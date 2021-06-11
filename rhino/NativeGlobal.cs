// Decompiled with JetBrains decompiler
// Type: rhino.NativeGlobal
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace rhino
{
  public class NativeGlobal : Object, IdFunctionCall
  {
    internal const long serialVersionUID = 6080442165748707530;
    private const string URI_DECODE_RESERVED = ";/?:@&=+$,#";
    private const int INVALID_UTF8 = 2147483647;
    [Modifiers]
    private static object FTAG;
    private const int Id_decodeURI = 1;
    private const int Id_decodeURIComponent = 2;
    private const int Id_encodeURI = 3;
    private const int Id_encodeURIComponent = 4;
    private const int Id_escape = 5;
    private const int Id_eval = 6;
    private const int Id_isFinite = 7;
    private const int Id_isNaN = 8;
    private const int Id_isXMLName = 9;
    private const int Id_parseFloat = 10;
    private const int Id_parseInt = 11;
    private const int Id_unescape = 12;
    private const int Id_uneval = 13;
    private const int LAST_SCOPE_FUNCTION_ID = 13;
    private const int Id_new_CommonError = 14;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(13)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public NativeGlobal()
    {
    }

    [LineNumberTable(new byte[] {158, 251, 66, 98, 130, 114, 105, 102, 99, 137, 137, 163, 104, 106, 130, 99, 103, 107, 121, 112, 100, 106, 234, 69, 143, 107, 103, 99, 103, 108, 103, 99, 103, 108, 102, 99, 102, 105, 102, 99, 102, 105, 102, 99, 102, 169, 139, 106, 107, 108, 107, 107, 121, 116, 107, 108, 228, 57, 235, 74, 152, 105, 114, 135, 105, 106, 105, 139, 110, 113, 105, 98, 165, 114, 105, 47, 202, 169, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static string decode([In] string obj0, [In] bool obj1)
    {
      int num1 = obj1 ? 1 : 0;
      char[] chArray1 = (char[]) null;
      int num2 = 0;
      int num3 = 0;
      int length = String.instancehelper_length(obj0);
label_1:
      while (num3 != length)
      {
        int num4 = (int) String.instancehelper_charAt(obj0, num3);
        if (num4 != 37)
        {
          if (chArray1 != null)
          {
            char[] chArray2 = chArray1;
            int index = num2;
            ++num2;
            int num5 = num4;
            chArray2[index] = (char) num5;
          }
          ++num3;
        }
        else
        {
          if (chArray1 == null)
          {
            chArray1 = new char[length];
            String.instancehelper_getChars(obj0, 0, num3, chArray1, 0);
            num2 = num3;
          }
          int num5 = num3;
          int num6 = num3 + 3 <= length ? NativeGlobal.unHex(String.instancehelper_charAt(obj0, num3 + 1), String.instancehelper_charAt(obj0, num3 + 2)) : throw Throwable.__\u003Cunmap\u003E((Exception) NativeGlobal.uriError());
          if (num6 < 0)
            throw Throwable.__\u003Cunmap\u003E((Exception) NativeGlobal.uriError());
          num3 += 3;
          int num7;
          if ((num6 & 128) == 0)
          {
            num7 = (int) (ushort) num6;
          }
          else
          {
            if ((num6 & 192) == 128)
              throw Throwable.__\u003Cunmap\u003E((Exception) NativeGlobal.uriError());
            int num8;
            int num9;
            int num10;
            if ((num6 & 32) == 0)
            {
              num8 = 1;
              num9 = num6 & 31;
              num10 = 128;
            }
            else if ((num6 & 16) == 0)
            {
              num8 = 2;
              num9 = num6 & 15;
              num10 = 2048;
            }
            else if ((num6 & 8) == 0)
            {
              num8 = 3;
              num9 = num6 & 7;
              num10 = 65536;
            }
            else if ((num6 & 4) == 0)
            {
              num8 = 4;
              num9 = num6 & 3;
              num10 = 2097152;
            }
            else
            {
              if ((num6 & 2) != 0)
                throw Throwable.__\u003Cunmap\u003E((Exception) NativeGlobal.uriError());
              num8 = 5;
              num9 = num6 & 1;
              num10 = 67108864;
            }
            if (num3 + 3 * num8 > length)
              throw Throwable.__\u003Cunmap\u003E((Exception) NativeGlobal.uriError());
            for (int index = 0; index != num8; ++index)
            {
              int num11 = String.instancehelper_charAt(obj0, num3) == '%' ? NativeGlobal.unHex(String.instancehelper_charAt(obj0, num3 + 1), String.instancehelper_charAt(obj0, num3 + 2)) : throw Throwable.__\u003Cunmap\u003E((Exception) NativeGlobal.uriError());
              if (num11 < 0 || (num11 & 192) != 128)
                throw Throwable.__\u003Cunmap\u003E((Exception) NativeGlobal.uriError());
              num9 = num9 << 6 | num11 & 63;
              num3 += 3;
            }
            if (num9 < num10 || num9 >= 55296 && num9 <= 57343)
              num9 = int.MaxValue;
            else if (num9 == 65534 || num9 == (int) ushort.MaxValue)
              num9 = 65533;
            if (num9 >= 65536)
            {
              int num11 = num9 - 65536;
              if (num11 > 1048575)
                throw Throwable.__\u003Cunmap\u003E((Exception) NativeGlobal.uriError());
              int num12 = (int) (ushort) (((uint) num11 >> 10) + 55296U);
              num7 = (int) (ushort) ((num11 & 1023) + 56320);
              char[] chArray2 = chArray1;
              int index = num2;
              ++num2;
              int num13 = num12;
              chArray2[index] = (char) num13;
            }
            else
              num7 = (int) (ushort) num9;
          }
          if (num1 != 0 && String.instancehelper_indexOf(";/?:@&=+$,#", num7) >= 0)
          {
            int num8 = num5;
            while (true)
            {
              if (num8 != num3)
              {
                char[] chArray2 = chArray1;
                int index = num2;
                ++num2;
                int num9 = (int) String.instancehelper_charAt(obj0, num8);
                chArray2[index] = (char) num9;
                ++num8;
              }
              else
                goto label_1;
            }
          }
          else
          {
            char[] chArray2 = chArray1;
            int index = num2;
            ++num2;
            int num8 = num7;
            chArray2[index] = (char) num8;
          }
        }
      }
      return chArray1 == null ? obj0 : String.newhelper(chArray1, 0, num2);
    }

    [LineNumberTable(new byte[] {159, 13, 66, 98, 130, 114, 105, 106, 102, 174, 99, 106, 104, 103, 135, 114, 171, 114, 134, 100, 101, 139, 105, 114, 139, 156, 106, 105, 108, 105, 112, 241, 60, 232, 33, 233, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static string encode([In] string obj0, [In] bool obj1)
    {
      int num1 = obj1 ? 1 : 0;
      byte[] numArray = (byte[]) null;
      StringBuilder stringBuilder = (StringBuilder) null;
      int num2 = 0;
      for (int index1 = String.instancehelper_length(obj0); num2 != index1; ++num2)
      {
        int num3 = (int) String.instancehelper_charAt(obj0, num2);
        if (NativeGlobal.encodeUnescaped((char) num3, num1 != 0))
        {
          stringBuilder?.append((char) num3);
        }
        else
        {
          if (stringBuilder == null)
          {
            stringBuilder = new StringBuilder(index1 + 3);
            stringBuilder.append(obj0);
            stringBuilder.setLength(num2);
            numArray = new byte[6];
          }
          if (56320 <= num3 && num3 <= 57343)
            throw Throwable.__\u003Cunmap\u003E((Exception) NativeGlobal.uriError());
          int num4;
          if (num3 < 55296 || 56319 < num3)
          {
            num4 = num3;
          }
          else
          {
            ++num2;
            int num5 = num2 != index1 ? (int) String.instancehelper_charAt(obj0, num2) : throw Throwable.__\u003Cunmap\u003E((Exception) NativeGlobal.uriError());
            if (56320 > num5 || num5 > 57343)
              throw Throwable.__\u003Cunmap\u003E((Exception) NativeGlobal.uriError());
            num4 = (num3 - 55296 << 10) + (num5 - 56320) + 65536;
          }
          int utf8Char = NativeGlobal.oneUcs4ToUtf8Char(numArray, num4);
          for (int index2 = 0; index2 < utf8Char; ++index2)
          {
            int num5 = (int) byte.MaxValue & (int) (sbyte) numArray[index2];
            stringBuilder.append('%');
            stringBuilder.append(NativeGlobal.toHexChar((int) ((uint) num5 >> 4)));
            stringBuilder.append(NativeGlobal.toHexChar(num5 & 15));
          }
        }
      }
      return stringBuilder == null ? obj0 : stringBuilder.toString();
    }

    [LineNumberTable(new byte[] {160, 245, 98, 98, 130, 136, 98, 101, 107, 155, 208, 98, 116, 106, 255, 62, 69, 102, 175, 99, 106, 104, 200, 105, 106, 105, 133, 105, 133, 105, 105, 195, 109, 109, 116, 234, 61, 233, 32, 235, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private object js_escape([In] object[] obj0)
    {
      string str = ScriptRuntime.toString(obj0, 0);
      int num1 = 7;
      if (obj0.Length > 1)
      {
        double number = ScriptRuntime.toNumber(obj0[1]);
        if (Double.isNaN(number) || (double) (num1 = ByteCodeHelper.d2i(number)) != number || 0 != (num1 & -8))
          throw Throwable.__\u003Cunmap\u003E((Exception) Context.reportRuntimeError0("msg.bad.esc.mask"));
      }
      StringBuilder stringBuilder = (StringBuilder) null;
      int num2 = 0;
      for (int index1 = String.instancehelper_length(str); num2 != index1; ++num2)
      {
        int num3 = (int) String.instancehelper_charAt(str, num2);
        if (num1 != 0 && (num3 >= 48 && num3 <= 57 || num3 >= 65 && num3 <= 90 || (num3 >= 97 && num3 <= 122 || (num3 == 64 || num3 == 42)) || (num3 == 95 || num3 == 45 || num3 == 46 || 0 != (num1 & 4) && (num3 == 47 || num3 == 43))))
        {
          stringBuilder?.append((char) num3);
        }
        else
        {
          if (stringBuilder == null)
          {
            stringBuilder = new StringBuilder(index1 + 3);
            stringBuilder.append(str);
            stringBuilder.setLength(num2);
          }
          int num4;
          if (num3 < 256)
          {
            if (num3 == 32 && num1 == 2)
            {
              stringBuilder.append('+');
              continue;
            }
            stringBuilder.append('%');
            num4 = 2;
          }
          else
          {
            stringBuilder.append('%');
            stringBuilder.append('u');
            num4 = 4;
          }
          for (int index2 = (num4 - 1) * 4; index2 >= 0; index2 += -4)
          {
            int num5 = 15 & num3 >> index2;
            int num6 = num5 >= 10 ? 55 + num5 : 48 + num5;
            stringBuilder.append((char) num6);
          }
        }
      }
      return stringBuilder == null ? (object) str : (object) stringBuilder.toString();
    }

    [LineNumberTable(new byte[] {161, 95, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private object js_eval([In] Context obj0, [In] Scriptable obj1, [In] object[] obj2)
    {
      Scriptable topLevelScope = ScriptableObject.getTopLevelScope(obj1);
      return ScriptRuntime.evalSpecial(obj0, topLevelScope, (object) topLevelScope, obj2, "eval code", 1);
    }

    [LineNumberTable(new byte[] {160, 129, 101, 134, 105, 103, 194, 100, 134, 104, 104, 130, 166, 99, 106, 102, 101, 134, 169, 133, 152, 107, 141, 139, 136, 198, 99, 99, 99, 104, 159, 160, 162, 101, 101, 100, 194, 101, 98, 103, 130, 100, 226, 69, 104, 98, 103, 102, 226, 78, 101, 229, 69, 226, 19, 235, 113, 105, 132, 138, 120, 97})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static object js_parseFloat([In] object[] obj0)
    {
      if (obj0.Length < 1)
        return (object) ScriptRuntime.__\u003C\u003ENaNobj;
      string str1 = ScriptRuntime.toString(obj0[0]);
      int num1 = String.instancehelper_length(str1);
      for (int index = 0; index != num1; ++index)
      {
        int num2 = (int) String.instancehelper_charAt(str1, index);
        if (!ScriptRuntime.isStrWhiteSpaceChar(num2))
        {
          int num3 = index;
          if (num2 == 43 || num2 == 45)
          {
            ++num3;
            if (num3 == num1)
              return (object) ScriptRuntime.__\u003C\u003ENaNobj;
            num2 = (int) String.instancehelper_charAt(str1, num3);
          }
          if (num2 == 73)
            return num3 + 8 <= num1 && String.instancehelper_regionMatches(str1, num3, "Infinity", 0, 8) ? (object) ScriptRuntime.wrapNumber(String.instancehelper_charAt(str1, index) != '-' ? double.PositiveInfinity : double.NegativeInfinity) : (object) ScriptRuntime.__\u003C\u003ENaNobj;
          int num4 = -1;
          int num5 = -1;
          int num6 = 0;
          for (; num3 < num1; ++num3)
          {
            switch (String.instancehelper_charAt(str1, num3))
            {
              case '+':
              case '-':
                if (num5 == num3 - 1)
                {
                  if (num3 == num1 - 1)
                  {
                    num3 += -1;
                    goto label_28;
                  }
                  else
                    break;
                }
                else
                  goto label_28;
              case '.':
                if (num4 == -1)
                {
                  num4 = num3;
                  break;
                }
                goto label_28;
              case '0':
              case '1':
              case '2':
              case '3':
              case '4':
              case '5':
              case '6':
              case '7':
              case '8':
              case '9':
                if (num5 != -1)
                {
                  num6 = 1;
                  break;
                }
                break;
              case 'E':
              case 'e':
                if (num5 == -1 && num3 != num1 - 1)
                {
                  num5 = num3;
                  break;
                }
                goto label_28;
              default:
                goto label_28;
            }
          }
label_28:
          if (num5 != -1 && num6 == 0)
            num3 = num5;
          string str2 = String.instancehelper_substring(str1, index, num3);
          Double @double;
          try
          {
            @double = Double.valueOf(str2);
          }
          catch (NumberFormatException ex)
          {
            goto label_34;
          }
          return (object) @double;
label_34:
          return (object) ScriptRuntime.__\u003C\u003ENaNobj;
        }
      }
      return (object) ScriptRuntime.__\u003C\u003ENaNobj;
    }

    [LineNumberTable(new byte[] {160, 72, 104, 136, 103, 99, 134, 98, 163, 106, 105, 98, 102, 133, 112, 134, 98, 99, 100, 105, 102, 120, 108, 108, 166, 103, 99, 121, 108, 108, 99, 104, 108, 103, 114, 98, 230, 70, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static object js_parseInt([In] object[] obj0)
    {
      string str = ScriptRuntime.toString(obj0, 0);
      int num1 = ScriptRuntime.toInt32(obj0, 1);
      int num2 = String.instancehelper_length(str);
      if (num2 == 0)
        return (object) ScriptRuntime.__\u003C\u003ENaNobj;
      int num3 = 0;
      int num4 = 0;
      int num5;
      do
      {
        num5 = (int) String.instancehelper_charAt(str, num4);
        if (ScriptRuntime.isStrWhiteSpaceChar(num5))
          ++num4;
        else
          break;
      }
      while (num4 < num2);
      if (num5 == 43 || (num3 = num5 == 45 ? 1 : 0) != 0)
        ++num4;
      if (num1 == 0)
      {
        num1 = -1;
      }
      else
      {
        if (num1 < 2 || num1 > 36)
          return (object) ScriptRuntime.__\u003C\u003ENaNobj;
        if (num1 == 16 && num2 - num4 > 1 && String.instancehelper_charAt(str, num4) == '0')
        {
          switch (String.instancehelper_charAt(str, num4 + 1))
          {
            case 'X':
            case 'x':
              num4 += 2;
              break;
          }
        }
      }
      if (num1 == -1)
      {
        num1 = 10;
        if (num2 - num4 > 1 && String.instancehelper_charAt(str, num4) == '0')
        {
          int num6 = (int) String.instancehelper_charAt(str, num4 + 1);
          switch (num6)
          {
            case 88:
            case 120:
              num1 = 16;
              num4 += 2;
              break;
            default:
              if (48 <= num6 && num6 <= 57)
              {
                Context currentContext = Context.getCurrentContext();
                if (currentContext == null || currentContext.getLanguageVersion() < 150)
                {
                  num1 = 8;
                  ++num4;
                  break;
                }
                break;
              }
              break;
          }
        }
      }
      double number = ScriptRuntime.stringPrefixToNumber(str, num4, num1);
      return (object) ScriptRuntime.wrapNumber(num3 == 0 ? number : -number);
    }

    [LineNumberTable(new byte[] {161, 53, 104, 105, 103, 103, 103, 99, 107, 102, 102, 145, 104, 102, 136, 100, 134, 101, 99, 106, 45, 168, 101, 101, 196, 102, 102, 101, 138})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private object js_unescape([In] object[] obj0)
    {
      string str = ScriptRuntime.toString(obj0, 0);
      int num1 = String.instancehelper_indexOf(str, 37);
      if (num1 >= 0)
      {
        int num2 = String.instancehelper_length(str);
        char[] charArray = String.instancehelper_toCharArray(str);
        int index1 = num1;
        int index2 = num1;
        while (index2 != num2)
        {
          int num3 = (int) charArray[index2];
          ++index2;
          if (num3 == 37 && index2 != num2)
          {
            int num4;
            int num5;
            if (charArray[index2] == 'u')
            {
              num4 = index2 + 1;
              num5 = index2 + 5;
            }
            else
            {
              num4 = index2;
              num5 = index2 + 2;
            }
            if (num5 <= num2)
            {
              int accumulator = 0;
              for (int index3 = num4; index3 != num5; ++index3)
                accumulator = Kit.xDigitToInt((int) charArray[index3], accumulator);
              if (accumulator >= 0)
              {
                num3 = (int) (ushort) accumulator;
                index2 = num5;
              }
            }
          }
          charArray[index1] = (char) num3;
          ++index1;
        }
        str = String.newhelper(charArray, 0, index1);
      }
      return (object) str;
    }

    [LineNumberTable(new byte[] {158, 226, 68, 158, 130, 110, 130, 99, 146})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool encodeUnescaped([In] char obj0, [In] bool obj1)
    {
      int num1 = (int) obj0;
      int num2 = obj1 ? 1 : 0;
      if (65 <= num1 && num1 <= 90 || 97 <= num1 && num1 <= 122 || (48 <= num1 && num1 <= 57 || String.instancehelper_indexOf("-_.!~*'()", num1) >= 0))
        return true;
      return num2 != 0 && String.instancehelper_indexOf(";/?:@&=+$,#", num1) >= 0;
    }

    [LineNumberTable(new byte[] {162, 76, 106, 37})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static EcmaError uriError() => ScriptRuntime.constructError("URIError", ScriptRuntime.getMessage0("msg.bad.uri"));

    [LineNumberTable(new byte[] {162, 87, 162, 102, 170, 101, 98, 99, 100, 134, 98, 104, 110, 135, 148})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static int oneUcs4ToUtf8Char([In] byte[] obj0, [In] int obj1)
    {
      int num1 = 1;
      if ((obj1 & (int) sbyte.MinValue) == 0)
      {
        obj0[0] = (byte) obj1;
      }
      else
      {
        int num2 = (int) ((uint) obj1 >> 11);
        num1 = 2;
        while (num2 != 0)
        {
          num2 = (int) ((uint) num2 >> 5);
          ++num1;
        }
        int index = num1;
        while (true)
        {
          index += -1;
          if (index > 0)
          {
            obj0[index] = (byte) (obj1 & 63 | 128);
            obj1 = (int) ((uint) obj1 >> 6);
          }
          else
            break;
        }
        obj0[0] = (byte) (256 - (1 << 8 - num1) + obj1);
      }
      return num1;
    }

    [LineNumberTable(new byte[] {161, 192, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static char toHexChar([In] int obj0)
    {
      if (obj0 >> 4 != 0)
        Kit.codeBug();
      return obj0 >= 10 ? (char) (obj0 - 10 + 65) : (char) (obj0 + 48);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    private static int unHex([In] char obj0)
    {
      int num = (int) obj0;
      if (65 <= num && num <= 70)
        return num - 65 + 10;
      if (97 <= num && num <= 102)
        return num - 97 + 10;
      return 48 <= num && num <= 57 ? num - 48 : -1;
    }

    [LineNumberTable(new byte[] {158, 254, 164, 103, 103, 104, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static int unHex([In] char obj0, [In] char obj1)
    {
      int num1 = (int) obj0;
      int num2 = (int) obj1;
      int num3 = NativeGlobal.unHex((char) num1);
      int num4 = NativeGlobal.unHex((char) num2);
      return num3 >= 0 && num4 >= 0 ? num3 << 4 | num4 : -1;
    }

    [LineNumberTable(new byte[] {159, 138, 98, 134, 138, 98, 159, 34, 103, 133, 103, 133, 103, 133, 103, 133, 103, 133, 103, 130, 103, 130, 103, 130, 103, 130, 103, 130, 103, 98, 130, 103, 130, 103, 130, 139, 151, 99, 135, 231, 12, 233, 119, 177, 143, 6, 197, 241, 72, 124, 142, 133, 105, 108, 172, 112, 115, 184, 105, 112, 109, 99, 103, 135, 231, 42, 233, 88})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void init(Context cx, Scriptable scope, bool @sealed)
    {
      int num = @sealed ? 1 : 0;
      NativeGlobal nativeGlobal = new NativeGlobal();
      for (int id = 1; id <= 13; ++id)
      {
        int arity = 1;
        string name;
        switch (id - 1)
        {
          case 0:
            name = "decodeURI";
            break;
          case 1:
            name = "decodeURIComponent";
            break;
          case 2:
            name = "encodeURI";
            break;
          case 3:
            name = "encodeURIComponent";
            break;
          case 4:
            name = "escape";
            break;
          case 5:
            name = "eval";
            break;
          case 6:
            name = "isFinite";
            break;
          case 7:
            name = "isNaN";
            break;
          case 8:
            name = "isXMLName";
            break;
          case 9:
            name = "parseFloat";
            break;
          case 10:
            name = "parseInt";
            arity = 2;
            break;
          case 11:
            name = "unescape";
            break;
          case 12:
            name = "uneval";
            break;
          default:
            throw Throwable.__\u003Cunmap\u003E((Exception) Kit.codeBug());
        }
        IdFunctionObject.__\u003Cclinit\u003E();
        IdFunctionObject idFunctionObject = new IdFunctionObject((IdFunctionCall) nativeGlobal, NativeGlobal.FTAG, id, name, arity, scope);
        if (num != 0)
          idFunctionObject.sealObject();
        idFunctionObject.exportAsScopeProperty();
      }
      ScriptableObject.defineProperty(scope, "NaN", (object) ScriptRuntime.__\u003C\u003ENaNobj, 7);
      ScriptableObject.defineProperty(scope, "Infinity", (object) ScriptRuntime.wrapNumber(double.PositiveInfinity), 7);
      ScriptableObject.defineProperty(scope, "undefined", Undefined.__\u003C\u003Einstance, 7);
      TopLevel.NativeErrors[] nativeErrorsArray = TopLevel.NativeErrors.values();
      int length = nativeErrorsArray.Length;
      for (int index = 0; index < length; ++index)
      {
        TopLevel.NativeErrors nativeErrors = nativeErrorsArray[index];
        if (!object.ReferenceEquals((object) nativeErrors, (object) TopLevel.NativeErrors.Error))
        {
          string name = nativeErrors.name();
          ScriptableObject scriptableObject = (ScriptableObject) ScriptRuntime.newBuiltinObject(cx, scope, TopLevel.Builtins.__\u003C\u003EError, ScriptRuntime.__\u003C\u003EemptyArgs);
          scriptableObject.put("name", (Scriptable) scriptableObject, (object) name);
          scriptableObject.put("message", (Scriptable) scriptableObject, (object) "");
          IdFunctionObject.__\u003Cclinit\u003E();
          IdFunctionObject idFunctionObject = new IdFunctionObject((IdFunctionCall) nativeGlobal, NativeGlobal.FTAG, 14, name, 1, scope);
          idFunctionObject.markAsConstructor((Scriptable) scriptableObject);
          scriptableObject.put("constructor", (Scriptable) scriptableObject, (object) idFunctionObject);
          scriptableObject.setAttributes("constructor", 2);
          if (num != 0)
          {
            scriptableObject.sealObject();
            idFunctionObject.sealObject();
          }
          idFunctionObject.exportAsScopeProperty();
        }
      }
    }

    [LineNumberTable(new byte[] {68, 112, 103, 191, 38, 105, 235, 69, 105, 203, 169, 171, 102, 134, 234, 70, 102, 132, 108, 135, 199, 168, 168, 169, 146, 234, 70, 171})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object execIdCall(
      IdFunctionObject f,
      Context cx,
      Scriptable scope,
      Scriptable thisObj,
      object[] args)
    {
      int num = f.hasTag(NativeGlobal.FTAG) ? f.methodId() : throw Throwable.__\u003Cunmap\u003E((Exception) f.unknown());
      switch (num)
      {
        case 1:
        case 2:
          return (object) NativeGlobal.decode(ScriptRuntime.toString(args, 0), num == 1);
        case 3:
        case 4:
          return (object) NativeGlobal.encode(ScriptRuntime.toString(args, 0), num == 3);
        case 5:
          return this.js_escape(args);
        case 6:
          return this.js_eval(cx, scope, args);
        case 7:
          return args.Length < 1 ? (object) Boolean.FALSE : NativeNumber.isFinite(args[0]);
        case 8:
          return (object) ScriptRuntime.wrapBoolean(args.Length < 1 || Double.isNaN(ScriptRuntime.toNumber(args[0])));
        case 10:
          return NativeGlobal.js_parseFloat(args);
        case 11:
          return NativeGlobal.js_parseInt(args);
        case 12:
          return this.js_unescape(args);
        case 13:
          object obj = args.Length == 0 ? Undefined.__\u003C\u003Einstance : args[0];
          return (object) ScriptRuntime.uneval(cx, scope, obj);
        case 14:
          return (object) NativeError.make(cx, scope, f, args);
      }
    }

    [LineNumberTable(new byte[] {161, 100, 104, 103, 155})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static bool isEvalFunction([In] object obj0)
    {
      if (!(obj0 is IdFunctionObject))
        return false;
      IdFunctionObject idFunctionObject = (IdFunctionObject) obj0;
      return idFunctionObject.hasTag(NativeGlobal.FTAG) && idFunctionObject.methodId() == 6;
    }

    [Obsolete]
    [LineNumberTable(486)]
    [Deprecated(new object[] {64, "Ljava/lang/Deprecated;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static EcmaError constructError(
      Context cx,
      string error,
      string message,
      Scriptable scope)
    {
      return ScriptRuntime.constructError(error, message);
    }

    [Obsolete]
    [LineNumberTable(503)]
    [Deprecated(new object[] {64, "Ljava/lang/Deprecated;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static EcmaError constructError(
      Context cx,
      string error,
      string message,
      Scriptable scope,
      string sourceName,
      int lineNumber,
      int columnNumber,
      string lineSource)
    {
      return ScriptRuntime.constructError(error, message, sourceName, lineNumber, lineSource, columnNumber);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    static NativeGlobal()
    {
      if (ByteCodeHelper.isAlreadyInited("rhino.NativeGlobal"))
        return;
      NativeGlobal.FTAG = (object) "Global";
    }
  }
}
