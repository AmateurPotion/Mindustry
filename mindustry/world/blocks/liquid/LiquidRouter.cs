// Decompiled with JetBrains decompiler
// Type: mindustry.world.blocks.liquid.LiquidRouter
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using mindustry.gen;
using mindustry.type;
using System.Runtime.CompilerServices;

namespace mindustry.world.blocks.liquid
{
  public class LiquidRouter : LiquidBlock
  {
    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 151, 137, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public LiquidRouter(string name)
      : base(name)
    {
      LiquidRouter liquidRouter = this;
      this.noUpdateDisabled = true;
    }

    [HideFromJava]
    static LiquidRouter() => LiquidBlock.__\u003Cclinit\u003E();

    public class LiquidRouterBuild : LiquidBlock.LiquidBuild
    {
      [Modifiers]
      internal LiquidRouter this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(14)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public LiquidRouterBuild(LiquidRouter _param1)
      {
        this.this\u00240 = _param1;
        // ISSUE: explicit constructor call
        base.\u002Ector((LiquidBlock) _param1);
      }

      [LineNumberTable(new byte[] {159, 159, 115, 145})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void updateTile()
      {
        if ((double) this.liquids.total() <= 0.00999999977648258)
          return;
        this.dumpLiquid(this.liquids.current());
      }

      [LineNumberTable(24)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override bool acceptLiquid(Building source, Liquid liquid) => object.ReferenceEquals((object) this.liquids.current(), (object) liquid) || (double) this.liquids.currentAmount() < 0.200000002980232;

      [HideFromJava]
      static LiquidRouterBuild() => LiquidBlock.LiquidBuild.__\u003Cclinit\u003E();
    }
  }
}
