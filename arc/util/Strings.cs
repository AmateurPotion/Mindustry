// Decompiled with JetBrains decompiler
// Type: arc.util.Strings
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.graphics;
using arc.math;
using IKVM.Attributes;
using IKVM.Runtime;
using java.io;
using java.lang;
using java.net;
using java.nio.charset;
using java.util;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.util
{
  public class Strings : Object
  {
    private static StringBuilder tmp1;
    private static StringBuilder tmp2;
    internal static Charset __\u003C\u003Eutf8;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {7, 102, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static string getStackTrace(Exception e)
    {
      StringWriter stringWriter = new StringWriter();
      Throwable.instancehelper_printStackTrace(e, new PrintWriter((Writer) stringWriter));
      return stringWriter.toString();
    }

    [LineNumberTable(64)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static string neatError(Exception e) => Strings.neatError(e, true);

    [LineNumberTable(new byte[] {159, 181, 103, 104, 104, 104, 169})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static string getFinalMessage(Exception e)
    {
      string message = Throwable.instancehelper_getMessage(e);
      while (Throwable.instancehelper_getCause(e) != null)
      {
        e = Throwable.instancehelper_getCause(e);
        if (Throwable.instancehelper_getMessage(e) != null)
          message = Throwable.instancehelper_getMessage(e);
      }
      return message;
    }

    [Signature("(Ljava/lang/Throwable;)Larc/struct/Seq<Ljava/lang/Throwable;>;")]
    [LineNumberTable(new byte[] {159, 167, 102, 99, 103, 138})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Seq getCauses(Exception e)
    {
      Seq seq = new Seq();
      for (; e != null; e = Throwable.instancehelper_getCause(e))
        seq.add((object) e);
      return seq;
    }

    [LineNumberTable(new byte[] {159, 117, 170, 152, 99, 120, 185, 105, 127, 22, 101, 139, 138, 134, 98, 106, 134, 133})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static string stripColors(CharSequence str)
    {
      object obj1 = (object) str.__\u003Cref\u003E;
      object obj2 = obj1;
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj2;
      StringBuilder stringBuilder = new StringBuilder(((CharSequence) ref charSequence).length());
      int num1 = 0;
      while (true)
      {
        int num2 = num1;
        object obj3 = obj1;
        charSequence.__\u003Cref\u003E = (__Null) obj3;
        int num3 = ((CharSequence) ref charSequence).length();
        if (num2 < num3)
        {
          object obj4 = obj1;
          int num4 = num1;
          object obj5 = obj4;
          charSequence.__\u003Cref\u003E = (__Null) obj5;
          int num5 = (int) ((CharSequence) ref charSequence).charAt(num4);
          if (num5 == 91)
          {
            object obj6 = obj1;
            int num6 = num1 + 1;
            object obj7 = obj1;
            charSequence.__\u003Cref\u003E = (__Null) obj7;
            int num7 = ((CharSequence) ref charSequence).length();
            int num8 = num6;
            object obj8 = obj6;
            charSequence.__\u003Cref\u003E = (__Null) obj8;
            int colorMarkup = Strings.parseColorMarkup(charSequence, num8, num7);
            if (colorMarkup >= 0)
            {
              num1 += colorMarkup + 2;
            }
            else
            {
              stringBuilder.append((char) num5);
              ++num1;
            }
          }
          else
          {
            stringBuilder.append((char) num5);
            ++num1;
          }
        }
        else
          break;
      }
      return stringBuilder.toString();
    }

    [LineNumberTable(new byte[] {160, 198, 140, 110, 104, 106, 110, 125, 143, 232, 57, 233, 75})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static string capitalize(string s)
    {
      StringBuilder stringBuilder = new StringBuilder(String.instancehelper_length(s));
      for (int index = 0; index < String.instancehelper_length(s); ++index)
      {
        int num = (int) String.instancehelper_charAt(s, index);
        switch (num)
        {
          case 45:
          case 95:
            stringBuilder.append(" ");
            break;
          default:
            if (index == 0 || String.instancehelper_charAt(s, index - 1) == '_' || String.instancehelper_charAt(s, index - 1) == '-')
            {
              stringBuilder.append(Character.toUpperCase((char) num));
              break;
            }
            stringBuilder.append((char) num);
            break;
        }
      }
      return stringBuilder.toString();
    }

    [LineNumberTable(new byte[] {0, 104, 138})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Exception getFinalCause(Exception e)
    {
      while (Throwable.instancehelper_getCause(e) != null)
        e = Throwable.instancehelper_getCause(e);
      return e;
    }

    [LineNumberTable(414)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static long parseLong(string s, long defaultValue) => Strings.parseLong(s, 10, defaultValue);

    [LineNumberTable(373)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int parseInt(string s, int defaultValue) => Strings.parseInt(s, 10, defaultValue);

    [LineNumberTable(556)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static string @fixed(float d, int decimalPlaces) => Strings.fixedBuilder(d, decimalPlaces).toString();

    [LineNumberTable(new byte[] {161, 181, 127, 41})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static string autoFixed(float value, int max)
    {
      int num = (double) Math.abs((float) ByteCodeHelper.f2i(value) - value) > 9.99999974737875E-05 ? ((double) Math.abs((float) ByteCodeHelper.f2i(value * 10f) - value * 10f) > 9.99999974737875E-05 ? 2 : 1) : 0;
      return Strings.@fixed(value, Math.min(num, max));
    }

    [LineNumberTable(new byte[] {161, 145, 104, 122, 97})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool canParseFloat(string s)
    {
      int num1;
      try
      {
        double num2 = (double) Float.parseFloat(s);
        num1 = 1;
      }
      catch (Exception ex)
      {
        if (ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 2) == null)
          throw;
        else
          goto label_4;
      }
      return num1 != 0;
label_4:
      return false;
    }

    [LineNumberTable(new byte[] {160, 98, 104, 113, 98, 107, 104, 106, 144, 232, 59, 230, 73, 167})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static string format(string text, params object[] args)
    {
      if (args.Length <= 0)
        return text;
      StringBuilder stringBuilder1 = new StringBuilder(String.instancehelper_length(text) + args.Length * 2);
      int num1 = 0;
      for (int index1 = 0; index1 < String.instancehelper_length(text); ++index1)
      {
        int num2 = (int) String.instancehelper_charAt(text, index1);
        if (num2 == 64 && num1 < args.Length)
        {
          StringBuilder stringBuilder2 = stringBuilder1;
          object[] objArray = args;
          int index2 = num1;
          ++num1;
          object obj = objArray[index2];
          stringBuilder2.append(obj);
        }
        else
          stringBuilder1.append((char) num2);
      }
      return stringBuilder1.toString();
    }

    [LineNumberTable(364)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool canParseInt(string s) => Strings.parseInt(s) != int.MinValue;

    [LineNumberTable(510)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int parseInt(string s) => Strings.parseInt(s, int.MinValue);

    [LineNumberTable(new byte[] {160, 254, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool canParsePositiveInt(string s) => Strings.parseInt(s) >= 0;

    [LineNumberTable(new byte[] {161, 154, 127, 12, 97})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool canParsePositiveFloat(string s)
    {
      int num;
      try
      {
        num = (double) Float.parseFloat(s) <= 0.0 ? 0 : 1;
      }
      catch (Exception ex)
      {
        if (ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 2) == null)
          throw;
        else
          goto label_4;
      }
      return num != 0;
label_4:
      return false;
    }

    [LineNumberTable(539)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static float parseFloat(string s) => Strings.parseFloat(s, float.Epsilon);

    [LineNumberTable(273)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static string animated(float time, int length, float scale, string replacement)
    {
      int num1 = ByteCodeHelper.f2i(time / scale);
      int num2 = length;
      string str = String.newhelper(new char[Math.abs(num2 != -1 ? num1 % num2 : 0)]);
      object obj1 = (object) replacement;
      object obj2 = (object) "\0";
      CharSequence charSequence1;
      charSequence1.__\u003Cref\u003E = (__Null) obj2;
      CharSequence charSequence2 = charSequence1;
      object obj3 = obj1;
      charSequence1.__\u003Cref\u003E = (__Null) obj3;
      CharSequence charSequence3 = charSequence1;
      return String.instancehelper_replace(str, charSequence2, charSequence3);
    }

    [LineNumberTable(new byte[] {161, 220, 104, 134, 107, 136, 112, 117, 116, 117, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static string formatMillis(long val)
    {
      StringBuilder stringBuilder = new StringBuilder(20);
      string str = "";
      if (val < 0L)
        str = "-";
      val = Math.abs(val);
      Strings.append(stringBuilder, str, 0, val / 3600000L);
      long num1 = val;
      long num2 = 3600000;
      val = num2 != -1L ? num1 % num2 : 0L;
      Strings.append(stringBuilder, ":", 2, val / 60000L);
      long num3 = val;
      long num4 = 60000;
      val = num4 != -1L ? num3 % num4 : 0L;
      Strings.append(stringBuilder, ":", 2, val / 1000L);
      return stringBuilder.toString();
    }

    [LineNumberTable(new byte[] {161, 51, 98, 102, 106, 100, 131, 105, 102, 102, 98, 108, 102, 163, 135, 228, 69, 104, 115, 101, 163, 103, 105, 227, 56, 234, 76})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static long parseLong(string s, int radix, int start, int end, long defaultValue)
    {
      int num1 = 0;
      int num2 = start;
      int num3 = end - start;
      long num4 = -9223372036854775807;
      if (num3 <= 0)
        return defaultValue;
      int num5 = (int) String.instancehelper_charAt(s, num2);
      if (num5 < 48)
      {
        switch (num5)
        {
          case 43:
            if (num3 == 1)
              return defaultValue;
            ++num2;
            break;
          case 45:
            num1 = 1;
            num4 = long.MinValue;
            goto case 43;
          default:
            return defaultValue;
        }
      }
      long num6 = 0;
      while (num2 < end)
      {
        string str = s;
        int num7 = num2;
        ++num2;
        int num8 = Character.digit(String.instancehelper_charAt(str, num7), radix);
        if (num8 < 0)
          return defaultValue;
        long num9 = num6 * (long) radix;
        if (num9 < num4 + (long) num8)
          return defaultValue;
        num6 = num9 - (long) num8;
      }
      return num1 != 0 ? num6 : -num6;
    }

    [LineNumberTable(new byte[] {161, 91, 103, 134, 100, 115, 111, 132, 102, 162, 102, 104, 106, 106, 240, 61, 232, 70, 144, 107, 120, 105, 157, 127, 0, 112, 120, 105, 223, 11, 104, 118, 112, 120, 112, 213, 117})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static double parseDouble(string value, double defaultValue)
    {
      int num1 = String.instancehelper_length(value);
      if (num1 == 0)
        return defaultValue;
      int start = 0;
      int end1 = num1;
      int num2 = (int) String.instancehelper_charAt(value, num1 - 1);
      int num3 = (int) String.instancehelper_charAt(value, 0);
      if (num2 == 70 || num2 == 102 || num2 == 46)
        end1 += -1;
      if (num3 == 43)
        start = 1;
      int end2 = -1;
      int end3 = -1;
      for (int index = start; index < end1; ++index)
      {
        int num4 = (int) String.instancehelper_charAt(value, index);
        if (num4 == 46)
          end2 = index;
        if (num4 == 101 || num4 == 69)
          end3 = index;
      }
      if (end2 != -1 && end2 < end1)
      {
        if (end2 == 1 && num3 == 45)
        {
          long num4 = Strings.parseLong(value, 10, end2 + 1, end1, long.MinValue);
          return num4 < 0L ? defaultValue : (double) -num4 / Math.pow(10.0, (double) (end1 - end2 - 1));
        }
        long num5 = start != end2 ? Strings.parseLong(value, 10, start, end2, long.MinValue) : 0L;
        if (num5 == long.MinValue)
          return defaultValue;
        long num6 = Strings.parseLong(value, 10, end2 + 1, end1, long.MinValue);
        return num6 < 0L ? defaultValue : (double) num5 + Math.copySign((double) num6 / Math.pow(10.0, (double) (end1 - end2 - 1)), (double) num5);
      }
      if (end3 != -1)
      {
        long num4 = Strings.parseLong(value, 10, start, end3, long.MinValue);
        if (num4 == long.MinValue)
          return defaultValue;
        long num5 = Strings.parseLong(value, 10, end3 + 1, end1, long.MinValue);
        return num5 == long.MinValue ? defaultValue : (double) ((float) num4 * Mathf.pow(10f, (float) num5));
      }
      long num7 = Strings.parseLong(value, 10, start, end1, long.MinValue);
      return num7 == long.MinValue ? defaultValue : (double) num7;
    }

    [LineNumberTable(new byte[] {160, 216, 140, 107, 136, 108, 169, 232, 57, 230, 74})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static string insertSpaces(string s)
    {
      StringBuilder stringBuilder = new StringBuilder(String.instancehelper_length(s));
      for (int index = 0; index < String.instancehelper_length(s); ++index)
      {
        int num = (int) String.instancehelper_charAt(s, index);
        if (index > 0 && Character.isUpperCase((char) num))
          stringBuilder.append(' ');
        stringBuilder.append((char) num);
      }
      return stringBuilder.toString();
    }

    [LineNumberTable(new byte[] {160, 90, 127, 2, 129})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static string encode(string str)
    {
      string str1;
      UnsupportedEncodingException encodingException1;
      try
      {
        str1 = URLEncoder.encode(str, "UTF-8");
      }
      catch (UnsupportedEncodingException ex)
      {
        encodingException1 = (UnsupportedEncodingException) ByteCodeHelper.MapException<UnsupportedEncodingException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
        goto label_3;
      }
      return str1;
label_3:
      UnsupportedEncodingException encodingException2 = encodingException1;
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new RuntimeException((Exception) encodingException2);
    }

    [LineNumberTable(new byte[] {159, 138, 108, 98, 122, 63, 1, 168})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int count(CharSequence s, char c)
    {
      object obj1 = (object) s.__\u003Cref\u003E;
      int num1 = (int) c;
      int num2 = 0;
      int num3 = 0;
      while (true)
      {
        int num4 = num3;
        object obj2 = obj1;
        CharSequence charSequence;
        charSequence.__\u003Cref\u003E = (__Null) obj2;
        int num5 = ((CharSequence) ref charSequence).length();
        if (num4 < num5)
        {
          object obj3 = obj1;
          int num6 = num3;
          object obj4 = obj3;
          charSequence.__\u003Cref\u003E = (__Null) obj4;
          if ((int) ((CharSequence) ref charSequence).charAt(num6) == num1)
            ++num2;
          ++num3;
        }
        else
          break;
      }
      return num2;
    }

    [LineNumberTable(new byte[] {161, 174, 127, 1, 97})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static float parseFloat(string s, float defaultValue)
    {
      float num;
      try
      {
        num = Float.parseFloat(s);
      }
      catch (Exception ex)
      {
        if (ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 2) == null)
          throw;
        else
          goto label_4;
      }
      return num;
label_4:
      return defaultValue;
    }

    [LineNumberTable(new byte[] {159, 125, 98, 134, 102, 127, 46, 108, 180, 115, 104, 108, 191, 2, 102, 127, 1, 127, 52, 140, 105, 255, 41, 59, 235, 73, 140, 104, 165})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static string neatError(Exception e, bool stacktrace)
    {
      int num = stacktrace ? 1 : 0;
      StringBuilder stringBuilder = new StringBuilder();
      for (; e != null; e = Throwable.instancehelper_getCause(e))
      {
        string str1 = String.instancehelper_substring(Object.instancehelper_getClass((object) e).toString(), String.instancehelper_length("class "));
        object obj1 = (object) "";
        object obj2 = (object) "Exception";
        CharSequence charSequence1;
        charSequence1.__\u003Cref\u003E = (__Null) obj2;
        CharSequence charSequence2 = charSequence1;
        object obj3 = obj1;
        charSequence1.__\u003Cref\u003E = (__Null) obj3;
        CharSequence charSequence3 = charSequence1;
        string str2 = String.instancehelper_replace(str1, charSequence2, charSequence3);
        if (String.instancehelper_indexOf(str2, 46) != -1)
          str2 = String.instancehelper_substring(str2, String.instancehelper_lastIndexOf(str2, 46) + 1);
        stringBuilder.append("> ").append(str2);
        if (Throwable.instancehelper_getMessage(e) != null)
        {
          stringBuilder.append(": ");
          stringBuilder.append("'").append(Throwable.instancehelper_getMessage(e)).append("'");
        }
        if (num != 0)
        {
          StackTraceElement[] stackTrace = Throwable.instancehelper_getStackTrace(e);
          int length = stackTrace.Length;
          for (int index = 0; index < length; ++index)
          {
            StackTraceElement stackTraceElement = stackTrace[index];
            string className1 = stackTraceElement.getClassName();
            object obj4 = (object) "MethodAccessor";
            charSequence1.__\u003Cref\u003E = (__Null) obj4;
            CharSequence charSequence4 = charSequence1;
            if (!String.instancehelper_contains(className1, charSequence4) && !String.instancehelper_equals(String.instancehelper_substring(stackTraceElement.getClassName(), String.instancehelper_lastIndexOf(stackTraceElement.getClassName(), ".") + 1), (object) "Method"))
            {
              stringBuilder.append("\n");
              string className2 = stackTraceElement.getClassName();
              stringBuilder.append(String.instancehelper_substring(className2, String.instancehelper_lastIndexOf(className2, ".") + 1)).append(".").append(stackTraceElement.getMethodName()).append(": ").append(stackTraceElement.getLineNumber());
            }
          }
        }
        stringBuilder.append("\n");
      }
      return stringBuilder.toString();
    }

    [LineNumberTable(new byte[] {159, 107, 106, 102, 191, 25, 99, 109, 119, 102, 119, 103, 114, 38, 136, 169, 133, 108, 111, 108, 111, 108, 237, 47, 235, 85, 130, 163, 162, 109, 119, 104, 127, 27, 134, 229, 58, 235, 72})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static int parseColorMarkup([In] CharSequence obj0, [In] int obj1, [In] int obj2)
    {
      object obj3 = (object) obj0.__\u003Cref\u003E;
      if (obj1 >= obj2)
        return -1;
      object obj4 = obj3;
      int num1 = obj1;
      object obj5 = obj4;
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj5;
      switch (((CharSequence) ref charSequence).charAt(num1))
      {
        case '#':
          int num2 = 0;
          for (int index1 = obj1 + 1; index1 < obj2; ++index1)
          {
            object obj6 = obj3;
            int num3 = index1;
            object obj7 = obj6;
            charSequence.__\u003Cref\u003E = (__Null) obj7;
            int num4 = (int) ((CharSequence) ref charSequence).charAt(num3);
            if (num4 == 93)
            {
              if (index1 >= obj1 + 2 && index1 <= obj1 + 9)
              {
                if (index1 - obj1 <= 7)
                {
                  int num5 = 0;
                  for (int index2 = 9 - (index1 - obj1); num5 < index2; ++num5)
                    num2 <<= 4;
                  int num6 = num2 | (int) byte.MaxValue;
                }
                return index1 - obj1;
              }
              break;
            }
            if (num4 >= 48 && num4 <= 57)
              num2 = num2 * 16 + (num4 - 48);
            else if (num4 >= 97 && num4 <= 102)
              num2 = num2 * 16 + (num4 - 87);
            else if (num4 >= 65 && num4 <= 70)
              num2 = num2 * 16 + (num4 - 55);
            else
              break;
          }
          return -1;
        case '[':
          return -2;
        case ']':
          return 0;
        default:
          for (int index = obj1 + 1; index < obj2; ++index)
          {
            object obj6 = obj3;
            int num3 = index;
            object obj7 = obj6;
            charSequence.__\u003Cref\u003E = (__Null) obj7;
            if (((CharSequence) ref charSequence).charAt(num3) == ']')
            {
              object obj8 = obj3;
              int num4 = obj1;
              int num5 = index;
              int num6 = num4;
              object obj9 = obj8;
              charSequence.__\u003Cref\u003E = (__Null) obj9;
              object obj10 = (object) ((CharSequence) ref charSequence).subSequence(num6, num5).__\u003Cref\u003E;
              charSequence.__\u003Cref\u003E = (__Null) obj10;
              return Colors.get(((CharSequence) ref charSequence).toString()) == null ? -1 : index - obj1;
            }
          }
          return -1;
      }
    }

    [LineNumberTable(new byte[] {161, 7, 98, 111, 100, 130, 105, 102, 102, 98, 104, 102, 162, 134, 196, 103, 115, 101, 162, 102, 104, 226, 56, 233, 76})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int parseInt(string s, int radix, int defaultValue)
    {
      int num1 = 0;
      int num2 = 0;
      int num3 = String.instancehelper_length(s);
      int num4 = -2147483647;
      if (num3 <= 0)
        return defaultValue;
      int num5 = (int) String.instancehelper_charAt(s, 0);
      if (num5 < 48)
      {
        switch (num5)
        {
          case 43:
            if (num3 == 1)
              return defaultValue;
            ++num2;
            break;
          case 45:
            num1 = 1;
            num4 = int.MinValue;
            goto case 43;
          default:
            return defaultValue;
        }
      }
      int num6 = 0;
      while (num2 < num3)
      {
        string str = s;
        int num7 = num2;
        ++num2;
        int num8 = Character.digit(String.instancehelper_charAt(str, num7), radix);
        if (num8 < 0)
          return defaultValue;
        int num9 = num6 * radix;
        if (num9 < num4 + num8)
          return defaultValue;
        num6 = num9 - num8;
      }
      return num1 != 0 ? num6 : -num6;
    }

    [LineNumberTable(417)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static long parseLong(string s, int radix, long defaultValue) => Strings.parseLong(s, radix, 0, String.instancehelper_length(s), defaultValue);

    [LineNumberTable(new byte[] {161, 190, 104, 159, 6, 102, 107, 159, 18, 103, 100, 102, 107, 99, 98, 135, 127, 5, 108, 159, 12, 140, 104, 142, 154})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static StringBuilder fixedBuilder(float d, int decimalPlaces)
    {
      if (decimalPlaces < 0 || decimalPlaces > 8)
      {
        string str = new StringBuilder().append("Unsupported number of decimal places: ").append(decimalPlaces).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException(str);
      }
      StringBuilder tmp2 = Strings.tmp2;
      Strings.tmp2.setLength(0);
      Strings.tmp2.append(ByteCodeHelper.d2i((double) d * Math.pow(10.0, (double) decimalPlaces) + 9.99999997475243E-07));
      int num1 = tmp2.length() - decimalPlaces;
      StringBuilder tmp1 = Strings.tmp1;
      Strings.tmp1.setLength(0);
      if (decimalPlaces == 0)
        return tmp2;
      if (num1 > 0)
      {
        StringBuilder stringBuilder1 = tmp1;
        StringBuilder stringBuilder2 = tmp2;
        int num2 = num1;
        int num3 = 0;
        object obj1 = (object) stringBuilder2;
        CharSequence charSequence1;
        charSequence1.__\u003Cref\u003E = (__Null) obj1;
        CharSequence charSequence2 = charSequence1;
        int num4 = num3;
        int num5 = num2;
        stringBuilder1.append(charSequence2, num4, num5);
        tmp1.append(".");
        StringBuilder stringBuilder3 = tmp1;
        StringBuilder stringBuilder4 = tmp2;
        int num6 = num1;
        int num7 = tmp2.length();
        int num8 = num6;
        object obj2 = (object) stringBuilder4;
        charSequence1.__\u003Cref\u003E = (__Null) obj2;
        CharSequence charSequence3 = charSequence1;
        int num9 = num8;
        int num10 = num7;
        stringBuilder3.append(charSequence3, num9, num10);
      }
      else
      {
        tmp1.append("0.");
        while (true)
        {
          int num2 = num1;
          ++num1;
          if (num2 < 0)
            tmp1.append("0");
          else
            break;
        }
        StringBuilder stringBuilder = tmp1;
        object obj = (object) tmp2;
        CharSequence charSequence1;
        charSequence1.__\u003Cref\u003E = (__Null) obj;
        CharSequence charSequence2 = charSequence1;
        stringBuilder.append(charSequence2);
      }
      return tmp1;
    }

    [LineNumberTable(new byte[] {161, 235, 104, 100, 100, 120, 149, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void append([In] StringBuilder obj0, [In] string obj1, [In] int obj2, [In] long obj3)
    {
      obj0.append(obj1);
      if (obj2 > 1)
      {
        int num = obj2 - 1;
        for (long index = obj3; index > 9L && num > 0; index /= 10L)
          num += -1;
        for (int index = 0; index < num; ++index)
          obj0.append('0');
      }
      obj0.append(obj3);
    }

    [LineNumberTable(11)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Strings()
    {
    }

    [LineNumberTable(new byte[] {159, 176, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static string getSimpleMessage(Exception e)
    {
      Exception finalCause = Strings.getFinalCause(e);
      return Throwable.instancehelper_getMessage(finalCause) == null ? Object.instancehelper_getClass((object) finalCause).getSimpleName() : new StringBuilder().append(Object.instancehelper_getClass((object) finalCause).getSimpleName()).append(": ").append(Throwable.instancehelper_getMessage(finalCause)).toString();
    }

    [LineNumberTable(new byte[] {159, 110, 106, 152, 120, 121, 116, 234, 61, 235, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static string stripGlyphs(CharSequence str)
    {
      object obj1 = (object) str.__\u003Cref\u003E;
      object obj2 = obj1;
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj2;
      StringBuilder stringBuilder = new StringBuilder(((CharSequence) ref charSequence).length());
      int num1 = 0;
      while (true)
      {
        int num2 = num1;
        object obj3 = obj1;
        charSequence.__\u003Cref\u003E = (__Null) obj3;
        int num3 = ((CharSequence) ref charSequence).length();
        if (num2 < num3)
        {
          object obj4 = obj1;
          int num4 = num1;
          object obj5 = obj4;
          charSequence.__\u003Cref\u003E = (__Null) obj5;
          int num5 = (int) ((CharSequence) ref charSequence).charAt(num4);
          if (num5 < 57344 || num5 > 63743)
            stringBuilder.append(num5);
          ++num1;
        }
        else
          break;
      }
      return stringBuilder.toString();
    }

    [LineNumberTable(new byte[] {160, 73, 98, 130, 132, 137, 100, 100, 171})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int count(string str, string substring)
    {
      int num1 = 0;
      int num2 = 0;
      while (num1 != -1)
      {
        num1 = String.instancehelper_indexOf(str, substring, num1);
        if (num1 != -1)
        {
          ++num2;
          num1 += String.instancehelper_length(substring);
        }
      }
      return num2;
    }

    [LineNumberTable(new byte[] {160, 117, 102, 112, 105, 8, 198, 115})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static string join(string separator, params string[] strings)
    {
      StringBuilder stringBuilder = new StringBuilder();
      string[] strArray = strings;
      int length = strArray.Length;
      for (int index = 0; index < length; ++index)
      {
        string str = strArray[index];
        stringBuilder.append(str);
        stringBuilder.append(separator);
      }
      stringBuilder.setLength(stringBuilder.length() - String.instancehelper_length(separator));
      return stringBuilder.toString();
    }

    [Signature("(Ljava/lang/String;Ljava/lang/Iterable<Ljava/lang/String;>;)Ljava/lang/String;")]
    [LineNumberTable(new byte[] {160, 127, 102, 123, 104, 104, 98, 115})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static string join(string separator, Iterable strings)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Iterator iterator = strings.iterator();
      while (iterator.hasNext())
      {
        string str = (string) iterator.next();
        stringBuilder.append(str);
        stringBuilder.append(separator);
      }
      stringBuilder.setLength(stringBuilder.length() - String.instancehelper_length(separator));
      return stringBuilder.toString();
    }

    [LineNumberTable(new byte[] {160, 138, 159, 19, 110, 112, 99, 109, 100, 137, 111, 63, 5, 245, 58, 43, 233, 79})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int levenshtein(string x, string y)
    {
      int num1 = String.instancehelper_length(x) + 1;
      int num2 = String.instancehelper_length(y) + 1;
      int[] numArray1 = new int[2];
      int num3 = num2;
      numArray1[1] = num3;
      int num4 = num1;
      numArray1[0] = num4;
      // ISSUE: type reference
      int[][] numArray2 = (int[][]) ByteCodeHelper.multianewarray(__typeref (int[][]), numArray1);
      for (int index1 = 0; index1 <= String.instancehelper_length(x); ++index1)
      {
        for (int index2 = 0; index2 <= String.instancehelper_length(y); ++index2)
          numArray2[index1][index2] = index1 != 0 ? (index2 != 0 ? Math.min(Math.min(numArray2[index1 - 1][index2 - 1] + ((int) String.instancehelper_charAt(x, index1 - 1) != (int) String.instancehelper_charAt(y, index2 - 1) ? 1 : 0), numArray2[index1 - 1][index2] + 1), numArray2[index1][index2 - 1] + 1) : index1) : index2;
      }
      return numArray2[String.instancehelper_length(x)][String.instancehelper_length(y)];
    }

    [LineNumberTable(new byte[] {160, 163, 140, 110, 104, 106, 125, 143, 232, 58, 233, 75})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static string kebabToCamel(string s)
    {
      StringBuilder stringBuilder = new StringBuilder(String.instancehelper_length(s));
      for (int index = 0; index < String.instancehelper_length(s); ++index)
      {
        int num = (int) String.instancehelper_charAt(s, index);
        switch (num)
        {
          case 45:
          case 95:
            continue;
          default:
            if (index != 0 && (String.instancehelper_charAt(s, index - 1) == '_' || String.instancehelper_charAt(s, index - 1) == '-'))
            {
              stringBuilder.append(Character.toUpperCase((char) num));
              continue;
            }
            stringBuilder.append((char) num);
            continue;
        }
      }
      return stringBuilder.toString();
    }

    [LineNumberTable(new byte[] {160, 180, 142, 107, 104, 114, 169, 237, 58, 230, 74})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static string camelToKebab(string s)
    {
      StringBuilder stringBuilder = new StringBuilder(String.instancehelper_length(s) + 1);
      for (int index = 0; index < String.instancehelper_length(s); ++index)
      {
        int num = (int) String.instancehelper_charAt(s, index);
        if (index > 0 && Character.isUpperCase(String.instancehelper_charAt(s, index)))
          stringBuilder.append('-');
        stringBuilder.append(Character.toLowerCase((char) num));
      }
      return stringBuilder.toString();
    }

    [LineNumberTable(new byte[] {160, 234, 140, 107, 104, 99, 111, 101, 232, 59, 230, 74})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static string camelize(string s)
    {
      StringBuilder stringBuilder = new StringBuilder(String.instancehelper_length(s));
      for (int index = 0; index < String.instancehelper_length(s); ++index)
      {
        int num = (int) String.instancehelper_charAt(s, index);
        if (index == 0)
          stringBuilder.append(Character.toLowerCase((char) num));
        else if (num != 32)
          stringBuilder.append((char) num);
      }
      return stringBuilder.toString();
    }

    [LineNumberTable(new byte[] {161, 162, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int parsePositiveInt(string s)
    {
      int num = Strings.parseInt(s, int.MinValue);
      return num <= 0 ? int.MinValue : num;
    }

    [LineNumberTable(new byte[] {161, 246, 110, 130, 105, 102, 108, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static StringBuilder replace(
      StringBuilder builder,
      string find,
      string replace)
    {
      int num1 = String.instancehelper_length(find);
      int num2 = String.instancehelper_length(replace);
      int num3 = 0;
      while (true)
      {
        int num4 = builder.indexOf(find, num3);
        if (num4 != -1)
        {
          builder.replace(num4, num4 + num1, replace);
          num3 = num4 + num2;
        }
        else
          break;
      }
      return builder;
    }

    [LineNumberTable(new byte[] {158, 241, 98, 103, 162, 107, 108, 134, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static StringBuilder replace(
      StringBuilder builder,
      char find,
      string replace)
    {
      int num1 = (int) find;
      int num2 = String.instancehelper_length(replace);
      int num3 = 0;
      while (num3 != builder.length())
      {
        if ((int) builder.charAt(num3) != num1)
        {
          ++num3;
        }
        else
        {
          builder.replace(num3, num3 + 1, replace);
          num3 += num2;
        }
      }
      return builder;
    }

    [LineNumberTable(new byte[] {159, 139, 77, 148})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static Strings()
    {
      if (ByteCodeHelper.isAlreadyInited("arc.util.Strings"))
        return;
      Strings.tmp1 = new StringBuilder();
      Strings.tmp2 = new StringBuilder();
      Strings.__\u003C\u003Eutf8 = Charset.forName("UTF-8");
    }

    [Modifiers]
    public static Charset utf8
    {
      [HideFromJava] get => Strings.__\u003C\u003Eutf8;
    }
  }
}
