// Decompiled with JetBrains decompiler
// Type: arc.freetype.FreeTypeFontGenerator
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.files;
using arc.graphics;
using arc.graphics.g2d;
using arc.math;
using arc.math.geom;
using arc.util;
using arc.util.io;
using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.io;
using java.lang;
using java.nio;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.freetype
{
  public class FreeTypeFontGenerator : Object, Disposable
  {
    public const string DEFAULT_CHARS = "\0ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890\"!`?'.,;:()[]{}<>|/@\\^$€-%+=#_&~*\u007F\u0080\u0081\u0082\u0083\u0084\u0085\u0086\u0087\u0088\u0089\u008A\u008B\u008C\u008D\u008E\u008F\u0090\u0091\u0092\u0093\u0094\u0095\u0096\u0097\u0098\u0099\u009A\u009B\u009C\u009D\u009E\u009F ¡¢£¤¥¦§¨©ª«¬\u00AD®¯°±\u00B2\u00B3´µ¶·¸\u00B9º»\u00BC\u00BD\u00BE¿ÀÁÂÃÄÅÆÇÈÉÊËÌÍÎÏÐÑÒÓÔÕÖ×ØÙÚÛÜÝÞßàáâãäåæçèéêëìíîïðñòóôõö÷øùúûüýþÿ";
    public const int NO_MAXIMUM = -1;
    private static int maxTextureSize;
    [Modifiers]
    internal FreeType.Library library;
    [Modifiers]
    internal FreeType.Face face;
    [Modifiers]
    internal string name;
    internal bool bitmapped;

    [LineNumberTable(195)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Font generateFont(
      FreeTypeFontGenerator.FreeTypeFontParameter parameter)
    {
      return this.generateFont(parameter, new FreeTypeFontGenerator.FreeTypeFontData());
    }

    [LineNumberTable(new byte[] {28, 232, 52, 231, 77, 108, 136, 139, 162, 178, 2, 193, 102, 135, 131, 109, 105, 108, 130, 103, 245, 69, 102, 39, 102, 230, 60, 98, 141, 102, 161, 115, 159, 14, 105, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public FreeTypeFontGenerator(Fi fontFile, int faceIndex)
    {
      FreeTypeFontGenerator typeFontGenerator = this;
      this.bitmapped = false;
      this.name = fontFile.pathWithoutExtension();
      int numBytes = (int) fontFile.length();
      this.library = FreeType.initFreeType();
      ByteBuffer byteBuffer = (ByteBuffer) null;
      try
      {
        byteBuffer = fontFile.map();
        goto label_4;
      }
      catch (ArcRuntimeException ex)
      {
      }
label_4:
      if (byteBuffer == null)
      {
        InputStream input = fontFile.read();
        IOException ioException1;
        // ISSUE: fault handler
        try
        {
          if (numBytes == 0)
          {
            byte[] src = Streams.copyBytes(input, 16384);
            byteBuffer = Buffers.newUnsafeByteBuffer(src.Length);
            Buffers.copy(src, 0, (Buffer) byteBuffer, src.Length);
            goto label_13;
          }
          else
          {
            byteBuffer = Buffers.newUnsafeByteBuffer(numBytes);
            Streams.copy(input, byteBuffer);
            goto label_13;
          }
        }
        catch (IOException ex)
        {
          ioException1 = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
        }
        __fault
        {
          Streams.close((Closeable) input);
        }
        IOException ioException2 = ioException1;
        // ISSUE: fault handler
        try
        {
          IOException ioException3 = ioException2;
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new ArcRuntimeException((Exception) ioException3);
        }
        __fault
        {
          Streams.close((Closeable) input);
        }
label_13:
        Streams.close((Closeable) input);
      }
      this.face = this.library.newMemoryFace(byteBuffer, faceIndex);
      if (this.face == null)
      {
        string message = new StringBuilder().append("Couldn't create face for font: ").append((object) fontFile).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new ArcRuntimeException(message);
      }
      if (this.checkForBitmapFont())
        return;
      this.setPixelSizes(0, 15);
    }

    [LineNumberTable(new byte[] {160, 67, 108, 156, 106, 108, 109, 199})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool checkForBitmapFont()
    {
      int faceFlags = this.face.getFaceFlags();
      if ((faceFlags & FreeType.FT_FACE_FLAG_FIXED_SIZES) == FreeType.FT_FACE_FLAG_FIXED_SIZES && (faceFlags & FreeType.FT_FACE_FLAG_HORIZONTAL) == FreeType.FT_FACE_FLAG_HORIZONTAL && (this.loadChar(32) && this.face.getGlyph().getFormat() == 1651078259))
        this.bitmapped = true;
      return this.bitmapped;
    }

    [LineNumberTable(new byte[] {160, 212, 119, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void setPixelSizes([In] int obj0, [In] int obj1)
    {
      if (!this.bitmapped && !this.face.setPixelSizes(obj0, obj1))
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new ArcRuntimeException("Couldn't set size for font");
      }
    }

    [LineNumberTable(177)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool loadChar([In] int obj0, [In] int obj1) => this.face.loadChar(obj0, obj1);

    [LineNumberTable(173)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool loadChar([In] int obj0) => this.loadChar(obj0, FreeType.FT_LOAD_DEFAULT | FreeType.FT_LOAD_FORCE_AUTOHINT);

    [LineNumberTable(new byte[] {160, 90, 117, 110, 105, 99, 127, 4, 125, 110, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Font generateFont(
      FreeTypeFontGenerator.FreeTypeFontParameter parameter,
      FreeTypeFontGenerator.FreeTypeFontData data)
    {
      int num = data.regions != null || parameter.packer == null ? 0 : 1;
      if (num != 0)
        data.regions = new Seq();
      this.generateData(parameter, data);
      if (num != 0)
        parameter.packer.updateTextureRegions(data.regions, parameter.minFilter, parameter.magFilter, parameter.genMipMaps);
      if (data.regions.isEmpty())
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new ArcRuntimeException("Unable to create a font with no texture regions.");
      }
      Font font = new Font((Font.FontData) data, data.regions, true);
      font.setOwnsTexture(parameter.packer == null);
      return font;
    }

    [LineNumberTable(new byte[] {160, 221, 109, 108, 99, 103, 136, 173, 114, 108, 115, 115, 115, 168, 123, 118, 107, 124, 252, 61, 232, 71, 181, 118, 159, 4, 210, 125, 109, 127, 2, 239, 61, 232, 69, 189, 125, 109, 127, 14, 226, 61, 232, 69, 159, 6, 116, 109, 104, 109, 173, 131, 136, 199, 99, 103, 137, 116, 122, 118, 135, 99, 127, 8, 109, 113, 109, 109, 209, 146, 99, 109, 109, 116, 116, 21, 229, 70, 104, 107, 134, 127, 11, 135, 100, 113, 118, 105, 104, 240, 53, 235, 79, 101, 104, 105, 105, 103, 102, 100, 228, 60, 232, 72, 102, 106, 114, 100, 106, 208, 102, 106, 102, 104, 102, 133, 142, 99, 103, 103, 104, 200, 120, 107, 107, 102, 106, 105, 111, 108, 102, 106, 105, 143, 114, 148, 114, 244, 54, 235, 59, 235, 85, 100, 107, 223, 0, 106, 100, 103, 121, 105, 138, 159, 6})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual FreeTypeFontGenerator.FreeTypeFontData generateData(
      FreeTypeFontGenerator.FreeTypeFontParameter parameter,
      FreeTypeFontGenerator.FreeTypeFontData data)
    {
      parameter = parameter != null ? parameter : new FreeTypeFontGenerator.FreeTypeFontParameter();
      char[] charArray = String.instancehelper_toCharArray(parameter.characters);
      int length1 = charArray.Length;
      int num1 = parameter.incremental ? 1 : 0;
      int loadingFlags = this.getLoadingFlags(parameter);
      this.setPixelSizes(0, parameter.size);
      FreeType.SizeMetrics metrics = this.face.getSize().getMetrics();
      data.flipped = parameter.flip;
      data.ascent = (float) FreeType.toInt(metrics.getAscender());
      data.descent = (float) FreeType.toInt(metrics.getDescender());
      data.lineHeight = (float) FreeType.toInt(metrics.getHeight());
      float ascent = data.ascent;
      if (this.bitmapped && (double) data.lineHeight == 0.0)
      {
        for (int index = 32; index < 32 + this.face.getNumGlyphs(); ++index)
        {
          if (this.loadChar(index, loadingFlags))
          {
            int num2 = FreeType.toInt(this.face.getGlyph().getMetrics().getHeight());
            data.lineHeight = (double) num2 <= (double) data.lineHeight ? data.lineHeight : (float) num2;
          }
        }
      }
      data.lineHeight += (float) parameter.spaceY;
      if (this.loadChar(32, loadingFlags) || this.loadChar(108, loadingFlags))
        data.spaceXadvance = (float) FreeType.toInt(this.face.getGlyph().getMetrics().getHoriAdvance());
      else
        data.spaceXadvance = (float) this.face.getMaxAdvanceWidth();
      char[] xChars = data.xChars;
      int length2 = xChars.Length;
      for (int index = 0; index < length2; ++index)
      {
        if (this.loadChar((int) xChars[index], loadingFlags))
        {
          data.xHeight = (float) FreeType.toInt(this.face.getGlyph().getMetrics().getHeight());
          if ((double) data.xHeight > 0.0)
            break;
        }
      }
      if ((double) data.xHeight == 0.0)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new ArcRuntimeException("No x-height character found in font");
      }
      char[] capChars = data.capChars;
      int length3 = capChars.Length;
      for (int index = 0; index < length3; ++index)
      {
        if (this.loadChar((int) capChars[index], loadingFlags))
        {
          data.capHeight = (float) (FreeType.toInt(this.face.getGlyph().getMetrics().getHeight()) + Math.abs(parameter.shadowOffsetY));
          break;
        }
      }
      if (!this.bitmapped && (double) data.capHeight == 1.0)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new ArcRuntimeException("No cap character found in font");
      }
      data.ascent -= data.capHeight;
      data.down = -data.lineHeight;
      if (parameter.flip)
      {
        data.ascent = -data.ascent;
        data.down = -data.down;
      }
      int num3 = 0;
      PixmapPacker pixmapPacker = parameter.packer;
      if (pixmapPacker == null)
      {
        int num2;
        object obj1;
        if (num1 != 0)
        {
          num2 = FreeTypeFontGenerator.maxTextureSize;
          obj1 = (object) new PixmapPacker.GuillotineStrategy();
        }
        else
        {
          int num4 = ByteCodeHelper.d2i(Math.ceil((double) data.lineHeight));
          num2 = Mathf.nextPowerOfTwo(ByteCodeHelper.d2i(Math.sqrt((double) (num4 * num4 * length1))));
          if (FreeTypeFontGenerator.maxTextureSize > 0)
            num2 = Math.min(num2, FreeTypeFontGenerator.maxTextureSize);
          obj1 = (object) new PixmapPacker.SkylineStrategy();
        }
        num3 = 1;
        int pageWidth = num2;
        int pageHeight = num2;
        Pixmap.Format rgba8888 = Pixmap.Format.__\u003C\u003Ergba8888;
        object obj2 = obj1;
        PixmapPacker.PackStrategy packStrategy1;
        if (obj2 != null)
          packStrategy1 = obj2 is PixmapPacker.PackStrategy packStrategy5 ? packStrategy5 : throw new IncompatibleClassChangeError();
        else
          packStrategy1 = (PixmapPacker.PackStrategy) null;
        pixmapPacker = new PixmapPacker(pageWidth, pageHeight, rgba8888, 1, false, packStrategy1);
        pixmapPacker.setTransparentColor(parameter.color);
        pixmapPacker.getTransparentColor().a = 0.0f;
        if ((double) parameter.borderWidth > 0.0)
        {
          pixmapPacker.setTransparentColor(parameter.borderColor);
          pixmapPacker.getTransparentColor().a = 0.0f;
        }
      }
      if (num1 != 0)
        data.glyphs = new Seq(length1 + 32);
      FreeType.Stroker stroker = (FreeType.Stroker) null;
      if ((double) parameter.borderWidth > 0.0)
      {
        stroker = this.library.createStroker();
        stroker.set(ByteCodeHelper.f2i(parameter.borderWidth * 64f), !parameter.borderStraight ? FreeType.FT_STROKER_LINECAP_ROUND : FreeType.FT_STROKER_LINECAP_BUTT, !parameter.borderStraight ? FreeType.FT_STROKER_LINEJOIN_ROUND : FreeType.FT_STROKER_LINEJOIN_MITER_FIXED, 0);
      }
      int[] numArray = new int[length1];
      for (int index = 0; index < length1; ++index)
      {
        int num2 = (int) charArray[index];
        int num4 = !this.loadChar(num2, loadingFlags) ? 0 : FreeType.toInt(this.face.getGlyph().getMetrics().getHeight());
        numArray[index] = num4;
        if (num2 == 0)
        {
          Font.Glyph glyph = this.createGlyph(char.MinValue, data, parameter, stroker, ascent, pixmapPacker);
          if (glyph != null && glyph.width != 0 && glyph.height != 0)
          {
            data.setGlyph(0, glyph);
            data.missingGlyph = glyph;
            if (num1 != 0)
              data.glyphs.add((object) glyph);
          }
        }
      }
      int length4 = numArray.Length;
      while (length4 > 0)
      {
        int index1 = 0;
        int num2 = numArray[0];
        for (int index2 = 1; index2 < length4; ++index2)
        {
          int num4 = numArray[index2];
          if (num4 > num2)
          {
            num2 = num4;
            index1 = index2;
          }
        }
        int ch = (int) charArray[index1];
        if (data.getGlyph((char) ch) == null)
        {
          Font.Glyph glyph = this.createGlyph((char) ch, data, parameter, stroker, ascent, pixmapPacker);
          if (glyph != null)
          {
            data.setGlyph(ch, glyph);
            if (num1 != 0)
              data.glyphs.add((object) glyph);
          }
        }
        length4 += -1;
        numArray[index1] = numArray[length4];
        int num5 = (int) charArray[index1];
        charArray[index1] = charArray[length4];
        charArray[length4] = (char) num5;
      }
      if (stroker != null && num1 == 0)
        stroker.dispose();
      if (num1 != 0)
      {
        data.generator = this;
        data.parameter = parameter;
        data.stroker = stroker;
        data.packer = pixmapPacker;
      }
      parameter.kerning &= this.face.hasKerning();
      if (parameter.kerning)
      {
        for (int index1 = 0; index1 < length1; ++index1)
        {
          int num2 = (int) charArray[index1];
          Font.Glyph glyph1 = data.getGlyph((char) num2);
          if (glyph1 != null)
          {
            int charIndex1 = this.face.getCharIndex(num2);
            for (int index2 = index1; index2 < length1; ++index2)
            {
              int num4 = (int) charArray[index2];
              Font.Glyph glyph2 = data.getGlyph((char) num4);
              if (glyph2 != null)
              {
                int charIndex2 = this.face.getCharIndex(num4);
                int kerning1 = this.face.getKerning(charIndex1, charIndex2, 0);
                if (kerning1 != 0)
                  glyph1.setKerning(num4, FreeType.toInt(kerning1));
                int kerning2 = this.face.getKerning(charIndex2, charIndex1, 0);
                if (kerning2 != 0)
                  glyph2.setKerning(num2, FreeType.toInt(kerning2));
              }
            }
          }
        }
      }
      if (num3 != 0)
      {
        data.regions = new Seq();
        pixmapPacker.updateTextureRegions(data.regions, parameter.minFilter, parameter.magFilter, parameter.genMipMaps);
      }
      Font.Glyph glyph3 = data.getGlyph(' ');
      if (glyph3 == null)
      {
        glyph3 = new Font.Glyph();
        glyph3.xadvance = ByteCodeHelper.f2i(data.spaceXadvance) + parameter.spaceX;
        glyph3.id = 32;
        data.setGlyph(32, glyph3);
      }
      if (glyph3.width == 0)
        glyph3.width = ByteCodeHelper.f2i((float) glyph3.xadvance + data.padRight);
      return data;
    }

    [LineNumberTable(new byte[] {160, 106, 104, 113, 108, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int scaleForPixelHeight(int height)
    {
      this.setPixelSizes(0, height);
      FreeType.SizeMetrics metrics = this.face.getSize().getMetrics();
      int num1 = FreeType.toInt(metrics.getAscender());
      int num2 = FreeType.toInt(metrics.getDescender());
      int num3 = height * height;
      int num4 = num1 - num2;
      return num4 == -1 ? -num3 : num3 / num4;
    }

    [LineNumberTable(new byte[] {160, 120, 113, 108, 108, 108, 101, 114, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int scaleForPixelWidth(int width, int numChars)
    {
      FreeType.SizeMetrics metrics = this.face.getSize().getMetrics();
      int num1 = FreeType.toInt(metrics.getMaxAdvance());
      int num2 = (FreeType.toInt(metrics.getAscender()) - FreeType.toInt(metrics.getDescender())) * width;
      int num3 = num1 * numChars;
      int num4 = num3 != -1 ? num2 / num3 : -num2;
      this.setPixelSizes(0, num4);
      return num4;
    }

    [LineNumberTable(322)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual FreeTypeFontGenerator.FreeTypeFontData generateData(
      FreeTypeFontGenerator.FreeTypeFontParameter parameter)
    {
      return this.generateData(parameter, new FreeTypeFontGenerator.FreeTypeFontData());
    }

    [LineNumberTable(new byte[] {95, 102, 159, 26, 104, 133, 104, 130, 104, 130, 104, 130, 110, 130, 110, 130, 174})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private int getLoadingFlags([In] FreeTypeFontGenerator.FreeTypeFontParameter obj0)
    {
      int ftLoadDefault = FreeType.FT_LOAD_DEFAULT;
      switch (FreeTypeFontGenerator.\u0031.\u0024SwitchMap\u0024arc\u0024freetype\u0024FreeTypeFontGenerator\u0024Hinting[obj0.hinting.ordinal()])
      {
        case 1:
          ftLoadDefault |= FreeType.FT_LOAD_NO_HINTING;
          break;
        case 2:
          ftLoadDefault |= FreeType.FT_LOAD_TARGET_LIGHT;
          break;
        case 3:
          ftLoadDefault |= FreeType.FT_LOAD_TARGET_NORMAL;
          break;
        case 4:
          ftLoadDefault |= FreeType.FT_LOAD_TARGET_MONO;
          break;
        case 5:
          ftLoadDefault |= FreeType.FT_LOAD_FORCE_AUTOHINT | FreeType.FT_LOAD_TARGET_LIGHT;
          break;
        case 6:
          ftLoadDefault |= FreeType.FT_LOAD_FORCE_AUTOHINT | FreeType.FT_LOAD_TARGET_NORMAL;
          break;
        case 7:
          ftLoadDefault |= FreeType.FT_LOAD_FORCE_AUTOHINT | FreeType.FT_LOAD_TARGET_MONO;
          break;
      }
      return ftLoadDefault;
    }

    [LineNumberTable(new byte[] {159, 10, 66, 118, 133, 146, 108, 135, 255, 6, 69, 226, 60, 97, 102, 127, 5, 130, 104, 154, 120, 100, 144, 112, 104, 106, 123, 108, 173, 105, 186, 113, 45, 168, 103, 102, 100, 163, 115, 114, 124, 127, 1, 146, 104, 105, 108, 127, 35, 105, 105, 108, 109, 108, 108, 110, 102, 105, 108, 110, 110, 255, 0, 56, 11, 235, 80, 113, 63, 4, 136, 103, 100, 143, 115, 43, 200, 127, 5, 119, 127, 2, 117, 103, 196, 104, 103, 104, 110, 110, 109, 104, 153, 127, 0, 159, 7, 107, 108, 103, 105, 108, 108, 113, 108, 118, 127, 7, 22, 11, 235, 73, 107, 117, 115, 179, 127, 5, 159, 0, 103, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual Font.Glyph createGlyph(
      [In] char obj0,
      [In] FreeTypeFontGenerator.FreeTypeFontData obj1,
      [In] FreeTypeFontGenerator.FreeTypeFontParameter obj2,
      [In] FreeType.Stroker obj3,
      [In] float obj4,
      [In] PixmapPacker obj5)
    {
      int charCode = (int) obj0;
      if ((this.face.getCharIndex(charCode) != 0 || charCode == 0 ? 0 : 1) != 0)
        return (Font.Glyph) null;
      if (!this.loadChar(charCode, this.getLoadingFlags(obj2)))
        return (Font.Glyph) null;
      FreeType.GlyphSlot glyph1 = this.face.getGlyph();
      FreeType.Glyph glyph2 = glyph1.getGlyph();
      try
      {
        glyph2.toBitmap(!obj2.mono ? FreeType.FT_RENDER_MODE_NORMAL : FreeType.FT_RENDER_MODE_MONO);
        goto label_8;
      }
      catch (ArcRuntimeException ex)
      {
      }
      glyph2.dispose();
      Log.infoTag(nameof (FreeTypeFontGenerator), new StringBuilder().append("Couldn't render char: ").append((char) charCode).toString());
      return (Font.Glyph) null;
label_8:
      FreeType.Bitmap bitmap = glyph2.getBitmap();
      Pixmap pixmap1 = bitmap.getPixmap(Pixmap.Format.__\u003C\u003Ergba8888, obj2.color, obj2.gamma);
      if (bitmap.getWidth() != 0 && bitmap.getRows() != 0)
      {
        if ((double) obj2.borderWidth > 0.0)
        {
          int top = glyph2.getTop();
          int left = glyph2.getLeft();
          FreeType.Glyph glyph3 = glyph1.getGlyph();
          glyph3.strokeBorder(obj3, false);
          glyph3.toBitmap(!obj2.mono ? FreeType.FT_RENDER_MODE_NORMAL : FreeType.FT_RENDER_MODE_MONO);
          int x = left - glyph3.getLeft();
          int y = -(top - glyph3.getTop());
          Pixmap pixmap2 = glyph3.getBitmap().getPixmap(Pixmap.Format.__\u003C\u003Ergba8888, obj2.borderColor, obj2.borderGamma);
          int num = 0;
          for (int renderCount = obj2.renderCount; num < renderCount; ++num)
            pixmap2.drawPixmap(pixmap1, x, y);
          pixmap1.dispose();
          glyph2.dispose();
          pixmap1 = pixmap2;
          glyph2 = glyph3;
        }
        if (obj2.shadowOffsetX != 0 || obj2.shadowOffsetY != 0)
        {
          int width1 = pixmap1.getWidth();
          int height1 = pixmap1.getHeight();
          int num1 = Math.max(obj2.shadowOffsetX, 0);
          int num2 = Math.max(obj2.shadowOffsetY, 0);
          int width2 = width1 + Math.abs(obj2.shadowOffsetX);
          int height2 = height1 + Math.abs(obj2.shadowOffsetY);
          Pixmap pixmap2 = new Pixmap(width2, height2, pixmap1.getFormat());
          Color shadowColor = obj2.shadowColor;
          float a = shadowColor.a;
          if ((double) a != 0.0)
          {
            int num3 = (int) (sbyte) ByteCodeHelper.f2i(shadowColor.r * (float) byte.MaxValue);
            int num4 = (int) (sbyte) ByteCodeHelper.f2i(shadowColor.g * (float) byte.MaxValue);
            int num5 = (int) (sbyte) ByteCodeHelper.f2i(shadowColor.b * (float) byte.MaxValue);
            ByteBuffer pixels1 = pixmap1.getPixels();
            ByteBuffer pixels2 = pixmap2.getPixels();
            for (int index1 = 0; index1 < height1; ++index1)
            {
              int num6 = width2 * (index1 + num2) + num1;
              for (int index2 = 0; index2 < width1; ++index2)
              {
                int num7 = (width1 * index1 + index2) * 4;
                int num8 = (int) (sbyte) pixels1.get(num7 + 3);
                if (num8 != 0)
                {
                  int num9 = (num6 + index2) * 4;
                  pixels2.put(num9, (byte) num3);
                  pixels2.put(num9 + 1, (byte) num4);
                  pixels2.put(num9 + 2, (byte) num5);
                  pixels2.put(num9 + 3, (byte) ByteCodeHelper.f2i((float) (num8 & (int) byte.MaxValue) * a));
                }
              }
            }
          }
          int num10 = 0;
          for (int renderCount = obj2.renderCount; num10 < renderCount; ++num10)
            pixmap2.drawPixmap(pixmap1, Math.max(-obj2.shadowOffsetX, 0), Math.max(-obj2.shadowOffsetY, 0));
          pixmap1.dispose();
          pixmap1 = pixmap2;
        }
        else if ((double) obj2.borderWidth == 0.0)
        {
          int num = 0;
          for (int index = obj2.renderCount - 1; num < index; ++num)
            pixmap1.drawPixmap(pixmap1, 0, 0);
        }
        if (obj2.padTop > 0 || obj2.padLeft > 0 || (obj2.padBottom > 0 || obj2.padRight > 0))
        {
          Pixmap pixmap2 = new Pixmap(pixmap1.getWidth() + obj2.padLeft + obj2.padRight, pixmap1.getHeight() + obj2.padTop + obj2.padBottom, pixmap1.getFormat());
          pixmap2.drawPixmap(pixmap1, obj2.padLeft, obj2.padTop);
          pixmap1.dispose();
          pixmap1 = pixmap2;
        }
      }
      FreeType.GlyphMetrics metrics = glyph1.getMetrics();
      Font.Glyph glyph4 = new Font.Glyph()
      {
        id = charCode,
        width = pixmap1.getWidth(),
        height = pixmap1.getHeight(),
        xoffset = glyph2.getLeft()
      };
      glyph4.yoffset = !obj2.flip ? -(glyph4.height - glyph2.getTop()) - ByteCodeHelper.f2i(obj4) : -glyph2.getTop() + ByteCodeHelper.f2i(obj4);
      glyph4.xadvance = FreeType.toInt(metrics.getHoriAdvance()) + ByteCodeHelper.f2i(obj2.borderWidth) + obj2.spaceX;
      if (this.bitmapped)
      {
        pixmap1.setColor(Color.__\u003C\u003Eclear);
        pixmap1.fill();
        ByteBuffer buffer = bitmap.getBuffer();
        int intBits1 = Color.__\u003C\u003Ewhite.toIntBits();
        int intBits2 = Color.__\u003C\u003Eclear.toIntBits();
        for (int y = 0; y < glyph4.height; ++y)
        {
          int num1 = y * bitmap.getPitch();
          for (int x = 0; x < glyph4.width + glyph4.xoffset; ++x)
          {
            int num2 = (int) (sbyte) buffer.get(num1 + x / 8);
            int num3 = x;
            int num4 = 8;
            int num5 = 7 - (num4 != -1 ? num3 % num4 : 0) & 31;
            int num6 = (int) ((uint) num2 >> num5) & 1;
            pixmap1.draw(x, y, num6 != 1 ? intBits2 : intBits1);
          }
        }
      }
      Rect rect = obj5.pack(pixmap1);
      glyph4.page = obj5.getPages().size - 1;
      glyph4.srcX = ByteCodeHelper.f2i(rect.x);
      glyph4.srcY = ByteCodeHelper.f2i(rect.y);
      if (obj2.incremental && obj1.regions != null && obj1.regions.size <= glyph4.page)
        obj5.updateTextureRegions(obj1.regions, obj2.minFilter, obj2.magFilter, obj2.genMipMaps);
      pixmap1.dispose();
      glyph2.dispose();
      return glyph4;
    }

    [LineNumberTable(new byte[] {20, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public FreeTypeFontGenerator(Fi fontFile)
      : this(fontFile, 0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int getMaxTextureSize() => FreeTypeFontGenerator.maxTextureSize;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void setMaxTextureSize(int texSize) => FreeTypeFontGenerator.maxTextureSize = texSize;

    [LineNumberTable(252)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int scaleToFitSquare(int width, int height, int numChars) => Math.min(this.scaleForPixelHeight(height), this.scaleForPixelWidth(width, numChars));

    [LineNumberTable(new byte[] {159, 77, 66, 136, 113, 204, 110, 194, 105, 176, 204, 104, 106, 109, 133, 168, 136, 103, 100, 110, 144, 104, 136, 109, 127, 7, 115, 104, 104, 136, 104, 105, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual FreeTypeFontGenerator.GlyphAndBitmap generateGlyphAndBitmap(
      int c,
      int size,
      bool flip)
    {
      int num1 = flip ? 1 : 0;
      this.setPixelSizes(0, size);
      int num2 = FreeType.toInt(this.face.getSize().getMetrics().getAscender());
      if (this.face.getCharIndex(c) == 0)
        return (FreeTypeFontGenerator.GlyphAndBitmap) null;
      if (!this.loadChar(c))
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new ArcRuntimeException("Unable to load character!");
      }
      FreeType.GlyphSlot glyph1 = this.face.getGlyph();
      FreeType.Bitmap bitmap = !this.bitmapped ? (glyph1.renderGlyph(FreeType.FT_RENDER_MODE_NORMAL) ? glyph1.getBitmap() : (FreeType.Bitmap) null) : glyph1.getBitmap();
      FreeType.GlyphMetrics metrics = glyph1.getMetrics();
      Font.Glyph glyph2 = new Font.Glyph();
      if (bitmap != null)
      {
        glyph2.width = bitmap.getWidth();
        glyph2.height = bitmap.getRows();
      }
      else
      {
        glyph2.width = 0;
        glyph2.height = 0;
      }
      glyph2.xoffset = glyph1.getBitmapLeft();
      glyph2.yoffset = num1 == 0 ? -(glyph2.height - glyph1.getBitmapTop()) - num2 : -glyph1.getBitmapTop() + num2;
      glyph2.xadvance = FreeType.toInt(metrics.getHoriAdvance());
      glyph2.srcX = 0;
      glyph2.srcY = 0;
      glyph2.id = c;
      return new FreeTypeFontGenerator.GlyphAndBitmap(this)
      {
        glyph = glyph2,
        bitmap = bitmap
      };
    }

    [LineNumberTable(new byte[] {160, 202, 102, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual FreeTypeFontGenerator.FreeTypeFontData generateData(int size) => this.generateData(new FreeTypeFontGenerator.FreeTypeFontParameter()
    {
      size = size
    });

    [LineNumberTable(new byte[] {162, 36, 107, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void dispose()
    {
      this.face.dispose();
      this.library.dispose();
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    static FreeTypeFontGenerator()
    {
      if (ByteCodeHelper.isAlreadyInited("arc.freetype.FreeTypeFontGenerator"))
        return;
      FreeTypeFontGenerator.maxTextureSize = 1024;
    }

    [HideFromJava]
    public virtual bool isDisposed() => Disposable.\u003Cdefault\u003EisDisposed((Disposable) this);

    [InnerClass]
    [EnclosingMethod(null, null, null)]
    [Modifiers]
    [SpecialName]
    internal class \u0031 : Object
    {
      [Modifiers]
      internal static int[] \u0024SwitchMap\u0024arc\u0024freetype\u0024FreeTypeFontGenerator\u0024Hinting;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(146)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static \u0031()
      {
        if (ByteCodeHelper.isAlreadyInited("arc.freetype.FreeTypeFontGenerator$1"))
          return;
        FreeTypeFontGenerator.\u0031.\u0024SwitchMap\u0024arc\u0024freetype\u0024FreeTypeFontGenerator\u0024Hinting = new int[FreeTypeFontGenerator.Hinting.values().Length];
        try
        {
          FreeTypeFontGenerator.\u0031.\u0024SwitchMap\u0024arc\u0024freetype\u0024FreeTypeFontGenerator\u0024Hinting[FreeTypeFontGenerator.Hinting.__\u003C\u003Enone.ordinal()] = 1;
          goto label_6;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_6:
        try
        {
          FreeTypeFontGenerator.\u0031.\u0024SwitchMap\u0024arc\u0024freetype\u0024FreeTypeFontGenerator\u0024Hinting[FreeTypeFontGenerator.Hinting.__\u003C\u003Eslight.ordinal()] = 2;
          goto label_10;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_10:
        try
        {
          FreeTypeFontGenerator.\u0031.\u0024SwitchMap\u0024arc\u0024freetype\u0024FreeTypeFontGenerator\u0024Hinting[FreeTypeFontGenerator.Hinting.__\u003C\u003Emedium.ordinal()] = 3;
          goto label_14;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_14:
        try
        {
          FreeTypeFontGenerator.\u0031.\u0024SwitchMap\u0024arc\u0024freetype\u0024FreeTypeFontGenerator\u0024Hinting[FreeTypeFontGenerator.Hinting.__\u003C\u003Efull.ordinal()] = 4;
          goto label_18;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_18:
        try
        {
          FreeTypeFontGenerator.\u0031.\u0024SwitchMap\u0024arc\u0024freetype\u0024FreeTypeFontGenerator\u0024Hinting[FreeTypeFontGenerator.Hinting.__\u003C\u003EautoSlight.ordinal()] = 5;
          goto label_22;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_22:
        try
        {
          FreeTypeFontGenerator.\u0031.\u0024SwitchMap\u0024arc\u0024freetype\u0024FreeTypeFontGenerator\u0024Hinting[FreeTypeFontGenerator.Hinting.__\u003C\u003EautoMedium.ordinal()] = 6;
          goto label_26;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_26:
        try
        {
          FreeTypeFontGenerator.\u0031.\u0024SwitchMap\u0024arc\u0024freetype\u0024FreeTypeFontGenerator\u0024Hinting[FreeTypeFontGenerator.Hinting.__\u003C\u003EautoFull.ordinal()] = 7;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
      }

      \u0031() => throw null;
    }

    [Implements(new string[] {"arc.util.Disposable"})]
    public class FreeTypeFontData : Font.FontData, Disposable
    {
      [Signature("Larc/struct/Seq<Larc/graphics/g2d/TextureRegion;>;")]
      internal Seq regions;
      internal FreeTypeFontGenerator generator;
      internal FreeTypeFontGenerator.FreeTypeFontParameter parameter;
      internal FreeType.Stroker stroker;
      internal PixmapPacker packer;
      [Signature("Larc/struct/Seq<Larc/graphics/g2d/Font$Glyph;>;")]
      internal Seq glyphs;
      private bool dirty;

      [LineNumberTable(690)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public FreeTypeFontData()
      {
      }

      [LineNumberTable(new byte[] {158, 223, 162, 104, 113, 119, 127, 9, 127, 2, 138, 125, 104, 108, 135, 108, 112, 105, 121, 116, 143, 109, 152, 109, 243, 56, 235, 76})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override Font.Glyph getGlyph(char ch)
      {
        int num1 = (int) ch;
        Font.Glyph glyph1 = base.getGlyph((char) num1);
        if (glyph1 == null && this.generator != null)
        {
          this.generator.setPixelSizes(0, this.parameter.size);
          float num2 = ((!this.flipped ? this.ascent : -this.ascent) + this.capHeight) / this.scaleY;
          glyph1 = this.generator.createGlyph((char) num1, this, this.parameter, this.stroker, num2, this.packer);
          if (glyph1 == null)
            return this.missingGlyph;
          this.setGlyphRegion(glyph1, (TextureRegion) this.regions.get(glyph1.page));
          this.setGlyph(num1, glyph1);
          this.glyphs.add((object) glyph1);
          this.dirty = true;
          FreeType.Face face = this.generator.face;
          if (this.parameter.kerning)
          {
            int charIndex1 = face.getCharIndex(num1);
            int index = 0;
            for (int size = this.glyphs.size; index < size; ++index)
            {
              Font.Glyph glyph2 = (Font.Glyph) this.glyphs.get(index);
              int charIndex2 = face.getCharIndex(glyph2.id);
              int kerning1 = face.getKerning(charIndex1, charIndex2, 0);
              if (kerning1 != 0)
                glyph1.setKerning(glyph2.id, FreeType.toInt(kerning1));
              int kerning2 = face.getKerning(charIndex2, charIndex1, 0);
              if (kerning2 != 0)
                glyph2.setKerning(num1, FreeType.toInt(kerning2));
            }
          }
        }
        return glyph1;
      }

      [LineNumberTable(new byte[] {158, 215, 138, 116, 127, 8, 104, 103, 159, 19})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void getGlyphs(
        GlyphLayout.GlyphRun run,
        CharSequence str,
        int start,
        int end,
        Font.Glyph lastGlyph)
      {
        object obj1 = (object) str.__\u003Cref\u003E;
        if (this.packer != null)
          this.packer.setPackToTexture(true);
        GlyphLayout.GlyphRun run1 = run;
        object obj2 = obj1;
        int num1 = start;
        int num2 = end;
        Font.Glyph glyph = lastGlyph;
        int num3 = num2;
        int num4 = num1;
        object obj3 = obj2;
        CharSequence charSequence;
        charSequence.__\u003Cref\u003E = (__Null) obj3;
        CharSequence str1 = charSequence;
        int start1 = num4;
        int end1 = num3;
        Font.Glyph lastGlyph1 = glyph;
        base.getGlyphs(run1, str1, start1, end1, lastGlyph1);
        if (!this.dirty)
          return;
        this.dirty = false;
        this.packer.updateTextureRegions(this.regions, this.parameter.minFilter, this.parameter.magFilter, this.parameter.genMipMaps);
      }

      [LineNumberTable(new byte[] {162, 118, 115, 115})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void dispose()
      {
        if (this.stroker != null)
          this.stroker.dispose();
        if (this.packer == null)
          return;
        this.packer.dispose();
      }

      [HideFromJava]
      public virtual bool isDisposed() => Disposable.\u003Cdefault\u003EisDisposed((Disposable) this);
    }

    public class FreeTypeFontParameter : Object
    {
      public int size;
      public bool mono;
      public FreeTypeFontGenerator.Hinting hinting;
      public Color color;
      public float gamma;
      public int renderCount;
      public float borderWidth;
      public Color borderColor;
      public bool borderStraight;
      public float borderGamma;
      public int shadowOffsetX;
      public int shadowOffsetY;
      public Color shadowColor;
      public int spaceX;
      public int spaceY;
      public int padTop;
      public int padLeft;
      public int padBottom;
      public int padRight;
      public string characters;
      public bool kerning;
      public PixmapPacker packer;
      public bool flip;
      public bool genMipMaps;
      public Texture.TextureFilter minFilter;
      public Texture.TextureFilter magFilter;
      public bool incremental;

      [LineNumberTable(new byte[] {162, 134, 136, 200, 139, 139, 139, 135, 139, 139, 135, 139, 135, 231, 69, 255, 0, 70, 139, 231, 69, 135, 135, 135, 139})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public FreeTypeFontParameter()
      {
        FreeTypeFontGenerator.FreeTypeFontParameter typeFontParameter = this;
        this.size = 16;
        this.hinting = FreeTypeFontGenerator.Hinting.__\u003C\u003EautoMedium;
        this.color = Color.__\u003C\u003Ewhite;
        this.gamma = 1.8f;
        this.renderCount = 2;
        this.borderWidth = 0.0f;
        this.borderColor = Color.__\u003C\u003Eblack;
        this.borderStraight = false;
        this.borderGamma = 1.8f;
        this.shadowOffsetX = 0;
        this.shadowOffsetY = 0;
        this.shadowColor = new Color(0.0f, 0.0f, 0.0f, 0.75f);
        this.characters = "\0ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890\"!`?'.,;:()[]{}<>|/@\\^$€-%+=#_&~*\u007F\u0080\u0081\u0082\u0083\u0084\u0085\u0086\u0087\u0088\u0089\u008A\u008B\u008C\u008D\u008E\u008F\u0090\u0091\u0092\u0093\u0094\u0095\u0096\u0097\u0098\u0099\u009A\u009B\u009C\u009D\u009E\u009F ¡¢£¤¥¦§¨©ª«¬\u00AD®¯°±\u00B2\u00B3´µ¶·¸\u00B9º»\u00BC\u00BD\u00BE¿ÀÁÂÃÄÅÆÇÈÉÊËÌÍÎÏÐÑÒÓÔÕÖ×ØÙÚÛÜÝÞßàáâãäåæçèéêëìíîïðñòóôõö÷øùúûüýþÿ";
        this.kerning = true;
        this.packer = (PixmapPacker) null;
        this.flip = false;
        this.genMipMaps = false;
        this.minFilter = Texture.TextureFilter.__\u003C\u003Enearest;
        this.magFilter = Texture.TextureFilter.__\u003C\u003Enearest;
      }
    }

    public class GlyphAndBitmap : Object
    {
      public Font.Glyph glyph;
      public FreeType.Bitmap bitmap;
      [Modifiers]
      internal FreeTypeFontGenerator this\u00240;

      [LineNumberTable(821)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public GlyphAndBitmap(FreeTypeFontGenerator _param1)
      {
        this.this\u00240 = _param1;
        // ISSUE: explicit constructor call
        base.\u002Ector();
      }
    }

    [InnerClass]
    [Signature("Ljava/lang/Enum<Larc/freetype/FreeTypeFontGenerator$Hinting;>;")]
    [Modifiers]
    [Serializable]
    public sealed class Hinting : Enum
    {
      [Modifiers]
      internal static FreeTypeFontGenerator.Hinting __\u003C\u003Enone;
      [Modifiers]
      internal static FreeTypeFontGenerator.Hinting __\u003C\u003Eslight;
      [Modifiers]
      internal static FreeTypeFontGenerator.Hinting __\u003C\u003Emedium;
      [Modifiers]
      internal static FreeTypeFontGenerator.Hinting __\u003C\u003Efull;
      [Modifiers]
      internal static FreeTypeFontGenerator.Hinting __\u003C\u003EautoSlight;
      [Modifiers]
      internal static FreeTypeFontGenerator.Hinting __\u003C\u003EautoMedium;
      [Modifiers]
      internal static FreeTypeFontGenerator.Hinting __\u003C\u003EautoFull;
      [Modifiers]
      private static FreeTypeFontGenerator.Hinting[] \u0024VALUES;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(667)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static FreeTypeFontGenerator.Hinting[] values() => (FreeTypeFontGenerator.Hinting[]) FreeTypeFontGenerator.Hinting.\u0024VALUES.Clone();

      [Signature("()V")]
      [LineNumberTable(667)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private Hinting([In] string obj0, [In] int obj1)
        : base(obj0, obj1)
      {
        GC.KeepAlive((object) this);
      }

      [LineNumberTable(667)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static FreeTypeFontGenerator.Hinting valueOf(string name) => (FreeTypeFontGenerator.Hinting) Enum.valueOf((Class) ClassLiteral<FreeTypeFontGenerator.Hinting>.Value, name);

      [LineNumberTable(new byte[] {158, 231, 109, 144, 144, 144, 144, 144, 144, 240, 50})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static Hinting()
      {
        if (ByteCodeHelper.isAlreadyInited("arc.freetype.FreeTypeFontGenerator$Hinting"))
          return;
        FreeTypeFontGenerator.Hinting.__\u003C\u003Enone = new FreeTypeFontGenerator.Hinting(nameof (none), 0);
        FreeTypeFontGenerator.Hinting.__\u003C\u003Eslight = new FreeTypeFontGenerator.Hinting(nameof (slight), 1);
        FreeTypeFontGenerator.Hinting.__\u003C\u003Emedium = new FreeTypeFontGenerator.Hinting(nameof (medium), 2);
        FreeTypeFontGenerator.Hinting.__\u003C\u003Efull = new FreeTypeFontGenerator.Hinting(nameof (full), 3);
        FreeTypeFontGenerator.Hinting.__\u003C\u003EautoSlight = new FreeTypeFontGenerator.Hinting(nameof (autoSlight), 4);
        FreeTypeFontGenerator.Hinting.__\u003C\u003EautoMedium = new FreeTypeFontGenerator.Hinting(nameof (autoMedium), 5);
        FreeTypeFontGenerator.Hinting.__\u003C\u003EautoFull = new FreeTypeFontGenerator.Hinting(nameof (autoFull), 6);
        FreeTypeFontGenerator.Hinting.\u0024VALUES = new FreeTypeFontGenerator.Hinting[7]
        {
          FreeTypeFontGenerator.Hinting.__\u003C\u003Enone,
          FreeTypeFontGenerator.Hinting.__\u003C\u003Eslight,
          FreeTypeFontGenerator.Hinting.__\u003C\u003Emedium,
          FreeTypeFontGenerator.Hinting.__\u003C\u003Efull,
          FreeTypeFontGenerator.Hinting.__\u003C\u003EautoSlight,
          FreeTypeFontGenerator.Hinting.__\u003C\u003EautoMedium,
          FreeTypeFontGenerator.Hinting.__\u003C\u003EautoFull
        };
      }

      [Modifiers]
      public static FreeTypeFontGenerator.Hinting none
      {
        [HideFromJava] get => FreeTypeFontGenerator.Hinting.__\u003C\u003Enone;
      }

      [Modifiers]
      public static FreeTypeFontGenerator.Hinting slight
      {
        [HideFromJava] get => FreeTypeFontGenerator.Hinting.__\u003C\u003Eslight;
      }

      [Modifiers]
      public static FreeTypeFontGenerator.Hinting medium
      {
        [HideFromJava] get => FreeTypeFontGenerator.Hinting.__\u003C\u003Emedium;
      }

      [Modifiers]
      public static FreeTypeFontGenerator.Hinting full
      {
        [HideFromJava] get => FreeTypeFontGenerator.Hinting.__\u003C\u003Efull;
      }

      [Modifiers]
      public static FreeTypeFontGenerator.Hinting autoSlight
      {
        [HideFromJava] get => FreeTypeFontGenerator.Hinting.__\u003C\u003EautoSlight;
      }

      [Modifiers]
      public static FreeTypeFontGenerator.Hinting autoMedium
      {
        [HideFromJava] get => FreeTypeFontGenerator.Hinting.__\u003C\u003EautoMedium;
      }

      [Modifiers]
      public static FreeTypeFontGenerator.Hinting autoFull
      {
        [HideFromJava] get => FreeTypeFontGenerator.Hinting.__\u003C\u003EautoFull;
      }

      [HideFromJava]
      [Serializable]
      public enum __Enum
      {
        none,
        slight,
        medium,
        full,
        autoSlight,
        autoMedium,
        autoFull,
      }
    }
  }
}
