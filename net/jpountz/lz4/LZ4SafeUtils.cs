// Decompiled with JetBrains decompiler
// Type: net.jpountz.lz4.LZ4SafeUtils
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using net.jpountz.util;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace net.jpountz.lz4
{
  [Signature("Ljava/lang/Enum<Lnet/jpountz/lz4/LZ4SafeUtils;>;")]
  [Modifiers]
  [Serializable]
  internal sealed class LZ4SafeUtils : Enum
  {
    [Modifiers]
    private static LZ4SafeUtils[] \u0024VALUES;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(35)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static bool readIntEquals([In] byte[] obj0, [In] int obj1, [In] int obj2) => (int) (sbyte) obj0[obj1] == (int) (sbyte) obj0[obj2] && (int) (sbyte) obj0[obj1 + 1] == (int) (sbyte) obj0[obj2 + 1] && ((int) (sbyte) obj0[obj1 + 2] == (int) (sbyte) obj0[obj2 + 2] && (int) (sbyte) obj0[obj1 + 3] == (int) (sbyte) obj0[obj2 + 3]);

    [LineNumberTable(new byte[] {9, 98, 118, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static int commonBytes([In] byte[] obj0, [In] int obj1, [In] int obj2, [In] int obj3)
    {
      int num1 = 0;
      while (obj2 < obj3)
      {
        byte[] numArray1 = obj0;
        int index1 = obj1;
        ++obj1;
        int num2 = (int) (sbyte) numArray1[index1];
        byte[] numArray2 = obj0;
        int index2 = obj2;
        ++obj2;
        int num3 = (int) (sbyte) numArray2[index2];
        if (num2 == num3)
          ++num1;
        else
          break;
      }
      return num1;
    }

    [LineNumberTable(new byte[] {17, 98, 123, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static int commonBytesBackward([In] byte[] obj0, [In] int obj1, [In] int obj2, [In] int obj3, [In] int obj4)
    {
      int num1 = 0;
      while (obj1 > obj3 && obj2 > obj4)
      {
        byte[] numArray1 = obj0;
        obj1 += -1;
        int index1 = obj1;
        int num2 = (int) (sbyte) numArray1[index1];
        byte[] numArray2 = obj0;
        obj2 += -1;
        int index2 = obj2;
        int num3 = (int) (sbyte) numArray2[index2];
        if (num2 == num3)
          ++num1;
        else
          break;
      }
      return num1;
    }

    [LineNumberTable(new byte[] {39, 100, 137, 110, 208, 101, 99, 145, 196, 108, 166, 100, 109, 175, 103, 109, 144, 102, 101, 146, 165, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static int encodeSequence(
      [In] byte[] obj0,
      [In] int obj1,
      [In] int obj2,
      [In] int obj3,
      [In] int obj4,
      [In] byte[] obj5,
      [In] int obj6,
      [In] int obj7)
    {
      int num1 = obj2 - obj1;
      int num2 = obj6;
      ++obj6;
      int index1 = num2;
      if (obj6 + num1 + 8 + (int) ((uint) num1 >> 8) > obj7)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new LZ4Exception("maxDestLen is too small");
      }
      int num3;
      if (num1 >= 15)
      {
        num3 = -16;
        obj6 = LZ4SafeUtils.writeLen(num1 - 15, obj5, obj6);
      }
      else
        num3 = num1 << 4;
      LZ4SafeUtils.wildArraycopy(obj0, obj1, obj5, obj6, num1);
      obj6 += num1;
      int num4 = obj2 - obj3;
      byte[] numArray1 = obj5;
      int index2 = obj6;
      ++obj6;
      int num5 = (int) (sbyte) num4;
      numArray1[index2] = (byte) num5;
      byte[] numArray2 = obj5;
      int index3 = obj6;
      ++obj6;
      int num6 = (int) (sbyte) ((uint) num4 >> 8);
      numArray2[index3] = (byte) num6;
      obj4 += -4;
      if (obj6 + 6 + (int) ((uint) obj4 >> 8) > obj7)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new LZ4Exception("maxDestLen is too small");
      }
      int num7;
      if (obj4 >= 15)
      {
        num7 = num3 | 15;
        obj6 = LZ4SafeUtils.writeLen(obj4 - 15, obj5, obj6);
      }
      else
        num7 = num3 | obj4;
      obj5[index1] = (byte) num7;
      return obj6;
    }

    [LineNumberTable(new byte[] {81, 130, 123, 171, 101, 108, 144, 174, 107, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static int lastLiterals(
      [In] byte[] obj0,
      [In] int obj1,
      [In] int obj2,
      [In] byte[] obj3,
      [In] int obj4,
      [In] int obj5)
    {
      int num1 = obj2;
      if (obj4 + num1 + 1 + (num1 + (int) byte.MaxValue - 15) / (int) byte.MaxValue > obj5)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new LZ4Exception();
      }
      if (num1 >= 15)
      {
        byte[] numArray = obj3;
        int index = obj4;
        ++obj4;
        numArray[index] = (byte) 240;
        obj4 = LZ4SafeUtils.writeLen(num1 - 15, obj3, obj4);
      }
      else
      {
        byte[] numArray = obj3;
        int index = obj4;
        ++obj4;
        int num2 = (int) (sbyte) (num1 << 4);
        numArray[index] = (byte) num2;
      }
      ByteCodeHelper.arraycopy_primitive_1((Array) obj0, obj1, (Array) obj3, obj4, num1);
      obj4 += num1;
      return obj4;
    }

    [LineNumberTable(new byte[] {101, 104, 105, 139, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static int writeLen([In] int obj0, [In] byte[] obj1, [In] int obj2)
    {
      for (; obj0 >= (int) byte.MaxValue; obj0 += -255)
      {
        byte[] numArray = obj1;
        int index = obj2;
        ++obj2;
        numArray[index] = byte.MaxValue;
      }
      byte[] numArray1 = obj1;
      int index1 = obj2;
      ++obj2;
      int num = (int) (sbyte) obj0;
      numArray1[index1] = (byte) num;
      return obj2;
    }

    [LineNumberTable(new byte[] {30, 103, 45, 249, 69, 2, 97, 159, 6})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static void wildArraycopy([In] byte[] obj0, [In] int obj1, [In] byte[] obj2, [In] int obj3, [In] int obj4)
    {
      try
      {
        for (int index = 0; index < obj4; index += 8)
          LZ4SafeUtils.copy8Bytes(obj0, obj1 + index, obj2, obj3 + index);
        return;
      }
      catch (Exception ex)
      {
        if (ByteCodeHelper.MapException<ArrayIndexOutOfBoundsException>(ex, (ByteCodeHelper.MapFlags) 2) == null)
          throw;
      }
      string msg = new StringBuilder().append("Malformed input at offset ").append(obj1).toString();
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new LZ4Exception(msg);
    }

    [LineNumberTable(new byte[] {25, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static void safeArraycopy([In] byte[] obj0, [In] int obj1, [In] byte[] obj2, [In] int obj3, [In] int obj4) => ByteCodeHelper.arraycopy_primitive_1((Array) obj0, obj1, (Array) obj2, obj3, obj4);

    [LineNumberTable(new byte[] {159, 181, 102, 42, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static void safeIncrementalCopy([In] byte[] obj0, [In] int obj1, [In] int obj2, [In] int obj3)
    {
      for (int index = 0; index < obj3; ++index)
        obj0[obj2 + index] = obj0[obj1 + index];
    }

    [LineNumberTable(new byte[] {159, 188, 105, 101, 101, 100})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static void wildIncrementalCopy([In] byte[] obj0, [In] int obj1, [In] int obj2, [In] int obj3)
    {
      do
      {
        LZ4SafeUtils.copy8Bytes(obj0, obj1, obj0, obj2);
        obj1 += 8;
        obj2 += 8;
      }
      while (obj2 < obj3);
    }

    [LineNumberTable(new byte[] {3, 102, 42, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static void copy8Bytes([In] byte[] obj0, [In] int obj1, [In] byte[] obj2, [In] int obj3)
    {
      for (int index = 0; index < 8; ++index)
        obj2[obj3 + index] = obj0[obj1 + index];
    }

    [LineNumberTable(23)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static LZ4SafeUtils[] values() => (LZ4SafeUtils[]) LZ4SafeUtils.\u0024VALUES.Clone();

    [LineNumberTable(23)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static LZ4SafeUtils valueOf([In] string obj0) => (LZ4SafeUtils) Enum.valueOf((Class) ClassLiteral<LZ4SafeUtils>.Value, obj0);

    [Signature("()V")]
    [LineNumberTable(new byte[] {159, 165, 232, 160, 136})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private LZ4SafeUtils([In] string obj0, [In] int obj1)
      : base(obj0, obj1)
    {
      GC.KeepAlive((object) this);
    }

    [LineNumberTable(27)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static int hash([In] byte[] obj0, [In] int obj1) => LZ4Utils.hash(SafeUtils.readInt(obj0, obj1));

    [LineNumberTable(31)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static int hash64k([In] byte[] obj0, [In] int obj1) => LZ4Utils.hash64k(SafeUtils.readInt(obj0, obj1));

    [LineNumberTable(new byte[] {124, 108, 108, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static void copyTo([In] LZ4SafeUtils.Match obj0, [In] LZ4SafeUtils.Match obj1)
    {
      obj1.len = obj0.len;
      obj1.start = obj0.start;
      obj1.@ref = obj0.@ref;
    }

    [LineNumberTable(23)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static LZ4SafeUtils()
    {
      if (ByteCodeHelper.isAlreadyInited("net.jpountz.lz4.LZ4SafeUtils"))
        return;
      LZ4SafeUtils.\u0024VALUES = new LZ4SafeUtils[0];
    }

    internal class Match : Object
    {
      internal int start;
      internal int @ref;
      internal int len;

      [LineNumberTable(159)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal Match()
      {
      }

      [LineNumberTable(new byte[] {113, 110, 110, 110})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal virtual void fix([In] int obj0)
      {
        this.start += obj0;
        this.@ref += obj0;
        this.len -= obj0;
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      internal virtual int end() => this.start + this.len;
    }
  }
}
