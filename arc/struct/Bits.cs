// Decompiled with JetBrains decompiler
// Type: arc.struct.Bits
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.@struct
{
  public class Bits : Object
  {
    internal long[] bits;

    [LineNumberTable(new byte[] {159, 161, 232, 54, 241, 75, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Bits(int nbits)
    {
      Bits bits = this;
      this.bits = new long[1]{ 0L };
      this.checkCapacity((int) ((uint) nbits >> 6));
    }

    [LineNumberTable(new byte[] {63, 103, 99, 102, 37, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void clear()
    {
      long[] bits = this.bits;
      int length = bits.Length;
      for (int index = 0; index < length; ++index)
        bits[index] = 0L;
    }

    [LineNumberTable(new byte[] {11, 100, 103, 105, 122})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool getAndSet(int index)
    {
      int index1 = (int) ((uint) index >> 6);
      this.checkCapacity(index1);
      long bit = this.bits[index1];
      long[] bits = this.bits;
      int index2 = index1;
      long[] numArray = bits;
      numArray[index2] = numArray[index2] | 1L << index;
      return this.bits[index1] == bit;
    }

    [LineNumberTable(new byte[] {159, 177, 100, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool get(int index)
    {
      int index1 = (int) ((uint) index >> 6);
      return index1 < this.bits.Length && (this.bits[index1] & 1L << index) != 0L;
    }

    [LineNumberTable(new byte[] {159, 153, 8, 177})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Bits()
    {
      Bits bits = this;
      this.bits = new long[1]{ 0L };
    }

    [LineNumberTable(new byte[] {31, 100, 103, 122})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void set(int index)
    {
      int num = (int) ((uint) index >> 6);
      this.checkCapacity(num);
      long[] bits = this.bits;
      int index1 = num;
      long[] numArray = bits;
      numArray[index1] = numArray[index1] | 1L << index;
    }

    [LineNumberTable(new byte[] {159, 125, 98, 99, 137, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void set(int index, bool value)
    {
      if (value)
        this.set(index);
      else
        this.clear(index);
    }

    [LineNumberTable(new byte[] {56, 100, 107, 125})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void clear(int index)
    {
      int num = (int) ((uint) index >> 6);
      if (num >= this.bits.Length)
        return;
      long[] bits = this.bits;
      int index1 = num;
      long[] numArray = bits;
      numArray[index1] = numArray[index1] & (1L << index ^ -1L);
    }

    [LineNumberTable(new byte[] {44, 106, 105, 117, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void checkCapacity([In] int obj0)
    {
      if (obj0 < this.bits.Length)
        return;
      long[] numArray = new long[obj0 + 1];
      ByteCodeHelper.arraycopy_primitive_8((Array) this.bits, 0, (Array) numArray, 0, this.bits.Length);
      this.bits = numArray;
    }

    [LineNumberTable(new byte[] {81, 103, 105, 100, 101, 103, 112, 8, 230, 61, 230, 74})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int length()
    {
      long[] bits = this.bits;
      for (int index1 = bits.Length - 1; index1 >= 0; index1 += -1)
      {
        long num = bits[index1];
        if (num != 0L)
        {
          for (int index2 = 63; index2 >= 0; index2 += -1)
          {
            if ((num & 1L << index2) != 0L)
              return (index1 << 6) + index2 + 1;
          }
        }
      }
      return 0;
    }

    [LineNumberTable(new byte[] {159, 167, 116, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void set(Bits other)
    {
      int num = Math.min(this.bits.Length, other.bits.Length);
      ByteCodeHelper.arraycopy_primitive_8((Array) other.bits, 0, (Array) this.bits, 0, num);
    }

    [LineNumberTable(new byte[] {159, 189, 100, 108, 105, 125})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool getAndClear(int index)
    {
      int index1 = (int) ((uint) index >> 6);
      if (index1 >= this.bits.Length)
        return false;
      long bit = this.bits[index1];
      long[] bits = this.bits;
      int index2 = index1;
      long[] numArray = bits;
      numArray[index2] = numArray[index2] & (1L << index ^ -1L);
      return this.bits[index1] != bit;
    }

    [LineNumberTable(new byte[] {38, 100, 103, 122})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void flip(int index)
    {
      int num = (int) ((uint) index >> 6);
      this.checkCapacity(num);
      long[] bits = this.bits;
      int index1 = num;
      long[] numArray = bits;
      numArray[index1] = numArray[index1] ^ 1L << index;
    }

    [LineNumberTable(122)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int numBits() => this.bits.Length << 6;

    [LineNumberTable(new byte[] {97, 103, 99, 102, 103, 2, 230, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isEmpty()
    {
      long[] bits = this.bits;
      int length = bits.Length;
      for (int index = 0; index < length; ++index)
      {
        if (bits[index] != 0L)
          return false;
      }
      return true;
    }

    [LineNumberTable(new byte[] {112, 103, 100, 99, 102, 100, 101, 108, 113, 7, 232, 70, 104, 99, 100, 101, 105, 113, 7, 232, 60, 230, 76})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int nextSetBit(int fromIndex)
    {
      long[] bits = this.bits;
      int index1 = (int) ((uint) fromIndex >> 6);
      int length = bits.Length;
      if (index1 >= length)
        return -1;
      long num1 = bits[index1];
      if (num1 != 0L)
      {
        for (int index2 = fromIndex & 63; index2 < 64; ++index2)
        {
          if ((num1 & 1L << index2) != 0L)
            return (index1 << 6) + index2;
        }
      }
      for (int index2 = index1 + 1; index2 < length; ++index2)
      {
        if (index2 != 0)
        {
          long num2 = bits[index2];
          if (num2 != 0L)
          {
            for (int index3 = 0; index3 < 64; ++index3)
            {
              if ((num2 & 1L << index3) != 0L)
                return (index2 << 6) + index3;
            }
          }
        }
      }
      return -1;
    }

    [LineNumberTable(new byte[] {160, 77, 103, 100, 99, 105, 100, 108, 113, 7, 232, 69, 104, 99, 132, 100, 105, 113, 7, 232, 59, 230, 75})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int nextClearBit(int fromIndex)
    {
      long[] bits = this.bits;
      int index1 = (int) ((uint) fromIndex >> 6);
      int length = bits.Length;
      if (index1 >= length)
        return bits.Length << 6;
      long num1 = bits[index1];
      for (int index2 = fromIndex & 63; index2 < 64; ++index2)
      {
        if ((num1 & 1L << index2) == 0L)
          return (index1 << 6) + index2;
      }
      for (int index2 = index1 + 1; index2 < length; ++index2)
      {
        if (index2 == 0)
          return index2 << 6;
        long num2 = bits[index2];
        for (int index3 = 0; index3 < 64; ++index3)
        {
          if ((num2 & 1L << index3) == 0L)
            return (index2 << 6) + index3;
        }
      }
      return bits.Length << 6;
    }

    [LineNumberTable(new byte[] {160, 108, 116, 102, 56, 198, 106, 112, 42, 198})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void and(Bits other)
    {
      int num = Math.min(this.bits.Length, other.bits.Length);
      for (int index1 = 0; num > index1; ++index1)
      {
        long[] bits = this.bits;
        int index2 = index1;
        long[] numArray = bits;
        numArray[index2] = numArray[index2] & other.bits[index1];
      }
      if (this.bits.Length <= num)
        return;
      int index = num;
      for (int length = this.bits.Length; length > index; ++index)
        this.bits[index] = 0L;
    }

    [LineNumberTable(new byte[] {160, 125, 122, 62, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void andNot(Bits other)
    {
      int index1 = 0;
      int length1 = this.bits.Length;
      for (int length2 = other.bits.Length; index1 < length1 && index1 < length2; ++index1)
      {
        long[] bits = this.bits;
        int index2 = index1;
        long[] numArray = bits;
        numArray[index2] = numArray[index2] & (other.bits[index1] ^ -1L);
      }
    }

    [LineNumberTable(new byte[] {160, 137, 116, 102, 56, 198, 106, 109, 112, 48, 198})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void or(Bits other)
    {
      int num = Math.min(this.bits.Length, other.bits.Length);
      for (int index1 = 0; num > index1; ++index1)
      {
        long[] bits = this.bits;
        int index2 = index1;
        long[] numArray = bits;
        numArray[index2] = numArray[index2] | other.bits[index1];
      }
      if (num >= other.bits.Length)
        return;
      this.checkCapacity(other.bits.Length);
      int index = num;
      for (int length = other.bits.Length; length > index; ++index)
        this.bits[index] = other.bits[index];
    }

    [LineNumberTable(new byte[] {160, 159, 148, 102, 56, 198, 106, 109, 112, 48, 198})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void xor(Bits other)
    {
      int num = Math.min(this.bits.Length, other.bits.Length);
      for (int index1 = 0; num > index1; ++index1)
      {
        long[] bits = this.bits;
        int index2 = index1;
        long[] numArray = bits;
        numArray[index2] = numArray[index2] ^ other.bits[index1];
      }
      if (num >= other.bits.Length)
        return;
      this.checkCapacity(other.bits.Length);
      int index = num;
      for (int length = other.bits.Length; length > index; ++index)
        this.bits[index] = other.bits[index];
    }

    [LineNumberTable(new byte[] {160, 179, 103, 103, 112, 107, 2, 230, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool intersects(Bits other)
    {
      long[] bits1 = this.bits;
      long[] bits2 = other.bits;
      for (int index = Math.min(bits1.Length, bits2.Length) - 1; index >= 0; index += -1)
      {
        if ((bits1[index] & bits2[index]) != 0L)
          return true;
      }
      return false;
    }

    [LineNumberTable(new byte[] {160, 196, 103, 103, 99, 131, 104, 104, 2, 232, 69, 112, 111, 2, 232, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool containsAll(Bits other)
    {
      long[] bits1 = this.bits;
      long[] bits2 = other.bits;
      int length1 = bits2.Length;
      int length2 = bits1.Length;
      for (int index = length2; index < length1; ++index)
      {
        if (bits2[index] != 0L)
          return false;
      }
      for (int index = Math.min(length2, length1) - 1; index >= 0; index += -1)
      {
        if ((bits1[index] & bits2[index]) != bits2[index])
          return false;
      }
      return true;
    }

    [LineNumberTable(new byte[] {160, 216, 105, 98, 102, 59, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int hashCode()
    {
      int num1 = (int) ((uint) this.length() >> 6);
      int num2 = 0;
      for (int index = 0; num1 >= index; ++index)
        num2 = (int) sbyte.MaxValue * num2 + (int) (this.bits[index] ^ (long) ((ulong) this.bits[index] >> 32));
      return num2;
    }

    [LineNumberTable(new byte[] {160, 226, 107, 101, 149, 103, 135, 111, 102, 109, 2, 230, 69, 107, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool equals(object obj)
    {
      if (object.ReferenceEquals((object) this, obj))
        return true;
      if (obj == null || !object.ReferenceEquals((object) ((object) this).GetType(), (object) obj.GetType()))
        return false;
      Bits bits1 = (Bits) obj;
      long[] bits2 = bits1.bits;
      int num = Math.min(this.bits.Length, bits2.Length);
      for (int index = 0; num > index; ++index)
      {
        if (this.bits[index] != bits2[index])
          return false;
      }
      return this.bits.Length == bits2.Length || this.length() == bits1.length();
    }
  }
}
