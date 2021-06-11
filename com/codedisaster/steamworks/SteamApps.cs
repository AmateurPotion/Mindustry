// Decompiled with JetBrains decompiler
// Type: com.codedisaster.steamworks.SteamApps
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
  public class SteamApps : SteamInterface
  {
    static IntPtr __\u003Cjniptr\u003EisSubscribed\u0028J\u0029Z;
    [SpecialName]
    private static CallerID __\u003CcallerID\u003E;
    static IntPtr __\u003Cjniptr\u003EisLowViolence\u0028J\u0029Z;
    static IntPtr __\u003Cjniptr\u003EisCybercafe\u0028J\u0029Z;
    static IntPtr __\u003Cjniptr\u003EisVACBanned\u0028J\u0029Z;
    static IntPtr __\u003Cjniptr\u003EgetCurrentGameLanguage\u0028J\u0029Ljava\u002Flang\u002FString\u003B;
    static IntPtr __\u003Cjniptr\u003EgetAvailableGameLanguages\u0028J\u0029Ljava\u002Flang\u002FString\u003B;
    static IntPtr __\u003Cjniptr\u003EisSubscribedApp\u0028JI\u0029Z;
    static IntPtr __\u003Cjniptr\u003EisDlcInstalled\u0028JI\u0029Z;
    static IntPtr __\u003Cjniptr\u003EgetEarliestPurchaseUnixTime\u0028JI\u0029I;
    static IntPtr __\u003Cjniptr\u003EisSubscribedFromFreeWeekend\u0028J\u0029Z;
    static IntPtr __\u003Cjniptr\u003EgetDLCCount\u0028J\u0029I;
    static IntPtr __\u003Cjniptr\u003EinstallDLC\u0028JI\u0029V;
    static IntPtr __\u003Cjniptr\u003EuninstallDLC\u0028JI\u0029V;
    static IntPtr __\u003Cjniptr\u003EgetAppOwner\u0028J\u0029J;
    static IntPtr __\u003Cjniptr\u003EgetAppBuildId\u0028J\u0029I;

    [Modifiers]
    private static bool isSubscribed([In] long obj0)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamApps.__\u003Cjniptr\u003EisSubscribed\u0028J\u0029Z == IntPtr.Zero)
        SteamApps.__\u003Cjniptr\u003EisSubscribed\u0028J\u0029Z = JNI.Frame.GetFuncPtr(SteamApps.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamApps", nameof (isSubscribed), "(J)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamApps.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamApps>.Value);
        long num4 = obj0;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, long)>) SteamApps.__\u003Cjniptr\u003EisSubscribed\u0028J\u0029Z)((long) num2, num3, (IntPtr) num4);
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
    private static bool isLowViolence([In] long obj0)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamApps.__\u003Cjniptr\u003EisLowViolence\u0028J\u0029Z == IntPtr.Zero)
        SteamApps.__\u003Cjniptr\u003EisLowViolence\u0028J\u0029Z = JNI.Frame.GetFuncPtr(SteamApps.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamApps", nameof (isLowViolence), "(J)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamApps.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamApps>.Value);
        long num4 = obj0;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, long)>) SteamApps.__\u003Cjniptr\u003EisLowViolence\u0028J\u0029Z)((long) num2, num3, (IntPtr) num4);
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
    private static bool isCybercafe([In] long obj0)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamApps.__\u003Cjniptr\u003EisCybercafe\u0028J\u0029Z == IntPtr.Zero)
        SteamApps.__\u003Cjniptr\u003EisCybercafe\u0028J\u0029Z = JNI.Frame.GetFuncPtr(SteamApps.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamApps", nameof (isCybercafe), "(J)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamApps.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamApps>.Value);
        long num4 = obj0;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, long)>) SteamApps.__\u003Cjniptr\u003EisCybercafe\u0028J\u0029Z)((long) num2, num3, (IntPtr) num4);
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
    private static bool isVACBanned([In] long obj0)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamApps.__\u003Cjniptr\u003EisVACBanned\u0028J\u0029Z == IntPtr.Zero)
        SteamApps.__\u003Cjniptr\u003EisVACBanned\u0028J\u0029Z = JNI.Frame.GetFuncPtr(SteamApps.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamApps", nameof (isVACBanned), "(J)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamApps.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamApps>.Value);
        long num4 = obj0;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, long)>) SteamApps.__\u003Cjniptr\u003EisVACBanned\u0028J\u0029Z)((long) num2, num3, (IntPtr) num4);
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
    private static string getCurrentGameLanguage([In] long obj0)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamApps.__\u003Cjniptr\u003EgetCurrentGameLanguage\u0028J\u0029Ljava\u002Flang\u002FString\u003B == IntPtr.Zero)
        SteamApps.__\u003Cjniptr\u003EgetCurrentGameLanguage\u0028J\u0029Ljava\u002Flang\u002FString\u003B = JNI.Frame.GetFuncPtr(SteamApps.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamApps", nameof (getCurrentGameLanguage), "(J)Ljava/lang/String;");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamApps.__\u003CGetCallerID\u003E());
      try
      {
        ref JNI.Frame local = ref frame;
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamApps>.Value);
        long num4 = obj0;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        IntPtr num5 = __calli((__FnPtr<IntPtr (IntPtr, IntPtr, long)>) SteamApps.__\u003Cjniptr\u003EgetCurrentGameLanguage\u0028J\u0029Ljava\u002Flang\u002FString\u003B)((long) num2, num3, (IntPtr) num4);
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
    private static string getAvailableGameLanguages([In] long obj0)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamApps.__\u003Cjniptr\u003EgetAvailableGameLanguages\u0028J\u0029Ljava\u002Flang\u002FString\u003B == IntPtr.Zero)
        SteamApps.__\u003Cjniptr\u003EgetAvailableGameLanguages\u0028J\u0029Ljava\u002Flang\u002FString\u003B = JNI.Frame.GetFuncPtr(SteamApps.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamApps", nameof (getAvailableGameLanguages), "(J)Ljava/lang/String;");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamApps.__\u003CGetCallerID\u003E());
      try
      {
        ref JNI.Frame local = ref frame;
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamApps>.Value);
        long num4 = obj0;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        IntPtr num5 = __calli((__FnPtr<IntPtr (IntPtr, IntPtr, long)>) SteamApps.__\u003Cjniptr\u003EgetAvailableGameLanguages\u0028J\u0029Ljava\u002Flang\u002FString\u003B)((long) num2, num3, (IntPtr) num4);
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
    private static bool isSubscribedApp([In] long obj0, [In] int obj1)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamApps.__\u003Cjniptr\u003EisSubscribedApp\u0028JI\u0029Z == IntPtr.Zero)
        SteamApps.__\u003Cjniptr\u003EisSubscribedApp\u0028JI\u0029Z = JNI.Frame.GetFuncPtr(SteamApps.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamApps", nameof (isSubscribedApp), "(JI)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamApps.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamApps>.Value);
        long num4 = obj0;
        int num5 = obj1;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, long, int)>) SteamApps.__\u003Cjniptr\u003EisSubscribedApp\u0028JI\u0029Z)((int) num2, (long) num3, (IntPtr) num4, (IntPtr) num5);
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
    private static bool isDlcInstalled([In] long obj0, [In] int obj1)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamApps.__\u003Cjniptr\u003EisDlcInstalled\u0028JI\u0029Z == IntPtr.Zero)
        SteamApps.__\u003Cjniptr\u003EisDlcInstalled\u0028JI\u0029Z = JNI.Frame.GetFuncPtr(SteamApps.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamApps", nameof (isDlcInstalled), "(JI)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamApps.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamApps>.Value);
        long num4 = obj0;
        int num5 = obj1;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, long, int)>) SteamApps.__\u003Cjniptr\u003EisDlcInstalled\u0028JI\u0029Z)((int) num2, (long) num3, (IntPtr) num4, (IntPtr) num5);
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
    private static int getEarliestPurchaseUnixTime([In] long obj0, [In] int obj1)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamApps.__\u003Cjniptr\u003EgetEarliestPurchaseUnixTime\u0028JI\u0029I == IntPtr.Zero)
        SteamApps.__\u003Cjniptr\u003EgetEarliestPurchaseUnixTime\u0028JI\u0029I = JNI.Frame.GetFuncPtr(SteamApps.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamApps", nameof (getEarliestPurchaseUnixTime), "(JI)I");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamApps.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamApps>.Value);
        long num4 = obj0;
        int num5 = obj1;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<int (IntPtr, IntPtr, long, int)>) SteamApps.__\u003Cjniptr\u003EgetEarliestPurchaseUnixTime\u0028JI\u0029I)((int) num2, (long) num3, (IntPtr) num4, (IntPtr) num5);
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
    private static bool isSubscribedFromFreeWeekend([In] long obj0)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamApps.__\u003Cjniptr\u003EisSubscribedFromFreeWeekend\u0028J\u0029Z == IntPtr.Zero)
        SteamApps.__\u003Cjniptr\u003EisSubscribedFromFreeWeekend\u0028J\u0029Z = JNI.Frame.GetFuncPtr(SteamApps.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamApps", nameof (isSubscribedFromFreeWeekend), "(J)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamApps.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamApps>.Value);
        long num4 = obj0;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, long)>) SteamApps.__\u003Cjniptr\u003EisSubscribedFromFreeWeekend\u0028J\u0029Z)((long) num2, num3, (IntPtr) num4);
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
    private static int getDLCCount([In] long obj0)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamApps.__\u003Cjniptr\u003EgetDLCCount\u0028J\u0029I == IntPtr.Zero)
        SteamApps.__\u003Cjniptr\u003EgetDLCCount\u0028J\u0029I = JNI.Frame.GetFuncPtr(SteamApps.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamApps", nameof (getDLCCount), "(J)I");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamApps.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamApps>.Value);
        long num4 = obj0;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<int (IntPtr, IntPtr, long)>) SteamApps.__\u003Cjniptr\u003EgetDLCCount\u0028J\u0029I)((long) num2, num3, (IntPtr) num4);
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
    private static void installDLC([In] long obj0, [In] int obj1)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamApps.__\u003Cjniptr\u003EinstallDLC\u0028JI\u0029V == IntPtr.Zero)
        SteamApps.__\u003Cjniptr\u003EinstallDLC\u0028JI\u0029V = JNI.Frame.GetFuncPtr(SteamApps.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamApps", nameof (installDLC), "(JI)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamApps.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamApps>.Value);
        long num4 = obj0;
        int num5 = obj1;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, long, int)>) SteamApps.__\u003Cjniptr\u003EinstallDLC\u0028JI\u0029V)((int) num2, (long) num3, (IntPtr) num4, (IntPtr) num5);
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
    private static void uninstallDLC([In] long obj0, [In] int obj1)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamApps.__\u003Cjniptr\u003EuninstallDLC\u0028JI\u0029V == IntPtr.Zero)
        SteamApps.__\u003Cjniptr\u003EuninstallDLC\u0028JI\u0029V = JNI.Frame.GetFuncPtr(SteamApps.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamApps", nameof (uninstallDLC), "(JI)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamApps.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamApps>.Value);
        long num4 = obj0;
        int num5 = obj1;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, long, int)>) SteamApps.__\u003Cjniptr\u003EuninstallDLC\u0028JI\u0029V)((int) num2, (long) num3, (IntPtr) num4, (IntPtr) num5);
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
    private static long getAppOwner([In] long obj0)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamApps.__\u003Cjniptr\u003EgetAppOwner\u0028J\u0029J == IntPtr.Zero)
        SteamApps.__\u003Cjniptr\u003EgetAppOwner\u0028J\u0029J = JNI.Frame.GetFuncPtr(SteamApps.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamApps", nameof (getAppOwner), "(J)J");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamApps.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamApps>.Value);
        long num4 = obj0;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<long (IntPtr, IntPtr, long)>) SteamApps.__\u003Cjniptr\u003EgetAppOwner\u0028J\u0029J)((long) num2, num3, (IntPtr) num4);
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
    private static int getAppBuildId([In] long obj0)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamApps.__\u003Cjniptr\u003EgetAppBuildId\u0028J\u0029I == IntPtr.Zero)
        SteamApps.__\u003Cjniptr\u003EgetAppBuildId\u0028J\u0029I = JNI.Frame.GetFuncPtr(SteamApps.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamApps", nameof (getAppBuildId), "(J)I");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamApps.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamApps>.Value);
        long num4 = obj0;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<int (IntPtr, IntPtr, long)>) SteamApps.__\u003Cjniptr\u003EgetAppBuildId\u0028J\u0029I)((long) num2, num3, (IntPtr) num4);
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
    public SteamApps()
      : base(SteamAPI.getSteamAppsPointer())
    {
    }

    [LineNumberTable(10)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isSubscribed() => SteamApps.isSubscribed(this.pointer);

    [LineNumberTable(14)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isLowViolence() => SteamApps.isLowViolence(this.pointer);

    [LineNumberTable(18)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isCybercafe() => SteamApps.isCybercafe(this.pointer);

    [LineNumberTable(22)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isVACBanned() => SteamApps.isVACBanned(this.pointer);

    [LineNumberTable(26)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string getCurrentGameLanguage() => SteamApps.getCurrentGameLanguage(this.pointer);

    [LineNumberTable(30)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string getAvailableGameLanguages() => SteamApps.getAvailableGameLanguages(this.pointer);

    [LineNumberTable(34)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isSubscribedApp(int appID) => SteamApps.isSubscribedApp(this.pointer, appID);

    [LineNumberTable(38)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isDlcInstalled(int appID) => SteamApps.isDlcInstalled(this.pointer, appID);

    [LineNumberTable(42)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getEarliestPurchaseUnixTime(int appID) => SteamApps.getEarliestPurchaseUnixTime(this.pointer, appID);

    [LineNumberTable(46)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isSubscribedFromFreeWeekend() => SteamApps.isSubscribedFromFreeWeekend(this.pointer);

    [LineNumberTable(50)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getDLCCount() => SteamApps.getDLCCount(this.pointer);

    [LineNumberTable(new byte[] {4, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void installDLC(int appID) => SteamApps.installDLC(this.pointer, appID);

    [LineNumberTable(new byte[] {8, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void uninstallDLC(int appID) => SteamApps.uninstallDLC(this.pointer, appID);

    [LineNumberTable(62)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual SteamID getAppOwner()
    {
      SteamID.__\u003Cclinit\u003E();
      return new SteamID(SteamApps.getAppOwner(this.pointer));
    }

    [LineNumberTable(66)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getAppBuildId() => SteamApps.getAppBuildId(this.pointer);

    [Modifiers]
    [LineNumberTable(3)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void dispose() => base.dispose();

    new static CallerID __\u003CGetCallerID\u003E()
    {
      if (SteamApps.__\u003CcallerID\u003E == null)
        SteamApps.__\u003CcallerID\u003E = (CallerID) new SteamApps.__\u003CCallerID\u003E();
      return SteamApps.__\u003CcallerID\u003E;
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
