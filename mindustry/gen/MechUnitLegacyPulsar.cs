// Decompiled with JetBrains decompiler
// Type: mindustry.gen.MechUnitLegacyPulsar
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
using arc.util.pooling;
using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.nio;
using java.util;
using mindustry.ai.formations;
using mindustry.ai.types;
using mindustry.async;
using mindustry.audio;
using mindustry.content;
using mindustry.core;
using mindustry.ctype;
using mindustry.entities;
using mindustry.entities.abilities;
using mindustry.entities.bullet;
using mindustry.entities.comp;
using mindustry.entities.units;
using mindustry.game;
using mindustry.graphics;
using mindustry.input;
using mindustry.io;
using mindustry.logic;
using mindustry.type;
using mindustry.ui;
using mindustry.world;
using mindustry.world.blocks;
using mindustry.world.blocks.environment;
using mindustry.world.blocks.payloads;
using mindustry.world.blocks.storage;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.gen
{
  [Implements(new string[] {"mindustry.gen.Rotc", "mindustry.gen.Teamc", "mindustry.gen.Healthc", "mindustry.gen.Drawc", "mindustry.gen.Mechc", "mindustry.gen.Shieldc", "mindustry.gen.Minerc", "mindustry.gen.Posc", "mindustry.gen.Weaponsc", "mindustry.gen.Entityc", "mindustry.gen.Statusc", "mindustry.gen.Hitboxc", "mindustry.gen.Unitc", "mindustry.gen.Commanderc", "mindustry.gen.Physicsc", "mindustry.gen.Syncc", "mindustry.gen.ElevationMovec", "mindustry.gen.Builderc", "mindustry.gen.Flyingc", "mindustry.gen.Velc", "mindustry.gen.Itemsc", "mindustry.gen.Boundedc"})]
  public class MechUnitLegacyPulsar : 
    Unit,
    Rotc,
    Entityc,
    Teamc,
    Posc,
    Position,
    Healthc,
    Drawc,
    Mechc,
    Flyingc,
    Hitboxc,
    Sized,
    QuadTree.QuadTreeObject,
    Velc,
    Shieldc,
    Minerc,
    Itemsc,
    Weaponsc,
    Statusc,
    Unitc,
    Displayable,
    Senseable,
    Ranged,
    Commanderc,
    Physicsc,
    Syncc,
    Builderc,
    Boundedc,
    ElevationMovec
  {
    public const float hitDuration = 9f;
    public static int sequenceNum;
    [Signature("Larc/struct/Seq<Lmindustry/ai/formations/FormationMember;>;")]
    internal static Seq __\u003C\u003Emembers;
    [Signature("Larc/struct/Seq<Lmindustry/gen/Unit;>;")]
    internal static Seq __\u003C\u003Eunits;
    internal static Vec2[] __\u003C\u003Evecs;
    internal static Vec2 __\u003C\u003Etmp1;
    internal static Vec2 __\u003C\u003Etmp2;
    public const float warpDst = 180f;
    [NonSerialized]
    private float rotation_TARGET_;
    [NonSerialized]
    private float rotation_LAST_;
    public float baseRotation;
    [NonSerialized]
    private float baseRotation_TARGET_;
    [NonSerialized]
    private float baseRotation_LAST_;
    [NonSerialized]
    public float walkTime;
    [NonSerialized]
    public float walkExtension;
    [NonSerialized]
    public bool walked;
    [NonSerialized]
    private float x_TARGET_;
    [NonSerialized]
    private float x_LAST_;
    [NonSerialized]
    private float y_TARGET_;
    [NonSerialized]
    private float y_LAST_;
    [NonSerialized]
    protected internal bool isRotate;
    [NonSerialized]
    public bool added;
    [Signature("Larc/struct/Seq<Lmindustry/entities/units/StatusEntry;>;")]
    public Seq statuses;
    [NonSerialized]
    public Bits applied;
    [NonSerialized]
    protected internal float speedMultiplier;
    [NonSerialized]
    protected internal float damageMultiplier;
    [NonSerialized]
    protected internal float healthMultiplier;
    [NonSerialized]
    protected internal float reloadMultiplier;
    [NonSerialized]
    protected internal float buildSpeedMultiplier;
    [NonSerialized]
    protected internal float dragMultiplier;
    [NonSerialized]
    protected internal bool disarmed;
    public UnitController controller;
    [NonSerialized]
    public float resupplyTime;
    [NonSerialized]
    public bool wasPlayer;
    [NonSerialized]
    public BuildPlan lastActive;
    [NonSerialized]
    public int lastSize;
    [NonSerialized]
    public float buildAlpha;
    [NonSerialized]
    public bool wasFlying;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {160, 145, 232, 25, 139, 159, 0, 171, 171, 171, 171, 171, 171, 231, 69, 241, 72, 235, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal MechUnitLegacyPulsar()
    {
      MechUnitLegacyPulsar unitLegacyPulsar = this;
      this.statuses = new Seq();
      this.applied = new Bits(Vars.content.getBy(ContentType.__\u003C\u003Estatus).size);
      this.speedMultiplier = 1f;
      this.damageMultiplier = 1f;
      this.healthMultiplier = 1f;
      this.reloadMultiplier = 1f;
      this.buildSpeedMultiplier = 1f;
      this.dragMultiplier = 1f;
      this.disarmed = false;
      this.resupplyTime = Mathf.random(10f);
      this.buildAlpha = 0.0f;
    }

    [LineNumberTable(new byte[] {167, 110, 107, 104, 146, 159, 57})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void drawPlan(BuildPlan request, float alpha)
    {
      request.animScale = 1f;
      if (request.breaking)
        Vars.control.input.drawBreaking(request);
      else
        request.block.drawPlan(request, Vars.control.input.allRequests(), Build.validPlace(request.block, this.team, request.x, request.y, request.rotation) || Vars.control.input.requestMatches(request), alpha);
    }

    [LineNumberTable(new byte[] {160, 158, 104, 101, 127, 7, 103, 146})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void drawPlanTop(BuildPlan request, float alpha)
    {
      if (request.breaking)
        return;
      Draw.reset();
      Draw.mixcol(Color.__\u003C\u003Ewhite, 0.24f + Mathf.absin(Time.globalTime, 6f, 0.28f));
      Draw.alpha(alpha);
      request.block.drawRequestConfigTop(request, (Eachable) this.plans);
    }

    [LineNumberTable(new byte[] {166, 189, 110, 99, 139, 122, 111, 107, 103, 105, 112, 117, 134, 112, 188})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void rawDamage([In] float obj0)
    {
      int num1 = (double) this.shield > 9.99999974737875E-05 ? 1 : 0;
      if (num1 != 0)
        this.shieldAlpha = 1f;
      float num2 = Math.min(Math.max(this.shield, 0.0f), obj0);
      this.shield -= num2;
      this.hitTime = 1f;
      obj0 -= num2;
      if ((double) obj0 <= 0.0)
        return;
      this.health -= obj0;
      if ((double) this.health <= 0.0 && !this.dead)
        this.kill();
      if (num1 == 0 || (double) this.shield > 9.99999974737875E-05)
        return;
      Fx.__\u003C\u003EunitShieldBreak.at(this.x, this.y, 0.0f, (object) this);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override float speedMultiplier() => this.speedMultiplier;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override int id() => this.id;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool isAdded() => this.added;

    [LineNumberTable(new byte[] {164, 5, 127, 46})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override float speed()
    {
      float num = this.isGrounded() || !this.isPlayer() ? 1f : Mathf.lerp(1f, this.type.strafePenalty, Angles.angleDist(this.vel().angle(), this.rotation) / 180f);
      return (!this.isCommanding() ? this.type.speed : this.minFormationSpeed * 0.98f) * num;
    }

    [LineNumberTable(new byte[] {167, 59, 127, 4})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override float floorSpeedMultiplier() => (this.isFlying() || this.hovering ? Blocks.air.asFloor() : this.floorOn()).speedMultiplier * this.speedMultiplier;

    [LineNumberTable(2003)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override Tile tileOn() => Vars.world.tileWorld(this.x, this.y);

    [LineNumberTable(467)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool isLocal() => object.ReferenceEquals((object) this, (object) Vars.player) || this is Unitc && object.ReferenceEquals((object) this.controller(), (object) Vars.player);

    [HideFromJava]
    public override float angleTo([In] Position obj0) => Position.\u003Cdefault\u003EangleTo((Position) this, obj0);

    [LineNumberTable(new byte[] {160, 190, 127, 16})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void lookAt(float angle) => this.rotation = Angles.moveToward(this.rotation, angle, this.type.rotateSpeed * Time.delta * this.speedMultiplier());

    [LineNumberTable(new byte[] {165, 124, 112, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void heal(float amount)
    {
      this.health += amount;
      this.clampHealth();
    }

    [LineNumberTable(new byte[] {162, 141, 105, 127, 9, 127, 2, 127, 2, 104, 159, 42, 110, 127, 4, 107, 104, 114, 107, 120, 138, 117, 159, 56, 106, 118, 117, 116, 109, 255, 37, 60, 235, 72, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void destroy()
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
      Events.fire((object) new EventType.UnitDestroyEvent((Unit) this));
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

    [LineNumberTable(new byte[] {166, 59, 127, 1, 110, 145, 98, 108, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void clearCommand()
    {
      Iterator iterator = this.controlling.iterator();
      while (iterator.hasNext())
      {
        Unit unit = (Unit) iterator.next();
        if (unit.controller().isBeingControlled((Unit) this))
          unit.controller(unit.type.createController());
      }
      this.controlling.clear();
      this.formation = (Formation) null;
    }

    [LineNumberTable(new byte[] {165, 138, 166, 102, 145})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void afterRead()
    {
      this.updateLastPosition();
      this.afterSync();
      this.controller(this.type.createController());
    }

    [LineNumberTable(new byte[] {157, 248, 162, 105, 98, 127, 1, 124, 98, 130, 98, 99, 141, 120, 127, 15, 141, 99, 142, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void addBuild(BuildPlan place, bool tail)
    {
      int num = tail ? 1 : 0;
      if (!this.canBuild())
        return;
      BuildPlan buildPlan1 = (BuildPlan) null;
      Iterator iterator = this.plans.iterator();
      while (iterator.hasNext())
      {
        BuildPlan buildPlan2 = (BuildPlan) iterator.next();
        if (buildPlan2.x == place.x && buildPlan2.y == place.y)
        {
          buildPlan1 = buildPlan2;
          break;
        }
      }
      if (buildPlan1 != null)
        this.plans.remove((object) buildPlan1);
      Tile tile = Vars.world.tile(place.x, place.y);
      if (tile != null)
      {
        Building build = tile.build;
        ConstructBlock.ConstructBuild constructBuild;
        if (build is ConstructBlock.ConstructBuild && object.ReferenceEquals((object) (constructBuild = (ConstructBlock.ConstructBuild) build), (object) (ConstructBlock.ConstructBuild) build))
          place.progress = constructBuild.progress;
      }
      if (num != 0)
        this.plans.addLast((object) place);
      else
        this.plans.addFirst((object) place);
    }

    [LineNumberTable(new byte[] {166, 132, 103, 108, 108, 108, 108, 108, 116, 123, 120, 155})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setType(UnitType type)
    {
      this.type = type;
      this.maxHealth = type.health;
      this.drag = type.drag;
      this.armor = type.armor;
      this.hitSize = type.hitSize;
      this.hovering = type.hovering;
      if (this.controller == null)
        this.controller(type.createController());
      if (this.mounts().Length != type.weapons.size)
        this.setupWeapons(type);
      if (this.abilities.size == type.abilities.size)
        return;
      this.abilities = type.abilities.map((Func) new MechUnitLegacyPulsar.__\u003C\u003EAnon15());
    }

    [LineNumberTable(new byte[] {167, 88, 103, 191, 0, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void controller(UnitController next)
    {
      this.controller = next;
      if (!object.ReferenceEquals((object) this.controller.unit(), (object) this))
        this.controller.unit((Unit) this);
      this.clearCommand();
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override ItemStack stack() => this.stack;

    [LineNumberTable(1683)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override Item item() => this.stack.item;

    [LineNumberTable(324)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool isValid() => !this.dead && this.isAdded();

    [LineNumberTable(1077)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool isBuilding() => this.plans.size != 0;

    [LineNumberTable(1736)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override BuildPlan buildPlan() => this.plans.size == 0 ? (BuildPlan) null : (BuildPlan) this.plans.first();

    [HideFromJava]
    public override bool within([In] Position obj0, [In] float obj1) => Position.\u003Cdefault\u003Ewithin((Position) this, obj0, obj1);

    [LineNumberTable(new byte[] {161, 112, 123, 108, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void damage(float amount)
    {
      amount = Math.max(amount - this.armor, 0.1f * amount);
      amount /= this.healthMultiplier;
      this.rawDamage(amount);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool isFlying() => (double) this.elevation >= 0.0900000035762787;

    [LineNumberTable(new byte[] {167, 119, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void aim(Position pos) => this.aim(pos.getX(), pos.getY());

    [LineNumberTable(new byte[] {160, 248, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void lookAt(Position pos) => this.lookAt(this.angleTo(pos));

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void set(float x, float y)
    {
      this.x = x;
      this.y = y;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool isShooting() => this.isShooting;

    [LineNumberTable(2038)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override float range() => this.type.maxRange;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override float aimX() => this.aimX;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override float aimY() => this.aimY;

    [LineNumberTable(830)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool mining() => this.mineTile != null && !this.activelyBuilding();

    [LineNumberTable(1989)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override int tileX() => World.toTile(this.x);

    [LineNumberTable(1663)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override int tileY() => World.toTile(this.y);

    [LineNumberTable(new byte[] {166, 46, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool canPass(int tileX, int tileY)
    {
      EntityCollisions.SolidPred solidPred = this.solidity();
      return solidPred == null || !solidPred.solid(tileX, tileY);
    }

    [LineNumberTable(new byte[] {163, 36, 122, 108, 134, 113, 115, 114, 110, 116, 97, 110, 112, 123, 112, 119, 144, 225, 52, 233, 80, 104, 122, 106, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void apply(StatusEffect effect, float duration)
    {
      if (object.ReferenceEquals((object) effect, (object) StatusEffects.none) || effect == null || this.isImmune(effect))
        return;
      if (Vars.state.isCampaign())
        effect.unlock();
      if (this.statuses.size > 0)
      {
        for (int index = 0; index < this.statuses.size; ++index)
        {
          StatusEntry statusEntry = (StatusEntry) this.statuses.get(index);
          if (object.ReferenceEquals((object) statusEntry.effect, (object) effect))
          {
            statusEntry.time = Math.max(statusEntry.time, duration);
            return;
          }
          if (statusEntry.effect.reactsWith(effect))
          {
            StatusEntry.__\u003C\u003Etmp.effect = statusEntry.effect;
            statusEntry.effect.getTransition((Unit) this, effect, statusEntry.time, duration, StatusEntry.__\u003C\u003Etmp);
            statusEntry.time = StatusEntry.__\u003C\u003Etmp.time;
            if (object.ReferenceEquals((object) StatusEntry.__\u003C\u003Etmp.effect, (object) statusEntry.effect))
              return;
            statusEntry.effect = StatusEntry.__\u003C\u003Etmp.effect;
            return;
          }
        }
      }
      if (effect.reactive)
        return;
      StatusEntry statusEntry1 = (StatusEntry) Pools.obtain((Class) ClassLiteral<StatusEntry>.Value, (Prov) new MechUnitLegacyPulsar.__\u003C\u003EAnon9());
      statusEntry1.set(effect, duration);
      this.statuses.add((object) statusEntry1);
    }

    [LineNumberTable(new byte[] {160, 228, 104, 199, 108, 127, 24, 145})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void moveAt(Vec2 vector, float acceleration)
    {
      if (!vector.isZero())
        this.walked = true;
      Vec2 v = MechUnitLegacyPulsar.__\u003C\u003Etmp1.set(vector);
      MechUnitLegacyPulsar.__\u003C\u003Etmp2.set(v).sub(this.vel).limit(acceleration * vector.len() * Time.delta * this.floorSpeedMultiplier());
      this.vel.add(MechUnitLegacyPulsar.__\u003C\u003Etmp2);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override Team team() => this.team;

    [LineNumberTable(new byte[] {161, 129, 104, 127, 24, 162})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool activelyBuilding() => (!this.isBuilding() || Vars.state.isEditor() || this.within((Position) this.buildPlan(), !Vars.state.rules.infiniteResources ? 220f : float.MaxValue)) && (this.isBuilding() && this.updateBuilding);

    [HideFromJava]
    public override float angleTo([In] float obj0, [In] float obj1) => Position.\u003Cdefault\u003EangleTo((Position) this, obj0, obj1);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override float bounds() => this.hitSize * 2f;

    [LineNumberTable(new byte[] {163, 223, 105, 107, 107, 107, 139, 116, 104, 125, 135, 104, 235, 58, 230, 75, 167, 119, 172, 166, 108, 176})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void remove()
    {
      if (!this.added)
        return;
      Groups.all.remove((Entityc) this);
      Groups.unit.remove((Entityc) this);
      Groups.sync.remove((Entityc) this);
      Groups.draw.remove((Entityc) this);
      WeaponMount[] mounts = this.mounts;
      int length = mounts.Length;
      for (int index = 0; index < length; ++index)
      {
        WeaponMount weaponMount = mounts[index];
        if (weaponMount.bullet != null)
        {
          weaponMount.bullet.time = weaponMount.bullet.lifetime - 10f;
          weaponMount.bullet = (Bullet) null;
        }
        if (weaponMount.sound != null)
          weaponMount.sound.stop();
      }
      this.added = false;
      this.team.data().updateCount(this.type, -1);
      this.controller.removed((Unit) this);
      this.clearCommand();
      if (!Vars.net.client())
        return;
      Vars.netClient.addRemovedEntity(this.id());
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool isGrounded() => (double) this.elevation < 1.0 / 1000.0;

    [Signature("(Lmindustry/ai/formations/Formation;Larc/struct/Seq<Lmindustry/gen/Unit;>;)V")]
    [LineNumberTable(new byte[] {163, 15, 102, 102, 110, 113, 109, 155, 111, 111, 125, 98, 103, 108, 107, 124, 118, 98, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void command(Formation formation, Seq units)
    {
      this.clearCommand();
      units.shuffle();
      float num = this.hitSize * 0.8f;
      this.minFormationSpeed = this.type.speed;
      this.controlling.addAll(units);
      Iterator iterator1 = units.iterator();
      while (iterator1.hasNext())
      {
        Unit unit = (Unit) iterator1.next();
        FormationAI formationAi;
        unit.controller((UnitController) (formationAi = new FormationAI((Unit) this, formation)));
        num = Math.max(num, formationAi.formationSize());
        this.minFormationSpeed = Math.min(this.minFormationSpeed, unit.type.speed);
      }
      this.formation = formation;
      formation.pattern.spacing = num;
      MechUnitLegacyPulsar.__\u003C\u003Emembers.clear();
      Iterator iterator2 = units.iterator();
      while (iterator2.hasNext())
      {
        Unitc unitc = (Unitc) iterator2.next();
        MechUnitLegacyPulsar.__\u003C\u003Emembers.add((object) (FormationAI) unitc.controller());
      }
      formation.addMembers((Iterable) MechUnitLegacyPulsar.__\u003C\u003Emembers);
    }

    [LineNumberTable(1565)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool isImmune(StatusEffect effect) => this.type.immunities.contains((object) effect);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void updateLastPosition()
    {
      this.deltaX = this.x - this.lastX;
      this.deltaY = this.y - this.lastY;
      this.lastX = this.x;
      this.lastY = this.y;
    }

    [LineNumberTable(826)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override int count() => this.team.data().countType(this.type);

    [LineNumberTable(1073)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override int cap() => Units.getCap(this.team);

    [LineNumberTable(1667)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool isPlayer() => this.controller is Player;

    [LineNumberTable(1831)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override Player getPlayer() => this.isPlayer() ? (Player) this.controller : (Player) null;

    [LineNumberTable(1671)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override int itemCapacity() => this.type.itemCapacity;

    [LineNumberTable(984)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override EntityCollisions.SolidPred solidity() => this.isFlying() ? (EntityCollisions.SolidPred) null : (EntityCollisions.SolidPred) new MechUnitLegacyPulsar.__\u003C\u003EAnon10();

    [LineNumberTable(1523)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool hasItem() => this.stack.amount > 0;

    [LineNumberTable(new byte[] {165, 165, 127, 15, 108, 127, 3})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void addItem(Item item, int amount)
    {
      this.stack.amount = !object.ReferenceEquals((object) this.stack.item, (object) item) ? amount : this.stack.amount + amount;
      this.stack.item = item;
      this.stack.amount = Mathf.clamp(this.stack.amount, 0, this.itemCapacity());
    }

    [LineNumberTable(1774)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool moving() => !this.vel.isZero(0.01f);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override Vec2 vel() => this.vel;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool isCommanding() => this.formation != null;

    [LineNumberTable(new byte[] {163, 133, 103, 99, 146, 112, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void move(float cx, float cy)
    {
      EntityCollisions.SolidPred solidCheck = this.solidity();
      if (solidCheck != null)
      {
        Vars.collisions.move((Hitboxc) this, cx, cy, solidCheck);
      }
      else
      {
        this.x += cx;
        this.y += cy;
      }
    }

    [LineNumberTable(1139)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override float deltaLen() => Mathf.len(this.deltaX, this.deltaY);

    [LineNumberTable(1701)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override float deltaAngle() => Mathf.angle(this.deltaX, this.deltaY);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override UnitType type() => this.type;

    [LineNumberTable(new byte[] {158, 208, 66, 123, 114, 127, 95})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float walkExtend(bool scaled)
    {
      int num1 = scaled ? 1 : 0;
      float num2 = this.walkTime % (this.type.mechStride * 4f);
      if (num1 != 0)
        return num2 / this.type.mechStride;
      if ((double) num2 > (double) (this.type.mechStride * 3f))
        num2 -= this.type.mechStride * 4f;
      else if ((double) num2 > (double) (this.type.mechStride * 2f))
        num2 = this.type.mechStride * 2f - num2;
      else if ((double) num2 > (double) this.type.mechStride)
        num2 = this.type.mechStride * 2f - num2;
      return num2;
    }

    [LineNumberTable(1569)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override Building closestCore() => (Building) Vars.state.teams.closestCore(this.x, this.y, this.team);

    [LineNumberTable(1052)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool acceptsItem(Item item) => !this.hasItem() || object.ReferenceEquals((object) item, (object) this.stack.item) && this.stack.amount + 1 <= this.itemCapacity();

    [LineNumberTable(1659)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool offloadImmediately() => this.isPlayer();

    [LineNumberTable(new byte[] {165, 116, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void clearItem() => this.stack.amount = 0;

    [LineNumberTable(1705)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool validMine(Tile tile) => this.validMine(tile, true);

    [LineNumberTable(new byte[] {163, 182, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void addItem(Item item) => this.addItem(item, 1);

    [LineNumberTable(516)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool canShoot() => !this.disarmed && (!this.type.canBoost || !this.isFlying());

    [LineNumberTable(new byte[] {161, 241, 103, 103, 103, 118, 127, 29, 104, 127, 19, 102, 99, 255, 12, 72, 159, 8, 105, 99, 255, 4, 74, 127, 8, 117, 139, 121, 123, 123, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void shoot(
      [In] WeaponMount obj0,
      [In] float obj1,
      [In] float obj2,
      [In] float obj3,
      [In] float obj4,
      [In] float obj5,
      [In] float obj6,
      [In] float obj7,
      [In] int obj8)
    {
      Weapon weapon = obj0.__\u003C\u003Eweapon;
      float x = this.x;
      float y = this.y;
      int num1 = (double) (weapon.firstShotDelay + weapon.shotDelay) > 0.0 ? 1 : 0;
      (num1 == 0 ? (!weapon.continuous ? weapon.shootSound : Sounds.none) : weapon.chargeSound).at(obj1, obj2, Mathf.random(weapon.soundPitchMin, weapon.soundPitchMax));
      BulletType bullet = weapon.bullet;
      float num2 = !bullet.scaleVelocity ? 1f : Mathf.clamp(Mathf.dst(obj1, obj2, obj3, obj4) / bullet.range());
      MechUnitLegacyPulsar.sequenceNum = 0;
      if (num1 != 0)
        Angles.shotgun(weapon.shots, weapon.spacing, obj7, (Floatc) new MechUnitLegacyPulsar.__\u003C\u003EAnon2(this, weapon, obj0, obj1, x, obj2, y, num2));
      else
        Angles.shotgun(weapon.shots, weapon.spacing, obj7, (Floatc) new MechUnitLegacyPulsar.__\u003C\u003EAnon3(this, obj0, weapon, obj1, obj2, num2));
      int num3 = bullet.keepVelocity ? 1 : 0;
      if (num1 != 0)
      {
        Time.run(weapon.firstShotDelay, (Runnable) new MechUnitLegacyPulsar.__\u003C\u003EAnon4(this, obj7, bullet, weapon, obj1, obj2, obj0));
      }
      else
      {
        this.vel.add(Tmp.__\u003C\u003Ev1.trns(obj7 + 180f, bullet.recoil));
        Effect.shake(weapon.shake, weapon.shake, obj1, obj2);
        obj0.heat = 1f;
      }
      weapon.ejectEffect.at(obj5, obj6, obj7 * (float) obj8);
      bullet.shootEffect.at(obj1, obj2, obj7, num3 == 0 ? (object) (MechUnitLegacyPulsar) null : (object) this);
      bullet.smokeEffect.at(obj1, obj2, obj7, num3 == 0 ? (object) (MechUnitLegacyPulsar) null : (object) this);
      this.apply(weapon.shootStatus, weapon.shootStatusDuration);
    }

    [LineNumberTable(new byte[] {162, 186, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override Floor floorOn()
    {
      Tile tile = this.tileOn();
      return tile == null || !object.ReferenceEquals((object) tile.block(), (object) Blocks.air) ? (Floor) Blocks.air : tile.floor();
    }

    [HideFromJava]
    public override bool within([In] float obj0, [In] float obj1, [In] float obj2) => Position.\u003Cdefault\u003Ewithin((Position) this, obj0, obj1, obj2);

    [HideFromJava]
    public override float dst([In] Position obj0) => Position.\u003Cdefault\u003Edst((Position) this, obj0);

    [LineNumberTable(new byte[] {166, 157, 127, 0})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void damageContinuous(float amount) => this.damage(amount * Time.delta, (double) this.hitTime <= -1.0);

    [LineNumberTable(606)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool canPassOn() => this.canPass(this.tileX(), this.tileY());

    [LineNumberTable(new byte[] {166, 209, 117, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void kill()
    {
      if (this.dead || Vars.net.client())
        return;
      Call.unitDeath(this.id);
    }

    [LineNumberTable(new byte[] {165, 120, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void resetController() => this.controller(this.type.createController());

    [LineNumberTable(358)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool isRemote() => this is Unitc && this.isPlayer() && !this.isLocal();

    [LineNumberTable(new byte[] {163, 86, 122, 109, 118, 121, 121, 121, 121, 108, 108, 108, 108, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void interpolate()
    {
      if (this.lastUpdated != 0L && this.updateSpacing != 0L)
      {
        float progress = Math.min((float) Time.timeSinceMillis(this.lastUpdated) / (float) this.updateSpacing, 2f);
        this.baseRotation = Mathf.slerp(this.baseRotation_LAST_, this.baseRotation_TARGET_, progress);
        this.rotation = Mathf.slerp(this.rotation_LAST_, this.rotation_TARGET_, progress);
        this.x = Mathf.lerp(this.x_LAST_, this.x_TARGET_, progress);
        this.y = Mathf.lerp(this.y_LAST_, this.y_TARGET_, progress);
      }
      else
      {
        if (this.lastUpdated == 0L)
          return;
        this.baseRotation = this.baseRotation_TARGET_;
        this.rotation = this.rotation_TARGET_;
        this.x = this.x_TARGET_;
        this.y = this.y_TARGET_;
      }
    }

    [LineNumberTable(2042)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool canBuild() => (double) this.type.buildSpeed > 0.0 && (double) this.buildSpeedMultiplier > 0.0;

    [LineNumberTable(1864)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override Building core() => (Building) this.team.core();

    [LineNumberTable(new byte[] {161, 150, 127, 31})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool shouldSkip(BuildPlan request, Building core) => !Vars.state.rules.infiniteResources && !this.team.rules().infiniteResources && (!request.breaking && core != null) && !request.isRotation(this.team) && (request.stuck && !core.items.has(request.block.requirements) || Structs.contains((object[]) request.block.requirements, (Boolf) new MechUnitLegacyPulsar.__\u003C\u003EAnon1(core)) && !request.initialized);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override float deltaX() => this.deltaX;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override float deltaY() => this.deltaY;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override float hitSize() => this.hitSize;

    [LineNumberTable(799)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool canDrown() => this.isGrounded() && !this.hovering && this.type.canDrown;

    [LineNumberTable(new byte[] {161, 222, 125})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void clampHealth() => this.health = Mathf.clamp(this.health, 0.0f, this.maxHealth);

    [LineNumberTable(new byte[] {165, 148, 108, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void afterSync()
    {
      this.setType(this.type);
      this.controller.unit((Unit) this);
    }

    [LineNumberTable(328)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override float realSpeed() => Mathf.lerp(1f, !this.type.canBoost ? 1f : this.type.boostMultiplier, this.elevation) * this.speed() * this.floorSpeedMultiplier();

    [Signature("(Lmindustry/ai/formations/FormationPattern;Larc/func/Boolf<Lmindustry/gen/Unit;>;)V")]
    [LineNumberTable(new byte[] {163, 0, 127, 4, 108, 107, 255, 9, 69, 109, 127, 16, 117, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void commandNearby(FormationPattern pattern, Boolf include)
    {
      Vec3.__\u003Cclinit\u003E();
      Formation formation = new Formation(new Vec3(this.x, this.y, this.rotation), pattern);
      formation.slotAssignmentStrategy = (SlotAssignmentStrategy) new DistanceAssignmentStrategy(pattern);
      MechUnitLegacyPulsar.__\u003C\u003Eunits.clear();
      Units.nearby(this.team, this.x, this.y, 150f, (Cons) new MechUnitLegacyPulsar.__\u003C\u003EAnon6(this, include));
      if (MechUnitLegacyPulsar.__\u003C\u003Eunits.isEmpty())
        return;
      MechUnitLegacyPulsar.__\u003C\u003Eunits.sort(Structs.comps(Structs.comparingFloat((Floatf) new MechUnitLegacyPulsar.__\u003C\u003EAnon7()), Structs.comparingFloat((Floatf) new MechUnitLegacyPulsar.__\u003C\u003EAnon8(this))));
      MechUnitLegacyPulsar.__\u003C\u003Eunits.truncate(this.type.commandLimit);
      this.command(formation, MechUnitLegacyPulsar.__\u003C\u003Eunits);
    }

    [LineNumberTable(1985)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool canMine(Item item) => this.type.mineTier >= item.hardness;

    [LineNumberTable(new byte[] {157, 233, 164, 120, 104, 8, 200, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void controlWeapons(bool rotate, bool shoot)
    {
      int num1 = rotate ? 1 : 0;
      int num2 = shoot ? 1 : 0;
      WeaponMount[] mounts = this.mounts;
      int length = mounts.Length;
      for (int index = 0; index < length; ++index)
      {
        WeaponMount weaponMount = mounts[index];
        weaponMount.rotate = num1 != 0;
        weaponMount.shoot = num2 != 0;
      }
      this.isRotate = num1 != 0;
      this.isShooting = num2 != 0;
    }

    [LineNumberTable(1655)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool validMine(Tile tile, bool checkDst)
    {
      int num = checkDst ? 1 : 0;
      return tile != null && object.ReferenceEquals((object) tile.block(), (object) Blocks.air) && (this.within(tile.worldx(), tile.worldy(), 70f) || num == 0) && (tile.drop() != null && this.canMine(tile.drop()));
    }

    [LineNumberTable(new byte[] {165, 198, 127, 1, 127, 15, 116, 116, 116, 104, 8, 198, 104, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void aim(float x, float y)
    {
      Tmp.__\u003C\u003Ev1.set(x, y).sub(this.x, this.y);
      if ((double) Tmp.__\u003C\u003Ev1.len() < (double) this.type.aimDst)
        Tmp.__\u003C\u003Ev1.setLength(this.type.aimDst);
      x = Tmp.__\u003C\u003Ev1.x + this.x;
      y = Tmp.__\u003C\u003Ev1.y + this.y;
      WeaponMount[] mounts = this.mounts;
      int length = mounts.Length;
      for (int index = 0; index < length; ++index)
      {
        WeaponMount weaponMount = mounts[index];
        weaponMount.aimX = x;
        weaponMount.aimY = y;
      }
      this.aimX = x;
      this.aimY = y;
    }

    [LineNumberTable(new byte[] {166, 146, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void lookAt(float x, float y) => this.lookAt(this.angleTo(x, y));

    [LineNumberTable(new byte[] {166, 218, 122})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void trns(float x, float y) => this.set(this.x + x, this.y + y);

    [LineNumberTable(new byte[] {167, 105, 104, 118})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void impulse(float x, float y)
    {
      float num = this.mass();
      this.vel.add(x / num, y / num);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override float mass() => this.hitSize * this.hitSize * 3.141593f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override WeaponMount[] mounts() => this.mounts;

    [LineNumberTable(new byte[] {160, 203, 118, 108, 62, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setupWeapons(UnitType def)
    {
      this.mounts = new WeaponMount[def.weapons.size];
      for (int index = 0; index < this.mounts.Length; ++index)
        this.mounts[index] = new WeaponMount((Weapon) def.weapons.get(index));
    }

    [LineNumberTable(new byte[] {159, 15, 66, 103, 104, 99, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void damage(float amount, bool withEffect)
    {
      int num = withEffect ? 1 : 0;
      float hitTime = this.hitTime;
      this.damage(amount);
      if (num != 0)
        return;
      this.hitTime = hitTime;
    }

    [LineNumberTable(new byte[] {159, 68, 66, 103, 104, 99, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void damagePierce(float amount, bool withEffect)
    {
      int num = withEffect ? 1 : 0;
      float hitTime = this.hitTime;
      this.rawDamage(amount);
      if (num != 0)
        return;
      this.hitTime = hitTime;
    }

    [Signature("()Larc/struct/Seq<Lmindustry/gen/Unit;>;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override Seq controlling() => this.controlling;

    [LineNumberTable(834)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool hasEffect(StatusEffect effect) => this.applied.get((int) effect.__\u003C\u003Eid);

    [LineNumberTable(new byte[] {165, 224, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Bullet bullet([In] Weapon obj0, [In] float obj1, [In] float obj2, [In] float obj3, [In] float obj4)
    {
      float y = Mathf.range(obj0.xRand);
      return obj0.bullet.create((Entityc) this, this.team(), obj1 + Angles.trnsx(obj3, 0.0f, y), obj2 + Angles.trnsy(obj3, 0.0f, y), obj3, 1f - obj0.velocityRnd + Mathf.random(obj0.velocityRnd), obj4);
    }

    [Modifiers]
    [LineNumberTable(281)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool lambda\u0024drawBuildPlans\u00240([In] BuildPlan obj0) => (double) obj0.progress > 0.00999999977648258 || object.ReferenceEquals((object) this.buildPlan(), (object) obj0) && obj0.initialized && (this.within((float) (obj0.x * 8), (float) (obj0.y * 8), 220f) || Vars.state.isEditor());

    [Modifiers]
    [LineNumberTable(521)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024shouldSkip\u00241([In] Building obj0, [In] ItemStack obj1) => !obj0.items.has(obj1.item) && Mathf.round((float) obj1.amount * Vars.state.rules.buildCostMultiplier) > 0;

    [Modifiers]
    [LineNumberTable(new byte[] {161, 251, 223, 26, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024shoot\u00243(
      [In] Weapon obj0,
      [In] WeaponMount obj1,
      [In] float obj2,
      [In] float obj3,
      [In] float obj4,
      [In] float obj5,
      [In] float obj6,
      [In] float obj7)
    {
      Time.run((float) MechUnitLegacyPulsar.sequenceNum * obj0.shotDelay + obj0.firstShotDelay, (Runnable) new MechUnitLegacyPulsar.__\u003C\u003EAnon18(this, obj1, obj0, obj2, obj3, obj4, obj5, obj7, obj6));
      ++MechUnitLegacyPulsar.sequenceNum;
    }

    [Modifiers]
    [LineNumberTable(628)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024shoot\u00244(
      [In] WeaponMount obj0,
      [In] Weapon obj1,
      [In] float obj2,
      [In] float obj3,
      [In] float obj4,
      [In] float obj5)
    {
      obj0.bullet = this.bullet(obj1, obj2, obj3, obj5 + Mathf.range(obj1.inaccuracy), obj4);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {162, 7, 105, 127, 6, 119, 108, 104, 159, 5})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024shoot\u00245(
      [In] float obj0,
      [In] BulletType obj1,
      [In] Weapon obj2,
      [In] float obj3,
      [In] float obj4,
      [In] WeaponMount obj5)
    {
      if (!this.isAdded())
        return;
      this.vel.add(Tmp.__\u003C\u003Ev1.trns(obj0 + 180f, obj1.recoil));
      Effect.shake(obj2.shake, obj2.shake, obj3, obj4);
      obj5.heat = 1f;
      if (obj2.continuous)
        return;
      obj2.shootSound.at(obj3, obj4, Mathf.random(obj2.soundPitchMin, obj2.soundPitchMax));
    }

    [Modifiers]
    [LineNumberTable(729)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private float lambda\u0024draw\u00246([In] float obj0, [In] Vec2 obj1) => -Angles.angleDist(this.angleTo((Position) obj1), obj0);

    [Modifiers]
    [LineNumberTable(new byte[] {163, 4, 127, 40, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024commandNearby\u00247([In] Boolf obj0, [In] Unit obj1)
    {
      if (!obj1.isAI() || !obj0.get((object) obj1) || (object.ReferenceEquals((object) obj1, (object) this) || obj1.type.flying != this.type.flying) || (double) obj1.hitSize > (double) (this.hitSize * 1.1f))
        return;
      MechUnitLegacyPulsar.__\u003C\u003Eunits.add((object) obj1);
    }

    [Modifiers]
    [LineNumberTable(891)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static float lambda\u0024commandNearby\u00248([In] Unit obj0) => -obj0.hitSize;

    [Modifiers]
    [LineNumberTable(891)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private float lambda\u0024commandNearby\u00249([In] Unit obj0) => obj0.dst2((Position) this);

    [Modifiers]
    [LineNumberTable(1379)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool lambda\u0024update\u002410([In] Unit obj0)
    {
      if (!obj0.dead)
      {
        UnitController unitController = obj0.controller();
        FormationAI formationAi;
        if (unitController is FormationAI && object.ReferenceEquals((object) (formationAi = (FormationAI) unitController), (object) (FormationAI) unitController) && object.ReferenceEquals((object) formationAi.leader, (object) this))
          return false;
      }
      return true;
    }

    [Modifiers]
    [LineNumberTable(1424)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024update\u002411([In] Building obj0, [In] ItemStack obj1) => obj0 != null && !obj0.items.has(obj1.item);

    [Modifiers]
    [LineNumberTable(1441)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024update\u002412([In] Tile obj0, [In] BuildPlan obj1) => Events.fire((object) new EventType.BuildSelectEvent(obj0, this.team, (Unit) this, obj1.breaking));

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024commandNearby\u002413([In] Unit obj0) => true;

    [Modifiers]
    [LineNumberTable(1824)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024removeBuild\u002414(
      [In] bool obj0,
      [In] int obj1,
      [In] int obj2,
      [In] BuildPlan obj3)
    {
      int num = obj0 ? 1 : 0;
      return (obj3.breaking ? 1 : 0) == num && obj3.x == obj1 && obj3.y == obj2;
    }

    [Modifiers]
    [LineNumberTable(new byte[] {167, 65, 110, 102, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024unapply\u002415([In] StatusEffect obj0, [In] StatusEntry obj1)
    {
      if (!object.ReferenceEquals((object) obj1.effect, (object) obj0))
        return false;
      Pools.free((object) obj1);
      return true;
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 252, 105, 127, 33})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024shoot\u00242(
      [In] WeaponMount obj0,
      [In] Weapon obj1,
      [In] float obj2,
      [In] float obj3,
      [In] float obj4,
      [In] float obj5,
      [In] float obj6,
      [In] float obj7)
    {
      if (!this.isAdded())
        return;
      obj0.bullet = this.bullet(obj1, obj2 + this.x - obj3, obj4 + this.y - obj5, obj6 + Mathf.range(obj1.inaccuracy), obj7);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool serialize() => true;

    [LineNumberTable(268)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toString() => new StringBuilder().append("MechUnitLegacyPulsar#").append(this.id).toString();

    [LineNumberTable(new byte[] {160, 167, 108, 105, 127, 1, 107, 99, 142, 140, 226, 56, 233, 74, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void drawBuildPlans()
    {
      Boolf boolf = (Boolf) new MechUnitLegacyPulsar.__\u003C\u003EAnon0(this);
      for (int index = 0; index < 2; ++index)
      {
        Iterator iterator = this.plans.iterator();
        while (iterator.hasNext())
        {
          BuildPlan request = (BuildPlan) iterator.next();
          if (!boolf.get((object) request))
          {
            if (index == 0)
              this.drawPlan(request, 1f);
            else
              this.drawPlanTop(request, 1f);
          }
        }
      }
      Draw.reset();
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override float getY() => this.y;

    [LineNumberTable(new byte[] {160, 198, 127, 43, 127, 43})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void wobble()
    {
      MechUnitLegacyPulsar unitLegacyPulsar1 = this;
      double x = (double) unitLegacyPulsar1.x;
      double time1 = (double) Time.time;
      int num1 = this.id();
      int num2 = 10;
      double num3 = (double) ((num2 != -1 ? num1 % num2 : 0) * 12);
      double num4 = (double) (Mathf.sin((float) (time1 + num3), 25f, 0.05f) * Time.delta * this.elevation);
      unitLegacyPulsar1.x = (float) (x + num4);
      MechUnitLegacyPulsar unitLegacyPulsar2 = this;
      double y = (double) unitLegacyPulsar2.y;
      double time2 = (double) Time.time;
      int num5 = this.id();
      int num6 = 10;
      double num7 = (double) ((num6 != -1 ? num5 % num6 : 0) * 12);
      double num8 = (double) (Mathf.cos((float) (time2 + num7), 25f, 0.05f) * Time.delta * this.elevation);
      unitLegacyPulsar2.y = (float) (y + num8);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override float healthf() => this.health / this.maxHealth;

    [LineNumberTable(new byte[] {160, 222, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool onSolid()
    {
      Tile tile = this.tileOn();
      return tile == null || tile.solid();
    }

    [LineNumberTable(new byte[] {160, 240, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void clearBuilding() => this.plans.clear();

    [LineNumberTable(new byte[] {160, 252, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void healFract(float amount) => this.heal(amount * this.maxHealth);

    [LineNumberTable(new byte[] {161, 1, 108, 107, 103, 109, 198, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void killed()
    {
      this.wasPlayer = this.isLocal();
      this.health = 0.0f;
      this.dead = true;
      if (!this.type.flying)
        this.destroy();
      this.clearCommand();
    }

    [LineNumberTable(new byte[] {161, 15, 103, 102, 109, 109, 109, 114, 109, 110, 109, 108, 108, 114, 103, 107, 102, 103, 15, 198, 109, 109, 108, 114, 103, 108, 104, 104, 17, 200, 108, 127, 1, 109, 109, 108, 109, 109, 109, 114, 109, 110, 109, 108, 108, 114, 103, 107, 102, 103, 15, 198, 109, 109, 108, 114, 103, 108, 104, 104, 17, 200, 108, 127, 1, 108, 109, 109, 98, 159, 16, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void read(Reads read)
    {
      int num1 = (int) read.s();
      switch (num1)
      {
        case 0:
          this.ammo = read.f();
          this.armor = read.f();
          this.baseRotation = read.f();
          this.controller = TypeIO.readController(read, this.controller);
          this.elevation = read.f();
          this.flag = read.d();
          this.health = read.f();
          this.isShooting = read.@bool();
          this.mineTile = TypeIO.readTile(read);
          this.mounts = TypeIO.readMounts(read, this.mounts);
          int num2 = read.i();
          this.plans.clear();
          for (int index = 0; index < num2; ++index)
          {
            BuildPlan buildPlan = TypeIO.readRequest(read);
            if (buildPlan != null)
              this.plans.add((object) buildPlan);
          }
          this.rotation = read.f();
          this.shield = read.f();
          this.spawnedByCore = read.@bool();
          this.stack = TypeIO.readItems(read, this.stack);
          int num3 = read.i();
          this.statuses.clear();
          for (int index = 0; index < num3; ++index)
          {
            StatusEntry statusEntry = TypeIO.readStatuse(read);
            if (statusEntry != null)
              this.statuses.add((object) statusEntry);
          }
          this.team = TypeIO.readTeam(read);
          this.type = (UnitType) Vars.content.getByID(ContentType.__\u003C\u003Eunit, (int) read.s());
          this.x = read.f();
          this.y = read.f();
          break;
        case 1:
          this.ammo = read.f();
          this.armor = read.f();
          this.baseRotation = read.f();
          this.controller = TypeIO.readController(read, this.controller);
          this.elevation = read.f();
          this.flag = read.d();
          this.health = read.f();
          this.isShooting = read.@bool();
          this.mineTile = TypeIO.readTile(read);
          this.mounts = TypeIO.readMounts(read, this.mounts);
          int num4 = read.i();
          this.plans.clear();
          for (int index = 0; index < num4; ++index)
          {
            BuildPlan buildPlan = TypeIO.readRequest(read);
            if (buildPlan != null)
              this.plans.add((object) buildPlan);
          }
          this.rotation = read.f();
          this.shield = read.f();
          this.spawnedByCore = read.@bool();
          this.stack = TypeIO.readItems(read, this.stack);
          int num5 = read.i();
          this.statuses.clear();
          for (int index = 0; index < num5; ++index)
          {
            StatusEntry statusEntry = TypeIO.readStatuse(read);
            if (statusEntry != null)
              this.statuses.add((object) statusEntry);
          }
          this.team = TypeIO.readTeam(read);
          this.type = (UnitType) Vars.content.getByID(ContentType.__\u003C\u003Eunit, (int) read.s());
          this.updateBuilding = read.@bool();
          this.x = read.f();
          this.y = read.f();
          break;
        default:
          string str = new StringBuilder().append("Unknown revision '").append(num1).append("' for entity type 'pulsar'").toString();
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalArgumentException(str);
      }
      this.afterRead();
    }

    [LineNumberTable(new byte[] {161, 86, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void addBuild(BuildPlan place) => this.addBuild(place, true);

    [Signature("(Larc/func/Cons<Larc/math/geom/QuadTree;>;)V")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void getCollisions(Cons consumer)
    {
    }

    [LineNumberTable(new byte[] {161, 101, 110, 135, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void set(UnitType def, UnitController controller)
    {
      if (!object.ReferenceEquals((object) this.type, (object) def))
        this.setType(def);
      this.controller(controller);
    }

    [LineNumberTable(478)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override Building closestEnemyCore() => (Building) Vars.state.teams.closestEnemyCore(this.x, this.y, this.team);

    [LineNumberTable(new byte[] {161, 118, 127, 13, 107, 127, 22, 126, 127, 85, 127, 160, 90, 229, 58})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override object senseObject(LAccess sensor)
    {
      switch (MechUnitLegacyPulsar.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess[sensor.ordinal()])
      {
        case 1:
          return (object) this.type;
        case 2:
          UnitController controller1 = this.controller;
          Player player;
          return controller1 is Player && object.ReferenceEquals((object) (player = (Player) controller1), (object) (Player) controller1) ? (object) player.name : (object) null;
        case 3:
          return this.stack().amount == 0 ? (object) null : (object) this.item();
        case 4:
          if (!this.isValid())
            return (object) null;
          UnitController controller2 = this.controller;
          LogicAI logicAi;
          if (controller2 is LogicAI && object.ReferenceEquals((object) (logicAi = (LogicAI) controller2), (object) (LogicAI) controller2))
            return (object) logicAi.controller;
          UnitController controller3 = this.controller;
          FormationAI formationAi;
          return controller3 is FormationAI && object.ReferenceEquals((object) (formationAi = (FormationAI) controller3), (object) (FormationAI) controller3) ? (object) formationAi.leader : (object) this;
        case 5:
          MechUnitLegacyPulsar unitLegacyPulsar = this;
          Payloadc payloadc;
          if (!(unitLegacyPulsar is Payloadc) || !object.ReferenceEquals((object) (payloadc = (Payloadc) unitLegacyPulsar), (object) (Payloadc) unitLegacyPulsar))
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

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool damaged() => (double) this.health < (double) (this.maxHealth - 1f / 1000f);

    [LineNumberTable(new byte[] {161, 159, 104, 159, 42})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override float clipSize()
    {
      if (!this.isBuilding())
        return Math.max((float) this.type.region.width * 2f, this.type.clipSize);
      return Vars.state.rules.infiniteResources ? float.MaxValue : Math.max(this.type.clipSize, (float) this.type.region.width) + 220f + 32f;
    }

    [LineNumberTable(new byte[] {161, 166, 105, 107, 108, 108, 108, 108, 108, 108, 108, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void snapInterpolation()
    {
      this.updateSpacing = 16L;
      this.lastUpdated = Time.millis();
      this.baseRotation_LAST_ = this.baseRotation;
      this.baseRotation_TARGET_ = this.baseRotation;
      this.rotation_LAST_ = this.rotation;
      this.rotation_TARGET_ = this.rotation;
      this.x_LAST_ = this.x;
      this.x_TARGET_ = this.x;
      this.y_LAST_ = this.y;
      this.y_TARGET_ = this.y;
    }

    [LineNumberTable(new byte[] {161, 179, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void aimLook(Position pos)
    {
      this.aim(pos);
      this.lookAt(pos);
    }

    [LineNumberTable(new byte[] {161, 188, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void set(Position pos) => this.set(pos.getX(), pos.getY());

    [LineNumberTable(new byte[] {161, 192, 127, 89, 113, 113, 108, 108, 108, 127, 15, 113, 114, 114, 127, 5, 113, 124, 127, 10, 116, 115, 115, 124, 127, 8, 127, 8, 107, 127, 74, 127, 4, 127, 17, 112, 233, 39})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override double sense(LAccess sensor)
    {
      switch (MechUnitLegacyPulsar.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess[sensor.ordinal()])
      {
        case 6:
          return (double) this.stack().amount;
        case 7:
          return (double) this.type.itemCapacity;
        case 8:
          return (double) this.rotation;
        case 9:
          return (double) this.health;
        case 10:
          return (double) this.maxHealth;
        case 11:
          return !Vars.state.rules.unitAmmo ? (double) this.type.ammoCapacity : (double) this.ammo;
        case 12:
          return (double) this.type.ammoCapacity;
        case 13:
          return (double) World.conv(this.x);
        case 14:
          return (double) World.conv(this.y);
        case 15:
          return this.dead || !this.isAdded() ? 1.0 : 0.0;
        case 16:
          return (double) this.team.__\u003C\u003Eid;
        case 17:
          return this.isShooting() ? 1.0 : 0.0;
        case 18:
          return this.type.canBoost && this.isFlying() ? 1.0 : 0.0;
        case 19:
          return (double) (this.range() / 8f);
        case 20:
          return (double) World.conv(this.aimX());
        case 21:
          return (double) World.conv(this.aimY());
        case 22:
          return this.mining() ? 1.0 : 0.0;
        case 23:
          return this.mining() ? (double) this.mineTile.x : -1.0;
        case 24:
          return this.mining() ? (double) this.mineTile.y : -1.0;
        case 25:
          return this.flag;
        case 26:
          if (!this.isValid())
            return 0.0;
          if (this.controller is LogicAI)
            return 1.0;
          if (this.controller is Player)
            return 2.0;
          return this.controller is FormationAI ? 3.0 : 0.0;
        case 27:
          return this.controller is FormationAI && this.isValid() ? 1.0 : 0.0;
        case 28:
          MechUnitLegacyPulsar unitLegacyPulsar = this;
          Payloadc payloadc;
          return !(unitLegacyPulsar is Payloadc) || !object.ReferenceEquals((object) (payloadc = (Payloadc) unitLegacyPulsar), (object) (Payloadc) unitLegacyPulsar) ? 0.0 : (double) payloadc.payloads().size;
        case 29:
          return (double) (this.hitSize / 8f);
        default:
          return double.NaN;
      }
    }

    [LineNumberTable(new byte[] {161, 226, 116, 40, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setWeaponRotation(float rotation)
    {
      WeaponMount[] mounts = this.mounts;
      int length = mounts.Length;
      for (int index = 0; index < length; ++index)
        mounts[index].rotation = rotation;
    }

    [LineNumberTable(602)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override TextureRegion icon() => this.type.icon(Cicon.__\u003C\u003Efull);

    [LineNumberTable(new byte[] {162, 27, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void moveAt(Vec2 vector) => this.moveAt(vector, this.type.accel);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override int pathType() => 0;

    [LineNumberTable(661)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool inRange(Position other) => this.within(other, this.type.range);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override float getX() => this.x;

    [LineNumberTable(new byte[] {162, 48, 109, 127, 6, 102, 102, 102, 119, 119, 127, 5, 127, 12, 106, 127, 11, 127, 23, 104, 111, 159, 16, 165, 127, 5, 109, 162, 172, 104, 113, 106, 116, 122, 109, 127, 15, 133, 126, 106, 109, 109, 138, 127, 18, 106, 106, 127, 0, 127, 5, 120, 120, 110, 109, 121, 121, 121, 121, 124, 125, 110, 110, 105, 105, 110, 110, 106, 107, 114, 159, 2, 111, 127, 1, 113, 147, 179, 109, 141, 127, 19, 101, 138})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void draw()
    {
      if (this.mining())
      {
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
      Iterator iterator = this.statuses.iterator();
      while (iterator.hasNext())
        ((StatusEntry) iterator.next()).effect.draw((Unit) this);
      this.type.draw((Unit) this);
      int num1 = this.activelyBuilding() ? 1 : 0;
      if (num1 == 0 && this.lastActive == null)
        return;
      Draw.z(115f);
      BuildPlan request = num1 == 0 ? this.lastActive : this.buildPlan();
      Tile tile = Vars.world.tile(request.x, request.y);
      CoreBlock.CoreBuild coreBuild = this.team.core();
      if (tile == null || !this.within((Position) request, !Vars.state.rules.infiniteResources ? 220f : float.MaxValue))
        return;
      if (coreBuild != null && num1 != 0 && (!this.isLocal() && !(tile.block() is ConstructBlock)))
      {
        Draw.z(84f);
        this.drawPlan(request, 0.5f);
        this.drawPlanTop(request, 0.5f);
        Draw.z(115f);
      }
      int num2 = !request.breaking ? request.block.size : (num1 == 0 ? this.lastSize : tile.block().size);
      float num3 = request.drawx();
      float num4 = request.drawy();
      Lines.stroke(1f, !request.breaking ? Pal.accent : Pal.remove);
      float len1 = this.type.buildBeamOffset + Mathf.absin(Time.time, 3f, 0.6f);
      float num5 = this.x + Angles.trnsx(this.rotation, len1);
      float num6 = this.y + Angles.trnsy(this.rotation, len1);
      float num7 = (float) (8 * num2) / 2f;
      float num8 = this.angleTo(num3, num4);
      MechUnitLegacyPulsar.__\u003C\u003Evecs[0].set(num3 - num7, num4 - num7);
      MechUnitLegacyPulsar.__\u003C\u003Evecs[1].set(num3 + num7, num4 - num7);
      MechUnitLegacyPulsar.__\u003C\u003Evecs[2].set(num3 - num7, num4 + num7);
      MechUnitLegacyPulsar.__\u003C\u003Evecs[3].set(num3 + num7, num4 + num7);
      Arrays.sort((object[]) MechUnitLegacyPulsar.__\u003C\u003Evecs, Structs.comparingFloat((Floatf) new MechUnitLegacyPulsar.__\u003C\u003EAnon5(this, num8)));
      Vec2 closest = (Vec2) Geometry.findClosest(this.x, this.y, (Position[]) MechUnitLegacyPulsar.__\u003C\u003Evecs);
      float x1 = MechUnitLegacyPulsar.__\u003C\u003Evecs[0].x;
      float y1 = MechUnitLegacyPulsar.__\u003C\u003Evecs[0].y;
      float x3 = closest.x;
      float y3 = closest.y;
      float x4 = MechUnitLegacyPulsar.__\u003C\u003Evecs[1].x;
      float y4 = MechUnitLegacyPulsar.__\u003C\u003Evecs[1].y;
      Draw.z(122f);
      Draw.alpha(this.buildAlpha);
      if (num1 == 0 && !(tile.build is ConstructBlock.ConstructBuild))
        Fill.square(request.drawx(), request.drawy(), (float) (num2 * 8) / 2f);
      if (Vars.renderer.animateShields)
      {
        if (!object.ReferenceEquals((object) closest, (object) MechUnitLegacyPulsar.__\u003C\u003Evecs[0]) && !object.ReferenceEquals((object) closest, (object) MechUnitLegacyPulsar.__\u003C\u003Evecs[1]))
        {
          Fill.tri(num5, num6, x1, y1, x3, y3);
          Fill.tri(num5, num6, x4, y4, x3, y3);
        }
        else
          Fill.tri(num5, num6, x1, y1, x4, y4);
      }
      else
      {
        Lines.line(num5, num6, x1, y1);
        Lines.line(num5, num6, x4, y4);
      }
      Fill.square(num5, num6, 1.8f + Mathf.absin(Time.time, 2.2f, 1.1f), this.rotation + 45f);
      Draw.reset();
      Draw.z(115f);
    }

    [LineNumberTable(new byte[] {162, 178, 114, 156, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void landed()
    {
      if ((double) this.type.landShake > 0.0)
        Effect.shake(this.type.landShake, this.type.landShake, (Position) this);
      this.type.landed((Unit) this);
    }

    [LineNumberTable(new byte[] {162, 191, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override Block blockOn()
    {
      Tile tile = this.tileOn();
      return tile == null ? Blocks.air : tile.block();
    }

    [LineNumberTable(new byte[] {162, 196, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void clearStatuses() => this.statuses.clear();

    [LineNumberTable(new byte[] {162, 212, 127, 0})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void hitbox(Rect rect) => rect.setCentered(this.x, this.y, this.hitSize, this.hitSize);

    [LineNumberTable(new byte[] {162, 217, 103, 108, 108, 108, 108, 108, 108, 108, 108, 108, 108, 113, 112, 55, 166, 108, 108, 108, 108, 113, 112, 55, 166, 108, 113, 108, 108, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void write(Writes write)
    {
      write.s(1);
      write.f(this.ammo);
      write.f(this.armor);
      write.f(this.baseRotation);
      TypeIO.writeController(write, this.controller);
      write.f(this.elevation);
      write.d(this.flag);
      write.f(this.health);
      write.@bool(this.isShooting);
      TypeIO.writeTile(write, this.mineTile);
      TypeIO.writeMounts(write, this.mounts);
      write.i(this.plans.size);
      for (int index = 0; index < this.plans.size; ++index)
        TypeIO.writeRequest(write, (BuildPlan) this.plans.get(index));
      write.f(this.rotation);
      write.f(this.shield);
      write.@bool(this.spawnedByCore);
      TypeIO.writeItems(write, this.stack);
      write.i(this.statuses.size);
      for (int index = 0; index < this.statuses.size; ++index)
        TypeIO.writeStatuse(write, (StatusEntry) this.statuses.get(index));
      TypeIO.writeTeam(write, this.team);
      write.s((int) this.type.__\u003C\u003Eid);
      write.@bool(this.updateBuilding);
      write.f(this.x);
      write.f(this.y);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool collides(Hitboxc other) => true;

    [Signature("<T:Ljava/lang/Object;>()TT;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override object @as() => (object) this;

    [LineNumberTable(new byte[] {163, 65, 106, 107, 107, 107, 139, 167, 166, 119, 127, 16, 102, 183})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void add()
    {
      if (this.added)
        return;
      Groups.all.add((Entityc) this);
      Groups.unit.add((Entityc) this);
      Groups.sync.add((Entityc) this);
      Groups.draw.add((Entityc) this);
      this.added = true;
      this.updateLastPosition();
      this.team.data().updateCount(this.type, 1);
      if (this.count() <= this.cap() || this.spawnedByCore || (this.dead || Vars.state.rules.editor))
        return;
      Call.unitCapDeath((Unit) this);
      this.team.data().updateCount(this.type, -1);
    }

    [LineNumberTable(988)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool isCounted() => this.type.isCounted;

    [LineNumberTable(new byte[] {163, 110, 116, 127, 25, 127, 43})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string getControllerName()
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

    [LineNumberTable(new byte[] {163, 117, 109, 109, 109, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void writeSyncManual(FloatBuffer buffer)
    {
      buffer.put(this.baseRotation);
      buffer.put(this.rotation);
      buffer.put(this.x);
      buffer.put(this.y);
    }

    [LineNumberTable(1006)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override int maxAccepted(Item item) => !object.ReferenceEquals((object) this.stack.item, (object) item) && this.stack.amount > 0 ? 0 : this.itemCapacity() - this.stack.amount;

    [LineNumberTable(new byte[] {163, 128, 127, 1})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override double sense(Content content) => object.ReferenceEquals((object) content, (object) this.stack().item) ? (double) this.stack().amount : double.NaN;

    [LineNumberTable(1025)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool cheating() => this.team.rules().cheat;

    [LineNumberTable(new byte[] {163, 147, 109, 144, 102, 102, 102, 102, 127, 8, 127, 6, 121, 121, 121, 102, 101, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override Color statusColor()
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

    [Signature("<T::Lmindustry/gen/Entityc;>()TT;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override Entityc self() => (Entityc) this;

    [LineNumberTable(new byte[] {163, 186, 121, 117})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void hitboxTile(Rect rect)
    {
      float num = Math.min(this.hitSize * 0.66f, 7.9f);
      rect.setCentered(this.x, this.y, num, num);
    }

    [LineNumberTable(new byte[] {163, 203, 104, 110, 104, 110, 104, 141})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override float prefRotation()
    {
      if (this.activelyBuilding())
        return this.angleTo((Position) this.buildPlan());
      if (this.mineTile != null)
        return this.angleTo((Position) this.mineTile);
      return this.moving() ? this.vel().angle() : this.rotation;
    }

    [LineNumberTable(1101)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool canMine() => (double) this.type.mineSpeed > 0.0 && this.type.mineTier >= 0;

    [LineNumberTable(new byte[] {164, 11, 127, 11, 191, 12, 186, 116, 104, 127, 41, 111, 135, 105, 105, 105, 103, 127, 5, 105, 116, 116, 122, 122, 114, 159, 0, 109, 112, 100, 110, 221, 167, 122, 184, 104, 127, 51, 123, 101, 127, 35, 166, 110, 103, 112, 107, 109, 127, 1, 120, 159, 41, 127, 2, 107, 127, 42, 127, 19, 127, 4, 127, 32, 106, 159, 29, 103, 171, 103, 255, 7, 69, 104, 127, 1, 105, 127, 9, 127, 9, 127, 12, 127, 12, 124, 124, 127, 46, 120, 127, 35, 141, 117, 112, 110, 127, 21, 127, 1, 127, 2, 219, 127, 23, 105, 185, 127, 74, 127, 13, 148, 127, 9, 127, 12, 127, 12, 127, 8, 127, 10, 107, 108, 156, 127, 160, 125, 127, 13, 110, 115, 248, 19, 235, 114, 104, 117, 148, 107, 127, 50, 103, 114, 99, 114, 122, 127, 1, 127, 6, 103, 102, 147, 119, 122, 122, 122, 122, 122, 122, 121, 148, 165, 108, 127, 13, 115, 109, 113, 171, 110, 127, 5, 104, 130, 127, 22, 127, 38, 127, 7, 127, 12, 121, 159, 54, 133, 120, 107, 112, 118, 159, 21, 115, 127, 16, 114, 159, 65, 127, 1, 104, 166, 104, 104, 121, 105, 141, 110, 173, 108, 109, 109, 108, 166, 116, 139, 109, 134, 120, 198, 121, 135, 104, 127, 3, 107, 215, 124, 198, 103, 117, 135, 159, 12, 120, 126, 127, 10, 109, 108, 110, 122, 127, 78, 135, 101, 104, 109, 110, 131, 127, 19, 108, 109, 168, 104, 105, 104, 107, 123, 112, 127, 14, 127, 37, 127, 25, 100, 159, 11, 136, 127, 19, 159, 0, 108, 133, 127, 59, 108, 133, 119, 121, 136, 127, 25, 133, 105, 159, 40, 159, 45, 122, 174, 104, 110, 104, 104, 191, 32, 140, 118, 127, 39, 127, 14, 107, 104, 223, 21, 127, 9, 124, 114, 112, 159, 5, 121, 102, 173, 220, 127, 3, 191, 4, 119, 127, 15, 127, 15, 127, 33, 159, 33, 104, 127, 7, 159, 7, 127, 51, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void update()
    {
      this.move(this.vel.x * Time.delta, this.vel.y * Time.delta);
      this.vel.scl(Math.max(1f - this.drag * Time.delta, 0.0f));
      this.hitTime -= Time.delta / 9f;
      if (this.walked || Vars.net.client())
      {
        float num = this.deltaLen();
        this.baseRotation = Angles.moveToward(this.baseRotation, this.deltaAngle(), this.type().baseRotateSpeed * Mathf.clamp(num / this.type().speed / Time.delta) * Time.delta);
        this.walkTime += num;
        this.walked = false;
      }
      float f = this.walkExtend(false);
      float num1 = this.walkExtend(true);
      float num2 = num1 % 1f;
      float walkExtension = this.walkExtension;
      if ((double) num2 < (double) walkExtension && (double) (num1 % 2f) > 1.0 && !this.isFlying())
      {
        float y1 = this.hitSize / 2f * (float) -Mathf.sign(f);
        float x1 = this.type.mechStride * 1.35f;
        float x2 = this.x + Angles.trnsx(this.baseRotation, x1, y1);
        float y2 = this.y + Angles.trnsy(this.baseRotation, x1, y1);
        if ((double) this.type.mechStepShake > 0.0)
          Effect.shake(this.type.mechStepShake, this.type.mechStepShake, x2, y2);
        if (this.type.mechStepParticles)
        {
          Tile tile = Vars.world.tileWorld(x2, y2);
          if (tile != null)
          {
            Color mapColor = tile.floor().mapColor;
            Fx.__\u003C\u003EunitLand.at(x2, y2, this.hitSize / 8f, mapColor);
          }
        }
      }
      this.walkExtension = num2;
      this.shieldAlpha -= Time.delta / 15f;
      if ((double) this.shieldAlpha < 0.0)
        this.shieldAlpha = 0.0f;
      Building build1 = this.closestCore();
      if (build1 != null && this.mineTile != null && (this.mineTile.drop() != null && !this.acceptsItem(this.mineTile.drop())) && (this.within((Position) build1, 220f) && !this.offloadImmediately()))
      {
        int amount = build1.acceptStack(this.item(), this.stack().amount, (Teamc) this);
        if (amount > 0)
        {
          Call.transferItemTo((Unit) this, this.item(), amount, this.mineTile.worldx() + Mathf.range(4f), this.mineTile.worldy() + Mathf.range(4f), build1);
          this.clearItem();
        }
      }
      if (!this.validMine(this.mineTile))
      {
        this.mineTile = (Tile) null;
        this.mineTimer = 0.0f;
      }
      else if (this.mining())
      {
        Item obj = this.mineTile.drop();
        this.mineTimer += Time.delta * this.type.mineSpeed;
        if (Mathf.chance(0.06 * (double) Time.delta))
          Fx.__\u003C\u003EpulverizeSmall.at(this.mineTile.worldx() + Mathf.range(4f), this.mineTile.worldy() + Mathf.range(4f), 0.0f, obj.color);
        if ((double) this.mineTimer >= (double) (50f + (float) obj.hardness * 15f))
        {
          this.mineTimer = 0.0f;
          if (Vars.state.rules.sector != null && object.ReferenceEquals((object) this.team(), (object) Vars.state.rules.defaultTeam))
            Vars.state.rules.sector.info.handleProduction(obj, 1);
          if (build1 != null && this.within((Position) build1, 220f) && (build1.acceptStack(obj, 1, (Teamc) this) == 1 && this.offloadImmediately()))
          {
            if (object.ReferenceEquals((object) this.item(), (object) obj) && !Vars.net.client())
              this.addItem(obj);
            Call.transferItemTo((Unit) this, obj, 1, this.mineTile.worldx() + Mathf.range(4f), this.mineTile.worldy() + Mathf.range(4f), build1);
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
        if (!Vars.headless)
          Vars.control.sound.loop(this.type.mineSound, (Position) this, this.type.mineSoundVolume);
      }
      int num3 = this.canShoot() ? 1 : 0;
      WeaponMount[] mounts = this.mounts;
      int length = mounts.Length;
      for (int index = 0; index < length; ++index)
      {
        WeaponMount weaponMount = mounts[index];
        Weapon weapon = weaponMount.__\u003C\u003Eweapon;
        weaponMount.reload = Math.max(weaponMount.reload - Time.delta * this.reloadMultiplier, 0.0f);
        float angle = this.rotation - 90f + (!weapon.rotate ? 0.0f : weaponMount.rotation);
        float num4 = this.x + Angles.trnsx(this.rotation - 90f, weapon.x, weapon.y);
        float num5 = this.y + Angles.trnsy(this.rotation - 90f, weapon.x, weapon.y);
        float x1 = num4 + Angles.trnsx(angle, weapon.shootX, weapon.shootY);
        float y1 = num5 + Angles.trnsy(angle, weapon.shootX, weapon.shootY);
        float num6 = !weapon.rotate ? Angles.angle(x1, y1, weaponMount.aimX, weaponMount.aimY) + (this.rotation - this.angleTo(weaponMount.aimX, weaponMount.aimY)) : angle + 90f;
        if (weapon.continuous && weaponMount.bullet != null)
        {
          if (!weaponMount.bullet.isAdded() || (double) weaponMount.bullet.time >= (double) weaponMount.bullet.lifetime || !object.ReferenceEquals((object) weaponMount.bullet.type, (object) weapon.bullet))
          {
            weaponMount.bullet = (Bullet) null;
          }
          else
          {
            weaponMount.bullet.rotation(angle + 90f);
            weaponMount.bullet.set(x1, y1);
            weaponMount.reload = weapon.reload;
            this.vel.add(Tmp.__\u003C\u003Ev1.trns(this.rotation + 180f, weaponMount.bullet.type.recoil));
            if (!object.ReferenceEquals((object) weapon.shootSound, (object) Sounds.none) && !Vars.headless)
            {
              if (weaponMount.sound == null)
                weaponMount.sound = new SoundLoop(weapon.shootSound, 1f);
              weaponMount.sound.update(this.x, this.y, true);
            }
          }
        }
        else
        {
          weaponMount.heat = Math.max(weaponMount.heat - Time.delta * this.reloadMultiplier / weaponMount.__\u003C\u003Eweapon.cooldownTime, 0.0f);
          if (weaponMount.sound != null)
            weaponMount.sound.update(this.x, this.y, false);
        }
        if (weapon.otherSide != -1 && weapon.alternate && (weaponMount.side == weapon.flipSprite && (double) (weaponMount.reload + Time.delta * this.reloadMultiplier) > (double) (weapon.reload / 2f)) && (double) weaponMount.reload <= (double) (weapon.reload / 2f))
        {
          this.mounts[weapon.otherSide].side = !this.mounts[weapon.otherSide].side;
          weaponMount.side = !weaponMount.side;
        }
        if (weapon.rotate && (weaponMount.rotate || weaponMount.shoot) && num3 != 0)
        {
          float x2 = this.x + Angles.trnsx(this.rotation - 90f, weapon.x, weapon.y);
          float y2 = this.y + Angles.trnsy(this.rotation - 90f, weapon.x, weapon.y);
          weaponMount.targetRotation = Angles.angle(x2, y2, weaponMount.aimX, weaponMount.aimY) - this.rotation;
          weaponMount.rotation = Angles.moveToward(weaponMount.rotation, weaponMount.targetRotation, weapon.rotateSpeed * Time.delta);
        }
        else if (!weapon.rotate)
        {
          weaponMount.rotation = 0.0f;
          weaponMount.targetRotation = this.angleTo(weaponMount.aimX, weaponMount.aimY);
        }
        if (weaponMount.shoot && num3 != 0 && ((double) this.ammo > 0.0 || !Vars.state.rules.unitAmmo || this.team().rules().infiniteAmmo) && ((!weapon.alternate || weaponMount.side == weapon.flipSprite) && ((double) this.vel.len() >= (double) weaponMount.__\u003C\u003Eweapon.minShootVelocity || Vars.net.active() && !this.isLocal())) && (double) weaponMount.reload <= 9.99999974737875E-05 && Angles.within(!weapon.rotate ? this.rotation : weaponMount.rotation, weaponMount.targetRotation, weaponMount.__\u003C\u003Eweapon.shootCone))
        {
          this.shoot(weaponMount, x1, y1, weaponMount.aimX, weaponMount.aimY, num4, num5, num6, Mathf.sign(weapon.x));
          weaponMount.reload = weapon.reload;
          --this.ammo;
          if ((double) this.ammo < 0.0)
            this.ammo = 0.0f;
        }
      }
      Floor floor1 = this.floorOn();
      if (this.isGrounded() && !this.type.hovering)
        this.apply(floor1.status, floor1.statusDuration);
      this.applied.clear();
      MechUnitLegacyPulsar unitLegacyPulsar1 = this;
      MechUnitLegacyPulsar unitLegacyPulsar2 = this;
      MechUnitLegacyPulsar unitLegacyPulsar3 = this;
      MechUnitLegacyPulsar unitLegacyPulsar4 = this;
      MechUnitLegacyPulsar unitLegacyPulsar5 = this;
      float num7 = 1f;
      double num8 = (double) num7;
      this.dragMultiplier = num7;
      float num9 = (float) num8;
      double num10 = (double) num9;
      this.buildSpeedMultiplier = num9;
      float num11 = (float) num10;
      double num12 = (double) num11;
      this.reloadMultiplier = num11;
      float num13 = (float) num12;
      double num14 = (double) num13;
      this.healthMultiplier = num13;
      float num15 = (float) num14;
      double num16 = (double) num15;
      this.damageMultiplier = num15;
      this.speedMultiplier = (float) num16;
      this.disarmed = false;
      if (!this.statuses.isEmpty())
      {
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
            statusEntry.effect.update((Unit) this, statusEntry.time);
          }
        }
      }
      this.type.update((Unit) this);
      if (Vars.state.rules.unitAmmo && (double) this.ammo < (double) ((float) this.type.ammoCapacity - 0.0001f))
      {
        this.resupplyTime += Time.delta;
        if ((double) this.resupplyTime > 10.0)
        {
          this.type.ammoType.resupply((Unit) this);
          this.resupplyTime = 0.0f;
        }
      }
      if (this.abilities.size > 0)
      {
        Iterator iterator = this.abilities.iterator();
        while (iterator.hasNext())
          ((Ability) iterator.next()).update((Unit) this);
      }
      this.drag = this.type.drag * (!this.isGrounded() ? 1f : this.floorOn().dragMultiplier) * this.dragMultiplier;
      if (!object.ReferenceEquals((object) this.team, (object) Vars.state.rules.waveTeam) && Vars.state.hasSpawns() && (!Vars.net.client() || this.isLocal()))
      {
        float num4 = Vars.state.rules.dropZoneRadius + this.hitSize / 2f + 1f;
        Iterator iterator = Vars.spawner.getSpawns().iterator();
        while (iterator.hasNext())
        {
          Tile tile = (Tile) iterator.next();
          if (this.within(tile.worldx(), tile.worldy(), num4))
            this.vel().add(Tmp.__\u003C\u003Ev1.set((Position) this).sub(tile.worldx(), tile.worldy()).setLength(1.1f - this.dst((Position) tile) / num4).scl(0.45f * Time.delta));
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
      Floor floor2 = this.floorOn();
      if (tile1 != null && this.isGrounded() && !this.type.hovering)
      {
        if (tile1.build != null)
          tile1.build.unitOn((Unit) this);
        if ((double) floor2.damageTaken > 0.0)
          this.damageContinuous(floor2.damageTaken);
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
      if (this.spawnedByCore && !this.isPlayer() && !this.dead)
        Call.unitDespawn((Unit) this);
      if (this.controlling.isEmpty() && !Vars.net.client())
        this.formation = (Formation) null;
      if (this.formation != null)
      {
        this.formation.anchor.set(this.x, this.y, 0.0f);
        this.formation.updateSlots();
        this.controlling.removeAll((Boolf) new MechUnitLegacyPulsar.__\u003C\u003EAnon11(this));
      }
      if (Vars.net.client() && !this.isLocal() || this.isRemote())
        this.interpolate();
      if (!Vars.headless)
      {
        if (this.lastActive != null && (double) this.buildAlpha <= 0.00999999977648258)
          this.lastActive = (BuildPlan) null;
        this.buildAlpha = Mathf.lerpDelta(this.buildAlpha, !this.activelyBuilding() ? 0.0f : 1f, 0.15f);
      }
      if (this.updateBuilding && this.canBuild())
      {
        float num4 = !Vars.state.rules.infiniteResources ? 220f : float.MaxValue;
        int num5 = Vars.state.rules.infiniteResources || this.team().rules().infiniteResources ? 1 : 0;
        Iterator iterator = this.plans.iterator();
        while (iterator.hasNext())
        {
          BuildPlan buildPlan = (BuildPlan) iterator.next();
          Tile tile2 = Vars.world.tile(buildPlan.x, buildPlan.y);
          if (tile2 == null || buildPlan.breaking && object.ReferenceEquals((object) tile2.block(), (object) Blocks.air) || !buildPlan.breaking && (tile2.build != null && tile2.build.rotation == buildPlan.rotation || !buildPlan.block.rotate) && object.ReferenceEquals((object) tile2.block(), (object) buildPlan.block))
            iterator.remove();
        }
        Building core = this.core();
        if (this.buildPlan() != null)
        {
          if (this.plans.size > 1)
          {
            BuildPlan request;
            for (int index = 0; (!this.within((Position) (request = this.buildPlan()).tile(), num4) || this.shouldSkip(request, core)) && index < this.plans.size; ++index)
            {
              this.plans.removeFirst();
              this.plans.addLast((object) request);
            }
          }
          BuildPlan buildPlan = this.buildPlan();
          Tile tile2 = buildPlan.tile();
          this.lastActive = buildPlan;
          this.buildAlpha = 1f;
          if (buildPlan.breaking)
            this.lastSize = tile2.block().size;
          if (this.within((Position) tile2, num4))
          {
            Building build2 = tile2.build;
            ConstructBlock.ConstructBuild constructBuild1;
            if (!(build2 is ConstructBlock.ConstructBuild) || !object.ReferenceEquals((object) (constructBuild1 = (ConstructBlock.ConstructBuild) build2), (object) (ConstructBlock.ConstructBuild) build2))
            {
              if (!buildPlan.initialized && !buildPlan.breaking && Build.validPlace(buildPlan.block, this.team, buildPlan.x, buildPlan.y, buildPlan.rotation))
              {
                if ((num5 != 0 || buildPlan.isRotation(this.team) || !Structs.contains((object[]) buildPlan.block.requirements, (Boolf) new MechUnitLegacyPulsar.__\u003C\u003EAnon12(core)) ? 1 : 0) != 0)
                  Call.beginPlace((Unit) this, buildPlan.block, this.team, buildPlan.x, buildPlan.y, buildPlan.rotation);
                else
                  buildPlan.stuck = true;
              }
              else if (!buildPlan.initialized && buildPlan.breaking && Build.validBreak(this.team, buildPlan.x, buildPlan.y))
              {
                Call.beginBreak((Unit) this, this.team, buildPlan.x, buildPlan.y);
              }
              else
              {
                this.plans.removeFirst();
                goto label_136;
              }
            }
            else if (!object.ReferenceEquals((object) tile2.team(), (object) this.team) && !object.ReferenceEquals((object) tile2.team(), (object) Team.__\u003C\u003Ederelict) || !buildPlan.breaking && (!object.ReferenceEquals((object) constructBuild1.cblock, (object) buildPlan.block) || !object.ReferenceEquals((object) constructBuild1.tile, (object) buildPlan.tile())))
            {
              this.plans.removeFirst();
              goto label_136;
            }
            if (tile2.build is ConstructBlock.ConstructBuild && !buildPlan.initialized)
            {
              Core.app.post((Runnable) new MechUnitLegacyPulsar.__\u003C\u003EAnon13(this, tile2, buildPlan));
              buildPlan.initialized = true;
            }
            if (core != null || num5 != 0)
            {
              Building build3 = tile2.build;
              ConstructBlock.ConstructBuild constructBuild2;
              if (build3 is ConstructBlock.ConstructBuild && object.ReferenceEquals((object) (constructBuild2 = (ConstructBlock.ConstructBuild) build3), (object) (ConstructBlock.ConstructBuild) build3))
              {
                if (buildPlan.breaking)
                  constructBuild2.deconstruct((Unit) this, core, 1f / constructBuild2.buildCost * Time.delta * this.type.buildSpeed * this.buildSpeedMultiplier * Vars.state.rules.buildSpeedMultiplier);
                else
                  constructBuild2.construct((Unit) this, core, 1f / constructBuild2.buildCost * Time.delta * this.type.buildSpeed * this.buildSpeedMultiplier * Vars.state.rules.buildSpeedMultiplier, buildPlan.config);
                buildPlan.stuck = Mathf.equal(buildPlan.progress, constructBuild2.progress);
                buildPlan.progress = constructBuild2.progress;
              }
            }
          }
        }
      }
label_136:
      Floor floor3 = this.floorOn();
      if (this.isFlying() != this.wasFlying)
      {
        if (this.wasFlying && this.tileOn() != null)
          Fx.__\u003C\u003EunitLand.at(this.x, this.y, !this.floorOn().isLiquid ? 0.5f : 1f, this.tileOn().floor().mapColor);
        this.wasFlying = this.isFlying();
      }
      if (!this.hovering && this.isGrounded())
      {
        MechUnitLegacyPulsar unitLegacyPulsar6 = this;
        float num4 = unitLegacyPulsar6.splashTimer + Mathf.dst(this.deltaX(), this.deltaY());
        MechUnitLegacyPulsar unitLegacyPulsar7 = unitLegacyPulsar6;
        double num5 = (double) num4;
        unitLegacyPulsar7.splashTimer = num4;
        double num6 = (double) (7f + this.hitSize() / 8f);
        if (num5 >= num6)
        {
          floor3.walkEffect.at(this.x, this.y, this.hitSize() / 8f, floor3.mapColor);
          this.splashTimer = 0.0f;
          if (!(this is WaterMovec))
            floor3.walkSound.at(this.x, this.y, Mathf.random(floor3.walkSoundPitchMin, floor3.walkSoundPitchMax), floor3.walkSoundVolume);
        }
      }
      if (this.canDrown() && floor3.isLiquid && (double) floor3.drownTime > 0.0)
      {
        this.drownTime += Time.delta / floor3.drownTime;
        this.drownTime = Mathf.clamp(this.drownTime);
        if (Mathf.chanceDelta(0.0500000007450581))
          floor3.drownUpdateEffect.at(this.x, this.y, 1f, floor3.mapColor);
        if ((double) this.drownTime >= 0.999000012874603 && !Vars.net.client())
        {
          this.kill();
          Events.fire((object) new EventType.UnitDrownEvent((Unit) this));
        }
      }
      else
        this.drownTime = Mathf.lerpDelta(this.drownTime, 0.0f, 0.03f);
      this.stack.amount = Mathf.clamp(this.stack.amount, 0, this.itemCapacity());
      this.itemTime = Mathf.lerpDelta(this.itemTime, (float) Mathf.num(this.hasItem()), 0.05f);
      if (!Vars.net.client() || this.isLocal())
      {
        if ((double) this.x < 0.0)
          this.vel.x += (float) (-(double) this.x / 180.0);
        if ((double) this.y < 0.0)
          this.vel.y += (float) (-(double) this.y / 180.0);
        if ((double) this.x > (double) Vars.world.unitWidth())
          this.vel.x -= (this.x - (float) Vars.world.unitWidth()) / 180f;
        if ((double) this.y > (double) Vars.world.unitHeight())
          this.vel.y -= (this.y - (float) Vars.world.unitHeight()) / 180f;
      }
      if (this.isGrounded())
      {
        this.x = Mathf.clamp(this.x, 0.0f, (float) (Vars.world.width() * 8 - 8));
        this.y = Mathf.clamp(this.y, 0.0f, (float) (Vars.world.height() * 8 - 8));
      }
      if ((double) this.x >= -500.0 && (double) this.y >= -500.0 && ((double) this.x < (double) ((float) (Vars.world.width() * 8) + 500f) && (double) this.y < (double) ((float) (Vars.world.height() * 8) + 500f)))
        return;
      this.kill();
    }

    [LineNumberTable(new byte[] {165, 133, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void apply(StatusEffect effect) => this.apply(effect, 1f);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool isNull() => false;

    [LineNumberTable(1552)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool checkTarget(bool targetAir, bool targetGround)
    {
      int num1 = targetGround ? 1 : 0;
      int num2 = targetAir ? 1 : 0;
      return this.isGrounded() && num1 != 0 || this.isFlying() && num2 != 0;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void collision(Hitboxc other, float x, float y)
    {
    }

    [LineNumberTable(new byte[] {165, 180, 109, 199, 159, 2})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void approach(Vec2 vector)
    {
      if (!vector.isZero(1f / 1000f))
        this.walked = true;
      this.vel.approachDelta(vector, this.type.accel * this.realSpeed());
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override UnitController controller() => this.controller;

    [LineNumberTable(1588)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool hasWeapons() => this.type.hasWeapons();

    [LineNumberTable(new byte[] {165, 211, 105, 107, 108, 108, 108, 108, 108, 108, 108, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void snapSync()
    {
      this.updateSpacing = 16L;
      this.lastUpdated = Time.millis();
      this.baseRotation_LAST_ = this.baseRotation_TARGET_;
      this.baseRotation = this.baseRotation_TARGET_;
      this.rotation_LAST_ = this.rotation_TARGET_;
      this.rotation = this.rotation_TARGET_;
      this.x_LAST_ = this.x_TARGET_;
      this.x = this.x_TARGET_;
      this.y_LAST_ = this.y_TARGET_;
      this.y = this.y_TARGET_;
    }

    [LineNumberTable(new byte[] {165, 229, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void commandNearby(FormationPattern pattern) => this.commandNearby(pattern, (Boolf) new MechUnitLegacyPulsar.__\u003C\u003EAnon14());

    [Signature("<T:Ljava/lang/Object;>(Larc/func/Cons<TT;>;)TT;")]
    [LineNumberTable(new byte[] {166, 0, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override object with(Cons cons)
    {
      cons.get((object) this);
      return (object) this;
    }

    [LineNumberTable(new byte[] {157, 236, 162, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void controlWeapons(bool rotateShoot)
    {
      int num = rotateShoot ? 1 : 0;
      this.controlWeapons(num != 0, num != 0);
    }

    [LineNumberTable(new byte[] {166, 69, 106, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void aimLook(float x, float y)
    {
      this.aim(x, y);
      this.lookAt(x, y);
    }

    [LineNumberTable(new byte[] {166, 74, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void trns(Position pos) => this.trns(pos.getX(), pos.getY());

    [LineNumberTable(new byte[] {166, 78, 114, 104, 104, 152})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void impulseNet(Vec2 v)
    {
      this.impulse(v.x, v.y);
      if (!this.isRemote())
        return;
      float num = this.mass();
      this.move(v.x / num, v.y / num);
    }

    [LineNumberTable(1740)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override float ammof() => this.ammo / (float) this.type.ammoCapacity;

    [LineNumberTable(new byte[] {166, 94, 108, 108, 108, 108, 108, 108, 108, 108, 108, 108, 113, 112, 55, 166, 108, 108, 108, 108, 113, 112, 55, 166, 108, 113, 108, 108, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void writeSync(Writes write)
    {
      write.f(this.ammo);
      write.f(this.armor);
      write.f(this.baseRotation);
      TypeIO.writeController(write, this.controller);
      write.f(this.elevation);
      write.d(this.flag);
      write.f(this.health);
      write.@bool(this.isShooting);
      TypeIO.writeTile(write, this.mineTile);
      TypeIO.writeMounts(write, this.mounts);
      write.i(this.plans.size);
      for (int index = 0; index < this.plans.size; ++index)
        TypeIO.writeRequest(write, (BuildPlan) this.plans.get(index));
      write.f(this.rotation);
      write.f(this.shield);
      write.@bool(this.spawnedByCore);
      TypeIO.writeItems(write, this.stack);
      write.i(this.statuses.size);
      for (int index = 0; index < this.statuses.size; ++index)
        TypeIO.writeStatuse(write, (StatusEntry) this.statuses.get(index));
      TypeIO.writeTeam(write, this.team);
      write.s((int) this.type.__\u003C\u003Eid);
      write.@bool(this.updateBuilding);
      write.f(this.x);
      write.f(this.y);
    }

    [LineNumberTable(new byte[] {166, 128, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void impulse(Vec2 v) => this.impulse(v.x, v.y);

    [LineNumberTable(new byte[] {166, 161, 123, 107, 108, 109, 108, 109, 108, 109, 108, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void readSyncManual(FloatBuffer buffer)
    {
      if (this.lastUpdated != 0L)
        this.updateSpacing = Time.timeSinceMillis(this.lastUpdated);
      this.lastUpdated = Time.millis();
      this.baseRotation_LAST_ = this.baseRotation;
      this.baseRotation_TARGET_ = buffer.get();
      this.rotation_LAST_ = this.rotation;
      this.rotation_TARGET_ = buffer.get();
      this.x_LAST_ = this.x;
      this.x_TARGET_ = buffer.get();
      this.y_LAST_ = this.y;
      this.y_TARGET_ = buffer.get();
    }

    [LineNumberTable(new byte[] {157, 198, 66, 121, 100, 141})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void removeBuild(int x, int y, bool breaking)
    {
      int index = this.plans.indexOf((Boolf) new MechUnitLegacyPulsar.__\u003C\u003EAnon16(breaking, x, y));
      if (index == -1)
        return;
      this.plans.removeIndex(index);
    }

    [LineNumberTable(new byte[] {166, 185, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void display(Table table) => this.type.display((Unit) this, table);

    [LineNumberTable(new byte[] {166, 222, 123, 107, 103, 109, 109, 99, 108, 143, 104, 108, 140, 114, 99, 143, 136, 110, 109, 108, 99, 142, 135, 99, 148, 135, 99, 103, 107, 102, 103, 15, 198, 98, 103, 102, 39, 198, 99, 108, 143, 104, 108, 140, 109, 108, 114, 103, 108, 102, 104, 17, 198, 108, 127, 1, 99, 142, 135, 99, 108, 143, 104, 108, 140, 99, 108, 143, 104, 108, 140, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void readSync(Reads read)
    {
      if (this.lastUpdated != 0L)
        this.updateSpacing = Time.timeSinceMillis(this.lastUpdated);
      this.lastUpdated = Time.millis();
      int num1 = this.isLocal() ? 1 : 0;
      this.ammo = read.f();
      this.armor = read.f();
      if (num1 == 0)
      {
        this.baseRotation_LAST_ = this.baseRotation;
        this.baseRotation_TARGET_ = read.f();
      }
      else
      {
        double num2 = (double) read.f();
        this.baseRotation_LAST_ = this.baseRotation;
        this.baseRotation_TARGET_ = this.baseRotation;
      }
      this.controller = TypeIO.readController(read, this.controller);
      if (num1 == 0)
      {
        this.elevation = read.f();
      }
      else
      {
        double num3 = (double) read.f();
      }
      this.flag = read.d();
      this.health = read.f();
      this.isShooting = read.@bool();
      if (num1 == 0)
        this.mineTile = TypeIO.readTile(read);
      else
        TypeIO.readTile(read);
      if (num1 == 0)
        this.mounts = TypeIO.readMounts(read, this.mounts);
      else
        TypeIO.readMounts(read);
      if (num1 == 0)
      {
        int num2 = read.i();
        this.plans.clear();
        for (int index = 0; index < num2; ++index)
        {
          BuildPlan buildPlan = TypeIO.readRequest(read);
          if (buildPlan != null)
            this.plans.add((object) buildPlan);
        }
      }
      else
      {
        int num2 = read.i();
        for (int index = 0; index < num2; ++index)
          TypeIO.readRequest(read);
      }
      if (num1 == 0)
      {
        this.rotation_LAST_ = this.rotation;
        this.rotation_TARGET_ = read.f();
      }
      else
      {
        double num2 = (double) read.f();
        this.rotation_LAST_ = this.rotation;
        this.rotation_TARGET_ = this.rotation;
      }
      this.shield = read.f();
      this.spawnedByCore = read.@bool();
      this.stack = TypeIO.readItems(read, this.stack);
      int num4 = read.i();
      this.statuses.clear();
      for (int index = 0; index < num4; ++index)
      {
        StatusEntry statusEntry = TypeIO.readStatuse(read);
        if (statusEntry != null)
          this.statuses.add((object) statusEntry);
      }
      this.team = TypeIO.readTeam(read);
      this.type = (UnitType) Vars.content.getByID(ContentType.__\u003C\u003Eunit, (int) read.s());
      if (num1 == 0)
        this.updateBuilding = read.@bool();
      else
        read.@bool();
      if (num1 == 0)
      {
        this.x_LAST_ = this.x;
        this.x_TARGET_ = read.f();
      }
      else
      {
        double num2 = (double) read.f();
        this.x_LAST_ = this.x;
        this.x_TARGET_ = this.x;
      }
      if (num1 == 0)
      {
        this.y_LAST_ = this.y;
        this.y_TARGET_ = read.f();
      }
      else
      {
        double num2 = (double) read.f();
        this.y_LAST_ = this.y;
        this.y_TARGET_ = this.y;
      }
      this.afterSync();
    }

    [LineNumberTable(new byte[] {167, 55, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void damagePierce(float amount) => this.damagePierce(amount, true);

    [LineNumberTable(new byte[] {167, 64, 247, 71})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void unapply(StatusEffect effect) => this.statuses.remove((Boolf) new MechUnitLegacyPulsar.__\u003C\u003EAnon17(effect));

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void heal()
    {
      this.dead = false;
      this.health = this.maxHealth;
    }

    [LineNumberTable(new byte[] {167, 101, 127, 0})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void damageContinuousPierce(float amount) => this.damagePierce(amount * Time.delta, (double) this.hitTime <= -11.0);

    [Signature("(Larc/func/Cons<Lmindustry/gen/Unit;>;)V")]
    [LineNumberTable(new byte[] {167, 123, 103, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void eachGroup(Cons cons)
    {
      cons.get((object) this);
      this.controlling().each(cons);
    }

    [LineNumberTable(2034)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool isBoss() => this.hasEffect(StatusEffects.boss);

    [LineNumberTable(2046)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool isAI() => this.controller is AIController;

    [LineNumberTable(2050)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static MechUnitLegacyPulsar create() => new MechUnitLegacyPulsar();

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override int classId() => 19;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override float rotation() => this.rotation;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void rotation(float rotation) => this.rotation = rotation;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void team(Team team) => this.team = team;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override float health() => this.health;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void health(float health) => this.health = health;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override float hitTime() => this.hitTime;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void hitTime(float hitTime) => this.hitTime = hitTime;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override float maxHealth() => this.maxHealth;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void maxHealth(float maxHealth) => this.maxHealth = maxHealth;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool dead() => this.dead;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void dead(bool dead) => this.dead = dead;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float baseRotation() => this.baseRotation;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void baseRotation(float baseRotation) => this.baseRotation = baseRotation;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float walkTime() => this.walkTime;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void walkTime(float walkTime) => this.walkTime = walkTime;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float walkExtension() => this.walkExtension;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void walkExtension(float walkExtension) => this.walkExtension = walkExtension;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override float shield() => this.shield;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void shield(float shield) => this.shield = shield;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override float armor() => this.armor;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void armor(float armor) => this.armor = armor;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override float shieldAlpha() => this.shieldAlpha;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void shieldAlpha(float shieldAlpha) => this.shieldAlpha = shieldAlpha;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override float mineTimer() => this.mineTimer;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void mineTimer(float mineTimer) => this.mineTimer = mineTimer;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override Tile mineTile() => this.mineTile;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void mineTile(Tile mineTile) => this.mineTile = mineTile;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override float x() => this.x;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void x(float x) => this.x = x;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override float y() => this.y;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void y(float y) => this.y = y;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void mounts(WeaponMount[] mounts) => this.mounts = mounts;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool isRotate() => this.isRotate;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void aimX(float aimX) => this.aimX = aimX;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void aimY(float aimY) => this.aimY = aimY;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void isShooting(bool isShooting) => this.isShooting = isShooting;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override float ammo() => this.ammo;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void ammo(float ammo) => this.ammo = ammo;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void id(int id) => this.id = id;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override float damageMultiplier() => this.damageMultiplier;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override float healthMultiplier() => this.healthMultiplier;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override float reloadMultiplier() => this.reloadMultiplier;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override float buildSpeedMultiplier() => this.buildSpeedMultiplier;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override float dragMultiplier() => this.dragMultiplier;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool disarmed() => this.disarmed;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override float lastX() => this.lastX;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void lastX(float lastX) => this.lastX = lastX;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override float lastY() => this.lastY;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void lastY(float lastY) => this.lastY = lastY;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void deltaX(float deltaX) => this.deltaX = deltaX;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void deltaY(float deltaY) => this.deltaY = deltaY;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void hitSize(float hitSize) => this.hitSize = hitSize;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void type(UnitType type) => this.type = type;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool spawnedByCore() => this.spawnedByCore;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void spawnedByCore(bool spawnedByCore) => this.spawnedByCore = spawnedByCore;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override double flag() => this.flag;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void flag(double flag) => this.flag = flag;

    [Signature("()Larc/struct/Seq<Lmindustry/entities/abilities/Ability;>;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override Seq abilities() => this.abilities;

    [Signature("(Larc/struct/Seq<Lmindustry/entities/abilities/Ability;>;)V")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void abilities(Seq abilities) => this.abilities = abilities;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override Formation formation() => this.formation;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void formation(Formation formation) => this.formation = formation;

    [Signature("(Larc/struct/Seq<Lmindustry/gen/Unit;>;)V")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void controlling(Seq controlling) => this.controlling = controlling;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override float minFormationSpeed() => this.minFormationSpeed;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void minFormationSpeed(float minFormationSpeed) => this.minFormationSpeed = minFormationSpeed;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override PhysicsProcess.PhysicRef physref() => this.physref;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void physref(PhysicsProcess.PhysicRef physref) => this.physref = physref;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override long lastUpdated() => this.lastUpdated;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void lastUpdated(long lastUpdated) => this.lastUpdated = lastUpdated;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override long updateSpacing() => this.updateSpacing;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void updateSpacing(long updateSpacing) => this.updateSpacing = updateSpacing;

    [Signature("()Larc/struct/Queue<Lmindustry/entities/units/BuildPlan;>;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override Queue plans() => this.plans;

    [Signature("(Larc/struct/Queue<Lmindustry/entities/units/BuildPlan;>;)V")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void plans(Queue plans) => this.plans = plans;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool updateBuilding() => this.updateBuilding;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void updateBuilding(bool updateBuilding) => this.updateBuilding = updateBuilding;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override float elevation() => this.elevation;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void elevation(float elevation) => this.elevation = elevation;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool hovering() => this.hovering;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void hovering(bool hovering) => this.hovering = hovering;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override float drownTime() => this.drownTime;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void drownTime(float drownTime) => this.drownTime = drownTime;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override float splashTimer() => this.splashTimer;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void splashTimer(float splashTimer) => this.splashTimer = splashTimer;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override float drag() => this.drag;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void drag(float drag) => this.drag = drag;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void stack(ItemStack stack) => this.stack = stack;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override float itemTime() => this.itemTime;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void itemTime(float itemTime) => this.itemTime = itemTime;

    [LineNumberTable(new byte[] {159, 99, 173, 134, 138, 138, 159, 12, 138})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static MechUnitLegacyPulsar()
    {
      if (ByteCodeHelper.isAlreadyInited("mindustry.gen.MechUnitLegacyPulsar"))
        return;
      MechUnitLegacyPulsar.sequenceNum = 0;
      MechUnitLegacyPulsar.__\u003C\u003Emembers = new Seq();
      MechUnitLegacyPulsar.__\u003C\u003Eunits = new Seq();
      MechUnitLegacyPulsar.__\u003C\u003Evecs = new Vec2[4]
      {
        new Vec2(),
        new Vec2(),
        new Vec2(),
        new Vec2()
      };
      MechUnitLegacyPulsar.__\u003C\u003Etmp1 = new Vec2();
      MechUnitLegacyPulsar.__\u003C\u003Etmp2 = new Vec2();
    }

    [HideFromJava]
    public override float dst2([In] Position obj0) => Position.\u003Cdefault\u003Edst2((Position) this, obj0);

    [HideFromJava]
    public override float dst([In] float obj0, [In] float obj1) => Position.\u003Cdefault\u003Edst((Position) this, obj0, obj1);

    [HideFromJava]
    public override float dst2([In] float obj0, [In] float obj1) => Position.\u003Cdefault\u003Edst2((Position) this, obj0, obj1);

    [Modifiers]
    public static Seq members
    {
      [HideFromJava] get => MechUnitLegacyPulsar.__\u003C\u003Emembers;
    }

    [Modifiers]
    public static Seq units
    {
      [HideFromJava] get => MechUnitLegacyPulsar.__\u003C\u003Eunits;
    }

    [Modifiers]
    public static Vec2[] vecs
    {
      [HideFromJava] get => MechUnitLegacyPulsar.__\u003C\u003Evecs;
    }

    [Modifiers]
    public static Vec2 tmp1
    {
      [HideFromJava] get => MechUnitLegacyPulsar.__\u003C\u003Etmp1;
    }

    [Modifiers]
    public static Vec2 tmp2
    {
      [HideFromJava] get => MechUnitLegacyPulsar.__\u003C\u003Etmp2;
    }

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

      [LineNumberTable(488)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static \u0031()
      {
        if (ByteCodeHelper.isAlreadyInited("mindustry.gen.MechUnitLegacyPulsar$1"))
          return;
        MechUnitLegacyPulsar.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess = new int[LAccess.values().Length];
        try
        {
          MechUnitLegacyPulsar.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess[LAccess.__\u003C\u003Etype.ordinal()] = 1;
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
          MechUnitLegacyPulsar.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess[LAccess.__\u003C\u003Ename.ordinal()] = 2;
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
          MechUnitLegacyPulsar.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess[LAccess.__\u003C\u003EfirstItem.ordinal()] = 3;
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
          MechUnitLegacyPulsar.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess[LAccess.__\u003C\u003Econtroller.ordinal()] = 4;
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
          MechUnitLegacyPulsar.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess[LAccess.__\u003C\u003EpayloadType.ordinal()] = 5;
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
          MechUnitLegacyPulsar.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess[LAccess.__\u003C\u003EtotalItems.ordinal()] = 6;
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
          MechUnitLegacyPulsar.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess[LAccess.__\u003C\u003EitemCapacity.ordinal()] = 7;
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
          MechUnitLegacyPulsar.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess[LAccess.__\u003C\u003Erotation.ordinal()] = 8;
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
          MechUnitLegacyPulsar.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess[LAccess.__\u003C\u003Ehealth.ordinal()] = 9;
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
          MechUnitLegacyPulsar.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess[LAccess.__\u003C\u003EmaxHealth.ordinal()] = 10;
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
          MechUnitLegacyPulsar.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess[LAccess.__\u003C\u003Eammo.ordinal()] = 11;
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
          MechUnitLegacyPulsar.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess[LAccess.__\u003C\u003EammoCapacity.ordinal()] = 12;
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
          MechUnitLegacyPulsar.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess[LAccess.__\u003C\u003Ex.ordinal()] = 13;
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
          MechUnitLegacyPulsar.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess[LAccess.__\u003C\u003Ey.ordinal()] = 14;
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
          MechUnitLegacyPulsar.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess[LAccess.__\u003C\u003Edead.ordinal()] = 15;
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
          MechUnitLegacyPulsar.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess[LAccess.__\u003C\u003Eteam.ordinal()] = 16;
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
          MechUnitLegacyPulsar.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess[LAccess.__\u003C\u003Eshooting.ordinal()] = 17;
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
          MechUnitLegacyPulsar.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess[LAccess.__\u003C\u003Eboosting.ordinal()] = 18;
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
          MechUnitLegacyPulsar.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess[LAccess.__\u003C\u003Erange.ordinal()] = 19;
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
          MechUnitLegacyPulsar.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess[LAccess.__\u003C\u003EshootX.ordinal()] = 20;
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
          MechUnitLegacyPulsar.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess[LAccess.__\u003C\u003EshootY.ordinal()] = 21;
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
          MechUnitLegacyPulsar.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess[LAccess.__\u003C\u003Emining.ordinal()] = 22;
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
          MechUnitLegacyPulsar.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess[LAccess.__\u003C\u003EmineX.ordinal()] = 23;
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
          MechUnitLegacyPulsar.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess[LAccess.__\u003C\u003EmineY.ordinal()] = 24;
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
          MechUnitLegacyPulsar.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess[LAccess.__\u003C\u003Eflag.ordinal()] = 25;
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
          MechUnitLegacyPulsar.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess[LAccess.__\u003C\u003Econtrolled.ordinal()] = 26;
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
          MechUnitLegacyPulsar.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess[LAccess.__\u003C\u003Ecommanded.ordinal()] = 27;
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
          MechUnitLegacyPulsar.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess[LAccess.__\u003C\u003EpayloadCount.ordinal()] = 28;
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
          MechUnitLegacyPulsar.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess[LAccess.__\u003C\u003Esize.ordinal()] = 29;
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
    private sealed class __\u003C\u003EAnon0 : Boolf
    {
      private readonly MechUnitLegacyPulsar arg\u00241;

      internal __\u003C\u003EAnon0([In] MechUnitLegacyPulsar obj0) => this.arg\u00241 = obj0;

      public bool get([In] object obj0) => (this.arg\u00241.lambda\u0024drawBuildPlans\u00240((BuildPlan) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Boolf
    {
      private readonly Building arg\u00241;

      internal __\u003C\u003EAnon1([In] Building obj0) => this.arg\u00241 = obj0;

      public bool get([In] object obj0) => (MechUnitLegacyPulsar.lambda\u0024shouldSkip\u00241(this.arg\u00241, (ItemStack) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon2 : Floatc
    {
      private readonly MechUnitLegacyPulsar arg\u00241;
      private readonly Weapon arg\u00242;
      private readonly WeaponMount arg\u00243;
      private readonly float arg\u00244;
      private readonly float arg\u00245;
      private readonly float arg\u00246;
      private readonly float arg\u00247;
      private readonly float arg\u00248;

      internal __\u003C\u003EAnon2(
        [In] MechUnitLegacyPulsar obj0,
        [In] Weapon obj1,
        [In] WeaponMount obj2,
        [In] float obj3,
        [In] float obj4,
        [In] float obj5,
        [In] float obj6,
        [In] float obj7)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
        this.arg\u00244 = obj3;
        this.arg\u00245 = obj4;
        this.arg\u00246 = obj5;
        this.arg\u00247 = obj6;
        this.arg\u00248 = obj7;
      }

      public void get([In] float obj0) => this.arg\u00241.lambda\u0024shoot\u00243(this.arg\u00242, this.arg\u00243, this.arg\u00244, this.arg\u00245, this.arg\u00246, this.arg\u00247, this.arg\u00248, obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon3 : Floatc
    {
      private readonly MechUnitLegacyPulsar arg\u00241;
      private readonly WeaponMount arg\u00242;
      private readonly Weapon arg\u00243;
      private readonly float arg\u00244;
      private readonly float arg\u00245;
      private readonly float arg\u00246;

      internal __\u003C\u003EAnon3(
        [In] MechUnitLegacyPulsar obj0,
        [In] WeaponMount obj1,
        [In] Weapon obj2,
        [In] float obj3,
        [In] float obj4,
        [In] float obj5)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
        this.arg\u00244 = obj3;
        this.arg\u00245 = obj4;
        this.arg\u00246 = obj5;
      }

      public void get([In] float obj0) => this.arg\u00241.lambda\u0024shoot\u00244(this.arg\u00242, this.arg\u00243, this.arg\u00244, this.arg\u00245, this.arg\u00246, obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon4 : Runnable
    {
      private readonly MechUnitLegacyPulsar arg\u00241;
      private readonly float arg\u00242;
      private readonly BulletType arg\u00243;
      private readonly Weapon arg\u00244;
      private readonly float arg\u00245;
      private readonly float arg\u00246;
      private readonly WeaponMount arg\u00247;

      internal __\u003C\u003EAnon4(
        [In] MechUnitLegacyPulsar obj0,
        [In] float obj1,
        [In] BulletType obj2,
        [In] Weapon obj3,
        [In] float obj4,
        [In] float obj5,
        [In] WeaponMount obj6)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
        this.arg\u00244 = obj3;
        this.arg\u00245 = obj4;
        this.arg\u00246 = obj5;
        this.arg\u00247 = obj6;
      }

      public void run() => this.arg\u00241.lambda\u0024shoot\u00245(this.arg\u00242, this.arg\u00243, this.arg\u00244, this.arg\u00245, this.arg\u00246, this.arg\u00247);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon5 : Floatf
    {
      private readonly MechUnitLegacyPulsar arg\u00241;
      private readonly float arg\u00242;

      internal __\u003C\u003EAnon5([In] MechUnitLegacyPulsar obj0, [In] float obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public float get([In] object obj0) => this.arg\u00241.lambda\u0024draw\u00246(this.arg\u00242, (Vec2) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon6 : Cons
    {
      private readonly MechUnitLegacyPulsar arg\u00241;
      private readonly Boolf arg\u00242;

      internal __\u003C\u003EAnon6([In] MechUnitLegacyPulsar obj0, [In] Boolf obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024commandNearby\u00247(this.arg\u00242, (Unit) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon7 : Floatf
    {
      internal __\u003C\u003EAnon7()
      {
      }

      public float get([In] object obj0) => MechUnitLegacyPulsar.lambda\u0024commandNearby\u00248((Unit) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon8 : Floatf
    {
      private readonly MechUnitLegacyPulsar arg\u00241;

      internal __\u003C\u003EAnon8([In] MechUnitLegacyPulsar obj0) => this.arg\u00241 = obj0;

      public float get([In] object obj0) => this.arg\u00241.lambda\u0024commandNearby\u00249((Unit) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon9 : Prov
    {
      internal __\u003C\u003EAnon9()
      {
      }

      public object get() => (object) new StatusEntry();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon10 : EntityCollisions.SolidPred
    {
      internal __\u003C\u003EAnon10()
      {
      }

      public bool solid([In] int obj0, [In] int obj1) => (EntityCollisions.solid(obj0, obj1) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon11 : Boolf
    {
      private readonly MechUnitLegacyPulsar arg\u00241;

      internal __\u003C\u003EAnon11([In] MechUnitLegacyPulsar obj0) => this.arg\u00241 = obj0;

      public bool get([In] object obj0) => (this.arg\u00241.lambda\u0024update\u002410((Unit) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon12 : Boolf
    {
      private readonly Building arg\u00241;

      internal __\u003C\u003EAnon12([In] Building obj0) => this.arg\u00241 = obj0;

      public bool get([In] object obj0) => (MechUnitLegacyPulsar.lambda\u0024update\u002411(this.arg\u00241, (ItemStack) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon13 : Runnable
    {
      private readonly MechUnitLegacyPulsar arg\u00241;
      private readonly Tile arg\u00242;
      private readonly BuildPlan arg\u00243;

      internal __\u003C\u003EAnon13([In] MechUnitLegacyPulsar obj0, [In] Tile obj1, [In] BuildPlan obj2)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
      }

      public void run() => this.arg\u00241.lambda\u0024update\u002412(this.arg\u00242, this.arg\u00243);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon14 : Boolf
    {
      internal __\u003C\u003EAnon14()
      {
      }

      public bool get([In] object obj0) => (MechUnitLegacyPulsar.lambda\u0024commandNearby\u002413((Unit) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon15 : Func
    {
      internal __\u003C\u003EAnon15()
      {
      }

      public object get([In] object obj0) => (object) ((Ability) obj0).copy();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon16 : Boolf
    {
      private readonly bool arg\u00241;
      private readonly int arg\u00242;
      private readonly int arg\u00243;

      internal __\u003C\u003EAnon16([In] bool obj0, [In] int obj1, [In] int obj2)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
      }

      public bool get([In] object obj0) => (MechUnitLegacyPulsar.lambda\u0024removeBuild\u002414(this.arg\u00241, this.arg\u00242, this.arg\u00243, (BuildPlan) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon17 : Boolf
    {
      private readonly StatusEffect arg\u00241;

      internal __\u003C\u003EAnon17([In] StatusEffect obj0) => this.arg\u00241 = obj0;

      public bool get([In] object obj0) => (MechUnitLegacyPulsar.lambda\u0024unapply\u002415(this.arg\u00241, (StatusEntry) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon18 : Runnable
    {
      private readonly MechUnitLegacyPulsar arg\u00241;
      private readonly WeaponMount arg\u00242;
      private readonly Weapon arg\u00243;
      private readonly float arg\u00244;
      private readonly float arg\u00245;
      private readonly float arg\u00246;
      private readonly float arg\u00247;
      private readonly float arg\u00248;
      private readonly float arg\u00249;

      internal __\u003C\u003EAnon18(
        [In] MechUnitLegacyPulsar obj0,
        [In] WeaponMount obj1,
        [In] Weapon obj2,
        [In] float obj3,
        [In] float obj4,
        [In] float obj5,
        [In] float obj6,
        [In] float obj7,
        [In] float obj8)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
        this.arg\u00244 = obj3;
        this.arg\u00245 = obj4;
        this.arg\u00246 = obj5;
        this.arg\u00247 = obj6;
        this.arg\u00248 = obj7;
        this.arg\u00249 = obj8;
      }

      public void run() => this.arg\u00241.lambda\u0024shoot\u00242(this.arg\u00242, this.arg\u00243, this.arg\u00244, this.arg\u00245, this.arg\u00246, this.arg\u00247, this.arg\u00248, this.arg\u00249);
    }
  }
}
