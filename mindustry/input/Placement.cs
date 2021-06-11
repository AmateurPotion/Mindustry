// Decompiled with JetBrains decompiler
// Type: mindustry.input.Placement
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.@struct;
using arc.func;
using arc.math;
using arc.math.geom;
using arc.util.pooling;
using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.util;
using java.util.function;
using mindustry.entities.units;
using mindustry.game;
using mindustry.gen;
using mindustry.world;
using mindustry.world.blocks.distribution;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.input
{
  public class Placement : Object
  {
    [Modifiers]
    [Signature("Larc/struct/Seq<Lmindustry/entities/units/BuildPlan;>;")]
    private static Seq plans1;
    [Modifiers]
    [Signature("Larc/struct/Seq<Larc/math/geom/Point2;>;")]
    private static Seq tmpPoints;
    [Modifiers]
    [Signature("Larc/struct/Seq<Larc/math/geom/Point2;>;")]
    private static Seq tmpPoints2;
    [Modifiers]
    private static Placement.NormalizeResult result;
    [Modifiers]
    private static Placement.NormalizeDrawResult drawResult;
    [Modifiers]
    private static Bresenham2 bres;
    [Modifiers]
    [Signature("Larc/struct/Seq<Larc/math/geom/Point2;>;")]
    private static Seq points;
    [Modifiers]
    private static IntFloatMap costs;
    [Modifiers]
    private static IntIntMap parents;
    [Modifiers]
    private static IntSet closed;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [Signature("(Larc/struct/Seq<Lmindustry/entities/units/BuildPlan;>;Lmindustry/world/blocks/distribution/ItemBridge;)V")]
    [LineNumberTable(new byte[] {63, 127, 45, 161, 171, 107, 107, 191, 72, 112, 111, 168, 191, 23, 115, 175, 159, 5, 108, 51, 168, 100, 101, 141, 104, 104, 99, 159, 13, 191, 11, 100, 229, 42, 235, 91, 112, 51, 168, 130, 134, 133, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void calculateBridges(Seq plans, ItemBridge bridge)
    {
      if (((BuildPlan) plans.first()).x != ((BuildPlan) plans.peek()).x && ((BuildPlan) plans.first()).y != ((BuildPlan) plans.peek()).y || !bridge.unlockedNow())
        return;
      Boolf boolf = (Boolf) new Placement.__\u003C\u003EAnon2();
      Seq array = Placement.plans1.clear();
      Team team = Vars.player.team();
      int num = ((BuildPlan) plans.first()).tile() == null || (int) (sbyte) ((BuildPlan) plans.first()).tile().absoluteRelativeTo(((BuildPlan) plans.peek()).x, ((BuildPlan) plans.peek()).y) != Mathf.mod(((BuildPlan) plans.first()).rotation + 2, 4) ? 0 : 1;
      int index1 = 0;
label_2:
      while (index1 < plans.size)
      {
        BuildPlan buildPlan1 = (BuildPlan) plans.get(index1);
        array.add((object) buildPlan1);
        if (index1 < plans.size - 1 && boolf.get((object) buildPlan1) && !boolf.get((object) (BuildPlan) plans.get(index1 + 1)))
        {
          for (int index2 = index1 + 1; index2 < plans.size; ++index2)
          {
            BuildPlan buildPlan2 = (BuildPlan) plans.get(index2);
            if (!bridge.positionsValid(buildPlan1.x, buildPlan1.y, buildPlan2.x, buildPlan2.y))
            {
              for (int index3 = index1 + 1; index3 < index2; ++index3)
                array.add((object) (BuildPlan) plans.get(index3));
              index1 = index2;
              goto label_2;
            }
            else if (buildPlan2.placeable(team))
            {
              buildPlan1.block = (Block) bridge;
              buildPlan2.block = (Block) bridge;
              if (num != 0)
                buildPlan2.config = (object) new Point2(buildPlan1.x - buildPlan2.x, buildPlan1.y - buildPlan2.y);
              else
                buildPlan1.config = (object) new Point2(buildPlan2.x - buildPlan1.x, buildPlan2.y - buildPlan1.y);
              index1 = index2;
              goto label_2;
            }
          }
          for (int index2 = index1 + 1; index2 < plans.size; ++index2)
            array.add((object) (BuildPlan) plans.get(index2));
          break;
        }
        ++index1;
      }
      plans.set(array);
    }

    [Signature("(Larc/struct/Seq<Larc/math/geom/Point2;>;Lmindustry/world/Block;ILarc/func/Boolf2<Larc/math/geom/Point2;Larc/math/geom/Point2;>;)V")]
    [LineNumberTable(new byte[] {27, 102, 139, 117, 162, 110, 110, 104, 173, 111, 111, 140, 132, 99, 229, 57, 232, 76, 100, 133, 156, 103, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void calculateNodes(Seq points, Block block, int rotation, Boolf2 overlapper)
    {
      Seq tmpPoints2 = Placement.tmpPoints2;
      Seq array = Placement.tmpPoints.clear();
      tmpPoints2.selectFrom(points, (Boolf) new Placement.__\u003C\u003EAnon1(points, block, rotation));
      int num = 0;
      int index1 = 0;
label_1:
      while (index1 < tmpPoints2.size)
      {
        Point2 point2_1 = (Point2) tmpPoints2.get(index1);
        array.add((object) point2_1);
        if (index1 == tmpPoints2.size - 1)
          num = 1;
        for (int index2 = tmpPoints2.size - 1; index2 > index1; index2 += -1)
        {
          Point2 point2_2 = (Point2) tmpPoints2.get(index2);
          if (overlapper.get((object) point2_1, (object) point2_2))
          {
            index1 = index2;
            goto label_1;
          }
        }
        ++index1;
      }
      if (num == 0 && !tmpPoints2.isEmpty())
        array.add((object) (Point2) tmpPoints2.peek());
      points.clear();
      points.addAll(array);
    }

    [LineNumberTable(new byte[] {159, 66, 131, 99, 114, 133, 195, 108, 176, 108, 176, 136, 110, 100, 133, 133, 110, 100, 133, 195, 100, 98, 99, 131, 100, 98, 99, 163, 107, 107, 107, 107, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Placement.NormalizeResult normalizeArea(
      int tilex,
      int tiley,
      int endx,
      int endy,
      int rotation,
      bool snap,
      int maxLength)
    {
      if (snap)
      {
        if (Math.abs(tilex - endx) > Math.abs(tiley - endy))
          endy = tiley;
        else
          endx = tilex;
      }
      if (Math.abs(endx - tilex) > maxLength)
        endx = Mathf.sign((float) (endx - tilex)) * maxLength + tilex;
      if (Math.abs(endy - tiley) > maxLength)
        endy = Mathf.sign((float) (endy - tiley)) * maxLength + tiley;
      int num1 = endx - tilex;
      int num2 = endy - tiley;
      if (Math.abs(num1) > Math.abs(num2))
        rotation = num1 < 0 ? 2 : 0;
      else if (Math.abs(num1) < Math.abs(num2))
        rotation = num2 < 0 ? 3 : 1;
      if (endx < tilex)
      {
        int num3 = endx;
        endx = tilex;
        tilex = num3;
      }
      if (endy < tiley)
      {
        int num3 = endy;
        endy = tiley;
        tiley = num3;
      }
      Placement.result.x2 = endx;
      Placement.result.y2 = endy;
      Placement.result.x = tilex;
      Placement.result.y = tiley;
      Placement.result.rotation = rotation;
      return Placement.result;
    }

    [LineNumberTable(new byte[] {159, 75, 131, 143, 135, 119, 119, 119, 151, 127, 13, 191, 13, 127, 13, 159, 13, 115, 115, 115, 147})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Placement.NormalizeDrawResult normalizeDrawArea(
      Block block,
      int startx,
      int starty,
      int endx,
      int endy,
      bool snap,
      int maxLength,
      float scaling)
    {
      int num = snap ? 1 : 0;
      Placement.normalizeArea(startx, starty, endx, endy, 0, num != 0, maxLength);
      float offset = block.offset;
      Placement.drawResult.x = (float) (Placement.result.x * 8);
      Placement.drawResult.y = (float) (Placement.result.y * 8);
      Placement.drawResult.x2 = (float) (Placement.result.x2 * 8);
      Placement.drawResult.y2 = (float) (Placement.result.y2 * 8);
      Placement.drawResult.x -= (float) block.size * scaling * 8f / 2f;
      Placement.drawResult.x2 += (float) block.size * scaling * 8f / 2f;
      Placement.drawResult.y -= (float) block.size * scaling * 8f / 2f;
      Placement.drawResult.y2 += (float) block.size * scaling * 8f / 2f;
      Placement.drawResult.x += offset;
      Placement.drawResult.y += offset;
      Placement.drawResult.x2 += offset;
      Placement.drawResult.y2 += offset;
      return Placement.drawResult;
    }

    [Signature("(IIII)Larc/struct/Seq<Larc/math/geom/Point2;>;")]
    [LineNumberTable(new byte[] {12, 106, 106, 107, 109, 127, 11, 127, 55, 115, 103, 159, 36})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Seq upgradeLine(int startX, int startY, int endX, int endY)
    {
      Placement.closed.clear();
      Pools.freeAll(Placement.points);
      Placement.points.clear();
      Building building1 = Vars.world.build(startX, startY);
      Placement.points.add((object) ((Point2) Pools.obtain((Class) ClassLiteral<Point2>.Value, (Prov) new Placement.__\u003C\u003EAnon0())).set(startX, startY));
      while (true)
      {
        Building building2 = building1;
        ChainedBuilding chainedBuilding;
        if (building2 is ChainedBuilding && object.ReferenceEquals((object) (chainedBuilding = (ChainedBuilding) building2), (object) (ChainedBuilding) building2) && ((int) building1.tile.x != endX || (int) building1.tile.y != endY) && Placement.closed.add(building1.id))
        {
          if (chainedBuilding.next() != null)
          {
            building1 = chainedBuilding.next();
            Placement.points.add((object) ((Point2) Pools.obtain((Class) ClassLiteral<Point2>.Value, (Prov) new Placement.__\u003C\u003EAnon0())).set((int) building1.tile.x, (int) building1.tile.y));
          }
          else
            break;
        }
        else
          goto label_5;
      }
      return Placement.pathfindLine(true, startX, startY, endX, endY);
label_5:
      return Placement.points;
    }

    [Signature("(ZIIII)Larc/struct/Seq<Larc/math/geom/Point2;>;")]
    [LineNumberTable(new byte[] {159, 135, 130, 106, 107, 116, 108, 134, 171})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Seq pathfindLine(bool conveyors, int startX, int startY, int endX, int endY)
    {
      int num = conveyors ? 1 : 0;
      Pools.freeAll(Placement.points);
      Placement.points.clear();
      if (num == 0 || !Core.settings.getBool("conveyorpathfinding"))
        return Placement.bres.lineNoDiagonal(startX, startY, endX, endY, Pools.get((Class) ClassLiteral<Point2>.Value, (Prov) new Placement.__\u003C\u003EAnon0()), Placement.points);
      return Placement.astar(startX, startY, endX, endY) ? Placement.points : Placement.normalizeLine(startX, startY, endX, endY);
    }

    [Signature("(IIII)Larc/struct/Seq<Larc/math/geom/Point2;>;")]
    [LineNumberTable(new byte[] {159, 187, 106, 107, 146, 109, 63, 23, 232, 69, 109, 63, 23, 198})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Seq normalizeLine(int startX, int startY, int endX, int endY)
    {
      Pools.freeAll(Placement.points);
      Placement.points.clear();
      if (Math.abs(startX - endX) > Math.abs(startY - endY))
      {
        for (int index = 0; index <= Math.abs(startX - endX); ++index)
          Placement.points.add((object) ((Point2) Pools.obtain((Class) ClassLiteral<Point2>.Value, (Prov) new Placement.__\u003C\u003EAnon0())).set(startX + index * Mathf.sign((float) (endX - startX)), startY));
      }
      else
      {
        for (int index = 0; index <= Math.abs(startY - endY); ++index)
          Placement.points.add((object) ((Point2) Pools.obtain((Class) ClassLiteral<Point2>.Value, (Prov) new Placement.__\u003C\u003EAnon0())).set(startX, startY + index * Mathf.sign((float) (endY - startY))));
      }
      return Placement.points;
    }

    [LineNumberTable(new byte[] {160, 88, 109, 109, 145, 106, 106, 138, 102, 130, 116, 105, 99, 119, 110, 121, 106, 99, 133, 126, 127, 0, 127, 3, 112, 111, 115, 120, 127, 0, 234, 57, 235, 75, 133, 102, 131, 159, 11, 99, 123, 102, 148, 135, 127, 23, 110, 133, 138})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool astar([In] int obj0, [In] int obj1, [In] int obj2, [In] int obj3)
    {
      Tile tile1 = Vars.world.tile(obj0, obj1);
      Tile tile2 = Vars.world.tile(obj2, obj3);
      if (object.ReferenceEquals((object) tile1, (object) tile2) || tile1 == null || tile2 == null)
        return false;
      Placement.costs.clear();
      Placement.closed.clear();
      Placement.parents.clear();
      int num1 = 1000;
      int num2 = 0;
      PQueue pqueue = new PQueue(10, (Comparator) new Placement.__\u003C\u003EAnon3(tile2));
      pqueue.add((object) tile1);
      int num3 = 0;
label_3:
      while (!pqueue.empty())
      {
        int num4 = num2;
        ++num2;
        int num5 = num1;
        if (num4 < num5)
        {
          Tile tile3 = (Tile) pqueue.poll();
          float num6 = Placement.costs.get(tile3.pos(), 0.0f);
          if (object.ReferenceEquals((object) tile3, (object) tile2))
          {
            num3 = 1;
            break;
          }
          Placement.closed.add(Point2.pack((int) tile3.x, (int) tile3.y));
          Point2[] d4 = Geometry.__\u003C\u003Ed4;
          int length = d4.Length;
          int index = 0;
          while (true)
          {
            if (index < length)
            {
              Point2 point2 = d4[index];
              int x = (int) tile3.x + point2.x;
              int y = (int) tile3.y + point2.y;
              Tile tile4 = Vars.world.tile(x, y);
              if (tile4 != null && Placement.validNode(tile3, tile4) && Placement.closed.add(tile4.pos()))
              {
                Placement.parents.put(tile4.pos(), tile3.pos());
                Placement.costs.put(tile4.pos(), Placement.tileHeuristic(tile3, tile4) + num6);
                pqueue.add((object) tile4);
              }
              ++index;
            }
            else
              goto label_3;
          }
        }
        else
          break;
      }
      if (num3 == 0)
        return false;
      int num7 = 0;
      Placement.points.add((object) ((Point2) Pools.obtain((Class) ClassLiteral<Point2>.Value, (Prov) new Placement.__\u003C\u003EAnon0())).set(obj2, obj3));
      int pos;
      for (Tile tile3 = tile2; !object.ReferenceEquals((object) tile3, (object) tile1); tile3 = Vars.world.tile(pos))
      {
        int num4 = num7;
        ++num7;
        int num5 = num1;
        if (num4 < num5)
        {
          if (tile3 == null)
            return false;
          pos = Placement.parents.get(tile3.pos(), -1);
          if (pos == -1)
            return false;
          Placement.points.add((object) ((Point2) Pools.obtain((Class) ClassLiteral<Point2>.Value, (Prov) new Placement.__\u003C\u003EAnon0())).set((int) Point2.x(pos), (int) Point2.y(pos)));
        }
        else
          break;
      }
      Placement.points.reverse();
      return true;
    }

    [LineNumberTable(new byte[] {160, 79, 112, 113, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool validNode([In] Tile obj0, [In] Tile obj1)
    {
      Block block = Vars.control.input.block;
      return block != null && block.canReplace(obj1.block()) || obj1.block().alwaysReplace;
    }

    [LineNumberTable(new byte[] {123, 144, 127, 12, 134, 114, 124, 114, 198})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static float tileHeuristic([In] Tile obj0, [In] Tile obj1)
    {
      Block block = Vars.control.input.block;
      if (!obj1.block().alwaysReplace && (block == null || !block.canReplace(obj1.block())) || obj1.floor().isDeep())
        return 20f;
      if (Placement.parents.containsKey(obj0.pos()))
      {
        Tile tile = Vars.world.tile(Placement.parents.get(obj0.pos(), 0));
        if ((int) (sbyte) obj0.relativeTo(tile) != (int) (sbyte) obj1.relativeTo(obj0))
          return 8f;
      }
      return 1f;
    }

    [LineNumberTable(189)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static float distanceHeuristic([In] int obj0, [In] int obj1, [In] int obj2, [In] int obj3) => (float) (Math.abs(obj0 - obj2) + Math.abs(obj1 - obj3));

    [Modifiers]
    [LineNumberTable(80)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024calculateNodes\u00240(
      [In] Seq obj0,
      [In] Block obj1,
      [In] int obj2,
      [In] Point2 obj3)
    {
      return object.ReferenceEquals((object) obj3, obj0.first()) || object.ReferenceEquals((object) obj3, obj0.peek()) || Build.validPlace(obj1, Vars.player.team(), obj3.x, obj3.y, obj2);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {67, 115, 63, 4})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024calculateBridges\u00241([In] BuildPlan obj0) => obj0.placeable(Vars.player.team()) || obj0.tile() != null && object.ReferenceEquals((object) obj0.tile().block(), (object) obj0.block);

    [Modifiers]
    [LineNumberTable(213)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static int lambda\u0024astar\u00242([In] Tile obj0, [In] Tile obj1, [In] Tile obj2) => Float.compare(Placement.costs.get(obj1.pos(), 0.0f) + Placement.distanceHeuristic((int) obj1.x, (int) obj1.y, (int) obj0.x, (int) obj0.y), Placement.costs.get(obj2.pos(), 0.0f) + Placement.distanceHeuristic((int) obj2.x, (int) obj2.y, (int) obj0.x, (int) obj0.y));

    [LineNumberTable(15)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Placement()
    {
    }

    [LineNumberTable(new byte[] {159, 138, 77, 106, 116, 106, 106, 106, 170, 106, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static Placement()
    {
      if (ByteCodeHelper.isAlreadyInited("mindustry.input.Placement"))
        return;
      Placement.plans1 = new Seq();
      Placement.tmpPoints = new Seq();
      Placement.tmpPoints2 = new Seq();
      Placement.result = new Placement.NormalizeResult();
      Placement.drawResult = new Placement.NormalizeDrawResult();
      Placement.bres = new Bresenham2();
      Placement.points = new Seq();
      Placement.costs = new IntFloatMap();
      Placement.parents = new IntIntMap();
      Placement.closed = new IntSet();
    }

    public class NormalizeDrawResult : Object
    {
      public float x;
      public float y;
      public float x2;
      public float y2;

      [LineNumberTable(358)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public NormalizeDrawResult()
      {
      }
    }

    public class NormalizeResult : Object
    {
      public int x;
      public int y;
      public int x2;
      public int y2;
      public int rotation;

      [LineNumberTable(362)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public NormalizeResult()
      {
      }
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Prov
    {
      internal __\u003C\u003EAnon0()
      {
      }

      public object get() => (object) new Point2();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Boolf
    {
      private readonly Seq arg\u00241;
      private readonly Block arg\u00242;
      private readonly int arg\u00243;

      internal __\u003C\u003EAnon1([In] Seq obj0, [In] Block obj1, [In] int obj2)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
      }

      public bool get([In] object obj0) => (Placement.lambda\u0024calculateNodes\u00240(this.arg\u00241, this.arg\u00242, this.arg\u00243, (Point2) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon2 : Boolf
    {
      internal __\u003C\u003EAnon2()
      {
      }

      public bool get([In] object obj0) => (Placement.lambda\u0024calculateBridges\u00241((BuildPlan) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon3 : Comparator
    {
      private readonly Tile arg\u00241;

      internal __\u003C\u003EAnon3([In] Tile obj0) => this.arg\u00241 = obj0;

      public int compare([In] object obj0, [In] object obj1) => Placement.lambda\u0024astar\u00242(this.arg\u00241, (Tile) obj0, (Tile) obj1);

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
