// Decompiled with JetBrains decompiler
// Type: rhino.optimizer.OptRuntime
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace rhino.optimizer
{
  public sealed class OptRuntime : ScriptRuntime
  {
    internal static Double __\u003C\u003EzeroObj;
    internal static Double __\u003C\u003EoneObj;
    internal static Double __\u003C\u003EminusOneObj;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {96, 99, 130, 99, 107, 100, 102, 100, 103, 105, 232, 60, 230, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static string encodeIntArray([In] int[] obj0)
    {
      if (obj0 == null)
        return (string) null;
      int length = obj0.Length;
      char[] chArray = new char[1 + length * 2];
      chArray[0] = '\u0001';
      for (int index1 = 0; index1 != length; ++index1)
      {
        int num = obj0[index1];
        int index2 = 1 + index1 * 2;
        chArray[index2] = (char) ((uint) num >> 16);
        chArray[index2 + 1] = (char) num;
      }
      return String.newhelper(chArray);
    }

    [LineNumberTable(new byte[] {79, 105, 144, 134, 105, 102, 109, 102, 105, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Double wrapDouble(double num)
    {
      if (num == 0.0)
      {
        if (1.0 / num > 0.0)
          return OptRuntime.__\u003C\u003EzeroObj;
      }
      else
      {
        if (num == 1.0)
          return OptRuntime.__\u003C\u003EoneObj;
        if (num == -1.0)
          return OptRuntime.__\u003C\u003EminusOneObj;
        if (Double.isNaN(num))
          return ScriptRuntime.__\u003C\u003ENaNobj;
      }
      return Double.valueOf(num);
    }

    [LineNumberTable(new byte[] {113, 99, 110, 130, 119, 139, 103, 102, 102, 23, 198})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static int[] decodeIntArray([In] string obj0, [In] int obj1)
    {
      if (obj1 == 0)
      {
        if (obj0 != null)
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalArgumentException();
        }
        return (int[]) null;
      }
      if (String.instancehelper_length(obj0) != 1 + obj1 * 2 && String.instancehelper_charAt(obj0, 0) != '\u0001')
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException();
      }
      int[] numArray = new int[obj1];
      for (int index = 0; index != obj1; ++index)
      {
        int num = 1 + index * 2;
        numArray[index] = (int) String.instancehelper_charAt(obj0, num) << 16 | (int) String.instancehelper_charAt(obj0, num + 1);
      }
      return numArray;
    }

    [LineNumberTable(new byte[] {160, 131, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object getGeneratorReturnValue(object obj)
    {
      OptRuntime.GeneratorState generatorState = (OptRuntime.GeneratorState) obj;
      return generatorState.returnValue == null ? Undefined.__\u003C\u003Einstance : generatorState.returnValue;
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 75, 199, 104, 107, 105, 141, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static object lambda\u0024main\u00240([In] string[] obj0, [In] Script obj1, [In] Context obj2)
    {
      ScriptableObject global = ScriptRuntime.getGlobal(obj2);
      object[] elements = new object[obj0.Length];
      java.lang.System.arraycopy((object) obj0, 0, (object) elements, 0, obj0.Length);
      Scriptable scriptable = obj2.newArray((Scriptable) global, elements);
      global.defineProperty("arguments", (object) scriptable, 2);
      obj1.exec(obj2, (Scriptable) global);
      return (object) null;
    }

    [LineNumberTable(5)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public OptRuntime()
    {
    }

    [LineNumberTable(15)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object call0(Callable fun, Scriptable thisObj, Context cx, Scriptable scope) => fun.call(cx, scope, thisObj, ScriptRuntime.__\u003C\u003EemptyArgs);

    [LineNumberTable(23)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object call1(
      Callable fun,
      Scriptable thisObj,
      object arg0,
      Context cx,
      Scriptable scope)
    {
      return fun.call(cx, scope, thisObj, new object[1]
      {
        arg0
      });
    }

    [LineNumberTable(32)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object call2(
      Callable fun,
      Scriptable thisObj,
      object arg0,
      object arg1,
      Context cx,
      Scriptable scope)
    {
      return fun.call(cx, scope, thisObj, new object[2]
      {
        arg0,
        arg1
      });
    }

    [LineNumberTable(41)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object callN(
      Callable fun,
      Scriptable thisObj,
      object[] args,
      Context cx,
      Scriptable scope)
    {
      return fun.call(cx, scope, thisObj, args);
    }

    [LineNumberTable(new byte[] {159, 191, 105, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object callName(object[] args, string name, Context cx, Scriptable scope)
    {
      Callable nameFunctionAndThis = ScriptRuntime.getNameFunctionAndThis(name, cx, scope);
      Scriptable s2 = ScriptRuntime.lastStoredScriptable(cx);
      return nameFunctionAndThis.call(cx, scope, s2, args);
    }

    [LineNumberTable(new byte[] {9, 105, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object callName0(string name, Context cx, Scriptable scope)
    {
      Callable nameFunctionAndThis = ScriptRuntime.getNameFunctionAndThis(name, cx, scope);
      Scriptable s2 = ScriptRuntime.lastStoredScriptable(cx);
      return nameFunctionAndThis.call(cx, scope, s2, ScriptRuntime.__\u003C\u003EemptyArgs);
    }

    [LineNumberTable(new byte[] {19, 106, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object callProp0(object value, string property, Context cx, Scriptable scope)
    {
      Callable propFunctionAndThis = ScriptRuntime.getPropFunctionAndThis(value, property, cx, scope);
      Scriptable s2 = ScriptRuntime.lastStoredScriptable(cx);
      return propFunctionAndThis.call(cx, scope, s2, ScriptRuntime.__\u003C\u003EemptyArgs);
    }

    [LineNumberTable(new byte[] {25, 104, 110, 104, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object add(object val1, double val2)
    {
      if (val1 is Scriptable)
        val1 = ((Scriptable) val1).getDefaultValue((Class) null);
      if (!CharSequence.IsInstance(val1))
        return (object) OptRuntime.wrapDouble(ScriptRuntime.toNumber(val1) + val2);
      object obj1 = val1;
      CharSequence.Cast(obj1);
      object obj2 = (object) ScriptRuntime.toString(val2);
      object obj3 = obj1;
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj3;
      CharSequence str1 = charSequence;
      object obj4 = obj2;
      charSequence.__\u003Cref\u003E = (__Null) obj4;
      CharSequence str2 = charSequence;
      return (object) new ConsString(str1, str2);
    }

    [LineNumberTable(new byte[] {33, 104, 110, 104, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object add(double val1, object val2)
    {
      if (val2 is Scriptable)
        val2 = ((Scriptable) val2).getDefaultValue((Class) null);
      if (!CharSequence.IsInstance(val2))
        return (object) OptRuntime.wrapDouble(ScriptRuntime.toNumber(val2) + val1);
      string str = ScriptRuntime.toString(val1);
      object obj1 = val2;
      CharSequence.Cast(obj1);
      object obj2 = obj1;
      object obj3 = (object) str;
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj3;
      CharSequence str1 = charSequence;
      object obj4 = obj2;
      charSequence.__\u003Cref\u003E = (__Null) obj4;
      CharSequence str2 = charSequence;
      return (object) new ConsString(str1, str2);
    }

    [LineNumberTable(93)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object elemIncrDecr(
      object obj,
      double index,
      Context cx,
      Scriptable scope,
      int incrDecrMask)
    {
      return ScriptRuntime.elemIncrDecr(obj, (object) Double.valueOf(index), cx, scope, incrDecrMask);
    }

    [LineNumberTable(new byte[] {48, 106, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object[] padStart(object[] currentArgs, int count)
    {
      object[] objArray = new object[currentArgs.Length + count];
      ByteCodeHelper.arraycopy((object) currentArgs, 0, (object) objArray, count, currentArgs.Length);
      return objArray;
    }

    [LineNumberTable(new byte[] {55, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void initFunction(
      NativeFunction fn,
      int functionType,
      Scriptable scope,
      Context cx)
    {
      ScriptRuntime.initFunction(cx, scope, fn, functionType, false);
    }

    [LineNumberTable(109)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Function bindThis(
      NativeFunction fn,
      Context cx,
      Scriptable scope,
      Scriptable thisObj)
    {
      return (Function) new ArrowFunction(cx, scope, (Callable) fn, thisObj);
    }

    [LineNumberTable(117)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static object callSpecial(
      Context cx,
      Callable fun,
      Scriptable thisObj,
      object[] args,
      Scriptable scope,
      Scriptable callerThis,
      int callType,
      string fileName,
      int lineNumber)
    {
      return ScriptRuntime.callSpecial(cx, fun, thisObj, args, scope, callerThis, callType, fileName, lineNumber);
    }

    [LineNumberTable(125)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object newObjectSpecial(
      Context cx,
      object fun,
      object[] args,
      Scriptable scope,
      Scriptable callerThis,
      int callType)
    {
      return ScriptRuntime.newSpecial(cx, fun, args, scope, callType);
    }

    [LineNumberTable(new byte[] {160, 69, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Scriptable newArrayLiteral(
      object[] objects,
      string encodedInts,
      int skipCount,
      Context cx,
      Scriptable scope)
    {
      int[] skipIndices = OptRuntime.decodeIntArray(encodedInts, skipCount);
      return ScriptRuntime.newArrayLiteral(objects, skipIndices, cx, scope);
    }

    [LineNumberTable(new byte[] {160, 74, 247, 77})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void main(Script script, string[] args) => ContextFactory.getGlobal().call((ContextAction) new OptRuntime.__\u003C\u003EAnon0(args, script));

    [LineNumberTable(new byte[] {160, 90, 103, 147, 142})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void throwStopIteration(object scope, object genState)
    {
      object generatorReturnValue = OptRuntime.getGeneratorReturnValue(genState);
      object obj = !object.ReferenceEquals(generatorReturnValue, Undefined.__\u003C\u003Einstance) ? (object) new NativeIterator.StopIteration(generatorReturnValue) : (object) (NativeIterator.StopIteration) NativeIterator.getStopIterationObject((Scriptable) scope);
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new JavaScriptException(obj, "", 0);
    }

    [LineNumberTable(new byte[] {160, 103, 106, 113, 137})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Scriptable createNativeGenerator(
      NativeFunction funObj,
      Scriptable scope,
      Scriptable thisObj,
      int maxLocals,
      int maxStack)
    {
      OptRuntime.GeneratorState generatorState = new OptRuntime.GeneratorState(thisObj, maxLocals, maxStack);
      return Context.getCurrentContext().getLanguageVersion() >= 200 ? (Scriptable) new ES6Generator(scope, funObj, (object) generatorState) : (Scriptable) new NativeGenerator(scope, funObj, (object) generatorState);
    }

    [LineNumberTable(new byte[] {160, 112, 103, 104, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object[] getGeneratorStackState(object obj)
    {
      OptRuntime.GeneratorState generatorState = (OptRuntime.GeneratorState) obj;
      if (generatorState.stackState == null)
        generatorState.stackState = new object[generatorState.maxStack];
      return generatorState.stackState;
    }

    [LineNumberTable(new byte[] {160, 119, 103, 104, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object[] getGeneratorLocalsState(object obj)
    {
      OptRuntime.GeneratorState generatorState = (OptRuntime.GeneratorState) obj;
      if (generatorState.localsState == null)
        generatorState.localsState = new object[generatorState.maxLocals];
      return generatorState.localsState;
    }

    [LineNumberTable(new byte[] {160, 126, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void setGeneratorReturnValue(object obj, object val) => ((OptRuntime.GeneratorState) obj).returnValue = val;

    [LineNumberTable(new byte[] {159, 141, 146, 111, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static OptRuntime()
    {
      ScriptRuntime.__\u003Cclinit\u003E();
      if (ByteCodeHelper.isAlreadyInited("rhino.optimizer.OptRuntime"))
        return;
      OptRuntime.__\u003C\u003EzeroObj = Double.valueOf(0.0);
      OptRuntime.__\u003C\u003EoneObj = Double.valueOf(1.0);
      OptRuntime.__\u003C\u003EminusOneObj = Double.valueOf(-1.0);
    }

    [Modifiers]
    public static Double zeroObj
    {
      [HideFromJava] get => OptRuntime.__\u003C\u003EzeroObj;
    }

    [Modifiers]
    public static Double oneObj
    {
      [HideFromJava] get => OptRuntime.__\u003C\u003EoneObj;
    }

    [Modifiers]
    public static Double minusOneObj
    {
      [HideFromJava] get => OptRuntime.__\u003C\u003EminusOneObj;
    }

    public class GeneratorState : Object
    {
      internal const string CLASS_NAME = "rhino/optimizer/OptRuntime$GeneratorState";
      public int resumptionPoint;
      internal const string resumptionPoint_NAME = "resumptionPoint";
      internal const string resumptionPoint_TYPE = "I";
      public Scriptable thisObj;
      internal const string thisObj_NAME = "thisObj";
      internal const string thisObj_TYPE = "Lrhino/Scriptable;";
      internal object[] stackState;
      internal object[] localsState;
      internal int maxLocals;
      internal int maxStack;
      internal object returnValue;

      [LineNumberTable(new byte[] {160, 154, 104, 103, 103, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal GeneratorState([In] Scriptable obj0, [In] int obj1, [In] int obj2)
      {
        OptRuntime.GeneratorState generatorState = this;
        this.thisObj = obj0;
        this.maxLocals = obj1;
        this.maxStack = obj2;
      }
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : ContextAction
    {
      private readonly string[] arg\u00241;
      private readonly Script arg\u00242;

      internal __\u003C\u003EAnon0([In] string[] obj0, [In] Script obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public object run([In] Context obj0) => OptRuntime.lambda\u0024main\u00240(this.arg\u00241, this.arg\u00242, obj0);
    }
  }
}
