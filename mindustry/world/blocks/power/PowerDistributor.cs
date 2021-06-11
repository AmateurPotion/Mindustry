// Decompiled with JetBrains decompiler
// Type: mindustry.world.blocks.power.PowerDistributor
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using System.Runtime.CompilerServices;

namespace mindustry.world.blocks.power
{
  public class PowerDistributor : PowerBlock
  {
    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 148, 105, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public PowerDistributor(string name)
      : base(name)
    {
      PowerDistributor powerDistributor = this;
      this.consumesPower = false;
      this.outputsPower = true;
    }

    [HideFromJava]
    static PowerDistributor() => PowerBlock.__\u003Cclinit\u003E();
  }
}
