// Decompiled with JetBrains decompiler
// Type: arc.ApplicationListener
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.files;
using IKVM.Attributes;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc
{
  public interface ApplicationListener
  {
    [Modifiers]
    void init();

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static void \u003Cdefault\u003Einit([In] ApplicationListener obj0)
    {
    }

    [Modifiers]
    void resize(int width, int height);

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static void \u003Cdefault\u003Eresize([In] ApplicationListener obj0, [In] int obj1, [In] int obj2)
    {
    }

    [Modifiers]
    void update();

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static void \u003Cdefault\u003Eupdate([In] ApplicationListener obj0)
    {
    }

    [Modifiers]
    void pause();

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static void \u003Cdefault\u003Epause([In] ApplicationListener obj0)
    {
    }

    [Modifiers]
    void resume();

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static void \u003Cdefault\u003Eresume([In] ApplicationListener obj0)
    {
    }

    [Modifiers]
    void dispose();

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static void \u003Cdefault\u003Edispose([In] ApplicationListener obj0)
    {
    }

    [Modifiers]
    void exit();

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static void \u003Cdefault\u003Eexit([In] ApplicationListener obj0)
    {
    }

    [Modifiers]
    void fileDropped(Fi file);

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static void \u003Cdefault\u003EfileDropped([In] ApplicationListener obj0, [In] Fi obj1)
    {
    }

    [HideFromJava]
    static class __DefaultMethods
    {
      public static void init([In] ApplicationListener obj0)
      {
        ApplicationListener applicationListener = obj0;
        // ISSUE: virtual method pointer
        IntPtr num = __vmethodptr(applicationListener, ToString);
        ApplicationListener.\u003Cdefault\u003Einit(applicationListener);
      }

      public static void resize([In] ApplicationListener obj0, [In] int obj1, [In] int obj2)
      {
        ApplicationListener applicationListener = obj0;
        // ISSUE: virtual method pointer
        IntPtr num = __vmethodptr(applicationListener, ToString);
        ApplicationListener.\u003Cdefault\u003Eresize(applicationListener, obj1, obj2);
      }

      public static void update([In] ApplicationListener obj0)
      {
        ApplicationListener applicationListener = obj0;
        // ISSUE: virtual method pointer
        IntPtr num = __vmethodptr(applicationListener, ToString);
        ApplicationListener.\u003Cdefault\u003Eupdate(applicationListener);
      }

      public static void pause([In] ApplicationListener obj0)
      {
        ApplicationListener applicationListener = obj0;
        // ISSUE: virtual method pointer
        IntPtr num = __vmethodptr(applicationListener, ToString);
        ApplicationListener.\u003Cdefault\u003Epause(applicationListener);
      }

      public static void resume([In] ApplicationListener obj0)
      {
        ApplicationListener applicationListener = obj0;
        // ISSUE: virtual method pointer
        IntPtr num = __vmethodptr(applicationListener, ToString);
        ApplicationListener.\u003Cdefault\u003Eresume(applicationListener);
      }

      public static void dispose([In] ApplicationListener obj0)
      {
        ApplicationListener applicationListener = obj0;
        // ISSUE: virtual method pointer
        IntPtr num = __vmethodptr(applicationListener, ToString);
        ApplicationListener.\u003Cdefault\u003Edispose(applicationListener);
      }

      public static void exit([In] ApplicationListener obj0)
      {
        ApplicationListener applicationListener = obj0;
        // ISSUE: virtual method pointer
        IntPtr num = __vmethodptr(applicationListener, ToString);
        ApplicationListener.\u003Cdefault\u003Eexit(applicationListener);
      }

      public static void fileDropped([In] ApplicationListener obj0, [In] Fi obj1)
      {
        ApplicationListener applicationListener = obj0;
        // ISSUE: virtual method pointer
        IntPtr num = __vmethodptr(applicationListener, ToString);
        ApplicationListener.\u003Cdefault\u003EfileDropped(applicationListener, obj1);
      }
    }
  }
}
