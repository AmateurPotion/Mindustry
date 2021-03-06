﻿// Decompiled with JetBrains decompiler
// Type: arc.struct.IntFloatMap
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
  [Signature("Ljava/lang/Object;Ljava/lang/Iterable<Larc/struct/IntFloatMap$Entry;>;")]
  [Implements(new string[] {"java.lang.Iterable"})]
  public class IntFloatMap : Object, Iterable, IEnumerable
  {
    private const int PRIME1 = -1105259343;
    private const int PRIME2 = -1262997959;
    private const int PRIME3 = -825114047;
    private const int EMPTY = 0;
    public int size;
    internal int[] keyTable;
    internal float[] valueTable;
    internal int capacity;
    internal int stashSize;
    internal float zeroValue;
    internal bool hasZeroValue;
    private float loadFactor;
    private int hashShift;
    private int mask;
    private int threshold;
    private int stashCapacity;
    private int pushIterations;
    private IntFloatMap.Entries entries1;
    private IntFloatMap.Entries entries2;
    private IntFloatMap.Values values1;
    private IntFloatMap.Values values2;
    private IntFloatMap.Keys keys1;
    private IntFloatMap.Keys keys2;

    [LineNumberTable(new byte[] {161, 77, 105, 103, 118, 102, 103, 103, 103})]
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
      this.hasZeroValue = false;
      this.size = 0;
      this.stashSize = 0;
    }

    [LineNumberTable(new byte[] {160, 178, 99, 107, 135, 105, 107, 104, 107, 104, 182})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float get(int key, float defaultValue)
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

    [LineNumberTable(new byte[] {42, 99, 104, 104, 103, 142, 161, 167, 105, 100, 100, 106, 161, 104, 101, 101, 106, 161, 105, 102, 101, 107, 193, 121, 103, 107, 225, 61, 232, 72, 99, 100, 106, 127, 15, 161, 100, 100, 106, 127, 15, 161, 100, 101, 107, 127, 15, 161, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void put(int key, float value)
    {
      if (key == 0)
      {
        this.zeroValue = value;
        if (this.hasZeroValue)
          return;
        this.hasZeroValue = true;
        ++this.size;
      }
      else
      {
        int[] keyTable = this.keyTable;
        int index1 = key & this.mask;
        int num1 = keyTable[index1];
        if (key == num1)
        {
          this.valueTable[index1] = value;
        }
        else
        {
          int index2 = this.hash2(key);
          int num2 = keyTable[index2];
          if (key == num2)
          {
            this.valueTable[index2] = value;
          }
          else
          {
            int index3 = this.hash3(key);
            int num3 = keyTable[index3];
            if (key == num3)
            {
              this.valueTable[index3] = value;
            }
            else
            {
              int capacity = this.capacity;
              for (int index4 = capacity + this.stashSize; capacity < index4; ++capacity)
              {
                if (key == keyTable[capacity])
                {
                  this.valueTable[capacity] = value;
                  return;
                }
              }
              if (num1 == 0)
              {
                keyTable[index1] = key;
                this.valueTable[index1] = value;
                IntFloatMap intFloatMap1 = this;
                int size = intFloatMap1.size;
                IntFloatMap intFloatMap2 = intFloatMap1;
                int num4 = size;
                intFloatMap2.size = size + 1;
                int threshold = this.threshold;
                if (num4 < threshold)
                  return;
                this.resize(this.capacity << 1);
              }
              else if (num2 == 0)
              {
                keyTable[index2] = key;
                this.valueTable[index2] = value;
                IntFloatMap intFloatMap1 = this;
                int size = intFloatMap1.size;
                IntFloatMap intFloatMap2 = intFloatMap1;
                int num4 = size;
                intFloatMap2.size = size + 1;
                int threshold = this.threshold;
                if (num4 < threshold)
                  return;
                this.resize(this.capacity << 1);
              }
              else if (num3 == 0)
              {
                keyTable[index3] = key;
                this.valueTable[index3] = value;
                IntFloatMap intFloatMap1 = this;
                int size = intFloatMap1.size;
                IntFloatMap intFloatMap2 = intFloatMap1;
                int num4 = size;
                intFloatMap2.size = size + 1;
                int threshold = this.threshold;
                if (num4 < threshold)
                  return;
                this.resize(this.capacity << 1);
              }
              else
                this.push(key, value, index1, num1, index2, num2, index3, num3);
            }
          }
        }
      }
    }

    [LineNumberTable(new byte[] {159, 186, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public IntFloatMap()
      : this(51, 0.8f)
    {
    }

    [LineNumberTable(287)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float get(int key) => this.get(key, 0.0f);

    [Signature("()Ljava/util/Iterator<Larc/struct/IntFloatMap$Entry;>;")]
    [LineNumberTable(637)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Iterator iterator() => (Iterator) this.entries();

    [LineNumberTable(new byte[] {161, 40, 110, 110, 100, 112, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void removeStashIndex([In] int obj0)
    {
      --this.stashSize;
      int index = this.capacity + this.stashSize;
      if (obj0 >= index)
        return;
      this.keyTable[obj0] = this.keyTable[index];
      this.valueTable[obj0] = this.valueTable[index];
    }

    [LineNumberTable(new byte[] {10, 104, 127, 10, 121, 104, 127, 6, 135, 127, 16, 136, 118, 110, 116, 127, 7, 159, 12, 120, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public IntFloatMap(int initialCapacity, float loadFactor)
    {
      IntFloatMap intFloatMap = this;
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
      this.valueTable = new float[this.keyTable.Length];
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

    [LineNumberTable(new byte[] {161, 156, 142, 103, 117, 105, 111, 127, 2, 159, 2, 103, 135, 115, 147, 103, 114, 103, 100, 104, 102, 16, 232, 69})]
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
      float[] valueTable = this.valueTable;
      this.keyTable = new int[obj0 + this.stashCapacity];
      this.valueTable = new float[obj0 + this.stashCapacity];
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

    [LineNumberTable(new byte[] {160, 89, 103, 103, 231, 69, 170, 151, 100, 101, 100, 101, 130, 100, 102, 101, 102, 130, 100, 102, 101, 230, 69, 102, 101, 100, 101, 101, 127, 15, 161, 106, 102, 100, 102, 102, 127, 15, 161, 106, 102, 100, 102, 102, 127, 15, 161, 139, 100, 100, 133, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void push(
      [In] int obj0,
      [In] float obj1,
      [In] int obj2,
      [In] int obj3,
      [In] int obj4,
      [In] int obj5,
      [In] int obj6,
      [In] int obj7)
    {
      int[] keyTable = this.keyTable;
      float[] valueTable = this.valueTable;
      int mask = this.mask;
      int num1 = 0;
      int pushIterations = this.pushIterations;
      int num2;
      float num3;
      while (true)
      {
        switch (Mathf.random(2))
        {
          case 0:
            num2 = obj3;
            num3 = valueTable[obj2];
            keyTable[obj2] = obj0;
            valueTable[obj2] = obj1;
            break;
          case 1:
            num2 = obj5;
            num3 = valueTable[obj4];
            keyTable[obj4] = obj0;
            valueTable[obj4] = obj1;
            break;
          default:
            num2 = obj7;
            num3 = valueTable[obj6];
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
                obj1 = num3;
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
      valueTable[obj2] = num3;
      IntFloatMap intFloatMap1 = this;
      int size1 = intFloatMap1.size;
      IntFloatMap intFloatMap2 = intFloatMap1;
      int num4 = size1;
      intFloatMap2.size = size1 + 1;
      int threshold1 = this.threshold;
      if (num4 < threshold1)
        return;
      this.resize(this.capacity << 1);
      return;
label_10:
      keyTable[obj4] = num2;
      valueTable[obj4] = num3;
      IntFloatMap intFloatMap3 = this;
      int size2 = intFloatMap3.size;
      IntFloatMap intFloatMap4 = intFloatMap3;
      int num5 = size2;
      intFloatMap4.size = size2 + 1;
      int threshold2 = this.threshold;
      if (num5 < threshold2)
        return;
      this.resize(this.capacity << 1);
      return;
label_14:
      keyTable[obj6] = num2;
      valueTable[obj6] = num3;
      IntFloatMap intFloatMap5 = this;
      int size3 = intFloatMap5.size;
      IntFloatMap intFloatMap6 = intFloatMap5;
      int num6 = size3;
      intFloatMap6.size = size3 + 1;
      int threshold3 = this.threshold;
      if (num6 < threshold3)
        return;
      this.resize(this.capacity << 1);
      return;
label_19:
      this.putStash(num2, num3);
    }

    [LineNumberTable(new byte[] {162, 19, 104, 108, 140, 109, 107, 108, 108, 135, 107, 108, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual IntFloatMap.Entries entries()
    {
      if (this.entries1 == null)
      {
        this.entries1 = new IntFloatMap.Entries(this);
        this.entries2 = new IntFloatMap.Entries(this);
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

    [LineNumberTable(new byte[] {160, 158, 142, 110, 105, 161, 110, 105, 106, 110, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void putStash([In] int obj0, [In] float obj1)
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

    [LineNumberTable(new byte[] {115, 99, 104, 103, 193, 105, 105, 99, 105, 106, 127, 10, 161, 105, 107, 100, 106, 107, 127, 10, 161, 105, 107, 100, 106, 107, 127, 10, 161, 115})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void putResize([In] int obj0, [In] float obj1)
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
          IntFloatMap intFloatMap1 = this;
          int size = intFloatMap1.size;
          IntFloatMap intFloatMap2 = intFloatMap1;
          int num2 = size;
          intFloatMap2.size = size + 1;
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
            IntFloatMap intFloatMap1 = this;
            int size = intFloatMap1.size;
            IntFloatMap intFloatMap2 = intFloatMap1;
            int num3 = size;
            intFloatMap2.size = size + 1;
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
              IntFloatMap intFloatMap1 = this;
              int size = intFloatMap1.size;
              IntFloatMap intFloatMap2 = intFloatMap1;
              int num4 = size;
              intFloatMap2.size = size + 1;
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

    [LineNumberTable(new byte[] {160, 194, 103, 116, 47, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private float getStash([In] int obj0, [In] float obj1)
    {
      int[] keyTable = this.keyTable;
      int capacity = this.capacity;
      for (int index = capacity + this.stashSize; capacity < index; ++capacity)
      {
        if (obj0 == keyTable[capacity])
          return this.valueTable[capacity];
      }
      return obj1;
    }

    [LineNumberTable(new byte[] {160, 209, 99, 104, 103, 112, 130, 103, 108, 110, 163, 105, 107, 104, 107, 104, 184, 105, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float increment(int key, float defaultValue, float increment)
    {
      if (key == 0)
      {
        if (this.hasZeroValue)
        {
          float zeroValue = this.zeroValue;
          this.zeroValue += increment;
          return zeroValue;
        }
        this.hasZeroValue = true;
        this.zeroValue = defaultValue + increment;
        ++this.size;
        return defaultValue;
      }
      int index = key & this.mask;
      if (key != this.keyTable[index])
      {
        index = this.hash2(key);
        if (key != this.keyTable[index])
        {
          index = this.hash3(key);
          if (key != this.keyTable[index])
            return this.getAndIncrementStash(key, defaultValue, increment);
        }
      }
      float num = this.valueTable[index];
      this.valueTable[index] = num + increment;
      return num;
    }

    [LineNumberTable(new byte[] {160, 235, 103, 116, 102, 105, 109, 226, 60, 230, 70, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private float getAndIncrementStash([In] int obj0, [In] float obj1, [In] float obj2)
    {
      int[] keyTable = this.keyTable;
      int capacity = this.capacity;
      for (int index = capacity + this.stashSize; capacity < index; ++capacity)
      {
        if (obj0 == keyTable[capacity])
        {
          float num = this.valueTable[capacity];
          this.valueTable[capacity] = num + obj2;
          return num;
        }
      }
      this.put(obj0, obj1 + obj2);
      return obj1;
    }

    [LineNumberTable(new byte[] {161, 26, 103, 116, 102, 105, 103, 110, 226, 59, 230, 72})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual float removeStash([In] int obj0, [In] float obj1)
    {
      int[] keyTable = this.keyTable;
      int capacity = this.capacity;
      for (int index = capacity + this.stashSize; capacity < index; ++capacity)
      {
        if (obj0 == keyTable[capacity])
        {
          float num = this.valueTable[capacity];
          this.removeStashIndex(capacity);
          --this.size;
          return num;
        }
      }
      return obj1;
    }

    [LineNumberTable(new byte[] {161, 125, 103, 116, 40, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool containsKeyStash([In] int obj0)
    {
      int[] keyTable = this.keyTable;
      int capacity = this.capacity;
      for (int index = capacity + this.stashSize; capacity < index; ++capacity)
      {
        if (obj0 == keyTable[capacity])
          return true;
      }
      return false;
    }

    [LineNumberTable(new byte[] {161, 112, 106, 105, 107, 104, 107, 104, 179})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool containsKey(int key)
    {
      if (key == 0)
        return this.hasZeroValue;
      return this.keyTable[key & this.mask] == key || this.keyTable[this.hash2(key)] == key || this.keyTable[this.hash3(key)] == key || this.containsKeyStash(key);
    }

    [LineNumberTable(new byte[] {2, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public IntFloatMap(int initialCapacity)
      : this(initialCapacity, 0.8f)
    {
    }

    [LineNumberTable(new byte[] {32, 127, 10, 108, 122, 122, 108, 108, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public IntFloatMap(IntFloatMap map)
      : this(ByteCodeHelper.d2i(Math.floor((double) ((float) map.capacity * map.loadFactor))), map.loadFactor)
    {
      IntFloatMap intFloatMap = this;
      this.stashSize = map.stashSize;
      ByteCodeHelper.arraycopy_primitive_4((Array) map.keyTable, 0, (Array) this.keyTable, 0, map.keyTable.Length);
      ByteCodeHelper.arraycopy_primitive_4((Array) map.valueTable, 0, (Array) this.valueTable, 0, map.valueTable.Length);
      this.size = map.size;
      this.zeroValue = map.zeroValue;
      this.hasZeroValue = map.hasZeroValue;
    }

    [LineNumberTable(new byte[] {109, 127, 1, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void putAll(IntFloatMap map)
    {
      Iterator iterator = map.entries().iterator();
      while (iterator.hasNext())
      {
        IntFloatMap.Entry entry = (IntFloatMap.Entry) iterator.next();
        this.put(entry.key, entry.value);
      }
    }

    [LineNumberTable(315)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float increment(int key, float increment) => this.increment(key, 0.0f, increment);

    [LineNumberTable(new byte[] {160, 247, 99, 107, 103, 110, 167, 105, 107, 105, 105, 110, 162, 104, 107, 105, 105, 110, 162, 104, 107, 105, 105, 110, 162})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float remove(int key, float defaultValue)
    {
      if (key == 0)
      {
        if (!this.hasZeroValue)
          return defaultValue;
        this.hasZeroValue = false;
        --this.size;
        return this.zeroValue;
      }
      int index1 = key & this.mask;
      if (key == this.keyTable[index1])
      {
        this.keyTable[index1] = 0;
        float num = this.valueTable[index1];
        --this.size;
        return num;
      }
      int index2 = this.hash2(key);
      if (key == this.keyTable[index2])
      {
        this.keyTable[index2] = 0;
        float num = this.valueTable[index2];
        --this.size;
        return num;
      }
      int index3 = this.hash3(key);
      if (key != this.keyTable[index3])
        return this.removeStash(key, defaultValue);
      this.keyTable[index3] = 0;
      float num1 = this.valueTable[index3];
      --this.size;
      return num1;
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

    [LineNumberTable(new byte[] {161, 67, 105, 102, 129, 103, 103, 103})]
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

    [LineNumberTable(new byte[] {161, 91, 116, 103, 103, 118, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool containsValue(float value)
    {
      if (this.hasZeroValue && (double) this.zeroValue == (double) value)
        return true;
      int[] keyTable = this.keyTable;
      float[] valueTable = this.valueTable;
      int index = this.capacity + this.stashSize;
      do
      {
        int num = index;
        index += -1;
        if (num <= 0)
          goto label_6;
      }
      while (keyTable[index] == 0 || (double) valueTable[index] != (double) value);
      return true;
label_6:
      return false;
    }

    [LineNumberTable(new byte[] {161, 104, 126, 103, 118, 115})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool containsValue(float value, float epsilon)
    {
      if (this.hasZeroValue && (double) Math.abs(this.zeroValue - value) <= (double) epsilon)
        return true;
      float[] valueTable = this.valueTable;
      int index = this.capacity + this.stashSize;
      do
      {
        int num = index;
        index += -1;
        if (num <= 0)
          goto label_6;
      }
      while ((double) Math.abs(valueTable[index] - value) > (double) epsilon);
      return true;
label_6:
      return false;
    }

    [LineNumberTable(new byte[] {161, 136, 116, 103, 103, 118, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int findKey(float value, int notFound)
    {
      if (this.hasZeroValue && (double) this.zeroValue == (double) value)
        return 0;
      int[] keyTable = this.keyTable;
      float[] valueTable = this.valueTable;
      int index = this.capacity + this.stashSize;
      do
      {
        int num = index;
        index += -1;
        if (num <= 0)
          goto label_6;
      }
      while (keyTable[index] == 0 || (double) valueTable[index] != (double) value);
      return keyTable[index];
label_6:
      return notFound;
    }

    [LineNumberTable(new byte[] {161, 149, 100, 127, 6, 105, 127, 11})]
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

    [LineNumberTable(new byte[] {161, 193, 98, 104, 142, 103, 103, 118, 101, 100, 136, 101, 234, 58, 230, 73})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int hashCode()
    {
      int num1 = 0;
      if (this.hasZeroValue)
        num1 += Float.floatToIntBits(this.zeroValue);
      int[] keyTable = this.keyTable;
      float[] valueTable = this.valueTable;
      int index1 = 0;
      for (int index2 = this.capacity + this.stashSize; index1 < index2; ++index1)
      {
        int num2 = keyTable[index1];
        if (num2 != 0)
          num1 = num1 + num2 * 31 + Float.floatToIntBits(valueTable[index1]);
      }
      return num1;
    }

    [LineNumberTable(new byte[] {161, 212, 107, 106, 103, 112, 112, 118, 130, 103, 103, 118, 101, 100, 112, 117, 101, 232, 58, 233, 73})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool equals(object obj)
    {
      if (object.ReferenceEquals(obj, (object) this))
        return true;
      if (!(obj is IntFloatMap))
        return false;
      IntFloatMap intFloatMap = (IntFloatMap) obj;
      if (intFloatMap.size != this.size || intFloatMap.hasZeroValue != this.hasZeroValue || this.hasZeroValue && (double) intFloatMap.zeroValue != (double) this.zeroValue)
        return false;
      int[] keyTable = this.keyTable;
      float[] valueTable = this.valueTable;
      int index1 = 0;
      for (int index2 = this.capacity + this.stashSize; index1 < index2; ++index1)
      {
        int key = keyTable[index1];
        if (key != 0)
        {
          float num1 = intFloatMap.get(key, 0.0f);
          if ((double) num1 == 0.0 && !intFloatMap.containsKey(key))
            return false;
          float num2 = valueTable[index1];
          if ((double) num1 != (double) num2)
            return false;
        }
      }
      return true;
    }

    [LineNumberTable(new byte[] {161, 235, 110, 104, 105, 103, 103, 99, 104, 108, 143, 104, 101, 102, 105, 105, 106, 162, 104, 101, 102, 108, 105, 105, 106, 98, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toString()
    {
      if (this.size == 0)
        return "{}";
      StringBuilder stringBuilder = new StringBuilder(32);
      stringBuilder.append('{');
      int[] keyTable = this.keyTable;
      float[] valueTable = this.valueTable;
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
      stringBuilder.append('}');
      return stringBuilder.toString();
    }

    [LineNumberTable(new byte[] {162, 40, 104, 108, 140, 109, 107, 108, 108, 135, 107, 108, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual IntFloatMap.Values values()
    {
      if (this.values1 == null)
      {
        this.values1 = new IntFloatMap.Values(this);
        this.values2 = new IntFloatMap.Values(this);
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

    [LineNumberTable(new byte[] {162, 61, 104, 108, 140, 109, 107, 108, 108, 135, 107, 108, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual IntFloatMap.Keys keys()
    {
      if (this.keys1 == null)
      {
        this.keys1 = new IntFloatMap.Keys(this);
        this.keys2 = new IntFloatMap.Keys(this);
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

    [Signature("Larc/struct/IntFloatMap$MapIterator;Ljava/lang/Iterable<Larc/struct/IntFloatMap$Entry;>;Ljava/util/Iterator<Larc/struct/IntFloatMap$Entry;>;")]
    [Implements(new string[] {"java.lang.Iterable", "java.util.Iterator"})]
    public class Entries : IntFloatMap.MapIterator, Iterable, IEnumerable, Iterator
    {
      private IntFloatMap.Entry entry;

      [LineNumberTable(new byte[] {162, 145, 115, 120, 108, 105, 108, 152, 115, 157, 108, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual IntFloatMap.Entry next()
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

      [LineNumberTable(new byte[] {162, 140, 233, 61, 203})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public Entries(IntFloatMap map)
        : base(map)
      {
        IntFloatMap.Entries entries = this;
        this.entry = new IntFloatMap.Entry();
      }

      [LineNumberTable(new byte[] {162, 161, 120})]
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

      [Signature("()Ljava/util/Iterator<Larc/struct/IntFloatMap$Entry;>;")]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual Iterator iterator() => (Iterator) this;

      [LineNumberTable(new byte[] {162, 170, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void remove() => base.remove();

      [Modifiers]
      [LineNumberTable(762)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void reset() => base.reset();

      [Modifiers]
      [EditorBrowsable(EditorBrowsableState.Never)]
      [LineNumberTable(762)]
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

    public class Entry : Object
    {
      public int key;
      public float value;

      [LineNumberTable(703)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public Entry()
      {
      }

      [LineNumberTable(708)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual string toString() => new StringBuilder().append(this.key).append("=").append(this.value).toString();
    }

    public class Keys : IntFloatMap.MapIterator
    {
      [LineNumberTable(new byte[] {162, 208, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public Keys(IntFloatMap map)
        : base(map)
      {
      }

      [Modifiers]
      [LineNumberTable(832)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void reset() => base.reset();

      [LineNumberTable(new byte[] {162, 217, 115, 120, 127, 0, 108, 102})]
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

      [LineNumberTable(new byte[] {162, 212, 120})]
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

      [LineNumberTable(new byte[] {162, 227, 114, 104, 110})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual IntSeq toArray()
      {
        IntSeq intSeq = new IntSeq(true, this.map.size);
        while (this.hasNext)
          intSeq.add(this.next());
        return intSeq;
      }

      [Modifiers]
      [LineNumberTable(832)]
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
    internal class MapIterator : Object
    {
      internal const int INDEX_ILLEGAL = -2;
      internal const int INDEX_ZERO = -1;
      [Modifiers]
      internal IntFloatMap map;
      public bool hasNext;
      internal int nextIndex;
      internal int currentIndex;
      internal bool valid;

      [LineNumberTable(new byte[] {162, 100, 104, 103, 109, 137, 102})]
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

      [LineNumberTable(new byte[] {162, 109, 103, 108, 127, 15, 106, 103, 162})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal virtual void findNextIndex()
      {
        this.hasNext = false;
        int[] keyTable = this.map.keyTable;
        int num1 = this.map.capacity + this.map.stashSize;
        do
        {
          IntFloatMap.MapIterator mapIterator1 = this;
          int num2 = mapIterator1.nextIndex + 1;
          IntFloatMap.MapIterator mapIterator2 = mapIterator1;
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

      [LineNumberTable(new byte[] {162, 94, 8, 167, 103, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public MapIterator([In] IntFloatMap obj0)
      {
        IntFloatMap.MapIterator mapIterator = this;
        this.valid = true;
        this.map = obj0;
        this.reset();
      }

      [LineNumberTable(new byte[] {162, 120, 118, 110, 105, 112, 115, 113, 110, 136, 147, 104, 115})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void remove()
      {
        if (this.currentIndex == -1 && this.map.hasZeroValue)
        {
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
            this.map.keyTable[this.currentIndex] = 0;
        }
        this.currentIndex = -2;
        --this.map.size;
      }
    }

    public class Values : IntFloatMap.MapIterator
    {
      [LineNumberTable(new byte[] {162, 176, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public Values(IntFloatMap map)
        : base(map)
      {
      }

      [Modifiers]
      [LineNumberTable(800)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void reset() => base.reset();

      [LineNumberTable(new byte[] {162, 185, 115, 152, 105, 142, 115, 108, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual float next()
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
        float num = this.nextIndex != -1 ? this.map.valueTable[this.nextIndex] : this.map.zeroValue;
        this.currentIndex = this.nextIndex;
        this.findNextIndex();
        return num;
      }

      [LineNumberTable(new byte[] {162, 180, 120})]
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

      [LineNumberTable(new byte[] {162, 199, 114, 104, 111})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual FloatSeq toArray()
      {
        FloatSeq floatSeq = new FloatSeq(true, this.map.size);
        while (this.hasNext)
          floatSeq.add(this.next());
        return floatSeq;
      }

      [Modifiers]
      [LineNumberTable(800)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void remove() => base.remove();

      [HideFromJava]
      public bool hasNext
      {
        [HideFromJava] get => this.hasNext;
        [HideFromJava] [param: In] set => this.hasNext = value;
      }
    }
  }
}
