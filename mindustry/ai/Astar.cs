// Decompiled with JetBrains decompiler
// Type: mindustry.ai.Astar
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.func;
using arc.math.geom;
using arc.util;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.util;
using java.util.function;
using mindustry.world;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.ai
{
  public class Astar : Object
  {
    internal static Astar.DistanceHeuristic __\u003C\u003Emanhattan;
    [Modifiers]
    [Signature("Larc/struct/Seq<Lmindustry/world/Tile;>;")]
    private static Seq @out;
    [Modifiers]
    [Signature("Larc/struct/PQueue<Lmindustry/world/Tile;>;")]
    private static PQueue queue;
    [Modifiers]
    private static IntFloatMap costs;
    private static byte[][] rotations;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [Signature("(IIIILmindustry/ai/Astar$TileHueristic;Lmindustry/ai/Astar$DistanceHeuristic;Larc/func/Boolf<Lmindustry/world/Tile;>;)Larc/struct/Seq<Lmindustry/world/Tile;>;")]
    [LineNumberTable(new byte[] {159, 170, 139, 105, 137, 146, 106, 106, 124, 108, 127, 14, 191, 35, 99, 111, 113, 121, 106, 99, 133, 116, 127, 0, 127, 3, 122, 108, 110, 114, 118, 116, 127, 12, 115, 237, 54, 235, 79, 133, 139, 138, 99, 106, 140, 119, 127, 9, 130, 138})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Seq pathfind(
      int startX,
      int startY,
      int endX,
      int endY,
      Astar.TileHueristic th,
      Astar.DistanceHeuristic dh,
      Boolf passable)
    {
      Tiles tiles = Vars.world.tiles;
      Tile tile1 = tiles.getn(startX, startY);
      Tile tile2 = tiles.getn(endX, endY);
      GridBits gridBits = new GridBits(tiles.__\u003C\u003Ewidth, tiles.__\u003C\u003Eheight);
      Astar.costs.clear();
      Astar.queue.clear();
      Astar.queue.comparator = Structs.comparingFloat((Floatf) new Astar.__\u003C\u003EAnon0(dh, tile2));
      Astar.queue.add((object) tile1);
      if (Astar.rotations == null || Astar.rotations.Length != Vars.world.width() || Astar.rotations[0].Length != Vars.world.height())
      {
        int num1 = Vars.world.width();
        int num2 = Vars.world.height();
        int[] numArray = new int[2];
        int num3 = num2;
        numArray[1] = num3;
        int num4 = num1;
        numArray[0] = num4;
        // ISSUE: type reference
        Astar.rotations = (byte[][]) ByteCodeHelper.multianewarray(__typeref (byte[][]), numArray);
      }
      int num5 = 0;
label_3:
      while (!Astar.queue.empty())
      {
        Tile from = (Tile) Astar.queue.poll();
        float num1 = Astar.costs.get(from.pos(), 0.0f);
        if (object.ReferenceEquals((object) from, (object) tile2))
        {
          num5 = 1;
          break;
        }
        gridBits.set((int) from.x, (int) from.y);
        Point2[] d4 = Geometry.__\u003C\u003Ed4;
        int length = d4.Length;
        int index = 0;
        while (true)
        {
          if (index < length)
          {
            Point2 point2 = d4[index];
            int x = (int) from.x + point2.x;
            int y = (int) from.y + point2.y;
            if (Structs.inBounds(x, y, tiles.__\u003C\u003Ewidth, tiles.__\u003C\u003Eheight))
            {
              Tile tile3 = tiles.getn(x, y);
              if (passable.get((object) tile3))
              {
                float num2 = th.cost(from, tile3) + num1;
                if (!gridBits.get((int) tile3.x, (int) tile3.y))
                {
                  gridBits.set((int) tile3.x, (int) tile3.y);
                  Astar.rotations[(int) tile3.x][(int) tile3.y] = tile3.relativeTo((int) from.x, (int) from.y);
                  Astar.costs.put(tile3.pos(), num2);
                  Astar.queue.add((object) tile3);
                }
              }
            }
            ++index;
          }
          else
            goto label_3;
        }
      }
      Astar.@out.clear();
      if (num5 == 0)
        return Astar.@out;
      int index1;
      for (Tile tile3 = tile2; !object.ReferenceEquals((object) tile3, (object) tile1); tile3 = tiles.getn((int) tile3.x + Geometry.__\u003C\u003Ed4x[index1], (int) tile3.y + Geometry.__\u003C\u003Ed4y[index1]))
      {
        Astar.@out.add((object) tile3);
        index1 = (int) (sbyte) Astar.rotations[(int) tile3.x][(int) tile3.y];
      }
      Astar.@out.reverse();
      return Astar.@out;
    }

    [Modifiers]
    [LineNumberTable(37)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static float lambda\u0024pathfind\u00242(
      [In] Astar.DistanceHeuristic obj0,
      [In] Tile obj1,
      [In] Tile obj2)
    {
      return Astar.costs.get(obj2.pos(), 0.0f) + obj0.cost((int) obj2.x, (int) obj2.y, (int) obj1.x, (int) obj1.y);
    }

    [Modifiers]
    [LineNumberTable(12)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static float lambda\u0024static\u00240([In] int obj0, [In] int obj1, [In] int obj2, [In] int obj3) => (float) (Math.abs(obj0 - obj2) + Math.abs(obj1 - obj3));

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static int lambda\u0024static\u00241([In] Tile obj0, [In] Tile obj1) => 0;

    [LineNumberTable(11)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Astar()
    {
    }

    [Signature("(Lmindustry/world/Tile;Lmindustry/world/Tile;Lmindustry/ai/Astar$TileHueristic;Larc/func/Boolf<Lmindustry/world/Tile;>;)Larc/struct/Seq<Lmindustry/world/Tile;>;")]
    [LineNumberTable(20)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Seq pathfind(Tile from, Tile to, Astar.TileHueristic th, Boolf passable) => Astar.pathfind((int) from.x, (int) from.y, (int) to.x, (int) to.y, th, Astar.__\u003C\u003Emanhattan, passable);

    [Signature("(IIIILmindustry/ai/Astar$TileHueristic;Larc/func/Boolf<Lmindustry/world/Tile;>;)Larc/struct/Seq<Lmindustry/world/Tile;>;")]
    [LineNumberTable(24)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Seq pathfind(
      int startX,
      int startY,
      int endX,
      int endY,
      Astar.TileHueristic th,
      Boolf passable)
    {
      return Astar.pathfind(startX, startY, endX, endY, th, Astar.__\u003C\u003Emanhattan, passable);
    }

    [LineNumberTable(new byte[] {159, 139, 77, 143, 106, 121})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static Astar()
    {
      if (ByteCodeHelper.isAlreadyInited("mindustry.ai.Astar"))
        return;
      Astar.__\u003C\u003Emanhattan = (Astar.DistanceHeuristic) new Astar.__\u003C\u003EAnon1();
      Astar.@out = new Seq();
      Astar.queue = new PQueue(10000, (Comparator) new Astar.__\u003C\u003EAnon2());
      Astar.costs = new IntFloatMap();
    }

    [Modifiers]
    public static Astar.DistanceHeuristic manhattan
    {
      [HideFromJava] get => Astar.__\u003C\u003Emanhattan;
    }

    public interface DistanceHeuristic
    {
      float cost(int i1, int i2, int i3, int i4);
    }

    public interface TileHueristic
    {
      [Modifiers]
      float cost(Tile from, Tile tile);

      [LineNumberTable(94)]
      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static float \u003Cdefault\u003Ecost([In] Astar.TileHueristic obj0, [In] Tile obj1, [In] Tile obj2) => obj0.cost(obj2);

      float cost(Tile t);

      [HideFromJava]
      static class __DefaultMethods
      {
        public static float cost([In] Astar.TileHueristic obj0, [In] Tile obj1, [In] Tile obj2)
        {
          Astar.TileHueristic tileHueristic = obj0;
          // ISSUE: virtual method pointer
          IntPtr num = __vmethodptr(tileHueristic, ToString);
          return Astar.TileHueristic.\u003Cdefault\u003Ecost(tileHueristic, obj1, obj2);
        }
      }
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Floatf
    {
      private readonly Astar.DistanceHeuristic arg\u00241;
      private readonly Tile arg\u00242;

      internal __\u003C\u003EAnon0([In] Astar.DistanceHeuristic obj0, [In] Tile obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public float get([In] object obj0) => Astar.lambda\u0024pathfind\u00242(this.arg\u00241, this.arg\u00242, (Tile) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Astar.DistanceHeuristic
    {
      internal __\u003C\u003EAnon1()
      {
      }

      public float cost([In] int obj0, [In] int obj1, [In] int obj2, [In] int obj3) => Astar.lambda\u0024static\u00240(obj0, obj1, obj2, obj3);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon2 : Comparator
    {
      internal __\u003C\u003EAnon2()
      {
      }

      public int compare([In] object obj0, [In] object obj1) => Astar.lambda\u0024static\u00241((Tile) obj0, (Tile) obj1);

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
