// Decompiled with JetBrains decompiler
// Type: arc.math.Angles
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.func;
using arc.math.geom;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System.Runtime.CompilerServices;

namespace arc.math
{
  public class Angles : Object
  {
    [Modifiers]
    private static Rand random;
    [Modifiers]
    private static Vec2 rv;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(46)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static float angle(float x, float y) => Angles.angle(0.0f, 0.0f, x, y);

    [LineNumberTable(24)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static float angleDist(float a, float b) => Math.min((double) (a - b) >= 0.0 ? a - b : a - b + 360f, (double) (b - a) >= 0.0 ? b - a : b - a + 360f);

    [LineNumberTable(new byte[] {0, 122, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static float angle(float x, float y, float x2, float y2)
    {
      float num = Mathf.atan2(x2 - x, y2 - y) * 57.29578f;
      if ((double) num < 0.0)
        num += 360f;
      return num;
    }

    [LineNumberTable(56)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static float trnsx(float angle, float len) => len * Mathf.cosDeg(angle);

    [LineNumberTable(60)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static float trnsy(float angle, float len) => len * Mathf.sinDeg(angle);

    [LineNumberTable(64)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static float trnsx(float angle, float x, float y) => Angles.rv.set(x, y).rotate(angle).x;

    [LineNumberTable(68)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static float trnsy(float angle, float x, float y) => Angles.rv.set(x, y).rotate(angle).y;

    [LineNumberTable(new byte[] {159, 174, 119, 111, 143, 126, 138, 168})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static float moveToward(float angle, float to, float speed)
    {
      if ((double) Math.abs(Angles.angleDist(angle, to)) < (double) speed)
        return to;
      angle = Mathf.mod(angle, 360f);
      to = Mathf.mod(to, 360f);
      if ((double) angle > (double) to == (double) Angles.backwardDistance(angle, to) > (double) Angles.forwardDistance(angle, to))
        angle -= speed;
      else
        angle += speed;
      return angle;
    }

    [LineNumberTable(new byte[] {74, 107, 102, 112, 115, 119, 250, 60, 230, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void randLenVectors(long seed, int amount, float length, Floatc2 cons)
    {
      Angles.random.setSeed(seed);
      for (int index = 0; index < amount; ++index)
      {
        float x = length * Angles.random.nextFloat();
        float degrees = Angles.random.nextFloat() * 360f;
        Angles.rv.set(x, 0.0f).rotate(degrees);
        cons.get(Angles.rv.x, Angles.rv.y);
      }
    }

    [LineNumberTable(new byte[] {104, 107, 105, 108, 106, 115, 119, 255, 13, 59, 233, 71})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void randLenVectors(
      long seed,
      float fin,
      int amount,
      float length,
      Angles.ParticleConsumer cons)
    {
      Angles.random.setSeed(seed);
      for (int index = 0; index < amount; ++index)
      {
        float num = Angles.random.nextFloat();
        float x = length * num * fin;
        float degrees = Angles.random.nextFloat() * 360f;
        Angles.rv.set(x, 0.0f).rotate(degrees);
        cons.accept(Angles.rv.x, Angles.rv.y, fin * num, (1f - fin) * num);
      }
    }

    [LineNumberTable(new byte[] {94, 107, 105, 112, 127, 2, 119, 251, 60, 233, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void randLenVectors(
      long seed,
      int amount,
      float length,
      float angle,
      float range,
      Floatc2 cons)
    {
      Angles.random.setSeed(seed);
      for (int index = 0; index < amount; ++index)
      {
        float x = length * Angles.random.nextFloat();
        float degrees = angle + Angles.random.nextFloat() * range * 2f - range;
        Angles.rv.set(x, 0.0f).rotate(degrees);
        cons.get(Angles.rv.x, Angles.rv.y);
      }
    }

    [LineNumberTable(28)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool near(float a, float b, float range) => (double) Angles.angleDist(a, b) < (double) range;

    [LineNumberTable(20)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool within(float a, float b, float margin) => (double) Angles.angleDist(a, b) <= (double) margin;

    [LineNumberTable(new byte[] {59, 102, 63, 2, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void shotgun(int points, float spacing, float offset, Floatc cons)
    {
      for (int index = 0; index < points; ++index)
        cons.get((float) index * spacing - (float) (points - 1) * spacing / 2f + offset);
    }

    [LineNumberTable(new byte[] {45, 102, 110, 24, 198})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void circleVectors(int points, float length, Floatc2 pos)
    {
      for (int index = 0; index < points; ++index)
      {
        float angle = (float) index * 360f / (float) points;
        pos.get(Angles.trnsx(angle, length), Angles.trnsy(angle, length));
      }
    }

    [LineNumberTable(new byte[] {22, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static float mouseAngle(float cx, float cy)
    {
      Vec2 vec2 = Core.camera.project(cx, cy);
      return Angles.angle(vec2.x, vec2.y, (float) Core.input.mouseX(), (float) Core.input.mouseY());
    }

    [LineNumberTable(16)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static float backwardDistance(float angle1, float angle2) => 360f - Math.abs(angle1 - angle2);

    [LineNumberTable(12)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static float forwardDistance(float angle1, float angle2) => Math.abs(angle1 - angle2);

    [LineNumberTable(7)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Angles()
    {
    }

    [LineNumberTable(new byte[] {27, 102, 39, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void loop(int max, Intc i)
    {
      for (int i1 = 0; i1 < max; ++i1)
        i.get(i1);
    }

    [LineNumberTable(new byte[] {33, 102, 55, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void circle(int points, float offset, Floatc cons)
    {
      for (int index = 0; index < points; ++index)
        cons.get(offset + (float) index * 360f / (float) points);
    }

    [LineNumberTable(new byte[] {39, 102, 51, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void circle(int points, Floatc cons)
    {
      for (int index = 0; index < points; ++index)
        cons.get((float) index * 360f / (float) points);
    }

    [LineNumberTable(new byte[] {52, 102, 114, 24, 198})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void circleVectors(int points, float length, float offset, Floatc2 pos)
    {
      for (int index = 0; index < points; ++index)
      {
        float angle = (float) index * 360f / (float) points + offset;
        pos.get(Angles.trnsx(angle, length), Angles.trnsy(angle, length));
      }
    }

    [LineNumberTable(new byte[] {65, 107, 102, 115, 120, 250, 61, 230, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void randVectors(long seed, int amount, float length, Floatc2 cons)
    {
      Angles.random.setSeed(seed);
      for (int index = 0; index < amount; ++index)
      {
        float degrees = Angles.random.nextFloat() * 360f;
        Angles.rv.set(length, 0.0f).rotate(degrees);
        cons.get(Angles.rv.x, Angles.rv.y);
      }
    }

    [LineNumberTable(new byte[] {84, 107, 102, 116, 115, 119, 251, 60, 230, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void randLenVectors(
      long seed,
      int amount,
      float minLength,
      float length,
      Floatc2 cons)
    {
      Angles.random.setSeed(seed);
      for (int index = 0; index < amount; ++index)
      {
        float x = minLength + length * Angles.random.nextFloat();
        float degrees = Angles.random.nextFloat() * 360f;
        Angles.rv.set(x, 0.0f).rotate(degrees);
        cons.get(Angles.rv.x, Angles.rv.y);
      }
    }

    [LineNumberTable(new byte[] {116, 107, 105, 116, 127, 3, 119, 255, 16, 60, 233, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void randLenVectors(
      long seed,
      float fin,
      int amount,
      float length,
      float angle,
      float range,
      Angles.ParticleConsumer cons)
    {
      Angles.random.setSeed(seed);
      for (int index = 0; index < amount; ++index)
      {
        float x = length * Angles.random.nextFloat() * fin;
        float degrees = angle + Angles.random.nextFloat() * range * 2f - range;
        Angles.rv.set(x, 0.0f).rotate(degrees);
        cons.accept(Angles.rv.x, Angles.rv.y, fin * Angles.random.nextFloat(), 0.0f);
      }
    }

    [LineNumberTable(new byte[] {159, 140, 77, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static Angles()
    {
      if (ByteCodeHelper.isAlreadyInited("arc.math.Angles"))
        return;
      Angles.random = new Rand();
      Angles.rv = new Vec2();
    }

    public interface ParticleConsumer
    {
      void accept(float f1, float f2, float f3, float f4);
    }
  }
}
