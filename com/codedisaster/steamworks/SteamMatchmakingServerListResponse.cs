// Decompiled with JetBrains decompiler
// Type: com.codedisaster.steamworks.SteamMatchmakingServerListResponse
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace com.codedisaster.steamworks
{
  public abstract class SteamMatchmakingServerListResponse : SteamInterface
  {
    static IntPtr __\u003Cjniptr\u003EcreateProxy\u0028Lcom\u002Fcodedisaster\u002Fsteamworks\u002FSteamMatchmakingServerListResponse\u003B\u0029J;
    [SpecialName]
    private static CallerID __\u003CcallerID\u003E;

    [Modifiers]
    private static long createProxy([In] SteamMatchmakingServerListResponse obj0)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamMatchmakingServerListResponse.__\u003Cjniptr\u003EcreateProxy\u0028Lcom\u002Fcodedisaster\u002Fsteamworks\u002FSteamMatchmakingServerListResponse\u003B\u0029J == IntPtr.Zero)
        SteamMatchmakingServerListResponse.__\u003Cjniptr\u003EcreateProxy\u0028Lcom\u002Fcodedisaster\u002Fsteamworks\u002FSteamMatchmakingServerListResponse\u003B\u0029J = JNI.Frame.GetFuncPtr(SteamMatchmakingServerListResponse.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamMatchmakingServerListResponse", nameof (createProxy), "(Lcom/codedisaster/steamworks/SteamMatchmakingServerListResponse;)J");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamMatchmakingServerListResponse.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamMatchmakingServerListResponse>.Value);
        IntPtr num4 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj0);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<long (IntPtr, IntPtr, IntPtr)>) SteamMatchmakingServerListResponse.__\u003Cjniptr\u003EcreateProxy\u0028Lcom\u002Fcodedisaster\u002Fsteamworks\u002FSteamMatchmakingServerListResponse\u003B\u0029J)(num2, num3, num4);
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

    public abstract void serverResponded(SteamServerListRequest sslr, int i);

    public abstract void serverFailedToRespond(SteamServerListRequest sslr, int i);

    public abstract void refreshComplete(
      SteamServerListRequest sslr,
      SteamMatchmakingServerListResponse.Response smslrr);

    [LineNumberTable(new byte[] {159, 160, 106, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal SteamMatchmakingServerListResponse()
      : base(-1L)
    {
      SteamMatchmakingServerListResponse serverListResponse = this;
      this.callback = SteamMatchmakingServerListResponse.createProxy(this);
    }

    [LineNumberTable(new byte[] {159, 167, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void serverResponded([In] long obj0, [In] int obj1) => this.serverResponded(new SteamServerListRequest(obj0), obj1);

    [LineNumberTable(new byte[] {159, 173, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void serverFailedToRespond([In] long obj0, [In] int obj1) => this.serverFailedToRespond(new SteamServerListRequest(obj0), obj1);

    [LineNumberTable(new byte[] {159, 179, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void refreshComplete([In] long obj0, [In] int obj1) => this.refreshComplete(new SteamServerListRequest(obj0), SteamMatchmakingServerListResponse.Response.byOrdinal(obj1));

    [Modifiers]
    [LineNumberTable(3)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void dispose() => base.dispose();

    new static CallerID __\u003CGetCallerID\u003E()
    {
      if (SteamMatchmakingServerListResponse.__\u003CcallerID\u003E == null)
        SteamMatchmakingServerListResponse.__\u003CcallerID\u003E = (CallerID) new SteamMatchmakingServerListResponse.__\u003CCallerID\u003E();
      return SteamMatchmakingServerListResponse.__\u003CcallerID\u003E;
    }

    [HideFromJava]
    protected internal long pointer
    {
      [HideFromJava] get => this.pointer;
    }

    [HideFromJava]
    protected internal long callback
    {
      [HideFromJava] get => this.callback;
      [HideFromJava] [param: In] set => this.callback = value;
    }

    [HideFromJava]
    [NameSig("<accessstub>0|deleteCallback", "(J)V")]
    protected internal new static void deleteCallback([In] long obj0) => SteamInterface.deleteCallback(obj0);

    [InnerClass]
    [Signature("Ljava/lang/Enum<Lcom/codedisaster/steamworks/SteamMatchmakingServerListResponse$Response;>;")]
    [Modifiers]
    [Serializable]
    public sealed class Response : Enum
    {
      [Modifiers]
      internal static SteamMatchmakingServerListResponse.Response __\u003C\u003EServerResponded;
      [Modifiers]
      internal static SteamMatchmakingServerListResponse.Response __\u003C\u003EServerFailedToRespond;
      [Modifiers]
      internal static SteamMatchmakingServerListResponse.Response __\u003C\u003ENoServersListedOnMasterServer;
      [Modifiers]
      private static SteamMatchmakingServerListResponse.Response[] values;
      [Modifiers]
      private static SteamMatchmakingServerListResponse.Response[] \u0024VALUES;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [Signature("()V")]
      [LineNumberTable(5)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private Response([In] string obj0, [In] int obj1)
        : base(obj0, obj1)
      {
        GC.KeepAlive((object) this);
      }

      [LineNumberTable(5)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static SteamMatchmakingServerListResponse.Response[] values() => (SteamMatchmakingServerListResponse.Response[]) SteamMatchmakingServerListResponse.Response.\u0024VALUES.Clone();

      [LineNumberTable(5)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static SteamMatchmakingServerListResponse.Response valueOf(
        string name)
      {
        return (SteamMatchmakingServerListResponse.Response) Enum.valueOf((Class) ClassLiteral<SteamMatchmakingServerListResponse.Response>.Value, name);
      }

      [LineNumberTable(13)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal static SteamMatchmakingServerListResponse.Response byOrdinal(
        [In] int obj0)
      {
        return SteamMatchmakingServerListResponse.Response.values[obj0];
      }

      [LineNumberTable(new byte[] {159, 141, 141, 112, 112, 240, 61, 255, 4, 69})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static Response()
      {
        if (ByteCodeHelper.isAlreadyInited("com.codedisaster.steamworks.SteamMatchmakingServerListResponse$Response"))
          return;
        SteamMatchmakingServerListResponse.Response.__\u003C\u003EServerResponded = new SteamMatchmakingServerListResponse.Response(nameof (ServerResponded), 0);
        SteamMatchmakingServerListResponse.Response.__\u003C\u003EServerFailedToRespond = new SteamMatchmakingServerListResponse.Response(nameof (ServerFailedToRespond), 1);
        SteamMatchmakingServerListResponse.Response.__\u003C\u003ENoServersListedOnMasterServer = new SteamMatchmakingServerListResponse.Response(nameof (NoServersListedOnMasterServer), 2);
        SteamMatchmakingServerListResponse.Response.\u0024VALUES = new SteamMatchmakingServerListResponse.Response[3]
        {
          SteamMatchmakingServerListResponse.Response.__\u003C\u003EServerResponded,
          SteamMatchmakingServerListResponse.Response.__\u003C\u003EServerFailedToRespond,
          SteamMatchmakingServerListResponse.Response.__\u003C\u003ENoServersListedOnMasterServer
        };
        SteamMatchmakingServerListResponse.Response.values = SteamMatchmakingServerListResponse.Response.values();
      }

      [Modifiers]
      public static SteamMatchmakingServerListResponse.Response ServerResponded
      {
        [HideFromJava] get => SteamMatchmakingServerListResponse.Response.__\u003C\u003EServerResponded;
      }

      [Modifiers]
      public static SteamMatchmakingServerListResponse.Response ServerFailedToRespond
      {
        [HideFromJava] get => SteamMatchmakingServerListResponse.Response.__\u003C\u003EServerFailedToRespond;
      }

      [Modifiers]
      public static SteamMatchmakingServerListResponse.Response NoServersListedOnMasterServer
      {
        [HideFromJava] get => SteamMatchmakingServerListResponse.Response.__\u003C\u003ENoServersListedOnMasterServer;
      }

      [HideFromJava]
      [Serializable]
      public enum __Enum
      {
        ServerResponded,
        ServerFailedToRespond,
        NoServersListedOnMasterServer,
      }
    }

    private new sealed class __\u003CCallerID\u003E : CallerID
    {
      internal __\u003CCallerID\u003E()
      {
      }
    }
  }
}
