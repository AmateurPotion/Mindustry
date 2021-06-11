// Decompiled with JetBrains decompiler
// Type: com.codedisaster.steamworks.SteamMatchmakingCallback
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

namespace com.codedisaster.steamworks
{
  public interface SteamMatchmakingCallback
  {
    void onFavoritesListChanged(int i1, int i2, int i3, int i4, int i5, bool b, int i6);

    void onLobbyInvite(SteamID sid1, SteamID sid2, long l);

    void onLobbyEnter(SteamID sid, int i, bool b, SteamMatchmaking.ChatRoomEnterResponse smcrer);

    void onLobbyDataUpdate(SteamID sid1, SteamID sid2, bool b);

    void onLobbyChatUpdate(
      SteamID sid1,
      SteamID sid2,
      SteamID sid3,
      SteamMatchmaking.ChatMemberStateChange smcmsc);

    void onLobbyChatMessage(
      SteamID sid1,
      SteamID sid2,
      SteamMatchmaking.ChatEntryType smcet,
      int i);

    void onLobbyGameCreated(SteamID sid1, SteamID sid2, int i, short s);

    void onLobbyMatchList(int i);

    void onLobbyKicked(SteamID sid1, SteamID sid2, bool b);

    void onLobbyCreated(SteamResult sr, SteamID sid);

    void onFavoritesListAccountsUpdated(SteamResult sr);
  }
}
