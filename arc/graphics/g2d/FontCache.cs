// Decompiled with JetBrains decompiler
// Type: arc.graphics.g2d.FontCache
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.func;
using arc.util.pooling;
using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.graphics.g2d
{
  public class FontCache : Object
  {
    [Modifiers]
    private static Color tempColor;
    [Modifiers]
    private Font font;
    [Modifiers]
    [Signature("Larc/struct/Seq<Larc/graphics/g2d/GlyphLayout;>;")]
    private Seq layouts;
    [Modifiers]
    [Signature("Larc/struct/Seq<Larc/graphics/g2d/GlyphLayout;>;")]
    private Seq pooledLayouts;
    [Modifiers]
    private Color color;
    private bool integer;
    private int glyphCount;
    private float x;
    private float y;
    private float currentTint;
    private float[][] pageVertices;
    private int[] idx;
    private IntSeq[] pageGlyphIndices;
    private int[] tempGlyphCount;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Font getFont() => this.font;

    [LineNumberTable(new byte[] {161, 109, 102, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setText(GlyphLayout layout, float x, float y)
    {
      this.clear();
      this.addText(layout, x, y);
    }

    [LineNumberTable(new byte[] {53, 104, 106, 135, 103, 105, 36, 166, 117, 115, 122, 117, 105, 127, 0, 117, 112, 105, 107, 115, 107, 105, 42, 232, 58, 235, 60, 11, 233, 81})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void tint(Color tint)
    {
      float floatBits1 = tint.toFloatBits();
      if ((double) this.currentTint == (double) floatBits1)
        return;
      this.currentTint = floatBits1;
      int[] tempGlyphCount = this.tempGlyphCount;
      int index1 = 0;
      for (int length = tempGlyphCount.Length; index1 < length; ++index1)
        tempGlyphCount[index1] = 0;
      int index2 = 0;
      for (int size1 = this.layouts.size; index2 < size1; ++index2)
      {
        GlyphLayout glyphLayout = (GlyphLayout) this.layouts.get(index2);
        int index3 = 0;
        for (int size2 = glyphLayout.__\u003C\u003Eruns.size; index3 < size2; ++index3)
        {
          GlyphLayout.GlyphRun glyphRun = (GlyphLayout.GlyphRun) glyphLayout.__\u003C\u003Eruns.get(index3);
          Seq glyphs = glyphRun.glyphs;
          float floatBits2 = FontCache.tempColor.set(glyphRun.__\u003C\u003Ecolor).mul(tint).toFloatBits();
          int index4 = 0;
          for (int size3 = glyphs.size; index4 < size3; ++index4)
          {
            int page = ((Font.Glyph) glyphs.get(index4)).page;
            int num = tempGlyphCount[page] * 24 + 2;
            int[] numArray1 = tempGlyphCount;
            int index5 = page;
            int[] numArray2 = numArray1;
            numArray2[index5] = numArray2[index5] + 1;
            float[] pageVertex = this.pageVertices[page];
            for (int index6 = 0; index6 < 24; index6 += 6)
              pageVertex[num + index6] = floatBits2;
          }
        }
      }
    }

    [LineNumberTable(new byte[] {24, 122})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setPosition(float x, float y) => this.translate(x - this.x, y - this.y);

    [LineNumberTable(new byte[] {160, 116, 108, 110, 107, 105, 255, 1, 61, 230, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void draw()
    {
      Seq regions = this.font.getRegions();
      int index = 0;
      for (int length = this.pageVertices.Length; index < length; ++index)
      {
        if (this.idx[index] > 0)
        {
          float[] pageVertex = this.pageVertices[index];
          Draw.vert(((TextureRegion) regions.get(index)).texture, pageVertex, 0, this.idx[index]);
        }
      }
    }

    [LineNumberTable(new byte[] {160, 176, 107, 107, 108, 108, 108, 110, 117, 9, 198})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void clear()
    {
      this.x = 0.0f;
      this.y = 0.0f;
      Pools.freeAll(this.pooledLayouts, true);
      this.pooledLayouts.clear();
      this.layouts.clear();
      int index = 0;
      for (int length = this.idx.Length; index < length; ++index)
      {
        if (this.pageGlyphIndices != null)
          this.pageGlyphIndices[index].clear();
        this.idx[index] = 0;
      }
    }

    [LineNumberTable(496)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual GlyphLayout addText(
      CharSequence str,
      float x,
      float y,
      float targetWidth,
      int halign,
      bool wrap)
    {
      object obj1 = (object) str.__\u003Cref\u003E;
      int num1 = wrap ? 1 : 0;
      object obj2 = obj1;
      double num2 = (double) x;
      double num3 = (double) y;
      object obj3 = obj1;
      CharSequence str1;
      str1.__\u003Cref\u003E = (__Null) obj3;
      int num4 = ((CharSequence) ref str1).length();
      double num5 = (double) targetWidth;
      int num6 = halign;
      int num7 = num1;
      string truncate = (string) null;
      bool wrap1 = num7 != 0;
      int halign1 = num6;
      float targetWidth1 = (float) num5;
      int end = num4;
      int start = 0;
      float y1 = (float) num3;
      float x1 = (float) num2;
      object obj4 = obj2;
      str1.__\u003Cref\u003E = (__Null) obj4;
      return this.addText(str1, x1, y1, start, end, targetWidth1, halign1, wrap1, truncate);
    }

    [LineNumberTable(new byte[] {82, 114, 108, 115, 106, 118, 103, 106, 136, 99, 105, 108, 105, 230, 55, 11, 233, 79})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setAlphas(float alpha)
    {
      int num1 = ByteCodeHelper.f2i(254f * alpha) << 24;
      float num2 = 0.0f;
      float num3 = 0.0f;
      int index1 = 0;
      for (int length = this.pageVertices.Length; index1 < length; ++index1)
      {
        float[] pageVertex = this.pageVertices[index1];
        int index2 = 2;
        for (int index3 = this.idx[index1]; index2 < index3; index2 += 6)
        {
          float num4 = pageVertex[index2];
          if ((double) num4 == (double) num2 && index2 != 2)
          {
            pageVertex[index2] = num3;
          }
          else
          {
            num2 = num4;
            num3 = Color.intToFloatColor(Color.floatToIntColor(num4) & 16777215 | num1);
            pageVertex[index2] = num3;
          }
        }
      }
    }

    [LineNumberTable(new byte[] {159, 130, 98, 232, 39, 107, 107, 255, 0, 88, 103, 135, 108, 99, 144, 108, 108, 132, 108, 112, 45, 166, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public FontCache(Font font, bool integer)
    {
      int num = integer ? 1 : 0;
      // ISSUE: explicit constructor call
      base.\u002Ector();
      FontCache fontCache = this;
      this.layouts = new Seq();
      this.pooledLayouts = new Seq();
      this.color = new Color(1f, 1f, 1f, 1f);
      this.font = font;
      this.integer = num != 0;
      int size = font.regions.size;
      if (size == 0)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException("The specified font must contain at least one texture page.");
      }
      this.pageVertices = new float[size][];
      this.idx = new int[size];
      if (size > 1)
      {
        this.pageGlyphIndices = new IntSeq[size];
        int index = 0;
        for (int length = this.pageGlyphIndices.Length; index < length; ++index)
          this.pageGlyphIndices[index] = new IntSeq();
      }
      this.tempGlyphCount = new int[size];
    }

    [LineNumberTable(new byte[] {33, 115, 104, 106, 138, 112, 144, 103, 108, 100, 115, 117, 23, 8, 233, 71})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void translate(float xAmount, float yAmount)
    {
      if ((double) xAmount == 0.0 && (double) yAmount == 0.0)
        return;
      if (this.integer)
      {
        xAmount = (float) Math.round(xAmount);
        yAmount = (float) Math.round(yAmount);
      }
      this.x += xAmount;
      this.y += yAmount;
      float[][] pageVertices = this.pageVertices;
      int index1 = 0;
      for (int length = pageVertices.Length; index1 < length; ++index1)
      {
        float[] numArray1 = pageVertices[index1];
        int num = 0;
        for (int index2 = this.idx[index1]; num < index2; num += 6)
        {
          float[] numArray2 = numArray1;
          int index3 = num;
          float[] numArray3 = numArray2;
          numArray3[index3] = numArray3[index3] + xAmount;
          float[] numArray4 = numArray1;
          int index4 = num + 1;
          float[] numArray5 = numArray4;
          numArray5[index4] = numArray5[index4] + yAmount;
        }
      }
    }

    [LineNumberTable(new byte[] {103, 110, 105, 113, 37, 6, 230, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setColors(float color)
    {
      int index1 = 0;
      for (int length = this.pageVertices.Length; index1 < length; ++index1)
      {
        float[] pageVertex = this.pageVertices[index1];
        int index2 = 2;
        for (int index3 = this.idx[index1]; index2 < index3; index2 += 6)
          pageVertex[index2] = color;
      }
    }

    [LineNumberTable(new byte[] {160, 70, 106, 105, 112, 37, 134, 161, 104, 105, 106, 138, 114, 172, 167, 101, 105, 47, 232, 56, 232, 60, 233, 81})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setColors(float color, int start, int end)
    {
      if (this.pageVertices.Length == 1)
      {
        float[] pageVertex = this.pageVertices[0];
        int index1 = start * 24 + 2;
        for (int index2 = end * 24; index1 < index2; index1 += 6)
          pageVertex[index1] = color;
      }
      else
      {
        int length = this.pageVertices.Length;
        for (int index1 = 0; index1 < length; ++index1)
        {
          float[] pageVertex = this.pageVertices[index1];
          IntSeq pageGlyphIndex = this.pageGlyphIndices[index1];
          int index2 = 0;
          for (int size = pageGlyphIndex.size; index2 < size; ++index2)
          {
            int num = pageGlyphIndex.items[index2];
            if (num < end)
            {
              if (num >= start)
              {
                for (int index3 = 0; index3 < 24; index3 += 6)
                  pageVertex[index3 + (index2 * 24 + 2)] = color;
              }
            }
            else
              break;
          }
        }
      }
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Color getColor() => this.color;

    [LineNumberTable(new byte[] {112, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setColors(Color tint) => this.setColors(tint.toFloatBits());

    [LineNumberTable(new byte[] {160, 211, 104, 113, 190, 110, 105, 99, 112, 101, 103, 113, 137})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void requirePageGlyphs([In] int obj0, [In] int obj1)
    {
      if (this.pageGlyphIndices != null && obj1 > this.pageGlyphIndices[obj0].items.Length)
        this.pageGlyphIndices[obj0].ensureCapacity(obj1 - this.pageGlyphIndices[obj0].items.Length);
      int length = this.idx[obj0] + obj1 * 24;
      float[] pageVertex = this.pageVertices[obj0];
      if (pageVertex == null)
      {
        this.pageVertices[obj0] = new float[length];
      }
      else
      {
        if (pageVertex.Length >= length)
          return;
        float[] numArray = new float[length];
        ByteCodeHelper.arraycopy_primitive_4((Array) pageVertex, 0, (Array) numArray, 0, this.idx[obj0]);
        this.pageVertices[obj0] = numArray;
      }
    }

    [LineNumberTable(new byte[] {160, 188, 138, 98, 114, 62, 134, 104, 101, 103, 105, 36, 166, 117, 120, 114, 63, 5, 8, 233, 70, 105, 42, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void requireGlyphs([In] GlyphLayout obj0)
    {
      if (this.pageVertices.Length == 1)
      {
        int num = 0;
        int index = 0;
        for (int size = obj0.__\u003C\u003Eruns.size; index < size; ++index)
          num += ((GlyphLayout.GlyphRun) obj0.__\u003C\u003Eruns.get(index)).glyphs.size;
        this.requirePageGlyphs(0, num);
      }
      else
      {
        int[] tempGlyphCount = this.tempGlyphCount;
        int index1 = 0;
        for (int length = tempGlyphCount.Length; index1 < length; ++index1)
          tempGlyphCount[index1] = 0;
        int index2 = 0;
        for (int size1 = obj0.__\u003C\u003Eruns.size; index2 < size1; ++index2)
        {
          Seq glyphs = ((GlyphLayout.GlyphRun) obj0.__\u003C\u003Eruns.get(index2)).glyphs;
          int index3 = 0;
          for (int size2 = glyphs.size; index3 < size2; ++index3)
          {
            int[] numArray1 = tempGlyphCount;
            int page = ((Font.Glyph) glyphs.get(index3)).page;
            int[] numArray2 = numArray1;
            numArray2[page] = numArray2[page] + 1;
          }
        }
        int index4 = 0;
        for (int length = tempGlyphCount.Length; index4 < length; ++index4)
          this.requirePageGlyphs(index4, tempGlyphCount[index4]);
      }
    }

    [LineNumberTable(new byte[] {161, 15, 127, 3, 112, 112, 118, 159, 1, 104, 106, 106, 104, 136, 142, 104, 107, 153, 159, 15, 107, 109, 109, 110, 109, 109, 134, 109, 109, 110, 109, 109, 134, 109, 109, 110, 109, 109, 134, 109, 109, 110, 109, 167})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void addGlyph([In] Font.Glyph obj0, [In] float obj1, [In] float obj2, [In] float obj3)
    {
      float scaleX = this.font.data.scaleX;
      float scaleY = this.font.data.scaleY;
      obj1 += (float) obj0.xoffset * scaleX;
      obj2 += (float) obj0.yoffset * scaleY;
      float num1 = (float) obj0.width * scaleX;
      float num2 = (float) obj0.height * scaleY;
      float u = obj0.u;
      float u2 = obj0.u2;
      float v = obj0.v;
      float v2 = obj0.v2;
      if (this.integer)
      {
        obj1 = (float) Math.round(obj1);
        obj2 = (float) Math.round(obj2);
        num1 = (float) Math.round(num1);
        num2 = (float) Math.round(num2);
      }
      float num3 = obj1 + num1;
      float num4 = obj2 + num2;
      int page = obj0.page;
      int num5 = this.idx[page];
      int[] idx = this.idx;
      int index1 = page;
      int[] numArray1 = idx;
      numArray1[index1] = numArray1[index1] + 24;
      if (this.pageGlyphIndices != null)
      {
        IntSeq pageGlyphIndex = this.pageGlyphIndices[page];
        FontCache fontCache1 = this;
        int glyphCount = fontCache1.glyphCount;
        FontCache fontCache2 = fontCache1;
        int num6 = glyphCount;
        fontCache2.glyphCount = glyphCount + 1;
        pageGlyphIndex.add(num6);
      }
      float[] pageVertex = this.pageVertices[page];
      float[] numArray2 = pageVertex;
      int index2 = num5;
      int num7 = num5 + 1;
      double num8 = (double) obj1;
      numArray2[index2] = (float) num8;
      float[] numArray3 = pageVertex;
      int index3 = num7;
      int num9 = num7 + 1;
      double num10 = (double) obj2;
      numArray3[index3] = (float) num10;
      float[] numArray4 = pageVertex;
      int index4 = num9;
      int num11 = num9 + 1;
      double num12 = (double) obj3;
      numArray4[index4] = (float) num12;
      float[] numArray5 = pageVertex;
      int index5 = num11;
      int num13 = num11 + 1;
      double num14 = (double) u;
      numArray5[index5] = (float) num14;
      float[] numArray6 = pageVertex;
      int index6 = num13;
      int num15 = num13 + 1;
      double num16 = (double) v;
      numArray6[index6] = (float) num16;
      int num17 = num15 + 1;
      float[] numArray7 = pageVertex;
      int index7 = num17;
      int num18 = num17 + 1;
      double num19 = (double) obj1;
      numArray7[index7] = (float) num19;
      float[] numArray8 = pageVertex;
      int index8 = num18;
      int num20 = num18 + 1;
      double num21 = (double) num4;
      numArray8[index8] = (float) num21;
      float[] numArray9 = pageVertex;
      int index9 = num20;
      int num22 = num20 + 1;
      double num23 = (double) obj3;
      numArray9[index9] = (float) num23;
      float[] numArray10 = pageVertex;
      int index10 = num22;
      int num24 = num22 + 1;
      double num25 = (double) u;
      numArray10[index10] = (float) num25;
      float[] numArray11 = pageVertex;
      int index11 = num24;
      int num26 = num24 + 1;
      double num27 = (double) v2;
      numArray11[index11] = (float) num27;
      int num28 = num26 + 1;
      float[] numArray12 = pageVertex;
      int index12 = num28;
      int num29 = num28 + 1;
      double num30 = (double) num3;
      numArray12[index12] = (float) num30;
      float[] numArray13 = pageVertex;
      int index13 = num29;
      int num31 = num29 + 1;
      double num32 = (double) num4;
      numArray13[index13] = (float) num32;
      float[] numArray14 = pageVertex;
      int index14 = num31;
      int num33 = num31 + 1;
      double num34 = (double) obj3;
      numArray14[index14] = (float) num34;
      float[] numArray15 = pageVertex;
      int index15 = num33;
      int num35 = num33 + 1;
      double num36 = (double) u2;
      numArray15[index15] = (float) num36;
      float[] numArray16 = pageVertex;
      int index16 = num35;
      int num37 = num35 + 1;
      double num38 = (double) v2;
      numArray16[index16] = (float) num38;
      int num39 = num37 + 1;
      float[] numArray17 = pageVertex;
      int index17 = num39;
      int num40 = num39 + 1;
      double num41 = (double) num3;
      numArray17[index17] = (float) num41;
      float[] numArray18 = pageVertex;
      int index18 = num40;
      int num42 = num40 + 1;
      double num43 = (double) obj2;
      numArray18[index18] = (float) num43;
      float[] numArray19 = pageVertex;
      int index19 = num42;
      int num44 = num42 + 1;
      double num45 = (double) obj3;
      numArray19[index19] = (float) num45;
      float[] numArray20 = pageVertex;
      int index20 = num44;
      int index21 = num44 + 1;
      double num46 = (double) u2;
      numArray20[index20] = (float) num46;
      pageVertex[index21] = v;
    }

    [LineNumberTable(505)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual GlyphLayout addText(
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
      object obj2 = obj1;
      double num2 = (double) x;
      double num3 = (double) y;
      int num4 = start;
      int num5 = end;
      double num6 = (double) targetWidth;
      int num7 = halign;
      int num8 = num1;
      string truncate = (string) null;
      bool wrap1 = num8 != 0;
      int halign1 = num7;
      float targetWidth1 = (float) num6;
      int end1 = num5;
      int start1 = num4;
      float y1 = (float) num3;
      float x1 = (float) num2;
      object obj3 = obj2;
      CharSequence str1;
      str1.__\u003Cref\u003E = (__Null) obj3;
      return this.addText(str1, x1, y1, start1, end1, targetWidth1, halign1, wrap1, truncate);
    }

    [LineNumberTable(new byte[] {159, 12, 173, 122, 108, 127, 46, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual GlyphLayout addText(
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
      GlyphLayout layout = (GlyphLayout) Pools.obtain((Class) ClassLiteral<GlyphLayout>.Value, (Prov) new FontCache.__\u003C\u003EAnon0());
      this.pooledLayouts.add((object) layout);
      GlyphLayout glyphLayout = layout;
      Font font = this.font;
      object obj2 = obj1;
      int num2 = start;
      int num3 = end;
      Color color1 = this.color;
      double num4 = (double) targetWidth;
      int num5 = halign;
      int num6 = num1;
      string str1 = truncate;
      bool flag = num6 != 0;
      int num7 = num5;
      float num8 = (float) num4;
      Color color2 = color1;
      int num9 = num3;
      int num10 = num2;
      object obj3 = obj2;
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj3;
      CharSequence str2 = charSequence;
      int start1 = num10;
      int end1 = num9;
      Color color3 = color2;
      double num11 = (double) num8;
      int halign1 = num7;
      int num12 = flag ? 1 : 0;
      string truncate1 = str1;
      glyphLayout.setText(font, str2, start1, end1, color3, (float) num11, halign1, num12 != 0, truncate1);
      this.addText(layout, x, y);
      return layout;
    }

    [LineNumberTable(new byte[] {161, 162, 125})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addText(GlyphLayout layout, float x, float y) => this.addToCache(layout, x, y + this.font.data.ascent);

    [LineNumberTable(new byte[] {160, 229, 113, 109, 103, 117, 135, 103, 117, 135, 103, 99, 104, 105, 149, 105, 41, 136, 135, 172, 108, 103, 121, 116, 105, 105, 111, 122, 114, 112, 112, 238, 61, 232, 58, 235, 77, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void addToCache([In] GlyphLayout obj0, [In] float obj1, [In] float obj2)
    {
      int size1 = this.font.regions.size;
      if (this.pageVertices.Length < size1)
      {
        float[][] numArray1 = new float[size1][];
        ByteCodeHelper.arraycopy((object) this.pageVertices, 0, (object) numArray1, 0, this.pageVertices.Length);
        this.pageVertices = numArray1;
        int[] numArray2 = new int[size1];
        ByteCodeHelper.arraycopy_primitive_4((Array) this.idx, 0, (Array) numArray2, 0, this.idx.Length);
        this.idx = numArray2;
        IntSeq[] intSeqArray = new IntSeq[size1];
        int num = 0;
        if (this.pageGlyphIndices != null)
        {
          num = this.pageGlyphIndices.Length;
          ByteCodeHelper.arraycopy((object) this.pageGlyphIndices, 0, (object) intSeqArray, 0, this.pageGlyphIndices.Length);
        }
        for (int index = num; index < size1; ++index)
          intSeqArray[index] = new IntSeq();
        this.pageGlyphIndices = intSeqArray;
        this.tempGlyphCount = new int[size1];
      }
      this.layouts.add((object) obj0);
      this.requireGlyphs(obj0);
      int index1 = 0;
      for (int size2 = obj0.__\u003C\u003Eruns.size; index1 < size2; ++index1)
      {
        GlyphLayout.GlyphRun glyphRun = (GlyphLayout.GlyphRun) obj0.__\u003C\u003Eruns.get(index1);
        Seq glyphs = glyphRun.glyphs;
        FloatSeq xAdvances = glyphRun.xAdvances;
        float floatBits = glyphRun.__\u003C\u003Ecolor.toFloatBits();
        float num1 = obj1 + glyphRun.x;
        float num2 = obj2 + glyphRun.y;
        int index2 = 0;
        for (int size3 = glyphs.size; index2 < size3; ++index2)
        {
          Font.Glyph glyph = (Font.Glyph) glyphs.get(index2);
          num1 += xAdvances.get(index2);
          this.addGlyph(glyph, num1, num2, floatBits);
        }
      }
      this.currentTint = Color.__\u003C\u003EwhiteFloatBits;
    }

    [LineNumberTable(564)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float[] getVertices(int page) => this.pageVertices[page];

    [LineNumberTable(new byte[] {159, 187, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public FontCache(Font font)
      : this(font, font.usesIntegerPositions())
    {
    }

    [LineNumberTable(new byte[] {117, 127, 38, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setColors(float r, float g, float b, float a) => this.setColors(Color.intToFloatColor(ByteCodeHelper.f2i((float) byte.MaxValue * a) << 24 | ByteCodeHelper.f2i((float) byte.MaxValue * b) << 16 | ByteCodeHelper.f2i((float) byte.MaxValue * g) << 8 | ByteCodeHelper.f2i((float) byte.MaxValue * r)));

    [LineNumberTable(new byte[] {126, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setColors(Color tint, int start, int end) => this.setColors(tint.toFloatBits(), start, end);

    [LineNumberTable(new byte[] {160, 107, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setColor(Color color) => this.color.set(color);

    [LineNumberTable(new byte[] {160, 112, 117})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setColor(float r, float g, float b, float a) => this.color.set(r, g, b, a);

    [LineNumberTable(new byte[] {160, 126, 106, 127, 8, 193, 108, 113, 165, 106, 114, 171, 167, 172, 101, 230, 53, 232, 79, 170, 255, 8, 41, 233, 89})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void draw(int start, int end)
    {
      if (this.pageVertices.Length == 1)
      {
        Draw.vert(this.font.getRegion().texture, this.pageVertices[0], start * 24, (end - start) * 24);
      }
      else
      {
        Seq regions = this.font.getRegions();
        int index1 = 0;
        for (int length = this.pageVertices.Length; index1 < length; ++index1)
        {
          int num1 = -1;
          int num2 = 0;
          IntSeq pageGlyphIndex = this.pageGlyphIndices[index1];
          int index2 = 0;
          for (int size = pageGlyphIndex.size; index2 < size; ++index2)
          {
            int num3 = pageGlyphIndex.get(index2);
            if (num3 < end)
            {
              if (num1 == -1 && num3 >= start)
                num1 = index2;
              if (num3 >= start)
                ++num2;
            }
            else
              break;
          }
          if (num1 != -1 && num2 != 0)
            Draw.vert(((TextureRegion) regions.get(index1)).texture, this.pageVertices[index1], num1 * 24, num2 * 24);
        }
      }
    }

    [LineNumberTable(new byte[] {160, 161, 105, 102, 129, 103, 103, 112, 103, 102, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void draw(float alphaModulation)
    {
      if ((double) alphaModulation == 1.0)
      {
        this.draw();
      }
      else
      {
        Color color = this.getColor();
        float a = color.a;
        color.a *= alphaModulation;
        this.setColors(color);
        this.draw();
        color.a = a;
        this.setColors(color);
      }
    }

    [LineNumberTable(new byte[] {159, 32, 106, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual GlyphLayout setText(CharSequence str, float x, float y)
    {
      object obj1 = (object) str.__\u003Cref\u003E;
      this.clear();
      object obj2 = obj1;
      double num1 = (double) x;
      double num2 = (double) y;
      object obj3 = obj1;
      CharSequence str1;
      str1.__\u003Cref\u003E = (__Null) obj3;
      int num3 = ((CharSequence) ref str1).length();
      bool wrap = false;
      int halign = 8;
      float targetWidth = 0.0f;
      int end = num3;
      int start = 0;
      float y1 = (float) num2;
      float x1 = (float) num1;
      object obj4 = obj2;
      str1.__\u003Cref\u003E = (__Null) obj4;
      return this.addText(str1, x1, y1, start, end, targetWidth, halign, wrap);
    }

    [LineNumberTable(new byte[] {159, 30, 141, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual GlyphLayout setText(
      CharSequence str,
      float x,
      float y,
      float targetWidth,
      int halign,
      bool wrap)
    {
      object obj1 = (object) str.__\u003Cref\u003E;
      int num1 = wrap ? 1 : 0;
      this.clear();
      object obj2 = obj1;
      double num2 = (double) x;
      double num3 = (double) y;
      object obj3 = obj1;
      CharSequence str1;
      str1.__\u003Cref\u003E = (__Null) obj3;
      int num4 = ((CharSequence) ref str1).length();
      double num5 = (double) targetWidth;
      int num6 = halign;
      bool wrap1 = num1 != 0;
      int halign1 = num6;
      float targetWidth1 = (float) num5;
      int end = num4;
      int start = 0;
      float y1 = (float) num3;
      float x1 = (float) num2;
      object obj4 = obj2;
      str1.__\u003Cref\u003E = (__Null) obj4;
      return this.addText(str1, x1, y1, start, end, targetWidth1, halign1, wrap1);
    }

    [LineNumberTable(new byte[] {159, 27, 77, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual GlyphLayout setText(
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
      this.clear();
      object obj2 = obj1;
      double num2 = (double) x;
      double num3 = (double) y;
      int num4 = start;
      int num5 = end;
      double num6 = (double) targetWidth;
      int num7 = halign;
      bool wrap1 = num1 != 0;
      int halign1 = num7;
      float targetWidth1 = (float) num6;
      int end1 = num5;
      int start1 = num4;
      float y1 = (float) num3;
      float x1 = (float) num2;
      object obj3 = obj2;
      CharSequence str1;
      str1.__\u003Cref\u003E = (__Null) obj3;
      return this.addText(str1, x1, y1, start1, end1, targetWidth1, halign1, wrap1);
    }

    [LineNumberTable(new byte[] {159, 25, 141, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual GlyphLayout setText(
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
      this.clear();
      object obj2 = obj1;
      double num2 = (double) x;
      double num3 = (double) y;
      int num4 = start;
      int num5 = end;
      double num6 = (double) targetWidth;
      int num7 = halign;
      int num8 = num1;
      string truncate1 = truncate;
      bool wrap1 = num8 != 0;
      int halign1 = num7;
      float targetWidth1 = (float) num6;
      int end1 = num5;
      int start1 = num4;
      float y1 = (float) num3;
      float x1 = (float) num2;
      object obj3 = obj2;
      CharSequence str1;
      str1.__\u003Cref\u003E = (__Null) obj3;
      return this.addText(str1, x1, y1, start1, end1, targetWidth1, halign1, wrap1, truncate1);
    }

    [LineNumberTable(488)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual GlyphLayout addText(CharSequence str, float x, float y)
    {
      object obj1 = (object) str.__\u003Cref\u003E;
      object obj2 = obj1;
      double num1 = (double) x;
      double num2 = (double) y;
      object obj3 = obj1;
      CharSequence str1;
      str1.__\u003Cref\u003E = (__Null) obj3;
      int num3 = ((CharSequence) ref str1).length();
      string truncate = (string) null;
      bool wrap = false;
      int halign = 8;
      float targetWidth = 0.0f;
      int end = num3;
      int start = 0;
      float y1 = (float) num2;
      float x1 = (float) num1;
      object obj4 = obj2;
      str1.__\u003Cref\u003E = (__Null) obj4;
      return this.addText(str1, x1, y1, start, end, targetWidth, halign, wrap, truncate);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getX() => this.x;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getY() => this.y;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setUseIntegerPositions(bool use) => this.integer = use;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool usesIntegerPositions() => this.integer;

    [LineNumberTable(560)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float[] getVertices() => this.getVertices(0);

    [LineNumberTable(568)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getVertexCount(int page) => this.idx[page];

    [Signature("()Larc/struct/Seq<Larc/graphics/g2d/GlyphLayout;>;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Seq getLayouts() => this.layouts;

    [LineNumberTable(21)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static FontCache()
    {
      if (ByteCodeHelper.isAlreadyInited("arc.graphics.g2d.FontCache"))
        return;
      FontCache.tempColor = new Color(1f, 1f, 1f, 1f);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Prov
    {
      internal __\u003C\u003EAnon0()
      {
      }

      public object get() => (object) new GlyphLayout();
    }
  }
}
