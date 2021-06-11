// Decompiled with JetBrains decompiler
// Type: rhino.UintMap
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
  public class UintMap : Object
  {
    private const int A = -1640531527;
    private const int EMPTY = -1;
    private const int DELETED = -2;
    [NonSerialized]
    private int[] keys;
    [NonSerialized]
    private object[] values;
    private int power;
    private int keyCount;
    [NonSerialized]
    private int occupiedCount;
    [NonSerialized]
    private int ivaluesShift;
    private const bool check = false;

    [LineNumberTable(new byte[] {159, 160, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public UintMap()
      : this(4)
    {
    }

    [LineNumberTable(new byte[] {64, 106, 105, 104, 140, 108, 105, 111, 135, 135, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void put(int key, int value)
    {
      if (key < 0)
        Kit.codeBug();
      int num1 = this.ensureIndex(key, true);
      if (this.ivaluesShift == 0)
      {
        int num2 = 1 << this.power;
        if (this.keys.Length != num2 * 2)
        {
          int[] numArray = new int[num2 * 2];
          ByteCodeHelper.arraycopy_primitive_4((Array) this.keys, 0, (Array) numArray, 0, num2);
          this.keys = numArray;
        }
        this.ivaluesShift = num2;
      }
      this.keys[this.ivaluesShift + num1] = value;
    }

    [LineNumberTable(new byte[] {15, 106, 104, 100, 104, 144, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getInt(int key, int defaultValue)
    {
      if (key < 0)
        Kit.codeBug();
      int index = this.findIndex(key);
      if (0 > index)
        return defaultValue;
      return this.ivaluesShift != 0 ? this.keys[this.ivaluesShift + index] : 0;
    }

    [LineNumberTable(new byte[] {159, 163, 104, 138, 134, 145, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public UintMap(int initialCapacity)
    {
      UintMap uintMap = this;
      if (initialCapacity < 0)
        Kit.codeBug();
      int num1 = initialCapacity * 4 / 3;
      int num2 = 2;
      while (1 << num2 < num1)
        ++num2;
      this.power = num2;
    }

    [LineNumberTable(new byte[] {115, 103, 103, 103, 101, 101, 107, 233, 61, 230, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int[] getKeys()
    {
      int[] keys = this.keys;
      int keyCount = this.keyCount;
      int[] numArray1 = new int[keyCount];
      int index1 = 0;
      while (keyCount != 0)
      {
        int num1 = keys[index1];
        switch (num1)
        {
          case -2:
          case -1:
            ++index1;
            continue;
          default:
            int[] numArray2 = numArray1;
            keyCount += -1;
            int index2 = keyCount;
            int num2 = num1;
            numArray2[index2] = num2;
            goto case -2;
        }
      }
      return numArray1;
    }

    [LineNumberTable(new byte[] {33, 106, 104, 100, 104, 144, 162, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getExistingInt(int key)
    {
      if (key < 0)
        Kit.codeBug();
      int index = this.findIndex(key);
      if (0 <= index)
        return this.ivaluesShift != 0 ? this.keys[this.ivaluesShift + index] : 0;
      Kit.codeBug();
      return 0;
    }

    [LineNumberTable(new byte[] {160, 72, 103, 102, 104, 111, 100, 100, 130, 132, 111, 112, 226, 70, 104, 100, 100, 130, 164})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private int findIndex([In] int obj0)
    {
      int[] keys = this.keys;
      if (keys != null)
      {
        int num1 = obj0 * -1640531527;
        int index = (int) ((uint) num1 >> 32 - this.power);
        int num2 = keys[index];
        if (num2 == obj0)
          return index;
        if (num2 != -1)
        {
          int num3 = (1 << this.power) - 1;
          int num4 = UintMap.tableLookupStep(num1, num3, this.power);
          int num5;
          do
          {
            index = index + num4 & num3;
            num5 = keys[index];
            if (num5 == obj0)
              return index;
          }
          while (num5 != -1);
        }
      }
      return -1;
    }

    [LineNumberTable(new byte[] {159, 71, 162, 98, 98, 103, 102, 105, 112, 101, 101, 130, 104, 102, 162, 111, 113, 226, 70, 104, 101, 101, 130, 106, 130, 229, 70, 100, 164, 154, 103, 136, 142, 100, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private int ensureIndex([In] int obj0, [In] bool obj1)
    {
      int num1 = obj1 ? 1 : 0;
      int index = -1;
      int num2 = -1;
      int[] keys = this.keys;
      if (keys != null)
      {
        int num3 = obj0 * -1640531527;
        index = (int) ((uint) num3 >> 32 - this.power);
        int num4 = keys[index];
        if (num4 == obj0)
          return index;
        switch (num4)
        {
          case -2:
            num2 = index;
            break;
          case -1:
            goto label_11;
        }
        int num5 = (1 << this.power) - 1;
        int num6 = UintMap.tableLookupStep(num3, num5, this.power);
        int num7;
        do
        {
          index = index + num6 & num5;
          num7 = keys[index];
          if (num7 == obj0)
            return index;
          if (num7 == -2 && num2 < 0)
            num2 = index;
        }
        while (num7 != -1);
      }
label_11:
      if (num2 >= 0)
      {
        index = num2;
      }
      else
      {
        if (keys == null || this.occupiedCount * 4 >= (1 << this.power) * 3)
        {
          this.rehashTable(num1 != 0);
          return this.insertNewKey(obj0);
        }
        ++this.occupiedCount;
      }
      keys[index] = obj0;
      ++this.keyCount;
      return index;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    private static int tableLookupStep([In] int obj0, [In] int obj1, [In] int obj2)
    {
      int num = 32 - 2 * obj2;
      return num >= 0 ? (int) ((uint) obj0 >> num) & obj1 | 1 : obj0 & (int) ((uint) obj1 >> -num) | 1;
    }

    [LineNumberTable(new byte[] {160, 106, 103, 104, 111, 102, 110, 111, 162, 135, 134, 100, 110, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private int insertNewKey([In] int obj0)
    {
      int[] keys = this.keys;
      int num1 = obj0 * -1640531527;
      int index = (int) ((uint) num1 >> 32 - this.power);
      if (keys[index] != -1)
      {
        int num2 = (1 << this.power) - 1;
        int num3 = UintMap.tableLookupStep(num1, num2, this.power);
        do
        {
          index = index + num3 & num2;
        }
        while (keys[index] != -1);
      }
      keys[index] = obj0;
      ++this.occupiedCount;
      ++this.keyCount;
      return index;
    }

    [LineNumberTable(new byte[] {159, 82, 66, 136, 144, 174, 108, 103, 103, 102, 142, 103, 142, 104, 42, 200, 104, 100, 172, 104, 103, 103, 103, 110, 102, 107, 106, 100, 142, 99, 150, 230, 54, 235, 78})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void rehashTable([In] bool obj0)
    {
      int num1 = obj0 ? 1 : 0;
      if (this.keys != null && this.keyCount * 2 >= this.occupiedCount)
        ++this.power;
      int length = 1 << this.power;
      int[] keys = this.keys;
      int ivaluesShift = this.ivaluesShift;
      if (ivaluesShift == 0 && num1 == 0)
      {
        this.keys = new int[length];
      }
      else
      {
        this.ivaluesShift = length;
        this.keys = new int[length * 2];
      }
      for (int index = 0; index != length; ++index)
        this.keys[index] = -1;
      object[] values = this.values;
      if (values != null)
        this.values = new object[length];
      int keyCount = this.keyCount;
      this.occupiedCount = 0;
      if (keyCount == 0)
        return;
      this.keyCount = 0;
      int index1 = 0;
      int num2 = keyCount;
      while (num2 != 0)
      {
        int num3 = keys[index1];
        switch (num3)
        {
          case -2:
          case -1:
            ++index1;
            continue;
          default:
            int index2 = this.insertNewKey(num3);
            if (values != null)
              this.values[index2] = values[index1];
            if (ivaluesShift != 0)
              this.keys[this.ivaluesShift + index2] = keys[ivaluesShift + index1];
            num2 += -1;
            goto case -2;
        }
      }
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isEmpty() => this.keyCount == 0;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int size() => this.keyCount;

    [LineNumberTable(new byte[] {159, 183, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool has(int key)
    {
      if (key < 0)
        Kit.codeBug();
      return 0 <= this.findIndex(key);
    }

    [LineNumberTable(new byte[] {0, 106, 104, 104, 100, 169})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object getObject(int key)
    {
      if (key < 0)
        Kit.codeBug();
      if (this.values != null)
      {
        int index = this.findIndex(key);
        if (0 <= index)
          return this.values[index];
      }
      return (object) null;
    }

    [LineNumberTable(new byte[] {51, 106, 105, 104, 150, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void put(int key, object value)
    {
      if (key < 0)
        Kit.codeBug();
      int index = this.ensureIndex(key, false);
      if (this.values == null)
        this.values = new object[1 << this.power];
      this.values[index] = value;
    }

    [LineNumberTable(new byte[] {80, 106, 104, 100, 106, 174, 104, 137, 104, 176})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void remove(int key)
    {
      if (key < 0)
        Kit.codeBug();
      int index = this.findIndex(key);
      if (0 > index)
        return;
      this.keys[index] = -2;
      --this.keyCount;
      if (this.values != null)
        this.values[index] = (object) null;
      if (this.ivaluesShift == 0)
        return;
      this.keys[this.ivaluesShift + index] = 0;
    }

    [LineNumberTable(new byte[] {97, 108, 104, 102, 41, 166, 104, 102, 41, 230, 69, 103, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void clear()
    {
      int num = 1 << this.power;
      if (this.keys != null)
      {
        for (int index = 0; index != num; ++index)
          this.keys[index] = -1;
        if (this.values != null)
        {
          for (int index = 0; index != num; ++index)
            this.values[index] = (object) null;
        }
      }
      this.ivaluesShift = 0;
      this.keyCount = 0;
      this.occupiedCount = 0;
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {160, 228, 134, 103, 102, 109, 109, 103, 135, 104, 106, 107, 100, 104, 99, 149, 99, 238, 55, 233, 78})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void writeObject([In] ObjectOutputStream obj0)
    {
      obj0.defaultWriteObject();
      int keyCount = this.keyCount;
      if (keyCount == 0)
        return;
      int num1 = this.ivaluesShift == 0 ? 0 : 1;
      int num2 = this.values == null ? 0 : 1;
      obj0.writeBoolean(num1 != 0);
      obj0.writeBoolean(num2 != 0);
      int index = 0;
      while (keyCount != 0)
      {
        int key = this.keys[index];
        switch (key)
        {
          case -2:
          case -1:
            ++index;
            continue;
          default:
            keyCount += -1;
            obj0.writeInt(key);
            if (num1 != 0)
              obj0.writeInt(this.keys[this.ivaluesShift + index]);
            if (num2 != 0)
            {
              obj0.writeObject(this.values[index]);
              goto case -2;
            }
            else
              goto case -2;
        }
      }
    }

    [Throws(new string[] {"java.io.IOException", "java.lang.ClassNotFoundException"})]
    [LineNumberTable(new byte[] {160, 255, 134, 103, 102, 103, 103, 135, 108, 99, 110, 137, 140, 104, 42, 168, 99, 140, 104, 104, 106, 99, 104, 146, 99, 239, 56, 232, 76})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void readObject([In] ObjectInputStream obj0)
    {
      obj0.defaultReadObject();
      int keyCount = this.keyCount;
      if (keyCount == 0)
        return;
      this.keyCount = 0;
      int num1 = obj0.readBoolean() ? 1 : 0;
      int num2 = obj0.readBoolean() ? 1 : 0;
      int length = 1 << this.power;
      if (num1 != 0)
      {
        this.keys = new int[2 * length];
        this.ivaluesShift = length;
      }
      else
        this.keys = new int[length];
      for (int index = 0; index != length; ++index)
        this.keys[index] = -1;
      if (num2 != 0)
        this.values = new object[length];
      for (int index1 = 0; index1 != keyCount; ++index1)
      {
        int index2 = this.insertNewKey(obj0.readInt());
        if (num1 != 0)
        {
          int num3 = obj0.readInt();
          this.keys[this.ivaluesShift + index2] = num3;
        }
        if (num2 != 0)
          this.values[index2] = obj0.readObject();
      }
    }
  }
}
