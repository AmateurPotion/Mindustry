// Decompiled with JetBrains decompiler
// Type: rhino.ObjArray
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using IKVM.Runtime;
using java.io;
using java.lang;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace rhino
{
  public class ObjArray : Object
  {
    private int size;
    private bool @sealed;
    private const int FIELDS_STORE_SIZE = 5;
    [NonSerialized]
    private object f0;
    [NonSerialized]
    private object f1;
    [NonSerialized]
    private object f2;
    [NonSerialized]
    private object f3;
    [NonSerialized]
    private object f4;
    [NonSerialized]
    private object[] data;

    [LineNumberTable(new byte[] {159, 152, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ObjArray()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public int size() => this.size;

    [LineNumberTable(new byte[] {160, 188, 108, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public object[] toArray()
    {
      object[] array = new object[this.size];
      this.toArray(array, 0);
      return array;
    }

    [LineNumberTable(new byte[] {114, 115, 103, 100, 137, 105, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public void add(object value)
    {
      if (this.@sealed)
        throw Throwable.__\u003Cunmap\u003E((Exception) ObjArray.onSeledMutation());
      int size = this.size;
      if (size >= 5)
        this.ensureCapacity(size + 1);
      this.size = size + 1;
      this.setImpl(size, value);
    }

    [LineNumberTable(new byte[] {159, 188, 127, 0})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public object get(int index) => 0 <= index && index < this.size ? this.getImpl(index) : throw Throwable.__\u003Cunmap\u003E((Exception) ObjArray.onInvalidIndex(index, this.size));

    [LineNumberTable(new byte[] {68, 103, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public object peek()
    {
      int size = this.size;
      return size != 0 ? this.getImpl(size - 1) : throw Throwable.__\u003Cunmap\u003E((Exception) ObjArray.onEmptyStackTopRead());
    }

    [LineNumberTable(new byte[] {160, 194, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public void toArray(object[] array) => this.toArray(array, 0);

    [LineNumberTable(new byte[] {110, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public void push(object value) => this.add(value);

    [LineNumberTable(new byte[] {74, 115, 103, 132, 159, 3, 139, 103, 103, 130, 103, 103, 130, 103, 103, 130, 103, 103, 130, 103, 103, 130, 107, 139, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public object pop()
    {
      if (this.@sealed)
        throw Throwable.__\u003Cunmap\u003E((Exception) ObjArray.onSeledMutation());
      int num = this.size - 1;
      object obj;
      switch (num)
      {
        case -1:
          throw Throwable.__\u003Cunmap\u003E((Exception) ObjArray.onEmptyStackTopRead());
        case 0:
          obj = this.f0;
          this.f0 = (object) null;
          break;
        case 1:
          obj = this.f1;
          this.f1 = (object) null;
          break;
        case 2:
          obj = this.f2;
          this.f2 = (object) null;
          break;
        case 3:
          obj = this.f3;
          this.f3 = (object) null;
          break;
        case 4:
          obj = this.f4;
          this.f4 = (object) null;
          break;
        default:
          obj = this.data[num - 5];
          this.data[num - 5] = (object) null;
          break;
      }
      this.size = num;
      return obj;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public bool isEmpty() => this.size == 0;

    [LineNumberTable(379)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static RuntimeException onSeledMutation()
    {
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new IllegalStateException("Attempt to modify sealed array");
    }

    [LineNumberTable(new byte[] {23, 156, 103, 130, 103, 130, 103, 130, 103, 130, 103, 130, 171})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void setImpl([In] int obj0, [In] object obj1)
    {
      switch (obj0)
      {
        case 0:
          this.f0 = obj1;
          break;
        case 1:
          this.f1 = obj1;
          break;
        case 2:
          this.f2 = obj1;
          break;
        case 3:
          this.f3 = obj1;
          break;
        case 4:
          this.f4 = obj1;
          break;
        default:
          this.data[obj0 - 5] = obj1;
          break;
      }
    }

    [LineNumberTable(new byte[] {160, 225, 100, 111, 104, 99, 100, 130, 108, 101, 104, 100, 100, 133, 132, 100, 130, 103, 105, 182, 167})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void ensureCapacity([In] int obj0)
    {
      int num = obj0 - 5;
      if (num <= 0)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException();
      }
      if (this.data == null)
      {
        int length = 10;
        if (length < num)
          length = num;
        this.data = new object[length];
      }
      else
      {
        int length1 = this.data.Length;
        if (length1 >= num)
          return;
        int length2 = length1 > 5 ? length1 * 2 : 10;
        if (length2 < num)
          length2 = num;
        object[] objArray = new object[length2];
        if (this.size > 5)
          ByteCodeHelper.arraycopy((object) this.data, 0, (object) objArray, 0, this.size - 5);
        this.data = objArray;
      }
    }

    [LineNumberTable(new byte[] {161, 0, 127, 9})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static RuntimeException onInvalidIndex([In] int obj0, [In] int obj1)
    {
      string str = new StringBuilder().append(obj0).append(" ∉ [0, ").append(obj1).append(')').toString();
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new IndexOutOfBoundsException(str);
    }

    [LineNumberTable(new byte[] {7, 156, 135, 135, 135, 135, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private object getImpl([In] int obj0)
    {
      switch (obj0)
      {
        case 0:
          return this.f0;
        case 1:
          return this.f1;
        case 2:
          return this.f2;
        case 3:
          return this.f3;
        case 4:
          return this.f4;
        default:
          return this.data[obj0 - 5];
      }
    }

    [LineNumberTable(375)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static RuntimeException onEmptyStackTopRead()
    {
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new RuntimeException("Empty stack");
    }

    [LineNumberTable(new byte[] {160, 198, 103, 159, 1, 211, 171, 171, 171, 171, 235, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public void toArray(object[] array, int offset)
    {
      int size = this.size;
      switch (size)
      {
        case 0:
          break;
        case 1:
          array[offset + 0] = this.f0;
          break;
        case 2:
          array[offset + 1] = this.f1;
          goto case 1;
        case 3:
          array[offset + 2] = this.f2;
          goto case 2;
        case 4:
          array[offset + 3] = this.f3;
          goto case 3;
        case 5:
          array[offset + 4] = this.f4;
          goto case 4;
        default:
          ByteCodeHelper.arraycopy((object) this.data, 0, (object) array, offset + 5, size - 5);
          goto case 5;
      }
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public bool isSealed() => this.@sealed;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public void seal() => this.@sealed = true;

    [LineNumberTable(new byte[] {159, 172, 111, 115, 103, 100, 102, 40, 168, 100, 100, 167, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public void setSize(int newSize)
    {
      if (newSize < 0)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException();
      }
      if (this.@sealed)
        throw Throwable.__\u003Cunmap\u003E((Exception) ObjArray.onSeledMutation());
      int size = this.size;
      if (newSize < size)
      {
        for (int index = newSize; index != size; ++index)
          this.setImpl(index, (object) null);
      }
      else if (newSize > size && newSize > 5)
        this.ensureCapacity(newSize);
      this.size = newSize;
    }

    [LineNumberTable(new byte[] {1, 127, 0, 115, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public void set(int index, object value)
    {
      if (0 > index || index >= this.size)
        throw Throwable.__\u003Cunmap\u003E((Exception) ObjArray.onInvalidIndex(index, this.size));
      if (this.@sealed)
        throw Throwable.__\u003Cunmap\u003E((Exception) ObjArray.onSeledMutation());
      this.setImpl(index, value);
    }

    [LineNumberTable(new byte[] {46, 103, 102, 104, 117, 226, 61, 230, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int indexOf(object obj)
    {
      int size = this.size;
      for (int index = 0; index != size; ++index)
      {
        object impl = this.getImpl(index);
        if (object.ReferenceEquals(impl, obj) || impl != null && Object.instancehelper_equals(impl, obj))
          return index;
      }
      return -1;
    }

    [LineNumberTable(new byte[] {57, 106, 100, 104, 117, 130, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int lastIndexOf(object obj)
    {
      int size = this.size;
      while (size != 0)
      {
        size += -1;
        object impl = this.getImpl(size);
        if (object.ReferenceEquals(impl, obj) || impl != null && Object.instancehelper_equals(impl, obj))
          return size;
      }
      return -1;
    }

    [LineNumberTable(new byte[] {124, 103, 119, 147, 159, 0, 99, 103, 133, 103, 103, 163, 100, 103, 133, 103, 103, 163, 100, 103, 133, 103, 103, 163, 100, 103, 133, 103, 103, 163, 100, 103, 130, 103, 103, 131, 163, 105, 100, 220, 139, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public void add(int index, object value)
    {
      int size = this.size;
      if (0 > index || index > size)
        throw Throwable.__\u003Cunmap\u003E((Exception) ObjArray.onInvalidIndex(index, size + 1));
      if (this.@sealed)
        throw Throwable.__\u003Cunmap\u003E((Exception) ObjArray.onSeledMutation());
      switch (index)
      {
        case 0:
          if (size == 0)
          {
            this.f0 = value;
            break;
          }
          object f0 = this.f0;
          this.f0 = value;
          value = f0;
          goto case 1;
        case 1:
          if (size == 1)
          {
            this.f1 = value;
            break;
          }
          object f1 = this.f1;
          this.f1 = value;
          value = f1;
          goto case 2;
        case 2:
          if (size == 2)
          {
            this.f2 = value;
            break;
          }
          object f2 = this.f2;
          this.f2 = value;
          value = f2;
          goto case 3;
        case 3:
          if (size == 3)
          {
            this.f3 = value;
            break;
          }
          object f3 = this.f3;
          this.f3 = value;
          value = f3;
          goto case 4;
        case 4:
          if (size == 4)
          {
            this.f4 = value;
            break;
          }
          object f4 = this.f4;
          this.f4 = value;
          value = f4;
          index = 5;
          goto default;
        default:
          this.ensureCapacity(size + 1);
          if (index != size)
            ByteCodeHelper.arraycopy((object) this.data, index - 5, (object) this.data, index - 5 + 1, size - index);
          this.data[index - 5] = value;
          break;
      }
      this.size = size + 1;
    }

    [LineNumberTable(new byte[] {160, 125, 103, 117, 115, 100, 159, 0, 99, 103, 133, 172, 100, 103, 133, 172, 100, 103, 133, 172, 100, 103, 130, 172, 100, 103, 130, 142, 163, 100, 220, 139, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public void remove(int index)
    {
      int size = this.size;
      if (0 > index || index >= size)
        throw Throwable.__\u003Cunmap\u003E((Exception) ObjArray.onInvalidIndex(index, size));
      if (this.@sealed)
        throw Throwable.__\u003Cunmap\u003E((Exception) ObjArray.onSeledMutation());
      int num = size - 1;
      switch (index)
      {
        case 0:
          if (num == 0)
          {
            this.f0 = (object) null;
            break;
          }
          this.f0 = this.f1;
          goto case 1;
        case 1:
          if (num == 1)
          {
            this.f1 = (object) null;
            break;
          }
          this.f1 = this.f2;
          goto case 2;
        case 2:
          if (num == 2)
          {
            this.f2 = (object) null;
            break;
          }
          this.f2 = this.f3;
          goto case 3;
        case 3:
          if (num == 3)
          {
            this.f3 = (object) null;
            break;
          }
          this.f3 = this.f4;
          goto case 4;
        case 4:
          if (num == 4)
          {
            this.f4 = (object) null;
            break;
          }
          this.f4 = this.data[0];
          index = 5;
          goto default;
        default:
          if (index != num)
            ByteCodeHelper.arraycopy((object) this.data, index - 5 + 1, (object) this.data, index - 5, num - index);
          this.data[num - 5] = (object) null;
          break;
      }
      this.size = num;
    }

    [LineNumberTable(new byte[] {160, 179, 115, 103, 102, 40, 166, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public void clear()
    {
      if (this.@sealed)
        throw Throwable.__\u003Cunmap\u003E((Exception) ObjArray.onSeledMutation());
      int size = this.size;
      for (int index = 0; index != size; ++index)
        this.setImpl(index, (object) null);
      this.size = 0;
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {161, 13, 102, 103, 102, 104, 7, 198})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void writeObject([In] ObjectOutputStream obj0)
    {
      obj0.defaultWriteObject();
      int size = this.size;
      for (int index = 0; index != size; ++index)
      {
        object impl = this.getImpl(index);
        obj0.writeObject(impl);
      }
    }

    [Throws(new string[] {"java.io.IOException", "java.lang.ClassNotFoundException"})]
    [LineNumberTable(new byte[] {161, 23, 102, 103, 100, 142, 102, 103, 8, 198})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void readObject([In] ObjectInputStream obj0)
    {
      obj0.defaultReadObject();
      int size = this.size;
      if (size > 5)
        this.data = new object[size - 5];
      for (int index = 0; index != size; ++index)
      {
        object obj = obj0.readObject();
        this.setImpl(index, obj);
      }
    }
  }
}
