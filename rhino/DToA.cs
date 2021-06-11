// Decompiled with JetBrains decompiler
// Type: rhino.DToA
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.math;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace rhino
{
  internal class DToA : Object
  {
    internal const int DTOSTR_STANDARD = 0;
    internal const int DTOSTR_STANDARD_EXPONENTIAL = 1;
    internal const int DTOSTR_FIXED = 2;
    internal const int DTOSTR_EXPONENTIAL = 3;
    internal const int DTOSTR_PRECISION = 4;
    private const int Frac_mask = 1048575;
    private const int Exp_shift = 20;
    private const int Exp_msk1 = 1048576;
    private const long Frac_maskL = 4503599627370495;
    private const int Exp_shiftL = 52;
    private const long Exp_msk1L = 4503599627370496;
    private const int Bias = 1023;
    private const int P = 53;
    private const int Exp_shift1 = 20;
    private const int Exp_mask = 2146435072;
    private const int Exp_mask_shifted = 2047;
    private const int Bndry_mask = 1048575;
    private const int Log2P = 1;
    private const int Sign_bit = -2147483648;
    private const int Exp_11 = 1072693248;
    private const int Ten_pmax = 22;
    private const int Quick_max = 14;
    private const int Bletch = 16;
    private const int Frac_mask1 = 1048575;
    private const int Int_max = 14;
    private const int n_bigtens = 5;
    [Modifiers]
    private static double[] tens;
    [Modifiers]
    private static double[] bigtens;
    [Modifiers]
    private static int[] dtoaModes;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    private static int lo0bits([In] int obj0)
    {
      int num1 = obj0;
      if ((num1 & 7) != 0)
      {
        if ((num1 & 1) != 0)
          return 0;
        return (num1 & 2) != 0 ? 1 : 2;
      }
      int num2 = 0;
      if ((num1 & (int) ushort.MaxValue) == 0)
      {
        num2 = 16;
        num1 = (int) ((uint) num1 >> 16);
      }
      if ((num1 & (int) byte.MaxValue) == 0)
      {
        num2 += 8;
        num1 = (int) ((uint) num1 >> 8);
      }
      if ((num1 & 15) == 0)
      {
        num2 += 4;
        num1 = (int) ((uint) num1 >> 4);
      }
      if ((num1 & 3) == 0)
      {
        num2 += 2;
        num1 = (int) ((uint) num1 >> 2);
      }
      if ((num1 & 1) == 0)
      {
        ++num2;
        if (((int) ((uint) num1 >> 1) & 1) == 0)
          return 32;
      }
      return num2;
    }

    [LineNumberTable(new byte[] {72, 104, 106, 105, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void stuffBits([In] byte[] obj0, [In] int obj1, [In] int obj2)
    {
      obj0[obj1] = (byte) (obj2 >> 24);
      obj0[obj1 + 1] = (byte) (obj2 >> 16);
      obj0[obj1 + 2] = (byte) (obj2 >> 8);
      obj0[obj1 + 3] = (byte) obj2;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    private static int hi0bits([In] int obj0)
    {
      int num = 0;
      if ((obj0 & -65536) == 0)
      {
        num = 16;
        obj0 <<= 16;
      }
      if ((obj0 & -16777216) == 0)
      {
        num += 8;
        obj0 <<= 8;
      }
      if ((obj0 & -268435456) == 0)
      {
        num += 4;
        obj0 <<= 4;
      }
      if ((obj0 & -1073741824) == 0)
      {
        num += 2;
        obj0 <<= 2;
      }
      if ((obj0 & int.MinValue) == 0)
      {
        ++num;
        if ((obj0 & 1073741824) == 0)
          return 32;
      }
      return num;
    }

    [LineNumberTable(new byte[] {84, 104, 102, 131, 104, 136, 105, 136, 105, 104, 105, 106, 100, 117, 138, 106, 105, 171, 104, 104, 104, 105, 103, 131, 100, 113, 138, 115, 143})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static BigInteger d2b([In] double obj0, [In] int[] obj1, [In] int[] obj2)
    {
      long longBits = Double.doubleToLongBits(obj0);
      int num1 = (int) ((ulong) longBits >> 32);
      int num2 = (int) longBits;
      int num3 = num1 & 1048575;
      int num4;
      if ((num4 = (int) ((uint) (num1 & int.MaxValue) >> 20)) != 0)
        num3 |= 1048576;
      int num5;
      byte[] numArray;
      int num6;
      int num7;
      if ((num5 = num2) != 0)
      {
        numArray = new byte[8];
        num6 = DToA.lo0bits(num5);
        int num8 = (int) ((uint) num5 >> num6);
        if (num6 != 0)
        {
          DToA.stuffBits(numArray, 4, num8 | num3 << 32 - num6);
          num3 >>= num6;
        }
        else
          DToA.stuffBits(numArray, 4, num8);
        DToA.stuffBits(numArray, 0, num3);
        num7 = num3 == 0 ? 1 : 2;
      }
      else
      {
        numArray = new byte[4];
        int num8 = DToA.lo0bits(num3);
        num3 = (int) ((uint) num3 >> num8);
        DToA.stuffBits(numArray, 0, num3);
        num6 = num8 + 32;
        num7 = 1;
      }
      if (num4 != 0)
      {
        obj1[0] = num4 - 1023 - 52 + num6;
        obj2[0] = 53 - num6;
      }
      else
      {
        obj1[0] = num4 - 1023 - 52 + 1 + num6;
        obj2[0] = 32 * num7 - DToA.hi0bits(num3);
      }
      return new BigInteger(numArray);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    private static char BASEDIGIT([In] int obj0) => obj0 < 10 ? (char) (48 + obj0) : (char) (87 + obj0);

    [LineNumberTable(new byte[] {160, 245, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static int word0([In] double obj0) => (int) (Double.doubleToLongBits(obj0) >> 32);

    [LineNumberTable(new byte[] {160, 250, 104, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static double setWord0([In] double obj0, [In] int obj1)
    {
      long longBits = Double.doubleToLongBits(obj0);
      DoubleConverter doubleConverter;
      return DoubleConverter.ToDouble((long) obj1 << 32 | longBits & (long) uint.MaxValue, ref doubleConverter);
    }

    [LineNumberTable(new byte[] {161, 0, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static int word1([In] double obj0) => (int) Double.doubleToLongBits(obj0);

    [LineNumberTable(new byte[] {163, 176, 103, 181, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void stripTrailingZeroes([In] StringBuilder obj0)
    {
      int num1 = obj0.length();
      int num2;
      do
      {
        num2 = num1;
        num1 += -1;
      }
      while (num2 > 0 && obj0.charAt(num1) == '0');
      obj0.setLength(num1 + 1);
    }

    [LineNumberTable(377)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static BigInteger pow5mult([In] BigInteger obj0, [In] int obj1) => obj0.multiply(BigInteger.valueOf(5L).pow(obj1));

    [LineNumberTable(new byte[] {161, 11, 103, 99, 100, 104, 101, 107, 105, 130, 98, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static bool roundOff([In] StringBuilder obj0)
    {
      int num1 = obj0.length();
      while (num1 != 0)
      {
        num1 += -1;
        int num2 = (int) obj0.charAt(num1);
        if (num2 != 57)
        {
          obj0.setCharAt(num1, (char) (num2 + 1));
          obj0.setLength(num1 + 1);
          return false;
        }
      }
      obj0.setLength(0);
      return true;
    }

    [LineNumberTable(new byte[] {159, 31, 98, 103, 199, 143, 133, 154, 133, 148, 127, 13, 134, 137, 104, 106, 162, 106, 117, 254, 86, 106, 168, 111, 104, 127, 6, 177, 122, 106, 163, 127, 23, 105, 112, 102, 99, 107, 108, 102, 195, 138, 101, 99, 134, 101, 131, 101, 99, 100, 137, 103, 101, 195, 105, 99, 99, 100, 102, 131, 99, 102, 191, 1, 102, 99, 162, 163, 100, 99, 102, 162, 104, 100, 102, 229, 71, 99, 216, 99, 100, 100, 100, 131, 104, 109, 102, 135, 103, 110, 134, 100, 102, 102, 239, 61, 238, 69, 107, 104, 114, 106, 102, 102, 239, 61, 238, 71, 114, 101, 133, 100, 102, 112, 230, 70, 117, 120, 100, 98, 112, 102, 106, 102, 133, 103, 104, 106, 130, 131, 103, 99, 199, 124, 99, 105, 106, 112, 102, 133, 205, 114, 112, 104, 105, 102, 100, 162, 109, 133, 108, 101, 112, 213, 113, 99, 105, 106, 112, 105, 209, 114, 112, 104, 105, 102, 100, 162, 109, 101, 113, 167, 229, 40, 251, 95, 100, 104, 100, 100, 228, 70, 146, 106, 105, 98, 127, 11, 104, 106, 130, 106, 102, 133, 99, 109, 110, 112, 105, 105, 254, 75, 114, 112, 104, 105, 102, 100, 162, 109, 162, 112, 105, 226, 32, 235, 98, 165, 100, 100, 99, 103, 100, 217, 102, 102, 137, 109, 103, 131, 104, 103, 195, 103, 103, 233, 70, 106, 107, 103, 103, 199, 101, 100, 101, 107, 106, 131, 106, 139, 233, 69, 105, 101, 235, 69, 99, 100, 122, 205, 102, 102, 227, 75, 105, 99, 104, 102, 103, 234, 61, 232, 69, 124, 135, 101, 103, 103, 103, 105, 101, 103, 103, 103, 167, 101, 105, 101, 171, 100, 107, 102, 111, 100, 113, 228, 69, 169, 106, 254, 71, 104, 106, 194, 106, 102, 133, 103, 101, 235, 70, 100, 100, 100, 234, 69, 99, 106, 101, 207, 138, 107, 151, 114, 102, 106, 105, 102, 138, 165, 101, 103, 106, 133, 180, 140, 168, 104, 106, 159, 1, 106, 105, 102, 138, 197, 106, 133, 101, 198, 106, 105, 102, 138, 133, 109, 133, 106, 102, 101, 111, 107, 150, 113, 241, 159, 182, 235, 160, 78, 131, 106, 101, 111, 106, 102, 98, 239, 56, 232, 77, 104, 106, 243, 73, 105, 102, 106, 165, 231, 78})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static int JS_dtoa(
      [In] double obj0,
      [In] int obj1,
      [In] bool obj2,
      [In] int obj3,
      [In] bool[] obj4,
      [In] StringBuilder obj5)
    {
      int num1 = obj2 ? 1 : 0;
      int[] numArray1 = new int[1];
      int[] numArray2 = new int[1];
      if ((DToA.word0(obj0) & int.MinValue) != 0)
      {
        obj4[0] = true;
        obj0 = DToA.setWord0(obj0, DToA.word0(obj0) & int.MaxValue);
      }
      else
        obj4[0] = false;
      if ((DToA.word0(obj0) & 2146435072) == 2146435072)
      {
        obj5.append(DToA.word1(obj0) != 0 || (DToA.word0(obj0) & 1048575) != 0 ? "NaN" : "Infinity");
        return 9999;
      }
      if (obj0 == 0.0)
      {
        obj5.setLength(0);
        obj5.append('0');
        return 1;
      }
      BigInteger bigInteger1 = DToA.d2b(obj0, numArray1, numArray2);
      int num2;
      double num3;
      int num4;
      int num5;
      if ((num2 = (int) ((uint) DToA.word0(obj0) >> 20) & 2047) != 0)
      {
        num3 = DToA.setWord0(obj0, DToA.word0(obj0) & 1048575 | 1072693248);
        num4 = num2 - 1023;
        num5 = 0;
      }
      else
      {
        int num6 = numArray2[0] + numArray1[0] + 1074;
        long num7 = num6 <= 32 ? (long) DToA.word1(obj0) << 32 - num6 : (long) DToA.word0(obj0) << 64 - num6 | (long) (int) ((uint) DToA.word1(obj0) >> num6 - 32);
        num3 = DToA.setWord0((double) num7, DToA.word0((double) num7) - 32505856);
        num4 = num6 - 1075;
        num5 = 1;
      }
      double num8 = (num3 - 1.5) * 0.289529654602168 + 0.1760912590558 + (double) num4 * 0.301029995663981;
      int index1 = ByteCodeHelper.d2i(num8);
      if (num8 < 0.0 && num8 != (double) index1)
        index1 += -1;
      int num9 = 1;
      if (index1 >= 0 && index1 <= 22)
      {
        if (obj0 < DToA.tens[index1])
          index1 += -1;
        num9 = 0;
      }
      int num10 = numArray2[0] - num4 - 1;
      int num11;
      int num12;
      if (num10 >= 0)
      {
        num11 = 0;
        num12 = num10;
      }
      else
      {
        num11 = -num10;
        num12 = 0;
      }
      int num13;
      int num14;
      if (index1 >= 0)
      {
        num13 = 0;
        num14 = index1;
        num12 += index1;
      }
      else
      {
        num11 -= index1;
        num13 = -index1;
        num14 = 0;
      }
      if (obj1 < 0 || obj1 > 9)
        obj1 = 0;
      int num15 = 1;
      if (obj1 > 5)
      {
        obj1 += -4;
        num15 = 0;
      }
      int num16 = 1;
      int num17;
      int num18 = num17 = 0;
      switch (obj1)
      {
        case 0:
        case 1:
          num18 = num17 = -1;
          obj3 = 0;
          break;
        case 2:
        case 3:
          num16 = 0;
          goto case 4;
        case 4:
          if (obj3 <= 0)
            obj3 = 1;
          num18 = num17 = obj3;
          break;
        case 5:
          int num19 = obj3 + index1 + 1;
          num18 = num19;
          num17 = num19 - 1;
          if (num19 > 0)
            break;
          break;
      }
      int num20 = 0;
      if (num18 >= 0 && num18 <= 14 && num15 != 0)
      {
        int index2 = 0;
        double num6 = obj0;
        int num7 = index1;
        int num21 = num18;
        int num22 = 2;
        if (index1 > 0)
        {
          double ten = DToA.tens[index1 & 15];
          int num23 = index1 >> 4;
          if ((num23 & 16) != 0)
          {
            num23 &= 15;
            obj0 /= DToA.bigtens[4];
            ++num22;
          }
          while (num23 != 0)
          {
            if ((num23 & 1) != 0)
            {
              ++num22;
              ten *= DToA.bigtens[index2];
            }
            num23 >>= 1;
            ++index2;
          }
          obj0 /= ten;
        }
        else
        {
          int num23;
          if ((num23 = -index1) != 0)
          {
            obj0 *= DToA.tens[num23 & 15];
            int num24 = num23 >> 4;
            while (num24 != 0)
            {
              if ((num24 & 1) != 0)
              {
                ++num22;
                obj0 *= DToA.bigtens[index2];
              }
              num24 >>= 1;
              ++index2;
            }
          }
        }
        if (num9 != 0 && obj0 < 1.0 && num18 > 0)
        {
          if (num17 <= 0)
          {
            num20 = 1;
          }
          else
          {
            num18 = num17;
            index1 += -1;
            obj0 *= 10.0;
            ++num22;
          }
        }
        double num25 = (double) num22 * obj0 + 7.0;
        double num26 = DToA.setWord0(num25, DToA.word0(num25) - 54525952);
        if (num18 == 0)
        {
          obj0 -= 5.0;
          if (obj0 > num26)
          {
            obj5.append('1');
            return index1 + 1 + 1;
          }
          if (obj0 < -num26)
          {
            obj5.setLength(0);
            obj5.append('0');
            return 1;
          }
          num20 = 1;
        }
        if (num20 == 0)
        {
          num20 = 1;
          if (num16 != 0)
          {
            double num23 = 0.5 / DToA.tens[num18 - 1] - num26;
            int num24 = 0;
            while (true)
            {
              long num27 = ByteCodeHelper.d2l(obj0);
              obj0 -= (double) num27;
              obj5.append((char) (48L + num27));
              if (obj0 >= num23)
              {
                if (1.0 - obj0 >= num23)
                {
                  ++num24;
                  if (num24 < num18)
                  {
                    num23 *= 10.0;
                    obj0 *= 10.0;
                  }
                  else
                    goto label_80;
                }
                else
                  goto label_64;
              }
              else
                break;
            }
            return index1 + 1;
label_64:
            int num28;
            do
            {
              num28 = (int) obj5.charAt(obj5.length() - 1);
              obj5.setLength(obj5.length() - 1);
              if (num28 != 57)
                goto label_67;
            }
            while (obj5.length() != 0);
            ++index1;
            num28 = 48;
label_67:
            obj5.append((char) (num28 + 1));
            return index1 + 1;
          }
          double num29 = num26 * DToA.tens[num18 - 1];
          int num30 = 1;
          while (true)
          {
            long num23 = ByteCodeHelper.d2l(obj0);
            obj0 -= (double) num23;
            obj5.append((char) (48L + num23));
            if (num30 != num18)
            {
              ++num30;
              obj0 *= 10.0;
            }
            else
              break;
          }
          if (obj0 > 0.5 + num29)
          {
            int num23;
            do
            {
              num23 = (int) obj5.charAt(obj5.length() - 1);
              obj5.setLength(obj5.length() - 1);
              if (num23 != 57)
                goto label_76;
            }
            while (obj5.length() != 0);
            ++index1;
            num23 = 48;
label_76:
            obj5.append((char) (num23 + 1));
            return index1 + 1;
          }
          if (obj0 < 0.5 - num29)
          {
            DToA.stripTrailingZeroes(obj5);
            return index1 + 1;
          }
        }
label_80:
        if (num20 != 0)
        {
          obj5.setLength(0);
          obj0 = num6;
          index1 = num7;
          num18 = num21;
        }
      }
      if (numArray1[0] >= 0 && index1 <= 14)
      {
        double ten = DToA.tens[index1];
        if (obj3 < 0 && num18 <= 0)
        {
          if (num18 < 0 || obj0 < 5.0 * ten || num1 == 0 && obj0 == 5.0 * ten)
          {
            obj5.setLength(0);
            obj5.append('0');
            return 1;
          }
          obj5.append('1');
          return index1 + 1 + 1;
        }
        int num6 = 1;
        long num7;
        while (true)
        {
          num7 = ByteCodeHelper.d2l(obj0 / ten);
          obj0 -= (double) num7 * ten;
          obj5.append((char) (48L + num7));
          if (num6 != num18)
          {
            obj0 *= 10.0;
            if (obj0 != 0.0)
              ++num6;
            else
              goto label_96;
          }
          else
            break;
        }
        obj0 += obj0;
        if (obj0 > ten || obj0 == ten && ((num7 & 1L) != 0L || num1 != 0))
        {
          int num21;
          do
          {
            num21 = (int) obj5.charAt(obj5.length() - 1);
            obj5.setLength(obj5.length() - 1);
            if (num21 != 57)
              goto label_93;
          }
          while (obj5.length() != 0);
          ++index1;
          num21 = 48;
label_93:
          obj5.append((char) (num21 + 1));
        }
label_96:
        return index1 + 1;
      }
      int num31 = num11;
      int num32 = num13;
      BigInteger bigInteger2 = (BigInteger) null;
      if (num16 != 0)
      {
        int num6;
        if (obj1 < 2)
        {
          num6 = num5 == 0 ? 54 - numArray2[0] : numArray1[0] + 1075;
        }
        else
        {
          int num7 = num18 - 1;
          if (num32 >= num7)
          {
            num32 -= num7;
          }
          else
          {
            int num21;
            num14 += num21 = num7 - num32;
            num13 += num21;
            num32 = 0;
          }
          if ((num6 = num18) < 0)
          {
            num31 -= num6;
            num6 = 0;
          }
        }
        num11 += num6;
        num12 += num6;
        bigInteger2 = BigInteger.valueOf(1L);
      }
      if (num31 > 0 && num12 > 0)
      {
        int num6 = Math.min(num31, num12);
        num11 -= num6;
        num31 -= num6;
        num12 -= num6;
      }
      if (num13 > 0)
      {
        if (num16 != 0)
        {
          if (num32 > 0)
          {
            bigInteger2 = DToA.pow5mult(bigInteger2, num32);
            bigInteger1 = bigInteger2.multiply(bigInteger1);
          }
          int num6;
          if ((num6 = num13 - num32) != 0)
            bigInteger1 = DToA.pow5mult(bigInteger1, num6);
        }
        else
          bigInteger1 = DToA.pow5mult(bigInteger1, num13);
      }
      BigInteger bigInteger3 = BigInteger.valueOf(1L);
      if (num14 > 0)
        bigInteger3 = DToA.pow5mult(bigInteger3, num14);
      int num33 = 0;
      if (obj1 < 2 && DToA.word1(obj0) == 0 && ((DToA.word0(obj0) & 1048575) == 0 && (DToA.word0(obj0) & 2145386496) != 0))
      {
        ++num11;
        ++num12;
        num33 = 1;
      }
      byte[] byteArray = bigInteger3.toByteArray();
      int num34 = 0;
      for (int index2 = 0; index2 < 4; ++index2)
      {
        num34 <<= 8;
        if (index2 < byteArray.Length)
          num34 |= (int) byteArray[index2];
      }
      int num35 = num14 == 0 ? 1 : 32 - DToA.hi0bits(num34);
      int num36 = num12;
      int num37;
      if ((num37 = num35 + num36 & 31) != 0)
        num37 = 32 - num37;
      if (num37 > 4)
      {
        int num6 = num37 - 4;
        num11 += num6;
        num31 += num6;
        num12 += num6;
      }
      else if (num37 < 4)
      {
        int num6 = num37 + 28;
        num11 += num6;
        num31 += num6;
        num12 += num6;
      }
      if (num11 > 0)
        bigInteger1 = bigInteger1.shiftLeft(num11);
      if (num12 > 0)
        bigInteger3 = bigInteger3.shiftLeft(num12);
      if (num9 != 0 && bigInteger1.compareTo(bigInteger3) < 0)
      {
        index1 += -1;
        bigInteger1 = bigInteger1.multiply(BigInteger.valueOf(10L));
        if (num16 != 0)
          bigInteger2 = bigInteger2.multiply(BigInteger.valueOf(10L));
        num18 = num17;
      }
      if (num18 <= 0 && obj1 > 2)
      {
        int num6;
        if (num18 < 0 || (num6 = bigInteger1.compareTo(bigInteger3.multiply(BigInteger.valueOf(5L)))) < 0 || num6 == 0 && num1 == 0)
        {
          obj5.setLength(0);
          obj5.append('0');
          return 1;
        }
        obj5.append('1');
        return index1 + 1 + 1;
      }
      BigInteger bigInteger4;
      int num38;
      if (num16 != 0)
      {
        if (num31 > 0)
          bigInteger2 = bigInteger2.shiftLeft(num31);
        BigInteger bigInteger5 = bigInteger2;
        if (num33 != 0)
          bigInteger2 = bigInteger5.shiftLeft(1);
        int num6 = 1;
        int num7;
        int num21;
        while (true)
        {
          BigInteger[] bigIntegerArray = bigInteger1.divideAndRemainder(bigInteger3);
          bigInteger4 = bigIntegerArray[1];
          num38 = (int) (ushort) (bigIntegerArray[0].intValue() + 48);
          num7 = bigInteger4.compareTo(bigInteger5);
          BigInteger bigInteger6 = bigInteger3.subtract(bigInteger2);
          num21 = bigInteger6.signum() > 0 ? bigInteger4.compareTo(bigInteger6) : 1;
          if (num21 != 0 || obj1 != 0 || (DToA.word1(obj0) & 1) != 0)
          {
            if (num7 >= 0 && (num7 != 0 || obj1 != 0 || (DToA.word1(obj0) & 1) != 0))
            {
              if (num21 <= 0)
              {
                obj5.append((char) num38);
                if (num6 != num18)
                {
                  bigInteger1 = bigInteger4.multiply(BigInteger.valueOf(10L));
                  if (object.ReferenceEquals((object) bigInteger5, (object) bigInteger2))
                  {
                    bigInteger5 = bigInteger2 = bigInteger2.multiply(BigInteger.valueOf(10L));
                  }
                  else
                  {
                    bigInteger5 = bigInteger5.multiply(BigInteger.valueOf(10L));
                    bigInteger2 = bigInteger2.multiply(BigInteger.valueOf(10L));
                  }
                  ++num6;
                }
                else
                  goto label_178;
              }
              else
                goto label_165;
            }
            else
              goto label_157;
          }
          else
            break;
        }
        if (num38 == 57)
        {
          obj5.append('9');
          if (DToA.roundOff(obj5))
          {
            ++index1;
            obj5.append('1');
          }
          return index1 + 1;
        }
        if (num7 > 0)
          num38 = (int) (ushort) (num38 + 1);
        obj5.append((char) num38);
        return index1 + 1;
label_157:
        if (num21 > 0)
        {
          int num22 = bigInteger4.shiftLeft(1).compareTo(bigInteger3);
          if (num22 > 0 || num22 == 0 && ((num38 & 1) == 1 || num1 != 0))
          {
            int num23 = num38;
            num38 = (int) (ushort) (num38 + 1);
            if (num23 == 57)
            {
              obj5.append('9');
              if (DToA.roundOff(obj5))
              {
                ++index1;
                obj5.append('1');
              }
              return index1 + 1;
            }
          }
        }
        obj5.append((char) num38);
        return index1 + 1;
label_165:
        if (num38 == 57)
        {
          obj5.append('9');
          if (DToA.roundOff(obj5))
          {
            ++index1;
            obj5.append('1');
          }
          return index1 + 1;
        }
        obj5.append((char) (num38 + 1));
        return index1 + 1;
      }
      int num39 = 1;
      while (true)
      {
        BigInteger[] bigIntegerArray = bigInteger1.divideAndRemainder(bigInteger3);
        bigInteger4 = bigIntegerArray[1];
        num38 = (int) (ushort) (bigIntegerArray[0].intValue() + 48);
        obj5.append((char) num38);
        if (num39 < num18)
        {
          bigInteger1 = bigInteger4.multiply(BigInteger.valueOf(10L));
          ++num39;
        }
        else
          break;
      }
label_178:
      int num40 = bigInteger4.shiftLeft(1).compareTo(bigInteger3);
      if (num40 > 0 || num40 == 0 && ((num38 & 1) == 1 || num1 != 0))
      {
        if (DToA.roundOff(obj5))
        {
          int num6 = index1 + 1;
          obj5.append('1');
          return num6 + 1;
        }
      }
      else
        DToA.stripTrailingZeroes(obj5);
      return index1 + 1;
    }

    [LineNumberTable(5)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal DToA()
    {
    }

    [LineNumberTable(new byte[] {125, 105, 191, 6, 105, 102, 105, 118, 137, 198, 105, 132, 98, 229, 70, 106, 103, 133, 180, 104, 142, 100, 146, 152, 99, 133, 106, 105, 101, 109, 101, 140, 169, 133, 226, 73, 103, 112, 136, 105, 104, 133, 104, 136, 205, 110, 100, 99, 170, 105, 100, 216, 102, 169, 112, 105, 235, 70, 137, 131, 107, 107, 102, 108, 107, 144, 107, 203, 139, 107, 152, 106, 101, 102, 104, 111, 165, 106, 107, 133, 134, 101, 101, 102, 163, 111, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static string JS_dtobasestr([In] int obj0, [In] double obj1)
    {
      if (2 > obj0 || obj0 > 36)
      {
        string str = new StringBuilder().append("Bad base: ").append(obj0).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException(str);
      }
      if (Double.isNaN(obj1))
        return "NaN";
      if (Double.isInfinite(obj1))
        return obj1 > 0.0 ? "Infinity" : "-Infinity";
      if (obj1 == 0.0)
        return "0";
      int num1;
      if (obj1 >= 0.0)
      {
        num1 = 0;
      }
      else
      {
        num1 = 1;
        obj1 = -obj1;
      }
      double num2 = Math.floor(obj1);
      long num3 = ByteCodeHelper.d2l(num2);
      string str1;
      if ((double) num3 == num2)
      {
        str1 = Long.toString(num1 == 0 ? num3 : -num3, obj0);
      }
      else
      {
        long longBits = Double.doubleToLongBits(num2);
        int num4 = (int) (longBits >> 52) & 2047;
        long num5 = num4 != 0 ? longBits & 4503599627370495L | 4503599627370496L : (longBits & 4503599627370495L) << 1;
        if (num1 != 0)
          num5 = -num5;
        int num6 = num4 - 1075;
        BigInteger bigInteger = BigInteger.valueOf(num5);
        if (num6 > 0)
          bigInteger = bigInteger.shiftLeft(num6);
        else if (num6 < 0)
          bigInteger = bigInteger.shiftRight(-num6);
        str1 = bigInteger.toString(obj0);
      }
      if (obj1 == num2)
        return str1;
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.append(str1).append('.');
      double num7 = obj1 - num2;
      long longBits1 = Double.doubleToLongBits(obj1);
      int num8 = (int) (longBits1 >> 32);
      int num9 = (int) longBits1;
      int[] numArray1 = new int[1];
      int[] numArray2 = new int[1];
      BigInteger bigInteger1 = DToA.d2b(num7, numArray1, numArray2);
      int num10 = -((int) ((uint) num8 >> 20) & 2047);
      if (num10 == 0)
        num10 = -1;
      int num11 = num10 + 1076;
      BigInteger bigInteger2 = BigInteger.valueOf(1L);
      BigInteger bigInteger3 = bigInteger2;
      if (num9 == 0 && (num8 & 1048575) == 0 && (num8 & 2145386496) != 0)
      {
        ++num11;
        bigInteger3 = BigInteger.valueOf(2L);
      }
      BigInteger bigInteger4 = bigInteger1.shiftLeft(numArray1[0] + num11);
      BigInteger bigInteger5 = BigInteger.valueOf(1L).shiftLeft(num11);
      BigInteger bigInteger6 = BigInteger.valueOf((long) obj0);
      int num12 = 0;
      do
      {
        BigInteger[] bigIntegerArray = bigInteger4.multiply(bigInteger6).divideAndRemainder(bigInteger5);
        bigInteger4 = bigIntegerArray[1];
        int num4 = (int) (ushort) bigIntegerArray[0].intValue();
        if (object.ReferenceEquals((object) bigInteger2, (object) bigInteger3))
        {
          bigInteger2 = bigInteger3 = bigInteger2.multiply(bigInteger6);
        }
        else
        {
          bigInteger2 = bigInteger2.multiply(bigInteger6);
          bigInteger3 = bigInteger3.multiply(bigInteger6);
        }
        int num5 = bigInteger4.compareTo(bigInteger2);
        BigInteger bigInteger7 = bigInteger5.subtract(bigInteger3);
        int num6 = bigInteger7.signum() > 0 ? bigInteger4.compareTo(bigInteger7) : 1;
        if (num6 == 0 && (num9 & 1) == 0)
        {
          if (num5 > 0)
            ++num4;
          num12 = 1;
        }
        else if (num5 < 0 || num5 == 0 && (num9 & 1) == 0)
        {
          if (num6 > 0)
          {
            bigInteger4 = bigInteger4.shiftLeft(1);
            if (bigInteger4.compareTo(bigInteger5) > 0)
              ++num4;
          }
          num12 = 1;
        }
        else if (num6 > 0)
        {
          ++num4;
          num12 = 1;
        }
        stringBuilder.append(DToA.BASEDIGIT(num4));
      }
      while (num12 == 0);
      return stringBuilder.toString();
    }

    [LineNumberTable(new byte[] {163, 194, 231, 70, 126, 131, 121, 167, 107, 98, 163, 159, 0, 106, 132, 99, 162, 100, 135, 99, 194, 163, 98, 194, 99, 105, 226, 69, 101, 100, 131, 105, 170, 131, 100, 138, 105, 102, 105, 140, 164, 132, 172, 106, 42, 136, 234, 70, 103, 119, 116, 118, 138})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static void JS_dtostr([In] StringBuilder obj0, [In] int obj1, [In] int obj2, [In] double obj3)
    {
      bool[] flagArray = new bool[1];
      if (obj1 == 2 && (obj3 >= 1E+21 || obj3 <= -1E+21))
        obj1 = 0;
      int num1 = DToA.JS_dtoa(obj3, DToA.dtoaModes[obj1], obj1 >= 2, obj2, flagArray, obj0);
      int num2 = obj0.length();
      if (num1 != 9999)
      {
        int num3 = 0;
        int num4 = 0;
        switch (obj1)
        {
          case 0:
            if (num1 < -5 || num1 > 21)
            {
              num3 = 1;
              break;
            }
            num4 = num1;
            break;
          case 1:
            num3 = 1;
            break;
          case 2:
            num4 = obj2 < 0 ? num1 : num1 + obj2;
            break;
          case 3:
            num4 = obj2;
            goto case 1;
          case 4:
            num4 = obj2;
            if (num1 < -5 || num1 > obj2)
            {
              num3 = 1;
              break;
            }
            break;
        }
        if (num2 < num4)
        {
          int num5 = num4;
          num2 = num4;
          do
          {
            obj0.append('0');
          }
          while (obj0.length() != num5);
        }
        if (num3 != 0)
        {
          if (num2 != 1)
            obj0.insert(1, '.');
          obj0.append('e');
          if (num1 - 1 >= 0)
            obj0.append('+');
          obj0.append(num1 - 1);
        }
        else if (num1 != num2)
        {
          if (num1 > 0)
          {
            obj0.insert(num1, '.');
          }
          else
          {
            for (int index = 0; index < 1 - num1; ++index)
              obj0.insert(0, '0');
            obj0.insert(1, '.');
          }
        }
      }
      if (!flagArray[0] || DToA.word0(obj3) == int.MinValue && DToA.word1(obj3) == 0 || (DToA.word0(obj3) & 2146435072) == 2146435072 && (DToA.word1(obj3) != 0 || (DToA.word0(obj3) & 1048575) != 0))
        return;
      obj0.insert(0, '-');
    }

    [LineNumberTable(new byte[] {159, 131, 173, 255, 160, 203, 70, 255, 40, 163, 245})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static DToA()
    {
      if (ByteCodeHelper.isAlreadyInited("rhino.DToA"))
        return;
      DToA.tens = new double[23]
      {
        1.0,
        10.0,
        100.0,
        1000.0,
        10000.0,
        100000.0,
        1000000.0,
        10000000.0,
        100000000.0,
        1000000000.0,
        10000000000.0,
        100000000000.0,
        1000000000000.0,
        10000000000000.0,
        100000000000000.0,
        1E+15,
        1E+16,
        1E+17,
        1E+18,
        1E+19,
        1E+20,
        1E+21,
        1E+22
      };
      DToA.bigtens = new double[5]
      {
        1E+16,
        1E+32,
        1E+64,
        1E+128,
        1E+256
      };
      DToA.dtoaModes = new int[5]{ 0, 0, 3, 2, 2 };
    }
  }
}
