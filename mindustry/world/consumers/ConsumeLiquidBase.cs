// Decompiled with JetBrains decompiler
// Type: mindustry.world.consumers.ConsumeLiquidBase
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using mindustry.gen;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.world.consumers
{
  public abstract class ConsumeLiquidBase : Consume
  {
    internal float __\u003C\u003Eamount;

    [LineNumberTable(new byte[] {159, 151, 104, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ConsumeLiquidBase(float amount)
    {
      ConsumeLiquidBase consumeLiquidBase = this;
      this.__\u003C\u003Eamount = amount;
    }

    [LineNumberTable(15)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override ConsumeType type() => ConsumeType.__\u003C\u003Eliquid;

    [LineNumberTable(19)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual float use(Building entity) => Math.min(this.__\u003C\u003Eamount * entity.edelta(), entity.block.liquidCapacity);

    [Modifiers]
    public float amount
    {
      [HideFromJava] get => this.__\u003C\u003Eamount;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Eamount = value;
    }
  }
}
