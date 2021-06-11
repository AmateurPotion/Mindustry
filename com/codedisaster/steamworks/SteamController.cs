// Decompiled with JetBrains decompiler
// Type: com.codedisaster.steamworks.SteamController
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
  public class SteamController : SteamInterface
  {
    public const int STEAM_CONTROLLER_MAX_COUNT = 16;
    public const int STEAM_CONTROLLER_MAX_ANALOG_ACTIONS = 16;
    public const int STEAM_CONTROLLER_MAX_DIGITAL_ACTIONS = 128;
    public const int STEAM_CONTROLLER_MAX_ORIGINS = 8;
    public const long STEAM_CONTROLLER_HANDLE_ALL_CONTROLLERS = -1;
    public const float STEAM_CONTROLLER_MIN_ANALOG_ACTION_DATA = -1f;
    public const float STEAM_CONTROLLER_MAX_ANALOG_ACTION_DATA = 1f;
    private long[] controllerHandles;
    private int[] actionOrigins;
    static IntPtr __\u003Cjniptr\u003Einit\u0028J\u0029Z;
    [SpecialName]
    private static CallerID __\u003CcallerID\u003E;
    static IntPtr __\u003Cjniptr\u003Eshutdown\u0028J\u0029Z;
    static IntPtr __\u003Cjniptr\u003ErunFrame\u0028J\u0029V;
    static IntPtr __\u003Cjniptr\u003EgetConnectedControllers\u0028J\u005BJ\u0029I;
    static IntPtr __\u003Cjniptr\u003EshowBindingPanel\u0028JJ\u0029Z;
    static IntPtr __\u003Cjniptr\u003EgetActionSetHandle\u0028JLjava\u002Flang\u002FString\u003B\u0029J;
    static IntPtr __\u003Cjniptr\u003EactivateActionSet\u0028JJJ\u0029V;
    static IntPtr __\u003Cjniptr\u003EgetCurrentActionSet\u0028JJ\u0029J;
    static IntPtr __\u003Cjniptr\u003EgetDigitalActionHandle\u0028JLjava\u002Flang\u002FString\u003B\u0029J;
    static IntPtr __\u003Cjniptr\u003EgetDigitalActionData\u0028JJJLcom\u002Fcodedisaster\u002Fsteamworks\u002FSteamControllerDigitalActionData\u003B\u0029V;
    static IntPtr __\u003Cjniptr\u003EgetDigitalActionOrigins\u0028JJJJ\u005BI\u0029I;
    static IntPtr __\u003Cjniptr\u003EgetAnalogActionHandle\u0028JLjava\u002Flang\u002FString\u003B\u0029J;
    static IntPtr __\u003Cjniptr\u003EgetAnalogActionData\u0028JJJLcom\u002Fcodedisaster\u002Fsteamworks\u002FSteamControllerAnalogActionData\u003B\u0029V;
    static IntPtr __\u003Cjniptr\u003EgetAnalogActionOrigins\u0028JJJJ\u005BI\u0029I;
    static IntPtr __\u003Cjniptr\u003EstopAnalogActionMomentum\u0028JJJ\u0029V;
    static IntPtr __\u003Cjniptr\u003EtriggerHapticPulse\u0028JJII\u0029V;
    static IntPtr __\u003Cjniptr\u003EtriggerRepeatedHapticPulse\u0028JJIIIII\u0029V;
    static IntPtr __\u003Cjniptr\u003EtriggerVibration\u0028JJSS\u0029V;
    static IntPtr __\u003Cjniptr\u003EsetLEDColor\u0028JJBBBI\u0029V;
    static IntPtr __\u003Cjniptr\u003EgetGamepadIndexForController\u0028JJ\u0029I;
    static IntPtr __\u003Cjniptr\u003EgetControllerForGamepadIndex\u0028JI\u0029J;
    static IntPtr __\u003Cjniptr\u003EgetMotionData\u0028JJ\u005BF\u0029V;
    static IntPtr __\u003Cjniptr\u003EshowDigitalActionOrigins\u0028JJJFFF\u0029Z;
    static IntPtr __\u003Cjniptr\u003EshowAnalogActionOrigins\u0028JJJFFF\u0029Z;
    static IntPtr __\u003Cjniptr\u003EgetStringForActionOrigin\u0028JI\u0029Ljava\u002Flang\u002FString\u003B;
    static IntPtr __\u003Cjniptr\u003EgetGlyphForActionOrigin\u0028JI\u0029Ljava\u002Flang\u002FString\u003B;
    static IntPtr __\u003Cjniptr\u003EgetInputTypeForHandle\u0028JJ\u0029I;

    [Modifiers]
    private static bool init([In] long obj0)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamController.__\u003Cjniptr\u003Einit\u0028J\u0029Z == IntPtr.Zero)
        SteamController.__\u003Cjniptr\u003Einit\u0028J\u0029Z = JNI.Frame.GetFuncPtr(SteamController.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamController", nameof (init), "(J)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamController.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamController>.Value);
        long num4 = obj0;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, long)>) SteamController.__\u003Cjniptr\u003Einit\u0028J\u0029Z)((long) num2, num3, (IntPtr) num4);
      }
      catch (object ex)
      {
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
    private static bool shutdown([In] long obj0)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamController.__\u003Cjniptr\u003Eshutdown\u0028J\u0029Z == IntPtr.Zero)
        SteamController.__\u003Cjniptr\u003Eshutdown\u0028J\u0029Z = JNI.Frame.GetFuncPtr(SteamController.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamController", nameof (shutdown), "(J)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamController.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamController>.Value);
        long num4 = obj0;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, long)>) SteamController.__\u003Cjniptr\u003Eshutdown\u0028J\u0029Z)((long) num2, num3, (IntPtr) num4);
      }
      catch (object ex)
      {
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
    private static void runFrame([In] long obj0)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamController.__\u003Cjniptr\u003ErunFrame\u0028J\u0029V == IntPtr.Zero)
        SteamController.__\u003Cjniptr\u003ErunFrame\u0028J\u0029V = JNI.Frame.GetFuncPtr(SteamController.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamController", nameof (runFrame), "(J)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamController.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamController>.Value);
        long num4 = obj0;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, long)>) SteamController.__\u003Cjniptr\u003ErunFrame\u0028J\u0029V)((long) num2, num3, (IntPtr) num4);
      }
      catch (object ex)
      {
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
    private static int getConnectedControllers([In] long obj0, [In] long[] obj1)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamController.__\u003Cjniptr\u003EgetConnectedControllers\u0028J\u005BJ\u0029I == IntPtr.Zero)
        SteamController.__\u003Cjniptr\u003EgetConnectedControllers\u0028J\u005BJ\u0029I = JNI.Frame.GetFuncPtr(SteamController.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamController", nameof (getConnectedControllers), "(J[J)I");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamController.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamController>.Value);
        long num4 = obj0;
        IntPtr num5 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj1);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<int (IntPtr, IntPtr, long, IntPtr)>) SteamController.__\u003Cjniptr\u003EgetConnectedControllers\u0028J\u005BJ\u0029I)(num2, (long) num3, (IntPtr) num4, num5);
      }
      catch (object ex)
      {
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
    private static bool showBindingPanel([In] long obj0, [In] long obj1)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamController.__\u003Cjniptr\u003EshowBindingPanel\u0028JJ\u0029Z == IntPtr.Zero)
        SteamController.__\u003Cjniptr\u003EshowBindingPanel\u0028JJ\u0029Z = JNI.Frame.GetFuncPtr(SteamController.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamController", nameof (showBindingPanel), "(JJ)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamController.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamController>.Value);
        long num4 = obj0;
        long num5 = obj1;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, long, long)>) SteamController.__\u003Cjniptr\u003EshowBindingPanel\u0028JJ\u0029Z)((long) num2, (long) num3, (IntPtr) num4, (IntPtr) num5);
      }
      catch (object ex)
      {
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
    private static long getActionSetHandle([In] long obj0, [In] string obj1)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamController.__\u003Cjniptr\u003EgetActionSetHandle\u0028JLjava\u002Flang\u002FString\u003B\u0029J == IntPtr.Zero)
        SteamController.__\u003Cjniptr\u003EgetActionSetHandle\u0028JLjava\u002Flang\u002FString\u003B\u0029J = JNI.Frame.GetFuncPtr(SteamController.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamController", nameof (getActionSetHandle), "(JLjava/lang/String;)J");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamController.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamController>.Value);
        long num4 = obj0;
        IntPtr num5 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj1);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<long (IntPtr, IntPtr, long, IntPtr)>) SteamController.__\u003Cjniptr\u003EgetActionSetHandle\u0028JLjava\u002Flang\u002FString\u003B\u0029J)(num2, (long) num3, (IntPtr) num4, num5);
      }
      catch (object ex)
      {
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
    private static void activateActionSet([In] long obj0, [In] long obj1, [In] long obj2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamController.__\u003Cjniptr\u003EactivateActionSet\u0028JJJ\u0029V == IntPtr.Zero)
        SteamController.__\u003Cjniptr\u003EactivateActionSet\u0028JJJ\u0029V = JNI.Frame.GetFuncPtr(SteamController.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamController", nameof (activateActionSet), "(JJJ)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamController.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamController>.Value);
        long num4 = obj0;
        long num5 = obj1;
        long num6 = obj2;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, long, long, long)>) SteamController.__\u003Cjniptr\u003EactivateActionSet\u0028JJJ\u0029V)((long) num2, (long) num3, num4, (IntPtr) num5, (IntPtr) num6);
      }
      catch (object ex)
      {
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
    private static long getCurrentActionSet([In] long obj0, [In] long obj1)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamController.__\u003Cjniptr\u003EgetCurrentActionSet\u0028JJ\u0029J == IntPtr.Zero)
        SteamController.__\u003Cjniptr\u003EgetCurrentActionSet\u0028JJ\u0029J = JNI.Frame.GetFuncPtr(SteamController.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamController", nameof (getCurrentActionSet), "(JJ)J");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamController.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamController>.Value);
        long num4 = obj0;
        long num5 = obj1;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<long (IntPtr, IntPtr, long, long)>) SteamController.__\u003Cjniptr\u003EgetCurrentActionSet\u0028JJ\u0029J)((long) num2, (long) num3, (IntPtr) num4, (IntPtr) num5);
      }
      catch (object ex)
      {
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
    private static long getDigitalActionHandle([In] long obj0, [In] string obj1)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamController.__\u003Cjniptr\u003EgetDigitalActionHandle\u0028JLjava\u002Flang\u002FString\u003B\u0029J == IntPtr.Zero)
        SteamController.__\u003Cjniptr\u003EgetDigitalActionHandle\u0028JLjava\u002Flang\u002FString\u003B\u0029J = JNI.Frame.GetFuncPtr(SteamController.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamController", nameof (getDigitalActionHandle), "(JLjava/lang/String;)J");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamController.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamController>.Value);
        long num4 = obj0;
        IntPtr num5 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj1);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<long (IntPtr, IntPtr, long, IntPtr)>) SteamController.__\u003Cjniptr\u003EgetDigitalActionHandle\u0028JLjava\u002Flang\u002FString\u003B\u0029J)(num2, (long) num3, (IntPtr) num4, num5);
      }
      catch (object ex)
      {
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
    private static void getDigitalActionData(
      [In] long obj0,
      [In] long obj1,
      [In] long obj2,
      [In] SteamControllerDigitalActionData obj3)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamController.__\u003Cjniptr\u003EgetDigitalActionData\u0028JJJLcom\u002Fcodedisaster\u002Fsteamworks\u002FSteamControllerDigitalActionData\u003B\u0029V == IntPtr.Zero)
        SteamController.__\u003Cjniptr\u003EgetDigitalActionData\u0028JJJLcom\u002Fcodedisaster\u002Fsteamworks\u002FSteamControllerDigitalActionData\u003B\u0029V = JNI.Frame.GetFuncPtr(SteamController.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamController", nameof (getDigitalActionData), "(JJJLcom/codedisaster/steamworks/SteamControllerDigitalActionData;)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamController.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamController>.Value);
        long num4 = obj0;
        long num5 = obj1;
        long num6 = obj2;
        IntPtr num7 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj3);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, long, long, long, IntPtr)>) SteamController.__\u003Cjniptr\u003EgetDigitalActionData\u0028JJJLcom\u002Fcodedisaster\u002Fsteamworks\u002FSteamControllerDigitalActionData\u003B\u0029V)(num2, (long) num3, num4, num5, (IntPtr) num6, num7);
      }
      catch (object ex)
      {
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
    private static int getDigitalActionOrigins(
      [In] long obj0,
      [In] long obj1,
      [In] long obj2,
      [In] long obj3,
      [In] int[] obj4)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamController.__\u003Cjniptr\u003EgetDigitalActionOrigins\u0028JJJJ\u005BI\u0029I == IntPtr.Zero)
        SteamController.__\u003Cjniptr\u003EgetDigitalActionOrigins\u0028JJJJ\u005BI\u0029I = JNI.Frame.GetFuncPtr(SteamController.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamController", nameof (getDigitalActionOrigins), "(JJJJ[I)I");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamController.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamController>.Value);
        long num4 = obj0;
        long num5 = obj1;
        long num6 = obj2;
        long num7 = obj3;
        IntPtr num8 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj4);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<int (IntPtr, IntPtr, long, long, long, long, IntPtr)>) SteamController.__\u003Cjniptr\u003EgetDigitalActionOrigins\u0028JJJJ\u005BI\u0029I)(num2, (long) num3, num4, num5, num6, (IntPtr) num7, num8);
      }
      catch (object ex)
      {
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
    private static long getAnalogActionHandle([In] long obj0, [In] string obj1)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamController.__\u003Cjniptr\u003EgetAnalogActionHandle\u0028JLjava\u002Flang\u002FString\u003B\u0029J == IntPtr.Zero)
        SteamController.__\u003Cjniptr\u003EgetAnalogActionHandle\u0028JLjava\u002Flang\u002FString\u003B\u0029J = JNI.Frame.GetFuncPtr(SteamController.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamController", nameof (getAnalogActionHandle), "(JLjava/lang/String;)J");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamController.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamController>.Value);
        long num4 = obj0;
        IntPtr num5 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj1);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<long (IntPtr, IntPtr, long, IntPtr)>) SteamController.__\u003Cjniptr\u003EgetAnalogActionHandle\u0028JLjava\u002Flang\u002FString\u003B\u0029J)(num2, (long) num3, (IntPtr) num4, num5);
      }
      catch (object ex)
      {
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
    private static void getAnalogActionData(
      [In] long obj0,
      [In] long obj1,
      [In] long obj2,
      [In] SteamControllerAnalogActionData obj3)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamController.__\u003Cjniptr\u003EgetAnalogActionData\u0028JJJLcom\u002Fcodedisaster\u002Fsteamworks\u002FSteamControllerAnalogActionData\u003B\u0029V == IntPtr.Zero)
        SteamController.__\u003Cjniptr\u003EgetAnalogActionData\u0028JJJLcom\u002Fcodedisaster\u002Fsteamworks\u002FSteamControllerAnalogActionData\u003B\u0029V = JNI.Frame.GetFuncPtr(SteamController.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamController", nameof (getAnalogActionData), "(JJJLcom/codedisaster/steamworks/SteamControllerAnalogActionData;)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamController.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamController>.Value);
        long num4 = obj0;
        long num5 = obj1;
        long num6 = obj2;
        IntPtr num7 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj3);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, long, long, long, IntPtr)>) SteamController.__\u003Cjniptr\u003EgetAnalogActionData\u0028JJJLcom\u002Fcodedisaster\u002Fsteamworks\u002FSteamControllerAnalogActionData\u003B\u0029V)(num2, (long) num3, num4, num5, (IntPtr) num6, num7);
      }
      catch (object ex)
      {
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
    private static int getAnalogActionOrigins(
      [In] long obj0,
      [In] long obj1,
      [In] long obj2,
      [In] long obj3,
      [In] int[] obj4)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamController.__\u003Cjniptr\u003EgetAnalogActionOrigins\u0028JJJJ\u005BI\u0029I == IntPtr.Zero)
        SteamController.__\u003Cjniptr\u003EgetAnalogActionOrigins\u0028JJJJ\u005BI\u0029I = JNI.Frame.GetFuncPtr(SteamController.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamController", nameof (getAnalogActionOrigins), "(JJJJ[I)I");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamController.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamController>.Value);
        long num4 = obj0;
        long num5 = obj1;
        long num6 = obj2;
        long num7 = obj3;
        IntPtr num8 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj4);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<int (IntPtr, IntPtr, long, long, long, long, IntPtr)>) SteamController.__\u003Cjniptr\u003EgetAnalogActionOrigins\u0028JJJJ\u005BI\u0029I)(num2, (long) num3, num4, num5, num6, (IntPtr) num7, num8);
      }
      catch (object ex)
      {
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
    private static void stopAnalogActionMomentum([In] long obj0, [In] long obj1, [In] long obj2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamController.__\u003Cjniptr\u003EstopAnalogActionMomentum\u0028JJJ\u0029V == IntPtr.Zero)
        SteamController.__\u003Cjniptr\u003EstopAnalogActionMomentum\u0028JJJ\u0029V = JNI.Frame.GetFuncPtr(SteamController.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamController", nameof (stopAnalogActionMomentum), "(JJJ)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamController.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamController>.Value);
        long num4 = obj0;
        long num5 = obj1;
        long num6 = obj2;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, long, long, long)>) SteamController.__\u003Cjniptr\u003EstopAnalogActionMomentum\u0028JJJ\u0029V)((long) num2, (long) num3, num4, (IntPtr) num5, (IntPtr) num6);
      }
      catch (object ex)
      {
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
    private static void triggerHapticPulse([In] long obj0, [In] long obj1, [In] int obj2, [In] int obj3)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamController.__\u003Cjniptr\u003EtriggerHapticPulse\u0028JJII\u0029V == IntPtr.Zero)
        SteamController.__\u003Cjniptr\u003EtriggerHapticPulse\u0028JJII\u0029V = JNI.Frame.GetFuncPtr(SteamController.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamController", nameof (triggerHapticPulse), "(JJII)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamController.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamController>.Value);
        long num4 = obj0;
        long num5 = obj1;
        int num6 = obj2;
        int num7 = obj3;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, long, long, int, int)>) SteamController.__\u003Cjniptr\u003EtriggerHapticPulse\u0028JJII\u0029V)((int) num2, (int) num3, num4, num5, (IntPtr) num6, (IntPtr) num7);
      }
      catch (object ex)
      {
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
    private static void triggerRepeatedHapticPulse(
      [In] long obj0,
      [In] long obj1,
      [In] int obj2,
      [In] int obj3,
      [In] int obj4,
      [In] int obj5,
      [In] int obj6)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamController.__\u003Cjniptr\u003EtriggerRepeatedHapticPulse\u0028JJIIIII\u0029V == IntPtr.Zero)
        SteamController.__\u003Cjniptr\u003EtriggerRepeatedHapticPulse\u0028JJIIIII\u0029V = JNI.Frame.GetFuncPtr(SteamController.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamController", nameof (triggerRepeatedHapticPulse), "(JJIIIII)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamController.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamController>.Value);
        long num4 = obj0;
        long num5 = obj1;
        int num6 = obj2;
        int num7 = obj3;
        int num8 = obj4;
        int num9 = obj5;
        int num10 = obj6;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, long, long, int, int, int, int, int)>) SteamController.__\u003Cjniptr\u003EtriggerRepeatedHapticPulse\u0028JJIIIII\u0029V)((int) num2, (int) num3, (int) num4, (int) num5, num6, (long) num7, (long) num8, (IntPtr) num9, (IntPtr) num10);
      }
      catch (object ex)
      {
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
    private static void triggerVibration([In] long obj0, [In] long obj1, [In] short obj2, [In] short obj3)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamController.__\u003Cjniptr\u003EtriggerVibration\u0028JJSS\u0029V == IntPtr.Zero)
        SteamController.__\u003Cjniptr\u003EtriggerVibration\u0028JJSS\u0029V = JNI.Frame.GetFuncPtr(SteamController.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamController", nameof (triggerVibration), "(JJSS)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamController.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamController>.Value);
        long num4 = obj0;
        long num5 = obj1;
        int num6 = (int) obj2;
        int num7 = (int) obj3;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, long, long, short, short)>) SteamController.__\u003Cjniptr\u003EtriggerVibration\u0028JJSS\u0029V)((short) num2, (short) num3, num4, num5, (IntPtr) num6, (IntPtr) num7);
      }
      catch (object ex)
      {
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
    private static void setLEDColor(
      [In] long obj0,
      [In] long obj1,
      [In] byte obj2,
      [In] byte obj3,
      [In] byte obj4,
      [In] int obj5)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamController.__\u003Cjniptr\u003EsetLEDColor\u0028JJBBBI\u0029V == IntPtr.Zero)
        SteamController.__\u003Cjniptr\u003EsetLEDColor\u0028JJBBBI\u0029V = JNI.Frame.GetFuncPtr(SteamController.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamController", nameof (setLEDColor), "(JJBBBI)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamController.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamController>.Value);
        long num4 = obj0;
        long num5 = obj1;
        int num6 = (int) obj2;
        int num7 = (int) obj3;
        int num8 = (int) obj4;
        int num9 = obj5;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, long, long, byte, byte, byte, int)>) SteamController.__\u003Cjniptr\u003EsetLEDColor\u0028JJBBBI\u0029V)((int) num2, (byte) num3, (byte) num4, (byte) num5, (long) num6, (long) num7, (IntPtr) num8, (IntPtr) num9);
      }
      catch (object ex)
      {
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
    private static int getGamepadIndexForController([In] long obj0, [In] long obj1)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamController.__\u003Cjniptr\u003EgetGamepadIndexForController\u0028JJ\u0029I == IntPtr.Zero)
        SteamController.__\u003Cjniptr\u003EgetGamepadIndexForController\u0028JJ\u0029I = JNI.Frame.GetFuncPtr(SteamController.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamController", nameof (getGamepadIndexForController), "(JJ)I");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamController.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamController>.Value);
        long num4 = obj0;
        long num5 = obj1;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<int (IntPtr, IntPtr, long, long)>) SteamController.__\u003Cjniptr\u003EgetGamepadIndexForController\u0028JJ\u0029I)((long) num2, (long) num3, (IntPtr) num4, (IntPtr) num5);
      }
      catch (object ex)
      {
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
    private static long getControllerForGamepadIndex([In] long obj0, [In] int obj1)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamController.__\u003Cjniptr\u003EgetControllerForGamepadIndex\u0028JI\u0029J == IntPtr.Zero)
        SteamController.__\u003Cjniptr\u003EgetControllerForGamepadIndex\u0028JI\u0029J = JNI.Frame.GetFuncPtr(SteamController.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamController", nameof (getControllerForGamepadIndex), "(JI)J");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamController.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamController>.Value);
        long num4 = obj0;
        int num5 = obj1;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<long (IntPtr, IntPtr, long, int)>) SteamController.__\u003Cjniptr\u003EgetControllerForGamepadIndex\u0028JI\u0029J)((int) num2, (long) num3, (IntPtr) num4, (IntPtr) num5);
      }
      catch (object ex)
      {
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
    private static void getMotionData([In] long obj0, [In] long obj1, [In] float[] obj2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamController.__\u003Cjniptr\u003EgetMotionData\u0028JJ\u005BF\u0029V == IntPtr.Zero)
        SteamController.__\u003Cjniptr\u003EgetMotionData\u0028JJ\u005BF\u0029V = JNI.Frame.GetFuncPtr(SteamController.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamController", nameof (getMotionData), "(JJ[F)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamController.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamController>.Value);
        long num4 = obj0;
        long num5 = obj1;
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj2);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, long, long, IntPtr)>) SteamController.__\u003Cjniptr\u003EgetMotionData\u0028JJ\u005BF\u0029V)(num2, (long) num3, num4, (IntPtr) num5, num6);
      }
      catch (object ex)
      {
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
    private static bool showDigitalActionOrigins(
      [In] long obj0,
      [In] long obj1,
      [In] long obj2,
      [In] float obj3,
      [In] float obj4,
      [In] float obj5)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamController.__\u003Cjniptr\u003EshowDigitalActionOrigins\u0028JJJFFF\u0029Z == IntPtr.Zero)
        SteamController.__\u003Cjniptr\u003EshowDigitalActionOrigins\u0028JJJFFF\u0029Z = JNI.Frame.GetFuncPtr(SteamController.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamController", nameof (showDigitalActionOrigins), "(JJJFFF)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamController.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamController>.Value);
        long num4 = obj0;
        long num5 = obj1;
        long num6 = obj2;
        double num7 = (double) obj3;
        double num8 = (double) obj4;
        double num9 = (double) obj5;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, long, long, long, float, float, float)>) SteamController.__\u003Cjniptr\u003EshowDigitalActionOrigins\u0028JJJFFF\u0029Z)((float) num2, (float) num3, (float) num4, num5, num6, (long) num7, (IntPtr) num8, (IntPtr) num9);
      }
      catch (object ex)
      {
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
    private static bool showAnalogActionOrigins(
      [In] long obj0,
      [In] long obj1,
      [In] long obj2,
      [In] float obj3,
      [In] float obj4,
      [In] float obj5)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamController.__\u003Cjniptr\u003EshowAnalogActionOrigins\u0028JJJFFF\u0029Z == IntPtr.Zero)
        SteamController.__\u003Cjniptr\u003EshowAnalogActionOrigins\u0028JJJFFF\u0029Z = JNI.Frame.GetFuncPtr(SteamController.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamController", nameof (showAnalogActionOrigins), "(JJJFFF)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamController.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamController>.Value);
        long num4 = obj0;
        long num5 = obj1;
        long num6 = obj2;
        double num7 = (double) obj3;
        double num8 = (double) obj4;
        double num9 = (double) obj5;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, long, long, long, float, float, float)>) SteamController.__\u003Cjniptr\u003EshowAnalogActionOrigins\u0028JJJFFF\u0029Z)((float) num2, (float) num3, (float) num4, num5, num6, (long) num7, (IntPtr) num8, (IntPtr) num9);
      }
      catch (object ex)
      {
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
    private static string getStringForActionOrigin([In] long obj0, [In] int obj1)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamController.__\u003Cjniptr\u003EgetStringForActionOrigin\u0028JI\u0029Ljava\u002Flang\u002FString\u003B == IntPtr.Zero)
        SteamController.__\u003Cjniptr\u003EgetStringForActionOrigin\u0028JI\u0029Ljava\u002Flang\u002FString\u003B = JNI.Frame.GetFuncPtr(SteamController.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamController", nameof (getStringForActionOrigin), "(JI)Ljava/lang/String;");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamController.__\u003CGetCallerID\u003E());
      try
      {
        ref JNI.Frame local = ref frame;
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamController>.Value);
        long num4 = obj0;
        int num5 = obj1;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        IntPtr num6 = __calli((__FnPtr<IntPtr (IntPtr, IntPtr, long, int)>) SteamController.__\u003Cjniptr\u003EgetStringForActionOrigin\u0028JI\u0029Ljava\u002Flang\u002FString\u003B)((int) num2, (long) num3, (IntPtr) num4, (IntPtr) num5);
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
    private static string getGlyphForActionOrigin([In] long obj0, [In] int obj1)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamController.__\u003Cjniptr\u003EgetGlyphForActionOrigin\u0028JI\u0029Ljava\u002Flang\u002FString\u003B == IntPtr.Zero)
        SteamController.__\u003Cjniptr\u003EgetGlyphForActionOrigin\u0028JI\u0029Ljava\u002Flang\u002FString\u003B = JNI.Frame.GetFuncPtr(SteamController.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamController", nameof (getGlyphForActionOrigin), "(JI)Ljava/lang/String;");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamController.__\u003CGetCallerID\u003E());
      try
      {
        ref JNI.Frame local = ref frame;
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamController>.Value);
        long num4 = obj0;
        int num5 = obj1;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        IntPtr num6 = __calli((__FnPtr<IntPtr (IntPtr, IntPtr, long, int)>) SteamController.__\u003Cjniptr\u003EgetGlyphForActionOrigin\u0028JI\u0029Ljava\u002Flang\u002FString\u003B)((int) num2, (long) num3, (IntPtr) num4, (IntPtr) num5);
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
    private static int getInputTypeForHandle([In] long obj0, [In] long obj1)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamController.__\u003Cjniptr\u003EgetInputTypeForHandle\u0028JJ\u0029I == IntPtr.Zero)
        SteamController.__\u003Cjniptr\u003EgetInputTypeForHandle\u0028JJ\u0029I = JNI.Frame.GetFuncPtr(SteamController.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamController", nameof (getInputTypeForHandle), "(JJ)I");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamController.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamController>.Value);
        long num4 = obj0;
        long num5 = obj1;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<int (IntPtr, IntPtr, long, long)>) SteamController.__\u003Cjniptr\u003EgetInputTypeForHandle\u0028JJ\u0029I)((long) num2, (long) num3, (IntPtr) num4, (IntPtr) num5);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [LineNumberTable(new byte[] {160, 182, 237, 60, 109, 204})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public SteamController()
      : base(SteamAPI.getSteamControllerPointer())
    {
      SteamController steamController = this;
      this.controllerHandles = new long[16];
      this.actionOrigins = new int[8];
    }

    [LineNumberTable(300)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool init() => SteamController.init(this.pointer);

    [LineNumberTable(304)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool shutdown() => SteamController.shutdown(this.pointer);

    [LineNumberTable(new byte[] {160, 194, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void runFrame() => SteamController.runFrame(this.pointer);

    [LineNumberTable(new byte[] {160, 198, 102, 176, 146, 102, 48, 198})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getConnectedControllers(SteamControllerHandle[] handlesOut)
    {
      if (handlesOut.Length < 16)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException("Array size must be at least STEAM_CONTROLLER_MAX_COUNT");
      }
      int connectedControllers = SteamController.getConnectedControllers(this.pointer, this.controllerHandles);
      for (int index = 0; index < connectedControllers; ++index)
        handlesOut[index] = new SteamControllerHandle(this.controllerHandles[index]);
      return connectedControllers;
    }

    [LineNumberTable(326)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool showBindingPanel(SteamControllerHandle controller) => SteamController.showBindingPanel(this.pointer, controller.handle);

    [LineNumberTable(330)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual SteamControllerActionSetHandle getActionSetHandle(
      string actionSetName)
    {
      return new SteamControllerActionSetHandle(SteamController.getActionSetHandle(this.pointer, actionSetName));
    }

    [LineNumberTable(new byte[] {160, 220, 119})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void activateActionSet(
      SteamControllerHandle controller,
      SteamControllerActionSetHandle actionSet)
    {
      SteamController.activateActionSet(this.pointer, controller.handle, actionSet.handle);
    }

    [LineNumberTable(338)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual SteamControllerActionSetHandle getCurrentActionSet(
      SteamControllerHandle controller)
    {
      return new SteamControllerActionSetHandle(SteamController.getCurrentActionSet(this.pointer, controller.handle));
    }

    [LineNumberTable(342)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual SteamControllerDigitalActionHandle getDigitalActionHandle(
      string actionName)
    {
      return new SteamControllerDigitalActionHandle(SteamController.getDigitalActionHandle(this.pointer, actionName));
    }

    [LineNumberTable(new byte[] {160, 235, 120})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void getDigitalActionData(
      SteamControllerHandle controller,
      SteamControllerDigitalActionHandle digitalAction,
      SteamControllerDigitalActionData digitalActionData)
    {
      SteamController.getDigitalActionData(this.pointer, controller.handle, digitalAction.handle, digitalActionData);
    }

    [LineNumberTable(new byte[] {160, 243, 102, 176, 191, 5, 102, 49, 198})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getDigitalActionOrigins(
      SteamControllerHandle controller,
      SteamControllerActionSetHandle actionSet,
      SteamControllerDigitalActionHandle digitalAction,
      SteamController.ActionOrigin[] originsOut)
    {
      if (originsOut.Length < 8)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException("Array size must be at least STEAM_CONTROLLER_MAX_ORIGINS");
      }
      int digitalActionOrigins = SteamController.getDigitalActionOrigins(this.pointer, controller.handle, actionSet.handle, digitalAction.handle, this.actionOrigins);
      for (int index = 0; index < digitalActionOrigins; ++index)
        originsOut[index] = SteamController.ActionOrigin.byOrdinal(this.actionOrigins[index]);
      return digitalActionOrigins;
    }

    [LineNumberTable(372)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual SteamControllerAnalogActionHandle getAnalogActionHandle(
      string actionName)
    {
      return new SteamControllerAnalogActionHandle(SteamController.getAnalogActionHandle(this.pointer, actionName));
    }

    [LineNumberTable(new byte[] {161, 9, 120})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void getAnalogActionData(
      SteamControllerHandle controller,
      SteamControllerAnalogActionHandle analogAction,
      SteamControllerAnalogActionData analoglActionData)
    {
      SteamController.getAnalogActionData(this.pointer, controller.handle, analogAction.handle, analoglActionData);
    }

    [LineNumberTable(new byte[] {161, 17, 102, 176, 191, 5, 102, 49, 198})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getAnalogActionOrigins(
      SteamControllerHandle controller,
      SteamControllerActionSetHandle actionSet,
      SteamControllerAnalogActionHandle analogAction,
      SteamController.ActionOrigin[] originsOut)
    {
      if (originsOut.Length < 8)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException("Array size must be at least STEAM_CONTROLLER_MAX_ORIGINS");
      }
      int analogActionOrigins = SteamController.getAnalogActionOrigins(this.pointer, controller.handle, actionSet.handle, analogAction.handle, this.actionOrigins);
      for (int index = 0; index < analogActionOrigins; ++index)
        originsOut[index] = SteamController.ActionOrigin.byOrdinal(this.actionOrigins[index]);
      return analogActionOrigins;
    }

    [LineNumberTable(new byte[] {161, 34, 119})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void stopAnalogActionMomentum(
      SteamControllerHandle controller,
      SteamControllerAnalogActionHandle analogAction)
    {
      SteamController.stopAnalogActionMomentum(this.pointer, controller.handle, analogAction.handle);
    }

    [LineNumberTable(new byte[] {161, 38, 120})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void triggerHapticPulse(
      SteamControllerHandle controller,
      SteamController.Pad targetPad,
      int durationMicroSec)
    {
      SteamController.triggerHapticPulse(this.pointer, controller.handle, targetPad.ordinal(), durationMicroSec);
    }

    [LineNumberTable(new byte[] {161, 44, 158})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void triggerRepeatedHapticPulse(
      SteamControllerHandle controller,
      SteamController.Pad targetPad,
      int durationMicroSec,
      int offMicroSec,
      int repeat,
      int flags)
    {
      SteamController.triggerRepeatedHapticPulse(this.pointer, controller.handle, targetPad.ordinal(), durationMicroSec, offMicroSec, repeat, flags);
    }

    [LineNumberTable(new byte[] {159, 38, 164, 115})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void triggerVibration(
      SteamControllerHandle controller,
      short leftSpeed,
      short rightSpeed)
    {
      int num1 = (int) leftSpeed;
      int num2 = (int) rightSpeed;
      SteamController.triggerVibration(this.pointer, controller.handle, (short) num1, (short) num2);
    }

    [LineNumberTable(new byte[] {161, 53, 127, 8, 37, 133})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setLEDColor(
      SteamControllerHandle controller,
      int colorR,
      int colorG,
      int colorB,
      SteamController.LEDFlag flags)
    {
      SteamController.setLEDColor(this.pointer, controller.handle, (byte) (colorR & (int) byte.MaxValue), (byte) (colorG & (int) byte.MaxValue), (byte) (colorB & (int) byte.MaxValue), flags.ordinal());
    }

    [LineNumberTable(428)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getGamepadIndexForController(SteamControllerHandle controller) => SteamController.getGamepadIndexForController(this.pointer, controller.handle);

    [LineNumberTable(432)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual SteamControllerHandle getControllerForGamepadIndex(int index) => new SteamControllerHandle(SteamController.getControllerForGamepadIndex(this.pointer, index));

    [LineNumberTable(new byte[] {161, 66, 119})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void getMotionData(
      SteamControllerHandle controller,
      SteamControllerMotionData motionData)
    {
      SteamController.getMotionData(this.pointer, controller.handle, motionData.data);
    }

    [LineNumberTable(443)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool showDigitalActionOrigins(
      SteamControllerHandle controller,
      SteamControllerDigitalActionHandle digitalActionHandle,
      float scale,
      float xPosition,
      float yPosition)
    {
      return SteamController.showDigitalActionOrigins(this.pointer, controller.handle, digitalActionHandle.handle, scale, xPosition, yPosition);
    }

    [LineNumberTable(451)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool showAnalogActionOrigins(
      SteamControllerHandle controller,
      SteamControllerAnalogActionHandle analogActionHandle,
      float scale,
      float xPosition,
      float yPosition)
    {
      return SteamController.showAnalogActionOrigins(this.pointer, controller.handle, analogActionHandle.handle, scale, xPosition, yPosition);
    }

    [LineNumberTable(456)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string getStringForActionOrigin(SteamController.ActionOrigin origin) => SteamController.getStringForActionOrigin(this.pointer, origin.ordinal());

    [LineNumberTable(460)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string getGlyphForActionOrigin(SteamController.ActionOrigin origin) => SteamController.getGlyphForActionOrigin(this.pointer, origin.ordinal());

    [LineNumberTable(464)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual SteamController.InputType getInputTypeForHandle(
      SteamControllerHandle controller)
    {
      return SteamController.InputType.byOrdinal(SteamController.getInputTypeForHandle(this.pointer, controller.handle));
    }

    [Modifiers]
    [LineNumberTable(3)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void dispose() => base.dispose();

    new static CallerID __\u003CGetCallerID\u003E()
    {
      if (SteamController.__\u003CcallerID\u003E == null)
        SteamController.__\u003CcallerID\u003E = (CallerID) new SteamController.__\u003CCallerID\u003E();
      return SteamController.__\u003CcallerID\u003E;
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
    [Signature("Ljava/lang/Enum<Lcom/codedisaster/steamworks/SteamController$ActionOrigin;>;")]
    [Modifiers]
    [Serializable]
    public sealed class ActionOrigin : Enum
    {
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003ENone;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003EA;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003EB;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003EX;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003EY;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003ELeftBumper;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003ERightBumper;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003ELeftGrip;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003ERightGrip;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003EStart;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003EBack;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003ELeftPad_Touch;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003ELeftPad_Swipe;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003ELeftPad_Click;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003ELeftPad_DPadNorth;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003ELeftPad_DPadSouth;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003ELeftPad_DPadWest;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003ELeftPad_DPadEast;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003ERightPad_Touch;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003ERightPad_Swipe;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003ERightPad_Click;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003ERightPad_DPadNorth;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003ERightPad_DPadSouth;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003ERightPad_DPadWest;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003ERightPad_DPadEast;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003ELeftTrigger_Pull;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003ELeftTrigger_Click;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003ERightTrigger_Pull;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003ERightTrigger_Click;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003ELeftStick_Move;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003ELeftStick_Click;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003ELeftStick_DPadNorth;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003ELeftStick_DPadSouth;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003ELeftStick_DPadWest;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003ELeftStick_DPadEast;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003EGyro_Move;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003EGyro_Pitch;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003EGyro_Yaw;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003EGyro_Roll;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003EPS4_X;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003EPS4_Circle;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003EPS4_Triangle;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003EPS4_Square;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003EPS4_LeftBumper;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003EPS4_RightBumper;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003EPS4_Options;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003EPS4_Share;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003EPS4_LeftPad_Touch;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003EPS4_LeftPad_Swipe;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003EPS4_LeftPad_Click;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003EPS4_LeftPad_DPadNorth;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003EPS4_LeftPad_DPadSouth;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003EPS4_LeftPad_DPadWest;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003EPS4_LeftPad_DPadEast;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003EPS4_RightPad_Touch;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003EPS4_RightPad_Swipe;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003EPS4_RightPad_Click;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003EPS4_RightPad_DPadNorth;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003EPS4_RightPad_DPadSouth;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003EPS4_RightPad_DPadWest;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003EPS4_RightPad_DPadEast;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003EPS4_CenterPad_Touch;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003EPS4_CenterPad_Swipe;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003EPS4_CenterPad_Click;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003EPS4_CenterPad_DPadNorth;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003EPS4_CenterPad_DPadSouth;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003EPS4_CenterPad_DPadWest;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003EPS4_CenterPad_DPadEast;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003EPS4_LeftTrigger_Pull;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003EPS4_LeftTrigger_Click;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003EPS4_RightTrigger_Pull;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003EPS4_RightTrigger_Click;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003EPS4_LeftStick_Move;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003EPS4_LeftStick_Click;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003EPS4_LeftStick_DPadNorth;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003EPS4_LeftStick_DPadSouth;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003EPS4_LeftStick_DPadWest;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003EPS4_LeftStick_DPadEast;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003EPS4_RightStick_Move;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003EPS4_RightStick_Click;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003EPS4_RightStick_DPadNorth;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003EPS4_RightStick_DPadSouth;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003EPS4_RightStick_DPadWest;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003EPS4_RightStick_DPadEast;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003EPS4_DPad_North;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003EPS4_DPad_South;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003EPS4_DPad_West;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003EPS4_DPad_East;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003EPS4_Gyro_Move;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003EPS4_Gyro_Pitch;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003EPS4_Gyro_Yaw;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003EPS4_Gyro_Roll;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003EXBoxOne_A;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003EXBoxOne_B;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003EXBoxOne_X;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003EXBoxOne_Y;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003EXBoxOne_LeftBumper;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003EXBoxOne_RightBumper;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003EXBoxOne_Menu;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003EXBoxOne_View;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003EXBoxOne_LeftTrigger_Pull;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003EXBoxOne_LeftTrigger_Click;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003EXBoxOne_RightTrigger_Pull;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003EXBoxOne_RightTrigger_Click;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003EXBoxOne_LeftStick_Move;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003EXBoxOne_LeftStick_Click;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003EXBoxOne_LeftStick_DPadNorth;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003EXBoxOne_LeftStick_DPadSouth;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003EXBoxOne_LeftStick_DPadWest;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003EXBoxOne_LeftStick_DPadEast;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003EXBoxOne_RightStick_Move;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003EXBoxOne_RightStick_Click;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003EXBoxOne_RightStick_DPadNorth;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003EXBoxOne_RightStick_DPadSouth;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003EXBoxOne_RightStick_DPadWest;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003EXBoxOne_RightStick_DPadEast;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003EXBoxOne_DPad_North;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003EXBoxOne_DPad_South;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003EXBoxOne_DPad_West;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003EXBoxOne_DPad_East;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003EXBox360_A;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003EXBox360_B;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003EXBox360_X;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003EXBox360_Y;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003EXBox360_LeftBumper;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003EXBox360_RightBumper;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003EXBox360_Start;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003EXBox360_Back;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003EXBox360_LeftTrigger_Pull;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003EXBox360_LeftTrigger_Click;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003EXBox360_RightTrigger_Pull;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003EXBox360_RightTrigger_Click;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003EXBox360_LeftStick_Move;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003EXBox360_LeftStick_Click;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003EXBox360_LeftStick_DPadNorth;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003EXBox360_LeftStick_DPadSouth;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003EXBox360_LeftStick_DPadWest;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003EXBox360_LeftStick_DPadEast;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003EXBox360_RightStick_Move;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003EXBox360_RightStick_Click;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003EXBox360_RightStick_DPadNorth;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003EXBox360_RightStick_DPadSouth;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003EXBox360_RightStick_DPadWest;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003EXBox360_RightStick_DPadEast;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003EXBox360_DPad_North;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003EXBox360_DPad_South;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003EXBox360_DPad_West;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003EXBox360_DPad_East;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003ESteamV2_A;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003ESteamV2_B;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003ESteamV2_X;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003ESteamV2_Y;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003ESteamV2_LeftBumper;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003ESteamV2_RightBumper;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003ESteamV2_LeftGrip;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003ESteamV2_RightGrip;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003ESteamV2_LeftGrip_Upper;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003ESteamV2_RightGrip_Upper;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003ESteamV2_LeftBumper_Pressure;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003ESteamV2_RightBumper_Pressure;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003ESteamV2_LeftGrip_Pressure;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003ESteamV2_RightGrip_Pressure;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003ESteamV2_LeftGrip_Upper_Pressure;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003ESteamV2_RightGrip_Upper_Pressure;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003ESteamV2_Start;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003ESteamV2_Back;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003ESteamV2_LeftPad_Touch;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003ESteamV2_LeftPad_Swipe;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003ESteamV2_LeftPad_Click;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003ESteamV2_LeftPad_Pressure;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003ESteamV2_LeftPad_DPadNorth;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003ESteamV2_LeftPad_DPadSouth;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003ESteamV2_LeftPad_DPadWest;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003ESteamV2_LeftPad_DPadEast;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003ESteamV2_RightPad_Touch;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003ESteamV2_RightPad_Swipe;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003ESteamV2_RightPad_Click;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003ESteamV2_RightPad_Pressure;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003ESteamV2_RightPad_DPadNorth;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003ESteamV2_RightPad_DPadSouth;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003ESteamV2_RightPad_DPadWest;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003ESteamV2_RightPad_DPadEast;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003ESteamV2_LeftTrigger_Pull;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003ESteamV2_LeftTrigger_Click;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003ESteamV2_RightTrigger_Pull;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003ESteamV2_RightTrigger_Click;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003ESteamV2_LeftStick_Move;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003ESteamV2_LeftStick_Click;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003ESteamV2_LeftStick_DPadNorth;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003ESteamV2_LeftStick_DPadSouth;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003ESteamV2_LeftStick_DPadWest;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003ESteamV2_LeftStick_DPadEast;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003ESteamV2_Gyro_Move;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003ESteamV2_Gyro_Pitch;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003ESteamV2_Gyro_Yaw;
      [Modifiers]
      internal static SteamController.ActionOrigin __\u003C\u003ESteamV2_Gyro_Roll;
      [Modifiers]
      private static SteamController.ActionOrigin[] values;
      [Modifiers]
      private static SteamController.ActionOrigin[] \u0024VALUES;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [Signature("()V")]
      [LineNumberTable(53)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private ActionOrigin([In] string obj0, [In] int obj1)
        : base(obj0, obj1)
      {
        GC.KeepAlive((object) this);
      }

      [LineNumberTable(53)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static SteamController.ActionOrigin[] values() => (SteamController.ActionOrigin[]) SteamController.ActionOrigin.\u0024VALUES.Clone();

      [LineNumberTable(53)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static SteamController.ActionOrigin valueOf(string name) => (SteamController.ActionOrigin) Enum.valueOf((Class) ClassLiteral<SteamController.ActionOrigin>.Value, name);

      [LineNumberTable(258)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal static SteamController.ActionOrigin byOrdinal([In] int obj0) => SteamController.ActionOrigin.values[obj0];

      [LineNumberTable(new byte[] {159, 129, 141, 112, 112, 112, 112, 112, 112, 112, 112, 112, 113, 113, 113, 113, 113, 113, 113, 113, 113, 113, 113, 113, 113, 113, 113, 113, 113, 113, 113, 113, 113, 113, 113, 113, 113, 113, 113, 113, 113, 145, 113, 113, 113, 113, 113, 113, 113, 113, 113, 113, 113, 113, 113, 113, 113, 113, 113, 113, 113, 113, 113, 113, 113, 113, 113, 113, 113, 113, 113, 113, 113, 113, 113, 113, 113, 113, 113, 113, 113, 113, 113, 113, 113, 113, 113, 113, 113, 113, 113, 113, 113, 113, 145, 113, 113, 113, 113, 113, 113, 113, 113, 113, 113, 113, 113, 113, 113, 113, 113, 113, 113, 113, 113, 113, 113, 113, 113, 113, 113, 113, 145, 113, 113, 113, 113, 113, 113, 113, 113, 116, 116, 116, 116, 116, 116, 116, 116, 116, 116, 116, 116, 116, 116, 116, 116, 116, 116, 116, 148, 116, 116, 116, 116, 116, 116, 116, 116, 116, 116, 116, 116, 116, 116, 116, 116, 116, 116, 116, 116, 116, 116, 116, 116, 116, 116, 116, 116, 116, 116, 116, 116, 116, 116, 116, 116, 116, 116, 116, 116, 116, 116, 116, 116, 116, 116, 116, 244, 159, 56, 255, 167, 87, 160, 202})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static ActionOrigin()
      {
        if (ByteCodeHelper.isAlreadyInited("com.codedisaster.steamworks.SteamController$ActionOrigin"))
          return;
        SteamController.ActionOrigin.__\u003C\u003ENone = new SteamController.ActionOrigin(nameof (None), 0);
        SteamController.ActionOrigin.__\u003C\u003EA = new SteamController.ActionOrigin(nameof (A), 1);
        SteamController.ActionOrigin.__\u003C\u003EB = new SteamController.ActionOrigin(nameof (B), 2);
        SteamController.ActionOrigin.__\u003C\u003EX = new SteamController.ActionOrigin(nameof (X), 3);
        SteamController.ActionOrigin.__\u003C\u003EY = new SteamController.ActionOrigin(nameof (Y), 4);
        SteamController.ActionOrigin.__\u003C\u003ELeftBumper = new SteamController.ActionOrigin(nameof (LeftBumper), 5);
        SteamController.ActionOrigin.__\u003C\u003ERightBumper = new SteamController.ActionOrigin(nameof (RightBumper), 6);
        SteamController.ActionOrigin.__\u003C\u003ELeftGrip = new SteamController.ActionOrigin(nameof (LeftGrip), 7);
        SteamController.ActionOrigin.__\u003C\u003ERightGrip = new SteamController.ActionOrigin(nameof (RightGrip), 8);
        SteamController.ActionOrigin.__\u003C\u003EStart = new SteamController.ActionOrigin(nameof (Start), 9);
        SteamController.ActionOrigin.__\u003C\u003EBack = new SteamController.ActionOrigin(nameof (Back), 10);
        SteamController.ActionOrigin.__\u003C\u003ELeftPad_Touch = new SteamController.ActionOrigin(nameof (LeftPad_Touch), 11);
        SteamController.ActionOrigin.__\u003C\u003ELeftPad_Swipe = new SteamController.ActionOrigin(nameof (LeftPad_Swipe), 12);
        SteamController.ActionOrigin.__\u003C\u003ELeftPad_Click = new SteamController.ActionOrigin(nameof (LeftPad_Click), 13);
        SteamController.ActionOrigin.__\u003C\u003ELeftPad_DPadNorth = new SteamController.ActionOrigin(nameof (LeftPad_DPadNorth), 14);
        SteamController.ActionOrigin.__\u003C\u003ELeftPad_DPadSouth = new SteamController.ActionOrigin(nameof (LeftPad_DPadSouth), 15);
        SteamController.ActionOrigin.__\u003C\u003ELeftPad_DPadWest = new SteamController.ActionOrigin(nameof (LeftPad_DPadWest), 16);
        SteamController.ActionOrigin.__\u003C\u003ELeftPad_DPadEast = new SteamController.ActionOrigin(nameof (LeftPad_DPadEast), 17);
        SteamController.ActionOrigin.__\u003C\u003ERightPad_Touch = new SteamController.ActionOrigin(nameof (RightPad_Touch), 18);
        SteamController.ActionOrigin.__\u003C\u003ERightPad_Swipe = new SteamController.ActionOrigin(nameof (RightPad_Swipe), 19);
        SteamController.ActionOrigin.__\u003C\u003ERightPad_Click = new SteamController.ActionOrigin(nameof (RightPad_Click), 20);
        SteamController.ActionOrigin.__\u003C\u003ERightPad_DPadNorth = new SteamController.ActionOrigin(nameof (RightPad_DPadNorth), 21);
        SteamController.ActionOrigin.__\u003C\u003ERightPad_DPadSouth = new SteamController.ActionOrigin(nameof (RightPad_DPadSouth), 22);
        SteamController.ActionOrigin.__\u003C\u003ERightPad_DPadWest = new SteamController.ActionOrigin(nameof (RightPad_DPadWest), 23);
        SteamController.ActionOrigin.__\u003C\u003ERightPad_DPadEast = new SteamController.ActionOrigin(nameof (RightPad_DPadEast), 24);
        SteamController.ActionOrigin.__\u003C\u003ELeftTrigger_Pull = new SteamController.ActionOrigin(nameof (LeftTrigger_Pull), 25);
        SteamController.ActionOrigin.__\u003C\u003ELeftTrigger_Click = new SteamController.ActionOrigin(nameof (LeftTrigger_Click), 26);
        SteamController.ActionOrigin.__\u003C\u003ERightTrigger_Pull = new SteamController.ActionOrigin(nameof (RightTrigger_Pull), 27);
        SteamController.ActionOrigin.__\u003C\u003ERightTrigger_Click = new SteamController.ActionOrigin(nameof (RightTrigger_Click), 28);
        SteamController.ActionOrigin.__\u003C\u003ELeftStick_Move = new SteamController.ActionOrigin(nameof (LeftStick_Move), 29);
        SteamController.ActionOrigin.__\u003C\u003ELeftStick_Click = new SteamController.ActionOrigin(nameof (LeftStick_Click), 30);
        SteamController.ActionOrigin.__\u003C\u003ELeftStick_DPadNorth = new SteamController.ActionOrigin(nameof (LeftStick_DPadNorth), 31);
        SteamController.ActionOrigin.__\u003C\u003ELeftStick_DPadSouth = new SteamController.ActionOrigin(nameof (LeftStick_DPadSouth), 32);
        SteamController.ActionOrigin.__\u003C\u003ELeftStick_DPadWest = new SteamController.ActionOrigin(nameof (LeftStick_DPadWest), 33);
        SteamController.ActionOrigin.__\u003C\u003ELeftStick_DPadEast = new SteamController.ActionOrigin(nameof (LeftStick_DPadEast), 34);
        SteamController.ActionOrigin.__\u003C\u003EGyro_Move = new SteamController.ActionOrigin(nameof (Gyro_Move), 35);
        SteamController.ActionOrigin.__\u003C\u003EGyro_Pitch = new SteamController.ActionOrigin(nameof (Gyro_Pitch), 36);
        SteamController.ActionOrigin.__\u003C\u003EGyro_Yaw = new SteamController.ActionOrigin(nameof (Gyro_Yaw), 37);
        SteamController.ActionOrigin.__\u003C\u003EGyro_Roll = new SteamController.ActionOrigin(nameof (Gyro_Roll), 38);
        SteamController.ActionOrigin.__\u003C\u003EPS4_X = new SteamController.ActionOrigin(nameof (PS4_X), 39);
        SteamController.ActionOrigin.__\u003C\u003EPS4_Circle = new SteamController.ActionOrigin(nameof (PS4_Circle), 40);
        SteamController.ActionOrigin.__\u003C\u003EPS4_Triangle = new SteamController.ActionOrigin(nameof (PS4_Triangle), 41);
        SteamController.ActionOrigin.__\u003C\u003EPS4_Square = new SteamController.ActionOrigin(nameof (PS4_Square), 42);
        SteamController.ActionOrigin.__\u003C\u003EPS4_LeftBumper = new SteamController.ActionOrigin(nameof (PS4_LeftBumper), 43);
        SteamController.ActionOrigin.__\u003C\u003EPS4_RightBumper = new SteamController.ActionOrigin(nameof (PS4_RightBumper), 44);
        SteamController.ActionOrigin.__\u003C\u003EPS4_Options = new SteamController.ActionOrigin(nameof (PS4_Options), 45);
        SteamController.ActionOrigin.__\u003C\u003EPS4_Share = new SteamController.ActionOrigin(nameof (PS4_Share), 46);
        SteamController.ActionOrigin.__\u003C\u003EPS4_LeftPad_Touch = new SteamController.ActionOrigin(nameof (PS4_LeftPad_Touch), 47);
        SteamController.ActionOrigin.__\u003C\u003EPS4_LeftPad_Swipe = new SteamController.ActionOrigin(nameof (PS4_LeftPad_Swipe), 48);
        SteamController.ActionOrigin.__\u003C\u003EPS4_LeftPad_Click = new SteamController.ActionOrigin(nameof (PS4_LeftPad_Click), 49);
        SteamController.ActionOrigin.__\u003C\u003EPS4_LeftPad_DPadNorth = new SteamController.ActionOrigin(nameof (PS4_LeftPad_DPadNorth), 50);
        SteamController.ActionOrigin.__\u003C\u003EPS4_LeftPad_DPadSouth = new SteamController.ActionOrigin(nameof (PS4_LeftPad_DPadSouth), 51);
        SteamController.ActionOrigin.__\u003C\u003EPS4_LeftPad_DPadWest = new SteamController.ActionOrigin(nameof (PS4_LeftPad_DPadWest), 52);
        SteamController.ActionOrigin.__\u003C\u003EPS4_LeftPad_DPadEast = new SteamController.ActionOrigin(nameof (PS4_LeftPad_DPadEast), 53);
        SteamController.ActionOrigin.__\u003C\u003EPS4_RightPad_Touch = new SteamController.ActionOrigin(nameof (PS4_RightPad_Touch), 54);
        SteamController.ActionOrigin.__\u003C\u003EPS4_RightPad_Swipe = new SteamController.ActionOrigin(nameof (PS4_RightPad_Swipe), 55);
        SteamController.ActionOrigin.__\u003C\u003EPS4_RightPad_Click = new SteamController.ActionOrigin(nameof (PS4_RightPad_Click), 56);
        SteamController.ActionOrigin.__\u003C\u003EPS4_RightPad_DPadNorth = new SteamController.ActionOrigin(nameof (PS4_RightPad_DPadNorth), 57);
        SteamController.ActionOrigin.__\u003C\u003EPS4_RightPad_DPadSouth = new SteamController.ActionOrigin(nameof (PS4_RightPad_DPadSouth), 58);
        SteamController.ActionOrigin.__\u003C\u003EPS4_RightPad_DPadWest = new SteamController.ActionOrigin(nameof (PS4_RightPad_DPadWest), 59);
        SteamController.ActionOrigin.__\u003C\u003EPS4_RightPad_DPadEast = new SteamController.ActionOrigin(nameof (PS4_RightPad_DPadEast), 60);
        SteamController.ActionOrigin.__\u003C\u003EPS4_CenterPad_Touch = new SteamController.ActionOrigin(nameof (PS4_CenterPad_Touch), 61);
        SteamController.ActionOrigin.__\u003C\u003EPS4_CenterPad_Swipe = new SteamController.ActionOrigin(nameof (PS4_CenterPad_Swipe), 62);
        SteamController.ActionOrigin.__\u003C\u003EPS4_CenterPad_Click = new SteamController.ActionOrigin(nameof (PS4_CenterPad_Click), 63);
        SteamController.ActionOrigin.__\u003C\u003EPS4_CenterPad_DPadNorth = new SteamController.ActionOrigin(nameof (PS4_CenterPad_DPadNorth), 64);
        SteamController.ActionOrigin.__\u003C\u003EPS4_CenterPad_DPadSouth = new SteamController.ActionOrigin(nameof (PS4_CenterPad_DPadSouth), 65);
        SteamController.ActionOrigin.__\u003C\u003EPS4_CenterPad_DPadWest = new SteamController.ActionOrigin(nameof (PS4_CenterPad_DPadWest), 66);
        SteamController.ActionOrigin.__\u003C\u003EPS4_CenterPad_DPadEast = new SteamController.ActionOrigin(nameof (PS4_CenterPad_DPadEast), 67);
        SteamController.ActionOrigin.__\u003C\u003EPS4_LeftTrigger_Pull = new SteamController.ActionOrigin(nameof (PS4_LeftTrigger_Pull), 68);
        SteamController.ActionOrigin.__\u003C\u003EPS4_LeftTrigger_Click = new SteamController.ActionOrigin(nameof (PS4_LeftTrigger_Click), 69);
        SteamController.ActionOrigin.__\u003C\u003EPS4_RightTrigger_Pull = new SteamController.ActionOrigin(nameof (PS4_RightTrigger_Pull), 70);
        SteamController.ActionOrigin.__\u003C\u003EPS4_RightTrigger_Click = new SteamController.ActionOrigin(nameof (PS4_RightTrigger_Click), 71);
        SteamController.ActionOrigin.__\u003C\u003EPS4_LeftStick_Move = new SteamController.ActionOrigin(nameof (PS4_LeftStick_Move), 72);
        SteamController.ActionOrigin.__\u003C\u003EPS4_LeftStick_Click = new SteamController.ActionOrigin(nameof (PS4_LeftStick_Click), 73);
        SteamController.ActionOrigin.__\u003C\u003EPS4_LeftStick_DPadNorth = new SteamController.ActionOrigin(nameof (PS4_LeftStick_DPadNorth), 74);
        SteamController.ActionOrigin.__\u003C\u003EPS4_LeftStick_DPadSouth = new SteamController.ActionOrigin(nameof (PS4_LeftStick_DPadSouth), 75);
        SteamController.ActionOrigin.__\u003C\u003EPS4_LeftStick_DPadWest = new SteamController.ActionOrigin(nameof (PS4_LeftStick_DPadWest), 76);
        SteamController.ActionOrigin.__\u003C\u003EPS4_LeftStick_DPadEast = new SteamController.ActionOrigin(nameof (PS4_LeftStick_DPadEast), 77);
        SteamController.ActionOrigin.__\u003C\u003EPS4_RightStick_Move = new SteamController.ActionOrigin(nameof (PS4_RightStick_Move), 78);
        SteamController.ActionOrigin.__\u003C\u003EPS4_RightStick_Click = new SteamController.ActionOrigin(nameof (PS4_RightStick_Click), 79);
        SteamController.ActionOrigin.__\u003C\u003EPS4_RightStick_DPadNorth = new SteamController.ActionOrigin(nameof (PS4_RightStick_DPadNorth), 80);
        SteamController.ActionOrigin.__\u003C\u003EPS4_RightStick_DPadSouth = new SteamController.ActionOrigin(nameof (PS4_RightStick_DPadSouth), 81);
        SteamController.ActionOrigin.__\u003C\u003EPS4_RightStick_DPadWest = new SteamController.ActionOrigin(nameof (PS4_RightStick_DPadWest), 82);
        SteamController.ActionOrigin.__\u003C\u003EPS4_RightStick_DPadEast = new SteamController.ActionOrigin(nameof (PS4_RightStick_DPadEast), 83);
        SteamController.ActionOrigin.__\u003C\u003EPS4_DPad_North = new SteamController.ActionOrigin(nameof (PS4_DPad_North), 84);
        SteamController.ActionOrigin.__\u003C\u003EPS4_DPad_South = new SteamController.ActionOrigin(nameof (PS4_DPad_South), 85);
        SteamController.ActionOrigin.__\u003C\u003EPS4_DPad_West = new SteamController.ActionOrigin(nameof (PS4_DPad_West), 86);
        SteamController.ActionOrigin.__\u003C\u003EPS4_DPad_East = new SteamController.ActionOrigin(nameof (PS4_DPad_East), 87);
        SteamController.ActionOrigin.__\u003C\u003EPS4_Gyro_Move = new SteamController.ActionOrigin(nameof (PS4_Gyro_Move), 88);
        SteamController.ActionOrigin.__\u003C\u003EPS4_Gyro_Pitch = new SteamController.ActionOrigin(nameof (PS4_Gyro_Pitch), 89);
        SteamController.ActionOrigin.__\u003C\u003EPS4_Gyro_Yaw = new SteamController.ActionOrigin(nameof (PS4_Gyro_Yaw), 90);
        SteamController.ActionOrigin.__\u003C\u003EPS4_Gyro_Roll = new SteamController.ActionOrigin(nameof (PS4_Gyro_Roll), 91);
        SteamController.ActionOrigin.__\u003C\u003EXBoxOne_A = new SteamController.ActionOrigin(nameof (XBoxOne_A), 92);
        SteamController.ActionOrigin.__\u003C\u003EXBoxOne_B = new SteamController.ActionOrigin(nameof (XBoxOne_B), 93);
        SteamController.ActionOrigin.__\u003C\u003EXBoxOne_X = new SteamController.ActionOrigin(nameof (XBoxOne_X), 94);
        SteamController.ActionOrigin.__\u003C\u003EXBoxOne_Y = new SteamController.ActionOrigin(nameof (XBoxOne_Y), 95);
        SteamController.ActionOrigin.__\u003C\u003EXBoxOne_LeftBumper = new SteamController.ActionOrigin(nameof (XBoxOne_LeftBumper), 96);
        SteamController.ActionOrigin.__\u003C\u003EXBoxOne_RightBumper = new SteamController.ActionOrigin(nameof (XBoxOne_RightBumper), 97);
        SteamController.ActionOrigin.__\u003C\u003EXBoxOne_Menu = new SteamController.ActionOrigin(nameof (XBoxOne_Menu), 98);
        SteamController.ActionOrigin.__\u003C\u003EXBoxOne_View = new SteamController.ActionOrigin(nameof (XBoxOne_View), 99);
        SteamController.ActionOrigin.__\u003C\u003EXBoxOne_LeftTrigger_Pull = new SteamController.ActionOrigin(nameof (XBoxOne_LeftTrigger_Pull), 100);
        SteamController.ActionOrigin.__\u003C\u003EXBoxOne_LeftTrigger_Click = new SteamController.ActionOrigin(nameof (XBoxOne_LeftTrigger_Click), 101);
        SteamController.ActionOrigin.__\u003C\u003EXBoxOne_RightTrigger_Pull = new SteamController.ActionOrigin(nameof (XBoxOne_RightTrigger_Pull), 102);
        SteamController.ActionOrigin.__\u003C\u003EXBoxOne_RightTrigger_Click = new SteamController.ActionOrigin(nameof (XBoxOne_RightTrigger_Click), 103);
        SteamController.ActionOrigin.__\u003C\u003EXBoxOne_LeftStick_Move = new SteamController.ActionOrigin(nameof (XBoxOne_LeftStick_Move), 104);
        SteamController.ActionOrigin.__\u003C\u003EXBoxOne_LeftStick_Click = new SteamController.ActionOrigin(nameof (XBoxOne_LeftStick_Click), 105);
        SteamController.ActionOrigin.__\u003C\u003EXBoxOne_LeftStick_DPadNorth = new SteamController.ActionOrigin(nameof (XBoxOne_LeftStick_DPadNorth), 106);
        SteamController.ActionOrigin.__\u003C\u003EXBoxOne_LeftStick_DPadSouth = new SteamController.ActionOrigin(nameof (XBoxOne_LeftStick_DPadSouth), 107);
        SteamController.ActionOrigin.__\u003C\u003EXBoxOne_LeftStick_DPadWest = new SteamController.ActionOrigin(nameof (XBoxOne_LeftStick_DPadWest), 108);
        SteamController.ActionOrigin.__\u003C\u003EXBoxOne_LeftStick_DPadEast = new SteamController.ActionOrigin(nameof (XBoxOne_LeftStick_DPadEast), 109);
        SteamController.ActionOrigin.__\u003C\u003EXBoxOne_RightStick_Move = new SteamController.ActionOrigin(nameof (XBoxOne_RightStick_Move), 110);
        SteamController.ActionOrigin.__\u003C\u003EXBoxOne_RightStick_Click = new SteamController.ActionOrigin(nameof (XBoxOne_RightStick_Click), 111);
        SteamController.ActionOrigin.__\u003C\u003EXBoxOne_RightStick_DPadNorth = new SteamController.ActionOrigin(nameof (XBoxOne_RightStick_DPadNorth), 112);
        SteamController.ActionOrigin.__\u003C\u003EXBoxOne_RightStick_DPadSouth = new SteamController.ActionOrigin(nameof (XBoxOne_RightStick_DPadSouth), 113);
        SteamController.ActionOrigin.__\u003C\u003EXBoxOne_RightStick_DPadWest = new SteamController.ActionOrigin(nameof (XBoxOne_RightStick_DPadWest), 114);
        SteamController.ActionOrigin.__\u003C\u003EXBoxOne_RightStick_DPadEast = new SteamController.ActionOrigin(nameof (XBoxOne_RightStick_DPadEast), 115);
        SteamController.ActionOrigin.__\u003C\u003EXBoxOne_DPad_North = new SteamController.ActionOrigin(nameof (XBoxOne_DPad_North), 116);
        SteamController.ActionOrigin.__\u003C\u003EXBoxOne_DPad_South = new SteamController.ActionOrigin(nameof (XBoxOne_DPad_South), 117);
        SteamController.ActionOrigin.__\u003C\u003EXBoxOne_DPad_West = new SteamController.ActionOrigin(nameof (XBoxOne_DPad_West), 118);
        SteamController.ActionOrigin.__\u003C\u003EXBoxOne_DPad_East = new SteamController.ActionOrigin(nameof (XBoxOne_DPad_East), 119);
        SteamController.ActionOrigin.__\u003C\u003EXBox360_A = new SteamController.ActionOrigin(nameof (XBox360_A), 120);
        SteamController.ActionOrigin.__\u003C\u003EXBox360_B = new SteamController.ActionOrigin(nameof (XBox360_B), 121);
        SteamController.ActionOrigin.__\u003C\u003EXBox360_X = new SteamController.ActionOrigin(nameof (XBox360_X), 122);
        SteamController.ActionOrigin.__\u003C\u003EXBox360_Y = new SteamController.ActionOrigin(nameof (XBox360_Y), 123);
        SteamController.ActionOrigin.__\u003C\u003EXBox360_LeftBumper = new SteamController.ActionOrigin(nameof (XBox360_LeftBumper), 124);
        SteamController.ActionOrigin.__\u003C\u003EXBox360_RightBumper = new SteamController.ActionOrigin(nameof (XBox360_RightBumper), 125);
        SteamController.ActionOrigin.__\u003C\u003EXBox360_Start = new SteamController.ActionOrigin(nameof (XBox360_Start), 126);
        SteamController.ActionOrigin.__\u003C\u003EXBox360_Back = new SteamController.ActionOrigin(nameof (XBox360_Back), (int) sbyte.MaxValue);
        SteamController.ActionOrigin.__\u003C\u003EXBox360_LeftTrigger_Pull = new SteamController.ActionOrigin(nameof (XBox360_LeftTrigger_Pull), 128);
        SteamController.ActionOrigin.__\u003C\u003EXBox360_LeftTrigger_Click = new SteamController.ActionOrigin(nameof (XBox360_LeftTrigger_Click), 129);
        SteamController.ActionOrigin.__\u003C\u003EXBox360_RightTrigger_Pull = new SteamController.ActionOrigin(nameof (XBox360_RightTrigger_Pull), 130);
        SteamController.ActionOrigin.__\u003C\u003EXBox360_RightTrigger_Click = new SteamController.ActionOrigin(nameof (XBox360_RightTrigger_Click), 131);
        SteamController.ActionOrigin.__\u003C\u003EXBox360_LeftStick_Move = new SteamController.ActionOrigin(nameof (XBox360_LeftStick_Move), 132);
        SteamController.ActionOrigin.__\u003C\u003EXBox360_LeftStick_Click = new SteamController.ActionOrigin(nameof (XBox360_LeftStick_Click), 133);
        SteamController.ActionOrigin.__\u003C\u003EXBox360_LeftStick_DPadNorth = new SteamController.ActionOrigin(nameof (XBox360_LeftStick_DPadNorth), 134);
        SteamController.ActionOrigin.__\u003C\u003EXBox360_LeftStick_DPadSouth = new SteamController.ActionOrigin(nameof (XBox360_LeftStick_DPadSouth), 135);
        SteamController.ActionOrigin.__\u003C\u003EXBox360_LeftStick_DPadWest = new SteamController.ActionOrigin(nameof (XBox360_LeftStick_DPadWest), 136);
        SteamController.ActionOrigin.__\u003C\u003EXBox360_LeftStick_DPadEast = new SteamController.ActionOrigin(nameof (XBox360_LeftStick_DPadEast), 137);
        SteamController.ActionOrigin.__\u003C\u003EXBox360_RightStick_Move = new SteamController.ActionOrigin(nameof (XBox360_RightStick_Move), 138);
        SteamController.ActionOrigin.__\u003C\u003EXBox360_RightStick_Click = new SteamController.ActionOrigin(nameof (XBox360_RightStick_Click), 139);
        SteamController.ActionOrigin.__\u003C\u003EXBox360_RightStick_DPadNorth = new SteamController.ActionOrigin(nameof (XBox360_RightStick_DPadNorth), 140);
        SteamController.ActionOrigin.__\u003C\u003EXBox360_RightStick_DPadSouth = new SteamController.ActionOrigin(nameof (XBox360_RightStick_DPadSouth), 141);
        SteamController.ActionOrigin.__\u003C\u003EXBox360_RightStick_DPadWest = new SteamController.ActionOrigin(nameof (XBox360_RightStick_DPadWest), 142);
        SteamController.ActionOrigin.__\u003C\u003EXBox360_RightStick_DPadEast = new SteamController.ActionOrigin(nameof (XBox360_RightStick_DPadEast), 143);
        SteamController.ActionOrigin.__\u003C\u003EXBox360_DPad_North = new SteamController.ActionOrigin(nameof (XBox360_DPad_North), 144);
        SteamController.ActionOrigin.__\u003C\u003EXBox360_DPad_South = new SteamController.ActionOrigin(nameof (XBox360_DPad_South), 145);
        SteamController.ActionOrigin.__\u003C\u003EXBox360_DPad_West = new SteamController.ActionOrigin(nameof (XBox360_DPad_West), 146);
        SteamController.ActionOrigin.__\u003C\u003EXBox360_DPad_East = new SteamController.ActionOrigin(nameof (XBox360_DPad_East), 147);
        SteamController.ActionOrigin.__\u003C\u003ESteamV2_A = new SteamController.ActionOrigin(nameof (SteamV2_A), 148);
        SteamController.ActionOrigin.__\u003C\u003ESteamV2_B = new SteamController.ActionOrigin(nameof (SteamV2_B), 149);
        SteamController.ActionOrigin.__\u003C\u003ESteamV2_X = new SteamController.ActionOrigin(nameof (SteamV2_X), 150);
        SteamController.ActionOrigin.__\u003C\u003ESteamV2_Y = new SteamController.ActionOrigin(nameof (SteamV2_Y), 151);
        SteamController.ActionOrigin.__\u003C\u003ESteamV2_LeftBumper = new SteamController.ActionOrigin(nameof (SteamV2_LeftBumper), 152);
        SteamController.ActionOrigin.__\u003C\u003ESteamV2_RightBumper = new SteamController.ActionOrigin(nameof (SteamV2_RightBumper), 153);
        SteamController.ActionOrigin.__\u003C\u003ESteamV2_LeftGrip = new SteamController.ActionOrigin(nameof (SteamV2_LeftGrip), 154);
        SteamController.ActionOrigin.__\u003C\u003ESteamV2_RightGrip = new SteamController.ActionOrigin(nameof (SteamV2_RightGrip), 155);
        SteamController.ActionOrigin.__\u003C\u003ESteamV2_LeftGrip_Upper = new SteamController.ActionOrigin(nameof (SteamV2_LeftGrip_Upper), 156);
        SteamController.ActionOrigin.__\u003C\u003ESteamV2_RightGrip_Upper = new SteamController.ActionOrigin(nameof (SteamV2_RightGrip_Upper), 157);
        SteamController.ActionOrigin.__\u003C\u003ESteamV2_LeftBumper_Pressure = new SteamController.ActionOrigin(nameof (SteamV2_LeftBumper_Pressure), 158);
        SteamController.ActionOrigin.__\u003C\u003ESteamV2_RightBumper_Pressure = new SteamController.ActionOrigin(nameof (SteamV2_RightBumper_Pressure), 159);
        SteamController.ActionOrigin.__\u003C\u003ESteamV2_LeftGrip_Pressure = new SteamController.ActionOrigin(nameof (SteamV2_LeftGrip_Pressure), 160);
        SteamController.ActionOrigin.__\u003C\u003ESteamV2_RightGrip_Pressure = new SteamController.ActionOrigin(nameof (SteamV2_RightGrip_Pressure), 161);
        SteamController.ActionOrigin.__\u003C\u003ESteamV2_LeftGrip_Upper_Pressure = new SteamController.ActionOrigin(nameof (SteamV2_LeftGrip_Upper_Pressure), 162);
        SteamController.ActionOrigin.__\u003C\u003ESteamV2_RightGrip_Upper_Pressure = new SteamController.ActionOrigin(nameof (SteamV2_RightGrip_Upper_Pressure), 163);
        SteamController.ActionOrigin.__\u003C\u003ESteamV2_Start = new SteamController.ActionOrigin(nameof (SteamV2_Start), 164);
        SteamController.ActionOrigin.__\u003C\u003ESteamV2_Back = new SteamController.ActionOrigin(nameof (SteamV2_Back), 165);
        SteamController.ActionOrigin.__\u003C\u003ESteamV2_LeftPad_Touch = new SteamController.ActionOrigin(nameof (SteamV2_LeftPad_Touch), 166);
        SteamController.ActionOrigin.__\u003C\u003ESteamV2_LeftPad_Swipe = new SteamController.ActionOrigin(nameof (SteamV2_LeftPad_Swipe), 167);
        SteamController.ActionOrigin.__\u003C\u003ESteamV2_LeftPad_Click = new SteamController.ActionOrigin(nameof (SteamV2_LeftPad_Click), 168);
        SteamController.ActionOrigin.__\u003C\u003ESteamV2_LeftPad_Pressure = new SteamController.ActionOrigin(nameof (SteamV2_LeftPad_Pressure), 169);
        SteamController.ActionOrigin.__\u003C\u003ESteamV2_LeftPad_DPadNorth = new SteamController.ActionOrigin(nameof (SteamV2_LeftPad_DPadNorth), 170);
        SteamController.ActionOrigin.__\u003C\u003ESteamV2_LeftPad_DPadSouth = new SteamController.ActionOrigin(nameof (SteamV2_LeftPad_DPadSouth), 171);
        SteamController.ActionOrigin.__\u003C\u003ESteamV2_LeftPad_DPadWest = new SteamController.ActionOrigin(nameof (SteamV2_LeftPad_DPadWest), 172);
        SteamController.ActionOrigin.__\u003C\u003ESteamV2_LeftPad_DPadEast = new SteamController.ActionOrigin(nameof (SteamV2_LeftPad_DPadEast), 173);
        SteamController.ActionOrigin.__\u003C\u003ESteamV2_RightPad_Touch = new SteamController.ActionOrigin(nameof (SteamV2_RightPad_Touch), 174);
        SteamController.ActionOrigin.__\u003C\u003ESteamV2_RightPad_Swipe = new SteamController.ActionOrigin(nameof (SteamV2_RightPad_Swipe), 175);
        SteamController.ActionOrigin.__\u003C\u003ESteamV2_RightPad_Click = new SteamController.ActionOrigin(nameof (SteamV2_RightPad_Click), 176);
        SteamController.ActionOrigin.__\u003C\u003ESteamV2_RightPad_Pressure = new SteamController.ActionOrigin(nameof (SteamV2_RightPad_Pressure), 177);
        SteamController.ActionOrigin.__\u003C\u003ESteamV2_RightPad_DPadNorth = new SteamController.ActionOrigin(nameof (SteamV2_RightPad_DPadNorth), 178);
        SteamController.ActionOrigin.__\u003C\u003ESteamV2_RightPad_DPadSouth = new SteamController.ActionOrigin(nameof (SteamV2_RightPad_DPadSouth), 179);
        SteamController.ActionOrigin.__\u003C\u003ESteamV2_RightPad_DPadWest = new SteamController.ActionOrigin(nameof (SteamV2_RightPad_DPadWest), 180);
        SteamController.ActionOrigin.__\u003C\u003ESteamV2_RightPad_DPadEast = new SteamController.ActionOrigin(nameof (SteamV2_RightPad_DPadEast), 181);
        SteamController.ActionOrigin.__\u003C\u003ESteamV2_LeftTrigger_Pull = new SteamController.ActionOrigin(nameof (SteamV2_LeftTrigger_Pull), 182);
        SteamController.ActionOrigin.__\u003C\u003ESteamV2_LeftTrigger_Click = new SteamController.ActionOrigin(nameof (SteamV2_LeftTrigger_Click), 183);
        SteamController.ActionOrigin.__\u003C\u003ESteamV2_RightTrigger_Pull = new SteamController.ActionOrigin(nameof (SteamV2_RightTrigger_Pull), 184);
        SteamController.ActionOrigin.__\u003C\u003ESteamV2_RightTrigger_Click = new SteamController.ActionOrigin(nameof (SteamV2_RightTrigger_Click), 185);
        SteamController.ActionOrigin.__\u003C\u003ESteamV2_LeftStick_Move = new SteamController.ActionOrigin(nameof (SteamV2_LeftStick_Move), 186);
        SteamController.ActionOrigin.__\u003C\u003ESteamV2_LeftStick_Click = new SteamController.ActionOrigin(nameof (SteamV2_LeftStick_Click), 187);
        SteamController.ActionOrigin.__\u003C\u003ESteamV2_LeftStick_DPadNorth = new SteamController.ActionOrigin(nameof (SteamV2_LeftStick_DPadNorth), 188);
        SteamController.ActionOrigin.__\u003C\u003ESteamV2_LeftStick_DPadSouth = new SteamController.ActionOrigin(nameof (SteamV2_LeftStick_DPadSouth), 189);
        SteamController.ActionOrigin.__\u003C\u003ESteamV2_LeftStick_DPadWest = new SteamController.ActionOrigin(nameof (SteamV2_LeftStick_DPadWest), 190);
        SteamController.ActionOrigin.__\u003C\u003ESteamV2_LeftStick_DPadEast = new SteamController.ActionOrigin(nameof (SteamV2_LeftStick_DPadEast), 191);
        SteamController.ActionOrigin.__\u003C\u003ESteamV2_Gyro_Move = new SteamController.ActionOrigin(nameof (SteamV2_Gyro_Move), 192);
        SteamController.ActionOrigin.__\u003C\u003ESteamV2_Gyro_Pitch = new SteamController.ActionOrigin(nameof (SteamV2_Gyro_Pitch), 193);
        SteamController.ActionOrigin.__\u003C\u003ESteamV2_Gyro_Yaw = new SteamController.ActionOrigin(nameof (SteamV2_Gyro_Yaw), 194);
        SteamController.ActionOrigin.__\u003C\u003ESteamV2_Gyro_Roll = new SteamController.ActionOrigin(nameof (SteamV2_Gyro_Roll), 195);
        SteamController.ActionOrigin.\u0024VALUES = new SteamController.ActionOrigin[196]
        {
          SteamController.ActionOrigin.__\u003C\u003ENone,
          SteamController.ActionOrigin.__\u003C\u003EA,
          SteamController.ActionOrigin.__\u003C\u003EB,
          SteamController.ActionOrigin.__\u003C\u003EX,
          SteamController.ActionOrigin.__\u003C\u003EY,
          SteamController.ActionOrigin.__\u003C\u003ELeftBumper,
          SteamController.ActionOrigin.__\u003C\u003ERightBumper,
          SteamController.ActionOrigin.__\u003C\u003ELeftGrip,
          SteamController.ActionOrigin.__\u003C\u003ERightGrip,
          SteamController.ActionOrigin.__\u003C\u003EStart,
          SteamController.ActionOrigin.__\u003C\u003EBack,
          SteamController.ActionOrigin.__\u003C\u003ELeftPad_Touch,
          SteamController.ActionOrigin.__\u003C\u003ELeftPad_Swipe,
          SteamController.ActionOrigin.__\u003C\u003ELeftPad_Click,
          SteamController.ActionOrigin.__\u003C\u003ELeftPad_DPadNorth,
          SteamController.ActionOrigin.__\u003C\u003ELeftPad_DPadSouth,
          SteamController.ActionOrigin.__\u003C\u003ELeftPad_DPadWest,
          SteamController.ActionOrigin.__\u003C\u003ELeftPad_DPadEast,
          SteamController.ActionOrigin.__\u003C\u003ERightPad_Touch,
          SteamController.ActionOrigin.__\u003C\u003ERightPad_Swipe,
          SteamController.ActionOrigin.__\u003C\u003ERightPad_Click,
          SteamController.ActionOrigin.__\u003C\u003ERightPad_DPadNorth,
          SteamController.ActionOrigin.__\u003C\u003ERightPad_DPadSouth,
          SteamController.ActionOrigin.__\u003C\u003ERightPad_DPadWest,
          SteamController.ActionOrigin.__\u003C\u003ERightPad_DPadEast,
          SteamController.ActionOrigin.__\u003C\u003ELeftTrigger_Pull,
          SteamController.ActionOrigin.__\u003C\u003ELeftTrigger_Click,
          SteamController.ActionOrigin.__\u003C\u003ERightTrigger_Pull,
          SteamController.ActionOrigin.__\u003C\u003ERightTrigger_Click,
          SteamController.ActionOrigin.__\u003C\u003ELeftStick_Move,
          SteamController.ActionOrigin.__\u003C\u003ELeftStick_Click,
          SteamController.ActionOrigin.__\u003C\u003ELeftStick_DPadNorth,
          SteamController.ActionOrigin.__\u003C\u003ELeftStick_DPadSouth,
          SteamController.ActionOrigin.__\u003C\u003ELeftStick_DPadWest,
          SteamController.ActionOrigin.__\u003C\u003ELeftStick_DPadEast,
          SteamController.ActionOrigin.__\u003C\u003EGyro_Move,
          SteamController.ActionOrigin.__\u003C\u003EGyro_Pitch,
          SteamController.ActionOrigin.__\u003C\u003EGyro_Yaw,
          SteamController.ActionOrigin.__\u003C\u003EGyro_Roll,
          SteamController.ActionOrigin.__\u003C\u003EPS4_X,
          SteamController.ActionOrigin.__\u003C\u003EPS4_Circle,
          SteamController.ActionOrigin.__\u003C\u003EPS4_Triangle,
          SteamController.ActionOrigin.__\u003C\u003EPS4_Square,
          SteamController.ActionOrigin.__\u003C\u003EPS4_LeftBumper,
          SteamController.ActionOrigin.__\u003C\u003EPS4_RightBumper,
          SteamController.ActionOrigin.__\u003C\u003EPS4_Options,
          SteamController.ActionOrigin.__\u003C\u003EPS4_Share,
          SteamController.ActionOrigin.__\u003C\u003EPS4_LeftPad_Touch,
          SteamController.ActionOrigin.__\u003C\u003EPS4_LeftPad_Swipe,
          SteamController.ActionOrigin.__\u003C\u003EPS4_LeftPad_Click,
          SteamController.ActionOrigin.__\u003C\u003EPS4_LeftPad_DPadNorth,
          SteamController.ActionOrigin.__\u003C\u003EPS4_LeftPad_DPadSouth,
          SteamController.ActionOrigin.__\u003C\u003EPS4_LeftPad_DPadWest,
          SteamController.ActionOrigin.__\u003C\u003EPS4_LeftPad_DPadEast,
          SteamController.ActionOrigin.__\u003C\u003EPS4_RightPad_Touch,
          SteamController.ActionOrigin.__\u003C\u003EPS4_RightPad_Swipe,
          SteamController.ActionOrigin.__\u003C\u003EPS4_RightPad_Click,
          SteamController.ActionOrigin.__\u003C\u003EPS4_RightPad_DPadNorth,
          SteamController.ActionOrigin.__\u003C\u003EPS4_RightPad_DPadSouth,
          SteamController.ActionOrigin.__\u003C\u003EPS4_RightPad_DPadWest,
          SteamController.ActionOrigin.__\u003C\u003EPS4_RightPad_DPadEast,
          SteamController.ActionOrigin.__\u003C\u003EPS4_CenterPad_Touch,
          SteamController.ActionOrigin.__\u003C\u003EPS4_CenterPad_Swipe,
          SteamController.ActionOrigin.__\u003C\u003EPS4_CenterPad_Click,
          SteamController.ActionOrigin.__\u003C\u003EPS4_CenterPad_DPadNorth,
          SteamController.ActionOrigin.__\u003C\u003EPS4_CenterPad_DPadSouth,
          SteamController.ActionOrigin.__\u003C\u003EPS4_CenterPad_DPadWest,
          SteamController.ActionOrigin.__\u003C\u003EPS4_CenterPad_DPadEast,
          SteamController.ActionOrigin.__\u003C\u003EPS4_LeftTrigger_Pull,
          SteamController.ActionOrigin.__\u003C\u003EPS4_LeftTrigger_Click,
          SteamController.ActionOrigin.__\u003C\u003EPS4_RightTrigger_Pull,
          SteamController.ActionOrigin.__\u003C\u003EPS4_RightTrigger_Click,
          SteamController.ActionOrigin.__\u003C\u003EPS4_LeftStick_Move,
          SteamController.ActionOrigin.__\u003C\u003EPS4_LeftStick_Click,
          SteamController.ActionOrigin.__\u003C\u003EPS4_LeftStick_DPadNorth,
          SteamController.ActionOrigin.__\u003C\u003EPS4_LeftStick_DPadSouth,
          SteamController.ActionOrigin.__\u003C\u003EPS4_LeftStick_DPadWest,
          SteamController.ActionOrigin.__\u003C\u003EPS4_LeftStick_DPadEast,
          SteamController.ActionOrigin.__\u003C\u003EPS4_RightStick_Move,
          SteamController.ActionOrigin.__\u003C\u003EPS4_RightStick_Click,
          SteamController.ActionOrigin.__\u003C\u003EPS4_RightStick_DPadNorth,
          SteamController.ActionOrigin.__\u003C\u003EPS4_RightStick_DPadSouth,
          SteamController.ActionOrigin.__\u003C\u003EPS4_RightStick_DPadWest,
          SteamController.ActionOrigin.__\u003C\u003EPS4_RightStick_DPadEast,
          SteamController.ActionOrigin.__\u003C\u003EPS4_DPad_North,
          SteamController.ActionOrigin.__\u003C\u003EPS4_DPad_South,
          SteamController.ActionOrigin.__\u003C\u003EPS4_DPad_West,
          SteamController.ActionOrigin.__\u003C\u003EPS4_DPad_East,
          SteamController.ActionOrigin.__\u003C\u003EPS4_Gyro_Move,
          SteamController.ActionOrigin.__\u003C\u003EPS4_Gyro_Pitch,
          SteamController.ActionOrigin.__\u003C\u003EPS4_Gyro_Yaw,
          SteamController.ActionOrigin.__\u003C\u003EPS4_Gyro_Roll,
          SteamController.ActionOrigin.__\u003C\u003EXBoxOne_A,
          SteamController.ActionOrigin.__\u003C\u003EXBoxOne_B,
          SteamController.ActionOrigin.__\u003C\u003EXBoxOne_X,
          SteamController.ActionOrigin.__\u003C\u003EXBoxOne_Y,
          SteamController.ActionOrigin.__\u003C\u003EXBoxOne_LeftBumper,
          SteamController.ActionOrigin.__\u003C\u003EXBoxOne_RightBumper,
          SteamController.ActionOrigin.__\u003C\u003EXBoxOne_Menu,
          SteamController.ActionOrigin.__\u003C\u003EXBoxOne_View,
          SteamController.ActionOrigin.__\u003C\u003EXBoxOne_LeftTrigger_Pull,
          SteamController.ActionOrigin.__\u003C\u003EXBoxOne_LeftTrigger_Click,
          SteamController.ActionOrigin.__\u003C\u003EXBoxOne_RightTrigger_Pull,
          SteamController.ActionOrigin.__\u003C\u003EXBoxOne_RightTrigger_Click,
          SteamController.ActionOrigin.__\u003C\u003EXBoxOne_LeftStick_Move,
          SteamController.ActionOrigin.__\u003C\u003EXBoxOne_LeftStick_Click,
          SteamController.ActionOrigin.__\u003C\u003EXBoxOne_LeftStick_DPadNorth,
          SteamController.ActionOrigin.__\u003C\u003EXBoxOne_LeftStick_DPadSouth,
          SteamController.ActionOrigin.__\u003C\u003EXBoxOne_LeftStick_DPadWest,
          SteamController.ActionOrigin.__\u003C\u003EXBoxOne_LeftStick_DPadEast,
          SteamController.ActionOrigin.__\u003C\u003EXBoxOne_RightStick_Move,
          SteamController.ActionOrigin.__\u003C\u003EXBoxOne_RightStick_Click,
          SteamController.ActionOrigin.__\u003C\u003EXBoxOne_RightStick_DPadNorth,
          SteamController.ActionOrigin.__\u003C\u003EXBoxOne_RightStick_DPadSouth,
          SteamController.ActionOrigin.__\u003C\u003EXBoxOne_RightStick_DPadWest,
          SteamController.ActionOrigin.__\u003C\u003EXBoxOne_RightStick_DPadEast,
          SteamController.ActionOrigin.__\u003C\u003EXBoxOne_DPad_North,
          SteamController.ActionOrigin.__\u003C\u003EXBoxOne_DPad_South,
          SteamController.ActionOrigin.__\u003C\u003EXBoxOne_DPad_West,
          SteamController.ActionOrigin.__\u003C\u003EXBoxOne_DPad_East,
          SteamController.ActionOrigin.__\u003C\u003EXBox360_A,
          SteamController.ActionOrigin.__\u003C\u003EXBox360_B,
          SteamController.ActionOrigin.__\u003C\u003EXBox360_X,
          SteamController.ActionOrigin.__\u003C\u003EXBox360_Y,
          SteamController.ActionOrigin.__\u003C\u003EXBox360_LeftBumper,
          SteamController.ActionOrigin.__\u003C\u003EXBox360_RightBumper,
          SteamController.ActionOrigin.__\u003C\u003EXBox360_Start,
          SteamController.ActionOrigin.__\u003C\u003EXBox360_Back,
          SteamController.ActionOrigin.__\u003C\u003EXBox360_LeftTrigger_Pull,
          SteamController.ActionOrigin.__\u003C\u003EXBox360_LeftTrigger_Click,
          SteamController.ActionOrigin.__\u003C\u003EXBox360_RightTrigger_Pull,
          SteamController.ActionOrigin.__\u003C\u003EXBox360_RightTrigger_Click,
          SteamController.ActionOrigin.__\u003C\u003EXBox360_LeftStick_Move,
          SteamController.ActionOrigin.__\u003C\u003EXBox360_LeftStick_Click,
          SteamController.ActionOrigin.__\u003C\u003EXBox360_LeftStick_DPadNorth,
          SteamController.ActionOrigin.__\u003C\u003EXBox360_LeftStick_DPadSouth,
          SteamController.ActionOrigin.__\u003C\u003EXBox360_LeftStick_DPadWest,
          SteamController.ActionOrigin.__\u003C\u003EXBox360_LeftStick_DPadEast,
          SteamController.ActionOrigin.__\u003C\u003EXBox360_RightStick_Move,
          SteamController.ActionOrigin.__\u003C\u003EXBox360_RightStick_Click,
          SteamController.ActionOrigin.__\u003C\u003EXBox360_RightStick_DPadNorth,
          SteamController.ActionOrigin.__\u003C\u003EXBox360_RightStick_DPadSouth,
          SteamController.ActionOrigin.__\u003C\u003EXBox360_RightStick_DPadWest,
          SteamController.ActionOrigin.__\u003C\u003EXBox360_RightStick_DPadEast,
          SteamController.ActionOrigin.__\u003C\u003EXBox360_DPad_North,
          SteamController.ActionOrigin.__\u003C\u003EXBox360_DPad_South,
          SteamController.ActionOrigin.__\u003C\u003EXBox360_DPad_West,
          SteamController.ActionOrigin.__\u003C\u003EXBox360_DPad_East,
          SteamController.ActionOrigin.__\u003C\u003ESteamV2_A,
          SteamController.ActionOrigin.__\u003C\u003ESteamV2_B,
          SteamController.ActionOrigin.__\u003C\u003ESteamV2_X,
          SteamController.ActionOrigin.__\u003C\u003ESteamV2_Y,
          SteamController.ActionOrigin.__\u003C\u003ESteamV2_LeftBumper,
          SteamController.ActionOrigin.__\u003C\u003ESteamV2_RightBumper,
          SteamController.ActionOrigin.__\u003C\u003ESteamV2_LeftGrip,
          SteamController.ActionOrigin.__\u003C\u003ESteamV2_RightGrip,
          SteamController.ActionOrigin.__\u003C\u003ESteamV2_LeftGrip_Upper,
          SteamController.ActionOrigin.__\u003C\u003ESteamV2_RightGrip_Upper,
          SteamController.ActionOrigin.__\u003C\u003ESteamV2_LeftBumper_Pressure,
          SteamController.ActionOrigin.__\u003C\u003ESteamV2_RightBumper_Pressure,
          SteamController.ActionOrigin.__\u003C\u003ESteamV2_LeftGrip_Pressure,
          SteamController.ActionOrigin.__\u003C\u003ESteamV2_RightGrip_Pressure,
          SteamController.ActionOrigin.__\u003C\u003ESteamV2_LeftGrip_Upper_Pressure,
          SteamController.ActionOrigin.__\u003C\u003ESteamV2_RightGrip_Upper_Pressure,
          SteamController.ActionOrigin.__\u003C\u003ESteamV2_Start,
          SteamController.ActionOrigin.__\u003C\u003ESteamV2_Back,
          SteamController.ActionOrigin.__\u003C\u003ESteamV2_LeftPad_Touch,
          SteamController.ActionOrigin.__\u003C\u003ESteamV2_LeftPad_Swipe,
          SteamController.ActionOrigin.__\u003C\u003ESteamV2_LeftPad_Click,
          SteamController.ActionOrigin.__\u003C\u003ESteamV2_LeftPad_Pressure,
          SteamController.ActionOrigin.__\u003C\u003ESteamV2_LeftPad_DPadNorth,
          SteamController.ActionOrigin.__\u003C\u003ESteamV2_LeftPad_DPadSouth,
          SteamController.ActionOrigin.__\u003C\u003ESteamV2_LeftPad_DPadWest,
          SteamController.ActionOrigin.__\u003C\u003ESteamV2_LeftPad_DPadEast,
          SteamController.ActionOrigin.__\u003C\u003ESteamV2_RightPad_Touch,
          SteamController.ActionOrigin.__\u003C\u003ESteamV2_RightPad_Swipe,
          SteamController.ActionOrigin.__\u003C\u003ESteamV2_RightPad_Click,
          SteamController.ActionOrigin.__\u003C\u003ESteamV2_RightPad_Pressure,
          SteamController.ActionOrigin.__\u003C\u003ESteamV2_RightPad_DPadNorth,
          SteamController.ActionOrigin.__\u003C\u003ESteamV2_RightPad_DPadSouth,
          SteamController.ActionOrigin.__\u003C\u003ESteamV2_RightPad_DPadWest,
          SteamController.ActionOrigin.__\u003C\u003ESteamV2_RightPad_DPadEast,
          SteamController.ActionOrigin.__\u003C\u003ESteamV2_LeftTrigger_Pull,
          SteamController.ActionOrigin.__\u003C\u003ESteamV2_LeftTrigger_Click,
          SteamController.ActionOrigin.__\u003C\u003ESteamV2_RightTrigger_Pull,
          SteamController.ActionOrigin.__\u003C\u003ESteamV2_RightTrigger_Click,
          SteamController.ActionOrigin.__\u003C\u003ESteamV2_LeftStick_Move,
          SteamController.ActionOrigin.__\u003C\u003ESteamV2_LeftStick_Click,
          SteamController.ActionOrigin.__\u003C\u003ESteamV2_LeftStick_DPadNorth,
          SteamController.ActionOrigin.__\u003C\u003ESteamV2_LeftStick_DPadSouth,
          SteamController.ActionOrigin.__\u003C\u003ESteamV2_LeftStick_DPadWest,
          SteamController.ActionOrigin.__\u003C\u003ESteamV2_LeftStick_DPadEast,
          SteamController.ActionOrigin.__\u003C\u003ESteamV2_Gyro_Move,
          SteamController.ActionOrigin.__\u003C\u003ESteamV2_Gyro_Pitch,
          SteamController.ActionOrigin.__\u003C\u003ESteamV2_Gyro_Yaw,
          SteamController.ActionOrigin.__\u003C\u003ESteamV2_Gyro_Roll
        };
        SteamController.ActionOrigin.values = SteamController.ActionOrigin.values();
      }

      [Modifiers]
      public static SteamController.ActionOrigin None
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003ENone;
      }

      [Modifiers]
      public static SteamController.ActionOrigin A
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003EA;
      }

      [Modifiers]
      public static SteamController.ActionOrigin B
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003EB;
      }

      [Modifiers]
      public static SteamController.ActionOrigin X
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003EX;
      }

      [Modifiers]
      public static SteamController.ActionOrigin Y
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003EY;
      }

      [Modifiers]
      public static SteamController.ActionOrigin LeftBumper
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003ELeftBumper;
      }

      [Modifiers]
      public static SteamController.ActionOrigin RightBumper
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003ERightBumper;
      }

      [Modifiers]
      public static SteamController.ActionOrigin LeftGrip
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003ELeftGrip;
      }

      [Modifiers]
      public static SteamController.ActionOrigin RightGrip
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003ERightGrip;
      }

      [Modifiers]
      public static SteamController.ActionOrigin Start
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003EStart;
      }

      [Modifiers]
      public static SteamController.ActionOrigin Back
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003EBack;
      }

      [Modifiers]
      public static SteamController.ActionOrigin LeftPad_Touch
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003ELeftPad_Touch;
      }

      [Modifiers]
      public static SteamController.ActionOrigin LeftPad_Swipe
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003ELeftPad_Swipe;
      }

      [Modifiers]
      public static SteamController.ActionOrigin LeftPad_Click
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003ELeftPad_Click;
      }

      [Modifiers]
      public static SteamController.ActionOrigin LeftPad_DPadNorth
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003ELeftPad_DPadNorth;
      }

      [Modifiers]
      public static SteamController.ActionOrigin LeftPad_DPadSouth
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003ELeftPad_DPadSouth;
      }

      [Modifiers]
      public static SteamController.ActionOrigin LeftPad_DPadWest
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003ELeftPad_DPadWest;
      }

      [Modifiers]
      public static SteamController.ActionOrigin LeftPad_DPadEast
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003ELeftPad_DPadEast;
      }

      [Modifiers]
      public static SteamController.ActionOrigin RightPad_Touch
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003ERightPad_Touch;
      }

      [Modifiers]
      public static SteamController.ActionOrigin RightPad_Swipe
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003ERightPad_Swipe;
      }

      [Modifiers]
      public static SteamController.ActionOrigin RightPad_Click
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003ERightPad_Click;
      }

      [Modifiers]
      public static SteamController.ActionOrigin RightPad_DPadNorth
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003ERightPad_DPadNorth;
      }

      [Modifiers]
      public static SteamController.ActionOrigin RightPad_DPadSouth
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003ERightPad_DPadSouth;
      }

      [Modifiers]
      public static SteamController.ActionOrigin RightPad_DPadWest
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003ERightPad_DPadWest;
      }

      [Modifiers]
      public static SteamController.ActionOrigin RightPad_DPadEast
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003ERightPad_DPadEast;
      }

      [Modifiers]
      public static SteamController.ActionOrigin LeftTrigger_Pull
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003ELeftTrigger_Pull;
      }

      [Modifiers]
      public static SteamController.ActionOrigin LeftTrigger_Click
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003ELeftTrigger_Click;
      }

      [Modifiers]
      public static SteamController.ActionOrigin RightTrigger_Pull
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003ERightTrigger_Pull;
      }

      [Modifiers]
      public static SteamController.ActionOrigin RightTrigger_Click
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003ERightTrigger_Click;
      }

      [Modifiers]
      public static SteamController.ActionOrigin LeftStick_Move
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003ELeftStick_Move;
      }

      [Modifiers]
      public static SteamController.ActionOrigin LeftStick_Click
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003ELeftStick_Click;
      }

      [Modifiers]
      public static SteamController.ActionOrigin LeftStick_DPadNorth
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003ELeftStick_DPadNorth;
      }

      [Modifiers]
      public static SteamController.ActionOrigin LeftStick_DPadSouth
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003ELeftStick_DPadSouth;
      }

      [Modifiers]
      public static SteamController.ActionOrigin LeftStick_DPadWest
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003ELeftStick_DPadWest;
      }

      [Modifiers]
      public static SteamController.ActionOrigin LeftStick_DPadEast
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003ELeftStick_DPadEast;
      }

      [Modifiers]
      public static SteamController.ActionOrigin Gyro_Move
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003EGyro_Move;
      }

      [Modifiers]
      public static SteamController.ActionOrigin Gyro_Pitch
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003EGyro_Pitch;
      }

      [Modifiers]
      public static SteamController.ActionOrigin Gyro_Yaw
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003EGyro_Yaw;
      }

      [Modifiers]
      public static SteamController.ActionOrigin Gyro_Roll
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003EGyro_Roll;
      }

      [Modifiers]
      public static SteamController.ActionOrigin PS4_X
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003EPS4_X;
      }

      [Modifiers]
      public static SteamController.ActionOrigin PS4_Circle
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003EPS4_Circle;
      }

      [Modifiers]
      public static SteamController.ActionOrigin PS4_Triangle
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003EPS4_Triangle;
      }

      [Modifiers]
      public static SteamController.ActionOrigin PS4_Square
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003EPS4_Square;
      }

      [Modifiers]
      public static SteamController.ActionOrigin PS4_LeftBumper
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003EPS4_LeftBumper;
      }

      [Modifiers]
      public static SteamController.ActionOrigin PS4_RightBumper
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003EPS4_RightBumper;
      }

      [Modifiers]
      public static SteamController.ActionOrigin PS4_Options
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003EPS4_Options;
      }

      [Modifiers]
      public static SteamController.ActionOrigin PS4_Share
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003EPS4_Share;
      }

      [Modifiers]
      public static SteamController.ActionOrigin PS4_LeftPad_Touch
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003EPS4_LeftPad_Touch;
      }

      [Modifiers]
      public static SteamController.ActionOrigin PS4_LeftPad_Swipe
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003EPS4_LeftPad_Swipe;
      }

      [Modifiers]
      public static SteamController.ActionOrigin PS4_LeftPad_Click
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003EPS4_LeftPad_Click;
      }

      [Modifiers]
      public static SteamController.ActionOrigin PS4_LeftPad_DPadNorth
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003EPS4_LeftPad_DPadNorth;
      }

      [Modifiers]
      public static SteamController.ActionOrigin PS4_LeftPad_DPadSouth
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003EPS4_LeftPad_DPadSouth;
      }

      [Modifiers]
      public static SteamController.ActionOrigin PS4_LeftPad_DPadWest
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003EPS4_LeftPad_DPadWest;
      }

      [Modifiers]
      public static SteamController.ActionOrigin PS4_LeftPad_DPadEast
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003EPS4_LeftPad_DPadEast;
      }

      [Modifiers]
      public static SteamController.ActionOrigin PS4_RightPad_Touch
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003EPS4_RightPad_Touch;
      }

      [Modifiers]
      public static SteamController.ActionOrigin PS4_RightPad_Swipe
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003EPS4_RightPad_Swipe;
      }

      [Modifiers]
      public static SteamController.ActionOrigin PS4_RightPad_Click
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003EPS4_RightPad_Click;
      }

      [Modifiers]
      public static SteamController.ActionOrigin PS4_RightPad_DPadNorth
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003EPS4_RightPad_DPadNorth;
      }

      [Modifiers]
      public static SteamController.ActionOrigin PS4_RightPad_DPadSouth
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003EPS4_RightPad_DPadSouth;
      }

      [Modifiers]
      public static SteamController.ActionOrigin PS4_RightPad_DPadWest
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003EPS4_RightPad_DPadWest;
      }

      [Modifiers]
      public static SteamController.ActionOrigin PS4_RightPad_DPadEast
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003EPS4_RightPad_DPadEast;
      }

      [Modifiers]
      public static SteamController.ActionOrigin PS4_CenterPad_Touch
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003EPS4_CenterPad_Touch;
      }

      [Modifiers]
      public static SteamController.ActionOrigin PS4_CenterPad_Swipe
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003EPS4_CenterPad_Swipe;
      }

      [Modifiers]
      public static SteamController.ActionOrigin PS4_CenterPad_Click
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003EPS4_CenterPad_Click;
      }

      [Modifiers]
      public static SteamController.ActionOrigin PS4_CenterPad_DPadNorth
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003EPS4_CenterPad_DPadNorth;
      }

      [Modifiers]
      public static SteamController.ActionOrigin PS4_CenterPad_DPadSouth
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003EPS4_CenterPad_DPadSouth;
      }

      [Modifiers]
      public static SteamController.ActionOrigin PS4_CenterPad_DPadWest
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003EPS4_CenterPad_DPadWest;
      }

      [Modifiers]
      public static SteamController.ActionOrigin PS4_CenterPad_DPadEast
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003EPS4_CenterPad_DPadEast;
      }

      [Modifiers]
      public static SteamController.ActionOrigin PS4_LeftTrigger_Pull
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003EPS4_LeftTrigger_Pull;
      }

      [Modifiers]
      public static SteamController.ActionOrigin PS4_LeftTrigger_Click
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003EPS4_LeftTrigger_Click;
      }

      [Modifiers]
      public static SteamController.ActionOrigin PS4_RightTrigger_Pull
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003EPS4_RightTrigger_Pull;
      }

      [Modifiers]
      public static SteamController.ActionOrigin PS4_RightTrigger_Click
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003EPS4_RightTrigger_Click;
      }

      [Modifiers]
      public static SteamController.ActionOrigin PS4_LeftStick_Move
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003EPS4_LeftStick_Move;
      }

      [Modifiers]
      public static SteamController.ActionOrigin PS4_LeftStick_Click
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003EPS4_LeftStick_Click;
      }

      [Modifiers]
      public static SteamController.ActionOrigin PS4_LeftStick_DPadNorth
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003EPS4_LeftStick_DPadNorth;
      }

      [Modifiers]
      public static SteamController.ActionOrigin PS4_LeftStick_DPadSouth
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003EPS4_LeftStick_DPadSouth;
      }

      [Modifiers]
      public static SteamController.ActionOrigin PS4_LeftStick_DPadWest
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003EPS4_LeftStick_DPadWest;
      }

      [Modifiers]
      public static SteamController.ActionOrigin PS4_LeftStick_DPadEast
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003EPS4_LeftStick_DPadEast;
      }

      [Modifiers]
      public static SteamController.ActionOrigin PS4_RightStick_Move
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003EPS4_RightStick_Move;
      }

      [Modifiers]
      public static SteamController.ActionOrigin PS4_RightStick_Click
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003EPS4_RightStick_Click;
      }

      [Modifiers]
      public static SteamController.ActionOrigin PS4_RightStick_DPadNorth
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003EPS4_RightStick_DPadNorth;
      }

      [Modifiers]
      public static SteamController.ActionOrigin PS4_RightStick_DPadSouth
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003EPS4_RightStick_DPadSouth;
      }

      [Modifiers]
      public static SteamController.ActionOrigin PS4_RightStick_DPadWest
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003EPS4_RightStick_DPadWest;
      }

      [Modifiers]
      public static SteamController.ActionOrigin PS4_RightStick_DPadEast
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003EPS4_RightStick_DPadEast;
      }

      [Modifiers]
      public static SteamController.ActionOrigin PS4_DPad_North
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003EPS4_DPad_North;
      }

      [Modifiers]
      public static SteamController.ActionOrigin PS4_DPad_South
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003EPS4_DPad_South;
      }

      [Modifiers]
      public static SteamController.ActionOrigin PS4_DPad_West
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003EPS4_DPad_West;
      }

      [Modifiers]
      public static SteamController.ActionOrigin PS4_DPad_East
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003EPS4_DPad_East;
      }

      [Modifiers]
      public static SteamController.ActionOrigin PS4_Gyro_Move
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003EPS4_Gyro_Move;
      }

      [Modifiers]
      public static SteamController.ActionOrigin PS4_Gyro_Pitch
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003EPS4_Gyro_Pitch;
      }

      [Modifiers]
      public static SteamController.ActionOrigin PS4_Gyro_Yaw
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003EPS4_Gyro_Yaw;
      }

      [Modifiers]
      public static SteamController.ActionOrigin PS4_Gyro_Roll
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003EPS4_Gyro_Roll;
      }

      [Modifiers]
      public static SteamController.ActionOrigin XBoxOne_A
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003EXBoxOne_A;
      }

      [Modifiers]
      public static SteamController.ActionOrigin XBoxOne_B
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003EXBoxOne_B;
      }

      [Modifiers]
      public static SteamController.ActionOrigin XBoxOne_X
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003EXBoxOne_X;
      }

      [Modifiers]
      public static SteamController.ActionOrigin XBoxOne_Y
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003EXBoxOne_Y;
      }

      [Modifiers]
      public static SteamController.ActionOrigin XBoxOne_LeftBumper
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003EXBoxOne_LeftBumper;
      }

      [Modifiers]
      public static SteamController.ActionOrigin XBoxOne_RightBumper
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003EXBoxOne_RightBumper;
      }

      [Modifiers]
      public static SteamController.ActionOrigin XBoxOne_Menu
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003EXBoxOne_Menu;
      }

      [Modifiers]
      public static SteamController.ActionOrigin XBoxOne_View
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003EXBoxOne_View;
      }

      [Modifiers]
      public static SteamController.ActionOrigin XBoxOne_LeftTrigger_Pull
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003EXBoxOne_LeftTrigger_Pull;
      }

      [Modifiers]
      public static SteamController.ActionOrigin XBoxOne_LeftTrigger_Click
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003EXBoxOne_LeftTrigger_Click;
      }

      [Modifiers]
      public static SteamController.ActionOrigin XBoxOne_RightTrigger_Pull
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003EXBoxOne_RightTrigger_Pull;
      }

      [Modifiers]
      public static SteamController.ActionOrigin XBoxOne_RightTrigger_Click
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003EXBoxOne_RightTrigger_Click;
      }

      [Modifiers]
      public static SteamController.ActionOrigin XBoxOne_LeftStick_Move
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003EXBoxOne_LeftStick_Move;
      }

      [Modifiers]
      public static SteamController.ActionOrigin XBoxOne_LeftStick_Click
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003EXBoxOne_LeftStick_Click;
      }

      [Modifiers]
      public static SteamController.ActionOrigin XBoxOne_LeftStick_DPadNorth
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003EXBoxOne_LeftStick_DPadNorth;
      }

      [Modifiers]
      public static SteamController.ActionOrigin XBoxOne_LeftStick_DPadSouth
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003EXBoxOne_LeftStick_DPadSouth;
      }

      [Modifiers]
      public static SteamController.ActionOrigin XBoxOne_LeftStick_DPadWest
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003EXBoxOne_LeftStick_DPadWest;
      }

      [Modifiers]
      public static SteamController.ActionOrigin XBoxOne_LeftStick_DPadEast
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003EXBoxOne_LeftStick_DPadEast;
      }

      [Modifiers]
      public static SteamController.ActionOrigin XBoxOne_RightStick_Move
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003EXBoxOne_RightStick_Move;
      }

      [Modifiers]
      public static SteamController.ActionOrigin XBoxOne_RightStick_Click
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003EXBoxOne_RightStick_Click;
      }

      [Modifiers]
      public static SteamController.ActionOrigin XBoxOne_RightStick_DPadNorth
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003EXBoxOne_RightStick_DPadNorth;
      }

      [Modifiers]
      public static SteamController.ActionOrigin XBoxOne_RightStick_DPadSouth
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003EXBoxOne_RightStick_DPadSouth;
      }

      [Modifiers]
      public static SteamController.ActionOrigin XBoxOne_RightStick_DPadWest
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003EXBoxOne_RightStick_DPadWest;
      }

      [Modifiers]
      public static SteamController.ActionOrigin XBoxOne_RightStick_DPadEast
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003EXBoxOne_RightStick_DPadEast;
      }

      [Modifiers]
      public static SteamController.ActionOrigin XBoxOne_DPad_North
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003EXBoxOne_DPad_North;
      }

      [Modifiers]
      public static SteamController.ActionOrigin XBoxOne_DPad_South
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003EXBoxOne_DPad_South;
      }

      [Modifiers]
      public static SteamController.ActionOrigin XBoxOne_DPad_West
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003EXBoxOne_DPad_West;
      }

      [Modifiers]
      public static SteamController.ActionOrigin XBoxOne_DPad_East
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003EXBoxOne_DPad_East;
      }

      [Modifiers]
      public static SteamController.ActionOrigin XBox360_A
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003EXBox360_A;
      }

      [Modifiers]
      public static SteamController.ActionOrigin XBox360_B
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003EXBox360_B;
      }

      [Modifiers]
      public static SteamController.ActionOrigin XBox360_X
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003EXBox360_X;
      }

      [Modifiers]
      public static SteamController.ActionOrigin XBox360_Y
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003EXBox360_Y;
      }

      [Modifiers]
      public static SteamController.ActionOrigin XBox360_LeftBumper
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003EXBox360_LeftBumper;
      }

      [Modifiers]
      public static SteamController.ActionOrigin XBox360_RightBumper
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003EXBox360_RightBumper;
      }

      [Modifiers]
      public static SteamController.ActionOrigin XBox360_Start
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003EXBox360_Start;
      }

      [Modifiers]
      public static SteamController.ActionOrigin XBox360_Back
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003EXBox360_Back;
      }

      [Modifiers]
      public static SteamController.ActionOrigin XBox360_LeftTrigger_Pull
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003EXBox360_LeftTrigger_Pull;
      }

      [Modifiers]
      public static SteamController.ActionOrigin XBox360_LeftTrigger_Click
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003EXBox360_LeftTrigger_Click;
      }

      [Modifiers]
      public static SteamController.ActionOrigin XBox360_RightTrigger_Pull
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003EXBox360_RightTrigger_Pull;
      }

      [Modifiers]
      public static SteamController.ActionOrigin XBox360_RightTrigger_Click
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003EXBox360_RightTrigger_Click;
      }

      [Modifiers]
      public static SteamController.ActionOrigin XBox360_LeftStick_Move
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003EXBox360_LeftStick_Move;
      }

      [Modifiers]
      public static SteamController.ActionOrigin XBox360_LeftStick_Click
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003EXBox360_LeftStick_Click;
      }

      [Modifiers]
      public static SteamController.ActionOrigin XBox360_LeftStick_DPadNorth
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003EXBox360_LeftStick_DPadNorth;
      }

      [Modifiers]
      public static SteamController.ActionOrigin XBox360_LeftStick_DPadSouth
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003EXBox360_LeftStick_DPadSouth;
      }

      [Modifiers]
      public static SteamController.ActionOrigin XBox360_LeftStick_DPadWest
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003EXBox360_LeftStick_DPadWest;
      }

      [Modifiers]
      public static SteamController.ActionOrigin XBox360_LeftStick_DPadEast
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003EXBox360_LeftStick_DPadEast;
      }

      [Modifiers]
      public static SteamController.ActionOrigin XBox360_RightStick_Move
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003EXBox360_RightStick_Move;
      }

      [Modifiers]
      public static SteamController.ActionOrigin XBox360_RightStick_Click
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003EXBox360_RightStick_Click;
      }

      [Modifiers]
      public static SteamController.ActionOrigin XBox360_RightStick_DPadNorth
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003EXBox360_RightStick_DPadNorth;
      }

      [Modifiers]
      public static SteamController.ActionOrigin XBox360_RightStick_DPadSouth
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003EXBox360_RightStick_DPadSouth;
      }

      [Modifiers]
      public static SteamController.ActionOrigin XBox360_RightStick_DPadWest
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003EXBox360_RightStick_DPadWest;
      }

      [Modifiers]
      public static SteamController.ActionOrigin XBox360_RightStick_DPadEast
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003EXBox360_RightStick_DPadEast;
      }

      [Modifiers]
      public static SteamController.ActionOrigin XBox360_DPad_North
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003EXBox360_DPad_North;
      }

      [Modifiers]
      public static SteamController.ActionOrigin XBox360_DPad_South
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003EXBox360_DPad_South;
      }

      [Modifiers]
      public static SteamController.ActionOrigin XBox360_DPad_West
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003EXBox360_DPad_West;
      }

      [Modifiers]
      public static SteamController.ActionOrigin XBox360_DPad_East
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003EXBox360_DPad_East;
      }

      [Modifiers]
      public static SteamController.ActionOrigin SteamV2_A
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003ESteamV2_A;
      }

      [Modifiers]
      public static SteamController.ActionOrigin SteamV2_B
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003ESteamV2_B;
      }

      [Modifiers]
      public static SteamController.ActionOrigin SteamV2_X
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003ESteamV2_X;
      }

      [Modifiers]
      public static SteamController.ActionOrigin SteamV2_Y
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003ESteamV2_Y;
      }

      [Modifiers]
      public static SteamController.ActionOrigin SteamV2_LeftBumper
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003ESteamV2_LeftBumper;
      }

      [Modifiers]
      public static SteamController.ActionOrigin SteamV2_RightBumper
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003ESteamV2_RightBumper;
      }

      [Modifiers]
      public static SteamController.ActionOrigin SteamV2_LeftGrip
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003ESteamV2_LeftGrip;
      }

      [Modifiers]
      public static SteamController.ActionOrigin SteamV2_RightGrip
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003ESteamV2_RightGrip;
      }

      [Modifiers]
      public static SteamController.ActionOrigin SteamV2_LeftGrip_Upper
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003ESteamV2_LeftGrip_Upper;
      }

      [Modifiers]
      public static SteamController.ActionOrigin SteamV2_RightGrip_Upper
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003ESteamV2_RightGrip_Upper;
      }

      [Modifiers]
      public static SteamController.ActionOrigin SteamV2_LeftBumper_Pressure
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003ESteamV2_LeftBumper_Pressure;
      }

      [Modifiers]
      public static SteamController.ActionOrigin SteamV2_RightBumper_Pressure
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003ESteamV2_RightBumper_Pressure;
      }

      [Modifiers]
      public static SteamController.ActionOrigin SteamV2_LeftGrip_Pressure
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003ESteamV2_LeftGrip_Pressure;
      }

      [Modifiers]
      public static SteamController.ActionOrigin SteamV2_RightGrip_Pressure
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003ESteamV2_RightGrip_Pressure;
      }

      [Modifiers]
      public static SteamController.ActionOrigin SteamV2_LeftGrip_Upper_Pressure
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003ESteamV2_LeftGrip_Upper_Pressure;
      }

      [Modifiers]
      public static SteamController.ActionOrigin SteamV2_RightGrip_Upper_Pressure
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003ESteamV2_RightGrip_Upper_Pressure;
      }

      [Modifiers]
      public static SteamController.ActionOrigin SteamV2_Start
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003ESteamV2_Start;
      }

      [Modifiers]
      public static SteamController.ActionOrigin SteamV2_Back
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003ESteamV2_Back;
      }

      [Modifiers]
      public static SteamController.ActionOrigin SteamV2_LeftPad_Touch
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003ESteamV2_LeftPad_Touch;
      }

      [Modifiers]
      public static SteamController.ActionOrigin SteamV2_LeftPad_Swipe
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003ESteamV2_LeftPad_Swipe;
      }

      [Modifiers]
      public static SteamController.ActionOrigin SteamV2_LeftPad_Click
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003ESteamV2_LeftPad_Click;
      }

      [Modifiers]
      public static SteamController.ActionOrigin SteamV2_LeftPad_Pressure
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003ESteamV2_LeftPad_Pressure;
      }

      [Modifiers]
      public static SteamController.ActionOrigin SteamV2_LeftPad_DPadNorth
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003ESteamV2_LeftPad_DPadNorth;
      }

      [Modifiers]
      public static SteamController.ActionOrigin SteamV2_LeftPad_DPadSouth
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003ESteamV2_LeftPad_DPadSouth;
      }

      [Modifiers]
      public static SteamController.ActionOrigin SteamV2_LeftPad_DPadWest
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003ESteamV2_LeftPad_DPadWest;
      }

      [Modifiers]
      public static SteamController.ActionOrigin SteamV2_LeftPad_DPadEast
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003ESteamV2_LeftPad_DPadEast;
      }

      [Modifiers]
      public static SteamController.ActionOrigin SteamV2_RightPad_Touch
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003ESteamV2_RightPad_Touch;
      }

      [Modifiers]
      public static SteamController.ActionOrigin SteamV2_RightPad_Swipe
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003ESteamV2_RightPad_Swipe;
      }

      [Modifiers]
      public static SteamController.ActionOrigin SteamV2_RightPad_Click
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003ESteamV2_RightPad_Click;
      }

      [Modifiers]
      public static SteamController.ActionOrigin SteamV2_RightPad_Pressure
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003ESteamV2_RightPad_Pressure;
      }

      [Modifiers]
      public static SteamController.ActionOrigin SteamV2_RightPad_DPadNorth
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003ESteamV2_RightPad_DPadNorth;
      }

      [Modifiers]
      public static SteamController.ActionOrigin SteamV2_RightPad_DPadSouth
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003ESteamV2_RightPad_DPadSouth;
      }

      [Modifiers]
      public static SteamController.ActionOrigin SteamV2_RightPad_DPadWest
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003ESteamV2_RightPad_DPadWest;
      }

      [Modifiers]
      public static SteamController.ActionOrigin SteamV2_RightPad_DPadEast
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003ESteamV2_RightPad_DPadEast;
      }

      [Modifiers]
      public static SteamController.ActionOrigin SteamV2_LeftTrigger_Pull
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003ESteamV2_LeftTrigger_Pull;
      }

      [Modifiers]
      public static SteamController.ActionOrigin SteamV2_LeftTrigger_Click
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003ESteamV2_LeftTrigger_Click;
      }

      [Modifiers]
      public static SteamController.ActionOrigin SteamV2_RightTrigger_Pull
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003ESteamV2_RightTrigger_Pull;
      }

      [Modifiers]
      public static SteamController.ActionOrigin SteamV2_RightTrigger_Click
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003ESteamV2_RightTrigger_Click;
      }

      [Modifiers]
      public static SteamController.ActionOrigin SteamV2_LeftStick_Move
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003ESteamV2_LeftStick_Move;
      }

      [Modifiers]
      public static SteamController.ActionOrigin SteamV2_LeftStick_Click
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003ESteamV2_LeftStick_Click;
      }

      [Modifiers]
      public static SteamController.ActionOrigin SteamV2_LeftStick_DPadNorth
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003ESteamV2_LeftStick_DPadNorth;
      }

      [Modifiers]
      public static SteamController.ActionOrigin SteamV2_LeftStick_DPadSouth
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003ESteamV2_LeftStick_DPadSouth;
      }

      [Modifiers]
      public static SteamController.ActionOrigin SteamV2_LeftStick_DPadWest
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003ESteamV2_LeftStick_DPadWest;
      }

      [Modifiers]
      public static SteamController.ActionOrigin SteamV2_LeftStick_DPadEast
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003ESteamV2_LeftStick_DPadEast;
      }

      [Modifiers]
      public static SteamController.ActionOrigin SteamV2_Gyro_Move
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003ESteamV2_Gyro_Move;
      }

      [Modifiers]
      public static SteamController.ActionOrigin SteamV2_Gyro_Pitch
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003ESteamV2_Gyro_Pitch;
      }

      [Modifiers]
      public static SteamController.ActionOrigin SteamV2_Gyro_Yaw
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003ESteamV2_Gyro_Yaw;
      }

      [Modifiers]
      public static SteamController.ActionOrigin SteamV2_Gyro_Roll
      {
        [HideFromJava] get => SteamController.ActionOrigin.__\u003C\u003ESteamV2_Gyro_Roll;
      }

      [HideFromJava]
      [Serializable]
      public enum __Enum
      {
        None,
        A,
        B,
        X,
        Y,
        LeftBumper,
        RightBumper,
        LeftGrip,
        RightGrip,
        Start,
        Back,
        LeftPad_Touch,
        LeftPad_Swipe,
        LeftPad_Click,
        LeftPad_DPadNorth,
        LeftPad_DPadSouth,
        LeftPad_DPadWest,
        LeftPad_DPadEast,
        RightPad_Touch,
        RightPad_Swipe,
        RightPad_Click,
        RightPad_DPadNorth,
        RightPad_DPadSouth,
        RightPad_DPadWest,
        RightPad_DPadEast,
        LeftTrigger_Pull,
        LeftTrigger_Click,
        RightTrigger_Pull,
        RightTrigger_Click,
        LeftStick_Move,
        LeftStick_Click,
        LeftStick_DPadNorth,
        LeftStick_DPadSouth,
        LeftStick_DPadWest,
        LeftStick_DPadEast,
        Gyro_Move,
        Gyro_Pitch,
        Gyro_Yaw,
        Gyro_Roll,
        PS4_X,
        PS4_Circle,
        PS4_Triangle,
        PS4_Square,
        PS4_LeftBumper,
        PS4_RightBumper,
        PS4_Options,
        PS4_Share,
        PS4_LeftPad_Touch,
        PS4_LeftPad_Swipe,
        PS4_LeftPad_Click,
        PS4_LeftPad_DPadNorth,
        PS4_LeftPad_DPadSouth,
        PS4_LeftPad_DPadWest,
        PS4_LeftPad_DPadEast,
        PS4_RightPad_Touch,
        PS4_RightPad_Swipe,
        PS4_RightPad_Click,
        PS4_RightPad_DPadNorth,
        PS4_RightPad_DPadSouth,
        PS4_RightPad_DPadWest,
        PS4_RightPad_DPadEast,
        PS4_CenterPad_Touch,
        PS4_CenterPad_Swipe,
        PS4_CenterPad_Click,
        PS4_CenterPad_DPadNorth,
        PS4_CenterPad_DPadSouth,
        PS4_CenterPad_DPadWest,
        PS4_CenterPad_DPadEast,
        PS4_LeftTrigger_Pull,
        PS4_LeftTrigger_Click,
        PS4_RightTrigger_Pull,
        PS4_RightTrigger_Click,
        PS4_LeftStick_Move,
        PS4_LeftStick_Click,
        PS4_LeftStick_DPadNorth,
        PS4_LeftStick_DPadSouth,
        PS4_LeftStick_DPadWest,
        PS4_LeftStick_DPadEast,
        PS4_RightStick_Move,
        PS4_RightStick_Click,
        PS4_RightStick_DPadNorth,
        PS4_RightStick_DPadSouth,
        PS4_RightStick_DPadWest,
        PS4_RightStick_DPadEast,
        PS4_DPad_North,
        PS4_DPad_South,
        PS4_DPad_West,
        PS4_DPad_East,
        PS4_Gyro_Move,
        PS4_Gyro_Pitch,
        PS4_Gyro_Yaw,
        PS4_Gyro_Roll,
        XBoxOne_A,
        XBoxOne_B,
        XBoxOne_X,
        XBoxOne_Y,
        XBoxOne_LeftBumper,
        XBoxOne_RightBumper,
        XBoxOne_Menu,
        XBoxOne_View,
        XBoxOne_LeftTrigger_Pull,
        XBoxOne_LeftTrigger_Click,
        XBoxOne_RightTrigger_Pull,
        XBoxOne_RightTrigger_Click,
        XBoxOne_LeftStick_Move,
        XBoxOne_LeftStick_Click,
        XBoxOne_LeftStick_DPadNorth,
        XBoxOne_LeftStick_DPadSouth,
        XBoxOne_LeftStick_DPadWest,
        XBoxOne_LeftStick_DPadEast,
        XBoxOne_RightStick_Move,
        XBoxOne_RightStick_Click,
        XBoxOne_RightStick_DPadNorth,
        XBoxOne_RightStick_DPadSouth,
        XBoxOne_RightStick_DPadWest,
        XBoxOne_RightStick_DPadEast,
        XBoxOne_DPad_North,
        XBoxOne_DPad_South,
        XBoxOne_DPad_West,
        XBoxOne_DPad_East,
        XBox360_A,
        XBox360_B,
        XBox360_X,
        XBox360_Y,
        XBox360_LeftBumper,
        XBox360_RightBumper,
        XBox360_Start,
        XBox360_Back,
        XBox360_LeftTrigger_Pull,
        XBox360_LeftTrigger_Click,
        XBox360_RightTrigger_Pull,
        XBox360_RightTrigger_Click,
        XBox360_LeftStick_Move,
        XBox360_LeftStick_Click,
        XBox360_LeftStick_DPadNorth,
        XBox360_LeftStick_DPadSouth,
        XBox360_LeftStick_DPadWest,
        XBox360_LeftStick_DPadEast,
        XBox360_RightStick_Move,
        XBox360_RightStick_Click,
        XBox360_RightStick_DPadNorth,
        XBox360_RightStick_DPadSouth,
        XBox360_RightStick_DPadWest,
        XBox360_RightStick_DPadEast,
        XBox360_DPad_North,
        XBox360_DPad_South,
        XBox360_DPad_West,
        XBox360_DPad_East,
        SteamV2_A,
        SteamV2_B,
        SteamV2_X,
        SteamV2_Y,
        SteamV2_LeftBumper,
        SteamV2_RightBumper,
        SteamV2_LeftGrip,
        SteamV2_RightGrip,
        SteamV2_LeftGrip_Upper,
        SteamV2_RightGrip_Upper,
        SteamV2_LeftBumper_Pressure,
        SteamV2_RightBumper_Pressure,
        SteamV2_LeftGrip_Pressure,
        SteamV2_RightGrip_Pressure,
        SteamV2_LeftGrip_Upper_Pressure,
        SteamV2_RightGrip_Upper_Pressure,
        SteamV2_Start,
        SteamV2_Back,
        SteamV2_LeftPad_Touch,
        SteamV2_LeftPad_Swipe,
        SteamV2_LeftPad_Click,
        SteamV2_LeftPad_Pressure,
        SteamV2_LeftPad_DPadNorth,
        SteamV2_LeftPad_DPadSouth,
        SteamV2_LeftPad_DPadWest,
        SteamV2_LeftPad_DPadEast,
        SteamV2_RightPad_Touch,
        SteamV2_RightPad_Swipe,
        SteamV2_RightPad_Click,
        SteamV2_RightPad_Pressure,
        SteamV2_RightPad_DPadNorth,
        SteamV2_RightPad_DPadSouth,
        SteamV2_RightPad_DPadWest,
        SteamV2_RightPad_DPadEast,
        SteamV2_LeftTrigger_Pull,
        SteamV2_LeftTrigger_Click,
        SteamV2_RightTrigger_Pull,
        SteamV2_RightTrigger_Click,
        SteamV2_LeftStick_Move,
        SteamV2_LeftStick_Click,
        SteamV2_LeftStick_DPadNorth,
        SteamV2_LeftStick_DPadSouth,
        SteamV2_LeftStick_DPadWest,
        SteamV2_LeftStick_DPadEast,
        SteamV2_Gyro_Move,
        SteamV2_Gyro_Pitch,
        SteamV2_Gyro_Yaw,
        SteamV2_Gyro_Roll,
      }
    }

    [InnerClass]
    [Signature("Ljava/lang/Enum<Lcom/codedisaster/steamworks/SteamController$InputType;>;")]
    [Modifiers]
    [Serializable]
    public sealed class InputType : Enum
    {
      [Modifiers]
      internal static SteamController.InputType __\u003C\u003EUnknown;
      [Modifiers]
      internal static SteamController.InputType __\u003C\u003ESteamController;
      [Modifiers]
      internal static SteamController.InputType __\u003C\u003EXBox360Controller;
      [Modifiers]
      internal static SteamController.InputType __\u003C\u003EXBoxOneController;
      [Modifiers]
      internal static SteamController.InputType __\u003C\u003EGenericXInput;
      [Modifiers]
      internal static SteamController.InputType __\u003C\u003EPS4Controller;
      [Modifiers]
      private static SteamController.InputType[] values;
      [Modifiers]
      private static SteamController.InputType[] \u0024VALUES;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(278)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal static SteamController.InputType byOrdinal([In] int obj0) => SteamController.InputType.values[obj0];

      [Signature("()V")]
      [LineNumberTable(267)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private InputType([In] string obj0, [In] int obj1)
        : base(obj0, obj1)
      {
        GC.KeepAlive((object) this);
      }

      [LineNumberTable(267)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static SteamController.InputType[] values() => (SteamController.InputType[]) SteamController.InputType.\u0024VALUES.Clone();

      [LineNumberTable(267)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static SteamController.InputType valueOf(string name) => (SteamController.InputType) Enum.valueOf((Class) ClassLiteral<SteamController.InputType>.Value, name);

      [LineNumberTable(new byte[] {159, 75, 77, 112, 112, 112, 112, 112, 240, 58, 255, 28, 72})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static InputType()
      {
        if (ByteCodeHelper.isAlreadyInited("com.codedisaster.steamworks.SteamController$InputType"))
          return;
        SteamController.InputType.__\u003C\u003EUnknown = new SteamController.InputType(nameof (Unknown), 0);
        SteamController.InputType.__\u003C\u003ESteamController = new SteamController.InputType(nameof (SteamController), 1);
        SteamController.InputType.__\u003C\u003EXBox360Controller = new SteamController.InputType(nameof (XBox360Controller), 2);
        SteamController.InputType.__\u003C\u003EXBoxOneController = new SteamController.InputType(nameof (XBoxOneController), 3);
        SteamController.InputType.__\u003C\u003EGenericXInput = new SteamController.InputType(nameof (GenericXInput), 4);
        SteamController.InputType.__\u003C\u003EPS4Controller = new SteamController.InputType(nameof (PS4Controller), 5);
        SteamController.InputType.\u0024VALUES = new SteamController.InputType[6]
        {
          SteamController.InputType.__\u003C\u003EUnknown,
          SteamController.InputType.__\u003C\u003ESteamController,
          SteamController.InputType.__\u003C\u003EXBox360Controller,
          SteamController.InputType.__\u003C\u003EXBoxOneController,
          SteamController.InputType.__\u003C\u003EGenericXInput,
          SteamController.InputType.__\u003C\u003EPS4Controller
        };
        SteamController.InputType.values = SteamController.InputType.values();
      }

      [Modifiers]
      public static SteamController.InputType Unknown
      {
        [HideFromJava] get => SteamController.InputType.__\u003C\u003EUnknown;
      }

      [Modifiers]
      public static SteamController.InputType SteamController
      {
        [HideFromJava] get => SteamController.InputType.__\u003C\u003ESteamController;
      }

      [Modifiers]
      public static SteamController.InputType XBox360Controller
      {
        [HideFromJava] get => SteamController.InputType.__\u003C\u003EXBox360Controller;
      }

      [Modifiers]
      public static SteamController.InputType XBoxOneController
      {
        [HideFromJava] get => SteamController.InputType.__\u003C\u003EXBoxOneController;
      }

      [Modifiers]
      public static SteamController.InputType GenericXInput
      {
        [HideFromJava] get => SteamController.InputType.__\u003C\u003EGenericXInput;
      }

      [Modifiers]
      public static SteamController.InputType PS4Controller
      {
        [HideFromJava] get => SteamController.InputType.__\u003C\u003EPS4Controller;
      }

      [HideFromJava]
      [Serializable]
      public enum __Enum
      {
        Unknown,
        SteamController,
        XBox360Controller,
        XBoxOneController,
        GenericXInput,
        PS4Controller,
      }
    }

    [InnerClass]
    [Signature("Ljava/lang/Enum<Lcom/codedisaster/steamworks/SteamController$LEDFlag;>;")]
    [Modifiers]
    [Serializable]
    public sealed class LEDFlag : Enum
    {
      [Modifiers]
      internal static SteamController.LEDFlag __\u003C\u003ESetColor;
      [Modifiers]
      internal static SteamController.LEDFlag __\u003C\u003ERestoreUserDefault;
      [Modifiers]
      private static SteamController.LEDFlag[] \u0024VALUES;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [Signature("()V")]
      [LineNumberTable(262)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private LEDFlag([In] string obj0, [In] int obj1)
        : base(obj0, obj1)
      {
        GC.KeepAlive((object) this);
      }

      [LineNumberTable(262)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static SteamController.LEDFlag[] values() => (SteamController.LEDFlag[]) SteamController.LEDFlag.\u0024VALUES.Clone();

      [LineNumberTable(262)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static SteamController.LEDFlag valueOf(string name) => (SteamController.LEDFlag) Enum.valueOf((Class) ClassLiteral<SteamController.LEDFlag>.Value, name);

      [LineNumberTable(new byte[] {159, 77, 173, 112, 16})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static LEDFlag()
      {
        if (ByteCodeHelper.isAlreadyInited("com.codedisaster.steamworks.SteamController$LEDFlag"))
          return;
        SteamController.LEDFlag.__\u003C\u003ESetColor = new SteamController.LEDFlag(nameof (SetColor), 0);
        SteamController.LEDFlag.__\u003C\u003ERestoreUserDefault = new SteamController.LEDFlag(nameof (RestoreUserDefault), 1);
        SteamController.LEDFlag.\u0024VALUES = new SteamController.LEDFlag[2]
        {
          SteamController.LEDFlag.__\u003C\u003ESetColor,
          SteamController.LEDFlag.__\u003C\u003ERestoreUserDefault
        };
      }

      [Modifiers]
      public static SteamController.LEDFlag SetColor
      {
        [HideFromJava] get => SteamController.LEDFlag.__\u003C\u003ESetColor;
      }

      [Modifiers]
      public static SteamController.LEDFlag RestoreUserDefault
      {
        [HideFromJava] get => SteamController.LEDFlag.__\u003C\u003ERestoreUserDefault;
      }

      [HideFromJava]
      [Serializable]
      public enum __Enum
      {
        SetColor,
        RestoreUserDefault,
      }
    }

    [InnerClass]
    [Signature("Ljava/lang/Enum<Lcom/codedisaster/steamworks/SteamController$Pad;>;")]
    [Modifiers]
    [Serializable]
    public sealed class Pad : Enum
    {
      [Modifiers]
      internal static SteamController.Pad __\u003C\u003ELeft;
      [Modifiers]
      internal static SteamController.Pad __\u003C\u003ERight;
      [Modifiers]
      private static SteamController.Pad[] \u0024VALUES;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [Signature("()V")]
      [LineNumberTable(5)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private Pad([In] string obj0, [In] int obj1)
        : base(obj0, obj1)
      {
        GC.KeepAlive((object) this);
      }

      [LineNumberTable(5)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static SteamController.Pad[] values() => (SteamController.Pad[]) SteamController.Pad.\u0024VALUES.Clone();

      [LineNumberTable(5)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static SteamController.Pad valueOf(string name) => (SteamController.Pad) Enum.valueOf((Class) ClassLiteral<SteamController.Pad>.Value, name);

      [LineNumberTable(new byte[] {159, 141, 141, 112, 16})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static Pad()
      {
        if (ByteCodeHelper.isAlreadyInited("com.codedisaster.steamworks.SteamController$Pad"))
          return;
        SteamController.Pad.__\u003C\u003ELeft = new SteamController.Pad(nameof (Left), 0);
        SteamController.Pad.__\u003C\u003ERight = new SteamController.Pad(nameof (Right), 1);
        SteamController.Pad.\u0024VALUES = new SteamController.Pad[2]
        {
          SteamController.Pad.__\u003C\u003ELeft,
          SteamController.Pad.__\u003C\u003ERight
        };
      }

      [Modifiers]
      public static SteamController.Pad Left
      {
        [HideFromJava] get => SteamController.Pad.__\u003C\u003ELeft;
      }

      [Modifiers]
      public static SteamController.Pad Right
      {
        [HideFromJava] get => SteamController.Pad.__\u003C\u003ERight;
      }

      [HideFromJava]
      [Serializable]
      public enum __Enum
      {
        Left,
        Right,
      }
    }

    [InnerClass]
    [Signature("Ljava/lang/Enum<Lcom/codedisaster/steamworks/SteamController$Source;>;")]
    [Modifiers]
    [Serializable]
    public sealed class Source : Enum
    {
      [Modifiers]
      internal static SteamController.Source __\u003C\u003ENone;
      [Modifiers]
      internal static SteamController.Source __\u003C\u003ELeftTrackpad;
      [Modifiers]
      internal static SteamController.Source __\u003C\u003ERightTrackpad;
      [Modifiers]
      internal static SteamController.Source __\u003C\u003EJoystick;
      [Modifiers]
      internal static SteamController.Source __\u003C\u003EABXY;
      [Modifiers]
      internal static SteamController.Source __\u003C\u003ESwitch;
      [Modifiers]
      internal static SteamController.Source __\u003C\u003ELeftTrigger;
      [Modifiers]
      internal static SteamController.Source __\u003C\u003ERightTrigger;
      [Modifiers]
      internal static SteamController.Source __\u003C\u003EGyro;
      [Modifiers]
      internal static SteamController.Source __\u003C\u003ECenterTrackpad;
      [Modifiers]
      internal static SteamController.Source __\u003C\u003ERightJoystick;
      [Modifiers]
      internal static SteamController.Source __\u003C\u003EDPad;
      [Modifiers]
      internal static SteamController.Source __\u003C\u003EKey;
      [Modifiers]
      internal static SteamController.Source __\u003C\u003EMouse;
      [Modifiers]
      private static SteamController.Source[] \u0024VALUES;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [Signature("()V")]
      [LineNumberTable(10)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private Source([In] string obj0, [In] int obj1)
        : base(obj0, obj1)
      {
        GC.KeepAlive((object) this);
      }

      [LineNumberTable(10)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static SteamController.Source[] values() => (SteamController.Source[]) SteamController.Source.\u0024VALUES.Clone();

      [LineNumberTable(10)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static SteamController.Source valueOf(string name) => (SteamController.Source) Enum.valueOf((Class) ClassLiteral<SteamController.Source>.Value, name);

      [LineNumberTable(new byte[] {159, 140, 173, 112, 112, 112, 112, 112, 112, 112, 112, 112, 113, 113, 113, 113, 241, 50})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static Source()
      {
        if (ByteCodeHelper.isAlreadyInited("com.codedisaster.steamworks.SteamController$Source"))
          return;
        SteamController.Source.__\u003C\u003ENone = new SteamController.Source(nameof (None), 0);
        SteamController.Source.__\u003C\u003ELeftTrackpad = new SteamController.Source(nameof (LeftTrackpad), 1);
        SteamController.Source.__\u003C\u003ERightTrackpad = new SteamController.Source(nameof (RightTrackpad), 2);
        SteamController.Source.__\u003C\u003EJoystick = new SteamController.Source(nameof (Joystick), 3);
        SteamController.Source.__\u003C\u003EABXY = new SteamController.Source(nameof (ABXY), 4);
        SteamController.Source.__\u003C\u003ESwitch = new SteamController.Source(nameof (Switch), 5);
        SteamController.Source.__\u003C\u003ELeftTrigger = new SteamController.Source(nameof (LeftTrigger), 6);
        SteamController.Source.__\u003C\u003ERightTrigger = new SteamController.Source(nameof (RightTrigger), 7);
        SteamController.Source.__\u003C\u003EGyro = new SteamController.Source(nameof (Gyro), 8);
        SteamController.Source.__\u003C\u003ECenterTrackpad = new SteamController.Source(nameof (CenterTrackpad), 9);
        SteamController.Source.__\u003C\u003ERightJoystick = new SteamController.Source(nameof (RightJoystick), 10);
        SteamController.Source.__\u003C\u003EDPad = new SteamController.Source(nameof (DPad), 11);
        SteamController.Source.__\u003C\u003EKey = new SteamController.Source(nameof (Key), 12);
        SteamController.Source.__\u003C\u003EMouse = new SteamController.Source(nameof (Mouse), 13);
        SteamController.Source.\u0024VALUES = new SteamController.Source[14]
        {
          SteamController.Source.__\u003C\u003ENone,
          SteamController.Source.__\u003C\u003ELeftTrackpad,
          SteamController.Source.__\u003C\u003ERightTrackpad,
          SteamController.Source.__\u003C\u003EJoystick,
          SteamController.Source.__\u003C\u003EABXY,
          SteamController.Source.__\u003C\u003ESwitch,
          SteamController.Source.__\u003C\u003ELeftTrigger,
          SteamController.Source.__\u003C\u003ERightTrigger,
          SteamController.Source.__\u003C\u003EGyro,
          SteamController.Source.__\u003C\u003ECenterTrackpad,
          SteamController.Source.__\u003C\u003ERightJoystick,
          SteamController.Source.__\u003C\u003EDPad,
          SteamController.Source.__\u003C\u003EKey,
          SteamController.Source.__\u003C\u003EMouse
        };
      }

      [Modifiers]
      public static SteamController.Source None
      {
        [HideFromJava] get => SteamController.Source.__\u003C\u003ENone;
      }

      [Modifiers]
      public static SteamController.Source LeftTrackpad
      {
        [HideFromJava] get => SteamController.Source.__\u003C\u003ELeftTrackpad;
      }

      [Modifiers]
      public static SteamController.Source RightTrackpad
      {
        [HideFromJava] get => SteamController.Source.__\u003C\u003ERightTrackpad;
      }

      [Modifiers]
      public static SteamController.Source Joystick
      {
        [HideFromJava] get => SteamController.Source.__\u003C\u003EJoystick;
      }

      [Modifiers]
      public static SteamController.Source ABXY
      {
        [HideFromJava] get => SteamController.Source.__\u003C\u003EABXY;
      }

      [Modifiers]
      public static SteamController.Source Switch
      {
        [HideFromJava] get => SteamController.Source.__\u003C\u003ESwitch;
      }

      [Modifiers]
      public static SteamController.Source LeftTrigger
      {
        [HideFromJava] get => SteamController.Source.__\u003C\u003ELeftTrigger;
      }

      [Modifiers]
      public static SteamController.Source RightTrigger
      {
        [HideFromJava] get => SteamController.Source.__\u003C\u003ERightTrigger;
      }

      [Modifiers]
      public static SteamController.Source Gyro
      {
        [HideFromJava] get => SteamController.Source.__\u003C\u003EGyro;
      }

      [Modifiers]
      public static SteamController.Source CenterTrackpad
      {
        [HideFromJava] get => SteamController.Source.__\u003C\u003ECenterTrackpad;
      }

      [Modifiers]
      public static SteamController.Source RightJoystick
      {
        [HideFromJava] get => SteamController.Source.__\u003C\u003ERightJoystick;
      }

      [Modifiers]
      public static SteamController.Source DPad
      {
        [HideFromJava] get => SteamController.Source.__\u003C\u003EDPad;
      }

      [Modifiers]
      public static SteamController.Source Key
      {
        [HideFromJava] get => SteamController.Source.__\u003C\u003EKey;
      }

      [Modifiers]
      public static SteamController.Source Mouse
      {
        [HideFromJava] get => SteamController.Source.__\u003C\u003EMouse;
      }

      [HideFromJava]
      [Serializable]
      public enum __Enum
      {
        None,
        LeftTrackpad,
        RightTrackpad,
        Joystick,
        ABXY,
        Switch,
        LeftTrigger,
        RightTrigger,
        Gyro,
        CenterTrackpad,
        RightJoystick,
        DPad,
        Key,
        Mouse,
      }
    }

    [InnerClass]
    [Signature("Ljava/lang/Enum<Lcom/codedisaster/steamworks/SteamController$SourceMode;>;")]
    [Modifiers]
    [Serializable]
    public sealed class SourceMode : Enum
    {
      [Modifiers]
      internal static SteamController.SourceMode __\u003C\u003ENone;
      [Modifiers]
      internal static SteamController.SourceMode __\u003C\u003EDpad;
      [Modifiers]
      internal static SteamController.SourceMode __\u003C\u003EButtons;
      [Modifiers]
      internal static SteamController.SourceMode __\u003C\u003EFourButtons;
      [Modifiers]
      internal static SteamController.SourceMode __\u003C\u003EAbsoluteMouse;
      [Modifiers]
      internal static SteamController.SourceMode __\u003C\u003ERelativeMouse;
      [Modifiers]
      internal static SteamController.SourceMode __\u003C\u003EJoystickMove;
      [Modifiers]
      internal static SteamController.SourceMode __\u003C\u003EJoystickMouse;
      [Modifiers]
      internal static SteamController.SourceMode __\u003C\u003EJoystickCamera;
      [Modifiers]
      internal static SteamController.SourceMode __\u003C\u003EScrollWheel;
      [Modifiers]
      internal static SteamController.SourceMode __\u003C\u003ETrigger;
      [Modifiers]
      internal static SteamController.SourceMode __\u003C\u003ETouchMenu;
      [Modifiers]
      internal static SteamController.SourceMode __\u003C\u003EMouseJoystick;
      [Modifiers]
      internal static SteamController.SourceMode __\u003C\u003EMouseRegion;
      [Modifiers]
      internal static SteamController.SourceMode __\u003C\u003ERadialMenu;
      [Modifiers]
      internal static SteamController.SourceMode __\u003C\u003ESingleButton;
      [Modifiers]
      internal static SteamController.SourceMode __\u003C\u003ESwitches;
      [Modifiers]
      private static SteamController.SourceMode[] values;
      [Modifiers]
      private static SteamController.SourceMode[] \u0024VALUES;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [Signature("()V")]
      [LineNumberTable(27)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private SourceMode([In] string obj0, [In] int obj1)
        : base(obj0, obj1)
      {
        GC.KeepAlive((object) this);
      }

      [LineNumberTable(27)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static SteamController.SourceMode[] values() => (SteamController.SourceMode[]) SteamController.SourceMode.\u0024VALUES.Clone();

      [LineNumberTable(27)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static SteamController.SourceMode valueOf(string name) => (SteamController.SourceMode) Enum.valueOf((Class) ClassLiteral<SteamController.SourceMode>.Value, name);

      [LineNumberTable(49)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal static SteamController.SourceMode byOrdinal([In] int obj0) => SteamController.SourceMode.values[obj0];

      [LineNumberTable(new byte[] {159, 135, 77, 112, 112, 112, 112, 112, 112, 112, 112, 112, 113, 113, 113, 113, 113, 113, 113, 241, 47, 255, 125, 83})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static SourceMode()
      {
        if (ByteCodeHelper.isAlreadyInited("com.codedisaster.steamworks.SteamController$SourceMode"))
          return;
        SteamController.SourceMode.__\u003C\u003ENone = new SteamController.SourceMode(nameof (None), 0);
        SteamController.SourceMode.__\u003C\u003EDpad = new SteamController.SourceMode(nameof (Dpad), 1);
        SteamController.SourceMode.__\u003C\u003EButtons = new SteamController.SourceMode(nameof (Buttons), 2);
        SteamController.SourceMode.__\u003C\u003EFourButtons = new SteamController.SourceMode(nameof (FourButtons), 3);
        SteamController.SourceMode.__\u003C\u003EAbsoluteMouse = new SteamController.SourceMode(nameof (AbsoluteMouse), 4);
        SteamController.SourceMode.__\u003C\u003ERelativeMouse = new SteamController.SourceMode(nameof (RelativeMouse), 5);
        SteamController.SourceMode.__\u003C\u003EJoystickMove = new SteamController.SourceMode(nameof (JoystickMove), 6);
        SteamController.SourceMode.__\u003C\u003EJoystickMouse = new SteamController.SourceMode(nameof (JoystickMouse), 7);
        SteamController.SourceMode.__\u003C\u003EJoystickCamera = new SteamController.SourceMode(nameof (JoystickCamera), 8);
        SteamController.SourceMode.__\u003C\u003EScrollWheel = new SteamController.SourceMode(nameof (ScrollWheel), 9);
        SteamController.SourceMode.__\u003C\u003ETrigger = new SteamController.SourceMode(nameof (Trigger), 10);
        SteamController.SourceMode.__\u003C\u003ETouchMenu = new SteamController.SourceMode(nameof (TouchMenu), 11);
        SteamController.SourceMode.__\u003C\u003EMouseJoystick = new SteamController.SourceMode(nameof (MouseJoystick), 12);
        SteamController.SourceMode.__\u003C\u003EMouseRegion = new SteamController.SourceMode(nameof (MouseRegion), 13);
        SteamController.SourceMode.__\u003C\u003ERadialMenu = new SteamController.SourceMode(nameof (RadialMenu), 14);
        SteamController.SourceMode.__\u003C\u003ESingleButton = new SteamController.SourceMode(nameof (SingleButton), 15);
        SteamController.SourceMode.__\u003C\u003ESwitches = new SteamController.SourceMode(nameof (Switches), 16);
        SteamController.SourceMode.\u0024VALUES = new SteamController.SourceMode[17]
        {
          SteamController.SourceMode.__\u003C\u003ENone,
          SteamController.SourceMode.__\u003C\u003EDpad,
          SteamController.SourceMode.__\u003C\u003EButtons,
          SteamController.SourceMode.__\u003C\u003EFourButtons,
          SteamController.SourceMode.__\u003C\u003EAbsoluteMouse,
          SteamController.SourceMode.__\u003C\u003ERelativeMouse,
          SteamController.SourceMode.__\u003C\u003EJoystickMove,
          SteamController.SourceMode.__\u003C\u003EJoystickMouse,
          SteamController.SourceMode.__\u003C\u003EJoystickCamera,
          SteamController.SourceMode.__\u003C\u003EScrollWheel,
          SteamController.SourceMode.__\u003C\u003ETrigger,
          SteamController.SourceMode.__\u003C\u003ETouchMenu,
          SteamController.SourceMode.__\u003C\u003EMouseJoystick,
          SteamController.SourceMode.__\u003C\u003EMouseRegion,
          SteamController.SourceMode.__\u003C\u003ERadialMenu,
          SteamController.SourceMode.__\u003C\u003ESingleButton,
          SteamController.SourceMode.__\u003C\u003ESwitches
        };
        SteamController.SourceMode.values = SteamController.SourceMode.values();
      }

      [Modifiers]
      public static SteamController.SourceMode None
      {
        [HideFromJava] get => SteamController.SourceMode.__\u003C\u003ENone;
      }

      [Modifiers]
      public static SteamController.SourceMode Dpad
      {
        [HideFromJava] get => SteamController.SourceMode.__\u003C\u003EDpad;
      }

      [Modifiers]
      public static SteamController.SourceMode Buttons
      {
        [HideFromJava] get => SteamController.SourceMode.__\u003C\u003EButtons;
      }

      [Modifiers]
      public static SteamController.SourceMode FourButtons
      {
        [HideFromJava] get => SteamController.SourceMode.__\u003C\u003EFourButtons;
      }

      [Modifiers]
      public static SteamController.SourceMode AbsoluteMouse
      {
        [HideFromJava] get => SteamController.SourceMode.__\u003C\u003EAbsoluteMouse;
      }

      [Modifiers]
      public static SteamController.SourceMode RelativeMouse
      {
        [HideFromJava] get => SteamController.SourceMode.__\u003C\u003ERelativeMouse;
      }

      [Modifiers]
      public static SteamController.SourceMode JoystickMove
      {
        [HideFromJava] get => SteamController.SourceMode.__\u003C\u003EJoystickMove;
      }

      [Modifiers]
      public static SteamController.SourceMode JoystickMouse
      {
        [HideFromJava] get => SteamController.SourceMode.__\u003C\u003EJoystickMouse;
      }

      [Modifiers]
      public static SteamController.SourceMode JoystickCamera
      {
        [HideFromJava] get => SteamController.SourceMode.__\u003C\u003EJoystickCamera;
      }

      [Modifiers]
      public static SteamController.SourceMode ScrollWheel
      {
        [HideFromJava] get => SteamController.SourceMode.__\u003C\u003EScrollWheel;
      }

      [Modifiers]
      public static SteamController.SourceMode Trigger
      {
        [HideFromJava] get => SteamController.SourceMode.__\u003C\u003ETrigger;
      }

      [Modifiers]
      public static SteamController.SourceMode TouchMenu
      {
        [HideFromJava] get => SteamController.SourceMode.__\u003C\u003ETouchMenu;
      }

      [Modifiers]
      public static SteamController.SourceMode MouseJoystick
      {
        [HideFromJava] get => SteamController.SourceMode.__\u003C\u003EMouseJoystick;
      }

      [Modifiers]
      public static SteamController.SourceMode MouseRegion
      {
        [HideFromJava] get => SteamController.SourceMode.__\u003C\u003EMouseRegion;
      }

      [Modifiers]
      public static SteamController.SourceMode RadialMenu
      {
        [HideFromJava] get => SteamController.SourceMode.__\u003C\u003ERadialMenu;
      }

      [Modifiers]
      public static SteamController.SourceMode SingleButton
      {
        [HideFromJava] get => SteamController.SourceMode.__\u003C\u003ESingleButton;
      }

      [Modifiers]
      public static SteamController.SourceMode Switches
      {
        [HideFromJava] get => SteamController.SourceMode.__\u003C\u003ESwitches;
      }

      [HideFromJava]
      [Serializable]
      public enum __Enum
      {
        None,
        Dpad,
        Buttons,
        FourButtons,
        AbsoluteMouse,
        RelativeMouse,
        JoystickMove,
        JoystickMouse,
        JoystickCamera,
        ScrollWheel,
        Trigger,
        TouchMenu,
        MouseJoystick,
        MouseRegion,
        RadialMenu,
        SingleButton,
        Switches,
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
