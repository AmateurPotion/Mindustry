// Decompiled with JetBrains decompiler
// Type: arc.util.noise.Simplex
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
  public class Simplex : Object
  {
    [Modifiers]
    internal static int[][] grad3;
    [Modifiers]
    internal static int[][] grad4;
    internal static int[][] simplex;
    [Modifiers]
    internal int[] perm;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {19, 232, 33, 255, 179, 22, 96, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Simplex(long seed)
    {
      Simplex simplex = this;
      this.perm = new int[512]
      {
        151,
        160,
        137,
        91,
        90,
        15,
        131,
        13,
        201,
        95,
        96,
        53,
        194,
        233,
        7,
        225,
        140,
        36,
        103,
        30,
        69,
        142,
        8,
        99,
        37,
        240,
        21,
        10,
        23,
        190,
        6,
        148,
        247,
        120,
        234,
        75,
        0,
        26,
        197,
        62,
        94,
        252,
        219,
        203,
        117,
        35,
        11,
        32,
        57,
        177,
        33,
        88,
        237,
        149,
        56,
        87,
        174,
        20,
        125,
        136,
        171,
        168,
        68,
        175,
        74,
        165,
        71,
        134,
        139,
        48,
        27,
        166,
        77,
        146,
        158,
        231,
        83,
        111,
        229,
        122,
        60,
        211,
        133,
        230,
        220,
        105,
        92,
        41,
        55,
        46,
        245,
        40,
        244,
        102,
        143,
        54,
        65,
        25,
        63,
        161,
        1,
        216,
        80,
        73,
        209,
        76,
        132,
        187,
        208,
        89,
        18,
        169,
        200,
        196,
        135,
        130,
        116,
        188,
        159,
        86,
        164,
        100,
        109,
        198,
        173,
        186,
        3,
        64,
        52,
        217,
        226,
        250,
        124,
        123,
        5,
        202,
        38,
        147,
        118,
        126,
        (int) byte.MaxValue,
        82,
        85,
        212,
        207,
        206,
        59,
        227,
        47,
        16,
        58,
        17,
        182,
        189,
        28,
        42,
        223,
        183,
        170,
        213,
        119,
        248,
        152,
        2,
        44,
        154,
        163,
        70,
        221,
        153,
        101,
        155,
        167,
        43,
        172,
        9,
        129,
        22,
        39,
        253,
        19,
        98,
        108,
        110,
        79,
        113,
        224,
        232,
        178,
        185,
        112,
        104,
        218,
        246,
        97,
        228,
        251,
        34,
        242,
        193,
        238,
        210,
        144,
        12,
        191,
        179,
        162,
        241,
        81,
        51,
        145,
        235,
        249,
        14,
        239,
        107,
        49,
        192,
        214,
        31,
        181,
        199,
        106,
        157,
        184,
        84,
        204,
        176,
        115,
        121,
        50,
        45,
        (int) sbyte.MaxValue,
        4,
        150,
        254,
        138,
        236,
        205,
        93,
        222,
        114,
        67,
        29,
        24,
        72,
        243,
        141,
        128,
        195,
        78,
        66,
        215,
        61,
        156,
        180,
        151,
        160,
        137,
        91,
        90,
        15,
        131,
        13,
        201,
        95,
        96,
        53,
        194,
        233,
        7,
        225,
        140,
        36,
        103,
        30,
        69,
        142,
        8,
        99,
        37,
        240,
        21,
        10,
        23,
        190,
        6,
        148,
        247,
        120,
        234,
        75,
        0,
        26,
        197,
        62,
        94,
        252,
        219,
        203,
        117,
        35,
        11,
        32,
        57,
        177,
        33,
        88,
        237,
        149,
        56,
        87,
        174,
        20,
        125,
        136,
        171,
        168,
        68,
        175,
        74,
        165,
        71,
        134,
        139,
        48,
        27,
        166,
        77,
        146,
        158,
        231,
        83,
        111,
        229,
        122,
        60,
        211,
        133,
        230,
        220,
        105,
        92,
        41,
        55,
        46,
        245,
        40,
        244,
        102,
        143,
        54,
        65,
        25,
        63,
        161,
        1,
        216,
        80,
        73,
        209,
        76,
        132,
        187,
        208,
        89,
        18,
        169,
        200,
        196,
        135,
        130,
        116,
        188,
        159,
        86,
        164,
        100,
        109,
        198,
        173,
        186,
        3,
        64,
        52,
        217,
        226,
        250,
        124,
        123,
        5,
        202,
        38,
        147,
        118,
        126,
        (int) byte.MaxValue,
        82,
        85,
        212,
        207,
        206,
        59,
        227,
        47,
        16,
        58,
        17,
        182,
        189,
        28,
        42,
        223,
        183,
        170,
        213,
        119,
        248,
        152,
        2,
        44,
        154,
        163,
        70,
        221,
        153,
        101,
        155,
        167,
        43,
        172,
        9,
        129,
        22,
        39,
        253,
        19,
        98,
        108,
        110,
        79,
        113,
        224,
        232,
        178,
        185,
        112,
        104,
        218,
        246,
        97,
        228,
        251,
        34,
        242,
        193,
        238,
        210,
        144,
        12,
        191,
        179,
        162,
        241,
        81,
        51,
        145,
        235,
        249,
        14,
        239,
        107,
        49,
        192,
        214,
        31,
        181,
        199,
        106,
        157,
        184,
        84,
        204,
        176,
        115,
        121,
        50,
        45,
        (int) sbyte.MaxValue,
        4,
        150,
        254,
        138,
        236,
        205,
        93,
        222,
        114,
        67,
        29,
        24,
        72,
        243,
        141,
        128,
        195,
        78,
        66,
        215,
        61,
        156,
        180
      };
      this.setSeed(seed);
    }

    [LineNumberTable(new byte[] {37, 102, 99, 198, 134, 106, 159, 14, 110, 102, 231, 59, 235, 72})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual double octaveNoise2D(
      double octaves,
      double persistence,
      double scale,
      double x,
      double y)
    {
      double num1 = 0.0;
      double num2 = scale;
      double num3 = 1.0;
      double num4 = 0.0;
      for (int index = 0; (double) index < octaves; ++index)
      {
        num1 += (this.rawNoise2D(x * num2, y * num2) + 1.0) / 2.0 * num3;
        num2 *= 2.0;
        num4 += num3;
        num3 *= persistence;
      }
      return num1 / num4;
    }

    [LineNumberTable(new byte[] {24, 135, 108, 51, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setSeed(long seed)
    {
      Random random = new Random(seed);
      for (int index = 0; index < this.perm.Length; ++index)
        this.perm[index] = random.nextInt(256);
    }

    [LineNumberTable(new byte[] {15, 232, 37, 255, 179, 22, 93})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Simplex()
    {
      Simplex simplex = this;
      this.perm = new int[512]
      {
        151,
        160,
        137,
        91,
        90,
        15,
        131,
        13,
        201,
        95,
        96,
        53,
        194,
        233,
        7,
        225,
        140,
        36,
        103,
        30,
        69,
        142,
        8,
        99,
        37,
        240,
        21,
        10,
        23,
        190,
        6,
        148,
        247,
        120,
        234,
        75,
        0,
        26,
        197,
        62,
        94,
        252,
        219,
        203,
        117,
        35,
        11,
        32,
        57,
        177,
        33,
        88,
        237,
        149,
        56,
        87,
        174,
        20,
        125,
        136,
        171,
        168,
        68,
        175,
        74,
        165,
        71,
        134,
        139,
        48,
        27,
        166,
        77,
        146,
        158,
        231,
        83,
        111,
        229,
        122,
        60,
        211,
        133,
        230,
        220,
        105,
        92,
        41,
        55,
        46,
        245,
        40,
        244,
        102,
        143,
        54,
        65,
        25,
        63,
        161,
        1,
        216,
        80,
        73,
        209,
        76,
        132,
        187,
        208,
        89,
        18,
        169,
        200,
        196,
        135,
        130,
        116,
        188,
        159,
        86,
        164,
        100,
        109,
        198,
        173,
        186,
        3,
        64,
        52,
        217,
        226,
        250,
        124,
        123,
        5,
        202,
        38,
        147,
        118,
        126,
        (int) byte.MaxValue,
        82,
        85,
        212,
        207,
        206,
        59,
        227,
        47,
        16,
        58,
        17,
        182,
        189,
        28,
        42,
        223,
        183,
        170,
        213,
        119,
        248,
        152,
        2,
        44,
        154,
        163,
        70,
        221,
        153,
        101,
        155,
        167,
        43,
        172,
        9,
        129,
        22,
        39,
        253,
        19,
        98,
        108,
        110,
        79,
        113,
        224,
        232,
        178,
        185,
        112,
        104,
        218,
        246,
        97,
        228,
        251,
        34,
        242,
        193,
        238,
        210,
        144,
        12,
        191,
        179,
        162,
        241,
        81,
        51,
        145,
        235,
        249,
        14,
        239,
        107,
        49,
        192,
        214,
        31,
        181,
        199,
        106,
        157,
        184,
        84,
        204,
        176,
        115,
        121,
        50,
        45,
        (int) sbyte.MaxValue,
        4,
        150,
        254,
        138,
        236,
        205,
        93,
        222,
        114,
        67,
        29,
        24,
        72,
        243,
        141,
        128,
        195,
        78,
        66,
        215,
        61,
        156,
        180,
        151,
        160,
        137,
        91,
        90,
        15,
        131,
        13,
        201,
        95,
        96,
        53,
        194,
        233,
        7,
        225,
        140,
        36,
        103,
        30,
        69,
        142,
        8,
        99,
        37,
        240,
        21,
        10,
        23,
        190,
        6,
        148,
        247,
        120,
        234,
        75,
        0,
        26,
        197,
        62,
        94,
        252,
        219,
        203,
        117,
        35,
        11,
        32,
        57,
        177,
        33,
        88,
        237,
        149,
        56,
        87,
        174,
        20,
        125,
        136,
        171,
        168,
        68,
        175,
        74,
        165,
        71,
        134,
        139,
        48,
        27,
        166,
        77,
        146,
        158,
        231,
        83,
        111,
        229,
        122,
        60,
        211,
        133,
        230,
        220,
        105,
        92,
        41,
        55,
        46,
        245,
        40,
        244,
        102,
        143,
        54,
        65,
        25,
        63,
        161,
        1,
        216,
        80,
        73,
        209,
        76,
        132,
        187,
        208,
        89,
        18,
        169,
        200,
        196,
        135,
        130,
        116,
        188,
        159,
        86,
        164,
        100,
        109,
        198,
        173,
        186,
        3,
        64,
        52,
        217,
        226,
        250,
        124,
        123,
        5,
        202,
        38,
        147,
        118,
        126,
        (int) byte.MaxValue,
        82,
        85,
        212,
        207,
        206,
        59,
        227,
        47,
        16,
        58,
        17,
        182,
        189,
        28,
        42,
        223,
        183,
        170,
        213,
        119,
        248,
        152,
        2,
        44,
        154,
        163,
        70,
        221,
        153,
        101,
        155,
        167,
        43,
        172,
        9,
        129,
        22,
        39,
        253,
        19,
        98,
        108,
        110,
        79,
        113,
        224,
        232,
        178,
        185,
        112,
        104,
        218,
        246,
        97,
        228,
        251,
        34,
        242,
        193,
        238,
        210,
        144,
        12,
        191,
        179,
        162,
        241,
        81,
        51,
        145,
        235,
        249,
        14,
        239,
        107,
        49,
        192,
        214,
        31,
        181,
        199,
        106,
        157,
        184,
        84,
        204,
        176,
        115,
        121,
        50,
        45,
        (int) sbyte.MaxValue,
        4,
        150,
        254,
        138,
        236,
        205,
        93,
        222,
        114,
        67,
        29,
        24,
        72,
        243,
        141,
        128,
        195,
        78,
        66,
        215,
        61,
        156,
        180
      };
    }

    [LineNumberTable(new byte[] {62, 102, 99, 198, 134, 109, 159, 20, 110, 102, 231, 59, 235, 72})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual double octaveNoise3D(
      double octaves,
      double persistence,
      double scale,
      double x,
      double y,
      double z)
    {
      double num1 = 0.0;
      double num2 = scale;
      double num3 = 1.0;
      double num4 = 0.0;
      for (int index = 0; (double) index < octaves; ++index)
      {
        num1 += (this.rawNoise3D(x * num2, y * num2, z * num2) + 1.0) / 2.0 * num3;
        num2 *= 2.0;
        num4 += num3;
        num3 *= persistence;
      }
      return num1 / num4;
    }

    [LineNumberTable(new byte[] {160, 95, 159, 4, 107, 108, 140, 127, 9, 139, 105, 137, 105, 233, 69, 102, 99, 165, 99, 227, 70, 110, 110, 123, 187, 105, 105, 127, 2, 127, 8, 191, 6, 124, 146, 105, 190, 124, 146, 105, 190, 124, 146, 105, 254, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual double rawNoise2D(double x, double y)
    {
      double num1 = 0.5 * (Math.sqrt(3.0) - 1.0);
      double num2 = (x + y) * num1;
      int num3 = this.fastfloor(x + num2);
      int num4 = this.fastfloor(y + num2);
      double num5 = (3.0 - Math.sqrt(3.0)) / 6.0;
      double num6 = (double) (num3 + num4) * num5;
      double num7 = (double) num3 - num6;
      double num8 = (double) num4 - num6;
      double num9 = x - num7;
      double num10 = y - num8;
      int num11;
      int num12;
      if (num9 > num10)
      {
        num11 = 1;
        num12 = 0;
      }
      else
      {
        num11 = 0;
        num12 = 1;
      }
      double num13 = num9 - (double) num11 + num5;
      double num14 = num10 - (double) num12 + num5;
      double num15 = num9 - 1.0 + 2.0 * num5;
      double num16 = num10 - 1.0 + 2.0 * num5;
      int num17 = num3 & (int) byte.MaxValue;
      int index1 = num4 & (int) byte.MaxValue;
      int num18 = this.perm[num17 + this.perm[index1]];
      int num19 = 12;
      int index2 = num19 != -1 ? num18 % num19 : 0;
      int num20 = this.perm[num17 + num11 + this.perm[index1 + num12]];
      int num21 = 12;
      int index3 = num21 != -1 ? num20 % num21 : 0;
      int num22 = this.perm[num17 + 1 + this.perm[index1 + 1]];
      int num23 = 12;
      int index4 = num23 != -1 ? num22 % num23 : 0;
      double num24 = 0.5 - num9 * num9 - num10 * num10;
      double num25;
      if (num24 < 0.0)
      {
        num25 = 0.0;
      }
      else
      {
        double num26 = num24 * num24;
        num25 = num26 * num26 * this.dot(Simplex.grad3[index2], num9, num10);
      }
      double num27 = 0.5 - num13 * num13 - num14 * num14;
      double num28;
      if (num27 < 0.0)
      {
        num28 = 0.0;
      }
      else
      {
        double num26 = num27 * num27;
        num28 = num26 * num26 * this.dot(Simplex.grad3[index3], num13, num14);
      }
      double num29 = 0.5 - num15 * num15 - num16 * num16;
      double num30;
      if (num29 < 0.0)
      {
        num30 = 0.0;
      }
      else
      {
        double num26 = num29 * num29;
        num30 = num26 * num26 * this.dot(Simplex.grad3[index4], num15, num16);
      }
      return 70.0 * (num25 + num28 + num30);
    }

    [LineNumberTable(new byte[] {160, 170, 106, 111, 108, 108, 141, 107, 110, 105, 105, 106, 105, 105, 233, 71, 105, 102, 99, 99, 99, 99, 99, 136, 102, 99, 99, 99, 99, 99, 168, 99, 99, 99, 99, 99, 168, 102, 99, 99, 99, 99, 99, 133, 102, 99, 99, 99, 99, 99, 165, 99, 99, 99, 99, 99, 227, 72, 110, 110, 110, 121, 121, 121, 123, 123, 187, 105, 105, 106, 127, 12, 127, 21, 127, 21, 191, 18, 127, 5, 146, 105, 191, 1, 127, 5, 146, 105, 191, 1, 127, 5, 146, 105, 191, 1, 127, 5, 146, 105, 255, 1, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual double rawNoise3D(double x, double y, double z)
    {
      double num1 = 1.0 / 3.0;
      double num2 = (x + y + z) * num1;
      int num3 = this.fastfloor(x + num2);
      int num4 = this.fastfloor(y + num2);
      int num5 = this.fastfloor(z + num2);
      double num6 = 1.0 / 6.0;
      double num7 = (double) (num3 + num4 + num5) * num6;
      double num8 = (double) num3 - num7;
      double num9 = (double) num4 - num7;
      double num10 = (double) num5 - num7;
      double num11 = x - num8;
      double num12 = y - num9;
      double num13 = z - num10;
      int num14;
      int num15;
      int num16;
      int num17;
      int num18;
      int num19;
      if (num11 >= num12)
      {
        if (num12 >= num13)
        {
          num14 = 1;
          num15 = 0;
          num16 = 0;
          num17 = 1;
          num18 = 1;
          num19 = 0;
        }
        else if (num11 >= num13)
        {
          num14 = 1;
          num15 = 0;
          num16 = 0;
          num17 = 1;
          num18 = 0;
          num19 = 1;
        }
        else
        {
          num14 = 0;
          num15 = 0;
          num16 = 1;
          num17 = 1;
          num18 = 0;
          num19 = 1;
        }
      }
      else if (num12 < num13)
      {
        num14 = 0;
        num15 = 0;
        num16 = 1;
        num17 = 0;
        num18 = 1;
        num19 = 1;
      }
      else if (num11 < num13)
      {
        num14 = 0;
        num15 = 1;
        num16 = 0;
        num17 = 0;
        num18 = 1;
        num19 = 1;
      }
      else
      {
        num14 = 0;
        num15 = 1;
        num16 = 0;
        num17 = 1;
        num18 = 1;
        num19 = 0;
      }
      double num20 = num11 - (double) num14 + num6;
      double num21 = num12 - (double) num15 + num6;
      double num22 = num13 - (double) num16 + num6;
      double num23 = num11 - (double) num17 + 2.0 * num6;
      double num24 = num12 - (double) num18 + 2.0 * num6;
      double num25 = num13 - (double) num19 + 2.0 * num6;
      double num26 = num11 - 1.0 + 3.0 * num6;
      double num27 = num12 - 1.0 + 3.0 * num6;
      double num28 = num13 - 1.0 + 3.0 * num6;
      int num29 = num3 & (int) byte.MaxValue;
      int num30 = num4 & (int) byte.MaxValue;
      int index1 = num5 & (int) byte.MaxValue;
      int num31 = this.perm[num29 + this.perm[num30 + this.perm[index1]]];
      int num32 = 12;
      int index2 = num32 != -1 ? num31 % num32 : 0;
      int num33 = this.perm[num29 + num14 + this.perm[num30 + num15 + this.perm[index1 + num16]]];
      int num34 = 12;
      int index3 = num34 != -1 ? num33 % num34 : 0;
      int num35 = this.perm[num29 + num17 + this.perm[num30 + num18 + this.perm[index1 + num19]]];
      int num36 = 12;
      int index4 = num36 != -1 ? num35 % num36 : 0;
      int num37 = this.perm[num29 + 1 + this.perm[num30 + 1 + this.perm[index1 + 1]]];
      int num38 = 12;
      int index5 = num38 != -1 ? num37 % num38 : 0;
      double num39 = 0.6 - num11 * num11 - num12 * num12 - num13 * num13;
      double num40;
      if (num39 < 0.0)
      {
        num40 = 0.0;
      }
      else
      {
        double num41 = num39 * num39;
        num40 = num41 * num41 * this.dot(Simplex.grad3[index2], num11, num12, num13);
      }
      double num42 = 0.6 - num20 * num20 - num21 * num21 - num22 * num22;
      double num43;
      if (num42 < 0.0)
      {
        num43 = 0.0;
      }
      else
      {
        double num41 = num42 * num42;
        num43 = num41 * num41 * this.dot(Simplex.grad3[index3], num20, num21, num22);
      }
      double num44 = 0.6 - num23 * num23 - num24 * num24 - num25 * num25;
      double num45;
      if (num44 < 0.0)
      {
        num45 = 0.0;
      }
      else
      {
        double num41 = num44 * num44;
        num45 = num41 * num41 * this.dot(Simplex.grad3[index4], num23, num24, num25);
      }
      double num46 = 0.6 - num26 * num26 - num27 * num27 - num28 * num28;
      double num47;
      if (num46 < 0.0)
      {
        num47 = 0.0;
      }
      else
      {
        double num41 = num46 * num46;
        num47 = num41 * num41 * this.dot(Simplex.grad3[index5], num26, num27, num28);
      }
      return 32.0 * (num40 + num43 + num45 + num47);
    }

    [LineNumberTable(new byte[] {161, 47, 127, 4, 223, 8, 116, 108, 109, 109, 110, 113, 105, 106, 106, 138, 105, 105, 105, 234, 74, 109, 109, 108, 108, 108, 104, 243, 75, 114, 114, 114, 146, 114, 114, 114, 146, 114, 114, 114, 178, 109, 109, 109, 109, 120, 120, 120, 120, 120, 120, 120, 120, 122, 122, 122, 186, 105, 106, 106, 106, 127, 22, 127, 34, 127, 34, 127, 34, 191, 30, 127, 13, 146, 105, 191, 3, 127, 13, 146, 105, 191, 3, 127, 13, 146, 105, 191, 3, 127, 13, 146, 105, 191, 3, 127, 13, 146, 105, 223, 3})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual double rawNoise4D(double x, double y, double z, double w)
    {
      double num1 = (Math.sqrt(5.0) - 1.0) / 4.0;
      double num2 = (5.0 - Math.sqrt(5.0)) / 20.0;
      double num3 = (x + y + z + w) * num1;
      int num4 = this.fastfloor(x + num3);
      int num5 = this.fastfloor(y + num3);
      int num6 = this.fastfloor(z + num3);
      int num7 = this.fastfloor(w + num3);
      double num8 = (double) (num4 + num5 + num6 + num7) * num2;
      double num9 = (double) num4 - num8;
      double num10 = (double) num5 - num8;
      double num11 = (double) num6 - num8;
      double num12 = (double) num7 - num8;
      double num13 = x - num9;
      double num14 = y - num10;
      double num15 = z - num11;
      double num16 = w - num12;
      int index1 = (num13 <= num14 ? 0 : 32) + (num13 <= num15 ? 0 : 16) + (num14 <= num15 ? 0 : 8) + (num13 <= num16 ? 0 : 4) + (num14 <= num16 ? 0 : 2) + (num15 > num16 ? 1 : 0);
      int num17 = Simplex.simplex[index1][0] >= 3 ? 1 : 0;
      int num18 = Simplex.simplex[index1][1] >= 3 ? 1 : 0;
      int num19 = Simplex.simplex[index1][2] >= 3 ? 1 : 0;
      int num20 = Simplex.simplex[index1][3] >= 3 ? 1 : 0;
      int num21 = Simplex.simplex[index1][0] >= 2 ? 1 : 0;
      int num22 = Simplex.simplex[index1][1] >= 2 ? 1 : 0;
      int num23 = Simplex.simplex[index1][2] >= 2 ? 1 : 0;
      int num24 = Simplex.simplex[index1][3] >= 2 ? 1 : 0;
      int num25 = Simplex.simplex[index1][0] >= 1 ? 1 : 0;
      int num26 = Simplex.simplex[index1][1] >= 1 ? 1 : 0;
      int num27 = Simplex.simplex[index1][2] >= 1 ? 1 : 0;
      int num28 = Simplex.simplex[index1][3] >= 1 ? 1 : 0;
      double num29 = num13 - (double) num17 + num2;
      double num30 = num14 - (double) num18 + num2;
      double num31 = num15 - (double) num19 + num2;
      double num32 = num16 - (double) num20 + num2;
      double num33 = num13 - (double) num21 + 2.0 * num2;
      double num34 = num14 - (double) num22 + 2.0 * num2;
      double num35 = num15 - (double) num23 + 2.0 * num2;
      double num36 = num16 - (double) num24 + 2.0 * num2;
      double num37 = num13 - (double) num25 + 3.0 * num2;
      double num38 = num14 - (double) num26 + 3.0 * num2;
      double num39 = num15 - (double) num27 + 3.0 * num2;
      double num40 = num16 - (double) num28 + 3.0 * num2;
      double num41 = num13 - 1.0 + 4.0 * num2;
      double num42 = num14 - 1.0 + 4.0 * num2;
      double num43 = num15 - 1.0 + 4.0 * num2;
      double num44 = num16 - 1.0 + 4.0 * num2;
      int num45 = num4 & (int) byte.MaxValue;
      int num46 = num5 & (int) byte.MaxValue;
      int num47 = num6 & (int) byte.MaxValue;
      int index2 = num7 & (int) byte.MaxValue;
      int num48 = this.perm[num45 + this.perm[num46 + this.perm[num47 + this.perm[index2]]]];
      int num49 = 32;
      int index3 = num49 != -1 ? num48 % num49 : 0;
      int num50 = this.perm[num45 + num17 + this.perm[num46 + num18 + this.perm[num47 + num19 + this.perm[index2 + num20]]]];
      int num51 = 32;
      int index4 = num51 != -1 ? num50 % num51 : 0;
      int num52 = this.perm[num45 + num21 + this.perm[num46 + num22 + this.perm[num47 + num23 + this.perm[index2 + num24]]]];
      int num53 = 32;
      int index5 = num53 != -1 ? num52 % num53 : 0;
      int num54 = this.perm[num45 + num25 + this.perm[num46 + num26 + this.perm[num47 + num27 + this.perm[index2 + num28]]]];
      int num55 = 32;
      int index6 = num55 != -1 ? num54 % num55 : 0;
      int num56 = this.perm[num45 + 1 + this.perm[num46 + 1 + this.perm[num47 + 1 + this.perm[index2 + 1]]]];
      int num57 = 32;
      int index7 = num57 != -1 ? num56 % num57 : 0;
      double num58 = 0.6 - num13 * num13 - num14 * num14 - num15 * num15 - num16 * num16;
      double num59;
      if (num58 < 0.0)
      {
        num59 = 0.0;
      }
      else
      {
        double num60 = num58 * num58;
        num59 = num60 * num60 * this.dot(Simplex.grad4[index3], num13, num14, num15, num16);
      }
      double num61 = 0.6 - num29 * num29 - num30 * num30 - num31 * num31 - num32 * num32;
      double num62;
      if (num61 < 0.0)
      {
        num62 = 0.0;
      }
      else
      {
        double num60 = num61 * num61;
        num62 = num60 * num60 * this.dot(Simplex.grad4[index4], num29, num30, num31, num32);
      }
      double num63 = 0.6 - num33 * num33 - num34 * num34 - num35 * num35 - num36 * num36;
      double num64;
      if (num63 < 0.0)
      {
        num64 = 0.0;
      }
      else
      {
        double num60 = num63 * num63;
        num64 = num60 * num60 * this.dot(Simplex.grad4[index5], num33, num34, num35, num36);
      }
      double num65 = 0.6 - num37 * num37 - num38 * num38 - num39 * num39 - num40 * num40;
      double num66;
      if (num65 < 0.0)
      {
        num66 = 0.0;
      }
      else
      {
        double num60 = num65 * num65;
        num66 = num60 * num60 * this.dot(Simplex.grad4[index6], num37, num38, num39, num40);
      }
      double num67 = 0.6 - num41 * num41 - num42 * num42 - num43 * num43 - num44 * num44;
      double num68;
      if (num67 < 0.0)
      {
        num68 = 0.0;
      }
      else
      {
        double num60 = num67 * num67;
        num68 = num60 * num60 * this.dot(Simplex.grad4[index7], num41, num42, num43, num44);
      }
      return 27.0 * (num59 + num62 + num64 + num66 + num68);
    }

    [LineNumberTable(new byte[] {87, 102, 99, 198, 134, 106, 159, 8, 110, 102, 231, 59, 235, 72})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual double octaveNoise4D(
      double octaves,
      double persistence,
      double scale,
      double x,
      double y,
      double z,
      double w)
    {
      double num1 = 0.0;
      double num2 = scale;
      double num3 = 1.0;
      double num4 = 0.0;
      for (int index = 0; (double) index < octaves; ++index)
      {
        num1 += this.rawNoise4D(x * num2, y * num2, z * num2, w * num2) * num3;
        num2 *= 2.0;
        num4 += num3;
        num3 *= persistence;
      }
      return num1 / num4;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual int fastfloor([In] double obj0) => obj0 > 0.0 ? ByteCodeHelper.d2i(obj0) : ByteCodeHelper.d2i(obj0) - 1;

    [LineNumberTable(553)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual double dot([In] int[] obj0, [In] double obj1, [In] double obj2) => (double) obj0[0] * obj1 + (double) obj0[1] * obj2;

    [LineNumberTable(557)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual double dot([In] int[] obj0, [In] double obj1, [In] double obj2, [In] double obj3) => (double) obj0[0] * obj1 + (double) obj0[1] * obj2 + (double) obj0[2] * obj3;

    [LineNumberTable(561)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual double dot([In] int[] obj0, [In] double obj1, [In] double obj2, [In] double obj3, [In] double obj4) => (double) obj0[0] * obj1 + (double) obj0[1] * obj2 + (double) obj0[2] * obj3 + (double) obj0[3] * obj4;

    [LineNumberTable(161)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual double scaledOctaveNoise2d(
      double octaves,
      double persistence,
      double scale,
      double loBound,
      double hiBound,
      double x,
      double y)
    {
      return this.octaveNoise2D(octaves, persistence, scale, x, y) * (hiBound - loBound) / 2.0 + (hiBound + loBound) / 2.0;
    }

    [LineNumberTable(169)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual double scaledOctaveNoise3D(
      double octaves,
      double persistence,
      double scale,
      double loBound,
      double hiBound,
      double x,
      double y,
      double z)
    {
      return this.octaveNoise3D(octaves, persistence, scale, x, y, z) * (hiBound - loBound) / 2.0 + (hiBound + loBound) / 2.0;
    }

    [LineNumberTable(176)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual double scaledOctaveNoise4D(
      double octaves,
      double persistence,
      double scale,
      double loBound,
      double hiBound,
      double x,
      double y,
      double z,
      double w)
    {
      return this.octaveNoise4D(octaves, persistence, scale, x, y, z, w) * (hiBound - loBound) / 2.0 + (hiBound + loBound) / 2.0;
    }

    [LineNumberTable(184)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual double scaledRawNoise2D(double loBound, double hiBound, double x, double y) => this.rawNoise2D(x, y) * (hiBound - loBound) / 2.0 + (hiBound + loBound) / 2.0;

    [LineNumberTable(192)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual double scaledRawNoise3D(
      double loBound,
      double hiBound,
      double x,
      double y,
      double z)
    {
      return this.rawNoise3D(x, y, z) * (hiBound - loBound) / 2.0 + (hiBound + loBound) / 2.0;
    }

    [LineNumberTable(199)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual double scaledRawNoise4D(
      double loBound,
      double hiBound,
      double x,
      double y,
      double z,
      double w)
    {
      return this.rawNoise4D(x, y, z, w) * (hiBound - loBound) / 2.0 + (hiBound + loBound) / 2.0;
    }

    [LineNumberTable(new byte[] {159, 139, 77, 255, 160, 172, 70, 255, 162, 228, 74})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static Simplex()
    {
      if (ByteCodeHelper.isAlreadyInited("arc.util.noise.Simplex"))
        return;
      Simplex.grad3 = new int[12][]
      {
        new int[3]{ 1, 1, 0 },
        new int[3]{ -1, 1, 0 },
        new int[3]{ 1, -1, 0 },
        new int[3]{ -1, -1, 0 },
        new int[3]{ 1, 0, 1 },
        new int[3]{ -1, 0, 1 },
        new int[3]{ 1, 0, -1 },
        new int[3]{ -1, 0, -1 },
        new int[3]{ 0, 1, 1 },
        new int[3]{ 0, -1, 1 },
        new int[3]{ 0, 1, -1 },
        new int[3]{ 0, -1, -1 }
      };
      Simplex.grad4 = new int[32][]
      {
        new int[4]{ 0, 1, 1, 1 },
        new int[4]{ 0, 1, 1, -1 },
        new int[4]{ 0, 1, -1, 1 },
        new int[4]{ 0, 1, -1, -1 },
        new int[4]{ 0, -1, 1, 1 },
        new int[4]{ 0, -1, 1, -1 },
        new int[4]{ 0, -1, -1, 1 },
        new int[4]{ 0, -1, -1, -1 },
        new int[4]{ 1, 0, 1, 1 },
        new int[4]{ 1, 0, 1, -1 },
        new int[4]{ 1, 0, -1, 1 },
        new int[4]{ 1, 0, -1, -1 },
        new int[4]{ -1, 0, 1, 1 },
        new int[4]{ -1, 0, 1, -1 },
        new int[4]{ -1, 0, -1, 1 },
        new int[4]{ -1, 0, -1, -1 },
        new int[4]{ 1, 1, 0, 1 },
        new int[4]{ 1, 1, 0, -1 },
        new int[4]{ 1, -1, 0, 1 },
        new int[4]{ 1, -1, 0, -1 },
        new int[4]{ -1, 1, 0, 1 },
        new int[4]{ -1, 1, 0, -1 },
        new int[4]{ -1, -1, 0, 1 },
        new int[4]{ -1, -1, 0, -1 },
        new int[4]{ 1, 1, 1, 0 },
        new int[4]{ 1, 1, -1, 0 },
        new int[4]{ 1, -1, 1, 0 },
        new int[4]{ 1, -1, -1, 0 },
        new int[4]{ -1, 1, 1, 0 },
        new int[4]{ -1, 1, -1, 0 },
        new int[4]{ -1, -1, 1, 0 },
        new int[4]{ -1, -1, -1, 0 }
      };
      Simplex.simplex = new int[64][]
      {
        new int[4]{ 0, 1, 2, 3 },
        new int[4]{ 0, 1, 3, 2 },
        new int[4]{ 0, 0, 0, 0 },
        new int[4]{ 0, 2, 3, 1 },
        new int[4]{ 0, 0, 0, 0 },
        new int[4]{ 0, 0, 0, 0 },
        new int[4]{ 0, 0, 0, 0 },
        new int[4]{ 1, 2, 3, 0 },
        new int[4]{ 0, 2, 1, 3 },
        new int[4]{ 0, 0, 0, 0 },
        new int[4]{ 0, 3, 1, 2 },
        new int[4]{ 0, 3, 2, 1 },
        new int[4]{ 0, 0, 0, 0 },
        new int[4]{ 0, 0, 0, 0 },
        new int[4]{ 0, 0, 0, 0 },
        new int[4]{ 1, 3, 2, 0 },
        new int[4]{ 0, 0, 0, 0 },
        new int[4]{ 0, 0, 0, 0 },
        new int[4]{ 0, 0, 0, 0 },
        new int[4]{ 0, 0, 0, 0 },
        new int[4]{ 0, 0, 0, 0 },
        new int[4]{ 0, 0, 0, 0 },
        new int[4]{ 0, 0, 0, 0 },
        new int[4]{ 0, 0, 0, 0 },
        new int[4]{ 1, 2, 0, 3 },
        new int[4]{ 0, 0, 0, 0 },
        new int[4]{ 1, 3, 0, 2 },
        new int[4]{ 0, 0, 0, 0 },
        new int[4]{ 0, 0, 0, 0 },
        new int[4]{ 0, 0, 0, 0 },
        new int[4]{ 2, 3, 0, 1 },
        new int[4]{ 2, 3, 1, 0 },
        new int[4]{ 1, 0, 2, 3 },
        new int[4]{ 1, 0, 3, 2 },
        new int[4]{ 0, 0, 0, 0 },
        new int[4]{ 0, 0, 0, 0 },
        new int[4]{ 0, 0, 0, 0 },
        new int[4]{ 2, 0, 3, 1 },
        new int[4]{ 0, 0, 0, 0 },
        new int[4]{ 2, 1, 3, 0 },
        new int[4]{ 0, 0, 0, 0 },
        new int[4]{ 0, 0, 0, 0 },
        new int[4]{ 0, 0, 0, 0 },
        new int[4]{ 0, 0, 0, 0 },
        new int[4]{ 0, 0, 0, 0 },
        new int[4]{ 0, 0, 0, 0 },
        new int[4]{ 0, 0, 0, 0 },
        new int[4]{ 0, 0, 0, 0 },
        new int[4]{ 2, 0, 1, 3 },
        new int[4]{ 0, 0, 0, 0 },
        new int[4]{ 0, 0, 0, 0 },
        new int[4]{ 0, 0, 0, 0 },
        new int[4]{ 3, 0, 1, 2 },
        new int[4]{ 3, 0, 2, 1 },
        new int[4]{ 0, 0, 0, 0 },
        new int[4]{ 3, 1, 2, 0 },
        new int[4]{ 2, 1, 0, 3 },
        new int[4]{ 0, 0, 0, 0 },
        new int[4]{ 0, 0, 0, 0 },
        new int[4]{ 0, 0, 0, 0 },
        new int[4]{ 3, 1, 0, 2 },
        new int[4]{ 0, 0, 0, 0 },
        new int[4]{ 3, 2, 0, 1 },
        new int[4]{ 3, 2, 1, 0 }
      };
    }
  }
}
