// Decompiled with JetBrains decompiler
// Type: arc.math.geom.Vec3
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.util;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.math.geom
{
  [Signature("Ljava/lang/Object;Larc/math/geom/Vector<Larc/math/geom/Vec3;>;")]
  public class Vec3 : Object, Vector
  {
    internal static Vec3 __\u003C\u003EX;
    internal static Vec3 __\u003C\u003EY;
    internal static Vec3 __\u003C\u003EZ;
    internal static Vec3 __\u003C\u003EZero;
    [Modifiers]
    private static Mat tmpMat;
    public float x;
    public float y;
    public float z;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 166, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Vec3()
    {
    }

    [LineNumberTable(new byte[] {161, 41, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec3 mul(Mat matrix)
    {
      float[] val = matrix.val;
      return this.set(this.x * val[0] + this.y * val[3] + this.z * val[6], this.x * val[1] + this.y * val[4] + this.z * val[7], this.x * val[2] + this.y * val[5] + this.z * val[8]);
    }

    [LineNumberTable(205)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec3 add(float x, float y, float z) => this.set(this.x + x, this.y + y, this.z + z);

    [LineNumberTable(182)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec3 add(Vec3 vector) => this.add(vector.x, vector.y, vector.z);

    [LineNumberTable(244)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec3 scl(float scalar) => this.set(this.x * scalar, this.y * scalar, this.z * scalar);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec3 set(float x, float y, float z)
    {
      this.x = x;
      this.y = y;
      this.z = z;
      return this;
    }

    [LineNumberTable(new byte[] {160, 185, 111, 111, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float dst(Vec3 vector)
    {
      float num1 = vector.x - this.x;
      float num2 = vector.y - this.y;
      float num3 = vector.z - this.z;
      return (float) Math.sqrt((double) (num1 * num1 + num2 * num2 + num3 * num3));
    }

    [LineNumberTable(122)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec3 set(Vec3 vector) => this.set(vector.x, vector.y, vector.z);

    [LineNumberTable(219)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec3 sub(Vec3 a_vec) => this.sub(a_vec.x, a_vec.y, a_vec.z);

    [LineNumberTable(new byte[] {160, 227, 104, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec3 nor()
    {
      float num = this.len2();
      return (double) num == 0.0 || (double) num == 1.0 ? this : this.scl(1f / (float) Math.sqrt((double) num));
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec3 setZero()
    {
      this.x = 0.0f;
      this.y = 0.0f;
      this.z = 0.0f;
      return this;
    }

    [LineNumberTable(new byte[] {161, 64, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec3 rotate(Vec3 axis, float degrees)
    {
      Vec3.tmpMat.setToRotation(axis, degrees);
      return this.mul(Vec3.tmpMat);
    }

    [LineNumberTable(new byte[] {160, 201, 111, 111, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float dst2(Vec3 point)
    {
      float num1 = point.x - this.x;
      float num2 = point.y - this.y;
      float num3 = point.z - this.z;
      return num1 * num1 + num2 * num2 + num3 * num3;
    }

    [LineNumberTable(new byte[] {159, 175, 104, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Vec3(float x, float y, float z)
    {
      Vec3 vec3 = this;
      this.set(x, y, z);
    }

    [LineNumberTable(135)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec3 set(float[] values, int offset) => this.set(values[offset], values[offset + 1], values[offset + 2]);

    [LineNumberTable(594)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec3 setLength(float len) => this.setLength2(len * len);

    [LineNumberTable(391)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec3 crs(float x, float y, float z) => this.set(this.y * z - this.z * y, this.z * x - this.x * z, this.x * y - this.y * x);

    [LineNumberTable(new byte[] {161, 140, 127, 1, 127, 1, 127, 1})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec3 lerp(Vec3 target, float alpha)
    {
      this.x += alpha * (target.x - this.x);
      this.y += alpha * (target.y - this.y);
      this.z += alpha * (target.z - this.z);
      return this;
    }

    [LineNumberTable(new byte[] {160, 193, 107, 107, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float dst(float x, float y, float z)
    {
      float num1 = x - this.x;
      float num2 = y - this.y;
      float num3 = z - this.z;
      return (float) Math.sqrt((double) (num1 * num1 + num2 * num2 + num3 * num3));
    }

    [LineNumberTable(190)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec3 add(Vec3 vector, float scale) => this.add(vector.x * scale, vector.y * scale, vector.z * scale);

    [LineNumberTable(348)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float dot(Vec3 vector) => this.x * vector.x + this.y * vector.y + this.z * vector.z;

    [LineNumberTable(177)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec3 cpy() => new Vec3(this);

    [LineNumberTable(360)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float angle(Vec3 vector) => this.angleRad(vector) * 57.29578f;

    [LineNumberTable(281)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float len() => (float) Math.sqrt((double) (this.x * this.x + this.y * this.y + this.z * this.z));

    [LineNumberTable(new byte[] {161, 159, 137, 191, 5, 138, 134, 106, 115, 115, 115, 120, 159, 7})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec3 slerp(Vec3 target, float alpha)
    {
      float num1 = this.dot(target);
      if ((double) num1 > 0.9995 || (double) num1 < -0.9995)
        return this.lerp(target, alpha);
      float num2 = (float) Math.acos((double) num1) * alpha;
      float num3 = (float) Math.sin((double) num2);
      float num4 = target.x - this.x * num1;
      float num5 = target.y - this.y * num1;
      float num6 = target.z - this.z * num1;
      float num7 = num4 * num4 + num5 * num5 + num6 * num6;
      float num8 = num3 * ((double) num7 >= 9.99999974737875E-05 ? 1f / (float) Math.sqrt((double) num7) : 1f);
      return this.scl((float) Math.cos((double) num2)).add(num4 * num8, num5 * num8, num6 * num8).nor();
    }

    [LineNumberTable(230)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec3 sub(float x, float y, float z) => this.set(this.x - x, this.y - y, this.z - z);

    [LineNumberTable(new byte[] {105, 105, 137, 105, 137})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec3 setFromSpherical(float azimuthalAngle, float polarAngle)
    {
      float z = Mathf.cos(polarAngle);
      float num1 = Mathf.sin(polarAngle);
      float num2 = Mathf.cos(azimuthalAngle);
      float num3 = Mathf.sin(azimuthalAngle);
      return this.set(num2 * num1, num3 * num1, z);
    }

    [LineNumberTable(new byte[] {159, 187, 104, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Vec3(Vec3 vector)
    {
      Vec3 vec3 = this;
      this.set(vector);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float len2() => this.x * this.x + this.y * this.y + this.z * this.z;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static float dot(float x1, float y1, float z1, float x2, float y2, float z2) => x1 * x2 + y1 * y2 + z1 * z2;

    [LineNumberTable(new byte[] {160, 239, 104, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float angleRad(Vec3 vector)
    {
      float num1 = this.len();
      float num2 = vector.len();
      return (float) Math.acos((double) Vec3.dot(this.x / num1, this.y / num1, this.z / num1, vector.x / num2, vector.y / num2, vector.z / num2));
    }

    [LineNumberTable(445)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isUnit(float margin) => (double) Math.abs(this.len2() - 1f) < (double) margin;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static float len2(float x, float y, float z) => x * x + y * y + z * z;

    [LineNumberTable(460)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isOnLine(Vec3 other, float epsilon) => (double) Vec3.len2(this.y * other.z - this.z * other.y, this.z * other.x - this.x * other.z, this.x * other.y - this.y * other.x) <= (double) epsilon;

    [LineNumberTable(500)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool hasSameDirection(Vec3 vector) => (double) this.dot(vector) > 0.0;

    [LineNumberTable(465)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isOnLine(Vec3 other) => (double) Vec3.len2(this.y * other.z - this.z * other.y, this.z * other.x - this.x * other.z, this.x * other.y - this.y * other.x) <= 9.99999997475243E-07;

    [LineNumberTable(505)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool hasOppositeDirection(Vec3 vector) => (double) this.dot(vector) < 0.0;

    [LineNumberTable(new byte[] {161, 215, 104, 101, 148})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec3 limit2(float limit2)
    {
      float num = this.len2();
      if ((double) num > (double) limit2)
        this.scl((float) Math.sqrt((double) (limit2 / num)));
      return this;
    }

    [LineNumberTable(new byte[] {161, 229, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec3 setLength2(float len2)
    {
      float num = this.len2();
      return (double) num == 0.0 || (double) num == (double) len2 ? this : this.scl((float) Math.sqrt((double) (len2 / num)));
    }

    [LineNumberTable(new byte[] {162, 11, 101, 122, 122})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool epsilonEquals(Vec3 other, float epsilon) => other != null && (double) Math.abs(other.x - this.x) <= (double) epsilon && (double) Math.abs(other.y - this.y) <= (double) epsilon && (double) Math.abs(other.z - this.z) <= (double) epsilon;

    [LineNumberTable(new byte[] {162, 22, 119, 119})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool epsilonEquals(float x, float y, float z, float epsilon) => (double) Math.abs(x - this.x) <= (double) epsilon && (double) Math.abs(y - this.y) <= (double) epsilon && (double) Math.abs(z - this.z) <= (double) epsilon;

    [LineNumberTable(new byte[] {160, 159, 124, 124, 124})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec3 mulAdd(Vec3 vec, Vec3 mulVec)
    {
      this.x += vec.x * mulVec.x;
      this.y += vec.y * mulVec.y;
      this.z += vec.z * mulVec.z;
      return this;
    }

    [LineNumberTable(new byte[] {160, 151, 120, 120, 120})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec3 mulAdd(Vec3 vec, float scalar)
    {
      this.x += vec.x * scalar;
      this.y += vec.y * scalar;
      this.z += vec.z * scalar;
      return this;
    }

    [LineNumberTable(495)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isPerpendicular(Vec3 vector, float epsilon) => Mathf.zero(this.dot(vector), epsilon);

    [LineNumberTable(490)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isPerpendicular(Vec3 vector) => Mathf.zero(this.dot(vector));

    [LineNumberTable(485)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isCollinearOpposite(Vec3 other) => this.isOnLine(other) && this.hasOppositeDirection(other);

    [LineNumberTable(480)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isCollinearOpposite(Vec3 other, float epsilon) => this.isOnLine(other, epsilon) && this.hasOppositeDirection(other);

    [LineNumberTable(475)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isCollinear(Vec3 other) => this.isOnLine(other) && this.hasSameDirection(other);

    [LineNumberTable(470)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isCollinear(Vec3 other, float epsilon) => this.isOnLine(other, epsilon) && this.hasSameDirection(other);

    [LineNumberTable(new byte[] {116, 103, 135, 105, 152})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec3 setToRandomDirection() => this.setFromSpherical(6.283185f * Mathf.random(), (float) Math.acos((double) (2f * Mathf.random() - 1f)));

    [LineNumberTable(518)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec3 interpolate(Vec3 target, float alpha, Interp interpolator) => this.lerp(target, interpolator.apply(0.0f, 1f, alpha));

    [LineNumberTable(new byte[] {63, 116, 116, 148})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec3 div(Vec3 other)
    {
      this.x /= other.x;
      this.y /= other.y;
      this.z /= other.z;
      return this;
    }

    [LineNumberTable(249)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec3 scl(Vec3 other) => this.set(this.x * other.x, this.y * other.y, this.z * other.z);

    [LineNumberTable(new byte[] {161, 235, 104, 106, 103, 119, 103, 119})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec3 clamp(float min, float max)
    {
      float num1 = this.len2();
      if ((double) num1 == 0.0)
        return this;
      float num2 = max * max;
      if ((double) num1 > (double) num2)
        return this.scl((float) Math.sqrt((double) (num2 / num1)));
      float num3 = min * min;
      return (double) num1 < (double) num3 ? this.scl((float) Math.sqrt((double) (num3 / num1))) : this;
    }

    [LineNumberTable(580)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec3 limit(float limit) => this.limit2(limit * limit);

    [LineNumberTable(new byte[] {159, 180, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Vec3(double x, double y, double z)
      : this((float) x, (float) y, (float) z)
    {
    }

    [LineNumberTable(new byte[] {3, 104, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Vec3(float[] values)
    {
      Vec3 vec3 = this;
      this.set(values[0], values[1], values[2]);
    }

    [LineNumberTable(new byte[] {12, 104, 117})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Vec3(Vec2 vector, float z)
    {
      Vec3 vec3 = this;
      this.set(vector.x, vector.y, z);
    }

    [LineNumberTable(68)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static float len(float x, float y, float z) => (float) Math.sqrt((double) (x * x + y * y + z * z));

    [LineNumberTable(new byte[] {28, 103, 104, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static float dst(float x1, float y1, float z1, float x2, float y2, float z2)
    {
      float num1 = x2 - x1;
      float num2 = y2 - y1;
      float num3 = z2 - z1;
      return (float) Math.sqrt((double) (num1 * num1 + num2 * num2 + num3 * num3));
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static float dst2(float x1, float y1, float z1, float x2, float y2, float z2)
    {
      float num1 = x2 - x1;
      float num2 = y2 - y1;
      float num3 = z2 - z1;
      return num1 * num1 + num2 * num2 + num3 * num3;
    }

    [LineNumberTable(131)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec3 set(float[] values) => this.set(values[0], values[1], values[2]);

    [LineNumberTable(145)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec3 set(Vec2 vector, float z) => this.set(vector.x, vector.y, z);

    [LineNumberTable(186)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec3 cpy(Vec3 dest) => dest.set(this);

    [LineNumberTable(194)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec3 sun(Vec3 vector, float scale) => this.sub(vector.x * scale, vector.y * scale, vector.z * scale);

    [LineNumberTable(214)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec3 add(float values) => this.set(this.x + values, this.y + values, this.z + values);

    [LineNumberTable(239)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec3 sub(float value) => this.set(this.x - value, this.y - value, this.z - value);

    [LineNumberTable(260)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec3 scl(float vx, float vy, float vz) => this.set(this.x * vx, this.y * vy, this.z * vz);

    [LineNumberTable(294)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool idt(Vec3 vector) => (double) this.x == (double) vector.x && (double) this.y == (double) vector.y && (double) this.z == (double) vector.z;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float dst2(float x, float y, float z)
    {
      float num1 = x - this.x;
      float num2 = y - this.y;
      float num3 = z - this.z;
      return num1 * num1 + num2 * num2 + num3 * num3;
    }

    [LineNumberTable(336)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool within(Vec3 v, float dst) => (double) this.dst2(v) < (double) (dst * dst);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float dot(float x, float y, float z) => this.x * x + this.y * y + this.z * z;

    [LineNumberTable(380)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec3 crs(Vec3 vector) => this.set(this.y * vector.z - this.z * vector.y, this.z * vector.x - this.x * vector.z, this.x * vector.y - this.y * vector.x);

    [LineNumberTable(401)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec3 mul4x3(float[] matrix) => this.set(this.x * matrix[0] + this.y * matrix[3] + this.z * matrix[6] + matrix[9], this.x * matrix[1] + this.y * matrix[4] + this.z * matrix[7] + matrix[10], this.x * matrix[2] + this.y * matrix[5] + this.z * matrix[8] + matrix[11]);

    [LineNumberTable(new byte[] {161, 52, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec3 traMul(Mat matrix)
    {
      float[] val = matrix.val;
      return this.set(this.x * val[0] + this.y * val[1] + this.z * val[2], this.x * val[3] + this.y * val[4] + this.z * val[5], this.x * val[6] + this.y * val[7] + this.z * val[8]);
    }

    [LineNumberTable(440)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isUnit() => this.isUnit(1E-09f);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isZero() => (double) this.x == 0.0 && (double) this.y == 0.0 && (double) this.z == 0.0;

    [LineNumberTable(455)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isZero(float margin) => (double) this.len2() < (double) margin;

    [LineNumberTable(554)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toString() => new StringBuilder().append("(").append(this.x).append(",").append(this.y).append(",").append(this.z).append(")").toString();

    [LineNumberTable(new byte[] {161, 193, 106, 108, 159, 18, 111, 113, 121, 124, 193})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec3 fromString(string v)
    {
      int num1 = String.instancehelper_indexOf(v, 44, 1);
      int num2 = String.instancehelper_indexOf(v, 44, num1 + 1);
      if (num1 != -1 && num2 != -1 && String.instancehelper_charAt(v, 0) == '(')
      {
        if (String.instancehelper_charAt(v, String.instancehelper_length(v) - 1) == ')')
        {
          Vec3 vec3;
          try
          {
            vec3 = this.set(Float.parseFloat(String.instancehelper_substring(v, 1, num1)), Float.parseFloat(String.instancehelper_substring(v, num1 + 1, num2)), Float.parseFloat(String.instancehelper_substring(v, num2 + 1, String.instancehelper_length(v) - 1)));
          }
          catch (NumberFormatException ex)
          {
            goto label_5;
          }
          return vec3;
label_5:;
        }
      }
      string message = new StringBuilder().append("Malformed Vec3: ").append(v).toString();
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new ArcRuntimeException(message);
    }

    [LineNumberTable(new byte[] {161, 246, 99, 98, 113, 113, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int hashCode() => 31 * (31 * (31 * 1 + Float.floatToIntBits(this.x)) + Float.floatToIntBits(this.y)) + Float.floatToIntBits(this.z);

    [LineNumberTable(new byte[] {162, 0, 107, 101, 117, 103, 122, 122})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool equals(object obj)
    {
      if (object.ReferenceEquals((object) this, obj))
        return true;
      if (obj == null || !object.ReferenceEquals((object) ((object) this).GetType(), (object) obj.GetType()))
        return false;
      Vec3 vec3 = (Vec3) obj;
      return Float.floatToIntBits(this.x) == Float.floatToIntBits(vec3.x) && Float.floatToIntBits(this.y) == Float.floatToIntBits(vec3.y) && Float.floatToIntBits(this.z) == Float.floatToIntBits(vec3.z);
    }

    [LineNumberTable(659)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool epsilonEquals(Vec3 other) => this.epsilonEquals(other, 1E-06f);

    [LineNumberTable(670)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool epsilonEquals(float x, float y, float z) => this.epsilonEquals(x, y, z, 1E-06f);

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(10)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vector \u003Cbridge\u003EsetZero() => (Vector) this.setZero();

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(10)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vector mulAdd(Vector v1, Vector v2) => (Vector) this.mulAdd((Vec3) v1, (Vec3) v2);

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(10)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vector mulAdd(Vector v, float f) => (Vector) this.mulAdd((Vec3) v, f);

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(10)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool epsilonEquals(Vector v, float f) => this.epsilonEquals((Vec3) v, f);

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(10)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool hasOppositeDirection(Vector v) => this.hasOppositeDirection((Vec3) v);

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(10)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool hasSameDirection(Vector v) => this.hasSameDirection((Vec3) v);

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(10)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isPerpendicular(Vector v, float f) => this.isPerpendicular((Vec3) v, f);

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(10)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isPerpendicular(Vector v) => this.isPerpendicular((Vec3) v);

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(10)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isCollinearOpposite(Vector v) => this.isCollinearOpposite((Vec3) v);

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(10)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isCollinearOpposite(Vector v, float f) => this.isCollinearOpposite((Vec3) v, f);

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(10)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isCollinear(Vector v) => this.isCollinear((Vec3) v);

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(10)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isCollinear(Vector v, float f) => this.isCollinear((Vec3) v, f);

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(10)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isOnLine(Vector v) => this.isOnLine((Vec3) v);

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(10)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isOnLine(Vector v, float f) => this.isOnLine((Vec3) v, f);

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(10)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vector \u003Cbridge\u003EsetToRandomDirection() => (Vector) this.setToRandomDirection();

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(10)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vector interpolate(Vector v, float f, Interp i) => (Vector) this.interpolate((Vec3) v, f, i);

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(10)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vector lerp(Vector v, float f) => (Vector) this.lerp((Vec3) v, f);

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(10)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float dst2(Vector v) => this.dst2((Vec3) v);

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(10)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float dst(Vector v) => this.dst((Vec3) v);

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(10)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vector div(Vector v) => (Vector) this.div((Vec3) v);

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(10)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vector scl(Vector v) => (Vector) this.scl((Vec3) v);

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(10)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vector \u003Cbridge\u003Escl(float f) => (Vector) this.scl(f);

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(10)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float dot(Vector v) => this.dot((Vec3) v);

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(10)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vector add(Vector v) => (Vector) this.add((Vec3) v);

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(10)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vector \u003Cbridge\u003Enor() => (Vector) this.nor();

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(10)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vector sub(Vector v) => (Vector) this.sub((Vec3) v);

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(10)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vector set(Vector v) => (Vector) this.set((Vec3) v);

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(10)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vector \u003Cbridge\u003Eclamp(float f1, float f2) => (Vector) this.clamp(f1, f2);

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(10)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vector \u003Cbridge\u003EsetLength2(float f) => (Vector) this.setLength2(f);

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(10)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vector \u003Cbridge\u003EsetLength(float f) => (Vector) this.setLength(f);

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(10)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vector \u003Cbridge\u003Elimit2(float f) => (Vector) this.limit2(f);

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(10)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vector \u003Cbridge\u003Elimit(float f) => (Vector) this.limit(f);

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(10)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vector \u003Cbridge\u003Ecpy() => (Vector) this.cpy();

    [LineNumberTable(new byte[] {159, 140, 173, 121, 121, 121, 121})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static Vec3()
    {
      if (ByteCodeHelper.isAlreadyInited("arc.math.geom.Vec3"))
        return;
      Vec3.__\u003C\u003EX = new Vec3(1f, 0.0f, 0.0f);
      Vec3.__\u003C\u003EY = new Vec3(0.0f, 1f, 0.0f);
      Vec3.__\u003C\u003EZ = new Vec3(0.0f, 0.0f, 1f);
      Vec3.__\u003C\u003EZero = new Vec3(0.0f, 0.0f, 0.0f);
      Vec3.tmpMat = new Mat();
    }

    [HideFromJava]
    public virtual Vector plus([In] Vector obj0) => Vector.\u003Cdefault\u003Eplus((Vector) this, obj0);

    [HideFromJava]
    public virtual Vector minus([In] Vector obj0) => Vector.\u003Cdefault\u003Eminus((Vector) this, obj0);

    [HideFromJava]
    public virtual Vector unaryMinus() => Vector.\u003Cdefault\u003EunaryMinus((Vector) this);

    [HideFromJava]
    public virtual Vector times([In] Vector obj0) => Vector.\u003Cdefault\u003Etimes((Vector) this, obj0);

    Vector Vector.__\u003Coverridestub\u003Earc\u002Emath\u002Egeom\u002EVector\u003A\u003Acpy() => this.\u003Cbridge\u003Ecpy();

    Vector Vector.__\u003Coverridestub\u003Earc\u002Emath\u002Egeom\u002EVector\u003A\u003Alimit(
      [In] float obj0)
    {
      return this.\u003Cbridge\u003Elimit(obj0);
    }

    Vector Vector.__\u003Coverridestub\u003Earc\u002Emath\u002Egeom\u002EVector\u003A\u003Alimit2(
      [In] float obj0)
    {
      return this.\u003Cbridge\u003Elimit2(obj0);
    }

    Vector Vector.__\u003Coverridestub\u003Earc\u002Emath\u002Egeom\u002EVector\u003A\u003AsetLength(
      [In] float obj0)
    {
      return this.\u003Cbridge\u003EsetLength(obj0);
    }

    Vector Vector.__\u003Coverridestub\u003Earc\u002Emath\u002Egeom\u002EVector\u003A\u003AsetLength2(
      [In] float obj0)
    {
      return this.\u003Cbridge\u003EsetLength2(obj0);
    }

    Vector Vector.__\u003Coverridestub\u003Earc\u002Emath\u002Egeom\u002EVector\u003A\u003Aclamp(
      [In] float obj0,
      [In] float obj1)
    {
      return this.\u003Cbridge\u003Eclamp(obj0, obj1);
    }

    Vector Vector.__\u003Coverridestub\u003Earc\u002Emath\u002Egeom\u002EVector\u003A\u003Anor() => this.\u003Cbridge\u003Enor();

    Vector Vector.__\u003Coverridestub\u003Earc\u002Emath\u002Egeom\u002EVector\u003A\u003Ascl(
      [In] float obj0)
    {
      return this.\u003Cbridge\u003Escl(obj0);
    }

    Vector Vector.__\u003Coverridestub\u003Earc\u002Emath\u002Egeom\u002EVector\u003A\u003AsetToRandomDirection() => this.\u003Cbridge\u003EsetToRandomDirection();

    Vector Vector.__\u003Coverridestub\u003Earc\u002Emath\u002Egeom\u002EVector\u003A\u003AsetZero() => this.\u003Cbridge\u003EsetZero();

    [Modifiers]
    public static Vec3 X
    {
      [HideFromJava] get => Vec3.__\u003C\u003EX;
    }

    [Modifiers]
    public static Vec3 Y
    {
      [HideFromJava] get => Vec3.__\u003C\u003EY;
    }

    [Modifiers]
    public static Vec3 Z
    {
      [HideFromJava] get => Vec3.__\u003C\u003EZ;
    }

    [Modifiers]
    public static Vec3 Zero
    {
      [HideFromJava] get => Vec3.__\u003C\u003EZero;
    }
  }
}
