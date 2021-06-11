// Decompiled with JetBrains decompiler
// Type: arc.input.InputProcessor
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.input
{
  public interface InputProcessor
  {
    [Modifiers]
    void connected(InputDevice device);

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static void \u003Cdefault\u003Econnected([In] InputProcessor obj0, [In] InputDevice obj1)
    {
    }

    [Modifiers]
    void disconnected(InputDevice device);

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static void \u003Cdefault\u003Edisconnected([In] InputProcessor obj0, [In] InputDevice obj1)
    {
    }

    [Modifiers]
    bool keyDown(KeyCode keycode);

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static bool \u003Cdefault\u003EkeyDown([In] InputProcessor obj0, [In] KeyCode obj1) => false;

    [Modifiers]
    bool keyUp(KeyCode keycode);

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static bool \u003Cdefault\u003EkeyUp([In] InputProcessor obj0, [In] KeyCode obj1) => false;

    [Modifiers]
    bool keyTyped(char character);

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static bool \u003Cdefault\u003EkeyTyped([In] InputProcessor obj0, [In] char obj1) => false;

    [Modifiers]
    bool touchDown(int screenX, int screenY, int pointer, KeyCode button);

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static bool \u003Cdefault\u003EtouchDown(
      [In] InputProcessor obj0,
      [In] int obj1,
      [In] int obj2,
      [In] int obj3,
      [In] KeyCode obj4)
    {
      return false;
    }

    [Modifiers]
    bool touchUp(int screenX, int screenY, int pointer, KeyCode button);

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static bool \u003Cdefault\u003EtouchUp(
      [In] InputProcessor obj0,
      [In] int obj1,
      [In] int obj2,
      [In] int obj3,
      [In] KeyCode obj4)
    {
      return false;
    }

    [Modifiers]
    bool touchDragged(int screenX, int screenY, int pointer);

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static bool \u003Cdefault\u003EtouchDragged([In] InputProcessor obj0, [In] int obj1, [In] int obj2, [In] int obj3) => false;

    [Modifiers]
    bool mouseMoved(int screenX, int screenY);

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static bool \u003Cdefault\u003EmouseMoved([In] InputProcessor obj0, [In] int obj1, [In] int obj2) => false;

    [Modifiers]
    bool scrolled(float amountX, float amountY);

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static bool \u003Cdefault\u003Escrolled([In] InputProcessor obj0, [In] float obj1, [In] float obj2) => false;

    [HideFromJava]
    static class __DefaultMethods
    {
      public static void connected([In] InputProcessor obj0, [In] InputDevice obj1)
      {
        InputProcessor nputProcessor = obj0;
        // ISSUE: virtual method pointer
        IntPtr num = __vmethodptr(nputProcessor, ToString);
        InputProcessor.\u003Cdefault\u003Econnected(nputProcessor, obj1);
      }

      public static void disconnected([In] InputProcessor obj0, [In] InputDevice obj1)
      {
        InputProcessor nputProcessor = obj0;
        // ISSUE: virtual method pointer
        IntPtr num = __vmethodptr(nputProcessor, ToString);
        InputProcessor.\u003Cdefault\u003Edisconnected(nputProcessor, obj1);
      }

      public static bool keyDown([In] InputProcessor obj0, [In] KeyCode obj1)
      {
        InputProcessor nputProcessor = obj0;
        // ISSUE: virtual method pointer
        IntPtr num = __vmethodptr(nputProcessor, ToString);
        return InputProcessor.\u003Cdefault\u003EkeyDown(nputProcessor, obj1);
      }

      public static bool keyUp([In] InputProcessor obj0, [In] KeyCode obj1)
      {
        InputProcessor nputProcessor = obj0;
        // ISSUE: virtual method pointer
        IntPtr num = __vmethodptr(nputProcessor, ToString);
        return InputProcessor.\u003Cdefault\u003EkeyUp(nputProcessor, obj1);
      }

      public static bool keyTyped([In] InputProcessor obj0, [In] char obj1)
      {
        InputProcessor nputProcessor = obj0;
        // ISSUE: virtual method pointer
        IntPtr num = __vmethodptr(nputProcessor, ToString);
        return InputProcessor.\u003Cdefault\u003EkeyTyped(nputProcessor, obj1);
      }

      public static bool touchDown(
        [In] InputProcessor obj0,
        [In] int obj1,
        [In] int obj2,
        [In] int obj3,
        [In] KeyCode obj4)
      {
        InputProcessor nputProcessor = obj0;
        // ISSUE: virtual method pointer
        IntPtr num = __vmethodptr(nputProcessor, ToString);
        return InputProcessor.\u003Cdefault\u003EtouchDown(nputProcessor, obj1, obj2, obj3, obj4);
      }

      public static bool touchUp([In] InputProcessor obj0, [In] int obj1, [In] int obj2, [In] int obj3, [In] KeyCode obj4)
      {
        InputProcessor nputProcessor = obj0;
        // ISSUE: virtual method pointer
        IntPtr num = __vmethodptr(nputProcessor, ToString);
        return InputProcessor.\u003Cdefault\u003EtouchUp(nputProcessor, obj1, obj2, obj3, obj4);
      }

      public static bool touchDragged([In] InputProcessor obj0, [In] int obj1, [In] int obj2, [In] int obj3)
      {
        InputProcessor nputProcessor = obj0;
        // ISSUE: virtual method pointer
        IntPtr num = __vmethodptr(nputProcessor, ToString);
        return InputProcessor.\u003Cdefault\u003EtouchDragged(nputProcessor, obj1, obj2, obj3);
      }

      public static bool mouseMoved([In] InputProcessor obj0, [In] int obj1, [In] int obj2)
      {
        InputProcessor nputProcessor = obj0;
        // ISSUE: virtual method pointer
        IntPtr num = __vmethodptr(nputProcessor, ToString);
        return InputProcessor.\u003Cdefault\u003EmouseMoved(nputProcessor, obj1, obj2);
      }

      public static bool scrolled([In] InputProcessor obj0, [In] float obj1, [In] float obj2)
      {
        InputProcessor nputProcessor = obj0;
        // ISSUE: virtual method pointer
        IntPtr num = __vmethodptr(nputProcessor, ToString);
        return InputProcessor.\u003Cdefault\u003Escrolled(nputProcessor, obj1, obj2);
      }
    }
  }
}
