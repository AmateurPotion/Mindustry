// Decompiled with JetBrains decompiler
// Type: mindustry.world.blocks.power.SingleTypeGenerator
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using mindustry.type;
using System.Runtime.CompilerServices;

namespace mindustry.world.blocks.power
{
  public class SingleTypeGenerator : ItemLiquidGenerator
  {
    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 150, 105, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public SingleTypeGenerator(string name)
      : base(name)
    {
      SingleTypeGenerator singleTypeGenerator = this;
      this.defaults = true;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override float getItemEfficiency(Item item) => 1f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override float getLiquidEfficiency(Liquid liquid) => 0.0f;

    [HideFromJava]
    static SingleTypeGenerator() => ItemLiquidGenerator.__\u003Cclinit\u003E();
  }
}
