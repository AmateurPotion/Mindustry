// Decompiled with JetBrains decompiler
// Type: arc.math.geom.Sphere
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.math.geom
{
  public class Sphere : Object
  {
    private const float PI_4_3 = 4.18879f;
    internal Vec3 __\u003C\u003Ecenter;
    public float radius;

    [LineNumberTable(new byte[] {159, 163, 104, 108, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Sphere(Vec3 center, float radius)
    {
      Sphere sphere = this;
      this.__\u003C\u003Ecenter = new Vec3(center);
      this.radius = radius;
    }

    [LineNumberTable(31)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool overlaps(Sphere sphere) => (double) this.__\u003C\u003Ecenter.dst2(sphere.__\u003C\u003Ecenter) < (double) ((this.radius + sphere.radius) * (this.radius + sphere.radius));

    [LineNumberTable(new byte[] {159, 178, 99, 98, 113, 115})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int hashCode()
    {
      FloatConverter floatConverter;
      return 71 * (71 * 1 + this.__\u003C\u003Ecenter.hashCode()) + FloatConverter.ToInt(this.radius, ref floatConverter);
    }

    [LineNumberTable(new byte[] {159, 187, 107, 120, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool equals(object o)
    {
      if (object.ReferenceEquals((object) this, o))
        return true;
      if (o == null || !object.ReferenceEquals((object) o.GetType(), (object) ((object) this).GetType()))
        return false;
      Sphere sphere = (Sphere) o;
      return (double) this.radius == (double) sphere.radius && this.__\u003C\u003Ecenter.equals((object) sphere.__\u003C\u003Ecenter);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float volume() => 4.18879f * this.radius * this.radius * this.radius;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float surfaceArea() => 12.56637f * this.radius * this.radius;

    [Modifiers]
    public Vec3 center
    {
      [HideFromJava] get => this.__\u003C\u003Ecenter;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Ecenter = value;
    }
  }
}
