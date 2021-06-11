// Decompiled with JetBrains decompiler
// Type: arc.struct.IntSeq
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
  public class IntSeq : Object
  {
    public int[] items;
    public int size;
    public bool ordered;

    [LineNumberTable(new byte[] {159, 169, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public IntSeq()
      : this(true, 16)
    {
    }

    [LineNumberTable(new byte[] {70, 103, 127, 11, 118})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void add(int value)
    {
      int[] numArray1 = this.items;
      if (this.size == numArray1.Length)
        numArray1 = this.resize(Math.max(8, ByteCodeHelper.f2i((float) this.size * 1.75f)));
      int[] numArray2 = numArray1;
      IntSeq intSeq1 = this;
      int size = intSeq1.size;
      IntSeq intSeq2 = intSeq1;
      int index = size;
      intSeq2.size = size + 1;
      int num = value;
      numArray2[index] = num;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void clear() => this.size = 0;

    [LineNumberTable(new byte[] {160, 196, 120})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int first()
    {
      if (this.size == 0)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalStateException("Array is empty.");
      }
      return this.items[0];
    }

    [LineNumberTable(new byte[] {125, 127, 36})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int get(int index)
    {
      if (index >= this.size)
      {
        string str = new StringBuilder().append("index can't be >= size: ").append(index).append(" >= ").append(this.size).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IndexOutOfBoundsException(str);
      }
      return this.items[index];
    }

    [LineNumberTable(new byte[] {159, 160, 102, 102, 39, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static IntSeq range(int min, int max)
    {
      IntSeq intSeq = new IntSeq();
      for (int index = min; index < max; ++index)
        intSeq.add(index);
      return intSeq;
    }

    [LineNumberTable(new byte[] {160, 136, 127, 36, 103, 100, 110, 104, 149, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int removeIndex(int index)
    {
      if (index >= this.size)
      {
        string str = new StringBuilder().append("index can't be >= size: ").append(index).append(" >= ").append(this.size).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IndexOutOfBoundsException(str);
      }
      int[] items = this.items;
      int num = items[index];
      --this.size;
      if (this.ordered)
        ByteCodeHelper.arraycopy_primitive_4((Array) items, index + 1, (Array) items, index, this.size - index);
      else
        items[index] = items[this.size];
      return num;
    }

    [LineNumberTable(new byte[] {160, 102, 105, 103, 100, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool contains(int value)
    {
      int num = this.size - 1;
      int[] items = this.items;
      while (num >= 0)
      {
        int[] numArray = items;
        int index = num;
        num += -1;
        if (numArray[index] == value)
          return true;
      }
      return false;
    }

    [LineNumberTable(new byte[] {0, 104, 108, 108, 113, 121})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public IntSeq(IntSeq array)
    {
      IntSeq intSeq = this;
      this.ordered = array.ordered;
      this.size = array.size;
      this.items = new int[this.size];
      ByteCodeHelper.arraycopy_primitive_4((Array) array.items, 0, (Array) this.items, 0, this.size);
    }

    [LineNumberTable(new byte[] {160, 124, 103, 109, 102, 104, 226, 61, 230, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool removeValue(int value)
    {
      int[] items = this.items;
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

    [LineNumberTable(new byte[] {62, 98, 107, 43, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int sum()
    {
      int num = 0;
      for (int index = 0; index < this.size; ++index)
        num += this.items[index];
      return num;
    }

    [LineNumberTable(300)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int pop()
    {
      int[] items = this.items;
      IntSeq intSeq1 = this;
      int num = intSeq1.size - 1;
      IntSeq intSeq2 = intSeq1;
      int index = num;
      intSeq2.size = num;
      return items[index];
    }

    [LineNumberTable(new byte[] {159, 174, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public IntSeq(int capacity)
      : this(true, capacity)
    {
    }

    [LineNumberTable(new byte[] {160, 252, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void sort() => Arrays.sort(this.items, 0, this.size);

    [LineNumberTable(new byte[] {161, 10, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void shuffle() => this.shuffle(Mathf.rand);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isEmpty() => this.size == 0;

    [LineNumberTable(new byte[] {160, 225, 100, 127, 6, 105, 120})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int[] ensureCapacity(int additionalCapacity)
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

    [LineNumberTable(new byte[] {161, 14, 103, 109, 106, 100, 102, 228, 60, 230, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void shuffle(Rand rand)
    {
      int[] items = this.items;
      for (int index1 = this.size - 1; index1 >= 0; index1 += -1)
      {
        int index2 = rand.nextInt(index1 + 1);
        int num = items[index1];
        items[index1] = items[index2];
        items[index2] = num;
      }
    }

    [LineNumberTable(new byte[] {160, 71, 127, 36, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void incr(int index, int value)
    {
      if (index >= this.size)
      {
        string str = new StringBuilder().append("index can't be >= size: ").append(index).append(" >= ").append(this.size).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IndexOutOfBoundsException(str);
      }
      int[] items = this.items;
      int index1 = index;
      int[] numArray = items;
      numArray[index1] = numArray[index1] + value;
    }

    [LineNumberTable(new byte[] {103, 115})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addAll(IntSeq array) => this.addAll(array.items, 0, array.size);

    [LineNumberTable(new byte[] {160, 66, 127, 36, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void set(int index, int value)
    {
      if (index >= this.size)
      {
        string str = new StringBuilder().append("index can't be >= size: ").append(index).append(" >= ").append(this.size).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IndexOutOfBoundsException(str);
      }
      this.items[index] = value;
    }

    [LineNumberTable(new byte[] {160, 81, 127, 36, 103, 127, 11, 104, 149, 107, 110, 100})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void insert(int index, int value)
    {
      if (index > this.size)
      {
        string str = new StringBuilder().append("index can't be > size: ").append(index).append(" > ").append(this.size).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IndexOutOfBoundsException(str);
      }
      int[] numArray = this.items;
      if (this.size == numArray.Length)
        numArray = this.resize(Math.max(8, ByteCodeHelper.f2i((float) this.size * 1.75f)));
      if (this.ordered)
        ByteCodeHelper.arraycopy_primitive_4((Array) numArray, index, (Array) numArray, index + 1, this.size - index);
      else
        numArray[this.size] = numArray[index];
      ++this.size;
      numArray[index] = value;
    }

    [LineNumberTable(new byte[] {159, 132, 66, 104, 103, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public IntSeq(bool ordered, int capacity)
    {
      int num = ordered ? 1 : 0;
      // ISSUE: explicit constructor call
      base.\u002Ector();
      IntSeq intSeq = this;
      this.ordered = num != 0;
      this.items = new int[capacity];
    }

    [LineNumberTable(new byte[] {159, 124, 66, 107, 104, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public IntSeq(bool ordered, int[] array, int startIndex, int count)
      : this(ordered, count)
    {
      IntSeq intSeq = this;
      this.size = count;
      ByteCodeHelper.arraycopy_primitive_4((Array) array, startIndex, (Array) this.items, 0, count);
    }

    [LineNumberTable(new byte[] {12, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public IntSeq(int[] array)
      : this(true, array, 0, array.Length)
    {
    }

    [LineNumberTable(new byte[] {160, 244, 103, 103, 118, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual int[] resize(int newSize)
    {
      int[] numArray = new int[newSize];
      ByteCodeHelper.arraycopy_primitive_4((Array) this.items, 0, (Array) numArray, 0, Math.min(this.size, numArray.Length));
      this.items = numArray;
      return numArray;
    }

    [LineNumberTable(new byte[] {117, 103, 105, 127, 1, 111, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addAll(int[] array, int offset, int length)
    {
      int[] numArray = this.items;
      int num = this.size + length;
      if (num > numArray.Length)
        numArray = this.resize(Math.max(8, ByteCodeHelper.f2i((float) num * 1.75f)));
      ByteCodeHelper.arraycopy_primitive_4((Array) array, offset, (Array) numArray, this.size, length);
      this.size += length;
    }

    [LineNumberTable(79)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static IntSeq with(params int[] array) => new IntSeq(array);

    [LineNumberTable(new byte[] {34, 98, 148, 112, 105, 99, 109, 50, 168, 101, 98, 227, 56, 233, 75})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int mode()
    {
      int num1 = 1;
      int num2 = this.size != 0 ? this.items[0] : 0;
      for (int index1 = 0; index1 < this.size - 1; ++index1)
      {
        int num3 = this.items[index1];
        int num4 = 0;
        for (int index2 = 1; index2 < this.size; ++index2)
        {
          if (num3 == this.items[index2])
            ++num4;
        }
        if (num4 > num1)
        {
          num2 = num3;
          num1 = num4;
        }
      }
      return num2;
    }

    [LineNumberTable(new byte[] {52, 98, 107, 107, 4, 230, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int count(int value)
    {
      int num = 0;
      for (int index = 0; index < this.size; ++index)
      {
        if (this.items[index] == value)
          ++num;
      }
      return num;
    }

    [LineNumberTable(new byte[] {76, 103, 127, 13, 105, 107, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void add(int value1, int value2)
    {
      int[] numArray = this.items;
      if (this.size + 1 >= numArray.Length)
        numArray = this.resize(Math.max(8, ByteCodeHelper.f2i((float) this.size * 1.75f)));
      numArray[this.size] = value1;
      numArray[this.size + 1] = value2;
      this.size += 2;
    }

    [LineNumberTable(new byte[] {84, 103, 127, 13, 105, 107, 107, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void add(int value1, int value2, int value3)
    {
      int[] numArray = this.items;
      if (this.size + 2 >= numArray.Length)
        numArray = this.resize(Math.max(8, ByteCodeHelper.f2i((float) this.size * 1.75f)));
      numArray[this.size] = value1;
      numArray[this.size + 1] = value2;
      numArray[this.size + 2] = value3;
      this.size += 3;
    }

    [LineNumberTable(new byte[] {93, 103, 127, 13, 105, 107, 107, 108, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void add(int value1, int value2, int value3, int value4)
    {
      int[] numArray = this.items;
      if (this.size + 3 >= numArray.Length)
        numArray = this.resize(Math.max(8, ByteCodeHelper.f2i((float) this.size * 1.8f)));
      numArray[this.size] = value1;
      numArray[this.size + 1] = value2;
      numArray[this.size + 2] = value3;
      numArray[this.size + 3] = value4;
      this.size += 4;
    }

    [LineNumberTable(new byte[] {107, 107, 127, 43, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addAll(IntSeq array, int offset, int length)
    {
      if (offset + length > array.size)
      {
        string str = new StringBuilder().append("offset + length must be <= size: ").append(offset).append(" + ").append(length).append(" <= ").append(array.size).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException(str);
      }
      this.addAll(array.items, offset, length);
    }

    [LineNumberTable(new byte[] {113, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addAll(params int[] array) => this.addAll(array, 0, array.Length);

    [LineNumberTable(new byte[] {160, 76, 127, 36, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void mul(int index, int value)
    {
      if (index >= this.size)
      {
        string str = new StringBuilder().append("index can't be >= size: ").append(index).append(" >= ").append(this.size).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IndexOutOfBoundsException(str);
      }
      int[] items = this.items;
      int index1 = index;
      int[] numArray = items;
      numArray[index1] = numArray[index1] * value;
    }

    [LineNumberTable(new byte[] {160, 93, 127, 36, 127, 36, 103, 100, 102, 100})]
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
      int[] items = this.items;
      int num = items[first];
      items[first] = items[second];
      items[second] = num;
    }

    [LineNumberTable(new byte[] {160, 110, 103, 109, 40, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int indexOf(int value)
    {
      int[] items = this.items;
      int index = 0;
      for (int size = this.size; index < size; ++index)
      {
        if (items[index] == value)
          return index;
      }
      return -1;
    }

    [LineNumberTable(new byte[] {160, 117, 103, 109, 40, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int lastIndexOf(int value)
    {
      int[] items = this.items;
      for (int index = this.size - 1; index >= 0; index += -1)
      {
        if (items[index] == value)
          return index;
      }
      return -1;
    }

    [LineNumberTable(new byte[] {160, 149, 127, 36, 127, 26, 103, 102, 104, 151, 105, 102, 42, 166, 110})]
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
      int[] items = this.items;
      int num1 = end - start + 1;
      if (this.ordered)
      {
        ByteCodeHelper.arraycopy_primitive_4((Array) items, start + num1, (Array) items, start, this.size - (start + num1));
      }
      else
      {
        int num2 = this.size - 1;
        for (int index = 0; index < num1; ++index)
          items[start + index] = items[num2 - index];
      }
      this.size -= num1;
    }

    [LineNumberTable(new byte[] {160, 168, 103, 98, 103, 111, 105, 104, 104, 105, 100, 226, 60, 8, 230, 74})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool removeAll(IntSeq array)
    {
      int size1 = this.size;
      int num1 = size1;
      int[] items = this.items;
      int index1 = 0;
      for (int size2 = array.size; index1 < size2; ++index1)
      {
        int num2 = array.get(index1);
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

    [LineNumberTable(305)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int peek() => this.items[this.size - 1];

    [LineNumberTable(new byte[] {160, 215, 124})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int[] shrink()
    {
      if (this.items.Length != this.size)
        this.resize(this.size);
      return this.items;
    }

    [LineNumberTable(new byte[] {160, 237, 127, 10, 120, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int[] setSize(int newSize)
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

    [LineNumberTable(new byte[] {161, 0, 103, 120, 101, 101, 103, 230, 60, 230, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void reverse()
    {
      int[] items = this.items;
      int index1 = 0;
      int num1 = this.size - 1;
      for (int index2 = this.size / 2; index1 < index2; ++index1)
      {
        int index3 = num1 - index1;
        int num2 = items[index1];
        items[index1] = items[index3];
        items[index3] = num2;
      }
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void truncate(int newSize)
    {
      if (this.size <= newSize)
        return;
      this.size = newSize;
    }

    [LineNumberTable(new byte[] {161, 33, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int random() => this.size == 0 ? 0 : this.items[Mathf.random(0, this.size - 1)];

    [LineNumberTable(new byte[] {161, 38, 108, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int[] toArray()
    {
      int[] numArray = new int[this.size];
      ByteCodeHelper.arraycopy_primitive_4((Array) this.items, 0, (Array) numArray, 0, this.size);
      return numArray;
    }

    [LineNumberTable(new byte[] {161, 44, 111, 103, 98, 109, 41, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int hashCode()
    {
      if (!this.ordered)
        return base.hashCode();
      int[] items = this.items;
      int num = 1;
      int index = 0;
      for (int size = this.size; index < size; ++index)
        num = num * 31 + items[index];
      return num;
    }

    [LineNumberTable(new byte[] {161, 53, 107, 106, 106, 103, 106, 103, 107, 103, 103, 102, 52, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool equals(object @object)
    {
      if (object.ReferenceEquals(@object, (object) this))
        return true;
      if (!this.ordered || !(@object is IntSeq))
        return false;
      IntSeq intSeq = (IntSeq) @object;
      if (!intSeq.ordered)
        return false;
      int size = this.size;
      if (size != intSeq.size)
        return false;
      int[] items1 = this.items;
      int[] items2 = intSeq.items;
      for (int index = 0; index < size; ++index)
      {
        if (this.items[index] != intSeq.items[index])
          return false;
      }
      return true;
    }

    [LineNumberTable(new byte[] {161, 68, 110, 103, 104, 105, 106, 107, 108, 10, 198, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toString()
    {
      if (this.size == 0)
        return "[]";
      int[] items = this.items;
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

    [LineNumberTable(new byte[] {161, 82, 110, 103, 104, 106, 107, 104, 10, 198})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toString(string separator)
    {
      if (this.size == 0)
        return "";
      int[] items = this.items;
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
