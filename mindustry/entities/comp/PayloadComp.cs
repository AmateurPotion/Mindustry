// Decompiled with JetBrains decompiler
// Type: mindustry.entities.comp.PayloadComp
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.@struct;
using arc.func;
using arc.graphics;
using arc.graphics.g2d;
using arc.math;
using arc.math.geom;
using arc.scene.ui.layout;
using arc.util;
using arc.util.io;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.nio;
using java.util;
using mindustry.ai.formations;
using mindustry.async;
using mindustry.content;
using mindustry.core;
using mindustry.ctype;
using mindustry.entities.units;
using mindustry.game;
using mindustry.gen;
using mindustry.logic;
using mindustry.type;
using mindustry.ui;
using mindustry.world;
using mindustry.world.blocks.environment;
using mindustry.world.blocks.payloads;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.entities.comp
{
  [Implements(new string[] {"mindustry.gen.Posc", "mindustry.gen.Rotc", "mindustry.gen.Hitboxc", "mindustry.gen.Unitc"})]
  internal abstract class PayloadComp : 
    Object,
    Posc,
    Position,
    Entityc,
    Rotc,
    Hitboxc,
    Sized,
    QuadTree.QuadTreeObject,
    Unitc,
    Displayable,
    Senseable,
    Ranged,
    Teamc,
    Healthc,
    Drawc,
    Shieldc,
    Minerc,
    Itemsc,
    Weaponsc,
    Flyingc,
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
    internal float rotation;
    internal UnitType type;
    [Signature("Larc/struct/Seq<Lmindustry/world/blocks/payloads/Payload;>;")]
    internal Seq payloads;

    [LineNumberTable(29)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual float payloadUsed() => this.payloads.sumf((Floatf) new PayloadComp.__\u003C\u003EAnon0());

    [HideFromJava]
    public abstract Team team();

    [HideFromJava]
    public abstract Entityc self();

    [LineNumberTable(new byte[] {33, 167, 116, 218, 127, 0, 112, 114, 162, 127, 0, 104, 127, 0, 136})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual bool tryDropPayload([In] Payload obj0)
    {
      Tile tile = this.tileOn();
      if (Vars.net.client() && obj0 is UnitPayload)
        Vars.netClient.clearRemovedEntity(((UnitPayload) obj0).unit.id);
      if (tile != null && tile.build != null && tile.build.acceptPayload(tile.build, obj0))
      {
        Fx.__\u003C\u003EunitDrop.at((Position) tile.build);
        tile.build.handlePayload(tile.build, obj0);
        return true;
      }
      Payload payload1 = obj0;
      BuildPayload buildPayload;
      if (payload1 is BuildPayload && object.ReferenceEquals((object) (buildPayload = (BuildPayload) payload1), (object) (BuildPayload) payload1))
        return this.dropBlock(buildPayload);
      Payload payload2 = obj0;
      UnitPayload unitPayload;
      return payload2 is UnitPayload && object.ReferenceEquals((object) (unitPayload = (UnitPayload) payload2), (object) (UnitPayload) payload2) && this.dropUnit(unitPayload);
    }

    [HideFromJava]
    public abstract Tile tileOn();

    [LineNumberTable(new byte[] {82, 103, 127, 19, 109, 127, 6, 127, 7, 137, 104, 177, 107, 127, 5, 162})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual bool dropBlock([In] BuildPayload obj0)
    {
      Building build = obj0.build;
      int tile1 = World.toTile(this.x - build.block.offset);
      int tile2 = World.toTile(this.y - build.block.offset);
      Tile tile3 = Vars.world.tile(tile1, tile2);
      if (tile3 == null || !Build.validPlace(build.block, build.team, tile1, tile2, build.rotation, false))
        return false;
      int num1 = ByteCodeHelper.f2i((this.rotation + 45f) / 90f);
      int num2 = 4;
      int rotation = num2 != -1 ? num1 % num2 : 0;
      obj0.place(tile3, rotation);
      if (this.getControllerName() != null)
        obj0.build.lastAccessed = this.getControllerName();
      Fx.__\u003C\u003EunitDrop.at((Position) build);
      Fx.__\u003C\u003EplaceBlock.at(tile3.drawx(), tile3.drawy(), (float) tile3.block().size);
      return true;
    }

    [LineNumberTable(new byte[] {56, 167, 116, 162, 171, 142, 103, 123, 140, 139, 127, 0, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual bool dropUnit([In] UnitPayload obj0)
    {
      Unit unit = obj0.unit;
      if (!unit.canPass(this.tileX(), this.tileY()))
        return false;
      Fx.__\u003C\u003EunitDrop.at((Position) this);
      if (Vars.net.client())
        return true;
      unit.set((Position) this);
      unit.trns((Position) Tmp.__\u003C\u003Ev1.rnd(Mathf.random(2f)));
      unit.rotation(this.rotation);
      unit.id = EntityGroup.nextId();
      if (!unit.isAdded())
        unit.team.data().updateCount(unit.type, -1);
      unit.add();
      return true;
    }

    [HideFromJava]
    public abstract int tileX();

    [HideFromJava]
    public abstract int tileY();

    [HideFromJava]
    public abstract string getControllerName();

    [Modifiers]
    [LineNumberTable(29)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static float lambda\u0024payloadUsed\u00240([In] Payload obj0) => obj0.size() * obj0.size();

    [LineNumberTable(new byte[] {159, 164, 200})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal PayloadComp()
    {
      PayloadComp payloadComp = this;
      this.payloads = new Seq();
    }

    [LineNumberTable(33)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual bool canPickup([In] Unit obj0) => (double) (this.payloadUsed() + obj0.hitSize * obj0.hitSize) <= (double) (this.type.payloadCapacity + 1f / 1000f) && object.ReferenceEquals((object) obj0.team, (object) this.team()) && obj0.isAI();

    [LineNumberTable(37)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual bool canPickup([In] Building obj0) => (double) (this.payloadUsed() + (float) (obj0.block.size * obj0.block.size * 8 * 8)) <= (double) (this.type.payloadCapacity + 1f / 1000f) && obj0.canPickup();

    [LineNumberTable(41)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual bool canPickupPayload([In] Payload obj0) => (double) (this.payloadUsed() + obj0.size() * obj0.size()) <= (double) (this.type.payloadCapacity + 1f / 1000f);

    [LineNumberTable(45)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual bool hasPayload() => this.payloads.size > 0;

    [LineNumberTable(new byte[] {159, 191, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void addPayload([In] Payload obj0) => this.payloads.add((object) obj0);

    [LineNumberTable(new byte[] {3, 102, 113, 107, 108, 144, 118})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void pickup([In] Unit obj0)
    {
      obj0.remove();
      this.payloads.add((object) new UnitPayload(obj0));
      Fx.__\u003C\u003EunitPickup.at((Position) obj0);
      if (Vars.net.client())
        Vars.netClient.clearRemovedEntity(obj0.id);
      Events.fire((object) new EventType.PickupEvent((Unit) this.self(), obj0));
    }

    [LineNumberTable(new byte[] {13, 102, 107, 113, 107, 118})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void pickup([In] Building obj0)
    {
      obj0.pickedUp();
      obj0.tile.remove();
      this.payloads.add((object) new BuildPayload(obj0));
      Fx.__\u003C\u003EunitPickup.at((Position) obj0);
      Events.fire((object) new EventType.PickupEvent((Unit) this.self(), obj0));
    }

    [LineNumberTable(new byte[] {21, 143, 145, 105, 108, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual bool dropLastPayload()
    {
      if (this.payloads.isEmpty() || !this.tryDropPayload((Payload) this.payloads.peek()))
        return false;
      this.payloads.pop();
      return true;
    }

    [LineNumberTable(new byte[] {102, 102, 140, 102, 109, 111, 173, 127, 1, 127, 0, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void contentInfo([In] Table obj0, [In] float obj1, [In] float obj2)
    {
      obj0.clear();
      obj0.top().left();
      float padRight = 0.0f;
      float size = (float) this.payloads.size;
      if ((double) (obj1 * size + padRight * size) > (double) obj2)
        padRight = (obj2 - obj1 * size) / size;
      Iterator iterator = this.payloads.iterator();
      while (iterator.hasNext())
      {
        Payload payload = (Payload) iterator.next();
        obj0.image(payload.icon(Cicon.__\u003C\u003Esmall)).size(obj1).padRight(padRight);
      }
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
    public abstract void update();

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
    public abstract Floor floorOn();

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
    public abstract float rotation();

    [HideFromJava]
    public abstract void rotation([In] float obj0);

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
    public abstract void display([In] Table obj0);

    [HideFromJava]
    public abstract double sense([In] LAccess obj0);

    [HideFromJava]
    public abstract double sense([In] Content obj0);

    [HideFromJava]
    public abstract object senseObject([In] LAccess obj0);

    [HideFromJava]
    public abstract bool cheating();

    [HideFromJava]
    public abstract Building core();

    [HideFromJava]
    public abstract Building closestCore();

    [HideFromJava]
    public abstract Building closestEnemyCore();

    [HideFromJava]
    public abstract void team([In] Team obj0);

    [HideFromJava]
    public abstract float range();

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
    private sealed class __\u003C\u003EAnon0 : Floatf
    {
      internal __\u003C\u003EAnon0()
      {
      }

      public float get([In] object obj0) => PayloadComp.lambda\u0024payloadUsed\u00240((Payload) obj0);
    }
  }
}
