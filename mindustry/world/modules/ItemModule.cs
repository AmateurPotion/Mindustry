// Decompiled with JetBrains decompiler
// Type: mindustry.world.modules.ItemModule
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.math;
using arc.util;
using arc.util.io;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.util;
using mindustry.type;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.world.modules
{
  public class ItemModule : BlockModule
  {
    internal static ItemModule __\u003C\u003Eempty;
    private const int windowSize = 6;
    private static WindowedMean[] cacheFlow;
    private static float[] cacheSums;
    private static float[] displayFlow;
    [Modifiers]
    private static Bits cacheBits;
    [Modifiers]
    private static Interval flowTimer;
    private const float pollScl = 20f;
    protected internal int[] items;
    protected internal int total;
    protected internal int takeRotation;
    [arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})]
    private WindowedMean[] flow;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int total() => this.total;

    [LineNumberTable(236)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int get(Item item) => this.items[(int) item.__\u003C\u003Eid];

    [LineNumberTable(new byte[] {104, 111, 63, 1, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool has(ItemStack[] stacks, float multiplier)
    {
      ItemStack[] itemStackArray = stacks;
      int length = itemStackArray.Length;
      for (int index = 0; index < length; ++index)
      {
        ItemStack itemStack = itemStackArray[index];
        if (!this.has(itemStack.item, Math.round((float) itemStack.amount * multiplier)))
          return false;
      }
      return true;
    }

    [LineNumberTable(new byte[] {159, 179, 108, 108, 122})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void set(ItemModule other)
    {
      this.total = other.total;
      this.takeRotation = other.takeRotation;
      ByteCodeHelper.arraycopy_primitive_4((Array) other.items, 0, (Array) this.items, 0, this.items.Length);
    }

    [LineNumberTable(new byte[] {159, 173, 102, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual ItemModule copy()
    {
      ItemModule itemModule = new ItemModule();
      itemModule.set(this);
      return itemModule;
    }

    [LineNumberTable(new byte[] {160, 172, 127, 8})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void remove(ItemStack[] stacks)
    {
      ItemStack[] itemStackArray = stacks;
      int length = itemStackArray.Length;
      for (int index = 0; index < length; ++index)
      {
        ItemStack itemStack = itemStackArray[index];
        this.remove(itemStack.item, itemStack.amount);
      }
    }

    [LineNumberTable(new byte[] {55, 108, 106, 25, 230, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void each(ItemModule.ItemConsumer cons)
    {
      for (int id = 0; id < this.items.Length; ++id)
      {
        if (this.items[id] != 0)
          cons.accept(Vars.content.item(id), this.items[id]);
      }
    }

    [LineNumberTable(new byte[] {160, 188, 108, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void clear()
    {
      Arrays.fill(this.items, 0);
      this.total = 0;
    }

    [LineNumberTable(new byte[] {160, 147, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void add(Item item, int amount) => this.add((int) item.__\u003C\u003Eid, amount);

    [LineNumberTable(new byte[] {160, 126, 124, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void set(Item item, int amount)
    {
      this.total += amount - this.items[(int) item.__\u003C\u003Eid];
      this.items[(int) item.__\u003C\u003Eid] = amount;
    }

    [LineNumberTable(new byte[] {159, 155, 232, 75})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ItemModule()
    {
      ItemModule itemModule = this;
      this.items = new int[Vars.content.items().size];
    }

    [LineNumberTable(new byte[] {160, 194, 98, 117, 41, 198, 135, 110, 108, 104, 239, 61, 232, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void write(Writes write)
    {
      int i1 = 0;
      int[] items = this.items;
      int length = items.Length;
      for (int index = 0; index < length; ++index)
      {
        if (items[index] > 0)
          ++i1;
      }
      write.s(i1);
      for (int i2 = 0; i2 < this.items.Length; ++i2)
      {
        if (this.items[i2] > 0)
        {
          write.s(i2);
          write.i(this.items[i2]);
        }
      }
    }

    [LineNumberTable(new byte[] {63, 102, 108, 107, 30, 230, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float sum(ItemModule.ItemCalculator calc)
    {
      float num = 0.0f;
      for (int id = 0; id < this.items.Length; ++id)
      {
        if (this.items[id] > 0)
          num += calc.get(Vars.content.item(id), this.items[id]);
      }
      return num;
    }

    [LineNumberTable(new byte[] {81, 111, 54, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool has(ItemStack[] stacks)
    {
      ItemStack[] itemStackArray = stacks;
      int length = itemStackArray.Length;
      for (int index = 0; index < length; ++index)
      {
        ItemStack itemStack = itemStackArray[index];
        if (!this.has(itemStack.item, itemStack.amount))
          return false;
      }
      return true;
    }

    [LineNumberTable(123)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool has(Item item) => this.get(item) > 0;

    [LineNumberTable(new byte[] {159, 61, 130, 108, 114, 135, 102, 114, 104, 121, 239, 60, 230, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void read(Reads read, bool legacy)
    {
      int num1 = legacy ? 1 : 0;
      Arrays.fill(this.items, 0);
      int num2 = num1 == 0 ? (int) read.s() : read.ub();
      this.total = 0;
      for (int index = 0; index < num2; ++index)
      {
        int id = num1 == 0 ? (int) read.s() : read.ub();
        int num3 = read.i();
        this.items[(int) Vars.content.item(id).__\u003C\u003Eid] = num3;
        this.total += num3;
      }
    }

    [LineNumberTable(new byte[] {160, 165, 149, 118, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void remove(Item item, int amount)
    {
      amount = Math.min(amount, this.items[(int) item.__\u003C\u003Eid]);
      int[] items = this.items;
      int id = (int) item.__\u003C\u003Eid;
      int[] numArray = items;
      numArray[id] = numArray[id] - amount;
      this.total -= amount;
    }

    [LineNumberTable(new byte[] {160, 70, 108, 107, 12, 230, 69})]
    [arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Item first()
    {
      for (int id = 0; id < this.items.Length; ++id)
      {
        if (this.items[id] > 0)
          return Vars.content.item(id);
      }
      return (Item) null;
    }

    [LineNumberTable(new byte[] {159, 132, 162, 134, 149, 107, 118, 113, 108, 45, 166, 113, 147, 108, 44, 166, 111, 170, 143, 171, 144, 111, 116, 110, 139, 140, 99, 255, 19, 56, 233, 75, 130, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void update(bool showFlow)
    {
      if (showFlow)
      {
        if (!ItemModule.flowTimer.get(1, 20f))
          return;
        if (this.flow == null)
        {
          if (ItemModule.cacheFlow == null || ItemModule.cacheFlow.Length != this.items.Length)
          {
            ItemModule.cacheFlow = new WindowedMean[this.items.Length];
            for (int index = 0; index < this.items.Length; ++index)
              ItemModule.cacheFlow[index] = new WindowedMean(6);
            ItemModule.cacheSums = new float[this.items.Length];
            ItemModule.displayFlow = new float[this.items.Length];
          }
          else
          {
            for (int index = 0; index < this.items.Length; ++index)
              ItemModule.cacheFlow[index].reset();
            Arrays.fill(ItemModule.cacheSums, 0.0f);
            ItemModule.cacheBits.clear();
          }
          Arrays.fill(ItemModule.displayFlow, -1f);
          this.flow = ItemModule.cacheFlow;
        }
        int num = ItemModule.flowTimer.get(30f) ? 1 : 0;
        for (int index = 0; index < this.items.Length; ++index)
        {
          this.flow[index].add(ItemModule.cacheSums[index]);
          if ((double) ItemModule.cacheSums[index] > 0.0)
            ItemModule.cacheBits.set(index);
          ItemModule.cacheSums[index] = 0.0f;
          if (num != 0)
            ItemModule.displayFlow[index] = !this.flow[index].hasEnoughData() ? -1f : this.flow[index].mean() / 20f;
        }
      }
      else
        this.flow = (WindowedMean[]) null;
    }

    [LineNumberTable(new byte[] {49, 138})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool hasFlowItem(Item item) => this.flow != null && ItemModule.cacheBits.get((int) item.__\u003C\u003Eid);

    [LineNumberTable(new byte[] {43, 142})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getFlowRate(Item item) => this.flow == null ? -1f : ItemModule.displayFlow[(int) item.__\u003C\u003Eid] * 60f;

    [LineNumberTable(new byte[] {160, 137, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void add(ItemSeq stacks) => stacks.each((ItemModule.ItemConsumer) new ItemModule.__\u003C\u003EAnon0(this));

    [LineNumberTable(88)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int length() => this.items.Length;

    [LineNumberTable(232)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int get(int id) => this.items[id];

    [Signature("(Ljava/lang/Iterable<Lmindustry/type/ItemStack;>;)V")]
    [LineNumberTable(new byte[] {160, 131, 123, 114, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void add(Iterable stacks)
    {
      Iterator iterator = stacks.iterator();
      while (iterator.hasNext())
      {
        ItemStack itemStack = (ItemStack) iterator.next();
        this.add(itemStack.item, itemStack.amount);
      }
    }

    [LineNumberTable(127)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool has(Item item, int amount) => this.get(item) >= amount;

    [LineNumberTable(new byte[] {160, 141, 108, 47, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void add(ItemModule items)
    {
      for (int index = 0; index < items.items.Length; ++index)
        this.add(index, items.items[index]);
    }

    [LineNumberTable(new byte[] {160, 80, 111, 105, 116, 107, 113, 110, 105, 236, 57, 233, 74})]
    [arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Item take()
    {
      for (int index1 = 0; index1 < this.items.Length; ++index1)
      {
        int id = index1 + this.takeRotation;
        if (id >= this.items.Length)
          id -= this.items.Length;
        if (this.items[id] > 0)
        {
          int[] items = this.items;
          int index2 = id;
          int[] numArray = items;
          numArray[index2] = numArray[index2] - 1;
          --this.total;
          this.takeRotation = id + 1;
          return Vars.content.item(id);
        }
      }
      return (Item) null;
    }

    [LineNumberTable(new byte[] {160, 159, 104, 154})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void undoFlow(Item item)
    {
      if (this.flow == null)
        return;
      float[] cacheSums = ItemModule.cacheSums;
      int id = (int) item.__\u003C\u003Eid;
      float[] numArray = cacheSums;
      numArray[id] = numArray[id] - 1f;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool any() => this.total > 0;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool empty() => this.total == 0;

    [LineNumberTable(new byte[] {160, 96, 108, 100, 116, 107, 236, 60, 230, 71})]
    [arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Item takeIndex(int takeRotation)
    {
      for (int index = 0; index < this.items.Length; ++index)
      {
        int id = index + takeRotation;
        if (id >= this.items.Length)
          id -= this.items.Length;
        if (this.items[id] > 0)
          return Vars.content.item(id);
      }
      return (Item) null;
    }

    [LineNumberTable(new byte[] {160, 107, 108, 100, 116, 107, 245, 60, 230, 71})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int nextIndex(int takeRotation)
    {
      for (int index1 = 1; index1 < this.items.Length; ++index1)
      {
        int index2 = index1 + takeRotation;
        if (index2 >= this.items.Length)
          index2 -= this.items.Length;
        if (this.items[index2] > 0)
        {
          int num = takeRotation + index1;
          int length = this.items.Length;
          return length == -1 ? 0 : num % length;
        }
      }
      return takeRotation;
    }

    [LineNumberTable(new byte[] {160, 184, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void remove(ItemStack stack) => this.remove(stack.item, stack.amount);

    [LineNumberTable(new byte[] {160, 151, 113, 110, 104, 146})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void add([In] int obj0, [In] int obj1)
    {
      int[] items = this.items;
      int index1 = obj0;
      int[] numArray1 = items;
      numArray1[index1] = numArray1[index1] + obj1;
      this.total += obj1;
      if (this.flow == null)
        return;
      float[] cacheSums = ItemModule.cacheSums;
      int index2 = obj0;
      float[] numArray2 = cacheSums;
      numArray2[index2] = numArray2[index2] + (float) obj1;
    }

    [LineNumberTable(new byte[] {88, 127, 5, 112, 130, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool has(ItemSeq items)
    {
      Iterator iterator = Vars.content.items().iterator();
      while (iterator.hasNext())
      {
        Item obj = (Item) iterator.next();
        if (!this.has(obj, items.get(obj)))
          return false;
      }
      return true;
    }

    [Signature("(Ljava/lang/Iterable<Lmindustry/type/ItemStack;>;)Z")]
    [LineNumberTable(new byte[] {97, 123, 118, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool has(Iterable stacks)
    {
      Iterator iterator = stacks.iterator();
      while (iterator.hasNext())
      {
        ItemStack itemStack = (ItemStack) iterator.next();
        if (!this.has(itemStack.item, itemStack.amount))
          return false;
      }
      return true;
    }

    [LineNumberTable(new byte[] {114, 111, 49, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool hasOne(ItemStack[] stacks)
    {
      ItemStack[] itemStackArray = stacks;
      int length = itemStackArray.Length;
      for (int index = 0; index < length; ++index)
      {
        if (!this.has(itemStackArray[index].item, 1))
          return false;
      }
      return true;
    }

    [LineNumberTable(new byte[] {160, 176, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void remove(ItemSeq stacks) => stacks.each((ItemModule.ItemConsumer) new ItemModule.__\u003C\u003EAnon1(this));

    [Signature("(Ljava/lang/Iterable<Lmindustry/type/ItemStack;>;)V")]
    [LineNumberTable(new byte[] {160, 180, 127, 16})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void remove(Iterable stacks)
    {
      Iterator iterator = stacks.iterator();
      while (iterator.hasNext())
      {
        ItemStack itemStack = (ItemStack) iterator.next();
        this.remove(itemStack.item, itemStack.amount);
      }
    }

    [LineNumberTable(new byte[] {159, 139, 141, 234, 70, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static ItemModule()
    {
      if (ByteCodeHelper.isAlreadyInited("mindustry.world.modules.ItemModule"))
        return;
      ItemModule.__\u003C\u003Eempty = new ItemModule();
      ItemModule.cacheBits = new Bits();
      ItemModule.flowTimer = new Interval(2);
    }

    [Modifiers]
    public static ItemModule empty
    {
      [HideFromJava] get => ItemModule.__\u003C\u003Eempty;
    }

    public interface ItemCalculator
    {
      float get(Item i1, int i2);
    }

    public interface ItemConsumer
    {
      void accept(Item i1, int i2);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : ItemModule.ItemConsumer
    {
      private readonly ItemModule arg\u00241;

      internal __\u003C\u003EAnon0([In] ItemModule obj0) => this.arg\u00241 = obj0;

      public void accept([In] Item obj0, [In] int obj1) => this.arg\u00241.add(obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : ItemModule.ItemConsumer
    {
      private readonly ItemModule arg\u00241;

      internal __\u003C\u003EAnon1([In] ItemModule obj0) => this.arg\u00241 = obj0;

      public void accept([In] Item obj0, [In] int obj1) => this.arg\u00241.remove(obj0, obj1);
    }
  }
}
