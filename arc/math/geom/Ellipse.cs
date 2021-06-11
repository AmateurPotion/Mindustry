// Decompiled with JetBrains decompiler
// Type: arc.math.geom.Ellipse
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System.Runtime.CompilerServices;

namespace arc.math.geom
{
  public class Ellipse : Object, Shape2D
  {
    public float x;
    public float y;
    public float width;
    public float height;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool contains(float x, float y)
    {
      x -= this.x;
      y -= this.y;
      return (double) (x * x / (this.width * 0.5f * this.width * 0.5f) + y * y / (this.height * 0.5f * this.height * 0.5f)) <= 1.0;
    }

    [LineNumberTable(new byte[] {159, 156, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Ellipse()
    {
    }

    [LineNumberTable(new byte[] {159, 164, 104, 108, 108, 108, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Ellipse(Ellipse ellipse)
    {
      Ellipse ellipse1 = this;
      this.x = ellipse.x;
      this.y = ellipse.y;
      this.width = ellipse.width;
      this.height = ellipse.height;
    }

    [LineNumberTable(new byte[] {159, 178, 104, 104, 104, 104, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Ellipse(float x, float y, float width, float height)
    {
      Ellipse ellipse = this;
      this.x = x;
      this.y = y;
      this.width = width;
      this.height = height;
    }

    [LineNumberTable(new byte[] {159, 191, 104, 108, 108, 104, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Ellipse(Vec2 position, float width, float height)
    {
      Ellipse ellipse = this;
      this.x = position.x;
      this.y = position.y;
      this.width = width;
      this.height = height;
    }

    [LineNumberTable(new byte[] {6, 104, 108, 108, 108, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Ellipse(Vec2 position, Vec2 size)
    {
      Ellipse ellipse = this;
      this.x = position.x;
      this.y = position.y;
      this.width = size.x;
      this.height = size.y;
    }

    [LineNumberTable(new byte[] {18, 104, 108, 108, 115, 115})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Ellipse(Circle circle)
    {
      Ellipse ellipse = this;
      this.x = circle.x;
      this.y = circle.y;
      this.width = circle.radius * 2f;
      this.height = circle.radius * 2f;
    }

    [LineNumberTable(94)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool contains(Vec2 point) => this.contains(point.x, point.y);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void set(float x, float y, float width, float height)
    {
      this.x = x;
      this.y = y;
      this.width = width;
      this.height = height;
    }

    [LineNumberTable(new byte[] {66, 108, 108, 108, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void set(Ellipse ellipse)
    {
      this.x = ellipse.x;
      this.y = ellipse.y;
      this.width = ellipse.width;
      this.height = ellipse.height;
    }

    [LineNumberTable(new byte[] {73, 108, 108, 115, 115})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void set(Circle circle)
    {
      this.x = circle.x;
      this.y = circle.y;
      this.width = circle.radius * 2f;
      this.height = circle.radius * 2f;
    }

    [LineNumberTable(new byte[] {80, 108, 108, 108, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void set(Vec2 position, Vec2 size)
    {
      this.x = position.x;
      this.y = position.y;
      this.width = size.x;
      this.height = size.y;
    }

    [LineNumberTable(new byte[] {92, 108, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Ellipse setPosition(Vec2 position)
    {
      this.x = position.x;
      this.y = position.y;
      return this;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Ellipse setPosition(float x, float y)
    {
      this.x = x;
      this.y = y;
      return this;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Ellipse setSize(float width, float height)
    {
      this.width = width;
      this.height = height;
      return this;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float area() => 3.141593f * (this.width * this.height) / 4f;

    [LineNumberTable(new byte[] {160, 72, 110, 110, 150, 191, 27})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float circumference()
    {
      float num1 = this.width / 2f;
      float num2 = this.height / 2f;
      return (double) (num1 * 3f) > (double) num2 || (double) (num2 * 3f) > (double) num1 ? (float) (3.14159274101257 * ((double) (3f * (num1 + num2)) - Math.sqrt((double) ((3f * num1 + num2) * (num1 + 3f * num2))))) : (float) (6.28318548202515 * Math.sqrt((double) ((num1 * num1 + num2 * num2) / 2f)));
    }

    [LineNumberTable(new byte[] {160, 85, 107, 120, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool equals(object o)
    {
      if (object.ReferenceEquals(o, (object) this))
        return true;
      if (o == null || !object.ReferenceEquals((object) o.GetType(), (object) ((object) this).GetType()))
        return false;
      Ellipse ellipse = (Ellipse) o;
      return (double) this.x == (double) ellipse.x && (double) this.y == (double) ellipse.y && ((double) this.width == (double) ellipse.width && (double) this.height == (double) ellipse.height);
    }

    [LineNumberTable(new byte[] {160, 93, 99, 98, 115, 115, 115, 115})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int hashCode()
    {
      FloatConverter floatConverter;
      return 53 * (53 * (53 * (53 * 1 + FloatConverter.ToInt(this.height, ref floatConverter)) + FloatConverter.ToInt(this.width, ref floatConverter)) + FloatConverter.ToInt(this.x, ref floatConverter)) + FloatConverter.ToInt(this.y, ref floatConverter);
    }
  }
}
