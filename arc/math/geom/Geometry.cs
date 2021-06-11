// Decompiled with JetBrains decompiler
// Type: arc.math.geom.Geometry
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.func;
using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.util;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.math.geom
{
  public sealed class Geometry : Object
  {
    internal static Point2[] __\u003C\u003Ed4;
    internal static Point2[] __\u003C\u003Ed4c;
    internal static int[] __\u003C\u003Ed4x;
    internal static int[] __\u003C\u003Ed4y;
    internal static Point2[] __\u003C\u003Ed8;
    internal static Point2[] __\u003C\u003Ed8edge;
    [Modifiers]
    private static Vec2 tmp1;
    [Modifiers]
    private static Vec2 tmp2;
    [Modifiers]
    private static Vec2 tmp3;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [Signature("<T::Larc/math/geom/Position;>(FFLjava/lang/Iterable<TT;>;)TT;")]
    [LineNumberTable(new byte[] {58, 98, 102, 123, 109, 104, 98, 131, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Position findClosest(float x, float y, Iterable list)
    {
      Position position1 = (Position) null;
      float num1 = 0.0f;
      Iterator iterator = list.iterator();
      while (iterator.hasNext())
      {
        Position position2 = (Position) iterator.next();
        float num2 = position2.dst(x, y);
        if (position1 == null || (double) num2 < (double) num1)
        {
          position1 = position2;
          num1 = num2;
        }
      }
      return position1;
    }

    [LineNumberTable(new byte[] {28, 108, 105, 104, 126, 233, 61, 38, 233, 72})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void circle(int x, int y, int width, int height, int radius, Intc2 cons)
    {
      for (int index1 = -radius; index1 <= radius; ++index1)
      {
        for (int index2 = -radius; index2 <= radius; ++index2)
        {
          int i1 = index1 + x;
          int i2 = index2 + y;
          if (i1 >= 0 && i2 >= 0 && (i1 < width && i2 < height) && Mathf.within((float) index1, (float) index2, (float) radius))
            cons.get(i1, i2);
        }
      }
    }

    [LineNumberTable(48)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Point2 d4(int i) => Geometry.__\u003C\u003Ed4[Mathf.mod(i, 4)];

    [LineNumberTable(new byte[] {18, 103, 103, 109, 12, 38, 230, 71})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void circle(int x, int y, int radius, Intc2 cons)
    {
      for (int index1 = -radius; index1 <= radius; ++index1)
      {
        for (int index2 = -radius; index2 <= radius; ++index2)
        {
          if (Mathf.within((float) index1, (float) index2, (float) radius))
            cons.get(index1 + x, index2 + y);
        }
      }
    }

    [LineNumberTable(new byte[] {160, 76, 112, 108, 138, 98, 112, 104, 104, 111, 114, 123, 229, 59, 232, 72})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static float iterateLine(
      float start,
      float x1,
      float y1,
      float x2,
      float y2,
      float segment,
      Floatc2 pos)
    {
      float num1 = Mathf.dst(x1, y1, x2, y2);
      int num2 = ByteCodeHelper.f2i(num1 / segment);
      float num3 = 1f / (float) num2;
      float num4 = num1;
      Geometry.tmp2.set(x2, y2);
      for (int index = 0; index < num2; ++index)
      {
        float alpha = num3 * (float) index;
        Geometry.tmp1.set(x1, y1);
        Geometry.tmp1.lerp(Geometry.tmp2, alpha);
        pos.get(Geometry.tmp1.x, Geometry.tmp1.y);
        num4 -= num3;
      }
      return num4;
    }

    [LineNumberTable(new byte[] {88, 111, 166, 107, 107, 127, 30, 127, 20, 237, 61, 41, 233, 73, 135, 98, 108, 118, 117, 127, 0, 168, 144, 119, 118, 127, 0, 117, 99, 226, 57, 235, 74, 133})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Vec2[] pixelCircle(float index, Geometry.SolidChecker checker)
    {
      int num1 = ByteCodeHelper.f2i(index * 2f);
      IntSeq intSeq = new IntSeq();
      for (int i1 = -1; i1 < num1 + 1; ++i1)
      {
        for (int i2 = -1; i2 < num1 + 1; ++i2)
        {
          if ((checker.solid(index, i1, i2) || checker.solid(index, i1 - 1, i2) || (checker.solid(index, i1, i2 - 1) || checker.solid(index, i1 - 1, i2 - 1))) && (!checker.solid(index, i1, i2) || !checker.solid(index, i1 - 1, i2) || (!checker.solid(index, i1, i2 - 1) || !checker.solid(index, i1 - 1, i2 - 1))))
            intSeq.add(i1 + i2 * (num1 + 1));
        }
      }
      Seq seq1 = new Seq();
      int index1 = 0;
label_9:
      while (intSeq.size > 0)
      {
        int num2 = intSeq.get(index1);
        int num3 = num1 + 1;
        int num4 = num3 != -1 ? num2 % num3 : 0;
        int num5 = intSeq.get(index1);
        int num6 = num1 + 1;
        int num7 = num6 != -1 ? num5 / num6 : -num5;
        Seq seq2 = seq1;
        Vec2.__\u003Cclinit\u003E();
        Vec2 vec2 = new Vec2((float) (num4 - num1 / 2), (float) (num7 - num1 / 2));
        seq2.add((object) vec2);
        intSeq.removeIndex(index1);
        int index2 = 0;
        while (true)
        {
          if (index2 < intSeq.size)
          {
            int num8 = intSeq.get(index2);
            int num9 = num1 + 1;
            int num10 = num9 != -1 ? num8 % num9 : 0;
            int num11 = intSeq.get(index2);
            int num12 = num1 + 1;
            int num13 = num12 != -1 ? num11 / num12 : -num11;
            if (Math.abs(num10 - num4) > 1 || Math.abs(num13 - num7) > 1 || Math.abs(num10 - num4) == 1 && Math.abs(num13 - num7) == 1)
              ++index2;
            else
              break;
          }
          else
            goto label_9;
        }
        index1 = index2;
      }
      return (Vec2[]) seq1.toArray((Class) ClassLiteral<Vec2>.Value);
    }

    [LineNumberTable(274)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Vec2 raycastRect(
      float startx,
      float starty,
      float endx,
      float endy,
      Rect rect)
    {
      return Geometry.raycastRect(startx, starty, endx, endy, rect.x + rect.width / 2f, rect.y + rect.height / 2f, rect.width / 2f, rect.height / 2f);
    }

    [LineNumberTable(new byte[] {160, 203, 134, 127, 13, 191, 14, 102, 167, 111, 175, 114, 178, 111, 175, 114, 178, 146, 127, 0, 111, 165, 111, 127, 0, 227, 70, 174, 112, 144, 109, 141})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Vec2 overlap(Rect a, Rect b, bool x)
    {
      float num1 = 0.0f;
      float num2 = a.x + a.width / 2f;
      float num3 = b.x + b.width / 2f;
      float num4 = a.y + a.height / 2f;
      float num5 = b.y + b.height / 2f;
      float num6 = num2 - num3;
      float num7 = num4 - num5;
      float num8 = a.width / 2f + b.width / 2f - Math.abs(num6);
      if ((double) Math.abs(num8) > 0.0)
      {
        float num9 = a.height / 2f + b.height / 2f - Math.abs(num7);
        if ((double) Math.abs(num9) > 0.0)
        {
          if ((double) Math.abs(num8) < (double) Math.abs(num9))
          {
            Geometry.tmp1.x = (double) num6 >= 0.0 ? -1f : 1f;
            Geometry.tmp1.y = 0.0f;
            num1 = num8;
          }
          else
          {
            Geometry.tmp1.x = 0.0f;
            Geometry.tmp1.y = (double) num7 >= 0.0 ? -1f : 1f;
            num1 = num9;
          }
        }
      }
      float num10 = Math.max(num1, 0.0f);
      float num11 = num10 * Geometry.tmp1.x;
      float num12 = num10 * Geometry.tmp1.y;
      Geometry.tmp1.x = -num11;
      Geometry.tmp1.y = -num12;
      return Geometry.tmp1;
    }

    [Signature("<T::Larc/math/geom/Position;>(FFLjava/lang/Iterable<TT;>;)TT;")]
    [LineNumberTable(new byte[] {71, 98, 102, 123, 109, 104, 98, 131, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Position findFurthest(float x, float y, Iterable list)
    {
      Position position1 = (Position) null;
      float num1 = 0.0f;
      Iterator iterator = list.iterator();
      while (iterator.hasNext())
      {
        Position position2 = (Position) iterator.next();
        float num2 = position2.dst(x, y);
        if (position1 == null || (double) num2 > (double) num1)
        {
          position1 = position2;
          num1 = num2;
        }
      }
      return position1;
    }

    [Signature("<T::Larc/math/geom/Position;>(FF[TT;)TT;")]
    [LineNumberTable(new byte[] {45, 98, 102, 115, 110, 104, 99, 227, 60, 232, 71})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Position findClosest(float x, float y, Position[] list)
    {
      Position position1 = (Position) null;
      float num1 = 0.0f;
      Position[] positionArray = list;
      int length = positionArray.Length;
      for (int index = 0; index < length; ++index)
      {
        Position position2 = positionArray[index];
        float num2 = position2.dst(x, y);
        if (position1 == null || (double) num2 < (double) num1)
        {
          position1 = position2;
          num1 = num2;
        }
      }
      return position1;
    }

    [LineNumberTable(134)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Vec2[] pixelCircle(float tindex) => Geometry.pixelCircle(tindex, (Geometry.SolidChecker) new Geometry.__\u003C\u003EAnon1());

    [LineNumberTable(64)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Point2 d8edge(int i) => Geometry.__\u003C\u003Ed8edge[Mathf.mod(i, 4)];

    [LineNumberTable(52)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int d4x(int i) => Geometry.__\u003C\u003Ed4x[Mathf.mod(i, 4)];

    [LineNumberTable(56)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int d4y(int i) => Geometry.__\u003C\u003Ed4y[Mathf.mod(i, 4)];

    [LineNumberTable(new byte[] {161, 91, 121, 121})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Vec2 triangleCentroid(
      float x1,
      float y1,
      float x2,
      float y2,
      float x3,
      float y3,
      Vec2 centroid)
    {
      centroid.x = (x1 + x2 + x3) / 3f;
      centroid.y = (y1 + y2 + y3) / 3f;
      return centroid;
    }

    [LineNumberTable(new byte[] {160, 165, 142, 134, 102, 135, 106, 106, 105, 105, 122, 123, 122, 155, 108, 130, 108, 140, 114, 130, 106, 103, 103, 108, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Vec2 raycastRect(
      float startx,
      float starty,
      float endx,
      float endy,
      float x,
      float y,
      float halfx,
      float halfy)
    {
      float num1 = endx - startx;
      float num2 = endy - starty;
      Vec2 tmp1 = Geometry.tmp1;
      float num3 = 0.0f;
      float num4 = 0.0f;
      float f1 = 1f / num1;
      float f2 = 1f / num2;
      int num5 = Mathf.sign(f1);
      int num6 = Mathf.sign(f2);
      float num7 = (x - (float) num5 * (halfx + num3) - startx) * f1;
      float num8 = (y - (float) num6 * (halfy + num4) - starty) * f2;
      float num9 = (x + (float) num5 * (halfx + num3) - startx) * f1;
      float num10 = (y + (float) num6 * (halfy + num4) - starty) * f2;
      if ((double) num7 > (double) num10 || (double) num8 > (double) num9)
        return (Vec2) null;
      float num11 = Math.max(num7, num8);
      float num12 = Math.min(num9, num10);
      if ((double) num11 >= 1.0 || (double) num12 <= 0.0)
        return (Vec2) null;
      float num13 = Mathf.clamp(num11);
      float num14 = num13 * num1;
      float num15 = num13 * num2;
      tmp1.x = startx + num14;
      tmp1.y = starty + num15;
      return tmp1;
    }

    [LineNumberTable(new byte[] {161, 112, 115, 114, 111, 111, 110, 113, 116, 113, 111, 111, 111, 148, 113, 114, 111, 111, 111, 111, 123, 143, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static float triangleCircumradius(
      float x1,
      float y1,
      float x2,
      float y2,
      float x3,
      float y3)
    {
      float num1;
      float num2;
      if ((double) Math.abs(y2 - y1) < 9.99999997475243E-07)
      {
        float num3 = -(x3 - x2) / (y3 - y2);
        float num4 = (x2 + x3) / 2f;
        float num5 = (y2 + y3) / 2f;
        num1 = (x2 + x1) / 2f;
        num2 = num3 * (num1 - num4) + num5;
      }
      else if ((double) Math.abs(y3 - y2) < 9.99999997475243E-07)
      {
        float num3 = -(x2 - x1) / (y2 - y1);
        float num4 = (x1 + x2) / 2f;
        float num5 = (y1 + y2) / 2f;
        num1 = (x3 + x2) / 2f;
        num2 = num3 * (num1 - num4) + num5;
      }
      else
      {
        float num3 = -(x2 - x1) / (y2 - y1);
        float num4 = -(x3 - x2) / (y3 - y2);
        float num5 = (x1 + x2) / 2f;
        float num6 = (x2 + x3) / 2f;
        float num7 = (y1 + y2) / 2f;
        float num8 = (y2 + y3) / 2f;
        num1 = (num3 * num5 - num4 * num6 + num8 - num7) / (num3 - num4);
        num2 = num3 * (num1 - num5) + num7;
      }
      float num9 = x1 - num1;
      float num10 = y1 - num2;
      return (float) Math.sqrt((double) (num9 * num9 + num10 * num10));
    }

    [LineNumberTable(new byte[] {161, 225, 107, 102, 108, 100, 101, 103, 102, 106, 101, 231, 57, 230, 73})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void ensureCCW(float[] polygon, int offset, int count)
    {
      if (!Geometry.isClockwise(polygon, offset, count))
        return;
      int num1 = offset + count - 2;
      int index1 = offset;
      for (int index2 = offset + count / 2; index1 < index2; index1 += 2)
      {
        int index3 = num1 - index1;
        float num2 = polygon[index1];
        float num3 = polygon[index1 + 1];
        polygon[index1] = polygon[index3];
        polygon[index1 + 1] = polygon[index3 + 1];
        polygon[index3] = num2;
        polygon[index3 + 1] = num3;
      }
    }

    [LineNumberTable(new byte[] {161, 239, 102, 102, 108, 100, 103, 103, 103, 241, 59, 230, 71, 104, 105, 101, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool isClockwise(float[] polygon, int offset, int count)
    {
      if (count <= 2)
        return false;
      float num1 = 0.0f;
      int index1 = offset;
      for (int index2 = offset + count - 3; index1 < index2; index1 += 2)
      {
        float num2 = polygon[index1];
        float num3 = polygon[index1 + 1];
        float num4 = polygon[index1 + 2];
        float num5 = polygon[index1 + 3];
        num1 += num2 * num5 - num4 * num3;
      }
      float num6 = polygon[offset + count - 2];
      float num7 = polygon[offset + count - 1];
      float num8 = polygon[offset];
      float num9 = polygon[offset + 1];
      return (double) (num1 + num6 * num9 - num8 * num7) < 0.0;
    }

    [Modifiers]
    [LineNumberTable(90)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024vectorsToFloats\u00240([In] FloatSeq obj0, [In] Vec2 obj1) => obj0.add(obj1.x, obj1.y);

    [Modifiers]
    [LineNumberTable(134)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024pixelCircle\u00241([In] float obj0, [In] int obj1, [In] int obj2) => (double) Mathf.dst((float) obj1, (float) obj2, obj0, obj0) < (double) (obj0 - 0.5f);

    [LineNumberTable(11)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Geometry()
    {
    }

    [LineNumberTable(60)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Point2 d8(int i) => Geometry.__\u003C\u003Ed8[Mathf.mod(i, 8)];

    [Signature("(Larc/struct/Seq<Larc/math/geom/Vec2;>;)Larc/struct/FloatSeq;")]
    [LineNumberTable(new byte[] {39, 110, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static FloatSeq vectorsToFloats(Seq result)
    {
      FloatSeq floatSeq = new FloatSeq(result.size * 2);
      result.each((Cons) new Geometry.__\u003C\u003EAnon0(floatSeq));
      return floatSeq;
    }

    [LineNumberTable(new byte[] {160, 64, 105, 112, 105, 102, 123, 107, 237, 61, 230, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static float[] regPoly(int amount, float size)
    {
      float[] numArray = new float[amount * 2];
      Vec2 vec2 = new Vec2(1f, 1f);
      vec2.setLength(size);
      for (int index = 0; index < amount; ++index)
      {
        vec2.setAngle(360f / (float) amount * (float) index + 90f);
        numArray[index * 2] = vec2.x;
        numArray[index * 2 + 1] = vec2.y;
      }
      return numArray;
    }

    [LineNumberTable(new byte[] {160, 94, 103, 100, 134, 103, 100, 135, 102, 167, 235, 52, 230, 78})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void iteratePolySegments(float[] vertices, Floatc4 it)
    {
      for (int index = 0; index < vertices.Length; index += 2)
      {
        float vertex1 = vertices[index];
        float vertex2 = vertices[index + 1];
        float vertex3;
        float vertex4;
        if (index == vertices.Length - 2)
        {
          vertex3 = vertices[0];
          vertex4 = vertices[1];
        }
        else
        {
          vertex3 = vertices[index + 2];
          vertex4 = vertices[index + 3];
        }
        it.get(vertex1, vertex2, vertex3, vertex4);
      }
    }

    [LineNumberTable(new byte[] {160, 111, 103, 100, 102, 232, 61, 230, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void iteratePolygon(Floatc2 path, float[] vertices)
    {
      for (int index = 0; index < vertices.Length; index += 2)
      {
        float vertex1 = vertices[index];
        float vertex2 = vertices[index + 1];
        path.get(vertex1, vertex2);
      }
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Point2[] getD4Points() => Geometry.__\u003C\u003Ed4;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Point2[] getD8Points() => Geometry.__\u003C\u003Ed8;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Point2[] getD8EdgePoints() => Geometry.__\u003C\u003Ed8edge;

    [LineNumberTable(new byte[] {160, 131, 98, 98, 105, 137, 106, 138, 197, 109, 138, 102, 102, 102, 165, 101, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool raycast(int x0f, int y0f, int x1, int y1, Geometry.Raycaster cons)
    {
      int i1 = x0f;
      int i2 = y0f;
      int num1 = Math.abs(x1 - i1);
      int num2 = Math.abs(y1 - i2);
      int num3 = i1 >= x1 ? -1 : 1;
      int num4 = i2 >= y1 ? -1 : 1;
      int num5 = num1 - num2;
      while (!cons.accept(i1, i2))
      {
        if (i1 == x1 && i2 == y1)
          return false;
        int num6 = 2 * num5;
        if (num6 > -num2)
        {
          num5 -= num2;
          i1 += num3;
        }
        if (num6 < num1)
        {
          num5 += num1;
          i2 += num4;
        }
      }
      return true;
    }

    [LineNumberTable(new byte[] {161, 16, 114, 114, 114, 105, 106, 106, 106, 106, 111, 121, 120})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Vec2 toBarycoord(Vec2 p, Vec2 a, Vec2 b, Vec2 c, Vec2 barycentricOut)
    {
      Vec2 v1 = Geometry.tmp1.set(b).sub(a);
      Vec2 v2 = Geometry.tmp2.set(c).sub(a);
      Vec2 vec2 = Geometry.tmp3.set(p).sub(a);
      float num1 = v1.dot(v1);
      float num2 = v1.dot(v2);
      float num3 = v2.dot(v2);
      float num4 = vec2.dot(v1);
      float num5 = vec2.dot(v2);
      float num6 = num1 * num3 - num2 * num2;
      barycentricOut.x = (num3 * num4 - num2 * num5) / num6;
      barycentricOut.y = (num1 * num5 - num2 * num4) / num6;
      return barycentricOut;
    }

    [LineNumberTable(402)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool barycoordInsideTriangle(Vec2 barycentric) => (double) barycentric.x >= 0.0 && (double) barycentric.y >= 0.0 && (double) (barycentric.x + barycentric.y) <= 1.0;

    [LineNumberTable(new byte[] {161, 40, 118, 127, 17, 127, 17})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Vec2 fromBarycoord(
      Vec2 barycentric,
      Vec2 a,
      Vec2 b,
      Vec2 c,
      Vec2 interpolatedOut)
    {
      float num = 1f - barycentric.x - barycentric.y;
      interpolatedOut.x = num * a.x + barycentric.x * b.x + barycentric.y * c.x;
      interpolatedOut.y = num * a.y + barycentric.x * b.y + barycentric.y * c.y;
      return interpolatedOut;
    }

    [LineNumberTable(new byte[] {161, 51, 118})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static float fromBarycoord(Vec2 barycentric, float a, float b, float c) => (1f - barycentric.x - barycentric.y) * a + barycentric.x * b + barycentric.y * c;

    [LineNumberTable(new byte[] {161, 64, 118, 142, 106, 113, 106, 139, 101, 100, 99, 163, 106, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static float lowestPositiveRoot(float a, float b, float c)
    {
      float num1 = b * b - 4f * a * c;
      if ((double) num1 < 0.0)
        return float.NaN;
      float num2 = (float) Math.sqrt((double) num1);
      float num3 = 1f / (2f * a);
      float num4 = (-b - num2) * num3;
      float num5 = (-b + num2) * num3;
      if ((double) num4 > (double) num5)
      {
        float num6 = num5;
        num5 = num4;
        num4 = num6;
      }
      if ((double) num4 > 0.0)
        return num4;
      return (double) num5 > 0.0 ? num5 : float.NaN;
    }

    [LineNumberTable(new byte[] {161, 84, 110, 112, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool colinear(float x1, float y1, float x2, float y2, float x3, float y3)
    {
      float num1 = x2 - x1;
      float num2 = y2 - y1;
      float num3 = x3 - x2;
      float num4 = y3 - y2;
      return (double) Math.abs(num3 * num2 - num1 * num4) < 9.99999997475243E-07;
    }

    [LineNumberTable(new byte[] {161, 98, 110, 112, 114, 108, 111, 112, 107, 127, 21, 127, 26})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Vec2 triangleCircumcenter(
      float x1,
      float y1,
      float x2,
      float y2,
      float x3,
      float y3,
      Vec2 circumcenter)
    {
      float num1 = x2 - x1;
      float num2 = y2 - y1;
      float num3 = x3 - x2;
      float num4 = y3 - y2;
      float num5 = x1 - x3;
      float num6 = y1 - y3;
      float num7 = num3 * num2 - num1 * num4;
      if ((double) Math.abs(num7) < 9.99999997475243E-07)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException("Triangle points must not be colinear.");
      }
      float num8 = num7 * 2f;
      float num9 = x1 * x1 + y1 * y1;
      float num10 = x2 * x2 + y2 * y2;
      float num11 = x3 * x3 + y3 * y3;
      circumcenter.set((num9 * num4 + num10 * num6 + num11 * num2) / num8, -(num9 * num3 + num10 * num5 + num11 * num1) / num8);
      return circumcenter;
    }

    [LineNumberTable(new byte[] {161, 145, 119, 119, 123})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static float triangleQuality(
      float x1,
      float y1,
      float x2,
      float y2,
      float x3,
      float y3)
    {
      return Math.min((float) Math.sqrt((double) (x1 * x1 + y1 * y1)), Math.min((float) Math.sqrt((double) (x2 * x2 + y2 * y2)), (float) Math.sqrt((double) (x3 * x3 + y3 * y3)))) / Geometry.triangleCircumradius(x1, y1, x2, y2, x3, y3);
    }

    [LineNumberTable(522)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static float triangleArea(float x1, float y1, float x2, float y2, float x3, float y3) => Math.abs((x1 - x3) * (y2 - y1) - (x1 - x2) * (y3 - y1)) * 0.5f;

    [LineNumberTable(new byte[] {161, 157, 115, 115, 116, 116, 117, 117})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Vec2 quadrilateralCentroid(
      float x1,
      float y1,
      float x2,
      float y2,
      float x3,
      float y3,
      float x4,
      float y4,
      Vec2 centroid)
    {
      float num1 = (x1 + x2 + x3) / 3f;
      float num2 = (y1 + y2 + y3) / 3f;
      float num3 = (x1 + x4 + x3) / 3f;
      float num4 = (y1 + y4 + y3) / 3f;
      centroid.x = num1 - (num1 - num3) / 2f;
      centroid.y = num2 - (num2 - num4) / 2f;
      return centroid;
    }

    [LineNumberTable(new byte[] {161, 168, 116, 140, 102, 98, 111, 101, 103, 103, 103, 112, 102, 110, 238, 56, 233, 75, 101, 103, 101, 103, 112, 102, 110, 142, 104, 107, 141, 105, 113, 145})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Vec2 polygonCentroid(float[] polygon, int offset, int count, Vec2 centroid)
    {
      if (count < 6)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException("A polygon must have 3 or more coordinate pairs.");
      }
      float num1 = 0.0f;
      float num2 = 0.0f;
      float num3 = 0.0f;
      int index1 = offset;
      for (int index2 = offset + count - 2; index1 < index2; index1 += 2)
      {
        float num4 = polygon[index1];
        float num5 = polygon[index1 + 1];
        float num6 = polygon[index1 + 2];
        float num7 = polygon[index1 + 3];
        float num8 = num4 * num7 - num6 * num5;
        num3 += num8;
        num1 += (num4 + num6) * num8;
        num2 += (num5 + num7) * num8;
      }
      float num9 = polygon[index1];
      float num10 = polygon[index1 + 1];
      float num11 = polygon[offset];
      float num12 = polygon[offset + 1];
      float num13 = num9 * num12 - num11 * num10;
      float num14 = num3 + num13;
      float num15 = num1 + (num9 + num11) * num13;
      float num16 = num2 + (num10 + num12) * num13;
      if ((double) num14 == 0.0)
      {
        centroid.x = 0.0f;
        centroid.y = 0.0f;
      }
      else
      {
        float num4 = num14 * 0.5f;
        centroid.x = num15 / (6f * num4);
        centroid.y = num16 / (6f * num4);
      }
      return centroid;
    }

    [LineNumberTable(new byte[] {161, 206, 102, 109, 100, 112, 107, 112, 107, 109, 237, 57, 233, 73, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static float polygonArea(float[] polygon, int offset, int count)
    {
      float num1 = 0.0f;
      int index1 = offset;
      for (int index2 = offset + count; index1 < index2; index1 += 2)
      {
        int index3 = index1 + 1;
        int num2 = index1 + 2;
        int num3 = index2;
        int index4 = num3 != -1 ? num2 % num3 : 0;
        if (index4 < offset)
          index4 += offset;
        int num4 = index1 + 3;
        int num5 = index2;
        int index5 = num5 != -1 ? num4 % num5 : 0;
        if (index5 < offset)
          index5 += offset;
        num1 = num1 + polygon[index1] * polygon[index5] - polygon[index4] * polygon[index3];
      }
      return num1 * 0.5f;
    }

    [LineNumberTable(new byte[] {161, 221, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void ensureCCW(float[] polygon) => Geometry.ensureCCW(polygon, 0, polygon.Length);

    [LineNumberTable(new byte[] {159, 139, 109, 255, 20, 71, 255, 30, 71, 123, 123, 255, 60, 74, 255, 20, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static Geometry()
    {
      if (ByteCodeHelper.isAlreadyInited("arc.math.geom.Geometry"))
        return;
      Geometry.__\u003C\u003Ed4 = new Point2[4]
      {
        new Point2(1, 0),
        new Point2(0, 1),
        new Point2(-1, 0),
        new Point2(0, -1)
      };
      Geometry.__\u003C\u003Ed4c = new Point2[5]
      {
        new Point2(1, 0),
        new Point2(0, 1),
        new Point2(-1, 0),
        new Point2(0, -1),
        new Point2(0, 0)
      };
      Geometry.__\u003C\u003Ed4x = new int[4]
      {
        1,
        0,
        -1,
        0
      };
      Geometry.__\u003C\u003Ed4y = new int[4]
      {
        0,
        1,
        0,
        -1
      };
      Geometry.__\u003C\u003Ed8 = new Point2[8]
      {
        new Point2(1, 0),
        new Point2(1, 1),
        new Point2(0, 1),
        new Point2(-1, 1),
        new Point2(-1, 0),
        new Point2(-1, -1),
        new Point2(0, -1),
        new Point2(1, -1)
      };
      Geometry.__\u003C\u003Ed8edge = new Point2[4]
      {
        new Point2(1, 1),
        new Point2(-1, 1),
        new Point2(-1, -1),
        new Point2(1, -1)
      };
      Geometry.tmp1 = new Vec2();
      Geometry.tmp2 = new Vec2();
      Geometry.tmp3 = new Vec2();
    }

    [Modifiers]
    public static Point2[] d4
    {
      [HideFromJava] get => Geometry.__\u003C\u003Ed4;
    }

    [Modifiers]
    public static Point2[] d4c
    {
      [HideFromJava] get => Geometry.__\u003C\u003Ed4c;
    }

    [Modifiers]
    public static int[] d4x
    {
      [HideFromJava] get => Geometry.__\u003C\u003Ed4x;
    }

    [Modifiers]
    public static int[] d4y
    {
      [HideFromJava] get => Geometry.__\u003C\u003Ed4y;
    }

    [Modifiers]
    public static Point2[] d8
    {
      [HideFromJava] get => Geometry.__\u003C\u003Ed8;
    }

    [Modifiers]
    public static Point2[] d8edge
    {
      [HideFromJava] get => Geometry.__\u003C\u003Ed8edge;
    }

    public interface Raycaster
    {
      bool accept(int i1, int i2);
    }

    public interface SolidChecker
    {
      bool solid(float f, int i1, int i2);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Cons
    {
      private readonly FloatSeq arg\u00241;

      internal __\u003C\u003EAnon0([In] FloatSeq obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => Geometry.lambda\u0024vectorsToFloats\u00240(this.arg\u00241, (Vec2) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Geometry.SolidChecker
    {
      internal __\u003C\u003EAnon1()
      {
      }

      public bool solid([In] float obj0, [In] int obj1, [In] int obj2) => (Geometry.lambda\u0024pixelCircle\u00241(obj0, obj1, obj2) ? 1 : 0) != 0;
    }
  }
}
