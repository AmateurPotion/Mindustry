// Decompiled with JetBrains decompiler
// Type: mindustry.type.LiquidStack
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using mindustry.content;
using System.Runtime.CompilerServices;

namespace mindustry.type
{
  public class LiquidStack : Object
  {
    public Liquid liquid;
    public float amount;

    [LineNumberTable(new byte[] {159, 151, 104, 103, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public LiquidStack(Liquid liquid, float amount)
    {
      LiquidStack liquidStack = this;
      this.liquid = liquid;
      this.amount = amount;
    }

    [LineNumberTable(new byte[] {159, 157, 104, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal LiquidStack()
    {
      LiquidStack liquidStack = this;
      this.liquid = Liquids.water;
    }

    [LineNumberTable(21)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toString() => new StringBuilder().append("LiquidStack{liquid=").append((object) this.liquid).append(", amount=").append(this.amount).append('}').toString();
  }
}
