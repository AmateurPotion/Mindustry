// Decompiled with JetBrains decompiler
// Type: arc.math.geom.Mat3D
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.math.geom
{
  public class Mat3D : Object
  {
    public const int M00 = 0;
    public const int M01 = 4;
    public const int M02 = 8;
    public const int M03 = 12;
    public const int M10 = 1;
    public const int M11 = 5;
    public const int M12 = 9;
    public const int M13 = 13;
    public const int M20 = 2;
    public const int M21 = 6;
    public const int M22 = 10;
    public const int M23 = 14;
    public const int M30 = 3;
    public const int M31 = 7;
    public const int M32 = 11;
    public const int M33 = 15;
    [Modifiers]
    private static float[] tmp;
    internal float[] __\u003C\u003Eval;
    internal static Quat quat;
    internal static Quat quat2;
    [Modifiers]
    internal static Vec3 l_vez;
    [Modifiers]
    internal static Vec3 l_vex;
    [Modifiers]
    internal static Vec3 l_vey;
    [Modifiers]
    internal static Vec3 tmpVec;
    [Modifiers]
    internal static Mat3D tmpMat;
    [Modifiers]
    internal static Vec3 right;
    [Modifiers]
    internal static Vec3 tmpForward;
    [Modifiers]
    internal static Vec3 tmpUp;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {162, 45, 103, 111, 111, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Mat3D setToTranslation(Vec3 vector)
    {
      this.idt();
      this.__\u003C\u003Eval[12] = vector.x;
      this.__\u003C\u003Eval[13] = vector.y;
      this.__\u003C\u003Eval[14] = vector.z;
      return this;
    }

    [LineNumberTable(new byte[] {165, 38, 107, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Mat3D rotate(Vec3 axis, float degrees)
    {
      if ((double) degrees == 0.0)
        return this;
      Mat3D.quat.set(axis, degrees);
      return this.rotate(Mat3D.quat);
    }

    [LineNumberTable(new byte[] {29, 232, 61, 205, 109, 109, 110, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Mat3D()
    {
      Mat3D mat3D = this;
      this.__\u003C\u003Eval = new float[16];
      this.__\u003C\u003Eval[0] = 1f;
      this.__\u003C\u003Eval[5] = 1f;
      this.__\u003C\u003Eval[10] = 1f;
      this.__\u003C\u003Eval[15] = 1f;
    }

    [LineNumberTable(new byte[] {160, 228, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Mat3D mul(Mat3D matrix)
    {
      Mat3D.mul(this.__\u003C\u003Eval, matrix.__\u003C\u003Eval);
      return this;
    }

    [LineNumberTable(new byte[] {161, 137, 103, 127, 9, 111, 118, 110, 109, 109, 109, 109, 105, 109, 109, 109, 110, 106, 110, 110, 110, 106, 142})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Mat3D setToProjection(
      float near,
      float far,
      float fovy,
      float aspectRatio)
    {
      this.idt();
      float num1 = (float) (1.0 / Math.tan((double) fovy * (Math.PI / 180.0) / 2.0));
      float num2 = (far + near) / (near - far);
      float num3 = 2f * far * near / (near - far);
      this.__\u003C\u003Eval[0] = num1 / aspectRatio;
      this.__\u003C\u003Eval[1] = 0.0f;
      this.__\u003C\u003Eval[2] = 0.0f;
      this.__\u003C\u003Eval[3] = 0.0f;
      this.__\u003C\u003Eval[4] = 0.0f;
      this.__\u003C\u003Eval[5] = num1;
      this.__\u003C\u003Eval[6] = 0.0f;
      this.__\u003C\u003Eval[7] = 0.0f;
      this.__\u003C\u003Eval[8] = 0.0f;
      this.__\u003C\u003Eval[9] = 0.0f;
      this.__\u003C\u003Eval[10] = num2;
      this.__\u003C\u003Eval[11] = -1f;
      this.__\u003C\u003Eval[12] = 0.0f;
      this.__\u003C\u003Eval[13] = 0.0f;
      this.__\u003C\u003Eval[14] = num3;
      this.__\u003C\u003Eval[15] = 0.0f;
      return this;
    }

    [LineNumberTable(new byte[] {161, 239, 103, 110, 111, 144, 112, 115, 149, 105, 109, 109, 109, 109, 105, 109, 109, 109, 110, 106, 110, 106, 107, 107, 142})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Mat3D setToOrtho(
      float left,
      float right,
      float bottom,
      float top,
      float near,
      float far)
    {
      this.idt();
      float num1 = 2f / (right - left);
      float num2 = 2f / (top - bottom);
      float num3 = -2f / (far - near);
      float num4 = -(right + left) / (right - left);
      float num5 = -(top + bottom) / (top - bottom);
      float num6 = -(far + near) / (far - near);
      this.__\u003C\u003Eval[0] = num1;
      this.__\u003C\u003Eval[1] = 0.0f;
      this.__\u003C\u003Eval[2] = 0.0f;
      this.__\u003C\u003Eval[3] = 0.0f;
      this.__\u003C\u003Eval[4] = 0.0f;
      this.__\u003C\u003Eval[5] = num2;
      this.__\u003C\u003Eval[6] = 0.0f;
      this.__\u003C\u003Eval[7] = 0.0f;
      this.__\u003C\u003Eval[8] = 0.0f;
      this.__\u003C\u003Eval[9] = 0.0f;
      this.__\u003C\u003Eval[10] = num3;
      this.__\u003C\u003Eval[11] = 0.0f;
      this.__\u003C\u003Eval[12] = num4;
      this.__\u003C\u003Eval[13] = num5;
      this.__\u003C\u003Eval[14] = num6;
      this.__\u003C\u003Eval[15] = 1f;
      return this;
    }

    [LineNumberTable(new byte[] {163, 33, 114, 109, 159, 7})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Mat3D setToLookAt(Vec3 position, Vec3 target, Vec3 up)
    {
      Mat3D.tmpVec.set(target).sub(position);
      this.setToLookAt(Mat3D.tmpVec, up);
      this.mul(Mat3D.tmpMat.setToTranslation(-position.x, -position.y, -position.z));
      return this;
    }

    [LineNumberTable(127)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Mat3D set(Mat3D matrix) => this.set(matrix.__\u003C\u003Eval);

    [LineNumberTable(new byte[] {161, 45, 255, 163, 138, 73, 120, 105, 159, 160, 102, 159, 160, 100, 159, 160, 100, 159, 160, 101, 159, 160, 102, 159, 160, 100, 159, 160, 101, 159, 160, 101, 159, 160, 96, 159, 160, 96, 159, 160, 97, 159, 160, 97, 159, 160, 96, 159, 160, 94, 159, 160, 95, 159, 160, 95, 114, 114, 114, 116, 114, 114, 116, 116, 114, 114, 116, 116, 114, 114, 116, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Mat3D inv()
    {
      float num1 = this.__\u003C\u003Eval[3] * this.__\u003C\u003Eval[6] * this.__\u003C\u003Eval[9] * this.__\u003C\u003Eval[12] - this.__\u003C\u003Eval[2] * this.__\u003C\u003Eval[7] * this.__\u003C\u003Eval[9] * this.__\u003C\u003Eval[12] - this.__\u003C\u003Eval[3] * this.__\u003C\u003Eval[5] * this.__\u003C\u003Eval[10] * this.__\u003C\u003Eval[12] + this.__\u003C\u003Eval[1] * this.__\u003C\u003Eval[7] * this.__\u003C\u003Eval[10] * this.__\u003C\u003Eval[12] + this.__\u003C\u003Eval[2] * this.__\u003C\u003Eval[5] * this.__\u003C\u003Eval[11] * this.__\u003C\u003Eval[12] - this.__\u003C\u003Eval[1] * this.__\u003C\u003Eval[6] * this.__\u003C\u003Eval[11] * this.__\u003C\u003Eval[12] - this.__\u003C\u003Eval[3] * this.__\u003C\u003Eval[6] * this.__\u003C\u003Eval[8] * this.__\u003C\u003Eval[13] + this.__\u003C\u003Eval[2] * this.__\u003C\u003Eval[7] * this.__\u003C\u003Eval[8] * this.__\u003C\u003Eval[13] + this.__\u003C\u003Eval[3] * this.__\u003C\u003Eval[4] * this.__\u003C\u003Eval[10] * this.__\u003C\u003Eval[13] - this.__\u003C\u003Eval[0] * this.__\u003C\u003Eval[7] * this.__\u003C\u003Eval[10] * this.__\u003C\u003Eval[13] - this.__\u003C\u003Eval[2] * this.__\u003C\u003Eval[4] * this.__\u003C\u003Eval[11] * this.__\u003C\u003Eval[13] + this.__\u003C\u003Eval[0] * this.__\u003C\u003Eval[6] * this.__\u003C\u003Eval[11] * this.__\u003C\u003Eval[13] + this.__\u003C\u003Eval[3] * this.__\u003C\u003Eval[5] * this.__\u003C\u003Eval[8] * this.__\u003C\u003Eval[14] - this.__\u003C\u003Eval[1] * this.__\u003C\u003Eval[7] * this.__\u003C\u003Eval[8] * this.__\u003C\u003Eval[14] - this.__\u003C\u003Eval[3] * this.__\u003C\u003Eval[4] * this.__\u003C\u003Eval[9] * this.__\u003C\u003Eval[14] + this.__\u003C\u003Eval[0] * this.__\u003C\u003Eval[7] * this.__\u003C\u003Eval[9] * this.__\u003C\u003Eval[14] + this.__\u003C\u003Eval[1] * this.__\u003C\u003Eval[4] * this.__\u003C\u003Eval[11] * this.__\u003C\u003Eval[14] - this.__\u003C\u003Eval[0] * this.__\u003C\u003Eval[5] * this.__\u003C\u003Eval[11] * this.__\u003C\u003Eval[14] - this.__\u003C\u003Eval[2] * this.__\u003C\u003Eval[5] * this.__\u003C\u003Eval[8] * this.__\u003C\u003Eval[15] + this.__\u003C\u003Eval[1] * this.__\u003C\u003Eval[6] * this.__\u003C\u003Eval[8] * this.__\u003C\u003Eval[15] + this.__\u003C\u003Eval[2] * this.__\u003C\u003Eval[4] * this.__\u003C\u003Eval[9] * this.__\u003C\u003Eval[15] - this.__\u003C\u003Eval[0] * this.__\u003C\u003Eval[6] * this.__\u003C\u003Eval[9] * this.__\u003C\u003Eval[15] - this.__\u003C\u003Eval[1] * this.__\u003C\u003Eval[4] * this.__\u003C\u003Eval[10] * this.__\u003C\u003Eval[15] + this.__\u003C\u003Eval[0] * this.__\u003C\u003Eval[5] * this.__\u003C\u003Eval[10] * this.__\u003C\u003Eval[15];
      if ((double) num1 == 0.0)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new RuntimeException("non-invertible matrix");
      }
      float num2 = 1f / num1;
      Mat3D.tmp[0] = this.__\u003C\u003Eval[9] * this.__\u003C\u003Eval[14] * this.__\u003C\u003Eval[7] - this.__\u003C\u003Eval[13] * this.__\u003C\u003Eval[10] * this.__\u003C\u003Eval[7] + this.__\u003C\u003Eval[13] * this.__\u003C\u003Eval[6] * this.__\u003C\u003Eval[11] - this.__\u003C\u003Eval[5] * this.__\u003C\u003Eval[14] * this.__\u003C\u003Eval[11] - this.__\u003C\u003Eval[9] * this.__\u003C\u003Eval[6] * this.__\u003C\u003Eval[15] + this.__\u003C\u003Eval[5] * this.__\u003C\u003Eval[10] * this.__\u003C\u003Eval[15];
      Mat3D.tmp[4] = this.__\u003C\u003Eval[12] * this.__\u003C\u003Eval[10] * this.__\u003C\u003Eval[7] - this.__\u003C\u003Eval[8] * this.__\u003C\u003Eval[14] * this.__\u003C\u003Eval[7] - this.__\u003C\u003Eval[12] * this.__\u003C\u003Eval[6] * this.__\u003C\u003Eval[11] + this.__\u003C\u003Eval[4] * this.__\u003C\u003Eval[14] * this.__\u003C\u003Eval[11] + this.__\u003C\u003Eval[8] * this.__\u003C\u003Eval[6] * this.__\u003C\u003Eval[15] - this.__\u003C\u003Eval[4] * this.__\u003C\u003Eval[10] * this.__\u003C\u003Eval[15];
      Mat3D.tmp[8] = this.__\u003C\u003Eval[8] * this.__\u003C\u003Eval[13] * this.__\u003C\u003Eval[7] - this.__\u003C\u003Eval[12] * this.__\u003C\u003Eval[9] * this.__\u003C\u003Eval[7] + this.__\u003C\u003Eval[12] * this.__\u003C\u003Eval[5] * this.__\u003C\u003Eval[11] - this.__\u003C\u003Eval[4] * this.__\u003C\u003Eval[13] * this.__\u003C\u003Eval[11] - this.__\u003C\u003Eval[8] * this.__\u003C\u003Eval[5] * this.__\u003C\u003Eval[15] + this.__\u003C\u003Eval[4] * this.__\u003C\u003Eval[9] * this.__\u003C\u003Eval[15];
      Mat3D.tmp[12] = this.__\u003C\u003Eval[12] * this.__\u003C\u003Eval[9] * this.__\u003C\u003Eval[6] - this.__\u003C\u003Eval[8] * this.__\u003C\u003Eval[13] * this.__\u003C\u003Eval[6] - this.__\u003C\u003Eval[12] * this.__\u003C\u003Eval[5] * this.__\u003C\u003Eval[10] + this.__\u003C\u003Eval[4] * this.__\u003C\u003Eval[13] * this.__\u003C\u003Eval[10] + this.__\u003C\u003Eval[8] * this.__\u003C\u003Eval[5] * this.__\u003C\u003Eval[14] - this.__\u003C\u003Eval[4] * this.__\u003C\u003Eval[9] * this.__\u003C\u003Eval[14];
      Mat3D.tmp[1] = this.__\u003C\u003Eval[13] * this.__\u003C\u003Eval[10] * this.__\u003C\u003Eval[3] - this.__\u003C\u003Eval[9] * this.__\u003C\u003Eval[14] * this.__\u003C\u003Eval[3] - this.__\u003C\u003Eval[13] * this.__\u003C\u003Eval[2] * this.__\u003C\u003Eval[11] + this.__\u003C\u003Eval[1] * this.__\u003C\u003Eval[14] * this.__\u003C\u003Eval[11] + this.__\u003C\u003Eval[9] * this.__\u003C\u003Eval[2] * this.__\u003C\u003Eval[15] - this.__\u003C\u003Eval[1] * this.__\u003C\u003Eval[10] * this.__\u003C\u003Eval[15];
      Mat3D.tmp[5] = this.__\u003C\u003Eval[8] * this.__\u003C\u003Eval[14] * this.__\u003C\u003Eval[3] - this.__\u003C\u003Eval[12] * this.__\u003C\u003Eval[10] * this.__\u003C\u003Eval[3] + this.__\u003C\u003Eval[12] * this.__\u003C\u003Eval[2] * this.__\u003C\u003Eval[11] - this.__\u003C\u003Eval[0] * this.__\u003C\u003Eval[14] * this.__\u003C\u003Eval[11] - this.__\u003C\u003Eval[8] * this.__\u003C\u003Eval[2] * this.__\u003C\u003Eval[15] + this.__\u003C\u003Eval[0] * this.__\u003C\u003Eval[10] * this.__\u003C\u003Eval[15];
      Mat3D.tmp[9] = this.__\u003C\u003Eval[12] * this.__\u003C\u003Eval[9] * this.__\u003C\u003Eval[3] - this.__\u003C\u003Eval[8] * this.__\u003C\u003Eval[13] * this.__\u003C\u003Eval[3] - this.__\u003C\u003Eval[12] * this.__\u003C\u003Eval[1] * this.__\u003C\u003Eval[11] + this.__\u003C\u003Eval[0] * this.__\u003C\u003Eval[13] * this.__\u003C\u003Eval[11] + this.__\u003C\u003Eval[8] * this.__\u003C\u003Eval[1] * this.__\u003C\u003Eval[15] - this.__\u003C\u003Eval[0] * this.__\u003C\u003Eval[9] * this.__\u003C\u003Eval[15];
      Mat3D.tmp[13] = this.__\u003C\u003Eval[8] * this.__\u003C\u003Eval[13] * this.__\u003C\u003Eval[2] - this.__\u003C\u003Eval[12] * this.__\u003C\u003Eval[9] * this.__\u003C\u003Eval[2] + this.__\u003C\u003Eval[12] * this.__\u003C\u003Eval[1] * this.__\u003C\u003Eval[10] - this.__\u003C\u003Eval[0] * this.__\u003C\u003Eval[13] * this.__\u003C\u003Eval[10] - this.__\u003C\u003Eval[8] * this.__\u003C\u003Eval[1] * this.__\u003C\u003Eval[14] + this.__\u003C\u003Eval[0] * this.__\u003C\u003Eval[9] * this.__\u003C\u003Eval[14];
      Mat3D.tmp[2] = this.__\u003C\u003Eval[5] * this.__\u003C\u003Eval[14] * this.__\u003C\u003Eval[3] - this.__\u003C\u003Eval[13] * this.__\u003C\u003Eval[6] * this.__\u003C\u003Eval[3] + this.__\u003C\u003Eval[13] * this.__\u003C\u003Eval[2] * this.__\u003C\u003Eval[7] - this.__\u003C\u003Eval[1] * this.__\u003C\u003Eval[14] * this.__\u003C\u003Eval[7] - this.__\u003C\u003Eval[5] * this.__\u003C\u003Eval[2] * this.__\u003C\u003Eval[15] + this.__\u003C\u003Eval[1] * this.__\u003C\u003Eval[6] * this.__\u003C\u003Eval[15];
      Mat3D.tmp[6] = this.__\u003C\u003Eval[12] * this.__\u003C\u003Eval[6] * this.__\u003C\u003Eval[3] - this.__\u003C\u003Eval[4] * this.__\u003C\u003Eval[14] * this.__\u003C\u003Eval[3] - this.__\u003C\u003Eval[12] * this.__\u003C\u003Eval[2] * this.__\u003C\u003Eval[7] + this.__\u003C\u003Eval[0] * this.__\u003C\u003Eval[14] * this.__\u003C\u003Eval[7] + this.__\u003C\u003Eval[4] * this.__\u003C\u003Eval[2] * this.__\u003C\u003Eval[15] - this.__\u003C\u003Eval[0] * this.__\u003C\u003Eval[6] * this.__\u003C\u003Eval[15];
      Mat3D.tmp[10] = this.__\u003C\u003Eval[4] * this.__\u003C\u003Eval[13] * this.__\u003C\u003Eval[3] - this.__\u003C\u003Eval[12] * this.__\u003C\u003Eval[5] * this.__\u003C\u003Eval[3] + this.__\u003C\u003Eval[12] * this.__\u003C\u003Eval[1] * this.__\u003C\u003Eval[7] - this.__\u003C\u003Eval[0] * this.__\u003C\u003Eval[13] * this.__\u003C\u003Eval[7] - this.__\u003C\u003Eval[4] * this.__\u003C\u003Eval[1] * this.__\u003C\u003Eval[15] + this.__\u003C\u003Eval[0] * this.__\u003C\u003Eval[5] * this.__\u003C\u003Eval[15];
      Mat3D.tmp[14] = this.__\u003C\u003Eval[12] * this.__\u003C\u003Eval[5] * this.__\u003C\u003Eval[2] - this.__\u003C\u003Eval[4] * this.__\u003C\u003Eval[13] * this.__\u003C\u003Eval[2] - this.__\u003C\u003Eval[12] * this.__\u003C\u003Eval[1] * this.__\u003C\u003Eval[6] + this.__\u003C\u003Eval[0] * this.__\u003C\u003Eval[13] * this.__\u003C\u003Eval[6] + this.__\u003C\u003Eval[4] * this.__\u003C\u003Eval[1] * this.__\u003C\u003Eval[14] - this.__\u003C\u003Eval[0] * this.__\u003C\u003Eval[5] * this.__\u003C\u003Eval[14];
      Mat3D.tmp[3] = this.__\u003C\u003Eval[9] * this.__\u003C\u003Eval[6] * this.__\u003C\u003Eval[3] - this.__\u003C\u003Eval[5] * this.__\u003C\u003Eval[10] * this.__\u003C\u003Eval[3] - this.__\u003C\u003Eval[9] * this.__\u003C\u003Eval[2] * this.__\u003C\u003Eval[7] + this.__\u003C\u003Eval[1] * this.__\u003C\u003Eval[10] * this.__\u003C\u003Eval[7] + this.__\u003C\u003Eval[5] * this.__\u003C\u003Eval[2] * this.__\u003C\u003Eval[11] - this.__\u003C\u003Eval[1] * this.__\u003C\u003Eval[6] * this.__\u003C\u003Eval[11];
      Mat3D.tmp[7] = this.__\u003C\u003Eval[4] * this.__\u003C\u003Eval[10] * this.__\u003C\u003Eval[3] - this.__\u003C\u003Eval[8] * this.__\u003C\u003Eval[6] * this.__\u003C\u003Eval[3] + this.__\u003C\u003Eval[8] * this.__\u003C\u003Eval[2] * this.__\u003C\u003Eval[7] - this.__\u003C\u003Eval[0] * this.__\u003C\u003Eval[10] * this.__\u003C\u003Eval[7] - this.__\u003C\u003Eval[4] * this.__\u003C\u003Eval[2] * this.__\u003C\u003Eval[11] + this.__\u003C\u003Eval[0] * this.__\u003C\u003Eval[6] * this.__\u003C\u003Eval[11];
      Mat3D.tmp[11] = this.__\u003C\u003Eval[8] * this.__\u003C\u003Eval[5] * this.__\u003C\u003Eval[3] - this.__\u003C\u003Eval[4] * this.__\u003C\u003Eval[9] * this.__\u003C\u003Eval[3] - this.__\u003C\u003Eval[8] * this.__\u003C\u003Eval[1] * this.__\u003C\u003Eval[7] + this.__\u003C\u003Eval[0] * this.__\u003C\u003Eval[9] * this.__\u003C\u003Eval[7] + this.__\u003C\u003Eval[4] * this.__\u003C\u003Eval[1] * this.__\u003C\u003Eval[11] - this.__\u003C\u003Eval[0] * this.__\u003C\u003Eval[5] * this.__\u003C\u003Eval[11];
      Mat3D.tmp[15] = this.__\u003C\u003Eval[4] * this.__\u003C\u003Eval[9] * this.__\u003C\u003Eval[2] - this.__\u003C\u003Eval[8] * this.__\u003C\u003Eval[5] * this.__\u003C\u003Eval[2] + this.__\u003C\u003Eval[8] * this.__\u003C\u003Eval[1] * this.__\u003C\u003Eval[6] - this.__\u003C\u003Eval[0] * this.__\u003C\u003Eval[9] * this.__\u003C\u003Eval[6] - this.__\u003C\u003Eval[4] * this.__\u003C\u003Eval[1] * this.__\u003C\u003Eval[10] + this.__\u003C\u003Eval[0] * this.__\u003C\u003Eval[5] * this.__\u003C\u003Eval[10];
      this.__\u003C\u003Eval[0] = Mat3D.tmp[0] * num2;
      this.__\u003C\u003Eval[4] = Mat3D.tmp[4] * num2;
      this.__\u003C\u003Eval[8] = Mat3D.tmp[8] * num2;
      this.__\u003C\u003Eval[12] = Mat3D.tmp[12] * num2;
      this.__\u003C\u003Eval[1] = Mat3D.tmp[1] * num2;
      this.__\u003C\u003Eval[5] = Mat3D.tmp[5] * num2;
      this.__\u003C\u003Eval[9] = Mat3D.tmp[9] * num2;
      this.__\u003C\u003Eval[13] = Mat3D.tmp[13] * num2;
      this.__\u003C\u003Eval[2] = Mat3D.tmp[2] * num2;
      this.__\u003C\u003Eval[6] = Mat3D.tmp[6] * num2;
      this.__\u003C\u003Eval[10] = Mat3D.tmp[10] * num2;
      this.__\u003C\u003Eval[14] = Mat3D.tmp[14] * num2;
      this.__\u003C\u003Eval[3] = Mat3D.tmp[3] * num2;
      this.__\u003C\u003Eval[7] = Mat3D.tmp[7] * num2;
      this.__\u003C\u003Eval[11] = Mat3D.tmp[11] * num2;
      this.__\u003C\u003Eval[15] = Mat3D.tmp[15] * num2;
      return this;
    }

    [LineNumberTable(new byte[] {165, 170, 103, 127, 21})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Vec3 prj(Vec3 v, Mat3D matrix)
    {
      float[] val = matrix.__\u003C\u003Eval;
      float num = 1f / (v.x * val[3] + v.y * val[7] + v.z * val[11] + val[15]);
      return v.set((v.x * val[0] + v.y * val[4] + v.z * val[8] + val[12]) * num, (v.x * val[1] + v.y * val[5] + v.z * val[9] + val[13]) * num, (v.x * val[2] + v.y * val[6] + v.z * val[10] + val[14]) * num);
    }

    [LineNumberTable(new byte[] {88, 117})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Mat3D set(float[] values)
    {
      ByteCodeHelper.arraycopy_primitive_4((Array) values, 0, (Array) this.__\u003C\u003Eval, 0, this.__\u003C\u003Eval.Length);
      return this;
    }

    [LineNumberTable(148)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Mat3D set(Quat quat) => this.set(quat.x, quat.y, quat.z, quat.w);

    [LineNumberTable(221)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Mat3D set(Vec3 position, Quat orientation, Vec3 scale) => this.set(position.x, position.y, position.z, orientation.x, orientation.y, orientation.z, orientation.w, scale.x, scale.y, scale.z);

    [LineNumberTable(160)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Mat3D set(
      float quaternionX,
      float quaternionY,
      float quaternionZ,
      float quaternionW)
    {
      return this.set(0.0f, 0.0f, 0.0f, quaternionX, quaternionY, quaternionZ, quaternionW);
    }

    [LineNumberTable(new byte[] {160, 72, 127, 2, 119, 120, 152, 117, 110, 110, 139, 110, 117, 110, 139, 110, 109, 118, 139, 109, 109, 110, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Mat3D set(
      float translationX,
      float translationY,
      float translationZ,
      float quaternionX,
      float quaternionY,
      float quaternionZ,
      float quaternionW)
    {
      float num1 = quaternionX * 2f;
      float num2 = quaternionY * 2f;
      float num3 = quaternionZ * 2f;
      float num4 = quaternionW * num1;
      float num5 = quaternionW * num2;
      float num6 = quaternionW * num3;
      float num7 = quaternionX * num1;
      float num8 = quaternionX * num2;
      float num9 = quaternionX * num3;
      float num10 = quaternionY * num2;
      float num11 = quaternionY * num3;
      float num12 = quaternionZ * num3;
      this.__\u003C\u003Eval[0] = 1f - (num10 + num12);
      this.__\u003C\u003Eval[4] = num8 - num6;
      this.__\u003C\u003Eval[8] = num9 + num5;
      this.__\u003C\u003Eval[12] = translationX;
      this.__\u003C\u003Eval[1] = num8 + num6;
      this.__\u003C\u003Eval[5] = 1f - (num7 + num12);
      this.__\u003C\u003Eval[9] = num11 - num4;
      this.__\u003C\u003Eval[13] = translationY;
      this.__\u003C\u003Eval[2] = num9 - num5;
      this.__\u003C\u003Eval[6] = num11 + num4;
      this.__\u003C\u003Eval[10] = 1f - (num7 + num10);
      this.__\u003C\u003Eval[14] = translationZ;
      this.__\u003C\u003Eval[3] = 0.0f;
      this.__\u003C\u003Eval[7] = 0.0f;
      this.__\u003C\u003Eval[11] = 0.0f;
      this.__\u003C\u003Eval[15] = 1f;
      return this;
    }

    [LineNumberTable(new byte[] {160, 127, 127, 2, 119, 120, 152, 122, 115, 115, 139, 115, 122, 115, 139, 115, 114, 123, 139, 109, 109, 110, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Mat3D set(
      float translationX,
      float translationY,
      float translationZ,
      float quaternionX,
      float quaternionY,
      float quaternionZ,
      float quaternionW,
      float scaleX,
      float scaleY,
      float scaleZ)
    {
      float num1 = quaternionX * 2f;
      float num2 = quaternionY * 2f;
      float num3 = quaternionZ * 2f;
      float num4 = quaternionW * num1;
      float num5 = quaternionW * num2;
      float num6 = quaternionW * num3;
      float num7 = quaternionX * num1;
      float num8 = quaternionX * num2;
      float num9 = quaternionX * num3;
      float num10 = quaternionY * num2;
      float num11 = quaternionY * num3;
      float num12 = quaternionZ * num3;
      this.__\u003C\u003Eval[0] = scaleX * (1f - (num10 + num12));
      this.__\u003C\u003Eval[4] = scaleY * (num8 - num6);
      this.__\u003C\u003Eval[8] = scaleZ * (num9 + num5);
      this.__\u003C\u003Eval[12] = translationX;
      this.__\u003C\u003Eval[1] = scaleX * (num8 + num6);
      this.__\u003C\u003Eval[5] = scaleY * (1f - (num7 + num12));
      this.__\u003C\u003Eval[9] = scaleZ * (num11 - num4);
      this.__\u003C\u003Eval[13] = translationY;
      this.__\u003C\u003Eval[2] = scaleX * (num9 - num5);
      this.__\u003C\u003Eval[6] = scaleY * (num11 + num4);
      this.__\u003C\u003Eval[10] = scaleZ * (1f - (num7 + num10));
      this.__\u003C\u003Eval[14] = translationZ;
      this.__\u003C\u003Eval[3] = 0.0f;
      this.__\u003C\u003Eval[7] = 0.0f;
      this.__\u003C\u003Eval[11] = 0.0f;
      this.__\u003C\u003Eval[15] = 1f;
      return this;
    }

    [LineNumberTable(new byte[] {40, 232, 50, 237, 79, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Mat3D(Mat3D matrix)
    {
      Mat3D mat3D = this;
      this.__\u003C\u003Eval = new float[16];
      this.set(matrix);
    }

    [LineNumberTable(new byte[] {164, 97, 127, 15, 127, 15, 127, 18, 127, 20, 127, 16, 127, 16, 127, 20, 127, 21, 127, 16, 127, 16, 127, 20, 127, 21, 127, 16, 127, 16, 127, 20, 127, 21, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void mul(float[] mata, float[] matb)
    {
      Mat3D.tmp[0] = mata[0] * matb[0] + mata[4] * matb[1] + mata[8] * matb[2] + mata[12] * matb[3];
      Mat3D.tmp[4] = mata[0] * matb[4] + mata[4] * matb[5] + mata[8] * matb[6] + mata[12] * matb[7];
      Mat3D.tmp[8] = mata[0] * matb[8] + mata[4] * matb[9] + mata[8] * matb[10] + mata[12] * matb[11];
      Mat3D.tmp[12] = mata[0] * matb[12] + mata[4] * matb[13] + mata[8] * matb[14] + mata[12] * matb[15];
      Mat3D.tmp[1] = mata[1] * matb[0] + mata[5] * matb[1] + mata[9] * matb[2] + mata[13] * matb[3];
      Mat3D.tmp[5] = mata[1] * matb[4] + mata[5] * matb[5] + mata[9] * matb[6] + mata[13] * matb[7];
      Mat3D.tmp[9] = mata[1] * matb[8] + mata[5] * matb[9] + mata[9] * matb[10] + mata[13] * matb[11];
      Mat3D.tmp[13] = mata[1] * matb[12] + mata[5] * matb[13] + mata[9] * matb[14] + mata[13] * matb[15];
      Mat3D.tmp[2] = mata[2] * matb[0] + mata[6] * matb[1] + mata[10] * matb[2] + mata[14] * matb[3];
      Mat3D.tmp[6] = mata[2] * matb[4] + mata[6] * matb[5] + mata[10] * matb[6] + mata[14] * matb[7];
      Mat3D.tmp[10] = mata[2] * matb[8] + mata[6] * matb[9] + mata[10] * matb[10] + mata[14] * matb[11];
      Mat3D.tmp[14] = mata[2] * matb[12] + mata[6] * matb[13] + mata[10] * matb[14] + mata[14] * matb[15];
      Mat3D.tmp[3] = mata[3] * matb[0] + mata[7] * matb[1] + mata[11] * matb[2] + mata[15] * matb[3];
      Mat3D.tmp[7] = mata[3] * matb[4] + mata[7] * matb[5] + mata[11] * matb[6] + mata[15] * matb[7];
      Mat3D.tmp[11] = mata[3] * matb[8] + mata[7] * matb[9] + mata[11] * matb[10] + mata[15] * matb[11];
      Mat3D.tmp[15] = mata[3] * matb[12] + mata[7] * matb[13] + mata[11] * matb[14] + mata[15] * matb[15];
      ByteCodeHelper.arraycopy_primitive_4((Array) Mat3D.tmp, 0, (Array) mata, 0, 16);
    }

    [LineNumberTable(new byte[] {161, 20, 109, 109, 109, 110, 109, 109, 110, 110, 109, 109, 110, 110, 109, 109, 110, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Mat3D idt()
    {
      this.__\u003C\u003Eval[0] = 1f;
      this.__\u003C\u003Eval[4] = 0.0f;
      this.__\u003C\u003Eval[8] = 0.0f;
      this.__\u003C\u003Eval[12] = 0.0f;
      this.__\u003C\u003Eval[1] = 0.0f;
      this.__\u003C\u003Eval[5] = 1f;
      this.__\u003C\u003Eval[9] = 0.0f;
      this.__\u003C\u003Eval[13] = 0.0f;
      this.__\u003C\u003Eval[2] = 0.0f;
      this.__\u003C\u003Eval[6] = 0.0f;
      this.__\u003C\u003Eval[10] = 1f;
      this.__\u003C\u003Eval[14] = 0.0f;
      this.__\u003C\u003Eval[3] = 0.0f;
      this.__\u003C\u003Eval[7] = 0.0f;
      this.__\u003C\u003Eval[11] = 0.0f;
      this.__\u003C\u003Eval[15] = 1f;
      return this;
    }

    [LineNumberTable(new byte[] {163, 4, 113, 113, 113, 127, 0, 103, 114, 114, 114, 114, 114, 115, 115, 115, 148})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Mat3D setToLookAt(Vec3 direction, Vec3 up)
    {
      Mat3D.l_vez.set(direction).nor();
      Mat3D.l_vex.set(direction).nor();
      Mat3D.l_vex.crs(up).nor();
      Mat3D.l_vey.set(Mat3D.l_vex).crs(Mat3D.l_vez).nor();
      this.idt();
      this.__\u003C\u003Eval[0] = Mat3D.l_vex.x;
      this.__\u003C\u003Eval[4] = Mat3D.l_vex.y;
      this.__\u003C\u003Eval[8] = Mat3D.l_vex.z;
      this.__\u003C\u003Eval[1] = Mat3D.l_vey.x;
      this.__\u003C\u003Eval[5] = Mat3D.l_vey.y;
      this.__\u003C\u003Eval[9] = Mat3D.l_vey.z;
      this.__\u003C\u003Eval[2] = -Mat3D.l_vez.x;
      this.__\u003C\u003Eval[6] = -Mat3D.l_vez.y;
      this.__\u003C\u003Eval[10] = -Mat3D.l_vez.z;
      return this;
    }

    [LineNumberTable(new byte[] {162, 61, 103, 107, 107, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Mat3D setToTranslation(float x, float y, float z)
    {
      this.idt();
      this.__\u003C\u003Eval[12] = x;
      this.__\u003C\u003Eval[13] = y;
      this.__\u003C\u003Eval[14] = z;
      return this;
    }

    [LineNumberTable(new byte[] {160, 163, 110, 110, 110, 110, 110, 111, 110, 110, 111, 112, 112, 112, 109, 109, 110, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Mat3D set(Vec3 xAxis, Vec3 yAxis, Vec3 zAxis, Vec3 pos)
    {
      this.__\u003C\u003Eval[0] = xAxis.x;
      this.__\u003C\u003Eval[4] = xAxis.y;
      this.__\u003C\u003Eval[8] = xAxis.z;
      this.__\u003C\u003Eval[1] = yAxis.x;
      this.__\u003C\u003Eval[5] = yAxis.y;
      this.__\u003C\u003Eval[9] = yAxis.z;
      this.__\u003C\u003Eval[2] = zAxis.x;
      this.__\u003C\u003Eval[6] = zAxis.y;
      this.__\u003C\u003Eval[10] = zAxis.z;
      this.__\u003C\u003Eval[12] = pos.x;
      this.__\u003C\u003Eval[13] = pos.y;
      this.__\u003C\u003Eval[14] = pos.z;
      this.__\u003C\u003Eval[3] = 0.0f;
      this.__\u003C\u003Eval[7] = 0.0f;
      this.__\u003C\u003Eval[11] = 0.0f;
      this.__\u003C\u003Eval[15] = 1f;
      return this;
    }

    [LineNumberTable(1217)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec3 getScale(Vec3 scale) => scale.set(this.getScaleX(), this.getScaleY(), this.getScaleZ());

    [LineNumberTable(1176)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Quat getRotation(Quat rotation) => rotation.setFromMatrix(this);

    [LineNumberTable(new byte[] {164, 16, 111, 111, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec3 getTranslation(Vec3 position)
    {
      position.x = this.__\u003C\u003Eval[12];
      position.y = this.__\u003C\u003Eval[13];
      position.z = this.__\u003C\u003Eval[14];
      return position;
    }

    [LineNumberTable(new byte[] {162, 226, 103, 110, 110, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Mat3D setToScaling(Vec3 vector)
    {
      this.idt();
      this.__\u003C\u003Eval[0] = vector.x;
      this.__\u003C\u003Eval[5] = vector.y;
      this.__\u003C\u003Eval[10] = vector.z;
      return this;
    }

    [LineNumberTable(new byte[] {165, 92, 107, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Mat3D rotate(Quat rotation)
    {
      rotation.toMatrix(Mat3D.tmp);
      Mat3D.mul(this.__\u003C\u003Eval, Mat3D.tmp);
      return this;
    }

    [LineNumberTable(new byte[] {162, 18, 111, 111, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Mat3D setTranslation(Vec3 vector)
    {
      this.__\u003C\u003Eval[12] = vector.x;
      this.__\u003C\u003Eval[13] = vector.y;
      this.__\u003C\u003Eval[14] = vector.z;
      return this;
    }

    [LineNumberTable(1181)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getScaleXSquared() => this.__\u003C\u003Eval[0] * this.__\u003C\u003Eval[0] + this.__\u003C\u003Eval[4] * this.__\u003C\u003Eval[4] + this.__\u003C\u003Eval[8] * this.__\u003C\u003Eval[8];

    [LineNumberTable(1186)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getScaleYSquared() => this.__\u003C\u003Eval[1] * this.__\u003C\u003Eval[1] + this.__\u003C\u003Eval[5] * this.__\u003C\u003Eval[5] + this.__\u003C\u003Eval[9] * this.__\u003C\u003Eval[9];

    [LineNumberTable(1191)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getScaleZSquared() => this.__\u003C\u003Eval[2] * this.__\u003C\u003Eval[2] + this.__\u003C\u003Eval[6] * this.__\u003C\u003Eval[6] + this.__\u003C\u003Eval[10] * this.__\u003C\u003Eval[10];

    [LineNumberTable(new byte[] {164, 58, 127, 15, 47})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getScaleX() => Mathf.zero(this.__\u003C\u003Eval[4]) && Mathf.zero(this.__\u003C\u003Eval[8]) ? Math.abs(this.__\u003C\u003Eval[0]) : (float) Math.sqrt((double) this.getScaleXSquared());

    [LineNumberTable(new byte[] {164, 64, 127, 16, 47})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getScaleY() => Mathf.zero(this.__\u003C\u003Eval[1]) && Mathf.zero(this.__\u003C\u003Eval[9]) ? Math.abs(this.__\u003C\u003Eval[5]) : (float) Math.sqrt((double) this.getScaleYSquared());

    [LineNumberTable(new byte[] {164, 70, 127, 16, 47})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getScaleZ() => Mathf.zero(this.__\u003C\u003Eval[2]) && Mathf.zero(this.__\u003C\u003Eval[6]) ? Math.abs(this.__\u003C\u003Eval[10]) : (float) Math.sqrt((double) this.getScaleZSquared());

    [LineNumberTable(new byte[] {160, 252, 111, 111, 111, 112, 111, 111, 112, 112, 111, 112, 113, 113, 112, 112, 113, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Mat3D tra()
    {
      Mat3D.tmp[0] = this.__\u003C\u003Eval[0];
      Mat3D.tmp[4] = this.__\u003C\u003Eval[1];
      Mat3D.tmp[8] = this.__\u003C\u003Eval[2];
      Mat3D.tmp[12] = this.__\u003C\u003Eval[3];
      Mat3D.tmp[1] = this.__\u003C\u003Eval[4];
      Mat3D.tmp[5] = this.__\u003C\u003Eval[5];
      Mat3D.tmp[9] = this.__\u003C\u003Eval[6];
      Mat3D.tmp[13] = this.__\u003C\u003Eval[7];
      Mat3D.tmp[2] = this.__\u003C\u003Eval[8];
      Mat3D.tmp[6] = this.__\u003C\u003Eval[9];
      Mat3D.tmp[10] = this.__\u003C\u003Eval[10];
      Mat3D.tmp[14] = this.__\u003C\u003Eval[11];
      Mat3D.tmp[3] = this.__\u003C\u003Eval[12];
      Mat3D.tmp[7] = this.__\u003C\u003Eval[13];
      Mat3D.tmp[11] = this.__\u003C\u003Eval[14];
      Mat3D.tmp[15] = this.__\u003C\u003Eval[15];
      return this.set(Mat3D.tmp);
    }

    [LineNumberTable(1374)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static float det(float[] val) => val[3] * val[6] * val[9] * val[12] - val[2] * val[7] * val[9] * val[12] - val[3] * val[5] * val[10] * val[12] + val[1] * val[7] * val[10] * val[12] + val[2] * val[5] * val[11] * val[12] - val[1] * val[6] * val[11] * val[12] - val[3] * val[6] * val[8] * val[13] + val[2] * val[7] * val[8] * val[13] + val[3] * val[4] * val[10] * val[13] - val[0] * val[7] * val[10] * val[13] - val[2] * val[4] * val[11] * val[13] + val[0] * val[6] * val[11] * val[13] + val[3] * val[5] * val[8] * val[14] - val[1] * val[7] * val[8] * val[14] - val[3] * val[4] * val[9] * val[14] + val[0] * val[7] * val[9] * val[14] + val[1] * val[4] * val[11] * val[14] - val[0] * val[5] * val[11] * val[14] - val[2] * val[5] * val[8] * val[15] + val[1] * val[6] * val[8] * val[15] + val[2] * val[4] * val[9] * val[15] - val[0] * val[6] * val[9] * val[15] - val[1] * val[4] * val[10] * val[15] + val[0] * val[5] * val[10] * val[15];

    [LineNumberTable(new byte[] {165, 9, 108, 108, 108, 106, 108, 108, 109, 106, 108, 108, 109, 106, 108, 108, 109, 141, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Mat3D translate(float x, float y, float z)
    {
      Mat3D.tmp[0] = 1f;
      Mat3D.tmp[4] = 0.0f;
      Mat3D.tmp[8] = 0.0f;
      Mat3D.tmp[12] = x;
      Mat3D.tmp[1] = 0.0f;
      Mat3D.tmp[5] = 1f;
      Mat3D.tmp[9] = 0.0f;
      Mat3D.tmp[13] = y;
      Mat3D.tmp[2] = 0.0f;
      Mat3D.tmp[6] = 0.0f;
      Mat3D.tmp[10] = 1f;
      Mat3D.tmp[14] = z;
      Mat3D.tmp[3] = 0.0f;
      Mat3D.tmp[7] = 0.0f;
      Mat3D.tmp[11] = 0.0f;
      Mat3D.tmp[15] = 1f;
      Mat3D.mul(this.__\u003C\u003Eval, Mat3D.tmp);
      return this;
    }

    [LineNumberTable(new byte[] {49, 232, 41, 237, 88, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Mat3D(float[] values)
    {
      Mat3D mat3D = this;
      this.__\u003C\u003Eval = new float[16];
      this.set(values);
    }

    [LineNumberTable(new byte[] {57, 232, 33, 237, 96, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Mat3D(Quat quat)
    {
      Mat3D mat3D = this;
      this.__\u003C\u003Eval = new float[16];
      this.set(quat);
    }

    [LineNumberTable(new byte[] {67, 232, 23, 237, 106, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Mat3D(Vec3 position, Quat rotation, Vec3 scale)
    {
      Mat3D mat3D = this;
      this.__\u003C\u003Eval = new float[16];
      this.set(position, rotation, scale);
    }

    [LineNumberTable(170)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Mat3D set(Vec3 position, Quat orientation) => this.set(position.x, position.y, position.z, orientation.x, orientation.y, orientation.z, orientation.w);

    [LineNumberTable(298)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Mat3D cpy() => new Mat3D(this);

    [LineNumberTable(new byte[] {160, 193, 120, 120, 120})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Mat3D trn(Vec3 vector)
    {
      float[] val1 = this.__\u003C\u003Eval;
      int index1 = 12;
      float[] numArray1 = val1;
      numArray1[index1] = numArray1[index1] + vector.x;
      float[] val2 = this.__\u003C\u003Eval;
      int index2 = 13;
      float[] numArray2 = val2;
      numArray2[index2] = numArray2[index2] + vector.y;
      float[] val3 = this.__\u003C\u003Eval;
      int index3 = 14;
      float[] numArray3 = val3;
      numArray3[index3] = numArray3[index3] + vector.z;
      return this;
    }

    [LineNumberTable(new byte[] {160, 207, 116, 116, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Mat3D trn(float x, float y, float z)
    {
      float[] val1 = this.__\u003C\u003Eval;
      int index1 = 12;
      float[] numArray1 = val1;
      numArray1[index1] = numArray1[index1] + x;
      float[] val2 = this.__\u003C\u003Eval;
      int index2 = 13;
      float[] numArray2 = val2;
      numArray2[index2] = numArray2[index2] + y;
      float[] val3 = this.__\u003C\u003Eval;
      int index3 = 14;
      float[] numArray3 = val3;
      numArray3[index3] = numArray3[index3] + z;
      return this;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float[] getValues() => this.__\u003C\u003Eval;

    [LineNumberTable(new byte[] {160, 242, 108, 117})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Mat3D mulLeft(Mat3D matrix)
    {
      Mat3D.tmpMat.set(matrix);
      Mat3D.mul(Mat3D.tmpMat.__\u003C\u003Eval, this.__\u003C\u003Eval);
      return this.set(Mat3D.tmpMat);
    }

    [LineNumberTable(479)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float det() => this.__\u003C\u003Eval[3] * this.__\u003C\u003Eval[6] * this.__\u003C\u003Eval[9] * this.__\u003C\u003Eval[12] - this.__\u003C\u003Eval[2] * this.__\u003C\u003Eval[7] * this.__\u003C\u003Eval[9] * this.__\u003C\u003Eval[12] - this.__\u003C\u003Eval[3] * this.__\u003C\u003Eval[5] * this.__\u003C\u003Eval[10] * this.__\u003C\u003Eval[12] + this.__\u003C\u003Eval[1] * this.__\u003C\u003Eval[7] * this.__\u003C\u003Eval[10] * this.__\u003C\u003Eval[12] + this.__\u003C\u003Eval[2] * this.__\u003C\u003Eval[5] * this.__\u003C\u003Eval[11] * this.__\u003C\u003Eval[12] - this.__\u003C\u003Eval[1] * this.__\u003C\u003Eval[6] * this.__\u003C\u003Eval[11] * this.__\u003C\u003Eval[12] - this.__\u003C\u003Eval[3] * this.__\u003C\u003Eval[6] * this.__\u003C\u003Eval[8] * this.__\u003C\u003Eval[13] + this.__\u003C\u003Eval[2] * this.__\u003C\u003Eval[7] * this.__\u003C\u003Eval[8] * this.__\u003C\u003Eval[13] + this.__\u003C\u003Eval[3] * this.__\u003C\u003Eval[4] * this.__\u003C\u003Eval[10] * this.__\u003C\u003Eval[13] - this.__\u003C\u003Eval[0] * this.__\u003C\u003Eval[7] * this.__\u003C\u003Eval[10] * this.__\u003C\u003Eval[13] - this.__\u003C\u003Eval[2] * this.__\u003C\u003Eval[4] * this.__\u003C\u003Eval[11] * this.__\u003C\u003Eval[13] + this.__\u003C\u003Eval[0] * this.__\u003C\u003Eval[6] * this.__\u003C\u003Eval[11] * this.__\u003C\u003Eval[13] + this.__\u003C\u003Eval[3] * this.__\u003C\u003Eval[5] * this.__\u003C\u003Eval[8] * this.__\u003C\u003Eval[14] - this.__\u003C\u003Eval[1] * this.__\u003C\u003Eval[7] * this.__\u003C\u003Eval[8] * this.__\u003C\u003Eval[14] - this.__\u003C\u003Eval[3] * this.__\u003C\u003Eval[4] * this.__\u003C\u003Eval[9] * this.__\u003C\u003Eval[14] + this.__\u003C\u003Eval[0] * this.__\u003C\u003Eval[7] * this.__\u003C\u003Eval[9] * this.__\u003C\u003Eval[14] + this.__\u003C\u003Eval[1] * this.__\u003C\u003Eval[4] * this.__\u003C\u003Eval[11] * this.__\u003C\u003Eval[14] - this.__\u003C\u003Eval[0] * this.__\u003C\u003Eval[5] * this.__\u003C\u003Eval[11] * this.__\u003C\u003Eval[14] - this.__\u003C\u003Eval[2] * this.__\u003C\u003Eval[5] * this.__\u003C\u003Eval[8] * this.__\u003C\u003Eval[15] + this.__\u003C\u003Eval[1] * this.__\u003C\u003Eval[6] * this.__\u003C\u003Eval[8] * this.__\u003C\u003Eval[15] + this.__\u003C\u003Eval[2] * this.__\u003C\u003Eval[4] * this.__\u003C\u003Eval[9] * this.__\u003C\u003Eval[15] - this.__\u003C\u003Eval[0] * this.__\u003C\u003Eval[6] * this.__\u003C\u003Eval[9] * this.__\u003C\u003Eval[15] - this.__\u003C\u003Eval[1] * this.__\u003C\u003Eval[4] * this.__\u003C\u003Eval[10] * this.__\u003C\u003Eval[15] + this.__\u003C\u003Eval[0] * this.__\u003C\u003Eval[5] * this.__\u003C\u003Eval[10] * this.__\u003C\u003Eval[15];

    [LineNumberTable(492)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float det3x3() => this.__\u003C\u003Eval[0] * this.__\u003C\u003Eval[5] * this.__\u003C\u003Eval[10] + this.__\u003C\u003Eval[4] * this.__\u003C\u003Eval[9] * this.__\u003C\u003Eval[2] + this.__\u003C\u003Eval[8] * this.__\u003C\u003Eval[1] * this.__\u003C\u003Eval[6] - this.__\u003C\u003Eval[0] * this.__\u003C\u003Eval[9] * this.__\u003C\u003Eval[6] - this.__\u003C\u003Eval[4] * this.__\u003C\u003Eval[1] * this.__\u003C\u003Eval[10] - this.__\u003C\u003Eval[8] * this.__\u003C\u003Eval[5] * this.__\u003C\u003Eval[2];

    [LineNumberTable(new byte[] {161, 170, 115, 116, 111, 113, 116, 123, 105, 109, 109, 109, 109, 105, 109, 109, 105, 106, 107, 110, 110, 110, 107, 142})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Mat3D setToProjection(
      float left,
      float right,
      float bottom,
      float top,
      float near,
      float far)
    {
      float num1 = 2f * near / (right - left);
      float num2 = 2f * near / (top - bottom);
      float num3 = (right + left) / (right - left);
      float num4 = (top + bottom) / (top - bottom);
      float num5 = (far + near) / (near - far);
      float num6 = 2f * far * near / (near - far);
      this.__\u003C\u003Eval[0] = num1;
      this.__\u003C\u003Eval[1] = 0.0f;
      this.__\u003C\u003Eval[2] = 0.0f;
      this.__\u003C\u003Eval[3] = 0.0f;
      this.__\u003C\u003Eval[4] = 0.0f;
      this.__\u003C\u003Eval[5] = num2;
      this.__\u003C\u003Eval[6] = 0.0f;
      this.__\u003C\u003Eval[7] = 0.0f;
      this.__\u003C\u003Eval[8] = num3;
      this.__\u003C\u003Eval[9] = num4;
      this.__\u003C\u003Eval[10] = num5;
      this.__\u003C\u003Eval[11] = -1f;
      this.__\u003C\u003Eval[12] = 0.0f;
      this.__\u003C\u003Eval[13] = 0.0f;
      this.__\u003C\u003Eval[14] = num6;
      this.__\u003C\u003Eval[15] = 0.0f;
      return this;
    }

    [LineNumberTable(new byte[] {161, 206, 127, 3})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Mat3D setToOrtho2D(float x, float y, float width, float height)
    {
      this.setToOrtho(x, x + width, y, y + height, 0.0f, 1f);
      return this;
    }

    [LineNumberTable(new byte[] {161, 222, 126})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Mat3D setToOrtho2D(
      float x,
      float y,
      float width,
      float height,
      float near,
      float far)
    {
      this.setToOrtho(x, x + width, y, y + height, near, far);
      return this;
    }

    [LineNumberTable(new byte[] {162, 32, 107, 107, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Mat3D setTranslation(float x, float y, float z)
    {
      this.__\u003C\u003Eval[12] = x;
      this.__\u003C\u003Eval[13] = y;
      this.__\u003C\u003Eval[14] = z;
      return this;
    }

    [LineNumberTable(new byte[] {162, 76, 103, 111, 111, 111, 110, 110, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Mat3D setToTranslationAndScaling(Vec3 translation, Vec3 scaling)
    {
      this.idt();
      this.__\u003C\u003Eval[12] = translation.x;
      this.__\u003C\u003Eval[13] = translation.y;
      this.__\u003C\u003Eval[14] = translation.z;
      this.__\u003C\u003Eval[0] = scaling.x;
      this.__\u003C\u003Eval[5] = scaling.y;
      this.__\u003C\u003Eval[10] = scaling.z;
      return this;
    }

    [LineNumberTable(new byte[] {162, 99, 103, 107, 107, 107, 107, 107, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Mat3D setToTranslationAndScaling(
      float translationX,
      float translationY,
      float translationZ,
      float scalingX,
      float scalingY,
      float scalingZ)
    {
      this.idt();
      this.__\u003C\u003Eval[12] = translationX;
      this.__\u003C\u003Eval[13] = translationY;
      this.__\u003C\u003Eval[14] = translationZ;
      this.__\u003C\u003Eval[0] = scalingX;
      this.__\u003C\u003Eval[5] = scalingY;
      this.__\u003C\u003Eval[10] = scalingZ;
      return this;
    }

    [LineNumberTable(new byte[] {162, 119, 105, 103, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Mat3D setToRotation(Vec3 axis, float degrees)
    {
      if ((double) degrees != 0.0)
        return this.set(Mat3D.quat.set(axis, degrees));
      this.idt();
      return this;
    }

    [LineNumberTable(new byte[] {162, 133, 105, 103, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Mat3D setToRotationRad(Vec3 axis, float radians)
    {
      if ((double) radians != 0.0)
        return this.set(Mat3D.quat.setFromAxisRad(axis, radians));
      this.idt();
      return this;
    }

    [LineNumberTable(new byte[] {162, 149, 106, 103, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Mat3D setToRotation(float axisX, float axisY, float axisZ, float degrees)
    {
      if ((double) degrees != 0.0)
        return this.set(Mat3D.quat.setFromAxis(axisX, axisY, axisZ, degrees));
      this.idt();
      return this;
    }

    [LineNumberTable(new byte[] {162, 165, 106, 103, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Mat3D setToRotationRad(
      float axisX,
      float axisY,
      float axisZ,
      float radians)
    {
      if ((double) radians != 0.0)
        return this.set(Mat3D.quat.setFromAxisRad(axisX, axisY, axisZ, radians));
      this.idt();
      return this;
    }

    [LineNumberTable(805)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Mat3D setToRotation(Vec3 v1, Vec3 v2) => this.set(Mat3D.quat.setFromCross(v1, v2));

    [LineNumberTable(819)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Mat3D setToRotation(
      float x1,
      float y1,
      float z1,
      float x2,
      float y2,
      float z2)
    {
      return this.set(Mat3D.quat.setFromCross(x1, y1, z1, x2, y2, z2));
    }

    [LineNumberTable(new byte[] {162, 204, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Mat3D setFromEulerAngles(float yaw, float pitch, float roll)
    {
      Mat3D.quat.setEulerAngles(yaw, pitch, roll);
      return this.set(Mat3D.quat);
    }

    [LineNumberTable(new byte[] {162, 216, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Mat3D setFromEulerAnglesRad(float yaw, float pitch, float roll)
    {
      Mat3D.quat.setEulerAnglesRad(yaw, pitch, roll);
      return this.set(Mat3D.quat);
    }

    [LineNumberTable(new byte[] {162, 241, 103, 106, 106, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Mat3D setToScaling(float x, float y, float z)
    {
      this.idt();
      this.__\u003C\u003Eval[0] = x;
      this.__\u003C\u003Eval[5] = y;
      this.__\u003C\u003Eval[10] = z;
      return this;
    }

    [LineNumberTable(new byte[] {163, 45, 113, 123, 159, 0, 127, 2})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Mat3D setToWorld(Vec3 position, Vec3 forward, Vec3 up)
    {
      Mat3D.tmpForward.set(forward).nor();
      Mat3D.right.set(Mat3D.tmpForward).crs(up).nor();
      Mat3D.tmpUp.set(Mat3D.right).crs(Mat3D.tmpForward).nor();
      this.set(Mat3D.right, Mat3D.tmpUp, Mat3D.tmpForward.scl(-1f), position);
      return this;
    }

    [LineNumberTable(936)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toString() => new StringBuilder().append("[").append(this.__\u003C\u003Eval[0]).append("|").append(this.__\u003C\u003Eval[4]).append("|").append(this.__\u003C\u003Eval[8]).append("|").append(this.__\u003C\u003Eval[12]).append("]\n[").append(this.__\u003C\u003Eval[1]).append("|").append(this.__\u003C\u003Eval[5]).append("|").append(this.__\u003C\u003Eval[9]).append("|").append(this.__\u003C\u003Eval[13]).append("]\n[").append(this.__\u003C\u003Eval[2]).append("|").append(this.__\u003C\u003Eval[6]).append("|").append(this.__\u003C\u003Eval[10]).append("|").append(this.__\u003C\u003Eval[14]).append("]\n[").append(this.__\u003C\u003Eval[3]).append("|").append(this.__\u003C\u003Eval[7]).append("|").append(this.__\u003C\u003Eval[11]).append("|").append(this.__\u003C\u003Eval[15]).append("]\n").toString();

    [LineNumberTable(new byte[] {163, 66, 103, 63, 10, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Mat3D lerp(Mat3D matrix, float alpha)
    {
      for (int index = 0; index < 16; ++index)
        this.__\u003C\u003Eval[index] = this.__\u003C\u003Eval[index] * (1f - alpha) + matrix.__\u003C\u003Eval[index] * alpha;
      return this;
    }

    [LineNumberTable(new byte[] {163, 79, 108, 140, 108, 140, 108, 140, 127, 12, 127, 0, 159, 12})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Mat3D avg(Mat3D other, float w)
    {
      this.getScale(Mat3D.tmpVec);
      other.getScale(Mat3D.tmpForward);
      this.getRotation(Mat3D.quat);
      other.getRotation(Mat3D.quat2);
      this.getTranslation(Mat3D.tmpUp);
      other.getTranslation(Mat3D.right);
      this.setToScaling(Mat3D.tmpVec.scl(w).add(Mat3D.tmpForward.scl(1f - w)));
      this.rotate(Mat3D.quat.slerp(Mat3D.quat2, 1f - w));
      this.setTranslation(Mat3D.tmpUp.scl(w).add(Mat3D.right.scl(1f - w)));
      return this;
    }

    [LineNumberTable(new byte[] {163, 102, 139, 126, 126, 158, 103, 126, 126, 254, 61, 233, 69, 139, 108, 108, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Mat3D avg(Mat3D[] t)
    {
      float num = 1f / (float) t.Length;
      Mat3D.tmpVec.set(t[0].getScale(Mat3D.tmpUp).scl(num));
      Mat3D.quat.set(t[0].getRotation(Mat3D.quat2).exp(num));
      Mat3D.tmpForward.set(t[0].getTranslation(Mat3D.tmpUp).scl(num));
      for (int index = 1; index < t.Length; ++index)
      {
        Mat3D.tmpVec.add(t[index].getScale(Mat3D.tmpUp).scl(num));
        Mat3D.quat.mul(t[index].getRotation(Mat3D.quat2).exp(num));
        Mat3D.tmpForward.add(t[index].getTranslation(Mat3D.tmpUp).scl(num));
      }
      Mat3D.quat.nor();
      this.setToScaling(Mat3D.tmpVec);
      this.rotate(Mat3D.quat);
      this.setTranslation(Mat3D.tmpForward);
      return this;
    }

    [LineNumberTable(new byte[] {163, 131, 127, 1, 127, 1, 159, 1, 106, 127, 1, 127, 1, 255, 1, 61, 233, 69, 139, 108, 108, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Mat3D avg(Mat3D[] t, float[] w)
    {
      Mat3D.tmpVec.set(t[0].getScale(Mat3D.tmpUp).scl(w[0]));
      Mat3D.quat.set(t[0].getRotation(Mat3D.quat2).exp(w[0]));
      Mat3D.tmpForward.set(t[0].getTranslation(Mat3D.tmpUp).scl(w[0]));
      for (int index = 1; index < t.Length; ++index)
      {
        Mat3D.tmpVec.add(t[index].getScale(Mat3D.tmpUp).scl(w[index]));
        Mat3D.quat.mul(t[index].getRotation(Mat3D.quat2).exp(w[index]));
        Mat3D.tmpForward.add(t[index].getTranslation(Mat3D.tmpUp).scl(w[index]));
      }
      Mat3D.quat.nor();
      this.setToScaling(Mat3D.tmpVec);
      this.rotate(Mat3D.quat);
      this.setTranslation(Mat3D.tmpForward);
      return this;
    }

    [LineNumberTable(new byte[] {163, 154, 112, 112, 112, 109, 112, 112, 112, 109, 109, 110, 110, 110, 113, 113, 110, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Mat3D set(Mat mat)
    {
      this.__\u003C\u003Eval[0] = mat.val[0];
      this.__\u003C\u003Eval[1] = mat.val[1];
      this.__\u003C\u003Eval[2] = mat.val[2];
      this.__\u003C\u003Eval[3] = 0.0f;
      this.__\u003C\u003Eval[4] = mat.val[3];
      this.__\u003C\u003Eval[5] = mat.val[4];
      this.__\u003C\u003Eval[6] = mat.val[5];
      this.__\u003C\u003Eval[7] = 0.0f;
      this.__\u003C\u003Eval[8] = 0.0f;
      this.__\u003C\u003Eval[9] = 0.0f;
      this.__\u003C\u003Eval[10] = 1f;
      this.__\u003C\u003Eval[11] = 0.0f;
      this.__\u003C\u003Eval[12] = mat.val[6];
      this.__\u003C\u003Eval[13] = mat.val[7];
      this.__\u003C\u003Eval[14] = 0.0f;
      this.__\u003C\u003Eval[15] = mat.val[8];
      return this;
    }

    [LineNumberTable(new byte[] {163, 186, 110, 110, 109, 109, 110, 110, 109, 109, 109, 110, 110, 110, 111, 111, 110, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Mat3D set(Affine2 affine)
    {
      this.__\u003C\u003Eval[0] = affine.m00;
      this.__\u003C\u003Eval[1] = affine.m10;
      this.__\u003C\u003Eval[2] = 0.0f;
      this.__\u003C\u003Eval[3] = 0.0f;
      this.__\u003C\u003Eval[4] = affine.m01;
      this.__\u003C\u003Eval[5] = affine.m11;
      this.__\u003C\u003Eval[6] = 0.0f;
      this.__\u003C\u003Eval[7] = 0.0f;
      this.__\u003C\u003Eval[8] = 0.0f;
      this.__\u003C\u003Eval[9] = 0.0f;
      this.__\u003C\u003Eval[10] = 1f;
      this.__\u003C\u003Eval[11] = 0.0f;
      this.__\u003C\u003Eval[12] = affine.m02;
      this.__\u003C\u003Eval[13] = affine.m12;
      this.__\u003C\u003Eval[14] = 0.0f;
      this.__\u003C\u003Eval[15] = 1f;
      return this;
    }

    [LineNumberTable(new byte[] {163, 219, 110, 110, 110, 110, 111, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Mat3D setAsAffine(Affine2 affine)
    {
      this.__\u003C\u003Eval[0] = affine.m00;
      this.__\u003C\u003Eval[1] = affine.m10;
      this.__\u003C\u003Eval[4] = affine.m01;
      this.__\u003C\u003Eval[5] = affine.m11;
      this.__\u003C\u003Eval[12] = affine.m02;
      this.__\u003C\u003Eval[13] = affine.m12;
      return this;
    }

    [LineNumberTable(new byte[] {163, 241, 112, 112, 112, 112, 114, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Mat3D setAsAffine(Mat3D mat)
    {
      this.__\u003C\u003Eval[0] = mat.__\u003C\u003Eval[0];
      this.__\u003C\u003Eval[1] = mat.__\u003C\u003Eval[1];
      this.__\u003C\u003Eval[4] = mat.__\u003C\u003Eval[4];
      this.__\u003C\u003Eval[5] = mat.__\u003C\u003Eval[5];
      this.__\u003C\u003Eval[12] = mat.__\u003C\u003Eval[12];
      this.__\u003C\u003Eval[13] = mat.__\u003C\u003Eval[13];
      return this;
    }

    [LineNumberTable(new byte[] {163, 251, 119, 119, 120})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Mat3D scl(Vec3 scale)
    {
      float[] val1 = this.__\u003C\u003Eval;
      int index1 = 0;
      float[] numArray1 = val1;
      numArray1[index1] = numArray1[index1] * scale.x;
      float[] val2 = this.__\u003C\u003Eval;
      int index2 = 5;
      float[] numArray2 = val2;
      numArray2[index2] = numArray2[index2] * scale.y;
      float[] val3 = this.__\u003C\u003Eval;
      int index3 = 10;
      float[] numArray3 = val3;
      numArray3[index3] = numArray3[index3] * scale.z;
      return this;
    }

    [LineNumberTable(new byte[] {164, 2, 115, 115, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Mat3D scl(float x, float y, float z)
    {
      float[] val1 = this.__\u003C\u003Eval;
      int index1 = 0;
      float[] numArray1 = val1;
      numArray1[index1] = numArray1[index1] * x;
      float[] val2 = this.__\u003C\u003Eval;
      int index2 = 5;
      float[] numArray2 = val2;
      numArray2[index2] = numArray2[index2] * y;
      float[] val3 = this.__\u003C\u003Eval;
      int index3 = 10;
      float[] numArray3 = val3;
      numArray3[index3] = numArray3[index3] * z;
      return this;
    }

    [LineNumberTable(new byte[] {164, 9, 115, 115, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Mat3D scl(float scale)
    {
      float[] val1 = this.__\u003C\u003Eval;
      int index1 = 0;
      float[] numArray1 = val1;
      numArray1[index1] = numArray1[index1] * scale;
      float[] val2 = this.__\u003C\u003Eval;
      int index2 = 5;
      float[] numArray2 = val2;
      numArray2[index2] = numArray2[index2] * scale;
      float[] val3 = this.__\u003C\u003Eval;
      int index3 = 10;
      float[] numArray3 = val3;
      numArray3[index3] = numArray3[index3] * scale;
      return this;
    }

    [LineNumberTable(1167)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Quat getRotation(Quat rotation, bool normalizeAxes)
    {
      int num = normalizeAxes ? 1 : 0;
      return rotation.setFromMatrix(num != 0, this);
    }

    [LineNumberTable(new byte[] {164, 84, 110, 110, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Mat3D toNormalMatrix()
    {
      this.__\u003C\u003Eval[12] = 0.0f;
      this.__\u003C\u003Eval[13] = 0.0f;
      this.__\u003C\u003Eval[14] = 0.0f;
      return this.inv().tra();
    }

    [LineNumberTable(new byte[] {164, 125, 127, 4, 127, 5, 127, 5, 100, 100, 100})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void mulVec(float[] mat, float[] vec)
    {
      float num1 = vec[0] * mat[0] + vec[1] * mat[4] + vec[2] * mat[8] + mat[12];
      float num2 = vec[0] * mat[1] + vec[1] * mat[5] + vec[2] * mat[9] + mat[13];
      float num3 = vec[0] * mat[2] + vec[1] * mat[6] + vec[2] * mat[10] + mat[14];
      vec[0] = num1;
      vec[1] = num2;
      vec[2] = num3;
    }

    [LineNumberTable(new byte[] {164, 142, 127, 12, 127, 7, 127, 8, 127, 8, 100, 100, 100})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void prj(float[] mat, float[] vec)
    {
      float num1 = 1f / (vec[0] * mat[3] + vec[1] * mat[7] + vec[2] * mat[11] + mat[15]);
      float num2 = (vec[0] * mat[0] + vec[1] * mat[4] + vec[2] * mat[8] + mat[12]) * num1;
      float num3 = (vec[0] * mat[1] + vec[1] * mat[5] + vec[2] * mat[9] + mat[13]) * num1;
      float num4 = (vec[0] * mat[2] + vec[1] * mat[6] + vec[2] * mat[10] + mat[14]) * num1;
      vec[0] = num2;
      vec[1] = num3;
      vec[2] = num4;
    }

    [LineNumberTable(new byte[] {164, 160, 125, 126, 126, 100, 100, 100})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void rot(float[] mat, float[] vec)
    {
      float num1 = vec[0] * mat[0] + vec[1] * mat[4] + vec[2] * mat[8];
      float num2 = vec[0] * mat[1] + vec[1] * mat[5] + vec[2] * mat[9];
      float num3 = vec[0] * mat[2] + vec[1] * mat[6] + vec[2] * mat[10];
      vec[0] = num1;
      vec[1] = num2;
      vec[2] = num3;
    }

    [LineNumberTable(new byte[] {164, 175, 104, 106, 159, 76, 159, 74, 159, 74, 159, 75, 159, 76, 159, 74, 159, 75, 159, 75, 159, 70, 159, 70, 159, 71, 159, 71, 159, 70, 159, 68, 159, 69, 159, 69, 105, 109, 109, 109, 111, 109, 109, 111, 111, 109, 109, 111, 111, 109, 109, 111, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool inv(float[] val)
    {
      float num1 = Mat3D.det(val);
      if ((double) num1 == 0.0)
        return false;
      Mat3D.tmp[0] = val[9] * val[14] * val[7] - val[13] * val[10] * val[7] + val[13] * val[6] * val[11] - val[5] * val[14] * val[11] - val[9] * val[6] * val[15] + val[5] * val[10] * val[15];
      Mat3D.tmp[4] = val[12] * val[10] * val[7] - val[8] * val[14] * val[7] - val[12] * val[6] * val[11] + val[4] * val[14] * val[11] + val[8] * val[6] * val[15] - val[4] * val[10] * val[15];
      Mat3D.tmp[8] = val[8] * val[13] * val[7] - val[12] * val[9] * val[7] + val[12] * val[5] * val[11] - val[4] * val[13] * val[11] - val[8] * val[5] * val[15] + val[4] * val[9] * val[15];
      Mat3D.tmp[12] = val[12] * val[9] * val[6] - val[8] * val[13] * val[6] - val[12] * val[5] * val[10] + val[4] * val[13] * val[10] + val[8] * val[5] * val[14] - val[4] * val[9] * val[14];
      Mat3D.tmp[1] = val[13] * val[10] * val[3] - val[9] * val[14] * val[3] - val[13] * val[2] * val[11] + val[1] * val[14] * val[11] + val[9] * val[2] * val[15] - val[1] * val[10] * val[15];
      Mat3D.tmp[5] = val[8] * val[14] * val[3] - val[12] * val[10] * val[3] + val[12] * val[2] * val[11] - val[0] * val[14] * val[11] - val[8] * val[2] * val[15] + val[0] * val[10] * val[15];
      Mat3D.tmp[9] = val[12] * val[9] * val[3] - val[8] * val[13] * val[3] - val[12] * val[1] * val[11] + val[0] * val[13] * val[11] + val[8] * val[1] * val[15] - val[0] * val[9] * val[15];
      Mat3D.tmp[13] = val[8] * val[13] * val[2] - val[12] * val[9] * val[2] + val[12] * val[1] * val[10] - val[0] * val[13] * val[10] - val[8] * val[1] * val[14] + val[0] * val[9] * val[14];
      Mat3D.tmp[2] = val[5] * val[14] * val[3] - val[13] * val[6] * val[3] + val[13] * val[2] * val[7] - val[1] * val[14] * val[7] - val[5] * val[2] * val[15] + val[1] * val[6] * val[15];
      Mat3D.tmp[6] = val[12] * val[6] * val[3] - val[4] * val[14] * val[3] - val[12] * val[2] * val[7] + val[0] * val[14] * val[7] + val[4] * val[2] * val[15] - val[0] * val[6] * val[15];
      Mat3D.tmp[10] = val[4] * val[13] * val[3] - val[12] * val[5] * val[3] + val[12] * val[1] * val[7] - val[0] * val[13] * val[7] - val[4] * val[1] * val[15] + val[0] * val[5] * val[15];
      Mat3D.tmp[14] = val[12] * val[5] * val[2] - val[4] * val[13] * val[2] - val[12] * val[1] * val[6] + val[0] * val[13] * val[6] + val[4] * val[1] * val[14] - val[0] * val[5] * val[14];
      Mat3D.tmp[3] = val[9] * val[6] * val[3] - val[5] * val[10] * val[3] - val[9] * val[2] * val[7] + val[1] * val[10] * val[7] + val[5] * val[2] * val[11] - val[1] * val[6] * val[11];
      Mat3D.tmp[7] = val[4] * val[10] * val[3] - val[8] * val[6] * val[3] + val[8] * val[2] * val[7] - val[0] * val[10] * val[7] - val[4] * val[2] * val[11] + val[0] * val[6] * val[11];
      Mat3D.tmp[11] = val[8] * val[5] * val[3] - val[4] * val[9] * val[3] - val[8] * val[1] * val[7] + val[0] * val[9] * val[7] + val[4] * val[1] * val[11] - val[0] * val[5] * val[11];
      Mat3D.tmp[15] = val[4] * val[9] * val[2] - val[8] * val[5] * val[2] + val[8] * val[1] * val[6] - val[0] * val[9] * val[6] - val[4] * val[1] * val[10] + val[0] * val[5] * val[10];
      float num2 = 1f / num1;
      val[0] = Mat3D.tmp[0] * num2;
      val[4] = Mat3D.tmp[4] * num2;
      val[8] = Mat3D.tmp[8] * num2;
      val[12] = Mat3D.tmp[12] * num2;
      val[1] = Mat3D.tmp[1] * num2;
      val[5] = Mat3D.tmp[5] * num2;
      val[9] = Mat3D.tmp[9] * num2;
      val[13] = Mat3D.tmp[13] * num2;
      val[2] = Mat3D.tmp[2] * num2;
      val[6] = Mat3D.tmp[6] * num2;
      val[10] = Mat3D.tmp[10] * num2;
      val[14] = Mat3D.tmp[14] * num2;
      val[3] = Mat3D.tmp[3] * num2;
      val[7] = Mat3D.tmp[7] * num2;
      val[11] = Mat3D.tmp[11] * num2;
      val[15] = Mat3D.tmp[15] * num2;
      return true;
    }

    [LineNumberTable(1391)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Mat3D translate(Vec3 translation) => this.translate(translation.x, translation.y, translation.z);

    [LineNumberTable(new byte[] {165, 51, 107, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Mat3D rotateRad(Vec3 axis, float radians)
    {
      if ((double) radians == 0.0)
        return this;
      Mat3D.quat.setFromAxisRad(axis, radians);
      return this.rotate(Mat3D.quat);
    }

    [LineNumberTable(new byte[] {165, 66, 108, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Mat3D rotate(float axisX, float axisY, float axisZ, float degrees)
    {
      if ((double) degrees == 0.0)
        return this;
      Mat3D.quat.setFromAxis(axisX, axisY, axisZ, degrees);
      return this.rotate(Mat3D.quat);
    }

    [LineNumberTable(new byte[] {165, 81, 108, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Mat3D rotateRad(float axisX, float axisY, float axisZ, float radians)
    {
      if ((double) radians == 0.0)
        return this;
      Mat3D.quat.setFromAxisRad(axisX, axisY, axisZ, radians);
      return this.rotate(Mat3D.quat);
    }

    [LineNumberTable(1498)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Mat3D rotate(Vec3 v1, Vec3 v2) => this.rotate(Mat3D.quat.setFromCross(v1, v2));

    [LineNumberTable(new byte[] {165, 116, 105, 108, 108, 109, 108, 105, 109, 109, 108, 108, 106, 109, 108, 108, 109, 141, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Mat3D scale(float scaleX, float scaleY, float scaleZ)
    {
      Mat3D.tmp[0] = scaleX;
      Mat3D.tmp[4] = 0.0f;
      Mat3D.tmp[8] = 0.0f;
      Mat3D.tmp[12] = 0.0f;
      Mat3D.tmp[1] = 0.0f;
      Mat3D.tmp[5] = scaleY;
      Mat3D.tmp[9] = 0.0f;
      Mat3D.tmp[13] = 0.0f;
      Mat3D.tmp[2] = 0.0f;
      Mat3D.tmp[6] = 0.0f;
      Mat3D.tmp[10] = scaleZ;
      Mat3D.tmp[14] = 0.0f;
      Mat3D.tmp[3] = 0.0f;
      Mat3D.tmp[7] = 0.0f;
      Mat3D.tmp[11] = 0.0f;
      Mat3D.tmp[15] = 1f;
      Mat3D.mul(this.__\u003C\u003Eval, Mat3D.tmp);
      return this;
    }

    [LineNumberTable(new byte[] {165, 142, 107, 107, 107, 107, 107, 107, 107, 108, 108, 109, 109, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void extract4x3Matrix(float[] dst)
    {
      dst[0] = this.__\u003C\u003Eval[0];
      dst[1] = this.__\u003C\u003Eval[1];
      dst[2] = this.__\u003C\u003Eval[2];
      dst[3] = this.__\u003C\u003Eval[4];
      dst[4] = this.__\u003C\u003Eval[5];
      dst[5] = this.__\u003C\u003Eval[6];
      dst[6] = this.__\u003C\u003Eval[8];
      dst[7] = this.__\u003C\u003Eval[9];
      dst[8] = this.__\u003C\u003Eval[10];
      dst[9] = this.__\u003C\u003Eval[12];
      dst[10] = this.__\u003C\u003Eval[13];
      dst[11] = this.__\u003C\u003Eval[14];
    }

    [LineNumberTable(new byte[] {165, 158, 127, 44, 127, 30, 26})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool hasRotationOrScaling() => !Mathf.equal(this.__\u003C\u003Eval[0], 1f) || !Mathf.equal(this.__\u003C\u003Eval[5], 1f) || (!Mathf.equal(this.__\u003C\u003Eval[10], 1f) || !Mathf.zero(this.__\u003C\u003Eval[4])) || (!Mathf.zero(this.__\u003C\u003Eval[8]) || !Mathf.zero(this.__\u003C\u003Eval[1]) || (!Mathf.zero(this.__\u003C\u003Eval[9]) || !Mathf.zero(this.__\u003C\u003Eval[2]))) || !Mathf.zero(this.__\u003C\u003Eval[6]);

    [LineNumberTable(new byte[] {165, 183, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Vec3 rot(Vec3 v, Mat3D matrix)
    {
      float[] val = matrix.__\u003C\u003Eval;
      return v.set(v.x * val[0] + v.y * val[4] + v.z * val[8], v.x * val[1] + v.y * val[5] + v.z * val[9], v.x * val[2] + v.y * val[6] + v.z * val[10]);
    }

    [LineNumberTable(new byte[] {165, 195, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Vec3 unrotate(Vec3 v, Mat3D matrix)
    {
      float[] val = matrix.__\u003C\u003Eval;
      return v.set(v.x * val[0] + v.y * val[1] + v.z * val[2], v.x * val[4] + v.y * val[5] + v.z * val[6], v.x * val[8] + v.y * val[9] + v.z * val[10]);
    }

    [LineNumberTable(new byte[] {165, 208, 103, 114, 114, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Vec3 untransform(Vec3 v, Mat3D matrix)
    {
      float[] val = matrix.__\u003C\u003Eval;
      v.x -= val[12];
      v.y -= val[12];
      v.z -= val[12];
      return v.set(v.x * val[0] + v.y * val[1] + v.z * val[2], v.x * val[4] + v.y * val[5] + v.z * val[6], v.x * val[8] + v.y * val[9] + v.z * val[10]);
    }

    [LineNumberTable(new byte[] {159, 124, 173, 236, 162, 148, 106, 234, 160, 138, 106, 106, 234, 92, 106, 234, 81, 106, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static Mat3D()
    {
      if (ByteCodeHelper.isAlreadyInited("arc.math.geom.Mat3D"))
        return;
      Mat3D.tmp = new float[16];
      Mat3D.quat = new Quat();
      Mat3D.quat2 = new Quat();
      Mat3D.l_vez = new Vec3();
      Mat3D.l_vex = new Vec3();
      Mat3D.l_vey = new Vec3();
      Mat3D.tmpVec = new Vec3();
      Mat3D.tmpMat = new Mat3D();
      Mat3D.right = new Vec3();
      Mat3D.tmpForward = new Vec3();
      Mat3D.tmpUp = new Vec3();
    }

    [Modifiers]
    public float[] val
    {
      [HideFromJava] get => this.__\u003C\u003Eval;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Eval = value;
    }
  }
}
