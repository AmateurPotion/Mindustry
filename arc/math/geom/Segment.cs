// Decompiled with JetBrains decompiler
// Type: arc.math.geom.Segment
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.math.geom
{
  public class Segment : Object
  {
    internal Vec3 __\u003C\u003Ea;
    internal Vec3 __\u003C\u003Eb;

    [LineNumberTable(new byte[] {159, 160, 232, 55, 139, 235, 72, 109, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Segment(Vec3 a, Vec3 b)
    {
      Segment segment = this;
      this.__\u003C\u003Ea = new Vec3();
      this.__\u003C\u003Eb = new Vec3();
      this.__\u003C\u003Ea.set(a);
      this.__\u003C\u003Eb.set(b);
    }

    [LineNumberTable(new byte[] {159, 174, 232, 41, 139, 235, 86, 114, 117})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Segment(float aX, float aY, float aZ, float bX, float bY, float bZ)
    {
      Segment segment = this;
      this.__\u003C\u003Ea = new Vec3();
      this.__\u003C\u003Eb = new Vec3();
      this.__\u003C\u003Ea.set(aX, aY, aZ);
      this.__\u003C\u003Eb.set(bX, bY, bZ);
    }

    [LineNumberTable(38)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float len() => this.__\u003C\u003Ea.dst(this.__\u003C\u003Eb);

    [LineNumberTable(42)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float len2() => this.__\u003C\u003Ea.dst2(this.__\u003C\u003Eb);

    [LineNumberTable(new byte[] {159, 189, 107, 120, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool equals(object o)
    {
      if (object.ReferenceEquals(o, (object) this))
        return true;
      if (o == null || !object.ReferenceEquals((object) o.GetType(), (object) ((object) this).GetType()))
        return false;
      Segment segment = (Segment) o;
      return this.__\u003C\u003Ea.equals((object) segment.__\u003C\u003Ea) && this.__\u003C\u003Eb.equals((object) segment.__\u003C\u003Eb);
    }

    [LineNumberTable(new byte[] {5, 99, 98, 113, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int hashCode() => 71 * (71 * 1 + this.__\u003C\u003Ea.hashCode()) + this.__\u003C\u003Eb.hashCode();

    [Modifiers]
    public Vec3 a
    {
      [HideFromJava] get => this.__\u003C\u003Ea;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Ea = value;
    }

    [Modifiers]
    public Vec3 b
    {
      [HideFromJava] get => this.__\u003C\u003Eb;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Eb = value;
    }
  }
}
