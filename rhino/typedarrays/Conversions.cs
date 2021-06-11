// Decompiled with JetBrains decompiler
// Type: rhino.typedarrays.Conversions
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System.Runtime.CompilerServices;

namespace rhino.typedarrays
{
  public class Conversions : Object
  {
    [LineNumberTable(9)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Conversions()
    {
    }

    [LineNumberTable(11)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int toInt8(object arg) => (int) (sbyte) ScriptRuntime.toInt32(arg);

    [LineNumberTable(15)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int toUint8(object arg) => ScriptRuntime.toInt32(arg) & (int) byte.MaxValue;

    [LineNumberTable(new byte[] {159, 161, 105, 104, 130, 108, 198, 105, 111, 142, 111, 135, 115, 137})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int toUint8Clamp(object arg)
    {
      double number = ScriptRuntime.toNumber(arg);
      if (number <= 0.0)
        return 0;
      if (number >= (double) byte.MaxValue)
        return (int) byte.MaxValue;
      double num1 = Math.floor(number);
      if (num1 + 0.5 < number)
        return ByteCodeHelper.d2i(num1 + 1.0);
      if (number < num1 + 0.5)
        return ByteCodeHelper.d2i(num1);
      int num2 = ByteCodeHelper.d2i(num1);
      int num3 = 2;
      return (num3 != -1 ? num2 % num3 : 0) != 0 ? ByteCodeHelper.d2i(num1) + 1 : ByteCodeHelper.d2i(num1);
    }

    [LineNumberTable(42)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int toInt16(object arg) => (int) (short) ScriptRuntime.toInt32(arg);

    [LineNumberTable(46)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int toUint16(object arg) => ScriptRuntime.toInt32(arg) & (int) ushort.MaxValue;

    [LineNumberTable(50)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int toInt32(object arg) => ScriptRuntime.toInt32(arg);

    [LineNumberTable(54)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static long toUint32(object arg) => ScriptRuntime.toUint32(arg);
  }
}
