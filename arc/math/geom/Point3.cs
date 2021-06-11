// Decompiled with JetBrains decompiler
// Type: arc.math.geom.Point3
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;

namespace arc.math.geom
{
  public class Point3 : Object
  {
    private const long serialVersionUID = 5922187982746752830;
    public int x;
    public int y;
    public int z;

    [LineNumberTable(new byte[] {159, 176, 104, 108, 108, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Point3(Point3 point)
    {
      Point3 point3 = this;
      this.x = point.x;
      this.y = point.y;
      this.z = point.z;
    }

    [LineNumberTable(new byte[] {159, 157, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Point3()
    {
    }

    [LineNumberTable(new byte[] {159, 166, 104, 103, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Point3(int x, int y, int z)
    {
      Point3 point3 = this;
      this.x = x;
      this.y = y;
      this.z = z;
    }

    [LineNumberTable(new byte[] {159, 188, 108, 108, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Point3 set(Point3 point)
    {
      this.x = point.x;
      this.y = point.y;
      this.z = point.z;
      return this;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Point3 set(int x, int y, int z)
    {
      this.x = x;
      this.y = y;
      this.z = z;
      return this;
    }

    [LineNumberTable(new byte[] {21, 110, 110, 142})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float dst2(Point3 other)
    {
      int num1 = other.x - this.x;
      int num2 = other.y - this.y;
      int num3 = other.z - this.z;
      return (float) (num1 * num1 + num2 * num2 + num3 * num3);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float dst2(int x, int y, int z)
    {
      int num1 = x - this.x;
      int num2 = y - this.y;
      int num3 = z - this.z;
      return (float) (num1 * num1 + num2 * num2 + num3 * num3);
    }

    [LineNumberTable(new byte[] {47, 110, 110, 142})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float dst(Point3 other)
    {
      int num1 = other.x - this.x;
      int num2 = other.y - this.y;
      int num3 = other.z - this.z;
      return (float) Math.sqrt((double) (num1 * num1 + num2 * num2 + num3 * num3));
    }

    [LineNumberTable(new byte[] {61, 105, 105, 137})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float dst(int x, int y, int z)
    {
      int num1 = x - this.x;
      int num2 = y - this.y;
      int num3 = z - this.z;
      return (float) Math.sqrt((double) (num1 * num1 + num2 * num2 + num3 * num3));
    }

    [LineNumberTable(new byte[] {74, 115, 115, 115})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Point3 add(Point3 other)
    {
      this.x += other.x;
      this.y += other.y;
      this.z += other.z;
      return this;
    }

    [LineNumberTable(new byte[] {88, 110, 110, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Point3 add(int x, int y, int z)
    {
      this.x += x;
      this.y += y;
      this.z += z;
      return this;
    }

    [LineNumberTable(new byte[] {100, 115, 115, 115})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Point3 sub(Point3 other)
    {
      this.x -= other.x;
      this.y -= other.y;
      this.z -= other.z;
      return this;
    }

    [LineNumberTable(new byte[] {114, 110, 110, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Point3 sub(int x, int y, int z)
    {
      this.x -= x;
      this.y -= y;
      this.z -= z;
      return this;
    }

    [LineNumberTable(174)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Point3 cpy() => new Point3(this);

    [LineNumberTable(new byte[] {160, 65, 107, 120, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool equals(object o)
    {
      if (object.ReferenceEquals((object) this, o))
        return true;
      if (o == null || !object.ReferenceEquals((object) o.GetType(), (object) ((object) this).GetType()))
        return false;
      Point3 point3 = (Point3) o;
      return this.x == point3.x && this.y == point3.y && this.z == point3.z;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int hashCode() => 17 * (17 * (17 * 1 + this.x) + this.y) + this.z;

    [LineNumberTable(197)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toString() => new StringBuilder().append("(").append(this.x).append(", ").append(this.y).append(", ").append(this.z).append(")").toString();
  }
}
