// Decompiled with JetBrains decompiler
// Type: arc.struct.OrderedSet
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using IKVM.Attributes;
using java.lang;
using java.util;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace arc.@struct
{
  [Signature("<T:Ljava/lang/Object;>Larc/struct/ObjectSet<TT;>;")]
  public class OrderedSet : ObjectSet
  {
    [Modifiers]
    [Signature("Larc/struct/Seq<TT;>;")]
    internal Seq items;
    [Signature("Larc/struct/OrderedSet<TT;>.OrderedSetIterator;")]
    internal OrderedSet.OrderedSetIterator iterator1;
    [Signature("Larc/struct/OrderedSet<TT;>.OrderedSetIterator;")]
    internal OrderedSet.OrderedSetIterator iterator2;

    [LineNumberTable(new byte[] {159, 160, 104, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public OrderedSet()
    {
      OrderedSet orderedSet = this;
      this.items = new Seq();
    }

    [LineNumberTable(new byte[] {28, 108, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void clear()
    {
      this.items.clear();
      base.clear();
    }

    [Signature("(TT;)Z")]
    [LineNumberTable(new byte[] {159, 187, 107, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool add(object key)
    {
      if (!base.add(key))
        return false;
      this.items.add(key);
      return true;
    }

    [Signature("(TT;)Z")]
    [LineNumberTable(new byte[] {11, 107, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool remove(object key)
    {
      if (!base.remove(key))
        return false;
      this.items.remove(key, false);
      return true;
    }

    [Signature("()Larc/struct/OrderedSet<TT;>.OrderedSetIterator;")]
    [LineNumberTable(new byte[] {38, 104, 108, 172, 109, 107, 167, 109, 107, 167})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual OrderedSet.OrderedSetIterator iterator()
    {
      if (this.iterator1 == null)
      {
        this.iterator1 = new OrderedSet.OrderedSetIterator(this);
        this.iterator2 = new OrderedSet.OrderedSetIterator(this);
      }
      if (this.iterator1.done)
      {
        this.iterator1.reset();
        return this.iterator1;
      }
      if (!this.iterator2.done)
        return new OrderedSet.OrderedSetIterator(this);
      this.iterator2.reset();
      return this.iterator2;
    }

    [Signature("()Larc/struct/Seq<TT;>;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Seq orderedItems() => this.items;

    [Signature("()TT;")]
    [LineNumberTable(41)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override object first() => this.items.first();

    [LineNumberTable(new byte[] {23, 108, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void clear(int maximumCapacity)
    {
      this.items.clear();
      base.clear(maximumCapacity);
    }

    [LineNumberTable(new byte[] {58, 110, 108, 104, 105, 106, 107, 108, 10, 198, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string toString()
    {
      if (this.size == 0)
        return "{}";
      object[] items = this.items.items;
      StringBuilder stringBuilder = new StringBuilder(32);
      stringBuilder.append('{');
      stringBuilder.append(items[0]);
      for (int index = 1; index < this.size; ++index)
      {
        stringBuilder.append(", ");
        stringBuilder.append(items[index]);
      }
      stringBuilder.append('}');
      return stringBuilder.toString();
    }

    [Signature("(I)TT;")]
    [LineNumberTable(new byte[] {17, 109, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object removeIndex(int index)
    {
      object key = this.items.remove(index);
      base.remove(key);
      return key;
    }

    [LineNumberTable(new byte[] {159, 165, 107, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public OrderedSet(int initialCapacity, float loadFactor)
      : base(initialCapacity, loadFactor)
    {
      OrderedSet orderedSet = this;
      this.items = new Seq(this.capacity);
    }

    [LineNumberTable(new byte[] {159, 170, 105, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public OrderedSet(int initialCapacity)
      : base(initialCapacity)
    {
      OrderedSet orderedSet = this;
      this.items = new Seq(this.capacity);
    }

    [LineNumberTable(new byte[] {159, 176, 105, 113, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public OrderedSet(OrderedSet set)
      : base((ObjectSet) set)
    {
      OrderedSet orderedSet = this;
      this.items = new Seq(this.capacity);
      this.items.addAll(set.items);
    }

    [Signature("(TT;I)Z")]
    [LineNumberTable(new byte[] {1, 105, 110, 109, 130, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool add(object key, int index)
    {
      if (!base.add(key))
      {
        this.items.remove(key, true);
        this.items.insert(index, key);
        return false;
      }
      this.items.insert(index, key);
      return true;
    }

    [LineNumberTable(122)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string toString(string separator) => this.items.toString(separator);

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(14)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual ObjectSet.ObjectSetIterator \u003Cbridge\u003Eiterator() => (ObjectSet.ObjectSetIterator) this.iterator();

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(14)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override Iterator \u003Cbridge\u003Eiterator() => (Iterator) this.iterator();

    [Signature("Larc/struct/ObjectSet<TT;>.ObjectSetIterator;")]
    public class OrderedSetIterator : ObjectSet.ObjectSetIterator
    {
      [Modifiers]
      internal OrderedSet this\u00240;

      [LineNumberTable(125)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public OrderedSetIterator(OrderedSet _param1)
      {
        this.this\u00240 = _param1;
        // ISSUE: explicit constructor call
        base.\u002Ector((ObjectSet) _param1);
      }

      [LineNumberTable(new byte[] {79, 102, 103, 116})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void reset()
      {
        base.reset();
        this.nextIndex = 0;
        this.hasNext = this.this\u00240.size > 0;
      }

      [Signature("()TT;")]
      [LineNumberTable(new byte[] {86, 115, 119, 110, 121})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override object next()
      {
        if (!this.hasNext)
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new NoSuchElementException();
        }
        object obj = this.this\u00240.items.get(this.nextIndex);
        ++this.nextIndex;
        this.hasNext = this.nextIndex < this.this\u00240.size;
        return obj;
      }

      [LineNumberTable(new byte[] {95, 121, 110, 114})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void remove()
      {
        if (this.nextIndex < 0)
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalStateException("next must be called before remove.");
        }
        --this.nextIndex;
        this.this\u00240.removeIndex(this.nextIndex);
      }
    }
  }
}
