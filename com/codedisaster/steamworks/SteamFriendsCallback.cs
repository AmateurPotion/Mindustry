// Decompiled with JetBrains decompiler
// Type: com.codedisaster.steamworks.SteamFriendsCallback
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

namespace com.codedisaster.steamworks
{
  public interface SteamFriendsCallback
  {
    void onSetPersonaNameResponse(bool b1, bool b2, SteamResult sr);

    void onPersonaStateChange(SteamID sid, SteamFriends.PersonaChange sfpc);

    void onGameOverlayActivated(bool b);

    void onGameLobbyJoinRequested(SteamID sid1, SteamID sid2);

    void onAvatarImageLoaded(SteamID sid, int i1, int i2, int i3);

    void onFriendRichPresenceUpdate(SteamID sid, int i);

    void onGameRichPresenceJoinRequested(SteamID sid, string str);

    void onGameServerChangeRequested(string str1, string str2);
  }
}
