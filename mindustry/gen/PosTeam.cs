// Decompiled with JetBrains decompiler
// Type: mindustry.gen.PosTeam
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.func;
using arc.math.geom;
using arc.util.io;
using IKVM.Attributes;
using java.lang;
using mindustry.content;
using mindustry.core;
using mindustry.entities;
using mindustry.game;
using mindustry.world;
using mindustry.world.blocks.environment;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.gen
{
  [Implements(new string[] {"mindustry.gen.Posc", "mindustry.gen.Teamc", "mindustry.gen.Entityc"})]
  public class PosTeam : Object, Posc, Position, Entityc, Teamc
  {
    public float x;
    public float y;
    public Team team;
    [NonSerialized]
    public bool added;
    [NonSerialized]
    public int id;

    [LineNumberTable(292)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static PosTeam create() => new PosTeam();

    [LineNumberTable(new byte[] {107, 232, 58, 203, 171})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal PosTeam()
    {
      PosTeam posTeam = this;
      this.team = Team.__\u003C\u003Ederelict;
      this.id = EntityGroup.nextId();
    }

    [LineNumberTable(263)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Tile tileOn() => Vars.world.tileWorld(this.x, this.y);

    [LineNumberTable(288)]
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

    [LineNumberTable(new byte[] {160, 121, 122})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void trns(float x, float y) => this.set(this.x + x, this.y + y);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool serialize() => true;

    [LineNumberTable(166)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toString() => new StringBuilder().append("PosTeam#").append(this.id).toString();

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getX() => this.x;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getY() => this.y;

    [LineNumberTable(new byte[] {160, 64, 105, 107, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void remove()
    {
      if (!this.added)
        return;
      Groups.all.remove((Entityc) this);
      this.added = false;
    }

    [Signature("<T:Ljava/lang/Object;>()TT;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object @as() => (object) this;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void update()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isNull() => false;

    [LineNumberTable(new byte[] {160, 81, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Floor floorOn()
    {
      Tile tile = this.tileOn();
      return tile == null || !object.ReferenceEquals((object) tile.block(), (object) Blocks.air) ? (Floor) Blocks.air : tile.floor();
    }

    [LineNumberTable(new byte[] {160, 86, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Block blockOn()
    {
      Tile tile = this.tileOn();
      return tile == null ? Blocks.air : tile.block();
    }

    [LineNumberTable(205)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isRemote() => this is Unitc && ((Unitc) this).isPlayer() && !this.isLocal();

    [LineNumberTable(new byte[] {160, 95, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void set(Position pos) => this.set(pos.getX(), pos.getY());

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void write(Writes write)
    {
    }

    [Signature("<T::Lmindustry/gen/Entityc;>()TT;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Entityc self() => (Entityc) this;

    [LineNumberTable(new byte[] {160, 109, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void read(Reads read) => this.afterRead();

    [LineNumberTable(227)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Building closestCore() => (Building) Vars.state.teams.closestCore(this.x, this.y, this.team);

    [LineNumberTable(231)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Building core() => (Building) this.team.core();

    [LineNumberTable(new byte[] {160, 130, 106, 107, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void add()
    {
      if (this.added)
        return;
      Groups.all.add((Entityc) this);
      this.added = true;
    }

    [Signature("<T:Ljava/lang/Object;>(Larc/func/Cons<TT;>;)TT;")]
    [LineNumberTable(new byte[] {160, 136, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object with(Cons cons)
    {
      cons.get((object) this);
      return (object) this;
    }

    [LineNumberTable(255)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int tileX() => World.toTile(this.x);

    [LineNumberTable(259)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int tileY() => World.toTile(this.y);

    [LineNumberTable(267)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Building closestEnemyCore() => (Building) Vars.state.teams.closestEnemyCore(this.x, this.y, this.team);

    [LineNumberTable(271)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool cheating() => this.team.rules().cheat;

    [LineNumberTable(new byte[] {160, 161, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void trns(Position pos) => this.trns(pos.getX(), pos.getY());

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isAdded() => this.added;

    [LineNumberTable(new byte[] {160, 169, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool onSolid()
    {
      Tile tile = this.tileOn();
      return tile == null || tile.solid();
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int classId() => 28;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float x() => this.x;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void x(float x) => this.x = x;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float y() => this.y;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void y(float y) => this.y = y;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Team team() => this.team;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void team(Team team) => this.team = team;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int id() => this.id;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void id(int id) => this.id = id;

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
