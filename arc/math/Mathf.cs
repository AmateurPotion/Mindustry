// Decompiled with JetBrains decompiler
// Type: arc.math.Mathf
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

namespace arc.math
{
  public sealed class Mathf : Object
  {
    internal static int[] __\u003C\u003Esigns;
    internal static int[] __\u003C\u003Eone;
    internal static bool[] __\u003C\u003Ebooleans;
    public const float FLOAT_ROUNDING_ERROR = 1E-06f;
    public const float PI = 3.141593f;
    public const float pi = 3.141593f;
    public const float PI2 = 6.283185f;
    public const float E = 2.718282f;
    internal static float __\u003C\u003Esqrt2;
    internal static float __\u003C\u003Esqrt3;
    public const float radiansToDegrees = 57.29578f;
    public const float radDeg = 57.29578f;
    public const float degreesToRadians = 0.01745329f;
    public const float degRad = 0.01745329f;
    private const int SIN_BITS = 14;
    private const int SIN_MASK = 16383;
    private const int SIN_COUNT = 16384;
    private const float radFull = 6.283185f;
    private const float degFull = 360f;
    private const float radToIndex = 2607.594f;
    private const float degToIndex = 45.51111f;
    private const int BIG_ENOUGH_INT = 16384;
    private const double BIG_ENOUGH_FLOOR = 16384.0;
    private const double CEIL = 0.9999999;
    private const double BIG_ENOUGH_ROUND = 16384.5;
    [Modifiers]
    private static Rand seedr;
    [Modifiers]
    private static Vec2 v1;
    [Modifiers]
    private static Vec2 v2;
    [Modifiers]
    private static Vec2 v3;
    public static Rand rand;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static float clamp(float value, float min, float max)
    {
      if ((double) value < (double) min)
        return min;
      return (double) value > (double) max ? max : value;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static float lerp(float fromValue, float toValue, float progress) => fromValue + (toValue - fromValue) * progress;

    [LineNumberTable(203)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int random(int range) => Mathf.rand.nextInt(range + 1);

    [LineNumberTable(198)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool chance(double d) => (double) Mathf.rand.nextFloat() < d;

    [LineNumberTable(182)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int range(int range) => Mathf.random(-range, range);

    [LineNumberTable(170)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static float pow(float a, float b) => (float) Math.pow((double) a, (double) b);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int ceil(float value) => 16384 - ByteCodeHelper.d2i(16384.0 - (double) value);

    [LineNumberTable(640)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool within(float x1, float y1, float x2, float y2, float dst) => (double) Mathf.dst2(x1, y1, x2, y2) < (double) (dst * dst);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int clamp(int value, int min, int max)
    {
      if (value < min)
        return min;
      return value > max ? max : value;
    }

    [LineNumberTable(178)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static float range(float range) => Mathf.random(-range, range);

    [LineNumberTable(new byte[] {161, 236, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static float dst(float x1, float y1, float x2, float y2)
    {
      float num1 = x2 - x1;
      float num2 = y2 - y1;
      return (float) Math.sqrt((double) (num1 * num1 + num2 * num2));
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static float dst2(float x1, float y1, float x2, float y2)
    {
      float num1 = x2 - x1;
      float num2 = y2 - y1;
      return num1 * num1 + num2 * num2;
    }

    [LineNumberTable(138)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static float sqrt(float x) => (float) Math.sqrt((double) x);

    [LineNumberTable(238)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static float random(float range) => Mathf.rand.nextFloat() * range;

    [LineNumberTable(390)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static float approachDelta(float from, float to, float speed) => Mathf.approach(from, to, Time.delta * speed);

    [LineNumberTable(new byte[] {162, 2, 120, 136, 113, 100, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Vec2 arrive(
      float x,
      float y,
      float destX,
      float destY,
      Vec2 curVel,
      float radius,
      float tolerance,
      float speed,
      float accel)
    {
      Vec2 vec2 = Mathf.v1.set(destX, destY).sub(x, y);
      float num = vec2.len();
      if ((double) num <= (double) tolerance)
        return Mathf.v3.setZero();
      float limit = speed;
      if ((double) num <= (double) radius)
        limit *= num / radius;
      return vec2.sub(curVel.x / accel, curVel.y / accel).limit(limit);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int num(bool b) => b ? 1 : 0;

    [LineNumberTable(370)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static float clamp(float value) => Mathf.clamp(value, 0.0f, 1f);

    [LineNumberTable(401)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static float lerpDelta(float fromValue, float toValue, float progress) => Mathf.lerp(fromValue, toValue, Mathf.clamp(progress * Time.delta));

    [LineNumberTable(506)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool zero(float value, float tolerance) => (double) Math.abs(value) <= (double) tolerance;

    [LineNumberTable(243)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static float random(float start, float end) => start + Mathf.rand.nextFloat() * (end - start);

    [LineNumberTable(63)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static float absin(float @in, float scl, float mag) => (Mathf.sin(@in, scl * 2f, mag) + mag) / 2f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int round(float value, int step) => ByteCodeHelper.f2i(value / (float) step) * step;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool within(float x1, float y1, float dst) => (double) (x1 * x1 + y1 * y1) < (double) (dst * dst);

    [LineNumberTable(493)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool zero(float value) => (double) Math.abs(value) <= 9.99999997475243E-07;

    [LineNumberTable(new byte[] {160, 139, 107, 104, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int randomSeed(long seed, int min, int max)
    {
      Mathf.seedr.setSeed(seed);
      if (Mathf.isPowerOfTwo(max))
        Mathf.seedr.nextInt();
      return Mathf.seedr.nextInt(max - min + 1) + min;
    }

    [LineNumberTable(59)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static float absin(float scl, float mag) => Mathf.absin(Time.time, scl, mag);

    [LineNumberTable(545)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int mod(int x, int n)
    {
      int num1 = x;
      int num2 = n;
      int num3 = (num2 != -1 ? num1 % num2 : 0) + n;
      int num4 = n;
      return num4 == -1 ? 0 : num3 % num4;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int round(float value) => ByteCodeHelper.d2i((double) value + 16384.5) - 16384;

    [LineNumberTable(55)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static float cosDeg(float degrees) => Mathf.Sin.table[ByteCodeHelper.f2i((degrees + 90f) * 45.51111f) & 16383];

    [LineNumberTable(50)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static float sinDeg(float degrees) => Mathf.Sin.table[ByteCodeHelper.f2i(degrees * 45.51111f) & 16383];

    [LineNumberTable(75)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static float sin(float radians, float scl, float mag) => Mathf.sin(radians / scl) * mag;

    [LineNumberTable(194)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool chanceDelta(double d) => (double) Mathf.rand.nextFloat() < d * (double) Time.delta;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static float curve(float f, float from, float to)
    {
      if ((double) f < (double) from)
        return 0.0f;
      return (double) f > (double) to ? 1f : (f - from) / (to - from);
    }

    [LineNumberTable(new byte[] {160, 153, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static float randomSeed(long seed)
    {
      Mathf.seedr.setSeed(seed * 99999L);
      return Mathf.seedr.nextFloat();
    }

    [LineNumberTable(new byte[] {160, 158, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static float randomSeed(long seed, float max)
    {
      Mathf.seedr.setSeed(seed * 99999L);
      return Mathf.seedr.nextFloat() * max;
    }

    [LineNumberTable(new byte[] {33, 114, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static float angle(float x, float y)
    {
      float num = Mathf.atan2(x, y) * 57.29578f;
      if ((double) num < 0.0)
        num += 360f;
      return num;
    }

    [LineNumberTable(new byte[] {160, 163, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static float randomSeedRange(long seed, float range)
    {
      Mathf.seedr.setSeed(seed * 99999L);
      return range * (Mathf.seedr.nextFloat() - 0.5f) * 2f;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int sign(float f) => (double) f < 0.0 ? -1 : 1;

    [LineNumberTable(475)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int round(int value, int step)
    {
      int num1 = value;
      int num2 = step;
      return (num2 != -1 ? num1 / num2 : -num1) * step;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int sign(bool b) => b ? 1 : -1;

    [LineNumberTable(550)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static float slope(float fin) => 1f - Math.abs(fin - 0.5f) * 2f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static float mod(float f, float n) => (f % n + n) % n;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static float round(float value, float step) => (float) ByteCodeHelper.f2i(value / step) * step;

    [LineNumberTable(525)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool equal(float a, float b, float tolerance) => (double) Math.abs(a - b) <= (double) tolerance;

    [LineNumberTable(598)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static float dst(float x1, float y1) => (float) Math.sqrt((double) (x1 * x1 + y1 * y1));

    [LineNumberTable(208)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int random(int start, int end) => start + Mathf.rand.nextInt(end - start + 1);

    [LineNumberTable(515)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool equal(float a, float b) => (double) Math.abs(a - b) <= 9.99999997475243E-07;

    [LineNumberTable(new byte[] {64, 111, 111, 111, 134, 103, 110, 118, 127, 3, 130, 118})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static float atan2(float x, float y)
    {
      if ((double) Math.abs(x) < 1.0000000116861E-07)
      {
        if ((double) y > 0.0)
          return 1.570796f;
        return (double) y == 0.0 ? 0.0f : -1.570796f;
      }
      float num1 = y / x;
      if ((double) Math.abs(num1) < 1.0)
      {
        float num2 = num1 / (1f + 0.28f * num1 * num1);
        return (double) x < 0.0 ? num2 + ((double) y >= 0.0 ? 3.141593f : -3.141593f) : num2;
      }
      float num3 = 1.570796f - num1 / (num1 * num1 + 0.28f);
      return (double) y < 0.0 ? num3 - 3.141593f : num3;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static float curve(float f, float offset) => (double) f < (double) offset ? 0.0f : (f - offset) / (1f - offset);

    [LineNumberTable(79)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static float cos(float radians, float scl, float mag) => Mathf.cos(radians / scl) * mag;

    [LineNumberTable(586)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static float len(float x, float y) => (float) Math.sqrt((double) (x * x + y * y));

    [LineNumberTable(233)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static float random() => Mathf.rand.nextFloat();

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static float map(float value, float froma, float toa, float fromb, float tob) => fromb + (value - froma) * (tob - fromb) / (toa - froma);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static float slerp(float fromDegrees, float toDegrees, float progress)
    {
      float num = (toDegrees - fromDegrees + 360f + 180f) % 360f - 180f;
      return (fromDegrees + num * progress + 360f) % 360f;
    }

    [LineNumberTable(new byte[] {39, 117, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static float angleExact(float x, float y)
    {
      float num = (float) Math.atan2((double) y, (double) x) * 57.29578f;
      if ((double) num < 0.0)
        num += 360f;
      return num;
    }

    [LineNumberTable(40)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static float sin(float radians) => Mathf.Sin.table[ByteCodeHelper.f2i(radians * 2607.594f) & 16383];

    [LineNumberTable(45)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static float cos(float radians) => Mathf.Sin.table[ByteCodeHelper.f2i((radians + 1.570796f) * 2607.594f) & 16383];

    [LineNumberTable(174)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int pow(int a, int b) => ByteCodeHelper.d2i(Math.ceil(Math.pow((double) a, (double) b)));

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static float dst2(float x1, float y1) => x1 * x1 + y1 * y1;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int nextPowerOfTwo(int value)
    {
      if (value == 0)
        return 1;
      value += -1;
      value |= value >> 1;
      value |= value >> 2;
      value |= value >> 4;
      value |= value >> 8;
      value |= value >> 16;
      return value + 1;
    }

    [LineNumberTable(619)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static float dstm(float x1, float y1, float x2, float y2) => Math.abs(x1 - x2) + Math.abs(y1 - y2);

    [LineNumberTable(498)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool zero(double value) => Math.abs(value) <= 9.99999997475243E-07;

    [LineNumberTable(431)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static float slerpDelta(float fromDegrees, float toDegrees, float progress) => Mathf.slerp(fromDegrees, toDegrees, Mathf.clamp(progress * Time.delta));

    [LineNumberTable(380)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static float maxZero(float val) => Math.max(val, 0.0f);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool isPowerOfTwo(int value) => value != 0 && (value & value - 1) == 0;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int floor(float value) => ByteCodeHelper.d2i((double) value + 16384.0) - 16384;

    [LineNumberTable(new byte[] {160, 208, 108, 103, 127, 6})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static float randomTriangular(float min, float max, float mode)
    {
      float num1 = Mathf.rand.nextFloat();
      float num2 = max - min;
      return (double) num1 <= (double) ((mode - min) / num2) ? min + (float) Math.sqrt((double) (num1 * num2 * (mode - min))) : max - (float) Math.sqrt((double) ((1f - num1) * num2 * (max - mode)));
    }

    [LineNumberTable(385)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static float approach(float from, float to, float speed) => from + Mathf.clamp(to - from, -speed, speed);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static float curveMargin(float f, float marginLeft, float marginRight)
    {
      if ((double) f < (double) marginLeft)
        return f / marginLeft * 0.5f;
      return (double) f > (double) (1f - marginRight) ? (f - 1f + marginRight) / marginRight * 0.5f + 0.5f : 0.5f;
    }

    [LineNumberTable(6)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Mathf()
    {
    }

    [LineNumberTable(67)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static float tan(float radians, float scl, float mag) => Mathf.sin(radians / scl) / Mathf.cos(radians / scl) * mag;

    [LineNumberTable(71)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static float sin(float scl, float mag) => Mathf.sin(Time.time / scl) * mag;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static float wrapAngleAroundZero(float a)
    {
      if ((double) a >= 0.0)
      {
        float num = a % 6.283185f;
        if ((double) num > 3.14159274101257)
          num -= 6.283185f;
        return num;
      }
      float num1 = (float) (-(double) a % 6.28318548202515);
      if ((double) num1 > 3.14159274101257)
        num1 -= 6.283185f;
      return -num1;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int digits(int n)
    {
      if (n < 100000)
      {
        if (n < 100)
          return n < 10 ? 1 : 2;
        if (n < 1000)
          return 3;
        return n < 10000 ? 4 : 5;
      }
      if (n < 10000000)
        return n < 1000000 ? 6 : 7;
      if (n < 100000000)
        return 8;
      return n < 1000000000 ? 9 : 10;
    }

    [LineNumberTable(134)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int digits(long n) => n == 0L ? 1 : ByteCodeHelper.d2i(Math.log10((double) n) + 1.0);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static float sqr(float x) => x * x;

    [LineNumberTable(151)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static float map(float value, float from, float to) => Mathf.map(value, 0.0f, 1f, from, to);

    [LineNumberTable(new byte[] {160, 72, 112, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static float range(float min, float max) => Mathf.chance(0.5) ? Mathf.random(min, max) : -Mathf.random(min, max);

    [LineNumberTable(213)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static long random(long range) => ByteCodeHelper.d2l(Mathf.rand.nextDouble() * (double) range);

    [LineNumberTable(218)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static long random(long start, long end) => start + ByteCodeHelper.d2l(Mathf.rand.nextDouble() * (double) (end - start));

    [LineNumberTable(223)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool randomBoolean() => Mathf.rand.nextBoolean();

    [LineNumberTable(228)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool randomBoolean(float chance) => (double) Mathf.random() < (double) chance;

    [LineNumberTable(248)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int randomSign() => 1 | Mathf.rand.nextInt() >> 31;

    [LineNumberTable(new byte[] {160, 148, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static float randomSeed(long seed, float min, float max)
    {
      Mathf.seedr.setSeed(seed);
      return min + Mathf.seedr.nextFloat() * (max - min);
    }

    [LineNumberTable(288)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static float randomTriangular() => Mathf.rand.nextFloat() - Mathf.rand.nextFloat();

    [LineNumberTable(299)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static float randomTriangular(float max) => (Mathf.rand.nextFloat() - Mathf.rand.nextFloat()) * max;

    [LineNumberTable(311)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static float randomTriangular(float min, float max) => Mathf.randomTriangular(min, max, (min + max) * 0.5f);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static short clamp(short value, short min, short max)
    {
      int num1 = (int) value;
      int num2 = (int) min;
      int num3 = (int) max;
      if (num1 < num2)
        return (short) num2;
      return num1 > num3 ? (short) num3 : (short) num1;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static long clamp(long value, long min, long max)
    {
      if (value < min)
        return min;
      return value > max ? max : value;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static double clamp(double value, double min, double max)
    {
      if (value < min)
        return min;
      return value > max ? max : value;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static float slerpRad(float fromRadians, float toRadians, float progress)
    {
      float num = (toRadians - fromRadians + 6.283185f + 3.141593f) % 6.283185f - 3.141593f;
      return (fromRadians + num * progress + 6.283185f) % 6.283185f;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int floorPositive(float value) => ByteCodeHelper.f2i(value);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int ceilPositive(float value) => ByteCodeHelper.d2i((double) value + 0.9999999);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int roundPositive(float value) => ByteCodeHelper.f2i(value + 0.5f);

    [LineNumberTable(530)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static float log(float a, float value) => (float) (Math.log((double) value) / Math.log((double) a));

    [LineNumberTable(535)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static float log2(float value) => (float) Math.log((double) value) / 0.30103f;

    [LineNumberTable(575)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static float curveMargin(float f, float margin) => Mathf.curveMargin(f, margin, margin);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static float len2(float x, float y) => x * x + y * y;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static float dot(float x1, float y1, float x2, float y2) => x1 * x2 + y1 * y2;

    [LineNumberTable(623)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Vec2 arrive(
      Position pos,
      Position target,
      Vec2 curVel,
      float radius,
      float tolerance,
      float speed,
      float smoothTime)
    {
      return Mathf.arrive(pos.getX(), pos.getY(), target.getX(), target.getY(), curVel, radius, tolerance, speed, smoothTime);
    }

    [LineNumberTable(new byte[] {159, 141, 173, 115, 111, 243, 69, 112, 240, 82, 106, 158})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static Mathf()
    {
      if (ByteCodeHelper.isAlreadyInited("arc.math.Mathf"))
        return;
      Mathf.__\u003C\u003Esigns = new int[2]{ -1, 1 };
      Mathf.__\u003C\u003Eone = new int[1]{ 1 };
      Mathf.__\u003C\u003Ebooleans = new bool[2]
      {
        true,
        false
      };
      Mathf.__\u003C\u003Esqrt2 = Mathf.sqrt(2f);
      Mathf.__\u003C\u003Esqrt3 = Mathf.sqrt(3f);
      Mathf.seedr = new Rand();
      Mathf.v1 = new Vec2();
      Mathf.v2 = new Vec2();
      Mathf.v3 = new Vec2();
      Mathf.rand = new Rand();
    }

    [Modifiers]
    public static int[] signs
    {
      [HideFromJava] get => Mathf.__\u003C\u003Esigns;
    }

    [Modifiers]
    public static int[] one
    {
      [HideFromJava] get => Mathf.__\u003C\u003Eone;
    }

    [Modifiers]
    public static bool[] booleans
    {
      [HideFromJava] get => Mathf.__\u003C\u003Ebooleans;
    }

    [Modifiers]
    public static float sqrt2
    {
      [HideFromJava] get => Mathf.__\u003C\u003Esqrt2;
    }

    [Modifiers]
    public static float sqrt3
    {
      [HideFromJava] get => Mathf.__\u003C\u003Esqrt3;
    }

    [InnerClass]
    internal class Sin : Object
    {
      [Modifiers]
      internal static float[] table;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(648)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private Sin()
      {
      }

      [LineNumberTable(new byte[] {158, 236, 109, 175, 106, 63, 7, 134, 106, 63, 12, 135})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static Sin()
      {
        if (ByteCodeHelper.isAlreadyInited("arc.math.Mathf$Sin"))
          return;
        Mathf.Sin.table = new float[16384];
        for (int index = 0; index < 16384; ++index)
          Mathf.Sin.table[index] = (float) Math.sin((double) (((float) index + 0.5f) / 16384f * 6.283185f));
        for (int index = 0; index < 360; index += 90)
          Mathf.Sin.table[ByteCodeHelper.f2i((float) index * 45.51111f) & 16383] = (float) Math.sin((double) ((float) index * ((float) Math.PI / 180f)));
      }
    }
  }
}
