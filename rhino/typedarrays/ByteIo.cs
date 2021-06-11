// Decompiled with JetBrains decompiler
// Type: rhino.typedarrays.ByteIo
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace rhino.typedarrays
{
  public class ByteIo : Object
  {
    [LineNumberTable(new byte[] {159, 137, 130, 99, 205})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static short doReadInt16([In] byte[] obj0, [In] int obj1, [In] bool obj2) => obj2 ? (short) ((int) obj0[obj1] | (int) obj0[obj1 + 1] << 8) : (short) ((int) obj0[obj1] << 8 | (int) obj0[obj1 + 1]);

    [LineNumberTable(new byte[] {159, 134, 98, 99, 107, 145, 109, 141})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void doWriteInt16([In] byte[] obj0, [In] int obj1, [In] int obj2, [In] bool obj3)
    {
      if (obj3)
      {
        obj0[obj1] = (byte) (obj2 & (int) byte.MaxValue);
        obj0[obj1 + 1] = (byte) ((int) ((uint) obj2 >> 8) & (int) byte.MaxValue);
      }
      else
      {
        obj0[obj1] = (byte) ((int) ((uint) obj2 >> 8) & (int) byte.MaxValue);
        obj0[obj1 + 1] = (byte) (obj2 & (int) byte.MaxValue);
      }
    }

    [LineNumberTable(new byte[] {159, 120, 66, 99, 255, 10, 71})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static long readUint32Primitive(byte[] buf, int offset, bool littleEndian) => littleEndian ? ((long) buf[offset] | (long) buf[offset + 1] << 8 | (long) buf[offset + 2] << 16 | (long) buf[offset + 3] << 24) & (long) uint.MaxValue : ((long) buf[offset] << 24 | (long) buf[offset + 1] << 16 | (long) buf[offset + 2] << 8 | (long) buf[offset + 3]) & (long) uint.MaxValue;

    [LineNumberTable(new byte[] {159, 116, 98, 99, 109, 113, 114, 148, 112, 114, 113, 143})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void writeUint32(byte[] buf, int offset, long val, bool littleEndian)
    {
      if (littleEndian)
      {
        buf[offset] = (byte) (int) (val & (long) byte.MaxValue);
        buf[offset + 1] = (byte) (int) ((long) ((ulong) val >> 8) & (long) byte.MaxValue);
        buf[offset + 2] = (byte) (int) ((long) ((ulong) val >> 16) & (long) byte.MaxValue);
        buf[offset + 3] = (byte) (int) ((long) ((ulong) val >> 24) & (long) byte.MaxValue);
      }
      else
      {
        buf[offset] = (byte) (int) ((long) ((ulong) val >> 24) & (long) byte.MaxValue);
        buf[offset + 1] = (byte) (int) ((long) ((ulong) val >> 16) & (long) byte.MaxValue);
        buf[offset + 2] = (byte) (int) ((long) ((ulong) val >> 8) & (long) byte.MaxValue);
        buf[offset + 3] = (byte) (int) (val & (long) byte.MaxValue);
      }
    }

    [LineNumberTable(new byte[] {159, 112, 162, 99, 255, 43, 74})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static long readUint64Primitive(byte[] buf, int offset, bool littleEndian) => littleEndian ? (long) buf[offset] | (long) buf[offset + 1] << 8 | (long) buf[offset + 2] << 16 | (long) buf[offset + 3] << 24 | (long) buf[offset + 4] << 32 | (long) buf[offset + 5] << 40 | (long) buf[offset + 6] << 48 | (long) buf[offset + 7] << 56 : (long) buf[offset] << 56 | (long) buf[offset + 1] << 48 | (long) buf[offset + 2] << 40 | (long) buf[offset + 3] << 32 | (long) buf[offset + 4] << 24 | (long) buf[offset + 5] << 16 | (long) buf[offset + 6] << 8 | (long) buf[offset + 7] << 0;

    [LineNumberTable(new byte[] {159, 106, 130, 102, 109, 113, 114, 114, 114, 114, 114, 151, 112, 114, 114, 114, 114, 114, 113, 143})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void writeUint64(byte[] buf, int offset, long val, bool littleEndian)
    {
      if (littleEndian)
      {
        buf[offset] = (byte) (int) (val & (long) byte.MaxValue);
        buf[offset + 1] = (byte) (int) ((long) ((ulong) val >> 8) & (long) byte.MaxValue);
        buf[offset + 2] = (byte) (int) ((long) ((ulong) val >> 16) & (long) byte.MaxValue);
        buf[offset + 3] = (byte) (int) ((long) ((ulong) val >> 24) & (long) byte.MaxValue);
        buf[offset + 4] = (byte) (int) ((long) ((ulong) val >> 32) & (long) byte.MaxValue);
        buf[offset + 5] = (byte) (int) ((long) ((ulong) val >> 40) & (long) byte.MaxValue);
        buf[offset + 6] = (byte) (int) ((long) ((ulong) val >> 48) & (long) byte.MaxValue);
        buf[offset + 7] = (byte) (int) ((long) ((ulong) val >> 56) & (long) byte.MaxValue);
      }
      else
      {
        buf[offset] = (byte) (int) ((long) ((ulong) val >> 56) & (long) byte.MaxValue);
        buf[offset + 1] = (byte) (int) ((long) ((ulong) val >> 48) & (long) byte.MaxValue);
        buf[offset + 2] = (byte) (int) ((long) ((ulong) val >> 40) & (long) byte.MaxValue);
        buf[offset + 3] = (byte) (int) ((long) ((ulong) val >> 32) & (long) byte.MaxValue);
        buf[offset + 4] = (byte) (int) ((long) ((ulong) val >> 24) & (long) byte.MaxValue);
        buf[offset + 5] = (byte) (int) ((long) ((ulong) val >> 16) & (long) byte.MaxValue);
        buf[offset + 6] = (byte) (int) ((long) ((ulong) val >> 8) & (long) byte.MaxValue);
        buf[offset + 7] = (byte) (int) (val & (long) byte.MaxValue);
      }
    }

    [LineNumberTable(3)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ByteIo()
    {
    }

    [LineNumberTable(5)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object readInt8(byte[] buf, int offset) => (object) Byte.valueOf(buf[offset]);

    [LineNumberTable(new byte[] {159, 151, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void writeInt8(byte[] buf, int offset, int val) => buf[offset] = (byte) val;

    [LineNumberTable(13)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object readUint8(byte[] buf, int offset) => (object) Integer.valueOf((int) buf[offset]);

    [LineNumberTable(new byte[] {159, 159, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void writeUint8(byte[] buf, int offset, int val) => buf[offset] = (byte) (val & (int) byte.MaxValue);

    [LineNumberTable(43)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object readInt16(byte[] buf, int offset, bool littleEndian)
    {
      int num = littleEndian ? 1 : 0;
      return (object) Short.valueOf(ByteIo.doReadInt16(buf, offset, num != 0));
    }

    [LineNumberTable(new byte[] {159, 131, 162, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void writeInt16(byte[] buf, int offset, int val, bool littleEndian)
    {
      int num = littleEndian ? 1 : 0;
      ByteIo.doWriteInt16(buf, offset, val, num != 0);
    }

    [LineNumberTable(51)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object readUint16(byte[] buf, int offset, bool littleEndian)
    {
      int num = littleEndian ? 1 : 0;
      return (object) Integer.valueOf((int) ByteIo.doReadInt16(buf, offset, num != 0) & (int) ushort.MaxValue);
    }

    [LineNumberTable(new byte[] {159, 129, 162, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void writeUint16(byte[] buf, int offset, int val, bool littleEndian)
    {
      int num = littleEndian ? 1 : 0;
      ByteIo.doWriteInt16(buf, offset, val & (int) ushort.MaxValue, num != 0);
    }

    [LineNumberTable(new byte[] {159, 128, 162, 99, 125, 37, 225, 70, 125, 37})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object readInt32(byte[] buf, int offset, bool littleEndian) => littleEndian ? (object) Integer.valueOf((int) buf[offset] | (int) buf[offset + 1] << 8 | (int) buf[offset + 2] << 16 | (int) buf[offset + 3] << 24) : (object) Integer.valueOf((int) buf[offset] << 24 | (int) buf[offset + 1] << 16 | (int) buf[offset + 2] << 8 | (int) buf[offset + 3]);

    [LineNumberTable(new byte[] {159, 124, 130, 99, 107, 111, 112, 146, 110, 112, 111, 141})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void writeInt32(byte[] buf, int offset, int val, bool littleEndian)
    {
      if (littleEndian)
      {
        buf[offset] = (byte) (val & (int) byte.MaxValue);
        buf[offset + 1] = (byte) ((int) ((uint) val >> 8) & (int) byte.MaxValue);
        buf[offset + 2] = (byte) ((int) ((uint) val >> 16) & (int) byte.MaxValue);
        buf[offset + 3] = (byte) ((int) ((uint) val >> 24) & (int) byte.MaxValue);
      }
      else
      {
        buf[offset] = (byte) ((int) ((uint) val >> 24) & (int) byte.MaxValue);
        buf[offset + 1] = (byte) ((int) ((uint) val >> 16) & (int) byte.MaxValue);
        buf[offset + 2] = (byte) ((int) ((uint) val >> 8) & (int) byte.MaxValue);
        buf[offset + 3] = (byte) (val & (int) byte.MaxValue);
      }
    }

    [LineNumberTable(119)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object readUint32(byte[] buf, int offset, bool littleEndian)
    {
      int num = littleEndian ? 1 : 0;
      return (object) Long.valueOf(ByteIo.readUint32Primitive(buf, offset, num != 0));
    }

    [LineNumberTable(new byte[] {159, 100, 66, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object readFloat32(byte[] buf, int offset, bool littleEndian)
    {
      int num = littleEndian ? 1 : 0;
      FloatConverter floatConverter;
      return (object) Float.valueOf(FloatConverter.ToFloat((int) ByteIo.readUint32Primitive(buf, offset, num != 0), ref floatConverter));
    }

    [LineNumberTable(new byte[] {159, 99, 98, 106, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void writeFloat32(byte[] buf, int offset, double val, bool littleEndian)
    {
      int num = littleEndian ? 1 : 0;
      long intBits = (long) Float.floatToIntBits((float) val);
      ByteIo.writeUint32(buf, offset, intBits, num != 0);
    }

    [LineNumberTable(new byte[] {159, 98, 130, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object readFloat64(byte[] buf, int offset, bool littleEndian)
    {
      int num = littleEndian ? 1 : 0;
      DoubleConverter doubleConverter;
      return (object) Double.valueOf(DoubleConverter.ToDouble(ByteIo.readUint64Primitive(buf, offset, num != 0), ref doubleConverter));
    }

    [LineNumberTable(new byte[] {159, 97, 162, 104, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void writeFloat64(byte[] buf, int offset, double val, bool littleEndian)
    {
      int num = littleEndian ? 1 : 0;
      long longBits = Double.doubleToLongBits(val);
      ByteIo.writeUint64(buf, offset, longBits, num != 0);
    }
  }
}
