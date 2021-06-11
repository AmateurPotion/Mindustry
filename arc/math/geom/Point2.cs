// Decompiled with JetBrains decompiler
// Type: arc.math.geom.Point2
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;

namespace arc.math.geom
{
  public class Point2 : Object
  {
    public int x;
    public int y;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int pack(int x, int y) => (int) (short) x << 16 | (int) (short) y & (int) ushort.MaxValue;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static short x(int pos) => (short) ((uint) pos >> 16);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static short y(int pos) => (short) (pos & (int) ushort.MaxValue);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool equals(int x, int y, int ox, int oy) => x == ox && y == oy;

    [LineNumberTable(new byte[] {159, 162, 104, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Point2(int x, int y)
    {
      Point2 point2 = this;
      this.x = x;
      this.y = y;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool equals(int x, int y) => this.x == x && this.y == y;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Point2 set(int x, int y)
    {
      this.x = x;
      this.y = y;
      return this;
    }

    [LineNumberTable(new byte[] {107, 115, 115})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Point2 sub(Point2 other)
    {
      this.x -= other.x;
      this.y -= other.y;
      return this;
    }

    [LineNumberTable(new byte[] {84, 115, 115})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Point2 add(Point2 other)
    {
      this.x += other.x;
      this.y += other.y;
      return this;
    }

    [LineNumberTable(new byte[] {119, 110, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Point2 sub(int x, int y)
    {
      this.x -= x;
      this.y -= y;
      return this;
    }

    [LineNumberTable(new byte[] {15, 108, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Point2 set(Point2 point)
    {
      this.x = point.x;
      this.y = point.y;
      return this;
    }

    [LineNumberTable(new byte[] {159, 154, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Point2()
    {
    }

    [LineNumberTable(178)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Point2 cpy() => new Point2(this);

    [LineNumberTable(36)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Point2 unpack(int pos) => new Point2((int) (short) ((uint) pos >> 16), (int) (short) (pos & (int) ushort.MaxValue));

    [LineNumberTable(56)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int pack() => Point2.pack(this.x, this.y);

    [LineNumberTable(new byte[] {159, 171, 104, 108, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Point2(Point2 point)
    {
      Point2 point2 = this;
      this.x = point.x;
      this.y = point.y;
    }

    [LineNumberTable(new byte[] {37, 110, 142})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float dst2(Point2 other)
    {
      int num1 = other.x - this.x;
      int num2 = other.y - this.y;
      return (float) (num1 * num1 + num2 * num2);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float dst2(int x, int y)
    {
      int num1 = x - this.x;
      int num2 = y - this.y;
      return (float) (num1 * num1 + num2 * num2);
    }

    [LineNumberTable(new byte[] {60, 110, 142})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float dst(Point2 other)
    {
      int num1 = other.x - this.x;
      int num2 = other.y - this.y;
      return (float) Math.sqrt((double) (num1 * num1 + num2 * num2));
    }

    [LineNumberTable(new byte[] {72, 105, 137})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float dst(int x, int y)
    {
      int num1 = x - this.x;
      int num2 = y - this.y;
      return (float) Math.sqrt((double) (num1 * num1 + num2 * num2));
    }

    [LineNumberTable(new byte[] {96, 110, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Point2 add(int x, int y)
    {
      this.x += x;
      this.y += y;
      return this;
    }

    [LineNumberTable(new byte[] {160, 69, 107, 103, 100, 109, 137, 108, 232, 57, 230, 74})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Point2 rotate(int steps)
    {
      for (int index = 0; index < Math.abs(steps); ++index)
      {
        int x = this.x;
        if (steps >= 0)
        {
          this.x = -this.y;
          this.y = x;
        }
        else
        {
          this.x = this.y;
          this.y = -x;
        }
      }
      return this;
    }

    [LineNumberTable(new byte[] {160, 92, 107, 120, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool equals(object o)
    {
      if (object.ReferenceEquals((object) this, o))
        return true;
      if (o == null || !object.ReferenceEquals((object) o.GetType(), (object) ((object) this).GetType()))
        return false;
      Point2 point2 = (Point2) o;
      return this.x == point2.x && this.y == point2.y;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int hashCode() => this.x * 49471 + this.y * 37345;

    [LineNumberTable(219)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toString() => new StringBuilder().append("(").append(this.x).append(", ").append(this.y).append(")").toString();
  }
}
