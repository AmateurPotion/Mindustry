// Decompiled with JetBrains decompiler
// Type: arc.util.io.CRC
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System.Runtime.CompilerServices;

namespace arc.util.io
{
  public class CRC : Object
  {
    public static int[] table;
    internal int _value;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 147, 232, 79})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public CRC()
    {
      CRC crc = this;
      this._value = -1;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void init() => this._value = -1;

    [LineNumberTable(new byte[] {159, 169, 102, 63, 8, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void update(byte[] data, int offset, int size)
    {
      for (int index = 0; index < size; ++index)
        this._value = CRC.table[(this._value ^ (int) (sbyte) data[offset + index]) & (int) byte.MaxValue] ^ (int) ((uint) this._value >> 8);
    }

    [LineNumberTable(new byte[] {159, 174, 99, 127, 25})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void update(byte[] data)
    {
      int length1 = data.Length;
      byte[] numArray = data;
      int length2 = numArray.Length;
      for (int index = 0; index < length2; ++index)
      {
        int num = (int) (sbyte) numArray[index];
        this._value = CRC.table[(this._value ^ num) & (int) byte.MaxValue] ^ (int) ((uint) this._value >> 8);
      }
    }

    [LineNumberTable(new byte[] {159, 179, 127, 4})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void updateByte(int b) => this._value = CRC.table[(this._value ^ b) & (int) byte.MaxValue] ^ (int) ((uint) this._value >> 8);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getDigest() => this._value ^ -1;

    [LineNumberTable(new byte[] {159, 141, 141, 175, 106, 98, 102, 101, 140, 228, 60, 230, 69, 232, 57, 230, 73})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static CRC()
    {
      if (ByteCodeHelper.isAlreadyInited("arc.util.io.CRC"))
        return;
      CRC.table = new int[256];
      for (int index1 = 0; index1 < 256; ++index1)
      {
        int num = index1;
        for (int index2 = 0; index2 < 8; ++index2)
          num = (num & 1) == 0 ? (int) ((uint) num >> 1) : (int) ((uint) num >> 1) ^ -306674912;
        CRC.table[index1] = num;
      }
    }
  }
}
