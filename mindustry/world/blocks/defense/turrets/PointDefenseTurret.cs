// Decompiled with JetBrains decompiler
// Type: mindustry.world.blocks.defense.turrets.PointDefenseTurret
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
using mindustry.content;
using mindustry.entities;
using mindustry.gen;
using mindustry.graphics;
using mindustry.world.meta;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.world.blocks.defense.turrets
{
  public class PointDefenseTurret : ReloadTurret
  {
    internal int __\u003C\u003EtimerTarget;
    public float retargetTime;
    public TextureRegion baseRegion;
    public Color color;
    public Effect beamEffect;
    public Effect hitEffect;
    public Effect shootEffect;
    public Sound shootSound;
    public float shootCone;
    public float bulletDamage;
    public float shootLength;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 177, 233, 47, 121, 203, 107, 107, 107, 139, 139, 107, 107, 235, 69, 107, 139, 139, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public PointDefenseTurret(string name)
      : base(name)
    {
      PointDefenseTurret pointDefenseTurret1 = this;
      PointDefenseTurret pointDefenseTurret2 = this;
      int timers = pointDefenseTurret2.timers;
      PointDefenseTurret pointDefenseTurret3 = pointDefenseTurret2;
      int num = timers;
      pointDefenseTurret3.timers = timers + 1;
      this.__\u003C\u003EtimerTarget = num;
      this.retargetTime = 5f;
      this.color = Color.__\u003C\u003Ewhite;
      this.beamEffect = Fx.__\u003C\u003EpointBeam;
      this.hitEffect = Fx.__\u003C\u003EpointHit;
      this.shootEffect = Fx.__\u003C\u003EsparkShoot;
      this.shootSound = Sounds.lasershoot;
      this.shootCone = 5f;
      this.bulletDamage = 10f;
      this.shootLength = 3f;
      this.rotateSpeed = 20f;
      this.reloadTime = 30f;
      this.coolantMultiplier = 2f;
      this.acceptCoolant = false;
    }

    [LineNumberTable(47)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override TextureRegion[] icons() => new TextureRegion[2]
    {
      this.baseRegion,
      this.region
    };

    [LineNumberTable(new byte[] {2, 134, 127, 3})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setStats()
    {
      base.setStats();
      this.stats.add(Stat.__\u003C\u003Ereload, 60f / this.reloadTime, StatUnit.__\u003C\u003Enone);
    }

    [HideFromJava]
    static PointDefenseTurret() => ReloadTurret.__\u003Cclinit\u003E();

    [Modifiers]
    public int timerTarget
    {
      [HideFromJava] get => this.__\u003C\u003EtimerTarget;
      [HideFromJava] [param: In] private set => this.__\u003C\u003EtimerTarget = value;
    }

    public class PointDefenseBuild : ReloadTurret.ReloadTurretBuild
    {
      [Nullable(new object[] {64, "Larc/util/Nullable;"})]
      public Bullet target;
      [Modifiers]
      internal PointDefenseTurret this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [Modifiers]
      [LineNumberTable(65)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private bool lambda\u0024updateTile\u00240([In] Bullet obj0) => !object.ReferenceEquals((object) obj0.team, (object) this.team) && obj0.type().hittable;

      [Modifiers]
      [LineNumberTable(65)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private float lambda\u0024updateTile\u00241([In] Bullet obj0) => obj0.dst2((Position) this);

      [LineNumberTable(57)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public PointDefenseBuild(PointDefenseTurret _param1)
      {
        this.this\u00240 = _param1;
        // ISSUE: explicit constructor call
        base.\u002Ector((ReloadTurret) _param1);
      }

      [LineNumberTable(new byte[] {14, 126, 223, 91, 117, 167, 109, 198, 127, 72, 110, 127, 8, 181, 127, 19, 121, 159, 7, 171, 156, 127, 54, 127, 38, 127, 18, 127, 38, 171})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void updateTile()
      {
        if (this.timer(this.this\u00240.__\u003C\u003EtimerTarget, this.this\u00240.retargetTime))
          this.target = (Bullet) Groups.bullet.intersect(this.x - this.this\u00240.range, this.y - this.this\u00240.range, this.this\u00240.range * 2f, this.this\u00240.range * 2f).min((Boolf) new PointDefenseTurret.PointDefenseBuild.__\u003C\u003EAnon0(this), (Floatf) new PointDefenseTurret.PointDefenseBuild.__\u003C\u003EAnon1(this));
        if (this.target != null && !this.target.isAdded())
          this.target = (Bullet) null;
        if (this.this\u00240.acceptCoolant)
          this.updateCooling();
        if (this.target == null || !this.target.within((Position) this, this.this\u00240.range) || (object.ReferenceEquals((object) this.target.team, (object) this.team) || this.target.type() == null) || !this.target.type().hittable)
          return;
        float num = this.angleTo((Position) this.target);
        this.rotation = Angles.moveToward(this.rotation, num, this.this\u00240.rotateSpeed * this.edelta());
        this.reload += this.edelta();
        if (!Angles.within(this.rotation, num, this.this\u00240.shootCone) || (double) this.reload < (double) this.this\u00240.reloadTime)
          return;
        if ((double) this.target.damage() > (double) this.this\u00240.bulletDamage)
          this.target.damage(this.target.damage() - this.this\u00240.bulletDamage);
        else
          this.target.remove();
        Tmp.__\u003C\u003Ev1.trns(this.rotation, this.this\u00240.shootLength);
        this.this\u00240.beamEffect.at(this.x + Tmp.__\u003C\u003Ev1.x, this.y + Tmp.__\u003C\u003Ev1.y, this.rotation, this.this\u00240.color, (object) new Vec2().set((Position) this.target));
        this.this\u00240.shootEffect.at(this.x + Tmp.__\u003C\u003Ev1.x, this.y + Tmp.__\u003C\u003Ev1.y, this.rotation, this.this\u00240.color);
        this.this\u00240.hitEffect.at(this.target.x, this.target.y, this.this\u00240.color);
        this.this\u00240.shootSound.at(this.x + Tmp.__\u003C\u003Ev1.x, this.y + Tmp.__\u003C\u003Ev1.y, Mathf.random(0.9f, 1.1f));
        this.reload = 0.0f;
      }

      [LineNumberTable(new byte[] {54, 124, 127, 52, 127, 10})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void draw()
      {
        Draw.rect(this.this\u00240.baseRegion, this.x, this.y);
        Drawf.shadow(this.this\u00240.region, this.x - (float) this.this\u00240.size / 2f, this.y - (float) this.this\u00240.size / 2f, this.rotation - 90f);
        Draw.rect(this.this\u00240.region, this.x, this.y, this.rotation - 90f);
      }

      [LineNumberTable(new byte[] {61, 135, 108})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void write(Writes write)
      {
        base.write(write);
        write.f(this.rotation);
      }

      [LineNumberTable(new byte[] {159, 113, 131, 136, 109})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void read(Reads read, byte revision)
      {
        int num = (int) (sbyte) revision;
        base.read(read, (byte) num);
        this.rotation = read.f();
      }

      [HideFromJava]
      static PointDefenseBuild() => ReloadTurret.ReloadTurretBuild.__\u003Cclinit\u003E();

      [SpecialName]
      private new sealed class __\u003C\u003EAnon0 : Boolf
      {
        private readonly PointDefenseTurret.PointDefenseBuild arg\u00241;

        internal __\u003C\u003EAnon0([In] PointDefenseTurret.PointDefenseBuild obj0) => this.arg\u00241 = obj0;

        public bool get([In] object obj0) => (this.arg\u00241.lambda\u0024updateTile\u00240((Bullet) obj0) ? 1 : 0) != 0;
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon1 : Floatf
      {
        private readonly PointDefenseTurret.PointDefenseBuild arg\u00241;

        internal __\u003C\u003EAnon1([In] PointDefenseTurret.PointDefenseBuild obj0) => this.arg\u00241 = obj0;

        public float get([In] object obj0) => this.arg\u00241.lambda\u0024updateTile\u00241((Bullet) obj0);
      }
    }
  }
}
