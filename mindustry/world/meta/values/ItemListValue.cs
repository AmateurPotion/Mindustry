// Decompiled with JetBrains decompiler
// Type: mindustry.world.meta.values.ItemListValue
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
  public class ItemListValue : Object, StatValue
  {
    [Modifiers]
    private ItemStack[] stacks;
    [Modifiers]
    private bool displayName;

    [LineNumberTable(new byte[] {159, 138, 66, 104, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ItemListValue(bool displayName, params ItemStack[] stacks)
    {
      int num = displayName ? 1 : 0;
      // ISSUE: explicit constructor call
      base.\u002Ector();
      ItemListValue itemListValue = this;
      this.stacks = stacks;
      this.displayName = num != 0;
    }

    [LineNumberTable(new byte[] {159, 155, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ItemListValue(params ItemStack[] stacks)
      : this(true, stacks)
    {
    }

    [LineNumberTable(new byte[] {159, 165, 116, 63, 14, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void display(Table table)
    {
      ItemStack[] stacks = this.stacks;
      int length = stacks.Length;
      for (int index = 0; index < length; ++index)
      {
        ItemStack itemStack = stacks[index];
        Table table1 = table;
        ItemDisplay.__\u003Cclinit\u003E();
        ItemDisplay itemDisplay = new ItemDisplay(itemStack.item, itemStack.amount, this.displayName);
        table1.add((Element) itemDisplay).padRight(5f);
      }
    }
  }
}
