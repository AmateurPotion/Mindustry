// Decompiled with JetBrains decompiler
// Type: arc.graphics.g2d.Font
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.files;
using arc.func;
using arc.util;
using arc.util.io;
using IKVM.Attributes;
using IKVM.Runtime;
using java.io;
using java.lang;
using java.util;
using java.util.regex;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.graphics.g2d
{
  public class Font : Object, Disposable
  {
    private const int LOG2_PAGE_SIZE = 9;
    private const int PAGE_SIZE = 512;
    private const int PAGES = 128;
    [Modifiers]
    internal Font.FontData data;
    [Modifiers]
    private FontCache cache;
    [Signature("Larc/struct/Seq<Larc/graphics/g2d/TextureRegion;>;")]
    internal Seq regions;
    internal bool integer;
    private bool flipped;
    private bool ownsTexture;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool usesIntegerPositions() => this.integer;

    [LineNumberTable(new byte[] {159, 42, 130, 103, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setUseIntegerPositions(bool integer)
    {
      int num = integer ? 1 : 0;
      this.integer = num != 0;
      this.cache.setUseIntegerPositions(num != 0);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Font.FontData getData() => this.data;

    [LineNumberTable(new byte[] {160, 165, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setColor(Color color) => this.cache.getColor().set(color);

    [LineNumberTable(225)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual GlyphLayout draw(CharSequence str, float x, float y, int halign)
    {
      object obj1 = (object) str.__\u003Cref\u003E;
      double num1 = (double) x;
      double num2 = (double) y;
      int num3 = halign;
      bool wrap = false;
      int halign1 = num3;
      float targetWidth = 0.0f;
      float y1 = (float) num2;
      float x1 = (float) num1;
      object obj2 = obj1;
      CharSequence str1;
      str1.__\u003Cref\u003E = (__Null) obj2;
      return this.draw(str1, x1, y1, targetWidth, halign1, wrap);
    }

    [LineNumberTable(new byte[] {159, 89, 77, 108, 104, 104, 110, 103, 127, 28, 108, 104, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual GlyphLayout draw(
      CharSequence str,
      float x,
      float y,
      Color color,
      float scale,
      bool integer,
      int halign)
    {
      int num1 = integer ? 1 : 0;
      object obj1 = (object) str.__\u003Cref\u003E;
      float scaleX = this.getData().scaleX;
      int num2 = this.usesIntegerPositions() ? 1 : 0;
      this.setColor(color);
      this.getData().setScale(scale);
      this.setUseIntegerPositions(num1 != 0);
      object obj2 = obj1;
      double num3 = (double) x;
      double num4 = (double) y;
      int num5 = halign;
      bool wrap = false;
      int halign1 = num5;
      float targetWidth = 0.0f;
      float y1 = (float) num4;
      float x1 = (float) num3;
      object obj3 = obj2;
      CharSequence str1;
      str1.__\u003Cref\u003E = (__Null) obj3;
      GlyphLayout glyphLayout = this.draw(str1, x1, y1, targetWidth, halign1, wrap);
      this.getData().setScale(scaleX);
      this.setUseIntegerPositions(num2 != 0);
      this.setColor(Color.__\u003C\u003Ewhite);
      return glyphLayout;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setOwnsTexture(bool ownsTexture) => this.ownsTexture = ownsTexture;

    [LineNumberTable(447)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual FontCache newFontCache()
    {
      FontCache.__\u003Cclinit\u003E();
      return new FontCache(this, this.integer);
    }

    [LineNumberTable(288)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getScaleX() => this.data.scaleX;

    [LineNumberTable(292)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getScaleY() => this.data.scaleY;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isFlipped() => this.flipped;

    [LineNumberTable(353)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getDescent() => this.data.descent;

    [LineNumberTable(new byte[] {159, 84, 109, 107, 127, 29, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual GlyphLayout draw(
      CharSequence str,
      float x,
      float y,
      float targetWidth,
      int halign,
      bool wrap)
    {
      object obj1 = (object) str.__\u003Cref\u003E;
      int num1 = wrap ? 1 : 0;
      this.cache.clear();
      FontCache cache = this.cache;
      object obj2 = obj1;
      double num2 = (double) x;
      double num3 = (double) y;
      double num4 = (double) targetWidth;
      int num5 = halign;
      bool flag = num1 != 0;
      int num6 = num5;
      float num7 = (float) num4;
      float num8 = (float) num3;
      float num9 = (float) num2;
      object obj3 = obj2;
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj3;
      CharSequence str1 = charSequence;
      double num10 = (double) num9;
      double num11 = (double) num8;
      double num12 = (double) num7;
      int halign1 = num6;
      int num13 = flag ? 1 : 0;
      GlyphLayout glyphLayout = cache.addText(str1, (float) num10, (float) num11, (float) num12, halign1, num13 != 0);
      this.cache.draw();
      return glyphLayout;
    }

    [LineNumberTable(new byte[] {160, 170, 122})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setColor(float r, float g, float b, float a) => this.cache.getColor().set(r, g, b, a);

    [LineNumberTable(new byte[] {159, 91, 106, 107, 127, 9, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual GlyphLayout draw(CharSequence str, float x, float y)
    {
      object obj1 = (object) str.__\u003Cref\u003E;
      this.cache.clear();
      FontCache cache = this.cache;
      object obj2 = obj1;
      double num1 = (double) x;
      float num2 = y;
      float num3 = (float) num1;
      object obj3 = obj2;
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj3;
      CharSequence str1 = charSequence;
      double num4 = (double) num3;
      double num5 = (double) num2;
      GlyphLayout glyphLayout = cache.addText(str1, (float) num4, (float) num5);
      this.cache.draw();
      return glyphLayout;
    }

    [LineNumberTable(322)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getLineHeight() => this.data.lineHeight;

    [LineNumberTable(301)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual TextureRegion getRegion() => (TextureRegion) this.regions.first();

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual FontCache getCache() => this.cache;

    [LineNumberTable(new byte[] {31, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Font(Fi fontFile, TextureRegion region)
      : this(fontFile, region, false)
    {
    }

    [Signature("(Larc/graphics/g2d/Font$FontData;Larc/struct/Seq<Larc/graphics/g2d/TextureRegion;>;Z)V")]
    [LineNumberTable(new byte[] {159, 104, 98, 104, 108, 103, 135, 110, 104, 176, 104, 108, 134, 104, 150, 127, 0, 248, 58, 230, 72, 103, 98, 103, 167, 140, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Font(Font.FontData data, Seq pageRegions, bool integer)
    {
      int num = integer ? 1 : 0;
      // ISSUE: explicit constructor call
      base.\u002Ector();
      Font font = this;
      this.flipped = data.flipped;
      this.data = data;
      this.integer = num != 0;
      if (pageRegions == null || pageRegions.size == 0)
      {
        if (data.imagePaths == null)
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalArgumentException("If no regions are specified, the font data must have an images path.");
        }
        int length = data.imagePaths.Length;
        this.regions = new Seq(length);
        for (int index = 0; index < length; ++index)
          this.regions.add((object) new TextureRegion(new Texture(data.fontFile != null ? Core.files.get(data.imagePaths[index], data.fontFile.type()) : Core.files.@internal(data.imagePaths[index]), false)));
        this.ownsTexture = true;
      }
      else
      {
        this.regions = pageRegions;
        this.ownsTexture = false;
      }
      this.cache = this.newFontCache();
      this.load(data);
    }

    [Signature("()Larc/struct/Seq<Larc/graphics/g2d/TextureRegion;>;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Seq getRegions() => this.regions;

    [LineNumberTable(new byte[] {159, 119, 98, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Font(Fi fontFile, TextureRegion region, bool flip)
    {
      int num = flip ? 1 : 0;
      // ISSUE: explicit constructor call
      this.\u002Ector(new Font.FontData(fontFile, num != 0), region, true);
    }

    [LineNumberTable(new byte[] {159, 106, 66, 125})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Font(Font.FontData data, TextureRegion region, bool integer)
    {
      int num1 = integer ? 1 : 0;
      Font.FontData data1 = data;
      Seq pageRegions;
      if (region != null)
        pageRegions = Seq.with((object[]) new TextureRegion[1]
        {
          region
        });
      else
        pageRegions = (Seq) null;
      int num2 = num1;
      // ISSUE: explicit constructor call
      this.\u002Ector(data1, pageRegions, num2 != 0);
    }

    [LineNumberTable(new byte[] {159, 115, 130, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Font(Fi fontFile, bool flip)
    {
      int num = flip ? 1 : 0;
      // ISSUE: explicit constructor call
      this.\u002Ector(new Font.FontData(fontFile, num != 0), (TextureRegion) null, true);
    }

    [LineNumberTable(new byte[] {159, 110, 101, 124, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Font(Fi fontFile, Fi imageFile, bool flip, bool integer)
    {
      int num1 = flip ? 1 : 0;
      int num2 = integer ? 1 : 0;
      // ISSUE: explicit constructor call
      this.\u002Ector(new Font.FontData(fontFile, num1 != 0), new TextureRegion(new Texture(imageFile, false)), num2 != 0);
      Font font = this;
      this.ownsTexture = true;
    }

    [LineNumberTable(new byte[] {160, 78, 119, 101, 120, 63, 4, 8, 233, 69, 127, 16})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void load(Font.FontData data)
    {
      Font.Glyph[][] glyphs = data.__\u003C\u003Eglyphs;
      int length1 = glyphs.Length;
      for (int index1 = 0; index1 < length1; ++index1)
      {
        Font.Glyph[] glyphArray1 = glyphs[index1];
        if (glyphArray1 != null)
        {
          Font.Glyph[] glyphArray2 = glyphArray1;
          int length2 = glyphArray2.Length;
          for (int index2 = 0; index2 < length2; ++index2)
          {
            Font.Glyph glyph = glyphArray2[index2];
            if (glyph != null)
              data.setGlyphRegion(glyph, (TextureRegion) this.regions.get(glyph.page));
          }
        }
      }
      if (data.missingGlyph == null)
        return;
      data.setGlyphRegion(data.missingGlyph, (TextureRegion) this.regions.get(data.missingGlyph.page));
    }

    [Modifiers]
    [LineNumberTable(374)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024isDisposed\u00240([In] TextureRegion obj0) => obj0.texture.isDisposed();

    [LineNumberTable(new byte[] {51, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Font(Fi fontFile)
      : this(fontFile, false)
    {
    }

    [LineNumberTable(new byte[] {159, 113, 162, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Font(Fi fontFile, Fi imageFile, bool flip)
    {
      int num = flip ? 1 : 0;
      // ISSUE: explicit constructor call
      this.\u002Ector(fontFile, imageFile, num != 0, true);
    }

    [LineNumberTable(new byte[] {159, 96, 108, 115, 101, 59, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static int indexOf([In] CharSequence obj0, [In] char obj1, [In] int obj2)
    {
      object obj3 = (object) obj0.__\u003Cref\u003E;
      int num1 = (int) obj1;
      object obj4 = obj3;
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj4;
      int num2;
      for (num2 = ((CharSequence) ref charSequence).length(); obj2 < num2; ++obj2)
      {
        object obj5 = obj3;
        int num3 = obj2;
        object obj6 = obj5;
        charSequence.__\u003Cref\u003E = (__Null) obj6;
        if ((int) ((CharSequence) ref charSequence).charAt(num3) == num1)
          return obj2;
      }
      return num2;
    }

    [LineNumberTable(new byte[] {159, 81, 77, 107, 127, 41, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual GlyphLayout draw(
      CharSequence str,
      float x,
      float y,
      int start,
      int end,
      float targetWidth,
      int halign,
      bool wrap)
    {
      object obj1 = (object) str.__\u003Cref\u003E;
      int num1 = wrap ? 1 : 0;
      this.cache.clear();
      FontCache cache = this.cache;
      object obj2 = obj1;
      double num2 = (double) x;
      double num3 = (double) y;
      int num4 = start;
      int num5 = end;
      double num6 = (double) targetWidth;
      int num7 = halign;
      bool flag = num1 != 0;
      int num8 = num7;
      float num9 = (float) num6;
      int num10 = num5;
      int num11 = num4;
      float num12 = (float) num3;
      float num13 = (float) num2;
      object obj3 = obj2;
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj3;
      CharSequence str1 = charSequence;
      double num14 = (double) num13;
      double num15 = (double) num12;
      int start1 = num11;
      int end1 = num10;
      double num16 = (double) num9;
      int halign1 = num8;
      int num17 = flag ? 1 : 0;
      GlyphLayout glyphLayout = cache.addText(str1, (float) num14, (float) num15, start1, end1, (float) num16, halign1, num17 != 0);
      this.cache.draw();
      return glyphLayout;
    }

    [LineNumberTable(new byte[] {159, 78, 77, 107, 127, 47, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual GlyphLayout draw(
      CharSequence str,
      float x,
      float y,
      int start,
      int end,
      float targetWidth,
      int halign,
      bool wrap,
      string truncate)
    {
      object obj1 = (object) str.__\u003Cref\u003E;
      int num1 = wrap ? 1 : 0;
      this.cache.clear();
      FontCache cache = this.cache;
      object obj2 = obj1;
      double num2 = (double) x;
      double num3 = (double) y;
      int num4 = start;
      int num5 = end;
      double num6 = (double) targetWidth;
      int num7 = halign;
      int num8 = num1;
      string str1 = truncate;
      bool flag = num8 != 0;
      int num9 = num7;
      float num10 = (float) num6;
      int num11 = num5;
      int num12 = num4;
      float num13 = (float) num3;
      float num14 = (float) num2;
      object obj3 = obj2;
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj3;
      CharSequence str2 = charSequence;
      double num15 = (double) num14;
      double num16 = (double) num13;
      int start1 = num12;
      int end1 = num11;
      double num17 = (double) num10;
      int halign1 = num9;
      int num18 = flag ? 1 : 0;
      string truncate1 = str1;
      GlyphLayout glyphLayout = cache.addText(str2, (float) num15, (float) num16, start1, end1, (float) num17, halign1, num18 != 0, truncate1);
      this.cache.draw();
      return glyphLayout;
    }

    [LineNumberTable(new byte[] {160, 153, 107, 112, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void draw(GlyphLayout layout, float x, float y)
    {
      this.cache.clear();
      this.cache.addText(layout, x, y);
      this.cache.draw();
    }

    [LineNumberTable(274)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Color getColor() => this.cache.getColor();

    [LineNumberTable(317)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual TextureRegion getRegion(int index) => (TextureRegion) this.regions.get(index);

    [LineNumberTable(327)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getSpaceXadvance() => this.data.spaceXadvance;

    [LineNumberTable(332)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getXHeight() => this.data.xHeight;

    [LineNumberTable(340)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getCapHeight() => this.data.capHeight;

    [LineNumberTable(345)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getAscent() => this.data.ascent;

    [LineNumberTable(new byte[] {160, 250, 104, 112, 59, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void dispose()
    {
      if (!this.ownsTexture)
        return;
      for (int index = 0; index < this.regions.size; ++index)
        ((TextureRegion) this.regions.get(index)).texture.dispose();
    }

    [LineNumberTable(new byte[] {161, 2, 136, 150})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isDisposed() => this.ownsTexture && this.regions.contains((Boolf) new Font.__\u003C\u003EAnon0());

    [LineNumberTable(new byte[] {159, 46, 74, 103, 98, 126, 127, 2, 22, 200, 127, 2, 127, 2, 102, 127, 0, 104, 104, 232, 58, 235, 72})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setFixedWidthGlyphs(CharSequence glyphs)
    {
      object obj1 = (object) glyphs.__\u003Cref\u003E;
      Font.FontData data = this.data;
      int num1 = 0;
      int num2 = 0;
      object obj2 = obj1;
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj2;
      for (int index = ((CharSequence) ref charSequence).length(); num2 < index; ++num2)
      {
        Font.FontData fontData = data;
        object obj3 = obj1;
        int num3 = num2;
        object obj4 = obj3;
        charSequence.__\u003Cref\u003E = (__Null) obj4;
        int num4 = (int) ((CharSequence) ref charSequence).charAt(num3);
        Font.Glyph glyph = fontData.getGlyph((char) num4);
        if (glyph != null && glyph.xadvance > num1)
          num1 = glyph.xadvance;
      }
      int num5 = 0;
      object obj5 = obj1;
      charSequence.__\u003Cref\u003E = (__Null) obj5;
      for (int index = ((CharSequence) ref charSequence).length(); num5 < index; ++num5)
      {
        Font.FontData fontData = data;
        object obj3 = obj1;
        int num3 = num5;
        object obj4 = obj3;
        charSequence.__\u003Cref\u003E = (__Null) obj4;
        int num4 = (int) ((CharSequence) ref charSequence).charAt(num3);
        Font.Glyph glyph = fontData.getGlyph((char) num4);
        if (glyph != null)
        {
          glyph.xoffset += Math.round((float) ((num1 - glyph.xadvance) / 2));
          glyph.xadvance = num1;
          glyph.kerning = (byte[][]) null;
          glyph.fixedWidth = true;
        }
      }
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool ownsTexture() => this.ownsTexture;

    [LineNumberTable(new byte[] {161, 81, 126})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toString() => this.data.fontFile != null ? this.data.fontFile.nameWithoutExtension() : base.toString();

    public class FontData : Object
    {
      internal Font.Glyph[][] __\u003C\u003Eglyphs;
      public string[] imagePaths;
      public Fi fontFile;
      public bool flipped;
      public float padTop;
      public float padRight;
      public float padBottom;
      public float padLeft;
      public float lineHeight;
      public float capHeight;
      public float ascent;
      public float descent;
      public float down;
      public float blankLineScale;
      public float scaleX;
      public float scaleY;
      public bool markupEnabled;
      public float cursorX;
      public Font.Glyph missingGlyph;
      public float spaceXadvance;
      public float xHeight;
      public char[] breakChars;
      public char[] xChars;
      public char[] capChars;

      [LineNumberTable(new byte[] {163, 86, 106})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void setScale(float scaleXY) => this.setScale(scaleXY, scaleXY);

      [LineNumberTable(new byte[] {158, 189, 162, 111, 109})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual Font.Glyph getGlyph(char ch)
      {
        int num = (int) ch;
        return this.__\u003C\u003Eglyphs[num / 512]?[num & 511];
      }

      [LineNumberTable(new byte[] {163, 61, 121, 121, 107, 107, 111, 111, 111, 111, 111, 111, 111, 111, 111, 111, 111, 104, 104})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void setScale(float scaleX, float scaleY)
      {
        if ((double) scaleX == 0.0)
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalArgumentException("scaleX cannot be 0.");
        }
        if ((double) scaleY == 0.0)
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalArgumentException("scaleY cannot be 0.");
        }
        float num1 = scaleX / this.scaleX;
        float num2 = scaleY / this.scaleY;
        this.lineHeight *= num2;
        this.spaceXadvance *= num1;
        this.xHeight *= num2;
        this.capHeight *= num2;
        this.ascent *= num2;
        this.descent *= num2;
        this.down *= num2;
        this.padLeft *= num1;
        this.padRight *= num1;
        this.padTop *= num2;
        this.padBottom *= num2;
        this.scaleX = scaleX;
        this.scaleY = scaleY;
      }

      [LineNumberTable(new byte[] {162, 185, 111, 125, 106})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void setGlyph(int ch, Font.Glyph glyph)
      {
        Font.Glyph[] glyphArray = this.__\u003C\u003Eglyphs[ch / 512];
        if (glyphArray == null)
          this.__\u003C\u003Eglyphs[ch / 512] = glyphArray = new Font.Glyph[512];
        glyphArray[ch & 511] = glyph;
      }

      [LineNumberTable(new byte[] {159, 6, 66, 232, 12, 240, 76, 235, 75, 107, 246, 77, 203, 127, 60, 255, 160, 65, 75, 103, 103, 104})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public FontData(Fi fontFile, bool flip)
      {
        int num = flip ? 1 : 0;
        // ISSUE: explicit constructor call
        base.\u002Ector();
        Font.FontData fontData = this;
        this.__\u003C\u003Eglyphs = new Font.Glyph[128][];
        this.capHeight = 1f;
        this.blankLineScale = 1f;
        this.scaleX = 1f;
        this.scaleY = 1f;
        this.xHeight = 1f;
        this.xChars = new char[14]
        {
          'x',
          'e',
          'a',
          'o',
          'n',
          's',
          'r',
          'c',
          'u',
          'm',
          'v',
          'w',
          'z',
          '\uF15C'
        };
        this.capChars = new char[26]
        {
          'M',
          'N',
          'B',
          'D',
          'C',
          'E',
          'F',
          'K',
          'A',
          'G',
          'H',
          'I',
          'J',
          'L',
          'O',
          'P',
          'Q',
          'R',
          'S',
          'T',
          'U',
          'V',
          'W',
          'X',
          'Y',
          'Z'
        };
        this.fontFile = fontFile;
        this.flipped = num != 0;
        this.load(fontFile, num != 0);
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual string[] getImagePaths() => this.imagePaths;

      [LineNumberTable(924)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual string getImagePath(int index) => this.imagePaths[index];

      [LineNumberTable(new byte[] {162, 115, 103, 111, 143, 109, 104, 104, 105, 105, 136, 104, 104, 187, 105, 112, 105, 208, 107, 103, 105, 118, 118, 135, 103, 102, 122, 164, 108, 104, 105, 118, 112, 135, 104, 102, 104, 118, 118, 196, 111, 111, 104, 111, 145, 111, 143})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void setGlyphRegion(Font.Glyph glyph, TextureRegion region)
      {
        Texture texture = region.texture;
        float num1 = 1f / (float) texture.width;
        float num2 = 1f / (float) texture.height;
        float num3 = 0.0f;
        float num4 = 0.0f;
        float u = region.u;
        float v = region.v;
        float width = (float) region.width;
        float height = (float) region.height;
        if (region is TextureAtlas.AtlasRegion)
        {
          TextureAtlas.AtlasRegion atlasRegion = (TextureAtlas.AtlasRegion) region;
          num3 = atlasRegion.offsetX;
          num4 = (float) (atlasRegion.originalHeight - atlasRegion.packedHeight) - atlasRegion.offsetY;
        }
        float num5 = (float) glyph.srcX;
        float num6 = (float) (glyph.srcX + glyph.width);
        float num7 = (float) glyph.srcY;
        float num8 = (float) (glyph.srcY + glyph.height);
        if ((double) num3 > 0.0)
        {
          num5 -= num3;
          if ((double) num5 < 0.0)
          {
            Font.Glyph glyph1 = glyph;
            glyph1.width = ByteCodeHelper.f2i((float) glyph1.width + num5);
            Font.Glyph glyph2 = glyph;
            glyph2.xoffset = ByteCodeHelper.f2i((float) glyph2.xoffset - num5);
            num5 = 0.0f;
          }
          num6 -= num3;
          if ((double) num6 > (double) width)
          {
            Font.Glyph glyph1 = glyph;
            glyph1.width = ByteCodeHelper.f2i((float) glyph1.width - (num6 - width));
            num6 = width;
          }
        }
        if ((double) num4 > 0.0)
        {
          num7 -= num4;
          if ((double) num7 < 0.0)
          {
            Font.Glyph glyph1 = glyph;
            glyph1.height = ByteCodeHelper.f2i((float) glyph1.height + num7);
            if (glyph.height < 0)
              glyph.height = 0;
            num7 = 0.0f;
          }
          num8 -= num4;
          if ((double) num8 > (double) height)
          {
            float num9 = num8 - height;
            Font.Glyph glyph1 = glyph;
            glyph1.height = ByteCodeHelper.f2i((float) glyph1.height - num9);
            Font.Glyph glyph2 = glyph;
            glyph2.yoffset = ByteCodeHelper.f2i((float) glyph2.yoffset + num9);
            num8 = height;
          }
        }
        glyph.u = u + num5 * num1;
        glyph.u2 = u + num6 * num1;
        if (this.flipped)
        {
          glyph.v = v + num7 * num2;
          glyph.v2 = v + num8 * num2;
        }
        else
        {
          glyph.v2 = v + num7 * num2;
          glyph.v = v + num8 * num2;
        }
      }

      [LineNumberTable(new byte[] {159, 5, 162, 152, 150, 103, 147, 116, 123, 117, 111, 111, 111, 111, 144, 103, 115, 174, 150, 127, 1, 151, 127, 1, 146, 99, 156, 159, 0, 243, 160, 151, 102, 237, 159, 103, 193, 173, 246, 160, 145, 102, 243, 159, 112, 103, 179, 127, 5, 105, 138, 105, 102, 191, 21, 245, 160, 130, 102, 251, 159, 123, 98, 255, 24, 160, 131, 102, 232, 159, 128, 127, 5, 121, 138, 255, 11, 42, 249, 160, 145, 102, 237, 159, 134, 254, 160, 121, 102, 234, 159, 137, 103, 104, 114, 143, 135, 109, 104, 104, 110, 101, 106, 108, 170, 105, 104, 115, 104, 115, 104, 115, 104, 115, 104, 115, 104, 99, 149, 124, 104, 179, 113, 137, 155, 245, 160, 76, 102, 242, 159, 178, 193, 127, 19, 243, 160, 72, 102, 237, 159, 184, 180, 103, 104, 146, 109, 104, 104, 110, 104, 110, 127, 11, 107, 104, 110, 100, 139, 133, 106, 100, 103, 105, 106, 108, 110, 138, 105, 127, 5, 147, 142, 99, 125, 106, 6, 200, 108, 146, 99, 125, 106, 6, 200, 103, 127, 1, 105, 121, 120, 26, 8, 237, 72, 110, 144, 112, 109, 99, 109, 255, 1, 69, 102, 39, 102, 230, 60, 98, 159, 8, 102, 97})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void load(Fi fontFile, bool flip)
      {
        int num1 = flip ? 1 : 0;
        if (this.imagePaths != null)
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalStateException("Already loaded.");
        }
        BufferedReader bufferedReader = new BufferedReader((Reader) new InputStreamReader(fontFile.read()), 512);
        string str1;
        float num2;
        float num3;
        int length1;
        Exception exception1;
        // ISSUE: fault handler
        try
        {
          str1 = bufferedReader.readLine();
          if (str1 == null)
          {
            Throwable.__\u003CsuppressFillInStackTrace\u003E();
            throw new ArcRuntimeException("File is empty.");
          }
          str1 = String.instancehelper_substring(str1, String.instancehelper_indexOf(str1, "padding=") + 8);
          string[] strArray1 = String.instancehelper_split(String.instancehelper_substring(str1, 0, String.instancehelper_indexOf(str1, 32)), ",", 4);
          if (strArray1.Length != 4)
          {
            Throwable.__\u003CsuppressFillInStackTrace\u003E();
            throw new ArcRuntimeException("Invalid padding.");
          }
          this.padTop = (float) Integer.parseInt(strArray1[0]);
          this.padRight = (float) Integer.parseInt(strArray1[1]);
          this.padBottom = (float) Integer.parseInt(strArray1[2]);
          this.padLeft = (float) Integer.parseInt(strArray1[3]);
          num2 = this.padTop + this.padBottom;
          str1 = bufferedReader.readLine();
          if (str1 == null)
          {
            Throwable.__\u003CsuppressFillInStackTrace\u003E();
            throw new ArcRuntimeException("Missing common header.");
          }
          string[] strArray2 = String.instancehelper_split(str1, " ", 7);
          if (strArray2.Length < 3)
          {
            Throwable.__\u003CsuppressFillInStackTrace\u003E();
            throw new ArcRuntimeException("Invalid common header.");
          }
          if (!String.instancehelper_startsWith(strArray2[1], "lineHeight="))
          {
            Throwable.__\u003CsuppressFillInStackTrace\u003E();
            throw new ArcRuntimeException("Missing: lineHeight");
          }
          this.lineHeight = (float) Integer.parseInt(String.instancehelper_substring(strArray2[1], 11));
          if (!String.instancehelper_startsWith(strArray2[2], "base="))
          {
            Throwable.__\u003CsuppressFillInStackTrace\u003E();
            throw new ArcRuntimeException("Missing: base");
          }
          num3 = (float) Integer.parseInt(String.instancehelper_substring(strArray2[2], 5));
          length1 = 1;
          if (strArray2.Length >= 6)
          {
            if (strArray2[5] != null)
            {
              if (String.instancehelper_startsWith(strArray2[5], "pages="))
              {
                try
                {
                  length1 = Math.max(1, Integer.parseInt(String.instancehelper_substring(strArray2[5], 6)));
                  goto label_26;
                }
                catch (NumberFormatException ex)
                {
                }
              }
              else
                goto label_26;
            }
            else
              goto label_26;
          }
          else
            goto label_26;
        }
        catch (Exception ex)
        {
          M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
          if (m0 == null)
          {
            throw;
          }
          else
          {
            exception1 = (Exception) m0;
            goto label_25;
          }
        }
        __fault
        {
          Streams.close((Closeable) bufferedReader);
        }
        goto label_26;
label_25:
        Exception exception2 = exception1;
        goto label_131;
label_26:
        int index1;
        Exception exception3;
        // ISSUE: fault handler
        try
        {
          this.imagePaths = new string[length1];
          index1 = 0;
          goto label_32;
        }
        catch (Exception ex)
        {
          M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
          if (m0 == null)
            throw;
          else
            exception3 = (Exception) m0;
        }
        __fault
        {
          Streams.close((Closeable) bufferedReader);
        }
        exception2 = exception3;
        goto label_131;
label_32:
        string name;
        NumberFormatException numberFormatException1;
        Exception exception4;
        Exception exception5;
        while (true)
        {
          CharSequence charSequence1;
          // ISSUE: fault handler
          try
          {
            if (index1 < length1)
            {
              str1 = bufferedReader.readLine();
              if (str1 == null)
              {
                Throwable.__\u003CsuppressFillInStackTrace\u003E();
                throw new ArcRuntimeException("Missing additional page definitions.");
              }
              Pattern pattern = Pattern.compile(".*id=(\\d+)");
              object obj = (object) str1;
              charSequence1.__\u003Cref\u003E = (__Null) obj;
              CharSequence charSequence2 = charSequence1;
              Matcher matcher = pattern.matcher(charSequence2);
              if (matcher.find())
              {
                name = matcher.group(1);
                try
                {
                  if (Integer.parseInt(name) != index1)
                  {
                    string message = new StringBuilder().append("Page IDs must be indices starting at 0: ").append(name).toString();
                    Throwable.__\u003CsuppressFillInStackTrace\u003E();
                    throw new ArcRuntimeException(message);
                  }
                }
                catch (NumberFormatException ex)
                {
                  numberFormatException1 = (NumberFormatException) ByteCodeHelper.MapException<NumberFormatException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
                  break;
                }
              }
            }
            else
              goto label_61;
          }
          catch (Exception ex)
          {
            M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
            if (m0 == null)
            {
              throw;
            }
            else
            {
              exception4 = (Exception) m0;
              goto label_45;
            }
          }
          __fault
          {
            Streams.close((Closeable) bufferedReader);
          }
          // ISSUE: fault handler
          try
          {
            Pattern pattern = Pattern.compile(".*file=\"?([^\"]+)\"?");
            object obj = (object) str1;
            charSequence1.__\u003Cref\u003E = (__Null) obj;
            CharSequence charSequence2 = charSequence1;
            Matcher matcher = pattern.matcher(charSequence2);
            if (!matcher.find())
            {
              Throwable.__\u003CsuppressFillInStackTrace\u003E();
              throw new ArcRuntimeException("Missing: file");
            }
            name = matcher.group(1);
            this.imagePaths[index1] = String.instancehelper_replaceAll(fontFile.parent().child(name).path(), "\\\\", "/");
            ++index1;
          }
          catch (Exception ex)
          {
            M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
            if (m0 == null)
            {
              throw;
            }
            else
            {
              exception5 = (Exception) m0;
              goto label_60;
            }
          }
          __fault
          {
            Streams.close((Closeable) bufferedReader);
          }
        }
        NumberFormatException numberFormatException2 = numberFormatException1;
        Exception exception6;
        // ISSUE: fault handler
        try
        {
          NumberFormatException numberFormatException3 = numberFormatException2;
          try
          {
            NumberFormatException numberFormatException4 = numberFormatException3;
            string message = new StringBuilder().append("Invalid page id: ").append(name).toString();
            NumberFormatException numberFormatException5 = numberFormatException4;
            Throwable.__\u003CsuppressFillInStackTrace\u003E();
            throw new ArcRuntimeException(message, (Exception) numberFormatException5);
          }
          catch (Exception ex)
          {
            M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
            if (m0 == null)
              throw;
            else
              exception6 = (Exception) m0;
          }
        }
        __fault
        {
          Streams.close((Closeable) bufferedReader);
        }
        exception2 = exception6;
        goto label_131;
label_45:
        exception2 = exception4;
        goto label_131;
label_60:
        exception2 = exception5;
        goto label_131;
label_61:
        Exception exception7;
        // ISSUE: fault handler
        try
        {
          this.descent = 0.0f;
          goto label_67;
        }
        catch (Exception ex)
        {
          M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
          if (m0 == null)
            throw;
          else
            exception7 = (Exception) m0;
        }
        __fault
        {
          Streams.close((Closeable) bufferedReader);
        }
        exception2 = exception7;
        goto label_131;
label_67:
        Exception exception8;
        Exception exception9;
        while (true)
        {
          Font.Glyph glyph;
          // ISSUE: fault handler
          try
          {
            StringTokenizer stringTokenizer;
            int ch;
            do
            {
              string str2;
              do
              {
                str2 = bufferedReader.readLine();
                if (str2 != null)
                {
                  if (String.instancehelper_startsWith(str2, "kernings "))
                    goto label_93;
                }
                else
                  goto label_93;
              }
              while (!String.instancehelper_startsWith(str2, "char "));
              glyph = new Font.Glyph();
              stringTokenizer = new StringTokenizer(str2, " =");
              stringTokenizer.nextToken();
              stringTokenizer.nextToken();
              ch = Integer.parseInt(stringTokenizer.nextToken());
              if (ch <= 0)
              {
                this.missingGlyph = glyph;
                goto label_74;
              }
            }
            while (ch > (int) ushort.MaxValue);
            this.setGlyph(ch, glyph);
label_74:
            glyph.id = ch;
            stringTokenizer.nextToken();
            glyph.srcX = Integer.parseInt(stringTokenizer.nextToken());
            stringTokenizer.nextToken();
            glyph.srcY = Integer.parseInt(stringTokenizer.nextToken());
            stringTokenizer.nextToken();
            glyph.width = Integer.parseInt(stringTokenizer.nextToken());
            stringTokenizer.nextToken();
            glyph.height = Integer.parseInt(stringTokenizer.nextToken());
            stringTokenizer.nextToken();
            glyph.xoffset = Integer.parseInt(stringTokenizer.nextToken());
            stringTokenizer.nextToken();
            glyph.yoffset = num1 == 0 ? -(glyph.height + Integer.parseInt(stringTokenizer.nextToken())) : Integer.parseInt(stringTokenizer.nextToken());
            stringTokenizer.nextToken();
            glyph.xadvance = Integer.parseInt(stringTokenizer.nextToken());
            if (stringTokenizer.hasMoreTokens())
              stringTokenizer.nextToken();
            if (stringTokenizer.hasMoreTokens())
            {
              try
              {
                glyph.page = Integer.parseInt(stringTokenizer.nextToken());
                goto label_85;
              }
              catch (NumberFormatException ex)
              {
              }
            }
            else
              goto label_85;
          }
          catch (Exception ex)
          {
            M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
            if (m0 == null)
            {
              throw;
            }
            else
            {
              exception8 = (Exception) m0;
              break;
            }
          }
          __fault
          {
            Streams.close((Closeable) bufferedReader);
          }
label_85:
          // ISSUE: fault handler
          try
          {
            if (glyph.width > 0)
            {
              if (glyph.height > 0)
                this.descent = Math.min(num3 + (float) glyph.yoffset, this.descent);
            }
          }
          catch (Exception ex)
          {
            M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
            if (m0 == null)
            {
              throw;
            }
            else
            {
              exception9 = (Exception) m0;
              goto label_92;
            }
          }
          __fault
          {
            Streams.close((Closeable) bufferedReader);
          }
        }
        exception2 = exception8;
        goto label_131;
label_92:
        exception2 = exception9;
        goto label_131;
label_93:
        Exception exception10;
        // ISSUE: fault handler
        try
        {
          this.descent += this.padBottom;
          while (true)
          {
            int ch;
            Font.Glyph glyph;
            int num4;
            do
            {
              StringTokenizer stringTokenizer;
              int num5;
              do
              {
                string str2 = bufferedReader.readLine();
                if (str2 != null && String.instancehelper_startsWith(str2, "kerning "))
                {
                  stringTokenizer = new StringTokenizer(str2, " =");
                  stringTokenizer.nextToken();
                  stringTokenizer.nextToken();
                  num5 = Integer.parseInt(stringTokenizer.nextToken());
                  stringTokenizer.nextToken();
                  ch = Integer.parseInt(stringTokenizer.nextToken());
                }
                else
                  goto label_98;
              }
              while (num5 < 0 || num5 > (int) ushort.MaxValue || (ch < 0 || ch > (int) ushort.MaxValue));
              glyph = this.getGlyph((char) num5);
              stringTokenizer.nextToken();
              num4 = Integer.parseInt(stringTokenizer.nextToken());
            }
            while (glyph == null);
            glyph.setKerning(ch, num4);
          }
label_98:
          Font.Glyph glyph1 = this.getGlyph(' ');
          if (glyph1 == null)
          {
            glyph1 = new Font.Glyph();
            glyph1.id = 32;
            Font.Glyph glyph2 = this.getGlyph('l') ?? this.getFirstGlyph();
            glyph1.xadvance = glyph2.xadvance;
            this.setGlyph(32, glyph1);
          }
          if (glyph1.width == 0)
          {
            glyph1.width = ByteCodeHelper.f2i(this.padLeft + (float) glyph1.xadvance + this.padRight);
            glyph1.xoffset = ByteCodeHelper.f2i(-this.padLeft);
          }
          this.spaceXadvance = (float) glyph1.xadvance;
          Font.Glyph glyph3 = (Font.Glyph) null;
          char[] xChars = this.xChars;
          int length2 = xChars.Length;
          for (int index2 = 0; index2 < length2; ++index2)
          {
            glyph3 = this.getGlyph(xChars[index2]);
            if (glyph3 != null)
              break;
          }
          if (glyph3 == null)
            glyph3 = this.getFirstGlyph();
          this.xHeight = (float) glyph3.height - num2;
          Font.Glyph glyph4 = (Font.Glyph) null;
          char[] capChars = this.capChars;
          int length3 = capChars.Length;
          for (int index2 = 0; index2 < length3; ++index2)
          {
            glyph4 = this.getGlyph(capChars[index2]);
            if (glyph4 != null)
              break;
          }
          if (glyph4 == null)
          {
            Font.Glyph[][] glyphs = this.__\u003C\u003Eglyphs;
            int length4 = glyphs.Length;
            for (int index2 = 0; index2 < length4; ++index2)
            {
              Font.Glyph[] glyphArray1 = glyphs[index2];
              if (glyphArray1 != null)
              {
                Font.Glyph[] glyphArray2 = glyphArray1;
                int length5 = glyphArray2.Length;
                for (int index3 = 0; index3 < length5; ++index3)
                {
                  Font.Glyph glyph2 = glyphArray2[index3];
                  if (glyph2 != null && glyph2.height != 0 && glyph2.width != 0)
                    this.capHeight = Math.max(this.capHeight, (float) glyph2.height);
                }
              }
            }
          }
          else
            this.capHeight = (float) glyph4.height;
          this.capHeight -= num2;
          this.ascent = num3 - this.capHeight;
          this.down = -this.lineHeight;
          if (num1 != 0)
          {
            this.ascent = -this.ascent;
            this.down = -this.down;
            goto label_130;
          }
          else
            goto label_130;
        }
        catch (Exception ex)
        {
          M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
          if (m0 == null)
            throw;
          else
            exception10 = (Exception) m0;
        }
        __fault
        {
          Streams.close((Closeable) bufferedReader);
        }
        exception2 = exception10;
        goto label_131;
label_130:
        Streams.close((Closeable) bufferedReader);
        return;
label_131:
        Exception exception11 = exception2;
        // ISSUE: fault handler
        try
        {
          Exception exception12 = exception11;
          string message = new StringBuilder().append("Error loading font file: ").append((object) fontFile).toString();
          Exception exception13 = exception12;
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new ArcRuntimeException(message, (Exception) exception13);
        }
        __fault
        {
          Streams.close((Closeable) bufferedReader);
        }
      }

      [LineNumberTable(new byte[] {162, 191, 119, 101, 120, 120, 3, 8, 233, 71})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual Font.Glyph getFirstGlyph()
      {
        Font.Glyph[][] glyphs = this.__\u003C\u003Eglyphs;
        int length1 = glyphs.Length;
        for (int index1 = 0; index1 < length1; ++index1)
        {
          Font.Glyph[] glyphArray1 = glyphs[index1];
          if (glyphArray1 != null)
          {
            Font.Glyph[] glyphArray2 = glyphArray1;
            int length2 = glyphArray2.Length;
            for (int index2 = 0; index2 < length2; ++index2)
            {
              Font.Glyph glyph = glyphArray2[index2];
              if (glyph != null && glyph.height != 0 && glyph.width != 0)
                return glyph;
            }
          }
        }
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new ArcRuntimeException("No glyphs found.");
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual bool isWhitespace(char c)
      {
        switch (c)
        {
          case '\t':
          case '\n':
          case '\r':
          case ' ':
            return true;
          default:
            return false;
        }
      }

      [LineNumberTable(new byte[] {158, 172, 66, 106, 117, 39, 134})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual bool isBreakChar(char c)
      {
        int num1 = (int) c;
        if (this.breakChars == null)
          return false;
        char[] breakChars = this.breakChars;
        int length = breakChars.Length;
        for (int index = 0; index < length; ++index)
        {
          int num2 = (int) breakChars[index];
          if (num1 == num2)
            return true;
        }
        return false;
      }

      [LineNumberTable(new byte[] {161, 171, 232, 15, 240, 76, 235, 75, 107, 246, 77, 203, 127, 60, 255, 160, 65, 72})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public FontData()
      {
        Font.FontData fontData = this;
        this.__\u003C\u003Eglyphs = new Font.Glyph[128][];
        this.capHeight = 1f;
        this.blankLineScale = 1f;
        this.scaleX = 1f;
        this.scaleY = 1f;
        this.xHeight = 1f;
        this.xChars = new char[14]
        {
          'x',
          'e',
          'a',
          'o',
          'n',
          's',
          'r',
          'c',
          'u',
          'm',
          'v',
          'w',
          'z',
          '\uF15C'
        };
        this.capChars = new char[26]
        {
          'M',
          'N',
          'B',
          'D',
          'C',
          'E',
          'F',
          'K',
          'A',
          'G',
          'H',
          'I',
          'J',
          'L',
          'O',
          'P',
          'Q',
          'R',
          'S',
          'T',
          'U',
          'V',
          'W',
          'X',
          'Y',
          'Z'
        };
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void setLineHeight(float height)
      {
        this.lineHeight = height * this.scaleY;
        this.down = !this.flipped ? -this.lineHeight : this.lineHeight;
      }

      [LineNumberTable(new byte[] {158, 191, 98, 106})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual bool hasGlyph(char ch)
      {
        int num = (int) ch;
        return this.missingGlyph != null || this.getGlyph((char) num) != null;
      }

      [LineNumberTable(new byte[] {158, 186, 170, 103, 103, 104, 104, 168, 108, 142, 104, 127, 0, 106, 100, 102, 164, 137, 100, 159, 14, 124, 164, 127, 16, 101, 100, 118, 125, 137})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void getGlyphs(
        GlyphLayout.GlyphRun run,
        CharSequence str,
        int start,
        int end,
        Font.Glyph lastGlyph)
      {
        object obj1 = (object) str.__\u003Cref\u003E;
        int num1 = this.markupEnabled ? 1 : 0;
        float scaleX = this.scaleX;
        Font.Glyph missingGlyph = this.missingGlyph;
        Seq glyphs = run.glyphs;
        FloatSeq xAdvances = run.xAdvances;
        glyphs.ensureCapacity(end - start);
        xAdvances.ensureCapacity(end - start + 1);
        while (start < end)
        {
          object obj2 = obj1;
          int num2 = start;
          ++start;
          int num3 = num2;
          object obj3 = obj2;
          CharSequence charSequence;
          charSequence.__\u003Cref\u003E = (__Null) obj3;
          int num4 = (int) ((CharSequence) ref charSequence).charAt(num3);
          Font.Glyph glyph = this.getGlyph((char) num4);
          if (glyph == null)
          {
            if (missingGlyph != null)
              glyph = missingGlyph;
            else
              continue;
          }
          glyphs.add((object) glyph);
          if (lastGlyph == null)
            xAdvances.add(!glyph.fixedWidth ? (float) -glyph.xoffset * scaleX - this.padLeft : 0.0f);
          else
            xAdvances.add((float) (lastGlyph.xadvance + lastGlyph.getKerning((char) num4)) * scaleX);
          lastGlyph = glyph;
          if (num1 != 0 && num4 == 91 && start < end)
          {
            object obj4 = obj1;
            int num5 = start;
            object obj5 = obj4;
            charSequence.__\u003Cref\u003E = (__Null) obj5;
            if (((CharSequence) ref charSequence).charAt(num5) == '[')
              ++start;
          }
        }
        if (lastGlyph == null)
          return;
        float num6 = !lastGlyph.fixedWidth ? (float) (lastGlyph.width + lastGlyph.xoffset) * scaleX - this.padRight : (float) lastGlyph.xadvance * scaleX;
        xAdvances.add(num6);
      }

      [Signature("(Larc/struct/Seq<Larc/graphics/g2d/Font$Glyph;>;I)I")]
      [LineNumberTable(new byte[] {163, 10, 100, 124, 100, 60, 134, 100, 115, 22, 198})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual int getWrapIndex(Seq glyphs, int start)
      {
        int index = start - 1;
        if (this.isWhitespace((char) ((Font.Glyph) glyphs.get(index)).id))
          return index;
        while (index > 0 && this.isWhitespace((char) ((Font.Glyph) glyphs.get(index)).id))
          index += -1;
        for (; index > 0; index += -1)
        {
          int id = (int) (ushort) ((Font.Glyph) glyphs.get(index)).id;
          if (this.isWhitespace((char) id) || this.isBreakChar((char) id))
            return index + 1;
        }
        return 0;
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual Fi getFontFile() => this.fontFile;

      [LineNumberTable(new byte[] {163, 95, 122})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void scale(float amount) => this.setScale(this.scaleX + amount, this.scaleY + amount);

      [Modifiers]
      public Font.Glyph[][] glyphs
      {
        [HideFromJava] get => this.__\u003C\u003Eglyphs;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Eglyphs = value;
      }
    }

    public class Glyph : Object
    {
      public int id;
      public int srcX;
      public int srcY;
      public int width;
      public int height;
      public float u;
      public float v;
      public float u2;
      public float v2;
      public int xoffset;
      public int yoffset;
      public int xadvance;
      public byte[][] kerning;
      public bool fixedWidth;
      public int page;

      [LineNumberTable(new byte[] {161, 86, 232, 76})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public Glyph()
      {
        Font.Glyph glyph = this;
        this.page = 0;
      }

      [LineNumberTable(new byte[] {161, 109, 120, 108, 122, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void setKerning(int ch, int value)
      {
        if (this.kerning == null)
          this.kerning = new byte[128][];
        byte[] numArray = this.kerning[(int) ((uint) ch >> 9)];
        if (numArray == null)
          this.kerning[(int) ((uint) ch >> 9)] = numArray = new byte[512];
        numArray[ch & 511] = (byte) value;
      }

      [LineNumberTable(new byte[] {159, 25, 162, 104, 108, 141})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual int getKerning(char ch)
      {
        int num = (int) ch;
        if (this.kerning != null)
        {
          byte[] numArray = this.kerning[(int) ((uint) num >> 9)];
          if (numArray != null)
            return (int) (sbyte) numArray[num & 511];
        }
        return 0;
      }

      [LineNumberTable(486)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual string toString() => Character.toString((char) this.id);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Boolf
    {
      internal __\u003C\u003EAnon0()
      {
      }

      public bool get([In] object obj0) => (Font.lambda\u0024isDisposed\u00240((TextureRegion) obj0) ? 1 : 0) != 0;
    }
  }
}
