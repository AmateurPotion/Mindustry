// Decompiled with JetBrains decompiler
// Type: mindustry.world.blocks.power.DecayGenerator
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using mindustry.type;
using System.Runtime.CompilerServices;

namespace mindustry.world.blocks.power
{
  public class DecayGenerator : ItemLiquidGenerator
  {
    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 150, 107, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public DecayGenerator(string name)
      : base(true, false, name)
    {
      DecayGenerator decayGenerator = this;
      this.hasItems = true;
      this.hasLiquids = false;
    }

    [LineNumberTable(15)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override float getItemEfficiency(Item item) => item.radioactivity;

    [HideFromJava]
    static DecayGenerator() => ItemLiquidGenerator.__\u003Cclinit\u003E();
  }
}
