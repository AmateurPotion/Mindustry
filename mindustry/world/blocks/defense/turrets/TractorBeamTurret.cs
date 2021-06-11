// Decompiled with JetBrains decompiler
// Type: mindustry.world.blocks.defense.turrets.TractorBeamTurret
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.audio;
using arc.func;
using arc.graphics;
using arc.graphics.g2d;
using arc.math;
using arc.math.geom;
using arc.util;
using arc.util.io;
using IKVM.Attributes;
using java.lang;
using mindustry.content;
using mindustry.entities;
using mindustry.gen;
using mindustry.graphics;
using mindustry.type;
using mindustry.world.consumers;
using mindustry.world.meta;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.world.blocks.defense.turrets
{
  public class TractorBeamTurret : BaseTurret
  {
    internal int __\u003C\u003EtimerTarget;
    public float retargetTime;
    public TextureRegion baseRegion;
    public TextureRegion laser;
    public TextureRegion laserEnd;
    public float shootCone;
    public float shootLength;
    public float laserWidth;
    public float force;
    public float scaledForce;
    public float damage;
    public bool targetAir;
    public bool targetGround;
    public Color laserColor;
    public StatusEffect status;
    public float statusDuration;
    public Sound shootSound;
    public float shootSoundVolume;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 185, 233, 42, 121, 235, 70, 107, 107, 107, 107, 107, 107, 110, 107, 107, 139, 107, 235, 69, 107, 171, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public TractorBeamTurret(string name)
      : base(name)
    {
      TractorBeamTurret tractorBeamTurret1 = this;
      TractorBeamTurret tractorBeamTurret2 = this;
      int timers = tractorBeamTurret2.timers;
      TractorBeamTurret tractorBeamTurret3 = tractorBeamTurret2;
      int num = timers;
      tractorBeamTurret3.timers = timers + 1;
      this.__\u003C\u003EtimerTarget = num;
      this.retargetTime = 5f;
      this.shootCone = 6f;
      this.shootLength = 5f;
      this.laserWidth = 0.6f;
      this.force = 0.3f;
      this.scaledForce = 0.0f;
      this.damage = 0.0f;
      this.targetAir = true;
      this.targetGround = false;
      this.laserColor = Color.__\u003C\u003Ewhite;
      this.status = StatusEffects.none;
      this.statusDuration = 300f;
      this.shootSound = Sounds.tractorbeam;
      this.shootSoundVolume = 0.9f;
      this.rotateSpeed = 10f;
      this.coolantMultiplier = 1f;
      this.acceptCoolant = false;
      this.expanded = true;
    }

    [LineNumberTable(55)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override TextureRegion[] icons() => new TextureRegion[2]
    {
      this.baseRegion,
      this.region
    };

    [LineNumberTable(new byte[] {10, 134, 118, 118, 127, 3})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setStats()
    {
      base.setStats();
      this.stats.add(Stat.__\u003C\u003EtargetsAir, this.targetAir);
      this.stats.add(Stat.__\u003C\u003EtargetsGround, this.targetGround);
      this.stats.add(Stat.__\u003C\u003Edamage, this.damage * 60f, StatUnit.__\u003C\u003EperSecond);
    }

    [HideFromJava]
    static TractorBeamTurret() => BaseTurret.__\u003Cclinit\u003E();

    [Modifiers]
    public int timerTarget
    {
      [HideFromJava] get => this.__\u003C\u003EtimerTarget;
      [HideFromJava] [param: In] private set => this.__\u003C\u003EtimerTarget = value;
    }

    public class TractorBeamBuild : BaseTurret.BaseTurretBuild
    {
      [Nullable(new object[] {64, "Larc/util/Nullable;"})]
      public Unit target;
      public float lastX;
      public float lastY;
      public float strength;
      public bool any;
      public float coolant;
      [Modifiers]
      internal TractorBeamTurret this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(132)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override float efficiency() => base.efficiency() * this.coolant;

      [Modifiers]
      [LineNumberTable(78)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private bool lambda\u0024updateTile\u00240([In] Unit obj0) => obj0.checkTarget(this.this\u00240.targetAir, this.this\u00240.targetGround);

      [LineNumberTable(new byte[] {17, 208})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public TractorBeamBuild(TractorBeamTurret _param1)
      {
        this.this\u00240 = _param1;
        // ISSUE: explicit constructor call
        base.\u002Ector((BaseTurret) _param1);
        TractorBeamTurret.TractorBeamBuild tractorBeamBuild = this;
        this.coolant = 1f;
      }

      [LineNumberTable(new byte[] {27, 126, 223, 20, 123, 159, 1, 140, 159, 40, 141, 116, 191, 55, 191, 4, 167, 127, 110, 103, 191, 7, 110, 127, 8, 113, 113, 188, 124, 114, 191, 0, 119, 191, 2, 103, 159, 83, 98, 156})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void updateTile()
      {
        if (this.timer(this.this\u00240.__\u003C\u003EtimerTarget, this.this\u00240.retargetTime))
          this.target = Units.closestEnemy(this.team, this.x, this.y, this.this\u00240.range, (Boolf) new TractorBeamTurret.TractorBeamBuild.__\u003C\u003EAnon0(this));
        if (this.target != null && this.this\u00240.acceptCoolant)
        {
          float amount1 = ((ConsumeLiquidBase) this.this\u00240.__\u003C\u003Econsumes.get(ConsumeType.__\u003C\u003Eliquid)).__\u003C\u003Eamount;
          Liquid liquid = this.liquids.current();
          float amount2 = Math.min(Math.min(this.liquids.get(liquid), amount1 * Time.delta), Math.max(0.0f, 1f / this.this\u00240.coolantMultiplier / liquid.heatCapacity));
          this.liquids.remove(liquid, amount2);
          if (Mathf.chance(0.06 * (double) amount2))
            this.this\u00240.coolEffect.at(this.x + Mathf.range((float) (this.this\u00240.size * 8) / 2f), this.y + Mathf.range((float) (this.this\u00240.size * 8) / 2f));
          this.coolant = 1f + amount2 * liquid.heatCapacity * this.this\u00240.coolantMultiplier;
        }
        this.any = false;
        if (this.target != null && this.target.within((Position) this, this.this\u00240.range + this.target.hitSize / 2f) && (!object.ReferenceEquals((object) this.target.team(), (object) this.team) && this.target.checkTarget(this.this\u00240.targetAir, this.this\u00240.targetGround)) && (double) this.efficiency() > 0.0199999995529652)
        {
          if (!Vars.headless)
            Vars.control.sound.loop(this.this\u00240.shootSound, (Position) this, this.this\u00240.shootSoundVolume);
          float num = this.angleTo((Position) this.target);
          this.rotation = Angles.moveToward(this.rotation, num, this.this\u00240.rotateSpeed * this.edelta());
          this.lastX = this.target.x;
          this.lastY = this.target.y;
          this.strength = Mathf.lerpDelta(this.strength, 1f, 0.1f);
          if (!Angles.within(this.rotation, num, this.this\u00240.shootCone))
            return;
          if ((double) this.this\u00240.damage > 0.0)
            this.target.damageContinuous(this.this\u00240.damage * this.efficiency());
          if (!object.ReferenceEquals((object) this.this\u00240.status, (object) StatusEffects.none))
            this.target.apply(this.this\u00240.status, this.this\u00240.statusDuration);
          this.any = true;
          this.target.impulseNet(Tmp.__\u003C\u003Ev1.set((Position) this).sub((Position) this.target).limit((this.this\u00240.force + (1f - this.target.dst((Position) this) / this.this\u00240.range) * this.this\u00240.scaledForce) * this.edelta() * this.timeScale));
        }
        else
          this.strength = Mathf.lerpDelta(this.strength, 0.0f, 0.1f);
      }

      [LineNumberTable(new byte[] {87, 124, 127, 52, 191, 10, 107, 106, 148, 159, 1, 127, 15, 127, 22, 21, 197, 133})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void draw()
      {
        Draw.rect(this.this\u00240.baseRegion, this.x, this.y);
        Drawf.shadow(this.this\u00240.region, this.x - (float) this.this\u00240.size / 2f, this.y - (float) this.this\u00240.size / 2f, this.rotation - 90f);
        Draw.rect(this.this\u00240.region, this.x, this.y, this.rotation - 90f);
        if (!this.any)
          return;
        Draw.z(100f);
        float angle = this.angleTo(this.lastX, this.lastY);
        Draw.mixcol(this.this\u00240.laserColor, Mathf.absin(4f, 0.6f));
        Drawf.laser(this.team, this.this\u00240.laser, this.this\u00240.laserEnd, this.x + Angles.trnsx(angle, this.this\u00240.shootLength), this.y + Angles.trnsy(angle, this.this\u00240.shootLength), this.lastX, this.lastY, this.strength * this.efficiency() * this.this\u00240.laserWidth);
        Draw.mixcol();
      }

      [LineNumberTable(new byte[] {108, 135, 108})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void write(Writes write)
      {
        base.write(write);
        write.f(this.rotation);
      }

      [LineNumberTable(new byte[] {159, 101, 99, 136, 109})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void read(Reads read, byte revision)
      {
        int num = (int) (sbyte) revision;
        base.read(read, (byte) num);
        this.rotation = read.f();
      }

      [HideFromJava]
      static TractorBeamBuild() => BaseTurret.BaseTurretBuild.__\u003Cclinit\u003E();

      [SpecialName]
      private new sealed class __\u003C\u003EAnon0 : Boolf
      {
        private readonly TractorBeamTurret.TractorBeamBuild arg\u00241;

        internal __\u003C\u003EAnon0([In] TractorBeamTurret.TractorBeamBuild obj0) => this.arg\u00241 = obj0;

        public bool get([In] object obj0) => (this.arg\u00241.lambda\u0024updateTile\u00240((Unit) obj0) ? 1 : 0) != 0;
      }
    }
  }
}
