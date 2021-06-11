// Decompiled with JetBrains decompiler
// Type: com.codedisaster.steamworks.SteamAPI
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.io;
using java.lang;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace com.codedisaster.steamworks
{
  public class SteamAPI : Object
  {
    private static bool isRunning;
    private static bool isNativeAPILoaded;
    static IntPtr __\u003Cjniptr\u003EnativeRestartAppIfNecessary\u0028I\u0029Z;
    [SpecialName]
    private static CallerID __\u003CcallerID\u003E;
    static IntPtr __\u003Cjniptr\u003EreleaseCurrentThreadMemory\u0028\u0029V;
    static IntPtr __\u003Cjniptr\u003EnativeInit\u0028\u0029Z;
    static IntPtr __\u003Cjniptr\u003EnativeShutdown\u0028\u0029V;
    static IntPtr __\u003Cjniptr\u003ErunCallbacks\u0028\u0029V;
    static IntPtr __\u003Cjniptr\u003EisSteamRunningNative\u0028\u0029Z;
    static IntPtr __\u003Cjniptr\u003EgetSteamAppsPointer\u0028\u0029J;
    static IntPtr __\u003Cjniptr\u003EgetSteamControllerPointer\u0028\u0029J;
    static IntPtr __\u003Cjniptr\u003EgetSteamFriendsPointer\u0028\u0029J;
    static IntPtr __\u003Cjniptr\u003EgetSteamHTTPPointer\u0028\u0029J;
    static IntPtr __\u003Cjniptr\u003EgetSteamMatchmakingPointer\u0028\u0029J;
    static IntPtr __\u003Cjniptr\u003EgetSteamMatchmakingServersPointer\u0028\u0029J;
    static IntPtr __\u003Cjniptr\u003EgetSteamNetworkingPointer\u0028\u0029J;
    static IntPtr __\u003Cjniptr\u003EgetSteamRemoteStoragePointer\u0028\u0029J;
    static IntPtr __\u003Cjniptr\u003EgetSteamScreenshotsPointer\u0028\u0029J;
    static IntPtr __\u003Cjniptr\u003EgetSteamUGCPointer\u0028\u0029J;
    static IntPtr __\u003Cjniptr\u003EgetSteamUserPointer\u0028\u0029J;
    static IntPtr __\u003Cjniptr\u003EgetSteamUserStatsPointer\u0028\u0029J;
    static IntPtr __\u003Cjniptr\u003EgetSteamUtilsPointer\u0028\u0029J;

    [LineNumberTable(58)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool isSteamRunning() => SteamAPI.isSteamRunning(false);

    [Modifiers]
    public static void runCallbacks()
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamAPI.__\u003Cjniptr\u003ErunCallbacks\u0028\u0029V == IntPtr.Zero)
        SteamAPI.__\u003Cjniptr\u003ErunCallbacks\u0028\u0029V = JNI.Frame.GetFuncPtr(SteamAPI.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamAPI", nameof (runCallbacks), "()V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamAPI.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamAPI>.Value);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr)>) SteamAPI.__\u003Cjniptr\u003ErunCallbacks\u0028\u0029V)(num2, num3);
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

    [Throws(new string[] {"com.codedisaster.steamworks.SteamException"})]
    [LineNumberTable(new byte[] {159, 153, 103, 161, 115, 147, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void loadLibraries()
    {
      if (SteamAPI.isNativeAPILoaded)
        return;
      SteamSharedLibraryLoader.loadLibrary("steam_api");
      SteamSharedLibraryLoader.loadLibrary("steamworks4j");
      SteamAPI.isNativeAPILoaded = true;
    }

    [Throws(new string[] {"com.codedisaster.steamworks.SteamException"})]
    [LineNumberTable(new byte[] {159, 178, 103, 176, 138})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool init()
    {
      if (!SteamAPI.isNativeAPILoaded)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new SteamException("Native libraries not loaded.\nEnsure to call SteamAPI.loadLibraries() first!");
      }
      SteamAPI.isRunning = SteamAPI.nativeInit();
      return SteamAPI.isRunning;
    }

    [Throws(new string[] {"com.codedisaster.steamworks.SteamException"})]
    [LineNumberTable(new byte[] {159, 169, 103, 176})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool restartAppIfNecessary(int appId)
    {
      if (!SteamAPI.isNativeAPILoaded)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new SteamException("Native libraries not loaded.\nEnsure to call SteamAPI.loadLibraries() first!");
      }
      return SteamAPI.nativeRestartAppIfNecessary(appId);
    }

    [LineNumberTable(new byte[] {159, 188, 102, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void shutdown()
    {
      SteamAPI.isRunning = false;
      SteamAPI.nativeShutdown();
    }

    [Modifiers]
    private static bool nativeRestartAppIfNecessary([In] int obj0)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamAPI.__\u003Cjniptr\u003EnativeRestartAppIfNecessary\u0028I\u0029Z == IntPtr.Zero)
        SteamAPI.__\u003Cjniptr\u003EnativeRestartAppIfNecessary\u0028I\u0029Z = JNI.Frame.GetFuncPtr(SteamAPI.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamAPI", nameof (nativeRestartAppIfNecessary), "(I)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamAPI.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamAPI>.Value);
        int num4 = obj0;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, int)>) SteamAPI.__\u003Cjniptr\u003EnativeRestartAppIfNecessary\u0028I\u0029Z)((int) num2, num3, (IntPtr) num4);
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
    private static bool nativeInit()
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamAPI.__\u003Cjniptr\u003EnativeInit\u0028\u0029Z == IntPtr.Zero)
        SteamAPI.__\u003Cjniptr\u003EnativeInit\u0028\u0029Z = JNI.Frame.GetFuncPtr(SteamAPI.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamAPI", nameof (nativeInit), "()Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamAPI.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamAPI>.Value);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr)>) SteamAPI.__\u003Cjniptr\u003EnativeInit\u0028\u0029Z)(num2, num3);
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
    private static void nativeShutdown()
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamAPI.__\u003Cjniptr\u003EnativeShutdown\u0028\u0029V == IntPtr.Zero)
        SteamAPI.__\u003Cjniptr\u003EnativeShutdown\u0028\u0029V = JNI.Frame.GetFuncPtr(SteamAPI.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamAPI", nameof (nativeShutdown), "()V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamAPI.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamAPI>.Value);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr)>) SteamAPI.__\u003Cjniptr\u003EnativeShutdown\u0028\u0029V)(num2, num3);
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

    [LineNumberTable(62)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool isSteamRunning(bool checkNative)
    {
      int num = checkNative ? 1 : 0;
      return SteamAPI.isRunning && (num == 0 || SteamAPI.isSteamRunningNative());
    }

    [Modifiers]
    private static bool isSteamRunningNative()
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamAPI.__\u003Cjniptr\u003EisSteamRunningNative\u0028\u0029Z == IntPtr.Zero)
        SteamAPI.__\u003Cjniptr\u003EisSteamRunningNative\u0028\u0029Z = JNI.Frame.GetFuncPtr(SteamAPI.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamAPI", nameof (isSteamRunningNative), "()Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamAPI.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamAPI>.Value);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr)>) SteamAPI.__\u003Cjniptr\u003EisSteamRunningNative\u0028\u0029Z)(num2, num3);
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

    [LineNumberTable(5)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public SteamAPI()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void skipLoadLibraries() => SteamAPI.isNativeAPILoaded = true;

    [LineNumberTable(new byte[] {16, 127, 5, 127, 5})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void printDebugInfo(PrintStream stream)
    {
      stream.println(new StringBuilder().append("  Steam API initialized: ").append(SteamAPI.isRunning).toString());
      stream.println(new StringBuilder().append("  Steam client active: ").append(SteamAPI.isSteamRunning()).toString());
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static bool isIsNativeAPILoaded() => SteamAPI.isNativeAPILoaded;

    [Modifiers]
    public static void releaseCurrentThreadMemory()
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamAPI.__\u003Cjniptr\u003EreleaseCurrentThreadMemory\u0028\u0029V == IntPtr.Zero)
        SteamAPI.__\u003Cjniptr\u003EreleaseCurrentThreadMemory\u0028\u0029V = JNI.Frame.GetFuncPtr(SteamAPI.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamAPI", nameof (releaseCurrentThreadMemory), "()V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamAPI.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamAPI>.Value);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr)>) SteamAPI.__\u003Cjniptr\u003EreleaseCurrentThreadMemory\u0028\u0029V)(num2, num3);
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
    internal static long getSteamAppsPointer()
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamAPI.__\u003Cjniptr\u003EgetSteamAppsPointer\u0028\u0029J == IntPtr.Zero)
        SteamAPI.__\u003Cjniptr\u003EgetSteamAppsPointer\u0028\u0029J = JNI.Frame.GetFuncPtr(SteamAPI.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamAPI", nameof (getSteamAppsPointer), "()J");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamAPI.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamAPI>.Value);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<long (IntPtr, IntPtr)>) SteamAPI.__\u003Cjniptr\u003EgetSteamAppsPointer\u0028\u0029J)(num2, num3);
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
    internal static long getSteamControllerPointer()
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamAPI.__\u003Cjniptr\u003EgetSteamControllerPointer\u0028\u0029J == IntPtr.Zero)
        SteamAPI.__\u003Cjniptr\u003EgetSteamControllerPointer\u0028\u0029J = JNI.Frame.GetFuncPtr(SteamAPI.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamAPI", nameof (getSteamControllerPointer), "()J");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamAPI.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamAPI>.Value);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<long (IntPtr, IntPtr)>) SteamAPI.__\u003Cjniptr\u003EgetSteamControllerPointer\u0028\u0029J)(num2, num3);
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
    internal static long getSteamFriendsPointer()
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamAPI.__\u003Cjniptr\u003EgetSteamFriendsPointer\u0028\u0029J == IntPtr.Zero)
        SteamAPI.__\u003Cjniptr\u003EgetSteamFriendsPointer\u0028\u0029J = JNI.Frame.GetFuncPtr(SteamAPI.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamAPI", nameof (getSteamFriendsPointer), "()J");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamAPI.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamAPI>.Value);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<long (IntPtr, IntPtr)>) SteamAPI.__\u003Cjniptr\u003EgetSteamFriendsPointer\u0028\u0029J)(num2, num3);
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
    internal static long getSteamHTTPPointer()
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamAPI.__\u003Cjniptr\u003EgetSteamHTTPPointer\u0028\u0029J == IntPtr.Zero)
        SteamAPI.__\u003Cjniptr\u003EgetSteamHTTPPointer\u0028\u0029J = JNI.Frame.GetFuncPtr(SteamAPI.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamAPI", nameof (getSteamHTTPPointer), "()J");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamAPI.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamAPI>.Value);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<long (IntPtr, IntPtr)>) SteamAPI.__\u003Cjniptr\u003EgetSteamHTTPPointer\u0028\u0029J)(num2, num3);
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
    internal static long getSteamMatchmakingPointer()
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamAPI.__\u003Cjniptr\u003EgetSteamMatchmakingPointer\u0028\u0029J == IntPtr.Zero)
        SteamAPI.__\u003Cjniptr\u003EgetSteamMatchmakingPointer\u0028\u0029J = JNI.Frame.GetFuncPtr(SteamAPI.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamAPI", nameof (getSteamMatchmakingPointer), "()J");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamAPI.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamAPI>.Value);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<long (IntPtr, IntPtr)>) SteamAPI.__\u003Cjniptr\u003EgetSteamMatchmakingPointer\u0028\u0029J)(num2, num3);
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
    internal static long getSteamMatchmakingServersPointer()
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamAPI.__\u003Cjniptr\u003EgetSteamMatchmakingServersPointer\u0028\u0029J == IntPtr.Zero)
        SteamAPI.__\u003Cjniptr\u003EgetSteamMatchmakingServersPointer\u0028\u0029J = JNI.Frame.GetFuncPtr(SteamAPI.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamAPI", nameof (getSteamMatchmakingServersPointer), "()J");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamAPI.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamAPI>.Value);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<long (IntPtr, IntPtr)>) SteamAPI.__\u003Cjniptr\u003EgetSteamMatchmakingServersPointer\u0028\u0029J)(num2, num3);
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
    internal static long getSteamNetworkingPointer()
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamAPI.__\u003Cjniptr\u003EgetSteamNetworkingPointer\u0028\u0029J == IntPtr.Zero)
        SteamAPI.__\u003Cjniptr\u003EgetSteamNetworkingPointer\u0028\u0029J = JNI.Frame.GetFuncPtr(SteamAPI.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamAPI", nameof (getSteamNetworkingPointer), "()J");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamAPI.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamAPI>.Value);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<long (IntPtr, IntPtr)>) SteamAPI.__\u003Cjniptr\u003EgetSteamNetworkingPointer\u0028\u0029J)(num2, num3);
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
    internal static long getSteamRemoteStoragePointer()
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamAPI.__\u003Cjniptr\u003EgetSteamRemoteStoragePointer\u0028\u0029J == IntPtr.Zero)
        SteamAPI.__\u003Cjniptr\u003EgetSteamRemoteStoragePointer\u0028\u0029J = JNI.Frame.GetFuncPtr(SteamAPI.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamAPI", nameof (getSteamRemoteStoragePointer), "()J");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamAPI.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamAPI>.Value);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<long (IntPtr, IntPtr)>) SteamAPI.__\u003Cjniptr\u003EgetSteamRemoteStoragePointer\u0028\u0029J)(num2, num3);
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
    internal static long getSteamScreenshotsPointer()
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamAPI.__\u003Cjniptr\u003EgetSteamScreenshotsPointer\u0028\u0029J == IntPtr.Zero)
        SteamAPI.__\u003Cjniptr\u003EgetSteamScreenshotsPointer\u0028\u0029J = JNI.Frame.GetFuncPtr(SteamAPI.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamAPI", nameof (getSteamScreenshotsPointer), "()J");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamAPI.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamAPI>.Value);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<long (IntPtr, IntPtr)>) SteamAPI.__\u003Cjniptr\u003EgetSteamScreenshotsPointer\u0028\u0029J)(num2, num3);
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
    internal static long getSteamUGCPointer()
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamAPI.__\u003Cjniptr\u003EgetSteamUGCPointer\u0028\u0029J == IntPtr.Zero)
        SteamAPI.__\u003Cjniptr\u003EgetSteamUGCPointer\u0028\u0029J = JNI.Frame.GetFuncPtr(SteamAPI.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamAPI", nameof (getSteamUGCPointer), "()J");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamAPI.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamAPI>.Value);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<long (IntPtr, IntPtr)>) SteamAPI.__\u003Cjniptr\u003EgetSteamUGCPointer\u0028\u0029J)(num2, num3);
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
    internal static long getSteamUserPointer()
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamAPI.__\u003Cjniptr\u003EgetSteamUserPointer\u0028\u0029J == IntPtr.Zero)
        SteamAPI.__\u003Cjniptr\u003EgetSteamUserPointer\u0028\u0029J = JNI.Frame.GetFuncPtr(SteamAPI.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamAPI", nameof (getSteamUserPointer), "()J");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamAPI.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamAPI>.Value);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<long (IntPtr, IntPtr)>) SteamAPI.__\u003Cjniptr\u003EgetSteamUserPointer\u0028\u0029J)(num2, num3);
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
    internal static long getSteamUserStatsPointer()
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamAPI.__\u003Cjniptr\u003EgetSteamUserStatsPointer\u0028\u0029J == IntPtr.Zero)
        SteamAPI.__\u003Cjniptr\u003EgetSteamUserStatsPointer\u0028\u0029J = JNI.Frame.GetFuncPtr(SteamAPI.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamAPI", nameof (getSteamUserStatsPointer), "()J");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamAPI.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamAPI>.Value);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<long (IntPtr, IntPtr)>) SteamAPI.__\u003Cjniptr\u003EgetSteamUserStatsPointer\u0028\u0029J)(num2, num3);
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
    internal static long getSteamUtilsPointer()
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamAPI.__\u003Cjniptr\u003EgetSteamUtilsPointer\u0028\u0029J == IntPtr.Zero)
        SteamAPI.__\u003Cjniptr\u003EgetSteamUtilsPointer\u0028\u0029J = JNI.Frame.GetFuncPtr(SteamAPI.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamAPI", nameof (getSteamUtilsPointer), "()J");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamAPI.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamAPI>.Value);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<long (IntPtr, IntPtr)>) SteamAPI.__\u003Cjniptr\u003EgetSteamUtilsPointer\u0028\u0029J)(num2, num3);
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

    static CallerID __\u003CGetCallerID\u003E()
    {
      if (SteamAPI.__\u003CcallerID\u003E == null)
        SteamAPI.__\u003CcallerID\u003E = (CallerID) new SteamAPI.__\u003CCallerID\u003E();
      return SteamAPI.__\u003CcallerID\u003E;
    }

    private sealed class __\u003CCallerID\u003E : CallerID
    {
      internal __\u003CCallerID\u003E()
      {
      }
    }
  }
}
