// Decompiled with JetBrains decompiler
// Type: rhino.NativeError
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.lang.reflect;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace rhino
{
  internal sealed class NativeError : IdScriptableObject
  {
    [Modifiers]
    private static object ERROR_TAG;
    [Modifiers]
    private static Method ERROR_DELEGATE_GET_STACK;
    [Modifiers]
    private static Method ERROR_DELEGATE_SET_STACK;
    public const int DEFAULT_STACK_LIMIT = -1;
    private const string STACK_HIDE_KEY = "_stackHide";
    private RhinoException stackProvider;
    private const int Id_constructor = 1;
    private const int Id_toString = 2;
    private const int Id_toSource = 3;
    private const int ConstructorId_captureStackTrace = -1;
    private const int MAX_PROTOTYPE_ID = 3;
    [SpecialName]
    private static CallerID __\u003CcallerID\u003E;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {106, 104, 103, 215})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setStackProvider([In] RhinoException obj0)
    {
      if (this.stackProvider != null)
        return;
      this.stackProvider = obj0;
      this.defineProperty("stack", (object) this, NativeError.ERROR_DELEGATE_GET_STACK, NativeError.ERROR_DELEGATE_SET_STACK, 2);
    }

    [LineNumberTable(10)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal NativeError()
    {
    }

    [LineNumberTable(new byte[] {160, 106, 108, 122, 136, 135, 108, 122, 136, 135, 109, 98, 109, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static object js_toString([In] Scriptable obj0)
    {
      object property1 = ScriptableObject.getProperty(obj0, "name");
      string str1 = object.ReferenceEquals(property1, Scriptable.NOT_FOUND) || object.ReferenceEquals(property1, Undefined.__\u003C\u003Einstance) ? "Error" : ScriptRuntime.toString(property1);
      object property2 = ScriptableObject.getProperty(obj0, "message");
      string str2 = object.ReferenceEquals(property2, Scriptable.NOT_FOUND) || object.ReferenceEquals(property2, Undefined.__\u003C\u003Einstance) ? "" : ScriptRuntime.toString(property2);
      if (String.instancehelper_length(Object.instancehelper_toString((object) str1)) == 0)
        return (object) str2;
      return String.instancehelper_length(Object.instancehelper_toString((object) str2)) == 0 ? (object) str1 : (object) new StringBuilder().append((object) str1).append(": ").append((object) str2).toString();
    }

    [LineNumberTable(new byte[] {159, 190, 151, 102, 103, 135, 99, 100, 111, 105, 37, 165, 100, 110, 100, 105, 103, 37, 229, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static NativeError make(
      [In] Context obj0,
      [In] Scriptable obj1,
      [In] IdFunctionObject obj2,
      [In] object[] obj3)
    {
      Scriptable m = (Scriptable) obj2.get("prototype", (Scriptable) obj2);
      NativeError nativeError = new NativeError();
      nativeError.setPrototype(m);
      nativeError.setParentScope(obj1);
      int length = obj3.Length;
      if (length >= 1)
      {
        if (!object.ReferenceEquals(obj3[0], Undefined.__\u003C\u003Einstance))
          ScriptableObject.putProperty((Scriptable) nativeError, "message", (object) ScriptRuntime.toString(obj3[0]));
        if (length >= 2)
        {
          ScriptableObject.putProperty((Scriptable) nativeError, "fileName", obj3[1]);
          if (length >= 3)
          {
            int int32 = ScriptRuntime.toInt32(obj3[2]);
            ScriptableObject.putProperty((Scriptable) nativeError, "lineNumber", (object) Integer.valueOf(int32));
          }
        }
      }
      return nativeError;
    }

    [LineNumberTable(new byte[] {160, 130, 108, 108, 108, 140, 103, 109, 109, 134, 110, 109, 191, 11, 109, 134, 112, 125, 109, 109, 134, 112, 109, 104, 100, 109, 240, 69, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static string js_toSource([In] Context obj0, [In] Scriptable obj1, [In] Scriptable obj2)
    {
      object obj = ScriptableObject.getProperty(obj2, "name");
      object objA1 = ScriptableObject.getProperty(obj2, "message");
      object objA2 = ScriptableObject.getProperty(obj2, "fileName");
      object property = ScriptableObject.getProperty(obj2, "lineNumber");
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.append("(new ");
      if (object.ReferenceEquals(obj, Scriptable.NOT_FOUND))
        obj = Undefined.__\u003C\u003Einstance;
      stringBuilder.append(ScriptRuntime.toString(obj));
      stringBuilder.append("(");
      if (!object.ReferenceEquals(objA1, Scriptable.NOT_FOUND) || !object.ReferenceEquals(objA2, Scriptable.NOT_FOUND) || !object.ReferenceEquals(property, Scriptable.NOT_FOUND))
      {
        if (object.ReferenceEquals(objA1, Scriptable.NOT_FOUND))
          objA1 = (object) "";
        stringBuilder.append(ScriptRuntime.uneval(obj0, obj1, objA1));
        if (!object.ReferenceEquals(objA2, Scriptable.NOT_FOUND) || !object.ReferenceEquals(property, Scriptable.NOT_FOUND))
        {
          stringBuilder.append(", ");
          if (object.ReferenceEquals(objA2, Scriptable.NOT_FOUND))
            objA2 = (object) "";
          stringBuilder.append(ScriptRuntime.uneval(obj0, obj1, objA2));
          if (!object.ReferenceEquals(property, Scriptable.NOT_FOUND))
          {
            int int32 = ScriptRuntime.toInt32(property);
            if (int32 != 0)
            {
              stringBuilder.append(", ");
              stringBuilder.append(ScriptRuntime.toString((double) int32));
            }
          }
        }
      }
      stringBuilder.append("))");
      return stringBuilder.toString();
    }

    [LineNumberTable(new byte[] {160, 169, 112, 98, 101, 208, 146, 176, 99, 109, 112, 242, 71, 151})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void js_captureStackTrace([In] Context obj0, [In] Scriptable obj1, [In] object[] obj2)
    {
      ScriptableObject objectOrNull = (ScriptableObject) ScriptRuntime.toObjectOrNull(obj0, obj2[0], obj1);
      Function function = (Function) null;
      if (obj2.Length > 1)
        function = (Function) ScriptRuntime.toObjectOrNull(obj0, obj2[1], obj1);
      NativeError nativeError = (NativeError) obj0.newObject(obj1, "Error");
      nativeError.setStackProvider((RhinoException) new EvaluatorException("[object Object]"));
      if (function != null)
      {
        object obj = function.get("name", (Scriptable) function);
        if (obj != null && !Object.instancehelper_equals(Undefined.__\u003C\u003Einstance, obj))
          nativeError.associateValue((object) "_stackHide", (object) Context.toString(obj));
      }
      objectOrNull.defineProperty("stack", (object) nativeError, NativeError.ERROR_DELEGATE_GET_STACK, NativeError.ERROR_DELEGATE_SET_STACK, 0);
    }

    [LineNumberTable(new byte[] {160, 91, 102, 168, 103, 114, 105, 228, 61, 230, 70, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private object callPrepareStack([In] Function obj0, [In] ScriptStackElement[] obj1)
    {
      Context currentContext = Context.getCurrentContext();
      object[] elements = new object[obj1.Length];
      for (int index = 0; index < obj1.Length; ++index)
      {
        NativeCallSite nativeCallSite = (NativeCallSite) currentContext.newObject((Scriptable) this, "CallSite");
        nativeCallSite.setElement(obj1[index]);
        elements[index] = (object) nativeCallSite;
      }
      Scriptable scriptable = currentContext.newArray((Scriptable) this, elements);
      return obj0.call(currentContext, (Scriptable) obj0, (Scriptable) this, new object[2]
      {
        (object) this,
        (object) scriptable
      });
    }

    [LineNumberTable(new byte[] {160, 85, 107, 103, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setStackDelegated([In] Scriptable obj0, [In] object obj1)
    {
      obj0.delete("stack");
      this.stackProvider = (RhinoException) null;
      obj0.put("stack", obj0, obj1);
    }

    [LineNumberTable(new byte[] {159, 134, 162, 102, 112, 112, 112, 113, 108, 108, 106, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static void init([In] Scriptable obj0, [In] bool obj1)
    {
      int num = obj1 ? 1 : 0;
      NativeError nativeError = new NativeError();
      ScriptableObject.putProperty((Scriptable) nativeError, "name", (object) "Error");
      ScriptableObject.putProperty((Scriptable) nativeError, "message", (object) "");
      ScriptableObject.putProperty((Scriptable) nativeError, "fileName", (object) "");
      ScriptableObject.putProperty((Scriptable) nativeError, "lineNumber", (object) Integer.valueOf(0));
      nativeError.setAttributes("name", 2);
      nativeError.setAttributes("message", 2);
      nativeError.exportAsJSClass(3, obj0, num != 0);
      NativeCallSite.init((Scriptable) nativeError, num != 0);
    }

    [LineNumberTable(new byte[] {24, 243, 70, 103, 173, 151, 183, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void fillConstructorProperties([In] IdFunctionObject obj0)
    {
      this.addIdFunctionProperty((Scriptable) obj0, NativeError.ERROR_TAG, -1, "captureStackTrace", 2);
      NativeError.ProtoProps protoProps = new NativeError.ProtoProps((NativeError.\u0031) null);
      this.associateValue((object) "_ErrorPrototypeProps", (object) protoProps);
      obj0.defineProperty("stackTraceLimit", (object) protoProps, NativeError.ProtoProps.GET_STACK_LIMIT, NativeError.ProtoProps.SET_STACK_LIMIT, 0);
      obj0.defineProperty("prepareStackTrace", (object) protoProps, NativeError.ProtoProps.GET_PREPARE_STACK, NativeError.ProtoProps.SET_PREPARE_STACK, 0);
      base.fillConstructorProperties(obj0);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string getClassName() => "Error";

    [LineNumberTable(new byte[] {50, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toString()
    {
      object obj = NativeError.js_toString((Scriptable) this);
      return obj is string ? (string) obj : base.toString();
    }

    [LineNumberTable(new byte[] {58, 150, 98, 102, 130, 98, 102, 130, 98, 102, 130, 145, 111})]
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
          arity = 0;
          name = "toString";
          break;
        case 3:
          arity = 0;
          name = "toSource";
          break;
        default:
          string str = String.valueOf(obj0);
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalArgumentException(str);
      }
      this.initPrototypeMethod(NativeError.ERROR_TAG, obj0, name, arity);
    }

    [LineNumberTable(new byte[] {80, 109, 142, 103, 158, 171, 168, 170, 106, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override object execIdCall(
      [In] IdFunctionObject obj0,
      [In] Context obj1,
      [In] Scriptable obj2,
      [In] Scriptable obj3,
      [In] object[] obj4)
    {
      if (!obj0.hasTag(NativeError.ERROR_TAG))
        return base.execIdCall(obj0, obj1, obj2, obj3, obj4);
      int num = obj0.methodId();
      switch (num)
      {
        case -1:
          NativeError.js_captureStackTrace(obj1, obj3, obj4);
          return Undefined.__\u003C\u003Einstance;
        case 1:
          return (object) NativeError.make(obj1, obj2, obj0, obj4);
        case 2:
          return NativeError.js_toString(obj3);
        case 3:
          return (object) NativeError.js_toSource(obj1, obj2, obj3);
        default:
          string str = String.valueOf(num);
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalArgumentException(str);
      }
    }

    [LineNumberTable(new byte[] {115, 104, 198, 98, 98, 108, 145, 99, 103, 199, 114, 208, 99, 150, 235, 69, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object getStackDelegated([In] Scriptable obj0)
    {
      if (this.stackProvider == null)
        return Scriptable.NOT_FOUND;
      int limit = -1;
      Function function = (Function) null;
      NativeError.ProtoProps associatedValue1 = (NativeError.ProtoProps) ((ScriptableObject) this.getPrototype()).getAssociatedValue((object) "_ErrorPrototypeProps");
      if (associatedValue1 != null)
      {
        limit = associatedValue1.getStackTraceLimit();
        function = associatedValue1.getPrepareStackTrace();
      }
      string associatedValue2 = (string) this.getAssociatedValue((object) "_stackHide");
      ScriptStackElement[] scriptStack = this.stackProvider.getScriptStack(limit, associatedValue2);
      object obj = function != null ? this.callPrepareStack(function, scriptStack) : (object) RhinoException.formatStackTrace(scriptStack, this.stackProvider.details());
      this.setStackDelegated(obj0, obj);
      return obj;
    }

    [LineNumberTable(new byte[] {160, 202, 98, 130, 103, 100, 104, 101, 102, 100, 101, 102, 132, 101, 102, 130, 183})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override int findPrototypeId([In] string obj0)
    {
      int num = 0;
      string str = (string) null;
      switch (String.instancehelper_length(obj0))
      {
        case 8:
          switch (String.instancehelper_charAt(obj0, 3))
          {
            case 'o':
              str = "toSource";
              num = 3;
              break;
            case 't':
              str = "toString";
              num = 2;
              break;
          }
          break;
        case 11:
          str = "constructor";
          num = 1;
          break;
      }
      if (str != null && !object.ReferenceEquals((object) str, (object) obj0) && !String.instancehelper_equals(str, (object) obj0))
        num = 0;
      return num;
    }

    [LineNumberTable(new byte[] {159, 140, 178, 234, 72, 127, 8, 191, 34, 2, 97, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static NativeError()
    {
      IdScriptableObject.__\u003Cclinit\u003E();
      if (!ByteCodeHelper.isAlreadyInited("rhino.NativeError"))
      {
        NativeError.ERROR_TAG = (object) "Error";
        NoSuchMethodException suchMethodException1;
        try
        {
          NativeError.ERROR_DELEGATE_GET_STACK = ((Class) ClassLiteral<NativeError>.Value).getMethod("getStackDelegated", new Class[1]
          {
            (Class) ClassLiteral<Scriptable>.Value
          }, NativeError.__\u003CGetCallerID\u003E());
          NativeError.ERROR_DELEGATE_SET_STACK = ((Class) ClassLiteral<NativeError>.Value).getMethod("setStackDelegated", new Class[2]
          {
            (Class) ClassLiteral<Scriptable>.Value,
            (Class) ClassLiteral<Object>.Value
          }, NativeError.__\u003CGetCallerID\u003E());
          return;
        }
        catch (NoSuchMethodException ex)
        {
          suchMethodException1 = (NoSuchMethodException) ByteCodeHelper.MapException<NoSuchMethodException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
        }
        NoSuchMethodException suchMethodException2 = suchMethodException1;
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new RuntimeException((Exception) suchMethodException2);
      }
    }

    new static CallerID __\u003CGetCallerID\u003E()
    {
      if (NativeError.__\u003CcallerID\u003E == null)
        NativeError.__\u003CcallerID\u003E = (CallerID) new NativeError.__\u003CCallerID\u003E();
      return NativeError.__\u003CcallerID\u003E;
    }

    [InnerClass]
    [EnclosingMethod(null, null, null)]
    [Modifiers]
    [SpecialName]
    internal class \u0031 : Object
    {
      \u0031() => throw null;
    }

    [InnerClass]
    internal sealed class ProtoProps : Object
    {
      internal const string KEY = "_ErrorPrototypeProps";
      [Modifiers]
      internal static Method GET_STACK_LIMIT;
      [Modifiers]
      internal static Method SET_STACK_LIMIT;
      [Modifiers]
      internal static Method GET_PREPARE_STACK;
      [Modifiers]
      internal static Method SET_PREPARE_STACK;
      private int stackTraceLimit;
      private Function prepareStackTrace;
      [SpecialName]
      private static CallerID __\u003CcallerID\u003E;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [Modifiers]
      [LineNumberTable(353)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal ProtoProps([In] NativeError.\u0031 obj0)
        : this()
      {
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual int getStackTraceLimit() => this.stackTraceLimit;

      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual Function getPrepareStackTrace() => this.prepareStackTrace;

      [LineNumberTable(new byte[] {160, 239, 232, 83})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private ProtoProps()
      {
        NativeError.ProtoProps protoProps = this;
        this.stackTraceLimit = -1;
      }

      [LineNumberTable(new byte[] {161, 6, 105, 140})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual object getStackTraceLimit([In] Scriptable obj0) => this.stackTraceLimit >= 0 ? (object) Integer.valueOf(this.stackTraceLimit) : (object) Double.valueOf(double.PositiveInfinity);

      [LineNumberTable(new byte[] {161, 17, 105, 112, 137, 140})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void setStackTraceLimit([In] Scriptable obj0, [In] object obj1)
      {
        double number = Context.toNumber(obj1);
        if (Double.isNaN(number) || Double.isInfinite(number))
          this.stackTraceLimit = -1;
        else
          this.stackTraceLimit = ByteCodeHelper.d2i(number);
      }

      [LineNumberTable(new byte[] {161, 26, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual object getPrepareStackTrace([In] Scriptable obj0) => (object) this.getPrepareStackTrace() ?? Undefined.__\u003C\u003Einstance;

      [LineNumberTable(new byte[] {161, 35, 112, 105, 104, 140})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void setPrepareStackTrace([In] Scriptable obj0, [In] object obj1)
      {
        if (obj1 == null || Object.instancehelper_equals(Undefined.__\u003C\u003Einstance, obj1))
        {
          this.prepareStackTrace = (Function) null;
        }
        else
        {
          if (!(obj1 is Function))
            return;
          this.prepareStackTrace = (Function) obj1;
        }
      }

      [LineNumberTable(new byte[] {159, 52, 173, 127, 8, 127, 16, 127, 8, 191, 34, 2, 97, 140})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static ProtoProps()
      {
        if (!ByteCodeHelper.isAlreadyInited("rhino.NativeError$ProtoProps"))
        {
          NoSuchMethodException suchMethodException1;
          try
          {
            NativeError.ProtoProps.GET_STACK_LIMIT = ((Class) ClassLiteral<NativeError.ProtoProps>.Value).getMethod("getStackTraceLimit", new Class[1]
            {
              (Class) ClassLiteral<Scriptable>.Value
            }, NativeError.ProtoProps.__\u003CGetCallerID\u003E());
            NativeError.ProtoProps.SET_STACK_LIMIT = ((Class) ClassLiteral<NativeError.ProtoProps>.Value).getMethod("setStackTraceLimit", new Class[2]
            {
              (Class) ClassLiteral<Scriptable>.Value,
              (Class) ClassLiteral<Object>.Value
            }, NativeError.ProtoProps.__\u003CGetCallerID\u003E());
            NativeError.ProtoProps.GET_PREPARE_STACK = ((Class) ClassLiteral<NativeError.ProtoProps>.Value).getMethod("getPrepareStackTrace", new Class[1]
            {
              (Class) ClassLiteral<Scriptable>.Value
            }, NativeError.ProtoProps.__\u003CGetCallerID\u003E());
            NativeError.ProtoProps.SET_PREPARE_STACK = ((Class) ClassLiteral<NativeError.ProtoProps>.Value).getMethod("setPrepareStackTrace", new Class[2]
            {
              (Class) ClassLiteral<Scriptable>.Value,
              (Class) ClassLiteral<Object>.Value
            }, NativeError.ProtoProps.__\u003CGetCallerID\u003E());
            return;
          }
          catch (NoSuchMethodException ex)
          {
            suchMethodException1 = (NoSuchMethodException) ByteCodeHelper.MapException<NoSuchMethodException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
          }
          NoSuchMethodException suchMethodException2 = suchMethodException1;
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new RuntimeException((Exception) suchMethodException2);
        }
      }

      static CallerID __\u003CGetCallerID\u003E()
      {
        if (NativeError.ProtoProps.__\u003CcallerID\u003E == null)
          NativeError.ProtoProps.__\u003CcallerID\u003E = (CallerID) new NativeError.ProtoProps.__\u003CCallerID\u003E();
        return NativeError.ProtoProps.__\u003CcallerID\u003E;
      }

      private sealed class __\u003CCallerID\u003E : CallerID
      {
        internal __\u003CCallerID\u003E()
        {
        }
      }
    }

    private new sealed class __\u003CCallerID\u003E : CallerID
    {
      internal __\u003CCallerID\u003E()
      {
      }
    }
  }
}
