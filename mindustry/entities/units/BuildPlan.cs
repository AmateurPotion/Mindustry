// Decompiled with JetBrains decompiler
// Type: mindustry.entities.units.BuildPlan
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.func;
using arc.math.geom;
using arc.util;
using IKVM.Attributes;
using java.lang;
using mindustry.game;
using mindustry.gen;
using mindustry.world;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.entities.units
{
  public class BuildPlan : Object, Position
  {
    public int x;
    public int y;
    public int rotation;
    [Nullable(new object[] {64, "Larc/util/Nullable;"})]
    public Block block;
    public bool breaking;
    public object config;
    public int originalX;
    public int originalY;
    public int originalWidth;
    public int originalHeight;
    public float progress;
    public bool initialized;
    public bool worldContext;
    public bool stuck;
    public float animScale;

    [LineNumberTable(76)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool samePos(BuildPlan other) => this.x == other.x && this.y == other.y;

    [LineNumberTable(153)]
    [Nullable(new object[] {64, "Larc/util/Nullable;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Tile tile() => Vars.world.tile(this.x, this.y);

    [LineNumberTable(new byte[] {159, 185, 232, 49, 167, 235, 77, 103, 103, 103, 104, 103, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public BuildPlan(int x, int y, int rotation, Block block, object config)
    {
      BuildPlan buildPlan = this;
      this.worldContext = true;
      this.animScale = 0.0f;
      this.x = x;
      this.y = y;
      this.rotation = rotation;
      this.block = block;
      this.breaking = false;
      this.config = config;
    }

    [LineNumberTable(new byte[] {11, 232, 31, 167, 235, 96})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public BuildPlan()
    {
      BuildPlan buildPlan = this;
      this.worldContext = true;
      this.animScale = 0.0f;
    }

    [LineNumberTable(145)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float drawx() => (float) (this.x * 8) + (this.block != null ? this.block.offset : 0.0f);

    [LineNumberTable(149)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float drawy() => (float) (this.y * 8) + (this.block != null ? this.block.offset : 0.0f);

    [LineNumberTable(157)]
    [Nullable(new object[] {64, "Larc/util/Nullable;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Building build() => Vars.world.build(this.x, this.y);

    [Signature("(Lmindustry/world/Block;Ljava/lang/Object;Larc/func/Cons<Larc/math/geom/Point2;>;)Ljava/lang/Object;")]
    [LineNumberTable(new byte[] {31, 104, 109, 118, 107, 109, 98, 120, 106, 13, 200, 99, 101, 138})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object pointConfig(Block block, object config, Cons cons)
    {
      if (config is Point2)
      {
        config = (object) ((Point2) config).cpy();
        cons.get((object) (Point2) config);
      }
      else if (config is Point2[])
      {
        Point2[] point2Array1 = new Point2[((Point2[]) config).Length];
        int index1 = 0;
        Point2[] point2Array2 = (Point2[]) config;
        int length = point2Array2.Length;
        for (int index2 = 0; index2 < length; ++index2)
        {
          Point2 point2_1 = point2Array2[index2];
          point2Array1[index1] = point2_1.cpy();
          Cons cons1 = cons;
          Point2[] point2Array3 = point2Array1;
          int index3 = index1;
          ++index1;
          Point2 point2_2 = point2Array3[index3];
          cons1.get((object) point2_2);
        }
        config = (object) point2Array1;
      }
      else if (block != null)
        config = block.pointConfig(config, cons);
      return config;
    }

    [LineNumberTable(new byte[] {20, 106, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isRotation(Team team)
    {
      if (this.breaking)
        return false;
      Tile tile = this.tile();
      return tile != null && object.ReferenceEquals((object) tile.team(), (object) team) && (object.ReferenceEquals((object) tile.block(), (object) this.block) && tile.build != null) && tile.build.rotation != this.rotation;
    }

    [LineNumberTable(new byte[] {159, 176, 232, 58, 167, 203, 103, 103, 103, 104, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public BuildPlan(int x, int y, int rotation, Block block)
    {
      BuildPlan buildPlan = this;
      this.worldContext = true;
      this.animScale = 0.0f;
      this.x = x;
      this.y = y;
      this.rotation = rotation;
      this.block = block;
      this.breaking = false;
    }

    [LineNumberTable(new byte[] {3, 232, 39, 167, 235, 87, 103, 103, 103, 119, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public BuildPlan(int x, int y)
    {
      BuildPlan buildPlan = this;
      this.worldContext = true;
      this.animScale = 0.0f;
      this.x = x;
      this.y = y;
      this.rotation = -1;
      this.block = Vars.world.tile(x, y).block();
      this.breaking = true;
    }

    [LineNumberTable(66)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool placeable(Team team) => Build.validPlace(this.block, team, this.x, this.y, this.rotation);

    [Signature("(Larc/func/Cons<Larc/math/geom/Point2;>;)V")]
    [LineNumberTable(new byte[] {50, 120})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void pointConfig(Cons cons) => this.config = BuildPlan.pointConfig(this.block, this.config, cons);

    [LineNumberTable(new byte[] {54, 102, 108, 108, 108, 108, 108, 108, 108, 108, 108, 108, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual BuildPlan copy() => new BuildPlan()
    {
      x = this.x,
      y = this.y,
      rotation = this.rotation,
      block = this.block,
      breaking = this.breaking,
      config = this.config,
      originalX = this.originalX,
      originalY = this.originalY,
      progress = this.progress,
      initialized = this.initialized,
      animScale = this.animScale
    };

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual BuildPlan original(
      int x,
      int y,
      int originalWidth,
      int originalHeight)
    {
      this.originalX = x;
      this.originalY = y;
      this.originalWidth = originalWidth;
      this.originalHeight = originalHeight;
      return this;
    }

    [LineNumberTable(new byte[] {78, 104, 155})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Rect bounds(Rect rect) => this.breaking ? rect.set(-100f, -100f, 0.0f, 0.0f) : this.block.bounds(this.x, this.y, rect);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual BuildPlan set(int x, int y, int rotation, Block block)
    {
      this.x = x;
      this.y = y;
      this.rotation = rotation;
      this.block = block;
      this.breaking = false;
      return this;
    }

    [LineNumberTable(162)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getX() => this.drawx();

    [LineNumberTable(167)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getY() => this.drawy();

    [LineNumberTable(172)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toString() => new StringBuilder().append("BuildPlan{x=").append(this.x).append(", y=").append(this.y).append(", rotation=").append(this.rotation).append(", block=").append((object) this.block).append(", breaking=").append(this.breaking).append(", progress=").append(this.progress).append(", initialized=").append(this.initialized).append(", config=").append(this.config).append('}').toString();

    [HideFromJava]
    public virtual float angleTo([In] Position obj0) => Position.\u003Cdefault\u003EangleTo((Position) this, obj0);

    [HideFromJava]
    public virtual float angleTo([In] float obj0, [In] float obj1) => Position.\u003Cdefault\u003EangleTo((Position) this, obj0, obj1);

    [HideFromJava]
    public virtual float dst2([In] Position obj0) => Position.\u003Cdefault\u003Edst2((Position) this, obj0);

    [HideFromJava]
    public virtual float dst([In] Position obj0) => Position.\u003Cdefault\u003Edst((Position) this, obj0);

    [HideFromJava]
    public virtual float dst([In] float obj0, [In] float obj1) => Position.\u003Cdefault\u003Edst((Position) this, obj0, obj1);

    [HideFromJava]
    public virtual float dst2([In] float obj0, [In] float obj1) => Position.\u003Cdefault\u003Edst2((Position) this, obj0, obj1);

    [HideFromJava]
    public virtual bool within([In] Position obj0, [In] float obj1) => Position.\u003Cdefault\u003Ewithin((Position) this, obj0, obj1);

    [HideFromJava]
    public virtual bool within([In] float obj0, [In] float obj1, [In] float obj2) => Position.\u003Cdefault\u003Ewithin((Position) this, obj0, obj1, obj2);
  }
}
