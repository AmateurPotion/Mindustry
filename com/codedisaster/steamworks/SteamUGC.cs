// Decompiled with JetBrains decompiler
// Type: com.codedisaster.steamworks.SteamUGC
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.util;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace com.codedisaster.steamworks
{
  public class SteamUGC : SteamInterface
  {
    static IntPtr __\u003Cjniptr\u003EcreateCallback\u0028Lcom\u002Fcodedisaster\u002Fsteamworks\u002FSteamUGCCallbackAdapter\u003B\u0029J;
    [SpecialName]
    private static CallerID __\u003CcallerID\u003E;
    static IntPtr __\u003Cjniptr\u003EcreateQueryUserUGCRequest\u0028JIIIIIII\u0029J;
    static IntPtr __\u003Cjniptr\u003EcreateQueryAllUGCRequest\u0028JIIIII\u0029J;
    static IntPtr __\u003Cjniptr\u003EcreateQueryUGCDetailsRequest\u0028J\u005BJI\u0029J;
    static IntPtr __\u003Cjniptr\u003EsendQueryUGCRequest\u0028JJJ\u0029J;
    static IntPtr __\u003Cjniptr\u003EgetQueryUGCResult\u0028JJILcom\u002Fcodedisaster\u002Fsteamworks\u002FSteamUGCDetails\u003B\u0029Z;
    static IntPtr __\u003Cjniptr\u003EgetQueryUGCPreviewURL\u0028JJI\u0029Ljava\u002Flang\u002FString\u003B;
    static IntPtr __\u003Cjniptr\u003EgetQueryUGCMetadata\u0028JJI\u0029Ljava\u002Flang\u002FString\u003B;
    static IntPtr __\u003Cjniptr\u003EgetQueryUGCStatistic\u0028JJII\u0029J;
    static IntPtr __\u003Cjniptr\u003EgetQueryUGCNumAdditionalPreviews\u0028JJI\u0029I;
    static IntPtr __\u003Cjniptr\u003EgetQueryUGCAdditionalPreview\u0028JJIILcom\u002Fcodedisaster\u002Fsteamworks\u002FSteamUGC\u0024ItemAdditionalPreview\u003B\u0029Z;
    static IntPtr __\u003Cjniptr\u003EgetQueryUGCNumKeyValueTags\u0028JJI\u0029I;
    static IntPtr __\u003Cjniptr\u003EgetQueryUGCKeyValueTag\u0028JJII\u005BLjava\u002Flang\u002FString\u003B\u0029Z;
    static IntPtr __\u003Cjniptr\u003EreleaseQueryUserUGCRequest\u0028JJ\u0029Z;
    static IntPtr __\u003Cjniptr\u003EaddRequiredTag\u0028JJLjava\u002Flang\u002FString\u003B\u0029Z;
    static IntPtr __\u003Cjniptr\u003EaddExcludedTag\u0028JJLjava\u002Flang\u002FString\u003B\u0029Z;
    static IntPtr __\u003Cjniptr\u003EsetReturnOnlyIDs\u0028JJZ\u0029Z;
    static IntPtr __\u003Cjniptr\u003EsetReturnKeyValueTags\u0028JJZ\u0029Z;
    static IntPtr __\u003Cjniptr\u003EsetReturnLongDescription\u0028JJZ\u0029Z;
    static IntPtr __\u003Cjniptr\u003EsetReturnMetadata\u0028JJZ\u0029Z;
    static IntPtr __\u003Cjniptr\u003EsetReturnChildren\u0028JJZ\u0029Z;
    static IntPtr __\u003Cjniptr\u003EsetReturnAdditionalPreviews\u0028JJZ\u0029Z;
    static IntPtr __\u003Cjniptr\u003EsetReturnTotalOnly\u0028JJZ\u0029Z;
    static IntPtr __\u003Cjniptr\u003EsetReturnPlaytimeStats\u0028JJI\u0029Z;
    static IntPtr __\u003Cjniptr\u003EsetLanguage\u0028JJLjava\u002Flang\u002FString\u003B\u0029Z;
    static IntPtr __\u003Cjniptr\u003EsetAllowCachedResponse\u0028JJI\u0029Z;
    static IntPtr __\u003Cjniptr\u003EsetCloudFileNameFilter\u0028JJLjava\u002Flang\u002FString\u003B\u0029Z;
    static IntPtr __\u003Cjniptr\u003EsetMatchAnyTag\u0028JJZ\u0029Z;
    static IntPtr __\u003Cjniptr\u003EsetSearchText\u0028JJLjava\u002Flang\u002FString\u003B\u0029Z;
    static IntPtr __\u003Cjniptr\u003EsetRankedByTrendDays\u0028JJI\u0029Z;
    static IntPtr __\u003Cjniptr\u003EaddRequiredKeyValueTag\u0028JJLjava\u002Flang\u002FString\u003BLjava\u002Flang\u002FString\u003B\u0029Z;
    static IntPtr __\u003Cjniptr\u003ErequestUGCDetails\u0028JJJI\u0029J;
    static IntPtr __\u003Cjniptr\u003EcreateItem\u0028JJII\u0029J;
    static IntPtr __\u003Cjniptr\u003EstartItemUpdate\u0028JIJ\u0029J;
    static IntPtr __\u003Cjniptr\u003EsetItemTitle\u0028JJLjava\u002Flang\u002FString\u003B\u0029Z;
    static IntPtr __\u003Cjniptr\u003EsetItemDescription\u0028JJLjava\u002Flang\u002FString\u003B\u0029Z;
    static IntPtr __\u003Cjniptr\u003EsetItemUpdateLanguage\u0028JJLjava\u002Flang\u002FString\u003B\u0029Z;
    static IntPtr __\u003Cjniptr\u003EsetItemMetadata\u0028JJLjava\u002Flang\u002FString\u003B\u0029Z;
    static IntPtr __\u003Cjniptr\u003EsetItemVisibility\u0028JJI\u0029Z;
    static IntPtr __\u003Cjniptr\u003EsetItemTags\u0028JJ\u005BLjava\u002Flang\u002FString\u003BI\u0029Z;
    static IntPtr __\u003Cjniptr\u003EsetItemContent\u0028JJLjava\u002Flang\u002FString\u003B\u0029Z;
    static IntPtr __\u003Cjniptr\u003EsetItemPreview\u0028JJLjava\u002Flang\u002FString\u003B\u0029Z;
    static IntPtr __\u003Cjniptr\u003EremoveItemKeyValueTags\u0028JJLjava\u002Flang\u002FString\u003B\u0029Z;
    static IntPtr __\u003Cjniptr\u003EaddItemKeyValueTag\u0028JJLjava\u002Flang\u002FString\u003BLjava\u002Flang\u002FString\u003B\u0029Z;
    static IntPtr __\u003Cjniptr\u003EsubmitItemUpdate\u0028JJJLjava\u002Flang\u002FString\u003B\u0029J;
    static IntPtr __\u003Cjniptr\u003EgetItemUpdateProgress\u0028JJ\u005BJ\u0029I;
    static IntPtr __\u003Cjniptr\u003EsetUserItemVote\u0028JJJZ\u0029J;
    static IntPtr __\u003Cjniptr\u003EgetUserItemVote\u0028JJJ\u0029J;
    static IntPtr __\u003Cjniptr\u003EaddItemToFavorites\u0028JJIJ\u0029J;
    static IntPtr __\u003Cjniptr\u003EremoveItemFromFavorites\u0028JJIJ\u0029J;
    static IntPtr __\u003Cjniptr\u003EsubscribeItem\u0028JJJ\u0029J;
    static IntPtr __\u003Cjniptr\u003EunsubscribeItem\u0028JJJ\u0029J;
    static IntPtr __\u003Cjniptr\u003EgetNumSubscribedItems\u0028J\u0029I;
    static IntPtr __\u003Cjniptr\u003EgetSubscribedItems\u0028J\u005BJI\u0029I;
    static IntPtr __\u003Cjniptr\u003EgetItemState\u0028JJ\u0029I;
    static IntPtr __\u003Cjniptr\u003EgetItemInstallInfo\u0028JJLcom\u002Fcodedisaster\u002Fsteamworks\u002FSteamUGC\u0024ItemInstallInfo\u003B\u0029Z;
    static IntPtr __\u003Cjniptr\u003EgetItemDownloadInfo\u0028JJ\u005BJ\u0029Z;
    static IntPtr __\u003Cjniptr\u003EdeleteItem\u0028JJJ\u0029J;
    static IntPtr __\u003Cjniptr\u003EdownloadItem\u0028JJZ\u0029Z;
    static IntPtr __\u003Cjniptr\u003EinitWorkshopForGameServer\u0028JILjava\u002Flang\u002FString\u003B\u0029Z;
    static IntPtr __\u003Cjniptr\u003EsuspendDownloads\u0028JZ\u0029V;
    static IntPtr __\u003Cjniptr\u003EstartPlaytimeTracking\u0028JJ\u005BJI\u0029J;
    static IntPtr __\u003Cjniptr\u003EstopPlaytimeTracking\u0028JJ\u005BJI\u0029J;
    static IntPtr __\u003Cjniptr\u003EstopPlaytimeTrackingForAllItems\u0028JJ\u0029J;

    [LineNumberTable(new byte[] {160, 107, 118})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public SteamUGC(SteamUGCCallback callback)
      : base(SteamAPI.getSteamUGCPointer(), SteamUGC.createCallback(new SteamUGCCallbackAdapter(callback)))
    {
    }

    [LineNumberTable(459)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getNumSubscribedItems() => SteamUGC.getNumSubscribedItems(this.pointer);

    [LineNumberTable(new byte[] {161, 93, 104, 143, 102, 43, 198})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getSubscribedItems(SteamPublishedFileID[] publishedFileIds)
    {
      long[] numArray = new long[publishedFileIds.Length];
      int subscribedItems = SteamUGC.getSubscribedItems(this.pointer, numArray, publishedFileIds.Length);
      for (int index = 0; index < subscribedItems; ++index)
        publishedFileIds[index] = new SteamPublishedFileID(numArray[index]);
      return subscribedItems;
    }

    [LineNumberTable(new byte[] {160, 126, 103, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual SteamUGCQuery createQueryUGCDetailsRequest(
      SteamPublishedFileID publishedFileID)
    {
      return new SteamUGCQuery(SteamUGC.createQueryUGCDetailsRequest(this.pointer, new long[1]
      {
        publishedFileID.handle
      }, 1));
    }

    [LineNumberTable(258)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual SteamAPICall sendQueryUGCRequest(SteamUGCQuery query) => new SteamAPICall(SteamUGC.sendQueryUGCRequest(this.pointer, this.callback, query.handle));

    [LineNumberTable(377)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual SteamUGCUpdateHandle startItemUpdate(
      int consumerAppID,
      SteamPublishedFileID publishedFileID)
    {
      return new SteamUGCUpdateHandle(SteamUGC.startItemUpdate(this.pointer, consumerAppID, publishedFileID.handle));
    }

    [LineNumberTable(262)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool getQueryUGCResult(SteamUGCQuery query, int index, SteamUGCDetails details) => SteamUGC.getQueryUGCResult(this.pointer, query.handle, index, details);

    [LineNumberTable(478)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool getItemInstallInfo(
      SteamPublishedFileID publishedFileID,
      SteamUGC.ItemInstallInfo installInfo)
    {
      return SteamUGC.getItemInstallInfo(this.pointer, publishedFileID.handle, installInfo);
    }

    [LineNumberTable(new byte[] {161, 57, 103, 120, 105, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual SteamUGC.ItemUpdateStatus getItemUpdateProgress(
      SteamUGCUpdateHandle update,
      SteamUGC.ItemUpdateInfo updateInfo)
    {
      long[] numArray = new long[2];
      SteamUGC.ItemUpdateStatus itemUpdateStatus = SteamUGC.ItemUpdateStatus.byOrdinal(SteamUGC.getItemUpdateProgress(this.pointer, update.handle, numArray));
      updateInfo.bytesProcessed = numArray[0];
      updateInfo.bytesTotal = numArray[1];
      return itemUpdateStatus;
    }

    [LineNumberTable(373)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual SteamAPICall createItem(
      int consumerAppID,
      SteamRemoteStorage.WorkshopFileType fileType)
    {
      return new SteamAPICall(SteamUGC.createItem(this.pointer, this.callback, consumerAppID, fileType.ordinal()));
    }

    [LineNumberTable(385)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool setItemDescription(SteamUGCUpdateHandle update, string description) => SteamUGC.setItemDescription(this.pointer, update.handle, description);

    [LineNumberTable(381)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool setItemTitle(SteamUGCUpdateHandle update, string title) => SteamUGC.setItemTitle(this.pointer, update.handle, title);

    [LineNumberTable(403)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool setItemTags(SteamUGCUpdateHandle update, string[] tags) => SteamUGC.setItemTags(this.pointer, update.handle, tags, tags.Length);

    [LineNumberTable(411)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool setItemPreview(SteamUGCUpdateHandle update, string previewFile) => SteamUGC.setItemPreview(this.pointer, update.handle, previewFile);

    [LineNumberTable(407)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool setItemContent(SteamUGCUpdateHandle update, string contentFolder) => SteamUGC.setItemContent(this.pointer, update.handle, contentFolder);

    [LineNumberTable(399)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool setItemVisibility(
      SteamUGCUpdateHandle update,
      SteamRemoteStorage.PublishedFileVisibility visibility)
    {
      return SteamUGC.setItemVisibility(this.pointer, update.handle, visibility.ordinal());
    }

    [LineNumberTable(423)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual SteamAPICall submitItemUpdate(
      SteamUGCUpdateHandle update,
      string changeNote)
    {
      return new SteamAPICall(SteamUGC.submitItemUpdate(this.pointer, this.callback, update.handle, changeNote));
    }

    [Modifiers]
    private static long createCallback([In] SteamUGCCallbackAdapter obj0)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamUGC.__\u003Cjniptr\u003EcreateCallback\u0028Lcom\u002Fcodedisaster\u002Fsteamworks\u002FSteamUGCCallbackAdapter\u003B\u0029J == IntPtr.Zero)
        SteamUGC.__\u003Cjniptr\u003EcreateCallback\u0028Lcom\u002Fcodedisaster\u002Fsteamworks\u002FSteamUGCCallbackAdapter\u003B\u0029J = JNI.Frame.GetFuncPtr(SteamUGC.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamUGC", nameof (createCallback), "(Lcom/codedisaster/steamworks/SteamUGCCallbackAdapter;)J");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamUGC.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamUGC>.Value);
        IntPtr num4 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj0);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<long (IntPtr, IntPtr, IntPtr)>) SteamUGC.__\u003Cjniptr\u003EcreateCallback\u0028Lcom\u002Fcodedisaster\u002Fsteamworks\u002FSteamUGCCallbackAdapter\u003B\u0029J)(num2, num3, num4);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    private static long createQueryUserUGCRequest(
      [In] long obj0,
      [In] int obj1,
      [In] int obj2,
      [In] int obj3,
      [In] int obj4,
      [In] int obj5,
      [In] int obj6,
      [In] int obj7)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamUGC.__\u003Cjniptr\u003EcreateQueryUserUGCRequest\u0028JIIIIIII\u0029J == IntPtr.Zero)
        SteamUGC.__\u003Cjniptr\u003EcreateQueryUserUGCRequest\u0028JIIIIIII\u0029J = JNI.Frame.GetFuncPtr(SteamUGC.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamUGC", nameof (createQueryUserUGCRequest), "(JIIIIIII)J");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamUGC.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamUGC>.Value);
        long num4 = obj0;
        int num5 = obj1;
        int num6 = obj2;
        int num7 = obj3;
        int num8 = obj4;
        int num9 = obj5;
        int num10 = obj6;
        int num11 = obj7;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<long (IntPtr, IntPtr, long, int, int, int, int, int, int, int)>) SteamUGC.__\u003Cjniptr\u003EcreateQueryUserUGCRequest\u0028JIIIIIII\u0029J)((int) num2, (int) num3, (int) num4, num5, num6, num7, num8, (long) num9, (IntPtr) num10, (IntPtr) num11);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    private static long createQueryAllUGCRequest(
      [In] long obj0,
      [In] int obj1,
      [In] int obj2,
      [In] int obj3,
      [In] int obj4,
      [In] int obj5)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamUGC.__\u003Cjniptr\u003EcreateQueryAllUGCRequest\u0028JIIIII\u0029J == IntPtr.Zero)
        SteamUGC.__\u003Cjniptr\u003EcreateQueryAllUGCRequest\u0028JIIIII\u0029J = JNI.Frame.GetFuncPtr(SteamUGC.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamUGC", nameof (createQueryAllUGCRequest), "(JIIIII)J");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamUGC.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamUGC>.Value);
        long num4 = obj0;
        int num5 = obj1;
        int num6 = obj2;
        int num7 = obj3;
        int num8 = obj4;
        int num9 = obj5;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<long (IntPtr, IntPtr, long, int, int, int, int, int)>) SteamUGC.__\u003Cjniptr\u003EcreateQueryAllUGCRequest\u0028JIIIII\u0029J)((int) num2, (int) num3, (int) num4, num5, num6, (long) num7, (IntPtr) num8, (IntPtr) num9);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    private static long createQueryUGCDetailsRequest([In] long obj0, [In] long[] obj1, [In] int obj2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamUGC.__\u003Cjniptr\u003EcreateQueryUGCDetailsRequest\u0028J\u005BJI\u0029J == IntPtr.Zero)
        SteamUGC.__\u003Cjniptr\u003EcreateQueryUGCDetailsRequest\u0028J\u005BJI\u0029J = JNI.Frame.GetFuncPtr(SteamUGC.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamUGC", nameof (createQueryUGCDetailsRequest), "(J[JI)J");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamUGC.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamUGC>.Value);
        long num4 = obj0;
        IntPtr num5 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj1);
        int num6 = obj2;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<long (IntPtr, IntPtr, long, IntPtr, int)>) SteamUGC.__\u003Cjniptr\u003EcreateQueryUGCDetailsRequest\u0028J\u005BJI\u0029J)((int) num2, num3, num4, num5, (IntPtr) num6);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    private static long sendQueryUGCRequest([In] long obj0, [In] long obj1, [In] long obj2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamUGC.__\u003Cjniptr\u003EsendQueryUGCRequest\u0028JJJ\u0029J == IntPtr.Zero)
        SteamUGC.__\u003Cjniptr\u003EsendQueryUGCRequest\u0028JJJ\u0029J = JNI.Frame.GetFuncPtr(SteamUGC.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamUGC", nameof (sendQueryUGCRequest), "(JJJ)J");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamUGC.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamUGC>.Value);
        long num4 = obj0;
        long num5 = obj1;
        long num6 = obj2;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<long (IntPtr, IntPtr, long, long, long)>) SteamUGC.__\u003Cjniptr\u003EsendQueryUGCRequest\u0028JJJ\u0029J)((long) num2, (long) num3, num4, (IntPtr) num5, (IntPtr) num6);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    private static bool getQueryUGCResult([In] long obj0, [In] long obj1, [In] int obj2, [In] SteamUGCDetails obj3)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamUGC.__\u003Cjniptr\u003EgetQueryUGCResult\u0028JJILcom\u002Fcodedisaster\u002Fsteamworks\u002FSteamUGCDetails\u003B\u0029Z == IntPtr.Zero)
        SteamUGC.__\u003Cjniptr\u003EgetQueryUGCResult\u0028JJILcom\u002Fcodedisaster\u002Fsteamworks\u002FSteamUGCDetails\u003B\u0029Z = JNI.Frame.GetFuncPtr(SteamUGC.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamUGC", nameof (getQueryUGCResult), "(JJILcom/codedisaster/steamworks/SteamUGCDetails;)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamUGC.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamUGC>.Value);
        long num4 = obj0;
        long num5 = obj1;
        int num6 = obj2;
        IntPtr num7 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj3);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, long, long, int, IntPtr)>) SteamUGC.__\u003Cjniptr\u003EgetQueryUGCResult\u0028JJILcom\u002Fcodedisaster\u002Fsteamworks\u002FSteamUGCDetails\u003B\u0029Z)(num2, (int) num3, num4, num5, (IntPtr) num6, num7);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    private static string getQueryUGCPreviewURL([In] long obj0, [In] long obj1, [In] int obj2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamUGC.__\u003Cjniptr\u003EgetQueryUGCPreviewURL\u0028JJI\u0029Ljava\u002Flang\u002FString\u003B == IntPtr.Zero)
        SteamUGC.__\u003Cjniptr\u003EgetQueryUGCPreviewURL\u0028JJI\u0029Ljava\u002Flang\u002FString\u003B = JNI.Frame.GetFuncPtr(SteamUGC.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamUGC", nameof (getQueryUGCPreviewURL), "(JJI)Ljava/lang/String;");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamUGC.__\u003CGetCallerID\u003E());
      try
      {
        ref JNI.Frame local = ref frame;
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamUGC>.Value);
        long num4 = obj0;
        long num5 = obj1;
        int num6 = obj2;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        IntPtr num7 = __calli((__FnPtr<IntPtr (IntPtr, IntPtr, long, long, int)>) SteamUGC.__\u003Cjniptr\u003EgetQueryUGCPreviewURL\u0028JJI\u0029Ljava\u002Flang\u002FString\u003B)((int) num2, (long) num3, num4, (IntPtr) num5, (IntPtr) num6);
        return (string) ((JNI.Frame) ref local).UnwrapLocalRef(num7);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    private static string getQueryUGCMetadata([In] long obj0, [In] long obj1, [In] int obj2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamUGC.__\u003Cjniptr\u003EgetQueryUGCMetadata\u0028JJI\u0029Ljava\u002Flang\u002FString\u003B == IntPtr.Zero)
        SteamUGC.__\u003Cjniptr\u003EgetQueryUGCMetadata\u0028JJI\u0029Ljava\u002Flang\u002FString\u003B = JNI.Frame.GetFuncPtr(SteamUGC.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamUGC", nameof (getQueryUGCMetadata), "(JJI)Ljava/lang/String;");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamUGC.__\u003CGetCallerID\u003E());
      try
      {
        ref JNI.Frame local = ref frame;
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamUGC>.Value);
        long num4 = obj0;
        long num5 = obj1;
        int num6 = obj2;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        IntPtr num7 = __calli((__FnPtr<IntPtr (IntPtr, IntPtr, long, long, int)>) SteamUGC.__\u003Cjniptr\u003EgetQueryUGCMetadata\u0028JJI\u0029Ljava\u002Flang\u002FString\u003B)((int) num2, (long) num3, num4, (IntPtr) num5, (IntPtr) num6);
        return (string) ((JNI.Frame) ref local).UnwrapLocalRef(num7);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    private static long getQueryUGCStatistic([In] long obj0, [In] long obj1, [In] int obj2, [In] int obj3)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamUGC.__\u003Cjniptr\u003EgetQueryUGCStatistic\u0028JJII\u0029J == IntPtr.Zero)
        SteamUGC.__\u003Cjniptr\u003EgetQueryUGCStatistic\u0028JJII\u0029J = JNI.Frame.GetFuncPtr(SteamUGC.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamUGC", nameof (getQueryUGCStatistic), "(JJII)J");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamUGC.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamUGC>.Value);
        long num4 = obj0;
        long num5 = obj1;
        int num6 = obj2;
        int num7 = obj3;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<long (IntPtr, IntPtr, long, long, int, int)>) SteamUGC.__\u003Cjniptr\u003EgetQueryUGCStatistic\u0028JJII\u0029J)((int) num2, (int) num3, num4, num5, (IntPtr) num6, (IntPtr) num7);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    private static int getQueryUGCNumAdditionalPreviews([In] long obj0, [In] long obj1, [In] int obj2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamUGC.__\u003Cjniptr\u003EgetQueryUGCNumAdditionalPreviews\u0028JJI\u0029I == IntPtr.Zero)
        SteamUGC.__\u003Cjniptr\u003EgetQueryUGCNumAdditionalPreviews\u0028JJI\u0029I = JNI.Frame.GetFuncPtr(SteamUGC.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamUGC", nameof (getQueryUGCNumAdditionalPreviews), "(JJI)I");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamUGC.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamUGC>.Value);
        long num4 = obj0;
        long num5 = obj1;
        int num6 = obj2;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<int (IntPtr, IntPtr, long, long, int)>) SteamUGC.__\u003Cjniptr\u003EgetQueryUGCNumAdditionalPreviews\u0028JJI\u0029I)((int) num2, (long) num3, num4, (IntPtr) num5, (IntPtr) num6);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    private static bool getQueryUGCAdditionalPreview(
      [In] long obj0,
      [In] long obj1,
      [In] int obj2,
      [In] int obj3,
      [In] SteamUGC.ItemAdditionalPreview obj4)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamUGC.__\u003Cjniptr\u003EgetQueryUGCAdditionalPreview\u0028JJIILcom\u002Fcodedisaster\u002Fsteamworks\u002FSteamUGC\u0024ItemAdditionalPreview\u003B\u0029Z == IntPtr.Zero)
        SteamUGC.__\u003Cjniptr\u003EgetQueryUGCAdditionalPreview\u0028JJIILcom\u002Fcodedisaster\u002Fsteamworks\u002FSteamUGC\u0024ItemAdditionalPreview\u003B\u0029Z = JNI.Frame.GetFuncPtr(SteamUGC.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamUGC", nameof (getQueryUGCAdditionalPreview), "(JJIILcom/codedisaster/steamworks/SteamUGC$ItemAdditionalPreview;)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamUGC.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamUGC>.Value);
        long num4 = obj0;
        long num5 = obj1;
        int num6 = obj2;
        int num7 = obj3;
        IntPtr num8 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj4);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, long, long, int, int, IntPtr)>) SteamUGC.__\u003Cjniptr\u003EgetQueryUGCAdditionalPreview\u0028JJIILcom\u002Fcodedisaster\u002Fsteamworks\u002FSteamUGC\u0024ItemAdditionalPreview\u003B\u0029Z)(num2, (int) num3, (int) num4, num5, (long) num6, (IntPtr) num7, num8);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    private static int getQueryUGCNumKeyValueTags([In] long obj0, [In] long obj1, [In] int obj2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamUGC.__\u003Cjniptr\u003EgetQueryUGCNumKeyValueTags\u0028JJI\u0029I == IntPtr.Zero)
        SteamUGC.__\u003Cjniptr\u003EgetQueryUGCNumKeyValueTags\u0028JJI\u0029I = JNI.Frame.GetFuncPtr(SteamUGC.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamUGC", nameof (getQueryUGCNumKeyValueTags), "(JJI)I");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamUGC.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamUGC>.Value);
        long num4 = obj0;
        long num5 = obj1;
        int num6 = obj2;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<int (IntPtr, IntPtr, long, long, int)>) SteamUGC.__\u003Cjniptr\u003EgetQueryUGCNumKeyValueTags\u0028JJI\u0029I)((int) num2, (long) num3, num4, (IntPtr) num5, (IntPtr) num6);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    private static bool getQueryUGCKeyValueTag(
      [In] long obj0,
      [In] long obj1,
      [In] int obj2,
      [In] int obj3,
      [In] string[] obj4)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamUGC.__\u003Cjniptr\u003EgetQueryUGCKeyValueTag\u0028JJII\u005BLjava\u002Flang\u002FString\u003B\u0029Z == IntPtr.Zero)
        SteamUGC.__\u003Cjniptr\u003EgetQueryUGCKeyValueTag\u0028JJII\u005BLjava\u002Flang\u002FString\u003B\u0029Z = JNI.Frame.GetFuncPtr(SteamUGC.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamUGC", nameof (getQueryUGCKeyValueTag), "(JJII[Ljava/lang/String;)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamUGC.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamUGC>.Value);
        long num4 = obj0;
        long num5 = obj1;
        int num6 = obj2;
        int num7 = obj3;
        IntPtr num8 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj4);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, long, long, int, int, IntPtr)>) SteamUGC.__\u003Cjniptr\u003EgetQueryUGCKeyValueTag\u0028JJII\u005BLjava\u002Flang\u002FString\u003B\u0029Z)(num2, (int) num3, (int) num4, num5, (long) num6, (IntPtr) num7, num8);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    private static bool releaseQueryUserUGCRequest([In] long obj0, [In] long obj1)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamUGC.__\u003Cjniptr\u003EreleaseQueryUserUGCRequest\u0028JJ\u0029Z == IntPtr.Zero)
        SteamUGC.__\u003Cjniptr\u003EreleaseQueryUserUGCRequest\u0028JJ\u0029Z = JNI.Frame.GetFuncPtr(SteamUGC.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamUGC", nameof (releaseQueryUserUGCRequest), "(JJ)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamUGC.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamUGC>.Value);
        long num4 = obj0;
        long num5 = obj1;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, long, long)>) SteamUGC.__\u003Cjniptr\u003EreleaseQueryUserUGCRequest\u0028JJ\u0029Z)((long) num2, (long) num3, (IntPtr) num4, (IntPtr) num5);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    private static bool addRequiredTag([In] long obj0, [In] long obj1, [In] string obj2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamUGC.__\u003Cjniptr\u003EaddRequiredTag\u0028JJLjava\u002Flang\u002FString\u003B\u0029Z == IntPtr.Zero)
        SteamUGC.__\u003Cjniptr\u003EaddRequiredTag\u0028JJLjava\u002Flang\u002FString\u003B\u0029Z = JNI.Frame.GetFuncPtr(SteamUGC.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamUGC", nameof (addRequiredTag), "(JJLjava/lang/String;)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamUGC.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamUGC>.Value);
        long num4 = obj0;
        long num5 = obj1;
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj2);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, long, long, IntPtr)>) SteamUGC.__\u003Cjniptr\u003EaddRequiredTag\u0028JJLjava\u002Flang\u002FString\u003B\u0029Z)(num2, (long) num3, num4, (IntPtr) num5, num6);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    private static bool addExcludedTag([In] long obj0, [In] long obj1, [In] string obj2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamUGC.__\u003Cjniptr\u003EaddExcludedTag\u0028JJLjava\u002Flang\u002FString\u003B\u0029Z == IntPtr.Zero)
        SteamUGC.__\u003Cjniptr\u003EaddExcludedTag\u0028JJLjava\u002Flang\u002FString\u003B\u0029Z = JNI.Frame.GetFuncPtr(SteamUGC.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamUGC", nameof (addExcludedTag), "(JJLjava/lang/String;)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamUGC.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamUGC>.Value);
        long num4 = obj0;
        long num5 = obj1;
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj2);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, long, long, IntPtr)>) SteamUGC.__\u003Cjniptr\u003EaddExcludedTag\u0028JJLjava\u002Flang\u002FString\u003B\u0029Z)(num2, (long) num3, num4, (IntPtr) num5, num6);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    private static bool setReturnOnlyIDs([In] long obj0, [In] long obj1, [In] bool obj2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamUGC.__\u003Cjniptr\u003EsetReturnOnlyIDs\u0028JJZ\u0029Z == IntPtr.Zero)
        SteamUGC.__\u003Cjniptr\u003EsetReturnOnlyIDs\u0028JJZ\u0029Z = JNI.Frame.GetFuncPtr(SteamUGC.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamUGC", nameof (setReturnOnlyIDs), "(JJZ)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamUGC.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamUGC>.Value);
        long num4 = obj0;
        long num5 = obj1;
        int num6 = obj2 ? 1 : 0;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, long, long, bool)>) SteamUGC.__\u003Cjniptr\u003EsetReturnOnlyIDs\u0028JJZ\u0029Z)((bool) num2, (long) num3, num4, (IntPtr) num5, (IntPtr) num6);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    private static bool setReturnKeyValueTags([In] long obj0, [In] long obj1, [In] bool obj2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamUGC.__\u003Cjniptr\u003EsetReturnKeyValueTags\u0028JJZ\u0029Z == IntPtr.Zero)
        SteamUGC.__\u003Cjniptr\u003EsetReturnKeyValueTags\u0028JJZ\u0029Z = JNI.Frame.GetFuncPtr(SteamUGC.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamUGC", nameof (setReturnKeyValueTags), "(JJZ)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamUGC.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamUGC>.Value);
        long num4 = obj0;
        long num5 = obj1;
        int num6 = obj2 ? 1 : 0;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, long, long, bool)>) SteamUGC.__\u003Cjniptr\u003EsetReturnKeyValueTags\u0028JJZ\u0029Z)((bool) num2, (long) num3, num4, (IntPtr) num5, (IntPtr) num6);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    private static bool setReturnLongDescription([In] long obj0, [In] long obj1, [In] bool obj2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamUGC.__\u003Cjniptr\u003EsetReturnLongDescription\u0028JJZ\u0029Z == IntPtr.Zero)
        SteamUGC.__\u003Cjniptr\u003EsetReturnLongDescription\u0028JJZ\u0029Z = JNI.Frame.GetFuncPtr(SteamUGC.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamUGC", nameof (setReturnLongDescription), "(JJZ)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamUGC.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamUGC>.Value);
        long num4 = obj0;
        long num5 = obj1;
        int num6 = obj2 ? 1 : 0;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, long, long, bool)>) SteamUGC.__\u003Cjniptr\u003EsetReturnLongDescription\u0028JJZ\u0029Z)((bool) num2, (long) num3, num4, (IntPtr) num5, (IntPtr) num6);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    private static bool setReturnMetadata([In] long obj0, [In] long obj1, [In] bool obj2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamUGC.__\u003Cjniptr\u003EsetReturnMetadata\u0028JJZ\u0029Z == IntPtr.Zero)
        SteamUGC.__\u003Cjniptr\u003EsetReturnMetadata\u0028JJZ\u0029Z = JNI.Frame.GetFuncPtr(SteamUGC.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamUGC", nameof (setReturnMetadata), "(JJZ)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamUGC.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamUGC>.Value);
        long num4 = obj0;
        long num5 = obj1;
        int num6 = obj2 ? 1 : 0;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, long, long, bool)>) SteamUGC.__\u003Cjniptr\u003EsetReturnMetadata\u0028JJZ\u0029Z)((bool) num2, (long) num3, num4, (IntPtr) num5, (IntPtr) num6);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    private static bool setReturnChildren([In] long obj0, [In] long obj1, [In] bool obj2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamUGC.__\u003Cjniptr\u003EsetReturnChildren\u0028JJZ\u0029Z == IntPtr.Zero)
        SteamUGC.__\u003Cjniptr\u003EsetReturnChildren\u0028JJZ\u0029Z = JNI.Frame.GetFuncPtr(SteamUGC.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamUGC", nameof (setReturnChildren), "(JJZ)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamUGC.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamUGC>.Value);
        long num4 = obj0;
        long num5 = obj1;
        int num6 = obj2 ? 1 : 0;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, long, long, bool)>) SteamUGC.__\u003Cjniptr\u003EsetReturnChildren\u0028JJZ\u0029Z)((bool) num2, (long) num3, num4, (IntPtr) num5, (IntPtr) num6);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    private static bool setReturnAdditionalPreviews([In] long obj0, [In] long obj1, [In] bool obj2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamUGC.__\u003Cjniptr\u003EsetReturnAdditionalPreviews\u0028JJZ\u0029Z == IntPtr.Zero)
        SteamUGC.__\u003Cjniptr\u003EsetReturnAdditionalPreviews\u0028JJZ\u0029Z = JNI.Frame.GetFuncPtr(SteamUGC.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamUGC", nameof (setReturnAdditionalPreviews), "(JJZ)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamUGC.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamUGC>.Value);
        long num4 = obj0;
        long num5 = obj1;
        int num6 = obj2 ? 1 : 0;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, long, long, bool)>) SteamUGC.__\u003Cjniptr\u003EsetReturnAdditionalPreviews\u0028JJZ\u0029Z)((bool) num2, (long) num3, num4, (IntPtr) num5, (IntPtr) num6);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    private static bool setReturnTotalOnly([In] long obj0, [In] long obj1, [In] bool obj2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamUGC.__\u003Cjniptr\u003EsetReturnTotalOnly\u0028JJZ\u0029Z == IntPtr.Zero)
        SteamUGC.__\u003Cjniptr\u003EsetReturnTotalOnly\u0028JJZ\u0029Z = JNI.Frame.GetFuncPtr(SteamUGC.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamUGC", nameof (setReturnTotalOnly), "(JJZ)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamUGC.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamUGC>.Value);
        long num4 = obj0;
        long num5 = obj1;
        int num6 = obj2 ? 1 : 0;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, long, long, bool)>) SteamUGC.__\u003Cjniptr\u003EsetReturnTotalOnly\u0028JJZ\u0029Z)((bool) num2, (long) num3, num4, (IntPtr) num5, (IntPtr) num6);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    private static bool setReturnPlaytimeStats([In] long obj0, [In] long obj1, [In] int obj2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamUGC.__\u003Cjniptr\u003EsetReturnPlaytimeStats\u0028JJI\u0029Z == IntPtr.Zero)
        SteamUGC.__\u003Cjniptr\u003EsetReturnPlaytimeStats\u0028JJI\u0029Z = JNI.Frame.GetFuncPtr(SteamUGC.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamUGC", nameof (setReturnPlaytimeStats), "(JJI)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamUGC.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamUGC>.Value);
        long num4 = obj0;
        long num5 = obj1;
        int num6 = obj2;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, long, long, int)>) SteamUGC.__\u003Cjniptr\u003EsetReturnPlaytimeStats\u0028JJI\u0029Z)((int) num2, (long) num3, num4, (IntPtr) num5, (IntPtr) num6);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    private static bool setLanguage([In] long obj0, [In] long obj1, [In] string obj2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamUGC.__\u003Cjniptr\u003EsetLanguage\u0028JJLjava\u002Flang\u002FString\u003B\u0029Z == IntPtr.Zero)
        SteamUGC.__\u003Cjniptr\u003EsetLanguage\u0028JJLjava\u002Flang\u002FString\u003B\u0029Z = JNI.Frame.GetFuncPtr(SteamUGC.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamUGC", nameof (setLanguage), "(JJLjava/lang/String;)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamUGC.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamUGC>.Value);
        long num4 = obj0;
        long num5 = obj1;
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj2);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, long, long, IntPtr)>) SteamUGC.__\u003Cjniptr\u003EsetLanguage\u0028JJLjava\u002Flang\u002FString\u003B\u0029Z)(num2, (long) num3, num4, (IntPtr) num5, num6);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    private static bool setAllowCachedResponse([In] long obj0, [In] long obj1, [In] int obj2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamUGC.__\u003Cjniptr\u003EsetAllowCachedResponse\u0028JJI\u0029Z == IntPtr.Zero)
        SteamUGC.__\u003Cjniptr\u003EsetAllowCachedResponse\u0028JJI\u0029Z = JNI.Frame.GetFuncPtr(SteamUGC.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamUGC", nameof (setAllowCachedResponse), "(JJI)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamUGC.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamUGC>.Value);
        long num4 = obj0;
        long num5 = obj1;
        int num6 = obj2;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, long, long, int)>) SteamUGC.__\u003Cjniptr\u003EsetAllowCachedResponse\u0028JJI\u0029Z)((int) num2, (long) num3, num4, (IntPtr) num5, (IntPtr) num6);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    private static bool setCloudFileNameFilter([In] long obj0, [In] long obj1, [In] string obj2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamUGC.__\u003Cjniptr\u003EsetCloudFileNameFilter\u0028JJLjava\u002Flang\u002FString\u003B\u0029Z == IntPtr.Zero)
        SteamUGC.__\u003Cjniptr\u003EsetCloudFileNameFilter\u0028JJLjava\u002Flang\u002FString\u003B\u0029Z = JNI.Frame.GetFuncPtr(SteamUGC.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamUGC", nameof (setCloudFileNameFilter), "(JJLjava/lang/String;)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamUGC.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamUGC>.Value);
        long num4 = obj0;
        long num5 = obj1;
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj2);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, long, long, IntPtr)>) SteamUGC.__\u003Cjniptr\u003EsetCloudFileNameFilter\u0028JJLjava\u002Flang\u002FString\u003B\u0029Z)(num2, (long) num3, num4, (IntPtr) num5, num6);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    private static bool setMatchAnyTag([In] long obj0, [In] long obj1, [In] bool obj2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamUGC.__\u003Cjniptr\u003EsetMatchAnyTag\u0028JJZ\u0029Z == IntPtr.Zero)
        SteamUGC.__\u003Cjniptr\u003EsetMatchAnyTag\u0028JJZ\u0029Z = JNI.Frame.GetFuncPtr(SteamUGC.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamUGC", nameof (setMatchAnyTag), "(JJZ)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamUGC.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamUGC>.Value);
        long num4 = obj0;
        long num5 = obj1;
        int num6 = obj2 ? 1 : 0;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, long, long, bool)>) SteamUGC.__\u003Cjniptr\u003EsetMatchAnyTag\u0028JJZ\u0029Z)((bool) num2, (long) num3, num4, (IntPtr) num5, (IntPtr) num6);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    private static bool setSearchText([In] long obj0, [In] long obj1, [In] string obj2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamUGC.__\u003Cjniptr\u003EsetSearchText\u0028JJLjava\u002Flang\u002FString\u003B\u0029Z == IntPtr.Zero)
        SteamUGC.__\u003Cjniptr\u003EsetSearchText\u0028JJLjava\u002Flang\u002FString\u003B\u0029Z = JNI.Frame.GetFuncPtr(SteamUGC.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamUGC", nameof (setSearchText), "(JJLjava/lang/String;)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamUGC.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamUGC>.Value);
        long num4 = obj0;
        long num5 = obj1;
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj2);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, long, long, IntPtr)>) SteamUGC.__\u003Cjniptr\u003EsetSearchText\u0028JJLjava\u002Flang\u002FString\u003B\u0029Z)(num2, (long) num3, num4, (IntPtr) num5, num6);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    private static bool setRankedByTrendDays([In] long obj0, [In] long obj1, [In] int obj2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamUGC.__\u003Cjniptr\u003EsetRankedByTrendDays\u0028JJI\u0029Z == IntPtr.Zero)
        SteamUGC.__\u003Cjniptr\u003EsetRankedByTrendDays\u0028JJI\u0029Z = JNI.Frame.GetFuncPtr(SteamUGC.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamUGC", nameof (setRankedByTrendDays), "(JJI)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamUGC.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamUGC>.Value);
        long num4 = obj0;
        long num5 = obj1;
        int num6 = obj2;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, long, long, int)>) SteamUGC.__\u003Cjniptr\u003EsetRankedByTrendDays\u0028JJI\u0029Z)((int) num2, (long) num3, num4, (IntPtr) num5, (IntPtr) num6);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    private static bool addRequiredKeyValueTag([In] long obj0, [In] long obj1, [In] string obj2, [In] string obj3)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamUGC.__\u003Cjniptr\u003EaddRequiredKeyValueTag\u0028JJLjava\u002Flang\u002FString\u003BLjava\u002Flang\u002FString\u003B\u0029Z == IntPtr.Zero)
        SteamUGC.__\u003Cjniptr\u003EaddRequiredKeyValueTag\u0028JJLjava\u002Flang\u002FString\u003BLjava\u002Flang\u002FString\u003B\u0029Z = JNI.Frame.GetFuncPtr(SteamUGC.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamUGC", nameof (addRequiredKeyValueTag), "(JJLjava/lang/String;Ljava/lang/String;)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamUGC.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamUGC>.Value);
        long num4 = obj0;
        long num5 = obj1;
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj2);
        IntPtr num7 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj3);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, long, long, IntPtr, IntPtr)>) SteamUGC.__\u003Cjniptr\u003EaddRequiredKeyValueTag\u0028JJLjava\u002Flang\u002FString\u003BLjava\u002Flang\u002FString\u003B\u0029Z)(num2, num3, num4, num5, num6, num7);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    private static long requestUGCDetails([In] long obj0, [In] long obj1, [In] long obj2, [In] int obj3)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamUGC.__\u003Cjniptr\u003ErequestUGCDetails\u0028JJJI\u0029J == IntPtr.Zero)
        SteamUGC.__\u003Cjniptr\u003ErequestUGCDetails\u0028JJJI\u0029J = JNI.Frame.GetFuncPtr(SteamUGC.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamUGC", nameof (requestUGCDetails), "(JJJI)J");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamUGC.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamUGC>.Value);
        long num4 = obj0;
        long num5 = obj1;
        long num6 = obj2;
        int num7 = obj3;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<long (IntPtr, IntPtr, long, long, long, int)>) SteamUGC.__\u003Cjniptr\u003ErequestUGCDetails\u0028JJJI\u0029J)((int) num2, (long) num3, num4, num5, (IntPtr) num6, (IntPtr) num7);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    private static long createItem([In] long obj0, [In] long obj1, [In] int obj2, [In] int obj3)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamUGC.__\u003Cjniptr\u003EcreateItem\u0028JJII\u0029J == IntPtr.Zero)
        SteamUGC.__\u003Cjniptr\u003EcreateItem\u0028JJII\u0029J = JNI.Frame.GetFuncPtr(SteamUGC.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamUGC", nameof (createItem), "(JJII)J");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamUGC.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamUGC>.Value);
        long num4 = obj0;
        long num5 = obj1;
        int num6 = obj2;
        int num7 = obj3;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<long (IntPtr, IntPtr, long, long, int, int)>) SteamUGC.__\u003Cjniptr\u003EcreateItem\u0028JJII\u0029J)((int) num2, (int) num3, num4, num5, (IntPtr) num6, (IntPtr) num7);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    private static long startItemUpdate([In] long obj0, [In] int obj1, [In] long obj2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamUGC.__\u003Cjniptr\u003EstartItemUpdate\u0028JIJ\u0029J == IntPtr.Zero)
        SteamUGC.__\u003Cjniptr\u003EstartItemUpdate\u0028JIJ\u0029J = JNI.Frame.GetFuncPtr(SteamUGC.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamUGC", nameof (startItemUpdate), "(JIJ)J");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamUGC.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamUGC>.Value);
        long num4 = obj0;
        int num5 = obj1;
        long num6 = obj2;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<long (IntPtr, IntPtr, long, int, long)>) SteamUGC.__\u003Cjniptr\u003EstartItemUpdate\u0028JIJ\u0029J)((long) num2, (int) num3, num4, (IntPtr) num5, (IntPtr) num6);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    private static bool setItemTitle([In] long obj0, [In] long obj1, [In] string obj2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamUGC.__\u003Cjniptr\u003EsetItemTitle\u0028JJLjava\u002Flang\u002FString\u003B\u0029Z == IntPtr.Zero)
        SteamUGC.__\u003Cjniptr\u003EsetItemTitle\u0028JJLjava\u002Flang\u002FString\u003B\u0029Z = JNI.Frame.GetFuncPtr(SteamUGC.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamUGC", nameof (setItemTitle), "(JJLjava/lang/String;)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamUGC.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamUGC>.Value);
        long num4 = obj0;
        long num5 = obj1;
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj2);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, long, long, IntPtr)>) SteamUGC.__\u003Cjniptr\u003EsetItemTitle\u0028JJLjava\u002Flang\u002FString\u003B\u0029Z)(num2, (long) num3, num4, (IntPtr) num5, num6);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    private static bool setItemDescription([In] long obj0, [In] long obj1, [In] string obj2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamUGC.__\u003Cjniptr\u003EsetItemDescription\u0028JJLjava\u002Flang\u002FString\u003B\u0029Z == IntPtr.Zero)
        SteamUGC.__\u003Cjniptr\u003EsetItemDescription\u0028JJLjava\u002Flang\u002FString\u003B\u0029Z = JNI.Frame.GetFuncPtr(SteamUGC.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamUGC", nameof (setItemDescription), "(JJLjava/lang/String;)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamUGC.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamUGC>.Value);
        long num4 = obj0;
        long num5 = obj1;
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj2);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, long, long, IntPtr)>) SteamUGC.__\u003Cjniptr\u003EsetItemDescription\u0028JJLjava\u002Flang\u002FString\u003B\u0029Z)(num2, (long) num3, num4, (IntPtr) num5, num6);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    private static bool setItemUpdateLanguage([In] long obj0, [In] long obj1, [In] string obj2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamUGC.__\u003Cjniptr\u003EsetItemUpdateLanguage\u0028JJLjava\u002Flang\u002FString\u003B\u0029Z == IntPtr.Zero)
        SteamUGC.__\u003Cjniptr\u003EsetItemUpdateLanguage\u0028JJLjava\u002Flang\u002FString\u003B\u0029Z = JNI.Frame.GetFuncPtr(SteamUGC.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamUGC", nameof (setItemUpdateLanguage), "(JJLjava/lang/String;)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamUGC.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamUGC>.Value);
        long num4 = obj0;
        long num5 = obj1;
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj2);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, long, long, IntPtr)>) SteamUGC.__\u003Cjniptr\u003EsetItemUpdateLanguage\u0028JJLjava\u002Flang\u002FString\u003B\u0029Z)(num2, (long) num3, num4, (IntPtr) num5, num6);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    private static bool setItemMetadata([In] long obj0, [In] long obj1, [In] string obj2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamUGC.__\u003Cjniptr\u003EsetItemMetadata\u0028JJLjava\u002Flang\u002FString\u003B\u0029Z == IntPtr.Zero)
        SteamUGC.__\u003Cjniptr\u003EsetItemMetadata\u0028JJLjava\u002Flang\u002FString\u003B\u0029Z = JNI.Frame.GetFuncPtr(SteamUGC.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamUGC", nameof (setItemMetadata), "(JJLjava/lang/String;)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamUGC.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamUGC>.Value);
        long num4 = obj0;
        long num5 = obj1;
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj2);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, long, long, IntPtr)>) SteamUGC.__\u003Cjniptr\u003EsetItemMetadata\u0028JJLjava\u002Flang\u002FString\u003B\u0029Z)(num2, (long) num3, num4, (IntPtr) num5, num6);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    private static bool setItemVisibility([In] long obj0, [In] long obj1, [In] int obj2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamUGC.__\u003Cjniptr\u003EsetItemVisibility\u0028JJI\u0029Z == IntPtr.Zero)
        SteamUGC.__\u003Cjniptr\u003EsetItemVisibility\u0028JJI\u0029Z = JNI.Frame.GetFuncPtr(SteamUGC.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamUGC", nameof (setItemVisibility), "(JJI)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamUGC.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamUGC>.Value);
        long num4 = obj0;
        long num5 = obj1;
        int num6 = obj2;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, long, long, int)>) SteamUGC.__\u003Cjniptr\u003EsetItemVisibility\u0028JJI\u0029Z)((int) num2, (long) num3, num4, (IntPtr) num5, (IntPtr) num6);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    private static bool setItemTags([In] long obj0, [In] long obj1, [In] string[] obj2, [In] int obj3)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamUGC.__\u003Cjniptr\u003EsetItemTags\u0028JJ\u005BLjava\u002Flang\u002FString\u003BI\u0029Z == IntPtr.Zero)
        SteamUGC.__\u003Cjniptr\u003EsetItemTags\u0028JJ\u005BLjava\u002Flang\u002FString\u003BI\u0029Z = JNI.Frame.GetFuncPtr(SteamUGC.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamUGC", nameof (setItemTags), "(JJ[Ljava/lang/String;I)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamUGC.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamUGC>.Value);
        long num4 = obj0;
        long num5 = obj1;
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj2);
        int num7 = obj3;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, long, long, IntPtr, int)>) SteamUGC.__\u003Cjniptr\u003EsetItemTags\u0028JJ\u005BLjava\u002Flang\u002FString\u003BI\u0029Z)((int) num2, num3, num4, num5, num6, (IntPtr) num7);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    private static bool setItemContent([In] long obj0, [In] long obj1, [In] string obj2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamUGC.__\u003Cjniptr\u003EsetItemContent\u0028JJLjava\u002Flang\u002FString\u003B\u0029Z == IntPtr.Zero)
        SteamUGC.__\u003Cjniptr\u003EsetItemContent\u0028JJLjava\u002Flang\u002FString\u003B\u0029Z = JNI.Frame.GetFuncPtr(SteamUGC.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamUGC", nameof (setItemContent), "(JJLjava/lang/String;)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamUGC.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamUGC>.Value);
        long num4 = obj0;
        long num5 = obj1;
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj2);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, long, long, IntPtr)>) SteamUGC.__\u003Cjniptr\u003EsetItemContent\u0028JJLjava\u002Flang\u002FString\u003B\u0029Z)(num2, (long) num3, num4, (IntPtr) num5, num6);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    private static bool setItemPreview([In] long obj0, [In] long obj1, [In] string obj2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamUGC.__\u003Cjniptr\u003EsetItemPreview\u0028JJLjava\u002Flang\u002FString\u003B\u0029Z == IntPtr.Zero)
        SteamUGC.__\u003Cjniptr\u003EsetItemPreview\u0028JJLjava\u002Flang\u002FString\u003B\u0029Z = JNI.Frame.GetFuncPtr(SteamUGC.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamUGC", nameof (setItemPreview), "(JJLjava/lang/String;)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamUGC.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamUGC>.Value);
        long num4 = obj0;
        long num5 = obj1;
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj2);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, long, long, IntPtr)>) SteamUGC.__\u003Cjniptr\u003EsetItemPreview\u0028JJLjava\u002Flang\u002FString\u003B\u0029Z)(num2, (long) num3, num4, (IntPtr) num5, num6);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    private static bool removeItemKeyValueTags([In] long obj0, [In] long obj1, [In] string obj2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamUGC.__\u003Cjniptr\u003EremoveItemKeyValueTags\u0028JJLjava\u002Flang\u002FString\u003B\u0029Z == IntPtr.Zero)
        SteamUGC.__\u003Cjniptr\u003EremoveItemKeyValueTags\u0028JJLjava\u002Flang\u002FString\u003B\u0029Z = JNI.Frame.GetFuncPtr(SteamUGC.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamUGC", nameof (removeItemKeyValueTags), "(JJLjava/lang/String;)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamUGC.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamUGC>.Value);
        long num4 = obj0;
        long num5 = obj1;
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj2);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, long, long, IntPtr)>) SteamUGC.__\u003Cjniptr\u003EremoveItemKeyValueTags\u0028JJLjava\u002Flang\u002FString\u003B\u0029Z)(num2, (long) num3, num4, (IntPtr) num5, num6);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    private static bool addItemKeyValueTag([In] long obj0, [In] long obj1, [In] string obj2, [In] string obj3)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamUGC.__\u003Cjniptr\u003EaddItemKeyValueTag\u0028JJLjava\u002Flang\u002FString\u003BLjava\u002Flang\u002FString\u003B\u0029Z == IntPtr.Zero)
        SteamUGC.__\u003Cjniptr\u003EaddItemKeyValueTag\u0028JJLjava\u002Flang\u002FString\u003BLjava\u002Flang\u002FString\u003B\u0029Z = JNI.Frame.GetFuncPtr(SteamUGC.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamUGC", nameof (addItemKeyValueTag), "(JJLjava/lang/String;Ljava/lang/String;)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamUGC.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamUGC>.Value);
        long num4 = obj0;
        long num5 = obj1;
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj2);
        IntPtr num7 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj3);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, long, long, IntPtr, IntPtr)>) SteamUGC.__\u003Cjniptr\u003EaddItemKeyValueTag\u0028JJLjava\u002Flang\u002FString\u003BLjava\u002Flang\u002FString\u003B\u0029Z)(num2, num3, num4, num5, num6, num7);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    private static long submitItemUpdate([In] long obj0, [In] long obj1, [In] long obj2, [In] string obj3)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamUGC.__\u003Cjniptr\u003EsubmitItemUpdate\u0028JJJLjava\u002Flang\u002FString\u003B\u0029J == IntPtr.Zero)
        SteamUGC.__\u003Cjniptr\u003EsubmitItemUpdate\u0028JJJLjava\u002Flang\u002FString\u003B\u0029J = JNI.Frame.GetFuncPtr(SteamUGC.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamUGC", nameof (submitItemUpdate), "(JJJLjava/lang/String;)J");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamUGC.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamUGC>.Value);
        long num4 = obj0;
        long num5 = obj1;
        long num6 = obj2;
        IntPtr num7 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj3);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<long (IntPtr, IntPtr, long, long, long, IntPtr)>) SteamUGC.__\u003Cjniptr\u003EsubmitItemUpdate\u0028JJJLjava\u002Flang\u002FString\u003B\u0029J)(num2, (long) num3, num4, num5, (IntPtr) num6, num7);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    private static int getItemUpdateProgress([In] long obj0, [In] long obj1, [In] long[] obj2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamUGC.__\u003Cjniptr\u003EgetItemUpdateProgress\u0028JJ\u005BJ\u0029I == IntPtr.Zero)
        SteamUGC.__\u003Cjniptr\u003EgetItemUpdateProgress\u0028JJ\u005BJ\u0029I = JNI.Frame.GetFuncPtr(SteamUGC.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamUGC", nameof (getItemUpdateProgress), "(JJ[J)I");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamUGC.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamUGC>.Value);
        long num4 = obj0;
        long num5 = obj1;
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj2);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<int (IntPtr, IntPtr, long, long, IntPtr)>) SteamUGC.__\u003Cjniptr\u003EgetItemUpdateProgress\u0028JJ\u005BJ\u0029I)(num2, (long) num3, num4, (IntPtr) num5, num6);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    private static long setUserItemVote([In] long obj0, [In] long obj1, [In] long obj2, [In] bool obj3)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamUGC.__\u003Cjniptr\u003EsetUserItemVote\u0028JJJZ\u0029J == IntPtr.Zero)
        SteamUGC.__\u003Cjniptr\u003EsetUserItemVote\u0028JJJZ\u0029J = JNI.Frame.GetFuncPtr(SteamUGC.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamUGC", nameof (setUserItemVote), "(JJJZ)J");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamUGC.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamUGC>.Value);
        long num4 = obj0;
        long num5 = obj1;
        long num6 = obj2;
        int num7 = obj3 ? 1 : 0;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<long (IntPtr, IntPtr, long, long, long, bool)>) SteamUGC.__\u003Cjniptr\u003EsetUserItemVote\u0028JJJZ\u0029J)((bool) num2, (long) num3, num4, num5, (IntPtr) num6, (IntPtr) num7);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    private static long getUserItemVote([In] long obj0, [In] long obj1, [In] long obj2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamUGC.__\u003Cjniptr\u003EgetUserItemVote\u0028JJJ\u0029J == IntPtr.Zero)
        SteamUGC.__\u003Cjniptr\u003EgetUserItemVote\u0028JJJ\u0029J = JNI.Frame.GetFuncPtr(SteamUGC.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamUGC", nameof (getUserItemVote), "(JJJ)J");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamUGC.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamUGC>.Value);
        long num4 = obj0;
        long num5 = obj1;
        long num6 = obj2;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<long (IntPtr, IntPtr, long, long, long)>) SteamUGC.__\u003Cjniptr\u003EgetUserItemVote\u0028JJJ\u0029J)((long) num2, (long) num3, num4, (IntPtr) num5, (IntPtr) num6);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    private static long addItemToFavorites([In] long obj0, [In] long obj1, [In] int obj2, [In] long obj3)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamUGC.__\u003Cjniptr\u003EaddItemToFavorites\u0028JJIJ\u0029J == IntPtr.Zero)
        SteamUGC.__\u003Cjniptr\u003EaddItemToFavorites\u0028JJIJ\u0029J = JNI.Frame.GetFuncPtr(SteamUGC.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamUGC", nameof (addItemToFavorites), "(JJIJ)J");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamUGC.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamUGC>.Value);
        long num4 = obj0;
        long num5 = obj1;
        int num6 = obj2;
        long num7 = obj3;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<long (IntPtr, IntPtr, long, long, int, long)>) SteamUGC.__\u003Cjniptr\u003EaddItemToFavorites\u0028JJIJ\u0029J)((long) num2, (int) num3, num4, num5, (IntPtr) num6, (IntPtr) num7);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    private static long removeItemFromFavorites([In] long obj0, [In] long obj1, [In] int obj2, [In] long obj3)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamUGC.__\u003Cjniptr\u003EremoveItemFromFavorites\u0028JJIJ\u0029J == IntPtr.Zero)
        SteamUGC.__\u003Cjniptr\u003EremoveItemFromFavorites\u0028JJIJ\u0029J = JNI.Frame.GetFuncPtr(SteamUGC.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamUGC", nameof (removeItemFromFavorites), "(JJIJ)J");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamUGC.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamUGC>.Value);
        long num4 = obj0;
        long num5 = obj1;
        int num6 = obj2;
        long num7 = obj3;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<long (IntPtr, IntPtr, long, long, int, long)>) SteamUGC.__\u003Cjniptr\u003EremoveItemFromFavorites\u0028JJIJ\u0029J)((long) num2, (int) num3, num4, num5, (IntPtr) num6, (IntPtr) num7);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    private static long subscribeItem([In] long obj0, [In] long obj1, [In] long obj2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamUGC.__\u003Cjniptr\u003EsubscribeItem\u0028JJJ\u0029J == IntPtr.Zero)
        SteamUGC.__\u003Cjniptr\u003EsubscribeItem\u0028JJJ\u0029J = JNI.Frame.GetFuncPtr(SteamUGC.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamUGC", nameof (subscribeItem), "(JJJ)J");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamUGC.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamUGC>.Value);
        long num4 = obj0;
        long num5 = obj1;
        long num6 = obj2;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<long (IntPtr, IntPtr, long, long, long)>) SteamUGC.__\u003Cjniptr\u003EsubscribeItem\u0028JJJ\u0029J)((long) num2, (long) num3, num4, (IntPtr) num5, (IntPtr) num6);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    private static long unsubscribeItem([In] long obj0, [In] long obj1, [In] long obj2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamUGC.__\u003Cjniptr\u003EunsubscribeItem\u0028JJJ\u0029J == IntPtr.Zero)
        SteamUGC.__\u003Cjniptr\u003EunsubscribeItem\u0028JJJ\u0029J = JNI.Frame.GetFuncPtr(SteamUGC.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamUGC", nameof (unsubscribeItem), "(JJJ)J");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamUGC.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamUGC>.Value);
        long num4 = obj0;
        long num5 = obj1;
        long num6 = obj2;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<long (IntPtr, IntPtr, long, long, long)>) SteamUGC.__\u003Cjniptr\u003EunsubscribeItem\u0028JJJ\u0029J)((long) num2, (long) num3, num4, (IntPtr) num5, (IntPtr) num6);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    private static int getNumSubscribedItems([In] long obj0)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamUGC.__\u003Cjniptr\u003EgetNumSubscribedItems\u0028J\u0029I == IntPtr.Zero)
        SteamUGC.__\u003Cjniptr\u003EgetNumSubscribedItems\u0028J\u0029I = JNI.Frame.GetFuncPtr(SteamUGC.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamUGC", nameof (getNumSubscribedItems), "(J)I");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamUGC.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamUGC>.Value);
        long num4 = obj0;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<int (IntPtr, IntPtr, long)>) SteamUGC.__\u003Cjniptr\u003EgetNumSubscribedItems\u0028J\u0029I)((long) num2, num3, (IntPtr) num4);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    private static int getSubscribedItems([In] long obj0, [In] long[] obj1, [In] int obj2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamUGC.__\u003Cjniptr\u003EgetSubscribedItems\u0028J\u005BJI\u0029I == IntPtr.Zero)
        SteamUGC.__\u003Cjniptr\u003EgetSubscribedItems\u0028J\u005BJI\u0029I = JNI.Frame.GetFuncPtr(SteamUGC.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamUGC", nameof (getSubscribedItems), "(J[JI)I");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamUGC.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamUGC>.Value);
        long num4 = obj0;
        IntPtr num5 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj1);
        int num6 = obj2;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<int (IntPtr, IntPtr, long, IntPtr, int)>) SteamUGC.__\u003Cjniptr\u003EgetSubscribedItems\u0028J\u005BJI\u0029I)((int) num2, num3, num4, num5, (IntPtr) num6);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    private static int getItemState([In] long obj0, [In] long obj1)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamUGC.__\u003Cjniptr\u003EgetItemState\u0028JJ\u0029I == IntPtr.Zero)
        SteamUGC.__\u003Cjniptr\u003EgetItemState\u0028JJ\u0029I = JNI.Frame.GetFuncPtr(SteamUGC.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamUGC", nameof (getItemState), "(JJ)I");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamUGC.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamUGC>.Value);
        long num4 = obj0;
        long num5 = obj1;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<int (IntPtr, IntPtr, long, long)>) SteamUGC.__\u003Cjniptr\u003EgetItemState\u0028JJ\u0029I)((long) num2, (long) num3, (IntPtr) num4, (IntPtr) num5);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    private static bool getItemInstallInfo([In] long obj0, [In] long obj1, [In] SteamUGC.ItemInstallInfo obj2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamUGC.__\u003Cjniptr\u003EgetItemInstallInfo\u0028JJLcom\u002Fcodedisaster\u002Fsteamworks\u002FSteamUGC\u0024ItemInstallInfo\u003B\u0029Z == IntPtr.Zero)
        SteamUGC.__\u003Cjniptr\u003EgetItemInstallInfo\u0028JJLcom\u002Fcodedisaster\u002Fsteamworks\u002FSteamUGC\u0024ItemInstallInfo\u003B\u0029Z = JNI.Frame.GetFuncPtr(SteamUGC.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamUGC", nameof (getItemInstallInfo), "(JJLcom/codedisaster/steamworks/SteamUGC$ItemInstallInfo;)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamUGC.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamUGC>.Value);
        long num4 = obj0;
        long num5 = obj1;
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj2);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, long, long, IntPtr)>) SteamUGC.__\u003Cjniptr\u003EgetItemInstallInfo\u0028JJLcom\u002Fcodedisaster\u002Fsteamworks\u002FSteamUGC\u0024ItemInstallInfo\u003B\u0029Z)(num2, (long) num3, num4, (IntPtr) num5, num6);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    private static bool getItemDownloadInfo([In] long obj0, [In] long obj1, [In] long[] obj2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamUGC.__\u003Cjniptr\u003EgetItemDownloadInfo\u0028JJ\u005BJ\u0029Z == IntPtr.Zero)
        SteamUGC.__\u003Cjniptr\u003EgetItemDownloadInfo\u0028JJ\u005BJ\u0029Z = JNI.Frame.GetFuncPtr(SteamUGC.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamUGC", nameof (getItemDownloadInfo), "(JJ[J)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamUGC.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamUGC>.Value);
        long num4 = obj0;
        long num5 = obj1;
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj2);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, long, long, IntPtr)>) SteamUGC.__\u003Cjniptr\u003EgetItemDownloadInfo\u0028JJ\u005BJ\u0029Z)(num2, (long) num3, num4, (IntPtr) num5, num6);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    private static long deleteItem([In] long obj0, [In] long obj1, [In] long obj2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamUGC.__\u003Cjniptr\u003EdeleteItem\u0028JJJ\u0029J == IntPtr.Zero)
        SteamUGC.__\u003Cjniptr\u003EdeleteItem\u0028JJJ\u0029J = JNI.Frame.GetFuncPtr(SteamUGC.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamUGC", nameof (deleteItem), "(JJJ)J");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamUGC.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamUGC>.Value);
        long num4 = obj0;
        long num5 = obj1;
        long num6 = obj2;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<long (IntPtr, IntPtr, long, long, long)>) SteamUGC.__\u003Cjniptr\u003EdeleteItem\u0028JJJ\u0029J)((long) num2, (long) num3, num4, (IntPtr) num5, (IntPtr) num6);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    private static bool downloadItem([In] long obj0, [In] long obj1, [In] bool obj2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamUGC.__\u003Cjniptr\u003EdownloadItem\u0028JJZ\u0029Z == IntPtr.Zero)
        SteamUGC.__\u003Cjniptr\u003EdownloadItem\u0028JJZ\u0029Z = JNI.Frame.GetFuncPtr(SteamUGC.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamUGC", nameof (downloadItem), "(JJZ)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamUGC.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamUGC>.Value);
        long num4 = obj0;
        long num5 = obj1;
        int num6 = obj2 ? 1 : 0;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, long, long, bool)>) SteamUGC.__\u003Cjniptr\u003EdownloadItem\u0028JJZ\u0029Z)((bool) num2, (long) num3, num4, (IntPtr) num5, (IntPtr) num6);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    private static bool initWorkshopForGameServer([In] long obj0, [In] int obj1, [In] string obj2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamUGC.__\u003Cjniptr\u003EinitWorkshopForGameServer\u0028JILjava\u002Flang\u002FString\u003B\u0029Z == IntPtr.Zero)
        SteamUGC.__\u003Cjniptr\u003EinitWorkshopForGameServer\u0028JILjava\u002Flang\u002FString\u003B\u0029Z = JNI.Frame.GetFuncPtr(SteamUGC.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamUGC", nameof (initWorkshopForGameServer), "(JILjava/lang/String;)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamUGC.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamUGC>.Value);
        long num4 = obj0;
        int num5 = obj1;
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj2);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, long, int, IntPtr)>) SteamUGC.__\u003Cjniptr\u003EinitWorkshopForGameServer\u0028JILjava\u002Flang\u002FString\u003B\u0029Z)(num2, (int) num3, num4, (IntPtr) num5, num6);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    private static void suspendDownloads([In] long obj0, [In] bool obj1)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamUGC.__\u003Cjniptr\u003EsuspendDownloads\u0028JZ\u0029V == IntPtr.Zero)
        SteamUGC.__\u003Cjniptr\u003EsuspendDownloads\u0028JZ\u0029V = JNI.Frame.GetFuncPtr(SteamUGC.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamUGC", nameof (suspendDownloads), "(JZ)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamUGC.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamUGC>.Value);
        long num4 = obj0;
        int num5 = obj1 ? 1 : 0;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, long, bool)>) SteamUGC.__\u003Cjniptr\u003EsuspendDownloads\u0028JZ\u0029V)((bool) num2, (long) num3, (IntPtr) num4, (IntPtr) num5);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    private static long startPlaytimeTracking([In] long obj0, [In] long obj1, [In] long[] obj2, [In] int obj3)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamUGC.__\u003Cjniptr\u003EstartPlaytimeTracking\u0028JJ\u005BJI\u0029J == IntPtr.Zero)
        SteamUGC.__\u003Cjniptr\u003EstartPlaytimeTracking\u0028JJ\u005BJI\u0029J = JNI.Frame.GetFuncPtr(SteamUGC.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamUGC", nameof (startPlaytimeTracking), "(JJ[JI)J");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamUGC.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamUGC>.Value);
        long num4 = obj0;
        long num5 = obj1;
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj2);
        int num7 = obj3;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<long (IntPtr, IntPtr, long, long, IntPtr, int)>) SteamUGC.__\u003Cjniptr\u003EstartPlaytimeTracking\u0028JJ\u005BJI\u0029J)((int) num2, num3, num4, num5, num6, (IntPtr) num7);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    private static long stopPlaytimeTracking([In] long obj0, [In] long obj1, [In] long[] obj2, [In] int obj3)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamUGC.__\u003Cjniptr\u003EstopPlaytimeTracking\u0028JJ\u005BJI\u0029J == IntPtr.Zero)
        SteamUGC.__\u003Cjniptr\u003EstopPlaytimeTracking\u0028JJ\u005BJI\u0029J = JNI.Frame.GetFuncPtr(SteamUGC.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamUGC", nameof (stopPlaytimeTracking), "(JJ[JI)J");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamUGC.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamUGC>.Value);
        long num4 = obj0;
        long num5 = obj1;
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj2);
        int num7 = obj3;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<long (IntPtr, IntPtr, long, long, IntPtr, int)>) SteamUGC.__\u003Cjniptr\u003EstopPlaytimeTracking\u0028JJ\u005BJI\u0029J)((int) num2, num3, num4, num5, num6, (IntPtr) num7);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    private static long stopPlaytimeTrackingForAllItems([In] long obj0, [In] long obj1)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamUGC.__\u003Cjniptr\u003EstopPlaytimeTrackingForAllItems\u0028JJ\u0029J == IntPtr.Zero)
        SteamUGC.__\u003Cjniptr\u003EstopPlaytimeTrackingForAllItems\u0028JJ\u0029J = JNI.Frame.GetFuncPtr(SteamUGC.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamUGC", nameof (stopPlaytimeTrackingForAllItems), "(JJ)J");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamUGC.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamUGC>.Value);
        long num4 = obj0;
        long num5 = obj1;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<long (IntPtr, IntPtr, long, long)>) SteamUGC.__\u003Cjniptr\u003EstopPlaytimeTrackingForAllItems\u0028JJ\u0029J)((long) num2, (long) num3, (IntPtr) num4, (IntPtr) num5);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [LineNumberTable(new byte[] {160, 114, 110, 50})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual SteamUGCQuery createQueryUserUGCRequest(
      int accountID,
      SteamUGC.UserUGCList listType,
      SteamUGC.MatchingUGCType matchingType,
      SteamUGC.UserUGCListSortOrder sortOrder,
      int creatorAppID,
      int consumerAppID,
      int page)
    {
      return new SteamUGCQuery(SteamUGC.createQueryUserUGCRequest(this.pointer, accountID, listType.ordinal(), SteamUGC.MatchingUGCType.access\u0024000(matchingType), sortOrder.ordinal(), creatorAppID, consumerAppID, page));
    }

    [LineNumberTable(235)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual SteamUGCQuery createQueryAllUGCRequest(
      SteamUGC.UGCQueryType queryType,
      SteamUGC.MatchingUGCType matchingType,
      int creatorAppID,
      int consumerAppID,
      int page)
    {
      return new SteamUGCQuery(SteamUGC.createQueryAllUGCRequest(this.pointer, queryType.ordinal(), SteamUGC.MatchingUGCType.access\u0024000(matchingType), creatorAppID, consumerAppID, page));
    }

    [Signature("(Ljava/util/Collection<Lcom/codedisaster/steamworks/SteamPublishedFileID;>;)Lcom/codedisaster/steamworks/SteamUGCQuery;")]
    [LineNumberTable(new byte[] {160, 132, 103, 135, 98, 124, 110, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual SteamUGCQuery createQueryUGCDetailsRequest(
      Collection publishedFileIDs)
    {
      int length = publishedFileIDs.size();
      long[] numArray1 = new long[length];
      int num = 0;
      Iterator iterator = publishedFileIDs.iterator();
      while (iterator.hasNext())
      {
        SteamPublishedFileID steamPublishedFileId = (SteamPublishedFileID) iterator.next();
        long[] numArray2 = numArray1;
        int index = num;
        ++num;
        long handle = steamPublishedFileId.handle;
        numArray2[index] = handle;
      }
      return new SteamUGCQuery(SteamUGC.createQueryUGCDetailsRequest(this.pointer, numArray1, length));
    }

    [LineNumberTable(266)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string getQueryUGCPreviewURL(SteamUGCQuery query, int index) => SteamUGC.getQueryUGCPreviewURL(this.pointer, query.handle, index);

    [LineNumberTable(270)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string getQueryUGCMetadata(SteamUGCQuery query, int index) => SteamUGC.getQueryUGCMetadata(this.pointer, query.handle, index);

    [LineNumberTable(274)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual long getQueryUGCStatistic(
      SteamUGCQuery query,
      int index,
      SteamUGC.ItemStatistic statType)
    {
      return SteamUGC.getQueryUGCStatistic(this.pointer, query.handle, index, statType.ordinal());
    }

    [LineNumberTable(278)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getQueryUGCNumAdditionalPreviews(SteamUGCQuery query, int index) => SteamUGC.getQueryUGCNumAdditionalPreviews(this.pointer, query.handle, index);

    [LineNumberTable(284)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool getQueryUGCAdditionalPreview(
      SteamUGCQuery query,
      int index,
      int previewIndex,
      SteamUGC.ItemAdditionalPreview previewInfo)
    {
      return SteamUGC.getQueryUGCAdditionalPreview(this.pointer, query.handle, index, previewIndex, previewInfo);
    }

    [LineNumberTable(288)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getQueryUGCNumKeyValueTags(SteamUGCQuery query, int index) => SteamUGC.getQueryUGCNumKeyValueTags(this.pointer, query.handle, index);

    [LineNumberTable(292)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool getQueryUGCKeyValueTag(
      SteamUGCQuery query,
      int index,
      int keyValueTagIndex,
      string[] keyAndValue)
    {
      return SteamUGC.getQueryUGCKeyValueTag(this.pointer, query.handle, index, keyValueTagIndex, keyAndValue);
    }

    [LineNumberTable(296)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool releaseQueryUserUGCRequest(SteamUGCQuery query) => SteamUGC.releaseQueryUserUGCRequest(this.pointer, query.handle);

    [LineNumberTable(300)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool addRequiredTag(SteamUGCQuery query, string tagName) => SteamUGC.addRequiredTag(this.pointer, query.handle, tagName);

    [LineNumberTable(304)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool addExcludedTag(SteamUGCQuery query, string tagName) => SteamUGC.addExcludedTag(this.pointer, query.handle, tagName);

    [LineNumberTable(308)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool setReturnOnlyIDs(SteamUGCQuery query, bool returnOnlyIDs)
    {
      int num = returnOnlyIDs ? 1 : 0;
      return SteamUGC.setReturnOnlyIDs(this.pointer, query.handle, num != 0);
    }

    [LineNumberTable(312)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool setReturnKeyValueTags(SteamUGCQuery query, bool returnKeyValueTags)
    {
      int num = returnKeyValueTags ? 1 : 0;
      return SteamUGC.setReturnKeyValueTags(this.pointer, query.handle, num != 0);
    }

    [LineNumberTable(316)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool setReturnLongDescription(SteamUGCQuery query, bool returnLongDescription)
    {
      int num = returnLongDescription ? 1 : 0;
      return SteamUGC.setReturnLongDescription(this.pointer, query.handle, num != 0);
    }

    [LineNumberTable(320)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool setReturnMetadata(SteamUGCQuery query, bool returnMetadata)
    {
      int num = returnMetadata ? 1 : 0;
      return SteamUGC.setReturnMetadata(this.pointer, query.handle, num != 0);
    }

    [LineNumberTable(324)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool setReturnChildren(SteamUGCQuery query, bool returnChildren)
    {
      int num = returnChildren ? 1 : 0;
      return SteamUGC.setReturnChildren(this.pointer, query.handle, num != 0);
    }

    [LineNumberTable(328)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool setReturnAdditionalPreviews(
      SteamUGCQuery query,
      bool returnAdditionalPreviews)
    {
      int num = returnAdditionalPreviews ? 1 : 0;
      return SteamUGC.setReturnAdditionalPreviews(this.pointer, query.handle, num != 0);
    }

    [LineNumberTable(332)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool setReturnTotalOnly(SteamUGCQuery query, bool returnTotalOnly)
    {
      int num = returnTotalOnly ? 1 : 0;
      return SteamUGC.setReturnTotalOnly(this.pointer, query.handle, num != 0);
    }

    [LineNumberTable(336)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool setReturnPlaytimeStats(SteamUGCQuery query, int days) => SteamUGC.setReturnPlaytimeStats(this.pointer, query.handle, days);

    [LineNumberTable(340)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool setLanguage(SteamUGCQuery query, string language) => SteamUGC.setLanguage(this.pointer, query.handle, language);

    [LineNumberTable(344)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool setAllowCachedResponse(SteamUGCQuery query, int maxAgeSeconds) => SteamUGC.setAllowCachedResponse(this.pointer, query.handle, maxAgeSeconds);

    [LineNumberTable(348)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool setCloudFileNameFilter(SteamUGCQuery query, string matchCloudFileName) => SteamUGC.setCloudFileNameFilter(this.pointer, query.handle, matchCloudFileName);

    [LineNumberTable(352)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool setMatchAnyTag(SteamUGCQuery query, bool matchAnyTag)
    {
      int num = matchAnyTag ? 1 : 0;
      return SteamUGC.setMatchAnyTag(this.pointer, query.handle, num != 0);
    }

    [LineNumberTable(356)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool setSearchText(SteamUGCQuery query, string searchText) => SteamUGC.setSearchText(this.pointer, query.handle, searchText);

    [LineNumberTable(360)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool setRankedByTrendDays(SteamUGCQuery query, int days) => SteamUGC.setRankedByTrendDays(this.pointer, query.handle, days);

    [LineNumberTable(364)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool addRequiredKeyValueTag(SteamUGCQuery query, string key, string value) => SteamUGC.addRequiredKeyValueTag(this.pointer, query.handle, key, value);

    [Obsolete]
    [LineNumberTable(369)]
    [Deprecated(new object[] {64, "Ljava/lang/Deprecated;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual SteamAPICall requestUGCDetails(
      SteamPublishedFileID publishedFileID,
      int maxAgeSeconds)
    {
      return new SteamAPICall(SteamUGC.requestUGCDetails(this.pointer, this.callback, publishedFileID.handle, maxAgeSeconds));
    }

    [LineNumberTable(389)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool setItemUpdateLanguage(SteamUGCUpdateHandle update, string language) => SteamUGC.setItemUpdateLanguage(this.pointer, update.handle, language);

    [LineNumberTable(393)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool setItemMetadata(SteamUGCUpdateHandle update, string metaData) => SteamUGC.setItemMetadata(this.pointer, update.handle, metaData);

    [LineNumberTable(415)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool removeItemKeyValueTags(SteamUGCUpdateHandle update, string key) => SteamUGC.removeItemKeyValueTags(this.pointer, update.handle, key);

    [LineNumberTable(419)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool addItemKeyValueTag(SteamUGCUpdateHandle update, string key, string value) => SteamUGC.addItemKeyValueTag(this.pointer, update.handle, key, value);

    [LineNumberTable(435)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual SteamAPICall setUserItemVote(
      SteamPublishedFileID publishedFileID,
      bool voteUp)
    {
      int num = voteUp ? 1 : 0;
      return new SteamAPICall(SteamUGC.setUserItemVote(this.pointer, this.callback, publishedFileID.handle, num != 0));
    }

    [LineNumberTable(439)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual SteamAPICall getUserItemVote(SteamPublishedFileID publishedFileID) => new SteamAPICall(SteamUGC.getUserItemVote(this.pointer, this.callback, publishedFileID.handle));

    [LineNumberTable(443)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual SteamAPICall addItemToFavorites(
      int appID,
      SteamPublishedFileID publishedFileID)
    {
      return new SteamAPICall(SteamUGC.addItemToFavorites(this.pointer, this.callback, appID, publishedFileID.handle));
    }

    [LineNumberTable(447)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual SteamAPICall removeItemFromFavorites(
      int appID,
      SteamPublishedFileID publishedFileID)
    {
      return new SteamAPICall(SteamUGC.removeItemFromFavorites(this.pointer, this.callback, appID, publishedFileID.handle));
    }

    [LineNumberTable(451)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual SteamAPICall subscribeItem(SteamPublishedFileID publishedFileID) => new SteamAPICall(SteamUGC.subscribeItem(this.pointer, this.callback, publishedFileID.handle));

    [LineNumberTable(455)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual SteamAPICall unsubscribeItem(SteamPublishedFileID publishedFileID) => new SteamAPICall(SteamUGC.unsubscribeItem(this.pointer, this.callback, publishedFileID.handle));

    [Signature("(Lcom/codedisaster/steamworks/SteamPublishedFileID;)Ljava/util/Collection<Lcom/codedisaster/steamworks/SteamUGC$ItemState;>;")]
    [LineNumberTable(474)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Collection getItemState(SteamPublishedFileID publishedFileID) => SteamUGC.ItemState.fromBits(SteamUGC.getItemState(this.pointer, publishedFileID.handle));

    [LineNumberTable(new byte[] {161, 112, 103, 116, 105, 105, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool getItemDownloadInfo(
      SteamPublishedFileID publishedFileID,
      SteamUGC.ItemDownloadInfo downloadInfo)
    {
      long[] numArray = new long[2];
      if (!SteamUGC.getItemDownloadInfo(this.pointer, publishedFileID.handle, numArray))
        return false;
      downloadInfo.bytesDownloaded = numArray[0];
      downloadInfo.bytesTotal = numArray[1];
      return true;
    }

    [LineNumberTable(492)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual SteamAPICall deleteItem(SteamPublishedFileID publishedFileID) => new SteamAPICall(SteamUGC.deleteItem(this.pointer, this.callback, publishedFileID.handle));

    [LineNumberTable(496)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool downloadItem(SteamPublishedFileID publishedFileID, bool highPriority)
    {
      int num = highPriority ? 1 : 0;
      return SteamUGC.downloadItem(this.pointer, publishedFileID.handle, num != 0);
    }

    [LineNumberTable(500)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool initWorkshopForGameServer(int workshopDepotID, string folder) => SteamUGC.initWorkshopForGameServer(this.pointer, workshopDepotID, folder);

    [LineNumberTable(new byte[] {159, 16, 66, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void suspendDownloads(bool suspend) => SteamUGC.suspendDownloads(this.pointer, suspend);

    [LineNumberTable(new byte[] {161, 138, 136, 103, 43, 198})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual SteamAPICall startPlaytimeTracking(
      SteamPublishedFileID[] publishedFileIDs)
    {
      long[] numArray = new long[publishedFileIDs.Length];
      for (int index = 0; index < numArray.Length; ++index)
        numArray[index] = publishedFileIDs[index].handle;
      return new SteamAPICall(SteamUGC.startPlaytimeTracking(this.pointer, this.callback, numArray, numArray.Length));
    }

    [LineNumberTable(new byte[] {161, 148, 136, 103, 43, 198})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual SteamAPICall stopPlaytimeTracking(
      SteamPublishedFileID[] publishedFileIDs)
    {
      long[] numArray = new long[publishedFileIDs.Length];
      for (int index = 0; index < numArray.Length; ++index)
        numArray[index] = publishedFileIDs[index].handle;
      return new SteamAPICall(SteamUGC.stopPlaytimeTracking(this.pointer, this.callback, numArray, numArray.Length));
    }

    [LineNumberTable(528)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual SteamAPICall stopPlaytimeTrackingForAllItems() => new SteamAPICall(SteamUGC.stopPlaytimeTrackingForAllItems(this.pointer, this.callback));

    [Modifiers]
    [LineNumberTable(5)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void dispose() => base.dispose();

    new static CallerID __\u003CGetCallerID\u003E()
    {
      if (SteamUGC.__\u003CcallerID\u003E == null)
        SteamUGC.__\u003CcallerID\u003E = (CallerID) new SteamUGC.__\u003CCallerID\u003E();
      return SteamUGC.__\u003CcallerID\u003E;
    }

    [HideFromJava]
    protected internal long pointer
    {
      [HideFromJava] get => this.pointer;
    }

    [HideFromJava]
    protected internal long callback
    {
      [HideFromJava] get => this.callback;
      [HideFromJava] [param: In] set => this.callback = value;
    }

    [HideFromJava]
    [NameSig("<accessstub>0|deleteCallback", "(J)V")]
    protected internal new static void deleteCallback([In] long obj0) => SteamInterface.deleteCallback(obj0);

    public class ItemAdditionalPreview : Object
    {
      private string urlOrVideoID;
      private string originalFileName;
      private int previewType;

      [LineNumberTable(202)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public ItemAdditionalPreview()
      {
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual string getUrlOrVideoID() => this.urlOrVideoID;

      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual string getOriginalFileName() => this.originalFileName;

      [LineNumberTable(216)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual SteamUGC.ItemPreviewType getPreviewType() => SteamUGC.ItemPreviewType.byValue(this.previewType);
    }

    public class ItemDownloadInfo : Object
    {
      internal long bytesDownloaded;
      internal long bytesTotal;

      [LineNumberTable(188)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public ItemDownloadInfo()
      {
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual long getBytesDownloaded() => this.bytesDownloaded;

      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual long getBytesTotal() => this.bytesTotal;
    }

    public class ItemInstallInfo : Object
    {
      private string folder;
      private int sizeOnDisk;

      [LineNumberTable(175)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public ItemInstallInfo()
      {
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual string getFolder() => this.folder;

      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual int getSizeOnDisk() => this.sizeOnDisk;
    }

    [InnerClass]
    [Signature("Ljava/lang/Enum<Lcom/codedisaster/steamworks/SteamUGC$ItemPreviewType;>;")]
    [Modifiers]
    [Serializable]
    public sealed class ItemPreviewType : Enum
    {
      [Modifiers]
      internal static SteamUGC.ItemPreviewType __\u003C\u003EImage;
      [Modifiers]
      internal static SteamUGC.ItemPreviewType __\u003C\u003EYouTubeVideo;
      [Modifiers]
      internal static SteamUGC.ItemPreviewType __\u003C\u003ESketchfab;
      [Modifiers]
      internal static SteamUGC.ItemPreviewType __\u003C\u003EEnvironmentMap_HorizontalCross;
      [Modifiers]
      internal static SteamUGC.ItemPreviewType __\u003C\u003EEnvironmentMap_LatLong;
      [Modifiers]
      internal static SteamUGC.ItemPreviewType __\u003C\u003EReservedMax;
      [Modifiers]
      internal static SteamUGC.ItemPreviewType __\u003C\u003EUnknownPreviewType_NotImplementedByAPI;
      [Modifiers]
      private int value;
      [Modifiers]
      private static SteamUGC.ItemPreviewType[] values;
      [Modifiers]
      private static SteamUGC.ItemPreviewType[] \u0024VALUES;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {115, 115, 105, 2, 230, 69})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal static SteamUGC.ItemPreviewType byValue([In] int obj0)
      {
        SteamUGC.ItemPreviewType[] values = SteamUGC.ItemPreviewType.values;
        int length = values.Length;
        for (int index = 0; index < length; ++index)
        {
          SteamUGC.ItemPreviewType itemPreviewType = values[index];
          if (itemPreviewType.value == obj0)
            return itemPreviewType;
        }
        return SteamUGC.ItemPreviewType.__\u003C\u003EUnknownPreviewType_NotImplementedByAPI;
      }

      [Signature("(I)V")]
      [LineNumberTable(new byte[] {110, 106, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private ItemPreviewType([In] string obj0, [In] int obj1, [In] int obj2)
        : base(obj0, obj1)
      {
        SteamUGC.ItemPreviewType itemPreviewType = this;
        this.value = obj2;
        GC.KeepAlive((object) this);
      }

      [LineNumberTable(147)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static SteamUGC.ItemPreviewType[] values() => (SteamUGC.ItemPreviewType[]) SteamUGC.ItemPreviewType.\u0024VALUES.Clone();

      [LineNumberTable(147)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static SteamUGC.ItemPreviewType valueOf(string name) => (SteamUGC.ItemPreviewType) Enum.valueOf((Class) ClassLiteral<SteamUGC.ItemPreviewType>.Value, name);

      [LineNumberTable(new byte[] {159, 105, 77, 113, 113, 113, 113, 113, 149, 241, 56, 255, 36, 75})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static ItemPreviewType()
      {
        if (ByteCodeHelper.isAlreadyInited("com.codedisaster.steamworks.SteamUGC$ItemPreviewType"))
          return;
        SteamUGC.ItemPreviewType.__\u003C\u003EImage = new SteamUGC.ItemPreviewType(nameof (Image), 0, 0);
        SteamUGC.ItemPreviewType.__\u003C\u003EYouTubeVideo = new SteamUGC.ItemPreviewType(nameof (YouTubeVideo), 1, 1);
        SteamUGC.ItemPreviewType.__\u003C\u003ESketchfab = new SteamUGC.ItemPreviewType(nameof (Sketchfab), 2, 2);
        SteamUGC.ItemPreviewType.__\u003C\u003EEnvironmentMap_HorizontalCross = new SteamUGC.ItemPreviewType(nameof (EnvironmentMap_HorizontalCross), 3, 3);
        SteamUGC.ItemPreviewType.__\u003C\u003EEnvironmentMap_LatLong = new SteamUGC.ItemPreviewType(nameof (EnvironmentMap_LatLong), 4, 4);
        SteamUGC.ItemPreviewType.__\u003C\u003EReservedMax = new SteamUGC.ItemPreviewType(nameof (ReservedMax), 5, (int) byte.MaxValue);
        SteamUGC.ItemPreviewType.__\u003C\u003EUnknownPreviewType_NotImplementedByAPI = new SteamUGC.ItemPreviewType(nameof (UnknownPreviewType_NotImplementedByAPI), 6, -1);
        SteamUGC.ItemPreviewType.\u0024VALUES = new SteamUGC.ItemPreviewType[7]
        {
          SteamUGC.ItemPreviewType.__\u003C\u003EImage,
          SteamUGC.ItemPreviewType.__\u003C\u003EYouTubeVideo,
          SteamUGC.ItemPreviewType.__\u003C\u003ESketchfab,
          SteamUGC.ItemPreviewType.__\u003C\u003EEnvironmentMap_HorizontalCross,
          SteamUGC.ItemPreviewType.__\u003C\u003EEnvironmentMap_LatLong,
          SteamUGC.ItemPreviewType.__\u003C\u003EReservedMax,
          SteamUGC.ItemPreviewType.__\u003C\u003EUnknownPreviewType_NotImplementedByAPI
        };
        SteamUGC.ItemPreviewType.values = SteamUGC.ItemPreviewType.values();
      }

      [Modifiers]
      public static SteamUGC.ItemPreviewType Image
      {
        [HideFromJava] get => SteamUGC.ItemPreviewType.__\u003C\u003EImage;
      }

      [Modifiers]
      public static SteamUGC.ItemPreviewType YouTubeVideo
      {
        [HideFromJava] get => SteamUGC.ItemPreviewType.__\u003C\u003EYouTubeVideo;
      }

      [Modifiers]
      public static SteamUGC.ItemPreviewType Sketchfab
      {
        [HideFromJava] get => SteamUGC.ItemPreviewType.__\u003C\u003ESketchfab;
      }

      [Modifiers]
      public static SteamUGC.ItemPreviewType EnvironmentMap_HorizontalCross
      {
        [HideFromJava] get => SteamUGC.ItemPreviewType.__\u003C\u003EEnvironmentMap_HorizontalCross;
      }

      [Modifiers]
      public static SteamUGC.ItemPreviewType EnvironmentMap_LatLong
      {
        [HideFromJava] get => SteamUGC.ItemPreviewType.__\u003C\u003EEnvironmentMap_LatLong;
      }

      [Modifiers]
      public static SteamUGC.ItemPreviewType ReservedMax
      {
        [HideFromJava] get => SteamUGC.ItemPreviewType.__\u003C\u003EReservedMax;
      }

      [Modifiers]
      public static SteamUGC.ItemPreviewType UnknownPreviewType_NotImplementedByAPI
      {
        [HideFromJava] get => SteamUGC.ItemPreviewType.__\u003C\u003EUnknownPreviewType_NotImplementedByAPI;
      }

      [HideFromJava]
      [Serializable]
      public enum __Enum
      {
        Image,
        YouTubeVideo,
        Sketchfab,
        EnvironmentMap_HorizontalCross,
        EnvironmentMap_LatLong,
        ReservedMax,
        UnknownPreviewType_NotImplementedByAPI,
      }
    }

    [InnerClass]
    [Signature("Ljava/lang/Enum<Lcom/codedisaster/steamworks/SteamUGC$ItemState;>;")]
    [Modifiers]
    [Serializable]
    public sealed class ItemState : Enum
    {
      [Modifiers]
      internal static SteamUGC.ItemState __\u003C\u003ENone;
      [Modifiers]
      internal static SteamUGC.ItemState __\u003C\u003ESubscribed;
      [Modifiers]
      internal static SteamUGC.ItemState __\u003C\u003ELegacyItem;
      [Modifiers]
      internal static SteamUGC.ItemState __\u003C\u003EInstalled;
      [Modifiers]
      internal static SteamUGC.ItemState __\u003C\u003ENeedsUpdate;
      [Modifiers]
      internal static SteamUGC.ItemState __\u003C\u003EDownloading;
      [Modifiers]
      internal static SteamUGC.ItemState __\u003C\u003EDownloadPending;
      [Modifiers]
      private int bits;
      [Modifiers]
      private static SteamUGC.ItemState[] values;
      [Modifiers]
      private static SteamUGC.ItemState[] \u0024VALUES;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [Signature("(I)Ljava/util/Collection<Lcom/codedisaster/steamworks/SteamUGC$ItemState;>;")]
      [LineNumberTable(new byte[] {69, 139, 116, 114, 9, 230, 70})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal static Collection fromBits([In] int obj0)
      {
        EnumSet enumSet = EnumSet.noneOf((Class) ClassLiteral<SteamUGC.ItemState>.Value);
        SteamUGC.ItemState[] values = SteamUGC.ItemState.values;
        int length = values.Length;
        for (int index = 0; index < length; ++index)
        {
          SteamUGC.ItemState itemState = values[index];
          if ((obj0 & itemState.bits) == itemState.bits)
            ((AbstractCollection) enumSet).add((object) itemState);
        }
        return (Collection) enumSet;
      }

      [Signature("(I)V")]
      [LineNumberTable(new byte[] {64, 106, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private ItemState([In] string obj0, [In] int obj1, [In] int obj2)
        : base(obj0, obj1)
      {
        SteamUGC.ItemState itemState = this;
        this.bits = obj2;
        GC.KeepAlive((object) this);
      }

      [LineNumberTable(102)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static SteamUGC.ItemState[] values() => (SteamUGC.ItemState[]) SteamUGC.ItemState.\u0024VALUES.Clone();

      [LineNumberTable(102)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static SteamUGC.ItemState valueOf(string name) => (SteamUGC.ItemState) Enum.valueOf((Class) ClassLiteral<SteamUGC.ItemState>.Value, name);

      [LineNumberTable(new byte[] {159, 117, 173, 113, 113, 113, 113, 113, 114, 242, 57, 255, 36, 74})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static ItemState()
      {
        if (ByteCodeHelper.isAlreadyInited("com.codedisaster.steamworks.SteamUGC$ItemState"))
          return;
        SteamUGC.ItemState.__\u003C\u003ENone = new SteamUGC.ItemState(nameof (None), 0, 0);
        SteamUGC.ItemState.__\u003C\u003ESubscribed = new SteamUGC.ItemState(nameof (Subscribed), 1, 1);
        SteamUGC.ItemState.__\u003C\u003ELegacyItem = new SteamUGC.ItemState(nameof (LegacyItem), 2, 2);
        SteamUGC.ItemState.__\u003C\u003EInstalled = new SteamUGC.ItemState(nameof (Installed), 3, 4);
        SteamUGC.ItemState.__\u003C\u003ENeedsUpdate = new SteamUGC.ItemState(nameof (NeedsUpdate), 4, 8);
        SteamUGC.ItemState.__\u003C\u003EDownloading = new SteamUGC.ItemState(nameof (Downloading), 5, 16);
        SteamUGC.ItemState.__\u003C\u003EDownloadPending = new SteamUGC.ItemState(nameof (DownloadPending), 6, 32);
        SteamUGC.ItemState.\u0024VALUES = new SteamUGC.ItemState[7]
        {
          SteamUGC.ItemState.__\u003C\u003ENone,
          SteamUGC.ItemState.__\u003C\u003ESubscribed,
          SteamUGC.ItemState.__\u003C\u003ELegacyItem,
          SteamUGC.ItemState.__\u003C\u003EInstalled,
          SteamUGC.ItemState.__\u003C\u003ENeedsUpdate,
          SteamUGC.ItemState.__\u003C\u003EDownloading,
          SteamUGC.ItemState.__\u003C\u003EDownloadPending
        };
        SteamUGC.ItemState.values = SteamUGC.ItemState.values();
      }

      [Modifiers]
      public static SteamUGC.ItemState None
      {
        [HideFromJava] get => SteamUGC.ItemState.__\u003C\u003ENone;
      }

      [Modifiers]
      public static SteamUGC.ItemState Subscribed
      {
        [HideFromJava] get => SteamUGC.ItemState.__\u003C\u003ESubscribed;
      }

      [Modifiers]
      public static SteamUGC.ItemState LegacyItem
      {
        [HideFromJava] get => SteamUGC.ItemState.__\u003C\u003ELegacyItem;
      }

      [Modifiers]
      public static SteamUGC.ItemState Installed
      {
        [HideFromJava] get => SteamUGC.ItemState.__\u003C\u003EInstalled;
      }

      [Modifiers]
      public static SteamUGC.ItemState NeedsUpdate
      {
        [HideFromJava] get => SteamUGC.ItemState.__\u003C\u003ENeedsUpdate;
      }

      [Modifiers]
      public static SteamUGC.ItemState Downloading
      {
        [HideFromJava] get => SteamUGC.ItemState.__\u003C\u003EDownloading;
      }

      [Modifiers]
      public static SteamUGC.ItemState DownloadPending
      {
        [HideFromJava] get => SteamUGC.ItemState.__\u003C\u003EDownloadPending;
      }

      [HideFromJava]
      [Serializable]
      public enum __Enum
      {
        None,
        Subscribed,
        LegacyItem,
        Installed,
        NeedsUpdate,
        Downloading,
        DownloadPending,
      }
    }

    [InnerClass]
    [Signature("Ljava/lang/Enum<Lcom/codedisaster/steamworks/SteamUGC$ItemStatistic;>;")]
    [Modifiers]
    [Serializable]
    public sealed class ItemStatistic : Enum
    {
      [Modifiers]
      internal static SteamUGC.ItemStatistic __\u003C\u003ENumSubscriptions;
      [Modifiers]
      internal static SteamUGC.ItemStatistic __\u003C\u003ENumFavorites;
      [Modifiers]
      internal static SteamUGC.ItemStatistic __\u003C\u003ENumFollowers;
      [Modifiers]
      internal static SteamUGC.ItemStatistic __\u003C\u003ENumUniqueSubscriptions;
      [Modifiers]
      internal static SteamUGC.ItemStatistic __\u003C\u003ENumUniqueFavorites;
      [Modifiers]
      internal static SteamUGC.ItemStatistic __\u003C\u003ENumUniqueFollowers;
      [Modifiers]
      internal static SteamUGC.ItemStatistic __\u003C\u003ENumUniqueWebsiteViews;
      [Modifiers]
      internal static SteamUGC.ItemStatistic __\u003C\u003EReportScore;
      [Modifiers]
      internal static SteamUGC.ItemStatistic __\u003C\u003ENumSecondsPlayed;
      [Modifiers]
      internal static SteamUGC.ItemStatistic __\u003C\u003ENumPlaytimeSessions;
      [Modifiers]
      internal static SteamUGC.ItemStatistic __\u003C\u003ENumComments;
      [Modifiers]
      internal static SteamUGC.ItemStatistic __\u003C\u003ENumSecondsPlayedDuringTimePeriod;
      [Modifiers]
      internal static SteamUGC.ItemStatistic __\u003C\u003ENumPlaytimeSessionsDuringTimePeriod;
      [Modifiers]
      private static SteamUGC.ItemStatistic[] \u0024VALUES;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [Signature("()V")]
      [LineNumberTable(131)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private ItemStatistic([In] string obj0, [In] int obj1)
        : base(obj0, obj1)
      {
        GC.KeepAlive((object) this);
      }

      [LineNumberTable(131)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static SteamUGC.ItemStatistic[] values() => (SteamUGC.ItemStatistic[]) SteamUGC.ItemStatistic.\u0024VALUES.Clone();

      [LineNumberTable(131)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static SteamUGC.ItemStatistic valueOf(string name) => (SteamUGC.ItemStatistic) Enum.valueOf((Class) ClassLiteral<SteamUGC.ItemStatistic>.Value, name);

      [LineNumberTable(new byte[] {159, 109, 77, 112, 112, 112, 112, 112, 112, 112, 112, 112, 113, 113, 113, 241, 51})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static ItemStatistic()
      {
        if (ByteCodeHelper.isAlreadyInited("com.codedisaster.steamworks.SteamUGC$ItemStatistic"))
          return;
        SteamUGC.ItemStatistic.__\u003C\u003ENumSubscriptions = new SteamUGC.ItemStatistic(nameof (NumSubscriptions), 0);
        SteamUGC.ItemStatistic.__\u003C\u003ENumFavorites = new SteamUGC.ItemStatistic(nameof (NumFavorites), 1);
        SteamUGC.ItemStatistic.__\u003C\u003ENumFollowers = new SteamUGC.ItemStatistic(nameof (NumFollowers), 2);
        SteamUGC.ItemStatistic.__\u003C\u003ENumUniqueSubscriptions = new SteamUGC.ItemStatistic(nameof (NumUniqueSubscriptions), 3);
        SteamUGC.ItemStatistic.__\u003C\u003ENumUniqueFavorites = new SteamUGC.ItemStatistic(nameof (NumUniqueFavorites), 4);
        SteamUGC.ItemStatistic.__\u003C\u003ENumUniqueFollowers = new SteamUGC.ItemStatistic(nameof (NumUniqueFollowers), 5);
        SteamUGC.ItemStatistic.__\u003C\u003ENumUniqueWebsiteViews = new SteamUGC.ItemStatistic(nameof (NumUniqueWebsiteViews), 6);
        SteamUGC.ItemStatistic.__\u003C\u003EReportScore = new SteamUGC.ItemStatistic(nameof (ReportScore), 7);
        SteamUGC.ItemStatistic.__\u003C\u003ENumSecondsPlayed = new SteamUGC.ItemStatistic(nameof (NumSecondsPlayed), 8);
        SteamUGC.ItemStatistic.__\u003C\u003ENumPlaytimeSessions = new SteamUGC.ItemStatistic(nameof (NumPlaytimeSessions), 9);
        SteamUGC.ItemStatistic.__\u003C\u003ENumComments = new SteamUGC.ItemStatistic(nameof (NumComments), 10);
        SteamUGC.ItemStatistic.__\u003C\u003ENumSecondsPlayedDuringTimePeriod = new SteamUGC.ItemStatistic(nameof (NumSecondsPlayedDuringTimePeriod), 11);
        SteamUGC.ItemStatistic.__\u003C\u003ENumPlaytimeSessionsDuringTimePeriod = new SteamUGC.ItemStatistic(nameof (NumPlaytimeSessionsDuringTimePeriod), 12);
        SteamUGC.ItemStatistic.\u0024VALUES = new SteamUGC.ItemStatistic[13]
        {
          SteamUGC.ItemStatistic.__\u003C\u003ENumSubscriptions,
          SteamUGC.ItemStatistic.__\u003C\u003ENumFavorites,
          SteamUGC.ItemStatistic.__\u003C\u003ENumFollowers,
          SteamUGC.ItemStatistic.__\u003C\u003ENumUniqueSubscriptions,
          SteamUGC.ItemStatistic.__\u003C\u003ENumUniqueFavorites,
          SteamUGC.ItemStatistic.__\u003C\u003ENumUniqueFollowers,
          SteamUGC.ItemStatistic.__\u003C\u003ENumUniqueWebsiteViews,
          SteamUGC.ItemStatistic.__\u003C\u003EReportScore,
          SteamUGC.ItemStatistic.__\u003C\u003ENumSecondsPlayed,
          SteamUGC.ItemStatistic.__\u003C\u003ENumPlaytimeSessions,
          SteamUGC.ItemStatistic.__\u003C\u003ENumComments,
          SteamUGC.ItemStatistic.__\u003C\u003ENumSecondsPlayedDuringTimePeriod,
          SteamUGC.ItemStatistic.__\u003C\u003ENumPlaytimeSessionsDuringTimePeriod
        };
      }

      [Modifiers]
      public static SteamUGC.ItemStatistic NumSubscriptions
      {
        [HideFromJava] get => SteamUGC.ItemStatistic.__\u003C\u003ENumSubscriptions;
      }

      [Modifiers]
      public static SteamUGC.ItemStatistic NumFavorites
      {
        [HideFromJava] get => SteamUGC.ItemStatistic.__\u003C\u003ENumFavorites;
      }

      [Modifiers]
      public static SteamUGC.ItemStatistic NumFollowers
      {
        [HideFromJava] get => SteamUGC.ItemStatistic.__\u003C\u003ENumFollowers;
      }

      [Modifiers]
      public static SteamUGC.ItemStatistic NumUniqueSubscriptions
      {
        [HideFromJava] get => SteamUGC.ItemStatistic.__\u003C\u003ENumUniqueSubscriptions;
      }

      [Modifiers]
      public static SteamUGC.ItemStatistic NumUniqueFavorites
      {
        [HideFromJava] get => SteamUGC.ItemStatistic.__\u003C\u003ENumUniqueFavorites;
      }

      [Modifiers]
      public static SteamUGC.ItemStatistic NumUniqueFollowers
      {
        [HideFromJava] get => SteamUGC.ItemStatistic.__\u003C\u003ENumUniqueFollowers;
      }

      [Modifiers]
      public static SteamUGC.ItemStatistic NumUniqueWebsiteViews
      {
        [HideFromJava] get => SteamUGC.ItemStatistic.__\u003C\u003ENumUniqueWebsiteViews;
      }

      [Modifiers]
      public static SteamUGC.ItemStatistic ReportScore
      {
        [HideFromJava] get => SteamUGC.ItemStatistic.__\u003C\u003EReportScore;
      }

      [Modifiers]
      public static SteamUGC.ItemStatistic NumSecondsPlayed
      {
        [HideFromJava] get => SteamUGC.ItemStatistic.__\u003C\u003ENumSecondsPlayed;
      }

      [Modifiers]
      public static SteamUGC.ItemStatistic NumPlaytimeSessions
      {
        [HideFromJava] get => SteamUGC.ItemStatistic.__\u003C\u003ENumPlaytimeSessions;
      }

      [Modifiers]
      public static SteamUGC.ItemStatistic NumComments
      {
        [HideFromJava] get => SteamUGC.ItemStatistic.__\u003C\u003ENumComments;
      }

      [Modifiers]
      public static SteamUGC.ItemStatistic NumSecondsPlayedDuringTimePeriod
      {
        [HideFromJava] get => SteamUGC.ItemStatistic.__\u003C\u003ENumSecondsPlayedDuringTimePeriod;
      }

      [Modifiers]
      public static SteamUGC.ItemStatistic NumPlaytimeSessionsDuringTimePeriod
      {
        [HideFromJava] get => SteamUGC.ItemStatistic.__\u003C\u003ENumPlaytimeSessionsDuringTimePeriod;
      }

      [HideFromJava]
      [Serializable]
      public enum __Enum
      {
        NumSubscriptions,
        NumFavorites,
        NumFollowers,
        NumUniqueSubscriptions,
        NumUniqueFavorites,
        NumUniqueFollowers,
        NumUniqueWebsiteViews,
        ReportScore,
        NumSecondsPlayed,
        NumPlaytimeSessions,
        NumComments,
        NumSecondsPlayedDuringTimePeriod,
        NumPlaytimeSessionsDuringTimePeriod,
      }
    }

    public class ItemUpdateInfo : Object
    {
      internal long bytesProcessed;
      internal long bytesTotal;

      [LineNumberTable(89)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public ItemUpdateInfo()
      {
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual long getBytesProcessed() => this.bytesProcessed;

      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual long getBytesTotal() => this.bytesTotal;
    }

    [InnerClass]
    [Signature("Ljava/lang/Enum<Lcom/codedisaster/steamworks/SteamUGC$ItemUpdateStatus;>;")]
    [Modifiers]
    [Serializable]
    public sealed class ItemUpdateStatus : Enum
    {
      [Modifiers]
      internal static SteamUGC.ItemUpdateStatus __\u003C\u003EInvalid;
      [Modifiers]
      internal static SteamUGC.ItemUpdateStatus __\u003C\u003EPreparingConfig;
      [Modifiers]
      internal static SteamUGC.ItemUpdateStatus __\u003C\u003EPreparingContent;
      [Modifiers]
      internal static SteamUGC.ItemUpdateStatus __\u003C\u003EUploadingContent;
      [Modifiers]
      internal static SteamUGC.ItemUpdateStatus __\u003C\u003EUploadingPreviewFile;
      [Modifiers]
      internal static SteamUGC.ItemUpdateStatus __\u003C\u003ECommittingChanges;
      [Modifiers]
      private static SteamUGC.ItemUpdateStatus[] values;
      [Modifiers]
      private static SteamUGC.ItemUpdateStatus[] \u0024VALUES;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(74)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static SteamUGC.ItemUpdateStatus[] values() => (SteamUGC.ItemUpdateStatus[]) SteamUGC.ItemUpdateStatus.\u0024VALUES.Clone();

      [LineNumberTable(85)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal static SteamUGC.ItemUpdateStatus byOrdinal([In] int obj0) => SteamUGC.ItemUpdateStatus.values[obj0];

      [Signature("()V")]
      [LineNumberTable(74)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private ItemUpdateStatus([In] string obj0, [In] int obj1)
        : base(obj0, obj1)
      {
        GC.KeepAlive((object) this);
      }

      [LineNumberTable(74)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static SteamUGC.ItemUpdateStatus valueOf(string name) => (SteamUGC.ItemUpdateStatus) Enum.valueOf((Class) ClassLiteral<SteamUGC.ItemUpdateStatus>.Value, name);

      [LineNumberTable(new byte[] {159, 124, 173, 112, 112, 112, 112, 112, 240, 58, 255, 28, 72})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static ItemUpdateStatus()
      {
        if (ByteCodeHelper.isAlreadyInited("com.codedisaster.steamworks.SteamUGC$ItemUpdateStatus"))
          return;
        SteamUGC.ItemUpdateStatus.__\u003C\u003EInvalid = new SteamUGC.ItemUpdateStatus(nameof (Invalid), 0);
        SteamUGC.ItemUpdateStatus.__\u003C\u003EPreparingConfig = new SteamUGC.ItemUpdateStatus(nameof (PreparingConfig), 1);
        SteamUGC.ItemUpdateStatus.__\u003C\u003EPreparingContent = new SteamUGC.ItemUpdateStatus(nameof (PreparingContent), 2);
        SteamUGC.ItemUpdateStatus.__\u003C\u003EUploadingContent = new SteamUGC.ItemUpdateStatus(nameof (UploadingContent), 3);
        SteamUGC.ItemUpdateStatus.__\u003C\u003EUploadingPreviewFile = new SteamUGC.ItemUpdateStatus(nameof (UploadingPreviewFile), 4);
        SteamUGC.ItemUpdateStatus.__\u003C\u003ECommittingChanges = new SteamUGC.ItemUpdateStatus(nameof (CommittingChanges), 5);
        SteamUGC.ItemUpdateStatus.\u0024VALUES = new SteamUGC.ItemUpdateStatus[6]
        {
          SteamUGC.ItemUpdateStatus.__\u003C\u003EInvalid,
          SteamUGC.ItemUpdateStatus.__\u003C\u003EPreparingConfig,
          SteamUGC.ItemUpdateStatus.__\u003C\u003EPreparingContent,
          SteamUGC.ItemUpdateStatus.__\u003C\u003EUploadingContent,
          SteamUGC.ItemUpdateStatus.__\u003C\u003EUploadingPreviewFile,
          SteamUGC.ItemUpdateStatus.__\u003C\u003ECommittingChanges
        };
        SteamUGC.ItemUpdateStatus.values = SteamUGC.ItemUpdateStatus.values();
      }

      [Modifiers]
      public static SteamUGC.ItemUpdateStatus Invalid
      {
        [HideFromJava] get => SteamUGC.ItemUpdateStatus.__\u003C\u003EInvalid;
      }

      [Modifiers]
      public static SteamUGC.ItemUpdateStatus PreparingConfig
      {
        [HideFromJava] get => SteamUGC.ItemUpdateStatus.__\u003C\u003EPreparingConfig;
      }

      [Modifiers]
      public static SteamUGC.ItemUpdateStatus PreparingContent
      {
        [HideFromJava] get => SteamUGC.ItemUpdateStatus.__\u003C\u003EPreparingContent;
      }

      [Modifiers]
      public static SteamUGC.ItemUpdateStatus UploadingContent
      {
        [HideFromJava] get => SteamUGC.ItemUpdateStatus.__\u003C\u003EUploadingContent;
      }

      [Modifiers]
      public static SteamUGC.ItemUpdateStatus UploadingPreviewFile
      {
        [HideFromJava] get => SteamUGC.ItemUpdateStatus.__\u003C\u003EUploadingPreviewFile;
      }

      [Modifiers]
      public static SteamUGC.ItemUpdateStatus CommittingChanges
      {
        [HideFromJava] get => SteamUGC.ItemUpdateStatus.__\u003C\u003ECommittingChanges;
      }

      [HideFromJava]
      [Serializable]
      public enum __Enum
      {
        Invalid,
        PreparingConfig,
        PreparingContent,
        UploadingContent,
        UploadingPreviewFile,
        CommittingChanges,
      }
    }

    [InnerClass]
    [Signature("Ljava/lang/Enum<Lcom/codedisaster/steamworks/SteamUGC$MatchingUGCType;>;")]
    [Modifiers]
    [Serializable]
    public sealed class MatchingUGCType : Enum
    {
      [Modifiers]
      internal static SteamUGC.MatchingUGCType __\u003C\u003EItems;
      [Modifiers]
      internal static SteamUGC.MatchingUGCType __\u003C\u003EItemsMtx;
      [Modifiers]
      internal static SteamUGC.MatchingUGCType __\u003C\u003EItemsReadyToUse;
      [Modifiers]
      internal static SteamUGC.MatchingUGCType __\u003C\u003ECollections;
      [Modifiers]
      internal static SteamUGC.MatchingUGCType __\u003C\u003EArtwork;
      [Modifiers]
      internal static SteamUGC.MatchingUGCType __\u003C\u003EVideos;
      [Modifiers]
      internal static SteamUGC.MatchingUGCType __\u003C\u003EScreenshots;
      [Modifiers]
      internal static SteamUGC.MatchingUGCType __\u003C\u003EAllGuides;
      [Modifiers]
      internal static SteamUGC.MatchingUGCType __\u003C\u003EWebGuides;
      [Modifiers]
      internal static SteamUGC.MatchingUGCType __\u003C\u003EIntegratedGuides;
      [Modifiers]
      internal static SteamUGC.MatchingUGCType __\u003C\u003EUsableInGame;
      [Modifiers]
      internal static SteamUGC.MatchingUGCType __\u003C\u003EControllerBindings;
      [Modifiers]
      internal static SteamUGC.MatchingUGCType __\u003C\u003EGameManagedItems;
      [Modifiers]
      internal static SteamUGC.MatchingUGCType __\u003C\u003EAll;
      [Modifiers]
      private int value;
      [Modifiers]
      private static SteamUGC.MatchingUGCType[] \u0024VALUES;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [Modifiers]
      [LineNumberTable(19)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal static int access\u0024000([In] SteamUGC.MatchingUGCType obj0) => obj0.value;

      [Signature("(I)V")]
      [LineNumberTable(new byte[] {159, 179, 106, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private MatchingUGCType([In] string obj0, [In] int obj1, [In] int obj2)
        : base(obj0, obj1)
      {
        SteamUGC.MatchingUGCType matchingUgcType = this;
        this.value = obj2;
        GC.KeepAlive((object) this);
      }

      [LineNumberTable(19)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static SteamUGC.MatchingUGCType[] values() => (SteamUGC.MatchingUGCType[]) SteamUGC.MatchingUGCType.\u0024VALUES.Clone();

      [LineNumberTable(19)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static SteamUGC.MatchingUGCType valueOf(string name) => (SteamUGC.MatchingUGCType) Enum.valueOf((Class) ClassLiteral<SteamUGC.MatchingUGCType>.Value, name);

      [LineNumberTable(new byte[] {159, 137, 77, 113, 113, 113, 113, 113, 113, 113, 113, 113, 115, 115, 115, 115, 242, 50})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static MatchingUGCType()
      {
        if (ByteCodeHelper.isAlreadyInited("com.codedisaster.steamworks.SteamUGC$MatchingUGCType"))
          return;
        SteamUGC.MatchingUGCType.__\u003C\u003EItems = new SteamUGC.MatchingUGCType(nameof (Items), 0, 0);
        SteamUGC.MatchingUGCType.__\u003C\u003EItemsMtx = new SteamUGC.MatchingUGCType(nameof (ItemsMtx), 1, 1);
        SteamUGC.MatchingUGCType.__\u003C\u003EItemsReadyToUse = new SteamUGC.MatchingUGCType(nameof (ItemsReadyToUse), 2, 2);
        SteamUGC.MatchingUGCType.__\u003C\u003ECollections = new SteamUGC.MatchingUGCType(nameof (Collections), 3, 3);
        SteamUGC.MatchingUGCType.__\u003C\u003EArtwork = new SteamUGC.MatchingUGCType(nameof (Artwork), 4, 4);
        SteamUGC.MatchingUGCType.__\u003C\u003EVideos = new SteamUGC.MatchingUGCType(nameof (Videos), 5, 5);
        SteamUGC.MatchingUGCType.__\u003C\u003EScreenshots = new SteamUGC.MatchingUGCType(nameof (Screenshots), 6, 6);
        SteamUGC.MatchingUGCType.__\u003C\u003EAllGuides = new SteamUGC.MatchingUGCType(nameof (AllGuides), 7, 7);
        SteamUGC.MatchingUGCType.__\u003C\u003EWebGuides = new SteamUGC.MatchingUGCType(nameof (WebGuides), 8, 8);
        SteamUGC.MatchingUGCType.__\u003C\u003EIntegratedGuides = new SteamUGC.MatchingUGCType(nameof (IntegratedGuides), 9, 9);
        SteamUGC.MatchingUGCType.__\u003C\u003EUsableInGame = new SteamUGC.MatchingUGCType(nameof (UsableInGame), 10, 10);
        SteamUGC.MatchingUGCType.__\u003C\u003EControllerBindings = new SteamUGC.MatchingUGCType(nameof (ControllerBindings), 11, 11);
        SteamUGC.MatchingUGCType.__\u003C\u003EGameManagedItems = new SteamUGC.MatchingUGCType(nameof (GameManagedItems), 12, 12);
        SteamUGC.MatchingUGCType.__\u003C\u003EAll = new SteamUGC.MatchingUGCType(nameof (All), 13, -1);
        SteamUGC.MatchingUGCType.\u0024VALUES = new SteamUGC.MatchingUGCType[14]
        {
          SteamUGC.MatchingUGCType.__\u003C\u003EItems,
          SteamUGC.MatchingUGCType.__\u003C\u003EItemsMtx,
          SteamUGC.MatchingUGCType.__\u003C\u003EItemsReadyToUse,
          SteamUGC.MatchingUGCType.__\u003C\u003ECollections,
          SteamUGC.MatchingUGCType.__\u003C\u003EArtwork,
          SteamUGC.MatchingUGCType.__\u003C\u003EVideos,
          SteamUGC.MatchingUGCType.__\u003C\u003EScreenshots,
          SteamUGC.MatchingUGCType.__\u003C\u003EAllGuides,
          SteamUGC.MatchingUGCType.__\u003C\u003EWebGuides,
          SteamUGC.MatchingUGCType.__\u003C\u003EIntegratedGuides,
          SteamUGC.MatchingUGCType.__\u003C\u003EUsableInGame,
          SteamUGC.MatchingUGCType.__\u003C\u003EControllerBindings,
          SteamUGC.MatchingUGCType.__\u003C\u003EGameManagedItems,
          SteamUGC.MatchingUGCType.__\u003C\u003EAll
        };
      }

      [Modifiers]
      public static SteamUGC.MatchingUGCType Items
      {
        [HideFromJava] get => SteamUGC.MatchingUGCType.__\u003C\u003EItems;
      }

      [Modifiers]
      public static SteamUGC.MatchingUGCType ItemsMtx
      {
        [HideFromJava] get => SteamUGC.MatchingUGCType.__\u003C\u003EItemsMtx;
      }

      [Modifiers]
      public static SteamUGC.MatchingUGCType ItemsReadyToUse
      {
        [HideFromJava] get => SteamUGC.MatchingUGCType.__\u003C\u003EItemsReadyToUse;
      }

      [Modifiers]
      public static SteamUGC.MatchingUGCType Collections
      {
        [HideFromJava] get => SteamUGC.MatchingUGCType.__\u003C\u003ECollections;
      }

      [Modifiers]
      public static SteamUGC.MatchingUGCType Artwork
      {
        [HideFromJava] get => SteamUGC.MatchingUGCType.__\u003C\u003EArtwork;
      }

      [Modifiers]
      public static SteamUGC.MatchingUGCType Videos
      {
        [HideFromJava] get => SteamUGC.MatchingUGCType.__\u003C\u003EVideos;
      }

      [Modifiers]
      public static SteamUGC.MatchingUGCType Screenshots
      {
        [HideFromJava] get => SteamUGC.MatchingUGCType.__\u003C\u003EScreenshots;
      }

      [Modifiers]
      public static SteamUGC.MatchingUGCType AllGuides
      {
        [HideFromJava] get => SteamUGC.MatchingUGCType.__\u003C\u003EAllGuides;
      }

      [Modifiers]
      public static SteamUGC.MatchingUGCType WebGuides
      {
        [HideFromJava] get => SteamUGC.MatchingUGCType.__\u003C\u003EWebGuides;
      }

      [Modifiers]
      public static SteamUGC.MatchingUGCType IntegratedGuides
      {
        [HideFromJava] get => SteamUGC.MatchingUGCType.__\u003C\u003EIntegratedGuides;
      }

      [Modifiers]
      public static SteamUGC.MatchingUGCType UsableInGame
      {
        [HideFromJava] get => SteamUGC.MatchingUGCType.__\u003C\u003EUsableInGame;
      }

      [Modifiers]
      public static SteamUGC.MatchingUGCType ControllerBindings
      {
        [HideFromJava] get => SteamUGC.MatchingUGCType.__\u003C\u003EControllerBindings;
      }

      [Modifiers]
      public static SteamUGC.MatchingUGCType GameManagedItems
      {
        [HideFromJava] get => SteamUGC.MatchingUGCType.__\u003C\u003EGameManagedItems;
      }

      [Modifiers]
      public static SteamUGC.MatchingUGCType All
      {
        [HideFromJava] get => SteamUGC.MatchingUGCType.__\u003C\u003EAll;
      }

      [HideFromJava]
      [Serializable]
      public enum __Enum
      {
        Items,
        ItemsMtx,
        ItemsReadyToUse,
        Collections,
        Artwork,
        Videos,
        Screenshots,
        AllGuides,
        WebGuides,
        IntegratedGuides,
        UsableInGame,
        ControllerBindings,
        GameManagedItems,
        All,
      }
    }

    [InnerClass]
    [Signature("Ljava/lang/Enum<Lcom/codedisaster/steamworks/SteamUGC$UGCQueryType;>;")]
    [Modifiers]
    [Serializable]
    public sealed class UGCQueryType : Enum
    {
      [Modifiers]
      internal static SteamUGC.UGCQueryType __\u003C\u003ERankedByVote;
      [Modifiers]
      internal static SteamUGC.UGCQueryType __\u003C\u003ERankedByPublicationDate;
      [Modifiers]
      internal static SteamUGC.UGCQueryType __\u003C\u003EAcceptedForGameRankedByAcceptanceDate;
      [Modifiers]
      internal static SteamUGC.UGCQueryType __\u003C\u003ERankedByTrend;
      [Modifiers]
      internal static SteamUGC.UGCQueryType __\u003C\u003EFavoritedByFriendsRankedByPublicationDate;
      [Modifiers]
      internal static SteamUGC.UGCQueryType __\u003C\u003ECreatedByFriendsRankedByPublicationDate;
      [Modifiers]
      internal static SteamUGC.UGCQueryType __\u003C\u003ERankedByNumTimesReported;
      [Modifiers]
      internal static SteamUGC.UGCQueryType __\u003C\u003ECreatedByFollowedUsersRankedByPublicationDate;
      [Modifiers]
      internal static SteamUGC.UGCQueryType __\u003C\u003ENotYetRated;
      [Modifiers]
      internal static SteamUGC.UGCQueryType __\u003C\u003ERankedByTotalVotesAsc;
      [Modifiers]
      internal static SteamUGC.UGCQueryType __\u003C\u003ERankedByVotesUp;
      [Modifiers]
      internal static SteamUGC.UGCQueryType __\u003C\u003ERankedByTextSearch;
      [Modifiers]
      internal static SteamUGC.UGCQueryType __\u003C\u003ERankedByTotalUniqueSubscriptions;
      [Modifiers]
      internal static SteamUGC.UGCQueryType __\u003C\u003ERankedByPlaytimeTrend;
      [Modifiers]
      internal static SteamUGC.UGCQueryType __\u003C\u003ERankedByTotalPlaytime;
      [Modifiers]
      internal static SteamUGC.UGCQueryType __\u003C\u003ERankedByAveragePlaytimeTrend;
      [Modifiers]
      internal static SteamUGC.UGCQueryType __\u003C\u003ERankedByLifetimeAveragePlaytime;
      [Modifiers]
      internal static SteamUGC.UGCQueryType __\u003C\u003ERankedByPlaytimeSessionsTrend;
      [Modifiers]
      internal static SteamUGC.UGCQueryType __\u003C\u003ERankedByLifetimePlaytimeSessions;
      [Modifiers]
      private static SteamUGC.UGCQueryType[] \u0024VALUES;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [Signature("()V")]
      [LineNumberTable(52)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private UGCQueryType([In] string obj0, [In] int obj1)
        : base(obj0, obj1)
      {
        GC.KeepAlive((object) this);
      }

      [LineNumberTable(52)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static SteamUGC.UGCQueryType[] values() => (SteamUGC.UGCQueryType[]) SteamUGC.UGCQueryType.\u0024VALUES.Clone();

      [LineNumberTable(52)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static SteamUGC.UGCQueryType valueOf(string name) => (SteamUGC.UGCQueryType) Enum.valueOf((Class) ClassLiteral<SteamUGC.UGCQueryType>.Value, name);

      [LineNumberTable(new byte[] {159, 129, 109, 112, 112, 112, 112, 112, 112, 112, 112, 112, 113, 113, 113, 113, 113, 113, 113, 113, 113, 241, 45})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static UGCQueryType()
      {
        if (ByteCodeHelper.isAlreadyInited("com.codedisaster.steamworks.SteamUGC$UGCQueryType"))
          return;
        SteamUGC.UGCQueryType.__\u003C\u003ERankedByVote = new SteamUGC.UGCQueryType(nameof (RankedByVote), 0);
        SteamUGC.UGCQueryType.__\u003C\u003ERankedByPublicationDate = new SteamUGC.UGCQueryType(nameof (RankedByPublicationDate), 1);
        SteamUGC.UGCQueryType.__\u003C\u003EAcceptedForGameRankedByAcceptanceDate = new SteamUGC.UGCQueryType(nameof (AcceptedForGameRankedByAcceptanceDate), 2);
        SteamUGC.UGCQueryType.__\u003C\u003ERankedByTrend = new SteamUGC.UGCQueryType(nameof (RankedByTrend), 3);
        SteamUGC.UGCQueryType.__\u003C\u003EFavoritedByFriendsRankedByPublicationDate = new SteamUGC.UGCQueryType(nameof (FavoritedByFriendsRankedByPublicationDate), 4);
        SteamUGC.UGCQueryType.__\u003C\u003ECreatedByFriendsRankedByPublicationDate = new SteamUGC.UGCQueryType(nameof (CreatedByFriendsRankedByPublicationDate), 5);
        SteamUGC.UGCQueryType.__\u003C\u003ERankedByNumTimesReported = new SteamUGC.UGCQueryType(nameof (RankedByNumTimesReported), 6);
        SteamUGC.UGCQueryType.__\u003C\u003ECreatedByFollowedUsersRankedByPublicationDate = new SteamUGC.UGCQueryType(nameof (CreatedByFollowedUsersRankedByPublicationDate), 7);
        SteamUGC.UGCQueryType.__\u003C\u003ENotYetRated = new SteamUGC.UGCQueryType(nameof (NotYetRated), 8);
        SteamUGC.UGCQueryType.__\u003C\u003ERankedByTotalVotesAsc = new SteamUGC.UGCQueryType(nameof (RankedByTotalVotesAsc), 9);
        SteamUGC.UGCQueryType.__\u003C\u003ERankedByVotesUp = new SteamUGC.UGCQueryType(nameof (RankedByVotesUp), 10);
        SteamUGC.UGCQueryType.__\u003C\u003ERankedByTextSearch = new SteamUGC.UGCQueryType(nameof (RankedByTextSearch), 11);
        SteamUGC.UGCQueryType.__\u003C\u003ERankedByTotalUniqueSubscriptions = new SteamUGC.UGCQueryType(nameof (RankedByTotalUniqueSubscriptions), 12);
        SteamUGC.UGCQueryType.__\u003C\u003ERankedByPlaytimeTrend = new SteamUGC.UGCQueryType(nameof (RankedByPlaytimeTrend), 13);
        SteamUGC.UGCQueryType.__\u003C\u003ERankedByTotalPlaytime = new SteamUGC.UGCQueryType(nameof (RankedByTotalPlaytime), 14);
        SteamUGC.UGCQueryType.__\u003C\u003ERankedByAveragePlaytimeTrend = new SteamUGC.UGCQueryType(nameof (RankedByAveragePlaytimeTrend), 15);
        SteamUGC.UGCQueryType.__\u003C\u003ERankedByLifetimeAveragePlaytime = new SteamUGC.UGCQueryType(nameof (RankedByLifetimeAveragePlaytime), 16);
        SteamUGC.UGCQueryType.__\u003C\u003ERankedByPlaytimeSessionsTrend = new SteamUGC.UGCQueryType(nameof (RankedByPlaytimeSessionsTrend), 17);
        SteamUGC.UGCQueryType.__\u003C\u003ERankedByLifetimePlaytimeSessions = new SteamUGC.UGCQueryType(nameof (RankedByLifetimePlaytimeSessions), 18);
        SteamUGC.UGCQueryType.\u0024VALUES = new SteamUGC.UGCQueryType[19]
        {
          SteamUGC.UGCQueryType.__\u003C\u003ERankedByVote,
          SteamUGC.UGCQueryType.__\u003C\u003ERankedByPublicationDate,
          SteamUGC.UGCQueryType.__\u003C\u003EAcceptedForGameRankedByAcceptanceDate,
          SteamUGC.UGCQueryType.__\u003C\u003ERankedByTrend,
          SteamUGC.UGCQueryType.__\u003C\u003EFavoritedByFriendsRankedByPublicationDate,
          SteamUGC.UGCQueryType.__\u003C\u003ECreatedByFriendsRankedByPublicationDate,
          SteamUGC.UGCQueryType.__\u003C\u003ERankedByNumTimesReported,
          SteamUGC.UGCQueryType.__\u003C\u003ECreatedByFollowedUsersRankedByPublicationDate,
          SteamUGC.UGCQueryType.__\u003C\u003ENotYetRated,
          SteamUGC.UGCQueryType.__\u003C\u003ERankedByTotalVotesAsc,
          SteamUGC.UGCQueryType.__\u003C\u003ERankedByVotesUp,
          SteamUGC.UGCQueryType.__\u003C\u003ERankedByTextSearch,
          SteamUGC.UGCQueryType.__\u003C\u003ERankedByTotalUniqueSubscriptions,
          SteamUGC.UGCQueryType.__\u003C\u003ERankedByPlaytimeTrend,
          SteamUGC.UGCQueryType.__\u003C\u003ERankedByTotalPlaytime,
          SteamUGC.UGCQueryType.__\u003C\u003ERankedByAveragePlaytimeTrend,
          SteamUGC.UGCQueryType.__\u003C\u003ERankedByLifetimeAveragePlaytime,
          SteamUGC.UGCQueryType.__\u003C\u003ERankedByPlaytimeSessionsTrend,
          SteamUGC.UGCQueryType.__\u003C\u003ERankedByLifetimePlaytimeSessions
        };
      }

      [Modifiers]
      public static SteamUGC.UGCQueryType RankedByVote
      {
        [HideFromJava] get => SteamUGC.UGCQueryType.__\u003C\u003ERankedByVote;
      }

      [Modifiers]
      public static SteamUGC.UGCQueryType RankedByPublicationDate
      {
        [HideFromJava] get => SteamUGC.UGCQueryType.__\u003C\u003ERankedByPublicationDate;
      }

      [Modifiers]
      public static SteamUGC.UGCQueryType AcceptedForGameRankedByAcceptanceDate
      {
        [HideFromJava] get => SteamUGC.UGCQueryType.__\u003C\u003EAcceptedForGameRankedByAcceptanceDate;
      }

      [Modifiers]
      public static SteamUGC.UGCQueryType RankedByTrend
      {
        [HideFromJava] get => SteamUGC.UGCQueryType.__\u003C\u003ERankedByTrend;
      }

      [Modifiers]
      public static SteamUGC.UGCQueryType FavoritedByFriendsRankedByPublicationDate
      {
        [HideFromJava] get => SteamUGC.UGCQueryType.__\u003C\u003EFavoritedByFriendsRankedByPublicationDate;
      }

      [Modifiers]
      public static SteamUGC.UGCQueryType CreatedByFriendsRankedByPublicationDate
      {
        [HideFromJava] get => SteamUGC.UGCQueryType.__\u003C\u003ECreatedByFriendsRankedByPublicationDate;
      }

      [Modifiers]
      public static SteamUGC.UGCQueryType RankedByNumTimesReported
      {
        [HideFromJava] get => SteamUGC.UGCQueryType.__\u003C\u003ERankedByNumTimesReported;
      }

      [Modifiers]
      public static SteamUGC.UGCQueryType CreatedByFollowedUsersRankedByPublicationDate
      {
        [HideFromJava] get => SteamUGC.UGCQueryType.__\u003C\u003ECreatedByFollowedUsersRankedByPublicationDate;
      }

      [Modifiers]
      public static SteamUGC.UGCQueryType NotYetRated
      {
        [HideFromJava] get => SteamUGC.UGCQueryType.__\u003C\u003ENotYetRated;
      }

      [Modifiers]
      public static SteamUGC.UGCQueryType RankedByTotalVotesAsc
      {
        [HideFromJava] get => SteamUGC.UGCQueryType.__\u003C\u003ERankedByTotalVotesAsc;
      }

      [Modifiers]
      public static SteamUGC.UGCQueryType RankedByVotesUp
      {
        [HideFromJava] get => SteamUGC.UGCQueryType.__\u003C\u003ERankedByVotesUp;
      }

      [Modifiers]
      public static SteamUGC.UGCQueryType RankedByTextSearch
      {
        [HideFromJava] get => SteamUGC.UGCQueryType.__\u003C\u003ERankedByTextSearch;
      }

      [Modifiers]
      public static SteamUGC.UGCQueryType RankedByTotalUniqueSubscriptions
      {
        [HideFromJava] get => SteamUGC.UGCQueryType.__\u003C\u003ERankedByTotalUniqueSubscriptions;
      }

      [Modifiers]
      public static SteamUGC.UGCQueryType RankedByPlaytimeTrend
      {
        [HideFromJava] get => SteamUGC.UGCQueryType.__\u003C\u003ERankedByPlaytimeTrend;
      }

      [Modifiers]
      public static SteamUGC.UGCQueryType RankedByTotalPlaytime
      {
        [HideFromJava] get => SteamUGC.UGCQueryType.__\u003C\u003ERankedByTotalPlaytime;
      }

      [Modifiers]
      public static SteamUGC.UGCQueryType RankedByAveragePlaytimeTrend
      {
        [HideFromJava] get => SteamUGC.UGCQueryType.__\u003C\u003ERankedByAveragePlaytimeTrend;
      }

      [Modifiers]
      public static SteamUGC.UGCQueryType RankedByLifetimeAveragePlaytime
      {
        [HideFromJava] get => SteamUGC.UGCQueryType.__\u003C\u003ERankedByLifetimeAveragePlaytime;
      }

      [Modifiers]
      public static SteamUGC.UGCQueryType RankedByPlaytimeSessionsTrend
      {
        [HideFromJava] get => SteamUGC.UGCQueryType.__\u003C\u003ERankedByPlaytimeSessionsTrend;
      }

      [Modifiers]
      public static SteamUGC.UGCQueryType RankedByLifetimePlaytimeSessions
      {
        [HideFromJava] get => SteamUGC.UGCQueryType.__\u003C\u003ERankedByLifetimePlaytimeSessions;
      }

      [HideFromJava]
      [Serializable]
      public enum __Enum
      {
        RankedByVote,
        RankedByPublicationDate,
        AcceptedForGameRankedByAcceptanceDate,
        RankedByTrend,
        FavoritedByFriendsRankedByPublicationDate,
        CreatedByFriendsRankedByPublicationDate,
        RankedByNumTimesReported,
        CreatedByFollowedUsersRankedByPublicationDate,
        NotYetRated,
        RankedByTotalVotesAsc,
        RankedByVotesUp,
        RankedByTextSearch,
        RankedByTotalUniqueSubscriptions,
        RankedByPlaytimeTrend,
        RankedByTotalPlaytime,
        RankedByAveragePlaytimeTrend,
        RankedByLifetimeAveragePlaytime,
        RankedByPlaytimeSessionsTrend,
        RankedByLifetimePlaytimeSessions,
      }
    }

    [InnerClass]
    [Signature("Ljava/lang/Enum<Lcom/codedisaster/steamworks/SteamUGC$UserUGCList;>;")]
    [Modifiers]
    [Serializable]
    public sealed class UserUGCList : Enum
    {
      [Modifiers]
      internal static SteamUGC.UserUGCList __\u003C\u003EPublished;
      [Modifiers]
      internal static SteamUGC.UserUGCList __\u003C\u003EVotedOn;
      [Modifiers]
      internal static SteamUGC.UserUGCList __\u003C\u003EVotedUp;
      [Modifiers]
      internal static SteamUGC.UserUGCList __\u003C\u003EVotedDown;
      [Modifiers]
      internal static SteamUGC.UserUGCList __\u003C\u003EWillVoteLater;
      [Modifiers]
      internal static SteamUGC.UserUGCList __\u003C\u003EFavorited;
      [Modifiers]
      internal static SteamUGC.UserUGCList __\u003C\u003ESubscribed;
      [Modifiers]
      internal static SteamUGC.UserUGCList __\u003C\u003EUsedOrPlayed;
      [Modifiers]
      internal static SteamUGC.UserUGCList __\u003C\u003EFollowed;
      [Modifiers]
      private static SteamUGC.UserUGCList[] \u0024VALUES;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [Signature("()V")]
      [LineNumberTable(7)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private UserUGCList([In] string obj0, [In] int obj1)
        : base(obj0, obj1)
      {
        GC.KeepAlive((object) this);
      }

      [LineNumberTable(7)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static SteamUGC.UserUGCList[] values() => (SteamUGC.UserUGCList[]) SteamUGC.UserUGCList.\u0024VALUES.Clone();

      [LineNumberTable(7)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static SteamUGC.UserUGCList valueOf(string name) => (SteamUGC.UserUGCList) Enum.valueOf((Class) ClassLiteral<SteamUGC.UserUGCList>.Value, name);

      [LineNumberTable(new byte[] {159, 140, 77, 112, 112, 112, 112, 112, 112, 112, 112, 240, 55})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static UserUGCList()
      {
        if (ByteCodeHelper.isAlreadyInited("com.codedisaster.steamworks.SteamUGC$UserUGCList"))
          return;
        SteamUGC.UserUGCList.__\u003C\u003EPublished = new SteamUGC.UserUGCList(nameof (Published), 0);
        SteamUGC.UserUGCList.__\u003C\u003EVotedOn = new SteamUGC.UserUGCList(nameof (VotedOn), 1);
        SteamUGC.UserUGCList.__\u003C\u003EVotedUp = new SteamUGC.UserUGCList(nameof (VotedUp), 2);
        SteamUGC.UserUGCList.__\u003C\u003EVotedDown = new SteamUGC.UserUGCList(nameof (VotedDown), 3);
        SteamUGC.UserUGCList.__\u003C\u003EWillVoteLater = new SteamUGC.UserUGCList(nameof (WillVoteLater), 4);
        SteamUGC.UserUGCList.__\u003C\u003EFavorited = new SteamUGC.UserUGCList(nameof (Favorited), 5);
        SteamUGC.UserUGCList.__\u003C\u003ESubscribed = new SteamUGC.UserUGCList(nameof (Subscribed), 6);
        SteamUGC.UserUGCList.__\u003C\u003EUsedOrPlayed = new SteamUGC.UserUGCList(nameof (UsedOrPlayed), 7);
        SteamUGC.UserUGCList.__\u003C\u003EFollowed = new SteamUGC.UserUGCList(nameof (Followed), 8);
        SteamUGC.UserUGCList.\u0024VALUES = new SteamUGC.UserUGCList[9]
        {
          SteamUGC.UserUGCList.__\u003C\u003EPublished,
          SteamUGC.UserUGCList.__\u003C\u003EVotedOn,
          SteamUGC.UserUGCList.__\u003C\u003EVotedUp,
          SteamUGC.UserUGCList.__\u003C\u003EVotedDown,
          SteamUGC.UserUGCList.__\u003C\u003EWillVoteLater,
          SteamUGC.UserUGCList.__\u003C\u003EFavorited,
          SteamUGC.UserUGCList.__\u003C\u003ESubscribed,
          SteamUGC.UserUGCList.__\u003C\u003EUsedOrPlayed,
          SteamUGC.UserUGCList.__\u003C\u003EFollowed
        };
      }

      [Modifiers]
      public static SteamUGC.UserUGCList Published
      {
        [HideFromJava] get => SteamUGC.UserUGCList.__\u003C\u003EPublished;
      }

      [Modifiers]
      public static SteamUGC.UserUGCList VotedOn
      {
        [HideFromJava] get => SteamUGC.UserUGCList.__\u003C\u003EVotedOn;
      }

      [Modifiers]
      public static SteamUGC.UserUGCList VotedUp
      {
        [HideFromJava] get => SteamUGC.UserUGCList.__\u003C\u003EVotedUp;
      }

      [Modifiers]
      public static SteamUGC.UserUGCList VotedDown
      {
        [HideFromJava] get => SteamUGC.UserUGCList.__\u003C\u003EVotedDown;
      }

      [Modifiers]
      public static SteamUGC.UserUGCList WillVoteLater
      {
        [HideFromJava] get => SteamUGC.UserUGCList.__\u003C\u003EWillVoteLater;
      }

      [Modifiers]
      public static SteamUGC.UserUGCList Favorited
      {
        [HideFromJava] get => SteamUGC.UserUGCList.__\u003C\u003EFavorited;
      }

      [Modifiers]
      public static SteamUGC.UserUGCList Subscribed
      {
        [HideFromJava] get => SteamUGC.UserUGCList.__\u003C\u003ESubscribed;
      }

      [Modifiers]
      public static SteamUGC.UserUGCList UsedOrPlayed
      {
        [HideFromJava] get => SteamUGC.UserUGCList.__\u003C\u003EUsedOrPlayed;
      }

      [Modifiers]
      public static SteamUGC.UserUGCList Followed
      {
        [HideFromJava] get => SteamUGC.UserUGCList.__\u003C\u003EFollowed;
      }

      [HideFromJava]
      [Serializable]
      public enum __Enum
      {
        Published,
        VotedOn,
        VotedUp,
        VotedDown,
        WillVoteLater,
        Favorited,
        Subscribed,
        UsedOrPlayed,
        Followed,
      }
    }

    [InnerClass]
    [Signature("Ljava/lang/Enum<Lcom/codedisaster/steamworks/SteamUGC$UserUGCListSortOrder;>;")]
    [Modifiers]
    [Serializable]
    public sealed class UserUGCListSortOrder : Enum
    {
      [Modifiers]
      internal static SteamUGC.UserUGCListSortOrder __\u003C\u003ECreationOrderDesc;
      [Modifiers]
      internal static SteamUGC.UserUGCListSortOrder __\u003C\u003ECreationOrderAsc;
      [Modifiers]
      internal static SteamUGC.UserUGCListSortOrder __\u003C\u003ETitleAsc;
      [Modifiers]
      internal static SteamUGC.UserUGCListSortOrder __\u003C\u003ELastUpdatedDesc;
      [Modifiers]
      internal static SteamUGC.UserUGCListSortOrder __\u003C\u003ESubscriptionDateDesc;
      [Modifiers]
      internal static SteamUGC.UserUGCListSortOrder __\u003C\u003EVoteScoreDesc;
      [Modifiers]
      internal static SteamUGC.UserUGCListSortOrder __\u003C\u003EForModeration;
      [Modifiers]
      private static SteamUGC.UserUGCListSortOrder[] \u0024VALUES;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [Signature("()V")]
      [LineNumberTable(42)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private UserUGCListSortOrder([In] string obj0, [In] int obj1)
        : base(obj0, obj1)
      {
        GC.KeepAlive((object) this);
      }

      [LineNumberTable(42)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static SteamUGC.UserUGCListSortOrder[] values() => (SteamUGC.UserUGCListSortOrder[]) SteamUGC.UserUGCListSortOrder.\u0024VALUES.Clone();

      [LineNumberTable(42)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static SteamUGC.UserUGCListSortOrder valueOf(string name) => (SteamUGC.UserUGCListSortOrder) Enum.valueOf((Class) ClassLiteral<SteamUGC.UserUGCListSortOrder>.Value, name);

      [LineNumberTable(new byte[] {159, 132, 173, 112, 112, 112, 112, 112, 112, 240, 57})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static UserUGCListSortOrder()
      {
        if (ByteCodeHelper.isAlreadyInited("com.codedisaster.steamworks.SteamUGC$UserUGCListSortOrder"))
          return;
        SteamUGC.UserUGCListSortOrder.__\u003C\u003ECreationOrderDesc = new SteamUGC.UserUGCListSortOrder(nameof (CreationOrderDesc), 0);
        SteamUGC.UserUGCListSortOrder.__\u003C\u003ECreationOrderAsc = new SteamUGC.UserUGCListSortOrder(nameof (CreationOrderAsc), 1);
        SteamUGC.UserUGCListSortOrder.__\u003C\u003ETitleAsc = new SteamUGC.UserUGCListSortOrder(nameof (TitleAsc), 2);
        SteamUGC.UserUGCListSortOrder.__\u003C\u003ELastUpdatedDesc = new SteamUGC.UserUGCListSortOrder(nameof (LastUpdatedDesc), 3);
        SteamUGC.UserUGCListSortOrder.__\u003C\u003ESubscriptionDateDesc = new SteamUGC.UserUGCListSortOrder(nameof (SubscriptionDateDesc), 4);
        SteamUGC.UserUGCListSortOrder.__\u003C\u003EVoteScoreDesc = new SteamUGC.UserUGCListSortOrder(nameof (VoteScoreDesc), 5);
        SteamUGC.UserUGCListSortOrder.__\u003C\u003EForModeration = new SteamUGC.UserUGCListSortOrder(nameof (ForModeration), 6);
        SteamUGC.UserUGCListSortOrder.\u0024VALUES = new SteamUGC.UserUGCListSortOrder[7]
        {
          SteamUGC.UserUGCListSortOrder.__\u003C\u003ECreationOrderDesc,
          SteamUGC.UserUGCListSortOrder.__\u003C\u003ECreationOrderAsc,
          SteamUGC.UserUGCListSortOrder.__\u003C\u003ETitleAsc,
          SteamUGC.UserUGCListSortOrder.__\u003C\u003ELastUpdatedDesc,
          SteamUGC.UserUGCListSortOrder.__\u003C\u003ESubscriptionDateDesc,
          SteamUGC.UserUGCListSortOrder.__\u003C\u003EVoteScoreDesc,
          SteamUGC.UserUGCListSortOrder.__\u003C\u003EForModeration
        };
      }

      [Modifiers]
      public static SteamUGC.UserUGCListSortOrder CreationOrderDesc
      {
        [HideFromJava] get => SteamUGC.UserUGCListSortOrder.__\u003C\u003ECreationOrderDesc;
      }

      [Modifiers]
      public static SteamUGC.UserUGCListSortOrder CreationOrderAsc
      {
        [HideFromJava] get => SteamUGC.UserUGCListSortOrder.__\u003C\u003ECreationOrderAsc;
      }

      [Modifiers]
      public static SteamUGC.UserUGCListSortOrder TitleAsc
      {
        [HideFromJava] get => SteamUGC.UserUGCListSortOrder.__\u003C\u003ETitleAsc;
      }

      [Modifiers]
      public static SteamUGC.UserUGCListSortOrder LastUpdatedDesc
      {
        [HideFromJava] get => SteamUGC.UserUGCListSortOrder.__\u003C\u003ELastUpdatedDesc;
      }

      [Modifiers]
      public static SteamUGC.UserUGCListSortOrder SubscriptionDateDesc
      {
        [HideFromJava] get => SteamUGC.UserUGCListSortOrder.__\u003C\u003ESubscriptionDateDesc;
      }

      [Modifiers]
      public static SteamUGC.UserUGCListSortOrder VoteScoreDesc
      {
        [HideFromJava] get => SteamUGC.UserUGCListSortOrder.__\u003C\u003EVoteScoreDesc;
      }

      [Modifiers]
      public static SteamUGC.UserUGCListSortOrder ForModeration
      {
        [HideFromJava] get => SteamUGC.UserUGCListSortOrder.__\u003C\u003EForModeration;
      }

      [HideFromJava]
      [Serializable]
      public enum __Enum
      {
        CreationOrderDesc,
        CreationOrderAsc,
        TitleAsc,
        LastUpdatedDesc,
        SubscriptionDateDesc,
        VoteScoreDesc,
        ForModeration,
      }
    }

    private new sealed class __\u003CCallerID\u003E : CallerID
    {
      internal __\u003CCallerID\u003E()
      {
      }
    }
  }
}
