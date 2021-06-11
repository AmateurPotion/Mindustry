// Decompiled with JetBrains decompiler
// Type: arc.graphics.g2d.GlyphLayout
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.func;
using arc.util.pooling;
using ikvm.@internal;
using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.graphics.g2d
{
  public class GlyphLayout : Object, Pool.Poolable
  {
    [Signature("Larc/struct/Seq<Larc/graphics/g2d/GlyphLayout$GlyphRun;>;")]
    internal Seq __\u003C\u003Eruns;
    [Modifiers]
    [Signature("Larc/struct/Seq<Larc/graphics/Color;>;")]
    private Seq colorStack;
    public float width;
    public float height;

    [LineNumberTable(new byte[] {159, 130, 170, 127, 53})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setText(Font font, CharSequence str)
    {
      object obj1 = (object) str.__\u003Cref\u003E;
      Font font1 = font;
      object obj2 = obj1;
      object obj3 = obj1;
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj3;
      int num1 = ((CharSequence) ref charSequence).length();
      Color color1 = font.getColor();
      string str1 = (string) null;
      bool flag = false;
      int num2 = 8;
      float num3 = 0.0f;
      Color color2 = color1;
      int num4 = num1;
      int num5 = 0;
      object obj4 = obj2;
      charSequence.__\u003Cref\u003E = (__Null) obj4;
      CharSequence str2 = charSequence;
      int start = num5;
      int end = num4;
      Color color3 = color2;
      double num6 = (double) num3;
      int halign = num2;
      int num7 = flag ? 1 : 0;
      string truncate = str1;
      this.setText(font1, str2, start, end, color3, (float) num6, halign, num7 != 0, truncate);
    }

    [LineNumberTable(new byte[] {159, 168, 232, 59, 107, 236, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public GlyphLayout()
    {
      GlyphLayout glyphLayout = this;
      this.__\u003C\u003Eruns = new Seq();
      this.colorStack = new Seq(4);
    }

    [LineNumberTable(new byte[] {159, 129, 173, 127, 47})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setText(
      Font font,
      CharSequence str,
      Color color,
      float targetWidth,
      int halign,
      bool wrap)
    {
      object obj1 = (object) str.__\u003Cref\u003E;
      int num1 = wrap ? 1 : 0;
      Font font1 = font;
      object obj2 = obj1;
      object obj3 = obj1;
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj3;
      int num2 = ((CharSequence) ref charSequence).length();
      Color color1 = color;
      double num3 = (double) targetWidth;
      int num4 = halign;
      int num5 = num1;
      string str1 = (string) null;
      bool flag = num5 != 0;
      int num6 = num4;
      float num7 = (float) num3;
      Color color2 = color1;
      int num8 = num2;
      int num9 = 0;
      object obj4 = obj2;
      charSequence.__\u003Cref\u003E = (__Null) obj4;
      CharSequence str2 = charSequence;
      int start = num9;
      int end = num8;
      Color color3 = color2;
      double num10 = (double) num7;
      int halign1 = num6;
      int num11 = flag ? 1 : 0;
      string truncate = str1;
      this.setText(font1, str2, start, end, color3, (float) num10, halign1, num11 != 0, truncate);
    }

    [LineNumberTable(new byte[] {159, 125, 173, 135, 100, 100, 114, 130, 136, 118, 104, 105, 136, 117, 102, 131, 104, 100, 105, 150, 195, 99, 99, 101, 107, 137, 191, 20, 101, 99, 165, 103, 127, 13, 101, 101, 104, 112, 102, 101, 229, 71, 136, 137, 110, 111, 127, 14, 110, 105, 133, 100, 125, 159, 5, 115, 105, 105, 115, 137, 110, 110, 99, 103, 105, 43, 136, 104, 105, 197, 106, 107, 106, 106, 115, 108, 119, 127, 3, 139, 107, 116, 165, 132, 114, 114, 197, 113, 159, 3, 166, 103, 100, 172, 116, 63, 4, 136, 101, 113, 143, 159, 22, 141, 119, 112, 101, 117, 114, 255, 1, 61, 232, 69, 112, 112, 105, 122, 133, 113, 122, 100, 103, 108, 102, 99, 133, 201, 110, 110, 102, 111, 113, 108, 102, 108, 105, 99, 100, 227, 159, 180, 235, 160, 80, 132, 108, 103, 104, 102, 108, 136, 102, 104, 163, 99, 132, 101, 140, 114, 53, 136, 168, 105, 108, 110, 108, 108, 112, 107, 105, 105, 111, 102, 127, 6, 135, 250, 54, 235, 76, 105, 111, 102, 191, 6, 104, 127, 15})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setText(
      Font font,
      CharSequence str,
      int start,
      int end,
      Color color,
      float targetWidth,
      int halign,
      bool wrap,
      string truncate)
    {
      object obj1 = (object) str.__\u003Cref\u003E;
      int num1 = wrap ? 1 : 0;
      Font.FontData data = font.data;
      if (truncate != null)
        num1 = 1;
      else if ((double) targetWidth <= (double) (data.spaceXadvance * 3f))
        num1 = 0;
      int num2 = data.markupEnabled ? 1 : 0;
      Pool pool1 = Pools.get((Class) ClassLiteral<GlyphLayout.GlyphRun>.Value, (Prov) new GlyphLayout.__\u003C\u003EAnon1());
      Seq runs = this.__\u003C\u003Eruns;
      pool1.freeAll(runs);
      runs.clear();
      float num3 = 0.0f;
      float num4 = 0.0f;
      float num5 = 0.0f;
      int num6 = 0;
      int num7 = 0;
      Font.Glyph glyph1 = (Font.Glyph) null;
      Seq colorStack = this.colorStack;
      Color color1 = color;
      colorStack.add((object) color);
      Pool pool2 = Pools.get((Class) ClassLiteral<Color>.Value, (Prov) new GlyphLayout.__\u003C\u003EAnon2());
      int num8 = start;
      while (true)
      {
        int num9;
        int num10;
        CharSequence charSequence;
        do
        {
          num9 = -1;
          num10 = 0;
          if (start == end)
          {
            if (num8 != end)
              num9 = end;
            else
              goto label_62;
          }
          else
          {
            object obj2 = obj1;
            int num11 = start;
            ++start;
            int num12 = num11;
            object obj3 = obj2;
            charSequence.__\u003Cref\u003E = (__Null) obj3;
            switch (((CharSequence) ref charSequence).charAt(num12))
            {
              case '\n':
                num9 = start - 1;
                num10 = 1;
                break;
              case '[':
                if (num2 != 0)
                {
                  object obj4 = obj1;
                  int num13 = start;
                  int num14 = end;
                  Pool pool3 = pool2;
                  int num15 = num14;
                  int num16 = num13;
                  object obj5 = obj4;
                  charSequence.__\u003Cref\u003E = (__Null) obj5;
                  int colorMarkup = this.parseColorMarkup(charSequence, num16, num15, pool3);
                  if (colorMarkup >= 0)
                  {
                    num9 = start - 1;
                    start += colorMarkup + 1;
                    color1 = (Color) colorStack.peek();
                    break;
                  }
                  if (colorMarkup == -2)
                  {
                    ++start;
                    continue;
                  }
                  break;
                }
                break;
            }
          }
        }
        while (num9 == -1);
        if (num9 != num8)
        {
          GlyphLayout.GlyphRun glyphRun1 = (GlyphLayout.GlyphRun) pool1.obtain();
          glyphRun1.__\u003C\u003Ecolor.set(color);
          Font.FontData fontData = data;
          GlyphLayout.GlyphRun run = glyphRun1;
          object obj2 = obj1;
          int num11 = num8;
          int num12 = num9;
          Font.Glyph glyph2 = glyph1;
          int num13 = num12;
          int num14 = num11;
          object obj3 = obj2;
          charSequence.__\u003Cref\u003E = (__Null) obj3;
          CharSequence str1 = charSequence;
          int start1 = num14;
          int end1 = num13;
          Font.Glyph lastGlyph = glyph2;
          fontData.getGlyphs(run, str1, start1, end1, lastGlyph);
          if (glyphRun1.glyphs.size == 0)
          {
            pool1.free((object) glyphRun1);
          }
          else
          {
            if (glyph1 != null)
              num3 -= !glyph1.fixedWidth ? (float) (glyph1.width + glyph1.xoffset) * data.scaleX - data.padRight : (float) glyph1.xadvance * data.scaleX;
            glyph1 = (Font.Glyph) glyphRun1.glyphs.peek();
            glyphRun1.x = num3;
            glyphRun1.y = num4;
            if (num10 != 0 || num9 == end)
              this.adjustLastGlyph(data, glyphRun1);
            runs.add((object) glyphRun1);
            float[] items = glyphRun1.xAdvances.items;
            int size1 = glyphRun1.xAdvances.size;
            if (num1 == 0)
            {
              float num15 = 0.0f;
              for (int index = 0; index < size1; ++index)
                num15 += items[index];
              num3 += num15;
              glyphRun1.width = num15;
            }
            else
            {
              num3 += items[0];
              glyphRun1.width = items[0];
              if (size1 >= 1)
              {
                num3 += items[1];
                glyphRun1.width += items[1];
                for (int start2 = 2; start2 < size1; ++start2)
                {
                  Font.Glyph glyph3 = (Font.Glyph) glyphRun1.glyphs.get(start2 - 1);
                  float num15 = (float) (glyph3.width + glyph3.xoffset) * data.scaleX - data.padRight;
                  if ((double) (num3 + num15) <= (double) targetWidth)
                  {
                    num3 += items[start2];
                    glyphRun1.width += items[start2];
                  }
                  else if (truncate != null)
                  {
                    this.truncate(data, glyphRun1, targetWidth, truncate, start2, pool1);
                    num3 = glyphRun1.x + glyphRun1.width;
                    goto label_62;
                  }
                  else
                  {
                    int num16 = data.getWrapIndex(glyphRun1.glyphs, start2);
                    if ((double) glyphRun1.x == 0.0 && num16 == 0 || num16 >= glyphRun1.glyphs.size)
                      num16 = start2 - 1;
                    GlyphLayout.GlyphRun glyphRun2;
                    if (num16 == 0)
                    {
                      glyphRun2 = glyphRun1;
                      glyphRun1.width = 0.0f;
                      int size2 = glyphRun1.glyphs.size;
                      while (num16 < size2 && data.isWhitespace((char) ((Font.Glyph) glyphRun1.glyphs.get(num16)).id))
                        ++num16;
                      if (num16 > 0)
                      {
                        glyphRun1.glyphs.removeRange(0, num16 - 1);
                        glyphRun1.xAdvances.removeRange(1, num16);
                      }
                      glyphRun1.xAdvances.set(0, (float) -((Font.Glyph) glyphRun1.glyphs.first()).xoffset * data.scaleX - data.padLeft);
                      if (runs.size > 1)
                      {
                        GlyphLayout.GlyphRun glyphRun3 = (GlyphLayout.GlyphRun) runs.get(runs.size - 2);
                        int index;
                        for (index = glyphRun3.glyphs.size - 1; index > 0; index += -1)
                        {
                          Font.Glyph glyph4 = (Font.Glyph) glyphRun3.glyphs.get(index);
                          if (data.isWhitespace((char) glyph4.id))
                            glyphRun3.width -= glyphRun3.xAdvances.get(index + 1);
                          else
                            break;
                        }
                        glyphRun3.glyphs.truncate(index + 1);
                        glyphRun3.xAdvances.truncate(index + 2);
                        this.adjustLastGlyph(data, glyphRun3);
                        num5 = Math.max(num5, glyphRun3.x + glyphRun3.width);
                      }
                    }
                    else
                    {
                      glyphRun2 = this.wrap(data, glyphRun1, pool1, num16, start2);
                      num5 = Math.max(num5, glyphRun1.x + glyphRun1.width);
                      if (glyphRun2 == null)
                      {
                        num3 = 0.0f;
                        num4 += data.down;
                        ++num6;
                        glyph1 = (Font.Glyph) null;
                        break;
                      }
                      runs.add((object) glyphRun2);
                    }
                    size1 = glyphRun2.xAdvances.size;
                    items = glyphRun2.xAdvances.items;
                    num3 = items[0];
                    if (size1 > 1)
                      num3 += items[1];
                    glyphRun2.width += num3;
                    num4 += data.down;
                    ++num6;
                    glyphRun2.x = 0.0f;
                    glyphRun2.y = num4;
                    start2 = 1;
                    glyphRun1 = glyphRun2;
                    glyph1 = (Font.Glyph) null;
                  }
                }
              }
            }
          }
        }
        if (num10 != 0)
        {
          num5 = Math.max(num5, num3);
          num3 = 0.0f;
          float down = data.down;
          if (num9 == num8)
          {
            down *= data.blankLineScale;
            ++num7;
          }
          else
            ++num6;
          num4 += down;
          glyph1 = (Font.Glyph) null;
        }
        num8 = start;
        color = color1;
      }
label_62:
      float num17 = Math.max(num5, num3);
      int index1 = 1;
      for (int size = colorStack.size; index1 < size; ++index1)
        pool2.free((object) (Color) colorStack.get(index1));
      colorStack.clear();
      if ((halign & 8) == 0)
      {
        int num9 = (halign & 1) == 0 ? 0 : 1;
        float num10 = 0.0f;
        float num11 = (float) int.MinValue;
        int num12 = 0;
        int size = runs.size;
        for (int index2 = 0; index2 < size; ++index2)
        {
          GlyphLayout.GlyphRun glyphRun = (GlyphLayout.GlyphRun) runs.get(index2);
          if ((double) glyphRun.y != (double) num11)
          {
            num11 = glyphRun.y;
            float num13 = targetWidth - num10;
            if (num9 != 0)
              num13 /= 2f;
            while (num12 < index2)
            {
              Seq seq = runs;
              int index3 = num12;
              ++num12;
              ((GlyphLayout.GlyphRun) seq.get(index3)).x += num13;
            }
            num10 = 0.0f;
          }
          num10 = Math.max(num10, glyphRun.x + glyphRun.width);
        }
        float num14 = targetWidth - num10;
        if (num9 != 0)
          num14 /= 2f;
        while (num12 < size)
        {
          Seq seq = runs;
          int index2 = num12;
          ++num12;
          ((GlyphLayout.GlyphRun) seq.get(index2)).x += num14;
        }
      }
      this.width = num17;
      this.height = data.capHeight - (float) num6 * data.down - (float) num7 * data.down * data.blankLineScale;
    }

    [LineNumberTable(43)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static GlyphLayout obtain() => (GlyphLayout) Pools.obtain((Class) ClassLiteral<GlyphLayout>.Value, (Prov) new GlyphLayout.__\u003C\u003EAnon0());

    [LineNumberTable(new byte[] {159, 189, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void free() => Pools.free((object) this);

    [Signature("(Ljava/lang/CharSequence;IILarc/util/pooling/Pool<Larc/graphics/Color;>;)I")]
    [LineNumberTable(new byte[] {159, 38, 74, 102, 191, 25, 99, 109, 119, 105, 119, 103, 114, 38, 136, 138, 110, 109, 106, 133, 108, 111, 108, 111, 108, 237, 45, 235, 87, 130, 131, 127, 6, 162, 109, 119, 107, 127, 27, 102, 110, 109, 106, 229, 56, 235, 74})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private int parseColorMarkup([In] CharSequence obj0, [In] int obj1, [In] int obj2, [In] Pool obj3)
    {
      object obj4 = (object) obj0.__\u003Cref\u003E;
      if (obj1 == obj2)
        return -1;
      object obj5 = obj4;
      int num1 = obj1;
      object obj6 = obj5;
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj6;
      switch (((CharSequence) ref charSequence).charAt(num1))
      {
        case '#':
          int num2 = 0;
          for (int index1 = obj1 + 1; index1 < obj2; ++index1)
          {
            object obj7 = obj4;
            int num3 = index1;
            object obj8 = obj7;
            charSequence.__\u003Cref\u003E = (__Null) obj8;
            int num4 = (int) ((CharSequence) ref charSequence).charAt(num3);
            if (num4 == 93)
            {
              if (index1 >= obj1 + 2 && index1 <= obj1 + 9)
              {
                if (index1 - obj1 <= 7)
                {
                  int num5 = 0;
                  for (int index2 = 9 - (index1 - obj1); num5 < index2; ++num5)
                    num2 <<= 4;
                  num2 |= (int) byte.MaxValue;
                }
                Color color = (Color) obj3.obtain();
                this.colorStack.add((object) color);
                color.rgba8888(num2);
                return index1 - obj1;
              }
              break;
            }
            if (num4 >= 48 && num4 <= 57)
              num2 = num2 * 16 + (num4 - 48);
            else if (num4 >= 97 && num4 <= 102)
              num2 = num2 * 16 + (num4 - 87);
            else if (num4 >= 65 && num4 <= 70)
              num2 = num2 * 16 + (num4 - 55);
            else
              break;
          }
          return -1;
        case '[':
          return -2;
        case ']':
          if (this.colorStack.size > 1)
            obj3.free((object) (Color) this.colorStack.pop());
          return 0;
        default:
          for (int index = obj1 + 1; index < obj2; ++index)
          {
            object obj7 = obj4;
            int num3 = index;
            object obj8 = obj7;
            charSequence.__\u003Cref\u003E = (__Null) obj8;
            if (((CharSequence) ref charSequence).charAt(num3) == ']')
            {
              object obj9 = obj4;
              int num4 = obj1;
              int num5 = index;
              int num6 = num4;
              object obj10 = obj9;
              charSequence.__\u003Cref\u003E = (__Null) obj10;
              object obj11 = (object) ((CharSequence) ref charSequence).subSequence(num6, num5).__\u003Cref\u003E;
              charSequence.__\u003Cref\u003E = (__Null) obj11;
              Color color1 = Colors.get(((CharSequence) ref charSequence).toString());
              if (color1 == null)
                return -1;
              Color color2 = (Color) obj3.obtain();
              this.colorStack.add((object) color2);
              color2.set(color1);
              return index - obj1;
            }
          }
          return -1;
      }
    }

    [LineNumberTable(new byte[] {161, 38, 113, 105, 127, 0, 125, 121})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void adjustLastGlyph([In] Font.FontData obj0, [In] GlyphLayout.GlyphRun obj1)
    {
      Font.Glyph glyph = (Font.Glyph) obj1.glyphs.peek();
      if (glyph.fixedWidth)
        return;
      float num = (float) (glyph.width + glyph.xoffset) * obj0.scaleX - obj0.padRight;
      obj1.width += num - obj1.xAdvances.peek();
      obj1.xAdvances.set(obj1.xAdvances.size - 1, num);
    }

    [Signature("(Larc/graphics/g2d/Font$FontData;Larc/graphics/g2d/GlyphLayout$GlyphRun;FLjava/lang/String;ILarc/util/pooling/Pool<Larc/graphics/g2d/GlyphLayout$GlyphRun;>;)V")]
    [LineNumberTable(new byte[] {160, 187, 109, 127, 11, 103, 110, 104, 118, 52, 168, 168, 99, 104, 111, 112, 104, 102, 116, 130, 102, 130, 133, 111, 109, 104, 113, 191, 2, 108, 107, 113, 159, 10, 114, 144, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void truncate(
      [In] Font.FontData obj0,
      [In] GlyphLayout.GlyphRun obj1,
      [In] float obj2,
      [In] string obj3,
      [In] int obj4,
      [In] Pool obj5)
    {
      GlyphLayout.GlyphRun glyphRun = (GlyphLayout.GlyphRun) obj5.obtain();
      Font.FontData fontData = obj0;
      GlyphLayout.GlyphRun run = glyphRun;
      string str1 = obj3;
      int num1 = String.instancehelper_length(obj3);
      Font.Glyph glyph = (Font.Glyph) null;
      int num2 = num1;
      int num3 = 0;
      object obj = (object) str1;
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj;
      CharSequence str2 = charSequence;
      int start = num3;
      int end = num2;
      Font.Glyph lastGlyph = glyph;
      fontData.getGlyphs(run, str2, start, end, lastGlyph);
      float num4 = 0.0f;
      if (glyphRun.xAdvances.size > 0)
      {
        this.adjustLastGlyph(obj0, glyphRun);
        int index = 1;
        for (int size = glyphRun.xAdvances.size; index < size; ++index)
          num4 += glyphRun.xAdvances.get(index);
      }
      obj2 -= num4;
      int num5 = 0;
      float x = obj1.x;
      for (; num5 < obj1.xAdvances.size; ++num5)
      {
        float num6 = obj1.xAdvances.get(num5);
        x += num6;
        if ((double) x > (double) obj2)
        {
          obj1.width = x - obj1.x - num6;
          break;
        }
      }
      if (num5 > 1)
      {
        obj1.glyphs.truncate(num5 - 1);
        obj1.xAdvances.truncate(num5);
        this.adjustLastGlyph(obj0, obj1);
        if (glyphRun.xAdvances.size > 0)
          obj1.xAdvances.addAll(glyphRun.xAdvances, 1, glyphRun.xAdvances.size - 1);
      }
      else
      {
        obj1.glyphs.clear();
        obj1.xAdvances.clear();
        obj1.xAdvances.addAll(glyphRun.xAdvances);
        if (glyphRun.xAdvances.size > 0)
          obj1.width += glyphRun.xAdvances.get(0);
      }
      obj1.glyphs.addAll(glyphRun.glyphs);
      obj1.width += num4;
      obj5.free((object) glyphRun);
    }

    [Signature("(Larc/graphics/g2d/Font$FontData;Larc/graphics/g2d/GlyphLayout$GlyphRun;Larc/util/pooling/Pool<Larc/graphics/g2d/GlyphLayout$GlyphRun;>;II)Larc/graphics/g2d/GlyphLayout$GlyphRun;")]
    [LineNumberTable(new byte[] {160, 235, 103, 108, 167, 99, 100, 62, 198, 100, 101, 61, 200, 101, 191, 0, 107, 223, 0, 99, 104, 109, 147, 105, 107, 107, 104, 136, 105, 108, 105, 127, 10, 104, 104, 130, 103, 169, 131, 103, 142, 136})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private GlyphLayout.GlyphRun wrap(
      [In] Font.FontData obj0,
      [In] GlyphLayout.GlyphRun obj1,
      [In] Pool obj2,
      [In] int obj3,
      [In] int obj4)
    {
      Seq glyphs1 = obj1.glyphs;
      int size = obj1.glyphs.size;
      FloatSeq xAdvances1 = obj1.xAdvances;
      int num1 = obj3;
      while (num1 > 0 && obj0.isWhitespace((char) ((Font.Glyph) glyphs1.get(num1 - 1)).id))
        num1 += -1;
      int num2 = obj3;
      while (num2 < size && obj0.isWhitespace((char) ((Font.Glyph) glyphs1.get(num2)).id))
        ++num2;
      while (obj4 < num1)
      {
        GlyphLayout.GlyphRun glyphRun = obj1;
        double width = (double) glyphRun.width;
        FloatSeq floatSeq = xAdvances1;
        int index = obj4;
        ++obj4;
        double num3 = (double) floatSeq.get(index);
        glyphRun.width = (float) (width + num3);
      }
      int num4 = num1 + 1;
      while (obj4 > num4)
      {
        GlyphLayout.GlyphRun glyphRun = obj1;
        double width = (double) glyphRun.width;
        FloatSeq floatSeq = xAdvances1;
        obj4 += -1;
        int index = obj4;
        double num3 = (double) floatSeq.get(index);
        glyphRun.width = (float) (width - num3);
      }
      GlyphLayout.GlyphRun glyphRun1 = (GlyphLayout.GlyphRun) null;
      if (num2 < size)
      {
        glyphRun1 = (GlyphLayout.GlyphRun) obj2.obtain();
        glyphRun1.__\u003C\u003Ecolor.set(obj1.__\u003C\u003Ecolor);
        Seq glyphs2 = glyphRun1.glyphs;
        glyphs2.addAll(glyphs1, 0, num1);
        glyphs1.removeRange(0, num2 - 1);
        obj1.glyphs = glyphs2;
        glyphRun1.glyphs = glyphs1;
        FloatSeq xAdvances2 = glyphRun1.xAdvances;
        xAdvances2.addAll(xAdvances1, 0, num1 + 1);
        xAdvances1.removeRange(1, num2);
        xAdvances1.set(0, (float) -((Font.Glyph) glyphs1.first()).xoffset * obj0.scaleX - obj0.padLeft);
        obj1.xAdvances = xAdvances2;
        glyphRun1.xAdvances = xAdvances1;
      }
      else
      {
        glyphs1.truncate(num1);
        xAdvances1.truncate(num1 + 1);
      }
      if (num1 == 0)
      {
        obj2.free((object) obj1);
        this.__\u003C\u003Eruns.pop();
      }
      else
        this.adjustLastGlyph(obj0, obj1);
      return glyphRun1;
    }

    [LineNumberTable(new byte[] {159, 135, 106, 232, 56, 107, 236, 72, 120})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public GlyphLayout(Font font, CharSequence str)
    {
      object obj1 = (object) str.__\u003Cref\u003E;
      // ISSUE: explicit constructor call
      base.\u002Ector();
      GlyphLayout glyphLayout = this;
      this.__\u003C\u003Eruns = new Seq();
      this.colorStack = new Seq(4);
      Font font1 = font;
      object obj2 = obj1;
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj2;
      CharSequence str1 = charSequence;
      this.setText(font1, str1);
    }

    [LineNumberTable(new byte[] {159, 134, 109, 232, 52, 107, 236, 76, 127, 18})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public GlyphLayout(
      Font font,
      CharSequence str,
      Color color,
      float targetWidth,
      int halign,
      bool wrap)
    {
      object obj1 = (object) str.__\u003Cref\u003E;
      int num1 = wrap ? 1 : 0;
      // ISSUE: explicit constructor call
      base.\u002Ector();
      GlyphLayout glyphLayout = this;
      this.__\u003C\u003Eruns = new Seq();
      this.colorStack = new Seq(4);
      Font font1 = font;
      object obj2 = obj1;
      Color color1 = color;
      double num2 = (double) targetWidth;
      int num3 = halign;
      bool flag = num1 != 0;
      int num4 = num3;
      float num5 = (float) num2;
      Color color2 = color1;
      object obj3 = obj2;
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj3;
      CharSequence str1 = charSequence;
      Color color3 = color2;
      double num6 = (double) num5;
      int halign1 = num4;
      int num7 = flag ? 1 : 0;
      this.setText(font1, str1, color3, (float) num6, halign1, num7 != 0);
    }

    [LineNumberTable(new byte[] {159, 133, 141, 232, 47, 107, 236, 81, 127, 36})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public GlyphLayout(
      Font font,
      CharSequence str,
      int start,
      int end,
      Color color,
      float targetWidth,
      int halign,
      bool wrap,
      string truncate)
    {
      object obj1 = (object) str.__\u003Cref\u003E;
      int num1 = wrap ? 1 : 0;
      // ISSUE: explicit constructor call
      base.\u002Ector();
      GlyphLayout glyphLayout = this;
      this.__\u003C\u003Eruns = new Seq();
      this.colorStack = new Seq(4);
      Font font1 = font;
      object obj2 = obj1;
      int num2 = start;
      int num3 = end;
      Color color1 = color;
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
      this.setText(font1, str2, start1, end1, color3, (float) num11, halign1, num12 != 0, truncate1);
    }

    [LineNumberTable(new byte[] {161, 96, 127, 0, 140, 107, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void reset()
    {
      Pools.get((Class) ClassLiteral<GlyphLayout.GlyphRun>.Value, (Prov) new GlyphLayout.__\u003C\u003EAnon1()).freeAll(this.__\u003C\u003Eruns);
      this.__\u003C\u003Eruns.clear();
      this.width = 0.0f;
      this.height = 0.0f;
    }

    [LineNumberTable(new byte[] {161, 104, 115, 107, 109, 105, 109, 105, 114, 125, 9, 198, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toString()
    {
      if (this.__\u003C\u003Eruns.size == 0)
        return "";
      StringBuilder stringBuilder = new StringBuilder(128);
      stringBuilder.append(this.width);
      stringBuilder.append('x');
      stringBuilder.append(this.height);
      stringBuilder.append('\n');
      int index = 0;
      for (int size = this.__\u003C\u003Eruns.size; index < size; ++index)
      {
        stringBuilder.append(((GlyphLayout.GlyphRun) this.__\u003C\u003Eruns.get(index)).toString());
        stringBuilder.append('\n');
      }
      stringBuilder.setLength(stringBuilder.length() - 1);
      return stringBuilder.toString();
    }

    [Modifiers]
    public Seq runs
    {
      [HideFromJava] get => this.__\u003C\u003Eruns;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Eruns = value;
    }

    public class GlyphRun : Object, Pool.Poolable
    {
      internal Color __\u003C\u003Ecolor;
      [Signature("Larc/struct/Seq<Larc/graphics/g2d/Font$Glyph;>;")]
      public Seq glyphs;
      public FloatSeq xAdvances;
      public float x;
      public float y;
      public float width;

      [LineNumberTable(new byte[] {161, 122, 104, 107, 235, 69})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public GlyphRun()
      {
        GlyphLayout.GlyphRun glyphRun = this;
        this.__\u003C\u003Ecolor = new Color();
        this.glyphs = new Seq();
        this.xAdvances = new FloatSeq();
      }

      [LineNumberTable(new byte[] {161, 133, 108, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void reset()
      {
        this.glyphs.clear();
        this.xAdvances.clear();
        this.width = 0.0f;
      }

      [LineNumberTable(new byte[] {161, 139, 113, 103, 109, 110, 15, 198, 108, 109, 108, 109, 108, 109, 108, 109})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual string toString()
      {
        StringBuilder stringBuilder = new StringBuilder(this.glyphs.size);
        Seq glyphs = this.glyphs;
        int index = 0;
        for (int size = glyphs.size; index < size; ++index)
        {
          Font.Glyph glyph = (Font.Glyph) glyphs.get(index);
          stringBuilder.append((char) glyph.id);
        }
        stringBuilder.append(", #");
        stringBuilder.append((object) this.__\u003C\u003Ecolor);
        stringBuilder.append(", ");
        stringBuilder.append(this.x);
        stringBuilder.append(", ");
        stringBuilder.append(this.y);
        stringBuilder.append(", ");
        stringBuilder.append(this.width);
        return stringBuilder.toString();
      }

      [Modifiers]
      public Color color
      {
        [HideFromJava] get => this.__\u003C\u003Ecolor;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Ecolor = value;
      }
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Prov
    {
      internal __\u003C\u003EAnon0()
      {
      }

      public object get() => (object) new GlyphLayout();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Prov
    {
      internal __\u003C\u003EAnon1()
      {
      }

      public object get() => (object) new GlyphLayout.GlyphRun();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon2 : Prov
    {
      internal __\u003C\u003EAnon2()
      {
      }

      public object get() => (object) new Color();
    }
  }
}
