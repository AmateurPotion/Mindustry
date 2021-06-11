// Decompiled with JetBrains decompiler
// Type: mindustry.entities.comp.StatusComp
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.func;
using arc.graphics;
using arc.math.geom;
using arc.util;
using arc.util.io;
using arc.util.pooling;
using ikvm.@internal;
using IKVM.Attributes;
using java.lang;
using java.util;
using mindustry.content;
using mindustry.ctype;
using mindustry.entities.units;
using mindustry.gen;
using mindustry.type;
using mindustry.world;
using mindustry.world.blocks.environment;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.entities.comp
{
  [Implements(new string[] {"mindustry.gen.Posc", "mindustry.gen.Flyingc"})]
  internal abstract class StatusComp : 
    Object,
    Posc,
    Position,
    Entityc,
    Flyingc,
    Healthc,
    Hitboxc,
    Sized,
    QuadTree.QuadTreeObject,
    Velc
  {
    [Signature("Larc/struct/Seq<Lmindustry/entities/units/StatusEntry;>;")]
    private Seq statuses;
    [NonSerialized]
    private Bits applied;
    [NonSerialized]
    internal float speedMultiplier;
    [NonSerialized]
    internal float damageMultiplier;
    [NonSerialized]
    internal float healthMultiplier;
    [NonSerialized]
    internal float reloadMultiplier;
    [NonSerialized]
    internal float buildSpeedMultiplier;
    [NonSerialized]
    internal float dragMultiplier;
    [NonSerialized]
    internal bool disarmed;
    internal UnitType type;

    [LineNumberTable(new byte[] {159, 176, 186, 108, 166, 145, 115, 146, 110, 116, 97, 113, 112, 127, 6, 144, 119, 208, 225, 48, 233, 85, 136, 122, 106, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void apply([In] StatusEffect obj0, [In] float obj1)
    {
      if (object.ReferenceEquals((object) obj0, (object) StatusEffects.none) || obj0 == null || this.isImmune(obj0))
        return;
      if (Vars.state.isCampaign())
        obj0.unlock();
      if (this.statuses.size > 0)
      {
        for (int index = 0; index < this.statuses.size; ++index)
        {
          StatusEntry statusEntry = (StatusEntry) this.statuses.get(index);
          if (object.ReferenceEquals((object) statusEntry.effect, (object) obj0))
          {
            statusEntry.time = Math.max(statusEntry.time, obj1);
            return;
          }
          if (statusEntry.effect.reactsWith(obj0))
          {
            StatusEntry.__\u003C\u003Etmp.effect = statusEntry.effect;
            statusEntry.effect.getTransition((Unit) this.self(), obj0, statusEntry.time, obj1, StatusEntry.__\u003C\u003Etmp);
            statusEntry.time = StatusEntry.__\u003C\u003Etmp.time;
            if (object.ReferenceEquals((object) StatusEntry.__\u003C\u003Etmp.effect, (object) statusEntry.effect))
              return;
            statusEntry.effect = StatusEntry.__\u003C\u003Etmp.effect;
            return;
          }
        }
      }
      if (obj0.reactive)
        return;
      StatusEntry statusEntry1 = (StatusEntry) Pools.obtain((Class) ClassLiteral<StatusEntry>.Value, (Prov) new StatusComp.__\u003C\u003EAnon0());
      statusEntry1.set(obj0, obj1);
      this.statuses.add((object) statusEntry1);
    }

    internal abstract bool isImmune([In] StatusEffect obj0);

    [HideFromJava]
    public abstract Entityc self();

    [LineNumberTable(159)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual bool hasEffect([In] StatusEffect obj0) => this.applied.get((int) obj0.__\u003C\u003Eid);

    [HideFromJava]
    public abstract Floor floorOn();

    [HideFromJava]
    public abstract bool isGrounded();

    [Modifiers]
    [LineNumberTable(new byte[] {29, 110, 102, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024unapply\u00240([In] StatusEffect obj0, [In] StatusEntry obj1)
    {
      if (!object.ReferenceEquals((object) obj1.effect, (object) obj0))
        return false;
      Pools.free((object) obj1);
      return true;
    }

    [LineNumberTable(new byte[] {159, 160, 104, 107, 159, 0, 127, 35})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal StatusComp()
    {
      StatusComp statusComp = this;
      this.statuses = new Seq();
      this.applied = new Bits(Vars.content.getBy(ContentType.__\u003C\u003Estatus).size);
      this.speedMultiplier = 1f;
      this.damageMultiplier = 1f;
      this.healthMultiplier = 1f;
      this.reloadMultiplier = 1f;
      this.buildSpeedMultiplier = 1f;
      this.dragMultiplier = 1f;
      this.disarmed = false;
    }

    [LineNumberTable(new byte[] {159, 171, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void apply([In] StatusEffect obj0) => this.apply(obj0, 1f);

    [LineNumberTable(new byte[] {23, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void clearStatuses() => this.statuses.clear();

    [LineNumberTable(new byte[] {28, 247, 71})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void unapply([In] StatusEffect obj0) => this.statuses.remove((Boolf) new StatusComp.__\u003C\u003EAnon1(obj0));

    [LineNumberTable(88)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual bool isBoss() => this.hasEffect(StatusEffects.boss);

    [LineNumberTable(new byte[] {44, 109, 176, 120, 127, 8, 127, 6, 121, 121, 121, 102, 101, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual Color statusColor()
    {
      if (this.statuses.size == 0)
        return Tmp.__\u003C\u003Ec1.set(Color.__\u003C\u003Ewhite);
      float num1 = 1f;
      float num2 = 1f;
      float num3 = 1f;
      float num4 = 0.0f;
      Iterator iterator = this.statuses.iterator();
      while (iterator.hasNext())
      {
        StatusEntry statusEntry = (StatusEntry) iterator.next();
        float num5 = (double) statusEntry.time >= 10.0 ? 1f : statusEntry.time / 10f;
        num1 += statusEntry.effect.color.r * num5;
        num2 += statusEntry.effect.color.g * num5;
        num3 += statusEntry.effect.color.b * num5;
        num4 += num5;
      }
      float num6 = (float) this.statuses.size + num4;
      return Tmp.__\u003C\u003Ec1.set(num1 / num6, num2 / num6, num3 / num6, 1f);
    }

    [LineNumberTable(new byte[] {62, 103, 149, 178, 107, 127, 35, 135, 142, 130, 113, 150, 158, 127, 3, 102, 100, 146, 150, 121, 121, 121, 121, 121, 153, 152, 156, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void update()
    {
      Floor floor = this.floorOn();
      if (this.isGrounded() && !this.type.hovering)
        this.apply(floor.status, floor.statusDuration);
      this.applied.clear();
      StatusComp statusComp1 = this;
      StatusComp statusComp2 = this;
      StatusComp statusComp3 = this;
      StatusComp statusComp4 = this;
      StatusComp statusComp5 = this;
      float num1 = 1f;
      double num2 = (double) num1;
      this.dragMultiplier = num1;
      float num3 = (float) num2;
      double num4 = (double) num3;
      this.buildSpeedMultiplier = num3;
      float num5 = (float) num4;
      double num6 = (double) num5;
      this.reloadMultiplier = num5;
      float num7 = (float) num6;
      double num8 = (double) num7;
      this.healthMultiplier = num7;
      float num9 = (float) num8;
      double num10 = (double) num9;
      this.damageMultiplier = num9;
      this.speedMultiplier = (float) num10;
      this.disarmed = false;
      if (this.statuses.isEmpty())
        return;
      int index1 = 0;
      while (index1 < this.statuses.size)
      {
        Seq statuses = this.statuses;
        int index2 = index1;
        ++index1;
        StatusEntry statusEntry = (StatusEntry) statuses.get(index2);
        statusEntry.time = Math.max(statusEntry.time - Time.delta, 0.0f);
        if (statusEntry.effect == null || (double) statusEntry.time <= 0.0 && !statusEntry.effect.permanent)
        {
          Pools.free((object) statusEntry);
          index1 += -1;
          this.statuses.remove(index1);
        }
        else
        {
          this.applied.set((int) statusEntry.effect.__\u003C\u003Eid);
          this.speedMultiplier *= statusEntry.effect.speedMultiplier;
          this.healthMultiplier *= statusEntry.effect.healthMultiplier;
          this.damageMultiplier *= statusEntry.effect.damageMultiplier;
          this.reloadMultiplier *= statusEntry.effect.reloadMultiplier;
          this.buildSpeedMultiplier *= statusEntry.effect.buildSpeedMultiplier;
          this.dragMultiplier *= statusEntry.effect.dragMultiplier;
          this.disarmed |= statusEntry.effect.disarm;
          statusEntry.effect.update((Unit) this.self(), statusEntry.time);
        }
      }
    }

    [LineNumberTable(new byte[] {103, 127, 1, 118, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void draw()
    {
      Iterator iterator = this.statuses.iterator();
      while (iterator.hasNext())
        ((StatusEntry) iterator.next()).effect.draw((Unit) this.self());
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
    public virtual bool within([In] Position obj0, [In] float obj1) => Position.\u003Cdefault\u003Ewithin((Position) this, obj0, obj1);

    [HideFromJava]
    public virtual bool within([In] float obj0, [In] float obj1, [In] float obj2) => Position.\u003Cdefault\u003Ewithin((Position) this, obj0, obj1, obj2);

    [HideFromJava]
    public abstract bool isAdded();

    [HideFromJava]
    public abstract void remove();

    [HideFromJava]
    public abstract void add();

    [HideFromJava]
    public abstract bool isLocal();

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
    public abstract bool isValid();

    [HideFromJava]
    public abstract float healthf();

    [HideFromJava]
    public abstract void killed();

    [HideFromJava]
    public abstract void kill();

    [HideFromJava]
    public abstract void heal();

    [HideFromJava]
    public abstract bool damaged();

    [HideFromJava]
    public abstract void damagePierce([In] float obj0, [In] bool obj1);

    [HideFromJava]
    public abstract void damagePierce([In] float obj0);

    [HideFromJava]
    public abstract void damage([In] float obj0);

    [HideFromJava]
    public abstract void damage([In] float obj0, [In] bool obj1);

    [HideFromJava]
    public abstract void damageContinuous([In] float obj0);

    [HideFromJava]
    public abstract void damageContinuousPierce([In] float obj0);

    [HideFromJava]
    public abstract void clampHealth();

    [HideFromJava]
    public abstract void heal([In] float obj0);

    [HideFromJava]
    public abstract void healFract([In] float obj0);

    [HideFromJava]
    public abstract float health();

    [HideFromJava]
    public abstract void health([In] float obj0);

    [HideFromJava]
    public abstract float hitTime();

    [HideFromJava]
    public abstract void hitTime([In] float obj0);

    [HideFromJava]
    public abstract float maxHealth();

    [HideFromJava]
    public abstract void maxHealth([In] float obj0);

    [HideFromJava]
    public abstract bool dead();

    [HideFromJava]
    public abstract void dead([In] bool obj0);

    [HideFromJava]
    public abstract float hitSize();

    [HideFromJava]
    public abstract void hitbox([In] Rect obj0);

    [HideFromJava]
    public abstract void getCollisions([In] Cons obj0);

    [HideFromJava]
    public abstract void updateLastPosition();

    [HideFromJava]
    public abstract void collision([In] Hitboxc obj0, [In] float obj1, [In] float obj2);

    [HideFromJava]
    public abstract float deltaLen();

    [HideFromJava]
    public abstract float deltaAngle();

    [HideFromJava]
    public abstract bool collides([In] Hitboxc obj0);

    [HideFromJava]
    public abstract void hitboxTile([In] Rect obj0);

    [HideFromJava]
    public abstract float lastX();

    [HideFromJava]
    public abstract void lastX([In] float obj0);

    [HideFromJava]
    public abstract float lastY();

    [HideFromJava]
    public abstract void lastY([In] float obj0);

    [HideFromJava]
    public abstract float deltaX();

    [HideFromJava]
    public abstract void deltaX([In] float obj0);

    [HideFromJava]
    public abstract float deltaY();

    [HideFromJava]
    public abstract void deltaY([In] float obj0);

    [HideFromJava]
    public abstract void hitSize([In] float obj0);

    [HideFromJava]
    public abstract EntityCollisions.SolidPred solidity();

    [HideFromJava]
    public abstract bool canPass([In] int obj0, [In] int obj1);

    [HideFromJava]
    public abstract bool canPassOn();

    [HideFromJava]
    public abstract bool moving();

    [HideFromJava]
    public abstract void move([In] float obj0, [In] float obj1);

    [HideFromJava]
    public abstract Vec2 vel();

    [HideFromJava]
    public abstract float drag();

    [HideFromJava]
    public abstract void drag([In] float obj0);

    [HideFromJava]
    public abstract bool checkTarget([In] bool obj0, [In] bool obj1);

    [HideFromJava]
    public abstract bool isFlying();

    [HideFromJava]
    public abstract bool canDrown();

    [HideFromJava]
    public abstract void landed();

    [HideFromJava]
    public abstract void wobble();

    [HideFromJava]
    public abstract void moveAt([In] Vec2 obj0, [In] float obj1);

    [HideFromJava]
    public abstract float floorSpeedMultiplier();

    [HideFromJava]
    public abstract float elevation();

    [HideFromJava]
    public abstract void elevation([In] float obj0);

    [HideFromJava]
    public abstract bool hovering();

    [HideFromJava]
    public abstract void hovering([In] bool obj0);

    [HideFromJava]
    public abstract float drownTime();

    [HideFromJava]
    public abstract void drownTime([In] float obj0);

    [HideFromJava]
    public abstract float splashTimer();

    [HideFromJava]
    public abstract void splashTimer([In] float obj0);

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Prov
    {
      internal __\u003C\u003EAnon0()
      {
      }

      public object get() => (object) new StatusEntry();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Boolf
    {
      private readonly StatusEffect arg\u00241;

      internal __\u003C\u003EAnon1([In] StatusEffect obj0) => this.arg\u00241 = obj0;

      public bool get([In] object obj0) => (StatusComp.lambda\u0024unapply\u00240(this.arg\u00241, (StatusEntry) obj0) ? 1 : 0) != 0;
    }
  }
}
