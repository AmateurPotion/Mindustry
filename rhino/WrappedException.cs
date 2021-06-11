// Decompiled with JetBrains decompiler
// Type: rhino.WrappedException
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using System;
using System.Runtime.CompilerServices;

namespace rhino
{
  public class WrappedException : EvaluatorException
  {
    [Modifiers]
    private Exception exception;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 157, 127, 8, 103, 136, 107, 103, 100, 99, 135, 99, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public WrappedException(Exception exception)
      : base(new StringBuilder().append("Wrapped ").append(Throwable.instancehelper_toString(exception)).toString())
    {
      WrappedException wrappedException = this;
      this.exception = exception;
      Throwable.instancehelper_initCause((Exception) this, exception);
      int[] numArray = new int[1]{ 0 };
      string positionFromStack = Context.getSourcePositionFromStack(numArray);
      int lineNumber = numArray[0];
      if (positionFromStack != null)
        this.initSourceName(positionFromStack);
      if (lineNumber == 0)
        return;
      this.initLineNumber(lineNumber);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Exception getWrappedException() => this.exception;

    [Obsolete]
    [LineNumberTable(44)]
    [Deprecated(new object[] {64, "Ljava/lang/Deprecated;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object unwrap() => (object) this.getWrappedException();

    [HideFromJava]
    static WrappedException() => EvaluatorException.__\u003Cclinit\u003E();
  }
}
