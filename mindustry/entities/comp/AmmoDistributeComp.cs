// Decompiled with JetBrains decompiler
// Type: mindustry.entities.comp.AmmoDistributeComp
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.func;
using arc.graphics;
using arc.graphics.g2d;
using arc.math.geom;
using arc.scene.ui.layout;
using arc.util;
using arc.util.io;
using IKVM.Attributes;
using java.lang;
using java.nio;
using mindustry.ai.formations;
using mindustry.async;
using mindustry.ctype;
using mindustry.entities.units;
using mindustry.game;
using mindustry.gen;
using mindustry.logic;
using mindustry.type;
using mindustry.ui;
using mindustry.world;
using mindustry.world.blocks.environment;
using mindustry.world.blocks.units;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.entities.comp
{
  [Implements(new string[] {"mindustry.gen.Unitc"})]
  internal abstract class AmmoDistributeComp : 
    Object,
    Unitc,
    Displayable,
    Senseable,
    Ranged,
    Posc,
    Position,
    Entityc,
    Teamc,
    Rotc,
    Healthc,
    Drawc,
    Shieldc,
    Minerc,
    Itemsc,
    Weaponsc,
    Flyingc,
    Hitboxc,
    Sized,
    QuadTree.QuadTreeObject,
    Velc,
    Statusc,
    Commanderc,
    Physicsc,
    Syncc,
    Builderc,
    Boundedc
  {
    internal float x;
    internal float y;
    internal UnitType type;
    internal Team team;
    internal float ammo;
    [NonSerialized]
    private float ammoCooldown;

    [HideFromJava]
    public abstract Entityc self();

    [Modifiers]
    [LineNumberTable(23)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool lambda\u0024update\u00240([In] Unit obj0) => !object.ReferenceEquals((object) obj0, (object) this.self());

    [LineNumberTable(11)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal AmmoDistributeComp()
    {
    }

    [LineNumberTable(new byte[] {159, 163, 159, 1, 127, 88, 127, 7, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void update()
    {
      if ((double) this.ammoCooldown > 0.0)
        this.ammoCooldown -= Time.delta;
      if ((double) this.ammo <= 0.0 || (double) this.ammoCooldown > 0.0 || !ResupplyPoint.resupply(this.team, this.x, this.y, this.type.ammoResupplyRange, Math.min((float) this.type.ammoResupplyAmount, this.ammo), this.type.ammoType.color, (Boolf) new AmmoDistributeComp.__\u003C\u003EAnon0(this)))
        return;
      this.ammo -= Math.min((float) this.type.ammoResupplyAmount, this.ammo);
      this.ammoCooldown = 5f;
    }

    [HideFromJava]
    public abstract void display([In] Table obj0);

    [HideFromJava]
    public abstract double sense([In] LAccess obj0);

    [HideFromJava]
    public abstract double sense([In] Content obj0);

    [HideFromJava]
    public abstract object senseObject([In] LAccess obj0);

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
    public abstract float range();

    [HideFromJava]
    public abstract float rotation();

    [HideFromJava]
    public abstract void rotation([In] float obj0);

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
    public abstract float clipSize();

    [HideFromJava]
    public abstract void draw();

    [HideFromJava]
    public abstract float shield();

    [HideFromJava]
    public abstract void shield([In] float obj0);

    [HideFromJava]
    public abstract float armor();

    [HideFromJava]
    public abstract void armor([In] float obj0);

    [HideFromJava]
    public abstract float shieldAlpha();

    [HideFromJava]
    public abstract void shieldAlpha([In] float obj0);

    [HideFromJava]
    public abstract int itemCapacity();

    [HideFromJava]
    public abstract Item item();

    [HideFromJava]
    public abstract void clearItem();

    [HideFromJava]
    public abstract bool acceptsItem([In] Item obj0);

    [HideFromJava]
    public abstract bool hasItem();

    [HideFromJava]
    public abstract void addItem([In] Item obj0);

    [HideFromJava]
    public abstract void addItem([In] Item obj0, [In] int obj1);

    [HideFromJava]
    public abstract int maxAccepted([In] Item obj0);

    [HideFromJava]
    public abstract ItemStack stack();

    [HideFromJava]
    public abstract void stack([In] ItemStack obj0);

    [HideFromJava]
    public abstract float itemTime();

    [HideFromJava]
    public abstract void itemTime([In] float obj0);

    [HideFromJava]
    public abstract bool canMine([In] Item obj0);

    [HideFromJava]
    public abstract bool offloadImmediately();

    [HideFromJava]
    public abstract bool mining();

    [HideFromJava]
    public abstract bool validMine([In] Tile obj0, [In] bool obj1);

    [HideFromJava]
    public abstract bool validMine([In] Tile obj0);

    [HideFromJava]
    public abstract bool canMine();

    [HideFromJava]
    public abstract float mineTimer();

    [HideFromJava]
    public abstract void mineTimer([In] float obj0);

    [HideFromJava]
    public abstract Tile mineTile();

    [HideFromJava]
    public abstract void mineTile([In] Tile obj0);

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
    public abstract bool isGrounded();

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

    [HideFromJava]
    public abstract void apply([In] StatusEffect obj0);

    [HideFromJava]
    public abstract void apply([In] StatusEffect obj0, [In] float obj1);

    [HideFromJava]
    public abstract void clearStatuses();

    [HideFromJava]
    public abstract void unapply([In] StatusEffect obj0);

    [HideFromJava]
    public abstract bool isBoss();

    [HideFromJava]
    public abstract bool isImmune([In] StatusEffect obj0);

    [HideFromJava]
    public abstract Color statusColor();

    [HideFromJava]
    public abstract bool hasEffect([In] StatusEffect obj0);

    [HideFromJava]
    public abstract float speedMultiplier();

    [HideFromJava]
    public abstract float damageMultiplier();

    [HideFromJava]
    public abstract float healthMultiplier();

    [HideFromJava]
    public abstract float reloadMultiplier();

    [HideFromJava]
    public abstract float buildSpeedMultiplier();

    [HideFromJava]
    public abstract float dragMultiplier();

    [HideFromJava]
    public abstract bool disarmed();

    [HideFromJava]
    public abstract float ammof();

    [HideFromJava]
    public abstract void setWeaponRotation([In] float obj0);

    [HideFromJava]
    public abstract void setupWeapons([In] UnitType obj0);

    [HideFromJava]
    public abstract void controlWeapons([In] bool obj0);

    [HideFromJava]
    public abstract void controlWeapons([In] bool obj0, [In] bool obj1);

    [HideFromJava]
    public abstract void aim([In] Position obj0);

    [HideFromJava]
    public abstract void aim([In] float obj0, [In] float obj1);

    [HideFromJava]
    public abstract bool canShoot();

    [HideFromJava]
    public abstract WeaponMount[] mounts();

    [HideFromJava]
    public abstract void mounts([In] WeaponMount[] obj0);

    [HideFromJava]
    public abstract bool isRotate();

    [HideFromJava]
    public abstract float aimX();

    [HideFromJava]
    public abstract void aimX([In] float obj0);

    [HideFromJava]
    public abstract float aimY();

    [HideFromJava]
    public abstract void aimY([In] float obj0);

    [HideFromJava]
    public abstract bool isShooting();

    [HideFromJava]
    public abstract void isShooting([In] bool obj0);

    [HideFromJava]
    public abstract float ammo();

    [HideFromJava]
    public abstract void ammo([In] float obj0);

    [HideFromJava]
    public abstract void controller([In] UnitController obj0);

    [HideFromJava]
    public abstract void commandNearby([In] FormationPattern obj0);

    [HideFromJava]
    public abstract void commandNearby([In] FormationPattern obj0, [In] Boolf obj1);

    [HideFromJava]
    public abstract void command([In] Formation obj0, [In] Seq obj1);

    [HideFromJava]
    public abstract bool isCommanding();

    [HideFromJava]
    public abstract void clearCommand();

    [HideFromJava]
    public abstract Formation formation();

    [HideFromJava]
    public abstract void formation([In] Formation obj0);

    [HideFromJava]
    public abstract Seq controlling();

    [HideFromJava]
    public abstract void controlling([In] Seq obj0);

    [HideFromJava]
    public abstract float minFormationSpeed();

    [HideFromJava]
    public abstract void minFormationSpeed([In] float obj0);

    [HideFromJava]
    public abstract float mass();

    [HideFromJava]
    public abstract void impulse([In] float obj0, [In] float obj1);

    [HideFromJava]
    public abstract void impulse([In] Vec2 obj0);

    [HideFromJava]
    public abstract void impulseNet([In] Vec2 obj0);

    [HideFromJava]
    public abstract PhysicsProcess.PhysicRef physref();

    [HideFromJava]
    public abstract void physref([In] PhysicsProcess.PhysicRef obj0);

    [HideFromJava]
    public abstract void snapSync();

    [HideFromJava]
    public abstract void snapInterpolation();

    [HideFromJava]
    public abstract void readSync([In] Reads obj0);

    [HideFromJava]
    public abstract void writeSync([In] Writes obj0);

    [HideFromJava]
    public abstract void readSyncManual([In] FloatBuffer obj0);

    [HideFromJava]
    public abstract void writeSyncManual([In] FloatBuffer obj0);

    [HideFromJava]
    public abstract void afterSync();

    [HideFromJava]
    public abstract void interpolate();

    [HideFromJava]
    public abstract long lastUpdated();

    [HideFromJava]
    public abstract void lastUpdated([In] long obj0);

    [HideFromJava]
    public abstract long updateSpacing();

    [HideFromJava]
    public abstract void updateSpacing([In] long obj0);

    [HideFromJava]
    public abstract bool canBuild();

    [HideFromJava]
    public abstract void drawBuildPlans();

    [HideFromJava]
    public abstract void drawPlan([In] BuildPlan obj0, [In] float obj1);

    [HideFromJava]
    public abstract void drawPlanTop([In] BuildPlan obj0, [In] float obj1);

    [HideFromJava]
    public abstract bool shouldSkip([In] BuildPlan obj0, [In] Building obj1);

    [HideFromJava]
    public abstract void removeBuild([In] int obj0, [In] int obj1, [In] bool obj2);

    [HideFromJava]
    public abstract bool isBuilding();

    [HideFromJava]
    public abstract void clearBuilding();

    [HideFromJava]
    public abstract void addBuild([In] BuildPlan obj0);

    [HideFromJava]
    public abstract void addBuild([In] BuildPlan obj0, [In] bool obj1);

    [HideFromJava]
    public abstract bool activelyBuilding();

    [HideFromJava]
    public abstract BuildPlan buildPlan();

    [HideFromJava]
    public abstract Queue plans();

    [HideFromJava]
    public abstract void plans([In] Queue obj0);

    [HideFromJava]
    public abstract bool updateBuilding();

    [HideFromJava]
    public abstract void updateBuilding([In] bool obj0);

    [HideFromJava]
    public abstract void moveAt([In] Vec2 obj0);

    [HideFromJava]
    public abstract void approach([In] Vec2 obj0);

    [HideFromJava]
    public abstract void aimLook([In] Position obj0);

    [HideFromJava]
    public abstract void aimLook([In] float obj0, [In] float obj1);

    [HideFromJava]
    public abstract bool inRange([In] Position obj0);

    [HideFromJava]
    public abstract bool hasWeapons();

    [HideFromJava]
    public abstract float speed();

    [HideFromJava]
    public abstract float realSpeed();

    [HideFromJava]
    public abstract void eachGroup([In] Cons obj0);

    [HideFromJava]
    public abstract float prefRotation();

    [HideFromJava]
    public abstract bool isCounted();

    [HideFromJava]
    public abstract float bounds();

    [HideFromJava]
    public abstract UnitController controller();

    [HideFromJava]
    public abstract void resetController();

    [HideFromJava]
    public abstract void set([In] UnitType obj0, [In] UnitController obj1);

    [HideFromJava]
    public abstract int pathType();

    [HideFromJava]
    public abstract void lookAt([In] float obj0);

    [HideFromJava]
    public abstract void lookAt([In] Position obj0);

    [HideFromJava]
    public abstract void lookAt([In] float obj0, [In] float obj1);

    [HideFromJava]
    public abstract bool isAI();

    [HideFromJava]
    public abstract int count();

    [HideFromJava]
    public abstract int cap();

    [HideFromJava]
    public abstract void setType([In] UnitType obj0);

    [HideFromJava]
    public abstract TextureRegion icon();

    [HideFromJava]
    public abstract void destroy();

    [HideFromJava]
    public abstract string getControllerName();

    [HideFromJava]
    public abstract bool isPlayer();

    [HideFromJava]
    public abstract Player getPlayer();

    [HideFromJava]
    public abstract UnitType type();

    [HideFromJava]
    public abstract void type([In] UnitType obj0);

    [HideFromJava]
    public abstract bool spawnedByCore();

    [HideFromJava]
    public abstract void spawnedByCore([In] bool obj0);

    [HideFromJava]
    public abstract double flag();

    [HideFromJava]
    public abstract void flag([In] double obj0);

    [HideFromJava]
    public abstract Seq abilities();

    [HideFromJava]
    public abstract void abilities([In] Seq obj0);

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Boolf
    {
      private readonly AmmoDistributeComp arg\u00241;

      internal __\u003C\u003EAnon0([In] AmmoDistributeComp obj0) => this.arg\u00241 = obj0;

      public bool get([In] object obj0) => (this.arg\u00241.lambda\u0024update\u00240((Unit) obj0) ? 1 : 0) != 0;
    }
  }
}
