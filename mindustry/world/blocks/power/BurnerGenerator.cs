// Decompiled with JetBrains decompiler
// Type: mindustry.world.blocks.power.BurnerGenerator
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.graphics.g2d;
using IKVM.Attributes;
using mindustry.graphics;
using mindustry.type;
using System.Runtime.CompilerServices;

namespace mindustry.world.blocks.power
{
  public class BurnerGenerator : ItemLiquidGenerator
  {
    public TextureRegion[] turbineRegions;
    public TextureRegion capRegion;
    public float turbineSpeed;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 156, 235, 61, 203})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public BurnerGenerator(string name)
      : base(true, false, name)
    {
      BurnerGenerator burnerGenerator = this;
      this.turbineSpeed = 2f;
    }

    [LineNumberTable(19)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override float getLiquidEfficiency(Liquid liquid) => liquid.flammability;

    [LineNumberTable(24)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override float getItemEfficiency(Item item) => item.flammability;

    [LineNumberTable(29)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override TextureRegion[] icons()
    {
      if (!this.turbineRegions[0].found())
        return base.icons();
      return new TextureRegion[4]
      {
        this.region,
        this.turbineRegions[0],
        this.turbineRegions[1],
        this.capRegion
      };
    }

    [HideFromJava]
    static BurnerGenerator() => ItemLiquidGenerator.__\u003Cclinit\u003E();

    public class BurnerGeneratorBuild : ItemLiquidGenerator.ItemLiquidGeneratorBuild
    {
      [Modifiers]
      internal BurnerGenerator this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(32)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public BurnerGeneratorBuild(BurnerGenerator _param1)
      {
        this.this\u00240 = _param1;
        // ISSUE: explicit constructor call
        base.\u002Ector((ItemLiquidGenerator) _param1);
      }

      [LineNumberTable(new byte[] {159, 178, 134, 119, 127, 18, 159, 19, 156, 109, 191, 38})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void draw()
      {
        base.draw();
        if (!this.this\u00240.turbineRegions[0].found())
          return;
        Draw.rect(this.this\u00240.turbineRegions[0], this.x, this.y, this.totalTime * this.this\u00240.turbineSpeed);
        Draw.rect(this.this\u00240.turbineRegions[1], this.x, this.y, -this.totalTime * this.this\u00240.turbineSpeed);
        Draw.rect(this.this\u00240.capRegion, this.x, this.y);
        if (!this.this\u00240.hasLiquids)
          return;
        Drawf.liquid(this.this\u00240.liquidRegion, this.x, this.y, this.liquids.total() / this.this\u00240.liquidCapacity, this.liquids.current().color);
      }

      [HideFromJava]
      static BurnerGeneratorBuild() => ItemLiquidGenerator.ItemLiquidGeneratorBuild.__\u003Cclinit\u003E();
    }
  }
}
