// Decompiled with JetBrains decompiler
// Type: mindustry.ai.Pathfinder
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.@struct;
using arc.func;
using arc.math.geom;
using arc.util;
using arc.util.async;
using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.util;
using mindustry.content;
using mindustry.core;
using mindustry.game;
using mindustry.gen;
using mindustry.world;
using mindustry.world.blocks.storage;
using mindustry.world.meta;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.ai
{
  public class Pathfinder : Object, Runnable
  {
    [Modifiers]
    private static long maxUpdate;
    private const int updateFPS = 60;
    private const int updateInterval = 16;
    private const int impassable = -1;
    public const int fieldCore = 0;
    public const int fieldRally = 1;
    [Signature("Larc/struct/Seq<Larc/func/Prov<Lmindustry/ai/Pathfinder$Flowfield;>;>;")]
    internal static Seq __\u003C\u003EfieldTypes;
    public const int costGround = 0;
    public const int costLegs = 1;
    public const int costNaval = 2;
    [Signature("Larc/struct/Seq<Lmindustry/ai/Pathfinder$PathCost;>;")]
    internal static Seq __\u003C\u003EcostTypes;
    internal Pathfinder.Flowfield[][][] cache;
    internal int[][] tiles;
    [Signature("Larc/struct/Seq<Lmindustry/ai/Pathfinder$Flowfield;>;")]
    internal Seq threadList;
    [Signature("Larc/struct/Seq<Lmindustry/ai/Pathfinder$Flowfield;>;")]
    internal Seq mainList;
    internal TaskQueue queue;
    [arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})]
    internal Thread thread;
    internal IntSeq tmpArray;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {24, 232, 55, 159, 10, 150, 171, 171, 134, 245, 87, 149, 117})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Pathfinder()
    {
      Pathfinder pathfinder = this;
      int[] numArray = new int[2];
      int num1 = 0;
      numArray[1] = num1;
      int num2 = 0;
      numArray[0] = num2;
      // ISSUE: type reference
      this.tiles = (int[][]) ByteCodeHelper.multianewarray(__typeref (int[][]), numArray);
      this.threadList = new Seq();
      this.mainList = new Seq();
      this.queue = new TaskQueue();
      this.tmpArray = new IntSeq();
      this.clearCache();
      Events.on((Class) ClassLiteral<EventType.WorldLoadEvent>.Value, (Cons) new Pathfinder.__\u003C\u003EAnon0(this));
      Events.on((Class) ClassLiteral<EventType.ResetEvent>.Value, (Cons) new Pathfinder.__\u003C\u003EAnon1(this));
      Events.on((Class) ClassLiteral<EventType.TileChangeEvent>.Value, (Cons) new Pathfinder.__\u003C\u003EAnon2(this));
    }

    [LineNumberTable(new byte[] {160, 96, 118, 123, 103, 118, 107, 140, 114, 151})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Pathfinder.Flowfield getField(Team team, int costType, int fieldType)
    {
      if (this.cache[team.__\u003C\u003Eid][costType][fieldType] == null)
      {
        Pathfinder.Flowfield flowfield = (Pathfinder.Flowfield) ((Prov) Pathfinder.__\u003C\u003EfieldTypes.get(fieldType)).get();
        flowfield.team = team;
        flowfield.__\u003C\u003Ecost = (Pathfinder.PathCost) Pathfinder.__\u003C\u003EcostTypes.get(costType);
        flowfield.targets.clear();
        flowfield.getPositions(flowfield.targets);
        this.cache[team.__\u003C\u003Eid][costType][fieldType] = flowfield;
        this.queue.post((Runnable) new Pathfinder.__\u003C\u003EAnon5(this, flowfield));
      }
      return this.cache[team.__\u003C\u003Eid][costType][fieldType];
    }

    [LineNumberTable(new byte[] {56, 127, 20})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void clearCache()
    {
      int[] numArray = new int[3];
      int num1 = 5;
      numArray[2] = num1;
      int num2 = 5;
      numArray[1] = num2;
      int num3 = 256;
      numArray[0] = num3;
      // ISSUE: type reference
      this.cache = (Pathfinder.Flowfield[][][]) ByteCodeHelper.multianewarray(__typeref (Pathfinder.Flowfield[][][]), numArray);
    }

    [LineNumberTable(new byte[] {94, 104, 107, 135, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void stop()
    {
      if (this.thread != null)
      {
        this.thread.interrupt();
        this.thread = (Thread) null;
      }
      this.queue.clear();
    }

    [LineNumberTable(new byte[] {160, 241, 134, 127, 3, 118, 108, 181, 127, 3, 107, 161, 103, 156, 159, 1, 159, 17, 159, 0, 127, 12, 116, 112, 243, 53, 235, 79, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void updateFrontier([In] Pathfinder.Flowfield obj0, [In] long obj1)
    {
      long prevTime = Time.nanos();
label_1:
      while (obj0.frontier.size > 0 && (obj1 < 0L || Time.timeSinceNanos(prevTime) <= obj1))
      {
        Tile tile = Vars.world.tile(obj0.frontier.removeLast());
        if (tile == null || obj0.weights == null)
          break;
        int num = obj0.weights[(int) tile.x][(int) tile.y];
        if (obj0.frontier.size >= Vars.world.width() * Vars.world.height())
        {
          obj0.frontier.clear();
          break;
        }
        if (num != -1)
        {
          Point2[] d4 = Geometry.__\u003C\u003Ed4;
          int length = d4.Length;
          int index = 0;
          while (true)
          {
            if (index < length)
            {
              Point2 point2 = d4[index];
              int x = (int) tile.x + point2.x;
              int y = (int) tile.y + point2.y;
              if (x >= 0 && y >= 0 && (x < this.tiles.Length && y < this.tiles[0].Length))
              {
                int cost = obj0.__\u003C\u003Ecost.getCost(obj0.team, this.tiles[x][y]);
                if ((obj0.weights[x][y] > num + cost || obj0.searches[x][y] < obj0.search) && cost != -1)
                {
                  obj0.frontier.addFirst(Point2.pack(x, y));
                  obj0.weights[x][y] = num + cost;
                  obj0.searches[x][y] = (int) (short) obj0.search;
                }
              }
              ++index;
            }
            else
              goto label_1;
          }
        }
      }
    }

    [LineNumberTable(new byte[] {160, 188, 142, 141, 112, 109, 143, 108, 113, 236, 58, 233, 72, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void updateTargets([In] Pathfinder.Flowfield obj0)
    {
      ++obj0.search;
      lock (obj0.targets)
      {
        for (int index1 = 0; index1 < obj0.targets.size; ++index1)
        {
          int num = obj0.targets.get(index1);
          int index2 = (int) Point2.x(num);
          int index3 = (int) Point2.y(num);
          obj0.weights[index2][index3] = 0;
          obj0.searches[index2][index3] = obj0.search;
          obj0.frontier.addFirst(num);
        }
      }
    }

    [LineNumberTable(new byte[] {160, 216, 107, 150, 172, 182, 111, 111, 43, 38, 230, 71, 112, 109, 117, 236, 61, 230, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void registerPath([In] Pathfinder.Flowfield obj0)
    {
      obj0.lastUpdateTime = Time.millis();
      obj0.setup(this.tiles.Length, this.tiles[0].Length);
      this.threadList.add((object) obj0);
      Core.app.post((Runnable) new Pathfinder.__\u003C\u003EAnon7(this, obj0));
      for (int index1 = 0; index1 < Vars.world.width(); ++index1)
      {
        for (int index2 = 0; index2 < Vars.world.height(); ++index2)
          obj0.weights[index1][index2] = -1;
      }
      for (int index = 0; index < obj0.targets.size; ++index)
      {
        int num = obj0.targets.get(index);
        obj0.weights[(int) Point2.x(num)][(int) Point2.y(num)] = 0;
        obj0.frontier.addFirst(num);
      }
    }

    [LineNumberTable(new byte[] {160, 165, 144, 140, 109, 141, 193, 191, 6, 139, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void updateTargets([In] Pathfinder.Flowfield obj0, [In] int obj1, [In] int obj2)
    {
      if (!Structs.inBounds(obj1, obj2, obj0.weights))
        return;
      if (obj0.weights[obj1][obj2] == 0)
        obj0.frontier.clear();
      else if (!obj0.frontier.isEmpty())
        return;
      obj0.weights[obj1][obj2] = obj0.__\u003C\u003Ecost.getCost(obj0.team, this.tiles[obj1][obj2]);
      obj0.frontier.clear();
      this.updateTargets(obj0);
    }

    [LineNumberTable(new byte[] {61, 141, 104, 106, 100, 112, 107, 240, 59, 232, 74, 127, 27, 135, 107, 223, 16, 107, 241, 54})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private int packTile([In] Tile obj0)
    {
      int num1 = 0;
      int num2 = 0;
      int num3 = 0;
      int num4 = obj0.solid() ? 1 : 0;
      for (int rotation = 0; rotation < 4; ++rotation)
      {
        Tile tile = obj0.nearby(rotation);
        if (tile != null)
        {
          if (tile.floor().isLiquid)
            num1 = 1;
          if (tile.solid())
            num2 = 1;
          if (!tile.floor().isLiquid)
            num3 = 1;
        }
      }
      return PathTile.get(obj0.build == null || num4 == 0 || obj0.block() is CoreBlock ? 0 : Math.min(ByteCodeHelper.f2i(obj0.build.health / 40f), 80), obj0.getTeamID(), num4 != 0, obj0.floor().isLiquid, obj0.staticDarkness() >= 2 || obj0.floor().solid && object.ReferenceEquals((object) obj0.block(), (object) Blocks.air), num1 != 0, num3 != 0, num2 != 0, obj0.floor().isDeep(), (double) obj0.floor().damageTaken > 9.99999974737875E-06);
    }

    [LineNumberTable(new byte[] {104, 141, 142, 241, 71, 127, 1, 99, 110, 107, 108, 144, 130, 248, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void updateTile(Tile tile)
    {
      if (Vars.net.client())
        return;
      int x = (int) tile.x;
      int y = (int) tile.y;
      tile.getLinkedTiles((Cons) new Pathfinder.__\u003C\u003EAnon3(this));
      Iterator iterator = this.mainList.iterator();
      while (iterator.hasNext())
      {
        Pathfinder.Flowfield flowfield = (Pathfinder.Flowfield) iterator.next();
        if (flowfield != null)
        {
          lock (flowfield.targets)
          {
            flowfield.targets.clear();
            flowfield.getPositions(flowfield.targets);
          }
        }
      }
      this.queue.post((Runnable) new Pathfinder.__\u003C\u003EAnon4(this, x, y));
    }

    [LineNumberTable(new byte[] {160, 204, 107, 108, 103, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void preloadPath([In] Pathfinder.Flowfield obj0)
    {
      obj0.targets.clear();
      obj0.getPositions(obj0.targets);
      this.registerPath(obj0);
      this.updateFrontier(obj0, -1L);
    }

    [LineNumberTable(new byte[] {88, 102, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void start()
    {
      this.stop();
      this.thread = Threads.daemon((Runnable) this);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {28, 166, 127, 28, 107, 107, 134, 127, 5, 123, 130, 189, 123, 189, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u00244([In] EventType.WorldLoadEvent obj0)
    {
      this.stop();
      int num1 = Vars.world.width();
      int num2 = Vars.world.height();
      int[] numArray = new int[2];
      int num3 = num2;
      numArray[1] = num3;
      int num4 = num1;
      numArray[0] = num4;
      // ISSUE: type reference
      this.tiles = (int[][]) ByteCodeHelper.multianewarray(__typeref (int[][]), numArray);
      this.threadList = new Seq();
      this.mainList = new Seq();
      this.clearCache();
      Iterator iterator = Vars.world.tiles.iterator();
      while (iterator.hasNext())
      {
        Tile tile = (Tile) iterator.next();
        this.tiles[(int) tile.x][(int) tile.y] = this.packTile(tile);
      }
      this.preloadPath(this.getField(Vars.state.rules.waveTeam, 0, 0));
      if (Vars.spawner.getSpawns().contains((Boolf) new Pathfinder.__\u003C\u003EAnon8()))
        this.preloadPath(this.getField(Vars.state.rules.waveTeam, 2, 0));
      this.start();
    }

    [Modifiers]
    [LineNumberTable(100)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u00245([In] EventType.ResetEvent obj0) => this.stop();

    [Modifiers]
    [LineNumberTable(102)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u00246([In] EventType.TileChangeEvent obj0) => this.updateTile(obj0.__\u003C\u003Etile);

    [Modifiers]
    [LineNumberTable(new byte[] {109, 121, 155})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024updateTile\u00247([In] Tile obj0)
    {
      if (!Structs.inBounds((int) obj0.x, (int) obj0.y, this.tiles))
        return;
      this.tiles[(int) obj0.x][(int) obj0.y] = this.packTile(obj0);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {125, 127, 1, 105, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024updateTile\u00248([In] int obj0, [In] int obj1)
    {
      Iterator iterator = this.threadList.iterator();
      while (iterator.hasNext())
        this.updateTargets((Pathfinder.Flowfield) iterator.next(), obj0, obj1);
    }

    [Modifiers]
    [LineNumberTable(218)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024getField\u00249([In] Pathfinder.Flowfield obj0) => this.registerPath(obj0);

    [Modifiers]
    [LineNumberTable(246)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024getTargetTile\u002410([In] Pathfinder.Flowfield obj0) => this.updateTargets(obj0);

    [Modifiers]
    [LineNumberTable(336)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024registerPath\u002411([In] Pathfinder.Flowfield obj0) => this.mainList.add((object) obj0);

    [Modifiers]
    [LineNumberTable(93)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024new\u00243([In] Tile obj0) => obj0.floor().isLiquid;

    [Modifiers]
    [LineNumberTable(new byte[] {159, 185, 223, 2, 226, 61, 104, 109, 109, 113, 238, 59})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static int lambda\u0024static\u00240([In] Team obj0, [In] int obj1) => (PathTile.team(obj1) == obj0.__\u003C\u003Eid || PathTile.team(obj1) == 0) && PathTile.solid(obj1) ? -1 : 1 + PathTile.health(obj1) * 5 + (!PathTile.nearSolid(obj1) ? 0 : 2) + (!PathTile.nearLiquid(obj1) ? 0 : 6) + (!PathTile.deep(obj1) ? 0 : 6000) + (!PathTile.damages(obj1) ? 0 : 30);

    [Modifiers]
    [LineNumberTable(new byte[] {1, 108, 45})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static int lambda\u0024static\u00241([In] Team obj0, [In] int obj1) => PathTile.legSolid(obj1) ? -1 : 1 + (!PathTile.solid(obj1) ? 0 : 5);

    [Modifiers]
    [LineNumberTable(new byte[] {5, 151, 33, 118, 109, 238, 61})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static int lambda\u0024static\u00242([In] Team obj0, [In] int obj1) => PathTile.solid(obj1) || !PathTile.liquid(obj1) ? 200 : 2 + (PathTile.nearGround(obj1) || PathTile.nearSolid(obj1) ? 14 : 0) + (!PathTile.deep(obj1) ? 0 : -1) + (!PathTile.damages(obj1) ? 0 : 35);

    [LineNumberTable(new byte[] {160, 71, 173, 108, 171, 127, 1, 127, 3, 194, 208, 245, 61, 129, 193, 5, 97, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void run()
    {
      while (!Vars.net.client())
      {
        Exception exception;
        try
        {
          if (Vars.state.isPlaying())
          {
            this.queue.run();
            Iterator iterator = this.threadList.iterator();
            while (iterator.hasNext())
            {
              Pathfinder.Flowfield flowfield = (Pathfinder.Flowfield) iterator.next();
              long maxUpdate = Pathfinder.maxUpdate;
              long size = (long) this.threadList.size;
              long num = size != -1L ? maxUpdate / size : -maxUpdate;
              this.updateFrontier(flowfield, num);
            }
          }
          try
          {
            Thread.sleep(16L);
            continue;
          }
          catch (InterruptedException ex)
          {
          }
        }
        catch (Exception ex)
        {
          exception = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
          goto label_9;
        }
        break;
label_9:
        Throwable.instancehelper_printStackTrace(exception);
      }
    }

    [LineNumberTable(new byte[] {160, 111, 165, 104, 194, 127, 4, 139, 107, 140, 141, 127, 21, 107, 172, 151, 175, 103, 144, 98, 99, 127, 0, 159, 1, 112, 137, 127, 50, 127, 4, 99, 233, 55, 235, 77, 159, 25})]
    [arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Tile getTargetTile(Tile tile, Pathfinder.Flowfield path)
    {
      if (tile == null)
        return (Tile) null;
      if (!path.initialized)
        return tile;
      if (path.refreshRate > 0 && Time.timeSinceMillis(path.lastUpdateTime) > (long) path.refreshRate)
      {
        path.lastUpdateTime = Time.millis();
        this.tmpArray.clear();
        path.getPositions(this.tmpArray);
        lock (path.targets)
        {
          if (path.targets.size == 1 && this.tmpArray.size == 1)
          {
            if (path.targets.first() == this.tmpArray.first())
              goto label_10;
          }
          path.targets.clear();
          path.getPositions(path.targets);
          this.queue.post((Runnable) new Pathfinder.__\u003C\u003EAnon6(this, path));
        }
      }
label_10:
      int[][] weights = path.weights;
      int num1 = weights[(int) tile.x][(int) tile.y];
      Tile tile1 = (Tile) null;
      int num2 = 0;
      Point2[] d8 = Geometry.__\u003C\u003Ed8;
      int length = d8.Length;
      for (int index = 0; index < length; ++index)
      {
        Point2 point2 = d8[index];
        int x = (int) tile.x + point2.x;
        int y = (int) tile.y + point2.y;
        Tile tile2 = Vars.world.tile(x, y);
        if (tile2 != null && weights[x][y] < num1 && (tile1 == null || weights[x][y] < num2) && path.passable(x, y) && (point2.x == 0 || point2.y == 0 || path.passable((int) tile.x + point2.x, (int) tile.y) && path.passable((int) tile.x, (int) tile.y + point2.y)))
        {
          tile1 = tile2;
          num2 = weights[x][y];
        }
      }
      return tile1 == null || num2 == -1 || object.ReferenceEquals((object) path.__\u003C\u003Ecost, (object) ((Pathfinder.PathCost[]) Pathfinder.__\u003C\u003EcostTypes.items)[0]) && tile1.dangerous() && !tile.dangerous() ? tile : tile1;
    }

    [LineNumberTable(new byte[] {159, 137, 141, 236, 73, 255, 11, 74})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static Pathfinder()
    {
      if (ByteCodeHelper.isAlreadyInited("mindustry.ai.Pathfinder"))
        return;
      Pathfinder.maxUpdate = Time.millisToNanos(7L);
      Pathfinder.__\u003C\u003EfieldTypes = Seq.with((object[]) new Prov[2]
      {
        (Prov) new Pathfinder.__\u003C\u003EAnon9(),
        (Prov) new Pathfinder.__\u003C\u003EAnon10()
      });
      Pathfinder.__\u003C\u003EcostTypes = Seq.with((object[]) new Pathfinder.PathCost[3]
      {
        (Pathfinder.PathCost) new Pathfinder.__\u003C\u003EAnon11(),
        (Pathfinder.PathCost) new Pathfinder.__\u003C\u003EAnon12(),
        (Pathfinder.PathCost) new Pathfinder.__\u003C\u003EAnon13()
      });
    }

    [Modifiers]
    public static Seq fieldTypes
    {
      [HideFromJava] get => Pathfinder.__\u003C\u003EfieldTypes;
    }

    [Modifiers]
    public static Seq costTypes
    {
      [HideFromJava] get => Pathfinder.__\u003C\u003EcostTypes;
    }

    public class EnemyCoreField : Pathfinder.Flowfield
    {
      [LineNumberTable(387)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public EnemyCoreField()
      {
      }

      [LineNumberTable(new byte[] {161, 20, 127, 16, 108, 162, 127, 14, 127, 5, 108, 130})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      protected internal override void getPositions(IntSeq @out)
      {
        Iterator iterator1 = Vars.indexer.getEnemy(this.team, BlockFlag.__\u003C\u003Ecore).iterator();
        while (iterator1.hasNext())
        {
          Tile tile = (Tile) iterator1.next();
          @out.add(tile.pos());
        }
        if (!Vars.state.rules.waves || !object.ReferenceEquals((object) this.team, (object) Vars.state.rules.defaultTeam))
          return;
        Iterator iterator2 = Vars.spawner.getSpawns().iterator();
        while (iterator2.hasNext())
        {
          Tile tile = (Tile) iterator2.next();
          @out.add(tile.pos());
        }
      }
    }

    public abstract class Flowfield : Object
    {
      protected internal int refreshRate;
      protected internal Team team;
      internal Pathfinder.PathCost __\u003C\u003Ecost;
      public int[][] weights;
      public int[][] searches;
      internal IntQueue frontier;
      [Modifiers]
      internal IntSeq targets;
      internal int search;
      internal long lastUpdateTime;
      internal bool initialized;

      [LineNumberTable(new byte[] {161, 60, 200, 139, 246, 71, 139, 139})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public Flowfield()
      {
        Pathfinder.Flowfield flowfield = this;
        this.team = Team.__\u003C\u003Ederelict;
        this.__\u003C\u003Ecost = (Pathfinder.PathCost) Pathfinder.__\u003C\u003EcostTypes.get(0);
        this.frontier = new IntQueue();
        this.targets = new IntSeq();
        this.search = 1;
      }

      [LineNumberTable(new byte[] {161, 84, 127, 10, 127, 10, 112, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal virtual void setup([In] int obj0, [In] int obj1)
      {
        int num1 = obj0;
        int num2 = obj1;
        int[] numArray1 = new int[2];
        int num3 = num2;
        numArray1[1] = num3;
        int num4 = num1;
        numArray1[0] = num4;
        // ISSUE: type reference
        this.weights = (int[][]) ByteCodeHelper.multianewarray(__typeref (int[][]), numArray1);
        int num5 = obj0;
        int num6 = obj1;
        int[] numArray2 = new int[2];
        int num7 = num6;
        numArray2[1] = num7;
        int num8 = num5;
        numArray2[0] = num8;
        // ISSUE: type reference
        this.searches = (int[][]) ByteCodeHelper.multianewarray(__typeref (int[][]), numArray2);
        this.frontier.ensureCapacity((obj0 + obj1) * 3);
        this.initialized = true;
      }

      [LineNumberTable(461)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      protected internal virtual bool passable(int x, int y) => this.__\u003C\u003Ecost.getCost(this.team, Vars.pathfinder.tiles[x][y]) != -1;

      protected internal abstract void getPositions(IntSeq @is);

      [Modifiers]
      protected internal object cost
      {
        [HideFromJava] get => (object) this.__\u003C\u003Ecost;
        [HideFromJava] [param: In] set => this.__\u003C\u003Ecost = (Pathfinder.PathCost) value;
      }
    }

    internal interface PathCost
    {
      int getCost([In] Team obj0, [In] int obj1);
    }

    internal class PathTileStruct : Object
    {
      internal int health;
      internal int team;
      internal bool solid;
      internal bool liquid;
      internal bool legSolid;
      internal bool nearLiquid;
      internal bool nearGround;
      internal bool nearSolid;
      internal bool deep;
      internal bool damages;
      [Modifiers]
      internal Pathfinder this\u00240;

      [LineNumberTable(474)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal PathTileStruct([In] Pathfinder obj0)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector();
      }
    }

    public class PositionTarget : Pathfinder.Flowfield
    {
      internal Position __\u003C\u003Eposition;

      [LineNumberTable(new byte[] {161, 45, 104, 103, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public PositionTarget(Position position)
      {
        Pathfinder.PositionTarget positionTarget = this;
        this.__\u003C\u003Eposition = position;
        this.refreshRate = 900;
      }

      [LineNumberTable(new byte[] {161, 52, 127, 14})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void getPositions(IntSeq @out) => @out.add(Point2.pack(World.toTile(this.__\u003C\u003Eposition.getX()), World.toTile(this.__\u003C\u003Eposition.getY())));

      [Modifiers]
      public Position position
      {
        [HideFromJava] get => this.__\u003C\u003Eposition;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Eposition = value;
      }
    }

    public class RallyField : Pathfinder.Flowfield
    {
      [LineNumberTable(403)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public RallyField()
      {
      }

      [LineNumberTable(new byte[] {161, 36, 127, 16, 108, 98})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      protected internal override void getPositions(IntSeq @out)
      {
        Iterator iterator = Vars.indexer.getAllied(this.team, BlockFlag.__\u003C\u003Erally).iterator();
        while (iterator.hasNext())
        {
          Tile tile = (Tile) iterator.next();
          @out.add(tile.pos());
        }
      }
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Cons
    {
      private readonly Pathfinder arg\u00241;

      internal __\u003C\u003EAnon0([In] Pathfinder obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024new\u00244((EventType.WorldLoadEvent) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Cons
    {
      private readonly Pathfinder arg\u00241;

      internal __\u003C\u003EAnon1([In] Pathfinder obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024new\u00245((EventType.ResetEvent) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon2 : Cons
    {
      private readonly Pathfinder arg\u00241;

      internal __\u003C\u003EAnon2([In] Pathfinder obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024new\u00246((EventType.TileChangeEvent) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon3 : Cons
    {
      private readonly Pathfinder arg\u00241;

      internal __\u003C\u003EAnon3([In] Pathfinder obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024updateTile\u00247((Tile) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon4 : Runnable
    {
      private readonly Pathfinder arg\u00241;
      private readonly int arg\u00242;
      private readonly int arg\u00243;

      internal __\u003C\u003EAnon4([In] Pathfinder obj0, [In] int obj1, [In] int obj2)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
      }

      public void run() => this.arg\u00241.lambda\u0024updateTile\u00248(this.arg\u00242, this.arg\u00243);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon5 : Runnable
    {
      private readonly Pathfinder arg\u00241;
      private readonly Pathfinder.Flowfield arg\u00242;

      internal __\u003C\u003EAnon5([In] Pathfinder obj0, [In] Pathfinder.Flowfield obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => this.arg\u00241.lambda\u0024getField\u00249(this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon6 : Runnable
    {
      private readonly Pathfinder arg\u00241;
      private readonly Pathfinder.Flowfield arg\u00242;

      internal __\u003C\u003EAnon6([In] Pathfinder obj0, [In] Pathfinder.Flowfield obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => this.arg\u00241.lambda\u0024getTargetTile\u002410(this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon7 : Runnable
    {
      private readonly Pathfinder arg\u00241;
      private readonly Pathfinder.Flowfield arg\u00242;

      internal __\u003C\u003EAnon7([In] Pathfinder obj0, [In] Pathfinder.Flowfield obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => this.arg\u00241.lambda\u0024registerPath\u002411(this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon8 : Boolf
    {
      internal __\u003C\u003EAnon8()
      {
      }

      public bool get([In] object obj0) => (Pathfinder.lambda\u0024new\u00243((Tile) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon9 : Prov
    {
      internal __\u003C\u003EAnon9()
      {
      }

      public object get() => (object) new Pathfinder.EnemyCoreField();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon10 : Prov
    {
      internal __\u003C\u003EAnon10()
      {
      }

      public object get() => (object) new Pathfinder.RallyField();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon11 : Pathfinder.PathCost
    {
      internal __\u003C\u003EAnon11()
      {
      }

      public int getCost([In] Team obj0, [In] int obj1) => Pathfinder.lambda\u0024static\u00240(obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon12 : Pathfinder.PathCost
    {
      internal __\u003C\u003EAnon12()
      {
      }

      public int getCost([In] Team obj0, [In] int obj1) => Pathfinder.lambda\u0024static\u00241(obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon13 : Pathfinder.PathCost
    {
      internal __\u003C\u003EAnon13()
      {
      }

      public int getCost([In] Team obj0, [In] int obj1) => Pathfinder.lambda\u0024static\u00242(obj0, obj1);
    }
  }
}
