// Decompiled with JetBrains decompiler
// Type: mindustry.graphics.Trail
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.func;
using arc.graphics;
using arc.graphics.g2d;
using arc.math;
using arc.math.geom;
using arc.util.pooling;
using ikvm.@internal;
using IKVM.Attributes;
using java.lang;
using System;
using System.Runtime.CompilerServices;

namespace mindustry.graphics
{
  public class Trail : Object
  {
    public int length;
    [Modifiers]
    [Signature("Larc/struct/Seq<Larc/math/geom/Vec3;>;")]
    private Seq points;
    private float lastX;
    private float lastY;

    [LineNumberTable(new byte[] {159, 168, 134, 117, 114, 116, 140, 127, 57, 255, 54, 58, 233, 73, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void draw(Color color, float width)
    {
      Draw.color(color);
      for (int index = 0; index < this.points.size - 1; ++index)
      {
        Vec3 vec3_1 = (Vec3) this.points.get(index);
        Vec3 vec3_2 = (Vec3) this.points.get(index + 1);
        float num1 = width / (float) this.length;
        float num2 = Mathf.sin(vec3_1.z) * (float) index * num1;
        float num3 = Mathf.cos(vec3_1.z) * (float) index * num1;
        float num4 = Mathf.sin(vec3_2.z) * (float) (index + 1) * num1;
        float num5 = Mathf.cos(vec3_2.z) * (float) (index + 1) * num1;
        Fill.quad(vec3_1.x - num2, vec3_1.y - num3, vec3_1.x + num2, vec3_1.y + num3, vec3_2.x + num4, vec3_2.y + num5, vec3_2.x - num4, vec3_2.y - num5);
      }
      Draw.reset();
    }

    [LineNumberTable(new byte[] {159, 158, 8, 182, 103, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Trail(int length)
    {
      Trail trail = this;
      this.lastX = -1f;
      this.lastY = -1f;
      this.length = length;
      this.points = new Seq(length);
    }

    [LineNumberTable(new byte[] {159, 183, 115, 112, 173, 152, 159, 22, 104, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void update(float x, float y)
    {
      if (this.points.size > this.length)
      {
        Pools.free(this.points.first());
        this.points.remove(0);
      }
      float num = -Angles.angle(x, y, this.lastX, this.lastY);
      this.points.add((object) ((Vec3) Pools.obtain((Class) ClassLiteral<Vec3>.Value, (Prov) new Trail.__\u003C\u003EAnon0())).set(x, y, num * ((float) Math.PI / 180f)));
      this.lastX = x;
      this.lastY = y;
    }

    [LineNumberTable(new byte[] {159, 164, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void clear() => this.points.clear();

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Prov
    {
      internal __\u003C\u003EAnon0()
      {
      }

      public object get() => (object) new Vec3();
    }
  }
}
