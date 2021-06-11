// Decompiled with JetBrains decompiler
// Type: arc.math.Rand
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using java.util;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.math
{
  public class Rand : Random
  {
    private const double NORM_DOUBLE = 1.11022302462516E-16;
    private const double NORM_FLOAT = 5.96046447753906E-08;
    private long seed0;
    private long seed1;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 173, 104, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Rand()
    {
      Rand rand = this;
      this.setSeed(new Random().nextLong());
    }

    [LineNumberTable(new byte[] {113, 98, 99, 99, 105, 110, 42, 168})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void nextBytes(byte[] bytes)
    {
      int length = bytes.Length;
label_1:
      while (length != 0)
      {
        int num1 = length >= 8 ? 8 : length;
        long num2 = this.nextLong();
        while (true)
        {
          int num3 = num1;
          num1 += -1;
          if (num3 != 0)
          {
            byte[] numArray = bytes;
            length += -1;
            int index = length;
            int num4 = (int) (sbyte) (int) num2;
            numArray[index] = (byte) num4;
            num2 >>= 8;
          }
          else
            goto label_1;
        }
      }
    }

    [LineNumberTable(new byte[] {159, 181, 104, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Rand(long seed)
    {
      Rand rand = this;
      this.setSeed(seed);
    }

    [LineNumberTable(new byte[] {160, 67, 123, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setSeed(long seed)
    {
      long seed0 = Rand.murmurHash3(seed != 0L ? seed : long.MinValue);
      this.setState(seed0, Rand.murmurHash3(seed0));
    }

    [LineNumberTable(202)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float random(float min, float max) => min + (max - min) * this.nextFloat();

    [LineNumberTable(194)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float random(float max) => this.nextFloat() * max;

    [LineNumberTable(190)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float range(float amount) => this.nextFloat() * amount * 2f - amount;

    [LineNumberTable(new byte[] {19, 103, 103, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual long nextLong()
    {
      long seed0 = this.seed0;
      long seed1 = this.seed1;
      this.seed0 = seed1;
      long num1 = seed0 ^ seed0 << 23;
      Rand rand = this;
      long num2 = num1 ^ seed1 ^ (long) ((ulong) num1 >> 17) ^ (long) ((ulong) seed1 >> 26);
      long num3 = num2;
      this.seed1 = num2;
      long num4 = seed1;
      return num3 + num4;
    }

    [LineNumberTable(186)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool chance(double chance) => this.nextDouble() < chance;

    [LineNumberTable(198)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int random(int max) => this.nextInt(max + 1);

    [LineNumberTable(new byte[] {160, 96, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int random(int min, int max) => min >= max ? min : min + this.nextInt(max - min + 1);

    [LineNumberTable(131)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual double nextDouble() => (double) (long) ((ulong) this.nextLong() >> 11) * 1.11022302462516E-16;

    [LineNumberTable(102)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int nextInt(int n) => (int) this.nextLong((long) n);

    [LineNumberTable(142)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float nextFloat() => (float) (long) ((ulong) this.nextLong() >> 40) * 5.960464E-08f;

    [LineNumberTable(152)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool nextBoolean() => (this.nextLong() & 1L) != 0L;

    [LineNumberTable(89)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int nextInt() => (int) this.nextLong();

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setState(long seed0, long seed1)
    {
      this.seed0 = seed0;
      this.seed1 = seed1;
    }

    [LineNumberTable(new byte[] {65, 149, 105, 111, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual long nextLong(long n)
    {
      if (n <= 0L)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException("n must be positive");
      }
      long num1;
      long num2;
      do
      {
        num1 = (long) ((ulong) this.nextLong() >> 1);
        long num3 = num1;
        long num4 = n;
        num2 = num4 != -1L ? num3 % num4 : 0L;
      }
      while (num1 - num2 + (n - 1L) < 0L);
      return num2;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    private static long murmurHash3([In] long obj0)
    {
      obj0 ^= (long) ((ulong) obj0 >> 33);
      obj0 *= -49064778989728563L;
      obj0 ^= (long) ((ulong) obj0 >> 33);
      obj0 *= -4265267296055464877L;
      obj0 ^= (long) ((ulong) obj0 >> 33);
      return obj0;
    }

    [LineNumberTable(new byte[] {159, 190, 104, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Rand(long seed0, long seed1)
    {
      Rand rand = this;
      this.setState(seed0, seed1);
    }

    [LineNumberTable(79)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual int next(int bits) => (int) (this.nextLong() & (1L << bits) - 1L);

    [LineNumberTable(206)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int range(int amount) => this.nextInt(amount * 2 + 1) - amount;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual long getState(int seed) => seed == 0 ? this.seed0 : this.seed1;

    [HideFromJava]
    static Rand() => Random.__\u003Cclinit\u003E();
  }
}
