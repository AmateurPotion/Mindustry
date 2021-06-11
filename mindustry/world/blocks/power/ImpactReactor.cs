// Decompiled with JetBrains decompiler
// Type: mindustry.world.blocks.power.ImpactReactor
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
using arc.util;
using arc.util.io;
using IKVM.Attributes;
using java.lang;
using mindustry.content;
using mindustry.entities;
using mindustry.game;
using mindustry.gen;
using mindustry.graphics;
using mindustry.logic;
using mindustry.world.meta;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.world.blocks.power
{
  public class ImpactReactor : PowerGenerator
  {
    internal int __\u003C\u003EtimerUse;
    public float warmupSpeed;
    public float itemDuration;
    public int explosionRadius;
    public int explosionDamage;
    public Color plasma1;
    public Color plasma2;
    public TextureRegion bottomRegion;
    public TextureRegion[] plasmaRegions;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [Modifiers]
    [LineNumberTable(49)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private mindustry.ui.Bar lambda\u0024setBars\u00243([In] PowerGenerator.GeneratorBuild obj0)
    {
      mindustry.ui.Bar.__\u003Cclinit\u003E();
      return new mindustry.ui.Bar((Prov) new ImpactReactor.__\u003C\u003EAnon1(this, obj0), (Prov) new ImpactReactor.__\u003C\u003EAnon2(), (Floatp) new ImpactReactor.__\u003C\u003EAnon3(obj0));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {0, 115, 63, 26})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private string lambda\u0024setBars\u00240([In] PowerGenerator.GeneratorBuild obj0) => Core.bundle.format("bar.poweroutput", (object) Strings.@fixed(Math.max(obj0.getPowerProduction() - this.__\u003C\u003Econsumes.getPower().__\u003C\u003Eusage, 0.0f) * 60f * obj0.timeScale, 1));

    [Modifiers]
    [LineNumberTable(52)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static Color lambda\u0024setBars\u00241() => Pal.powerBar;

    [Modifiers]
    [LineNumberTable(53)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static float lambda\u0024setBars\u00242([In] PowerGenerator.GeneratorBuild obj0) => obj0.productionEfficiency;

    [LineNumberTable(new byte[] {159, 178, 233, 51, 153, 107, 107, 104, 139, 255, 1, 71, 103, 103, 107, 103, 114, 127, 2})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ImpactReactor(string name)
      : base(name)
    {
      ImpactReactor impactReactor1 = this;
      ImpactReactor impactReactor2 = this;
      int timers = impactReactor2.timers;
      ImpactReactor impactReactor3 = impactReactor2;
      int num1 = timers;
      impactReactor3.timers = timers + 1;
      this.__\u003C\u003EtimerUse = num1;
      this.warmupSpeed = 1f / 1000f;
      this.itemDuration = 60f;
      this.explosionRadius = 23;
      this.explosionDamage = 1900;
      this.plasma1 = Color.valueOf("ffd06b");
      this.plasma2 = Color.valueOf("ff361b");
      this.hasPower = true;
      this.hasLiquids = true;
      this.liquidCapacity = 30f;
      this.hasItems = true;
      ImpactReactor impactReactor4 = this;
      int num2 = 1;
      int num3 = num2;
      this.consumesPower = num2 != 0;
      this.outputsPower = num3 != 0;
      this.flags = EnumSet.of((Enum[]) new BlockFlag[2]
      {
        BlockFlag.__\u003C\u003Ereactor,
        BlockFlag.__\u003C\u003Egenerator
      });
    }

    [LineNumberTable(new byte[] {159, 189, 134, 251, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setBars()
    {
      base.setBars();
      this.__\u003C\u003Ebars.add("poweroutput", (Func) new ImpactReactor.__\u003C\u003EAnon0(this));
    }

    [LineNumberTable(new byte[] {8, 134, 104, 159, 3})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setStats()
    {
      base.setStats();
      if (!this.hasItems)
        return;
      this.stats.add(Stat.__\u003C\u003EproductionTime, this.itemDuration / 60f, StatUnit.__\u003C\u003Eseconds);
    }

    [LineNumberTable(67)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override TextureRegion[] icons() => new TextureRegion[2]
    {
      this.bottomRegion,
      this.region
    };

    [HideFromJava]
    static ImpactReactor() => PowerGenerator.__\u003Cclinit\u003E();

    [Modifiers]
    public int timerUse
    {
      [HideFromJava] get => this.__\u003C\u003EtimerUse;
      [HideFromJava] [param: In] private set => this.__\u003C\u003EtimerUse = value;
    }

    public class ImpactReactorBuild : PowerGenerator.GeneratorBuild
    {
      public float warmup;
      [Modifiers]
      internal ImpactReactor this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [Modifiers]
      [LineNumberTable(145)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024onDestroyed\u00240() => Fx.__\u003C\u003Eimpactcloud.at(this.x, this.y);

      [Modifiers]
      [LineNumberTable(new byte[] {103, 118, 127, 15})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024onDestroyed\u00241()
      {
        Tmp.__\u003C\u003Ev1.rnd(Mathf.random(40f));
        Fx.__\u003C\u003Eexplosion.at(Tmp.__\u003C\u003Ev1.x + this.x, Tmp.__\u003C\u003Ev1.y + this.y);
      }

      [Modifiers]
      [LineNumberTable(new byte[] {110, 118, 127, 15})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024onDestroyed\u00242()
      {
        Tmp.__\u003C\u003Ev1.rnd(Mathf.random(120f));
        Fx.__\u003C\u003Eimpactsmoke.at(Tmp.__\u003C\u003Ev1.x + this.x, Tmp.__\u003C\u003Ev1.y + this.y);
      }

      [LineNumberTable(70)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public ImpactReactorBuild(ImpactReactor _param1)
      {
        this.this\u00240 = _param1;
        // ISSUE: explicit constructor call
        base.\u002Ector((PowerGenerator) _param1);
      }

      [LineNumberTable(new byte[] {25, 127, 1, 159, 5, 127, 11, 119, 171, 127, 4, 170, 127, 7, 134, 98, 188, 119})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void updateTile()
      {
        if (this.consValid() && (double) this.power.status >= 0.990000009536743)
        {
          int num = (double) this.getPowerProduction() <= (double) this.this\u00240.__\u003C\u003Econsumes.getPower().requestedPower((Building) this) ? 1 : 0;
          this.warmup = Mathf.lerpDelta(this.warmup, 1f, this.this\u00240.warmupSpeed * this.timeScale);
          if (Mathf.equal(this.warmup, 1f, 1f / 1000f))
            this.warmup = 1f;
          if (num == 0 && (double) this.getPowerProduction() > (double) this.this\u00240.__\u003C\u003Econsumes.getPower().requestedPower((Building) this))
            Events.fire((object) EventType.Trigger.__\u003C\u003EimpactPower);
          if (this.timer(this.this\u00240.__\u003C\u003EtimerUse, this.this\u00240.itemDuration / this.timeScale))
            this.consume();
        }
        else
          this.warmup = Mathf.lerpDelta(this.warmup, 0.0f, 0.01f);
        this.productionEfficiency = Mathf.pow(this.warmup, 5f);
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      public override float ambientVolume() => this.warmup;

      [LineNumberTable(new byte[] {54, 156, 116, 159, 36, 127, 13, 127, 32, 106, 127, 32, 229, 57, 233, 74, 133, 156, 101})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void draw()
      {
        Draw.rect(this.this\u00240.bottomRegion, this.x, this.y);
        for (int index = 0; index < this.this\u00240.plasmaRegions.Length; ++index)
        {
          float num = (float) (this.this\u00240.size * 8) - 3f + Mathf.absin(Time.time, 2f + (float) index * 1f, 5f - (float) index * 0.5f);
          Draw.color(this.this\u00240.plasma1, this.this\u00240.plasma2, (float) index / (float) this.this\u00240.plasmaRegions.Length);
          Draw.alpha((0.3f + Mathf.absin(Time.time, 2f + (float) index * 2f, 0.3f + (float) index * 0.05f)) * this.warmup);
          Draw.blend(Blending.__\u003C\u003Eadditive);
          Draw.rect(this.this\u00240.plasmaRegions[index], this.x, this.y, num, num, Time.time * (12f + (float) index * 6f) * this.warmup);
          Draw.blend();
        }
        Draw.color();
        Draw.rect(this.this\u00240.region, this.x, this.y);
        Draw.color();
      }

      [LineNumberTable(new byte[] {75, 127, 89})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void drawLight() => Drawf.light(this.team, this.x, this.y, (110f + Mathf.absin(5f, 5f)) * this.warmup, Tmp.__\u003C\u003Ec1.set(this.this\u00240.plasma2).lerp(this.this\u00240.plasma1, Mathf.absin(7f, 0.2f)), 0.8f * this.warmup);

      [LineNumberTable(new byte[] {80, 117})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override double sense(LAccess sensor) => object.ReferenceEquals((object) sensor, (object) LAccess.__\u003C\u003Eheat) ? (double) this.warmup : base.sense(sensor);

      [LineNumberTable(new byte[] {86, 134, 159, 0, 145, 123, 118, 102, 56, 198, 191, 14, 103, 56, 230, 71, 103, 56, 230, 70})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void onDestroyed()
      {
        base.onDestroyed();
        if ((double) this.warmup < 0.400000005960464 || !Vars.state.rules.reactorExplosions)
          return;
        Sounds.explosionbig.at((Position) this.tile);
        Effect.shake(6f, 16f, this.x, this.y);
        Fx.__\u003C\u003EimpactShockwave.at(this.x, this.y);
        for (int index = 0; index < 6; ++index)
          Time.run((float) Mathf.random(80), (Runnable) new ImpactReactor.ImpactReactorBuild.__\u003C\u003EAnon0(this));
        Damage.damage(this.x, this.y, (float) (this.this\u00240.explosionRadius * 8), (float) (this.this\u00240.explosionDamage * 4));
        for (int index = 0; index < 20; ++index)
          Time.run((float) Mathf.random(80), (Runnable) new ImpactReactor.ImpactReactorBuild.__\u003C\u003EAnon1(this));
        for (int index = 0; index < 70; ++index)
          Time.run((float) Mathf.random(90), (Runnable) new ImpactReactor.ImpactReactorBuild.__\u003C\u003EAnon2(this));
      }

      [LineNumberTable(new byte[] {118, 103, 108})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void write(Writes write)
      {
        base.write(write);
        write.f(this.warmup);
      }

      [LineNumberTable(new byte[] {159, 99, 131, 104, 109})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void read(Reads read, byte revision)
      {
        int num = (int) (sbyte) revision;
        base.read(read, (byte) num);
        this.warmup = read.f();
      }

      [HideFromJava]
      static ImpactReactorBuild() => PowerGenerator.GeneratorBuild.__\u003Cclinit\u003E();

      [SpecialName]
      private new sealed class __\u003C\u003EAnon0 : Runnable
      {
        private readonly ImpactReactor.ImpactReactorBuild arg\u00241;

        internal __\u003C\u003EAnon0([In] ImpactReactor.ImpactReactorBuild obj0) => this.arg\u00241 = obj0;

        public void run() => this.arg\u00241.lambda\u0024onDestroyed\u00240();
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon1 : Runnable
      {
        private readonly ImpactReactor.ImpactReactorBuild arg\u00241;

        internal __\u003C\u003EAnon1([In] ImpactReactor.ImpactReactorBuild obj0) => this.arg\u00241 = obj0;

        public void run() => this.arg\u00241.lambda\u0024onDestroyed\u00241();
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon2 : Runnable
      {
        private readonly ImpactReactor.ImpactReactorBuild arg\u00241;

        internal __\u003C\u003EAnon2([In] ImpactReactor.ImpactReactorBuild obj0) => this.arg\u00241 = obj0;

        public void run() => this.arg\u00241.lambda\u0024onDestroyed\u00242();
      }
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon0 : Func
    {
      private readonly ImpactReactor arg\u00241;

      internal __\u003C\u003EAnon0([In] ImpactReactor obj0) => this.arg\u00241 = obj0;

      public object get([In] object obj0) => (object) this.arg\u00241.lambda\u0024setBars\u00243((PowerGenerator.GeneratorBuild) obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon1 : Prov
    {
      private readonly ImpactReactor arg\u00241;
      private readonly PowerGenerator.GeneratorBuild arg\u00242;

      internal __\u003C\u003EAnon1([In] ImpactReactor obj0, [In] PowerGenerator.GeneratorBuild obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public object get() => (object) this.arg\u00241.lambda\u0024setBars\u00240(this.arg\u00242);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon2 : Prov
    {
      internal __\u003C\u003EAnon2()
      {
      }

      public object get() => (object) ImpactReactor.lambda\u0024setBars\u00241();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon3 : Floatp
    {
      private readonly PowerGenerator.GeneratorBuild arg\u00241;

      internal __\u003C\u003EAnon3([In] PowerGenerator.GeneratorBuild obj0) => this.arg\u00241 = obj0;

      public float get() => ImpactReactor.lambda\u0024setBars\u00242(this.arg\u00241);
    }
  }
}
