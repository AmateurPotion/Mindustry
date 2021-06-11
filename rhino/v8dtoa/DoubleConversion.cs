// Decompiled with JetBrains decompiler
// Type: rhino.v8dtoa.DoubleConversion
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace rhino.v8dtoa
{
  public sealed class DoubleConversion : Object
  {
    private const long kSignMask = -9223372036854775808;
    private const long kExponentMask = 9218868437227405312;
    private const long kSignificandMask = 4503599627370495;
    private const long kHiddenBit = 4503599627370496;
    private const int kPhysicalSignificandSize = 52;
    private const int kSignificandSize = 53;
    private const int kExponentBias = 1075;
    private const int kDenormalExponent = -1074;

    [LineNumberTable(new byte[] {22, 104, 102, 130, 104, 103, 106, 130, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int doubleToInt32(double x)
    {
      int num1 = ByteCodeHelper.d2i(x);
      if ((double) num1 == x)
        return num1;
      long longBits = Double.doubleToLongBits(x);
      int num2 = DoubleConversion.exponent(longBits);
      if (num2 <= -53 || num2 > 31)
        return 0;
      long num3 = DoubleConversion.significand(longBits);
      return DoubleConversion.sign(longBits) * (num2 >= 0 ? (int) (num3 << num2) : (int) (num3 >> -num2));
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool isDenormal([In] long obj0) => (obj0 & 9218868437227405312L) == 0L;

    [LineNumberTable(new byte[] {159, 189, 104, 134, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static int exponent([In] long obj0) => DoubleConversion.isDenormal(obj0) ? -1074 : (int) ((obj0 & 9218868437227405312L) >> 52) - 1075;

    [LineNumberTable(new byte[] {5, 108, 104, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static long significand([In] long obj0)
    {
      long num = obj0 & 4503599627370495L;
      return !DoubleConversion.isDenormal(obj0) ? num + 4503599627370496L : num;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    private static int sign([In] long obj0) => (obj0 & long.MinValue) == 0L ? 1 : -1;

    [LineNumberTable(new byte[] {159, 185, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private DoubleConversion()
    {
    }
  }
}
