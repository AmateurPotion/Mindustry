﻿// Decompiled with JetBrains decompiler
// Type: arc.struct.ObjectIntMap
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
  [Signature("<K:Ljava/lang/Object;>Ljava/lang/Object;Ljava/lang/Iterable<Larc/struct/ObjectIntMap$Entry<TK;>;>;")]
  [Implements(new string[] {"java.lang.Iterable"})]
  public class ObjectIntMap : Object, Iterable, IEnumerable
  {
    private const int PRIME1 = -1105259343;
    private const int PRIME2 = -1262997959;
    private const int PRIME3 = -825114047;
    public int size;
    [Signature("[TK;")]
    internal object[] keyTable;
    internal int[] valueTable;
    internal int capacity;
    internal int stashSize;
    private float loadFactor;
    private int hashShift;
    private int mask;
    private int threshold;
    private int stashCapacity;
    private int pushIterations;
    private ObjectIntMap.Entries entries1;
    private ObjectIntMap.Entries entries2;
    private ObjectIntMap.Values values1;
    private ObjectIntMap.Values values2;
    private ObjectIntMap.Keys keys1;
    private ObjectIntMap.Keys keys2;

    [LineNumberTable(new byte[] {159, 183, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ObjectIntMap()
      : this(51, 0.8f)
    {
    }

    [LineNumberTable(new byte[] {161, 45, 105, 103, 118, 102, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void clear()
    {
      if (this.size == 0)
        return;
      object[] keyTable = this.keyTable;
      int index = this.capacity + this.stashSize;
      while (true)
      {
        int num = index;
        index += -1;
        if (num > 0)
          keyTable[index] = (object) null;
        else
          break;
      }
      this.size = 0;
      this.stashSize = 0;
    }

    [Signature("(TK;II)I")]
    [LineNumberTable(new byte[] {160, 194, 103, 105, 112, 104, 112, 104, 186, 105, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int increment(object key, int defaultValue, int increment)
    {
      int num1 = Object.instancehelper_hashCode(key);
      int index = num1 & this.mask;
      if (!Object.instancehelper_equals(key, this.keyTable[index]))
      {
        index = this.hash2(num1);
        if (!Object.instancehelper_equals(key, this.keyTable[index]))
        {
          index = this.hash3(num1);
          if (!Object.instancehelper_equals(key, this.keyTable[index]))
            return this.getAndIncrementStash(key, defaultValue, increment);
        }
      }
      int num2 = this.valueTable[index];
      this.valueTable[index] = num2 + increment;
      return num2;
    }

    [Signature("()Larc/struct/ObjectIntMap$Keys<TK;>;")]
    [LineNumberTable(new byte[] {162, 3, 104, 108, 140, 109, 107, 108, 108, 135, 107, 108, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual ObjectIntMap.Keys keys()
    {
      if (this.keys1 == null)
      {
        this.keys1 = new ObjectIntMap.Keys(this);
        this.keys2 = new ObjectIntMap.Keys(this);
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

    [Signature("(TK;I)I")]
    [LineNumberTable(new byte[] {160, 162, 103, 105, 112, 104, 112, 104, 185})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int get(object key, int defaultValue)
    {
      int num = Object.instancehelper_hashCode(key);
      int index = num & this.mask;
      if (!Object.instancehelper_equals(key, this.keyTable[index]))
      {
        index = this.hash2(num);
        if (!Object.instancehelper_equals(key, this.keyTable[index]))
        {
          index = this.hash3(num);
          if (!Object.instancehelper_equals(key, this.keyTable[index]))
            return this.getStash(key, defaultValue);
        }
      }
      return this.valueTable[index];
    }

    [Signature("(TK;)I")]
    [LineNumberTable(296)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int increment(object key) => this.increment(key, 0, 1);

    [Signature("()Larc/struct/ObjectIntMap$Entries<TK;>;")]
    [LineNumberTable(new byte[] {161, 217, 104, 108, 140, 109, 107, 108, 108, 135, 107, 108, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual ObjectIntMap.Entries entries()
    {
      if (this.entries1 == null)
      {
        this.entries1 = new ObjectIntMap.Entries(this);
        this.entries2 = new ObjectIntMap.Entries(this);
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

    [Signature("(TK;I)V")]
    [LineNumberTable(new byte[] {37, 115, 167, 103, 105, 100, 105, 105, 161, 105, 102, 106, 106, 161, 105, 102, 106, 106, 193, 121, 108, 106, 225, 61, 232, 72, 99, 100, 105, 127, 15, 161, 100, 101, 106, 127, 15, 161, 100, 101, 106, 127, 15, 161, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void put(object key, int value)
    {
      if (key == null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException("key cannot be null.");
      }
      object[] keyTable = this.keyTable;
      int num1 = Object.instancehelper_hashCode(key);
      int index1 = num1 & this.mask;
      object obj1 = keyTable[index1];
      if (Object.instancehelper_equals(key, obj1))
      {
        this.valueTable[index1] = value;
      }
      else
      {
        int index2 = this.hash2(num1);
        object obj2 = keyTable[index2];
        if (Object.instancehelper_equals(key, obj2))
        {
          this.valueTable[index2] = value;
        }
        else
        {
          int index3 = this.hash3(num1);
          object obj3 = keyTable[index3];
          if (Object.instancehelper_equals(key, obj3))
          {
            this.valueTable[index3] = value;
          }
          else
          {
            int capacity = this.capacity;
            for (int index4 = capacity + this.stashSize; capacity < index4; ++capacity)
            {
              if (Object.instancehelper_equals(key, keyTable[capacity]))
              {
                this.valueTable[capacity] = value;
                return;
              }
            }
            if (obj1 == null)
            {
              keyTable[index1] = key;
              this.valueTable[index1] = value;
              ObjectIntMap objectIntMap1 = this;
              int size = objectIntMap1.size;
              ObjectIntMap objectIntMap2 = objectIntMap1;
              int num2 = size;
              objectIntMap2.size = size + 1;
              int threshold = this.threshold;
              if (num2 < threshold)
                return;
              this.resize(this.capacity << 1);
            }
            else if (obj2 == null)
            {
              keyTable[index2] = key;
              this.valueTable[index2] = value;
              ObjectIntMap objectIntMap1 = this;
              int size = objectIntMap1.size;
              ObjectIntMap objectIntMap2 = objectIntMap1;
              int num2 = size;
              objectIntMap2.size = size + 1;
              int threshold = this.threshold;
              if (num2 < threshold)
                return;
              this.resize(this.capacity << 1);
            }
            else if (obj3 == null)
            {
              keyTable[index3] = key;
              this.valueTable[index3] = value;
              ObjectIntMap objectIntMap1 = this;
              int size = objectIntMap1.size;
              ObjectIntMap objectIntMap2 = objectIntMap1;
              int num2 = size;
              objectIntMap2.size = size + 1;
              int threshold = this.threshold;
              if (num2 < threshold)
                return;
              this.resize(this.capacity << 1);
            }
            else
              this.push(key, value, index1, obj1, index2, obj2, index3, obj3);
          }
        }
      }
    }

    [Signature("(TK;)Z")]
    [LineNumberTable(new byte[] {161, 67, 103, 105, 112, 104, 112, 104, 184})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool containsKey(object key)
    {
      int num = Object.instancehelper_hashCode(key);
      int index1 = num & this.mask;
      if (!Object.instancehelper_equals(key, this.keyTable[index1]))
      {
        int index2 = this.hash2(num);
        if (!Object.instancehelper_equals(key, this.keyTable[index2]))
        {
          int index3 = this.hash3(num);
          if (!Object.instancehelper_equals(key, this.keyTable[index3]))
            return this.containsKeyStash(key);
        }
      }
      return true;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isEmpty() => this.size == 0;

    [LineNumberTable(new byte[] {161, 8, 110, 110, 100, 112, 112, 137})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void removeStashIndex([In] int obj0)
    {
      --this.stashSize;
      int index = this.capacity + this.stashSize;
      if (obj0 >= index)
        return;
      this.keyTable[obj0] = this.keyTable[index];
      this.valueTable[obj0] = this.valueTable[index];
      this.keyTable[index] = (object) null;
    }

    [LineNumberTable(new byte[] {7, 104, 127, 10, 121, 104, 127, 6, 135, 127, 16, 136, 118, 110, 116, 127, 7, 159, 12, 120, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ObjectIntMap(int initialCapacity, float loadFactor)
    {
      ObjectIntMap objectIntMap = this;
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
      this.keyTable = new object[this.capacity + this.stashCapacity];
      this.valueTable = new int[this.keyTable.Length];
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

    [LineNumberTable(new byte[] {161, 110, 142, 103, 117, 105, 111, 127, 2, 159, 2, 103, 135, 115, 147, 103, 103, 103, 100, 104, 102, 16, 232, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void resize([In] int obj0)
    {
      int num = this.capacity + this.stashSize;
      this.capacity = obj0;
      this.threshold = ByteCodeHelper.f2i((float) obj0 * this.loadFactor);
      this.mask = obj0 - 1;
      this.hashShift = 31 - Integer.numberOfTrailingZeros(obj0);
      this.stashCapacity = Math.max(3, ByteCodeHelper.d2i(Math.ceil(Math.log((double) obj0))) * 2);
      this.pushIterations = Math.max(Math.min(obj0, 8), ByteCodeHelper.d2i(Math.sqrt((double) obj0)) / 8);
      object[] keyTable = this.keyTable;
      int[] valueTable = this.valueTable;
      this.keyTable = new object[obj0 + this.stashCapacity];
      this.valueTable = new int[obj0 + this.stashCapacity];
      int size = this.size;
      this.size = 0;
      this.stashSize = 0;
      if (size <= 0)
        return;
      for (int index = 0; index < num; ++index)
      {
        object obj = keyTable[index];
        if (obj != null)
          this.putResize(obj, valueTable[index]);
      }
    }

    [Signature("(TK;IITK;ITK;ITK;)V")]
    [LineNumberTable(new byte[] {160, 72, 103, 103, 231, 69, 170, 151, 100, 101, 100, 100, 130, 100, 102, 101, 101, 130, 100, 102, 101, 229, 69, 105, 102, 101, 100, 101, 101, 127, 15, 161, 106, 102, 100, 102, 102, 127, 15, 161, 106, 102, 100, 102, 102, 127, 15, 161, 139, 100, 100, 133, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void push(
      [In] object obj0,
      [In] int obj1,
      [In] int obj2,
      [In] object obj3,
      [In] int obj4,
      [In] object obj5,
      [In] int obj6,
      [In] object obj7)
    {
      object[] keyTable = this.keyTable;
      int[] valueTable = this.valueTable;
      int mask = this.mask;
      int num1 = 0;
      int pushIterations = this.pushIterations;
      object obj;
      int num2;
      while (true)
      {
        switch (Mathf.random(2))
        {
          case 0:
            obj = obj3;
            num2 = valueTable[obj2];
            keyTable[obj2] = obj0;
            valueTable[obj2] = obj1;
            break;
          case 1:
            obj = obj5;
            num2 = valueTable[obj4];
            keyTable[obj4] = obj0;
            valueTable[obj4] = obj1;
            break;
          default:
            obj = obj7;
            num2 = valueTable[obj6];
            keyTable[obj6] = obj0;
            valueTable[obj6] = obj1;
            break;
        }
        int num3 = Object.instancehelper_hashCode(obj);
        obj2 = num3 & mask;
        obj3 = keyTable[obj2];
        if (obj3 != null)
        {
          obj4 = this.hash2(num3);
          obj5 = keyTable[obj4];
          if (obj5 != null)
          {
            obj6 = this.hash3(num3);
            obj7 = keyTable[obj6];
            if (obj7 != null)
            {
              ++num1;
              if (num1 != pushIterations)
              {
                obj0 = obj;
                obj1 = num2;
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
      keyTable[obj2] = obj;
      valueTable[obj2] = num2;
      ObjectIntMap objectIntMap1 = this;
      int size1 = objectIntMap1.size;
      ObjectIntMap objectIntMap2 = objectIntMap1;
      int num4 = size1;
      objectIntMap2.size = size1 + 1;
      int threshold1 = this.threshold;
      if (num4 < threshold1)
        return;
      this.resize(this.capacity << 1);
      return;
label_10:
      keyTable[obj4] = obj;
      valueTable[obj4] = num2;
      ObjectIntMap objectIntMap3 = this;
      int size2 = objectIntMap3.size;
      ObjectIntMap objectIntMap4 = objectIntMap3;
      int num5 = size2;
      objectIntMap4.size = size2 + 1;
      int threshold2 = this.threshold;
      if (num5 < threshold2)
        return;
      this.resize(this.capacity << 1);
      return;
label_14:
      keyTable[obj6] = obj;
      valueTable[obj6] = num2;
      ObjectIntMap objectIntMap5 = this;
      int size3 = objectIntMap5.size;
      ObjectIntMap objectIntMap6 = objectIntMap5;
      int num6 = size3;
      objectIntMap6.size = size3 + 1;
      int threshold3 = this.threshold;
      if (num6 < threshold3)
        return;
      this.resize(this.capacity << 1);
      return;
label_19:
      this.putStash(obj, num2);
    }

    [Signature("(TK;I)V")]
    [LineNumberTable(new byte[] {160, 142, 142, 110, 104, 161, 110, 105, 105, 110, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void putStash([In] object obj0, [In] int obj1)
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

    [Signature("(TK;I)V")]
    [LineNumberTable(new byte[] {104, 103, 105, 105, 99, 105, 105, 127, 12, 161, 105, 107, 100, 106, 106, 127, 12, 161, 105, 107, 100, 106, 106, 127, 12, 161, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void putResize([In] object obj0, [In] int obj1)
    {
      int num1 = Object.instancehelper_hashCode(obj0);
      int index1 = num1 & this.mask;
      object obj2 = this.keyTable[index1];
      if (obj2 == null)
      {
        this.keyTable[index1] = obj0;
        this.valueTable[index1] = obj1;
        ObjectIntMap objectIntMap1 = this;
        int size = objectIntMap1.size;
        ObjectIntMap objectIntMap2 = objectIntMap1;
        int num2 = size;
        objectIntMap2.size = size + 1;
        int threshold = this.threshold;
        if (num2 < threshold)
          return;
        this.resize(this.capacity << 1);
      }
      else
      {
        int index2 = this.hash2(num1);
        object obj3 = this.keyTable[index2];
        if (obj3 == null)
        {
          this.keyTable[index2] = obj0;
          this.valueTable[index2] = obj1;
          ObjectIntMap objectIntMap1 = this;
          int size = objectIntMap1.size;
          ObjectIntMap objectIntMap2 = objectIntMap1;
          int num2 = size;
          objectIntMap2.size = size + 1;
          int threshold = this.threshold;
          if (num2 < threshold)
            return;
          this.resize(this.capacity << 1);
        }
        else
        {
          int index3 = this.hash3(num1);
          object obj4 = this.keyTable[index3];
          if (obj4 == null)
          {
            this.keyTable[index3] = obj0;
            this.valueTable[index3] = obj1;
            ObjectIntMap objectIntMap1 = this;
            int size = objectIntMap1.size;
            ObjectIntMap objectIntMap2 = objectIntMap1;
            int num2 = size;
            objectIntMap2.size = size + 1;
            int threshold = this.threshold;
            if (num2 < threshold)
              return;
            this.resize(this.capacity << 1);
          }
          else
            this.push(obj0, obj1, index1, obj2, index2, obj3, index3, obj4);
        }
      }
    }

    [Signature("(TK;I)I")]
    [LineNumberTable(new byte[] {160, 175, 103, 116, 52, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private int getStash([In] object obj0, [In] int obj1)
    {
      object[] keyTable = this.keyTable;
      int capacity = this.capacity;
      for (int index = capacity + this.stashSize; capacity < index; ++capacity)
      {
        if (Object.instancehelper_equals(obj0, keyTable[capacity]))
          return this.valueTable[capacity];
      }
      return obj1;
    }

    [Signature("(TK;II)I")]
    [LineNumberTable(new byte[] {160, 209, 103, 116, 107, 105, 107, 226, 60, 230, 70, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private int getAndIncrementStash([In] object obj0, [In] int obj1, [In] int obj2)
    {
      object[] keyTable = this.keyTable;
      int capacity = this.capacity;
      for (int index = capacity + this.stashSize; capacity < index; ++capacity)
      {
        if (Object.instancehelper_equals(obj0, keyTable[capacity]))
        {
          int num = this.valueTable[capacity];
          this.valueTable[capacity] = num + obj2;
          return num;
        }
      }
      this.put(obj0, obj1 + obj2);
      return obj1;
    }

    [Signature("(TK;I)I")]
    [LineNumberTable(new byte[] {160, 250, 103, 116, 107, 105, 103, 110, 226, 59, 230, 72})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual int removeStash([In] object obj0, [In] int obj1)
    {
      object[] keyTable = this.keyTable;
      int capacity = this.capacity;
      for (int index = capacity + this.stashSize; capacity < index; ++capacity)
      {
        if (Object.instancehelper_equals(obj0, keyTable[capacity]))
        {
          int num = this.valueTable[capacity];
          this.removeStashIndex(capacity);
          --this.size;
          return num;
        }
      }
      return obj1;
    }

    [Signature("(TK;)Z")]
    [LineNumberTable(new byte[] {161, 80, 103, 116, 45, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool containsKeyStash([In] object obj0)
    {
      object[] keyTable = this.keyTable;
      int capacity = this.capacity;
      for (int index = capacity + this.stashSize; capacity < index; ++capacity)
      {
        if (Object.instancehelper_equals(obj0, keyTable[capacity]))
          return true;
      }
      return false;
    }

    [Signature("()Larc/struct/ObjectIntMap$Entries<TK;>;")]
    [LineNumberTable(579)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual ObjectIntMap.Entries iterator() => this.entries();

    [LineNumberTable(new byte[] {159, 191, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ObjectIntMap(int initialCapacity)
      : this(initialCapacity, 0.8f)
    {
    }

    [Signature("(Larc/struct/ObjectIntMap<+TK;>;)V")]
    [LineNumberTable(new byte[] {29, 127, 10, 108, 122, 122, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ObjectIntMap(ObjectIntMap map)
      : this(ByteCodeHelper.d2i(Math.floor((double) ((float) map.capacity * map.loadFactor))), map.loadFactor)
    {
      ObjectIntMap objectIntMap = this;
      this.stashSize = map.stashSize;
      ByteCodeHelper.arraycopy((object) map.keyTable, 0, (object) this.keyTable, 0, map.keyTable.Length);
      ByteCodeHelper.arraycopy_primitive_4((Array) map.valueTable, 0, (Array) this.valueTable, 0, map.valueTable.Length);
      this.size = map.size;
    }

    [Signature("(Larc/struct/ObjectIntMap<+TK;>;)V")]
    [LineNumberTable(new byte[] {97, 127, 1, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void putAll(ObjectIntMap map)
    {
      ObjectIntMap.Entries entries = map.entries().iterator();
      while (((Iterator) entries).hasNext())
      {
        ObjectIntMap.Entry entry = (ObjectIntMap.Entry) ((Iterator) entries).next();
        this.put(entry.key, entry.value);
      }
    }

    [Signature("(TK;)I")]
    [LineNumberTable(271)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int get(object key) => this.get(key, 0);

    [Signature("(TK;I)I")]
    [LineNumberTable(300)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int increment(object key, int amount) => this.increment(key, 0, amount);

    [Signature("(TK;I)I")]
    [LineNumberTable(new byte[] {160, 221, 103, 105, 112, 105, 105, 110, 162, 104, 112, 105, 105, 110, 162, 104, 112, 105, 105, 110, 162})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int remove(object key, int defaultValue)
    {
      int num1 = Object.instancehelper_hashCode(key);
      int index1 = num1 & this.mask;
      if (Object.instancehelper_equals(key, this.keyTable[index1]))
      {
        this.keyTable[index1] = (object) null;
        int num2 = this.valueTable[index1];
        --this.size;
        return num2;
      }
      int index2 = this.hash2(num1);
      if (Object.instancehelper_equals(key, this.keyTable[index2]))
      {
        this.keyTable[index2] = (object) null;
        int num2 = this.valueTable[index2];
        --this.size;
        return num2;
      }
      int index3 = this.hash3(num1);
      if (!Object.instancehelper_equals(key, this.keyTable[index3]))
        return this.removeStash(key, defaultValue);
      this.keyTable[index3] = (object) null;
      int num3 = this.valueTable[index3];
      --this.size;
      return num3;
    }

    [LineNumberTable(new byte[] {161, 27, 127, 10, 113, 106, 104, 103})]
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

    [LineNumberTable(new byte[] {161, 36, 105, 102, 129, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void clear(int maximumCapacity)
    {
      if (this.capacity <= maximumCapacity)
      {
        this.clear();
      }
      else
      {
        this.size = 0;
        this.resize(maximumCapacity);
      }
    }

    [LineNumberTable(new byte[] {161, 58, 103, 103, 118, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool containsValue(int value)
    {
      object[] keyTable = this.keyTable;
      int[] valueTable = this.valueTable;
      int index = this.capacity + this.stashSize;
      do
      {
        int num = index;
        index += -1;
        if (num <= 0)
          goto label_4;
      }
      while (keyTable[index] == null || valueTable[index] != value);
      return true;
label_4:
      return false;
    }

    [Signature("(I)TK;")]
    [LineNumberTable(new byte[] {161, 91, 103, 103, 118, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object findKey(int value)
    {
      object[] keyTable = this.keyTable;
      int[] valueTable = this.valueTable;
      int index = this.capacity + this.stashSize;
      do
      {
        int num = index;
        index += -1;
        if (num <= 0)
          goto label_4;
      }
      while (keyTable[index] == null || valueTable[index] != value);
      return keyTable[index];
label_4:
      return (object) null;
    }

    [LineNumberTable(new byte[] {161, 103, 100, 127, 6, 105, 127, 11})]
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

    [LineNumberTable(new byte[] {161, 147, 98, 103, 103, 118, 101, 100, 141, 101, 229, 58, 230, 73})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int hashCode()
    {
      int num = 0;
      object[] keyTable = this.keyTable;
      int[] valueTable = this.valueTable;
      int index1 = 0;
      for (int index2 = this.capacity + this.stashSize; index1 < index2; ++index1)
      {
        object obj = keyTable[index1];
        if (obj != null)
          num = num + Object.instancehelper_hashCode(obj) * 31 + valueTable[index1];
      }
      return num;
    }

    [LineNumberTable(new byte[] {161, 163, 107, 106, 103, 112, 103, 103, 118, 101, 100, 107, 112, 101, 232, 58, 230, 73})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool equals(object obj)
    {
      if (object.ReferenceEquals(obj, (object) this))
        return true;
      if (!(obj is ObjectIntMap))
        return false;
      ObjectIntMap objectIntMap = (ObjectIntMap) obj;
      if (objectIntMap.size != this.size)
        return false;
      object[] keyTable = this.keyTable;
      int[] valueTable = this.valueTable;
      int index1 = 0;
      for (int index2 = this.capacity + this.stashSize; index1 < index2; ++index1)
      {
        object key = keyTable[index1];
        if (key != null)
        {
          int num1 = objectIntMap.get(key, 0);
          if (num1 == 0 && !objectIntMap.containsKey(key))
            return false;
          int num2 = valueTable[index1];
          if (num1 != num2)
            return false;
        }
      }
      return true;
    }

    [LineNumberTable(new byte[] {161, 182, 110, 104, 105, 103, 103, 99, 104, 101, 102, 105, 105, 106, 130, 104, 101, 102, 108, 105, 105, 106, 98, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toString()
    {
      if (this.size == 0)
        return "{}";
      StringBuilder stringBuilder = new StringBuilder(32);
      stringBuilder.append('{');
      object[] keyTable = this.keyTable;
      int[] valueTable = this.valueTable;
      int length = keyTable.Length;
      object obj1;
      do
      {
        int num = length;
        length += -1;
        if (num > 0)
          obj1 = keyTable[length];
        else
          goto label_6;
      }
      while (obj1 == null);
      stringBuilder.append(obj1);
      stringBuilder.append('=');
      stringBuilder.append(valueTable[length]);
label_6:
      while (true)
      {
        object obj2;
        do
        {
          int num = length;
          length += -1;
          if (num > 0)
            obj2 = keyTable[length];
          else
            goto label_9;
        }
        while (obj2 == null);
        stringBuilder.append(", ");
        stringBuilder.append(obj2);
        stringBuilder.append('=');
        stringBuilder.append(valueTable[length]);
      }
label_9:
      stringBuilder.append('}');
      return stringBuilder.toString();
    }

    [LineNumberTable(new byte[] {161, 238, 104, 108, 140, 109, 107, 108, 108, 135, 107, 108, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual ObjectIntMap.Values values()
    {
      if (this.values1 == null)
      {
        this.values1 = new ObjectIntMap.Values(this);
        this.values2 = new ObjectIntMap.Values(this);
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

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(18)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Iterator \u003Cbridge\u003Eiterator() => (Iterator) this.iterator();

    [HideFromJava]
    public virtual void forEach([In] Consumer obj0) => Iterable.\u003Cdefault\u003EforEach((Iterable) this, obj0);

    [HideFromJava]
    public virtual Spliterator spliterator() => Iterable.\u003Cdefault\u003Espliterator((Iterable) this);

    [HideFromJava]
    [SpecialName]
    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) new IterableEnumerator((Iterable) this);

    Iterator Iterable.__\u003Coverridestub\u003Ejava\u002Elang\u002EIterable\u003A\u003Aiterator() => this.\u003Cbridge\u003Eiterator();

    [Signature("<K:Ljava/lang/Object;>Larc/struct/ObjectIntMap$MapIterator<TK;>;Ljava/lang/Iterable<Larc/struct/ObjectIntMap$Entry<TK;>;>;Ljava/util/Iterator<Larc/struct/ObjectIntMap$Entry<TK;>;>;")]
    [Implements(new string[] {"java.lang.Iterable", "java.util.Iterator"})]
    public class Entries : ObjectIntMap.MapIterator, Iterable, IEnumerable, Iterator
    {
      [Signature("Larc/struct/ObjectIntMap$Entry<TK;>;")]
      private ObjectIntMap.Entry entry;

      [Signature("()Larc/struct/Seq<Larc/struct/ObjectIntMap$Entry<TK;>;>;")]
      [LineNumberTable(new byte[] {162, 78, 102, 123, 102, 108, 108, 103, 98})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual Seq toArray()
      {
        Seq seq = new Seq();
        ObjectIntMap.Entries entries = this.iterator();
        while (((Iterator) entries).hasNext())
        {
          ObjectIntMap.Entry entry = (ObjectIntMap.Entry) ((Iterator) entries).next();
          seq.add((object) new ObjectIntMap.Entry()
          {
            key = entry.key,
            value = entry.value
          });
        }
        return seq;
      }

      [Signature("()Larc/struct/ObjectIntMap$Entries<TK;>;")]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual ObjectIntMap.Entries iterator() => this;

      [Signature("()Larc/struct/ObjectIntMap$Entry<TK;>;")]
      [LineNumberTable(new byte[] {162, 90, 115, 120, 108, 115, 125, 108, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual ObjectIntMap.Entry next()
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
        this.entry.key = this.map.keyTable[this.nextIndex];
        this.entry.value = this.map.valueTable[this.nextIndex];
        this.currentIndex = this.nextIndex;
        this.findNextIndex();
        return this.entry;
      }

      [Signature("(Larc/struct/ObjectIntMap<TK;>;)V")]
      [LineNumberTable(new byte[] {162, 74, 233, 61, 203})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public Entries(ObjectIntMap map)
        : base(map)
      {
        ObjectIntMap.Entries entries = this;
        this.entry = new ObjectIntMap.Entry();
      }

      [LineNumberTable(new byte[] {162, 101, 120})]
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

      [LineNumberTable(new byte[] {162, 110, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void remove() => base.remove();

      [Modifiers]
      [LineNumberTable(696)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void reset() => base.reset();

      [Modifiers]
      [EditorBrowsable(EditorBrowsableState.Never)]
      [LineNumberTable(696)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual Iterator \u003Cbridge\u003Eiterator() => (Iterator) this.iterator();

      [Modifiers]
      [EditorBrowsable(EditorBrowsableState.Never)]
      [LineNumberTable(696)]
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

      Iterator Iterable.__\u003Coverridestub\u003Ejava\u002Elang\u002EIterable\u003A\u003Aiterator() => this.\u003Cbridge\u003Eiterator();

      object Iterator.__\u003Coverridestub\u003Ejava\u002Eutil\u002EIterator\u003A\u003Anext() => this.\u003Cbridge\u003Enext();

      [HideFromJava]
      public bool hasNext
      {
        [HideFromJava] get => this.hasNext;
        [HideFromJava] [param: In] set => this.hasNext = value;
      }
    }

    [Signature("<K:Ljava/lang/Object;>Ljava/lang/Object;")]
    public class Entry : Object
    {
      [Signature("TK;")]
      public object key;
      public int value;

      [LineNumberTable(645)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public Entry()
      {
      }

      [LineNumberTable(650)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual string toString() => new StringBuilder().append(this.key).append("=").append(this.value).toString();
    }

    [Signature("<K:Ljava/lang/Object;>Larc/struct/ObjectIntMap$MapIterator<TK;>;Ljava/lang/Iterable<TK;>;Ljava/util/Iterator<TK;>;")]
    [Implements(new string[] {"java.lang.Iterable", "java.util.Iterator"})]
    public class Keys : ObjectIntMap.MapIterator, Iterable, IEnumerable, Iterator
    {
      [Signature("()Larc/struct/ObjectIntMap$Keys<TK;>;")]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual ObjectIntMap.Keys iterator() => this;

      [Signature("(Larc/struct/ObjectIntMap<TK;>;)V")]
      [LineNumberTable(new byte[] {162, 144, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public Keys(ObjectIntMap map)
        : base(map)
      {
      }

      [Modifiers]
      [LineNumberTable(768)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void reset() => base.reset();

      [Signature("()TK;")]
      [LineNumberTable(new byte[] {162, 153, 115, 120, 115, 108, 102})]
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
        object obj = this.map.keyTable[this.nextIndex];
        this.currentIndex = this.nextIndex;
        this.findNextIndex();
        return obj;
      }

      [LineNumberTable(new byte[] {162, 148, 120})]
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

      [Signature("()Larc/struct/Seq<TK;>;")]
      [LineNumberTable(new byte[] {162, 167, 114, 104, 110})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual Seq toArray()
      {
        Seq seq = new Seq(true, this.map.size);
        while (this.hasNext)
          seq.add(this.next());
        return seq;
      }

      [Signature("(Larc/struct/Seq<TK;>;)Larc/struct/Seq<TK;>;")]
      [LineNumberTable(new byte[] {162, 175, 104, 110})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual Seq toArray(Seq array)
      {
        while (this.hasNext)
          array.add(this.next());
        return array;
      }

      [LineNumberTable(new byte[] {162, 181, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void remove() => base.remove();

      [Modifiers]
      [EditorBrowsable(EditorBrowsableState.Never)]
      [LineNumberTable(768)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual Iterator \u003Cbridge\u003Eiterator() => (Iterator) this.iterator();

      [HideFromJava]
      public virtual void forEach([In] Consumer obj0) => Iterable.\u003Cdefault\u003EforEach((Iterable) this, obj0);

      [HideFromJava]
      public virtual Spliterator spliterator() => Iterable.\u003Cdefault\u003Espliterator((Iterable) this);

      [HideFromJava]
      public virtual void forEachRemaining([In] Consumer obj0) => Iterator.\u003Cdefault\u003EforEachRemaining((Iterator) this, obj0);

      [HideFromJava]
      [SpecialName]
      IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) new IterableEnumerator((Iterable) this);

      Iterator Iterable.__\u003Coverridestub\u003Ejava\u002Elang\u002EIterable\u003A\u003Aiterator() => this.\u003Cbridge\u003Eiterator();

      [HideFromJava]
      public bool hasNext
      {
        [HideFromJava] get => this.hasNext;
        [HideFromJava] [param: In] set => this.hasNext = value;
      }
    }

    [InnerClass]
    [Signature("<K:Ljava/lang/Object;>Ljava/lang/Object;")]
    internal class MapIterator : Object
    {
      [Modifiers]
      [Signature("Larc/struct/ObjectIntMap<TK;>;")]
      internal ObjectIntMap map;
      public bool hasNext;
      internal int nextIndex;
      internal int currentIndex;
      internal bool valid;

      [LineNumberTable(new byte[] {162, 40, 103, 103, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void reset()
      {
        this.currentIndex = -1;
        this.nextIndex = -1;
        this.findNextIndex();
      }

      [LineNumberTable(new byte[] {162, 46, 103, 108, 127, 15, 106, 103, 162})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal virtual void findNextIndex()
      {
        this.hasNext = false;
        object[] keyTable = this.map.keyTable;
        int num1 = this.map.capacity + this.map.stashSize;
        do
        {
          ObjectIntMap.MapIterator mapIterator1 = this;
          int num2 = mapIterator1.nextIndex + 1;
          ObjectIntMap.MapIterator mapIterator2 = mapIterator1;
          int num3 = num2;
          mapIterator2.nextIndex = num2;
          int num4 = num1;
          if (num3 >= num4)
            goto label_4;
        }
        while (keyTable[this.nextIndex] == null);
        goto label_3;
label_4:
        return;
label_3:
        this.hasNext = true;
      }

      [Signature("(Larc/struct/ObjectIntMap<TK;>;)V")]
      [LineNumberTable(new byte[] {162, 34, 8, 167, 103, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public MapIterator([In] ObjectIntMap obj0)
      {
        ObjectIntMap.MapIterator mapIterator = this;
        this.valid = true;
        this.map = obj0;
        this.reset();
      }

      [LineNumberTable(new byte[] {162, 57, 121, 115, 113, 110, 136, 147, 103, 115})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void remove()
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
          this.map.keyTable[this.currentIndex] = (object) null;
        this.currentIndex = -1;
        --this.map.size;
      }
    }

    [Signature("Larc/struct/ObjectIntMap$MapIterator<Ljava/lang/Object;>;")]
    public class Values : ObjectIntMap.MapIterator
    {
      [Signature("(Larc/struct/ObjectIntMap<*>;)V")]
      [LineNumberTable(new byte[] {162, 116, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public Values(ObjectIntMap map)
        : base(map)
      {
      }

      [Modifiers]
      [LineNumberTable(740)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void reset() => base.reset();

      [LineNumberTable(new byte[] {162, 125, 115, 120, 115, 108, 102})]
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
        int num = this.map.valueTable[this.nextIndex];
        this.currentIndex = this.nextIndex;
        this.findNextIndex();
        return num;
      }

      [LineNumberTable(new byte[] {162, 120, 120})]
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

      [LineNumberTable(new byte[] {162, 135, 114, 104, 110})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual IntSeq toArray()
      {
        IntSeq intSeq = new IntSeq(true, this.map.size);
        while (this.hasNext)
          intSeq.add(this.next());
        return intSeq;
      }

      [Modifiers]
      [LineNumberTable(740)]
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
