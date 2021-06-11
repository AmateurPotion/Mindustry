// Decompiled with JetBrains decompiler
// Type: arc.util.noise.Noise
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
  public sealed class Noise : Object
  {
    private static int seed;
    private const int P = 8;
    private const int B = 256;
    private const int M = 255;
    private const int NP = 8;
    private const int N = 256;
    private static int[] p;
    private static double[][] g2;
    private static double[] g1;
    private static double[][] points;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {160, 104, 102, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void setSeed(int s)
    {
      Noise.seed = s;
      Noise.init();
    }

    [LineNumberTable(new byte[] {159, 175, 111, 109, 106, 108, 139, 106, 115, 148})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static double rawNoise(double x)
    {
      double num1 = x + 256.0;
      int index1 = ByteCodeHelper.d2i(num1) & (int) byte.MaxValue;
      int index2 = index1 + 1 & (int) byte.MaxValue;
      double num2 = num1 - (double) ByteCodeHelper.d2i(num1);
      double num3 = num2 - 1.0;
      return Noise.lerp(Noise.s_curve(num2), num2 * Noise.g1[Noise.p[index1]], num3 * Noise.g1[Noise.p[index2]]);
    }

    [LineNumberTable(64)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static float noise(float x, float y, float scale, float mag) => Noise.snoise(x, y, scale, mag) / 2f;

    [LineNumberTable(56)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static float snoise3(float x, float y, float z, float scale, float mag) => (float) Noise.rawNoise((double) (x / scale), (double) (y / scale), (double) (z / scale)) * mag;

    [MethodImpl(MethodImplOptions.NoInlining)]
    private static double s_curve([In] double obj0) => obj0 * obj0 * (3.0 - obj0 - obj0);

    [MethodImpl(MethodImplOptions.NoInlining)]
    private static double lerp([In] double obj0, [In] double obj1, [In] double obj2) => obj1 + obj0 * (obj2 - obj1);

    [LineNumberTable(new byte[] {41, 111, 109, 106, 108, 139, 111, 110, 108, 109, 140, 105, 137, 109, 109, 109, 141, 106, 139, 106, 116, 106, 117, 143, 106, 116, 106, 117, 143})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static double rawNoise(double x, double y)
    {
      double num1 = x + 256.0;
      int index1 = ByteCodeHelper.d2i(num1) & (int) byte.MaxValue;
      int index2 = index1 + 1 & (int) byte.MaxValue;
      double num2 = num1 - (double) ByteCodeHelper.d2i(num1);
      double num3 = num2 - 1.0;
      double num4 = y + 256.0;
      int num5 = ByteCodeHelper.d2i(num4) & (int) byte.MaxValue;
      int num6 = num5 + 1 & (int) byte.MaxValue;
      double num7 = num4 - (double) ByteCodeHelper.d2i(num4);
      double num8 = num7 - 1.0;
      int num9 = Noise.p[index1];
      int num10 = Noise.p[index2];
      int index3 = Noise.p[num9 + num5];
      int index4 = Noise.p[num10 + num5];
      int index5 = Noise.p[num9 + num6];
      int index6 = Noise.p[num10 + num6];
      double num11 = Noise.s_curve(num2);
      double num12 = Noise.s_curve(num7);
      double[] numArray1 = Noise.g2[index3];
      double num13 = num2 * numArray1[0] + num7 * numArray1[1];
      double[] numArray2 = Noise.g2[index4];
      double num14 = num3 * numArray2[0] + num7 * numArray2[1];
      double num15 = Noise.lerp(num11, num13, num14);
      double[] numArray3 = Noise.g2[index5];
      double num16 = num2 * numArray3[0] + num8 * numArray3[1];
      double[] numArray4 = Noise.g2[index6];
      double num17 = num3 * numArray4[0] + num8 * numArray4[1];
      double num18 = Noise.lerp(num11, num16, num17);
      return Noise.lerp(num12, num15, num18);
    }

    [LineNumberTable(new byte[] {97, 121, 100, 136, 110, 138, 121, 100, 136, 111, 140, 122, 101, 138, 143, 137, 132, 137, 108, 140, 132, 108, 140, 106, 107, 139, 108, 126, 108, 126, 111, 108, 126, 108, 126, 111, 111, 102, 108, 108, 126, 108, 126, 111, 108, 126, 108, 126, 111, 143})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static double rawNoise([In] double obj0, [In] double obj1, [In] double obj2)
    {
      int index1 = ByteCodeHelper.d2i(Math.floor(obj0) % 256.0);
      if (index1 < 0)
        index1 += 256;
      double num1 = obj0 - Math.floor(obj0);
      double num2 = num1 - 1.0;
      int num3 = ByteCodeHelper.d2i(Math.floor(obj1) % 256.0);
      if (num3 < 0)
        num3 += 256;
      double num4 = obj1 - Math.floor(obj1);
      double num5 = num4 - 1.0;
      int num6 = ByteCodeHelper.d2i(Math.floor(obj2) % 256.0);
      if (num6 < 0)
        num6 += 256;
      double num7 = obj2 - Math.floor(obj2);
      int num8 = Noise.p[index1];
      int index2 = index1 + 1;
      int num9 = Noise.p[index2];
      int num10 = Noise.p[num8 + num3];
      int num11 = Noise.p[num9 + num3];
      int num12 = num3 + 1;
      int num13 = Noise.p[num8 + num12];
      int num14 = Noise.p[num9 + num12];
      double num15 = Noise.s_curve(num1);
      double num16 = Noise.s_curve(num4);
      double num17 = Noise.s_curve(num7);
      double[] numArray1 = Noise.G(num10 + num6);
      double num18 = num1 * numArray1[0] + num4 * numArray1[1] + num7 * numArray1[2];
      double[] numArray2 = Noise.G(num11 + num6);
      double num19 = num2 * numArray2[0] + num4 * numArray2[1] + num7 * numArray2[2];
      double num20 = Noise.lerp(num15, num18, num19);
      double[] numArray3 = Noise.G(num13 + num6);
      double num21 = num1 * numArray3[0] + num5 * numArray3[1] + num7 * numArray3[2];
      double[] numArray4 = Noise.G(num14 + num6);
      double num22 = num2 * numArray4[0] + num5 * numArray4[1] + num7 * numArray4[2];
      double num23 = Noise.lerp(num15, num21, num22);
      double num24 = Noise.lerp(num16, num20, num23);
      int num25 = num6 + 1;
      double num26 = num7 - 1.0;
      double[] numArray5 = Noise.G(num10 + num25);
      double num27 = num1 * numArray5[0] + num4 * numArray5[1] + num26 * numArray5[2];
      double[] numArray6 = Noise.G(num11 + num25);
      double num28 = num2 * numArray6[0] + num4 * numArray6[1] + num26 * numArray6[2];
      double num29 = Noise.lerp(num15, num27, num28);
      double[] numArray7 = Noise.G(num13 + num25);
      double num30 = num1 * numArray7[0] + num5 * numArray7[1] + num26 * numArray7[2];
      double[] numArray8 = Noise.G(num14 + num25);
      double num31 = num2 * numArray8[0] + num5 * numArray8[1] + num26 * numArray8[2];
      double num32 = Noise.lerp(num15, num30, num31);
      double num33 = Noise.lerp(num16, num29, num32);
      return Noise.lerp(num17, num24, num33);
    }

    [LineNumberTable(52)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static float snoise(float x, float y, float scale, float mag) => (float) Noise.rawNoise((double) (x / scale), (double) (y / scale)) * mag;

    [LineNumberTable(48)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static double snoise(float x, float y, float scale, float mag, float exp) => Math.pow(Noise.rawNoise((double) (x / scale), (double) (y / scale)) * (double) mag, (double) exp);

    [LineNumberTable(214)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static double[] G([In] int obj0)
    {
      double[][] points = Noise.points;
      int num1 = obj0;
      int num2 = 32;
      int index = num2 != -1 ? num1 % num2 : 0;
      return points[index];
    }

    [LineNumberTable(new byte[] {160, 111, 113, 109, 104, 191, 2, 123, 123, 114, 126, 126, 127, 4, 106, 106, 172, 123, 123, 124, 106, 106, 107, 117, 117, 127, 23, 255, 25, 39, 233, 92, 104, 105, 112, 111, 140, 109, 116, 116, 104, 58, 232, 61, 233, 72, 127, 42, 114, 154, 102, 104, 63, 6, 40, 230, 69, 105, 107, 107, 109, 104, 107, 127, 5, 127, 6, 255, 6, 61, 235, 61, 43, 43, 233, 78})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void init()
    {
      Random.__\u003Cclinit\u003E();
      Random random = new Random((long) Noise.seed);
      int index1;
      for (index1 = 0; index1 < 256; ++index1)
      {
        Noise.p[index1] = index1;
        Noise.g1[index1] = 2.0 * random.nextDouble() - 1.0;
        double num1;
        double num2;
        do
        {
          num1 = 2.0 * random.nextDouble() - 1.0;
          num2 = 2.0 * random.nextDouble() - 1.0;
        }
        while (num1 * num1 + num2 * num2 > 1.0 || Math.abs(num1) > 2.5 * Math.abs(num2) || (Math.abs(num2) > 2.5 * Math.abs(num1) || Math.abs(Math.abs(num1) - Math.abs(num2)) < 0.4));
        Noise.g2[index1][0] = num1;
        Noise.g2[index1][1] = num2;
        Noise.normalize2(Noise.g2[index1]);
        double num3;
        double num4;
        double num5;
        double num6;
        double num7;
        double num8;
        double num9;
        double num10;
        do
        {
          num3 = 2.0 * random.nextDouble() - 1.0;
          num4 = 2.0 * random.nextDouble() - 1.0;
          num5 = 2.0 * random.nextDouble() - 1.0;
          num6 = Math.abs(num3);
          num7 = Math.abs(num4);
          num8 = Math.abs(num5);
          num9 = Math.min(num6, Math.min(num7, num8));
          num10 = Math.max(num6, Math.max(num7, num8));
        }
        while (num3 * num3 + num4 * num4 + num5 * num5 > 1.0 || num10 > 4.0 * num9 || Math.min(Math.abs(num6 - num7), Math.min(Math.abs(num6 - num8), Math.abs(num7 - num8))) < 0.2);
      }
      while (true)
      {
        index1 += -1;
        if (index1 > 0)
        {
          int num = Noise.p[index1];
          int index2 = (int) (random.nextLong() & (long) byte.MaxValue);
          Noise.p[index1] = Noise.p[index2];
          Noise.p[index2] = num;
        }
        else
          break;
      }
      for (int index2 = 0; index2 < 258; ++index2)
      {
        Noise.p[256 + index2] = Noise.p[index2];
        Noise.g1[256 + index2] = Noise.g1[index2];
        for (int index3 = 0; index3 < 2; ++index3)
          Noise.g2[256 + index2][index3] = Noise.g2[index2][index3];
      }
      double[] point1 = Noise.points[3];
      double[] point2 = Noise.points[3];
      double[] point3 = Noise.points[3];
      double num11 = Math.sqrt(1.0 / 3.0);
      int index4 = 2;
      double[] numArray1 = point3;
      double num12 = num11;
      numArray1[index4] = num11;
      double num13 = num12;
      int index5 = 1;
      double[] numArray2 = point2;
      double num14 = num13;
      numArray2[index5] = num13;
      double num15 = num14;
      point1[0] = num15;
      double num16 = Math.sqrt(0.5);
      double num17 = Math.sqrt(2.0 + num16 + num16);
      for (int index2 = 0; index2 < 3; ++index2)
      {
        for (int index3 = 0; index3 < 3; ++index3)
          Noise.points[index2][index3] = (index2 != index3 ? num16 : 1.0 + num16 + num16) / num17;
      }
      for (int index2 = 0; index2 <= 1; ++index2)
      {
        for (int index3 = 0; index3 <= 1; ++index3)
        {
          for (int index6 = 0; index6 <= 1; ++index6)
          {
            int num1 = index2 + index3 * 2 + index6 * 4;
            if (num1 > 0)
            {
              for (int index7 = 0; index7 < 4; ++index7)
              {
                Noise.points[4 * num1 + index7][0] = (index2 != 0 ? -1.0 : 1.0) * Noise.points[index7][0];
                Noise.points[4 * num1 + index7][1] = (index3 != 0 ? -1.0 : 1.0) * Noise.points[index7][1];
                Noise.points[4 * num1 + index7][2] = (index6 != 0 ? -1.0 : 1.0) * Noise.points[index7][2];
              }
            }
          }
        }
      }
    }

    [LineNumberTable(new byte[] {160, 181, 122, 106, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void normalize2([In] double[] obj0)
    {
      double num = Math.sqrt(obj0[0] * obj0[0] + obj0[1] * obj0[1]);
      obj0[0] = obj0[0] / num;
      obj0[1] = obj0[1] / num;
    }

    [LineNumberTable(5)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Noise()
    {
    }

    [LineNumberTable(60)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static float nnoise(float x, float y, float scale, float mag) => (Noise.snoise(x, y, scale, mag) + mag) / 2f;

    [LineNumberTable(68)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static float noise(float x, float y, float scale, float mag, float xp) => (float) (Noise.snoise(x, y, scale, mag, xp) / 2.0);

    [LineNumberTable(72)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static float fnoise(float x, float y, float scale, float mag) => (float) Noise.rawNoise((double) (x / scale), (double) (y / scale)) * mag;

    [LineNumberTable(new byte[] {159, 141, 141, 231, 71, 111, 127, 13, 111, 191, 10, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static Noise()
    {
      if (ByteCodeHelper.isAlreadyInited("arc.util.noise.Noise"))
        return;
      Noise.seed = 100;
      Noise.p = new int[514];
      int[] numArray1 = new int[2];
      int num1 = 2;
      numArray1[1] = num1;
      int num2 = 514;
      numArray1[0] = num2;
      // ISSUE: type reference
      Noise.g2 = (double[][]) ByteCodeHelper.multianewarray(__typeref (double[][]), numArray1);
      Noise.g1 = new double[514];
      int[] numArray2 = new int[2];
      int num3 = 3;
      numArray2[1] = num3;
      int num4 = 32;
      numArray2[0] = num4;
      // ISSUE: type reference
      Noise.points = (double[][]) ByteCodeHelper.multianewarray(__typeref (double[][]), numArray2);
      Noise.init();
    }
  }
}
