// Decompiled with JetBrains decompiler
// Type: mindustry.gen.PathTile
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;

namespace mindustry.gen
{
  public sealed class PathTile : Object
  {
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int get(
      int health,
      int team,
      bool solid,
      bool liquid,
      bool legSolid,
      bool nearLiquid,
      bool nearGround,
      bool nearSolid,
      bool deep,
      bool damages)
    {
      int num1 = solid ? 1 : 0;
      int num2 = liquid ? 1 : 0;
      int num3 = legSolid ? 1 : 0;
      int num4 = nearLiquid ? 1 : 0;
      int num5 = nearGround ? 1 : 0;
      int num6 = nearSolid ? 1 : 0;
      int num7 = deep ? 1 : 0;
      int num8 = damages ? 1 : 0;
      return (int) ((long) (health << 0) & (long) byte.MaxValue | (long) (team << 8) & 65280L | (num1 == 0 ? 0L : 65536L) | (num2 == 0 ? 0L : 131072L) | (num3 == 0 ? 0L : 262144L) | (num4 == 0 ? 0L : 524288L) | (num5 == 0 ? 0L : 1048576L) | (num6 == 0 ? 0L : 2097152L) | (num7 == 0 ? 0L : 4194304L) | (num8 == 0 ? 0L : 8388608L));
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool solid(int pathtile) => ((long) pathtile & 65536L) != 0L;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool liquid(int pathtile) => ((long) pathtile & 131072L) != 0L;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool nearGround(int pathtile) => ((long) pathtile & 1048576L) != 0L;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool nearSolid(int pathtile) => ((long) pathtile & 2097152L) != 0L;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool deep(int pathtile) => ((long) pathtile & 4194304L) != 0L;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool damages(int pathtile) => ((long) pathtile & 8388608L) != 0L;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool legSolid(int pathtile) => ((long) pathtile & 262144L) != 0L;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int team(int pathtile) => (int) ((long) (int) ((uint) pathtile >> 8) & (long) byte.MaxValue);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int health(int pathtile) => (int) ((long) (int) ((uint) pathtile >> 0) & (long) byte.MaxValue);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool nearLiquid(int pathtile) => ((long) pathtile & 524288L) != 0L;

    [LineNumberTable(16)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public PathTile()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int health(int pathtile, int value) => (int) ((long) pathtile & (long) byte.MaxValue | (long) (value << 0));

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int team(int pathtile, int value) => (int) ((long) pathtile & 65280L | (long) (value << 8));

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int solid(int pathtile, bool value) => value ? (int) ((long) pathtile & -65537L) : (int) ((long) pathtile & -65537L | 65536L);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int liquid(int pathtile, bool value) => value ? (int) ((long) pathtile & -131073L) : (int) ((long) pathtile & -131073L | 131072L);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int legSolid(int pathtile, bool value) => value ? (int) ((long) pathtile & -262145L) : (int) ((long) pathtile & -262145L | 262144L);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int nearLiquid(int pathtile, bool value) => value ? (int) ((long) pathtile & -524289L) : (int) ((long) pathtile & -524289L | 524288L);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int nearGround(int pathtile, bool value) => value ? (int) ((long) pathtile & -1048577L) : (int) ((long) pathtile & -1048577L | 1048576L);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int nearSolid(int pathtile, bool value) => value ? (int) ((long) pathtile & -2097153L) : (int) ((long) pathtile & -2097153L | 2097152L);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int deep(int pathtile, bool value) => value ? (int) ((long) pathtile & -4194305L) : (int) ((long) pathtile & -4194305L | 4194304L);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int damages(int pathtile, bool value) => value ? (int) ((long) pathtile & -8388609L) : (int) ((long) pathtile & -8388609L | 8388608L);
  }
}
