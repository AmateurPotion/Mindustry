// Decompiled with JetBrains decompiler
// Type: arc.math.DelaunayTriangulator
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.math.geom;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.math
{
  public class DelaunayTriangulator : Object
  {
    private const float EPSILON = 1E-06f;
    private const int INSIDE = 0;
    private const int COMPLETE = 1;
    private const int INCOMPLETE = 2;
    [Modifiers]
    private IntSeq quicksortStack;
    [Modifiers]
    private ShortSeq triangles;
    [Modifiers]
    private ShortSeq originalIndices;
    [Modifiers]
    private IntSeq edges;
    [Modifiers]
    private BoolSeq complete;
    [Modifiers]
    private float[] superTriangle;
    [Modifiers]
    private Vec2 centroid;
    private float[] sortedPoints;

    [LineNumberTable(new byte[] {159, 130, 131, 103, 102, 102, 136, 99, 126, 111, 104, 99, 168, 164, 105, 103, 109, 102, 104, 106, 102, 102, 106, 234, 57, 235, 73, 111, 117, 189, 104, 106, 106, 102, 106, 106, 138, 104, 139, 104, 103, 169, 103, 105, 105, 168, 107, 174, 104, 105, 114, 102, 108, 105, 105, 135, 101, 102, 103, 105, 98, 102, 136, 101, 102, 103, 105, 98, 102, 136, 101, 102, 103, 105, 98, 102, 136, 159, 11, 102, 133, 105, 105, 105, 105, 105, 137, 105, 107, 107, 234, 18, 236, 115, 105, 149, 103, 106, 105, 99, 108, 116, 99, 230, 61, 232, 70, 166, 104, 109, 104, 232, 46, 235, 84, 231, 159, 178, 235, 160, 82, 104, 111, 124, 105, 107, 235, 60, 233, 73, 99, 109, 113, 50, 232, 69, 99, 113, 45, 170, 113, 47, 200})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual ShortSeq computeTriangles(
      float[] points,
      int offset,
      int count,
      bool sorted)
    {
      int num1 = sorted ? 1 : 0;
      ShortSeq triangles = this.triangles;
      triangles.clear();
      if (count < 6)
        return triangles;
      triangles.ensureCapacity(count);
      if (num1 == 0)
      {
        if (this.sortedPoints == null || this.sortedPoints.Length < count)
          this.sortedPoints = new float[count];
        ByteCodeHelper.arraycopy_primitive_4((Array) points, offset, (Array) this.sortedPoints, 0, count);
        points = this.sortedPoints;
        offset = 0;
        this.sort(points, count);
      }
      int num2 = offset + count;
      float num3 = points[0];
      float num4 = points[1];
      float num5 = num3;
      float num6 = num4;
      int index1;
      for (int index2 = offset + 2; index2 < num2; index2 = index1 + 1)
      {
        float point1 = points[index2];
        if ((double) point1 < (double) num3)
          num3 = point1;
        if ((double) point1 > (double) num5)
          num5 = point1;
        index1 = index2 + 1;
        float point2 = points[index1];
        if ((double) point2 < (double) num4)
          num4 = point2;
        if ((double) point2 > (double) num6)
          num6 = point2;
      }
      float num7 = num5 - num3;
      float num8 = num6 - num4;
      float num9 = (float) (((double) num7 <= (double) num8 ? (double) num8 : (double) num7) * 20.0);
      float num10 = (num5 + num3) / 2f;
      float num11 = (num6 + num4) / 2f;
      float[] superTriangle = this.superTriangle;
      superTriangle[0] = num10 - num9;
      superTriangle[1] = num11 - num9;
      superTriangle[2] = num10;
      superTriangle[3] = num11 + num9;
      superTriangle[4] = num10 + num9;
      superTriangle[5] = num11 - num9;
      IntSeq edges = this.edges;
      edges.ensureCapacity(count / 2);
      BoolSeq complete = this.complete;
      complete.clear();
      complete.ensureCapacity(count);
      triangles.add(num2);
      triangles.add(num2 + 2);
      triangles.add(num2 + 4);
      complete.add(false);
      for (int index2 = offset; index2 < num2; index2 += 2)
      {
        float point1 = points[index2];
        float point2 = points[index2 + 1];
        short[] items1 = triangles.items;
        bool[] items2 = complete.items;
        for (int index3 = triangles.size - 1; index3 >= 0; index3 += -3)
        {
          int index4 = index3 / 3;
          if (!items2[index4])
          {
            int index5 = (int) items1[index3 - 2];
            int index6 = (int) items1[index3 - 1];
            int index7 = (int) items1[index3];
            float point3;
            float point4;
            if (index5 >= num2)
            {
              int index8 = index5 - num2;
              point3 = superTriangle[index8];
              point4 = superTriangle[index8 + 1];
            }
            else
            {
              point3 = points[index5];
              point4 = points[index5 + 1];
            }
            float point5;
            float point6;
            if (index6 >= num2)
            {
              int index8 = index6 - num2;
              point5 = superTriangle[index8];
              point6 = superTriangle[index8 + 1];
            }
            else
            {
              point5 = points[index6];
              point6 = points[index6 + 1];
            }
            float point7;
            float point8;
            if (index7 >= num2)
            {
              int index8 = index7 - num2;
              point7 = superTriangle[index8];
              point8 = superTriangle[index8 + 1];
            }
            else
            {
              point7 = points[index7];
              point8 = points[index7 + 1];
            }
            switch (this.circumCircle(point1, point2, point3, point4, point5, point6, point7, point8))
            {
              case 0:
                edges.add(index5);
                edges.add(index6);
                edges.add(index6);
                edges.add(index7);
                edges.add(index7);
                edges.add(index5);
                int num12 = (int) triangles.removeIndex(index3);
                int num13 = (int) triangles.removeIndex(index3 - 1);
                int num14 = (int) triangles.removeIndex(index3 - 2);
                complete.removeIndex(index4);
                continue;
              case 1:
                items2[index4] = true;
                continue;
              default:
                continue;
            }
          }
        }
        int[] items3 = edges.items;
        int index9 = 0;
        for (int size = edges.size; index9 < size; index9 += 2)
        {
          int num12 = items3[index9];
          if (num12 != -1)
          {
            int num13 = items3[index9 + 1];
            int num14 = 0;
            for (int index3 = index9 + 2; index3 < size; index3 += 2)
            {
              if (num12 == items3[index3 + 1] && num13 == items3[index3])
              {
                num14 = 1;
                items3[index3] = -1;
              }
            }
            if (num14 == 0)
            {
              triangles.add(num12);
              triangles.add(items3[index9 + 1]);
              triangles.add(index2);
              complete.add(false);
            }
          }
        }
        edges.clear();
      }
      short[] items4 = triangles.items;
      for (int index2 = triangles.size - 1; index2 >= 0; index2 += -3)
      {
        if ((int) items4[index2] >= num2 || (int) items4[index2 - 1] >= num2 || (int) items4[index2 - 2] >= num2)
        {
          int num12 = (int) triangles.removeIndex(index2);
          int num13 = (int) triangles.removeIndex(index2 - 1);
          int num14 = (int) triangles.removeIndex(index2 - 2);
        }
      }
      if (num1 == 0)
      {
        short[] items1 = this.originalIndices.items;
        int index2 = 0;
        for (int size = triangles.size; index2 < size; ++index2)
          items4[index2] = (short) ((int) items1[(int) items4[index2] / 2] * 2);
      }
      if (offset == 0)
      {
        int index2 = 0;
        for (int size = triangles.size; index2 < size; ++index2)
          items4[index2] = (short) ((int) items4[index2] / 2);
      }
      else
      {
        int index2 = 0;
        for (int size = triangles.size; index2 < size; ++index2)
          items4[index2] = (short) (((int) items4[index2] - offset) / 2);
      }
      return triangles;
    }

    [LineNumberTable(new byte[] {160, 148, 100, 107, 109, 108, 102, 36, 167, 98, 100, 104, 104, 106, 109, 104, 104, 102, 108, 106, 104, 139, 107, 104, 106, 104, 139, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void sort([In] float[] obj0, [In] int obj1)
    {
      int additionalCapacity = obj1 / 2;
      this.originalIndices.clear();
      this.originalIndices.ensureCapacity(additionalCapacity);
      short[] items = this.originalIndices.items;
      for (int index = 0; index < additionalCapacity; index = (int) (short) (index + 1))
        items[index] = (short) index;
      int num1 = 0;
      int num2 = obj1 - 1;
      IntSeq quicksortStack = this.quicksortStack;
      quicksortStack.add(num1);
      quicksortStack.add(num2 - 1);
      while (quicksortStack.size > 0)
      {
        int num3 = quicksortStack.pop();
        int num4 = quicksortStack.pop();
        if (num3 > num4)
        {
          int num5 = this.quicksortPartition(obj0, num4, num3, items);
          if (num5 - num4 > num3 - num5)
          {
            quicksortStack.add(num4);
            quicksortStack.add(num5 - 2);
          }
          quicksortStack.add(num5 + 2);
          quicksortStack.add(num3);
          if (num3 - num5 >= num5 - num4)
          {
            quicksortStack.add(num4);
            quicksortStack.add(num5 - 2);
          }
        }
      }
    }

    [LineNumberTable(new byte[] {160, 107, 111, 111, 107, 106, 116, 112, 113, 112, 110, 101, 115, 111, 113, 104, 113, 147, 117, 113, 113, 125, 206, 104, 104, 140, 103, 101, 103, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private int circumCircle(
      [In] float obj0,
      [In] float obj1,
      [In] float obj2,
      [In] float obj3,
      [In] float obj4,
      [In] float obj5,
      [In] float obj6,
      [In] float obj7)
    {
      float num1 = Math.abs(obj3 - obj5);
      float num2 = Math.abs(obj5 - obj7);
      float num3;
      float num4;
      if ((double) num1 < 9.99999997475243E-07)
      {
        if ((double) num2 < 9.99999997475243E-07)
          return 2;
        float num5 = -(obj6 - obj4) / (obj7 - obj5);
        float num6 = (obj4 + obj6) / 2f;
        float num7 = (obj5 + obj7) / 2f;
        num3 = (obj4 + obj2) / 2f;
        num4 = num5 * (num3 - num6) + num7;
      }
      else
      {
        float num5 = -(obj4 - obj2) / (obj5 - obj3);
        float num6 = (obj2 + obj4) / 2f;
        float num7 = (obj3 + obj5) / 2f;
        if ((double) num2 < 9.99999997475243E-07)
        {
          num3 = (obj6 + obj4) / 2f;
          num4 = num5 * (num3 - num6) + num7;
        }
        else
        {
          float num8 = -(obj6 - obj4) / (obj7 - obj5);
          float num9 = (obj4 + obj6) / 2f;
          float num10 = (obj5 + obj7) / 2f;
          num3 = (num5 * num6 - num8 * num9 + num10 - num7) / (num5 - num8);
          num4 = num5 * (num3 - num6) + num7;
        }
      }
      float num11 = obj4 - num3;
      float num12 = obj5 - num4;
      float num13 = num11 * num11 + num12 * num12;
      float num14 = obj0 - num3;
      float num15 = num14 * num14;
      float num16 = obj1 - num4;
      if ((double) (num15 + num16 * num16 - num13) <= 9.99999997475243E-07)
        return 0;
      return (double) obj0 > (double) num3 && (double) num15 > (double) num13 ? 1 : 2;
    }

    [LineNumberTable(new byte[] {160, 179, 100, 98, 164, 103, 106, 102, 102, 102, 100, 100, 102, 132, 102, 106, 134, 104, 108, 173, 102, 132, 102, 106, 134, 104, 108, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private int quicksortPartition([In] float[] obj0, [In] int obj1, [In] int obj2, [In] short[] obj3)
    {
      float num1 = obj0[obj1];
      int index1 = obj2;
      int index2 = obj1 + 2;
      while (index2 < index1)
      {
        while (index2 < index1 && (double) obj0[index2] <= (double) num1)
          index2 += 2;
        while ((double) obj0[index1] > (double) num1)
          index1 -= 2;
        if (index2 < index1)
        {
          float num2 = obj0[index2];
          obj0[index2] = obj0[index1];
          obj0[index1] = num2;
          float num3 = obj0[index2 + 1];
          obj0[index2 + 1] = obj0[index1 + 1];
          obj0[index1 + 1] = num3;
          int num4 = (int) obj3[index2 / 2];
          obj3[index2 / 2] = obj3[index1 / 2];
          obj3[index1 / 2] = (short) num4;
        }
      }
      obj0[obj1] = obj0[index1];
      obj0[index1] = num1;
      float num5 = obj0[obj1 + 1];
      obj0[obj1 + 1] = obj0[index1 + 1];
      obj0[index1 + 1] = num5;
      int num6 = (int) obj3[obj1 / 2];
      obj3[obj1 / 2] = obj3[index1 / 2];
      obj3[index1 / 2] = (short) num6;
      return index1;
    }

    [LineNumberTable(new byte[] {159, 157, 232, 70, 107, 110, 109, 107, 110, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public DelaunayTriangulator()
    {
      DelaunayTriangulator delaunayTriangulator = this;
      this.quicksortStack = new IntSeq();
      this.triangles = new ShortSeq(false, 16);
      this.originalIndices = new ShortSeq(false, 0);
      this.edges = new IntSeq();
      this.complete = new BoolSeq(false, 16);
      this.superTriangle = new float[6];
      this.centroid = new Vec2();
    }

    [LineNumberTable(32)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual ShortSeq computeTriangles(FloatSeq points, bool sorted)
    {
      int num = sorted ? 1 : 0;
      return this.computeTriangles(points.items, 0, points.size, num != 0);
    }

    [LineNumberTable(37)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual ShortSeq computeTriangles(float[] polygon, bool sorted)
    {
      int num = sorted ? 1 : 0;
      return this.computeTriangles(polygon, 0, polygon.Length, num != 0);
    }

    [LineNumberTable(new byte[] {160, 221, 103, 112, 104, 104, 103, 159, 7, 127, 3, 104, 106, 234, 55, 234, 76})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void trim(
      ShortSeq triangles,
      float[] points,
      float[] hull,
      int offset,
      int count)
    {
      short[] items = triangles.items;
      for (int index1 = triangles.size - 1; index1 >= 0; index1 += -3)
      {
        int index2 = (int) items[index1 - 2] * 2;
        int index3 = (int) items[index1 - 1] * 2;
        int index4 = (int) items[index1] * 2;
        Geometry.triangleCentroid(points[index2], points[index2 + 1], points[index3], points[index3 + 1], points[index4], points[index4 + 1], this.centroid);
        if (!Intersector.isInPolygon(hull, offset, count, this.centroid.x, this.centroid.y))
        {
          int num1 = (int) triangles.removeIndex(index1);
          int num2 = (int) triangles.removeIndex(index1 - 1);
          int num3 = (int) triangles.removeIndex(index1 - 2);
        }
      }
    }
  }
}
