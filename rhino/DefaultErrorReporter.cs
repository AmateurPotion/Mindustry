// Decompiled with JetBrains decompiler
// Type: rhino.DefaultErrorReporter
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
  internal class DefaultErrorReporter : Object, ErrorReporter
  {
    [Modifiers]
    internal static DefaultErrorReporter instance;
    private bool forEval;
    private ErrorReporter chainedReporter;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 159, 102, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static ErrorReporter forEval([In] ErrorReporter obj0) => (ErrorReporter) new DefaultErrorReporter()
    {
      forEval = true,
      chainedReporter = obj0
    };

    [LineNumberTable(new byte[] {159, 155, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private DefaultErrorReporter()
    {
    }

    [LineNumberTable(new byte[] {15, 104, 147})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual EvaluatorException runtimeError(
      [In] string obj0,
      [In] string obj1,
      [In] int obj2,
      [In] string obj3,
      [In] int obj4)
    {
      return this.chainedReporter != null ? this.chainedReporter.runtimeError(obj0, obj1, obj2, obj3, obj4) : new EvaluatorException(obj0, obj1, obj2, obj3, obj4);
    }

    [LineNumberTable(new byte[] {159, 168, 104, 242, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void warning([In] string obj0, [In] string obj1, [In] int obj2, [In] string obj3, [In] int obj4)
    {
      if (this.chainedReporter == null)
        return;
      this.chainedReporter.warning(obj0, obj1, obj2, obj3, obj4);
    }

    [LineNumberTable(new byte[] {159, 179, 200, 102, 102, 102, 102, 109, 102, 146, 179, 104, 180, 179})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void error([In] string obj0, [In] string obj1, [In] int obj2, [In] string obj3, [In] int obj4)
    {
      if (this.forEval)
      {
        string error = "SyntaxError";
        if (String.instancehelper_startsWith(obj0, "TypeError: "))
        {
          error = "TypeError";
          obj0 = String.instancehelper_substring(obj0, String.instancehelper_length("TypeError: "));
        }
        throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.constructError(error, obj0, obj1, obj2, obj3, obj4));
      }
      if (this.chainedReporter == null)
        throw Throwable.__\u003Cunmap\u003E((Exception) this.runtimeError(obj0, obj1, obj2, obj3, obj4));
      this.chainedReporter.error(obj0, obj1, obj2, obj3, obj4);
    }

    [LineNumberTable(8)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static DefaultErrorReporter()
    {
      if (ByteCodeHelper.isAlreadyInited("rhino.DefaultErrorReporter"))
        return;
      DefaultErrorReporter.instance = new DefaultErrorReporter();
    }
  }
}
