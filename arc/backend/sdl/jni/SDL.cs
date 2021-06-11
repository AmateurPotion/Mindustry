// Decompiled with JetBrains decompiler
// Type: arc.backend.sdl.jni.SDL
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.util;
using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.io;
using java.lang;
using java.nio;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.backend.sdl.jni
{
  public class SDL : Object
  {
    public const int SDL_INIT_TIMER = 1;
    public const int SDL_INIT_AUDIO = 16;
    public const int SDL_INIT_VIDEO = 32;
    public const int SDL_INIT_JOYSTICK = 512;
    public const int SDL_INIT_HAPTIC = 4096;
    public const int SDL_INIT_GAMECONTROLLER = 8192;
    public const int SDL_INIT_EVENTS = 16384;
    public const int SDL_INIT_NOPARACHUTE = 1048576;
    public const int SDL_INIT_EVERYTHING = 29233;
    public const int SDL_WINDOW_FULLSCREEN = 1;
    public const int SDL_WINDOW_OPENGL = 2;
    public const int SDL_WINDOW_SHOWN = 4;
    public const int SDL_WINDOW_HIDDEN = 8;
    public const int SDL_WINDOW_BORDERLESS = 16;
    public const int SDL_WINDOW_RESIZABLE = 32;
    public const int SDL_WINDOW_MINIMIZED = 64;
    public const int SDL_WINDOW_MAXIMIZED = 128;
    public const int SDL_WINDOW_INPUT_GRABBED = 256;
    public const int SDL_WINDOW_INPUT_FOCUS = 512;
    public const int SDL_WINDOW_MOUSE_FOCUS = 1024;
    public const int SDL_WINDOW_FULLSCREEN_DESKTOP = 4097;
    public const int SDL_WINDOW_FOREIGN = 2048;
    public const int SDL_WINDOW_ALLOW_HIGHDPI = 8192;
    public const int SDL_WINDOW_MOUSE_CAPTURE = 16384;
    public const int SDL_WINDOWEVENT_NONE = 0;
    public const int SDL_WINDOWEVENT_SHOWN = 1;
    public const int SDL_WINDOWEVENT_HIDDEN = 2;
    public const int SDL_WINDOWEVENT_EXPOSED = 3;
    public const int SDL_WINDOWEVENT_MOVED = 4;
    public const int SDL_WINDOWEVENT_RESIZED = 5;
    public const int SDL_WINDOWEVENT_SIZE_CHANGED = 6;
    public const int SDL_WINDOWEVENT_MINIMIZED = 7;
    public const int SDL_WINDOWEVENT_MAXIMIZED = 8;
    public const int SDL_WINDOWEVENT_RESTORED = 9;
    public const int SDL_WINDOWEVENT_ENTER = 10;
    public const int SDL_WINDOWEVENT_LEAVE = 11;
    public const int SDL_WINDOWEVENT_FOCUS_GAINED = 12;
    public const int SDL_WINDOWEVENT_FOCUS_LOST = 13;
    public const int SDL_WINDOWEVENT_CLOSE = 14;
    public const int SDL_SYSTEM_CURSOR_ARROW = 0;
    public const int SDL_SYSTEM_CURSOR_IBEAM = 1;
    public const int SDL_SYSTEM_CURSOR_WAIT = 2;
    public const int SDL_SYSTEM_CURSOR_CROSSHAIR = 3;
    public const int SDL_SYSTEM_CURSOR_WAITARROW = 4;
    public const int SDL_SYSTEM_CURSOR_SIZENWSE = 5;
    public const int SDL_SYSTEM_CURSOR_SIZENESW = 6;
    public const int SDL_SYSTEM_CURSOR_SIZEWE = 7;
    public const int SDL_SYSTEM_CURSOR_SIZENS = 8;
    public const int SDL_SYSTEM_CURSOR_SIZEALL = 9;
    public const int SDL_SYSTEM_CURSOR_NO = 10;
    public const int SDL_SYSTEM_CURSOR_HAND = 11;
    public const int SDL_NUM_SYSTEM_CURSORS = 12;
    public const int SDL_MESSAGEBOX_ERROR = 16;
    public const int SDL_MESSAGEBOX_WARNING = 32;
    public const int SDL_MESSAGEBOX_INFORMATION = 64;
    public const int SDL_BUTTON_LEFT = 1;
    public const int SDL_BUTTON_MIDDLE = 2;
    public const int SDL_BUTTON_RIGHT = 3;
    public const int SDL_BUTTON_X1 = 4;
    public const int SDL_BUTTON_X2 = 5;
    public const int SDL_EVENT_QUIT = 0;
    public const int SDL_EVENT_WINDOW = 1;
    public const int SDL_EVENT_MOUSE_MOTION = 2;
    public const int SDL_EVENT_MOUSE_BUTTON = 3;
    public const int SDL_EVENT_MOUSE_WHEEL = 4;
    public const int SDL_EVENT_KEYBOARD = 5;
    public const int SDL_EVENT_TEXT_INPUT = 6;
    public const int SDL_EVENT_OTHER = 7;
    public const int SDL_GL_RED_SIZE = 0;
    public const int SDL_GL_GREEN_SIZE = 1;
    public const int SDL_GL_BLUE_SIZE = 2;
    public const int SDL_GL_ALPHA_SIZE = 3;
    public const int SDL_GL_BUFFER_SIZE = 4;
    public const int SDL_GL_DOUBLEBUFFER = 5;
    public const int SDL_GL_DEPTH_SIZE = 6;
    public const int SDL_GL_STENCIL_SIZE = 7;
    public const int SDL_GL_CONTEXT_MAJOR_VERSION = 17;
    public const int SDL_GL_CONTEXT_MINOR_VERSION = 18;
    public const int SDL_GL_MULTISAMPLEBUFFERS = 13;
    public const int SDL_GL_MULTISAMPLESAMPLES = 14;
    public const int SDL_GL_CONTEXT_PROFILE_CORE = 1;
    public const int SDL_GL_CONTEXT_PROFILE_MASK = 21;
    public const int SDL_GL_CONTEXT_FLAGS = 20;
    static IntPtr __\u003Cjniptr\u003ESDL_Init\u0028I\u0029I;
    [SpecialName]
    private static CallerID __\u003CcallerID\u003E;
    static IntPtr __\u003Cjniptr\u003ESDL_InitSubSystem\u0028I\u0029I;
    static IntPtr __\u003Cjniptr\u003ESDL_QuitSubSystem\u0028I\u0029V;
    static IntPtr __\u003Cjniptr\u003ESDL_WasInit\u0028I\u0029I;
    static IntPtr __\u003Cjniptr\u003ESDL_Quit\u0028\u0029V;
    static IntPtr __\u003Cjniptr\u003ESDL_SetHint\u0028Ljava\u002Flang\u002FString\u003BLjava\u002Flang\u002FString\u003B\u0029Z;
    static IntPtr __\u003Cjniptr\u003ESDL_GetError\u0028\u0029Ljava\u002Flang\u002FString\u003B;
    static IntPtr __\u003Cjniptr\u003ESDL_SetClipboardText\u0028Ljava\u002Flang\u002FString\u003B\u0029I;
    static IntPtr __\u003Cjniptr\u003ESDL_GetClipboardText\u0028\u0029Ljava\u002Flang\u002FString\u003B;
    static IntPtr __\u003Cjniptr\u003ESDL_CreateWindow\u0028Ljava\u002Flang\u002FString\u003BIII\u0029J;
    static IntPtr __\u003Cjniptr\u003ESDL_DestroyWindow\u0028J\u0029V;
    static IntPtr __\u003Cjniptr\u003ESDL_SetWindowIcon\u0028JJ\u0029V;
    static IntPtr __\u003Cjniptr\u003ESDL_RestoreWindow\u0028J\u0029V;
    static IntPtr __\u003Cjniptr\u003ESDL_MaximizeWindow\u0028J\u0029V;
    static IntPtr __\u003Cjniptr\u003ESDL_MinimizeWindow\u0028J\u0029V;
    static IntPtr __\u003Cjniptr\u003ESDL_SetWindowFullscreen\u0028JI\u0029I;
    static IntPtr __\u003Cjniptr\u003ESDL_SetWindowBordered\u0028JZ\u0029V;
    static IntPtr __\u003Cjniptr\u003ESDL_SetWindowSize\u0028JII\u0029V;
    static IntPtr __\u003Cjniptr\u003ESDL_GetWindowFlags\u0028J\u0029I;
    static IntPtr __\u003Cjniptr\u003ESDL_SetWindowTitle\u0028JLjava\u002Flang\u002FString\u003B\u0029V;
    static IntPtr __\u003Cjniptr\u003ESDL_CreateRGBSurfaceFrom\u0028Ljava\u002Fnio\u002FByteBuffer\u003BII\u0029J;
    static IntPtr __\u003Cjniptr\u003ESDL_CreateColorCursor\u0028JII\u0029J;
    static IntPtr __\u003Cjniptr\u003ESDL_CreateSystemCursor\u0028I\u0029J;
    static IntPtr __\u003Cjniptr\u003ESDL_SetCursor\u0028J\u0029V;
    static IntPtr __\u003Cjniptr\u003ESDL_FreeCursor\u0028J\u0029V;
    static IntPtr __\u003Cjniptr\u003ESDL_FreeSurface\u0028J\u0029V;
    static IntPtr __\u003Cjniptr\u003ESDL_ShowSimpleMessageBox\u0028ILjava\u002Flang\u002FString\u003BLjava\u002Flang\u002FString\u003B\u0029I;
    static IntPtr __\u003Cjniptr\u003ESDL_StartTextInput\u0028\u0029V;
    static IntPtr __\u003Cjniptr\u003ESDL_StopTextInput\u0028\u0029V;
    static IntPtr __\u003Cjniptr\u003ESDL_PollEvent\u0028\u005BI\u0029Z;
    static IntPtr __\u003Cjniptr\u003ESDL_GL_SetAttribute\u0028II\u0029I;
    static IntPtr __\u003Cjniptr\u003ESDL_GL_ExtensionSupported\u0028Ljava\u002Flang\u002FString\u003B\u0029Z;
    static IntPtr __\u003Cjniptr\u003ESDL_GL_CreateContext\u0028J\u0029J;
    static IntPtr __\u003Cjniptr\u003ESDL_GL_SetSwapInterval\u0028I\u0029I;
    static IntPtr __\u003Cjniptr\u003ESDL_GL_SwapWindow\u0028J\u0029V;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [Modifiers]
    public static int SDL_ShowSimpleMessageBox(int i, string str1, string str2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDL.__\u003Cjniptr\u003ESDL_ShowSimpleMessageBox\u0028ILjava\u002Flang\u002FString\u003BLjava\u002Flang\u002FString\u003B\u0029I == IntPtr.Zero)
        SDL.__\u003Cjniptr\u003ESDL_ShowSimpleMessageBox\u0028ILjava\u002Flang\u002FString\u003BLjava\u002Flang\u002FString\u003B\u0029I = JNI.Frame.GetFuncPtr(SDL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDL", nameof (SDL_ShowSimpleMessageBox), "(ILjava/lang/String;Ljava/lang/String;)I");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDL>.Value);
        int num4 = i;
        IntPtr num5 = ((JNI.Frame) ref frame).MakeLocalRef((object) str1);
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) str2);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<int (IntPtr, IntPtr, int, IntPtr, IntPtr)>) SDL.__\u003Cjniptr\u003ESDL_ShowSimpleMessageBox\u0028ILjava\u002Flang\u002FString\u003BLjava\u002Flang\u002FString\u003B\u0029I)(num2, num3, num4, num5, num6);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static string SDL_GetError()
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDL.__\u003Cjniptr\u003ESDL_GetError\u0028\u0029Ljava\u002Flang\u002FString\u003B == IntPtr.Zero)
        SDL.__\u003Cjniptr\u003ESDL_GetError\u0028\u0029Ljava\u002Flang\u002FString\u003B = JNI.Frame.GetFuncPtr(SDL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDL", nameof (SDL_GetError), "()Ljava/lang/String;");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDL.__\u003CGetCallerID\u003E());
      try
      {
        ref JNI.Frame local = ref frame;
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDL>.Value);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        IntPtr num4 = __calli((__FnPtr<IntPtr (IntPtr, IntPtr)>) SDL.__\u003Cjniptr\u003ESDL_GetError\u0028\u0029Ljava\u002Flang\u002FString\u003B)(num2, num3);
        return (string) ((JNI.Frame) ref local).UnwrapLocalRef(num4);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static long SDL_CreateRGBSurfaceFrom(ByteBuffer bb, int i1, int i2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDL.__\u003Cjniptr\u003ESDL_CreateRGBSurfaceFrom\u0028Ljava\u002Fnio\u002FByteBuffer\u003BII\u0029J == IntPtr.Zero)
        SDL.__\u003Cjniptr\u003ESDL_CreateRGBSurfaceFrom\u0028Ljava\u002Fnio\u002FByteBuffer\u003BII\u0029J = JNI.Frame.GetFuncPtr(SDL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDL", nameof (SDL_CreateRGBSurfaceFrom), "(Ljava/nio/ByteBuffer;II)J");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDL>.Value);
        IntPtr num4 = ((JNI.Frame) ref frame).MakeLocalRef((object) bb);
        int num5 = i1;
        int num6 = i2;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<long (IntPtr, IntPtr, IntPtr, int, int)>) SDL.__\u003Cjniptr\u003ESDL_CreateRGBSurfaceFrom\u0028Ljava\u002Fnio\u002FByteBuffer\u003BII\u0029J)((int) num2, (int) num3, num4, (IntPtr) num5, (IntPtr) num6);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void SDL_SetWindowIcon(long l1, long l2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDL.__\u003Cjniptr\u003ESDL_SetWindowIcon\u0028JJ\u0029V == IntPtr.Zero)
        SDL.__\u003Cjniptr\u003ESDL_SetWindowIcon\u0028JJ\u0029V = JNI.Frame.GetFuncPtr(SDL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDL", nameof (SDL_SetWindowIcon), "(JJ)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDL>.Value);
        long num4 = l1;
        long num5 = l2;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, long, long)>) SDL.__\u003Cjniptr\u003ESDL_SetWindowIcon\u0028JJ\u0029V)((long) num2, (long) num3, (IntPtr) num4, (IntPtr) num5);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void SDL_FreeSurface(long l)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDL.__\u003Cjniptr\u003ESDL_FreeSurface\u0028J\u0029V == IntPtr.Zero)
        SDL.__\u003Cjniptr\u003ESDL_FreeSurface\u0028J\u0029V = JNI.Frame.GetFuncPtr(SDL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDL", nameof (SDL_FreeSurface), "(J)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDL>.Value);
        long num4 = l;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, long)>) SDL.__\u003Cjniptr\u003ESDL_FreeSurface\u0028J\u0029V)((long) num2, num3, (IntPtr) num4);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static long SDL_CreateWindow(string str, int i1, int i2, int i3)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDL.__\u003Cjniptr\u003ESDL_CreateWindow\u0028Ljava\u002Flang\u002FString\u003BIII\u0029J == IntPtr.Zero)
        SDL.__\u003Cjniptr\u003ESDL_CreateWindow\u0028Ljava\u002Flang\u002FString\u003BIII\u0029J = JNI.Frame.GetFuncPtr(SDL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDL", nameof (SDL_CreateWindow), "(Ljava/lang/String;III)J");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDL>.Value);
        IntPtr num4 = ((JNI.Frame) ref frame).MakeLocalRef((object) str);
        int num5 = i1;
        int num6 = i2;
        int num7 = i3;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<long (IntPtr, IntPtr, IntPtr, int, int, int)>) SDL.__\u003Cjniptr\u003ESDL_CreateWindow\u0028Ljava\u002Flang\u002FString\u003BIII\u0029J)((int) num2, (int) num3, (int) num4, (IntPtr) num5, (IntPtr) num6, (IntPtr) num7);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static long SDL_GL_CreateContext(long l)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDL.__\u003Cjniptr\u003ESDL_GL_CreateContext\u0028J\u0029J == IntPtr.Zero)
        SDL.__\u003Cjniptr\u003ESDL_GL_CreateContext\u0028J\u0029J = JNI.Frame.GetFuncPtr(SDL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDL", nameof (SDL_GL_CreateContext), "(J)J");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDL>.Value);
        long num4 = l;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<long (IntPtr, IntPtr, long)>) SDL.__\u003Cjniptr\u003ESDL_GL_CreateContext\u0028J\u0029J)((long) num2, num3, (IntPtr) num4);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static int SDL_GL_SetSwapInterval(int i)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDL.__\u003Cjniptr\u003ESDL_GL_SetSwapInterval\u0028I\u0029I == IntPtr.Zero)
        SDL.__\u003Cjniptr\u003ESDL_GL_SetSwapInterval\u0028I\u0029I = JNI.Frame.GetFuncPtr(SDL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDL", nameof (SDL_GL_SetSwapInterval), "(I)I");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDL>.Value);
        int num4 = i;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<int (IntPtr, IntPtr, int)>) SDL.__\u003Cjniptr\u003ESDL_GL_SetSwapInterval\u0028I\u0029I)((int) num2, num3, (IntPtr) num4);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void SDL_StartTextInput()
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDL.__\u003Cjniptr\u003ESDL_StartTextInput\u0028\u0029V == IntPtr.Zero)
        SDL.__\u003Cjniptr\u003ESDL_StartTextInput\u0028\u0029V = JNI.Frame.GetFuncPtr(SDL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDL", nameof (SDL_StartTextInput), "()V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDL>.Value);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr)>) SDL.__\u003Cjniptr\u003ESDL_StartTextInput\u0028\u0029V)(num2, num3);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static bool SDL_PollEvent(int[] iarr)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDL.__\u003Cjniptr\u003ESDL_PollEvent\u0028\u005BI\u0029Z == IntPtr.Zero)
        SDL.__\u003Cjniptr\u003ESDL_PollEvent\u0028\u005BI\u0029Z = JNI.Frame.GetFuncPtr(SDL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDL", nameof (SDL_PollEvent), "([I)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDL>.Value);
        IntPtr num4 = ((JNI.Frame) ref frame).MakeLocalRef((object) iarr);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, IntPtr)>) SDL.__\u003Cjniptr\u003ESDL_PollEvent\u0028\u005BI\u0029Z)(num2, num3, num4);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void SDL_GL_SwapWindow(long l)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDL.__\u003Cjniptr\u003ESDL_GL_SwapWindow\u0028J\u0029V == IntPtr.Zero)
        SDL.__\u003Cjniptr\u003ESDL_GL_SwapWindow\u0028J\u0029V = JNI.Frame.GetFuncPtr(SDL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDL", nameof (SDL_GL_SwapWindow), "(J)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDL>.Value);
        long num4 = l;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, long)>) SDL.__\u003Cjniptr\u003ESDL_GL_SwapWindow\u0028J\u0029V)((long) num2, num3, (IntPtr) num4);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void SDL_DestroyWindow(long l)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDL.__\u003Cjniptr\u003ESDL_DestroyWindow\u0028J\u0029V == IntPtr.Zero)
        SDL.__\u003Cjniptr\u003ESDL_DestroyWindow\u0028J\u0029V = JNI.Frame.GetFuncPtr(SDL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDL", nameof (SDL_DestroyWindow), "(J)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDL>.Value);
        long num4 = l;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, long)>) SDL.__\u003Cjniptr\u003ESDL_DestroyWindow\u0028J\u0029V)((long) num2, num3, (IntPtr) num4);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void SDL_Quit()
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDL.__\u003Cjniptr\u003ESDL_Quit\u0028\u0029V == IntPtr.Zero)
        SDL.__\u003Cjniptr\u003ESDL_Quit\u0028\u0029V = JNI.Frame.GetFuncPtr(SDL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDL", nameof (SDL_Quit), "()V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDL>.Value);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr)>) SDL.__\u003Cjniptr\u003ESDL_Quit\u0028\u0029V)(num2, num3);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static string SDL_GetClipboardText()
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDL.__\u003Cjniptr\u003ESDL_GetClipboardText\u0028\u0029Ljava\u002Flang\u002FString\u003B == IntPtr.Zero)
        SDL.__\u003Cjniptr\u003ESDL_GetClipboardText\u0028\u0029Ljava\u002Flang\u002FString\u003B = JNI.Frame.GetFuncPtr(SDL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDL", nameof (SDL_GetClipboardText), "()Ljava/lang/String;");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDL.__\u003CGetCallerID\u003E());
      try
      {
        ref JNI.Frame local = ref frame;
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDL>.Value);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        IntPtr num4 = __calli((__FnPtr<IntPtr (IntPtr, IntPtr)>) SDL.__\u003Cjniptr\u003ESDL_GetClipboardText\u0028\u0029Ljava\u002Flang\u002FString\u003B)(num2, num3);
        return (string) ((JNI.Frame) ref local).UnwrapLocalRef(num4);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static int SDL_SetClipboardText(string str)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDL.__\u003Cjniptr\u003ESDL_SetClipboardText\u0028Ljava\u002Flang\u002FString\u003B\u0029I == IntPtr.Zero)
        SDL.__\u003Cjniptr\u003ESDL_SetClipboardText\u0028Ljava\u002Flang\u002FString\u003B\u0029I = JNI.Frame.GetFuncPtr(SDL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDL", nameof (SDL_SetClipboardText), "(Ljava/lang/String;)I");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDL>.Value);
        IntPtr num4 = ((JNI.Frame) ref frame).MakeLocalRef((object) str);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<int (IntPtr, IntPtr, IntPtr)>) SDL.__\u003Cjniptr\u003ESDL_SetClipboardText\u0028Ljava\u002Flang\u002FString\u003B\u0029I)(num2, num3, num4);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static int SDL_GL_SetAttribute(int i1, int i2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDL.__\u003Cjniptr\u003ESDL_GL_SetAttribute\u0028II\u0029I == IntPtr.Zero)
        SDL.__\u003Cjniptr\u003ESDL_GL_SetAttribute\u0028II\u0029I = JNI.Frame.GetFuncPtr(SDL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDL", nameof (SDL_GL_SetAttribute), "(II)I");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDL>.Value);
        int num4 = i1;
        int num5 = i2;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<int (IntPtr, IntPtr, int, int)>) SDL.__\u003Cjniptr\u003ESDL_GL_SetAttribute\u0028II\u0029I)((int) num2, (int) num3, (IntPtr) num4, (IntPtr) num5);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static int SDL_Init(int i)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDL.__\u003Cjniptr\u003ESDL_Init\u0028I\u0029I == IntPtr.Zero)
        SDL.__\u003Cjniptr\u003ESDL_Init\u0028I\u0029I = JNI.Frame.GetFuncPtr(SDL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDL", nameof (SDL_Init), "(I)I");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDL>.Value);
        int num4 = i;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<int (IntPtr, IntPtr, int)>) SDL.__\u003Cjniptr\u003ESDL_Init\u0028I\u0029I)((int) num2, num3, (IntPtr) num4);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static bool SDL_GL_ExtensionSupported(string str)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDL.__\u003Cjniptr\u003ESDL_GL_ExtensionSupported\u0028Ljava\u002Flang\u002FString\u003B\u0029Z == IntPtr.Zero)
        SDL.__\u003Cjniptr\u003ESDL_GL_ExtensionSupported\u0028Ljava\u002Flang\u002FString\u003B\u0029Z = JNI.Frame.GetFuncPtr(SDL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDL", nameof (SDL_GL_ExtensionSupported), "(Ljava/lang/String;)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDL>.Value);
        IntPtr num4 = ((JNI.Frame) ref frame).MakeLocalRef((object) str);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, IntPtr)>) SDL.__\u003Cjniptr\u003ESDL_GL_ExtensionSupported\u0028Ljava\u002Flang\u002FString\u003B\u0029Z)(num2, num3, num4);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static int SDL_SetWindowFullscreen(long l, int i)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDL.__\u003Cjniptr\u003ESDL_SetWindowFullscreen\u0028JI\u0029I == IntPtr.Zero)
        SDL.__\u003Cjniptr\u003ESDL_SetWindowFullscreen\u0028JI\u0029I = JNI.Frame.GetFuncPtr(SDL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDL", nameof (SDL_SetWindowFullscreen), "(JI)I");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDL>.Value);
        long num4 = l;
        int num5 = i;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<int (IntPtr, IntPtr, long, int)>) SDL.__\u003Cjniptr\u003ESDL_SetWindowFullscreen\u0028JI\u0029I)((int) num2, (long) num3, (IntPtr) num4, (IntPtr) num5);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void SDL_SetWindowSize(long l, int i1, int i2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDL.__\u003Cjniptr\u003ESDL_SetWindowSize\u0028JII\u0029V == IntPtr.Zero)
        SDL.__\u003Cjniptr\u003ESDL_SetWindowSize\u0028JII\u0029V = JNI.Frame.GetFuncPtr(SDL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDL", nameof (SDL_SetWindowSize), "(JII)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDL>.Value);
        long num4 = l;
        int num5 = i1;
        int num6 = i2;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, long, int, int)>) SDL.__\u003Cjniptr\u003ESDL_SetWindowSize\u0028JII\u0029V)((int) num2, (int) num3, num4, (IntPtr) num5, (IntPtr) num6);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void SDL_SetWindowTitle(long l, string str)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDL.__\u003Cjniptr\u003ESDL_SetWindowTitle\u0028JLjava\u002Flang\u002FString\u003B\u0029V == IntPtr.Zero)
        SDL.__\u003Cjniptr\u003ESDL_SetWindowTitle\u0028JLjava\u002Flang\u002FString\u003B\u0029V = JNI.Frame.GetFuncPtr(SDL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDL", nameof (SDL_SetWindowTitle), "(JLjava/lang/String;)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDL>.Value);
        long num4 = l;
        IntPtr num5 = ((JNI.Frame) ref frame).MakeLocalRef((object) str);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, long, IntPtr)>) SDL.__\u003Cjniptr\u003ESDL_SetWindowTitle\u0028JLjava\u002Flang\u002FString\u003B\u0029V)(num2, (long) num3, (IntPtr) num4, num5);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static int SDL_GetWindowFlags(long l)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDL.__\u003Cjniptr\u003ESDL_GetWindowFlags\u0028J\u0029I == IntPtr.Zero)
        SDL.__\u003Cjniptr\u003ESDL_GetWindowFlags\u0028J\u0029I = JNI.Frame.GetFuncPtr(SDL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDL", nameof (SDL_GetWindowFlags), "(J)I");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDL>.Value);
        long num4 = l;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<int (IntPtr, IntPtr, long)>) SDL.__\u003Cjniptr\u003ESDL_GetWindowFlags\u0028J\u0029I)((long) num2, num3, (IntPtr) num4);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void SDL_RestoreWindow(long l)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDL.__\u003Cjniptr\u003ESDL_RestoreWindow\u0028J\u0029V == IntPtr.Zero)
        SDL.__\u003Cjniptr\u003ESDL_RestoreWindow\u0028J\u0029V = JNI.Frame.GetFuncPtr(SDL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDL", nameof (SDL_RestoreWindow), "(J)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDL>.Value);
        long num4 = l;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, long)>) SDL.__\u003Cjniptr\u003ESDL_RestoreWindow\u0028J\u0029V)((long) num2, num3, (IntPtr) num4);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void SDL_SetWindowBordered(long l, bool b)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDL.__\u003Cjniptr\u003ESDL_SetWindowBordered\u0028JZ\u0029V == IntPtr.Zero)
        SDL.__\u003Cjniptr\u003ESDL_SetWindowBordered\u0028JZ\u0029V = JNI.Frame.GetFuncPtr(SDL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDL", nameof (SDL_SetWindowBordered), "(JZ)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDL>.Value);
        long num4 = l;
        int num5 = b ? 1 : 0;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, long, bool)>) SDL.__\u003Cjniptr\u003ESDL_SetWindowBordered\u0028JZ\u0029V)((bool) num2, (long) num3, (IntPtr) num4, (IntPtr) num5);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void SDL_MaximizeWindow(long l)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDL.__\u003Cjniptr\u003ESDL_MaximizeWindow\u0028J\u0029V == IntPtr.Zero)
        SDL.__\u003Cjniptr\u003ESDL_MaximizeWindow\u0028J\u0029V = JNI.Frame.GetFuncPtr(SDL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDL", nameof (SDL_MaximizeWindow), "(J)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDL>.Value);
        long num4 = l;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, long)>) SDL.__\u003Cjniptr\u003ESDL_MaximizeWindow\u0028J\u0029V)((long) num2, num3, (IntPtr) num4);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static long SDL_CreateColorCursor(long l, int i1, int i2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDL.__\u003Cjniptr\u003ESDL_CreateColorCursor\u0028JII\u0029J == IntPtr.Zero)
        SDL.__\u003Cjniptr\u003ESDL_CreateColorCursor\u0028JII\u0029J = JNI.Frame.GetFuncPtr(SDL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDL", nameof (SDL_CreateColorCursor), "(JII)J");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDL>.Value);
        long num4 = l;
        int num5 = i1;
        int num6 = i2;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<long (IntPtr, IntPtr, long, int, int)>) SDL.__\u003Cjniptr\u003ESDL_CreateColorCursor\u0028JII\u0029J)((int) num2, (int) num3, num4, (IntPtr) num5, (IntPtr) num6);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void SDL_SetCursor(long l)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDL.__\u003Cjniptr\u003ESDL_SetCursor\u0028J\u0029V == IntPtr.Zero)
        SDL.__\u003Cjniptr\u003ESDL_SetCursor\u0028J\u0029V = JNI.Frame.GetFuncPtr(SDL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDL", nameof (SDL_SetCursor), "(J)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDL>.Value);
        long num4 = l;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, long)>) SDL.__\u003Cjniptr\u003ESDL_SetCursor\u0028J\u0029V)((long) num2, num3, (IntPtr) num4);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static long SDL_CreateSystemCursor(int i)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDL.__\u003Cjniptr\u003ESDL_CreateSystemCursor\u0028I\u0029J == IntPtr.Zero)
        SDL.__\u003Cjniptr\u003ESDL_CreateSystemCursor\u0028I\u0029J = JNI.Frame.GetFuncPtr(SDL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDL", nameof (SDL_CreateSystemCursor), "(I)J");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDL>.Value);
        int num4 = i;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<long (IntPtr, IntPtr, int)>) SDL.__\u003Cjniptr\u003ESDL_CreateSystemCursor\u0028I\u0029J)((int) num2, num3, (IntPtr) num4);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void SDL_FreeCursor(long l)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDL.__\u003Cjniptr\u003ESDL_FreeCursor\u0028J\u0029V == IntPtr.Zero)
        SDL.__\u003Cjniptr\u003ESDL_FreeCursor\u0028J\u0029V = JNI.Frame.GetFuncPtr(SDL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDL", nameof (SDL_FreeCursor), "(J)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDL>.Value);
        long num4 = l;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, long)>) SDL.__\u003Cjniptr\u003ESDL_FreeCursor\u0028J\u0029V)((long) num2, num3, (IntPtr) num4);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [LineNumberTable(8)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public SDL()
    {
    }

    [Modifiers]
    public static int SDL_InitSubSystem(int i)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDL.__\u003Cjniptr\u003ESDL_InitSubSystem\u0028I\u0029I == IntPtr.Zero)
        SDL.__\u003Cjniptr\u003ESDL_InitSubSystem\u0028I\u0029I = JNI.Frame.GetFuncPtr(SDL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDL", nameof (SDL_InitSubSystem), "(I)I");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDL>.Value);
        int num4 = i;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<int (IntPtr, IntPtr, int)>) SDL.__\u003Cjniptr\u003ESDL_InitSubSystem\u0028I\u0029I)((int) num2, num3, (IntPtr) num4);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void SDL_QuitSubSystem(int i)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDL.__\u003Cjniptr\u003ESDL_QuitSubSystem\u0028I\u0029V == IntPtr.Zero)
        SDL.__\u003Cjniptr\u003ESDL_QuitSubSystem\u0028I\u0029V = JNI.Frame.GetFuncPtr(SDL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDL", nameof (SDL_QuitSubSystem), "(I)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDL>.Value);
        int num4 = i;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int)>) SDL.__\u003Cjniptr\u003ESDL_QuitSubSystem\u0028I\u0029V)((int) num2, num3, (IntPtr) num4);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static int SDL_WasInit(int i)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDL.__\u003Cjniptr\u003ESDL_WasInit\u0028I\u0029I == IntPtr.Zero)
        SDL.__\u003Cjniptr\u003ESDL_WasInit\u0028I\u0029I = JNI.Frame.GetFuncPtr(SDL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDL", nameof (SDL_WasInit), "(I)I");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDL>.Value);
        int num4 = i;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<int (IntPtr, IntPtr, int)>) SDL.__\u003Cjniptr\u003ESDL_WasInit\u0028I\u0029I)((int) num2, num3, (IntPtr) num4);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static bool SDL_SetHint(string str1, string str2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDL.__\u003Cjniptr\u003ESDL_SetHint\u0028Ljava\u002Flang\u002FString\u003BLjava\u002Flang\u002FString\u003B\u0029Z == IntPtr.Zero)
        SDL.__\u003Cjniptr\u003ESDL_SetHint\u0028Ljava\u002Flang\u002FString\u003BLjava\u002Flang\u002FString\u003B\u0029Z = JNI.Frame.GetFuncPtr(SDL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDL", nameof (SDL_SetHint), "(Ljava/lang/String;Ljava/lang/String;)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDL>.Value);
        IntPtr num4 = ((JNI.Frame) ref frame).MakeLocalRef((object) str1);
        IntPtr num5 = ((JNI.Frame) ref frame).MakeLocalRef((object) str2);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, IntPtr, IntPtr)>) SDL.__\u003Cjniptr\u003ESDL_SetHint\u0028Ljava\u002Flang\u002FString\u003BLjava\u002Flang\u002FString\u003B\u0029Z)(num2, num3, num4, num5);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void SDL_MinimizeWindow(long l)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDL.__\u003Cjniptr\u003ESDL_MinimizeWindow\u0028J\u0029V == IntPtr.Zero)
        SDL.__\u003Cjniptr\u003ESDL_MinimizeWindow\u0028J\u0029V = JNI.Frame.GetFuncPtr(SDL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDL", nameof (SDL_MinimizeWindow), "(J)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDL>.Value);
        long num4 = l;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, long)>) SDL.__\u003Cjniptr\u003ESDL_MinimizeWindow\u0028J\u0029V)((long) num2, num3, (IntPtr) num4);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void SDL_StopTextInput()
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDL.__\u003Cjniptr\u003ESDL_StopTextInput\u0028\u0029V == IntPtr.Zero)
        SDL.__\u003Cjniptr\u003ESDL_StopTextInput\u0028\u0029V = JNI.Frame.GetFuncPtr(SDL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDL", nameof (SDL_StopTextInput), "()V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDL>.Value);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr)>) SDL.__\u003Cjniptr\u003ESDL_StopTextInput\u0028\u0029V)(num2, num3);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [LineNumberTable(new byte[] {159, 112, 109, 103, 234, 74, 103, 103, 138, 133, 234, 76, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static SDL()
    {
      if (ByteCodeHelper.isAlreadyInited("arc.backend.sdl.jni.SDL"))
        return;
      if (OS.isWindows)
        new SDL.\u0031().load("OpenAL32");
      else if (OS.isLinux)
        new SDL.\u0032().load("openal");
      new SDL.\u0033().load("sdl-arc");
    }

    static CallerID __\u003CGetCallerID\u003E()
    {
      if (SDL.__\u003CcallerID\u003E == null)
        SDL.__\u003CcallerID\u003E = (CallerID) new SDL.__\u003CCallerID\u003E();
      return SDL.__\u003CcallerID\u003E;
    }

    [InnerClass]
    [EnclosingMethod(null, null, null)]
    [SpecialName]
    internal class \u0031 : SharedLibraryLoader
    {
      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(122)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0031()
      {
      }

      [LineNumberTable(125)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override string mapLibraryName([In] string obj0) => new StringBuilder().append(obj0).append(".dll").toString();

      [LineNumberTable(130)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      protected internal override InputStream readFile([In] string obj0) => base.readFile(!OS.is64Bit ? "OpenAL32.dll" : "OpenAL.dll");

      [HideFromJava]
      static \u0031() => SharedLibraryLoader.__\u003Cclinit\u003E();
    }

    [InnerClass]
    [EnclosingMethod(null, null, null)]
    [SpecialName]
    internal class \u0032 : SharedLibraryLoader
    {
      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(134)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0032()
      {
      }

      [LineNumberTable(135)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override string mapLibraryName([In] string obj0) => new StringBuilder().append("lib").append(obj0).append(".so").toString();

      [HideFromJava]
      static \u0032() => SharedLibraryLoader.__\u003Cclinit\u003E();
    }

    [InnerClass]
    [EnclosingMethod(null, null, null)]
    [SpecialName]
    internal class \u0033 : SharedLibraryLoader
    {
      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(138)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0033()
      {
      }

      [LineNumberTable(new byte[] {91, 138, 122, 63, 20, 183, 34, 161})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      protected internal override Exception loadFile([In] string obj0, [In] string obj1, [In] File obj2)
      {
        if (OS.isWindows)
        {
          try
          {
            string sourcePath = !OS.is64Bit ? "OpenAL32.dll" : "OpenAL.dll";
            string sourceCrc = obj1;
            File.__\u003Cclinit\u003E();
            File extractedFile = new File(obj2.getParentFile() != null ? new StringBuilder().append((object) obj2.getParentFile()).append("/OpenAL32.dll").toString() : "OpenAL32.dll");
            this.extractFile(sourcePath, sourceCrc, extractedFile);
            goto label_4;
          }
          catch (Exception ex)
          {
            ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 2);
          }
        }
label_4:
        return base.loadFile(obj0, obj1, obj2);
      }

      [HideFromJava]
      static \u0033() => SharedLibraryLoader.__\u003Cclinit\u003E();
    }

    private sealed class __\u003CCallerID\u003E : CallerID
    {
      internal __\u003CCallerID\u003E()
      {
      }
    }
  }
}
