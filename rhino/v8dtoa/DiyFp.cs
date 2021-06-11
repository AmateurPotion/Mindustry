// Decompiled with JetBrains decompiler
// Type: rhino.v8dtoa.DiyFp
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
  internal class DiyFp : Object
  {
    private long f;
    private int e;
    internal const int kSignificandSize = 64;
    internal const long kUint64MSB = -9223372036854775808;
    [Modifiers]
    internal static bool \u0024assertionsDisabled;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void setF([In] long obj0) => this.f = obj0;

    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void setE([In] int obj0) => this.e = obj0;

    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual int e() => this.e;

    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool uint64_gte([In] long obj0, [In] long obj1) => obj0 == obj1 || obj0 > obj1 ^ obj0 < 0L ^ obj1 < 0L;

    [LineNumberTable(new byte[] {2, 104, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal DiyFp([In] long obj0, [In] int obj1)
    {
      DiyFp diyFp = this;
      this.f = obj0;
      this.e = obj1;
    }

    [LineNumberTable(new byte[] {17, 127, 1, 127, 6, 115})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void subtract([In] DiyFp obj0)
    {
      if (!DiyFp.\u0024assertionsDisabled && this.e != obj0.e)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new AssertionError();
      }
      if (!DiyFp.\u0024assertionsDisabled && !DiyFp.uint64_gte(this.f, obj0.f))
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new AssertionError();
      }
      this.f -= obj0.f;
    }

    [LineNumberTable(new byte[] {38, 103, 106, 110, 106, 110, 101, 101, 101, 101, 187, 107, 118, 118, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void multiply([In] DiyFp obj0)
    {
      long num1 = (long) ((ulong) this.f >> 32);
      long num2 = this.f & (long) uint.MaxValue;
      long num3 = (long) ((ulong) obj0.f >> 32);
      long num4 = obj0.f & (long) uint.MaxValue;
      long num5 = num1 * num3;
      long num6 = num2 * num3;
      long num7 = num1 * num4;
      long num8 = (long) ((ulong) (num2 * num4) >> 32) + (num7 & (long) uint.MaxValue) + (num6 & (long) uint.MaxValue) + 2147483648L;
      long num9 = num5 + (long) ((ulong) num7 >> 32) + (long) ((ulong) num6 >> 32) + (long) ((ulong) num8 >> 32);
      this.e += obj0.e + 64;
      this.f = num9;
    }

    [LineNumberTable(new byte[] {64, 124, 103, 199, 106, 111, 101, 135, 111, 100, 134, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void normalize()
    {
      if (!DiyFp.\u0024assertionsDisabled && this.f == 0L)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new AssertionError();
      }
      long f = this.f;
      int e = this.e;
      while ((f & -18014398509481984L) == 0L)
      {
        f <<= 10;
        e += -10;
      }
      while ((f & long.MinValue) == 0L)
      {
        f <<= 1;
        e += -1;
      }
      this.f = f;
      this.e = e;
    }

    [LineNumberTable(new byte[] {159, 189, 104, 104, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal DiyFp()
    {
      DiyFp diyFp = this;
      this.f = 0L;
      this.e = 0;
    }

    [LineNumberTable(new byte[] {26, 114, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static DiyFp minus([In] DiyFp obj0, [In] DiyFp obj1)
    {
      DiyFp diyFp = new DiyFp(obj0.f, obj0.e);
      diyFp.subtract(obj1);
      return diyFp;
    }

    [LineNumberTable(new byte[] {58, 114, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static DiyFp times([In] DiyFp obj0, [In] DiyFp obj1)
    {
      DiyFp diyFp = new DiyFp(obj0.f, obj0.e);
      diyFp.multiply(obj1);
      return diyFp;
    }

    [LineNumberTable(new byte[] {84, 114, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static DiyFp normalize([In] DiyFp obj0)
    {
      DiyFp diyFp = new DiyFp(obj0.f, obj0.e);
      diyFp.normalize();
      return diyFp;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual long f() => this.f;

    [LineNumberTable(157)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toString() => new StringBuilder().append("[DiyFp f:").append(this.f).append(", e:").append(this.e).append("]").toString();

    [LineNumberTable(38)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static DiyFp()
    {
      if (ByteCodeHelper.isAlreadyInited("rhino.v8dtoa.DiyFp"))
        return;
      DiyFp.\u0024assertionsDisabled = !((Class) ClassLiteral<DiyFp>.Value).desiredAssertionStatus();
    }
  }
}
