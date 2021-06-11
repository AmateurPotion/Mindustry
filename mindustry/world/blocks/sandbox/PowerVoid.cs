// Decompiled with JetBrains decompiler
// Type: mindustry.world.blocks.sandbox.PowerVoid
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using mindustry.world.blocks.power;
using mindustry.world.meta;
using System.Runtime.CompilerServices;

namespace mindustry.world.blocks.sandbox
{
  public class PowerVoid : PowerBlock
  {
    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 151, 105, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public PowerVoid(string name)
      : base(name)
    {
      PowerVoid powerVoid = this;
      this.__\u003C\u003Econsumes.power(float.MaxValue);
    }

    [LineNumberTable(new byte[] {159, 157, 102, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setStats()
    {
      base.setStats();
      this.stats.remove(Stat.__\u003C\u003EpowerUse);
    }

    [HideFromJava]
    static PowerVoid() => PowerBlock.__\u003Cclinit\u003E();
  }
}
