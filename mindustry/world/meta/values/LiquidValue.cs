// Decompiled with JetBrains decompiler
// Type: mindustry.world.meta.values.LiquidValue
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.scene;
using arc.scene.ui.layout;
using IKVM.Attributes;
using java.lang;
using mindustry.type;
using mindustry.ui;
using System.Runtime.CompilerServices;

namespace mindustry.world.meta.values
{
  public class LiquidValue : Object, StatValue
  {
    [Modifiers]
    private Liquid liquid;
    [Modifiers]
    private float amount;
    [Modifiers]
    private bool perSecond;

    [LineNumberTable(new byte[] {159, 139, 98, 104, 103, 104, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public LiquidValue(Liquid liquid, float amount, bool perSecond)
    {
      int num = perSecond ? 1 : 0;
      // ISSUE: explicit constructor call
      base.\u002Ector();
      LiquidValue liquidValue = this;
      this.liquid = liquid;
      this.amount = amount;
      this.perSecond = num != 0;
    }

    [LineNumberTable(new byte[] {159, 163, 127, 4})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void display(Table table)
    {
      Table table1 = table;
      LiquidDisplay.__\u003Cclinit\u003E();
      LiquidDisplay liquidDisplay = new LiquidDisplay(this.liquid, this.amount, this.perSecond);
      table1.add((Element) liquidDisplay);
    }
  }
}
