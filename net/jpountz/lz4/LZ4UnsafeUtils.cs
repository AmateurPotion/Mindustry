// Decompiled with JetBrains decompiler
// Type: net.jpountz.lz4.LZ4UnsafeUtils
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.nio;
using net.jpountz.util;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace net.jpountz.lz4
{
  [Signature("Ljava/lang/Enum<Lnet/jpountz/lz4/LZ4UnsafeUtils;>;")]
  [Modifiers]
  [Serializable]
  internal sealed class LZ4UnsafeUtils : Enum
  {
    [Modifiers]
    private static LZ4UnsafeUtils[] \u0024VALUES;
    [Modifiers]
    internal static bool \u0024assertionsDisabled;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(121)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static bool readIntEquals([In] byte[] obj0, [In] int obj1, [In] int obj2) => UnsafeUtils.readInt(obj0, obj1) == UnsafeUtils.readInt(obj0, obj2);

    [LineNumberTable(new byte[] {75, 98, 105, 112, 100, 101, 167, 113, 151, 149, 166, 127, 1, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static int commonBytes([In] byte[] obj0, [In] int obj1, [In] int obj2, [In] int obj3)
    {
      int num1 = 0;
      for (; obj2 <= obj3 - 8; obj2 += 8)
      {
        if (UnsafeUtils.readLong(obj0, obj2) == UnsafeUtils.readLong(obj0, obj1))
        {
          num1 += 8;
          obj1 += 8;
        }
        else
        {
          int num2 = !object.ReferenceEquals((object) Utils.__\u003C\u003ENATIVE_BYTE_ORDER, (object) ByteOrder.BIG_ENDIAN) ? Long.numberOfTrailingZeros(UnsafeUtils.readLong(obj0, obj2) ^ UnsafeUtils.readLong(obj0, obj1)) : Long.numberOfLeadingZeros(UnsafeUtils.readLong(obj0, obj2) ^ UnsafeUtils.readLong(obj0, obj1));
          return num1 + (int) ((uint) num2 >> 3);
        }
      }
      while (obj2 < obj3)
      {
        byte[] src1 = obj0;
        int srcOff1 = obj1;
        ++obj1;
        int num2 = (int) (sbyte) UnsafeUtils.readByte(src1, srcOff1);
        byte[] src2 = obj0;
        int srcOff2 = obj2;
        ++obj2;
        int num3 = (int) (sbyte) UnsafeUtils.readByte(src2, srcOff2);
        if (num2 == num3)
          ++num1;
        else
          break;
      }
      return num1;
    }

    [LineNumberTable(new byte[] {160, 81, 98, 127, 6, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static int commonBytesBackward([In] byte[] obj0, [In] int obj1, [In] int obj2, [In] int obj3, [In] int obj4)
    {
      int num1 = 0;
      while (obj1 > obj3 && obj2 > obj4)
      {
        byte[] src1 = obj0;
        obj1 += -1;
        int srcOff1 = obj1;
        int num2 = (int) (sbyte) UnsafeUtils.readByte(src1, srcOff1);
        byte[] src2 = obj0;
        obj2 += -1;
        int srcOff2 = obj2;
        int num3 = (int) (sbyte) UnsafeUtils.readByte(src2, srcOff2);
        if (num2 == num3)
          ++num1;
        else
          break;
      }
      return num1;
    }

    [LineNumberTable(new byte[] {107, 100, 169, 101, 99, 145, 196, 108, 166, 100, 109, 175, 103, 109, 144, 102, 101, 146, 165, 134})]
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
      int num3;
      if (num1 >= 15)
      {
        num3 = -16;
        obj6 = LZ4UnsafeUtils.writeLen(num1 - 15, obj5, obj6);
      }
      else
        num3 = num1 << 4;
      LZ4UnsafeUtils.wildArraycopy(obj0, obj1, obj5, obj6, num1);
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
        obj6 = LZ4UnsafeUtils.writeLen(obj4 - 15, obj5, obj6);
      }
      else
        num7 = num3 | obj4;
      obj5[index1] = (byte) num7;
      return obj6;
    }

    [LineNumberTable(203)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static int lastLiterals(
      [In] byte[] obj0,
      [In] int obj1,
      [In] int obj2,
      [In] byte[] obj3,
      [In] int obj4,
      [In] int obj5)
    {
      return LZ4SafeUtils.lastLiterals(obj0, obj1, obj2, obj3, obj4, obj5);
    }

    [LineNumberTable(new byte[] {98, 104, 113, 139, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static int writeLen([In] int obj0, [In] byte[] obj1, [In] int obj2)
    {
      for (; obj0 >= (int) byte.MaxValue; obj0 += -255)
      {
        byte[] src = obj1;
        int srcOff = obj2;
        ++obj2;
        UnsafeUtils.writeByte(src, srcOff, (int) byte.MaxValue);
      }
      byte[] src1 = obj1;
      int srcOff1 = obj2;
      ++obj2;
      int num = obj0;
      UnsafeUtils.writeByte(src1, srcOff1, num);
      return obj2;
    }

    [LineNumberTable(new byte[] {159, 188, 103, 50, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static void wildArraycopy([In] byte[] obj0, [In] int obj1, [In] byte[] obj2, [In] int obj3, [In] int obj4)
    {
      for (int index = 0; index < obj4; index += 8)
        UnsafeUtils.writeLong(obj2, obj3 + index, UnsafeUtils.readLong(obj0, obj1 + index));
    }

    [LineNumberTable(new byte[] {159, 180, 102, 106, 107, 55, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static void safeArraycopy([In] byte[] obj0, [In] int obj1, [In] byte[] obj2, [In] int obj3, [In] int obj4)
    {
      int num1 = obj4 & -8;
      LZ4UnsafeUtils.wildArraycopy(obj0, obj1, obj2, obj3, num1);
      int num2 = 0;
      for (int index = obj4 & 7; num2 < index; ++num2)
        UnsafeUtils.writeByte(obj2, obj3 + num1 + num2, UnsafeUtils.readByte(obj0, obj1 + num1 + num2));
    }

    [LineNumberTable(new byte[] {48, 102, 106, 19, 198})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static void safeIncrementalCopy([In] byte[] obj0, [In] int obj1, [In] int obj2, [In] int obj3)
    {
      for (int index = 0; index < obj3; ++index)
      {
        obj0[obj2 + index] = obj0[obj1 + index];
        UnsafeUtils.writeByte(obj0, obj2 + index, UnsafeUtils.readByte(obj0, obj1 + index));
      }
    }

    [LineNumberTable(new byte[] {2, 105, 102, 51, 166, 101, 101, 98, 124, 159, 9, 102, 130, 102, 130, 102, 98, 130, 98, 130, 98, 130, 98, 194, 110, 101, 101, 104, 110, 135, 100, 110, 101, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static void wildIncrementalCopy([In] byte[] obj0, [In] int obj1, [In] int obj2, [In] int obj3)
    {
      if (obj2 - obj1 < 4)
      {
        for (int index = 0; index < 4; ++index)
          UnsafeUtils.writeByte(obj0, obj2 + index, UnsafeUtils.readByte(obj0, obj1 + index));
        obj2 += 4;
        obj1 += 4;
        int num = 0;
        if (!LZ4UnsafeUtils.\u0024assertionsDisabled && (obj2 < obj1 || obj2 - obj1 >= 8))
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new AssertionError();
        }
        switch (obj2 - obj1)
        {
          case 1:
            obj1 += -3;
            break;
          case 2:
            obj1 += -2;
            break;
          case 3:
            obj1 += -3;
            num = -1;
            break;
          case 5:
            num = 1;
            break;
          case 6:
            num = 2;
            break;
          case 7:
            num = 3;
            break;
        }
        UnsafeUtils.writeInt(obj0, obj2, UnsafeUtils.readInt(obj0, obj1));
        obj2 += 4;
        obj1 -= num;
      }
      else if (obj2 - obj1 < 8)
      {
        UnsafeUtils.writeLong(obj0, obj2, UnsafeUtils.readLong(obj0, obj1));
        obj2 += obj2 - obj1;
      }
      while (obj2 < obj3)
      {
        UnsafeUtils.writeLong(obj0, obj2, UnsafeUtils.readLong(obj0, obj1));
        obj2 += 8;
        obj1 += 8;
      }
    }

    [LineNumberTable(34)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static LZ4UnsafeUtils[] values() => (LZ4UnsafeUtils[]) LZ4UnsafeUtils.\u0024VALUES.Clone();

    [LineNumberTable(34)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static LZ4UnsafeUtils valueOf([In] string obj0) => (LZ4UnsafeUtils) Enum.valueOf((Class) ClassLiteral<LZ4UnsafeUtils>.Value, obj0);

    [Signature("()V")]
    [LineNumberTable(34)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private LZ4UnsafeUtils([In] string obj0, [In] int obj1)
      : base(obj0, obj1)
    {
      GC.KeepAlive((object) this);
    }

    [LineNumberTable(new byte[] {55, 104, 113, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static int readShortLittleEndian([In] byte[] obj0, [In] int obj1)
    {
      int num = (int) UnsafeUtils.readShort(obj0, obj1);
      if (object.ReferenceEquals((object) Utils.__\u003C\u003ENATIVE_BYTE_ORDER, (object) ByteOrder.BIG_ENDIAN))
        num = (int) Short.reverseBytes((short) num);
      return num & (int) ushort.MaxValue;
    }

    [LineNumberTable(new byte[] {63, 99, 113, 135, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static void writeShortLittleEndian([In] byte[] obj0, [In] int obj1, [In] int obj2)
    {
      int num = (int) (short) obj2;
      if (object.ReferenceEquals((object) Utils.__\u003C\u003ENATIVE_BYTE_ORDER, (object) ByteOrder.BIG_ENDIAN))
        num = (int) Short.reverseBytes((short) num);
      UnsafeUtils.writeShort(obj0, obj1, (short) num);
    }

    [LineNumberTable(34)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static LZ4UnsafeUtils()
    {
      if (ByteCodeHelper.isAlreadyInited("net.jpountz.lz4.LZ4UnsafeUtils"))
        return;
      LZ4UnsafeUtils.\u0024assertionsDisabled = !((Class) ClassLiteral<LZ4UnsafeUtils>.Value).desiredAssertionStatus();
      LZ4UnsafeUtils.\u0024VALUES = new LZ4UnsafeUtils[0];
    }
  }
}
