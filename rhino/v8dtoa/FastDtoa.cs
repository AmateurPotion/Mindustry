// Decompiled with JetBrains decompiler
// Type: rhino.v8dtoa.FastDtoa
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
  public class FastDtoa : Object
  {
    internal const int kFastDtoaMaximalLength = 17;
    internal const int minimal_target_exponent = -60;
    internal const int maximal_target_exponent = -32;
    internal const int kTen4 = 10000;
    internal const int kTen5 = 100000;
    internal const int kTen6 = 1000000;
    internal const int kTen7 = 10000000;
    internal const int kTen8 = 100000000;
    internal const int kTen9 = 1000000000;
    [Modifiers]
    internal static bool \u0024assertionsDisabled;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {161, 125, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static string numberToString(double v)
    {
      FastDtoaBuilder buffer = new FastDtoaBuilder();
      return FastDtoa.numberToString(v, buffer) ? buffer.format() : (string) null;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool uint64_lte([In] long obj0, [In] long obj1) => obj0 == obj1 || obj0 < obj1 ^ obj0 < 0L ^ obj1 < 0L;

    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static long biggestPowerTen([In] int obj0, [In] int obj1)
    {
      int num1;
      int num2;
      switch (obj1)
      {
        case 0:
          num1 = 0;
          num2 = -1;
          break;
        case 1:
        case 2:
        case 3:
          if (1 <= obj0)
          {
            num1 = 1;
            num2 = 0;
            break;
          }
          goto case 0;
        case 4:
        case 5:
        case 6:
          if (10 <= obj0)
          {
            num1 = 10;
            num2 = 1;
            break;
          }
          goto case 1;
        case 7:
        case 8:
        case 9:
          if (100 <= obj0)
          {
            num1 = 100;
            num2 = 2;
            break;
          }
          goto case 4;
        case 10:
        case 11:
        case 12:
        case 13:
          if (1000 <= obj0)
          {
            num1 = 1000;
            num2 = 3;
            break;
          }
          goto case 7;
        case 14:
        case 15:
        case 16:
          if (10000 <= obj0)
          {
            num1 = 10000;
            num2 = 4;
            break;
          }
          goto case 10;
        case 17:
        case 18:
        case 19:
          if (100000 <= obj0)
          {
            num1 = 100000;
            num2 = 5;
            break;
          }
          goto case 14;
        case 20:
        case 21:
        case 22:
        case 23:
          if (1000000 <= obj0)
          {
            num1 = 1000000;
            num2 = 6;
            break;
          }
          goto case 17;
        case 24:
        case 25:
        case 26:
          if (10000000 <= obj0)
          {
            num1 = 10000000;
            num2 = 7;
            break;
          }
          goto case 20;
        case 27:
        case 28:
        case 29:
          if (100000000 <= obj0)
          {
            num1 = 100000000;
            num2 = 8;
            break;
          }
          goto case 24;
        case 30:
        case 31:
        case 32:
          if (1000000000 <= obj0)
          {
            num1 = 1000000000;
            num2 = 9;
            break;
          }
          goto case 27;
        default:
          num1 = 0;
          num2 = 0;
          break;
      }
      return (long) num1 << 32 | (long) uint.MaxValue & (long) num2;
    }

    [LineNumberTable(new byte[] {19, 101, 229, 160, 70, 221, 102, 232, 70, 221, 226, 72})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static bool roundWeed(
      [In] FastDtoaBuilder obj0,
      [In] long obj1,
      [In] long obj2,
      [In] long obj3,
      [In] long obj4,
      [In] long obj5)
    {
      long num1 = obj1 - obj5;
      long num2 = obj1 + obj5;
      for (; obj3 < num1 && obj2 - obj3 >= obj4 && (obj3 + obj4 < num1 || num1 - obj3 >= obj3 + obj4 - num1); obj3 += obj4)
        obj0.decreaseLast();
      return (obj3 >= num2 || obj2 - obj3 < obj4 || obj3 + obj4 >= num2 && num2 - obj3 <= obj3 + obj4 - num2) && (2L * obj5 <= obj3 && obj3 <= obj2 - 4L * obj5);
    }

    [LineNumberTable(new byte[] {160, 216, 127, 15, 127, 12, 255, 7, 76, 99, 121, 185, 232, 72, 159, 0, 156, 115, 116, 111, 108, 230, 69, 104, 111, 108, 112, 166, 101, 175, 170, 114, 110, 108, 11, 198, 103, 229, 81, 103, 101, 111, 110, 112, 144, 120, 108, 111, 102, 106, 114, 112, 47, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static bool digitGen(
      [In] DiyFp obj0,
      [In] DiyFp obj1,
      [In] DiyFp obj2,
      [In] FastDtoaBuilder obj3,
      [In] int obj4)
    {
      if (!FastDtoa.\u0024assertionsDisabled && (obj0.e() != obj1.e() || obj1.e() != obj2.e()))
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new AssertionError();
      }
      if (!FastDtoa.\u0024assertionsDisabled && !FastDtoa.uint64_lte(obj0.f() + 1L, obj2.f() - 1L))
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new AssertionError();
      }
      if (!FastDtoa.\u0024assertionsDisabled && (-60 > obj1.e() || obj1.e() > -32))
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new AssertionError();
      }
      long num1 = 1;
      DiyFp.__\u003Cclinit\u003E();
      DiyFp diyFp1 = new DiyFp(obj0.f() - num1, obj0.e());
      DiyFp.__\u003Cclinit\u003E();
      DiyFp diyFp2 = new DiyFp(obj2.f() + num1, obj2.e());
      DiyFp diyFp3 = DiyFp.minus(diyFp2, diyFp1);
      DiyFp.__\u003Cclinit\u003E();
      DiyFp diyFp4 = new DiyFp(1L << -obj1.e(), obj1.e());
      int num2 = (int) ((long) ((ulong) diyFp2.f() >> -diyFp4.e()) & (long) uint.MaxValue);
      long num3 = diyFp2.f() & diyFp4.f() - 1L;
      long num4 = FastDtoa.biggestPowerTen(num2, 64 - -diyFp4.e());
      int num5 = (int) ((long) ((ulong) num4 >> 32) & (long) uint.MaxValue);
      int num6 = (int) (num4 & (long) uint.MaxValue) + 1;
      while (num6 > 0)
      {
        int num7 = num2;
        int num8 = num5;
        int num9 = num8 != -1 ? num7 / num8 : -num7;
        obj3.append((char) (48 + num9));
        int num10 = num2;
        int num11 = num5;
        num2 = num11 != -1 ? num10 % num11 : 0;
        num6 += -1;
        long num12 = ((long) num2 << -diyFp4.e()) + num3;
        if (num12 < diyFp3.f())
        {
          obj3.point = obj3.end - obj4 + num6;
          return FastDtoa.roundWeed(obj3, DiyFp.minus(diyFp2, obj1).f(), diyFp3.f(), num12, (long) num5 << -diyFp4.e(), num1);
        }
        num5 /= 10;
      }
      do
      {
        long num7 = num3 * 5L;
        num1 *= 5L;
        diyFp3.setF(diyFp3.f() * 5L);
        diyFp3.setE(diyFp3.e() + 1);
        diyFp4.setF((long) ((ulong) diyFp4.f() >> 1));
        diyFp4.setE(diyFp4.e() + 1);
        int num8 = (int) ((long) ((ulong) num7 >> -diyFp4.e()) & (long) uint.MaxValue);
        obj3.append((char) (48 + num8));
        num3 = num7 & diyFp4.f() - 1L;
        num6 += -1;
      }
      while (num3 >= diyFp3.f());
      obj3.point = obj3.end - obj4 + num6;
      return FastDtoa.roundWeed(obj3, DiyFp.minus(diyFp2, obj1).f() * num1, diyFp3.f(), num3, diyFp4.f(), num1);
    }

    [LineNumberTable(new byte[] {161, 69, 104, 231, 69, 108, 104, 127, 1, 103, 150, 159, 0, 18, 235, 77, 106, 111, 50, 235, 71, 106, 234, 72})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static bool grisu3([In] double obj0, [In] FastDtoaBuilder obj1)
    {
      long longBits = Double.doubleToLongBits(obj0);
      DiyFp diyFp1 = DoubleHelper.asNormalizedDiyFp(longBits);
      DiyFp diyFp2 = new DiyFp();
      DiyFp diyFp3 = new DiyFp();
      DoubleHelper.normalizedBoundaries(longBits, diyFp2, diyFp3);
      if (!FastDtoa.\u0024assertionsDisabled && diyFp3.e() != diyFp1.e())
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new AssertionError();
      }
      DiyFp diyFp4 = new DiyFp();
      int cachedPower = CachedPowers.getCachedPower(diyFp1.e() + 64, -60, -32, diyFp4);
      if (!FastDtoa.\u0024assertionsDisabled && (-60 > diyFp1.e() + diyFp4.e() + 64 || -32 < diyFp1.e() + diyFp4.e() + 64))
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new AssertionError();
      }
      DiyFp diyFp5 = DiyFp.times(diyFp1, diyFp4);
      if (!FastDtoa.\u0024assertionsDisabled && diyFp5.e() != diyFp3.e() + diyFp4.e() + 64)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new AssertionError();
      }
      DiyFp diyFp6 = DiyFp.times(diyFp2, diyFp4);
      DiyFp diyFp7 = DiyFp.times(diyFp3, diyFp4);
      return FastDtoa.digitGen(diyFp6, diyFp5, diyFp7, obj1, cachedPower);
    }

    [LineNumberTable(new byte[] {161, 130, 102, 105, 104, 133})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool numberToString(double v, FastDtoaBuilder buffer)
    {
      buffer.reset();
      if (v < 0.0)
      {
        buffer.append('-');
        v = -v;
      }
      return FastDtoa.dtoa(v, buffer);
    }

    [LineNumberTable(new byte[] {161, 117, 123, 123, 155})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool dtoa(double v, FastDtoaBuilder buffer)
    {
      if (!FastDtoa.\u0024assertionsDisabled && v <= 0.0)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new AssertionError();
      }
      if (!FastDtoa.\u0024assertionsDisabled && Double.isNaN(v))
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new AssertionError();
      }
      if (!FastDtoa.\u0024assertionsDisabled && Double.isInfinite(v))
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new AssertionError();
      }
      return FastDtoa.grisu3(v, buffer);
    }

    [LineNumberTable(33)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public FastDtoa()
    {
    }

    [LineNumberTable(33)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static FastDtoa()
    {
      if (ByteCodeHelper.isAlreadyInited("rhino.v8dtoa.FastDtoa"))
        return;
      FastDtoa.\u0024assertionsDisabled = !((Class) ClassLiteral<FastDtoa>.Value).desiredAssertionStatus();
    }
  }
}
