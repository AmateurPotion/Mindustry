// Decompiled with JetBrains decompiler
// Type: arc.graphics.profiling.GLErrorListener
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.util;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.graphics.profiling
{
  public interface GLErrorListener
  {
    static readonly GLErrorListener LOGGING_LISTENER;
    static readonly GLErrorListener THROWING_LISTENER;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static void __\u003Cclinit\u003E()
    {
    }

    void onError(int i);

    [LineNumberTable(new byte[] {159, 139, 173, 239, 94})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static GLErrorListener()
    {
      if (ByteCodeHelper.isAlreadyInited("arc.graphics.profiling.GLErrorListener"))
        return;
      GLErrorListener.LOGGING_LISTENER = (GLErrorListener) new GLErrorListener.__\u003C\u003EAnon0();
      GLErrorListener.THROWING_LISTENER = (GLErrorListener) new GLErrorListener.__\u003C\u003EAnon1();
    }

    private static class __\u003C\u003EPIM
    {
      [Modifiers]
      [LineNumberTable(new byte[] {159, 158, 130, 107, 103, 116, 103, 102, 103, 226, 59, 249, 74, 34, 161, 99, 125, 159, 9, 127, 2})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal static void lambda\u0024static\u00240([In] int obj0)
      {
        string str1 = (string) null;
        try
        {
          StackTraceElement[] stackTrace = Thread.currentThread().getStackTrace();
          for (int index = 0; index < stackTrace.Length; ++index)
          {
            if (String.instancehelper_equals("check", (object) stackTrace[index].getMethodName()))
            {
              if (index + 1 < stackTrace.Length)
              {
                str1 = stackTrace[index + 1].getMethodName();
                break;
              }
              break;
            }
          }
          goto label_10;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_10:
        if (str1 != null)
        {
          Log.err("[GLProfiler] Error @ from @", (object) GLInterceptor.resolveErrorNumber(obj0), (object) str1);
          string str2 = Strings.format("[GLProfiler] Error @ from @", (object) GLInterceptor.resolveErrorNumber(obj0), (object) str1);
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new RuntimeException(str2);
        }
        Log.err("[GLProfiler] Error @ at: @", (object) GLInterceptor.resolveErrorNumber(obj0), (object) new Exception());
        string str3 = Strings.format("[GLProfiler] Error @", (object) GLInterceptor.resolveErrorNumber(obj0));
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new RuntimeException(str3);
      }

      [Modifiers]
      [LineNumberTable(46)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal static void lambda\u0024static\u00241([In] int obj0)
      {
        string message = new StringBuilder().append("GLProfiler: Got GL error ").append(GLInterceptor.resolveErrorNumber(obj0)).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new ArcRuntimeException(message);
      }
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : GLErrorListener
    {
      internal __\u003C\u003EAnon0()
      {
      }

      public void onError([In] int obj0) => GLErrorListener.__\u003C\u003EPIM.lambda\u0024static\u00240(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : GLErrorListener
    {
      internal __\u003C\u003EAnon1()
      {
      }

      public void onError([In] int obj0) => GLErrorListener.__\u003C\u003EPIM.lambda\u0024static\u00241(obj0);
    }

    [HideFromJava]
    static class __Fields
    {
      public static readonly GLErrorListener LOGGING_LISTENER = GLErrorListener.LOGGING_LISTENER;
      public static readonly GLErrorListener THROWING_LISTENER = GLErrorListener.THROWING_LISTENER;
    }
  }
}
