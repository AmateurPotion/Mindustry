// Decompiled with JetBrains decompiler
// Type: rhino.NativeFunction
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using rhino.debug;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace rhino
{
  public abstract class NativeFunction : BaseFunction
  {
    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal new static void __\u003Cclinit\u003E()
    {
    }

    protected internal abstract int getLanguageVersion();

    protected internal abstract string getParamOrVarName(int i);

    protected internal abstract int getParamCount();

    [LineNumberTable(new byte[] {159, 168, 103, 99, 137, 103, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal override sealed string decompile([In] int obj0, [In] int obj1)
    {
      string encodedSource = this.getEncodedSource();
      if (encodedSource == null)
        return base.decompile(obj0, obj1);
      UintMap properties = new UintMap(1);
      properties.put(1, obj0);
      return Decompiler.decompile(encodedSource, obj1, properties);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual DebuggableScript getDebuggableView() => (DebuggableScript) null;

    [LineNumberTable(86)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object resumeGenerator(
      Context cx,
      Scriptable scope,
      int operation,
      object state,
      object value)
    {
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new EvaluatorException("resumeGenerator() not implemented");
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string getEncodedSource() => (string) null;

    [LineNumberTable(new byte[] {159, 138, 98, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public void initScriptFunction(Context cx, Scriptable scope, bool es6GeneratorFunction)
    {
      int num = es6GeneratorFunction ? 1 : 0;
      ScriptRuntime.setFunctionProtoAndParent((BaseFunction) this, scope, num != 0);
    }

    [LineNumberTable(10)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public NativeFunction()
    {
    }

    [LineNumberTable(new byte[] {159, 155, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public void initScriptFunction(Context cx, Scriptable scope) => this.initScriptFunction(cx, scope, this.isGeneratorFunction());

    [LineNumberTable(new byte[] {159, 179, 103, 106, 130, 102, 104, 99, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override int getLength()
    {
      int paramCount = this.getParamCount();
      if (this.getLanguageVersion() != 120)
        return paramCount;
      NativeCall functionActivation = ScriptRuntime.findFunctionActivation(Context.getContext(), (Function) this);
      return functionActivation == null ? paramCount : functionActivation.originalArgs.Length;
    }

    [LineNumberTable(51)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override int getArity() => this.getParamCount();

    [Obsolete]
    [LineNumberTable(61)]
    [Deprecated(new object[] {64, "Ljava/lang/Deprecated;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string jsGet_name() => this.getFunctionName();

    protected internal abstract int getParamAndVarCount();

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual bool getParamOrVarConst(int index) => false;

    [HideFromJava]
    static NativeFunction() => BaseFunction.__\u003Cclinit\u003E();
  }
}
