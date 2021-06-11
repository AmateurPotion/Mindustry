// Decompiled with JetBrains decompiler
// Type: com.codedisaster.steamworks.SteamRemoteStorage
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.nio;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace com.codedisaster.steamworks
{
  public class SteamRemoteStorage : SteamInterface
  {
    static IntPtr __\u003Cjniptr\u003EcreateCallback\u0028Lcom\u002Fcodedisaster\u002Fsteamworks\u002FSteamRemoteStorageCallbackAdapter\u003B\u0029J;
    [SpecialName]
    private static CallerID __\u003CcallerID\u003E;
    static IntPtr __\u003Cjniptr\u003EfileWrite\u0028JLjava\u002Flang\u002FString\u003BLjava\u002Fnio\u002FByteBuffer\u003BII\u0029Z;
    static IntPtr __\u003Cjniptr\u003EfileRead\u0028JLjava\u002Flang\u002FString\u003BLjava\u002Fnio\u002FByteBuffer\u003BII\u0029Z;
    static IntPtr __\u003Cjniptr\u003EfileWriteAsync\u0028JJLjava\u002Flang\u002FString\u003BLjava\u002Fnio\u002FByteBuffer\u003BII\u0029J;
    static IntPtr __\u003Cjniptr\u003EfileReadAsync\u0028JJLjava\u002Flang\u002FString\u003BII\u0029J;
    static IntPtr __\u003Cjniptr\u003EfileReadAsyncComplete\u0028JJLjava\u002Fnio\u002FByteBuffer\u003BJI\u0029Z;
    static IntPtr __\u003Cjniptr\u003EfileForget\u0028JLjava\u002Flang\u002FString\u003B\u0029Z;
    static IntPtr __\u003Cjniptr\u003EfileDelete\u0028JLjava\u002Flang\u002FString\u003B\u0029Z;
    static IntPtr __\u003Cjniptr\u003EfileShare\u0028JJLjava\u002Flang\u002FString\u003B\u0029J;
    static IntPtr __\u003Cjniptr\u003EsetSyncPlatforms\u0028JLjava\u002Flang\u002FString\u003BI\u0029Z;
    static IntPtr __\u003Cjniptr\u003EfileWriteStreamOpen\u0028JLjava\u002Flang\u002FString\u003B\u0029J;
    static IntPtr __\u003Cjniptr\u003EfileWriteStreamWriteChunk\u0028JJLjava\u002Fnio\u002FByteBuffer\u003BII\u0029Z;
    static IntPtr __\u003Cjniptr\u003EfileWriteStreamClose\u0028JJ\u0029Z;
    static IntPtr __\u003Cjniptr\u003EfileWriteStreamCancel\u0028JJ\u0029Z;
    static IntPtr __\u003Cjniptr\u003EfileExists\u0028JLjava\u002Flang\u002FString\u003B\u0029Z;
    static IntPtr __\u003Cjniptr\u003EfilePersisted\u0028JLjava\u002Flang\u002FString\u003B\u0029Z;
    static IntPtr __\u003Cjniptr\u003EgetFileSize\u0028JLjava\u002Flang\u002FString\u003B\u0029I;
    static IntPtr __\u003Cjniptr\u003EgetFileTimestamp\u0028JLjava\u002Flang\u002FString\u003B\u0029J;
    static IntPtr __\u003Cjniptr\u003EgetSyncPlatforms\u0028JLjava\u002Flang\u002FString\u003B\u0029I;
    static IntPtr __\u003Cjniptr\u003EgetFileCount\u0028J\u0029I;
    static IntPtr __\u003Cjniptr\u003EgetFileNameAndSize\u0028JI\u005BI\u0029Ljava\u002Flang\u002FString\u003B;
    static IntPtr __\u003Cjniptr\u003EgetQuota\u0028J\u005BJ\u005BJ\u0029Z;
    static IntPtr __\u003Cjniptr\u003EisCloudEnabledForAccount\u0028J\u0029Z;
    static IntPtr __\u003Cjniptr\u003EisCloudEnabledForApp\u0028J\u0029Z;
    static IntPtr __\u003Cjniptr\u003EsetCloudEnabledForApp\u0028JZ\u0029V;
    static IntPtr __\u003Cjniptr\u003EugcDownload\u0028JJJI\u0029J;
    static IntPtr __\u003Cjniptr\u003EgetUGCDownloadProgress\u0028JJ\u005BI\u005BI\u0029Z;
    static IntPtr __\u003Cjniptr\u003EugcRead\u0028JJLjava\u002Fnio\u002FByteBuffer\u003BIIII\u0029I;
    static IntPtr __\u003Cjniptr\u003EgetCachedUGCCount\u0028J\u0029I;
    static IntPtr __\u003Cjniptr\u003EgetCachedUGCHandle\u0028JI\u0029J;
    static IntPtr __\u003Cjniptr\u003EpublishWorkshopFile\u0028JJLjava\u002Flang\u002FString\u003BLjava\u002Flang\u002FString\u003BILjava\u002Flang\u002FString\u003BLjava\u002Flang\u002FString\u003BI\u005BLjava\u002Flang\u002FString\u003BII\u0029J;
    static IntPtr __\u003Cjniptr\u003EcreatePublishedFileUpdateRequest\u0028JJ\u0029J;
    static IntPtr __\u003Cjniptr\u003EupdatePublishedFileFile\u0028JJLjava\u002Flang\u002FString\u003B\u0029Z;
    static IntPtr __\u003Cjniptr\u003EupdatePublishedFilePreviewFile\u0028JJLjava\u002Flang\u002FString\u003B\u0029Z;
    static IntPtr __\u003Cjniptr\u003EupdatePublishedFileTitle\u0028JJLjava\u002Flang\u002FString\u003B\u0029Z;
    static IntPtr __\u003Cjniptr\u003EupdatePublishedFileDescription\u0028JJLjava\u002Flang\u002FString\u003B\u0029Z;
    static IntPtr __\u003Cjniptr\u003EupdatePublishedFileVisibility\u0028JJI\u0029Z;
    static IntPtr __\u003Cjniptr\u003EupdatePublishedFileTags\u0028JJ\u005BLjava\u002Flang\u002FString\u003BI\u0029Z;
    static IntPtr __\u003Cjniptr\u003EcommitPublishedFileUpdate\u0028JJJ\u0029J;

    [Modifiers]
    private static long createCallback([In] SteamRemoteStorageCallbackAdapter obj0)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamRemoteStorage.__\u003Cjniptr\u003EcreateCallback\u0028Lcom\u002Fcodedisaster\u002Fsteamworks\u002FSteamRemoteStorageCallbackAdapter\u003B\u0029J == IntPtr.Zero)
        SteamRemoteStorage.__\u003Cjniptr\u003EcreateCallback\u0028Lcom\u002Fcodedisaster\u002Fsteamworks\u002FSteamRemoteStorageCallbackAdapter\u003B\u0029J = JNI.Frame.GetFuncPtr(SteamRemoteStorage.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamRemoteStorage", nameof (createCallback), "(Lcom/codedisaster/steamworks/SteamRemoteStorageCallbackAdapter;)J");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamRemoteStorage.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamRemoteStorage>.Value);
        IntPtr num4 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj0);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<long (IntPtr, IntPtr, IntPtr)>) SteamRemoteStorage.__\u003Cjniptr\u003EcreateCallback\u0028Lcom\u002Fcodedisaster\u002Fsteamworks\u002FSteamRemoteStorageCallbackAdapter\u003B\u0029J)(num2, num3, num4);
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
    private static bool fileWrite([In] long obj0, [In] string obj1, [In] ByteBuffer obj2, [In] int obj3, [In] int obj4)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamRemoteStorage.__\u003Cjniptr\u003EfileWrite\u0028JLjava\u002Flang\u002FString\u003BLjava\u002Fnio\u002FByteBuffer\u003BII\u0029Z == IntPtr.Zero)
        SteamRemoteStorage.__\u003Cjniptr\u003EfileWrite\u0028JLjava\u002Flang\u002FString\u003BLjava\u002Fnio\u002FByteBuffer\u003BII\u0029Z = JNI.Frame.GetFuncPtr(SteamRemoteStorage.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamRemoteStorage", nameof (fileWrite), "(JLjava/lang/String;Ljava/nio/ByteBuffer;II)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamRemoteStorage.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamRemoteStorage>.Value);
        long num4 = obj0;
        IntPtr num5 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj1);
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj2);
        int num7 = obj3;
        int num8 = obj4;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, long, IntPtr, IntPtr, int, int)>) SteamRemoteStorage.__\u003Cjniptr\u003EfileWrite\u0028JLjava\u002Flang\u002FString\u003BLjava\u002Fnio\u002FByteBuffer\u003BII\u0029Z)((int) num2, (int) num3, (IntPtr) num4, num5, (long) num6, (IntPtr) num7, (IntPtr) num8);
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
    private static bool fileRead([In] long obj0, [In] string obj1, [In] ByteBuffer obj2, [In] int obj3, [In] int obj4)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamRemoteStorage.__\u003Cjniptr\u003EfileRead\u0028JLjava\u002Flang\u002FString\u003BLjava\u002Fnio\u002FByteBuffer\u003BII\u0029Z == IntPtr.Zero)
        SteamRemoteStorage.__\u003Cjniptr\u003EfileRead\u0028JLjava\u002Flang\u002FString\u003BLjava\u002Fnio\u002FByteBuffer\u003BII\u0029Z = JNI.Frame.GetFuncPtr(SteamRemoteStorage.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamRemoteStorage", nameof (fileRead), "(JLjava/lang/String;Ljava/nio/ByteBuffer;II)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamRemoteStorage.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamRemoteStorage>.Value);
        long num4 = obj0;
        IntPtr num5 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj1);
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj2);
        int num7 = obj3;
        int num8 = obj4;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, long, IntPtr, IntPtr, int, int)>) SteamRemoteStorage.__\u003Cjniptr\u003EfileRead\u0028JLjava\u002Flang\u002FString\u003BLjava\u002Fnio\u002FByteBuffer\u003BII\u0029Z)((int) num2, (int) num3, (IntPtr) num4, num5, (long) num6, (IntPtr) num7, (IntPtr) num8);
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
    private static long fileWriteAsync(
      [In] long obj0,
      [In] long obj1,
      [In] string obj2,
      [In] ByteBuffer obj3,
      [In] int obj4,
      [In] int obj5)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamRemoteStorage.__\u003Cjniptr\u003EfileWriteAsync\u0028JJLjava\u002Flang\u002FString\u003BLjava\u002Fnio\u002FByteBuffer\u003BII\u0029J == IntPtr.Zero)
        SteamRemoteStorage.__\u003Cjniptr\u003EfileWriteAsync\u0028JJLjava\u002Flang\u002FString\u003BLjava\u002Fnio\u002FByteBuffer\u003BII\u0029J = JNI.Frame.GetFuncPtr(SteamRemoteStorage.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamRemoteStorage", nameof (fileWriteAsync), "(JJLjava/lang/String;Ljava/nio/ByteBuffer;II)J");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamRemoteStorage.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamRemoteStorage>.Value);
        long num4 = obj0;
        long num5 = obj1;
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj2);
        IntPtr num7 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj3);
        int num8 = obj4;
        int num9 = obj5;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<long (IntPtr, IntPtr, long, long, IntPtr, IntPtr, int, int)>) SteamRemoteStorage.__\u003Cjniptr\u003EfileWriteAsync\u0028JJLjava\u002Flang\u002FString\u003BLjava\u002Fnio\u002FByteBuffer\u003BII\u0029J)((int) num2, (int) num3, (IntPtr) num4, (IntPtr) num5, (long) num6, (long) num7, (IntPtr) num8, (IntPtr) num9);
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
    private static long fileReadAsync([In] long obj0, [In] long obj1, [In] string obj2, [In] int obj3, [In] int obj4)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamRemoteStorage.__\u003Cjniptr\u003EfileReadAsync\u0028JJLjava\u002Flang\u002FString\u003BII\u0029J == IntPtr.Zero)
        SteamRemoteStorage.__\u003Cjniptr\u003EfileReadAsync\u0028JJLjava\u002Flang\u002FString\u003BII\u0029J = JNI.Frame.GetFuncPtr(SteamRemoteStorage.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamRemoteStorage", nameof (fileReadAsync), "(JJLjava/lang/String;II)J");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamRemoteStorage.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamRemoteStorage>.Value);
        long num4 = obj0;
        long num5 = obj1;
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj2);
        int num7 = obj3;
        int num8 = obj4;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<long (IntPtr, IntPtr, long, long, IntPtr, int, int)>) SteamRemoteStorage.__\u003Cjniptr\u003EfileReadAsync\u0028JJLjava\u002Flang\u002FString\u003BII\u0029J)((int) num2, (int) num3, (IntPtr) num4, num5, (long) num6, (IntPtr) num7, (IntPtr) num8);
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
    private static bool fileReadAsyncComplete(
      [In] long obj0,
      [In] long obj1,
      [In] ByteBuffer obj2,
      [In] long obj3,
      [In] int obj4)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamRemoteStorage.__\u003Cjniptr\u003EfileReadAsyncComplete\u0028JJLjava\u002Fnio\u002FByteBuffer\u003BJI\u0029Z == IntPtr.Zero)
        SteamRemoteStorage.__\u003Cjniptr\u003EfileReadAsyncComplete\u0028JJLjava\u002Fnio\u002FByteBuffer\u003BJI\u0029Z = JNI.Frame.GetFuncPtr(SteamRemoteStorage.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamRemoteStorage", nameof (fileReadAsyncComplete), "(JJLjava/nio/ByteBuffer;JI)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamRemoteStorage.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamRemoteStorage>.Value);
        long num4 = obj0;
        long num5 = obj1;
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj2);
        long num7 = obj3;
        int num8 = obj4;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, long, long, IntPtr, long, int)>) SteamRemoteStorage.__\u003Cjniptr\u003EfileReadAsyncComplete\u0028JJLjava\u002Fnio\u002FByteBuffer\u003BJI\u0029Z)((int) num2, (long) num3, (IntPtr) num4, num5, (long) num6, (IntPtr) num7, (IntPtr) num8);
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
    private static bool fileForget([In] long obj0, [In] string obj1)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamRemoteStorage.__\u003Cjniptr\u003EfileForget\u0028JLjava\u002Flang\u002FString\u003B\u0029Z == IntPtr.Zero)
        SteamRemoteStorage.__\u003Cjniptr\u003EfileForget\u0028JLjava\u002Flang\u002FString\u003B\u0029Z = JNI.Frame.GetFuncPtr(SteamRemoteStorage.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamRemoteStorage", nameof (fileForget), "(JLjava/lang/String;)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamRemoteStorage.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamRemoteStorage>.Value);
        long num4 = obj0;
        IntPtr num5 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj1);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, long, IntPtr)>) SteamRemoteStorage.__\u003Cjniptr\u003EfileForget\u0028JLjava\u002Flang\u002FString\u003B\u0029Z)(num2, (long) num3, (IntPtr) num4, num5);
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
    private static bool fileDelete([In] long obj0, [In] string obj1)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamRemoteStorage.__\u003Cjniptr\u003EfileDelete\u0028JLjava\u002Flang\u002FString\u003B\u0029Z == IntPtr.Zero)
        SteamRemoteStorage.__\u003Cjniptr\u003EfileDelete\u0028JLjava\u002Flang\u002FString\u003B\u0029Z = JNI.Frame.GetFuncPtr(SteamRemoteStorage.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamRemoteStorage", nameof (fileDelete), "(JLjava/lang/String;)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamRemoteStorage.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamRemoteStorage>.Value);
        long num4 = obj0;
        IntPtr num5 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj1);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, long, IntPtr)>) SteamRemoteStorage.__\u003Cjniptr\u003EfileDelete\u0028JLjava\u002Flang\u002FString\u003B\u0029Z)(num2, (long) num3, (IntPtr) num4, num5);
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
    private static long fileShare([In] long obj0, [In] long obj1, [In] string obj2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamRemoteStorage.__\u003Cjniptr\u003EfileShare\u0028JJLjava\u002Flang\u002FString\u003B\u0029J == IntPtr.Zero)
        SteamRemoteStorage.__\u003Cjniptr\u003EfileShare\u0028JJLjava\u002Flang\u002FString\u003B\u0029J = JNI.Frame.GetFuncPtr(SteamRemoteStorage.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamRemoteStorage", nameof (fileShare), "(JJLjava/lang/String;)J");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamRemoteStorage.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamRemoteStorage>.Value);
        long num4 = obj0;
        long num5 = obj1;
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj2);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<long (IntPtr, IntPtr, long, long, IntPtr)>) SteamRemoteStorage.__\u003Cjniptr\u003EfileShare\u0028JJLjava\u002Flang\u002FString\u003B\u0029J)(num2, (long) num3, num4, (IntPtr) num5, num6);
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
    private static bool setSyncPlatforms([In] long obj0, [In] string obj1, [In] int obj2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamRemoteStorage.__\u003Cjniptr\u003EsetSyncPlatforms\u0028JLjava\u002Flang\u002FString\u003BI\u0029Z == IntPtr.Zero)
        SteamRemoteStorage.__\u003Cjniptr\u003EsetSyncPlatforms\u0028JLjava\u002Flang\u002FString\u003BI\u0029Z = JNI.Frame.GetFuncPtr(SteamRemoteStorage.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamRemoteStorage", nameof (setSyncPlatforms), "(JLjava/lang/String;I)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamRemoteStorage.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamRemoteStorage>.Value);
        long num4 = obj0;
        IntPtr num5 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj1);
        int num6 = obj2;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, long, IntPtr, int)>) SteamRemoteStorage.__\u003Cjniptr\u003EsetSyncPlatforms\u0028JLjava\u002Flang\u002FString\u003BI\u0029Z)((int) num2, num3, num4, num5, (IntPtr) num6);
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
    private static long fileWriteStreamOpen([In] long obj0, [In] string obj1)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamRemoteStorage.__\u003Cjniptr\u003EfileWriteStreamOpen\u0028JLjava\u002Flang\u002FString\u003B\u0029J == IntPtr.Zero)
        SteamRemoteStorage.__\u003Cjniptr\u003EfileWriteStreamOpen\u0028JLjava\u002Flang\u002FString\u003B\u0029J = JNI.Frame.GetFuncPtr(SteamRemoteStorage.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamRemoteStorage", nameof (fileWriteStreamOpen), "(JLjava/lang/String;)J");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamRemoteStorage.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamRemoteStorage>.Value);
        long num4 = obj0;
        IntPtr num5 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj1);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<long (IntPtr, IntPtr, long, IntPtr)>) SteamRemoteStorage.__\u003Cjniptr\u003EfileWriteStreamOpen\u0028JLjava\u002Flang\u002FString\u003B\u0029J)(num2, (long) num3, (IntPtr) num4, num5);
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
    private static bool fileWriteStreamWriteChunk(
      [In] long obj0,
      [In] long obj1,
      [In] ByteBuffer obj2,
      [In] int obj3,
      [In] int obj4)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamRemoteStorage.__\u003Cjniptr\u003EfileWriteStreamWriteChunk\u0028JJLjava\u002Fnio\u002FByteBuffer\u003BII\u0029Z == IntPtr.Zero)
        SteamRemoteStorage.__\u003Cjniptr\u003EfileWriteStreamWriteChunk\u0028JJLjava\u002Fnio\u002FByteBuffer\u003BII\u0029Z = JNI.Frame.GetFuncPtr(SteamRemoteStorage.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamRemoteStorage", nameof (fileWriteStreamWriteChunk), "(JJLjava/nio/ByteBuffer;II)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamRemoteStorage.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamRemoteStorage>.Value);
        long num4 = obj0;
        long num5 = obj1;
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj2);
        int num7 = obj3;
        int num8 = obj4;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, long, long, IntPtr, int, int)>) SteamRemoteStorage.__\u003Cjniptr\u003EfileWriteStreamWriteChunk\u0028JJLjava\u002Fnio\u002FByteBuffer\u003BII\u0029Z)((int) num2, (int) num3, (IntPtr) num4, num5, (long) num6, (IntPtr) num7, (IntPtr) num8);
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
    private static bool fileWriteStreamClose([In] long obj0, [In] long obj1)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamRemoteStorage.__\u003Cjniptr\u003EfileWriteStreamClose\u0028JJ\u0029Z == IntPtr.Zero)
        SteamRemoteStorage.__\u003Cjniptr\u003EfileWriteStreamClose\u0028JJ\u0029Z = JNI.Frame.GetFuncPtr(SteamRemoteStorage.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamRemoteStorage", nameof (fileWriteStreamClose), "(JJ)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamRemoteStorage.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamRemoteStorage>.Value);
        long num4 = obj0;
        long num5 = obj1;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, long, long)>) SteamRemoteStorage.__\u003Cjniptr\u003EfileWriteStreamClose\u0028JJ\u0029Z)((long) num2, (long) num3, (IntPtr) num4, (IntPtr) num5);
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
    private static bool fileWriteStreamCancel([In] long obj0, [In] long obj1)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamRemoteStorage.__\u003Cjniptr\u003EfileWriteStreamCancel\u0028JJ\u0029Z == IntPtr.Zero)
        SteamRemoteStorage.__\u003Cjniptr\u003EfileWriteStreamCancel\u0028JJ\u0029Z = JNI.Frame.GetFuncPtr(SteamRemoteStorage.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamRemoteStorage", nameof (fileWriteStreamCancel), "(JJ)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamRemoteStorage.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamRemoteStorage>.Value);
        long num4 = obj0;
        long num5 = obj1;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, long, long)>) SteamRemoteStorage.__\u003Cjniptr\u003EfileWriteStreamCancel\u0028JJ\u0029Z)((long) num2, (long) num3, (IntPtr) num4, (IntPtr) num5);
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
    private static bool fileExists([In] long obj0, [In] string obj1)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamRemoteStorage.__\u003Cjniptr\u003EfileExists\u0028JLjava\u002Flang\u002FString\u003B\u0029Z == IntPtr.Zero)
        SteamRemoteStorage.__\u003Cjniptr\u003EfileExists\u0028JLjava\u002Flang\u002FString\u003B\u0029Z = JNI.Frame.GetFuncPtr(SteamRemoteStorage.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamRemoteStorage", nameof (fileExists), "(JLjava/lang/String;)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamRemoteStorage.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamRemoteStorage>.Value);
        long num4 = obj0;
        IntPtr num5 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj1);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, long, IntPtr)>) SteamRemoteStorage.__\u003Cjniptr\u003EfileExists\u0028JLjava\u002Flang\u002FString\u003B\u0029Z)(num2, (long) num3, (IntPtr) num4, num5);
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
    private static bool filePersisted([In] long obj0, [In] string obj1)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamRemoteStorage.__\u003Cjniptr\u003EfilePersisted\u0028JLjava\u002Flang\u002FString\u003B\u0029Z == IntPtr.Zero)
        SteamRemoteStorage.__\u003Cjniptr\u003EfilePersisted\u0028JLjava\u002Flang\u002FString\u003B\u0029Z = JNI.Frame.GetFuncPtr(SteamRemoteStorage.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamRemoteStorage", nameof (filePersisted), "(JLjava/lang/String;)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamRemoteStorage.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamRemoteStorage>.Value);
        long num4 = obj0;
        IntPtr num5 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj1);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, long, IntPtr)>) SteamRemoteStorage.__\u003Cjniptr\u003EfilePersisted\u0028JLjava\u002Flang\u002FString\u003B\u0029Z)(num2, (long) num3, (IntPtr) num4, num5);
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
    private static int getFileSize([In] long obj0, [In] string obj1)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamRemoteStorage.__\u003Cjniptr\u003EgetFileSize\u0028JLjava\u002Flang\u002FString\u003B\u0029I == IntPtr.Zero)
        SteamRemoteStorage.__\u003Cjniptr\u003EgetFileSize\u0028JLjava\u002Flang\u002FString\u003B\u0029I = JNI.Frame.GetFuncPtr(SteamRemoteStorage.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamRemoteStorage", nameof (getFileSize), "(JLjava/lang/String;)I");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamRemoteStorage.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamRemoteStorage>.Value);
        long num4 = obj0;
        IntPtr num5 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj1);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<int (IntPtr, IntPtr, long, IntPtr)>) SteamRemoteStorage.__\u003Cjniptr\u003EgetFileSize\u0028JLjava\u002Flang\u002FString\u003B\u0029I)(num2, (long) num3, (IntPtr) num4, num5);
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
    private static long getFileTimestamp([In] long obj0, [In] string obj1)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamRemoteStorage.__\u003Cjniptr\u003EgetFileTimestamp\u0028JLjava\u002Flang\u002FString\u003B\u0029J == IntPtr.Zero)
        SteamRemoteStorage.__\u003Cjniptr\u003EgetFileTimestamp\u0028JLjava\u002Flang\u002FString\u003B\u0029J = JNI.Frame.GetFuncPtr(SteamRemoteStorage.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamRemoteStorage", nameof (getFileTimestamp), "(JLjava/lang/String;)J");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamRemoteStorage.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamRemoteStorage>.Value);
        long num4 = obj0;
        IntPtr num5 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj1);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<long (IntPtr, IntPtr, long, IntPtr)>) SteamRemoteStorage.__\u003Cjniptr\u003EgetFileTimestamp\u0028JLjava\u002Flang\u002FString\u003B\u0029J)(num2, (long) num3, (IntPtr) num4, num5);
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
    private static int getSyncPlatforms([In] long obj0, [In] string obj1)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamRemoteStorage.__\u003Cjniptr\u003EgetSyncPlatforms\u0028JLjava\u002Flang\u002FString\u003B\u0029I == IntPtr.Zero)
        SteamRemoteStorage.__\u003Cjniptr\u003EgetSyncPlatforms\u0028JLjava\u002Flang\u002FString\u003B\u0029I = JNI.Frame.GetFuncPtr(SteamRemoteStorage.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamRemoteStorage", nameof (getSyncPlatforms), "(JLjava/lang/String;)I");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamRemoteStorage.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamRemoteStorage>.Value);
        long num4 = obj0;
        IntPtr num5 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj1);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<int (IntPtr, IntPtr, long, IntPtr)>) SteamRemoteStorage.__\u003Cjniptr\u003EgetSyncPlatforms\u0028JLjava\u002Flang\u002FString\u003B\u0029I)(num2, (long) num3, (IntPtr) num4, num5);
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
    private static int getFileCount([In] long obj0)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamRemoteStorage.__\u003Cjniptr\u003EgetFileCount\u0028J\u0029I == IntPtr.Zero)
        SteamRemoteStorage.__\u003Cjniptr\u003EgetFileCount\u0028J\u0029I = JNI.Frame.GetFuncPtr(SteamRemoteStorage.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamRemoteStorage", nameof (getFileCount), "(J)I");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamRemoteStorage.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamRemoteStorage>.Value);
        long num4 = obj0;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<int (IntPtr, IntPtr, long)>) SteamRemoteStorage.__\u003Cjniptr\u003EgetFileCount\u0028J\u0029I)((long) num2, num3, (IntPtr) num4);
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
    private static string getFileNameAndSize([In] long obj0, [In] int obj1, [In] int[] obj2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamRemoteStorage.__\u003Cjniptr\u003EgetFileNameAndSize\u0028JI\u005BI\u0029Ljava\u002Flang\u002FString\u003B == IntPtr.Zero)
        SteamRemoteStorage.__\u003Cjniptr\u003EgetFileNameAndSize\u0028JI\u005BI\u0029Ljava\u002Flang\u002FString\u003B = JNI.Frame.GetFuncPtr(SteamRemoteStorage.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamRemoteStorage", nameof (getFileNameAndSize), "(JI[I)Ljava/lang/String;");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamRemoteStorage.__\u003CGetCallerID\u003E());
      try
      {
        ref JNI.Frame local = ref frame;
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamRemoteStorage>.Value);
        long num4 = obj0;
        int num5 = obj1;
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj2);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        IntPtr num7 = __calli((__FnPtr<IntPtr (IntPtr, IntPtr, long, int, IntPtr)>) SteamRemoteStorage.__\u003Cjniptr\u003EgetFileNameAndSize\u0028JI\u005BI\u0029Ljava\u002Flang\u002FString\u003B)(num2, (int) num3, num4, (IntPtr) num5, num6);
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
    private static bool getQuota([In] long obj0, [In] long[] obj1, [In] long[] obj2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamRemoteStorage.__\u003Cjniptr\u003EgetQuota\u0028J\u005BJ\u005BJ\u0029Z == IntPtr.Zero)
        SteamRemoteStorage.__\u003Cjniptr\u003EgetQuota\u0028J\u005BJ\u005BJ\u0029Z = JNI.Frame.GetFuncPtr(SteamRemoteStorage.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamRemoteStorage", nameof (getQuota), "(J[J[J)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamRemoteStorage.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamRemoteStorage>.Value);
        long num4 = obj0;
        IntPtr num5 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj1);
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj2);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, long, IntPtr, IntPtr)>) SteamRemoteStorage.__\u003Cjniptr\u003EgetQuota\u0028J\u005BJ\u005BJ\u0029Z)(num2, num3, num4, num5, num6);
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
    private static bool isCloudEnabledForAccount([In] long obj0)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamRemoteStorage.__\u003Cjniptr\u003EisCloudEnabledForAccount\u0028J\u0029Z == IntPtr.Zero)
        SteamRemoteStorage.__\u003Cjniptr\u003EisCloudEnabledForAccount\u0028J\u0029Z = JNI.Frame.GetFuncPtr(SteamRemoteStorage.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamRemoteStorage", nameof (isCloudEnabledForAccount), "(J)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamRemoteStorage.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamRemoteStorage>.Value);
        long num4 = obj0;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, long)>) SteamRemoteStorage.__\u003Cjniptr\u003EisCloudEnabledForAccount\u0028J\u0029Z)((long) num2, num3, (IntPtr) num4);
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
    private static bool isCloudEnabledForApp([In] long obj0)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamRemoteStorage.__\u003Cjniptr\u003EisCloudEnabledForApp\u0028J\u0029Z == IntPtr.Zero)
        SteamRemoteStorage.__\u003Cjniptr\u003EisCloudEnabledForApp\u0028J\u0029Z = JNI.Frame.GetFuncPtr(SteamRemoteStorage.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamRemoteStorage", nameof (isCloudEnabledForApp), "(J)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamRemoteStorage.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamRemoteStorage>.Value);
        long num4 = obj0;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, long)>) SteamRemoteStorage.__\u003Cjniptr\u003EisCloudEnabledForApp\u0028J\u0029Z)((long) num2, num3, (IntPtr) num4);
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
    private static void setCloudEnabledForApp([In] long obj0, [In] bool obj1)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamRemoteStorage.__\u003Cjniptr\u003EsetCloudEnabledForApp\u0028JZ\u0029V == IntPtr.Zero)
        SteamRemoteStorage.__\u003Cjniptr\u003EsetCloudEnabledForApp\u0028JZ\u0029V = JNI.Frame.GetFuncPtr(SteamRemoteStorage.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamRemoteStorage", nameof (setCloudEnabledForApp), "(JZ)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamRemoteStorage.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamRemoteStorage>.Value);
        long num4 = obj0;
        int num5 = obj1 ? 1 : 0;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, long, bool)>) SteamRemoteStorage.__\u003Cjniptr\u003EsetCloudEnabledForApp\u0028JZ\u0029V)((bool) num2, (long) num3, (IntPtr) num4, (IntPtr) num5);
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
    private static long ugcDownload([In] long obj0, [In] long obj1, [In] long obj2, [In] int obj3)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamRemoteStorage.__\u003Cjniptr\u003EugcDownload\u0028JJJI\u0029J == IntPtr.Zero)
        SteamRemoteStorage.__\u003Cjniptr\u003EugcDownload\u0028JJJI\u0029J = JNI.Frame.GetFuncPtr(SteamRemoteStorage.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamRemoteStorage", nameof (ugcDownload), "(JJJI)J");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamRemoteStorage.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamRemoteStorage>.Value);
        long num4 = obj0;
        long num5 = obj1;
        long num6 = obj2;
        int num7 = obj3;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<long (IntPtr, IntPtr, long, long, long, int)>) SteamRemoteStorage.__\u003Cjniptr\u003EugcDownload\u0028JJJI\u0029J)((int) num2, (long) num3, num4, num5, (IntPtr) num6, (IntPtr) num7);
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
    private static bool getUGCDownloadProgress([In] long obj0, [In] long obj1, [In] int[] obj2, [In] int[] obj3)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamRemoteStorage.__\u003Cjniptr\u003EgetUGCDownloadProgress\u0028JJ\u005BI\u005BI\u0029Z == IntPtr.Zero)
        SteamRemoteStorage.__\u003Cjniptr\u003EgetUGCDownloadProgress\u0028JJ\u005BI\u005BI\u0029Z = JNI.Frame.GetFuncPtr(SteamRemoteStorage.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamRemoteStorage", nameof (getUGCDownloadProgress), "(JJ[I[I)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamRemoteStorage.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamRemoteStorage>.Value);
        long num4 = obj0;
        long num5 = obj1;
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj2);
        IntPtr num7 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj3);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, long, long, IntPtr, IntPtr)>) SteamRemoteStorage.__\u003Cjniptr\u003EgetUGCDownloadProgress\u0028JJ\u005BI\u005BI\u0029Z)(num2, num3, num4, num5, num6, num7);
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
    private static int ugcRead(
      [In] long obj0,
      [In] long obj1,
      [In] ByteBuffer obj2,
      [In] int obj3,
      [In] int obj4,
      [In] int obj5,
      [In] int obj6)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamRemoteStorage.__\u003Cjniptr\u003EugcRead\u0028JJLjava\u002Fnio\u002FByteBuffer\u003BIIII\u0029I == IntPtr.Zero)
        SteamRemoteStorage.__\u003Cjniptr\u003EugcRead\u0028JJLjava\u002Fnio\u002FByteBuffer\u003BIIII\u0029I = JNI.Frame.GetFuncPtr(SteamRemoteStorage.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamRemoteStorage", nameof (ugcRead), "(JJLjava/nio/ByteBuffer;IIII)I");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamRemoteStorage.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamRemoteStorage>.Value);
        long num4 = obj0;
        long num5 = obj1;
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj2);
        int num7 = obj3;
        int num8 = obj4;
        int num9 = obj5;
        int num10 = obj6;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<int (IntPtr, IntPtr, long, long, IntPtr, int, int, int, int)>) SteamRemoteStorage.__\u003Cjniptr\u003EugcRead\u0028JJLjava\u002Fnio\u002FByteBuffer\u003BIIII\u0029I)((int) num2, (int) num3, (int) num4, (int) num5, num6, (long) num7, (long) num8, (IntPtr) num9, (IntPtr) num10);
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
    private static int getCachedUGCCount([In] long obj0)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamRemoteStorage.__\u003Cjniptr\u003EgetCachedUGCCount\u0028J\u0029I == IntPtr.Zero)
        SteamRemoteStorage.__\u003Cjniptr\u003EgetCachedUGCCount\u0028J\u0029I = JNI.Frame.GetFuncPtr(SteamRemoteStorage.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamRemoteStorage", nameof (getCachedUGCCount), "(J)I");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamRemoteStorage.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamRemoteStorage>.Value);
        long num4 = obj0;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<int (IntPtr, IntPtr, long)>) SteamRemoteStorage.__\u003Cjniptr\u003EgetCachedUGCCount\u0028J\u0029I)((long) num2, num3, (IntPtr) num4);
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
    private static long getCachedUGCHandle([In] long obj0, [In] int obj1)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamRemoteStorage.__\u003Cjniptr\u003EgetCachedUGCHandle\u0028JI\u0029J == IntPtr.Zero)
        SteamRemoteStorage.__\u003Cjniptr\u003EgetCachedUGCHandle\u0028JI\u0029J = JNI.Frame.GetFuncPtr(SteamRemoteStorage.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamRemoteStorage", nameof (getCachedUGCHandle), "(JI)J");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamRemoteStorage.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamRemoteStorage>.Value);
        long num4 = obj0;
        int num5 = obj1;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<long (IntPtr, IntPtr, long, int)>) SteamRemoteStorage.__\u003Cjniptr\u003EgetCachedUGCHandle\u0028JI\u0029J)((int) num2, (long) num3, (IntPtr) num4, (IntPtr) num5);
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
    private static long publishWorkshopFile(
      [In] long obj0,
      [In] long obj1,
      [In] string obj2,
      [In] string obj3,
      [In] int obj4,
      [In] string obj5,
      [In] string obj6,
      [In] int obj7,
      [In] string[] obj8,
      [In] int obj9,
      [In] int obj10)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamRemoteStorage.__\u003Cjniptr\u003EpublishWorkshopFile\u0028JJLjava\u002Flang\u002FString\u003BLjava\u002Flang\u002FString\u003BILjava\u002Flang\u002FString\u003BLjava\u002Flang\u002FString\u003BI\u005BLjava\u002Flang\u002FString\u003BII\u0029J == IntPtr.Zero)
        SteamRemoteStorage.__\u003Cjniptr\u003EpublishWorkshopFile\u0028JJLjava\u002Flang\u002FString\u003BLjava\u002Flang\u002FString\u003BILjava\u002Flang\u002FString\u003BLjava\u002Flang\u002FString\u003BI\u005BLjava\u002Flang\u002FString\u003BII\u0029J = JNI.Frame.GetFuncPtr(SteamRemoteStorage.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamRemoteStorage", nameof (publishWorkshopFile), "(JJLjava/lang/String;Ljava/lang/String;ILjava/lang/String;Ljava/lang/String;I[Ljava/lang/String;II)J");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamRemoteStorage.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamRemoteStorage>.Value);
        long num4 = obj0;
        long num5 = obj1;
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj2);
        IntPtr num7 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj3);
        int num8 = obj4;
        IntPtr num9 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj5);
        IntPtr num10 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj6);
        int num11 = obj7;
        IntPtr num12 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj8);
        int num13 = obj9;
        int num14 = obj10;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<long (IntPtr, IntPtr, long, long, IntPtr, IntPtr, int, IntPtr, IntPtr, int, IntPtr, int, int)>) SteamRemoteStorage.__\u003Cjniptr\u003EpublishWorkshopFile\u0028JJLjava\u002Flang\u002FString\u003BLjava\u002Flang\u002FString\u003BILjava\u002Flang\u002FString\u003BLjava\u002Flang\u002FString\u003BI\u005BLjava\u002Flang\u002FString\u003BII\u0029J)((int) num2, (int) num3, (IntPtr) num4, (int) num5, num6, num7, num8, num9, num10, (long) num11, (long) num12, (IntPtr) num13, (IntPtr) num14);
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
    private static long createPublishedFileUpdateRequest([In] long obj0, [In] long obj1)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamRemoteStorage.__\u003Cjniptr\u003EcreatePublishedFileUpdateRequest\u0028JJ\u0029J == IntPtr.Zero)
        SteamRemoteStorage.__\u003Cjniptr\u003EcreatePublishedFileUpdateRequest\u0028JJ\u0029J = JNI.Frame.GetFuncPtr(SteamRemoteStorage.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamRemoteStorage", nameof (createPublishedFileUpdateRequest), "(JJ)J");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamRemoteStorage.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamRemoteStorage>.Value);
        long num4 = obj0;
        long num5 = obj1;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<long (IntPtr, IntPtr, long, long)>) SteamRemoteStorage.__\u003Cjniptr\u003EcreatePublishedFileUpdateRequest\u0028JJ\u0029J)((long) num2, (long) num3, (IntPtr) num4, (IntPtr) num5);
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
    private static bool updatePublishedFileFile([In] long obj0, [In] long obj1, [In] string obj2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamRemoteStorage.__\u003Cjniptr\u003EupdatePublishedFileFile\u0028JJLjava\u002Flang\u002FString\u003B\u0029Z == IntPtr.Zero)
        SteamRemoteStorage.__\u003Cjniptr\u003EupdatePublishedFileFile\u0028JJLjava\u002Flang\u002FString\u003B\u0029Z = JNI.Frame.GetFuncPtr(SteamRemoteStorage.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamRemoteStorage", nameof (updatePublishedFileFile), "(JJLjava/lang/String;)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamRemoteStorage.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamRemoteStorage>.Value);
        long num4 = obj0;
        long num5 = obj1;
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj2);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, long, long, IntPtr)>) SteamRemoteStorage.__\u003Cjniptr\u003EupdatePublishedFileFile\u0028JJLjava\u002Flang\u002FString\u003B\u0029Z)(num2, (long) num3, num4, (IntPtr) num5, num6);
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
    private static bool updatePublishedFilePreviewFile([In] long obj0, [In] long obj1, [In] string obj2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamRemoteStorage.__\u003Cjniptr\u003EupdatePublishedFilePreviewFile\u0028JJLjava\u002Flang\u002FString\u003B\u0029Z == IntPtr.Zero)
        SteamRemoteStorage.__\u003Cjniptr\u003EupdatePublishedFilePreviewFile\u0028JJLjava\u002Flang\u002FString\u003B\u0029Z = JNI.Frame.GetFuncPtr(SteamRemoteStorage.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamRemoteStorage", nameof (updatePublishedFilePreviewFile), "(JJLjava/lang/String;)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamRemoteStorage.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamRemoteStorage>.Value);
        long num4 = obj0;
        long num5 = obj1;
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj2);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, long, long, IntPtr)>) SteamRemoteStorage.__\u003Cjniptr\u003EupdatePublishedFilePreviewFile\u0028JJLjava\u002Flang\u002FString\u003B\u0029Z)(num2, (long) num3, num4, (IntPtr) num5, num6);
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
    private static bool updatePublishedFileTitle([In] long obj0, [In] long obj1, [In] string obj2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamRemoteStorage.__\u003Cjniptr\u003EupdatePublishedFileTitle\u0028JJLjava\u002Flang\u002FString\u003B\u0029Z == IntPtr.Zero)
        SteamRemoteStorage.__\u003Cjniptr\u003EupdatePublishedFileTitle\u0028JJLjava\u002Flang\u002FString\u003B\u0029Z = JNI.Frame.GetFuncPtr(SteamRemoteStorage.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamRemoteStorage", nameof (updatePublishedFileTitle), "(JJLjava/lang/String;)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamRemoteStorage.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamRemoteStorage>.Value);
        long num4 = obj0;
        long num5 = obj1;
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj2);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, long, long, IntPtr)>) SteamRemoteStorage.__\u003Cjniptr\u003EupdatePublishedFileTitle\u0028JJLjava\u002Flang\u002FString\u003B\u0029Z)(num2, (long) num3, num4, (IntPtr) num5, num6);
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
    private static bool updatePublishedFileDescription([In] long obj0, [In] long obj1, [In] string obj2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamRemoteStorage.__\u003Cjniptr\u003EupdatePublishedFileDescription\u0028JJLjava\u002Flang\u002FString\u003B\u0029Z == IntPtr.Zero)
        SteamRemoteStorage.__\u003Cjniptr\u003EupdatePublishedFileDescription\u0028JJLjava\u002Flang\u002FString\u003B\u0029Z = JNI.Frame.GetFuncPtr(SteamRemoteStorage.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamRemoteStorage", nameof (updatePublishedFileDescription), "(JJLjava/lang/String;)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamRemoteStorage.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamRemoteStorage>.Value);
        long num4 = obj0;
        long num5 = obj1;
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj2);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, long, long, IntPtr)>) SteamRemoteStorage.__\u003Cjniptr\u003EupdatePublishedFileDescription\u0028JJLjava\u002Flang\u002FString\u003B\u0029Z)(num2, (long) num3, num4, (IntPtr) num5, num6);
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
    private static bool updatePublishedFileVisibility([In] long obj0, [In] long obj1, [In] int obj2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamRemoteStorage.__\u003Cjniptr\u003EupdatePublishedFileVisibility\u0028JJI\u0029Z == IntPtr.Zero)
        SteamRemoteStorage.__\u003Cjniptr\u003EupdatePublishedFileVisibility\u0028JJI\u0029Z = JNI.Frame.GetFuncPtr(SteamRemoteStorage.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamRemoteStorage", nameof (updatePublishedFileVisibility), "(JJI)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamRemoteStorage.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamRemoteStorage>.Value);
        long num4 = obj0;
        long num5 = obj1;
        int num6 = obj2;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, long, long, int)>) SteamRemoteStorage.__\u003Cjniptr\u003EupdatePublishedFileVisibility\u0028JJI\u0029Z)((int) num2, (long) num3, num4, (IntPtr) num5, (IntPtr) num6);
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
    private static bool updatePublishedFileTags([In] long obj0, [In] long obj1, [In] string[] obj2, [In] int obj3)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamRemoteStorage.__\u003Cjniptr\u003EupdatePublishedFileTags\u0028JJ\u005BLjava\u002Flang\u002FString\u003BI\u0029Z == IntPtr.Zero)
        SteamRemoteStorage.__\u003Cjniptr\u003EupdatePublishedFileTags\u0028JJ\u005BLjava\u002Flang\u002FString\u003BI\u0029Z = JNI.Frame.GetFuncPtr(SteamRemoteStorage.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamRemoteStorage", nameof (updatePublishedFileTags), "(JJ[Ljava/lang/String;I)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamRemoteStorage.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamRemoteStorage>.Value);
        long num4 = obj0;
        long num5 = obj1;
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj2);
        int num7 = obj3;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, long, long, IntPtr, int)>) SteamRemoteStorage.__\u003Cjniptr\u003EupdatePublishedFileTags\u0028JJ\u005BLjava\u002Flang\u002FString\u003BI\u0029Z)((int) num2, num3, num4, num5, num6, (IntPtr) num7);
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
    private static long commitPublishedFileUpdate([In] long obj0, [In] long obj1, [In] long obj2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamRemoteStorage.__\u003Cjniptr\u003EcommitPublishedFileUpdate\u0028JJJ\u0029J == IntPtr.Zero)
        SteamRemoteStorage.__\u003Cjniptr\u003EcommitPublishedFileUpdate\u0028JJJ\u0029J = JNI.Frame.GetFuncPtr(SteamRemoteStorage.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamRemoteStorage", nameof (commitPublishedFileUpdate), "(JJJ)J");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamRemoteStorage.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamRemoteStorage>.Value);
        long num4 = obj0;
        long num5 = obj1;
        long num6 = obj2;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<long (IntPtr, IntPtr, long, long, long)>) SteamRemoteStorage.__\u003Cjniptr\u003EcommitPublishedFileUpdate\u0028JJJ\u0029J)((long) num2, (long) num3, num4, (IntPtr) num5, (IntPtr) num6);
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

    [LineNumberTable(new byte[] {27, 118})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public SteamRemoteStorage(SteamRemoteStorageCallback callback)
      : base(SteamAPI.getSteamRemoteStoragePointer(), SteamRemoteStorage.createCallback(new SteamRemoteStorageCallbackAdapter(callback)))
    {
    }

    [Throws(new string[] {"com.codedisaster.steamworks.SteamException"})]
    [LineNumberTable(new byte[] {31, 104, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool fileWrite(string file, ByteBuffer data)
    {
      if (!data.isDirect())
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new SteamException("Direct buffer required!");
      }
      return SteamRemoteStorage.fileWrite(this.pointer, file, data, ((Buffer) data).position(), ((Buffer) data).remaining());
    }

    [Throws(new string[] {"com.codedisaster.steamworks.SteamException"})]
    [LineNumberTable(new byte[] {38, 104, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool fileRead(string file, ByteBuffer buffer)
    {
      if (!buffer.isDirect())
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new SteamException("Direct buffer required!");
      }
      return SteamRemoteStorage.fileRead(this.pointer, file, buffer, ((Buffer) buffer).position(), ((Buffer) buffer).remaining());
    }

    [Throws(new string[] {"com.codedisaster.steamworks.SteamException"})]
    [LineNumberTable(new byte[] {45, 104, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual SteamAPICall fileWriteAsync(string file, ByteBuffer data)
    {
      if (!data.isDirect())
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new SteamException("Direct buffer required!");
      }
      return new SteamAPICall(SteamRemoteStorage.fileWriteAsync(this.pointer, this.callback, file, data, ((Buffer) data).position(), ((Buffer) data).remaining()));
    }

    [LineNumberTable(102)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual SteamAPICall fileReadAsync(string file, int offset, int toRead) => new SteamAPICall(SteamRemoteStorage.fileReadAsync(this.pointer, this.callback, file, offset, toRead));

    [LineNumberTable(106)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool fileReadAsyncComplete(SteamAPICall readCall, ByteBuffer buffer, int toRead) => SteamRemoteStorage.fileReadAsyncComplete(this.pointer, readCall.handle, buffer, (long) ((Buffer) buffer).position(), toRead);

    [LineNumberTable(110)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool fileForget(string file) => SteamRemoteStorage.fileForget(this.pointer, file);

    [LineNumberTable(114)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool fileDelete(string file) => SteamRemoteStorage.fileDelete(this.pointer, file);

    [LineNumberTable(118)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual SteamAPICall fileShare(string file) => new SteamAPICall(SteamRemoteStorage.fileShare(this.pointer, this.callback, file));

    [LineNumberTable(122)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool setSyncPlatforms(
      string file,
      SteamRemoteStorage.RemoteStoragePlatform remoteStoragePlatform)
    {
      return SteamRemoteStorage.setSyncPlatforms(this.pointer, file, SteamRemoteStorage.RemoteStoragePlatform.access\u0024000(remoteStoragePlatform));
    }

    [LineNumberTable(126)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual SteamUGCFileWriteStreamHandle fileWriteStreamOpen(
      string name)
    {
      return new SteamUGCFileWriteStreamHandle(SteamRemoteStorage.fileWriteStreamOpen(this.pointer, name));
    }

    [LineNumberTable(130)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool fileWriteStreamWriteChunk(
      SteamUGCFileWriteStreamHandle stream,
      ByteBuffer data)
    {
      return SteamRemoteStorage.fileWriteStreamWriteChunk(this.pointer, stream.handle, data, ((Buffer) data).position(), ((Buffer) data).remaining());
    }

    [LineNumberTable(134)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool fileWriteStreamClose(SteamUGCFileWriteStreamHandle stream) => SteamRemoteStorage.fileWriteStreamClose(this.pointer, stream.handle);

    [LineNumberTable(138)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool fileWriteStreamCancel(SteamUGCFileWriteStreamHandle stream) => SteamRemoteStorage.fileWriteStreamCancel(this.pointer, stream.handle);

    [LineNumberTable(142)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool fileExists(string file) => SteamRemoteStorage.fileExists(this.pointer, file);

    [LineNumberTable(146)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool filePersisted(string file) => SteamRemoteStorage.filePersisted(this.pointer, file);

    [LineNumberTable(150)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getFileSize(string file) => SteamRemoteStorage.getFileSize(this.pointer, file);

    [LineNumberTable(154)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual long getFileTimestamp(string file) => SteamRemoteStorage.getFileTimestamp(this.pointer, file);

    [LineNumberTable(new byte[] {108, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual SteamRemoteStorage.RemoteStoragePlatform[] getSyncPlatforms(
      string file)
    {
      return SteamRemoteStorage.RemoteStoragePlatform.byMask(SteamRemoteStorage.getSyncPlatforms(this.pointer, file));
    }

    [LineNumberTable(163)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getFileCount() => SteamRemoteStorage.getFileCount(this.pointer);

    [LineNumberTable(167)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string getFileNameAndSize(int index, int[] sizes) => SteamRemoteStorage.getFileNameAndSize(this.pointer, index, sizes);

    [LineNumberTable(171)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool getQuota(long[] totalBytes, long[] availableBytes) => SteamRemoteStorage.getQuota(this.pointer, totalBytes, availableBytes);

    [LineNumberTable(175)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isCloudEnabledForAccount() => SteamRemoteStorage.isCloudEnabledForAccount(this.pointer);

    [LineNumberTable(179)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isCloudEnabledForApp() => SteamRemoteStorage.isCloudEnabledForApp(this.pointer);

    [LineNumberTable(new byte[] {159, 97, 162, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setCloudEnabledForApp(bool enabled) => SteamRemoteStorage.setCloudEnabledForApp(this.pointer, enabled);

    [LineNumberTable(187)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual SteamAPICall ugcDownload(SteamUGCHandle fileHandle, int priority) => new SteamAPICall(SteamRemoteStorage.ugcDownload(this.pointer, this.callback, fileHandle.handle, priority));

    [LineNumberTable(191)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool getUGCDownloadProgress(
      SteamUGCHandle fileHandle,
      int[] bytesDownloaded,
      int[] bytesExpected)
    {
      return SteamRemoteStorage.getUGCDownloadProgress(this.pointer, fileHandle.handle, bytesDownloaded, bytesExpected);
    }

    [LineNumberTable(195)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int ugcRead(
      SteamUGCHandle fileHandle,
      ByteBuffer buffer,
      int dataToRead,
      int offset,
      SteamRemoteStorage.UGCReadAction action)
    {
      return SteamRemoteStorage.ugcRead(this.pointer, fileHandle.handle, buffer, ((Buffer) buffer).position(), dataToRead, offset, action.ordinal());
    }

    [LineNumberTable(199)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getCachedUGCCount() => SteamRemoteStorage.getCachedUGCCount(this.pointer);

    [LineNumberTable(203)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual SteamUGCHandle getCachedUGCHandle(int cachedContent) => new SteamUGCHandle(SteamRemoteStorage.getCachedUGCHandle(this.pointer, cachedContent));

    [LineNumberTable(new byte[] {160, 97, 117, 56})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual SteamAPICall publishWorkshopFile(
      string file,
      string previewFile,
      int consumerAppID,
      string title,
      string description,
      SteamRemoteStorage.PublishedFileVisibility visibility,
      string[] tags,
      SteamRemoteStorage.WorkshopFileType workshopFileType)
    {
      return new SteamAPICall(SteamRemoteStorage.publishWorkshopFile(this.pointer, this.callback, file, previewFile, consumerAppID, title, description, visibility.ordinal(), tags, tags == null ? 0 : tags.Length, workshopFileType.ordinal()));
    }

    [LineNumberTable(216)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual SteamPublishedFileUpdateHandle createPublishedFileUpdateRequest(
      SteamPublishedFileID publishedFileID)
    {
      return new SteamPublishedFileUpdateHandle(SteamRemoteStorage.createPublishedFileUpdateRequest(this.pointer, publishedFileID.handle));
    }

    [LineNumberTable(220)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool updatePublishedFileFile(
      SteamPublishedFileUpdateHandle updateHandle,
      string file)
    {
      return SteamRemoteStorage.updatePublishedFileFile(this.pointer, updateHandle.handle, file);
    }

    [LineNumberTable(224)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool updatePublishedFilePreviewFile(
      SteamPublishedFileUpdateHandle updateHandle,
      string previewFile)
    {
      return SteamRemoteStorage.updatePublishedFilePreviewFile(this.pointer, updateHandle.handle, previewFile);
    }

    [LineNumberTable(228)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool updatePublishedFileTitle(
      SteamPublishedFileUpdateHandle updateHandle,
      string title)
    {
      return SteamRemoteStorage.updatePublishedFileTitle(this.pointer, updateHandle.handle, title);
    }

    [LineNumberTable(232)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool updatePublishedFileDescription(
      SteamPublishedFileUpdateHandle updateHandle,
      string description)
    {
      return SteamRemoteStorage.updatePublishedFileDescription(this.pointer, updateHandle.handle, description);
    }

    [LineNumberTable(238)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool updatePublishedFileVisibility(
      SteamPublishedFileUpdateHandle updateHandle,
      SteamRemoteStorage.PublishedFileVisibility visibility)
    {
      return SteamRemoteStorage.updatePublishedFileVisibility(this.pointer, updateHandle.handle, visibility.ordinal());
    }

    [LineNumberTable(242)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool updatePublishedFileTags(
      SteamPublishedFileUpdateHandle updateHandle,
      string[] tags)
    {
      return SteamRemoteStorage.updatePublishedFileTags(this.pointer, updateHandle.handle, tags, tags == null ? 0 : tags.Length);
    }

    [LineNumberTable(246)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual SteamAPICall commitPublishedFileUpdate(
      SteamPublishedFileUpdateHandle updateHandle)
    {
      return new SteamAPICall(SteamRemoteStorage.commitPublishedFileUpdate(this.pointer, this.callback, updateHandle.handle));
    }

    [Modifiers]
    [LineNumberTable(5)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void dispose() => base.dispose();

    new static CallerID __\u003CGetCallerID\u003E()
    {
      if (SteamRemoteStorage.__\u003CcallerID\u003E == null)
        SteamRemoteStorage.__\u003CcallerID\u003E = (CallerID) new SteamRemoteStorage.__\u003CCallerID\u003E();
      return SteamRemoteStorage.__\u003CcallerID\u003E;
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

    [InnerClass]
    [Signature("Ljava/lang/Enum<Lcom/codedisaster/steamworks/SteamRemoteStorage$PublishedFileVisibility;>;")]
    [Modifiers]
    [Serializable]
    public sealed class PublishedFileVisibility : Enum
    {
      [Modifiers]
      internal static SteamRemoteStorage.PublishedFileVisibility __\u003C\u003EPublic;
      [Modifiers]
      internal static SteamRemoteStorage.PublishedFileVisibility __\u003C\u003EFriendsOnly;
      [Modifiers]
      internal static SteamRemoteStorage.PublishedFileVisibility __\u003C\u003EPrivate;
      [Modifiers]
      private static SteamRemoteStorage.PublishedFileVisibility[] \u0024VALUES;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [Signature("()V")]
      [LineNumberTable(45)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private PublishedFileVisibility([In] string obj0, [In] int obj1)
        : base(obj0, obj1)
      {
        GC.KeepAlive((object) this);
      }

      [LineNumberTable(45)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static SteamRemoteStorage.PublishedFileVisibility[] values() => (SteamRemoteStorage.PublishedFileVisibility[]) SteamRemoteStorage.PublishedFileVisibility.\u0024VALUES.Clone();

      [LineNumberTable(45)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static SteamRemoteStorage.PublishedFileVisibility valueOf(string name) => (SteamRemoteStorage.PublishedFileVisibility) Enum.valueOf((Class) ClassLiteral<SteamRemoteStorage.PublishedFileVisibility>.Value, name);

      [LineNumberTable(new byte[] {159, 131, 141, 112, 112, 240, 61})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static PublishedFileVisibility()
      {
        if (ByteCodeHelper.isAlreadyInited("com.codedisaster.steamworks.SteamRemoteStorage$PublishedFileVisibility"))
          return;
        SteamRemoteStorage.PublishedFileVisibility.__\u003C\u003EPublic = new SteamRemoteStorage.PublishedFileVisibility(nameof (Public), 0);
        SteamRemoteStorage.PublishedFileVisibility.__\u003C\u003EFriendsOnly = new SteamRemoteStorage.PublishedFileVisibility(nameof (FriendsOnly), 1);
        SteamRemoteStorage.PublishedFileVisibility.__\u003C\u003EPrivate = new SteamRemoteStorage.PublishedFileVisibility(nameof (Private), 2);
        SteamRemoteStorage.PublishedFileVisibility.\u0024VALUES = new SteamRemoteStorage.PublishedFileVisibility[3]
        {
          SteamRemoteStorage.PublishedFileVisibility.__\u003C\u003EPublic,
          SteamRemoteStorage.PublishedFileVisibility.__\u003C\u003EFriendsOnly,
          SteamRemoteStorage.PublishedFileVisibility.__\u003C\u003EPrivate
        };
      }

      [Modifiers]
      public static SteamRemoteStorage.PublishedFileVisibility Public
      {
        [HideFromJava] get => SteamRemoteStorage.PublishedFileVisibility.__\u003C\u003EPublic;
      }

      [Modifiers]
      public static SteamRemoteStorage.PublishedFileVisibility FriendsOnly
      {
        [HideFromJava] get => SteamRemoteStorage.PublishedFileVisibility.__\u003C\u003EFriendsOnly;
      }

      [Modifiers]
      public static SteamRemoteStorage.PublishedFileVisibility Private
      {
        [HideFromJava] get => SteamRemoteStorage.PublishedFileVisibility.__\u003C\u003EPrivate;
      }

      [HideFromJava]
      [Serializable]
      public enum __Enum
      {
        Public,
        FriendsOnly,
        Private,
      }
    }

    [InnerClass]
    [Signature("Ljava/lang/Enum<Lcom/codedisaster/steamworks/SteamRemoteStorage$RemoteStoragePlatform;>;")]
    [Modifiers]
    [Serializable]
    public sealed class RemoteStoragePlatform : Enum
    {
      [Modifiers]
      internal static SteamRemoteStorage.RemoteStoragePlatform __\u003C\u003ENone;
      [Modifiers]
      internal static SteamRemoteStorage.RemoteStoragePlatform __\u003C\u003EWindows;
      [Modifiers]
      internal static SteamRemoteStorage.RemoteStoragePlatform __\u003C\u003EOSX;
      [Modifiers]
      internal static SteamRemoteStorage.RemoteStoragePlatform __\u003C\u003EPS3;
      [Modifiers]
      internal static SteamRemoteStorage.RemoteStoragePlatform __\u003C\u003ELinux;
      [Modifiers]
      internal static SteamRemoteStorage.RemoteStoragePlatform __\u003C\u003EReserved2;
      [Modifiers]
      internal static SteamRemoteStorage.RemoteStoragePlatform __\u003C\u003EAll;
      [Modifiers]
      private int mask;
      [Modifiers]
      private static SteamRemoteStorage.RemoteStoragePlatform[] values;
      [Modifiers]
      private static SteamRemoteStorage.RemoteStoragePlatform[] \u0024VALUES;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [Modifiers]
      [LineNumberTable(7)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal static int access\u0024000([In] SteamRemoteStorage.RemoteStoragePlatform obj0) => obj0.mask;

      [LineNumberTable(new byte[] {159, 167, 103, 135, 98, 121, 107, 9, 232, 70})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal static SteamRemoteStorage.RemoteStoragePlatform[] byMask([In] int obj0)
      {
        SteamRemoteStorage.RemoteStoragePlatform[] remoteStoragePlatformArray1 = new SteamRemoteStorage.RemoteStoragePlatform[Integer.bitCount(obj0)];
        int num = 0;
        SteamRemoteStorage.RemoteStoragePlatform[] values = SteamRemoteStorage.RemoteStoragePlatform.values;
        int length = values.Length;
        for (int index1 = 0; index1 < length; ++index1)
        {
          SteamRemoteStorage.RemoteStoragePlatform remoteStoragePlatform1 = values[index1];
          if ((remoteStoragePlatform1.mask & obj0) != 0)
          {
            SteamRemoteStorage.RemoteStoragePlatform[] remoteStoragePlatformArray2 = remoteStoragePlatformArray1;
            int index2 = num;
            ++num;
            SteamRemoteStorage.RemoteStoragePlatform remoteStoragePlatform2 = remoteStoragePlatform1;
            remoteStoragePlatformArray2[index2] = remoteStoragePlatform2;
          }
        }
        return remoteStoragePlatformArray1;
      }

      [Signature("(I)V")]
      [LineNumberTable(new byte[] {159, 162, 106, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private RemoteStoragePlatform([In] string obj0, [In] int obj1, [In] int obj2)
        : base(obj0, obj1)
      {
        SteamRemoteStorage.RemoteStoragePlatform remoteStoragePlatform = this;
        this.mask = obj2;
        GC.KeepAlive((object) this);
      }

      [LineNumberTable(7)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static SteamRemoteStorage.RemoteStoragePlatform[] values() => (SteamRemoteStorage.RemoteStoragePlatform[]) SteamRemoteStorage.RemoteStoragePlatform.\u0024VALUES.Clone();

      [LineNumberTable(7)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static SteamRemoteStorage.RemoteStoragePlatform valueOf(string name) => (SteamRemoteStorage.RemoteStoragePlatform) Enum.valueOf((Class) ClassLiteral<SteamRemoteStorage.RemoteStoragePlatform>.Value, name);

      [LineNumberTable(new byte[] {159, 140, 77, 113, 113, 113, 113, 113, 146, 241, 56, 255, 36, 75})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static RemoteStoragePlatform()
      {
        if (ByteCodeHelper.isAlreadyInited("com.codedisaster.steamworks.SteamRemoteStorage$RemoteStoragePlatform"))
          return;
        SteamRemoteStorage.RemoteStoragePlatform.__\u003C\u003ENone = new SteamRemoteStorage.RemoteStoragePlatform(nameof (None), 0, 0);
        SteamRemoteStorage.RemoteStoragePlatform.__\u003C\u003EWindows = new SteamRemoteStorage.RemoteStoragePlatform(nameof (Windows), 1, 1);
        SteamRemoteStorage.RemoteStoragePlatform.__\u003C\u003EOSX = new SteamRemoteStorage.RemoteStoragePlatform(nameof (OSX), 2, 2);
        SteamRemoteStorage.RemoteStoragePlatform.__\u003C\u003EPS3 = new SteamRemoteStorage.RemoteStoragePlatform(nameof (PS3), 3, 4);
        SteamRemoteStorage.RemoteStoragePlatform.__\u003C\u003ELinux = new SteamRemoteStorage.RemoteStoragePlatform(nameof (Linux), 4, 8);
        SteamRemoteStorage.RemoteStoragePlatform.__\u003C\u003EReserved2 = new SteamRemoteStorage.RemoteStoragePlatform(nameof (Reserved2), 5, 16);
        SteamRemoteStorage.RemoteStoragePlatform.__\u003C\u003EAll = new SteamRemoteStorage.RemoteStoragePlatform(nameof (All), 6, -1);
        SteamRemoteStorage.RemoteStoragePlatform.\u0024VALUES = new SteamRemoteStorage.RemoteStoragePlatform[7]
        {
          SteamRemoteStorage.RemoteStoragePlatform.__\u003C\u003ENone,
          SteamRemoteStorage.RemoteStoragePlatform.__\u003C\u003EWindows,
          SteamRemoteStorage.RemoteStoragePlatform.__\u003C\u003EOSX,
          SteamRemoteStorage.RemoteStoragePlatform.__\u003C\u003EPS3,
          SteamRemoteStorage.RemoteStoragePlatform.__\u003C\u003ELinux,
          SteamRemoteStorage.RemoteStoragePlatform.__\u003C\u003EReserved2,
          SteamRemoteStorage.RemoteStoragePlatform.__\u003C\u003EAll
        };
        SteamRemoteStorage.RemoteStoragePlatform.values = SteamRemoteStorage.RemoteStoragePlatform.values();
      }

      [Modifiers]
      public static SteamRemoteStorage.RemoteStoragePlatform None
      {
        [HideFromJava] get => SteamRemoteStorage.RemoteStoragePlatform.__\u003C\u003ENone;
      }

      [Modifiers]
      public static SteamRemoteStorage.RemoteStoragePlatform Windows
      {
        [HideFromJava] get => SteamRemoteStorage.RemoteStoragePlatform.__\u003C\u003EWindows;
      }

      [Modifiers]
      public static SteamRemoteStorage.RemoteStoragePlatform OSX
      {
        [HideFromJava] get => SteamRemoteStorage.RemoteStoragePlatform.__\u003C\u003EOSX;
      }

      [Modifiers]
      public static SteamRemoteStorage.RemoteStoragePlatform PS3
      {
        [HideFromJava] get => SteamRemoteStorage.RemoteStoragePlatform.__\u003C\u003EPS3;
      }

      [Modifiers]
      public static SteamRemoteStorage.RemoteStoragePlatform Linux
      {
        [HideFromJava] get => SteamRemoteStorage.RemoteStoragePlatform.__\u003C\u003ELinux;
      }

      [Modifiers]
      public static SteamRemoteStorage.RemoteStoragePlatform Reserved2
      {
        [HideFromJava] get => SteamRemoteStorage.RemoteStoragePlatform.__\u003C\u003EReserved2;
      }

      [Modifiers]
      public static SteamRemoteStorage.RemoteStoragePlatform All
      {
        [HideFromJava] get => SteamRemoteStorage.RemoteStoragePlatform.__\u003C\u003EAll;
      }

      [HideFromJava]
      [Serializable]
      public enum __Enum
      {
        None,
        Windows,
        OSX,
        PS3,
        Linux,
        Reserved2,
        All,
      }
    }

    [InnerClass]
    [Signature("Ljava/lang/Enum<Lcom/codedisaster/steamworks/SteamRemoteStorage$UGCReadAction;>;")]
    [Modifiers]
    [Serializable]
    public sealed class UGCReadAction : Enum
    {
      [Modifiers]
      internal static SteamRemoteStorage.UGCReadAction __\u003C\u003EContinueReadingUntilFinished;
      [Modifiers]
      internal static SteamRemoteStorage.UGCReadAction __\u003C\u003EContinueReading;
      [Modifiers]
      internal static SteamRemoteStorage.UGCReadAction __\u003C\u003EClose;
      [Modifiers]
      private static SteamRemoteStorage.UGCReadAction[] \u0024VALUES;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [Signature("()V")]
      [LineNumberTable(39)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private UGCReadAction([In] string obj0, [In] int obj1)
        : base(obj0, obj1)
      {
        GC.KeepAlive((object) this);
      }

      [LineNumberTable(39)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static SteamRemoteStorage.UGCReadAction[] values() => (SteamRemoteStorage.UGCReadAction[]) SteamRemoteStorage.UGCReadAction.\u0024VALUES.Clone();

      [LineNumberTable(39)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static SteamRemoteStorage.UGCReadAction valueOf(string name) => (SteamRemoteStorage.UGCReadAction) Enum.valueOf((Class) ClassLiteral<SteamRemoteStorage.UGCReadAction>.Value, name);

      [LineNumberTable(new byte[] {159, 132, 77, 112, 112, 240, 61})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static UGCReadAction()
      {
        if (ByteCodeHelper.isAlreadyInited("com.codedisaster.steamworks.SteamRemoteStorage$UGCReadAction"))
          return;
        SteamRemoteStorage.UGCReadAction.__\u003C\u003EContinueReadingUntilFinished = new SteamRemoteStorage.UGCReadAction(nameof (ContinueReadingUntilFinished), 0);
        SteamRemoteStorage.UGCReadAction.__\u003C\u003EContinueReading = new SteamRemoteStorage.UGCReadAction(nameof (ContinueReading), 1);
        SteamRemoteStorage.UGCReadAction.__\u003C\u003EClose = new SteamRemoteStorage.UGCReadAction(nameof (Close), 2);
        SteamRemoteStorage.UGCReadAction.\u0024VALUES = new SteamRemoteStorage.UGCReadAction[3]
        {
          SteamRemoteStorage.UGCReadAction.__\u003C\u003EContinueReadingUntilFinished,
          SteamRemoteStorage.UGCReadAction.__\u003C\u003EContinueReading,
          SteamRemoteStorage.UGCReadAction.__\u003C\u003EClose
        };
      }

      [Modifiers]
      public static SteamRemoteStorage.UGCReadAction ContinueReadingUntilFinished
      {
        [HideFromJava] get => SteamRemoteStorage.UGCReadAction.__\u003C\u003EContinueReadingUntilFinished;
      }

      [Modifiers]
      public static SteamRemoteStorage.UGCReadAction ContinueReading
      {
        [HideFromJava] get => SteamRemoteStorage.UGCReadAction.__\u003C\u003EContinueReading;
      }

      [Modifiers]
      public static SteamRemoteStorage.UGCReadAction Close
      {
        [HideFromJava] get => SteamRemoteStorage.UGCReadAction.__\u003C\u003EClose;
      }

      [HideFromJava]
      [Serializable]
      public enum __Enum
      {
        ContinueReadingUntilFinished,
        ContinueReading,
        Close,
      }
    }

    [InnerClass]
    [Signature("Ljava/lang/Enum<Lcom/codedisaster/steamworks/SteamRemoteStorage$WorkshopFileType;>;")]
    [Modifiers]
    [Serializable]
    public sealed class WorkshopFileType : Enum
    {
      [Modifiers]
      internal static SteamRemoteStorage.WorkshopFileType __\u003C\u003ECommunity;
      [Modifiers]
      internal static SteamRemoteStorage.WorkshopFileType __\u003C\u003EMicrotransaction;
      [Modifiers]
      internal static SteamRemoteStorage.WorkshopFileType __\u003C\u003ECollection;
      [Modifiers]
      internal static SteamRemoteStorage.WorkshopFileType __\u003C\u003EArt;
      [Modifiers]
      internal static SteamRemoteStorage.WorkshopFileType __\u003C\u003EVideo;
      [Modifiers]
      internal static SteamRemoteStorage.WorkshopFileType __\u003C\u003EScreenshot;
      [Modifiers]
      internal static SteamRemoteStorage.WorkshopFileType __\u003C\u003EGame;
      [Modifiers]
      internal static SteamRemoteStorage.WorkshopFileType __\u003C\u003ESoftware;
      [Modifiers]
      internal static SteamRemoteStorage.WorkshopFileType __\u003C\u003EConcept;
      [Modifiers]
      internal static SteamRemoteStorage.WorkshopFileType __\u003C\u003EWebGuide;
      [Modifiers]
      internal static SteamRemoteStorage.WorkshopFileType __\u003C\u003EIntegratedGuide;
      [Modifiers]
      internal static SteamRemoteStorage.WorkshopFileType __\u003C\u003EMerch;
      [Modifiers]
      internal static SteamRemoteStorage.WorkshopFileType __\u003C\u003EControllerBinding;
      [Modifiers]
      internal static SteamRemoteStorage.WorkshopFileType __\u003C\u003ESteamworksAccessInvite;
      [Modifiers]
      internal static SteamRemoteStorage.WorkshopFileType __\u003C\u003ESteamVideo;
      [Modifiers]
      internal static SteamRemoteStorage.WorkshopFileType __\u003C\u003EGameManagedItem;
      [Modifiers]
      private static SteamRemoteStorage.WorkshopFileType[] values;
      [Modifiers]
      private static SteamRemoteStorage.WorkshopFileType[] \u0024VALUES;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [Signature("()V")]
      [LineNumberTable(51)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private WorkshopFileType([In] string obj0, [In] int obj1)
        : base(obj0, obj1)
      {
        GC.KeepAlive((object) this);
      }

      [LineNumberTable(51)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static SteamRemoteStorage.WorkshopFileType[] values() => (SteamRemoteStorage.WorkshopFileType[]) SteamRemoteStorage.WorkshopFileType.\u0024VALUES.Clone();

      [LineNumberTable(51)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static SteamRemoteStorage.WorkshopFileType valueOf(string name) => (SteamRemoteStorage.WorkshopFileType) Enum.valueOf((Class) ClassLiteral<SteamRemoteStorage.WorkshopFileType>.Value, name);

      [LineNumberTable(72)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal static SteamRemoteStorage.WorkshopFileType byOrdinal([In] int obj0) => SteamRemoteStorage.WorkshopFileType.values[obj0];

      [LineNumberTable(new byte[] {159, 129, 77, 112, 112, 112, 112, 112, 112, 112, 112, 112, 113, 113, 113, 113, 113, 113, 241, 48, 255, 116, 82})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static WorkshopFileType()
      {
        if (ByteCodeHelper.isAlreadyInited("com.codedisaster.steamworks.SteamRemoteStorage$WorkshopFileType"))
          return;
        SteamRemoteStorage.WorkshopFileType.__\u003C\u003ECommunity = new SteamRemoteStorage.WorkshopFileType(nameof (Community), 0);
        SteamRemoteStorage.WorkshopFileType.__\u003C\u003EMicrotransaction = new SteamRemoteStorage.WorkshopFileType(nameof (Microtransaction), 1);
        SteamRemoteStorage.WorkshopFileType.__\u003C\u003ECollection = new SteamRemoteStorage.WorkshopFileType(nameof (Collection), 2);
        SteamRemoteStorage.WorkshopFileType.__\u003C\u003EArt = new SteamRemoteStorage.WorkshopFileType(nameof (Art), 3);
        SteamRemoteStorage.WorkshopFileType.__\u003C\u003EVideo = new SteamRemoteStorage.WorkshopFileType(nameof (Video), 4);
        SteamRemoteStorage.WorkshopFileType.__\u003C\u003EScreenshot = new SteamRemoteStorage.WorkshopFileType(nameof (Screenshot), 5);
        SteamRemoteStorage.WorkshopFileType.__\u003C\u003EGame = new SteamRemoteStorage.WorkshopFileType(nameof (Game), 6);
        SteamRemoteStorage.WorkshopFileType.__\u003C\u003ESoftware = new SteamRemoteStorage.WorkshopFileType(nameof (Software), 7);
        SteamRemoteStorage.WorkshopFileType.__\u003C\u003EConcept = new SteamRemoteStorage.WorkshopFileType(nameof (Concept), 8);
        SteamRemoteStorage.WorkshopFileType.__\u003C\u003EWebGuide = new SteamRemoteStorage.WorkshopFileType(nameof (WebGuide), 9);
        SteamRemoteStorage.WorkshopFileType.__\u003C\u003EIntegratedGuide = new SteamRemoteStorage.WorkshopFileType(nameof (IntegratedGuide), 10);
        SteamRemoteStorage.WorkshopFileType.__\u003C\u003EMerch = new SteamRemoteStorage.WorkshopFileType(nameof (Merch), 11);
        SteamRemoteStorage.WorkshopFileType.__\u003C\u003EControllerBinding = new SteamRemoteStorage.WorkshopFileType(nameof (ControllerBinding), 12);
        SteamRemoteStorage.WorkshopFileType.__\u003C\u003ESteamworksAccessInvite = new SteamRemoteStorage.WorkshopFileType(nameof (SteamworksAccessInvite), 13);
        SteamRemoteStorage.WorkshopFileType.__\u003C\u003ESteamVideo = new SteamRemoteStorage.WorkshopFileType(nameof (SteamVideo), 14);
        SteamRemoteStorage.WorkshopFileType.__\u003C\u003EGameManagedItem = new SteamRemoteStorage.WorkshopFileType(nameof (GameManagedItem), 15);
        SteamRemoteStorage.WorkshopFileType.\u0024VALUES = new SteamRemoteStorage.WorkshopFileType[16]
        {
          SteamRemoteStorage.WorkshopFileType.__\u003C\u003ECommunity,
          SteamRemoteStorage.WorkshopFileType.__\u003C\u003EMicrotransaction,
          SteamRemoteStorage.WorkshopFileType.__\u003C\u003ECollection,
          SteamRemoteStorage.WorkshopFileType.__\u003C\u003EArt,
          SteamRemoteStorage.WorkshopFileType.__\u003C\u003EVideo,
          SteamRemoteStorage.WorkshopFileType.__\u003C\u003EScreenshot,
          SteamRemoteStorage.WorkshopFileType.__\u003C\u003EGame,
          SteamRemoteStorage.WorkshopFileType.__\u003C\u003ESoftware,
          SteamRemoteStorage.WorkshopFileType.__\u003C\u003EConcept,
          SteamRemoteStorage.WorkshopFileType.__\u003C\u003EWebGuide,
          SteamRemoteStorage.WorkshopFileType.__\u003C\u003EIntegratedGuide,
          SteamRemoteStorage.WorkshopFileType.__\u003C\u003EMerch,
          SteamRemoteStorage.WorkshopFileType.__\u003C\u003EControllerBinding,
          SteamRemoteStorage.WorkshopFileType.__\u003C\u003ESteamworksAccessInvite,
          SteamRemoteStorage.WorkshopFileType.__\u003C\u003ESteamVideo,
          SteamRemoteStorage.WorkshopFileType.__\u003C\u003EGameManagedItem
        };
        SteamRemoteStorage.WorkshopFileType.values = SteamRemoteStorage.WorkshopFileType.values();
      }

      [Modifiers]
      public static SteamRemoteStorage.WorkshopFileType Community
      {
        [HideFromJava] get => SteamRemoteStorage.WorkshopFileType.__\u003C\u003ECommunity;
      }

      [Modifiers]
      public static SteamRemoteStorage.WorkshopFileType Microtransaction
      {
        [HideFromJava] get => SteamRemoteStorage.WorkshopFileType.__\u003C\u003EMicrotransaction;
      }

      [Modifiers]
      public static SteamRemoteStorage.WorkshopFileType Collection
      {
        [HideFromJava] get => SteamRemoteStorage.WorkshopFileType.__\u003C\u003ECollection;
      }

      [Modifiers]
      public static SteamRemoteStorage.WorkshopFileType Art
      {
        [HideFromJava] get => SteamRemoteStorage.WorkshopFileType.__\u003C\u003EArt;
      }

      [Modifiers]
      public static SteamRemoteStorage.WorkshopFileType Video
      {
        [HideFromJava] get => SteamRemoteStorage.WorkshopFileType.__\u003C\u003EVideo;
      }

      [Modifiers]
      public static SteamRemoteStorage.WorkshopFileType Screenshot
      {
        [HideFromJava] get => SteamRemoteStorage.WorkshopFileType.__\u003C\u003EScreenshot;
      }

      [Modifiers]
      public static SteamRemoteStorage.WorkshopFileType Game
      {
        [HideFromJava] get => SteamRemoteStorage.WorkshopFileType.__\u003C\u003EGame;
      }

      [Modifiers]
      public static SteamRemoteStorage.WorkshopFileType Software
      {
        [HideFromJava] get => SteamRemoteStorage.WorkshopFileType.__\u003C\u003ESoftware;
      }

      [Modifiers]
      public static SteamRemoteStorage.WorkshopFileType Concept
      {
        [HideFromJava] get => SteamRemoteStorage.WorkshopFileType.__\u003C\u003EConcept;
      }

      [Modifiers]
      public static SteamRemoteStorage.WorkshopFileType WebGuide
      {
        [HideFromJava] get => SteamRemoteStorage.WorkshopFileType.__\u003C\u003EWebGuide;
      }

      [Modifiers]
      public static SteamRemoteStorage.WorkshopFileType IntegratedGuide
      {
        [HideFromJava] get => SteamRemoteStorage.WorkshopFileType.__\u003C\u003EIntegratedGuide;
      }

      [Modifiers]
      public static SteamRemoteStorage.WorkshopFileType Merch
      {
        [HideFromJava] get => SteamRemoteStorage.WorkshopFileType.__\u003C\u003EMerch;
      }

      [Modifiers]
      public static SteamRemoteStorage.WorkshopFileType ControllerBinding
      {
        [HideFromJava] get => SteamRemoteStorage.WorkshopFileType.__\u003C\u003EControllerBinding;
      }

      [Modifiers]
      public static SteamRemoteStorage.WorkshopFileType SteamworksAccessInvite
      {
        [HideFromJava] get => SteamRemoteStorage.WorkshopFileType.__\u003C\u003ESteamworksAccessInvite;
      }

      [Modifiers]
      public static SteamRemoteStorage.WorkshopFileType SteamVideo
      {
        [HideFromJava] get => SteamRemoteStorage.WorkshopFileType.__\u003C\u003ESteamVideo;
      }

      [Modifiers]
      public static SteamRemoteStorage.WorkshopFileType GameManagedItem
      {
        [HideFromJava] get => SteamRemoteStorage.WorkshopFileType.__\u003C\u003EGameManagedItem;
      }

      [HideFromJava]
      [Serializable]
      public enum __Enum
      {
        Community,
        Microtransaction,
        Collection,
        Art,
        Video,
        Screenshot,
        Game,
        Software,
        Concept,
        WebGuide,
        IntegratedGuide,
        Merch,
        ControllerBinding,
        SteamworksAccessInvite,
        SteamVideo,
        GameManagedItem,
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
