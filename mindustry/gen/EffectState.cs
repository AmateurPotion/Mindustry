// Decompiled with JetBrains decompiler
// Type: mindustry.gen.EffectState
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.func;
using arc.graphics;
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
  [Implements(new string[] {"arc.util.pooling.Pool$Poolable", "mindustry.gen.Rotc", "mindustry.gen.Drawc", "mindustry.gen.Childc", "mindustry.gen.Posc", "mindustry.gen.EffectStatec", "mindustry.gen.Entityc", "mindustry.gen.Timedc"})]
  public class EffectState : 
    Object,
    Pool.Poolable,
    Rotc,
    Entityc,
    Drawc,
    Posc,
    Position,
    Childc,
    EffectStatec,
    Timedc,
    Scaled
  {
    public float rotation;
    [arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})]
    public Posc parent;
    public float offsetX;
    public float offsetY;
    public float x;
    public float y;
    public Color color;
    public Effect effect;
    public object data;
    [NonSerialized]
    public bool added;
    [NonSerialized]
    public int id;
    public float time;
    public float lifetime;

    [LineNumberTable(350)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static EffectState create() => (EffectState) Pools.obtain((Class) ClassLiteral<EffectState>.Value, (Prov) new EffectState.__\u003C\u003EAnon0());

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void set(float x, float y)
    {
      this.x = x;
      this.y = y;
    }

    [LineNumberTable(new byte[] {160, 155, 106, 107, 139, 104, 122, 218, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void add()
    {
      if (this.added)
        return;
      Groups.all.add((Entityc) this);
      Groups.draw.add((Entityc) this);
      if (this.parent != null)
      {
        this.offsetX = this.x - this.parent.getX();
        this.offsetY = this.y - this.parent.getY();
      }
      this.added = true;
    }

    [LineNumberTable(new byte[] {160, 192, 105, 107, 107, 103, 102})]
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

    [LineNumberTable(302)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Tile tileOn() => Vars.world.tileWorld(this.x, this.y);

    [LineNumberTable(331)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isLocal() => object.ReferenceEquals((object) this, (object) Vars.player) || this is Unitc && object.ReferenceEquals((object) ((Unitc) this).controller(), (object) Vars.player);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void afterRead()
    {
    }

    [LineNumberTable(new byte[] {160, 147, 122})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void trns(float x, float y) => this.set(this.x + x, this.y + y);

    [LineNumberTable(new byte[] {160, 65, 232, 50, 245, 72, 235, 71})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal EffectState()
    {
      EffectState effectState = this;
      Color.__\u003Cclinit\u003E();
      this.color = new Color(Color.__\u003C\u003Ewhite);
      this.id = EntityGroup.nextId();
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool serialize() => false;

    [LineNumberTable(188)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toString() => new StringBuilder().append("EffectState#").append(this.id).toString();

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getX() => this.x;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getY() => this.y;

    [LineNumberTable(new byte[] {160, 87, 159, 35})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void draw() => this.lifetime = this.effect.render(this.id, this.color, this.time, this.lifetime, this.rotation, this.x, this.y, this.data);

    [LineNumberTable(new byte[] {160, 93, 104, 122, 218, 127, 0, 110, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void update()
    {
      if (this.parent != null)
      {
        this.x = this.parent.getX() + this.offsetX;
        this.y = this.parent.getY() + this.offsetY;
      }
      this.time = Math.min(this.time + Time.delta, this.lifetime);
      if ((double) this.time < (double) this.lifetime)
        return;
      this.remove();
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isNull() => false;

    [LineNumberTable(new byte[] {160, 111, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Floor floorOn()
    {
      Tile tile = this.tileOn();
      return tile == null || !object.ReferenceEquals((object) tile.block(), (object) Blocks.air) ? (Floor) Blocks.air : tile.floor();
    }

    [LineNumberTable(new byte[] {160, 116, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Block blockOn()
    {
      Tile tile = this.tileOn();
      return tile == null ? Blocks.air : tile.block();
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float fin() => this.time / this.lifetime;

    [LineNumberTable(239)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isRemote() => this is Unitc && ((Unitc) this).isPlayer() && !this.isLocal();

    [LineNumberTable(new byte[] {160, 129, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void set(Position pos) => this.set(pos.getX(), pos.getY());

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void write(Writes write)
    {
    }

    [Signature("<T::Lmindustry/gen/Entityc;>()TT;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Entityc self() => (Entityc) this;

    [LineNumberTable(new byte[] {160, 143, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void read(Reads read) => this.afterRead();

    [Signature("<T:Ljava/lang/Object;>()TT;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object @as() => (object) this;

    [Signature("<T:Ljava/lang/Object;>(Larc/func/Cons<TT;>;)TT;")]
    [LineNumberTable(new byte[] {160, 175, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object with(Cons cons)
    {
      cons.get((object) this);
      return (object) this;
    }

    [LineNumberTable(294)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int tileX() => World.toTile(this.x);

    [LineNumberTable(298)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int tileY() => World.toTile(this.y);

    [LineNumberTable(314)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float clipSize() => this.effect.clip;

    [LineNumberTable(new byte[] {160, 204, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void trns(Position pos) => this.trns(pos.getX(), pos.getY());

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isAdded() => this.added;

    [LineNumberTable(new byte[] {160, 212, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool onSolid()
    {
      Tile tile = this.tileOn();
      return tile == null || tile.solid();
    }

    [LineNumberTable(new byte[] {160, 221, 107, 103, 107, 107, 107, 107, 103, 103, 103, 107, 107, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void reset()
    {
      this.rotation = 0.0f;
      this.parent = (Posc) null;
      this.offsetX = 0.0f;
      this.offsetY = 0.0f;
      this.x = 0.0f;
      this.y = 0.0f;
      this.effect = (Effect) null;
      this.data = (object) null;
      this.added = false;
      this.id = EntityGroup.nextId();
      this.time = 0.0f;
      this.lifetime = 0.0f;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int classId() => 9;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float rotation() => this.rotation;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void rotation(float rotation) => this.rotation = rotation;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Posc parent() => this.parent;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void parent(Posc parent) => this.parent = parent;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float offsetX() => this.offsetX;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void offsetX(float offsetX) => this.offsetX = offsetX;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float offsetY() => this.offsetY;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void offsetY(float offsetY) => this.offsetY = offsetY;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float x() => this.x;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void x(float x) => this.x = x;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float y() => this.y;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void y(float y) => this.y = y;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Color color() => this.color;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void color(Color color) => this.color = color;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Effect effect() => this.effect;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void effect(Effect effect) => this.effect = effect;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object data() => this.data;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void data(object data) => this.data = data;

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

      public object get() => (object) new EffectState();
    }
  }
}
