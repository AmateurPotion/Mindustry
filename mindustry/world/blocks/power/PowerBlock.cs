// Decompiled with JetBrains decompiler
// Type: mindustry.world.blocks.power.PowerBlock
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using mindustry.world.meta;
using System.Runtime.CompilerServices;

namespace mindustry.world.blocks.power
{
  public class PowerBlock : Block
  {
    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 151, 105, 103, 103, 103, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public PowerBlock(string name)
      : base(name)
    {
      PowerBlock powerBlock = this;
      this.update = true;
      this.solid = true;
      this.hasPower = true;
      this.group = BlockGroup.__\u003C\u003Epower;
    }

    [HideFromJava]
    static PowerBlock() => Block.__\u003Cclinit\u003E();
  }
}
