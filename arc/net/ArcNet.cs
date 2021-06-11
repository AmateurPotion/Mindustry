// Decompiled with JetBrains decompiler
// Type: arc.net.ArcNet
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.func;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.net
{
  public class ArcNet : Object
  {
    [Signature("Larc/func/Cons<Ljava/lang/Throwable;>;")]
    public static Cons errorHandler;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u00240([In] Exception obj0)
    {
    }

    [LineNumberTable(5)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ArcNet()
    {
    }

    [LineNumberTable(new byte[] {159, 151, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void handleError(Exception e) => ArcNet.errorHandler.get((object) e);

    [LineNumberTable(6)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static ArcNet()
    {
      if (ByteCodeHelper.isAlreadyInited("arc.net.ArcNet"))
        return;
      ArcNet.errorHandler = (Cons) new ArcNet.__\u003C\u003EAnon0();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Cons
    {
      internal __\u003C\u003EAnon0()
      {
      }

      public void get([In] object obj0) => ArcNet.lambda\u0024static\u00240((Exception) obj0);
    }
  }
}
