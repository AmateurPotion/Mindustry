// Decompiled with JetBrains decompiler
// Type: rhino.NativeDate
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.text;
using java.util;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace rhino
{
  internal sealed class NativeDate : IdScriptableObject
  {
    [Modifiers]
    private static object DATE_TAG;
    private const string js_NaN_date_str = "Invalid Date";
    private const double HalfTimeDomain = 8.64E+15;
    private const double HoursPerDay = 24.0;
    private const double MinutesPerHour = 60.0;
    private const double SecondsPerMinute = 60.0;
    private const double msPerSecond = 1000.0;
    private const double MinutesPerDay = 1440.0;
    private const double SecondsPerDay = 86400.0;
    private const double SecondsPerHour = 3600.0;
    private const double msPerDay = 86400000.0;
    private const double msPerHour = 3600000.0;
    private const double msPerMinute = 60000.0;
    private const int MAXARGS = 7;
    private const int ConstructorId_now = -3;
    private const int ConstructorId_parse = -2;
    private const int ConstructorId_UTC = -1;
    private const int Id_constructor = 1;
    private const int Id_toString = 2;
    private const int Id_toTimeString = 3;
    private const int Id_toDateString = 4;
    private const int Id_toLocaleString = 5;
    private const int Id_toLocaleTimeString = 6;
    private const int Id_toLocaleDateString = 7;
    private const int Id_toUTCString = 8;
    private const int Id_toSource = 9;
    private const int Id_valueOf = 10;
    private const int Id_getTime = 11;
    private const int Id_getYear = 12;
    private const int Id_getFullYear = 13;
    private const int Id_getUTCFullYear = 14;
    private const int Id_getMonth = 15;
    private const int Id_getUTCMonth = 16;
    private const int Id_getDate = 17;
    private const int Id_getUTCDate = 18;
    private const int Id_getDay = 19;
    private const int Id_getUTCDay = 20;
    private const int Id_getHours = 21;
    private const int Id_getUTCHours = 22;
    private const int Id_getMinutes = 23;
    private const int Id_getUTCMinutes = 24;
    private const int Id_getSeconds = 25;
    private const int Id_getUTCSeconds = 26;
    private const int Id_getMilliseconds = 27;
    private const int Id_getUTCMilliseconds = 28;
    private const int Id_getTimezoneOffset = 29;
    private const int Id_setTime = 30;
    private const int Id_setMilliseconds = 31;
    private const int Id_setUTCMilliseconds = 32;
    private const int Id_setSeconds = 33;
    private const int Id_setUTCSeconds = 34;
    private const int Id_setMinutes = 35;
    private const int Id_setUTCMinutes = 36;
    private const int Id_setHours = 37;
    private const int Id_setUTCHours = 38;
    private const int Id_setDate = 39;
    private const int Id_setUTCDate = 40;
    private const int Id_setMonth = 41;
    private const int Id_setUTCMonth = 42;
    private const int Id_setFullYear = 43;
    private const int Id_setUTCFullYear = 44;
    private const int Id_setYear = 45;
    private const int Id_toISOString = 46;
    private const int Id_toJSON = 47;
    private const int MAX_PROTOTYPE_ID = 47;
    private const int Id_toGMTString = 8;
    [Modifiers]
    private static TimeZone thisTimeZone;
    [Modifiers]
    private static double LocalTZA;
    [Modifiers]
    private static DateFormat timeZoneFormatter;
    [Modifiers]
    private static DateFormat localeDateTimeFormatter;
    [Modifiers]
    private static DateFormat localeDateFormatter;
    [Modifiers]
    private static DateFormat localeTimeFormatter;
    private double date;
    [Modifiers]
    internal new static bool \u0024assertionsDisabled;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 168, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private NativeDate()
    {
    }

    [LineNumberTable(733)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static double now() => (double) java.lang.System.currentTimeMillis();

    [LineNumberTable(new byte[] {163, 212, 105, 104, 162, 98, 98, 98, 99, 99, 163, 131, 107, 131, 131, 104, 105, 106, 102, 114, 102, 106, 114, 233, 69, 102, 99, 105, 106, 102, 102, 104, 102, 107, 197, 114, 103, 123, 109, 232, 74, 143, 163, 102, 137, 121, 102, 101, 118, 106, 106, 191, 2, 100, 106, 120, 152, 106, 102, 101, 105, 101, 137, 106, 102, 100, 106, 100, 136, 106, 120, 106, 106, 105, 140, 108, 106, 102, 106, 102, 100, 133, 138, 104, 120, 137, 102, 102, 106, 120, 98, 136, 103, 101, 234, 70, 231, 70, 99, 99, 109, 101, 106, 113, 98, 102, 102, 98, 229, 69, 107, 106, 132, 105, 168, 105, 140, 145, 141, 100, 136, 170, 135, 223, 22, 103, 162, 107, 130, 107, 162, 107, 162, 107, 130, 107, 130, 166, 133, 108, 106, 101, 99, 101, 99, 101, 131, 125, 109, 137})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static double date_parseString([In] string obj0)
    {
      double isoString = NativeDate.parseISOString(obj0);
      if (!Double.isNaN(isoString))
        return isoString;
      int num1 = -1;
      int num2 = -1;
      int num3 = -1;
      int num4 = -1;
      int num5 = -1;
      int num6 = -1;
      int num7 = 0;
      double num8 = -1.0;
      int num9 = 0;
      int num10 = 0;
      int num11 = String.instancehelper_length(obj0);
      while (num7 < num11)
      {
        int num12 = (int) String.instancehelper_charAt(obj0, num7);
        ++num7;
        if (num12 > 32)
        {
          switch (num12)
          {
            case 40:
              int num13 = 1;
              do
              {
                if (num7 < num11)
                {
                  int num14 = (int) String.instancehelper_charAt(obj0, num7);
                  ++num7;
                  switch (num14)
                  {
                    case 40:
                      ++num13;
                      continue;
                    case 41:
                      num13 += -1;
                      continue;
                    default:
                      continue;
                  }
                }
                else
                  break;
              }
              while (num13 > 0);
              continue;
            case 44:
            case 45:
              break;
            default:
              if (48 <= num12 && num12 <= 57)
              {
                int num14 = num12 - 48;
                for (; num7 < num11 && 48 <= (num12 = (int) String.instancehelper_charAt(obj0, num7)) && num12 <= 57; ++num7)
                  num14 = num14 * 10 + num12 - 48;
                if (num9 == 43 || num9 == 45)
                {
                  num10 = 1;
                  int num15;
                  if (num14 < 24)
                  {
                    num15 = num14 * 60;
                  }
                  else
                  {
                    int num16 = num14;
                    int num17 = 100;
                    num15 = (num17 != -1 ? num16 % num17 : 0) + num14 / 100 * 60;
                  }
                  if (num9 == 43)
                    num15 = -num15;
                  if (num8 != 0.0 && num8 != -1.0)
                    return double.NaN;
                  num8 = (double) num15;
                }
                else if (num14 >= 70 || num9 == 47 && num2 >= 0 && (num3 >= 0 && num1 < 0))
                {
                  if (num1 >= 0 || num12 > 32 && num12 != 44 && (num12 != 47 && num7 < num11))
                    return double.NaN;
                  num1 = num14 >= 100 ? num14 : num14 + 1900;
                }
                else
                {
                  switch (num12)
                  {
                    case 47:
                      if (num2 < 0)
                      {
                        num2 = num14 - 1;
                        break;
                      }
                      if (num3 >= 0)
                        return double.NaN;
                      num3 = num14;
                      break;
                    case 58:
                      if (num4 < 0)
                      {
                        num4 = num14;
                        break;
                      }
                      if (num5 >= 0)
                        return double.NaN;
                      num5 = num14;
                      break;
                    default:
                      if (num7 < num11 && num12 != 44 && (num12 > 32 && num12 != 45))
                        return double.NaN;
                      if (num10 != 0 && num14 < 60)
                      {
                        if (num8 < 0.0)
                        {
                          num8 -= (double) num14;
                          break;
                        }
                        num8 += (double) num14;
                        break;
                      }
                      if (num4 >= 0 && num5 < 0)
                      {
                        num5 = num14;
                        break;
                      }
                      if (num5 >= 0 && num6 < 0)
                      {
                        num6 = num14;
                        break;
                      }
                      if (num3 >= 0)
                        return double.NaN;
                      num3 = num14;
                      break;
                  }
                }
                num9 = 0;
                continue;
              }
              if (num12 == 47 || num12 == 58 || (num12 == 43 || num12 == 45))
              {
                num9 = num12;
                continue;
              }
              int num18 = num7 - 1;
              for (; num7 < num11; ++num7)
              {
                int num14 = (int) String.instancehelper_charAt(obj0, num7);
                if ((65 > num14 || num14 > 90) && (97 > num14 || num14 > 122))
                  break;
              }
              int num19 = num7 - num18;
              if (num19 < 2)
                return double.NaN;
              string str = "am;pm;monday;tuesday;wednesday;thursday;friday;saturday;sunday;january;february;march;april;may;june;july;august;september;october;november;december;gmt;ut;utc;est;edt;cst;cdt;mst;mdt;pst;pdt;";
              int num20 = 0;
              int num21 = 0;
              while (true)
              {
                int num14 = String.instancehelper_indexOf(str, 59, num21);
                if (num14 >= 0)
                {
                  if (!String.instancehelper_regionMatches(str, true, num21, obj0, num18, num19))
                  {
                    num21 = num14 + 1;
                    ++num20;
                  }
                  else
                    goto label_69;
                }
                else
                  break;
              }
              return double.NaN;
label_69:
              if (num20 < 2)
              {
                if (num4 > 12 || num4 < 0)
                  return double.NaN;
                if (num20 == 0)
                {
                  if (num4 == 12)
                  {
                    num4 = 0;
                    continue;
                  }
                  continue;
                }
                if (num4 != 12)
                {
                  num4 += 12;
                  continue;
                }
                continue;
              }
              int num22 = num20 - 2;
              if (num22 >= 7)
              {
                int num14 = num22 - 7;
                if (num14 < 12)
                {
                  if (num2 >= 0)
                    return double.NaN;
                  num2 = num14;
                  continue;
                }
                switch (num14 - 12)
                {
                  case 0:
                  case 1:
                  case 2:
                    num8 = 0.0;
                    continue;
                  case 3:
                  case 6:
                    num8 = 300.0;
                    continue;
                  case 4:
                    num8 = 240.0;
                    continue;
                  case 5:
                  case 8:
                    num8 = 360.0;
                    continue;
                  case 7:
                  case 10:
                    num8 = 420.0;
                    continue;
                  case 9:
                    num8 = 480.0;
                    continue;
                  default:
                    Kit.codeBug();
                    continue;
                }
              }
              else
                continue;
          }
        }
        if (num7 < num11)
        {
          int num14 = (int) String.instancehelper_charAt(obj0, num7);
          if (num12 == 45 && 48 <= num14 && num14 <= 57)
            num9 = num12;
        }
      }
      if (num1 < 0 || num2 < 0 || num3 < 0)
        return double.NaN;
      if (num6 < 0)
        num6 = 0;
      if (num5 < 0)
        num5 = 0;
      if (num4 < 0)
        num4 = 0;
      double num23 = NativeDate.date_msecFromDate((double) num1, (double) num2, (double) num3, (double) num4, (double) num5, (double) num6, 0.0);
      return num8 == -1.0 ? NativeDate.internalUTC(num23) : num23 + num8 * 60000.0;
    }

    [LineNumberTable(new byte[] {163, 47, 100, 138})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static double jsStaticFunction_UTC([In] object[] obj0) => obj0.Length == 0 ? double.NaN : NativeDate.TimeClip(NativeDate.date_msecFromArgs(obj0));

    [LineNumberTable(new byte[] {164, 179, 104, 234, 70, 103, 108, 105, 108, 105, 109, 105, 103, 100, 105, 131, 104, 100, 169, 103, 109, 105, 109, 105, 205, 191, 7, 118, 100, 142, 108, 131, 200, 105, 109, 124, 147, 108, 110, 109, 115, 112, 137})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static string date_format([In] double obj0, [In] int obj1)
    {
      StringBuilder stringBuilder = new StringBuilder(60);
      double num1 = NativeDate.LocalTime(obj0);
      if (obj1 != 3)
      {
        NativeDate.appendWeekDayName(stringBuilder, NativeDate.WeekDay(num1));
        stringBuilder.append(' ');
        NativeDate.appendMonthName(stringBuilder, NativeDate.MonthFromTime(num1));
        stringBuilder.append(' ');
        NativeDate.append0PaddedUint(stringBuilder, NativeDate.DateFromTime(num1), 2);
        stringBuilder.append(' ');
        int num2 = NativeDate.YearFromTime(num1);
        if (num2 < 0)
        {
          stringBuilder.append('-');
          num2 = -num2;
        }
        NativeDate.append0PaddedUint(stringBuilder, num2, 4);
        if (obj1 != 4)
          stringBuilder.append(' ');
      }
      if (obj1 != 4)
      {
        NativeDate.append0PaddedUint(stringBuilder, NativeDate.HourFromTime(num1), 2);
        stringBuilder.append(':');
        NativeDate.append0PaddedUint(stringBuilder, NativeDate.MinFromTime(num1), 2);
        stringBuilder.append(':');
        NativeDate.append0PaddedUint(stringBuilder, NativeDate.SecFromTime(num1), 2);
        int num2 = ByteCodeHelper.d2i(Math.floor((NativeDate.LocalTZA + NativeDate.DaylightSavingTA(obj0)) / 60000.0));
        int num3 = num2 / 60 * 100;
        int num4 = num2;
        int num5 = 60;
        int num6 = num5 != -1 ? num4 % num5 : 0;
        int num7 = num3 + num6;
        if (num7 > 0)
        {
          stringBuilder.append(" GMT+");
        }
        else
        {
          stringBuilder.append(" GMT-");
          num7 = -num7;
        }
        NativeDate.append0PaddedUint(stringBuilder, num7, 4);
        if (obj0 < 0.0)
          obj0 = NativeDate.MakeDate(NativeDate.MakeDay((double) NativeDate.EquivalentYear(NativeDate.YearFromTime(num1)), (double) NativeDate.MonthFromTime(obj0), (double) NativeDate.DateFromTime(obj0)), NativeDate.TimeWithinDay(obj0));
        stringBuilder.append(" (");
        Date date = new Date(ByteCodeHelper.d2l(obj0));
        lock (NativeDate.timeZoneFormatter)
          stringBuilder.append(NativeDate.timeZoneFormatter.format(date));
        stringBuilder.append(')');
      }
      return stringBuilder.toString();
    }

    [LineNumberTable(new byte[] {164, 243, 198, 100, 109, 194, 104, 100, 104, 114, 130, 104, 173, 136, 176, 137, 110, 162, 137, 112, 143, 136})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static object jsConstructor([In] object[] obj0)
    {
      NativeDate nativeDate = new NativeDate();
      if (obj0.Length == 0)
      {
        nativeDate.date = NativeDate.now();
        return (object) nativeDate;
      }
      if (obj0.Length == 1)
      {
        object defaultValue = obj0[0];
        switch (defaultValue)
        {
          case NativeDate _:
            nativeDate.date = ((NativeDate) defaultValue).date;
            return (object) nativeDate;
          case Scriptable _:
            defaultValue = ((Scriptable) defaultValue).getDefaultValue((Class) null);
            break;
        }
        double num = !CharSequence.IsInstance(defaultValue) ? ScriptRuntime.toNumber(defaultValue) : NativeDate.date_parseString(Object.instancehelper_toString(defaultValue));
        nativeDate.date = NativeDate.TimeClip(num);
        return (object) nativeDate;
      }
      double num1 = NativeDate.date_msecFromArgs(obj0);
      if (!Double.isNaN(num1) && !Double.isInfinite(num1))
        num1 = NativeDate.TimeClip(NativeDate.internalUTC(num1));
      nativeDate.date = num1;
      return (object) nativeDate;
    }

    [LineNumberTable(new byte[] {165, 30, 150, 102, 130, 102, 130, 102, 130, 171, 104, 120})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static string toLocale_helper([In] double obj0, [In] int obj1)
    {
      DateFormat dateFormat;
      switch (obj1)
      {
        case 5:
          dateFormat = NativeDate.localeDateTimeFormatter;
          break;
        case 6:
          dateFormat = NativeDate.localeTimeFormatter;
          break;
        case 7:
          dateFormat = NativeDate.localeDateFormatter;
          break;
        default:
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new AssertionError();
      }
      string str;
      lock (dateFormat)
        str = dateFormat.format(new Date(ByteCodeHelper.d2l(obj0)));
      return str;
    }

    [LineNumberTable(new byte[] {165, 50, 136, 109, 108, 110, 105, 109, 105, 104, 100, 105, 131, 104, 105, 110, 105, 110, 105, 110, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static string js_toUTCString([In] double obj0)
    {
      StringBuilder stringBuilder = new StringBuilder(60);
      NativeDate.appendWeekDayName(stringBuilder, NativeDate.WeekDay(obj0));
      stringBuilder.append(", ");
      NativeDate.append0PaddedUint(stringBuilder, NativeDate.DateFromTime(obj0), 2);
      stringBuilder.append(' ');
      NativeDate.appendMonthName(stringBuilder, NativeDate.MonthFromTime(obj0));
      stringBuilder.append(' ');
      int num = NativeDate.YearFromTime(obj0);
      if (num < 0)
      {
        stringBuilder.append('-');
        num = -num;
      }
      NativeDate.append0PaddedUint(stringBuilder, num, 4);
      stringBuilder.append(' ');
      NativeDate.append0PaddedUint(stringBuilder, NativeDate.HourFromTime(obj0), 2);
      stringBuilder.append(':');
      NativeDate.append0PaddedUint(stringBuilder, NativeDate.MinFromTime(obj0), 2);
      stringBuilder.append(':');
      NativeDate.append0PaddedUint(stringBuilder, NativeDate.SecFromTime(obj0), 2);
      stringBuilder.append(" GMT");
      return stringBuilder.toString();
    }

    [LineNumberTable(805)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static double LocalTime([In] double obj0) => obj0 + NativeDate.LocalTZA + NativeDate.DaylightSavingTA(obj0);

    [LineNumberTable(new byte[] {161, 172, 114, 162, 127, 1, 233, 71, 101, 140, 121, 138})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static int YearFromTime([In] double obj0)
    {
      if (Double.isInfinite(obj0) || Double.isNaN(obj0))
        return 0;
      double num1 = Math.floor(obj0 / 31556952000.0) + 1970.0;
      double num2 = NativeDate.TimeFromYear(num1);
      if (num2 > obj0)
        --num1;
      else if (num2 + 86400000.0 * NativeDate.DaysInYear(num1) <= obj0)
        ++num1;
      return ByteCodeHelper.d2i(num1);
    }

    [LineNumberTable(new byte[] {161, 228, 104, 152, 101, 100, 170, 104, 99, 98, 196, 133, 159, 21, 130, 99, 130, 99, 130, 99, 130, 99, 130, 102, 130, 102, 130, 102, 130, 102, 130, 102, 130, 131, 171})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static int MonthFromTime([In] double obj0)
    {
      int num1 = NativeDate.YearFromTime(obj0);
      int num2 = ByteCodeHelper.d2i(NativeDate.Day(obj0) - NativeDate.DayFromYear((double) num1)) - 59;
      if (num2 < 0)
        return num2 < -28 ? 0 : 1;
      if (NativeDate.IsLeapYear(num1))
      {
        if (num2 == 0)
          return 1;
        num2 += -1;
      }
      int num3 = num2 / 30;
      int num4;
      switch (num3)
      {
        case 0:
          return 2;
        case 1:
          num4 = 31;
          break;
        case 2:
          num4 = 61;
          break;
        case 3:
          num4 = 92;
          break;
        case 4:
          num4 = 122;
          break;
        case 5:
          num4 = 153;
          break;
        case 6:
          num4 = 184;
          break;
        case 7:
          num4 = 214;
          break;
        case 8:
          num4 = 245;
          break;
        case 9:
          num4 = 275;
          break;
        case 10:
          return 11;
        default:
          throw Throwable.__\u003Cunmap\u003E((Exception) Kit.codeBug());
      }
      return num2 >= num4 ? num3 + 2 : num3 + 1;
    }

    [LineNumberTable(new byte[] {162, 29, 104, 152, 101, 100, 183, 104, 99, 99, 228, 69, 159, 27, 132, 99, 99, 133, 99, 99, 133, 99, 99, 133, 99, 99, 130, 99, 102, 130, 99, 102, 130, 99, 102, 130, 99, 102, 130, 99, 102, 130, 138, 139, 100, 132, 132})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static int DateFromTime([In] double obj0)
    {
      int num1 = NativeDate.YearFromTime(obj0);
      int num2 = ByteCodeHelper.d2i(NativeDate.Day(obj0) - NativeDate.DayFromYear((double) num1)) - 59;
      if (num2 < 0)
        return num2 < -28 ? num2 + 31 + 28 + 1 : num2 + 28 + 1;
      if (NativeDate.IsLeapYear(num1))
      {
        if (num2 == 0)
          return 29;
        num2 += -1;
      }
      int num3;
      int num4;
      switch (num2 / 30)
      {
        case 0:
          return num2 + 1;
        case 1:
          num3 = 31;
          num4 = 31;
          break;
        case 2:
          num3 = 30;
          num4 = 61;
          break;
        case 3:
          num3 = 31;
          num4 = 92;
          break;
        case 4:
          num3 = 30;
          num4 = 122;
          break;
        case 5:
          num3 = 31;
          num4 = 153;
          break;
        case 6:
          num3 = 31;
          num4 = 184;
          break;
        case 7:
          num3 = 30;
          num4 = 214;
          break;
        case 8:
          num3 = 31;
          num4 = 245;
          break;
        case 9:
          num3 = 30;
          num4 = 275;
          break;
        case 10:
          return num2 - 275 + 1;
        default:
          throw Throwable.__\u003Cunmap\u003E((Exception) Kit.codeBug());
      }
      int num5 = num2 - num4;
      if (num5 < 0)
        num5 += num3;
      return num5 + 1;
    }

    [LineNumberTable(new byte[] {162, 99, 117, 110, 104, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static int WeekDay([In] double obj0)
    {
      double num = (NativeDate.Day(obj0) + 4.0) % 7.0;
      if (num < 0.0)
        num += 7.0;
      return ByteCodeHelper.d2i(num);
    }

    [LineNumberTable(new byte[] {162, 188, 127, 1, 104, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static int HourFromTime([In] double obj0)
    {
      double num = Math.floor(obj0 / 3600000.0) % 24.0;
      if (num < 0.0)
        num += 24.0;
      return ByteCodeHelper.d2i(num);
    }

    [LineNumberTable(new byte[] {162, 196, 127, 1, 104, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static int MinFromTime([In] double obj0)
    {
      double num = Math.floor(obj0 / 60000.0) % 60.0;
      if (num < 0.0)
        num += 60.0;
      return ByteCodeHelper.d2i(num);
    }

    [LineNumberTable(new byte[] {162, 204, 127, 1, 104, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static int SecFromTime([In] double obj0)
    {
      double num = Math.floor(obj0 / 1000.0) % 60.0;
      if (num < 0.0)
        num += 60.0;
      return ByteCodeHelper.d2i(num);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    private static int msFromTime([In] double obj0)
    {
      double num = obj0 % 1000.0;
      if (num < 0.0)
        num += 1000.0;
      return ByteCodeHelper.d2i(num);
    }

    [LineNumberTable(new byte[] {162, 242, 191, 6, 113, 138, 105, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static double TimeClip([In] double obj0)
    {
      if (Double.isNaN(obj0) || obj0 == double.PositiveInfinity || (obj0 == double.NegativeInfinity || Math.abs(obj0) > 8.64E+15))
        return double.NaN;
      return obj0 > 0.0 ? Math.floor(obj0 + 0.0) : Math.ceil(obj0 + 0.0);
    }

    [LineNumberTable(new byte[] {165, 155, 228, 74, 202, 98, 255, 12, 72, 162, 98, 162, 98, 162, 98, 162, 98, 162, 171, 98, 105, 118, 104, 104, 109, 114, 132, 238, 59, 232, 75, 108, 170, 198, 99, 141, 132, 106, 143, 138, 106, 143, 138, 106, 143, 138, 106, 143, 138, 113, 147, 99, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static double makeTime([In] double obj0, [In] object[] obj1, [In] int obj2)
    {
      if (obj1.Length == 0)
        return double.NaN;
      int num1 = 1;
      int num2;
      switch (obj2)
      {
        case 31:
          num2 = 1;
          break;
        case 32:
        case 34:
        case 36:
        case 38:
          num1 = 0;
          goto case 31;
        case 33:
          num2 = 2;
          break;
        case 35:
          num2 = 3;
          break;
        case 37:
          num2 = 4;
          break;
        default:
          throw Throwable.__\u003Cunmap\u003E((Exception) Kit.codeBug());
      }
      int num3 = 0;
      int num4 = Math.min(obj1.Length, num2);
      if (!NativeDate.\u0024assertionsDisabled && num4 > 4)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new AssertionError();
      }
      double[] numArray1 = new double[4];
      for (int index = 0; index < num4; ++index)
      {
        double number = ScriptRuntime.toNumber(obj1[index]);
        if (Double.isNaN(number) || Double.isInfinite(number))
          num3 = 1;
        else
          numArray1[index] = ScriptRuntime.toInteger(number);
      }
      if (num3 != 0 || Double.isNaN(obj0))
        return double.NaN;
      int num5 = 0;
      int num6 = num4;
      double num7 = num1 == 0 ? obj0 : NativeDate.LocalTime(obj0);
      double num8;
      if (num2 >= 4 && num5 < num6)
      {
        double[] numArray2 = numArray1;
        int index = num5;
        ++num5;
        num8 = numArray2[index];
      }
      else
        num8 = (double) NativeDate.HourFromTime(num7);
      double num9;
      if (num2 >= 3 && num5 < num6)
      {
        double[] numArray2 = numArray1;
        int index = num5;
        ++num5;
        num9 = numArray2[index];
      }
      else
        num9 = (double) NativeDate.MinFromTime(num7);
      double num10;
      if (num2 >= 2 && num5 < num6)
      {
        double[] numArray2 = numArray1;
        int index = num5;
        ++num5;
        num10 = numArray2[index];
      }
      else
        num10 = (double) NativeDate.SecFromTime(num7);
      double num11;
      if (num2 >= 1 && num5 < num6)
      {
        double[] numArray2 = numArray1;
        int index = num5;
        int num12 = num5 + 1;
        num11 = numArray2[index];
      }
      else
        num11 = (double) NativeDate.msFromTime(num7);
      double num13 = NativeDate.MakeTime(num8, num9, num10, num11);
      double num14 = NativeDate.MakeDate(NativeDate.Day(num7), num13);
      if (num1 != 0)
        num14 = NativeDate.internalUTC(num14);
      return NativeDate.TimeClip(num14);
    }

    [LineNumberTable(new byte[] {166, 3, 100, 202, 98, 255, 4, 70, 162, 98, 162, 98, 162, 98, 162, 171, 98, 105, 122, 104, 104, 109, 114, 132, 238, 59, 232, 74, 99, 170, 230, 70, 105, 100, 138, 137, 99, 141, 164, 106, 143, 138, 106, 143, 138, 106, 143, 138, 111, 147, 99, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static double makeDate([In] double obj0, [In] object[] obj1, [In] int obj2)
    {
      if (obj1.Length == 0)
        return double.NaN;
      int num1 = 1;
      int num2;
      switch (obj2)
      {
        case 39:
          num2 = 1;
          break;
        case 40:
        case 42:
        case 44:
          num1 = 0;
          goto case 39;
        case 41:
          num2 = 2;
          break;
        case 43:
          num2 = 3;
          break;
        default:
          throw Throwable.__\u003Cunmap\u003E((Exception) Kit.codeBug());
      }
      int num3 = 0;
      int num4 = Math.min(obj1.Length, num2);
      if (!NativeDate.\u0024assertionsDisabled && (1 > num4 || num4 > 3))
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new AssertionError();
      }
      double[] numArray1 = new double[3];
      for (int index = 0; index < num4; ++index)
      {
        double number = ScriptRuntime.toNumber(obj1[index]);
        if (Double.isNaN(number) || Double.isInfinite(number))
          num3 = 1;
        else
          numArray1[index] = ScriptRuntime.toInteger(number);
      }
      if (num3 != 0)
        return double.NaN;
      int num5 = 0;
      int num6 = num4;
      double num7;
      if (Double.isNaN(obj0))
      {
        if (num2 < 3)
          return double.NaN;
        num7 = 0.0;
      }
      else
        num7 = num1 == 0 ? obj0 : NativeDate.LocalTime(obj0);
      double num8;
      if (num2 >= 3 && num5 < num6)
      {
        double[] numArray2 = numArray1;
        int index = num5;
        ++num5;
        num8 = numArray2[index];
      }
      else
        num8 = (double) NativeDate.YearFromTime(num7);
      double num9;
      if (num2 >= 2 && num5 < num6)
      {
        double[] numArray2 = numArray1;
        int index = num5;
        ++num5;
        num9 = numArray2[index];
      }
      else
        num9 = (double) NativeDate.MonthFromTime(num7);
      double num10;
      if (num2 >= 1 && num5 < num6)
      {
        double[] numArray2 = numArray1;
        int index = num5;
        int num11 = num5 + 1;
        num10 = numArray2[index];
      }
      else
        num10 = (double) NativeDate.DateFromTime(num7);
      double num12 = NativeDate.MakeDate(NativeDate.MakeDay(num8, num9, num10), NativeDate.TimeWithinDay(num7));
      if (num1 != 0)
        num12 = NativeDate.internalUTC(num12);
      return NativeDate.TimeClip(num12);
    }

    [LineNumberTable(new byte[] {162, 225, 154, 112, 105, 144, 123, 150})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static double MakeDay([In] double obj0, [In] double obj1, [In] double obj2)
    {
      obj0 += Math.floor(obj1 / 12.0);
      obj1 %= 12.0;
      if (obj1 < 0.0)
        obj1 += 12.0;
      return Math.floor(NativeDate.TimeFromYear(obj0) / 86400000.0) + NativeDate.DayFromMonth(ByteCodeHelper.d2i(obj1), ByteCodeHelper.d2i(obj0)) + obj2 - 1.0;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    private static double TimeWithinDay([In] double obj0)
    {
      double num = obj0 % 86400000.0;
      if (num < 0.0)
        num += 86400000.0;
      return num;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    private static double MakeDate([In] double obj0, [In] double obj1) => obj0 * 86400000.0 + obj1;

    [LineNumberTable(809)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static double internalUTC([In] double obj0) => obj0 - NativeDate.LocalTZA - NativeDate.DaylightSavingTA(obj0 - NativeDate.LocalTZA);

    [LineNumberTable(new byte[] {165, 75, 136, 104, 100, 105, 107, 104, 138, 136, 105, 112, 105, 110, 105, 110, 105, 110, 105, 110, 105, 110, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static string js_toISOString([In] double obj0)
    {
      StringBuilder stringBuilder = new StringBuilder(27);
      int num = NativeDate.YearFromTime(obj0);
      if (num < 0)
      {
        stringBuilder.append('-');
        NativeDate.append0PaddedUint(stringBuilder, -num, 6);
      }
      else if (num > 9999)
        NativeDate.append0PaddedUint(stringBuilder, num, 6);
      else
        NativeDate.append0PaddedUint(stringBuilder, num, 4);
      stringBuilder.append('-');
      NativeDate.append0PaddedUint(stringBuilder, NativeDate.MonthFromTime(obj0) + 1, 2);
      stringBuilder.append('-');
      NativeDate.append0PaddedUint(stringBuilder, NativeDate.DateFromTime(obj0), 2);
      stringBuilder.append('T');
      NativeDate.append0PaddedUint(stringBuilder, NativeDate.HourFromTime(obj0), 2);
      stringBuilder.append(':');
      NativeDate.append0PaddedUint(stringBuilder, NativeDate.MinFromTime(obj0), 2);
      stringBuilder.append(':');
      NativeDate.append0PaddedUint(stringBuilder, NativeDate.SecFromTime(obj0), 2);
      stringBuilder.append('.');
      NativeDate.append0PaddedUint(stringBuilder, NativeDate.msFromTime(obj0), 3);
      stringBuilder.append('Z');
      return stringBuilder.toString();
    }

    [LineNumberTable(new byte[] {161, 163, 127, 49, 63, 9})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static double DayFromYear([In] double obj0) => 365.0 * (obj0 - 1970.0) + Math.floor((obj0 - 1969.0) / 4.0) - Math.floor((obj0 - 1901.0) / 100.0) + Math.floor((obj0 - 1601.0) / 400.0);

    [LineNumberTable(538)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static double TimeFromYear([In] double obj0) => NativeDate.DayFromYear(obj0) * 86400000.0;

    [LineNumberTable(new byte[] {161, 212, 114, 138})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static double DaysInYear([In] double obj0)
    {
      if (Double.isInfinite(obj0) || Double.isNaN(obj0))
        return double.NaN;
      return NativeDate.IsLeapYear(ByteCodeHelper.d2i(obj0)) ? 366.0 : 365.0;
    }

    [LineNumberTable(526)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool IsLeapYear([In] int obj0)
    {
      int num1 = obj0;
      int num2 = 4;
      if ((num2 != -1 ? num1 % num2 : 0) == 0)
      {
        int num3 = obj0;
        int num4 = 100;
        if ((num4 != -1 ? num3 % num4 : 0) == 0)
        {
          int num5 = obj0;
          int num6 = 400;
          if ((num6 != -1 ? num5 % num6 : 0) != 0)
            goto label_4;
        }
        return true;
      }
label_4:
      return false;
    }

    [LineNumberTable(514)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static double Day([In] double obj0) => Math.floor(obj0 / 86400000.0);

    [LineNumberTable(new byte[] {162, 134, 112, 109, 100, 132, 104, 159, 5, 134, 134, 134, 134, 134, 134, 168, 159, 5, 134, 134, 134, 134, 134, 134, 198})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static int EquivalentYear([In] int obj0)
    {
      int num1 = ByteCodeHelper.d2i(NativeDate.DayFromYear((double) obj0)) + 4;
      int num2 = 7;
      int num3 = num2 != -1 ? num1 % num2 : 0;
      if (num3 < 0)
        num3 += 7;
      if (NativeDate.IsLeapYear(obj0))
      {
        switch (num3)
        {
          case 0:
            return 1984;
          case 1:
            return 1996;
          case 2:
            return 1980;
          case 3:
            return 1992;
          case 4:
            return 1976;
          case 5:
            return 1988;
          case 6:
            return 1972;
        }
      }
      else
      {
        switch (num3)
        {
          case 0:
            return 1978;
          case 1:
            return 1973;
          case 2:
            return 1985;
          case 3:
            return 1986;
          case 4:
            return 1981;
          case 5:
            return 1971;
          case 6:
            return 1977;
        }
      }
      throw Throwable.__\u003Cunmap\u003E((Exception) Kit.codeBug());
    }

    [LineNumberTable(new byte[] {162, 115, 105, 109, 122, 146, 109, 109, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static double DaylightSavingTA([In] double obj0)
    {
      if (obj0 < 0.0)
        obj0 = NativeDate.MakeDate(NativeDate.MakeDay((double) NativeDate.EquivalentYear(NativeDate.YearFromTime(obj0)), (double) NativeDate.MonthFromTime(obj0), (double) NativeDate.DateFromTime(obj0)), NativeDate.TimeWithinDay(obj0));
      Date date = new Date(ByteCodeHelper.d2l(obj0));
      return NativeDate.thisTimeZone.inDaylightTime(date) ? 3600000.0 : 0.0;
    }

    [LineNumberTable(new byte[] {161, 194, 133, 100, 106, 100, 140, 164, 108, 164})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static double DayFromMonth([In] int obj0, [In] int obj1)
    {
      int num1 = obj0 * 30;
      int num2 = obj0 < 7 ? (obj0 < 2 ? num1 + obj0 : num1 + ((obj0 - 1) / 2 - 1)) : num1 + (obj0 / 2 - 1);
      if (obj0 >= 2 && NativeDate.IsLeapYear(obj1))
        ++num2;
      return (double) num2;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    private static double MakeTime([In] double obj0, [In] double obj1, [In] double obj2, [In] double obj3) => ((obj0 * 60.0 + obj1) * 60.0 + obj2) * 1000.0 + obj3;

    [LineNumberTable(new byte[] {163, 8, 110, 115, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static double date_msecFromDate(
      [In] double obj0,
      [In] double obj1,
      [In] double obj2,
      [In] double obj3,
      [In] double obj4,
      [In] double obj5,
      [In] double obj6)
    {
      return NativeDate.MakeDate(NativeDate.MakeDay(obj0, obj1, obj2), NativeDate.MakeTime(obj3, obj4, obj5, obj6));
    }

    [LineNumberTable(new byte[] {163, 18, 199, 105, 101, 107, 112, 138, 143, 100, 138, 232, 53, 233, 81, 120, 153})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static double date_msecFromArgs([In] object[] obj0)
    {
      double[] numArray1 = new double[7];
      for (int index = 0; index < 7; ++index)
      {
        if (index < obj0.Length)
        {
          double number = ScriptRuntime.toNumber(obj0[index]);
          if (Double.isNaN(number) || Double.isInfinite(number))
            return double.NaN;
          numArray1[index] = ScriptRuntime.toInteger(obj0[index]);
        }
        else
          numArray1[index] = index != 2 ? 0.0 : 1.0;
      }
      if (numArray1[0] >= 0.0 && numArray1[0] <= 99.0)
      {
        double[] numArray2 = numArray1;
        int index = 0;
        double[] numArray3 = numArray2;
        numArray3[index] = numArray3[index] + 1900.0;
      }
      return NativeDate.date_msecFromDate(numArray1[0], numArray1[1], numArray1[2], numArray1[3], numArray1[4], numArray1[5], numArray1[6]);
    }

    [LineNumberTable(new byte[] {161, 220, 100, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static int DaysInMonth([In] int obj0, [In] int obj1) => obj1 == 2 ? (NativeDate.IsLeapYear(obj0) ? 29 : 28) : (obj1 >= 8 ? 31 - (obj1 & 1) : 30 + (obj1 & 1));

    [LineNumberTable(new byte[] {163, 63, 98, 102, 104, 100, 130, 127, 17, 103, 107, 100, 105, 140, 102, 98, 109, 134, 102, 194, 103, 115, 102, 98, 165, 99, 102, 106, 108, 98, 133, 237, 58, 232, 72, 133, 134, 178, 130, 165, 112, 134, 100, 100, 214, 133, 130, 197, 191, 16, 118, 133, 107, 133, 107, 197, 134, 134, 98, 133, 122, 130, 122, 130, 113, 130, 162, 132, 140, 229, 69, 178, 111, 116, 106, 159, 12, 255, 51, 72, 165, 159, 3, 231, 70, 191, 1, 124, 195})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static double parseISOString([In] string obj0)
    {
      int index = 0;
      int[] numArray = new int[9]
      {
        1970,
        1,
        1,
        0,
        0,
        0,
        0,
        -1,
        -1
      };
      int num1 = 4;
      int num2 = 1;
      int num3 = 1;
      int num4 = 0;
      int num5 = String.instancehelper_length(obj0);
      if (num5 != 0)
      {
        int num6 = (int) String.instancehelper_charAt(obj0, 0);
        switch (num6)
        {
          case 43:
          case 45:
            ++num4;
            num1 = 6;
            num2 = num6 != 45 ? 1 : -1;
            break;
          case 84:
            ++num4;
            index = 3;
            break;
        }
      }
      while (index != -1)
      {
        int num6 = num4 + (index != 0 ? (index != 6 ? 2 : 3) : num1);
        if (num6 > num5)
        {
          index = -1;
          break;
        }
        int num7 = 0;
        for (; num4 < num6; ++num4)
        {
          int num8 = (int) String.instancehelper_charAt(obj0, num4);
          if (num8 < 48 || num8 > 57)
          {
            index = -1;
            goto label_43;
          }
          else
            num7 = 10 * num7 + (num8 - 48);
        }
        numArray[index] = num7;
        if (num4 == num5)
        {
          switch (index)
          {
            case 3:
            case 7:
              index = -1;
              goto label_43;
            default:
              goto label_43;
          }
        }
        else
        {
          string str = obj0;
          int num8 = num4;
          ++num4;
          int num9 = (int) String.instancehelper_charAt(str, num8);
          if (num9 == 90)
          {
            numArray[7] = 0;
            numArray[8] = 0;
            switch (index)
            {
              case 4:
              case 5:
              case 6:
                goto label_43;
              default:
                index = -1;
                goto label_43;
            }
          }
          else
          {
            switch (index)
            {
              case 0:
              case 1:
                int num10;
                switch (num9)
                {
                  case 45:
                    num10 = index + 1;
                    break;
                  case 84:
                    num10 = 3;
                    break;
                  default:
                    num10 = -1;
                    break;
                }
                index = num10;
                break;
              case 2:
                index = num9 != 84 ? -1 : 3;
                break;
              case 3:
                index = num9 != 58 ? -1 : 4;
                break;
              case 4:
                int num11;
                switch (num9)
                {
                  case 43:
                  case 45:
                    num11 = 7;
                    break;
                  case 58:
                    num11 = 5;
                    break;
                  default:
                    num11 = -1;
                    break;
                }
                index = num11;
                break;
              case 5:
                int num12;
                switch (num9)
                {
                  case 43:
                  case 45:
                    num12 = 7;
                    break;
                  case 46:
                    num12 = 6;
                    break;
                  default:
                    num12 = -1;
                    break;
                }
                index = num12;
                break;
              case 6:
                index = num9 == 43 || num9 == 45 ? 7 : -1;
                break;
              case 7:
                if (num9 != 58)
                  num4 += -1;
                index = 8;
                break;
              case 8:
                index = -1;
                break;
            }
            if (index == 7)
              num3 = num9 != 45 ? 1 : -1;
          }
        }
      }
label_43:
      if (index != -1 && num4 == num5)
      {
        int num6 = numArray[0];
        int num7 = numArray[1];
        int num8 = numArray[2];
        int num9 = numArray[3];
        int num10 = numArray[4];
        int num11 = numArray[5];
        int num12 = numArray[6];
        int num13 = numArray[7];
        int num14 = numArray[8];
        if (num6 <= 275943 && num7 >= 1 && (num7 <= 12 && num8 >= 1) && (num8 <= NativeDate.DaysInMonth(num6, num7) && num9 <= 24) && (num9 != 24 || num10 <= 0 && num11 <= 0 && num12 <= 0) && (num10 <= 59 && num11 <= 59 && (num13 <= 23 && num14 <= 59)))
        {
          double num15 = NativeDate.date_msecFromDate((double) (num6 * num2), (double) (num7 - 1), (double) num8, (double) num9, (double) num10, (double) num11, (double) num12);
          if (num13 != -1)
            num15 -= (double) (num13 * 60 + num14) * 60000.0 * (double) num3;
          if (num15 >= -8.64E+15 && num15 <= 8.64E+15)
            return num15;
        }
      }
      return double.NaN;
    }

    [LineNumberTable(new byte[] {165, 147, 102, 101, 102, 48, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void appendWeekDayName([In] StringBuilder obj0, [In] int obj1)
    {
      string str = "SunMonTueWedThuFriSat";
      obj1 *= 3;
      for (int index = 0; index != 3; ++index)
        obj0.append(String.instancehelper_charAt(str, obj1 + index));
    }

    [LineNumberTable(new byte[] {165, 138, 134, 101, 102, 48, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void appendMonthName([In] StringBuilder obj0, [In] int obj1)
    {
      string str = "JanFebMarAprMayJunJulAugSepOctNovDec";
      obj1 *= 3;
      for (int index = 0; index != 3; ++index)
        obj0.append(String.instancehelper_charAt(str, obj1 + index));
    }

    [LineNumberTable(new byte[] {165, 103, 106, 98, 101, 101, 136, 101, 100, 130, 101, 98, 162, 102, 166, 100, 105, 135, 100, 118, 110, 135, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void append0PaddedUint([In] StringBuilder obj0, [In] int obj1, [In] int obj2)
    {
      if (obj1 < 0)
        Kit.codeBug();
      int num1 = 1;
      obj2 += -1;
      if (obj1 >= 10)
      {
        if (obj1 < 1000000000)
        {
          while (true)
          {
            int num2 = num1 * 10;
            if (obj1 >= num2)
            {
              obj2 += -1;
              num1 = num2;
            }
            else
              break;
          }
        }
        else
        {
          obj2 += -9;
          num1 = 1000000000;
        }
      }
      for (; obj2 > 0; obj2 += -1)
        obj0.append('0');
      for (; num1 != 1; num1 /= 10)
      {
        StringBuilder stringBuilder = obj0;
        int num2 = obj1;
        int num3 = num1;
        int num4 = (int) (ushort) (48 + (num3 != -1 ? num2 / num3 : -num2));
        stringBuilder.append((char) num4);
        int num5 = obj1;
        int num6 = num1;
        obj1 = num6 != -1 ? num5 % num6 : 0;
      }
      obj0.append((char) (48 + obj1));
    }

    [LineNumberTable(new byte[] {159, 137, 66, 134, 112, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static void init([In] Scriptable obj0, [In] bool obj1)
    {
      int num = obj1 ? 1 : 0;
      new NativeDate() { date = double.NaN }.exportAsJSClass(47, obj0, num != 0);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string getClassName() => "Date";

    [Signature("(Ljava/lang/Class<*>;)Ljava/lang/Object;")]
    [LineNumberTable(new byte[] {159, 178, 99, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override object getDefaultValue([In] Class obj0)
    {
      if (obj0 == null)
        obj0 = ScriptRuntime.__\u003C\u003EStringClass;
      return base.getDefaultValue(obj0);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual double getJSTimeValue() => this.date;

    [LineNumberTable(new byte[] {159, 189, 148, 148, 147, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void fillConstructorProperties([In] IdFunctionObject obj0)
    {
      this.addIdFunctionProperty((Scriptable) obj0, NativeDate.DATE_TAG, -3, "now", 0);
      this.addIdFunctionProperty((Scriptable) obj0, NativeDate.DATE_TAG, -2, "parse", 1);
      this.addIdFunctionProperty((Scriptable) obj0, NativeDate.DATE_TAG, -1, "UTC", 7);
      base.fillConstructorProperties(obj0);
    }

    [LineNumberTable(new byte[] {10, 159, 160, 106, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 130, 98, 102, 130, 98, 102, 130, 98, 102, 130, 98, 102, 130, 98, 102, 130, 145, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void initPrototypeId([In] int obj0)
    {
      int arity;
      string name;
      switch (obj0)
      {
        case 1:
          arity = 7;
          name = "constructor";
          break;
        case 2:
          arity = 0;
          name = "toString";
          break;
        case 3:
          arity = 0;
          name = "toTimeString";
          break;
        case 4:
          arity = 0;
          name = "toDateString";
          break;
        case 5:
          arity = 0;
          name = "toLocaleString";
          break;
        case 6:
          arity = 0;
          name = "toLocaleTimeString";
          break;
        case 7:
          arity = 0;
          name = "toLocaleDateString";
          break;
        case 8:
          arity = 0;
          name = "toUTCString";
          break;
        case 9:
          arity = 0;
          name = "toSource";
          break;
        case 10:
          arity = 0;
          name = "valueOf";
          break;
        case 11:
          arity = 0;
          name = "getTime";
          break;
        case 12:
          arity = 0;
          name = "getYear";
          break;
        case 13:
          arity = 0;
          name = "getFullYear";
          break;
        case 14:
          arity = 0;
          name = "getUTCFullYear";
          break;
        case 15:
          arity = 0;
          name = "getMonth";
          break;
        case 16:
          arity = 0;
          name = "getUTCMonth";
          break;
        case 17:
          arity = 0;
          name = "getDate";
          break;
        case 18:
          arity = 0;
          name = "getUTCDate";
          break;
        case 19:
          arity = 0;
          name = "getDay";
          break;
        case 20:
          arity = 0;
          name = "getUTCDay";
          break;
        case 21:
          arity = 0;
          name = "getHours";
          break;
        case 22:
          arity = 0;
          name = "getUTCHours";
          break;
        case 23:
          arity = 0;
          name = "getMinutes";
          break;
        case 24:
          arity = 0;
          name = "getUTCMinutes";
          break;
        case 25:
          arity = 0;
          name = "getSeconds";
          break;
        case 26:
          arity = 0;
          name = "getUTCSeconds";
          break;
        case 27:
          arity = 0;
          name = "getMilliseconds";
          break;
        case 28:
          arity = 0;
          name = "getUTCMilliseconds";
          break;
        case 29:
          arity = 0;
          name = "getTimezoneOffset";
          break;
        case 30:
          arity = 1;
          name = "setTime";
          break;
        case 31:
          arity = 1;
          name = "setMilliseconds";
          break;
        case 32:
          arity = 1;
          name = "setUTCMilliseconds";
          break;
        case 33:
          arity = 2;
          name = "setSeconds";
          break;
        case 34:
          arity = 2;
          name = "setUTCSeconds";
          break;
        case 35:
          arity = 3;
          name = "setMinutes";
          break;
        case 36:
          arity = 3;
          name = "setUTCMinutes";
          break;
        case 37:
          arity = 4;
          name = "setHours";
          break;
        case 38:
          arity = 4;
          name = "setUTCHours";
          break;
        case 39:
          arity = 1;
          name = "setDate";
          break;
        case 40:
          arity = 1;
          name = "setUTCDate";
          break;
        case 41:
          arity = 2;
          name = "setMonth";
          break;
        case 42:
          arity = 2;
          name = "setUTCMonth";
          break;
        case 43:
          arity = 3;
          name = "setFullYear";
          break;
        case 44:
          arity = 3;
          name = "setUTCFullYear";
          break;
        case 45:
          arity = 1;
          name = "setYear";
          break;
        case 46:
          arity = 0;
          name = "toISOString";
          break;
        case 47:
          arity = 1;
          name = "toJSON";
          break;
        default:
          string str = String.valueOf(obj0);
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalArgumentException(str);
      }
      this.initPrototypeMethod(NativeDate.DATE_TAG, obj0, name, arity);
    }

    [LineNumberTable(new byte[] {160, 144, 109, 142, 103, 159, 14, 172, 105, 205, 238, 69, 100, 109, 200, 134, 106, 108, 104, 111, 114, 162, 109, 110, 139, 5, 203, 105, 139, 103, 229, 61, 235, 69, 150, 105, 103, 37, 171, 227, 71, 105, 108, 105, 137, 255, 160, 98, 69, 105, 137, 230, 69, 105, 137, 166, 105, 136, 166, 223, 12, 232, 69, 108, 112, 106, 101, 105, 122, 178, 208, 200, 105, 112, 138, 200, 105, 112, 138, 200, 105, 112, 138, 200, 105, 112, 138, 200, 105, 112, 138, 200, 105, 112, 138, 200, 105, 112, 138, 168, 105, 154, 168, 114, 106, 232, 74, 110, 106, 232, 72, 110, 106, 168, 140, 114, 144, 105, 137, 171, 118, 144, 108, 38, 137, 115, 107, 171, 106, 168, 105, 136, 108, 178})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override object execIdCall(
      [In] IdFunctionObject obj0,
      [In] Context obj1,
      [In] Scriptable obj2,
      [In] Scriptable obj3,
      [In] object[] obj4)
    {
      if (!obj0.hasTag(NativeDate.DATE_TAG))
        return base.execIdCall(obj0, obj1, obj2, obj3, obj4);
      int num1 = obj0.methodId();
      switch (num1)
      {
        case -3:
          return (object) ScriptRuntime.wrapNumber(NativeDate.now());
        case -2:
          return (object) ScriptRuntime.wrapNumber(NativeDate.date_parseString(ScriptRuntime.toString(obj4, 0)));
        case -1:
          return (object) ScriptRuntime.wrapNumber(NativeDate.jsStaticFunction_UTC(obj4));
        case 1:
          return obj3 != null ? (object) NativeDate.date_format(NativeDate.now(), 2) : NativeDate.jsConstructor(obj4);
        case 47:
          Scriptable s2 = ScriptRuntime.toObject(obj1, obj2, (object) obj3);
          object primitive = ScriptRuntime.toPrimitive((object) s2, ScriptRuntime.__\u003C\u003ENumberClass);
          if (primitive is Number)
          {
            double num2 = ((Number) primitive).doubleValue();
            if (Double.isNaN(num2) || Double.isInfinite(num2))
              return (object) null;
          }
          object property = ScriptableObject.getProperty(s2, "toISOString");
          if (object.ReferenceEquals(property, Scriptable.NOT_FOUND))
            throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.typeError2("msg.function.not.found.in", (object) "toISOString", (object) ScriptRuntime.toString((object) s2)));
          if (!(property is Callable))
            throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.typeError3("msg.isnt.function.in", "toISOString", ScriptRuntime.toString((object) s2), ScriptRuntime.toString(property)));
          object val = ((Callable) property).call(obj1, obj2, s2, ScriptRuntime.__\u003C\u003EemptyArgs);
          return ScriptRuntime.isPrimitive(val) ? val : throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.typeError1("msg.toisostring.must.return.primitive", (object) ScriptRuntime.toString(val)));
        default:
          NativeDate nativeDate = obj3 is NativeDate ? (NativeDate) obj3 : throw Throwable.__\u003Cunmap\u003E((Exception) IdScriptableObject.incompatibleCallError(obj0));
          double num3 = nativeDate.date;
          switch (num1)
          {
            case 2:
            case 3:
            case 4:
              return !Double.isNaN(num3) ? (object) NativeDate.date_format(num3, num1) : (object) "Invalid Date";
            case 5:
            case 6:
            case 7:
              return !Double.isNaN(num3) ? (object) NativeDate.toLocale_helper(num3, num1) : (object) "Invalid Date";
            case 8:
              return !Double.isNaN(num3) ? (object) NativeDate.js_toUTCString(num3) : (object) "Invalid Date";
            case 9:
              return (object) new StringBuilder().append("(new Date(").append(ScriptRuntime.toString(num3)).append("))").toString();
            case 10:
            case 11:
              return (object) ScriptRuntime.wrapNumber(num3);
            case 12:
            case 13:
            case 14:
              if (!Double.isNaN(num3))
              {
                if (num1 != 14)
                  num3 = NativeDate.LocalTime(num3);
                num3 = (double) NativeDate.YearFromTime(num3);
                if (num1 == 12)
                {
                  if (obj1.hasFeature(1))
                  {
                    if (1900.0 <= num3 && num3 < 2000.0)
                      num3 -= 1900.0;
                  }
                  else
                    num3 -= 1900.0;
                }
              }
              return (object) ScriptRuntime.wrapNumber(num3);
            case 15:
            case 16:
              if (!Double.isNaN(num3))
              {
                if (num1 == 15)
                  num3 = NativeDate.LocalTime(num3);
                num3 = (double) NativeDate.MonthFromTime(num3);
              }
              return (object) ScriptRuntime.wrapNumber(num3);
            case 17:
            case 18:
              if (!Double.isNaN(num3))
              {
                if (num1 == 17)
                  num3 = NativeDate.LocalTime(num3);
                num3 = (double) NativeDate.DateFromTime(num3);
              }
              return (object) ScriptRuntime.wrapNumber(num3);
            case 19:
            case 20:
              if (!Double.isNaN(num3))
              {
                if (num1 == 19)
                  num3 = NativeDate.LocalTime(num3);
                num3 = (double) NativeDate.WeekDay(num3);
              }
              return (object) ScriptRuntime.wrapNumber(num3);
            case 21:
            case 22:
              if (!Double.isNaN(num3))
              {
                if (num1 == 21)
                  num3 = NativeDate.LocalTime(num3);
                num3 = (double) NativeDate.HourFromTime(num3);
              }
              return (object) ScriptRuntime.wrapNumber(num3);
            case 23:
            case 24:
              if (!Double.isNaN(num3))
              {
                if (num1 == 23)
                  num3 = NativeDate.LocalTime(num3);
                num3 = (double) NativeDate.MinFromTime(num3);
              }
              return (object) ScriptRuntime.wrapNumber(num3);
            case 25:
            case 26:
              if (!Double.isNaN(num3))
              {
                if (num1 == 25)
                  num3 = NativeDate.LocalTime(num3);
                num3 = (double) NativeDate.SecFromTime(num3);
              }
              return (object) ScriptRuntime.wrapNumber(num3);
            case 27:
            case 28:
              if (!Double.isNaN(num3))
              {
                if (num1 == 27)
                  num3 = NativeDate.LocalTime(num3);
                num3 = (double) NativeDate.msFromTime(num3);
              }
              return (object) ScriptRuntime.wrapNumber(num3);
            case 29:
              if (!Double.isNaN(num3))
                num3 = (num3 - NativeDate.LocalTime(num3)) / 60000.0;
              return (object) ScriptRuntime.wrapNumber(num3);
            case 30:
              double x1 = NativeDate.TimeClip(ScriptRuntime.toNumber(obj4, 0));
              nativeDate.date = x1;
              return (object) ScriptRuntime.wrapNumber(x1);
            case 31:
            case 32:
            case 33:
            case 34:
            case 35:
            case 36:
            case 37:
            case 38:
              double x2 = NativeDate.makeTime(num3, obj4, num1);
              nativeDate.date = x2;
              return (object) ScriptRuntime.wrapNumber(x2);
            case 39:
            case 40:
            case 41:
            case 42:
            case 43:
            case 44:
              double x3 = NativeDate.makeDate(num3, obj4, num1);
              nativeDate.date = x3;
              return (object) ScriptRuntime.wrapNumber(x3);
            case 45:
              double number = ScriptRuntime.toNumber(obj4, 0);
              double x4;
              if (Double.isNaN(number) || Double.isInfinite(number))
              {
                x4 = double.NaN;
              }
              else
              {
                double num2 = !Double.isNaN(num3) ? NativeDate.LocalTime(num3) : 0.0;
                if (number >= 0.0 && number <= 99.0)
                  number += 1900.0;
                x4 = NativeDate.TimeClip(NativeDate.internalUTC(NativeDate.MakeDate(NativeDate.MakeDay(number, (double) NativeDate.MonthFromTime(num2), (double) NativeDate.DateFromTime(num2)), NativeDate.TimeWithinDay(num2))));
              }
              nativeDate.date = x4;
              return (object) ScriptRuntime.wrapNumber(x4);
            case 46:
              return !Double.isNaN(num3) ? (object) NativeDate.js_toISOString(num3) : throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.constructError("RangeError", ScriptRuntime.getMessage0("msg.invalid.date")));
            default:
              string str = String.valueOf(num1);
              Throwable.__\u003CsuppressFillInStackTrace\u003E();
              throw new IllegalArgumentException(str);
          }
      }
    }

    [LineNumberTable(new byte[] {166, 101, 98, 162, 159, 39, 104, 101, 102, 104, 104, 102, 200, 159, 20, 104, 101, 102, 104, 104, 102, 200, 104, 101, 102, 104, 104, 102, 200, 104, 101, 102, 104, 104, 102, 200, 102, 99, 133, 133, 159, 20, 104, 101, 102, 104, 104, 102, 200, 104, 101, 102, 104, 104, 102, 200, 102, 99, 133, 102, 98, 133, 133, 102, 99, 133, 104, 101, 104, 101, 102, 104, 104, 102, 136, 101, 104, 101, 102, 104, 104, 102, 136, 104, 104, 101, 102, 104, 104, 102, 232, 69, 159, 45, 104, 101, 102, 104, 104, 102, 200, 102, 98, 133, 102, 99, 133, 102, 98, 133, 104, 101, 105, 101, 102, 104, 104, 102, 136, 104, 105, 101, 102, 104, 104, 102, 232, 69, 102, 98, 133, 133, 104, 101, 102, 103, 104, 102, 199, 104, 101, 104, 101, 102, 104, 104, 102, 136, 104, 104, 101, 102, 104, 104, 102, 232, 69, 104, 101, 102, 104, 101, 102, 104, 104, 102, 199, 104, 101, 102, 104, 104, 102, 200, 102, 99, 133, 104, 101, 102, 101, 101, 102, 101, 101, 104, 101, 102, 100, 101, 102, 226, 69, 183})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override int findPrototypeId([In] string obj0)
    {
      int num = 0;
      string str = (string) null;
      switch (String.instancehelper_length(obj0))
      {
        case 6:
          switch (String.instancehelper_charAt(obj0, 0))
          {
            case 'g':
              str = "getDay";
              num = 19;
              break;
            case 't':
              str = "toJSON";
              num = 47;
              break;
          }
          break;
        case 7:
          switch (String.instancehelper_charAt(obj0, 3))
          {
            case 'D':
              switch (String.instancehelper_charAt(obj0, 0))
              {
                case 'g':
                  str = "getDate";
                  num = 17;
                  break;
                case 's':
                  str = "setDate";
                  num = 39;
                  break;
              }
              break;
            case 'T':
              switch (String.instancehelper_charAt(obj0, 0))
              {
                case 'g':
                  str = "getTime";
                  num = 11;
                  break;
                case 's':
                  str = "setTime";
                  num = 30;
                  break;
              }
              break;
            case 'Y':
              switch (String.instancehelper_charAt(obj0, 0))
              {
                case 'g':
                  str = "getYear";
                  num = 12;
                  break;
                case 's':
                  str = "setYear";
                  num = 45;
                  break;
              }
              break;
            case 'u':
              str = "valueOf";
              num = 10;
              break;
          }
          break;
        case 8:
          switch (String.instancehelper_charAt(obj0, 3))
          {
            case 'H':
              switch (String.instancehelper_charAt(obj0, 0))
              {
                case 'g':
                  str = "getHours";
                  num = 21;
                  break;
                case 's':
                  str = "setHours";
                  num = 37;
                  break;
              }
              break;
            case 'M':
              switch (String.instancehelper_charAt(obj0, 0))
              {
                case 'g':
                  str = "getMonth";
                  num = 15;
                  break;
                case 's':
                  str = "setMonth";
                  num = 41;
                  break;
              }
              break;
            case 'o':
              str = "toSource";
              num = 9;
              break;
            case 't':
              str = "toString";
              num = 2;
              break;
          }
          break;
        case 9:
          str = "getUTCDay";
          num = 20;
          break;
        case 10:
          switch (String.instancehelper_charAt(obj0, 3))
          {
            case 'M':
              switch (String.instancehelper_charAt(obj0, 0))
              {
                case 'g':
                  str = "getMinutes";
                  num = 23;
                  break;
                case 's':
                  str = "setMinutes";
                  num = 35;
                  break;
              }
              break;
            case 'S':
              switch (String.instancehelper_charAt(obj0, 0))
              {
                case 'g':
                  str = "getSeconds";
                  num = 25;
                  break;
                case 's':
                  str = "setSeconds";
                  num = 33;
                  break;
              }
              break;
            case 'U':
              switch (String.instancehelper_charAt(obj0, 0))
              {
                case 'g':
                  str = "getUTCDate";
                  num = 18;
                  break;
                case 's':
                  str = "setUTCDate";
                  num = 40;
                  break;
              }
              break;
          }
          break;
        case 11:
          switch (String.instancehelper_charAt(obj0, 3))
          {
            case 'F':
              switch (String.instancehelper_charAt(obj0, 0))
              {
                case 'g':
                  str = "getFullYear";
                  num = 13;
                  break;
                case 's':
                  str = "setFullYear";
                  num = 43;
                  break;
              }
              break;
            case 'M':
              str = "toGMTString";
              num = 8;
              break;
            case 'S':
              str = "toISOString";
              num = 46;
              break;
            case 'T':
              str = "toUTCString";
              num = 8;
              break;
            case 'U':
              switch (String.instancehelper_charAt(obj0, 0))
              {
                case 'g':
                  switch (String.instancehelper_charAt(obj0, 9))
                  {
                    case 'r':
                      str = "getUTCHours";
                      num = 22;
                      break;
                    case 't':
                      str = "getUTCMonth";
                      num = 16;
                      break;
                  }
                  break;
                case 's':
                  switch (String.instancehelper_charAt(obj0, 9))
                  {
                    case 'r':
                      str = "setUTCHours";
                      num = 38;
                      break;
                    case 't':
                      str = "setUTCMonth";
                      num = 42;
                      break;
                  }
                  break;
              }
              break;
            case 's':
              str = "constructor";
              num = 1;
              break;
          }
          break;
        case 12:
          switch (String.instancehelper_charAt(obj0, 2))
          {
            case 'D':
              str = "toDateString";
              num = 4;
              break;
            case 'T':
              str = "toTimeString";
              num = 3;
              break;
          }
          break;
        case 13:
          switch (String.instancehelper_charAt(obj0, 0))
          {
            case 'g':
              switch (String.instancehelper_charAt(obj0, 6))
              {
                case 'M':
                  str = "getUTCMinutes";
                  num = 24;
                  break;
                case 'S':
                  str = "getUTCSeconds";
                  num = 26;
                  break;
              }
              break;
            case 's':
              switch (String.instancehelper_charAt(obj0, 6))
              {
                case 'M':
                  str = "setUTCMinutes";
                  num = 36;
                  break;
                case 'S':
                  str = "setUTCSeconds";
                  num = 34;
                  break;
              }
              break;
          }
          break;
        case 14:
          switch (String.instancehelper_charAt(obj0, 0))
          {
            case 'g':
              str = "getUTCFullYear";
              num = 14;
              break;
            case 's':
              str = "setUTCFullYear";
              num = 44;
              break;
            case 't':
              str = "toLocaleString";
              num = 5;
              break;
          }
          break;
        case 15:
          switch (String.instancehelper_charAt(obj0, 0))
          {
            case 'g':
              str = "getMilliseconds";
              num = 27;
              break;
            case 's':
              str = "setMilliseconds";
              num = 31;
              break;
          }
          break;
        case 17:
          str = "getTimezoneOffset";
          num = 29;
          break;
        case 18:
          switch (String.instancehelper_charAt(obj0, 0))
          {
            case 'g':
              str = "getUTCMilliseconds";
              num = 28;
              break;
            case 's':
              str = "setUTCMilliseconds";
              num = 32;
              break;
            case 't':
              switch (String.instancehelper_charAt(obj0, 8))
              {
                case 'D':
                  str = "toLocaleDateString";
                  num = 7;
                  break;
                case 'T':
                  str = "toLocaleTimeString";
                  num = 6;
                  break;
              }
              break;
          }
          break;
      }
      if (str != null && !object.ReferenceEquals((object) str, (object) obj0) && !String.instancehelper_equals(str, (object) obj0))
        num = 0;
      return num;
    }

    [LineNumberTable(new byte[] {159, 139, 146, 117, 234, 168, 5, 106, 113, 111, 98, 106, 97, 106, 97, 42})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static NativeDate()
    {
      IdScriptableObject.__\u003Cclinit\u003E();
      if (ByteCodeHelper.isAlreadyInited("rhino.NativeDate"))
        return;
      NativeDate.\u0024assertionsDisabled = !((Class) ClassLiteral<NativeDate>.Value).desiredAssertionStatus();
      NativeDate.DATE_TAG = (object) "Date";
      NativeDate.thisTimeZone = TimeZone.getDefault();
      NativeDate.LocalTZA = (double) NativeDate.thisTimeZone.getRawOffset();
      NativeDate.timeZoneFormatter = (DateFormat) new SimpleDateFormat("zzz");
      NativeDate.localeDateTimeFormatter = DateFormat.getDateTimeInstance(1, 1);
      NativeDate.localeDateFormatter = DateFormat.getDateInstance(1);
      NativeDate.localeTimeFormatter = DateFormat.getTimeInstance(1);
    }
  }
}
