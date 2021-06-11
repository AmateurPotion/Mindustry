// Decompiled with JetBrains decompiler
// Type: arc.math.Affine2
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.math.geom;
using arc.util;
using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;

namespace arc.math
{
  public sealed class Affine2 : Object
  {
    public float m00;
    public float m01;
    public float m02;
    public float m10;
    public float m11;
    public float m12;

    [LineNumberTable(new byte[] {159, 162, 232, 58, 127, 2, 255, 2, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Affine2()
    {
      Affine2 affine2 = this;
      this.m00 = 1f;
      this.m01 = 0.0f;
      this.m02 = 0.0f;
      this.m10 = 0.0f;
      this.m11 = 1f;
      this.m12 = 0.0f;
    }

    [LineNumberTable(new byte[] {160, 101, 104, 136, 105, 105, 107, 107, 139, 105, 137, 108, 109, 108, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Affine2 setToTrnRotScl(
      float x,
      float y,
      float degrees,
      float scaleX,
      float scaleY)
    {
      this.m02 = x;
      this.m12 = y;
      if ((double) degrees == 0.0)
      {
        this.m00 = scaleX;
        this.m01 = 0.0f;
        this.m10 = 0.0f;
        this.m11 = scaleY;
      }
      else
      {
        float num1 = Mathf.sinDeg(degrees);
        float num2 = Mathf.cosDeg(degrees);
        this.m00 = num2 * scaleX;
        this.m01 = -num1 * scaleY;
        this.m10 = num1 * scaleX;
        this.m11 = num2 * scaleY;
      }
      return this;
    }

    [LineNumberTable(new byte[] {161, 52, 127, 5, 127, 5})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Affine2 translate(float x, float y)
    {
      this.m02 += this.m00 * x + this.m01 * y;
      this.m12 += this.m10 * x + this.m11 * y;
      return this;
    }

    [LineNumberTable(new byte[] {161, 29, 127, 0, 127, 0, 127, 8, 127, 0, 127, 1, 159, 9, 103, 103, 103, 103, 104, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Affine2 preMul(Affine2 other)
    {
      float num1 = other.m00 * this.m00 + other.m01 * this.m10;
      float num2 = other.m00 * this.m01 + other.m01 * this.m11;
      float num3 = other.m00 * this.m02 + other.m01 * this.m12 + other.m02;
      float num4 = other.m10 * this.m00 + other.m11 * this.m10;
      float num5 = other.m10 * this.m01 + other.m11 * this.m11;
      float num6 = other.m10 * this.m02 + other.m11 * this.m12 + other.m12;
      this.m00 = num1;
      this.m01 = num2;
      this.m02 = num3;
      this.m10 = num4;
      this.m11 = num5;
      this.m12 = num6;
      return this;
    }

    [LineNumberTable(new byte[] {1, 108, 108, 108, 108, 108, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Affine2 set(Affine2 other)
    {
      this.m00 = other.m00;
      this.m01 = other.m01;
      this.m02 = other.m02;
      this.m10 = other.m10;
      this.m11 = other.m11;
      this.m12 = other.m12;
      return this;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Affine2 setToTranslation(float x, float y)
    {
      this.m00 = 1f;
      this.m01 = 0.0f;
      this.m02 = x;
      this.m10 = 0.0f;
      this.m11 = 1f;
      this.m12 = y;
      return this;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Affine2 setToScaling(float scaleX, float scaleY)
    {
      this.m00 = scaleX;
      this.m01 = 0.0f;
      this.m02 = 0.0f;
      this.m10 = 0.0f;
      this.m11 = scaleY;
      this.m12 = 0.0f;
      return this;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Affine2 setToShearing(float shearX, float shearY)
    {
      this.m00 = 1f;
      this.m01 = shearX;
      this.m02 = 0.0f;
      this.m10 = shearY;
      this.m11 = 1f;
      this.m12 = 0.0f;
      return this;
    }

    [LineNumberTable(new byte[] {160, 144, 104, 136, 105, 105, 107, 107, 139, 105, 137, 108, 109, 108, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Affine2 setToTrnRotRadScl(
      float x,
      float y,
      float radians,
      float scaleX,
      float scaleY)
    {
      this.m02 = x;
      this.m12 = y;
      if ((double) radians == 0.0)
      {
        this.m00 = scaleX;
        this.m01 = 0.0f;
        this.m10 = 0.0f;
        this.m11 = scaleY;
      }
      else
      {
        float num1 = Mathf.sin(radians);
        float num2 = Mathf.cos(radians);
        this.m00 = num2 * scaleX;
        this.m01 = -num1 * scaleY;
        this.m10 = num1 * scaleX;
        this.m11 = num2 * scaleY;
      }
      return this;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Affine2 setToTrnScl(float x, float y, float scaleX, float scaleY)
    {
      this.m00 = scaleX;
      this.m01 = 0.0f;
      this.m02 = x;
      this.m10 = 0.0f;
      this.m11 = scaleY;
      this.m12 = y;
      return this;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float det() => this.m00 * this.m11 - this.m01 * this.m10;

    [LineNumberTable(new byte[] {161, 73, 112, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Affine2 preTranslate(float x, float y)
    {
      this.m02 += x;
      this.m12 += y;
      return this;
    }

    [LineNumberTable(new byte[] {161, 94, 112, 112, 112, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Affine2 scale(float scaleX, float scaleY)
    {
      this.m00 *= scaleX;
      this.m01 *= scaleY;
      this.m10 *= scaleX;
      this.m11 *= scaleY;
      return this;
    }

    [LineNumberTable(new byte[] {161, 117, 112, 112, 112, 112, 112, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Affine2 preScale(float scaleX, float scaleY)
    {
      this.m00 *= scaleX;
      this.m01 *= scaleX;
      this.m02 *= scaleX;
      this.m10 *= scaleY;
      this.m11 *= scaleY;
      this.m12 *= scaleY;
      return this;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Affine2 shear(float shearX, float shearY)
    {
      float num1 = this.m00 + shearY * this.m01;
      float num2 = this.m01 + shearX * this.m00;
      this.m00 = num1;
      this.m01 = num2;
      float num3 = this.m10 + shearY * this.m11;
      float num4 = this.m11 + shearX * this.m10;
      this.m10 = num3;
      this.m11 = num4;
      return this;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Affine2 preShear(float shearX, float shearY)
    {
      float num1 = this.m00 + shearX * this.m10;
      float num2 = this.m01 + shearX * this.m11;
      float num3 = this.m02 + shearX * this.m12;
      float num4 = this.m10 + shearY * this.m00;
      float num5 = this.m11 + shearY * this.m01;
      float num6 = this.m12 + shearY * this.m02;
      this.m00 = num1;
      this.m01 = num2;
      this.m02 = num3;
      this.m10 = num4;
      this.m11 = num5;
      this.m12 = num6;
      return this;
    }

    [LineNumberTable(new byte[] {159, 169, 232, 51, 127, 2, 255, 2, 77, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Affine2(Affine2 other)
    {
      Affine2 affine2 = this;
      this.m00 = 1f;
      this.m01 = 0.0f;
      this.m02 = 0.0f;
      this.m10 = 0.0f;
      this.m11 = 1f;
      this.m12 = 0.0f;
      this.set(other);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Affine2 idt()
    {
      this.m00 = 1f;
      this.m01 = 0.0f;
      this.m02 = 0.0f;
      this.m10 = 0.0f;
      this.m11 = 1f;
      this.m12 = 0.0f;
      return this;
    }

    [LineNumberTable(new byte[] {16, 135, 105, 105, 105, 105, 105, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Affine2 set(Mat matrix)
    {
      float[] val = matrix.val;
      this.m00 = val[0];
      this.m01 = val[3];
      this.m02 = val[6];
      this.m10 = val[1];
      this.m11 = val[4];
      this.m12 = val[7];
      return this;
    }

    [LineNumberTable(99)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Affine2 setToTranslation(Vec2 trn) => this.setToTranslation(trn.x, trn.y);

    [LineNumberTable(124)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Affine2 setToScaling(Vec2 scale) => this.setToScaling(scale.x, scale.y);

    [LineNumberTable(new byte[] {83, 105, 137, 103, 104, 107, 103, 103, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Affine2 setToRotation(float degrees)
    {
      float num1 = Mathf.cosDeg(degrees);
      float num2 = Mathf.sinDeg(degrees);
      this.m00 = num1;
      this.m01 = -num2;
      this.m02 = 0.0f;
      this.m10 = num2;
      this.m11 = num1;
      this.m12 = 0.0f;
      return this;
    }

    [LineNumberTable(new byte[] {101, 105, 137, 103, 104, 107, 103, 103, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Affine2 setToRotationRad(float radians)
    {
      float num1 = Mathf.cos(radians);
      float num2 = Mathf.sin(radians);
      this.m00 = num1;
      this.m01 = -num2;
      this.m02 = 0.0f;
      this.m10 = num2;
      this.m11 = num1;
      this.m12 = 0.0f;
      return this;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Affine2 setToRotation(float cos, float sin)
    {
      this.m00 = cos;
      this.m01 = -sin;
      this.m02 = 0.0f;
      this.m10 = sin;
      this.m11 = cos;
      this.m12 = 0.0f;
      return this;
    }

    [LineNumberTable(201)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Affine2 setToShearing(Vec2 shear) => this.setToShearing(shear.x, shear.y);

    [LineNumberTable(244)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Affine2 setToTrnRotScl(Vec2 trn, float degrees, Vec2 scale) => this.setToTrnRotScl(trn.x, trn.y, degrees, scale.x, scale.y);

    [LineNumberTable(287)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Affine2 setToTrnRotRadScl(Vec2 trn, float radians, Vec2 scale) => this.setToTrnRotRadScl(trn.x, trn.y, radians, scale.x, scale.y);

    [LineNumberTable(317)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Affine2 setToTrnScl(Vec2 trn, Vec2 scale) => this.setToTrnScl(trn.x, trn.y, scale.x, scale.y);

    [LineNumberTable(new byte[] {160, 213, 127, 5, 127, 5, 127, 13, 127, 5, 127, 5, 127, 13})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Affine2 setToProduct(Affine2 l, Affine2 r)
    {
      this.m00 = l.m00 * r.m00 + l.m01 * r.m10;
      this.m01 = l.m00 * r.m01 + l.m01 * r.m11;
      this.m02 = l.m00 * r.m02 + l.m01 * r.m12 + l.m02;
      this.m10 = l.m10 * r.m00 + l.m11 * r.m10;
      this.m11 = l.m10 * r.m01 + l.m11 * r.m11;
      this.m12 = l.m10 * r.m02 + l.m11 * r.m12 + l.m12;
      return this;
    }

    [LineNumberTable(new byte[] {160, 228, 104, 152, 137, 103, 104, 127, 1, 105, 104, 159, 1, 106, 106, 107, 107, 107, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Affine2 inv()
    {
      float num1 = this.det();
      if ((double) num1 == 0.0)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new ArcRuntimeException("Can't invert a singular affine matrix");
      }
      float num2 = 1f / num1;
      float m11 = this.m11;
      float num3 = -this.m01;
      float num4 = this.m01 * this.m12 - this.m11 * this.m02;
      float num5 = -this.m10;
      float m00 = this.m00;
      float num6 = this.m10 * this.m02 - this.m00 * this.m12;
      this.m00 = num2 * m11;
      this.m01 = num2 * num3;
      this.m02 = num2 * num4;
      this.m10 = num2 * num5;
      this.m11 = num2 * m00;
      this.m12 = num2 * num6;
      return this;
    }

    [LineNumberTable(new byte[] {161, 3, 127, 0, 127, 0, 127, 8, 127, 0, 127, 1, 159, 9, 103, 103, 103, 103, 104, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Affine2 mul(Affine2 other)
    {
      float num1 = this.m00 * other.m00 + this.m01 * other.m10;
      float num2 = this.m00 * other.m01 + this.m01 * other.m11;
      float num3 = this.m00 * other.m02 + this.m01 * other.m12 + this.m02;
      float num4 = this.m10 * other.m00 + this.m11 * other.m10;
      float num5 = this.m10 * other.m01 + this.m11 * other.m11;
      float num6 = this.m10 * other.m02 + this.m11 * other.m12 + this.m12;
      this.m00 = num1;
      this.m01 = num2;
      this.m02 = num3;
      this.m10 = num4;
      this.m11 = num5;
      this.m12 = num6;
      return this;
    }

    [LineNumberTable(433)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Affine2 translate(Vec2 trn) => this.translate(trn.x, trn.y);

    [LineNumberTable(454)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Affine2 preTranslate(Vec2 trn) => this.preTranslate(trn.x, trn.y);

    [LineNumberTable(477)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Affine2 scale(Vec2 scale) => this.scale(scale.x, scale.y);

    [LineNumberTable(502)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Affine2 preScale(Vec2 scale) => this.preScale(scale.x, scale.y);

    [LineNumberTable(new byte[] {161, 141, 139, 105, 137, 117, 118, 118, 151, 103, 103, 104, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Affine2 rotate(float degrees)
    {
      if ((double) degrees == 0.0)
        return this;
      float num1 = Mathf.cosDeg(degrees);
      float num2 = Mathf.sinDeg(degrees);
      float num3 = this.m00 * num1 + this.m01 * num2;
      float num4 = this.m00 * -num2 + this.m01 * num1;
      float num5 = this.m10 * num1 + this.m11 * num2;
      float num6 = this.m10 * -num2 + this.m11 * num1;
      this.m00 = num3;
      this.m01 = num4;
      this.m10 = num5;
      this.m11 = num6;
      return this;
    }

    [LineNumberTable(new byte[] {161, 164, 139, 105, 137, 117, 118, 118, 151, 103, 103, 104, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Affine2 rotateRad(float radians)
    {
      if ((double) radians == 0.0)
        return this;
      float num1 = Mathf.cos(radians);
      float num2 = Mathf.sin(radians);
      float num3 = this.m00 * num1 + this.m01 * num2;
      float num4 = this.m00 * -num2 + this.m01 * num1;
      float num5 = this.m10 * num1 + this.m11 * num2;
      float num6 = this.m10 * -num2 + this.m11 * num1;
      this.m00 = num3;
      this.m01 = num4;
      this.m10 = num5;
      this.m11 = num6;
      return this;
    }

    [LineNumberTable(new byte[] {161, 187, 139, 105, 137, 117, 117, 118, 118, 118, 150, 103, 103, 104, 104, 104, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Affine2 preRotate(float degrees)
    {
      if ((double) degrees == 0.0)
        return this;
      float num1 = Mathf.cosDeg(degrees);
      float num2 = Mathf.sinDeg(degrees);
      float num3 = num1 * this.m00 - num2 * this.m10;
      float num4 = num1 * this.m01 - num2 * this.m11;
      float num5 = num1 * this.m02 - num2 * this.m12;
      float num6 = num2 * this.m00 + num1 * this.m10;
      float num7 = num2 * this.m01 + num1 * this.m11;
      float num8 = num2 * this.m02 + num1 * this.m12;
      this.m00 = num3;
      this.m01 = num4;
      this.m02 = num5;
      this.m10 = num6;
      this.m11 = num7;
      this.m12 = num8;
      return this;
    }

    [LineNumberTable(new byte[] {161, 214, 139, 105, 137, 117, 117, 118, 118, 118, 150, 103, 103, 104, 104, 104, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Affine2 preRotateRad(float radians)
    {
      if ((double) radians == 0.0)
        return this;
      float num1 = Mathf.cos(radians);
      float num2 = Mathf.sin(radians);
      float num3 = num1 * this.m00 - num2 * this.m10;
      float num4 = num1 * this.m01 - num2 * this.m11;
      float num5 = num1 * this.m02 - num2 * this.m12;
      float num6 = num2 * this.m00 + num1 * this.m10;
      float num7 = num2 * this.m01 + num1 * this.m11;
      float num8 = num2 * this.m02 + num1 * this.m12;
      this.m00 = num3;
      this.m01 = num4;
      this.m02 = num5;
      this.m10 = num6;
      this.m11 = num7;
      this.m12 = num8;
      return this;
    }

    [LineNumberTable(630)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Affine2 shear(Vec2 shear) => this.shear(shear.x, shear.y);

    [LineNumberTable(662)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Affine2 preShear(Vec2 shear) => this.preShear(shear.x, shear.y);

    [LineNumberTable(new byte[] {162, 53, 108, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec2 getTranslation(Vec2 position)
    {
      position.x = this.m02;
      position.y = this.m12;
      return position;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isTranslation() => (double) this.m00 == 1.0 && (double) this.m11 == 1.0 && ((double) this.m01 == 0.0 && (double) this.m10 == 0.0);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isIdt() => (double) this.m00 == 1.0 && (double) this.m02 == 0.0 && ((double) this.m12 == 0.0 && (double) this.m11 == 1.0) && ((double) this.m01 == 0.0 && (double) this.m10 == 0.0);

    [LineNumberTable(new byte[] {162, 76, 103, 103, 127, 3, 127, 3})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void applyTo(Vec2 point)
    {
      float x = point.x;
      float y = point.y;
      point.x = this.m00 * x + this.m01 * y + this.m02;
      point.y = this.m10 * x + this.m11 * y + this.m12;
    }

    [LineNumberTable(710)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toString() => new StringBuilder().append("[").append(this.m00).append("|").append(this.m01).append("|").append(this.m02).append("]\n[").append(this.m10).append("|").append(this.m11).append("|").append(this.m12).append("]\n[0.0|0.0|0.1]").toString();
  }
}
