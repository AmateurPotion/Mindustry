// Decompiled with JetBrains decompiler
// Type: mindustry.world.Build
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.@struct;
using arc.func;
using arc.math;
using arc.math.geom;
using arc.util;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using mindustry.content;
using mindustry.entities;
using mindustry.game;
using mindustry.gen;
using mindustry.world.blocks;
using mindustry.world.blocks.storage;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.world
{
  public class Build : Object
  {
    [Modifiers]
    private static IntSet tmp;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(106)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool validPlace(Block type, Team team, int x, int y, int rotation) => Build.validPlace(type, team, x, y, rotation, true);

    [LineNumberTable(new byte[] {160, 97, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool validBreak(Team team, int x, int y)
    {
      Tile tile = Vars.world.tile(x, y);
      return tile != null && tile.block().canBreak(tile) && (tile.breakable() && tile.interactable(team));
    }

    [LineNumberTable(new byte[] {159, 114, 67, 127, 31, 162, 127, 70, 162, 127, 0, 162, 141, 165, 116, 162, 127, 5, 162, 106, 162, 108, 140, 112, 112, 154, 144, 137, 127, 11, 127, 20, 108, 116, 114, 239, 69, 127, 89, 127, 32, 118, 226, 44, 43, 235, 89})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool validPlace(
      Block type,
      Team team,
      int x,
      int y,
      int rotation,
      bool checkVisible)
    {
      int num1 = checkVisible ? 1 : 0;
      if (type == null || num1 != 0 && !type.isPlaceable() && (!Vars.state.rules.waves || !object.ReferenceEquals((object) team, (object) Vars.state.rules.waveTeam) || !type.isVisible()) || ((type.solid || type.solidifes) && Units.anyEntities((float) (x * 8) + type.offset - (float) (type.size * 8) / 2f, (float) (y * 8) + type.offset - (float) (type.size * 8) / 2f, (float) (type.size * 8), (float) (type.size * 8)) || Vars.state.teams.eachEnemyCore(team, (Boolf) new Build.__\u003C\u003EAnon3(x, type, y))))
        return false;
      Tile tile1 = Vars.world.tile(x, y);
      if (tile1 == null || (double) Vars.world.getDarkness(x, y) >= 3.0 || !type.requiresWater && !Build.contactsShallows((int) tile1.x, (int) tile1.y, type) && !type.placeableLiquid || !type.canPlaceOn(tile1, team))
        return false;
      int num2 = -(type.size - 1) / 2;
      int num3 = -(type.size - 1) / 2;
      for (int index1 = 0; index1 < type.size; ++index1)
      {
        for (int index2 = 0; index2 < type.size; ++index2)
        {
          int x1 = index1 + num2 + (int) tile1.x;
          int y1 = index2 + num3 + (int) tile1.y;
          Tile tile2 = Vars.world.tile(x1, y1);
          if (tile2 != null && (!tile2.floor().isDeep() || type.floating || (type.requiresWater || type.placeableLiquid)) && ((!object.ReferenceEquals((object) type, (object) tile2.block()) || tile2.build == null || (rotation != tile2.build.rotation || !type.rotate)) && (tile2.interactable(team) && tile2.floor().placeableOn && (num1 != 0 || tile2.block().alwaysReplace))))
          {
            if (!type.canReplace(tile2.block()))
            {
              Building build = tile2.build;
              ConstructBlock.ConstructBuild constructBuild;
              if (!(build is ConstructBlock.ConstructBuild) || !object.ReferenceEquals((object) (constructBuild = (ConstructBlock.ConstructBuild) build), (object) (ConstructBlock.ConstructBuild) build) || (!object.ReferenceEquals((object) constructBuild.cblock, (object) type) || tile2.centerX() != (int) tile1.x) || tile2.centerY() != (int) tile1.y)
                goto label_12;
            }
            if (type.bounds((int) tile1.x, (int) tile1.y, Tmp.__\u003C\u003Er1).grow(0.01f).contains(tile2.block.bounds(tile2.centerX(), tile2.centerY(), Tmp.__\u003C\u003Er2)) && (!type.requiresWater || object.ReferenceEquals((object) tile2.floor().liquidDrop, (object) Liquids.water)))
              continue;
          }
label_12:
          return false;
        }
      }
      return true;
    }

    [LineNumberTable(new byte[] {9, 110, 161, 174, 164, 127, 30, 124, 115, 107, 107, 127, 18, 161, 103, 108, 136, 104, 138, 243, 70, 138, 141, 126, 104, 152, 136, 119})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void beginPlace(
      [Nullable(new object[] {64, "Larc/util/Nullable;"})] Unit unit,
      Block result,
      Team team,
      int x,
      int y,
      int rotation)
    {
      if (!Build.validPlace(result, team, x, y, rotation))
        return;
      Tile tile = Vars.world.tile(x, y);
      if (tile == null)
        return;
      if (object.ReferenceEquals((object) tile.team(), (object) team) && object.ReferenceEquals((object) tile.block, (object) result) && (tile.build != null && tile.block.quickRotate))
      {
        if (unit != null && unit.getControllerName() != null)
          tile.build.lastAccessed = unit.getControllerName();
        tile.build.rotation = Mathf.mod(rotation, 4);
        tile.build.updateProximity();
        tile.build.noSleep();
        Fx.__\u003C\u003ErotateBlock.at(tile.build.x, tile.build.y, (float) tile.build.block.size);
      }
      else
      {
        Block previous = tile.block();
        ConstructBlock constructBlock = ConstructBlock.get(result.size);
        Seq seq = new Seq(9);
        result.beforePlaceBegan(tile, previous);
        Build.tmp.clear();
        tile.getLinkedTilesAs(result, (Cons) new Build.__\u003C\u003EAnon1(team, seq));
        tile.setBlock((Block) constructBlock, team, rotation);
        ConstructBlock.ConstructBuild build = (ConstructBlock.ConstructBuild) tile.build;
        build.setConstruct(previous.size != constructBlock.size ? Blocks.air : previous, result);
        build.prevBuild = seq;
        if (unit != null && unit.getControllerName() != null)
          build.lastAccessed = unit.getControllerName();
        result.placeBegan(tile, previous);
        Core.app.post((Runnable) new Build.__\u003C\u003EAnon2(tile, team, unit));
      }
    }

    [LineNumberTable(new byte[] {159, 166, 106, 161, 141, 134, 104, 173, 119, 103, 141, 104, 149, 106, 109, 104, 105, 153, 107, 177, 119})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void beginBreak([Nullable(new object[] {64, "Larc/util/Nullable;"})] Unit unit, Team team, int x, int y)
    {
      if (!Build.validBreak(team, x, y))
        return;
      Tile tile = Vars.world.tileBuilding(x, y);
      float num = 1f;
      if (tile.build != null)
        num = tile.build.healthf();
      int rotation = tile.build == null ? 0 : tile.build.rotation;
      Block previous = tile.block();
      ConstructBlock constructBlock = ConstructBlock.get(previous.size);
      Seq seq = new Seq(1);
      if (tile.build != null)
        seq.add((object) tile.build);
      tile.setBlock((Block) constructBlock, team, rotation);
      ConstructBlock.ConstructBuild build = (ConstructBlock.ConstructBuild) tile.build;
      build.setDeconstruct(previous);
      build.prevBuild = seq;
      tile.build.health = tile.build.maxHealth * num;
      if (unit != null && unit.getControllerName() != null)
        tile.build.lastAccessed = unit.getControllerName();
      Core.app.post((Runnable) new Build.__\u003C\u003EAnon0(tile, team, unit));
    }

    [LineNumberTable(new byte[] {160, 74, 107, 121, 124, 20, 230, 69, 121, 124, 20, 235, 69, 115, 124, 20, 198, 110, 151})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool contactsShallows(int x, int y, Block block)
    {
      if (block.isMultiblock())
      {
        Point2[] insideEdges = Edges.getInsideEdges(block.size);
        int length1 = insideEdges.Length;
        for (int index = 0; index < length1; ++index)
        {
          Point2 point2 = insideEdges[index];
          Tile tile = Vars.world.tile(x + point2.x, y + point2.y);
          if (tile != null && !tile.floor().isDeep())
            return true;
        }
        Point2[] edges = Edges.getEdges(block.size);
        int length2 = edges.Length;
        for (int index = 0; index < length2; ++index)
        {
          Point2 point2 = edges[index];
          Tile tile = Vars.world.tile(x + point2.x, y + point2.y);
          if (tile != null && !tile.floor().isDeep())
            return true;
        }
        return false;
      }
      Point2[] d4 = Geometry.__\u003C\u003Ed4;
      int length = d4.Length;
      for (int index = 0; index < length; ++index)
      {
        Point2 point2 = d4[index];
        Tile tile = Vars.world.tile(x + point2.x, y + point2.y);
        if (tile != null && !tile.floor().isDeep())
          return true;
      }
      Tile tile1 = Vars.world.tile(x, y);
      return tile1 != null && !tile1.floor().isDeep();
    }

    [Modifiers]
    [LineNumberTable(53)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024beginBreak\u00240([In] Tile obj0, [In] Team obj1, [In] Unit obj2) => Events.fire((object) new EventType.BlockBuildBeginEvent(obj0, obj1, obj2, true));

    [Modifiers]
    [LineNumberTable(new byte[] {36, 127, 19, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024beginPlace\u00241([In] Team obj0, [In] Seq obj1, [In] Tile obj2)
    {
      if (obj2.build == null || !object.ReferenceEquals((object) obj2.build.team, (object) obj0) || !Build.tmp.add(obj2.build.id))
        return;
      obj1.add((object) obj2.build);
    }

    [Modifiers]
    [LineNumberTable(101)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024beginPlace\u00242([In] Tile obj0, [In] Team obj1, [In] Unit obj2) => Events.fire((object) new EventType.BlockBuildBeginEvent(obj0, obj1, obj2, false));

    [Modifiers]
    [LineNumberTable(120)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024validPlace\u00243(
      [In] int obj0,
      [In] Block obj1,
      [In] int obj2,
      [In] CoreBlock.CoreBuild obj3)
    {
      return (double) Mathf.dst((float) (obj0 * 8) + obj1.offset, (float) (obj2 * 8) + obj1.offset, obj3.x, obj3.y) < (double) (Vars.state.rules.enemyCoreBuildRadius + (float) (obj1.size * 8) / 2f);
    }

    [LineNumberTable(19)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Build()
    {
    }

    [LineNumberTable(new byte[] {123, 107, 121, 124, 20, 235, 69, 115, 124, 20, 230, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool contactsGround(int x, int y, Block block)
    {
      if (block.isMultiblock())
      {
        Point2[] edges = Edges.getEdges(block.size);
        int length = edges.Length;
        for (int index = 0; index < length; ++index)
        {
          Point2 point2 = edges[index];
          Tile tile = Vars.world.tile(x + point2.x, y + point2.y);
          if (tile != null && !tile.floor().isLiquid)
            return true;
        }
      }
      else
      {
        Point2[] d4 = Geometry.__\u003C\u003Ed4;
        int length = d4.Length;
        for (int index = 0; index < length; ++index)
        {
          Point2 point2 = d4[index];
          Tile tile = Vars.world.tile(x + point2.x, y + point2.y);
          if (tile != null && !tile.floor().isLiquid)
            return true;
        }
      }
      return false;
    }

    [LineNumberTable(20)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static Build()
    {
      if (ByteCodeHelper.isAlreadyInited("mindustry.world.Build"))
        return;
      Build.tmp = new IntSet();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Runnable
    {
      private readonly Tile arg\u00241;
      private readonly Team arg\u00242;
      private readonly Unit arg\u00243;

      internal __\u003C\u003EAnon0([In] Tile obj0, [In] Team obj1, [In] Unit obj2)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
      }

      public void run() => Build.lambda\u0024beginBreak\u00240(this.arg\u00241, this.arg\u00242, this.arg\u00243);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Cons
    {
      private readonly Team arg\u00241;
      private readonly Seq arg\u00242;

      internal __\u003C\u003EAnon1([In] Team obj0, [In] Seq obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] object obj0) => Build.lambda\u0024beginPlace\u00241(this.arg\u00241, this.arg\u00242, (Tile) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon2 : Runnable
    {
      private readonly Tile arg\u00241;
      private readonly Team arg\u00242;
      private readonly Unit arg\u00243;

      internal __\u003C\u003EAnon2([In] Tile obj0, [In] Team obj1, [In] Unit obj2)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
      }

      public void run() => Build.lambda\u0024beginPlace\u00242(this.arg\u00241, this.arg\u00242, this.arg\u00243);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon3 : Boolf
    {
      private readonly int arg\u00241;
      private readonly Block arg\u00242;
      private readonly int arg\u00243;

      internal __\u003C\u003EAnon3([In] int obj0, [In] Block obj1, [In] int obj2)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
      }

      public bool get([In] object obj0) => (Build.lambda\u0024validPlace\u00243(this.arg\u00241, this.arg\u00242, this.arg\u00243, (CoreBlock.CoreBuild) obj0) ? 1 : 0) != 0;
    }
  }
}
