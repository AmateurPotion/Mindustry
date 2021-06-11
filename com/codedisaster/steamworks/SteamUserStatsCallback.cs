// Decompiled with JetBrains decompiler
// Type: com.codedisaster.steamworks.SteamUserStatsCallback
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

namespace com.codedisaster.steamworks
{
  public interface SteamUserStatsCallback
  {
    void onUserStatsReceived(long l, SteamID sid, SteamResult sr);

    void onUserStatsStored(long l, SteamResult sr);

    void onUserStatsUnloaded(SteamID sid);

    void onUserAchievementStored(long l, bool b, string str, int i1, int i2);

    void onLeaderboardFindResult(SteamLeaderboardHandle slh, bool b);

    void onLeaderboardScoresDownloaded(
      SteamLeaderboardHandle slh,
      SteamLeaderboardEntriesHandle sleh,
      int i);

    void onLeaderboardScoreUploaded(
      bool b1,
      SteamLeaderboardHandle slh,
      int i1,
      bool b2,
      int i2,
      int i3);

    void onGlobalStatsReceived(long l, SteamResult sr);
  }
}
