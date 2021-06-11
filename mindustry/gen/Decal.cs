// Decompiled with JetBrains decompiler
// Type: mindustry.gen.Decal
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.func;
using arc.graphics;
using arc.graphics.g2d;
using arc.math;
using arc.math.geom;
using arc.util;
using arc.util.io;
using arc.util.pooling;
using ikvm.@internal;
using IKVM.Attributes;
using java.lang;
using mindustry.content;
using mindustry.core;
using mindustry.entities;
using mindustry.world;
using mindustry.world.blocks.environment;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.gen
{
  [Implements(new string[] {"arc.util.pooling.Pool$Poolable", "mindustry.gen.Rotc", "mindustry.gen.Drawc", "mindustry.gen.Posc", "mindustry.gen.Decalc", "mindustry.gen.Entityc", "mindustry.gen.Timedc"})]
  public class Decal : 
    Object,
    Pool.Poolable,
    Rotc,
    Entityc,
    Drawc,
    Posc,
    Position,
    Decalc,
    Timedc,
    Scaled
  {
    public float rotation;
    public float x;
    public float y;
    public Color color;
    public TextureRegion region;
    [NonSerialized]
    public bool added;
    [NonSerialized]
    public int id;
    public float time;
    public float lifetime;

    [LineNumberTable(326)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Decal create() => (Decal) Pools.obtain((Class) ClassLiteral<Decal>.Value, (Prov) new Decal.__\u003C\u003EAnon0());

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void set(float x, float y)
    {
      this.x = x;
      this.y = y;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void rotation(float rotation) => this.rotation = rotation;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void lifetime(float lifetime) => this.lifetime = lifetime;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Color color() => this.color;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void region(TextureRegion region) => this.region = region;

    [LineNumberTable(new byte[] {160, 148, 106, 107, 107, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void add()
    {
      if (this.added)
        return;
      Groups.all.add((Entityc) this);
      Groups.draw.add((Entityc) this);
      this.added = true;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float fin() => this.time / this.lifetime;

    [LineNumberTable(new byte[] {160, 172, 105, 107, 107, 103, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void remove()
    {
      if (!this.added)
        return;
      Groups.all.remove((Entityc) this);
      Groups.draw.remove((Entityc) this);
      this.added = false;
      Groups.queueFree((Pool.Poolable) this);
    }

    [LineNumberTable(282)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Tile tileOn() => Vars.world.tileWorld(this.x, this.y);

    [LineNumberTable(311)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isLocal() => object.ReferenceEquals((object) this, (object) Vars.player) || this is Unitc && object.ReferenceEquals((object) ((Unitc) this).controller(), (object) Vars.player);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void afterRead()
    {
    }

    [LineNumberTable(new byte[] {160, 139, 122})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void trns(float x, float y) => this.set(this.x + x, this.y + y);

    [LineNumberTable(new byte[] {119, 232, 52, 255, 0, 70, 235, 71})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal Decal()
    {
      Decal decal = this;
      this.color = new Color(1f, 1f, 1f, 1f);
      this.id = EntityGroup.nextId();
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool serialize() => false;

    [LineNumberTable(178)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toString() => new StringBuilder().append("Decal#").append(this.id).toString();

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getX() => this.x;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getY() => this.y;

    [LineNumberTable(new byte[] {160, 77, 106, 118, 126, 125, 133})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void draw()
    {
      Draw.z(10f);
      Draw.mixcol(this.color, this.color.a);
      Draw.alpha(1f - Mathf.curve(this.fin(), 0.98f));
      Draw.rect(this.region, this.x, this.y, this.rotation);
      Draw.reset();
    }

    [LineNumberTable(new byte[] {160, 87, 127, 0, 110, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void update()
    {
      this.time = Math.min(this.time + Time.delta, this.lifetime);
      if ((double) this.time < (double) this.lifetime)
        return;
      this.remove();
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isNull() => false;

    [LineNumberTable(new byte[] {160, 99, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Floor floorOn()
    {
      Tile tile = this.tileOn();
      return tile == null || !object.ReferenceEquals((object) tile.block(), (object) Blocks.air) ? (Floor) Blocks.air : tile.floor();
    }

    [LineNumberTable(new byte[] {160, 104, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Block blockOn()
    {
      Tile tile = this.tileOn();
      return tile == null ? Blocks.air : tile.block();
    }

    [LineNumberTable(227)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isRemote() => this is Unitc && ((Unitc) this).isPlayer() && !this.isLocal();

    [LineNumberTable(new byte[] {160, 117, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void set(Position pos) => this.set(pos.getX(), pos.getY());

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void write(Writes write)
    {
    }

    [Signature("<T::Lmindustry/gen/Entityc;>()TT;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Entityc self() => (Entityc) this;

    [LineNumberTable(new byte[] {160, 131, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void read(Reads read) => this.afterRead();

    [Signature("<T:Ljava/lang/Object;>()TT;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object @as() => (object) this;

    [Signature("<T:Ljava/lang/Object;>(Larc/func/Cons<TT;>;)TT;")]
    [LineNumberTable(new byte[] {160, 155, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object with(Cons cons)
    {
      cons.get((object) this);
      return (object) this;
    }

    [LineNumberTable(274)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int tileX() => World.toTile(this.x);

    [LineNumberTable(278)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int tileY() => World.toTile(this.y);

    [LineNumberTable(294)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float clipSize() => (float) (this.region.width * 2);

    [LineNumberTable(new byte[] {160, 184, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void trns(Position pos) => this.trns(pos.getX(), pos.getY());

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isAdded() => this.added;

    [LineNumberTable(new byte[] {160, 192, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool onSolid()
    {
      Tile tile = this.tileOn();
      return tile == null || tile.solid();
    }

    [LineNumberTable(new byte[] {160, 201, 107, 107, 107, 103, 103, 107, 107, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void reset()
    {
      this.rotation = 0.0f;
      this.x = 0.0f;
      this.y = 0.0f;
      this.region = (TextureRegion) null;
      this.added = false;
      this.id = EntityGroup.nextId();
      this.time = 0.0f;
      this.lifetime = 0.0f;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int classId() => 8;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float rotation() => this.rotation;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float x() => this.x;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void x(float x) => this.x = x;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float y() => this.y;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void y(float y) => this.y = y;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void color(Color color) => this.color = color;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual TextureRegion region() => this.region;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int id() => this.id;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void id(int id) => this.id = id;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float time() => this.time;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void time(float time) => this.time = time;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float lifetime() => this.lifetime;

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
    public virtual float fout([In] Interp obj0) => Scaled.\u003Cdefault\u003Efout((Scaled) this, obj0);

    [HideFromJava]
    public virtual float fout([In] float obj0) => Scaled.\u003Cdefault\u003Efout((Scaled) this, obj0);

    [HideFromJava]
    public virtual float fin([In] Interp obj0) => Scaled.\u003Cdefault\u003Efin((Scaled) this, obj0);

    [HideFromJava]
    public virtual float finpow() => Scaled.\u003Cdefault\u003Efinpow((Scaled) this);

    [HideFromJava]
    public virtual float fslope() => Scaled.\u003Cdefault\u003Efslope((Scaled) this);

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Prov
    {
      internal __\u003C\u003EAnon0()
      {
      }

      public object get() => (object) new Decal();
    }
  }
}
