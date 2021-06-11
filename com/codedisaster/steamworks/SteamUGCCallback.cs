// Decompiled with JetBrains decompiler
// Type: com.codedisaster.steamworks.SteamUGCCallback
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

namespace com.codedisaster.steamworks
{
  public interface SteamUGCCallback
  {
    void onUGCQueryCompleted(SteamUGCQuery sugcq, int i1, int i2, bool b, SteamResult sr);

    void onSubscribeItem(SteamPublishedFileID spfid, SteamResult sr);

    void onUnsubscribeItem(SteamPublishedFileID spfid, SteamResult sr);

    void onRequestUGCDetails(SteamUGCDetails sugcd, SteamResult sr);

    void onCreateItem(SteamPublishedFileID spfid, bool b, SteamResult sr);

    void onSubmitItemUpdate(SteamPublishedFileID spfid, bool b, SteamResult sr);

    void onDownloadItemResult(int i, SteamPublishedFileID spfid, SteamResult sr);

    void onUserFavoriteItemsListChanged(SteamPublishedFileID spfid, bool b, SteamResult sr);

    void onSetUserItemVote(SteamPublishedFileID spfid, bool b, SteamResult sr);

    void onGetUserItemVote(SteamPublishedFileID spfid, bool b1, bool b2, bool b3, SteamResult sr);

    void onStartPlaytimeTracking(SteamResult sr);

    void onStopPlaytimeTracking(SteamResult sr);

    void onStopPlaytimeTrackingForAllItems(SteamResult sr);

    void onDeleteItem(SteamPublishedFileID spfid, SteamResult sr);
  }
}
