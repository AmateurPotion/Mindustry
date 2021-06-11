// Decompiled with JetBrains decompiler
// Type: arc.math.geom.Plane
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.math.geom
{
  public class Plane : Object
  {
    internal Vec3 __\u003C\u003Enormal;
    public float d;

    [LineNumberTable(new byte[] {23, 118})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec3 project(Vec3 v)
    {
      float num = this.__\u003C\u003Enormal.dot(v) + this.d;
      return v.sub(num * this.__\u003C\u003Enormal.x, num * this.__\u003C\u003Enormal.y, num * this.__\u003C\u003Enormal.z);
    }

    [LineNumberTable(new byte[] {159, 156, 232, 58, 107, 235, 71})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Plane()
    {
      Plane plane = this;
      this.__\u003C\u003Enormal = new Vec3();
      this.d = 0.0f;
    }

    [LineNumberTable(new byte[] {4, 127, 40, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void set(Vec3 point1, Vec3 point2, Vec3 point3)
    {
      this.__\u003C\u003Enormal.set(point1).sub(point2).crs(point2.x - point3.x, point2.y - point3.y, point2.z - point3.z).nor();
      this.d = -point1.dot(this.__\u003C\u003Enormal);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec3 getNormal() => this.__\u003C\u003Enormal;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getD() => this.d;

    [LineNumberTable(new byte[] {43, 150, 104, 102, 104, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Plane.PlaneSide testPoint(Vec3 point)
    {
      float num = this.__\u003C\u003Enormal.dot(point) + this.d;
      if ((double) num == 0.0)
        return Plane.PlaneSide.__\u003C\u003EonPlane;
      return (double) num < 0.0 ? Plane.PlaneSide.__\u003C\u003Eback : Plane.PlaneSide.__\u003C\u003Efront;
    }

    [LineNumberTable(new byte[] {59, 155, 104, 102, 104, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Plane.PlaneSide testPoint(float x, float y, float z)
    {
      float num = this.__\u003C\u003Enormal.dot(x, y, z) + this.d;
      if ((double) num == 0.0)
        return Plane.PlaneSide.__\u003C\u003EonPlane;
      return (double) num < 0.0 ? Plane.PlaneSide.__\u003C\u003Eback : Plane.PlaneSide.__\u003C\u003Efront;
    }

    [LineNumberTable(new byte[] {159, 165, 232, 49, 107, 235, 79, 114, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Plane(Vec3 normal, float d)
    {
      Plane plane = this;
      this.__\u003C\u003Enormal = new Vec3();
      this.d = 0.0f;
      this.__\u003C\u003Enormal.set(normal).nor();
      this.d = d;
    }

    [LineNumberTable(new byte[] {159, 175, 232, 39, 107, 235, 89, 114, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Plane(Vec3 normal, Vec3 point)
    {
      Plane plane = this;
      this.__\u003C\u003Enormal = new Vec3();
      this.d = 0.0f;
      this.__\u003C\u003Enormal.set(normal).nor();
      this.d = -this.__\u003C\u003Enormal.dot(point);
    }

    [LineNumberTable(new byte[] {159, 187, 232, 27, 107, 235, 101, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Plane(Vec3 point1, Vec3 point2, Vec3 point3)
    {
      Plane plane = this;
      this.__\u003C\u003Enormal = new Vec3();
      this.d = 0.0f;
      this.set(point1, point2, point3);
    }

    [LineNumberTable(new byte[] {16, 114, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void set(float nx, float ny, float nz, float d)
    {
      this.__\u003C\u003Enormal.set(nx, ny, nz);
      this.d = d;
    }

    [LineNumberTable(83)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float distance(Vec3 point) => this.__\u003C\u003Enormal.dot(point) + this.d;

    [LineNumberTable(new byte[] {76, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isFrontFacing(Vec3 direction) => (double) this.__\u003C\u003Enormal.dot(direction) <= 0.0;

    [LineNumberTable(new byte[] {96, 109, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void set(Vec3 point, Vec3 normal)
    {
      this.__\u003C\u003Enormal.set(normal);
      this.d = -point.dot(normal);
    }

    [LineNumberTable(new byte[] {101, 117, 127, 1})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void set(
      float pointX,
      float pointY,
      float pointZ,
      float norX,
      float norY,
      float norZ)
    {
      this.__\u003C\u003Enormal.set(norX, norY, norZ);
      this.d = -(pointX * norX + pointY * norY + pointZ * norZ);
    }

    [LineNumberTable(new byte[] {110, 114, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void set(Plane plane)
    {
      this.__\u003C\u003Enormal.set(plane.__\u003C\u003Enormal);
      this.d = plane.d;
    }

    [LineNumberTable(166)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toString() => new StringBuilder().append(this.__\u003C\u003Enormal.toString()).append(", ").append(this.d).toString();

    [Modifiers]
    public Vec3 normal
    {
      [HideFromJava] get => this.__\u003C\u003Enormal;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Enormal = value;
    }

    [InnerClass]
    [Signature("Ljava/lang/Enum<Larc/math/geom/Plane$PlaneSide;>;")]
    [Modifiers]
    [Serializable]
    public sealed class PlaneSide : Enum
    {
      [Modifiers]
      internal static Plane.PlaneSide __\u003C\u003EonPlane;
      [Modifiers]
      internal static Plane.PlaneSide __\u003C\u003Eback;
      [Modifiers]
      internal static Plane.PlaneSide __\u003C\u003Efront;
      [Modifiers]
      private static Plane.PlaneSide[] \u0024VALUES;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [Signature("()V")]
      [LineNumberTable(174)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private PlaneSide([In] string obj0, [In] int obj1)
        : base(obj0, obj1)
      {
        GC.KeepAlive((object) this);
      }

      [LineNumberTable(174)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static Plane.PlaneSide[] values() => (Plane.PlaneSide[]) Plane.PlaneSide.\u0024VALUES.Clone();

      [LineNumberTable(174)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static Plane.PlaneSide valueOf(string name) => (Plane.PlaneSide) Enum.valueOf((Class) ClassLiteral<Plane.PlaneSide>.Value, name);

      [LineNumberTable(new byte[] {159, 99, 173, 63, 17})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static PlaneSide()
      {
        if (ByteCodeHelper.isAlreadyInited("arc.math.geom.Plane$PlaneSide"))
          return;
        Plane.PlaneSide.__\u003C\u003EonPlane = new Plane.PlaneSide(nameof (onPlane), 0);
        Plane.PlaneSide.__\u003C\u003Eback = new Plane.PlaneSide(nameof (back), 1);
        Plane.PlaneSide.__\u003C\u003Efront = new Plane.PlaneSide(nameof (front), 2);
        Plane.PlaneSide.\u0024VALUES = new Plane.PlaneSide[3]
        {
          Plane.PlaneSide.__\u003C\u003EonPlane,
          Plane.PlaneSide.__\u003C\u003Eback,
          Plane.PlaneSide.__\u003C\u003Efront
        };
      }

      [Modifiers]
      public static Plane.PlaneSide onPlane
      {
        [HideFromJava] get => Plane.PlaneSide.__\u003C\u003EonPlane;
      }

      [Modifiers]
      public static Plane.PlaneSide back
      {
        [HideFromJava] get => Plane.PlaneSide.__\u003C\u003Eback;
      }

      [Modifiers]
      public static Plane.PlaneSide front
      {
        [HideFromJava] get => Plane.PlaneSide.__\u003C\u003Efront;
      }

      [HideFromJava]
      [Serializable]
      public enum __Enum
      {
        onPlane,
        back,
        front,
      }
    }
  }
}
