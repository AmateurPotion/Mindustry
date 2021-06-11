// Decompiled with JetBrains decompiler
// Type: arc.struct.IntSet
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.func;
using arc.math;
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
  public class IntSet : Object
  {
    private const int PRIME1 = -1105259343;
    private const int PRIME2 = -1262997959;
    private const int PRIME3 = -825114047;
    private const int EMPTY = 0;
    public int size;
    internal int[] keyTable;
    internal int capacity;
    internal int stashSize;
    internal bool hasZeroValue;
    private float loadFactor;
    private int hashShift;
    private int mask;
    private int threshold;
    private int stashCapacity;
    private int pushIterations;
    private IntSet.IntSetIterator iterator1;
    private IntSet.IntSetIterator iterator2;

    [LineNumberTable(new byte[] {159, 181, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public IntSet()
      : this(51, 0.8f)
    {
    }

    [LineNumberTable(new byte[] {160, 248, 105, 103, 118, 102, 103, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void clear()
    {
      if (this.size == 0)
        return;
      int[] keyTable = this.keyTable;
      int index = this.capacity + this.stashSize;
      while (true)
      {
        int num = index;
        index += -1;
        if (num > 0)
          keyTable[index] = 0;
        else
          break;
      }
      this.size = 0;
      this.stashSize = 0;
      this.hasZeroValue = false;
    }

    [LineNumberTable(new byte[] {48, 99, 106, 103, 110, 162, 167, 105, 100, 134, 104, 101, 135, 105, 102, 167, 121, 41, 200, 99, 100, 127, 15, 162, 100, 100, 127, 15, 162, 100, 101, 127, 15, 162, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool add(int key)
    {
      if (key == 0)
      {
        if (this.hasZeroValue)
          return false;
        this.hasZeroValue = true;
        ++this.size;
        return true;
      }
      int[] keyTable = this.keyTable;
      int index1 = key & this.mask;
      int num1 = keyTable[index1];
      if (num1 == key)
        return false;
      int index2 = this.hash2(key);
      int num2 = keyTable[index2];
      if (num2 == key)
        return false;
      int index3 = this.hash3(key);
      int num3 = keyTable[index3];
      if (num3 == key)
        return false;
      int capacity = this.capacity;
      for (int index4 = capacity + this.stashSize; capacity < index4; ++capacity)
      {
        if (keyTable[capacity] == key)
          return false;
      }
      if (num1 == 0)
      {
        keyTable[index1] = key;
        IntSet intSet1 = this;
        int size = intSet1.size;
        IntSet intSet2 = intSet1;
        int num4 = size;
        intSet2.size = size + 1;
        int threshold = this.threshold;
        if (num4 >= threshold)
          this.resize(this.capacity << 1);
        return true;
      }
      if (num2 == 0)
      {
        keyTable[index2] = key;
        IntSet intSet1 = this;
        int size = intSet1.size;
        IntSet intSet2 = intSet1;
        int num4 = size;
        intSet2.size = size + 1;
        int threshold = this.threshold;
        if (num4 >= threshold)
          this.resize(this.capacity << 1);
        return true;
      }
      if (num3 == 0)
      {
        keyTable[index3] = key;
        IntSet intSet1 = this;
        int size = intSet1.size;
        IntSet intSet2 = intSet1;
        int num4 = size;
        intSet2.size = size + 1;
        int threshold = this.threshold;
        if (num4 >= threshold)
          this.resize(this.capacity << 1);
        return true;
      }
      this.push(key, index1, num1, index2, num2, index3, num3);
      return true;
    }

    [LineNumberTable(new byte[] {118, 108, 103, 104, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addAll(IntSet set)
    {
      this.ensureCapacity(set.size);
      IntSet.IntSetIterator intSetIterator = set.iterator();
      while (intSetIterator.hasNext)
        this.add(intSetIterator.next());
    }

    [LineNumberTable(new byte[] {161, 2, 106, 105, 107, 104, 107, 104, 179})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool contains(int key)
    {
      if (key == 0)
        return this.hasZeroValue;
      return this.keyTable[key & this.mask] == key || this.keyTable[this.hash2(key)] == key || this.keyTable[this.hash3(key)] == key || this.containsKeyStash(key);
    }

    [LineNumberTable(new byte[] {160, 169, 99, 106, 103, 110, 162, 105, 107, 105, 110, 162, 104, 107, 105, 110, 162, 104, 107, 105, 110, 162})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool remove(int key)
    {
      if (key == 0)
      {
        if (!this.hasZeroValue)
          return false;
        this.hasZeroValue = false;
        --this.size;
        return true;
      }
      int index1 = key & this.mask;
      if (this.keyTable[index1] == key)
      {
        this.keyTable[index1] = 0;
        --this.size;
        return true;
      }
      int index2 = this.hash2(key);
      if (this.keyTable[index2] == key)
      {
        this.keyTable[index2] = 0;
        --this.size;
        return true;
      }
      int index3 = this.hash3(key);
      if (this.keyTable[index3] != key)
        return this.removeStash(key);
      this.keyTable[index3] = 0;
      --this.size;
      return true;
    }

    [LineNumberTable(new byte[] {40, 103, 104, 142})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void each(Intc cons)
    {
      IntSet.IntSetIterator intSetIterator = this.iterator();
      while (intSetIterator.hasNext)
        cons.get(intSetIterator.next());
    }

    [LineNumberTable(new byte[] {161, 123, 104, 108, 140, 109, 107, 108, 108, 135, 107, 108, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual IntSet.IntSetIterator iterator()
    {
      if (this.iterator1 == null)
      {
        this.iterator1 = new IntSet.IntSetIterator(this);
        this.iterator2 = new IntSet.IntSetIterator(this);
      }
      if (!this.iterator1.valid)
      {
        this.iterator1.reset();
        this.iterator1.valid = true;
        this.iterator2.valid = false;
        return this.iterator1;
      }
      this.iterator2.reset();
      this.iterator2.valid = true;
      this.iterator1.valid = false;
      return this.iterator2;
    }

    [LineNumberTable(new byte[] {160, 214, 110, 110, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void removeStashIndex([In] int obj0)
    {
      --this.stashSize;
      int index = this.capacity + this.stashSize;
      if (obj0 >= index)
        return;
      this.keyTable[obj0] = this.keyTable[index];
    }

    [LineNumberTable(new byte[] {5, 104, 127, 10, 121, 104, 127, 6, 135, 127, 16, 136, 118, 110, 116, 127, 7, 159, 12, 120})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public IntSet(int initialCapacity, float loadFactor)
    {
      IntSet intSet = this;
      if (initialCapacity < 0)
      {
        string str = new StringBuilder().append("initialCapacity must be >= 0: ").append(initialCapacity).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException(str);
      }
      initialCapacity = Mathf.nextPowerOfTwo(ByteCodeHelper.d2i(Math.ceil((double) ((float) initialCapacity / loadFactor))));
      if (initialCapacity > 1073741824)
      {
        string str = new StringBuilder().append("initialCapacity is too large: ").append(initialCapacity).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException(str);
      }
      this.capacity = initialCapacity;
      if ((double) loadFactor <= 0.0)
      {
        string str = new StringBuilder().append("loadFactor must be > 0: ").append(loadFactor).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException(str);
      }
      this.loadFactor = loadFactor;
      this.threshold = ByteCodeHelper.f2i((float) this.capacity * loadFactor);
      this.mask = this.capacity - 1;
      this.hashShift = 31 - Integer.numberOfTrailingZeros(this.capacity);
      this.stashCapacity = Math.max(3, ByteCodeHelper.d2i(Math.ceil(Math.log((double) this.capacity))) * 2);
      this.pushIterations = Math.max(Math.min(this.capacity, 8), ByteCodeHelper.d2i(Math.sqrt((double) this.capacity)) / 8);
      this.keyTable = new int[this.capacity + this.stashCapacity];
    }

    [LineNumberTable(new byte[] {108, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addAll(params int[] array) => this.addAll(array, 0, array.Length);

    [MethodImpl(MethodImplOptions.NoInlining)]
    private int hash2([In] int obj0)
    {
      obj0 *= -1262997959;
      return (obj0 ^ (int) ((uint) obj0 >> this.hashShift)) & this.mask;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    private int hash3([In] int obj0)
    {
      obj0 *= -825114047;
      return (obj0 ^ (int) ((uint) obj0 >> this.hashShift)) & this.mask;
    }

    [LineNumberTable(new byte[] {161, 41, 142, 103, 117, 105, 111, 127, 2, 159, 2, 135, 147, 103, 114, 103, 100, 102, 101, 12, 230, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void resize([In] int obj0)
    {
      int num1 = this.capacity + this.stashSize;
      this.capacity = obj0;
      this.threshold = ByteCodeHelper.f2i((float) obj0 * this.loadFactor);
      this.mask = obj0 - 1;
      this.hashShift = 31 - Integer.numberOfTrailingZeros(obj0);
      this.stashCapacity = Math.max(3, ByteCodeHelper.d2i(Math.ceil(Math.log((double) obj0))) * 2);
      this.pushIterations = Math.max(Math.min(obj0, 8), ByteCodeHelper.d2i(Math.sqrt((double) obj0)) / 8);
      int[] keyTable = this.keyTable;
      this.keyTable = new int[obj0 + this.stashCapacity];
      int size = this.size;
      this.size = !this.hasZeroValue ? 0 : 1;
      this.stashSize = 0;
      if (size <= 0)
        return;
      for (int index = 0; index < num1; ++index)
      {
        int num2 = keyTable[index];
        if (num2 != 0)
          this.addResize(num2);
      }
    }

    [LineNumberTable(new byte[] {160, 96, 135, 199, 169, 151, 99, 100, 130, 100, 101, 130, 100, 229, 69, 102, 101, 99, 101, 127, 15, 161, 106, 102, 100, 102, 127, 15, 161, 106, 102, 100, 102, 127, 15, 161, 138, 100, 133, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void push([In] int obj0, [In] int obj1, [In] int obj2, [In] int obj3, [In] int obj4, [In] int obj5, [In] int obj6)
    {
      int[] keyTable = this.keyTable;
      int mask = this.mask;
      int num1 = 0;
      int pushIterations = this.pushIterations;
      int num2;
      while (true)
      {
        switch (Mathf.random(2))
        {
          case 0:
            num2 = obj2;
            keyTable[obj1] = obj0;
            break;
          case 1:
            num2 = obj4;
            keyTable[obj3] = obj0;
            break;
          default:
            num2 = obj6;
            keyTable[obj5] = obj0;
            break;
        }
        obj1 = num2 & mask;
        obj2 = keyTable[obj1];
        if (obj2 != 0)
        {
          obj3 = this.hash2(num2);
          obj4 = keyTable[obj3];
          if (obj4 != 0)
          {
            obj5 = this.hash3(num2);
            obj6 = keyTable[obj5];
            if (obj6 != 0)
            {
              ++num1;
              if (num1 != pushIterations)
                obj0 = num2;
              else
                goto label_19;
            }
            else
              goto label_14;
          }
          else
            goto label_10;
        }
        else
          break;
      }
      keyTable[obj1] = num2;
      IntSet intSet1 = this;
      int size1 = intSet1.size;
      IntSet intSet2 = intSet1;
      int num3 = size1;
      intSet2.size = size1 + 1;
      int threshold1 = this.threshold;
      if (num3 < threshold1)
        return;
      this.resize(this.capacity << 1);
      return;
label_10:
      keyTable[obj3] = num2;
      IntSet intSet3 = this;
      int size2 = intSet3.size;
      IntSet intSet4 = intSet3;
      int num4 = size2;
      intSet4.size = size2 + 1;
      int threshold2 = this.threshold;
      if (num4 < threshold2)
        return;
      this.resize(this.capacity << 1);
      return;
label_14:
      keyTable[obj5] = num2;
      IntSet intSet5 = this;
      int size3 = intSet5.size;
      IntSet intSet6 = intSet5;
      int num5 = size3;
      intSet6.size = size3 + 1;
      int threshold3 = this.threshold;
      if (num5 < threshold3)
        return;
      this.resize(this.capacity << 1);
      return;
label_19:
      this.addStash(num2);
    }

    [LineNumberTable(new byte[] {112, 103, 106, 42, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addAll(int[] array, int offset, int length)
    {
      this.ensureCapacity(length);
      int index1 = offset;
      for (int index2 = index1 + length; index1 < index2; ++index1)
        this.add(array[index1]);
    }

    [LineNumberTable(new byte[] {161, 34, 100, 127, 6, 105, 127, 11})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void ensureCapacity(int additionalCapacity)
    {
      if (additionalCapacity < 0)
      {
        string str = new StringBuilder().append("additionalCapacity must be >= 0: ").append(additionalCapacity).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException(str);
      }
      int num = this.size + additionalCapacity;
      if (num < this.threshold)
        return;
      this.resize(Mathf.nextPowerOfTwo(ByteCodeHelper.d2i(Math.ceil((double) ((float) num / this.loadFactor)))));
    }

    [LineNumberTable(new byte[] {160, 154, 142, 110, 103, 161, 110, 105, 110, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void addStash([In] int obj0)
    {
      if (this.stashSize == this.stashCapacity)
      {
        this.resize(this.capacity << 1);
        this.addResize(obj0);
      }
      else
      {
        this.keyTable[this.capacity + this.stashSize] = obj0;
        ++this.stashSize;
        ++this.size;
      }
    }

    [LineNumberTable(new byte[] {126, 99, 103, 193, 105, 105, 99, 105, 127, 10, 161, 105, 107, 100, 106, 127, 10, 161, 105, 107, 100, 106, 127, 10, 161, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void addResize([In] int obj0)
    {
      if (obj0 == 0)
      {
        this.hasZeroValue = true;
      }
      else
      {
        int index1 = obj0 & this.mask;
        int num1 = this.keyTable[index1];
        if (num1 == 0)
        {
          this.keyTable[index1] = obj0;
          IntSet intSet1 = this;
          int size = intSet1.size;
          IntSet intSet2 = intSet1;
          int num2 = size;
          intSet2.size = size + 1;
          int threshold = this.threshold;
          if (num2 < threshold)
            return;
          this.resize(this.capacity << 1);
        }
        else
        {
          int index2 = this.hash2(obj0);
          int num2 = this.keyTable[index2];
          if (num2 == 0)
          {
            this.keyTable[index2] = obj0;
            IntSet intSet1 = this;
            int size = intSet1.size;
            IntSet intSet2 = intSet1;
            int num3 = size;
            intSet2.size = size + 1;
            int threshold = this.threshold;
            if (num3 < threshold)
              return;
            this.resize(this.capacity << 1);
          }
          else
          {
            int index3 = this.hash3(obj0);
            int num3 = this.keyTable[index3];
            if (num3 == 0)
            {
              this.keyTable[index3] = obj0;
              IntSet intSet1 = this;
              int size = intSet1.size;
              IntSet intSet2 = intSet1;
              int num4 = size;
              intSet2.size = size + 1;
              int threshold = this.threshold;
              if (num4 < threshold)
                return;
              this.resize(this.capacity << 1);
            }
            else
              this.push(obj0, index1, num1, index2, num2, index3, num3);
          }
        }
      }
    }

    [LineNumberTable(new byte[] {160, 201, 103, 116, 102, 103, 110, 226, 60, 230, 71})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual bool removeStash([In] int obj0)
    {
      int[] keyTable = this.keyTable;
      int capacity = this.capacity;
      for (int index = capacity + this.stashSize; capacity < index; ++capacity)
      {
        if (keyTable[capacity] == obj0)
        {
          this.removeStashIndex(capacity);
          --this.size;
          return true;
        }
      }
      return false;
    }

    [LineNumberTable(new byte[] {161, 15, 103, 116, 40, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool containsKeyStash([In] int obj0)
    {
      int[] keyTable = this.keyTable;
      int capacity = this.capacity;
      for (int index = capacity + this.stashSize; capacity < index; ++capacity)
      {
        if (keyTable[capacity] == obj0)
          return true;
      }
      return false;
    }

    [LineNumberTable(new byte[] {159, 189, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public IntSet(int initialCapacity)
      : this(initialCapacity, 0.8f)
    {
    }

    [LineNumberTable(new byte[] {26, 127, 10, 108, 122, 108, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public IntSet(IntSet set)
      : this(ByteCodeHelper.d2i(Math.floor((double) ((float) set.capacity * set.loadFactor))), set.loadFactor)
    {
      IntSet intSet = this;
      this.stashSize = set.stashSize;
      ByteCodeHelper.arraycopy_primitive_4((Array) set.keyTable, 0, (Array) this.keyTable, 0, set.keyTable.Length);
      this.size = set.size;
      this.hasZeroValue = set.hasZeroValue;
    }

    [LineNumberTable(new byte[] {34, 102, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static IntSet with(params int[] array)
    {
      IntSet intSet = new IntSet();
      intSet.addAll(array);
      return intSet;
    }

    [LineNumberTable(new byte[] {98, 115})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addAll(IntSeq array) => this.addAll(array.items, 0, array.size);

    [LineNumberTable(new byte[] {102, 107, 127, 43, 110})]
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

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isEmpty() => this.size == 0;

    [LineNumberTable(new byte[] {160, 229, 127, 10, 113, 106, 104, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void shrink(int maximumCapacity)
    {
      if (maximumCapacity < 0)
      {
        string str = new StringBuilder().append("maximumCapacity must be >= 0: ").append(maximumCapacity).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException(str);
      }
      if (this.size > maximumCapacity)
        maximumCapacity = this.size;
      if (this.capacity <= maximumCapacity)
        return;
      maximumCapacity = Mathf.nextPowerOfTwo(maximumCapacity);
      this.resize(maximumCapacity);
    }

    [LineNumberTable(new byte[] {160, 238, 105, 102, 129, 103, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void clear(int maximumCapacity)
    {
      if (this.capacity <= maximumCapacity)
      {
        this.clear();
      }
      else
      {
        this.hasZeroValue = false;
        this.size = 0;
        this.resize(maximumCapacity);
      }
    }

    [LineNumberTable(new byte[] {161, 22, 106, 103, 116, 41, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int first()
    {
      if (this.hasZeroValue)
        return 0;
      int[] keyTable = this.keyTable;
      int index1 = 0;
      for (int index2 = this.capacity + this.stashSize; index1 < index2; ++index1)
      {
        if (keyTable[index1] != 0)
          return keyTable[index1];
      }
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new IllegalStateException("IntSet is empty.");
    }

    [LineNumberTable(new byte[] {161, 76, 98, 116, 53, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int hashCode()
    {
      int num = 0;
      int index1 = 0;
      for (int index2 = this.capacity + this.stashSize; index1 < index2; ++index1)
      {
        if (this.keyTable[index1] != 0)
          num += this.keyTable[index1];
      }
      return num;
    }

    [LineNumberTable(new byte[] {161, 83, 106, 103, 112, 112, 116, 60, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool equals(object obj)
    {
      if (!(obj is IntSet))
        return false;
      IntSet intSet = (IntSet) obj;
      if (intSet.size != this.size || intSet.hasZeroValue != this.hasZeroValue)
        return false;
      int index1 = 0;
      for (int index2 = this.capacity + this.stashSize; index1 < index2; ++index1)
      {
        if (this.keyTable[index1] != 0 && !intSet.contains(this.keyTable[index1]))
          return false;
      }
      return true;
    }

    [LineNumberTable(new byte[] {161, 93, 110, 104, 105, 103, 99, 104, 142, 104, 100, 101, 104, 162, 104, 100, 101, 108, 104, 98, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toString()
    {
      if (this.size == 0)
        return "[]";
      StringBuilder stringBuilder = new StringBuilder(32);
      stringBuilder.append('[');
      int[] keyTable = this.keyTable;
      int length = keyTable.Length;
      if (this.hasZeroValue)
      {
        stringBuilder.append("0");
      }
      else
      {
        int num1;
        do
        {
          int num2 = length;
          length += -1;
          if (num2 > 0)
            num1 = keyTable[length];
          else
            goto label_7;
        }
        while (num1 == 0);
        stringBuilder.append(num1);
      }
label_7:
      while (true)
      {
        int num1;
        do
        {
          int num2 = length;
          length += -1;
          if (num2 > 0)
            num1 = keyTable[length];
          else
            goto label_10;
        }
        while (num1 == 0);
        stringBuilder.append(", ");
        stringBuilder.append(num1);
      }
label_10:
      stringBuilder.append(']');
      return stringBuilder.toString();
    }

    public class IntSetIterator : Object
    {
      internal const int INDEX_ILLEGAL = -2;
      internal const int INDEX_ZERO = -1;
      [Modifiers]
      internal IntSet set;
      public bool hasNext;
      internal int nextIndex;
      internal int currentIndex;
      internal bool valid;

      [LineNumberTable(new byte[] {161, 189, 115, 120, 127, 0, 108, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual int next()
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
        int num = this.nextIndex != -1 ? this.set.keyTable[this.nextIndex] : 0;
        this.currentIndex = this.nextIndex;
        this.findNextIndex();
        return num;
      }

      [LineNumberTable(new byte[] {161, 173, 118, 110, 105, 112, 115, 113, 110, 136, 147, 104, 115})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void remove()
      {
        if (this.currentIndex == -1 && this.set.hasZeroValue)
        {
          this.set.hasZeroValue = false;
        }
        else
        {
          if (this.currentIndex < 0)
          {
            Throwable.__\u003CsuppressFillInStackTrace\u003E();
            throw new IllegalStateException("next must be called before remove.");
          }
          if (this.currentIndex >= this.set.capacity)
          {
            this.set.removeStashIndex(this.currentIndex);
            this.nextIndex = this.currentIndex - 1;
            this.findNextIndex();
          }
          else
            this.set.keyTable[this.currentIndex] = 0;
        }
        this.currentIndex = -2;
        --this.set.size;
      }

      [LineNumberTable(new byte[] {161, 153, 104, 103, 109, 137, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void reset()
      {
        this.currentIndex = -2;
        this.nextIndex = -1;
        if (this.set.hasZeroValue)
          this.hasNext = true;
        else
          this.findNextIndex();
      }

      [LineNumberTable(new byte[] {161, 162, 103, 108, 127, 15, 106, 103, 162})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal virtual void findNextIndex()
      {
        this.hasNext = false;
        int[] keyTable = this.set.keyTable;
        int num1 = this.set.capacity + this.set.stashSize;
        do
        {
          IntSet.IntSetIterator intSetIterator1 = this;
          int num2 = intSetIterator1.nextIndex + 1;
          IntSet.IntSetIterator intSetIterator2 = intSetIterator1;
          int num3 = num2;
          intSetIterator2.nextIndex = num2;
          int num4 = num1;
          if (num3 >= num4)
            goto label_4;
        }
        while (keyTable[this.nextIndex] == 0);
        goto label_3;
label_4:
        return;
label_3:
        this.hasNext = true;
      }

      [LineNumberTable(new byte[] {161, 147, 8, 167, 103, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public IntSetIterator(IntSet set)
      {
        IntSet.IntSetIterator intSetIterator = this;
        this.valid = true;
        this.set = set;
        this.reset();
      }

      [LineNumberTable(new byte[] {161, 199, 114, 104, 110})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual IntSeq toArray()
      {
        IntSeq intSeq = new IntSeq(true, this.set.size);
        while (this.hasNext)
          intSeq.add(this.next());
        return intSeq;
      }
    }
  }
}
