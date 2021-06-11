// Decompiled with JetBrains decompiler
// Type: mindustry.world.blocks.power.NuclearReactor
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
using mindustry.type;
using mindustry.world.consumers;
using mindustry.world.meta;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.world.blocks.power
{
  public class NuclearReactor : PowerGenerator
  {
    internal int __\u003C\u003EtimerFuel;
    internal Vec2 __\u003C\u003Etr;
    public new Color lightColor;
    public Color coolColor;
    public Color hotColor;
    public float itemDuration;
    public float heating;
    public float smokeThreshold;
    public float flashThreshold;
    public int explosionRadius;
    public int explosionDamage;
    public float coolantPower;
    public TextureRegion topRegion;
    public TextureRegion lightsRegion;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [Modifiers]
    [LineNumberTable(72)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static mindustry.ui.Bar lambda\u0024setBars\u00241(
      [In] NuclearReactor.NuclearReactorBuild obj0)
    {
      mindustry.ui.Bar.__\u003Cclinit\u003E();
      return new mindustry.ui.Bar("bar.heat", Pal.lightOrange, (Floatp) new NuclearReactor.__\u003C\u003EAnon1(obj0));
    }

    [Modifiers]
    [LineNumberTable(72)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static float lambda\u0024setBars\u00240([In] NuclearReactor.NuclearReactorBuild obj0) => obj0.heat;

    [LineNumberTable(new byte[] {0, 233, 40, 153, 139, 112, 127, 0, 144, 139, 139, 139, 107, 104, 139, 235, 71, 104, 107, 103, 103, 103, 127, 2, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public NuclearReactor(string name)
      : base(name)
    {
      NuclearReactor nuclearReactor1 = this;
      NuclearReactor nuclearReactor2 = this;
      int timers = nuclearReactor2.timers;
      NuclearReactor nuclearReactor3 = nuclearReactor2;
      int num = timers;
      nuclearReactor3.timers = timers + 1;
      this.__\u003C\u003EtimerFuel = num;
      this.__\u003C\u003Etr = new Vec2();
      this.lightColor = Color.valueOf("7f19ea");
      this.coolColor = new Color(1f, 1f, 1f, 0.0f);
      this.hotColor = Color.valueOf("ff9575a3");
      this.itemDuration = 120f;
      this.heating = 0.01f;
      this.smokeThreshold = 0.3f;
      this.flashThreshold = 0.46f;
      this.explosionRadius = 19;
      this.explosionDamage = 1250;
      this.coolantPower = 0.5f;
      this.itemCapacity = 30;
      this.liquidCapacity = 30f;
      this.hasItems = true;
      this.hasLiquids = true;
      this.rebuildable = false;
      this.flags = EnumSet.of((Enum[]) new BlockFlag[2]
      {
        BlockFlag.__\u003C\u003Ereactor,
        BlockFlag.__\u003C\u003Egenerator
      });
      this.schematicPriority = -5;
    }

    [LineNumberTable(new byte[] {12, 134, 104, 159, 3})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setStats()
    {
      base.setStats();
      if (!this.hasItems)
        return;
      this.stats.add(Stat.__\u003C\u003EproductionTime, this.itemDuration / 60f, StatUnit.__\u003C\u003Eseconds);
    }

    [LineNumberTable(new byte[] {21, 102, 122})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setBars()
    {
      base.setBars();
      this.__\u003C\u003Ebars.add("heat", (Func) new NuclearReactor.__\u003C\u003EAnon0());
    }

    [HideFromJava]
    static NuclearReactor() => PowerGenerator.__\u003Cclinit\u003E();

    [Modifiers]
    public int timerFuel
    {
      [HideFromJava] get => this.__\u003C\u003EtimerFuel;
      [HideFromJava] [param: In] private set => this.__\u003C\u003EtimerFuel = value;
    }

    [Modifiers]
    public Vec2 tr
    {
      [HideFromJava] get => this.__\u003C\u003Etr;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Etr = value;
    }

    public class NuclearReactorBuild : PowerGenerator.GeneratorBuild
    {
      public float heat;
      [Modifiers]
      internal NuclearReactor this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [Modifiers]
      [LineNumberTable(140)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024onDestroyed\u00240() => Fx.__\u003C\u003Enuclearcloud.at(this.x, this.y);

      [Modifiers]
      [LineNumberTable(new byte[] {97, 124, 127, 27})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024onDestroyed\u00241()
      {
        this.this\u00240.__\u003C\u003Etr.rnd(Mathf.random(40f));
        Fx.__\u003C\u003Eexplosion.at(this.this\u00240.__\u003C\u003Etr.x + this.x, this.this\u00240.__\u003C\u003Etr.y + this.y);
      }

      [Modifiers]
      [LineNumberTable(new byte[] {104, 124, 127, 27})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024onDestroyed\u00242()
      {
        this.this\u00240.__\u003C\u003Etr.rnd(Mathf.random(120f));
        Fx.__\u003C\u003Enuclearsmoke.at(this.this\u00240.__\u003C\u003Etr.x + this.x, this.this\u00240.__\u003C\u003Etr.y + this.y);
      }

      [LineNumberTable(75)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public NuclearReactorBuild(NuclearReactor _param1)
      {
        this.this\u00240 = _param1;
        // ISSUE: explicit constructor call
        base.\u002Ector((PowerGenerator) _param1);
      }

      [LineNumberTable(new byte[] {30, 123, 157, 109, 113, 135, 108, 159, 17, 127, 7, 168, 171, 136, 109, 127, 10, 125, 175, 118, 127, 17, 127, 0, 127, 36, 40, 229, 69, 146, 109, 106, 134})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void updateTile()
      {
        ConsumeLiquid consumeLiquid = (ConsumeLiquid) this.this\u00240.__\u003C\u003Econsumes.get(ConsumeType.__\u003C\u003Eliquid);
        int num1 = this.items.get(this.this\u00240.__\u003C\u003Econsumes.getItem().__\u003C\u003Eitems[0].item);
        float num2 = (float) num1 / (float) this.this\u00240.itemCapacity;
        this.productionEfficiency = num2;
        if (num1 > 0 && this.enabled)
        {
          this.heat += num2 * this.this\u00240.heating * Math.min(this.delta(), 4f);
          if (this.timer(this.this\u00240.__\u003C\u003EtimerFuel, this.this\u00240.itemDuration / this.timeScale))
            this.consume();
        }
        else
          this.productionEfficiency = 0.0f;
        Liquid liquid = consumeLiquid.__\u003C\u003Eliquid;
        if ((double) this.heat > 0.0)
        {
          float amount = Math.min(this.liquids.get(liquid), this.heat / this.this\u00240.coolantPower);
          this.heat -= amount * this.this\u00240.coolantPower;
          this.liquids.remove(liquid, amount);
        }
        if ((double) this.heat > (double) this.this\u00240.smokeThreshold && Mathf.chance((double) (1f + (this.heat - this.this\u00240.smokeThreshold) / (1f - this.this\u00240.smokeThreshold)) / 20.0 * (double) this.delta()))
          Fx.__\u003C\u003Ereactorsmoke.at(this.x + Mathf.range((float) (this.this\u00240.size * 8) / 2f), this.y + Mathf.range((float) (this.this\u00240.size * 8) / 2f));
        this.heat = Mathf.clamp(this.heat);
        if ((double) this.heat < 0.999000012874603)
          return;
        Events.fire((object) EventType.Trigger.__\u003C\u003EthoriumReactorOverheat);
        this.kill();
      }

      [LineNumberTable(new byte[] {73, 117})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override double sense(LAccess sensor) => object.ReferenceEquals((object) sensor, (object) LAccess.__\u003C\u003Eheat) ? (double) this.heat : base.sense(sensor);

      [LineNumberTable(new byte[] {79, 134, 145, 159, 19, 159, 4, 123, 118, 102, 56, 198, 159, 14, 103, 56, 230, 71, 103, 56, 230, 70})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void onDestroyed()
      {
        base.onDestroyed();
        Sounds.explosionbig.at((Position) this.tile);
        if (this.items.get(((ConsumeItems) this.this\u00240.__\u003C\u003Econsumes.get(ConsumeType.__\u003C\u003Eitem)).__\u003C\u003Eitems[0].item) < 5 && (double) this.heat < 0.5 || !Vars.state.rules.reactorExplosions)
          return;
        Effect.shake(6f, 16f, this.x, this.y);
        Fx.__\u003C\u003EnuclearShockwave.at(this.x, this.y);
        for (int index = 0; index < 6; ++index)
          Time.run((float) Mathf.random(40), (Runnable) new NuclearReactor.NuclearReactorBuild.__\u003C\u003EAnon0(this));
        Damage.damage(this.x, this.y, (float) (this.this\u00240.explosionRadius * 8), (float) (this.this\u00240.explosionDamage * 4));
        for (int index = 0; index < 20; ++index)
          Time.run((float) Mathf.random(50), (Runnable) new NuclearReactor.NuclearReactorBuild.__\u003C\u003EAnon1(this));
        for (int index = 0; index < 70; ++index)
          Time.run((float) Mathf.random(80), (Runnable) new NuclearReactor.NuclearReactorBuild.__\u003C\u003EAnon2(this));
      }

      [LineNumberTable(new byte[] {112, 103, 127, 63})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void drawLight()
      {
        float productionEfficiency = this.productionEfficiency;
        Drawf.light(this.team, this.x, this.y, (90f + Mathf.absin(5f, 5f)) * productionEfficiency, Tmp.__\u003C\u003Ec1.set(this.this\u00240.lightColor).lerp(Color.__\u003C\u003Escarlet, this.heat), 0.6f * productionEfficiency);
      }

      [LineNumberTable(new byte[] {118, 134, 127, 2, 159, 14, 117, 126, 156, 118, 127, 23, 108, 127, 1, 106, 188, 101})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void draw()
      {
        base.draw();
        Draw.color(this.this\u00240.coolColor, this.this\u00240.hotColor, this.heat);
        Fill.rect(this.x, this.y, (float) (this.this\u00240.size * 8), (float) (this.this\u00240.size * 8));
        Draw.color(this.liquids.current().color);
        Draw.alpha(this.liquids.currentAmount() / this.this\u00240.liquidCapacity);
        Draw.rect(this.this\u00240.topRegion, this.x, this.y);
        if ((double) this.heat > (double) this.this\u00240.flashThreshold)
        {
          float num = 1f + (this.heat - this.this\u00240.flashThreshold) / (1f - this.this\u00240.flashThreshold) * 5.4f;
          float @in = num + num * Time.delta;
          Draw.color(Color.__\u003C\u003Ered, Color.__\u003C\u003Eyellow, Mathf.absin(@in, 9f, 1f));
          Draw.alpha(0.6f);
          Draw.rect(this.this\u00240.lightsRegion, this.x, this.y);
        }
        Draw.reset();
      }

      [LineNumberTable(new byte[] {160, 76, 103, 108})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void write(Writes write)
      {
        base.write(write);
        write.f(this.heat);
      }

      [LineNumberTable(new byte[] {159, 93, 67, 104, 109})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void read(Reads read, byte revision)
      {
        int num = (int) (sbyte) revision;
        base.read(read, (byte) num);
        this.heat = read.f();
      }

      [HideFromJava]
      static NuclearReactorBuild() => PowerGenerator.GeneratorBuild.__\u003Cclinit\u003E();

      [SpecialName]
      private new sealed class __\u003C\u003EAnon0 : Runnable
      {
        private readonly NuclearReactor.NuclearReactorBuild arg\u00241;

        internal __\u003C\u003EAnon0([In] NuclearReactor.NuclearReactorBuild obj0) => this.arg\u00241 = obj0;

        public void run() => this.arg\u00241.lambda\u0024onDestroyed\u00240();
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon1 : Runnable
      {
        private readonly NuclearReactor.NuclearReactorBuild arg\u00241;

        internal __\u003C\u003EAnon1([In] NuclearReactor.NuclearReactorBuild obj0) => this.arg\u00241 = obj0;

        public void run() => this.arg\u00241.lambda\u0024onDestroyed\u00241();
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon2 : Runnable
      {
        private readonly NuclearReactor.NuclearReactorBuild arg\u00241;

        internal __\u003C\u003EAnon2([In] NuclearReactor.NuclearReactorBuild obj0) => this.arg\u00241 = obj0;

        public void run() => this.arg\u00241.lambda\u0024onDestroyed\u00242();
      }
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon0 : Func
    {
      internal __\u003C\u003EAnon0()
      {
      }

      public object get([In] object obj0) => (object) NuclearReactor.lambda\u0024setBars\u00241((NuclearReactor.NuclearReactorBuild) obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon1 : Floatp
    {
      private readonly NuclearReactor.NuclearReactorBuild arg\u00241;

      internal __\u003C\u003EAnon1([In] NuclearReactor.NuclearReactorBuild obj0) => this.arg\u00241 = obj0;

      public float get() => NuclearReactor.lambda\u0024setBars\u00240(this.arg\u00241);
    }
  }
}
