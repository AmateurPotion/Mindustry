// Decompiled with JetBrains decompiler
// Type: com.codedisaster.steamworks.SteamNetworkingCallbackAdapter
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace com.codedisaster.steamworks
{
  [Signature("Lcom/codedisaster/steamworks/SteamCallbackAdapter<Lcom/codedisaster/steamworks/SteamNetworkingCallback;>;")]
  internal class SteamNetworkingCallbackAdapter : SteamCallbackAdapter
  {
    [LineNumberTable(new byte[] {159, 149, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal SteamNetworkingCallbackAdapter([In] SteamNetworkingCallback obj0)
      : base((object) obj0)
    {
    }

    [LineNumberTable(new byte[] {159, 153, 103, 119})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void onP2PSessionConnectFail([In] long obj0, [In] int obj1) => ((SteamNetworkingCallback) this.callback).onP2PSessionConnectFail(new SteamID(obj0), SteamNetworking.P2PSessionError.byOrdinal(obj1));

    [LineNumberTable(new byte[] {159, 158, 103, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void onP2PSessionRequest([In] long obj0) => ((SteamNetworkingCallback) this.callback).onP2PSessionRequest(new SteamID(obj0));
  }
}
