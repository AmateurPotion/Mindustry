// Decompiled with JetBrains decompiler
// Type: arc.graphics.g2d.TextureAtlas
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.files;
using arc.func;
using arc.scene.style;
using arc.util;
using arc.util.io;
using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.io;
using java.lang;
using java.util;
using java.util.function;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.graphics.g2d
{
  public class TextureAtlas : Object, Disposable
  {
    [Modifiers]
    internal static string[] tuple;
    [Modifiers]
    [Signature("Ljava/util/Comparator<Larc/graphics/g2d/TextureAtlas$TextureAtlasData$Region;>;")]
    internal static Comparator indexComparator;
    [Modifiers]
    [Signature("Larc/struct/ObjectSet<Larc/graphics/Texture;>;")]
    private ObjectSet textures;
    [Modifiers]
    [Signature("Larc/struct/Seq<Larc/graphics/g2d/TextureAtlas$AtlasRegion;>;")]
    private Seq regions;
    [Modifiers]
    [Signature("Larc/struct/ObjectMap<Ljava/lang/String;Larc/scene/style/Drawable;>;")]
    private ObjectMap drawables;
    [Modifiers]
    [Signature("Larc/struct/ObjectMap<Ljava/lang/String;Larc/graphics/g2d/TextureAtlas$AtlasRegion;>;")]
    private ObjectMap regionmap;
    [Modifiers]
    [Signature("Larc/struct/ObjectMap<Larc/graphics/Texture;Larc/graphics/Pixmap;>;")]
    private ObjectMap pixmaps;
    protected internal float drawableScale;
    protected internal TextureAtlas.AtlasRegion error;
    protected internal TextureAtlas.AtlasRegion white;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 187, 102, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static TextureAtlas blankAtlas() => new TextureAtlas()
    {
      white = new TextureAtlas.AtlasRegion(Pixmaps.blankTextureRegion())
    };

    [LineNumberTable(new byte[] {160, 118, 114, 120, 127, 16, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual TextureAtlas.AtlasRegion find(string name)
    {
      TextureAtlas.AtlasRegion atlasRegion = (TextureAtlas.AtlasRegion) this.regionmap.get((object) name);
      if (atlasRegion == null && this.error == null && !String.instancehelper_equals(name, (object) "error"))
      {
        string str = new StringBuilder().append("The region \"").append(name).append("\" does not exist!").toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException(str);
      }
      return atlasRegion ?? this.error;
    }

    [LineNumberTable(new byte[] {160, 130, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual TextureRegion find(string name, TextureRegion def)
    {
      TextureRegion textureRegion = (TextureRegion) this.regionmap.get((object) name);
      return textureRegion == null || object.ReferenceEquals((object) textureRegion, (object) this.error) ? def : textureRegion;
    }

    [LineNumberTable(new byte[] {110, 104, 127, 3, 191, 5})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual PixmapRegion getPixmap(TextureAtlas.AtlasRegion region)
    {
      if (region.pixmapRegion == null)
      {
        Pixmap pixmap = (Pixmap) this.pixmaps.get((object) region.texture, (Prov) new TextureAtlas.__\u003C\u003EAnon0(region));
        region.pixmapRegion = new PixmapRegion(pixmap, region.getX(), region.getY(), region.width, region.height);
      }
      return region.pixmapRegion;
    }

    [LineNumberTable(176)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual PixmapRegion getPixmap(TextureRegion region) => this.getPixmap((TextureAtlas.AtlasRegion) region);

    [LineNumberTable(249)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool has(string s) => this.regionmap.containsKey((object) s);

    [LineNumberTable(156)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual PixmapRegion getPixmap(string name) => this.getPixmap(this.find(name));

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isFound(TextureRegion region) => !object.ReferenceEquals((object) region, (object) this.error);

    [LineNumberTable(240)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual TextureRegion find(string name, string def) => this.find(name, (TextureRegion) this.find(def));

    [Signature("<T::Larc/scene/style/Drawable;>(Ljava/lang/String;)TT;")]
    [LineNumberTable(254)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Drawable getDrawable(string name) => this.drawable(name);

    [LineNumberTable(new byte[] {160, 146, 110, 178, 130, 108, 136, 107, 103, 120, 104, 126, 109, 98, 205, 127, 27, 111, 142})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Drawable drawable(string name)
    {
      if (this.drawables.containsKey((object) name))
        return (Drawable) this.drawables.get((object) name);
      BaseDrawable baseDrawable = (BaseDrawable) null;
      if (this.has(name))
      {
        TextureAtlas.AtlasRegion atlasRegion = this.find(name);
        if (atlasRegion.splits != null)
        {
          int[] splits = atlasRegion.splits;
          NinePatch.__\u003Cclinit\u003E();
          NinePatch patch = new NinePatch((TextureRegion) atlasRegion, splits[0], splits[1], splits[2], splits[3]);
          int[] pads = atlasRegion.pads;
          if (pads != null)
            patch.setPadding((float) pads[0], (float) pads[1], (float) pads[2], (float) pads[3]);
          baseDrawable = (BaseDrawable) new ScaledNinePatchDrawable(patch, this.drawableScale);
        }
        else
          baseDrawable = (BaseDrawable) new TextureRegionDrawable((TextureRegion) atlasRegion, this.drawableScale);
      }
      if (this.error == null && baseDrawable == null)
      {
        string str = new StringBuilder().append("No drawable '").append(name).append("' found.").toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException(str);
      }
      if (baseDrawable == null)
        baseDrawable = (BaseDrawable) new TextureRegionDrawable((TextureRegion) this.error);
      this.drawables.put((object) name, (object) baseDrawable);
      return (Drawable) baseDrawable;
    }

    [LineNumberTable(new byte[] {14, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public TextureAtlas(Fi packFile)
      : this(packFile, packFile.parent())
    {
    }

    [Signature("()Larc/struct/Seq<Larc/graphics/g2d/TextureAtlas$AtlasRegion;>;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Seq getRegions() => this.regions;

    [LineNumberTable(new byte[] {1, 232, 48, 108, 107, 107, 107, 107, 235, 76})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public TextureAtlas()
    {
      TextureAtlas textureAtlas = this;
      this.textures = new ObjectSet(4);
      this.regions = new Seq();
      this.drawables = new ObjectMap();
      this.regionmap = new ObjectMap();
      this.pixmaps = new ObjectMap();
      this.drawableScale = 1f;
    }

    [LineNumberTable(new byte[] {160, 104, 115, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool setErrorRegion(string name)
    {
      if (this.error != null || !this.has(name))
        return false;
      this.error = this.find(name);
      return true;
    }

    [Signature("()Larc/struct/ObjectSet<Larc/graphics/Texture;>;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual ObjectSet getTextures() => this.textures;

    [LineNumberTable(new byte[] {119, 110, 118, 141})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void disposePixmap(Texture texture)
    {
      if (!this.pixmaps.containsKey((object) texture))
        return;
      ((Pixmap) this.pixmaps.get((object) texture)).dispose();
      this.pixmaps.remove((object) texture);
    }

    [LineNumberTable(new byte[] {35, 232, 14, 108, 107, 107, 107, 107, 235, 110, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public TextureAtlas(TextureAtlas.TextureAtlasData data)
    {
      TextureAtlas textureAtlas = this;
      this.textures = new ObjectSet(4);
      this.regions = new Seq();
      this.drawables = new ObjectMap();
      this.regionmap = new ObjectMap();
      this.pixmaps = new ObjectMap();
      this.drawableScale = 1f;
      if (data == null)
        return;
      this.load(data);
    }

    [LineNumberTable(new byte[] {160, 96, 104, 145})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual TextureAtlas.AtlasRegion white()
    {
      if (this.white == null)
        this.white = this.find(nameof (white));
      return this.white;
    }

    [Signature("()Larc/struct/ObjectMap<Ljava/lang/String;Larc/graphics/g2d/TextureAtlas$AtlasRegion;>;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual ObjectMap getRegionMap() => this.regionmap;

    [LineNumberTable(new byte[] {26, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public TextureAtlas(Fi packFile, Fi imagesDir)
      : this(packFile, imagesDir, false)
    {
    }

    [LineNumberTable(new byte[] {159, 122, 98, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public TextureAtlas(Fi packFile, Fi imagesDir, bool flip)
    {
      int num = flip ? 1 : 0;
      // ISSUE: explicit constructor call
      this.\u002Ector(new TextureAtlas.TextureAtlasData(packFile, imagesDir, num != 0));
    }

    [LineNumberTable(new byte[] {67, 102, 127, 4, 98, 104, 120, 114, 148, 103, 114, 146, 109, 105, 133, 127, 5, 105, 105, 127, 1, 127, 6, 110, 110, 110, 110, 110, 110, 110, 110, 110, 114, 109, 117, 133, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void load([In] TextureAtlas.TextureAtlasData obj0)
    {
      ObjectMap objectMap = new ObjectMap();
      Iterator iterator1 = obj0.pages.iterator();
      while (iterator1.hasNext())
      {
        TextureAtlas.TextureAtlasData.AtlasPage atlasPage = (TextureAtlas.TextureAtlasData.AtlasPage) iterator1.next();
        Texture texture;
        if (atlasPage.texture == null)
        {
          texture = new Texture(atlasPage.__\u003C\u003EtextureFile, atlasPage.__\u003C\u003Eformat, atlasPage.__\u003C\u003EuseMipMaps);
          texture.setFilter(atlasPage.__\u003C\u003EminFilter, atlasPage.__\u003C\u003EmagFilter);
          texture.setWrap(atlasPage.__\u003C\u003EuWrap, atlasPage.__\u003C\u003EvWrap);
        }
        else
        {
          texture = atlasPage.texture;
          texture.setFilter(atlasPage.__\u003C\u003EminFilter, atlasPage.__\u003C\u003EmagFilter);
          texture.setWrap(atlasPage.__\u003C\u003EuWrap, atlasPage.__\u003C\u003EvWrap);
        }
        this.textures.add((object) texture);
        objectMap.put((object) atlasPage, (object) texture);
      }
      Iterator iterator2 = obj0.regions.iterator();
      while (iterator2.hasNext())
      {
        TextureAtlas.TextureAtlasData.Region region = (TextureAtlas.TextureAtlasData.Region) iterator2.next();
        int width = region.width;
        int height = region.height;
        TextureAtlas.AtlasRegion atlasRegion = new TextureAtlas.AtlasRegion((Texture) objectMap.get((object) region.page), region.left, region.top, !region.rotate ? width : height, !region.rotate ? height : width);
        atlasRegion.index = region.index;
        atlasRegion.name = region.name;
        atlasRegion.offsetX = region.offsetX;
        atlasRegion.offsetY = region.offsetY;
        atlasRegion.originalHeight = region.originalHeight;
        atlasRegion.originalWidth = region.originalWidth;
        atlasRegion.rotate = region.rotate;
        atlasRegion.splits = region.splits;
        atlasRegion.pads = region.pads;
        if (region.flip)
          atlasRegion.flip(false, true);
        this.regions.add((object) atlasRegion);
        this.regionmap.put((object) atlasRegion.name, (object) atlasRegion);
      }
      this.error = this.find("error");
    }

    [LineNumberTable(new byte[] {160, 67, 109, 110, 103, 104, 104, 103, 108, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual TextureAtlas.AtlasRegion addRegion(
      string name,
      Texture texture,
      int x,
      int y,
      int width,
      int height)
    {
      this.textures.add((object) texture);
      TextureAtlas.AtlasRegion atlasRegion = new TextureAtlas.AtlasRegion(texture, x, y, width, height);
      atlasRegion.name = name;
      atlasRegion.originalWidth = width;
      atlasRegion.originalHeight = height;
      atlasRegion.index = -1;
      this.regions.add((object) atlasRegion);
      this.regionmap.put((object) name, (object) atlasRegion);
      return atlasRegion;
    }

    [Modifiers]
    [LineNumberTable(161)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static Pixmap lambda\u0024getPixmap\u00241([In] TextureAtlas.AtlasRegion obj0) => obj0.texture.getTextureData().getPixmap();

    [Modifiers]
    [LineNumberTable(new byte[] {159, 171, 103, 106, 103, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static int lambda\u0024static\u00240(
      [In] TextureAtlas.TextureAtlasData.Region obj0,
      [In] TextureAtlas.TextureAtlasData.Region obj1)
    {
      int num1 = obj0.index;
      if (num1 == -1)
        num1 = int.MaxValue;
      int num2 = obj1.index;
      if (num2 == -1)
        num2 = int.MaxValue;
      return num1 - num2;
    }

    [LineNumberTable(new byte[] {9, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public TextureAtlas(string internalPackFile)
      : this(Core.files.@internal(internalPackFile))
    {
    }

    [LineNumberTable(new byte[] {159, 124, 66, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public TextureAtlas(Fi packFile, bool flip)
    {
      int num = flip ? 1 : 0;
      // ISSUE: explicit constructor call
      this.\u002Ector(packFile, packFile.parent(), num != 0);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setDrawableScale(float scale) => this.drawableScale = scale;

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {44, 103, 105, 127, 10})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static string readValue([In] BufferedReader obj0)
    {
      string str = obj0.readLine();
      int num = String.instancehelper_indexOf(str, 58);
      if (num == -1)
      {
        string message = new StringBuilder().append("Invalid line: ").append(str).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new ArcRuntimeException(message);
      }
      return String.instancehelper_trim(String.instancehelper_substring(str, num + 1));
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {52, 103, 105, 127, 10, 102, 102, 107, 103, 117, 229, 60, 230, 70, 115})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static int readTuple([In] BufferedReader obj0)
    {
      string str = obj0.readLine();
      int num1 = String.instancehelper_indexOf(str, 58);
      if (num1 == -1)
      {
        string message = new StringBuilder().append("Invalid line: ").append(str).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new ArcRuntimeException(message);
      }
      int num2 = num1 + 1;
      int index;
      for (index = 0; index < 3; ++index)
      {
        int num3 = String.instancehelper_indexOf(str, 44, num2);
        if (num3 != -1)
        {
          TextureAtlas.tuple[index] = String.instancehelper_trim(String.instancehelper_substring(str, num2, num3));
          num2 = num3 + 1;
        }
        else
          break;
      }
      TextureAtlas.tuple[index] = String.instancehelper_trim(String.instancehelper_substring(str, num2));
      return index + 1;
    }

    [LineNumberTable(194)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual TextureAtlas.AtlasRegion addRegion(
      string name,
      TextureRegion textureRegion)
    {
      return this.addRegion(name, textureRegion.texture, textureRegion.getX(), textureRegion.getY(), textureRegion.width, textureRegion.height);
    }

    [Signature("(Ljava/lang/String;)Larc/struct/Seq<Larc/graphics/g2d/TextureAtlas$AtlasRegion;>;")]
    [LineNumberTable(new byte[] {160, 178, 107, 114, 114, 26, 198})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Seq findRegions(string name)
    {
      Seq seq = new Seq((Class) ClassLiteral<TextureAtlas.AtlasRegion>.Value);
      int index = 0;
      for (int size = this.regions.size; index < size; ++index)
      {
        TextureAtlas.AtlasRegion region = (TextureAtlas.AtlasRegion) this.regions.get(index);
        if (String.instancehelper_equals(region.name, (object) name))
          seq.add((object) new TextureAtlas.AtlasRegion(region));
      }
      return seq;
    }

    [LineNumberTable(new byte[] {160, 193, 117, 114, 113, 103, 127, 9, 121, 104, 127, 12, 227, 56, 233, 75})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual NinePatch createPatch(string name)
    {
      int index = 0;
      for (int size = this.regions.size; index < size; ++index)
      {
        TextureAtlas.AtlasRegion atlasRegion = (TextureAtlas.AtlasRegion) this.regions.get(index);
        if (String.instancehelper_equals(atlasRegion.name, (object) name))
        {
          int[] splits = atlasRegion.splits;
          if (splits == null)
          {
            string str = new StringBuilder().append("Region does not have ninepatch splits: ").append(name).toString();
            Throwable.__\u003CsuppressFillInStackTrace\u003E();
            throw new IllegalArgumentException(str);
          }
          NinePatch.__\u003Cclinit\u003E();
          NinePatch ninePatch = new NinePatch((TextureRegion) atlasRegion, splits[0], splits[1], splits[2], splits[3]);
          if (atlasRegion.pads != null)
            ninePatch.setPadding((float) atlasRegion.pads[0], (float) atlasRegion.pads[1], (float) atlasRegion.pads[2], (float) atlasRegion.pads[3]);
          return ninePatch;
        }
      }
      return (NinePatch) null;
    }

    [LineNumberTable(328)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Texture texture() => (Texture) this.textures.first();

    [LineNumberTable(new byte[] {160, 222, 127, 1, 104, 127, 6, 104, 38, 130, 107, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void dispose()
    {
      ObjectSet.ObjectSetIterator objectSetIterator = this.textures.iterator();
      while (((Iterator) objectSetIterator).hasNext())
        ((Texture) ((Iterator) objectSetIterator).next()).dispose();
      ObjectMap.Values values = this.pixmaps.values().iterator();
      while (((Iterator) values).hasNext())
      {
        Pixmap pixmap = (Pixmap) ((Iterator) values).next();
        if (!pixmap.isDisposed())
          pixmap.dispose();
      }
      this.textures.clear();
      this.pixmaps.clear();
    }

    [LineNumberTable(new byte[] {159, 136, 173, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static TextureAtlas()
    {
      if (ByteCodeHelper.isAlreadyInited("arc.graphics.g2d.TextureAtlas"))
        return;
      TextureAtlas.tuple = new string[4];
      TextureAtlas.indexComparator = (Comparator) new TextureAtlas.__\u003C\u003EAnon1();
    }

    [HideFromJava]
    public virtual bool isDisposed() => Disposable.\u003Cdefault\u003EisDisposed((Disposable) this);

    public class AtlasRegion : TextureRegion
    {
      internal PixmapRegion pixmapRegion;
      public int index;
      public string name;
      public float offsetX;
      public float offsetY;
      public int packedWidth;
      public int packedHeight;
      public int originalWidth;
      public int originalHeight;
      public bool rotate;
      public int[] splits;
      public int[] pads;

      [LineNumberTable(new byte[] {161, 174, 111, 104, 104, 104, 104})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public AtlasRegion(Texture texture, int x, int y, int width, int height)
        : base(texture, x, y, width, height)
      {
        TextureAtlas.AtlasRegion atlasRegion = this;
        this.originalWidth = width;
        this.originalHeight = height;
        this.packedWidth = width;
        this.packedHeight = height;
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual float getRotatedPackedWidth() => this.rotate ? (float) this.packedHeight : (float) this.packedWidth;

      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual float getRotatedPackedHeight() => this.rotate ? (float) this.packedWidth : (float) this.packedHeight;

      [LineNumberTable(new byte[] {161, 181, 134})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public AtlasRegion()
      {
      }

      [LineNumberTable(new byte[] {161, 185, 104, 103, 108, 108, 108, 108, 108, 108, 108, 108, 108, 108})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public AtlasRegion(TextureAtlas.AtlasRegion region)
      {
        TextureAtlas.AtlasRegion atlasRegion = this;
        this.set((TextureRegion) region);
        this.index = region.index;
        this.name = region.name;
        this.offsetX = region.offsetX;
        this.offsetY = region.offsetY;
        this.packedWidth = region.packedWidth;
        this.packedHeight = region.packedHeight;
        this.originalWidth = region.originalWidth;
        this.originalHeight = region.originalHeight;
        this.rotate = region.rotate;
        this.splits = region.splits;
      }

      [LineNumberTable(new byte[] {161, 199, 104, 103, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public AtlasRegion(TextureRegion region)
      {
        TextureAtlas.AtlasRegion atlasRegion = this;
        this.set(region);
        this.name = "unknown";
      }

      [LineNumberTable(new byte[] {158, 254, 100, 104, 127, 2, 127, 2})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void flip(bool x, bool y)
      {
        int num1 = x ? 1 : 0;
        int num2 = y ? 1 : 0;
        base.flip(num1 != 0, num2 != 0);
        if (num1 != 0)
          this.offsetX = (float) this.originalWidth - this.offsetX - this.getRotatedPackedWidth();
        if (num2 == 0)
          return;
        this.offsetY = (float) this.originalHeight - this.offsetY - this.getRotatedPackedHeight();
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      public override string toString() => this.name;
    }

    public class TextureAtlasData : Object
    {
      [Modifiers]
      [Signature("Larc/struct/Seq<Larc/graphics/g2d/TextureAtlas$TextureAtlasData$AtlasPage;>;")]
      internal Seq pages;
      [Modifiers]
      [Signature("Larc/struct/Seq<Larc/graphics/g2d/TextureAtlas$TextureAtlasData$Region;>;")]
      internal Seq regions;

      [Signature("()Larc/struct/Seq<Larc/graphics/g2d/TextureAtlas$TextureAtlasData$AtlasPage;>;")]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual Seq getPages() => this.pages;

      [LineNumberTable(new byte[] {159, 55, 98, 232, 61, 107, 171, 147, 130, 104, 105, 110, 103, 102, 138, 110, 105, 111, 111, 135, 142, 103, 110, 142, 104, 103, 103, 110, 105, 110, 105, 110, 103, 167, 125, 108, 101, 146, 103, 110, 142, 103, 110, 142, 103, 104, 105, 105, 105, 105, 105, 137, 108, 127, 16, 154, 105, 127, 16, 154, 199, 115, 147, 103, 116, 148, 146, 139, 141, 214, 102, 39, 102, 230, 60, 98, 159, 8, 102, 129, 113})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public TextureAtlasData(Fi packFile, Fi imagesDir, bool flip)
      {
        int num1 = flip ? 1 : 0;
        // ISSUE: explicit constructor call
        base.\u002Ector();
        TextureAtlas.TextureAtlasData textureAtlasData = this;
        this.pages = new Seq();
        this.regions = new Seq();
        BufferedReader bufferedReader = new BufferedReader((Reader) new InputStreamReader(packFile.read()), 64);
        Exception exception1;
        // ISSUE: fault handler
        try
        {
          TextureAtlas.TextureAtlasData.AtlasPage atlasPage = (TextureAtlas.TextureAtlasData.AtlasPage) null;
          while (true)
          {
            string name = bufferedReader.readLine();
            if (name != null)
            {
              if (String.instancehelper_length(String.instancehelper_trim(name)) == 0)
                atlasPage = (TextureAtlas.TextureAtlasData.AtlasPage) null;
              else if (atlasPage == null)
              {
                Fi handle = imagesDir.child(name);
                float width = 0.0f;
                float height = 0.0f;
                if (TextureAtlas.readTuple(bufferedReader) == 2)
                {
                  width = (float) Integer.parseInt(TextureAtlas.tuple[0]);
                  height = (float) Integer.parseInt(TextureAtlas.tuple[1]);
                  TextureAtlas.readTuple(bufferedReader);
                }
                Pixmap.Format format = Pixmap.Format.valueOf(TextureAtlas.tuple[0]);
                TextureAtlas.readTuple(bufferedReader);
                Texture.TextureFilter minFilter = Texture.TextureFilter.valueOf(TextureAtlas.tuple[0]);
                Texture.TextureFilter magFilter = Texture.TextureFilter.valueOf(TextureAtlas.tuple[1]);
                string str = TextureAtlas.readValue(bufferedReader);
                Texture.TextureWrap uWrap = Texture.TextureWrap.__\u003C\u003EclampToEdge;
                Texture.TextureWrap vWrap = Texture.TextureWrap.__\u003C\u003EclampToEdge;
                if (String.instancehelper_equals(str, (object) "x"))
                  uWrap = Texture.TextureWrap.__\u003C\u003Erepeat;
                else if (String.instancehelper_equals(str, (object) "y"))
                  vWrap = Texture.TextureWrap.__\u003C\u003Erepeat;
                else if (String.instancehelper_equals(str, (object) "xy"))
                {
                  uWrap = Texture.TextureWrap.__\u003C\u003Erepeat;
                  vWrap = Texture.TextureWrap.__\u003C\u003Erepeat;
                }
                atlasPage = new TextureAtlas.TextureAtlasData.AtlasPage(handle, width, height, minFilter.isMipMap(), format, minFilter, magFilter, uWrap, vWrap);
                this.pages.add((object) atlasPage);
              }
              else
              {
                int num2 = Boolean.valueOf(TextureAtlas.readValue(bufferedReader)).booleanValue() ? 1 : 0;
                TextureAtlas.readTuple(bufferedReader);
                int num3 = Integer.parseInt(TextureAtlas.tuple[0]);
                int num4 = Integer.parseInt(TextureAtlas.tuple[1]);
                TextureAtlas.readTuple(bufferedReader);
                int num5 = Integer.parseInt(TextureAtlas.tuple[0]);
                int num6 = Integer.parseInt(TextureAtlas.tuple[1]);
                TextureAtlas.TextureAtlasData.Region region = new TextureAtlas.TextureAtlasData.Region();
                region.page = atlasPage;
                region.left = num3;
                region.top = num4;
                region.width = num5;
                region.height = num6;
                region.name = name;
                region.rotate = num2 != 0;
                if (TextureAtlas.readTuple(bufferedReader) == 4)
                {
                  region.splits = new int[4]
                  {
                    Integer.parseInt(TextureAtlas.tuple[0]),
                    Integer.parseInt(TextureAtlas.tuple[1]),
                    Integer.parseInt(TextureAtlas.tuple[2]),
                    Integer.parseInt(TextureAtlas.tuple[3])
                  };
                  if (TextureAtlas.readTuple(bufferedReader) == 4)
                  {
                    region.pads = new int[4]
                    {
                      Integer.parseInt(TextureAtlas.tuple[0]),
                      Integer.parseInt(TextureAtlas.tuple[1]),
                      Integer.parseInt(TextureAtlas.tuple[2]),
                      Integer.parseInt(TextureAtlas.tuple[3])
                    };
                    TextureAtlas.readTuple(bufferedReader);
                  }
                }
                region.originalWidth = Integer.parseInt(TextureAtlas.tuple[0]);
                region.originalHeight = Integer.parseInt(TextureAtlas.tuple[1]);
                TextureAtlas.readTuple(bufferedReader);
                region.offsetX = (float) Integer.parseInt(TextureAtlas.tuple[0]);
                region.offsetY = (float) Integer.parseInt(TextureAtlas.tuple[1]);
                region.index = Integer.parseInt(TextureAtlas.readValue(bufferedReader));
                if (num1 != 0)
                  region.flip = true;
                this.regions.add((object) region);
              }
            }
            else
              goto label_26;
          }
        }
        catch (Exception ex)
        {
          M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
          if (m0 == null)
            throw;
          else
            exception1 = (Exception) m0;
        }
        __fault
        {
          Streams.close((Closeable) bufferedReader);
        }
        Exception exception2 = exception1;
        // ISSUE: fault handler
        try
        {
          Exception exception3 = exception2;
          string message = new StringBuilder().append("Error reading pack file: ").append((object) packFile).toString();
          Exception exception4 = exception3;
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new ArcRuntimeException(message, (Exception) exception4);
        }
        __fault
        {
          Streams.close((Closeable) bufferedReader);
        }
label_26:
        Streams.close((Closeable) bufferedReader);
        this.regions.sort(TextureAtlas.indexComparator);
      }

      [Signature("()Larc/struct/Seq<Larc/graphics/g2d/TextureAtlas$TextureAtlasData$Region;>;")]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual Seq getRegions() => this.regions;

      public class AtlasPage : Object
      {
        internal Fi __\u003C\u003EtextureFile;
        internal float __\u003C\u003Ewidth;
        internal float __\u003C\u003Eheight;
        internal bool __\u003C\u003EuseMipMaps;
        internal Pixmap.Format __\u003C\u003Eformat;
        internal Texture.TextureFilter __\u003C\u003EminFilter;
        internal Texture.TextureFilter __\u003C\u003EmagFilter;
        internal Texture.TextureWrap __\u003C\u003EuWrap;
        internal Texture.TextureWrap __\u003C\u003EvWrap;
        public Texture texture;

        [LineNumberTable(new byte[] {159, 27, 131, 104, 104, 104, 103, 103, 104, 104, 104, 104, 104})]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public AtlasPage(
          Fi handle,
          float width,
          float height,
          bool useMipMaps,
          Pixmap.Format format,
          Texture.TextureFilter minFilter,
          Texture.TextureFilter magFilter,
          Texture.TextureWrap uWrap,
          Texture.TextureWrap vWrap)
        {
          int num = useMipMaps ? 1 : 0;
          // ISSUE: explicit constructor call
          base.\u002Ector();
          TextureAtlas.TextureAtlasData.AtlasPage atlasPage = this;
          this.__\u003C\u003Ewidth = width;
          this.__\u003C\u003Eheight = height;
          this.__\u003C\u003EtextureFile = handle;
          this.__\u003C\u003EuseMipMaps = num != 0;
          this.__\u003C\u003Eformat = format;
          this.__\u003C\u003EminFilter = minFilter;
          this.__\u003C\u003EmagFilter = magFilter;
          this.__\u003C\u003EuWrap = uWrap;
          this.__\u003C\u003EvWrap = vWrap;
        }

        [Modifiers]
        public Fi textureFile
        {
          [HideFromJava] get => this.__\u003C\u003EtextureFile;
          [HideFromJava] [param: In] private set => this.__\u003C\u003EtextureFile = value;
        }

        [Modifiers]
        public float width
        {
          [HideFromJava] get => this.__\u003C\u003Ewidth;
          [HideFromJava] [param: In] private set => this.__\u003C\u003Ewidth = value;
        }

        [Modifiers]
        public float height
        {
          [HideFromJava] get => this.__\u003C\u003Eheight;
          [HideFromJava] [param: In] private set => this.__\u003C\u003Eheight = value;
        }

        [Modifiers]
        public bool useMipMaps
        {
          [HideFromJava] get => this.__\u003C\u003EuseMipMaps;
          [HideFromJava] [param: In] private set => this.__\u003C\u003EuseMipMaps = value;
        }

        [Modifiers]
        public Pixmap.Format format
        {
          [HideFromJava] get => this.__\u003C\u003Eformat;
          [HideFromJava] [param: In] private set => this.__\u003C\u003Eformat = value;
        }

        [Modifiers]
        public Texture.TextureFilter minFilter
        {
          [HideFromJava] get => this.__\u003C\u003EminFilter;
          [HideFromJava] [param: In] private set => this.__\u003C\u003EminFilter = value;
        }

        [Modifiers]
        public Texture.TextureFilter magFilter
        {
          [HideFromJava] get => this.__\u003C\u003EmagFilter;
          [HideFromJava] [param: In] private set => this.__\u003C\u003EmagFilter = value;
        }

        [Modifiers]
        public Texture.TextureWrap uWrap
        {
          [HideFromJava] get => this.__\u003C\u003EuWrap;
          [HideFromJava] [param: In] private set => this.__\u003C\u003EuWrap = value;
        }

        [Modifiers]
        public Texture.TextureWrap vWrap
        {
          [HideFromJava] get => this.__\u003C\u003EvWrap;
          [HideFromJava] [param: In] private set => this.__\u003C\u003EvWrap = value;
        }
      }

      public class Region : Object
      {
        public TextureAtlas.TextureAtlasData.AtlasPage page;
        public int index;
        public string name;
        public float offsetX;
        public float offsetY;
        public int originalWidth;
        public int originalHeight;
        public bool rotate;
        public int left;
        public int top;
        public int width;
        public int height;
        public bool flip;
        public int[] splits;
        public int[] pads;

        [LineNumberTable(475)]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public Region()
        {
        }
      }
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Prov
    {
      private readonly TextureAtlas.AtlasRegion arg\u00241;

      internal __\u003C\u003EAnon0([In] TextureAtlas.AtlasRegion obj0) => this.arg\u00241 = obj0;

      public object get() => (object) TextureAtlas.lambda\u0024getPixmap\u00241(this.arg\u00241);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Comparator
    {
      internal __\u003C\u003EAnon1()
      {
      }

      public int compare([In] object obj0, [In] object obj1) => TextureAtlas.lambda\u0024static\u00240((TextureAtlas.TextureAtlasData.Region) obj0, (TextureAtlas.TextureAtlasData.Region) obj1);

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
