// Decompiled with JetBrains decompiler
// Type: mindustry.type.ItemSeq
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.func;
using arc.util.serialization;
using IKVM.Attributes;
using ikvm.lang;
using IKVM.Runtime;
using java.lang;
using java.util;
using java.util.function;
using mindustry.io;
using mindustry.world.modules;
using System;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.type
{
  [Signature("Ljava/lang/Object;Ljava/lang/Iterable<Lmindustry/type/ItemStack;>;Larc/util/serialization/Json$JsonSerializable;")]
  [Implements(new string[] {"java.lang.Iterable", "arc.util.serialization.Json$JsonSerializable"})]
  public class ItemSeq : Object, Iterable, IEnumerable, Json.JsonSerializable
  {
    internal int[] __\u003C\u003Evalues;
    public int total;

    [LineNumberTable(82)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int get(Item item) => this.__\u003C\u003Evalues[(int) item.__\u003C\u003Eid];

    [LineNumberTable(new byte[] {56, 118, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void add(Item item, int amount)
    {
      int[] values = this.__\u003C\u003Evalues;
      int id = (int) item.__\u003C\u003Eid;
      int[] numArray = values;
      numArray[id] = numArray[id] + amount;
      this.total += amount;
    }

    [LineNumberTable(new byte[] {159, 159, 232, 61, 218})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ItemSeq()
    {
      ItemSeq itemSeq = this;
      this.__\u003C\u003Evalues = new int[Vars.content.items().size];
    }

    [LineNumberTable(new byte[] {159, 188, 103, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void clear()
    {
      this.total = 0;
      Arrays.fill(this.__\u003C\u003Evalues, 0);
    }

    [LineNumberTable(new byte[] {36, 118})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void set(Item item, int amount) => this.add(item, amount - this.__\u003C\u003Evalues[(int) item.__\u003C\u003Eid]);

    [LineNumberTable(new byte[] {159, 167, 108, 52, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void checkNegative()
    {
      for (int index = 0; index < this.__\u003C\u003Evalues.Length; ++index)
      {
        if (this.__\u003C\u003Evalues[index] < 0)
          this.__\u003C\u003Evalues[index] = 0;
      }
    }

    [LineNumberTable(new byte[] {44, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void add(ItemSeq seq) => seq.each((ItemModule.ItemConsumer) new ItemSeq.__\u003C\u003EAnon1(this));

    [LineNumberTable(new byte[] {48, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void add(ItemStack stack) => this.add(stack.item, stack.amount);

    [LineNumberTable(new byte[] {159, 180, 108, 106, 25, 230, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void each(ItemModule.ItemConsumer cons)
    {
      for (int id = 0; id < this.__\u003C\u003Evalues.Length; ++id)
      {
        if (this.__\u003C\u003Evalues[id] != 0)
          cons.accept(Vars.content.item(id), this.__\u003C\u003Evalues[id]);
      }
    }

    [Signature("()Larc/struct/Seq<Lmindustry/type/ItemStack;>;")]
    [LineNumberTable(new byte[] {1, 102, 108, 63, 14, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Seq toSeq()
    {
      Seq seq1 = new Seq();
      for (int id = 0; id < this.__\u003C\u003Evalues.Length; ++id)
      {
        if (this.__\u003C\u003Evalues[id] != 0)
        {
          Seq seq2 = seq1;
          ItemStack.__\u003Cclinit\u003E();
          ItemStack itemStack = new ItemStack(Vars.content.item(id), this.__\u003C\u003Evalues[id]);
          seq2.add((object) itemStack);
        }
      }
      return seq1;
    }

    [Signature("(Larc/struct/Seq<Lmindustry/type/ItemStack;>;)V")]
    [LineNumberTable(new byte[] {159, 162, 232, 58, 250, 71, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ItemSeq(Seq stacks)
    {
      ItemSeq itemSeq = this;
      this.__\u003C\u003Evalues = new int[Vars.content.items().size];
      stacks.each((Cons) new ItemSeq.__\u003C\u003EAnon0(this));
    }

    [LineNumberTable(new byte[] {159, 173, 102, 108, 122})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual ItemSeq copy()
    {
      ItemSeq itemSeq = new ItemSeq();
      itemSeq.total = this.total;
      ByteCodeHelper.arraycopy_primitive_4((Array) this.__\u003C\u003Evalues, 0, (Array) itemSeq.__\u003C\u003Evalues, 0, this.__\u003C\u003Evalues.Length);
      return itemSeq;
    }

    [LineNumberTable(new byte[] {9, 127, 5, 116, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void min(int number)
    {
      Iterator iterator = Vars.content.items().iterator();
      while (iterator.hasNext())
      {
        Item obj = (Item) iterator.next();
        this.set(obj, Math.min(this.get(obj), number));
      }
    }

    [LineNumberTable(65)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool has(Item item) => this.__\u003C\u003Evalues[(int) item.__\u003C\u003Eid] > 0;

    [LineNumberTable(new byte[] {19, 108, 114, 2, 230, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool has(ItemSeq seq)
    {
      for (int index = 0; index < this.__\u003C\u003Evalues.Length; ++index)
      {
        if (seq.__\u003C\u003Evalues[index] > this.__\u003C\u003Evalues[index])
          return false;
      }
      return true;
    }

    [LineNumberTable(78)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool has(Item item, int amount) => this.__\u003C\u003Evalues[(int) item.__\u003C\u003Eid] >= amount;

    [LineNumberTable(new byte[] {40, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void add(ItemModule itemModule) => itemModule.each((ItemModule.ItemConsumer) new ItemSeq.__\u003C\u003EAnon1(this));

    [LineNumberTable(new byte[] {52, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void add(Item item) => this.add(item, 1);

    [LineNumberTable(new byte[] {61, 115})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void remove(ItemStack stack) => this.add(stack.item, -stack.amount);

    [LineNumberTable(new byte[] {65, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void remove(Item item) => this.add(item, -1);

    [LineNumberTable(new byte[] {69, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void remove(Item item, int amount) => this.add(item, -amount);

    [LineNumberTable(new byte[] {74, 127, 5, 111, 158, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void write(Json json)
    {
      Iterator iterator = Vars.content.items().iterator();
      while (iterator.hasNext())
      {
        Item obj = (Item) iterator.next();
        if (this.__\u003C\u003Evalues[(int) obj.__\u003C\u003Eid] != 0)
          json.writeValue(obj.__\u003C\u003Ename, (object) Integer.valueOf(this.__\u003C\u003Evalues[(int) obj.__\u003C\u003Eid]));
      }
    }

    [LineNumberTable(new byte[] {83, 103, 127, 5, 122, 122, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void read(Json json, JsonValue jsonData)
    {
      this.total = 0;
      Iterator iterator = Vars.content.items().iterator();
      while (iterator.hasNext())
      {
        Item obj = (Item) iterator.next();
        this.__\u003C\u003Evalues[(int) obj.__\u003C\u003Eid] = jsonData.getInt(obj.__\u003C\u003Ename, 0);
        this.total += this.__\u003C\u003Evalues[(int) obj.__\u003C\u003Eid];
      }
    }

    [LineNumberTable(142)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toString() => JsonIO.print(JsonIO.write((object) this));

    [Signature("()Ljava/util/Iterator<Lmindustry/type/ItemStack;>;")]
    [LineNumberTable(147)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Iterator iterator() => this.toSeq().iterator();

    [HideFromJava]
    public virtual void forEach([In] Consumer obj0) => Iterable.\u003Cdefault\u003EforEach((Iterable) this, obj0);

    [HideFromJava]
    public virtual Spliterator spliterator() => Iterable.\u003Cdefault\u003Espliterator((Iterable) this);

    [HideFromJava]
    [SpecialName]
    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) new IterableEnumerator((Iterable) this);

    [Modifiers]
    protected internal int[] values
    {
      [HideFromJava] get => this.__\u003C\u003Evalues;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Evalues = value;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Cons
    {
      private readonly ItemSeq arg\u00241;

      internal __\u003C\u003EAnon0([In] ItemSeq obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.add((ItemStack) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : ItemModule.ItemConsumer
    {
      private readonly ItemSeq arg\u00241;

      internal __\u003C\u003EAnon1([In] ItemSeq obj0) => this.arg\u00241 = obj0;

      public void accept([In] Item obj0, [In] int obj1) => this.arg\u00241.add(obj0, obj1);
    }
  }
}
