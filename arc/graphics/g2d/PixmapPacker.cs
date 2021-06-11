// Decompiled with JetBrains decompiler
// Type: arc.graphics.g2d.PixmapPacker
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.files;
using arc.func;
using arc.graphics.gl;
using arc.math.geom;
using arc.util;
using IKVM.Attributes;
using IKVM.Runtime;
using java.io;
using java.lang;
using java.nio;
using java.util;
using java.util.function;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.graphics.g2d
{
  public class PixmapPacker : Object, Disposable
  {
    [Modifiers]
    [Signature("Larc/struct/Seq<Larc/graphics/g2d/PixmapPacker$Page;>;")]
    internal Seq pages;
    internal bool packToTexture;
    internal bool disposed;
    internal int pageWidth;
    internal int pageHeight;
    internal Pixmap.Format pageFormat;
    internal int padding;
    internal bool duplicateBorder;
    internal bool stripWhitespaceX;
    internal bool stripWhitespaceY;
    internal Color transparentColor;
    internal PixmapPacker.PackStrategy packStrategy;
    private Color c;

    [LineNumberTable(new byte[] {159, 118, 67, 115})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public PixmapPacker(
      int pageWidth,
      int pageHeight,
      Pixmap.Format pageFormat,
      int padding,
      bool duplicateBorder)
    {
      int num = duplicateBorder ? 1 : 0;
      // ISSUE: explicit constructor call
      this.\u002Ector(pageWidth, pageHeight, pageFormat, padding, num != 0, false, false, (PixmapPacker.PackStrategy) new PixmapPacker.GuillotineStrategy());
    }

    [LineNumberTable(new byte[] {160, 131, 127, 1, 114, 101, 98})]
    [MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
    public virtual Rect getRect(string name)
    {
      Iterator iterator = this.pages.iterator();
      while (iterator.hasNext())
      {
        Rect rect = (Rect) ((PixmapPacker.Page) iterator.next()).rects.get((object) name);
        if (rect != null)
          return rect;
      }
      return (Rect) null;
    }

    [LineNumberTable(new byte[] {115, 234, 69, 181, 98, 102, 121, 125, 109, 115, 119, 104, 145, 185, 126, 115, 191, 6, 111, 99, 110, 172, 159, 21, 159, 4, 107, 127, 6, 48, 167, 135, 144, 144, 107, 144, 122, 126, 126, 159, 3, 122, 126, 122, 190, 99, 166})]
    [MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
    public virtual Rect pack(string name, PixmapRegion image)
    {
      if (this.disposed)
        return (Rect) null;
      int num1 = name == null || !String.instancehelper_endsWith(name, ".9") ? 0 : 1;
      Pixmap pixmap = (Pixmap) null;
      PixmapPacker.PixmapPackerRect pixmapPackerRect;
      if (num1 != 0)
      {
        PixmapPacker.PixmapPackerRect.__\u003Cclinit\u003E();
        pixmapPackerRect = new PixmapPacker.PixmapPackerRect(0, 0, image.width, image.height);
        pixmap = new Pixmap(image.width, image.height, image.pixmap.getFormat());
        pixmapPackerRect.splits = this.getSplits(image);
        pixmapPackerRect.pads = this.getPads(image, pixmapPackerRect.splits);
        pixmap.draw(image, 0, 0, 0, 0, image.width, image.height);
        image = new PixmapRegion(pixmap);
        name = String.instancehelper_split(name, "\\.")[0];
      }
      else
      {
        PixmapPacker.PixmapPackerRect.__\u003Cclinit\u003E();
        pixmapPackerRect = new PixmapPacker.PixmapPackerRect(0, 0, image.width, image.height);
      }
      if ((double) pixmapPackerRect.width > (double) this.pageWidth || (double) pixmapPackerRect.height > (double) this.pageHeight)
      {
        if (name == null)
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new ArcRuntimeException("Page size too small for pixmap.");
        }
        string message = new StringBuilder().append("Page size too small for pixmap: ").append(name).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new ArcRuntimeException(message);
      }
      PixmapPacker.Page page = this.packStrategy.pack(this, name, (Rect) pixmapPackerRect);
      if (name != null)
      {
        page.rects.put((object) name, (object) pixmapPackerRect);
        page.addedRects.add((object) name);
      }
      int num2 = ByteCodeHelper.f2i(pixmapPackerRect.x);
      int num3 = ByteCodeHelper.f2i(pixmapPackerRect.y);
      int num4 = ByteCodeHelper.f2i(pixmapPackerRect.width);
      int num5 = ByteCodeHelper.f2i(pixmapPackerRect.height);
      if (this.packToTexture && !this.duplicateBorder && (page.texture != null && !page.dirty))
      {
        page.texture.bind();
        Gl.texSubImage2D(page.texture.__\u003C\u003EglTarget, 0, num2, num3, num4, num5, image.pixmap.getGLFormat(), image.pixmap.getGLType(), (Buffer) image.pixmap.getPixels());
      }
      else
        page.dirty = true;
      page.image.setBlending(Pixmap.Blending.__\u003C\u003Enone);
      page.image.draw(image, num2, num3);
      if (this.duplicateBorder)
      {
        int width = image.width;
        int height = image.height;
        page.image.draw(image, 0, 0, 1, 1, num2 - 1, num3 - 1, 1, 1);
        page.image.draw(image, width - 1, 0, 1, 1, num2 + num4, num3 - 1, 1, 1);
        page.image.draw(image, 0, height - 1, 1, 1, num2 - 1, num3 + num5, 1, 1);
        page.image.draw(image, width - 1, height - 1, 1, 1, num2 + num4, num3 + num5, 1, 1);
        page.image.draw(image, 0, 0, width, 1, num2, num3 - 1, num4, 1);
        page.image.draw(image, 0, height - 1, width, 1, num2, num3 + num5, num4, 1);
        page.image.draw(image, 0, 0, 1, height, num2 - 1, num3, 1, num5);
        page.image.draw(image, width - 1, 0, 1, height, num2 + num4, num3, 1, num5);
      }
      pixmap?.dispose();
      return (Rect) pixmapPackerRect;
    }

    [LineNumberTable(153)]
    [MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
    public virtual Rect pack(string name, Pixmap image) => this.pack(name, new PixmapRegion(image));

    [LineNumberTable(new byte[] {159, 64, 102, 105, 127, 4, 113, 127, 8, 116, 159, 30, 105, 110, 206, 105, 104, 111, 127, 9, 110, 142, 109, 112, 101, 111, 146, 101})]
    [MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
    public virtual void updateTextureAtlas(
      TextureAtlas atlas,
      Texture.TextureFilter minFilter,
      Texture.TextureFilter magFilter,
      bool useMipMaps,
      bool clearRects)
    {
      int num1 = useMipMaps ? 1 : 0;
      int num2 = clearRects ? 1 : 0;
      this.updatePageTextures(minFilter, magFilter, num1 != 0);
      Iterator iterator1 = this.pages.iterator();
      while (iterator1.hasNext())
      {
        PixmapPacker.Page page = (PixmapPacker.Page) iterator1.next();
        if (page.addedRects.size > 0)
        {
          Iterator iterator2 = page.addedRects.iterator();
          while (iterator2.hasNext())
          {
            string str = (string) iterator2.next();
            PixmapPacker.PixmapPackerRect pixmapPackerRect = (PixmapPacker.PixmapPackerRect) page.rects.get((object) str);
            TextureAtlas.AtlasRegion atlasRegion = new TextureAtlas.AtlasRegion(page.texture, ByteCodeHelper.f2i(pixmapPackerRect.x), ByteCodeHelper.f2i(pixmapPackerRect.y), ByteCodeHelper.f2i(pixmapPackerRect.width), ByteCodeHelper.f2i(pixmapPackerRect.height));
            if (pixmapPackerRect.splits != null)
            {
              atlasRegion.splits = pixmapPackerRect.splits;
              atlasRegion.pads = pixmapPackerRect.pads;
            }
            atlasRegion.name = str;
            atlasRegion.index = -1;
            atlasRegion.offsetX = (float) pixmapPackerRect.offsetX;
            atlasRegion.offsetY = (float) ByteCodeHelper.f2i((float) pixmapPackerRect.originalHeight - pixmapPackerRect.height - (float) pixmapPackerRect.offsetY);
            atlasRegion.originalWidth = pixmapPackerRect.originalWidth;
            atlasRegion.originalHeight = pixmapPackerRect.originalHeight;
            atlas.getRegions().add((object) atlasRegion);
            atlas.getRegionMap().put((object) str, (object) atlasRegion);
          }
          if (num2 != 0)
            page.addedRects.clear();
          atlas.getTextures().add((object) page.texture);
        }
      }
    }

    [LineNumberTable(new byte[] {160, 168, 127, 1, 104, 139, 98, 103})]
    [MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
    public virtual void dispose()
    {
      Iterator iterator = this.pages.iterator();
      while (iterator.hasNext())
      {
        PixmapPacker.Page page = (PixmapPacker.Page) iterator.next();
        if (page.texture == null)
          page.image.dispose();
      }
      this.disposed = true;
    }

    [Signature("()Larc/struct/Seq<Larc/graphics/g2d/PixmapPacker$Page;>;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Seq getPages() => this.pages;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Color getTransparentColor() => this.transparentColor;

    [LineNumberTable(new byte[] {159, 113, 105, 232, 26, 235, 72, 159, 0, 235, 93, 103, 103, 103, 104, 103, 103, 103, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public PixmapPacker(
      int pageWidth,
      int pageHeight,
      Pixmap.Format pageFormat,
      int padding,
      bool duplicateBorder,
      bool stripWhitespaceX,
      bool stripWhitespaceY,
      PixmapPacker.PackStrategy packStrategy)
    {
      int num1 = duplicateBorder ? 1 : 0;
      int num2 = stripWhitespaceX ? 1 : 0;
      int num3 = stripWhitespaceY ? 1 : 0;
      // ISSUE: explicit constructor call
      base.\u002Ector();
      PixmapPacker pixmapPacker = this;
      this.pages = new Seq();
      this.transparentColor = new Color(0.0f, 0.0f, 0.0f, 0.0f);
      this.c = new Color();
      this.pageWidth = pageWidth;
      this.pageHeight = pageHeight;
      this.pageFormat = pageFormat;
      this.padding = padding;
      this.duplicateBorder = num1 != 0;
      this.stripWhitespaceX = num2 != 0;
      this.stripWhitespaceY = num3 != 0;
      this.packStrategy = packStrategy;
    }

    [LineNumberTable(new byte[] {161, 58, 108, 108, 108, 172, 110, 174, 174, 99, 100, 175, 137, 99, 100, 175, 169})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private int[] getSplits([In] PixmapRegion obj0)
    {
      int splitPoint1 = this.getSplitPoint(obj0, 1, 0, true, true);
      int splitPoint2 = this.getSplitPoint(obj0, splitPoint1, 0, false, true);
      int splitPoint3 = this.getSplitPoint(obj0, 0, 1, true, false);
      int splitPoint4 = this.getSplitPoint(obj0, 0, splitPoint3, false, false);
      this.getSplitPoint(obj0, splitPoint2 + 1, 0, true, true);
      this.getSplitPoint(obj0, 0, splitPoint4 + 1, true, false);
      if (splitPoint1 == 0 && splitPoint2 == 0 && (splitPoint3 == 0 && splitPoint4 == 0))
        return (int[]) null;
      int num1;
      if (splitPoint1 != 0)
      {
        splitPoint1 += -1;
        num1 = obj0.width - 2 - (splitPoint2 - 1);
      }
      else
        num1 = obj0.width - 2;
      int num2;
      if (splitPoint3 != 0)
      {
        splitPoint3 += -1;
        num2 = obj0.height - 2 - (splitPoint4 - 1);
      }
      else
        num2 = obj0.height - 2;
      return new int[4]
      {
        splitPoint1,
        num1,
        splitPoint3,
        num2
      };
    }

    [LineNumberTable(new byte[] {161, 91, 105, 137, 108, 172, 99, 99, 114, 178, 111, 175, 110, 194, 103, 98, 133, 100, 100, 177, 170, 103, 98, 133, 100, 100, 177, 202, 154, 109, 162})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private int[] getPads([In] PixmapRegion obj0, [In] int[] obj1)
    {
      int num1 = obj0.height - 1;
      int num2 = obj0.width - 1;
      int num3 = this.getSplitPoint(obj0, 1, num1, true, true);
      int num4 = this.getSplitPoint(obj0, num2, 1, true, false);
      int num5 = 0;
      int num6 = 0;
      if (num3 != 0)
        num5 = this.getSplitPoint(obj0, num3 + 1, num1, false, true);
      if (num4 != 0)
        num6 = this.getSplitPoint(obj0, num2, num4 + 1, false, false);
      this.getSplitPoint(obj0, num5 + 1, num1, true, true);
      this.getSplitPoint(obj0, num2, num6 + 1, true, false);
      if (num3 == 0 && num5 == 0 && (num4 == 0 && num6 == 0))
        return (int[]) null;
      int num7;
      if (num3 == 0 && num5 == 0)
      {
        num3 = -1;
        num7 = -1;
      }
      else if (num3 > 0)
      {
        num3 += -1;
        num7 = obj0.width - 2 - (num5 - 1);
      }
      else
        num7 = obj0.width - 2;
      int num8;
      if (num4 == 0 && num6 == 0)
      {
        num4 = -1;
        num8 = -1;
      }
      else if (num4 > 0)
      {
        num4 += -1;
        num8 = obj0.height - 2 - (num6 - 1);
      }
      else
        num8 = obj0.height - 2;
      int[] numArray = new int[4]{ num3, num7, num4, num8 };
      return obj1 != null && Arrays.equals(numArray, obj1) ? (int[]) null : numArray;
    }

    [LineNumberTable(new byte[] {159, 54, 162, 127, 1, 108})]
    [MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
    public virtual void updatePageTextures(
      Texture.TextureFilter minFilter,
      Texture.TextureFilter magFilter,
      bool useMipMaps)
    {
      int num = useMipMaps ? 1 : 0;
      Iterator iterator = this.pages.iterator();
      while (iterator.hasNext())
        ((PixmapPacker.Page) iterator.next()).updateTexture(minFilter, magFilter, num != 0);
    }

    [LineNumberTable(new byte[] {159, 13, 134, 135, 104, 115, 141, 99, 99, 104, 99, 133, 131, 108, 110, 122, 122, 122, 122, 137, 100, 133})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private int getSplitPoint([In] PixmapRegion obj0, [In] int obj1, [In] int obj2, [In] bool obj3, [In] bool obj4)
    {
      int num1 = obj4 ? 1 : 0;
      int num2 = obj3 ? 1 : 0;
      int[] numArray = new int[4];
      int num3 = num1 == 0 ? obj2 : obj1;
      int num4 = num1 == 0 ? obj0.height : obj0.width;
      int num5 = num2 == 0 ? 0 : (int) byte.MaxValue;
      int x = obj1;
      int y = obj2;
      for (; num3 != num4; ++num3)
      {
        if (num1 != 0)
          x = num3;
        else
          y = num3;
        this.c.set(obj0.getPixel(x, y));
        numArray[0] = ByteCodeHelper.f2i(this.c.r * (float) byte.MaxValue);
        numArray[1] = ByteCodeHelper.f2i(this.c.g * (float) byte.MaxValue);
        numArray[2] = ByteCodeHelper.f2i(this.c.b * (float) byte.MaxValue);
        numArray[3] = ByteCodeHelper.f2i(this.c.a * (float) byte.MaxValue);
        if (numArray[3] == num5)
          return num3;
      }
      return 0;
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {161, 193, 104, 98, 127, 4, 113, 127, 28, 141, 107, 127, 7, 127, 47, 127, 21, 127, 37, 107, 127, 13, 127, 2, 116, 107, 127, 49, 127, 49, 108, 127, 91, 108, 191, 91, 127, 39, 127, 64, 107, 133, 101, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void save(
      Fi file,
      Texture.TextureFilter minFilter,
      Texture.TextureFilter maxFilter)
    {
      Writer writer = file.writer(false);
      int num1 = 0;
      Iterator iterator = this.pages.iterator();
label_1:
      while (iterator.hasNext())
      {
        PixmapPacker.Page page = (PixmapPacker.Page) iterator.next();
        if (page.rects.size > 0)
        {
          Fi fi = file;
          StringBuilder stringBuilder = new StringBuilder().append(file.nameWithoutExtension()).append("_");
          ++num1;
          int num2 = num1;
          string name = stringBuilder.append(num2).append(".PNG").toString();
          Fi file1 = fi.sibling(name);
          PixmapIO.writePNG(file1, page.image);
          writer.write("\n");
          writer.write(new StringBuilder().append(file1.name()).append("\n").toString());
          writer.write(new StringBuilder().append("size: ").append(page.image.getWidth()).append(",").append(page.image.getHeight()).append("\n").toString());
          writer.write(new StringBuilder().append("format: ").append(this.pageFormat.name()).append("\n").toString());
          writer.write(new StringBuilder().append("filter: ").append(minFilter.name()).append(",").append(maxFilter.name()).append("\n").toString());
          writer.write("repeat: none\n");
          ObjectMap.Keys keys = page.rects.keys().iterator();
          while (true)
          {
            if (((Iterator) keys).hasNext())
            {
              string str = (string) ((Iterator) keys).next();
              writer.write(new StringBuilder().append(str).append("\n").toString());
              PixmapPacker.PixmapPackerRect pixmapPackerRect = (PixmapPacker.PixmapPackerRect) page.rects.get((object) str);
              writer.write("  rotate: false\n");
              writer.write(new StringBuilder().append("  xy: ").append(ByteCodeHelper.f2i(pixmapPackerRect.x)).append(",").append(ByteCodeHelper.f2i(pixmapPackerRect.y)).append("\n").toString());
              writer.write(new StringBuilder().append("  size: ").append(ByteCodeHelper.f2i(pixmapPackerRect.width)).append(",").append(ByteCodeHelper.f2i(pixmapPackerRect.height)).append("\n").toString());
              if (pixmapPackerRect.splits != null)
              {
                writer.write(new StringBuilder().append("  split: ").append(pixmapPackerRect.splits[0]).append(", ").append(pixmapPackerRect.splits[1]).append(", ").append(pixmapPackerRect.splits[2]).append(", ").append(pixmapPackerRect.splits[3]).append("\n").toString());
                if (pixmapPackerRect.pads != null)
                  writer.write(new StringBuilder().append("  pad: ").append(pixmapPackerRect.pads[0]).append(", ").append(pixmapPackerRect.pads[1]).append(", ").append(pixmapPackerRect.pads[2]).append(", ").append(pixmapPackerRect.pads[3]).append("\n").toString());
              }
              writer.write(new StringBuilder().append("  orig: ").append(pixmapPackerRect.originalWidth).append(", ").append(pixmapPackerRect.originalHeight).append("\n").toString());
              writer.write(new StringBuilder().append("  offset: ").append(pixmapPackerRect.offsetX).append(", ").append(ByteCodeHelper.f2i((float) pixmapPackerRect.originalHeight - pixmapPackerRect.height - (float) pixmapPackerRect.offsetY)).append("\n").toString());
              writer.write("  index: -1\n");
            }
            else
              goto label_1;
          }
        }
      }
      writer.close();
    }

    [LineNumberTable(new byte[] {159, 116, 67, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public PixmapPacker(
      int pageWidth,
      int pageHeight,
      Pixmap.Format pageFormat,
      int padding,
      bool duplicateBorder,
      PixmapPacker.PackStrategy packStrategy)
    {
      int num = duplicateBorder ? 1 : 0;
      // ISSUE: explicit constructor call
      this.\u002Ector(pageWidth, pageHeight, pageFormat, padding, num != 0, false, false, packStrategy);
    }

    [Signature("(Larc/struct/Seq<Larc/graphics/Pixmap;>;)V")]
    [LineNumberTable(new byte[] {83, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void sort(Seq images) => this.packStrategy.sort(images);

    [LineNumberTable(141)]
    [MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
    public virtual Rect pack(Pixmap image) => this.pack((string) null, image);

    [LineNumberTable(new byte[] {160, 143, 127, 1, 114, 101, 98})]
    [MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
    public virtual PixmapPacker.Page getPage(string name)
    {
      Iterator iterator = this.pages.iterator();
      while (iterator.hasNext())
      {
        PixmapPacker.Page page = (PixmapPacker.Page) iterator.next();
        if ((Rect) page.rects.get((object) name) != null)
          return page;
      }
      return (PixmapPacker.Page) null;
    }

    [LineNumberTable(new byte[] {160, 156, 112, 127, 3, 5, 198})]
    [MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
    public virtual int getPageIndex(string name)
    {
      for (int index = 0; index < this.pages.size; ++index)
      {
        if ((Rect) ((PixmapPacker.Page) this.pages.get(index)).rects.get((object) name) != null)
          return index;
      }
      return -1;
    }

    [LineNumberTable(new byte[] {159, 69, 162, 102, 107})]
    [MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
    public virtual TextureAtlas generateTextureAtlas(
      Texture.TextureFilter minFilter,
      Texture.TextureFilter magFilter,
      bool useMipMaps)
    {
      int num = useMipMaps ? 1 : 0;
      TextureAtlas atlas = new TextureAtlas();
      this.updateTextureAtlas(atlas, minFilter, magFilter, num != 0, true);
      return atlas;
    }

    [LineNumberTable(new byte[] {159, 67, 131, 107})]
    [MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
    public virtual void updateTextureAtlas(
      TextureAtlas atlas,
      Texture.TextureFilter minFilter,
      Texture.TextureFilter magFilter,
      bool useMipMaps)
    {
      int num = useMipMaps ? 1 : 0;
      this.updateTextureAtlas(atlas, minFilter, magFilter, num != 0, true);
    }

    [Signature("(Larc/struct/Seq<Larc/graphics/g2d/TextureRegion;>;Larc/graphics/Texture$TextureFilter;Larc/graphics/Texture$TextureFilter;Z)V")]
    [LineNumberTable(new byte[] {159, 55, 67, 105, 115, 127, 9})]
    [MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
    public virtual void updateTextureRegions(
      Seq regions,
      Texture.TextureFilter minFilter,
      Texture.TextureFilter magFilter,
      bool useMipMaps)
    {
      int num = useMipMaps ? 1 : 0;
      this.updatePageTextures(minFilter, magFilter, num != 0);
      while (regions.size < this.pages.size)
        regions.add((object) new TextureRegion(((PixmapPacker.Page) this.pages.get(regions.size)).texture));
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getPageWidth() => this.pageWidth;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setPageWidth(int pageWidth) => this.pageWidth = pageWidth;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getPageHeight() => this.pageHeight;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setPageHeight(int pageHeight) => this.pageHeight = pageHeight;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Pixmap.Format getPageFormat() => this.pageFormat;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setPageFormat(Pixmap.Format pageFormat) => this.pageFormat = pageFormat;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getPadding() => this.padding;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setPadding(int padding) => this.padding = padding;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool getDuplicateBorder() => this.duplicateBorder;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setDuplicateBorder(bool duplicateBorder) => this.duplicateBorder = duplicateBorder;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool getPackToTexture() => this.packToTexture;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setPackToTexture(bool packToTexture) => this.packToTexture = packToTexture;

    [LineNumberTable(new byte[] {161, 53, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setTransparentColor(Color color) => this.transparentColor.set(color);

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {161, 183, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void save(Fi file) => this.save(file, Texture.TextureFilter.__\u003C\u003Enearest, Texture.TextureFilter.__\u003C\u003Enearest);

    [HideFromJava]
    public virtual bool isDisposed() => Disposable.\u003Cdefault\u003EisDisposed((Disposable) this);

    public class GuillotineStrategy : Object, PixmapPacker.PackStrategy
    {
      [Signature("Ljava/util/Comparator<Larc/graphics/Pixmap;>;")]
      internal Comparator comparator;

      [LineNumberTable(new byte[] {162, 98, 120, 110, 113, 130, 106, 127, 9, 159, 9, 107, 139, 125, 125, 103, 123, 123, 118, 155, 127, 4, 123, 127, 4, 159, 1, 123, 123, 123, 150, 123, 127, 4, 123, 191, 4})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private PixmapPacker.GuillotineStrategy.Node insert(
        [In] PixmapPacker.GuillotineStrategy.Node obj0,
        [In] Rect obj1)
      {
        if (!obj0.full && obj0.leftChild != null && obj0.rightChild != null)
          return this.insert(obj0.leftChild, obj1) ?? this.insert(obj0.rightChild, obj1);
        if (obj0.full)
          return (PixmapPacker.GuillotineStrategy.Node) null;
        if ((double) obj0.rect.width == (double) obj1.width && (double) obj0.rect.height == (double) obj1.height)
          return obj0;
        if ((double) obj0.rect.width < (double) obj1.width || (double) obj0.rect.height < (double) obj1.height)
          return (PixmapPacker.GuillotineStrategy.Node) null;
        obj0.leftChild = new PixmapPacker.GuillotineStrategy.Node();
        obj0.rightChild = new PixmapPacker.GuillotineStrategy.Node();
        if (ByteCodeHelper.f2i(obj0.rect.width) - ByteCodeHelper.f2i(obj1.width) > ByteCodeHelper.f2i(obj0.rect.height) - ByteCodeHelper.f2i(obj1.height))
        {
          obj0.leftChild.rect.x = obj0.rect.x;
          obj0.leftChild.rect.y = obj0.rect.y;
          obj0.leftChild.rect.width = obj1.width;
          obj0.leftChild.rect.height = obj0.rect.height;
          obj0.rightChild.rect.x = obj0.rect.x + obj1.width;
          obj0.rightChild.rect.y = obj0.rect.y;
          obj0.rightChild.rect.width = obj0.rect.width - obj1.width;
          obj0.rightChild.rect.height = obj0.rect.height;
        }
        else
        {
          obj0.leftChild.rect.x = obj0.rect.x;
          obj0.leftChild.rect.y = obj0.rect.y;
          obj0.leftChild.rect.width = obj0.rect.width;
          obj0.leftChild.rect.height = obj1.height;
          obj0.rightChild.rect.x = obj0.rect.x;
          obj0.rightChild.rect.y = obj0.rect.y + obj1.height;
          obj0.rightChild.rect.width = obj0.rect.width;
          obj0.rightChild.rect.height = obj0.rect.height - obj1.height;
        }
        return this.insert(obj0.leftChild, obj1);
      }

      [Modifiers]
      [LineNumberTable(691)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static int lambda\u0024sort\u00240([In] Pixmap obj0) => Math.max(obj0.getWidth(), obj0.getHeight());

      [LineNumberTable(685)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public GuillotineStrategy()
      {
      }

      [Signature("(Larc/struct/Seq<Larc/graphics/Pixmap;>;)V")]
      [LineNumberTable(new byte[] {162, 64, 104, 149, 109})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void sort(Seq pixmaps)
      {
        if (this.comparator == null)
          this.comparator = Structs.comparingInt((Intf) new PixmapPacker.GuillotineStrategy.__\u003C\u003EAnon0());
        pixmaps.sort(this.comparator);
      }

      [LineNumberTable(new byte[] {162, 73, 141, 103, 174, 177, 103, 112, 112, 110, 131, 103, 108, 142, 103, 127, 28})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual PixmapPacker.Page pack(
        PixmapPacker packer,
        string name,
        Rect rect)
      {
        PixmapPacker.GuillotineStrategy.GuillotinePage guillotinePage;
        if (packer.pages.size == 0)
        {
          guillotinePage = new PixmapPacker.GuillotineStrategy.GuillotinePage(packer);
          packer.pages.add((object) guillotinePage);
        }
        else
          guillotinePage = (PixmapPacker.GuillotineStrategy.GuillotinePage) packer.pages.peek();
        int padding = packer.padding;
        rect.width += (float) padding;
        rect.height += (float) padding;
        PixmapPacker.GuillotineStrategy.Node node = this.insert(guillotinePage.root, rect);
        if (node == null)
        {
          guillotinePage = new PixmapPacker.GuillotineStrategy.GuillotinePage(packer);
          packer.pages.add((object) guillotinePage);
          node = this.insert(guillotinePage.root, rect);
        }
        node.full = true;
        rect.set(node.rect.x, node.rect.y, node.rect.width - (float) padding, node.rect.height - (float) padding);
        return (PixmapPacker.Page) guillotinePage;
      }

      public class GuillotinePage : PixmapPacker.Page
      {
        internal PixmapPacker.GuillotineStrategy.Node root;

        [LineNumberTable(new byte[] {162, 149, 105, 107, 119, 119, 127, 1, 127, 1})]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public GuillotinePage(PixmapPacker packer)
          : base(packer)
        {
          PixmapPacker.GuillotineStrategy.GuillotinePage guillotinePage = this;
          this.root = new PixmapPacker.GuillotineStrategy.Node();
          this.root.rect.x = (float) packer.padding;
          this.root.rect.y = (float) packer.padding;
          this.root.rect.width = (float) (packer.pageWidth - packer.padding * 2);
          this.root.rect.height = (float) (packer.pageHeight - packer.padding * 2);
        }

        [LineNumberTable(new byte[] {162, 158, 105, 107, 119, 119, 127, 1, 127, 1})]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public GuillotinePage(PixmapPacker packer, Pixmap @base)
          : base(@base)
        {
          PixmapPacker.GuillotineStrategy.GuillotinePage guillotinePage = this;
          this.root = new PixmapPacker.GuillotineStrategy.Node();
          this.root.rect.x = (float) packer.padding;
          this.root.rect.y = (float) packer.padding;
          this.root.rect.width = (float) (packer.pageWidth - packer.padding * 2);
          this.root.rect.height = (float) (packer.pageHeight - packer.padding * 2);
        }
      }

      internal sealed class Node : Object
      {
        [Modifiers]
        public Rect rect;
        public PixmapPacker.GuillotineStrategy.Node leftChild;
        public PixmapPacker.GuillotineStrategy.Node rightChild;
        public bool full;

        [LineNumberTable(new byte[] {162, 138, 104})]
        [MethodImpl(MethodImplOptions.NoInlining)]
        internal Node()
        {
          PixmapPacker.GuillotineStrategy.Node node = this;
          this.rect = new Rect();
        }
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon0 : Intf
      {
        internal __\u003C\u003EAnon0()
        {
        }

        public int get([In] object obj0) => PixmapPacker.GuillotineStrategy.lambda\u0024sort\u00240((Pixmap) obj0);
      }
    }

    public interface PackStrategy
    {
      [Signature("(Larc/struct/Seq<Larc/graphics/Pixmap;>;)V")]
      void sort(Seq s);

      PixmapPacker.Page pack(PixmapPacker pp, string str, Rect r);
    }

    public class Page : Object
    {
      [Modifiers]
      [Signature("Larc/struct/Seq<Ljava/lang/String;>;")]
      internal Seq addedRects;
      [Signature("Larc/struct/OrderedMap<Ljava/lang/String;Larc/graphics/g2d/PixmapPacker$PixmapPackerRect;>;")]
      internal OrderedMap rects;
      internal Pixmap image;
      internal Texture texture;
      internal bool dirty;

      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void setDirty(bool dirty) => this.dirty = dirty;

      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual Texture getTexture() => this.texture;

      [LineNumberTable(new byte[] {158, 234, 130, 104, 106, 152, 255, 5, 73, 141, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual bool updateTexture(
        Texture.TextureFilter minFilter,
        Texture.TextureFilter magFilter,
        bool useMipMaps)
      {
        int num = useMipMaps ? 1 : 0;
        if (this.texture != null)
        {
          if (!this.dirty)
            return false;
          this.texture.load(this.texture.getTextureData());
        }
        else
        {
          this.texture = (Texture) new PixmapPacker.Page.\u0031(this, (TextureData) new PixmapTextureData(this.image, this.image.getFormat(), num != 0, false));
          this.texture.setFilter(minFilter, magFilter);
        }
        this.dirty = false;
        return true;
      }

      [LineNumberTable(new byte[] {161, 251, 232, 57, 107, 235, 71, 125, 103, 108, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public Page(PixmapPacker packer)
      {
        PixmapPacker.Page page = this;
        this.addedRects = new Seq();
        this.rects = new OrderedMap();
        this.image = new Pixmap(packer.pageWidth, packer.pageHeight, packer.pageFormat);
        this.image.setColor(packer.getTransparentColor());
        this.image.fill();
      }

      [LineNumberTable(new byte[] {162, 2, 232, 50, 107, 235, 78, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public Page(Pixmap pixmap)
      {
        PixmapPacker.Page page = this;
        this.addedRects = new Seq();
        this.rects = new OrderedMap();
        this.image = pixmap;
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual Pixmap getPixmap() => this.image;

      [Signature("()Larc/struct/OrderedMap<Ljava/lang/String;Larc/graphics/g2d/PixmapPacker$PixmapPackerRect;>;")]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual OrderedMap getRects() => this.rects;

      [EnclosingMethod(null, "updateTexture", "(Larc.graphics.Texture$TextureFilter;Larc.graphics.Texture$TextureFilter;Z)Z")]
      [SpecialName]
      internal class \u0031 : Texture
      {
        [Modifiers]
        internal PixmapPacker.Page this\u00240;

        [LineNumberTable(662)]
        [MethodImpl(MethodImplOptions.NoInlining)]
        internal \u0031([In] PixmapPacker.Page obj0, [In] TextureData obj1)
        {
          this.this\u00240 = obj0;
          // ISSUE: explicit constructor call
          base.\u002Ector(obj1);
        }

        [LineNumberTable(new byte[] {162, 39, 102, 114, 144})]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public override void dispose()
        {
          base.dispose();
          if (this.this\u00240.image.isDisposed())
            return;
          this.this\u00240.image.dispose();
        }
      }
    }

    public class PixmapPackerRect : Rect
    {
      public int[] splits;
      public int[] pads;
      internal int offsetX;
      internal int offsetY;
      internal int originalWidth;
      internal int originalHeight;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {162, 253, 113, 103, 103, 103, 104})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public PixmapPackerRect(int x, int y, int width, int height)
        : base((float) x, (float) y, (float) width, (float) height)
      {
        PixmapPacker.PixmapPackerRect pixmapPackerRect = this;
        this.offsetX = 0;
        this.offsetY = 0;
        this.originalWidth = width;
        this.originalHeight = height;
      }

      [LineNumberTable(new byte[] {163, 5, 113, 104, 104, 104, 104})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public PixmapPackerRect(
        int x,
        int y,
        int width,
        int height,
        int left,
        int top,
        int originalWidth,
        int originalHeight)
        : base((float) x, (float) y, (float) width, (float) height)
      {
        PixmapPacker.PixmapPackerRect pixmapPackerRect = this;
        this.offsetX = left;
        this.offsetY = top;
        this.originalWidth = originalWidth;
        this.originalHeight = originalHeight;
      }

      [HideFromJava]
      static PixmapPackerRect() => Rect.__\u003Cclinit\u003E();
    }

    public class SkylineStrategy : Object, PixmapPacker.PackStrategy
    {
      [Signature("Ljava/util/Comparator<Larc/graphics/Pixmap;>;")]
      internal Comparator comparator;

      [Modifiers]
      [LineNumberTable(803)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static int lambda\u0024sort\u00240([In] Pixmap obj0, [In] Pixmap obj1) => obj0.getHeight() - obj1.getHeight();

      [LineNumberTable(798)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public SkylineStrategy()
      {
      }

      [Signature("(Larc/struct/Seq<Larc/graphics/Pixmap;>;)V")]
      [LineNumberTable(new byte[] {162, 176, 104, 144, 109})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void sort(Seq images)
      {
        if (this.comparator == null)
          this.comparator = (Comparator) new PixmapPacker.SkylineStrategy.__\u003C\u003EAnon0();
        images.sort(this.comparator);
      }

      [LineNumberTable(new byte[] {162, 183, 103, 118, 125, 121, 116, 131, 124, 117, 110, 111, 109, 248, 59, 235, 71, 135, 115, 114, 108, 117, 102, 149, 103, 118, 105, 174, 100, 110, 110, 111, 227, 34, 235, 98, 104, 109, 103, 106, 104, 105, 110, 104, 104})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual PixmapPacker.Page pack(
        PixmapPacker packer,
        string name,
        Rect rect)
      {
        int padding = packer.padding;
        int num1 = packer.pageWidth - padding * 2;
        int num2 = packer.pageHeight - padding * 2;
        int num3 = ByteCodeHelper.f2i(rect.width) + padding;
        int num4 = ByteCodeHelper.f2i(rect.height) + padding;
        int index1 = 0;
        for (int size = packer.pages.size; index1 < size; ++index1)
        {
          PixmapPacker.SkylineStrategy.SkylinePage skylinePage = (PixmapPacker.SkylineStrategy.SkylinePage) packer.pages.get(index1);
          PixmapPacker.SkylineStrategy.SkylinePage.Row row1 = (PixmapPacker.SkylineStrategy.SkylinePage.Row) null;
          int index2 = 0;
          for (int index3 = skylinePage.rows.size - 1; index2 < index3; ++index2)
          {
            PixmapPacker.SkylineStrategy.SkylinePage.Row row2 = (PixmapPacker.SkylineStrategy.SkylinePage.Row) skylinePage.rows.get(index2);
            if (row2.x + num3 < num1 && row2.y + num4 < num2 && num4 <= row2.height && (row1 == null || row2.height < row1.height))
              row1 = row2;
          }
          if (row1 == null)
          {
            PixmapPacker.SkylineStrategy.SkylinePage.Row row2 = (PixmapPacker.SkylineStrategy.SkylinePage.Row) skylinePage.rows.peek();
            if (row2.y + num4 < num2)
            {
              if (row2.x + num3 < num1)
              {
                row2.height = Math.max(row2.height, num4);
                row1 = row2;
              }
              else if (row2.y + row2.height + num4 < num2)
              {
                row1 = new PixmapPacker.SkylineStrategy.SkylinePage.Row();
                row1.y = row2.y + row2.height;
                row1.height = num4;
                skylinePage.rows.add((object) row1);
              }
            }
            else
              continue;
          }
          if (row1 != null)
          {
            rect.x = (float) row1.x;
            rect.y = (float) row1.y;
            row1.x += num3;
            return (PixmapPacker.Page) skylinePage;
          }
        }
        PixmapPacker.SkylineStrategy.SkylinePage skylinePage1 = new PixmapPacker.SkylineStrategy.SkylinePage(packer);
        packer.pages.add((object) skylinePage1);
        skylinePage1.rows.add((object) new PixmapPacker.SkylineStrategy.SkylinePage.Row()
        {
          x = (padding + num3),
          y = padding,
          height = num4
        });
        rect.x = (float) padding;
        rect.y = (float) padding;
        return (PixmapPacker.Page) skylinePage1;
      }

      internal class SkylinePage : PixmapPacker.Page
      {
        [Signature("Larc/struct/Seq<Larc/graphics/g2d/PixmapPacker$SkylineStrategy$SkylinePage$Row;>;")]
        internal Seq rows;

        [LineNumberTable(new byte[] {162, 236, 233, 61, 235, 69})]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public SkylinePage([In] PixmapPacker obj0)
          : base(obj0)
        {
          PixmapPacker.SkylineStrategy.SkylinePage skylinePage = this;
          this.rows = new Seq();
        }

        internal class Row : Object
        {
          internal int x;
          internal int y;
          internal int height;

          [LineNumberTable(866)]
          [MethodImpl(MethodImplOptions.NoInlining)]
          internal Row()
          {
          }
        }
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon0 : Comparator
      {
        internal __\u003C\u003EAnon0()
        {
        }

        public int compare([In] object obj0, [In] object obj1) => PixmapPacker.SkylineStrategy.lambda\u0024sort\u00240((Pixmap) obj0, (Pixmap) obj1);

        [SpecialName]
        public Comparator thenComparing([In] Comparator obj0) => Comparator.\u003Cdefault\u003EthenComparing((Comparator) this, obj0);

        [SpecialName]
        public bool equals([In] object obj0) => Object.instancehelper_equals((object) this, obj0);

        [SpecialName]
        public Comparator reversed() => Comparator.\u003Cdefault\u003Ereversed((Comparator) this);

        [SpecialName]
        public Comparator thenComparing([In] Function obj0, [In] Comparator obj1) => Comparator.\u003Cdefault\u003EthenComparing((Comparator) this, obj0, obj1);

        [SpecialName]
        public Comparator thenComparing([In] Function obj0) => Comparator.\u003Cdefault\u003EthenComparing((Comparator) this, obj0);

        [SpecialName]
        public Comparator thenComparingInt([In] ToIntFunction obj0) => Comparator.\u003Cdefault\u003EthenComparingInt((Comparator) this, obj0);

        [SpecialName]
        public Comparator thenComparingLong([In] ToLongFunction obj0) => Comparator.\u003Cdefault\u003EthenComparingLong((Comparator) this, obj0);

        [SpecialName]
        public Comparator thenComparingDouble([In] ToDoubleFunction obj0) => Comparator.\u003Cdefault\u003EthenComparingDouble((Comparator) this, obj0);
      }
    }
  }
}
