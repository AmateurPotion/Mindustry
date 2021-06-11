// Decompiled with JetBrains decompiler
// Type: mindustry.world.blocks.defense.turrets.Turret
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.@struct;
using arc.audio;
using arc.func;
using arc.graphics;
using arc.graphics.g2d;
using arc.math;
using arc.math.geom;
using arc.util;
using arc.util.io;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using mindustry.content;
using mindustry.core;
using mindustry.entities;
using mindustry.entities.bullet;
using mindustry.game;
using mindustry.gen;
using mindustry.graphics;
using mindustry.logic;
using mindustry.type;
using mindustry.world.consumers;
using mindustry.world.meta;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.world.blocks.defense.turrets
{
  public class Turret : ReloadTurret
  {
    public const float logicControlCooldown = 120f;
    internal int __\u003C\u003EtimerTarget;
    public int targetInterval;
    public Color heatColor;
    public Effect shootEffect;
    public Effect smokeEffect;
    public Effect ammoUseEffect;
    public Sound shootSound;
    public int maxAmmo;
    public int ammoPerShot;
    public float ammoEjectBack;
    public float inaccuracy;
    public float velocityInaccuracy;
    public int shots;
    public float spread;
    public float recoilAmount;
    public float restitution;
    public float cooldown;
    public float coolantUsage;
    public float shootCone;
    public float shootShake;
    public float shootLength;
    public float xRand;
    public float minRange;
    public float burstSpacing;
    public bool alternate;
    public bool targetAir;
    public bool targetGround;
    public float chargeTime;
    public int chargeEffects;
    public float chargeMaxDelay;
    public Effect chargeEffect;
    public Effect chargeBeginEffect;
    public Sound chargeSound;
    public Units.Sortf unitSort;
    protected internal Vec2 tr;
    protected internal Vec2 tr2;
    public TextureRegion baseRegion;
    public TextureRegion heatRegion;
    public float elevation;
    [Signature("Larc/func/Cons<Lmindustry/world/blocks/defense/turrets/Turret$TurretBuild;>;")]
    public Cons drawer;
    [Signature("Larc/func/Cons<Lmindustry/world/blocks/defense/turrets/Turret$TurretBuild;>;")]
    public Cons heatDrawer;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [Modifiers]
    [LineNumberTable(83)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u00240([In] Turret.TurretBuild obj0) => Draw.rect(this.region, obj0.x + this.tr2.x, obj0.y + this.tr2.y, obj0.rotation - 90f);

    [Modifiers]
    [LineNumberTable(new byte[] {35, 142, 113, 106, 127, 31, 101, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u00241([In] Turret.TurretBuild obj0)
    {
      if ((double) obj0.heat <= 9.99999974737875E-06)
        return;
      Draw.color(this.heatColor, obj0.heat);
      Draw.blend(Blending.__\u003C\u003Eadditive);
      Draw.rect(this.heatRegion, obj0.x + this.tr2.x, obj0.y + this.tr2.y, obj0.rotation - 90f);
      Draw.blend();
      Draw.color();
    }

    [Modifiers]
    [LineNumberTable(119)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024init\u00242([In] Liquid obj0) => (double) obj0.temperature <= 0.5 && (double) obj0.flammability < 0.100000001490116;

    [LineNumberTable(new byte[] {45, 233, 3, 121, 136, 107, 107, 107, 107, 171, 104, 103, 107, 107, 107, 103, 107, 107, 107, 107, 107, 107, 107, 107, 139, 107, 107, 103, 103, 167, 107, 103, 107, 107, 107, 139, 144, 107, 203, 139, 113, 241, 76, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Turret(string name)
      : base(name)
    {
      Turret turret1 = this;
      Turret turret2 = this;
      int timers = turret2.timers;
      Turret turret3 = turret2;
      int num = timers;
      turret3.timers = timers + 1;
      this.__\u003C\u003EtimerTarget = num;
      this.targetInterval = 20;
      this.heatColor = Pal.turretHeat;
      this.shootEffect = Fx.__\u003C\u003Enone;
      this.smokeEffect = Fx.__\u003C\u003Enone;
      this.ammoUseEffect = Fx.__\u003C\u003Enone;
      this.shootSound = Sounds.shoot;
      this.maxAmmo = 30;
      this.ammoPerShot = 1;
      this.ammoEjectBack = 1f;
      this.inaccuracy = 0.0f;
      this.velocityInaccuracy = 0.0f;
      this.shots = 1;
      this.spread = 4f;
      this.recoilAmount = 1f;
      this.restitution = 0.02f;
      this.cooldown = 0.02f;
      this.coolantUsage = 0.2f;
      this.shootCone = 8f;
      this.shootShake = 0.0f;
      this.shootLength = -1f;
      this.xRand = 0.0f;
      this.minRange = 0.0f;
      this.burstSpacing = 0.0f;
      this.alternate = false;
      this.targetAir = true;
      this.targetGround = true;
      this.chargeTime = -1f;
      this.chargeEffects = 5;
      this.chargeMaxDelay = 10f;
      this.chargeEffect = Fx.__\u003C\u003Enone;
      this.chargeBeginEffect = Fx.__\u003C\u003Enone;
      this.chargeSound = Sounds.none;
      this.unitSort = (Units.Sortf) new Turret.__\u003C\u003EAnon0();
      this.tr = new Vec2();
      this.tr2 = new Vec2();
      this.elevation = -1f;
      this.drawer = (Cons) new Turret.__\u003C\u003EAnon1(this);
      this.heatDrawer = (Cons) new Turret.__\u003C\u003EAnon2(this);
      this.liquidCapacity = 20f;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool outputsItems() => false;

    [LineNumberTable(new byte[] {56, 134, 127, 2, 127, 30, 118, 118, 127, 6})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setStats()
    {
      base.setStats();
      this.stats.add(Stat.__\u003C\u003Einaccuracy, (float) ByteCodeHelper.f2i(this.inaccuracy), StatUnit.__\u003C\u003Edegrees);
      this.stats.add(Stat.__\u003C\u003Ereload, 60f / (this.reloadTime + 1f) * (!this.alternate ? (float) this.shots : 1f), StatUnit.__\u003C\u003Enone);
      this.stats.add(Stat.__\u003C\u003EtargetsAir, this.targetAir);
      this.stats.add(Stat.__\u003C\u003EtargetsGround, this.targetGround);
      if (this.ammoPerShot == 1)
        return;
      this.stats.add(Stat.__\u003C\u003EammoUse, (float) this.ammoPerShot, StatUnit.__\u003C\u003EperShot);
    }

    [LineNumberTable(new byte[] {67, 122, 103, 191, 18, 127, 4, 159, 2, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void init()
    {
      if (this.acceptCoolant && !this.__\u003C\u003Econsumes.has(ConsumeType.__\u003C\u003Eliquid))
      {
        this.hasLiquids = true;
        this.__\u003C\u003Econsumes.add((Consume) new ConsumeLiquidFilter((Boolf) new Turret.__\u003C\u003EAnon3(), this.coolantUsage)).update(false).boost();
      }
      if ((double) this.shootLength < 0.0)
        this.shootLength = (float) (this.size * 8) / 2f;
      if ((double) this.elevation < 0.0)
        this.elevation = (float) this.size / 2f;
      base.init();
    }

    [LineNumberTable(130)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override TextureRegion[] icons() => new TextureRegion[2]
    {
      this.baseRegion,
      this.region
    };

    [HideFromJava]
    static Turret() => ReloadTurret.__\u003Cclinit\u003E();

    [Modifiers]
    public int timerTarget
    {
      [HideFromJava] get => this.__\u003C\u003EtimerTarget;
      [HideFromJava] [param: In] private set => this.__\u003C\u003EtimerTarget = value;
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

      [LineNumberTable(183)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static \u0031()
      {
        if (ByteCodeHelper.isAlreadyInited("mindustry.world.blocks.defense.turrets.Turret$1"))
          return;
        Turret.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess = new int[LAccess.values().Length];
        try
        {
          Turret.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess[LAccess.__\u003C\u003Eammo.ordinal()] = 1;
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
          Turret.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess[LAccess.__\u003C\u003EammoCapacity.ordinal()] = 2;
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
          Turret.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess[LAccess.__\u003C\u003Erotation.ordinal()] = 3;
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
          Turret.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess[LAccess.__\u003C\u003EshootX.ordinal()] = 4;
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
          Turret.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess[LAccess.__\u003C\u003EshootY.ordinal()] = 5;
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
          Turret.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess[LAccess.__\u003C\u003Eshooting.ordinal()] = 6;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
      }

      \u0031() => throw null;
    }

    public abstract class AmmoEntry : Object
    {
      public int amount;

      [LineNumberTable(133)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public AmmoEntry()
      {
      }

      public abstract BulletType type();
    }

    [Implements(new string[] {"mindustry.world.blocks.ControlBlock"})]
    public class TurretBuild : ReloadTurret.ReloadTurretBuild, ControlBlock
    {
      [Signature("Larc/struct/Seq<Lmindustry/world/blocks/defense/turrets/Turret$AmmoEntry;>;")]
      public Seq ammo;
      public int totalAmmo;
      public float recoil;
      public float heat;
      public float logicControlTime;
      public int shotCounter;
      public bool logicShooting;
      [arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})]
      public Posc target;
      public Vec2 targetPos;
      public BlockUnitc unit;
      public bool wasShooting;
      public bool charging;
      [Modifiers]
      internal Turret this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual bool isActive() => this.target != null || this.wasShooting;

      [LineNumberTable(new byte[] {160, 235, 127, 17, 140})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual bool hasAmmo()
      {
        if (this.ammo.size >= 2 && ((Turret.AmmoEntry) this.ammo.peek()).amount < this.this\u00240.ammoPerShot)
          this.ammo.pop();
        return this.ammo.size > 0 && ((Turret.AmmoEntry) this.ammo.peek()).amount >= this.this\u00240.ammoPerShot;
      }

      [LineNumberTable(343)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual BulletType peekAmmo() => ((Turret.AmmoEntry) this.ammo.peek()).type();

      [LineNumberTable(new byte[] {160, 98, 108, 103, 135, 142, 116, 109, 141})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void targetPosition(Posc pos)
      {
        if (!this.hasAmmo() || pos == null)
          return;
        float v = this.peekAmmo().speed;
        if ((double) v < 0.100000001490116)
          v = 9999999f;
        this.targetPos.set(Predict.intercept((Position) this, (Position) pos, v));
        if (!this.targetPos.isZero())
          return;
        this.targetPos.set((Position) pos);
      }

      [LineNumberTable(195)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual bool isShooting()
      {
        if (this.isControlled())
          return this.unit.isShooting();
        if (this.logicControlled())
          return this.logicShooting;
        return this.target != null;
      }

      [HideFromJava]
      public virtual bool isControlled() => ControlBlock.\u003Cdefault\u003EisControlled((ControlBlock) this);

      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual bool logicControlled() => (double) this.logicControlTime > 0.0;

      [LineNumberTable(309)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      protected internal virtual bool validateTarget() => !Units.invalidateTarget(this.target, this.team, this.x, this.y) || this.isControlled() || this.logicControlled();

      [LineNumberTable(new byte[] {160, 199, 122, 159, 32, 159, 41})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      protected internal virtual void findTarget()
      {
        if (this.this\u00240.targetAir && !this.this\u00240.targetGround)
          this.target = (Posc) Units.bestEnemy(this.team, this.x, this.y, this.this\u00240.range, (Boolf) new Turret.TurretBuild.__\u003C\u003EAnon0(), this.this\u00240.unitSort);
        else
          this.target = (Posc) Units.bestTarget(this.team, this.x, this.y, this.this\u00240.range, (Boolf) new Turret.TurretBuild.__\u003C\u003EAnon1(this), (Boolf) new Turret.TurretBuild.__\u003C\u003EAnon2(), this.this\u00240.unitSort);
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual bool shouldTurn() => !this.charging;

      [LineNumberTable(new byte[] {160, 207, 127, 18})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      protected internal virtual void turnToTarget(float targetRot) => this.rotation = Angles.moveToward(this.rotation, targetRot, this.this\u00240.rotateSpeed * this.delta() * this.baseReloadSpeed());

      [LineNumberTable(new byte[] {160, 242, 123, 135, 135, 107, 98, 159, 12})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      protected internal virtual void updateShooting()
      {
        if ((double) this.reload >= (double) this.this\u00240.reloadTime && !this.charging)
        {
          this.shoot(this.peekAmmo());
          this.reload = 0.0f;
        }
        else
          this.reload += this.delta() * this.peekAmmo().reloadMultiplier * this.baseReloadSpeed();
      }

      [LineNumberTable(new byte[] {161, 91, 169, 159, 29, 127, 56})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      protected internal virtual void ejectEffects()
      {
        if (!this.isValid())
          return;
        double num1;
        if (this.this\u00240.shots == 2 && this.this\u00240.alternate)
        {
          int shotCounter = this.shotCounter;
          int num2 = 2;
          if ((num2 != -1 ? shotCounter % num2 : 0) == 1)
          {
            num1 = -1.0;
            goto label_5;
          }
        }
        num1 = 1.0;
label_5:
        float num3 = (float) num1;
        this.this\u00240.ammoUseEffect.at(this.x - Angles.trnsx(this.rotation, this.this\u00240.ammoEjectBack), this.y - Angles.trnsy(this.rotation, this.this\u00240.ammoEjectBack), this.rotation * num3);
      }

      [LineNumberTable(new byte[] {161, 0, 117, 135, 127, 3, 127, 39, 159, 39, 112, 63, 2, 230, 72, 135, 255, 2, 75, 114, 112, 63, 1, 235, 82, 112, 159, 21, 127, 43, 127, 1, 101, 159, 20, 112, 63, 51, 230, 69, 142, 113, 107, 102, 135})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      protected internal virtual void shoot(BulletType type)
      {
        if ((double) this.this\u00240.chargeTime > 0.0)
        {
          this.useAmmo();
          this.this\u00240.tr.trns(this.rotation, this.this\u00240.shootLength);
          this.this\u00240.chargeBeginEffect.at(this.x + this.this\u00240.tr.x, this.y + this.this\u00240.tr.y, this.rotation);
          this.this\u00240.chargeSound.at(this.x + this.this\u00240.tr.x, this.y + this.this\u00240.tr.y, 1f);
          for (int index = 0; index < this.this\u00240.chargeEffects; ++index)
            Time.run(Mathf.random(this.this\u00240.chargeMaxDelay), (Runnable) new Turret.TurretBuild.__\u003C\u003EAnon3(this));
          this.charging = true;
          Time.run(this.this\u00240.chargeTime, (Runnable) new Turret.TurretBuild.__\u003C\u003EAnon4(this, type));
        }
        else if ((double) this.this\u00240.burstSpacing > 9.99999974737875E-05)
        {
          for (int index = 0; index < this.this\u00240.shots; ++index)
            Time.run(this.this\u00240.burstSpacing * (float) index, (Runnable) new Turret.TurretBuild.__\u003C\u003EAnon5(this, type));
        }
        else
        {
          if (this.this\u00240.alternate)
          {
            int shotCounter = this.shotCounter;
            int shots = this.this\u00240.shots;
            this.this\u00240.tr.trns(this.rotation - 90f, this.this\u00240.spread * ((shots != -1 ? (float) (shotCounter % shots) : 0.0f) - (float) (this.this\u00240.shots - 1) / 2f) + Mathf.range(this.this\u00240.xRand), this.this\u00240.shootLength);
            this.bullet(type, this.rotation + Mathf.range(this.this\u00240.inaccuracy));
          }
          else
          {
            this.this\u00240.tr.trns(this.rotation, this.this\u00240.shootLength, Mathf.range(this.this\u00240.xRand));
            for (int index = 0; index < this.this\u00240.shots; ++index)
              this.bullet(type, this.rotation + Mathf.range(this.this\u00240.inaccuracy + type.inaccuracy) + (float) (index - ByteCodeHelper.f2i((float) this.this\u00240.shots / 2f)) * this.this\u00240.spread);
          }
          ++this.shotCounter;
          this.recoil = this.this\u00240.recoilAmount;
          this.heat = 1f;
          this.effects();
          this.useAmmo();
        }
      }

      [LineNumberTable(new byte[] {160, 216, 143, 113, 120, 117, 120, 114, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual BulletType useAmmo()
      {
        if (this.cheating())
          return this.peekAmmo();
        Turret.AmmoEntry ammoEntry = (Turret.AmmoEntry) this.ammo.peek();
        ammoEntry.amount -= this.this\u00240.ammoPerShot;
        if (ammoEntry.amount <= 0)
          this.ammo.pop();
        this.totalAmmo -= this.this\u00240.ammoPerShot;
        this.totalAmmo = Math.max(this.totalAmmo, 0);
        this.ejectEffects();
        return ammoEntry.type();
      }

      [LineNumberTable(new byte[] {161, 70, 159, 119, 127, 58})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      protected internal virtual void bullet(BulletType type, float angle)
      {
        float lifetimeScl = !type.scaleVelocity ? 1f : Mathf.clamp(Mathf.dst(this.x + this.this\u00240.tr.x, this.y + this.this\u00240.tr.y, this.targetPos.x, this.targetPos.y) / type.range(), this.this\u00240.minRange / type.range(), this.this\u00240.range / type.range());
        type.create((Entityc) this, this.team, this.x + this.this\u00240.tr.x, this.y + this.this\u00240.tr.y, angle, 1f + Mathf.range(this.this\u00240.velocityInaccuracy), lifetimeScl);
      }

      [LineNumberTable(new byte[] {161, 76, 127, 17, 159, 17, 127, 29, 127, 29, 159, 50, 114, 188, 113})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      protected internal virtual void effects()
      {
        Effect effect1 = !object.ReferenceEquals((object) this.this\u00240.shootEffect, (object) Fx.__\u003C\u003Enone) ? this.this\u00240.shootEffect : this.peekAmmo().shootEffect;
        Effect effect2 = !object.ReferenceEquals((object) this.this\u00240.smokeEffect, (object) Fx.__\u003C\u003Enone) ? this.this\u00240.smokeEffect : this.peekAmmo().smokeEffect;
        effect1.at(this.x + this.this\u00240.tr.x, this.y + this.this\u00240.tr.y, this.rotation);
        effect2.at(this.x + this.this\u00240.tr.x, this.y + this.this\u00240.tr.y, this.rotation);
        this.this\u00240.shootSound.at(this.x + this.this\u00240.tr.x, this.y + this.this\u00240.tr.y, Mathf.random(0.9f, 1.1f));
        if ((double) this.this\u00240.shootShake > 0.0)
          Effect.shake(this.this\u00240.shootShake, this.this\u00240.shootShake, (Position) this);
        this.recoil = this.this\u00240.recoilAmount;
      }

      [Modifiers]
      [LineNumberTable(314)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static bool lambda\u0024findTarget\u00240([In] Unit obj0) => !obj0.dead() && !obj0.isGrounded();

      [Modifiers]
      [LineNumberTable(316)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private bool lambda\u0024findTarget\u00241([In] Unit obj0) => !obj0.dead() && (obj0.isGrounded() || this.this\u00240.targetAir) && (!obj0.isGrounded() || this.this\u00240.targetGround);

      [Modifiers]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static bool lambda\u0024findTarget\u00242([In] Building obj0) => true;

      [Modifiers]
      [LineNumberTable(new byte[] {161, 9, 105, 127, 3, 127, 39})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024shoot\u00243()
      {
        if (!this.isValid())
          return;
        this.this\u00240.tr.trns(this.rotation, this.this\u00240.shootLength);
        this.this\u00240.chargeEffect.at(this.x + this.this\u00240.tr.x, this.y + this.this\u00240.tr.y, this.rotation);
      }

      [Modifiers]
      [LineNumberTable(new byte[] {161, 18, 105, 127, 3, 113, 107, 127, 1, 102, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024shoot\u00244([In] BulletType obj0)
      {
        if (!this.isValid())
          return;
        this.this\u00240.tr.trns(this.rotation, this.this\u00240.shootLength);
        this.recoil = this.this\u00240.recoilAmount;
        this.heat = 1f;
        this.bullet(obj0, this.rotation + Mathf.range(this.this\u00240.inaccuracy));
        this.effects();
        this.charging = false;
      }

      [Modifiers]
      [LineNumberTable(new byte[] {161, 31, 145, 145, 127, 20, 127, 1, 102, 103, 113, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024shoot\u00245([In] BulletType obj0)
      {
        if (!this.isValid() || !this.hasAmmo())
          return;
        this.recoil = this.this\u00240.recoilAmount;
        this.this\u00240.tr.trns(this.rotation, this.this\u00240.shootLength, Mathf.range(this.this\u00240.xRand));
        this.bullet(obj0, this.rotation + Mathf.range(this.this\u00240.inaccuracy));
        this.effects();
        this.useAmmo();
        this.recoil = this.this\u00240.recoilAmount;
        this.heat = 1f;
      }

      [LineNumberTable(new byte[] {89, 112, 139, 139, 135, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public TurretBuild(Turret _param1)
      {
        this.this\u00240 = _param1;
        // ISSUE: explicit constructor call
        base.\u002Ector((ReloadTurret) _param1);
        Turret.TurretBuild turretBuild = this;
        this.ammo = new Seq();
        this.logicControlTime = -1f;
        this.logicShooting = false;
        this.targetPos = new Vec2();
        this.unit = Nulls.__\u003C\u003EblockUnit;
      }

      [LineNumberTable(new byte[] {102, 123, 108})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void created()
      {
        this.unit = (BlockUnitc) UnitTypes.block.create(this.team);
        this.unit.tile((Building) this);
      }

      [LineNumberTable(new byte[] {108, 122, 126, 107, 180, 113})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void control(LAccess type, double p1, double p2, double p3, double p4)
      {
        if (object.ReferenceEquals((object) type, (object) LAccess.__\u003C\u003Eshoot) && !this.unit.isPlayer())
        {
          this.targetPos.set(World.unconv((float) p1), World.unconv((float) p2));
          this.logicControlTime = 120f;
          this.logicShooting = !Mathf.zero(p3);
        }
        base.control(type, p1, p2, p3, p4);
      }

      [LineNumberTable(new byte[] {119, 122, 107, 147, 104, 204, 112})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void control(LAccess type, object p1, double p2, double p3, double p4)
      {
        if (object.ReferenceEquals((object) type, (object) LAccess.__\u003C\u003Eshootp) && !this.unit.isPlayer())
        {
          this.logicControlTime = 120f;
          this.logicShooting = !Mathf.zero(p2);
          if (p1 is Posc)
            this.targetPosition((Posc) p1);
        }
        base.control(type, p1, p2, p3, p4);
      }

      [LineNumberTable(new byte[] {160, 69, 127, 14, 105, 110, 105, 116, 116, 118, 232, 57})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override double sense(LAccess sensor)
      {
        switch (Turret.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LAccess[sensor.ordinal()])
        {
          case 1:
            return (double) this.totalAmmo;
          case 2:
            return (double) this.this\u00240.maxAmmo;
          case 3:
            return (double) this.rotation;
          case 4:
            return (double) World.conv(this.targetPos.x);
          case 5:
            return (double) World.conv(this.targetPos.y);
          case 6:
            return this.isShooting() ? 1.0 : 0.0;
          default:
            return base.sense(sensor);
        }
      }

      [LineNumberTable(200)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual Unit unit() => (Unit) this.unit;

      [LineNumberTable(new byte[] {160, 112, 124, 133, 138, 158, 127, 72, 145, 127, 2, 145})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void draw()
      {
        Draw.rect(this.this\u00240.baseRegion, this.x, this.y);
        Draw.color();
        Draw.z(50f);
        this.this\u00240.tr2.trns(this.rotation, -this.recoil);
        Drawf.shadow(this.this\u00240.region, this.x + this.this\u00240.tr2.x - this.this\u00240.elevation, this.y + this.this\u00240.tr2.y - this.this\u00240.elevation, this.rotation - 90f);
        this.this\u00240.drawer.get((object) this);
        if (object.ReferenceEquals((object) this.this\u00240.heatRegion, (object) Core.atlas.find("error")))
          return;
        this.this\u00240.heatDrawer.get((object) this);
      }

      [LineNumberTable(new byte[] {160, 129, 143, 135, 127, 3, 159, 3, 113, 113, 113, 151, 109, 179, 139, 127, 0, 166, 107, 130, 104, 127, 5, 110, 104, 137, 140, 109, 203, 142, 104, 167, 125, 103, 230, 69, 109, 134})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void updateTile()
      {
        if (!this.validateTarget())
          this.target = (Posc) null;
        this.wasShooting = false;
        this.recoil = Mathf.lerpDelta(this.recoil, 0.0f, this.this\u00240.restitution);
        this.heat = Mathf.lerpDelta(this.heat, 0.0f, this.this\u00240.cooldown);
        this.unit.health(this.health);
        this.unit.rotation(this.rotation);
        this.unit.team(this.team);
        this.unit.set(this.x, this.y);
        if ((double) this.logicControlTime > 0.0)
          this.logicControlTime -= Time.delta;
        if (this.hasAmmo())
        {
          if (this.timer(this.this\u00240.__\u003C\u003EtimerTarget, (float) this.this\u00240.targetInterval))
            this.findTarget();
          if (this.validateTarget())
          {
            int num1 = 1;
            if (this.isControlled())
            {
              this.targetPos.set(this.unit.aimX(), this.unit.aimY());
              num1 = this.unit.isShooting() ? 1 : 0;
            }
            else if (this.logicControlled())
            {
              num1 = this.logicShooting ? 1 : 0;
            }
            else
            {
              this.targetPosition(this.target);
              if (Float.isNaN(this.rotation))
                this.rotation = 0.0f;
            }
            float num2 = this.angleTo((Position) this.targetPos);
            if (this.shouldTurn())
              this.turnToTarget(num2);
            if ((double) Angles.angleDist(this.rotation, num2) < (double) this.this\u00240.shootCone && num1 != 0)
            {
              this.wasShooting = true;
              this.updateShooting();
            }
          }
        }
        if (!this.this\u00240.acceptCoolant)
          return;
        this.updateCooling();
      }

      [LineNumberTable(new byte[] {160, 187, 127, 1, 170, 106})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void handleLiquid(Building source, Liquid liquid, float amount)
      {
        if (this.this\u00240.acceptCoolant && (double) this.liquids.currentAmount() <= 1.0 / 1000.0)
          Events.fire((object) EventType.Trigger.__\u003C\u003EturretCool);
        base.handleLiquid(source, liquid, amount);
      }

      [LineNumberTable(new byte[] {161, 101, 103, 108, 108})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void write(Writes write)
      {
        base.write(write);
        write.f(this.reload);
        write.f(this.rotation);
      }

      [LineNumberTable(new byte[] {159, 23, 131, 136, 100, 109, 141})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void read(Reads read, byte revision)
      {
        int num = (int) (sbyte) revision;
        base.read(read, (byte) num);
        if (num < 1)
          return;
        this.reload = read.f();
        this.rotation = read.f();
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      public override byte version() => 1;

      [HideFromJava]
      public virtual bool canControl() => ControlBlock.\u003Cdefault\u003EcanControl((ControlBlock) this);

      [HideFromJava]
      public virtual bool shouldAutoTarget() => ControlBlock.\u003Cdefault\u003EshouldAutoTarget((ControlBlock) this);

      [HideFromJava]
      static TurretBuild() => ReloadTurret.ReloadTurretBuild.__\u003Cclinit\u003E();

      [SpecialName]
      private new sealed class __\u003C\u003EAnon0 : Boolf
      {
        internal __\u003C\u003EAnon0()
        {
        }

        public bool get([In] object obj0) => (Turret.TurretBuild.lambda\u0024findTarget\u00240((Unit) obj0) ? 1 : 0) != 0;
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon1 : Boolf
      {
        private readonly Turret.TurretBuild arg\u00241;

        internal __\u003C\u003EAnon1([In] Turret.TurretBuild obj0) => this.arg\u00241 = obj0;

        public bool get([In] object obj0) => (this.arg\u00241.lambda\u0024findTarget\u00241((Unit) obj0) ? 1 : 0) != 0;
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon2 : Boolf
      {
        internal __\u003C\u003EAnon2()
        {
        }

        public bool get([In] object obj0) => (Turret.TurretBuild.lambda\u0024findTarget\u00242((Building) obj0) ? 1 : 0) != 0;
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon3 : Runnable
      {
        private readonly Turret.TurretBuild arg\u00241;

        internal __\u003C\u003EAnon3([In] Turret.TurretBuild obj0) => this.arg\u00241 = obj0;

        public void run() => this.arg\u00241.lambda\u0024shoot\u00243();
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon4 : Runnable
      {
        private readonly Turret.TurretBuild arg\u00241;
        private readonly BulletType arg\u00242;

        internal __\u003C\u003EAnon4([In] Turret.TurretBuild obj0, [In] BulletType obj1)
        {
          this.arg\u00241 = obj0;
          this.arg\u00242 = obj1;
        }

        public void run() => this.arg\u00241.lambda\u0024shoot\u00244(this.arg\u00242);
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon5 : Runnable
      {
        private readonly Turret.TurretBuild arg\u00241;
        private readonly BulletType arg\u00242;

        internal __\u003C\u003EAnon5([In] Turret.TurretBuild obj0, [In] BulletType obj1)
        {
          this.arg\u00241 = obj0;
          this.arg\u00242 = obj1;
        }

        public void run() => this.arg\u00241.lambda\u0024shoot\u00245(this.arg\u00242);
      }
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon0 : Units.Sortf
    {
      internal __\u003C\u003EAnon0()
      {
      }

      public float cost([In] Unit obj0, [In] float obj1, [In] float obj2) => obj0.dst2(obj1, obj2);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon1 : Cons
    {
      private readonly Turret arg\u00241;

      internal __\u003C\u003EAnon1([In] Turret obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024new\u00240((Turret.TurretBuild) obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon2 : Cons
    {
      private readonly Turret arg\u00241;

      internal __\u003C\u003EAnon2([In] Turret obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024new\u00241((Turret.TurretBuild) obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon3 : Boolf
    {
      internal __\u003C\u003EAnon3()
      {
      }

      public bool get([In] object obj0) => (Turret.lambda\u0024init\u00242((Liquid) obj0) ? 1 : 0) != 0;
    }
  }
}
