// Decompiled with JetBrains decompiler
// Type: arc.struct.LongSeq
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.math;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.util;
using System;
using System.Runtime.CompilerServices;

namespace arc.@struct
{
  public class LongSeq : Object
  {
    public long[] items;
    public int size;
    public bool ordered;

    [LineNumberTable(new byte[] {159, 161, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public LongSeq()
      : this(true, 16)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isEmpty() => this.size == 0;

    [LineNumberTable(new byte[] {25, 103, 127, 11, 118})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void add(long value)
    {
      long[] numArray1 = this.items;
      if (this.size == numArray1.Length)
        numArray1 = this.resize(Math.max(8, ByteCodeHelper.f2i((float) this.size * 1.75f)));
      long[] numArray2 = numArray1;
      LongSeq longSeq1 = this;
      int size = longSeq1.size;
      LongSeq longSeq2 = longSeq1;
      int index = size;
      longSeq2.size = size + 1;
      long num = value;
      numArray2[index] = num;
    }

    [LineNumberTable(new byte[] {80, 127, 36})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual long get(int index)
    {
      if (index >= this.size)
      {
        string str = new StringBuilder().append("index can't be >= size: ").append(index).append(" >= ").append(this.size).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IndexOutOfBoundsException(str);
      }
      return this.items[index];
    }

    [LineNumberTable(new byte[] {85, 127, 36, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void set(int index, long value)
    {
      if (index >= this.size)
      {
        string str = new StringBuilder().append("index can't be >= size: ").append(index).append(" >= ").append(this.size).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IndexOutOfBoundsException(str);
      }
      this.items[index] = value;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void clear() => this.size = 0;

    [LineNumberTable(new byte[] {159, 134, 66, 104, 103, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public LongSeq(bool ordered, int capacity)
    {
      int num = ordered ? 1 : 0;
      // ISSUE: explicit constructor call
      base.\u002Ector();
      LongSeq longSeq = this;
      this.ordered = num != 0;
      this.items = new long[capacity];
    }

    [LineNumberTable(new byte[] {159, 126, 66, 107, 104, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public LongSeq(bool ordered, long[] array, int startIndex, int count)
      : this(ordered, count)
    {
      LongSeq longSeq = this;
      this.size = count;
      ByteCodeHelper.arraycopy_primitive_8((Array) array, startIndex, (Array) this.items, 0, count);
    }

    [LineNumberTable(new byte[] {4, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public LongSeq(long[] array)
      : this(true, array, 0, array.Length)
    {
    }

    [LineNumberTable(new byte[] {160, 199, 103, 103, 118, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual long[] resize(int newSize)
    {
      long[] numArray = new long[newSize];
      ByteCodeHelper.arraycopy_primitive_8((Array) this.items, 0, (Array) numArray, 0, Math.min(this.size, numArray.Length));
      this.items = numArray;
      return numArray;
    }

    [LineNumberTable(new byte[] {72, 103, 105, 127, 1, 111, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addAll(long[] array, int offset, int length)
    {
      long[] numArray = this.items;
      int num = this.size + length;
      if (num > numArray.Length)
        numArray = this.resize(Math.max(8, ByteCodeHelper.f2i((float) num * 1.75f)));
      ByteCodeHelper.arraycopy_primitive_8((Array) array, offset, (Array) numArray, this.size, length);
      this.size += length;
    }

    [LineNumberTable(new byte[] {160, 91, 127, 36, 103, 100, 110, 104, 149, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual long removeIndex(int index)
    {
      if (index >= this.size)
      {
        string str = new StringBuilder().append("index can't be >= size: ").append(index).append(" >= ").append(this.size).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IndexOutOfBoundsException(str);
      }
      long[] items = this.items;
      long num = items[index];
      --this.size;
      if (this.ordered)
        ByteCodeHelper.arraycopy_primitive_8((Array) items, index + 1, (Array) items, index, this.size - index);
      else
        items[index] = items[this.size];
      return num;
    }

    [LineNumberTable(new byte[] {159, 166, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public LongSeq(int capacity)
      : this(true, capacity)
    {
    }

    [LineNumberTable(new byte[] {159, 184, 104, 108, 108, 113, 121})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public LongSeq(LongSeq array)
    {
      LongSeq longSeq = this;
      this.ordered = array.ordered;
      this.size = array.size;
      this.items = new long[this.size];
      ByteCodeHelper.arraycopy_primitive_8((Array) array.items, 0, (Array) this.items, 0, this.size);
    }

    [LineNumberTable(71)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static LongSeq with(params long[] array) => new LongSeq(array);

    [LineNumberTable(new byte[] {31, 103, 127, 13, 105, 107, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void add(long value1, long value2)
    {
      long[] numArray = this.items;
      if (this.size + 1 >= numArray.Length)
        numArray = this.resize(Math.max(8, ByteCodeHelper.f2i((float) this.size * 1.75f)));
      numArray[this.size] = value1;
      numArray[this.size + 1] = value2;
      this.size += 2;
    }

    [LineNumberTable(new byte[] {39, 103, 127, 13, 105, 107, 107, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void add(long value1, long value2, long value3)
    {
      long[] numArray = this.items;
      if (this.size + 2 >= numArray.Length)
        numArray = this.resize(Math.max(8, ByteCodeHelper.f2i((float) this.size * 1.75f)));
      numArray[this.size] = value1;
      numArray[this.size + 1] = value2;
      numArray[this.size + 2] = value3;
      this.size += 3;
    }

    [LineNumberTable(new byte[] {48, 103, 127, 13, 105, 107, 107, 108, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void add(long value1, long value2, long value3, long value4)
    {
      long[] numArray = this.items;
      if (this.size + 3 >= numArray.Length)
        numArray = this.resize(Math.max(8, ByteCodeHelper.f2i((float) this.size * 1.8f)));
      numArray[this.size] = value1;
      numArray[this.size + 1] = value2;
      numArray[this.size + 2] = value3;
      numArray[this.size + 3] = value4;
      this.size += 4;
    }

    [LineNumberTable(new byte[] {58, 115})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addAll(LongSeq array) => this.addAll(array.items, 0, array.size);

    [LineNumberTable(new byte[] {62, 107, 127, 43, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addAll(LongSeq array, int offset, int length)
    {
      if (offset + length > array.size)
      {
        string str = new StringBuilder().append("offset + length must be <= size: ").append(offset).append(" + ").append(length).append(" <= ").append(array.size).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException(str);
      }
      this.addAll(array.items, offset, length);
    }

    [LineNumberTable(new byte[] {68, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addAll(params long[] array) => this.addAll(array, 0, array.Length);

    [LineNumberTable(new byte[] {90, 127, 36, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void incr(int index, long value)
    {
      if (index >= this.size)
      {
        string str = new StringBuilder().append("index can't be >= size: ").append(index).append(" >= ").append(this.size).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IndexOutOfBoundsException(str);
      }
      long[] items = this.items;
      int index1 = index;
      long[] numArray = items;
      numArray[index1] = numArray[index1] + value;
    }

    [LineNumberTable(new byte[] {95, 127, 36, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void mul(int index, long value)
    {
      if (index >= this.size)
      {
        string str = new StringBuilder().append("index can't be >= size: ").append(index).append(" >= ").append(this.size).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IndexOutOfBoundsException(str);
      }
      long[] items = this.items;
      int index1 = index;
      long[] numArray = items;
      numArray[index1] = numArray[index1] * value;
    }

    [LineNumberTable(new byte[] {100, 127, 36, 103, 127, 11, 104, 149, 107, 110, 100})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void insert(int index, long value)
    {
      if (index > this.size)
      {
        string str = new StringBuilder().append("index can't be > size: ").append(index).append(" > ").append(this.size).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IndexOutOfBoundsException(str);
      }
      long[] numArray = this.items;
      if (this.size == numArray.Length)
        numArray = this.resize(Math.max(8, ByteCodeHelper.f2i((float) this.size * 1.75f)));
      if (this.ordered)
        ByteCodeHelper.arraycopy_primitive_8((Array) numArray, index, (Array) numArray, index + 1, this.size - index);
      else
        numArray[this.size] = numArray[index];
      ++this.size;
      numArray[index] = value;
    }

    [LineNumberTable(new byte[] {112, 127, 36, 127, 36, 103, 100, 102, 100})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void swap(int first, int second)
    {
      if (first >= this.size)
      {
        string str = new StringBuilder().append("first can't be >= size: ").append(first).append(" >= ").append(this.size).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IndexOutOfBoundsException(str);
      }
      if (second >= this.size)
      {
        string str = new StringBuilder().append("second can't be >= size: ").append(second).append(" >= ").append(this.size).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IndexOutOfBoundsException(str);
      }
      long[] items = this.items;
      long num = items[first];
      items[first] = items[second];
      items[second] = num;
    }

    [LineNumberTable(new byte[] {121, 105, 103, 100, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool contains(long value)
    {
      int num = this.size - 1;
      long[] items = this.items;
      while (num >= 0)
      {
        long[] numArray = items;
        int index = num;
        num += -1;
        if (numArray[index] == value)
          return true;
      }
      return false;
    }

    [LineNumberTable(new byte[] {160, 65, 103, 109, 40, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int indexOf(long value)
    {
      long[] items = this.items;
      int index = 0;
      for (int size = this.size; index < size; ++index)
      {
        if (items[index] == value)
          return index;
      }
      return -1;
    }

    [LineNumberTable(new byte[] {159, 96, 130, 103, 109, 41, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int lastIndexOf(char value)
    {
      int num = (int) value;
      long[] items = this.items;
      for (int index = this.size - 1; index >= 0; index += -1)
      {
        if (items[index] == (long) num)
          return index;
      }
      return -1;
    }

    [LineNumberTable(new byte[] {160, 79, 103, 109, 102, 104, 226, 61, 230, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool removeValue(long value)
    {
      long[] items = this.items;
      int index = 0;
      for (int size = this.size; index < size; ++index)
      {
        if (items[index] == value)
        {
          this.removeIndex(index);
          return true;
        }
      }
      return false;
    }

    [LineNumberTable(new byte[] {160, 104, 127, 36, 127, 26, 103, 102, 104, 151, 105, 102, 42, 166, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void removeRange(int start, int end)
    {
      if (end >= this.size)
      {
        string str = new StringBuilder().append("end can't be >= size: ").append(end).append(" >= ").append(this.size).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IndexOutOfBoundsException(str);
      }
      if (start > end)
      {
        string str = new StringBuilder().append("start can't be > end: ").append(start).append(" > ").append(end).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IndexOutOfBoundsException(str);
      }
      long[] items = this.items;
      int num1 = end - start + 1;
      if (this.ordered)
      {
        ByteCodeHelper.arraycopy_primitive_8((Array) items, start + num1, (Array) items, start, this.size - (start + num1));
      }
      else
      {
        int num2 = this.size - 1;
        for (int index = 0; index < num1; ++index)
          items[start + index] = items[num2 - index];
      }
      this.size -= num1;
    }

    [LineNumberTable(new byte[] {160, 123, 103, 98, 103, 111, 105, 104, 104, 105, 100, 226, 60, 8, 230, 74})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool removeAll(LongSeq array)
    {
      int size1 = this.size;
      int num1 = size1;
      long[] items = this.items;
      int index1 = 0;
      for (int size2 = array.size; index1 < size2; ++index1)
      {
        long num2 = array.get(index1);
        for (int index2 = 0; index2 < size1; ++index2)
        {
          if (num2 == items[index2])
          {
            this.removeIndex(index2);
            size1 += -1;
            break;
          }
        }
      }
      return size1 != num1;
    }

    [LineNumberTable(255)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual long pop()
    {
      long[] items = this.items;
      LongSeq longSeq1 = this;
      int num = longSeq1.size - 1;
      LongSeq longSeq2 = longSeq1;
      int index = num;
      longSeq2.size = num;
      return items[index];
    }

    [LineNumberTable(260)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual long peek() => this.items[this.size - 1];

    [LineNumberTable(new byte[] {160, 151, 120})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual long first()
    {
      if (this.size == 0)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalStateException("Array is empty.");
      }
      return this.items[0];
    }

    [LineNumberTable(new byte[] {160, 170, 124})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual long[] shrink()
    {
      if (this.items.Length != this.size)
        this.resize(this.size);
      return this.items;
    }

    [LineNumberTable(new byte[] {160, 180, 100, 127, 6, 105, 120})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual long[] ensureCapacity(int additionalCapacity)
    {
      if (additionalCapacity < 0)
      {
        string str = new StringBuilder().append("additionalCapacity must be >= 0: ").append(additionalCapacity).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException(str);
      }
      int num = this.size + additionalCapacity;
      if (num > this.items.Length)
        this.resize(Math.max(8, num));
      return this.items;
    }

    [LineNumberTable(new byte[] {160, 192, 127, 10, 120, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual long[] setSize(int newSize)
    {
      if (newSize < 0)
      {
        string str = new StringBuilder().append("newSize must be >= 0: ").append(newSize).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException(str);
      }
      if (newSize > this.items.Length)
        this.resize(Math.max(8, newSize));
      this.size = newSize;
      return this.items;
    }

    [LineNumberTable(new byte[] {160, 207, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void sort() => Arrays.sort(this.items, 0, this.size);

    [LineNumberTable(new byte[] {160, 211, 103, 120, 101, 101, 103, 230, 60, 230, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void reverse()
    {
      long[] items = this.items;
      int index1 = 0;
      int num1 = this.size - 1;
      for (int index2 = this.size / 2; index1 < index2; ++index1)
      {
        int index3 = num1 - index1;
        long num2 = items[index1];
        items[index1] = items[index3];
        items[index3] = num2;
      }
    }

    [LineNumberTable(new byte[] {160, 221, 103, 109, 103, 100, 102, 228, 60, 230, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void shuffle()
    {
      long[] items = this.items;
      for (int range = this.size - 1; range >= 0; range += -1)
      {
        int index = Mathf.random(range);
        long num = items[range];
        items[range] = items[index];
        items[index] = num;
      }
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void truncate(int newSize)
    {
      if (this.size <= newSize)
        return;
      this.size = newSize;
    }

    [LineNumberTable(new byte[] {160, 240, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual long random() => this.size == 0 ? 0L : this.items[Mathf.random(0, this.size - 1)];

    [LineNumberTable(new byte[] {160, 245, 108, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual long[] toArray()
    {
      long[] numArray = new long[this.size];
      ByteCodeHelper.arraycopy_primitive_8((Array) this.items, 0, (Array) numArray, 0, this.size);
      return numArray;
    }

    [LineNumberTable(new byte[] {160, 251, 111, 103, 98, 109, 49, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int hashCode()
    {
      if (!this.ordered)
        return base.hashCode();
      long[] items = this.items;
      int num = 1;
      int index = 0;
      for (int size = this.size; index < size; ++index)
        num = num * 31 + (int) (items[index] ^ (long) ((ulong) items[index] >> 32));
      return num;
    }

    [LineNumberTable(new byte[] {161, 4, 107, 106, 106, 103, 106, 103, 107, 103, 103, 102, 52, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool equals(object @object)
    {
      if (object.ReferenceEquals(@object, (object) this))
        return true;
      if (!this.ordered || !(@object is LongSeq))
        return false;
      LongSeq longSeq = (LongSeq) @object;
      if (!longSeq.ordered)
        return false;
      int size = this.size;
      if (size != longSeq.size)
        return false;
      long[] items1 = this.items;
      long[] items2 = longSeq.items;
      for (int index = 0; index < size; ++index)
      {
        if (this.items[index] != longSeq.items[index])
          return false;
      }
      return true;
    }

    [LineNumberTable(new byte[] {161, 19, 110, 103, 104, 105, 106, 107, 108, 10, 198, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toString()
    {
      if (this.size == 0)
        return "[]";
      long[] items = this.items;
      StringBuilder stringBuilder = new StringBuilder(32);
      stringBuilder.append('[');
      stringBuilder.append(items[0]);
      for (int index = 1; index < this.size; ++index)
      {
        stringBuilder.append(", ");
        stringBuilder.append(items[index]);
      }
      stringBuilder.append(']');
      return stringBuilder.toString();
    }

    [LineNumberTable(new byte[] {161, 33, 110, 103, 104, 106, 107, 104, 10, 198})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toString(string separator)
    {
      if (this.size == 0)
        return "";
      long[] items = this.items;
      StringBuilder stringBuilder = new StringBuilder(32);
      stringBuilder.append(items[0]);
      for (int index = 1; index < this.size; ++index)
      {
        stringBuilder.append(separator);
        stringBuilder.append(items[index]);
      }
      return stringBuilder.toString();
    }
  }
}
