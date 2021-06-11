// Decompiled with JetBrains decompiler
// Type: com.codedisaster.steamworks.SteamRemoteStorageCallback
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

namespace com.codedisaster.steamworks
{
  public interface SteamRemoteStorageCallback
  {
    void onFileShareResult(SteamUGCHandle sugch, string str, SteamResult sr);

    void onDownloadUGCResult(SteamUGCHandle sugch, SteamResult sr);

    void onPublishFileResult(SteamPublishedFileID spfid, bool b, SteamResult sr);

    void onUpdatePublishedFileResult(SteamPublishedFileID spfid, bool b, SteamResult sr);

    void onPublishedFileSubscribed(SteamPublishedFileID spfid, int i);

    void onPublishedFileUnsubscribed(SteamPublishedFileID spfid, int i);

    void onPublishedFileDeleted(SteamPublishedFileID spfid, int i);

    void onFileWriteAsyncComplete(SteamResult sr);

    void onFileReadAsyncComplete(SteamAPICall sapic, SteamResult sr, int i1, int i2);
  }
}
