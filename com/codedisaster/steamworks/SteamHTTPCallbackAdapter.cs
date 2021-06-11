// Decompiled with JetBrains decompiler
// Type: com.codedisaster.steamworks.SteamHTTPCallbackAdapter
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace com.codedisaster.steamworks
{
  [Signature("Lcom/codedisaster/steamworks/SteamCallbackAdapter<Lcom/codedisaster/steamworks/SteamHTTPCallback;>;")]
  internal class SteamHTTPCallbackAdapter : SteamCallbackAdapter
  {
    [LineNumberTable(new byte[] {159, 149, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal SteamHTTPCallbackAdapter([In] SteamHTTPCallback obj0)
      : base((object) obj0)
    {
    }

    [LineNumberTable(new byte[] {159, 139, 98, 117, 39, 133})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void onHTTPRequestCompleted(
      [In] long obj0,
      [In] long obj1,
      [In] bool obj2,
      [In] int obj3,
      [In] int obj4)
    {
      int num = obj2 ? 1 : 0;
      ((SteamHTTPCallback) this.callback).onHTTPRequestCompleted(new SteamHTTPRequestHandle(obj0), obj1, num != 0, SteamHTTP.HTTPStatusCode.byValue(obj3), obj4);
    }

    [LineNumberTable(new byte[] {159, 160, 119})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void onHTTPRequestHeadersReceived([In] long obj0, [In] long obj1) => ((SteamHTTPCallback) this.callback).onHTTPRequestHeadersReceived(new SteamHTTPRequestHandle(obj0), obj1);

    [LineNumberTable(new byte[] {159, 164, 122})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void onHTTPRequestDataReceived([In] long obj0, [In] long obj1, [In] int obj2, [In] int obj3) => ((SteamHTTPCallback) this.callback).onHTTPRequestDataReceived(new SteamHTTPRequestHandle(obj0), obj1, obj2, obj3);
  }
}
