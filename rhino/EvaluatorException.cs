// Decompiled with JetBrains decompiler
// Type: rhino.EvaluatorException
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using System;
using System.Runtime.CompilerServices;

namespace rhino
{
  public class EvaluatorException : RhinoException
  {
    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 182, 105, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public EvaluatorException(
      string detail,
      string sourceName,
      int lineNumber,
      string lineSource,
      int columnNumber)
      : base(detail)
    {
      EvaluatorException evaluatorException = this;
      this.recordErrorOrigin(sourceName, lineNumber, lineSource, columnNumber);
    }

    [LineNumberTable(new byte[] {159, 150, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public EvaluatorException(string detail)
      : base(detail)
    {
    }

    [LineNumberTable(new byte[] {159, 164, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public EvaluatorException(string detail, string sourceName, int lineNumber)
      : this(detail, sourceName, lineNumber, (string) null, 0)
    {
    }

    [Obsolete]
    [LineNumberTable(49)]
    [Deprecated(new object[] {64, "Ljava/lang/Deprecated;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string getSourceName() => this.sourceName();

    [Obsolete]
    [LineNumberTable(57)]
    [Deprecated(new object[] {64, "Ljava/lang/Deprecated;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getLineNumber() => this.lineNumber();

    [Obsolete]
    [LineNumberTable(65)]
    [Deprecated(new object[] {64, "Ljava/lang/Deprecated;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getColumnNumber() => this.columnNumber();

    [Obsolete]
    [LineNumberTable(73)]
    [Deprecated(new object[] {64, "Ljava/lang/Deprecated;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string getLineSource() => this.lineSource();

    [HideFromJava]
    static EvaluatorException() => RhinoException.__\u003Cclinit\u003E();
  }
}
