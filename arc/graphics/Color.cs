// Decompiled with JetBrains decompiler
// Type: arc.graphics.Color
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.math;
using arc.math.geom;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.graphics
{
  public class Color : Object
  {
    internal static Color __\u003C\u003Ewhite;
    internal static Color __\u003C\u003ElightGray;
    internal static Color __\u003C\u003Egray;
    internal static Color __\u003C\u003EdarkGray;
    internal static Color __\u003C\u003Eblack;
    internal static Color __\u003C\u003Eclear;
    internal static float __\u003C\u003EwhiteFloatBits;
    internal static float __\u003C\u003EclearFloatBits;
    internal static float __\u003C\u003EblackFloatBits;
    internal static Color __\u003C\u003Eblue;
    internal static Color __\u003C\u003Enavy;
    internal static Color __\u003C\u003Eroyal;
    internal static Color __\u003C\u003Eslate;
    internal static Color __\u003C\u003Esky;
    internal static Color __\u003C\u003Ecyan;
    internal static Color __\u003C\u003Eteal;
    internal static Color __\u003C\u003Egreen;
    internal static Color __\u003C\u003Eacid;
    internal static Color __\u003C\u003Elime;
    internal static Color __\u003C\u003Eforest;
    internal static Color __\u003C\u003Eolive;
    internal static Color __\u003C\u003Eyellow;
    internal static Color __\u003C\u003Egold;
    internal static Color __\u003C\u003Egoldenrod;
    internal static Color __\u003C\u003Eorange;
    internal static Color __\u003C\u003Ebrown;
    internal static Color __\u003C\u003Etan;
    internal static Color __\u003C\u003Ebrick;
    internal static Color __\u003C\u003Ered;
    internal static Color __\u003C\u003Escarlet;
    internal static Color __\u003C\u003Ecrimson;
    internal static Color __\u003C\u003Ecoral;
    internal static Color __\u003C\u003Esalmon;
    internal static Color __\u003C\u003Epink;
    internal static Color __\u003C\u003Emagenta;
    internal static Color __\u003C\u003Epurple;
    internal static Color __\u003C\u003Eviolet;
    internal static Color __\u003C\u003Emaroon;
    [Modifiers]
    private static float[] tmpHSV;
    public float r;
    public float g;
    public float b;
    public float a;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {30, 104, 104, 104, 104, 105, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Color(float r, float g, float b, float a)
    {
      Color color = this;
      this.r = r;
      this.g = g;
      this.b = b;
      this.a = a;
      this.clamp();
    }

    [LineNumberTable(new byte[] {161, 88, 104, 104, 104, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Color set(float r, float g, float b, float a)
    {
      this.r = r;
      this.g = g;
      this.b = b;
      this.a = a;
      return this.clamp();
    }

    [LineNumberTable(new byte[] {160, 239, 108, 108, 108, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Color set(Color color)
    {
      this.r = color.r;
      this.g = color.g;
      this.b = color.b;
      this.a = color.a;
      return this;
    }

    [LineNumberTable(111)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Color valueOf(string hex) => Color.valueOf(new Color(), hex);

    [LineNumberTable(962)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Color cpy() => new Color(this);

    [LineNumberTable(484)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Color set(int rgba) => this.rgba8888(rgba);

    [LineNumberTable(new byte[] {15, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Color()
    {
    }

    [LineNumberTable(new byte[] {161, 13, 112, 112, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Color mul(float value)
    {
      this.r *= value;
      this.g *= value;
      this.b *= value;
      return this.clamp();
    }

    [LineNumberTable(345)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int rgba() => this.rgba8888();

    [LineNumberTable(new byte[] {161, 0, 116, 116, 116, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Color mul(Color color)
    {
      this.r *= color.r;
      this.g *= color.g;
      this.b *= color.b;
      this.a *= color.a;
      return this.clamp();
    }

    [LineNumberTable(340)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float diff(Color other) => Math.abs(this.hue() - other.hue()) / 360f + Math.abs(this.value() - other.value()) + Math.abs(this.saturation() - other.saturation());

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Color a(float a)
    {
      this.a = a;
      return this;
    }

    [LineNumberTable(new byte[] {161, 219, 112, 112, 112, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Color mul(float r, float g, float b, float a)
    {
      this.r *= r;
      this.g *= g;
      this.b *= b;
      this.a *= a;
      return this.clamp();
    }

    [LineNumberTable(new byte[] {161, 234, 127, 1, 127, 1, 127, 1, 127, 1})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Color lerp(Color target, float t)
    {
      this.r += t * (target.r - this.r);
      this.g += t * (target.g - this.g);
      this.b += t * (target.b - this.b);
      this.a += t * (target.a - this.a);
      return this.clamp();
    }

    [LineNumberTable(new byte[] {162, 45, 108, 114, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Color shiftValue(float amount)
    {
      this.toHsv(Color.tmpHSV);
      float[] tmpHsv = Color.tmpHSV;
      int index = 2;
      float[] numArray = tmpHsv;
      numArray[index] = numArray[index] + amount;
      this.fromHsv(Color.tmpHSV);
      return this;
    }

    [LineNumberTable(new byte[] {52, 104, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Color(Color color)
    {
      Color color1 = this;
      this.set(color);
    }

    [LineNumberTable(new byte[] {45, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Color(float r, float g, float b)
      : this(r, g, b, 1f)
    {
    }

    [LineNumberTable(300)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Color grays(float value) => new Color(value, value, value);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Color rgba8888(int value)
    {
      this.r = (float) (int) ((uint) (value & -16777216) >> 24) / (float) byte.MaxValue;
      this.g = (float) (int) ((uint) (value & 16711680) >> 16) / (float) byte.MaxValue;
      this.b = (float) (int) ((uint) (value & 65280) >> 8) / (float) byte.MaxValue;
      this.a = (float) (value & (int) byte.MaxValue) / (float) byte.MaxValue;
      return this;
    }

    [LineNumberTable(new byte[] {162, 88, 102, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toString()
    {
      StringBuilder builder = new StringBuilder();
      this.toString(builder);
      return builder.toString();
    }

    [LineNumberTable(new byte[] {162, 108, 120, 103, 102, 110, 114, 121, 159, 0, 104, 104, 103, 133, 104, 104, 103, 133, 103, 104, 104, 130, 103, 104, 104, 130, 104, 103, 104, 130, 104, 103, 168})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Color fromHsv(float h, float s, float v)
    {
      float num1 = (h / 60f + 6f) % 6f;
      int num2 = ByteCodeHelper.f2i(num1);
      float num3 = num1 - (float) num2;
      float num4 = v * (1f - s);
      float num5 = v * (1f - s * num3);
      float num6 = v * (1f - s * (1f - num3));
      switch (num2)
      {
        case 0:
          this.r = v;
          this.g = num6;
          this.b = num4;
          break;
        case 1:
          this.r = num5;
          this.g = v;
          this.b = num4;
          break;
        case 2:
          this.r = num4;
          this.g = v;
          this.b = num6;
          break;
        case 3:
          this.r = num4;
          this.g = num5;
          this.b = v;
          break;
        case 4:
          this.r = num6;
          this.g = num4;
          this.b = v;
          break;
        default:
          this.r = v;
          this.g = num4;
          this.b = num5;
          break;
      }
      return this.clamp();
    }

    [LineNumberTable(new byte[] {162, 53, 107, 120, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool equals(object o)
    {
      if (object.ReferenceEquals((object) this, o))
        return true;
      if (o == null || !object.ReferenceEquals((object) ((object) this).GetType(), (object) o.GetType()))
        return false;
      Color color = (Color) o;
      return this.toIntBits() == color.toIntBits();
    }

    [LineNumberTable(new byte[] {162, 198, 108, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Color HSVtoRGB(float h, float s, float v, float alpha)
    {
      Color color = Color.HSVtoRGB(h, s, v);
      color.a = alpha;
      return color;
    }

    [LineNumberTable(new byte[] {162, 74, 127, 53})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float toFloatBits() => Color.intToFloatColor(ByteCodeHelper.f2i((float) byte.MaxValue * this.a) << 24 | ByteCodeHelper.f2i((float) byte.MaxValue * this.b) << 16 | ByteCodeHelper.f2i((float) byte.MaxValue * this.g) << 8 | ByteCodeHelper.f2i((float) byte.MaxValue * this.r));

    [LineNumberTable(638)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Color write(Color to) => to.set(this);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int rgba8888(float r, float g, float b, float a) => ByteCodeHelper.f2i(r * (float) byte.MaxValue) << 24 | ByteCodeHelper.f2i(g * (float) byte.MaxValue) << 16 | ByteCodeHelper.f2i(b * (float) byte.MaxValue) << 8 | ByteCodeHelper.f2i(a * (float) byte.MaxValue);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int rgba8888() => ByteCodeHelper.f2i(this.r * (float) byte.MaxValue) << 24 | ByteCodeHelper.f2i(this.g * (float) byte.MaxValue) << 16 | ByteCodeHelper.f2i(this.b * (float) byte.MaxValue) << 8 | ByteCodeHelper.f2i(this.a * (float) byte.MaxValue);

    [LineNumberTable(new byte[] {19, 104, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Color(int rgba8888)
    {
      Color color = this;
      this.rgba8888(rgba8888);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Color r(float r)
    {
      this.r = r;
      return this;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Color g(float g)
    {
      this.g = g;
      return this;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Color b(float b)
    {
      this.b = b;
      return this;
    }

    [LineNumberTable(new byte[] {161, 161, 112, 112, 112, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Color sub(float r, float g, float b, float a)
    {
      this.r -= r;
      this.g -= g;
      this.b -= b;
      this.a -= a;
      return this.clamp();
    }

    [LineNumberTable(new byte[] {98, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static float toFloatBits(int r, int g, int b, int a) => Color.intToFloatColor(a << 24 | b << 16 | g << 8 | r);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Color clamp()
    {
      if ((double) this.r < 0.0)
        this.r = 0.0f;
      else if ((double) this.r > 1.0)
        this.r = 1f;
      if ((double) this.g < 0.0)
        this.g = 0.0f;
      else if ((double) this.g > 1.0)
        this.g = 1f;
      if ((double) this.b < 0.0)
        this.b = 0.0f;
      else if ((double) this.b > 1.0)
        this.b = 1f;
      if ((double) this.a < 0.0)
        this.a = 0.0f;
      else if ((double) this.a > 1.0)
        this.a = 1f;
      return this;
    }

    [LineNumberTable(new byte[] {69, 140, 107, 109, 109, 127, 1})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Color valueOf(Color color, string hex)
    {
      int num1 = String.instancehelper_charAt(hex, 0) == '#' ? 1 : 0;
      int hex1 = Color.parseHex(hex, num1, num1 + 2);
      int hex2 = Color.parseHex(hex, num1 + 2, num1 + 4);
      int hex3 = Color.parseHex(hex, num1 + 4, num1 + 6);
      int num2 = String.instancehelper_length(hex) - num1 == 8 ? Color.parseHex(hex, num1 + 6, num1 + 8) : (int) byte.MaxValue;
      return color.set((float) hex1 / (float) byte.MaxValue, (float) hex2 / (float) byte.MaxValue, (float) hex3 / (float) byte.MaxValue, (float) num2 / (float) byte.MaxValue);
    }

    [LineNumberTable(new byte[] {79, 98, 102, 104, 21, 198})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static int parseHex([In] string obj0, [In] int obj1, [In] int obj2)
    {
      int num1 = 0;
      for (int index = obj1; index < obj2; ++index)
      {
        int num2 = (int) String.instancehelper_charAt(obj0, index);
        num1 += Character.digit((char) num2, 16) * (index != obj1 ? 1 : 16);
      }
      return num1;
    }

    [LineNumberTable(325)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static float intToFloatColor(int value)
    {
      FloatConverter floatConverter;
      return FloatConverter.ToFloat(value & -16777217, ref floatConverter);
    }

    [LineNumberTable(new byte[] {160, 200, 106, 119})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int floatToIntColor(float value)
    {
      FloatConverter floatConverter;
      int num = FloatConverter.ToInt(value, ref floatConverter);
      return num | ByteCodeHelper.f2i((float) (int) ((uint) num >> 24) * 1.003937f) << 24;
    }

    [LineNumberTable(new byte[] {162, 16, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float hue()
    {
      this.toHsv(Color.tmpHSV);
      return Color.tmpHSV[0];
    }

    [LineNumberTable(new byte[] {162, 26, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float value()
    {
      this.toHsv(Color.tmpHSV);
      return Color.tmpHSV[2];
    }

    [LineNumberTable(new byte[] {162, 21, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float saturation()
    {
      this.toHsv(Color.tmpHSV);
      return Color.tmpHSV[1];
    }

    [LineNumberTable(new byte[] {161, 103, 104, 104, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Color set(float r, float g, float b)
    {
      this.r = r;
      this.g = g;
      this.b = b;
      return this.clamp();
    }

    [LineNumberTable(new byte[] {162, 165, 127, 0, 127, 0, 101, 104, 109, 105, 127, 12, 105, 159, 5, 191, 3, 104, 144, 168, 132})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float[] toHsv(float[] hsv)
    {
      float num1 = Math.max(Math.max(this.r, this.g), this.b);
      float num2 = Math.min(Math.min(this.r, this.g), this.b);
      float num3 = num1 - num2;
      hsv[0] = (double) num3 != 0.0 ? ((double) num1 != (double) this.r ? ((double) num1 != (double) this.g ? 60f * (this.r - this.g) / num3 + 240f : 60f * (this.b - this.r) / num3 + 120f) : (60f * (this.g - this.b) / num3 + 360f) % 360f) : 0.0f;
      hsv[1] = (double) num1 <= 0.0 ? 0.0f : 1f - num2 / num1;
      hsv[2] = num1;
      return hsv;
    }

    [LineNumberTable(782)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Color fromHsv(float[] hsv) => this.fromHsv(hsv[0], hsv[1], hsv[2]);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int toIntBits() => ByteCodeHelper.f2i((float) byte.MaxValue * this.a) << 24 | ByteCodeHelper.f2i((float) byte.MaxValue * this.b) << 16 | ByteCodeHelper.f2i((float) byte.MaxValue * this.g) << 8 | ByteCodeHelper.f2i((float) byte.MaxValue * this.r);

    [LineNumberTable(new byte[] {162, 94, 127, 64, 105, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void toString(StringBuilder builder)
    {
      builder.append(Integer.toHexString(ByteCodeHelper.f2i((float) byte.MaxValue * this.r) << 24 | ByteCodeHelper.f2i((float) byte.MaxValue * this.g) << 16 | ByteCodeHelper.f2i((float) byte.MaxValue * this.b) << 8 | ByteCodeHelper.f2i((float) byte.MaxValue * this.a)));
      while (builder.length() < 8)
        builder.insert(0, "0");
    }

    [LineNumberTable(new byte[] {162, 211, 122, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Color HSVtoRGB(float h, float s, float v)
    {
      Color targetColor = new Color(1f, 1f, 1f, 1f);
      Color.HSVtoRGB(h, s, v, targetColor);
      return targetColor;
    }

    [LineNumberTable(new byte[] {162, 226, 208, 127, 1, 127, 1, 127, 1, 107, 107, 107, 104, 103, 110, 113, 121, 159, 0, 100, 100, 99, 133, 99, 100, 99, 130, 99, 100, 100, 130, 99, 99, 100, 130, 100, 99, 100, 130, 100, 99, 163, 115})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Color HSVtoRGB(float h, float s, float v, Color targetColor)
    {
      if ((double) h == 360.0)
        h = 359f;
      h = (float) Math.max(0.0, Math.min(360.0, (double) h));
      s = (float) Math.max(0.0, Math.min(100.0, (double) s));
      v = (float) Math.max(0.0, Math.min(100.0, (double) v));
      s /= 100f;
      v /= 100f;
      h /= 60f;
      int num1 = Mathf.floor(h);
      float num2 = h - (float) num1;
      float num3 = v * (1f - s);
      float num4 = v * (1f - s * num2);
      float num5 = v * (1f - s * (1f - num2));
      float r;
      float g;
      float b;
      switch (num1)
      {
        case 0:
          r = v;
          g = num5;
          b = num3;
          break;
        case 1:
          r = num4;
          g = v;
          b = num3;
          break;
        case 2:
          r = num3;
          g = v;
          b = num5;
          break;
        case 3:
          r = num3;
          g = num4;
          b = v;
          break;
        case 4:
          r = num5;
          g = num3;
          b = v;
          break;
        default:
          r = v;
          g = num3;
          b = num4;
          break;
      }
      targetColor.set(r, g, b, targetColor.a);
      return targetColor;
    }

    [LineNumberTable(new byte[] {163, 42, 115, 115, 130, 133, 104, 136, 103, 103, 191, 5, 104, 169, 101, 109, 101, 148, 178, 107, 105, 139, 107, 137})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int[] RGBtoHSV(float r, float g, float b)
    {
      float num1 = Math.min(Math.min(r, g), b);
      float num2 = Math.max(Math.max(r, g), b);
      float num3 = num2;
      float num4 = num2 - num1;
      if ((double) num2 != 0.0)
      {
        float num5 = num4 / num2;
        float num6 = ((double) num4 != 0.0 ? ((double) r != (double) num2 ? ((double) g != (double) num2 ? 4f + (r - g) / num4 : 2f + (b - r) / num4) : (g - b) / num4) : 0.0f) * 60f;
        if ((double) num6 < 0.0)
          num6 += 360f;
        float num7 = num5 * 100f;
        float num8 = num3 * 100f;
        return new int[3]
        {
          Mathf.round(num6),
          Mathf.round(num7),
          Mathf.round(num8)
        };
      }
      float num9 = 0.0f;
      return new int[3]
      {
        Mathf.round(0.0f),
        Mathf.round(num9),
        Mathf.round(num3)
      };
    }

    [LineNumberTable(new byte[] {108, 127, 37})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static float toFloatBits(float r, float g, float b, float a) => Color.intToFloatColor(ByteCodeHelper.f2i((float) byte.MaxValue * a) << 24 | ByteCodeHelper.f2i((float) byte.MaxValue * b) << 16 | ByteCodeHelper.f2i((float) byte.MaxValue * g) << 8 | ByteCodeHelper.f2i((float) byte.MaxValue * r));

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int toIntBits(int r, int g, int b, int a) => a << 24 | b << 16 | g << 8 | r;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int alpha(float alpha) => ByteCodeHelper.f2i(alpha * (float) byte.MaxValue);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int luminanceAlpha(float luminance, float alpha) => ByteCodeHelper.f2i(luminance * (float) byte.MaxValue) << 8 | ByteCodeHelper.f2i(alpha * (float) byte.MaxValue);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int rgb565(float r, float g, float b) => ByteCodeHelper.f2i(r * 31f) << 11 | ByteCodeHelper.f2i(g * 63f) << 5 | ByteCodeHelper.f2i(b * 31f);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int rgba4444(float r, float g, float b, float a) => ByteCodeHelper.f2i(r * 15f) << 12 | ByteCodeHelper.f2i(g * 15f) << 8 | ByteCodeHelper.f2i(b * 15f) << 4 | ByteCodeHelper.f2i(a * 15f);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int rgb888(float r, float g, float b) => ByteCodeHelper.f2i(r * (float) byte.MaxValue) << 16 | ByteCodeHelper.f2i(g * (float) byte.MaxValue) << 8 | ByteCodeHelper.f2i(b * (float) byte.MaxValue);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int argb8888(float a, float r, float g, float b) => ByteCodeHelper.f2i(a * (float) byte.MaxValue) << 24 | ByteCodeHelper.f2i(r * (float) byte.MaxValue) << 16 | ByteCodeHelper.f2i(g * (float) byte.MaxValue) << 8 | ByteCodeHelper.f2i(b * (float) byte.MaxValue);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int rgb565() => ByteCodeHelper.f2i(this.r * 31f) << 11 | ByteCodeHelper.f2i(this.g * 63f) << 5 | ByteCodeHelper.f2i(this.b * 31f);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int rgba4444() => ByteCodeHelper.f2i(this.r * 15f) << 12 | ByteCodeHelper.f2i(this.g * 15f) << 8 | ByteCodeHelper.f2i(this.b * 15f) << 4 | ByteCodeHelper.f2i(this.a * 15f);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int rgb888() => ByteCodeHelper.f2i(this.r * (float) byte.MaxValue) << 16 | ByteCodeHelper.f2i(this.g * (float) byte.MaxValue) << 8 | ByteCodeHelper.f2i(this.b * (float) byte.MaxValue);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int argb8888() => ByteCodeHelper.f2i(this.a * (float) byte.MaxValue) << 24 | ByteCodeHelper.f2i(this.r * (float) byte.MaxValue) << 16 | ByteCodeHelper.f2i(this.g * (float) byte.MaxValue) << 8 | ByteCodeHelper.f2i(this.b * (float) byte.MaxValue);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Color rgb565(int value)
    {
      this.r = (float) (int) ((uint) (value & 63488) >> 11) / 31f;
      this.g = (float) (int) ((uint) (value & 2016) >> 5) / 63f;
      this.b = (float) (value & 31) / 31f;
      return this;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Color rgba4444(int value)
    {
      this.r = (float) (int) ((uint) (value & 61440) >> 12) / 15f;
      this.g = (float) (int) ((uint) (value & 3840) >> 8) / 15f;
      this.b = (float) (int) ((uint) (value & 240) >> 4) / 15f;
      this.a = (float) (value & 15) / 15f;
      return this;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Color rgb888(int value)
    {
      this.r = (float) (int) ((uint) (value & 16711680) >> 16) / (float) byte.MaxValue;
      this.g = (float) (int) ((uint) (value & 65280) >> 8) / (float) byte.MaxValue;
      this.b = (float) (value & (int) byte.MaxValue) / (float) byte.MaxValue;
      return this;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Color argb8888(int value)
    {
      this.a = (float) (int) ((uint) (value & -16777216) >> 24) / (float) byte.MaxValue;
      this.r = (float) (int) ((uint) (value & 16711680) >> 16) / (float) byte.MaxValue;
      this.g = (float) (int) ((uint) (value & 65280) >> 8) / (float) byte.MaxValue;
      this.b = (float) (value & (int) byte.MaxValue) / (float) byte.MaxValue;
      return this;
    }

    [LineNumberTable(new byte[] {160, 176, 104, 120, 120, 119, 117})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Color abgr8888(float value)
    {
      int intColor = Color.floatToIntColor(value);
      this.a = (float) (int) ((uint) (intColor & -16777216) >> 24) / (float) byte.MaxValue;
      this.b = (float) (int) ((uint) (intColor & 16711680) >> 16) / (float) byte.MaxValue;
      this.g = (float) (int) ((uint) (intColor & 65280) >> 8) / (float) byte.MaxValue;
      this.r = (float) (intColor & (int) byte.MaxValue) / (float) byte.MaxValue;
      return this;
    }

    [LineNumberTable(305)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Color rgb(int r, int g, int b) => new Color((float) r / (float) byte.MaxValue, (float) g / (float) byte.MaxValue, (float) b / (float) byte.MaxValue);

    [LineNumberTable(329)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Color rand() => this.set(Mathf.random(), Mathf.random(), Mathf.random(), 1f);

    [LineNumberTable(new byte[] {160, 219, 124, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Color randHue()
    {
      this.fromHsv(Mathf.random(360f), 1f, 1f);
      this.a = 1f;
      return this;
    }

    [LineNumberTable(361)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Color set(Vec3 vec) => this.set(vec.x, vec.y, vec.z);

    [LineNumberTable(new byte[] {161, 25, 112, 112, 112, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Color mula(float value)
    {
      this.r *= value;
      this.g *= value;
      this.b *= value;
      this.a *= value;
      return this.clamp();
    }

    [LineNumberTable(new byte[] {161, 38, 116, 116, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Color add(Color color)
    {
      this.r += color.r;
      this.g += color.g;
      this.b += color.b;
      return this.clamp();
    }

    [LineNumberTable(new byte[] {161, 50, 116, 116, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Color sub(Color color)
    {
      this.r -= color.r;
      this.g -= color.g;
      this.b -= color.b;
      return this.clamp();
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float sum() => this.r + this.g + this.b;

    [LineNumberTable(new byte[] {161, 131, 112, 112, 112, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Color add(float r, float g, float b, float a)
    {
      this.r += r;
      this.g += g;
      this.b += b;
      this.a += a;
      return this.clamp();
    }

    [LineNumberTable(new byte[] {161, 146, 112, 112, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Color add(float r, float g, float b)
    {
      this.r += r;
      this.g += g;
      this.b += b;
      return this.clamp();
    }

    [LineNumberTable(new byte[] {161, 176, 112, 112, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Color sub(float r, float g, float b)
    {
      this.r -= r;
      this.g -= g;
      this.b -= b;
      return this.clamp();
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Color inv()
    {
      this.r = 1f - this.r;
      this.g = 1f - this.g;
      this.b = 1f - this.b;
      return this;
    }

    [LineNumberTable(new byte[] {161, 252, 125, 125, 125, 126})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Color lerp(float r, float g, float b, float a, float t)
    {
      this.r += t * (r - this.r);
      this.g += t * (g - this.g);
      this.b += t * (b - this.b);
      this.a += t * (a - this.a);
      return this.clamp();
    }

    [LineNumberTable(new byte[] {162, 5, 116, 116, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Color premultiplyAlpha()
    {
      this.r *= this.a;
      this.g *= this.a;
      this.b *= this.a;
      return this;
    }

    [LineNumberTable(new byte[] {162, 31, 108, 114, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Color shiftHue(float amount)
    {
      this.toHsv(Color.tmpHSV);
      float[] tmpHsv = Color.tmpHSV;
      int index = 0;
      float[] numArray = tmpHsv;
      numArray[index] = numArray[index] + amount;
      this.fromHsv(Color.tmpHSV);
      return this;
    }

    [LineNumberTable(new byte[] {162, 38, 108, 114, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Color shiftSaturation(float amount)
    {
      this.toHsv(Color.tmpHSV);
      float[] tmpHsv = Color.tmpHSV;
      int index = 1;
      float[] numArray = tmpHsv;
      numArray[index] = numArray[index] + amount;
      this.fromHsv(Color.tmpHSV);
      return this;
    }

    [LineNumberTable(new byte[] {162, 61, 124, 127, 2, 127, 2, 127, 2})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int hashCode() => 31 * (31 * (31 * ((double) this.r == 0.0 ? 0 : Float.floatToIntBits(this.r)) + ((double) this.g == 0.0 ? 0 : Float.floatToIntBits(this.g))) + ((double) this.b == 0.0 ? 0 : Float.floatToIntBits(this.b))) + ((double) this.a == 0.0 ? 0 : Float.floatToIntBits(this.a));

    [LineNumberTable(909)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int[] RGBtoHSV(Color c) => Color.RGBtoHSV(c.r, c.g, c.b);

    [LineNumberTable(new byte[] {163, 84, 99, 112, 159, 1, 121, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Color lerp(Color[] colors, float s)
    {
      int length = colors.Length;
      Color color1 = colors[ByteCodeHelper.f2i(s * (float) (length - 1))];
      Color color2 = colors[Mathf.clamp(ByteCodeHelper.f2i(s * (float) (length - 1) + 1f), 0, length - 1)];
      float num1 = s * (float) (length - 1) - (float) ByteCodeHelper.f2i(s * (float) (length - 1));
      float num2 = 1f - num1;
      return this.set(color1.r * num2 + color2.r * num1, color1.g * num2 + color2.g * num1, color1.b * num2 + color2.b * num1, 1f);
    }

    [LineNumberTable(new byte[] {159, 139, 77, 126, 111, 111, 111, 126, 190, 112, 112, 144, 126, 126, 111, 111, 111, 126, 158, 111, 111, 111, 111, 143, 111, 111, 111, 143, 111, 111, 143, 111, 111, 111, 111, 111, 111, 158, 111, 111, 143})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static Color()
    {
      if (ByteCodeHelper.isAlreadyInited("arc.graphics.Color"))
        return;
      Color.__\u003C\u003Ewhite = new Color(1f, 1f, 1f, 1f);
      Color.__\u003C\u003ElightGray = new Color(-1077952513);
      Color.__\u003C\u003Egray = new Color(2139062271);
      Color.__\u003C\u003EdarkGray = new Color(1061109759);
      Color.__\u003C\u003Eblack = new Color(0.0f, 0.0f, 0.0f, 1f);
      Color.__\u003C\u003Eclear = new Color(0.0f, 0.0f, 0.0f, 0.0f);
      Color.__\u003C\u003EwhiteFloatBits = Color.__\u003C\u003Ewhite.toFloatBits();
      Color.__\u003C\u003EclearFloatBits = Color.__\u003C\u003Eclear.toFloatBits();
      Color.__\u003C\u003EblackFloatBits = Color.__\u003C\u003Eblack.toFloatBits();
      Color.__\u003C\u003Eblue = new Color(0.0f, 0.0f, 1f, 1f);
      Color.__\u003C\u003Enavy = new Color(0.0f, 0.0f, 0.5f, 1f);
      Color.__\u003C\u003Eroyal = new Color(1097458175);
      Color.__\u003C\u003Eslate = new Color(1887473919);
      Color.__\u003C\u003Esky = new Color(-2016482305);
      Color.__\u003C\u003Ecyan = new Color(0.0f, 1f, 1f, 1f);
      Color.__\u003C\u003Eteal = new Color(0.0f, 0.5f, 0.5f, 1f);
      Color.__\u003C\u003Egreen = new Color(16711935);
      Color.__\u003C\u003Eacid = new Color(2147418367);
      Color.__\u003C\u003Elime = new Color(852308735);
      Color.__\u003C\u003Eforest = new Color(579543807);
      Color.__\u003C\u003Eolive = new Color(1804477439);
      Color.__\u003C\u003Eyellow = new Color(-65281);
      Color.__\u003C\u003Egold = new Color(-2686721);
      Color.__\u003C\u003Egoldenrod = new Color(-626712321);
      Color.__\u003C\u003Eorange = new Color(-5963521);
      Color.__\u003C\u003Ebrown = new Color(-1958407169);
      Color.__\u003C\u003Etan = new Color(-759919361);
      Color.__\u003C\u003Ebrick = new Color(-1306385665);
      Color.__\u003C\u003Ered = new Color(-16776961);
      Color.__\u003C\u003Escarlet = new Color(-13361921);
      Color.__\u003C\u003Ecrimson = new Color(-602653441);
      Color.__\u003C\u003Ecoral = new Color(-8433409);
      Color.__\u003C\u003Esalmon = new Color(-92245249);
      Color.__\u003C\u003Epink = new Color(-9849601);
      Color.__\u003C\u003Emagenta = new Color(1f, 0.0f, 1f, 1f);
      Color.__\u003C\u003Epurple = new Color(-1608453889);
      Color.__\u003C\u003Eviolet = new Color(-293409025);
      Color.__\u003C\u003Emaroon = new Color(-1339006721);
      Color.tmpHSV = new float[3];
    }

    [Modifiers]
    public static Color white
    {
      [HideFromJava] get => Color.__\u003C\u003Ewhite;
    }

    [Modifiers]
    public static Color lightGray
    {
      [HideFromJava] get => Color.__\u003C\u003ElightGray;
    }

    [Modifiers]
    public static Color gray
    {
      [HideFromJava] get => Color.__\u003C\u003Egray;
    }

    [Modifiers]
    public static Color darkGray
    {
      [HideFromJava] get => Color.__\u003C\u003EdarkGray;
    }

    [Modifiers]
    public static Color black
    {
      [HideFromJava] get => Color.__\u003C\u003Eblack;
    }

    [Modifiers]
    public static Color clear
    {
      [HideFromJava] get => Color.__\u003C\u003Eclear;
    }

    [Modifiers]
    public static float whiteFloatBits
    {
      [HideFromJava] get => Color.__\u003C\u003EwhiteFloatBits;
    }

    [Modifiers]
    public static float clearFloatBits
    {
      [HideFromJava] get => Color.__\u003C\u003EclearFloatBits;
    }

    [Modifiers]
    public static float blackFloatBits
    {
      [HideFromJava] get => Color.__\u003C\u003EblackFloatBits;
    }

    [Modifiers]
    public static Color blue
    {
      [HideFromJava] get => Color.__\u003C\u003Eblue;
    }

    [Modifiers]
    public static Color navy
    {
      [HideFromJava] get => Color.__\u003C\u003Enavy;
    }

    [Modifiers]
    public static Color royal
    {
      [HideFromJava] get => Color.__\u003C\u003Eroyal;
    }

    [Modifiers]
    public static Color slate
    {
      [HideFromJava] get => Color.__\u003C\u003Eslate;
    }

    [Modifiers]
    public static Color sky
    {
      [HideFromJava] get => Color.__\u003C\u003Esky;
    }

    [Modifiers]
    public static Color cyan
    {
      [HideFromJava] get => Color.__\u003C\u003Ecyan;
    }

    [Modifiers]
    public static Color teal
    {
      [HideFromJava] get => Color.__\u003C\u003Eteal;
    }

    [Modifiers]
    public static Color green
    {
      [HideFromJava] get => Color.__\u003C\u003Egreen;
    }

    [Modifiers]
    public static Color acid
    {
      [HideFromJava] get => Color.__\u003C\u003Eacid;
    }

    [Modifiers]
    public static Color lime
    {
      [HideFromJava] get => Color.__\u003C\u003Elime;
    }

    [Modifiers]
    public static Color forest
    {
      [HideFromJava] get => Color.__\u003C\u003Eforest;
    }

    [Modifiers]
    public static Color olive
    {
      [HideFromJava] get => Color.__\u003C\u003Eolive;
    }

    [Modifiers]
    public static Color yellow
    {
      [HideFromJava] get => Color.__\u003C\u003Eyellow;
    }

    [Modifiers]
    public static Color gold
    {
      [HideFromJava] get => Color.__\u003C\u003Egold;
    }

    [Modifiers]
    public static Color goldenrod
    {
      [HideFromJava] get => Color.__\u003C\u003Egoldenrod;
    }

    [Modifiers]
    public static Color orange
    {
      [HideFromJava] get => Color.__\u003C\u003Eorange;
    }

    [Modifiers]
    public static Color brown
    {
      [HideFromJava] get => Color.__\u003C\u003Ebrown;
    }

    [Modifiers]
    public static Color tan
    {
      [HideFromJava] get => Color.__\u003C\u003Etan;
    }

    [Modifiers]
    public static Color brick
    {
      [HideFromJava] get => Color.__\u003C\u003Ebrick;
    }

    [Modifiers]
    public static Color red
    {
      [HideFromJava] get => Color.__\u003C\u003Ered;
    }

    [Modifiers]
    public static Color scarlet
    {
      [HideFromJava] get => Color.__\u003C\u003Escarlet;
    }

    [Modifiers]
    public static Color crimson
    {
      [HideFromJava] get => Color.__\u003C\u003Ecrimson;
    }

    [Modifiers]
    public static Color coral
    {
      [HideFromJava] get => Color.__\u003C\u003Ecoral;
    }

    [Modifiers]
    public static Color salmon
    {
      [HideFromJava] get => Color.__\u003C\u003Esalmon;
    }

    [Modifiers]
    public static Color pink
    {
      [HideFromJava] get => Color.__\u003C\u003Epink;
    }

    [Modifiers]
    public static Color magenta
    {
      [HideFromJava] get => Color.__\u003C\u003Emagenta;
    }

    [Modifiers]
    public static Color purple
    {
      [HideFromJava] get => Color.__\u003C\u003Epurple;
    }

    [Modifiers]
    public static Color violet
    {
      [HideFromJava] get => Color.__\u003C\u003Eviolet;
    }

    [Modifiers]
    public static Color maroon
    {
      [HideFromJava] get => Color.__\u003C\u003Emaroon;
    }
  }
}
