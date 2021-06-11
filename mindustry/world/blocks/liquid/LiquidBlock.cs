// Decompiled with JetBrains decompiler
// Type: mindustry.world.blocks.liquid.LiquidBlock
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.graphics.g2d;
using IKVM.Attributes;
using mindustry.gen;
using mindustry.graphics;
using mindustry.world.meta;
using System.Runtime.CompilerServices;

namespace mindustry.world.blocks.liquid
{
  public class LiquidBlock : Block
  {
    public TextureRegion liquidRegion;
    public TextureRegion topRegion;
    public TextureRegion bottomRegion;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 158, 105, 103, 103, 103, 107, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public LiquidBlock(string name)
      : base(name)
    {
      LiquidBlock liquidBlock = this;
      this.update = true;
      this.solid = true;
      this.hasLiquids = true;
      this.group = BlockGroup.__\u003C\u003Eliquids;
      this.outputsLiquid = true;
    }

    [LineNumberTable(26)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override TextureRegion[] icons() => new TextureRegion[2]
    {
      this.bottomRegion,
      this.topRegion
    };

    [HideFromJava]
    static LiquidBlock() => Block.__\u003Cclinit\u003E();

    public class LiquidBuild : Building
    {
      [Modifiers]
      internal LiquidBlock this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(29)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public LiquidBuild(LiquidBlock _param1)
      {
        this.this\u00240 = _param1;
        // ISSUE: explicit constructor call
        base.\u002Ector();
      }

      [LineNumberTable(new byte[] {159, 174, 124, 157, 115, 191, 38, 125})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void draw()
      {
        float rotation = !this.this\u00240.rotate ? 0.0f : this.rotdeg();
        Draw.rect(this.this\u00240.bottomRegion, this.x, this.y, rotation);
        if ((double) this.liquids.total() > 1.0 / 1000.0)
          Drawf.liquid(this.this\u00240.liquidRegion, this.x, this.y, this.liquids.total() / this.this\u00240.liquidCapacity, this.liquids.current().color);
        Draw.rect(this.this\u00240.topRegion, this.x, this.y, rotation);
      }

      [HideFromJava]
      static LiquidBuild() => Building.__\u003Cclinit\u003E();
    }
  }
}
