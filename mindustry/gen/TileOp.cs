// Decompiled with JetBrains decompiler
// Type: mindustry.gen.TileOp
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;

namespace mindustry.gen
{
  public sealed class TileOp : Object
  {
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static short x(long tileop) => (short) (int) ((long) ((ulong) tileop >> 0) & (long) ushort.MaxValue);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static short y(long tileop) => (short) (int) ((long) ((ulong) tileop >> 16) & (long) ushort.MaxValue);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static byte type(long tileop) => (byte) (int) ((long) ((ulong) tileop >> 32) & (long) byte.MaxValue);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static long get(short x, short y, byte type, short value) => (long) x << 0 & (long) ushort.MaxValue | (long) y << 16 & 4294901760L | (long) (sbyte) type << 32 & 1095216660480L | (long) value << 40 & 72056494526300160L;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static short value(long tileop) => (short) (int) ((long) ((ulong) tileop >> 40) & (long) ushort.MaxValue);

    [LineNumberTable(10)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public TileOp()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static long x(long tileop, short value)
    {
      int num = (int) value;
      return tileop & (long) ushort.MaxValue | (long) num << 0;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static long y(long tileop, short value)
    {
      int num = (int) value;
      return tileop & 4294901760L | (long) num << 16;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static long type(long tileop, byte value)
    {
      int num = (int) (sbyte) value;
      return tileop & 1095216660480L | (long) num << 32;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static long value(long tileop, short value)
    {
      int num = (int) value;
      return tileop & 72056494526300160L | (long) num << 40;
    }
  }
}
