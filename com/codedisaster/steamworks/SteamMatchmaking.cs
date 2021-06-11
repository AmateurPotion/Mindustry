// Decompiled with JetBrains decompiler
// Type: com.codedisaster.steamworks.SteamMatchmaking
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
  public class SteamMatchmaking : SteamInterface
  {
    static IntPtr __\u003Cjniptr\u003EcreateCallback\u0028Lcom\u002Fcodedisaster\u002Fsteamworks\u002FSteamMatchmakingCallbackAdapter\u003B\u0029J;
    [SpecialName]
    private static CallerID __\u003CcallerID\u003E;
    static IntPtr __\u003Cjniptr\u003EgetFavoriteGameCount\u0028J\u0029I;
    static IntPtr __\u003Cjniptr\u003EgetFavoriteGame\u0028JI\u005BI\u005BI\u005BS\u005BS\u005BI\u005BI\u0029Z;
    static IntPtr __\u003Cjniptr\u003EaddFavoriteGame\u0028JIISSII\u0029I;
    static IntPtr __\u003Cjniptr\u003EremoveFavoriteGame\u0028JIISSI\u0029Z;
    static IntPtr __\u003Cjniptr\u003ErequestLobbyList\u0028JJ\u0029J;
    static IntPtr __\u003Cjniptr\u003EaddRequestLobbyListStringFilter\u0028JLjava\u002Flang\u002FString\u003BLjava\u002Flang\u002FString\u003BI\u0029V;
    static IntPtr __\u003Cjniptr\u003EaddRequestLobbyListNumericalFilter\u0028JLjava\u002Flang\u002FString\u003BII\u0029V;
    static IntPtr __\u003Cjniptr\u003EaddRequestLobbyListNearValueFilter\u0028JLjava\u002Flang\u002FString\u003BI\u0029V;
    static IntPtr __\u003Cjniptr\u003EaddRequestLobbyListFilterSlotsAvailable\u0028JI\u0029V;
    static IntPtr __\u003Cjniptr\u003EaddRequestLobbyListDistanceFilter\u0028JI\u0029V;
    static IntPtr __\u003Cjniptr\u003EaddRequestLobbyListResultCountFilter\u0028JI\u0029V;
    static IntPtr __\u003Cjniptr\u003EaddRequestLobbyListCompatibleMembersFilter\u0028JJ\u0029V;
    static IntPtr __\u003Cjniptr\u003EgetLobbyByIndex\u0028JI\u0029J;
    static IntPtr __\u003Cjniptr\u003EcreateLobby\u0028JJII\u0029J;
    static IntPtr __\u003Cjniptr\u003EjoinLobby\u0028JJJ\u0029J;
    static IntPtr __\u003Cjniptr\u003EleaveLobby\u0028JJ\u0029V;
    static IntPtr __\u003Cjniptr\u003EinviteUserToLobby\u0028JJJ\u0029Z;
    static IntPtr __\u003Cjniptr\u003EgetNumLobbyMembers\u0028JJ\u0029I;
    static IntPtr __\u003Cjniptr\u003EgetLobbyMemberByIndex\u0028JJI\u0029J;
    static IntPtr __\u003Cjniptr\u003EgetLobbyData\u0028JJLjava\u002Flang\u002FString\u003B\u0029Ljava\u002Flang\u002FString\u003B;
    static IntPtr __\u003Cjniptr\u003EsetLobbyData\u0028JJLjava\u002Flang\u002FString\u003BLjava\u002Flang\u002FString\u003B\u0029Z;
    static IntPtr __\u003Cjniptr\u003EgetLobbyMemberData\u0028JJJLjava\u002Flang\u002FString\u003B\u0029Ljava\u002Flang\u002FString\u003B;
    static IntPtr __\u003Cjniptr\u003EsetLobbyMemberData\u0028JJLjava\u002Flang\u002FString\u003BLjava\u002Flang\u002FString\u003B\u0029V;
    static IntPtr __\u003Cjniptr\u003EgetLobbyDataCount\u0028JJ\u0029I;
    static IntPtr __\u003Cjniptr\u003EgetLobbyDataByIndex\u0028JJILcom\u002Fcodedisaster\u002Fsteamworks\u002FSteamMatchmakingKeyValuePair\u003B\u0029Z;
    static IntPtr __\u003Cjniptr\u003EdeleteLobbyData\u0028JJLjava\u002Flang\u002FString\u003B\u0029Z;
    static IntPtr __\u003Cjniptr\u003EsendLobbyChatMsg\u0028JJLjava\u002Fnio\u002FByteBuffer\u003BII\u0029Z;
    static IntPtr __\u003Cjniptr\u003EsendLobbyChatMsg\u0028JJLjava\u002Flang\u002FString\u003B\u0029Z;
    static IntPtr __\u003Cjniptr\u003EgetLobbyChatEntry\u0028JJILcom\u002Fcodedisaster\u002Fsteamworks\u002FSteamMatchmaking\u0024ChatEntry\u003BLjava\u002Fnio\u002FByteBuffer\u003BII\u0029I;
    static IntPtr __\u003Cjniptr\u003ErequestLobbyData\u0028JJ\u0029Z;
    static IntPtr __\u003Cjniptr\u003EsetLobbyGameServer\u0028JJISJ\u0029V;
    static IntPtr __\u003Cjniptr\u003EgetLobbyGameServer\u0028JJ\u005BI\u005BS\u005BJ\u0029Z;
    static IntPtr __\u003Cjniptr\u003EsetLobbyMemberLimit\u0028JJI\u0029Z;
    static IntPtr __\u003Cjniptr\u003EgetLobbyMemberLimit\u0028JJ\u0029I;
    static IntPtr __\u003Cjniptr\u003EsetLobbyType\u0028JJI\u0029Z;
    static IntPtr __\u003Cjniptr\u003EsetLobbyJoinable\u0028JJZ\u0029Z;
    static IntPtr __\u003Cjniptr\u003EgetLobbyOwner\u0028JJ\u0029J;
    static IntPtr __\u003Cjniptr\u003EsetLobbyOwner\u0028JJJ\u0029Z;
    static IntPtr __\u003Cjniptr\u003EsetLinkedLobby\u0028JJJ\u0029Z;

    [LineNumberTable(new byte[] {83, 118})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public SteamMatchmaking(SteamMatchmakingCallback callback)
      : base(SteamAPI.getSteamMatchmakingPointer(), SteamMatchmaking.createCallback(new SteamMatchmakingCallbackAdapter(callback)))
    {
    }

    [LineNumberTable(198)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual SteamAPICall joinLobby(SteamID steamIDLobby) => new SteamAPICall(SteamMatchmaking.joinLobby(this.pointer, this.callback, steamIDLobby.handle));

    [LineNumberTable(new byte[] {160, 88, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void leaveLobby(SteamID steamIDLobby) => SteamMatchmaking.leaveLobby(this.pointer, steamIDLobby.handle);

    [LineNumberTable(new byte[] {160, 68, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addRequestLobbyListResultCountFilter(int maxResults) => SteamMatchmaking.addRequestLobbyListResultCountFilter(this.pointer, maxResults);

    [LineNumberTable(154)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual SteamAPICall requestLobbyList() => new SteamAPICall(SteamMatchmaking.requestLobbyList(this.pointer, this.callback));

    [LineNumberTable(194)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual SteamAPICall createLobby(
      SteamMatchmaking.LobbyType lobbyType,
      int maxMembers)
    {
      return new SteamAPICall(SteamMatchmaking.createLobby(this.pointer, this.callback, lobbyType.ordinal(), maxMembers));
    }

    [LineNumberTable(315)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool setLobbyType(SteamID steamIDLobby, SteamMatchmaking.LobbyType lobbyType) => SteamMatchmaking.setLobbyType(this.pointer, steamIDLobby.handle, lobbyType.ordinal());

    [LineNumberTable(307)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool setLobbyMemberLimit(SteamID steamIDLobby, int maxMembers) => SteamMatchmaking.setLobbyMemberLimit(this.pointer, steamIDLobby.handle, maxMembers);

    [LineNumberTable(218)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string getLobbyData(SteamID steamIDLobby, string key) => SteamMatchmaking.getLobbyData(this.pointer, steamIDLobby.handle, key);

    [LineNumberTable(323)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual SteamID getLobbyOwner(SteamID steamIDLobby)
    {
      SteamID.__\u003Cclinit\u003E();
      return new SteamID(SteamMatchmaking.getLobbyOwner(this.pointer, steamIDLobby.handle));
    }

    [LineNumberTable(190)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual SteamID getLobbyByIndex(int lobby)
    {
      SteamID.__\u003Cclinit\u003E();
      return new SteamID(SteamMatchmaking.getLobbyByIndex(this.pointer, lobby));
    }

    [LineNumberTable(210)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getNumLobbyMembers(SteamID steamIDLobby) => SteamMatchmaking.getNumLobbyMembers(this.pointer, steamIDLobby.handle);

    [LineNumberTable(311)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getLobbyMemberLimit(SteamID steamIDLobby) => SteamMatchmaking.getLobbyMemberLimit(this.pointer, steamIDLobby.handle);

    [LineNumberTable(222)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool setLobbyData(SteamID steamIDLobby, string key, string value) => SteamMatchmaking.setLobbyData(this.pointer, steamIDLobby.handle, key, value);

    [Modifiers]
    private static long createCallback([In] SteamMatchmakingCallbackAdapter obj0)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamMatchmaking.__\u003Cjniptr\u003EcreateCallback\u0028Lcom\u002Fcodedisaster\u002Fsteamworks\u002FSteamMatchmakingCallbackAdapter\u003B\u0029J == IntPtr.Zero)
        SteamMatchmaking.__\u003Cjniptr\u003EcreateCallback\u0028Lcom\u002Fcodedisaster\u002Fsteamworks\u002FSteamMatchmakingCallbackAdapter\u003B\u0029J = JNI.Frame.GetFuncPtr(SteamMatchmaking.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamMatchmaking", nameof (createCallback), "(Lcom/codedisaster/steamworks/SteamMatchmakingCallbackAdapter;)J");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamMatchmaking.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamMatchmaking>.Value);
        IntPtr num4 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj0);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<long (IntPtr, IntPtr, IntPtr)>) SteamMatchmaking.__\u003Cjniptr\u003EcreateCallback\u0028Lcom\u002Fcodedisaster\u002Fsteamworks\u002FSteamMatchmakingCallbackAdapter\u003B\u0029J)(num2, num3, num4);
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
    private static int getFavoriteGameCount([In] long obj0)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamMatchmaking.__\u003Cjniptr\u003EgetFavoriteGameCount\u0028J\u0029I == IntPtr.Zero)
        SteamMatchmaking.__\u003Cjniptr\u003EgetFavoriteGameCount\u0028J\u0029I = JNI.Frame.GetFuncPtr(SteamMatchmaking.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamMatchmaking", nameof (getFavoriteGameCount), "(J)I");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamMatchmaking.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamMatchmaking>.Value);
        long num4 = obj0;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<int (IntPtr, IntPtr, long)>) SteamMatchmaking.__\u003Cjniptr\u003EgetFavoriteGameCount\u0028J\u0029I)((long) num2, num3, (IntPtr) num4);
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
    private static bool getFavoriteGame(
      [In] long obj0,
      [In] int obj1,
      [In] int[] obj2,
      [In] int[] obj3,
      [In] short[] obj4,
      [In] short[] obj5,
      [In] int[] obj6,
      [In] int[] obj7)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamMatchmaking.__\u003Cjniptr\u003EgetFavoriteGame\u0028JI\u005BI\u005BI\u005BS\u005BS\u005BI\u005BI\u0029Z == IntPtr.Zero)
        SteamMatchmaking.__\u003Cjniptr\u003EgetFavoriteGame\u0028JI\u005BI\u005BI\u005BS\u005BS\u005BI\u005BI\u0029Z = JNI.Frame.GetFuncPtr(SteamMatchmaking.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamMatchmaking", nameof (getFavoriteGame), "(JI[I[I[S[S[I[I)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamMatchmaking.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamMatchmaking>.Value);
        long num4 = obj0;
        int num5 = obj1;
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj2);
        IntPtr num7 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj3);
        IntPtr num8 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj4);
        IntPtr num9 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj5);
        IntPtr num10 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj6);
        IntPtr num11 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj7);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, long, int, IntPtr, IntPtr, IntPtr, IntPtr, IntPtr, IntPtr)>) SteamMatchmaking.__\u003Cjniptr\u003EgetFavoriteGame\u0028JI\u005BI\u005BI\u005BS\u005BS\u005BI\u005BI\u0029Z)(num2, num3, (IntPtr) num4, (IntPtr) num5, num6, num7, (int) num8, (long) num9, num10, num11);
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
    private static int addFavoriteGame(
      [In] long obj0,
      [In] int obj1,
      [In] int obj2,
      [In] short obj3,
      [In] short obj4,
      [In] int obj5,
      [In] int obj6)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamMatchmaking.__\u003Cjniptr\u003EaddFavoriteGame\u0028JIISSII\u0029I == IntPtr.Zero)
        SteamMatchmaking.__\u003Cjniptr\u003EaddFavoriteGame\u0028JIISSII\u0029I = JNI.Frame.GetFuncPtr(SteamMatchmaking.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamMatchmaking", nameof (addFavoriteGame), "(JIISSII)I");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamMatchmaking.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamMatchmaking>.Value);
        long num4 = obj0;
        int num5 = obj1;
        int num6 = obj2;
        int num7 = (int) obj3;
        int num8 = (int) obj4;
        int num9 = obj5;
        int num10 = obj6;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<int (IntPtr, IntPtr, long, int, int, short, short, int, int)>) SteamMatchmaking.__\u003Cjniptr\u003EaddFavoriteGame\u0028JIISSII\u0029I)((int) num2, (int) num3, (short) num4, (short) num5, num6, num7, (long) num8, (IntPtr) num9, (IntPtr) num10);
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
    private static bool removeFavoriteGame(
      [In] long obj0,
      [In] int obj1,
      [In] int obj2,
      [In] short obj3,
      [In] short obj4,
      [In] int obj5)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamMatchmaking.__\u003Cjniptr\u003EremoveFavoriteGame\u0028JIISSI\u0029Z == IntPtr.Zero)
        SteamMatchmaking.__\u003Cjniptr\u003EremoveFavoriteGame\u0028JIISSI\u0029Z = JNI.Frame.GetFuncPtr(SteamMatchmaking.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamMatchmaking", nameof (removeFavoriteGame), "(JIISSI)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamMatchmaking.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamMatchmaking>.Value);
        long num4 = obj0;
        int num5 = obj1;
        int num6 = obj2;
        int num7 = (int) obj3;
        int num8 = (int) obj4;
        int num9 = obj5;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, long, int, int, short, short, int)>) SteamMatchmaking.__\u003Cjniptr\u003EremoveFavoriteGame\u0028JIISSI\u0029Z)((int) num2, (short) num3, (short) num4, num5, num6, (long) num7, (IntPtr) num8, (IntPtr) num9);
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
    private static long requestLobbyList([In] long obj0, [In] long obj1)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamMatchmaking.__\u003Cjniptr\u003ErequestLobbyList\u0028JJ\u0029J == IntPtr.Zero)
        SteamMatchmaking.__\u003Cjniptr\u003ErequestLobbyList\u0028JJ\u0029J = JNI.Frame.GetFuncPtr(SteamMatchmaking.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamMatchmaking", nameof (requestLobbyList), "(JJ)J");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamMatchmaking.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamMatchmaking>.Value);
        long num4 = obj0;
        long num5 = obj1;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<long (IntPtr, IntPtr, long, long)>) SteamMatchmaking.__\u003Cjniptr\u003ErequestLobbyList\u0028JJ\u0029J)((long) num2, (long) num3, (IntPtr) num4, (IntPtr) num5);
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
    private static void addRequestLobbyListStringFilter(
      [In] long obj0,
      [In] string obj1,
      [In] string obj2,
      [In] int obj3)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamMatchmaking.__\u003Cjniptr\u003EaddRequestLobbyListStringFilter\u0028JLjava\u002Flang\u002FString\u003BLjava\u002Flang\u002FString\u003BI\u0029V == IntPtr.Zero)
        SteamMatchmaking.__\u003Cjniptr\u003EaddRequestLobbyListStringFilter\u0028JLjava\u002Flang\u002FString\u003BLjava\u002Flang\u002FString\u003BI\u0029V = JNI.Frame.GetFuncPtr(SteamMatchmaking.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamMatchmaking", nameof (addRequestLobbyListStringFilter), "(JLjava/lang/String;Ljava/lang/String;I)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamMatchmaking.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamMatchmaking>.Value);
        long num4 = obj0;
        IntPtr num5 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj1);
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj2);
        int num7 = obj3;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, long, IntPtr, IntPtr, int)>) SteamMatchmaking.__\u003Cjniptr\u003EaddRequestLobbyListStringFilter\u0028JLjava\u002Flang\u002FString\u003BLjava\u002Flang\u002FString\u003BI\u0029V)((int) num2, num3, (IntPtr) num4, (long) num5, num6, (IntPtr) num7);
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
    private static void addRequestLobbyListNumericalFilter(
      [In] long obj0,
      [In] string obj1,
      [In] int obj2,
      [In] int obj3)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamMatchmaking.__\u003Cjniptr\u003EaddRequestLobbyListNumericalFilter\u0028JLjava\u002Flang\u002FString\u003BII\u0029V == IntPtr.Zero)
        SteamMatchmaking.__\u003Cjniptr\u003EaddRequestLobbyListNumericalFilter\u0028JLjava\u002Flang\u002FString\u003BII\u0029V = JNI.Frame.GetFuncPtr(SteamMatchmaking.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamMatchmaking", nameof (addRequestLobbyListNumericalFilter), "(JLjava/lang/String;II)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamMatchmaking.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamMatchmaking>.Value);
        long num4 = obj0;
        IntPtr num5 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj1);
        int num6 = obj2;
        int num7 = obj3;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, long, IntPtr, int, int)>) SteamMatchmaking.__\u003Cjniptr\u003EaddRequestLobbyListNumericalFilter\u0028JLjava\u002Flang\u002FString\u003BII\u0029V)((int) num2, (int) num3, (IntPtr) num4, (long) num5, (IntPtr) num6, (IntPtr) num7);
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
    private static void addRequestLobbyListNearValueFilter([In] long obj0, [In] string obj1, [In] int obj2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamMatchmaking.__\u003Cjniptr\u003EaddRequestLobbyListNearValueFilter\u0028JLjava\u002Flang\u002FString\u003BI\u0029V == IntPtr.Zero)
        SteamMatchmaking.__\u003Cjniptr\u003EaddRequestLobbyListNearValueFilter\u0028JLjava\u002Flang\u002FString\u003BI\u0029V = JNI.Frame.GetFuncPtr(SteamMatchmaking.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamMatchmaking", nameof (addRequestLobbyListNearValueFilter), "(JLjava/lang/String;I)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamMatchmaking.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamMatchmaking>.Value);
        long num4 = obj0;
        IntPtr num5 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj1);
        int num6 = obj2;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, long, IntPtr, int)>) SteamMatchmaking.__\u003Cjniptr\u003EaddRequestLobbyListNearValueFilter\u0028JLjava\u002Flang\u002FString\u003BI\u0029V)((int) num2, num3, num4, num5, (IntPtr) num6);
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
    private static void addRequestLobbyListFilterSlotsAvailable([In] long obj0, [In] int obj1)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamMatchmaking.__\u003Cjniptr\u003EaddRequestLobbyListFilterSlotsAvailable\u0028JI\u0029V == IntPtr.Zero)
        SteamMatchmaking.__\u003Cjniptr\u003EaddRequestLobbyListFilterSlotsAvailable\u0028JI\u0029V = JNI.Frame.GetFuncPtr(SteamMatchmaking.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamMatchmaking", nameof (addRequestLobbyListFilterSlotsAvailable), "(JI)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamMatchmaking.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamMatchmaking>.Value);
        long num4 = obj0;
        int num5 = obj1;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, long, int)>) SteamMatchmaking.__\u003Cjniptr\u003EaddRequestLobbyListFilterSlotsAvailable\u0028JI\u0029V)((int) num2, (long) num3, (IntPtr) num4, (IntPtr) num5);
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
    private static void addRequestLobbyListDistanceFilter([In] long obj0, [In] int obj1)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamMatchmaking.__\u003Cjniptr\u003EaddRequestLobbyListDistanceFilter\u0028JI\u0029V == IntPtr.Zero)
        SteamMatchmaking.__\u003Cjniptr\u003EaddRequestLobbyListDistanceFilter\u0028JI\u0029V = JNI.Frame.GetFuncPtr(SteamMatchmaking.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamMatchmaking", nameof (addRequestLobbyListDistanceFilter), "(JI)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamMatchmaking.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamMatchmaking>.Value);
        long num4 = obj0;
        int num5 = obj1;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, long, int)>) SteamMatchmaking.__\u003Cjniptr\u003EaddRequestLobbyListDistanceFilter\u0028JI\u0029V)((int) num2, (long) num3, (IntPtr) num4, (IntPtr) num5);
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
    private static void addRequestLobbyListResultCountFilter([In] long obj0, [In] int obj1)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamMatchmaking.__\u003Cjniptr\u003EaddRequestLobbyListResultCountFilter\u0028JI\u0029V == IntPtr.Zero)
        SteamMatchmaking.__\u003Cjniptr\u003EaddRequestLobbyListResultCountFilter\u0028JI\u0029V = JNI.Frame.GetFuncPtr(SteamMatchmaking.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamMatchmaking", nameof (addRequestLobbyListResultCountFilter), "(JI)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamMatchmaking.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamMatchmaking>.Value);
        long num4 = obj0;
        int num5 = obj1;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, long, int)>) SteamMatchmaking.__\u003Cjniptr\u003EaddRequestLobbyListResultCountFilter\u0028JI\u0029V)((int) num2, (long) num3, (IntPtr) num4, (IntPtr) num5);
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
    private static void addRequestLobbyListCompatibleMembersFilter([In] long obj0, [In] long obj1)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamMatchmaking.__\u003Cjniptr\u003EaddRequestLobbyListCompatibleMembersFilter\u0028JJ\u0029V == IntPtr.Zero)
        SteamMatchmaking.__\u003Cjniptr\u003EaddRequestLobbyListCompatibleMembersFilter\u0028JJ\u0029V = JNI.Frame.GetFuncPtr(SteamMatchmaking.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamMatchmaking", nameof (addRequestLobbyListCompatibleMembersFilter), "(JJ)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamMatchmaking.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamMatchmaking>.Value);
        long num4 = obj0;
        long num5 = obj1;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, long, long)>) SteamMatchmaking.__\u003Cjniptr\u003EaddRequestLobbyListCompatibleMembersFilter\u0028JJ\u0029V)((long) num2, (long) num3, (IntPtr) num4, (IntPtr) num5);
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
    private static long getLobbyByIndex([In] long obj0, [In] int obj1)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamMatchmaking.__\u003Cjniptr\u003EgetLobbyByIndex\u0028JI\u0029J == IntPtr.Zero)
        SteamMatchmaking.__\u003Cjniptr\u003EgetLobbyByIndex\u0028JI\u0029J = JNI.Frame.GetFuncPtr(SteamMatchmaking.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamMatchmaking", nameof (getLobbyByIndex), "(JI)J");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamMatchmaking.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamMatchmaking>.Value);
        long num4 = obj0;
        int num5 = obj1;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<long (IntPtr, IntPtr, long, int)>) SteamMatchmaking.__\u003Cjniptr\u003EgetLobbyByIndex\u0028JI\u0029J)((int) num2, (long) num3, (IntPtr) num4, (IntPtr) num5);
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
    private static long createLobby([In] long obj0, [In] long obj1, [In] int obj2, [In] int obj3)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamMatchmaking.__\u003Cjniptr\u003EcreateLobby\u0028JJII\u0029J == IntPtr.Zero)
        SteamMatchmaking.__\u003Cjniptr\u003EcreateLobby\u0028JJII\u0029J = JNI.Frame.GetFuncPtr(SteamMatchmaking.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamMatchmaking", nameof (createLobby), "(JJII)J");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamMatchmaking.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamMatchmaking>.Value);
        long num4 = obj0;
        long num5 = obj1;
        int num6 = obj2;
        int num7 = obj3;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<long (IntPtr, IntPtr, long, long, int, int)>) SteamMatchmaking.__\u003Cjniptr\u003EcreateLobby\u0028JJII\u0029J)((int) num2, (int) num3, num4, num5, (IntPtr) num6, (IntPtr) num7);
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
    private static long joinLobby([In] long obj0, [In] long obj1, [In] long obj2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamMatchmaking.__\u003Cjniptr\u003EjoinLobby\u0028JJJ\u0029J == IntPtr.Zero)
        SteamMatchmaking.__\u003Cjniptr\u003EjoinLobby\u0028JJJ\u0029J = JNI.Frame.GetFuncPtr(SteamMatchmaking.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamMatchmaking", nameof (joinLobby), "(JJJ)J");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamMatchmaking.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamMatchmaking>.Value);
        long num4 = obj0;
        long num5 = obj1;
        long num6 = obj2;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<long (IntPtr, IntPtr, long, long, long)>) SteamMatchmaking.__\u003Cjniptr\u003EjoinLobby\u0028JJJ\u0029J)((long) num2, (long) num3, num4, (IntPtr) num5, (IntPtr) num6);
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
    private static void leaveLobby([In] long obj0, [In] long obj1)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamMatchmaking.__\u003Cjniptr\u003EleaveLobby\u0028JJ\u0029V == IntPtr.Zero)
        SteamMatchmaking.__\u003Cjniptr\u003EleaveLobby\u0028JJ\u0029V = JNI.Frame.GetFuncPtr(SteamMatchmaking.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamMatchmaking", nameof (leaveLobby), "(JJ)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamMatchmaking.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamMatchmaking>.Value);
        long num4 = obj0;
        long num5 = obj1;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, long, long)>) SteamMatchmaking.__\u003Cjniptr\u003EleaveLobby\u0028JJ\u0029V)((long) num2, (long) num3, (IntPtr) num4, (IntPtr) num5);
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
    private static bool inviteUserToLobby([In] long obj0, [In] long obj1, [In] long obj2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamMatchmaking.__\u003Cjniptr\u003EinviteUserToLobby\u0028JJJ\u0029Z == IntPtr.Zero)
        SteamMatchmaking.__\u003Cjniptr\u003EinviteUserToLobby\u0028JJJ\u0029Z = JNI.Frame.GetFuncPtr(SteamMatchmaking.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamMatchmaking", nameof (inviteUserToLobby), "(JJJ)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamMatchmaking.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamMatchmaking>.Value);
        long num4 = obj0;
        long num5 = obj1;
        long num6 = obj2;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, long, long, long)>) SteamMatchmaking.__\u003Cjniptr\u003EinviteUserToLobby\u0028JJJ\u0029Z)((long) num2, (long) num3, num4, (IntPtr) num5, (IntPtr) num6);
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
    private static int getNumLobbyMembers([In] long obj0, [In] long obj1)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamMatchmaking.__\u003Cjniptr\u003EgetNumLobbyMembers\u0028JJ\u0029I == IntPtr.Zero)
        SteamMatchmaking.__\u003Cjniptr\u003EgetNumLobbyMembers\u0028JJ\u0029I = JNI.Frame.GetFuncPtr(SteamMatchmaking.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamMatchmaking", nameof (getNumLobbyMembers), "(JJ)I");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamMatchmaking.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamMatchmaking>.Value);
        long num4 = obj0;
        long num5 = obj1;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<int (IntPtr, IntPtr, long, long)>) SteamMatchmaking.__\u003Cjniptr\u003EgetNumLobbyMembers\u0028JJ\u0029I)((long) num2, (long) num3, (IntPtr) num4, (IntPtr) num5);
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
    private static long getLobbyMemberByIndex([In] long obj0, [In] long obj1, [In] int obj2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamMatchmaking.__\u003Cjniptr\u003EgetLobbyMemberByIndex\u0028JJI\u0029J == IntPtr.Zero)
        SteamMatchmaking.__\u003Cjniptr\u003EgetLobbyMemberByIndex\u0028JJI\u0029J = JNI.Frame.GetFuncPtr(SteamMatchmaking.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamMatchmaking", nameof (getLobbyMemberByIndex), "(JJI)J");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamMatchmaking.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamMatchmaking>.Value);
        long num4 = obj0;
        long num5 = obj1;
        int num6 = obj2;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<long (IntPtr, IntPtr, long, long, int)>) SteamMatchmaking.__\u003Cjniptr\u003EgetLobbyMemberByIndex\u0028JJI\u0029J)((int) num2, (long) num3, num4, (IntPtr) num5, (IntPtr) num6);
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
    private static string getLobbyData([In] long obj0, [In] long obj1, [In] string obj2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamMatchmaking.__\u003Cjniptr\u003EgetLobbyData\u0028JJLjava\u002Flang\u002FString\u003B\u0029Ljava\u002Flang\u002FString\u003B == IntPtr.Zero)
        SteamMatchmaking.__\u003Cjniptr\u003EgetLobbyData\u0028JJLjava\u002Flang\u002FString\u003B\u0029Ljava\u002Flang\u002FString\u003B = JNI.Frame.GetFuncPtr(SteamMatchmaking.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamMatchmaking", nameof (getLobbyData), "(JJLjava/lang/String;)Ljava/lang/String;");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamMatchmaking.__\u003CGetCallerID\u003E());
      try
      {
        ref JNI.Frame local = ref frame;
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamMatchmaking>.Value);
        long num4 = obj0;
        long num5 = obj1;
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj2);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        IntPtr num7 = __calli((__FnPtr<IntPtr (IntPtr, IntPtr, long, long, IntPtr)>) SteamMatchmaking.__\u003Cjniptr\u003EgetLobbyData\u0028JJLjava\u002Flang\u002FString\u003B\u0029Ljava\u002Flang\u002FString\u003B)(num2, (long) num3, num4, (IntPtr) num5, num6);
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
    private static bool setLobbyData([In] long obj0, [In] long obj1, [In] string obj2, [In] string obj3)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamMatchmaking.__\u003Cjniptr\u003EsetLobbyData\u0028JJLjava\u002Flang\u002FString\u003BLjava\u002Flang\u002FString\u003B\u0029Z == IntPtr.Zero)
        SteamMatchmaking.__\u003Cjniptr\u003EsetLobbyData\u0028JJLjava\u002Flang\u002FString\u003BLjava\u002Flang\u002FString\u003B\u0029Z = JNI.Frame.GetFuncPtr(SteamMatchmaking.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamMatchmaking", nameof (setLobbyData), "(JJLjava/lang/String;Ljava/lang/String;)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamMatchmaking.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamMatchmaking>.Value);
        long num4 = obj0;
        long num5 = obj1;
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj2);
        IntPtr num7 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj3);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, long, long, IntPtr, IntPtr)>) SteamMatchmaking.__\u003Cjniptr\u003EsetLobbyData\u0028JJLjava\u002Flang\u002FString\u003BLjava\u002Flang\u002FString\u003B\u0029Z)(num2, num3, num4, num5, num6, num7);
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
    private static string getLobbyMemberData([In] long obj0, [In] long obj1, [In] long obj2, [In] string obj3)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamMatchmaking.__\u003Cjniptr\u003EgetLobbyMemberData\u0028JJJLjava\u002Flang\u002FString\u003B\u0029Ljava\u002Flang\u002FString\u003B == IntPtr.Zero)
        SteamMatchmaking.__\u003Cjniptr\u003EgetLobbyMemberData\u0028JJJLjava\u002Flang\u002FString\u003B\u0029Ljava\u002Flang\u002FString\u003B = JNI.Frame.GetFuncPtr(SteamMatchmaking.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamMatchmaking", nameof (getLobbyMemberData), "(JJJLjava/lang/String;)Ljava/lang/String;");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamMatchmaking.__\u003CGetCallerID\u003E());
      try
      {
        ref JNI.Frame local = ref frame;
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamMatchmaking>.Value);
        long num4 = obj0;
        long num5 = obj1;
        long num6 = obj2;
        IntPtr num7 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj3);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        IntPtr num8 = __calli((__FnPtr<IntPtr (IntPtr, IntPtr, long, long, long, IntPtr)>) SteamMatchmaking.__\u003Cjniptr\u003EgetLobbyMemberData\u0028JJJLjava\u002Flang\u002FString\u003B\u0029Ljava\u002Flang\u002FString\u003B)(num2, (long) num3, num4, num5, (IntPtr) num6, num7);
        return (string) ((JNI.Frame) ref local).UnwrapLocalRef(num8);
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
    private static void setLobbyMemberData([In] long obj0, [In] long obj1, [In] string obj2, [In] string obj3)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamMatchmaking.__\u003Cjniptr\u003EsetLobbyMemberData\u0028JJLjava\u002Flang\u002FString\u003BLjava\u002Flang\u002FString\u003B\u0029V == IntPtr.Zero)
        SteamMatchmaking.__\u003Cjniptr\u003EsetLobbyMemberData\u0028JJLjava\u002Flang\u002FString\u003BLjava\u002Flang\u002FString\u003B\u0029V = JNI.Frame.GetFuncPtr(SteamMatchmaking.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamMatchmaking", nameof (setLobbyMemberData), "(JJLjava/lang/String;Ljava/lang/String;)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamMatchmaking.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamMatchmaking>.Value);
        long num4 = obj0;
        long num5 = obj1;
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj2);
        IntPtr num7 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj3);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, long, long, IntPtr, IntPtr)>) SteamMatchmaking.__\u003Cjniptr\u003EsetLobbyMemberData\u0028JJLjava\u002Flang\u002FString\u003BLjava\u002Flang\u002FString\u003B\u0029V)(num2, num3, num4, num5, num6, num7);
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
    private static int getLobbyDataCount([In] long obj0, [In] long obj1)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamMatchmaking.__\u003Cjniptr\u003EgetLobbyDataCount\u0028JJ\u0029I == IntPtr.Zero)
        SteamMatchmaking.__\u003Cjniptr\u003EgetLobbyDataCount\u0028JJ\u0029I = JNI.Frame.GetFuncPtr(SteamMatchmaking.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamMatchmaking", nameof (getLobbyDataCount), "(JJ)I");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamMatchmaking.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamMatchmaking>.Value);
        long num4 = obj0;
        long num5 = obj1;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<int (IntPtr, IntPtr, long, long)>) SteamMatchmaking.__\u003Cjniptr\u003EgetLobbyDataCount\u0028JJ\u0029I)((long) num2, (long) num3, (IntPtr) num4, (IntPtr) num5);
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
    private static bool getLobbyDataByIndex(
      [In] long obj0,
      [In] long obj1,
      [In] int obj2,
      [In] SteamMatchmakingKeyValuePair obj3)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamMatchmaking.__\u003Cjniptr\u003EgetLobbyDataByIndex\u0028JJILcom\u002Fcodedisaster\u002Fsteamworks\u002FSteamMatchmakingKeyValuePair\u003B\u0029Z == IntPtr.Zero)
        SteamMatchmaking.__\u003Cjniptr\u003EgetLobbyDataByIndex\u0028JJILcom\u002Fcodedisaster\u002Fsteamworks\u002FSteamMatchmakingKeyValuePair\u003B\u0029Z = JNI.Frame.GetFuncPtr(SteamMatchmaking.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamMatchmaking", nameof (getLobbyDataByIndex), "(JJILcom/codedisaster/steamworks/SteamMatchmakingKeyValuePair;)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamMatchmaking.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamMatchmaking>.Value);
        long num4 = obj0;
        long num5 = obj1;
        int num6 = obj2;
        IntPtr num7 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj3);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, long, long, int, IntPtr)>) SteamMatchmaking.__\u003Cjniptr\u003EgetLobbyDataByIndex\u0028JJILcom\u002Fcodedisaster\u002Fsteamworks\u002FSteamMatchmakingKeyValuePair\u003B\u0029Z)(num2, (int) num3, num4, num5, (IntPtr) num6, num7);
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
    private static bool deleteLobbyData([In] long obj0, [In] long obj1, [In] string obj2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamMatchmaking.__\u003Cjniptr\u003EdeleteLobbyData\u0028JJLjava\u002Flang\u002FString\u003B\u0029Z == IntPtr.Zero)
        SteamMatchmaking.__\u003Cjniptr\u003EdeleteLobbyData\u0028JJLjava\u002Flang\u002FString\u003B\u0029Z = JNI.Frame.GetFuncPtr(SteamMatchmaking.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamMatchmaking", nameof (deleteLobbyData), "(JJLjava/lang/String;)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamMatchmaking.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamMatchmaking>.Value);
        long num4 = obj0;
        long num5 = obj1;
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj2);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, long, long, IntPtr)>) SteamMatchmaking.__\u003Cjniptr\u003EdeleteLobbyData\u0028JJLjava\u002Flang\u002FString\u003B\u0029Z)(num2, (long) num3, num4, (IntPtr) num5, num6);
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
    private static bool sendLobbyChatMsg(
      [In] long obj0,
      [In] long obj1,
      [In] ByteBuffer obj2,
      [In] int obj3,
      [In] int obj4)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamMatchmaking.__\u003Cjniptr\u003EsendLobbyChatMsg\u0028JJLjava\u002Fnio\u002FByteBuffer\u003BII\u0029Z == IntPtr.Zero)
        SteamMatchmaking.__\u003Cjniptr\u003EsendLobbyChatMsg\u0028JJLjava\u002Fnio\u002FByteBuffer\u003BII\u0029Z = JNI.Frame.GetFuncPtr(SteamMatchmaking.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamMatchmaking", nameof (sendLobbyChatMsg), "(JJLjava/nio/ByteBuffer;II)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamMatchmaking.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamMatchmaking>.Value);
        long num4 = obj0;
        long num5 = obj1;
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj2);
        int num7 = obj3;
        int num8 = obj4;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, long, long, IntPtr, int, int)>) SteamMatchmaking.__\u003Cjniptr\u003EsendLobbyChatMsg\u0028JJLjava\u002Fnio\u002FByteBuffer\u003BII\u0029Z)((int) num2, (int) num3, (IntPtr) num4, num5, (long) num6, (IntPtr) num7, (IntPtr) num8);
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
    private static bool sendLobbyChatMsg([In] long obj0, [In] long obj1, [In] string obj2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamMatchmaking.__\u003Cjniptr\u003EsendLobbyChatMsg\u0028JJLjava\u002Flang\u002FString\u003B\u0029Z == IntPtr.Zero)
        SteamMatchmaking.__\u003Cjniptr\u003EsendLobbyChatMsg\u0028JJLjava\u002Flang\u002FString\u003B\u0029Z = JNI.Frame.GetFuncPtr(SteamMatchmaking.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamMatchmaking", nameof (sendLobbyChatMsg), "(JJLjava/lang/String;)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamMatchmaking.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamMatchmaking>.Value);
        long num4 = obj0;
        long num5 = obj1;
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj2);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, long, long, IntPtr)>) SteamMatchmaking.__\u003Cjniptr\u003EsendLobbyChatMsg\u0028JJLjava\u002Flang\u002FString\u003B\u0029Z)(num2, (long) num3, num4, (IntPtr) num5, num6);
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
    private static int getLobbyChatEntry(
      [In] long obj0,
      [In] long obj1,
      [In] int obj2,
      [In] SteamMatchmaking.ChatEntry obj3,
      [In] ByteBuffer obj4,
      [In] int obj5,
      [In] int obj6)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamMatchmaking.__\u003Cjniptr\u003EgetLobbyChatEntry\u0028JJILcom\u002Fcodedisaster\u002Fsteamworks\u002FSteamMatchmaking\u0024ChatEntry\u003BLjava\u002Fnio\u002FByteBuffer\u003BII\u0029I == IntPtr.Zero)
        SteamMatchmaking.__\u003Cjniptr\u003EgetLobbyChatEntry\u0028JJILcom\u002Fcodedisaster\u002Fsteamworks\u002FSteamMatchmaking\u0024ChatEntry\u003BLjava\u002Fnio\u002FByteBuffer\u003BII\u0029I = JNI.Frame.GetFuncPtr(SteamMatchmaking.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamMatchmaking", nameof (getLobbyChatEntry), "(JJILcom/codedisaster/steamworks/SteamMatchmaking$ChatEntry;Ljava/nio/ByteBuffer;II)I");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamMatchmaking.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamMatchmaking>.Value);
        long num4 = obj0;
        long num5 = obj1;
        int num6 = obj2;
        IntPtr num7 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj3);
        IntPtr num8 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj4);
        int num9 = obj5;
        int num10 = obj6;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<int (IntPtr, IntPtr, long, long, int, IntPtr, IntPtr, int, int)>) SteamMatchmaking.__\u003Cjniptr\u003EgetLobbyChatEntry\u0028JJILcom\u002Fcodedisaster\u002Fsteamworks\u002FSteamMatchmaking\u0024ChatEntry\u003BLjava\u002Fnio\u002FByteBuffer\u003BII\u0029I)((int) num2, (int) num3, (IntPtr) num4, (IntPtr) num5, num6, (long) num7, (long) num8, (IntPtr) num9, (IntPtr) num10);
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
    private static bool requestLobbyData([In] long obj0, [In] long obj1)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamMatchmaking.__\u003Cjniptr\u003ErequestLobbyData\u0028JJ\u0029Z == IntPtr.Zero)
        SteamMatchmaking.__\u003Cjniptr\u003ErequestLobbyData\u0028JJ\u0029Z = JNI.Frame.GetFuncPtr(SteamMatchmaking.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamMatchmaking", nameof (requestLobbyData), "(JJ)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamMatchmaking.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamMatchmaking>.Value);
        long num4 = obj0;
        long num5 = obj1;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, long, long)>) SteamMatchmaking.__\u003Cjniptr\u003ErequestLobbyData\u0028JJ\u0029Z)((long) num2, (long) num3, (IntPtr) num4, (IntPtr) num5);
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
    private static void setLobbyGameServer([In] long obj0, [In] long obj1, [In] int obj2, [In] short obj3, [In] long obj4)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamMatchmaking.__\u003Cjniptr\u003EsetLobbyGameServer\u0028JJISJ\u0029V == IntPtr.Zero)
        SteamMatchmaking.__\u003Cjniptr\u003EsetLobbyGameServer\u0028JJISJ\u0029V = JNI.Frame.GetFuncPtr(SteamMatchmaking.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamMatchmaking", nameof (setLobbyGameServer), "(JJISJ)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamMatchmaking.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamMatchmaking>.Value);
        long num4 = obj0;
        long num5 = obj1;
        int num6 = obj2;
        int num7 = (int) obj3;
        long num8 = obj4;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, long, long, int, short, long)>) SteamMatchmaking.__\u003Cjniptr\u003EsetLobbyGameServer\u0028JJISJ\u0029V)((long) num2, (short) num3, (int) num4, num5, (long) num6, (IntPtr) num7, (IntPtr) num8);
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
    private static bool getLobbyGameServer(
      [In] long obj0,
      [In] long obj1,
      [In] int[] obj2,
      [In] short[] obj3,
      [In] long[] obj4)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamMatchmaking.__\u003Cjniptr\u003EgetLobbyGameServer\u0028JJ\u005BI\u005BS\u005BJ\u0029Z == IntPtr.Zero)
        SteamMatchmaking.__\u003Cjniptr\u003EgetLobbyGameServer\u0028JJ\u005BI\u005BS\u005BJ\u0029Z = JNI.Frame.GetFuncPtr(SteamMatchmaking.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamMatchmaking", nameof (getLobbyGameServer), "(JJ[I[S[J)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamMatchmaking.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamMatchmaking>.Value);
        long num4 = obj0;
        long num5 = obj1;
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj2);
        IntPtr num7 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj3);
        IntPtr num8 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj4);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, long, long, IntPtr, IntPtr, IntPtr)>) SteamMatchmaking.__\u003Cjniptr\u003EgetLobbyGameServer\u0028JJ\u005BI\u005BS\u005BJ\u0029Z)(num2, num3, (IntPtr) num4, num5, (long) num6, num7, num8);
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
    private static bool setLobbyMemberLimit([In] long obj0, [In] long obj1, [In] int obj2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamMatchmaking.__\u003Cjniptr\u003EsetLobbyMemberLimit\u0028JJI\u0029Z == IntPtr.Zero)
        SteamMatchmaking.__\u003Cjniptr\u003EsetLobbyMemberLimit\u0028JJI\u0029Z = JNI.Frame.GetFuncPtr(SteamMatchmaking.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamMatchmaking", nameof (setLobbyMemberLimit), "(JJI)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamMatchmaking.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamMatchmaking>.Value);
        long num4 = obj0;
        long num5 = obj1;
        int num6 = obj2;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, long, long, int)>) SteamMatchmaking.__\u003Cjniptr\u003EsetLobbyMemberLimit\u0028JJI\u0029Z)((int) num2, (long) num3, num4, (IntPtr) num5, (IntPtr) num6);
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
    private static int getLobbyMemberLimit([In] long obj0, [In] long obj1)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamMatchmaking.__\u003Cjniptr\u003EgetLobbyMemberLimit\u0028JJ\u0029I == IntPtr.Zero)
        SteamMatchmaking.__\u003Cjniptr\u003EgetLobbyMemberLimit\u0028JJ\u0029I = JNI.Frame.GetFuncPtr(SteamMatchmaking.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamMatchmaking", nameof (getLobbyMemberLimit), "(JJ)I");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamMatchmaking.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamMatchmaking>.Value);
        long num4 = obj0;
        long num5 = obj1;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<int (IntPtr, IntPtr, long, long)>) SteamMatchmaking.__\u003Cjniptr\u003EgetLobbyMemberLimit\u0028JJ\u0029I)((long) num2, (long) num3, (IntPtr) num4, (IntPtr) num5);
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
    private static bool setLobbyType([In] long obj0, [In] long obj1, [In] int obj2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamMatchmaking.__\u003Cjniptr\u003EsetLobbyType\u0028JJI\u0029Z == IntPtr.Zero)
        SteamMatchmaking.__\u003Cjniptr\u003EsetLobbyType\u0028JJI\u0029Z = JNI.Frame.GetFuncPtr(SteamMatchmaking.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamMatchmaking", nameof (setLobbyType), "(JJI)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamMatchmaking.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamMatchmaking>.Value);
        long num4 = obj0;
        long num5 = obj1;
        int num6 = obj2;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, long, long, int)>) SteamMatchmaking.__\u003Cjniptr\u003EsetLobbyType\u0028JJI\u0029Z)((int) num2, (long) num3, num4, (IntPtr) num5, (IntPtr) num6);
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
    private static bool setLobbyJoinable([In] long obj0, [In] long obj1, [In] bool obj2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamMatchmaking.__\u003Cjniptr\u003EsetLobbyJoinable\u0028JJZ\u0029Z == IntPtr.Zero)
        SteamMatchmaking.__\u003Cjniptr\u003EsetLobbyJoinable\u0028JJZ\u0029Z = JNI.Frame.GetFuncPtr(SteamMatchmaking.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamMatchmaking", nameof (setLobbyJoinable), "(JJZ)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamMatchmaking.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamMatchmaking>.Value);
        long num4 = obj0;
        long num5 = obj1;
        int num6 = obj2 ? 1 : 0;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, long, long, bool)>) SteamMatchmaking.__\u003Cjniptr\u003EsetLobbyJoinable\u0028JJZ\u0029Z)((bool) num2, (long) num3, num4, (IntPtr) num5, (IntPtr) num6);
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
    private static long getLobbyOwner([In] long obj0, [In] long obj1)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamMatchmaking.__\u003Cjniptr\u003EgetLobbyOwner\u0028JJ\u0029J == IntPtr.Zero)
        SteamMatchmaking.__\u003Cjniptr\u003EgetLobbyOwner\u0028JJ\u0029J = JNI.Frame.GetFuncPtr(SteamMatchmaking.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamMatchmaking", nameof (getLobbyOwner), "(JJ)J");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamMatchmaking.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamMatchmaking>.Value);
        long num4 = obj0;
        long num5 = obj1;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<long (IntPtr, IntPtr, long, long)>) SteamMatchmaking.__\u003Cjniptr\u003EgetLobbyOwner\u0028JJ\u0029J)((long) num2, (long) num3, (IntPtr) num4, (IntPtr) num5);
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
    private static bool setLobbyOwner([In] long obj0, [In] long obj1, [In] long obj2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamMatchmaking.__\u003Cjniptr\u003EsetLobbyOwner\u0028JJJ\u0029Z == IntPtr.Zero)
        SteamMatchmaking.__\u003Cjniptr\u003EsetLobbyOwner\u0028JJJ\u0029Z = JNI.Frame.GetFuncPtr(SteamMatchmaking.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamMatchmaking", nameof (setLobbyOwner), "(JJJ)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamMatchmaking.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamMatchmaking>.Value);
        long num4 = obj0;
        long num5 = obj1;
        long num6 = obj2;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, long, long, long)>) SteamMatchmaking.__\u003Cjniptr\u003EsetLobbyOwner\u0028JJJ\u0029Z)((long) num2, (long) num3, num4, (IntPtr) num5, (IntPtr) num6);
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
    private static bool setLinkedLobby([In] long obj0, [In] long obj1, [In] long obj2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamMatchmaking.__\u003Cjniptr\u003EsetLinkedLobby\u0028JJJ\u0029Z == IntPtr.Zero)
        SteamMatchmaking.__\u003Cjniptr\u003EsetLinkedLobby\u0028JJJ\u0029Z = JNI.Frame.GetFuncPtr(SteamMatchmaking.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamMatchmaking", nameof (setLinkedLobby), "(JJJ)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamMatchmaking.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamMatchmaking>.Value);
        long num4 = obj0;
        long num5 = obj1;
        long num6 = obj2;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, long, long, long)>) SteamMatchmaking.__\u003Cjniptr\u003EsetLinkedLobby\u0028JJJ\u0029Z)((long) num2, (long) num3, num4, (IntPtr) num5, (IntPtr) num6);
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

    [LineNumberTable(137)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getFavoriteGameCount() => SteamMatchmaking.getFavoriteGameCount(this.pointer);

    [LineNumberTable(142)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool getFavoriteGame(
      int game,
      int[] appID,
      int[] ip,
      short[] connPort,
      short[] queryPort,
      int[] flags,
      int[] lastPlayedOnServer)
    {
      return SteamMatchmaking.getFavoriteGame(this.pointer, game, appID, ip, connPort, queryPort, flags, lastPlayedOnServer);
    }

    [LineNumberTable(146)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int addFavoriteGame(
      int appID,
      int ip,
      short connPort,
      short queryPort,
      int flags,
      int lastPlayedOnServer)
    {
      int num1 = (int) connPort;
      int num2 = (int) queryPort;
      return SteamMatchmaking.addFavoriteGame(this.pointer, appID, ip, (short) num1, (short) num2, flags, lastPlayedOnServer);
    }

    [LineNumberTable(150)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool removeFavoriteGame(
      int appID,
      int ip,
      short connPort,
      short queryPort,
      int flags)
    {
      int num1 = (int) connPort;
      int num2 = (int) queryPort;
      return SteamMatchmaking.removeFavoriteGame(this.pointer, appID, ip, (short) num1, (short) num2, flags);
    }

    [LineNumberTable(new byte[] {110, 115})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addRequestLobbyListStringFilter(
      string keyToMatch,
      string valueToMatch,
      SteamMatchmaking.LobbyComparison comparisonType)
    {
      SteamMatchmaking.addRequestLobbyListStringFilter(this.pointer, keyToMatch, valueToMatch, SteamMatchmaking.LobbyComparison.access\u0024000(comparisonType));
    }

    [LineNumberTable(new byte[] {116, 115})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addRequestLobbyListNumericalFilter(
      string keyToMatch,
      int valueToMatch,
      SteamMatchmaking.LobbyComparison comparisonType)
    {
      SteamMatchmaking.addRequestLobbyListNumericalFilter(this.pointer, keyToMatch, valueToMatch, SteamMatchmaking.LobbyComparison.access\u0024000(comparisonType));
    }

    [LineNumberTable(new byte[] {120, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addRequestLobbyListNearValueFilter(string keyToMatch, int valueToBeCloseTo) => SteamMatchmaking.addRequestLobbyListNearValueFilter(this.pointer, keyToMatch, valueToBeCloseTo);

    [LineNumberTable(new byte[] {124, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addRequestLobbyListFilterSlotsAvailable(int slotsAvailable) => SteamMatchmaking.addRequestLobbyListFilterSlotsAvailable(this.pointer, slotsAvailable);

    [LineNumberTable(new byte[] {160, 64, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addRequestLobbyListDistanceFilter(
      SteamMatchmaking.LobbyDistanceFilter lobbyDistanceFilter)
    {
      SteamMatchmaking.addRequestLobbyListDistanceFilter(this.pointer, lobbyDistanceFilter.ordinal());
    }

    [LineNumberTable(new byte[] {160, 72, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addRequestLobbyListCompatibleMembersFilter(SteamID steamIDLobby) => SteamMatchmaking.addRequestLobbyListCompatibleMembersFilter(this.pointer, steamIDLobby.handle);

    [LineNumberTable(206)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool inviteUserToLobby(SteamID steamIDLobby, SteamID steamIDInvitee) => SteamMatchmaking.inviteUserToLobby(this.pointer, steamIDLobby.handle, steamIDInvitee.handle);

    [LineNumberTable(214)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual SteamID getLobbyMemberByIndex(SteamID steamIDLobby, int memberIndex)
    {
      SteamID.__\u003Cclinit\u003E();
      return new SteamID(SteamMatchmaking.getLobbyMemberByIndex(this.pointer, steamIDLobby.handle, memberIndex));
    }

    [LineNumberTable(226)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool setLobbyData(
      SteamID steamIDLobby,
      SteamMatchmakingKeyValuePair keyValuePair)
    {
      return SteamMatchmaking.setLobbyData(this.pointer, steamIDLobby.handle, keyValuePair.getKey(), keyValuePair.getValue());
    }

    [LineNumberTable(230)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string getLobbyMemberData(SteamID steamIDLobby, SteamID steamIDUser, string key) => SteamMatchmaking.getLobbyMemberData(this.pointer, steamIDLobby.handle, steamIDUser.handle, key);

    [LineNumberTable(new byte[] {160, 120, 115})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setLobbyMemberData(SteamID steamIDLobby, string key, string value) => SteamMatchmaking.setLobbyMemberData(this.pointer, steamIDLobby.handle, key, value);

    [LineNumberTable(new byte[] {160, 124, 125})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setLobbyMemberData(
      SteamID steamIDLobby,
      SteamMatchmakingKeyValuePair keyValuePair)
    {
      SteamMatchmaking.setLobbyMemberData(this.pointer, steamIDLobby.handle, keyValuePair.getKey(), keyValuePair.getValue());
    }

    [LineNumberTable(242)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getLobbyDataCount(SteamID steamIDLobby) => SteamMatchmaking.getLobbyDataCount(this.pointer, steamIDLobby.handle);

    [LineNumberTable(247)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool getLobbyDataByIndex(
      SteamID steamIDLobby,
      int lobbyDataIndex,
      SteamMatchmakingKeyValuePair keyValuePair)
    {
      return SteamMatchmaking.getLobbyDataByIndex(this.pointer, steamIDLobby.handle, lobbyDataIndex, keyValuePair);
    }

    [LineNumberTable(251)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool deleteLobbyData(SteamID steamIDLobby, string key) => SteamMatchmaking.deleteLobbyData(this.pointer, steamIDLobby.handle, key);

    [Throws(new string[] {"com.codedisaster.steamworks.SteamException"})]
    [LineNumberTable(new byte[] {160, 145, 104, 176})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool sendLobbyChatMsg(SteamID steamIDLobby, ByteBuffer data)
    {
      if (!data.isDirect())
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new SteamException("Direct buffer required!");
      }
      return SteamMatchmaking.sendLobbyChatMsg(this.pointer, steamIDLobby.handle, data, ((Buffer) data).position(), ((Buffer) data).remaining());
    }

    [LineNumberTable(267)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool sendLobbyChatMsg(SteamID steamIDLobby, string data) => SteamMatchmaking.sendLobbyChatMsg(this.pointer, steamIDLobby.handle, data);

    [Throws(new string[] {"com.codedisaster.steamworks.SteamException"})]
    [LineNumberTable(new byte[] {160, 163, 105, 176, 114, 44})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getLobbyChatEntry(
      SteamID steamIDLobby,
      int chatID,
      SteamMatchmaking.ChatEntry chatEntry,
      ByteBuffer dest)
    {
      if (!dest.isDirect())
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new SteamException("Direct buffer required!");
      }
      return SteamMatchmaking.getLobbyChatEntry(this.pointer, steamIDLobby.handle, chatID, chatEntry, dest, ((Buffer) dest).position(), ((Buffer) dest).remaining());
    }

    [LineNumberTable(286)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool requestLobbyData(SteamID steamIDLobby) => SteamMatchmaking.requestLobbyData(this.pointer, steamIDLobby.handle);

    [LineNumberTable(new byte[] {159, 70, 162, 122})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setLobbyGameServer(
      SteamID steamIDLobby,
      int gameServerIP,
      short gameServerPort,
      SteamID steamIDGameServer)
    {
      int num = (int) gameServerPort;
      SteamMatchmaking.setLobbyGameServer(this.pointer, steamIDLobby.handle, gameServerIP, (short) num, steamIDGameServer.handle);
    }

    [LineNumberTable(new byte[] {160, 182, 135, 118, 106, 162})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool getLobbyGameServer(
      SteamID steamIDLobby,
      int[] gameServerIP,
      short[] gameServerPort,
      SteamID steamIDGameServer)
    {
      long[] numArray = new long[1];
      if (!SteamMatchmaking.getLobbyGameServer(this.pointer, steamIDLobby.handle, gameServerIP, gameServerPort, numArray))
        return false;
      steamIDGameServer.handle = numArray[0];
      return true;
    }

    [LineNumberTable(319)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool setLobbyJoinable(SteamID steamIDLobby, bool joinable)
    {
      int num = joinable ? 1 : 0;
      return SteamMatchmaking.setLobbyJoinable(this.pointer, steamIDLobby.handle, num != 0);
    }

    [LineNumberTable(327)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool setLobbyOwner(SteamID steamIDLobby, SteamID steamIDNewOwner) => SteamMatchmaking.setLobbyOwner(this.pointer, steamIDLobby.handle, steamIDNewOwner.handle);

    [LineNumberTable(331)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool setLinkedLobby(SteamID steamIDLobby, SteamID steamIDLobbyDependent) => SteamMatchmaking.setLinkedLobby(this.pointer, steamIDLobby.handle, steamIDLobbyDependent.handle);

    [Modifiers]
    [LineNumberTable(5)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void dispose() => base.dispose();

    new static CallerID __\u003CGetCallerID\u003E()
    {
      if (SteamMatchmaking.__\u003CcallerID\u003E == null)
        SteamMatchmaking.__\u003CcallerID\u003E = (CallerID) new SteamMatchmaking.__\u003CCallerID\u003E();
      return SteamMatchmaking.__\u003CcallerID\u003E;
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

    public class ChatEntry : Object
    {
      private long steamIDUser;
      private int chatEntryType;

      [LineNumberTable(118)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public ChatEntry()
      {
      }

      [LineNumberTable(124)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual SteamID getSteamIDUser()
      {
        SteamID.__\u003Cclinit\u003E();
        return new SteamID(this.steamIDUser);
      }

      [LineNumberTable(128)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual SteamMatchmaking.ChatEntryType getChatEntryType() => SteamMatchmaking.ChatEntryType.byValue(this.chatEntryType);
    }

    [InnerClass]
    [Signature("Ljava/lang/Enum<Lcom/codedisaster/steamworks/SteamMatchmaking$ChatEntryType;>;")]
    [Modifiers]
    [Serializable]
    public sealed class ChatEntryType : Enum
    {
      [Modifiers]
      internal static SteamMatchmaking.ChatEntryType __\u003C\u003EInvalid;
      [Modifiers]
      internal static SteamMatchmaking.ChatEntryType __\u003C\u003EChatMsg;
      [Modifiers]
      internal static SteamMatchmaking.ChatEntryType __\u003C\u003ETyping;
      [Modifiers]
      internal static SteamMatchmaking.ChatEntryType __\u003C\u003EInviteGame;
      [Modifiers]
      internal static SteamMatchmaking.ChatEntryType __\u003C\u003EEmote;
      [Modifiers]
      internal static SteamMatchmaking.ChatEntryType __\u003C\u003ELeftConversation;
      [Modifiers]
      internal static SteamMatchmaking.ChatEntryType __\u003C\u003EEntered;
      [Modifiers]
      internal static SteamMatchmaking.ChatEntryType __\u003C\u003EWasKicked;
      [Modifiers]
      internal static SteamMatchmaking.ChatEntryType __\u003C\u003EWasBanned;
      [Modifiers]
      internal static SteamMatchmaking.ChatEntryType __\u003C\u003EDisconnected;
      [Modifiers]
      internal static SteamMatchmaking.ChatEntryType __\u003C\u003EHistoricalChat;
      [Modifiers]
      internal static SteamMatchmaking.ChatEntryType __\u003C\u003EReserved1;
      [Modifiers]
      internal static SteamMatchmaking.ChatEntryType __\u003C\u003EReserved2;
      [Modifiers]
      internal static SteamMatchmaking.ChatEntryType __\u003C\u003ELinkBlocked;
      [Modifiers]
      private int code;
      [Modifiers]
      private static SteamMatchmaking.ChatEntryType[] values;
      [Modifiers]
      private static SteamMatchmaking.ChatEntryType[] \u0024VALUES;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {59, 115, 105, 2, 230, 69})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal static SteamMatchmaking.ChatEntryType byValue([In] int obj0)
      {
        SteamMatchmaking.ChatEntryType[] values = SteamMatchmaking.ChatEntryType.values;
        int length = values.Length;
        for (int index = 0; index < length; ++index)
        {
          SteamMatchmaking.ChatEntryType chatEntryType = values[index];
          if (chatEntryType.code == obj0)
            return chatEntryType;
        }
        return SteamMatchmaking.ChatEntryType.__\u003C\u003EInvalid;
      }

      [Signature("(I)V")]
      [LineNumberTable(new byte[] {54, 106, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private ChatEntryType([In] string obj0, [In] int obj1, [In] int obj2)
        : base(obj0, obj1)
      {
        SteamMatchmaking.ChatEntryType chatEntryType = this;
        this.code = obj2;
        GC.KeepAlive((object) this);
      }

      [LineNumberTable(85)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static SteamMatchmaking.ChatEntryType[] values() => (SteamMatchmaking.ChatEntryType[]) SteamMatchmaking.ChatEntryType.\u0024VALUES.Clone();

      [LineNumberTable(85)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static SteamMatchmaking.ChatEntryType valueOf(string name) => (SteamMatchmaking.ChatEntryType) Enum.valueOf((Class) ClassLiteral<SteamMatchmaking.ChatEntryType>.Value, name);

      [LineNumberTable(new byte[] {159, 121, 141, 113, 113, 113, 113, 113, 113, 113, 113, 114, 115, 115, 115, 115, 243, 50, 255, 98, 81})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static ChatEntryType()
      {
        if (ByteCodeHelper.isAlreadyInited("com.codedisaster.steamworks.SteamMatchmaking$ChatEntryType"))
          return;
        SteamMatchmaking.ChatEntryType.__\u003C\u003EInvalid = new SteamMatchmaking.ChatEntryType(nameof (Invalid), 0, 0);
        SteamMatchmaking.ChatEntryType.__\u003C\u003EChatMsg = new SteamMatchmaking.ChatEntryType(nameof (ChatMsg), 1, 1);
        SteamMatchmaking.ChatEntryType.__\u003C\u003ETyping = new SteamMatchmaking.ChatEntryType(nameof (Typing), 2, 2);
        SteamMatchmaking.ChatEntryType.__\u003C\u003EInviteGame = new SteamMatchmaking.ChatEntryType(nameof (InviteGame), 3, 3);
        SteamMatchmaking.ChatEntryType.__\u003C\u003EEmote = new SteamMatchmaking.ChatEntryType(nameof (Emote), 4, 4);
        SteamMatchmaking.ChatEntryType.__\u003C\u003ELeftConversation = new SteamMatchmaking.ChatEntryType(nameof (LeftConversation), 5, 6);
        SteamMatchmaking.ChatEntryType.__\u003C\u003EEntered = new SteamMatchmaking.ChatEntryType(nameof (Entered), 6, 7);
        SteamMatchmaking.ChatEntryType.__\u003C\u003EWasKicked = new SteamMatchmaking.ChatEntryType(nameof (WasKicked), 7, 8);
        SteamMatchmaking.ChatEntryType.__\u003C\u003EWasBanned = new SteamMatchmaking.ChatEntryType(nameof (WasBanned), 8, 9);
        SteamMatchmaking.ChatEntryType.__\u003C\u003EDisconnected = new SteamMatchmaking.ChatEntryType(nameof (Disconnected), 9, 10);
        SteamMatchmaking.ChatEntryType.__\u003C\u003EHistoricalChat = new SteamMatchmaking.ChatEntryType(nameof (HistoricalChat), 10, 11);
        SteamMatchmaking.ChatEntryType.__\u003C\u003EReserved1 = new SteamMatchmaking.ChatEntryType(nameof (Reserved1), 11, 12);
        SteamMatchmaking.ChatEntryType.__\u003C\u003EReserved2 = new SteamMatchmaking.ChatEntryType(nameof (Reserved2), 12, 13);
        SteamMatchmaking.ChatEntryType.__\u003C\u003ELinkBlocked = new SteamMatchmaking.ChatEntryType(nameof (LinkBlocked), 13, 14);
        SteamMatchmaking.ChatEntryType.\u0024VALUES = new SteamMatchmaking.ChatEntryType[14]
        {
          SteamMatchmaking.ChatEntryType.__\u003C\u003EInvalid,
          SteamMatchmaking.ChatEntryType.__\u003C\u003EChatMsg,
          SteamMatchmaking.ChatEntryType.__\u003C\u003ETyping,
          SteamMatchmaking.ChatEntryType.__\u003C\u003EInviteGame,
          SteamMatchmaking.ChatEntryType.__\u003C\u003EEmote,
          SteamMatchmaking.ChatEntryType.__\u003C\u003ELeftConversation,
          SteamMatchmaking.ChatEntryType.__\u003C\u003EEntered,
          SteamMatchmaking.ChatEntryType.__\u003C\u003EWasKicked,
          SteamMatchmaking.ChatEntryType.__\u003C\u003EWasBanned,
          SteamMatchmaking.ChatEntryType.__\u003C\u003EDisconnected,
          SteamMatchmaking.ChatEntryType.__\u003C\u003EHistoricalChat,
          SteamMatchmaking.ChatEntryType.__\u003C\u003EReserved1,
          SteamMatchmaking.ChatEntryType.__\u003C\u003EReserved2,
          SteamMatchmaking.ChatEntryType.__\u003C\u003ELinkBlocked
        };
        SteamMatchmaking.ChatEntryType.values = SteamMatchmaking.ChatEntryType.values();
      }

      [Modifiers]
      public static SteamMatchmaking.ChatEntryType Invalid
      {
        [HideFromJava] get => SteamMatchmaking.ChatEntryType.__\u003C\u003EInvalid;
      }

      [Modifiers]
      public static SteamMatchmaking.ChatEntryType ChatMsg
      {
        [HideFromJava] get => SteamMatchmaking.ChatEntryType.__\u003C\u003EChatMsg;
      }

      [Modifiers]
      public static SteamMatchmaking.ChatEntryType Typing
      {
        [HideFromJava] get => SteamMatchmaking.ChatEntryType.__\u003C\u003ETyping;
      }

      [Modifiers]
      public static SteamMatchmaking.ChatEntryType InviteGame
      {
        [HideFromJava] get => SteamMatchmaking.ChatEntryType.__\u003C\u003EInviteGame;
      }

      [Modifiers]
      public static SteamMatchmaking.ChatEntryType Emote
      {
        [HideFromJava] get => SteamMatchmaking.ChatEntryType.__\u003C\u003EEmote;
      }

      [Modifiers]
      public static SteamMatchmaking.ChatEntryType LeftConversation
      {
        [HideFromJava] get => SteamMatchmaking.ChatEntryType.__\u003C\u003ELeftConversation;
      }

      [Modifiers]
      public static SteamMatchmaking.ChatEntryType Entered
      {
        [HideFromJava] get => SteamMatchmaking.ChatEntryType.__\u003C\u003EEntered;
      }

      [Modifiers]
      public static SteamMatchmaking.ChatEntryType WasKicked
      {
        [HideFromJava] get => SteamMatchmaking.ChatEntryType.__\u003C\u003EWasKicked;
      }

      [Modifiers]
      public static SteamMatchmaking.ChatEntryType WasBanned
      {
        [HideFromJava] get => SteamMatchmaking.ChatEntryType.__\u003C\u003EWasBanned;
      }

      [Modifiers]
      public static SteamMatchmaking.ChatEntryType Disconnected
      {
        [HideFromJava] get => SteamMatchmaking.ChatEntryType.__\u003C\u003EDisconnected;
      }

      [Modifiers]
      public static SteamMatchmaking.ChatEntryType HistoricalChat
      {
        [HideFromJava] get => SteamMatchmaking.ChatEntryType.__\u003C\u003EHistoricalChat;
      }

      [Modifiers]
      public static SteamMatchmaking.ChatEntryType Reserved1
      {
        [HideFromJava] get => SteamMatchmaking.ChatEntryType.__\u003C\u003EReserved1;
      }

      [Modifiers]
      public static SteamMatchmaking.ChatEntryType Reserved2
      {
        [HideFromJava] get => SteamMatchmaking.ChatEntryType.__\u003C\u003EReserved2;
      }

      [Modifiers]
      public static SteamMatchmaking.ChatEntryType LinkBlocked
      {
        [HideFromJava] get => SteamMatchmaking.ChatEntryType.__\u003C\u003ELinkBlocked;
      }

      [HideFromJava]
      [Serializable]
      public enum __Enum
      {
        Invalid,
        ChatMsg,
        Typing,
        InviteGame,
        Emote,
        LeftConversation,
        Entered,
        WasKicked,
        WasBanned,
        Disconnected,
        HistoricalChat,
        Reserved1,
        Reserved2,
        LinkBlocked,
      }
    }

    [InnerClass]
    [Signature("Ljava/lang/Enum<Lcom/codedisaster/steamworks/SteamMatchmaking$ChatMemberStateChange;>;")]
    [Modifiers]
    [Serializable]
    public sealed class ChatMemberStateChange : Enum
    {
      [Modifiers]
      internal static SteamMatchmaking.ChatMemberStateChange __\u003C\u003EEntered;
      [Modifiers]
      internal static SteamMatchmaking.ChatMemberStateChange __\u003C\u003ELeft;
      [Modifiers]
      internal static SteamMatchmaking.ChatMemberStateChange __\u003C\u003EDisconnected;
      [Modifiers]
      internal static SteamMatchmaking.ChatMemberStateChange __\u003C\u003EKicked;
      [Modifiers]
      internal static SteamMatchmaking.ChatMemberStateChange __\u003C\u003EBanned;
      [Modifiers]
      private int bits;
      [Modifiers]
      private static SteamMatchmaking.ChatMemberStateChange[] \u0024VALUES;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [Signature("(I)V")]
      [LineNumberTable(new byte[] {26, 106, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private ChatMemberStateChange([In] string obj0, [In] int obj1, [In] int obj2)
        : base(obj0, obj1)
      {
        SteamMatchmaking.ChatMemberStateChange memberStateChange = this;
        this.bits = obj2;
        GC.KeepAlive((object) this);
      }

      [LineNumberTable(67)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static SteamMatchmaking.ChatMemberStateChange[] values() => (SteamMatchmaking.ChatMemberStateChange[]) SteamMatchmaking.ChatMemberStateChange.\u0024VALUES.Clone();

      [LineNumberTable(67)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static SteamMatchmaking.ChatMemberStateChange valueOf(string name) => (SteamMatchmaking.ChatMemberStateChange) Enum.valueOf((Class) ClassLiteral<SteamMatchmaking.ChatMemberStateChange>.Value, name);

      [LineNumberTable(81)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal static bool isSet([In] SteamMatchmaking.ChatMemberStateChange obj0, [In] int obj1) => (obj0.bits & obj1) == obj0.bits;

      [LineNumberTable(new byte[] {159, 125, 77, 113, 113, 113, 113, 242, 59})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static ChatMemberStateChange()
      {
        if (ByteCodeHelper.isAlreadyInited("com.codedisaster.steamworks.SteamMatchmaking$ChatMemberStateChange"))
          return;
        SteamMatchmaking.ChatMemberStateChange.__\u003C\u003EEntered = new SteamMatchmaking.ChatMemberStateChange(nameof (Entered), 0, 1);
        SteamMatchmaking.ChatMemberStateChange.__\u003C\u003ELeft = new SteamMatchmaking.ChatMemberStateChange(nameof (Left), 1, 2);
        SteamMatchmaking.ChatMemberStateChange.__\u003C\u003EDisconnected = new SteamMatchmaking.ChatMemberStateChange(nameof (Disconnected), 2, 4);
        SteamMatchmaking.ChatMemberStateChange.__\u003C\u003EKicked = new SteamMatchmaking.ChatMemberStateChange(nameof (Kicked), 3, 8);
        SteamMatchmaking.ChatMemberStateChange.__\u003C\u003EBanned = new SteamMatchmaking.ChatMemberStateChange(nameof (Banned), 4, 16);
        SteamMatchmaking.ChatMemberStateChange.\u0024VALUES = new SteamMatchmaking.ChatMemberStateChange[5]
        {
          SteamMatchmaking.ChatMemberStateChange.__\u003C\u003EEntered,
          SteamMatchmaking.ChatMemberStateChange.__\u003C\u003ELeft,
          SteamMatchmaking.ChatMemberStateChange.__\u003C\u003EDisconnected,
          SteamMatchmaking.ChatMemberStateChange.__\u003C\u003EKicked,
          SteamMatchmaking.ChatMemberStateChange.__\u003C\u003EBanned
        };
      }

      [Modifiers]
      public static SteamMatchmaking.ChatMemberStateChange Entered
      {
        [HideFromJava] get => SteamMatchmaking.ChatMemberStateChange.__\u003C\u003EEntered;
      }

      [Modifiers]
      public static SteamMatchmaking.ChatMemberStateChange Left
      {
        [HideFromJava] get => SteamMatchmaking.ChatMemberStateChange.__\u003C\u003ELeft;
      }

      [Modifiers]
      public static SteamMatchmaking.ChatMemberStateChange Disconnected
      {
        [HideFromJava] get => SteamMatchmaking.ChatMemberStateChange.__\u003C\u003EDisconnected;
      }

      [Modifiers]
      public static SteamMatchmaking.ChatMemberStateChange Kicked
      {
        [HideFromJava] get => SteamMatchmaking.ChatMemberStateChange.__\u003C\u003EKicked;
      }

      [Modifiers]
      public static SteamMatchmaking.ChatMemberStateChange Banned
      {
        [HideFromJava] get => SteamMatchmaking.ChatMemberStateChange.__\u003C\u003EBanned;
      }

      [HideFromJava]
      [Serializable]
      public enum __Enum
      {
        Entered,
        Left,
        Disconnected,
        Kicked,
        Banned,
      }
    }

    [InnerClass]
    [Signature("Ljava/lang/Enum<Lcom/codedisaster/steamworks/SteamMatchmaking$ChatRoomEnterResponse;>;")]
    [Modifiers]
    [Serializable]
    public sealed class ChatRoomEnterResponse : Enum
    {
      [Modifiers]
      internal static SteamMatchmaking.ChatRoomEnterResponse __\u003C\u003ESuccess;
      [Modifiers]
      internal static SteamMatchmaking.ChatRoomEnterResponse __\u003C\u003EDoesntExist;
      [Modifiers]
      internal static SteamMatchmaking.ChatRoomEnterResponse __\u003C\u003ENotAllowed;
      [Modifiers]
      internal static SteamMatchmaking.ChatRoomEnterResponse __\u003C\u003EFull;
      [Modifiers]
      internal static SteamMatchmaking.ChatRoomEnterResponse __\u003C\u003EError;
      [Modifiers]
      internal static SteamMatchmaking.ChatRoomEnterResponse __\u003C\u003EBanned;
      [Modifiers]
      internal static SteamMatchmaking.ChatRoomEnterResponse __\u003C\u003ELimited;
      [Modifiers]
      internal static SteamMatchmaking.ChatRoomEnterResponse __\u003C\u003EClanDisabled;
      [Modifiers]
      internal static SteamMatchmaking.ChatRoomEnterResponse __\u003C\u003ECommunityBan;
      [Modifiers]
      internal static SteamMatchmaking.ChatRoomEnterResponse __\u003C\u003EMemberBlockedYou;
      [Modifiers]
      internal static SteamMatchmaking.ChatRoomEnterResponse __\u003C\u003EYouBlockedMember;
      [Modifiers]
      internal static SteamMatchmaking.ChatRoomEnterResponse __\u003C\u003ERatelimitExceeded;
      [Modifiers]
      private int code;
      [Modifiers]
      private static SteamMatchmaking.ChatRoomEnterResponse[] values;
      [Modifiers]
      private static SteamMatchmaking.ChatRoomEnterResponse[] \u0024VALUES;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [Signature("(I)V")]
      [LineNumberTable(new byte[] {3, 106, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private ChatRoomEnterResponse([In] string obj0, [In] int obj1, [In] int obj2)
        : base(obj0, obj1)
      {
        SteamMatchmaking.ChatRoomEnterResponse roomEnterResponse = this;
        this.code = obj2;
        GC.KeepAlive((object) this);
      }

      [LineNumberTable(36)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static SteamMatchmaking.ChatRoomEnterResponse[] values() => (SteamMatchmaking.ChatRoomEnterResponse[]) SteamMatchmaking.ChatRoomEnterResponse.\u0024VALUES.Clone();

      [LineNumberTable(36)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static SteamMatchmaking.ChatRoomEnterResponse valueOf(string name) => (SteamMatchmaking.ChatRoomEnterResponse) Enum.valueOf((Class) ClassLiteral<SteamMatchmaking.ChatRoomEnterResponse>.Value, name);

      [LineNumberTable(new byte[] {8, 115, 105, 2, 230, 69})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal static SteamMatchmaking.ChatRoomEnterResponse byValue([In] int obj0)
      {
        SteamMatchmaking.ChatRoomEnterResponse[] values = SteamMatchmaking.ChatRoomEnterResponse.values;
        int length = values.Length;
        for (int index = 0; index < length; ++index)
        {
          SteamMatchmaking.ChatRoomEnterResponse roomEnterResponse = values[index];
          if (roomEnterResponse.code == obj0)
            return roomEnterResponse;
        }
        return SteamMatchmaking.ChatRoomEnterResponse.__\u003C\u003EError;
      }

      [LineNumberTable(new byte[] {159, 133, 109, 113, 113, 113, 113, 113, 113, 113, 113, 114, 115, 115, 243, 52, 255, 80, 79})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static ChatRoomEnterResponse()
      {
        if (ByteCodeHelper.isAlreadyInited("com.codedisaster.steamworks.SteamMatchmaking$ChatRoomEnterResponse"))
          return;
        SteamMatchmaking.ChatRoomEnterResponse.__\u003C\u003ESuccess = new SteamMatchmaking.ChatRoomEnterResponse(nameof (Success), 0, 1);
        SteamMatchmaking.ChatRoomEnterResponse.__\u003C\u003EDoesntExist = new SteamMatchmaking.ChatRoomEnterResponse(nameof (DoesntExist), 1, 2);
        SteamMatchmaking.ChatRoomEnterResponse.__\u003C\u003ENotAllowed = new SteamMatchmaking.ChatRoomEnterResponse(nameof (NotAllowed), 2, 3);
        SteamMatchmaking.ChatRoomEnterResponse.__\u003C\u003EFull = new SteamMatchmaking.ChatRoomEnterResponse(nameof (Full), 3, 4);
        SteamMatchmaking.ChatRoomEnterResponse.__\u003C\u003EError = new SteamMatchmaking.ChatRoomEnterResponse(nameof (Error), 4, 5);
        SteamMatchmaking.ChatRoomEnterResponse.__\u003C\u003EBanned = new SteamMatchmaking.ChatRoomEnterResponse(nameof (Banned), 5, 6);
        SteamMatchmaking.ChatRoomEnterResponse.__\u003C\u003ELimited = new SteamMatchmaking.ChatRoomEnterResponse(nameof (Limited), 6, 7);
        SteamMatchmaking.ChatRoomEnterResponse.__\u003C\u003EClanDisabled = new SteamMatchmaking.ChatRoomEnterResponse(nameof (ClanDisabled), 7, 8);
        SteamMatchmaking.ChatRoomEnterResponse.__\u003C\u003ECommunityBan = new SteamMatchmaking.ChatRoomEnterResponse(nameof (CommunityBan), 8, 9);
        SteamMatchmaking.ChatRoomEnterResponse.__\u003C\u003EMemberBlockedYou = new SteamMatchmaking.ChatRoomEnterResponse(nameof (MemberBlockedYou), 9, 10);
        SteamMatchmaking.ChatRoomEnterResponse.__\u003C\u003EYouBlockedMember = new SteamMatchmaking.ChatRoomEnterResponse(nameof (YouBlockedMember), 10, 11);
        SteamMatchmaking.ChatRoomEnterResponse.__\u003C\u003ERatelimitExceeded = new SteamMatchmaking.ChatRoomEnterResponse(nameof (RatelimitExceeded), 11, 15);
        SteamMatchmaking.ChatRoomEnterResponse.\u0024VALUES = new SteamMatchmaking.ChatRoomEnterResponse[12]
        {
          SteamMatchmaking.ChatRoomEnterResponse.__\u003C\u003ESuccess,
          SteamMatchmaking.ChatRoomEnterResponse.__\u003C\u003EDoesntExist,
          SteamMatchmaking.ChatRoomEnterResponse.__\u003C\u003ENotAllowed,
          SteamMatchmaking.ChatRoomEnterResponse.__\u003C\u003EFull,
          SteamMatchmaking.ChatRoomEnterResponse.__\u003C\u003EError,
          SteamMatchmaking.ChatRoomEnterResponse.__\u003C\u003EBanned,
          SteamMatchmaking.ChatRoomEnterResponse.__\u003C\u003ELimited,
          SteamMatchmaking.ChatRoomEnterResponse.__\u003C\u003EClanDisabled,
          SteamMatchmaking.ChatRoomEnterResponse.__\u003C\u003ECommunityBan,
          SteamMatchmaking.ChatRoomEnterResponse.__\u003C\u003EMemberBlockedYou,
          SteamMatchmaking.ChatRoomEnterResponse.__\u003C\u003EYouBlockedMember,
          SteamMatchmaking.ChatRoomEnterResponse.__\u003C\u003ERatelimitExceeded
        };
        SteamMatchmaking.ChatRoomEnterResponse.values = SteamMatchmaking.ChatRoomEnterResponse.values();
      }

      [Modifiers]
      public static SteamMatchmaking.ChatRoomEnterResponse Success
      {
        [HideFromJava] get => SteamMatchmaking.ChatRoomEnterResponse.__\u003C\u003ESuccess;
      }

      [Modifiers]
      public static SteamMatchmaking.ChatRoomEnterResponse DoesntExist
      {
        [HideFromJava] get => SteamMatchmaking.ChatRoomEnterResponse.__\u003C\u003EDoesntExist;
      }

      [Modifiers]
      public static SteamMatchmaking.ChatRoomEnterResponse NotAllowed
      {
        [HideFromJava] get => SteamMatchmaking.ChatRoomEnterResponse.__\u003C\u003ENotAllowed;
      }

      [Modifiers]
      public static SteamMatchmaking.ChatRoomEnterResponse Full
      {
        [HideFromJava] get => SteamMatchmaking.ChatRoomEnterResponse.__\u003C\u003EFull;
      }

      [Modifiers]
      public static SteamMatchmaking.ChatRoomEnterResponse Error
      {
        [HideFromJava] get => SteamMatchmaking.ChatRoomEnterResponse.__\u003C\u003EError;
      }

      [Modifiers]
      public static SteamMatchmaking.ChatRoomEnterResponse Banned
      {
        [HideFromJava] get => SteamMatchmaking.ChatRoomEnterResponse.__\u003C\u003EBanned;
      }

      [Modifiers]
      public static SteamMatchmaking.ChatRoomEnterResponse Limited
      {
        [HideFromJava] get => SteamMatchmaking.ChatRoomEnterResponse.__\u003C\u003ELimited;
      }

      [Modifiers]
      public static SteamMatchmaking.ChatRoomEnterResponse ClanDisabled
      {
        [HideFromJava] get => SteamMatchmaking.ChatRoomEnterResponse.__\u003C\u003EClanDisabled;
      }

      [Modifiers]
      public static SteamMatchmaking.ChatRoomEnterResponse CommunityBan
      {
        [HideFromJava] get => SteamMatchmaking.ChatRoomEnterResponse.__\u003C\u003ECommunityBan;
      }

      [Modifiers]
      public static SteamMatchmaking.ChatRoomEnterResponse MemberBlockedYou
      {
        [HideFromJava] get => SteamMatchmaking.ChatRoomEnterResponse.__\u003C\u003EMemberBlockedYou;
      }

      [Modifiers]
      public static SteamMatchmaking.ChatRoomEnterResponse YouBlockedMember
      {
        [HideFromJava] get => SteamMatchmaking.ChatRoomEnterResponse.__\u003C\u003EYouBlockedMember;
      }

      [Modifiers]
      public static SteamMatchmaking.ChatRoomEnterResponse RatelimitExceeded
      {
        [HideFromJava] get => SteamMatchmaking.ChatRoomEnterResponse.__\u003C\u003ERatelimitExceeded;
      }

      [HideFromJava]
      [Serializable]
      public enum __Enum
      {
        Success,
        DoesntExist,
        NotAllowed,
        Full,
        Error,
        Banned,
        Limited,
        ClanDisabled,
        CommunityBan,
        MemberBlockedYou,
        YouBlockedMember,
        RatelimitExceeded,
      }
    }

    [InnerClass]
    [Signature("Ljava/lang/Enum<Lcom/codedisaster/steamworks/SteamMatchmaking$LobbyComparison;>;")]
    [Modifiers]
    [Serializable]
    public sealed class LobbyComparison : Enum
    {
      [Modifiers]
      internal static SteamMatchmaking.LobbyComparison __\u003C\u003EEqualToOrLessThan;
      [Modifiers]
      internal static SteamMatchmaking.LobbyComparison __\u003C\u003ELessThan;
      [Modifiers]
      internal static SteamMatchmaking.LobbyComparison __\u003C\u003EEqual;
      [Modifiers]
      internal static SteamMatchmaking.LobbyComparison __\u003C\u003EGreaterThan;
      [Modifiers]
      internal static SteamMatchmaking.LobbyComparison __\u003C\u003EEqualToOrGreaterThan;
      [Modifiers]
      internal static SteamMatchmaking.LobbyComparison __\u003C\u003ENotEqual;
      [Modifiers]
      private int value;
      [Modifiers]
      private static SteamMatchmaking.LobbyComparison[] \u0024VALUES;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [Modifiers]
      [LineNumberTable(14)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal static int access\u0024000([In] SteamMatchmaking.LobbyComparison obj0) => obj0.value;

      [Signature("(I)V")]
      [LineNumberTable(new byte[] {159, 166, 106, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private LobbyComparison([In] string obj0, [In] int obj1, [In] int obj2)
        : base(obj0, obj1)
      {
        SteamMatchmaking.LobbyComparison lobbyComparison = this;
        this.value = obj2;
        GC.KeepAlive((object) this);
      }

      [LineNumberTable(14)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static SteamMatchmaking.LobbyComparison[] values() => (SteamMatchmaking.LobbyComparison[]) SteamMatchmaking.LobbyComparison.\u0024VALUES.Clone();

      [LineNumberTable(14)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static SteamMatchmaking.LobbyComparison valueOf(string name) => (SteamMatchmaking.LobbyComparison) Enum.valueOf((Class) ClassLiteral<SteamMatchmaking.LobbyComparison>.Value, name);

      [LineNumberTable(new byte[] {159, 139, 173, 114, 113, 113, 113, 113, 241, 58})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static LobbyComparison()
      {
        if (ByteCodeHelper.isAlreadyInited("com.codedisaster.steamworks.SteamMatchmaking$LobbyComparison"))
          return;
        SteamMatchmaking.LobbyComparison.__\u003C\u003EEqualToOrLessThan = new SteamMatchmaking.LobbyComparison(nameof (EqualToOrLessThan), 0, -2);
        SteamMatchmaking.LobbyComparison.__\u003C\u003ELessThan = new SteamMatchmaking.LobbyComparison(nameof (LessThan), 1, -1);
        SteamMatchmaking.LobbyComparison.__\u003C\u003EEqual = new SteamMatchmaking.LobbyComparison(nameof (Equal), 2, 0);
        SteamMatchmaking.LobbyComparison.__\u003C\u003EGreaterThan = new SteamMatchmaking.LobbyComparison(nameof (GreaterThan), 3, 1);
        SteamMatchmaking.LobbyComparison.__\u003C\u003EEqualToOrGreaterThan = new SteamMatchmaking.LobbyComparison(nameof (EqualToOrGreaterThan), 4, 2);
        SteamMatchmaking.LobbyComparison.__\u003C\u003ENotEqual = new SteamMatchmaking.LobbyComparison(nameof (NotEqual), 5, 3);
        SteamMatchmaking.LobbyComparison.\u0024VALUES = new SteamMatchmaking.LobbyComparison[6]
        {
          SteamMatchmaking.LobbyComparison.__\u003C\u003EEqualToOrLessThan,
          SteamMatchmaking.LobbyComparison.__\u003C\u003ELessThan,
          SteamMatchmaking.LobbyComparison.__\u003C\u003EEqual,
          SteamMatchmaking.LobbyComparison.__\u003C\u003EGreaterThan,
          SteamMatchmaking.LobbyComparison.__\u003C\u003EEqualToOrGreaterThan,
          SteamMatchmaking.LobbyComparison.__\u003C\u003ENotEqual
        };
      }

      [Modifiers]
      public static SteamMatchmaking.LobbyComparison EqualToOrLessThan
      {
        [HideFromJava] get => SteamMatchmaking.LobbyComparison.__\u003C\u003EEqualToOrLessThan;
      }

      [Modifiers]
      public static SteamMatchmaking.LobbyComparison LessThan
      {
        [HideFromJava] get => SteamMatchmaking.LobbyComparison.__\u003C\u003ELessThan;
      }

      [Modifiers]
      public static SteamMatchmaking.LobbyComparison Equal
      {
        [HideFromJava] get => SteamMatchmaking.LobbyComparison.__\u003C\u003EEqual;
      }

      [Modifiers]
      public static SteamMatchmaking.LobbyComparison GreaterThan
      {
        [HideFromJava] get => SteamMatchmaking.LobbyComparison.__\u003C\u003EGreaterThan;
      }

      [Modifiers]
      public static SteamMatchmaking.LobbyComparison EqualToOrGreaterThan
      {
        [HideFromJava] get => SteamMatchmaking.LobbyComparison.__\u003C\u003EEqualToOrGreaterThan;
      }

      [Modifiers]
      public static SteamMatchmaking.LobbyComparison NotEqual
      {
        [HideFromJava] get => SteamMatchmaking.LobbyComparison.__\u003C\u003ENotEqual;
      }

      [HideFromJava]
      [Serializable]
      public enum __Enum
      {
        EqualToOrLessThan,
        LessThan,
        Equal,
        GreaterThan,
        EqualToOrGreaterThan,
        NotEqual,
      }
    }

    [InnerClass]
    [Signature("Ljava/lang/Enum<Lcom/codedisaster/steamworks/SteamMatchmaking$LobbyDistanceFilter;>;")]
    [Modifiers]
    [Serializable]
    public sealed class LobbyDistanceFilter : Enum
    {
      [Modifiers]
      internal static SteamMatchmaking.LobbyDistanceFilter __\u003C\u003EClose;
      [Modifiers]
      internal static SteamMatchmaking.LobbyDistanceFilter __\u003C\u003EDefault;
      [Modifiers]
      internal static SteamMatchmaking.LobbyDistanceFilter __\u003C\u003EFar;
      [Modifiers]
      internal static SteamMatchmaking.LobbyDistanceFilter __\u003C\u003EWorldwide;
      [Modifiers]
      private static SteamMatchmaking.LobbyDistanceFilter[] \u0024VALUES;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [Signature("()V")]
      [LineNumberTable(29)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private LobbyDistanceFilter([In] string obj0, [In] int obj1)
        : base(obj0, obj1)
      {
        GC.KeepAlive((object) this);
      }

      [LineNumberTable(29)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static SteamMatchmaking.LobbyDistanceFilter[] values() => (SteamMatchmaking.LobbyDistanceFilter[]) SteamMatchmaking.LobbyDistanceFilter.\u0024VALUES.Clone();

      [LineNumberTable(29)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static SteamMatchmaking.LobbyDistanceFilter valueOf(string name) => (SteamMatchmaking.LobbyDistanceFilter) Enum.valueOf((Class) ClassLiteral<SteamMatchmaking.LobbyDistanceFilter>.Value, name);

      [LineNumberTable(new byte[] {159, 135, 141, 112, 112, 112, 240, 60})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static LobbyDistanceFilter()
      {
        if (ByteCodeHelper.isAlreadyInited("com.codedisaster.steamworks.SteamMatchmaking$LobbyDistanceFilter"))
          return;
        SteamMatchmaking.LobbyDistanceFilter.__\u003C\u003EClose = new SteamMatchmaking.LobbyDistanceFilter(nameof (Close), 0);
        SteamMatchmaking.LobbyDistanceFilter.__\u003C\u003EDefault = new SteamMatchmaking.LobbyDistanceFilter(nameof (Default), 1);
        SteamMatchmaking.LobbyDistanceFilter.__\u003C\u003EFar = new SteamMatchmaking.LobbyDistanceFilter(nameof (Far), 2);
        SteamMatchmaking.LobbyDistanceFilter.__\u003C\u003EWorldwide = new SteamMatchmaking.LobbyDistanceFilter(nameof (Worldwide), 3);
        SteamMatchmaking.LobbyDistanceFilter.\u0024VALUES = new SteamMatchmaking.LobbyDistanceFilter[4]
        {
          SteamMatchmaking.LobbyDistanceFilter.__\u003C\u003EClose,
          SteamMatchmaking.LobbyDistanceFilter.__\u003C\u003EDefault,
          SteamMatchmaking.LobbyDistanceFilter.__\u003C\u003EFar,
          SteamMatchmaking.LobbyDistanceFilter.__\u003C\u003EWorldwide
        };
      }

      [Modifiers]
      public static SteamMatchmaking.LobbyDistanceFilter Close
      {
        [HideFromJava] get => SteamMatchmaking.LobbyDistanceFilter.__\u003C\u003EClose;
      }

      [Modifiers]
      public static SteamMatchmaking.LobbyDistanceFilter Default
      {
        [HideFromJava] get => SteamMatchmaking.LobbyDistanceFilter.__\u003C\u003EDefault;
      }

      [Modifiers]
      public static SteamMatchmaking.LobbyDistanceFilter Far
      {
        [HideFromJava] get => SteamMatchmaking.LobbyDistanceFilter.__\u003C\u003EFar;
      }

      [Modifiers]
      public static SteamMatchmaking.LobbyDistanceFilter Worldwide
      {
        [HideFromJava] get => SteamMatchmaking.LobbyDistanceFilter.__\u003C\u003EWorldwide;
      }

      [HideFromJava]
      [Serializable]
      public enum __Enum
      {
        Close,
        Default,
        Far,
        Worldwide,
      }
    }

    [InnerClass]
    [Signature("Ljava/lang/Enum<Lcom/codedisaster/steamworks/SteamMatchmaking$LobbyType;>;")]
    [Modifiers]
    [Serializable]
    public sealed class LobbyType : Enum
    {
      [Modifiers]
      internal static SteamMatchmaking.LobbyType __\u003C\u003EPrivate;
      [Modifiers]
      internal static SteamMatchmaking.LobbyType __\u003C\u003EFriendsOnly;
      [Modifiers]
      internal static SteamMatchmaking.LobbyType __\u003C\u003EPublic;
      [Modifiers]
      internal static SteamMatchmaking.LobbyType __\u003C\u003EInvisible;
      [Modifiers]
      private static SteamMatchmaking.LobbyType[] \u0024VALUES;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [Signature("()V")]
      [LineNumberTable(7)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private LobbyType([In] string obj0, [In] int obj1)
        : base(obj0, obj1)
      {
        GC.KeepAlive((object) this);
      }

      [LineNumberTable(7)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static SteamMatchmaking.LobbyType[] values() => (SteamMatchmaking.LobbyType[]) SteamMatchmaking.LobbyType.\u0024VALUES.Clone();

      [LineNumberTable(7)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static SteamMatchmaking.LobbyType valueOf(string name) => (SteamMatchmaking.LobbyType) Enum.valueOf((Class) ClassLiteral<SteamMatchmaking.LobbyType>.Value, name);

      [LineNumberTable(new byte[] {159, 140, 77, 112, 112, 112, 240, 60})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static LobbyType()
      {
        if (ByteCodeHelper.isAlreadyInited("com.codedisaster.steamworks.SteamMatchmaking$LobbyType"))
          return;
        SteamMatchmaking.LobbyType.__\u003C\u003EPrivate = new SteamMatchmaking.LobbyType(nameof (Private), 0);
        SteamMatchmaking.LobbyType.__\u003C\u003EFriendsOnly = new SteamMatchmaking.LobbyType(nameof (FriendsOnly), 1);
        SteamMatchmaking.LobbyType.__\u003C\u003EPublic = new SteamMatchmaking.LobbyType(nameof (Public), 2);
        SteamMatchmaking.LobbyType.__\u003C\u003EInvisible = new SteamMatchmaking.LobbyType(nameof (Invisible), 3);
        SteamMatchmaking.LobbyType.\u0024VALUES = new SteamMatchmaking.LobbyType[4]
        {
          SteamMatchmaking.LobbyType.__\u003C\u003EPrivate,
          SteamMatchmaking.LobbyType.__\u003C\u003EFriendsOnly,
          SteamMatchmaking.LobbyType.__\u003C\u003EPublic,
          SteamMatchmaking.LobbyType.__\u003C\u003EInvisible
        };
      }

      [Modifiers]
      public static SteamMatchmaking.LobbyType Private
      {
        [HideFromJava] get => SteamMatchmaking.LobbyType.__\u003C\u003EPrivate;
      }

      [Modifiers]
      public static SteamMatchmaking.LobbyType FriendsOnly
      {
        [HideFromJava] get => SteamMatchmaking.LobbyType.__\u003C\u003EFriendsOnly;
      }

      [Modifiers]
      public static SteamMatchmaking.LobbyType Public
      {
        [HideFromJava] get => SteamMatchmaking.LobbyType.__\u003C\u003EPublic;
      }

      [Modifiers]
      public static SteamMatchmaking.LobbyType Invisible
      {
        [HideFromJava] get => SteamMatchmaking.LobbyType.__\u003C\u003EInvisible;
      }

      [HideFromJava]
      [Serializable]
      public enum __Enum
      {
        Private,
        FriendsOnly,
        Public,
        Invisible,
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
