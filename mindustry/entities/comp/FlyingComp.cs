// Decompiled with JetBrains decompiler
// Type: mindustry.entities.comp.FlyingComp
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.func;
using arc.math;
using arc.math.geom;
using arc.util;
using arc.util.io;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using mindustry.content;
using mindustry.game;
using mindustry.gen;
using mindustry.world;
using mindustry.world.blocks.environment;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.entities.comp
{
  [Implements(new string[] {"mindustry.gen.Posc", "mindustry.gen.Velc", "mindustry.gen.Healthc", "mindustry.gen.Hitboxc"})]
  internal abstract class FlyingComp : 
    Object,
    Posc,
    Position,
    Entityc,
    Velc,
    Healthc,
    Hitboxc,
    Sized,
    QuadTree.QuadTreeObject
  {
    [Modifiers]
    private static Vec2 tmp1;
    [Modifiers]
    private static Vec2 tmp2;
    internal float x;
    internal float y;
    internal float speedMultiplier;
    internal Vec2 vel;
    internal float elevation;
    [NonSerialized]
    private bool wasFlying;
    [NonSerialized]
    internal bool hovering;
    [NonSerialized]
    internal float drownTime;
    [NonSerialized]
    internal float splashTimer;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal static void __\u003Cclinit\u003E()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual bool isGrounded() => (double) this.elevation < 1.0 / 1000.0;

    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual bool isFlying() => (double) this.elevation >= 0.0900000035762787;

    [HideFromJava]
    public abstract int id();

    [LineNumberTable(new byte[] {10, 127, 4})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual float floorSpeedMultiplier() => (this.isFlying() || this.hovering ? Blocks.air.asFloor() : this.floorOn()).speedMultiplier * this.speedMultiplier;

    [HideFromJava]
    public abstract Floor floorOn();

    [HideFromJava]
    public abstract Tile tileOn();

    [HideFromJava]
    public abstract float deltaX();

    [HideFromJava]
    public abstract float deltaY();

    [HideFromJava]
    public abstract float hitSize();

    [LineNumberTable(41)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual bool canDrown() => this.isGrounded() && !this.hovering;

    [HideFromJava]
    public abstract void kill();

    [HideFromJava]
    public abstract Entityc self();

    [LineNumberTable(16)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal FlyingComp()
    {
    }

    [LineNumberTable(29)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual bool checkTarget([In] bool obj0, [In] bool obj1)
    {
      int num1 = obj1 ? 1 : 0;
      int num2 = obj0 ? 1 : 0;
      return this.isGrounded() && num1 != 0 || this.isFlying() && num2 != 0;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void landed()
    {
    }

    [LineNumberTable(new byte[] {159, 191, 127, 43, 127, 43})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void wobble()
    {
      FlyingComp flyingComp1 = this;
      double x = (double) flyingComp1.x;
      double time1 = (double) Time.time;
      int num1 = this.id();
      int num2 = 10;
      double num3 = (double) ((num2 != -1 ? num1 % num2 : 0) * 12);
      double num4 = (double) (Mathf.sin((float) (time1 + num3), 25f, 0.05f) * Time.delta * this.elevation);
      flyingComp1.x = (float) (x + num4);
      FlyingComp flyingComp2 = this;
      double y = (double) flyingComp2.y;
      double time2 = (double) Time.time;
      int num5 = this.id();
      int num6 = 10;
      double num7 = (double) ((num6 != -1 ? num5 % num6 : 0) * 12);
      double num8 = (double) (Mathf.cos((float) (time2 + num7), 25f, 0.05f) * Time.delta * this.elevation);
      flyingComp2.y = (float) (y + num8);
    }

    [LineNumberTable(new byte[] {4, 108, 127, 24, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void moveAt([In] Vec2 obj0, [In] float obj1)
    {
      Vec2 v = FlyingComp.tmp1.set(obj0);
      FlyingComp.tmp2.set(v).sub(this.vel).limit(obj1 * obj0.len() * Time.delta * this.floorSpeedMultiplier());
      this.vel.add(FlyingComp.tmp2);
    }

    [LineNumberTable(new byte[] {16, 135, 110, 104, 104, 223, 32, 172, 118, 127, 34, 127, 12, 139, 104, 255, 17, 69, 127, 7, 123, 114, 112, 223, 3, 121, 102, 183, 156})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void update()
    {
      Floor floor = this.floorOn();
      if (this.isFlying() != this.wasFlying)
      {
        if (this.wasFlying && this.tileOn() != null)
          Fx.__\u003C\u003EunitLand.at(this.x, this.y, !this.floorOn().isLiquid ? 0.5f : 1f, this.tileOn().floor().mapColor);
        this.wasFlying = this.isFlying();
      }
      if (!this.hovering && this.isGrounded())
      {
        FlyingComp flyingComp1 = this;
        float num1 = flyingComp1.splashTimer + Mathf.dst(this.deltaX(), this.deltaY());
        FlyingComp flyingComp2 = flyingComp1;
        double num2 = (double) num1;
        flyingComp2.splashTimer = num1;
        double num3 = (double) (7f + this.hitSize() / 8f);
        if (num2 >= num3)
        {
          floor.walkEffect.at(this.x, this.y, this.hitSize() / 8f, floor.mapColor);
          this.splashTimer = 0.0f;
          if (!(this is WaterMovec))
            floor.walkSound.at(this.x, this.y, Mathf.random(floor.walkSoundPitchMin, floor.walkSoundPitchMax), floor.walkSoundVolume);
        }
      }
      if (this.canDrown() && floor.isLiquid && (double) floor.drownTime > 0.0)
      {
        this.drownTime += Time.delta / floor.drownTime;
        this.drownTime = Mathf.clamp(this.drownTime);
        if (Mathf.chanceDelta(0.0500000007450581))
          floor.drownUpdateEffect.at(this.x, this.y, 1f, floor.mapColor);
        if ((double) this.drownTime < 0.999000012874603 || Vars.net.client())
          return;
        this.kill();
        Events.fire((object) new EventType.UnitDrownEvent((Unit) this.self()));
      }
      else
        this.drownTime = Mathf.lerpDelta(this.drownTime, 0.0f, 0.03f);
    }

    [LineNumberTable(17)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static FlyingComp()
    {
      if (ByteCodeHelper.isAlreadyInited("mindustry.entities.comp.FlyingComp"))
        return;
      FlyingComp.tmp1 = new Vec2();
      FlyingComp.tmp2 = new Vec2();
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
    public abstract float x();

    [HideFromJava]
    public abstract void x([In] float obj0);

    [HideFromJava]
    public abstract float y();

    [HideFromJava]
    public abstract void y([In] float obj0);

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
    public abstract bool isValid();

    [HideFromJava]
    public abstract float healthf();

    [HideFromJava]
    public abstract void killed();

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
    public abstract void deltaX([In] float obj0);

    [HideFromJava]
    public abstract void deltaY([In] float obj0);

    [HideFromJava]
    public abstract void hitSize([In] float obj0);
  }
}
