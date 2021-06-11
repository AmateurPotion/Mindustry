// Decompiled with JetBrains decompiler
// Type: mindustry.ai.BaseAI
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.func;
using arc.math;
using arc.math.geom;
using arc.util;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.util;
using mindustry.content;
using mindustry.core;
using mindustry.ctype;
using mindustry.game;
using mindustry.gen;
using mindustry.type;
using mindustry.world;
using mindustry.world.blocks.defense;
using mindustry.world.blocks.distribution;
using mindustry.world.blocks.production;
using mindustry.world.blocks.storage;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.ai
{
  public class BaseAI : Object
  {
    [Modifiers]
    private static Vec2 axis;
    [Modifiers]
    private static Vec2 rotator;
    private const float correctPercent = 0.5f;
    private const int attempts = 4;
    private const float emptyChance = 0.01f;
    private const int timerStep = 0;
    private const int timerSpawn = 1;
    private const int timerRefreshPath = 2;
    private const int pathStep = 50;
    [Modifiers]
    [Signature("Larc/struct/Seq<Lmindustry/world/Tile;>;")]
    private static Seq tmpTiles;
    private static int correct;
    private static int incorrect;
    private int lastX;
    private int lastY;
    private int lastW;
    private int lastH;
    private bool triedWalls;
    private bool foundPath;
    internal Teams.TeamData data;
    internal Interval timer;
    internal IntSet path;
    internal IntSet calcPath;
    [Nullable(new object[] {64, "Larc/util/Nullable;"})]
    internal Tile calcTile;
    internal bool calculating;
    internal bool startedCalculating;
    internal int calcCount;
    internal int totalCalcs;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {160, 156, 102, 127, 30, 141, 132, 154, 124, 143, 154, 131, 127, 0, 127, 13, 165, 127, 11, 127, 4, 165, 127, 12, 227, 53, 235, 79, 107, 127, 41, 255, 12, 40, 11, 233, 94})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void tryWalls()
    {
      Block copperWall = Blocks.copperWall;
      Tile tile1 = (Vars.state.rules.defaultTeam.core() == null ? (Building) this.data.__\u003C\u003Eteam.core() : (Building) Vars.state.rules.defaultTeam.core())?.tile;
      if (tile1 == null)
        return;
      for (int lastX = this.lastX; lastX <= this.lastX + this.lastW; ++lastX)
      {
label_5:
        for (int lastY = this.lastY; lastY <= this.lastY + this.lastH; ++lastY)
        {
          Tile tile2 = Vars.world.tile(lastX, lastY);
          if (tile2 != null && tile2.block().alwaysReplace)
          {
            int num = 0;
            Point2[] d8 = Geometry.__\u003C\u003Ed8;
            int length = d8.Length;
            for (int index = 0; index < length; ++index)
            {
              Point2 point2 = d8[index];
              if ((double) Angles.angleDist(Angles.angle((float) point2.x, (float) point2.y), tile1.angleTo((Position) tile2)) <= 70.0)
              {
                Tile tile3 = Vars.world.tile((int) tile2.x + point2.x, (int) tile2.y + point2.y);
                if (tile3 == null || !(tile3.block() is PayloadAcceptor) && !(tile3.block() is PayloadConveyor))
                {
                  if (tile3 != null && object.ReferenceEquals((object) tile3.team(), (object) this.data.__\u003C\u003Eteam) && !(tile3.block() is Wall))
                    num = 1;
                }
                else
                  goto label_5;
              }
            }
            BaseAI.tmpTiles.clear();
            if (num != 0 && Build.validPlace(copperWall, this.data.__\u003C\u003Eteam, (int) tile2.x, (int) tile2.y, 0) && !tile2.getLinkedTilesAs(copperWall, BaseAI.tmpTiles).contains((Boolf) new BaseAI.__\u003C\u003EAnon5(this)))
              this.data.blocks.add((object) new Teams.BlockPlan((int) tile2.x, (int) tile2.y, (short) 0, copperWall.__\u003C\u003Eid, (object) null));
          }
        }
      }
    }

    [LineNumberTable(new byte[] {160, 71, 109, 118, 127, 2, 149})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Position randomPosition()
    {
      if (this.data.hasCore())
        return (Position) this.data.__\u003C\u003Ecores.random();
      return object.ReferenceEquals((object) this.data.__\u003C\u003Eteam, (object) Vars.state.rules.waveTeam) ? (Position) Vars.spawner.getSpawns().random() : (Position) null;
    }

    [LineNumberTable(new byte[] {160, 80, 103, 127, 30, 109, 101, 159, 6, 114, 179, 127, 8, 119, 127, 6, 130, 144, 159, 0, 127, 9, 127, 11, 100, 226, 61, 232, 73, 107, 127, 24, 130, 165, 108, 131, 112, 127, 5, 110, 131, 255, 11, 73, 194, 114, 194, 127, 5, 127, 37, 130, 105, 106, 110, 142, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool tryPlace([In] BaseRegistry.BasePart obj0, [In] int obj1, [In] int obj2)
    {
      int times = Mathf.range(2);
      BaseAI.axis.set((float) ByteCodeHelper.f2i((float) obj0.__\u003C\u003Eschematic.width / 2f), (float) ByteCodeHelper.f2i((float) obj0.__\u003C\u003Eschematic.height / 2f));
      Schematic schematic = Schematics.rotate(obj0.__\u003C\u003Eschematic, times);
      int num1 = times * 90;
      BaseAI.rotator.set((float) obj0.centerX, (float) obj0.centerY).rotateAround(BaseAI.axis, (float) num1);
      int num2 = obj1 - ByteCodeHelper.f2i(BaseAI.rotator.x);
      int num3 = obj2 - ByteCodeHelper.f2i(BaseAI.rotator.y);
      Iterator iterator1 = schematic.__\u003C\u003Etiles.iterator();
      while (iterator1.hasNext())
      {
        Schematic.Stile stile = (Schematic.Stile) iterator1.next();
        int x = (int) stile.x + num2;
        int y = (int) stile.y + num3;
        if (!Build.validPlace(stile.block, this.data.__\u003C\u003Eteam, x, y, (int) (sbyte) stile.rotation))
          return false;
        Tile tile = Vars.world.tile(x, y);
        if (stile.block is PayloadConveyor || stile.block is PayloadAcceptor)
        {
          Point2[] edges = Edges.getEdges(stile.block.size);
          int length = edges.Length;
          for (int index = 0; index < length; ++index)
          {
            Point2 point2 = edges[index];
            if (Vars.world.build((int) stile.x + point2.x, (int) stile.y + point2.y) != null)
              return false;
          }
        }
        BaseAI.tmpTiles.clear();
        if (stile.block.solid && tile != null && tile.getLinkedTilesAs(stile.block, BaseAI.tmpTiles).contains((Boolf) new BaseAI.__\u003C\u003EAnon3(this)))
          return false;
      }
      BaseAI.correct = BaseAI.incorrect = 0;
      int num4 = 0;
      if (obj0.required is Item)
      {
        Iterator iterator2 = schematic.__\u003C\u003Etiles.iterator();
        while (iterator2.hasNext())
        {
          Schematic.Stile stile = (Schematic.Stile) iterator2.next();
          if (stile.block is Drill)
          {
            num4 = 1;
            stile.block.iterateTaken((int) stile.x + num2, (int) stile.y + num3, (Intc2) new BaseAI.__\u003C\u003EAnon4(obj0));
          }
        }
      }
      if (num4 != 0 && (BaseAI.incorrect != 0 || BaseAI.correct == 0))
        return false;
      Iterator iterator3 = schematic.__\u003C\u003Etiles.iterator();
      while (iterator3.hasNext())
      {
        Schematic.Stile stile = (Schematic.Stile) iterator3.next();
        this.data.blocks.add((object) new Teams.BlockPlan(num2 + (int) stile.x, num3 + (int) stile.y, (short) (sbyte) stile.rotation, stile.block.__\u003C\u003Eid, stile.config));
      }
      this.lastX = num2 - 1;
      this.lastY = num3 - 1;
      this.lastW = schematic.width + 2;
      this.lastH = schematic.height + 2;
      this.triedWalls = false;
      return true;
    }

    [Modifiers]
    [LineNumberTable(56)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool lambda\u0024update\u00240([In] CoreBlock obj0, [In] Unit obj1) => object.ReferenceEquals((object) obj1.team, (object) this.data.__\u003C\u003Eteam) && object.ReferenceEquals((object) obj1.type, (object) obj0.unitType);

    [Modifiers]
    [LineNumberTable(85)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024update\u00241([In] int obj0, [In] int obj1) => this.calcTile = Vars.world.tile(obj0, obj1);

    [Modifiers]
    [LineNumberTable(159)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024update\u00242([In] Tile obj0, [In] Tile obj1) => obj1.within((Position) obj0, 320f);

    [Modifiers]
    [LineNumberTable(223)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool lambda\u0024tryPlace\u00243([In] Tile obj0) => this.path.contains(obj0.pos());

    [Modifiers]
    [LineNumberTable(new byte[] {160, 124, 109, 115, 110, 104, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024tryPlace\u00244([In] BaseRegistry.BasePart obj0, [In] int obj1, [In] int obj2)
    {
      Tile tile = Vars.world.rawTile(obj1, obj2);
      if (object.ReferenceEquals((object) tile.drop(), (object) obj0.required))
      {
        ++BaseAI.correct;
      }
      else
      {
        if (tile.drop() == null)
          return;
        ++BaseAI.incorrect;
      }
    }

    [Modifiers]
    [LineNumberTable(301)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool lambda\u0024tryWalls\u00245([In] Tile obj0) => this.path.contains(obj0.pos());

    [LineNumberTable(new byte[] {159, 191, 232, 55, 140, 107, 171, 103, 167, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public BaseAI(Teams.TeamData data)
    {
      BaseAI baseAi = this;
      this.timer = new Interval(4);
      this.path = new IntSet();
      this.calcPath = new IntSet();
      this.calcCount = 0;
      this.totalCalcs = 0;
      this.data = data;
    }

    [LineNumberTable(new byte[] {4, 127, 33, 118, 183, 127, 0, 119, 123, 102, 235, 69, 127, 17, 103, 103, 203, 127, 6, 103, 103, 107, 206, 107, 104, 117, 107, 172, 156, 104, 108, 103, 122, 99, 127, 0, 152, 112, 123, 106, 104, 227, 57, 235, 76, 100, 107, 165, 119, 124, 63, 24, 232, 69, 159, 47, 103, 103, 107, 113, 107, 103, 110, 135, 162, 238, 23, 235, 111, 127, 55, 104, 102, 167, 107, 134, 168, 133, 114, 127, 35, 181, 125, 165, 195, 127, 2, 117, 112, 172, 100, 110, 120, 226, 34, 235, 99})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void update()
    {
      if (this.data.__\u003C\u003Eteam.rules().aiCoreSpawn && this.timer.get(1, 150f) && this.data.hasCore())
      {
        CoreBlock block = (CoreBlock) this.data.core().block;
        int num = Groups.unit.count((Boolf) new BaseAI.__\u003C\u003EAnon0(this, block));
        if (!Vars.state.isEditor() && num < this.data.__\u003C\u003Ecores.size)
        {
          Unit unit = block.unitType.create(this.data.__\u003C\u003Eteam);
          unit.set((Position) this.data.__\u003C\u003Ecores.random());
          unit.add();
          Fx.__\u003C\u003Espawn.at((Position) unit);
        }
      }
      if (!this.calculating && (this.timer.get(2, 10800f) || !this.startedCalculating) && this.data.hasCore())
      {
        this.calculating = true;
        this.startedCalculating = true;
        this.calcPath.clear();
      }
      if (this.calculating && this.calcCount >= Vars.world.width() * Vars.world.height())
      {
        this.calculating = false;
        this.calcCount = 0;
        this.calcPath.clear();
        ++this.totalCalcs;
      }
      if (this.calculating)
      {
        if (this.calcTile == null)
        {
          Vars.spawner.eachGroundSpawn((Intc2) new BaseAI.__\u003C\u003EAnon1(this));
          if (this.calcTile == null)
            this.calculating = false;
        }
        else
        {
          int[][] weights = Vars.pathfinder.getField(Vars.state.rules.waveTeam, 0, 0).weights;
          for (int index1 = 0; index1 < 50; ++index1)
          {
            int maxValue = int.MaxValue;
            int x1 = (int) this.calcTile.x;
            int y1 = (int) this.calcTile.y;
            int num = 0;
            Point2[] d4 = Geometry.__\u003C\u003Ed4;
            int length1 = d4.Length;
            for (int index2 = 0; index2 < length1; ++index2)
            {
              Point2 point2 = d4[index2];
              int x2 = x1 + point2.x;
              int y2 = y1 + point2.y;
              Tile tile = Vars.world.tile(x2, y2);
              if (tile != null && weights[x2][y2] < maxValue && weights[x2][y2] != -1)
              {
                maxValue = weights[x2][y2];
                this.calcTile = tile;
                num = 1;
              }
            }
            if (num == 0)
            {
              this.calcCount = int.MaxValue;
              break;
            }
            this.calcPath.add(this.calcTile.pos());
            Point2[] d8 = Geometry.__\u003C\u003Ed8;
            int length2 = d8.Length;
            for (int index2 = 0; index2 < length2; ++index2)
            {
              Point2 point2 = d8[index2];
              this.calcPath.add(Point2.pack(point2.x + (int) this.calcTile.x, point2.y + (int) this.calcTile.y));
            }
            Building build = this.calcTile.build;
            CoreBlock.CoreBuild coreBuild;
            if (build is CoreBlock.CoreBuild && object.ReferenceEquals((object) (coreBuild = (CoreBlock.CoreBuild) build), (object) (CoreBlock.CoreBuild) build) && object.ReferenceEquals((object) coreBuild.team, (object) Vars.state.rules.defaultTeam))
            {
              this.calculating = false;
              this.calcCount = 0;
              this.path.clear();
              this.path.addAll(this.calcPath);
              this.calcPath.clear();
              this.calcTile = (Tile) null;
              ++this.totalCalcs;
              this.foundPath = true;
              break;
            }
            ++this.calcCount;
          }
        }
      }
      if (!this.foundPath || !this.data.blocks.isEmpty() || !this.timer.get(0, Mathf.lerp(20f, 4f, this.data.__\u003C\u003Eteam.rules().aiTier)))
        return;
      if (!this.triedWalls)
      {
        this.tryWalls();
        this.triedWalls = true;
      }
      for (int index = 0; index < 4; ++index)
      {
        int range = 150;
        Position position = this.randomPosition();
        if (position == null)
          break;
        Tmp.__\u003C\u003Ev1.rnd((float) Mathf.random(range));
        int x = ByteCodeHelper.f2i((float) World.toTile(position.getX()) + Tmp.__\u003C\u003Ev1.x);
        int y = ByteCodeHelper.f2i((float) World.toTile(position.getY()) + Tmp.__\u003C\u003Ev1.y);
        Tile tile = Vars.world.tiles.getc(x, y);
        if (!Vars.spawner.getSpawns().contains((Boolf) new BaseAI.__\u003C\u003EAnon2(tile)))
        {
          Seq seq = (Seq) null;
          if (tile.drop() != null && Vars.bases.forResource((Content) tile.drop()).any())
            seq = Vars.bases.forResource((Content) tile.drop());
          else if (Mathf.chance(0.00999999977648258))
            seq = Vars.bases.parts;
          if (seq != null && this.tryPlace((BaseRegistry.BasePart) seq.random(), (int) tile.x, (int) tile.y))
            break;
        }
      }
    }

    [LineNumberTable(new byte[] {159, 136, 141, 244, 70, 138})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static BaseAI()
    {
      if (ByteCodeHelper.isAlreadyInited("mindustry.ai.BaseAI"))
        return;
      BaseAI.axis = new Vec2();
      BaseAI.rotator = new Vec2();
      BaseAI.tmpTiles = new Seq();
      BaseAI.correct = 0;
      BaseAI.incorrect = 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Boolf
    {
      private readonly BaseAI arg\u00241;
      private readonly CoreBlock arg\u00242;

      internal __\u003C\u003EAnon0([In] BaseAI obj0, [In] CoreBlock obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public bool get([In] object obj0) => (this.arg\u00241.lambda\u0024update\u00240(this.arg\u00242, (Unit) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Intc2
    {
      private readonly BaseAI arg\u00241;

      internal __\u003C\u003EAnon1([In] BaseAI obj0) => this.arg\u00241 = obj0;

      public void get([In] int obj0, [In] int obj1) => this.arg\u00241.lambda\u0024update\u00241(obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon2 : Boolf
    {
      private readonly Tile arg\u00241;

      internal __\u003C\u003EAnon2([In] Tile obj0) => this.arg\u00241 = obj0;

      public bool get([In] object obj0) => (BaseAI.lambda\u0024update\u00242(this.arg\u00241, (Tile) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon3 : Boolf
    {
      private readonly BaseAI arg\u00241;

      internal __\u003C\u003EAnon3([In] BaseAI obj0) => this.arg\u00241 = obj0;

      public bool get([In] object obj0) => (this.arg\u00241.lambda\u0024tryPlace\u00243((Tile) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon4 : Intc2
    {
      private readonly BaseRegistry.BasePart arg\u00241;

      internal __\u003C\u003EAnon4([In] BaseRegistry.BasePart obj0) => this.arg\u00241 = obj0;

      public void get([In] int obj0, [In] int obj1) => BaseAI.lambda\u0024tryPlace\u00244(this.arg\u00241, obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon5 : Boolf
    {
      private readonly BaseAI arg\u00241;

      internal __\u003C\u003EAnon5([In] BaseAI obj0) => this.arg\u00241 = obj0;

      public bool get([In] object obj0) => (this.arg\u00241.lambda\u0024tryWalls\u00245((Tile) obj0) ? 1 : 0) != 0;
    }
  }
}
