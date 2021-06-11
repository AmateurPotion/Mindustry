// Decompiled with JetBrains decompiler
// Type: rhino.ObjToIntMap
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
  public class ObjToIntMap : Object
  {
    private const int A = -1640531527;
    [Modifiers]
    private static object DELETED;
    [NonSerialized]
    private object[] keys;
    [NonSerialized]
    private int[] values;
    private int power;
    private int keyCount;
    [NonSerialized]
    private int occupiedCount;
    private const bool check = false;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {34, 104, 138, 134, 145, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ObjToIntMap(int keyCountHint)
    {
      ObjToIntMap objToIntMap = this;
      if (keyCountHint < 0)
        Kit.codeBug();
      int num1 = keyCountHint * 4 / 3;
      int num2 = 2;
      while (1 << num2 < num1)
        ++num2;
      this.power = num2;
    }

    [LineNumberTable(new byte[] {107, 98, 99, 98, 135, 104, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object intern(object keyArg)
    {
      int num = 0;
      if (keyArg == null)
      {
        num = 1;
        keyArg = (object) UniqueTag.__\u003C\u003ENULL_VALUE;
      }
      int index = this.ensureIndex(keyArg);
      this.values[index] = 0;
      return num != 0 ? (object) null : this.keys[index];
    }

    [LineNumberTable(new byte[] {160, 86, 108, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object[] getKeys()
    {
      object[] array = new object[this.keyCount];
      this.getKeys(array, 0);
      return array;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int size() => this.keyCount;

    [LineNumberTable(188)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual ObjToIntMap.Iterator newIterator() => new ObjToIntMap.Iterator(this);

    [LineNumberTable(new byte[] {65, 99, 135, 104, 100, 137})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int get(object key, int defaultValue)
    {
      if (key == null)
        key = (object) UniqueTag.__\u003C\u003ENULL_VALUE;
      int index = this.findIndex(key);
      return 0 <= index ? this.values[index] : defaultValue;
    }

    [LineNumberTable(new byte[] {94, 99, 135, 104, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void put(object key, int value)
    {
      if (key == null)
        key = (object) UniqueTag.__\u003C\u003ENULL_VALUE;
      this.values[this.ensureIndex(key)] = value;
    }

    [LineNumberTable(new byte[] {31, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ObjToIntMap()
      : this(4)
    {
    }

    [LineNumberTable(new byte[] {54, 99, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool has(object key)
    {
      if (key == null)
        key = (object) UniqueTag.__\u003C\u003ENULL_VALUE;
      return 0 <= this.findIndex(key);
    }

    [LineNumberTable(new byte[] {118, 99, 135, 104, 100, 109, 142})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void remove(object key)
    {
      if (key == null)
        key = (object) UniqueTag.__\u003C\u003ENULL_VALUE;
      int index = this.findIndex(key);
      if (0 > index)
        return;
      this.keys[index] = ObjToIntMap.DELETED;
      --this.keyCount;
    }

    [LineNumberTable(new byte[] {160, 81, 120})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal void initIterator([In] ObjToIntMap.Iterator obj0) => obj0.init(this.keys, this.values, this.keyCount);

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static object access\u0024000() => ObjToIntMap.DELETED;

    [LineNumberTable(new byte[] {160, 115, 107, 103, 104, 111, 105, 102, 109, 121, 103, 162, 102, 112, 226, 70, 104, 105, 99, 130, 121, 103, 226, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private int findIndex([In] object obj0)
    {
      if (this.keys != null)
      {
        int num1 = Object.instancehelper_hashCode(obj0);
        int num2 = num1 * -1640531527;
        int index = (int) ((uint) num2 >> 32 - this.power);
        object key1 = this.keys[index];
        if (key1 != null)
        {
          int num3 = 1 << this.power;
          if (object.ReferenceEquals(key1, obj0) || this.values[num3 + index] == num1 && Object.instancehelper_equals(key1, obj0))
            return index;
          int num4 = num3 - 1;
          int num5 = ObjToIntMap.tableLookupStep(num2, num4, this.power);
          object key2;
          do
          {
            index = index + num5 & num4;
            key2 = this.keys[index];
            if (key2 == null)
              goto label_8;
          }
          while (!object.ReferenceEquals(key2, obj0) && (this.values[num3 + index] != num1 || !Object.instancehelper_equals(key2, obj0)));
          return index;
        }
      }
label_8:
      return -1;
    }

    [LineNumberTable(new byte[] {160, 212, 103, 98, 98, 107, 104, 111, 106, 103, 109, 123, 103, 130, 110, 194, 102, 112, 226, 70, 104, 106, 100, 130, 123, 103, 130, 117, 231, 72, 100, 164, 159, 0, 102, 137, 142, 105, 117, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private int ensureIndex([In] object obj0)
    {
      int num1 = Object.instancehelper_hashCode(obj0);
      int index = -1;
      int num2 = -1;
      if (this.keys != null)
      {
        int num3 = num1 * -1640531527;
        index = (int) ((uint) num3 >> 32 - this.power);
        object key1 = this.keys[index];
        if (key1 != null)
        {
          int num4 = 1 << this.power;
          if (object.ReferenceEquals(key1, obj0) || this.values[num4 + index] == num1 && Object.instancehelper_equals(key1, obj0))
            return index;
          if (object.ReferenceEquals(key1, ObjToIntMap.DELETED))
            num2 = index;
          int num5 = num4 - 1;
          int num6 = ObjToIntMap.tableLookupStep(num3, num5, this.power);
          while (true)
          {
            object key2;
            do
            {
              index = index + num6 & num5;
              key2 = this.keys[index];
              if (key2 != null)
              {
                if (object.ReferenceEquals(key2, obj0) || this.values[num4 + index] == num1 && Object.instancehelper_equals(key2, obj0))
                  return index;
              }
              else
                goto label_12;
            }
            while (!object.ReferenceEquals(key2, ObjToIntMap.DELETED) || num2 >= 0);
            num2 = index;
          }
        }
      }
label_12:
      if (num2 >= 0)
      {
        index = num2;
      }
      else
      {
        if (this.keys == null || this.occupiedCount * 4 >= (1 << this.power) * 3)
        {
          this.rehashTable();
          return this.insertNewKey(obj0, num1);
        }
        ++this.occupiedCount;
      }
      this.keys[index] = obj0;
      this.values[(1 << this.power) + index] = num1;
      ++this.keyCount;
      return index;
    }

    [LineNumberTable(new byte[] {160, 92, 103, 101, 105, 112, 109, 130, 100, 101, 228, 56, 230, 75})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void getKeys(object[] array, int offset)
    {
      int keyCount = this.keyCount;
      int index = 0;
      while (keyCount != 0)
      {
        object objA = this.keys[index];
        if (objA != null && !object.ReferenceEquals(objA, ObjToIntMap.DELETED))
        {
          if (object.ReferenceEquals(objA, (object) UniqueTag.__\u003C\u003ENULL_VALUE))
            objA = (object) null;
          array[offset] = objA;
          ++offset;
          keyCount += -1;
        }
        ++index;
      }
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    private static int tableLookupStep([In] int obj0, [In] int obj1, [In] int obj2)
    {
      int num = 32 - 2 * obj2;
      return num >= 0 ? (int) ((uint) obj0 >> num) & obj1 | 1 : obj0 & (int) ((uint) obj1 >> -num) | 1;
    }

    [LineNumberTable(new byte[] {160, 155, 104, 111, 108, 106, 100, 111, 162, 135, 138, 105, 107, 110, 142})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private int insertNewKey([In] object obj0, [In] int obj1)
    {
      int num1 = obj1 * -1640531527;
      int index = (int) ((uint) num1 >> 32 - this.power);
      int num2 = 1 << this.power;
      if (this.keys[index] != null)
      {
        int num3 = num2 - 1;
        int num4 = ObjToIntMap.tableLookupStep(num1, num3, this.power);
        do
        {
          index = index + num4 & num3;
        }
        while (this.keys[index] != null);
      }
      this.keys[index] = obj0;
      this.values[num2 + index] = obj1;
      ++this.occupiedCount;
      ++this.keyCount;
      return index;
    }

    [LineNumberTable(new byte[] {160, 177, 168, 108, 108, 110, 133, 144, 142, 108, 103, 103, 99, 108, 142, 104, 117, 103, 102, 114, 104, 108, 109, 230, 58, 232, 74})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void rehashTable()
    {
      if (this.keys == null)
      {
        int length = 1 << this.power;
        this.keys = new object[length];
        this.values = new int[2 * length];
      }
      else
      {
        if (this.keyCount * 2 >= this.occupiedCount)
          ++this.power;
        int length1 = 1 << this.power;
        object[] keys = this.keys;
        int[] values = this.values;
        int length2 = keys.Length;
        this.keys = new object[length1];
        this.values = new int[2 * length1];
        int keyCount = this.keyCount;
        ObjToIntMap objToIntMap = this;
        int num1 = 0;
        int num2 = num1;
        this.keyCount = num1;
        this.occupiedCount = num2;
        int index = 0;
        while (keyCount != 0)
        {
          object objA = keys[index];
          if (objA != null && !object.ReferenceEquals(objA, ObjToIntMap.DELETED))
          {
            int num3 = values[length2 + index];
            this.values[this.insertNewKey(objA, num3)] = values[index];
            keyCount += -1;
          }
          ++index;
        }
      }
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isEmpty() => this.keyCount == 0;

    [LineNumberTable(new byte[] {81, 99, 135, 104, 100, 169, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getExisting(object key)
    {
      if (key == null)
        key = (object) UniqueTag.__\u003C\u003ENULL_VALUE;
      int index = this.findIndex(key);
      if (0 <= index)
        return this.values[index];
      Kit.codeBug();
      return 0;
    }

    [LineNumberTable(new byte[] {160, 65, 104, 99, 143, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void clear()
    {
      int length = this.keys.Length;
      while (length != 0)
      {
        object[] keys = this.keys;
        length += -1;
        int index = length;
        keys[index] = (object) null;
      }
      this.keyCount = 0;
      this.occupiedCount = 0;
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {161, 19, 134, 103, 101, 105, 112, 100, 103, 238, 59, 230, 72})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void writeObject([In] ObjectOutputStream obj0)
    {
      obj0.defaultWriteObject();
      int keyCount = this.keyCount;
      int index = 0;
      while (keyCount != 0)
      {
        object key = this.keys[index];
        if (key != null && !object.ReferenceEquals(key, ObjToIntMap.DELETED))
        {
          keyCount += -1;
          obj0.writeObject(key);
          obj0.writeInt(this.values[index]);
        }
        ++index;
      }
    }

    [Throws(new string[] {"java.io.IOException", "java.lang.ClassNotFoundException"})]
    [LineNumberTable(new byte[] {161, 34, 134, 103, 102, 103, 108, 108, 110, 102, 103, 104, 107, 239, 60, 230, 71})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void readObject([In] ObjectInputStream obj0)
    {
      obj0.defaultReadObject();
      int keyCount = this.keyCount;
      if (keyCount == 0)
        return;
      this.keyCount = 0;
      int length = 1 << this.power;
      this.keys = new object[length];
      this.values = new int[2 * length];
      for (int index = 0; index != keyCount; ++index)
      {
        object obj = obj0.readObject();
        int num = Object.instancehelper_hashCode(obj);
        this.values[this.insertNewKey(obj, num)] = obj0.readInt();
      }
    }

    [LineNumberTable(425)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static ObjToIntMap()
    {
      if (ByteCodeHelper.isAlreadyInited("rhino.ObjToIntMap"))
        return;
      ObjToIntMap.DELETED = (object) new Object();
    }

    public class Iterator : Object
    {
      internal ObjToIntMap master;
      private int cursor;
      private int remaining;
      private object[] keys;
      private int[] values;

      [LineNumberTable(new byte[] {159, 175, 108, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void start()
      {
        this.master.initIterator(this);
        this.next();
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual bool done() => this.remaining < 0;

      [LineNumberTable(new byte[] {8, 110, 109, 130})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual object getKey()
      {
        object objA = this.keys[this.cursor];
        if (object.ReferenceEquals(objA, (object) UniqueTag.__\u003C\u003ENULL_VALUE))
          objA = (object) null;
        return objA;
      }

      [LineNumberTable(66)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual int getValue() => this.values[this.cursor];

      [LineNumberTable(new byte[] {159, 184, 111, 104, 103, 137, 110, 110, 112, 110, 226, 60, 240, 72})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void next()
      {
        if (this.remaining == -1)
          Kit.codeBug();
        if (this.remaining == 0)
        {
          this.remaining = -1;
          this.cursor = -1;
        }
        else
        {
          ++this.cursor;
          while (true)
          {
            object key = this.keys[this.cursor];
            if (key == null || object.ReferenceEquals(key, ObjToIntMap.access\u0024000()))
              ++this.cursor;
            else
              break;
          }
          --this.remaining;
        }
      }

      [LineNumberTable(new byte[] {159, 163, 104, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal Iterator([In] ObjToIntMap obj0)
      {
        ObjToIntMap.Iterator iterator = this;
        this.master = obj0;
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      internal void init([In] object[] obj0, [In] int[] obj1, [In] int obj2)
      {
        this.keys = obj0;
        this.values = obj1;
        this.cursor = -1;
        this.remaining = obj2;
      }

      [LineNumberTable(new byte[] {20, 110})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void setValue(int value) => this.values[this.cursor] = value;
    }
  }
}
