// Decompiled with JetBrains decompiler
// Type: mindustry.world.consumers.ConsumeItemDynamic
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.func;
using arc.scene;
using arc.scene.ui.layout;
using IKVM.Attributes;
using java.lang;
using mindustry.gen;
using mindustry.type;
using mindustry.ui;
using mindustry.world.meta;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.world.consumers
{
  public class ConsumeItemDynamic : Consume
  {
    [Signature("Larc/func/Func<Lmindustry/gen/Building;[Lmindustry/type/ItemStack;>;")]
    internal Func __\u003C\u003Eitems;

    [Signature("<T:Lmindustry/gen/Building;>(Larc/func/Func<TT;[Lmindustry/type/ItemStack;>;)V")]
    [LineNumberTable(new byte[] {159, 156, 104, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ConsumeItemDynamic(Func items)
    {
      ConsumeItemDynamic consumeItemDynamic = this;
      this.__\u003C\u003Eitems = items;
    }

    [LineNumberTable(new byte[] {159, 187, 102, 130, 127, 4, 127, 37, 107, 249, 61, 233, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void rebuild([In] Building obj0, [In] Table obj1)
    {
      obj1.clear();
      int num1 = 0;
      ItemStack[] itemStackArray = (ItemStack[]) this.__\u003C\u003Eitems.get((object) obj0);
      int length = itemStackArray.Length;
      for (int index = 0; index < length; ++index)
      {
        ItemStack itemStack = itemStackArray[index];
        Table table = obj1;
        ReqImage.__\u003Cclinit\u003E();
        ItemImage.__\u003Cclinit\u003E();
        ReqImage reqImage = new ReqImage((Element) new ItemImage(itemStack.item.icon(Cicon.__\u003C\u003Emedium), itemStack.amount), (Boolp) new ConsumeItemDynamic.__\u003C\u003EAnon1(obj0, itemStack));
        table.add((Element) reqImage).padRight(8f).left();
        ++num1;
        int num2 = num1;
        int num3 = 4;
        if ((num3 != -1 ? num2 % num3 : 0) == 0)
          obj1.row();
      }
    }

    [Modifiers]
    [LineNumberTable(new byte[] {159, 175, 246, 71, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024build\u00241(
      [In] Table obj0,
      [In] ItemStack[][] obj1,
      [In] Building obj2,
      [In] Table obj3)
    {
      obj0.update((Runnable) new ConsumeItemDynamic.__\u003C\u003EAnon2(this, obj1, obj2, obj3));
      this.rebuild(obj2, obj3);
    }

    [Modifiers]
    [LineNumberTable(50)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024rebuild\u00242([In] Building obj0, [In] ItemStack obj1) => obj0.items != null && obj0.items.has(obj1.item, obj1.amount);

    [Modifiers]
    [LineNumberTable(new byte[] {159, 176, 118, 104, 148})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024build\u00240([In] ItemStack[][] obj0, [In] Building obj1, [In] Table obj2)
    {
      if (object.ReferenceEquals((object) obj0[0], this.__\u003C\u003Eitems.get((object) obj1)))
        return;
      this.rebuild(obj1, obj2);
      obj0[0] = (ItemStack[]) this.__\u003C\u003Eitems.get((object) obj1);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void applyItemFilter(Bits filter)
    {
    }

    [LineNumberTable(25)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override ConsumeType type() => ConsumeType.__\u003C\u003Eitem;

    [LineNumberTable(new byte[] {159, 172, 155, 245, 74})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void build(Building tile, Table table)
    {
      ItemStack[][] itemStackArray = new ItemStack[1][]
      {
        (ItemStack[]) this.__\u003C\u003Eitems.get((object) tile)
      };
      table.table((Cons) new ConsumeItemDynamic.__\u003C\u003EAnon0(this, table, itemStackArray, tile));
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string getIcon() => "icon-item";

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void update(Building entity)
    {
    }

    [LineNumberTable(new byte[] {17, 127, 0, 44, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void trigger(Building entity)
    {
      ItemStack[] itemStackArray = (ItemStack[]) this.__\u003C\u003Eitems.get((object) entity);
      int length = itemStackArray.Length;
      for (int index = 0; index < length; ++index)
      {
        ItemStack stack = itemStackArray[index];
        entity.items.remove(stack);
      }
    }

    [LineNumberTable(74)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool valid(Building entity) => entity.items != null && entity.items.has((ItemStack[]) this.__\u003C\u003Eitems.get((object) entity));

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void display(Stats stats)
    {
    }

    [Modifiers]
    public Func items
    {
      [HideFromJava] get => this.__\u003C\u003Eitems;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Eitems = value;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Cons
    {
      private readonly ConsumeItemDynamic arg\u00241;
      private readonly Table arg\u00242;
      private readonly ItemStack[][] arg\u00243;
      private readonly Building arg\u00244;

      internal __\u003C\u003EAnon0(
        [In] ConsumeItemDynamic obj0,
        [In] Table obj1,
        [In] ItemStack[][] obj2,
        [In] Building obj3)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
        this.arg\u00244 = obj3;
      }

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024build\u00241(this.arg\u00242, this.arg\u00243, this.arg\u00244, (Table) obj0);
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

      public bool get() => (ConsumeItemDynamic.lambda\u0024rebuild\u00242(this.arg\u00241, this.arg\u00242) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon2 : Runnable
    {
      private readonly ConsumeItemDynamic arg\u00241;
      private readonly ItemStack[][] arg\u00242;
      private readonly Building arg\u00243;
      private readonly Table arg\u00244;

      internal __\u003C\u003EAnon2(
        [In] ConsumeItemDynamic obj0,
        [In] ItemStack[][] obj1,
        [In] Building obj2,
        [In] Table obj3)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
        this.arg\u00244 = obj3;
      }

      public void run() => this.arg\u00241.lambda\u0024build\u00240(this.arg\u00242, this.arg\u00243, this.arg\u00244);
    }
  }
}
