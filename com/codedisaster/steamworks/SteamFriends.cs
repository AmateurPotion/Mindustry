// Decompiled with JetBrains decompiler
// Type: com.codedisaster.steamworks.SteamFriends
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
  public class SteamFriends : SteamInterface
  {
    static IntPtr __\u003Cjniptr\u003EcreateCallback\u0028Lcom\u002Fcodedisaster\u002Fsteamworks\u002FSteamFriendsCallbackAdapter\u003B\u0029J;
    [SpecialName]
    private static CallerID __\u003CcallerID\u003E;
    static IntPtr __\u003Cjniptr\u003EgetPersonaName\u0028J\u0029Ljava\u002Flang\u002FString\u003B;
    static IntPtr __\u003Cjniptr\u003EsetPersonaName\u0028JJLjava\u002Flang\u002FString\u003B\u0029J;
    static IntPtr __\u003Cjniptr\u003EgetPersonaState\u0028J\u0029I;
    static IntPtr __\u003Cjniptr\u003EgetFriendCount\u0028JI\u0029I;
    static IntPtr __\u003Cjniptr\u003EgetFriendByIndex\u0028JII\u0029J;
    static IntPtr __\u003Cjniptr\u003EgetFriendRelationship\u0028JJ\u0029I;
    static IntPtr __\u003Cjniptr\u003EgetFriendPersonaState\u0028JJ\u0029I;
    static IntPtr __\u003Cjniptr\u003EgetFriendPersonaName\u0028JJ\u0029Ljava\u002Flang\u002FString\u003B;
    static IntPtr __\u003Cjniptr\u003EgetFriendGamePlayed\u0028JJLcom\u002Fcodedisaster\u002Fsteamworks\u002FSteamFriends\u0024FriendGameInfo\u003B\u0029Z;
    static IntPtr __\u003Cjniptr\u003EsetInGameVoiceSpeaking\u0028JJZ\u0029V;
    static IntPtr __\u003Cjniptr\u003EgetSmallFriendAvatar\u0028JJ\u0029I;
    static IntPtr __\u003Cjniptr\u003EgetMediumFriendAvatar\u0028JJ\u0029I;
    static IntPtr __\u003Cjniptr\u003EgetLargeFriendAvatar\u0028JJ\u0029I;
    static IntPtr __\u003Cjniptr\u003ErequestUserInformation\u0028JJZ\u0029Z;
    static IntPtr __\u003Cjniptr\u003EactivateGameOverlay\u0028JLjava\u002Flang\u002FString\u003B\u0029V;
    static IntPtr __\u003Cjniptr\u003EactivateGameOverlayToUser\u0028JLjava\u002Flang\u002FString\u003BJ\u0029V;
    static IntPtr __\u003Cjniptr\u003EactivateGameOverlayToWebPage\u0028JLjava\u002Flang\u002FString\u003B\u0029V;
    static IntPtr __\u003Cjniptr\u003EactivateGameOverlayToStore\u0028JII\u0029V;
    static IntPtr __\u003Cjniptr\u003EactivateGameOverlayInviteDialog\u0028JJ\u0029V;
    static IntPtr __\u003Cjniptr\u003EsetRichPresence\u0028JLjava\u002Flang\u002FString\u003BLjava\u002Flang\u002FString\u003B\u0029Z;
    static IntPtr __\u003Cjniptr\u003EclearRichPresence\u0028J\u0029V;
    static IntPtr __\u003Cjniptr\u003EgetFriendRichPresence\u0028JJLjava\u002Flang\u002FString\u003B\u0029Ljava\u002Flang\u002FString\u003B;
    static IntPtr __\u003Cjniptr\u003EgetFriendRichPresenceKeyCount\u0028JJ\u0029I;
    static IntPtr __\u003Cjniptr\u003EgetFriendRichPresenceKeyByIndex\u0028JJI\u0029Ljava\u002Flang\u002FString\u003B;
    static IntPtr __\u003Cjniptr\u003ErequestFriendRichPresence\u0028JJ\u0029V;
    static IntPtr __\u003Cjniptr\u003EinviteUserToGame\u0028JJLjava\u002Flang\u002FString\u003B\u0029Z;

    [LineNumberTable(new byte[] {160, 137, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void activateGameOverlayToWebPage(string url) => SteamFriends.activateGameOverlayToWebPage(this.pointer, url);

    [LineNumberTable(263)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool setRichPresence(string key, string value) => SteamFriends.setRichPresence(this.pointer, key, value == null ? "" : value);

    [LineNumberTable(179)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string getPersonaName() => SteamFriends.getPersonaName(this.pointer);

    [LineNumberTable(new byte[] {125, 118})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public SteamFriends(SteamFriendsCallback callback)
      : base(SteamAPI.getSteamFriendsPointer(), SteamFriends.createCallback(new SteamFriendsCallbackAdapter(callback)))
    {
    }

    [LineNumberTable(215)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string getFriendPersonaName(SteamID steamIDFriend) => SteamFriends.getFriendPersonaName(this.pointer, steamIDFriend.handle);

    [LineNumberTable(new byte[] {160, 145, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void activateGameOverlayInviteDialog(SteamID steamIDLobby) => SteamFriends.activateGameOverlayInviteDialog(this.pointer, steamIDLobby.handle);

    [Modifiers]
    private static long createCallback([In] SteamFriendsCallbackAdapter obj0)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamFriends.__\u003Cjniptr\u003EcreateCallback\u0028Lcom\u002Fcodedisaster\u002Fsteamworks\u002FSteamFriendsCallbackAdapter\u003B\u0029J == IntPtr.Zero)
        SteamFriends.__\u003Cjniptr\u003EcreateCallback\u0028Lcom\u002Fcodedisaster\u002Fsteamworks\u002FSteamFriendsCallbackAdapter\u003B\u0029J = JNI.Frame.GetFuncPtr(SteamFriends.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamFriends", nameof (createCallback), "(Lcom/codedisaster/steamworks/SteamFriendsCallbackAdapter;)J");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamFriends.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamFriends>.Value);
        IntPtr num4 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj0);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<long (IntPtr, IntPtr, IntPtr)>) SteamFriends.__\u003Cjniptr\u003EcreateCallback\u0028Lcom\u002Fcodedisaster\u002Fsteamworks\u002FSteamFriendsCallbackAdapter\u003B\u0029J)(num2, num3, num4);
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
    private static string getPersonaName([In] long obj0)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamFriends.__\u003Cjniptr\u003EgetPersonaName\u0028J\u0029Ljava\u002Flang\u002FString\u003B == IntPtr.Zero)
        SteamFriends.__\u003Cjniptr\u003EgetPersonaName\u0028J\u0029Ljava\u002Flang\u002FString\u003B = JNI.Frame.GetFuncPtr(SteamFriends.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamFriends", nameof (getPersonaName), "(J)Ljava/lang/String;");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamFriends.__\u003CGetCallerID\u003E());
      try
      {
        ref JNI.Frame local = ref frame;
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamFriends>.Value);
        long num4 = obj0;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        IntPtr num5 = __calli((__FnPtr<IntPtr (IntPtr, IntPtr, long)>) SteamFriends.__\u003Cjniptr\u003EgetPersonaName\u0028J\u0029Ljava\u002Flang\u002FString\u003B)((long) num2, num3, (IntPtr) num4);
        return (string) ((JNI.Frame) ref local).UnwrapLocalRef(num5);
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
    private static long setPersonaName([In] long obj0, [In] long obj1, [In] string obj2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamFriends.__\u003Cjniptr\u003EsetPersonaName\u0028JJLjava\u002Flang\u002FString\u003B\u0029J == IntPtr.Zero)
        SteamFriends.__\u003Cjniptr\u003EsetPersonaName\u0028JJLjava\u002Flang\u002FString\u003B\u0029J = JNI.Frame.GetFuncPtr(SteamFriends.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamFriends", nameof (setPersonaName), "(JJLjava/lang/String;)J");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamFriends.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamFriends>.Value);
        long num4 = obj0;
        long num5 = obj1;
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj2);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<long (IntPtr, IntPtr, long, long, IntPtr)>) SteamFriends.__\u003Cjniptr\u003EsetPersonaName\u0028JJLjava\u002Flang\u002FString\u003B\u0029J)(num2, (long) num3, num4, (IntPtr) num5, num6);
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
    private static int getPersonaState([In] long obj0)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamFriends.__\u003Cjniptr\u003EgetPersonaState\u0028J\u0029I == IntPtr.Zero)
        SteamFriends.__\u003Cjniptr\u003EgetPersonaState\u0028J\u0029I = JNI.Frame.GetFuncPtr(SteamFriends.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamFriends", nameof (getPersonaState), "(J)I");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamFriends.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamFriends>.Value);
        long num4 = obj0;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<int (IntPtr, IntPtr, long)>) SteamFriends.__\u003Cjniptr\u003EgetPersonaState\u0028J\u0029I)((long) num2, num3, (IntPtr) num4);
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
    private static int getFriendCount([In] long obj0, [In] int obj1)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamFriends.__\u003Cjniptr\u003EgetFriendCount\u0028JI\u0029I == IntPtr.Zero)
        SteamFriends.__\u003Cjniptr\u003EgetFriendCount\u0028JI\u0029I = JNI.Frame.GetFuncPtr(SteamFriends.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamFriends", nameof (getFriendCount), "(JI)I");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamFriends.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamFriends>.Value);
        long num4 = obj0;
        int num5 = obj1;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<int (IntPtr, IntPtr, long, int)>) SteamFriends.__\u003Cjniptr\u003EgetFriendCount\u0028JI\u0029I)((int) num2, (long) num3, (IntPtr) num4, (IntPtr) num5);
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
    private static long getFriendByIndex([In] long obj0, [In] int obj1, [In] int obj2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamFriends.__\u003Cjniptr\u003EgetFriendByIndex\u0028JII\u0029J == IntPtr.Zero)
        SteamFriends.__\u003Cjniptr\u003EgetFriendByIndex\u0028JII\u0029J = JNI.Frame.GetFuncPtr(SteamFriends.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamFriends", nameof (getFriendByIndex), "(JII)J");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamFriends.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamFriends>.Value);
        long num4 = obj0;
        int num5 = obj1;
        int num6 = obj2;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<long (IntPtr, IntPtr, long, int, int)>) SteamFriends.__\u003Cjniptr\u003EgetFriendByIndex\u0028JII\u0029J)((int) num2, (int) num3, num4, (IntPtr) num5, (IntPtr) num6);
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
    private static int getFriendRelationship([In] long obj0, [In] long obj1)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamFriends.__\u003Cjniptr\u003EgetFriendRelationship\u0028JJ\u0029I == IntPtr.Zero)
        SteamFriends.__\u003Cjniptr\u003EgetFriendRelationship\u0028JJ\u0029I = JNI.Frame.GetFuncPtr(SteamFriends.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamFriends", nameof (getFriendRelationship), "(JJ)I");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamFriends.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamFriends>.Value);
        long num4 = obj0;
        long num5 = obj1;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<int (IntPtr, IntPtr, long, long)>) SteamFriends.__\u003Cjniptr\u003EgetFriendRelationship\u0028JJ\u0029I)((long) num2, (long) num3, (IntPtr) num4, (IntPtr) num5);
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
    private static int getFriendPersonaState([In] long obj0, [In] long obj1)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamFriends.__\u003Cjniptr\u003EgetFriendPersonaState\u0028JJ\u0029I == IntPtr.Zero)
        SteamFriends.__\u003Cjniptr\u003EgetFriendPersonaState\u0028JJ\u0029I = JNI.Frame.GetFuncPtr(SteamFriends.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamFriends", nameof (getFriendPersonaState), "(JJ)I");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamFriends.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamFriends>.Value);
        long num4 = obj0;
        long num5 = obj1;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<int (IntPtr, IntPtr, long, long)>) SteamFriends.__\u003Cjniptr\u003EgetFriendPersonaState\u0028JJ\u0029I)((long) num2, (long) num3, (IntPtr) num4, (IntPtr) num5);
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
    private static string getFriendPersonaName([In] long obj0, [In] long obj1)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamFriends.__\u003Cjniptr\u003EgetFriendPersonaName\u0028JJ\u0029Ljava\u002Flang\u002FString\u003B == IntPtr.Zero)
        SteamFriends.__\u003Cjniptr\u003EgetFriendPersonaName\u0028JJ\u0029Ljava\u002Flang\u002FString\u003B = JNI.Frame.GetFuncPtr(SteamFriends.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamFriends", nameof (getFriendPersonaName), "(JJ)Ljava/lang/String;");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamFriends.__\u003CGetCallerID\u003E());
      try
      {
        ref JNI.Frame local = ref frame;
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamFriends>.Value);
        long num4 = obj0;
        long num5 = obj1;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        IntPtr num6 = __calli((__FnPtr<IntPtr (IntPtr, IntPtr, long, long)>) SteamFriends.__\u003Cjniptr\u003EgetFriendPersonaName\u0028JJ\u0029Ljava\u002Flang\u002FString\u003B)((long) num2, (long) num3, (IntPtr) num4, (IntPtr) num5);
        return (string) ((JNI.Frame) ref local).UnwrapLocalRef(num6);
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
    private static bool getFriendGamePlayed([In] long obj0, [In] long obj1, [In] SteamFriends.FriendGameInfo obj2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamFriends.__\u003Cjniptr\u003EgetFriendGamePlayed\u0028JJLcom\u002Fcodedisaster\u002Fsteamworks\u002FSteamFriends\u0024FriendGameInfo\u003B\u0029Z == IntPtr.Zero)
        SteamFriends.__\u003Cjniptr\u003EgetFriendGamePlayed\u0028JJLcom\u002Fcodedisaster\u002Fsteamworks\u002FSteamFriends\u0024FriendGameInfo\u003B\u0029Z = JNI.Frame.GetFuncPtr(SteamFriends.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamFriends", nameof (getFriendGamePlayed), "(JJLcom/codedisaster/steamworks/SteamFriends$FriendGameInfo;)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamFriends.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamFriends>.Value);
        long num4 = obj0;
        long num5 = obj1;
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj2);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, long, long, IntPtr)>) SteamFriends.__\u003Cjniptr\u003EgetFriendGamePlayed\u0028JJLcom\u002Fcodedisaster\u002Fsteamworks\u002FSteamFriends\u0024FriendGameInfo\u003B\u0029Z)(num2, (long) num3, num4, (IntPtr) num5, num6);
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
    private static void setInGameVoiceSpeaking([In] long obj0, [In] long obj1, [In] bool obj2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamFriends.__\u003Cjniptr\u003EsetInGameVoiceSpeaking\u0028JJZ\u0029V == IntPtr.Zero)
        SteamFriends.__\u003Cjniptr\u003EsetInGameVoiceSpeaking\u0028JJZ\u0029V = JNI.Frame.GetFuncPtr(SteamFriends.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamFriends", nameof (setInGameVoiceSpeaking), "(JJZ)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamFriends.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamFriends>.Value);
        long num4 = obj0;
        long num5 = obj1;
        int num6 = obj2 ? 1 : 0;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, long, long, bool)>) SteamFriends.__\u003Cjniptr\u003EsetInGameVoiceSpeaking\u0028JJZ\u0029V)((bool) num2, (long) num3, num4, (IntPtr) num5, (IntPtr) num6);
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
    private static int getSmallFriendAvatar([In] long obj0, [In] long obj1)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamFriends.__\u003Cjniptr\u003EgetSmallFriendAvatar\u0028JJ\u0029I == IntPtr.Zero)
        SteamFriends.__\u003Cjniptr\u003EgetSmallFriendAvatar\u0028JJ\u0029I = JNI.Frame.GetFuncPtr(SteamFriends.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamFriends", nameof (getSmallFriendAvatar), "(JJ)I");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamFriends.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamFriends>.Value);
        long num4 = obj0;
        long num5 = obj1;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<int (IntPtr, IntPtr, long, long)>) SteamFriends.__\u003Cjniptr\u003EgetSmallFriendAvatar\u0028JJ\u0029I)((long) num2, (long) num3, (IntPtr) num4, (IntPtr) num5);
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
    private static int getMediumFriendAvatar([In] long obj0, [In] long obj1)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamFriends.__\u003Cjniptr\u003EgetMediumFriendAvatar\u0028JJ\u0029I == IntPtr.Zero)
        SteamFriends.__\u003Cjniptr\u003EgetMediumFriendAvatar\u0028JJ\u0029I = JNI.Frame.GetFuncPtr(SteamFriends.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamFriends", nameof (getMediumFriendAvatar), "(JJ)I");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamFriends.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamFriends>.Value);
        long num4 = obj0;
        long num5 = obj1;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<int (IntPtr, IntPtr, long, long)>) SteamFriends.__\u003Cjniptr\u003EgetMediumFriendAvatar\u0028JJ\u0029I)((long) num2, (long) num3, (IntPtr) num4, (IntPtr) num5);
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
    private static int getLargeFriendAvatar([In] long obj0, [In] long obj1)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamFriends.__\u003Cjniptr\u003EgetLargeFriendAvatar\u0028JJ\u0029I == IntPtr.Zero)
        SteamFriends.__\u003Cjniptr\u003EgetLargeFriendAvatar\u0028JJ\u0029I = JNI.Frame.GetFuncPtr(SteamFriends.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamFriends", nameof (getLargeFriendAvatar), "(JJ)I");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamFriends.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamFriends>.Value);
        long num4 = obj0;
        long num5 = obj1;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<int (IntPtr, IntPtr, long, long)>) SteamFriends.__\u003Cjniptr\u003EgetLargeFriendAvatar\u0028JJ\u0029I)((long) num2, (long) num3, (IntPtr) num4, (IntPtr) num5);
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
    private static bool requestUserInformation([In] long obj0, [In] long obj1, [In] bool obj2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamFriends.__\u003Cjniptr\u003ErequestUserInformation\u0028JJZ\u0029Z == IntPtr.Zero)
        SteamFriends.__\u003Cjniptr\u003ErequestUserInformation\u0028JJZ\u0029Z = JNI.Frame.GetFuncPtr(SteamFriends.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamFriends", nameof (requestUserInformation), "(JJZ)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamFriends.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamFriends>.Value);
        long num4 = obj0;
        long num5 = obj1;
        int num6 = obj2 ? 1 : 0;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, long, long, bool)>) SteamFriends.__\u003Cjniptr\u003ErequestUserInformation\u0028JJZ\u0029Z)((bool) num2, (long) num3, num4, (IntPtr) num5, (IntPtr) num6);
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
    private static void activateGameOverlay([In] long obj0, [In] string obj1)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamFriends.__\u003Cjniptr\u003EactivateGameOverlay\u0028JLjava\u002Flang\u002FString\u003B\u0029V == IntPtr.Zero)
        SteamFriends.__\u003Cjniptr\u003EactivateGameOverlay\u0028JLjava\u002Flang\u002FString\u003B\u0029V = JNI.Frame.GetFuncPtr(SteamFriends.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamFriends", nameof (activateGameOverlay), "(JLjava/lang/String;)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamFriends.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamFriends>.Value);
        long num4 = obj0;
        IntPtr num5 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj1);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, long, IntPtr)>) SteamFriends.__\u003Cjniptr\u003EactivateGameOverlay\u0028JLjava\u002Flang\u002FString\u003B\u0029V)(num2, (long) num3, (IntPtr) num4, num5);
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
    private static void activateGameOverlayToUser([In] long obj0, [In] string obj1, [In] long obj2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamFriends.__\u003Cjniptr\u003EactivateGameOverlayToUser\u0028JLjava\u002Flang\u002FString\u003BJ\u0029V == IntPtr.Zero)
        SteamFriends.__\u003Cjniptr\u003EactivateGameOverlayToUser\u0028JLjava\u002Flang\u002FString\u003BJ\u0029V = JNI.Frame.GetFuncPtr(SteamFriends.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamFriends", nameof (activateGameOverlayToUser), "(JLjava/lang/String;J)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamFriends.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamFriends>.Value);
        long num4 = obj0;
        IntPtr num5 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj1);
        long num6 = obj2;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, long, IntPtr, long)>) SteamFriends.__\u003Cjniptr\u003EactivateGameOverlayToUser\u0028JLjava\u002Flang\u002FString\u003BJ\u0029V)((long) num2, num3, num4, num5, (IntPtr) num6);
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
    private static void activateGameOverlayToWebPage([In] long obj0, [In] string obj1)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamFriends.__\u003Cjniptr\u003EactivateGameOverlayToWebPage\u0028JLjava\u002Flang\u002FString\u003B\u0029V == IntPtr.Zero)
        SteamFriends.__\u003Cjniptr\u003EactivateGameOverlayToWebPage\u0028JLjava\u002Flang\u002FString\u003B\u0029V = JNI.Frame.GetFuncPtr(SteamFriends.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamFriends", nameof (activateGameOverlayToWebPage), "(JLjava/lang/String;)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamFriends.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamFriends>.Value);
        long num4 = obj0;
        IntPtr num5 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj1);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, long, IntPtr)>) SteamFriends.__\u003Cjniptr\u003EactivateGameOverlayToWebPage\u0028JLjava\u002Flang\u002FString\u003B\u0029V)(num2, (long) num3, (IntPtr) num4, num5);
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
    private static void activateGameOverlayToStore([In] long obj0, [In] int obj1, [In] int obj2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamFriends.__\u003Cjniptr\u003EactivateGameOverlayToStore\u0028JII\u0029V == IntPtr.Zero)
        SteamFriends.__\u003Cjniptr\u003EactivateGameOverlayToStore\u0028JII\u0029V = JNI.Frame.GetFuncPtr(SteamFriends.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamFriends", nameof (activateGameOverlayToStore), "(JII)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamFriends.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamFriends>.Value);
        long num4 = obj0;
        int num5 = obj1;
        int num6 = obj2;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, long, int, int)>) SteamFriends.__\u003Cjniptr\u003EactivateGameOverlayToStore\u0028JII\u0029V)((int) num2, (int) num3, num4, (IntPtr) num5, (IntPtr) num6);
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
    private static void activateGameOverlayInviteDialog([In] long obj0, [In] long obj1)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamFriends.__\u003Cjniptr\u003EactivateGameOverlayInviteDialog\u0028JJ\u0029V == IntPtr.Zero)
        SteamFriends.__\u003Cjniptr\u003EactivateGameOverlayInviteDialog\u0028JJ\u0029V = JNI.Frame.GetFuncPtr(SteamFriends.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamFriends", nameof (activateGameOverlayInviteDialog), "(JJ)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamFriends.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamFriends>.Value);
        long num4 = obj0;
        long num5 = obj1;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, long, long)>) SteamFriends.__\u003Cjniptr\u003EactivateGameOverlayInviteDialog\u0028JJ\u0029V)((long) num2, (long) num3, (IntPtr) num4, (IntPtr) num5);
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
    private static bool setRichPresence([In] long obj0, [In] string obj1, [In] string obj2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamFriends.__\u003Cjniptr\u003EsetRichPresence\u0028JLjava\u002Flang\u002FString\u003BLjava\u002Flang\u002FString\u003B\u0029Z == IntPtr.Zero)
        SteamFriends.__\u003Cjniptr\u003EsetRichPresence\u0028JLjava\u002Flang\u002FString\u003BLjava\u002Flang\u002FString\u003B\u0029Z = JNI.Frame.GetFuncPtr(SteamFriends.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamFriends", nameof (setRichPresence), "(JLjava/lang/String;Ljava/lang/String;)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamFriends.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamFriends>.Value);
        long num4 = obj0;
        IntPtr num5 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj1);
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj2);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, long, IntPtr, IntPtr)>) SteamFriends.__\u003Cjniptr\u003EsetRichPresence\u0028JLjava\u002Flang\u002FString\u003BLjava\u002Flang\u002FString\u003B\u0029Z)(num2, num3, num4, num5, num6);
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
    private static void clearRichPresence([In] long obj0)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamFriends.__\u003Cjniptr\u003EclearRichPresence\u0028J\u0029V == IntPtr.Zero)
        SteamFriends.__\u003Cjniptr\u003EclearRichPresence\u0028J\u0029V = JNI.Frame.GetFuncPtr(SteamFriends.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamFriends", nameof (clearRichPresence), "(J)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamFriends.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamFriends>.Value);
        long num4 = obj0;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, long)>) SteamFriends.__\u003Cjniptr\u003EclearRichPresence\u0028J\u0029V)((long) num2, num3, (IntPtr) num4);
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
    private static string getFriendRichPresence([In] long obj0, [In] long obj1, [In] string obj2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamFriends.__\u003Cjniptr\u003EgetFriendRichPresence\u0028JJLjava\u002Flang\u002FString\u003B\u0029Ljava\u002Flang\u002FString\u003B == IntPtr.Zero)
        SteamFriends.__\u003Cjniptr\u003EgetFriendRichPresence\u0028JJLjava\u002Flang\u002FString\u003B\u0029Ljava\u002Flang\u002FString\u003B = JNI.Frame.GetFuncPtr(SteamFriends.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamFriends", nameof (getFriendRichPresence), "(JJLjava/lang/String;)Ljava/lang/String;");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamFriends.__\u003CGetCallerID\u003E());
      try
      {
        ref JNI.Frame local = ref frame;
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamFriends>.Value);
        long num4 = obj0;
        long num5 = obj1;
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj2);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        IntPtr num7 = __calli((__FnPtr<IntPtr (IntPtr, IntPtr, long, long, IntPtr)>) SteamFriends.__\u003Cjniptr\u003EgetFriendRichPresence\u0028JJLjava\u002Flang\u002FString\u003B\u0029Ljava\u002Flang\u002FString\u003B)(num2, (long) num3, num4, (IntPtr) num5, num6);
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
    private static int getFriendRichPresenceKeyCount([In] long obj0, [In] long obj1)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamFriends.__\u003Cjniptr\u003EgetFriendRichPresenceKeyCount\u0028JJ\u0029I == IntPtr.Zero)
        SteamFriends.__\u003Cjniptr\u003EgetFriendRichPresenceKeyCount\u0028JJ\u0029I = JNI.Frame.GetFuncPtr(SteamFriends.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamFriends", nameof (getFriendRichPresenceKeyCount), "(JJ)I");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamFriends.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamFriends>.Value);
        long num4 = obj0;
        long num5 = obj1;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<int (IntPtr, IntPtr, long, long)>) SteamFriends.__\u003Cjniptr\u003EgetFriendRichPresenceKeyCount\u0028JJ\u0029I)((long) num2, (long) num3, (IntPtr) num4, (IntPtr) num5);
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
    private static string getFriendRichPresenceKeyByIndex([In] long obj0, [In] long obj1, [In] int obj2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamFriends.__\u003Cjniptr\u003EgetFriendRichPresenceKeyByIndex\u0028JJI\u0029Ljava\u002Flang\u002FString\u003B == IntPtr.Zero)
        SteamFriends.__\u003Cjniptr\u003EgetFriendRichPresenceKeyByIndex\u0028JJI\u0029Ljava\u002Flang\u002FString\u003B = JNI.Frame.GetFuncPtr(SteamFriends.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamFriends", nameof (getFriendRichPresenceKeyByIndex), "(JJI)Ljava/lang/String;");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamFriends.__\u003CGetCallerID\u003E());
      try
      {
        ref JNI.Frame local = ref frame;
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamFriends>.Value);
        long num4 = obj0;
        long num5 = obj1;
        int num6 = obj2;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        IntPtr num7 = __calli((__FnPtr<IntPtr (IntPtr, IntPtr, long, long, int)>) SteamFriends.__\u003Cjniptr\u003EgetFriendRichPresenceKeyByIndex\u0028JJI\u0029Ljava\u002Flang\u002FString\u003B)((int) num2, (long) num3, num4, (IntPtr) num5, (IntPtr) num6);
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
    private static void requestFriendRichPresence([In] long obj0, [In] long obj1)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamFriends.__\u003Cjniptr\u003ErequestFriendRichPresence\u0028JJ\u0029V == IntPtr.Zero)
        SteamFriends.__\u003Cjniptr\u003ErequestFriendRichPresence\u0028JJ\u0029V = JNI.Frame.GetFuncPtr(SteamFriends.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamFriends", nameof (requestFriendRichPresence), "(JJ)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamFriends.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamFriends>.Value);
        long num4 = obj0;
        long num5 = obj1;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, long, long)>) SteamFriends.__\u003Cjniptr\u003ErequestFriendRichPresence\u0028JJ\u0029V)((long) num2, (long) num3, (IntPtr) num4, (IntPtr) num5);
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
    private static bool inviteUserToGame([In] long obj0, [In] long obj1, [In] string obj2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamFriends.__\u003Cjniptr\u003EinviteUserToGame\u0028JJLjava\u002Flang\u002FString\u003B\u0029Z == IntPtr.Zero)
        SteamFriends.__\u003Cjniptr\u003EinviteUserToGame\u0028JJLjava\u002Flang\u002FString\u003B\u0029Z = JNI.Frame.GetFuncPtr(SteamFriends.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamFriends", nameof (inviteUserToGame), "(JJLjava/lang/String;)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamFriends.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamFriends>.Value);
        long num4 = obj0;
        long num5 = obj1;
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj2);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, long, long, IntPtr)>) SteamFriends.__\u003Cjniptr\u003EinviteUserToGame\u0028JJLjava\u002Flang\u002FString\u003B\u0029Z)(num2, (long) num3, num4, (IntPtr) num5, num6);
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

    [LineNumberTable(183)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual SteamAPICall setPersonaName(string personaName) => new SteamAPICall(SteamFriends.setPersonaName(this.pointer, this.callback, personaName));

    [LineNumberTable(187)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual SteamFriends.PersonaState getPersonaState() => SteamFriends.PersonaState.byOrdinal(SteamFriends.getPersonaState(this.pointer));

    [LineNumberTable(191)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getFriendCount(SteamFriends.FriendFlags friendFlag) => SteamFriends.getFriendCount(this.pointer, SteamFriends.FriendFlags.access\u0024000(friendFlag));

    [Signature("(Ljava/util/Collection<Lcom/codedisaster/steamworks/SteamFriends$FriendFlags;>;)I")]
    [LineNumberTable(195)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getFriendCount(Collection friendFlags) => SteamFriends.getFriendCount(this.pointer, SteamFriends.FriendFlags.asBits(friendFlags));

    [LineNumberTable(199)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual SteamID getFriendByIndex(int friend, SteamFriends.FriendFlags friendFlag)
    {
      SteamID.__\u003Cclinit\u003E();
      return new SteamID(SteamFriends.getFriendByIndex(this.pointer, friend, SteamFriends.FriendFlags.access\u0024000(friendFlag)));
    }

    [Signature("(ILjava/util/Collection<Lcom/codedisaster/steamworks/SteamFriends$FriendFlags;>;)Lcom/codedisaster/steamworks/SteamID;")]
    [LineNumberTable(203)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual SteamID getFriendByIndex(int friend, Collection friendFlags)
    {
      SteamID.__\u003Cclinit\u003E();
      return new SteamID(SteamFriends.getFriendByIndex(this.pointer, friend, SteamFriends.FriendFlags.asBits(friendFlags)));
    }

    [LineNumberTable(207)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual SteamFriends.FriendRelationship getFriendRelationship(
      SteamID steamIDFriend)
    {
      return SteamFriends.FriendRelationship.byOrdinal(SteamFriends.getFriendRelationship(this.pointer, steamIDFriend.handle));
    }

    [LineNumberTable(211)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual SteamFriends.PersonaState getFriendPersonaState(SteamID steamIDFriend) => SteamFriends.PersonaState.byOrdinal(SteamFriends.getFriendPersonaState(this.pointer, steamIDFriend.handle));

    [LineNumberTable(219)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool getFriendGamePlayed(
      SteamID steamIDFriend,
      SteamFriends.FriendGameInfo friendGameInfo)
    {
      return SteamFriends.getFriendGamePlayed(this.pointer, steamIDFriend.handle, friendGameInfo);
    }

    [LineNumberTable(new byte[] {159, 87, 162, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setInGameVoiceSpeaking(SteamID steamID, bool speaking)
    {
      int num = speaking ? 1 : 0;
      SteamFriends.setInGameVoiceSpeaking(this.pointer, steamID.handle, num != 0);
    }

    [LineNumberTable(227)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getSmallFriendAvatar(SteamID steamID) => SteamFriends.getSmallFriendAvatar(this.pointer, steamID.handle);

    [LineNumberTable(231)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getMediumFriendAvatar(SteamID steamID) => SteamFriends.getMediumFriendAvatar(this.pointer, steamID.handle);

    [LineNumberTable(235)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getLargeFriendAvatar(SteamID steamID) => SteamFriends.getLargeFriendAvatar(this.pointer, steamID.handle);

    [LineNumberTable(239)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool requestUserInformation(SteamID steamID, bool requireNameOnly)
    {
      int num = requireNameOnly ? 1 : 0;
      return SteamFriends.requestUserInformation(this.pointer, steamID.handle, num != 0);
    }

    [LineNumberTable(new byte[] {160, 129, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void activateGameOverlay(SteamFriends.OverlayDialog dialog) => SteamFriends.activateGameOverlay(this.pointer, SteamFriends.OverlayDialog.access\u0024100(dialog));

    [LineNumberTable(new byte[] {160, 133, 119})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void activateGameOverlayToUser(
      SteamFriends.OverlayToUserDialog dialog,
      SteamID steamID)
    {
      SteamFriends.activateGameOverlayToUser(this.pointer, SteamFriends.OverlayToUserDialog.access\u0024200(dialog), steamID.handle);
    }

    [LineNumberTable(new byte[] {160, 141, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void activateGameOverlayToStore(int appID, SteamFriends.OverlayToStoreFlag flag) => SteamFriends.activateGameOverlayToStore(this.pointer, appID, flag.ordinal());

    [LineNumberTable(new byte[] {160, 153, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void clearRichPresence() => SteamFriends.clearRichPresence(this.pointer);

    [LineNumberTable(271)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string getFriendRichPresence(SteamID steamIDFriend, string key) => SteamFriends.getFriendRichPresence(this.pointer, steamIDFriend.handle, key);

    [LineNumberTable(275)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getFriendRichPresenceKeyCount(SteamID steamIDFriend) => SteamFriends.getFriendRichPresenceKeyCount(this.pointer, steamIDFriend.handle);

    [LineNumberTable(279)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string getFriendRichPresenceKeyByIndex(SteamID steamIDFriend, int index) => SteamFriends.getFriendRichPresenceKeyByIndex(this.pointer, steamIDFriend.handle, index);

    [LineNumberTable(new byte[] {160, 169, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void requestFriendRichPresence(SteamID steamIDFriend) => SteamFriends.requestFriendRichPresence(this.pointer, steamIDFriend.handle);

    [LineNumberTable(287)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool inviteUserToGame(SteamID steamIDFriend, string connectString) => SteamFriends.inviteUserToGame(this.pointer, steamIDFriend.handle, connectString);

    [Modifiers]
    [LineNumberTable(5)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void dispose() => base.dispose();

    new static CallerID __\u003CGetCallerID\u003E()
    {
      if (SteamFriends.__\u003CcallerID\u003E == null)
        SteamFriends.__\u003CcallerID\u003E = (CallerID) new SteamFriends.__\u003CCallerID\u003E();
      return SteamFriends.__\u003CcallerID\u003E;
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
    [Signature("Ljava/lang/Enum<Lcom/codedisaster/steamworks/SteamFriends$FriendFlags;>;")]
    [Modifiers]
    [Serializable]
    public sealed class FriendFlags : Enum
    {
      [Modifiers]
      internal static SteamFriends.FriendFlags __\u003C\u003ENone;
      [Modifiers]
      internal static SteamFriends.FriendFlags __\u003C\u003EBlocked;
      [Modifiers]
      internal static SteamFriends.FriendFlags __\u003C\u003EFriendshipRequested;
      [Modifiers]
      internal static SteamFriends.FriendFlags __\u003C\u003EImmediate;
      [Modifiers]
      internal static SteamFriends.FriendFlags __\u003C\u003EClanMember;
      [Modifiers]
      internal static SteamFriends.FriendFlags __\u003C\u003EOnGameServer;
      [Modifiers]
      internal static SteamFriends.FriendFlags __\u003C\u003ERequestingFriendship;
      [Modifiers]
      internal static SteamFriends.FriendFlags __\u003C\u003ERequestingInfo;
      [Modifiers]
      internal static SteamFriends.FriendFlags __\u003C\u003EIgnored;
      [Modifiers]
      internal static SteamFriends.FriendFlags __\u003C\u003EIgnoredFriend;
      [Modifiers]
      internal static SteamFriends.FriendFlags __\u003C\u003EChatMember;
      [Modifiers]
      internal static SteamFriends.FriendFlags __\u003C\u003EAll;
      [Modifiers]
      private int bits;
      [Modifiers]
      private static SteamFriends.FriendFlags[] \u0024VALUES;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [Signature("(I)V")]
      [LineNumberTable(new byte[] {11, 106, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private FriendFlags([In] string obj0, [In] int obj1, [In] int obj2)
        : base(obj0, obj1)
      {
        SteamFriends.FriendFlags friendFlags = this;
        this.bits = obj2;
        GC.KeepAlive((object) this);
      }

      [LineNumberTable(41)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static SteamFriends.FriendFlags[] values() => (SteamFriends.FriendFlags[]) SteamFriends.FriendFlags.\u0024VALUES.Clone();

      [LineNumberTable(41)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static SteamFriends.FriendFlags valueOf(string name) => (SteamFriends.FriendFlags) Enum.valueOf((Class) ClassLiteral<SteamFriends.FriendFlags>.Value, name);

      [Signature("(Ljava/util/Collection<Lcom/codedisaster/steamworks/SteamFriends$FriendFlags;>;)I")]
      [LineNumberTable(new byte[] {16, 98, 123, 105, 98})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal static int asBits([In] Collection obj0)
      {
        int num = 0;
        Iterator iterator = obj0.iterator();
        while (iterator.hasNext())
        {
          SteamFriends.FriendFlags friendFlags = (SteamFriends.FriendFlags) iterator.next();
          num |= friendFlags.bits;
        }
        return num;
      }

      [Modifiers]
      [LineNumberTable(41)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal static int access\u0024000([In] SteamFriends.FriendFlags obj0) => obj0.bits;

      [LineNumberTable(new byte[] {159, 132, 173, 113, 113, 113, 113, 113, 178, 117, 117, 117, 150, 118, 246, 48})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static FriendFlags()
      {
        if (ByteCodeHelper.isAlreadyInited("com.codedisaster.steamworks.SteamFriends$FriendFlags"))
          return;
        SteamFriends.FriendFlags.__\u003C\u003ENone = new SteamFriends.FriendFlags(nameof (None), 0, 0);
        SteamFriends.FriendFlags.__\u003C\u003EBlocked = new SteamFriends.FriendFlags(nameof (Blocked), 1, 1);
        SteamFriends.FriendFlags.__\u003C\u003EFriendshipRequested = new SteamFriends.FriendFlags(nameof (FriendshipRequested), 2, 2);
        SteamFriends.FriendFlags.__\u003C\u003EImmediate = new SteamFriends.FriendFlags(nameof (Immediate), 3, 4);
        SteamFriends.FriendFlags.__\u003C\u003EClanMember = new SteamFriends.FriendFlags(nameof (ClanMember), 4, 8);
        SteamFriends.FriendFlags.__\u003C\u003EOnGameServer = new SteamFriends.FriendFlags(nameof (OnGameServer), 5, 16);
        SteamFriends.FriendFlags.__\u003C\u003ERequestingFriendship = new SteamFriends.FriendFlags(nameof (RequestingFriendship), 6, 128);
        SteamFriends.FriendFlags.__\u003C\u003ERequestingInfo = new SteamFriends.FriendFlags(nameof (RequestingInfo), 7, 256);
        SteamFriends.FriendFlags.__\u003C\u003EIgnored = new SteamFriends.FriendFlags(nameof (Ignored), 8, 512);
        SteamFriends.FriendFlags.__\u003C\u003EIgnoredFriend = new SteamFriends.FriendFlags(nameof (IgnoredFriend), 9, 1024);
        SteamFriends.FriendFlags.__\u003C\u003EChatMember = new SteamFriends.FriendFlags(nameof (ChatMember), 10, 4096);
        SteamFriends.FriendFlags.__\u003C\u003EAll = new SteamFriends.FriendFlags(nameof (All), 11, (int) ushort.MaxValue);
        SteamFriends.FriendFlags.\u0024VALUES = new SteamFriends.FriendFlags[12]
        {
          SteamFriends.FriendFlags.__\u003C\u003ENone,
          SteamFriends.FriendFlags.__\u003C\u003EBlocked,
          SteamFriends.FriendFlags.__\u003C\u003EFriendshipRequested,
          SteamFriends.FriendFlags.__\u003C\u003EImmediate,
          SteamFriends.FriendFlags.__\u003C\u003EClanMember,
          SteamFriends.FriendFlags.__\u003C\u003EOnGameServer,
          SteamFriends.FriendFlags.__\u003C\u003ERequestingFriendship,
          SteamFriends.FriendFlags.__\u003C\u003ERequestingInfo,
          SteamFriends.FriendFlags.__\u003C\u003EIgnored,
          SteamFriends.FriendFlags.__\u003C\u003EIgnoredFriend,
          SteamFriends.FriendFlags.__\u003C\u003EChatMember,
          SteamFriends.FriendFlags.__\u003C\u003EAll
        };
      }

      [Modifiers]
      public static SteamFriends.FriendFlags None
      {
        [HideFromJava] get => SteamFriends.FriendFlags.__\u003C\u003ENone;
      }

      [Modifiers]
      public static SteamFriends.FriendFlags Blocked
      {
        [HideFromJava] get => SteamFriends.FriendFlags.__\u003C\u003EBlocked;
      }

      [Modifiers]
      public static SteamFriends.FriendFlags FriendshipRequested
      {
        [HideFromJava] get => SteamFriends.FriendFlags.__\u003C\u003EFriendshipRequested;
      }

      [Modifiers]
      public static SteamFriends.FriendFlags Immediate
      {
        [HideFromJava] get => SteamFriends.FriendFlags.__\u003C\u003EImmediate;
      }

      [Modifiers]
      public static SteamFriends.FriendFlags ClanMember
      {
        [HideFromJava] get => SteamFriends.FriendFlags.__\u003C\u003EClanMember;
      }

      [Modifiers]
      public static SteamFriends.FriendFlags OnGameServer
      {
        [HideFromJava] get => SteamFriends.FriendFlags.__\u003C\u003EOnGameServer;
      }

      [Modifiers]
      public static SteamFriends.FriendFlags RequestingFriendship
      {
        [HideFromJava] get => SteamFriends.FriendFlags.__\u003C\u003ERequestingFriendship;
      }

      [Modifiers]
      public static SteamFriends.FriendFlags RequestingInfo
      {
        [HideFromJava] get => SteamFriends.FriendFlags.__\u003C\u003ERequestingInfo;
      }

      [Modifiers]
      public static SteamFriends.FriendFlags Ignored
      {
        [HideFromJava] get => SteamFriends.FriendFlags.__\u003C\u003EIgnored;
      }

      [Modifiers]
      public static SteamFriends.FriendFlags IgnoredFriend
      {
        [HideFromJava] get => SteamFriends.FriendFlags.__\u003C\u003EIgnoredFriend;
      }

      [Modifiers]
      public static SteamFriends.FriendFlags ChatMember
      {
        [HideFromJava] get => SteamFriends.FriendFlags.__\u003C\u003EChatMember;
      }

      [Modifiers]
      public static SteamFriends.FriendFlags All
      {
        [HideFromJava] get => SteamFriends.FriendFlags.__\u003C\u003EAll;
      }

      [HideFromJava]
      [Serializable]
      public enum __Enum
      {
        None,
        Blocked,
        FriendshipRequested,
        Immediate,
        ClanMember,
        OnGameServer,
        RequestingFriendship,
        RequestingInfo,
        Ignored,
        IgnoredFriend,
        ChatMember,
        All,
      }
    }

    public class FriendGameInfo : Object
    {
      private long gameID;
      private int gameIP;
      private short gamePort;
      private short queryPort;
      private long steamIDLobby;

      [LineNumberTable(102)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public FriendGameInfo()
      {
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual long getGameID() => this.gameID;

      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual int getGameIP() => this.gameIP;

      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual short getGamePort() => this.gamePort;

      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual short getQueryPort() => this.queryPort;

      [LineNumberTable(127)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual SteamID getSteamIDLobby()
      {
        SteamID.__\u003Cclinit\u003E();
        return new SteamID(this.steamIDLobby);
      }
    }

    [InnerClass]
    [Signature("Ljava/lang/Enum<Lcom/codedisaster/steamworks/SteamFriends$FriendRelationship;>;")]
    [Modifiers]
    [Serializable]
    public sealed class FriendRelationship : Enum
    {
      [Modifiers]
      internal static SteamFriends.FriendRelationship __\u003C\u003ENone;
      [Modifiers]
      internal static SteamFriends.FriendRelationship __\u003C\u003EBlocked;
      [Modifiers]
      internal static SteamFriends.FriendRelationship __\u003C\u003ERecipient;
      [Modifiers]
      internal static SteamFriends.FriendRelationship __\u003C\u003EFriend;
      [Modifiers]
      internal static SteamFriends.FriendRelationship __\u003C\u003ERequestInitiator;
      [Modifiers]
      internal static SteamFriends.FriendRelationship __\u003C\u003EIgnored;
      [Modifiers]
      internal static SteamFriends.FriendRelationship __\u003C\u003EIgnoredFriend;
      [Modifiers]
      internal static SteamFriends.FriendRelationship __\u003C\u003ESuggested_DEPRECATED;
      [Modifiers]
      internal static SteamFriends.FriendRelationship __\u003C\u003EMax;
      [Modifiers]
      private static SteamFriends.FriendRelationship[] values;
      [Modifiers]
      private static SteamFriends.FriendRelationship[] \u0024VALUES;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(21)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal static SteamFriends.FriendRelationship byOrdinal([In] int obj0) => SteamFriends.FriendRelationship.values[obj0];

      [Signature("()V")]
      [LineNumberTable(7)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private FriendRelationship([In] string obj0, [In] int obj1)
        : base(obj0, obj1)
      {
        GC.KeepAlive((object) this);
      }

      [LineNumberTable(7)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static SteamFriends.FriendRelationship[] values() => (SteamFriends.FriendRelationship[]) SteamFriends.FriendRelationship.\u0024VALUES.Clone();

      [LineNumberTable(7)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static SteamFriends.FriendRelationship valueOf(string name) => (SteamFriends.FriendRelationship) Enum.valueOf((Class) ClassLiteral<SteamFriends.FriendRelationship>.Value, name);

      [LineNumberTable(new byte[] {159, 140, 77, 112, 112, 112, 112, 112, 112, 112, 112, 240, 55, 255, 53, 75})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static FriendRelationship()
      {
        if (ByteCodeHelper.isAlreadyInited("com.codedisaster.steamworks.SteamFriends$FriendRelationship"))
          return;
        SteamFriends.FriendRelationship.__\u003C\u003ENone = new SteamFriends.FriendRelationship(nameof (None), 0);
        SteamFriends.FriendRelationship.__\u003C\u003EBlocked = new SteamFriends.FriendRelationship(nameof (Blocked), 1);
        SteamFriends.FriendRelationship.__\u003C\u003ERecipient = new SteamFriends.FriendRelationship(nameof (Recipient), 2);
        SteamFriends.FriendRelationship.__\u003C\u003EFriend = new SteamFriends.FriendRelationship(nameof (Friend), 3);
        SteamFriends.FriendRelationship.__\u003C\u003ERequestInitiator = new SteamFriends.FriendRelationship(nameof (RequestInitiator), 4);
        SteamFriends.FriendRelationship.__\u003C\u003EIgnored = new SteamFriends.FriendRelationship(nameof (Ignored), 5);
        SteamFriends.FriendRelationship.__\u003C\u003EIgnoredFriend = new SteamFriends.FriendRelationship(nameof (IgnoredFriend), 6);
        SteamFriends.FriendRelationship.__\u003C\u003ESuggested_DEPRECATED = new SteamFriends.FriendRelationship(nameof (Suggested_DEPRECATED), 7);
        SteamFriends.FriendRelationship.__\u003C\u003EMax = new SteamFriends.FriendRelationship(nameof (Max), 8);
        SteamFriends.FriendRelationship.\u0024VALUES = new SteamFriends.FriendRelationship[9]
        {
          SteamFriends.FriendRelationship.__\u003C\u003ENone,
          SteamFriends.FriendRelationship.__\u003C\u003EBlocked,
          SteamFriends.FriendRelationship.__\u003C\u003ERecipient,
          SteamFriends.FriendRelationship.__\u003C\u003EFriend,
          SteamFriends.FriendRelationship.__\u003C\u003ERequestInitiator,
          SteamFriends.FriendRelationship.__\u003C\u003EIgnored,
          SteamFriends.FriendRelationship.__\u003C\u003EIgnoredFriend,
          SteamFriends.FriendRelationship.__\u003C\u003ESuggested_DEPRECATED,
          SteamFriends.FriendRelationship.__\u003C\u003EMax
        };
        SteamFriends.FriendRelationship.values = SteamFriends.FriendRelationship.values();
      }

      [Modifiers]
      public static SteamFriends.FriendRelationship None
      {
        [HideFromJava] get => SteamFriends.FriendRelationship.__\u003C\u003ENone;
      }

      [Modifiers]
      public static SteamFriends.FriendRelationship Blocked
      {
        [HideFromJava] get => SteamFriends.FriendRelationship.__\u003C\u003EBlocked;
      }

      [Modifiers]
      public static SteamFriends.FriendRelationship Recipient
      {
        [HideFromJava] get => SteamFriends.FriendRelationship.__\u003C\u003ERecipient;
      }

      [Modifiers]
      public static SteamFriends.FriendRelationship Friend
      {
        [HideFromJava] get => SteamFriends.FriendRelationship.__\u003C\u003EFriend;
      }

      [Modifiers]
      public static SteamFriends.FriendRelationship RequestInitiator
      {
        [HideFromJava] get => SteamFriends.FriendRelationship.__\u003C\u003ERequestInitiator;
      }

      [Modifiers]
      public static SteamFriends.FriendRelationship Ignored
      {
        [HideFromJava] get => SteamFriends.FriendRelationship.__\u003C\u003EIgnored;
      }

      [Modifiers]
      public static SteamFriends.FriendRelationship IgnoredFriend
      {
        [HideFromJava] get => SteamFriends.FriendRelationship.__\u003C\u003EIgnoredFriend;
      }

      [Modifiers]
      public static SteamFriends.FriendRelationship Suggested_DEPRECATED
      {
        [HideFromJava] get => SteamFriends.FriendRelationship.__\u003C\u003ESuggested_DEPRECATED;
      }

      [Modifiers]
      public static SteamFriends.FriendRelationship Max
      {
        [HideFromJava] get => SteamFriends.FriendRelationship.__\u003C\u003EMax;
      }

      [HideFromJava]
      [Serializable]
      public enum __Enum
      {
        None,
        Blocked,
        Recipient,
        Friend,
        RequestInitiator,
        Ignored,
        IgnoredFriend,
        Suggested_DEPRECATED,
        Max,
      }
    }

    [InnerClass]
    [Signature("Ljava/lang/Enum<Lcom/codedisaster/steamworks/SteamFriends$OverlayDialog;>;")]
    [Modifiers]
    [Serializable]
    public sealed class OverlayDialog : Enum
    {
      [Modifiers]
      internal static SteamFriends.OverlayDialog __\u003C\u003EFriends;
      [Modifiers]
      internal static SteamFriends.OverlayDialog __\u003C\u003ECommunity;
      [Modifiers]
      internal static SteamFriends.OverlayDialog __\u003C\u003EPlayers;
      [Modifiers]
      internal static SteamFriends.OverlayDialog __\u003C\u003ESettings;
      [Modifiers]
      internal static SteamFriends.OverlayDialog __\u003C\u003EOfficialGameGroup;
      [Modifiers]
      internal static SteamFriends.OverlayDialog __\u003C\u003EStats;
      [Modifiers]
      internal static SteamFriends.OverlayDialog __\u003C\u003EAchievements;
      [Modifiers]
      private string id;
      [Modifiers]
      private static SteamFriends.OverlayDialog[] \u0024VALUES;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [Modifiers]
      [LineNumberTable(131)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal static string access\u0024100([In] SteamFriends.OverlayDialog obj0) => obj0.id;

      [Signature("(Ljava/lang/String;)V")]
      [LineNumberTable(new byte[] {93, 106, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private OverlayDialog([In] string obj0, [In] int obj1, [In] string obj2)
        : base(obj0, obj1)
      {
        SteamFriends.OverlayDialog overlayDialog = this;
        this.id = obj2;
        GC.KeepAlive((object) this);
      }

      [LineNumberTable(131)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static SteamFriends.OverlayDialog[] values() => (SteamFriends.OverlayDialog[]) SteamFriends.OverlayDialog.\u0024VALUES.Clone();

      [LineNumberTable(131)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static SteamFriends.OverlayDialog valueOf(string name) => (SteamFriends.OverlayDialog) Enum.valueOf((Class) ClassLiteral<SteamFriends.OverlayDialog>.Value, name);

      [LineNumberTable(new byte[] {159, 109, 109, 117, 117, 117, 117, 117, 117, 245, 56})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static OverlayDialog()
      {
        if (ByteCodeHelper.isAlreadyInited("com.codedisaster.steamworks.SteamFriends$OverlayDialog"))
          return;
        SteamFriends.OverlayDialog.__\u003C\u003EFriends = new SteamFriends.OverlayDialog(nameof (Friends), 0, nameof (Friends));
        SteamFriends.OverlayDialog.__\u003C\u003ECommunity = new SteamFriends.OverlayDialog(nameof (Community), 1, nameof (Community));
        SteamFriends.OverlayDialog.__\u003C\u003EPlayers = new SteamFriends.OverlayDialog(nameof (Players), 2, nameof (Players));
        SteamFriends.OverlayDialog.__\u003C\u003ESettings = new SteamFriends.OverlayDialog(nameof (Settings), 3, nameof (Settings));
        SteamFriends.OverlayDialog.__\u003C\u003EOfficialGameGroup = new SteamFriends.OverlayDialog(nameof (OfficialGameGroup), 4, nameof (OfficialGameGroup));
        SteamFriends.OverlayDialog.__\u003C\u003EStats = new SteamFriends.OverlayDialog(nameof (Stats), 5, nameof (Stats));
        SteamFriends.OverlayDialog.__\u003C\u003EAchievements = new SteamFriends.OverlayDialog(nameof (Achievements), 6, nameof (Achievements));
        SteamFriends.OverlayDialog.\u0024VALUES = new SteamFriends.OverlayDialog[7]
        {
          SteamFriends.OverlayDialog.__\u003C\u003EFriends,
          SteamFriends.OverlayDialog.__\u003C\u003ECommunity,
          SteamFriends.OverlayDialog.__\u003C\u003EPlayers,
          SteamFriends.OverlayDialog.__\u003C\u003ESettings,
          SteamFriends.OverlayDialog.__\u003C\u003EOfficialGameGroup,
          SteamFriends.OverlayDialog.__\u003C\u003EStats,
          SteamFriends.OverlayDialog.__\u003C\u003EAchievements
        };
      }

      [Modifiers]
      public static SteamFriends.OverlayDialog Friends
      {
        [HideFromJava] get => SteamFriends.OverlayDialog.__\u003C\u003EFriends;
      }

      [Modifiers]
      public static SteamFriends.OverlayDialog Community
      {
        [HideFromJava] get => SteamFriends.OverlayDialog.__\u003C\u003ECommunity;
      }

      [Modifiers]
      public static SteamFriends.OverlayDialog Players
      {
        [HideFromJava] get => SteamFriends.OverlayDialog.__\u003C\u003EPlayers;
      }

      [Modifiers]
      public static SteamFriends.OverlayDialog Settings
      {
        [HideFromJava] get => SteamFriends.OverlayDialog.__\u003C\u003ESettings;
      }

      [Modifiers]
      public static SteamFriends.OverlayDialog OfficialGameGroup
      {
        [HideFromJava] get => SteamFriends.OverlayDialog.__\u003C\u003EOfficialGameGroup;
      }

      [Modifiers]
      public static SteamFriends.OverlayDialog Stats
      {
        [HideFromJava] get => SteamFriends.OverlayDialog.__\u003C\u003EStats;
      }

      [Modifiers]
      public static SteamFriends.OverlayDialog Achievements
      {
        [HideFromJava] get => SteamFriends.OverlayDialog.__\u003C\u003EAchievements;
      }

      [HideFromJava]
      [Serializable]
      public enum __Enum
      {
        Friends,
        Community,
        Players,
        Settings,
        OfficialGameGroup,
        Stats,
        Achievements,
      }
    }

    [InnerClass]
    [Signature("Ljava/lang/Enum<Lcom/codedisaster/steamworks/SteamFriends$OverlayToStoreFlag;>;")]
    [Modifiers]
    [Serializable]
    public sealed class OverlayToStoreFlag : Enum
    {
      [Modifiers]
      internal static SteamFriends.OverlayToStoreFlag __\u003C\u003ENone;
      [Modifiers]
      internal static SteamFriends.OverlayToStoreFlag __\u003C\u003EAddToCart;
      [Modifiers]
      internal static SteamFriends.OverlayToStoreFlag __\u003C\u003EAddToCartAndShow;
      [Modifiers]
      private static SteamFriends.OverlayToStoreFlag[] \u0024VALUES;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [Signature("()V")]
      [LineNumberTable(167)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private OverlayToStoreFlag([In] string obj0, [In] int obj1)
        : base(obj0, obj1)
      {
        GC.KeepAlive((object) this);
      }

      [LineNumberTable(167)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static SteamFriends.OverlayToStoreFlag[] values() => (SteamFriends.OverlayToStoreFlag[]) SteamFriends.OverlayToStoreFlag.\u0024VALUES.Clone();

      [LineNumberTable(167)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static SteamFriends.OverlayToStoreFlag valueOf(string name) => (SteamFriends.OverlayToStoreFlag) Enum.valueOf((Class) ClassLiteral<SteamFriends.OverlayToStoreFlag>.Value, name);

      [LineNumberTable(new byte[] {159, 100, 109, 112, 112, 240, 60})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static OverlayToStoreFlag()
      {
        if (ByteCodeHelper.isAlreadyInited("com.codedisaster.steamworks.SteamFriends$OverlayToStoreFlag"))
          return;
        SteamFriends.OverlayToStoreFlag.__\u003C\u003ENone = new SteamFriends.OverlayToStoreFlag(nameof (None), 0);
        SteamFriends.OverlayToStoreFlag.__\u003C\u003EAddToCart = new SteamFriends.OverlayToStoreFlag(nameof (AddToCart), 1);
        SteamFriends.OverlayToStoreFlag.__\u003C\u003EAddToCartAndShow = new SteamFriends.OverlayToStoreFlag(nameof (AddToCartAndShow), 2);
        SteamFriends.OverlayToStoreFlag.\u0024VALUES = new SteamFriends.OverlayToStoreFlag[3]
        {
          SteamFriends.OverlayToStoreFlag.__\u003C\u003ENone,
          SteamFriends.OverlayToStoreFlag.__\u003C\u003EAddToCart,
          SteamFriends.OverlayToStoreFlag.__\u003C\u003EAddToCartAndShow
        };
      }

      [Modifiers]
      public static SteamFriends.OverlayToStoreFlag None
      {
        [HideFromJava] get => SteamFriends.OverlayToStoreFlag.__\u003C\u003ENone;
      }

      [Modifiers]
      public static SteamFriends.OverlayToStoreFlag AddToCart
      {
        [HideFromJava] get => SteamFriends.OverlayToStoreFlag.__\u003C\u003EAddToCart;
      }

      [Modifiers]
      public static SteamFriends.OverlayToStoreFlag AddToCartAndShow
      {
        [HideFromJava] get => SteamFriends.OverlayToStoreFlag.__\u003C\u003EAddToCartAndShow;
      }

      [HideFromJava]
      [Serializable]
      public enum __Enum
      {
        None,
        AddToCart,
        AddToCartAndShow,
      }
    }

    [InnerClass]
    [Signature("Ljava/lang/Enum<Lcom/codedisaster/steamworks/SteamFriends$OverlayToUserDialog;>;")]
    [Modifiers]
    [Serializable]
    public sealed class OverlayToUserDialog : Enum
    {
      [Modifiers]
      internal static SteamFriends.OverlayToUserDialog __\u003C\u003ESteamID;
      [Modifiers]
      internal static SteamFriends.OverlayToUserDialog __\u003C\u003EChat;
      [Modifiers]
      internal static SteamFriends.OverlayToUserDialog __\u003C\u003EJoinTrade;
      [Modifiers]
      internal static SteamFriends.OverlayToUserDialog __\u003C\u003EStats;
      [Modifiers]
      internal static SteamFriends.OverlayToUserDialog __\u003C\u003EAchievements;
      [Modifiers]
      internal static SteamFriends.OverlayToUserDialog __\u003C\u003EFriendAdd;
      [Modifiers]
      internal static SteamFriends.OverlayToUserDialog __\u003C\u003EFriendRemove;
      [Modifiers]
      internal static SteamFriends.OverlayToUserDialog __\u003C\u003EFriendRequestAccept;
      [Modifiers]
      internal static SteamFriends.OverlayToUserDialog __\u003C\u003EFriendRequestIgnore;
      [Modifiers]
      private string id;
      [Modifiers]
      private static SteamFriends.OverlayToUserDialog[] \u0024VALUES;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [Modifiers]
      [LineNumberTable(148)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal static string access\u0024200([In] SteamFriends.OverlayToUserDialog obj0) => obj0.id;

      [Signature("(Ljava/lang/String;)V")]
      [LineNumberTable(new byte[] {112, 106, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private OverlayToUserDialog([In] string obj0, [In] int obj1, [In] string obj2)
        : base(obj0, obj1)
      {
        SteamFriends.OverlayToUserDialog overlayToUserDialog = this;
        this.id = obj2;
        GC.KeepAlive((object) this);
      }

      [LineNumberTable(148)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static SteamFriends.OverlayToUserDialog[] values() => (SteamFriends.OverlayToUserDialog[]) SteamFriends.OverlayToUserDialog.\u0024VALUES.Clone();

      [LineNumberTable(148)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static SteamFriends.OverlayToUserDialog valueOf(string name) => (SteamFriends.OverlayToUserDialog) Enum.valueOf((Class) ClassLiteral<SteamFriends.OverlayToUserDialog>.Value, name);

      [LineNumberTable(new byte[] {159, 105, 141, 117, 117, 117, 117, 117, 117, 117, 117, 245, 54})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static OverlayToUserDialog()
      {
        if (ByteCodeHelper.isAlreadyInited("com.codedisaster.steamworks.SteamFriends$OverlayToUserDialog"))
          return;
        SteamFriends.OverlayToUserDialog.__\u003C\u003ESteamID = new SteamFriends.OverlayToUserDialog(nameof (SteamID), 0, "steamid");
        SteamFriends.OverlayToUserDialog.__\u003C\u003EChat = new SteamFriends.OverlayToUserDialog(nameof (Chat), 1, "chat");
        SteamFriends.OverlayToUserDialog.__\u003C\u003EJoinTrade = new SteamFriends.OverlayToUserDialog(nameof (JoinTrade), 2, "jointrade");
        SteamFriends.OverlayToUserDialog.__\u003C\u003EStats = new SteamFriends.OverlayToUserDialog(nameof (Stats), 3, "stats");
        SteamFriends.OverlayToUserDialog.__\u003C\u003EAchievements = new SteamFriends.OverlayToUserDialog(nameof (Achievements), 4, "achievements");
        SteamFriends.OverlayToUserDialog.__\u003C\u003EFriendAdd = new SteamFriends.OverlayToUserDialog(nameof (FriendAdd), 5, "friendadd");
        SteamFriends.OverlayToUserDialog.__\u003C\u003EFriendRemove = new SteamFriends.OverlayToUserDialog(nameof (FriendRemove), 6, "friendremove");
        SteamFriends.OverlayToUserDialog.__\u003C\u003EFriendRequestAccept = new SteamFriends.OverlayToUserDialog(nameof (FriendRequestAccept), 7, "friendrequestaccept");
        SteamFriends.OverlayToUserDialog.__\u003C\u003EFriendRequestIgnore = new SteamFriends.OverlayToUserDialog(nameof (FriendRequestIgnore), 8, "friendrequestignore");
        SteamFriends.OverlayToUserDialog.\u0024VALUES = new SteamFriends.OverlayToUserDialog[9]
        {
          SteamFriends.OverlayToUserDialog.__\u003C\u003ESteamID,
          SteamFriends.OverlayToUserDialog.__\u003C\u003EChat,
          SteamFriends.OverlayToUserDialog.__\u003C\u003EJoinTrade,
          SteamFriends.OverlayToUserDialog.__\u003C\u003EStats,
          SteamFriends.OverlayToUserDialog.__\u003C\u003EAchievements,
          SteamFriends.OverlayToUserDialog.__\u003C\u003EFriendAdd,
          SteamFriends.OverlayToUserDialog.__\u003C\u003EFriendRemove,
          SteamFriends.OverlayToUserDialog.__\u003C\u003EFriendRequestAccept,
          SteamFriends.OverlayToUserDialog.__\u003C\u003EFriendRequestIgnore
        };
      }

      [Modifiers]
      public static SteamFriends.OverlayToUserDialog SteamID
      {
        [HideFromJava] get => SteamFriends.OverlayToUserDialog.__\u003C\u003ESteamID;
      }

      [Modifiers]
      public static SteamFriends.OverlayToUserDialog Chat
      {
        [HideFromJava] get => SteamFriends.OverlayToUserDialog.__\u003C\u003EChat;
      }

      [Modifiers]
      public static SteamFriends.OverlayToUserDialog JoinTrade
      {
        [HideFromJava] get => SteamFriends.OverlayToUserDialog.__\u003C\u003EJoinTrade;
      }

      [Modifiers]
      public static SteamFriends.OverlayToUserDialog Stats
      {
        [HideFromJava] get => SteamFriends.OverlayToUserDialog.__\u003C\u003EStats;
      }

      [Modifiers]
      public static SteamFriends.OverlayToUserDialog Achievements
      {
        [HideFromJava] get => SteamFriends.OverlayToUserDialog.__\u003C\u003EAchievements;
      }

      [Modifiers]
      public static SteamFriends.OverlayToUserDialog FriendAdd
      {
        [HideFromJava] get => SteamFriends.OverlayToUserDialog.__\u003C\u003EFriendAdd;
      }

      [Modifiers]
      public static SteamFriends.OverlayToUserDialog FriendRemove
      {
        [HideFromJava] get => SteamFriends.OverlayToUserDialog.__\u003C\u003EFriendRemove;
      }

      [Modifiers]
      public static SteamFriends.OverlayToUserDialog FriendRequestAccept
      {
        [HideFromJava] get => SteamFriends.OverlayToUserDialog.__\u003C\u003EFriendRequestAccept;
      }

      [Modifiers]
      public static SteamFriends.OverlayToUserDialog FriendRequestIgnore
      {
        [HideFromJava] get => SteamFriends.OverlayToUserDialog.__\u003C\u003EFriendRequestIgnore;
      }

      [HideFromJava]
      [Serializable]
      public enum __Enum
      {
        SteamID,
        Chat,
        JoinTrade,
        Stats,
        Achievements,
        FriendAdd,
        FriendRemove,
        FriendRequestAccept,
        FriendRequestIgnore,
      }
    }

    [InnerClass]
    [Signature("Ljava/lang/Enum<Lcom/codedisaster/steamworks/SteamFriends$PersonaChange;>;")]
    [Modifiers]
    [Serializable]
    public sealed class PersonaChange : Enum
    {
      [Modifiers]
      internal static SteamFriends.PersonaChange __\u003C\u003EName;
      [Modifiers]
      internal static SteamFriends.PersonaChange __\u003C\u003EStatus;
      [Modifiers]
      internal static SteamFriends.PersonaChange __\u003C\u003EComeOnline;
      [Modifiers]
      internal static SteamFriends.PersonaChange __\u003C\u003EGoneOffline;
      [Modifiers]
      internal static SteamFriends.PersonaChange __\u003C\u003EGamePlayed;
      [Modifiers]
      internal static SteamFriends.PersonaChange __\u003C\u003EGameServer;
      [Modifiers]
      internal static SteamFriends.PersonaChange __\u003C\u003EAvatar;
      [Modifiers]
      internal static SteamFriends.PersonaChange __\u003C\u003EJoinedSource;
      [Modifiers]
      internal static SteamFriends.PersonaChange __\u003C\u003ELeftSource;
      [Modifiers]
      internal static SteamFriends.PersonaChange __\u003C\u003ERelationshipChanged;
      [Modifiers]
      internal static SteamFriends.PersonaChange __\u003C\u003ENameFirstSet;
      [Modifiers]
      internal static SteamFriends.PersonaChange __\u003C\u003EFacebookInfo;
      [Modifiers]
      internal static SteamFriends.PersonaChange __\u003C\u003ENickname;
      [Modifiers]
      internal static SteamFriends.PersonaChange __\u003C\u003ESteamLevel;
      [Modifiers]
      private int bits;
      [Modifiers]
      private static SteamFriends.PersonaChange[] \u0024VALUES;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [Signature("(I)V")]
      [LineNumberTable(new byte[] {43, 106, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private PersonaChange([In] string obj0, [In] int obj1, [In] int obj2)
        : base(obj0, obj1)
      {
        SteamFriends.PersonaChange personaChange = this;
        this.bits = obj2;
        GC.KeepAlive((object) this);
      }

      [LineNumberTable(74)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static SteamFriends.PersonaChange[] values() => (SteamFriends.PersonaChange[]) SteamFriends.PersonaChange.\u0024VALUES.Clone();

      [LineNumberTable(74)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static SteamFriends.PersonaChange valueOf(string name) => (SteamFriends.PersonaChange) Enum.valueOf((Class) ClassLiteral<SteamFriends.PersonaChange>.Value, name);

      [LineNumberTable(98)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal static bool isSet([In] SteamFriends.PersonaChange obj0, [In] int obj1) => (obj0.bits & obj1) == obj0.bits;

      [LineNumberTable(new byte[] {159, 123, 77, 113, 113, 113, 113, 114, 114, 114, 117, 117, 118, 118, 118, 118, 246, 49})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static PersonaChange()
      {
        if (ByteCodeHelper.isAlreadyInited("com.codedisaster.steamworks.SteamFriends$PersonaChange"))
          return;
        SteamFriends.PersonaChange.__\u003C\u003EName = new SteamFriends.PersonaChange(nameof (Name), 0, 1);
        SteamFriends.PersonaChange.__\u003C\u003EStatus = new SteamFriends.PersonaChange(nameof (Status), 1, 2);
        SteamFriends.PersonaChange.__\u003C\u003EComeOnline = new SteamFriends.PersonaChange(nameof (ComeOnline), 2, 4);
        SteamFriends.PersonaChange.__\u003C\u003EGoneOffline = new SteamFriends.PersonaChange(nameof (GoneOffline), 3, 8);
        SteamFriends.PersonaChange.__\u003C\u003EGamePlayed = new SteamFriends.PersonaChange(nameof (GamePlayed), 4, 16);
        SteamFriends.PersonaChange.__\u003C\u003EGameServer = new SteamFriends.PersonaChange(nameof (GameServer), 5, 32);
        SteamFriends.PersonaChange.__\u003C\u003EAvatar = new SteamFriends.PersonaChange(nameof (Avatar), 6, 64);
        SteamFriends.PersonaChange.__\u003C\u003EJoinedSource = new SteamFriends.PersonaChange(nameof (JoinedSource), 7, 128);
        SteamFriends.PersonaChange.__\u003C\u003ELeftSource = new SteamFriends.PersonaChange(nameof (LeftSource), 8, 256);
        SteamFriends.PersonaChange.__\u003C\u003ERelationshipChanged = new SteamFriends.PersonaChange(nameof (RelationshipChanged), 9, 512);
        SteamFriends.PersonaChange.__\u003C\u003ENameFirstSet = new SteamFriends.PersonaChange(nameof (NameFirstSet), 10, 1024);
        SteamFriends.PersonaChange.__\u003C\u003EFacebookInfo = new SteamFriends.PersonaChange(nameof (FacebookInfo), 11, 2048);
        SteamFriends.PersonaChange.__\u003C\u003ENickname = new SteamFriends.PersonaChange(nameof (Nickname), 12, 4096);
        SteamFriends.PersonaChange.__\u003C\u003ESteamLevel = new SteamFriends.PersonaChange(nameof (SteamLevel), 13, 8192);
        SteamFriends.PersonaChange.\u0024VALUES = new SteamFriends.PersonaChange[14]
        {
          SteamFriends.PersonaChange.__\u003C\u003EName,
          SteamFriends.PersonaChange.__\u003C\u003EStatus,
          SteamFriends.PersonaChange.__\u003C\u003EComeOnline,
          SteamFriends.PersonaChange.__\u003C\u003EGoneOffline,
          SteamFriends.PersonaChange.__\u003C\u003EGamePlayed,
          SteamFriends.PersonaChange.__\u003C\u003EGameServer,
          SteamFriends.PersonaChange.__\u003C\u003EAvatar,
          SteamFriends.PersonaChange.__\u003C\u003EJoinedSource,
          SteamFriends.PersonaChange.__\u003C\u003ELeftSource,
          SteamFriends.PersonaChange.__\u003C\u003ERelationshipChanged,
          SteamFriends.PersonaChange.__\u003C\u003ENameFirstSet,
          SteamFriends.PersonaChange.__\u003C\u003EFacebookInfo,
          SteamFriends.PersonaChange.__\u003C\u003ENickname,
          SteamFriends.PersonaChange.__\u003C\u003ESteamLevel
        };
      }

      [Modifiers]
      public static SteamFriends.PersonaChange Name
      {
        [HideFromJava] get => SteamFriends.PersonaChange.__\u003C\u003EName;
      }

      [Modifiers]
      public static SteamFriends.PersonaChange Status
      {
        [HideFromJava] get => SteamFriends.PersonaChange.__\u003C\u003EStatus;
      }

      [Modifiers]
      public static SteamFriends.PersonaChange ComeOnline
      {
        [HideFromJava] get => SteamFriends.PersonaChange.__\u003C\u003EComeOnline;
      }

      [Modifiers]
      public static SteamFriends.PersonaChange GoneOffline
      {
        [HideFromJava] get => SteamFriends.PersonaChange.__\u003C\u003EGoneOffline;
      }

      [Modifiers]
      public static SteamFriends.PersonaChange GamePlayed
      {
        [HideFromJava] get => SteamFriends.PersonaChange.__\u003C\u003EGamePlayed;
      }

      [Modifiers]
      public static SteamFriends.PersonaChange GameServer
      {
        [HideFromJava] get => SteamFriends.PersonaChange.__\u003C\u003EGameServer;
      }

      [Modifiers]
      public static SteamFriends.PersonaChange Avatar
      {
        [HideFromJava] get => SteamFriends.PersonaChange.__\u003C\u003EAvatar;
      }

      [Modifiers]
      public static SteamFriends.PersonaChange JoinedSource
      {
        [HideFromJava] get => SteamFriends.PersonaChange.__\u003C\u003EJoinedSource;
      }

      [Modifiers]
      public static SteamFriends.PersonaChange LeftSource
      {
        [HideFromJava] get => SteamFriends.PersonaChange.__\u003C\u003ELeftSource;
      }

      [Modifiers]
      public static SteamFriends.PersonaChange RelationshipChanged
      {
        [HideFromJava] get => SteamFriends.PersonaChange.__\u003C\u003ERelationshipChanged;
      }

      [Modifiers]
      public static SteamFriends.PersonaChange NameFirstSet
      {
        [HideFromJava] get => SteamFriends.PersonaChange.__\u003C\u003ENameFirstSet;
      }

      [Modifiers]
      public static SteamFriends.PersonaChange FacebookInfo
      {
        [HideFromJava] get => SteamFriends.PersonaChange.__\u003C\u003EFacebookInfo;
      }

      [Modifiers]
      public static SteamFriends.PersonaChange Nickname
      {
        [HideFromJava] get => SteamFriends.PersonaChange.__\u003C\u003ENickname;
      }

      [Modifiers]
      public static SteamFriends.PersonaChange SteamLevel
      {
        [HideFromJava] get => SteamFriends.PersonaChange.__\u003C\u003ESteamLevel;
      }

      [HideFromJava]
      [Serializable]
      public enum __Enum
      {
        Name,
        Status,
        ComeOnline,
        GoneOffline,
        GamePlayed,
        GameServer,
        Avatar,
        JoinedSource,
        LeftSource,
        RelationshipChanged,
        NameFirstSet,
        FacebookInfo,
        Nickname,
        SteamLevel,
      }
    }

    [InnerClass]
    [Signature("Ljava/lang/Enum<Lcom/codedisaster/steamworks/SteamFriends$PersonaState;>;")]
    [Modifiers]
    [Serializable]
    public sealed class PersonaState : Enum
    {
      [Modifiers]
      internal static SteamFriends.PersonaState __\u003C\u003EOffline;
      [Modifiers]
      internal static SteamFriends.PersonaState __\u003C\u003EOnline;
      [Modifiers]
      internal static SteamFriends.PersonaState __\u003C\u003EBusy;
      [Modifiers]
      internal static SteamFriends.PersonaState __\u003C\u003EAway;
      [Modifiers]
      internal static SteamFriends.PersonaState __\u003C\u003ESnooze;
      [Modifiers]
      internal static SteamFriends.PersonaState __\u003C\u003ELookingToTrade;
      [Modifiers]
      internal static SteamFriends.PersonaState __\u003C\u003ELookingToPlay;
      [Modifiers]
      private static SteamFriends.PersonaState[] values;
      [Modifiers]
      private static SteamFriends.PersonaState[] \u0024VALUES;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(37)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal static SteamFriends.PersonaState byOrdinal([In] int obj0) => SteamFriends.PersonaState.values[obj0];

      [Signature("()V")]
      [LineNumberTable(25)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private PersonaState([In] string obj0, [In] int obj1)
        : base(obj0, obj1)
      {
        GC.KeepAlive((object) this);
      }

      [LineNumberTable(25)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static SteamFriends.PersonaState[] values() => (SteamFriends.PersonaState[]) SteamFriends.PersonaState.\u0024VALUES.Clone();

      [LineNumberTable(25)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static SteamFriends.PersonaState valueOf(string name) => (SteamFriends.PersonaState) Enum.valueOf((Class) ClassLiteral<SteamFriends.PersonaState>.Value, name);

      [LineNumberTable(new byte[] {159, 136, 141, 112, 112, 112, 112, 112, 112, 240, 57, 255, 36, 73})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static PersonaState()
      {
        if (ByteCodeHelper.isAlreadyInited("com.codedisaster.steamworks.SteamFriends$PersonaState"))
          return;
        SteamFriends.PersonaState.__\u003C\u003EOffline = new SteamFriends.PersonaState(nameof (Offline), 0);
        SteamFriends.PersonaState.__\u003C\u003EOnline = new SteamFriends.PersonaState(nameof (Online), 1);
        SteamFriends.PersonaState.__\u003C\u003EBusy = new SteamFriends.PersonaState(nameof (Busy), 2);
        SteamFriends.PersonaState.__\u003C\u003EAway = new SteamFriends.PersonaState(nameof (Away), 3);
        SteamFriends.PersonaState.__\u003C\u003ESnooze = new SteamFriends.PersonaState(nameof (Snooze), 4);
        SteamFriends.PersonaState.__\u003C\u003ELookingToTrade = new SteamFriends.PersonaState(nameof (LookingToTrade), 5);
        SteamFriends.PersonaState.__\u003C\u003ELookingToPlay = new SteamFriends.PersonaState(nameof (LookingToPlay), 6);
        SteamFriends.PersonaState.\u0024VALUES = new SteamFriends.PersonaState[7]
        {
          SteamFriends.PersonaState.__\u003C\u003EOffline,
          SteamFriends.PersonaState.__\u003C\u003EOnline,
          SteamFriends.PersonaState.__\u003C\u003EBusy,
          SteamFriends.PersonaState.__\u003C\u003EAway,
          SteamFriends.PersonaState.__\u003C\u003ESnooze,
          SteamFriends.PersonaState.__\u003C\u003ELookingToTrade,
          SteamFriends.PersonaState.__\u003C\u003ELookingToPlay
        };
        SteamFriends.PersonaState.values = SteamFriends.PersonaState.values();
      }

      [Modifiers]
      public static SteamFriends.PersonaState Offline
      {
        [HideFromJava] get => SteamFriends.PersonaState.__\u003C\u003EOffline;
      }

      [Modifiers]
      public static SteamFriends.PersonaState Online
      {
        [HideFromJava] get => SteamFriends.PersonaState.__\u003C\u003EOnline;
      }

      [Modifiers]
      public static SteamFriends.PersonaState Busy
      {
        [HideFromJava] get => SteamFriends.PersonaState.__\u003C\u003EBusy;
      }

      [Modifiers]
      public static SteamFriends.PersonaState Away
      {
        [HideFromJava] get => SteamFriends.PersonaState.__\u003C\u003EAway;
      }

      [Modifiers]
      public static SteamFriends.PersonaState Snooze
      {
        [HideFromJava] get => SteamFriends.PersonaState.__\u003C\u003ESnooze;
      }

      [Modifiers]
      public static SteamFriends.PersonaState LookingToTrade
      {
        [HideFromJava] get => SteamFriends.PersonaState.__\u003C\u003ELookingToTrade;
      }

      [Modifiers]
      public static SteamFriends.PersonaState LookingToPlay
      {
        [HideFromJava] get => SteamFriends.PersonaState.__\u003C\u003ELookingToPlay;
      }

      [HideFromJava]
      [Serializable]
      public enum __Enum
      {
        Offline,
        Online,
        Busy,
        Away,
        Snooze,
        LookingToTrade,
        LookingToPlay,
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
