// Decompiled with JetBrains decompiler
// Type: mindustry.gen.DisplayCmd
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;

namespace mindustry.gen
{
  public sealed class DisplayCmd : Object
  {
    [LineNumberTable(13)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public DisplayCmd()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static byte type(long displaycmd) => (byte) (int) ((long) ((ulong) displaycmd >> 0) & 15L);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static long type(long displaycmd, byte value)
    {
      int num = (int) (sbyte) value;
      return displaycmd & 15L | (long) num << 0;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int x(long displaycmd) => (int) ((long) ((ulong) displaycmd >> 4) & 1023L);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static long x(long displaycmd, int value) => displaycmd & 16368L | (long) value << 4;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int y(long displaycmd) => (int) ((long) ((ulong) displaycmd >> 14) & 1023L);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static long y(long displaycmd, int value) => displaycmd & 16760832L | (long) value << 14;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int p1(long displaycmd) => (int) ((long) ((ulong) displaycmd >> 24) & 1023L);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static long p1(long displaycmd, int value) => displaycmd & 17163091968L | (long) value << 24;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int p2(long displaycmd) => (int) ((long) ((ulong) displaycmd >> 34) & 1023L);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static long p2(long displaycmd, int value) => displaycmd & 17575006175232L | (long) value << 34;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int p3(long displaycmd) => (int) ((long) ((ulong) displaycmd >> 44) & 1023L);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static long p3(long displaycmd, int value) => displaycmd & 17996806323437568L | (long) value << 44;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int p4(long displaycmd) => (int) ((long) ((ulong) displaycmd >> 54) & 1023L);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static long p4(long displaycmd, int value) => displaycmd & -18014398509481984L | (long) value << 54;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static long get(byte type, int x, int y, int p1, int p2, int p3, int p4) => (long) (sbyte) type << 0 & 15L | (long) x << 4 & 16368L | (long) y << 14 & 16760832L | (long) p1 << 24 & 17163091968L | (long) p2 << 34 & 17575006175232L | (long) p3 << 44 & 17996806323437568L | (long) p4 << 54 & -18014398509481984L;
  }
}
