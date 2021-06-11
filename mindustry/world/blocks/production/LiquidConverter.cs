// Decompiled with JetBrains decompiler
// Type: mindustry.world.blocks.production.LiquidConverter
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using mindustry.world.consumers;
using mindustry.world.meta;
using System.Runtime.CompilerServices;

namespace mindustry.world.blocks.production
{
  public class LiquidConverter : GenericCrafter
  {
    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 151, 105, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public LiquidConverter(string name)
      : base(name)
    {
      LiquidConverter liquidConverter = this;
      this.hasLiquids = true;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool outputsItems() => false;

    [LineNumberTable(new byte[] {159, 162, 127, 10, 176, 118, 104, 113, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void init()
    {
      if (!this.__\u003C\u003Econsumes.has(ConsumeType.__\u003C\u003Eliquid) || !(this.__\u003C\u003Econsumes.get(ConsumeType.__\u003C\u003Eliquid) is ConsumeLiquid))
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new RuntimeException("LiquidsConverters must have a ConsumeLiquid. Note that filters are not supported.");
      }
      ConsumeLiquid consumeLiquid = (ConsumeLiquid) this.__\u003C\u003Econsumes.get(ConsumeType.__\u003C\u003Eliquid);
      consumeLiquid.update(false);
      this.outputLiquid.amount = consumeLiquid.__\u003C\u003Eamount;
      base.init();
    }

    [LineNumberTable(new byte[] {159, 174, 102, 112, 127, 15})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setStats()
    {
      base.setStats();
      this.stats.remove(Stat.__\u003C\u003Eoutput);
      this.stats.add(Stat.__\u003C\u003Eoutput, this.outputLiquid.liquid, this.outputLiquid.amount * 60f, true);
    }

    [HideFromJava]
    static LiquidConverter() => GenericCrafter.__\u003Cclinit\u003E();

    public class LiquidConverterBuild : GenericCrafter.GenericCrafterBuild
    {
      [Modifiers]
      internal LiquidConverter this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(37)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public LiquidConverterBuild(LiquidConverter _param1)
      {
        this.this\u00240 = _param1;
        // ISSUE: explicit constructor call
        base.\u002Ector((GenericCrafter) _param1);
      }

      [LineNumberTable(new byte[] {159, 182, 127, 28, 159, 19})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void drawLight()
      {
        if (!this.this\u00240.hasLiquids || !this.this\u00240.drawLiquidLight || (double) this.this\u00240.outputLiquid.liquid.lightColor.a <= 1.0 / 1000.0)
          return;
        this.drawLiquidLight(this.this\u00240.outputLiquid.liquid, this.liquids.get(this.this\u00240.outputLiquid.liquid));
      }

      [LineNumberTable(new byte[] {159, 189, 155, 112, 159, 32, 159, 11, 119, 124, 115, 102, 217, 118})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void updateTile()
      {
        ConsumeLiquid consumeLiquid = (ConsumeLiquid) this.this\u00240.__\u003C\u003Econsumes.get(ConsumeType.__\u003C\u003Eliquid);
        if (this.cons.valid())
        {
          float amount = Math.min(consumeLiquid.__\u003C\u003Eamount * this.edelta(), this.this\u00240.liquidCapacity - this.liquids.get(this.this\u00240.outputLiquid.liquid));
          this.liquids.remove(consumeLiquid.__\u003C\u003Eliquid, Math.min(amount, this.liquids.get(consumeLiquid.__\u003C\u003Eliquid)));
          this.progress += amount / consumeLiquid.__\u003C\u003Eamount;
          this.liquids.add(this.this\u00240.outputLiquid.liquid, amount);
          if ((double) this.progress >= (double) this.this\u00240.craftTime)
          {
            this.consume();
            this.progress %= this.this\u00240.craftTime;
          }
        }
        this.dumpLiquid(this.this\u00240.outputLiquid.liquid);
      }

      [HideFromJava]
      static LiquidConverterBuild() => GenericCrafter.GenericCrafterBuild.__\u003Cclinit\u003E();
    }
  }
}
