// Decompiled with JetBrains decompiler
// Type: rhino.InterpretedFunction
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using rhino.debug;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace rhino
{
  [Implements(new string[] {"rhino.Script"})]
  internal sealed class InterpretedFunction : NativeFunction, Script
  {
    internal InterpreterData idata;
    internal SecurityController securityController;
    internal object securityDomain;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(112)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isScript() => this.idata.itsFunctionType == 0;

    [LineNumberTable(117)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string getEncodedSource() => Interpreter.getEncodedSource(this.idata);

    [LineNumberTable(new byte[] {159, 153, 104, 231, 69, 102, 135, 99, 138, 99, 139, 162, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private InterpretedFunction([In] InterpreterData obj0, [In] object obj1)
    {
      InterpretedFunction interpretedFunction = this;
      this.idata = obj0;
      SecurityController securityController = Context.getContext().getSecurityController();
      object obj;
      if (securityController != null)
      {
        obj = securityController.getDynamicSecurityDomain(obj1);
      }
      else
      {
        if (obj1 != null)
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalArgumentException();
        }
        obj = (object) null;
      }
      this.securityController = securityController;
      this.securityDomain = obj;
    }

    [LineNumberTable(new byte[] {159, 175, 104, 115, 108, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private InterpretedFunction([In] InterpretedFunction obj0, [In] int obj1)
    {
      InterpretedFunction interpretedFunction = this;
      this.idata = obj0.idata.itsNestedFunctions[obj1];
      this.securityController = obj0.securityController;
      this.securityDomain = obj0.securityDomain;
    }

    [LineNumberTable(new byte[] {159, 187, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static InterpretedFunction createScript(
      [In] InterpreterData obj0,
      [In] object obj1)
    {
      return new InterpretedFunction(obj0, obj1);
    }

    [LineNumberTable(new byte[] {6, 104, 115})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static InterpretedFunction createFunction(
      [In] Context obj0,
      [In] Scriptable obj1,
      [In] InterpreterData obj2,
      [In] object obj3)
    {
      InterpretedFunction interpretedFunction = new InterpretedFunction(obj2, obj3);
      interpretedFunction.initScriptFunction(obj0, obj1, interpretedFunction.idata.isES6Generator);
      return interpretedFunction;
    }

    [LineNumberTable(new byte[] {17, 104, 115})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static InterpretedFunction createFunction(
      [In] Context obj0,
      [In] Scriptable obj1,
      [In] InterpretedFunction obj2,
      [In] int obj3)
    {
      InterpretedFunction interpretedFunction = new InterpretedFunction(obj2, obj3);
      interpretedFunction.initScriptFunction(obj0, obj1, interpretedFunction.idata.isES6Generator);
      return interpretedFunction;
    }

    [LineNumberTable(75)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string getFunctionName() => this.idata.itsName == null ? "" : this.idata.itsName;

    [LineNumberTable(new byte[] {40, 104, 151})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override object call([In] Context obj0, [In] Scriptable obj1, [In] Scriptable obj2, [In] object[] obj3) => !ScriptRuntime.hasTopCall(obj0) ? ScriptRuntime.doTopCall((Callable) this, obj0, obj1, obj2, obj3, this.idata.isStrict) : Interpreter.interpret(this, obj0, obj1, obj2, obj3);

    [LineNumberTable(new byte[] {48, 136, 139, 136, 186})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object exec([In] Context obj0, [In] Scriptable obj1)
    {
      if (!this.isScript())
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalStateException();
      }
      return !ScriptRuntime.hasTopCall(obj0) ? ScriptRuntime.doTopCall((Callable) this, obj0, obj1, obj1, ScriptRuntime.__\u003C\u003EemptyArgs, this.idata.isStrict) : Interpreter.interpret(this, obj0, obj1, obj1, ScriptRuntime.__\u003C\u003EemptyArgs);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override DebuggableScript getDebuggableView() => (DebuggableScript) this.idata;

    [LineNumberTable(128)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override object resumeGenerator(
      [In] Context obj0,
      [In] Scriptable obj1,
      [In] int obj2,
      [In] object obj3,
      [In] object obj4)
    {
      return Interpreter.resumeGenerator(obj0, obj1, obj2, obj3, obj4);
    }

    [LineNumberTable(133)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override int getLanguageVersion() => this.idata.languageVersion;

    [LineNumberTable(138)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override int getParamCount() => this.idata.argCount;

    [LineNumberTable(143)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override int getParamAndVarCount() => this.idata.argNames.Length;

    [LineNumberTable(148)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override string getParamOrVarName([In] int obj0) => this.idata.argNames[obj0];

    [LineNumberTable(153)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override bool getParamOrVarConst([In] int obj0) => this.idata.argIsConst[obj0];

    [LineNumberTable(new byte[] {107, 112, 114, 106, 108, 226, 60, 230, 71})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual bool hasFunctionNamed([In] string obj0)
    {
      for (int index = 0; index < this.idata.getFunctionCount(); ++index)
      {
        InterpreterData function = (InterpreterData) this.idata.getFunction(index);
        if (!function.declaredAsFunctionExpression && String.instancehelper_equals(obj0, (object) function.getFunctionName()))
          return false;
      }
      return true;
    }

    [HideFromJava]
    static InterpretedFunction() => NativeFunction.__\u003Cclinit\u003E();
  }
}
