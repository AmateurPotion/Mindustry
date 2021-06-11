// Decompiled with JetBrains decompiler
// Type: com.codedisaster.steamworks.SteamMatchmakingServers
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace com.codedisaster.steamworks
{
  public class SteamMatchmakingServers : SteamInterface
  {
    static IntPtr __\u003Cjniptr\u003ErequestInternetServerList\u0028JI\u005BLcom\u002Fcodedisaster\u002Fsteamworks\u002FSteamMatchmakingKeyValuePair\u003BIJ\u0029J;
    [SpecialName]
    private static CallerID __\u003CcallerID\u003E;
    static IntPtr __\u003Cjniptr\u003ErequestLANServerList\u0028JIJ\u0029J;
    static IntPtr __\u003Cjniptr\u003ErequestFriendsServerList\u0028JI\u005BLcom\u002Fcodedisaster\u002Fsteamworks\u002FSteamMatchmakingKeyValuePair\u003BIJ\u0029J;
    static IntPtr __\u003Cjniptr\u003ErequestFavoritesServerList\u0028JI\u005BLcom\u002Fcodedisaster\u002Fsteamworks\u002FSteamMatchmakingKeyValuePair\u003BIJ\u0029J;
    static IntPtr __\u003Cjniptr\u003ErequestHistoryServerList\u0028JI\u005BLcom\u002Fcodedisaster\u002Fsteamworks\u002FSteamMatchmakingKeyValuePair\u003BIJ\u0029J;
    static IntPtr __\u003Cjniptr\u003ErequestSpectatorServerList\u0028JI\u005BLcom\u002Fcodedisaster\u002Fsteamworks\u002FSteamMatchmakingKeyValuePair\u003BIJ\u0029J;
    static IntPtr __\u003Cjniptr\u003EreleaseRequest\u0028JJ\u0029V;
    static IntPtr __\u003Cjniptr\u003EgetServerDetails\u0028JJILcom\u002Fcodedisaster\u002Fsteamworks\u002FSteamMatchmakingGameServerItem\u003B\u0029Z;
    static IntPtr __\u003Cjniptr\u003EcancelQuery\u0028JJ\u0029V;
    static IntPtr __\u003Cjniptr\u003ErefreshQuery\u0028JJ\u0029V;
    static IntPtr __\u003Cjniptr\u003EisRefreshing\u0028JJ\u0029Z;
    static IntPtr __\u003Cjniptr\u003EgetServerCount\u0028JJ\u0029I;
    static IntPtr __\u003Cjniptr\u003ErefreshServer\u0028JJI\u0029V;
    static IntPtr __\u003Cjniptr\u003EpingServer\u0028JISJ\u0029I;
    static IntPtr __\u003Cjniptr\u003EplayerDetails\u0028JISJ\u0029I;
    static IntPtr __\u003Cjniptr\u003EserverRules\u0028JISJ\u0029I;
    static IntPtr __\u003Cjniptr\u003EcancelServerQuery\u0028JI\u0029V;

    [Modifiers]
    private static long requestInternetServerList(
      [In] long obj0,
      [In] int obj1,
      [In] SteamMatchmakingKeyValuePair[] obj2,
      [In] int obj3,
      [In] long obj4)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamMatchmakingServers.__\u003Cjniptr\u003ErequestInternetServerList\u0028JI\u005BLcom\u002Fcodedisaster\u002Fsteamworks\u002FSteamMatchmakingKeyValuePair\u003BIJ\u0029J == IntPtr.Zero)
        SteamMatchmakingServers.__\u003Cjniptr\u003ErequestInternetServerList\u0028JI\u005BLcom\u002Fcodedisaster\u002Fsteamworks\u002FSteamMatchmakingKeyValuePair\u003BIJ\u0029J = JNI.Frame.GetFuncPtr(SteamMatchmakingServers.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamMatchmakingServers", nameof (requestInternetServerList), "(JI[Lcom/codedisaster/steamworks/SteamMatchmakingKeyValuePair;IJ)J");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamMatchmakingServers.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamMatchmakingServers>.Value);
        long num4 = obj0;
        int num5 = obj1;
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj2);
        int num7 = obj3;
        long num8 = obj4;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<long (IntPtr, IntPtr, long, int, IntPtr, int, long)>) SteamMatchmakingServers.__\u003Cjniptr\u003ErequestInternetServerList\u0028JI\u005BLcom\u002Fcodedisaster\u002Fsteamworks\u002FSteamMatchmakingKeyValuePair\u003BIJ\u0029J)((long) num2, (int) num3, (IntPtr) num4, num5, (long) num6, (IntPtr) num7, (IntPtr) num8);
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
    private static long requestLANServerList([In] long obj0, [In] int obj1, [In] long obj2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamMatchmakingServers.__\u003Cjniptr\u003ErequestLANServerList\u0028JIJ\u0029J == IntPtr.Zero)
        SteamMatchmakingServers.__\u003Cjniptr\u003ErequestLANServerList\u0028JIJ\u0029J = JNI.Frame.GetFuncPtr(SteamMatchmakingServers.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamMatchmakingServers", nameof (requestLANServerList), "(JIJ)J");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamMatchmakingServers.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamMatchmakingServers>.Value);
        long num4 = obj0;
        int num5 = obj1;
        long num6 = obj2;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<long (IntPtr, IntPtr, long, int, long)>) SteamMatchmakingServers.__\u003Cjniptr\u003ErequestLANServerList\u0028JIJ\u0029J)((long) num2, (int) num3, num4, (IntPtr) num5, (IntPtr) num6);
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
    private static long requestFriendsServerList(
      [In] long obj0,
      [In] int obj1,
      [In] SteamMatchmakingKeyValuePair[] obj2,
      [In] int obj3,
      [In] long obj4)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamMatchmakingServers.__\u003Cjniptr\u003ErequestFriendsServerList\u0028JI\u005BLcom\u002Fcodedisaster\u002Fsteamworks\u002FSteamMatchmakingKeyValuePair\u003BIJ\u0029J == IntPtr.Zero)
        SteamMatchmakingServers.__\u003Cjniptr\u003ErequestFriendsServerList\u0028JI\u005BLcom\u002Fcodedisaster\u002Fsteamworks\u002FSteamMatchmakingKeyValuePair\u003BIJ\u0029J = JNI.Frame.GetFuncPtr(SteamMatchmakingServers.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamMatchmakingServers", nameof (requestFriendsServerList), "(JI[Lcom/codedisaster/steamworks/SteamMatchmakingKeyValuePair;IJ)J");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamMatchmakingServers.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamMatchmakingServers>.Value);
        long num4 = obj0;
        int num5 = obj1;
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj2);
        int num7 = obj3;
        long num8 = obj4;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<long (IntPtr, IntPtr, long, int, IntPtr, int, long)>) SteamMatchmakingServers.__\u003Cjniptr\u003ErequestFriendsServerList\u0028JI\u005BLcom\u002Fcodedisaster\u002Fsteamworks\u002FSteamMatchmakingKeyValuePair\u003BIJ\u0029J)((long) num2, (int) num3, (IntPtr) num4, num5, (long) num6, (IntPtr) num7, (IntPtr) num8);
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
    private static long requestFavoritesServerList(
      [In] long obj0,
      [In] int obj1,
      [In] SteamMatchmakingKeyValuePair[] obj2,
      [In] int obj3,
      [In] long obj4)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamMatchmakingServers.__\u003Cjniptr\u003ErequestFavoritesServerList\u0028JI\u005BLcom\u002Fcodedisaster\u002Fsteamworks\u002FSteamMatchmakingKeyValuePair\u003BIJ\u0029J == IntPtr.Zero)
        SteamMatchmakingServers.__\u003Cjniptr\u003ErequestFavoritesServerList\u0028JI\u005BLcom\u002Fcodedisaster\u002Fsteamworks\u002FSteamMatchmakingKeyValuePair\u003BIJ\u0029J = JNI.Frame.GetFuncPtr(SteamMatchmakingServers.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamMatchmakingServers", nameof (requestFavoritesServerList), "(JI[Lcom/codedisaster/steamworks/SteamMatchmakingKeyValuePair;IJ)J");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamMatchmakingServers.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamMatchmakingServers>.Value);
        long num4 = obj0;
        int num5 = obj1;
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj2);
        int num7 = obj3;
        long num8 = obj4;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<long (IntPtr, IntPtr, long, int, IntPtr, int, long)>) SteamMatchmakingServers.__\u003Cjniptr\u003ErequestFavoritesServerList\u0028JI\u005BLcom\u002Fcodedisaster\u002Fsteamworks\u002FSteamMatchmakingKeyValuePair\u003BIJ\u0029J)((long) num2, (int) num3, (IntPtr) num4, num5, (long) num6, (IntPtr) num7, (IntPtr) num8);
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
    private static long requestHistoryServerList(
      [In] long obj0,
      [In] int obj1,
      [In] SteamMatchmakingKeyValuePair[] obj2,
      [In] int obj3,
      [In] long obj4)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamMatchmakingServers.__\u003Cjniptr\u003ErequestHistoryServerList\u0028JI\u005BLcom\u002Fcodedisaster\u002Fsteamworks\u002FSteamMatchmakingKeyValuePair\u003BIJ\u0029J == IntPtr.Zero)
        SteamMatchmakingServers.__\u003Cjniptr\u003ErequestHistoryServerList\u0028JI\u005BLcom\u002Fcodedisaster\u002Fsteamworks\u002FSteamMatchmakingKeyValuePair\u003BIJ\u0029J = JNI.Frame.GetFuncPtr(SteamMatchmakingServers.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamMatchmakingServers", nameof (requestHistoryServerList), "(JI[Lcom/codedisaster/steamworks/SteamMatchmakingKeyValuePair;IJ)J");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamMatchmakingServers.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamMatchmakingServers>.Value);
        long num4 = obj0;
        int num5 = obj1;
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj2);
        int num7 = obj3;
        long num8 = obj4;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<long (IntPtr, IntPtr, long, int, IntPtr, int, long)>) SteamMatchmakingServers.__\u003Cjniptr\u003ErequestHistoryServerList\u0028JI\u005BLcom\u002Fcodedisaster\u002Fsteamworks\u002FSteamMatchmakingKeyValuePair\u003BIJ\u0029J)((long) num2, (int) num3, (IntPtr) num4, num5, (long) num6, (IntPtr) num7, (IntPtr) num8);
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
    private static long requestSpectatorServerList(
      [In] long obj0,
      [In] int obj1,
      [In] SteamMatchmakingKeyValuePair[] obj2,
      [In] int obj3,
      [In] long obj4)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamMatchmakingServers.__\u003Cjniptr\u003ErequestSpectatorServerList\u0028JI\u005BLcom\u002Fcodedisaster\u002Fsteamworks\u002FSteamMatchmakingKeyValuePair\u003BIJ\u0029J == IntPtr.Zero)
        SteamMatchmakingServers.__\u003Cjniptr\u003ErequestSpectatorServerList\u0028JI\u005BLcom\u002Fcodedisaster\u002Fsteamworks\u002FSteamMatchmakingKeyValuePair\u003BIJ\u0029J = JNI.Frame.GetFuncPtr(SteamMatchmakingServers.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamMatchmakingServers", nameof (requestSpectatorServerList), "(JI[Lcom/codedisaster/steamworks/SteamMatchmakingKeyValuePair;IJ)J");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamMatchmakingServers.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamMatchmakingServers>.Value);
        long num4 = obj0;
        int num5 = obj1;
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj2);
        int num7 = obj3;
        long num8 = obj4;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<long (IntPtr, IntPtr, long, int, IntPtr, int, long)>) SteamMatchmakingServers.__\u003Cjniptr\u003ErequestSpectatorServerList\u0028JI\u005BLcom\u002Fcodedisaster\u002Fsteamworks\u002FSteamMatchmakingKeyValuePair\u003BIJ\u0029J)((long) num2, (int) num3, (IntPtr) num4, num5, (long) num6, (IntPtr) num7, (IntPtr) num8);
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
    private static void releaseRequest([In] long obj0, [In] long obj1)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamMatchmakingServers.__\u003Cjniptr\u003EreleaseRequest\u0028JJ\u0029V == IntPtr.Zero)
        SteamMatchmakingServers.__\u003Cjniptr\u003EreleaseRequest\u0028JJ\u0029V = JNI.Frame.GetFuncPtr(SteamMatchmakingServers.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamMatchmakingServers", nameof (releaseRequest), "(JJ)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamMatchmakingServers.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamMatchmakingServers>.Value);
        long num4 = obj0;
        long num5 = obj1;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, long, long)>) SteamMatchmakingServers.__\u003Cjniptr\u003EreleaseRequest\u0028JJ\u0029V)((long) num2, (long) num3, (IntPtr) num4, (IntPtr) num5);
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
    private static bool getServerDetails(
      [In] long obj0,
      [In] long obj1,
      [In] int obj2,
      [In] SteamMatchmakingGameServerItem obj3)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamMatchmakingServers.__\u003Cjniptr\u003EgetServerDetails\u0028JJILcom\u002Fcodedisaster\u002Fsteamworks\u002FSteamMatchmakingGameServerItem\u003B\u0029Z == IntPtr.Zero)
        SteamMatchmakingServers.__\u003Cjniptr\u003EgetServerDetails\u0028JJILcom\u002Fcodedisaster\u002Fsteamworks\u002FSteamMatchmakingGameServerItem\u003B\u0029Z = JNI.Frame.GetFuncPtr(SteamMatchmakingServers.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamMatchmakingServers", nameof (getServerDetails), "(JJILcom/codedisaster/steamworks/SteamMatchmakingGameServerItem;)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamMatchmakingServers.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamMatchmakingServers>.Value);
        long num4 = obj0;
        long num5 = obj1;
        int num6 = obj2;
        IntPtr num7 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj3);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, long, long, int, IntPtr)>) SteamMatchmakingServers.__\u003Cjniptr\u003EgetServerDetails\u0028JJILcom\u002Fcodedisaster\u002Fsteamworks\u002FSteamMatchmakingGameServerItem\u003B\u0029Z)(num2, (int) num3, num4, num5, (IntPtr) num6, num7);
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
    private static void cancelQuery([In] long obj0, [In] long obj1)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamMatchmakingServers.__\u003Cjniptr\u003EcancelQuery\u0028JJ\u0029V == IntPtr.Zero)
        SteamMatchmakingServers.__\u003Cjniptr\u003EcancelQuery\u0028JJ\u0029V = JNI.Frame.GetFuncPtr(SteamMatchmakingServers.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamMatchmakingServers", nameof (cancelQuery), "(JJ)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamMatchmakingServers.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamMatchmakingServers>.Value);
        long num4 = obj0;
        long num5 = obj1;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, long, long)>) SteamMatchmakingServers.__\u003Cjniptr\u003EcancelQuery\u0028JJ\u0029V)((long) num2, (long) num3, (IntPtr) num4, (IntPtr) num5);
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
    private static void refreshQuery([In] long obj0, [In] long obj1)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamMatchmakingServers.__\u003Cjniptr\u003ErefreshQuery\u0028JJ\u0029V == IntPtr.Zero)
        SteamMatchmakingServers.__\u003Cjniptr\u003ErefreshQuery\u0028JJ\u0029V = JNI.Frame.GetFuncPtr(SteamMatchmakingServers.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamMatchmakingServers", nameof (refreshQuery), "(JJ)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamMatchmakingServers.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamMatchmakingServers>.Value);
        long num4 = obj0;
        long num5 = obj1;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, long, long)>) SteamMatchmakingServers.__\u003Cjniptr\u003ErefreshQuery\u0028JJ\u0029V)((long) num2, (long) num3, (IntPtr) num4, (IntPtr) num5);
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
    private static bool isRefreshing([In] long obj0, [In] long obj1)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamMatchmakingServers.__\u003Cjniptr\u003EisRefreshing\u0028JJ\u0029Z == IntPtr.Zero)
        SteamMatchmakingServers.__\u003Cjniptr\u003EisRefreshing\u0028JJ\u0029Z = JNI.Frame.GetFuncPtr(SteamMatchmakingServers.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamMatchmakingServers", nameof (isRefreshing), "(JJ)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamMatchmakingServers.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamMatchmakingServers>.Value);
        long num4 = obj0;
        long num5 = obj1;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, long, long)>) SteamMatchmakingServers.__\u003Cjniptr\u003EisRefreshing\u0028JJ\u0029Z)((long) num2, (long) num3, (IntPtr) num4, (IntPtr) num5);
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
    private static int getServerCount([In] long obj0, [In] long obj1)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamMatchmakingServers.__\u003Cjniptr\u003EgetServerCount\u0028JJ\u0029I == IntPtr.Zero)
        SteamMatchmakingServers.__\u003Cjniptr\u003EgetServerCount\u0028JJ\u0029I = JNI.Frame.GetFuncPtr(SteamMatchmakingServers.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamMatchmakingServers", nameof (getServerCount), "(JJ)I");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamMatchmakingServers.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamMatchmakingServers>.Value);
        long num4 = obj0;
        long num5 = obj1;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<int (IntPtr, IntPtr, long, long)>) SteamMatchmakingServers.__\u003Cjniptr\u003EgetServerCount\u0028JJ\u0029I)((long) num2, (long) num3, (IntPtr) num4, (IntPtr) num5);
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
    private static void refreshServer([In] long obj0, [In] long obj1, [In] int obj2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamMatchmakingServers.__\u003Cjniptr\u003ErefreshServer\u0028JJI\u0029V == IntPtr.Zero)
        SteamMatchmakingServers.__\u003Cjniptr\u003ErefreshServer\u0028JJI\u0029V = JNI.Frame.GetFuncPtr(SteamMatchmakingServers.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamMatchmakingServers", nameof (refreshServer), "(JJI)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamMatchmakingServers.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamMatchmakingServers>.Value);
        long num4 = obj0;
        long num5 = obj1;
        int num6 = obj2;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, long, long, int)>) SteamMatchmakingServers.__\u003Cjniptr\u003ErefreshServer\u0028JJI\u0029V)((int) num2, (long) num3, num4, (IntPtr) num5, (IntPtr) num6);
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
    private static int pingServer([In] long obj0, [In] int obj1, [In] short obj2, [In] long obj3)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamMatchmakingServers.__\u003Cjniptr\u003EpingServer\u0028JISJ\u0029I == IntPtr.Zero)
        SteamMatchmakingServers.__\u003Cjniptr\u003EpingServer\u0028JISJ\u0029I = JNI.Frame.GetFuncPtr(SteamMatchmakingServers.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamMatchmakingServers", nameof (pingServer), "(JISJ)I");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamMatchmakingServers.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamMatchmakingServers>.Value);
        long num4 = obj0;
        int num5 = obj1;
        int num6 = (int) obj2;
        long num7 = obj3;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<int (IntPtr, IntPtr, long, int, short, long)>) SteamMatchmakingServers.__\u003Cjniptr\u003EpingServer\u0028JISJ\u0029I)((long) num2, (short) num3, (int) num4, (long) num5, (IntPtr) num6, (IntPtr) num7);
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
    private static int playerDetails([In] long obj0, [In] int obj1, [In] short obj2, [In] long obj3)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamMatchmakingServers.__\u003Cjniptr\u003EplayerDetails\u0028JISJ\u0029I == IntPtr.Zero)
        SteamMatchmakingServers.__\u003Cjniptr\u003EplayerDetails\u0028JISJ\u0029I = JNI.Frame.GetFuncPtr(SteamMatchmakingServers.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamMatchmakingServers", nameof (playerDetails), "(JISJ)I");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamMatchmakingServers.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamMatchmakingServers>.Value);
        long num4 = obj0;
        int num5 = obj1;
        int num6 = (int) obj2;
        long num7 = obj3;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<int (IntPtr, IntPtr, long, int, short, long)>) SteamMatchmakingServers.__\u003Cjniptr\u003EplayerDetails\u0028JISJ\u0029I)((long) num2, (short) num3, (int) num4, (long) num5, (IntPtr) num6, (IntPtr) num7);
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
    private static int serverRules([In] long obj0, [In] int obj1, [In] short obj2, [In] long obj3)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamMatchmakingServers.__\u003Cjniptr\u003EserverRules\u0028JISJ\u0029I == IntPtr.Zero)
        SteamMatchmakingServers.__\u003Cjniptr\u003EserverRules\u0028JISJ\u0029I = JNI.Frame.GetFuncPtr(SteamMatchmakingServers.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamMatchmakingServers", nameof (serverRules), "(JISJ)I");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamMatchmakingServers.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamMatchmakingServers>.Value);
        long num4 = obj0;
        int num5 = obj1;
        int num6 = (int) obj2;
        long num7 = obj3;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<int (IntPtr, IntPtr, long, int, short, long)>) SteamMatchmakingServers.__\u003Cjniptr\u003EserverRules\u0028JISJ\u0029I)((long) num2, (short) num3, (int) num4, (long) num5, (IntPtr) num6, (IntPtr) num7);
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
    private static void cancelServerQuery([In] long obj0, [In] int obj1)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamMatchmakingServers.__\u003Cjniptr\u003EcancelServerQuery\u0028JI\u0029V == IntPtr.Zero)
        SteamMatchmakingServers.__\u003Cjniptr\u003EcancelServerQuery\u0028JI\u0029V = JNI.Frame.GetFuncPtr(SteamMatchmakingServers.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamMatchmakingServers", nameof (cancelServerQuery), "(JI)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamMatchmakingServers.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamMatchmakingServers>.Value);
        long num4 = obj0;
        int num5 = obj1;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, long, int)>) SteamMatchmakingServers.__\u003Cjniptr\u003EcancelServerQuery\u0028JI\u0029V)((int) num2, (long) num3, (IntPtr) num4, (IntPtr) num5);
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

    [LineNumberTable(new byte[] {159, 148, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public SteamMatchmakingServers()
      : base(SteamAPI.getSteamMatchmakingServersPointer())
    {
    }

    [LineNumberTable(12)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual SteamServerListRequest requestInternetServerList(
      int appID,
      SteamMatchmakingKeyValuePair[] filters,
      SteamMatchmakingServerListResponse requestServersResponse)
    {
      return new SteamServerListRequest(SteamMatchmakingServers.requestInternetServerList(this.pointer, appID, filters, filters.Length, requestServersResponse.callback));
    }

    [LineNumberTable(19)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual SteamServerListRequest requestLANServerList(
      int appID,
      SteamMatchmakingServerListResponse requestServersResponse)
    {
      return new SteamServerListRequest(SteamMatchmakingServers.requestLANServerList(this.pointer, appID, requestServersResponse.callback));
    }

    [LineNumberTable(25)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual SteamServerListRequest requestFriendsServerList(
      int appID,
      SteamMatchmakingKeyValuePair[] filters,
      SteamMatchmakingServerListResponse requestServersResponse)
    {
      return new SteamServerListRequest(SteamMatchmakingServers.requestFriendsServerList(this.pointer, appID, filters, filters.Length, requestServersResponse.callback));
    }

    [LineNumberTable(32)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual SteamServerListRequest requestFavoritesServerList(
      int appID,
      SteamMatchmakingKeyValuePair[] filters,
      SteamMatchmakingServerListResponse requestServersResponse)
    {
      return new SteamServerListRequest(SteamMatchmakingServers.requestFavoritesServerList(this.pointer, appID, filters, filters.Length, requestServersResponse.callback));
    }

    [LineNumberTable(39)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual SteamServerListRequest requestHistoryServerList(
      int appID,
      SteamMatchmakingKeyValuePair[] filters,
      SteamMatchmakingServerListResponse requestServersResponse)
    {
      return new SteamServerListRequest(SteamMatchmakingServers.requestHistoryServerList(this.pointer, appID, filters, filters.Length, requestServersResponse.callback));
    }

    [LineNumberTable(46)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual SteamServerListRequest requestSpectatorServerList(
      int appID,
      SteamMatchmakingKeyValuePair[] filters,
      SteamMatchmakingServerListResponse requestServersResponse)
    {
      return new SteamServerListRequest(SteamMatchmakingServers.requestSpectatorServerList(this.pointer, appID, filters, filters.Length, requestServersResponse.callback));
    }

    [LineNumberTable(new byte[] {1, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void releaseRequest(SteamServerListRequest request) => SteamMatchmakingServers.releaseRequest(this.pointer, request.handle);

    [LineNumberTable(55)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool getServerDetails(
      SteamServerListRequest request,
      int server,
      SteamMatchmakingGameServerItem details)
    {
      return SteamMatchmakingServers.getServerDetails(this.pointer, request.handle, server, details);
    }

    [LineNumberTable(new byte[] {9, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void cancelQuery(SteamServerListRequest request) => SteamMatchmakingServers.cancelQuery(this.pointer, request.handle);

    [LineNumberTable(new byte[] {13, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void refreshQuery(SteamServerListRequest request) => SteamMatchmakingServers.refreshQuery(this.pointer, request.handle);

    [LineNumberTable(67)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isRefreshing(SteamServerListRequest request) => SteamMatchmakingServers.isRefreshing(this.pointer, request.handle);

    [LineNumberTable(71)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getServerCount(SteamServerListRequest request) => SteamMatchmakingServers.getServerCount(this.pointer, request.handle);

    [LineNumberTable(new byte[] {25, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void refreshServer(SteamServerListRequest request, int server) => SteamMatchmakingServers.refreshServer(this.pointer, request.handle, server);

    [LineNumberTable(79)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual SteamServerQuery pingServer(
      int ip,
      short port,
      SteamMatchmakingPingResponse requestServersResponse)
    {
      int num = (int) port;
      SteamServerQuery.__\u003Cclinit\u003E();
      return new SteamServerQuery(SteamMatchmakingServers.pingServer(this.pointer, ip, (short) num, requestServersResponse.callback));
    }

    [LineNumberTable(83)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual SteamServerQuery playerDetails(
      int ip,
      short port,
      SteamMatchmakingPlayersResponse requestServersResponse)
    {
      int num = (int) port;
      SteamServerQuery.__\u003Cclinit\u003E();
      return new SteamServerQuery(SteamMatchmakingServers.playerDetails(this.pointer, ip, (short) num, requestServersResponse.callback));
    }

    [LineNumberTable(87)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual SteamServerQuery serverRules(
      int ip,
      short port,
      SteamMatchmakingRulesResponse requestServersResponse)
    {
      int num = (int) port;
      SteamServerQuery.__\u003Cclinit\u003E();
      return new SteamServerQuery(SteamMatchmakingServers.serverRules(this.pointer, ip, (short) num, requestServersResponse.callback));
    }

    [LineNumberTable(new byte[] {41, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void cancelServerQuery(SteamServerQuery serverQuery) => SteamMatchmakingServers.cancelServerQuery(this.pointer, serverQuery.handle);

    [Modifiers]
    [LineNumberTable(3)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void dispose() => base.dispose();

    new static CallerID __\u003CGetCallerID\u003E()
    {
      if (SteamMatchmakingServers.__\u003CcallerID\u003E == null)
        SteamMatchmakingServers.__\u003CcallerID\u003E = (CallerID) new SteamMatchmakingServers.__\u003CCallerID\u003E();
      return SteamMatchmakingServers.__\u003CcallerID\u003E;
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

    private new sealed class __\u003CCallerID\u003E : CallerID
    {
      internal __\u003CCallerID\u003E()
      {
      }
    }
  }
}
