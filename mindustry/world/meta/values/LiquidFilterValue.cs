// Decompiled with JetBrains decompiler
// Type: mindustry.world.meta.values.LiquidFilterValue
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.func;
using arc.scene;
using arc.scene.ui.layout;
using IKVM.Attributes;
using java.lang;
using java.util;
using mindustry.type;
using mindustry.ui;
using System.Runtime.CompilerServices;

namespace mindustry.world.meta.values
{
  public class LiquidFilterValue : Object, StatValue
  {
    [Modifiers]
    [Signature("Larc/func/Boolf<Lmindustry/type/Liquid;>;")]
    private Boolf filter;
    [Modifiers]
    private float amount;
    [Modifiers]
    private bool perSecond;

    [Signature("(Larc/func/Boolf<Lmindustry/type/Liquid;>;FZ)V")]
    [LineNumberTable(new byte[] {159, 138, 98, 104, 103, 104, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public LiquidFilterValue(Boolf filter, float amount, bool perSecond)
    {
      int num = perSecond ? 1 : 0;
      // ISSUE: explicit constructor call
      base.\u002Ector();
      LiquidFilterValue liquidFilterValue = this;
      this.filter = filter;
      this.amount = amount;
      this.perSecond = num != 0;
    }

    [LineNumberTable(new byte[] {159, 167, 134, 127, 5, 125, 130, 110, 159, 20, 107, 254, 60, 233, 71})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void display(Table table)
    {
      Seq seq = new Seq();
      Iterator iterator = Vars.content.liquids().iterator();
      while (iterator.hasNext())
      {
        Liquid liquid = (Liquid) iterator.next();
        if (!liquid.isHidden() && this.filter.get((object) liquid))
          seq.add((object) liquid);
      }
      for (int index = 0; index < seq.size; ++index)
      {
        Table table1 = table;
        LiquidDisplay.__\u003Cclinit\u003E();
        LiquidDisplay liquidDisplay = new LiquidDisplay((Liquid) seq.get(index), this.amount, this.perSecond);
        table1.add((Element) liquidDisplay).padRight(5f);
        if (index != seq.size - 1)
        {
          Table table2 = table;
          object obj = (object) "/";
          CharSequence charSequence;
          charSequence.__\u003Cref\u003E = (__Null) obj;
          CharSequence text = charSequence;
          table2.add(text);
        }
      }
    }
  }
}
