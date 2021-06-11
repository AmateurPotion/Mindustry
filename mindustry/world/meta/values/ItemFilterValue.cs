// Decompiled with JetBrains decompiler
// Type: mindustry.world.meta.values.ItemFilterValue
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.func;
using arc.scene;
using arc.scene.ui.layout;
using IKVM.Attributes;
using java.lang;
using mindustry.type;
using mindustry.ui;
using System.Runtime.CompilerServices;

namespace mindustry.world.meta.values
{
  public class ItemFilterValue : Object, StatValue
  {
    [Modifiers]
    [Signature("Larc/func/Boolf<Lmindustry/type/Item;>;")]
    private Boolf filter;

    [Signature("(Larc/func/Boolf<Lmindustry/type/Item;>;)V")]
    [LineNumberTable(new byte[] {159, 157, 104, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ItemFilterValue(Boolf filter)
    {
      ItemFilterValue itemFilterValue = this;
      this.filter = filter;
    }

    [LineNumberTable(new byte[] {159, 163, 150, 107, 141, 151, 107, 252, 58, 233, 73})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void display(Table table)
    {
      Seq seq = Vars.content.items().select(this.filter);
      for (int index = 0; index < seq.size; ++index)
      {
        Item obj1 = (Item) seq.get(index);
        table.add((Element) new ItemDisplay(obj1)).padRight(5f);
        if (index != seq.size - 1)
        {
          Table table1 = table;
          object obj2 = (object) "/";
          CharSequence charSequence;
          charSequence.__\u003Cref\u003E = (__Null) obj2;
          CharSequence text = charSequence;
          table1.add(text);
        }
      }
    }
  }
}
