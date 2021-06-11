// Decompiled with JetBrains decompiler
// Type: mindustry.world.blocks.power.ConditionalConsumePower
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.func;
using IKVM.Attributes;
using mindustry.gen;
using mindustry.world.consumers;
using System.Runtime.CompilerServices;

namespace mindustry.world.blocks.power
{
  public class ConditionalConsumePower : ConsumePower
  {
    [Modifiers]
    [Signature("Larc/func/Boolf<Lmindustry/gen/Building;>;")]
    private Boolf consume;

    [Signature("(FLarc/func/Boolf<Lmindustry/gen/Building;>;)V")]
    [LineNumberTable(new byte[] {159, 154, 112, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ConditionalConsumePower(float usage, Boolf consume)
      : base(usage, 0.0f, false)
    {
      ConditionalConsumePower conditionalConsumePower = this;
      this.consume = consume;
    }

    [LineNumberTable(18)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override float requestedPower(Building entity) => this.consume.get((object) entity) ? this.__\u003C\u003Eusage : 0.0f;
  }
}
