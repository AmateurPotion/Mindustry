// Decompiled with JetBrains decompiler
// Type: arc.util.Align
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;

namespace arc.util
{
  public class Align : Object
  {
    public const int center = 1;
    public const int top = 2;
    public const int bottom = 4;
    public const int left = 8;
    public const int right = 16;
    public const int topLeft = 10;
    public const int topRight = 18;
    public const int bottomLeft = 12;
    public const int bottomRight = 20;

    [LineNumberTable(7)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Align()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool isLeft(int align) => (align & 8) != 0;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool isRight(int align) => (align & 16) != 0;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool isTop(int align) => (align & 2) != 0;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool isBottom(int align) => (align & 4) != 0;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool isCenterVertical(int align) => (align & 2) == 0 && (align & 4) == 0;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool isCenterHorizontal(int align) => (align & 8) == 0 && (align & 16) == 0;

    [LineNumberTable(new byte[] {159, 186, 104, 101, 110, 101, 142, 108, 101, 110, 102, 142, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static string toString(int align)
    {
      StringBuilder stringBuilder = new StringBuilder(13);
      if ((align & 2) != 0)
        stringBuilder.append("top,");
      else if ((align & 4) != 0)
        stringBuilder.append("bottom,");
      else
        stringBuilder.append("center,");
      if ((align & 8) != 0)
        stringBuilder.append("left");
      else if ((align & 16) != 0)
        stringBuilder.append("right");
      else
        stringBuilder.append("center");
      return stringBuilder.toString();
    }
  }
}
