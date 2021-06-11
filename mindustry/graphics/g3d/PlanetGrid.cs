// Decompiled with JetBrains decompiler
// Type: mindustry.graphics.g3d.PlanetGrid
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.math;
using arc.math.geom;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.graphics.g3d
{
  public class PlanetGrid : Object
  {
    [Modifiers]
    private static PlanetGrid[] cache;
    private const float x = -0.5257311f;
    private const float z = -0.8506508f;
    [Modifiers]
    private static Vec3[] iTiles;
    [Modifiers]
    private static int[][] iTilesP;
    public int size;
    public PlanetGrid.Ptile[] tiles;
    public PlanetGrid.Corner[] corners;
    public PlanetGrid.Edge[] edges;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {2, 114, 200, 99, 136, 206, 105, 168})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static PlanetGrid create(int size)
    {
      if (size < PlanetGrid.cache.Length && PlanetGrid.cache[size] != null)
        return PlanetGrid.cache[size];
      PlanetGrid planetGrid = size != 0 ? PlanetGrid.subdividedGrid(PlanetGrid.create(size - 1)) : PlanetGrid.initialGrid();
      if (size < PlanetGrid.cache.Length)
        PlanetGrid.cache[size] = planetGrid;
      return planetGrid;
    }

    [LineNumberTable(212)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static int tileCount([In] int obj0) => 10 * Mathf.pow(3, obj0) + 2;

    [LineNumberTable(216)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static int cornerCount([In] int obj0) => 20 * Mathf.pow(3, obj0);

    [LineNumberTable(220)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static int edgeCount([In] int obj0) => 30 * Mathf.pow(3, obj0);

    [LineNumberTable(new byte[] {22, 135, 120, 116, 104, 63, 2, 8, 233, 70, 104, 63, 11, 168, 104, 63, 13, 168, 108, 108, 108, 108, 108, 109, 108, 108, 107, 171, 123, 104, 63, 25, 40, 233, 70, 99, 126, 104, 108, 31, 6, 40, 235, 71})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static PlanetGrid initialGrid()
    {
      PlanetGrid planetGrid1 = new PlanetGrid(0);
      PlanetGrid.Ptile[] tiles1 = planetGrid1.tiles;
      int length1 = tiles1.Length;
      for (int index1 = 0; index1 < length1; ++index1)
      {
        PlanetGrid.Ptile ptile = tiles1[index1];
        ptile.v = PlanetGrid.iTiles[ptile.id];
        for (int index2 = 0; index2 < 5; ++index2)
          ptile.tiles[index2] = planetGrid1.tiles[PlanetGrid.iTilesP[ptile.id][index2]];
      }
      for (int index1 = 0; index1 < 5; ++index1)
      {
        int num1 = index1;
        PlanetGrid planetGrid2 = planetGrid1;
        int[] numArray = PlanetGrid.iTilesP[0];
        int num2 = index1 + 4;
        int num3 = 5;
        int index2 = num3 != -1 ? num2 % num3 : 0;
        int num4 = numArray[index2];
        int num5 = PlanetGrid.iTilesP[0][index1];
        PlanetGrid.addCorner(num1, planetGrid2, 0, num4, num5);
      }
      for (int index1 = 0; index1 < 5; ++index1)
      {
        int num1 = index1 + 5;
        PlanetGrid planetGrid2 = planetGrid1;
        int[] numArray = PlanetGrid.iTilesP[3];
        int num2 = index1 + 4;
        int num3 = 5;
        int index2 = num3 != -1 ? num2 % num3 : 0;
        int num4 = numArray[index2];
        int num5 = PlanetGrid.iTilesP[3][index1];
        PlanetGrid.addCorner(num1, planetGrid2, 3, num4, num5);
      }
      PlanetGrid.addCorner(10, planetGrid1, 10, 1, 8);
      PlanetGrid.addCorner(11, planetGrid1, 1, 10, 6);
      PlanetGrid.addCorner(12, planetGrid1, 6, 10, 7);
      PlanetGrid.addCorner(13, planetGrid1, 6, 7, 11);
      PlanetGrid.addCorner(14, planetGrid1, 11, 7, 2);
      PlanetGrid.addCorner(15, planetGrid1, 11, 2, 9);
      PlanetGrid.addCorner(16, planetGrid1, 9, 2, 5);
      PlanetGrid.addCorner(17, planetGrid1, 9, 5, 4);
      PlanetGrid.addCorner(18, planetGrid1, 4, 5, 8);
      PlanetGrid.addCorner(19, planetGrid1, 4, 8, 1);
      PlanetGrid.Corner[] corners1 = planetGrid1.corners;
      int length2 = corners1.Length;
      for (int index1 = 0; index1 < length2; ++index1)
      {
        PlanetGrid.Corner corner1 = corners1[index1];
        for (int index2 = 0; index2 < 3; ++index2)
        {
          PlanetGrid.Corner[] corners2 = corner1.corners;
          int index3 = index2;
          PlanetGrid.Corner[] corners3 = corner1.tiles[index2].corners;
          int num1 = PlanetGrid.pos(corner1.tiles[index2], corner1) + 1;
          int num2 = 5;
          int index4 = num2 != -1 ? num1 % num2 : 0;
          PlanetGrid.Corner corner2 = corners3[index4];
          corners2[index3] = corner2;
        }
      }
      int num6 = 0;
      PlanetGrid.Ptile[] tiles2 = planetGrid1.tiles;
      int length3 = tiles2.Length;
      for (int index1 = 0; index1 < length3; ++index1)
      {
        PlanetGrid.Ptile ptile = tiles2[index1];
        for (int index2 = 0; index2 < 5; ++index2)
        {
          if (ptile.edges[index2] == null)
          {
            int num1 = num6;
            ++num6;
            PlanetGrid planetGrid2 = planetGrid1;
            int id = ptile.id;
            int num2 = PlanetGrid.iTilesP[ptile.id][index2];
            PlanetGrid.addEdge(num1, planetGrid2, id, num2);
          }
        }
      }
      return planetGrid1;
    }

    [LineNumberTable(new byte[] {66, 142, 104, 168, 105, 122, 148, 31, 15, 8, 233, 72, 105, 124, 107, 127, 19, 31, 19, 11, 233, 72, 98, 127, 1, 112, 110, 127, 40, 4, 11, 235, 72, 127, 1, 104, 63, 39, 40, 235, 70, 99, 127, 1, 110, 108, 126, 230, 61, 40, 235, 73})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static PlanetGrid subdividedGrid(PlanetGrid prev)
    {
      PlanetGrid planetGrid1 = new PlanetGrid(prev.size + 1);
      int length1 = prev.tiles.Length;
      int length2 = prev.corners.Length;
      for (int index1 = 0; index1 < length1; ++index1)
      {
        planetGrid1.tiles[index1].v = prev.tiles[index1].v;
        for (int index2 = 0; index2 < planetGrid1.tiles[index1].edgeCount; ++index2)
          planetGrid1.tiles[index1].tiles[index2] = planetGrid1.tiles[prev.tiles[index1].corners[index2].id + length1];
      }
      for (int index1 = 0; index1 < length2; ++index1)
      {
        planetGrid1.tiles[index1 + length1].v = prev.corners[index1].v;
        for (int index2 = 0; index2 < 3; ++index2)
        {
          planetGrid1.tiles[index1 + length1].tiles[2 * index2] = planetGrid1.tiles[prev.corners[index1].corners[index2].id + length1];
          planetGrid1.tiles[index1 + length1].tiles[2 * index2 + 1] = planetGrid1.tiles[prev.corners[index1].tiles[index2].id];
        }
      }
      int num1 = 0;
      PlanetGrid.Ptile[] tiles1 = prev.tiles;
      int length3 = tiles1.Length;
      for (int index1 = 0; index1 < length3; ++index1)
      {
        PlanetGrid.Ptile ptile = tiles1[index1];
        PlanetGrid.Ptile tile = planetGrid1.tiles[ptile.id];
        for (int index2 = 0; index2 < tile.edgeCount; ++index2)
        {
          int num2 = num1;
          PlanetGrid planetGrid2 = planetGrid1;
          int id1 = tile.id;
          PlanetGrid.Ptile[] tiles2 = tile.tiles;
          int num3 = index2 + tile.edgeCount - 1;
          int edgeCount = tile.edgeCount;
          int index3 = edgeCount != -1 ? num3 % edgeCount : 0;
          int id2 = tiles2[index3].id;
          int id3 = tile.tiles[index2].id;
          PlanetGrid.addCorner(num2, planetGrid2, id1, id2, id3);
          ++num1;
        }
      }
      PlanetGrid.Corner[] corners1 = planetGrid1.corners;
      int length4 = corners1.Length;
      for (int index1 = 0; index1 < length4; ++index1)
      {
        PlanetGrid.Corner corner1 = corners1[index1];
        for (int index2 = 0; index2 < 3; ++index2)
        {
          PlanetGrid.Corner[] corners2 = corner1.corners;
          int index3 = index2;
          PlanetGrid.Corner[] corners3 = corner1.tiles[index2].corners;
          int num2 = PlanetGrid.pos(corner1.tiles[index2], corner1) + 1;
          int edgeCount = corner1.tiles[index2].edgeCount;
          int index4 = edgeCount != -1 ? num2 % edgeCount : 0;
          PlanetGrid.Corner corner2 = corners3[index4];
          corners2[index3] = corner2;
        }
      }
      int num4 = 0;
      PlanetGrid.Ptile[] tiles3 = planetGrid1.tiles;
      int length5 = tiles3.Length;
      for (int index1 = 0; index1 < length5; ++index1)
      {
        PlanetGrid.Ptile ptile = tiles3[index1];
        for (int index2 = 0; index2 < ptile.edgeCount; ++index2)
        {
          if (ptile.edges[index2] == null)
          {
            PlanetGrid.addEdge(num4, planetGrid1, ptile.id, ptile.tiles[index2].id);
            ++num4;
          }
        }
      }
      return planetGrid1;
    }

    [LineNumberTable(new byte[] {159, 173, 104, 135, 113, 108, 55, 198, 113, 108, 46, 198, 113, 108, 46, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal PlanetGrid(int size)
    {
      PlanetGrid planetGrid = this;
      this.size = size;
      this.tiles = new PlanetGrid.Ptile[PlanetGrid.tileCount(size)];
      for (int id = 0; id < this.tiles.Length; ++id)
        this.tiles[id] = new PlanetGrid.Ptile(id, id >= 12 ? 6 : 5);
      this.corners = new PlanetGrid.Corner[PlanetGrid.cornerCount(size)];
      for (int id = 0; id < this.corners.Length; ++id)
        this.corners[id] = new PlanetGrid.Corner(id);
      this.edges = new PlanetGrid.Edge[PlanetGrid.edgeCount(size)];
      for (int id = 0; id < this.edges.Length; ++id)
        this.edges[id] = new PlanetGrid.Edge(id);
    }

    [LineNumberTable(new byte[] {117, 105, 127, 10, 127, 20, 102, 127, 3, 11, 198})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static void addCorner([In] int obj0, [In] PlanetGrid obj1, [In] int obj2, [In] int obj3, [In] int obj4)
    {
      PlanetGrid.Corner corner1 = obj1.corners[obj0];
      PlanetGrid.Ptile[] ptileArray1 = new PlanetGrid.Ptile[3]
      {
        obj1.tiles[obj2],
        obj1.tiles[obj3],
        obj1.tiles[obj4]
      };
      corner1.v.set(ptileArray1[0].v).add(ptileArray1[1].v).add(ptileArray1[2].v).nor();
      for (int index1 = 0; index1 < 3; ++index1)
      {
        PlanetGrid.Corner[] corners = ptileArray1[index1].corners;
        PlanetGrid.Ptile ptile1 = ptileArray1[index1];
        PlanetGrid.Ptile[] ptileArray2 = ptileArray1;
        int num1 = index1 + 2;
        int num2 = 3;
        int index2 = num2 != -1 ? num1 % num2 : 0;
        PlanetGrid.Ptile ptile2 = ptileArray2[index2];
        int index3 = PlanetGrid.pos(ptile1, ptile2);
        PlanetGrid.Corner corner2 = corner1;
        corners[index3] = corner2;
        corner1.tiles[index1] = ptileArray1[index1];
      }
    }

    [LineNumberTable(new byte[] {160, 84, 107, 50, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static int pos([In] PlanetGrid.Ptile obj0, [In] PlanetGrid.Corner obj1)
    {
      for (int index = 0; index < obj0.edgeCount; ++index)
      {
        if (object.ReferenceEquals((object) obj0.corners[index], (object) obj1))
          return index;
      }
      return -1;
    }

    [LineNumberTable(new byte[] {127, 105, 125, 124, 127, 4, 127, 3, 105, 127, 3, 107, 127, 3, 235, 60, 233, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static void addEdge([In] int obj0, [In] PlanetGrid obj1, [In] int obj2, [In] int obj3)
    {
      PlanetGrid.Edge edge1 = obj1.edges[obj0];
      PlanetGrid.Ptile[] ptileArray1 = new PlanetGrid.Ptile[2]
      {
        obj1.tiles[obj2],
        obj1.tiles[obj3]
      };
      PlanetGrid.Corner[] cornerArray1 = new PlanetGrid.Corner[2]
      {
        obj1.corners[ptileArray1[0].corners[PlanetGrid.pos(ptileArray1[0], ptileArray1[1])].id],
        null
      };
      PlanetGrid.Corner[] corners1 = obj1.corners;
      PlanetGrid.Corner[] corners2 = ptileArray1[0].corners;
      int num1 = PlanetGrid.pos(ptileArray1[0], ptileArray1[1]) + 1;
      int edgeCount = ptileArray1[0].edgeCount;
      int index1 = edgeCount != -1 ? num1 % edgeCount : 0;
      int id = corners2[index1].id;
      cornerArray1[1] = corners1[id];
      PlanetGrid.Corner[] cornerArray2 = cornerArray1;
      for (int index2 = 0; index2 < 2; ++index2)
      {
        PlanetGrid.Edge[] edges1 = ptileArray1[index2].edges;
        PlanetGrid.Ptile ptile1 = ptileArray1[index2];
        PlanetGrid.Ptile[] ptileArray2 = ptileArray1;
        int num2 = index2 + 1;
        int num3 = 2;
        int index3 = num3 != -1 ? num2 % num3 : 0;
        PlanetGrid.Ptile ptile2 = ptileArray2[index3];
        int index4 = PlanetGrid.pos(ptile1, ptile2);
        PlanetGrid.Edge edge2 = edge1;
        edges1[index4] = edge2;
        edge1.tiles[index2] = ptileArray1[index2];
        PlanetGrid.Edge[] edges2 = cornerArray2[index2].edges;
        PlanetGrid.Corner corner1 = cornerArray2[index2];
        PlanetGrid.Corner[] cornerArray3 = cornerArray2;
        int num4 = index2 + 1;
        int num5 = 2;
        int index5 = num5 != -1 ? num4 % num5 : 0;
        PlanetGrid.Corner corner2 = cornerArray3[index5];
        int index6 = PlanetGrid.pos(corner1, corner2);
        PlanetGrid.Edge edge3 = edge1;
        edges2[index6] = edge3;
        edge1.corners[index2] = cornerArray2[index2];
      }
    }

    [LineNumberTable(new byte[] {160, 77, 107, 50, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static int pos([In] PlanetGrid.Ptile obj0, [In] PlanetGrid.Ptile obj1)
    {
      for (int index = 0; index < obj0.edgeCount; ++index)
      {
        if (object.ReferenceEquals((object) obj0.tiles[index], (object) obj1))
          return index;
      }
      return -1;
    }

    [LineNumberTable(new byte[] {160, 91, 102, 50, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static int pos([In] PlanetGrid.Corner obj0, [In] PlanetGrid.Corner obj1)
    {
      for (int index = 0; index < 3; ++index)
      {
        if (object.ReferenceEquals((object) obj0.corners[index], (object) obj1))
          return index;
      }
      return -1;
    }

    [LineNumberTable(new byte[] {159, 140, 77, 236, 69, 255, 160, 196, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static PlanetGrid()
    {
      if (ByteCodeHelper.isAlreadyInited("mindustry.graphics.g3d.PlanetGrid"))
        return;
      PlanetGrid.cache = new PlanetGrid[10];
      PlanetGrid.iTiles = new Vec3[12]
      {
        new Vec3(0.5257311f, 0.0f, -0.8506508f),
        new Vec3(-0.5257311f, 0.0f, -0.8506508f),
        new Vec3(0.5257311f, 0.0f, 0.8506508f),
        new Vec3(-0.5257311f, 0.0f, 0.8506508f),
        new Vec3(0.0f, -0.8506508f, -0.5257311f),
        new Vec3(0.0f, -0.8506508f, 0.5257311f),
        new Vec3(0.0f, 0.8506508f, -0.5257311f),
        new Vec3(0.0f, 0.8506508f, 0.5257311f),
        new Vec3(-0.8506508f, -0.5257311f, 0.0f),
        new Vec3(0.8506508f, -0.5257311f, 0.0f),
        new Vec3(-0.8506508f, 0.5257311f, 0.0f),
        new Vec3(0.8506508f, 0.5257311f, 0.0f)
      };
      PlanetGrid.iTilesP = new int[12][]
      {
        new int[5]{ 9, 4, 1, 6, 11 },
        new int[5]{ 4, 8, 10, 6, 0 },
        new int[5]{ 11, 7, 3, 5, 9 },
        new int[5]{ 2, 7, 10, 8, 5 },
        new int[5]{ 9, 5, 8, 1, 0 },
        new int[5]{ 2, 3, 8, 4, 9 },
        new int[5]{ 0, 1, 10, 7, 11 },
        new int[5]{ 11, 6, 10, 3, 2 },
        new int[5]{ 5, 3, 10, 1, 4 },
        new int[5]{ 2, 5, 4, 0, 11 },
        new int[5]{ 3, 7, 6, 1, 8 },
        new int[5]{ 7, 2, 9, 0, 6 }
      };
    }

    public class Corner : Object
    {
      public int id;
      public PlanetGrid.Ptile[] tiles;
      public PlanetGrid.Corner[] corners;
      public PlanetGrid.Edge[] edges;
      public Vec3 v;

      [LineNumberTable(new byte[] {160, 136, 232, 59, 108, 108, 108, 171, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public Corner(int id)
      {
        PlanetGrid.Corner corner = this;
        this.tiles = new PlanetGrid.Ptile[3];
        this.corners = new PlanetGrid.Corner[3];
        this.edges = new PlanetGrid.Edge[3];
        this.v = new Vec3();
        this.id = id;
      }
    }

    public class Edge : Object
    {
      public int id;
      public PlanetGrid.Ptile[] tiles;
      public PlanetGrid.Corner[] corners;

      [LineNumberTable(new byte[] {160, 146, 232, 61, 108, 172, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public Edge(int id)
      {
        PlanetGrid.Edge edge = this;
        this.tiles = new PlanetGrid.Ptile[2];
        this.corners = new PlanetGrid.Corner[2];
        this.id = id;
      }
    }

    public class Ptile : Object
    {
      public int id;
      public int edgeCount;
      public PlanetGrid.Ptile[] tiles;
      public PlanetGrid.Corner[] corners;
      public PlanetGrid.Edge[] edges;
      public Vec3 v;

      [LineNumberTable(new byte[] {160, 119, 8, 171, 103, 135, 108, 108, 108})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public Ptile(int id, int edgeCount)
      {
        PlanetGrid.Ptile ptile = this;
        this.v = new Vec3();
        this.id = id;
        this.edgeCount = edgeCount;
        this.tiles = new PlanetGrid.Ptile[edgeCount];
        this.corners = new PlanetGrid.Corner[edgeCount];
        this.edges = new PlanetGrid.Edge[edgeCount];
      }
    }
  }
}
