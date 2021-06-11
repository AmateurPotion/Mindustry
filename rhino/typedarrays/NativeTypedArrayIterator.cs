// Decompiled with JetBrains decompiler
// Type: rhino.typedarrays.NativeTypedArrayIterator
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using java.util;
using java.util.function;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace rhino.typedarrays
{
  [Signature("<T:Ljava/lang/Object;>Ljava/lang/Object;Ljava/util/ListIterator<TT;>;")]
  [Implements(new string[] {"java.util.ListIterator"})]
  public class NativeTypedArrayIterator : Object, ListIterator, Iterator
  {
    [Modifiers]
    [Signature("Lrhino/typedarrays/NativeTypedArrayView<TT;>;")]
    private NativeTypedArrayView view;
    private int position;
    private int lastPosition;

    [Signature("(Lrhino/typedarrays/NativeTypedArrayView<TT;>;I)V")]
    [LineNumberTable(new byte[] {159, 155, 8, 167, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal NativeTypedArrayIterator([In] NativeTypedArrayView obj0, [In] int obj1)
    {
      NativeTypedArrayIterator typedArrayIterator = this;
      this.lastPosition = -1;
      this.view = obj0;
      this.position = obj1;
    }

    [LineNumberTable(20)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool hasNext() => this.position < this.view.__\u003C\u003Elength;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool hasPrevious() => this.position > 0;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int nextIndex() => this.position;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int previousIndex() => this.position - 1;

    [Signature("()TT;")]
    [LineNumberTable(new byte[] {159, 182, 104, 114, 108, 110, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object next()
    {
      if (this.hasNext())
      {
        object obj = this.view.get(this.position);
        this.lastPosition = this.position;
        ++this.position;
        return obj;
      }
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new NoSuchElementException();
    }

    [Signature("()TT;")]
    [LineNumberTable(new byte[] {1, 104, 110, 108, 146})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object previous()
    {
      if (this.hasPrevious())
      {
        --this.position;
        this.lastPosition = this.position;
        return this.view.get(this.position);
      }
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new NoSuchElementException();
    }

    [Signature("(TT;)V")]
    [LineNumberTable(new byte[] {11, 105, 139, 115})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void set(object t)
    {
      if (this.lastPosition < 0)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalStateException();
      }
      this.view.js_set(this.lastPosition, t);
    }

    [LineNumberTable(69)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void remove()
    {
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new UnsupportedOperationException();
    }

    [Signature("(TT;)V")]
    [LineNumberTable(74)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void add(object t)
    {
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new UnsupportedOperationException();
    }

    [HideFromJava]
    public virtual void forEachRemaining([In] Consumer obj0) => Iterator.\u003Cdefault\u003EforEachRemaining((Iterator) this, obj0);
  }
}
