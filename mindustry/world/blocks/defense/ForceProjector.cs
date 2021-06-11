// Decompiled with JetBrains decompiler
// Type: mindustry.world.blocks.defense.ForceProjector
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
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
using mindustry.gen;
using mindustry.graphics;
using mindustry.logic;
using mindustry.type;
using mindustry.world.blocks.environment;
using mindustry.world.consumers;
using mindustry.world.meta;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.world.blocks.defense
{
  public class ForceProjector : Block
  {
    internal int __\u003C\u003EtimerUse;
    public float phaseUseTime;
    public float phaseRadiusBoost;
    public float phaseShieldBoost;
    public float radius;
    public float shieldHealth;
    public float cooldownNormal;
    public float cooldownLiquid;
    public float cooldownBrokenBase;
    public float basePowerDraw;
    public TextureRegion topRegion;
    internal static ForceProjector.ForceBuild paramEntity;
    [Modifiers]
    [Signature("Larc/func/Cons<Lmindustry/gen/Bullet;>;")]
    internal static Cons shieldConsumer;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [Modifiers]
    [LineNumberTable(57)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024new\u00241([In] Liquid obj0) => (double) obj0.temperature <= 0.5 && (double) obj0.flammability < 0.100000001490116;

    [Modifiers]
    [LineNumberTable(63)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private mindustry.ui.Bar lambda\u0024setBars\u00243([In] ForceProjector.ForceBuild obj0)
    {
      mindustry.ui.Bar.__\u003Cclinit\u003E();
      return new mindustry.ui.Bar("stat.shieldhealth", Pal.accent, (Floatp) new ForceProjector.__\u003C\u003EAnon2(this, obj0)).blink(Color.__\u003C\u003Ewhite);
    }

    [Modifiers]
    [LineNumberTable(63)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private float lambda\u0024setBars\u00242([In] ForceProjector.ForceBuild obj0) => obj0.broken ? 0.0f : 1f - obj0.buildup / (this.shieldHealth + this.phaseShieldBoost * obj0.phaseHeat);

    [Modifiers]
    [LineNumberTable(new byte[] {159, 181, 127, 70, 102, 107, 111, 159, 6})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u00240([In] Bullet obj0)
    {
      if (object.ReferenceEquals((object) obj0.team, (object) ForceProjector.paramEntity.team) || !obj0.type.absorbable || !Intersector.isInsideHexagon(ForceProjector.paramEntity.x, ForceProjector.paramEntity.y, ForceProjector.paramEntity.realRadius() * 2f, obj0.x(), obj0.y()))
        return;
      obj0.absorb();
      Fx.__\u003C\u003Eabsorb.at((Position) obj0);
      ForceProjector.paramEntity.hit = 1f;
      ForceProjector.paramEntity.buildup += obj0.damage() * ForceProjector.paramEntity.warmup;
    }

    [LineNumberTable(new byte[] {159, 190, 233, 40, 121, 139, 107, 107, 107, 107, 107, 107, 107, 235, 79, 103, 103, 107, 103, 103, 103, 107, 107, 127, 17})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ForceProjector(string name)
      : base(name)
    {
      ForceProjector forceProjector1 = this;
      ForceProjector forceProjector2 = this;
      int timers = forceProjector2.timers;
      ForceProjector forceProjector3 = forceProjector2;
      int num = timers;
      forceProjector3.timers = timers + 1;
      this.__\u003C\u003EtimerUse = num;
      this.phaseUseTime = 350f;
      this.phaseRadiusBoost = 80f;
      this.phaseShieldBoost = 400f;
      this.radius = 101.7f;
      this.shieldHealth = 700f;
      this.cooldownNormal = 1.75f;
      this.cooldownLiquid = 1.5f;
      this.cooldownBrokenBase = 0.35f;
      this.basePowerDraw = 0.2f;
      this.update = true;
      this.solid = true;
      this.group = BlockGroup.__\u003C\u003Eprojectors;
      this.hasPower = true;
      this.hasLiquids = true;
      this.hasItems = true;
      this.ambientSound = Sounds.shield;
      this.ambientSoundVolume = 0.08f;
      this.__\u003C\u003Econsumes.add((Consume) new ConsumeLiquidFilter((Boolf) new ForceProjector.__\u003C\u003EAnon0(), 0.1f)).boost().update(false);
    }

    [LineNumberTable(new byte[] {12, 102, 123})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setBars()
    {
      base.setBars();
      this.__\u003C\u003Ebars.add("shield", (Func) new ForceProjector.__\u003C\u003EAnon1(this));
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool outputsItems() => false;

    [LineNumberTable(new byte[] {23, 102, 123, 127, 17, 127, 3, 127, 3, 123})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setStats()
    {
      base.setStats();
      this.stats.add(Stat.__\u003C\u003EshieldHealth, this.shieldHealth, StatUnit.__\u003C\u003Enone);
      this.stats.add(Stat.__\u003C\u003EcooldownTime, (float) ByteCodeHelper.f2i(this.shieldHealth / this.cooldownBrokenBase / 60f), StatUnit.__\u003C\u003Eseconds);
      this.stats.add(Stat.__\u003C\u003EpowerUse, this.basePowerDraw * 60f, StatUnit.__\u003C\u003EpowerSecond);
      this.stats.add(Stat.__\u003C\u003EboostEffect, this.phaseRadiusBoost / 8f, StatUnit.__\u003C\u003Eblocks);
      this.stats.add(Stat.__\u003C\u003EboostEffect, this.phaseShieldBoost, StatUnit.__\u003C\u003EshieldHealth);
    }

    [LineNumberTable(new byte[] {159, 122, 163, 138, 106, 106, 127, 5, 116, 106, 127, 5, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void drawPlace(int x, int y, int rotation, bool valid)
    {
      int num = valid ? 1 : 0;
      base.drawPlace(x, y, rotation, num != 0);
      Draw.color(Pal.gray);
      Lines.stroke(3f);
      Lines.poly((float) (x * 8) + this.offset, (float) (y * 8) + this.offset, 6, this.radius);
      Draw.color(Vars.player.team().__\u003C\u003Ecolor);
      Lines.stroke(1f);
      Lines.poly((float) (x * 8) + this.offset, (float) (y * 8) + this.offset, 6, this.radius);
      Draw.color();
    }

    [LineNumberTable(38)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static ForceProjector()
    {
      Block.__\u003Cclinit\u003E();
      if (ByteCodeHelper.isAlreadyInited("mindustry.world.blocks.defense.ForceProjector"))
        return;
      ForceProjector.shieldConsumer = (Cons) new ForceProjector.__\u003C\u003EAnon3();
    }

    [Modifiers]
    public int timerUse
    {
      [HideFromJava] get => this.__\u003C\u003EtimerUse;
      [HideFromJava] [param: In] private set => this.__\u003C\u003EtimerUse = value;
    }

    [Implements(new string[] {"mindustry.logic.Ranged"})]
    public class ForceBuild : Building, Ranged, Posc, Position, Entityc, Teamc
    {
      public bool broken;
      public float buildup;
      public float radscl;
      public float hit;
      public float warmup;
      public float phaseHeat;
      public ForceDraw drawer;
      [Modifiers]
      internal ForceProjector this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(178)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual float realRadius() => (this.this\u00240.radius + this.phaseHeat * this.this\u00240.phaseRadiusBoost) * this.radscl;

      [LineNumberTable(new byte[] {160, 91, 107, 136, 138, 159, 2, 113, 149, 106, 127, 0, 115, 106, 115, 197, 101})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void drawShield()
      {
        if (!this.broken)
        {
          float radius = this.realRadius();
          Draw.z(125f);
          Draw.color(this.team.__\u003C\u003Ecolor, Color.__\u003C\u003Ewhite, Mathf.clamp(this.hit));
          if (Core.settings.getBool("animatedshields"))
          {
            Fill.poly(this.x, this.y, 6, radius);
          }
          else
          {
            Lines.stroke(1.5f);
            Draw.alpha(0.09f + Mathf.clamp(0.08f * this.hit));
            Fill.poly(this.x, this.y, 6, radius);
            Draw.alpha(1f);
            Lines.poly(this.x, this.y, 6, radius);
            Draw.reset();
          }
        }
        Draw.reset();
      }

      [LineNumberTable(new byte[] {44, 111})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public ForceBuild(ForceProjector _param1)
      {
        this.this\u00240 = _param1;
        // ISSUE: explicit constructor call
        base.\u002Ector();
        ForceProjector.ForceBuild forceBuild = this;
        this.broken = true;
      }

      [LineNumberTable(101)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual float range() => this.realRadius();

      [LineNumberTable(new byte[] {56, 102, 107, 108, 119, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void created()
      {
        base.created();
        this.drawer = ForceDraw.create();
        this.drawer.build = this;
        this.drawer.set(this.x, this.y);
        this.drawer.add();
      }

      [LineNumberTable(115)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override bool shouldAmbientSound() => !this.broken && (double) this.realRadius() > 1.0;

      [LineNumberTable(new byte[] {70, 104, 127, 19, 102, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void onRemoved()
      {
        float rotation = this.realRadius();
        if (!this.broken && (double) rotation > 1.0)
          Fx.__\u003C\u003EforceShrink.at(this.x, this.y, rotation, this.team.__\u003C\u003Ecolor);
        base.onRemoved();
        this.drawer.remove();
      }

      [LineNumberTable(new byte[] {78, 156, 158, 127, 24, 166, 159, 13, 127, 3, 191, 17, 158, 112, 127, 2, 123, 105, 103, 191, 23, 184, 117, 167, 127, 17, 103, 113, 191, 9, 109, 186, 136, 112, 102, 159, 18})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void updateTile()
      {
        int num1 = this.this\u00240.__\u003C\u003Econsumes.get(ConsumeType.__\u003C\u003Eitem).valid((Building) this) ? 1 : 0;
        this.phaseHeat = Mathf.lerpDelta(this.phaseHeat, (float) Mathf.num(num1 != 0), 0.1f);
        if (num1 != 0 && !this.broken && (this.timer(this.this\u00240.__\u003C\u003EtimerUse, this.this\u00240.phaseUseTime) && (double) this.efficiency() > 0.0))
          this.consume();
        this.radscl = Mathf.lerpDelta(this.radscl, !this.broken ? this.warmup : 0.0f, 0.05f);
        if (Mathf.chanceDelta((double) (this.buildup / this.this\u00240.shieldHealth * 0.1f)))
          Fx.__\u003C\u003Ereactorsmoke.at(this.x + Mathf.range(4f), this.y + Mathf.range(4f));
        this.warmup = Mathf.lerpDelta(this.warmup, this.efficiency(), 0.1f);
        if ((double) this.buildup > 0.0)
        {
          float num2 = this.broken ? this.this\u00240.cooldownBrokenBase : this.this\u00240.cooldownNormal;
          ConsumeLiquidFilter consumeLiquidFilter = (ConsumeLiquidFilter) this.this\u00240.__\u003C\u003Econsumes.get(ConsumeType.__\u003C\u003Eliquid);
          if (consumeLiquidFilter.valid((Building) this))
          {
            consumeLiquidFilter.update((Building) this);
            num2 *= this.this\u00240.cooldownLiquid * (1f + (this.liquids.current().heatCapacity - 0.4f) * 0.9f);
          }
          this.buildup -= this.delta() * num2;
        }
        if (this.broken && (double) this.buildup <= 0.0)
          this.broken = false;
        if ((double) this.buildup >= (double) (this.this\u00240.shieldHealth + this.this\u00240.phaseShieldBoost * this.phaseHeat) && !this.broken)
        {
          this.broken = true;
          this.buildup = this.this\u00240.shieldHealth;
          Fx.__\u003C\u003EshieldBreak.at(this.x, this.y, this.realRadius(), this.team.__\u003C\u003Ecolor);
        }
        if ((double) this.hit > 0.0)
          this.hit -= 0.2f * Time.delta;
        float num3 = this.realRadius();
        if ((double) num3 <= 0.0 || this.broken)
          return;
        ForceProjector.paramEntity = this;
        Groups.bullet.intersect(this.x - num3, this.y - num3, num3 * 2f, num3 * 2f, ForceProjector.shieldConsumer);
      }

      [LineNumberTable(new byte[] {160, 69, 117})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override double sense(LAccess sensor) => object.ReferenceEquals((object) sensor, (object) LAccess.__\u003C\u003Eheat) ? (double) this.buildup : base.sense(sensor);

      [LineNumberTable(new byte[] {160, 75, 134, 104, 183, 109, 127, 0, 106, 124, 101, 133})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void draw()
      {
        base.draw();
        if (this.drawer != null)
          this.drawer.set(this.x, this.y);
        if ((double) this.buildup <= 0.0)
          return;
        Draw.alpha(this.buildup / this.this\u00240.shieldHealth * 0.75f);
        Draw.blend(Blending.__\u003C\u003Eadditive);
        Draw.rect(this.this\u00240.topRegion, this.x, this.y);
        Draw.blend();
        Draw.reset();
      }

      [LineNumberTable(new byte[] {160, 115, 103, 108, 108, 108, 108, 108})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void write(Writes write)
      {
        base.write(write);
        write.@bool(this.broken);
        write.f(this.buildup);
        write.f(this.radscl);
        write.f(this.warmup);
        write.f(this.phaseHeat);
      }

      [LineNumberTable(new byte[] {159, 83, 163, 104, 108, 109, 109, 109, 109})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void read(Reads read, byte revision)
      {
        int num = (int) (sbyte) revision;
        base.read(read, (byte) num);
        this.broken = read.@bool();
        this.buildup = read.f();
        this.radscl = read.f();
        this.warmup = read.f();
        this.phaseHeat = read.f();
      }

      [HideFromJava]
      public override float angleTo([In] Position obj0) => Position.\u003Cdefault\u003EangleTo((Position) this, obj0);

      [HideFromJava]
      public override float angleTo([In] float obj0, [In] float obj1) => Position.\u003Cdefault\u003EangleTo((Position) this, obj0, obj1);

      [HideFromJava]
      public override float dst2([In] Position obj0) => Position.\u003Cdefault\u003Edst2((Position) this, obj0);

      [HideFromJava]
      public override float dst([In] Position obj0) => Position.\u003Cdefault\u003Edst((Position) this, obj0);

      [HideFromJava]
      public override float dst([In] float obj0, [In] float obj1) => Position.\u003Cdefault\u003Edst((Position) this, obj0, obj1);

      [HideFromJava]
      public override float dst2([In] float obj0, [In] float obj1) => Position.\u003Cdefault\u003Edst2((Position) this, obj0, obj1);

      [HideFromJava]
      public override bool within([In] Position obj0, [In] float obj1) => Position.\u003Cdefault\u003Ewithin((Position) this, obj0, obj1);

      [HideFromJava]
      public override bool within([In] float obj0, [In] float obj1, [In] float obj2) => Position.\u003Cdefault\u003Ewithin((Position) this, obj0, obj1, obj2);

      [HideFromJava]
      static ForceBuild() => Building.__\u003Cclinit\u003E();
    }

    [Implements(new string[] {"mindustry.gen.Drawc"})]
    internal abstract class ForceDrawComp : Object, Drawc, Posc, Position, Entityc
    {
      [NonSerialized]
      internal ForceProjector.ForceBuild build;
      [Modifiers]
      internal ForceProjector this\u00240;

      [LineNumberTable(250)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal ForceDrawComp([In] ForceProjector obj0)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector();
      }

      [LineNumberTable(new byte[] {160, 141, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void draw() => this.build.drawShield();

      [LineNumberTable(261)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual float clipSize() => this.build.realRadius() * 3f;

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
      public abstract Entityc self();

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
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon0 : Boolf
    {
      internal __\u003C\u003EAnon0()
      {
      }

      public bool get([In] object obj0) => (ForceProjector.lambda\u0024new\u00241((Liquid) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon1 : Func
    {
      private readonly ForceProjector arg\u00241;

      internal __\u003C\u003EAnon1([In] ForceProjector obj0) => this.arg\u00241 = obj0;

      public object get([In] object obj0) => (object) this.arg\u00241.lambda\u0024setBars\u00243((ForceProjector.ForceBuild) obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon2 : Floatp
    {
      private readonly ForceProjector arg\u00241;
      private readonly ForceProjector.ForceBuild arg\u00242;

      internal __\u003C\u003EAnon2([In] ForceProjector obj0, [In] ForceProjector.ForceBuild obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public float get() => this.arg\u00241.lambda\u0024setBars\u00242(this.arg\u00242);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon3 : Cons
    {
      internal __\u003C\u003EAnon3()
      {
      }

      public void get([In] object obj0) => ForceProjector.lambda\u0024static\u00240((Bullet) obj0);
    }
  }
}
