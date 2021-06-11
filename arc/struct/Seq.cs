// Decompiled with JetBrains decompiler
// Type: arc.struct.Seq
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
using java.lang.reflect;
using java.util;
using java.util.function;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.@struct
{
  [Signature("<T:Ljava/lang/Object;>Ljava/lang/Object;Ljava/lang/Iterable<TT;>;Larc/util/Eachable<TT;>;")]
  [Implements(new string[] {"java.lang.Iterable", "arc.util.Eachable"})]
  public class Seq : Object, Iterable, IEnumerable, Eachable
  {
    public static int iteratorsAllocated;
    [Signature("[TT;")]
    public object[] items;
    public int size;
    public bool ordered;
    [Signature("Larc/struct/Seq$SeqIterable<TT;>;")]
    [Nullable(new object[] {64, "Larc/util/Nullable;"})]
    private Seq.SeqIterable iterable;

    [LineNumberTable(new byte[] {159, 178, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Seq(int capacity)
      : this(true, capacity)
    {
    }

    [Signature("<T:Ljava/lang/Object;>([TT;)Larc/struct/Seq<TT;>;")]
    [LineNumberTable(126)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Seq with(params object[] array) => new Seq(array);

    [Signature("(TT;)Z")]
    [LineNumberTable(481)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool contains(object value) => this.contains(value, false);

    [LineNumberTable(new byte[] {163, 102, 110, 103, 104, 105, 106, 107, 108, 10, 198, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toString()
    {
      if (this.size == 0)
        return "[]";
      object[] items = this.items;
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

    [Signature("()Ljava/util/Iterator<TT;>;")]
    [LineNumberTable(new byte[] {163, 139, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Iterator iterator()
    {
      if (this.iterable == null)
        this.iterable = new Seq.SeqIterable(this);
      return this.iterable.iterator();
    }

    [Signature("(Larc/func/Boolf<TT;>;)Z")]
    [LineNumberTable(265)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool contains(Boolf predicate) => this.find(predicate) != null;

    [Signature("(Larc/func/Boolf<TT;>;)I")]
    [LineNumberTable(new byte[] {162, 209, 98, 107, 112, 4, 230, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int count(Boolf predicate)
    {
      int num = 0;
      for (int index = 0; index < this.size; ++index)
      {
        if (predicate.get(this.items[index]))
          ++num;
      }
      return num;
    }

    [Signature("(I)TT;")]
    [LineNumberTable(new byte[] {161, 80, 127, 36})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object get(int index)
    {
      if (index >= this.size)
      {
        string str = new StringBuilder().append("index can't be >= size: ").append(index).append(" >= ").append(this.size).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IndexOutOfBoundsException(str);
      }
      return this.items[index];
    }

    [Signature("(TT;Z)I")]
    [LineNumberTable(new byte[] {159, 14, 130, 103, 102, 109, 45, 168, 109, 45, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int indexOf(object value, bool identity)
    {
      int num = identity ? 1 : 0;
      object[] items = this.items;
      if (num != 0 || value == null)
      {
        int index = 0;
        for (int size = this.size; index < size; ++index)
        {
          if (object.ReferenceEquals(items[index], value))
            return index;
        }
      }
      else
      {
        int index = 0;
        for (int size = this.size; index < size; ++index)
        {
          if (Object.instancehelper_equals(value, items[index]))
            return index;
        }
      }
      return -1;
    }

    [Signature("(I)TT;")]
    [LineNumberTable(new byte[] {161, 226, 127, 36, 103, 100, 110, 104, 149, 107, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object remove(int index)
    {
      if (index >= this.size)
      {
        string str = new StringBuilder().append("index can't be >= size: ").append(index).append(" >= ").append(this.size).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IndexOutOfBoundsException(str);
      }
      object[] items = this.items;
      object obj = items[index];
      --this.size;
      if (this.ordered)
        ByteCodeHelper.arraycopy((object) items, index + 1, (object) items, index, this.size - index);
      else
        items[index] = items[this.size];
      items[this.size] = (object) null;
      return obj;
    }

    [Signature("(TT;)V")]
    [LineNumberTable(new byte[] {160, 249, 103, 127, 11, 118})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void add(object value)
    {
      object[] objArray1 = this.items;
      if (this.size == objArray1.Length)
        objArray1 = this.resize(Math.max(8, ByteCodeHelper.f2i((float) this.size * 1.75f)));
      object[] objArray2 = objArray1;
      Seq seq1 = this;
      int size = seq1.size;
      Seq seq2 = seq1;
      int index = size;
      seq2.size = size + 1;
      object obj = value;
      objArray2[index] = obj;
    }

    [Signature("()Larc/struct/Seq<TT;>;")]
    [LineNumberTable(new byte[] {162, 93, 103, 109, 36, 134, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Seq clear()
    {
      object[] items = this.items;
      int index = 0;
      for (int size = this.size; index < size; ++index)
        items[index] = (object) null;
      this.size = 0;
      return this;
    }

    [Signature("(TT;Z)Z")]
    [LineNumberTable(new byte[] {159, 20, 162, 103, 105, 102, 100, 145, 100, 145})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool contains(object value, bool identity)
    {
      int num1 = identity ? 1 : 0;
      object[] items = this.items;
      int num2 = this.size - 1;
      if (num1 != 0 || value == null)
      {
        while (num2 >= 0)
        {
          object[] objArray = items;
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
          object[] objArray = items;
          int index = num2;
          num2 += -1;
          object obj2 = objArray[index];
          if (Object.instancehelper_equals(obj1, obj2))
            return true;
        }
      }
      return false;
    }

    [Signature("(TT;Z)Z")]
    [LineNumberTable(new byte[] {158, 255, 162, 103, 102, 109, 107, 104, 226, 61, 232, 71, 109, 107, 104, 226, 61, 230, 71})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool remove(object value, bool identity)
    {
      int num = identity ? 1 : 0;
      object[] items = this.items;
      if (num != 0 || value == null)
      {
        int index = 0;
        for (int size = this.size; index < size; ++index)
        {
          if (object.ReferenceEquals(items[index], value))
          {
            this.remove(index);
            return true;
          }
        }
      }
      else
      {
        int index = 0;
        for (int size = this.size; index < size; ++index)
        {
          if (Object.instancehelper_equals(value, items[index]))
          {
            this.remove(index);
            return true;
          }
        }
      }
      return false;
    }

    [Signature("(ITT;)V")]
    [LineNumberTable(new byte[] {161, 90, 127, 36, 103, 127, 11, 104, 149, 107, 110, 100})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void insert(int index, object value)
    {
      if (index > this.size)
      {
        string str = new StringBuilder().append("index can't be > size: ").append(index).append(" > ").append(this.size).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IndexOutOfBoundsException(str);
      }
      object[] objArray = this.items;
      if (this.size == objArray.Length)
        objArray = this.resize(Math.max(8, ByteCodeHelper.f2i((float) this.size * 1.75f)));
      if (this.ordered)
        ByteCodeHelper.arraycopy((object) objArray, index, (object) objArray, index + 1, this.size - index);
      else
        objArray[this.size] = objArray[index];
      ++this.size;
      objArray[index] = value;
    }

    [LineNumberTable(new byte[] {159, 173, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Seq()
      : this(true, 16)
    {
    }

    [LineNumberTable(new byte[] {161, 102, 127, 36, 127, 36, 103, 100, 102, 100})]
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
      object[] items = this.items;
      object obj = items[first];
      items[first] = items[second];
      items[second] = obj;
    }

    [Signature("()TT;")]
    [LineNumberTable(new byte[] {162, 66, 120})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object peek()
    {
      if (this.size == 0)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalStateException("Array is empty.");
      }
      return this.items[this.size - 1];
    }

    [LineNumberTable(new byte[] {162, 249, 103, 120, 101, 101, 103, 230, 60, 230, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void reverse()
    {
      object[] items = this.items;
      int index1 = 0;
      int num = this.size - 1;
      for (int index2 = this.size / 2; index1 < index2; ++index1)
      {
        int index3 = num - index1;
        object obj = items[index1];
        items[index1] = items[index3];
        items[index3] = obj;
      }
    }

    [Signature("<R:Ljava/lang/Object;>(Larc/func/Func<TT;TR;>;)Larc/struct/Seq<TR;>;")]
    [LineNumberTable(new byte[] {160, 117, 108, 107, 52, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Seq map(Func mapper)
    {
      Seq seq = new Seq(this.size);
      for (int index = 0; index < this.size; ++index)
        seq.add(mapper.get(this.items[index]));
      return seq;
    }

    [Signature("(Larc/func/Boolf<TT;>;)Larc/struct/Seq<TT;>;")]
    [LineNumberTable(new byte[] {162, 194, 102, 107, 112, 14, 230, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Seq select(Boolf predicate)
    {
      Seq seq = new Seq();
      for (int index = 0; index < this.size; ++index)
      {
        if (predicate.get(this.items[index]))
          seq.add(this.items[index]);
      }
      return seq;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isEmpty() => this.size == 0;

    [Signature("()TT;")]
    [LineNumberTable(new byte[] {162, 72, 120})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object first()
    {
      if (this.size == 0)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalStateException("Array is empty.");
      }
      return this.items[0];
    }

    [Signature("<V:Ljava/lang/Object;>(Ljava/lang/Class;)[TV;")]
    [LineNumberTable(new byte[] {163, 63, 114, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object[] toArray(Class type)
    {
      object[] objArray = (object[]) Array.newInstance(type, this.size);
      ByteCodeHelper.arraycopy((object) this.items, 0, (object) objArray, 0, this.size);
      return objArray;
    }

    [Signature("(Ljava/util/Comparator<-TT;>;)Larc/struct/Seq<TT;>;")]
    [LineNumberTable(new byte[] {162, 156, 120})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Seq sort(Comparator comparator)
    {
      Sort.instance().sort(this.items, comparator, 0, this.size);
      return this;
    }

    [Signature("(Larc/func/Cons<-TT;>;)V")]
    [LineNumberTable(new byte[] {160, 85, 107, 46, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void each(Cons consumer)
    {
      for (int index = 0; index < this.size; ++index)
        consumer.get(this.items[index]);
    }

    [Signature("(TT;)Larc/struct/Seq<TT;>;")]
    [LineNumberTable(new byte[] {160, 234, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Seq and(object value)
    {
      this.add(value);
      return this;
    }

    [Signature("()TT;")]
    [LineNumberTable(913)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object random() => this.random(Mathf.rand);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool any() => this.size > 0;

    [Signature("(Larc/func/Boolf<TT;>;)Larc/struct/Seq<TT;>;")]
    [LineNumberTable(new byte[] {162, 0, 103, 104, 110, 168})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Seq removeAll(Boolf pred)
    {
      Iterator iterator = this.iterator();
      while (iterator.hasNext())
      {
        if (pred.get(iterator.next()))
          iterator.remove();
      }
      return this;
    }

    [Signature("(Larc/func/Floatf<TT;>;)F")]
    [LineNumberTable(new byte[] {126, 102, 107, 51, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float sumf(Floatf summer)
    {
      float num = 0.0f;
      for (int index = 0; index < this.size; ++index)
        num += summer.get(this.items[index]);
      return num;
    }

    [Signature("(Larc/func/Floatf<-TT;>;)Larc/struct/Seq<TT;>;")]
    [LineNumberTable(new byte[] {162, 161, 125})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Seq sort(Floatf comparator)
    {
      Sort.instance().sort(this.items, Structs.comparingFloat(comparator), 0, this.size);
      return this;
    }

    [Signature("()Larc/struct/Seq<TT;>;")]
    [LineNumberTable(new byte[] {162, 150, 119})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Seq sort()
    {
      Sort.instance().sort(this.items, 0, this.size);
      return this;
    }

    [LineNumberTable(new byte[] {159, 130, 98, 104, 103, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Seq(bool ordered, int capacity)
    {
      int num = ordered ? 1 : 0;
      // ISSUE: explicit constructor call
      base.\u002Ector();
      Seq seq = this;
      this.ordered = num != 0;
      this.items = new object[capacity];
    }

    [Signature("(TT;)Z")]
    [LineNumberTable(553)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool remove(object value) => this.remove(value, false);

    [Signature("(Ljava/lang/Class<*>;)V")]
    [LineNumberTable(new byte[] {17, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Seq(Class arrayType)
      : this(true, 16, arrayType)
    {
    }

    [Signature("(Larc/func/Boolf<TT;>;Larc/func/Floatf<TT;>;)TT;")]
    [LineNumberTable(new byte[] {160, 177, 98, 102, 107, 105, 107, 106, 101, 98, 227, 58, 230, 73})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object min(Boolf filter, Floatf func)
    {
      object obj1 = (object) null;
      float num1 = float.MaxValue;
      for (int index = 0; index < this.size; ++index)
      {
        object obj2 = this.items[index];
        if (filter.get(obj2))
        {
          float num2 = func.get(obj2);
          if ((double) num2 <= (double) num1)
          {
            obj1 = obj2;
            num1 = num2;
          }
        }
      }
      return obj1;
    }

    [LineNumberTable(new byte[] {159, 132, 98, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Seq(bool ordered)
      : this(ordered, 16)
    {
    }

    [Signature("(ZILjava/lang/Class<*>;)V")]
    [LineNumberTable(new byte[] {159, 127, 66, 104, 103, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Seq(bool ordered, int capacity, Class arrayType)
    {
      int num = ordered ? 1 : 0;
      // ISSUE: explicit constructor call
      base.\u002Ector();
      Seq seq = this;
      this.ordered = num != 0;
      this.items = (object[]) Array.newInstance(arrayType, capacity);
    }

    [Signature("(TT;)TT;")]
    [LineNumberTable(new byte[] {163, 37, 106, 106, 144, 136, 171, 111, 100, 164})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object random(object exclude)
    {
      if (exclude == null)
        return this.random();
      if (this.size == 0)
        return (object) null;
      if (this.size == 1)
        return this.first();
      int num = this.indexOf(exclude);
      if (num == -1)
        return this.random();
      int index = Mathf.random(0, this.size - 2);
      if (index >= num)
        ++index;
      return this.items[index];
    }

    [Signature("(Larc/func/Floatf<TT;>;)TT;")]
    [LineNumberTable(new byte[] {160, 192, 98, 102, 107, 105, 106, 101, 98, 227, 59, 230, 72})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object min(Floatf func)
    {
      object obj1 = (object) null;
      float num1 = float.MaxValue;
      for (int index = 0; index < this.size; ++index)
      {
        object obj2 = this.items[index];
        float num2 = func.get(obj2);
        if ((double) num2 <= (double) num1)
        {
          obj1 = obj2;
          num1 = num2;
        }
      }
      return obj1;
    }

    [Signature("<E:TT;>(Larc/func/Boolf<-TT;>;Larc/func/Cons<TE;>;)V")]
    [LineNumberTable(new byte[] {160, 78, 107, 62, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void each(Boolf pred, Cons consumer)
    {
      for (int index = 0; index < this.size; ++index)
      {
        if (pred.get(this.items[index]))
          consumer.get(this.items[index]);
      }
    }

    [Signature("(Larc/func/Boolf<TT;>;)TT;")]
    [LineNumberTable(new byte[] {160, 220, 107, 112, 9, 230, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object find(Boolf predicate)
    {
      for (int index = 0; index < this.size; ++index)
      {
        if (predicate.get(this.items[index]))
          return this.items[index];
      }
      return (object) null;
    }

    [Signature("(Larc/func/Boolf<TT;>;)I")]
    [LineNumberTable(new byte[] {161, 156, 103, 109, 45, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int indexOf(Boolf value)
    {
      object[] items = this.items;
      int index = 0;
      for (int size = this.size; index < size; ++index)
      {
        if (value.get(items[index]))
          return index;
      }
      return -1;
    }

    [Signature("([TT;)Larc/struct/Seq<TT;>;")]
    [LineNumberTable(new byte[] {161, 40, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Seq addAll(params object[] array)
    {
      this.addAll(array, 0, array.Length);
      return this;
    }

    [Signature("(Larc/func/Boolf<TT;>;)Z")]
    [LineNumberTable(new byte[] {161, 189, 107, 112, 104, 226, 61, 230, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool remove(Boolf value)
    {
      for (int index = 0; index < this.size; ++index)
      {
        if (value.get(this.items[index]))
        {
          this.remove(index);
          return true;
        }
      }
      return false;
    }

    [Signature("(Larc/struct/Seq<+TT;>;)Larc/struct/Seq<TT;>;")]
    [LineNumberTable(new byte[] {161, 26, 148})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Seq addAll(Seq array)
    {
      this.addAll(array.items, 0, array.size);
      return this;
    }

    [Signature("(TT;TT;TT;TT;)V")]
    [LineNumberTable(new byte[] {161, 16, 103, 127, 13, 105, 107, 107, 108, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void add(object value1, object value2, object value3, object value4)
    {
      object[] objArray = this.items;
      if (this.size + 3 >= objArray.Length)
        objArray = this.resize(Math.max(8, ByteCodeHelper.f2i((float) this.size * 1.8f)));
      objArray[this.size] = value1;
      objArray[this.size + 1] = value2;
      objArray[this.size + 2] = value3;
      objArray[this.size + 3] = value4;
      this.size += 4;
    }

    [Signature("(TT;TT;TT;)V")]
    [LineNumberTable(new byte[] {161, 7, 103, 127, 13, 105, 107, 107, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void add(object value1, object value2, object value3)
    {
      object[] objArray = this.items;
      if (this.size + 2 >= objArray.Length)
        objArray = this.resize(Math.max(8, ByteCodeHelper.f2i((float) this.size * 1.75f)));
      objArray[this.size] = value1;
      objArray[this.size + 1] = value2;
      objArray[this.size + 2] = value3;
      this.size += 3;
    }

    [Signature("(TT;TT;)V")]
    [LineNumberTable(new byte[] {160, 255, 103, 127, 13, 105, 107, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void add(object value1, object value2)
    {
      object[] objArray = this.items;
      if (this.size + 1 >= objArray.Length)
        objArray = this.resize(Math.max(8, ByteCodeHelper.f2i((float) this.size * 1.75f)));
      objArray[this.size] = value1;
      objArray[this.size + 1] = value2;
      this.size += 2;
    }

    [Signature("(Larc/func/Intf<TT;>;)Larc/struct/IntSeq;")]
    [LineNumberTable(new byte[] {160, 126, 108, 107, 52, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual IntSeq mapInt(Intf mapper)
    {
      IntSeq intSeq = new IntSeq(this.size);
      for (int index = 0; index < this.size; ++index)
        intSeq.add(mapper.get(this.items[index]));
      return intSeq;
    }

    [Signature("()TT;")]
    [LineNumberTable(new byte[] {162, 57, 120, 110, 110, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object pop()
    {
      if (this.size == 0)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalStateException("Array is empty.");
      }
      --this.size;
      object obj = this.items[this.size];
      this.items[this.size] = (object) null;
      return obj;
    }

    [Signature("(Ljava/lang/String;Larc/func/Func<TT;Ljava/lang/String;>;)Ljava/lang/String;")]
    [LineNumberTable(new byte[] {163, 116, 110, 103, 104, 117, 107, 104, 21, 198})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toString(string separator, Func stringifier)
    {
      if (this.size == 0)
        return "";
      object[] items = this.items;
      StringBuilder stringBuilder = new StringBuilder(32);
      stringBuilder.append((string) stringifier.get(items[0]));
      for (int index = 1; index < this.size; ++index)
      {
        stringBuilder.append(separator);
        stringBuilder.append((string) stringifier.get(items[index]));
      }
      return stringBuilder.toString();
    }

    [Signature("(Larc/func/Intf<TT;>;)I")]
    [LineNumberTable(new byte[] {160, 70, 98, 107, 49, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int sum(Intf summer)
    {
      int num = 0;
      for (int index = 0; index < this.size; ++index)
        num += summer.get(this.items[index]);
      return num;
    }

    [Signature("()Larc/struct/Seq<TT;>;")]
    [LineNumberTable(166)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Seq copy() => new Seq(this);

    [LineNumberTable(1010)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toString(string separator) => this.toString(separator, (Func) new Seq.__\u003C\u003EAnon4());

    [Signature("(Larc/struct/Seq<+TT;>;)V")]
    [LineNumberTable(new byte[] {26, 127, 5, 108, 121})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Seq(Seq array)
      : this(array.ordered, array.size, Object.instancehelper_getClass((object) array.items).getComponentType())
    {
      Seq seq = this;
      this.size = array.size;
      ByteCodeHelper.arraycopy((object) array.items, 0, (object) this.items, 0, this.size);
    }

    [Signature("(TT;)I")]
    [LineNumberTable(504)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int indexOf(object value) => this.indexOf(value, false);

    [Signature("(Larc/struct/Seq<+TT;>;)V")]
    [LineNumberTable(new byte[] {161, 69, 103, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void set(Seq array)
    {
      this.clear();
      this.addAll(array);
    }

    [LineNumberTable(new byte[] {163, 17, 127, 10, 106, 107, 41, 134, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void truncate(int newSize)
    {
      if (newSize < 0)
      {
        string str = new StringBuilder().append("newSize must be >= 0: ").append(newSize).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException(str);
      }
      if (this.size <= newSize)
        return;
      for (int index = newSize; index < this.size; ++index)
        this.items[index] = (object) null;
      this.size = newSize;
    }

    [LineNumberTable(new byte[] {163, 3, 103, 109, 103, 100, 102, 228, 60, 230, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void shuffle()
    {
      object[] items = this.items;
      for (int range = this.size - 1; range >= 0; range += -1)
      {
        int index = Mathf.random(range);
        object obj = items[range];
        items[range] = items[index];
        items[index] = obj;
      }
    }

    [Signature("(Ljava/util/Comparator<TT;>;)TT;")]
    [LineNumberTable(new byte[] {160, 155, 98, 107, 105, 110, 226, 61, 230, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object min(Comparator func)
    {
      object obj1 = (object) null;
      for (int index = 0; index < this.size; ++index)
      {
        object obj2 = this.items[index];
        if (obj1 == null || func.compare(obj1, obj2) > 0)
          obj1 = obj2;
      }
      return obj1;
    }

    [Signature("(Larc/struct/Seq<+TT;>;)Z")]
    [LineNumberTable(636)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool removeAll(Seq array) => this.removeAll(array, false);

    [Signature("(Larc/func/Floatf<TT;>;)TT;")]
    [LineNumberTable(new byte[] {160, 206, 98, 102, 107, 105, 106, 101, 98, 227, 59, 230, 72})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object max(Floatf func)
    {
      object obj1 = (object) null;
      float num1 = float.NegativeInfinity;
      for (int index = 0; index < this.size; ++index)
      {
        object obj2 = this.items[index];
        float num2 = func.get(obj2);
        if ((double) num2 >= (double) num1)
        {
          obj1 = obj2;
          num1 = num2;
        }
      }
      return obj1;
    }

    [Signature("(Larc/struct/Seq<TT;>;Larc/func/Boolf<TT;>;)Larc/struct/Seq<TT;>;")]
    [LineNumberTable(new byte[] {162, 171, 103, 242, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Seq selectFrom(Seq @base, Boolf predicate)
    {
      this.clear();
      @base.each((Cons) new Seq.__\u003C\u003EAnon2(this, predicate));
      return this;
    }

    [Signature("<T:Ljava/lang/Object;>([TT;Larc/func/Boolf<TT;>;)Larc/struct/Seq<TT;>;")]
    [LineNumberTable(new byte[] {89, 104, 103, 107, 9, 230, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Seq select(object[] array, Boolf test)
    {
      Seq seq = new Seq(array.Length);
      for (int index = 0; index < array.Length; ++index)
      {
        if (test.get(array[index]))
          seq.add(array[index]);
      }
      return seq;
    }

    [Signature("(Larc/func/Boolf<TT;>;)Larc/struct/Seq<TT;>;")]
    [LineNumberTable(831)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Seq filter(Boolf predicate) => this.removeAll((Boolf) new Seq.__\u003C\u003EAnon3(predicate));

    [Signature("<R:Ljava/lang/Object;>()Larc/struct/Seq<TR;>;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Seq @as() => this;

    [Signature("<T:Ljava/lang/Object;>([Ljava/lang/Object;)Larc/struct/Seq<TT;>;")]
    [LineNumberTable(new byte[] {63, 102, 112, 105, 144, 232, 60, 230, 71})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Seq withArrays(params object[] arrays)
    {
      Seq seq = new Seq();
      object[] objArray = arrays;
      int length = objArray.Length;
      for (int index = 0; index < length; ++index)
      {
        object obj = objArray[index];
        if (obj is Seq)
          seq.addAll((Seq) obj);
        else
          seq.add(obj);
      }
      return seq;
    }

    [Signature("(F)TT;")]
    [LineNumberTable(new byte[] {161, 75, 106})]
    [Nullable(new object[] {64, "Larc/util/Nullable;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object getFrac(float index) => this.isEmpty() ? (object) null : this.get(Mathf.clamp(ByteCodeHelper.f2i(index * (float) this.size), 0, this.size - 1));

    [Signature("(Larc/math/Rand;)TT;")]
    [LineNumberTable(new byte[] {163, 25, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object random(Rand rand) => this.size == 0 ? (object) null : this.items[rand.random(0, this.size - 1)];

    [Signature("(Larc/struct/Seq<+TT;>;Z)Z")]
    [LineNumberTable(new byte[] {158, 237, 98, 103, 98, 103, 102, 113, 106, 104, 109, 105, 100, 226, 60, 8, 237, 75, 113, 106, 104, 109, 105, 100, 226, 60, 8, 232, 75})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool removeAll(Seq array, bool identity)
    {
      int num1 = identity ? 1 : 0;
      int size1 = this.size;
      int num2 = size1;
      object[] items = this.items;
      if (num1 != 0)
      {
        int index1 = 0;
        for (int size2 = array.size; index1 < size2; ++index1)
        {
          object objA = array.get(index1);
          for (int index2 = 0; index2 < size1; ++index2)
          {
            if (object.ReferenceEquals(objA, items[index2]))
            {
              this.remove(index2);
              size1 += -1;
              break;
            }
          }
        }
      }
      else
      {
        int index1 = 0;
        for (int size2 = array.size; index1 < size2; ++index1)
        {
          object obj = array.get(index1);
          for (int index2 = 0; index2 < size1; ++index2)
          {
            if (Object.instancehelper_equals(obj, items[index2]))
            {
              this.remove(index2);
              size1 += -1;
              break;
            }
          }
        }
      }
      return size1 != num2;
    }

    [Signature("<T:Ljava/lang/Object;>(Ljava/lang/Iterable<TT;>;)Larc/struct/Seq<TT;>;")]
    [LineNumberTable(new byte[] {80, 102, 118, 103, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Seq with(Iterable array)
    {
      Seq seq = new Seq();
      Iterator iterator = array.iterator();
      while (iterator.hasNext())
      {
        object obj = iterator.next();
        seq.add(obj);
      }
      return seq;
    }

    [Signature("<R:Ljava/lang/Object;>()Larc/struct/Seq<TR;>;")]
    [LineNumberTable(new byte[] {160, 99, 102, 107, 52, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Seq flatten()
    {
      Seq seq = new Seq();
      for (int index = 0; index < this.size; ++index)
        seq.addAll((Seq) this.items[index]);
      return seq;
    }

    [Signature("()Larc/struct/ObjectSet<TT;>;")]
    [LineNumberTable(162)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual ObjectSet asSet() => ObjectSet.with(this);

    [Signature("<U::Ljava/lang/Comparable<-TU;>;>(Larc/func/Func<-TT;+TU;>;)Larc/struct/Seq<TT;>;")]
    [LineNumberTable(new byte[] {162, 166, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Seq sortComparing(Func keyExtractor)
    {
      this.sort(Structs.comparing(keyExtractor));
      return this;
    }

    [Signature("(ITT;)V")]
    [LineNumberTable(new byte[] {161, 85, 127, 36, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void set(int index, object value)
    {
      if (index >= this.size)
      {
        string str = new StringBuilder().append("index can't be >= size: ").append(index).append(" >= ").append(this.size).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IndexOutOfBoundsException(str);
      }
      this.items[index] = value;
    }

    [Signature("([TT;)Larc/struct/Seq<TT;>;")]
    [LineNumberTable(new byte[] {160, 244, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Seq and(object[] value)
    {
      this.addAll(value);
      return this;
    }

    [Signature("(Larc/func/Cons<Larc/struct/Seq<TT;>;>;)Larc/struct/Seq<TT;>;")]
    [LineNumberTable(new byte[] {160, 229, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Seq with(Cons cons)
    {
      cons.get((object) this);
      return this;
    }

    [Signature("(I)[TT;")]
    [LineNumberTable(new byte[] {162, 117, 100, 127, 6, 105, 120})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object[] ensureCapacity(int additionalCapacity)
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

    [LineNumberTable(new byte[] {161, 240, 127, 36, 127, 26, 103, 102, 104, 151, 105, 102, 42, 166, 110})]
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
      object[] items = this.items;
      int num1 = end - start + 1;
      if (this.ordered)
      {
        ByteCodeHelper.arraycopy((object) items, start + num1, (object) items, start, this.size - (start + num1));
      }
      else
      {
        int num2 = this.size - 1;
        for (int index = 0; index < num1; ++index)
          items[start + index] = items[num2 - index];
      }
      this.size -= num1;
    }

    [Signature("(Larc/struct/Seq<+TT;>;II)Larc/struct/Seq<TT;>;")]
    [LineNumberTable(new byte[] {161, 32, 107, 127, 43, 143})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Seq addAll(Seq array, int start, int count)
    {
      if (start + count > array.size)
      {
        string str = new StringBuilder().append("start + count must be <= size: ").append(start).append(" + ").append(count).append(" <= ").append(array.size).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException(str);
      }
      this.addAll(array.items, start, count);
      return this;
    }

    [Signature("([TT;II)Larc/struct/Seq<TT;>;")]
    [LineNumberTable(new byte[] {161, 46, 103, 105, 127, 1, 111, 142})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Seq addAll(object[] array, int start, int count)
    {
      object[] objArray = this.items;
      int num = this.size + count;
      if (num > objArray.Length)
        objArray = this.resize(Math.max(8, ByteCodeHelper.f2i((float) num * 1.75f)));
      ByteCodeHelper.arraycopy((object) array, start, (object) objArray, this.size, count);
      this.size += count;
      return this;
    }

    [Signature("(Z[TT;II)V")]
    [LineNumberTable(new byte[] {159, 118, 98, 118, 104, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Seq(bool ordered, object[] array, int start, int count)
      : this(ordered, count, Object.instancehelper_getClass((object) array).getComponentType())
    {
      Seq seq = this;
      this.size = count;
      ByteCodeHelper.arraycopy((object) array, start, (object) this.items, 0, this.size);
    }

    [Signature("([TT;)V")]
    [LineNumberTable(new byte[] {37, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Seq(object[] array)
      : this(true, array, 0, array.Length)
    {
    }

    [Signature("<K:Ljava/lang/Object;V:Ljava/lang/Object;>(Larc/func/Func<TT;TK;>;Larc/func/Func<TT;TV;>;)Larc/struct/ObjectMap<TK;TV;>;")]
    [LineNumberTable(new byte[] {99, 102, 107, 63, 4, 198})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual ObjectMap asMap(Func keygen, Func valgen)
    {
      ObjectMap objectMap = new ObjectMap();
      for (int index = 0; index < this.size; ++index)
        objectMap.put(keygen.get(this.items[index]), valgen.get(this.items[index]));
      return objectMap;
    }

    [Signature("(Ljava/lang/Iterable<+TT;>;)Larc/struct/Seq<TT;>;")]
    [LineNumberTable(new byte[] {161, 56, 104, 143, 118, 103, 162})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Seq addAll(Iterable items)
    {
      if (items is Seq)
      {
        this.addAll((Seq) items);
      }
      else
      {
        Iterator iterator = items.iterator();
        while (iterator.hasNext())
          this.add(iterator.next());
      }
      return this;
    }

    [Signature("(I)[TT;")]
    [LineNumberTable(new byte[] {162, 137, 135, 127, 24, 118, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual object[] resize(int newSize)
    {
      object[] items = this.items;
      object[] objArray = !object.ReferenceEquals((object) items.GetType(), (object) typeof (object[])) ? (object[]) Array.newInstance(Object.instancehelper_getClass((object) items).getComponentType(), newSize) : new object[newSize];
      ByteCodeHelper.arraycopy((object) items, 0, (object) objArray, 0, Math.min(this.size, objArray.Length));
      this.items = objArray;
      return objArray;
    }

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static object lambda\u0024asMap\u00240([In] object obj0) => obj0;

    [Modifiers]
    [LineNumberTable(new byte[] {162, 173, 105, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024selectFrom\u00241([In] Boolf obj0, [In] object obj1)
    {
      if (!obj0.get(obj1))
        return;
      this.add(obj1);
    }

    [Modifiers]
    [LineNumberTable(831)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024filter\u00242([In] Boolf obj0, [In] object obj1) => !obj0.get(obj1);

    [Signature("<T:Ljava/lang/Object;>(Ljava/lang/Class<TT;>;)Larc/struct/Seq<TT;>;")]
    [LineNumberTable(104)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Seq of(Class arrayType) => new Seq(arrayType);

    [Signature("<T:Ljava/lang/Object;>(ZILjava/lang/Class<TT;>;)Larc/struct/Seq<TT;>;")]
    [LineNumberTable(109)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Seq of(bool ordered, int capacity, Class arrayType) => new Seq(ordered, capacity, arrayType);

    [Signature("<K:Ljava/lang/Object;>(Larc/func/Func<TT;TK;>;)Larc/struct/ObjectMap<TK;TT;>;")]
    [LineNumberTable(158)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual ObjectMap asMap(Func keygen) => this.asMap(keygen, (Func) new Seq.__\u003C\u003EAnon0());

    [Signature("()Ljava/util/ArrayList<TT;>;")]
    [LineNumberTable(new byte[] {120, 113, 120})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual ArrayList list()
    {
      ArrayList.__\u003Cclinit\u003E();
      ArrayList arrayList1 = new ArrayList(this.size);
      ArrayList arrayList2 = arrayList1;
      Objects.requireNonNull((object) arrayList2);
      this.each((Cons) new Seq.__\u003C\u003EAnon1(arrayList2));
      return arrayList1;
    }

    [Signature("(Larc/func/Func<TT;TT;>;)V")]
    [LineNumberTable(new byte[] {160, 92, 107, 54, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void replace(Func mapper)
    {
      for (int index = 0; index < this.size; ++index)
        this.items[index] = mapper.get(this.items[index]);
    }

    [Signature("<R:Ljava/lang/Object;>(Larc/func/Func<TT;Ljava/lang/Iterable<TR;>;>;)Larc/struct/Seq<TR;>;")]
    [LineNumberTable(new byte[] {160, 108, 108, 107, 58, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Seq flatMap(Func mapper)
    {
      Seq seq = new Seq(this.size);
      for (int index = 0; index < this.size; ++index)
        seq.addAll((Iterable) mapper.get(this.items[index]));
      return seq;
    }

    [Signature("(Larc/func/Floatf<TT;>;)Larc/struct/FloatSeq;")]
    [LineNumberTable(new byte[] {160, 135, 108, 107, 53, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual FloatSeq mapFloat(Floatf mapper)
    {
      FloatSeq floatSeq = new FloatSeq(this.size);
      for (int index = 0; index < this.size; ++index)
        floatSeq.add(mapper.get(this.items[index]));
      return floatSeq;
    }

    [Signature("<R:Ljava/lang/Object;>(TR;Larc/func/Func2<TT;TR;TR;>;)TR;")]
    [LineNumberTable(new byte[] {160, 143, 98, 107, 48, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object reduce(object initial, Func2 reducer)
    {
      object obj = initial;
      for (int index = 0; index < this.size; ++index)
        obj = reducer.get(this.items[index], obj);
      return obj;
    }

    [Signature("(Ljava/util/Comparator<TT;>;)TT;")]
    [LineNumberTable(new byte[] {160, 166, 98, 107, 105, 110, 226, 61, 230, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object max(Comparator func)
    {
      object obj1 = (object) null;
      for (int index = 0; index < this.size; ++index)
      {
        object obj2 = this.items[index];
        if (obj1 == null || func.compare(obj1, obj2) < 0)
          obj1 = obj2;
      }
      return obj1;
    }

    [Signature("(Larc/struct/Seq<TT;>;)Larc/struct/Seq<TT;>;")]
    [LineNumberTable(new byte[] {160, 239, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Seq and(Seq value)
    {
      this.addAll(value);
      return this;
    }

    [Signature("(TT;Z)I")]
    [LineNumberTable(new byte[] {159, 7, 66, 103, 102, 109, 45, 168, 109, 45, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int lastIndexOf(object value, bool identity)
    {
      int num = identity ? 1 : 0;
      object[] items = this.items;
      if (num != 0 || value == null)
      {
        for (int index = this.size - 1; index >= 0; index += -1)
        {
          if (object.ReferenceEquals(items[index], value))
            return index;
        }
      }
      else
      {
        for (int index = this.size - 1; index >= 0; index += -1)
        {
          if (Object.instancehelper_equals(value, items[index]))
            return index;
        }
      }
      return -1;
    }

    [Signature("(Larc/func/Prov<TT;>;)TT;")]
    [LineNumberTable(new byte[] {162, 51, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object pop(Prov constructor) => this.size == 0 ? constructor.get() : this.pop();

    [Signature("()TT;")]
    [LineNumberTable(new byte[] {162, 79, 106})]
    [Nullable(new object[] {64, "Larc/util/Nullable;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object firstOpt() => this.size == 0 ? (object) null : this.items[0];

    [Signature("()[TT;")]
    [LineNumberTable(new byte[] {162, 107, 124})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object[] shrink()
    {
      if (this.items.Length != this.size)
        this.resize(this.size);
      return this.items;
    }

    [Signature("(I)[TT;")]
    [LineNumberTable(new byte[] {162, 129, 103, 120, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object[] setSize(int newSize)
    {
      this.truncate(newSize);
      if (newSize > this.items.Length)
        this.resize(Math.max(8, newSize));
      this.size = newSize;
      return this.items;
    }

    [Signature("()Larc/struct/Seq<TT;>;")]
    [LineNumberTable(new byte[] {162, 182, 103, 103, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Seq distinct()
    {
      ObjectSet objectSet = this.asSet();
      this.clear();
      this.addAll((Iterable) objectSet);
      return this;
    }

    [Signature("(Ljava/util/Comparator<TT;>;I)TT;")]
    [LineNumberTable(new byte[] {162, 228, 100, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object selectRanked(Comparator comparator, int kthLowest)
    {
      if (kthLowest < 1)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new ArcRuntimeException("nth_lowest must be greater than 0, 1 = first, 2 = second...");
      }
      return Select.instance().select(this.items, comparator, kthLowest, this.size);
    }

    [Signature("(Ljava/util/Comparator<TT;>;I)I")]
    [LineNumberTable(new byte[] {162, 242, 100, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int selectRankedIndex(Comparator comparator, int kthLowest)
    {
      if (kthLowest < 1)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new ArcRuntimeException("nth_lowest must be greater than 0, 1 = first, 2 = second...");
      }
      return Select.instance().selectIndex(this.items, comparator, kthLowest, this.size);
    }

    [Signature("()[TT;")]
    [LineNumberTable(941)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object[] toArray() => this.toArray(Object.instancehelper_getClass((object) this.items).getComponentType());

    [LineNumberTable(new byte[] {163, 70, 111, 103, 98, 109, 101, 101, 238, 61, 230, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int hashCode()
    {
      if (!this.ordered)
        return base.hashCode();
      object[] items = this.items;
      int num = 1;
      int index = 0;
      for (int size = this.size; index < size; ++index)
      {
        num *= 31;
        object obj = items[index];
        if (obj != null)
          num += Object.instancehelper_hashCode(obj);
      }
      return num;
    }

    [LineNumberTable(new byte[] {163, 83, 107, 106, 106, 103, 106, 103, 107, 103, 103, 104, 102, 102, 247, 61, 232, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool equals(object @object)
    {
      if (object.ReferenceEquals(@object, (object) this))
        return true;
      if (!this.ordered || !(@object is Seq))
        return false;
      Seq seq = (Seq) @object;
      if (!seq.ordered)
        return false;
      int size = this.size;
      if (size != seq.size)
        return false;
      object[] items1 = this.items;
      object[] items2 = seq.items;
      for (int index = 0; index < size; ++index)
      {
        object obj1 = items1[index];
        object obj2 = items2[index];
        if (obj1 == null)
        {
          if (obj2 == null)
            continue;
        }
        else if (Object.instancehelper_equals(obj1, obj2))
          continue;
        return false;
      }
      return true;
    }

    [HideFromJava]
    public virtual void forEach([In] Consumer obj0) => Iterable.\u003Cdefault\u003EforEach((Iterable) this, obj0);

    [HideFromJava]
    public virtual Spliterator spliterator() => Iterable.\u003Cdefault\u003Espliterator((Iterable) this);

    [HideFromJava]
    [SpecialName]
    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) new IterableEnumerator((Iterable) this);

    [Signature("<T:Ljava/lang/Object;>Ljava/lang/Object;Ljava/lang/Iterable<TT;>;")]
    [Implements(new string[] {"java.lang.Iterable"})]
    public class SeqIterable : Object, Iterable, IEnumerable
    {
      [Modifiers]
      [Signature("Larc/struct/Seq<TT;>;")]
      internal Seq array;
      [Modifiers]
      internal bool allowRemove;
      [Signature("Larc/struct/Seq$SeqIterable<TT;>.SeqIterator;")]
      private Seq.SeqIterable.SeqIterator iterator1;
      [Signature("Larc/struct/Seq$SeqIterable<TT;>.SeqIterator;")]
      private Seq.SeqIterable.SeqIterator iterator2;

      [Signature("(Larc/struct/Seq<TT;>;)V")]
      [LineNumberTable(new byte[] {163, 149, 104})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public SeqIterable(Seq array)
        : this(array, true)
      {
      }

      [Signature("()Ljava/util/Iterator<TT;>;")]
      [LineNumberTable(new byte[] {163, 159, 109, 108, 108, 167, 109, 108, 108, 167})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual Iterator iterator()
      {
        if (this.iterator1.done)
        {
          this.iterator1.index = 0;
          this.iterator1.done = false;
          return (Iterator) this.iterator1;
        }
        if (!this.iterator2.done)
          return (Iterator) new Seq.SeqIterable.SeqIterator(this);
        this.iterator2.index = 0;
        this.iterator2.done = false;
        return (Iterator) this.iterator2;
      }

      [Signature("(Larc/struct/Seq<TT;>;Z)V")]
      [LineNumberTable(new byte[] {158, 140, 130, 232, 58, 248, 71, 103, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public SeqIterable(Seq array, bool allowRemove)
      {
        int num = allowRemove ? 1 : 0;
        // ISSUE: explicit constructor call
        base.\u002Ector();
        Seq.SeqIterable seqIterable = this;
        this.iterator1 = new Seq.SeqIterable.SeqIterator(this);
        this.iterator2 = new Seq.SeqIterable.SeqIterator(this);
        this.array = array;
        this.allowRemove = num != 0;
      }

      [HideFromJava]
      public virtual void forEach([In] Consumer obj0) => Iterable.\u003Cdefault\u003EforEach((Iterable) this, obj0);

      [HideFromJava]
      public virtual Spliterator spliterator() => Iterable.\u003Cdefault\u003Espliterator((Iterable) this);

      [HideFromJava]
      [SpecialName]
      IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) new IterableEnumerator((Iterable) this);

      [InnerClass]
      [Signature("Ljava/lang/Object;Ljava/util/Iterator<TT;>;")]
      internal class SeqIterator : Object, Iterator
      {
        internal int index;
        internal bool done;
        [Modifiers]
        internal Seq.SeqIterable this\u00240;

        [LineNumberTable(new byte[] {163, 182, 239, 58, 167, 204})]
        [MethodImpl(MethodImplOptions.NoInlining)]
        internal SeqIterator([In] Seq.SeqIterable obj0)
        {
          this.this\u00240 = obj0;
          // ISSUE: explicit constructor call
          base.\u002Ector();
          Seq.SeqIterable.SeqIterator seqIterator = this;
          this.done = true;
          ++Seq.iteratorsAllocated;
        }

        [LineNumberTable(new byte[] {163, 187, 127, 0})]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public virtual bool hasNext()
        {
          if (this.index >= this.this\u00240.array.size)
            this.done = true;
          return this.index < this.this\u00240.array.size;
        }

        [Signature("()TT;")]
        [LineNumberTable(new byte[] {163, 193, 127, 15})]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public virtual object next()
        {
          if (this.index >= this.this\u00240.array.size)
          {
            string str = String.valueOf(this.index);
            Throwable.__\u003CsuppressFillInStackTrace\u003E();
            throw new NoSuchElementException(str);
          }
          object[] items = this.this\u00240.array.items;
          Seq.SeqIterable.SeqIterator seqIterator1 = this;
          int index1 = seqIterator1.index;
          Seq.SeqIterable.SeqIterator seqIterator2 = seqIterator1;
          int index2 = index1;
          seqIterator2.index = index1 + 1;
          return items[index2];
        }

        [LineNumberTable(new byte[] {163, 199, 125, 110, 119})]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public virtual void remove()
        {
          if (!this.this\u00240.allowRemove)
          {
            Throwable.__\u003CsuppressFillInStackTrace\u003E();
            throw new ArcRuntimeException("Remove not allowed.");
          }
          --this.index;
          this.this\u00240.array.remove(this.index);
        }

        [HideFromJava]
        public virtual void forEachRemaining([In] Consumer obj0) => Iterator.\u003Cdefault\u003EforEachRemaining((Iterator) this, obj0);
      }
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Func
    {
      internal __\u003C\u003EAnon0()
      {
      }

      public object get([In] object obj0) => Seq.lambda\u0024asMap\u00240(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Cons
    {
      private readonly ArrayList arg\u00241;

      internal __\u003C\u003EAnon1([In] ArrayList obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.add(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon2 : Cons
    {
      private readonly Seq arg\u00241;
      private readonly Boolf arg\u00242;

      internal __\u003C\u003EAnon2([In] Seq obj0, [In] Boolf obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024selectFrom\u00241(this.arg\u00242, obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon3 : Boolf
    {
      private readonly Boolf arg\u00241;

      internal __\u003C\u003EAnon3([In] Boolf obj0) => this.arg\u00241 = obj0;

      public bool get([In] object obj0) => (Seq.lambda\u0024filter\u00242(this.arg\u00241, obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon4 : Func
    {
      internal __\u003C\u003EAnon4()
      {
      }

      public object get([In] object obj0) => (object) String.valueOf(obj0);
    }
  }
}
