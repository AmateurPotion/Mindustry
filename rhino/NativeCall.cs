// Decompiled with JetBrains decompiler
// Type: rhino.NativeCall
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
  public sealed class NativeCall : IdScriptableObject
  {
    [Modifiers]
    private static object CALL_TAG;
    private const int Id_constructor = 1;
    private const int MAX_PROTOTYPE_ID = 1;
    internal NativeFunction function;
    internal object[] originalArgs;
    internal bool isStrict;
    private Arguments arguments;
    [NonSerialized]
    internal NativeCall parentActivationCall;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 160, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal NativeCall()
    {
    }

    [LineNumberTable(new byte[] {159, 139, 130, 102, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static void init([In] Scriptable obj0, [In] bool obj1)
    {
      int num = obj1 ? 1 : 0;
      new NativeCall().exportAsJSClass(1, obj0, num != 0);
    }

    [LineNumberTable(new byte[] {159, 137, 102, 104, 135, 167, 113, 167, 103, 104, 99, 105, 106, 147, 235, 60, 232, 74, 113, 108, 178, 102, 108, 106, 107, 106, 113, 112, 103, 238, 57, 235, 76})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal NativeCall(
      [In] NativeFunction obj0,
      [In] Scriptable obj1,
      [In] object[] obj2,
      [In] bool obj3,
      [In] bool obj4)
    {
      int num1 = obj4 ? 1 : 0;
      int num2 = obj3 ? 1 : 0;
      // ISSUE: explicit constructor call
      base.\u002Ector();
      NativeCall nativeCall = this;
      this.function = obj0;
      this.setParentScope(obj1);
      this.originalArgs = obj2 != null ? obj2 : ScriptRuntime.__\u003C\u003EemptyArgs;
      this.isStrict = num1 != 0;
      int paramAndVarCount = obj0.getParamAndVarCount();
      int paramCount = obj0.getParamCount();
      if (paramAndVarCount != 0)
      {
        for (int i = 0; i < paramCount; ++i)
          this.defineProperty(obj0.getParamOrVarName(i), i >= obj2.Length ? Undefined.__\u003C\u003Einstance : obj2[i], 4);
      }
      if (!this.has(nameof (arguments), (Scriptable) this) && num2 == 0)
      {
        this.arguments = new Arguments(this);
        this.defineProperty(nameof (arguments), (object) this.arguments, 4);
      }
      if (paramAndVarCount == 0)
        return;
      for (int index = paramCount; index < paramAndVarCount; ++index)
      {
        string paramOrVarName = obj0.getParamOrVarName(index);
        if (!this.has(paramOrVarName, (Scriptable) this))
        {
          if (obj0.getParamOrVarConst(index))
            this.defineProperty(paramOrVarName, Undefined.__\u003C\u003Einstance, 13);
          else if (!(obj0 is InterpretedFunction) || ((InterpretedFunction) obj0).hasFunctionNamed(paramOrVarName))
            this.defineProperty(paramOrVarName, Undefined.__\u003C\u003Einstance, 4);
        }
      }
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string getClassName() => "Call";

    [LineNumberTable(71)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override int findPrototypeId(string s) => String.instancehelper_equals(s, (object) "constructor") ? 1 : 0;

    [LineNumberTable(new byte[] {28, 100, 98, 136, 145, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void initPrototypeId(int id)
    {
      if (id == 1)
      {
        int arity = 1;
        string name = "constructor";
        this.initPrototypeMethod(NativeCall.CALL_TAG, id, name, arity);
      }
      else
      {
        string str = String.valueOf(id);
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException(str);
      }
    }

    [LineNumberTable(new byte[] {40, 109, 142, 103, 100, 100, 149, 107, 102, 108, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override object execIdCall(
      IdFunctionObject f,
      Context cx,
      Scriptable scope,
      Scriptable thisObj,
      object[] args)
    {
      if (!f.hasTag(NativeCall.CALL_TAG))
        return base.execIdCall(f, cx, scope, thisObj, args);
      int num = f.methodId();
      if (num == 1)
      {
        if (thisObj != null)
          throw Throwable.__\u003Cunmap\u003E((Exception) Context.reportRuntimeError1("msg.only.from.new", (object) "Call"));
        ScriptRuntime.checkDeprecated(cx, "Call");
        NativeCall nativeCall = new NativeCall();
        nativeCall.setPrototype(ScriptableObject.getObjectPrototype(scope));
        return (object) nativeCall;
      }
      string str = String.valueOf(num);
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new IllegalArgumentException(str);
    }

    [LineNumberTable(new byte[] {57, 104, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void defineAttributesForArguments()
    {
      if (this.arguments == null)
        return;
      this.arguments.defineAttributesForStrictMode();
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    static NativeCall()
    {
      IdScriptableObject.__\u003Cclinit\u003E();
      if (ByteCodeHelper.isAlreadyInited("rhino.NativeCall"))
        return;
      NativeCall.CALL_TAG = (object) "Call";
    }
  }
}
