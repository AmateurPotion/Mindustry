// Decompiled with JetBrains decompiler
// Type: com.codedisaster.steamworks.SteamUserCallbackAdapter
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace com.codedisaster.steamworks
{
  [Signature("Lcom/codedisaster/steamworks/SteamCallbackAdapter<Lcom/codedisaster/steamworks/SteamUserCallback;>;")]
  internal class SteamUserCallbackAdapter : SteamCallbackAdapter
  {
    [LineNumberTable(new byte[] {159, 149, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal SteamUserCallbackAdapter([In] SteamUserCallback obj0)
      : base((object) obj0)
    {
    }

    [LineNumberTable(new byte[] {159, 153, 114, 43, 133})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void onValidateAuthTicket([In] long obj0, [In] int obj1, [In] long obj2) => ((SteamUserCallback) this.callback).onValidateAuthTicket(new SteamID(obj0), SteamAuth.AuthSessionResponse.byOrdinal(obj1), new SteamID(obj2));

    [LineNumberTable(new byte[] {159, 138, 66, 115})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void onMicroTxnAuthorization([In] int obj0, [In] long obj1, [In] bool obj2)
    {
      int num = obj2 ? 1 : 0;
      ((SteamUserCallback) this.callback).onMicroTxnAuthorization(obj0, obj1, num != 0);
    }

    [LineNumberTable(new byte[] {159, 162, 118})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void onEncryptedAppTicket([In] int obj0) => ((SteamUserCallback) this.callback).onEncryptedAppTicket(SteamResult.byValue(obj0));
  }
}
