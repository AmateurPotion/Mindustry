// Decompiled with JetBrains decompiler
// Type: mindustry.gen.BufferItem
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System.Runtime.CompilerServices;

namespace mindustry.gen
{
  public sealed class BufferItem : Object
  {
    [LineNumberTable(8)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public BufferItem()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static byte item(long bufferitem) => (byte) (int) ((long) ((ulong) bufferitem >> 0) & (long) byte.MaxValue);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static long item(long bufferitem, byte value)
    {
      int num = (int) (sbyte) value;
      return bufferitem & (long) byte.MaxValue | (long) num << 0;
    }

    [LineNumberTable(18)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static float time(long bufferitem)
    {
      FloatConverter floatConverter;
      return FloatConverter.ToFloat((int) ((long) ((ulong) bufferitem >> 8) & (long) uint.MaxValue), ref floatConverter);
    }

    [LineNumberTable(22)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static long time(long bufferitem, float value) => bufferitem & 1099511627520L | (long) Float.floatToIntBits(value) << 8;

    [LineNumberTable(26)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static long get(byte item, float time) => (long) (sbyte) item << 0 & (long) byte.MaxValue | (long) Float.floatToIntBits(time) << 8;
  }
}
