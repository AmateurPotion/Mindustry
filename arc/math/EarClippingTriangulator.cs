// Decompiled with JetBrains decompiler
// Type: arc.math.EarClippingTriangulator
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.math
{
  public class EarClippingTriangulator : Object
  {
    private const int CONCAVE = -1;
    private const int CONVEX = 1;
    [Modifiers]
    private ShortSeq indicesArray;
    [Modifiers]
    private IntSeq vertexTypes;
    [Modifiers]
    private ShortSeq triangles;
    private short[] indices;
    private float[] vertices;
    private int vertexCount;

    [LineNumberTable(new byte[] {26, 103, 111, 132, 103, 102, 104, 103, 118, 106, 104, 42, 171, 109, 45, 200, 104, 103, 105, 104, 47, 200, 104, 103, 115, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual ShortSeq computeTriangles(float[] vertices, int offset, int count)
    {
      this.vertices = vertices;
      EarClippingTriangulator clippingTriangulator1 = this;
      int num1 = count / 2;
      int num2 = num1;
      this.vertexCount = num1;
      int additionalCapacity = num2;
      int num3 = offset / 2;
      ShortSeq indicesArray = this.indicesArray;
      indicesArray.clear();
      indicesArray.ensureCapacity(additionalCapacity);
      indicesArray.size = additionalCapacity;
      EarClippingTriangulator clippingTriangulator2 = this;
      short[] items = indicesArray.items;
      short[] numArray1 = items;
      this.indices = items;
      short[] numArray2 = numArray1;
      if (EarClippingTriangulator.areVerticesClockwise(vertices, offset, count))
      {
        for (int index = 0; index < additionalCapacity; index = (int) (short) (index + 1))
          numArray2[index] = (short) (num3 + index);
      }
      else
      {
        int index = 0;
        int num4 = additionalCapacity - 1;
        for (; index < additionalCapacity; ++index)
          numArray2[index] = (short) (num3 + num4 - index);
      }
      IntSeq vertexTypes = this.vertexTypes;
      vertexTypes.clear();
      vertexTypes.ensureCapacity(additionalCapacity);
      for (int index = 0; index < additionalCapacity; ++index)
        vertexTypes.add(this.classifyVertex(index));
      ShortSeq triangles = this.triangles;
      triangles.clear();
      triangles.ensureCapacity(Math.max(0, additionalCapacity - 2) * 3);
      this.triangulate();
      return triangles;
    }

    [LineNumberTable(new byte[] {159, 178, 102, 102, 108, 100, 103, 103, 103, 241, 59, 230, 71, 104, 105, 101, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool areVerticesClockwise([In] float[] obj0, [In] int obj1, [In] int obj2)
    {
      if (obj2 <= 2)
        return false;
      float num1 = 0.0f;
      int index1 = obj1;
      for (int index2 = obj1 + obj2 - 3; index1 < index2; index1 += 2)
      {
        float num2 = obj0[index1];
        float num3 = obj0[index1 + 1];
        float num4 = obj0[index1 + 2];
        float num5 = obj0[index1 + 3];
        num1 += num2 * num5 - num4 * num3;
      }
      float num6 = obj0[obj1 + obj2 - 2];
      float num7 = obj0[obj1 + obj2 - 1];
      float num8 = obj0[obj1];
      float num9 = obj0[obj1 + 1];
      return (double) (num1 + num6 * num9 - num8 * num7) < 0.0;
    }

    [LineNumberTable(new byte[] {82, 103, 108, 102, 108, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private int classifyVertex([In] int obj0)
    {
      short[] indices = this.indices;
      int index1 = (int) indices[this.previousIndex(obj0)] * 2;
      int index2 = (int) indices[obj0] * 2;
      int index3 = (int) indices[this.nextIndex(obj0)] * 2;
      float[] vertices = this.vertices;
      return EarClippingTriangulator.computeSpannedAreaSign(vertices[index1], vertices[index1 + 1], vertices[index2], vertices[index2 + 1], vertices[index3], vertices[index3 + 1]);
    }

    [LineNumberTable(new byte[] {58, 140, 105, 103, 167, 104, 110, 106, 106, 130, 105, 104, 104, 107, 107, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void triangulate()
    {
      int[] items = this.vertexTypes.items;
      while (this.vertexCount > 3)
      {
        int earTip = this.findEarTip();
        this.cutEarTip(earTip);
        int index1 = this.previousIndex(earTip);
        int index2 = earTip != this.vertexCount ? earTip : 0;
        items[index1] = this.classifyVertex(index1);
        items[index2] = this.classifyVertex(index2);
      }
      if (this.vertexCount != 3)
        return;
      ShortSeq triangles = this.triangles;
      short[] indices = this.indices;
      triangles.add(indices[0]);
      triangles.add(indices[1]);
      triangles.add(indices[2]);
    }

    [LineNumberTable(new byte[] {92, 103, 102, 43, 230, 74, 108, 102, 40, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private int findEarTip()
    {
      int vertexCount = this.vertexCount;
      for (int index = 0; index < vertexCount; ++index)
      {
        if (this.isEarTip(index))
          return index;
      }
      int[] items = this.vertexTypes.items;
      for (int index = 0; index < vertexCount; ++index)
      {
        if (items[index] != -1)
          return index;
      }
      return 0;
    }

    [LineNumberTable(new byte[] {160, 83, 103, 135, 111, 105, 143, 109, 109, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void cutEarTip([In] int obj0)
    {
      short[] indices = this.indices;
      ShortSeq triangles = this.triangles;
      triangles.add(indices[this.previousIndex(obj0)]);
      triangles.add(indices[obj0]);
      triangles.add(indices[this.nextIndex(obj0)]);
      int num = (int) this.indicesArray.removeIndex(obj0);
      this.vertexTypes.removeIndex(obj0);
      --this.vertexCount;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    private int previousIndex([In] int obj0) => (obj0 != 0 ? obj0 : this.vertexCount) - 1;

    [LineNumberTable(214)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private int nextIndex([In] int obj0)
    {
      int num = obj0 + 1;
      int vertexCount = this.vertexCount;
      return vertexCount == -1 ? 0 : num % vertexCount;
    }

    [LineNumberTable(new byte[] {3, 108, 111, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static int computeSpannedAreaSign(
      [In] float obj0,
      [In] float obj1,
      [In] float obj2,
      [In] float obj3,
      [In] float obj4,
      [In] float obj5)
    {
      return ByteCodeHelper.f2i(Math.signum(obj0 * (obj5 - obj3) + obj2 * (obj1 - obj5) + obj4 * (obj3 - obj1)));
    }

    [LineNumberTable(new byte[] {110, 108, 136, 104, 104, 103, 103, 103, 103, 104, 112, 112, 208, 177, 106, 104, 103, 201, 116, 116, 246, 52, 239, 81})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool isEarTip([In] int obj0)
    {
      int[] items = this.vertexTypes.items;
      if (items[obj0] == -1)
        return false;
      int index1 = this.previousIndex(obj0);
      int index2 = this.nextIndex(obj0);
      short[] indices = this.indices;
      int index3 = (int) indices[index1] * 2;
      int index4 = (int) indices[obj0] * 2;
      int index5 = (int) indices[index2] * 2;
      float[] vertices = this.vertices;
      float num1 = vertices[index3];
      float num2 = vertices[index3 + 1];
      float num3 = vertices[index4];
      float num4 = vertices[index4 + 1];
      float num5 = vertices[index5];
      float num6 = vertices[index5 + 1];
      for (int index6 = this.nextIndex(index2); index6 != index1; index6 = this.nextIndex(index6))
      {
        if (items[index6] != 1)
        {
          int index7 = (int) indices[index6] * 2;
          float num7 = vertices[index7];
          float num8 = vertices[index7 + 1];
          if (EarClippingTriangulator.computeSpannedAreaSign(num5, num6, num1, num2, num7, num8) >= 0 && EarClippingTriangulator.computeSpannedAreaSign(num1, num2, num3, num4, num7, num8) >= 0 && EarClippingTriangulator.computeSpannedAreaSign(num3, num4, num5, num6, num7, num8) >= 0)
            return false;
        }
      }
      return true;
    }

    [LineNumberTable(new byte[] {159, 166, 200, 107, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public EarClippingTriangulator()
    {
      EarClippingTriangulator clippingTriangulator = this;
      this.indicesArray = new ShortSeq();
      this.vertexTypes = new IntSeq();
      this.triangles = new ShortSeq();
    }

    [LineNumberTable(61)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual ShortSeq computeTriangles(FloatSeq vertices) => this.computeTriangles(vertices.items, 0, vertices.size);

    [LineNumberTable(66)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual ShortSeq computeTriangles(float[] vertices) => this.computeTriangles(vertices, 0, vertices.Length);
  }
}
