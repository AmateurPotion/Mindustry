// Decompiled with JetBrains decompiler
// Type: mindustry.gen.PackTile
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;

namespace mindustry.gen
{
  public sealed class PackTile : Object
  {
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static long get(short block, short floor, short overlay) => (long) block << 0 & (long) ushort.MaxValue | (long) floor << 16 & 4294901760L | (long) overlay << 32 & 281470681743360L;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static short floor(long packtile) => (short) (int) ((long) ((ulong) packtile >> 16) & (long) ushort.MaxValue);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static short block(long packtile) => (short) (int) ((long) ((ulong) packtile >> 0) & (long) ushort.MaxValue);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static short overlay(long packtile) => (short) (int) ((long) ((ulong) packtile >> 32) & (long) ushort.MaxValue);

    [LineNumberTable(9)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public PackTile()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static long block(long packtile, short value)
    {
      int num = (int) value;
      return packtile & (long) ushort.MaxValue | (long) num << 0;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static long floor(long packtile, short value)
    {
      int num = (int) value;
      return packtile & 4294901760L | (long) num << 16;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static long overlay(long packtile, short value)
    {
      int num = (int) value;
      return packtile & 281470681743360L | (long) num << 32;
    }
  }
}
