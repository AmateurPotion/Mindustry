// Decompiled with JetBrains decompiler
// Type: com.codedisaster.steamworks.SteamUserStats
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace com.codedisaster.steamworks
{
  public class SteamUserStats : SteamInterface
  {
    static IntPtr __\u003Cjniptr\u003EcreateCallback\u0028Lcom\u002Fcodedisaster\u002Fsteamworks\u002FSteamUserStatsCallbackAdapter\u003B\u0029J;
    [SpecialName]
    private static CallerID __\u003CcallerID\u003E;
    static IntPtr __\u003Cjniptr\u003ErequestCurrentStats\u0028J\u0029Z;
    static IntPtr __\u003Cjniptr\u003EgetStat\u0028JLjava\u002Flang\u002FString\u003B\u005BI\u0029Z;
    static IntPtr __\u003Cjniptr\u003EsetStat\u0028JLjava\u002Flang\u002FString\u003BI\u0029Z;
    static IntPtr __\u003Cjniptr\u003EgetStat\u0028JLjava\u002Flang\u002FString\u003B\u005BF\u0029Z;
    static IntPtr __\u003Cjniptr\u003EsetStat\u0028JLjava\u002Flang\u002FString\u003BF\u0029Z;
    static IntPtr __\u003Cjniptr\u003EgetAchievement\u0028JLjava\u002Flang\u002FString\u003B\u005BZ\u0029Z;
    static IntPtr __\u003Cjniptr\u003EsetAchievement\u0028JLjava\u002Flang\u002FString\u003B\u0029Z;
    static IntPtr __\u003Cjniptr\u003EclearAchievement\u0028JLjava\u002Flang\u002FString\u003B\u0029Z;
    static IntPtr __\u003Cjniptr\u003EstoreStats\u0028J\u0029Z;
    static IntPtr __\u003Cjniptr\u003EindicateAchievementProgress\u0028JLjava\u002Flang\u002FString\u003BII\u0029Z;
    static IntPtr __\u003Cjniptr\u003EgetNumAchievements\u0028J\u0029I;
    static IntPtr __\u003Cjniptr\u003EgetAchievementName\u0028JI\u0029Ljava\u002Flang\u002FString\u003B;
    static IntPtr __\u003Cjniptr\u003EresetAllStats\u0028JZ\u0029Z;
    static IntPtr __\u003Cjniptr\u003EfindOrCreateLeaderboard\u0028JJLjava\u002Flang\u002FString\u003BII\u0029J;
    static IntPtr __\u003Cjniptr\u003EfindLeaderboard\u0028JJLjava\u002Flang\u002FString\u003B\u0029J;
    static IntPtr __\u003Cjniptr\u003EgetLeaderboardName\u0028JJ\u0029Ljava\u002Flang\u002FString\u003B;
    static IntPtr __\u003Cjniptr\u003EgetLeaderboardEntryCount\u0028JJ\u0029I;
    static IntPtr __\u003Cjniptr\u003EgetLeaderboardSortMethod\u0028JJ\u0029I;
    static IntPtr __\u003Cjniptr\u003EgetLeaderboardDisplayType\u0028JJ\u0029I;
    static IntPtr __\u003Cjniptr\u003EdownloadLeaderboardEntries\u0028JJJIII\u0029J;
    static IntPtr __\u003Cjniptr\u003EdownloadLeaderboardEntriesForUsers\u0028JJJ\u005BJI\u0029J;
    static IntPtr __\u003Cjniptr\u003EgetDownloadedLeaderboardEntry\u0028JJILcom\u002Fcodedisaster\u002Fsteamworks\u002FSteamLeaderboardEntry\u003B\u005BII\u0029Z;
    static IntPtr __\u003Cjniptr\u003EgetDownloadedLeaderboardEntry\u0028JJILcom\u002Fcodedisaster\u002Fsteamworks\u002FSteamLeaderboardEntry\u003B\u0029Z;
    static IntPtr __\u003Cjniptr\u003EuploadLeaderboardScore\u0028JJJII\u005BII\u0029J;
    static IntPtr __\u003Cjniptr\u003EuploadLeaderboardScore\u0028JJJII\u0029J;
    static IntPtr __\u003Cjniptr\u003ErequestGlobalStats\u0028JJI\u0029J;
    static IntPtr __\u003Cjniptr\u003EgetGlobalStat\u0028JLjava\u002Flang\u002FString\u003B\u005BJ\u0029Z;
    static IntPtr __\u003Cjniptr\u003EgetGlobalStat\u0028JLjava\u002Flang\u002FString\u003B\u005BD\u0029Z;
    static IntPtr __\u003Cjniptr\u003EgetGlobalStatHistory\u0028JLjava\u002Flang\u002FString\u003B\u005BJI\u0029I;
    static IntPtr __\u003Cjniptr\u003EgetGlobalStatHistory\u0028JLjava\u002Flang\u002FString\u003B\u005BDI\u0029I;

    [LineNumberTable(new byte[] {159, 174, 118})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public SteamUserStats(SteamUserStatsCallback callback)
      : base(SteamAPI.getSteamUserStatsPointer(), SteamUserStats.createCallback(new SteamUserStatsCallbackAdapter(callback)))
    {
    }

    [LineNumberTable(36)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool requestCurrentStats() => SteamUserStats.requestCurrentStats(this.pointer);

    [LineNumberTable(80)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool storeStats() => SteamUserStats.storeStats(this.pointer);

    [LineNumberTable(new byte[] {159, 182, 103, 111, 132})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getStatI(string name, int defaultValue)
    {
      int[] numArray = new int[1];
      return SteamUserStats.getStat(this.pointer, name, numArray) ? numArray[0] : defaultValue;
    }

    [LineNumberTable(48)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool setStatI(string name, int value) => SteamUserStats.setStat(this.pointer, name, value);

    [LineNumberTable(72)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool setAchievement(string name) => SteamUserStats.setAchievement(this.pointer, name);

    [LineNumberTable(new byte[] {159, 126, 66, 103, 111, 132})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isAchieved(string name, bool defaultValue)
    {
      int num = defaultValue ? 1 : 0;
      bool[] flagArray = new bool[1];
      return SteamUserStats.getAchievement(this.pointer, name, flagArray) ? flagArray[0] : num != 0;
    }

    [Modifiers]
    private static long createCallback([In] SteamUserStatsCallbackAdapter obj0)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamUserStats.__\u003Cjniptr\u003EcreateCallback\u0028Lcom\u002Fcodedisaster\u002Fsteamworks\u002FSteamUserStatsCallbackAdapter\u003B\u0029J == IntPtr.Zero)
        SteamUserStats.__\u003Cjniptr\u003EcreateCallback\u0028Lcom\u002Fcodedisaster\u002Fsteamworks\u002FSteamUserStatsCallbackAdapter\u003B\u0029J = JNI.Frame.GetFuncPtr(SteamUserStats.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamUserStats", nameof (createCallback), "(Lcom/codedisaster/steamworks/SteamUserStatsCallbackAdapter;)J");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamUserStats.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamUserStats>.Value);
        IntPtr num4 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj0);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<long (IntPtr, IntPtr, IntPtr)>) SteamUserStats.__\u003Cjniptr\u003EcreateCallback\u0028Lcom\u002Fcodedisaster\u002Fsteamworks\u002FSteamUserStatsCallbackAdapter\u003B\u0029J)(num2, num3, num4);
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
    private static bool requestCurrentStats([In] long obj0)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamUserStats.__\u003Cjniptr\u003ErequestCurrentStats\u0028J\u0029Z == IntPtr.Zero)
        SteamUserStats.__\u003Cjniptr\u003ErequestCurrentStats\u0028J\u0029Z = JNI.Frame.GetFuncPtr(SteamUserStats.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamUserStats", nameof (requestCurrentStats), "(J)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamUserStats.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamUserStats>.Value);
        long num4 = obj0;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, long)>) SteamUserStats.__\u003Cjniptr\u003ErequestCurrentStats\u0028J\u0029Z)((long) num2, num3, (IntPtr) num4);
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
    private static bool getStat([In] long obj0, [In] string obj1, [In] int[] obj2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamUserStats.__\u003Cjniptr\u003EgetStat\u0028JLjava\u002Flang\u002FString\u003B\u005BI\u0029Z == IntPtr.Zero)
        SteamUserStats.__\u003Cjniptr\u003EgetStat\u0028JLjava\u002Flang\u002FString\u003B\u005BI\u0029Z = JNI.Frame.GetFuncPtr(SteamUserStats.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamUserStats", nameof (getStat), "(JLjava/lang/String;[I)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamUserStats.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamUserStats>.Value);
        long num4 = obj0;
        IntPtr num5 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj1);
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj2);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, long, IntPtr, IntPtr)>) SteamUserStats.__\u003Cjniptr\u003EgetStat\u0028JLjava\u002Flang\u002FString\u003B\u005BI\u0029Z)(num2, num3, num4, num5, num6);
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
    private static bool setStat([In] long obj0, [In] string obj1, [In] int obj2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamUserStats.__\u003Cjniptr\u003EsetStat\u0028JLjava\u002Flang\u002FString\u003BI\u0029Z == IntPtr.Zero)
        SteamUserStats.__\u003Cjniptr\u003EsetStat\u0028JLjava\u002Flang\u002FString\u003BI\u0029Z = JNI.Frame.GetFuncPtr(SteamUserStats.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamUserStats", nameof (setStat), "(JLjava/lang/String;I)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamUserStats.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamUserStats>.Value);
        long num4 = obj0;
        IntPtr num5 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj1);
        int num6 = obj2;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, long, IntPtr, int)>) SteamUserStats.__\u003Cjniptr\u003EsetStat\u0028JLjava\u002Flang\u002FString\u003BI\u0029Z)((int) num2, num3, num4, num5, (IntPtr) num6);
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
    private static bool getStat([In] long obj0, [In] string obj1, [In] float[] obj2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamUserStats.__\u003Cjniptr\u003EgetStat\u0028JLjava\u002Flang\u002FString\u003B\u005BF\u0029Z == IntPtr.Zero)
        SteamUserStats.__\u003Cjniptr\u003EgetStat\u0028JLjava\u002Flang\u002FString\u003B\u005BF\u0029Z = JNI.Frame.GetFuncPtr(SteamUserStats.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamUserStats", nameof (getStat), "(JLjava/lang/String;[F)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamUserStats.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamUserStats>.Value);
        long num4 = obj0;
        IntPtr num5 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj1);
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj2);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, long, IntPtr, IntPtr)>) SteamUserStats.__\u003Cjniptr\u003EgetStat\u0028JLjava\u002Flang\u002FString\u003B\u005BF\u0029Z)(num2, num3, num4, num5, num6);
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
    private static bool setStat([In] long obj0, [In] string obj1, [In] float obj2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamUserStats.__\u003Cjniptr\u003EsetStat\u0028JLjava\u002Flang\u002FString\u003BF\u0029Z == IntPtr.Zero)
        SteamUserStats.__\u003Cjniptr\u003EsetStat\u0028JLjava\u002Flang\u002FString\u003BF\u0029Z = JNI.Frame.GetFuncPtr(SteamUserStats.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamUserStats", nameof (setStat), "(JLjava/lang/String;F)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamUserStats.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamUserStats>.Value);
        long num4 = obj0;
        IntPtr num5 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj1);
        double num6 = (double) obj2;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, long, IntPtr, float)>) SteamUserStats.__\u003Cjniptr\u003EsetStat\u0028JLjava\u002Flang\u002FString\u003BF\u0029Z)((float) num2, num3, num4, num5, (IntPtr) num6);
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
    private static bool getAchievement([In] long obj0, [In] string obj1, [In] bool[] obj2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamUserStats.__\u003Cjniptr\u003EgetAchievement\u0028JLjava\u002Flang\u002FString\u003B\u005BZ\u0029Z == IntPtr.Zero)
        SteamUserStats.__\u003Cjniptr\u003EgetAchievement\u0028JLjava\u002Flang\u002FString\u003B\u005BZ\u0029Z = JNI.Frame.GetFuncPtr(SteamUserStats.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamUserStats", nameof (getAchievement), "(JLjava/lang/String;[Z)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamUserStats.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamUserStats>.Value);
        long num4 = obj0;
        IntPtr num5 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj1);
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj2);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, long, IntPtr, IntPtr)>) SteamUserStats.__\u003Cjniptr\u003EgetAchievement\u0028JLjava\u002Flang\u002FString\u003B\u005BZ\u0029Z)(num2, num3, num4, num5, num6);
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
    private static bool setAchievement([In] long obj0, [In] string obj1)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamUserStats.__\u003Cjniptr\u003EsetAchievement\u0028JLjava\u002Flang\u002FString\u003B\u0029Z == IntPtr.Zero)
        SteamUserStats.__\u003Cjniptr\u003EsetAchievement\u0028JLjava\u002Flang\u002FString\u003B\u0029Z = JNI.Frame.GetFuncPtr(SteamUserStats.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamUserStats", nameof (setAchievement), "(JLjava/lang/String;)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamUserStats.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamUserStats>.Value);
        long num4 = obj0;
        IntPtr num5 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj1);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, long, IntPtr)>) SteamUserStats.__\u003Cjniptr\u003EsetAchievement\u0028JLjava\u002Flang\u002FString\u003B\u0029Z)(num2, (long) num3, (IntPtr) num4, num5);
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
    private static bool clearAchievement([In] long obj0, [In] string obj1)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamUserStats.__\u003Cjniptr\u003EclearAchievement\u0028JLjava\u002Flang\u002FString\u003B\u0029Z == IntPtr.Zero)
        SteamUserStats.__\u003Cjniptr\u003EclearAchievement\u0028JLjava\u002Flang\u002FString\u003B\u0029Z = JNI.Frame.GetFuncPtr(SteamUserStats.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamUserStats", nameof (clearAchievement), "(JLjava/lang/String;)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamUserStats.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamUserStats>.Value);
        long num4 = obj0;
        IntPtr num5 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj1);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, long, IntPtr)>) SteamUserStats.__\u003Cjniptr\u003EclearAchievement\u0028JLjava\u002Flang\u002FString\u003B\u0029Z)(num2, (long) num3, (IntPtr) num4, num5);
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
    private static bool storeStats([In] long obj0)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamUserStats.__\u003Cjniptr\u003EstoreStats\u0028J\u0029Z == IntPtr.Zero)
        SteamUserStats.__\u003Cjniptr\u003EstoreStats\u0028J\u0029Z = JNI.Frame.GetFuncPtr(SteamUserStats.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamUserStats", nameof (storeStats), "(J)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamUserStats.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamUserStats>.Value);
        long num4 = obj0;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, long)>) SteamUserStats.__\u003Cjniptr\u003EstoreStats\u0028J\u0029Z)((long) num2, num3, (IntPtr) num4);
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
    private static bool indicateAchievementProgress([In] long obj0, [In] string obj1, [In] int obj2, [In] int obj3)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamUserStats.__\u003Cjniptr\u003EindicateAchievementProgress\u0028JLjava\u002Flang\u002FString\u003BII\u0029Z == IntPtr.Zero)
        SteamUserStats.__\u003Cjniptr\u003EindicateAchievementProgress\u0028JLjava\u002Flang\u002FString\u003BII\u0029Z = JNI.Frame.GetFuncPtr(SteamUserStats.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamUserStats", nameof (indicateAchievementProgress), "(JLjava/lang/String;II)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamUserStats.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamUserStats>.Value);
        long num4 = obj0;
        IntPtr num5 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj1);
        int num6 = obj2;
        int num7 = obj3;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, long, IntPtr, int, int)>) SteamUserStats.__\u003Cjniptr\u003EindicateAchievementProgress\u0028JLjava\u002Flang\u002FString\u003BII\u0029Z)((int) num2, (int) num3, (IntPtr) num4, (long) num5, (IntPtr) num6, (IntPtr) num7);
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
    private static int getNumAchievements([In] long obj0)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamUserStats.__\u003Cjniptr\u003EgetNumAchievements\u0028J\u0029I == IntPtr.Zero)
        SteamUserStats.__\u003Cjniptr\u003EgetNumAchievements\u0028J\u0029I = JNI.Frame.GetFuncPtr(SteamUserStats.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamUserStats", nameof (getNumAchievements), "(J)I");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamUserStats.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamUserStats>.Value);
        long num4 = obj0;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<int (IntPtr, IntPtr, long)>) SteamUserStats.__\u003Cjniptr\u003EgetNumAchievements\u0028J\u0029I)((long) num2, num3, (IntPtr) num4);
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
    private static string getAchievementName([In] long obj0, [In] int obj1)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamUserStats.__\u003Cjniptr\u003EgetAchievementName\u0028JI\u0029Ljava\u002Flang\u002FString\u003B == IntPtr.Zero)
        SteamUserStats.__\u003Cjniptr\u003EgetAchievementName\u0028JI\u0029Ljava\u002Flang\u002FString\u003B = JNI.Frame.GetFuncPtr(SteamUserStats.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamUserStats", nameof (getAchievementName), "(JI)Ljava/lang/String;");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamUserStats.__\u003CGetCallerID\u003E());
      try
      {
        ref JNI.Frame local = ref frame;
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamUserStats>.Value);
        long num4 = obj0;
        int num5 = obj1;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        IntPtr num6 = __calli((__FnPtr<IntPtr (IntPtr, IntPtr, long, int)>) SteamUserStats.__\u003Cjniptr\u003EgetAchievementName\u0028JI\u0029Ljava\u002Flang\u002FString\u003B)((int) num2, (long) num3, (IntPtr) num4, (IntPtr) num5);
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
    private static bool resetAllStats([In] long obj0, [In] bool obj1)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamUserStats.__\u003Cjniptr\u003EresetAllStats\u0028JZ\u0029Z == IntPtr.Zero)
        SteamUserStats.__\u003Cjniptr\u003EresetAllStats\u0028JZ\u0029Z = JNI.Frame.GetFuncPtr(SteamUserStats.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamUserStats", nameof (resetAllStats), "(JZ)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamUserStats.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamUserStats>.Value);
        long num4 = obj0;
        int num5 = obj1 ? 1 : 0;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, long, bool)>) SteamUserStats.__\u003Cjniptr\u003EresetAllStats\u0028JZ\u0029Z)((bool) num2, (long) num3, (IntPtr) num4, (IntPtr) num5);
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
    private static long findOrCreateLeaderboard(
      [In] long obj0,
      [In] long obj1,
      [In] string obj2,
      [In] int obj3,
      [In] int obj4)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamUserStats.__\u003Cjniptr\u003EfindOrCreateLeaderboard\u0028JJLjava\u002Flang\u002FString\u003BII\u0029J == IntPtr.Zero)
        SteamUserStats.__\u003Cjniptr\u003EfindOrCreateLeaderboard\u0028JJLjava\u002Flang\u002FString\u003BII\u0029J = JNI.Frame.GetFuncPtr(SteamUserStats.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamUserStats", nameof (findOrCreateLeaderboard), "(JJLjava/lang/String;II)J");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamUserStats.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamUserStats>.Value);
        long num4 = obj0;
        long num5 = obj1;
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj2);
        int num7 = obj3;
        int num8 = obj4;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<long (IntPtr, IntPtr, long, long, IntPtr, int, int)>) SteamUserStats.__\u003Cjniptr\u003EfindOrCreateLeaderboard\u0028JJLjava\u002Flang\u002FString\u003BII\u0029J)((int) num2, (int) num3, (IntPtr) num4, num5, (long) num6, (IntPtr) num7, (IntPtr) num8);
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
    private static long findLeaderboard([In] long obj0, [In] long obj1, [In] string obj2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamUserStats.__\u003Cjniptr\u003EfindLeaderboard\u0028JJLjava\u002Flang\u002FString\u003B\u0029J == IntPtr.Zero)
        SteamUserStats.__\u003Cjniptr\u003EfindLeaderboard\u0028JJLjava\u002Flang\u002FString\u003B\u0029J = JNI.Frame.GetFuncPtr(SteamUserStats.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamUserStats", nameof (findLeaderboard), "(JJLjava/lang/String;)J");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamUserStats.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamUserStats>.Value);
        long num4 = obj0;
        long num5 = obj1;
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj2);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<long (IntPtr, IntPtr, long, long, IntPtr)>) SteamUserStats.__\u003Cjniptr\u003EfindLeaderboard\u0028JJLjava\u002Flang\u002FString\u003B\u0029J)(num2, (long) num3, num4, (IntPtr) num5, num6);
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
    private static string getLeaderboardName([In] long obj0, [In] long obj1)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamUserStats.__\u003Cjniptr\u003EgetLeaderboardName\u0028JJ\u0029Ljava\u002Flang\u002FString\u003B == IntPtr.Zero)
        SteamUserStats.__\u003Cjniptr\u003EgetLeaderboardName\u0028JJ\u0029Ljava\u002Flang\u002FString\u003B = JNI.Frame.GetFuncPtr(SteamUserStats.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamUserStats", nameof (getLeaderboardName), "(JJ)Ljava/lang/String;");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamUserStats.__\u003CGetCallerID\u003E());
      try
      {
        ref JNI.Frame local = ref frame;
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamUserStats>.Value);
        long num4 = obj0;
        long num5 = obj1;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        IntPtr num6 = __calli((__FnPtr<IntPtr (IntPtr, IntPtr, long, long)>) SteamUserStats.__\u003Cjniptr\u003EgetLeaderboardName\u0028JJ\u0029Ljava\u002Flang\u002FString\u003B)((long) num2, (long) num3, (IntPtr) num4, (IntPtr) num5);
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
    private static int getLeaderboardEntryCount([In] long obj0, [In] long obj1)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamUserStats.__\u003Cjniptr\u003EgetLeaderboardEntryCount\u0028JJ\u0029I == IntPtr.Zero)
        SteamUserStats.__\u003Cjniptr\u003EgetLeaderboardEntryCount\u0028JJ\u0029I = JNI.Frame.GetFuncPtr(SteamUserStats.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamUserStats", nameof (getLeaderboardEntryCount), "(JJ)I");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamUserStats.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamUserStats>.Value);
        long num4 = obj0;
        long num5 = obj1;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<int (IntPtr, IntPtr, long, long)>) SteamUserStats.__\u003Cjniptr\u003EgetLeaderboardEntryCount\u0028JJ\u0029I)((long) num2, (long) num3, (IntPtr) num4, (IntPtr) num5);
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
    private static int getLeaderboardSortMethod([In] long obj0, [In] long obj1)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamUserStats.__\u003Cjniptr\u003EgetLeaderboardSortMethod\u0028JJ\u0029I == IntPtr.Zero)
        SteamUserStats.__\u003Cjniptr\u003EgetLeaderboardSortMethod\u0028JJ\u0029I = JNI.Frame.GetFuncPtr(SteamUserStats.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamUserStats", nameof (getLeaderboardSortMethod), "(JJ)I");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamUserStats.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamUserStats>.Value);
        long num4 = obj0;
        long num5 = obj1;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<int (IntPtr, IntPtr, long, long)>) SteamUserStats.__\u003Cjniptr\u003EgetLeaderboardSortMethod\u0028JJ\u0029I)((long) num2, (long) num3, (IntPtr) num4, (IntPtr) num5);
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
    private static int getLeaderboardDisplayType([In] long obj0, [In] long obj1)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamUserStats.__\u003Cjniptr\u003EgetLeaderboardDisplayType\u0028JJ\u0029I == IntPtr.Zero)
        SteamUserStats.__\u003Cjniptr\u003EgetLeaderboardDisplayType\u0028JJ\u0029I = JNI.Frame.GetFuncPtr(SteamUserStats.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamUserStats", nameof (getLeaderboardDisplayType), "(JJ)I");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamUserStats.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamUserStats>.Value);
        long num4 = obj0;
        long num5 = obj1;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<int (IntPtr, IntPtr, long, long)>) SteamUserStats.__\u003Cjniptr\u003EgetLeaderboardDisplayType\u0028JJ\u0029I)((long) num2, (long) num3, (IntPtr) num4, (IntPtr) num5);
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
    private static long downloadLeaderboardEntries(
      [In] long obj0,
      [In] long obj1,
      [In] long obj2,
      [In] int obj3,
      [In] int obj4,
      [In] int obj5)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamUserStats.__\u003Cjniptr\u003EdownloadLeaderboardEntries\u0028JJJIII\u0029J == IntPtr.Zero)
        SteamUserStats.__\u003Cjniptr\u003EdownloadLeaderboardEntries\u0028JJJIII\u0029J = JNI.Frame.GetFuncPtr(SteamUserStats.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamUserStats", nameof (downloadLeaderboardEntries), "(JJJIII)J");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamUserStats.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamUserStats>.Value);
        long num4 = obj0;
        long num5 = obj1;
        long num6 = obj2;
        int num7 = obj3;
        int num8 = obj4;
        int num9 = obj5;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<long (IntPtr, IntPtr, long, long, long, int, int, int)>) SteamUserStats.__\u003Cjniptr\u003EdownloadLeaderboardEntries\u0028JJJIII\u0029J)((int) num2, (int) num3, (int) num4, num5, num6, (long) num7, (IntPtr) num8, (IntPtr) num9);
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
    private static long downloadLeaderboardEntriesForUsers(
      [In] long obj0,
      [In] long obj1,
      [In] long obj2,
      [In] long[] obj3,
      [In] int obj4)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamUserStats.__\u003Cjniptr\u003EdownloadLeaderboardEntriesForUsers\u0028JJJ\u005BJI\u0029J == IntPtr.Zero)
        SteamUserStats.__\u003Cjniptr\u003EdownloadLeaderboardEntriesForUsers\u0028JJJ\u005BJI\u0029J = JNI.Frame.GetFuncPtr(SteamUserStats.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamUserStats", nameof (downloadLeaderboardEntriesForUsers), "(JJJ[JI)J");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamUserStats.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamUserStats>.Value);
        long num4 = obj0;
        long num5 = obj1;
        long num6 = obj2;
        IntPtr num7 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj3);
        int num8 = obj4;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<long (IntPtr, IntPtr, long, long, long, IntPtr, int)>) SteamUserStats.__\u003Cjniptr\u003EdownloadLeaderboardEntriesForUsers\u0028JJJ\u005BJI\u0029J)((int) num2, num3, num4, num5, num6, num7, (IntPtr) num8);
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
    private static bool getDownloadedLeaderboardEntry(
      [In] long obj0,
      [In] long obj1,
      [In] int obj2,
      [In] SteamLeaderboardEntry obj3)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamUserStats.__\u003Cjniptr\u003EgetDownloadedLeaderboardEntry\u0028JJILcom\u002Fcodedisaster\u002Fsteamworks\u002FSteamLeaderboardEntry\u003B\u0029Z == IntPtr.Zero)
        SteamUserStats.__\u003Cjniptr\u003EgetDownloadedLeaderboardEntry\u0028JJILcom\u002Fcodedisaster\u002Fsteamworks\u002FSteamLeaderboardEntry\u003B\u0029Z = JNI.Frame.GetFuncPtr(SteamUserStats.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamUserStats", nameof (getDownloadedLeaderboardEntry), "(JJILcom/codedisaster/steamworks/SteamLeaderboardEntry;)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamUserStats.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamUserStats>.Value);
        long num4 = obj0;
        long num5 = obj1;
        int num6 = obj2;
        IntPtr num7 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj3);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, long, long, int, IntPtr)>) SteamUserStats.__\u003Cjniptr\u003EgetDownloadedLeaderboardEntry\u0028JJILcom\u002Fcodedisaster\u002Fsteamworks\u002FSteamLeaderboardEntry\u003B\u0029Z)(num2, (int) num3, num4, num5, (IntPtr) num6, num7);
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
    private static bool getDownloadedLeaderboardEntry(
      [In] long obj0,
      [In] long obj1,
      [In] int obj2,
      [In] SteamLeaderboardEntry obj3,
      [In] int[] obj4,
      [In] int obj5)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamUserStats.__\u003Cjniptr\u003EgetDownloadedLeaderboardEntry\u0028JJILcom\u002Fcodedisaster\u002Fsteamworks\u002FSteamLeaderboardEntry\u003B\u005BII\u0029Z == IntPtr.Zero)
        SteamUserStats.__\u003Cjniptr\u003EgetDownloadedLeaderboardEntry\u0028JJILcom\u002Fcodedisaster\u002Fsteamworks\u002FSteamLeaderboardEntry\u003B\u005BII\u0029Z = JNI.Frame.GetFuncPtr(SteamUserStats.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamUserStats", nameof (getDownloadedLeaderboardEntry), "(JJILcom/codedisaster/steamworks/SteamLeaderboardEntry;[II)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamUserStats.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamUserStats>.Value);
        long num4 = obj0;
        long num5 = obj1;
        int num6 = obj2;
        IntPtr num7 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj3);
        IntPtr num8 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj4);
        int num9 = obj5;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, long, long, int, IntPtr, IntPtr, int)>) SteamUserStats.__\u003Cjniptr\u003EgetDownloadedLeaderboardEntry\u0028JJILcom\u002Fcodedisaster\u002Fsteamworks\u002FSteamLeaderboardEntry\u003B\u005BII\u0029Z)((int) num2, num3, (IntPtr) num4, (int) num5, (long) num6, (long) num7, num8, (IntPtr) num9);
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
    private static long uploadLeaderboardScore(
      [In] long obj0,
      [In] long obj1,
      [In] long obj2,
      [In] int obj3,
      [In] int obj4)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamUserStats.__\u003Cjniptr\u003EuploadLeaderboardScore\u0028JJJII\u0029J == IntPtr.Zero)
        SteamUserStats.__\u003Cjniptr\u003EuploadLeaderboardScore\u0028JJJII\u0029J = JNI.Frame.GetFuncPtr(SteamUserStats.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamUserStats", nameof (uploadLeaderboardScore), "(JJJII)J");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamUserStats.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamUserStats>.Value);
        long num4 = obj0;
        long num5 = obj1;
        long num6 = obj2;
        int num7 = obj3;
        int num8 = obj4;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<long (IntPtr, IntPtr, long, long, long, int, int)>) SteamUserStats.__\u003Cjniptr\u003EuploadLeaderboardScore\u0028JJJII\u0029J)((int) num2, (int) num3, num4, num5, num6, (IntPtr) num7, (IntPtr) num8);
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
    private static long uploadLeaderboardScore(
      [In] long obj0,
      [In] long obj1,
      [In] long obj2,
      [In] int obj3,
      [In] int obj4,
      [In] int[] obj5,
      [In] int obj6)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamUserStats.__\u003Cjniptr\u003EuploadLeaderboardScore\u0028JJJII\u005BII\u0029J == IntPtr.Zero)
        SteamUserStats.__\u003Cjniptr\u003EuploadLeaderboardScore\u0028JJJII\u005BII\u0029J = JNI.Frame.GetFuncPtr(SteamUserStats.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamUserStats", nameof (uploadLeaderboardScore), "(JJJII[II)J");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamUserStats.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamUserStats>.Value);
        long num4 = obj0;
        long num5 = obj1;
        long num6 = obj2;
        int num7 = obj3;
        int num8 = obj4;
        IntPtr num9 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj5);
        int num10 = obj6;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<long (IntPtr, IntPtr, long, long, long, int, int, IntPtr, int)>) SteamUserStats.__\u003Cjniptr\u003EuploadLeaderboardScore\u0028JJJII\u005BII\u0029J)((int) num2, num3, (int) num4, (int) num5, num6, (long) num7, (long) num8, num9, (IntPtr) num10);
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
    private static long requestGlobalStats([In] long obj0, [In] long obj1, [In] int obj2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamUserStats.__\u003Cjniptr\u003ErequestGlobalStats\u0028JJI\u0029J == IntPtr.Zero)
        SteamUserStats.__\u003Cjniptr\u003ErequestGlobalStats\u0028JJI\u0029J = JNI.Frame.GetFuncPtr(SteamUserStats.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamUserStats", nameof (requestGlobalStats), "(JJI)J");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamUserStats.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamUserStats>.Value);
        long num4 = obj0;
        long num5 = obj1;
        int num6 = obj2;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<long (IntPtr, IntPtr, long, long, int)>) SteamUserStats.__\u003Cjniptr\u003ErequestGlobalStats\u0028JJI\u0029J)((int) num2, (long) num3, num4, (IntPtr) num5, (IntPtr) num6);
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
    private static bool getGlobalStat([In] long obj0, [In] string obj1, [In] long[] obj2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamUserStats.__\u003Cjniptr\u003EgetGlobalStat\u0028JLjava\u002Flang\u002FString\u003B\u005BJ\u0029Z == IntPtr.Zero)
        SteamUserStats.__\u003Cjniptr\u003EgetGlobalStat\u0028JLjava\u002Flang\u002FString\u003B\u005BJ\u0029Z = JNI.Frame.GetFuncPtr(SteamUserStats.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamUserStats", nameof (getGlobalStat), "(JLjava/lang/String;[J)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamUserStats.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamUserStats>.Value);
        long num4 = obj0;
        IntPtr num5 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj1);
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj2);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, long, IntPtr, IntPtr)>) SteamUserStats.__\u003Cjniptr\u003EgetGlobalStat\u0028JLjava\u002Flang\u002FString\u003B\u005BJ\u0029Z)(num2, num3, num4, num5, num6);
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
    private static bool getGlobalStat([In] long obj0, [In] string obj1, [In] double[] obj2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamUserStats.__\u003Cjniptr\u003EgetGlobalStat\u0028JLjava\u002Flang\u002FString\u003B\u005BD\u0029Z == IntPtr.Zero)
        SteamUserStats.__\u003Cjniptr\u003EgetGlobalStat\u0028JLjava\u002Flang\u002FString\u003B\u005BD\u0029Z = JNI.Frame.GetFuncPtr(SteamUserStats.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamUserStats", nameof (getGlobalStat), "(JLjava/lang/String;[D)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamUserStats.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamUserStats>.Value);
        long num4 = obj0;
        IntPtr num5 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj1);
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj2);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, long, IntPtr, IntPtr)>) SteamUserStats.__\u003Cjniptr\u003EgetGlobalStat\u0028JLjava\u002Flang\u002FString\u003B\u005BD\u0029Z)(num2, num3, num4, num5, num6);
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
    private static int getGlobalStatHistory([In] long obj0, [In] string obj1, [In] long[] obj2, [In] int obj3)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamUserStats.__\u003Cjniptr\u003EgetGlobalStatHistory\u0028JLjava\u002Flang\u002FString\u003B\u005BJI\u0029I == IntPtr.Zero)
        SteamUserStats.__\u003Cjniptr\u003EgetGlobalStatHistory\u0028JLjava\u002Flang\u002FString\u003B\u005BJI\u0029I = JNI.Frame.GetFuncPtr(SteamUserStats.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamUserStats", nameof (getGlobalStatHistory), "(JLjava/lang/String;[JI)I");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamUserStats.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamUserStats>.Value);
        long num4 = obj0;
        IntPtr num5 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj1);
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj2);
        int num7 = obj3;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<int (IntPtr, IntPtr, long, IntPtr, IntPtr, int)>) SteamUserStats.__\u003Cjniptr\u003EgetGlobalStatHistory\u0028JLjava\u002Flang\u002FString\u003B\u005BJI\u0029I)((int) num2, num3, (IntPtr) num4, (long) num5, num6, (IntPtr) num7);
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
    private static int getGlobalStatHistory([In] long obj0, [In] string obj1, [In] double[] obj2, [In] int obj3)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamUserStats.__\u003Cjniptr\u003EgetGlobalStatHistory\u0028JLjava\u002Flang\u002FString\u003B\u005BDI\u0029I == IntPtr.Zero)
        SteamUserStats.__\u003Cjniptr\u003EgetGlobalStatHistory\u0028JLjava\u002Flang\u002FString\u003B\u005BDI\u0029I = JNI.Frame.GetFuncPtr(SteamUserStats.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamUserStats", nameof (getGlobalStatHistory), "(JLjava/lang/String;[DI)I");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamUserStats.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamUserStats>.Value);
        long num4 = obj0;
        IntPtr num5 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj1);
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj2);
        int num7 = obj3;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<int (IntPtr, IntPtr, long, IntPtr, IntPtr, int)>) SteamUserStats.__\u003Cjniptr\u003EgetGlobalStatHistory\u0028JLjava\u002Flang\u002FString\u003B\u005BDI\u0029I)((int) num2, num3, (IntPtr) num4, (long) num5, num6, (IntPtr) num7);
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

    [LineNumberTable(new byte[] {2, 103, 111, 132})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getStatF(string name, float defaultValue)
    {
      float[] numArray = new float[1];
      return SteamUserStats.getStat(this.pointer, name, numArray) ? numArray[0] : defaultValue;
    }

    [LineNumberTable(60)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool setStatF(string name, float value) => SteamUserStats.setStat(this.pointer, name, value);

    [LineNumberTable(76)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool clearAchievement(string name) => SteamUserStats.clearAchievement(this.pointer, name);

    [LineNumberTable(84)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool indicateAchievementProgress(string name, int curProgress, int maxProgress) => SteamUserStats.indicateAchievementProgress(this.pointer, name, curProgress, maxProgress);

    [LineNumberTable(88)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getNumAchievements() => SteamUserStats.getNumAchievements(this.pointer);

    [LineNumberTable(92)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string getAchievementName(int index) => SteamUserStats.getAchievementName(this.pointer, index);

    [LineNumberTable(96)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool resetAllStats(bool achievementsToo) => SteamUserStats.resetAllStats(this.pointer, achievementsToo);

    [LineNumberTable(new byte[] {53, 110, 43})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual SteamAPICall findOrCreateLeaderboard(
      string leaderboardName,
      SteamUserStats.LeaderboardSortMethod leaderboardSortMethod,
      SteamUserStats.LeaderboardDisplayType leaderboardDisplayType)
    {
      return new SteamAPICall(SteamUserStats.findOrCreateLeaderboard(this.pointer, this.callback, leaderboardName, leaderboardSortMethod.ordinal(), leaderboardDisplayType.ordinal()));
    }

    [LineNumberTable(108)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual SteamAPICall findLeaderboard(string leaderboardName) => new SteamAPICall(SteamUserStats.findLeaderboard(this.pointer, this.callback, leaderboardName));

    [LineNumberTable(112)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string getLeaderboardName(SteamLeaderboardHandle leaderboard) => SteamUserStats.getLeaderboardName(this.pointer, leaderboard.handle);

    [LineNumberTable(116)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getLeaderboardEntryCount(SteamLeaderboardHandle leaderboard) => SteamUserStats.getLeaderboardEntryCount(this.pointer, leaderboard.handle);

    [LineNumberTable(120)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual SteamUserStats.LeaderboardSortMethod getLeaderboardSortMethod(
      SteamLeaderboardHandle leaderboard)
    {
      return SteamUserStats.LeaderboardSortMethod.values()[SteamUserStats.getLeaderboardSortMethod(this.pointer, leaderboard.handle)];
    }

    [LineNumberTable(124)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual SteamUserStats.LeaderboardDisplayType getLeaderboardDisplayType(
      SteamLeaderboardHandle leaderboard)
    {
      return SteamUserStats.LeaderboardDisplayType.values()[SteamUserStats.getLeaderboardDisplayType(this.pointer, leaderboard.handle)];
    }

    [LineNumberTable(new byte[] {82, 115, 40})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual SteamAPICall downloadLeaderboardEntries(
      SteamLeaderboardHandle leaderboard,
      SteamUserStats.LeaderboardDataRequest leaderboardDataRequest,
      int rangeStart,
      int rangeEnd)
    {
      return new SteamAPICall(SteamUserStats.downloadLeaderboardEntries(this.pointer, this.callback, leaderboard.handle, leaderboardDataRequest.ordinal(), rangeStart, rangeEnd));
    }

    [LineNumberTable(new byte[] {89, 99, 135, 102, 43, 198})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual SteamAPICall downloadLeaderboardEntriesForUsers(
      SteamLeaderboardHandle leaderboard,
      SteamID[] users)
    {
      int length = users.Length;
      long[] numArray = new long[length];
      for (int index = 0; index < length; ++index)
        numArray[index] = users[index].handle;
      return new SteamAPICall(SteamUserStats.downloadLeaderboardEntriesForUsers(this.pointer, this.callback, leaderboard.handle, numArray, length));
    }

    [LineNumberTable(new byte[] {107, 114, 122, 5})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool getDownloadedLeaderboardEntry(
      SteamLeaderboardEntriesHandle leaderboardEntries,
      int index,
      SteamLeaderboardEntry entry,
      int[] details)
    {
      return details == null ? SteamUserStats.getDownloadedLeaderboardEntry(this.pointer, leaderboardEntries.handle, index, entry) : SteamUserStats.getDownloadedLeaderboardEntry(this.pointer, leaderboardEntries.handle, index, entry, details, details.Length);
    }

    [LineNumberTable(new byte[] {119, 119, 127, 1, 21})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual SteamAPICall uploadLeaderboardScore(
      SteamLeaderboardHandle leaderboard,
      SteamUserStats.LeaderboardUploadScoreMethod method,
      int score,
      int[] scoreDetails)
    {
      return new SteamAPICall(scoreDetails != null ? SteamUserStats.uploadLeaderboardScore(this.pointer, this.callback, leaderboard.handle, method.ordinal(), score, scoreDetails, scoreDetails.Length) : SteamUserStats.uploadLeaderboardScore(this.pointer, this.callback, leaderboard.handle, method.ordinal(), score));
    }

    [LineNumberTable(175)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual SteamAPICall requestGlobalStats(int historyDays) => new SteamAPICall(SteamUserStats.requestGlobalStats(this.pointer, this.callback, historyDays));

    [LineNumberTable(new byte[] {160, 65, 103, 111, 132})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual long getGlobalStat(string name, long defaultValue)
    {
      long[] numArray = new long[1];
      return SteamUserStats.getGlobalStat(this.pointer, name, numArray) ? numArray[0] : defaultValue;
    }

    [LineNumberTable(new byte[] {160, 73, 103, 111, 132})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual double getGlobalStat(string name, double defaultValue)
    {
      double[] numArray = new double[1];
      return SteamUserStats.getGlobalStat(this.pointer, name, numArray) ? numArray[0] : defaultValue;
    }

    [LineNumberTable(195)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getGlobalStatHistory(string name, long[] data) => SteamUserStats.getGlobalStatHistory(this.pointer, name, data, data.Length);

    [LineNumberTable(199)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getGlobalStatHistory(string name, double[] data) => SteamUserStats.getGlobalStatHistory(this.pointer, name, data, data.Length);

    [Modifiers]
    [LineNumberTable(3)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void dispose() => base.dispose();

    new static CallerID __\u003CGetCallerID\u003E()
    {
      if (SteamUserStats.__\u003CcallerID\u003E == null)
        SteamUserStats.__\u003CcallerID\u003E = (CallerID) new SteamUserStats.__\u003CCallerID\u003E();
      return SteamUserStats.__\u003CcallerID\u003E;
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
    [Signature("Ljava/lang/Enum<Lcom/codedisaster/steamworks/SteamUserStats$LeaderboardDataRequest;>;")]
    [Modifiers]
    [Serializable]
    public sealed class LeaderboardDataRequest : Enum
    {
      [Modifiers]
      internal static SteamUserStats.LeaderboardDataRequest __\u003C\u003EGlobal;
      [Modifiers]
      internal static SteamUserStats.LeaderboardDataRequest __\u003C\u003EGlobalAroundUser;
      [Modifiers]
      internal static SteamUserStats.LeaderboardDataRequest __\u003C\u003EFriends;
      [Modifiers]
      internal static SteamUserStats.LeaderboardDataRequest __\u003C\u003EUsers;
      [Modifiers]
      private static SteamUserStats.LeaderboardDataRequest[] \u0024VALUES;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [Signature("()V")]
      [LineNumberTable(5)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private LeaderboardDataRequest([In] string obj0, [In] int obj1)
        : base(obj0, obj1)
      {
        GC.KeepAlive((object) this);
      }

      [LineNumberTable(5)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static SteamUserStats.LeaderboardDataRequest[] values() => (SteamUserStats.LeaderboardDataRequest[]) SteamUserStats.LeaderboardDataRequest.\u0024VALUES.Clone();

      [LineNumberTable(5)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static SteamUserStats.LeaderboardDataRequest valueOf(string name) => (SteamUserStats.LeaderboardDataRequest) Enum.valueOf((Class) ClassLiteral<SteamUserStats.LeaderboardDataRequest>.Value, name);

      [LineNumberTable(new byte[] {159, 141, 141, 112, 112, 112, 240, 60})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static LeaderboardDataRequest()
      {
        if (ByteCodeHelper.isAlreadyInited("com.codedisaster.steamworks.SteamUserStats$LeaderboardDataRequest"))
          return;
        SteamUserStats.LeaderboardDataRequest.__\u003C\u003EGlobal = new SteamUserStats.LeaderboardDataRequest(nameof (Global), 0);
        SteamUserStats.LeaderboardDataRequest.__\u003C\u003EGlobalAroundUser = new SteamUserStats.LeaderboardDataRequest(nameof (GlobalAroundUser), 1);
        SteamUserStats.LeaderboardDataRequest.__\u003C\u003EFriends = new SteamUserStats.LeaderboardDataRequest(nameof (Friends), 2);
        SteamUserStats.LeaderboardDataRequest.__\u003C\u003EUsers = new SteamUserStats.LeaderboardDataRequest(nameof (Users), 3);
        SteamUserStats.LeaderboardDataRequest.\u0024VALUES = new SteamUserStats.LeaderboardDataRequest[4]
        {
          SteamUserStats.LeaderboardDataRequest.__\u003C\u003EGlobal,
          SteamUserStats.LeaderboardDataRequest.__\u003C\u003EGlobalAroundUser,
          SteamUserStats.LeaderboardDataRequest.__\u003C\u003EFriends,
          SteamUserStats.LeaderboardDataRequest.__\u003C\u003EUsers
        };
      }

      [Modifiers]
      public static SteamUserStats.LeaderboardDataRequest Global
      {
        [HideFromJava] get => SteamUserStats.LeaderboardDataRequest.__\u003C\u003EGlobal;
      }

      [Modifiers]
      public static SteamUserStats.LeaderboardDataRequest GlobalAroundUser
      {
        [HideFromJava] get => SteamUserStats.LeaderboardDataRequest.__\u003C\u003EGlobalAroundUser;
      }

      [Modifiers]
      public static SteamUserStats.LeaderboardDataRequest Friends
      {
        [HideFromJava] get => SteamUserStats.LeaderboardDataRequest.__\u003C\u003EFriends;
      }

      [Modifiers]
      public static SteamUserStats.LeaderboardDataRequest Users
      {
        [HideFromJava] get => SteamUserStats.LeaderboardDataRequest.__\u003C\u003EUsers;
      }

      [HideFromJava]
      [Serializable]
      public enum __Enum
      {
        Global,
        GlobalAroundUser,
        Friends,
        Users,
      }
    }

    [InnerClass]
    [Signature("Ljava/lang/Enum<Lcom/codedisaster/steamworks/SteamUserStats$LeaderboardDisplayType;>;")]
    [Modifiers]
    [Serializable]
    public sealed class LeaderboardDisplayType : Enum
    {
      [Modifiers]
      internal static SteamUserStats.LeaderboardDisplayType __\u003C\u003ENone;
      [Modifiers]
      internal static SteamUserStats.LeaderboardDisplayType __\u003C\u003ENumeric;
      [Modifiers]
      internal static SteamUserStats.LeaderboardDisplayType __\u003C\u003ETimeSeconds;
      [Modifiers]
      internal static SteamUserStats.LeaderboardDisplayType __\u003C\u003ETimeMilliSeconds;
      [Modifiers]
      private static SteamUserStats.LeaderboardDisplayType[] \u0024VALUES;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(12)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static SteamUserStats.LeaderboardDisplayType[] values() => (SteamUserStats.LeaderboardDisplayType[]) SteamUserStats.LeaderboardDisplayType.\u0024VALUES.Clone();

      [Signature("()V")]
      [LineNumberTable(12)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private LeaderboardDisplayType([In] string obj0, [In] int obj1)
        : base(obj0, obj1)
      {
        GC.KeepAlive((object) this);
      }

      [LineNumberTable(12)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static SteamUserStats.LeaderboardDisplayType valueOf(string name) => (SteamUserStats.LeaderboardDisplayType) Enum.valueOf((Class) ClassLiteral<SteamUserStats.LeaderboardDisplayType>.Value, name);

      [LineNumberTable(new byte[] {159, 139, 109, 112, 112, 112, 240, 60})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static LeaderboardDisplayType()
      {
        if (ByteCodeHelper.isAlreadyInited("com.codedisaster.steamworks.SteamUserStats$LeaderboardDisplayType"))
          return;
        SteamUserStats.LeaderboardDisplayType.__\u003C\u003ENone = new SteamUserStats.LeaderboardDisplayType(nameof (None), 0);
        SteamUserStats.LeaderboardDisplayType.__\u003C\u003ENumeric = new SteamUserStats.LeaderboardDisplayType(nameof (Numeric), 1);
        SteamUserStats.LeaderboardDisplayType.__\u003C\u003ETimeSeconds = new SteamUserStats.LeaderboardDisplayType(nameof (TimeSeconds), 2);
        SteamUserStats.LeaderboardDisplayType.__\u003C\u003ETimeMilliSeconds = new SteamUserStats.LeaderboardDisplayType(nameof (TimeMilliSeconds), 3);
        SteamUserStats.LeaderboardDisplayType.\u0024VALUES = new SteamUserStats.LeaderboardDisplayType[4]
        {
          SteamUserStats.LeaderboardDisplayType.__\u003C\u003ENone,
          SteamUserStats.LeaderboardDisplayType.__\u003C\u003ENumeric,
          SteamUserStats.LeaderboardDisplayType.__\u003C\u003ETimeSeconds,
          SteamUserStats.LeaderboardDisplayType.__\u003C\u003ETimeMilliSeconds
        };
      }

      [Modifiers]
      public static SteamUserStats.LeaderboardDisplayType None
      {
        [HideFromJava] get => SteamUserStats.LeaderboardDisplayType.__\u003C\u003ENone;
      }

      [Modifiers]
      public static SteamUserStats.LeaderboardDisplayType Numeric
      {
        [HideFromJava] get => SteamUserStats.LeaderboardDisplayType.__\u003C\u003ENumeric;
      }

      [Modifiers]
      public static SteamUserStats.LeaderboardDisplayType TimeSeconds
      {
        [HideFromJava] get => SteamUserStats.LeaderboardDisplayType.__\u003C\u003ETimeSeconds;
      }

      [Modifiers]
      public static SteamUserStats.LeaderboardDisplayType TimeMilliSeconds
      {
        [HideFromJava] get => SteamUserStats.LeaderboardDisplayType.__\u003C\u003ETimeMilliSeconds;
      }

      [HideFromJava]
      [Serializable]
      public enum __Enum
      {
        None,
        Numeric,
        TimeSeconds,
        TimeMilliSeconds,
      }
    }

    [InnerClass]
    [Signature("Ljava/lang/Enum<Lcom/codedisaster/steamworks/SteamUserStats$LeaderboardSortMethod;>;")]
    [Modifiers]
    [Serializable]
    public sealed class LeaderboardSortMethod : Enum
    {
      [Modifiers]
      internal static SteamUserStats.LeaderboardSortMethod __\u003C\u003ENone;
      [Modifiers]
      internal static SteamUserStats.LeaderboardSortMethod __\u003C\u003EAscending;
      [Modifiers]
      internal static SteamUserStats.LeaderboardSortMethod __\u003C\u003EDescending;
      [Modifiers]
      private static SteamUserStats.LeaderboardSortMethod[] \u0024VALUES;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(19)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static SteamUserStats.LeaderboardSortMethod[] values() => (SteamUserStats.LeaderboardSortMethod[]) SteamUserStats.LeaderboardSortMethod.\u0024VALUES.Clone();

      [Signature("()V")]
      [LineNumberTable(19)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private LeaderboardSortMethod([In] string obj0, [In] int obj1)
        : base(obj0, obj1)
      {
        GC.KeepAlive((object) this);
      }

      [LineNumberTable(19)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static SteamUserStats.LeaderboardSortMethod valueOf(string name) => (SteamUserStats.LeaderboardSortMethod) Enum.valueOf((Class) ClassLiteral<SteamUserStats.LeaderboardSortMethod>.Value, name);

      [LineNumberTable(new byte[] {159, 137, 77, 112, 112, 240, 61})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static LeaderboardSortMethod()
      {
        if (ByteCodeHelper.isAlreadyInited("com.codedisaster.steamworks.SteamUserStats$LeaderboardSortMethod"))
          return;
        SteamUserStats.LeaderboardSortMethod.__\u003C\u003ENone = new SteamUserStats.LeaderboardSortMethod(nameof (None), 0);
        SteamUserStats.LeaderboardSortMethod.__\u003C\u003EAscending = new SteamUserStats.LeaderboardSortMethod(nameof (Ascending), 1);
        SteamUserStats.LeaderboardSortMethod.__\u003C\u003EDescending = new SteamUserStats.LeaderboardSortMethod(nameof (Descending), 2);
        SteamUserStats.LeaderboardSortMethod.\u0024VALUES = new SteamUserStats.LeaderboardSortMethod[3]
        {
          SteamUserStats.LeaderboardSortMethod.__\u003C\u003ENone,
          SteamUserStats.LeaderboardSortMethod.__\u003C\u003EAscending,
          SteamUserStats.LeaderboardSortMethod.__\u003C\u003EDescending
        };
      }

      [Modifiers]
      public static SteamUserStats.LeaderboardSortMethod None
      {
        [HideFromJava] get => SteamUserStats.LeaderboardSortMethod.__\u003C\u003ENone;
      }

      [Modifiers]
      public static SteamUserStats.LeaderboardSortMethod Ascending
      {
        [HideFromJava] get => SteamUserStats.LeaderboardSortMethod.__\u003C\u003EAscending;
      }

      [Modifiers]
      public static SteamUserStats.LeaderboardSortMethod Descending
      {
        [HideFromJava] get => SteamUserStats.LeaderboardSortMethod.__\u003C\u003EDescending;
      }

      [HideFromJava]
      [Serializable]
      public enum __Enum
      {
        None,
        Ascending,
        Descending,
      }
    }

    [InnerClass]
    [Signature("Ljava/lang/Enum<Lcom/codedisaster/steamworks/SteamUserStats$LeaderboardUploadScoreMethod;>;")]
    [Modifiers]
    [Serializable]
    public sealed class LeaderboardUploadScoreMethod : Enum
    {
      [Modifiers]
      internal static SteamUserStats.LeaderboardUploadScoreMethod __\u003C\u003ENone;
      [Modifiers]
      internal static SteamUserStats.LeaderboardUploadScoreMethod __\u003C\u003EKeepBest;
      [Modifiers]
      internal static SteamUserStats.LeaderboardUploadScoreMethod __\u003C\u003EForceUpdate;
      [Modifiers]
      private static SteamUserStats.LeaderboardUploadScoreMethod[] \u0024VALUES;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [Signature("()V")]
      [LineNumberTable(25)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private LeaderboardUploadScoreMethod([In] string obj0, [In] int obj1)
        : base(obj0, obj1)
      {
        GC.KeepAlive((object) this);
      }

      [LineNumberTable(25)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static SteamUserStats.LeaderboardUploadScoreMethod[] values() => (SteamUserStats.LeaderboardUploadScoreMethod[]) SteamUserStats.LeaderboardUploadScoreMethod.\u0024VALUES.Clone();

      [LineNumberTable(25)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static SteamUserStats.LeaderboardUploadScoreMethod valueOf(string name) => (SteamUserStats.LeaderboardUploadScoreMethod) Enum.valueOf((Class) ClassLiteral<SteamUserStats.LeaderboardUploadScoreMethod>.Value, name);

      [LineNumberTable(new byte[] {159, 136, 141, 112, 112, 240, 61})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static LeaderboardUploadScoreMethod()
      {
        if (ByteCodeHelper.isAlreadyInited("com.codedisaster.steamworks.SteamUserStats$LeaderboardUploadScoreMethod"))
          return;
        SteamUserStats.LeaderboardUploadScoreMethod.__\u003C\u003ENone = new SteamUserStats.LeaderboardUploadScoreMethod(nameof (None), 0);
        SteamUserStats.LeaderboardUploadScoreMethod.__\u003C\u003EKeepBest = new SteamUserStats.LeaderboardUploadScoreMethod(nameof (KeepBest), 1);
        SteamUserStats.LeaderboardUploadScoreMethod.__\u003C\u003EForceUpdate = new SteamUserStats.LeaderboardUploadScoreMethod(nameof (ForceUpdate), 2);
        SteamUserStats.LeaderboardUploadScoreMethod.\u0024VALUES = new SteamUserStats.LeaderboardUploadScoreMethod[3]
        {
          SteamUserStats.LeaderboardUploadScoreMethod.__\u003C\u003ENone,
          SteamUserStats.LeaderboardUploadScoreMethod.__\u003C\u003EKeepBest,
          SteamUserStats.LeaderboardUploadScoreMethod.__\u003C\u003EForceUpdate
        };
      }

      [Modifiers]
      public static SteamUserStats.LeaderboardUploadScoreMethod None
      {
        [HideFromJava] get => SteamUserStats.LeaderboardUploadScoreMethod.__\u003C\u003ENone;
      }

      [Modifiers]
      public static SteamUserStats.LeaderboardUploadScoreMethod KeepBest
      {
        [HideFromJava] get => SteamUserStats.LeaderboardUploadScoreMethod.__\u003C\u003EKeepBest;
      }

      [Modifiers]
      public static SteamUserStats.LeaderboardUploadScoreMethod ForceUpdate
      {
        [HideFromJava] get => SteamUserStats.LeaderboardUploadScoreMethod.__\u003C\u003EForceUpdate;
      }

      [HideFromJava]
      [Serializable]
      public enum __Enum
      {
        None,
        KeepBest,
        ForceUpdate,
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
