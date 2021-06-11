// Decompiled with JetBrains decompiler
// Type: rhino.ArrowFunction
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace rhino
{
  public class ArrowFunction : BaseFunction
  {
    [Modifiers]
    private Callable targetFunction;
    [Modifiers]
    private Scriptable boundThis;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {14, 109, 147})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal override string decompile([In] int obj0, [In] int obj1) => this.targetFunction is BaseFunction ? ((BaseFunction) this.targetFunction).decompile(obj0, obj1) : base.decompile(obj0, obj1);

    [LineNumberTable(new byte[] {1, 109, 145})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override int getLength() => this.targetFunction is BaseFunction ? ((BaseFunction) this.targetFunction).getLength() : 0;

    [LineNumberTable(new byte[] {159, 154, 104, 103, 136, 135, 103, 102, 109, 109, 114, 114, 134, 110, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ArrowFunction(
      Context cx,
      Scriptable scope,
      Callable targetFunction,
      Scriptable boundThis)
    {
      ArrowFunction arrowFunction = this;
      this.targetFunction = targetFunction;
      this.boundThis = boundThis;
      ScriptRuntime.setFunctionProtoAndParent((BaseFunction) this, scope);
      BaseFunction baseFunction = ScriptRuntime.typeErrorThrower(cx);
      NativeObject nativeObject = new NativeObject();
      nativeObject.put("get", (Scriptable) nativeObject, (object) baseFunction);
      nativeObject.put("set", (Scriptable) nativeObject, (object) baseFunction);
      nativeObject.put("enumerable", (Scriptable) nativeObject, (object) Boolean.valueOf(false));
      nativeObject.put("configurable", (Scriptable) nativeObject, (object) Boolean.valueOf(false));
      nativeObject.preventExtensions();
      this.defineOwnProperty(cx, (object) "caller", (ScriptableObject) nativeObject, false);
      this.defineOwnProperty(cx, (object) "arguments", (ScriptableObject) nativeObject, false);
    }

    [LineNumberTable(new byte[] {159, 174, 119})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override object call(Context cx, Scriptable scope, Scriptable thisObj, object[] args)
    {
      Scriptable s2 = this.boundThis == null ? ScriptRuntime.getTopCallScope(cx) : this.boundThis;
      return this.targetFunction.call(cx, scope, s2, args);
    }

    [LineNumberTable(38)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override Scriptable construct(Context cx, Scriptable scope, object[] args) => throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.typeError1("msg.not.ctor", (object) this.decompile(0, 0)));

    [LineNumberTable(new byte[] {159, 185, 109, 146})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool hasInstance(Scriptable instance) => this.targetFunction is Function ? ((Scriptable) this.targetFunction).hasInstance(instance) : throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.typeError0("msg.not.ctor"));

    [LineNumberTable(59)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override int getArity() => this.getLength();

    [LineNumberTable(71)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static bool equalObjectGraphs(
      [In] ArrowFunction obj0,
      [In] ArrowFunction obj1,
      [In] EqualObjectGraphs obj2)
    {
      return obj2.equalGraphs((object) obj0.boundThis, (object) obj1.boundThis) && obj2.equalGraphs((object) obj0.targetFunction, (object) obj1.targetFunction);
    }

    [HideFromJava]
    static ArrowFunction() => BaseFunction.__\u003Cclinit\u003E();
  }
}
