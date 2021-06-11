// Decompiled with JetBrains decompiler
// Type: rhino.NativeNumber
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
  internal sealed class NativeNumber : IdScriptableObject
  {
    public const double MAX_SAFE_INTEGER = 9.00719925474099E+15;
    [Modifiers]
    private static object NUMBER_TAG;
    private const int MAX_PRECISION = 100;
    private const double MIN_SAFE_INTEGER = -9.00719925474099E+15;
    private const int ConstructorId_isFinite = -1;
    private const int ConstructorId_isNaN = -2;
    private const int ConstructorId_isInteger = -3;
    private const int ConstructorId_isSafeInteger = -4;
    private const int ConstructorId_parseFloat = -5;
    private const int ConstructorId_parseInt = -6;
    private const int Id_constructor = 1;
    private const int Id_toString = 2;
    private const int Id_toLocaleString = 3;
    private const int Id_toSource = 4;
    private const int Id_valueOf = 5;
    private const int Id_toFixed = 6;
    private const int Id_toExponential = 7;
    private const int Id_toPrecision = 8;
    private const int MAX_PROTOTYPE_ID = 8;
    [Modifiers]
    private double doubleValue;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {160, 166, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static object isFinite([In] object obj0)
    {
      double number = ScriptRuntime.toNumber(obj0);
      return (object) ScriptRuntime.wrapBoolean(!Double.isInfinite(number) && !Double.isNaN(number));
    }

    [LineNumberTable(new byte[] {159, 167, 104, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal NativeNumber([In] double obj0)
    {
      NativeNumber nativeNumber = this;
      this.doubleValue = obj0;
    }

    [LineNumberTable(new byte[] {160, 87, 159, 7, 115, 135, 138, 137, 167, 115, 135, 106, 143, 167, 115, 135, 106, 148, 167, 115, 135, 106, 148, 167, 167, 167})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private object execConstructorCall([In] int obj0, [In] object[] obj1)
    {
      switch (obj0)
      {
        case -6:
          return NativeGlobal.js_parseInt(obj1);
        case -5:
          return NativeGlobal.js_parseFloat(obj1);
        case -4:
          if (obj1.Length == 0 || object.ReferenceEquals(Undefined.__\u003C\u003Einstance, obj1[0]))
            return (object) Boolean.valueOf(false);
          return obj1[0] is Number ? (object) Boolean.valueOf(this.isSafeInteger((Number) obj1[0])) : (object) Boolean.valueOf(false);
        case -3:
          if (obj1.Length == 0 || object.ReferenceEquals(Undefined.__\u003C\u003Einstance, obj1[0]))
            return (object) Boolean.valueOf(false);
          return obj1[0] is Number ? (object) Boolean.valueOf(this.isInteger((Number) obj1[0])) : (object) Boolean.valueOf(false);
        case -2:
          if (obj1.Length == 0 || object.ReferenceEquals(Undefined.__\u003C\u003Einstance, obj1[0]))
            return (object) Boolean.valueOf(false);
          return obj1[0] is Number ? this.isNaN((Number) obj1[0]) : (object) Boolean.valueOf(false);
        case -1:
          if (obj1.Length == 0 || object.ReferenceEquals(Undefined.__\u003C\u003Einstance, obj1[0]))
            return (object) Boolean.valueOf(false);
          return obj1[0] is Number ? NativeNumber.isFinite(obj1[0]) : (object) Boolean.valueOf(false);
        default:
          string str = String.valueOf(obj0);
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalArgumentException(str);
      }
    }

    [LineNumberTable(new byte[] {160, 146, 100, 98, 197, 107, 114, 104, 37, 134, 145, 135, 102, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static string num_to(
      [In] double obj0,
      [In] object[] obj1,
      [In] int obj2,
      [In] int obj3,
      [In] int obj4,
      [In] int obj5)
    {
      int num;
      if (obj1.Length == 0)
      {
        num = 0;
        obj3 = obj2;
      }
      else
      {
        double integer = ScriptRuntime.toInteger(obj1[0]);
        num = integer >= (double) obj4 && integer <= 100.0 ? ScriptRuntime.toInt32(integer) : throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.constructError("RangeError", ScriptRuntime.getMessage1("msg.bad.precision", (object) ScriptRuntime.toString(obj1[0]))));
      }
      StringBuilder stringBuilder = new StringBuilder();
      DToA.JS_dtostr(stringBuilder, obj3, num + obj5, obj0);
      return stringBuilder.toString();
    }

    [LineNumberTable(new byte[] {160, 171, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private object isNaN([In] Number obj0) => (object) Boolean.valueOf(ScriptRuntime.toBoolean((object) Boolean.valueOf(this.isDoubleNan(this.doubleVal(obj0)))));

    [LineNumberTable(new byte[] {160, 180, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool isInteger([In] Number obj0) => ScriptRuntime.toBoolean((object) Boolean.valueOf(this.isDoubleInteger(this.doubleVal(obj0))));

    [LineNumberTable(new byte[] {160, 190, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool isSafeInteger([In] Number obj0) => ScriptRuntime.toBoolean((object) Boolean.valueOf(this.isDoubleSafeInteger(this.doubleVal(obj0))));

    [LineNumberTable(new byte[] {160, 201, 104, 135, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Double doubleVal([In] Number obj0) => obj0 is Double ? (Double) obj0 : Double.valueOf(obj0.doubleValue());

    [LineNumberTable(290)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool isDoubleNan([In] Double obj0) => obj0.isNaN();

    [LineNumberTable(new byte[] {160, 185, 113, 57})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool isDoubleInteger([In] Double obj0) => !obj0.isInfinite() && !obj0.isNaN() && Math.floor(obj0.doubleValue()) == obj0.doubleValue();

    [LineNumberTable(new byte[] {160, 195, 106, 114, 21})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool isDoubleSafeInteger([In] Double obj0) => this.isDoubleInteger(obj0) && obj0.doubleValue() <= 9.00719925474099E+15 && obj0.doubleValue() >= -9.00719925474099E+15;

    [LineNumberTable(new byte[] {159, 137, 98, 107, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static void init([In] Scriptable obj0, [In] bool obj1)
    {
      int num = obj1 ? 1 : 0;
      new NativeNumber(0.0).exportAsJSClass(8, obj0, num != 0);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string getClassName() => "Number";

    [LineNumberTable(new byte[] {159, 178, 194, 113, 111, 38, 165, 111, 38, 165, 111, 38, 165, 111, 38, 165, 111, 38, 165, 111, 38, 197, 115, 116, 116, 116, 116, 148, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void fillConstructorProperties([In] IdFunctionObject obj0)
    {
      obj0.defineProperty("NaN", (object) ScriptRuntime.__\u003C\u003ENaNobj, 7);
      obj0.defineProperty("POSITIVE_INFINITY", (object) ScriptRuntime.wrapNumber(double.PositiveInfinity), 7);
      obj0.defineProperty("NEGATIVE_INFINITY", (object) ScriptRuntime.wrapNumber(double.NegativeInfinity), 7);
      obj0.defineProperty("MAX_VALUE", (object) ScriptRuntime.wrapNumber(double.MaxValue), 7);
      obj0.defineProperty("MIN_VALUE", (object) ScriptRuntime.wrapNumber(double.Epsilon), 7);
      obj0.defineProperty("MAX_SAFE_INTEGER", (object) ScriptRuntime.wrapNumber(9.00719925474099E+15), 7);
      obj0.defineProperty("MIN_SAFE_INTEGER", (object) ScriptRuntime.wrapNumber(-9.00719925474099E+15), 7);
      this.addIdFunctionProperty((Scriptable) obj0, NativeNumber.NUMBER_TAG, -1, "isFinite", 1);
      this.addIdFunctionProperty((Scriptable) obj0, NativeNumber.NUMBER_TAG, -2, "isNaN", 1);
      this.addIdFunctionProperty((Scriptable) obj0, NativeNumber.NUMBER_TAG, -3, "isInteger", 1);
      this.addIdFunctionProperty((Scriptable) obj0, NativeNumber.NUMBER_TAG, -4, "isSafeInteger", 1);
      this.addIdFunctionProperty((Scriptable) obj0, NativeNumber.NUMBER_TAG, -5, "parseFloat", 1);
      this.addIdFunctionProperty((Scriptable) obj0, NativeNumber.NUMBER_TAG, -6, "parseInt", 1);
      base.fillConstructorProperties(obj0);
    }

    [LineNumberTable(new byte[] {24, 159, 14, 98, 102, 133, 98, 102, 133, 98, 102, 130, 98, 102, 130, 98, 102, 130, 98, 102, 130, 98, 102, 130, 98, 102, 130, 145, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void initPrototypeId([In] int obj0)
    {
      int arity;
      string name;
      switch (obj0)
      {
        case 1:
          arity = 1;
          name = "constructor";
          break;
        case 2:
          arity = 1;
          name = "toString";
          break;
        case 3:
          arity = 1;
          name = "toLocaleString";
          break;
        case 4:
          arity = 0;
          name = "toSource";
          break;
        case 5:
          arity = 0;
          name = "valueOf";
          break;
        case 6:
          arity = 1;
          name = "toFixed";
          break;
        case 7:
          arity = 1;
          name = "toExponential";
          break;
        case 8:
          arity = 1;
          name = "toPrecision";
          break;
        default:
          string str = String.valueOf(obj0);
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalArgumentException(str);
      }
      this.initPrototypeMethod(NativeNumber.NUMBER_TAG, obj0, name, arity);
    }

    [LineNumberTable(new byte[] {66, 109, 142, 103, 100, 106, 111, 132, 167, 135, 100, 234, 69, 105, 108, 141, 255, 10, 69, 125, 102, 200, 191, 11, 167, 115, 205, 104, 134, 104, 104, 134, 166, 237, 70, 117, 169, 104, 134, 104, 104, 134, 134, 237, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override object execIdCall(
      [In] IdFunctionObject obj0,
      [In] Context obj1,
      [In] Scriptable obj2,
      [In] Scriptable obj3,
      [In] object[] obj4)
    {
      if (!obj0.hasTag(NativeNumber.NUMBER_TAG))
        return base.execIdCall(obj0, obj1, obj2, obj3, obj4);
      int num1 = obj0.methodId();
      if (num1 == 1)
      {
        double x = obj4.Length < 1 ? 0.0 : ScriptRuntime.toNumber(obj4[0]);
        return obj3 == null ? (object) new NativeNumber(x) : (object) ScriptRuntime.wrapNumber(x);
      }
      if (num1 < 1)
        return this.execConstructorCall(num1, obj4);
      double num2 = obj3 is NativeNumber ? ((NativeNumber) obj3).doubleValue : throw Throwable.__\u003Cunmap\u003E((Exception) IdScriptableObject.incompatibleCallError(obj0));
      switch (num1)
      {
        case 2:
        case 3:
          int @base = obj4.Length == 0 || object.ReferenceEquals(obj4[0], Undefined.__\u003C\u003Einstance) ? 10 : ScriptRuntime.toInt32(obj4[0]);
          return (object) ScriptRuntime.numberToString(num2, @base);
        case 4:
          return (object) new StringBuilder().append("(new Number(").append(ScriptRuntime.toString(num2)).append("))").toString();
        case 5:
          return (object) ScriptRuntime.wrapNumber(num2);
        case 6:
          int num3 = obj1.version >= 200 ? 0 : -20;
          return (object) NativeNumber.num_to(num2, obj4, 2, 2, num3, 0);
        case 7:
          if (Double.isNaN(num2))
            return (object) "NaN";
          if (!Double.isInfinite(num2))
            return (object) NativeNumber.num_to(num2, obj4, 1, 3, 0, 1);
          return num2 >= 0.0 ? (object) "Infinity" : (object) "-Infinity";
        case 8:
          if (obj4.Length == 0 || object.ReferenceEquals(obj4[0], Undefined.__\u003C\u003Einstance))
            return (object) ScriptRuntime.numberToString(num2, 10);
          if (Double.isNaN(num2))
            return (object) "NaN";
          if (!Double.isInfinite(num2))
            return (object) NativeNumber.num_to(num2, obj4, 0, 4, 1, 0);
          return num2 >= 0.0 ? (object) "Infinity" : (object) "-Infinity";
        default:
          string str = String.valueOf(num1);
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalArgumentException(str);
      }
    }

    [LineNumberTable(252)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toString() => ScriptRuntime.numberToString(this.doubleValue, 10);

    [LineNumberTable(new byte[] {160, 216, 98, 162, 159, 19, 104, 101, 102, 103, 104, 102, 199, 104, 101, 102, 103, 101, 102, 196, 104, 101, 102, 100, 101, 102, 196, 102, 98, 130, 102, 162, 183})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override int findPrototypeId([In] string obj0)
    {
      int num = 0;
      string str = (string) null;
      switch (String.instancehelper_length(obj0))
      {
        case 7:
          switch (String.instancehelper_charAt(obj0, 0))
          {
            case 't':
              str = "toFixed";
              num = 6;
              break;
            case 'v':
              str = "valueOf";
              num = 5;
              break;
          }
          break;
        case 8:
          switch (String.instancehelper_charAt(obj0, 3))
          {
            case 'o':
              str = "toSource";
              num = 4;
              break;
            case 't':
              str = "toString";
              num = 2;
              break;
          }
          break;
        case 11:
          switch (String.instancehelper_charAt(obj0, 0))
          {
            case 'c':
              str = "constructor";
              num = 1;
              break;
            case 't':
              str = "toPrecision";
              num = 8;
              break;
          }
          break;
        case 13:
          str = "toExponential";
          num = 7;
          break;
        case 14:
          str = "toLocaleString";
          num = 3;
          break;
      }
      if (str != null && !object.ReferenceEquals((object) str, (object) obj0) && !String.instancehelper_equals(str, (object) obj0))
        num = 0;
      return num;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    static NativeNumber()
    {
      IdScriptableObject.__\u003Cclinit\u003E();
      if (ByteCodeHelper.isAlreadyInited("rhino.NativeNumber"))
        return;
      NativeNumber.NUMBER_TAG = (object) "Number";
    }
  }
}
