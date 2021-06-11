// Decompiled with JetBrains decompiler
// Type: arc.math.geom.Circle
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System.Runtime.CompilerServices;

namespace arc.math.geom
{
  public class Circle : Object, Shape2D
  {
    public float x;
    public float y;
    public float radius;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Circle set(float x, float y, float radius)
    {
      this.x = x;
      this.y = y;
      this.radius = radius;
      return this;
    }

    [LineNumberTable(new byte[] {159, 156, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Circle()
    {
    }

    [LineNumberTable(new byte[] {159, 166, 104, 104, 104, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Circle(float x, float y, float radius)
    {
      Circle circle = this;
      this.x = x;
      this.y = y;
      this.radius = radius;
    }

    [LineNumberTable(new byte[] {159, 177, 104, 108, 108, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Circle(Vec2 position, float radius)
    {
      Circle circle = this;
      this.x = position.x;
      this.y = position.y;
      this.radius = radius;
    }

    [LineNumberTable(new byte[] {159, 187, 104, 108, 108, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Circle(Circle circle)
    {
      Circle circle1 = this;
      this.x = circle.x;
      this.y = circle.y;
      this.radius = circle.radius;
    }

    [LineNumberTable(new byte[] {6, 104, 108, 108, 127, 9})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Circle(Vec2 center, Vec2 edge)
    {
      Circle circle = this;
      this.x = center.x;
      this.y = center.y;
      this.radius = Mathf.len(center.x - edge.x, center.y - edge.y);
    }

    [LineNumberTable(new byte[] {31, 108, 108, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Circle set(Vec2 position, float radius)
    {
      this.x = position.x;
      this.y = position.y;
      this.radius = radius;
      return this;
    }

    [LineNumberTable(new byte[] {42, 108, 108, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Circle set(Circle circle)
    {
      this.x = circle.x;
      this.y = circle.y;
      this.radius = circle.radius;
      return this;
    }

    [LineNumberTable(new byte[] {54, 108, 108, 127, 9})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Circle set(Vec2 center, Vec2 edge)
    {
      this.x = center.x;
      this.y = center.y;
      this.radius = Mathf.len(center.x - edge.x, center.y - edge.y);
      return this;
    }

    [LineNumberTable(new byte[] {65, 108, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Circle setPosition(Vec2 position)
    {
      this.x = position.x;
      this.y = position.y;
      return this;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Circle setPosition(float x, float y)
    {
      this.x = x;
      this.y = y;
      return this;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setX(float x) => this.x = x;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setY(float y) => this.y = y;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setRadius(float radius) => this.radius = radius;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool contains(float x, float y)
    {
      x = this.x - x;
      y = this.y - y;
      return (double) (x * x + y * y) <= (double) (this.radius * this.radius);
    }

    [LineNumberTable(new byte[] {123, 111, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool contains(Vec2 point)
    {
      float num1 = this.x - point.x;
      float num2 = this.y - point.y;
      return (double) (num1 * num1 + num2 * num2) <= (double) (this.radius * this.radius);
    }

    [LineNumberTable(new byte[] {160, 69, 111, 106, 111, 111, 107, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool contains(Circle c)
    {
      float num1 = this.radius - c.radius;
      if ((double) num1 < 0.0)
        return false;
      float num2 = this.x - c.x;
      float num3 = this.y - c.y;
      float num4 = num2 * num2 + num3 * num3;
      float num5 = this.radius + c.radius;
      return (double) (num1 * num1) >= (double) num4 && (double) num4 < (double) (num5 * num5);
    }

    [LineNumberTable(new byte[] {160, 83, 111, 111, 107, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool overlaps(Circle c)
    {
      float num1 = this.x - c.x;
      float num2 = this.y - c.y;
      float num3 = num1 * num1 + num2 * num2;
      float num4 = this.radius + c.radius;
      return (double) num3 < (double) (num4 * num4);
    }

    [LineNumberTable(207)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toString() => new StringBuilder().append(this.x).append(",").append(this.y).append(",").append(this.radius).toString();

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float circumference() => this.radius * 6.283185f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float area() => this.radius * this.radius * 3.141593f;

    [LineNumberTable(new byte[] {160, 108, 107, 120, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool equals(object o)
    {
      if (object.ReferenceEquals(o, (object) this))
        return true;
      if (o == null || !object.ReferenceEquals((object) o.GetType(), (object) ((object) this).GetType()))
        return false;
      Circle circle = (Circle) o;
      return (double) this.x == (double) circle.x && (double) this.y == (double) circle.y && (double) this.radius == (double) circle.radius;
    }

    [LineNumberTable(new byte[] {160, 116, 99, 98, 115, 115, 115})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int hashCode()
    {
      FloatConverter floatConverter;
      return 41 * (41 * (41 * 1 + FloatConverter.ToInt(this.radius, ref floatConverter)) + FloatConverter.ToInt(this.x, ref floatConverter)) + FloatConverter.ToInt(this.y, ref floatConverter);
    }
  }
}
