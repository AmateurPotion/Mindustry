// Decompiled with JetBrains decompiler
// Type: arc.struct.IntMap
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.func;
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
  [Signature("<V:Ljava/lang/Object;>Ljava/lang/Object;Ljava/lang/Iterable<Larc/struct/IntMap$Entry<TV;>;>;")]
  [Implements(new string[] {"java.lang.Iterable"})]
  public class IntMap : Object, Iterable, IEnumerable
  {
    private const int PRIME1 = -1105259343;
    private const int PRIME2 = -1262997959;
    private const int PRIME3 = -825114047;
    private const int EMPTY = 0;
    public int size;
    internal int[] keyTable;
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
    private IntMap.Entries entries1;
    private IntMap.Entries entries2;
    private IntMap.Values values1;
    private IntMap.Values values2;
    private IntMap.Keys keys1;
    private IntMap.Keys keys2;

    [Signature("(I)TV;")]
    [LineNumberTable(new byte[] {160, 201, 99, 106, 135, 105, 107, 104, 107, 104, 180})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object get(int key)
    {
      if (key == 0)
        return !this.hasZeroValue ? (object) null : this.zeroValue;
      int index = key & this.mask;
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

    [Signature("(ITV;)TV;")]
    [LineNumberTable(new byte[] {54, 99, 103, 103, 104, 103, 142, 162, 167, 105, 100, 100, 106, 105, 163, 105, 102, 101, 107, 106, 163, 105, 102, 101, 107, 106, 195, 121, 103, 107, 106, 227, 60, 232, 73, 99, 100, 105, 127, 15, 162, 100, 101, 106, 127, 15, 162, 100, 101, 106, 127, 15, 162, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object put(int key, object value)
    {
      if (key == 0)
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
      int[] keyTable = this.keyTable;
      int index1 = key & this.mask;
      int num1 = keyTable[index1];
      if (num1 == key)
      {
        object obj = this.valueTable[index1];
        this.valueTable[index1] = value;
        return obj;
      }
      int index2 = this.hash2(key);
      int num2 = keyTable[index2];
      if (num2 == key)
      {
        object obj = this.valueTable[index2];
        this.valueTable[index2] = value;
        return obj;
      }
      int index3 = this.hash3(key);
      int num3 = keyTable[index3];
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
      if (num1 == 0)
      {
        keyTable[index1] = key;
        this.valueTable[index1] = value;
        IntMap intMap1 = this;
        int size = intMap1.size;
        IntMap intMap2 = intMap1;
        int num4 = size;
        intMap2.size = size + 1;
        int threshold = this.threshold;
        if (num4 >= threshold)
          this.resize(this.capacity << 1);
        return (object) null;
      }
      if (num2 == 0)
      {
        keyTable[index2] = key;
        this.valueTable[index2] = value;
        IntMap intMap1 = this;
        int size = intMap1.size;
        IntMap intMap2 = intMap1;
        int num4 = size;
        intMap2.size = size + 1;
        int threshold = this.threshold;
        if (num4 >= threshold)
          this.resize(this.capacity << 1);
        return (object) null;
      }
      if (num3 == 0)
      {
        keyTable[index3] = key;
        this.valueTable[index3] = value;
        IntMap intMap1 = this;
        int size = intMap1.size;
        IntMap intMap2 = intMap1;
        int num4 = size;
        intMap2.size = size + 1;
        int threshold = this.threshold;
        if (num4 >= threshold)
          this.resize(this.capacity << 1);
        return (object) null;
      }
      this.push(key, value, index1, num1, index2, num2, index3, num3);
      return (object) null;
    }

    [LineNumberTable(new byte[] {6, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public IntMap()
      : this(51, 0.8f)
    {
    }

    [Signature("()Larc/struct/IntMap$Values<TV;>;")]
    [LineNumberTable(new byte[] {162, 65, 104, 108, 140, 109, 107, 108, 108, 135, 107, 108, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual IntMap.Values values()
    {
      if (this.values1 == null)
      {
        this.values1 = new IntMap.Values(this);
        this.values2 = new IntMap.Values(this);
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

    [LineNumberTable(new byte[] {161, 78, 105, 103, 103, 118, 100, 134, 103, 103, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void clear()
    {
      if (this.size == 0)
        return;
      int[] keyTable = this.keyTable;
      object[] valueTable = this.valueTable;
      int index = this.capacity + this.stashSize;
      while (true)
      {
        int num = index;
        index += -1;
        if (num > 0)
        {
          keyTable[index] = 0;
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

    [LineNumberTable(new byte[] {161, 117, 106, 105, 107, 104, 107, 104, 179})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool containsKey(int key)
    {
      if (key == 0)
        return this.hasZeroValue;
      return this.keyTable[key & this.mask] == key || this.keyTable[this.hash2(key)] == key || this.keyTable[this.hash3(key)] == key || this.containsKeyStash(key);
    }

    [Signature("(I)TV;")]
    [LineNumberTable(new byte[] {160, 240, 99, 106, 103, 103, 103, 110, 162, 105, 107, 105, 105, 105, 110, 162, 104, 107, 105, 105, 105, 110, 162, 104, 107, 105, 105, 105, 110, 162})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object remove(int key)
    {
      if (key == 0)
      {
        if (!this.hasZeroValue)
          return (object) null;
        object zeroValue = this.zeroValue;
        this.zeroValue = (object) null;
        this.hasZeroValue = false;
        --this.size;
        return zeroValue;
      }
      int index1 = key & this.mask;
      if (this.keyTable[index1] == key)
      {
        this.keyTable[index1] = 0;
        object obj = this.valueTable[index1];
        this.valueTable[index1] = (object) null;
        --this.size;
        return obj;
      }
      int index2 = this.hash2(key);
      if (this.keyTable[index2] == key)
      {
        this.keyTable[index2] = 0;
        object obj = this.valueTable[index2];
        this.valueTable[index2] = (object) null;
        --this.size;
        return obj;
      }
      int index3 = this.hash3(key);
      if (this.keyTable[index3] != key)
        return this.removeStash(key);
      this.keyTable[index3] = 0;
      object obj1 = this.valueTable[index3];
      this.valueTable[index3] = (object) null;
      --this.size;
      return obj1;
    }

    [Signature("(ITV;)TV;")]
    [LineNumberTable(new byte[] {160, 217, 99, 106, 135, 105, 107, 104, 107, 104, 180})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object get(int key, object defaultValue)
    {
      if (key == 0)
        return !this.hasZeroValue ? defaultValue : this.zeroValue;
      int index = key & this.mask;
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

    [LineNumberTable(new byte[] {161, 38, 110, 110, 100, 112, 112, 139, 105})]
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

    [LineNumberTable(new byte[] {22, 104, 127, 10, 121, 104, 127, 6, 135, 127, 16, 136, 118, 110, 116, 127, 7, 159, 12, 120, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public IntMap(int initialCapacity, float loadFactor)
    {
      IntMap intMap = this;
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
      this.valueTable = new object[this.keyTable.Length];
    }

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

    [LineNumberTable(new byte[] {161, 173, 142, 103, 117, 105, 111, 127, 2, 159, 2, 103, 135, 115, 147, 103, 114, 103, 100, 104, 102, 16, 232, 69})]
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
      object[] valueTable = this.valueTable;
      this.keyTable = new int[obj0 + this.stashCapacity];
      this.valueTable = new object[obj0 + this.stashCapacity];
      int size = this.size;
      this.size = !this.hasZeroValue ? 0 : 1;
      this.stashSize = 0;
      if (size <= 0)
        return;
      for (int index = 0; index < num1; ++index)
      {
        int num2 = keyTable[index];
        if (num2 != 0)
          this.putResize(num2, valueTable[index]);
      }
    }

    [Signature("(ITV;IIIIII)V")]
    [LineNumberTable(new byte[] {160, 107, 135, 103, 231, 69, 170, 151, 100, 101, 100, 100, 130, 100, 102, 101, 101, 130, 100, 102, 101, 229, 69, 102, 101, 100, 101, 101, 127, 15, 161, 106, 102, 100, 102, 102, 127, 15, 161, 106, 102, 100, 102, 102, 127, 15, 161, 139, 100, 100, 133, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void push(
      [In] int obj0,
      [In] object obj1,
      [In] int obj2,
      [In] int obj3,
      [In] int obj4,
      [In] int obj5,
      [In] int obj6,
      [In] int obj7)
    {
      int[] keyTable = this.keyTable;
      object[] valueTable = this.valueTable;
      int mask = this.mask;
      int num1 = 0;
      int pushIterations = this.pushIterations;
      int num2;
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
        obj2 = num2 & mask;
        obj3 = keyTable[obj2];
        if (obj3 != 0)
        {
          obj4 = this.hash2(num2);
          obj5 = keyTable[obj4];
          if (obj5 != 0)
          {
            obj6 = this.hash3(num2);
            obj7 = keyTable[obj6];
            if (obj7 != 0)
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
      IntMap intMap1 = this;
      int size1 = intMap1.size;
      IntMap intMap2 = intMap1;
      int num3 = size1;
      intMap2.size = size1 + 1;
      int threshold1 = this.threshold;
      if (num3 < threshold1)
        return;
      this.resize(this.capacity << 1);
      return;
label_10:
      keyTable[obj4] = num2;
      valueTable[obj4] = obj;
      IntMap intMap3 = this;
      int size2 = intMap3.size;
      IntMap intMap4 = intMap3;
      int num4 = size2;
      intMap4.size = size2 + 1;
      int threshold2 = this.threshold;
      if (num4 < threshold2)
        return;
      this.resize(this.capacity << 1);
      return;
label_14:
      keyTable[obj6] = num2;
      valueTable[obj6] = obj;
      IntMap intMap5 = this;
      int size3 = intMap5.size;
      IntMap intMap6 = intMap5;
      int num5 = size3;
      intMap6.size = size3 + 1;
      int threshold3 = this.threshold;
      if (num5 < threshold3)
        return;
      this.resize(this.capacity << 1);
      return;
label_19:
      this.putStash(num2, obj);
    }

    [Signature("()Larc/struct/IntMap$Entries<TV;>;")]
    [LineNumberTable(new byte[] {162, 44, 104, 108, 140, 109, 107, 108, 108, 135, 107, 108, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual IntMap.Entries entries()
    {
      if (this.entries1 == null)
      {
        this.entries1 = new IntMap.Entries(this);
        this.entries2 = new IntMap.Entries(this);
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

    [Signature("(ITV;)V")]
    [LineNumberTable(new byte[] {160, 177, 142, 110, 104, 161, 110, 105, 105, 110, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void putStash([In] int obj0, [In] object obj1)
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

    [Signature("(ITV;)V")]
    [LineNumberTable(new byte[] {160, 69, 99, 103, 103, 193, 105, 105, 99, 105, 105, 127, 10, 161, 105, 107, 100, 106, 106, 127, 10, 161, 105, 107, 100, 106, 106, 127, 10, 161, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void putResize([In] int obj0, [In] object obj1)
    {
      if (obj0 == 0)
      {
        this.zeroValue = obj1;
        this.hasZeroValue = true;
      }
      else
      {
        int index1 = obj0 & this.mask;
        int num1 = this.keyTable[index1];
        if (num1 == 0)
        {
          this.keyTable[index1] = obj0;
          this.valueTable[index1] = obj1;
          IntMap intMap1 = this;
          int size = intMap1.size;
          IntMap intMap2 = intMap1;
          int num2 = size;
          intMap2.size = size + 1;
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
            this.valueTable[index2] = obj1;
            IntMap intMap1 = this;
            int size = intMap1.size;
            IntMap intMap2 = intMap1;
            int num3 = size;
            intMap2.size = size + 1;
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
              this.valueTable[index3] = obj1;
              IntMap intMap1 = this;
              int size = intMap1.size;
              IntMap intMap2 = intMap1;
              int num4 = size;
              intMap2.size = size + 1;
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

    [Signature("(ITV;)TV;")]
    [LineNumberTable(new byte[] {160, 233, 103, 116, 47, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private object getStash([In] int obj0, [In] object obj1)
    {
      int[] keyTable = this.keyTable;
      int capacity = this.capacity;
      for (int index = capacity + this.stashSize; capacity < index; ++capacity)
      {
        if (keyTable[capacity] == obj0)
          return this.valueTable[capacity];
      }
      return obj1;
    }

    [Signature("(I)TV;")]
    [LineNumberTable(new byte[] {161, 24, 103, 116, 102, 105, 103, 110, 226, 59, 230, 72})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual object removeStash([In] int obj0)
    {
      int[] keyTable = this.keyTable;
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

    [LineNumberTable(new byte[] {161, 130, 103, 116, 40, 134})]
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

    [Signature("<V:Ljava/lang/Object;>([Ljava/lang/Object;)Larc/struct/IntMap<TV;>;")]
    [LineNumberTable(new byte[] {159, 185, 134, 105, 102, 127, 2, 239, 61, 230, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static IntMap of(params object[] values)
    {
      IntMap intMap = new IntMap();
      for (int index = 0; index < values.Length / 2; ++index)
      {
        object obj = values[index * 2];
        int key = !(obj is Character) ? ((Integer) obj).intValue() : (int) ((Character) obj).charValue();
        intMap.put(key, values[index * 2 + 1]);
      }
      return intMap;
    }

    [LineNumberTable(new byte[] {14, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public IntMap(int initialCapacity)
      : this(initialCapacity, 0.8f)
    {
    }

    [Signature("(Larc/struct/IntMap<+TV;>;)V")]
    [LineNumberTable(new byte[] {44, 127, 10, 108, 122, 122, 108, 108, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public IntMap(IntMap map)
      : this(ByteCodeHelper.d2i(Math.floor((double) ((float) map.capacity * map.loadFactor))), map.loadFactor)
    {
      IntMap intMap = this;
      this.stashSize = map.stashSize;
      ByteCodeHelper.arraycopy_primitive_4((Array) map.keyTable, 0, (Array) this.keyTable, 0, map.keyTable.Length);
      ByteCodeHelper.arraycopy((object) map.valueTable, 0, (object) this.valueTable, 0, map.valueTable.Length);
      this.size = map.size;
      this.zeroValue = map.zeroValue;
      this.hasZeroValue = map.hasZeroValue;
    }

    [Signature("(Larc/struct/IntMap<+TV;>;)V")]
    [LineNumberTable(new byte[] {127, 127, 1, 117})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void putAll(IntMap map)
    {
      Iterator iterator = map.entries().iterator();
      while (iterator.hasNext())
      {
        IntMap.Entry entry = (IntMap.Entry) iterator.next();
        this.put(entry.key, entry.value);
      }
    }

    [Signature("(ILarc/func/Prov<TV;>;)TV;")]
    [LineNumberTable(new byte[] {160, 192, 104, 99, 103, 137})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object get(int key, Prov defaultValue)
    {
      object obj = this.get(key);
      if (obj == null)
      {
        obj = defaultValue.get();
        this.put(key, obj);
      }
      return obj;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isEmpty() => this.size == 0;

    [LineNumberTable(new byte[] {161, 58, 127, 10, 113, 106, 104, 103})]
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

    [LineNumberTable(new byte[] {161, 67, 105, 102, 129, 103, 103, 103, 103})]
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

    [LineNumberTable(new byte[] {159, 25, 66, 103, 99, 114, 103, 118, 108, 104, 112, 122, 144, 120, 122, 142})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool containsValue(object value, bool identity)
    {
      int num1 = identity ? 1 : 0;
      object[] valueTable = this.valueTable;
      if (value == null)
      {
        if (this.hasZeroValue && this.zeroValue == null)
          return true;
        int[] keyTable = this.keyTable;
        int index = this.capacity + this.stashSize;
        do
        {
          int num2 = index;
          index += -1;
          if (num2 <= 0)
            goto label_20;
        }
        while (keyTable[index] == 0 || valueTable[index] != null);
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

    [LineNumberTable(new byte[] {159, 14, 98, 103, 99, 114, 103, 118, 110, 104, 112, 122, 152, 120, 122, 150})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int findKey(object value, bool identity, int notFound)
    {
      int num1 = identity ? 1 : 0;
      object[] valueTable = this.valueTable;
      if (value == null)
      {
        if (this.hasZeroValue && this.zeroValue == null)
          return 0;
        int[] keyTable = this.keyTable;
        int index = this.capacity + this.stashSize;
        do
        {
          int num2 = index;
          index += -1;
          if (num2 <= 0)
            goto label_20;
        }
        while (keyTable[index] == 0 || valueTable[index] != null);
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

    [LineNumberTable(new byte[] {161, 166, 100, 127, 6, 105, 127, 11})]
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

    [LineNumberTable(new byte[] {161, 210, 98, 112, 142, 103, 103, 118, 101, 100, 136, 101, 100, 234, 57, 230, 75})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int hashCode()
    {
      int num1 = 0;
      if (this.hasZeroValue && this.zeroValue != null)
        num1 += Object.instancehelper_hashCode(this.zeroValue);
      int[] keyTable = this.keyTable;
      object[] valueTable = this.valueTable;
      int index1 = 0;
      for (int index2 = this.capacity + this.stashSize; index1 < index2; ++index1)
      {
        int num2 = keyTable[index1];
        if (num2 != 0)
        {
          num1 += num2 * 31;
          object obj = valueTable[index1];
          if (obj != null)
            num1 += Object.instancehelper_hashCode(obj);
        }
      }
      return num1;
    }

    [LineNumberTable(new byte[] {161, 231, 107, 106, 103, 112, 112, 104, 104, 138, 181, 103, 103, 121, 101, 100, 101, 100, 150, 243, 57, 233, 75})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool equals(object obj)
    {
      if (object.ReferenceEquals(obj, (object) this))
        return true;
      if (!(obj is IntMap))
        return false;
      IntMap intMap = (IntMap) obj;
      if (intMap.size != this.size || intMap.hasZeroValue != this.hasZeroValue)
        return false;
      if (this.hasZeroValue)
      {
        if (intMap.zeroValue == null)
        {
          if (this.zeroValue != null)
            return false;
        }
        else if (!Object.instancehelper_equals(intMap.zeroValue, this.zeroValue))
          return false;
      }
      int[] keyTable = this.keyTable;
      object[] valueTable = this.valueTable;
      int index1 = 0;
      for (int index2 = this.capacity + this.stashSize; index1 < index2; ++index1)
      {
        int key = keyTable[index1];
        if (key != 0)
        {
          object obj1 = valueTable[index1];
          if (obj1 == null)
          {
            if (!intMap.containsKey(key) || intMap.get(key) != null)
              return false;
          }
          else if (!Object.instancehelper_equals(obj1, intMap.get(key)))
            return false;
        }
      }
      return true;
    }

    [LineNumberTable(new byte[] {162, 4, 110, 104, 105, 103, 103, 99, 104, 108, 143, 104, 101, 102, 105, 105, 106, 162, 104, 101, 102, 108, 105, 105, 106, 98, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toString()
    {
      if (this.size == 0)
        return "[]";
      StringBuilder stringBuilder = new StringBuilder(32);
      stringBuilder.append('[');
      int[] keyTable = this.keyTable;
      object[] valueTable = this.valueTable;
      int length = keyTable.Length;
      if (this.hasZeroValue)
      {
        stringBuilder.append("0=");
        stringBuilder.append(this.zeroValue);
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
        stringBuilder.append('=');
        stringBuilder.append(valueTable[length]);
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
        stringBuilder.append('=');
        stringBuilder.append(valueTable[length]);
      }
label_10:
      stringBuilder.append(']');
      return stringBuilder.toString();
    }

    [Signature("()Ljava/util/Iterator<Larc/struct/IntMap$Entry<TV;>;>;")]
    [LineNumberTable(662)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Iterator iterator() => (Iterator) this.entries();

    [LineNumberTable(new byte[] {162, 86, 104, 108, 140, 109, 107, 108, 108, 135, 107, 108, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual IntMap.Keys keys()
    {
      if (this.keys1 == null)
      {
        this.keys1 = new IntMap.Keys(this);
        this.keys2 = new IntMap.Keys(this);
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

    [HideFromJava]
    public virtual void forEach([In] Consumer obj0) => Iterable.\u003Cdefault\u003EforEach((Iterable) this, obj0);

    [HideFromJava]
    public virtual Spliterator spliterator() => Iterable.\u003Cdefault\u003Espliterator((Iterable) this);

    [HideFromJava]
    [SpecialName]
    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) new IterableEnumerator((Iterable) this);

    [Signature("<V:Ljava/lang/Object;>Larc/struct/IntMap$MapIterator<TV;>;Ljava/lang/Iterable<Larc/struct/IntMap$Entry<TV;>;>;Ljava/util/Iterator<Larc/struct/IntMap$Entry<TV;>;>;")]
    [Implements(new string[] {"java.lang.Iterable", "java.util.Iterator"})]
    public class Entries : IntMap.MapIterator, Iterable, IEnumerable, Iterator
    {
      [Signature("Larc/struct/IntMap$Entry<TV;>;")]
      private IntMap.Entry entry;

      [Signature("()Larc/struct/IntMap$Entry<TV;>;")]
      [LineNumberTable(new byte[] {162, 172, 115, 120, 108, 105, 108, 152, 115, 157, 108, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual IntMap.Entry next()
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
        int[] keyTable = this.map.keyTable;
        if (this.nextIndex == -1)
        {
          this.entry.key = 0;
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

      [LineNumberTable(new byte[] {162, 167, 233, 61, 203})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public Entries(IntMap map)
        : base(map)
      {
        IntMap.Entries entries = this;
        this.entry = new IntMap.Entry();
      }

      [LineNumberTable(new byte[] {162, 188, 120})]
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

      [Signature("()Ljava/util/Iterator<Larc/struct/IntMap$Entry<TV;>;>;")]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual Iterator iterator() => (Iterator) this;

      [LineNumberTable(new byte[] {162, 197, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void remove() => base.remove();

      [Modifiers]
      [LineNumberTable(789)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void reset() => base.reset();

      [Modifiers]
      [EditorBrowsable(EditorBrowsableState.Never)]
      [LineNumberTable(789)]
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
      public int key;
      [Signature("TV;")]
      public object value;

      [LineNumberTable(728)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public Entry()
      {
      }

      [LineNumberTable(733)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual string toString() => new StringBuilder().append(this.key).append("=").append(this.value).toString();
    }

    public class Keys : IntMap.MapIterator
    {
      [LineNumberTable(new byte[] {162, 243, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public Keys(IntMap map)
        : base(map)
      {
      }

      [Modifiers]
      [LineNumberTable(867)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void reset() => base.reset();

      [LineNumberTable(new byte[] {162, 247, 115, 120, 127, 0, 108, 102})]
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
        int num = this.nextIndex != -1 ? this.map.keyTable[this.nextIndex] : 0;
        this.currentIndex = this.nextIndex;
        this.findNextIndex();
        return num;
      }

      [LineNumberTable(new byte[] {163, 1, 114, 104, 110})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual IntSeq toArray()
      {
        IntSeq intSeq = new IntSeq(true, this.map.size);
        while (this.hasNext)
          intSeq.add(this.next());
        return intSeq;
      }

      [Modifiers]
      [LineNumberTable(867)]
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
      [Signature("Larc/struct/IntMap<TV;>;")]
      internal IntMap map;
      public bool hasNext;
      internal int nextIndex;
      internal int currentIndex;
      internal bool valid;

      [LineNumberTable(new byte[] {162, 125, 104, 103, 109, 137, 102})]
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

      [LineNumberTable(new byte[] {162, 134, 103, 108, 127, 15, 106, 103, 162})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal virtual void findNextIndex()
      {
        this.hasNext = false;
        int[] keyTable = this.map.keyTable;
        int num1 = this.map.capacity + this.map.stashSize;
        do
        {
          IntMap.MapIterator mapIterator1 = this;
          int num2 = mapIterator1.nextIndex + 1;
          IntMap.MapIterator mapIterator2 = mapIterator1;
          int num3 = num2;
          mapIterator2.nextIndex = num2;
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

      [Signature("(Larc/struct/IntMap<TV;>;)V")]
      [LineNumberTable(new byte[] {162, 119, 8, 167, 103, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public MapIterator([In] IntMap obj0)
      {
        IntMap.MapIterator mapIterator = this;
        this.valid = true;
        this.map = obj0;
        this.reset();
      }

      [LineNumberTable(new byte[] {162, 145, 118, 108, 113, 105, 112, 115, 113, 110, 136, 115, 147, 104, 115})]
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
            this.map.keyTable[this.currentIndex] = 0;
            this.map.valueTable[this.currentIndex] = (object) null;
          }
        }
        this.currentIndex = -2;
        --this.map.size;
      }
    }

    [Signature("<V:Ljava/lang/Object;>Larc/struct/IntMap$MapIterator<TV;>;Ljava/lang/Iterable<TV;>;Ljava/util/Iterator<TV;>;")]
    [Implements(new string[] {"java.lang.Iterable", "java.util.Iterator"})]
    public class Values : IntMap.MapIterator, Iterable, IEnumerable, Iterator
    {
      [Signature("()Ljava/util/Iterator<TV;>;")]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual Iterator iterator() => (Iterator) this;

      [Signature("(Larc/struct/IntMap<TV;>;)V")]
      [LineNumberTable(new byte[] {162, 203, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public Values(IntMap map)
        : base(map)
      {
      }

      [Modifiers]
      [LineNumberTable(827)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void reset() => base.reset();

      [Signature("()TV;")]
      [LineNumberTable(new byte[] {162, 212, 115, 152, 105, 142, 115, 108, 102})]
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

      [LineNumberTable(new byte[] {162, 207, 120})]
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

      [Signature("()Larc/struct/Seq<TV;>;")]
      [LineNumberTable(new byte[] {162, 230, 114, 104, 110})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual Seq toArray()
      {
        Seq seq = new Seq(true, this.map.size);
        while (this.hasNext)
          seq.add(this.next());
        return seq;
      }

      [LineNumberTable(new byte[] {162, 237, 102})]
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
