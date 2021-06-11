// Decompiled with JetBrains decompiler
// Type: arc.struct.LongMap
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.math;
using arc.util;
using IKVM.Attributes;
using ikvm.lang;
using IKVM.Runtime;
using java.lang;
using java.util;
using java.util.function;
using System;
using System.Collections;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.@struct
{
  [Signature("<V:Ljava/lang/Object;>Ljava/lang/Object;Ljava/lang/Iterable<Larc/struct/LongMap$Entry<TV;>;>;")]
  [Implements(new string[] {"java.lang.Iterable"})]
  public class LongMap : Object, Iterable, IEnumerable
  {
    private const int PRIME1 = -1105259343;
    private const int PRIME2 = -1262997959;
    private const int PRIME3 = -825114047;
    private const int EMPTY = 0;
    public int size;
    internal long[] keyTable;
    [Signature("[TV;")]
    internal object[] valueTable;
    internal int capacity;
    internal int stashSize;
    [Signature("TV;")]
    internal object zeroValue;
    internal bool hasZeroValue;
    private float loadFactor;
    private int hashShift;
    private int mask;
    private int threshold;
    private int stashCapacity;
    private int pushIterations;
    private LongMap.Entries entries1;
    private LongMap.Entries entries2;
    private LongMap.Values values1;
    private LongMap.Values values2;
    private LongMap.Keys keys1;
    private LongMap.Keys keys2;

    [LineNumberTable(new byte[] {159, 186, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public LongMap()
      : this(51, 0.8f)
    {
    }

    [Signature("(J)TV;")]
    [LineNumberTable(new byte[] {160, 179, 105, 106, 135, 107, 107, 104, 107, 104, 180})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object get(long key)
    {
      if (key == 0L)
        return !this.hasZeroValue ? (object) null : this.zeroValue;
      int index = (int) (key & (long) this.mask);
      if (this.keyTable[index] != key)
      {
        index = this.hash2(key);
        if (this.keyTable[index] != key)
        {
          index = this.hash3(key);
          if (this.keyTable[index] != key)
            return this.getStash(key, (object) null);
        }
      }
      return this.valueTable[index];
    }

    [LineNumberTable(new byte[] {161, 93, 112, 107, 107, 104, 107, 104, 179})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool containsKey(long key)
    {
      if (key == 0L)
        return this.hasZeroValue;
      return this.keyTable[(int) (key & (long) this.mask)] == key || this.keyTable[this.hash2(key)] == key || this.keyTable[this.hash3(key)] == key || this.containsKeyStash(key);
    }

    [Signature("(JTV;)TV;")]
    [LineNumberTable(new byte[] {42, 105, 103, 103, 104, 103, 142, 162, 167, 107, 100, 100, 106, 105, 163, 105, 102, 101, 107, 106, 163, 105, 102, 101, 107, 106, 195, 121, 103, 107, 106, 227, 60, 232, 73, 101, 100, 105, 127, 15, 162, 102, 101, 106, 127, 15, 162, 102, 101, 106, 127, 15, 162, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object put(long key, object value)
    {
      if (key == 0L)
      {
        object zeroValue = this.zeroValue;
        this.zeroValue = value;
        if (!this.hasZeroValue)
        {
          this.hasZeroValue = true;
          ++this.size;
        }
        return zeroValue;
      }
      long[] keyTable = this.keyTable;
      int index1 = (int) (key & (long) this.mask);
      long num1 = keyTable[index1];
      if (num1 == key)
      {
        object obj = this.valueTable[index1];
        this.valueTable[index1] = value;
        return obj;
      }
      int index2 = this.hash2(key);
      long num2 = keyTable[index2];
      if (num2 == key)
      {
        object obj = this.valueTable[index2];
        this.valueTable[index2] = value;
        return obj;
      }
      int index3 = this.hash3(key);
      long num3 = keyTable[index3];
      if (num3 == key)
      {
        object obj = this.valueTable[index3];
        this.valueTable[index3] = value;
        return obj;
      }
      int capacity = this.capacity;
      for (int index4 = capacity + this.stashSize; capacity < index4; ++capacity)
      {
        if (keyTable[capacity] == key)
        {
          object obj = this.valueTable[capacity];
          this.valueTable[capacity] = value;
          return obj;
        }
      }
      if (num1 == 0L)
      {
        keyTable[index1] = key;
        this.valueTable[index1] = value;
        LongMap longMap1 = this;
        int size = longMap1.size;
        LongMap longMap2 = longMap1;
        int num4 = size;
        longMap2.size = size + 1;
        int threshold = this.threshold;
        if (num4 >= threshold)
          this.resize(this.capacity << 1);
        return (object) null;
      }
      if (num2 == 0L)
      {
        keyTable[index2] = key;
        this.valueTable[index2] = value;
        LongMap longMap1 = this;
        int size = longMap1.size;
        LongMap longMap2 = longMap1;
        int num4 = size;
        longMap2.size = size + 1;
        int threshold = this.threshold;
        if (num4 >= threshold)
          this.resize(this.capacity << 1);
        return (object) null;
      }
      if (num3 == 0L)
      {
        keyTable[index3] = key;
        this.valueTable[index3] = value;
        LongMap longMap1 = this;
        int size = longMap1.size;
        LongMap longMap2 = longMap1;
        int num4 = size;
        longMap2.size = size + 1;
        int threshold = this.threshold;
        if (num4 >= threshold)
          this.resize(this.capacity << 1);
        return (object) null;
      }
      this.push(key, value, index1, num1, index2, num2, index3, num3);
      return (object) null;
    }

    [Signature("(J)TV;")]
    [LineNumberTable(new byte[] {160, 218, 105, 106, 103, 103, 103, 110, 162, 107, 107, 106, 105, 105, 110, 162, 104, 107, 106, 105, 105, 110, 162, 104, 107, 106, 105, 105, 110, 162})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object remove(long key)
    {
      if (key == 0L)
      {
        if (!this.hasZeroValue)
          return (object) null;
        object zeroValue = this.zeroValue;
        this.zeroValue = (object) null;
        this.hasZeroValue = false;
        --this.size;
        return zeroValue;
      }
      int index1 = (int) (key & (long) this.mask);
      if (this.keyTable[index1] == key)
      {
        this.keyTable[index1] = 0L;
        object obj = this.valueTable[index1];
        this.valueTable[index1] = (object) null;
        --this.size;
        return obj;
      }
      int index2 = this.hash2(key);
      if (this.keyTable[index2] == key)
      {
        this.keyTable[index2] = 0L;
        object obj = this.valueTable[index2];
        this.valueTable[index2] = (object) null;
        --this.size;
        return obj;
      }
      int index3 = this.hash3(key);
      if (this.keyTable[index3] != key)
        return this.removeStash(key);
      this.keyTable[index3] = 0L;
      object obj1 = this.valueTable[index3];
      this.valueTable[index3] = (object) null;
      --this.size;
      return obj1;
    }

    [Signature("()Larc/struct/LongMap$Values<TV;>;")]
    [LineNumberTable(new byte[] {162, 36, 104, 108, 140, 109, 107, 108, 108, 135, 107, 108, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual LongMap.Values values()
    {
      if (this.values1 == null)
      {
        this.values1 = new LongMap.Values(this);
        this.values2 = new LongMap.Values(this);
      }
      if (!this.values1.valid)
      {
        this.values1.reset();
        this.values1.valid = true;
        this.values2.valid = false;
        return this.values1;
      }
      this.values2.reset();
      this.values2.valid = true;
      this.values1.valid = false;
      return this.values2;
    }

    [LineNumberTable(new byte[] {162, 57, 104, 108, 140, 109, 107, 108, 108, 135, 107, 108, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual LongMap.Keys keys()
    {
      if (this.keys1 == null)
      {
        this.keys1 = new LongMap.Keys(this);
        this.keys2 = new LongMap.Keys(this);
      }
      if (!this.keys1.valid)
      {
        this.keys1.reset();
        this.keys1.valid = true;
        this.keys2.valid = false;
        return this.keys1;
      }
      this.keys2.reset();
      this.keys2.valid = true;
      this.keys1.valid = false;
      return this.keys2;
    }

    [LineNumberTable(new byte[] {161, 56, 105, 103, 103, 118, 101, 134, 103, 103, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void clear()
    {
      if (this.size == 0)
        return;
      long[] keyTable = this.keyTable;
      object[] valueTable = this.valueTable;
      int index = this.capacity + this.stashSize;
      while (true)
      {
        int num = index;
        index += -1;
        if (num > 0)
        {
          keyTable[index] = 0L;
          valueTable[index] = (object) null;
        }
        else
          break;
      }
      this.size = 0;
      this.stashSize = 0;
      this.zeroValue = (object) null;
      this.hasZeroValue = false;
    }

    [LineNumberTable(new byte[] {161, 16, 110, 110, 100, 112, 112, 139, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void removeStashIndex([In] int obj0)
    {
      --this.stashSize;
      int index = this.capacity + this.stashSize;
      if (obj0 < index)
      {
        this.keyTable[obj0] = this.keyTable[index];
        this.valueTable[obj0] = this.valueTable[index];
        this.valueTable[index] = (object) null;
      }
      else
        this.valueTable[obj0] = (object) null;
    }

    [LineNumberTable(new byte[] {10, 104, 127, 10, 121, 104, 127, 6, 135, 127, 16, 136, 118, 110, 117, 127, 7, 159, 12, 120, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public LongMap(int initialCapacity, float loadFactor)
    {
      LongMap longMap = this;
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
      this.hashShift = 63 - Long.numberOfTrailingZeros((long) this.capacity);
      this.stashCapacity = Math.max(3, ByteCodeHelper.d2i(Math.ceil(Math.log((double) this.capacity))) * 2);
      this.pushIterations = Math.max(Math.min(this.capacity, 8), ByteCodeHelper.d2i(Math.sqrt((double) this.capacity)) / 8);
      this.keyTable = new long[this.capacity + this.stashCapacity];
      this.valueTable = new object[this.keyTable.Length];
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    private int hash2([In] long obj0)
    {
      obj0 *= -1262997959L;
      return (int) ((obj0 ^ (long) ((ulong) obj0 >> this.hashShift)) & (long) this.mask);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    private int hash3([In] long obj0)
    {
      obj0 *= -825114047L;
      return (int) ((obj0 ^ (long) ((ulong) obj0 >> this.hashShift)) & (long) this.mask);
    }

    [LineNumberTable(new byte[] {161, 149, 142, 103, 117, 105, 112, 127, 2, 159, 2, 103, 135, 115, 147, 103, 114, 103, 100, 104, 102, 18, 232, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void resize([In] int obj0)
    {
      int num1 = this.capacity + this.stashSize;
      this.capacity = obj0;
      this.threshold = ByteCodeHelper.f2i((float) obj0 * this.loadFactor);
      this.mask = obj0 - 1;
      this.hashShift = 63 - Long.numberOfTrailingZeros((long) obj0);
      this.stashCapacity = Math.max(3, ByteCodeHelper.d2i(Math.ceil(Math.log((double) obj0))) * 2);
      this.pushIterations = Math.max(Math.min(obj0, 8), ByteCodeHelper.d2i(Math.sqrt((double) obj0)) / 8);
      long[] keyTable = this.keyTable;
      object[] valueTable = this.valueTable;
      this.keyTable = new long[obj0 + this.stashCapacity];
      this.valueTable = new object[obj0 + this.stashCapacity];
      int size = this.size;
      this.size = !this.hasZeroValue ? 0 : 1;
      this.stashSize = 0;
      if (size <= 0)
        return;
      for (int index = 0; index < num1; ++index)
      {
        long num2 = keyTable[index];
        if (num2 != 0L)
          this.putResize(num2, valueTable[index]);
      }
    }

    [Signature("(JTV;IJIJIJ)V")]
    [LineNumberTable(new byte[] {160, 95, 103, 103, 231, 69, 170, 151, 100, 101, 100, 100, 130, 100, 102, 101, 101, 130, 100, 102, 101, 229, 69, 104, 101, 105, 101, 101, 127, 15, 161, 106, 102, 105, 102, 102, 127, 15, 161, 106, 102, 105, 102, 102, 127, 15, 161, 139, 100, 100, 133, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void push(
      [In] long obj0,
      [In] object obj1,
      [In] int obj2,
      [In] long obj3,
      [In] int obj4,
      [In] long obj5,
      [In] int obj6,
      [In] long obj7)
    {
      long[] keyTable = this.keyTable;
      object[] valueTable = this.valueTable;
      int mask = this.mask;
      int num1 = 0;
      int pushIterations = this.pushIterations;
      long num2;
      object obj;
      while (true)
      {
        switch (Mathf.random(2))
        {
          case 0:
            num2 = obj3;
            obj = valueTable[obj2];
            keyTable[obj2] = obj0;
            valueTable[obj2] = obj1;
            break;
          case 1:
            num2 = obj5;
            obj = valueTable[obj4];
            keyTable[obj4] = obj0;
            valueTable[obj4] = obj1;
            break;
          default:
            num2 = obj7;
            obj = valueTable[obj6];
            keyTable[obj6] = obj0;
            valueTable[obj6] = obj1;
            break;
        }
        obj2 = (int) (num2 & (long) mask);
        obj3 = keyTable[obj2];
        if (obj3 != 0L)
        {
          obj4 = this.hash2(num2);
          obj5 = keyTable[obj4];
          if (obj5 != 0L)
          {
            obj6 = this.hash3(num2);
            obj7 = keyTable[obj6];
            if (obj7 != 0L)
            {
              ++num1;
              if (num1 != pushIterations)
              {
                obj0 = num2;
                obj1 = obj;
              }
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
      keyTable[obj2] = num2;
      valueTable[obj2] = obj;
      LongMap longMap1 = this;
      int size1 = longMap1.size;
      LongMap longMap2 = longMap1;
      int num3 = size1;
      longMap2.size = size1 + 1;
      int threshold1 = this.threshold;
      if (num3 < threshold1)
        return;
      this.resize(this.capacity << 1);
      return;
label_10:
      keyTable[obj4] = num2;
      valueTable[obj4] = obj;
      LongMap longMap3 = this;
      int size2 = longMap3.size;
      LongMap longMap4 = longMap3;
      int num4 = size2;
      longMap4.size = size2 + 1;
      int threshold2 = this.threshold;
      if (num4 < threshold2)
        return;
      this.resize(this.capacity << 1);
      return;
label_14:
      keyTable[obj6] = num2;
      valueTable[obj6] = obj;
      LongMap longMap5 = this;
      int size3 = longMap5.size;
      LongMap longMap6 = longMap5;
      int num5 = size3;
      longMap6.size = size3 + 1;
      int threshold3 = this.threshold;
      if (num5 < threshold3)
        return;
      this.resize(this.capacity << 1);
      return;
label_19:
      this.putStash(num2, obj);
    }

    [Signature("()Larc/struct/LongMap$Entries<TV;>;")]
    [LineNumberTable(new byte[] {162, 15, 104, 108, 140, 109, 107, 108, 108, 135, 107, 108, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual LongMap.Entries entries()
    {
      if (this.entries1 == null)
      {
        this.entries1 = new LongMap.Entries(this);
        this.entries2 = new LongMap.Entries(this);
      }
      if (!this.entries1.valid)
      {
        this.entries1.reset();
        this.entries1.valid = true;
        this.entries2.valid = false;
        return this.entries1;
      }
      this.entries2.reset();
      this.entries2.valid = true;
      this.entries1.valid = false;
      return this.entries2;
    }

    [Signature("(JTV;)V")]
    [LineNumberTable(new byte[] {160, 164, 142, 110, 104, 161, 110, 105, 105, 110, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void putStash([In] long obj0, [In] object obj1)
    {
      if (this.stashSize == this.stashCapacity)
      {
        this.resize(this.capacity << 1);
        this.putResize(obj0, obj1);
      }
      else
      {
        int index = this.capacity + this.stashSize;
        this.keyTable[index] = obj0;
        this.valueTable[index] = obj1;
        ++this.stashSize;
        ++this.size;
      }
    }

    [Signature("(JTV;)V")]
    [LineNumberTable(new byte[] {121, 105, 103, 103, 193, 107, 105, 101, 105, 105, 127, 10, 161, 105, 107, 102, 106, 106, 127, 10, 161, 105, 107, 102, 106, 106, 127, 10, 161, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void putResize([In] long obj0, [In] object obj1)
    {
      if (obj0 == 0L)
      {
        this.zeroValue = obj1;
        this.hasZeroValue = true;
      }
      else
      {
        int index1 = (int) (obj0 & (long) this.mask);
        long num1 = this.keyTable[index1];
        if (num1 == 0L)
        {
          this.keyTable[index1] = obj0;
          this.valueTable[index1] = obj1;
          LongMap longMap1 = this;
          int size = longMap1.size;
          LongMap longMap2 = longMap1;
          int num2 = size;
          longMap2.size = size + 1;
          int threshold = this.threshold;
          if (num2 < threshold)
            return;
          this.resize(this.capacity << 1);
        }
        else
        {
          int index2 = this.hash2(obj0);
          long num2 = this.keyTable[index2];
          if (num2 == 0L)
          {
            this.keyTable[index2] = obj0;
            this.valueTable[index2] = obj1;
            LongMap longMap1 = this;
            int size = longMap1.size;
            LongMap longMap2 = longMap1;
            int num3 = size;
            longMap2.size = size + 1;
            int threshold = this.threshold;
            if (num3 < threshold)
              return;
            this.resize(this.capacity << 1);
          }
          else
          {
            int index3 = this.hash3(obj0);
            long num3 = this.keyTable[index3];
            if (num3 == 0L)
            {
              this.keyTable[index3] = obj0;
              this.valueTable[index3] = obj1;
              LongMap longMap1 = this;
              int size = longMap1.size;
              LongMap longMap2 = longMap1;
              int num4 = size;
              longMap2.size = size + 1;
              int threshold = this.threshold;
              if (num4 < threshold)
                return;
              this.resize(this.capacity << 1);
            }
            else
              this.push(obj0, obj1, index1, num1, index2, num2, index3, num3);
          }
        }
      }
    }

    [Signature("(JTV;)TV;")]
    [LineNumberTable(new byte[] {160, 211, 103, 116, 47, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private object getStash([In] long obj0, [In] object obj1)
    {
      long[] keyTable = this.keyTable;
      int capacity = this.capacity;
      for (int index = capacity + this.stashSize; capacity < index; ++capacity)
      {
        if (keyTable[capacity] == obj0)
          return this.valueTable[capacity];
      }
      return obj1;
    }

    [Signature("(J)TV;")]
    [LineNumberTable(new byte[] {161, 2, 103, 116, 102, 105, 103, 110, 226, 59, 230, 72})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual object removeStash([In] long obj0)
    {
      long[] keyTable = this.keyTable;
      int capacity = this.capacity;
      for (int index = capacity + this.stashSize; capacity < index; ++capacity)
      {
        if (keyTable[capacity] == obj0)
        {
          object obj = this.valueTable[capacity];
          this.removeStashIndex(capacity);
          --this.size;
          return obj;
        }
      }
      return (object) null;
    }

    [LineNumberTable(new byte[] {161, 106, 103, 116, 40, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool containsKeyStash([In] long obj0)
    {
      long[] keyTable = this.keyTable;
      int capacity = this.capacity;
      for (int index = capacity + this.stashSize; capacity < index; ++capacity)
      {
        if (keyTable[capacity] == obj0)
          return true;
      }
      return false;
    }

    [LineNumberTable(new byte[] {2, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public LongMap(int initialCapacity)
      : this(initialCapacity, 0.8f)
    {
    }

    [Signature("(Larc/struct/LongMap<+TV;>;)V")]
    [LineNumberTable(new byte[] {32, 127, 10, 108, 122, 122, 108, 108, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public LongMap(LongMap map)
      : this(ByteCodeHelper.d2i(Math.floor((double) ((float) map.capacity * map.loadFactor))), map.loadFactor)
    {
      LongMap longMap = this;
      this.stashSize = map.stashSize;
      ByteCodeHelper.arraycopy_primitive_8((Array) map.keyTable, 0, (Array) this.keyTable, 0, map.keyTable.Length);
      ByteCodeHelper.arraycopy((object) map.valueTable, 0, (object) this.valueTable, 0, map.valueTable.Length);
      this.size = map.size;
      this.zeroValue = map.zeroValue;
      this.hasZeroValue = map.hasZeroValue;
    }

    [Signature("(Larc/struct/LongMap<+TV;>;)V")]
    [LineNumberTable(new byte[] {115, 127, 1, 117})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void putAll(LongMap map)
    {
      Iterator iterator = map.entries().iterator();
      while (iterator.hasNext())
      {
        LongMap.Entry entry = (LongMap.Entry) iterator.next();
        this.put(entry.key, entry.value);
      }
    }

    [Signature("(JTV;)TV;")]
    [LineNumberTable(new byte[] {160, 195, 105, 106, 135, 107, 107, 104, 107, 104, 180})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object get(long key, object defaultValue)
    {
      if (key == 0L)
        return !this.hasZeroValue ? defaultValue : this.zeroValue;
      int index = (int) (key & (long) this.mask);
      if (this.keyTable[index] != key)
      {
        index = this.hash2(key);
        if (this.keyTable[index] != key)
        {
          index = this.hash3(key);
          if (this.keyTable[index] != key)
            return this.getStash(key, defaultValue);
        }
      }
      return this.valueTable[index];
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isEmpty() => this.size == 0;

    [LineNumberTable(new byte[] {161, 36, 127, 10, 113, 106, 104, 103})]
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

    [LineNumberTable(new byte[] {161, 45, 105, 102, 129, 103, 103, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void clear(int maximumCapacity)
    {
      if (this.capacity <= maximumCapacity)
      {
        this.clear();
      }
      else
      {
        this.zeroValue = (object) null;
        this.hasZeroValue = false;
        this.size = 0;
        this.resize(maximumCapacity);
      }
    }

    [LineNumberTable(new byte[] {159, 31, 66, 103, 99, 114, 103, 118, 110, 104, 112, 122, 144, 120, 122, 142})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool containsValue(object value, bool identity)
    {
      int num1 = identity ? 1 : 0;
      object[] valueTable = this.valueTable;
      if (value == null)
      {
        if (this.hasZeroValue && this.zeroValue == null)
          return true;
        long[] keyTable = this.keyTable;
        int index = this.capacity + this.stashSize;
        do
        {
          int num2 = index;
          index += -1;
          if (num2 <= 0)
            goto label_20;
        }
        while (keyTable[index] == 0L || valueTable[index] != null);
        return true;
      }
      if (num1 != 0)
      {
        if (object.ReferenceEquals(value, this.zeroValue))
          return true;
        int index = this.capacity + this.stashSize;
        do
        {
          int num2 = index;
          index += -1;
          if (num2 <= 0)
            goto label_20;
        }
        while (!object.ReferenceEquals(valueTable[index], value));
        return true;
      }
      if (this.hasZeroValue && Object.instancehelper_equals(value, this.zeroValue))
        return true;
      int index1 = this.capacity + this.stashSize;
      do
      {
        int num2 = index1;
        index1 += -1;
        if (num2 <= 0)
          goto label_20;
      }
      while (!Object.instancehelper_equals(value, valueTable[index1]));
      return true;
label_20:
      return false;
    }

    [LineNumberTable(new byte[] {159, 20, 98, 103, 99, 115, 103, 118, 112, 104, 113, 122, 152, 121, 122, 150})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual long findKey(object value, bool identity, long notFound)
    {
      int num1 = identity ? 1 : 0;
      object[] valueTable = this.valueTable;
      if (value == null)
      {
        if (this.hasZeroValue && this.zeroValue == null)
          return 0;
        long[] keyTable = this.keyTable;
        int index = this.capacity + this.stashSize;
        do
        {
          int num2 = index;
          index += -1;
          if (num2 <= 0)
            goto label_20;
        }
        while (keyTable[index] == 0L || valueTable[index] != null);
        return keyTable[index];
      }
      if (num1 != 0)
      {
        if (object.ReferenceEquals(value, this.zeroValue))
          return 0;
        int index = this.capacity + this.stashSize;
        do
        {
          int num2 = index;
          index += -1;
          if (num2 <= 0)
            goto label_20;
        }
        while (!object.ReferenceEquals(valueTable[index], value));
        return this.keyTable[index];
      }
      if (this.hasZeroValue && Object.instancehelper_equals(value, this.zeroValue))
        return 0;
      int index1 = this.capacity + this.stashSize;
      do
      {
        int num2 = index1;
        index1 += -1;
        if (num2 <= 0)
          goto label_20;
      }
      while (!Object.instancehelper_equals(value, valueTable[index1]));
      return this.keyTable[index1];
label_20:
      return notFound;
    }

    [LineNumberTable(new byte[] {161, 142, 100, 127, 6, 105, 127, 11})]
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

    [LineNumberTable(new byte[] {161, 186, 98, 112, 142, 103, 103, 118, 101, 102, 143, 101, 100, 234, 57, 230, 75})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int hashCode()
    {
      int num1 = 0;
      if (this.hasZeroValue && this.zeroValue != null)
        num1 += Object.instancehelper_hashCode(this.zeroValue);
      long[] keyTable = this.keyTable;
      object[] valueTable = this.valueTable;
      int index1 = 0;
      for (int index2 = this.capacity + this.stashSize; index1 < index2; ++index1)
      {
        long num2 = keyTable[index1];
        if (num2 != 0L)
        {
          num1 += (int) (num2 ^ (long) ((ulong) num2 >> 32)) * 31;
          object obj = valueTable[index1];
          if (obj != null)
            num1 += Object.instancehelper_hashCode(obj);
        }
      }
      return num1;
    }

    [LineNumberTable(new byte[] {161, 207, 107, 106, 103, 112, 112, 104, 104, 138, 181, 103, 103, 121, 101, 102, 101, 100, 150, 243, 57, 233, 75})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool equals(object obj)
    {
      if (object.ReferenceEquals(obj, (object) this))
        return true;
      if (!(obj is LongMap))
        return false;
      LongMap longMap = (LongMap) obj;
      if (longMap.size != this.size || longMap.hasZeroValue != this.hasZeroValue)
        return false;
      if (this.hasZeroValue)
      {
        if (longMap.zeroValue == null)
        {
          if (this.zeroValue != null)
            return false;
        }
        else if (!Object.instancehelper_equals(longMap.zeroValue, this.zeroValue))
          return false;
      }
      long[] keyTable = this.keyTable;
      object[] valueTable = this.valueTable;
      int index1 = 0;
      for (int index2 = this.capacity + this.stashSize; index1 < index2; ++index1)
      {
        long key = keyTable[index1];
        if (key != 0L)
        {
          object obj1 = valueTable[index1];
          if (obj1 == null)
          {
            if (!longMap.containsKey(key) || longMap.get(key) != null)
              return false;
          }
          else if (!Object.instancehelper_equals(obj1, longMap.get(key)))
            return false;
        }
      }
      return true;
    }

    [LineNumberTable(new byte[] {161, 236, 110, 104, 105, 103, 103, 99, 104, 101, 104, 105, 105, 106, 130, 104, 101, 104, 108, 105, 105, 106, 98, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toString()
    {
      if (this.size == 0)
        return "[]";
      StringBuilder stringBuilder = new StringBuilder(32);
      stringBuilder.append('[');
      long[] keyTable = this.keyTable;
      object[] valueTable = this.valueTable;
      int length = keyTable.Length;
      long num1;
      do
      {
        int num2 = length;
        length += -1;
        if (num2 > 0)
          num1 = keyTable[length];
        else
          goto label_6;
      }
      while (num1 == 0L);
      stringBuilder.append(num1);
      stringBuilder.append('=');
      stringBuilder.append(valueTable[length]);
label_6:
      while (true)
      {
        long num2;
        do
        {
          int num3 = length;
          length += -1;
          if (num3 > 0)
            num2 = keyTable[length];
          else
            goto label_9;
        }
        while (num2 == 0L);
        stringBuilder.append(", ");
        stringBuilder.append(num2);
        stringBuilder.append('=');
        stringBuilder.append(valueTable[length]);
      }
label_9:
      stringBuilder.append(']');
      return stringBuilder.toString();
    }

    [Signature("()Ljava/util/Iterator<Larc/struct/LongMap$Entry<TV;>;>;")]
    [LineNumberTable(633)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Iterator iterator() => (Iterator) this.entries();

    [HideFromJava]
    public virtual void forEach([In] Consumer obj0) => Iterable.\u003Cdefault\u003EforEach((Iterable) this, obj0);

    [HideFromJava]
    public virtual Spliterator spliterator() => Iterable.\u003Cdefault\u003Espliterator((Iterable) this);

    [HideFromJava]
    [SpecialName]
    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) new IterableEnumerator((Iterable) this);

    [Signature("<V:Ljava/lang/Object;>Larc/struct/LongMap$MapIterator<TV;>;Ljava/lang/Iterable<Larc/struct/LongMap$Entry<TV;>;>;Ljava/util/Iterator<Larc/struct/LongMap$Entry<TV;>;>;")]
    [Implements(new string[] {"java.lang.Iterable", "java.util.Iterator"})]
    public class Entries : LongMap.MapIterator, Iterable, IEnumerable, Iterator
    {
      [Signature("Larc/struct/LongMap$Entry<TV;>;")]
      private LongMap.Entry entry;

      [Signature("()Larc/struct/LongMap$Entry<TV;>;")]
      [LineNumberTable(new byte[] {162, 143, 115, 120, 108, 105, 109, 152, 115, 157, 108, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual LongMap.Entry next()
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
        long[] keyTable = this.map.keyTable;
        if (this.nextIndex == -1)
        {
          this.entry.key = 0L;
          this.entry.value = this.map.zeroValue;
        }
        else
        {
          this.entry.key = keyTable[this.nextIndex];
          this.entry.value = this.map.valueTable[this.nextIndex];
        }
        this.currentIndex = this.nextIndex;
        this.findNextIndex();
        return this.entry;
      }

      [LineNumberTable(new byte[] {162, 138, 233, 61, 203})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public Entries(LongMap map)
        : base(map)
      {
        LongMap.Entries entries = this;
        this.entry = new LongMap.Entry();
      }

      [LineNumberTable(new byte[] {162, 159, 120})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual bool hasNext()
      {
        if (!this.valid)
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new ArcRuntimeException("#iterator() cannot be used nested.");
        }
        return this.hasNext;
      }

      [Signature("()Ljava/util/Iterator<Larc/struct/LongMap$Entry<TV;>;>;")]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual Iterator iterator() => (Iterator) this;

      [LineNumberTable(new byte[] {162, 168, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void remove() => base.remove();

      [Modifiers]
      [LineNumberTable(760)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void reset() => base.reset();

      [Modifiers]
      [EditorBrowsable(EditorBrowsableState.Never)]
      [LineNumberTable(760)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual object \u003Cbridge\u003Enext() => (object) this.next();

      [HideFromJava]
      public virtual void forEach([In] Consumer obj0) => Iterable.\u003Cdefault\u003EforEach((Iterable) this, obj0);

      [HideFromJava]
      public virtual Spliterator spliterator() => Iterable.\u003Cdefault\u003Espliterator((Iterable) this);

      [HideFromJava]
      public virtual void forEachRemaining([In] Consumer obj0) => Iterator.\u003Cdefault\u003EforEachRemaining((Iterator) this, obj0);

      [HideFromJava]
      [SpecialName]
      IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) new IterableEnumerator((Iterable) this);

      object Iterator.__\u003Coverridestub\u003Ejava\u002Eutil\u002EIterator\u003A\u003Anext() => this.\u003Cbridge\u003Enext();

      [HideFromJava]
      public bool hasNext
      {
        [HideFromJava] get => this.hasNext;
        [HideFromJava] [param: In] set => this.hasNext = value;
      }
    }

    [Signature("<V:Ljava/lang/Object;>Ljava/lang/Object;")]
    public class Entry : Object
    {
      public long key;
      [Signature("TV;")]
      public object value;

      [LineNumberTable(699)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public Entry()
      {
      }

      [LineNumberTable(704)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual string toString() => new StringBuilder().append(this.key).append("=").append(this.value).toString();
    }

    public class Keys : LongMap.MapIterator
    {
      [LineNumberTable(new byte[] {162, 214, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public Keys(LongMap map)
        : base(map)
      {
      }

      [Modifiers]
      [LineNumberTable(838)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void reset() => base.reset();

      [LineNumberTable(new byte[] {162, 218, 115, 120, 127, 1, 108, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual long next()
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
        long num = this.nextIndex != -1 ? this.map.keyTable[this.nextIndex] : 0L;
        this.currentIndex = this.nextIndex;
        this.findNextIndex();
        return num;
      }

      [LineNumberTable(new byte[] {162, 228, 114, 104, 110})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual LongSeq toArray()
      {
        LongSeq longSeq = new LongSeq(true, this.map.size);
        while (this.hasNext)
          longSeq.add(this.next());
        return longSeq;
      }

      [Modifiers]
      [LineNumberTable(838)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void remove() => base.remove();

      [HideFromJava]
      public bool hasNext
      {
        [HideFromJava] get => this.hasNext;
        [HideFromJava] [param: In] set => this.hasNext = value;
      }
    }

    [InnerClass]
    [Signature("<V:Ljava/lang/Object;>Ljava/lang/Object;")]
    internal class MapIterator : Object
    {
      internal const int INDEX_ILLEGAL = -2;
      internal const int INDEX_ZERO = -1;
      [Modifiers]
      [Signature("Larc/struct/LongMap<TV;>;")]
      internal LongMap map;
      public bool hasNext;
      internal int nextIndex;
      internal int currentIndex;
      internal bool valid;

      [LineNumberTable(new byte[] {162, 96, 104, 103, 109, 137, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void reset()
      {
        this.currentIndex = -2;
        this.nextIndex = -1;
        if (this.map.hasZeroValue)
          this.hasNext = true;
        else
          this.findNextIndex();
      }

      [LineNumberTable(new byte[] {162, 105, 103, 108, 127, 15, 108, 103, 162})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal virtual void findNextIndex()
      {
        this.hasNext = false;
        long[] keyTable = this.map.keyTable;
        int num1 = this.map.capacity + this.map.stashSize;
        do
        {
          LongMap.MapIterator mapIterator1 = this;
          int num2 = mapIterator1.nextIndex + 1;
          LongMap.MapIterator mapIterator2 = mapIterator1;
          int num3 = num2;
          mapIterator2.nextIndex = num2;
          int num4 = num1;
          if (num3 >= num4)
            goto label_4;
        }
        while (keyTable[this.nextIndex] == 0L);
        goto label_3;
label_4:
        return;
label_3:
        this.hasNext = true;
      }

      [Signature("(Larc/struct/LongMap<TV;>;)V")]
      [LineNumberTable(new byte[] {162, 90, 8, 167, 103, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public MapIterator([In] LongMap obj0)
      {
        LongMap.MapIterator mapIterator = this;
        this.valid = true;
        this.map = obj0;
        this.reset();
      }

      [LineNumberTable(new byte[] {162, 116, 118, 108, 113, 105, 112, 115, 113, 110, 136, 116, 147, 104, 115})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void remove()
      {
        if (this.currentIndex == -1 && this.map.hasZeroValue)
        {
          this.map.zeroValue = (object) null;
          this.map.hasZeroValue = false;
        }
        else
        {
          if (this.currentIndex < 0)
          {
            Throwable.__\u003CsuppressFillInStackTrace\u003E();
            throw new IllegalStateException("next must be called before remove.");
          }
          if (this.currentIndex >= this.map.capacity)
          {
            this.map.removeStashIndex(this.currentIndex);
            this.nextIndex = this.currentIndex - 1;
            this.findNextIndex();
          }
          else
          {
            this.map.keyTable[this.currentIndex] = 0L;
            this.map.valueTable[this.currentIndex] = (object) null;
          }
        }
        this.currentIndex = -2;
        --this.map.size;
      }
    }

    [Signature("<V:Ljava/lang/Object;>Larc/struct/LongMap$MapIterator<TV;>;Ljava/lang/Iterable<TV;>;Ljava/util/Iterator<TV;>;")]
    [Implements(new string[] {"java.lang.Iterable", "java.util.Iterator"})]
    public class Values : LongMap.MapIterator, Iterable, IEnumerable, Iterator
    {
      [Signature("(Larc/struct/LongMap<TV;>;)V")]
      [LineNumberTable(new byte[] {162, 174, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public Values(LongMap map)
        : base(map)
      {
      }

      [Modifiers]
      [LineNumberTable(798)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void reset() => base.reset();

      [Signature("()TV;")]
      [LineNumberTable(new byte[] {162, 183, 115, 152, 105, 142, 115, 108, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual object next()
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
        object obj = this.nextIndex != -1 ? this.map.valueTable[this.nextIndex] : this.map.zeroValue;
        this.currentIndex = this.nextIndex;
        this.findNextIndex();
        return obj;
      }

      [LineNumberTable(new byte[] {162, 178, 120})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual bool hasNext()
      {
        if (!this.valid)
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new ArcRuntimeException("#iterator() cannot be used nested.");
        }
        return this.hasNext;
      }

      [Signature("()Ljava/util/Iterator<TV;>;")]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual Iterator iterator() => (Iterator) this;

      [Signature("()Larc/struct/Seq<TV;>;")]
      [LineNumberTable(new byte[] {162, 201, 114, 104, 110})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual Seq toArray()
      {
        Seq seq = new Seq(true, this.map.size);
        while (this.hasNext)
          seq.add(this.next());
        return seq;
      }

      [LineNumberTable(new byte[] {162, 208, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void remove() => base.remove();

      [HideFromJava]
      public virtual void forEach([In] Consumer obj0) => Iterable.\u003Cdefault\u003EforEach((Iterable) this, obj0);

      [HideFromJava]
      public virtual Spliterator spliterator() => Iterable.\u003Cdefault\u003Espliterator((Iterable) this);

      [HideFromJava]
      public virtual void forEachRemaining([In] Consumer obj0) => Iterator.\u003Cdefault\u003EforEachRemaining((Iterator) this, obj0);

      [HideFromJava]
      [SpecialName]
      IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) new IterableEnumerator((Iterable) this);

      [HideFromJava]
      public bool hasNext
      {
        [HideFromJava] get => this.hasNext;
        [HideFromJava] [param: In] set => this.hasNext = value;
      }
    }
  }
}
