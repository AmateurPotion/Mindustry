// Decompiled with JetBrains decompiler
// Type: arc.math.LinearRegression
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.math.geom;
using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;

namespace arc.math
{
  public class LinearRegression : Object
  {
    public float intercept;
    public float slope;

    [LineNumberTable(7)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public LinearRegression()
    {
    }

    [Signature("(Larc/struct/Seq<Larc/math/geom/Vec2;>;)V")]
    [LineNumberTable(new byte[] {159, 154, 135, 108, 102, 117, 21, 198, 103, 135, 110, 107, 127, 21, 31, 21, 235, 69, 108, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void calculate(Seq v)
    {
      int size = v.size;
      float num1 = 0.0f;
      float num2 = 0.0f;
      for (int index = 0; index < size; ++index)
      {
        num1 += ((Vec2) v.get(index)).x;
        num2 += ((Vec2) v.get(index)).y;
      }
      float num3 = num1 / (float) size;
      float num4 = num2 / (float) size;
      float num5 = 0.0f;
      float num6 = 0.0f;
      for (int index = 0; index < size; ++index)
      {
        num5 += (((Vec2) v.get(index)).x - num3) * (((Vec2) v.get(index)).x - num3);
        num6 += (((Vec2) v.get(index)).x - num3) * (((Vec2) v.get(index)).y - num4);
      }
      this.slope = num6 / num5;
      this.intercept = num4 - this.slope * num3;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float predict(float x) => this.slope * x + this.intercept;
  }
}
