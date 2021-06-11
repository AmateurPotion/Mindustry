// Decompiled with JetBrains decompiler
// Type: mindustry.world.consumers.ConsumeItems
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.func;
using arc.scene;
using arc.scene.ui.layout;
using IKVM.Attributes;
using mindustry.gen;
using mindustry.type;
using mindustry.ui;
using mindustry.world.meta;
using mindustry.world.meta.values;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.world.consumers
{
  public class ConsumeItems : Consume
  {
    internal ItemStack[] __\u003C\u003Eitems;

    [LineNumberTable(new byte[] {159, 156, 104, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ConsumeItems(ItemStack[] items)
    {
      ConsumeItems consumeItems = this;
      this.__\u003C\u003Eitems = items;
    }

    [Modifiers]
    [LineNumberTable(new byte[] {159, 180, 98, 120, 127, 37, 102, 249, 61, 233, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024build\u00241([In] Building obj0, [In] Table obj1, [In] Table obj2)
    {
      int num1 = 0;
      ItemStack[] items = this.__\u003C\u003Eitems;
      int length = items.Length;
      for (int index = 0; index < length; ++index)
      {
        ItemStack itemStack = items[index];
        Table table = obj2;
        ReqImage.__\u003Cclinit\u003E();
        ItemImage.__\u003Cclinit\u003E();
        ReqImage reqImage = new ReqImage((Element) new ItemImage(itemStack.item.icon(Cicon.__\u003C\u003Emedium), itemStack.amount), (Boolp) new ConsumeItems.__\u003C\u003EAnon1(obj0, itemStack));
        table.add((Element) reqImage).padRight(8f);
        ++num1;
        int num2 = num1;
        int num3 = 4;
        if ((num3 != -1 ? num2 % num3 : 0) == 0)
          obj1.row();
      }
    }

    [Modifiers]
    [LineNumberTable(41)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024build\u00240([In] Building obj0, [In] ItemStack obj1) => obj0.items != null && obj0.items.has(obj1.item, obj1.amount);

    [LineNumberTable(new byte[] {159, 162, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal ConsumeItems()
      : this(ItemStack.__\u003C\u003Eempty)
    {
    }

    [LineNumberTable(new byte[] {159, 167, 116, 49, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void applyItemFilter(Bits filter)
    {
      ItemStack[] items = this.__\u003C\u003Eitems;
      int length = items.Length;
      for (int index = 0; index < length; ++index)
      {
        ItemStack itemStack = items[index];
        filter.set((int) itemStack.item.__\u003C\u003Eid);
      }
    }

    [LineNumberTable(32)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override ConsumeType type() => ConsumeType.__\u003C\u003Eitem;

    [LineNumberTable(new byte[] {159, 179, 243, 71, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void build(Building tile, Table table) => table.table((Cons) new ConsumeItems.__\u003C\u003EAnon0(this, tile, table)).left();

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string getIcon() => "icon-item";

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void update(Building entity)
    {
    }

    [LineNumberTable(new byte[] {9, 116, 44, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void trigger(Building entity)
    {
      ItemStack[] items = this.__\u003C\u003Eitems;
      int length = items.Length;
      for (int index = 0; index < length; ++index)
      {
        ItemStack stack = items[index];
        entity.items.remove(stack);
      }
    }

    [LineNumberTable(66)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool valid(Building entity) => entity.items != null && entity.items.has(this.__\u003C\u003Eitems);

    [LineNumberTable(new byte[] {21, 127, 6})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void display(Stats stats) => stats.add(!this.booster ? Stat.__\u003C\u003Einput : Stat.__\u003C\u003Ebooster, (StatValue) new ItemListValue(this.__\u003C\u003Eitems));

    [Modifiers]
    public ItemStack[] items
    {
      [HideFromJava] get => this.__\u003C\u003Eitems;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Eitems = value;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Cons
    {
      private readonly ConsumeItems arg\u00241;
      private readonly Building arg\u00242;
      private readonly Table arg\u00243;

      internal __\u003C\u003EAnon0([In] ConsumeItems obj0, [In] Building obj1, [In] Table obj2)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
      }

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024build\u00241(this.arg\u00242, this.arg\u00243, (Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Boolp
    {
      private readonly Building arg\u00241;
      private readonly ItemStack arg\u00242;

      internal __\u003C\u003EAnon1([In] Building obj0, [In] ItemStack obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public bool get() => (ConsumeItems.lambda\u0024build\u00240(this.arg\u00241, this.arg\u00242) ? 1 : 0) != 0;
    }
  }
}
