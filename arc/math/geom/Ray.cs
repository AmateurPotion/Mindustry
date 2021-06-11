// Decompiled with JetBrains decompiler
// Type: arc.math.geom.Ray
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.math.geom
{
  public class Ray : Object
  {
    internal Vec3 __\u003C\u003Eorigin;
    internal Vec3 __\u003C\u003Edirection;

    [LineNumberTable(new byte[] {159, 161, 232, 53, 107, 235, 75, 109, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Ray(Vec3 origin, Vec3 direction)
    {
      Ray ray = this;
      this.__\u003C\u003Eorigin = new Vec3();
      this.__\u003C\u003Edirection = new Vec3();
      this.__\u003C\u003Eorigin.set(origin);
      this.__\u003C\u003Edirection.set(direction).nor();
    }

    [LineNumberTable(36)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec3 getEndPoint(Vec3 @out, float distance) => @out.set(this.__\u003C\u003Edirection).scl(distance).add(this.__\u003C\u003Eorigin);

    [LineNumberTable(new byte[] {159, 153, 232, 61, 107, 171})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Ray()
    {
      Ray ray = this;
      this.__\u003C\u003Eorigin = new Vec3();
      this.__\u003C\u003Edirection = new Vec3();
    }

    [LineNumberTable(26)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Ray cpy() => new Ray(this.__\u003C\u003Eorigin, this.__\u003C\u003Edirection);

    [LineNumberTable(new byte[] {159, 188, 109, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Ray set(Vec3 origin, Vec3 direction)
    {
      this.__\u003C\u003Eorigin.set(origin);
      this.__\u003C\u003Edirection.set(direction);
      return this;
    }

    [LineNumberTable(new byte[] {12, 114, 117})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Ray set(float x, float y, float z, float dx, float dy, float dz)
    {
      this.__\u003C\u003Eorigin.set(x, y, z);
      this.__\u003C\u003Edirection.set(dx, dy, dz);
      return this;
    }

    [LineNumberTable(new byte[] {23, 114, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Ray set(Ray ray)
    {
      this.__\u003C\u003Eorigin.set(ray.__\u003C\u003Eorigin);
      this.__\u003C\u003Edirection.set(ray.__\u003C\u003Edirection);
      return this;
    }

    [LineNumberTable(81)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toString() => new StringBuilder().append("ray [").append((object) this.__\u003C\u003Eorigin).append(":").append((object) this.__\u003C\u003Edirection).append("]").toString();

    [LineNumberTable(new byte[] {36, 107, 120, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool equals(object o)
    {
      if (object.ReferenceEquals(o, (object) this))
        return true;
      if (o == null || !object.ReferenceEquals((object) o.GetType(), (object) ((object) this).GetType()))
        return false;
      Ray ray = (Ray) o;
      return this.__\u003C\u003Edirection.equals((object) ray.__\u003C\u003Edirection) && this.__\u003C\u003Eorigin.equals((object) ray.__\u003C\u003Eorigin);
    }

    [LineNumberTable(new byte[] {44, 99, 98, 113, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int hashCode() => 73 * (73 * 1 + this.__\u003C\u003Edirection.hashCode()) + this.__\u003C\u003Eorigin.hashCode();

    [Modifiers]
    public Vec3 origin
    {
      [HideFromJava] get => this.__\u003C\u003Eorigin;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Eorigin = value;
    }

    [Modifiers]
    public Vec3 direction
    {
      [HideFromJava] get => this.__\u003C\u003Edirection;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Edirection = value;
    }
  }
}
