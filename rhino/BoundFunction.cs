// Decompiled with JetBrains decompiler
// Type: rhino.BoundFunction
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
  public class BoundFunction : BaseFunction
  {
    [Modifiers]
    private Callable targetFunction;
    [Modifiers]
    private Scriptable boundThis;
    [Modifiers]
    private object[] boundArgs;
    [Modifiers]
    private int length;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 158, 104, 103, 104, 104, 104, 157, 167, 135, 103, 102, 109, 109, 114, 114, 134, 110, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public BoundFunction(
      Context cx,
      Scriptable scope,
      Callable targetFunction,
      Scriptable boundThis,
      object[] boundArgs)
    {
      BoundFunction boundFunction = this;
      this.targetFunction = targetFunction;
      this.boundThis = boundThis;
      this.boundArgs = boundArgs;
      this.length = !(targetFunction is BaseFunction) ? 0 : Math.max(0, ((BaseFunction) targetFunction).getLength() - boundArgs.Length);
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

    [LineNumberTable(new byte[] {18, 107, 107, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private object[] concat([In] object[] obj0, [In] object[] obj1)
    {
      object[] objArray = new object[obj0.Length + obj1.Length];
      ByteCodeHelper.arraycopy((object) obj0, 0, (object) objArray, 0, obj0.Length);
      ByteCodeHelper.arraycopy((object) obj1, 0, (object) objArray, obj0.Length, obj1.Length);
      return objArray;
    }

    [LineNumberTable(new byte[] {159, 184, 119})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override object call(
      Context cx,
      Scriptable scope,
      Scriptable thisObj,
      object[] extraArgs)
    {
      Scriptable s2 = this.boundThis == null ? ScriptRuntime.getTopCallScope(cx) : this.boundThis;
      return this.targetFunction.call(cx, scope, s2, this.concat(this.boundArgs, extraArgs));
    }

    [LineNumberTable(new byte[] {159, 190, 109, 159, 1})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override Scriptable construct(
      Context cx,
      Scriptable scope,
      object[] extraArgs)
    {
      if (this.targetFunction is Function)
        return ((Function) this.targetFunction).construct(cx, scope, this.concat(this.boundArgs, extraArgs));
      throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.typeError0("msg.not.ctor"));
    }

    [LineNumberTable(new byte[] {6, 109, 146})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool hasInstance(Scriptable instance) => this.targetFunction is Function ? ((Scriptable) this.targetFunction).hasInstance(instance) : throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.typeError0("msg.not.ctor"));

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override int getLength() => this.length;

    [LineNumberTable(75)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static bool equalObjectGraphs(
      [In] BoundFunction obj0,
      [In] BoundFunction obj1,
      [In] EqualObjectGraphs obj2)
    {
      return obj2.equalGraphs((object) obj0.boundThis, (object) obj1.boundThis) && obj2.equalGraphs((object) obj0.targetFunction, (object) obj1.targetFunction) && obj2.equalGraphs((object) obj0.boundArgs, (object) obj1.boundArgs);
    }

    [HideFromJava]
    static BoundFunction() => BaseFunction.__\u003Cclinit\u003E();
  }
}
