// Decompiled with JetBrains decompiler
// Type: arc.struct.ShortSeq
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
  public class ShortSeq : Object
  {
    public short[] items;
    public int size;
    public bool ordered;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void clear() => this.size = 0;

    [LineNumberTable(new byte[] {160, 214, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void sort() => Arrays.sort(this.items, 0, this.size);

    [LineNumberTable(new byte[] {87, 127, 36})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual short get(int index)
    {
      if (index >= this.size)
      {
        string str = new StringBuilder().append("index can't be >= size: ").append(index).append(" >= ").append(this.size).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IndexOutOfBoundsException(str);
      }
      return this.items[index];
    }

    [LineNumberTable(new byte[] {159, 122, 130, 103, 127, 11, 118})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void add(short value)
    {
      int num1 = (int) value;
      short[] numArray1 = this.items;
      if (this.size == numArray1.Length)
        numArray1 = this.resize(Math.max(8, ByteCodeHelper.f2i((float) this.size * 1.75f)));
      short[] numArray2 = numArray1;
      ShortSeq shortSeq1 = this;
      int size = shortSeq1.size;
      ShortSeq shortSeq2 = shortSeq1;
      int index = size;
      shortSeq2.size = size + 1;
      int num2 = num1;
      numArray2[index] = (short) num2;
    }

    [LineNumberTable(new byte[] {159, 161, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ShortSeq()
      : this(true, 16)
    {
    }

    [LineNumberTable(new byte[] {159, 134, 66, 104, 103, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ShortSeq(bool ordered, int capacity)
    {
      int num = ordered ? 1 : 0;
      // ISSUE: explicit constructor call
      base.\u002Ector();
      ShortSeq shortSeq = this;
      this.ordered = num != 0;
      this.items = new short[capacity];
    }

    [LineNumberTable(new byte[] {160, 187, 100, 127, 6, 105, 120})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual short[] ensureCapacity(int additionalCapacity)
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

    [LineNumberTable(new byte[] {26, 103, 127, 11, 119})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void add(int value)
    {
      short[] numArray1 = this.items;
      if (this.size == numArray1.Length)
        numArray1 = this.resize(Math.max(8, ByteCodeHelper.f2i((float) this.size * 1.75f)));
      short[] numArray2 = numArray1;
      ShortSeq shortSeq1 = this;
      int size = shortSeq1.size;
      ShortSeq shortSeq2 = shortSeq1;
      int index = size;
      shortSeq2.size = size + 1;
      int num = (int) (short) value;
      numArray2[index] = (short) num;
    }

    [LineNumberTable(new byte[] {160, 98, 127, 36, 103, 100, 110, 104, 149, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual short removeIndex(int index)
    {
      if (index >= this.size)
      {
        string str = new StringBuilder().append("index can't be >= size: ").append(index).append(" >= ").append(this.size).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IndexOutOfBoundsException(str);
      }
      short[] items = this.items;
      int num = (int) items[index];
      --this.size;
      if (this.ordered)
        ByteCodeHelper.arraycopy_primitive_2((Array) items, index + 1, (Array) items, index, this.size - index);
      else
        items[index] = items[this.size];
      return (short) num;
    }

    [LineNumberTable(new byte[] {159, 126, 66, 107, 104, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ShortSeq(bool ordered, short[] array, int startIndex, int count)
      : this(ordered, count)
    {
      ShortSeq shortSeq = this;
      this.size = count;
      ByteCodeHelper.arraycopy_primitive_2((Array) array, startIndex, (Array) this.items, 0, count);
    }

    [LineNumberTable(new byte[] {4, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ShortSeq(short[] array)
      : this(true, array, 0, array.Length)
    {
    }

    [LineNumberTable(new byte[] {160, 206, 103, 103, 118, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual short[] resize(int newSize)
    {
      short[] numArray = new short[newSize];
      ByteCodeHelper.arraycopy_primitive_2((Array) this.items, 0, (Array) numArray, 0, Math.min(this.size, numArray.Length));
      this.items = numArray;
      return numArray;
    }

    [LineNumberTable(new byte[] {79, 103, 105, 127, 1, 111, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addAll(short[] array, int offset, int length)
    {
      short[] numArray = this.items;
      int num = this.size + length;
      if (num > numArray.Length)
        numArray = this.resize(Math.max(8, ByteCodeHelper.f2i((float) num * 1.75f)));
      ByteCodeHelper.arraycopy_primitive_2((Array) array, offset, (Array) numArray, this.size, length);
      this.size += length;
    }

    [LineNumberTable(new byte[] {159, 166, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ShortSeq(int capacity)
      : this(true, capacity)
    {
    }

    [LineNumberTable(new byte[] {159, 184, 104, 108, 108, 113, 121})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ShortSeq(ShortSeq array)
    {
      ShortSeq shortSeq = this;
      this.ordered = array.ordered;
      this.size = array.size;
      this.items = new short[this.size];
      ByteCodeHelper.arraycopy_primitive_2((Array) array.items, 0, (Array) this.items, 0, this.size);
    }

    [LineNumberTable(71)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static ShortSeq with(params short[] array) => new ShortSeq(array);

    [LineNumberTable(new byte[] {159, 120, 68, 103, 127, 13, 105, 107, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void add(short value1, short value2)
    {
      int num1 = (int) value1;
      int num2 = (int) value2;
      short[] numArray = this.items;
      if (this.size + 1 >= numArray.Length)
        numArray = this.resize(Math.max(8, ByteCodeHelper.f2i((float) this.size * 1.75f)));
      numArray[this.size] = (short) num1;
      numArray[this.size + 1] = (short) num2;
      this.size += 2;
    }

    [LineNumberTable(new byte[] {159, 118, 70, 103, 127, 13, 105, 107, 107, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void add(short value1, short value2, short value3)
    {
      int num1 = (int) value1;
      int num2 = (int) value2;
      int num3 = (int) value3;
      short[] numArray = this.items;
      if (this.size + 2 >= numArray.Length)
        numArray = this.resize(Math.max(8, ByteCodeHelper.f2i((float) this.size * 1.75f)));
      numArray[this.size] = (short) num1;
      numArray[this.size + 1] = (short) num2;
      numArray[this.size + 2] = (short) num3;
      this.size += 3;
    }

    [LineNumberTable(new byte[] {159, 116, 105, 104, 127, 15, 106, 108, 108, 108, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void add(short value1, short value2, short value3, short value4)
    {
      int num1 = (int) value1;
      int num2 = (int) value2;
      int num3 = (int) value3;
      int num4 = (int) value4;
      short[] numArray = this.items;
      if (this.size + 3 >= numArray.Length)
        numArray = this.resize(Math.max(8, ByteCodeHelper.f2i((float) this.size * 1.8f)));
      numArray[this.size] = (short) num1;
      numArray[this.size + 1] = (short) num2;
      numArray[this.size + 2] = (short) num3;
      numArray[this.size + 3] = (short) num4;
      this.size += 4;
    }

    [LineNumberTable(new byte[] {65, 115})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addAll(ShortSeq array) => this.addAll(array.items, 0, array.size);

    [LineNumberTable(new byte[] {69, 107, 127, 43, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addAll(ShortSeq array, int offset, int length)
    {
      if (offset + length > array.size)
      {
        string str = new StringBuilder().append("offset + length must be <= size: ").append(offset).append(" + ").append(length).append(" <= ").append(array.size).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException(str);
      }
      this.addAll(array.items, offset, length);
    }

    [LineNumberTable(new byte[] {75, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addAll(params short[] array) => this.addAll(array, 0, array.Length);

    [LineNumberTable(new byte[] {159, 107, 130, 127, 36, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void set(int index, short value)
    {
      int num = (int) value;
      if (index >= this.size)
      {
        string str = new StringBuilder().append("index can't be >= size: ").append(index).append(" >= ").append(this.size).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IndexOutOfBoundsException(str);
      }
      this.items[index] = (short) num;
    }

    [LineNumberTable(new byte[] {159, 106, 162, 127, 36, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void incr(int index, short value)
    {
      int num = (int) value;
      if (index >= this.size)
      {
        string str = new StringBuilder().append("index can't be >= size: ").append(index).append(" >= ").append(this.size).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IndexOutOfBoundsException(str);
      }
      short[] items = this.items;
      int index1 = index;
      short[] numArray = items;
      numArray[index1] = (short) ((int) numArray[index1] + num);
    }

    [LineNumberTable(new byte[] {159, 104, 66, 127, 36, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void mul(int index, short value)
    {
      int num = (int) value;
      if (index >= this.size)
      {
        string str = new StringBuilder().append("index can't be >= size: ").append(index).append(" >= ").append(this.size).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IndexOutOfBoundsException(str);
      }
      short[] items = this.items;
      int index1 = index;
      short[] numArray = items;
      numArray[index1] = (short) ((int) numArray[index1] * num);
    }

    [LineNumberTable(new byte[] {159, 103, 98, 127, 36, 103, 127, 11, 104, 149, 107, 110, 100})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void insert(int index, short value)
    {
      int num = (int) value;
      if (index > this.size)
      {
        string str = new StringBuilder().append("index can't be > size: ").append(index).append(" > ").append(this.size).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IndexOutOfBoundsException(str);
      }
      short[] numArray = this.items;
      if (this.size == numArray.Length)
        numArray = this.resize(Math.max(8, ByteCodeHelper.f2i((float) this.size * 1.75f)));
      if (this.ordered)
        ByteCodeHelper.arraycopy_primitive_2((Array) numArray, index, (Array) numArray, index + 1, this.size - index);
      else
        numArray[this.size] = numArray[index];
      ++this.size;
      numArray[index] = (short) num;
    }

    [LineNumberTable(new byte[] {119, 127, 36, 127, 36, 103, 100, 102, 100})]
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
      short[] items = this.items;
      int num = (int) items[first];
      items[first] = items[second];
      items[second] = (short) num;
    }

    [LineNumberTable(new byte[] {159, 98, 130, 105, 103, 100, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool contains(short value)
    {
      int num1 = (int) value;
      int num2 = this.size - 1;
      short[] items = this.items;
      while (num2 >= 0)
      {
        short[] numArray = items;
        int index = num2;
        num2 += -1;
        if ((int) numArray[index] == num1)
          return true;
      }
      return false;
    }

    [LineNumberTable(new byte[] {159, 96, 130, 103, 109, 40, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int indexOf(short value)
    {
      int num = (int) value;
      short[] items = this.items;
      int index = 0;
      for (int size = this.size; index < size; ++index)
      {
        if ((int) items[index] == num)
          return index;
      }
      return -1;
    }

    [LineNumberTable(new byte[] {159, 94, 98, 103, 109, 40, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int lastIndexOf(char value)
    {
      int num = (int) value;
      short[] items = this.items;
      for (int index = this.size - 1; index >= 0; index += -1)
      {
        if ((int) items[index] == num)
          return index;
      }
      return -1;
    }

    [LineNumberTable(new byte[] {159, 92, 66, 103, 109, 102, 104, 226, 61, 230, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool removeValue(short value)
    {
      int num1 = (int) value;
      short[] items = this.items;
      int index = 0;
      for (int size = this.size; index < size; ++index)
      {
        if ((int) items[index] == num1)
        {
          int num2 = (int) this.removeIndex(index);
          return true;
        }
      }
      return false;
    }

    [LineNumberTable(new byte[] {160, 111, 127, 36, 127, 26, 103, 102, 104, 151, 105, 102, 42, 166, 110})]
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
      short[] items = this.items;
      int num1 = end - start + 1;
      if (this.ordered)
      {
        ByteCodeHelper.arraycopy_primitive_2((Array) items, start + num1, (Array) items, start, this.size - (start + num1));
      }
      else
      {
        int num2 = this.size - 1;
        for (int index = 0; index < num1; ++index)
          items[start + index] = items[num2 - index];
      }
      this.size -= num1;
    }

    [LineNumberTable(new byte[] {160, 130, 103, 98, 103, 111, 105, 104, 104, 105, 100, 226, 60, 8, 230, 74})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool removeAll(ShortSeq array)
    {
      int size1 = this.size;
      int num1 = size1;
      short[] items = this.items;
      int index1 = 0;
      for (int size2 = array.size; index1 < size2; ++index1)
      {
        int num2 = (int) array.get(index1);
        for (int index2 = 0; index2 < size1; ++index2)
        {
          if (num2 == (int) items[index2])
          {
            int num3 = (int) this.removeIndex(index2);
            size1 += -1;
            break;
          }
        }
      }
      return size1 != num1;
    }

    [LineNumberTable(262)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual short pop()
    {
      short[] items = this.items;
      ShortSeq shortSeq1 = this;
      int num = shortSeq1.size - 1;
      ShortSeq shortSeq2 = shortSeq1;
      int index = num;
      shortSeq2.size = num;
      return items[index];
    }

    [LineNumberTable(267)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual short peek() => this.items[this.size - 1];

    [LineNumberTable(new byte[] {160, 158, 120})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual short first()
    {
      if (this.size == 0)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalStateException("Array is empty.");
      }
      return this.items[0];
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isEmpty() => this.size == 0;

    [LineNumberTable(new byte[] {160, 177, 124})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual short[] shrink()
    {
      if (this.items.Length != this.size)
        this.resize(this.size);
      return this.items;
    }

    [LineNumberTable(new byte[] {160, 199, 127, 10, 120, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual short[] setSize(int newSize)
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

    [LineNumberTable(new byte[] {160, 218, 103, 120, 101, 101, 103, 230, 60, 230, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void reverse()
    {
      short[] items = this.items;
      int index1 = 0;
      int num1 = this.size - 1;
      for (int index2 = this.size / 2; index1 < index2; ++index1)
      {
        int index3 = num1 - index1;
        int num2 = (int) items[index1];
        items[index1] = items[index3];
        items[index3] = (short) num2;
      }
    }

    [LineNumberTable(new byte[] {160, 228, 103, 109, 103, 100, 102, 228, 60, 230, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void shuffle()
    {
      short[] items = this.items;
      for (int range = this.size - 1; range >= 0; range += -1)
      {
        int index = Mathf.random(range);
        int num = (int) items[range];
        items[range] = items[index];
        items[index] = (short) num;
      }
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void truncate(int newSize)
    {
      if (this.size <= newSize)
        return;
      this.size = newSize;
    }

    [LineNumberTable(new byte[] {160, 247, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual short random() => this.size == 0 ? (short) 0 : this.items[Mathf.random(0, this.size - 1)];

    [LineNumberTable(new byte[] {160, 252, 108, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual short[] toArray()
    {
      short[] numArray = new short[this.size];
      ByteCodeHelper.arraycopy_primitive_2((Array) this.items, 0, (Array) numArray, 0, this.size);
      return numArray;
    }

    [LineNumberTable(new byte[] {161, 2, 111, 103, 98, 109, 41, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int hashCode()
    {
      if (!this.ordered)
        return base.hashCode();
      short[] items = this.items;
      int num = 1;
      int index = 0;
      for (int size = this.size; index < size; ++index)
        num = num * 31 + (int) items[index];
      return num;
    }

    [LineNumberTable(new byte[] {161, 11, 107, 106, 106, 103, 106, 103, 107, 103, 103, 102, 52, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool equals(object @object)
    {
      if (object.ReferenceEquals(@object, (object) this))
        return true;
      if (!this.ordered || !(@object is ShortSeq))
        return false;
      ShortSeq shortSeq = (ShortSeq) @object;
      if (!shortSeq.ordered)
        return false;
      int size = this.size;
      if (size != shortSeq.size)
        return false;
      short[] items1 = this.items;
      short[] items2 = shortSeq.items;
      for (int index = 0; index < size; ++index)
      {
        if ((int) this.items[index] != (int) shortSeq.items[index])
          return false;
      }
      return true;
    }

    [LineNumberTable(new byte[] {161, 26, 110, 103, 104, 105, 106, 107, 108, 10, 198, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toString()
    {
      if (this.size == 0)
        return "[]";
      short[] items = this.items;
      StringBuilder stringBuilder = new StringBuilder(32);
      stringBuilder.append('[');
      stringBuilder.append((int) items[0]);
      for (int index = 1; index < this.size; ++index)
      {
        stringBuilder.append(", ");
        stringBuilder.append((int) items[index]);
      }
      stringBuilder.append(']');
      return stringBuilder.toString();
    }

    [LineNumberTable(new byte[] {161, 40, 110, 103, 104, 106, 107, 104, 10, 198})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toString(string separator)
    {
      if (this.size == 0)
        return "";
      short[] items = this.items;
      StringBuilder stringBuilder = new StringBuilder(32);
      stringBuilder.append((int) items[0]);
      for (int index = 1; index < this.size; ++index)
      {
        stringBuilder.append(separator);
        stringBuilder.append((int) items[index]);
      }
      return stringBuilder.toString();
    }
  }
}
