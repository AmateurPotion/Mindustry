// Decompiled with JetBrains decompiler
// Type: arc.util.Pack
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;

namespace arc.util
{
  public class Pack : Object
  {
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static long longInt(int x, int y) => (long) x << 32 | (long) y & (long) uint.MaxValue;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static byte leftByte(byte value) => (byte) ((int) (sbyte) value >> 4 & 15);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static byte rightByte(byte value) => (byte) ((int) (sbyte) value & 15);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int shortInt(short left, short right) => (int) left << 16 | (int) right & (int) ushort.MaxValue;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int leftInt(long field) => (int) (field >> 32);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int rightInt(long field) => (int) field;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static short leftShort(int field) => (short) ((uint) field >> 16);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int intBytes(byte b1, byte b2, byte b3, byte b4) => ((int) byte.MaxValue & (int) (sbyte) b1) << 24 | ((int) byte.MaxValue & (int) (sbyte) b2) << 16 | ((int) byte.MaxValue & (int) (sbyte) b3) << 8 | (int) byte.MaxValue & (int) (sbyte) b4;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static short rightShort(int field) => (short) (field & (int) ushort.MaxValue);

    [LineNumberTable(3)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Pack()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int u(byte b) => (int) (sbyte) b & (int) byte.MaxValue;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int u(short b) => (int) b & (int) ushort.MaxValue;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static long u(int b) => (long) b & (long) uint.MaxValue;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static byte byteValue(bool b) => b ? (byte) 1 : (byte) 0;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static byte byteByte(byte left, byte right) => (byte) ((int) (sbyte) left << 4 | (int) (sbyte) right);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static byte leftByte(short field) => (byte) ((int) field >> 8);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static byte rightByte(short field) => (byte) field;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static short shortByte(byte left, byte right) => (short) ((int) (sbyte) left << 8 | (int) (sbyte) right & (int) byte.MaxValue);

    [LineNumberTable(new byte[] {25, 104, 104, 103, 133})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static byte[] bytes(int i, byte[] result)
    {
      result[0] = (byte) (i >> 24);
      result[1] = (byte) (i >> 16);
      result[2] = (byte) (i >> 8);
      result[3] = (byte) i;
      return result;
    }

    [LineNumberTable(new byte[] {35, 105, 105, 105, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static short[] shorts(long i, short[] resultShort)
    {
      resultShort[0] = (short) (int) (i >> 48);
      resultShort[1] = (short) (int) (i >> 32);
      resultShort[2] = (short) (int) (i >> 16);
      resultShort[3] = (short) (int) i;
      return resultShort;
    }

    [LineNumberTable(94)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static long longShorts(short[] s) => (long) ((int) ushort.MaxValue & (int) s[0]) << 48 | (long) ((int) ushort.MaxValue & (int) s[1]) << 32 | (long) ((int) ushort.MaxValue & (int) s[2]) << 16 | (long) ((int) ushort.MaxValue & (int) s[3]);

    [LineNumberTable(103)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int intBytes(byte[] array) => ((int) byte.MaxValue & (int) (sbyte) array[0]) << 24 | ((int) byte.MaxValue & (int) (sbyte) array[1]) << 16 | ((int) byte.MaxValue & (int) (sbyte) array[2]) << 8 | (int) byte.MaxValue & (int) (sbyte) array[3];
  }
}
