// Decompiled with JetBrains decompiler
// Type: mindustry.desktop.steam.SUser
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using com.codedisaster.steamworks;
using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.desktop.steam
{
  public class SUser : Object, SteamUserCallback
  {
    internal SteamUser __\u003C\u003Euser;

    [LineNumberTable(new byte[] {159, 148, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public SUser()
    {
      SUser suser = this;
      this.__\u003C\u003Euser = new SteamUser((SteamUserCallback) this);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void onValidateAuthTicket(
      SteamID steamID,
      SteamAuth.AuthSessionResponse authSessionResponse,
      SteamID ownerSteamID)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void onMicroTxnAuthorization(int appID, long orderID, bool authorized)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void onEncryptedAppTicket(SteamResult result)
    {
    }

    [Modifiers]
    public SteamUser user
    {
      [HideFromJava] get => this.__\u003C\u003Euser;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Euser = value;
    }
  }
}
