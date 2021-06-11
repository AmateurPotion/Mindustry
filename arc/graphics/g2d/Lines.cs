// Decompiled with JetBrains decompiler
// Type: arc.graphics.g2d.Lines
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.math;
using arc.math.geom;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System.Runtime.CompilerServices;

namespace arc.graphics.g2d
{
  public class Lines : Object
  {
    public static bool useLegacyLine;
    private static float stroke;
    private static Vec2 vector;
    private static Vec2 u;
    private static Vec2 v;
    private static Vec2 inner;
    private static Vec2 outer;
    private static FloatSeq floats;
    private static FloatSeq floatBuilder;
    private static bool building;
    private static float circlePrecision;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {161, 34, 103, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void stroke(float thick, Color color)
    {
      Lines.stroke = thick;
      Draw.color(color);
    }

    [LineNumberTable(new byte[] {3, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void line(float x, float y, float x2, float y2) => Lines.line(x, y, x2, y2, true);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void stroke(float thick) => Lines.stroke = thick;

    [LineNumberTable(new byte[] {160, 160, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void poly(float x, float y, int sides, float radius) => Lines.poly(x, y, sides, radius, 0.0f);

    [LineNumberTable(new byte[] {159, 127, 99, 106, 127, 2, 155, 99, 159, 36, 159, 13, 101, 109, 116, 156, 102, 255, 51, 81, 255, 21, 82})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void line(
      TextureRegion region,
      float x,
      float y,
      float x2,
      float y2,
      bool cap)
    {
      int num1 = cap ? 1 : 0;
      if (Lines.useLegacyLine)
      {
        float w = Mathf.dst(x, y, x2, y2) + (num1 != 0 ? Lines.stroke : 0.0f);
        float rotation = Mathf.atan2(x2 - x, y2 - y) * 57.29578f;
        if (num1 != 0)
          Draw.rect(region, x - Lines.stroke / 2f + w / 2f, y, w, Lines.stroke, Lines.stroke / 2f, Lines.stroke / 2f, rotation);
        else
          Draw.rect(region, x + w / 2f, y, w, Lines.stroke, 0.0f, Lines.stroke / 2f, rotation);
      }
      else
      {
        float num2 = Lines.stroke / 2f;
        float num3 = Mathf.len(x2 - x, y2 - y);
        float num4 = (x2 - x) / num3 * num2;
        float num5 = (y2 - y) / num3 * num2;
        if (num1 != 0)
          Fill.quad(region, x - num4 - num5, y - num5 + num4, x - num4 + num5, y - num5 - num4, x2 + num4 + num5, y2 + num5 - num4, x2 + num4 - num5, y2 + num5 + num4);
        else
          Fill.quad(region, x - num5, y + num4, x + num5, y - num4, x2 + num5, y2 - num4, x2 - num5, y2 + num4);
      }
    }

    [LineNumberTable(new byte[] {160, 79, 142, 106, 110, 31, 44, 233, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void dashLine(float x1, float y1, float x2, float y2, int divisions)
    {
      float num1 = x2 - x1;
      float num2 = y2 - y1;
      for (int index = 0; index < divisions; ++index)
      {
        int num3 = index;
        int num4 = 2;
        if ((num4 != -1 ? num3 % num4 : 0) == 0)
          Lines.line(x1 + (float) index / (float) divisions * num1, y1 + (float) index / (float) divisions * num2, x1 + ((float) index + 1f) / (float) divisions * num1, y1 + ((float) index + 1f) / (float) divisions * num2);
      }
    }

    [LineNumberTable(new byte[] {161, 18, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void rect(float x, float y, float width, float height) => Lines.rect(x, y, width, height, 0);

    [LineNumberTable(new byte[] {159, 177, 159, 4, 127, 6})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void lineAngle(float x, float y, float angle, float length)
    {
      Lines.vector.set(1f, 1f).setLength(length).setAngle(angle);
      Lines.line(x, y, x + Lines.vector.x, y + Lines.vector.y);
    }

    [LineNumberTable(new byte[] {159, 135, 99, 159, 4, 127, 7})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void lineAngle(float x, float y, float angle, float length, bool cap)
    {
      int num = cap ? 1 : 0;
      Lines.vector.set(1f, 1f).setLength(length).setAngle(angle);
      Lines.line(x, y, x + Lines.vector.x, y + Lines.vector.y, num != 0);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static float getStroke() => Lines.stroke;

    [LineNumberTable(new byte[] {160, 94, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void circle(float x, float y, float rad) => Lines.poly(x, y, Lines.circleVertices(rad), rad);

    [LineNumberTable(new byte[] {160, 253, 127, 4})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void square(float x, float y, float rad) => Lines.rect(x - rad, y - rad, rad * 2f, rad * 2f);

    [LineNumberTable(new byte[] {160, 131, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void spikes(float x, float y, float rad, float length, int spikes) => Lines.spikes(x, y, rad, length, spikes, 0.0f);

    [LineNumberTable(new byte[] {159, 128, 99, 120})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void line(float x, float y, float x2, float y2, bool cap)
    {
      int num = cap ? 1 : 0;
      Lines.line((TextureRegion) Core.atlas.white(), x, y, x2, y2, num != 0);
    }

    [LineNumberTable(new byte[] {161, 1, 117})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void square(float x, float y, float rad, float rot) => Lines.poly(x, y, 4, rad, rot - 45f);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int circleVertices(float rad) => 11 + ByteCodeHelper.f2i(rad * Lines.circlePrecision);

    [LineNumberTable(new byte[] {159, 189, 143, 127, 58})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void lineAngleCenter(float x, float y, float angle, float length)
    {
      Lines.vector.trns(angle, length);
      Lines.line(x - Lines.vector.x / 2f, y - Lines.vector.y / 2f, x + Lines.vector.x / 2f, y + Lines.vector.y / 2f);
    }

    [LineNumberTable(new byte[] {160, 164, 106, 100, 114, 255, 30, 61, 233, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void poly(Vec2[] vertices, float offsetx, float offsety, float scl)
    {
      for (int index = 0; index < vertices.Length; ++index)
      {
        Vec2 vertex = vertices[index];
        Vec2 vec2 = index != vertices.Length - 1 ? vertices[index + 1] : vertices[0];
        Lines.line(vertex.x * scl + offsetx, vertex.y * scl + offsety, vec2.x * scl + offsetx, vec2.y * scl + offsety);
      }
    }

    [LineNumberTable(new byte[] {73, 119, 106, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void beginLine()
    {
      if (Lines.building)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalStateException("Already building");
      }
      Lines.floatBuilder.clear();
      Lines.building = true;
    }

    [LineNumberTable(new byte[] {68, 119, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void linePoint(float x, float y)
    {
      if (!Lines.building)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalStateException("Not building");
      }
      Lines.floatBuilder.add(x, y);
    }

    [LineNumberTable(new byte[] {79, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void endLine() => Lines.endLine(false);

    [LineNumberTable(new byte[] {160, 144, 106, 125, 140, 107, 127, 28, 31, 46, 235, 73})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void poly(float x, float y, int sides, float radius, float angle)
    {
      float num1 = 360f / (float) sides;
      float num2 = Lines.stroke / 2f / Mathf.cosDeg(num1 / 2f);
      float num3 = radius - num2;
      float num4 = radius + num2;
      for (int index = 0; index < sides; ++index)
      {
        float degrees = num1 * (float) index + angle;
        float num5 = Mathf.cosDeg(degrees);
        float num6 = Mathf.sinDeg(degrees);
        float num7 = Mathf.cosDeg(degrees + num1);
        float num8 = Mathf.sinDeg(degrees + num1);
        Fill.quad(x + num3 * num5, y + num3 * num6, x + num3 * num7, y + num3 * num8, x + num4 * num7, y + num4 * num8, x + num4 * num5, y + num4 * num6);
      }
    }

    [LineNumberTable(new byte[] {160, 117, 117, 139, 106, 117, 109, 118, 145, 255, 12, 58, 233, 72})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void spikes(
      float x,
      float y,
      float radius,
      float length,
      int spikes,
      float rot)
    {
      Lines.vector.set(0.0f, 1f);
      float num = 360f / (float) spikes;
      for (int index = 0; index < spikes; ++index)
      {
        Lines.vector.setAngle((float) index * num + rot);
        Lines.vector.setLength(radius);
        float x1 = Lines.vector.x;
        float y1 = Lines.vector.y;
        Lines.vector.setLength(radius + length);
        Lines.line(x + x1, y + y1, x + Lines.vector.x, y + Lines.vector.y);
      }
    }

    [LineNumberTable(new byte[] {160, 98, 102, 110, 147, 149, 105, 115, 127, 12, 107, 140, 159, 14, 255, 13, 56, 233, 74})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void dashCircle(float x, float y, float radius)
    {
      float num1 = 0.6f;
      int num2 = 10 + ByteCodeHelper.f2i(radius * num1);
      int num3 = num2;
      int num4 = 2;
      if ((num4 != -1 ? num3 % num4 : 0) == 1)
        ++num2;
      Lines.vector.set(0.0f, 0.0f);
      for (int index = 0; index < num2; ++index)
      {
        int num5 = index;
        int num6 = 2;
        if ((num6 != -1 ? num5 % num6 : 0) != 0)
        {
          Lines.vector.set(radius, 0.0f).setAngle(360f / (float) num2 * (float) index + 90f);
          float x1 = Lines.vector.x;
          float y1 = Lines.vector.y;
          Lines.vector.set(radius, 0.0f).setAngle(360f / (float) num2 * (float) (index + 1) + 90f);
          Lines.line(x1 + x, y1 + y, Lines.vector.x + x, Lines.vector.y + y);
        }
      }
    }

    [LineNumberTable(new byte[] {159, 108, 162, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void polyline(FloatSeq points, bool wrap)
    {
      int num = wrap ? 1 : 0;
      Lines.polyline(points.items, points.size, num != 0);
    }

    [LineNumberTable(new byte[] {161, 5, 105, 105, 112, 144, 112, 149, 117, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void rect(
      float x,
      float y,
      float width,
      float height,
      float xspace,
      float yspace)
    {
      x -= xspace;
      y -= yspace;
      width += xspace * 2f;
      height += yspace * 2f;
      Fill.crect(x, y, width, Lines.stroke);
      Fill.crect(x, y + height, width, -Lines.stroke);
      Fill.crect(x + width, y, -Lines.stroke, height);
      Fill.crect(x, y, Lines.stroke, height);
    }

    [LineNumberTable(new byte[] {160, 188, 107, 101, 136, 105, 106, 106, 138, 116, 148, 121, 153, 100, 132, 122, 154, 112, 144, 104, 136, 110, 104, 104, 104, 104, 104, 104, 104, 109, 133, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void curve(
      float x1,
      float y1,
      float cx1,
      float cy1,
      float cx2,
      float cy2,
      float x2,
      float y2,
      int segments)
    {
      float num1 = 1f / (float) segments;
      float num2 = num1 * num1;
      float num3 = num1 * num1 * num1;
      float num4 = 3f * num1;
      float num5 = 3f * num2;
      float num6 = 6f * num2;
      float num7 = 6f * num3;
      float num8 = x1 - cx1 * 2f + cx2;
      float num9 = y1 - cy1 * 2f + cy2;
      float num10 = (cx1 - cx2) * 3f - x1 + x2;
      float num11 = (cy1 - cy2) * 3f - y1 + y2;
      float num12 = x1;
      float num13 = y1;
      float num14 = (cx1 - x1) * num4 + num8 * num5 + num10 * num3;
      float num15 = (cy1 - y1) * num4 + num9 * num5 + num11 * num3;
      float num16 = num8 * num6 + num10 * num7;
      float num17 = num9 * num6 + num11 * num7;
      float num18 = num10 * num7;
      float num19 = num11 * num7;
      while (true)
      {
        int num20 = segments;
        segments += -1;
        if (num20 > 0)
        {
          float x = num12;
          float y = num13;
          num12 += num14;
          num13 += num15;
          num14 += num16;
          num15 += num17;
          num16 += num18;
          num17 += num19;
          Lines.line(x, y, num12, num13);
        }
        else
          break;
      }
      Lines.line(num12, num13, x2, y2);
    }

    [LineNumberTable(new byte[] {159, 109, 98, 119, 107, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void endLine(bool wrap)
    {
      int num = wrap ? 1 : 0;
      if (!Lines.building)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalStateException("Not building");
      }
      Lines.polyline(Lines.floatBuilder, num != 0);
      Lines.building = false;
    }

    [LineNumberTable(new byte[] {159, 107, 162, 133, 99, 104, 100, 102, 103, 103, 235, 59, 235, 72, 138, 105, 108, 108, 101, 103, 114, 146, 126, 142, 127, 36, 159, 40, 127, 4, 159, 4, 255, 19, 47, 233, 84, 114, 109, 111, 127, 5, 159, 5, 127, 5, 127, 5, 127, 5, 159, 5, 243, 53, 233, 78})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void polyline(float[] points, int length, bool wrap)
    {
      int num1 = wrap ? 1 : 0;
      if (length < 4)
        return;
      if (num1 == 0)
      {
        for (int index = 0; index < length - 2; index += 2)
          Lines.line(points[index], points[index + 1], points[index + 2], points[index + 3]);
      }
      else
      {
        Lines.floats.clear();
        for (int index1 = 0; index1 < length; index1 += 2)
        {
          float point1 = points[Mathf.mod(index1 - 2, length)];
          float point2 = points[Mathf.mod(index1 - 1, length)];
          float point3 = points[index1];
          float point4 = points[index1 + 1];
          float[] numArray1 = points;
          int num2 = index1 + 2;
          int num3 = length;
          int index2 = num3 != -1 ? num2 % num3 : 0;
          float num4 = numArray1[index2];
          float[] numArray2 = points;
          int num5 = index1 + 3;
          int num6 = length;
          int index3 = num6 != -1 ? num5 % num6 : 0;
          float num7 = numArray2[index3];
          float num8 = Angles.angle(point1, point2, point3, point4);
          float num9 = Mathf.sinDeg(Angles.angle(point3, point4, num4, num7) - num8);
          Lines.u.set(point1, point2).sub(point3, point4).scl(1f / Mathf.dst(point1, point2, point3, point4)).scl(Lines.stroke / (2f * num9));
          Lines.v.set(num4, num7).sub(point3, point4).scl(1f / Mathf.dst(num4, num7, point3, point4)).scl(Lines.stroke / (2f * num9));
          Lines.inner.set(point3, point4).add(Lines.u).add(Lines.v);
          Lines.outer.set(point3, point4).sub(Lines.u).sub(Lines.v);
          Lines.floats.add(Lines.inner.x, Lines.inner.y, Lines.outer.x, Lines.outer.y);
        }
        for (int index1 = 0; index1 < Lines.floats.size; index1 += 4)
        {
          float x1 = Lines.floats.items[index1];
          float y1 = Lines.floats.items[index1 + 1];
          float[] items1 = Lines.floats.items;
          int num2 = index1 + 2;
          int size1 = Lines.floats.size;
          int index2 = size1 != -1 ? num2 % size1 : 0;
          float x4 = items1[index2];
          float[] items2 = Lines.floats.items;
          int num3 = index1 + 3;
          int size2 = Lines.floats.size;
          int index3 = size2 != -1 ? num3 % size2 : 0;
          float y4 = items2[index3];
          float[] items3 = Lines.floats.items;
          int num4 = index1 + 4;
          int size3 = Lines.floats.size;
          int index4 = size3 != -1 ? num4 % size3 : 0;
          float x2 = items3[index4];
          float[] items4 = Lines.floats.items;
          int num5 = index1 + 5;
          int size4 = Lines.floats.size;
          int index5 = size4 != -1 ? num5 % size4 : 0;
          float y2 = items4[index5];
          float[] items5 = Lines.floats.items;
          int num6 = index1 + 6;
          int size5 = Lines.floats.size;
          int index6 = size5 != -1 ? num6 % size5 : 0;
          float x3 = items5[index6];
          float[] items6 = Lines.floats.items;
          int num7 = index1 + 7;
          int size6 = Lines.floats.size;
          int index7 = size6 != -1 ? num7 % size6 : 0;
          float y3 = items6[index7];
          Fill.quad(x1, y1, x2, y2, x3, y3, x4, y4);
        }
      }
    }

    [LineNumberTable(new byte[] {160, 234, 99, 115, 117, 138, 105, 127, 10, 107, 140, 159, 12, 245, 57, 233, 74, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void swirl(float x, float y, float radius, float finion, float angle)
    {
      int num1 = 50;
      int num2 = ByteCodeHelper.f2i((float) num1 * (finion + 1f / 1000f));
      Lines.vector.set(0.0f, 0.0f);
      Lines.floats.clear();
      for (int index = 0; index < num2; ++index)
      {
        Lines.vector.set(radius, 0.0f).setAngle(360f / (float) num1 * (float) index + angle);
        float x1 = Lines.vector.x;
        float y1 = Lines.vector.y;
        Lines.vector.set(radius, 0.0f).setAngle(360f / (float) num1 * (float) (index + 1) + angle);
        Lines.floats.add(x1 + x, y1 + y);
      }
      Lines.polyline(Lines.floats, false);
    }

    [LineNumberTable(new byte[] {161, 26, 115})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void rect(float x, float y, float width, float height, int space) => Lines.rect(x, y, width, height, (float) space, (float) space);

    [LineNumberTable(9)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Lines()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void setCirclePrecision(float amount) => Lines.circlePrecision = amount;

    [LineNumberTable(new byte[] {159, 183, 159, 9, 127, 6})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void lineAngle(float x, float y, float offset, float angle, float length)
    {
      Lines.vector.set(1f, 1f).setLength(length + offset).setAngle(angle);
      Lines.line(x, y, x + Lines.vector.x, y + Lines.vector.y);
    }

    [LineNumberTable(new byte[] {64, 115})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void linePoint(Position p) => Lines.linePoint(p.getX(), p.getY());

    [LineNumberTable(new byte[] {160, 135, 138, 114, 150, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void quad(
      float x1,
      float y1,
      float x2,
      float y2,
      float x3,
      float y3,
      float x4,
      float y4)
    {
      Lines.floatBuilder.clear();
      Lines.floatBuilder.add(x1, y1, x2, y2);
      Lines.floatBuilder.add(x3, y3, x4, y4);
      Lines.polyline(Lines.floatBuilder, true);
    }

    [LineNumberTable(new byte[] {160, 172, 149, 105, 127, 18, 107, 139, 159, 20, 255, 14, 57, 233, 73})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void polySeg(
      int sides,
      int from,
      int to,
      float x,
      float y,
      float radius,
      float angle)
    {
      Lines.vector.set(0.0f, 0.0f);
      for (int index = from; index < to; ++index)
      {
        Lines.vector.set(radius, 0.0f).setAngle(360f / (float) sides * (float) index + angle + 90f);
        float x1 = Lines.vector.x;
        float y1 = Lines.vector.y;
        Lines.vector.set(radius, 0.0f).setAngle(360f / (float) sides * (float) (index + 1) + angle + 90f);
        Lines.line(x1 + x, y1 + y, Lines.vector.x + x, Lines.vector.y + y);
      }
    }

    [LineNumberTable(new byte[] {160, 230, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void swirl(float x, float y, float radius, float finion) => Lines.swirl(x, y, radius, finion, 0.0f);

    [LineNumberTable(new byte[] {161, 22, 126})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void rect(Rect rect) => Lines.rect(rect.x, rect.y, rect.width, rect.height, 0);

    [LineNumberTable(new byte[] {159, 140, 141, 134, 106, 127, 19, 108, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static Lines()
    {
      if (ByteCodeHelper.isAlreadyInited("arc.graphics.g2d.Lines"))
        return;
      Lines.useLegacyLine = false;
      Lines.stroke = 1f;
      Lines.vector = new Vec2();
      Lines.u = new Vec2();
      Lines.v = new Vec2();
      Lines.inner = new Vec2();
      Lines.outer = new Vec2();
      Lines.floats = new FloatSeq(20);
      Lines.floatBuilder = new FloatSeq(20);
      Lines.circlePrecision = 0.4f;
    }
  }
}
