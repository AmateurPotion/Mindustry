// Decompiled with JetBrains decompiler
// Type: arc.math.geom.Intersector
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.math.geom
{
  public sealed class Intersector : Object
  {
    [Modifiers]
    private static Vec3 v0;
    [Modifiers]
    private static Vec3 v1;
    [Modifiers]
    private static Vec3 v2;
    [Modifiers]
    private static FloatSeq floatArray;
    [Modifiers]
    private static FloatSeq floatArray2;
    [Modifiers]
    private static Vec2 ip;
    [Modifiers]
    private static Vec2 ep1;
    [Modifiers]
    private static Vec2 ep2;
    [Modifiers]
    private static Vec2 s;
    [Modifiers]
    private static Vec2 e;
    [Modifiers]
    private static Vec3 i;
    [Modifiers]
    private static Vec3 dir;
    [Modifiers]
    private static Vec3 start;
    internal static Vec3 best;
    internal static Vec3 tmp;
    internal static Vec3 tmp1;
    internal static Vec3 tmp2;
    internal static Vec3 tmp3;
    internal static Vec2 v2tmp;
    internal static Vec3 intersection;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {59, 113, 114, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool isInsideHexagon(float cx, float cy, float d, float x, float y)
    {
      float num1 = Math.abs(x - cx) / d;
      float num2 = Math.abs(y - cy) / d;
      float num3 = 0.25f * Mathf.__\u003C\u003Esqrt3;
      return (double) num2 <= (double) num3 && (double) (num3 * num1) + 0.25 * (double) num2 <= 0.5 * (double) num3;
    }

    [LineNumberTable(new byte[] {161, 222, 103, 135, 110, 105, 118, 175, 110, 105, 118, 175, 106, 101, 106, 133})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool overlaps(Circle c, Rect r)
    {
      float num1 = c.x;
      float num2 = c.y;
      if ((double) c.x < (double) r.x)
        num1 = r.x;
      else if ((double) c.x > (double) (r.x + r.width))
        num1 = r.x + r.width;
      if ((double) c.y < (double) r.y)
        num2 = r.y;
      else if ((double) c.y > (double) (r.y + r.height))
        num2 = r.y + r.height;
      float num3 = num1 - c.x;
      float num4 = num3 * num3;
      float num5 = num2 - c.y;
      float num6 = num5 * num5;
      return (double) (num4 + num6) < (double) (c.radius * c.radius);
    }

    [LineNumberTable(258)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static float distanceLinePoint(Vec2 start, Vec2 end, Vec2 point) => Intersector.distanceLinePoint(start.x, start.y, end.x, end.y, point.x, point.y);

    [LineNumberTable(492)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool intersectSegmentRectangle(Vec2 start, Vec2 end, Rect rect) => Intersector.intersectSegmentRectangle(start.x, start.y, end.x, end.y, rect);

    [LineNumberTable(new byte[] {161, 80, 108, 120, 127, 17, 120, 127, 17, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool intersectRectangles(Rect rect1, Rect rect2, Rect intersection)
    {
      if (!rect1.overlaps(rect2))
        return false;
      intersection.x = Math.max(rect1.x, rect2.x);
      intersection.width = Math.min(rect1.x + rect1.width, rect2.x + rect2.width) - intersection.x;
      intersection.y = Math.max(rect1.y, rect2.y);
      intersection.height = Math.min(rect1.y + rect1.height, rect2.y + rect2.height) - intersection.y;
      return true;
    }

    [LineNumberTable(new byte[] {126, 98, 102, 107, 103, 103, 124, 101, 159, 9, 226, 57, 233, 73})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool isInPolygon(float[] polygon, int offset, int count, float x, float y)
    {
      int num1 = 0;
      int index1 = offset + count - 2;
      int index2 = offset;
      for (int index3 = index1; index2 <= index3; index2 += 2)
      {
        float num2 = polygon[index2 + 1];
        float num3 = polygon[index1 + 1];
        if ((double) num2 < (double) y && (double) num3 >= (double) y || (double) num3 < (double) y && (double) num2 >= (double) y)
        {
          float num4 = polygon[index2];
          if ((double) (num4 + (y - num2) / (num3 - num2) * (polygon[index1] - num4)) < (double) x)
            num1 = num1 != 0 ? 0 : 1;
        }
        index1 = index2;
      }
      return num1 != 0;
    }

    [LineNumberTable(139)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int pointLineSide(Vec2 linePoint1, Vec2 linePoint2, Vec2 point) => ByteCodeHelper.f2i(Math.signum((linePoint2.x - linePoint1.x) * (point.y - linePoint1.y) - (linePoint2.y - linePoint1.y) * (point.x - linePoint1.x)));

    [LineNumberTable(new byte[] {161, 17, 159, 29, 124, 139, 100, 127, 3, 158})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool intersectLines(Vec2 p1, Vec2 p2, Vec2 p3, Vec2 p4, Vec2 intersection)
    {
      float x1 = p1.x;
      float y1 = p1.y;
      float x2 = p2.x;
      float y2 = p2.y;
      float x3 = p3.x;
      float y3 = p3.y;
      float x4 = p4.x;
      float y4 = p4.y;
      float num1 = (y4 - y3) * (x2 - x1) - (x4 - x3) * (y2 - y1);
      if ((double) num1 == 0.0)
        return false;
      if (intersection != null)
      {
        float num2 = ((x4 - x3) * (y1 - y3) - (y4 - y3) * (x1 - x3)) / num1;
        intersection.set(x1 + (x2 - x1) * num2, y1 + (y2 - y1) * num2);
      }
      return true;
    }

    [LineNumberTable(new byte[] {160, 149, 127, 8})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static float distanceLinePoint(
      float startX,
      float startY,
      float endX,
      float endY,
      float pointX,
      float pointY)
    {
      float num = (float) Math.sqrt((double) ((endX - startX) * (endX - startX) + (endY - startY) * (endY - startY)));
      return Math.abs((pointX - startX) * (endY - startY) - (pointY - startY) * (endX - startX)) / num;
    }

    [LineNumberTable(new byte[] {160, 176, 103, 103, 107, 116, 127, 5, 116, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Vec2 nearestSegmentPoint(
      float startX,
      float startY,
      float endX,
      float endY,
      float pointX,
      float pointY,
      Vec2 nearest)
    {
      float num1 = endX - startX;
      float num2 = endY - startY;
      float num3 = num1 * num1 + num2 * num2;
      if ((double) num3 == 0.0)
        return nearest.set(startX, startY);
      float num4 = ((pointX - startX) * (endX - startX) + (pointY - startY) * (endY - startY)) / num3;
      if ((double) num4 < 0.0)
        return nearest.set(startX, startY);
      return (double) num4 > 1.0 ? nearest.set(endX, endY) : nearest.set(startX + num4 * (endX - startX), startY + num4 * (endY - startY));
    }

    [LineNumberTable(new byte[] {160, 165, 105, 112, 127, 35, 112, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Vec2 nearestSegmentPoint(Vec2 start, Vec2 end, Vec2 point, Vec2 nearest)
    {
      float num1 = start.dst2(end);
      if ((double) num1 == 0.0)
        return nearest.set(start);
      float num2 = ((point.x - start.x) * (end.x - start.x) + (point.y - start.y) * (end.y - start.y)) / num1;
      if ((double) num2 < 0.0)
        return nearest.set(start);
      return (double) num2 > 1.0 ? nearest.set(end) : nearest.set(start.x + num2 * (end.x - start.x), start.y + num2 * (end.y - start.y));
    }

    [LineNumberTable(new byte[] {161, 186, 127, 4, 138, 104, 104, 124, 146, 121, 148, 127, 7})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool intersectSegments(
      float x1,
      float y1,
      float x2,
      float y2,
      float x3,
      float y3,
      float x4,
      float y4,
      Vec2 intersection)
    {
      float num1 = (y4 - y3) * (x2 - x1) - (x4 - x3) * (y2 - y1);
      if ((double) num1 == 0.0)
        return false;
      float num2 = y1 - y3;
      float num3 = x1 - x3;
      float num4 = ((x4 - x3) * num2 - (y4 - y3) * num3) / num1;
      if ((double) num4 < 0.0 || (double) num4 > 1.0)
        return false;
      float num5 = ((x2 - x1) * num2 - (y2 - y1) * num3) / num1;
      if ((double) num5 < 0.0 || (double) num5 > 1.0)
        return false;
      intersection?.set(x1 + (x2 - x1) * num4, y1 + (y2 - y1) * num4);
      return true;
    }

    [LineNumberTable(new byte[] {161, 100, 113, 145, 127, 7, 130, 127, 7, 130, 122, 130, 122, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool intersectSegmentRectangle(
      float startX,
      float startY,
      float endX,
      float endY,
      Rect rect)
    {
      float num1 = rect.x + rect.width;
      float num2 = rect.y + rect.height;
      return Intersector.intersectSegments(startX, startY, endX, endY, rect.x, rect.y, rect.x, num2, (Vec2) null) || Intersector.intersectSegments(startX, startY, endX, endY, rect.x, rect.y, num1, rect.y, (Vec2) null) || (Intersector.intersectSegments(startX, startY, endX, endY, num1, rect.y, num1, num2, (Vec2) null) || Intersector.intersectSegments(startX, startY, endX, endY, rect.x, num2, num1, num2, (Vec2) null)) || rect.contains(startX, startY);
    }

    [LineNumberTable(634)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool overlapConvexPolygons(
      Polygon p1,
      Polygon p2,
      Intersector.MinimumTranslationVector mtv)
    {
      return Intersector.overlapConvexPolygons(p1.getTransformedVertices(), p2.getTransformedVertices(), mtv);
    }

    [LineNumberTable(639)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool overlapConvexPolygons(
      float[] verts1,
      float[] verts2,
      Intersector.MinimumTranslationVector mtv)
    {
      return Intersector.overlapConvexPolygons(verts1, 0, verts1.Length, verts2, 0, verts2.Length, mtv);
    }

    [LineNumberTable(new byte[] {162, 27, 102, 102, 166, 100, 167, 107, 102, 104, 115, 147, 104, 137, 120, 104, 232, 69, 114, 100, 104, 118, 102, 102, 102, 228, 59, 232, 74, 99, 114, 100, 141, 124, 118, 102, 102, 102, 228, 57, 235, 75, 120, 130, 120, 120, 110, 110, 102, 138, 168, 101, 131, 109, 237, 5, 235, 160, 66, 109, 102, 104, 116, 148, 104, 137, 120, 104, 168, 163, 114, 100, 107, 150, 124, 102, 102, 102, 228, 57, 235, 76, 114, 100, 106, 118, 102, 102, 102, 228, 59, 232, 73, 120, 130, 152, 120, 110, 110, 102, 138, 200, 101, 131, 109, 237, 3, 235, 160, 66, 100, 111, 136})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool overlapConvexPolygons(
      float[] verts1,
      int offset1,
      int count1,
      float[] verts2,
      int offset2,
      int count2,
      Intersector.MinimumTranslationVector mtv)
    {
      float num1 = float.MaxValue;
      float x = 0.0f;
      float y = 0.0f;
      int num2 = offset1 + count1;
      int num3 = offset2 + count2;
      for (int index1 = offset1; index1 < num2; index1 += 2)
      {
        float linePoint1X = verts1[index1];
        float linePoint1Y = verts1[index1 + 1];
        float[] numArray1 = verts1;
        int num4 = index1 + 2;
        int num5 = count1;
        int index2 = num5 != -1 ? num4 % num5 : 0;
        float linePoint2X = numArray1[index2];
        float[] numArray2 = verts1;
        int num6 = index1 + 3;
        int num7 = count1;
        int index3 = num7 != -1 ? num6 % num7 : 0;
        float linePoint2Y = numArray2[index3];
        float num8 = linePoint1Y - linePoint2Y;
        float num9 = -(linePoint1X - linePoint2X);
        float num10 = (float) Math.sqrt((double) (num8 * num8 + num9 * num9));
        float num11 = num8 / num10;
        float num12 = num9 / num10;
        float num13 = num11 * verts1[0] + num12 * verts1[1];
        float num14 = num13;
        for (int index4 = offset1; index4 < num2; index4 += 2)
        {
          float num15 = num11 * verts1[index4] + num12 * verts1[index4 + 1];
          if ((double) num15 < (double) num13)
            num13 = num15;
          else if ((double) num15 > (double) num14)
            num14 = num15;
        }
        int num16 = 0;
        float num17 = num11 * verts2[0] + num12 * verts2[1];
        float num18 = num17;
        for (int index4 = offset2; index4 < num3; index4 += 2)
        {
          num16 -= Intersector.pointLineSide(linePoint1X, linePoint1Y, linePoint2X, linePoint2Y, verts2[index4], verts2[index4 + 1]);
          float num15 = num11 * verts2[index4] + num12 * verts2[index4 + 1];
          if ((double) num15 < (double) num17)
            num17 = num15;
          else if ((double) num15 > (double) num18)
            num18 = num15;
        }
        if (((double) num13 > (double) num17 || (double) num14 < (double) num17) && ((double) num17 > (double) num13 || (double) num18 < (double) num13))
          return false;
        float num19 = Math.min(num14, num18) - Math.max(num13, num17);
        if ((double) num13 < (double) num17 && (double) num14 > (double) num18 || (double) num17 < (double) num13 && (double) num18 > (double) num14)
        {
          float num15 = Math.abs(num13 - num17);
          float num20 = Math.abs(num14 - num18);
          if ((double) num15 < (double) num20)
            num19 += num15;
          else
            num19 += num20;
        }
        if ((double) num19 < (double) num1)
        {
          num1 = num19;
          x = num16 < 0 ? -num11 : num11;
          y = num16 < 0 ? -num12 : num12;
        }
      }
      for (int index1 = offset2; index1 < num3; index1 += 2)
      {
        float linePoint1X = verts2[index1];
        float linePoint1Y = verts2[index1 + 1];
        float[] numArray1 = verts2;
        int num4 = index1 + 2;
        int num5 = count2;
        int index2 = num5 != -1 ? num4 % num5 : 0;
        float linePoint2X = numArray1[index2];
        float[] numArray2 = verts2;
        int num6 = index1 + 3;
        int num7 = count2;
        int index3 = num7 != -1 ? num6 % num7 : 0;
        float linePoint2Y = numArray2[index3];
        float num8 = linePoint1Y - linePoint2Y;
        float num9 = -(linePoint1X - linePoint2X);
        float num10 = (float) Math.sqrt((double) (num8 * num8 + num9 * num9));
        float num11 = num8 / num10;
        float num12 = num9 / num10;
        int num13 = 0;
        float num14 = num11 * verts1[0] + num12 * verts1[1];
        float num15 = num14;
        for (int index4 = offset1; index4 < num2; index4 += 2)
        {
          float num16 = num11 * verts1[index4] + num12 * verts1[index4 + 1];
          num13 -= Intersector.pointLineSide(linePoint1X, linePoint1Y, linePoint2X, linePoint2Y, verts1[index4], verts1[index4 + 1]);
          if ((double) num16 < (double) num14)
            num14 = num16;
          else if ((double) num16 > (double) num15)
            num15 = num16;
        }
        float num17 = num11 * verts2[0] + num12 * verts2[1];
        float num18 = num17;
        for (int index4 = offset2; index4 < num3; index4 += 2)
        {
          float num16 = num11 * verts2[index4] + num12 * verts2[index4 + 1];
          if ((double) num16 < (double) num17)
            num17 = num16;
          else if ((double) num16 > (double) num18)
            num18 = num16;
        }
        if (((double) num14 > (double) num17 || (double) num15 < (double) num17) && ((double) num17 > (double) num14 || (double) num18 < (double) num14))
          return false;
        float num19 = Math.min(num15, num18) - Math.max(num14, num17);
        if ((double) num14 < (double) num17 && (double) num15 > (double) num18 || (double) num17 < (double) num14 && (double) num18 > (double) num15)
        {
          float num16 = Math.abs(num14 - num17);
          float num20 = Math.abs(num15 - num18);
          if ((double) num16 < (double) num20)
            num19 += num16;
          else
            num19 += num20;
        }
        if ((double) num19 < (double) num1)
        {
          num1 = num19;
          x = num13 >= 0 ? -num11 : num11;
          y = num13 >= 0 ? -num12 : num12;
        }
      }
      if (mtv != null)
      {
        mtv.normal.set(x, y);
        mtv.depth = num1;
      }
      return true;
    }

    [LineNumberTable(new byte[] {95, 127, 1, 43})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int pointLineSide(
      float linePoint1X,
      float linePoint1Y,
      float linePoint2X,
      float linePoint2Y,
      float pointX,
      float pointY)
    {
      return ByteCodeHelper.f2i(Math.signum((linePoint2X - linePoint1X) * (pointY - linePoint1Y) - (linePoint2Y - linePoint1Y) * (pointX - linePoint1X)));
    }

    [LineNumberTable(12)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Intersector()
    {
    }

    [LineNumberTable(new byte[] {159, 178, 106, 106, 107, 104, 130, 106, 147, 103, 151, 145, 108, 130, 127, 26, 114, 159, 6, 122, 122, 127, 0, 127, 34, 114, 116, 180, 116, 118, 119, 127, 0, 116, 148, 255, 0, 45, 233, 85, 106, 111, 234, 29, 233, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool intersectPolygons(float[] p1, float[] p2)
    {
      Intersector.floatArray2.clear();
      Intersector.floatArray.clear();
      Intersector.floatArray2.addAll(p1);
      if (p1.Length == 0 || p2.Length == 0)
        return false;
      for (int index1 = 0; index1 < p2.Length; index1 += 2)
      {
        Intersector.ep1.set(p2[index1], p2[index1 + 1]);
        if (index1 < p2.Length - 2)
          Intersector.ep2.set(p2[index1 + 2], p2[index1 + 3]);
        else
          Intersector.ep2.set(p2[0], p2[1]);
        if (Intersector.floatArray2.size == 0)
          return false;
        Intersector.s.set(Intersector.floatArray2.get(Intersector.floatArray2.size - 2), Intersector.floatArray2.get(Intersector.floatArray2.size - 1));
        for (int index2 = 0; index2 < Intersector.floatArray2.size; index2 += 2)
        {
          Intersector.e.set(Intersector.floatArray2.get(index2), Intersector.floatArray2.get(index2 + 1));
          if (Intersector.pointLineSide(Intersector.ep2, Intersector.ep1, Intersector.e) > 0)
          {
            if (Intersector.pointLineSide(Intersector.ep2, Intersector.ep1, Intersector.s) <= 0)
            {
              Intersector.intersectLines(Intersector.s, Intersector.e, Intersector.ep1, Intersector.ep2, Intersector.ip);
              if (Intersector.floatArray.size < 2 || (double) Intersector.floatArray.get(Intersector.floatArray.size - 2) != (double) Intersector.ip.x || (double) Intersector.floatArray.get(Intersector.floatArray.size - 1) != (double) Intersector.ip.y)
              {
                Intersector.floatArray.add(Intersector.ip.x);
                Intersector.floatArray.add(Intersector.ip.y);
              }
            }
            Intersector.floatArray.add(Intersector.e.x);
            Intersector.floatArray.add(Intersector.e.y);
          }
          else if (Intersector.pointLineSide(Intersector.ep2, Intersector.ep1, Intersector.s) > 0)
          {
            Intersector.intersectLines(Intersector.s, Intersector.e, Intersector.ep1, Intersector.ep2, Intersector.ip);
            Intersector.floatArray.add(Intersector.ip.x);
            Intersector.floatArray.add(Intersector.ip.y);
          }
          Intersector.s.set(Intersector.e.x, Intersector.e.y);
        }
        Intersector.floatArray2.clear();
        Intersector.floatArray2.addAll(Intersector.floatArray);
        Intersector.floatArray.clear();
      }
      return Intersector.floatArray2.size != 0;
    }

    [LineNumberTable(new byte[] {43, 114, 114, 146, 113, 113, 113, 145, 115, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool isInTriangle(Vec3 point, Vec3 t1, Vec3 t2, Vec3 t3)
    {
      Intersector.v0.set(t1).sub(point);
      Intersector.v1.set(t2).sub(point);
      Intersector.v2.set(t3).sub(point);
      float num1 = Intersector.v0.dot(Intersector.v1);
      float num2 = Intersector.v0.dot(Intersector.v2);
      float num3 = Intersector.v1.dot(Intersector.v2);
      float num4 = Intersector.v2.dot(Intersector.v2);
      if ((double) (num3 * num2 - num4 * num1) < 0.0)
        return false;
      float num5 = Intersector.v1.dot(Intersector.v1);
      return (double) (num1 * num3 - num2 * num5) >= 0.0;
    }

    [LineNumberTable(new byte[] {67, 111, 111, 127, 13, 127, 17})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool isInTriangle(Vec2 p, Vec2 a, Vec2 b, Vec2 c)
    {
      float num1 = p.x - a.x;
      float num2 = p.y - a.y;
      int num3 = (double) ((b.x - a.x) * num2 - (b.y - a.y) * num1) > 0.0 ? 1 : 0;
      return ((double) ((c.x - a.x) * num2 - (c.y - a.y) * num1) > 0.0 ? 1 : 0) != num3 && ((double) ((c.x - b.x) * (p.y - b.y) - (c.y - b.y) * (p.x - b.x)) > 0.0 ? 1 : 0) == num3;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool isInTriangle(
      float px,
      float py,
      float ax,
      float ay,
      float bx,
      float by,
      float cx,
      float cy)
    {
      float num1 = px - ax;
      float num2 = py - ay;
      int num3 = (double) ((bx - ax) * num2 - (by - ay) * num1) > 0.0 ? 1 : 0;
      return ((double) ((cx - ax) * num2 - (cy - ay) * num1) > 0.0 ? 1 : 0) != num3 && ((double) ((cx - bx) * (py - by) - (cy - by) * (px - bx)) > 0.0 ? 1 : 0) == num3;
    }

    [Signature("(Larc/struct/Seq<Larc/math/geom/Vec2;>;Larc/math/geom/Vec2;)Z")]
    [LineNumberTable(new byte[] {106, 108, 98, 110, 109, 127, 25, 127, 31, 168, 226, 57, 233, 73})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool isInPolygon(Seq polygon, Vec2 point)
    {
      Vec2 vec2_1 = (Vec2) polygon.peek();
      int num = 0;
      for (int index = 0; index < polygon.size; ++index)
      {
        Vec2 vec2_2 = (Vec2) polygon.get(index);
        if (((double) vec2_2.y < (double) point.y && (double) vec2_1.y >= (double) point.y || (double) vec2_1.y < (double) point.y && (double) vec2_2.y >= (double) point.y) && (double) (vec2_2.x + (point.y - vec2_2.y) / (vec2_1.y - vec2_2.y) * (vec2_1.x - vec2_2.x)) < (double) point.x)
          num = num != 0 ? 0 : 1;
        vec2_1 = vec2_2;
      }
      return num != 0;
    }

    [LineNumberTable(new byte[] {160, 85, 114, 162, 106, 106, 112, 111, 157, 108, 159, 2, 155, 108, 130, 127, 26, 114, 159, 6, 122, 122, 127, 0, 127, 34, 114, 116, 180, 116, 118, 119, 127, 0, 116, 148, 255, 0, 45, 233, 85, 106, 111, 234, 29, 233, 101, 108, 99, 115, 159, 4, 144, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool intersectPolygons(Polygon p1, Polygon p2, Polygon overlap)
    {
      if (p1.getVertices().Length == 0 || p2.getVertices().Length == 0)
        return false;
      Intersector.floatArray2.clear();
      Intersector.floatArray.clear();
      Intersector.floatArray2.addAll(p1.getTransformedVertices());
      for (int index1 = 0; index1 < p2.getTransformedVertices().Length; index1 += 2)
      {
        Intersector.ep1.set(p2.getTransformedVertices()[index1], p2.getTransformedVertices()[index1 + 1]);
        if (index1 < p2.getTransformedVertices().Length - 2)
          Intersector.ep2.set(p2.getTransformedVertices()[index1 + 2], p2.getTransformedVertices()[index1 + 3]);
        else
          Intersector.ep2.set(p2.getTransformedVertices()[0], p2.getTransformedVertices()[1]);
        if (Intersector.floatArray2.size == 0)
          return false;
        Intersector.s.set(Intersector.floatArray2.get(Intersector.floatArray2.size - 2), Intersector.floatArray2.get(Intersector.floatArray2.size - 1));
        for (int index2 = 0; index2 < Intersector.floatArray2.size; index2 += 2)
        {
          Intersector.e.set(Intersector.floatArray2.get(index2), Intersector.floatArray2.get(index2 + 1));
          if (Intersector.pointLineSide(Intersector.ep2, Intersector.ep1, Intersector.e) > 0)
          {
            if (Intersector.pointLineSide(Intersector.ep2, Intersector.ep1, Intersector.s) <= 0)
            {
              Intersector.intersectLines(Intersector.s, Intersector.e, Intersector.ep1, Intersector.ep2, Intersector.ip);
              if (Intersector.floatArray.size < 2 || (double) Intersector.floatArray.get(Intersector.floatArray.size - 2) != (double) Intersector.ip.x || (double) Intersector.floatArray.get(Intersector.floatArray.size - 1) != (double) Intersector.ip.y)
              {
                Intersector.floatArray.add(Intersector.ip.x);
                Intersector.floatArray.add(Intersector.ip.y);
              }
            }
            Intersector.floatArray.add(Intersector.e.x);
            Intersector.floatArray.add(Intersector.e.y);
          }
          else if (Intersector.pointLineSide(Intersector.ep2, Intersector.ep1, Intersector.s) > 0)
          {
            Intersector.intersectLines(Intersector.s, Intersector.e, Intersector.ep1, Intersector.ep2, Intersector.ip);
            Intersector.floatArray.add(Intersector.ip.x);
            Intersector.floatArray.add(Intersector.ip.y);
          }
          Intersector.s.set(Intersector.e.x, Intersector.e.y);
        }
        Intersector.floatArray2.clear();
        Intersector.floatArray2.addAll(Intersector.floatArray);
        Intersector.floatArray.clear();
      }
      if (Intersector.floatArray2.size == 0)
        return false;
      if (overlap != null)
      {
        if (overlap.getVertices().Length == Intersector.floatArray2.size)
          ByteCodeHelper.arraycopy_primitive_4((Array) Intersector.floatArray2.items, 0, (Array) overlap.getVertices(), 0, Intersector.floatArray2.size);
        else
          overlap.setVertices(Intersector.floatArray2.toArray());
      }
      return true;
    }

    [LineNumberTable(269)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static float distanceSegmentPoint(
      float startX,
      float startY,
      float endX,
      float endY,
      float pointX,
      float pointY)
    {
      return Intersector.nearestSegmentPoint(startX, startY, endX, endY, pointX, pointY, Intersector.v2tmp).dst(pointX, pointY);
    }

    [LineNumberTable(274)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static float distanceSegmentPoint(Vec2 start, Vec2 end, Vec2 point) => Intersector.nearestSegmentPoint(start, end, point, Intersector.v2tmp).dst(point);

    [LineNumberTable(new byte[] {160, 195, 127, 13, 127, 13, 108, 118, 104, 126, 100, 158, 118, 191, 21, 115, 147})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool intersectSegmentCircle(
      Vec2 start,
      Vec2 end,
      Vec2 center,
      float squareRadius)
    {
      Intersector.tmp.set(end.x - start.x, end.y - start.y, 0.0f);
      Intersector.tmp1.set(center.x - start.x, center.y - start.y, 0.0f);
      float num1 = Intersector.tmp.len();
      float scalar = Intersector.tmp1.dot(Intersector.tmp.nor());
      if ((double) scalar <= 0.0)
        Intersector.tmp2.set(start.x, start.y, 0.0f);
      else if ((double) scalar >= (double) num1)
      {
        Intersector.tmp2.set(end.x, end.y, 0.0f);
      }
      else
      {
        Intersector.tmp3.set(Intersector.tmp.scl(scalar));
        Intersector.tmp2.set(Intersector.tmp3.x + start.x, Intersector.tmp3.y + start.y, 0.0f);
      }
      float num2 = center.x - Intersector.tmp2.x;
      float num3 = center.y - Intersector.tmp2.y;
      return (double) (num2 * num2 + num3 * num3) <= (double) squareRadius;
    }

    [LineNumberTable(new byte[] {160, 226, 127, 32, 105, 104, 118, 127, 19, 127, 13, 125, 101, 127, 8, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static float intersectSegmentCircleDisplace(
      Vec2 start,
      Vec2 end,
      Vec2 point,
      float radius,
      Vec2 displacement)
    {
      float num1 = (point.x - start.x) * (end.x - start.x) + (point.y - start.y) * (end.y - start.y);
      float num2 = start.dst(end);
      float scalar = num1 / (num2 * num2);
      if ((double) scalar < 0.0 || (double) scalar > 1.0)
        return float.PositiveInfinity;
      Intersector.tmp.set(end.x, end.y, 0.0f).sub(start.x, start.y, 0.0f);
      Intersector.tmp2.set(start.x, start.y, 0.0f).add(Intersector.tmp.scl(scalar));
      float num3 = Intersector.tmp2.dst(point.x, point.y, 0.0f);
      if ((double) num3 >= (double) radius)
        return float.PositiveInfinity;
      displacement.set(point).sub(Intersector.tmp2.x, Intersector.tmp2.y).nor();
      return num3;
    }

    [LineNumberTable(new byte[] {160, 252, 111, 111, 127, 0, 104, 134, 106, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static float intersectRayRay(
      Vec2 start1,
      Vec2 direction1,
      Vec2 start2,
      Vec2 direction2)
    {
      float num1 = start2.x - start1.x;
      float num2 = start2.y - start1.y;
      float num3 = direction1.x * direction2.y - direction1.y * direction2.x;
      if ((double) num3 == 0.0)
        return float.PositiveInfinity;
      float num4 = direction2.x / num3;
      float num5 = direction2.y / num3;
      return num1 * num5 - num2 * num4;
    }

    [LineNumberTable(new byte[] {161, 35, 127, 4, 138, 100, 127, 9, 159, 3})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool intersectLines(
      float x1,
      float y1,
      float x2,
      float y2,
      float x3,
      float y3,
      float x4,
      float y4,
      Vec2 intersection)
    {
      float num1 = (y4 - y3) * (x2 - x1) - (x4 - x3) * (y2 - y1);
      if ((double) num1 == 0.0)
        return false;
      if (intersection != null)
      {
        float num2 = ((x4 - x3) * (y1 - y3) - (y4 - y3) * (x1 - x3)) / num1;
        intersection.set(x1 + (x2 - x1) * num2, y1 + (y2 - y1) * num2);
      }
      return true;
    }

    [LineNumberTable(new byte[] {161, 53, 103, 125, 100, 112, 108, 110, 125, 105, 103, 103, 124, 114, 162, 100, 228, 52, 235, 78})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool intersectLinePolygon(Vec2 p1, Vec2 p2, Polygon polygon)
    {
      float[] transformedVertices = polygon.getTransformedVertices();
      float x1 = p1.x;
      float y1 = p1.y;
      float x2 = p2.x;
      float y2 = p2.y;
      int length = transformedVertices.Length;
      float num1 = transformedVertices[length - 2];
      float num2 = transformedVertices[length - 1];
      for (int index = 0; index < length; index += 2)
      {
        float num3 = transformedVertices[index];
        float num4 = transformedVertices[index + 1];
        float num5 = (num4 - num2) * (x2 - x1) - (num3 - num1) * (y2 - y1);
        if ((double) num5 != 0.0)
        {
          float num6 = y1 - num2;
          float num7 = x1 - num1;
          float num8 = ((num3 - num1) * num6 - (num4 - num2) * num7) / num5;
          if ((double) num8 >= 0.0 && (double) num8 <= 1.0)
            return true;
        }
        num1 = num3;
        num2 = num4;
      }
      return false;
    }

    [LineNumberTable(new byte[] {161, 132, 103, 125, 100, 112, 108, 110, 125, 108, 103, 103, 124, 114, 121, 114, 194, 100, 228, 49, 235, 81})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool intersectSegmentPolygon(Vec2 p1, Vec2 p2, Polygon polygon)
    {
      float[] transformedVertices = polygon.getTransformedVertices();
      float x1 = p1.x;
      float y1 = p1.y;
      float x2 = p2.x;
      float y2 = p2.y;
      int length = transformedVertices.Length;
      float num1 = transformedVertices[length - 2];
      float num2 = transformedVertices[length - 1];
      for (int index = 0; index < length; index += 2)
      {
        float num3 = transformedVertices[index];
        float num4 = transformedVertices[index + 1];
        float num5 = (num4 - num2) * (x2 - x1) - (num3 - num1) * (y2 - y1);
        if ((double) num5 != 0.0)
        {
          float num6 = y1 - num2;
          float num7 = x1 - num1;
          float num8 = ((num3 - num1) * num6 - (num4 - num2) * num7) / num5;
          if ((double) num8 >= 0.0 && (double) num8 <= 1.0)
          {
            float num9 = ((x2 - x1) * num6 - (y2 - y1) * num7) / num5;
            if ((double) num9 >= 0.0 && (double) num9 <= 1.0)
              return true;
          }
        }
        num1 = num3;
        num2 = num4;
      }
      return false;
    }

    [LineNumberTable(new byte[] {161, 166, 159, 29, 124, 139, 103, 103, 124, 148, 120, 148, 127, 3})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool intersectSegments(Vec2 p1, Vec2 p2, Vec2 p3, Vec2 p4, Vec2 intersection)
    {
      float x1 = p1.x;
      float y1 = p1.y;
      float x2 = p2.x;
      float y2 = p2.y;
      float x3 = p3.x;
      float y3 = p3.y;
      float x4 = p4.x;
      float y4 = p4.y;
      float num1 = (y4 - y3) * (x2 - x1) - (x4 - x3) * (y2 - y1);
      if ((double) num1 == 0.0)
        return false;
      float num2 = y1 - y3;
      float num3 = x1 - x3;
      float num4 = ((x4 - x3) * num2 - (y4 - y3) * num3) / num1;
      if ((double) num4 < 0.0 || (double) num4 > 1.0)
        return false;
      float num5 = ((x2 - x1) * num2 - (y2 - y1) * num3) / num1;
      if ((double) num5 < 0.0 || (double) num5 > 1.0)
        return false;
      intersection?.set(x1 + (x2 - x1) * num4, y1 + (y2 - y1) * num4);
      return true;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static float det([In] float obj0, [In] float obj1, [In] float obj2, [In] float obj3) => obj0 * obj3 - obj1 * obj2;

    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static double detd([In] double obj0, [In] double obj1, [In] double obj2, [In] double obj3) => obj0 * obj3 - obj1 * obj2;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool overlapsRect(
      float x1,
      float y1,
      float w1,
      float h1,
      float x2,
      float y2,
      float w2,
      float h2)
    {
      return (double) x1 < (double) (x2 + w2) && (double) (x1 + w1) > (double) x2 && ((double) y1 < (double) (y2 + h2) && (double) (y1 + h1) > (double) y2);
    }

    [LineNumberTable(584)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool overlaps(Circle c1, Circle c2) => c1.overlaps(c2);

    [LineNumberTable(588)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool overlaps(Rect r1, Rect r2) => r1.overlaps(r2);

    [LineNumberTable(622)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool overlapConvexPolygons(Polygon p1, Polygon p2) => Intersector.overlapConvexPolygons(p1, p2, (Intersector.MinimumTranslationVector) null);

    [LineNumberTable(new byte[] {159, 139, 109, 106, 106, 106, 106, 106, 106, 106, 106, 106, 106, 106, 106, 106, 106, 106, 106, 106, 106, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static Intersector()
    {
      if (ByteCodeHelper.isAlreadyInited("arc.math.geom.Intersector"))
        return;
      Intersector.v0 = new Vec3();
      Intersector.v1 = new Vec3();
      Intersector.v2 = new Vec3();
      Intersector.floatArray = new FloatSeq();
      Intersector.floatArray2 = new FloatSeq();
      Intersector.ip = new Vec2();
      Intersector.ep1 = new Vec2();
      Intersector.ep2 = new Vec2();
      Intersector.s = new Vec2();
      Intersector.e = new Vec2();
      Intersector.i = new Vec3();
      Intersector.dir = new Vec3();
      Intersector.start = new Vec3();
      Intersector.best = new Vec3();
      Intersector.tmp = new Vec3();
      Intersector.tmp1 = new Vec3();
      Intersector.tmp2 = new Vec3();
      Intersector.tmp3 = new Vec3();
      Intersector.v2tmp = new Vec2();
      Intersector.intersection = new Vec3();
    }

    public class MinimumTranslationVector : Object
    {
      public Vec2 normal;
      public float depth;

      [LineNumberTable(new byte[] {162, 177, 136, 139})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public MinimumTranslationVector()
      {
        Intersector.MinimumTranslationVector translationVector = this;
        this.normal = new Vec2();
        this.depth = 0.0f;
      }
    }
  }
}
