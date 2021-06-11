// Decompiled with JetBrains decompiler
// Type: arc.net.FrameworkMessage
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System.Runtime.CompilerServices;

namespace arc.net
{
  public interface FrameworkMessage
  {
    static readonly FrameworkMessage.KeepAlive keepAlive;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(8)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static FrameworkMessage()
    {
      if (ByteCodeHelper.isAlreadyInited("arc.net.FrameworkMessage"))
        return;
      FrameworkMessage.keepAlive = new FrameworkMessage.KeepAlive();
    }

    class DiscoverHost : Object, FrameworkMessage
    {
      [LineNumberTable(33)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public DiscoverHost()
      {
      }
    }

    class KeepAlive : Object, FrameworkMessage
    {
      [LineNumberTable(27)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public KeepAlive()
      {
      }
    }

    class Ping : Object, FrameworkMessage
    {
      public int id;
      public bool isReply;

      [LineNumberTable(39)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public Ping()
      {
      }
    }

    class RegisterTCP : Object, FrameworkMessage
    {
      public int connectionID;

      [LineNumberTable(13)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public RegisterTCP()
      {
      }
    }

    class RegisterUDP : Object, FrameworkMessage
    {
      public int connectionID;

      [LineNumberTable(20)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public RegisterUDP()
      {
      }
    }

    [HideFromJava]
    static class __Fields
    {
      public static readonly FrameworkMessage.KeepAlive keepAlive = FrameworkMessage.keepAlive;
    }
  }
}
