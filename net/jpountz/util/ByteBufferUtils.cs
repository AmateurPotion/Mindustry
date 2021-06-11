// Decompiled with JetBrains decompiler
// Type: net.jpountz.util.ByteBufferUtils
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
  [Signature("Ljava/lang/Enum<Lnet/jpountz/util/ByteBufferUtils;>;")]
  [Modifiers]
  [Serializable]
  public sealed class ByteBufferUtils : Enum
  {
    [Modifiers]
    private static ByteBufferUtils[] \u0024VALUES;
    [Modifiers]
    internal static bool \u0024assertionsDisabled;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {0, 127, 5})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int readInt(ByteBuffer buf, int i)
    {
      if (!ByteBufferUtils.\u0024assertionsDisabled && !object.ReferenceEquals((object) buf.order(), (object) Utils.__\u003C\u003ENATIVE_BYTE_ORDER))
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new AssertionError();
      }
      return buf.getInt(i);
    }

    [LineNumberTable(41)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static byte readByte(ByteBuffer buf, int i) => buf.get(i);

    [LineNumberTable(new byte[] {25, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void writeByte(ByteBuffer dest, int off, int i) => dest.put(off, (byte) i);

    [LineNumberTable(new byte[] {159, 187, 127, 5, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void writeInt(ByteBuffer buf, int i, int v)
    {
      if (!ByteBufferUtils.\u0024assertionsDisabled && !object.ReferenceEquals((object) buf.order(), (object) Utils.__\u003C\u003ENATIVE_BYTE_ORDER))
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new AssertionError();
      }
      buf.putInt(i, v);
    }

    [LineNumberTable(new byte[] {15, 127, 5})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static long readLong(ByteBuffer buf, int i)
    {
      if (!ByteBufferUtils.\u0024assertionsDisabled && !object.ReferenceEquals((object) buf.order(), (object) Utils.__\u003C\u003ENATIVE_BYTE_ORDER))
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new AssertionError();
      }
      return buf.getLong(i);
    }

    [LineNumberTable(new byte[] {10, 127, 5, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void writeLong(ByteBuffer buf, int i, long v)
    {
      if (!ByteBufferUtils.\u0024assertionsDisabled && !object.ReferenceEquals((object) buf.order(), (object) Utils.__\u003C\u003ENATIVE_BYTE_ORDER))
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new AssertionError();
      }
      buf.putLong(i, v);
    }

    [LineNumberTable(new byte[] {34, 104, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void checkNotReadOnly(ByteBuffer buffer)
    {
      if (((Buffer) buffer).isReadOnly())
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new ReadOnlyBufferException();
      }
    }

    [LineNumberTable(new byte[] {159, 153, 102, 100, 103, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void checkRange(ByteBuffer buf, int off, int len)
    {
      SafeUtils.checkLength(len);
      if (len <= 0)
        return;
      ByteBufferUtils.checkRange(buf, off);
      ByteBufferUtils.checkRange(buf, off + len - 1);
    }

    [LineNumberTable(new byte[] {159, 175, 114, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static ByteBuffer inNativeByteOrder(ByteBuffer buf) => Object.instancehelper_equals((object) buf.order(), (object) Utils.__\u003C\u003ENATIVE_BYTE_ORDER) ? buf : buf.duplicate().order(Utils.__\u003C\u003ENATIVE_BYTE_ORDER);

    [LineNumberTable(new byte[] {159, 161, 109, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void checkRange(ByteBuffer buf, int off)
    {
      if (off < 0 || off >= ((Buffer) buf).capacity())
      {
        int num = off;
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new ArrayIndexOutOfBoundsException(num);
      }
    }

    [LineNumberTable(new byte[] {29, 106, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void writeShortLE(ByteBuffer dest, int off, int i)
    {
      dest.put(off, (byte) i);
      dest.put(off + 1, (byte) ((uint) i >> 8));
    }

    [LineNumberTable(90)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int readShortLE(ByteBuffer buf, int i) => (int) (sbyte) buf.get(i) & (int) byte.MaxValue | ((int) (sbyte) buf.get(i + 1) & (int) byte.MaxValue) << 8;

    [LineNumberTable(7)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static ByteBufferUtils[] values() => (ByteBufferUtils[]) ByteBufferUtils.\u0024VALUES.Clone();

    [LineNumberTable(7)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static ByteBufferUtils valueOf(string name) => (ByteBufferUtils) Enum.valueOf((Class) ClassLiteral<ByteBufferUtils>.Value, name);

    [Signature("()V")]
    [LineNumberTable(7)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private ByteBufferUtils([In] string obj0, [In] int obj1)
      : base(obj0, obj1)
    {
      GC.KeepAlive((object) this);
    }

    [LineNumberTable(new byte[] {159, 167, 114, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static ByteBuffer inLittleEndianOrder(ByteBuffer buf) => Object.instancehelper_equals((object) buf.order(), (object) ByteOrder.LITTLE_ENDIAN) ? buf : buf.duplicate().order((ByteOrder) ByteOrder.LITTLE_ENDIAN);

    [LineNumberTable(new byte[] {5, 127, 5})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int readIntLE(ByteBuffer buf, int i)
    {
      if (!ByteBufferUtils.\u0024assertionsDisabled && !object.ReferenceEquals((object) buf.order(), (object) ByteOrder.LITTLE_ENDIAN))
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new AssertionError();
      }
      return buf.getInt(i);
    }

    [LineNumberTable(new byte[] {20, 127, 5})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static long readLongLE(ByteBuffer buf, int i)
    {
      if (!ByteBufferUtils.\u0024assertionsDisabled && !object.ReferenceEquals((object) buf.order(), (object) ByteOrder.LITTLE_ENDIAN))
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new AssertionError();
      }
      return buf.getLong(i);
    }

    [LineNumberTable(7)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static ByteBufferUtils()
    {
      if (ByteCodeHelper.isAlreadyInited("net.jpountz.util.ByteBufferUtils"))
        return;
      ByteBufferUtils.\u0024assertionsDisabled = !((Class) ClassLiteral<ByteBufferUtils>.Value).desiredAssertionStatus();
      ByteBufferUtils.\u0024VALUES = new ByteBufferUtils[0];
    }

    [HideFromJava]
    [Serializable]
    public enum __Enum
    {
    }
  }
}
