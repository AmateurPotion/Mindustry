// Decompiled with JetBrains decompiler
// Type: mindustry.entities.comp.MinerComp
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.func;
using arc.graphics;
using arc.graphics.g2d;
using arc.math;
using arc.math.geom;
using arc.util;
using arc.util.io;
using IKVM.Attributes;
using java.lang;
using mindustry.content;
using mindustry.game;
using mindustry.gen;
using mindustry.graphics;
using mindustry.input;
using mindustry.type;
using mindustry.world;
using mindustry.world.blocks.environment;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.entities.comp
{
  [Implements(new string[] {"mindustry.gen.Itemsc", "mindustry.gen.Posc", "mindustry.gen.Teamc", "mindustry.gen.Rotc", "mindustry.gen.Drawc"})]
  internal abstract class MinerComp : Object, Itemsc, Posc, Position, Entityc, Teamc, Rotc, Drawc
  {
    internal float x;
    internal float y;
    internal float rotation;
    internal float hitSize;
    internal UnitType type;
    [NonSerialized]
    internal float mineTimer;
    [arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})]
    internal Tile mineTile;

    [HideFromJava]
    public abstract Entityc self();

    [HideFromJava]
    public virtual bool within([In] float obj0, [In] float obj1, [In] float obj2) => Position.\u003Cdefault\u003Ewithin((Position) this, obj0, obj1, obj2);

    [LineNumberTable(27)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool canMine([In] Item obj0) => this.type.mineTier >= obj0.hardness;

    [LineNumberTable(new byte[] {159, 133, 162, 127, 21, 57})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool validMine([In] Tile obj0, [In] bool obj1)
    {
      int num = obj1 ? 1 : 0;
      return obj0 != null && object.ReferenceEquals((object) obj0.block(), (object) Blocks.air) && (this.within(obj0.worldx(), obj0.worldy(), 70f) || num == 0) && (obj0.drop() != null && this.canMine(obj0.drop()));
    }

    [HideFromJava]
    public abstract Building closestCore();

    [HideFromJava]
    public abstract bool acceptsItem([In] Item obj0);

    [HideFromJava]
    public virtual bool within([In] Position obj0, [In] float obj1) => Position.\u003Cdefault\u003Ewithin((Position) this, obj0, obj1);

    [LineNumberTable(31)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool offloadImmediately() => ((Unit) this.self()).isPlayer();

    [HideFromJava]
    public abstract Item item();

    [HideFromJava]
    public abstract ItemStack stack();

    [HideFromJava]
    public abstract void clearItem();

    [LineNumberTable(44)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool validMine([In] Tile obj0) => this.validMine(obj0, true);

    [LineNumberTable(35)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual bool mining() => this.mineTile != null && !((Unit) this.self()).activelyBuilding();

    [HideFromJava]
    public abstract Team team();

    [HideFromJava]
    public abstract void addItem([In] Item obj0);

    [HideFromJava]
    public abstract bool isLocal();

    [LineNumberTable(19)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal MinerComp()
    {
    }

    [LineNumberTable(48)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool canMine() => (double) this.type.mineSpeed > 0.0 && this.type.mineTier >= 0;

    [LineNumberTable(new byte[] {3, 135, 127, 52, 121, 100, 120, 121, 20, 165, 198, 110, 103, 112, 107, 108, 159, 1, 120, 191, 40, 127, 1, 139, 159, 41, 159, 18, 127, 2, 115, 121, 20, 167, 137, 103, 121, 20, 231, 69, 103, 203, 103, 191, 7})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void update()
    {
      Building build = this.closestCore();
      if (build != null && this.mineTile != null && (this.mineTile.drop() != null && !this.acceptsItem(this.mineTile.drop())) && (this.within((Position) build, 220f) && !this.offloadImmediately()))
      {
        int amount = build.acceptStack(this.item(), this.stack().amount, (Teamc) this);
        if (amount > 0)
        {
          Call.transferItemTo((Unit) this.self(), this.item(), amount, this.mineTile.worldx() + Mathf.range(4f), this.mineTile.worldy() + Mathf.range(4f), build);
          this.clearItem();
        }
      }
      if (!this.validMine(this.mineTile))
      {
        this.mineTile = (Tile) null;
        this.mineTimer = 0.0f;
      }
      else
      {
        if (!this.mining())
          return;
        Item obj = this.mineTile.drop();
        this.mineTimer += Time.delta * this.type.mineSpeed;
        if (Mathf.chance(0.06 * (double) Time.delta))
          Fx.__\u003C\u003EpulverizeSmall.at(this.mineTile.worldx() + Mathf.range(4f), this.mineTile.worldy() + Mathf.range(4f), 0.0f, obj.color);
        if ((double) this.mineTimer >= (double) (50f + (float) obj.hardness * 15f))
        {
          this.mineTimer = 0.0f;
          if (Vars.state.rules.sector != null && object.ReferenceEquals((object) this.team(), (object) Vars.state.rules.defaultTeam))
            Vars.state.rules.sector.info.handleProduction(obj, 1);
          if (build != null && this.within((Position) build, 220f) && (build.acceptStack(obj, 1, (Teamc) this) == 1 && this.offloadImmediately()))
          {
            if (object.ReferenceEquals((object) this.item(), (object) obj) && !Vars.net.client())
              this.addItem(obj);
            Call.transferItemTo((Unit) this.self(), obj, 1, this.mineTile.worldx() + Mathf.range(4f), this.mineTile.worldy() + Mathf.range(4f), build);
          }
          else if (this.acceptsItem(obj))
          {
            InputHandler.transferItemToUnit(obj, this.mineTile.worldx() + Mathf.range(4f), this.mineTile.worldy() + Mathf.range(4f), (Itemsc) this);
          }
          else
          {
            this.mineTile = (Tile) null;
            this.mineTimer = 0.0f;
          }
        }
        if (Vars.headless)
          return;
        Vars.control.sound.loop(this.type.mineSound, (Position) this, this.type.mineSoundVolume);
      }
    }

    [LineNumberTable(new byte[] {57, 105, 127, 6, 108, 134, 119, 151, 127, 5, 159, 12, 138, 159, 11, 159, 23, 104, 111, 191, 16, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void draw()
    {
      if (!this.mining())
        return;
      float len = this.hitSize / 2f + Mathf.absin(Time.time, 1.1f, 0.5f);
      float scl = 12f;
      float mag1 = 1f;
      float mag2 = 0.3f;
      float x = this.x + Angles.trnsx(this.rotation, len);
      float y = this.y + Angles.trnsy(this.rotation, len);
      float x2 = this.mineTile.worldx() + Mathf.sin(Time.time + 48f, scl, mag1);
      float y2 = this.mineTile.worldy() + Mathf.sin(Time.time + 48f, scl + 2f, mag1);
      Draw.z(115.1f);
      Draw.color(Color.__\u003C\u003ElightGray, Color.__\u003C\u003Ewhite, 1f - mag2 + Mathf.absin(Time.time, 0.5f, mag2));
      Drawf.laser(this.team(), (TextureRegion) Core.atlas.find("minelaser"), (TextureRegion) Core.atlas.find("minelaser-end"), x, y, x2, y2, 0.75f);
      if (this.isLocal())
      {
        Lines.stroke(1f, Pal.accent);
        Lines.poly(this.mineTile.worldx(), this.mineTile.worldy(), 4, 4f * Mathf.__\u003C\u003Esqrt2, Time.time);
      }
      Draw.color();
    }

    [HideFromJava]
    public abstract float getX();

    [HideFromJava]
    public abstract float getY();

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
    public abstract bool isAdded();

    [HideFromJava]
    public abstract void remove();

    [HideFromJava]
    public abstract void add();

    [HideFromJava]
    public abstract bool isRemote();

    [HideFromJava]
    public abstract bool isNull();

    [HideFromJava]
    public abstract object @as();

    [HideFromJava]
    public abstract object with([In] Cons obj0);

    [HideFromJava]
    public abstract int classId();

    [HideFromJava]
    public abstract bool serialize();

    [HideFromJava]
    public abstract void read([In] Reads obj0);

    [HideFromJava]
    public abstract void write([In] Writes obj0);

    [HideFromJava]
    public abstract void afterRead();

    [HideFromJava]
    public abstract int id();

    [HideFromJava]
    public abstract void id([In] int obj0);

    [HideFromJava]
    public abstract void set([In] float obj0, [In] float obj1);

    [HideFromJava]
    public abstract void set([In] Position obj0);

    [HideFromJava]
    public abstract void trns([In] float obj0, [In] float obj1);

    [HideFromJava]
    public abstract void trns([In] Position obj0);

    [HideFromJava]
    public abstract int tileX();

    [HideFromJava]
    public abstract int tileY();

    [HideFromJava]
    public abstract Floor floorOn();

    [HideFromJava]
    public abstract Block blockOn();

    [HideFromJava]
    public abstract bool onSolid();

    [HideFromJava]
    public abstract Tile tileOn();

    [HideFromJava]
    public abstract float x();

    [HideFromJava]
    public abstract void x([In] float obj0);

    [HideFromJava]
    public abstract float y();

    [HideFromJava]
    public abstract void y([In] float obj0);

    [HideFromJava]
    public abstract int itemCapacity();

    [HideFromJava]
    public abstract bool hasItem();

    [HideFromJava]
    public abstract void addItem([In] Item obj0, [In] int obj1);

    [HideFromJava]
    public abstract int maxAccepted([In] Item obj0);

    [HideFromJava]
    public abstract void stack([In] ItemStack obj0);

    [HideFromJava]
    public abstract float itemTime();

    [HideFromJava]
    public abstract void itemTime([In] float obj0);

    [HideFromJava]
    public abstract bool cheating();

    [HideFromJava]
    public abstract Building core();

    [HideFromJava]
    public abstract Building closestEnemyCore();

    [HideFromJava]
    public abstract void team([In] Team obj0);

    [HideFromJava]
    public abstract float rotation();

    [HideFromJava]
    public abstract void rotation([In] float obj0);

    [HideFromJava]
    public abstract float clipSize();
  }
}
