// Decompiled with JetBrains decompiler
// Type: mindustry.type.ItemStack
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.math;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using mindustry.content;
using mindustry.ctype;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.type
{
  [Signature("Ljava/lang/Object;Ljava/lang/Comparable<Lmindustry/type/ItemStack;>;")]
  [Implements(new string[] {"java.lang.Comparable"})]
  public class ItemStack : Object, Comparable
  {
    internal static ItemStack[] __\u003C\u003Eempty;
    public Item item;
    public int amount;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 155, 8, 167, 106, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ItemStack(Item item, int amount)
    {
      ItemStack itemStack = this;
      this.amount = 0;
      if (item == null)
        item = Items.copper;
      this.item = item;
      this.amount = amount;
    }

    [LineNumberTable(new byte[] {159, 190, 106, 103, 63, 2, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static ItemStack[] with(params object[] items)
    {
      ItemStack[] itemStackArray = new ItemStack[items.Length / 2];
      for (int index = 0; index < items.Length; index += 2)
        itemStackArray[index / 2] = new ItemStack((Item) items[index], ((Number) items[index + 1]).intValue());
      return itemStackArray;
    }

    [LineNumberTable(new byte[] {159, 182, 104, 103, 63, 3, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static ItemStack[] mult(ItemStack[] stacks, float amount)
    {
      ItemStack[] itemStackArray = new ItemStack[stacks.Length];
      for (int index = 0; index < itemStackArray.Length; ++index)
        itemStackArray[index] = new ItemStack(stacks[index].item, Mathf.round((float) stacks[index].amount * amount));
      return itemStackArray;
    }

    [LineNumberTable(new byte[] {159, 162, 232, 55, 231, 75, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ItemStack()
    {
      ItemStack itemStack = this;
      this.amount = 0;
      this.item = Items.copper;
    }

    [Signature("([Ljava/lang/Object;)Larc/struct/Seq<Lmindustry/type/ItemStack;>;")]
    [LineNumberTable(new byte[] {6, 106, 103, 63, 3, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Seq list(params object[] items)
    {
      Seq seq = new Seq(items.Length / 2);
      for (int index = 0; index < items.Length; index += 2)
        seq.add((object) new ItemStack((Item) items[index], ((Number) items[index + 1]).intValue()));
      return seq;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual ItemStack set(Item item, int amount)
    {
      this.item = item;
      this.amount = amount;
      return this;
    }

    [LineNumberTable(65)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int compareTo(ItemStack itemStack) => this.item.compareTo((Content) itemStack.item);

    [LineNumberTable(32)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual ItemStack copy() => new ItemStack(this.item, this.amount);

    [LineNumberTable(36)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool equals(ItemStack other) => other != null && object.ReferenceEquals((object) other.item, (object) this.item) && other.amount == this.amount;

    [LineNumberTable(new byte[] {20, 107, 127, 2})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool equals(object o)
    {
      if (object.ReferenceEquals((object) this, o))
        return true;
      object obj = o;
      ItemStack itemStack;
      return obj is ItemStack && object.ReferenceEquals((object) (itemStack = (ItemStack) obj), (object) (ItemStack) obj) && (this.amount == itemStack.amount && object.ReferenceEquals((object) this.item, (object) itemStack.item));
    }

    [LineNumberTable(77)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toString() => new StringBuilder().append("ItemStack{item=").append((object) this.item).append(", amount=").append(this.amount).append('}').toString();

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(7)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int compareTo(object obj) => this.compareTo((ItemStack) obj);

    [LineNumberTable(8)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static ItemStack()
    {
      if (ByteCodeHelper.isAlreadyInited("mindustry.type.ItemStack"))
        return;
      ItemStack.__\u003C\u003Eempty = new ItemStack[0];
    }

    int IComparable.__\u003Coverridestub\u003Ejava\u002Elang\u002EComparable\u003A\u003AcompareTo(
      [In] object obj0)
    {
      return this.compareTo(obj0);
    }

    [Modifiers]
    public static ItemStack[] empty
    {
      [HideFromJava] get => ItemStack.__\u003C\u003Eempty;
    }
  }
}
