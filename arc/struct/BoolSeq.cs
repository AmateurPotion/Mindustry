// Decompiled with JetBrains decompiler
// Type: arc.struct.BoolSeq
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.math;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System;
using System.Runtime.CompilerServices;

namespace arc.@struct
{
  public class BoolSeq : Object
  {
    public bool[] items;
    public int size;
    public bool ordered;

    [LineNumberTable(new byte[] {159, 163, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public BoolSeq()
      : this(true, 16)
    {
    }

    [LineNumberTable(new byte[] {160, 139, 100, 127, 6, 105, 120})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool[] ensureCapacity(int additionalCapacity)
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

    [LineNumberTable(new byte[] {159, 108, 98, 127, 36, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void set(int index, bool value)
    {
      int num = value ? 1 : 0;
      if (index >= this.size)
      {
        string str = new StringBuilder().append("index can't be >= size: ").append(index).append(" >= ").append(this.size).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IndexOutOfBoundsException(str);
      }
      this.items[index] = num != 0;
    }

    [LineNumberTable(new byte[] {82, 127, 36})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool get(int index)
    {
      if (index >= this.size)
      {
        string str = new StringBuilder().append("index can't be >= size: ").append(index).append(" >= ").append(this.size).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IndexOutOfBoundsException(str);
      }
      return this.items[index];
    }

    [LineNumberTable(new byte[] {159, 134, 130, 104, 103, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public BoolSeq(bool ordered, int capacity)
    {
      int num = ordered ? 1 : 0;
      // ISSUE: explicit constructor call
      base.\u002Ector();
      BoolSeq boolSeq = this;
      this.ordered = num != 0;
      this.items = new bool[capacity];
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void clear() => this.size = 0;

    [LineNumberTable(new byte[] {159, 123, 98, 103, 127, 11, 118})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void add(bool value)
    {
      int num1 = value ? 1 : 0;
      bool[] flagArray1 = this.items;
      if (this.size == flagArray1.Length)
        flagArray1 = this.resize(Math.max(8, ByteCodeHelper.f2i((float) this.size * 1.75f)));
      bool[] flagArray2 = flagArray1;
      BoolSeq boolSeq1 = this;
      int size = boolSeq1.size;
      BoolSeq boolSeq2 = boolSeq1;
      int index = size;
      boolSeq2.size = size + 1;
      int num2 = num1;
      flagArray2[index] = num2 != 0;
    }

    [LineNumberTable(new byte[] {114, 127, 36, 103, 100, 110, 104, 149, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool removeIndex(int index)
    {
      if (index >= this.size)
      {
        string str = new StringBuilder().append("index can't be >= size: ").append(index).append(" >= ").append(this.size).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IndexOutOfBoundsException(str);
      }
      bool[] items = this.items;
      int num = items[index] ? 1 : 0;
      --this.size;
      if (this.ordered)
        ByteCodeHelper.arraycopy_primitive_1((Array) items, index + 1, (Array) items, index, this.size - index);
      else
        items[index] = items[this.size];
      return num != 0;
    }

    [LineNumberTable(new byte[] {159, 126, 130, 107, 104, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public BoolSeq(bool ordered, bool[] array, int startIndex, int count)
      : this(ordered, count)
    {
      BoolSeq boolSeq = this;
      this.size = count;
      ByteCodeHelper.arraycopy_primitive_1((Array) array, startIndex, (Array) this.items, 0, count);
    }

    [LineNumberTable(new byte[] {6, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public BoolSeq(bool[] array)
      : this(true, array, 0, array.Length)
    {
    }

    [LineNumberTable(new byte[] {160, 158, 103, 103, 118, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual bool[] resize(int newSize)
    {
      bool[] flagArray = new bool[newSize];
      ByteCodeHelper.arraycopy_primitive_1((Array) this.items, 0, (Array) flagArray, 0, Math.min(this.size, flagArray.Length));
      this.items = flagArray;
      return flagArray;
    }

    [LineNumberTable(new byte[] {74, 103, 105, 127, 1, 111, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addAll(bool[] array, int offset, int length)
    {
      bool[] flagArray = this.items;
      int num = this.size + length;
      if (num > flagArray.Length)
        flagArray = this.resize(Math.max(8, ByteCodeHelper.f2i((float) num * 1.75f)));
      ByteCodeHelper.arraycopy_primitive_1((Array) array, offset, (Array) flagArray, this.size, length);
      this.size += length;
    }

    [LineNumberTable(new byte[] {159, 168, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public BoolSeq(int capacity)
      : this(true, capacity)
    {
    }

    [LineNumberTable(new byte[] {159, 186, 104, 108, 108, 113, 121})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public BoolSeq(BoolSeq array)
    {
      BoolSeq boolSeq = this;
      this.ordered = array.ordered;
      this.size = array.size;
      this.items = new bool[this.size];
      ByteCodeHelper.arraycopy_primitive_1((Array) array.items, 0, (Array) this.items, 0, this.size);
    }

    [LineNumberTable(73)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static BoolSeq with(params bool[] array) => new BoolSeq(array);

    [LineNumberTable(new byte[] {159, 122, 164, 103, 127, 13, 105, 107, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void add(bool value1, bool value2)
    {
      int num1 = value1 ? 1 : 0;
      int num2 = value2 ? 1 : 0;
      bool[] flagArray = this.items;
      if (this.size + 1 >= flagArray.Length)
        flagArray = this.resize(Math.max(8, ByteCodeHelper.f2i((float) this.size * 1.75f)));
      flagArray[this.size] = num1 != 0;
      flagArray[this.size + 1] = num2 != 0;
      this.size += 2;
    }

    [LineNumberTable(new byte[] {159, 120, 166, 103, 127, 13, 105, 107, 107, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void add(bool value1, bool value2, bool value3)
    {
      int num1 = value1 ? 1 : 0;
      int num2 = value2 ? 1 : 0;
      int num3 = value3 ? 1 : 0;
      bool[] flagArray = this.items;
      if (this.size + 2 >= flagArray.Length)
        flagArray = this.resize(Math.max(8, ByteCodeHelper.f2i((float) this.size * 1.75f)));
      flagArray[this.size] = num1 != 0;
      flagArray[this.size + 1] = num2 != 0;
      flagArray[this.size + 2] = num3 != 0;
      this.size += 3;
    }

    [LineNumberTable(new byte[] {159, 117, 73, 104, 127, 15, 106, 108, 108, 108, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void add(bool value1, bool value2, bool value3, bool value4)
    {
      int num1 = value1 ? 1 : 0;
      int num2 = value2 ? 1 : 0;
      int num3 = value3 ? 1 : 0;
      int num4 = value4 ? 1 : 0;
      bool[] flagArray = this.items;
      if (this.size + 3 >= flagArray.Length)
        flagArray = this.resize(Math.max(8, ByteCodeHelper.f2i((float) this.size * 1.8f)));
      flagArray[this.size] = num1 != 0;
      flagArray[this.size + 1] = num2 != 0;
      flagArray[this.size + 2] = num3 != 0;
      flagArray[this.size + 3] = num4 != 0;
      this.size += 4;
    }

    [LineNumberTable(new byte[] {60, 115})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addAll(BoolSeq array) => this.addAll(array.items, 0, array.size);

    [LineNumberTable(new byte[] {64, 107, 127, 43, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addAll(BoolSeq array, int offset, int length)
    {
      if (offset + length > array.size)
      {
        string str = new StringBuilder().append("offset + length must be <= size: ").append(offset).append(" + ").append(length).append(" <= ").append(array.size).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException(str);
      }
      this.addAll(array.items, offset, length);
    }

    [LineNumberTable(new byte[] {70, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addAll(params bool[] array) => this.addAll(array, 0, array.Length);

    [LineNumberTable(new byte[] {159, 107, 130, 127, 36, 103, 127, 11, 104, 149, 107, 110, 100})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void insert(int index, bool value)
    {
      int num = value ? 1 : 0;
      if (index > this.size)
      {
        string str = new StringBuilder().append("index can't be > size: ").append(index).append(" > ").append(this.size).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IndexOutOfBoundsException(str);
      }
      bool[] flagArray = this.items;
      if (this.size == flagArray.Length)
        flagArray = this.resize(Math.max(8, ByteCodeHelper.f2i((float) this.size * 1.75f)));
      if (this.ordered)
        ByteCodeHelper.arraycopy_primitive_1((Array) flagArray, index, (Array) flagArray, index + 1, this.size - index);
      else
        flagArray[this.size] = flagArray[index];
      ++this.size;
      flagArray[index] = num != 0;
    }

    [LineNumberTable(new byte[] {104, 127, 36, 127, 36, 103, 100, 102, 100})]
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
      bool[] items = this.items;
      int num = items[first] ? 1 : 0;
      items[first] = items[second];
      items[second] = num != 0;
    }

    [LineNumberTable(new byte[] {127, 127, 36, 127, 26, 103, 102, 104, 151, 105, 102, 42, 166, 110})]
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
      bool[] items = this.items;
      int num1 = end - start + 1;
      if (this.ordered)
      {
        ByteCodeHelper.arraycopy_primitive_1((Array) items, start + num1, (Array) items, start, this.size - (start + num1));
      }
      else
      {
        int num2 = this.size - 1;
        for (int index = 0; index < num1; ++index)
          items[start + index] = items[num2 - index];
      }
      this.size -= num1;
    }

    [LineNumberTable(new byte[] {160, 82, 103, 98, 103, 111, 105, 104, 104, 105, 100, 226, 60, 8, 230, 74})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool removeAll(BoolSeq array)
    {
      int size1 = this.size;
      int num1 = size1;
      bool[] items = this.items;
      int index1 = 0;
      for (int size2 = array.size; index1 < size2; ++index1)
      {
        int num2 = array.get(index1) ? 1 : 0;
        for (int index2 = 0; index2 < size1; ++index2)
        {
          if (num2 == (items[index2] ? 1 : 0))
          {
            this.removeIndex(index2);
            size1 += -1;
            break;
          }
        }
      }
      return size1 != num1;
    }

    [LineNumberTable(214)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool pop()
    {
      bool[] items = this.items;
      BoolSeq boolSeq1 = this;
      int num = boolSeq1.size - 1;
      BoolSeq boolSeq2 = boolSeq1;
      int index = num;
      boolSeq2.size = num;
      return items[index];
    }

    [LineNumberTable(219)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool peek() => this.items[this.size - 1];

    [LineNumberTable(new byte[] {160, 110, 120})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool first()
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

    [LineNumberTable(new byte[] {160, 129, 124})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool[] shrink()
    {
      if (this.items.Length != this.size)
        this.resize(this.size);
      return this.items;
    }

    [LineNumberTable(new byte[] {160, 151, 127, 10, 120, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool[] setSize(int newSize)
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

    [LineNumberTable(new byte[] {160, 166, 103, 120, 101, 101, 103, 230, 60, 230, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void reverse()
    {
      bool[] items = this.items;
      int index1 = 0;
      int num1 = this.size - 1;
      for (int index2 = this.size / 2; index1 < index2; ++index1)
      {
        int index3 = num1 - index1;
        int num2 = items[index1] ? 1 : 0;
        items[index1] = items[index3];
        items[index3] = num2 != 0;
      }
    }

    [LineNumberTable(new byte[] {160, 176, 103, 109, 103, 100, 102, 228, 60, 230, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void shuffle()
    {
      bool[] items = this.items;
      for (int range = this.size - 1; range >= 0; range += -1)
      {
        int index = Mathf.random(range);
        int num = items[range] ? 1 : 0;
        items[range] = items[index];
        items[index] = num != 0;
      }
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void truncate(int newSize)
    {
      if (this.size <= newSize)
        return;
      this.size = newSize;
    }

    [LineNumberTable(new byte[] {160, 195, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool random() => this.size != 0 && this.items[Mathf.random(0, this.size - 1)];

    [LineNumberTable(new byte[] {160, 200, 108, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool[] toArray()
    {
      bool[] flagArray = new bool[this.size];
      ByteCodeHelper.arraycopy_primitive_1((Array) this.items, 0, (Array) flagArray, 0, this.size);
      return flagArray;
    }

    [LineNumberTable(new byte[] {160, 206, 111, 103, 98, 109, 55, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int hashCode()
    {
      if (!this.ordered)
        return base.hashCode();
      bool[] items = this.items;
      int num = 1;
      int index = 0;
      for (int size = this.size; index < size; ++index)
        num = num * 31 + (!items[index] ? 1237 : 1231);
      return num;
    }

    [LineNumberTable(new byte[] {160, 215, 107, 106, 106, 103, 106, 103, 107, 103, 103, 104, 44, 136})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool equals(object @object)
    {
      if (object.ReferenceEquals(@object, (object) this))
        return true;
      if (!this.ordered || !(@object is BoolSeq))
        return false;
      BoolSeq boolSeq = (BoolSeq) @object;
      if (!boolSeq.ordered)
        return false;
      int size = this.size;
      if (size != boolSeq.size)
        return false;
      bool[] items1 = this.items;
      bool[] items2 = boolSeq.items;
      for (int index = 0; index < size; ++index)
      {
        if (items1[index] != items2[index])
          return false;
      }
      return true;
    }

    [LineNumberTable(new byte[] {160, 230, 110, 103, 104, 105, 106, 107, 108, 10, 198, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toString()
    {
      if (this.size == 0)
        return "[]";
      bool[] items = this.items;
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

    [LineNumberTable(new byte[] {160, 244, 110, 103, 104, 106, 107, 104, 10, 198})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toString(string separator)
    {
      if (this.size == 0)
        return "";
      bool[] items = this.items;
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
