// Decompiled with JetBrains decompiler
// Type: arc.struct.OrderedMap
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.util;
using IKVM.Attributes;
using java.lang;
using java.util;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace arc.@struct
{
  [Signature("<K:Ljava/lang/Object;V:Ljava/lang/Object;>Larc/struct/ObjectMap<TK;TV;>;")]
  public class OrderedMap : ObjectMap
  {
    [Modifiers]
    [Signature("Larc/struct/Seq<TK;>;")]
    internal Seq keys;

    [Signature("<K:Ljava/lang/Object;V:Ljava/lang/Object;>([Ljava/lang/Object;)Larc/struct/OrderedMap<TK;TV;>;")]
    [LineNumberTable(new byte[] {159, 161, 134, 105, 51, 198})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static OrderedMap of(params object[] values)
    {
      OrderedMap orderedMap = new OrderedMap();
      for (int index = 0; index < values.Length / 2; ++index)
        orderedMap.put(values[index * 2], values[index * 2 + 1]);
      return orderedMap;
    }

    [LineNumberTable(new byte[] {159, 170, 104, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public OrderedMap()
    {
      OrderedMap orderedMap = this;
      this.keys = new Seq();
    }

    [Signature("(TK;)TV;")]
    [LineNumberTable(new byte[] {3, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override object remove(object key)
    {
      this.keys.remove(key, false);
      return base.remove(key);
    }

    [Signature("()Larc/struct/Seq<TK;>;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Seq orderedKeys() => this.keys;

    [Signature("(TK;TV;)TV;")]
    [LineNumberTable(new byte[] {159, 190, 117})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override object put(object key, object value)
    {
      if (!this.containsKey(key))
        this.keys.add(key);
      return base.put(key, value);
    }

    [LineNumberTable(new byte[] {159, 175, 105, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public OrderedMap(int initialCapacity)
      : base(initialCapacity)
    {
      OrderedMap orderedMap = this;
      this.keys = new Seq(this.capacity);
    }

    [Signature("()Larc/struct/ObjectMap$Entries<TK;TV;>;")]
    [LineNumberTable(76)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override ObjectMap.Entries iterator() => this.entries();

    [Signature("()Larc/struct/ObjectMap$Values<TV;>;")]
    [LineNumberTable(new byte[] {55, 104, 108, 140, 109, 107, 108, 108, 135, 107, 108, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override ObjectMap.Values values()
    {
      if (this.values1 == null)
      {
        this.values1 = (ObjectMap.Values) new OrderedMap.OrderedMapValues(this);
        this.values2 = (ObjectMap.Values) new OrderedMap.OrderedMapValues(this);
      }
      if (!this.values1.valid)
      {
        this.values1.reset();
        this.values1.valid = true;
        this.values2.valid = false;
        return this.values1;
      }
      this.values2.reset();
      this.values2.valid = true;
      this.values1.valid = false;
      return this.values2;
    }

    [Signature("()Larc/struct/ObjectMap$Keys<TK;>;")]
    [LineNumberTable(new byte[] {76, 104, 108, 140, 109, 107, 108, 108, 135, 107, 108, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override ObjectMap.Keys keys()
    {
      if (this.keys1 == null)
      {
        this.keys1 = (ObjectMap.Keys) new OrderedMap.OrderedMapKeys(this);
        this.keys2 = (ObjectMap.Keys) new OrderedMap.OrderedMapKeys(this);
      }
      if (!this.keys1.valid)
      {
        this.keys1.reset();
        this.keys1.valid = true;
        this.keys2.valid = false;
        return this.keys1;
      }
      this.keys2.reset();
      this.keys2.valid = true;
      this.keys1.valid = false;
      return this.keys2;
    }

    [Signature("()Larc/struct/ObjectMap$Entries<TK;TV;>;")]
    [LineNumberTable(new byte[] {34, 104, 108, 140, 109, 107, 108, 108, 135, 107, 108, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override ObjectMap.Entries entries()
    {
      if (this.entries1 == null)
      {
        this.entries1 = (ObjectMap.Entries) new OrderedMap.OrderedMapEntries(this);
        this.entries2 = (ObjectMap.Entries) new OrderedMap.OrderedMapEntries(this);
      }
      if (!this.entries1.valid)
      {
        this.entries1.reset();
        this.entries1.valid = true;
        this.entries2.valid = false;
        return this.entries1;
      }
      this.entries2.reset();
      this.entries2.valid = true;
      this.entries1.valid = false;
      return this.entries2;
    }

    [LineNumberTable(new byte[] {17, 108, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void clear()
    {
      this.keys.clear();
      base.clear();
    }

    [LineNumberTable(new byte[] {159, 180, 107, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public OrderedMap(int initialCapacity, float loadFactor)
      : base(initialCapacity, loadFactor)
    {
      OrderedMap orderedMap = this;
      this.keys = new Seq(this.capacity);
    }

    [Signature("(Larc/struct/OrderedMap<+TK;+TV;>;)V")]
    [LineNumberTable(new byte[] {159, 185, 105, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public OrderedMap(OrderedMap map)
      : base((ObjectMap) map)
    {
      OrderedMap orderedMap = this;
      this.keys = new Seq(map.keys);
    }

    [Signature("(I)TV;")]
    [LineNumberTable(58)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object removeIndex(int index) => base.remove(this.keys.remove(index));

    [LineNumberTable(new byte[] {12, 108, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void clear(int maximumCapacity)
    {
      this.keys.clear();
      base.clear(maximumCapacity);
    }

    [LineNumberTable(new byte[] {93, 110, 104, 105, 103, 109, 105, 112, 105, 105, 239, 59, 230, 71, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string toString()
    {
      if (this.size == 0)
        return "{}";
      StringBuilder stringBuilder = new StringBuilder(32);
      stringBuilder.append('{');
      Seq keys = this.keys;
      int index = 0;
      for (int size = keys.size; index < size; ++index)
      {
        object key = keys.get(index);
        if (index > 0)
          stringBuilder.append(", ");
        stringBuilder.append(key);
        stringBuilder.append('=');
        stringBuilder.append(this.get(key));
      }
      stringBuilder.append('}');
      return stringBuilder.toString();
    }

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(15)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override Iterator \u003Cbridge\u003Eiterator() => (Iterator) this.iterator();

    [Signature("<K:Ljava/lang/Object;V:Ljava/lang/Object;>Larc/struct/ObjectMap$Entries<TK;TV;>;")]
    public class OrderedMapEntries : ObjectMap.Entries
    {
      [Signature("Larc/struct/Seq<TK;>;")]
      private Seq keys;

      [Signature("()Larc/struct/ObjectMap$Entry<TK;TV;>;")]
      [LineNumberTable(new byte[] {122, 115, 120, 124, 127, 2, 110, 121})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override ObjectMap.Entry next()
      {
        if (!this.hasNext)
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new NoSuchElementException();
        }
        if (!this.valid)
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new ArcRuntimeException("#iterator() cannot be used nested.");
        }
        this.entry.key = this.keys.get(this.nextIndex);
        this.entry.value = this.map.get(this.entry.key);
        ++this.nextIndex;
        this.hasNext = this.nextIndex < this.map.size;
        return this.entry;
      }

      [Signature("(Larc/struct/OrderedMap<TK;TV;>;)V")]
      [LineNumberTable(new byte[] {112, 105, 108})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public OrderedMapEntries(OrderedMap map)
        : base((ObjectMap) map)
      {
        OrderedMap.OrderedMapEntries orderedMapEntries = this;
        this.keys = map.keys;
      }

      [LineNumberTable(new byte[] {117, 103, 116})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void reset()
      {
        this.nextIndex = 0;
        this.hasNext = this.map.size > 0;
      }

      [LineNumberTable(new byte[] {160, 68, 121, 119, 110})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void remove()
      {
        if (this.currentIndex < 0)
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalStateException("next must be called before remove.");
        }
        this.map.remove(this.entry.key);
        --this.nextIndex;
      }

      [Modifiers]
      [EditorBrowsable(EditorBrowsableState.Never)]
      [LineNumberTable(158)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override object \u003Cbridge\u003Enext() => (object) this.next();
    }

    [Signature("<K:Ljava/lang/Object;>Larc/struct/ObjectMap$Keys<TK;>;")]
    public class OrderedMapKeys : ObjectMap.Keys
    {
      [Signature("Larc/struct/Seq<TK;>;")]
      private Seq keys;

      [Signature("(Larc/struct/OrderedMap<TK;*>;)V")]
      [LineNumberTable(new byte[] {160, 78, 105, 108})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public OrderedMapKeys(OrderedMap map)
        : base((ObjectMap) map)
      {
        OrderedMap.OrderedMapKeys orderedMapKeys = this;
        this.keys = map.keys;
      }

      [LineNumberTable(new byte[] {160, 83, 103, 116})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void reset()
      {
        this.nextIndex = 0;
        this.hasNext = this.map.size > 0;
      }

      [Signature("()TK;")]
      [LineNumberTable(new byte[] {160, 88, 115, 120, 114, 108, 110, 121})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override object next()
      {
        if (!this.hasNext)
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new NoSuchElementException();
        }
        if (!this.valid)
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new ArcRuntimeException("#iterator() cannot be used nested.");
        }
        object obj = this.keys.get(this.nextIndex);
        this.currentIndex = this.nextIndex;
        ++this.nextIndex;
        this.hasNext = this.nextIndex < this.map.size;
        return obj;
      }

      [LineNumberTable(new byte[] {160, 98, 121, 121, 108, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void remove()
      {
        if (this.currentIndex < 0)
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalStateException("next must be called before remove.");
        }
        ((OrderedMap) this.map).removeIndex(this.nextIndex - 1);
        this.nextIndex = this.currentIndex;
        this.currentIndex = -1;
      }
    }

    [Signature("<V:Ljava/lang/Object;>Larc/struct/ObjectMap$Values<TV;>;")]
    public class OrderedMapValues : ObjectMap.Values
    {
      private Seq keys;

      [Signature("(Larc/struct/OrderedMap<*TV;>;)V")]
      [LineNumberTable(new byte[] {160, 109, 105, 108})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public OrderedMapValues(OrderedMap map)
        : base((ObjectMap) map)
      {
        OrderedMap.OrderedMapValues orderedMapValues = this;
        this.keys = map.keys;
      }

      [LineNumberTable(new byte[] {160, 114, 103, 116})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void reset()
      {
        this.nextIndex = 0;
        this.hasNext = this.map.size > 0;
      }

      [Signature("()TV;")]
      [LineNumberTable(new byte[] {160, 119, 115, 120, 125, 108, 110, 121})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override object next()
      {
        if (!this.hasNext)
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new NoSuchElementException();
        }
        if (!this.valid)
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new ArcRuntimeException("#iterator() cannot be used nested.");
        }
        object obj = this.map.get(this.keys.get(this.nextIndex));
        this.currentIndex = this.nextIndex;
        ++this.nextIndex;
        this.hasNext = this.nextIndex < this.map.size;
        return obj;
      }

      [LineNumberTable(new byte[] {160, 129, 121, 119, 108, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void remove()
      {
        if (this.currentIndex < 0)
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalStateException("next must be called before remove.");
        }
        ((OrderedMap) this.map).removeIndex(this.currentIndex);
        this.nextIndex = this.currentIndex;
        this.currentIndex = -1;
      }
    }
  }
}
