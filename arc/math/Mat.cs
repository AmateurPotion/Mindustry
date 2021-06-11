// Decompiled with JetBrains decompiler
// Type: arc.math.Mat
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.math.geom;
using arc.util;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.math
{
  public class Mat : Object
  {
    public const int M00 = 0;
    public const int M01 = 3;
    public const int M02 = 6;
    public const int M10 = 1;
    public const int M11 = 4;
    public const int M12 = 7;
    public const int M20 = 2;
    public const int M21 = 5;
    public const int M22 = 8;
    public float[] val;
    private float[] tmp;

    [LineNumberTable(new byte[] {27, 143, 109, 141, 111, 143, 105, 137, 106, 106, 141})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Mat setOrtho(float x, float y, float width, float height)
    {
      float num1 = x + width;
      float num2 = y + height;
      float num3 = 2f / (num1 - x);
      float num4 = 2f / (num2 - y);
      float num5 = -(num1 + x) / (num1 - x);
      float num6 = -(num2 + y) / (num2 - y);
      this.val[0] = num3;
      this.val[4] = num4;
      this.val[6] = num5;
      this.val[7] = num6;
      this.val[8] = 1f;
      return this;
    }

    [LineNumberTable(new byte[] {159, 166, 232, 61, 109, 173, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Mat()
    {
      Mat mat = this;
      this.val = new float[9];
      this.tmp = new float[9];
      this.idt();
    }

    [LineNumberTable(new byte[] {161, 21, 135, 105, 105, 104, 105, 105, 104, 105, 105, 136})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Mat set(Affine2 affine)
    {
      float[] val = this.val;
      val[0] = affine.m00;
      val[1] = affine.m10;
      val[2] = 0.0f;
      val[3] = affine.m01;
      val[4] = affine.m11;
      val[5] = 0.0f;
      val[6] = affine.m02;
      val[7] = affine.m12;
      val[8] = 1f;
      return this;
    }

    [LineNumberTable(new byte[] {161, 11, 122})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Mat set(Mat mat)
    {
      ByteCodeHelper.arraycopy_primitive_4((Array) mat.val, 0, (Array) this.val, 0, this.val.Length);
      return this;
    }

    [LineNumberTable(new byte[] {50, 103, 104, 104, 104, 104, 104, 104, 104, 104, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Mat idt()
    {
      float[] val = this.val;
      val[0] = 1f;
      val[1] = 0.0f;
      val[2] = 0.0f;
      val[3] = 0.0f;
      val[4] = 1f;
      val[5] = 0.0f;
      val[6] = 0.0f;
      val[7] = 0.0f;
      val[8] = 1f;
      return this;
    }

    [LineNumberTable(506)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Mat rotate(float degrees) => this.rotateRad((float) Math.PI / 180f * degrees);

    [LineNumberTable(new byte[] {160, 133, 135, 104, 104, 136, 104, 104, 136, 101, 101, 136})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Mat setToTranslation(float x, float y)
    {
      float[] val = this.val;
      val[0] = 1f;
      val[1] = 0.0f;
      val[2] = 0.0f;
      val[3] = 0.0f;
      val[4] = 1f;
      val[5] = 0.0f;
      val[6] = x;
      val[7] = y;
      val[8] = 1f;
      return this;
    }

    [LineNumberTable(new byte[] {161, 174, 103, 101, 104, 104, 104, 101, 104, 104, 104, 104, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Mat scale(float scaleX, float scaleY)
    {
      float[] tmp = this.tmp;
      tmp[0] = scaleX;
      tmp[1] = 0.0f;
      tmp[2] = 0.0f;
      tmp[3] = 0.0f;
      tmp[4] = scaleY;
      tmp[5] = 0.0f;
      tmp[6] = 0.0f;
      tmp[7] = 0.0f;
      tmp[8] = 1f;
      Mat.mul(this.val, tmp);
      return this;
    }

    [LineNumberTable(new byte[] {161, 90, 103, 109, 109, 141, 109, 109, 141, 106, 106, 109, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Mat translate(float x, float y)
    {
      float[] val = this.val;
      this.tmp[0] = 1f;
      this.tmp[1] = 0.0f;
      this.tmp[2] = 0.0f;
      this.tmp[3] = 0.0f;
      this.tmp[4] = 1f;
      this.tmp[5] = 0.0f;
      this.tmp[6] = x;
      this.tmp[7] = y;
      this.tmp[8] = 1f;
      Mat.mul(val, this.tmp);
      return this;
    }

    [LineNumberTable(new byte[] {73, 135, 127, 13, 127, 13, 159, 13, 127, 14, 127, 14, 159, 14, 127, 14, 127, 14, 159, 14, 100, 101, 101, 100, 101, 101, 100, 101, 133})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Mat mul(Mat m)
    {
      float[] val = this.val;
      float num1 = val[0] * m.val[0] + val[3] * m.val[1] + val[6] * m.val[2];
      float num2 = val[0] * m.val[3] + val[3] * m.val[4] + val[6] * m.val[5];
      float num3 = val[0] * m.val[6] + val[3] * m.val[7] + val[6] * m.val[8];
      float num4 = val[1] * m.val[0] + val[4] * m.val[1] + val[7] * m.val[2];
      float num5 = val[1] * m.val[3] + val[4] * m.val[4] + val[7] * m.val[5];
      float num6 = val[1] * m.val[6] + val[4] * m.val[7] + val[7] * m.val[8];
      float num7 = val[2] * m.val[0] + val[5] * m.val[1] + val[8] * m.val[2];
      float num8 = val[2] * m.val[3] + val[5] * m.val[4] + val[8] * m.val[5];
      float num9 = val[2] * m.val[6] + val[5] * m.val[7] + val[8] * m.val[8];
      val[0] = num1;
      val[1] = num4;
      val[2] = num7;
      val[3] = num2;
      val[4] = num5;
      val[5] = num8;
      val[6] = num3;
      val[7] = num6;
      val[8] = num9;
      return this;
    }

    [LineNumberTable(new byte[] {160, 232, 104, 152, 105, 142, 117, 117, 117, 117, 117, 117, 117, 117, 149, 105, 105, 105, 105, 105, 105, 105, 105, 137})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Mat inv()
    {
      float num1 = this.det();
      if ((double) num1 == 0.0)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new ArcRuntimeException("Can't invert a singular matrix");
      }
      float num2 = 1f / num1;
      float[] tmp = this.tmp;
      float[] val = this.val;
      tmp[0] = val[4] * val[8] - val[5] * val[7];
      tmp[1] = val[2] * val[7] - val[1] * val[8];
      tmp[2] = val[1] * val[5] - val[2] * val[4];
      tmp[3] = val[5] * val[6] - val[3] * val[8];
      tmp[4] = val[0] * val[8] - val[2] * val[6];
      tmp[5] = val[2] * val[3] - val[0] * val[5];
      tmp[6] = val[3] * val[7] - val[4] * val[6];
      tmp[7] = val[1] * val[6] - val[0] * val[7];
      tmp[8] = val[0] * val[4] - val[1] * val[3];
      val[0] = num2 * tmp[0];
      val[1] = num2 * tmp[1];
      val[2] = num2 * tmp[2];
      val[3] = num2 * tmp[3];
      val[4] = num2 * tmp[4];
      val[5] = num2 * tmp[5];
      val[6] = num2 * tmp[6];
      val[7] = num2 * tmp[7];
      val[8] = num2 * tmp[8];
      return this;
    }

    [LineNumberTable(new byte[] {161, 44, 117})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Mat set(float[] values)
    {
      ByteCodeHelper.arraycopy_primitive_4((Array) values, 0, (Array) this.val, 0, this.val.Length);
      return this;
    }

    [LineNumberTable(new byte[] {160, 88, 107, 107, 135, 100, 100, 136, 101, 100, 136, 104, 104, 136})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Mat setToRotationRad(float radians)
    {
      float num1 = (float) Math.cos((double) radians);
      float num2 = (float) Math.sin((double) radians);
      float[] val = this.val;
      val[0] = num1;
      val[1] = num2;
      val[2] = 0.0f;
      val[3] = -num2;
      val[4] = num1;
      val[5] = 0.0f;
      val[6] = 0.0f;
      val[7] = 0.0f;
      val[8] = 1f;
      return this;
    }

    [LineNumberTable(new byte[] {160, 112, 103, 106, 120, 127, 1, 127, 1, 127, 1, 120, 127, 1, 127, 1, 127, 1, 120})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Mat setToRotation(Vec3 axis, float cos, float sin)
    {
      float[] val = this.val;
      float num = 1f - cos;
      val[0] = num * axis.x * axis.x + cos;
      val[1] = num * axis.x * axis.y - axis.z * sin;
      val[2] = num * axis.z * axis.x + axis.y * sin;
      val[3] = num * axis.x * axis.y + axis.z * sin;
      val[4] = num * axis.y * axis.y + cos;
      val[5] = num * axis.y * axis.z - axis.x * sin;
      val[6] = num * axis.z * axis.x - axis.y * sin;
      val[7] = num * axis.y * axis.z + axis.x * sin;
      val[8] = num * axis.z * axis.z + cos;
      return this;
    }

    [LineNumberTable(new byte[] {160, 221, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float det()
    {
      float[] val = this.val;
      return val[0] * val[4] * val[8] + val[3] * val[7] * val[2] + val[6] * val[1] * val[5] - val[0] * val[7] * val[5] - val[3] * val[1] * val[8] - val[6] * val[4] * val[2];
    }

    [LineNumberTable(new byte[] {2, 125, 125, 157, 125, 126, 158, 126, 126, 158, 100, 100, 101, 100, 101, 101, 100, 101, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void mul([In] float[] obj0, [In] float[] obj1)
    {
      float num1 = obj0[0] * obj1[0] + obj0[3] * obj1[1] + obj0[6] * obj1[2];
      float num2 = obj0[0] * obj1[3] + obj0[3] * obj1[4] + obj0[6] * obj1[5];
      float num3 = obj0[0] * obj1[6] + obj0[3] * obj1[7] + obj0[6] * obj1[8];
      float num4 = obj0[1] * obj1[0] + obj0[4] * obj1[1] + obj0[7] * obj1[2];
      float num5 = obj0[1] * obj1[3] + obj0[4] * obj1[4] + obj0[7] * obj1[5];
      float num6 = obj0[1] * obj1[6] + obj0[4] * obj1[7] + obj0[7] * obj1[8];
      float num7 = obj0[2] * obj1[0] + obj0[5] * obj1[1] + obj0[8] * obj1[2];
      float num8 = obj0[2] * obj1[3] + obj0[5] * obj1[4] + obj0[8] * obj1[5];
      float num9 = obj0[2] * obj1[6] + obj0[5] * obj1[7] + obj0[8] * obj1[8];
      obj0[0] = num1;
      obj0[1] = num4;
      obj0[2] = num7;
      obj0[3] = num2;
      obj0[4] = num5;
      obj0[5] = num8;
      obj0[6] = num3;
      obj0[7] = num6;
      obj0[8] = num9;
    }

    [LineNumberTable(new byte[] {161, 146, 107, 107, 107, 135, 100, 100, 136, 101, 100, 136, 104, 104, 104, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Mat rotateRad(float radians)
    {
      if ((double) radians == 0.0)
        return this;
      float num1 = (float) Math.cos((double) radians);
      float num2 = (float) Math.sin((double) radians);
      float[] tmp = this.tmp;
      tmp[0] = num1;
      tmp[1] = num2;
      tmp[2] = 0.0f;
      tmp[3] = -num2;
      tmp[4] = num1;
      tmp[5] = 0.0f;
      tmp[6] = 0.0f;
      tmp[7] = 0.0f;
      tmp[8] = 1f;
      Mat.mul(this.val, tmp);
      return this;
    }

    [LineNumberTable(new byte[] {159, 170, 232, 57, 109, 237, 71, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Mat(Mat matrix)
    {
      Mat mat = this;
      this.val = new float[9];
      this.tmp = new float[9];
      this.set(matrix);
    }

    [LineNumberTable(new byte[] {159, 180, 232, 47, 109, 237, 81, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Mat(float[] values)
    {
      Mat mat = this;
      this.val = new float[9];
      this.tmp = new float[9];
      this.set(values);
    }

    [LineNumberTable(new byte[] {110, 135, 127, 13, 127, 13, 159, 13, 127, 14, 127, 14, 159, 14, 127, 14, 127, 14, 159, 14, 100, 101, 101, 100, 101, 101, 100, 101, 133})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Mat mulLeft(Mat m)
    {
      float[] val = this.val;
      float num1 = m.val[0] * val[0] + m.val[3] * val[1] + m.val[6] * val[2];
      float num2 = m.val[0] * val[3] + m.val[3] * val[4] + m.val[6] * val[5];
      float num3 = m.val[0] * val[6] + m.val[3] * val[7] + m.val[6] * val[8];
      float num4 = m.val[1] * val[0] + m.val[4] * val[1] + m.val[7] * val[2];
      float num5 = m.val[1] * val[3] + m.val[4] * val[4] + m.val[7] * val[5];
      float num6 = m.val[1] * val[6] + m.val[4] * val[7] + m.val[7] * val[8];
      float num7 = m.val[2] * val[0] + m.val[5] * val[1] + m.val[8] * val[2];
      float num8 = m.val[2] * val[3] + m.val[5] * val[4] + m.val[8] * val[5];
      float num9 = m.val[2] * val[6] + m.val[5] * val[7] + m.val[8] * val[8];
      val[0] = num1;
      val[1] = num4;
      val[2] = num7;
      val[3] = num2;
      val[4] = num5;
      val[5] = num8;
      val[6] = num3;
      val[7] = num6;
      val[8] = num9;
      return this;
    }

    [LineNumberTable(193)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Mat setToRotation(float degrees) => this.setToRotationRad((float) Math.PI / 180f * degrees);

    [LineNumberTable(222)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Mat setToRotation(Vec3 axis, float degrees) => this.setToRotation(axis, Mathf.cosDeg(degrees), Mathf.sinDeg(degrees));

    [LineNumberTable(new byte[] {160, 156, 135, 104, 104, 136, 104, 104, 136, 105, 105, 136})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Mat setToTranslation(Vec2 translation)
    {
      float[] val = this.val;
      val[0] = 1f;
      val[1] = 0.0f;
      val[2] = 0.0f;
      val[3] = 0.0f;
      val[4] = 1f;
      val[5] = 0.0f;
      val[6] = translation.x;
      val[7] = translation.y;
      val[8] = 1f;
      return this;
    }

    [LineNumberTable(new byte[] {160, 180, 103, 101, 104, 104, 104, 101, 104, 104, 104, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Mat setToScaling(float scaleX, float scaleY)
    {
      float[] val = this.val;
      val[0] = scaleX;
      val[1] = 0.0f;
      val[2] = 0.0f;
      val[3] = 0.0f;
      val[4] = scaleY;
      val[5] = 0.0f;
      val[6] = 0.0f;
      val[7] = 0.0f;
      val[8] = 1f;
      return this;
    }

    [LineNumberTable(new byte[] {160, 199, 103, 105, 104, 104, 104, 105, 104, 104, 104, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Mat setToScaling(Vec2 scale)
    {
      float[] val = this.val;
      val[0] = scale.x;
      val[1] = 0.0f;
      val[2] = 0.0f;
      val[3] = 0.0f;
      val[4] = scale.y;
      val[5] = 0.0f;
      val[6] = 0.0f;
      val[7] = 0.0f;
      val[8] = 1f;
      return this;
    }

    [LineNumberTable(new byte[] {160, 213, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toString()
    {
      float[] val = this.val;
      return new StringBuilder().append("[").append(val[0]).append("|").append(val[3]).append("|").append(val[6]).append("]\n[").append(val[1]).append("|").append(val[4]).append("|").append(val[7]).append("]\n[").append(val[2]).append("|").append(val[5]).append("|").append(val[8]).append("]").toString();
    }

    [LineNumberTable(new byte[] {161, 54, 119, 119})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Mat trn(Vec2 vector)
    {
      float[] val1 = this.val;
      int index1 = 6;
      float[] numArray1 = val1;
      numArray1[index1] = numArray1[index1] + vector.x;
      float[] val2 = this.val;
      int index2 = 7;
      float[] numArray2 = val2;
      numArray2[index2] = numArray2[index2] + vector.y;
      return this;
    }

    [LineNumberTable(new byte[] {161, 66, 115, 115})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Mat trn(float x, float y)
    {
      float[] val1 = this.val;
      int index1 = 6;
      float[] numArray1 = val1;
      numArray1[index1] = numArray1[index1] + x;
      float[] val2 = this.val;
      int index2 = 7;
      float[] numArray2 = val2;
      numArray2[index2] = numArray2[index2] + y;
      return this;
    }

    [LineNumberTable(new byte[] {161, 77, 119, 119})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Mat trn(Vec3 vector)
    {
      float[] val1 = this.val;
      int index1 = 6;
      float[] numArray1 = val1;
      numArray1[index1] = numArray1[index1] + vector.x;
      float[] val2 = this.val;
      int index2 = 7;
      float[] numArray2 = val2;
      numArray2[index2] = numArray2[index2] + vector.y;
      return this;
    }

    [LineNumberTable(new byte[] {161, 113, 103, 109, 109, 141, 109, 109, 141, 110, 110, 109, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Mat translate(Vec2 translation)
    {
      float[] val = this.val;
      this.tmp[0] = 1f;
      this.tmp[1] = 0.0f;
      this.tmp[2] = 0.0f;
      this.tmp[3] = 0.0f;
      this.tmp[4] = 1f;
      this.tmp[5] = 0.0f;
      this.tmp[6] = translation.x;
      this.tmp[7] = translation.y;
      this.tmp[8] = 1f;
      Mat.mul(val, this.tmp);
      return this;
    }

    [LineNumberTable(new byte[] {161, 195, 103, 105, 104, 104, 104, 105, 104, 104, 104, 104, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Mat scale(Vec2 scale)
    {
      float[] tmp = this.tmp;
      tmp[0] = scale.x;
      tmp[1] = 0.0f;
      tmp[2] = 0.0f;
      tmp[3] = 0.0f;
      tmp[4] = scale.y;
      tmp[5] = 0.0f;
      tmp[6] = 0.0f;
      tmp[7] = 0.0f;
      tmp[8] = 1f;
      Mat.mul(this.val, tmp);
      return this;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float[] getValues() => this.val;

    [LineNumberTable(new byte[] {161, 218, 110, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec2 getTranslation(Vec2 position)
    {
      position.x = this.val[6];
      position.y = this.val[7];
      return position;
    }

    [LineNumberTable(new byte[] {161, 224, 103, 127, 1, 127, 1})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec2 getScale(Vec2 scale)
    {
      float[] val = this.val;
      scale.x = (float) Math.sqrt((double) (val[0] * val[0] + val[3] * val[3]));
      scale.y = (float) Math.sqrt((double) (val[1] * val[1] + val[4] * val[4]));
      return scale;
    }

    [LineNumberTable(601)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getRotation() => 57.29578f * (float) Math.atan2((double) this.val[1], (double) this.val[0]);

    [LineNumberTable(605)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getRotationRad() => (float) Math.atan2((double) this.val[1], (double) this.val[0]);

    [LineNumberTable(new byte[] {161, 244, 115, 115})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Mat scl(float scale)
    {
      float[] val1 = this.val;
      int index1 = 0;
      float[] numArray1 = val1;
      numArray1[index1] = numArray1[index1] * scale;
      float[] val2 = this.val;
      int index2 = 4;
      float[] numArray2 = val2;
      numArray2[index2] = numArray2[index2] * scale;
      return this;
    }

    [LineNumberTable(new byte[] {161, 255, 119, 119})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Mat scl(Vec2 scale)
    {
      float[] val1 = this.val;
      int index1 = 0;
      float[] numArray1 = val1;
      numArray1[index1] = numArray1[index1] * scale.x;
      float[] val2 = this.val;
      int index2 = 4;
      float[] numArray2 = val2;
      numArray2[index2] = numArray2[index2] * scale.y;
      return this;
    }

    [LineNumberTable(new byte[] {162, 10, 119, 119})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Mat scl(Vec3 scale)
    {
      float[] val1 = this.val;
      int index1 = 0;
      float[] numArray1 = val1;
      numArray1[index1] = numArray1[index1] * scale.x;
      float[] val2 = this.val;
      int index2 = 4;
      float[] numArray2 = val2;
      numArray2[index2] = numArray2[index2] * scale.y;
      return this;
    }

    [LineNumberTable(new byte[] {162, 21, 103, 100, 100, 100, 101, 101, 101, 100, 100, 100, 101, 101, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Mat transpose()
    {
      float[] val = this.val;
      float num1 = val[1];
      float num2 = val[2];
      float num3 = val[3];
      float num4 = val[5];
      float num5 = val[6];
      float num6 = val[7];
      val[3] = num1;
      val[6] = num2;
      val[1] = num3;
      val[7] = num4;
      val[2] = num5;
      val[5] = num6;
      return this;
    }
  }
}
