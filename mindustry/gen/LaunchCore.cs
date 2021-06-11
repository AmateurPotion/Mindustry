// Decompiled with JetBrains decompiler
// Type: mindustry.gen.LaunchCore
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.func;
using arc.graphics.g2d;
using arc.math;
using arc.math.geom;
using arc.util;
using arc.util.io;
using IKVM.Attributes;
using java.lang;
using mindustry.content;
using mindustry.core;
using mindustry.entities;
using mindustry.graphics;
using mindustry.ui;
using mindustry.world;
using mindustry.world.blocks.environment;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.gen
{
  [Implements(new string[] {"mindustry.gen.LaunchCorec", "mindustry.gen.Drawc", "mindustry.gen.Posc", "mindustry.gen.Entityc", "mindustry.gen.Timedc"})]
  public class LaunchCore : Object, LaunchCorec, Drawc, Posc, Position, Entityc, Timedc, Scaled
  {
    [NonSerialized]
    public Interval @in;
    public Block block;
    public float x;
    public float y;
    [NonSerialized]
    public bool added;
    [NonSerialized]
    public int id;
    public float time;
    public float lifetime;

    [LineNumberTable(new byte[] {113, 232, 44, 235, 78, 235, 71})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal LaunchCore()
    {
      LaunchCore launchCore = this;
      this.@in = new Interval();
      this.id = EntityGroup.nextId();
    }

    [HideFromJava]
    public virtual float fout([In] Interp obj0) => Scaled.\u003Cdefault\u003Efout((Scaled) this, obj0);

    [LineNumberTable(326)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float cx() => this.x + this.fin((Interp) Interp.pow2In) * (12f + Mathf.randomSeedRange((long) (this.id() + 3), 4f));

    [LineNumberTable(330)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float cy() => this.y + this.fin((Interp) Interp.pow5In) * (100f + Mathf.randomSeedRange((long) (this.id() + 2), 30f));

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float fin() => this.time / this.lifetime;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int id() => this.id;

    [HideFromJava]
    public virtual float fslope() => Scaled.\u003Cdefault\u003Efslope((Scaled) this);

    [HideFromJava]
    public virtual float fin([In] Interp obj0) => Scaled.\u003Cdefault\u003Efin((Scaled) this, obj0);

    [LineNumberTable(new byte[] {160, 197, 105, 107, 107, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void remove()
    {
      if (!this.added)
        return;
      Groups.all.remove((Entityc) this);
      Groups.draw.remove((Entityc) this);
      this.added = false;
    }

    [LineNumberTable(307)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Tile tileOn() => Vars.world.tileWorld(this.x, this.y);

    [LineNumberTable(339)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isLocal() => object.ReferenceEquals((object) this, (object) Vars.player) || this is Unitc && object.ReferenceEquals((object) ((Unitc) this).controller(), (object) Vars.player);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void set(float x, float y)
    {
      this.x = x;
      this.y = y;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void afterRead()
    {
    }

    [LineNumberTable(new byte[] {160, 164, 122})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void trns(float x, float y) => this.set(this.x + x, this.y + y);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool serialize() => false;

    [LineNumberTable(172)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toString() => new StringBuilder().append("LaunchCore#").append(this.id).toString();

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getX() => this.x;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getY() => this.y;

    [LineNumberTable(new byte[] {160, 71, 109, 119, 104, 104, 127, 5, 106, 106, 112, 119, 127, 47, 102, 104, 63, 22, 168, 101, 106, 114, 116, 116, 102, 118, 127, 4, 106, 124, 127, 15, 133})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void draw()
    {
      float num1 = this.fout((Interp) Interp.pow5Out);
      float num2 = (1f - num1) * 1.4f + 1f;
      float x = this.cx();
      float y = this.cy();
      float num3 = this.fin() * (140f + Mathf.randomSeedRange((long) this.id(), 50f));
      Draw.z(110.001f);
      Draw.color(Pal.engine);
      float num4 = 0.2f + this.fslope();
      float num5 = (float) (this.block.size - 1) * 0.85f;
      Fill.light(x, y, 10, 25f * (num4 + num2 - 1f) * num5, Tmp.__\u003C\u003Ec2.set(Pal.engine).a(num1), Tmp.__\u003C\u003Ec1.set(Pal.engine).a(0.0f));
      Draw.alpha(num1);
      for (int index = 0; index < 4; ++index)
        Drawf.tri(x, y, 6f * num5, 40f * (num4 + num2 - 1f) * num5, (float) index * 90f + num3);
      Draw.color();
      Draw.z(129f);
      TextureRegion region = this.block.icon(Cicon.__\u003C\u003Efull);
      float w = (float) region.width * Draw.scl * num2;
      float h = (float) region.height * Draw.scl * num2;
      Draw.alpha(num1);
      Draw.rect(region, x, y, w, h, num3 - 45f);
      Tmp.__\u003C\u003Ev1.trns(225f, this.fin((Interp) Interp.pow3In) * 250f);
      Draw.z(116f);
      Draw.color(0.0f, 0.0f, 0.0f, 0.22f * num1);
      Draw.rect(region, x + Tmp.__\u003C\u003Ev1.x, y + Tmp.__\u003C\u003Ev1.y, w, h, num3 - 45f);
      Draw.reset();
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isAdded() => this.added;

    [LineNumberTable(new byte[] {160, 106, 102, 127, 3, 223, 18, 127, 0, 110, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void update()
    {
      float range = 4f;
      if (this.@in.get(3f - this.fin() * 2f))
        Fx.__\u003C\u003ErocketSmokeLarge.at(this.cx() + Mathf.range(range), this.cy() + Mathf.range(range), this.fin());
      this.time = Math.min(this.time + Time.delta, this.lifetime);
      if ((double) this.time < (double) this.lifetime)
        return;
      this.remove();
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isNull() => false;

    [LineNumberTable(new byte[] {160, 124, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Floor floorOn()
    {
      Tile tile = this.tileOn();
      return tile == null || !object.ReferenceEquals((object) tile.block(), (object) Blocks.air) ? (Floor) Blocks.air : tile.floor();
    }

    [LineNumberTable(new byte[] {160, 129, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Block blockOn()
    {
      Tile tile = this.tileOn();
      return tile == null ? Blocks.air : tile.block();
    }

    [LineNumberTable(252)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isRemote() => this is Unitc && ((Unitc) this).isPlayer() && !this.isLocal();

    [LineNumberTable(new byte[] {160, 142, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void set(Position pos) => this.set(pos.getX(), pos.getY());

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void write(Writes write)
    {
    }

    [Signature("<T::Lmindustry/gen/Entityc;>()TT;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Entityc self() => (Entityc) this;

    [LineNumberTable(new byte[] {160, 156, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void read(Reads read) => this.afterRead();

    [Signature("<T:Ljava/lang/Object;>()TT;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object @as() => (object) this;

    [LineNumberTable(new byte[] {160, 173, 106, 107, 107, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void add()
    {
      if (this.added)
        return;
      Groups.all.add((Entityc) this);
      Groups.draw.add((Entityc) this);
      this.added = true;
    }

    [Signature("<T:Ljava/lang/Object;>(Larc/func/Cons<TT;>;)TT;")]
    [LineNumberTable(new byte[] {160, 180, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object with(Cons cons)
    {
      cons.get((object) this);
      return (object) this;
    }

    [LineNumberTable(299)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int tileX() => World.toTile(this.x);

    [LineNumberTable(303)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int tileY() => World.toTile(this.y);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float clipSize() => float.MaxValue;

    [LineNumberTable(new byte[] {160, 208, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void trns(Position pos) => this.trns(pos.getX(), pos.getY());

    [LineNumberTable(new byte[] {160, 220, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool onSolid()
    {
      Tile tile = this.tileOn();
      return tile == null || tile.solid();
    }

    [LineNumberTable(343)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static LaunchCore create() => new LaunchCore();

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int classId() => 11;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Interval @in() => this.@in;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void @in(Interval @in) => this.@in = @in;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Block block() => this.block;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void block(Block block) => this.block = block;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float x() => this.x;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void x(float x) => this.x = x;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float y() => this.y;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void y(float y) => this.y = y;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void id(int id) => this.id = id;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float time() => this.time;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void time(float time) => this.time = time;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float lifetime() => this.lifetime;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void lifetime(float lifetime) => this.lifetime = lifetime;

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

    [HideFromJava]
    public virtual float fout() => Scaled.\u003Cdefault\u003Efout((Scaled) this);

    [HideFromJava]
    public virtual float fout([In] float obj0) => Scaled.\u003Cdefault\u003Efout((Scaled) this, obj0);

    [HideFromJava]
    public virtual float finpow() => Scaled.\u003Cdefault\u003Efinpow((Scaled) this);
  }
}
