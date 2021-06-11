// Decompiled with JetBrains decompiler
// Type: rhino.v8dtoa.DoubleHelper
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace rhino.v8dtoa
{
  public class DoubleHelper : Object
  {
    internal const long kSignMask = -9223372036854775808;
    internal const long kExponentMask = 9218868437227405312;
    internal const long kSignificandMask = 4503599627370495;
    internal const long kHiddenBit = 4503599627370496;
    private const int kSignificandSize = 52;
    private const int kExponentBias = 1075;
    private const int kDenormalExponent = -1074;
    [Modifiers]
    internal static bool \u0024assertionsDisabled;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static bool isSpecial([In] long obj0) => (obj0 & 9218868437227405312L) == 9218868437227405312L;

    [LineNumberTable(new byte[] {22, 108, 104, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static long significand([In] long obj0)
    {
      long num = obj0 & 4503599627370495L;
      return !DoubleHelper.isDenormal(obj0) ? num + 4503599627370496L : num;
    }

    [LineNumberTable(new byte[] {15, 142, 119})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static int exponent([In] long obj0) => DoubleHelper.isDenormal(obj0) ? -1074 : (int) ((long) ((ulong) (obj0 & 9218868437227405312L) >> 52) & (long) uint.MaxValue) - 1075;

    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static bool isDenormal([In] long obj0) => (obj0 & 9218868437227405312L) == 0L;

    [LineNumberTable(new byte[] {159, 184, 122})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static DiyFp asDiyFp([In] long obj0)
    {
      if (!DoubleHelper.\u0024assertionsDisabled && DoubleHelper.isSpecial(obj0))
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new AssertionError();
      }
      DiyFp.__\u003Cclinit\u003E();
      return new DiyFp(DoubleHelper.significand(obj0), DoubleHelper.exponent(obj0));
    }

    [LineNumberTable(34)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public DoubleHelper()
    {
    }

    [LineNumberTable(new byte[] {159, 190, 103, 135, 183, 111, 100, 166, 101, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static DiyFp asNormalizedDiyFp([In] long obj0)
    {
      long num1 = DoubleHelper.significand(obj0);
      int num2 = DoubleHelper.exponent(obj0);
      if (!DoubleHelper.\u0024assertionsDisabled && num1 == 0L)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new AssertionError();
      }
      while ((num1 & 4503599627370496L) == 0L)
      {
        num1 <<= 1;
        num2 += -1;
      }
      return new DiyFp(num1 << 11, num2 - 11);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static bool isNan([In] long obj0) => (obj0 & 9218868437227405312L) == 9218868437227405312L && (obj0 & 4503599627370495L) != 0L;

    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static bool isInfinite([In] long obj0) => (obj0 & 9218868437227405312L) == 9218868437227405312L && (obj0 & 4503599627370495L) == 0L;

    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static int sign([In] long obj0) => (obj0 & long.MinValue) == 0L ? 1 : -1;

    [LineNumberTable(new byte[] {61, 103, 114, 113, 110, 102, 240, 71, 113, 144, 113, 142, 125, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static void normalizedBoundaries([In] long obj0, [In] DiyFp obj1, [In] DiyFp obj2)
    {
      DiyFp diyFp = DoubleHelper.asDiyFp(obj0);
      int num = diyFp.f() == 4503599627370496L ? 1 : 0;
      obj2.setF((diyFp.f() << 1) + 1L);
      obj2.setE(diyFp.e() - 1);
      obj2.normalize();
      if (num != 0 && diyFp.e() != -1074)
      {
        obj1.setF((diyFp.f() << 2) - 1L);
        obj1.setE(diyFp.e() - 2);
      }
      else
      {
        obj1.setF((diyFp.f() << 1) - 1L);
        obj1.setE(diyFp.e() - 1);
      }
      obj1.setF(obj1.f() << obj1.e() - obj2.e());
      obj1.setE(obj2.e());
    }

    [LineNumberTable(34)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static DoubleHelper()
    {
      if (ByteCodeHelper.isAlreadyInited("rhino.v8dtoa.DoubleHelper"))
        return;
      DoubleHelper.\u0024assertionsDisabled = !((Class) ClassLiteral<DoubleHelper>.Value).desiredAssertionStatus();
    }
  }
}
