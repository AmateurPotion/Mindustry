// Decompiled with JetBrains decompiler
// Type: arc.struct.ObjectSet
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
using System.Collections;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.@struct
{
  [Signature("<T:Ljava/lang/Object;>Ljava/lang/Object;Ljava/lang/Iterable<TT;>;Larc/util/Eachable<TT;>;")]
  [Implements(new string[] {"java.lang.Iterable", "arc.util.Eachable"})]
  public class ObjectSet : Object, Iterable, IEnumerable, Eachable
  {
    private const int PRIME1 = -1105259343;
    private const int PRIME2 = -1262997959;
    private const int PRIME3 = -825114047;
    public int size;
    [Signature("[TT;")]
    internal object[] keyTable;
    internal int capacity;
    internal int stashSize;
    private float loadFactor;
    private int hashShift;
    private int mask;
    private int threshold;
    private int stashCapacity;
    private int pushIterations;
    [Signature("Larc/struct/ObjectSet<TT;>.ObjectSetIterator;")]
    [Nullable(new object[] {64, "Larc/util/Nullable;"})]
    private ObjectSet.ObjectSetIterator iterator1;
    [Signature("Larc/struct/ObjectSet<TT;>.ObjectSetIterator;")]
    [Nullable(new object[] {64, "Larc/util/Nullable;"})]
    private ObjectSet.ObjectSetIterator iterator2;

    [LineNumberTable(new byte[] {159, 183, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ObjectSet()
      : this(51, 0.8f)
    {
    }

    [Signature("(TT;)Z")]
    [LineNumberTable(new byte[] {161, 17, 106, 103, 105, 112, 104, 112, 104, 190})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool contains(object key)
    {
      if (this.size == 0)
        return false;
      int num = Object.instancehelper_hashCode(key);
      int index1 = num & this.mask;
      if (!Object.instancehelper_equals(key, this.keyTable[index1]))
      {
        int index2 = this.hash2(num);
        if (!Object.instancehelper_equals(key, this.keyTable[index2]))
        {
          int index3 = this.hash3(num);
          if (!Object.instancehelper_equals(key, this.keyTable[index3]) && this.getKeyStash(key) == null)
            return false;
        }
      }
      return true;
    }

    [Signature("(TT;)Z")]
    [LineNumberTable(new byte[] {71, 101, 167, 103, 105, 100, 139, 105, 102, 140, 105, 102, 172, 121, 46, 200, 99, 100, 127, 15, 162, 100, 101, 127, 15, 162, 100, 101, 127, 15, 162, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool add(object key)
    {
      if (key == null)
        return false;
      object[] keyTable = this.keyTable;
      int num1 = Object.instancehelper_hashCode(key);
      int index1 = num1 & this.mask;
      object obj1 = keyTable[index1];
      if (Object.instancehelper_equals(key, obj1))
        return false;
      int index2 = this.hash2(num1);
      object obj2 = keyTable[index2];
      if (Object.instancehelper_equals(key, obj2))
        return false;
      int index3 = this.hash3(num1);
      object obj3 = keyTable[index3];
      if (Object.instancehelper_equals(key, obj3))
        return false;
      int capacity = this.capacity;
      for (int index4 = capacity + this.stashSize; capacity < index4; ++capacity)
      {
        if (Object.instancehelper_equals(key, keyTable[capacity]))
          return false;
      }
      if (obj1 == null)
      {
        keyTable[index1] = key;
        ObjectSet objectSet1 = this;
        int size = objectSet1.size;
        ObjectSet objectSet2 = objectSet1;
        int num2 = size;
        objectSet2.size = size + 1;
        int threshold = this.threshold;
        if (num2 >= threshold)
          this.resize(this.capacity << 1);
        return true;
      }
      if (obj2 == null)
      {
        keyTable[index2] = key;
        ObjectSet objectSet1 = this;
        int size = objectSet1.size;
        ObjectSet objectSet2 = objectSet1;
        int num2 = size;
        objectSet2.size = size + 1;
        int threshold = this.threshold;
        if (num2 >= threshold)
          this.resize(this.capacity << 1);
        return true;
      }
      if (obj3 == null)
      {
        keyTable[index3] = key;
        ObjectSet objectSet1 = this;
        int size = objectSet1.size;
        ObjectSet objectSet2 = objectSet1;
        int num2 = size;
        objectSet2.size = size + 1;
        int threshold = this.threshold;
        if (num2 >= threshold)
          this.resize(this.capacity << 1);
        return true;
      }
      this.push(key, index1, obj1, index2, obj2, index3, obj3);
      return true;
    }

    [Signature("<T:Ljava/lang/Object;>([TT;)Larc/struct/ObjectSet<TT;>;")]
    [LineNumberTable(new byte[] {35, 102, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static ObjectSet with(params object[] array)
    {
      ObjectSet objectSet = new ObjectSet();
      objectSet.addAll(array);
      return objectSet;
    }

    [Signature("()Larc/struct/ObjectSet<TT;>.ObjectSetIterator;")]
    [LineNumberTable(new byte[] {161, 153, 104, 108, 172, 109, 107, 167, 109, 107, 167})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual ObjectSet.ObjectSetIterator iterator()
    {
      if (this.iterator1 == null)
      {
        this.iterator1 = new ObjectSet.ObjectSetIterator(this);
        this.iterator2 = new ObjectSet.ObjectSetIterator(this);
      }
      if (this.iterator1.done)
      {
        this.iterator1.reset();
        return this.iterator1;
      }
      if (!this.iterator2.done)
        return new ObjectSet.ObjectSetIterator(this);
      this.iterator2.reset();
      return this.iterator2;
    }

    [Signature("(TT;)Z")]
    [LineNumberTable(new byte[] {160, 182, 103, 105, 112, 105, 110, 162, 104, 112, 105, 110, 162, 104, 112, 105, 110, 162})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool remove(object key)
    {
      int num = Object.instancehelper_hashCode(key);
      int index1 = num & this.mask;
      if (Object.instancehelper_equals(key, this.keyTable[index1]))
      {
        this.keyTable[index1] = (object) null;
        --this.size;
        return true;
      }
      int index2 = this.hash2(num);
      if (Object.instancehelper_equals(key, this.keyTable[index2]))
      {
        this.keyTable[index2] = (object) null;
        --this.size;
        return true;
      }
      int index3 = this.hash3(num);
      if (!Object.instancehelper_equals(key, this.keyTable[index3]))
        return this.removeStash(key);
      this.keyTable[index3] = (object) null;
      --this.size;
      return true;
    }

    [LineNumberTable(new byte[] {161, 8, 105, 103, 118, 102, 103, 103})]
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

    [Signature("(Larc/struct/Seq<+TT;>;)V")]
    [LineNumberTable(new byte[] {116, 115})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addAll(Seq array) => this.addAll(array.items, 0, array.size);

    [Signature("()Larc/struct/Seq<TT;>;")]
    [LineNumberTable(106)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Seq asArray() => this.iterator().toSeq();

    [Signature("([TT;)V")]
    [LineNumberTable(new byte[] {126, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addAll(params object[] array) => this.addAll(array, 0, array.Length);

    [LineNumberTable(new byte[] {28, 127, 10, 108, 122, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ObjectSet(ObjectSet set)
      : this(ByteCodeHelper.d2i(Math.floor((double) ((float) set.capacity * set.loadFactor))), set.loadFactor)
    {
      ObjectSet objectSet = this;
      this.stashSize = set.stashSize;
      ByteCodeHelper.arraycopy((object) set.keyTable, 0, (object) this.keyTable, 0, set.keyTable.Length);
      this.size = set.size;
    }

    [Signature("(Larc/struct/ObjectSet<TT;>;)V")]
    [LineNumberTable(new byte[] {160, 72, 108, 118, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addAll(ObjectSet set)
    {
      this.ensureCapacity(set.size);
      ObjectSet.ObjectSetIterator objectSetIterator = set.iterator();
      while (((Iterator) objectSetIterator).hasNext())
        this.add(((Iterator) objectSetIterator).next());
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isEmpty() => this.size == 0;

    [Signature("()TT;")]
    [LineNumberTable(new byte[] {161, 55, 103, 116, 41, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object first()
    {
      object[] keyTable = this.keyTable;
      int index1 = 0;
      for (int index2 = this.capacity + this.stashSize; index1 < index2; ++index1)
      {
        if (keyTable[index1] != null)
          return keyTable[index1];
      }
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new IllegalStateException("ObjectSet is empty.");
    }

    [LineNumberTable(new byte[] {159, 191, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ObjectSet(int initialCapacity)
      : this(initialCapacity, 0.8f)
    {
    }

    [LineNumberTable(new byte[] {160, 251, 105, 102, 129, 103, 103})]
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

    [LineNumberTable(495)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toString() => new StringBuilder().append('{').append(this.toString(", ")).append('}').toString();

    [Signature("<T:Ljava/lang/Object;>(Larc/struct/Seq<TT;>;)Larc/struct/ObjectSet<TT;>;")]
    [LineNumberTable(new byte[] {41, 102, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static ObjectSet with(Seq array)
    {
      ObjectSet objectSet = new ObjectSet();
      objectSet.addAll(array);
      return objectSet;
    }

    [LineNumberTable(new byte[] {160, 221, 110, 110, 100, 112, 137})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void removeStashIndex([In] int obj0)
    {
      --this.stashSize;
      int index = this.capacity + this.stashSize;
      if (obj0 >= index)
        return;
      this.keyTable[obj0] = this.keyTable[index];
      this.keyTable[index] = (object) null;
    }

    [LineNumberTable(new byte[] {7, 104, 127, 10, 121, 104, 127, 6, 135, 127, 16, 136, 118, 110, 116, 127, 7, 159, 12, 120})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ObjectSet(int initialCapacity, float loadFactor)
    {
      ObjectSet objectSet = this;
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

    [LineNumberTable(new byte[] {161, 73, 142, 103, 117, 105, 111, 127, 2, 159, 2, 135, 147, 103, 103, 103, 100, 102, 101, 12, 230, 69})]
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
      this.keyTable = new object[obj0 + this.stashCapacity];
      int size = this.size;
      this.size = 0;
      this.stashSize = 0;
      if (size <= 0)
        return;
      for (int index = 0; index < num; ++index)
      {
        object obj = keyTable[index];
        if (obj != null)
          this.addResize(obj);
      }
    }

    [Signature("(TT;ITT;ITT;ITT;)V")]
    [LineNumberTable(new byte[] {160, 109, 103, 199, 169, 151, 99, 100, 130, 100, 101, 130, 100, 229, 69, 105, 102, 101, 99, 101, 127, 15, 161, 106, 102, 100, 102, 127, 15, 161, 106, 102, 100, 102, 127, 15, 161, 138, 100, 133, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void push(
      [In] object obj0,
      [In] int obj1,
      [In] object obj2,
      [In] int obj3,
      [In] object obj4,
      [In] int obj5,
      [In] object obj6)
    {
      object[] keyTable = this.keyTable;
      int mask = this.mask;
      int num1 = 0;
      int pushIterations = this.pushIterations;
      object obj;
      while (true)
      {
        switch (Mathf.random(2))
        {
          case 0:
            obj = obj2;
            keyTable[obj1] = obj0;
            break;
          case 1:
            obj = obj4;
            keyTable[obj3] = obj0;
            break;
          default:
            obj = obj6;
            keyTable[obj5] = obj0;
            break;
        }
        int num2 = Object.instancehelper_hashCode(obj);
        obj1 = num2 & mask;
        obj2 = keyTable[obj1];
        if (obj2 != null)
        {
          obj3 = this.hash2(num2);
          obj4 = keyTable[obj3];
          if (obj4 != null)
          {
            obj5 = this.hash3(num2);
            obj6 = keyTable[obj5];
            if (obj6 != null)
            {
              ++num1;
              if (num1 != pushIterations)
                obj0 = obj;
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
      keyTable[obj1] = obj;
      ObjectSet objectSet1 = this;
      int size1 = objectSet1.size;
      ObjectSet objectSet2 = objectSet1;
      int num3 = size1;
      objectSet2.size = size1 + 1;
      int threshold1 = this.threshold;
      if (num3 < threshold1)
        return;
      this.resize(this.capacity << 1);
      return;
label_10:
      keyTable[obj3] = obj;
      ObjectSet objectSet3 = this;
      int size2 = objectSet3.size;
      ObjectSet objectSet4 = objectSet3;
      int num4 = size2;
      objectSet4.size = size2 + 1;
      int threshold2 = this.threshold;
      if (num4 < threshold2)
        return;
      this.resize(this.capacity << 1);
      return;
label_14:
      keyTable[obj5] = obj;
      ObjectSet objectSet5 = this;
      int size3 = objectSet5.size;
      ObjectSet objectSet6 = objectSet5;
      int num5 = size3;
      objectSet6.size = size3 + 1;
      int threshold3 = this.threshold;
      if (num5 < threshold3)
        return;
      this.resize(this.capacity << 1);
      return;
label_19:
      this.addStash(obj);
    }

    [Signature("([TT;II)V")]
    [LineNumberTable(new byte[] {160, 66, 103, 106, 42, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addAll(object[] array, int offset, int length)
    {
      this.ensureCapacity(length);
      int index1 = offset;
      for (int index2 = index1 + length; index1 < index2; ++index1)
        this.add(array[index1]);
    }

    [LineNumberTable(new byte[] {161, 66, 100, 127, 6, 105, 127, 11})]
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

    [Signature("(TT;)V")]
    [LineNumberTable(new byte[] {160, 167, 142, 110, 103, 161, 110, 105, 110, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void addStash([In] object obj0)
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

    [Signature("(TT;)V")]
    [LineNumberTable(new byte[] {160, 80, 103, 105, 105, 99, 105, 127, 12, 161, 105, 107, 100, 106, 127, 12, 161, 105, 107, 100, 106, 127, 12, 161, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void addResize([In] object obj0)
    {
      int num1 = Object.instancehelper_hashCode(obj0);
      int index1 = num1 & this.mask;
      object obj1 = this.keyTable[index1];
      if (obj1 == null)
      {
        this.keyTable[index1] = obj0;
        ObjectSet objectSet1 = this;
        int size = objectSet1.size;
        ObjectSet objectSet2 = objectSet1;
        int num2 = size;
        objectSet2.size = size + 1;
        int threshold = this.threshold;
        if (num2 < threshold)
          return;
        this.resize(this.capacity << 1);
      }
      else
      {
        int index2 = this.hash2(num1);
        object obj2 = this.keyTable[index2];
        if (obj2 == null)
        {
          this.keyTable[index2] = obj0;
          ObjectSet objectSet1 = this;
          int size = objectSet1.size;
          ObjectSet objectSet2 = objectSet1;
          int num2 = size;
          objectSet2.size = size + 1;
          int threshold = this.threshold;
          if (num2 < threshold)
            return;
          this.resize(this.capacity << 1);
        }
        else
        {
          int index3 = this.hash3(num1);
          object obj3 = this.keyTable[index3];
          if (obj3 == null)
          {
            this.keyTable[index3] = obj0;
            ObjectSet objectSet1 = this;
            int size = objectSet1.size;
            ObjectSet objectSet2 = objectSet1;
            int num2 = size;
            objectSet2.size = size + 1;
            int threshold = this.threshold;
            if (num2 < threshold)
              return;
            this.resize(this.capacity << 1);
          }
          else
            this.push(obj0, index1, obj1, index2, obj2, index3, obj3);
        }
      }
    }

    [Signature("(TT;)Z")]
    [LineNumberTable(new byte[] {160, 208, 103, 116, 107, 103, 110, 226, 60, 230, 71})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual bool removeStash([In] object obj0)
    {
      object[] keyTable = this.keyTable;
      int capacity = this.capacity;
      for (int index = capacity + this.stashSize; capacity < index; ++capacity)
      {
        if (Object.instancehelper_equals(obj0, keyTable[capacity]))
        {
          this.removeStashIndex(capacity);
          --this.size;
          return true;
        }
      }
      return false;
    }

    [Signature("(TT;)TT;")]
    [LineNumberTable(new byte[] {161, 48, 103, 116, 47, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private object getKeyStash([In] object obj0)
    {
      object[] keyTable = this.keyTable;
      int capacity = this.capacity;
      for (int index = capacity + this.stashSize; capacity < index; ++capacity)
      {
        if (Object.instancehelper_equals(obj0, keyTable[capacity]))
          return keyTable[capacity];
      }
      return (object) null;
    }

    [LineNumberTable(new byte[] {161, 129, 110, 104, 103, 99, 104, 100, 101, 104, 130, 104, 100, 101, 104, 104, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toString(string separator)
    {
      if (this.size == 0)
        return "";
      StringBuilder stringBuilder = new StringBuilder(32);
      object[] keyTable = this.keyTable;
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
        stringBuilder.append(separator);
        stringBuilder.append(obj2);
      }
label_9:
      return stringBuilder.toString();
    }

    [Signature("(Larc/func/Boolf<TT;>;)Larc/struct/ObjectSet<TT;>;")]
    [LineNumberTable(new byte[] {48, 102, 118, 113, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual ObjectSet select(Boolf predicate)
    {
      ObjectSet objectSet = new ObjectSet();
      ObjectSet.ObjectSetIterator objectSetIterator = this.iterator();
      while (((Iterator) objectSetIterator).hasNext())
      {
        object key = ((Iterator) objectSetIterator).next();
        if (predicate.get(key))
          objectSet.add(key);
      }
      return objectSet;
    }

    [Signature("(Larc/func/Cons<-TT;>;)V")]
    [LineNumberTable(new byte[] {61, 118, 103, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void each(Cons cons)
    {
      ObjectSet.ObjectSetIterator objectSetIterator = this.iterator();
      while (((Iterator) objectSetIterator).hasNext())
      {
        object obj = ((Iterator) objectSetIterator).next();
        cons.get(obj);
      }
    }

    [Signature("(Larc/struct/Seq<+TT;>;II)V")]
    [LineNumberTable(new byte[] {120, 107, 127, 43, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addAll(Seq array, int offset, int length)
    {
      if (offset + length > array.size)
      {
        string str = new StringBuilder().append("offset + length must be <= size: ").append(offset).append(" + ").append(length).append(" <= ").append(array.size).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException(str);
      }
      this.addAll(array.items, offset, length);
    }

    [LineNumberTable(new byte[] {160, 239, 127, 10, 113, 106, 104, 103})]
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

    [Signature("(TT;)TT;")]
    [LineNumberTable(new byte[] {161, 32, 103, 105, 105, 105, 104, 105, 105, 104, 105, 177})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object get(object key)
    {
      int num = Object.instancehelper_hashCode(key);
      object obj = this.keyTable[num & this.mask];
      if (!Object.instancehelper_equals(key, obj))
      {
        obj = this.keyTable[this.hash2(num)];
        if (!Object.instancehelper_equals(key, obj))
        {
          obj = this.keyTable[this.hash3(num)];
          if (!Object.instancehelper_equals(key, obj))
            return this.getKeyStash(key);
        }
      }
      return obj;
    }

    [LineNumberTable(new byte[] {161, 108, 98, 116, 58, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int hashCode()
    {
      int num = 0;
      int index1 = 0;
      for (int index2 = this.capacity + this.stashSize; index1 < index2; ++index1)
      {
        if (this.keyTable[index1] != null)
          num += Object.instancehelper_hashCode(this.keyTable[index1]);
      }
      return num;
    }

    [LineNumberTable(new byte[] {161, 115, 106, 103, 112, 103, 116, 50, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool equals(object obj)
    {
      if (!(obj is ObjectSet))
        return false;
      ObjectSet objectSet = (ObjectSet) obj;
      if (objectSet.size != this.size)
        return false;
      object[] keyTable = this.keyTable;
      int index1 = 0;
      for (int index2 = this.capacity + this.stashSize; index1 < index2; ++index1)
      {
        if (keyTable[index1] != null && !objectSet.contains(keyTable[index1]))
          return false;
      }
      return true;
    }

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(21)]
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

    [Signature("Ljava/lang/Object;Ljava/lang/Iterable<TT;>;Ljava/util/Iterator<TT;>;")]
    [Implements(new string[] {"java.lang.Iterable", "java.util.Iterator"})]
    public class ObjectSetIterator : Object, Iterable, IEnumerable, Iterator
    {
      public bool hasNext;
      internal int nextIndex;
      internal int currentIndex;
      internal bool done;
      [Modifiers]
      internal ObjectSet this\u00240;

      [Signature("()Larc/struct/Seq<TT;>;")]
      [LineNumberTable(613)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual Seq toSeq() => this.toSeq(new Seq(true, this.this\u00240.size));

      [Signature("(Larc/struct/Seq<TT;>;)Larc/struct/Seq<TT;>;")]
      [LineNumberTable(new byte[] {161, 236, 104, 110})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual Seq toSeq(Seq array)
      {
        while (this.hasNext)
          array.add(this.next());
        return array;
      }

      [LineNumberTable(new byte[] {161, 182, 103, 103, 102, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void reset()
      {
        this.currentIndex = -1;
        this.nextIndex = -1;
        this.findNextIndex();
        this.done = false;
      }

      [LineNumberTable(new byte[] {161, 189, 103, 127, 15, 116, 103, 162})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void findNextIndex()
      {
        this.hasNext = false;
        int num1 = this.this\u00240.capacity + this.this\u00240.stashSize;
        do
        {
          ObjectSet.ObjectSetIterator objectSetIterator1 = this;
          int num2 = objectSetIterator1.nextIndex + 1;
          ObjectSet.ObjectSetIterator objectSetIterator2 = objectSetIterator1;
          int num3 = num2;
          objectSetIterator2.nextIndex = num2;
          int num4 = num1;
          if (num3 >= num4)
            goto label_4;
        }
        while (this.this\u00240.keyTable[this.nextIndex] == null);
        goto label_3;
label_4:
        return;
label_3:
        this.hasNext = true;
      }

      [Signature("()TT;")]
      [LineNumberTable(new byte[] {161, 222, 115, 115, 108, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual object next()
      {
        if (!this.hasNext)
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new NoSuchElementException();
        }
        object obj = this.this\u00240.keyTable[this.nextIndex];
        this.currentIndex = this.nextIndex;
        this.findNextIndex();
        return obj;
      }

      [Signature("()Larc/struct/ObjectSet<TT;>.ObjectSetIterator;")]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual ObjectSet.ObjectSetIterator iterator() => this;

      [LineNumberTable(new byte[] {161, 176, 111, 102, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public ObjectSetIterator(ObjectSet _param1)
      {
        this.this\u00240 = _param1;
        // ISSUE: explicit constructor call
        base.\u002Ector();
        ObjectSet.ObjectSetIterator objectSetIterator = this;
        this.reset();
        this.done = true;
      }

      [LineNumberTable(new byte[] {161, 200, 121, 115, 113, 110, 136, 147, 103, 115})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void remove()
      {
        if (this.currentIndex < 0)
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalStateException("next must be called before remove.");
        }
        if (this.currentIndex >= this.this\u00240.capacity)
        {
          this.this\u00240.removeStashIndex(this.currentIndex);
          this.nextIndex = this.currentIndex - 1;
          this.findNextIndex();
        }
        else
          this.this\u00240.keyTable[this.currentIndex] = (object) null;
        this.currentIndex = -1;
        --this.this\u00240.size;
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual bool hasNext()
      {
        if (!this.hasNext)
          this.done = true;
        return this.hasNext;
      }

      [Modifiers]
      [EditorBrowsable(EditorBrowsableState.Never)]
      [LineNumberTable(541)]
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
    }
  }
}
