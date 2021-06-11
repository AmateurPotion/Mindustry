// Decompiled with JetBrains decompiler
// Type: arc.math.geom.ConvexHull
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
  public class ConvexHull : Object
  {
    [Modifiers]
    private IntSeq quicksortStack;
    [Modifiers]
    private FloatSeq hull;
    [Modifiers]
    private IntSeq indices;
    [Modifiers]
    private ShortSeq originalIndices;
    private float[] sortedPoints;

    [LineNumberTable(new byte[] {159, 133, 163, 132, 99, 126, 111, 104, 99, 168, 103, 166, 105, 101, 103, 123, 112, 104, 232, 58, 233, 74, 117, 101, 103, 124, 112, 104, 232, 58, 234, 73})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual FloatSeq computePolygon(
      float[] points,
      int offset,
      int count,
      bool sorted)
    {
      int num1 = sorted ? 1 : 0;
      int num2 = offset + count;
      if (num1 == 0)
      {
        if (this.sortedPoints == null || this.sortedPoints.Length < count)
          this.sortedPoints = new float[count];
        ByteCodeHelper.arraycopy_primitive_4((Array) points, offset, (Array) this.sortedPoints, 0, count);
        points = this.sortedPoints;
        offset = 0;
        this.sort(points, count);
      }
      FloatSeq hull = this.hull;
      hull.clear();
      for (int index = offset; index < num2; index += 2)
      {
        float point1 = points[index];
        float point2 = points[index + 1];
        while (hull.size >= 4 && (double) this.ccw(point1, point2) <= 0.0)
          hull.size -= 2;
        hull.add(point1);
        hull.add(point2);
      }
      int index1 = num2 - 4;
      int num3 = hull.size + 2;
      for (; index1 >= offset; index1 += -2)
      {
        float point1 = points[index1];
        float point2 = points[index1 + 1];
        while (hull.size >= num3 && (double) this.ccw(point1, point2) <= 0.0)
          hull.size -= 2;
        hull.add(point1);
        hull.add(point2);
      }
      return hull;
    }

    [LineNumberTable(new byte[] {106, 98, 100, 103, 103, 105, 108, 103, 103, 102, 106, 104, 103, 137, 105, 103, 104, 103, 137, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void sort([In] float[] obj0, [In] int obj1)
    {
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
          int num5 = this.quicksortPartition(obj0, num4, num3);
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

    [LineNumberTable(new byte[] {92, 103, 103, 107, 107, 108, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private float ccw([In] float obj0, [In] float obj1)
    {
      FloatSeq hull = this.hull;
      int size = hull.size;
      float num1 = hull.get(size - 4);
      float num2 = hull.get(size - 3);
      float num3 = hull.get(size - 2);
      float num4 = hull.peek();
      return (num3 - num1) * (obj1 - num2) - (num4 - num2) * (obj0 - num1);
    }

    [LineNumberTable(new byte[] {159, 121, 166, 132, 99, 126, 111, 104, 99, 169, 103, 134, 104, 167, 113, 102, 104, 124, 111, 144, 105, 105, 232, 55, 241, 77, 126, 102, 104, 125, 111, 144, 105, 105, 232, 55, 242, 77, 99, 109, 104, 113, 45, 200})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual IntSeq computeIndices(
      float[] points,
      int offset,
      int count,
      bool sorted,
      bool yDown)
    {
      int num1 = sorted ? 1 : 0;
      int num2 = yDown ? 1 : 0;
      int num3 = offset + count;
      if (num1 == 0)
      {
        if (this.sortedPoints == null || this.sortedPoints.Length < count)
          this.sortedPoints = new float[count];
        ByteCodeHelper.arraycopy_primitive_4((Array) points, offset, (Array) this.sortedPoints, 0, count);
        points = this.sortedPoints;
        offset = 0;
        this.sortWithIndices(points, count, num2 != 0);
      }
      IntSeq indices = this.indices;
      indices.clear();
      FloatSeq hull = this.hull;
      hull.clear();
      int index1 = offset;
      int num4 = index1 / 2;
      while (index1 < num3)
      {
        float point1 = points[index1];
        float point2 = points[index1 + 1];
        while (hull.size >= 4 && (double) this.ccw(point1, point2) <= 0.0)
        {
          hull.size -= 2;
          --indices.size;
        }
        hull.add(point1);
        hull.add(point2);
        indices.add(num4);
        index1 += 2;
        ++num4;
      }
      int index2 = num3 - 4;
      int num5 = index2 / 2;
      int num6 = hull.size + 2;
      while (index2 >= offset)
      {
        float point1 = points[index2];
        float point2 = points[index2 + 1];
        while (hull.size >= num6 && (double) this.ccw(point1, point2) <= 0.0)
        {
          hull.size -= 2;
          --indices.size;
        }
        hull.add(point1);
        hull.add(point2);
        indices.add(num5);
        index2 += -2;
        num5 += -1;
      }
      if (num1 == 0)
      {
        short[] items1 = this.originalIndices.items;
        int[] items2 = indices.items;
        int index3 = 0;
        for (int size = indices.size; index3 < size; ++index3)
          items2[index3] = (int) items1[items2[index3]];
      }
      return indices;
    }

    [LineNumberTable(new byte[] {159, 89, 162, 100, 107, 109, 108, 102, 36, 167, 98, 101, 104, 104, 107, 109, 105, 104, 103, 110, 107, 104, 139, 107, 105, 107, 104, 139, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void sortWithIndices([In] float[] obj0, [In] int obj1, [In] bool obj2)
    {
      int num1 = obj2 ? 1 : 0;
      int additionalCapacity = obj1 / 2;
      this.originalIndices.clear();
      this.originalIndices.ensureCapacity(additionalCapacity);
      short[] items = this.originalIndices.items;
      for (int index = 0; index < additionalCapacity; index = (int) (short) (index + 1))
        items[index] = (short) index;
      int num2 = 0;
      int num3 = obj1 - 1;
      IntSeq quicksortStack = this.quicksortStack;
      quicksortStack.add(num2);
      quicksortStack.add(num3 - 1);
      while (quicksortStack.size > 0)
      {
        int num4 = quicksortStack.pop();
        int num5 = quicksortStack.pop();
        if (num4 > num5)
        {
          int num6 = this.quicksortPartitionWithIndices(obj0, num5, num4, num1 != 0, items);
          if (num6 - num5 > num4 - num6)
          {
            quicksortStack.add(num5);
            quicksortStack.add(num6 - 2);
          }
          quicksortStack.add(num6 + 2);
          quicksortStack.add(num4);
          if (num4 - num6 >= num6 - num5)
          {
            quicksortStack.add(num5);
            quicksortStack.add(num6 - 2);
          }
        }
      }
    }

    [LineNumberTable(new byte[] {160, 66, 100, 102, 98, 162, 103, 106, 102, 116, 102, 100, 101, 102, 133, 103, 106, 172, 102, 132, 106, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private int quicksortPartition([In] float[] obj0, [In] int obj1, [In] int obj2)
    {
      float num1 = obj0[obj1];
      float num2 = obj0[obj1 + 1];
      int index1 = obj2;
      int index2 = obj1;
      while (index2 < index1)
      {
        while (index2 < index1 && (double) obj0[index2] <= (double) num1)
          index2 += 2;
        while ((double) obj0[index1] > (double) num1 || (double) obj0[index1] == (double) num1 && (double) obj0[index1 + 1] < (double) num2)
          index1 -= 2;
        if (index2 < index1)
        {
          float num3 = obj0[index2];
          obj0[index2] = obj0[index1];
          obj0[index1] = num3;
          float num4 = obj0[index2 + 1];
          obj0[index2 + 1] = obj0[index1 + 1];
          obj0[index1 + 1] = num4;
        }
      }
      obj0[obj1] = obj0[index1];
      obj0[index1] = num1;
      obj0[obj1 + 1] = obj0[index1 + 1];
      obj0[index1 + 1] = num2;
      return index1;
    }

    [LineNumberTable(new byte[] {159, 81, 131, 100, 102, 98, 163, 104, 108, 104, 99, 116, 134, 116, 134, 104, 102, 103, 133, 104, 107, 135, 105, 109, 173, 102, 132, 106, 134, 104, 108, 136})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private int quicksortPartitionWithIndices(
      [In] float[] obj0,
      [In] int obj1,
      [In] int obj2,
      [In] bool obj3,
      [In] short[] obj4)
    {
      int num1 = obj3 ? 1 : 0;
      float num2 = obj0[obj1];
      float num3 = obj0[obj1 + 1];
      int index1 = obj2;
      int index2 = obj1;
      while (index2 < index1)
      {
        while (index2 < index1 && (double) obj0[index2] <= (double) num2)
          index2 += 2;
        if (num1 != 0)
        {
          while ((double) obj0[index1] > (double) num2 || (double) obj0[index1] == (double) num2 && (double) obj0[index1 + 1] < (double) num3)
            index1 -= 2;
        }
        else
        {
          while ((double) obj0[index1] > (double) num2 || (double) obj0[index1] == (double) num2 && (double) obj0[index1 + 1] > (double) num3)
            index1 -= 2;
        }
        if (index2 < index1)
        {
          float num4 = obj0[index2];
          obj0[index2] = obj0[index1];
          obj0[index1] = num4;
          float num5 = obj0[index2 + 1];
          obj0[index2 + 1] = obj0[index1 + 1];
          obj0[index1 + 1] = num5;
          int num6 = (int) obj4[index2 / 2];
          obj4[index2 / 2] = obj4[index1 / 2];
          obj4[index1 / 2] = (short) num6;
        }
      }
      obj0[obj1] = obj0[index1];
      obj0[index1] = num2;
      obj0[obj1 + 1] = obj0[index1 + 1];
      obj0[index1 + 1] = num3;
      int num7 = (int) obj4[obj1 / 2];
      obj4[obj1 / 2] = obj4[index1 / 2];
      obj4[index1 / 2] = (short) num7;
      return index1;
    }

    [LineNumberTable(new byte[] {159, 153, 104, 107, 107, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ConvexHull()
    {
      ConvexHull convexHull = this;
      this.quicksortStack = new IntSeq();
      this.hull = new FloatSeq();
      this.indices = new IntSeq();
      this.originalIndices = new ShortSeq(false, 0);
    }

    [LineNumberTable(20)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual FloatSeq computePolygon(FloatSeq points, bool sorted)
    {
      int num = sorted ? 1 : 0;
      return this.computePolygon(points.items, 0, points.size, num != 0);
    }

    [LineNumberTable(25)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual FloatSeq computePolygon(float[] polygon, bool sorted)
    {
      int num = sorted ? 1 : 0;
      return this.computePolygon(polygon, 0, polygon.Length, num != 0);
    }

    [LineNumberTable(77)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual IntSeq computeIndices(FloatSeq points, bool sorted, bool yDown)
    {
      int num1 = sorted ? 1 : 0;
      int num2 = yDown ? 1 : 0;
      return this.computeIndices(points.items, 0, points.size, num1 != 0, num2 != 0);
    }

    [LineNumberTable(82)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual IntSeq computeIndices(float[] polygon, bool sorted, bool yDown)
    {
      int num1 = sorted ? 1 : 0;
      int num2 = yDown ? 1 : 0;
      return this.computeIndices(polygon, 0, polygon.Length, num1 != 0, num2 != 0);
    }
  }
}
