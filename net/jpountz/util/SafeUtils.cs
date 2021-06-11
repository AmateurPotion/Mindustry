// Decompiled with JetBrains decompiler
// Type: net.jpountz.util.SafeUtils
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.nio;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace net.jpountz.util
{
  [Signature("Ljava/lang/Enum<Lnet/jpountz/util/SafeUtils;>;")]
  [Modifiers]
  [Serializable]
  public sealed class SafeUtils : Enum
  {
    [Modifiers]
    private static SafeUtils[] \u0024VALUES;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 171, 102, 100, 103, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void checkRange(byte[] buf, int off, int len)
    {
      SafeUtils.checkLength(len);
      if (len <= 0)
        return;
      SafeUtils.checkRange(buf, off);
      SafeUtils.checkRange(buf, off + len - 1);
    }

    [LineNumberTable(51)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int readIntLE(byte[] buf, int i) => (int) buf[i] | (int) buf[i + 1] << 8 | (int) buf[i + 2] << 16 | (int) buf[i + 3] << 24;

    [LineNumberTable(new byte[] {5, 113, 136})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int readInt(byte[] buf, int i) => object.ReferenceEquals((object) Utils.__\u003C\u003ENATIVE_BYTE_ORDER, (object) ByteOrder.BIG_ENDIAN) ? SafeUtils.readIntBE(buf, i) : SafeUtils.readIntLE(buf, i);

    [LineNumberTable(new byte[] {159, 165, 105, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void checkRange(byte[] buf, int off)
    {
      if (off < 0 || off >= buf.Length)
      {
        int num = off;
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new ArrayIndexOutOfBoundsException(num);
      }
    }

    [LineNumberTable(93)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int readShort(short[] buf, int off) => (int) buf[off] & (int) ushort.MaxValue;

    [LineNumberTable(new byte[] {35, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void writeShort(short[] buf, int off, int v) => buf[off] = (short) v;

    [LineNumberTable(new byte[] {31, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void writeByte(byte[] dest, int off, int i) => dest[off] = (byte) i;

    [LineNumberTable(new byte[] {18, 106, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void writeShortLE(byte[] buf, int off, int v)
    {
      byte[] numArray1 = buf;
      int index1 = off;
      ++off;
      int num1 = (int) (sbyte) v;
      numArray1[index1] = (byte) num1;
      byte[] numArray2 = buf;
      int index2 = off;
      ++off;
      int num2 = (int) (sbyte) ((uint) v >> 8);
      numArray2[index2] = (byte) num2;
    }

    [LineNumberTable(43)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static byte readByte(byte[] buf, int i) => buf[i];

    [LineNumberTable(77)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int readInt(int[] buf, int off) => buf[off];

    [LineNumberTable(new byte[] {23, 100})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void writeInt(int[] buf, int off, int v) => buf[off] = v;

    [LineNumberTable(89)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int readShortLE(byte[] buf, int i) => (int) buf[i] | (int) buf[i + 1] << 8;

    [LineNumberTable(new byte[] {159, 179, 100, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void checkLength(int len)
    {
      if (len < 0)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException("lengths must be >= 0");
      }
    }

    [LineNumberTable(47)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int readIntBE(byte[] buf, int i) => (int) buf[i] << 24 | (int) buf[i + 1] << 16 | (int) buf[i + 2] << 8 | (int) buf[i + 3];

    [LineNumberTable(19)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static SafeUtils[] values() => (SafeUtils[]) SafeUtils.\u0024VALUES.Clone();

    [LineNumberTable(19)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static SafeUtils valueOf(string name) => (SafeUtils) Enum.valueOf((Class) ClassLiteral<SafeUtils>.Value, name);

    [Signature("()V")]
    [LineNumberTable(19)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private SafeUtils([In] string obj0, [In] int obj1)
      : base(obj0, obj1)
    {
      GC.KeepAlive((object) this);
    }

    [LineNumberTable(63)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static long readLongLE(byte[] buf, int i) => (long) buf[i] | (long) buf[i + 1] << 8 | (long) buf[i + 2] << 16 | (long) buf[i + 3] << 24 | (long) buf[i + 4] << 32 | (long) buf[i + 5] << 40 | (long) buf[i + 6] << 48 | (long) buf[i + 7] << 56;

    [LineNumberTable(19)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static SafeUtils()
    {
      if (ByteCodeHelper.isAlreadyInited("net.jpountz.util.SafeUtils"))
        return;
      SafeUtils.\u0024VALUES = new SafeUtils[0];
    }

    [HideFromJava]
    [Serializable]
    public enum __Enum
    {
    }
  }
}
