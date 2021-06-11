// Decompiled with JetBrains decompiler
// Type: com.codedisaster.steamworks.SteamUtils
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
  public class SteamUtils : SteamInterface
  {
    private SteamUtilsCallbackAdapter callbackAdapter;
    static IntPtr __\u003Cjniptr\u003EcreateCallback\u0028Lcom\u002Fcodedisaster\u002Fsteamworks\u002FSteamUtilsCallbackAdapter\u003B\u0029J;
    [SpecialName]
    private static CallerID __\u003CcallerID\u003E;
    static IntPtr __\u003Cjniptr\u003EgetSecondsSinceAppActive\u0028J\u0029I;
    static IntPtr __\u003Cjniptr\u003EgetSecondsSinceComputerActive\u0028J\u0029I;
    static IntPtr __\u003Cjniptr\u003EgetConnectedUniverse\u0028J\u0029I;
    static IntPtr __\u003Cjniptr\u003EgetServerRealTime\u0028J\u0029I;
    static IntPtr __\u003Cjniptr\u003EgetIPCountry\u0028J\u0029Ljava\u002Flang\u002FString\u003B;
    static IntPtr __\u003Cjniptr\u003EgetImageWidth\u0028JI\u0029I;
    static IntPtr __\u003Cjniptr\u003EgetImageHeight\u0028JI\u0029I;
    static IntPtr __\u003Cjniptr\u003EgetImageSize\u0028JI\u005BI\u0029Z;
    static IntPtr __\u003Cjniptr\u003EgetImageRGBA\u0028JILjava\u002Fnio\u002FByteBuffer\u003BII\u0029Z;
    static IntPtr __\u003Cjniptr\u003EgetAppID\u0028J\u0029I;
    static IntPtr __\u003Cjniptr\u003EsetOverlayNotificationPosition\u0028JI\u0029V;
    static IntPtr __\u003Cjniptr\u003EisAPICallCompleted\u0028JJ\u005BZ\u0029Z;
    static IntPtr __\u003Cjniptr\u003EgetAPICallFailureReason\u0028JJ\u0029I;
    static IntPtr __\u003Cjniptr\u003EenableWarningMessageHook\u0028JZ\u0029V;
    static IntPtr __\u003Cjniptr\u003EisOverlayEnabled\u0028J\u0029Z;

    [Modifiers]
    private static long createCallback([In] SteamUtilsCallbackAdapter obj0)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamUtils.__\u003Cjniptr\u003EcreateCallback\u0028Lcom\u002Fcodedisaster\u002Fsteamworks\u002FSteamUtilsCallbackAdapter\u003B\u0029J == IntPtr.Zero)
        SteamUtils.__\u003Cjniptr\u003EcreateCallback\u0028Lcom\u002Fcodedisaster\u002Fsteamworks\u002FSteamUtilsCallbackAdapter\u003B\u0029J = JNI.Frame.GetFuncPtr(SteamUtils.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamUtils", nameof (createCallback), "(Lcom/codedisaster/steamworks/SteamUtilsCallbackAdapter;)J");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamUtils.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamUtils>.Value);
        IntPtr num4 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj0);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<long (IntPtr, IntPtr, IntPtr)>) SteamUtils.__\u003Cjniptr\u003EcreateCallback\u0028Lcom\u002Fcodedisaster\u002Fsteamworks\u002FSteamUtilsCallbackAdapter\u003B\u0029J)(num2, num3, num4);
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
    private static int getSecondsSinceAppActive([In] long obj0)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamUtils.__\u003Cjniptr\u003EgetSecondsSinceAppActive\u0028J\u0029I == IntPtr.Zero)
        SteamUtils.__\u003Cjniptr\u003EgetSecondsSinceAppActive\u0028J\u0029I = JNI.Frame.GetFuncPtr(SteamUtils.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamUtils", nameof (getSecondsSinceAppActive), "(J)I");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamUtils.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamUtils>.Value);
        long num4 = obj0;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<int (IntPtr, IntPtr, long)>) SteamUtils.__\u003Cjniptr\u003EgetSecondsSinceAppActive\u0028J\u0029I)((long) num2, num3, (IntPtr) num4);
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
    private static int getSecondsSinceComputerActive([In] long obj0)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamUtils.__\u003Cjniptr\u003EgetSecondsSinceComputerActive\u0028J\u0029I == IntPtr.Zero)
        SteamUtils.__\u003Cjniptr\u003EgetSecondsSinceComputerActive\u0028J\u0029I = JNI.Frame.GetFuncPtr(SteamUtils.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamUtils", nameof (getSecondsSinceComputerActive), "(J)I");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamUtils.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamUtils>.Value);
        long num4 = obj0;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<int (IntPtr, IntPtr, long)>) SteamUtils.__\u003Cjniptr\u003EgetSecondsSinceComputerActive\u0028J\u0029I)((long) num2, num3, (IntPtr) num4);
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
    private static int getConnectedUniverse([In] long obj0)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamUtils.__\u003Cjniptr\u003EgetConnectedUniverse\u0028J\u0029I == IntPtr.Zero)
        SteamUtils.__\u003Cjniptr\u003EgetConnectedUniverse\u0028J\u0029I = JNI.Frame.GetFuncPtr(SteamUtils.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamUtils", nameof (getConnectedUniverse), "(J)I");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamUtils.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamUtils>.Value);
        long num4 = obj0;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<int (IntPtr, IntPtr, long)>) SteamUtils.__\u003Cjniptr\u003EgetConnectedUniverse\u0028J\u0029I)((long) num2, num3, (IntPtr) num4);
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
    private static int getServerRealTime([In] long obj0)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamUtils.__\u003Cjniptr\u003EgetServerRealTime\u0028J\u0029I == IntPtr.Zero)
        SteamUtils.__\u003Cjniptr\u003EgetServerRealTime\u0028J\u0029I = JNI.Frame.GetFuncPtr(SteamUtils.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamUtils", nameof (getServerRealTime), "(J)I");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamUtils.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamUtils>.Value);
        long num4 = obj0;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<int (IntPtr, IntPtr, long)>) SteamUtils.__\u003Cjniptr\u003EgetServerRealTime\u0028J\u0029I)((long) num2, num3, (IntPtr) num4);
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
    private static int getImageWidth([In] long obj0, [In] int obj1)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamUtils.__\u003Cjniptr\u003EgetImageWidth\u0028JI\u0029I == IntPtr.Zero)
        SteamUtils.__\u003Cjniptr\u003EgetImageWidth\u0028JI\u0029I = JNI.Frame.GetFuncPtr(SteamUtils.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamUtils", nameof (getImageWidth), "(JI)I");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamUtils.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamUtils>.Value);
        long num4 = obj0;
        int num5 = obj1;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<int (IntPtr, IntPtr, long, int)>) SteamUtils.__\u003Cjniptr\u003EgetImageWidth\u0028JI\u0029I)((int) num2, (long) num3, (IntPtr) num4, (IntPtr) num5);
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
    private static int getImageHeight([In] long obj0, [In] int obj1)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamUtils.__\u003Cjniptr\u003EgetImageHeight\u0028JI\u0029I == IntPtr.Zero)
        SteamUtils.__\u003Cjniptr\u003EgetImageHeight\u0028JI\u0029I = JNI.Frame.GetFuncPtr(SteamUtils.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamUtils", nameof (getImageHeight), "(JI)I");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamUtils.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamUtils>.Value);
        long num4 = obj0;
        int num5 = obj1;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<int (IntPtr, IntPtr, long, int)>) SteamUtils.__\u003Cjniptr\u003EgetImageHeight\u0028JI\u0029I)((int) num2, (long) num3, (IntPtr) num4, (IntPtr) num5);
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
    private static bool getImageSize([In] long obj0, [In] int obj1, [In] int[] obj2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamUtils.__\u003Cjniptr\u003EgetImageSize\u0028JI\u005BI\u0029Z == IntPtr.Zero)
        SteamUtils.__\u003Cjniptr\u003EgetImageSize\u0028JI\u005BI\u0029Z = JNI.Frame.GetFuncPtr(SteamUtils.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamUtils", nameof (getImageSize), "(JI[I)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamUtils.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamUtils>.Value);
        long num4 = obj0;
        int num5 = obj1;
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj2);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, long, int, IntPtr)>) SteamUtils.__\u003Cjniptr\u003EgetImageSize\u0028JI\u005BI\u0029Z)(num2, (int) num3, num4, (IntPtr) num5, num6);
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
    private static bool getImageRGBA([In] long obj0, [In] int obj1, [In] ByteBuffer obj2, [In] int obj3, [In] int obj4)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamUtils.__\u003Cjniptr\u003EgetImageRGBA\u0028JILjava\u002Fnio\u002FByteBuffer\u003BII\u0029Z == IntPtr.Zero)
        SteamUtils.__\u003Cjniptr\u003EgetImageRGBA\u0028JILjava\u002Fnio\u002FByteBuffer\u003BII\u0029Z = JNI.Frame.GetFuncPtr(SteamUtils.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamUtils", nameof (getImageRGBA), "(JILjava/nio/ByteBuffer;II)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamUtils.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamUtils>.Value);
        long num4 = obj0;
        int num5 = obj1;
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj2);
        int num7 = obj3;
        int num8 = obj4;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, long, int, IntPtr, int, int)>) SteamUtils.__\u003Cjniptr\u003EgetImageRGBA\u0028JILjava\u002Fnio\u002FByteBuffer\u003BII\u0029Z)((int) num2, (int) num3, (IntPtr) num4, num5, (long) num6, (IntPtr) num7, (IntPtr) num8);
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
    private static int getAppID([In] long obj0)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamUtils.__\u003Cjniptr\u003EgetAppID\u0028J\u0029I == IntPtr.Zero)
        SteamUtils.__\u003Cjniptr\u003EgetAppID\u0028J\u0029I = JNI.Frame.GetFuncPtr(SteamUtils.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamUtils", nameof (getAppID), "(J)I");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamUtils.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamUtils>.Value);
        long num4 = obj0;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<int (IntPtr, IntPtr, long)>) SteamUtils.__\u003Cjniptr\u003EgetAppID\u0028J\u0029I)((long) num2, num3, (IntPtr) num4);
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
    private static void setOverlayNotificationPosition([In] long obj0, [In] int obj1)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamUtils.__\u003Cjniptr\u003EsetOverlayNotificationPosition\u0028JI\u0029V == IntPtr.Zero)
        SteamUtils.__\u003Cjniptr\u003EsetOverlayNotificationPosition\u0028JI\u0029V = JNI.Frame.GetFuncPtr(SteamUtils.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamUtils", nameof (setOverlayNotificationPosition), "(JI)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamUtils.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamUtils>.Value);
        long num4 = obj0;
        int num5 = obj1;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, long, int)>) SteamUtils.__\u003Cjniptr\u003EsetOverlayNotificationPosition\u0028JI\u0029V)((int) num2, (long) num3, (IntPtr) num4, (IntPtr) num5);
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
    private static bool isAPICallCompleted([In] long obj0, [In] long obj1, [In] bool[] obj2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamUtils.__\u003Cjniptr\u003EisAPICallCompleted\u0028JJ\u005BZ\u0029Z == IntPtr.Zero)
        SteamUtils.__\u003Cjniptr\u003EisAPICallCompleted\u0028JJ\u005BZ\u0029Z = JNI.Frame.GetFuncPtr(SteamUtils.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamUtils", nameof (isAPICallCompleted), "(JJ[Z)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamUtils.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamUtils>.Value);
        long num4 = obj0;
        long num5 = obj1;
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj2);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, long, long, IntPtr)>) SteamUtils.__\u003Cjniptr\u003EisAPICallCompleted\u0028JJ\u005BZ\u0029Z)(num2, (long) num3, num4, (IntPtr) num5, num6);
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
    private static int getAPICallFailureReason([In] long obj0, [In] long obj1)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamUtils.__\u003Cjniptr\u003EgetAPICallFailureReason\u0028JJ\u0029I == IntPtr.Zero)
        SteamUtils.__\u003Cjniptr\u003EgetAPICallFailureReason\u0028JJ\u0029I = JNI.Frame.GetFuncPtr(SteamUtils.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamUtils", nameof (getAPICallFailureReason), "(JJ)I");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamUtils.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamUtils>.Value);
        long num4 = obj0;
        long num5 = obj1;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<int (IntPtr, IntPtr, long, long)>) SteamUtils.__\u003Cjniptr\u003EgetAPICallFailureReason\u0028JJ\u0029I)((long) num2, (long) num3, (IntPtr) num4, (IntPtr) num5);
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
    private static void enableWarningMessageHook([In] long obj0, [In] bool obj1)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamUtils.__\u003Cjniptr\u003EenableWarningMessageHook\u0028JZ\u0029V == IntPtr.Zero)
        SteamUtils.__\u003Cjniptr\u003EenableWarningMessageHook\u0028JZ\u0029V = JNI.Frame.GetFuncPtr(SteamUtils.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamUtils", nameof (enableWarningMessageHook), "(JZ)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamUtils.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamUtils>.Value);
        long num4 = obj0;
        int num5 = obj1 ? 1 : 0;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, long, bool)>) SteamUtils.__\u003Cjniptr\u003EenableWarningMessageHook\u0028JZ\u0029V)((bool) num2, (long) num3, (IntPtr) num4, (IntPtr) num5);
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
    private static bool isOverlayEnabled([In] long obj0)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamUtils.__\u003Cjniptr\u003EisOverlayEnabled\u0028J\u0029Z == IntPtr.Zero)
        SteamUtils.__\u003Cjniptr\u003EisOverlayEnabled\u0028J\u0029Z = JNI.Frame.GetFuncPtr(SteamUtils.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamUtils", nameof (isOverlayEnabled), "(J)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamUtils.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamUtils>.Value);
        long num4 = obj0;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, long)>) SteamUtils.__\u003Cjniptr\u003EisOverlayEnabled\u0028J\u0029Z)((long) num2, num3, (IntPtr) num4);
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

    [LineNumberTable(new byte[] {159, 183, 109, 108, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public SteamUtils(SteamUtilsCallback callback)
      : base(SteamAPI.getSteamUtilsPointer())
    {
      SteamUtils steamUtils = this;
      this.callbackAdapter = new SteamUtilsCallbackAdapter(callback);
      this.setCallback(SteamUtils.createCallback(this.callbackAdapter));
    }

    [LineNumberTable(47)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getSecondsSinceAppActive() => SteamUtils.getSecondsSinceAppActive(this.pointer);

    [LineNumberTable(51)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getSecondsSinceComputerActive() => SteamUtils.getSecondsSinceComputerActive(this.pointer);

    [LineNumberTable(55)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual SteamUniverse getConnectedUniverse() => SteamUniverse.byValue(SteamUtils.getConnectedUniverse(this.pointer));

    [LineNumberTable(59)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getServerRealTime() => SteamUtils.getServerRealTime(this.pointer);

    [LineNumberTable(63)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getImageWidth(int image) => SteamUtils.getImageWidth(this.pointer, image);

    [LineNumberTable(67)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getImageHeight(int image) => SteamUtils.getImageHeight(this.pointer, image);

    [LineNumberTable(71)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool getImageSize(int image, int[] size) => SteamUtils.getImageSize(this.pointer, image, size);

    [Throws(new string[] {"com.codedisaster.steamworks.SteamException"})]
    [LineNumberTable(new byte[] {25, 104, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool getImageRGBA(int image, ByteBuffer dest)
    {
      if (!dest.isDirect())
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new SteamException("Direct buffer required!");
      }
      return SteamUtils.getImageRGBA(this.pointer, image, dest, ((Buffer) dest).position(), ((Buffer) dest).remaining());
    }

    [LineNumberTable(82)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getAppID() => SteamUtils.getAppID(this.pointer);

    [LineNumberTable(new byte[] {36, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setOverlayNotificationPosition(SteamUtils.NotificationPosition position) => SteamUtils.setOverlayNotificationPosition(this.pointer, position.ordinal());

    [LineNumberTable(90)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isAPICallCompleted(SteamAPICall handle, bool[] result) => SteamUtils.isAPICallCompleted(this.pointer, handle.handle, result);

    [LineNumberTable(94)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual SteamUtils.SteamAPICallFailure getAPICallFailureReason(
      SteamAPICall handle)
    {
      return SteamUtils.SteamAPICallFailure.byValue(SteamUtils.getAPICallFailureReason(this.pointer, handle.handle));
    }

    [LineNumberTable(new byte[] {48, 108, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setWarningMessageHook(SteamAPIWarningMessageHook messageHook)
    {
      this.callbackAdapter.setWarningMessageHook(messageHook);
      SteamUtils.enableWarningMessageHook(this.callback, messageHook != null);
    }

    [LineNumberTable(103)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isOverlayEnabled() => SteamUtils.isOverlayEnabled(this.pointer);

    [Modifiers]
    private static string getIPCountry([In] long obj0)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamUtils.__\u003Cjniptr\u003EgetIPCountry\u0028J\u0029Ljava\u002Flang\u002FString\u003B == IntPtr.Zero)
        SteamUtils.__\u003Cjniptr\u003EgetIPCountry\u0028J\u0029Ljava\u002Flang\u002FString\u003B = JNI.Frame.GetFuncPtr(SteamUtils.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamUtils", nameof (getIPCountry), "(J)Ljava/lang/String;");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamUtils.__\u003CGetCallerID\u003E());
      try
      {
        ref JNI.Frame local = ref frame;
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamUtils>.Value);
        long num4 = obj0;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        IntPtr num5 = __calli((__FnPtr<IntPtr (IntPtr, IntPtr, long)>) SteamUtils.__\u003Cjniptr\u003EgetIPCountry\u0028J\u0029Ljava\u002Flang\u002FString\u003B)((long) num2, num3, (IntPtr) num4);
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
    [LineNumberTable(5)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void dispose() => base.dispose();

    new static CallerID __\u003CGetCallerID\u003E()
    {
      if (SteamUtils.__\u003CcallerID\u003E == null)
        SteamUtils.__\u003CcallerID\u003E = (CallerID) new SteamUtils.__\u003CCallerID\u003E();
      return SteamUtils.__\u003CcallerID\u003E;
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
    [Signature("Ljava/lang/Enum<Lcom/codedisaster/steamworks/SteamUtils$NotificationPosition;>;")]
    [Modifiers]
    [Serializable]
    public sealed class NotificationPosition : Enum
    {
      [Modifiers]
      internal static SteamUtils.NotificationPosition __\u003C\u003ETopLeft;
      [Modifiers]
      internal static SteamUtils.NotificationPosition __\u003C\u003ETopRight;
      [Modifiers]
      internal static SteamUtils.NotificationPosition __\u003C\u003EBottomLeft;
      [Modifiers]
      internal static SteamUtils.NotificationPosition __\u003C\u003EBottomRight;
      [Modifiers]
      private static SteamUtils.NotificationPosition[] \u0024VALUES;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [Signature("()V")]
      [LineNumberTable(31)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private NotificationPosition([In] string obj0, [In] int obj1)
        : base(obj0, obj1)
      {
        GC.KeepAlive((object) this);
      }

      [LineNumberTable(31)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static SteamUtils.NotificationPosition[] values() => (SteamUtils.NotificationPosition[]) SteamUtils.NotificationPosition.\u0024VALUES.Clone();

      [LineNumberTable(31)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static SteamUtils.NotificationPosition valueOf(string name) => (SteamUtils.NotificationPosition) Enum.valueOf((Class) ClassLiteral<SteamUtils.NotificationPosition>.Value, name);

      [LineNumberTable(new byte[] {159, 134, 77, 112, 112, 112, 240, 60})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static NotificationPosition()
      {
        if (ByteCodeHelper.isAlreadyInited("com.codedisaster.steamworks.SteamUtils$NotificationPosition"))
          return;
        SteamUtils.NotificationPosition.__\u003C\u003ETopLeft = new SteamUtils.NotificationPosition(nameof (TopLeft), 0);
        SteamUtils.NotificationPosition.__\u003C\u003ETopRight = new SteamUtils.NotificationPosition(nameof (TopRight), 1);
        SteamUtils.NotificationPosition.__\u003C\u003EBottomLeft = new SteamUtils.NotificationPosition(nameof (BottomLeft), 2);
        SteamUtils.NotificationPosition.__\u003C\u003EBottomRight = new SteamUtils.NotificationPosition(nameof (BottomRight), 3);
        SteamUtils.NotificationPosition.\u0024VALUES = new SteamUtils.NotificationPosition[4]
        {
          SteamUtils.NotificationPosition.__\u003C\u003ETopLeft,
          SteamUtils.NotificationPosition.__\u003C\u003ETopRight,
          SteamUtils.NotificationPosition.__\u003C\u003EBottomLeft,
          SteamUtils.NotificationPosition.__\u003C\u003EBottomRight
        };
      }

      [Modifiers]
      public static SteamUtils.NotificationPosition TopLeft
      {
        [HideFromJava] get => SteamUtils.NotificationPosition.__\u003C\u003ETopLeft;
      }

      [Modifiers]
      public static SteamUtils.NotificationPosition TopRight
      {
        [HideFromJava] get => SteamUtils.NotificationPosition.__\u003C\u003ETopRight;
      }

      [Modifiers]
      public static SteamUtils.NotificationPosition BottomLeft
      {
        [HideFromJava] get => SteamUtils.NotificationPosition.__\u003C\u003EBottomLeft;
      }

      [Modifiers]
      public static SteamUtils.NotificationPosition BottomRight
      {
        [HideFromJava] get => SteamUtils.NotificationPosition.__\u003C\u003EBottomRight;
      }

      [HideFromJava]
      [Serializable]
      public enum __Enum
      {
        TopLeft,
        TopRight,
        BottomLeft,
        BottomRight,
      }
    }

    [InnerClass]
    [Signature("Ljava/lang/Enum<Lcom/codedisaster/steamworks/SteamUtils$SteamAPICallFailure;>;")]
    [Modifiers]
    [Serializable]
    public sealed class SteamAPICallFailure : Enum
    {
      [Modifiers]
      internal static SteamUtils.SteamAPICallFailure __\u003C\u003ENone;
      [Modifiers]
      internal static SteamUtils.SteamAPICallFailure __\u003C\u003ESteamGone;
      [Modifiers]
      internal static SteamUtils.SteamAPICallFailure __\u003C\u003ENetworkFailure;
      [Modifiers]
      internal static SteamUtils.SteamAPICallFailure __\u003C\u003EInvalidHandle;
      [Modifiers]
      internal static SteamUtils.SteamAPICallFailure __\u003C\u003EMismatchedCallback;
      [Modifiers]
      private int code;
      [Modifiers]
      private static SteamUtils.SteamAPICallFailure[] values;
      [Modifiers]
      private static SteamUtils.SteamAPICallFailure[] \u0024VALUES;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {159, 164, 115, 105, 2, 230, 69})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal static SteamUtils.SteamAPICallFailure byValue([In] int obj0)
      {
        SteamUtils.SteamAPICallFailure[] values = SteamUtils.SteamAPICallFailure.values;
        int length = values.Length;
        for (int index = 0; index < length; ++index)
        {
          SteamUtils.SteamAPICallFailure steamApiCallFailure = values[index];
          if (steamApiCallFailure.code == obj0)
            return steamApiCallFailure;
        }
        return SteamUtils.SteamAPICallFailure.__\u003C\u003ENone;
      }

      [Signature("(I)V")]
      [LineNumberTable(new byte[] {159, 159, 106, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private SteamAPICallFailure([In] string obj0, [In] int obj1, [In] int obj2)
        : base(obj0, obj1)
      {
        SteamUtils.SteamAPICallFailure steamApiCallFailure = this;
        this.code = obj2;
        GC.KeepAlive((object) this);
      }

      [LineNumberTable(7)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static SteamUtils.SteamAPICallFailure[] values() => (SteamUtils.SteamAPICallFailure[]) SteamUtils.SteamAPICallFailure.\u0024VALUES.Clone();

      [LineNumberTable(7)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static SteamUtils.SteamAPICallFailure valueOf(string name) => (SteamUtils.SteamAPICallFailure) Enum.valueOf((Class) ClassLiteral<SteamUtils.SteamAPICallFailure>.Value, name);

      [LineNumberTable(new byte[] {159, 140, 77, 113, 113, 113, 113, 241, 59, 255, 20, 72})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static SteamAPICallFailure()
      {
        if (ByteCodeHelper.isAlreadyInited("com.codedisaster.steamworks.SteamUtils$SteamAPICallFailure"))
          return;
        SteamUtils.SteamAPICallFailure.__\u003C\u003ENone = new SteamUtils.SteamAPICallFailure(nameof (None), 0, -1);
        SteamUtils.SteamAPICallFailure.__\u003C\u003ESteamGone = new SteamUtils.SteamAPICallFailure(nameof (SteamGone), 1, 0);
        SteamUtils.SteamAPICallFailure.__\u003C\u003ENetworkFailure = new SteamUtils.SteamAPICallFailure(nameof (NetworkFailure), 2, 1);
        SteamUtils.SteamAPICallFailure.__\u003C\u003EInvalidHandle = new SteamUtils.SteamAPICallFailure(nameof (InvalidHandle), 3, 2);
        SteamUtils.SteamAPICallFailure.__\u003C\u003EMismatchedCallback = new SteamUtils.SteamAPICallFailure(nameof (MismatchedCallback), 4, 3);
        SteamUtils.SteamAPICallFailure.\u0024VALUES = new SteamUtils.SteamAPICallFailure[5]
        {
          SteamUtils.SteamAPICallFailure.__\u003C\u003ENone,
          SteamUtils.SteamAPICallFailure.__\u003C\u003ESteamGone,
          SteamUtils.SteamAPICallFailure.__\u003C\u003ENetworkFailure,
          SteamUtils.SteamAPICallFailure.__\u003C\u003EInvalidHandle,
          SteamUtils.SteamAPICallFailure.__\u003C\u003EMismatchedCallback
        };
        SteamUtils.SteamAPICallFailure.values = SteamUtils.SteamAPICallFailure.values();
      }

      [Modifiers]
      public static SteamUtils.SteamAPICallFailure None
      {
        [HideFromJava] get => SteamUtils.SteamAPICallFailure.__\u003C\u003ENone;
      }

      [Modifiers]
      public static SteamUtils.SteamAPICallFailure SteamGone
      {
        [HideFromJava] get => SteamUtils.SteamAPICallFailure.__\u003C\u003ESteamGone;
      }

      [Modifiers]
      public static SteamUtils.SteamAPICallFailure NetworkFailure
      {
        [HideFromJava] get => SteamUtils.SteamAPICallFailure.__\u003C\u003ENetworkFailure;
      }

      [Modifiers]
      public static SteamUtils.SteamAPICallFailure InvalidHandle
      {
        [HideFromJava] get => SteamUtils.SteamAPICallFailure.__\u003C\u003EInvalidHandle;
      }

      [Modifiers]
      public static SteamUtils.SteamAPICallFailure MismatchedCallback
      {
        [HideFromJava] get => SteamUtils.SteamAPICallFailure.__\u003C\u003EMismatchedCallback;
      }

      [HideFromJava]
      [Serializable]
      public enum __Enum
      {
        None,
        SteamGone,
        NetworkFailure,
        InvalidHandle,
        MismatchedCallback,
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
