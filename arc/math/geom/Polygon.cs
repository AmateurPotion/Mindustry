// Decompiled with JetBrains decompiler
// Type: arc.math.geom.Polygon
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;

namespace arc.math.geom
{
  public class Polygon : Object, Shape2D
  {
    private float[] localVertices;
    private float[] worldVertices;
    private float x;
    private float y;
    private float originX;
    private float originY;
    private float rotation;
    private float scaleX;
    private float scaleY;
    private bool dirty;
    private Rect bounds;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float[] getVertices() => this.localVertices;

    [LineNumberTable(new byte[] {5, 111, 135, 103, 115, 141, 103, 103, 103, 104, 104, 104, 104, 120, 104, 106, 138, 112, 106, 172, 100, 104, 200, 105, 100, 112, 176, 109, 239, 46, 235, 84})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float[] getTransformedVertices()
    {
      if (!this.dirty)
        return this.worldVertices;
      this.dirty = false;
      float[] localVertices = this.localVertices;
      if (this.worldVertices == null || this.worldVertices.Length != localVertices.Length)
        this.worldVertices = new float[localVertices.Length];
      float[] worldVertices = this.worldVertices;
      float x = this.x;
      float y = this.y;
      float originX = this.originX;
      float originY = this.originY;
      float scaleX = this.scaleX;
      float scaleY = this.scaleY;
      int num1 = (double) scaleX != 1.0 || (double) scaleY != 1.0 ? 1 : 0;
      float rotation = this.rotation;
      float num2 = Mathf.cosDeg(rotation);
      float num3 = Mathf.sinDeg(rotation);
      int index = 0;
      for (int length = localVertices.Length; index < length; index += 2)
      {
        float num4 = localVertices[index] - originX;
        float num5 = localVertices[index + 1] - originY;
        if (num1 != 0)
        {
          num4 *= scaleX;
          num5 *= scaleY;
        }
        if ((double) rotation != 0.0)
        {
          float num6 = num4;
          num4 = num2 * num4 - num3 * num5;
          num5 = num3 * num6 + num2 * num5;
        }
        worldVertices[index] = x + num4 + originX;
        worldVertices[index + 1] = y + num5 + originY;
      }
      return worldVertices;
    }

    [LineNumberTable(new byte[] {159, 186, 117, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setVertices(float[] vertices)
    {
      if (vertices.Length < 6)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException("polygons must contain at least 3 points.");
      }
      this.localVertices = vertices;
      this.dirty = true;
    }

    [LineNumberTable(new byte[] {160, 69, 103, 99, 130, 105, 101, 103, 114, 114, 127, 23, 228, 58, 233, 72})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool contains(float x, float y)
    {
      float[] transformedVertices = this.getTransformedVertices();
      int length = transformedVertices.Length;
      int num1 = 0;
      for (int index1 = 0; index1 < length; index1 += 2)
      {
        float num2 = transformedVertices[index1];
        float num3 = transformedVertices[index1 + 1];
        float[] numArray1 = transformedVertices;
        int num4 = index1 + 2;
        int num5 = length;
        int index2 = num5 != -1 ? num4 % num5 : 0;
        float num6 = numArray1[index2];
        float[] numArray2 = transformedVertices;
        int num7 = index1 + 3;
        int num8 = length;
        int index3 = num8 != -1 ? num7 % num8 : 0;
        float num9 = numArray2[index3];
        if (((double) num3 <= (double) y && (double) y < (double) num9 || (double) num9 <= (double) y && (double) y < (double) num3) && (double) x < (double) ((num6 - num2) / (num9 - num3) * (y - num3) + num2))
          ++num1;
      }
      return (num1 & 1) == 1;
    }

    [LineNumberTable(new byte[] {159, 159, 232, 59, 118, 231, 69, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Polygon()
    {
      Polygon polygon = this;
      this.scaleX = 1f;
      this.scaleY = 1f;
      this.dirty = true;
      this.localVertices = new float[0];
    }

    [LineNumberTable(new byte[] {159, 169, 232, 49, 118, 231, 79, 117, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Polygon(float[] vertices)
    {
      Polygon polygon = this;
      this.scaleX = 1f;
      this.scaleY = 1f;
      this.dirty = true;
      if (vertices.Length < 6)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException("polygons must contain at least 3 points.");
      }
      this.localVertices = vertices;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setOrigin(float originX, float originY)
    {
      this.originX = originX;
      this.originY = originY;
      this.dirty = true;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setPosition(float x, float y)
    {
      this.x = x;
      this.y = y;
      this.dirty = true;
    }

    [LineNumberTable(new byte[] {63, 112, 112, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void translate(float x, float y)
    {
      this.x += x;
      this.y += y;
      this.dirty = true;
    }

    [LineNumberTable(new byte[] {70, 112, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void rotate(float degrees)
    {
      this.rotation += degrees;
      this.dirty = true;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setScale(float scaleX, float scaleY)
    {
      this.scaleX = scaleX;
      this.scaleY = scaleY;
      this.dirty = true;
    }

    [LineNumberTable(new byte[] {83, 112, 112, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void scale(float amount)
    {
      this.scaleX += amount;
      this.scaleY += amount;
      this.dirty = true;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void dirty() => this.dirty = true;

    [LineNumberTable(new byte[] {95, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float area()
    {
      float[] transformedVertices = this.getTransformedVertices();
      return Geometry.polygonArea(transformedVertices, 0, transformedVertices.Length);
    }

    [LineNumberTable(new byte[] {106, 135, 100, 100, 100, 133, 100, 108, 111, 115, 111, 246, 60, 235, 71, 115, 108, 108, 111, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Rect getBoundingRectangle()
    {
      float[] transformedVertices = this.getTransformedVertices();
      float num1 = transformedVertices[0];
      float num2 = transformedVertices[1];
      float num3 = transformedVertices[0];
      float num4 = transformedVertices[1];
      int length = transformedVertices.Length;
      for (int index = 2; index < length; index += 2)
      {
        num1 = (double) num1 <= (double) transformedVertices[index] ? num1 : transformedVertices[index];
        num2 = (double) num2 <= (double) transformedVertices[index + 1] ? num2 : transformedVertices[index + 1];
        num3 = (double) num3 >= (double) transformedVertices[index] ? num3 : transformedVertices[index];
        num4 = (double) num4 >= (double) transformedVertices[index + 1] ? num4 : transformedVertices[index + 1];
      }
      if (this.bounds == null)
        this.bounds = new Rect();
      this.bounds.x = num1;
      this.bounds.y = num2;
      this.bounds.width = num3 - num1;
      this.bounds.height = num4 - num2;
      return this.bounds;
    }

    [LineNumberTable(200)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool contains(Vec2 point) => this.contains(point.x, point.y);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getX() => this.x;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getY() => this.y;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getOriginX() => this.originX;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getOriginY() => this.originY;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getRotation() => this.rotation;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setRotation(float degrees)
    {
      this.rotation = degrees;
      this.dirty = true;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getScaleX() => this.scaleX;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getScaleY() => this.scaleY;
  }
}
