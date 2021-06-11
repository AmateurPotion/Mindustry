// Decompiled with JetBrains decompiler
// Type: com.codedisaster.steamworks.SteamUserStatsCallbackAdapter
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace com.codedisaster.steamworks
{
  [Signature("Lcom/codedisaster/steamworks/SteamCallbackAdapter<Lcom/codedisaster/steamworks/SteamUserStatsCallback;>;")]
  internal class SteamUserStatsCallbackAdapter : SteamCallbackAdapter
  {
    [LineNumberTable(new byte[] {159, 149, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal SteamUserStatsCallbackAdapter([In] SteamUserStatsCallback obj0)
      : base((object) obj0)
    {
    }

    [LineNumberTable(new byte[] {159, 153, 125})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void onUserStatsReceived([In] long obj0, [In] long obj1, [In] int obj2) => ((SteamUserStatsCallback) this.callback).onUserStatsReceived(obj0, new SteamID(obj1), SteamResult.byValue(obj2));

    [LineNumberTable(new byte[] {159, 157, 119})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void onUserStatsStored([In] long obj0, [In] int obj1) => ((SteamUserStatsCallback) this.callback).onUserStatsStored(obj0, SteamResult.byValue(obj1));

    [LineNumberTable(new byte[] {159, 161, 118})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void onUserStatsUnloaded([In] long obj0) => ((SteamUserStatsCallback) this.callback).onUserStatsUnloaded(new SteamID(obj0));

    [LineNumberTable(new byte[] {159, 136, 66, 119})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void onUserAchievementStored(
      [In] long obj0,
      [In] bool obj1,
      [In] string obj2,
      [In] int obj3,
      [In] int obj4)
    {
      int num = obj1 ? 1 : 0;
      ((SteamUserStatsCallback) this.callback).onUserAchievementStored(obj0, num != 0, obj2, obj3, obj4);
    }

    [LineNumberTable(new byte[] {159, 135, 66, 119})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void onLeaderboardFindResult([In] long obj0, [In] bool obj1)
    {
      int num = obj1 ? 1 : 0;
      ((SteamUserStatsCallback) this.callback).onLeaderboardFindResult(new SteamLeaderboardHandle(obj0), num != 0);
    }

    [LineNumberTable(new byte[] {159, 174, 157})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void onLeaderboardScoresDownloaded([In] long obj0, [In] long obj1, [In] int obj2) => ((SteamUserStatsCallback) this.callback).onLeaderboardScoresDownloaded(new SteamLeaderboardHandle(obj0), new SteamLeaderboardEntriesHandle(obj1), obj2);

    [LineNumberTable(new byte[] {159, 133, 133, 157})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void onLeaderboardScoreUploaded(
      [In] bool obj0,
      [In] long obj1,
      [In] int obj2,
      [In] bool obj3,
      [In] int obj4,
      [In] int obj5)
    {
      int num1 = obj0 ? 1 : 0;
      int num2 = obj3 ? 1 : 0;
      ((SteamUserStatsCallback) this.callback).onLeaderboardScoreUploaded(num1 != 0, new SteamLeaderboardHandle(obj1), obj2, num2 != 0, obj4, obj5);
    }

    [LineNumberTable(new byte[] {159, 185, 119})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void onGlobalStatsReceived([In] long obj0, [In] int obj1) => ((SteamUserStatsCallback) this.callback).onGlobalStatsReceived(obj0, SteamResult.byValue(obj1));
  }
}
