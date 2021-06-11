// Decompiled with JetBrains decompiler
// Type: arc.struct.FloatSeq
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.math;
using arc.math.geom;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.util;
using System;
using System.Runtime.CompilerServices;

namespace arc.@struct
{
  public class FloatSeq : Object
  {
    public float[] items;
    public int size;
    public bool ordered;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void clear() => this.size = 0;

    [LineNumberTable(new byte[] {41, 103, 127, 13, 106, 108, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void add(float value1, float value2)
    {
      float[] numArray = this.items;
      if (this.size + 1 >= numArray.Length)
        numArray = this.resize(Math.max(8, ByteCodeHelper.f2i((float) this.size * 1.75f)));
      numArray[this.size] = value1;
      numArray[this.size + 1] = value2;
      this.size += 2;
    }

    [LineNumberTable(new byte[] {90, 127, 36})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float get(int index)
    {
      if (index >= this.size)
      {
        string str = new StringBuilder().append("index can't be >= size: ").append(index).append(" >= ").append(this.size).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IndexOutOfBoundsException(str);
      }
      return this.items[index];
    }

    [LineNumberTable(new byte[] {159, 162, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public FloatSeq()
      : this(true, 16)
    {
    }

    [LineNumberTable(new byte[] {35, 103, 127, 11, 119})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void add(float value)
    {
      float[] numArray1 = this.items;
      if (this.size == numArray1.Length)
        numArray1 = this.resize(Math.max(8, ByteCodeHelper.f2i((float) this.size * 1.75f)));
      float[] numArray2 = numArray1;
      FloatSeq floatSeq1 = this;
      int size = floatSeq1.size;
      FloatSeq floatSeq2 = floatSeq1;
      int index = size;
      floatSeq2.size = size + 1;
      double num = (double) value;
      numArray2[index] = (float) num;
    }

    [LineNumberTable(new byte[] {95, 127, 36, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void set(int index, float value)
    {
      if (index >= this.size)
      {
        string str = new StringBuilder().append("index can't be >= size: ").append(index).append(" >= ").append(this.size).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IndexOutOfBoundsException(str);
      }
      this.items[index] = value;
    }

    [LineNumberTable(new byte[] {160, 198, 100, 127, 6, 105, 120})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float[] ensureCapacity(int additionalCapacity)
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

    [LineNumberTable(new byte[] {160, 114, 127, 36, 127, 26, 103, 102, 104, 151, 105, 102, 42, 166, 110})]
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
      float[] items = this.items;
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

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void truncate(int newSize)
    {
      if (this.size <= newSize)
        return;
      this.size = newSize;
    }

    [LineNumberTable(new byte[] {72, 107, 127, 43, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addAll(FloatSeq array, int offset, int length)
    {
      if (offset + length > array.size)
      {
        string str = new StringBuilder().append("offset + length must be <= size: ").append(offset).append(" + ").append(length).append(" <= ").append(array.size).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException(str);
      }
      this.addAll(array.items, offset, length);
    }

    [LineNumberTable(new byte[] {68, 115})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addAll(FloatSeq array) => this.addAll(array.items, 0, array.size);

    [LineNumberTable(270)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float peek() => this.items[this.size - 1];

    [LineNumberTable(new byte[] {58, 103, 127, 13, 106, 108, 108, 109, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void add(float value1, float value2, float value3, float value4)
    {
      float[] numArray = this.items;
      if (this.size + 3 >= numArray.Length)
        numArray = this.resize(Math.max(8, ByteCodeHelper.f2i((float) this.size * 1.8f)));
      numArray[this.size] = value1;
      numArray[this.size + 1] = value2;
      numArray[this.size + 2] = value3;
      numArray[this.size + 3] = value4;
      this.size += 4;
    }

    [LineNumberTable(new byte[] {159, 167, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public FloatSeq(int capacity)
      : this(true, capacity)
    {
    }

    [LineNumberTable(new byte[] {78, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addAll(params float[] array) => this.addAll(array, 0, array.Length);

    [LineNumberTable(new byte[] {161, 7, 108, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float[] toArray()
    {
      float[] numArray = new float[this.size];
      ByteCodeHelper.arraycopy_primitive_4((Array) this.items, 0, (Array) numArray, 0, this.size);
      return numArray;
    }

    [LineNumberTable(new byte[] {160, 161, 120})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float first()
    {
      if (this.size == 0)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalStateException("Array is empty.");
      }
      return this.items[0];
    }

    [LineNumberTable(new byte[] {159, 134, 98, 104, 103, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public FloatSeq(bool ordered, int capacity)
    {
      int num = ordered ? 1 : 0;
      // ISSUE: explicit constructor call
      base.\u002Ector();
      FloatSeq floatSeq = this;
      this.ordered = num != 0;
      this.items = new float[capacity];
    }

    [LineNumberTable(new byte[] {159, 126, 98, 107, 104, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public FloatSeq(bool ordered, float[] array, int startIndex, int count)
      : this(ordered, count)
    {
      FloatSeq floatSeq = this;
      this.size = count;
      ByteCodeHelper.arraycopy_primitive_4((Array) array, startIndex, (Array) this.items, 0, count);
    }

    [LineNumberTable(new byte[] {5, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public FloatSeq(float[] array)
      : this(true, array, 0, array.Length)
    {
    }

    [LineNumberTable(new byte[] {160, 217, 103, 103, 118, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual float[] resize(int newSize)
    {
      float[] numArray = new float[newSize];
      ByteCodeHelper.arraycopy_primitive_4((Array) this.items, 0, (Array) numArray, 0, Math.min(this.size, numArray.Length));
      this.items = numArray;
      return numArray;
    }

    [LineNumberTable(new byte[] {82, 103, 105, 127, 1, 111, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addAll(float[] array, int offset, int length)
    {
      float[] numArray = this.items;
      int num = this.size + length;
      if (num > numArray.Length)
        numArray = this.resize(Math.max(8, ByteCodeHelper.f2i((float) num * 1.75f)));
      ByteCodeHelper.arraycopy_primitive_4((Array) array, offset, (Array) numArray, this.size, length);
      this.size += length;
    }

    [LineNumberTable(new byte[] {160, 101, 127, 36, 103, 100, 110, 104, 149, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float removeIndex(int index)
    {
      if (index >= this.size)
      {
        string str = new StringBuilder().append("index can't be >= size: ").append(index).append(" >= ").append(this.size).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IndexOutOfBoundsException(str);
      }
      float[] items = this.items;
      float num = items[index];
      --this.size;
      if (this.ordered)
        ByteCodeHelper.arraycopy_primitive_4((Array) items, index + 1, (Array) items, index, this.size - index);
      else
        items[index] = items[this.size];
      return num;
    }

    [LineNumberTable(new byte[] {159, 185, 104, 108, 108, 113, 121})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public FloatSeq(FloatSeq array)
    {
      FloatSeq floatSeq = this;
      this.ordered = array.ordered;
      this.size = array.size;
      this.items = new float[this.size];
      ByteCodeHelper.arraycopy_primitive_4((Array) array.items, 0, (Array) this.items, 0, this.size);
    }

    [LineNumberTable(72)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static FloatSeq with(params float[] array) => new FloatSeq(array);

    [Signature("()Larc/struct/Seq<Larc/math/geom/Vec2;>;")]
    [LineNumberTable(new byte[] {27, 110, 107, 63, 3, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Seq toVec2Array()
    {
      Seq seq1 = new Seq(this.size / 2);
      for (int index = 0; index < this.size; index += 2)
      {
        Seq seq2 = seq1;
        Vec2.__\u003Cclinit\u003E();
        Vec2 vec2 = new Vec2(this.items[index], this.items[index + 1]);
        seq2.add((object) vec2);
      }
      return seq1;
    }

    [LineNumberTable(new byte[] {49, 103, 127, 13, 106, 108, 108, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void add(float value1, float value2, float value3)
    {
      float[] numArray = this.items;
      if (this.size + 2 >= numArray.Length)
        numArray = this.resize(Math.max(8, ByteCodeHelper.f2i((float) this.size * 1.75f)));
      numArray[this.size] = value1;
      numArray[this.size + 1] = value2;
      numArray[this.size + 2] = value3;
      this.size += 3;
    }

    [LineNumberTable(new byte[] {100, 127, 36, 115})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void incr(int index, float value)
    {
      if (index >= this.size)
      {
        string str = new StringBuilder().append("index can't be >= size: ").append(index).append(" >= ").append(this.size).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IndexOutOfBoundsException(str);
      }
      float[] items = this.items;
      int index1 = index;
      float[] numArray = items;
      numArray[index1] = numArray[index1] + value;
    }

    [LineNumberTable(new byte[] {105, 127, 36, 115})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void mul(int index, float value)
    {
      if (index >= this.size)
      {
        string str = new StringBuilder().append("index can't be >= size: ").append(index).append(" >= ").append(this.size).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IndexOutOfBoundsException(str);
      }
      float[] items = this.items;
      int index1 = index;
      float[] numArray = items;
      numArray[index1] = numArray[index1] * value;
    }

    [LineNumberTable(new byte[] {110, 127, 36, 103, 127, 11, 104, 149, 107, 110, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void insert(int index, float value)
    {
      if (index > this.size)
      {
        string str = new StringBuilder().append("index can't be > size: ").append(index).append(" > ").append(this.size).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IndexOutOfBoundsException(str);
      }
      float[] numArray = this.items;
      if (this.size == numArray.Length)
        numArray = this.resize(Math.max(8, ByteCodeHelper.f2i((float) this.size * 1.75f)));
      if (this.ordered)
        ByteCodeHelper.arraycopy_primitive_4((Array) numArray, index, (Array) numArray, index + 1, this.size - index);
      else
        numArray[this.size] = numArray[index];
      ++this.size;
      numArray[index] = value;
    }

    [LineNumberTable(new byte[] {122, 127, 36, 127, 36, 103, 100, 102, 100})]
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
      float[] items = this.items;
      float num = items[first];
      items[first] = items[second];
      items[second] = num;
    }

    [LineNumberTable(new byte[] {160, 67, 105, 103, 100, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool contains(float value)
    {
      int num = this.size - 1;
      float[] items = this.items;
      while (num >= 0)
      {
        float[] numArray = items;
        int index = num;
        num += -1;
        if ((double) numArray[index] == (double) value)
          return true;
      }
      return false;
    }

    [LineNumberTable(new byte[] {160, 75, 103, 109, 41, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int indexOf(float value)
    {
      float[] items = this.items;
      int index = 0;
      for (int size = this.size; index < size; ++index)
      {
        if ((double) items[index] == (double) value)
          return index;
      }
      return -1;
    }

    [LineNumberTable(new byte[] {160, 82, 103, 109, 41, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int lastIndexOf(float value)
    {
      float[] items = this.items;
      for (int index = this.size - 1; index >= 0; index += -1)
      {
        if ((double) items[index] == (double) value)
          return index;
      }
      return -1;
    }

    [LineNumberTable(new byte[] {160, 89, 103, 109, 103, 105, 226, 61, 230, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool removeValue(float value)
    {
      float[] items = this.items;
      int index = 0;
      for (int size = this.size; index < size; ++index)
      {
        if ((double) items[index] == (double) value)
        {
          double num = (double) this.removeIndex(index);
          return true;
        }
      }
      return false;
    }

    [LineNumberTable(new byte[] {160, 133, 103, 98, 103, 111, 106, 104, 104, 106, 100, 226, 60, 8, 230, 74})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool removeAll(FloatSeq array)
    {
      int size1 = this.size;
      int num1 = size1;
      float[] items = this.items;
      int index1 = 0;
      for (int size2 = array.size; index1 < size2; ++index1)
      {
        float num2 = array.get(index1);
        for (int index2 = 0; index2 < size1; ++index2)
        {
          if ((double) num2 == (double) items[index2])
          {
            double num3 = (double) this.removeIndex(index2);
            size1 += -1;
            break;
          }
        }
      }
      return size1 != num1;
    }

    [LineNumberTable(265)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float pop()
    {
      float[] items = this.items;
      FloatSeq floatSeq1 = this;
      int num = floatSeq1.size - 1;
      FloatSeq floatSeq2 = floatSeq1;
      int index = num;
      floatSeq2.size = num;
      return items[index];
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isEmpty() => this.size == 0;

    [LineNumberTable(new byte[] {160, 175, 102, 107, 44, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float sum()
    {
      float num = 0.0f;
      for (int index = 0; index < this.size; ++index)
        num += this.items[index];
      return num;
    }

    [LineNumberTable(new byte[] {160, 188, 124})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float[] shrink()
    {
      if (this.items.Length != this.size)
        this.resize(this.size);
      return this.items;
    }

    [LineNumberTable(new byte[] {160, 210, 127, 10, 120, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float[] setSize(int newSize)
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

    [LineNumberTable(new byte[] {160, 225, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void sort() => Arrays.sort(this.items, 0, this.size);

    [LineNumberTable(new byte[] {160, 229, 103, 120, 101, 101, 103, 230, 60, 230, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void reverse()
    {
      float[] items = this.items;
      int index1 = 0;
      int num1 = this.size - 1;
      for (int index2 = this.size / 2; index1 < index2; ++index1)
      {
        int index3 = num1 - index1;
        float num2 = items[index1];
        items[index1] = items[index3];
        items[index3] = num2;
      }
    }

    [LineNumberTable(new byte[] {160, 239, 103, 109, 103, 100, 102, 228, 60, 230, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void shuffle()
    {
      float[] items = this.items;
      for (int range = this.size - 1; range >= 0; range += -1)
      {
        int index = Mathf.random(range);
        float num = items[range];
        items[range] = items[index];
        items[index] = num;
      }
    }

    [LineNumberTable(new byte[] {161, 2, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float random() => this.size == 0 ? 0.0f : this.items[Mathf.random(0, this.size - 1)];

    [LineNumberTable(new byte[] {161, 13, 111, 103, 98, 109, 46, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int hashCode()
    {
      if (!this.ordered)
        return base.hashCode();
      float[] items = this.items;
      int num = 1;
      int index = 0;
      for (int size = this.size; index < size; ++index)
        num = num * 31 + Float.floatToIntBits(items[index]);
      return num;
    }

    [LineNumberTable(new byte[] {161, 22, 107, 106, 106, 103, 106, 103, 107, 103, 103, 104, 44, 136})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool equals(object @object)
    {
      if (object.ReferenceEquals(@object, (object) this))
        return true;
      if (!this.ordered || !(@object is FloatSeq))
        return false;
      FloatSeq floatSeq = (FloatSeq) @object;
      if (!floatSeq.ordered)
        return false;
      int size = this.size;
      if (size != floatSeq.size)
        return false;
      float[] items1 = this.items;
      float[] items2 = floatSeq.items;
      for (int index = 0; index < size; ++index)
      {
        if ((double) items1[index] != (double) items2[index])
          return false;
      }
      return true;
    }

    [LineNumberTable(new byte[] {161, 37, 107, 106, 103, 103, 107, 106, 106, 103, 103, 104, 54, 136})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool equals(object @object, float epsilon)
    {
      if (object.ReferenceEquals(@object, (object) this))
        return true;
      if (!(@object is FloatSeq))
        return false;
      FloatSeq floatSeq = (FloatSeq) @object;
      int size = this.size;
      if (size != floatSeq.size || !this.ordered || !floatSeq.ordered)
        return false;
      float[] items1 = this.items;
      float[] items2 = floatSeq.items;
      for (int index = 0; index < size; ++index)
      {
        if ((double) Math.abs(items1[index] - items2[index]) > (double) epsilon)
          return false;
      }
      return true;
    }

    [LineNumberTable(new byte[] {161, 52, 110, 103, 104, 105, 106, 107, 108, 10, 198, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toString()
    {
      if (this.size == 0)
        return "[]";
      float[] items = this.items;
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

    [LineNumberTable(new byte[] {161, 66, 110, 103, 104, 106, 107, 104, 10, 198})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toString(string separator)
    {
      if (this.size == 0)
        return "";
      float[] items = this.items;
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
