// Decompiled with JetBrains decompiler
// Type: arc.util.noise.VoronoiNoise
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.math;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.util;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.util.noise
{
  public class VoronoiNoise : Object
  {
    private const double SQRT_2 = 1.4142135623731;
    private const double SQRT_3 = 1.73205080756888;
    private bool useDistance;
    private long seed;
    private bool useManhattan;
    private Rand rnd;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static double valueNoise2D(int x, int z, long seed)
    {
      long num1 = (long) (1619 * x + 6971 * z) + 1013L * seed & (long) int.MaxValue;
      long num2 = num1 >> 13 ^ num1;
      return 1.0 - (double) (num2 * (num2 * num2 * 60493L + 19990303L) + 1376312589L & (long) int.MaxValue) / 1073741824.0;
    }

    [LineNumberTable(72)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private double getDistance([In] double obj0, [In] double obj1) => this.useManhattan ? obj0 + obj1 : Math.sqrt(obj0 * obj0 + obj1 * obj1) / 1.4142135623731;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static double valueNoise3D(int x, int y, int z, long seed)
    {
      long num1 = (long) (1619 * x + 31337 * y + 6971 * z) + 1013L * seed & (long) int.MaxValue;
      long num2 = num1 >> 13 ^ num1;
      return 1.0 - (double) (num2 * (num2 * num2 * 60493L + 19990303L) + 1376312589L & (long) int.MaxValue) / 1073741824.0;
    }

    [LineNumberTable(76)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private double getDistance([In] double obj0, [In] double obj1, [In] double obj2) => this.useManhattan ? obj0 + obj1 + obj2 : Math.sqrt(obj0 * obj0 + obj1 * obj1 + obj2 * obj2) / 1.73205080756888;

    [LineNumberTable(new byte[] {159, 130, 98, 232, 58, 199, 171, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public VoronoiNoise(long seed, bool useManhattan)
    {
      int num = useManhattan ? 1 : 0;
      // ISSUE: explicit constructor call
      base.\u002Ector();
      VoronoiNoise voronoiNoise = this;
      this.useDistance = false;
      this.rnd = new Rand();
      this.seed = seed;
      this.useManhattan = num != 0;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isUseDistance() => this.useDistance;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setUseDistance(bool useDistance) => this.useDistance = useDistance;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual long getSeed() => this.seed;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setSeed(long seed) => this.seed = seed;

    [LineNumberTable(new byte[] {46, 105, 105, 113, 140, 124, 156, 138, 103, 135, 111, 143, 120, 115, 105, 105, 145, 101, 99, 100, 228, 53, 43, 235, 81, 104, 105, 105, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual double noise(double x, double z, double frequency)
    {
      x *= frequency;
      z *= frequency;
      this.rnd.setSeed(this.seed);
      long seed = this.rnd.nextLong();
      int num1 = x <= 0.0 ? ByteCodeHelper.d2i(x) - 1 : ByteCodeHelper.d2i(x);
      int num2 = z <= 0.0 ? ByteCodeHelper.d2i(z) - 1 : ByteCodeHelper.d2i(z);
      double num3 = 32000000.0;
      double num4 = 0.0;
      double num5 = 0.0;
      for (int z1 = num2 - 2; z1 <= num2 + 2; ++z1)
      {
        for (int x1 = num1 - 2; x1 <= num1 + 2; ++x1)
        {
          double num6 = (double) x1 + VoronoiNoise.valueNoise2D(x1, z1, this.seed);
          double num7 = (double) z1 + VoronoiNoise.valueNoise2D(x1, z1, seed);
          double num8 = num6 - x;
          double num9 = num7 - z;
          double num10 = num8 * num8 + num9 * num9;
          if (num10 < num3)
          {
            num3 = num10;
            num4 = num6;
            num5 = num7;
          }
        }
      }
      return this.useDistance ? this.getDistance(num4 - x, num5 - z) : VoronoiNoise.valueNoise2D(ByteCodeHelper.d2i(Math.floor(num4)), ByteCodeHelper.d2i(Math.floor(num5)), this.seed);
    }

    [LineNumberTable(new byte[] {87, 106, 106, 138, 124, 124, 156, 138, 103, 103, 135, 146, 111, 111, 207, 122, 123, 123, 105, 105, 105, 153, 165, 99, 100, 100, 228, 46, 43, 43, 235, 90, 104, 105, 105, 137, 110, 98, 109, 109, 241, 61})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual double noise(double x, double y, double z, double frequency)
    {
      x *= frequency;
      y *= frequency;
      z *= frequency;
      int num1 = x <= 0.0 ? ByteCodeHelper.d2i(x) - 1 : ByteCodeHelper.d2i(x);
      int num2 = y <= 0.0 ? ByteCodeHelper.d2i(y) - 1 : ByteCodeHelper.d2i(y);
      int num3 = z <= 0.0 ? ByteCodeHelper.d2i(z) - 1 : ByteCodeHelper.d2i(z);
      double num4 = 32000000.0;
      double num5 = 0.0;
      double num6 = 0.0;
      double num7 = 0.0;
      Random.__\u003Cclinit\u003E();
      Random random = new Random(this.seed);
      for (int z1 = num3 - 2; z1 <= num3 + 2; ++z1)
      {
        for (int y1 = num2 - 2; y1 <= num2 + 2; ++y1)
        {
          for (int x1 = num1 - 2; x1 <= num1 + 2; ++x1)
          {
            double num8 = (double) x1 + VoronoiNoise.valueNoise3D(x1, y1, z1, this.seed);
            double num9 = (double) y1 + VoronoiNoise.valueNoise3D(x1, y1, z1, random.nextLong());
            double num10 = (double) z1 + VoronoiNoise.valueNoise3D(x1, y1, z1, random.nextLong());
            double num11 = num8 - x;
            double num12 = num9 - y;
            double num13 = num10 - z;
            double num14 = num11 * num11 + num12 * num12 + num13 * num13;
            if (num14 < num4)
            {
              num4 = num14;
              num5 = num8;
              num6 = num9;
              num7 = num10;
            }
          }
        }
      }
      return this.useDistance ? this.getDistance(num5 - x, num6 - y, num7 - z) : VoronoiNoise.valueNoise3D(ByteCodeHelper.d2i(Math.floor(num5)), ByteCodeHelper.d2i(Math.floor(num6)), ByteCodeHelper.d2i(Math.floor(num7)), this.seed);
    }
  }
}
