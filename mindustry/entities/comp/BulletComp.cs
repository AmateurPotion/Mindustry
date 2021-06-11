// Decompiled with JetBrains decompiler
// Type: mindustry.entities.comp.BulletComp
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.@struct;
using arc.func;
using arc.graphics.g2d;
using arc.math;
using arc.math.geom;
using arc.util;
using arc.util.io;
using IKVM.Attributes;
using java.lang;
using mindustry.core;
using mindustry.entities.bullet;
using mindustry.game;
using mindustry.gen;
using mindustry.world;
using mindustry.world.blocks.defense;
using mindustry.world.blocks.environment;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.entities.comp
{
  [Implements(new string[] {"mindustry.gen.Timedc", "mindustry.gen.Damagec", "mindustry.gen.Hitboxc", "mindustry.gen.Teamc", "mindustry.gen.Posc", "mindustry.gen.Drawc", "mindustry.gen.Shielderc", "mindustry.gen.Ownerc", "mindustry.gen.Velc", "mindustry.gen.Bulletc", "mindustry.gen.Timerc"})]
  internal abstract class BulletComp : 
    Object,
    Timedc,
    Scaled,
    Entityc,
    Damagec,
    Hitboxc,
    Sized,
    QuadTree.QuadTreeObject,
    Posc,
    Position,
    Teamc,
    Drawc,
    Shielderc,
    Ownerc,
    Velc,
    Bulletc,
    Timerc
  {
    internal Team team;
    internal Entityc owner;
    internal float x;
    internal float y;
    internal float damage;
    internal IntSeq collided;
    internal object data;
    internal BulletType type;
    internal float fdata;
    [NonSerialized]
    internal bool absorbed;
    [NonSerialized]
    internal bool hit;

    [HideFromJava]
    public abstract Entityc self();

    [LineNumberTable(new byte[] {7, 118, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void remove()
    {
      this.type.despawned((Bullet) this.self());
      this.collided.clear();
    }

    [HideFromJava]
    public abstract float lastX();

    [HideFromJava]
    public abstract float lastY();

    [HideFromJava]
    public abstract int tileX();

    [HideFromJava]
    public abstract int tileY();

    [HideFromJava]
    public abstract Vec2 vel();

    [HideFromJava]
    public abstract bool isAdded();

    [Modifiers]
    [LineNumberTable(new byte[] {75, 109, 141, 127, 100, 130, 135, 115, 178, 112, 109, 136, 209, 153, 178})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool lambda\u0024update\u00240([In] int obj0, [In] int obj1)
    {
      Building building = Vars.world.build(obj0, obj1);
      if (building == null || !this.isAdded() || (!building.collide((Bullet) this.self()) || !this.type.testCollision((Bullet) this.self(), building)) || (building.dead() || !this.type.collidesTeam && object.ReferenceEquals((object) building.team, (object) this.team)) || this.type.pierceBuilding && this.collided.contains(building.id))
        return false;
      int num = 0;
      float health = building.health;
      if (!object.ReferenceEquals((object) building.team, (object) this.team))
        num = building.collision((Bullet) this.self()) ? 1 : 0;
      if (num != 0 || this.type.collidesTeam)
      {
        if (!this.type.pierceBuilding)
          this.remove();
        else
          this.collided.add(building.id);
      }
      this.type.hitTile((Bullet) this.self(), building, health, true);
      return !this.type.pierceBuilding;
    }

    [LineNumberTable(new byte[] {159, 166, 232, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal BulletComp()
    {
      BulletComp bulletComp = this;
      this.collided = new IntSeq(6);
    }

    [Signature("(Larc/func/Cons<Larc/math/geom/QuadTree;>;)V")]
    [LineNumberTable(new byte[] {159, 179, 112, 107, 127, 0, 24, 230, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void getCollisions([In] Cons obj0)
    {
      Seq present = Vars.state.teams.present;
      for (int index = 0; index < present.size; ++index)
      {
        if (!object.ReferenceEquals((object) ((Teams.TeamData[]) present.items)[index].__\u003C\u003Eteam, (object) this.team))
          obj0.get((object) ((Teams.TeamData[]) present.items)[index].tree());
      }
    }

    [LineNumberTable(new byte[] {159, 189, 118})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void drawBullets() => this.type.draw((Bullet) this.self());

    [LineNumberTable(new byte[] {2, 118})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void add() => this.type.init((Bullet) this.self());

    [LineNumberTable(new byte[] {13, 127, 17, 157})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float damageMultiplier()
    {
      if (this.owner is Unit)
        return ((Unit) this.owner).damageMultiplier() * Vars.state.rules.unitDamageMultiplier;
      return this.owner is Building ? Vars.state.rules.blockDamageMultiplier : 1f;
    }

    [LineNumberTable(new byte[] {21, 103, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void absorb()
    {
      this.absorbed = true;
      this.remove();
    }

    [LineNumberTable(77)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float clipSize() => this.type.drawSize;

    [LineNumberTable(new byte[] {33, 127, 53, 123, 16})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool collides([In] Hitboxc obj0) => this.type.collides && obj0 is Teamc && !object.ReferenceEquals((object) ((Teamc) obj0).team(), (object) this.team) && ((!(obj0 is Flyingc) || ((Flyingc) obj0).checkTarget(this.type.collidesAir, this.type.collidesGround)) && (!this.type.pierce || !this.collided.contains(obj0.id())));

    [LineNumberTable(new byte[] {41, 122, 134, 127, 0, 104, 172, 127, 3, 127, 31, 220, 109, 136, 177, 152, 127, 51, 138})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void collision([In] Hitboxc obj0, [In] float obj1, [In] float obj2)
    {
      this.type.hit((Bullet) this.self(), obj1, obj2);
      float initialHealth = 0.0f;
      Hitboxc hitboxc1 = obj0;
      Healthc healthc;
      if (hitboxc1 is Healthc && object.ReferenceEquals((object) (healthc = (Healthc) hitboxc1), (object) (Healthc) hitboxc1))
      {
        initialHealth = healthc.health();
        healthc.damage(this.damage);
      }
      Hitboxc hitboxc2 = obj0;
      Unit unit1;
      if (hitboxc2 is Unit && object.ReferenceEquals((object) (unit1 = (Unit) hitboxc2), (object) (Unit) hitboxc2))
      {
        unit1.impulse(Tmp.__\u003C\u003Ev3.set((Position) unit1).sub(this.x, this.y).nor().scl(this.type.knockback * 80f));
        unit1.apply(this.type.status, this.type.statusDuration);
      }
      if (!this.type.pierce)
        this.remove();
      else
        this.collided.add(obj0.id());
      this.type.hitEntity((Bullet) this.self(), obj0, initialHealth);
      if (!(this.owner is Wall.WallBuild) || Vars.player == null || !object.ReferenceEquals((object) this.team, (object) Vars.player.team()))
        return;
      Hitboxc hitboxc3 = obj0;
      Unit unit2;
      if (!(hitboxc3 is Unit) || !object.ReferenceEquals((object) (unit2 = (Unit) hitboxc3), (object) (Unit) hitboxc3) || !unit2.dead)
        return;
      Events.fire((object) EventType.Trigger.__\u003C\u003EphaseDeflectHit);
    }

    [LineNumberTable(new byte[] {70, 150, 127, 8, 255, 26, 95, 127, 7, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void update()
    {
      this.type.update((Bullet) this.self());
      if (this.type.collidesTiles && this.type.collides && this.type.collidesGround)
        Vars.world.raycastEach(World.toTile(this.lastX()), World.toTile(this.lastY()), this.tileX(), this.tileY(), (Geometry.Raycaster) new BulletComp.__\u003C\u003EAnon0(this));
      if (this.type.pierceCap == -1 || this.collided.size < this.type.pierceCap)
        return;
      this.remove();
    }

    [LineNumberTable(new byte[] {111, 138, 118, 118})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void draw()
    {
      Draw.z(100f);
      this.type.draw((Bullet) this.self());
      this.type.drawLight((Bullet) this.self());
    }

    [LineNumberTable(new byte[] {120, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void rotation([In] float obj0) => this.vel().setAngle(obj0);

    [LineNumberTable(new byte[] {126, 127, 5, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float rotation()
    {
      float num = Mathf.atan2(this.vel().x, this.vel().y) * 57.29578f;
      if ((double) num < 0.0)
        num += 360f;
      return num;
    }

    [HideFromJava]
    public abstract float fin();

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
    public abstract float time();

    [HideFromJava]
    public abstract void time([In] float obj0);

    [HideFromJava]
    public abstract float lifetime();

    [HideFromJava]
    public abstract void lifetime([In] float obj0);

    [HideFromJava]
    public abstract float damage();

    [HideFromJava]
    public abstract void damage([In] float obj0);

    [HideFromJava]
    public abstract float hitSize();

    [HideFromJava]
    public abstract void hitbox([In] Rect obj0);

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
    public abstract void set([In] float obj0, [In] float obj1);

    [HideFromJava]
    public abstract void set([In] Position obj0);

    [HideFromJava]
    public abstract void trns([In] float obj0, [In] float obj1);

    [HideFromJava]
    public abstract void trns([In] Position obj0);

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
    public abstract void updateLastPosition();

    [HideFromJava]
    public abstract float deltaLen();

    [HideFromJava]
    public abstract float deltaAngle();

    [HideFromJava]
    public abstract void hitboxTile([In] Rect obj0);

    [HideFromJava]
    public abstract void lastX([In] float obj0);

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
    public abstract bool cheating();

    [HideFromJava]
    public abstract Building core();

    [HideFromJava]
    public abstract Building closestCore();

    [HideFromJava]
    public abstract Building closestEnemyCore();

    [HideFromJava]
    public abstract Team team();

    [HideFromJava]
    public abstract void team([In] Team obj0);

    [HideFromJava]
    public abstract Entityc owner();

    [HideFromJava]
    public abstract void owner([In] Entityc obj0);

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
    public abstract float drag();

    [HideFromJava]
    public abstract void drag([In] float obj0);

    [HideFromJava]
    public abstract bool timer([In] int obj0, [In] float obj1);

    [HideFromJava]
    public abstract Interval timer();

    [HideFromJava]
    public abstract void timer([In] Interval obj0);

    [HideFromJava]
    public abstract IntSeq collided();

    [HideFromJava]
    public abstract void collided([In] IntSeq obj0);

    [HideFromJava]
    public abstract object data();

    [HideFromJava]
    public abstract void data([In] object obj0);

    [HideFromJava]
    public abstract BulletType type();

    [HideFromJava]
    public abstract void type([In] BulletType obj0);

    [HideFromJava]
    public abstract float fdata();

    [HideFromJava]
    public abstract void fdata([In] float obj0);

    [HideFromJava]
    public abstract bool absorbed();

    [HideFromJava]
    public abstract void absorbed([In] bool obj0);

    [HideFromJava]
    public abstract bool hit();

    [HideFromJava]
    public abstract void hit([In] bool obj0);

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Geometry.Raycaster
    {
      private readonly BulletComp arg\u00241;

      internal __\u003C\u003EAnon0([In] BulletComp obj0) => this.arg\u00241 = obj0;

      public bool accept([In] int obj0, [In] int obj1) => (this.arg\u00241.lambda\u0024update\u00240(obj0, obj1) ? 1 : 0) != 0;
    }
  }
}
