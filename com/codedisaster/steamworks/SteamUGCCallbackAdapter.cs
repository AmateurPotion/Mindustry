// Decompiled with JetBrains decompiler
// Type: com.codedisaster.steamworks.SteamUGCCallbackAdapter
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace com.codedisaster.steamworks
{
  [Signature("Lcom/codedisaster/steamworks/SteamCallbackAdapter<Lcom/codedisaster/steamworks/SteamUGCCallback;>;")]
  internal class SteamUGCCallbackAdapter : SteamCallbackAdapter
  {
    [LineNumberTable(new byte[] {159, 149, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal SteamUGCCallbackAdapter([In] SteamUGCCallback obj0)
      : base((object) obj0)
    {
    }

    [LineNumberTable(new byte[] {159, 139, 99, 118, 37, 133})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void onUGCQueryCompleted([In] long obj0, [In] int obj1, [In] int obj2, [In] bool obj3, [In] int obj4)
    {
      int num = obj3 ? 1 : 0;
      ((SteamUGCCallback) this.callback).onUGCQueryCompleted(new SteamUGCQuery(obj0), obj1, obj2, num != 0, SteamResult.byValue(obj4));
    }

    [LineNumberTable(new byte[] {159, 160, 124})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void onSubscribeItem([In] long obj0, [In] int obj1) => ((SteamUGCCallback) this.callback).onSubscribeItem(new SteamPublishedFileID(obj0), SteamResult.byValue(obj1));

    [LineNumberTable(new byte[] {159, 164, 124})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void onUnsubscribeItem([In] long obj0, [In] int obj1) => ((SteamUGCCallback) this.callback).onUnsubscribeItem(new SteamPublishedFileID(obj0), SteamResult.byValue(obj1));

    [LineNumberTable(new byte[] {159, 172, 102, 103, 103, 103, 104, 104, 104, 104, 104, 104, 104, 104, 136, 119})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void onRequestUGCDetails(
      [In] long obj0,
      [In] int obj1,
      [In] string obj2,
      [In] string obj3,
      [In] long obj4,
      [In] long obj5,
      [In] string obj6,
      [In] bool obj7,
      [In] int obj8,
      [In] int obj9,
      [In] long obj10,
      [In] int obj11,
      [In] int obj12)
    {
      ((SteamUGCCallback) this.callback).onRequestUGCDetails(new SteamUGCDetails()
      {
        publishedFileID = obj0,
        result = obj1,
        title = obj2,
        description = obj3,
        fileHandle = obj4,
        previewFileHandle = obj5,
        fileName = obj6,
        votesUp = obj8,
        votesDown = obj9,
        ownerID = obj10,
        timeCreated = obj11,
        timeUpdated = obj12
      }, SteamResult.byValue(obj1));
    }

    [LineNumberTable(new byte[] {159, 130, 66, 125})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void onCreateItem([In] long obj0, [In] bool obj1, [In] int obj2)
    {
      int num = obj1 ? 1 : 0;
      ((SteamUGCCallback) this.callback).onCreateItem(new SteamPublishedFileID(obj0), num != 0, SteamResult.byValue(obj2));
    }

    [LineNumberTable(new byte[] {159, 129, 66, 115, 37, 133})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void onSubmitItemUpdate([In] long obj0, [In] bool obj1, [In] int obj2)
    {
      int num = obj1 ? 1 : 0;
      ((SteamUGCCallback) this.callback).onSubmitItemUpdate(new SteamPublishedFileID(obj0), num != 0, SteamResult.byValue(obj2));
    }

    [LineNumberTable(new byte[] {7, 125})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void onDownloadItemResult([In] int obj0, [In] long obj1, [In] int obj2) => ((SteamUGCCallback) this.callback).onDownloadItemResult(obj0, new SteamPublishedFileID(obj1), SteamResult.byValue(obj2));

    [LineNumberTable(new byte[] {159, 127, 98, 115, 37, 133})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void onUserFavoriteItemsListChanged([In] long obj0, [In] bool obj1, [In] int obj2)
    {
      int num = obj1 ? 1 : 0;
      ((SteamUGCCallback) this.callback).onUserFavoriteItemsListChanged(new SteamPublishedFileID(obj0), num != 0, SteamResult.byValue(obj2));
    }

    [LineNumberTable(new byte[] {159, 126, 130, 125})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void onSetUserItemVote([In] long obj0, [In] bool obj1, [In] int obj2)
    {
      int num = obj1 ? 1 : 0;
      ((SteamUGCCallback) this.callback).onSetUserItemVote(new SteamPublishedFileID(obj0), num != 0, SteamResult.byValue(obj2));
    }

    [LineNumberTable(new byte[] {159, 125, 135, 118, 37, 133})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void onGetUserItemVote([In] long obj0, [In] bool obj1, [In] bool obj2, [In] bool obj3, [In] int obj4)
    {
      int num1 = obj1 ? 1 : 0;
      int num2 = obj2 ? 1 : 0;
      int num3 = obj3 ? 1 : 0;
      ((SteamUGCCallback) this.callback).onGetUserItemVote(new SteamPublishedFileID(obj0), num1 != 0, num2 != 0, num3 != 0, SteamResult.byValue(obj4));
    }

    [LineNumberTable(new byte[] {25, 118})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void onStartPlaytimeTracking([In] int obj0) => ((SteamUGCCallback) this.callback).onStartPlaytimeTracking(SteamResult.byValue(obj0));

    [LineNumberTable(new byte[] {29, 118})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void onStopPlaytimeTracking([In] int obj0) => ((SteamUGCCallback) this.callback).onStopPlaytimeTracking(SteamResult.byValue(obj0));

    [LineNumberTable(new byte[] {33, 118})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void onStopPlaytimeTrackingForAllItems([In] int obj0) => ((SteamUGCCallback) this.callback).onStopPlaytimeTrackingForAllItems(SteamResult.byValue(obj0));

    [LineNumberTable(new byte[] {37, 124})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void onDeleteItem([In] long obj0, [In] int obj1) => ((SteamUGCCallback) this.callback).onDeleteItem(new SteamPublishedFileID(obj0), SteamResult.byValue(obj1));
  }
}
