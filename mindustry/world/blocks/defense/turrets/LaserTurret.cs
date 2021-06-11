// Decompiled with JetBrains decompiler
// Type: mindustry.world.blocks.defense.turrets.LaserTurret
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.func;
using arc.math;
using arc.util;
using IKVM.Attributes;
using java.lang;
using mindustry.entities.bullet;
using mindustry.gen;
using mindustry.type;
using mindustry.world.consumers;
using mindustry.world.meta;
using mindustry.world.meta.values;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.world.blocks.defense.turrets
{
  public class LaserTurret : PowerTurret
  {
    public float firingMoveFract;
    public float shootDuration;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [Modifiers]
    [LineNumberTable(22)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024new\u00240([In] Liquid obj0) => (double) obj0.temperature <= 0.5 && (double) obj0.flammability < 0.100000001490116;

    [Modifiers]
    [LineNumberTable(28)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024init\u00241([In] Building obj0) => ((LaserTurret.LaserTurretBuild) obj0).bullet != null || ((Turret.TurretBuild) obj0).target != null;

    [Modifiers]
    [LineNumberTable(37)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool lambda\u0024setStats\u00242([In] Liquid obj0) => this.__\u003C\u003Econsumes.__\u003C\u003Eliquidfilters.get((int) obj0.__\u003C\u003Eid);

    [LineNumberTable(new byte[] {159, 161, 233, 60, 107, 203, 135, 127, 12, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public LaserTurret(string name)
      : base(name)
    {
      LaserTurret laserTurret = this;
      this.firingMoveFract = 0.25f;
      this.shootDuration = 100f;
      this.canOverdrive = false;
      this.__\u003C\u003Econsumes.add((Consume) new ConsumeLiquidFilter((Boolf) new LaserTurret.__\u003C\u003EAnon0(), 0.01f)).update(false);
      this.coolantMultiplier = 1f;
    }

    [LineNumberTable(new byte[] {159, 170, 124, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void init()
    {
      this.__\u003C\u003Econsumes.powerCond(this.powerUse, (Boolf) new LaserTurret.__\u003C\u003EAnon1());
      base.init();
    }

    [LineNumberTable(new byte[] {159, 176, 134, 112, 127, 40})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setStats()
    {
      base.setStats();
      this.stats.remove(Stat.__\u003C\u003Ebooster);
      this.stats.add(Stat.__\u003C\u003Einput, (StatValue) new BoosterListValue(this.reloadTime, ((ConsumeLiquidBase) this.__\u003C\u003Econsumes.get(ConsumeType.__\u003C\u003Eliquid)).__\u003C\u003Eamount, this.coolantMultiplier, false, (Boolf) new LaserTurret.__\u003C\u003EAnon2(this)));
    }

    [HideFromJava]
    static LaserTurret() => PowerTurret.__\u003Cclinit\u003E();

    public class LaserTurretBuild : PowerTurret.PowerTurretBuild
    {
      internal Bullet bullet;
      internal float bulletLife;
      [Modifiers]
      internal LaserTurret this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(40)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public LaserTurretBuild(LaserTurret _param1)
      {
        this.this\u00240 = _param1;
        // ISSUE: explicit constructor call
        base.\u002Ector((PowerTurret) _param1);
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      protected internal override void updateCooling()
      {
      }

      [LineNumberTable(new byte[] {1, 134, 123, 103, 127, 8, 113, 127, 28, 112, 107, 113, 127, 8, 112, 140, 112, 103, 108, 159, 1, 127, 36, 111, 141, 116, 191, 55})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void updateTile()
      {
        base.updateTile();
        if ((double) this.bulletLife > 0.0 && this.bullet != null)
        {
          this.wasShooting = true;
          this.this\u00240.tr.trns(this.rotation, this.this\u00240.shootLength, 0.0f);
          this.bullet.rotation(this.rotation);
          this.bullet.set(this.x + this.this\u00240.tr.x, this.y + this.this\u00240.tr.y);
          this.bullet.time(0.0f);
          this.heat = 1f;
          this.recoil = this.this\u00240.recoilAmount;
          this.bulletLife -= Time.delta / Math.max(this.efficiency(), 1E-05f);
          if ((double) this.bulletLife > 0.0)
            return;
          this.bullet = (Bullet) null;
        }
        else
        {
          if ((double) this.reload <= 0.0)
            return;
          this.wasShooting = true;
          Liquid liquid = this.liquids.current();
          float amount1 = ((ConsumeLiquidBase) this.this\u00240.__\u003C\u003Econsumes.get(ConsumeType.__\u003C\u003Eliquid)).__\u003C\u003Eamount;
          float amount2 = (!this.cheating() ? Math.min(this.liquids.get(liquid), amount1 * Time.delta) : amount1 * Time.delta) * liquid.heatCapacity * this.this\u00240.coolantMultiplier;
          this.reload -= amount2;
          this.liquids.remove(liquid, amount2);
          if (!Mathf.chance(0.06 * (double) amount2))
            return;
          this.this\u00240.coolEffect.at(this.x + Mathf.range((float) (this.this\u00240.size * 8) / 2f), this.y + Mathf.range((float) (this.this\u00240.size * 8) / 2f));
        }
      }

      [LineNumberTable(new byte[] {32, 117, 161, 125, 135, 135, 145})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      protected internal override void updateShooting()
      {
        if ((double) this.bulletLife > 0.0 && this.bullet != null || (double) this.reload > 0.0 || !this.consValid() && !this.cheating())
          return;
        this.shoot(this.peekAmmo());
        this.reload = this.this\u00240.reloadTime;
      }

      [LineNumberTable(new byte[] {47, 127, 51})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      protected internal override void turnToTarget(float targetRot) => this.rotation = Angles.moveToward(this.rotation, targetRot, this.efficiency() * this.this\u00240.rotateSpeed * this.delta() * ((double) this.bulletLife <= 0.0 ? 1f : this.this\u00240.firingMoveFract));

      [LineNumberTable(new byte[] {52, 127, 48, 113})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      protected internal override void bullet(BulletType type, float angle)
      {
        this.bullet = type.create((Entityc) this.tile.build, this.team, this.x + this.this\u00240.tr.x, this.y + this.this\u00240.tr.y, angle);
        this.bulletLife = this.this\u00240.shootDuration;
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      public override bool shouldActiveSound() => (double) this.bulletLife > 0.0 && this.bullet != null;

      [HideFromJava]
      static LaserTurretBuild() => PowerTurret.PowerTurretBuild.__\u003Cclinit\u003E();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon0 : Boolf
    {
      internal __\u003C\u003EAnon0()
      {
      }

      public bool get([In] object obj0) => (LaserTurret.lambda\u0024new\u00240((Liquid) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon1 : Boolf
    {
      internal __\u003C\u003EAnon1()
      {
      }

      public bool get([In] object obj0) => (LaserTurret.lambda\u0024init\u00241((Building) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon2 : Boolf
    {
      private readonly LaserTurret arg\u00241;

      internal __\u003C\u003EAnon2([In] LaserTurret obj0) => this.arg\u00241 = obj0;

      public bool get([In] object obj0) => (this.arg\u00241.lambda\u0024setStats\u00242((Liquid) obj0) ? 1 : 0) != 0;
    }
  }
}
