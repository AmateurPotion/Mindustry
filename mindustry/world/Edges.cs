// Decompiled with JetBrains decompiler
// Type: mindustry.world.Edges
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.math;
using arc.math.geom;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.util;
using java.util.function;
using mindustry.gen;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.world
{
  public class Edges : Object
  {
    private const int maxRadius = 12;
    private static Point2[][] edges;
    private static Point2[][] edgeInside;
    private static Vec2[][] polygons;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {24, 153})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Point2[] getEdges(int size)
    {
      if (size < 0 || size > 16)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new RuntimeException("Block size must be between 0 and 16");
      }
      return Edges.edges[size - 1];
    }

    [LineNumberTable(new byte[] {11, 117, 103, 127, 16, 38})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Tile getFacingEdge(Block block, int tilex, int tiley, Tile other)
    {
      if (!block.isMultiblock())
        return Vars.world.tile(tilex, tiley);
      int size = block.size;
      return Vars.world.tile(tilex + Mathf.clamp((int) other.x - tilex, -(size - 1) / 2, size / 2), tiley + Mathf.clamp((int) other.y - tiley, -(size - 1) / 2, size / 2));
    }

    [LineNumberTable(53)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Tile getFacingEdge(Building tile, Building other) => Edges.getFacingEdge(tile.block, tile.tileX(), tile.tileY(), other.tile());

    [LineNumberTable(57)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Tile getFacingEdge(Tile tile, Tile other) => Edges.getFacingEdge(tile.block, (int) tile.x, (int) tile.y, other);

    [LineNumberTable(new byte[] {30, 153})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Point2[] getInsideEdges(int size)
    {
      if (size < 0 || size > 16)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new RuntimeException("Block size must be between 0 and 16");
      }
      return Edges.edgeInside[size - 1];
    }

    [Modifiers]
    [LineNumberTable(40)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static int lambda\u0024static\u00240([In] Point2 obj0, [In] Point2 obj1) => Float.compare(Mathf.angle((float) obj0.x, (float) obj0.y), Mathf.angle((float) obj1.x, (float) obj1.y));

    [LineNumberTable(11)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Edges()
    {
    }

    [LineNumberTable(new byte[] {18, 114, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Vec2[] getPixelPolygon(float radius)
    {
      if ((double) radius < 1.0 || (double) radius > 12.0)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new RuntimeException("Polygon size must be between 1 and 12");
      }
      return Edges.polygons[ByteCodeHelper.f2i(radius * 2f) - 1];
    }

    [LineNumberTable(new byte[] {159, 139, 109, 127, 10, 127, 10, 191, 10, 103, 55, 198, 106, 114, 121, 145, 131, 141, 156, 157, 156, 253, 56, 235, 75, 150, 148, 114, 108, 127, 69, 235, 61, 235, 42, 233, 92})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static Edges()
    {
      if (ByteCodeHelper.isAlreadyInited("mindustry.world.Edges"))
        return;
      int[] numArray1 = new int[2];
      int num1 = 0;
      numArray1[1] = num1;
      int num2 = 16;
      numArray1[0] = num2;
      // ISSUE: type reference
      Edges.edges = (Point2[][]) ByteCodeHelper.multianewarray(__typeref (Point2[][]), numArray1);
      int[] numArray2 = new int[2];
      int num3 = 0;
      numArray2[1] = num3;
      int num4 = 16;
      numArray2[0] = num4;
      // ISSUE: type reference
      Edges.edgeInside = (Point2[][]) ByteCodeHelper.multianewarray(__typeref (Point2[][]), numArray2);
      int[] numArray3 = new int[2];
      int num5 = 0;
      numArray3[1] = num5;
      int num6 = 24;
      numArray3[0] = num6;
      // ISSUE: type reference
      Edges.polygons = (Vec2[][]) ByteCodeHelper.multianewarray(__typeref (Vec2[][]), numArray3);
      for (int index = 0; index < 24; ++index)
        Edges.polygons[index] = Geometry.pixelCircle((float) (index + 1) / 2f);
      for (int index1 = 0; index1 < 16; ++index1)
      {
        int num7 = -ByteCodeHelper.f2i((float) index1 / 2f) - 1;
        int num8 = ByteCodeHelper.f2i((float) index1 / 2f + 0.5f) + 1;
        Edges.edges[index1] = new Point2[(index1 + 1) * 4];
        int num9 = 0;
        for (int index2 = 0; index2 < index1 + 1; ++index2)
        {
          Point2[] edge1 = Edges.edges[index1];
          int index3 = num9;
          int num10 = num9 + 1;
          Point2 point2_1 = new Point2(num7 + 1 + index2, num7);
          edge1[index3] = point2_1;
          Point2[] edge2 = Edges.edges[index1];
          int index4 = num10;
          int num11 = num10 + 1;
          Point2 point2_2 = new Point2(num7 + 1 + index2, num8);
          edge2[index4] = point2_2;
          Point2[] edge3 = Edges.edges[index1];
          int index5 = num11;
          int num12 = num11 + 1;
          Point2 point2_3 = new Point2(num7, num7 + index2 + 1);
          edge3[index5] = point2_3;
          Point2[] edge4 = Edges.edges[index1];
          int index6 = num12;
          num9 = num12 + 1;
          Point2 point2_4 = new Point2(num8, num7 + index2 + 1);
          edge4[index6] = point2_4;
        }
        Arrays.sort((object[]) Edges.edges[index1], (Comparator) new Edges.__\u003C\u003EAnon0());
        Edges.edgeInside[index1] = new Point2[Edges.edges[index1].Length];
        for (int index2 = 0; index2 < Edges.edges[index1].Length; ++index2)
        {
          Point2 point2 = Edges.edges[index1][index2];
          Edges.edgeInside[index1][index2] = new Point2(Mathf.clamp(point2.x, -ByteCodeHelper.f2i((float) index1 / 2f), ByteCodeHelper.f2i((float) index1 / 2f + 0.5f)), Mathf.clamp(point2.y, -ByteCodeHelper.f2i((float) index1 / 2f), ByteCodeHelper.f2i((float) index1 / 2f + 0.5f)));
        }
      }
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Comparator
    {
      internal __\u003C\u003EAnon0()
      {
      }

      public int compare([In] object obj0, [In] object obj1) => Edges.lambda\u0024static\u00240((Point2) obj0, (Point2) obj1);

      [SpecialName]
      public Comparator thenComparing([In] Comparator obj0) => Comparator.\u003Cdefault\u003EthenComparing((Comparator) this, obj0);

      [SpecialName]
      public bool equals([In] object obj0) => Object.instancehelper_equals((object) this, obj0);

      [SpecialName]
      public Comparator reversed() => Comparator.\u003Cdefault\u003Ereversed((Comparator) this);

      [SpecialName]
      public Comparator thenComparing([In] Function obj0, [In] Comparator obj1) => Comparator.\u003Cdefault\u003EthenComparing((Comparator) this, obj0, obj1);

      [SpecialName]
      public Comparator thenComparing([In] Function obj0) => Comparator.\u003Cdefault\u003EthenComparing((Comparator) this, obj0);

      [SpecialName]
      public Comparator thenComparingInt([In] ToIntFunction obj0) => Comparator.\u003Cdefault\u003EthenComparingInt((Comparator) this, obj0);

      [SpecialName]
      public Comparator thenComparingLong([In] ToLongFunction obj0) => Comparator.\u003Cdefault\u003EthenComparingLong((Comparator) this, obj0);

      [SpecialName]
      public Comparator thenComparingDouble([In] ToDoubleFunction obj0) => Comparator.\u003Cdefault\u003EthenComparingDouble((Comparator) this, obj0);
    }
  }
}
