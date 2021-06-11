// Decompiled with JetBrains decompiler
// Type: arc.math.geom.Spring1D
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;

namespace arc.math.geom
{
  public class Spring1D : Object
  {
    public float value;
    public float target;
    public float velocity;
    public float damping;
    public float frequency;

    [LineNumberTable(new byte[] {159, 156, 104, 104, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Spring1D(float damping, float frequency)
    {
      Spring1D spring1D = this;
      this.damping = damping;
      this.frequency = frequency;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void update(float deltaTime)
    {
      float num1 = this.frequency * 6.283185f;
      float num2 = 1f + 2f * deltaTime * this.damping * num1;
      float num3 = num1 * num1;
      float num4 = deltaTime * num3;
      float num5 = deltaTime * num4;
      float num6 = 1f / (num2 + num5);
      float num7 = num2 * this.value + deltaTime * this.velocity + num5 * this.target;
      float num8 = this.velocity + num4 * (this.target - this.value);
      this.value = num7 * num6;
      this.velocity = num8 * num6;
    }
  }
}
