// Decompiled with JetBrains decompiler
// Type: arc.struct.PQueue
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.util;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.util;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.@struct
{
  [Signature("<E:Ljava/lang/Object;>Ljava/lang/Object;")]
  public class PQueue : Object
  {
    private const double CAPACITY_RATIO_LOW = 1.5;
    private const double CAPACITY_RATIO_HI = 2.0;
    public object[] queue;
    public int size;
    [Signature("Ljava/util/Comparator<TE;>;")]
    public Comparator comparator;

    [LineNumberTable(new byte[] {41, 122, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void clear()
    {
      for (int index = 0; index < this.size; ++index)
        this.queue[index] = (object) null;
      this.size = 0;
    }

    [Signature("(TE;)Z")]
    [LineNumberTable(new byte[] {5, 115, 103, 115, 105, 99, 139, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool add(object e)
    {
      if (e == null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException("Element cannot be null.");
      }
      int size = this.size;
      if (size >= this.queue.Length)
        this.growToSize(size + 1);
      this.size = size + 1;
      if (size == 0)
        this.queue[0] = e;
      else
        this.siftUp(size, e);
      return true;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool empty() => this.size == 0;

    [Signature("()TE;")]
    [LineNumberTable(new byte[] {50, 106, 116, 105, 106, 105, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object poll()
    {
      if (this.size == 0)
        return (object) null;
      PQueue pqueue1 = this;
      int num1 = pqueue1.size - 1;
      PQueue pqueue2 = pqueue1;
      int num2 = num1;
      pqueue2.size = num1;
      int index = num2;
      object obj1 = this.queue[0];
      object obj2 = this.queue[index];
      this.queue[index] = (object) null;
      if (index != 0)
        this.siftDown(0, obj2);
      return obj1;
    }

    [Signature("(ILjava/util/Comparator<TE;>;)V")]
    [LineNumberTable(new byte[] {159, 179, 232, 47, 231, 82, 108, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public PQueue(int initialCapacity, Comparator comparator)
    {
      PQueue pqueue = this;
      this.size = 0;
      this.queue = new object[initialCapacity];
      this.comparator = comparator;
    }

    [LineNumberTable(new byte[] {105, 100, 112, 136, 127, 10, 100, 102, 102, 103, 116, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void growToSize([In] int obj0)
    {
      if (obj0 < 0)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new ArcRuntimeException("Capacity upper limit exceeded.");
      }
      int length1 = this.queue.Length;
      int length2 = ByteCodeHelper.d2i(length1 >= 64 ? (double) length1 * 1.5 : (double) (length1 + 1) * 2.0);
      if (length2 < 0)
        length2 = int.MaxValue;
      if (length2 < obj0)
        length2 = obj0;
      object[] objArray = new object[length2];
      ByteCodeHelper.arraycopy((object) this.queue, 0, (object) objArray, 0, this.size);
      this.queue = objArray;
    }

    [Signature("(ITE;)V")]
    [LineNumberTable(new byte[] {66, 100, 102, 105, 109, 105, 99, 98, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void siftUp([In] int obj0, [In] object obj1)
    {
      int index;
      for (; obj0 > 0; obj0 = index)
      {
        index = (int) ((uint) (obj0 - 1) >> 1);
        object obj = this.queue[index];
        if (this.compare(obj1, obj) < 0)
          this.queue[obj0] = obj;
        else
          break;
      }
      this.queue[obj0] = obj1;
    }

    [Signature("(ITE;)V")]
    [LineNumberTable(new byte[] {83, 105, 103, 102, 105, 100, 127, 7, 109, 105, 99, 101, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void siftDown([In] int obj0, [In] object obj1)
    {
      int index1;
      for (int index2 = (int) ((uint) this.size >> 1); obj0 < index2; obj0 = index1)
      {
        index1 = (obj0 << 1) + 1;
        object obj = this.queue[index1];
        int index3 = index1 + 1;
        if (index3 < this.size && this.compare(obj, this.queue[index3]) > 0)
          obj = this.queue[index1 = index3];
        if (this.compare(obj1, obj) > 0)
          this.queue[obj0] = obj;
        else
          break;
      }
      this.queue[obj0] = obj1;
    }

    [Signature("(TE;TE;)I")]
    [LineNumberTable(147)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private int compare([In] object obj0, [In] object obj1) => this.comparator == null ? Comparable.__Helper.compareTo((IComparable) obj0, obj1) : this.comparator.compare(obj0, obj1);

    [LineNumberTable(new byte[] {159, 171, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public PQueue()
      : this(12, (Comparator) null)
    {
    }

    [Signature("()TE;")]
    [LineNumberTable(71)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object peek() => this.size == 0 ? (object) null : this.queue[0];

    [Signature("(I)TE;")]
    [LineNumberTable(81)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object get(int index) => index >= this.size ? (object) null : this.queue[index];

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int size() => this.size;
  }
}
