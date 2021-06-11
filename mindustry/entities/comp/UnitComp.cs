// Decompiled with JetBrains decompiler
// Type: mindustry.entities.comp.UnitComp
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
using mindustry.ai.types;
using mindustry.async;
using mindustry.content;
using mindustry.core;
using mindustry.ctype;
using mindustry.entities.abilities;
using mindustry.entities.units;
using mindustry.game;
using mindustry.gen;
using mindustry.logic;
using mindustry.type;
using mindustry.ui;
using mindustry.world;
using mindustry.world.blocks.environment;
using mindustry.world.blocks.payloads;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.entities.comp
{
  [Implements(new string[] {"mindustry.gen.Healthc", "mindustry.gen.Physicsc", "mindustry.gen.Hitboxc", "mindustry.gen.Statusc", "mindustry.gen.Teamc", "mindustry.gen.Itemsc", "mindustry.gen.Rotc", "mindustry.gen.Unitc", "mindustry.gen.Weaponsc", "mindustry.gen.Drawc", "mindustry.gen.Boundedc", "mindustry.gen.Syncc", "mindustry.gen.Shieldc", "mindustry.gen.Commanderc", "mindustry.ui.Displayable", "mindustry.logic.Senseable", "mindustry.logic.Ranged", "mindustry.gen.Minerc", "mindustry.gen.Builderc"})]
  internal abstract class UnitComp : 
    Object,
    Healthc,
    Posc,
    Position,
    Entityc,
    Physicsc,
    Flyingc,
    Hitboxc,
    Sized,
    QuadTree.QuadTreeObject,
    Velc,
    Statusc,
    Teamc,
    Itemsc,
    Rotc,
    Unitc,
    Displayable,
    Senseable,
    Ranged,
    Drawc,
    Shieldc,
    Minerc,
    Weaponsc,
    Commanderc,
    Syncc,
    Builderc,
    Boundedc
  {
    internal bool hovering;
    internal bool dead;
    internal bool disarmed;
    internal float x;
    internal float y;
    internal float rotation;
    internal float elevation;
    internal float maxHealth;
    internal float drag;
    internal float armor;
    internal float hitSize;
    internal float health;
    internal float ammo;
    internal float minFormationSpeed;
    internal float dragMultiplier;
    internal Team team;
    internal int id;
    [arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})]
    internal Tile mineTile;
    internal Vec2 vel;
    private UnitController controller;
    internal UnitType type;
    internal bool spawnedByCore;
    internal double flag;
    [Signature("Larc/struct/Seq<Lmindustry/entities/abilities/Ability;>;")]
    [NonSerialized]
    internal Seq abilities;
    [NonSerialized]
    private float resupplyTime;
    [NonSerialized]
    private bool wasPlayer;

    [HideFromJava]
    public abstract void moveAt([In] Vec2 obj0, [In] float obj1);

    [LineNumberTable(86)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float realSpeed() => Mathf.lerp(1f, !this.type.canBoost ? 1f : this.type.boostMultiplier, this.elevation) * this.speed() * this.floorSpeedMultiplier();

    [HideFromJava]
    public abstract void aim([In] Position obj0);

    [LineNumberTable(new byte[] {160, 122, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void lookAt([In] Position obj0) => this.lookAt(this.angleTo(obj0));

    [HideFromJava]
    public abstract void aim([In] float obj0, [In] float obj1);

    [LineNumberTable(new byte[] {160, 126, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void lookAt([In] float obj0, [In] float obj1) => this.lookAt(this.angleTo(obj0, obj1));

    [HideFromJava]
    public virtual bool within([In] Position obj0, [In] float obj1) => Position.\u003Cdefault\u003Ewithin((Position) this, obj0, obj1);

    [HideFromJava]
    public abstract bool isGrounded();

    [LineNumberTable(489)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isPlayer() => this.controller is Player;

    [HideFromJava]
    public abstract Vec2 vel();

    [HideFromJava]
    public abstract bool isCommanding();

    [LineNumberTable(new byte[] {29, 159, 46})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float speed()
    {
      float num = this.isGrounded() || !this.isPlayer() ? 1f : Mathf.lerp(1f, this.type.strafePenalty, Angles.angleDist(this.vel().angle(), this.rotation) / 180f);
      return (!this.isCommanding() ? this.type.speed : this.minFormationSpeed * 0.98f) * num;
    }

    [HideFromJava]
    public abstract float floorSpeedMultiplier();

    [HideFromJava]
    public abstract Entityc self();

    [HideFromJava]
    public abstract Seq controlling();

    [HideFromJava]
    public abstract bool activelyBuilding();

    [HideFromJava]
    public abstract BuildPlan buildPlan();

    [HideFromJava]
    public virtual float angleTo([In] Position obj0) => Position.\u003Cdefault\u003EangleTo((Position) this, obj0);

    [HideFromJava]
    public abstract bool moving();

    [HideFromJava]
    public abstract bool isBuilding();

    [HideFromJava]
    public abstract ItemStack stack();

    [HideFromJava]
    public abstract bool isAdded();

    [HideFromJava]
    public abstract bool isShooting();

    [HideFromJava]
    public abstract bool isFlying();

    [LineNumberTable(109)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float range() => this.type.maxRange;

    [HideFromJava]
    public abstract float aimX();

    [HideFromJava]
    public abstract float aimY();

    [HideFromJava]
    public abstract bool mining();

    [HideFromJava]
    public abstract bool isValid();

    [HideFromJava]
    public abstract Item item();

    [LineNumberTable(new byte[] {160, 91, 103, 127, 15})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void controller([In] UnitController obj0)
    {
      this.controller = obj0;
      if (object.ReferenceEquals((object) this.controller.unit(), (object) this.self()))
        return;
      this.controller.unit((Unit) this.self());
    }

    [LineNumberTable(new byte[] {160, 142, 103, 108, 108, 108, 108, 140, 116, 123, 120, 155})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setType([In] UnitType obj0)
    {
      this.type = obj0;
      this.maxHealth = obj0.health;
      this.drag = obj0.drag;
      this.armor = obj0.armor;
      this.hitSize = obj0.hitSize;
      this.hovering = obj0.hovering;
      if (this.controller == null)
        this.controller(obj0.createController());
      if (this.mounts().Length != obj0.weapons.size)
        this.setupWeapons(obj0);
      if (this.abilities.size == obj0.abilities.size)
        return;
      this.abilities = obj0.abilities.map((Func) new UnitComp.__\u003C\u003EAnon0());
    }

    [HideFromJava]
    public abstract float speedMultiplier();

    [LineNumberTable(new byte[] {160, 118, 127, 16})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void lookAt([In] float obj0) => this.rotation = Angles.moveToward(this.rotation, obj0, this.type.rotateSpeed * Time.delta * this.speedMultiplier());

    [HideFromJava]
    public virtual float angleTo([In] float obj0, [In] float obj1) => Position.\u003Cdefault\u003EangleTo((Position) this, obj0, obj1);

    [HideFromJava]
    public abstract WeaponMount[] mounts();

    [HideFromJava]
    public abstract void setupWeapons([In] UnitType obj0);

    [LineNumberTable(new byte[] {160, 159, 108, 118})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void afterSync()
    {
      this.setType(this.type);
      this.controller.unit((Unit) this.self());
    }

    [LineNumberTable(248)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int count() => this.team.data().countType(this.type);

    [LineNumberTable(252)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int cap() => Units.getCap(this.team);

    [HideFromJava]
    public abstract Floor floorOn();

    [HideFromJava]
    public abstract bool isLocal();

    [HideFromJava]
    public virtual bool within([In] float obj0, [In] float obj1, [In] float obj2) => Position.\u003Cdefault\u003Ewithin((Position) this, obj0, obj1, obj2);

    [HideFromJava]
    public virtual float dst([In] Position obj0) => Position.\u003Cdefault\u003Edst((Position) this, obj0);

    [LineNumberTable(new byte[] {161, 52, 137, 127, 9, 127, 2, 159, 2, 104, 191, 42, 142, 127, 4, 107, 104, 146, 149, 120, 202, 117, 191, 56, 106, 118, 117, 116, 109, 255, 37, 60, 235, 73, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void destroy()
    {
      if (!this.isAdded())
        return;
      float explosiveness = 2f + this.item().explosiveness * (float) this.stack().amount * 1.53f;
      float flammability = this.item().flammability * (float) this.stack().amount / 1.9f;
      float power = this.item().charge * (float) this.stack().amount * 150f;
      if (!this.spawnedByCore)
        Damage.dynamicExplosion(this.x, this.y, flammability, explosiveness, power, this.bounds() / 2f, Vars.state.rules.damageExplosions, (double) this.item().flammability > 1.0, this.team);
      float num = this.hitSize / 3f;
      Effect.scorch(this.x, this.y, ByteCodeHelper.f2i(this.hitSize / 5f));
      Fx.__\u003C\u003Eexplosion.at((Position) this);
      Effect.shake(num, num, (Position) this);
      this.type.deathSound.at((Position) this);
      Events.fire((object) new EventType.UnitDestroyEvent((Unit) this.self()));
      if ((double) explosiveness > 7.0 && (this.isLocal() || this.wasPlayer))
        Events.fire((object) EventType.Trigger.__\u003C\u003EsuicideBomb);
      if (this.type.flying && !this.spawnedByCore)
        Damage.damage(this.team, this.x, this.y, Mathf.pow(this.hitSize, 0.94f) * 1.25f, Mathf.pow(this.hitSize, 0.75f) * this.type.crashDamageMultiplier * 5f, true, false, true);
      if (!Vars.headless)
      {
        for (int index = 0; index < this.type.wreckRegions.Length; ++index)
        {
          if (this.type.wreckRegions[index].found())
          {
            float length = this.type.hitSize / 4f;
            Tmp.__\u003C\u003Ev1.rnd(length);
            Effect.decal(this.type.wreckRegions[index], this.x + Tmp.__\u003C\u003Ev1.x, this.y + Tmp.__\u003C\u003Ev1.y, this.rotation - 90f);
          }
        }
      }
      this.remove();
    }

    [HideFromJava]
    public abstract Tile tileOn();

    [HideFromJava]
    public abstract void damageContinuous([In] float obj0);

    [HideFromJava]
    public abstract bool canPassOn();

    [LineNumberTable(new byte[] {161, 142, 181, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void kill()
    {
      if (this.dead || Vars.net.client())
        return;
      Call.unitDeath(this.id);
    }

    [LineNumberTable(new byte[] {160, 101, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void resetController() => this.controller(this.type.createController());

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float bounds() => this.hitSize * 2f;

    [LineNumberTable(new byte[] {160, 184, 119, 118})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void remove()
    {
      this.team.data().updateCount(this.type, -1);
      this.controller.removed((Unit) this.self());
    }

    [LineNumberTable(494)]
    [arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Player getPlayer() => this.isPlayer() ? (Player) this.controller : (Player) null;

    [LineNumberTable(new byte[] {159, 176, 232, 78, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal UnitComp()
    {
      UnitComp unitComp = this;
      this.abilities = new Seq(0);
      this.resupplyTime = Mathf.random(10f);
    }

    [LineNumberTable(new byte[] {3, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void moveAt([In] Vec2 obj0) => this.moveAt(obj0, this.type.accel);

    [LineNumberTable(new byte[] {7, 127, 2})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void approach([In] Vec2 obj0) => this.vel.approachDelta(obj0, this.type.accel * this.realSpeed());

    [LineNumberTable(new byte[] {11, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void aimLook([In] Position obj0)
    {
      this.aim(obj0);
      this.lookAt(obj0);
    }

    [LineNumberTable(new byte[] {16, 106, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void aimLook([In] float obj0, [In] float obj1)
    {
      this.aim(obj0, obj1);
      this.lookAt(obj0, obj1);
    }

    [LineNumberTable(71)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool inRange([In] Position obj0) => this.within(obj0, this.type.range);

    [LineNumberTable(75)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool hasWeapons() => this.type.hasWeapons();

    [Signature("(Larc/func/Cons<Lmindustry/gen/Unit;>;)V")]
    [LineNumberTable(new byte[] {41, 113, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void eachGroup([In] Cons obj0)
    {
      obj0.get((object) (Unit) this.self());
      this.controlling().each(obj0);
    }

    [LineNumberTable(new byte[] {47, 104, 110, 104, 110, 104, 141})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float prefRotation()
    {
      if (this.activelyBuilding())
        return this.angleTo((Position) this.buildPlan());
      if (this.mineTile != null)
        return this.angleTo((Position) this.mineTile);
      return this.moving() ? this.vel().angle() : this.rotation;
    }

    [LineNumberTable(new byte[] {64, 104, 159, 42})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float clipSize()
    {
      if (!this.isBuilding())
        return Math.max((float) this.type.region.width * 2f, this.type.clipSize);
      return Vars.state.rules.infiniteResources ? float.MaxValue : Math.max(this.type.clipSize, (float) this.type.region.width) + 220f + 32f;
    }

    [LineNumberTable(new byte[] {72, 127, 89, 113, 113, 108, 108, 108, 127, 15, 113, 114, 114, 127, 5, 113, 124, 127, 10, 116, 115, 115, 124, 127, 8, 127, 8, 107, 114, 119, 123, 123, 106, 127, 4, 127, 22, 112, 233, 35})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual double sense([In] LAccess obj0)
    {
      switch (UnitComp.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess[obj0.ordinal()])
      {
        case 1:
          return (double) this.stack().amount;
        case 2:
          return (double) this.type.itemCapacity;
        case 3:
          return (double) this.rotation;
        case 4:
          return (double) this.health;
        case 5:
          return (double) this.maxHealth;
        case 6:
          return !Vars.state.rules.unitAmmo ? (double) this.type.ammoCapacity : (double) this.ammo;
        case 7:
          return (double) this.type.ammoCapacity;
        case 8:
          return (double) World.conv(this.x);
        case 9:
          return (double) World.conv(this.y);
        case 10:
          return this.dead || !this.isAdded() ? 1.0 : 0.0;
        case 11:
          return (double) this.team.__\u003C\u003Eid;
        case 12:
          return this.isShooting() ? 1.0 : 0.0;
        case 13:
          return this.type.canBoost && this.isFlying() ? 1.0 : 0.0;
        case 14:
          return (double) (this.range() / 8f);
        case 15:
          return (double) World.conv(this.aimX());
        case 16:
          return (double) World.conv(this.aimY());
        case 17:
          return this.mining() ? 1.0 : 0.0;
        case 18:
          return this.mining() ? (double) this.mineTile.x : -1.0;
        case 19:
          return this.mining() ? (double) this.mineTile.y : -1.0;
        case 20:
          return this.flag;
        case 21:
          if (!this.isValid())
            return 0.0;
          if (this.controller is LogicAI)
            return 1.0;
          if (this.controller is Player)
            return 2.0;
          return this.controller is FormationAI ? 3.0 : 0.0;
        case 22:
          return this.controller is FormationAI && this.isValid() ? 1.0 : 0.0;
        case 23:
          Entityc entityc = this.self();
          Payloadc payloadc;
          return !(entityc is Payloadc) || !object.ReferenceEquals((object) (payloadc = (Payloadc) entityc), (object) (Payloadc) entityc) ? 0.0 : (double) payloadc.payloads().size;
        case 24:
          return (double) (this.hitSize / 8f);
        default:
          return double.NaN;
      }
    }

    [LineNumberTable(new byte[] {107, 127, 14, 107, 127, 22, 126, 127, 85, 127, 16, 116, 127, 30, 127, 31, 229, 55})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object senseObject([In] LAccess obj0)
    {
      switch (UnitComp.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess[obj0.ordinal()])
      {
        case 25:
          return (object) this.type;
        case 26:
          UnitController controller1 = this.controller;
          Player player;
          return controller1 is Player && object.ReferenceEquals((object) (player = (Player) controller1), (object) (Player) controller1) ? (object) player.name : (object) null;
        case 27:
          return this.stack().amount == 0 ? (object) null : (object) this.item();
        case 28:
          if (!this.isValid())
            return (object) null;
          UnitController controller2 = this.controller;
          LogicAI logicAi;
          if (controller2 is LogicAI && object.ReferenceEquals((object) (logicAi = (LogicAI) controller2), (object) (LogicAI) controller2))
            return (object) logicAi.controller;
          UnitController controller3 = this.controller;
          FormationAI formationAi;
          return controller3 is FormationAI && object.ReferenceEquals((object) (formationAi = (FormationAI) controller3), (object) (FormationAI) controller3) ? (object) formationAi.leader : (object) this;
        case 29:
          Entityc entityc = this.self();
          Payloadc payloadc;
          if (!(entityc is Payloadc) || !object.ReferenceEquals((object) (payloadc = (Payloadc) entityc), (object) (Payloadc) entityc))
            return (object) null;
          if (payloadc.payloads().isEmpty())
            return (object) null;
          object obj1 = payloadc.payloads().peek();
          UnitPayload unitPayload;
          if (obj1 is UnitPayload && object.ReferenceEquals((object) (unitPayload = (UnitPayload) obj1), (object) (UnitPayload) obj1))
            return (object) unitPayload.unit.type;
          object obj2 = payloadc.payloads().peek();
          BuildPayload buildPayload;
          return obj2 is BuildPayload && object.ReferenceEquals((object) (buildPayload = (BuildPayload) obj2), (object) (BuildPayload) obj2) ? (object) buildPayload.block() : (object) null;
        default:
          return Senseable.noSensed;
      }
    }

    [LineNumberTable(new byte[] {122, 127, 1})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual double sense([In] Content obj0) => object.ReferenceEquals((object) obj0, (object) this.stack().item) ? (double) this.stack().amount : double.NaN;

    [LineNumberTable(179)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool canDrown() => this.isGrounded() && !this.hovering && this.type.canDrown;

    [LineNumberTable(186)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool canShoot() => !this.disarmed && (!this.type.canBoost || !this.isFlying());

    [LineNumberTable(190)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isCounted() => this.type.isCounted;

    [LineNumberTable(195)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int itemCapacity() => this.type.itemCapacity;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual UnitController controller() => this.controller;

    [LineNumberTable(new byte[] {160, 106, 110, 135, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void set([In] UnitType obj0, [In] UnitController obj1)
    {
      if (!object.ReferenceEquals((object) this.type, (object) obj0))
        this.setType(obj0);
      this.controller(obj1);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int pathType() => 0;

    [LineNumberTable(244)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isAI() => this.controller is AIController;

    [LineNumberTable(new byte[] {160, 165, 134, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void afterRead()
    {
      this.afterSync();
      this.controller(this.type.createController());
    }

    [LineNumberTable(new byte[] {160, 172, 183, 127, 16, 112, 183})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void add()
    {
      this.team.data().updateCount(this.type, 1);
      if (this.count() <= this.cap() || this.spawnedByCore || (this.dead || Vars.state.rules.editor))
        return;
      Call.unitCapDeath((Unit) this.self());
      this.team.data().updateCount(this.type, -1);
    }

    [LineNumberTable(new byte[] {160, 190, 114, 188, 118})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void landed()
    {
      if ((double) this.type.landShake > 0.0)
        Effect.shake(this.type.landShake, this.type.landShake, (Position) this);
      this.type.landed((Unit) this.self());
    }

    [LineNumberTable(new byte[] {160, 200, 150, 127, 13, 179, 109, 123, 203, 110, 127, 1, 113, 162, 191, 22, 127, 38, 127, 7, 127, 9, 121, 159, 54, 197, 152, 171, 112, 118, 223, 21, 115, 127, 16, 115, 127, 0, 127, 7, 114, 230, 61, 229, 72, 159, 1, 104, 198, 104, 136, 153, 105, 215, 110, 237, 69, 140, 109, 109, 108, 230, 69, 116, 203, 109, 198, 120, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void update()
    {
      this.type.update((Unit) this.self());
      if (Vars.state.rules.unitAmmo && (double) this.ammo < (double) ((float) this.type.ammoCapacity - 0.0001f))
      {
        this.resupplyTime += Time.delta;
        if ((double) this.resupplyTime > 10.0)
        {
          this.type.ammoType.resupply((Unit) this.self());
          this.resupplyTime = 0.0f;
        }
      }
      if (this.abilities.size > 0)
      {
        Iterator iterator = this.abilities.iterator();
        while (iterator.hasNext())
          ((Ability) iterator.next()).update((Unit) this.self());
      }
      this.drag = this.type.drag * (!this.isGrounded() ? 1f : this.floorOn().dragMultiplier) * this.dragMultiplier;
      if (!object.ReferenceEquals((object) this.team, (object) Vars.state.rules.waveTeam) && Vars.state.hasSpawns() && (!Vars.net.client() || this.isLocal()))
      {
        float num = Vars.state.rules.dropZoneRadius + this.hitSize / 2f + 1f;
        Iterator iterator = Vars.spawner.getSpawns().iterator();
        while (iterator.hasNext())
        {
          Tile tile = (Tile) iterator.next();
          if (this.within(tile.worldx(), tile.worldy(), num))
            this.vel().add(Tmp.__\u003C\u003Ev1.set((Position) this).sub(tile.worldx(), tile.worldy()).setLength(1.1f - this.dst((Position) tile) / num).scl(0.45f * Time.delta));
        }
      }
      if (this.dead || (double) this.health <= 0.0)
      {
        this.drag = 0.01f;
        if (Mathf.chanceDelta(0.1))
        {
          Tmp.__\u003C\u003Ev1.setToRandomDirection().scl(this.hitSize);
          this.type.fallEffect.at(this.x + Tmp.__\u003C\u003Ev1.x, this.y + Tmp.__\u003C\u003Ev1.y);
        }
        if (Mathf.chanceDelta(0.2))
        {
          float len = this.type.engineOffset / 2f + this.type.engineOffset / 2f * this.elevation;
          float range = Mathf.range(this.type.engineSize);
          this.type.fallThrusterEffect.at(this.x + Angles.trnsx(this.rotation + 180f, len) + Mathf.range(range), this.y + Angles.trnsy(this.rotation + 180f, len) + Mathf.range(range), Mathf.random());
        }
        this.elevation -= this.type.fallSpeed * Time.delta;
        if (this.isGrounded())
          this.destroy();
      }
      Tile tile1 = this.tileOn();
      Floor floor = this.floorOn();
      if (tile1 != null && this.isGrounded() && !this.type.hovering)
      {
        if (tile1.build != null)
          tile1.build.unitOn((Unit) this.self());
        if ((double) floor.damageTaken > 0.0)
          this.damageContinuous(floor.damageTaken);
      }
      if (tile1 != null && !this.canPassOn())
      {
        if (this.type.canBoost)
          this.elevation = 1f;
        else if (!Vars.net.client())
          this.kill();
      }
      if (!Vars.net.client() && !this.dead)
        this.controller.updateUnit();
      if (!this.controller.isValidController())
        this.resetController();
      if (!this.spawnedByCore || this.isPlayer() || this.dead)
        return;
      Call.unitDespawn((Unit) this.self());
    }

    [LineNumberTable(417)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual TextureRegion icon() => this.type.icon(Cicon.__\u003C\u003Efull);

    [LineNumberTable(new byte[] {161, 96, 116, 127, 25, 127, 43})]
    [arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string getControllerName()
    {
      if (this.isPlayer())
        return this.getPlayer().name;
      UnitController controller1 = this.controller;
      LogicAI logicAi;
      if (controller1 is LogicAI && object.ReferenceEquals((object) (logicAi = (LogicAI) controller1), (object) (LogicAI) controller1) && logicAi.controller != null)
        return logicAi.controller.lastAccessed;
      UnitController controller2 = this.controller;
      FormationAI formationAi;
      return controller2 is FormationAI && object.ReferenceEquals((object) (formationAi = (FormationAI) controller2), (object) (FormationAI) controller2) && (formationAi.leader != null && formationAi.leader.isPlayer()) ? formationAi.leader.getPlayer().name : (string) null;
    }

    [LineNumberTable(new byte[] {161, 104, 119})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void display([In] Table obj0) => this.type.display((Unit) this.self(), obj0);

    [LineNumberTable(479)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isImmune([In] StatusEffect obj0) => this.type.immunities.contains((object) obj0);

    [LineNumberTable(new byte[] {161, 114, 118})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void draw() => this.type.draw((Unit) this.self());

    [LineNumberTable(new byte[] {161, 129, 108, 107, 167, 109, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void killed()
    {
      this.wasPlayer = this.isLocal();
      this.health = 0.0f;
      this.dead = true;
      if (this.type.flying)
        return;
      this.destroy();
    }

    [HideFromJava]
    public abstract float getX();

    [HideFromJava]
    public abstract float getY();

    [HideFromJava]
    public virtual float dst2([In] Position obj0) => Position.\u003Cdefault\u003Edst2((Position) this, obj0);

    [HideFromJava]
    public virtual float dst([In] float obj0, [In] float obj1) => Position.\u003Cdefault\u003Edst((Position) this, obj0, obj1);

    [HideFromJava]
    public virtual float dst2([In] float obj0, [In] float obj1) => Position.\u003Cdefault\u003Edst2((Position) this, obj0, obj1);

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
    public abstract float x();

    [HideFromJava]
    public abstract void x([In] float obj0);

    [HideFromJava]
    public abstract float y();

    [HideFromJava]
    public abstract void y([In] float obj0);

    [HideFromJava]
    public abstract float healthf();

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
    public abstract void move([In] float obj0, [In] float obj1);

    [HideFromJava]
    public abstract float drag();

    [HideFromJava]
    public abstract void drag([In] float obj0);

    [HideFromJava]
    public abstract bool checkTarget([In] bool obj0, [In] bool obj1);

    [HideFromJava]
    public abstract void wobble();

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
    public abstract Color statusColor();

    [HideFromJava]
    public abstract bool hasEffect([In] StatusEffect obj0);

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
    public abstract void stack([In] ItemStack obj0);

    [HideFromJava]
    public abstract float itemTime();

    [HideFromJava]
    public abstract void itemTime([In] float obj0);

    [HideFromJava]
    public abstract float rotation();

    [HideFromJava]
    public abstract void rotation([In] float obj0);

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
    public abstract bool canMine([In] Item obj0);

    [HideFromJava]
    public abstract bool offloadImmediately();

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
    public abstract float ammof();

    [HideFromJava]
    public abstract void setWeaponRotation([In] float obj0);

    [HideFromJava]
    public abstract void controlWeapons([In] bool obj0);

    [HideFromJava]
    public abstract void controlWeapons([In] bool obj0, [In] bool obj1);

    [HideFromJava]
    public abstract void mounts([In] WeaponMount[] obj0);

    [HideFromJava]
    public abstract bool isRotate();

    [HideFromJava]
    public abstract void aimX([In] float obj0);

    [HideFromJava]
    public abstract void aimY([In] float obj0);

    [HideFromJava]
    public abstract void isShooting([In] bool obj0);

    [HideFromJava]
    public abstract float ammo();

    [HideFromJava]
    public abstract void ammo([In] float obj0);

    [HideFromJava]
    public abstract void commandNearby([In] FormationPattern obj0);

    [HideFromJava]
    public abstract void commandNearby([In] FormationPattern obj0, [In] Boolf obj1);

    [HideFromJava]
    public abstract void command([In] Formation obj0, [In] Seq obj1);

    [HideFromJava]
    public abstract void clearCommand();

    [HideFromJava]
    public abstract Formation formation();

    [HideFromJava]
    public abstract void formation([In] Formation obj0);

    [HideFromJava]
    public abstract void controlling([In] Seq obj0);

    [HideFromJava]
    public abstract float minFormationSpeed();

    [HideFromJava]
    public abstract void minFormationSpeed([In] float obj0);

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
    public abstract void clearBuilding();

    [HideFromJava]
    public abstract void addBuild([In] BuildPlan obj0);

    [HideFromJava]
    public abstract void addBuild([In] BuildPlan obj0, [In] bool obj1);

    [HideFromJava]
    public abstract Queue plans();

    [HideFromJava]
    public abstract void plans([In] Queue obj0);

    [HideFromJava]
    public abstract bool updateBuilding();

    [HideFromJava]
    public abstract void updateBuilding([In] bool obj0);

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

    [InnerClass]
    [EnclosingMethod(null, null, null)]
    [Modifiers]
    [SpecialName]
    internal class \u0031 : Object
    {
      [Modifiers]
      internal static int[] \u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(122)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static \u0031()
      {
        if (ByteCodeHelper.isAlreadyInited("mindustry.entities.comp.UnitComp$1"))
          return;
        UnitComp.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess = new int[LAccess.values().Length];
        try
        {
          UnitComp.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess[LAccess.__\u003C\u003EtotalItems.ordinal()] = 1;
          goto label_6;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_6:
        try
        {
          UnitComp.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess[LAccess.__\u003C\u003EitemCapacity.ordinal()] = 2;
          goto label_10;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_10:
        try
        {
          UnitComp.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess[LAccess.__\u003C\u003Erotation.ordinal()] = 3;
          goto label_14;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_14:
        try
        {
          UnitComp.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess[LAccess.__\u003C\u003Ehealth.ordinal()] = 4;
          goto label_18;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_18:
        try
        {
          UnitComp.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess[LAccess.__\u003C\u003EmaxHealth.ordinal()] = 5;
          goto label_22;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_22:
        try
        {
          UnitComp.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess[LAccess.__\u003C\u003Eammo.ordinal()] = 6;
          goto label_26;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_26:
        try
        {
          UnitComp.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess[LAccess.__\u003C\u003EammoCapacity.ordinal()] = 7;
          goto label_30;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_30:
        try
        {
          UnitComp.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess[LAccess.__\u003C\u003Ex.ordinal()] = 8;
          goto label_34;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_34:
        try
        {
          UnitComp.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess[LAccess.__\u003C\u003Ey.ordinal()] = 9;
          goto label_38;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_38:
        try
        {
          UnitComp.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess[LAccess.__\u003C\u003Edead.ordinal()] = 10;
          goto label_42;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_42:
        try
        {
          UnitComp.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess[LAccess.__\u003C\u003Eteam.ordinal()] = 11;
          goto label_46;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_46:
        try
        {
          UnitComp.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess[LAccess.__\u003C\u003Eshooting.ordinal()] = 12;
          goto label_50;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_50:
        try
        {
          UnitComp.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess[LAccess.__\u003C\u003Eboosting.ordinal()] = 13;
          goto label_54;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_54:
        try
        {
          UnitComp.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess[LAccess.__\u003C\u003Erange.ordinal()] = 14;
          goto label_58;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_58:
        try
        {
          UnitComp.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess[LAccess.__\u003C\u003EshootX.ordinal()] = 15;
          goto label_62;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_62:
        try
        {
          UnitComp.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess[LAccess.__\u003C\u003EshootY.ordinal()] = 16;
          goto label_66;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_66:
        try
        {
          UnitComp.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess[LAccess.__\u003C\u003Emining.ordinal()] = 17;
          goto label_70;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_70:
        try
        {
          UnitComp.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess[LAccess.__\u003C\u003EmineX.ordinal()] = 18;
          goto label_74;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_74:
        try
        {
          UnitComp.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess[LAccess.__\u003C\u003EmineY.ordinal()] = 19;
          goto label_78;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_78:
        try
        {
          UnitComp.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess[LAccess.__\u003C\u003Eflag.ordinal()] = 20;
          goto label_82;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_82:
        try
        {
          UnitComp.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess[LAccess.__\u003C\u003Econtrolled.ordinal()] = 21;
          goto label_86;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_86:
        try
        {
          UnitComp.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess[LAccess.__\u003C\u003Ecommanded.ordinal()] = 22;
          goto label_90;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_90:
        try
        {
          UnitComp.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess[LAccess.__\u003C\u003EpayloadCount.ordinal()] = 23;
          goto label_94;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_94:
        try
        {
          UnitComp.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess[LAccess.__\u003C\u003Esize.ordinal()] = 24;
          goto label_98;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_98:
        try
        {
          UnitComp.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess[LAccess.__\u003C\u003Etype.ordinal()] = 25;
          goto label_102;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_102:
        try
        {
          UnitComp.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess[LAccess.__\u003C\u003Ename.ordinal()] = 26;
          goto label_106;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_106:
        try
        {
          UnitComp.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess[LAccess.__\u003C\u003EfirstItem.ordinal()] = 27;
          goto label_110;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_110:
        try
        {
          UnitComp.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess[LAccess.__\u003C\u003Econtroller.ordinal()] = 28;
          goto label_114;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_114:
        try
        {
          UnitComp.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess[LAccess.__\u003C\u003EpayloadType.ordinal()] = 29;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
      }

      \u0031() => throw null;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Func
    {
      internal __\u003C\u003EAnon0()
      {
      }

      public object get([In] object obj0) => (object) ((Ability) obj0).copy();
    }
  }
}
