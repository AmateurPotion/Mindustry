// Decompiled with JetBrains decompiler
// Type: com.sun.jna.Callback
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using IKVM.Runtime;
using java.util;
using System;
using System.Runtime.CompilerServices;

namespace com.sun.jna
{
  public interface Callback
  {
    const string METHOD_NAME = "callback";
    [Signature("Ljava/util/List<Ljava/lang/String;>;")]
    static readonly List FORBIDDEN_NAMES;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 127, 77, 126, 37})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static Callback()
    {
      if (ByteCodeHelper.isAlreadyInited("com.sun.jna.Callback"))
        return;
      Callback.FORBIDDEN_NAMES = Collections.unmodifiableList(Arrays.asList((object[]) new string[3]
      {
        "hashCode",
        "equals",
        "toString"
      }));
    }

    interface UncaughtExceptionHandler
    {
      void uncaughtException(Callback c, Exception t);
    }

    [HideFromJava]
    static class __Fields
    {
      public const string METHOD_NAME = "callback";
      public static readonly List FORBIDDEN_NAMES = Callback.FORBIDDEN_NAMES;
    }
  }
}
