// Decompiled with JetBrains decompiler
// Type: mindustry.world.blocks.power.ItemLiquidGenerator
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.func;
using arc.graphics;
using arc.graphics.g2d;
using arc.math;
using arc.util;
using IKVM.Attributes;
using java.lang;
using java.util;
using mindustry.content;
using mindustry.entities;
using mindustry.graphics;
using mindustry.type;
using mindustry.world.consumers;
using mindustry.world.meta;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.world.blocks.power
{
  public class ItemLiquidGenerator : PowerGenerator
  {
    public float minItemEfficiency;
    public float itemDuration;
    public float minLiquidEfficiency;
    public float maxLiquidGenerate;
    public Effect generateEffect;
    public Effect explodeEffect;
    public Color heatColor;
    public TextureRegion topRegion;
    public TextureRegion liquidRegion;
    public bool randomlyExplode;
    public bool defaults;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 189, 233, 40, 139, 139, 139, 139, 107, 107, 176, 103, 231, 75})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ItemLiquidGenerator(string name)
      : base(name)
    {
      ItemLiquidGenerator itemLiquidGenerator = this;
      this.minItemEfficiency = 0.2f;
      this.itemDuration = 70f;
      this.minLiquidEfficiency = 0.2f;
      this.maxLiquidGenerate = 0.4f;
      this.generateEffect = Fx.__\u003C\u003Egeneratespark;
      this.explodeEffect = Fx.__\u003C\u003Egeneratespark;
      this.heatColor = Color.valueOf("ff9b59");
      this.randomlyExplode = true;
      this.defaults = false;
    }

    [LineNumberTable(new byte[] {1, 104, 191, 15, 104, 191, 21, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void setDefaults()
    {
      if (this.hasItems)
        this.__\u003C\u003Econsumes.add((Consume) new ConsumeItemFilter((Boolf) new ItemLiquidGenerator.__\u003C\u003EAnon0(this))).update(false).optional(true, false);
      if (this.hasLiquids)
        this.__\u003C\u003Econsumes.add((Consume) new ConsumeLiquidFilter((Boolf) new ItemLiquidGenerator.__\u003C\u003EAnon1(this), this.maxLiquidGenerate)).update(false).optional(true, false);
      this.defaults = true;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual float getLiquidEfficiency(Liquid liquid) => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual float getItemEfficiency(Item item) => 0.0f;

    [Modifiers]
    [LineNumberTable(52)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool lambda\u0024setDefaults\u00240([In] Item obj0) => (double) this.getItemEfficiency(obj0) >= (double) this.minItemEfficiency;

    [Modifiers]
    [LineNumberTable(56)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool lambda\u0024setDefaults\u00241([In] Liquid obj0) => (double) this.getLiquidEfficiency(obj0) >= (double) this.minLiquidEfficiency;

    [LineNumberTable(new byte[] {159, 132, 68, 105, 103, 103, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ItemLiquidGenerator(bool hasItems, bool hasLiquids, string name)
    {
      int num1 = hasItems ? 1 : 0;
      int num2 = hasLiquids ? 1 : 0;
      // ISSUE: explicit constructor call
      this.\u002Ector(name);
      ItemLiquidGenerator itemLiquidGenerator = this;
      this.hasItems = num1 != 0;
      this.hasLiquids = num2 != 0;
      this.setDefaults();
    }

    [LineNumberTable(new byte[] {14, 104, 134, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void init()
    {
      if (!this.defaults)
        this.setDefaults();
      base.init();
    }

    [LineNumberTable(new byte[] {22, 134, 104, 159, 3})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setStats()
    {
      base.setStats();
      if (!this.hasItems)
        return;
      this.stats.add(Stat.__\u003C\u003EproductionTime, this.itemDuration / 60f, StatUnit.__\u003C\u003Eseconds);
    }

    [HideFromJava]
    static ItemLiquidGenerator() => PowerGenerator.__\u003Cclinit\u003E();

    public class ItemLiquidGeneratorBuild : PowerGenerator.GeneratorBuild
    {
      public float explosiveness;
      public float heat;
      public float totalTime;
      [Modifiers]
      internal ItemLiquidGenerator this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [Modifiers]
      [LineNumberTable(new byte[] {96, 113, 127, 55})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024updateTile\u00240()
      {
        this.damage(Mathf.random(11f));
        this.this\u00240.explodeEffect.at(this.x + Mathf.range((float) (this.this\u00240.size * 8) / 2f), this.y + Mathf.range((float) (this.this\u00240.size * 8) / 2f));
      }

      [LineNumberTable(87)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public ItemLiquidGeneratorBuild(ItemLiquidGenerator _param1)
      {
        this.this\u00240 = _param1;
        // ISSUE: explicit constructor call
        base.\u002Ector((PowerGenerator) _param1);
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      public override bool productionValid() => (double) this.generateTime > 0.0;

      [LineNumberTable(new byte[] {49, 136, 159, 25, 104, 107, 161, 98, 127, 5, 127, 28, 98, 130, 130, 187, 127, 14, 111, 112, 154, 127, 2, 144, 127, 4, 159, 23, 149, 126, 127, 23, 109, 116, 109, 171, 112, 159, 41, 159, 47, 247, 70, 171})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void updateTile()
      {
        float num1 = this.delta();
        this.heat = Mathf.lerpDelta(this.heat, (double) this.generateTime < 1.0 / 1000.0 || !this.enabled ? 0.0f : 1f, 0.05f);
        if (!this.consValid())
        {
          this.productionEfficiency = 0.0f;
        }
        else
        {
          Liquid liquid1 = (Liquid) null;
          Iterator iterator = Vars.content.liquids().iterator();
          while (iterator.hasNext())
          {
            Liquid liquid2 = (Liquid) iterator.next();
            if (this.this\u00240.hasLiquids && (double) this.liquids.get(liquid2) >= 1.0 / 1000.0 && (double) this.this\u00240.getLiquidEfficiency(liquid2) >= (double) this.this\u00240.minLiquidEfficiency)
            {
              liquid1 = liquid2;
              break;
            }
          }
          this.totalTime += this.heat * Time.delta;
          if (this.this\u00240.hasLiquids && liquid1 != null && (double) this.liquids.get(liquid1) >= 1.0 / 1000.0)
          {
            float liquidEfficiency = this.this\u00240.getLiquidEfficiency(liquid1);
            float num2 = this.this\u00240.maxLiquidGenerate * num1;
            float num3 = Math.min(this.liquids.get(liquid1) * num1, num2);
            this.liquids.remove(liquid1, num3 * this.power.graph.getUsageFraction());
            this.productionEfficiency = liquidEfficiency * num3 / num2;
            if ((double) num3 <= 1.0 / 1000.0 || !Mathf.chance(0.05 * (double) this.delta()))
              return;
            this.this\u00240.generateEffect.at(this.x + Mathf.range(3f), this.y + Mathf.range(3f));
          }
          else
          {
            if (!this.this\u00240.hasItems)
              return;
            if ((double) this.generateTime <= 0.0 && this.items.total() > 0)
            {
              this.this\u00240.generateEffect.at(this.x + Mathf.range(3f), this.y + Mathf.range(3f));
              Item obj = this.items.take();
              this.productionEfficiency = this.this\u00240.getItemEfficiency(obj);
              this.explosiveness = obj.explosiveness;
              this.generateTime = 1f;
            }
            if ((double) this.generateTime > 0.0)
            {
              this.generateTime -= Math.min(1f / this.this\u00240.itemDuration * this.delta() * this.power.graph.getUsageFraction(), this.generateTime);
              if (!this.this\u00240.randomlyExplode || !Vars.state.rules.reactorExplosions || !Mathf.chance((double) this.delta() * 0.06 * (double) Mathf.clamp(this.explosiveness - 0.5f)))
                return;
              Core.app.post((Runnable) new ItemLiquidGenerator.ItemLiquidGeneratorBuild.__\u003C\u003EAnon0(this));
            }
            else
              this.productionEfficiency = 0.0f;
          }
        }
      }

      [LineNumberTable(new byte[] {108, 134, 109, 112, 127, 18, 124, 165, 109, 159, 38})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void draw()
      {
        base.draw();
        if (this.this\u00240.hasItems)
        {
          Draw.color(this.this\u00240.heatColor);
          Draw.alpha(this.heat * 0.4f + Mathf.absin(Time.time, 8f, 0.6f) * this.heat);
          Draw.rect(this.this\u00240.topRegion, this.x, this.y);
          Draw.reset();
        }
        if (!this.this\u00240.hasLiquids)
          return;
        Drawf.liquid(this.this\u00240.liquidRegion, this.x, this.y, this.liquids.total() / this.this\u00240.liquidCapacity, this.liquids.current().color);
      }

      [LineNumberTable(new byte[] {124, 127, 47})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void drawLight() => Drawf.light(this.team, this.x, this.y, (60f + Mathf.absin(10f, 5f)) * (float) this.this\u00240.size, Color.__\u003C\u003Eorange, 0.5f * this.heat);

      [HideFromJava]
      static ItemLiquidGeneratorBuild() => PowerGenerator.GeneratorBuild.__\u003Cclinit\u003E();

      [SpecialName]
      private new sealed class __\u003C\u003EAnon0 : Runnable
      {
        private readonly ItemLiquidGenerator.ItemLiquidGeneratorBuild arg\u00241;

        internal __\u003C\u003EAnon0([In] ItemLiquidGenerator.ItemLiquidGeneratorBuild obj0) => this.arg\u00241 = obj0;

        public void run() => this.arg\u00241.lambda\u0024updateTile\u00240();
      }
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon0 : Boolf
    {
      private readonly ItemLiquidGenerator arg\u00241;

      internal __\u003C\u003EAnon0([In] ItemLiquidGenerator obj0) => this.arg\u00241 = obj0;

      public bool get([In] object obj0) => (this.arg\u00241.lambda\u0024setDefaults\u00240((Item) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon1 : Boolf
    {
      private readonly ItemLiquidGenerator arg\u00241;

      internal __\u003C\u003EAnon1([In] ItemLiquidGenerator obj0) => this.arg\u00241 = obj0;

      public bool get([In] object obj0) => (this.arg\u00241.lambda\u0024setDefaults\u00241((Liquid) obj0) ? 1 : 0) != 0;
    }
  }
}
