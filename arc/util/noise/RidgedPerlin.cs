// Decompiled with JetBrains decompiler
// Type: arc.util.noise.RidgedPerlin
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.util;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.util.noise
{
  public class RidgedPerlin : Object
  {
    internal const int X_NOISE_GEN = 1619;
    internal const int Y_NOISE_GEN = 31337;
    internal const int Z_NOISE_GEN = 6971;
    internal const int SEED_NOISE_GEN = 1013;
    internal const int SHIFT_NOISE_GEN = 8;
    internal float lacunarity;
    internal double[] spectralWeights;
    private int octaves;
    private int seed;

    [LineNumberTable(new byte[] {159, 169, 232, 51, 107, 237, 77, 103, 103, 134, 102, 140, 114, 236, 61, 230, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public RidgedPerlin(int seed, int octaves)
    {
      RidgedPerlin ridgedPerlin = this;
      this.lacunarity = 2f;
      this.spectralWeights = new double[20];
      this.octaves = octaves;
      this.seed = seed;
      double num1 = 1.0;
      double num2 = 1.0;
      for (int index = 0; index < this.spectralWeights.Length; ++index)
      {
        this.spectralWeights[index] = Math.pow(num2, -num1);
        num2 *= (double) this.lacunarity;
      }
    }

    [LineNumberTable(165)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getValue(double x, double y, float frequency) => this.getValue(x, y, 0.0, frequency);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setSeed(int seed) => this.seed = seed;

    [LineNumberTable(new byte[] {120, 99, 99, 99, 105, 105, 169, 102, 135, 103, 139, 176, 106, 106, 170, 113, 177, 107, 169, 233, 70, 169, 105, 105, 135, 105, 199, 178, 108, 108, 236, 25, 235, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getValue(double x, double y, double z, float frequency)
    {
      double num1 = x;
      double num2 = y;
      double num3 = z;
      double n1 = num1 * (double) frequency;
      double n2 = num2 * (double) frequency;
      double n3 = num3 * (double) frequency;
      double num4 = 0.0;
      double num5 = 1.0;
      double num6 = 1.0;
      double num7 = 2.0;
      for (int index = 0; index < this.octaves; ++index)
      {
        double num8 = Math.abs(RidgedPerlin.GradientCoherentNoise3D(RidgedPerlin.MakeInt32Range(n1), RidgedPerlin.MakeInt32Range(n2), RidgedPerlin.MakeInt32Range(n3), this.seed + index & int.MaxValue));
        double num9 = num6 - num8;
        double num10 = num9 * num9 * num5;
        num5 = num10 * num7;
        if (num5 > 1.0)
          num5 = 1.0;
        if (num5 < 0.0)
          num5 = 0.0;
        num4 += num10 * this.spectralWeights[index];
        n1 *= (double) this.lacunarity;
        n2 *= (double) this.lacunarity;
        n3 *= (double) this.lacunarity;
      }
      return (float) (num4 * 1.25 - 1.0);
    }

    [LineNumberTable(new byte[] {159, 166, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public RidgedPerlin(int seed)
      : this(seed, 1)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static double SCurve3(double a) => a * a * (3.0 - 2.0 * a);

    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static double SCurve5([In] double obj0)
    {
      double num1 = obj0 * obj0 * obj0;
      double num2 = num1 * obj0;
      return 6.0 * (num2 * obj0) - 15.0 * num2 + 10.0 * num1;
    }

    [LineNumberTable(new byte[] {62, 159, 4, 102, 136, 106, 106, 234, 73, 105, 106, 234, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static double GradientNoise3D(
      double fx,
      double fy,
      double fz,
      int ix,
      int iy,
      int iz,
      int seed)
    {
      int num1 = 1619 * ix + 31337 * iy + 6971 * iz + 1013 * seed;
      int a = (num1 ^ num1 >> 8) & (int) byte.MaxValue;
      double randomVectors1 = VectorTable.getRandomVectors(a, 0);
      double randomVectors2 = VectorTable.getRandomVectors(a, 1);
      double randomVectors3 = VectorTable.getRandomVectors(a, 2);
      double num2 = fx - (double) ix;
      double num3 = fy - (double) iy;
      double num4 = fz - (double) iz;
      return (randomVectors1 * num2 + randomVectors2 * num3 + randomVectors3 * num4) * 2.12;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static double linearInterp(double n0, double n1, double a) => (1.0 - a) * n0 + a * n1;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static double MakeInt32Range(double n)
    {
      if (n >= 1073741824.0)
        return 2.0 * (n % 1073741824.0) - 1073741824.0;
      return n <= -1073741824.0 ? 2.0 * (n % 1073741824.0) + 1073741824.0 : n;
    }

    [LineNumberTable(new byte[] {0, 194, 124, 100, 124, 101, 125, 198, 117, 151, 105, 105, 106, 133, 111, 111, 112, 130, 111, 111, 240, 74, 116, 116, 111, 117, 117, 111, 111, 116, 116, 111, 117, 117, 111, 143})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static double GradientCoherentNoise3D(double x, double y, double z, int seed)
    {
      int num = 2;
      int ix1 = x <= 0.0 ? ByteCodeHelper.d2i(x) - 1 : ByteCodeHelper.d2i(x);
      int ix2 = ix1 + 1;
      int iy1 = y <= 0.0 ? ByteCodeHelper.d2i(y) - 1 : ByteCodeHelper.d2i(y);
      int iy2 = iy1 + 1;
      int iz1 = z <= 0.0 ? ByteCodeHelper.d2i(z) - 1 : ByteCodeHelper.d2i(z);
      int iz2 = iz1 + 1;
      double a1 = 0.0;
      double a2 = 0.0;
      double a3 = 0.0;
      switch (num)
      {
        case 0:
          a1 = x - (double) ix1;
          a2 = y - (double) iy1;
          a3 = z - (double) iz1;
          break;
        case 1:
          a1 = RidgedPerlin.SCurve3(x - (double) ix1);
          a2 = RidgedPerlin.SCurve3(y - (double) iy1);
          a3 = RidgedPerlin.SCurve3(z - (double) iz1);
          break;
        case 2:
          a1 = RidgedPerlin.SCurve5(x - (double) ix1);
          a2 = RidgedPerlin.SCurve5(y - (double) iy1);
          a3 = RidgedPerlin.SCurve5(z - (double) iz1);
          break;
      }
      return RidgedPerlin.linearInterp(RidgedPerlin.linearInterp(RidgedPerlin.linearInterp(RidgedPerlin.GradientNoise3D(x, y, z, ix1, iy1, iz1, seed), RidgedPerlin.GradientNoise3D(x, y, z, ix2, iy1, iz1, seed), a1), RidgedPerlin.linearInterp(RidgedPerlin.GradientNoise3D(x, y, z, ix1, iy2, iz1, seed), RidgedPerlin.GradientNoise3D(x, y, z, ix2, iy2, iz1, seed), a1), a2), RidgedPerlin.linearInterp(RidgedPerlin.linearInterp(RidgedPerlin.GradientNoise3D(x, y, z, ix1, iy1, iz2, seed), RidgedPerlin.GradientNoise3D(x, y, z, ix2, iy1, iz2, seed), a1), RidgedPerlin.linearInterp(RidgedPerlin.GradientNoise3D(x, y, z, ix1, iy2, iz2, seed), RidgedPerlin.GradientNoise3D(x, y, z, ix2, iy2, iz2, seed), a1), a2), a3);
    }

    [LineNumberTable(new byte[] {159, 162, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public RidgedPerlin()
      : this(new Random().nextInt())
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static double cubicInterp(double n0, double n1, double n2, double n3, double a)
    {
      double num1 = n3 - n2 - (n0 - n1);
      double num2 = n0 - n1 - num1;
      double num3 = n2 - n0;
      return num1 * a * a * a + num2 * a * a + num3 * a + n1;
    }
  }
}
