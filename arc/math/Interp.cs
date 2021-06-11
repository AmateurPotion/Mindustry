// Decompiled with JetBrains decompiler
// Type: arc.math.Interp
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.math
{
  public interface Interp
  {
    static readonly Interp linear;
    static readonly Interp smooth;
    static readonly Interp smooth2;
    static readonly Interp smoother;
    static readonly Interp fade;
    static readonly Interp.Pow pow2;
    static readonly Interp.PowIn pow2In;
    static readonly Interp.PowIn slowFast;
    static readonly Interp.PowOut pow2Out;
    static readonly Interp.PowOut fastSlow;
    static readonly Interp pow2InInverse;
    static readonly Interp pow2OutInverse;
    static readonly Interp.Pow pow3;
    static readonly Interp.PowIn pow3In;
    static readonly Interp.PowOut pow3Out;
    static readonly Interp pow3InInverse;
    static readonly Interp pow3OutInverse;
    static readonly Interp.Pow pow4;
    static readonly Interp.PowIn pow4In;
    static readonly Interp.PowOut pow4Out;
    static readonly Interp.Pow pow5;
    static readonly Interp.PowIn pow5In;
    static readonly Interp.PowIn pow10In;
    static readonly Interp.PowOut pow5Out;
    static readonly Interp sine;
    static readonly Interp sineIn;
    static readonly Interp sineOut;
    static readonly Interp.Exp exp10;
    static readonly Interp.ExpIn exp10In;
    static readonly Interp.ExpOut exp10Out;
    static readonly Interp.Exp exp5;
    static readonly Interp.ExpIn exp5In;
    static readonly Interp.ExpOut exp5Out;
    static readonly Interp circle;
    static readonly Interp circleIn;
    static readonly Interp circleOut;
    static readonly Interp.Elastic elastic;
    static readonly Interp.ElasticIn elasticIn;
    static readonly Interp.ElasticOut elasticOut;
    static readonly Interp.Swing swing;
    static readonly Interp.SwingIn swingIn;
    static readonly Interp.SwingOut swingOut;
    static readonly Interp.Bounce bounce;
    static readonly Interp.BounceIn bounceIn;
    static readonly Interp.BounceOut bounceOut;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static void __\u003Cclinit\u003E()
    {
    }

    [Modifiers]
    float apply(float start, float end, float a);

    [LineNumberTable(81)]
    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static float \u003Cdefault\u003Eapply([In] Interp obj0, [In] float obj1, [In] float obj2, [In] float obj3) => obj1 + (obj2 - obj1) * obj0.apply(obj3);

    float apply(float f);

    [LineNumberTable(new byte[] {159, 140, 77, 143, 175, 239, 71, 111, 106, 139, 107, 138, 107, 106, 111, 111, 107, 107, 107, 111, 111, 107, 107, 107, 107, 107, 108, 107, 111, 111, 111, 116, 116, 116, 116, 116, 116, 239, 73, 111, 207, 122, 122, 122, 111, 111, 111, 107, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static Interp()
    {
      if (ByteCodeHelper.isAlreadyInited("arc.math.Interp"))
        return;
      Interp.linear = (Interp) new Interp.__\u003C\u003EAnon1();
      Interp.smooth = (Interp) new Interp.__\u003C\u003EAnon2();
      Interp.smooth2 = (Interp) new Interp.__\u003C\u003EAnon3();
      Interp.smoother = (Interp) new Interp.__\u003C\u003EAnon4();
      Interp.fade = Interp.smoother;
      Interp.pow2 = new Interp.Pow(2);
      Interp.pow2In = new Interp.PowIn(2);
      Interp.slowFast = Interp.pow2In;
      Interp.pow2Out = new Interp.PowOut(2);
      Interp.fastSlow = Interp.pow2Out;
      Interp.pow2InInverse = (Interp) new Interp.__\u003C\u003EAnon5();
      Interp.pow2OutInverse = (Interp) new Interp.__\u003C\u003EAnon6();
      Interp.pow3 = new Interp.Pow(3);
      Interp.pow3In = new Interp.PowIn(3);
      Interp.pow3Out = new Interp.PowOut(3);
      Interp.pow3InInverse = (Interp) new Interp.__\u003C\u003EAnon7();
      Interp.pow3OutInverse = (Interp) new Interp.__\u003C\u003EAnon8();
      Interp.pow4 = new Interp.Pow(4);
      Interp.pow4In = new Interp.PowIn(4);
      Interp.pow4Out = new Interp.PowOut(4);
      Interp.pow5 = new Interp.Pow(5);
      Interp.pow5In = new Interp.PowIn(5);
      Interp.pow10In = new Interp.PowIn(10);
      Interp.pow5Out = new Interp.PowOut(5);
      Interp.sine = (Interp) new Interp.__\u003C\u003EAnon9();
      Interp.sineIn = (Interp) new Interp.__\u003C\u003EAnon10();
      Interp.sineOut = (Interp) new Interp.__\u003C\u003EAnon11();
      Interp.exp10 = new Interp.Exp(2f, 10f);
      Interp.exp10In = new Interp.ExpIn(2f, 10f);
      Interp.exp10Out = new Interp.ExpOut(2f, 10f);
      Interp.exp5 = new Interp.Exp(2f, 5f);
      Interp.exp5In = new Interp.ExpIn(2f, 5f);
      Interp.exp5Out = new Interp.ExpOut(2f, 5f);
      Interp.circle = (Interp) new Interp.__\u003C\u003EAnon12();
      Interp.circleIn = (Interp) new Interp.__\u003C\u003EAnon13();
      Interp.circleOut = (Interp) new Interp.__\u003C\u003EAnon14();
      Interp.elastic = new Interp.Elastic(2f, 10f, 7, 1f);
      Interp.elasticIn = new Interp.ElasticIn(2f, 10f, 6, 1f);
      Interp.elasticOut = new Interp.ElasticOut(2f, 10f, 7, 1f);
      Interp.swing = new Interp.Swing(1.5f);
      Interp.swingIn = new Interp.SwingIn(2f);
      Interp.swingOut = new Interp.SwingOut(2f);
      Interp.bounce = new Interp.Bounce(4);
      Interp.bounceIn = new Interp.BounceIn(4);
      Interp.bounceOut = new Interp.BounceOut(4);
    }

    class Bounce : Interp.BounceOut
    {
      [LineNumberTable(new byte[] {160, 100, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public Bounce(int bounces)
        : base(bounces)
      {
      }

      [LineNumberTable(new byte[] {160, 104, 116, 127, 6})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private float @out([In] float obj0)
      {
        float num = obj0 + this.widths[0] / 2f;
        return (double) num < (double) this.widths[0] ? num / (this.widths[0] / 2f) - 1f : base.apply(obj0);
      }

      [LineNumberTable(new byte[] {160, 96, 104})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public Bounce(float[] widths, float[] heights)
        : base(widths, heights)
      {
      }

      [LineNumberTable(new byte[] {160, 111, 127, 16})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override float apply(float a) => (double) a <= 0.5 ? (1f - this.@out(1f - a * 2f)) / 2f : this.@out(a * 2f - 1f) / 2f + 0.5f;
    }

    class BounceIn : Interp.BounceOut
    {
      [LineNumberTable(new byte[] {160, 194, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public BounceIn(int bounces)
        : base(bounces)
      {
      }

      [LineNumberTable(new byte[] {160, 190, 104})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public BounceIn(float[] widths, float[] heights)
        : base(widths, heights)
      {
      }

      [LineNumberTable(313)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override float apply(float a) => 1f - base.apply(1f - a);
    }

    class BounceOut : Object, Interp
    {
      [Modifiers]
      internal float[] widths;
      [Modifiers]
      internal float[] heights;

      [LineNumberTable(new byte[] {160, 126, 104, 104, 127, 6, 108, 108, 109, 157, 109, 109, 109, 133, 109, 109, 109, 109, 109, 133, 109, 109, 109, 109, 109, 109, 109, 130, 109, 109, 109, 109, 109, 109, 109, 109, 173, 118})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public BounceOut(int bounces)
      {
        Interp.BounceOut bounceOut = this;
        if (bounces < 2 || bounces > 5)
        {
          string str = new StringBuilder().append("bounces cannot be < 2 or > 5: ").append(bounces).toString();
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalArgumentException(str);
        }
        this.widths = new float[bounces];
        this.heights = new float[bounces];
        this.heights[0] = 1f;
        switch (bounces)
        {
          case 2:
            this.widths[0] = 0.6f;
            this.widths[1] = 0.4f;
            this.heights[1] = 0.33f;
            break;
          case 3:
            this.widths[0] = 0.4f;
            this.widths[1] = 0.4f;
            this.widths[2] = 0.2f;
            this.heights[1] = 0.33f;
            this.heights[2] = 0.1f;
            break;
          case 4:
            this.widths[0] = 0.34f;
            this.widths[1] = 0.34f;
            this.widths[2] = 0.2f;
            this.widths[3] = 0.15f;
            this.heights[1] = 0.26f;
            this.heights[2] = 0.11f;
            this.heights[3] = 0.03f;
            break;
          case 5:
            this.widths[0] = 0.3f;
            this.widths[1] = 0.3f;
            this.widths[2] = 0.2f;
            this.widths[3] = 0.1f;
            this.widths[4] = 0.1f;
            this.heights[1] = 0.45f;
            this.heights[2] = 0.3f;
            this.heights[3] = 0.15f;
            this.heights[4] = 0.06f;
            break;
        }
        float[] widths = this.widths;
        int index = 0;
        float[] numArray = widths;
        numArray[index] = numArray[index] * 2f;
      }

      [LineNumberTable(new byte[] {160, 119, 104, 102, 112, 103, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public BounceOut(float[] widths, float[] heights)
      {
        Interp.BounceOut bounceOut = this;
        if (widths.Length != heights.Length)
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalArgumentException("Must be the same number of widths and heights.");
        }
        this.widths = widths;
        this.heights = heights;
      }

      [LineNumberTable(new byte[] {160, 171, 111, 117, 108, 110, 105, 101, 105, 130, 231, 58, 230, 72, 103, 113})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual float apply(float a)
      {
        if ((double) a == 1.0)
          return 1f;
        a += this.widths[0] / 2f;
        float num1 = 0.0f;
        float num2 = 0.0f;
        int index = 0;
        for (int length = this.widths.Length; index < length; ++index)
        {
          num1 = this.widths[index];
          if ((double) a <= (double) num1)
          {
            num2 = this.heights[index];
            break;
          }
          a -= num1;
        }
        a /= num1;
        float num3 = 4f / num1 * num2 * a;
        return 1f - (num3 - num3 * a) * num1;
      }

      [HideFromJava]
      public virtual float apply([In] float obj0, [In] float obj1, [In] float obj2) => Interp.\u003Cdefault\u003Eapply((Interp) this, obj0, obj1, obj2);
    }

    class Elastic : Object, Interp
    {
      [Modifiers]
      internal float value;
      [Modifiers]
      internal float power;
      [Modifiers]
      internal float scale;
      [Modifiers]
      internal float bounces;

      [LineNumberTable(new byte[] {114, 104, 104, 104, 105, 127, 5})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public Elastic(float value, float power, int bounces, float scale)
      {
        Interp.Elastic elastic = this;
        this.value = value;
        this.power = power;
        this.scale = scale;
        double num1 = (double) ((float) bounces * 3.141593f);
        int num2 = bounces;
        int num3 = 2;
        double num4 = (num3 != -1 ? num2 % num3 : 0) != 0 ? -1.0 : 1.0;
        this.bounces = (float) (num1 * num4);
      }

      [LineNumberTable(new byte[] {123, 105, 107, 159, 35, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual float apply(float a)
      {
        if ((double) a <= 0.5)
        {
          a *= 2f;
          return (float) Math.pow((double) this.value, (double) (this.power * (a - 1f))) * Mathf.sin(a * this.bounces) * this.scale / 2f;
        }
        a = 1f - a;
        a *= 2f;
        return 1f - (float) Math.pow((double) this.value, (double) (this.power * (a - 1f))) * Mathf.sin(a * this.bounces) * this.scale / 2f;
      }

      [HideFromJava]
      public virtual float apply([In] float obj0, [In] float obj1, [In] float obj2) => Interp.\u003Cdefault\u003Eapply((Interp) this, obj0, obj1, obj2);
    }

    class ElasticIn : Interp.Elastic
    {
      [LineNumberTable(new byte[] {160, 71, 110})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public ElasticIn(float value, float power, int bounces, float scale)
        : base(value, power, bounces, scale)
      {
      }

      [LineNumberTable(new byte[] {160, 76, 116})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override float apply(float a) => (double) a >= 0.99 ? 1f : (float) Math.pow((double) this.value, (double) (this.power * (a - 1f))) * Mathf.sin(a * this.bounces) * this.scale;
    }

    class ElasticOut : Interp.Elastic
    {
      [LineNumberTable(new byte[] {160, 83, 110})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public ElasticOut(float value, float power, int bounces, float scale)
        : base(value, power, bounces, scale)
      {
      }

      [LineNumberTable(new byte[] {160, 88, 111, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override float apply(float a)
      {
        if ((double) a == 0.0)
          return 0.0f;
        a = 1f - a;
        return 1f - (float) Math.pow((double) this.value, (double) (this.power * (a - 1f))) * Mathf.sin(a * this.bounces) * this.scale;
      }
    }

    class Exp : Object, Interp
    {
      [Modifiers]
      internal float value;
      [Modifiers]
      internal float power;
      [Modifiers]
      internal float min;
      [Modifiers]
      internal float scale;

      [LineNumberTable(new byte[] {84, 127, 41})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual float apply(float a) => (double) a <= 0.5 ? ((float) Math.pow((double) this.value, (double) (this.power * (a * 2f - 1f))) - this.min) * this.scale / 2f : (2f - ((float) Math.pow((double) this.value, (double) (-this.power * (a * 2f - 1f))) - this.min) * this.scale) / 2f;

      [LineNumberTable(new byte[] {75, 104, 104, 104, 116, 122})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public Exp(float value, float power)
      {
        Interp.Exp exp = this;
        this.value = value;
        this.power = power;
        this.min = (float) Math.pow((double) value, -(double) power);
        this.scale = 1f / (1f - this.min);
      }

      [HideFromJava]
      public virtual float apply([In] float obj0, [In] float obj1, [In] float obj2) => Interp.\u003Cdefault\u003Eapply((Interp) this, obj0, obj1, obj2);
    }

    class ExpIn : Interp.Exp
    {
      [LineNumberTable(new byte[] {91, 106})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public ExpIn(float value, float power)
        : base(value, power)
      {
      }

      [LineNumberTable(146)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override float apply(float a) => ((float) Math.pow((double) this.value, (double) (this.power * (a - 1f))) - this.min) * this.scale;
    }

    class ExpOut : Interp.Exp
    {
      [LineNumberTable(157)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override float apply(float a) => 1f - ((float) Math.pow((double) this.value, (double) (-this.power * a)) - this.min) * this.scale;

      [LineNumberTable(new byte[] {102, 106})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public ExpOut(float value, float power)
        : base(value, power)
      {
      }
    }

    class Pow : Object, Interp
    {
      [Modifiers]
      internal int power;

      [LineNumberTable(new byte[] {45, 127, 10})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual float apply(float a)
      {
        if ((double) a <= 0.5)
          return (float) Math.pow((double) (a * 2f), (double) this.power) / 2f;
        double num1 = Math.pow((double) ((a - 1f) * 2f), (double) this.power);
        int power = this.power;
        int num2 = 2;
        double num3 = (num2 != -1 ? power % num2 : 0) != 0 ? 2.0 : -2.0;
        return (float) (num1 / num3) + 1f;
      }

      [HideFromJava]
      public virtual float apply([In] float obj0, [In] float obj1, [In] float obj2) => Interp.\u003Cdefault\u003Eapply((Interp) this, obj0, obj1, obj2);

      [LineNumberTable(new byte[] {39, 104, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public Pow(int power)
      {
        Interp.Pow pow = this;
        this.power = power;
      }
    }

    class PowIn : Interp.Pow
    {
      [LineNumberTable(107)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override float apply(float a) => (float) Math.pow((double) a, (double) this.power);

      [LineNumberTable(new byte[] {52, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public PowIn(int power)
        : base(power)
      {
      }
    }

    class PowOut : Interp.Pow
    {
      [LineNumberTable(118)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override float apply(float a)
      {
        double num1 = Math.pow((double) (a - 1f), (double) this.power);
        int power = this.power;
        int num2 = 2;
        double num3 = (num2 != -1 ? power % num2 : 0) != 0 ? 1.0 : -1.0;
        return (float) (num1 * num3) + 1f;
      }

      [LineNumberTable(new byte[] {63, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public PowOut(int power)
        : base(power)
      {
      }
    }

    class Swing : Object, Interp
    {
      [Modifiers]
      private float scale;

      [LineNumberTable(new byte[] {160, 206, 104, 111})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public Swing(float scale)
      {
        Interp.Swing swing = this;
        this.scale = scale * 2f;
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual float apply(float a)
      {
        if ((double) a <= 0.5)
        {
          a *= 2f;
          return a * a * ((this.scale + 1f) * a - this.scale) / 2f;
        }
        --a;
        a *= 2f;
        return a * a * ((this.scale + 1f) * a + this.scale) / 2f + 1f;
      }

      [HideFromJava]
      public virtual float apply([In] float obj0, [In] float obj1, [In] float obj2) => Interp.\u003Cdefault\u003Eapply((Interp) this, obj0, obj1, obj2);
    }

    class SwingIn : Object, Interp
    {
      [Modifiers]
      private float scale;

      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual float apply(float a) => a * a * ((this.scale + 1f) * a - this.scale);

      [LineNumberTable(new byte[] {160, 239, 104, 104})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public SwingIn(float scale)
      {
        Interp.SwingIn swingIn = this;
        this.scale = scale;
      }

      [HideFromJava]
      public virtual float apply([In] float obj0, [In] float obj1, [In] float obj2) => Interp.\u003Cdefault\u003Eapply((Interp) this, obj0, obj1, obj2);
    }

    class SwingOut : Object, Interp
    {
      [Modifiers]
      private float scale;

      [LineNumberTable(new byte[] {160, 225, 104, 104})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public SwingOut(float scale)
      {
        Interp.SwingOut swingOut = this;
        this.scale = scale;
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual float apply(float a)
      {
        --a;
        return a * a * ((this.scale + 1f) * a + this.scale) + 1f;
      }

      [HideFromJava]
      public virtual float apply([In] float obj0, [In] float obj1, [In] float obj2) => Interp.\u003Cdefault\u003Eapply((Interp) this, obj0, obj1, obj2);
    }

    private static class __\u003C\u003EPIM
    {
      [Modifiers]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal static float lambda\u0024static\u00240([In] float obj0) => obj0;

      [Modifiers]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal static float lambda\u0024static\u00241([In] float obj0) => obj0 * obj0 * (3f - 2f * obj0);

      [Modifiers]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal static float lambda\u0024static\u00242([In] float obj0)
      {
        obj0 = obj0 * obj0 * (3f - 2f * obj0);
        return obj0 * obj0 * (3f - 2f * obj0);
      }

      [Modifiers]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal static float lambda\u0024static\u00243([In] float obj0) => obj0 * obj0 * obj0 * (obj0 * (obj0 * 6f - 15f) + 10f);

      [Modifiers]
      [LineNumberTable(29)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal static float lambda\u0024static\u00244([In] float obj0) => (float) Math.sqrt((double) obj0);

      [Modifiers]
      [LineNumberTable(30)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal static float lambda\u0024static\u00245([In] float obj0) => 1f - (float) Math.sqrt(-(double) (obj0 - 1f));

      [Modifiers]
      [LineNumberTable(34)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal static float lambda\u0024static\u00246([In] float obj0) => (float) Math.cbrt((double) obj0);

      [Modifiers]
      [LineNumberTable(35)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal static float lambda\u0024static\u00247([In] float obj0) => 1f - (float) Math.cbrt(-(double) (obj0 - 1f));

      [Modifiers]
      [LineNumberTable(43)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal static float lambda\u0024static\u00248([In] float obj0) => (1f - Mathf.cos(obj0 * 3.141593f)) / 2f;

      [Modifiers]
      [LineNumberTable(44)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal static float lambda\u0024static\u00249([In] float obj0) => 1f - Mathf.cos(obj0 * 3.141593f / 2f);

      [Modifiers]
      [LineNumberTable(45)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal static float lambda\u0024static\u002410([In] float obj0) => Mathf.sin(obj0 * 3.141593f / 2f);

      [Modifiers]
      [LineNumberTable(new byte[] {3, 105, 107, 159, 5, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal static float lambda\u0024static\u002411([In] float obj0)
      {
        if ((double) obj0 <= 0.5)
        {
          obj0 *= 2f;
          return (1f - (float) Math.sqrt((double) (1f - obj0 * obj0))) / 2f;
        }
        --obj0;
        obj0 *= 2f;
        return ((float) Math.sqrt((double) (1f - obj0 * obj0)) + 1f) / 2f;
      }

      [Modifiers]
      [LineNumberTable(61)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal static float lambda\u0024static\u002412([In] float obj0) => 1f - (float) Math.sqrt((double) (1f - obj0 * obj0));

      [Modifiers]
      [LineNumberTable(new byte[] {13, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal static float lambda\u0024static\u002413([In] float obj0)
      {
        --obj0;
        return (float) Math.sqrt((double) (1f - obj0 * obj0));
      }
    }

    [HideFromJava]
    static class __DefaultMethods
    {
      public static float apply([In] Interp obj0, [In] float obj1, [In] float obj2, [In] float obj3)
      {
        Interp nterp = obj0;
        // ISSUE: virtual method pointer
        IntPtr num = __vmethodptr(nterp, ToString);
        return Interp.\u003Cdefault\u003Eapply(nterp, obj1, obj2, obj3);
      }
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Interp
    {
      internal __\u003C\u003EAnon1()
      {
      }

      public float apply([In] float obj0) => Interp.__\u003C\u003EPIM.lambda\u0024static\u00240(obj0);

      [SpecialName]
      public float apply([In] float obj0, [In] float obj1, [In] float obj2) => Interp.\u003Cdefault\u003Eapply((Interp) this, obj0, obj1, obj2);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon2 : Interp
    {
      internal __\u003C\u003EAnon2()
      {
      }

      public float apply([In] float obj0) => Interp.__\u003C\u003EPIM.lambda\u0024static\u00241(obj0);

      [SpecialName]
      public float apply([In] float obj0, [In] float obj1, [In] float obj2) => Interp.\u003Cdefault\u003Eapply((Interp) this, obj0, obj1, obj2);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon3 : Interp
    {
      internal __\u003C\u003EAnon3()
      {
      }

      public float apply([In] float obj0) => Interp.__\u003C\u003EPIM.lambda\u0024static\u00242(obj0);

      [SpecialName]
      public float apply([In] float obj0, [In] float obj1, [In] float obj2) => Interp.\u003Cdefault\u003Eapply((Interp) this, obj0, obj1, obj2);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon4 : Interp
    {
      internal __\u003C\u003EAnon4()
      {
      }

      public float apply([In] float obj0) => Interp.__\u003C\u003EPIM.lambda\u0024static\u00243(obj0);

      [SpecialName]
      public float apply([In] float obj0, [In] float obj1, [In] float obj2) => Interp.\u003Cdefault\u003Eapply((Interp) this, obj0, obj1, obj2);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon5 : Interp
    {
      internal __\u003C\u003EAnon5()
      {
      }

      public float apply([In] float obj0) => Interp.__\u003C\u003EPIM.lambda\u0024static\u00244(obj0);

      [SpecialName]
      public float apply([In] float obj0, [In] float obj1, [In] float obj2) => Interp.\u003Cdefault\u003Eapply((Interp) this, obj0, obj1, obj2);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon6 : Interp
    {
      internal __\u003C\u003EAnon6()
      {
      }

      public float apply([In] float obj0) => Interp.__\u003C\u003EPIM.lambda\u0024static\u00245(obj0);

      [SpecialName]
      public float apply([In] float obj0, [In] float obj1, [In] float obj2) => Interp.\u003Cdefault\u003Eapply((Interp) this, obj0, obj1, obj2);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon7 : Interp
    {
      internal __\u003C\u003EAnon7()
      {
      }

      public float apply([In] float obj0) => Interp.__\u003C\u003EPIM.lambda\u0024static\u00246(obj0);

      [SpecialName]
      public float apply([In] float obj0, [In] float obj1, [In] float obj2) => Interp.\u003Cdefault\u003Eapply((Interp) this, obj0, obj1, obj2);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon8 : Interp
    {
      internal __\u003C\u003EAnon8()
      {
      }

      public float apply([In] float obj0) => Interp.__\u003C\u003EPIM.lambda\u0024static\u00247(obj0);

      [SpecialName]
      public float apply([In] float obj0, [In] float obj1, [In] float obj2) => Interp.\u003Cdefault\u003Eapply((Interp) this, obj0, obj1, obj2);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon9 : Interp
    {
      internal __\u003C\u003EAnon9()
      {
      }

      public float apply([In] float obj0) => Interp.__\u003C\u003EPIM.lambda\u0024static\u00248(obj0);

      [SpecialName]
      public float apply([In] float obj0, [In] float obj1, [In] float obj2) => Interp.\u003Cdefault\u003Eapply((Interp) this, obj0, obj1, obj2);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon10 : Interp
    {
      internal __\u003C\u003EAnon10()
      {
      }

      public float apply([In] float obj0) => Interp.__\u003C\u003EPIM.lambda\u0024static\u00249(obj0);

      [SpecialName]
      public float apply([In] float obj0, [In] float obj1, [In] float obj2) => Interp.\u003Cdefault\u003Eapply((Interp) this, obj0, obj1, obj2);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon11 : Interp
    {
      internal __\u003C\u003EAnon11()
      {
      }

      public float apply([In] float obj0) => Interp.__\u003C\u003EPIM.lambda\u0024static\u002410(obj0);

      [SpecialName]
      public float apply([In] float obj0, [In] float obj1, [In] float obj2) => Interp.\u003Cdefault\u003Eapply((Interp) this, obj0, obj1, obj2);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon12 : Interp
    {
      internal __\u003C\u003EAnon12()
      {
      }

      public float apply([In] float obj0) => Interp.__\u003C\u003EPIM.lambda\u0024static\u002411(obj0);

      [SpecialName]
      public float apply([In] float obj0, [In] float obj1, [In] float obj2) => Interp.\u003Cdefault\u003Eapply((Interp) this, obj0, obj1, obj2);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon13 : Interp
    {
      internal __\u003C\u003EAnon13()
      {
      }

      public float apply([In] float obj0) => Interp.__\u003C\u003EPIM.lambda\u0024static\u002412(obj0);

      [SpecialName]
      public float apply([In] float obj0, [In] float obj1, [In] float obj2) => Interp.\u003Cdefault\u003Eapply((Interp) this, obj0, obj1, obj2);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon14 : Interp
    {
      internal __\u003C\u003EAnon14()
      {
      }

      public float apply([In] float obj0) => Interp.__\u003C\u003EPIM.lambda\u0024static\u002413(obj0);

      [SpecialName]
      public float apply([In] float obj0, [In] float obj1, [In] float obj2) => Interp.\u003Cdefault\u003Eapply((Interp) this, obj0, obj1, obj2);
    }

    [HideFromJava]
    static class __Fields
    {
      public static readonly Interp linear = Interp.linear;
      public static readonly Interp smooth = Interp.smooth;
      public static readonly Interp smooth2 = Interp.smooth2;
      public static readonly Interp smoother = Interp.smoother;
      public static readonly Interp fade = Interp.fade;
      public static readonly Interp.Pow pow2 = Interp.pow2;
      public static readonly Interp.PowIn pow2In = Interp.pow2In;
      public static readonly Interp.PowIn slowFast = Interp.slowFast;
      public static readonly Interp.PowOut pow2Out = Interp.pow2Out;
      public static readonly Interp.PowOut fastSlow = Interp.fastSlow;
      public static readonly Interp pow2InInverse = Interp.pow2InInverse;
      public static readonly Interp pow2OutInverse = Interp.pow2OutInverse;
      public static readonly Interp.Pow pow3 = Interp.pow3;
      public static readonly Interp.PowIn pow3In = Interp.pow3In;
      public static readonly Interp.PowOut pow3Out = Interp.pow3Out;
      public static readonly Interp pow3InInverse = Interp.pow3InInverse;
      public static readonly Interp pow3OutInverse = Interp.pow3OutInverse;
      public static readonly Interp.Pow pow4 = Interp.pow4;
      public static readonly Interp.PowIn pow4In = Interp.pow4In;
      public static readonly Interp.PowOut pow4Out = Interp.pow4Out;
      public static readonly Interp.Pow pow5 = Interp.pow5;
      public static readonly Interp.PowIn pow5In = Interp.pow5In;
      public static readonly Interp.PowIn pow10In = Interp.pow10In;
      public static readonly Interp.PowOut pow5Out = Interp.pow5Out;
      public static readonly Interp sine = Interp.sine;
      public static readonly Interp sineIn = Interp.sineIn;
      public static readonly Interp sineOut = Interp.sineOut;
      public static readonly Interp.Exp exp10 = Interp.exp10;
      public static readonly Interp.ExpIn exp10In = Interp.exp10In;
      public static readonly Interp.ExpOut exp10Out = Interp.exp10Out;
      public static readonly Interp.Exp exp5 = Interp.exp5;
      public static readonly Interp.ExpIn exp5In = Interp.exp5In;
      public static readonly Interp.ExpOut exp5Out = Interp.exp5Out;
      public static readonly Interp circle = Interp.circle;
      public static readonly Interp circleIn = Interp.circleIn;
      public static readonly Interp circleOut = Interp.circleOut;
      public static readonly Interp.Elastic elastic = Interp.elastic;
      public static readonly Interp.ElasticIn elasticIn = Interp.elasticIn;
      public static readonly Interp.ElasticOut elasticOut = Interp.elasticOut;
      public static readonly Interp.Swing swing = Interp.swing;
      public static readonly Interp.SwingIn swingIn = Interp.swingIn;
      public static readonly Interp.SwingOut swingOut = Interp.swingOut;
      public static readonly Interp.Bounce bounce = Interp.bounce;
      public static readonly Interp.BounceIn bounceIn = Interp.bounceIn;
      public static readonly Interp.BounceOut bounceOut = Interp.bounceOut;
    }
  }
}
