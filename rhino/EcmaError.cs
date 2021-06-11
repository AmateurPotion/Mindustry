// Decompiled with JetBrains decompiler
// Type: rhino.EcmaError
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
  public class EcmaError : RhinoException
  {
    [Modifiers]
    private string errorName;
    [Modifiers]
    private string errorMessage;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 169, 104, 109, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal EcmaError([In] string obj0, [In] string obj1, [In] string obj2, [In] int obj3, [In] string obj4, [In] int obj5)
    {
      EcmaError ecmaError = this;
      this.recordErrorOrigin(obj2, obj3, obj4, obj5);
      this.errorName = obj0;
      this.errorMessage = obj1;
    }

    [Obsolete]
    [LineNumberTable(new byte[] {159, 182, 151})]
    [Deprecated(new object[] {64, "Ljava/lang/Deprecated;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public EcmaError(
      Scriptable nativeError,
      string sourceName,
      int lineNumber,
      int columnNumber,
      string lineSource)
      : this("InternalError", ScriptRuntime.toString((object) nativeError), sourceName, lineNumber, lineSource, columnNumber)
    {
    }

    [LineNumberTable(46)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string details() => new StringBuilder().append(this.errorName).append(": ").append(this.errorMessage).toString();

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string getName() => this.errorName;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string getErrorMessage() => this.errorMessage;

    [Obsolete]
    [LineNumberTable(79)]
    [Deprecated(new object[] {64, "Ljava/lang/Deprecated;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string getSourceName() => this.sourceName();

    [Obsolete]
    [LineNumberTable(87)]
    [Deprecated(new object[] {64, "Ljava/lang/Deprecated;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getLineNumber() => this.lineNumber();

    [Obsolete]
    [LineNumberTable(95)]
    [Deprecated(new object[] {64, "Ljava/lang/Deprecated;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getColumnNumber() => this.columnNumber();

    [Obsolete]
    [LineNumberTable(103)]
    [Deprecated(new object[] {64, "Ljava/lang/Deprecated;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string getLineSource() => this.lineSource();

    [Obsolete]
    [Deprecated(new object[] {64, "Ljava/lang/Deprecated;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Scriptable getErrorObject() => (Scriptable) null;

    [HideFromJava]
    static EcmaError() => RhinoException.__\u003Cclinit\u003E();
  }
}
