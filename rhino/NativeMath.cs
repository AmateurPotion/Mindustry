// Decompiled with JetBrains decompiler
// Type: rhino.NativeMath
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
  internal sealed class NativeMath : IdScriptableObject
  {
    [Modifiers]
    private static object MATH_TAG;
    private const double LOG2E = 1.44269504088896;
    private const int Id_toSource = 1;
    private const int Id_abs = 2;
    private const int Id_acos = 3;
    private const int Id_asin = 4;
    private const int Id_atan = 5;
    private const int Id_atan2 = 6;
    private const int Id_ceil = 7;
    private const int Id_cos = 8;
    private const int Id_exp = 9;
    private const int Id_floor = 10;
    private const int Id_log = 11;
    private const int Id_max = 12;
    private const int Id_min = 13;
    private const int Id_pow = 14;
    private const int Id_random = 15;
    private const int Id_round = 16;
    private const int Id_sin = 17;
    private const int Id_sqrt = 18;
    private const int Id_tan = 19;
    private const int Id_cbrt = 20;
    private const int Id_cosh = 21;
    private const int Id_expm1 = 22;
    private const int Id_hypot = 23;
    private const int Id_log1p = 24;
    private const int Id_log10 = 25;
    private const int Id_sinh = 26;
    private const int Id_tanh = 27;
    private const int Id_imul = 28;
    private const int Id_trunc = 29;
    private const int Id_acosh = 30;
    private const int Id_asinh = 31;
    private const int Id_atanh = 32;
    private const int Id_sign = 33;
    private const int Id_log2 = 34;
    private const int Id_fround = 35;
    private const int Id_clz32 = 36;
    private const int LAST_METHOD_ID = 36;
    private const int Id_E = 37;
    private const int Id_PI = 38;
    private const int Id_LN10 = 39;
    private const int Id_LN2 = 40;
    private const int Id_LOG2E = 41;
    private const int Id_LOG10E = 42;
    private const int Id_SQRT1_2 = 43;
    private const int Id_SQRT2 = 44;
    private const int MAX_ID = 44;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 173, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private NativeMath()
    {
    }

    [LineNumberTable(new byte[] {161, 179, 99, 134, 166, 98, 130, 117, 107, 105, 100, 105, 132, 235, 57, 232, 75, 99, 138, 99, 138})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static double js_hypot([In] object[] obj0)
    {
      if (obj0 == null)
        return 0.0;
      double num1 = 0.0;
      int num2 = 0;
      int num3 = 0;
      object[] objArray = obj0;
      int length = objArray.Length;
      for (int index = 0; index < length; ++index)
      {
        double number = ScriptRuntime.toNumber(objArray[index]);
        if (Double.isNaN(number))
          num2 = 1;
        else if (Double.isInfinite(number))
          num3 = 1;
        else
          num1 += number * number;
      }
      if (num3 != 0)
        return double.PositiveInfinity;
      return num2 != 0 ? double.NaN : Math.sqrt(num1);
    }

    [LineNumberTable(new byte[] {161, 214, 99, 162, 104, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static int js_imul([In] object[] obj0) => obj0 == null ? 0 : ScriptRuntime.toInt32(obj0, 0) * ScriptRuntime.toInt32(obj0, 1);

    [LineNumberTable(new byte[] {161, 125, 137, 104, 137, 107, 140, 112, 191, 0, 104, 110, 159, 1, 154, 133, 108, 171, 109, 118, 111, 124, 139, 109, 118, 107, 124, 143, 109, 127, 0, 109, 104, 142, 159, 1, 250, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static double js_pow([In] double obj0, [In] double obj1)
    {
      double num1;
      if (Double.isNaN(obj1))
        num1 = obj1;
      else if (obj1 == 0.0)
        num1 = 1.0;
      else if (obj0 == 0.0)
      {
        if (1.0 / obj0 > 0.0)
        {
          num1 = obj1 <= 0.0 ? double.PositiveInfinity : 0.0;
        }
        else
        {
          long num2 = ByteCodeHelper.d2l(obj1);
          num1 = (double) num2 != obj1 || (num2 & 1L) == 0L ? (obj1 <= 0.0 ? double.PositiveInfinity : 0.0) : (obj1 <= 0.0 ? double.NegativeInfinity : -0.0);
        }
      }
      else
      {
        num1 = Math.pow(obj0, obj1);
        if (Double.isNaN(num1))
        {
          if (obj1 == double.PositiveInfinity)
          {
            if (obj0 < -1.0 || 1.0 < obj0)
              num1 = double.PositiveInfinity;
            else if (-1.0 < obj0 && obj0 < 1.0)
              num1 = 0.0;
          }
          else if (obj1 == double.NegativeInfinity)
          {
            if (obj0 < -1.0 || 1.0 < obj0)
              num1 = 0.0;
            else if (-1.0 < obj0 && obj0 < 1.0)
              num1 = double.PositiveInfinity;
          }
          else if (obj0 == double.PositiveInfinity)
            num1 = obj1 <= 0.0 ? 0.0 : double.PositiveInfinity;
          else if (obj0 == double.NegativeInfinity)
          {
            long num2 = ByteCodeHelper.d2l(obj1);
            num1 = (double) num2 != obj1 || (num2 & 1L) == 0L ? (obj1 <= 0.0 ? 0.0 : double.PositiveInfinity) : (obj1 <= 0.0 ? -0.0 : double.NegativeInfinity);
          }
        }
      }
      return num1;
    }

    [LineNumberTable(579)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static double js_trunc([In] double obj0) => obj0 < 0.0 ? Math.ceil(obj0) : Math.floor(obj0);

    [LineNumberTable(new byte[] {159, 137, 66, 102, 104, 108, 103, 99, 134, 141})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static void init([In] Scriptable obj0, [In] bool obj1)
    {
      int num = obj1 ? 1 : 0;
      NativeMath nativeMath = new NativeMath();
      nativeMath.activatePrototypeMap(44);
      nativeMath.setPrototype(ScriptableObject.getObjectPrototype(obj0));
      nativeMath.setParentScope(obj0);
      if (num != 0)
        nativeMath.sealObject();
      ScriptableObject.defineProperty(obj0, "Math", (object) nativeMath, 2);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string getClassName() => "Math";

    [LineNumberTable(new byte[] {159, 183, 168, 159, 126, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 130, 98, 102, 130, 98, 102, 130, 98, 102, 130, 98, 102, 130, 98, 102, 130, 145, 111, 165, 159, 15, 106, 102, 133, 106, 102, 133, 106, 102, 133, 106, 102, 133, 106, 102, 130, 106, 102, 130, 106, 102, 130, 106, 102, 130, 145, 175})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void initPrototypeId([In] int obj0)
    {
      if (obj0 <= 36)
      {
        int arity;
        string name;
        switch (obj0 - 1)
        {
          case 0:
            arity = 0;
            name = "toSource";
            break;
          case 1:
            arity = 1;
            name = "abs";
            break;
          case 2:
            arity = 1;
            name = "acos";
            break;
          case 3:
            arity = 1;
            name = "asin";
            break;
          case 4:
            arity = 1;
            name = "atan";
            break;
          case 5:
            arity = 2;
            name = "atan2";
            break;
          case 6:
            arity = 1;
            name = "ceil";
            break;
          case 7:
            arity = 1;
            name = "cos";
            break;
          case 8:
            arity = 1;
            name = "exp";
            break;
          case 9:
            arity = 1;
            name = "floor";
            break;
          case 10:
            arity = 1;
            name = "log";
            break;
          case 11:
            arity = 2;
            name = "max";
            break;
          case 12:
            arity = 2;
            name = "min";
            break;
          case 13:
            arity = 2;
            name = "pow";
            break;
          case 14:
            arity = 0;
            name = "random";
            break;
          case 15:
            arity = 1;
            name = "round";
            break;
          case 16:
            arity = 1;
            name = "sin";
            break;
          case 17:
            arity = 1;
            name = "sqrt";
            break;
          case 18:
            arity = 1;
            name = "tan";
            break;
          case 19:
            arity = 1;
            name = "cbrt";
            break;
          case 20:
            arity = 1;
            name = "cosh";
            break;
          case 21:
            arity = 1;
            name = "expm1";
            break;
          case 22:
            arity = 2;
            name = "hypot";
            break;
          case 23:
            arity = 1;
            name = "log1p";
            break;
          case 24:
            arity = 1;
            name = "log10";
            break;
          case 25:
            arity = 1;
            name = "sinh";
            break;
          case 26:
            arity = 1;
            name = "tanh";
            break;
          case 27:
            arity = 2;
            name = "imul";
            break;
          case 28:
            arity = 1;
            name = "trunc";
            break;
          case 29:
            arity = 1;
            name = "acosh";
            break;
          case 30:
            arity = 1;
            name = "asinh";
            break;
          case 31:
            arity = 1;
            name = "atanh";
            break;
          case 32:
            arity = 1;
            name = "sign";
            break;
          case 33:
            arity = 1;
            name = "log2";
            break;
          case 34:
            arity = 1;
            name = "fround";
            break;
          case 35:
            arity = 1;
            name = "clz32";
            break;
          default:
            string str = String.valueOf(obj0);
            Throwable.__\u003CsuppressFillInStackTrace\u003E();
            throw new IllegalStateException(str);
        }
        this.initPrototypeMethod(NativeMath.MATH_TAG, obj0, name, arity);
      }
      else
      {
        double x;
        string name;
        switch (obj0 - 37)
        {
          case 0:
            x = Math.E;
            name = "E";
            break;
          case 1:
            x = Math.PI;
            name = "PI";
            break;
          case 2:
            x = 2.30258509299405;
            name = "LN10";
            break;
          case 3:
            x = 0.693147180559945;
            name = "LN2";
            break;
          case 4:
            x = 1.44269504088896;
            name = "LOG2E";
            break;
          case 5:
            x = 0.434294481903252;
            name = "LOG10E";
            break;
          case 6:
            x = 0.707106781186548;
            name = "SQRT1_2";
            break;
          case 7:
            x = 1.4142135623731;
            name = "SQRT2";
            break;
          default:
            string str = String.valueOf(obj0);
            Throwable.__\u003CsuppressFillInStackTrace\u003E();
            throw new IllegalStateException(str);
        }
        this.initPrototypeValue(obj0, name, (object) ScriptRuntime.wrapNumber(x), 7);
      }
    }

    [LineNumberTable(new byte[] {160, 127, 109, 174, 103, 159, 126, 166, 139, 125, 197, 107, 124, 155, 138, 165, 107, 104, 159, 1, 175, 107, 104, 135, 104, 104, 111, 139, 143, 159, 1, 175, 107, 105, 165, 107, 127, 0, 104, 111, 139, 143, 159, 10, 175, 107, 114, 165, 107, 105, 165, 107, 105, 165, 107, 105, 104, 103, 136, 103, 101, 136, 191, 13, 107, 124, 165, 107, 105, 165, 106, 165, 107, 159, 4, 104, 165, 107, 105, 165, 107, 105, 165, 139, 100, 165, 173, 139, 124, 165, 107, 105, 165, 107, 105, 165, 139, 127, 8, 197, 154, 104, 109, 105, 99, 130, 133, 141, 235, 54, 230, 77, 165, 107, 114, 165, 104, 165, 107, 150, 104, 102, 166, 104, 104, 104, 166, 197, 107, 104, 104, 111, 139, 143, 141, 175, 107, 124, 165, 107, 105, 165, 107, 105, 162, 107, 105, 162, 107, 105, 162, 107, 105, 162, 145})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override object execIdCall(
      [In] IdFunctionObject obj0,
      [In] Context obj1,
      [In] Scriptable obj2,
      [In] Scriptable obj3,
      [In] object[] obj4)
    {
      if (!obj0.hasTag(NativeMath.MATH_TAG))
        return base.execIdCall(obj0, obj1, obj2, obj3, obj4);
      int num1 = obj0.methodId();
      double x;
      switch (num1)
      {
        case 1:
          return (object) "Math";
        case 2:
          double number1 = ScriptRuntime.toNumber(obj4, 0);
          x = number1 != 0.0 ? (number1 >= 0.0 ? number1 : -number1) : 0.0;
          break;
        case 3:
        case 4:
          double number2 = ScriptRuntime.toNumber(obj4, 0);
          x = Double.isNaN(number2) || -1.0 > number2 || number2 > 1.0 ? double.NaN : (num1 != 3 ? Math.asin(number2) : Math.acos(number2));
          break;
        case 5:
          x = Math.atan(ScriptRuntime.toNumber(obj4, 0));
          break;
        case 6:
          x = Math.atan2(ScriptRuntime.toNumber(obj4, 0), ScriptRuntime.toNumber(obj4, 1));
          break;
        case 7:
          x = Math.ceil(ScriptRuntime.toNumber(obj4, 0));
          break;
        case 8:
          double number3 = ScriptRuntime.toNumber(obj4, 0);
          x = !Double.isInfinite(number3) ? Math.cos(number3) : double.NaN;
          break;
        case 9:
          double number4 = ScriptRuntime.toNumber(obj4, 0);
          x = number4 != double.PositiveInfinity ? (number4 != double.NegativeInfinity ? Math.exp(number4) : 0.0) : number4;
          break;
        case 10:
          x = Math.floor(ScriptRuntime.toNumber(obj4, 0));
          break;
        case 11:
          double number5 = ScriptRuntime.toNumber(obj4, 0);
          x = number5 >= 0.0 ? Math.log(number5) : double.NaN;
          break;
        case 12:
        case 13:
          x = num1 != 12 ? double.PositiveInfinity : double.NegativeInfinity;
          for (int index = 0; index != obj4.Length; ++index)
          {
            double number6 = ScriptRuntime.toNumber(obj4[index]);
            if (Double.isNaN(number6))
            {
              x = number6;
              break;
            }
            x = num1 != 12 ? Math.min(x, number6) : Math.max(x, number6);
          }
          break;
        case 14:
          x = NativeMath.js_pow(ScriptRuntime.toNumber(obj4, 0), ScriptRuntime.toNumber(obj4, 1));
          break;
        case 15:
          x = Math.random();
          break;
        case 16:
          x = ScriptRuntime.toNumber(obj4, 0);
          if (!Double.isNaN(x) && !Double.isInfinite(x))
          {
            long num2 = Math.round(x);
            if (num2 != 0L)
            {
              x = (double) num2;
              break;
            }
            if (x < 0.0)
            {
              x = ScriptRuntime.__\u003C\u003EnegativeZero;
              break;
            }
            if (x != 0.0)
            {
              x = 0.0;
              break;
            }
            break;
          }
          break;
        case 17:
          double number7 = ScriptRuntime.toNumber(obj4, 0);
          x = !Double.isInfinite(number7) ? Math.sin(number7) : double.NaN;
          break;
        case 18:
          x = Math.sqrt(ScriptRuntime.toNumber(obj4, 0));
          break;
        case 19:
          x = Math.tan(ScriptRuntime.toNumber(obj4, 0));
          break;
        case 20:
          x = Math.cbrt(ScriptRuntime.toNumber(obj4, 0));
          break;
        case 21:
          x = Math.cosh(ScriptRuntime.toNumber(obj4, 0));
          break;
        case 22:
          x = Math.expm1(ScriptRuntime.toNumber(obj4, 0));
          break;
        case 23:
          x = NativeMath.js_hypot(obj4);
          break;
        case 24:
          x = Math.log1p(ScriptRuntime.toNumber(obj4, 0));
          break;
        case 25:
          x = Math.log10(ScriptRuntime.toNumber(obj4, 0));
          break;
        case 26:
          x = Math.sinh(ScriptRuntime.toNumber(obj4, 0));
          break;
        case 27:
          x = Math.tanh(ScriptRuntime.toNumber(obj4, 0));
          break;
        case 28:
          return (object) Integer.valueOf(NativeMath.js_imul(obj4));
        case 29:
          x = NativeMath.js_trunc(ScriptRuntime.toNumber(obj4, 0));
          break;
        case 30:
          double number8 = ScriptRuntime.toNumber(obj4, 0);
          return !Double.isNaN(number8) ? (object) Double.valueOf(Math.log(number8 + Math.sqrt(number8 * number8 - 1.0))) : (object) Double.valueOf(double.NaN);
        case 31:
          double number9 = ScriptRuntime.toNumber(obj4, 0);
          if (Double.isInfinite(number9))
            return (object) Double.valueOf(number9);
          if (Double.isNaN(number9))
            return (object) Double.valueOf(double.NaN);
          if (number9 != 0.0)
            return (object) Double.valueOf(Math.log(number9 + Math.sqrt(number9 * number9 + 1.0)));
          return 1.0 / number9 > 0.0 ? (object) Double.valueOf(0.0) : (object) Double.valueOf(-0.0);
        case 32:
          double number10 = ScriptRuntime.toNumber(obj4, 0);
          if (Double.isNaN(number10) || -1.0 > number10 || number10 > 1.0)
            return (object) Double.valueOf(double.NaN);
          if (number10 != 0.0)
            return (object) Double.valueOf(0.5 * Math.log((number10 + 1.0) / (number10 - 1.0)));
          return 1.0 / number10 > 0.0 ? (object) Double.valueOf(0.0) : (object) Double.valueOf(-0.0);
        case 33:
          double number11 = ScriptRuntime.toNumber(obj4, 0);
          if (Double.isNaN(number11))
            return (object) Double.valueOf(double.NaN);
          if (number11 != 0.0)
            return (object) Double.valueOf(Math.signum(number11));
          return 1.0 / number11 > 0.0 ? (object) Double.valueOf(0.0) : (object) Double.valueOf(-0.0);
        case 34:
          double number12 = ScriptRuntime.toNumber(obj4, 0);
          x = number12 >= 0.0 ? Math.log(number12) * 1.44269504088896 : double.NaN;
          break;
        case 35:
          x = ScriptRuntime.toNumber(obj4, 0);
          break;
        case 36:
          double number13 = ScriptRuntime.toNumber(obj4, 0);
          if (number13 == 0.0 || Double.isNaN(number13) || Double.isInfinite(number13))
            return (object) Integer.valueOf(32);
          long uint32 = ScriptRuntime.toUint32(number13);
          return uint32 == 0L ? (object) Integer.valueOf(32) : (object) Double.valueOf(31.0 - Math.floor(Math.log((double) (long) ((ulong) uint32 >> 0)) * 1.44269504088896));
        default:
          string str = String.valueOf(num1);
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalStateException(str);
      }
      return (object) ScriptRuntime.wrapNumber(x);
    }

    [LineNumberTable(new byte[] {161, 231, 98, 162, 159, 19, 110, 99, 197, 124, 99, 197, 159, 78, 124, 99, 197, 124, 98, 197, 124, 98, 197, 124, 99, 197, 124, 99, 197, 104, 101, 110, 99, 133, 104, 110, 99, 229, 69, 124, 99, 197, 124, 99, 197, 124, 99, 197, 133, 159, 160, 81, 102, 99, 133, 102, 99, 133, 102, 99, 133, 102, 98, 133, 102, 98, 133, 104, 101, 124, 99, 133, 104, 124, 99, 229, 69, 102, 99, 133, 104, 101, 124, 99, 133, 104, 124, 99, 229, 69, 102, 99, 133, 102, 98, 133, 102, 98, 133, 133, 159, 92, 102, 99, 133, 102, 99, 133, 104, 101, 102, 104, 101, 102, 104, 104, 104, 101, 124, 98, 133, 104, 124, 99, 229, 70, 102, 99, 133, 102, 99, 133, 102, 99, 133, 102, 99, 133, 104, 101, 102, 104, 104, 102, 200, 102, 99, 133, 102, 99, 133, 133, 104, 101, 102, 101, 101, 102, 101, 101, 102, 197, 102, 99, 130, 102, 162, 183})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override int findPrototypeId([In] string obj0)
    {
      int num = 0;
      string str = (string) null;
      switch (String.instancehelper_length(obj0))
      {
        case 1:
          if (String.instancehelper_charAt(obj0, 0) == 'E')
          {
            num = 37;
            break;
          }
          goto default;
        case 2:
          if (String.instancehelper_charAt(obj0, 0) == 'P' && String.instancehelper_charAt(obj0, 1) == 'I')
          {
            num = 38;
            break;
          }
          goto default;
        case 3:
          switch (String.instancehelper_charAt(obj0, 0))
          {
            case 'L':
              if (String.instancehelper_charAt(obj0, 2) == '2' && String.instancehelper_charAt(obj0, 1) == 'N')
              {
                num = 40;
                break;
              }
              goto label_73;
            case 'a':
              if (String.instancehelper_charAt(obj0, 2) == 's' && String.instancehelper_charAt(obj0, 1) == 'b')
              {
                num = 2;
                break;
              }
              goto label_73;
            case 'c':
              if (String.instancehelper_charAt(obj0, 2) == 's' && String.instancehelper_charAt(obj0, 1) == 'o')
              {
                num = 8;
                break;
              }
              goto label_73;
            case 'e':
              if (String.instancehelper_charAt(obj0, 2) == 'p' && String.instancehelper_charAt(obj0, 1) == 'x')
              {
                num = 9;
                break;
              }
              goto label_73;
            case 'l':
              if (String.instancehelper_charAt(obj0, 2) == 'g' && String.instancehelper_charAt(obj0, 1) == 'o')
              {
                num = 11;
                break;
              }
              goto label_73;
            case 'm':
              switch (String.instancehelper_charAt(obj0, 2))
              {
                case 'n':
                  if (String.instancehelper_charAt(obj0, 1) == 'i')
                  {
                    num = 13;
                    break;
                  }
                  goto label_73;
                case 'x':
                  if (String.instancehelper_charAt(obj0, 1) == 'a')
                  {
                    num = 12;
                    break;
                  }
                  goto label_73;
                default:
                  goto label_73;
              }
              break;
            case 'p':
              if (String.instancehelper_charAt(obj0, 2) == 'w' && String.instancehelper_charAt(obj0, 1) == 'o')
              {
                num = 14;
                break;
              }
              goto label_73;
            case 's':
              if (String.instancehelper_charAt(obj0, 2) == 'n' && String.instancehelper_charAt(obj0, 1) == 'i')
              {
                num = 17;
                break;
              }
              goto label_73;
            case 't':
              if (String.instancehelper_charAt(obj0, 2) == 'n' && String.instancehelper_charAt(obj0, 1) == 'a')
              {
                num = 19;
                break;
              }
              goto label_73;
            default:
              goto label_73;
          }
          break;
        case 4:
          switch (String.instancehelper_charAt(obj0, 1))
          {
            case 'N':
              str = "LN10";
              num = 39;
              goto label_73;
            case 'a':
              str = "tanh";
              num = 27;
              goto label_73;
            case 'b':
              str = "cbrt";
              num = 20;
              goto label_73;
            case 'c':
              str = "acos";
              num = 3;
              goto label_73;
            case 'e':
              str = "ceil";
              num = 7;
              goto label_73;
            case 'i':
              switch (String.instancehelper_charAt(obj0, 3))
              {
                case 'h':
                  if (String.instancehelper_charAt(obj0, 0) == 's' && String.instancehelper_charAt(obj0, 2) == 'n')
                  {
                    num = 26;
                    break;
                  }
                  goto label_73;
                case 'n':
                  if (String.instancehelper_charAt(obj0, 0) == 's' && String.instancehelper_charAt(obj0, 2) == 'g')
                  {
                    num = 33;
                    break;
                  }
                  goto label_73;
                default:
                  goto label_73;
              }
              break;
            case 'm':
              str = "imul";
              num = 28;
              goto label_73;
            case 'o':
              switch (String.instancehelper_charAt(obj0, 0))
              {
                case 'c':
                  if (String.instancehelper_charAt(obj0, 2) == 's' && String.instancehelper_charAt(obj0, 3) == 'h')
                  {
                    num = 21;
                    break;
                  }
                  goto label_73;
                case 'l':
                  if (String.instancehelper_charAt(obj0, 2) == 'g' && String.instancehelper_charAt(obj0, 3) == '2')
                  {
                    num = 34;
                    break;
                  }
                  goto label_73;
                default:
                  goto label_73;
              }
              break;
            case 'q':
              str = "sqrt";
              num = 18;
              goto label_73;
            case 's':
              str = "asin";
              num = 4;
              goto label_73;
            case 't':
              str = "atan";
              num = 5;
              goto label_73;
            default:
              goto label_73;
          }
        case 5:
          switch (String.instancehelper_charAt(obj0, 0))
          {
            case 'L':
              str = "LOG2E";
              num = 41;
              goto label_73;
            case 'S':
              str = "SQRT2";
              num = 44;
              goto label_73;
            case 'a':
              switch (String.instancehelper_charAt(obj0, 1))
              {
                case 'c':
                  str = "acosh";
                  num = 30;
                  goto label_73;
                case 's':
                  str = "asinh";
                  num = 31;
                  goto label_73;
                case 't':
                  switch (String.instancehelper_charAt(obj0, 4))
                  {
                    case '2':
                      if (String.instancehelper_charAt(obj0, 2) == 'a' && String.instancehelper_charAt(obj0, 3) == 'n')
                      {
                        num = 6;
                        break;
                      }
                      goto label_73;
                    case 'h':
                      if (String.instancehelper_charAt(obj0, 2) == 'a' && String.instancehelper_charAt(obj0, 3) == 'n')
                      {
                        num = 32;
                        break;
                      }
                      goto label_73;
                    default:
                      goto label_73;
                  }
                  break;
                default:
                  goto label_73;
              }
            case 'c':
              str = "clz32";
              num = 36;
              goto label_73;
            case 'e':
              str = "expm1";
              num = 22;
              goto label_73;
            case 'f':
              str = "floor";
              num = 10;
              goto label_73;
            case 'h':
              str = "hypot";
              num = 23;
              goto label_73;
            case 'l':
              switch (String.instancehelper_charAt(obj0, 4))
              {
                case '0':
                  str = "log10";
                  num = 25;
                  goto label_73;
                case 'p':
                  str = "log1p";
                  num = 24;
                  goto label_73;
                default:
                  goto label_73;
              }
            case 'r':
              str = "round";
              num = 16;
              goto label_73;
            case 't':
              str = "trunc";
              num = 29;
              goto label_73;
            default:
              goto label_73;
          }
        case 6:
          switch (String.instancehelper_charAt(obj0, 0))
          {
            case 'L':
              str = "LOG10E";
              num = 42;
              goto label_73;
            case 'f':
              str = "fround";
              num = 35;
              goto label_73;
            case 'r':
              str = "random";
              num = 15;
              goto label_73;
            default:
              goto label_73;
          }
        case 7:
          str = "SQRT1_2";
          num = 43;
          goto default;
        case 8:
          str = "toSource";
          num = 1;
          goto default;
        default:
label_73:
          if (str != null && !object.ReferenceEquals((object) str, (object) obj0) && !String.instancehelper_equals(str, (object) obj0))
          {
            num = 0;
            break;
          }
          break;
      }
      return num;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    static NativeMath()
    {
      IdScriptableObject.__\u003Cclinit\u003E();
      if (ByteCodeHelper.isAlreadyInited("rhino.NativeMath"))
        return;
      NativeMath.MATH_TAG = (object) "Math";
    }
  }
}
