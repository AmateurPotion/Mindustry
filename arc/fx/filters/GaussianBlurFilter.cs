// Decompiled with JetBrains decompiler
// Type: arc.fx.filters.GaussianBlurFilter
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.fx.util;
using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.fx.filters
{
  public class GaussianBlurFilter : MultipassVfxFilter
  {
    private GaussianBlurFilter.BlurType type;
    private float amount;
    private int passes;
    private float invWidth;
    private float invHeight;
    private Convolve2dFilter convolve;

    [LineNumberTable(new byte[] {159, 156, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public GaussianBlurFilter()
      : this(GaussianBlurFilter.BlurType.__\u003C\u003Egaussian5x5)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setPasses(int passes) => this.passes = passes;

    [LineNumberTable(new byte[] {30, 104, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setAmount(float amount)
    {
      this.amount = amount;
      this.computeBlurWeightings();
    }

    [LineNumberTable(new byte[] {159, 170, 111, 143, 109, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void resize(int width, int height)
    {
      this.invWidth = 1f / (float) width;
      this.invHeight = 1f / (float) height;
      this.convolve.resize(width, height);
      this.computeBlurWeightings();
    }

    [LineNumberTable(new byte[] {159, 165, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void dispose() => this.convolve.dispose();

    [LineNumberTable(new byte[] {159, 185, 107, 140, 107, 230, 60, 230, 71})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void render(PingPongBuffer buffer)
    {
      for (int index = 0; index < this.passes; ++index)
      {
        this.convolve.render(buffer);
        if (index < this.passes - 1)
          buffer.swap();
      }
    }

    [LineNumberTable(new byte[] {7, 99, 144, 110, 167, 104, 139, 155, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setType(GaussianBlurFilter.BlurType type)
    {
      if (type == null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException("Blur type cannot be null.");
      }
      if (object.ReferenceEquals((object) this.type, (object) type))
        return;
      this.type = type;
      if (this.convolve != null)
        this.convolve.dispose();
      this.convolve = new Convolve2dFilter(this.type.__\u003C\u003Etap.radius);
      this.computeBlurWeightings();
    }

    [LineNumberTable(new byte[] {159, 179, 107, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setParams()
    {
      this.convolve.setParams();
      this.computeBlurWeightings();
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getPasses() => this.passes;

    [LineNumberTable(new byte[] {159, 159, 232, 54, 107, 231, 74, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public GaussianBlurFilter(GaussianBlurFilter.BlurType blurType)
    {
      GaussianBlurFilter gaussianBlurFilter = this;
      this.amount = 1f;
      this.passes = 1;
      this.setType(blurType);
    }

    [LineNumberTable(new byte[] {43, 130, 108, 108, 140, 104, 136, 191, 14, 125, 127, 5, 229, 72, 104, 104, 168, 104, 104, 104, 104, 104, 168, 104, 104, 104, 104, 104, 168, 116, 117, 21, 232, 69, 229, 73, 104, 104, 104, 104, 168, 104, 104, 104, 104, 104, 104, 104, 104, 104, 169, 104, 104, 104, 104, 104, 104, 104, 104, 104, 169, 116, 117, 21, 232, 69, 130, 194, 99, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void computeBlurWeightings()
    {
      int num = 1;
      float[] weights = this.convolve.__\u003C\u003Eweights;
      float[] offsetsHor = this.convolve.__\u003C\u003EoffsetsHor;
      float[] offsetsVert = this.convolve.__\u003C\u003EoffsetsVert;
      float invWidth = this.invWidth;
      float invHeight = this.invHeight;
      switch (GaussianBlurFilter.\u0031.\u0024SwitchMap\u0024arc\u0024fx\u0024filters\u0024GaussianBlurFilter\u0024BlurType[this.type.ordinal()])
      {
        case 1:
        case 2:
          this.computeKernel(this.type.__\u003C\u003Etap.radius, this.amount, weights);
          this.computeOffsets(this.type.__\u003C\u003Etap.radius, this.invWidth, this.invHeight, offsetsHor, offsetsVert);
          break;
        case 3:
          weights[0] = 0.352941f;
          weights[1] = 0.294118f;
          weights[2] = 0.352941f;
          offsetsHor[0] = -1.33333f;
          offsetsHor[1] = 0.0f;
          offsetsHor[2] = 0.0f;
          offsetsHor[3] = 0.0f;
          offsetsHor[4] = 1.33333f;
          offsetsHor[5] = 0.0f;
          offsetsVert[0] = 0.0f;
          offsetsVert[1] = -1.33333f;
          offsetsVert[2] = 0.0f;
          offsetsVert[3] = 0.0f;
          offsetsVert[4] = 0.0f;
          offsetsVert[5] = 1.33333f;
          for (int index1 = 0; index1 < this.convolve.__\u003C\u003Elength * 2; ++index1)
          {
            float[] numArray1 = offsetsHor;
            int index2 = index1;
            float[] numArray2 = numArray1;
            numArray2[index2] = numArray2[index2] * invWidth;
            float[] numArray3 = offsetsVert;
            int index3 = index1;
            float[] numArray4 = numArray3;
            numArray4[index3] = numArray4[index3] * invHeight;
          }
          break;
        case 4:
          weights[0] = 0.0702703f;
          weights[1] = 0.316216f;
          weights[2] = 0.227027f;
          weights[3] = 0.316216f;
          weights[4] = 0.0702703f;
          offsetsHor[0] = -3.23077f;
          offsetsHor[1] = 0.0f;
          offsetsHor[2] = -1.38462f;
          offsetsHor[3] = 0.0f;
          offsetsHor[4] = 0.0f;
          offsetsHor[5] = 0.0f;
          offsetsHor[6] = 1.38462f;
          offsetsHor[7] = 0.0f;
          offsetsHor[8] = 3.23077f;
          offsetsHor[9] = 0.0f;
          offsetsVert[0] = 0.0f;
          offsetsVert[1] = -3.23077f;
          offsetsVert[2] = 0.0f;
          offsetsVert[3] = -1.38462f;
          offsetsVert[4] = 0.0f;
          offsetsVert[5] = 0.0f;
          offsetsVert[6] = 0.0f;
          offsetsVert[7] = 1.38462f;
          offsetsVert[8] = 0.0f;
          offsetsVert[9] = 3.23077f;
          for (int index1 = 0; index1 < this.convolve.__\u003C\u003Elength * 2; ++index1)
          {
            float[] numArray1 = offsetsHor;
            int index2 = index1;
            float[] numArray2 = numArray1;
            numArray2[index2] = numArray2[index2] * invWidth;
            float[] numArray3 = offsetsVert;
            int index3 = index1;
            float[] numArray4 = numArray3;
            numArray4[index3] = numArray4[index3] * invHeight;
          }
          break;
        default:
          num = 0;
          break;
      }
      if (num == 0)
        return;
      this.convolve.setParams();
    }

    [LineNumberTable(new byte[] {160, 84, 162, 131, 108, 117, 103, 102, 130, 105, 104, 102, 117, 234, 60, 232, 71, 103, 105, 53, 168})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void computeKernel([In] int obj0, [In] float obj1, [In] float[] obj2)
    {
      int num1 = obj0;
      float num2 = obj1;
      float num3 = 2f * num2 * num2;
      float num4 = (float) Math.sqrt((double) num3 * Math.PI);
      float num5 = 0.0f;
      for (int index1 = -num1; index1 <= num1; ++index1)
      {
        float num6 = (float) (index1 * index1);
        int index2 = index1 + num1;
        obj2[index2] = (float) Math.exp((double) (-num6 / num3)) / num4;
        num5 += obj2[index2];
      }
      int num7 = num1 * 2 + 1;
      for (int index1 = 0; index1 < num7; ++index1)
      {
        float[] numArray1 = obj2;
        int index2 = index1;
        float[] numArray2 = numArray1;
        numArray2[index2] = numArray2[index2] / num5;
      }
    }

    [LineNumberTable(new byte[] {160, 109, 130, 100, 105, 108, 139, 107, 236, 59, 234, 71})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void computeOffsets([In] int obj0, [In] float obj1, [In] float obj2, [In] float[] obj3, [In] float[] obj4)
    {
      int num1 = obj0;
      int num2 = -num1;
      int num3 = 0;
      while (num2 <= num1)
      {
        obj3[num3 + 0] = (float) num2 * obj1;
        obj3[num3 + 1] = 0.0f;
        obj4[num3 + 0] = 0.0f;
        obj4[num3 + 1] = (float) num2 * obj2;
        ++num2;
        num3 += 2;
      }
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual GaussianBlurFilter.BlurType getType() => this.type;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getAmount() => this.amount;

    [InnerClass]
    [EnclosingMethod(null, null, null)]
    [Modifiers]
    [SpecialName]
    internal class \u0031 : Object
    {
      [Modifiers]
      internal static int[] \u0024SwitchMap\u0024arc\u0024fx\u0024filters\u0024GaussianBlurFilter\u0024BlurType;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(102)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static \u0031()
      {
        if (ByteCodeHelper.isAlreadyInited("arc.fx.filters.GaussianBlurFilter$1"))
          return;
        GaussianBlurFilter.\u0031.\u0024SwitchMap\u0024arc\u0024fx\u0024filters\u0024GaussianBlurFilter\u0024BlurType = new int[GaussianBlurFilter.BlurType.values().Length];
        try
        {
          GaussianBlurFilter.\u0031.\u0024SwitchMap\u0024arc\u0024fx\u0024filters\u0024GaussianBlurFilter\u0024BlurType[GaussianBlurFilter.BlurType.__\u003C\u003Egaussian3x3.ordinal()] = 1;
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
          GaussianBlurFilter.\u0031.\u0024SwitchMap\u0024arc\u0024fx\u0024filters\u0024GaussianBlurFilter\u0024BlurType[GaussianBlurFilter.BlurType.__\u003C\u003Egaussian5x5.ordinal()] = 2;
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
          GaussianBlurFilter.\u0031.\u0024SwitchMap\u0024arc\u0024fx\u0024filters\u0024GaussianBlurFilter\u0024BlurType[GaussianBlurFilter.BlurType.__\u003C\u003Egaussian3x3b.ordinal()] = 3;
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
          GaussianBlurFilter.\u0031.\u0024SwitchMap\u0024arc\u0024fx\u0024filters\u0024GaussianBlurFilter\u0024BlurType[GaussianBlurFilter.BlurType.__\u003C\u003Egaussian5x5b.ordinal()] = 4;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
      }

      \u0031() => throw null;
    }

    [InnerClass]
    [Signature("Ljava/lang/Enum<Larc/fx/filters/GaussianBlurFilter$BlurType;>;")]
    [Modifiers]
    [Serializable]
    public sealed class BlurType : Enum
    {
      [Modifiers]
      internal static GaussianBlurFilter.BlurType __\u003C\u003Egaussian3x3;
      [Modifiers]
      internal static GaussianBlurFilter.BlurType __\u003C\u003Egaussian3x3b;
      [Modifiers]
      internal static GaussianBlurFilter.BlurType __\u003C\u003Egaussian5x5;
      [Modifiers]
      internal static GaussianBlurFilter.BlurType __\u003C\u003Egaussian5x5b;
      internal GaussianBlurFilter.Tap __\u003C\u003Etap;
      [Modifiers]
      private static GaussianBlurFilter.BlurType[] \u0024VALUES;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(248)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static GaussianBlurFilter.BlurType[] values() => (GaussianBlurFilter.BlurType[]) GaussianBlurFilter.BlurType.\u0024VALUES.Clone();

      [Signature("(Larc/fx/filters/GaussianBlurFilter$Tap;)V")]
      [LineNumberTable(new byte[] {160, 141, 106, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private BlurType([In] string obj0, [In] int obj1, [In] GaussianBlurFilter.Tap obj2)
        : base(obj0, obj1)
      {
        GaussianBlurFilter.BlurType blurType = this;
        this.__\u003C\u003Etap = obj2;
        GC.KeepAlive((object) this);
      }

      [LineNumberTable(248)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static GaussianBlurFilter.BlurType valueOf(string name) => (GaussianBlurFilter.BlurType) Enum.valueOf((Class) ClassLiteral<GaussianBlurFilter.BlurType>.Value, name);

      [LineNumberTable(new byte[] {159, 80, 109, 127, 11, 31, 11})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static BlurType()
      {
        if (ByteCodeHelper.isAlreadyInited("arc.fx.filters.GaussianBlurFilter$BlurType"))
          return;
        GaussianBlurFilter.BlurType.__\u003C\u003Egaussian3x3 = new GaussianBlurFilter.BlurType(nameof (gaussian3x3), 0, GaussianBlurFilter.Tap.tap3x3);
        GaussianBlurFilter.BlurType.__\u003C\u003Egaussian3x3b = new GaussianBlurFilter.BlurType(nameof (gaussian3x3b), 1, GaussianBlurFilter.Tap.tap3x3);
        GaussianBlurFilter.BlurType.__\u003C\u003Egaussian5x5 = new GaussianBlurFilter.BlurType(nameof (gaussian5x5), 2, GaussianBlurFilter.Tap.tap5x5);
        GaussianBlurFilter.BlurType.__\u003C\u003Egaussian5x5b = new GaussianBlurFilter.BlurType(nameof (gaussian5x5b), 3, GaussianBlurFilter.Tap.tap5x5);
        GaussianBlurFilter.BlurType.\u0024VALUES = new GaussianBlurFilter.BlurType[4]
        {
          GaussianBlurFilter.BlurType.__\u003C\u003Egaussian3x3,
          GaussianBlurFilter.BlurType.__\u003C\u003Egaussian3x3b,
          GaussianBlurFilter.BlurType.__\u003C\u003Egaussian5x5,
          GaussianBlurFilter.BlurType.__\u003C\u003Egaussian5x5b
        };
      }

      [Modifiers]
      public static GaussianBlurFilter.BlurType gaussian3x3
      {
        [HideFromJava] get => GaussianBlurFilter.BlurType.__\u003C\u003Egaussian3x3;
      }

      [Modifiers]
      public static GaussianBlurFilter.BlurType gaussian3x3b
      {
        [HideFromJava] get => GaussianBlurFilter.BlurType.__\u003C\u003Egaussian3x3b;
      }

      [Modifiers]
      public static GaussianBlurFilter.BlurType gaussian5x5
      {
        [HideFromJava] get => GaussianBlurFilter.BlurType.__\u003C\u003Egaussian5x5;
      }

      [Modifiers]
      public static GaussianBlurFilter.BlurType gaussian5x5b
      {
        [HideFromJava] get => GaussianBlurFilter.BlurType.__\u003C\u003Egaussian5x5b;
      }

      [Modifiers]
      public Enum tap
      {
        [HideFromJava] get => (Enum) this.__\u003C\u003Etap;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Etap = (GaussianBlurFilter.Tap) value;
      }

      [HideFromJava]
      [Serializable]
      public enum __Enum
      {
        gaussian3x3,
        gaussian3x3b,
        gaussian5x5,
        gaussian5x5b,
      }
    }

    [InnerClass]
    [Signature("Ljava/lang/Enum<Larc/fx/filters/GaussianBlurFilter$Tap;>;")]
    [Modifiers]
    [Serializable]
    internal sealed class Tap : Enum
    {
      [Modifiers]
      public static GaussianBlurFilter.Tap tap3x3;
      [Modifiers]
      public static GaussianBlurFilter.Tap tap5x5;
      [Modifiers]
      public int radius;
      [Modifiers]
      private static GaussianBlurFilter.Tap[] \u0024VALUES;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [Signature("(I)V")]
      [LineNumberTable(new byte[] {160, 129, 106, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private Tap([In] string obj0, [In] int obj1, [In] int obj2)
        : base(obj0, obj1)
      {
        GaussianBlurFilter.Tap tap = this;
        this.radius = obj2;
        GC.KeepAlive((object) this);
      }

      [LineNumberTable(235)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static GaussianBlurFilter.Tap[] values() => (GaussianBlurFilter.Tap[]) GaussianBlurFilter.Tap.\u0024VALUES.Clone();

      [LineNumberTable(235)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static GaussianBlurFilter.Tap valueOf([In] string obj0) => (GaussianBlurFilter.Tap) Enum.valueOf((Class) ClassLiteral<GaussianBlurFilter.Tap>.Value, obj0);

      [LineNumberTable(new byte[] {159, 83, 77, 113, 17})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static Tap()
      {
        if (ByteCodeHelper.isAlreadyInited("arc.fx.filters.GaussianBlurFilter$Tap"))
          return;
        GaussianBlurFilter.Tap.tap3x3 = new GaussianBlurFilter.Tap(nameof (tap3x3), 0, 1);
        GaussianBlurFilter.Tap.tap5x5 = new GaussianBlurFilter.Tap(nameof (tap5x5), 1, 2);
        GaussianBlurFilter.Tap.\u0024VALUES = new GaussianBlurFilter.Tap[2]
        {
          GaussianBlurFilter.Tap.tap3x3,
          GaussianBlurFilter.Tap.tap5x5
        };
      }
    }
  }
}
