// Decompiled with JetBrains decompiler
// Type: arc.struct.ObjectMap
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
  [Signature("<K:Ljava/lang/Object;V:Ljava/lang/Object;>Ljava/lang/Object;Ljava/lang/Iterable<Larc/struct/ObjectMap$Entry<TK;TV;>;>;")]
  [Implements(new string[] {"java.lang.Iterable"})]
  public class ObjectMap : Object, Iterable, IEnumerable
  {
    private const int PRIME1 = -1105259343;
    private const int PRIME2 = -1262997959;
    private const int PRIME3 = -825114047;
    public int size;
    [Signature("[TK;")]
    internal object[] keyTable;
    [Signature("[TV;")]
    internal object[] valueTable;
    internal int capacity;
    internal int stashSize;
    private float loadFactor;
    private int hashShift;
    private int mask;
    private int threshold;
    private int stashCapacity;
    private int pushIterations;
    internal ObjectMap.Entries entries1;
    internal ObjectMap.Entries entries2;
    internal ObjectMap.Values values1;
    internal ObjectMap.Values values2;
    internal ObjectMap.Keys keys1;
    internal ObjectMap.Keys keys2;

    [Signature("()Larc/struct/ObjectMap$Values<TV;>;")]
    [LineNumberTable(new byte[] {162, 64, 104, 108, 140, 109, 107, 108, 108, 135, 107, 108, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual ObjectMap.Values values()
    {
      if (this.values1 == null)
      {
        this.values1 = new ObjectMap.Values(this);
        this.values2 = new ObjectMap.Values(this);
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

    [LineNumberTable(new byte[] {6, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ObjectMap()
      : this(51, 0.8f)
    {
    }

    [Signature("(TK;TV;)TV;")]
    [LineNumberTable(new byte[] {66, 115, 167, 103, 105, 100, 105, 106, 105, 163, 105, 102, 106, 107, 106, 163, 105, 102, 106, 107, 106, 195, 121, 108, 107, 106, 227, 60, 232, 73, 99, 100, 105, 127, 15, 162, 100, 101, 106, 127, 15, 162, 100, 101, 106, 127, 15, 162, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object put(object key, object value)
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
        object obj2 = this.valueTable[index1];
        this.valueTable[index1] = value;
        return obj2;
      }
      int index2 = this.hash2(num1);
      object obj3 = keyTable[index2];
      if (Object.instancehelper_equals(key, obj3))
      {
        object obj2 = this.valueTable[index2];
        this.valueTable[index2] = value;
        return obj2;
      }
      int index3 = this.hash3(num1);
      object obj4 = keyTable[index3];
      if (Object.instancehelper_equals(key, obj4))
      {
        object obj2 = this.valueTable[index3];
        this.valueTable[index3] = value;
        return obj2;
      }
      int capacity = this.capacity;
      for (int index4 = capacity + this.stashSize; capacity < index4; ++capacity)
      {
        if (Object.instancehelper_equals(key, keyTable[capacity]))
        {
          object obj2 = this.valueTable[capacity];
          this.valueTable[capacity] = value;
          return obj2;
        }
      }
      if (obj1 == null)
      {
        keyTable[index1] = key;
        this.valueTable[index1] = value;
        ObjectMap objectMap1 = this;
        int size = objectMap1.size;
        ObjectMap objectMap2 = objectMap1;
        int num2 = size;
        objectMap2.size = size + 1;
        int threshold = this.threshold;
        if (num2 >= threshold)
          this.resize(this.capacity << 1);
        return (object) null;
      }
      if (obj3 == null)
      {
        keyTable[index2] = key;
        this.valueTable[index2] = value;
        ObjectMap objectMap1 = this;
        int size = objectMap1.size;
        ObjectMap objectMap2 = objectMap1;
        int num2 = size;
        objectMap2.size = size + 1;
        int threshold = this.threshold;
        if (num2 >= threshold)
          this.resize(this.capacity << 1);
        return (object) null;
      }
      if (obj4 == null)
      {
        keyTable[index3] = key;
        this.valueTable[index3] = value;
        ObjectMap objectMap1 = this;
        int size = objectMap1.size;
        ObjectMap objectMap2 = objectMap1;
        int num2 = size;
        objectMap2.size = size + 1;
        int threshold = this.threshold;
        if (num2 >= threshold)
          this.resize(this.capacity << 1);
        return (object) null;
      }
      this.push(key, value, index1, obj1, index2, obj3, index3, obj4);
      return (object) null;
    }

    [Signature("(TK;)TV;")]
    [LineNumberTable(new byte[] {160, 220, 103, 105, 112, 104, 112, 104, 185})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object get(object key)
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
            return this.getStash(key, (object) null);
        }
      }
      return this.valueTable[index];
    }

    [Signature("(Larc/func/Cons2<TK;TV;>;)V")]
    [LineNumberTable(new byte[] {53, 127, 1, 114, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void each(Cons2 cons)
    {
      ObjectMap.Entries entries = this.entries().iterator();
      while (((Iterator) entries).hasNext())
      {
        ObjectMap.Entry entry = (ObjectMap.Entry) ((Iterator) entries).next();
        cons.get(entry.key, entry.value);
      }
    }

    [Signature("(TK;Larc/func/Prov<TV;>;)TV;")]
    [LineNumberTable(new byte[] {160, 206, 104, 99, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object get(object key, Prov supplier)
    {
      object obj = this.get(key);
      if (obj == null)
        this.put(key, obj = supplier.get());
      return obj;
    }

    [Signature("(TK;)Z")]
    [LineNumberTable(new byte[] {161, 127, 103, 105, 112, 104, 112, 104, 184})]
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

    [Signature("(TK;)TV;")]
    [LineNumberTable(new byte[] {160, 255, 103, 105, 112, 105, 105, 105, 110, 162, 104, 112, 105, 105, 105, 110, 162, 104, 112, 105, 105, 105, 110, 162})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object remove(object key)
    {
      int num = Object.instancehelper_hashCode(key);
      int index1 = num & this.mask;
      if (Object.instancehelper_equals(key, this.keyTable[index1]))
      {
        this.keyTable[index1] = (object) null;
        object obj = this.valueTable[index1];
        this.valueTable[index1] = (object) null;
        --this.size;
        return obj;
      }
      int index2 = this.hash2(num);
      if (Object.instancehelper_equals(key, this.keyTable[index2]))
      {
        this.keyTable[index2] = (object) null;
        object obj = this.valueTable[index2];
        this.valueTable[index2] = (object) null;
        --this.size;
        return obj;
      }
      int index3 = this.hash3(num);
      if (!Object.instancehelper_equals(key, this.keyTable[index3]))
        return this.removeStash(key);
      this.keyTable[index3] = (object) null;
      object obj1 = this.valueTable[index3];
      this.valueTable[index3] = (object) null;
      --this.size;
      return obj1;
    }

    [LineNumberTable(new byte[] {161, 93, 105, 103, 103, 118, 100, 134, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void clear()
    {
      if (this.size == 0)
        return;
      object[] keyTable = this.keyTable;
      object[] valueTable = this.valueTable;
      int index = this.capacity + this.stashSize;
      while (true)
      {
        int num = index;
        index += -1;
        if (num > 0)
        {
          keyTable[index] = (object) null;
          valueTable[index] = (object) null;
        }
        else
          break;
      }
      this.size = 0;
      this.stashSize = 0;
    }

    [Signature("(TK;TV;)TV;")]
    [LineNumberTable(new byte[] {160, 234, 103, 105, 112, 104, 112, 104, 185})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object get(object key, object defaultValue)
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

    [Signature("(TK;Larc/func/Prov<+Ljava/lang/RuntimeException;>;)TV;")]
    [LineNumberTable(new byte[] {160, 198, 105, 145})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object getThrow(object key, Prov error) => this.containsKey(key) ? this.get(key) : throw Throwable.__\u003Cunmap\u003E((Exception) error.get());

    [Signature("(Larc/struct/ObjectMap<+TK;+TV;>;)V")]
    [LineNumberTable(new byte[] {160, 67, 108, 123, 117})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void putAll(ObjectMap map)
    {
      this.ensureCapacity(map.size);
      ObjectMap.Entries entries = map.iterator();
      while (((Iterator) entries).hasNext())
      {
        ObjectMap.Entry entry = (ObjectMap.Entry) ((Iterator) entries).next();
        this.put(entry.key, entry.value);
      }
    }

    [Signature("()Larc/struct/ObjectMap$Entries<TK;TV;>;")]
    [LineNumberTable(new byte[] {162, 43, 104, 108, 140, 109, 107, 108, 108, 135, 107, 108, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual ObjectMap.Entries entries()
    {
      if (this.entries1 == null)
      {
        this.entries1 = new ObjectMap.Entries(this);
        this.entries2 = new ObjectMap.Entries(this);
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

    [Signature("()Larc/struct/ObjectMap$Entries<TK;TV;>;")]
    [LineNumberTable(661)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual ObjectMap.Entries iterator() => this.entries();

    [Signature("<K:Ljava/lang/Object;V:Ljava/lang/Object;>([Ljava/lang/Object;)Larc/struct/ObjectMap<TK;TV;>;")]
    [LineNumberTable(new byte[] {159, 187, 134, 105, 51, 198})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static ObjectMap of(params object[] values)
    {
      ObjectMap objectMap = new ObjectMap();
      for (int index = 0; index < values.Length / 2; ++index)
        objectMap.put(values[index * 2], values[index * 2 + 1]);
      return objectMap;
    }

    [Signature("(Larc/struct/ObjectMap<+TK;+TV;>;)Larc/struct/ObjectMap<TK;TV;>;")]
    [LineNumberTable(new byte[] {160, 74, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual ObjectMap merge(ObjectMap map)
    {
      this.putAll(map);
      return this;
    }

    [LineNumberTable(new byte[] {22, 104, 127, 10, 121, 104, 127, 6, 135, 127, 16, 136, 118, 110, 116, 127, 7, 159, 12, 120, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ObjectMap(int initialCapacity, float loadFactor)
    {
      ObjectMap objectMap = this;
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

    [LineNumberTable(new byte[] {161, 180, 142, 103, 117, 105, 111, 127, 2, 159, 2, 103, 135, 115, 147, 103, 103, 103, 100, 104, 102, 16, 232, 69})]
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
      object[] valueTable = this.valueTable;
      this.keyTable = new object[obj0 + this.stashCapacity];
      this.valueTable = new object[obj0 + this.stashCapacity];
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

    [Signature("(TK;TV;ITK;ITK;ITK;)V")]
    [LineNumberTable(new byte[] {160, 113, 103, 103, 231, 69, 170, 151, 100, 101, 100, 100, 130, 100, 102, 101, 101, 130, 100, 102, 101, 229, 69, 105, 102, 101, 100, 101, 101, 127, 15, 161, 106, 102, 100, 102, 102, 127, 15, 161, 106, 102, 100, 102, 102, 127, 15, 161, 139, 100, 100, 133, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void push(
      [In] object obj0,
      [In] object obj1,
      [In] int obj2,
      [In] object obj3,
      [In] int obj4,
      [In] object obj5,
      [In] int obj6,
      [In] object obj7)
    {
      object[] keyTable = this.keyTable;
      object[] valueTable = this.valueTable;
      int mask = this.mask;
      int num1 = 0;
      int pushIterations = this.pushIterations;
      object obj8;
      object obj9;
      while (true)
      {
        switch (Mathf.random(2))
        {
          case 0:
            obj8 = obj3;
            obj9 = valueTable[obj2];
            keyTable[obj2] = obj0;
            valueTable[obj2] = obj1;
            break;
          case 1:
            obj8 = obj5;
            obj9 = valueTable[obj4];
            keyTable[obj4] = obj0;
            valueTable[obj4] = obj1;
            break;
          default:
            obj8 = obj7;
            obj9 = valueTable[obj6];
            keyTable[obj6] = obj0;
            valueTable[obj6] = obj1;
            break;
        }
        int num2 = Object.instancehelper_hashCode(obj8);
        obj2 = num2 & mask;
        obj3 = keyTable[obj2];
        if (obj3 != null)
        {
          obj4 = this.hash2(num2);
          obj5 = keyTable[obj4];
          if (obj5 != null)
          {
            obj6 = this.hash3(num2);
            obj7 = keyTable[obj6];
            if (obj7 != null)
            {
              ++num1;
              if (num1 != pushIterations)
              {
                obj0 = obj8;
                obj1 = obj9;
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
      keyTable[obj2] = obj8;
      valueTable[obj2] = obj9;
      ObjectMap objectMap1 = this;
      int size1 = objectMap1.size;
      ObjectMap objectMap2 = objectMap1;
      int num3 = size1;
      objectMap2.size = size1 + 1;
      int threshold1 = this.threshold;
      if (num3 < threshold1)
        return;
      this.resize(this.capacity << 1);
      return;
label_10:
      keyTable[obj4] = obj8;
      valueTable[obj4] = obj9;
      ObjectMap objectMap3 = this;
      int size2 = objectMap3.size;
      ObjectMap objectMap4 = objectMap3;
      int num4 = size2;
      objectMap4.size = size2 + 1;
      int threshold2 = this.threshold;
      if (num4 < threshold2)
        return;
      this.resize(this.capacity << 1);
      return;
label_14:
      keyTable[obj6] = obj8;
      valueTable[obj6] = obj9;
      ObjectMap objectMap5 = this;
      int size3 = objectMap5.size;
      ObjectMap objectMap6 = objectMap5;
      int num5 = size3;
      objectMap6.size = size3 + 1;
      int threshold3 = this.threshold;
      if (num5 < threshold3)
        return;
      this.resize(this.capacity << 1);
      return;
label_19:
      this.putStash(obj8, obj9);
    }

    [LineNumberTable(new byte[] {161, 173, 100, 127, 6, 105, 127, 11})]
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

    [Signature("(TK;TV;)V")]
    [LineNumberTable(new byte[] {160, 183, 142, 110, 104, 161, 110, 105, 105, 110, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void putStash([In] object obj0, [In] object obj1)
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

    [Signature("(TK;TV;)V")]
    [LineNumberTable(new byte[] {160, 81, 103, 105, 105, 99, 105, 105, 127, 12, 161, 105, 107, 100, 106, 106, 127, 12, 161, 105, 107, 100, 106, 106, 127, 12, 161, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void putResize([In] object obj0, [In] object obj1)
    {
      int num1 = Object.instancehelper_hashCode(obj0);
      int index1 = num1 & this.mask;
      object obj2 = this.keyTable[index1];
      if (obj2 == null)
      {
        this.keyTable[index1] = obj0;
        this.valueTable[index1] = obj1;
        ObjectMap objectMap1 = this;
        int size = objectMap1.size;
        ObjectMap objectMap2 = objectMap1;
        int num2 = size;
        objectMap2.size = size + 1;
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
          ObjectMap objectMap1 = this;
          int size = objectMap1.size;
          ObjectMap objectMap2 = objectMap1;
          int num2 = size;
          objectMap2.size = size + 1;
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
            ObjectMap objectMap1 = this;
            int size = objectMap1.size;
            ObjectMap objectMap2 = objectMap1;
            int num2 = size;
            objectMap2.size = size + 1;
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

    [Signature("(TK;TV;)TV;")]
    [LineNumberTable(new byte[] {160, 247, 103, 116, 52, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private object getStash([In] object obj0, [In] object obj1)
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

    [Signature("(TK;)TV;")]
    [LineNumberTable(new byte[] {161, 31, 103, 116, 107, 105, 103, 110, 226, 59, 230, 72})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual object removeStash([In] object obj0)
    {
      object[] keyTable = this.keyTable;
      int capacity = this.capacity;
      for (int index = capacity + this.stashSize; capacity < index; ++capacity)
      {
        if (Object.instancehelper_equals(obj0, keyTable[capacity]))
        {
          object obj = this.valueTable[capacity];
          this.removeStashIndex(capacity);
          --this.size;
          return obj;
        }
      }
      return (object) null;
    }

    [LineNumberTable(new byte[] {161, 45, 110, 110, 100, 112, 112, 105, 139, 105, 137})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void removeStashIndex([In] int obj0)
    {
      --this.stashSize;
      int index = this.capacity + this.stashSize;
      if (obj0 < index)
      {
        this.keyTable[obj0] = this.keyTable[index];
        this.valueTable[obj0] = this.valueTable[index];
        this.keyTable[index] = (object) null;
        this.valueTable[index] = (object) null;
      }
      else
      {
        this.keyTable[obj0] = (object) null;
        this.valueTable[obj0] = (object) null;
      }
    }

    [Signature("(TK;)Z")]
    [LineNumberTable(new byte[] {161, 140, 103, 116, 45, 134})]
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

    [LineNumberTable(new byte[] {158, 240, 130, 120, 104, 108, 103, 103, 100, 107, 102, 102, 105, 105, 107, 130, 107, 102, 102, 104, 105, 105, 107, 98, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toString(string separator, bool braces)
    {
      int num1 = braces ? 1 : 0;
      if (this.size == 0)
        return num1 != 0 ? "{}" : "";
      StringBuilder stringBuilder = new StringBuilder(32);
      if (num1 != 0)
        stringBuilder.append('{');
      object[] keyTable = this.keyTable;
      object[] valueTable = this.valueTable;
      int length = keyTable.Length;
      object obj1;
      do
      {
        int num2 = length;
        length += -1;
        if (num2 > 0)
          obj1 = keyTable[length];
        else
          goto label_10;
      }
      while (obj1 == null);
      stringBuilder.append(obj1);
      stringBuilder.append('=');
      stringBuilder.append(valueTable[length]);
label_10:
      while (true)
      {
        object obj2;
        do
        {
          int num2 = length;
          length += -1;
          if (num2 > 0)
            obj2 = keyTable[length];
          else
            goto label_13;
        }
        while (obj2 == null);
        stringBuilder.append(separator);
        stringBuilder.append(obj2);
        stringBuilder.append('=');
        stringBuilder.append(valueTable[length]);
      }
label_13:
      if (num1 != 0)
        stringBuilder.append('}');
      return stringBuilder.toString();
    }

    [LineNumberTable(new byte[] {14, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ObjectMap(int initialCapacity)
      : this(initialCapacity, 0.8f)
    {
    }

    [Signature("(Larc/struct/ObjectMap<+TK;+TV;>;)V")]
    [LineNumberTable(new byte[] {44, 127, 10, 108, 122, 122, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ObjectMap(ObjectMap map)
      : this(ByteCodeHelper.d2i(Math.floor((double) ((float) map.capacity * map.loadFactor))), map.loadFactor)
    {
      ObjectMap objectMap = this;
      this.stashSize = map.stashSize;
      ByteCodeHelper.arraycopy((object) map.keyTable, 0, (object) this.keyTable, 0, map.keyTable.Length);
      ByteCodeHelper.arraycopy((object) map.valueTable, 0, (object) this.valueTable, 0, map.valueTable.Length);
      this.size = map.size;
    }

    [Signature("()Larc/struct/ObjectMap<TK;TV;>;")]
    [LineNumberTable(new byte[] {59, 102, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual ObjectMap copy()
    {
      ObjectMap objectMap = new ObjectMap();
      objectMap.putAll(this);
      return objectMap;
    }

    [Signature("(TK;)TV;")]
    [LineNumberTable(329)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object getNull(object key) => key == null ? (object) null : this.get(key);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isEmpty() => this.size == 0;

    [LineNumberTable(new byte[] {161, 68, 127, 10, 113, 106, 104, 103})]
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

    [LineNumberTable(new byte[] {161, 80, 105, 102, 129, 103, 103})]
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

    [LineNumberTable(new byte[] {159, 22, 98, 103, 99, 103, 118, 108, 104, 122, 144, 122, 142})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool containsValue(object value, bool identity)
    {
      int num1 = identity ? 1 : 0;
      object[] valueTable = this.valueTable;
      if (value == null)
      {
        object[] keyTable = this.keyTable;
        int index = this.capacity + this.stashSize;
        do
        {
          int num2 = index;
          index += -1;
          if (num2 <= 0)
            goto label_14;
        }
        while (keyTable[index] == null || valueTable[index] != null);
        return true;
      }
      if (num1 != 0)
      {
        int index = this.capacity + this.stashSize;
        do
        {
          int num2 = index;
          index += -1;
          if (num2 <= 0)
            goto label_14;
        }
        while (!object.ReferenceEquals(valueTable[index], value));
        return true;
      }
      int index1 = this.capacity + this.stashSize;
      do
      {
        int num2 = index1;
        index1 += -1;
        if (num2 <= 0)
          goto label_14;
      }
      while (!Object.instancehelper_equals(value, valueTable[index1]));
      return true;
label_14:
      return false;
    }

    [Signature("(Ljava/lang/Object;Z)TK;")]
    [LineNumberTable(new byte[] {159, 12, 162, 103, 99, 103, 118, 110, 104, 122, 152, 122, 150})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object findKey(object value, bool identity)
    {
      int num1 = identity ? 1 : 0;
      object[] valueTable = this.valueTable;
      if (value == null)
      {
        object[] keyTable = this.keyTable;
        int index = this.capacity + this.stashSize;
        do
        {
          int num2 = index;
          index += -1;
          if (num2 <= 0)
            goto label_14;
        }
        while (keyTable[index] == null || valueTable[index] != null);
        return keyTable[index];
      }
      if (num1 != 0)
      {
        int index = this.capacity + this.stashSize;
        do
        {
          int num2 = index;
          index += -1;
          if (num2 <= 0)
            goto label_14;
        }
        while (!object.ReferenceEquals(valueTable[index], value));
        return this.keyTable[index];
      }
      int index1 = this.capacity + this.stashSize;
      do
      {
        int num2 = index1;
        index1 += -1;
        if (num2 <= 0)
          goto label_14;
      }
      while (!Object.instancehelper_equals(value, valueTable[index1]));
      return this.keyTable[index1];
label_14:
      return (object) null;
    }

    [LineNumberTable(new byte[] {161, 217, 98, 103, 103, 118, 101, 100, 141, 101, 100, 234, 57, 230, 75})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int hashCode()
    {
      int num = 0;
      object[] keyTable = this.keyTable;
      object[] valueTable = this.valueTable;
      int index1 = 0;
      for (int index2 = this.capacity + this.stashSize; index1 < index2; ++index1)
      {
        object obj1 = keyTable[index1];
        if (obj1 != null)
        {
          num += Object.instancehelper_hashCode(obj1) * 31;
          object obj2 = valueTable[index1];
          if (obj2 != null)
            num += Object.instancehelper_hashCode(obj2);
        }
      }
      return num;
    }

    [LineNumberTable(new byte[] {161, 235, 107, 106, 103, 112, 103, 103, 121, 101, 100, 101, 100, 150, 243, 57, 233, 75})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool equals(object obj)
    {
      if (object.ReferenceEquals(obj, (object) this))
        return true;
      if (!(obj is ObjectMap))
        return false;
      ObjectMap objectMap = (ObjectMap) obj;
      if (objectMap.size != this.size)
        return false;
      object[] keyTable = this.keyTable;
      object[] valueTable = this.valueTable;
      int index1 = 0;
      for (int index2 = this.capacity + this.stashSize; index1 < index2; ++index1)
      {
        object key = keyTable[index1];
        if (key != null)
        {
          object obj1 = valueTable[index1];
          if (obj1 == null)
          {
            if (!objectMap.containsKey(key) || objectMap.get(key) != null)
              return false;
          }
          else if (!Object.instancehelper_equals(obj1, objectMap.get(key)))
            return false;
        }
      }
      return true;
    }

    [LineNumberTable(626)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toString(string separator) => this.toString(separator, false);

    [LineNumberTable(630)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toString() => this.toString(", ", true);

    [Signature("()Larc/struct/ObjectMap$Keys<TK;>;")]
    [LineNumberTable(new byte[] {162, 85, 104, 108, 140, 109, 107, 108, 108, 135, 107, 108, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual ObjectMap.Keys keys()
    {
      if (this.keys1 == null)
      {
        this.keys1 = new ObjectMap.Keys(this);
        this.keys2 = new ObjectMap.Keys(this);
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

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(23)]
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

    [Signature("<K:Ljava/lang/Object;V:Ljava/lang/Object;>Larc/struct/ObjectMap$MapIterator<TK;TV;Larc/struct/ObjectMap$Entry<TK;TV;>;>;")]
    public class Entries : ObjectMap.MapIterator
    {
      [Signature("Larc/struct/ObjectMap$Entry<TK;TV;>;")]
      internal ObjectMap.Entry entry;

      [Signature("()Larc/struct/ObjectMap$Entries<TK;TV;>;")]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual ObjectMap.Entries iterator() => this;

      [Signature("(Larc/struct/ObjectMap<TK;TV;>;)V")]
      [LineNumberTable(new byte[] {162, 157, 233, 61, 203})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public Entries(ObjectMap map)
        : base(map)
      {
        ObjectMap.Entries entries = this;
        this.entry = new ObjectMap.Entry();
      }

      [Modifiers]
      [LineNumberTable(779)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void reset() => base.reset();

      [Signature("()Larc/struct/ObjectMap$Entry<TK;TV;>;")]
      [LineNumberTable(new byte[] {162, 162, 115, 120, 108, 115, 125, 108, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual ObjectMap.Entry next()
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

      [LineNumberTable(new byte[] {162, 173, 120})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override bool hasNext()
      {
        if (!this.valid)
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new ArcRuntimeException("#iterator() cannot be used nested.");
        }
        return this.hasNext;
      }

      [Modifiers]
      [LineNumberTable(779)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void remove() => base.remove();

      [Modifiers]
      [EditorBrowsable(EditorBrowsableState.Never)]
      [LineNumberTable(779)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual Iterator \u003Cbridge\u003Eiterator() => (Iterator) this.iterator();

      [Modifiers]
      [EditorBrowsable(EditorBrowsableState.Never)]
      [LineNumberTable(779)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual object \u003Cbridge\u003Enext() => (object) this.next();

      [HideFromJava]
      public bool hasNext
      {
        [HideFromJava] get => this.hasNext;
        [HideFromJava] [param: In] set => this.hasNext = value;
      }

      [HideFromJava]
      [NameSig("<accessstub>0|forEach", "(Ljava.util.function.Consumer;)V")]
      public new void forEach([In] Consumer obj0) => base.forEach(obj0);

      [HideFromJava]
      protected internal void \u003Cnonvirtual\u003E0([In] Consumer obj0) => base.forEach(obj0);

      [HideFromJava]
      [NameSig("<accessstub>1|spliterator", "()Ljava.util.Spliterator;")]
      public new Spliterator spliterator() => base.spliterator();

      [HideFromJava]
      protected internal Spliterator \u003Cnonvirtual\u003E1() => base.spliterator();

      [HideFromJava]
      [NameSig("<accessstub>2|forEachRemaining", "(Ljava.util.function.Consumer;)V")]
      public new void forEachRemaining([In] Consumer obj0) => base.forEachRemaining(obj0);

      [HideFromJava]
      protected internal void \u003Cnonvirtual\u003E2([In] Consumer obj0) => base.forEachRemaining(obj0);
    }

    [Signature("<K:Ljava/lang/Object;V:Ljava/lang/Object;>Ljava/lang/Object;")]
    public class Entry : Object
    {
      [Signature("TK;")]
      public object key;
      [Signature("TV;")]
      public object value;

      [LineNumberTable(727)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public Entry()
      {
      }

      [LineNumberTable(732)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual string toString() => new StringBuilder().append(this.key).append("=").append(this.value).toString();
    }

    [Signature("<K:Ljava/lang/Object;>Larc/struct/ObjectMap$MapIterator<TK;Ljava/lang/Object;TK;>;")]
    public class Keys : ObjectMap.MapIterator
    {
      [Signature("(Larc/struct/ObjectMap<TK;*>;)V")]
      [LineNumberTable(new byte[] {162, 220, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public Keys(ObjectMap map)
        : base(map)
      {
      }

      [Modifiers]
      [LineNumberTable(844)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void reset() => base.reset();

      [Signature("()Larc/struct/ObjectMap$Keys<TK;>;")]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual ObjectMap.Keys iterator() => this;

      [Signature("()Larc/struct/Seq<TK;>;")]
      [LineNumberTable(869)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual Seq toSeq() => this.toSeq(new Seq(true, this.map.size));

      [Signature("(Larc/struct/Seq<TK;>;)Larc/struct/Seq<TK;>;")]
      [LineNumberTable(new byte[] {162, 248, 104, 110})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual Seq toSeq(Seq array)
      {
        while (this.hasNext)
          array.add(this.next());
        return array;
      }

      [Signature("()TK;")]
      [LineNumberTable(new byte[] {162, 229, 115, 120, 115, 108, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override object next()
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

      [LineNumberTable(new byte[] {162, 224, 120})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override bool hasNext()
      {
        if (!this.valid)
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new ArcRuntimeException("#iterator() cannot be used nested.");
        }
        return this.hasNext;
      }

      [Modifiers]
      [LineNumberTable(844)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void remove() => base.remove();

      [Modifiers]
      [EditorBrowsable(EditorBrowsableState.Never)]
      [LineNumberTable(844)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual Iterator \u003Cbridge\u003Eiterator() => (Iterator) this.iterator();

      [HideFromJava]
      public bool hasNext
      {
        [HideFromJava] get => this.hasNext;
        [HideFromJava] [param: In] set => this.hasNext = value;
      }

      [HideFromJava]
      [NameSig("<accessstub>0|forEach", "(Ljava.util.function.Consumer;)V")]
      public new void forEach([In] Consumer obj0) => base.forEach(obj0);

      [HideFromJava]
      protected internal void \u003Cnonvirtual\u003E0([In] Consumer obj0) => base.forEach(obj0);

      [HideFromJava]
      [NameSig("<accessstub>1|spliterator", "()Ljava.util.Spliterator;")]
      public new Spliterator spliterator() => base.spliterator();

      [HideFromJava]
      protected internal Spliterator \u003Cnonvirtual\u003E1() => base.spliterator();

      [HideFromJava]
      [NameSig("<accessstub>2|forEachRemaining", "(Ljava.util.function.Consumer;)V")]
      public new void forEachRemaining([In] Consumer obj0) => base.forEachRemaining(obj0);

      [HideFromJava]
      protected internal void \u003Cnonvirtual\u003E2([In] Consumer obj0) => base.forEachRemaining(obj0);
    }

    [InnerClass]
    [Signature("<K:Ljava/lang/Object;V:Ljava/lang/Object;I:Ljava/lang/Object;>Ljava/lang/Object;Ljava/lang/Iterable<TI;>;Ljava/util/Iterator<TI;>;")]
    [Implements(new string[] {"java.lang.Iterable", "java.util.Iterator"})]
    internal abstract class MapIterator : Object, Iterable, IEnumerable, Iterator
    {
      [Modifiers]
      [Signature("Larc/struct/ObjectMap<TK;TV;>;")]
      internal ObjectMap map;
      public bool hasNext;
      internal int nextIndex;
      internal int currentIndex;
      internal bool valid;

      [LineNumberTable(new byte[] {162, 122, 103, 103, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void reset()
      {
        this.currentIndex = -1;
        this.nextIndex = -1;
        this.findNextIndex();
      }

      [LineNumberTable(new byte[] {162, 128, 103, 108, 127, 15, 106, 103, 162})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal virtual void findNextIndex()
      {
        this.hasNext = false;
        object[] keyTable = this.map.keyTable;
        int num1 = this.map.capacity + this.map.stashSize;
        do
        {
          ObjectMap.MapIterator mapIterator1 = this;
          int num2 = mapIterator1.nextIndex + 1;
          ObjectMap.MapIterator mapIterator2 = mapIterator1;
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

      [Signature("(Larc/struct/ObjectMap<TK;TV;>;)V")]
      [LineNumberTable(new byte[] {162, 116, 8, 167, 103, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public MapIterator([In] ObjectMap obj0)
      {
        ObjectMap.MapIterator mapIterator = this;
        this.valid = true;
        this.map = obj0;
        this.reset();
      }

      [LineNumberTable(new byte[] {162, 139, 121, 115, 113, 110, 136, 115, 147, 103, 115})]
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
        {
          this.map.keyTable[this.currentIndex] = (object) null;
          this.map.valueTable[this.currentIndex] = (object) null;
        }
        this.currentIndex = -1;
        --this.map.size;
      }

      [HideFromJava]
      public abstract Iterator iterator();

      [HideFromJava]
      public virtual void forEach([In] Consumer obj0) => Iterable.\u003Cdefault\u003EforEach((Iterable) this, obj0);

      [HideFromJava]
      public virtual Spliterator spliterator() => Iterable.\u003Cdefault\u003Espliterator((Iterable) this);

      [HideFromJava]
      public abstract bool hasNext();

      [HideFromJava]
      public abstract object next();

      [HideFromJava]
      public virtual void forEachRemaining([In] Consumer obj0) => Iterator.\u003Cdefault\u003EforEachRemaining((Iterator) this, obj0);

      [HideFromJava]
      [SpecialName]
      IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) new IterableEnumerator((Iterable) this);
    }

    [Signature("<V:Ljava/lang/Object;>Larc/struct/ObjectMap$MapIterator<Ljava/lang/Object;TV;TV;>;")]
    public class Values : ObjectMap.MapIterator
    {
      [Signature("()Larc/struct/ObjectMap$Values<TV;>;")]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual ObjectMap.Values iterator() => this;

      [Signature("(Larc/struct/ObjectMap<*TV;>;)V")]
      [LineNumberTable(new byte[] {162, 184, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public Values(ObjectMap map)
        : base(map)
      {
      }

      [Modifiers]
      [LineNumberTable(808)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void reset() => base.reset();

      [Signature("()Larc/struct/Seq<TV;>;")]
      [LineNumberTable(833)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual Seq toSeq() => this.toSeq(new Seq(true, this.map.size));

      [Signature("(Larc/struct/Seq<TV;>;)Larc/struct/Seq<TV;>;")]
      [LineNumberTable(new byte[] {162, 212, 104, 110})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual Seq toSeq(Seq array)
      {
        while (this.hasNext)
          array.add(this.next());
        return array;
      }

      [Signature("()TV;")]
      [LineNumberTable(new byte[] {162, 193, 115, 120, 115, 108, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override object next()
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
        object obj = this.map.valueTable[this.nextIndex];
        this.currentIndex = this.nextIndex;
        this.findNextIndex();
        return obj;
      }

      [LineNumberTable(new byte[] {162, 188, 120})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override bool hasNext()
      {
        if (!this.valid)
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new ArcRuntimeException("#iterator() cannot be used nested.");
        }
        return this.hasNext;
      }

      [Modifiers]
      [LineNumberTable(808)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void remove() => base.remove();

      [Modifiers]
      [EditorBrowsable(EditorBrowsableState.Never)]
      [LineNumberTable(808)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual Iterator \u003Cbridge\u003Eiterator() => (Iterator) this.iterator();

      [HideFromJava]
      public bool hasNext
      {
        [HideFromJava] get => this.hasNext;
        [HideFromJava] [param: In] set => this.hasNext = value;
      }

      [HideFromJava]
      [NameSig("<accessstub>0|forEach", "(Ljava.util.function.Consumer;)V")]
      public new void forEach([In] Consumer obj0) => base.forEach(obj0);

      [HideFromJava]
      protected internal void \u003Cnonvirtual\u003E0([In] Consumer obj0) => base.forEach(obj0);

      [HideFromJava]
      [NameSig("<accessstub>1|spliterator", "()Ljava.util.Spliterator;")]
      public new Spliterator spliterator() => base.spliterator();

      [HideFromJava]
      protected internal Spliterator \u003Cnonvirtual\u003E1() => base.spliterator();

      [HideFromJava]
      [NameSig("<accessstub>2|forEachRemaining", "(Ljava.util.function.Consumer;)V")]
      public new void forEachRemaining([In] Consumer obj0) => base.forEachRemaining(obj0);

      [HideFromJava]
      protected internal void \u003Cnonvirtual\u003E2([In] Consumer obj0) => base.forEachRemaining(obj0);
    }
  }
}
