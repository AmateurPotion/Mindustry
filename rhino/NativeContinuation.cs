// Decompiled with JetBrains decompiler
// Type: rhino.NativeContinuation
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.util;
using System;
using System.Runtime.CompilerServices;

namespace rhino
{
  [Implements(new string[] {"rhino.Function"})]
  public sealed class NativeContinuation : IdScriptableObject, Function, Scriptable, Callable
  {
    [Modifiers]
    private static object FTAG;
    private object implementation;
    private const int Id_constructor = 1;
    private const int MAX_PROTOTYPE_ID = 1;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(52)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool equalImplementations(NativeContinuation c1, NativeContinuation c2) => Objects.equals(c1.implementation, c2.implementation);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object getImplementation() => this.implementation;

    [LineNumberTable(41)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool isContinuationConstructor(IdFunctionObject f) => f.hasTag(NativeContinuation.FTAG) && f.methodId() == 1;

    [LineNumberTable(5)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public NativeContinuation()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void initImplementation(object implementation) => this.implementation = implementation;

    [LineNumberTable(new byte[] {159, 139, 66, 102, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void init(Context cx, Scriptable scope, bool @sealed)
    {
      int num = @sealed ? 1 : 0;
      new NativeContinuation().exportAsJSClass(1, scope, num != 0);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string getClassName() => "Continuation";

    [LineNumberTable(31)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Scriptable construct(Context cx, Scriptable scope, object[] args) => throw Throwable.__\u003Cunmap\u003E((Exception) Context.reportRuntimeError("Direct call is not supported"));

    [LineNumberTable(37)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object call(Context cx, Scriptable scope, Scriptable thisObj, object[] args) => Interpreter.restartContinuation(this, cx, scope, args);

    [LineNumberTable(new byte[] {9, 139, 98, 102, 130, 145, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void initPrototypeId(int id)
    {
      if (id == 1)
      {
        int arity = 0;
        string name = "constructor";
        this.initPrototypeMethod(NativeContinuation.FTAG, id, name, arity);
      }
      else
      {
        string str = String.valueOf(id);
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException(str);
      }
    }

    [LineNumberTable(new byte[] {23, 109, 142, 103, 139, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override object execIdCall(
      IdFunctionObject f,
      Context cx,
      Scriptable scope,
      Scriptable thisObj,
      object[] args)
    {
      if (!f.hasTag(NativeContinuation.FTAG))
        return base.execIdCall(f, cx, scope, thisObj, args);
      int num = f.methodId();
      string str = num != 1 ? String.valueOf(num) : throw Throwable.__\u003Cunmap\u003E((Exception) Context.reportRuntimeError("Direct call is not supported"));
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new IllegalArgumentException(str);
    }

    [LineNumberTable(new byte[] {42, 98, 98, 106, 102, 130, 183})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override int findPrototypeId(string s)
    {
      int num = 0;
      string str = (string) null;
      if (String.instancehelper_length(s) == 11)
      {
        str = "constructor";
        num = 1;
      }
      if (str != null && !object.ReferenceEquals((object) str, (object) s) && !String.instancehelper_equals(str, (object) s))
        num = 0;
      return num;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    static NativeContinuation()
    {
      IdScriptableObject.__\u003Cclinit\u003E();
      if (ByteCodeHelper.isAlreadyInited("rhino.NativeContinuation"))
        return;
      NativeContinuation.FTAG = (object) "Continuation";
    }
  }
}
