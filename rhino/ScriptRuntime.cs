// Decompiled with JetBrains decompiler
// Type: rhino.ScriptRuntime
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.text;
using java.util;
using rhino.v8dtoa;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace rhino
{
  public class ScriptRuntime : Object
  {
    [Signature("Ljava/lang/Class<*>;")]
    internal static Class __\u003C\u003EBooleanClass;
    [Signature("Ljava/lang/Class<*>;")]
    internal static Class __\u003C\u003EByteClass;
    [Signature("Ljava/lang/Class<*>;")]
    internal static Class __\u003C\u003ECharacterClass;
    [Signature("Ljava/lang/Class<*>;")]
    internal static Class __\u003C\u003EClassClass;
    [Signature("Ljava/lang/Class<*>;")]
    internal static Class __\u003C\u003EDoubleClass;
    [Signature("Ljava/lang/Class<*>;")]
    internal static Class __\u003C\u003EFloatClass;
    [Signature("Ljava/lang/Class<*>;")]
    internal static Class __\u003C\u003EIntegerClass;
    [Signature("Ljava/lang/Class<*>;")]
    internal static Class __\u003C\u003ELongClass;
    [Signature("Ljava/lang/Class<*>;")]
    internal static Class __\u003C\u003ENumberClass;
    [Signature("Ljava/lang/Class<*>;")]
    internal static Class __\u003C\u003EObjectClass;
    [Signature("Ljava/lang/Class<*>;")]
    internal static Class __\u003C\u003EShortClass;
    [Signature("Ljava/lang/Class<*>;")]
    internal static Class __\u003C\u003EStringClass;
    [Signature("Ljava/lang/Class<*>;")]
    internal static Class __\u003C\u003EDateClass;
    [Signature("Ljava/lang/Class<*>;")]
    internal static Class __\u003C\u003EContextClass;
    [Signature("Ljava/lang/Class<*>;")]
    internal static Class __\u003C\u003EContextFactoryClass;
    [Signature("Ljava/lang/Class<*>;")]
    internal static Class __\u003C\u003EFunctionClass;
    [Signature("Ljava/lang/Class<*>;")]
    internal static Class __\u003C\u003EScriptableObjectClass;
    [Signature("Ljava/lang/Class<Lrhino/Scriptable;>;")]
    internal static Class __\u003C\u003EScriptableClass;
    [Modifiers]
    private static object LIBRARY_SCOPE_KEY;
    public const double NaN = double.NaN;
    internal static double __\u003C\u003EnegativeZero;
    internal static Double __\u003C\u003ENaNobj;
    private const string DEFAULT_NS_TAG = "__default_namespace__";
    public const int ENUMERATE_KEYS = 0;
    public const int ENUMERATE_VALUES = 1;
    public const int ENUMERATE_ARRAY = 2;
    public const int ENUMERATE_KEYS_NO_ITERATOR = 3;
    public const int ENUMERATE_VALUES_NO_ITERATOR = 4;
    public const int ENUMERATE_ARRAY_NO_ITERATOR = 5;
    public const int ENUMERATE_VALUES_IN_ORDER = 6;
    internal static ScriptRuntime.MessageProvider __\u003C\u003EmessageProvider;
    internal static object[] __\u003C\u003EemptyArgs;
    internal static string[] __\u003C\u003EemptyStrings;
    [SpecialName]
    private static CallerID __\u003CcallerID\u003E;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(1170)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static long toUint32(object val) => ScriptRuntime.toUint32(ScriptRuntime.toNumber(val));

    [LineNumberTable(new byte[] {173, 244, 104, 103, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void setBuiltinProtoAndParent(
      ScriptableObject @object,
      Scriptable scope,
      TopLevel.Builtins type)
    {
      scope = ScriptableObject.getTopLevelScope(scope);
      @object.setParentScope(scope);
      @object.setPrototype(TopLevel.getBuiltinPrototype(scope, type));
    }

    [LineNumberTable(new byte[] {163, 218, 104, 105, 99, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static Scriptable newNativeError(
      [In] Context obj0,
      [In] Scriptable obj1,
      [In] TopLevel.NativeErrors obj2,
      [In] object[] obj3)
    {
      obj1 = ScriptableObject.getTopLevelScope(obj1);
      Function nativeErrorCtor = TopLevel.getNativeErrorCtor(obj0, obj1, obj2);
      if (obj3 == null)
        obj3 = ScriptRuntime.__\u003C\u003EemptyArgs;
      return nativeErrorCtor.construct(obj0, obj1, obj3);
    }

    [LineNumberTable(new byte[] {175, 14, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static EcmaError typeError0(string messageId) => ScriptRuntime.typeError(ScriptRuntime.getMessage0(messageId));

    [LineNumberTable(new byte[] {175, 19, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static EcmaError typeError1(string messageId, object arg1) => ScriptRuntime.typeError(ScriptRuntime.getMessage1(messageId, arg1));

    [LineNumberTable(new byte[] {171, 240, 135, 99, 107, 169})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool jsDelegatesTo(Scriptable lhs, Scriptable rhs)
    {
      for (Scriptable prototype = lhs.getPrototype(); prototype != null; prototype = prototype.getPrototype())
      {
        if (Object.instancehelper_equals((object) prototype, (object) rhs))
          return true;
      }
      return false;
    }

    [LineNumberTable(new byte[] {165, 19, 104, 143, 104, 104, 103, 104, 98, 205, 109, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object getObjectElem(Scriptable obj, object elem, Context cx)
    {
      object objA;
      if (ScriptRuntime.isSymbol(elem))
      {
        objA = ScriptableObject.getProperty(obj, (Symbol) elem);
      }
      else
      {
        ScriptRuntime.StringIdOrIndex stringIdOrIndex = ScriptRuntime.toStringIdOrIndex(cx, elem);
        if (stringIdOrIndex.stringId == null)
        {
          int index = stringIdOrIndex.index;
          objA = ScriptableObject.getProperty(obj, index);
        }
        else
          objA = ScriptableObject.getProperty(obj, stringIdOrIndex.stringId);
      }
      if (object.ReferenceEquals(objA, Scriptable.NOT_FOUND))
        objA = Undefined.__\u003C\u003Einstance;
      return objA;
    }

    [LineNumberTable(4016)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static RuntimeException notFunctionError(object value) => ScriptRuntime.notFunctionError(value, value);

    [LineNumberTable(new byte[] {160, 235, 104, 108, 112, 98, 104, 127, 0, 104, 110, 149, 104, 110, 103, 130, 140, 162, 114, 118, 177, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool toBoolean(object val)
    {
      while (!(val is Boolean))
      {
        if (val == null || object.ReferenceEquals(val, Undefined.__\u003C\u003Einstance))
          return false;
        if (CharSequence.IsInstance(val))
        {
          object obj1 = val;
          CharSequence.Cast(obj1);
          object obj2 = obj1;
          CharSequence charSequence;
          charSequence.__\u003Cref\u003E = (__Null) obj2;
          return ((CharSequence) ref charSequence).length() != 0;
        }
        switch (val)
        {
          case Number _:
            double num = ((Number) val).doubleValue();
            return !Double.isNaN(num) && num != 0.0;
          case Scriptable _:
            if (val is ScriptableObject && ((ScriptableObject) val).avoidObjectDetection())
              return false;
            if (Context.getContext().isVersionECMA1())
              return true;
            val = ((Scriptable) val).getDefaultValue(ScriptRuntime.__\u003C\u003EBooleanClass);
            if (val is Scriptable && !ScriptRuntime.isSymbol(val))
              throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.errorWithClassName("msg.primitive.expected", val));
            continue;
          default:
            ScriptRuntime.warnAboutNonJSObject(val);
            return true;
        }
      }
      return ((Boolean) val).booleanValue();
    }

    [LineNumberTable(new byte[] {171, 184, 105, 104, 162, 110, 141, 125, 159, 26, 104, 107, 155, 104, 107, 146, 104, 104, 136, 104, 112, 191, 3, 102, 142})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool shallowEq(object x, object y)
    {
      if (object.ReferenceEquals(x, y))
        return !(x is Number) || !Double.isNaN(((Number) x).doubleValue());
      if (x == null || object.ReferenceEquals(x, Undefined.__\u003C\u003Einstance) || object.ReferenceEquals(x, (object) Undefined.__\u003C\u003ESCRIPTABLE_UNDEFINED))
        return object.ReferenceEquals(x, Undefined.__\u003C\u003Einstance) && object.ReferenceEquals(y, (object) Undefined.__\u003C\u003ESCRIPTABLE_UNDEFINED) || object.ReferenceEquals(x, (object) Undefined.__\u003C\u003ESCRIPTABLE_UNDEFINED) && object.ReferenceEquals(y, Undefined.__\u003C\u003Einstance);
      if (x is Number)
      {
        if (y is Number)
          return ((Number) x).doubleValue() == ((Number) y).doubleValue();
      }
      else if (CharSequence.IsInstance(x))
      {
        if (CharSequence.IsInstance(y))
          return String.instancehelper_equals(Object.instancehelper_toString(x), (object) Object.instancehelper_toString(y));
      }
      else
      {
        switch (x)
        {
          case Boolean _:
            if (y is Boolean)
              return Object.instancehelper_equals(x, y);
            break;
          case Scriptable _:
            if (x is Wrapper && y is Wrapper && object.ReferenceEquals(((Wrapper) x).unwrap(), ((Wrapper) y).unwrap()))
              return true;
            break;
          default:
            ScriptRuntime.warnAboutNonJSObject(x);
            return object.ReferenceEquals(x, y);
        }
      }
      return false;
    }

    [LineNumberTable(new byte[] {169, 208, 99, 102, 109, 102, 104, 108, 104, 117, 104, 102, 104, 102, 104, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static string @typeof(object value)
    {
      if (value == null)
        return "object";
      if (object.ReferenceEquals(value, Undefined.__\u003C\u003Einstance))
        return "undefined";
      if (value is ScriptableObject)
        return ((ScriptableObject) value).getTypeOf();
      if (value is Scriptable)
        return value is Callable ? "function" : "object";
      if (CharSequence.IsInstance(value))
        return "string";
      switch (value)
      {
        case Number _:
          return "number";
        case Boolean _:
          return "boolean";
        default:
          throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.errorWithClassName("msg.invalid.type", value));
      }
    }

    [LineNumberTable(new byte[] {175, 68, 107, 102, 109, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static RuntimeException notFunctionError(
      object value,
      object messageHelper)
    {
      string str = messageHelper != null ? Object.instancehelper_toString(messageHelper) : "null";
      return object.ReferenceEquals(value, Scriptable.NOT_FOUND) ? (RuntimeException) ScriptRuntime.typeError1("msg.function.not.found", (object) str) : (RuntimeException) ScriptRuntime.typeError2("msg.isnt.function", (object) str, (object) ScriptRuntime.@typeof(value));
    }

    [LineNumberTable(new byte[] {164, 229, 104, 110, 103, 101, 135, 172, 104, 137, 135, 103, 101, 136})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static ScriptRuntime.StringIdOrIndex toStringIdOrIndex(
      [In] Context obj0,
      [In] object obj1)
    {
      string str;
      switch (obj1)
      {
        case Number _:
          double num1 = ((Number) obj1).doubleValue();
          int num2 = ByteCodeHelper.d2i(num1);
          return (double) num2 == num1 ? new ScriptRuntime.StringIdOrIndex(num2) : new ScriptRuntime.StringIdOrIndex(ScriptRuntime.toString(obj1));
        case string _:
          str = (string) obj1;
          break;
        default:
          str = ScriptRuntime.toString(obj1);
          break;
      }
      long num3 = ScriptRuntime.indexFromString(str);
      return num3 >= 0L ? new ScriptRuntime.StringIdOrIndex((int) num3) : new ScriptRuntime.StringIdOrIndex(str);
    }

    [LineNumberTable(new byte[] {174, 235, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static EcmaError constructError(string error, string message)
    {
      int[] numArray = new int[1];
      string positionFromStack = Context.getSourcePositionFromStack(numArray);
      return ScriptRuntime.constructError(error, message, positionFromStack, numArray[0], (string) null, 0);
    }

    [LineNumberTable(4132)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static bool isSymbol([In] object obj0) => obj0 is NativeSymbol && ((NativeSymbol) obj0).isSymbol() || obj0 is SymbolKey;

    [LineNumberTable(332)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Integer wrapInt(int i) => Integer.valueOf(i);

    [LineNumberTable(1154)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int toInt32(object[] args, int index) => index < args.Length ? ScriptRuntime.toInt32(args[index]) : 0;

    [LineNumberTable(new byte[] {164, 9, 104, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int toInt32(object val) => val is Integer ? ((Integer) val).intValue() : ScriptRuntime.toInt32(ScriptRuntime.toNumber(val));

    [LineNumberTable(new byte[] {157, 29, 130, 100, 135, 98, 99, 106, 142, 191, 4, 109, 199, 131, 112, 169, 100, 137, 106, 206})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object applyOrCall(
      bool isApply,
      Context cx,
      Scriptable scope,
      Scriptable thisObj,
      object[] args)
    {
      int num = isApply ? 1 : 0;
      int length = args.Length;
      Callable callable = ScriptRuntime.getCallable(thisObj);
      Scriptable s2 = (Scriptable) null;
      if (length != 0)
        s2 = !cx.hasFeature(15) ? (!object.ReferenceEquals(args[0], Undefined.__\u003C\u003Einstance) ? ScriptRuntime.toObjectOrNull(cx, args[0], scope) : Undefined.__\u003C\u003ESCRIPTABLE_UNDEFINED) : ScriptRuntime.toObjectOrNull(cx, args[0], scope);
      if (s2 == null && cx.hasFeature(15))
        s2 = ScriptRuntime.getTopCallScope(cx);
      object[] objarr;
      if (num != 0)
        objarr = length > 1 ? ScriptRuntime.getApplyArguments(cx, args[1]) : ScriptRuntime.__\u003C\u003EemptyArgs;
      else if (length <= 1)
      {
        objarr = ScriptRuntime.__\u003C\u003EemptyArgs;
      }
      else
      {
        objarr = new object[length - 1];
        ByteCodeHelper.arraycopy((object) args, 1, (object) objarr, 0, length - 1);
      }
      return callable.call(cx, scope, s2, objarr);
    }

    [LineNumberTable(new byte[] {163, 142, 104, 103, 112, 137})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Scriptable toObjectOrNull(Context cx, object obj, Scriptable scope)
    {
      if (obj is Scriptable)
        return (Scriptable) obj;
      return obj != null && !object.ReferenceEquals(obj, Undefined.__\u003C\u003Einstance) ? ScriptRuntime.toObject(cx, scope, obj) : (Scriptable) null;
    }

    [LineNumberTable(new byte[] {172, 245, 103, 99, 110, 98, 137})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static NativeCall findFunctionActivation([In] Context obj0, [In] Function obj1)
    {
      for (NativeCall nativeCall = obj0.currentActivationCall; nativeCall != null; nativeCall = nativeCall.parentActivationCall)
      {
        if (object.ReferenceEquals((object) nativeCall.function, (object) obj1))
          return nativeCall;
      }
      return (NativeCall) null;
    }

    [LineNumberTable(new byte[] {162, 198, 99, 134, 122, 134, 104, 135, 104, 135, 168, 148, 104, 144, 104, 114, 118, 209})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static string toString(object val)
    {
      while (val != null)
      {
        if (object.ReferenceEquals(val, Undefined.__\u003C\u003Einstance) || object.ReferenceEquals(val, (object) Undefined.__\u003C\u003ESCRIPTABLE_UNDEFINED))
          return "undefined";
        if (val is string)
          return (string) val;
        if (CharSequence.IsInstance(val))
          return Object.instancehelper_toString(val);
        switch (val)
        {
          case Number _:
            return ScriptRuntime.numberToString(((Number) val).doubleValue(), 10);
          case Symbol _:
            throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.typeError0("msg.not.a.string"));
          case Scriptable _:
            val = ((Scriptable) val).getDefaultValue(ScriptRuntime.__\u003C\u003EStringClass);
            if (val is Scriptable && !ScriptRuntime.isSymbol(val))
              throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.errorWithClassName("msg.primitive.expected", val));
            continue;
          default:
            return Object.instancehelper_toString(val);
        }
      }
      return "null";
    }

    [LineNumberTable(new byte[] {155, 138, 130, 99, 159, 9})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static string makeUrlForGeneratedScript([In] bool obj0, [In] string obj1, [In] int obj2) => obj0 ? new StringBuilder().append(obj1).append('#').append(obj2).append("(eval)").toString() : new StringBuilder().append(obj1).append('#').append(obj2).append("(Function)").toString();

    [LineNumberTable(new byte[] {161, 16, 104, 109, 99, 102, 109, 106, 104, 109, 104, 109, 104, 122, 104, 112, 104, 114, 118, 177, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static double toNumber(object val)
    {
      while (!(val is Number))
      {
        if (val == null)
          return 0.0;
        if (object.ReferenceEquals(val, Undefined.__\u003C\u003Einstance))
          return double.NaN;
        if (val is string)
          return ScriptRuntime.toNumber((string) val);
        if (CharSequence.IsInstance(val))
          return ScriptRuntime.toNumber(Object.instancehelper_toString(val));
        switch (val)
        {
          case Boolean _:
            return ((Boolean) val).booleanValue() ? 1.0 : 0.0;
          case Symbol _:
            throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.typeError0("msg.not.a.number"));
          case Scriptable _:
            val = ((Scriptable) val).getDefaultValue(ScriptRuntime.__\u003C\u003ENumberClass);
            if (val is Scriptable && !ScriptRuntime.isSymbol(val))
              throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.errorWithClassName("msg.primitive.expected", val));
            continue;
          default:
            ScriptRuntime.warnAboutNonJSObject(val);
            return double.NaN;
        }
      }
      return ((Number) val).doubleValue();
    }

    [LineNumberTable(new byte[] {173, 217, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void setFunctionProtoAndParent(BaseFunction fn, Scriptable scope) => ScriptRuntime.setFunctionProtoAndParent(fn, scope, false);

    [LineNumberTable(new byte[] {159, 181, 104, 230, 75, 108, 102, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static BaseFunction typeErrorThrower(Context cx)
    {
      if (cx.typeErrorThrower == null)
      {
        ScriptRuntime.\u0031 obj = new ScriptRuntime.\u0031();
        ScriptRuntime.setFunctionProtoAndParent((BaseFunction) obj, cx.topCallScope);
        obj.preventExtensions();
        cx.typeErrorThrower = (BaseFunction) obj;
      }
      return cx.typeErrorThrower;
    }

    [LineNumberTable(new byte[] {172, 86, 103, 99, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Scriptable getTopCallScope(Context cx)
    {
      Scriptable topCallScope = cx.topCallScope;
      if (topCallScope == null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalStateException();
      }
      return topCallScope;
    }

    [LineNumberTable(new byte[] {175, 120, 103, 99, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static RegExpProxy checkRegExpProxy(Context cx) => ScriptRuntime.getRegExpProxy(cx) ?? throw Throwable.__\u003Cunmap\u003E((Exception) Context.reportRuntimeError0("msg.no.regexp"));

    [LineNumberTable(3850)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static string getMessage0(string messageId) => ScriptRuntime.getMessage(messageId, (object[]) null);

    [LineNumberTable(new byte[] {174, 156, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static string getMessage1(string messageId, object arg1)
    {
      object[] arguments = new object[1]{ arg1 };
      return ScriptRuntime.getMessage(messageId, arguments);
    }

    [LineNumberTable(new byte[] {174, 162, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static string getMessage2(string messageId, object arg1, object arg2)
    {
      object[] arguments = new object[2]{ arg1, arg2 };
      return ScriptRuntime.getMessage(messageId, arguments);
    }

    [LineNumberTable(new byte[] {174, 168, 115})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static string getMessage3(string messageId, object arg1, object arg2, object arg3)
    {
      object[] arguments = new object[3]{ arg1, arg2, arg3 };
      return ScriptRuntime.getMessage(messageId, arguments);
    }

    [LineNumberTable(new byte[] {174, 174, 120})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static string getMessage4(
      string messageId,
      object arg1,
      object arg2,
      object arg3,
      object arg4)
    {
      object[] arguments = new object[4]
      {
        arg1,
        arg2,
        arg3,
        arg4
      };
      return ScriptRuntime.getMessage(messageId, arguments);
    }

    [LineNumberTable(new byte[] {159, 81, 162, 137, 147, 147, 147, 179, 119, 48, 232, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static ScriptableObject initStandardObjects(
      Context cx,
      ScriptableObject scope,
      bool @sealed)
    {
      int num = @sealed ? 1 : 0;
      ScriptableObject scriptableObject = ScriptRuntime.initSafeStandardObjects(cx, scope, num != 0);
      LazilyLoadedCtor lazilyLoadedCtor1 = new LazilyLoadedCtor(scriptableObject, "Packages", "rhino.NativeJavaTopPackage", num != 0, true);
      LazilyLoadedCtor lazilyLoadedCtor2 = new LazilyLoadedCtor(scriptableObject, "getClass", "rhino.NativeJavaTopPackage", num != 0, true);
      LazilyLoadedCtor lazilyLoadedCtor3 = new LazilyLoadedCtor(scriptableObject, "JavaAdapter", "rhino.JavaAdapter", num != 0, true);
      LazilyLoadedCtor lazilyLoadedCtor4 = new LazilyLoadedCtor(scriptableObject, "JavaImporter", "rhino.ImporterTopLevel", num != 0, true);
      string[] topPackageNames = ScriptRuntime.getTopPackageNames();
      int length = topPackageNames.Length;
      for (int index = 0; index < length; ++index)
      {
        string str = topPackageNames[index];
        LazilyLoadedCtor lazilyLoadedCtor5 = new LazilyLoadedCtor(scriptableObject, str, "rhino.NativeJavaTopPackage", num != 0, true);
      }
      return scriptableObject;
    }

    [LineNumberTable(new byte[] {159, 108, 98, 99, 135, 109, 140, 103, 135, 167, 108, 167, 104, 167, 103, 136, 103, 201, 138, 103, 103, 103, 103, 103, 135, 103, 103, 135, 136, 103, 167, 147, 179, 112, 104, 111, 179, 179, 179, 179, 179, 179, 179, 179, 179, 179, 243, 69, 109, 104, 108, 108, 104, 104, 103, 167, 104, 173})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static ScriptableObject initSafeStandardObjects(
      Context cx,
      ScriptableObject scope,
      bool @sealed)
    {
      int num = @sealed ? 1 : 0;
      if (scope == null)
        scope = (ScriptableObject) new NativeObject();
      scope.associateValue(ScriptRuntime.LIBRARY_SCOPE_KEY, (object) scope);
      new ClassCache().associate(scope);
      BaseFunction.init((Scriptable) scope, num != 0);
      NativeObject.init((Scriptable) scope, num != 0);
      Scriptable objectPrototype = ScriptableObject.getObjectPrototype((Scriptable) scope);
      ScriptableObject.getClassPrototype((Scriptable) scope, "Function").setPrototype(objectPrototype);
      if (scope.getPrototype() == null)
        scope.setPrototype(objectPrototype);
      NativeError.init((Scriptable) scope, num != 0);
      NativeGlobal.init(cx, (Scriptable) scope, num != 0);
      NativeArray.init((Scriptable) scope, num != 0);
      if (cx.getOptimizationLevel() > 0)
        NativeArray.setMaximumInitialCapacity(200000);
      NativeString.init((Scriptable) scope, num != 0);
      NativeBoolean.init((Scriptable) scope, num != 0);
      NativeNumber.init((Scriptable) scope, num != 0);
      NativeDate.init((Scriptable) scope, num != 0);
      NativeMath.init((Scriptable) scope, num != 0);
      NativeJSON.init((Scriptable) scope, num != 0);
      NativeWith.init((Scriptable) scope, num != 0);
      NativeCall.init((Scriptable) scope, num != 0);
      NativeScript.init((Scriptable) scope, num != 0);
      NativeIterator.init(cx, scope, num != 0);
      NativeArrayIterator.init(scope, num != 0);
      NativeStringIterator.init(scope, num != 0);
      LazilyLoadedCtor lazilyLoadedCtor1 = new LazilyLoadedCtor(scope, "RegExp", "rhino.regexp.NativeRegExp", num != 0, true);
      LazilyLoadedCtor lazilyLoadedCtor2 = new LazilyLoadedCtor(scope, "Continuation", "rhino.NativeContinuation", num != 0, true);
      if (cx.getLanguageVersion() >= 180 && cx.hasFeature(14) || cx.getLanguageVersion() >= 200)
      {
        LazilyLoadedCtor lazilyLoadedCtor3 = new LazilyLoadedCtor(scope, "ArrayBuffer", "rhino.typedarrays.NativeArrayBuffer", num != 0, true);
        LazilyLoadedCtor lazilyLoadedCtor4 = new LazilyLoadedCtor(scope, "Int8Array", "rhino.typedarrays.NativeInt8Array", num != 0, true);
        LazilyLoadedCtor lazilyLoadedCtor5 = new LazilyLoadedCtor(scope, "Uint8Array", "rhino.typedarrays.NativeUint8Array", num != 0, true);
        LazilyLoadedCtor lazilyLoadedCtor6 = new LazilyLoadedCtor(scope, "Uint8ClampedArray", "rhino.typedarrays.NativeUint8ClampedArray", num != 0, true);
        LazilyLoadedCtor lazilyLoadedCtor7 = new LazilyLoadedCtor(scope, "Int16Array", "rhino.typedarrays.NativeInt16Array", num != 0, true);
        LazilyLoadedCtor lazilyLoadedCtor8 = new LazilyLoadedCtor(scope, "Uint16Array", "rhino.typedarrays.NativeUint16Array", num != 0, true);
        LazilyLoadedCtor lazilyLoadedCtor9 = new LazilyLoadedCtor(scope, "Int32Array", "rhino.typedarrays.NativeInt32Array", num != 0, true);
        LazilyLoadedCtor lazilyLoadedCtor10 = new LazilyLoadedCtor(scope, "Uint32Array", "rhino.typedarrays.NativeUint32Array", num != 0, true);
        LazilyLoadedCtor lazilyLoadedCtor11 = new LazilyLoadedCtor(scope, "Float32Array", "rhino.typedarrays.NativeFloat32Array", num != 0, true);
        LazilyLoadedCtor lazilyLoadedCtor12 = new LazilyLoadedCtor(scope, "Float64Array", "rhino.typedarrays.NativeFloat64Array", num != 0, true);
        LazilyLoadedCtor lazilyLoadedCtor13 = new LazilyLoadedCtor(scope, "DataView", "rhino.typedarrays.NativeDataView", num != 0, true);
      }
      if (cx.getLanguageVersion() >= 200)
      {
        NativeSymbol.init(cx, (Scriptable) scope, num != 0);
        NativeCollectionIterator.init(scope, "Set Iterator", num != 0);
        NativeCollectionIterator.init(scope, "Map Iterator", num != 0);
        NativeMap.init(cx, (Scriptable) scope, num != 0);
        NativeSet.init(cx, (Scriptable) scope, num != 0);
        NativeWeakMap.init((Scriptable) scope, num != 0);
        NativeWeakSet.init((Scriptable) scope, num != 0);
      }
      if (scope is TopLevel)
        ((TopLevel) scope).cacheBuiltins((Scriptable) scope, num != 0);
      return scope;
    }

    [LineNumberTable(3268)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool hasTopCall(Context cx) => cx.topCallScope != null;

    [LineNumberTable(new byte[] {156, 87, 67, 99, 107, 179, 108, 109, 103, 103, 135, 145, 135, 135, 168, 139, 227, 55, 135, 135, 168, 171})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object doTopCall(
      Callable callable,
      Context cx,
      Scriptable scope,
      Scriptable thisObj,
      object[] args,
      bool isTopLevelStrict)
    {
      int num1 = isTopLevelStrict ? 1 : 0;
      if (scope == null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException();
      }
      if (cx.topCallScope != null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalStateException();
      }
      cx.topCallScope = ScriptableObject.getTopLevelScope(scope);
      cx.useDynamicScope = cx.hasFeature(7);
      int num2 = cx.isTopLevelStrict ? 1 : 0;
      cx.isTopLevelStrict = num1 != 0;
      ContextFactory factory = cx.getFactory();
      object obj;
      // ISSUE: fault handler
      try
      {
        obj = factory.doTopCall(callable, cx, scope, thisObj, args);
      }
      __fault
      {
        cx.topCallScope = (Scriptable) null;
        cx.isTopLevelStrict = num2 != 0;
        if (cx.currentActivationCall != null)
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalStateException();
        }
      }
      cx.topCallScope = (Scriptable) null;
      cx.isTopLevelStrict = num2 != 0;
      if (cx.currentActivationCall != null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalStateException();
      }
      return obj;
    }

    [LineNumberTable(new byte[] {163, 197, 104, 105, 99, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Scriptable newObject(
      Context cx,
      Scriptable scope,
      string constructorName,
      object[] args)
    {
      scope = ScriptableObject.getTopLevelScope(scope);
      Function existingCtor = ScriptRuntime.getExistingCtor(cx, scope, constructorName);
      if (args == null)
        args = ScriptRuntime.__\u003C\u003EemptyArgs;
      return existingCtor.construct(cx, scope, args);
    }

    [LineNumberTable(new byte[] {174, 121, 102, 105, 137, 139, 99, 99, 134, 103, 104, 106, 27, 232, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object[] getArrayElements(Scriptable @object)
    {
      long lengthProperty = NativeArray.getLengthProperty(Context.getContext(), @object, false);
      if (lengthProperty > (long) int.MaxValue)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException();
      }
      int length = (int) lengthProperty;
      if (length == 0)
        return ScriptRuntime.__\u003C\u003EemptyArgs;
      object[] objArray = new object[length];
      for (int index = 0; index < length; ++index)
      {
        object property = ScriptableObject.getProperty(@object, index);
        objArray[index] = !object.ReferenceEquals(property, Scriptable.NOT_FOUND) ? property : Undefined.__\u003C\u003Einstance;
      }
      return objArray;
    }

    [LineNumberTable(new byte[] {163, 131, 104, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Scriptable toObject(Scriptable scope, object val) => val is Scriptable ? (Scriptable) val : ScriptRuntime.toObject(Context.getContext(), scope, val);

    [LineNumberTable(713)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static string escapeString(string s) => ScriptRuntime.escapeString(s, '"');

    [LineNumberTable(new byte[] {162, 249, 105, 102, 37, 203, 105, 102, 109, 102, 109, 102, 105, 134, 101, 201, 104, 99, 130, 102, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static string numberToString(double d, int @base)
    {
      if (@base < 2 || @base > 36)
        throw Throwable.__\u003Cunmap\u003E((Exception) Context.reportRuntimeError1("msg.bad.radix", (object) Integer.toString(@base)));
      if (Double.isNaN(d))
        return "NaN";
      if (d == double.PositiveInfinity)
        return "Infinity";
      if (d == double.NegativeInfinity)
        return "-Infinity";
      if (d == 0.0)
        return "0";
      if (@base != 10)
        return DToA.JS_dtobasestr(@base, d);
      string str = FastDtoa.numberToString(d);
      if (str != null)
        return str;
      StringBuilder stringBuilder = new StringBuilder();
      DToA.JS_dtostr(stringBuilder, 0, 0, d);
      return stringBuilder.toString();
    }

    [LineNumberTable(3955)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static EcmaError constructError(
      string error,
      string message,
      string sourceName,
      int lineNumber,
      string lineSource,
      int columnNumber)
    {
      return new EcmaError(error, message, sourceName, lineNumber, lineSource, columnNumber);
    }

    [LineNumberTable(new byte[] {163, 156, 99, 144, 104, 176, 104, 113, 108, 130, 104, 135, 136, 127, 4, 108, 130, 104, 120, 109, 131, 104, 119, 109, 195, 113, 105, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Scriptable toObject(Context cx, Scriptable scope, object val)
    {
      if (val == null)
        throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.typeError0("msg.null.to.object"));
      if (Undefined.isUndefined(val))
        throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.typeError0("msg.undef.to.object"));
      if (ScriptRuntime.isSymbol(val))
      {
        NativeSymbol.__\u003Cclinit\u003E();
        NativeSymbol nativeSymbol = new NativeSymbol((NativeSymbol) val);
        ScriptRuntime.setBuiltinProtoAndParent((ScriptableObject) nativeSymbol, scope, TopLevel.Builtins.__\u003C\u003ESymbol);
        return (Scriptable) nativeSymbol;
      }
      if (val is Scriptable)
        return (Scriptable) val;
      if (CharSequence.IsInstance(val))
      {
        NativeString.__\u003Cclinit\u003E();
        object obj1 = val;
        CharSequence.Cast(obj1);
        object obj2 = obj1;
        CharSequence charSequence;
        charSequence.__\u003Cref\u003E = (__Null) obj2;
        NativeString nativeString = new NativeString(charSequence);
        ScriptRuntime.setBuiltinProtoAndParent((ScriptableObject) nativeString, scope, TopLevel.Builtins.__\u003C\u003EString);
        return (Scriptable) nativeString;
      }
      switch (val)
      {
        case Number _:
          NativeNumber.__\u003Cclinit\u003E();
          NativeNumber nativeNumber = new NativeNumber(((Number) val).doubleValue());
          ScriptRuntime.setBuiltinProtoAndParent((ScriptableObject) nativeNumber, scope, TopLevel.Builtins.__\u003C\u003ENumber);
          return (Scriptable) nativeNumber;
        case Boolean _:
          NativeBoolean.__\u003Cclinit\u003E();
          NativeBoolean nativeBoolean = new NativeBoolean(((Boolean) val).booleanValue());
          ScriptRuntime.setBuiltinProtoAndParent((ScriptableObject) nativeBoolean, scope, TopLevel.Builtins.__\u003C\u003EBoolean);
          return (Scriptable) nativeBoolean;
        default:
          object obj = cx.getWrapFactory().wrap(cx, scope, val, (Class) null);
          return obj is Scriptable ? (Scriptable) obj : throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.errorWithClassName("msg.invalid.type", val));
      }
    }

    [LineNumberTable(new byte[] {168, 170, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Callable getPropFunctionAndThis(
      object obj,
      string property,
      Context cx,
      Scriptable scope)
    {
      Scriptable objectOrNull = ScriptRuntime.toObjectOrNull(cx, obj, scope);
      return ScriptRuntime.getPropFunctionAndThisHelper(obj, property, cx, objectOrNull);
    }

    [LineNumberTable(new byte[] {175, 153, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Scriptable lastStoredScriptable(Context cx)
    {
      Scriptable scratchScriptable = cx.scratchScriptable;
      cx.scratchScriptable = (Scriptable) null;
      return scratchScriptable;
    }

    [LineNumberTable(new byte[] {168, 246, 104, 130, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool isIteratorDone(Context cx, object result) => result is Scriptable && ScriptRuntime.toBoolean(ScriptRuntime.getObjectProp((Scriptable) result, "done", cx));

    [LineNumberTable(new byte[] {165, 54, 105, 99, 141})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object getObjectProp(object obj, string property, Context cx, Scriptable scope) => ScriptRuntime.getObjectProp(ScriptRuntime.toObjectOrNull(cx, obj, scope) ?? throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.undefReadError(obj, (object) property)), property, cx);

    [LineNumberTable(new byte[] {165, 87, 105, 99, 141, 104, 109, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object getObjectPropNoWarn(
      object obj,
      string property,
      Context cx,
      Scriptable scope)
    {
      object property1 = ScriptableObject.getProperty(ScriptRuntime.toObjectOrNull(cx, obj, scope) ?? throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.undefReadError(obj, (object) property)), property);
      return object.ReferenceEquals(property1, Scriptable.NOT_FOUND) ? Undefined.__\u003C\u003Einstance : property1;
    }

    [LineNumberTable(new byte[] {168, 235, 104, 102, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object callIterator(object obj, Context cx, Scriptable scope)
    {
      Callable elemFunctionAndThis = ScriptRuntime.getElemFunctionAndThis(obj, (object) SymbolKey.__\u003C\u003EITERATOR, cx, scope);
      Scriptable s2 = ScriptRuntime.lastStoredScriptable(cx);
      return elemFunctionAndThis.call(cx, scope, s2, ScriptRuntime.__\u003C\u003EemptyArgs);
    }

    [LineNumberTable(new byte[] {173, 117, 130, 104, 103, 98, 103, 104, 109, 104, 99, 104, 102, 127, 1, 113, 138, 104, 99, 102, 105, 172, 103, 102, 202, 171, 104, 100, 135, 136, 101, 158, 178, 108, 141, 105, 173, 108, 145, 207, 105, 113, 207})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Scriptable wrapException(Exception t, Scriptable scope, Context cx)
    {
      Exception exception = (Exception) null;
      RhinoException rhinoException;
      string constructorName;
      string str1;
      switch (t)
      {
        case EcmaError _:
          EcmaError ecmaError = (EcmaError) t;
          rhinoException = (RhinoException) ecmaError;
          constructorName = ecmaError.getName();
          str1 = ecmaError.getErrorMessage();
          break;
        case WrappedException _:
          WrappedException wrappedException = (WrappedException) t;
          rhinoException = (RhinoException) wrappedException;
          exception = wrappedException.getWrappedException();
          constructorName = "JavaException";
          str1 = new StringBuilder().append(Object.instancehelper_getClass((object) exception).getName()).append(": ").append(Throwable.instancehelper_getMessage(exception)).toString();
          break;
        case EvaluatorException _:
          EvaluatorException evaluatorException = (EvaluatorException) t;
          rhinoException = (RhinoException) evaluatorException;
          constructorName = "InternalError";
          str1 = evaluatorException.getMessage();
          break;
        default:
          if (!cx.hasFeature(13))
            throw Throwable.__\u003Cunmap\u003E((Exception) Kit.codeBug());
          rhinoException = (RhinoException) new WrappedException(t);
          constructorName = "JavaException";
          str1 = Throwable.instancehelper_toString(t);
          break;
      }
      string str2 = rhinoException.sourceName() ?? "";
      int num = rhinoException.lineNumber();
      object[] args;
      if (num > 0)
        args = new object[3]
        {
          (object) str1,
          (object) str2,
          (object) Integer.valueOf(num)
        };
      else
        args = new object[2]{ (object) str1, (object) str2 };
      Scriptable destination = cx.newObject(scope, constructorName, args);
      ScriptableObject.putProperty(destination, "name", (object) constructorName);
      if (destination is NativeError)
        ((NativeError) destination).setStackProvider(rhinoException);
      if (exception != null && ScriptRuntime.isVisible(cx, (object) exception))
      {
        object obj = cx.getWrapFactory().wrap(cx, scope, (object) exception, (Class) null);
        ScriptableObject.defineProperty(destination, "javaException", obj, 7);
      }
      if (ScriptRuntime.isVisible(cx, (object) rhinoException))
      {
        object obj = cx.getWrapFactory().wrap(cx, scope, (object) rhinoException, (Class) null);
        ScriptableObject.defineProperty(destination, "rhinoException", obj, 7);
      }
      return destination;
    }

    [LineNumberTable(new byte[] {175, 25, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static EcmaError typeError2(string messageId, object arg1, object arg2) => ScriptRuntime.typeError(ScriptRuntime.getMessage2(messageId, arg1, arg2));

    [LineNumberTable(new byte[] {171, 91, 115, 130, 107, 112, 130, 110, 104, 110, 159, 1, 162, 136})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool sameZero(object x, object y)
    {
      if (!String.instancehelper_equals(ScriptRuntime.@typeof(x), (object) ScriptRuntime.@typeof(y)))
        return false;
      if (!(x is Number))
        return ScriptRuntime.eq(x, y);
      if (ScriptRuntime.isNaN(x) && ScriptRuntime.isNaN(y))
        return true;
      double num1 = ((Number) x).doubleValue();
      if (y is Number)
      {
        double num2 = ((Number) y).doubleValue();
        if (num1 == ScriptRuntime.__\u003C\u003EnegativeZero && num2 == 0.0 || num1 == 0.0 && num2 == ScriptRuntime.__\u003C\u003EnegativeZero)
          return true;
      }
      return ScriptRuntime.eqNumber(num1, y);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool isJSLineTerminator(int c) => (c & 57296) == 0 && (c == 10 || c == 13 || (c == 8232 || c == 8233));

    [LineNumberTable(new byte[] {164, 183, 103, 101, 136})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static object getIndexObject([In] string obj0)
    {
      long num = ScriptRuntime.indexFromString(obj0);
      return num >= 0L ? (object) Integer.valueOf((int) num) : (object) obj0;
    }

    [LineNumberTable(new byte[] {164, 195, 104, 102, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static object getIndexObject([In] double obj0)
    {
      int num = ByteCodeHelper.d2i(obj0);
      return (double) num == obj0 ? (object) Integer.valueOf(num) : (object) ScriptRuntime.toString(obj0);
    }

    [LineNumberTable(1158)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int toInt32(double d) => DoubleConversion.doubleToInt32(d);

    [LineNumberTable(1700)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static bool isSpecialProperty([In] string obj0) => String.instancehelper_equals(obj0, (object) "__proto__") || String.instancehelper_equals(obj0, (object) "__parent__");

    [LineNumberTable(new byte[] {164, 78, 104, 104, 135, 109, 177})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static Function getExistingCtor([In] Context obj0, [In] Scriptable obj1, [In] string obj2)
    {
      object property = ScriptableObject.getProperty(obj1, obj2);
      if (property is Function)
        return (Function) property;
      if (object.ReferenceEquals(property, Scriptable.NOT_FOUND))
        throw Throwable.__\u003Cunmap\u003E((Exception) Context.reportRuntimeError1("msg.ctor.not.found", (object) obj2));
      throw Throwable.__\u003Cunmap\u003E((Exception) Context.reportRuntimeError1("msg.not.ctor", (object) obj2));
    }

    [LineNumberTable(new byte[] {155, 250, 98, 103, 99, 142, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void setFunctionProtoAndParent(
      BaseFunction fn,
      Scriptable scope,
      bool es6GeneratorFunction)
    {
      int num = es6GeneratorFunction ? 1 : 0;
      fn.setParentScope(scope);
      if (num != 0)
        fn.setPrototype(ScriptableObject.getGeneratorFunctionPrototype(scope));
      else
        fn.setPrototype(ScriptableObject.getFunctionPrototype(scope));
    }

    [LineNumberTable(3411)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Scriptable createArrowFunctionActivation(
      NativeFunction funObj,
      Scriptable scope,
      object[] args,
      bool isStrict)
    {
      int num = isStrict ? 1 : 0;
      return (Scriptable) new NativeCall(funObj, scope, args, true, num != 0);
    }

    [LineNumberTable(3404)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Scriptable createFunctionActivation(
      NativeFunction funObj,
      Scriptable scope,
      object[] args,
      bool isStrict)
    {
      int num = isStrict ? 1 : 0;
      return (Scriptable) new NativeCall(funObj, scope, args, false, num != 0);
    }

    [LineNumberTable(new byte[] {156, 72, 99, 104, 139, 103, 134, 162, 104, 169, 108, 105, 169, 106, 100, 106, 99, 112, 135, 176, 176, 138, 133})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void initScript(
      NativeFunction funObj,
      Scriptable thisObj,
      Context cx,
      Scriptable scope,
      bool evalScript)
    {
      int num1 = evalScript ? 1 : 0;
      if (cx.topCallScope == null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalStateException();
      }
      int paramAndVarCount = funObj.getParamAndVarCount();
      if (paramAndVarCount == 0)
        return;
      Scriptable scriptable = scope;
      while (scriptable is NativeWith)
        scriptable = scriptable.getParentScope();
      int num2 = paramAndVarCount;
      while (true)
      {
        string paramOrVarName;
        int num3;
        do
        {
          int num4 = num2;
          num2 += -1;
          if (num4 != 0)
          {
            paramOrVarName = funObj.getParamOrVarName(num2);
            num3 = funObj.getParamOrVarConst(num2) ? 1 : 0;
            if (!ScriptableObject.hasProperty(scope, paramOrVarName))
            {
              if (num3 != 0)
                ScriptableObject.defineConstProperty(scriptable, paramOrVarName);
              else if (num1 != 0)
                goto label_14;
            }
            else
              goto label_15;
          }
          else
            goto label_17;
        }
        while (funObj is InterpretedFunction && !((InterpretedFunction) funObj).hasFunctionNamed(paramOrVarName));
        ScriptableObject.defineProperty(scriptable, paramOrVarName, Undefined.__\u003C\u003Einstance, 4);
        continue;
label_14:
        scriptable.put(paramOrVarName, scriptable, Undefined.__\u003C\u003Einstance);
        continue;
label_15:
        ScriptableObject.redefineProperty(scope, paramOrVarName, num3 != 0);
      }
label_17:;
    }

    [LineNumberTable(new byte[] {155, 243, 163, 100, 103, 107, 163, 100, 135, 169, 102, 103, 203, 104, 138, 137, 98, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void initFunction(
      Context cx,
      Scriptable scope,
      NativeFunction function,
      int type,
      bool fromEvalCode)
    {
      int num = fromEvalCode ? 1 : 0;
      if (type == 1)
      {
        string functionName = function.getFunctionName();
        if (functionName == null || String.instancehelper_length(functionName) == 0)
          return;
        if (num == 0)
          ScriptableObject.defineProperty(scope, functionName, (object) function, 4);
        else
          scope.put(functionName, scope, (object) function);
      }
      else
      {
        if (type != 3)
          throw Throwable.__\u003Cunmap\u003E((Exception) Kit.codeBug());
        string functionName = function.getFunctionName();
        if (functionName == null || String.instancehelper_length(functionName) == 0)
          return;
        while (scope is NativeWith)
          scope = scope.getParentScope();
        scope.put(functionName, scope, (object) function);
      }
    }

    [LineNumberTable(new byte[] {160, 222, 105, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Number wrapNumber(double x) => Double.isNaN(x) ? (Number) ScriptRuntime.__\u003C\u003ENaNobj : (Number) Double.valueOf(x);

    [LineNumberTable(328)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Boolean wrapBoolean(bool b) => b ? (Boolean) Boolean.TRUE : (Boolean) Boolean.FALSE;

    [LineNumberTable(1166)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static long toUint32(double d) => (long) DoubleConversion.doubleToInt32(d) & (long) uint.MaxValue;

    [LineNumberTable(new byte[] {166, 216, 98, 135, 134, 104, 103, 105, 130, 99, 103, 99, 130, 130, 105, 130, 99, 103, 99, 226, 69, 104, 142, 105, 194})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Scriptable bind(Context cx, Scriptable scope, string id)
    {
      Scriptable parentScope = scope.getParentScope();
      if (parentScope != null)
      {
        while (scope is NativeWith)
        {
          Scriptable prototype = scope.getPrototype();
          if (ScriptableObject.hasProperty(prototype, id))
            return prototype;
          scope = parentScope;
          parentScope = parentScope.getParentScope();
          if (parentScope == null)
            goto label_8;
        }
        while (!ScriptableObject.hasProperty(scope, id))
        {
          scope = parentScope;
          parentScope = parentScope.getParentScope();
          if (parentScope == null)
            goto label_8;
        }
        return scope;
      }
label_8:
      if (cx.useDynamicScope)
        scope = ScriptRuntime.checkDynamicScope(cx.topCallScope, scope);
      return ScriptableObject.hasProperty(scope, id) ? scope : (Scriptable) null;
    }

    [LineNumberTable(new byte[] {167, 1, 163, 235, 69, 108, 103, 103, 37, 197, 104, 104, 142, 138})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object setName(
      Scriptable bound,
      object value,
      Context cx,
      Scriptable scope,
      string id)
    {
      if (bound != null)
      {
        ScriptableObject.putProperty(bound, id, value);
      }
      else
      {
        if (cx.hasFeature(11) || cx.hasFeature(8))
          Context.reportWarning(ScriptRuntime.getMessage1("msg.assn.create.strict", (object) id));
        bound = ScriptableObject.getTopLevelScope(scope);
        if (cx.useDynamicScope)
          bound = ScriptRuntime.checkDynamicScope(cx.topCallScope, bound);
        bound.put(id, bound, value);
      }
      return value;
    }

    [LineNumberTable(new byte[] {167, 26, 227, 72, 105, 162, 127, 7})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object strictSetName(
      Scriptable bound,
      object value,
      Context cx,
      Scriptable scope,
      string id)
    {
      if (bound == null)
        throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.constructError("ReferenceError", new StringBuilder().append("Assignment to undefined \"").append(id).append("\" in strict mode").toString()));
      ScriptableObject.putProperty(bound, id, value);
      return value;
    }

    [LineNumberTable(new byte[] {167, 43, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object setConst(Scriptable bound, object value, Context cx, string id)
    {
      ScriptableObject.putConstProperty(bound, id, value);
      return value;
    }

    [LineNumberTable(new byte[] {165, 192, 105, 104, 108, 174, 106, 99, 174})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object setObjectProp(
      object obj,
      string property,
      object value,
      Context cx,
      Scriptable scope)
    {
      if (!(obj is Scriptable) && cx.isStrictMode() && cx.getLanguageVersion() >= 180)
        throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.undefWriteError(obj, (object) property, value));
      return ScriptRuntime.setObjectProp(ScriptRuntime.toObjectOrNull(cx, obj, scope) ?? throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.undefWriteError(obj, (object) property, value)), property, value, cx);
    }

    [LineNumberTable(new byte[] {170, 77, 105, 99, 173, 226, 69, 105, 109, 130, 103, 99, 109, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object propIncrDecr(
      object obj,
      string id,
      Context cx,
      Scriptable scope,
      int incrDecrMask)
    {
      Scriptable objectOrNull = ScriptRuntime.toObjectOrNull(cx, obj, scope);
      Scriptable scriptable = objectOrNull != null ? objectOrNull : throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.undefReadError(obj, (object) id));
      object objA;
      do
      {
        objA = scriptable.get(id, objectOrNull);
        if (object.ReferenceEquals(objA, Scriptable.NOT_FOUND))
          scriptable = scriptable.getPrototype();
        else
          goto label_6;
      }
      while (scriptable != null);
      objectOrNull.put(id, objectOrNull, (object) ScriptRuntime.__\u003C\u003ENaNobj);
      return (object) ScriptRuntime.__\u003C\u003ENaNobj;
label_6:
      return ScriptRuntime.doScriptableIncrDecr(scriptable, id, objectOrNull, objA, incrDecrMask);
    }

    [LineNumberTable(1679)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object refGet(Ref @ref, Context cx) => @ref.get(cx);

    [LineNumberTable(1692)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object refSet(Ref @ref, object value, Context cx, Scriptable scope) => @ref.set(cx, scope, value);

    [LineNumberTable(1696)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object refDel(Ref @ref, Context cx) => (object) ScriptRuntime.wrapBoolean(@ref.delete(cx));

    [LineNumberTable(new byte[] {170, 204, 104, 138, 104, 144, 105, 131, 167, 101, 140, 138, 103, 106, 99, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object refIncrDecr(Ref @ref, Context cx, Scriptable scope, int incrDecrMask)
    {
      object val = @ref.get(cx);
      int num = (incrDecrMask & 2) == 0 ? 0 : 1;
      double x;
      if (val is Number)
      {
        x = ((Number) val).doubleValue();
      }
      else
      {
        x = ScriptRuntime.toNumber(val);
        if (num != 0)
          val = (object) ScriptRuntime.wrapNumber(x);
      }
      Number number = ScriptRuntime.wrapNumber((incrDecrMask & 1) != 0 ? x - 1.0 : x + 1.0);
      @ref.set(cx, scope, (object) number);
      return num != 0 ? val : (object) number;
    }

    [LineNumberTable(new byte[] {168, 68, 103, 99, 105, 104, 109, 141, 173, 98, 103, 199})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Callable getNameFunctionAndThis(
      string name,
      Context cx,
      Scriptable scope)
    {
      Scriptable parentScope = scope.getParentScope();
      if (parentScope != null)
        return (Callable) ScriptRuntime.nameOrFunction(cx, scope, parentScope, name, true);
      object objA = ScriptRuntime.topScopeName(cx, scope, name);
      if (!(objA is Callable))
      {
        if (object.ReferenceEquals(objA, Scriptable.NOT_FOUND))
          throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.notFoundError(scope, name));
        throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.notFunctionError(objA, (object) name));
      }
      Scriptable scriptable = scope;
      ScriptRuntime.storeScriptable(cx, scriptable);
      return (Callable) objA;
    }

    [LineNumberTable(new byte[] {168, 114, 104, 105, 99, 146, 175, 104, 104, 175, 105, 99, 178, 173, 104, 173, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Callable getElemFunctionAndThis(
      object obj,
      object elem,
      Context cx,
      Scriptable scope)
    {
      Scriptable objectOrNull;
      object obj1;
      if (ScriptRuntime.isSymbol(elem))
      {
        objectOrNull = ScriptRuntime.toObjectOrNull(cx, obj, scope);
        obj1 = objectOrNull != null ? ScriptableObject.getProperty(objectOrNull, (Symbol) elem) : throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.undefCallError(obj, (object) String.valueOf(elem)));
      }
      else
      {
        ScriptRuntime.StringIdOrIndex stringIdOrIndex = ScriptRuntime.toStringIdOrIndex(cx, elem);
        if (stringIdOrIndex.stringId != null)
          return ScriptRuntime.getPropFunctionAndThis(obj, stringIdOrIndex.stringId, cx, scope);
        objectOrNull = ScriptRuntime.toObjectOrNull(cx, obj, scope);
        if (objectOrNull == null)
          throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.undefCallError(obj, (object) String.valueOf(elem)));
        obj1 = ScriptableObject.getProperty(objectOrNull, stringIdOrIndex.index);
      }
      if (!(obj1 is Callable))
        throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.notFunctionError(obj1, elem));
      ScriptRuntime.storeScriptable(cx, objectOrNull);
      return (Callable) obj1;
    }

    [LineNumberTable(new byte[] {168, 203, 104, 172, 103, 98, 104, 140, 99, 115, 135, 104, 170, 136, 167, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Callable getValueFunctionAndThis(object value, Context cx)
    {
      Callable callable = value is Callable ? (Callable) value : throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.notFunctionError(value));
      Scriptable scriptable = (Scriptable) null;
      if (callable is Scriptable)
        scriptable = ((Scriptable) callable).getParentScope();
      if (scriptable == null)
      {
        if (cx.topCallScope == null)
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalStateException();
        }
        scriptable = cx.topCallScope;
      }
      if (scriptable.getParentScope() != null)
      {
        switch (scriptable)
        {
          case NativeCall _:
            scriptable = ScriptableObject.getTopLevelScope(scriptable);
            break;
        }
      }
      ScriptRuntime.storeScriptable(cx, scriptable);
      return callable;
    }

    [LineNumberTable(new byte[] {169, 8, 104, 103, 106, 99, 159, 16, 162, 102, 37, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Ref callRef(Callable function, Scriptable thisObj, object[] args, Context cx)
    {
      RefCallable refCallable = function is RefCallable ? (RefCallable) function : throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.constructError("ReferenceError", ScriptRuntime.getMessage1("msg.no.ref.from.function", (object) ScriptRuntime.toString((object) function))));
      Ref @ref = refCallable.refCall(cx, thisObj, args);
      if (@ref == null)
      {
        string str = new StringBuilder().append(Object.instancehelper_getClass((object) refCallable).getName()).append(".refCall() returned null").toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalStateException(str);
      }
      return @ref;
    }

    [LineNumberTable(new byte[] {169, 142, 104, 137, 108, 104, 141, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static Callable getCallable([In] Scriptable obj0)
    {
      Callable callable;
      if (obj0 is Callable)
      {
        callable = (Callable) obj0;
      }
      else
      {
        object defaultValue = obj0.getDefaultValue(ScriptRuntime.__\u003C\u003EFunctionClass);
        callable = defaultValue is Callable ? (Callable) defaultValue : throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.notFunctionError(defaultValue, (object) obj0));
      }
      return callable;
    }

    [LineNumberTable(new byte[] {169, 229, 102, 105, 99, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static string typeofName(Scriptable scope, string id)
    {
      Context context = Context.getContext();
      Scriptable scriptable = ScriptRuntime.bind(context, scope, id);
      return scriptable == null ? "undefined" : ScriptRuntime.@typeof(ScriptRuntime.getObjectProp(scriptable, id, context));
    }

    [LineNumberTable(new byte[] {166, 120, 103, 99, 105, 109, 141, 162})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object name(Context cx, Scriptable scope, string name)
    {
      Scriptable parentScope = scope.getParentScope();
      if (parentScope != null)
        return ScriptRuntime.nameOrFunction(cx, scope, parentScope, name, false);
      object objA = ScriptRuntime.topScopeName(cx, scope, name);
      return !object.ReferenceEquals(objA, Scriptable.NOT_FOUND) ? objA : throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.notFoundError(scope, name));
    }

    [LineNumberTable(new byte[] {170, 55, 112, 142, 130, 105, 109, 130, 103, 99, 104, 99, 141})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object nameIncrDecr(
      Scriptable scopeChain,
      string id,
      Context cx,
      int incrDecrMask)
    {
      Scriptable scriptable;
      object objA;
      do
      {
        if (cx.useDynamicScope && scopeChain.getParentScope() == null)
          scopeChain = ScriptRuntime.checkDynamicScope(cx.topCallScope, scopeChain);
        scriptable = scopeChain;
        do
        {
          objA = scriptable.get(id, scopeChain);
          if (object.ReferenceEquals(objA, Scriptable.NOT_FOUND))
            scriptable = scriptable.getPrototype();
          else
            goto label_7;
        }
        while (scriptable != null);
        scopeChain = scopeChain.getParentScope();
      }
      while (scopeChain != null);
      throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.notFoundError(scopeChain, id));
label_7:
      return ScriptRuntime.doScriptableIncrDecr(scriptable, id, scopeChain, objA, incrDecrMask);
    }

    [LineNumberTable(new byte[] {173, 192, 105, 99, 150})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Scriptable enterWith(object obj, Context cx, Scriptable scope) => (Scriptable) new NativeWith(scope, ScriptRuntime.toObjectOrNull(cx, obj, scope) ?? throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.typeError1("msg.undef.with", (object) ScriptRuntime.toString(obj))));

    [LineNumberTable(new byte[] {173, 200, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Scriptable leaveWith(Scriptable scope) => ((NativeWith) scope).getParentScope();

    [LineNumberTable(new byte[] {173, 6, 104, 98, 145, 226, 69, 99, 103, 104, 241, 71, 130, 104, 104, 100, 110, 105, 109, 104, 100, 104, 103, 127, 1, 113, 138, 104, 100, 103, 105, 172, 104, 103, 202, 171, 105, 100, 135, 137, 101, 158, 178, 142, 105, 174, 108, 146, 207, 106, 115, 207, 163, 134, 169, 201, 105, 38, 229, 69, 99, 137})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Scriptable newCatchScope(
      Exception t,
      Scriptable lastCatchScope,
      string exceptionName,
      Context cx,
      Scriptable scope)
    {
      int num1;
      object obj1;
      if (t is JavaScriptException)
      {
        num1 = 0;
        obj1 = ((JavaScriptException) t).getValue();
      }
      else
      {
        num1 = 1;
        if (lastCatchScope != null)
        {
          obj1 = ((ScriptableObject) lastCatchScope).getAssociatedValue((object) t);
          if (obj1 == null)
            Kit.codeBug();
        }
        else
        {
          Exception exception = (Exception) null;
          RhinoException rhinoException;
          TopLevel.NativeErrors nativeErrors;
          string str1;
          switch (t)
          {
            case EcmaError _:
              EcmaError ecmaError = (EcmaError) t;
              rhinoException = (RhinoException) ecmaError;
              nativeErrors = TopLevel.NativeErrors.valueOf(ecmaError.getName());
              str1 = ecmaError.getErrorMessage();
              break;
            case WrappedException _:
              WrappedException wrappedException = (WrappedException) t;
              rhinoException = (RhinoException) wrappedException;
              exception = wrappedException.getWrappedException();
              nativeErrors = TopLevel.NativeErrors.JavaException;
              str1 = new StringBuilder().append(Object.instancehelper_getClass((object) exception).getName()).append(": ").append(Throwable.instancehelper_getMessage(exception)).toString();
              break;
            case EvaluatorException _:
              EvaluatorException evaluatorException = (EvaluatorException) t;
              rhinoException = (RhinoException) evaluatorException;
              nativeErrors = TopLevel.NativeErrors.InternalError;
              str1 = evaluatorException.getMessage();
              break;
            default:
              if (!cx.hasFeature(13))
                throw Throwable.__\u003Cunmap\u003E((Exception) Kit.codeBug());
              rhinoException = (RhinoException) new WrappedException(t);
              nativeErrors = TopLevel.NativeErrors.JavaException;
              str1 = Throwable.instancehelper_toString(t);
              break;
          }
          string str2 = rhinoException.sourceName() ?? "";
          int num2 = rhinoException.lineNumber();
          object[] objArray;
          if (num2 > 0)
            objArray = new object[3]
            {
              (object) str1,
              (object) str2,
              (object) Integer.valueOf(num2)
            };
          else
            objArray = new object[2]
            {
              (object) str1,
              (object) str2
            };
          Scriptable destination = ScriptRuntime.newNativeError(cx, scope, nativeErrors, objArray);
          if (destination is NativeError)
            ((NativeError) destination).setStackProvider(rhinoException);
          if (exception != null && ScriptRuntime.isVisible(cx, (object) exception))
          {
            object obj2 = cx.getWrapFactory().wrap(cx, scope, (object) exception, (Class) null);
            ScriptableObject.defineProperty(destination, "javaException", obj2, 7);
          }
          if (ScriptRuntime.isVisible(cx, (object) rhinoException))
          {
            object obj2 = cx.getWrapFactory().wrap(cx, scope, (object) rhinoException, (Class) null);
            ScriptableObject.defineProperty(destination, "rhinoException", obj2, 7);
          }
          obj1 = (object) destination;
        }
      }
      NativeObject nativeObject = new NativeObject();
      nativeObject.defineProperty(exceptionName, obj1, 4);
      if (ScriptRuntime.isVisible(cx, (object) t))
        nativeObject.defineProperty("__exception__", Context.javaToJS((object) t, scope), 6);
      if (num1 != 0)
        nativeObject.associateValue((object) t, obj1);
      return (Scriptable) nativeObject;
    }

    [LineNumberTable(new byte[] {167, 125, 103, 142, 100, 103, 103, 136, 168, 130, 103, 103, 172, 191, 5, 168, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object enumInit(object value, Context cx, Scriptable scope, int enumType)
    {
      ScriptRuntime.IdEnumeration idEnumeration = new ScriptRuntime.IdEnumeration((ScriptRuntime.\u0031) null);
      idEnumeration.obj = ScriptRuntime.toObjectOrNull(cx, value, scope);
      if (enumType == 6)
      {
        idEnumeration.enumType = enumType;
        idEnumeration.iterator = (Scriptable) null;
        return ScriptRuntime.enumInitInOrder(cx, idEnumeration);
      }
      if (idEnumeration.obj == null)
        return (object) idEnumeration;
      idEnumeration.enumType = enumType;
      idEnumeration.iterator = (Scriptable) null;
      if (enumType != 3 && enumType != 4 && enumType != 5)
        idEnumeration.iterator = ScriptRuntime.toIterator(cx, idEnumeration.obj.getParentScope(), idEnumeration.obj, enumType == 0);
      if (idEnumeration.iterator == null)
        ScriptRuntime.enumChangeObject(idEnumeration);
      return (object) idEnumeration;
    }

    [LineNumberTable(new byte[] {167, 180, 103, 107, 105, 135, 113, 104, 102, 103, 134, 159, 4, 127, 1, 98, 110, 134, 200, 104, 134, 111, 113, 102, 130, 127, 1, 118, 133, 104, 101, 104, 104, 117, 101, 104, 98, 109, 117, 101, 116, 138})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Boolean enumNext(object enumObj)
    {
      ScriptRuntime.IdEnumeration idEnumeration1 = (ScriptRuntime.IdEnumeration) enumObj;
      if (idEnumeration1.iterator != null)
      {
        if (idEnumeration1.enumType == 6)
          return ScriptRuntime.enumNextInOrder(idEnumeration1);
        object property = ScriptableObject.getProperty(idEnumeration1.iterator, "next");
        if (!(property is Callable))
          return (Boolean) Boolean.FALSE;
        Callable callable = (Callable) property;
        Context context = Context.getContext();
        Boolean boolean;
        JavaScriptException javaScriptException1;
        try
        {
          idEnumeration1.currentId = callable.call(context, idEnumeration1.iterator.getParentScope(), idEnumeration1.iterator, ScriptRuntime.__\u003C\u003EemptyArgs);
          boolean = (Boolean) Boolean.TRUE;
        }
        catch (JavaScriptException ex)
        {
          javaScriptException1 = (JavaScriptException) ByteCodeHelper.MapException<JavaScriptException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
          goto label_9;
        }
        return boolean;
label_9:
        JavaScriptException javaScriptException2 = javaScriptException1;
        if (javaScriptException2.getValue() is NativeIterator.StopIteration)
          return (Boolean) Boolean.FALSE;
        throw Throwable.__\u003Cunmap\u003E((Exception) javaScriptException2);
      }
      while (idEnumeration1.obj != null)
      {
        if (idEnumeration1.index == idEnumeration1.ids.Length)
        {
          idEnumeration1.obj = idEnumeration1.obj.getPrototype();
          ScriptRuntime.enumChangeObject(idEnumeration1);
        }
        else
        {
          object[] ids = idEnumeration1.ids;
          ScriptRuntime.IdEnumeration idEnumeration2 = idEnumeration1;
          int index1 = idEnumeration2.index;
          ScriptRuntime.IdEnumeration idEnumeration3 = idEnumeration2;
          int index2 = index1;
          idEnumeration3.index = index1 + 1;
          object key = ids[index2];
          if (idEnumeration1.used == null || !idEnumeration1.used.has(key))
          {
            switch (key)
            {
              case Symbol _:
                continue;
              case string _:
                string str = (string) key;
                if (idEnumeration1.obj.has(str, idEnumeration1.obj))
                {
                  idEnumeration1.currentId = (object) str;
                  break;
                }
                continue;
              default:
                int i = ((Number) key).intValue();
                if (idEnumeration1.obj.has(i, idEnumeration1.obj))
                {
                  idEnumeration1.currentId = !idEnumeration1.enumNumbers ? (object) String.valueOf(i) : (object) (string) Integer.valueOf(i);
                  break;
                }
                continue;
            }
            return (Boolean) Boolean.TRUE;
          }
        }
      }
      return (Boolean) Boolean.FALSE;
    }

    [LineNumberTable(new byte[] {167, 251, 103, 104, 135, 191, 6, 167, 168, 122, 147})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object enumId(object enumObj, Context cx)
    {
      ScriptRuntime.IdEnumeration idEnumeration = (ScriptRuntime.IdEnumeration) enumObj;
      if (idEnumeration.iterator != null)
        return idEnumeration.currentId;
      switch (idEnumeration.enumType)
      {
        case 0:
        case 3:
          return idEnumeration.currentId;
        case 1:
        case 4:
          return ScriptRuntime.enumValue(enumObj, cx);
        case 2:
        case 5:
          object[] elements = new object[2]
          {
            idEnumeration.currentId,
            ScriptRuntime.enumValue(enumObj, cx)
          };
          return (object) cx.newArray(ScriptableObject.getTopLevelScope(idEnumeration.obj), elements);
        default:
          throw Throwable.__\u003Cunmap\u003E((Exception) Kit.codeBug());
      }
    }

    [LineNumberTable(1714)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Ref specialRef(
      object obj,
      string specialProperty,
      Context cx,
      Scriptable scope)
    {
      return SpecialRef.createSpecial(cx, scope, obj, specialProperty);
    }

    [LineNumberTable(4083)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Scriptable wrapRegExp(Context cx, Scriptable scope, object compiled) => cx.getRegExpProxy().wrapRegExp(cx, scope, compiled);

    [LineNumberTable(new byte[] {174, 89, 105, 108, 100, 107, 101, 107, 100, 109, 113, 109, 101, 177, 104, 105, 103, 114, 130, 109, 235, 44, 233, 87})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Scriptable newObjectLiteral(
      object[] propertyIds,
      object[] propertyValues,
      int[] getterSetters,
      Context cx,
      Scriptable scope)
    {
      Scriptable s = cx.newObject(scope);
      int index = 0;
      for (int length = propertyIds.Length; index != length; ++index)
      {
        object propertyId = propertyIds[index];
        int num1 = getterSetters != null ? getterSetters[index] : 0;
        object propertyValue = propertyValues[index];
        if (propertyId is string)
        {
          if (num1 == 0)
          {
            if (ScriptRuntime.isSpecialProperty((string) propertyId))
              ScriptRuntime.specialRef((object) s, (string) propertyId, cx, scope).set(cx, scope, propertyValue);
            else
              s.put((string) propertyId, s, propertyValue);
          }
          else
          {
            ScriptableObject scriptableObject = (ScriptableObject) s;
            Callable getterOrSetter = (Callable) propertyValue;
            int num2 = num1 == 1 ? 1 : 0;
            scriptableObject.setGetterOrSetter((string) propertyId, 0, getterOrSetter, num2 != 0);
          }
        }
        else
        {
          int i = ((Integer) propertyId).intValue();
          s.put(i, s, propertyValue);
        }
      }
      return s;
    }

    [LineNumberTable(new byte[] {174, 28, 98, 99, 98, 99, 131, 100, 176, 99, 135, 103, 99, 107, 109, 105, 102, 130, 104, 230, 57, 232, 74, 169, 138, 99, 107, 109, 102, 130, 111, 230, 58, 232, 72})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Scriptable newArrayLiteral(
      object[] objects,
      int[] skipIndices,
      Context cx,
      Scriptable scope)
    {
      int length1 = objects.Length;
      int num = 0;
      if (skipIndices != null)
        num = skipIndices.Length;
      int length2 = length1 + num;
      if (length2 > 1 && num * 2 < length2)
      {
        object[] elements;
        if (num == 0)
        {
          elements = objects;
        }
        else
        {
          elements = new object[length2];
          int index1 = 0;
          int index2 = 0;
          int index3 = 0;
          for (; index2 != length2; ++index2)
          {
            if (index1 != num && skipIndices[index1] == index2)
            {
              elements[index2] = Scriptable.NOT_FOUND;
              ++index1;
            }
            else
            {
              elements[index2] = objects[index3];
              ++index3;
            }
          }
        }
        return cx.newArray(scope, elements);
      }
      Scriptable s = cx.newArray(scope, length2);
      int index4 = 0;
      int i = 0;
      int index5 = 0;
      for (; i != length2; ++i)
      {
        if (index4 != num && skipIndices[index4] == i)
        {
          ++index4;
        }
        else
        {
          s.put(i, s, objects[index5]);
          ++index5;
        }
      }
      return s;
    }

    [LineNumberTable(new byte[] {155, 254, 66, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object updateDotQuery(bool value, Scriptable scope)
    {
      int num = value ? 1 : 0;
      return ((NativeWith) scope).updateDotQuery(num != 0);
    }

    [LineNumberTable(new byte[] {173, 211, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Scriptable leaveDotQuery(Scriptable scope) => ((NativeWith) scope).getParentScope();

    [LineNumberTable(new byte[] {172, 8, 104, 176})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool @in(object a, object b, Context cx)
    {
      if (!(b is Scriptable))
        throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.typeError0("msg.in.not.object"));
      return ScriptRuntime.hasObjectElem((Scriptable) b, a, cx);
    }

    [LineNumberTable(new byte[] {171, 224, 104, 208, 104, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool instanceOf(object a, object b, Context cx)
    {
      if (!(b is Scriptable))
        throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.typeError0("msg.instanceof.not.object"));
      return a is Scriptable && ((Scriptable) b).hasInstance((Scriptable) a);
    }

    [LineNumberTable(new byte[] {172, 39, 112, 110, 147, 112, 144, 104, 114, 104, 114, 112, 152, 105, 137})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool cmp_LE(object val1, object val2)
    {
      double num1;
      double num2;
      if (val1 is Number && val2 is Number)
      {
        num1 = ((Number) val1).doubleValue();
        num2 = ((Number) val2).doubleValue();
      }
      else
      {
        if (val1 is Symbol || val2 is Symbol)
          throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.typeError0("msg.compare.symbol"));
        if (val1 is Scriptable)
          val1 = ((Scriptable) val1).getDefaultValue(ScriptRuntime.__\u003C\u003ENumberClass);
        if (val2 is Scriptable)
          val2 = ((Scriptable) val2).getDefaultValue(ScriptRuntime.__\u003C\u003ENumberClass);
        if (CharSequence.IsInstance(val1) && CharSequence.IsInstance(val2))
          return String.instancehelper_compareTo(Object.instancehelper_toString(val1), Object.instancehelper_toString(val2)) <= 0;
        num1 = ScriptRuntime.toNumber(val1);
        num2 = ScriptRuntime.toNumber(val2);
      }
      return num1 <= num2;
    }

    [LineNumberTable(new byte[] {172, 17, 112, 110, 147, 112, 144, 104, 114, 104, 114, 112, 149, 105, 137})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool cmp_LT(object val1, object val2)
    {
      double num1;
      double num2;
      if (val1 is Number && val2 is Number)
      {
        num1 = ((Number) val1).doubleValue();
        num2 = ((Number) val2).doubleValue();
      }
      else
      {
        if (val1 is Symbol || val2 is Symbol)
          throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.typeError0("msg.compare.symbol"));
        if (val1 is Scriptable)
          val1 = ((Scriptable) val1).getDefaultValue(ScriptRuntime.__\u003C\u003ENumberClass);
        if (val2 is Scriptable)
          val2 = ((Scriptable) val2).getDefaultValue(ScriptRuntime.__\u003C\u003ENumberClass);
        if (CharSequence.IsInstance(val1) && CharSequence.IsInstance(val2))
          return String.instancehelper_compareTo(Object.instancehelper_toString(val1), Object.instancehelper_toString(val2)) < 0;
        num1 = ScriptRuntime.toNumber(val1);
        num2 = ScriptRuntime.toNumber(val2);
      }
      return num1 < num2;
    }

    [LineNumberTable(new byte[] {157, 216, 163, 105, 99, 99, 134, 141, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object delete(object obj, object id, Context cx, Scriptable scope, bool isName)
    {
      int num = isName ? 1 : 0;
      Scriptable objectOrNull = ScriptRuntime.toObjectOrNull(cx, obj, scope);
      if (objectOrNull != null)
        return (object) ScriptRuntime.wrapBoolean(ScriptRuntime.deleteObjectElem(objectOrNull, id, cx));
      if (num != 0)
        return (object) Boolean.TRUE;
      throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.undefDeleteError(obj, id));
    }

    [LineNumberTable(new byte[] {165, 7, 105, 99, 141})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object getObjectElem(object obj, object elem, Context cx, Scriptable scope) => ScriptRuntime.getObjectElem(ScriptRuntime.toObjectOrNull(cx, obj, scope) ?? throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.undefReadError(obj, elem)), elem, cx);

    [LineNumberTable(new byte[] {165, 115, 105, 99, 179, 104, 102, 137, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object getObjectIndex(object obj, double dblIndex, Context cx, Scriptable scope)
    {
      Scriptable objectOrNull = ScriptRuntime.toObjectOrNull(cx, obj, scope);
      if (objectOrNull == null)
        throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.undefReadError(obj, (object) ScriptRuntime.toString(dblIndex)));
      int index = ByteCodeHelper.d2i(dblIndex);
      if ((double) index == dblIndex)
        return ScriptRuntime.getObjectIndex(objectOrNull, index, cx);
      string property = ScriptRuntime.toString(dblIndex);
      return ScriptRuntime.getObjectProp(objectOrNull, property, cx);
    }

    [LineNumberTable(new byte[] {165, 153, 106, 99, 142})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object setObjectElem(
      object obj,
      object elem,
      object value,
      Context cx,
      Scriptable scope)
    {
      return ScriptRuntime.setObjectElem(ScriptRuntime.toObjectOrNull(cx, obj, scope) ?? throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.undefWriteError(obj, elem, value)), elem, value, cx);
    }

    [LineNumberTable(new byte[] {165, 230, 106, 99, 180, 104, 102, 138, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object setObjectIndex(
      object obj,
      double dblIndex,
      object value,
      Context cx,
      Scriptable scope)
    {
      Scriptable objectOrNull = ScriptRuntime.toObjectOrNull(cx, obj, scope);
      if (objectOrNull == null)
        throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.undefWriteError(obj, (object) String.valueOf(dblIndex), value));
      int index = ByteCodeHelper.d2i(dblIndex);
      if ((double) index == dblIndex)
        return ScriptRuntime.setObjectIndex(objectOrNull, index, value, cx);
      string property = ScriptRuntime.toString(dblIndex);
      return ScriptRuntime.setObjectProp(objectOrNull, property, value, cx);
    }

    [LineNumberTable(new byte[] {170, 169, 106, 139, 104, 144, 105, 131, 167, 102, 140, 138, 103, 107, 99, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object elemIncrDecr(
      object obj,
      object index,
      Context cx,
      Scriptable scope,
      int incrDecrMask)
    {
      object val = ScriptRuntime.getObjectElem(obj, index, cx, scope);
      int num = (incrDecrMask & 2) == 0 ? 0 : 1;
      double x;
      if (val is Number)
      {
        x = ((Number) val).doubleValue();
      }
      else
      {
        x = ScriptRuntime.toNumber(val);
        if (num != 0)
          val = (object) ScriptRuntime.wrapNumber(x);
      }
      Number number = ScriptRuntime.wrapNumber((incrDecrMask & 1) != 0 ? x - 1.0 : x + 1.0);
      ScriptRuntime.setObjectElem(obj, index, (object) number, cx, scope);
      return num != 0 ? val : (object) number;
    }

    [LineNumberTable(new byte[] {169, 61, 101, 104, 149, 101, 104, 169, 171})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object newSpecial(
      Context cx,
      object fun,
      object[] args,
      Scriptable scope,
      int callType)
    {
      if (callType == 1)
      {
        if (NativeGlobal.isEvalFunction(fun))
          throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.typeError1("msg.not.ctor", (object) "eval"));
      }
      else
      {
        if (callType != 2)
          throw Throwable.__\u003Cunmap\u003E((Exception) Kit.codeBug());
        if (NativeWith.isWithFunction(fun))
          return NativeWith.newWithSpecial(cx, scope, args);
      }
      return (object) ScriptRuntime.newObject(fun, cx, scope, args);
    }

    [LineNumberTable(new byte[] {169, 41, 101, 112, 176, 101, 104, 213, 171})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object callSpecial(
      Context cx,
      Callable fun,
      Scriptable thisObj,
      object[] args,
      Scriptable scope,
      Scriptable callerThis,
      int callType,
      string filename,
      int lineNumber)
    {
      if (callType == 1)
      {
        if (thisObj.getParentScope() == null && NativeGlobal.isEvalFunction((object) fun))
          return ScriptRuntime.evalSpecial(cx, scope, (object) callerThis, args, filename, lineNumber);
      }
      else
      {
        if (callType != 2)
          throw Throwable.__\u003Cunmap\u003E((Exception) Kit.codeBug());
        if (NativeWith.isWithFunction((object) fun))
          throw Throwable.__\u003Cunmap\u003E((Exception) Context.reportRuntimeError1("msg.only.from.new", (object) "With"));
      }
      return fun.call(cx, scope, thisObj, args);
    }

    [LineNumberTable(new byte[] {171, 129, 112, 98, 104, 113, 104, 108, 104, 126, 104, 98, 104, 104, 104, 109, 109, 172, 141, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static bool eqNumber([In] double obj0, [In] object obj1)
    {
      for (; obj1 != null && !object.ReferenceEquals(obj1, Undefined.__\u003C\u003Einstance); obj1 = ScriptRuntime.toPrimitive(obj1))
      {
        if (obj1 is Number)
          return obj0 == ((Number) obj1).doubleValue();
        if (CharSequence.IsInstance(obj1))
          return obj0 == ScriptRuntime.toNumber(obj1);
        if (obj1 is Boolean)
          return obj0 == (!((Boolean) obj1).booleanValue() ? 0.0 : 1.0);
        if (ScriptRuntime.isSymbol(obj1))
          return false;
        if (obj1 is Scriptable)
        {
          if (obj1 is ScriptableObject)
          {
            Number number = ScriptRuntime.wrapNumber(obj0);
            object objA = ((ScriptableObject) obj1).equivalentValues((object) number);
            if (!object.ReferenceEquals(objA, Scriptable.NOT_FOUND))
              return ((Boolean) objA).booleanValue();
          }
        }
        else
        {
          ScriptRuntime.warnAboutNonJSObject(obj1);
          return false;
        }
      }
      return false;
    }

    [LineNumberTable(new byte[] {170, 250, 112, 112, 130, 104, 109, 109, 172, 98, 104, 115, 105, 98, 104, 127, 2, 107, 109, 104, 144, 104, 110, 110, 173, 119, 107, 107, 104, 109, 109, 172, 104, 109, 109, 172, 176, 108, 109, 107, 105, 106, 235, 61, 225, 69, 98, 104, 104, 109, 109, 172, 123, 105, 104, 115, 104, 191, 2, 130, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool eq(object x, object y)
    {
      if (x == null || object.ReferenceEquals(x, Undefined.__\u003C\u003Einstance))
      {
        if (y == null || object.ReferenceEquals(y, Undefined.__\u003C\u003Einstance))
          return true;
        if (y is ScriptableObject)
        {
          object objA = ((ScriptableObject) y).equivalentValues(x);
          if (!object.ReferenceEquals(objA, Scriptable.NOT_FOUND))
            return ((Boolean) objA).booleanValue();
        }
        return false;
      }
      if (x is Number)
        return ScriptRuntime.eqNumber(((Number) x).doubleValue(), y);
      if (object.ReferenceEquals(x, y))
        return true;
      if (CharSequence.IsInstance(x))
      {
        object obj1 = x;
        CharSequence.Cast(obj1);
        object obj2 = y;
        object obj3 = obj1;
        CharSequence charSequence;
        charSequence.__\u003Cref\u003E = (__Null) obj3;
        return ScriptRuntime.eqString(charSequence, obj2);
      }
      switch (x)
      {
        case Boolean _:
          int num = ((Boolean) x).booleanValue() ? 1 : 0;
          switch (y)
          {
            case Boolean _:
              return num == (((Boolean) y).booleanValue() ? 1 : 0);
            case ScriptableObject _:
              object objA1 = ((ScriptableObject) y).equivalentValues(x);
              if (!object.ReferenceEquals(objA1, Scriptable.NOT_FOUND))
                return ((Boolean) objA1).booleanValue();
              break;
          }
          return ScriptRuntime.eqNumber(num == 0 ? 0.0 : 1.0, y);
        case Scriptable _:
          switch (y)
          {
            case Scriptable _:
              if (x is ScriptableObject)
              {
                object objA2 = ((ScriptableObject) x).equivalentValues(y);
                if (!object.ReferenceEquals(objA2, Scriptable.NOT_FOUND))
                  return ((Boolean) objA2).booleanValue();
              }
              if (y is ScriptableObject)
              {
                object objA2 = ((ScriptableObject) y).equivalentValues(x);
                if (!object.ReferenceEquals(objA2, Scriptable.NOT_FOUND))
                  return ((Boolean) objA2).booleanValue();
              }
              if (!(x is Wrapper) || !(y is Wrapper))
                return false;
              object obj4 = ((Wrapper) x).unwrap();
              object obj5 = ((Wrapper) y).unwrap();
              return object.ReferenceEquals(obj4, obj5) || ScriptRuntime.isPrimitive(obj4) && ScriptRuntime.isPrimitive(obj5) && ScriptRuntime.eq(obj4, obj5);
            case Boolean _:
              if (x is ScriptableObject)
              {
                object objA2 = ((ScriptableObject) x).equivalentValues(y);
                if (!object.ReferenceEquals(objA2, Scriptable.NOT_FOUND))
                  return ((Boolean) objA2).booleanValue();
              }
              return ScriptRuntime.eqNumber(!((Boolean) y).booleanValue() ? 0.0 : 1.0, x);
            case Number _:
              return ScriptRuntime.eqNumber(((Number) y).doubleValue(), x);
            default:
              if (!CharSequence.IsInstance(y))
                return false;
              object obj6 = y;
              CharSequence.Cast(obj6);
              object obj7 = x;
              object obj8 = obj6;
              CharSequence charSequence1;
              charSequence1.__\u003Cref\u003E = (__Null) obj8;
              return ScriptRuntime.eqString(charSequence1, obj7);
          }
        default:
          ScriptRuntime.warnAboutNonJSObject(x);
          return object.ReferenceEquals(x, y);
      }
    }

    [LineNumberTable(new byte[] {172, 239, 103, 108, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void exitActivationFunction(Context cx)
    {
      NativeCall currentActivationCall = cx.currentActivationCall;
      cx.currentActivationCall = currentActivationCall.parentActivationCall;
      currentActivationCall.parentActivationCall = (NativeCall) null;
    }

    [LineNumberTable(new byte[] {169, 129, 112, 102, 117, 109, 104, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static object[] getApplyArguments([In] Context obj0, [In] object obj1)
    {
      if (obj1 == null || object.ReferenceEquals(obj1, Undefined.__\u003C\u003Einstance))
        return ScriptRuntime.__\u003C\u003EemptyArgs;
      switch (obj1)
      {
        case Scriptable _ when ScriptRuntime.isArrayLike((Scriptable) obj1):
          return obj0.getElements((Scriptable) obj1);
        case ScriptableObject _:
          return ScriptRuntime.__\u003C\u003EemptyArgs;
        default:
          throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.typeError0("msg.arg.isnt.array"));
      }
    }

    [LineNumberTable(new byte[] {172, 230, 104, 107, 103, 108, 103, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void enterActivationFunction(Context cx, Scriptable scope)
    {
      if (cx.topCallScope == null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalStateException();
      }
      NativeCall nativeCall = (NativeCall) scope;
      nativeCall.parentActivationCall = cx.currentActivationCall;
      cx.currentActivationCall = nativeCall;
      nativeCall.defineAttributesForArguments();
    }

    [LineNumberTable(new byte[] {173, 234, 104, 103, 98, 107, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void setObjectProtoAndParent(ScriptableObject @object, Scriptable scope)
    {
      scope = ScriptableObject.getTopLevelScope(scope);
      @object.setParentScope(scope);
      Scriptable classPrototype = ScriptableObject.getClassPrototype(scope, @object.getClassName());
      @object.setPrototype(classPrototype);
    }

    [LineNumberTable(new byte[] {170, 10, 112, 114, 40, 166, 112, 144, 104, 110, 104, 110, 112, 112, 159, 1, 150})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object add(object val1, object val2, Context cx)
    {
      if (val1 is Number && val2 is Number)
        return (object) ScriptRuntime.wrapNumber(((Number) val1).doubleValue() + ((Number) val2).doubleValue());
      if (val1 is Symbol || val2 is Symbol)
        throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.typeError0("msg.not.a.number"));
      if (val1 is Scriptable)
        val1 = ((Scriptable) val1).getDefaultValue((Class) null);
      if (val2 is Scriptable)
        val2 = ((Scriptable) val2).getDefaultValue((Class) null);
      if (!CharSequence.IsInstance(val1) && !CharSequence.IsInstance(val2))
        return val1 is Number && val2 is Number ? (object) ScriptRuntime.wrapNumber(((Number) val1).doubleValue() + ((Number) val2).doubleValue()) : (object) ScriptRuntime.wrapNumber(ScriptRuntime.toNumber(val1) + ScriptRuntime.toNumber(val2));
      // ISSUE: variable of the null type
      __Null local = ScriptRuntime.toCharSequence(val1).__\u003Cref\u003E;
      object obj1 = (object) ScriptRuntime.toCharSequence(val2).__\u003Cref\u003E;
      object obj2 = (object) local;
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj2;
      CharSequence str1 = charSequence;
      object obj3 = obj1;
      charSequence.__\u003Cref\u003E = (__Null) obj3;
      CharSequence str2 = charSequence;
      return (object) new ConsString(str1, str2);
    }

    [LineNumberTable(new byte[] {162, 185, 104, 159, 5})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static CharSequence toCharSequence(object val)
    {
      if (val is NativeString)
      {
        object obj = (object) ((NativeString) val).toCharSequence().__\u003Cref\u003E;
        CharSequence charSequence;
        charSequence.__\u003Cref\u003E = (__Null) obj;
        return charSequence;
      }
      object obj1;
      if (CharSequence.IsInstance(val))
      {
        object obj2 = val;
        CharSequence.Cast(obj2);
        obj1 = obj2;
      }
      else
        obj1 = (object) ScriptRuntime.toString(val);
      object obj3 = obj1;
      CharSequence charSequence1;
      charSequence1.__\u003Cref\u003E = (__Null) obj3;
      return charSequence1;
    }

    [LineNumberTable(new byte[] {175, 169, 127, 4, 59})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static bool isGeneratedScript([In] string obj0)
    {
      string str1 = obj0;
      object obj1 = (object) "(eval)";
      CharSequence charSequence1;
      charSequence1.__\u003Cref\u003E = (__Null) obj1;
      CharSequence charSequence2 = charSequence1;
      if (!String.instancehelper_contains(str1, charSequence2))
      {
        string str2 = obj0;
        object obj2 = (object) "(Function)";
        charSequence1.__\u003Cref\u003E = (__Null) obj2;
        CharSequence charSequence3 = charSequence1;
        if (!String.instancehelper_contains(str2, charSequence3))
          return false;
      }
      return true;
    }

    [LineNumberTable(new byte[] {175, 79, 103, 136, 105, 106, 100, 191, 5, 109, 173, 104, 37})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static RuntimeException notFunctionError(
      object obj,
      object value,
      string propertyName)
    {
      string str = ScriptRuntime.toString(obj);
      if (obj is NativeFunction)
      {
        int num1 = String.instancehelper_indexOf(str, 41);
        int num2 = String.instancehelper_indexOf(str, 123, num1);
        if (num2 > -1)
          str = new StringBuilder().append(String.instancehelper_substring(str, 0, num2 + 1)).append("...}").toString();
      }
      return object.ReferenceEquals(value, Scriptable.NOT_FOUND) ? (RuntimeException) ScriptRuntime.typeError2("msg.function.not.found.in", (object) propertyName, (object) str) : (RuntimeException) ScriptRuntime.typeError3("msg.isnt.function.in", propertyName, str, ScriptRuntime.@typeof(value));
    }

    [LineNumberTable(new byte[] {172, 64, 102, 107, 134, 111, 109, 107, 127, 33, 98, 104, 193})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static ScriptableObject getGlobal(Context cx)
    {
      Class @class = Kit.classOrNull("rhino.tools.shell.Global");
      if (@class != null)
      {
        ScriptableObject scriptableObject;
        RuntimeException runtimeException;
        try
        {
          try
          {
            Class[] classArray = new Class[1]
            {
              ScriptRuntime.__\u003C\u003EContextClass
            };
            scriptableObject = (ScriptableObject) @class.getConstructor(classArray, ScriptRuntime.__\u003CGetCallerID\u003E()).newInstance(new object[1]
            {
              (object) cx
            }, ScriptRuntime.__\u003CGetCallerID\u003E());
          }
          catch (Exception ex)
          {
            M0 m0 = ByteCodeHelper.MapException<RuntimeException>(ex, (ByteCodeHelper.MapFlags) 0);
            if (m0 == null)
            {
              throw;
            }
            else
            {
              runtimeException = (RuntimeException) m0;
              goto label_8;
            }
          }
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
          else
            goto label_9;
        }
        return scriptableObject;
label_8:
        throw Throwable.__\u003Cunmap\u003E((Exception) runtimeException);
label_9:;
      }
      return (ScriptableObject) new ImporterTopLevel(cx);
    }

    [LineNumberTable(new byte[] {162, 230, 99, 102, 104, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static string defaultObjectToString([In] Scriptable obj0)
    {
      if (obj0 == null)
        return "[object Null]";
      return Undefined.isUndefined((object) obj0) ? "[object Undefined]" : new StringBuilder().append("[object ").append(obj0.getClassName()).append(']').toString();
    }

    [LineNumberTable(new byte[] {161, 219, 167, 162, 132, 134, 104, 136, 130, 198, 132, 113, 230, 76, 103, 102, 178, 104, 105, 107, 99, 108, 102, 112, 101, 112, 131, 101, 100, 141, 142, 101, 145, 115, 107, 108, 111, 237, 69, 134, 106, 132, 118, 218, 202, 172, 112, 107, 191, 11, 98, 234, 58, 235, 73, 122, 97})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static double toNumber(string s)
    {
      int num1 = String.instancehelper_length(s);
      for (int index1 = 0; index1 != num1; ++index1)
      {
        int num2 = (int) String.instancehelper_charAt(s, index1);
        if (!ScriptRuntime.isStrWhiteSpaceChar(num2))
        {
          int num3 = num1 - 1;
          int num4;
          while (ScriptRuntime.isStrWhiteSpaceChar(num4 = (int) String.instancehelper_charAt(s, num3)))
            num3 += -1;
          Context currentContext = Context.getCurrentContext();
          int num5 = currentContext == null || currentContext.getLanguageVersion() < 200 ? 1 : 0;
          if (num2 == 48)
          {
            if (index1 + 2 <= num3)
            {
              int num6 = (int) String.instancehelper_charAt(s, index1 + 1);
              int num7 = -1;
              if (num6 == 120 || num6 == 88)
                num7 = 16;
              else if (num5 == 0 && (num6 == 111 || num6 == 79))
                num7 = 8;
              else if (num5 == 0 && (num6 == 98 || num6 == 66))
                num7 = 2;
              if (num7 != -1)
                return num5 != 0 ? ScriptRuntime.stringPrefixToNumber(s, index1 + 2, num7) : ScriptRuntime.stringToNumber(s, index1 + 2, num3, num7);
            }
          }
          else if (num5 != 0 && (num2 == 43 || num2 == 45) && (index1 + 3 <= num3 && String.instancehelper_charAt(s, index1 + 1) == '0'))
          {
            switch (String.instancehelper_charAt(s, index1 + 2))
            {
              case 'X':
              case 'x':
                double number = ScriptRuntime.stringPrefixToNumber(s, index1 + 3, 16);
                return num2 == 45 ? -number : number;
            }
          }
          if (num4 == 121)
          {
            if (num2 == 43 || num2 == 45)
              ++index1;
            if (index1 + 7 != num3 || !String.instancehelper_regionMatches(s, index1, "Infinity", 0, 8))
              return double.NaN;
            return num2 == 45 ? double.NegativeInfinity : double.PositiveInfinity;
          }
          string str = String.instancehelper_substring(s, index1, num3 + 1);
          for (int index2 = String.instancehelper_length(str) - 1; index2 >= 0; index2 += -1)
          {
            int num6 = (int) String.instancehelper_charAt(str, index2);
            if ((48 > num6 || num6 > 57) && (num6 != 46 && num6 != 101) && (num6 != 69 && num6 != 43 && num6 != 45))
              return double.NaN;
          }
          double num8;
          try
          {
            num8 = Double.parseDouble(str);
          }
          catch (NumberFormatException ex)
          {
            goto label_41;
          }
          return num8;
label_41:
          return double.NaN;
        }
      }
      return 0.0;
    }

    [LineNumberTable(871)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static string toString(double val) => ScriptRuntime.numberToString(val, 10);

    [LineNumberTable(new byte[] {163, 22, 99, 134, 109, 134, 104, 108, 191, 0, 130, 104, 110, 119, 134, 135, 104, 135, 104, 167, 109, 109, 105, 105, 181, 135, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static string uneval([In] Context obj0, [In] Scriptable obj1, [In] object obj2)
    {
      if (obj2 == null)
        return "null";
      if (object.ReferenceEquals(obj2, Undefined.__\u003C\u003Einstance))
        return "undefined";
      if (CharSequence.IsInstance(obj2))
      {
        string str = ScriptRuntime.escapeString(Object.instancehelper_toString(obj2));
        return new StringBuilder().append('"').append(str).append('"').toString();
      }
      switch (obj2)
      {
        case Number _:
          double val = ((Number) obj2).doubleValue();
          return val == 0.0 && 1.0 / val < 0.0 ? "-0" : ScriptRuntime.toString(val);
        case Boolean _:
          return ScriptRuntime.toString(obj2);
        case Scriptable _:
          Scriptable s2 = (Scriptable) obj2;
          if (ScriptableObject.hasProperty(s2, "toSource"))
          {
            object property = ScriptableObject.getProperty(s2, "toSource");
            if (property is Function)
              return ScriptRuntime.toString(((Function) property).call(obj0, obj1, s2, ScriptRuntime.__\u003C\u003EemptyArgs));
          }
          return ScriptRuntime.toString(obj2);
        default:
          ScriptRuntime.warnAboutNonJSObject(obj2);
          return Object.instancehelper_toString(obj2);
      }
    }

    [LineNumberTable(1112)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static double toInteger(object val) => ScriptRuntime.toInteger(ScriptRuntime.toNumber(val));

    [LineNumberTable(new byte[] {163, 253, 106, 104, 131})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static long toLength(object[] args, int index)
    {
      double integer = ScriptRuntime.toInteger(args, index);
      return integer <= 0.0 ? 0L : ByteCodeHelper.d2l(Math.min(integer, 9.00719925474099E+15));
    }

    [LineNumberTable(new byte[] {174, 141, 103, 112, 108, 104, 136, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static void checkDeprecated([In] Context obj0, [In] string obj1)
    {
      int languageVersion = obj0.getLanguageVersion();
      if (languageVersion < 140 && languageVersion != 200)
        return;
      string message1 = ScriptRuntime.getMessage1("msg.deprec.ctor", (object) obj1);
      if (languageVersion != 200)
        throw Throwable.__\u003Cunmap\u003E((Exception) Context.reportRuntimeError(message1));
      Context.reportWarning(message1);
    }

    [LineNumberTable(864)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static string toString(object[] args, int index) => index < args.Length ? ScriptRuntime.toString(args[index]) : "undefined";

    [Signature("(Ljava/lang/Object;Ljava/lang/Class<*>;)Ljava/lang/Object;")]
    [LineNumberTable(new byte[] {170, 234, 104, 130, 103, 104, 112, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object toPrimitive(object val, Class typeHint)
    {
      if (!(val is Scriptable))
        return val;
      object defaultValue = ((Scriptable) val).getDefaultValue(typeHint);
      return !(defaultValue is Scriptable) || ScriptRuntime.isSymbol(defaultValue) ? defaultValue : throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.typeError0("msg.bad.default.value"));
    }

    [LineNumberTable(new byte[] {175, 31, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static EcmaError typeError3(
      string messageId,
      string arg1,
      string arg2,
      string arg3)
    {
      return ScriptRuntime.typeError(ScriptRuntime.getMessage3(messageId, (object) arg1, (object) arg2, (object) arg3));
    }

    [LineNumberTable(3052)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool isPrimitive(object obj)
    {
      if (obj != null && !object.ReferenceEquals(obj, Undefined.__\u003C\u003Einstance))
      {
        switch (obj)
        {
          case Number _:
          case string _:
          case Boolean _:
            break;
          default:
            return false;
        }
      }
      return true;
    }

    [LineNumberTable(412)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static double toNumber(object[] args, int index) => index < args.Length ? ScriptRuntime.toNumber(args[index]) : double.NaN;

    [LineNumberTable(new byte[] {163, 236, 105, 134, 114, 131, 105, 137})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static double toInteger(double d)
    {
      if (Double.isNaN(d))
        return 0.0;
      if (d == 0.0 || Double.isInfinite(d))
        return d;
      return d > 0.0 ? Math.floor(d) : Math.ceil(d);
    }

    [LineNumberTable(new byte[] {163, 208, 104, 105, 99, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Scriptable newBuiltinObject(
      Context cx,
      Scriptable scope,
      TopLevel.Builtins type,
      object[] args)
    {
      scope = ScriptableObject.getTopLevelScope(scope);
      Function builtinCtor = TopLevel.getBuiltinCtor(cx, scope, type);
      if (args == null)
        args = ScriptRuntime.__\u003C\u003EemptyArgs;
      return builtinCtor.construct(cx, scope, args);
    }

    [LineNumberTable(new byte[] {160, 196, 255, 71, 75, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static bool isStrWhiteSpaceChar([In] int obj0)
    {
      switch (obj0)
      {
        case 9:
        case 10:
        case 11:
        case 12:
        case 13:
        case 32:
        case 160:
        case 8232:
        case 8233:
        case 65279:
          return true;
        default:
          return Character.getType(obj0) == 12;
      }
    }

    [LineNumberTable(423)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static double stringPrefixToNumber([In] string obj0, [In] int obj1, [In] int obj2) => ScriptRuntime.stringToNumber(obj0, obj1, String.instancehelper_length(obj0) - 1, obj2, true);

    [LineNumberTable(new byte[] {169, 162, 101, 102, 100, 104, 109, 103, 144, 107, 102, 130, 100, 103, 104, 100, 135, 167, 101, 166, 140, 103, 100, 244, 70, 148, 105, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object evalSpecial(
      Context cx,
      Scriptable scope,
      object thisArg,
      object[] args,
      string filename,
      int lineNumber)
    {
      if (args.Length < 1)
        return Undefined.__\u003C\u003Einstance;
      object obj = args[0];
      if (!CharSequence.IsInstance(obj))
      {
        if (cx.hasFeature(11) || cx.hasFeature(9))
          throw Throwable.__\u003Cunmap\u003E((Exception) Context.reportRuntimeError0("msg.eval.nonstring.strict"));
        Context.reportWarning(ScriptRuntime.getMessage0("msg.eval.nonstring"));
        return obj;
      }
      if (filename == null)
      {
        int[] numArray = new int[1];
        filename = Context.getSourcePositionFromStack(numArray);
        if (filename != null)
          lineNumber = numArray[0];
        else
          filename = "";
      }
      string str = ScriptRuntime.makeUrlForGeneratedScript(true, filename, lineNumber);
      ErrorReporter errorReporter = DefaultErrorReporter.forEval(cx.getErrorReporter());
      Evaluator interpreter = Context.createInterpreter();
      if (interpreter == null)
      {
        string sourceName = filename;
        int lineNumber1 = lineNumber;
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new JavaScriptException((object) "Interpreter not present", sourceName, lineNumber1);
      }
      Script s = cx.compileString(Object.instancehelper_toString(obj), interpreter, errorReporter, str, 1, (object) null);
      interpreter.setEvalScriptFlag(s);
      return ((Callable) s).call(cx, scope, (Scriptable) thisArg, ScriptRuntime.__\u003C\u003EemptyArgs);
    }

    [LineNumberTable(new byte[] {163, 65, 104, 98, 98, 143, 98, 173, 107, 99, 140, 233, 69, 102, 109, 103, 108, 134, 105, 110, 107, 110, 101, 101, 108, 105, 101, 105, 107, 110, 101, 101, 108, 112, 139, 105, 101, 37, 134, 169, 105, 240, 36, 237, 96, 99, 135, 227, 61, 99, 201, 105, 99, 137})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static string defaultObjectToSource(
      [In] Context obj0,
      [In] Scriptable obj1,
      [In] Scriptable obj2,
      [In] object[] obj3)
    {
      int num1;
      int num2;
      if (obj0.iterating == null)
      {
        num1 = 1;
        num2 = 0;
        obj0.iterating = new ObjToIntMap(31);
      }
      else
      {
        num1 = 0;
        num2 = obj0.iterating.has((object) obj2) ? 1 : 0;
      }
      StringBuilder stringBuilder = new StringBuilder(128);
      if (num1 != 0)
        stringBuilder.append("(");
      stringBuilder.append('{');
      // ISSUE: fault handler
      try
      {
        if (num2 == 0)
        {
          obj0.iterating.intern((object) obj2);
          object[] ids = obj2.getIds();
          for (int index = 0; index < ids.Length; ++index)
          {
            object obj = ids[index];
            object objA;
            if (obj is Integer)
            {
              int i = ((Integer) obj).intValue();
              objA = obj2.get(i, obj2);
              if (!object.ReferenceEquals(objA, Scriptable.NOT_FOUND))
              {
                if (index > 0)
                  stringBuilder.append(", ");
                stringBuilder.append(i);
              }
              else
                continue;
            }
            else
            {
              string str = (string) obj;
              objA = obj2.get(str, obj2);
              if (!object.ReferenceEquals(objA, Scriptable.NOT_FOUND))
              {
                if (index > 0)
                  stringBuilder.append(", ");
                if (ScriptRuntime.isValidIdentifierName(str, obj0, obj0.isStrictMode()))
                {
                  stringBuilder.append(str);
                }
                else
                {
                  stringBuilder.append('\'');
                  stringBuilder.append(ScriptRuntime.escapeString(str, '\''));
                  stringBuilder.append('\'');
                }
              }
              else
                continue;
            }
            stringBuilder.append(':');
            stringBuilder.append(ScriptRuntime.uneval(obj0, obj1, objA));
          }
        }
      }
      __fault
      {
        if (num1 != 0)
          obj0.iterating = (ObjToIntMap) null;
      }
      if (num1 != 0)
        obj0.iterating = (ObjToIntMap) null;
      stringBuilder.append('}');
      if (num1 != 0)
        stringBuilder.append(')');
      return stringBuilder.toString();
    }

    [LineNumberTable(new byte[] {171, 75, 115, 130, 104, 112, 130, 136})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool same(object x, object y)
    {
      if (!String.instancehelper_equals(ScriptRuntime.@typeof(x), (object) ScriptRuntime.@typeof(y)))
        return false;
      if (!(x is Number))
        return ScriptRuntime.eq(x, y);
      return ScriptRuntime.isNaN(x) && ScriptRuntime.isNaN(y) || Object.instancehelper_equals(x, y);
    }

    [LineNumberTable(new byte[] {157, 158, 66, 144, 140, 104, 144, 103, 153, 107, 104, 144, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Scriptable toIterator(
      Context cx,
      Scriptable scope,
      Scriptable obj,
      bool keyOnly)
    {
      int num = keyOnly ? 1 : 0;
      if (!ScriptableObject.hasProperty(obj, "__iterator__"))
        return (Scriptable) null;
      object property = ScriptableObject.getProperty(obj, "__iterator__");
      Callable callable = property is Callable ? (Callable) property : throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.typeError0("msg.invalid.iterator"));
      object[] objarr = new object[1]
      {
        num == 0 ? (object) Boolean.FALSE : (object) Boolean.TRUE
      };
      object obj1 = callable.call(cx, scope, obj, objarr);
      return obj1 is Scriptable ? (Scriptable) obj1 : throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.typeError0("msg.iterator.primitive"));
    }

    [LineNumberTable(new byte[] {157, 134, 130, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void setEnumNumbers(object enumObj, bool enumNumbers)
    {
      int num = enumNumbers ? 1 : 0;
      ((ScriptRuntime.IdEnumeration) enumObj).enumNumbers = num != 0;
    }

    [LineNumberTable(268)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static string[] getTopPackageNames() => String.instancehelper_equals("Dalvik", (object) java.lang.System.getProperty("java.vm.name")) ? new string[7]
    {
      "java",
      "javax",
      "org",
      "com",
      "edu",
      "net",
      "android"
    } : new string[6]
    {
      "java",
      "javax",
      "org",
      "com",
      "edu",
      "net"
    };

    [LineNumberTable(new byte[] {164, 39, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static char toUint16(object val) => (char) DoubleConversion.doubleToInt32(ScriptRuntime.toNumber(val));

    [LineNumberTable(1131)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static double toInteger(object[] args, int index) => index < args.Length ? ScriptRuntime.toInteger(args[index]) : 0.0;

    [LineNumberTable(291)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool isJSWhitespaceOrLineTerminator(int c) => ScriptRuntime.isStrWhiteSpaceChar(c) || ScriptRuntime.isJSLineTerminator(c);

    [LineNumberTable(3960)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static EcmaError rangeError(string message) => ScriptRuntime.constructError("RangeError", message);

    [LineNumberTable(new byte[] {175, 212, 107, 103, 118, 38, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static JavaScriptException throwCustomError(
      Context cx,
      Scriptable scope,
      string constructorName,
      string message)
    {
      int[] numArray = new int[1]{ 0 };
      string positionFromStack = Context.getSourcePositionFromStack(numArray);
      Scriptable scriptable = cx.newObject(scope, constructorName, new object[3]
      {
        (object) message,
        (object) positionFromStack,
        (object) Integer.valueOf(numArray[0])
      });
      JavaScriptException.__\u003Cclinit\u003E();
      return new JavaScriptException((object) scriptable, positionFromStack, numArray[0]);
    }

    [LineNumberTable(new byte[] {169, 237, 99, 130, 109, 130, 104, 108, 159, 0, 104, 141})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool isObject(object value)
    {
      if (value == null || Object.instancehelper_equals(Undefined.__\u003C\u003Einstance, value))
        return false;
      switch (value)
      {
        case ScriptableObject _:
          string str = ((ScriptableObject) value).getTypeOf();
          return String.instancehelper_equals("object", (object) str) || String.instancehelper_equals("function", (object) str);
        case Scriptable _:
          return !(value is Callable);
        default:
          return false;
      }
    }

    [LineNumberTable(4137)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static RuntimeException errorWithClassName([In] string obj0, [In] object obj1) => (RuntimeException) Context.reportRuntimeError1(obj0, (object) Object.instancehelper_getClass(obj1).getName());

    [LineNumberTable(new byte[] {175, 101, 107, 109, 119, 134, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void warnAboutNonJSObject([In] object obj0)
    {
      if (String.instancehelper_equals("true", (object) ScriptRuntime.getMessage0("params.omit.non.js.object.warning")))
        return;
      string message2 = ScriptRuntime.getMessage2("msg.non.js.object.warning", obj0, (object) Object.instancehelper_getClass(obj0).getName());
      Context.reportWarning(message2);
      java.lang.System.err.println(message2);
    }

    [LineNumberTable(new byte[] {159, 34, 131, 99, 99, 99, 101, 136, 101, 105, 169, 103, 107, 138, 107, 105, 107, 108, 107, 108, 99, 170, 238, 51, 235, 79, 101, 138, 112, 229, 71, 127, 2, 97, 138, 249, 76, 99, 131, 98, 98, 98, 98, 130, 99, 100, 103, 131, 99, 163, 104, 102, 101, 112, 108, 105, 108, 137, 103, 131, 102, 141, 159, 1, 103, 102, 103, 200, 112, 100, 108, 102, 100, 100, 197, 100, 107, 99, 130, 100, 195, 176, 101, 157, 103, 194, 194, 103, 108, 105, 194, 100, 108, 233, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static double stringToNumber([In] string obj0, [In] int obj1, [In] int obj2, [In] int obj3, [In] bool obj4)
    {
      int num1 = obj4 ? 1 : 0;
      int num2 = 57;
      int num3 = 97;
      int num4 = 65;
      if (obj3 < 10)
        num2 = (int) (ushort) (48 + obj3 - 1);
      if (obj3 > 10)
      {
        num3 = (int) (ushort) (97 + obj3 - 10);
        num4 = (int) (ushort) (65 + obj3 - 10);
      }
      double num5 = 0.0;
      int num6;
      for (num6 = obj1; num6 <= obj2; ++num6)
      {
        int num7 = (int) String.instancehelper_charAt(obj0, num6);
        int num8;
        if (48 <= num7 && num7 <= num2)
          num8 = num7 - 48;
        else if (97 <= num7 && num7 < num3)
          num8 = num7 - 97 + 10;
        else if (65 <= num7 && num7 < num4)
        {
          num8 = num7 - 65 + 10;
        }
        else
        {
          if (num1 == 0)
            return double.NaN;
          break;
        }
        num5 = num5 * (double) obj3 + (double) num8;
      }
      if (obj1 == num6)
        return double.NaN;
      if (num5 > 9.00719925474099E+15)
      {
        switch (obj3)
        {
          case 2:
          case 4:
          case 8:
          case 16:
          case 32:
            int num9 = 1;
            int num10 = 0;
            int num11 = 0;
            int num12 = 53;
            double num13 = 0.0;
            int num14 = 0;
            int num15 = 0;
            int num16 = obj1;
            while (true)
            {
              int num7;
              do
              {
                do
                {
                  if (num9 == 1)
                  {
                    if (num16 != num6)
                    {
                      string str = obj0;
                      int num8 = num16;
                      ++num16;
                      int num17 = (int) String.instancehelper_charAt(str, num8);
                      num10 = 48 > num17 || num17 > 57 ? (97 > num17 || num17 > 122 ? num17 - 55 : num17 - 87) : num17 - 48;
                      num9 = obj3;
                    }
                    else
                      goto label_38;
                  }
                  num9 >>= 1;
                  num7 = (num10 & num9) == 0 ? 0 : 1;
                  switch (num11)
                  {
                    case 0:
                      continue;
                    case 1:
                      goto label_30;
                    case 2:
                      goto label_34;
                    case 3:
                      goto label_35;
                    case 4:
                      goto label_37;
                    default:
                      continue;
                  }
                }
                while (num7 == 0);
                num12 += -1;
                num5 = 1.0;
                num11 = 1;
                continue;
label_30:
                num5 *= 2.0;
                if (num7 != 0)
                  ++num5;
                num12 += -1;
              }
              while (num12 != 0);
              num14 = num7;
              num11 = 2;
              continue;
label_34:
              num15 = num7;
              num13 = 2.0;
              num11 = 3;
              continue;
label_35:
              if (num7 != 0)
                num11 = 4;
label_37:
              num13 *= 2.0;
            }
label_38:
            switch (num11)
            {
              case 0:
                num5 = 0.0;
                break;
              case 3:
                if ((num15 & num14) != 0)
                  ++num5;
                num5 *= num13;
                break;
              case 4:
                if (num15 != 0)
                  ++num5;
                num5 *= num13;
                break;
            }
            break;
          case 10:
            double num18;
            try
            {
              num18 = Double.parseDouble(String.instancehelper_substring(obj0, obj1, num6));
            }
            catch (NumberFormatException ex)
            {
              goto label_22;
            }
            return num18;
label_22:
            return double.NaN;
        }
      }
      return num5;
    }

    [LineNumberTable(427)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static double stringToNumber([In] string obj0, [In] int obj1, [In] int obj2, [In] int obj3) => ScriptRuntime.stringToNumber(obj0, obj1, obj2, obj3, false);

    [LineNumberTable(new byte[] {158, 218, 98, 117, 130, 112, 137, 183, 102, 207, 99, 105, 104, 167, 99, 159, 40, 100, 130, 100, 130, 100, 130, 100, 130, 100, 130, 100, 130, 100, 130, 164, 133, 105, 111, 101, 105, 173, 137, 108, 165, 108, 163, 109, 109, 116, 234, 61, 233, 1, 233, 160, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static string escapeString(string s, char escapeQuote)
    {
      int num1 = (int) escapeQuote;
      switch (num1)
      {
        case 34:
        case 39:
        case 96:
          StringBuilder stringBuilder = (StringBuilder) null;
          int num2 = 0;
          for (int index1 = String.instancehelper_length(s); num2 != index1; ++num2)
          {
            int num3 = (int) String.instancehelper_charAt(s, num2);
            if (32 <= num3 && num3 <= 126 && (num3 != num1 && num3 != 92))
            {
              stringBuilder?.append((char) num3);
            }
            else
            {
              if (stringBuilder == null)
              {
                stringBuilder = new StringBuilder(index1 + 3);
                stringBuilder.append(s);
                stringBuilder.setLength(num2);
              }
              int num4 = -1;
              switch (num3)
              {
                case 8:
                  num4 = 98;
                  break;
                case 9:
                  num4 = 116;
                  break;
                case 10:
                  num4 = 110;
                  break;
                case 11:
                  num4 = 118;
                  break;
                case 12:
                  num4 = 102;
                  break;
                case 13:
                  num4 = 114;
                  break;
                case 32:
                  num4 = 32;
                  break;
                case 92:
                  num4 = 92;
                  break;
              }
              if (num4 >= 0)
              {
                stringBuilder.append('\\');
                stringBuilder.append((char) num4);
              }
              else if (num3 == num1)
              {
                stringBuilder.append('\\');
                stringBuilder.append((char) num1);
              }
              else
              {
                int num5;
                if (num3 < 256)
                {
                  stringBuilder.append("\\x");
                  num5 = 2;
                }
                else
                {
                  stringBuilder.append("\\u");
                  num5 = 4;
                }
                for (int index2 = (num5 - 1) * 4; index2 >= 0; index2 += -4)
                {
                  int num6 = 15 & num3 >> index2;
                  int num7 = num6 >= 10 ? 87 + num6 : 48 + num6;
                  stringBuilder.append((char) num7);
                }
              }
            }
          }
          return stringBuilder == null ? s : stringBuilder.toString();
        default:
          Kit.codeBug();
          goto case 34;
      }
    }

    [LineNumberTable(new byte[] {158, 199, 130, 103, 99, 98, 110, 98, 102, 110, 2, 198})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static bool isValidIdentifierName([In] string obj0, [In] Context obj1, [In] bool obj2)
    {
      int num1 = obj2 ? 1 : 0;
      int num2 = String.instancehelper_length(obj0);
      if (num2 == 0 || !Character.isJavaIdentifierStart(String.instancehelper_charAt(obj0, 0)))
        return false;
      for (int index = 1; index != num2; ++index)
      {
        if (!Character.isJavaIdentifierPart(String.instancehelper_charAt(obj0, index)))
          return false;
      }
      return !TokenStream.isKeyword(obj0, obj1.getLanguageVersion(), num1 != 0);
    }

    [LineNumberTable(new byte[] {164, 97, 131, 103, 103, 98, 98, 104, 101, 100, 104, 104, 98, 162, 101, 254, 69, 100, 99, 100, 132, 120, 100, 105, 230, 69, 255, 1, 69, 211})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static long indexFromString(string str)
    {
      int num1 = String.instancehelper_length(str);
      if (num1 > 0)
      {
        int num2 = 0;
        int num3 = 0;
        int num4 = (int) String.instancehelper_charAt(str, 0);
        if (num4 == 45 && num1 > 1)
        {
          num4 = (int) String.instancehelper_charAt(str, 1);
          if (num4 == 48)
            return -1;
          num2 = 1;
          num3 = 1;
        }
        int num5 = num4 - 48;
        if (0 <= num5 && num5 <= 9 && num1 <= (num3 == 0 ? 10 : 11))
        {
          int num6 = -num5;
          int num7 = 0;
          int num8 = num2 + 1;
          if (num6 != 0)
          {
            for (; num8 != num1 && 0 <= (num5 = (int) String.instancehelper_charAt(str, num8) - 48) && num5 <= 9; ++num8)
            {
              num7 = num6;
              num6 = 10 * num6 - num5;
            }
          }
          if (num8 == num1 && (num7 > -214748364 || num7 == -214748364 && num5 <= (num3 == 0 ? 7 : 8)))
            return (long) uint.MaxValue & (num3 == 0 ? (long) -num6 : (long) num6);
        }
      }
      return -1;
    }

    [LineNumberTable(3990)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static RuntimeException undefReadError(object @object, object id) => (RuntimeException) ScriptRuntime.typeError2("msg.undef.prop.read", (object) ScriptRuntime.toString(@object), (object) ScriptRuntime.toString(id));

    [LineNumberTable(new byte[] {165, 64, 104, 109, 106, 176, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object getObjectProp(Scriptable obj, string property, Context cx)
    {
      object objA = ScriptableObject.getProperty(obj, property);
      if (object.ReferenceEquals(objA, Scriptable.NOT_FOUND))
      {
        if (cx.hasFeature(11))
          Context.reportWarning(ScriptRuntime.getMessage1("msg.ref.undefined.prop", (object) property));
        objA = Undefined.__\u003C\u003Einstance;
      }
      return objA;
    }

    [LineNumberTable(new byte[] {165, 130, 104, 109, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object getObjectIndex(Scriptable obj, int index, Context cx)
    {
      object objA = ScriptableObject.getProperty(obj, index);
      if (object.ReferenceEquals(objA, Scriptable.NOT_FOUND))
        objA = Undefined.__\u003C\u003Einstance;
      return objA;
    }

    [LineNumberTable(new byte[] {175, 46, 114, 37})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static RuntimeException undefWriteError(
      object @object,
      object id,
      object value)
    {
      return (RuntimeException) ScriptRuntime.typeError3("msg.undef.prop.write", ScriptRuntime.toString(@object), ScriptRuntime.toString(id), ScriptRuntime.toString(value));
    }

    [LineNumberTable(new byte[] {165, 162, 104, 143, 104, 104, 143, 205})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object setObjectElem(Scriptable obj, object elem, object value, Context cx)
    {
      if (ScriptRuntime.isSymbol(elem))
      {
        ScriptableObject.putProperty(obj, (Symbol) elem, value);
      }
      else
      {
        ScriptRuntime.StringIdOrIndex stringIdOrIndex = ScriptRuntime.toStringIdOrIndex(cx, elem);
        if (stringIdOrIndex.stringId == null)
          ScriptableObject.putProperty(obj, stringIdOrIndex.index, value);
        else
          ScriptableObject.putProperty(obj, stringIdOrIndex.stringId, value);
      }
      return value;
    }

    [LineNumberTable(new byte[] {165, 208, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object setObjectProp(Scriptable obj, string property, object value, Context cx)
    {
      ScriptableObject.putProperty(obj, property, value);
      return value;
    }

    [LineNumberTable(new byte[] {165, 245, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object setObjectIndex(Scriptable obj, int index, object value, Context cx)
    {
      ScriptableObject.putProperty(obj, index, value);
      return value;
    }

    [Obsolete]
    [LineNumberTable(1739)]
    [Deprecated(new object[] {64, "Ljava/lang/Deprecated;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object delete(object obj, object id, Context cx, bool isName)
    {
      int num = isName ? 1 : 0;
      return ScriptRuntime.delete(obj, id, cx, ScriptRuntime.getTopCallScope(cx), num != 0);
    }

    [LineNumberTable(4005)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static RuntimeException undefDeleteError([In] object obj0, [In] object obj1) => throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.typeError2("msg.undef.prop.delete", (object) ScriptRuntime.toString(obj0), (object) ScriptRuntime.toString(obj1)));

    [LineNumberTable(new byte[] {165, 251, 104, 103, 103, 103, 143, 104, 104, 108, 148, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool deleteObjectElem(Scriptable target, object elem, Context cx)
    {
      if (ScriptRuntime.isSymbol(elem))
      {
        SymbolScriptable symbolScriptable = ScriptableObject.ensureSymbolScriptable((object) target);
        Symbol symbol = (Symbol) elem;
        symbolScriptable.delete(symbol);
        return !symbolScriptable.has(symbol, target);
      }
      ScriptRuntime.StringIdOrIndex stringIdOrIndex = ScriptRuntime.toStringIdOrIndex(cx, elem);
      if (stringIdOrIndex.stringId == null)
      {
        target.delete(stringIdOrIndex.index);
        return !target.has(stringIdOrIndex.index, target);
      }
      target.delete(stringIdOrIndex.stringId);
      return !target.has(stringIdOrIndex.stringId, target);
    }

    [LineNumberTable(new byte[] {166, 195, 104, 142})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static object topScopeName([In] Context obj0, [In] Scriptable obj1, [In] string obj2)
    {
      if (obj0.useDynamicScope)
        obj1 = ScriptRuntime.checkDynamicScope(obj0.topCallScope, obj1);
      return ScriptableObject.getProperty(obj1, obj2);
    }

    [LineNumberTable(new byte[] {175, 57, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static RuntimeException notFoundError(
      Scriptable @object,
      string property)
    {
      throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.constructError("ReferenceError", ScriptRuntime.getMessage1("msg.is.not.defined", (object) property)));
    }

    [LineNumberTable(new byte[] {157, 208, 131, 162, 104, 135, 104, 141, 98, 133, 170, 105, 109, 166, 97, 232, 71, 104, 109, 98, 162, 99, 104, 102, 105, 109, 173, 98, 194, 99, 104, 141, 167})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static object nameOrFunction(
      [In] Context obj0,
      [In] Scriptable obj1,
      [In] Scriptable obj2,
      [In] string obj3,
      [In] bool obj4)
    {
      int num = obj4 ? 1 : 0;
      Scriptable scriptable = obj1;
      object objA;
      do
      {
        switch (obj1)
        {
          case NativeWith _:
            Scriptable prototype = obj1.getPrototype();
            objA = ScriptableObject.getProperty(prototype, obj3);
            if (!object.ReferenceEquals(objA, Scriptable.NOT_FOUND))
            {
              scriptable = prototype;
              goto label_13;
            }
            else
              break;
          case NativeCall _:
            objA = obj1.get(obj3, obj1);
            if (!object.ReferenceEquals(objA, Scriptable.NOT_FOUND))
            {
              if (num != 0)
              {
                scriptable = ScriptableObject.getTopLevelScope(obj2);
                goto label_13;
              }
              else
                goto label_13;
            }
            else
              break;
          default:
            objA = ScriptableObject.getProperty(obj1, obj3);
            if (!object.ReferenceEquals(objA, Scriptable.NOT_FOUND))
            {
              scriptable = obj1;
              goto label_13;
            }
            else
              break;
        }
        obj1 = obj2;
        obj2 = obj2.getParentScope();
      }
      while (obj2 != null);
      objA = ScriptRuntime.topScopeName(obj0, obj1, obj3);
      if (object.ReferenceEquals(objA, Scriptable.NOT_FOUND))
        throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.notFoundError(obj1, obj3));
      scriptable = obj1;
label_13:
      if (num != 0)
      {
        if (!(objA is Callable))
          throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.notFunctionError(objA, (object) obj3));
        ScriptRuntime.storeScriptable(obj0, scriptable);
      }
      return objA;
    }

    [LineNumberTable(new byte[] {175, 147, 104, 107, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void storeScriptable([In] Context obj0, [In] Scriptable obj1)
    {
      if (obj0.scratchScriptable != null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalStateException();
      }
      obj0.scratchScriptable = obj1;
    }

    [LineNumberTable(new byte[] {172, 141, 105, 130, 130, 103, 105, 130, 99})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static Scriptable checkDynamicScope([In] Scriptable obj0, [In] Scriptable obj1)
    {
      if (object.ReferenceEquals((object) obj0, (object) obj1))
        return obj0;
      Scriptable scriptable = obj0;
      do
      {
        scriptable = scriptable.getPrototype();
        if (object.ReferenceEquals((object) scriptable, (object) obj1))
          return obj0;
      }
      while (scriptable != null);
      return obj1;
    }

    [Obsolete]
    [LineNumberTable(2026)]
    [Deprecated(new object[] {64, "Ljava/lang/Deprecated;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object enumInit(object value, Context cx, int enumType) => ScriptRuntime.enumInit(value, cx, ScriptRuntime.getTopCallScope(cx), enumType);

    [LineNumberTable(new byte[] {167, 156, 127, 0, 187, 113, 104, 155, 103, 108, 103, 113, 105, 155, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static object enumInitInOrder([In] Context obj0, [In] ScriptRuntime.IdEnumeration obj1)
    {
      if (!(obj1.obj is SymbolScriptable) || !ScriptableObject.hasProperty(obj1.obj, (Symbol) SymbolKey.__\u003C\u003EITERATOR))
        throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.typeError1("msg.not.iterable", (object) ScriptRuntime.toString((object) obj1.obj)));
      object property = ScriptableObject.getProperty(obj1.obj, (Symbol) SymbolKey.__\u003C\u003EITERATOR);
      Callable callable = property is Callable ? (Callable) property : throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.typeError1("msg.not.iterable", (object) ScriptRuntime.toString((object) obj1.obj)));
      Scriptable parentScope = obj1.obj.getParentScope();
      object[] objarr = new object[0];
      object obj = callable.call(obj0, parentScope, obj1.obj, objarr);
      obj1.iterator = obj is Scriptable ? (Scriptable) obj : throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.typeError1("msg.not.iterable", (object) ScriptRuntime.toString((object) obj1.obj)));
      return (object) obj1;
    }

    [LineNumberTable(new byte[] {168, 36, 98, 104, 108, 100, 130, 147, 112, 103, 99, 104, 140, 102, 47, 198, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void enumChangeObject([In] ScriptRuntime.IdEnumeration obj0)
    {
      object[] objArray = (object[]) null;
      for (; obj0.obj != null; obj0.obj = obj0.obj.getPrototype())
      {
        objArray = obj0.obj.getIds();
        if (objArray.Length != 0)
          break;
      }
      if (obj0.obj != null && obj0.ids != null)
      {
        object[] ids = obj0.ids;
        int length = ids.Length;
        if (obj0.used == null)
          obj0.used = new ObjToIntMap(length);
        for (int index = 0; index != length; ++index)
          obj0.used.intern(ids[index]);
      }
      obj0.ids = objArray;
      obj0.index = 0;
    }

    [LineNumberTable(new byte[] {167, 233, 113, 104, 150, 103, 102, 108, 117, 107, 110, 119, 134, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static Boolean enumNextInOrder([In] ScriptRuntime.IdEnumeration obj0)
    {
      object property1 = ScriptableObject.getProperty(obj0.iterator, "next");
      Callable callable = property1 is Callable ? (Callable) property1 : throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.notFunctionError((object) obj0.iterator, (object) "next"));
      Context context = Context.getContext();
      Scriptable parentScope = obj0.iterator.getParentScope();
      object val = callable.call(context, parentScope, obj0.iterator, ScriptRuntime.__\u003C\u003EemptyArgs);
      Scriptable scriptable = ScriptRuntime.toObject(context, parentScope, val);
      object property2 = ScriptableObject.getProperty(scriptable, "done");
      if (!object.ReferenceEquals(property2, Scriptable.NOT_FOUND) && ScriptRuntime.toBoolean(property2))
        return (Boolean) Boolean.FALSE;
      obj0.currentId = ScriptableObject.getProperty(scriptable, "value");
      return (Boolean) Boolean.TRUE;
    }

    [LineNumberTable(new byte[] {168, 16, 199, 109, 108, 120, 98, 109, 104, 154, 216})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object enumValue(object enumObj, Context cx)
    {
      ScriptRuntime.IdEnumeration idEnumeration = (ScriptRuntime.IdEnumeration) enumObj;
      object obj;
      if (ScriptRuntime.isSymbol(idEnumeration.currentId))
      {
        obj = ScriptableObject.ensureSymbolScriptable((object) idEnumeration.obj).get((Symbol) idEnumeration.currentId, idEnumeration.obj);
      }
      else
      {
        ScriptRuntime.StringIdOrIndex stringIdOrIndex = ScriptRuntime.toStringIdOrIndex(cx, idEnumeration.currentId);
        obj = stringIdOrIndex.stringId != null ? idEnumeration.obj.get(stringIdOrIndex.stringId, idEnumeration.obj) : idEnumeration.obj.get(stringIdOrIndex.index, idEnumeration.obj);
      }
      return obj;
    }

    [LineNumberTable(3994)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static RuntimeException undefCallError(object @object, object id) => (RuntimeException) ScriptRuntime.typeError2("msg.undef.method.call", (object) ScriptRuntime.toString(@object), (object) ScriptRuntime.toString(id));

    [LineNumberTable(new byte[] {168, 176, 99, 173, 104, 104, 108, 104, 173, 104, 174, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static Callable getPropFunctionAndThisHelper(
      [In] object obj0,
      [In] string obj1,
      [In] Context obj2,
      [In] Scriptable obj3)
    {
      object obj = obj3 != null ? ScriptableObject.getProperty(obj3, obj1) : throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.undefCallError(obj0, (object) obj1));
      if (!(obj is Callable))
      {
        object property = ScriptableObject.getProperty(obj3, "__noSuchMethod__");
        if (property is Callable)
          obj = (object) new ScriptRuntime.NoSuchMethodShim((Callable) property, obj1);
      }
      if (!(obj is Callable))
        throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.notFunctionError((object) obj3, obj, obj1));
      ScriptRuntime.storeScriptable(obj2, obj3);
      return (Callable) obj;
    }

    [LineNumberTable(new byte[] {169, 29, 104, 140, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Scriptable newObject(
      object fun,
      Context cx,
      Scriptable scope,
      object[] args)
    {
      if (!(fun is Function))
        throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.notFunctionError(fun));
      return ((Function) fun).construct(cx, scope, args);
    }

    [LineNumberTable(new byte[] {169, 121, 185, 235, 61})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool isArrayLike([In] Scriptable obj0) => obj0 != null && (obj0 is NativeArray || obj0 is Arguments || ScriptableObject.hasProperty(obj0, "length"));

    [LineNumberTable(new byte[] {170, 105, 139, 104, 108, 102, 134, 132, 103, 105, 168, 107, 110, 124, 104, 102, 136, 134, 105, 106, 233, 69, 104, 144, 105, 131, 168, 102, 140, 138, 104, 106, 99, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static object doScriptableIncrDecr(
      [In] Scriptable obj0,
      [In] string obj1,
      [In] Scriptable obj2,
      [In] object obj3,
      [In] int obj4)
    {
      int num1 = (obj4 & 2) == 0 ? 0 : 1;
      if (obj3 is Integer)
      {
        int num2 = ((Integer) obj3).intValue();
        Integer integer = ScriptRuntime.wrapInt((obj4 & 1) != 0 ? num2 - 1 : num2 + 1);
        obj0.put(obj1, obj2, (object) integer);
        return num1 != 0 ? obj3 : (object) integer;
      }
      if (obj3 is Double)
      {
        double num2 = ((Double) obj3).doubleValue();
        if (Math.floor(num2) == num2 && Math.abs(num2) < 9.00719925474099E+15)
        {
          int num3 = ByteCodeHelper.d2i(num2);
          Integer integer = ScriptRuntime.wrapInt((obj4 & 1) != 0 ? num3 - 1 : num3 + 1);
          obj0.put(obj1, obj2, (object) integer);
          return num1 != 0 ? obj3 : (object) integer;
        }
      }
      double x;
      if (obj3 is Number)
      {
        x = ((Number) obj3).doubleValue();
      }
      else
      {
        x = ScriptRuntime.toNumber(obj3);
        if (num1 != 0)
          obj3 = (object) ScriptRuntime.wrapNumber(x);
      }
      Number number = ScriptRuntime.wrapNumber((obj4 & 1) != 0 ? x - 1.0 : x + 1.0);
      obj0.put(obj1, obj2, (object) number);
      return num1 != 0 ? obj3 : (object) number;
    }

    [LineNumberTable(new byte[] {156, 139, 170, 112, 98, 107, 105, 127, 51, 104, 127, 7, 104, 127, 20, 104, 98, 104, 104, 126, 110, 173, 141, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool eqString([In] CharSequence obj0, [In] object obj1)
    {
      object obj2 = (object) obj0.__\u003Cref\u003E;
      for (; obj1 != null && !object.ReferenceEquals(obj1, Undefined.__\u003C\u003Einstance); obj1 = ScriptRuntime.toPrimitive(obj1))
      {
        CharSequence charSequence;
        if (CharSequence.IsInstance(obj1))
        {
          object obj3 = obj1;
          CharSequence.Cast(obj3);
          object obj4 = obj3;
          object obj5 = obj2;
          charSequence.__\u003Cref\u003E = (__Null) obj5;
          int num1 = ((CharSequence) ref charSequence).length();
          object obj6 = obj4;
          charSequence.__\u003Cref\u003E = (__Null) obj6;
          int num2 = ((CharSequence) ref charSequence).length();
          if (num1 == num2)
          {
            object obj7 = obj2;
            charSequence.__\u003Cref\u003E = (__Null) obj7;
            string str1 = ((CharSequence) ref charSequence).toString();
            object obj8 = obj4;
            charSequence.__\u003Cref\u003E = (__Null) obj8;
            string str2 = ((CharSequence) ref charSequence).toString();
            if (String.instancehelper_equals(str1, (object) str2))
              return true;
          }
          return false;
        }
        if (obj1 is Number)
        {
          object obj3 = obj2;
          charSequence.__\u003Cref\u003E = (__Null) obj3;
          return ScriptRuntime.toNumber(((CharSequence) ref charSequence).toString()) == ((Number) obj1).doubleValue();
        }
        if (obj1 is Boolean)
        {
          object obj3 = obj2;
          charSequence.__\u003Cref\u003E = (__Null) obj3;
          return ScriptRuntime.toNumber(((CharSequence) ref charSequence).toString()) == (!((Boolean) obj1).booleanValue() ? 0.0 : 1.0);
        }
        if (ScriptRuntime.isSymbol(obj1))
          return false;
        if (obj1 is Scriptable)
        {
          if (obj1 is ScriptableObject)
          {
            ScriptableObject scriptableObject = (ScriptableObject) obj1;
            object obj3 = obj2;
            charSequence.__\u003Cref\u003E = (__Null) obj3;
            string str = ((CharSequence) ref charSequence).toString();
            object objA = scriptableObject.equivalentValues((object) str);
            if (!object.ReferenceEquals(objA, Scriptable.NOT_FOUND))
              return ((Boolean) objA).booleanValue();
          }
        }
        else
        {
          ScriptRuntime.warnAboutNonJSObject(obj1);
          return false;
        }
      }
      return false;
    }

    [LineNumberTable(new byte[] {171, 112, 104, 146, 104, 146})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool isNaN(object n)
    {
      switch (n)
      {
        case Double _:
          return Double.isNaN(((Double) n).doubleValue());
        case Float _:
          return Float.isNaN(((Float) n).floatValue());
        default:
          return false;
      }
    }

    [LineNumberTable(2904)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object toPrimitive(object val) => ScriptRuntime.toPrimitive(val, (Class) null);

    [LineNumberTable(new byte[] {166, 14, 104, 143, 104, 104, 143, 205})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool hasObjectElem(Scriptable target, object elem, Context cx)
    {
      int num;
      if (ScriptRuntime.isSymbol(elem))
      {
        num = ScriptableObject.hasProperty(target, (Symbol) elem) ? 1 : 0;
      }
      else
      {
        ScriptRuntime.StringIdOrIndex stringIdOrIndex = ScriptRuntime.toStringIdOrIndex(cx, elem);
        num = stringIdOrIndex.stringId != null ? (ScriptableObject.hasProperty(target, stringIdOrIndex.stringId) ? 1 : 0) : (ScriptableObject.hasProperty(target, stringIdOrIndex.index) ? 1 : 0);
      }
      return num != 0;
    }

    [LineNumberTable(new byte[] {173, 185, 103, 101, 53})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool isVisible([In] Context obj0, [In] object obj1)
    {
      ClassShutter classShutter = obj0.getClassShutter();
      return classShutter == null || classShutter.visibleToScripts(Object.instancehelper_getClass(obj1).getName());
    }

    [LineNumberTable(3895)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static string getMessage(string messageId, object[] arguments) => ScriptRuntime.__\u003C\u003EmessageProvider.getMessage(messageId, arguments);

    [LineNumberTable(3964)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static EcmaError typeError(string message) => ScriptRuntime.constructError("TypeError", message);

    [LineNumberTable(4065)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static RegExpProxy getRegExpProxy(Context cx) => cx.getRegExpProxy();

    [LineNumberTable(new byte[] {159, 162, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal ScriptRuntime()
    {
    }

    [Obsolete]
    [LineNumberTable(31)]
    [Deprecated(new object[] {64, "Ljava/lang/Deprecated;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static BaseFunction typeErrorThrower() => ScriptRuntime.typeErrorThrower(Context.getCurrentContext());

    [Signature("(Ljava/lang/Class<*>;)Z")]
    [LineNumberTable(new byte[] {76, 104, 146, 127, 1, 109, 11})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool isRhinoRuntimeType(Class cl) => cl.isPrimitive() ? !object.ReferenceEquals((object) cl, (object) Character.TYPE) : object.ReferenceEquals((object) cl, (object) ScriptRuntime.__\u003C\u003EStringClass) || object.ReferenceEquals((object) cl, (object) ScriptRuntime.__\u003C\u003EBooleanClass) || (ScriptRuntime.__\u003C\u003ENumberClass.isAssignableFrom(cl) || ScriptRuntime.__\u003C\u003EScriptableClass.isAssignableFrom(cl));

    [LineNumberTable(new byte[] {160, 161, 102, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static ScriptableObject getLibraryScopeOrNull(Scriptable scope) => (ScriptableObject) ScriptableObject.getTopScopeValue(scope, ScriptRuntime.LIBRARY_SCOPE_KEY);

    [LineNumberTable(new byte[] {162, 70, 101, 162, 103, 103, 38, 198, 100, 40, 198})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object[] padArguments(object[] args, int count)
    {
      if (count < args.Length)
        return args;
      object[] objArray = new object[count];
      int index;
      for (index = 0; index < args.Length; ++index)
        objArray[index] = args[index];
      for (; index < count; ++index)
        objArray[index] = Undefined.__\u003C\u003Einstance;
      return objArray;
    }

    [LineNumberTable(new byte[] {164, 48, 103, 104, 199, 122, 99, 127, 2, 112, 194, 127, 26, 109, 130, 98, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object searchDefaultNamespace(Context cx)
    {
      object obj1 = (object) cx.currentActivationCall;
      if ((NativeCall) obj1 == null)
        obj1 = (object) ScriptRuntime.getTopCallScope(cx);
      object property;
      while (true)
      {
        object obj2 = obj1;
        Scriptable scriptable1;
        if (obj2 != null)
        {
          if (obj2 is Scriptable scriptable18)
            scriptable1 = scriptable18;
          else
            break;
        }
        else
          scriptable1 = (Scriptable) null;
        Scriptable parentScope = scriptable1.getParentScope();
        if (parentScope != null)
        {
          object obj3 = obj1;
          object obj4 = obj1;
          Scriptable scriptable4;
          if (obj4 != null)
          {
            if (obj4 is Scriptable scriptable19)
              scriptable4 = scriptable19;
            else
              goto label_15;
          }
          else
            scriptable4 = (Scriptable) null;
          Scriptable scriptable7 = scriptable4;
          string str1 = "__default_namespace__";
          Scriptable scriptable8;
          if (obj3 != null)
          {
            if (obj3 is Scriptable scriptable20)
              scriptable8 = scriptable20;
            else
              goto label_19;
          }
          else
            scriptable8 = (Scriptable) null;
          string str2 = str1;
          Scriptable s = scriptable7;
          property = scriptable8.get(str2, s);
          if (object.ReferenceEquals(property, Scriptable.NOT_FOUND))
            obj1 = (object) parentScope;
          else
            goto label_23;
        }
        else
          goto label_7;
      }
      throw new IncompatibleClassChangeError();
label_7:
      object obj5 = obj1;
      string str = "__default_namespace__";
      Scriptable scriptable21;
      if (obj5 != null)
        scriptable21 = obj5 is Scriptable scriptable23 ? scriptable23 : throw new IncompatibleClassChangeError();
      else
        scriptable21 = (Scriptable) null;
      string name = str;
      property = ScriptableObject.getProperty(scriptable21, name);
      if (object.ReferenceEquals(property, Scriptable.NOT_FOUND))
        return (object) null;
      goto label_23;
label_15:
      throw new IncompatibleClassChangeError();
label_19:
      throw new IncompatibleClassChangeError();
label_23:
      return property;
    }

    [LineNumberTable(new byte[] {164, 72, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object getTopLevelProp(Scriptable scope, string id)
    {
      scope = ScriptableObject.getTopLevelScope(scope);
      return ScriptableObject.getProperty(scope, id);
    }

    [LineNumberTable(new byte[] {164, 150, 131, 103, 111, 104, 101, 131, 139, 108, 99, 102, 107, 105, 131, 233, 59, 230, 72, 104, 194})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static long testUint32String(string str)
    {
      int num1 = String.instancehelper_length(str);
      if (1 <= num1 && num1 <= 10)
      {
        int num2 = (int) String.instancehelper_charAt(str, 0) - 48;
        if (num2 == 0)
          return num1 == 1 ? 0L : -1L;
        if (1 <= num2 && num2 <= 9)
        {
          long num3 = (long) num2;
          for (int index = 1; index != num1; ++index)
          {
            int num4 = (int) String.instancehelper_charAt(str, index) - 48;
            if (0 > num4 || num4 > 9)
              return -1;
            num3 = 10L * num3 + (long) num4;
          }
          if ((ulong) num3 >> 32 == 0UL)
            return num3;
        }
      }
      return -1;
    }

    [Obsolete]
    [LineNumberTable(1394)]
    [Deprecated(new object[] {64, "Ljava/lang/Deprecated;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object getObjectElem(object obj, object elem, Context cx) => ScriptRuntime.getObjectElem(obj, elem, cx, ScriptRuntime.getTopCallScope(cx));

    [Obsolete]
    [LineNumberTable(1439)]
    [Deprecated(new object[] {64, "Ljava/lang/Deprecated;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object getObjectProp(object obj, string property, Context cx) => ScriptRuntime.getObjectProp(obj, property, cx, ScriptRuntime.getTopCallScope(cx));

    [Obsolete]
    [LineNumberTable(1476)]
    [Deprecated(new object[] {64, "Ljava/lang/Deprecated;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object getObjectPropNoWarn(object obj, string property, Context cx) => ScriptRuntime.getObjectPropNoWarn(obj, property, cx, ScriptRuntime.getTopCallScope(cx));

    [Obsolete]
    [LineNumberTable(1500)]
    [Deprecated(new object[] {64, "Ljava/lang/Deprecated;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object getObjectIndex(object obj, double dblIndex, Context cx) => ScriptRuntime.getObjectIndex(obj, dblIndex, cx, ScriptRuntime.getTopCallScope(cx));

    [Obsolete]
    [LineNumberTable(1539)]
    [Deprecated(new object[] {64, "Ljava/lang/Deprecated;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object setObjectElem(object obj, object elem, object value, Context cx) => ScriptRuntime.setObjectElem(obj, elem, value, cx, ScriptRuntime.getTopCallScope(cx));

    [Obsolete]
    [LineNumberTable(1577)]
    [Deprecated(new object[] {64, "Ljava/lang/Deprecated;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object setObjectProp(object obj, string property, object value, Context cx) => ScriptRuntime.setObjectProp(obj, property, value, cx, ScriptRuntime.getTopCallScope(cx));

    [Obsolete]
    [LineNumberTable(1614)]
    [Deprecated(new object[] {64, "Ljava/lang/Deprecated;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object setObjectIndex(object obj, double dblIndex, object value, Context cx) => ScriptRuntime.setObjectIndex(obj, dblIndex, value, cx, ScriptRuntime.getTopCallScope(cx));

    [Obsolete]
    [LineNumberTable(1687)]
    [Deprecated(new object[] {64, "Ljava/lang/Deprecated;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object refSet(Ref @ref, object value, Context cx) => ScriptRuntime.refSet(@ref, value, cx, ScriptRuntime.getTopCallScope(cx));

    [Obsolete]
    [LineNumberTable(1709)]
    [Deprecated(new object[] {64, "Ljava/lang/Deprecated;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Ref specialRef(object obj, string specialProperty, Context cx) => ScriptRuntime.specialRef(obj, specialProperty, cx, ScriptRuntime.getTopCallScope(cx));

    [Obsolete]
    [LineNumberTable(1722)]
    [Deprecated(new object[] {64, "Ljava/lang/Deprecated;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object delete(object obj, object id, Context cx) => ScriptRuntime.delete(obj, id, cx, false);

    [Obsolete]
    [LineNumberTable(2009)]
    [Deprecated(new object[] {64, "Ljava/lang/Deprecated;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object enumInit(object value, Context cx, bool enumValues)
    {
      int num = enumValues ? 1 : 0;
      return ScriptRuntime.enumInit(value, cx, num == 0 ? 0 : 1);
    }

    [Obsolete]
    [LineNumberTable(2261)]
    [Deprecated(new object[] {64, "Ljava/lang/Deprecated;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Callable getElemFunctionAndThis(object obj, object elem, Context cx) => ScriptRuntime.getElemFunctionAndThis(obj, elem, cx, ScriptRuntime.getTopCallScope(cx));

    [Obsolete]
    [LineNumberTable(2319)]
    [Deprecated(new object[] {64, "Ljava/lang/Deprecated;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Callable getPropFunctionAndThis(object obj, string property, Context cx) => ScriptRuntime.getPropFunctionAndThis(obj, property, cx, ScriptRuntime.getTopCallScope(cx));

    [LineNumberTable(2705)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static CharSequence add(CharSequence val1, object val2)
    {
      object obj1 = (object) val1.__\u003Cref\u003E;
      object obj2 = (object) ScriptRuntime.toCharSequence(val2).__\u003Cref\u003E;
      object obj3 = obj1;
      CharSequence charSequence1;
      charSequence1.__\u003Cref\u003E = (__Null) obj3;
      CharSequence str1 = charSequence1;
      object obj4 = obj2;
      charSequence1.__\u003Cref\u003E = (__Null) obj4;
      CharSequence str2 = charSequence1;
      object obj5 = (object) new ConsString(str1, str2);
      CharSequence charSequence2;
      charSequence2.__\u003Cref\u003E = (__Null) obj5;
      return charSequence2;
    }

    [LineNumberTable(2709)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static CharSequence add(object val1, CharSequence val2)
    {
      object obj1 = (object) val2.__\u003Cref\u003E;
      // ISSUE: variable of the null type
      __Null local = ScriptRuntime.toCharSequence(val1).__\u003Cref\u003E;
      object obj2 = obj1;
      object obj3 = (object) local;
      CharSequence charSequence1;
      charSequence1.__\u003Cref\u003E = (__Null) obj3;
      CharSequence str1 = charSequence1;
      object obj4 = obj2;
      charSequence1.__\u003Cref\u003E = (__Null) obj4;
      CharSequence str2 = charSequence1;
      object obj5 = (object) new ConsString(str1, str2);
      CharSequence charSequence2;
      charSequence2.__\u003Cref\u003E = (__Null) obj5;
      return charSequence2;
    }

    [Obsolete]
    [LineNumberTable(2719)]
    [Deprecated(new object[] {64, "Ljava/lang/Deprecated;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object nameIncrDecr(Scriptable scopeChain, string id, int incrDecrMask) => ScriptRuntime.nameIncrDecr(scopeChain, id, Context.getContext(), incrDecrMask);

    [Obsolete]
    [LineNumberTable(2837)]
    [Deprecated(new object[] {64, "Ljava/lang/Deprecated;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object elemIncrDecr(object obj, object index, Context cx, int incrDecrMask) => ScriptRuntime.elemIncrDecr(obj, index, cx, ScriptRuntime.getTopCallScope(cx), incrDecrMask);

    [Obsolete]
    [LineNumberTable(2873)]
    [Deprecated(new object[] {64, "Ljava/lang/Deprecated;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object refIncrDecr(Ref @ref, Context cx, int incrDecrMask) => ScriptRuntime.refIncrDecr(@ref, cx, ScriptRuntime.getTopCallScope(cx), incrDecrMask);

    [Obsolete]
    [LineNumberTable(3286)]
    [Deprecated(new object[] {64, "Ljava/lang/Deprecated;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object doTopCall(
      Callable callable,
      Context cx,
      Scriptable scope,
      Scriptable thisObj,
      object[] args)
    {
      return ScriptRuntime.doTopCall(callable, cx, scope, thisObj, args, cx.isTopLevelStrict);
    }

    [LineNumberTable(new byte[] {172, 157, 110, 110, 108, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void addInstructionCount(Context cx, int instructionsToAdd)
    {
      cx.instructionCount += instructionsToAdd;
      if (cx.instructionCount <= cx.instructionThreshold)
        return;
      cx.observeInstructionCount(cx.instructionCount);
      cx.instructionCount = 0;
    }

    [Obsolete]
    [LineNumberTable(3397)]
    [Deprecated(new object[] {64, "Ljava/lang/Deprecated;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Scriptable createFunctionActivation(
      NativeFunction funObj,
      Scriptable scope,
      object[] args)
    {
      return ScriptRuntime.createFunctionActivation(funObj, scope, args, false);
    }

    [Obsolete]
    [LineNumberTable(3780)]
    [Deprecated(new object[] {64, "Ljava/lang/Deprecated;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Scriptable newObjectLiteral(
      object[] propertyIds,
      object[] propertyValues,
      Context cx,
      Scriptable scope)
    {
      return ScriptRuntime.newObjectLiteral(propertyIds, propertyValues, (int[]) null, cx, scope);
    }

    [LineNumberTable(3815)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool isArrayObject(object obj)
    {
      switch (obj)
      {
        case NativeArray _:
        case Arguments _:
          return true;
        default:
          return false;
      }
    }

    [LineNumberTable(new byte[] {174, 243, 103, 103, 101, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static EcmaError constructError(
      string error,
      string message,
      int lineNumberDelta)
    {
      int[] numArray1 = new int[1];
      string positionFromStack = Context.getSourcePositionFromStack(numArray1);
      if (numArray1[0] != 0)
      {
        int[] numArray2 = numArray1;
        int index = 0;
        int[] numArray3 = numArray2;
        numArray3[index] = numArray3[index] + lineNumberDelta;
      }
      return ScriptRuntime.constructError(error, message, positionFromStack, numArray1[0], (string) null, 0);
    }

    [LineNumberTable(4051)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static RuntimeException notXmlError([In] object obj0) => throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.typeError1("msg.isnt.xml.object", (object) ScriptRuntime.toString(obj0)));

    [LineNumberTable(new byte[] {175, 115, 110, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void setRegExpProxy(Context cx, RegExpProxy proxy)
    {
      if (proxy == null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException();
      }
      cx.regExpProxy = proxy;
    }

    [LineNumberTable(new byte[] {175, 133, 104, 107, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void storeUint32Result(Context cx, long value)
    {
      if ((ulong) value >> 32 != 0UL)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException();
      }
      cx.scratchUint32 = value;
    }

    [LineNumberTable(new byte[] {175, 139, 103, 104, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static long lastUint32Result(Context cx)
    {
      long scratchUint32 = cx.scratchUint32;
      if ((ulong) scratchUint32 >> 32 != 0UL)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalStateException();
      }
      return scratchUint32;
    }

    [LineNumberTable(new byte[] {175, 195, 107, 103, 122, 38, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static JavaScriptException throwError(
      Context cx,
      Scriptable scope,
      string message)
    {
      int[] numArray = new int[1]{ 0 };
      string positionFromStack = Context.getSourcePositionFromStack(numArray);
      Scriptable scriptable = ScriptRuntime.newBuiltinObject(cx, scope, TopLevel.Builtins.__\u003C\u003EError, new object[3]
      {
        (object) message,
        (object) positionFromStack,
        (object) Integer.valueOf(numArray[0])
      });
      JavaScriptException.__\u003Cclinit\u003E();
      return new JavaScriptException((object) scriptable, positionFromStack, numArray[0]);
    }

    [LineNumberTable(new byte[] {159, 118, 109, 111, 111, 111, 111, 111, 111, 111, 111, 111, 111, 111, 111, 175, 101, 106, 101, 106, 101, 106, 101, 106, 170, 234, 161, 39, 150, 243, 173, 144, 235, 161, 25, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static ScriptRuntime()
    {
      if (ByteCodeHelper.isAlreadyInited("rhino.ScriptRuntime"))
        return;
      ScriptRuntime.__\u003C\u003EBooleanClass = Kit.classOrNull("java.lang.Boolean");
      ScriptRuntime.__\u003C\u003EByteClass = Kit.classOrNull("java.lang.Byte");
      ScriptRuntime.__\u003C\u003ECharacterClass = Kit.classOrNull("java.lang.Character");
      ScriptRuntime.__\u003C\u003EClassClass = Kit.classOrNull("java.lang.Class");
      ScriptRuntime.__\u003C\u003EDoubleClass = Kit.classOrNull("java.lang.Double");
      ScriptRuntime.__\u003C\u003EFloatClass = Kit.classOrNull("java.lang.Float");
      ScriptRuntime.__\u003C\u003EIntegerClass = Kit.classOrNull("java.lang.Integer");
      ScriptRuntime.__\u003C\u003ELongClass = Kit.classOrNull("java.lang.Long");
      ScriptRuntime.__\u003C\u003ENumberClass = Kit.classOrNull("java.lang.Number");
      ScriptRuntime.__\u003C\u003EObjectClass = Kit.classOrNull("java.lang.Object");
      ScriptRuntime.__\u003C\u003EShortClass = Kit.classOrNull("java.lang.Short");
      ScriptRuntime.__\u003C\u003EStringClass = Kit.classOrNull("java.lang.String");
      ScriptRuntime.__\u003C\u003EDateClass = Kit.classOrNull("java.util.Date");
      ScriptRuntime.__\u003C\u003EContextClass = Kit.classOrNull("rhino.Context");
      ScriptRuntime.__\u003C\u003EContextFactoryClass = Kit.classOrNull("rhino.ContextFactory");
      ScriptRuntime.__\u003C\u003EFunctionClass = Kit.classOrNull("rhino.Function");
      ScriptRuntime.__\u003C\u003EScriptableObjectClass = Kit.classOrNull("rhino.ScriptableObject");
      ScriptRuntime.__\u003C\u003EScriptableClass = (Class) ClassLiteral<Scriptable>.Value;
      ScriptRuntime.LIBRARY_SCOPE_KEY = (object) "LIBRARY_SCOPE";
      DoubleConverter doubleConverter;
      ScriptRuntime.__\u003C\u003EnegativeZero = DoubleConverter.ToDouble(long.MinValue, ref doubleConverter);
      ScriptRuntime.__\u003C\u003ENaNobj = Double.valueOf(double.NaN);
      ScriptRuntime.__\u003C\u003EmessageProvider = (ScriptRuntime.MessageProvider) new ScriptRuntime.DefaultMessageProvider((ScriptRuntime.\u0031) null);
      ScriptRuntime.__\u003C\u003EemptyArgs = new object[0];
      ScriptRuntime.__\u003C\u003EemptyStrings = new string[0];
    }

    static CallerID __\u003CGetCallerID\u003E()
    {
      if (ScriptRuntime.__\u003CcallerID\u003E == null)
        ScriptRuntime.__\u003CcallerID\u003E = (CallerID) new ScriptRuntime.__\u003CCallerID\u003E();
      return ScriptRuntime.__\u003CcallerID\u003E;
    }

    [Modifiers]
    public static Class BooleanClass
    {
      [HideFromJava] get => ScriptRuntime.__\u003C\u003EBooleanClass;
    }

    [Modifiers]
    public static Class ByteClass
    {
      [HideFromJava] get => ScriptRuntime.__\u003C\u003EByteClass;
    }

    [Modifiers]
    public static Class CharacterClass
    {
      [HideFromJava] get => ScriptRuntime.__\u003C\u003ECharacterClass;
    }

    [Modifiers]
    public static Class ClassClass
    {
      [HideFromJava] get => ScriptRuntime.__\u003C\u003EClassClass;
    }

    [Modifiers]
    public static Class DoubleClass
    {
      [HideFromJava] get => ScriptRuntime.__\u003C\u003EDoubleClass;
    }

    [Modifiers]
    public static Class FloatClass
    {
      [HideFromJava] get => ScriptRuntime.__\u003C\u003EFloatClass;
    }

    [Modifiers]
    public static Class IntegerClass
    {
      [HideFromJava] get => ScriptRuntime.__\u003C\u003EIntegerClass;
    }

    [Modifiers]
    public static Class LongClass
    {
      [HideFromJava] get => ScriptRuntime.__\u003C\u003ELongClass;
    }

    [Modifiers]
    public static Class NumberClass
    {
      [HideFromJava] get => ScriptRuntime.__\u003C\u003ENumberClass;
    }

    [Modifiers]
    public static Class ObjectClass
    {
      [HideFromJava] get => ScriptRuntime.__\u003C\u003EObjectClass;
    }

    [Modifiers]
    public static Class ShortClass
    {
      [HideFromJava] get => ScriptRuntime.__\u003C\u003EShortClass;
    }

    [Modifiers]
    public static Class StringClass
    {
      [HideFromJava] get => ScriptRuntime.__\u003C\u003EStringClass;
    }

    [Modifiers]
    public static Class DateClass
    {
      [HideFromJava] get => ScriptRuntime.__\u003C\u003EDateClass;
    }

    [Modifiers]
    public static Class ContextClass
    {
      [HideFromJava] get => ScriptRuntime.__\u003C\u003EContextClass;
    }

    [Modifiers]
    public static Class ContextFactoryClass
    {
      [HideFromJava] get => ScriptRuntime.__\u003C\u003EContextFactoryClass;
    }

    [Modifiers]
    public static Class FunctionClass
    {
      [HideFromJava] get => ScriptRuntime.__\u003C\u003EFunctionClass;
    }

    [Modifiers]
    public static Class ScriptableObjectClass
    {
      [HideFromJava] get => ScriptRuntime.__\u003C\u003EScriptableObjectClass;
    }

    [Modifiers]
    public static Class ScriptableClass
    {
      [HideFromJava] get => ScriptRuntime.__\u003C\u003EScriptableClass;
    }

    [Modifiers]
    public static double negativeZero
    {
      [HideFromJava] get => ScriptRuntime.__\u003C\u003EnegativeZero;
    }

    [Modifiers]
    public static Double NaNobj
    {
      [HideFromJava] get => ScriptRuntime.__\u003C\u003ENaNobj;
    }

    [Modifiers]
    public static ScriptRuntime.MessageProvider messageProvider
    {
      [HideFromJava] get => ScriptRuntime.__\u003C\u003EmessageProvider;
    }

    [Modifiers]
    public static object[] emptyArgs
    {
      [HideFromJava] get => ScriptRuntime.__\u003C\u003EemptyArgs;
    }

    [Modifiers]
    public static string[] emptyStrings
    {
      [HideFromJava] get => ScriptRuntime.__\u003C\u003EemptyStrings;
    }

    [EnclosingMethod(null, "typeErrorThrower", "(Lrhino.Context;)Lrhino.BaseFunction;")]
    [SpecialName]
    internal sealed class \u0031 : BaseFunction
    {
      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(40)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0031()
      {
      }

      [LineNumberTable(43)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override object call([In] Context obj0, [In] Scriptable obj1, [In] Scriptable obj2, [In] object[] obj3) => throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.typeError0("msg.op.not.allowed"));

      [MethodImpl(MethodImplOptions.NoInlining)]
      public override int getLength() => 0;

      [HideFromJava]
      static \u0031() => BaseFunction.__\u003Cclinit\u003E();
    }

    [InnerClass]
    internal class DefaultMessageProvider : Object, ScriptRuntime.MessageProvider
    {
      [SpecialName]
      private static CallerID __\u003CcallerID\u003E;

      [Modifiers]
      [LineNumberTable(3902)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal DefaultMessageProvider([In] ScriptRuntime.\u0031 obj0)
        : this()
      {
      }

      [LineNumberTable(3902)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private DefaultMessageProvider()
      {
      }

      [LineNumberTable(new byte[] {174, 207, 166, 102, 177, 209, 211, 226, 61, 97, 255, 6, 73, 104})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual string getMessage([In] string obj0, [In] object[] obj1)
      {
        Context currentContext = Context.getCurrentContext();
        ResourceBundle bundle = ResourceBundle.getBundle("rhino.resources.Messages", currentContext == null ? Locale.getDefault() : currentContext.getLocale(), ScriptRuntime.DefaultMessageProvider.__\u003CGetCallerID\u003E());
        string str1;
        try
        {
          str1 = bundle.getString(obj0);
          goto label_4;
        }
        catch (MissingResourceException ex)
        {
        }
        string str2 = new StringBuilder().append("no message resource found for message property ").append(obj0).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new RuntimeException(str2);
label_4:
        return ((Format) new MessageFormat(str1)).format((object) obj1);
      }

      static CallerID __\u003CGetCallerID\u003E()
      {
        if (ScriptRuntime.DefaultMessageProvider.__\u003CcallerID\u003E == null)
          ScriptRuntime.DefaultMessageProvider.__\u003CcallerID\u003E = (CallerID) new ScriptRuntime.DefaultMessageProvider.__\u003CCallerID\u003E();
        return ScriptRuntime.DefaultMessageProvider.__\u003CcallerID\u003E;
      }

      private sealed class __\u003CCallerID\u003E : CallerID
      {
        internal __\u003CCallerID\u003E()
        {
        }
      }
    }

    [InnerClass]
    internal class IdEnumeration : Object
    {
      internal Scriptable obj;
      internal object[] ids;
      internal ObjToIntMap used;
      internal object currentId;
      internal int index;
      internal int enumType;
      internal bool enumNumbers;
      internal Scriptable iterator;

      [Modifiers]
      [LineNumberTable(1967)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal IdEnumeration([In] ScriptRuntime.\u0031 obj0)
        : this()
      {
      }

      [LineNumberTable(1967)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private IdEnumeration()
      {
      }
    }

    public interface MessageProvider
    {
      string getMessage(string str, object[] objarr);
    }

    internal class NoSuchMethodShim : Object, Callable
    {
      internal string methodName;
      internal Callable noSuchMethodMethod;

      [LineNumberTable(new byte[] {12, 104, 103, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal NoSuchMethodShim([In] Callable obj0, [In] string obj1)
      {
        ScriptRuntime.NoSuchMethodShim noSuchMethodShim = this;
        this.noSuchMethodMethod = obj0;
        this.methodName = obj1;
      }

      [LineNumberTable(new byte[] {28, 135, 105, 109})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual object call([In] Context obj0, [In] Scriptable obj1, [In] Scriptable obj2, [In] object[] obj3)
      {
        object[] objarr = new object[2]
        {
          (object) this.methodName,
          (object) ScriptRuntime.newArrayLiteral(obj3, (int[]) null, obj0, obj1)
        };
        return this.noSuchMethodMethod.call(obj0, obj1, obj2, objarr);
      }
    }

    internal sealed class StringIdOrIndex : Object
    {
      [Modifiers]
      internal string stringId;
      [Modifiers]
      internal int index;

      [LineNumberTable(new byte[] {164, 217, 104, 103, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal StringIdOrIndex([In] int obj0)
      {
        ScriptRuntime.StringIdOrIndex stringIdOrIndex = this;
        this.stringId = (string) null;
        this.index = obj0;
      }

      [LineNumberTable(new byte[] {164, 212, 104, 103, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal StringIdOrIndex([In] string obj0)
      {
        ScriptRuntime.StringIdOrIndex stringIdOrIndex = this;
        this.stringId = obj0;
        this.index = -1;
      }
    }

    private sealed class __\u003CCallerID\u003E : CallerID
    {
      internal __\u003CCallerID\u003E()
      {
      }
    }
  }
}
