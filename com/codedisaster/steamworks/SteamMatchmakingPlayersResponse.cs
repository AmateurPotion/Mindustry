// Decompiled with JetBrains decompiler
// Type: com.codedisaster.steamworks.SteamMatchmakingPlayersResponse
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace com.codedisaster.steamworks
{
  public abstract class SteamMatchmakingPlayersResponse : SteamInterface
  {
    static IntPtr __\u003Cjniptr\u003EcreateProxy\u0028Lcom\u002Fcodedisaster\u002Fsteamworks\u002FSteamMatchmakingPlayersResponse\u003B\u0029J;
    [SpecialName]
    private static CallerID __\u003CcallerID\u003E;

    [Modifiers]
    private static long createProxy([In] SteamMatchmakingPlayersResponse obj0)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamMatchmakingPlayersResponse.__\u003Cjniptr\u003EcreateProxy\u0028Lcom\u002Fcodedisaster\u002Fsteamworks\u002FSteamMatchmakingPlayersResponse\u003B\u0029J == IntPtr.Zero)
        SteamMatchmakingPlayersResponse.__\u003Cjniptr\u003EcreateProxy\u0028Lcom\u002Fcodedisaster\u002Fsteamworks\u002FSteamMatchmakingPlayersResponse\u003B\u0029J = JNI.Frame.GetFuncPtr(SteamMatchmakingPlayersResponse.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamMatchmakingPlayersResponse", nameof (createProxy), "(Lcom/codedisaster/steamworks/SteamMatchmakingPlayersResponse;)J");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamMatchmakingPlayersResponse.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamMatchmakingPlayersResponse>.Value);
        IntPtr num4 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj0);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<long (IntPtr, IntPtr, IntPtr)>) SteamMatchmakingPlayersResponse.__\u003Cjniptr\u003EcreateProxy\u0028Lcom\u002Fcodedisaster\u002Fsteamworks\u002FSteamMatchmakingPlayersResponse\u003B\u0029J)(num2, num3, num4);
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

    [LineNumberTable(new byte[] {159, 148, 106, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal SteamMatchmakingPlayersResponse()
      : base(-1L)
    {
      SteamMatchmakingPlayersResponse matchmakingPlayersResponse = this;
      this.callback = SteamMatchmakingPlayersResponse.createProxy(this);
    }

    public abstract void addPlayerToList(string str, int i, float f);

    public abstract void playersFailedToRespond();

    public abstract void playersRefreshComplete();

    [Modifiers]
    [LineNumberTable(3)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void dispose() => base.dispose();

    new static CallerID __\u003CGetCallerID\u003E()
    {
      if (SteamMatchmakingPlayersResponse.__\u003CcallerID\u003E == null)
        SteamMatchmakingPlayersResponse.__\u003CcallerID\u003E = (CallerID) new SteamMatchmakingPlayersResponse.__\u003CCallerID\u003E();
      return SteamMatchmakingPlayersResponse.__\u003CcallerID\u003E;
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

    private new sealed class __\u003CCallerID\u003E : CallerID
    {
      internal __\u003CCallerID\u003E()
      {
      }
    }
  }
}
