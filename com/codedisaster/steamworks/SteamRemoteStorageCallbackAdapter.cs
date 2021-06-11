// Decompiled with JetBrains decompiler
// Type: com.codedisaster.steamworks.SteamRemoteStorageCallbackAdapter
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace com.codedisaster.steamworks
{
  [Signature("Lcom/codedisaster/steamworks/SteamCallbackAdapter<Lcom/codedisaster/steamworks/SteamRemoteStorageCallback;>;")]
  internal class SteamRemoteStorageCallbackAdapter : SteamCallbackAdapter
  {
    [LineNumberTable(new byte[] {159, 149, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal SteamRemoteStorageCallbackAdapter([In] SteamRemoteStorageCallback obj0)
      : base((object) obj0)
    {
    }

    [LineNumberTable(new byte[] {159, 153, 115, 37, 133})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void onFileShareResult([In] long obj0, [In] string obj1, [In] int obj2) => ((SteamRemoteStorageCallback) this.callback).onFileShareResult(new SteamUGCHandle(obj0), obj1, SteamResult.byValue(obj2));

    [LineNumberTable(new byte[] {159, 158, 124})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void onDownloadUGCResult([In] long obj0, [In] int obj1) => ((SteamRemoteStorageCallback) this.callback).onDownloadUGCResult(new SteamUGCHandle(obj0), SteamResult.byValue(obj1));

    [LineNumberTable(new byte[] {159, 137, 66, 115, 37, 133})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void onPublishFileResult([In] long obj0, [In] bool obj1, [In] int obj2)
    {
      int num = obj1 ? 1 : 0;
      ((SteamRemoteStorageCallback) this.callback).onPublishFileResult(new SteamPublishedFileID(obj0), num != 0, SteamResult.byValue(obj2));
    }

    [LineNumberTable(new byte[] {159, 136, 98, 115, 37, 133})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void onUpdatePublishedFileResult([In] long obj0, [In] bool obj1, [In] int obj2)
    {
      int num = obj1 ? 1 : 0;
      ((SteamRemoteStorageCallback) this.callback).onUpdatePublishedFileResult(new SteamPublishedFileID(obj0), num != 0, SteamResult.byValue(obj2));
    }

    [LineNumberTable(new byte[] {159, 172, 119})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void onPublishedFileSubscribed([In] long obj0, [In] int obj1) => ((SteamRemoteStorageCallback) this.callback).onPublishedFileSubscribed(new SteamPublishedFileID(obj0), obj1);

    [LineNumberTable(new byte[] {159, 176, 119})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void onPublishedFileUnsubscribed([In] long obj0, [In] int obj1) => ((SteamRemoteStorageCallback) this.callback).onPublishedFileUnsubscribed(new SteamPublishedFileID(obj0), obj1);

    [LineNumberTable(new byte[] {159, 180, 119})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void onPublishedFileDeleted([In] long obj0, [In] int obj1) => ((SteamRemoteStorageCallback) this.callback).onPublishedFileDeleted(new SteamPublishedFileID(obj0), obj1);

    [LineNumberTable(new byte[] {159, 184, 118})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void onFileWriteAsyncComplete([In] int obj0) => ((SteamRemoteStorageCallback) this.callback).onFileWriteAsyncComplete(SteamResult.byValue(obj0));

    [LineNumberTable(new byte[] {159, 188, 114, 40, 133})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void onFileReadAsyncComplete([In] long obj0, [In] int obj1, [In] int obj2, [In] int obj3) => ((SteamRemoteStorageCallback) this.callback).onFileReadAsyncComplete(new SteamAPICall(obj0), SteamResult.byValue(obj1), obj2, obj3);
  }
}
