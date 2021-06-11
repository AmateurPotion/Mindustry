// Decompiled with JetBrains decompiler
// Type: arc.struct.LongQueue
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.util;
using System;
using System.Runtime.CompilerServices;

namespace arc.@struct
{
  public class LongQueue : Object
  {
    public int size;
    protected internal long[] values;
    protected internal int head;
    protected internal int tail;

    [LineNumberTable(new byte[] {159, 183, 135, 106, 106, 167, 118, 106, 135, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addLast(long @object)
    {
      long[] values = this.values;
      if (this.size == values.Length)
      {
        this.resize(values.Length << 1);
        values = this.values;
      }
      long[] numArray = values;
      LongQueue longQueue1 = this;
      int tail = longQueue1.tail;
      LongQueue longQueue2 = longQueue1;
      int index = tail;
      longQueue2.tail = tail + 1;
      long num = @object;
      numArray[index] = num;
      if (this.tail == values.Length)
        this.tail = 0;
      ++this.size;
    }

    [LineNumberTable(new byte[] {159, 167, 232, 47, 199, 231, 69, 231, 73, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public LongQueue(int initialSize)
    {
      LongQueue longQueue = this;
      this.size = 0;
      this.head = 0;
      this.tail = 0;
      this.values = new long[initialSize];
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isEmpty() => this.size == 0;

    [LineNumberTable(new byte[] {67, 136, 176, 135, 105, 106, 110, 106, 135, 142})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual long removeFirst()
    {
      if (this.size == 0)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new NoSuchElementException("Queue is empty.");
      }
      long[] values = this.values;
      long num = values[this.head];
      values[this.head] = 0L;
      ++this.head;
      if (this.head == values.Length)
        this.head = 0;
      --this.size;
      return num;
    }

    [LineNumberTable(new byte[] {42, 103, 103, 135, 103, 132, 110, 137, 102, 107, 139, 103, 103, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void resize(int newSize)
    {
      long[] values = this.values;
      int head = this.head;
      int tail = this.tail;
      long[] numArray = new long[newSize];
      if (head < tail)
        ByteCodeHelper.arraycopy_primitive_8((Array) values, head, (Array) numArray, 0, tail - head);
      else if (this.size > 0)
      {
        int num = values.Length - head;
        ByteCodeHelper.arraycopy_primitive_8((Array) values, head, (Array) numArray, 0, num);
        ByteCodeHelper.arraycopy_primitive_8((Array) values, 0, (Array) numArray, num, tail);
      }
      this.values = numArray;
      this.head = 0;
      this.tail = this.size;
    }

    [LineNumberTable(new byte[] {116, 106, 103, 110, 100, 102, 42, 171, 107, 42, 134, 102, 45, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int indexOf(long value, bool identity)
    {
      if (this.size == 0)
        return -1;
      long[] values = this.values;
      int head = this.head;
      int tail = this.tail;
      if (head < tail)
      {
        for (int index = head; index < tail; ++index)
        {
          if (values[index] == value)
            return index - head;
        }
      }
      else
      {
        int index1 = head;
        for (int length = values.Length; index1 < length; ++index1)
        {
          if (values[index1] == value)
            return index1 - head;
        }
        for (int index2 = 0; index2 < tail; ++index2)
        {
          if (values[index2] == value)
            return index2 + values.Length - head;
        }
      }
      return -1;
    }

    [LineNumberTable(new byte[] {160, 81, 127, 10, 159, 36, 103, 110, 133, 100, 100, 110, 115, 101, 102, 100, 110, 144, 100, 110, 110, 106, 167, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual long removeIndex(int index)
    {
      if (index < 0)
      {
        string str = new StringBuilder().append("index can't be < 0: ").append(index).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IndexOutOfBoundsException(str);
      }
      if (index >= this.size)
      {
        string str = new StringBuilder().append("index can't be >= size: ").append(index).append(" >= ").append(this.size).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IndexOutOfBoundsException(str);
      }
      long[] values = this.values;
      int head = this.head;
      int tail = this.tail;
      index += head;
      long num;
      if (head < tail)
      {
        num = values[index];
        ByteCodeHelper.arraycopy_primitive_8((Array) values, index + 1, (Array) values, index, tail - index);
        --this.tail;
      }
      else if (index >= values.Length)
      {
        index -= values.Length;
        num = values[index];
        ByteCodeHelper.arraycopy_primitive_8((Array) values, index + 1, (Array) values, index, tail - index);
        --this.tail;
      }
      else
      {
        num = values[index];
        ByteCodeHelper.arraycopy_primitive_8((Array) values, head, (Array) values, head + 1, index - head);
        ++this.head;
        if (this.head == values.Length)
          this.head = 0;
      }
      --this.size;
      return num;
    }

    [LineNumberTable(new byte[] {160, 154, 127, 10, 127, 36, 135, 105, 101, 133})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual long get(int index)
    {
      if (index < 0)
      {
        string str = new StringBuilder().append("index can't be < 0: ").append(index).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IndexOutOfBoundsException(str);
      }
      if (index >= this.size)
      {
        string str = new StringBuilder().append("index can't be >= size: ").append(index).append(" >= ").append(this.size).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IndexOutOfBoundsException(str);
      }
      long[] values = this.values;
      int index1 = this.head + index;
      if (index1 >= values.Length)
        index1 -= values.Length;
      return values[index1];
    }

    [LineNumberTable(new byte[] {159, 163, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public LongQueue()
      : this(16)
    {
    }

    [LineNumberTable(new byte[] {159, 172, 113, 103, 41, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public LongQueue(long[] array)
      : this(Math.max(array.Length, 16))
    {
      LongQueue longQueue = this;
      for (int index = 0; index < array.Length; ++index)
        this.addLast(array[index]);
    }

    [LineNumberTable(new byte[] {11, 135, 106, 106, 167, 103, 100, 100, 133, 132, 103, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addFirst(long @object)
    {
      long[] values = this.values;
      if (this.size == values.Length)
      {
        this.resize(values.Length << 1);
        values = this.values;
      }
      int index = this.head - 1;
      if (index == -1)
        index = values.Length - 1;
      values[index] = @object;
      this.head = index;
      ++this.size;
    }

    [LineNumberTable(new byte[] {34, 105, 106, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void ensureCapacity(int additional)
    {
      int newSize = this.size + additional;
      if (this.values.Length >= newSize)
        return;
      this.resize(newSize);
    }

    [LineNumberTable(new byte[] {92, 104, 176, 103, 103, 100, 100, 133, 100, 101, 103, 142})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual long removeLast()
    {
      if (this.size == 0)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new NoSuchElementException("Queue is empty.");
      }
      long[] values = this.values;
      int index = this.tail - 1;
      if (index == -1)
        index = values.Length - 1;
      long num = values[index];
      values[index] = 0L;
      this.tail = index;
      --this.size;
      return num;
    }

    [LineNumberTable(new byte[] {159, 96, 162, 105, 102, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool removeValue(long value, bool identity)
    {
      int num = identity ? 1 : 0;
      int index = this.indexOf(value, num != 0);
      if (index == -1)
        return false;
      this.removeIndex(index);
      return true;
    }

    [LineNumberTable(new byte[] {160, 121, 136, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual long first()
    {
      if (this.size == 0)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new NoSuchElementException("Queue is empty.");
      }
      return this.values[this.head];
    }

    [LineNumberTable(new byte[] {160, 135, 136, 144, 103, 103, 100, 100, 133})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual long last()
    {
      if (this.size == 0)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new NoSuchElementException("Queue is empty.");
      }
      long[] values = this.values;
      int index = this.tail - 1;
      if (index == -1)
        index = values.Length - 1;
      return values[index];
    }

    [LineNumberTable(new byte[] {160, 166, 127, 10, 127, 36, 135, 105, 101, 133, 100})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void set(int index, long value)
    {
      if (index < 0)
      {
        string str = new StringBuilder().append("index can't be < 0: ").append(index).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IndexOutOfBoundsException(str);
      }
      if (index >= this.size)
      {
        string str = new StringBuilder().append("index can't be >= size: ").append(index).append(" >= ").append(this.size).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IndexOutOfBoundsException(str);
      }
      long[] values = this.values;
      int index1 = this.head + index;
      if (index1 >= values.Length)
        index1 -= values.Length;
      values[index1] = value;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void clear()
    {
      if (this.size == 0)
        return;
      this.head = 0;
      this.tail = 0;
      this.size = 0;
    }

    [LineNumberTable(new byte[] {160, 186, 108, 107, 42, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual long[] toArray()
    {
      long[] numArray = new long[this.size];
      for (int index = 0; index < this.size; ++index)
        numArray[index] = this.get(index);
      return numArray;
    }

    [LineNumberTable(new byte[] {160, 194, 104, 134, 103, 103, 135, 104, 105, 106, 118, 53, 180, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toString()
    {
      if (this.size == 0)
        return "[]";
      long[] values = this.values;
      int head = this.head;
      int tail = this.tail;
      StringBuilder stringBuilder = new StringBuilder(64);
      stringBuilder.append('[');
      stringBuilder.append(values[head]);
      int num1 = head + 1;
      int length1 = values.Length;
      int num2;
      int length2;
      for (int index = length1 != -1 ? num1 % length1 : 0; index != tail; index = length2 != -1 ? num2 % length2 : 0)
      {
        stringBuilder.append(", ").append(values[index]);
        num2 = index + 1;
        length2 = values.Length;
      }
      stringBuilder.append(']');
      return stringBuilder.toString();
    }
  }
}
