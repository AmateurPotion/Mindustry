// Decompiled with JetBrains decompiler
// Type: rhino.ast.ErrorCollector
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using java.util;
using System.Runtime.CompilerServices;

namespace rhino.ast
{
  [Implements(new string[] {"rhino.ast.IdeErrorReporter"})]
  public class ErrorCollector : Object, IdeErrorReporter, ErrorReporter
  {
    [Modifiers]
    [Signature("Ljava/util/List<Lrhino/ast/ParseProblem;>;")]
    private List errors;

    [LineNumberTable(new byte[] {159, 156, 136})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ErrorCollector()
    {
      ErrorCollector errorCollector = this;
      this.errors = (List) new ArrayList();
    }

    [LineNumberTable(25)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void warning(
      string message,
      string sourceName,
      int line,
      string lineSource,
      int lineOffset)
    {
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new UnsupportedOperationException();
    }

    [LineNumberTable(new byte[] {159, 175, 187})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void warning(string message, string sourceName, int offset, int length) => this.errors.add((object) new ParseProblem(ParseProblem.Type.__\u003C\u003EWarning, message, sourceName, offset, length));

    [LineNumberTable(45)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void error(
      string message,
      string sourceName,
      int line,
      string lineSource,
      int lineOffset)
    {
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new UnsupportedOperationException();
    }

    [LineNumberTable(new byte[] {4, 187})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void error(string message, string sourceName, int fileOffset, int length) => this.errors.add((object) new ParseProblem(ParseProblem.Type.__\u003C\u003EError, message, sourceName, fileOffset, length));

    [LineNumberTable(66)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual EvaluatorException runtimeError(
      string message,
      string sourceName,
      int line,
      string lineSource,
      int lineOffset)
    {
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new UnsupportedOperationException();
    }

    [Signature("()Ljava/util/List<Lrhino/ast/ParseProblem;>;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual List getErrors() => this.errors;

    [LineNumberTable(new byte[] {28, 116, 127, 1, 119, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toString()
    {
      StringBuilder stringBuilder = new StringBuilder(this.errors.size() * 100);
      Iterator iterator = this.errors.iterator();
      while (iterator.hasNext())
      {
        ParseProblem parseProblem = (ParseProblem) iterator.next();
        stringBuilder.append(parseProblem.toString()).append("\n");
      }
      return stringBuilder.toString();
    }
  }
}
