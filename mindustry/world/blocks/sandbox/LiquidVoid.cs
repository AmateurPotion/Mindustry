// Decompiled with JetBrains decompiler
// Type: mindustry.world.blocks.sandbox.LiquidVoid
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using mindustry.gen;
using mindustry.type;
using mindustry.world.meta;
using System.Runtime.CompilerServices;

namespace mindustry.world.blocks.sandbox
{
  public class LiquidVoid : Block
  {
    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 153, 105, 103, 103, 103, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public LiquidVoid(string name)
      : base(name)
    {
      LiquidVoid liquidVoid = this;
      this.hasLiquids = true;
      this.solid = true;
      this.update = true;
      this.group = BlockGroup.__\u003C\u003Eliquids;
    }

    [LineNumberTable(new byte[] {159, 162, 102, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setBars()
    {
      base.setBars();
      this.__\u003C\u003Ebars.remove("liquid");
    }

    [HideFromJava]
    static LiquidVoid() => Block.__\u003Cclinit\u003E();

    public class LiquidVoidBuild : Building
    {
      [Modifiers]
      internal LiquidVoid this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(24)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public LiquidVoidBuild(LiquidVoid _param1)
      {
        this.this\u00240 = _param1;
        // ISSUE: explicit constructor call
        base.\u002Ector();
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      public override bool acceptLiquid(Building source, Liquid liquid) => this.enabled;

      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void handleLiquid(Building source, Liquid liquid, float amount)
      {
      }

      [HideFromJava]
      static LiquidVoidBuild() => Building.__\u003Cclinit\u003E();
    }
  }
}
