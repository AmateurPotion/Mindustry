// Decompiled with JetBrains decompiler
// Type: net.jpountz.util.UnsafeUtils
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.lang.reflect;
using java.nio;
using sun.misc;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace net.jpountz.util
{
  [Signature("Ljava/lang/Enum<Lnet/jpountz/util/UnsafeUtils;>;")]
  [Modifiers]
  [Serializable]
  public sealed class UnsafeUtils : Enum
  {
    [Modifiers]
    private static Unsafe UNSAFE;
    [Modifiers]
    private static long BYTE_ARRAY_OFFSET;
    [Modifiers]
    private static int BYTE_ARRAY_SCALE;
    [Modifiers]
    private static long INT_ARRAY_OFFSET;
    [Modifiers]
    private static int INT_ARRAY_SCALE;
    [Modifiers]
    private static long SHORT_ARRAY_OFFSET;
    [Modifiers]
    private static int SHORT_ARRAY_SCALE;
    [Modifiers]
    private static UnsafeUtils[] \u0024VALUES;
    [SpecialName]
    private static CallerID __\u003CcallerID\u003E;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(96)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int readInt(byte[] src, int srcOff) => UnsafeUtils.UNSAFE.getInt((object) src, UnsafeUtils.BYTE_ARRAY_OFFSET + (long) srcOff);

    [LineNumberTable(new byte[] {10, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void checkRange(byte[] buf, int off, int len) => SafeUtils.checkRange(buf, off, len);

    [LineNumberTable(141)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int readShort(short[] src, int srcOff) => (int) UnsafeUtils.UNSAFE.getShort((object) src, UnsafeUtils.SHORT_ARRAY_OFFSET + (long) (UnsafeUtils.SHORT_ARRAY_SCALE * srcOff)) & (int) ushort.MaxValue;

    [LineNumberTable(new byte[] {95, 123})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void writeShort(short[] dest, int destOff, int value) => UnsafeUtils.UNSAFE.putShort((object) dest, UnsafeUtils.SHORT_ARRAY_OFFSET + (long) (UnsafeUtils.SHORT_ARRAY_SCALE * destOff), (short) value);

    [LineNumberTable(new byte[] {26, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void writeByte(byte[] src, int srcOff, int value) => UnsafeUtils.writeByte(src, srcOff, (byte) value);

    [LineNumberTable(new byte[] {78, 105, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void writeShortLE(byte[] buf, int off, int v)
    {
      UnsafeUtils.writeByte(buf, off, (byte) v);
      UnsafeUtils.writeByte(buf, off + 1, (byte) ((uint) v >> 8));
    }

    [LineNumberTable(68)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static byte readByte(byte[] src, int srcOff) => UnsafeUtils.UNSAFE.getByte((object) src, UnsafeUtils.BYTE_ARRAY_OFFSET + (long) (UnsafeUtils.BYTE_ARRAY_SCALE * srcOff));

    [LineNumberTable(133)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int readInt(int[] src, int srcOff) => UnsafeUtils.UNSAFE.getInt((object) src, UnsafeUtils.INT_ARRAY_OFFSET + (long) (UnsafeUtils.INT_ARRAY_SCALE * srcOff));

    [LineNumberTable(new byte[] {87, 122})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void writeInt(int[] dest, int destOff, int value) => UnsafeUtils.UNSAFE.putInt((object) dest, UnsafeUtils.INT_ARRAY_OFFSET + (long) (UnsafeUtils.INT_ARRAY_SCALE * destOff), value);

    [LineNumberTable(new byte[] {6, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void checkRange(byte[] buf, int off) => SafeUtils.checkRange(buf, off);

    [LineNumberTable(new byte[] {66, 104, 113, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int readShortLE(byte[] src, int srcOff)
    {
      int num = (int) UnsafeUtils.readShort(src, srcOff);
      if (object.ReferenceEquals((object) Utils.__\u003C\u003ENATIVE_BYTE_ORDER, (object) ByteOrder.BIG_ENDIAN))
        num = (int) Short.reverseBytes((short) num);
      return num & (int) ushort.MaxValue;
    }

    [LineNumberTable(new byte[] {159, 124, 67, 122})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void writeByte(byte[] src, int srcOff, byte value)
    {
      int num = (int) (sbyte) value;
      UnsafeUtils.UNSAFE.putByte((object) src, UnsafeUtils.BYTE_ARRAY_OFFSET + (long) (UnsafeUtils.BYTE_ARRAY_SCALE * srcOff), (byte) num);
    }

    [LineNumberTable(80)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static long readLong(byte[] src, int srcOff) => UnsafeUtils.UNSAFE.getLong((object) src, UnsafeUtils.BYTE_ARRAY_OFFSET + (long) srcOff);

    [LineNumberTable(new byte[] {42, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void writeLong(byte[] dest, int destOff, long value) => UnsafeUtils.UNSAFE.putLong((object) dest, UnsafeUtils.BYTE_ARRAY_OFFSET + (long) destOff, value);

    [LineNumberTable(new byte[] {58, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void writeInt(byte[] dest, int destOff, int value) => UnsafeUtils.UNSAFE.putInt((object) dest, UnsafeUtils.BYTE_ARRAY_OFFSET + (long) destOff, value);

    [LineNumberTable(112)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static short readShort(byte[] src, int srcOff) => UnsafeUtils.UNSAFE.getShort((object) src, UnsafeUtils.BYTE_ARRAY_OFFSET + (long) srcOff);

    [LineNumberTable(new byte[] {159, 111, 66, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void writeShort(byte[] dest, int destOff, short value)
    {
      int num = (int) value;
      UnsafeUtils.UNSAFE.putShort((object) dest, UnsafeUtils.BYTE_ARRAY_OFFSET + (long) destOff, (short) num);
    }

    [LineNumberTable(24)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static UnsafeUtils[] values() => (UnsafeUtils[]) UnsafeUtils.\u0024VALUES.Clone();

    [LineNumberTable(24)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static UnsafeUtils valueOf(string name) => (UnsafeUtils) Enum.valueOf((Class) ClassLiteral<UnsafeUtils>.Value, name);

    [Signature("()V")]
    [LineNumberTable(24)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private UnsafeUtils([In] string obj0, [In] int obj1)
      : base(obj0, obj1)
    {
      GC.KeepAlive((object) this);
    }

    [LineNumberTable(new byte[] {14, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void checkLength(int len) => SafeUtils.checkLength(len);

    [LineNumberTable(new byte[] {34, 104, 113, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static long readLongLE(byte[] src, int srcOff)
    {
      long num = UnsafeUtils.readLong(src, srcOff);
      if (object.ReferenceEquals((object) Utils.__\u003C\u003ENATIVE_BYTE_ORDER, (object) ByteOrder.BIG_ENDIAN))
        num = Long.reverseBytes(num);
      return num;
    }

    [LineNumberTable(new byte[] {50, 104, 113, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int readIntLE(byte[] src, int srcOff)
    {
      int num = UnsafeUtils.readInt(src, srcOff);
      if (object.ReferenceEquals((object) Utils.__\u003C\u003ENATIVE_BYTE_ORDER, (object) ByteOrder.BIG_ENDIAN))
        num = Integer.reverseBytes(num);
      return num;
    }

    [LineNumberTable(new byte[] {159, 136, 77, 235, 77, 117, 103, 118, 117, 116, 117, 116, 117, 255, 10, 71, 226, 58, 97, 112, 97, 112, 97, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static UnsafeUtils()
    {
      if (!ByteCodeHelper.isAlreadyInited("net.jpountz.util.UnsafeUtils"))
      {
        UnsafeUtils.\u0024VALUES = new UnsafeUtils[0];
        try
        {
          try
          {
            try
            {
              Field declaredField = ((Class) ClassLiteral<Unsafe>.Value).getDeclaredField("theUnsafe", UnsafeUtils.__\u003CGetCallerID\u003E());
              ((AccessibleObject) declaredField).setAccessible(true);
              UnsafeUtils.UNSAFE = (Unsafe) declaredField.get((object) null, UnsafeUtils.__\u003CGetCallerID\u003E());
              UnsafeUtils.BYTE_ARRAY_OFFSET = (long) UnsafeUtils.UNSAFE.arrayBaseOffset((Class) ClassLiteral<byte[]>.Value);
              UnsafeUtils.BYTE_ARRAY_SCALE = UnsafeUtils.UNSAFE.arrayIndexScale((Class) ClassLiteral<byte[]>.Value);
              UnsafeUtils.INT_ARRAY_OFFSET = (long) UnsafeUtils.UNSAFE.arrayBaseOffset((Class) ClassLiteral<int[]>.Value);
              UnsafeUtils.INT_ARRAY_SCALE = UnsafeUtils.UNSAFE.arrayIndexScale((Class) ClassLiteral<int[]>.Value);
              UnsafeUtils.SHORT_ARRAY_OFFSET = (long) UnsafeUtils.UNSAFE.arrayBaseOffset((Class) ClassLiteral<short[]>.Value);
              UnsafeUtils.SHORT_ARRAY_SCALE = UnsafeUtils.UNSAFE.arrayIndexScale((Class) ClassLiteral<short[]>.Value);
              return;
            }
            catch (IllegalAccessException ex)
            {
            }
          }
          catch (NoSuchFieldException ex)
          {
            goto label_7;
          }
        }
        catch (SecurityException ex)
        {
          goto label_8;
        }
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new ExceptionInInitializerError("Cannot access Unsafe");
label_7:
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new ExceptionInInitializerError("Cannot access Unsafe");
label_8:
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new ExceptionInInitializerError("Cannot access Unsafe");
      }
    }

    static CallerID __\u003CGetCallerID\u003E()
    {
      if (UnsafeUtils.__\u003CcallerID\u003E == null)
        UnsafeUtils.__\u003CcallerID\u003E = (CallerID) new UnsafeUtils.__\u003CCallerID\u003E();
      return UnsafeUtils.__\u003CcallerID\u003E;
    }

    [HideFromJava]
    [Serializable]
    public enum __Enum
    {
    }

    private sealed class __\u003CCallerID\u003E : CallerID
    {
      internal __\u003CCallerID\u003E()
      {
      }
    }
  }
}
