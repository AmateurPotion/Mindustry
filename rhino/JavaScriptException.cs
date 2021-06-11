// Decompiled with JetBrains decompiler
// Type: rhino.JavaScriptException
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System;
using System.Runtime.CompilerServices;

namespace rhino
{
  public class JavaScriptException : RhinoException
  {
    [Modifiers]
    private object value;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 166, 104, 106, 167, 114, 103, 103, 110, 141, 110, 178, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public JavaScriptException(object value, string sourceName, int lineNumber)
    {
      JavaScriptException javaScriptException = this;
      this.recordErrorOrigin(sourceName, lineNumber, (string) null, 0);
      this.value = value;
      if (!(value is NativeError) || !Context.getContext().hasFeature(10))
        return;
      NativeError nativeError = (NativeError) value;
      if (!nativeError.has("fileName", (Scriptable) nativeError))
        nativeError.put("fileName", (Scriptable) nativeError, (object) sourceName);
      if (!nativeError.has(nameof (lineNumber), (Scriptable) nativeError))
        nativeError.put(nameof (lineNumber), (Scriptable) nativeError, (object) Integer.valueOf(lineNumber));
      nativeError.setStackProvider((RhinoException) this);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object getValue() => this.value;

    [Obsolete]
    [LineNumberTable(new byte[] {159, 159, 109})]
    [Deprecated(new object[] {64, "Ljava/lang/Deprecated;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public JavaScriptException(object value)
      : this(value, "", 0)
    {
    }

    [LineNumberTable(new byte[] {159, 187, 104, 102, 109, 172, 127, 5, 129, 109, 145})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string details()
    {
      if (this.value == null)
        return "null";
      if (this.value is NativeError)
        return Object.instancehelper_toString(this.value);
      string str;
      try
      {
        str = ScriptRuntime.toString(this.value);
      }
      catch (Exception ex)
      {
        if (ByteCodeHelper.MapException<RuntimeException>(ex, (ByteCodeHelper.MapFlags) 2) == null)
          throw;
        else
          goto label_8;
      }
      return str;
label_8:
      return this.value is Scriptable ? ScriptRuntime.defaultObjectToString((Scriptable) this.value) : Object.instancehelper_toString(this.value);
    }

    [Obsolete]
    [LineNumberTable(73)]
    [Deprecated(new object[] {64, "Ljava/lang/Deprecated;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string getSourceName() => this.sourceName();

    [Obsolete]
    [LineNumberTable(81)]
    [Deprecated(new object[] {64, "Ljava/lang/Deprecated;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getLineNumber() => this.lineNumber();

    [HideFromJava]
    static JavaScriptException() => RhinoException.__\u003Cclinit\u003E();
  }
}
