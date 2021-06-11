// Decompiled with JetBrains decompiler
// Type: arc.struct.EnumSet
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using IKVM.Attributes;
using ikvm.lang;
using java.lang;
using java.util;
using java.util.function;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.@struct
{
  [Signature("<T:Ljava/lang/Enum<TT;>;>Ljava/lang/Object;Ljava/lang/Iterable<TT;>;")]
  [Implements(new string[] {"java.lang.Iterable"})]
  public class EnumSet : Object, Iterable, IEnumerable
  {
    private int i;
    [Signature("Larc/struct/EnumSet<TT;>.EnumSetIterator;")]
    private EnumSet.EnumSetIterator iterator;
    [Signature("[TT;")]
    internal Enum[] set;

    [Signature("()Ljava/util/Iterator<TT;>;")]
    [LineNumberTable(new byte[] {159, 174, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Iterator iterator()
    {
      this.iterator.index = 0;
      return (Iterator) this.iterator;
    }

    [Signature("(TT;)Z")]
    [LineNumberTable(23)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool contains(Enum t) => (this.i & 1 << t.ordinal()) != 0;

    [LineNumberTable(27)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int size() => this.set.Length;

    [Signature("<T:Ljava/lang/Enum<TT;>;>([TT;)Larc/struct/EnumSet<TT;>;")]
    [LineNumberTable(new byte[] {159, 156, 102, 103, 112, 57, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static EnumSet of(params Enum[] arr)
    {
      EnumSet enumSet = new EnumSet();
      enumSet.set = arr;
      Enum[] enumArray = arr;
      int length = enumArray.Length;
      for (int index = 0; index < length; ++index)
      {
        Enum @enum = enumArray[index];
        enumSet.i |= 1 << @enum.ordinal();
      }
      return enumSet;
    }

    [LineNumberTable(new byte[] {159, 152, 232, 61, 204})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal EnumSet()
    {
      EnumSet enumSet = this;
      this.iterator = new EnumSet.EnumSetIterator(this);
    }

    [HideFromJava]
    public virtual void forEach([In] Consumer obj0) => Iterable.\u003Cdefault\u003EforEach((Iterable) this, obj0);

    [HideFromJava]
    public virtual Spliterator spliterator() => Iterable.\u003Cdefault\u003Espliterator((Iterable) this);

    [HideFromJava]
    [SpecialName]
    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) new IterableEnumerator((Iterable) this);

    [Signature("Ljava/lang/Object;Ljava/util/Iterator<TT;>;")]
    internal class EnumSetIterator : Object, Iterator
    {
      internal int index;
      [Modifiers]
      internal EnumSet this\u00240;

      [Signature("()TT;")]
      [LineNumberTable(new byte[] {159, 188, 118})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual Enum next()
      {
        if (this.index >= this.this\u00240.set.Length)
          return (Enum) null;
        Enum[] set = this.this\u00240.set;
        EnumSet.EnumSetIterator enumSetIterator1 = this;
        int index1 = enumSetIterator1.index;
        EnumSet.EnumSetIterator enumSetIterator2 = enumSetIterator1;
        int index2 = index1;
        enumSetIterator2.index = index1 + 1;
        return set[index2];
      }

      [LineNumberTable(new byte[] {159, 178, 111})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal EnumSetIterator([In] EnumSet obj0)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector();
        EnumSet.EnumSetIterator enumSetIterator = this;
        this.index = 0;
      }

      [LineNumberTable(41)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual bool hasNext() => this.index < this.this\u00240.set.Length;

      [Modifiers]
      [LineNumberTable(36)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual object next() => (object) this.next();

      [HideFromJava]
      public virtual void remove() => Iterator.\u003Cdefault\u003Eremove((Iterator) this);

      [HideFromJava]
      public virtual void forEachRemaining([In] Consumer obj0) => Iterator.\u003Cdefault\u003EforEachRemaining((Iterator) this, obj0);
    }
  }
}
