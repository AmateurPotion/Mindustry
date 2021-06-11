// Decompiled with JetBrains decompiler
// Type: arc.math.geom.Spring2D
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;

namespace arc.math.geom
{
  public class Spring2D : Object
  {
    public Vec2 value;
    public Vec2 target;
    public Vec2 velocity;
    public float damping;
    public float frequency;

    [LineNumberTable(new byte[] {159, 156, 232, 57, 107, 107, 235, 70, 104, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Spring2D(float damping, float frequency)
    {
      Spring2D spring2D = this;
      this.value = new Vec2();
      this.target = new Vec2();
      this.velocity = new Vec2();
      this.damping = damping;
      this.frequency = frequency;
    }

    [LineNumberTable(new byte[] {159, 162, 103, 137, 124, 101, 102, 103, 174, 127, 19, 127, 11, 113, 209, 127, 19, 127, 11, 113, 145})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void update(float deltaTime)
    {
      float num1 = this.frequency * 6.283185f;
      float num2 = 1f + 2f * deltaTime * this.damping * num1;
      float num3 = num1 * num1;
      float num4 = deltaTime * num3;
      float num5 = deltaTime * num4;
      float num6 = 1f / (num2 + num5);
      float num7 = num2 * this.value.x + deltaTime * this.velocity.x + num5 * this.target.x;
      float num8 = this.velocity.x + num4 * (this.target.x - this.value.x);
      this.value.x = num7 * num6;
      this.velocity.x = num8 * num6;
      float num9 = num2 * this.value.y + deltaTime * this.velocity.y + num5 * this.target.y;
      float num10 = this.velocity.y + num4 * (this.target.y - this.value.y);
      this.value.y = num9 * num6;
      this.velocity.y = num10 * num6;
    }
  }
}
