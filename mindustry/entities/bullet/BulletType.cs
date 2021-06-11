// Decompiled with JetBrains decompiler
// Type: mindustry.entities.bullet.BulletType
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.audio;
using arc.func;
using arc.graphics;
using arc.math;
using arc.math.geom;
using arc.util;
using IKVM.Attributes;
using java.lang;
using mindustry.content;
using mindustry.ctype;
using mindustry.game;
using mindustry.gen;
using mindustry.graphics;
using mindustry.type;
using mindustry.world.blocks;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.entities.bullet
{
  public abstract class BulletType : Content
  {
    public float lifetime;
    public float speed;
    public float damage;
    public float hitSize;
    public float drawSize;
    public float drag;
    public bool pierce;
    public bool pierceBuilding;
    public int pierceCap;
    public Effect hitEffect;
    public Effect despawnEffect;
    public Effect shootEffect;
    public Effect smokeEffect;
    public Sound hitSound;
    public float hitSoundPitch;
    public float hitSoundVolume;
    public float inaccuracy;
    public float ammoMultiplier;
    public float reloadMultiplier;
    public float buildingDamageMultiplier;
    public float recoil;
    public bool killShooter;
    public bool instantDisappear;
    public float splashDamage;
    public float knockback;
    public StatusEffect status;
    public float statusDuration;
    public bool collidesTiles;
    public bool collidesTeam;
    public bool collidesAir;
    public bool collidesGround;
    public bool collides;
    public bool keepVelocity;
    public bool scaleVelocity;
    public bool hittable;
    public bool reflectable;
    public bool absorbable;
    public bool backMove;
    public float maxRange;
    public float healPercent;
    public bool makeFire;
    public float fragCone;
    public float fragAngle;
    public int fragBullets;
    public float fragVelocityMin;
    public float fragVelocityMax;
    public float fragLifeMin;
    public float fragLifeMax;
    [Nullable(new object[] {64, "Larc/util/Nullable;"})]
    public BulletType fragBullet;
    public Color hitColor;
    public Color trailColor;
    public float trailChance;
    public Effect trailEffect;
    public float trailParam;
    public float splashDamageRadius;
    public int incendAmount;
    public float incendSpread;
    public float incendChance;
    public float homingPower;
    public float homingRange;
    public float homingDelay;
    public Color lightningColor;
    public int lightning;
    public int lightningLength;
    public int lightningLengthRand;
    public float lightningDamage;
    public float lightningCone;
    public float lightningAngle;
    [Nullable(new object[] {64, "Larc/util/Nullable;"})]
    public BulletType lightningType;
    public float weaveScale;
    public float weaveMag;
    public float hitShake;
    public float despawnShake;
    public int puddles;
    public float puddleRange;
    public float puddleAmount;
    public Liquid puddleLiquid;
    public float lightRadius;
    public float lightOpacity;
    public Color lightColor;

    [LineNumberTable(161)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float range() => Math.max(this.speed * this.lifetime * (1f - this.drag), this.maxRange);

    [LineNumberTable(new byte[] {89, 232, 159, 138, 171, 107, 107, 139, 199, 139, 139, 139, 139, 139, 139, 139, 139, 235, 72, 203, 139, 139, 135, 135, 142, 135, 199, 135, 135, 167, 135, 139, 139, 199, 107, 107, 104, 127, 13, 103, 139, 107, 107, 107, 171, 139, 103, 107, 107, 107, 139, 139, 139, 142, 107, 107, 139, 135, 107, 107, 214, 107, 139, 107, 107, 171, 104, 104, 107, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public BulletType(float speed, float damage)
    {
      BulletType bulletType = this;
      this.lifetime = 40f;
      this.hitSize = 4f;
      this.drawSize = 40f;
      this.drag = 0.0f;
      this.pierceCap = -1;
      this.shootEffect = Fx.__\u003C\u003EshootSmall;
      this.smokeEffect = Fx.__\u003C\u003EshootSmallSmoke;
      this.hitSound = Sounds.none;
      this.hitSoundPitch = 1f;
      this.hitSoundVolume = 1f;
      this.inaccuracy = 0.0f;
      this.ammoMultiplier = 2f;
      this.reloadMultiplier = 1f;
      this.buildingDamageMultiplier = 1f;
      this.splashDamage = 0.0f;
      this.status = StatusEffects.none;
      this.statusDuration = 480f;
      this.collidesTiles = true;
      this.collidesTeam = false;
      this.collidesAir = true;
      this.collidesGround = true;
      this.collides = true;
      this.keepVelocity = true;
      this.hittable = true;
      this.reflectable = true;
      this.absorbable = true;
      this.backMove = true;
      this.maxRange = -1f;
      this.healPercent = 0.0f;
      this.makeFire = false;
      this.fragCone = 360f;
      this.fragAngle = 0.0f;
      this.fragBullets = 9;
      this.fragVelocityMin = 0.2f;
      this.fragVelocityMax = 1f;
      this.fragLifeMin = 1f;
      this.fragLifeMax = 1f;
      this.fragBullet = (BulletType) null;
      this.hitColor = Color.__\u003C\u003Ewhite;
      this.trailColor = Pal.missileYellowBack;
      this.trailChance = -0.0001f;
      this.trailEffect = Fx.__\u003C\u003EmissileTrail;
      this.trailParam = 2f;
      this.splashDamageRadius = -1f;
      this.incendAmount = 0;
      this.incendSpread = 8f;
      this.incendChance = 1f;
      this.homingPower = 0.0f;
      this.homingRange = 50f;
      this.homingDelay = -1f;
      this.lightningColor = Pal.surge;
      this.lightningLength = 5;
      this.lightningLengthRand = 0;
      this.lightningDamage = -1f;
      this.lightningCone = 360f;
      this.lightningAngle = 0.0f;
      this.lightningType = (BulletType) null;
      this.weaveScale = 1f;
      this.weaveMag = -1f;
      this.hitShake = 0.0f;
      this.despawnShake = 0.0f;
      this.puddleAmount = 5f;
      this.puddleLiquid = Liquids.water;
      this.lightRadius = 16f;
      this.lightOpacity = 0.3f;
      this.lightColor = Pal.powerLight;
      this.speed = speed;
      this.damage = damage;
      this.hitEffect = Fx.__\u003C\u003EhitBulletSmall;
      this.despawnEffect = Fx.__\u003C\u003EhitBulletSmall;
    }

    [LineNumberTable(new byte[] {102, 118, 118, 159, 1})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float estimateDPS()
    {
      float num = this.damage + this.splashDamage * 0.75f;
      if (this.fragBullet != null && !object.ReferenceEquals((object) this.fragBullet, (object) this))
        num += this.fragBullet.estimateDPS() * (float) this.fragBullets / 2f;
      return num;
    }

    [LineNumberTable(new byte[] {160, 79, 115})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void hit(Bullet b) => this.hit(b, b.x, b.y);

    [LineNumberTable(new byte[] {160, 83, 103, 124, 156, 146, 107, 110, 113, 127, 6, 255, 43, 61, 233, 71, 113, 107, 127, 12, 18, 230, 70, 110, 181, 123, 159, 17, 114, 191, 14, 109, 255, 17, 70, 104, 255, 12, 70, 110, 63, 74, 169})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void hit(Bullet b, float x, float y)
    {
      b.hit = true;
      this.hitEffect.at(x, y, b.rotation(), this.hitColor);
      this.hitSound.at(x, y, this.hitSoundPitch, this.hitSoundVolume);
      Effect.shake(this.hitShake, this.hitShake, (Position) b);
      if (this.fragBullet != null)
      {
        for (int index = 0; index < this.fragBullets; ++index)
        {
          float len = Mathf.random(1f, 7f);
          float angle = b.rotation() + Mathf.range(this.fragCone / 2f) + this.fragAngle;
          this.fragBullet.create(b, x + Angles.trnsx(angle, len), y + Angles.trnsy(angle, len), angle, Mathf.random(this.fragVelocityMin, this.fragVelocityMax), Mathf.random(this.fragLifeMin, this.fragLifeMax));
        }
      }
      if (this.puddleLiquid != null && this.puddles > 0)
      {
        for (int index = 0; index < this.puddles; ++index)
          Puddles.deposit(Vars.world.tileWorld(x + Mathf.range(this.puddleRange), y + Mathf.range(this.puddleRange)), this.puddleLiquid, this.puddleAmount);
      }
      if (Mathf.chance((double) this.incendChance))
        Damage.createIncend(x, y, this.incendSpread, this.incendAmount);
      if ((double) this.splashDamageRadius > 0.0 && !b.absorbed)
      {
        Damage.damage(b.team, x, y, this.splashDamageRadius, this.splashDamage * b.damageMultiplier(), this.collidesAir, this.collidesGround);
        if (!object.ReferenceEquals((object) this.status, (object) StatusEffects.none))
          Damage.status(b.team, x, y, this.splashDamageRadius, this.status, this.statusDuration, this.collidesAir, this.collidesGround);
        if ((double) this.healPercent > 0.0)
          Vars.indexer.eachBlock(b.team, x, y, this.splashDamageRadius, (Boolf) new BulletType.__\u003C\u003EAnon0(), (Cons) new BulletType.__\u003C\u003EAnon1(this));
        if (this.makeFire)
          Vars.indexer.eachBlock((Team) null, x, y, this.splashDamageRadius, (Boolf) new BulletType.__\u003C\u003EAnon2(b), (Cons) new BulletType.__\u003C\u003EAnon3());
      }
      for (int index = 0; index < this.lightning; ++index)
        Lightning.create(b, this.lightningColor, (double) this.lightningDamage >= 0.0 ? this.lightningDamage : this.damage, b.x, b.y, b.rotation() + Mathf.range(this.lightningCone / 2f) + this.lightningAngle, this.lightningLength + Mathf.random(this.lightningLengthRand));
    }

    [LineNumberTable(334)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Bullet create(
      Bullet parent,
      float x,
      float y,
      float angle,
      float velocityScl,
      float lifeScale)
    {
      return this.create(parent.owner, parent.team, x, y, angle, velocityScl, lifeScale);
    }

    [LineNumberTable(318)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Bullet create(Entityc owner, Team team, float x, float y, float angle) => this.create(owner, team, x, y, angle, 1f);

    [LineNumberTable(322)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Bullet create(
      Entityc owner,
      Team team,
      float x,
      float y,
      float angle,
      float velocityScl)
    {
      return this.create(owner, team, x, y, angle, -1f, velocityScl, 1f, (object) null);
    }

    [LineNumberTable(new byte[] {160, 228, 102, 103, 103, 103, 107, 122, 104, 159, 22, 139, 113, 104, 108, 108, 127, 5, 134, 127, 42})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Bullet create(
      [Nullable(new object[] {64, "Larc/util/Nullable;"})] Entityc owner,
      Team team,
      float x,
      float y,
      float angle,
      float damage,
      float velocityScl,
      float lifetimeScl,
      object data)
    {
      Bullet bullet = Bullet.create();
      bullet.type = this;
      bullet.owner = owner;
      bullet.team = team;
      bullet.time = 0.0f;
      bullet.vel.trns(angle, this.speed * velocityScl);
      if (this.backMove)
        bullet.set(x - bullet.vel.x * Time.delta, y - bullet.vel.y * Time.delta);
      else
        bullet.set(x, y);
      bullet.lifetime = this.lifetime * lifetimeScl;
      bullet.data = data;
      bullet.drag = this.drag;
      bullet.hitSize = this.hitSize;
      bullet.damage = ((double) damage >= 0.0 ? damage : this.damage) * bullet.damageMultiplier();
      bullet.add();
      if (this.keepVelocity)
      {
        Entityc entityc = owner;
        Velc velc;
        if (entityc is Velc && object.ReferenceEquals((object) (velc = (Velc) entityc), (object) (Velc) entityc))
          bullet.vel.add(velc.vel().x, velc.vel().y);
      }
      return bullet;
    }

    [LineNumberTable(326)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Bullet create(
      Entityc owner,
      Team team,
      float x,
      float y,
      float angle,
      float velocityScl,
      float lifetimeScl)
    {
      return this.create(owner, team, x, y, angle, -1f, velocityScl, lifetimeScl, (object) null);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 117, 127, 8, 124})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024hit\u00240([In] Building obj0)
    {
      Fx.__\u003C\u003EhealBlockFull.at(obj0.x, obj0.y, (float) obj0.block.size, Pal.heal);
      obj0.heal(this.healPercent / 100f * obj0.maxHealth());
    }

    [Modifiers]
    [LineNumberTable(237)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024hit\u00241([In] Bullet obj0, [In] Building obj1) => !object.ReferenceEquals((object) obj1.team, (object) obj0.team);

    [Modifiers]
    [LineNumberTable(new byte[] {160, 124, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024hit\u00242([In] Building obj0) => Fires.create(obj0.tile);

    [Modifiers]
    [LineNumberTable(279)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool lambda\u0024update\u00243([In] Unit obj0) => obj0.isGrounded() && this.collidesGround || obj0.isFlying() && this.collidesAir;

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool lambda\u0024update\u00244([In] Building obj0) => this.collidesGround;

    [LineNumberTable(new byte[] {97, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public BulletType()
      : this(1f, 1f)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float continuousDamage() => -1f;

    [LineNumberTable(170)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool testCollision(Bullet bullet, Building tile) => (double) this.healPercent <= 1.0 / 1000.0 || !object.ReferenceEquals((object) tile.team, (object) bullet.team) || (double) tile.healthf() < 1.0;

    [LineNumberTable(new byte[] {159, 98, 67, 123, 171, 127, 14, 127, 8, 126, 118, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void hitTile(Bullet b, Building build, float initialHealth, bool direct)
    {
      int num = direct ? 1 : 0;
      if (this.makeFire && !object.ReferenceEquals((object) build.team, (object) b.team))
        Fires.create(build.tile);
      if ((double) this.healPercent > 0.0 && object.ReferenceEquals((object) build.team, (object) b.team) && !(build.block is ConstructBlock))
      {
        Fx.__\u003C\u003EhealBlockFull.at(build.x, build.y, (float) build.block.size, Pal.heal);
        build.heal(this.healPercent / 100f * build.maxHealth());
      }
      else
      {
        if (object.ReferenceEquals((object) build.team, (object) b.team) || num == 0)
          return;
        this.hit(b);
      }
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void hitEntity(Bullet b, Hitboxc other, float initialHealth)
    {
    }

    [LineNumberTable(new byte[] {160, 135, 127, 5, 141, 146, 127, 7, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void despawned(Bullet b)
    {
      this.despawnEffect.at(b.x, b.y, b.rotation(), this.hitColor);
      this.hitSound.at((Position) b);
      Effect.shake(this.despawnShake, this.despawnShake, (Position) b);
      if (b.hit || this.fragBullet == null && (double) this.splashDamageRadius <= 0.0 && this.lightning <= 0)
        return;
      this.hit(b);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void draw(Bullet b)
    {
    }

    [LineNumberTable(new byte[] {160, 149, 126})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void drawLight(Bullet b) => Drawf.light(b.team, (Position) b, this.lightRadius, this.lightColor, this.lightOpacity);

    [LineNumberTable(new byte[] {160, 154, 127, 13, 166, 104, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void init(Bullet b)
    {
      if (this.killShooter)
      {
        Entityc entityc = b.owner();
        Healthc healthc;
        if (entityc is Healthc && object.ReferenceEquals((object) (healthc = (Healthc) entityc), (object) (Healthc) entityc))
          healthc.kill();
      }
      if (!this.instantDisappear)
        return;
      b.time = this.lifetime;
    }

    [LineNumberTable(new byte[] {160, 164, 126, 127, 21, 99, 223, 22, 109, 191, 58, 109, 110, 191, 4})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void update(Bullet b)
    {
      if ((double) this.homingPower > 9.99999974737875E-05 && (double) b.time >= (double) this.homingDelay)
      {
        Teamc teamc = Units.closestTarget(b.team, b.x, b.y, this.homingRange, (Boolf) new BulletType.__\u003C\u003EAnon4(this), (Boolf) new BulletType.__\u003C\u003EAnon5(this));
        if (teamc != null)
          b.vel.setAngle(Angles.moveToward(b.rotation(), b.angleTo((Position) teamc), this.homingPower * Time.delta * 50f));
      }
      if ((double) this.weaveMag > 0.0)
        b.vel.rotate(Mathf.sin(b.time + 3.141593f * this.weaveScale / 2f, this.weaveScale, this.weaveMag * (Mathf.randomSeed((long) b.id, 0, 1) != 1 ? 1f : -1f)) * Time.delta);
      if ((double) this.trailChance <= 0.0 || !Mathf.chanceDelta((double) this.trailChance))
        return;
      this.trailEffect.at(b.x, b.y, this.trailParam, this.trailColor);
    }

    [LineNumberTable(new byte[] {160, 184, 105, 199, 104, 154})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void init()
    {
      if (this.pierceCap >= 1)
        this.pierce = true;
      if (this.lightningType != null)
        return;
      this.lightningType = this.collidesAir ? Bullets.damageLightning : Bullets.damageLightningGround;
    }

    [LineNumberTable(310)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override ContentType getContentType() => ContentType.__\u003C\u003Ebullet;

    [LineNumberTable(314)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Bullet create(Teamc owner, float x, float y, float angle) => this.create((Entityc) owner, owner.team(), x, y, angle);

    [LineNumberTable(330)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Bullet create(Bullet parent, float x, float y, float angle) => this.create(parent.owner, parent.team, x, y, angle);

    [LineNumberTable(338)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Bullet create(
      Bullet parent,
      float x,
      float y,
      float angle,
      float velocityScl)
    {
      return this.create(parent.owner(), parent.team, x, y, angle, velocityScl);
    }

    [LineNumberTable(new byte[] {160, 251, 119})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void createNet(
      Team team,
      float x,
      float y,
      float angle,
      float damage,
      float velocityScl,
      float lifetimeScl)
    {
      Call.createBullet(this, team, x, y, angle, damage, velocityScl, lifetimeScl);
    }

    [LineNumberTable(new byte[] {161, 0, 100, 122})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void createBullet(
      BulletType type,
      Team team,
      float x,
      float y,
      float angle,
      float damage,
      float velocityScl,
      float lifetimeScl)
    {
      type?.create((Entityc) null, team, x, y, angle, damage, velocityScl, lifetimeScl, (object) null);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Boolf
    {
      internal __\u003C\u003EAnon0()
      {
      }

      public bool get([In] object obj0) => (((Building) obj0).damaged() ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Cons
    {
      private readonly BulletType arg\u00241;

      internal __\u003C\u003EAnon1([In] BulletType obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024hit\u00240((Building) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon2 : Boolf
    {
      private readonly Bullet arg\u00241;

      internal __\u003C\u003EAnon2([In] Bullet obj0) => this.arg\u00241 = obj0;

      public bool get([In] object obj0) => (BulletType.lambda\u0024hit\u00241(this.arg\u00241, (Building) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon3 : Cons
    {
      internal __\u003C\u003EAnon3()
      {
      }

      public void get([In] object obj0) => BulletType.lambda\u0024hit\u00242((Building) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon4 : Boolf
    {
      private readonly BulletType arg\u00241;

      internal __\u003C\u003EAnon4([In] BulletType obj0) => this.arg\u00241 = obj0;

      public bool get([In] object obj0) => (this.arg\u00241.lambda\u0024update\u00243((Unit) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon5 : Boolf
    {
      private readonly BulletType arg\u00241;

      internal __\u003C\u003EAnon5([In] BulletType obj0) => this.arg\u00241 = obj0;

      public bool get([In] object obj0) => (this.arg\u00241.lambda\u0024update\u00244((Building) obj0) ? 1 : 0) != 0;
    }
  }
}
