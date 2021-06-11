// Decompiled with JetBrains decompiler
// Type: arc.struct.ArrayMap
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
using java.lang.reflect;
using java.util;
using java.util.function;
using System.Collections;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.@struct
{
  [Signature("<K:Ljava/lang/Object;V:Ljava/lang/Object;>Ljava/lang/Object;Ljava/lang/Iterable<Larc/struct/ObjectMap$Entry<TK;TV;>;>;")]
  [Implements(new string[] {"java.lang.Iterable"})]
  public class ArrayMap : Object, Iterable, IEnumerable
  {
    [Signature("[TK;")]
    public object[] keys;
    [Signature("[TV;")]
    public object[] values;
    public int size;
    public bool ordered;
    private ArrayMap.Entries entries1;
    private ArrayMap.Entries entries2;
    private ArrayMap.Values valuesIter1;
    private ArrayMap.Values valuesIter2;
    private ArrayMap.Keys keysIter1;
    private ArrayMap.Keys keysIter2;

    [Signature("(TK;TV;)I")]
    [LineNumberTable(new byte[] {29, 104, 100, 127, 15, 148, 105, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int put(object key, object value)
    {
      int index = this.indexOfKey(key);
      if (index == -1)
      {
        if (this.size == this.keys.Length)
          this.resize(Math.max(8, ByteCodeHelper.f2i((float) this.size * 1.75f)));
        ArrayMap arrayMap1 = this;
        int size = arrayMap1.size;
        ArrayMap arrayMap2 = arrayMap1;
        int num = size;
        arrayMap2.size = size + 1;
        index = num;
      }
      this.keys[index] = key;
      this.values[index] = value;
      return index;
    }

    [LineNumberTable(new byte[] {160, 178, 122, 103, 110, 104, 115, 159, 0, 107, 149, 105, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void removeIndex(int index)
    {
      if (index >= this.size)
      {
        string str = String.valueOf(index);
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IndexOutOfBoundsException(str);
      }
      object[] keys = this.keys;
      --this.size;
      if (this.ordered)
      {
        ByteCodeHelper.arraycopy((object) keys, index + 1, (object) keys, index, this.size - index);
        ByteCodeHelper.arraycopy((object) this.values, index + 1, (object) this.values, index, this.size - index);
      }
      else
      {
        keys[index] = keys[this.size];
        this.values[index] = this.values[this.size];
      }
      keys[this.size] = (object) null;
      this.values[this.size] = (object) null;
    }

    [LineNumberTable(new byte[] {159, 132, 162, 104, 103, 108, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ArrayMap(bool ordered, int capacity)
    {
      int num = ordered ? 1 : 0;
      // ISSUE: explicit constructor call
      base.\u002Ector();
      ArrayMap arrayMap = this;
      this.ordered = num != 0;
      this.keys = new object[capacity];
      this.values = new object[capacity];
    }

    [LineNumberTable(new byte[] {159, 129, 162, 104, 103, 114, 115})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ArrayMap(bool ordered, int capacity, Class keyArrayType, Class valueArrayType)
    {
      int num = ordered ? 1 : 0;
      // ISSUE: explicit constructor call
      base.\u002Ector();
      ArrayMap arrayMap = this;
      this.ordered = num != 0;
      this.keys = (object[]) Array.newInstance(keyArrayType, capacity);
      this.values = (object[]) Array.newInstance(valueArrayType, capacity);
    }

    [Signature("(TK;)I")]
    [LineNumberTable(new byte[] {160, 111, 103, 99, 109, 45, 168, 109, 45, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int indexOfKey(object key)
    {
      object[] keys = this.keys;
      if (key == null)
      {
        int index = 0;
        for (int size = this.size; index < size; ++index)
        {
          if (object.ReferenceEquals(keys[index], key))
            return index;
        }
      }
      else
      {
        int index = 0;
        for (int size = this.size; index < size; ++index)
        {
          if (Object.instancehelper_equals(key, keys[index]))
            return index;
        }
      }
      return -1;
    }

    [LineNumberTable(new byte[] {160, 248, 124, 123, 135, 124, 123, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void resize(int newSize)
    {
      object[] objArray1 = (object[]) Array.newInstance(Object.instancehelper_getClass((object) this.keys).getComponentType(), newSize);
      ByteCodeHelper.arraycopy((object) this.keys, 0, (object) objArray1, 0, Math.min(this.size, objArray1.Length));
      this.keys = objArray1;
      object[] objArray2 = (object[]) Array.newInstance(Object.instancehelper_getClass((object) this.values).getComponentType(), newSize);
      ByteCodeHelper.arraycopy((object) this.values, 0, (object) objArray2, 0, Math.min(this.size, objArray2.Length));
      this.values = objArray2;
    }

    [Signature("(Larc/struct/ArrayMap<+TK;+TV;>;II)V")]
    [LineNumberTable(new byte[] {58, 107, 127, 43, 107, 127, 5, 121, 121, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void putAll(ArrayMap map, int offset, int length)
    {
      if (offset + length > map.size)
      {
        string str = new StringBuilder().append("offset + length must be <= size: ").append(offset).append(" + ").append(length).append(" <= ").append(map.size).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException(str);
      }
      int num = this.size + length - offset;
      if (num >= this.keys.Length)
        this.resize(Math.max(8, ByteCodeHelper.f2i((float) num * 1.75f)));
      ByteCodeHelper.arraycopy((object) map.keys, offset, (object) this.keys, this.size, length);
      ByteCodeHelper.arraycopy((object) map.values, offset, (object) this.values, this.size, length);
      this.size += length;
    }

    [LineNumberTable(new byte[] {160, 218, 103, 103, 109, 100, 4, 198, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void clear()
    {
      object[] keys = this.keys;
      object[] values = this.values;
      int index = 0;
      for (int size = this.size; index < size; ++index)
      {
        keys[index] = (object) null;
        values[index] = (object) null;
      }
      this.size = 0;
    }

    [Signature("(TK;)Z")]
    [LineNumberTable(new byte[] {160, 84, 103, 105, 99, 100, 145, 100, 145})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool containsKey(object key)
    {
      object[] keys = this.keys;
      int num = this.size - 1;
      if (key == null)
      {
        while (num >= 0)
        {
          object[] objArray = keys;
          int index = num;
          num += -1;
          if (object.ReferenceEquals(objArray[index], key))
            return true;
        }
      }
      else
      {
        while (num >= 0)
        {
          object obj1 = key;
          object[] objArray = keys;
          int index = num;
          num += -1;
          object obj2 = objArray[index];
          if (Object.instancehelper_equals(obj1, obj2))
            return true;
        }
      }
      return false;
    }

    [Signature("(TK;)TV;")]
    [LineNumberTable(new byte[] {72, 103, 105, 99, 100, 52, 166, 100, 52, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object get(object key)
    {
      object[] keys = this.keys;
      int index = this.size - 1;
      if (key == null)
      {
        for (; index >= 0; index += -1)
        {
          if (object.ReferenceEquals(keys[index], key))
            return this.values[index];
        }
      }
      else
      {
        for (; index >= 0; index += -1)
        {
          if (Object.instancehelper_equals(key, keys[index]))
            return this.values[index];
        }
      }
      return (object) null;
    }

    [Signature("()Larc/struct/ArrayMap$Entries<TK;TV;>;")]
    [LineNumberTable(new byte[] {161, 100, 104, 108, 140, 109, 108, 108, 108, 135, 108, 108, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual ArrayMap.Entries entries()
    {
      if (this.entries1 == null)
      {
        this.entries1 = new ArrayMap.Entries(this);
        this.entries2 = new ArrayMap.Entries(this);
      }
      if (!this.entries1.valid)
      {
        this.entries1.index = 0;
        this.entries1.valid = true;
        this.entries2.valid = false;
        return this.entries1;
      }
      this.entries2.index = 0;
      this.entries2.valid = true;
      this.entries1.valid = false;
      return this.entries2;
    }

    [LineNumberTable(new byte[] {159, 172, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ArrayMap()
      : this(true, 16)
    {
    }

    [LineNumberTable(new byte[] {159, 177, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ArrayMap(int capacity)
      : this(true, capacity)
    {
    }

    [LineNumberTable(new byte[] {13, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ArrayMap(Class keyArrayType, Class valueArrayType)
      : this(false, 16, keyArrayType, valueArrayType)
    {
    }

    [LineNumberTable(new byte[] {22, 127, 21, 108, 121, 121})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ArrayMap(ArrayMap array)
      : this(array.ordered, array.size, Object.instancehelper_getClass((object) array.keys).getComponentType(), Object.instancehelper_getClass((object) array.values).getComponentType())
    {
      ArrayMap arrayMap = this;
      this.size = array.size;
      ByteCodeHelper.arraycopy((object) array.keys, 0, (object) this.keys, 0, this.size);
      ByteCodeHelper.arraycopy((object) array.values, 0, (object) this.values, 0, this.size);
    }

    [Signature("(TK;TV;I)I")]
    [LineNumberTable(new byte[] {40, 104, 100, 105, 111, 127, 0, 125, 125, 105, 105, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int put(object key, object value, int index)
    {
      int index1 = this.indexOfKey(key);
      if (index1 != -1)
        this.removeIndex(index1);
      else if (this.size == this.keys.Length)
        this.resize(Math.max(8, ByteCodeHelper.f2i((float) this.size * 1.75f)));
      ByteCodeHelper.arraycopy((object) this.keys, index, (object) this.keys, index + 1, this.size - index);
      ByteCodeHelper.arraycopy((object) this.values, index, (object) this.values, index + 1, this.size - index);
      this.keys[index] = key;
      this.values[index] = value;
      ++this.size;
      return index;
    }

    [Signature("(Larc/struct/ArrayMap<+TK;+TV;>;)V")]
    [LineNumberTable(new byte[] {54, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void putAll(ArrayMap map) => this.putAll(map, 0, map.size);

    [Signature("(TV;Z)TK;")]
    [LineNumberTable(new byte[] {159, 107, 66, 103, 105, 102, 100, 52, 166, 100, 52, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object getKey(object value, bool identity)
    {
      int num = identity ? 1 : 0;
      object[] values = this.values;
      int index = this.size - 1;
      if (num != 0 || value == null)
      {
        for (; index >= 0; index += -1)
        {
          if (object.ReferenceEquals(values[index], value))
            return this.keys[index];
        }
      }
      else
      {
        for (; index >= 0; index += -1)
        {
          if (Object.instancehelper_equals(value, values[index]))
            return this.keys[index];
        }
      }
      return (object) null;
    }

    [Signature("(I)TK;")]
    [LineNumberTable(new byte[] {103, 122})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object getKeyAt(int index)
    {
      if (index >= this.size)
      {
        string str = String.valueOf(index);
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IndexOutOfBoundsException(str);
      }
      return this.keys[index];
    }

    [Signature("(I)TV;")]
    [LineNumberTable(new byte[] {108, 122})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object getValueAt(int index)
    {
      if (index >= this.size)
      {
        string str = String.valueOf(index);
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IndexOutOfBoundsException(str);
      }
      return this.values[index];
    }

    [Signature("()TK;")]
    [LineNumberTable(new byte[] {113, 120})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object firstKey()
    {
      if (this.size == 0)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalStateException("Map is empty.");
      }
      return this.keys[0];
    }

    [Signature("()TV;")]
    [LineNumberTable(new byte[] {118, 120})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object firstValue()
    {
      if (this.size == 0)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalStateException("Map is empty.");
      }
      return this.values[0];
    }

    [Signature("(ITK;)V")]
    [LineNumberTable(new byte[] {123, 122, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setKey(int index, object key)
    {
      if (index >= this.size)
      {
        string str = String.valueOf(index);
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IndexOutOfBoundsException(str);
      }
      this.keys[index] = key;
    }

    [Signature("(ITV;)V")]
    [LineNumberTable(new byte[] {160, 64, 122, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setValue(int index, object value)
    {
      if (index >= this.size)
      {
        string str = String.valueOf(index);
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IndexOutOfBoundsException(str);
      }
      this.values[index] = value;
    }

    [Signature("(ITK;TV;)V")]
    [LineNumberTable(new byte[] {160, 69, 122, 127, 15, 104, 125, 159, 0, 117, 149, 110, 105, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void insert(int index, object key, object value)
    {
      if (index > this.size)
      {
        string str = String.valueOf(index);
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IndexOutOfBoundsException(str);
      }
      if (this.size == this.keys.Length)
        this.resize(Math.max(8, ByteCodeHelper.f2i((float) this.size * 1.75f)));
      if (this.ordered)
      {
        ByteCodeHelper.arraycopy((object) this.keys, index, (object) this.keys, index + 1, this.size - index);
        ByteCodeHelper.arraycopy((object) this.values, index, (object) this.values, index + 1, this.size - index);
      }
      else
      {
        this.keys[this.size] = this.keys[index];
        this.values[this.size] = this.values[index];
      }
      ++this.size;
      this.keys[index] = key;
      this.values[index] = value;
    }

    [Signature("(TV;Z)Z")]
    [LineNumberTable(new byte[] {159, 89, 66, 103, 105, 102, 100, 145, 100, 145})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool containsValue(object value, bool identity)
    {
      int num1 = identity ? 1 : 0;
      object[] values = this.values;
      int num2 = this.size - 1;
      if (num1 != 0 || value == null)
      {
        while (num2 >= 0)
        {
          object[] objArray = values;
          int index = num2;
          num2 += -1;
          if (object.ReferenceEquals(objArray[index], value))
            return true;
        }
      }
      else
      {
        while (num2 >= 0)
        {
          object obj1 = value;
          object[] objArray = values;
          int index = num2;
          num2 += -1;
          object obj2 = objArray[index];
          if (Object.instancehelper_equals(obj1, obj2))
            return true;
        }
      }
      return false;
    }

    [Signature("(TV;Z)I")]
    [LineNumberTable(new byte[] {159, 83, 98, 103, 102, 109, 45, 168, 109, 45, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int indexOfValue(object value, bool identity)
    {
      int num = identity ? 1 : 0;
      object[] values = this.values;
      if (num != 0 || value == null)
      {
        int index = 0;
        for (int size = this.size; index < size; ++index)
        {
          if (object.ReferenceEquals(values[index], value))
            return index;
        }
      }
      else
      {
        int index = 0;
        for (int size = this.size; index < size; ++index)
        {
          if (Object.instancehelper_equals(value, values[index]))
            return index;
        }
      }
      return -1;
    }

    [Signature("(TK;)TV;")]
    [LineNumberTable(new byte[] {160, 135, 103, 99, 109, 107, 105, 103, 226, 60, 232, 72, 109, 107, 105, 103, 226, 60, 230, 72})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object removeKey(object key)
    {
      object[] keys = this.keys;
      if (key == null)
      {
        int index = 0;
        for (int size = this.size; index < size; ++index)
        {
          if (object.ReferenceEquals(keys[index], key))
          {
            object obj = this.values[index];
            this.removeIndex(index);
            return obj;
          }
        }
      }
      else
      {
        int index = 0;
        for (int size = this.size; index < size; ++index)
        {
          if (Object.instancehelper_equals(key, keys[index]))
          {
            object obj = this.values[index];
            this.removeIndex(index);
            return obj;
          }
        }
      }
      return (object) null;
    }

    [Signature("(TV;Z)Z")]
    [LineNumberTable(new byte[] {159, 75, 162, 103, 102, 109, 107, 103, 226, 61, 232, 71, 109, 107, 103, 226, 61, 230, 71})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool removeValue(object value, bool identity)
    {
      int num = identity ? 1 : 0;
      object[] values = this.values;
      if (num != 0 || value == null)
      {
        int index = 0;
        for (int size = this.size; index < size; ++index)
        {
          if (object.ReferenceEquals(values[index], value))
          {
            this.removeIndex(index);
            return true;
          }
        }
      }
      else
      {
        int index = 0;
        for (int size = this.size; index < size; ++index)
        {
          if (Object.instancehelper_equals(value, values[index]))
          {
            this.removeIndex(index);
            return true;
          }
        }
      }
      return false;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isEmpty() => this.size == 0;

    [Signature("()TK;")]
    [LineNumberTable(313)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object peekKey() => this.keys[this.size - 1];

    [Signature("()TV;")]
    [LineNumberTable(318)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object peekValue() => this.values[this.size - 1];

    [LineNumberTable(new byte[] {160, 209, 106, 102, 129, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void clear(int maximumCapacity)
    {
      if (this.keys.Length <= maximumCapacity)
      {
        this.clear();
      }
      else
      {
        this.size = 0;
        this.resize(maximumCapacity);
      }
    }

    [LineNumberTable(new byte[] {160, 232, 112, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void shrink()
    {
      if (this.keys.Length == this.size)
        return;
      this.resize(this.size);
    }

    [LineNumberTable(new byte[] {160, 241, 100, 127, 6, 105, 119})]
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
      if (num < this.keys.Length)
        return;
      this.resize(Math.max(8, num));
    }

    [LineNumberTable(new byte[] {161, 2, 123, 100, 106, 112, 138, 106, 112, 234, 56, 233, 74})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void reverse()
    {
      int index1 = 0;
      int num = this.size - 1;
      for (int index2 = this.size / 2; index1 < index2; ++index1)
      {
        int index3 = num - index1;
        object key = this.keys[index1];
        this.keys[index1] = this.keys[index3];
        this.keys[index3] = key;
        object obj = this.values[index1];
        this.values[index1] = this.values[index3];
        this.values[index3] = obj;
      }
    }

    [LineNumberTable(new byte[] {161, 15, 112, 103, 105, 112, 137, 105, 112, 233, 56, 233, 74})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void shuffle()
    {
      for (int range = this.size - 1; range >= 0; range += -1)
      {
        int index = Mathf.random(range);
        object key = this.keys[range];
        this.keys[range] = this.keys[index];
        this.keys[index] = key;
        object obj = this.values[range];
        this.values[range] = this.values[index];
        this.values[index] = obj;
      }
    }

    [LineNumberTable(new byte[] {161, 32, 106, 107, 105, 9, 198, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void truncate(int newSize)
    {
      if (this.size <= newSize)
        return;
      for (int index = newSize; index < this.size; ++index)
      {
        this.keys[index] = (object) null;
        this.values[index] = (object) null;
      }
      this.size = newSize;
    }

    [LineNumberTable(new byte[] {161, 41, 103, 103, 98, 111, 101, 101, 113, 238, 60, 230, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int hashCode()
    {
      object[] keys = this.keys;
      object[] values = this.values;
      int num = 0;
      int index = 0;
      for (int size = this.size; index < size; ++index)
      {
        object obj1 = keys[index];
        object obj2 = values[index];
        if (obj1 != null)
          num += Object.instancehelper_hashCode(obj1) * 31;
        if (obj2 != null)
          num += Object.instancehelper_hashCode(obj2);
      }
      return num;
    }

    [LineNumberTable(new byte[] {161, 54, 107, 106, 103, 112, 103, 103, 111, 101, 101, 100, 150, 243, 58, 230, 73})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool equals(object obj)
    {
      if (object.ReferenceEquals(obj, (object) this))
        return true;
      if (!(obj is ArrayMap))
        return false;
      ArrayMap arrayMap = (ArrayMap) obj;
      if (arrayMap.size != this.size)
        return false;
      object[] keys = this.keys;
      object[] values = this.values;
      int index = 0;
      for (int size = this.size; index < size; ++index)
      {
        object key = keys[index];
        object obj1 = values[index];
        if (obj1 == null)
        {
          if (!arrayMap.containsKey(key) || arrayMap.get(key) != null)
            return false;
        }
        else if (!Object.instancehelper_equals(obj1, arrayMap.get(key)))
          return false;
      }
      return true;
    }

    [LineNumberTable(new byte[] {161, 73, 110, 103, 103, 104, 105, 106, 105, 106, 107, 108, 106, 105, 234, 60, 230, 70, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toString()
    {
      if (this.size == 0)
        return "{}";
      object[] keys = this.keys;
      object[] values = this.values;
      StringBuilder stringBuilder = new StringBuilder(32);
      stringBuilder.append('{');
      stringBuilder.append(keys[0]);
      stringBuilder.append('=');
      stringBuilder.append(values[0]);
      for (int index = 1; index < this.size; ++index)
      {
        stringBuilder.append(", ");
        stringBuilder.append(keys[index]);
        stringBuilder.append('=');
        stringBuilder.append(values[index]);
      }
      stringBuilder.append('}');
      return stringBuilder.toString();
    }

    [Signature("()Ljava/util/Iterator<Larc/struct/ObjectMap$Entry<TK;TV;>;>;")]
    [LineNumberTable(462)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Iterator iterator() => (Iterator) this.entries();

    [Signature("()Larc/struct/ArrayMap$Values<TV;>;")]
    [LineNumberTable(new byte[] {161, 121, 104, 108, 140, 109, 108, 108, 108, 135, 108, 108, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual ArrayMap.Values values()
    {
      if (this.valuesIter1 == null)
      {
        this.valuesIter1 = new ArrayMap.Values(this);
        this.valuesIter2 = new ArrayMap.Values(this);
      }
      if (!this.valuesIter1.valid)
      {
        this.valuesIter1.index = 0;
        this.valuesIter1.valid = true;
        this.valuesIter2.valid = false;
        return this.valuesIter1;
      }
      this.valuesIter2.index = 0;
      this.valuesIter2.valid = true;
      this.valuesIter1.valid = false;
      return this.valuesIter2;
    }

    [Signature("()Larc/struct/ArrayMap$Keys<TK;>;")]
    [LineNumberTable(new byte[] {161, 142, 104, 108, 140, 109, 108, 108, 108, 135, 108, 108, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual ArrayMap.Keys keys()
    {
      if (this.keysIter1 == null)
      {
        this.keysIter1 = new ArrayMap.Keys(this);
        this.keysIter2 = new ArrayMap.Keys(this);
      }
      if (!this.keysIter1.valid)
      {
        this.keysIter1.index = 0;
        this.keysIter1.valid = true;
        this.keysIter2.valid = false;
        return this.keysIter1;
      }
      this.keysIter2.index = 0;
      this.keysIter2.valid = true;
      this.keysIter1.valid = false;
      return this.keysIter2;
    }

    [HideFromJava]
    public virtual void forEach([In] Consumer obj0) => Iterable.\u003Cdefault\u003EforEach((Iterable) this, obj0);

    [HideFromJava]
    public virtual Spliterator spliterator() => Iterable.\u003Cdefault\u003Espliterator((Iterable) this);

    [HideFromJava]
    [SpecialName]
    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) new IterableEnumerator((Iterable) this);

    [Signature("<K:Ljava/lang/Object;V:Ljava/lang/Object;>Ljava/lang/Object;Ljava/lang/Iterable<Larc/struct/ObjectMap$Entry<TK;TV;>;>;Ljava/util/Iterator<Larc/struct/ObjectMap$Entry<TK;TV;>;>;")]
    [Implements(new string[] {"java.lang.Iterable", "java.util.Iterator"})]
    public class Entries : Object, Iterable, IEnumerable, Iterator
    {
      [Modifiers]
      [Signature("Larc/struct/ArrayMap<TK;TV;>;")]
      private ArrayMap map;
      [Signature("Larc/struct/ObjectMap$Entry<TK;TV;>;")]
      internal ObjectMap.Entry entry;
      internal int index;
      internal bool valid;

      [Signature("()Larc/struct/ObjectMap$Entry<TK;TV;>;")]
      [LineNumberTable(new byte[] {161, 179, 127, 10, 120, 125, 127, 11})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual ObjectMap.Entry next()
      {
        if (this.index >= this.map.size)
        {
          string str = String.valueOf(this.index);
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new NoSuchElementException(str);
        }
        if (!this.valid)
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new ArcRuntimeException("#iterator() cannot be used nested.");
        }
        this.entry.key = this.map.keys[this.index];
        ObjectMap.Entry entry = this.entry;
        object[] values = this.map.values;
        ArrayMap.Entries entries1 = this;
        int index1 = entries1.index;
        ArrayMap.Entries entries2 = entries1;
        int index2 = index1;
        entries2.index = index1 + 1;
        object obj = values[index2];
        entry.value = obj;
        return this.entry;
      }

      [Signature("(Larc/struct/ArrayMap<TK;TV;>;)V")]
      [LineNumberTable(new byte[] {161, 164, 232, 60, 139, 167, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public Entries(ArrayMap map)
      {
        ArrayMap.Entries entries = this;
        this.entry = new ObjectMap.Entry();
        this.valid = true;
        this.map = map;
      }

      [LineNumberTable(new byte[] {161, 169, 120})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual bool hasNext()
      {
        if (!this.valid)
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new ArcRuntimeException("#iterator() cannot be used nested.");
        }
        return this.index < this.map.size;
      }

      [Signature("()Ljava/util/Iterator<Larc/struct/ObjectMap$Entry<TK;TV;>;>;")]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual Iterator iterator() => (Iterator) this;

      [LineNumberTable(new byte[] {161, 187, 110, 113})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void remove()
      {
        --this.index;
        this.map.removeIndex(this.index);
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void reset() => this.index = 0;

      [Modifiers]
      [EditorBrowsable(EditorBrowsableState.Never)]
      [LineNumberTable(528)]
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
    }

    [Signature("<K:Ljava/lang/Object;>Ljava/lang/Object;Ljava/lang/Iterable<TK;>;Ljava/util/Iterator<TK;>;")]
    [Implements(new string[] {"java.lang.Iterable", "java.util.Iterator"})]
    public class Keys : Object, Iterable, IEnumerable, Iterator
    {
      [Modifiers]
      [Signature("Larc/struct/ArrayMap<TK;Ljava/lang/Object;>;")]
      private ArrayMap map;
      internal int index;
      internal bool valid;

      [Signature("(Larc/struct/ArrayMap<TK;Ljava/lang/Object;>;)V")]
      [LineNumberTable(new byte[] {161, 244, 8, 167, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public Keys(ArrayMap map)
      {
        ArrayMap.Keys keys = this;
        this.valid = true;
        this.map = map;
      }

      [LineNumberTable(new byte[] {161, 249, 120})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual bool hasNext()
      {
        if (!this.valid)
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new ArcRuntimeException("#iterator() cannot be used nested.");
        }
        return this.index < this.map.size;
      }

      [Signature("()Ljava/util/Iterator<TK;>;")]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual Iterator iterator() => (Iterator) this;

      [Signature("()TK;")]
      [LineNumberTable(new byte[] {162, 2, 127, 10, 120})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual object next()
      {
        if (this.index >= this.map.size)
        {
          string str = String.valueOf(this.index);
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new NoSuchElementException(str);
        }
        if (!this.valid)
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new ArcRuntimeException("#iterator() cannot be used nested.");
        }
        object[] keys1 = this.map.keys;
        ArrayMap.Keys keys2 = this;
        int index1 = keys2.index;
        ArrayMap.Keys keys3 = keys2;
        int index2 = index1;
        keys3.index = index1 + 1;
        return keys1[index2];
      }

      [LineNumberTable(new byte[] {162, 8, 110, 113})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void remove()
      {
        --this.index;
        this.map.removeIndex(this.index);
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void reset() => this.index = 0;

      [Signature("()Larc/struct/Seq<TK;>;")]
      [LineNumberTable(643)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual Seq toArray() => new Seq(true, this.map.keys, this.index, this.map.size - this.index);

      [Signature("(Larc/struct/Seq;)Larc/struct/Seq<TK;>;")]
      [LineNumberTable(new byte[] {162, 21, 127, 11})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual Seq toArray(Seq array)
      {
        array.addAll(this.map.keys, this.index, this.map.size - this.index);
        return array;
      }

      [HideFromJava]
      public virtual void forEach([In] Consumer obj0) => Iterable.\u003Cdefault\u003EforEach((Iterable) this, obj0);

      [HideFromJava]
      public virtual Spliterator spliterator() => Iterable.\u003Cdefault\u003Espliterator((Iterable) this);

      [HideFromJava]
      public virtual void forEachRemaining([In] Consumer obj0) => Iterator.\u003Cdefault\u003EforEachRemaining((Iterator) this, obj0);

      [HideFromJava]
      [SpecialName]
      IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) new IterableEnumerator((Iterable) this);
    }

    [Signature("<V:Ljava/lang/Object;>Ljava/lang/Object;Ljava/lang/Iterable<TV;>;Ljava/util/Iterator<TV;>;")]
    [Implements(new string[] {"java.lang.Iterable", "java.util.Iterator"})]
    public class Values : Object, Iterable, IEnumerable, Iterator
    {
      [Modifiers]
      [Signature("Larc/struct/ArrayMap<Ljava/lang/Object;TV;>;")]
      private ArrayMap map;
      internal int index;
      internal bool valid;

      [Signature("(Larc/struct/ArrayMap<Ljava/lang/Object;TV;>;)V")]
      [LineNumberTable(new byte[] {161, 201, 8, 167, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public Values(ArrayMap map)
      {
        ArrayMap.Values values = this;
        this.valid = true;
        this.map = map;
      }

      [LineNumberTable(new byte[] {161, 206, 120})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual bool hasNext()
      {
        if (!this.valid)
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new ArcRuntimeException("#iterator() cannot be used nested.");
        }
        return this.index < this.map.size;
      }

      [Signature("()Ljava/util/Iterator<TV;>;")]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual Iterator iterator() => (Iterator) this;

      [Signature("()TV;")]
      [LineNumberTable(new byte[] {161, 215, 127, 10, 120})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual object next()
      {
        if (this.index >= this.map.size)
        {
          string str = String.valueOf(this.index);
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new NoSuchElementException(str);
        }
        if (!this.valid)
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new ArcRuntimeException("#iterator() cannot be used nested.");
        }
        object[] values1 = this.map.values;
        ArrayMap.Values values2 = this;
        int index1 = values2.index;
        ArrayMap.Values values3 = values2;
        int index2 = index1;
        values3.index = index1 + 1;
        return values1[index2];
      }

      [LineNumberTable(new byte[] {161, 221, 110, 113})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void remove()
      {
        --this.index;
        this.map.removeIndex(this.index);
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void reset() => this.index = 0;

      [Signature("()Larc/struct/Seq<TV;>;")]
      [LineNumberTable(600)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual Seq toArray() => new Seq(true, this.map.values, this.index, this.map.size - this.index);

      [Signature("(Larc/struct/Seq;)Larc/struct/Seq<TV;>;")]
      [LineNumberTable(new byte[] {161, 234, 127, 11})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual Seq toArray(Seq array)
      {
        array.addAll(this.map.values, this.index, this.map.size - this.index);
        return array;
      }

      [HideFromJava]
      public virtual void forEach([In] Consumer obj0) => Iterable.\u003Cdefault\u003EforEach((Iterable) this, obj0);

      [HideFromJava]
      public virtual Spliterator spliterator() => Iterable.\u003Cdefault\u003Espliterator((Iterable) this);

      [HideFromJava]
      public virtual void forEachRemaining([In] Consumer obj0) => Iterator.\u003Cdefault\u003EforEachRemaining((Iterator) this, obj0);

      [HideFromJava]
      [SpecialName]
      IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) new IterableEnumerator((Iterable) this);
    }
  }
}
