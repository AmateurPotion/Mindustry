// Decompiled with JetBrains decompiler
// Type: arc.util.serialization.Base64Coder
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.util.serialization
{
  public class Base64Coder : Object
  {
    internal static Base64Coder.CharMap __\u003C\u003EregularMap;
    internal static Base64Coder.CharMap __\u003C\u003EurlsafeMap;
    private const string systemLineSeparator = "\n";

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(79)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static char[] encode(byte[] @in) => Base64Coder.encode(@in, Base64Coder.__\u003C\u003EregularMap.__\u003C\u003EencodingMap);

    [LineNumberTable(191)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static byte[] decode(string s) => Base64Coder.decode(String.instancehelper_toCharArray(s));

    [LineNumberTable(98)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static char[] encode(byte[] @in, int iLen) => Base64Coder.encode(@in, 0, iLen, Base64Coder.__\u003C\u003EregularMap.__\u003C\u003EencodingMap);

    [LineNumberTable(25)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static string encodeString(string s, bool useUrlsafeEncoding)
    {
      int num = useUrlsafeEncoding ? 1 : 0;
      return String.newhelper(Base64Coder.encode(String.instancehelper_getBytes(s, Strings.__\u003C\u003Eutf8), num == 0 ? Base64Coder.__\u003C\u003EregularMap.__\u003C\u003EencodingMap : Base64Coder.__\u003C\u003EurlsafeMap.__\u003C\u003EencodingMap));
    }

    [LineNumberTable(87)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static char[] encode(byte[] @in, char[] charMap) => Base64Coder.encode(@in, 0, @in.Length, charMap);

    [LineNumberTable(new byte[] {5, 102, 100, 139, 112, 114, 103, 99, 101, 108, 117, 105, 103, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static string encodeLines(
      byte[] @in,
      int iOff,
      int iLen,
      int lineLen,
      string lineSeparator,
      char[] charMap)
    {
      int num1 = lineLen * 3 / 4;
      if (num1 <= 0)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException();
      }
      int num2 = iLen + num1 - 1;
      int num3 = num1;
      int num4 = num3 != -1 ? num2 / num3 : -num2;
      StringBuilder stringBuilder = new StringBuilder((iLen + 2) / 3 * 4 + num4 * String.instancehelper_length(lineSeparator));
      int iLen1;
      for (int index = 0; index < iLen; index += iLen1)
      {
        iLen1 = Math.min(iLen - index, num1);
        stringBuilder.append(Base64Coder.encode(@in, iOff + index, iLen1, charMap));
        stringBuilder.append(lineSeparator);
      }
      return stringBuilder.toString();
    }

    [LineNumberTable(new byte[] {65, 104, 104, 103, 98, 101, 99, 104, 105, 113, 113, 102, 109, 110, 103, 110, 110, 113, 102, 113, 102, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static char[] encode(byte[] @in, int iOff, int iLen, char[] charMap)
    {
      int num1 = (iLen * 4 + 2) / 3;
      char[] chArray1 = new char[(iLen + 2) / 3 * 4];
      int num2 = iOff;
      int num3 = iOff + iLen;
      int num4 = 0;
      while (num2 < num3)
      {
        byte[] numArray1 = @in;
        int index1 = num2;
        ++num2;
        int num5 = (int) numArray1[index1];
        int num6;
        if (num2 < num3)
        {
          byte[] numArray2 = @in;
          int index2 = num2;
          ++num2;
          num6 = (int) numArray2[index2];
        }
        else
          num6 = 0;
        int num7 = num6;
        int num8;
        if (num2 < num3)
        {
          byte[] numArray2 = @in;
          int index2 = num2;
          ++num2;
          num8 = (int) numArray2[index2];
        }
        else
          num8 = 0;
        int num9 = num8;
        int index3 = (int) ((uint) num5 >> 2);
        int index4 = (num5 & 3) << 4 | (int) ((uint) num7 >> 4);
        int index5 = (num7 & 15) << 2 | (int) ((uint) num9 >> 6);
        int index6 = num9 & 63;
        char[] chArray2 = chArray1;
        int index7 = num4;
        int num10 = num4 + 1;
        int num11 = (int) charMap[index3];
        chArray2[index7] = (char) num11;
        char[] chArray3 = chArray1;
        int index8 = num10;
        int index9 = num10 + 1;
        int num12 = (int) charMap[index4];
        chArray3[index8] = (char) num12;
        chArray1[index9] = index9 >= num1 ? '=' : charMap[index5];
        int index10 = index9 + 1;
        chArray1[index10] = index10 >= num1 ? '=' : charMap[index6];
        num4 = index10 + 1;
      }
      return chArray1;
    }

    [LineNumberTable(102)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static char[] encode(byte[] @in, int iOff, int iLen, Base64Coder.CharMap charMap) => Base64Coder.encode(@in, iOff, iLen, charMap.__\u003C\u003EencodingMap);

    [LineNumberTable(151)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static string decodeString(string s, bool useUrlSafeEncoding)
    {
      int num = useUrlSafeEncoding ? 1 : 0;
      return String.newhelper(Base64Coder.decode(String.instancehelper_toCharArray(s), num == 0 ? Base64Coder.__\u003C\u003EregularMap.__\u003C\u003EdecodingMap : Base64Coder.__\u003C\u003EurlsafeMap.__\u003C\u003EdecodingMap));
    }

    [LineNumberTable(207)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static byte[] decode(char[] @in, byte[] inverseCharMap) => Base64Coder.decode(@in, 0, @in.Length, inverseCharMap);

    [LineNumberTable(new byte[] {122, 108, 98, 107, 104, 116, 232, 61, 230, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static byte[] decodeLines(string s, byte[] inverseCharMap)
    {
      char[] @in = new char[String.instancehelper_length(s)];
      int iLen = 0;
      for (int index1 = 0; index1 < String.instancehelper_length(s); ++index1)
      {
        int num1 = (int) String.instancehelper_charAt(s, index1);
        switch (num1)
        {
          case 9:
          case 10:
          case 13:
          case 32:
            continue;
          default:
            char[] chArray = @in;
            int index2 = iLen;
            ++iLen;
            int num2 = num1;
            chArray[index2] = (char) num2;
            continue;
        }
      }
      return Base64Coder.decode(@in, 0, iLen, inverseCharMap);
    }

    [LineNumberTable(new byte[] {160, 126, 110, 144, 111, 135, 102, 103, 98, 100, 99, 103, 105, 105, 113, 113, 120, 144, 102, 102, 102, 102, 116, 144, 107, 110, 107, 109, 101, 141, 101, 141, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static byte[] decode(char[] @in, int iOff, int iLen, byte[] inverseCharMap)
    {
      int num1 = iLen;
      int num2 = 4;
      if ((num2 != -1 ? num1 % num2 : 0) != 0)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException("Length of Base64 encoded input string is not a multiple of 4.");
      }
      while (iLen > 0 && @in[iOff + iLen - 1] == '=')
        iLen += -1;
      int length = iLen * 3 / 4;
      byte[] numArray1 = new byte[length];
      int num3 = iOff;
      int num4 = iOff + iLen;
      int num5 = 0;
      while (num3 < num4)
      {
        char[] chArray1 = @in;
        int index1 = num3;
        int num6 = num3 + 1;
        int index2 = (int) chArray1[index1];
        char[] chArray2 = @in;
        int index3 = num6;
        num3 = num6 + 1;
        int index4 = (int) chArray2[index3];
        int num7;
        if (num3 < num4)
        {
          char[] chArray3 = @in;
          int index5 = num3;
          ++num3;
          num7 = (int) chArray3[index5];
        }
        else
          num7 = 65;
        int index6 = num7;
        int num8;
        if (num3 < num4)
        {
          char[] chArray3 = @in;
          int index5 = num3;
          ++num3;
          num8 = (int) chArray3[index5];
        }
        else
          num8 = 65;
        int index7 = num8;
        if (index2 > (int) sbyte.MaxValue || index4 > (int) sbyte.MaxValue || (index6 > (int) sbyte.MaxValue || index7 > (int) sbyte.MaxValue))
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalArgumentException("Illegal character in Base64 encoded data.");
        }
        int inverseChar1 = (int) (sbyte) inverseCharMap[index2];
        int inverseChar2 = (int) (sbyte) inverseCharMap[index4];
        int inverseChar3 = (int) (sbyte) inverseCharMap[index6];
        int inverseChar4 = (int) (sbyte) inverseCharMap[index7];
        if (inverseChar1 < 0 || inverseChar2 < 0 || (inverseChar3 < 0 || inverseChar4 < 0))
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalArgumentException("Illegal character in Base64 encoded data.");
        }
        int num9 = inverseChar1 << 2 | (int) ((uint) inverseChar2 >> 4);
        int num10 = (inverseChar2 & 15) << 4 | (int) ((uint) inverseChar3 >> 2);
        int num11 = (inverseChar3 & 3) << 6 | inverseChar4;
        byte[] numArray2 = numArray1;
        int index8 = num5;
        ++num5;
        int num12 = (int) (sbyte) num9;
        numArray2[index8] = (byte) num12;
        if (num5 < length)
        {
          byte[] numArray3 = numArray1;
          int index5 = num5;
          ++num5;
          int num13 = (int) (sbyte) num10;
          numArray3[index5] = (byte) num13;
        }
        if (num5 < length)
        {
          byte[] numArray3 = numArray1;
          int index5 = num5;
          ++num5;
          int num13 = (int) (sbyte) num11;
          numArray3[index5] = (byte) num13;
        }
      }
      return numArray1;
    }

    [LineNumberTable(222)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static byte[] decode(char[] @in) => Base64Coder.decode(@in, 0, @in.Length, Base64Coder.__\u003C\u003EregularMap.__\u003C\u003EdecodingMap);

    [LineNumberTable(211)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static byte[] decode(char[] @in, Base64Coder.CharMap inverseCharMap) => Base64Coder.decode(@in, 0, @in.Length, inverseCharMap);

    [LineNumberTable(226)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static byte[] decode(
      char[] @in,
      int iOff,
      int iLen,
      Base64Coder.CharMap inverseCharMap)
    {
      return Base64Coder.decode(@in, iOff, iLen, inverseCharMap.__\u003C\u003EdecodingMap);
    }

    [LineNumberTable(new byte[] {159, 153, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Base64Coder()
    {
    }

    [LineNumberTable(21)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static string encodeString(string s) => Base64Coder.encodeString(s, false);

    [LineNumberTable(36)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static string encodeLines(byte[] @in) => Base64Coder.encodeLines(@in, 0, @in.Length, 76, "\n", Base64Coder.__\u003C\u003EregularMap.__\u003C\u003EencodingMap);

    [LineNumberTable(40)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static string encodeLines(
      byte[] @in,
      int iOff,
      int iLen,
      int lineLen,
      string lineSeparator,
      Base64Coder.CharMap charMap)
    {
      return Base64Coder.encodeLines(@in, iOff, iLen, lineLen, lineSeparator, charMap.__\u003C\u003EencodingMap);
    }

    [LineNumberTable(83)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static char[] encode(byte[] @in, Base64Coder.CharMap charMap) => Base64Coder.encode(@in, 0, @in.Length, charMap);

    [LineNumberTable(147)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static string decodeString(string s) => Base64Coder.decodeString(s, false);

    [LineNumberTable(155)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static byte[] decodeLines(string s) => Base64Coder.decodeLines(s, Base64Coder.__\u003C\u003EregularMap.__\u003C\u003EdecodingMap);

    [LineNumberTable(159)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static byte[] decodeLines(string s, Base64Coder.CharMap inverseCharMap) => Base64Coder.decodeLines(s, inverseCharMap.__\u003C\u003EdecodingMap);

    [LineNumberTable(203)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static byte[] decode(string s, Base64Coder.CharMap inverseCharMap) => Base64Coder.decode(String.instancehelper_toCharArray(s), inverseCharMap);

    [LineNumberTable(6)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static Base64Coder()
    {
      if (ByteCodeHelper.isAlreadyInited("arc.util.serialization.Base64Coder"))
        return;
      Base64Coder.__\u003C\u003EregularMap = new Base64Coder.CharMap('+', '/');
      Base64Coder.__\u003C\u003EurlsafeMap = new Base64Coder.CharMap('-', '_');
    }

    [Modifiers]
    public static Base64Coder.CharMap regularMap
    {
      [HideFromJava] get => Base64Coder.__\u003C\u003EregularMap;
    }

    [Modifiers]
    public static Base64Coder.CharMap urlsafeMap
    {
      [HideFromJava] get => Base64Coder.__\u003C\u003EurlsafeMap;
    }

    public class CharMap : Object
    {
      internal char[] __\u003C\u003EencodingMap;
      internal byte[] __\u003C\u003EdecodingMap;

      [LineNumberTable(new byte[] {159, 71, 68, 232, 61, 109, 176, 98, 106, 46, 169, 106, 46, 169, 106, 46, 169, 109, 109, 108, 41, 166, 103, 49, 166})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public CharMap(char char63, char char64)
      {
        int num1 = (int) char63;
        int num2 = (int) char64;
        // ISSUE: explicit constructor call
        base.\u002Ector();
        Base64Coder.CharMap charMap = this;
        this.__\u003C\u003EencodingMap = new char[64];
        this.__\u003C\u003EdecodingMap = new byte[128];
        int num3 = 0;
        for (int index1 = 65; index1 <= 90; index1 = (int) (ushort) (index1 + 1))
        {
          char[] encodingMap = this.__\u003C\u003EencodingMap;
          int index2 = num3;
          ++num3;
          int num4 = index1;
          encodingMap[index2] = (char) num4;
        }
        for (int index1 = 97; index1 <= 122; index1 = (int) (ushort) (index1 + 1))
        {
          char[] encodingMap = this.__\u003C\u003EencodingMap;
          int index2 = num3;
          ++num3;
          int num4 = index1;
          encodingMap[index2] = (char) num4;
        }
        for (int index1 = 48; index1 <= 57; index1 = (int) (ushort) (index1 + 1))
        {
          char[] encodingMap = this.__\u003C\u003EencodingMap;
          int index2 = num3;
          ++num3;
          int num4 = index1;
          encodingMap[index2] = (char) num4;
        }
        char[] encodingMap1 = this.__\u003C\u003EencodingMap;
        int index3 = num3;
        int num5 = num3 + 1;
        int num6 = num1;
        encodingMap1[index3] = (char) num6;
        char[] encodingMap2 = this.__\u003C\u003EencodingMap;
        int index4 = num5;
        int num7 = num5 + 1;
        int num8 = num2;
        encodingMap2[index4] = (char) num8;
        for (int index1 = 0; index1 < this.__\u003C\u003EdecodingMap.Length; ++index1)
          this.__\u003C\u003EdecodingMap[index1] = byte.MaxValue;
        for (int index1 = 0; index1 < 64; ++index1)
          this.__\u003C\u003EdecodingMap[(int) this.__\u003C\u003EencodingMap[index1]] = (byte) index1;
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual byte[] getDecodingMap() => this.__\u003C\u003EdecodingMap;

      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual char[] getEncodingMap() => this.__\u003C\u003EencodingMap;

      [Modifiers]
      protected internal char[] encodingMap
      {
        [HideFromJava] get => this.__\u003C\u003EencodingMap;
        [HideFromJava] [param: In] private set => this.__\u003C\u003EencodingMap = value;
      }

      [Modifiers]
      protected internal byte[] decodingMap
      {
        [HideFromJava] get => this.__\u003C\u003EdecodingMap;
        [HideFromJava] [param: In] private set => this.__\u003C\u003EdecodingMap = value;
      }
    }
  }
}
