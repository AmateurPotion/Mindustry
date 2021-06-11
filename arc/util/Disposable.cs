// Decompiled with JetBrains decompiler
// Type: arc.util.Disposable
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.util
{
  public interface Disposable
  {
    void dispose();

    [Modifiers]
    bool isDisposed();

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static bool \u003Cdefault\u003EisDisposed([In] Disposable obj0) => false;

    [HideFromJava]
    static class __DefaultMethods
    {
      public static bool isDisposed([In] Disposable obj0)
      {
        Disposable disposable = obj0;
        // ISSUE: virtual method pointer
        IntPtr num = __vmethodptr(disposable, ToString);
        return Disposable.\u003Cdefault\u003EisDisposed(disposable);
      }
    }
  }
}
