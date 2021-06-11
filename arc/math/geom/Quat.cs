// Decompiled with JetBrains decompiler
// Type: arc.math.geom.Quat
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System;
using System.Runtime.CompilerServices;

namespace arc.math.geom
{
  public class Quat : Object
  {
    private static Quat tmp1;
    private static Quat tmp2;
    public float x;
    public float y;
    public float z;
    public float w;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(111)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Quat set(Vec3 axis, float angle) => this.setFromAxis(axis.x, axis.y, axis.z, angle);

    [LineNumberTable(438)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Quat setFromAxisRad(Vec3 axis, float radians) => this.setFromAxisRad(axis.x, axis.y, axis.z, radians);

    [LineNumberTable(450)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Quat setFromAxis(float x, float y, float z, float degrees) => this.setFromAxisRad(x, y, z, degrees * ((float) Math.PI / 180f));

    [LineNumberTable(new byte[] {161, 92, 109, 111, 105, 127, 10, 113, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Quat setFromAxisRad(float x, float y, float z, float radians)
    {
      float num1 = Vec3.len(x, y, z);
      if ((double) num1 == 0.0)
        return this.idt();
      float num2 = 1f / num1;
      float num3 = (double) radians >= 0.0 ? radians % 6.283185f : 6.283185f - (float) (-(double) radians % 6.28318548202515);
      float num4 = (float) Math.sin((double) (num3 / 2f));
      float w = (float) Math.cos((double) (num3 / 2f));
      return this.set(num2 * x * num4, num2 * y * num4, num2 * z * num4, w).nor();
    }

    [LineNumberTable(new byte[] {161, 229, 121, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Quat setFromCross(Vec3 v1, Vec3 v2)
    {
      float radians = (float) Math.acos((double) Mathf.clamp(v1.dot(v2), -1f, 1f));
      return this.setFromAxisRad(v1.y * v2.z - v1.z * v2.y, v1.z * v2.x - v1.x * v2.z, v1.x * v2.y - v1.y * v2.x, radians);
    }

    [LineNumberTable(new byte[] {161, 245, 127, 7, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Quat setFromCross(
      float x1,
      float y1,
      float z1,
      float x2,
      float y2,
      float z2)
    {
      float radians = (float) Math.acos((double) Mathf.clamp(Vec3.dot(x1, y1, z1, x2, y2, z2), -1f, 1f));
      return this.setFromAxisRad(y1 * z2 - z1 * y2, z1 * x2 - x1 * z2, x1 * y2 - y1 * x2, radians);
    }

    [LineNumberTable(137)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Quat setEulerAngles(float yaw, float pitch, float roll) => this.setEulerAnglesRad(yaw * ((float) Math.PI / 180f), pitch * ((float) Math.PI / 180f), roll * ((float) Math.PI / 180f));

    [LineNumberTable(new byte[] {99, 106, 106, 106, 106, 107, 107, 107, 108, 108, 104, 104, 104, 136, 114, 114, 114, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Quat setEulerAnglesRad(float yaw, float pitch, float roll)
    {
      float num1 = roll * 0.5f;
      float num2 = (float) Math.sin((double) num1);
      float num3 = (float) Math.cos((double) num1);
      float num4 = pitch * 0.5f;
      float num5 = (float) Math.sin((double) num4);
      float num6 = (float) Math.cos((double) num4);
      float num7 = yaw * 0.5f;
      float num8 = (float) Math.sin((double) num7);
      float num9 = (float) Math.cos((double) num7);
      float num10 = num9 * num5;
      float num11 = num8 * num6;
      float num12 = num9 * num6;
      float num13 = num8 * num5;
      this.x = num10 * num3 + num11 * num2;
      this.y = num11 * num3 - num10 * num2;
      this.z = num12 * num2 - num13 * num3;
      this.w = num12 * num3 + num13 * num2;
      return this;
    }

    [LineNumberTable(new byte[] {162, 2, 127, 32, 174, 106, 195, 148, 107, 211, 122, 179, 203, 122, 122, 122, 186})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Quat slerp(Quat end, float alpha)
    {
      float num1 = this.x * end.x + this.y * end.y + this.z * end.z + this.w * end.w;
      float num2 = (double) num1 >= 0.0 ? num1 : -num1;
      float num3 = 1f - alpha;
      float num4 = alpha;
      if ((double) (1f - num2) > 0.1)
      {
        float num5 = (float) Math.acos((double) num2);
        float num6 = 1f / (float) Math.sin((double) num5);
        num3 = (float) Math.sin((double) ((1f - alpha) * num5)) * num6;
        num4 = (float) Math.sin((double) (alpha * num5)) * num6;
      }
      if ((double) num1 < 0.0)
        num4 = -num4;
      this.x = num3 * this.x + num4 * end.x;
      this.y = num3 * this.y + num4 * end.y;
      this.z = num3 * this.z + num4 * end.z;
      this.w = num3 * this.w + num4 * end.w;
      return this;
    }

    [LineNumberTable(new byte[] {162, 79, 104, 173, 178, 102, 147, 139, 191, 1, 119, 111, 111, 175, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Quat exp(float alpha)
    {
      float num1 = this.len();
      float num2 = (float) Math.pow((double) num1, (double) alpha);
      float num3 = (float) Math.acos((double) (this.w / num1));
      float num4 = (double) Math.abs(num3) >= 0.001 ? (float) ((double) num2 * Math.sin((double) (alpha * num3)) / ((double) num1 * Math.sin((double) num3))) : num2 * alpha / num1;
      this.w = num2 * (float) Math.cos((double) (alpha * num3));
      this.x *= num4;
      this.y *= num4;
      this.z *= num4;
      this.nor();
      return this;
    }

    [LineNumberTable(101)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Quat set(Quat quat) => this.set(quat.x, quat.y, quat.z, quat.w);

    [LineNumberTable(new byte[] {160, 171, 127, 32, 127, 32, 127, 32, 127, 32, 103, 103, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Quat mul(Quat other)
    {
      float num1 = this.w * other.x + this.x * other.w + this.y * other.z - this.z * other.y;
      float num2 = this.w * other.y + this.y * other.w + this.z * other.x - this.x * other.z;
      float num3 = this.w * other.z + this.z * other.w + this.x * other.y - this.y * other.x;
      float num4 = this.w * other.w - this.x * other.x - this.y * other.y - this.z * other.z;
      this.x = num1;
      this.y = num2;
      this.z = num3;
      this.w = num4;
      return this;
    }

    [LineNumberTable(new byte[] {160, 126, 104, 117, 106, 111, 111, 111, 143})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Quat nor()
    {
      float a = this.len2();
      if ((double) a != 0.0 && !Mathf.equal(a, 1f))
      {
        float num = (float) Math.sqrt((double) a);
        this.w /= num;
        this.x /= num;
        this.y /= num;
        this.z /= num;
      }
      return this;
    }

    [LineNumberTable(473)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Quat setFromMatrix(bool normalizeAxes, Mat3D matrix) => this.setFromAxes(normalizeAxes, matrix.__\u003C\u003Eval[0], matrix.__\u003C\u003Eval[4], matrix.__\u003C\u003Eval[8], matrix.__\u003C\u003Eval[1], matrix.__\u003C\u003Eval[5], matrix.__\u003C\u003Eval[9], matrix.__\u003C\u003Eval[2], matrix.__\u003C\u003Eval[6], matrix.__\u003C\u003Eval[10]);

    [LineNumberTable(480)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Quat setFromMatrix(Mat3D matrix) => this.setFromMatrix(false, matrix);

    [LineNumberTable(new byte[] {161, 2, 111, 111, 111, 111, 112, 112, 112, 112, 144, 119, 111, 111, 105, 111, 118, 112, 105, 111, 111, 119, 105, 104, 104, 105, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void toMatrix(float[] matrix)
    {
      float num1 = this.x * this.x;
      float num2 = this.x * this.y;
      float num3 = this.x * this.z;
      float num4 = this.x * this.w;
      float num5 = this.y * this.y;
      float num6 = this.y * this.z;
      float num7 = this.y * this.w;
      float num8 = this.z * this.z;
      float num9 = this.z * this.w;
      matrix[0] = 1f - 2f * (num5 + num8);
      matrix[4] = 2f * (num2 - num9);
      matrix[8] = 2f * (num3 + num7);
      matrix[12] = 0.0f;
      matrix[1] = 2f * (num2 + num9);
      matrix[5] = 1f - 2f * (num1 + num8);
      matrix[9] = 2f * (num6 - num4);
      matrix[13] = 0.0f;
      matrix[2] = 2f * (num3 - num7);
      matrix[6] = 2f * (num6 + num4);
      matrix[10] = 1f - 2f * (num1 + num5);
      matrix[14] = 0.0f;
      matrix[3] = 0.0f;
      matrix[7] = 0.0f;
      matrix[11] = 0.0f;
      matrix[15] = 1f;
    }

    [LineNumberTable(new byte[] {159, 174, 104, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Quat()
    {
      Quat quat = this;
      this.idt();
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Quat set(float x, float y, float z, float w)
    {
      this.x = x;
      this.y = y;
      this.z = z;
      this.w = w;
      return this;
    }

    [LineNumberTable(405)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Quat idt() => this.set(0.0f, 0.0f, 0.0f, 1f);

    [LineNumberTable(new byte[] {159, 182, 104, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Quat(Quat quat)
    {
      Quat quat1 = this;
      this.set(quat);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getGimbalPole()
    {
      float num = this.y * this.x + this.z * this.w;
      if ((double) num > 0.499000012874603)
        return 1;
      return (double) num < -0.499000012874603 ? -1 : 0;
    }

    [LineNumberTable(new byte[] {160, 70, 103, 127, 61, 61})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getRollRad()
    {
      int gimbalPole = this.getGimbalPole();
      return gimbalPole == 0 ? Mathf.atan2(1f - 2f * (this.x * this.x + this.z * this.z), 2f * (this.w * this.z + this.y * this.x)) : (float) gimbalPole * 2f * Mathf.atan2(this.w, this.y);
    }

    [LineNumberTable(new byte[] {160, 88, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getPitchRad()
    {
      int gimbalPole = this.getGimbalPole();
      return gimbalPole == 0 ? (float) Math.asin((double) Mathf.clamp(2f * (this.w * this.x - this.z * this.y), -1f, 1f)) : (float) gimbalPole * 3.141593f * 0.5f;
    }

    [LineNumberTable(219)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getYawRad() => this.getGimbalPole() == 0 ? Mathf.atan2(1f - 2f * (this.y * this.y + this.x * this.x), 2f * (this.y * this.w + this.x * this.z)) : 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float len2() => this.x * this.x + this.y * this.y + this.z * this.z + this.w * this.w;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Quat conjugate()
    {
      this.x = -this.x;
      this.y = -this.y;
      this.z = -this.z;
      return this;
    }

    [LineNumberTable(new byte[] {160, 208, 127, 32, 127, 32, 127, 32, 127, 32, 103, 103, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Quat mulLeft(Quat other)
    {
      float num1 = other.w * this.x + other.x * this.w + other.y * this.z - other.z * this.y;
      float num2 = other.w * this.y + other.y * this.w + other.z * this.x - other.x * this.z;
      float num3 = other.w * this.z + other.z * this.w + other.x * this.y - other.y * this.x;
      float num4 = other.w * this.w - other.x * this.x - other.y * this.y - other.z * this.z;
      this.x = num1;
      this.y = num2;
      this.z = num3;
      this.w = num4;
      return this;
    }

    [LineNumberTable(new byte[] {159, 7, 66, 102, 117, 119, 119, 103, 103, 104, 104, 104, 104, 104, 104, 200, 173, 104, 113, 110, 105, 113, 113, 112, 121, 126, 110, 105, 112, 113, 113, 112, 126, 110, 105, 112, 113, 113, 98, 126, 110, 105, 113, 113, 176})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Quat setFromAxes(
      bool normalizeAxes,
      float xx,
      float xy,
      float xz,
      float yx,
      float yy,
      float yz,
      float zx,
      float zy,
      float zz)
    {
      if (normalizeAxes)
      {
        float num1 = 1f / Vec3.len(xx, xy, xz);
        float num2 = 1f / Vec3.len(yx, yy, yz);
        float num3 = 1f / Vec3.len(zx, zy, zz);
        xx *= num1;
        xy *= num1;
        xz *= num1;
        yx *= num2;
        yy *= num2;
        yz *= num2;
        zx *= num3;
        zy *= num3;
        zz *= num3;
      }
      float num4 = xx + yy + zz;
      if ((double) num4 >= 0.0)
      {
        float num1 = (float) Math.sqrt((double) (num4 + 1f));
        this.w = 0.5f * num1;
        float num2 = 0.5f / num1;
        this.x = (zy - yz) * num2;
        this.y = (xz - zx) * num2;
        this.z = (yx - xy) * num2;
      }
      else if ((double) xx > (double) yy && (double) xx > (double) zz)
      {
        float num1 = (float) Math.sqrt(1.0 + (double) xx - (double) yy - (double) zz);
        this.x = num1 * 0.5f;
        float num2 = 0.5f / num1;
        this.y = (yx + xy) * num2;
        this.z = (xz + zx) * num2;
        this.w = (zy - yz) * num2;
      }
      else if ((double) yy > (double) zz)
      {
        float num1 = (float) Math.sqrt(1.0 + (double) yy - (double) xx - (double) zz);
        this.y = num1 * 0.5f;
        float num2 = 0.5f / num1;
        this.x = (yx + xy) * num2;
        this.z = (zy + yz) * num2;
        this.w = (xz - zx) * num2;
      }
      else
      {
        float num1 = (float) Math.sqrt(1.0 + (double) zz - (double) xx - (double) yy);
        this.z = num1 * 0.5f;
        float num2 = 0.5f / num1;
        this.x = (xz + zx) * num2;
        this.y = (zy + yz) * num2;
        this.w = (yx - xy) * num2;
      }
      return this;
    }

    [LineNumberTable(485)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Quat setFromMatrix(bool normalizeAxes, Mat matrix) => this.setFromAxes(normalizeAxes, matrix.val[0], matrix.val[3], matrix.val[6], matrix.val[1], matrix.val[4], matrix.val[7], matrix.val[2], matrix.val[5], matrix.val[8]);

    [LineNumberTable(121)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float len() => (float) Math.sqrt((double) (this.x * this.x + this.y * this.y + this.z * this.z + this.w * this.w));

    [LineNumberTable(new byte[] {162, 195, 109, 103, 122, 126, 140, 108, 108, 142, 113, 113, 177})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getAxisAngleRad(Vec3 axis)
    {
      if ((double) this.w > 1.0)
        this.nor();
      float num1 = (float) (2.0 * Math.acos((double) this.w));
      double num2 = Math.sqrt((double) (1f - this.w * this.w));
      if (num2 < 9.99999997475243E-07)
      {
        axis.x = this.x;
        axis.y = this.y;
        axis.z = this.z;
      }
      else
      {
        axis.x = this.x / (float) num2;
        axis.y = this.y / (float) num2;
        axis.z = this.z / (float) num2;
      }
      return num1;
    }

    [LineNumberTable(846)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getAngleRad() => (float) (2.0 * Math.acos((double) this.w <= 1.0 ? (double) this.w : (double) (this.w / this.len())));

    [LineNumberTable(new byte[] {162, 161, 112, 112, 112, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Quat mul(float scalar)
    {
      this.x *= scalar;
      this.y *= scalar;
      this.z *= scalar;
      this.w *= scalar;
      return this;
    }

    [LineNumberTable(new byte[] {162, 246, 127, 0, 127, 3, 117, 117})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void getSwingTwist(
      float axisX,
      float axisY,
      float axisZ,
      Quat swing,
      Quat twist)
    {
      float num = Vec3.dot(this.x, this.y, this.z, axisX, axisY, axisZ);
      twist.set(axisX * num, axisY * num, axisZ * num, this.w).nor();
      if ((double) num < 0.0)
        twist.mul(-1f);
      swing.set(twist).conjugate().mulLeft(this);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static float len2(float x, float y, float z, float w) => x * x + y * y + z * z + w * w;

    [LineNumberTable(new byte[] {163, 18, 127, 0, 124, 120, 63, 14})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getAngleAroundRad(float axisX, float axisY, float axisZ)
    {
      float num1 = Vec3.dot(this.x, this.y, this.z, axisX, axisY, axisZ);
      float num2 = Quat.len2(axisX * num1, axisY * num1, axisZ * num1, this.w);
      return Mathf.zero(num2) ? 0.0f : (float) (2.0 * Math.acos((double) Mathf.clamp((float) (((double) num1 >= 0.0 ? (double) this.w : -(double) this.w) / Math.sqrt((double) num2)), -1f, 1f)));
    }

    [LineNumberTable(923)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getAngleAround(float axisX, float axisY, float axisZ) => this.getAngleAroundRad(axisX, axisY, axisZ) * 57.29578f;

    [LineNumberTable(new byte[] {159, 170, 104, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Quat(float x, float y, float z, float w)
    {
      Quat quat = this;
      this.set(x, y, z, w);
    }

    [LineNumberTable(new byte[] {159, 191, 104, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Quat(Vec3 axis, float angle)
    {
      Quat quat = this;
      this.set(axis, angle);
    }

    [LineNumberTable(55)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static float len(float x, float y, float z, float w) => (float) Math.sqrt((double) (x * x + y * y + z * z + w * w));

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static float dot(
      float x1,
      float y1,
      float z1,
      float w1,
      float x2,
      float y2,
      float z2,
      float w2)
    {
      return x1 * x2 + y1 * y2 + z1 * z2 + w1 * w2;
    }

    [LineNumberTable(116)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Quat cpy() => new Quat(this);

    [LineNumberTable(126)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toString() => new StringBuilder().append("[").append(this.x).append("|").append(this.y).append("|").append(this.z).append("|").append(this.w).append("]").toString();

    [LineNumberTable(194)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getRoll() => this.getRollRad() * 57.29578f;

    [LineNumberTable(211)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getPitch() => this.getPitchRad() * 57.29578f;

    [LineNumberTable(227)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getYaw() => this.getYawRad() * 57.29578f;

    [LineNumberTable(new byte[] {160, 155, 108, 107, 159, 19, 112, 112, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec3 transform(Vec3 v)
    {
      Quat.tmp2.set(this);
      Quat.tmp2.conjugate();
      Quat.tmp2.mulLeft(Quat.tmp1.set(v.x, v.y, v.z, 0.0f)).mulLeft(this);
      v.x = Quat.tmp2.x;
      v.y = Quat.tmp2.y;
      v.z = Quat.tmp2.z;
      return v;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Quat mul(float x, float y, float z, float w)
    {
      float num1 = this.w * x + this.x * w + this.y * z - this.z * y;
      float num2 = this.w * y + this.y * w + this.z * x - this.x * z;
      float num3 = this.w * z + this.z * w + this.x * y - this.y * x;
      float num4 = this.w * w - this.x * x - this.y * y - this.z * z;
      this.x = num1;
      this.y = num2;
      this.z = num3;
      this.w = num4;
      return this;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Quat mulLeft(float x, float y, float z, float w)
    {
      float num1 = w * this.x + x * this.w + y * this.z - z * this.y;
      float num2 = w * this.y + y * this.w + z * this.x - x * this.z;
      float num3 = w * this.z + z * this.w + x * this.y - y * this.x;
      float num4 = w * this.w - x * this.x - y * this.y - z * this.z;
      this.x = num1;
      this.y = num2;
      this.z = num3;
      this.w = num4;
      return this;
    }

    [LineNumberTable(new byte[] {160, 241, 116, 116, 116, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Quat add(Quat quat)
    {
      this.x += quat.x;
      this.y += quat.y;
      this.z += quat.z;
      this.w += quat.w;
      return this;
    }

    [LineNumberTable(new byte[] {160, 250, 112, 112, 112, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Quat add(float qx, float qy, float qz, float qw)
    {
      this.x += qx;
      this.y += qy;
      this.z += qz;
      this.w += qw;
      return this;
    }

    [LineNumberTable(410)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isIdentity() => Mathf.zero(this.x) && Mathf.zero(this.y) && (Mathf.zero(this.z) && Mathf.equal(this.w, 1f));

    [LineNumberTable(new byte[] {161, 47, 127, 27, 43})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isIdentity(float tolerance) => Mathf.zero(this.x, tolerance) && Mathf.zero(this.y, tolerance) && (Mathf.zero(this.z, tolerance) && Mathf.equal(this.w, 1f, tolerance));

    [LineNumberTable(428)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Quat setFromAxis(Vec3 axis, float degrees) => this.setFromAxis(axis.x, axis.y, axis.z, degrees);

    [LineNumberTable(492)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Quat setFromMatrix(Mat matrix) => this.setFromMatrix(false, matrix);

    [LineNumberTable(515)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Quat setFromAxes(
      float xx,
      float xy,
      float xz,
      float yx,
      float yy,
      float yz,
      float zx,
      float zy,
      float zz)
    {
      return this.setFromAxes(false, xx, xy, xz, yx, yy, yz, zx, zy, zz);
    }

    [LineNumberTable(new byte[] {162, 44, 107, 112, 103, 58, 134, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Quat slerp(Quat[] q)
    {
      float alpha = 1f / (float) q.Length;
      this.set(q[0]).exp(alpha);
      for (int index = 1; index < q.Length; ++index)
        this.mul(Quat.tmp1.set(q[index]).exp(alpha));
      this.nor();
      return this;
    }

    [LineNumberTable(new byte[] {162, 63, 114, 103, 60, 134, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Quat slerp(Quat[] q, float[] w)
    {
      this.set(q[0]).exp(w[0]);
      for (int index = 1; index < q.Length; ++index)
        this.mul(Quat.tmp1.set(q[index]).exp(w[index]));
      this.nor();
      return this;
    }

    [LineNumberTable(new byte[] {162, 107, 99, 98, 115, 115, 115, 115})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int hashCode()
    {
      FloatConverter floatConverter;
      return 31 * (31 * (31 * (31 * 1 + FloatConverter.ToInt(this.w, ref floatConverter)) + FloatConverter.ToInt(this.x, ref floatConverter)) + FloatConverter.ToInt(this.y, ref floatConverter)) + FloatConverter.ToInt(this.z, ref floatConverter);
    }

    [LineNumberTable(new byte[] {162, 118, 105, 130, 99, 130, 104, 130, 103, 127, 3, 124, 124, 250, 61})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool equals(object obj)
    {
      if (object.ReferenceEquals((object) this, obj))
        return true;
      if (obj == null || !(obj is Quat))
        return false;
      Quat quat = (Quat) obj;
      FloatConverter floatConverter;
      return FloatConverter.ToInt(this.w, ref floatConverter) == FloatConverter.ToInt(quat.w, ref floatConverter) && FloatConverter.ToInt(this.x, ref floatConverter) == FloatConverter.ToInt(quat.x, ref floatConverter) && (FloatConverter.ToInt(this.y, ref floatConverter) == FloatConverter.ToInt(quat.y, ref floatConverter) && FloatConverter.ToInt(this.z, ref floatConverter) == FloatConverter.ToInt(quat.z, ref floatConverter));
    }

    [LineNumberTable(766)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float dot(Quat other) => this.x * other.x + this.y * other.y + this.z * other.z + this.w * other.w;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float dot(float x, float y, float z, float w) => this.x * x + this.y * y + this.z * z + this.w * w;

    [LineNumberTable(806)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getAxisAngle(Vec3 axis) => this.getAxisAngleRad(axis) * 57.29578f;

    [LineNumberTable(855)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getAngle() => this.getAngleRad() * 57.29578f;

    [LineNumberTable(new byte[] {163, 7, 122})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void getSwingTwist(Vec3 axis, Quat swing, Quat twist) => this.getSwingTwist(axis.x, axis.y, axis.z, swing, twist);

    [LineNumberTable(912)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getAngleAroundRad(Vec3 axis) => this.getAngleAroundRad(axis.x, axis.y, axis.z);

    [LineNumberTable(932)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getAngleAround(Vec3 axis) => this.getAngleAround(axis.x, axis.y, axis.z);

    [LineNumberTable(new byte[] {159, 139, 109, 126})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static Quat()
    {
      if (ByteCodeHelper.isAlreadyInited("arc.math.geom.Quat"))
        return;
      Quat.tmp1 = new Quat(0.0f, 0.0f, 0.0f, 0.0f);
      Quat.tmp2 = new Quat(0.0f, 0.0f, 0.0f, 0.0f);
    }
  }
}
