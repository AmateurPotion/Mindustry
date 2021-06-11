// Decompiled with JetBrains decompiler
// Type: arc.math.geom.Polyline
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;

namespace arc.math.geom
{
  public class Polyline : Object, Shape2D
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
    private float length;
    private float scaledLength;
    private bool calculateScaledLength;
    private bool calculateLength;
    private bool dirty;

    [LineNumberTable(new byte[] {159, 160, 232, 57, 182, 103, 103, 167, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Polyline()
    {
      Polyline polyline = this;
      this.scaleX = 1f;
      this.scaleY = 1f;
      this.calculateScaledLength = true;
      this.calculateLength = true;
      this.dirty = true;
      this.localVertices = new float[0];
    }

    [LineNumberTable(new byte[] {159, 164, 232, 53, 182, 103, 103, 231, 71, 117, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Polyline(float[] vertices)
    {
      Polyline polyline = this;
      this.scaleX = 1f;
      this.scaleY = 1f;
      this.calculateScaledLength = true;
      this.calculateLength = true;
      this.dirty = true;
      if (vertices.Length < 4)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException("polylines must contain at least 2 points.");
      }
      this.localVertices = vertices;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float[] getVertices() => this.localVertices;

    [LineNumberTable(new byte[] {159, 175, 117, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setVertices(float[] vertices)
    {
      if (vertices.Length < 4)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException("polylines must contain at least 2 points.");
      }
      this.localVertices = vertices;
      this.dirty = true;
    }

    [LineNumberTable(new byte[] {159, 182, 111, 135, 103, 115, 141, 103, 103, 103, 104, 104, 104, 104, 120, 104, 106, 138, 112, 106, 172, 100, 104, 200, 105, 100, 112, 176, 109, 239, 46, 235, 84})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float[] getTransformedVertices()
    {
      if (!this.dirty)
        return this.worldVertices;
      this.dirty = false;
      float[] localVertices = this.localVertices;
      if (this.worldVertices == null || this.worldVertices.Length < localVertices.Length)
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

    [LineNumberTable(new byte[] {34, 111, 135, 107, 112, 117, 119, 255, 1, 61, 233, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getLength()
    {
      if (!this.calculateLength)
        return this.length;
      this.calculateLength = false;
      this.length = 0.0f;
      int index1 = 0;
      for (int index2 = this.localVertices.Length - 2; index1 < index2; index1 += 2)
      {
        float num1 = this.localVertices[index1 + 2] - this.localVertices[index1];
        float num2 = this.localVertices[index1 + 1] - this.localVertices[index1 + 3];
        this.length += (float) Math.sqrt((double) (num1 * num1 + num2 * num2));
      }
      return this.length;
    }

    [LineNumberTable(new byte[] {49, 111, 135, 107, 115, 127, 6, 127, 8, 255, 1, 61, 233, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getScaledLength()
    {
      if (!this.calculateScaledLength)
        return this.scaledLength;
      this.calculateScaledLength = false;
      this.scaledLength = 0.0f;
      int index1 = 0;
      for (int index2 = this.localVertices.Length - 2; index1 < index2; index1 += 2)
      {
        float num1 = this.localVertices[index1 + 2] * this.scaleX - this.localVertices[index1] * this.scaleX;
        float num2 = this.localVertices[index1 + 1] * this.scaleY - this.localVertices[index1 + 3] * this.scaleY;
        this.scaledLength += (float) Math.sqrt((double) (num1 * num1 + num2 * num2));
      }
      return this.scaledLength;
    }

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

    [LineNumberTable(new byte[] {108, 112, 103})]
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
      this.calculateScaledLength = true;
    }

    [LineNumberTable(new byte[] {120, 112, 112, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void scale(float amount)
    {
      this.scaleX += amount;
      this.scaleY += amount;
      this.dirty = true;
      this.calculateScaledLength = true;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void calculateLength() => this.calculateLength = true;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void calculateScaledLength() => this.calculateScaledLength = true;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void dirty() => this.dirty = true;

    [LineNumberTable(new byte[] {160, 75, 112, 112, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void translate(float x, float y)
    {
      this.x += x;
      this.y += y;
      this.dirty = true;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool contains(Vec2 point) => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool contains(float x, float y) => false;
  }
}
