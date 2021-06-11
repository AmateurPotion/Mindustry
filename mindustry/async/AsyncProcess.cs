// Decompiled with JetBrains decompiler
// Type: mindustry.async.AsyncProcess
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.async
{
  public interface AsyncProcess
  {
    [Modifiers]
    void begin();

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static void \u003Cdefault\u003Ebegin([In] AsyncProcess obj0)
    {
    }

    [Modifiers]
    bool shouldProcess();

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static bool \u003Cdefault\u003EshouldProcess([In] AsyncProcess obj0) => true;

    [Modifiers]
    void end();

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static void \u003Cdefault\u003Eend([In] AsyncProcess obj0)
    {
    }

    [Modifiers]
    void reset();

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static void \u003Cdefault\u003Ereset([In] AsyncProcess obj0)
    {
    }

    [Modifiers]
    void init();

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static void \u003Cdefault\u003Einit([In] AsyncProcess obj0)
    {
    }

    [Modifiers]
    void process();

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static void \u003Cdefault\u003Eprocess([In] AsyncProcess obj0)
    {
    }

    [HideFromJava]
    static class __DefaultMethods
    {
      public static void init([In] AsyncProcess obj0)
      {
        AsyncProcess asyncProcess = obj0;
        // ISSUE: virtual method pointer
        IntPtr num = __vmethodptr(asyncProcess, ToString);
        AsyncProcess.\u003Cdefault\u003Einit(asyncProcess);
      }

      public static void reset([In] AsyncProcess obj0)
      {
        AsyncProcess asyncProcess = obj0;
        // ISSUE: virtual method pointer
        IntPtr num = __vmethodptr(asyncProcess, ToString);
        AsyncProcess.\u003Cdefault\u003Ereset(asyncProcess);
      }

      public static void begin([In] AsyncProcess obj0)
      {
        AsyncProcess asyncProcess = obj0;
        // ISSUE: virtual method pointer
        IntPtr num = __vmethodptr(asyncProcess, ToString);
        AsyncProcess.\u003Cdefault\u003Ebegin(asyncProcess);
      }

      public static void process([In] AsyncProcess obj0)
      {
        AsyncProcess asyncProcess = obj0;
        // ISSUE: virtual method pointer
        IntPtr num = __vmethodptr(asyncProcess, ToString);
        AsyncProcess.\u003Cdefault\u003Eprocess(asyncProcess);
      }

      public static void end([In] AsyncProcess obj0)
      {
        AsyncProcess asyncProcess = obj0;
        // ISSUE: virtual method pointer
        IntPtr num = __vmethodptr(asyncProcess, ToString);
        AsyncProcess.\u003Cdefault\u003Eend(asyncProcess);
      }

      public static bool shouldProcess([In] AsyncProcess obj0)
      {
        AsyncProcess asyncProcess = obj0;
        // ISSUE: virtual method pointer
        IntPtr num = __vmethodptr(asyncProcess, ToString);
        return AsyncProcess.\u003Cdefault\u003EshouldProcess(asyncProcess);
      }
    }
  }
}
