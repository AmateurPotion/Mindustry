// Decompiled with JetBrains decompiler
// Type: arc.math.geom.Vec2
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.util;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.math.geom
{
  [Signature("Ljava/lang/Object;Larc/math/geom/Vector<Larc/math/geom/Vec2;>;Larc/math/geom/Position;")]
  [Implements(new string[] {"arc.math.geom.Vector", "arc.math.geom.Position"})]
  public class Vec2 : Object, Vector, Position
  {
    internal static Vec2 __\u003C\u003EX;
    internal static Vec2 __\u003C\u003EY;
    internal static Vec2 __\u003C\u003EZERO;
    public float x;
    public float y;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 169, 104, 104, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Vec2(float x, float y)
    {
      Vec2 vec2 = this;
      this.x = x;
      this.y = y;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec2 set(float x, float y)
    {
      this.x = x;
      this.y = y;
      return this;
    }

    [LineNumberTable(new byte[] {159, 161, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Vec2()
    {
    }

    [LineNumberTable(new byte[] {161, 29, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec2 rnd(float length)
    {
      this.setToRandomDirection().scl(length);
      return this;
    }

    [LineNumberTable(456)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec2 rotateAround(Vec2 reference, float degrees) => this.sub(reference).rotate(degrees).add(reference);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec2 setZero()
    {
      this.x = 0.0f;
      this.y = 0.0f;
      return this;
    }

    [LineNumberTable(new byte[] {121, 112, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec2 add(float x, float y)
    {
      this.x += x;
      this.y += y;
      return this;
    }

    [LineNumberTable(new byte[] {160, 73, 112, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec2 scl(float scalar)
    {
      this.x *= scalar;
      this.y *= scalar;
      return this;
    }

    [LineNumberTable(new byte[] {37, 109, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec2 set(Position v)
    {
      this.x = v.getX();
      this.y = v.getY();
      return this;
    }

    [LineNumberTable(111)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec2 sub(Position v) => this.sub(v.getX(), v.getY());

    [LineNumberTable(265)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec2 limit(float limit) => this.limit2(limit * limit);

    [LineNumberTable(71)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float len() => (float) Math.sqrt((double) (this.x * this.x + this.y * this.y));

    [LineNumberTable(290)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec2 setLength(float len) => this.setLength2(len * len);

    [LineNumberTable(66)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec2 cpy() => new Vec2(this);

    [LineNumberTable(new byte[] {55, 108, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec2 set(Vec3 other)
    {
      this.x = other.x;
      this.y = other.y;
      return this;
    }

    [LineNumberTable(134)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec2 sub(Vec3 v) => this.sub(v.x, v.y);

    [LineNumberTable(41)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec2 trns(float angle, float amount) => this.set(amount, 0.0f).rotate(angle);

    [LineNumberTable(447)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec2 rotate(float degrees) => this.rotateRad(degrees * ((float) Math.PI / 180f));

    [LineNumberTable(new byte[] {161, 14, 122, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float angle()
    {
      float num = Mathf.atan2(this.x, this.y) * 57.29578f;
      if ((double) num < 0.0)
        num += 360f;
      return num;
    }

    [LineNumberTable(424)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec2 setAngle(float degrees) => this.setAngleRad(degrees * ((float) Math.PI / 180f));

    [LineNumberTable(new byte[] {99, 116, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec2 add(Vec2 v)
    {
      this.x += v.x;
      this.y += v.y;
      return this;
    }

    [LineNumberTable(641)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isNaN() => Float.isNaN(this.x) || Float.isNaN(this.y);

    [LineNumberTable(645)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isInfinite() => Float.isInfinite(this.x) || Float.isInfinite(this.y);

    [LineNumberTable(new byte[] {78, 112, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec2 sub(float x, float y)
    {
      this.x -= x;
      this.y -= y;
      return this;
    }

    [LineNumberTable(577)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec2 interpolate(Vec2 target, float alpha, Interp interpolation) => this.lerp(target, interpolation.apply(alpha));

    [LineNumberTable(new byte[] {89, 104, 104, 111, 143})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec2 nor()
    {
      float num = this.len();
      if ((double) num != 0.0)
      {
        this.x /= num;
        this.y /= num;
      }
      return this;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec2 rotate90(int dir)
    {
      float x = this.x;
      if (dir >= 0)
      {
        this.x = -this.y;
        this.y = x;
      }
      else
      {
        this.x = this.y;
        this.y = -x;
      }
      return this;
    }

    [LineNumberTable(45)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec2 trns(float angle, float x, float y) => this.set(x, y).rotate(angle);

    [LineNumberTable(155)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec2 add(Position pos) => this.add(pos.getX(), pos.getY());

    [LineNumberTable(new byte[] {31, 108, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec2 set(Vec2 v)
    {
      this.x = v.x;
      this.y = v.y;
      return this;
    }

    [LineNumberTable(new byte[] {66, 116, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec2 sub(Vec2 v)
    {
      this.x -= v.x;
      this.y -= v.y;
      return this;
    }

    [LineNumberTable(193)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec2 inv() => this.scl(-1f);

    [HideFromJava]
    public virtual float angleTo([In] Position obj0) => Position.\u003Cdefault\u003EangleTo((Position) this, obj0);

    [LineNumberTable(new byte[] {161, 184, 106, 124, 124})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec2 lerp(Position target, float alpha)
    {
      float num = 1f - alpha;
      this.x = this.x * num + target.getX() * alpha;
      this.y = this.y * num + target.getY() * alpha;
      return this;
    }

    [LineNumberTable(new byte[] {161, 212, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec2 setToRandomDirection()
    {
      float radians = Mathf.random(0.0f, 6.283185f);
      return this.set(Mathf.cos(radians), Mathf.sin(radians));
    }

    [LineNumberTable(new byte[] {160, 126, 107, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float dst(float x, float y)
    {
      float num1 = x - this.x;
      float num2 = y - this.y;
      return (float) Math.sqrt((double) (num1 * num1 + num2 * num2));
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getX() => this.x;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getY() => this.y;

    [LineNumberTable(new byte[] {161, 199, 106, 123, 123})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec2 lerp(Vec2 target, float alpha)
    {
      float num = 1f - alpha;
      this.x = this.x * num + target.x * alpha;
      this.y = this.y * num + target.y * alpha;
      return this;
    }

    [LineNumberTable(new byte[] {161, 176, 113, 106, 124, 124})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec2 lerpDelta(Position target, float alpha)
    {
      alpha = Mathf.clamp(alpha * Time.delta);
      float num = 1f - alpha;
      this.x = this.x * num + target.getX() * alpha;
      this.y = this.y * num + target.getY() * alpha;
      return this;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isZero() => (double) this.x == 0.0 && (double) this.y == 0.0;

    [LineNumberTable(665)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isZero(float margin) => (double) this.len2() < (double) margin;

    [LineNumberTable(512)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec2 approachDelta(Vec2 target, float alpha) => this.approach(target, Time.delta * alpha);

    [LineNumberTable(178)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float dot(Vec2 v) => this.x * v.x + this.y * v.y;

    [LineNumberTable(49)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec2 trnsExact(float angle, float amount) => this.set(amount, 0.0f).rotateRadExact(angle * ((float) Math.PI / 180f));

    [LineNumberTable(439)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec2 rotateTo(float angle, float speed) => this.setAngle(Angles.moveToward(this.angle(), angle, speed));

    [HideFromJava]
    public virtual float dst([In] Position obj0) => Position.\u003Cdefault\u003Edst((Position) this, obj0);

    [LineNumberTable(new byte[] {159, 178, 104, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Vec2(Vec2 v)
    {
      Vec2 vec2 = this;
      this.set(v);
    }

    [LineNumberTable(305)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toString() => new StringBuilder().append("(").append(this.x).append(",").append(this.y).append(")").toString();

    [LineNumberTable(new byte[] {160, 202, 106, 127, 2, 111, 120, 223, 2, 2, 161})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec2 tryFromString(string v)
    {
      Vec2 vec2;
      try
      {
        int num = String.instancehelper_indexOf(v, 44, 1);
        if (num != -1)
        {
          if (String.instancehelper_charAt(v, 0) == '(')
          {
            if (String.instancehelper_charAt(v, String.instancehelper_length(v) - 1) == ')')
              vec2 = this.set(Float.parseFloat(String.instancehelper_substring(v, 1, num)), Float.parseFloat(String.instancehelper_substring(v, num + 1, String.instancehelper_length(v) - 1)));
            else
              goto label_7;
          }
          else
            goto label_7;
        }
        else
          goto label_7;
      }
      catch (Exception ex)
      {
        ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 2);
        goto label_6;
      }
      return vec2;
label_6:
label_7:
      return this.setZero();
    }

    [LineNumberTable(new byte[] {160, 195, 119, 118})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec2 clamp(float minx, float miny, float maxy, float maxx)
    {
      this.x = Mathf.clamp(this.x, minx, maxx);
      this.y = Mathf.clamp(this.y, miny, maxy);
      return this;
    }

    [LineNumberTable(new byte[] {161, 146, 126, 103, 137, 100, 108, 102, 134, 137})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec2 approach(Vec2 target, float alpha)
    {
      float x = this.x - target.x;
      float y = this.y - target.y;
      float num1 = alpha * alpha;
      float num2 = Mathf.len2(x, y);
      if ((double) num2 <= (double) num1)
        return this.set(target);
      float num3 = Mathf.sqrt(num1 / num2);
      return this.sub(x * num3, y * num3);
    }

    [HideFromJava]
    public virtual bool within([In] Position obj0, [In] float obj1) => Position.\u003Cdefault\u003Ewithin((Position) this, obj0, obj1);

    [LineNumberTable(new byte[] {160, 239, 127, 14, 127, 14, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec2 mul(Mat mat)
    {
      float num1 = this.x * mat.val[0] + this.y * mat.val[3] + mat.val[6];
      float num2 = this.x * mat.val[1] + this.y * mat.val[4] + mat.val[7];
      this.x = num1;
      this.y = num2;
      return this;
    }

    [LineNumberTable(new byte[] {160, 115, 111, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float dst(Vec2 v)
    {
      float num1 = v.x - this.x;
      float num2 = v.y - this.y;
      return (float) Math.sqrt((double) (num1 * num1 + num2 * num2));
    }

    [LineNumberTable(new byte[] {160, 133, 111, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float dst2(Vec2 v)
    {
      float num1 = v.x - this.x;
      float num2 = v.y - this.y;
      return num1 * num1 + num2 * num2;
    }

    [LineNumberTable(new byte[] {161, 107, 107, 139, 117, 149, 103, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec2 rotateRadExact(float radians)
    {
      float num1 = (float) Math.cos((double) radians);
      float num2 = (float) Math.sin((double) radians);
      float num3 = this.x * num1 - this.y * num2;
      float num4 = this.x * num2 + this.y * num1;
      this.x = num3;
      this.y = num4;
      return this;
    }

    [LineNumberTable(new byte[] {160, 156, 104, 101, 148})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec2 limit2(float limit2)
    {
      float num = this.len2();
      return (double) num > (double) limit2 ? this.scl((float) Math.sqrt((double) (limit2 / num))) : this;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float len2() => this.x * this.x + this.y * this.y;

    [LineNumberTable(new byte[] {160, 181, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec2 setLength2(float len2)
    {
      float num = this.len2();
      return (double) num == 0.0 || (double) num == (double) len2 ? this : this.scl((float) Math.sqrt((double) (len2 / num)));
    }

    [LineNumberTable(366)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float crs(Vec2 v) => this.x * v.y - this.y * v.x;

    [LineNumberTable(new byte[] {161, 62, 115, 137})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec2 setAngleRad(float radians)
    {
      this.set(this.len(), 0.0f);
      this.rotateRad(radians);
      return this;
    }

    [LineNumberTable(new byte[] {161, 94, 105, 137, 117, 149, 103, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec2 rotateRad(float radians)
    {
      float num1 = Mathf.cos(radians);
      float num2 = Mathf.sin(radians);
      float num3 = this.x * num1 - this.y * num2;
      float num4 = this.x * num2 + this.y * num1;
      this.x = num3;
      this.y = num4;
      return this;
    }

    [LineNumberTable(new byte[] {161, 237, 101, 122})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool epsilonEquals(Vec2 other, float epsilon) => other != null && (double) Math.abs(other.x - this.x) <= (double) epsilon && (double) Math.abs(other.y - this.y) <= (double) epsilon;

    [LineNumberTable(new byte[] {161, 247, 118})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool epsilonEquals(float x, float y, float epsilon) => (double) Math.abs(x - this.x) <= (double) epsilon && (double) Math.abs(y - this.y) <= (double) epsilon;

    [LineNumberTable(655)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isUnit(float margin) => (double) Math.abs(this.len2() - 1f) < (double) margin;

    [LineNumberTable(675)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isOnLine(Vec2 other, float epsilon) => Mathf.zero(this.x * other.y - this.y * other.x, epsilon);

    [LineNumberTable(670)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isOnLine(Vec2 other) => Mathf.zero(this.x * other.y - this.y * other.x);

    [LineNumberTable(new byte[] {160, 108, 124, 124})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec2 mulAdd(Vec2 vec, Vec2 mulVec)
    {
      this.x += vec.x * mulVec.x;
      this.y += vec.y * mulVec.y;
      return this;
    }

    [LineNumberTable(new byte[] {160, 101, 120, 120})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec2 mulAdd(Vec2 vec, float scalar)
    {
      this.x += vec.x * scalar;
      this.y += vec.y * scalar;
      return this;
    }

    [LineNumberTable(715)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool hasOppositeDirection(Vec2 vector) => (double) this.dot(vector) < 0.0;

    [LineNumberTable(710)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool hasSameDirection(Vec2 vector) => (double) this.dot(vector) > 0.0;

    [LineNumberTable(705)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isPerpendicular(Vec2 vector, float epsilon) => Mathf.zero(this.dot(vector), epsilon);

    [LineNumberTable(700)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isPerpendicular(Vec2 vector) => Mathf.zero(this.dot(vector));

    [LineNumberTable(695)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isCollinearOpposite(Vec2 other) => this.isOnLine(other) && (double) this.dot(other) < 0.0;

    [LineNumberTable(690)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isCollinearOpposite(Vec2 other, float epsilon) => this.isOnLine(other, epsilon) && (double) this.dot(other) < 0.0;

    [LineNumberTable(685)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isCollinear(Vec2 other) => this.isOnLine(other) && (double) this.dot(other) > 0.0;

    [LineNumberTable(680)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isCollinear(Vec2 other, float epsilon) => this.isOnLine(other, epsilon) && (double) this.dot(other) > 0.0;

    [LineNumberTable(new byte[] {9, 116, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec2 div(Vec2 other)
    {
      this.x /= other.x;
      this.y /= other.y;
      return this;
    }

    [LineNumberTable(new byte[] {160, 94, 116, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec2 scl(Vec2 v)
    {
      this.x *= v.x;
      this.y *= v.y;
      return this;
    }

    [LineNumberTable(new byte[] {160, 165, 104, 106, 103, 119, 103, 119})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec2 clamp(float min, float max)
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

    [LineNumberTable(54)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec2 snap() => this.set((float) ByteCodeHelper.f2i(this.x), (float) ByteCodeHelper.f2i(this.y));

    [LineNumberTable(new byte[] {109, 120, 120})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec2 add(Vec2 vec, float scl)
    {
      this.x += vec.x * scl;
      this.y += vec.y * scl;
      return this;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float dot(float ox, float oy) => this.x * ox + this.y * oy;

    [LineNumberTable(new byte[] {160, 87, 112, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec2 scl(float x, float y)
    {
      this.x *= x;
      this.y *= y;
      return this;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float dst2(float x, float y)
    {
      float num1 = x - this.x;
      float num2 = y - this.y;
      return num1 * num1 + num2 * num2;
    }

    [LineNumberTable(new byte[] {160, 220, 106, 159, 8, 111, 120, 119, 193})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec2 fromString(string v)
    {
      int num = String.instancehelper_indexOf(v, 44, 1);
      if (num != -1 && String.instancehelper_charAt(v, 0) == '(')
      {
        if (String.instancehelper_charAt(v, String.instancehelper_length(v) - 1) == ')')
        {
          Vec2 vec2;
          try
          {
            vec2 = this.set(Float.parseFloat(String.instancehelper_substring(v, 1, num)), Float.parseFloat(String.instancehelper_substring(v, num + 1, String.instancehelper_length(v) - 1)));
          }
          catch (NumberFormatException ex)
          {
            goto label_5;
          }
          return vec2;
label_5:;
        }
      }
      string message = new StringBuilder().append("Malformed Vec2: ").append(v).toString();
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new ArcRuntimeException(message);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float crs(float x, float y) => this.x * y - this.y * x;

    [LineNumberTable(394)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float angle(Vec2 reference) => (float) Math.atan2((double) this.crs(reference), (double) this.dot(reference)) * 57.29578f;

    [LineNumberTable(408)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float angleRad() => (float) Math.atan2((double) this.y, (double) this.x);

    [LineNumberTable(416)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float angleRad(Vec2 reference) => (float) Math.atan2((double) this.crs(reference), (double) this.dot(reference));

    [LineNumberTable(495)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec2 rotateAroundRad(Vec2 reference, float radians) => this.sub(reference).rotateRad(radians).add(reference);

    [LineNumberTable(new byte[] {161, 162, 127, 1, 127, 1})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec2 lerpPast(Vec2 target, float alpha)
    {
      this.x += (target.x - this.x) * alpha;
      this.y += (target.y - this.y) * alpha;
      return this;
    }

    [LineNumberTable(new byte[] {161, 168, 113, 106, 119, 119})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec2 lerpDelta(float tx, float ty, float alpha)
    {
      alpha = Mathf.clamp(alpha * Time.delta);
      float num = 1f - alpha;
      this.x = this.x * num + tx * alpha;
      this.y = this.y * num + ty * alpha;
      return this;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec2 lerp(float tx, float ty, float alpha)
    {
      float num = 1f - alpha;
      this.x = this.x * num + tx * alpha;
      this.y = this.y * num + ty * alpha;
      return this;
    }

    [LineNumberTable(new byte[] {161, 218, 99, 98, 113, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int hashCode() => 31 * (31 * 1 + Float.floatToIntBits(this.x)) + Float.floatToIntBits(this.y);

    [LineNumberTable(new byte[] {161, 227, 107, 101, 117, 103, 122})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool equals(object obj)
    {
      if (object.ReferenceEquals((object) this, obj))
        return true;
      if (obj == null || !object.ReferenceEquals((object) ((object) this).GetType(), (object) obj.GetType()))
        return false;
      Vec2 vec2 = (Vec2) obj;
      return Float.floatToIntBits(this.x) == Float.floatToIntBits(vec2.x) && Float.floatToIntBits(this.y) == Float.floatToIntBits(vec2.y);
    }

    [LineNumberTable(627)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool epsilonEquals(Vec2 other) => this.epsilonEquals(other, 1E-06f);

    [LineNumberTable(637)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool epsilonEquals(float x, float y) => this.epsilonEquals(x, y, 1E-06f);

    [LineNumberTable(650)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isUnit() => this.isUnit(1E-09f);

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(10)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vector \u003Cbridge\u003EsetZero() => (Vector) this.setZero();

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(10)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vector mulAdd(Vector v1, Vector v2) => (Vector) this.mulAdd((Vec2) v1, (Vec2) v2);

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(10)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vector mulAdd(Vector v, float f) => (Vector) this.mulAdd((Vec2) v, f);

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(10)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool epsilonEquals(Vector v, float f) => this.epsilonEquals((Vec2) v, f);

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(10)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool hasOppositeDirection(Vector v) => this.hasOppositeDirection((Vec2) v);

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(10)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool hasSameDirection(Vector v) => this.hasSameDirection((Vec2) v);

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(10)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isPerpendicular(Vector v, float f) => this.isPerpendicular((Vec2) v, f);

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(10)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isPerpendicular(Vector v) => this.isPerpendicular((Vec2) v);

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(10)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isCollinearOpposite(Vector v) => this.isCollinearOpposite((Vec2) v);

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(10)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isCollinearOpposite(Vector v, float f) => this.isCollinearOpposite((Vec2) v, f);

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(10)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isCollinear(Vector v) => this.isCollinear((Vec2) v);

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(10)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isCollinear(Vector v, float f) => this.isCollinear((Vec2) v, f);

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(10)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isOnLine(Vector v) => this.isOnLine((Vec2) v);

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(10)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isOnLine(Vector v, float f) => this.isOnLine((Vec2) v, f);

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(10)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vector \u003Cbridge\u003EsetToRandomDirection() => (Vector) this.setToRandomDirection();

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(10)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vector interpolate(Vector v, float f, Interp i) => (Vector) this.interpolate((Vec2) v, f, i);

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(10)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vector lerp(Vector v, float f) => (Vector) this.lerp((Vec2) v, f);

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(10)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float dst2(Vector v) => this.dst2((Vec2) v);

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(10)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float dst(Vector v) => this.dst((Vec2) v);

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(10)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vector div(Vector v) => (Vector) this.div((Vec2) v);

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(10)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vector scl(Vector v) => (Vector) this.scl((Vec2) v);

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(10)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vector \u003Cbridge\u003Escl(float f) => (Vector) this.scl(f);

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(10)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float dot(Vector v) => this.dot((Vec2) v);

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(10)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vector add(Vector v) => (Vector) this.add((Vec2) v);

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(10)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vector \u003Cbridge\u003Enor() => (Vector) this.nor();

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(10)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vector sub(Vector v) => (Vector) this.sub((Vec2) v);

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(10)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vector set(Vector v) => (Vector) this.set((Vec2) v);

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

    [LineNumberTable(11)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static Vec2()
    {
      if (ByteCodeHelper.isAlreadyInited("arc.math.geom.Vec2"))
        return;
      Vec2.__\u003C\u003EX = new Vec2(1f, 0.0f);
      Vec2.__\u003C\u003EY = new Vec2(0.0f, 1f);
      Vec2.__\u003C\u003EZERO = new Vec2(0.0f, 0.0f);
    }

    [HideFromJava]
    public virtual Vector plus([In] Vector obj0) => Vector.\u003Cdefault\u003Eplus((Vector) this, obj0);

    [HideFromJava]
    public virtual Vector minus([In] Vector obj0) => Vector.\u003Cdefault\u003Eminus((Vector) this, obj0);

    [HideFromJava]
    public virtual Vector unaryMinus() => Vector.\u003Cdefault\u003EunaryMinus((Vector) this);

    [HideFromJava]
    public virtual Vector times([In] Vector obj0) => Vector.\u003Cdefault\u003Etimes((Vector) this, obj0);

    [HideFromJava]
    public virtual float angleTo([In] float obj0, [In] float obj1) => Position.\u003Cdefault\u003EangleTo((Position) this, obj0, obj1);

    [HideFromJava]
    public virtual float dst2([In] Position obj0) => Position.\u003Cdefault\u003Edst2((Position) this, obj0);

    [HideFromJava]
    public virtual bool within([In] float obj0, [In] float obj1, [In] float obj2) => Position.\u003Cdefault\u003Ewithin((Position) this, obj0, obj1, obj2);

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
    public static Vec2 X
    {
      [HideFromJava] get => Vec2.__\u003C\u003EX;
    }

    [Modifiers]
    public static Vec2 Y
    {
      [HideFromJava] get => Vec2.__\u003C\u003EY;
    }

    [Modifiers]
    public static Vec2 ZERO
    {
      [HideFromJava] get => Vec2.__\u003C\u003EZERO;
    }
  }
}
