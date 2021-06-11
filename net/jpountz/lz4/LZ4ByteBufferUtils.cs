// Decompiled with JetBrains decompiler
// Type: net.jpountz.lz4.LZ4ByteBufferUtils
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
  [Signature("Ljava/lang/Enum<Lnet/jpountz/lz4/LZ4ByteBufferUtils;>;")]
  [Modifiers]
  [Serializable]
  internal sealed class LZ4ByteBufferUtils : Enum
  {
    [Modifiers]
    private static LZ4ByteBufferUtils[] \u0024VALUES;
    [Modifiers]
    internal static bool \u0024assertionsDisabled;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {160, 95, 104, 110, 139, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static int writeLen([In] int obj0, [In] ByteBuffer obj1, [In] int obj2)
    {
      for (; obj0 >= (int) byte.MaxValue; obj0 += -255)
      {
        ByteBuffer byteBuffer = obj1;
        int num = obj2;
        ++obj2;
        byteBuffer.put(num, byte.MaxValue);
      }
      ByteBuffer byteBuffer1 = obj1;
      int num1 = obj2;
      ++obj2;
      int num2 = (int) (sbyte) obj0;
      byteBuffer1.put(num1, (byte) num2);
      return obj2;
    }

    [LineNumberTable(new byte[] {86, 159, 6, 103, 51, 249, 69, 2, 97, 159, 6})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static void wildArraycopy(
      [In] ByteBuffer obj0,
      [In] int obj1,
      [In] ByteBuffer obj2,
      [In] int obj3,
      [In] int obj4)
    {
      if (!LZ4ByteBufferUtils.\u0024assertionsDisabled)
      {
        if (!Object.instancehelper_equals((object) obj0.order(), (object) obj2.order()))
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new AssertionError();
        }
      }
      try
      {
        for (int index = 0; index < obj4; index += 8)
          obj2.putLong(obj3 + index, obj0.getLong(obj1 + index));
        return;
      }
      catch (Exception ex)
      {
        if (ByteCodeHelper.MapException<IndexOutOfBoundsException>(ex, (ByteCodeHelper.MapFlags) 2) == null)
          throw;
      }
      string msg = new StringBuilder().append("Malformed input at offset ").append(obj1).toString();
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new LZ4Exception(msg);
    }

    [LineNumberTable(new byte[] {80, 103, 52, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static void safeArraycopy(
      [In] ByteBuffer obj0,
      [In] int obj1,
      [In] ByteBuffer obj2,
      [In] int obj3,
      [In] int obj4)
    {
      for (int index = 0; index < obj4; ++index)
        obj2.put(obj3 + index, obj0.get(obj1 + index));
    }

    [LineNumberTable(32)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static LZ4ByteBufferUtils[] values() => (LZ4ByteBufferUtils[]) LZ4ByteBufferUtils.\u0024VALUES.Clone();

    [LineNumberTable(32)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static LZ4ByteBufferUtils valueOf([In] string obj0) => (LZ4ByteBufferUtils) Enum.valueOf((Class) ClassLiteral<LZ4ByteBufferUtils>.Value, obj0);

    [Signature("()V")]
    [LineNumberTable(new byte[] {159, 174, 232, 160, 185})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private LZ4ByteBufferUtils([In] string obj0, [In] int obj1)
      : base(obj0, obj1)
    {
      GC.KeepAlive((object) this);
    }

    [LineNumberTable(35)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static int hash([In] ByteBuffer obj0, [In] int obj1) => LZ4Utils.hash(ByteBufferUtils.readInt(obj0, obj1));

    [LineNumberTable(39)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static int hash64k([In] ByteBuffer obj0, [In] int obj1) => LZ4Utils.hash64k(ByteBufferUtils.readInt(obj0, obj1));

    [LineNumberTable(43)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static bool readIntEquals([In] ByteBuffer obj0, [In] int obj1, [In] int obj2) => obj0.getInt(obj1) == obj0.getInt(obj2);

    [LineNumberTable(new byte[] {159, 189, 102, 52, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static void safeIncrementalCopy([In] ByteBuffer obj0, [In] int obj1, [In] int obj2, [In] int obj3)
    {
      for (int index = 0; index < obj3; ++index)
        obj0.put(obj2 + index, obj0.get(obj1 + index));
    }

    [LineNumberTable(new byte[] {3, 105, 102, 51, 166, 101, 101, 98, 124, 159, 9, 102, 130, 102, 130, 102, 98, 130, 98, 130, 98, 130, 98, 194, 110, 101, 101, 104, 110, 135, 100, 110, 101, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static void wildIncrementalCopy([In] ByteBuffer obj0, [In] int obj1, [In] int obj2, [In] int obj3)
    {
      if (obj2 - obj1 < 4)
      {
        for (int index = 0; index < 4; ++index)
          ByteBufferUtils.writeByte(obj0, obj2 + index, (int) (sbyte) ByteBufferUtils.readByte(obj0, obj1 + index));
        obj2 += 4;
        obj1 += 4;
        int num = 0;
        if (!LZ4ByteBufferUtils.\u0024assertionsDisabled && (obj2 < obj1 || obj2 - obj1 >= 8))
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
        ByteBufferUtils.writeInt(obj0, obj2, ByteBufferUtils.readInt(obj0, obj1));
        obj2 += 4;
        obj1 -= num;
      }
      else if (obj2 - obj1 < 8)
      {
        ByteBufferUtils.writeLong(obj0, obj2, ByteBufferUtils.readLong(obj0, obj1));
        obj2 += obj2 - obj1;
      }
      while (obj2 < obj3)
      {
        ByteBufferUtils.writeLong(obj0, obj2, ByteBufferUtils.readLong(obj0, obj1));
        obj2 += 8;
        obj1 += 8;
      }
    }

    [LineNumberTable(new byte[] {49, 98, 105, 112, 100, 101, 167, 114, 151, 149, 166, 127, 1, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static int commonBytes([In] ByteBuffer obj0, [In] int obj1, [In] int obj2, [In] int obj3)
    {
      int num1 = 0;
      for (; obj2 <= obj3 - 8; obj2 += 8)
      {
        if (ByteBufferUtils.readLong(obj0, obj2) == ByteBufferUtils.readLong(obj0, obj1))
        {
          num1 += 8;
          obj1 += 8;
        }
        else
        {
          int num2 = !object.ReferenceEquals((object) obj0.order(), (object) ByteOrder.BIG_ENDIAN) ? Long.numberOfTrailingZeros(ByteBufferUtils.readLong(obj0, obj2) ^ ByteBufferUtils.readLong(obj0, obj1)) : Long.numberOfLeadingZeros(ByteBufferUtils.readLong(obj0, obj2) ^ ByteBufferUtils.readLong(obj0, obj1));
          return num1 + (int) ((uint) num2 >> 3);
        }
      }
      while (obj2 < obj3)
      {
        ByteBuffer buf1 = obj0;
        int i1 = obj1;
        ++obj1;
        int num2 = (int) (sbyte) ByteBufferUtils.readByte(buf1, i1);
        ByteBuffer buf2 = obj0;
        int i2 = obj2;
        ++obj2;
        int num3 = (int) (sbyte) ByteBufferUtils.readByte(buf2, i2);
        if (num2 == num3)
          ++num1;
        else
          break;
      }
      return num1;
    }

    [LineNumberTable(new byte[] {72, 98, 127, 6, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static int commonBytesBackward(
      [In] ByteBuffer obj0,
      [In] int obj1,
      [In] int obj2,
      [In] int obj3,
      [In] int obj4)
    {
      int num1 = 0;
      while (obj1 > obj3 && obj2 > obj4)
      {
        ByteBuffer byteBuffer1 = obj0;
        obj1 += -1;
        int num2 = obj1;
        int num3 = (int) (sbyte) byteBuffer1.get(num2);
        ByteBuffer byteBuffer2 = obj0;
        obj2 += -1;
        int num4 = obj2;
        int num5 = (int) (sbyte) byteBuffer2.get(num4);
        if (num3 == num5)
          ++num1;
        else
          break;
      }
      return num1;
    }

    [LineNumberTable(new byte[] {97, 100, 137, 110, 208, 101, 99, 145, 196, 108, 166, 100, 114, 180, 103, 109, 144, 102, 101, 146, 165, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static int encodeSequence(
      [In] ByteBuffer obj0,
      [In] int obj1,
      [In] int obj2,
      [In] int obj3,
      [In] int obj4,
      [In] ByteBuffer obj5,
      [In] int obj6,
      [In] int obj7)
    {
      int num1 = obj2 - obj1;
      int num2 = obj6;
      ++obj6;
      int num3 = num2;
      if (obj6 + num1 + 8 + (int) ((uint) num1 >> 8) > obj7)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new LZ4Exception("maxDestLen is too small");
      }
      int num4;
      if (num1 >= 15)
      {
        num4 = -16;
        obj6 = LZ4ByteBufferUtils.writeLen(num1 - 15, obj5, obj6);
      }
      else
        num4 = num1 << 4;
      LZ4ByteBufferUtils.wildArraycopy(obj0, obj1, obj5, obj6, num1);
      obj6 += num1;
      int num5 = obj2 - obj3;
      ByteBuffer byteBuffer1 = obj5;
      int num6 = obj6;
      ++obj6;
      int num7 = (int) (sbyte) num5;
      byteBuffer1.put(num6, (byte) num7);
      ByteBuffer byteBuffer2 = obj5;
      int num8 = obj6;
      ++obj6;
      int num9 = (int) (sbyte) ((uint) num5 >> 8);
      byteBuffer2.put(num8, (byte) num9);
      obj4 += -4;
      if (obj6 + 6 + (int) ((uint) obj4 >> 8) > obj7)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new LZ4Exception("maxDestLen is too small");
      }
      int num10;
      if (obj4 >= 15)
      {
        num10 = num4 | 15;
        obj6 = LZ4ByteBufferUtils.writeLen(obj4 - 15, obj5, obj6);
      }
      else
        num10 = num4 | obj4;
      obj5.put(num3, (byte) num10);
      return obj6;
    }

    [LineNumberTable(new byte[] {160, 75, 130, 123, 171, 101, 113, 144, 179, 107, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static int lastLiterals(
      [In] ByteBuffer obj0,
      [In] int obj1,
      [In] int obj2,
      [In] ByteBuffer obj3,
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
        ByteBuffer byteBuffer = obj3;
        int num2 = obj4;
        ++obj4;
        byteBuffer.put(num2, (byte) 240);
        obj4 = LZ4ByteBufferUtils.writeLen(num1 - 15, obj3, obj4);
      }
      else
      {
        ByteBuffer byteBuffer = obj3;
        int num2 = obj4;
        ++obj4;
        int num3 = (int) (sbyte) (num1 << 4);
        byteBuffer.put(num2, (byte) num3);
      }
      LZ4ByteBufferUtils.safeArraycopy(obj0, obj1, obj3, obj4, num1);
      obj4 += num1;
      return obj4;
    }

    [LineNumberTable(new byte[] {160, 118, 108, 108, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static void copyTo([In] LZ4ByteBufferUtils.Match obj0, [In] LZ4ByteBufferUtils.Match obj1)
    {
      obj1.len = obj0.len;
      obj1.start = obj0.start;
      obj1.@ref = obj0.@ref;
    }

    [LineNumberTable(32)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static LZ4ByteBufferUtils()
    {
      if (ByteCodeHelper.isAlreadyInited("net.jpountz.lz4.LZ4ByteBufferUtils"))
        return;
      LZ4ByteBufferUtils.\u0024assertionsDisabled = !((Class) ClassLiteral<LZ4ByteBufferUtils>.Value).desiredAssertionStatus();
      LZ4ByteBufferUtils.\u0024VALUES = new LZ4ByteBufferUtils[0];
    }

    internal class Match : Object
    {
      internal int start;
      internal int @ref;
      internal int len;

      [LineNumberTable(217)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal Match()
      {
      }

      [LineNumberTable(new byte[] {160, 107, 110, 110, 110})]
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
