// Decompiled with JetBrains decompiler
// Type: arc.audio.Soloud
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

namespace arc.audio
{
  public class Soloud : Object
  {
    static IntPtr __\u003Cjniptr\u003Einit\u0028\u0029V;
    [SpecialName]
    private static CallerID __\u003CcallerID\u003E;
    static IntPtr __\u003Cjniptr\u003Edeinit\u0028\u0029V;
    static IntPtr __\u003Cjniptr\u003EbackendString\u0028\u0029Ljava\u002Flang\u002FString\u003B;
    static IntPtr __\u003Cjniptr\u003EbackendId\u0028\u0029I;
    static IntPtr __\u003Cjniptr\u003EbackendChannels\u0028\u0029I;
    static IntPtr __\u003Cjniptr\u003EbackendSamplerate\u0028\u0029I;
    static IntPtr __\u003Cjniptr\u003EbackendBufferSize\u0028\u0029I;
    static IntPtr __\u003Cjniptr\u003Eversion\u0028\u0029I;
    static IntPtr __\u003Cjniptr\u003EstopAll\u0028\u0029V;
    static IntPtr __\u003Cjniptr\u003EpauseAll\u0028Z\u0029V;
    static IntPtr __\u003Cjniptr\u003EbiquadSet\u0028JIFF\u0029V;
    static IntPtr __\u003Cjniptr\u003EechoSet\u0028JFFF\u0029V;
    static IntPtr __\u003Cjniptr\u003ElofiSet\u0028JFF\u0029V;
    static IntPtr __\u003Cjniptr\u003EflangerSet\u0028JFF\u0029V;
    static IntPtr __\u003Cjniptr\u003EwaveShaperSet\u0028JF\u0029V;
    static IntPtr __\u003Cjniptr\u003EbassBoostSet\u0028JF\u0029V;
    static IntPtr __\u003Cjniptr\u003ErobotizeSet\u0028JFI\u0029V;
    static IntPtr __\u003Cjniptr\u003EfreeverbSet\u0028JFFFF\u0029V;
    static IntPtr __\u003Cjniptr\u003EfilterBiquad\u0028\u0029J;
    static IntPtr __\u003Cjniptr\u003EfilterEcho\u0028\u0029J;
    static IntPtr __\u003Cjniptr\u003EfilterLofi\u0028\u0029J;
    static IntPtr __\u003Cjniptr\u003EfilterFlanger\u0028\u0029J;
    static IntPtr __\u003Cjniptr\u003EfilterBassBoost\u0028\u0029J;
    static IntPtr __\u003Cjniptr\u003EfilterWaveShaper\u0028\u0029J;
    static IntPtr __\u003Cjniptr\u003EfilterRobotize\u0028\u0029J;
    static IntPtr __\u003Cjniptr\u003EfilterFreeverb\u0028\u0029J;
    static IntPtr __\u003Cjniptr\u003EsetGlobalFilter\u0028IJ\u0029V;
    static IntPtr __\u003Cjniptr\u003EfilterFade\u0028IIIFF\u0029V;
    static IntPtr __\u003Cjniptr\u003EfilterSet\u0028IIIF\u0029V;
    static IntPtr __\u003Cjniptr\u003EspeechNew\u0028\u0029J;
    static IntPtr __\u003Cjniptr\u003EspeechText\u0028JLjava\u002Flang\u002FString\u003B\u0029V;
    static IntPtr __\u003Cjniptr\u003EspeechParams\u0028JIFFI\u0029V;
    static IntPtr __\u003Cjniptr\u003EbusNew\u0028\u0029J;
    static IntPtr __\u003Cjniptr\u003EwavLoad\u0028\u005BBI\u0029J;
    static IntPtr __\u003Cjniptr\u003EidSeek\u0028IF\u0029V;
    static IntPtr __\u003Cjniptr\u003EidVolume\u0028IF\u0029V;
    static IntPtr __\u003Cjniptr\u003EidGetVolume\u0028I\u0029F;
    static IntPtr __\u003Cjniptr\u003EidPan\u0028IF\u0029V;
    static IntPtr __\u003Cjniptr\u003EidPitch\u0028IF\u0029V;
    static IntPtr __\u003Cjniptr\u003EidPause\u0028IZ\u0029V;
    static IntPtr __\u003Cjniptr\u003EidGetPause\u0028I\u0029Z;
    static IntPtr __\u003Cjniptr\u003EidProtected\u0028IZ\u0029V;
    static IntPtr __\u003Cjniptr\u003EidStop\u0028I\u0029V;
    static IntPtr __\u003Cjniptr\u003EidLooping\u0028IZ\u0029V;
    static IntPtr __\u003Cjniptr\u003EidGetLooping\u0028I\u0029Z;
    static IntPtr __\u003Cjniptr\u003EidPosition\u0028I\u0029F;
    static IntPtr __\u003Cjniptr\u003EidValid\u0028I\u0029Z;
    static IntPtr __\u003Cjniptr\u003EstreamLoad\u0028Ljava\u002Flang\u002FString\u003B\u0029J;
    static IntPtr __\u003Cjniptr\u003EstreamLength\u0028J\u0029D;
    static IntPtr __\u003Cjniptr\u003EsourceDestroy\u0028J\u0029V;
    static IntPtr __\u003Cjniptr\u003EsourceInaudible\u0028JZZ\u0029V;
    static IntPtr __\u003Cjniptr\u003EsourcePlay\u0028J\u0029I;
    static IntPtr __\u003Cjniptr\u003EsourceCount\u0028J\u0029I;
    static IntPtr __\u003Cjniptr\u003EsourcePlay\u0028JFFFZ\u0029I;
    static IntPtr __\u003Cjniptr\u003EsourcePlayBus\u0028JJFFFZ\u0029I;
    static IntPtr __\u003Cjniptr\u003EsourceLoop\u0028JZ\u0029V;
    static IntPtr __\u003Cjniptr\u003EsourceStop\u0028J\u0029V;
    static IntPtr __\u003Cjniptr\u003EsourceFilter\u0028JIJ\u0029V;

    [Modifiers]
    internal static long filterBiquad()
    {
      JNI.Frame frame = new JNI.Frame();
      if (Soloud.__\u003Cjniptr\u003EfilterBiquad\u0028\u0029J == IntPtr.Zero)
        Soloud.__\u003Cjniptr\u003EfilterBiquad\u0028\u0029J = JNI.Frame.GetFuncPtr(Soloud.__\u003CGetCallerID\u003E(), "arc/audio/Soloud", nameof (filterBiquad), "()J");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Soloud.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Soloud>.Value);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<long (IntPtr, IntPtr)>) Soloud.__\u003Cjniptr\u003EfilterBiquad\u0028\u0029J)(num2, num3);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    internal static void biquadSet([In] long obj0, [In] int obj1, [In] float obj2, [In] float obj3)
    {
      JNI.Frame frame = new JNI.Frame();
      if (Soloud.__\u003Cjniptr\u003EbiquadSet\u0028JIFF\u0029V == IntPtr.Zero)
        Soloud.__\u003Cjniptr\u003EbiquadSet\u0028JIFF\u0029V = JNI.Frame.GetFuncPtr(Soloud.__\u003CGetCallerID\u003E(), "arc/audio/Soloud", nameof (biquadSet), "(JIFF)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Soloud.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Soloud>.Value);
        long num4 = obj0;
        int num5 = obj1;
        double num6 = (double) obj2;
        double num7 = (double) obj3;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, long, int, float, float)>) Soloud.__\u003Cjniptr\u003EbiquadSet\u0028JIFF\u0029V)((float) num2, (float) num3, (int) num4, (long) num5, (IntPtr) num6, (IntPtr) num7);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    internal static void pauseAll([In] bool obj0)
    {
      JNI.Frame frame = new JNI.Frame();
      if (Soloud.__\u003Cjniptr\u003EpauseAll\u0028Z\u0029V == IntPtr.Zero)
        Soloud.__\u003Cjniptr\u003EpauseAll\u0028Z\u0029V = JNI.Frame.GetFuncPtr(Soloud.__\u003CGetCallerID\u003E(), "arc/audio/Soloud", nameof (pauseAll), "(Z)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Soloud.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Soloud>.Value);
        int num4 = obj0 ? 1 : 0;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, bool)>) Soloud.__\u003Cjniptr\u003EpauseAll\u0028Z\u0029V)((bool) num2, num3, (IntPtr) num4);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    internal static void init()
    {
      JNI.Frame frame = new JNI.Frame();
      if (Soloud.__\u003Cjniptr\u003Einit\u0028\u0029V == IntPtr.Zero)
        Soloud.__\u003Cjniptr\u003Einit\u0028\u0029V = JNI.Frame.GetFuncPtr(Soloud.__\u003CGetCallerID\u003E(), "arc/audio/Soloud", nameof (init), "()V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Soloud.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Soloud>.Value);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr)>) Soloud.__\u003Cjniptr\u003Einit\u0028\u0029V)(num2, num3);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    internal static int version()
    {
      JNI.Frame frame = new JNI.Frame();
      if (Soloud.__\u003Cjniptr\u003Eversion\u0028\u0029I == IntPtr.Zero)
        Soloud.__\u003Cjniptr\u003Eversion\u0028\u0029I = JNI.Frame.GetFuncPtr(Soloud.__\u003CGetCallerID\u003E(), "arc/audio/Soloud", nameof (version), "()I");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Soloud.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Soloud>.Value);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<int (IntPtr, IntPtr)>) Soloud.__\u003Cjniptr\u003Eversion\u0028\u0029I)(num2, num3);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    internal static string backendString()
    {
      JNI.Frame frame = new JNI.Frame();
      if (Soloud.__\u003Cjniptr\u003EbackendString\u0028\u0029Ljava\u002Flang\u002FString\u003B == IntPtr.Zero)
        Soloud.__\u003Cjniptr\u003EbackendString\u0028\u0029Ljava\u002Flang\u002FString\u003B = JNI.Frame.GetFuncPtr(Soloud.__\u003CGetCallerID\u003E(), "arc/audio/Soloud", nameof (backendString), "()Ljava/lang/String;");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Soloud.__\u003CGetCallerID\u003E());
      try
      {
        ref JNI.Frame local = ref frame;
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Soloud>.Value);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        IntPtr num4 = __calli((__FnPtr<IntPtr (IntPtr, IntPtr)>) Soloud.__\u003Cjniptr\u003EbackendString\u0028\u0029Ljava\u002Flang\u002FString\u003B)(num2, num3);
        return (string) ((JNI.Frame) ref local).UnwrapLocalRef(num4);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    internal static int backendSamplerate()
    {
      JNI.Frame frame = new JNI.Frame();
      if (Soloud.__\u003Cjniptr\u003EbackendSamplerate\u0028\u0029I == IntPtr.Zero)
        Soloud.__\u003Cjniptr\u003EbackendSamplerate\u0028\u0029I = JNI.Frame.GetFuncPtr(Soloud.__\u003CGetCallerID\u003E(), "arc/audio/Soloud", nameof (backendSamplerate), "()I");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Soloud.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Soloud>.Value);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<int (IntPtr, IntPtr)>) Soloud.__\u003Cjniptr\u003EbackendSamplerate\u0028\u0029I)(num2, num3);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    internal static int backendBufferSize()
    {
      JNI.Frame frame = new JNI.Frame();
      if (Soloud.__\u003Cjniptr\u003EbackendBufferSize\u0028\u0029I == IntPtr.Zero)
        Soloud.__\u003Cjniptr\u003EbackendBufferSize\u0028\u0029I = JNI.Frame.GetFuncPtr(Soloud.__\u003CGetCallerID\u003E(), "arc/audio/Soloud", nameof (backendBufferSize), "()I");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Soloud.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Soloud>.Value);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<int (IntPtr, IntPtr)>) Soloud.__\u003Cjniptr\u003EbackendBufferSize\u0028\u0029I)(num2, num3);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    internal static int backendChannels()
    {
      JNI.Frame frame = new JNI.Frame();
      if (Soloud.__\u003Cjniptr\u003EbackendChannels\u0028\u0029I == IntPtr.Zero)
        Soloud.__\u003Cjniptr\u003EbackendChannels\u0028\u0029I = JNI.Frame.GetFuncPtr(Soloud.__\u003CGetCallerID\u003E(), "arc/audio/Soloud", nameof (backendChannels), "()I");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Soloud.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Soloud>.Value);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<int (IntPtr, IntPtr)>) Soloud.__\u003Cjniptr\u003EbackendChannels\u0028\u0029I)(num2, num3);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    internal static bool idValid([In] int obj0)
    {
      JNI.Frame frame = new JNI.Frame();
      if (Soloud.__\u003Cjniptr\u003EidValid\u0028I\u0029Z == IntPtr.Zero)
        Soloud.__\u003Cjniptr\u003EidValid\u0028I\u0029Z = JNI.Frame.GetFuncPtr(Soloud.__\u003CGetCallerID\u003E(), "arc/audio/Soloud", nameof (idValid), "(I)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Soloud.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Soloud>.Value);
        int num4 = obj0;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, int)>) Soloud.__\u003Cjniptr\u003EidValid\u0028I\u0029Z)((int) num2, num3, (IntPtr) num4);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    internal static void idProtected([In] int obj0, [In] bool obj1)
    {
      JNI.Frame frame = new JNI.Frame();
      if (Soloud.__\u003Cjniptr\u003EidProtected\u0028IZ\u0029V == IntPtr.Zero)
        Soloud.__\u003Cjniptr\u003EidProtected\u0028IZ\u0029V = JNI.Frame.GetFuncPtr(Soloud.__\u003CGetCallerID\u003E(), "arc/audio/Soloud", nameof (idProtected), "(IZ)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Soloud.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Soloud>.Value);
        int num4 = obj0;
        int num5 = obj1 ? 1 : 0;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, bool)>) Soloud.__\u003Cjniptr\u003EidProtected\u0028IZ\u0029V)((bool) num2, (int) num3, (IntPtr) num4, (IntPtr) num5);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    internal static int sourcePlay([In] long obj0, [In] float obj1, [In] float obj2, [In] float obj3, [In] bool obj4)
    {
      JNI.Frame frame = new JNI.Frame();
      if (Soloud.__\u003Cjniptr\u003EsourcePlay\u0028JFFFZ\u0029I == IntPtr.Zero)
        Soloud.__\u003Cjniptr\u003EsourcePlay\u0028JFFFZ\u0029I = JNI.Frame.GetFuncPtr(Soloud.__\u003CGetCallerID\u003E(), "arc/audio/Soloud", nameof (sourcePlay), "(JFFFZ)I");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Soloud.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Soloud>.Value);
        long num4 = obj0;
        double num5 = (double) obj1;
        double num6 = (double) obj2;
        double num7 = (double) obj3;
        int num8 = obj4 ? 1 : 0;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<int (IntPtr, IntPtr, long, float, float, float, bool)>) Soloud.__\u003Cjniptr\u003EsourcePlay\u0028JFFFZ\u0029I)((bool) num2, (float) num3, (float) num4, (float) num5, (long) num6, (IntPtr) num7, (IntPtr) num8);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    internal static void sourceStop([In] long obj0)
    {
      JNI.Frame frame = new JNI.Frame();
      if (Soloud.__\u003Cjniptr\u003EsourceStop\u0028J\u0029V == IntPtr.Zero)
        Soloud.__\u003Cjniptr\u003EsourceStop\u0028J\u0029V = JNI.Frame.GetFuncPtr(Soloud.__\u003CGetCallerID\u003E(), "arc/audio/Soloud", nameof (sourceStop), "(J)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Soloud.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Soloud>.Value);
        long num4 = obj0;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, long)>) Soloud.__\u003Cjniptr\u003EsourceStop\u0028J\u0029V)((long) num2, num3, (IntPtr) num4);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    internal static void idStop([In] int obj0)
    {
      JNI.Frame frame = new JNI.Frame();
      if (Soloud.__\u003Cjniptr\u003EidStop\u0028I\u0029V == IntPtr.Zero)
        Soloud.__\u003Cjniptr\u003EidStop\u0028I\u0029V = JNI.Frame.GetFuncPtr(Soloud.__\u003CGetCallerID\u003E(), "arc/audio/Soloud", nameof (idStop), "(I)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Soloud.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Soloud>.Value);
        int num4 = obj0;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int)>) Soloud.__\u003Cjniptr\u003EidStop\u0028I\u0029V)((int) num2, num3, (IntPtr) num4);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    internal static void idPause([In] int obj0, [In] bool obj1)
    {
      JNI.Frame frame = new JNI.Frame();
      if (Soloud.__\u003Cjniptr\u003EidPause\u0028IZ\u0029V == IntPtr.Zero)
        Soloud.__\u003Cjniptr\u003EidPause\u0028IZ\u0029V = JNI.Frame.GetFuncPtr(Soloud.__\u003CGetCallerID\u003E(), "arc/audio/Soloud", nameof (idPause), "(IZ)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Soloud.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Soloud>.Value);
        int num4 = obj0;
        int num5 = obj1 ? 1 : 0;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, bool)>) Soloud.__\u003Cjniptr\u003EidPause\u0028IZ\u0029V)((bool) num2, (int) num3, (IntPtr) num4, (IntPtr) num5);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    internal static void idLooping([In] int obj0, [In] bool obj1)
    {
      JNI.Frame frame = new JNI.Frame();
      if (Soloud.__\u003Cjniptr\u003EidLooping\u0028IZ\u0029V == IntPtr.Zero)
        Soloud.__\u003Cjniptr\u003EidLooping\u0028IZ\u0029V = JNI.Frame.GetFuncPtr(Soloud.__\u003CGetCallerID\u003E(), "arc/audio/Soloud", nameof (idLooping), "(IZ)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Soloud.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Soloud>.Value);
        int num4 = obj0;
        int num5 = obj1 ? 1 : 0;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, bool)>) Soloud.__\u003Cjniptr\u003EidLooping\u0028IZ\u0029V)((bool) num2, (int) num3, (IntPtr) num4, (IntPtr) num5);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    internal static void idPitch([In] int obj0, [In] float obj1)
    {
      JNI.Frame frame = new JNI.Frame();
      if (Soloud.__\u003Cjniptr\u003EidPitch\u0028IF\u0029V == IntPtr.Zero)
        Soloud.__\u003Cjniptr\u003EidPitch\u0028IF\u0029V = JNI.Frame.GetFuncPtr(Soloud.__\u003CGetCallerID\u003E(), "arc/audio/Soloud", nameof (idPitch), "(IF)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Soloud.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Soloud>.Value);
        int num4 = obj0;
        double num5 = (double) obj1;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, float)>) Soloud.__\u003Cjniptr\u003EidPitch\u0028IF\u0029V)((float) num2, (int) num3, (IntPtr) num4, (IntPtr) num5);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    internal static void idVolume([In] int obj0, [In] float obj1)
    {
      JNI.Frame frame = new JNI.Frame();
      if (Soloud.__\u003Cjniptr\u003EidVolume\u0028IF\u0029V == IntPtr.Zero)
        Soloud.__\u003Cjniptr\u003EidVolume\u0028IF\u0029V = JNI.Frame.GetFuncPtr(Soloud.__\u003CGetCallerID\u003E(), "arc/audio/Soloud", nameof (idVolume), "(IF)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Soloud.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Soloud>.Value);
        int num4 = obj0;
        double num5 = (double) obj1;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, float)>) Soloud.__\u003Cjniptr\u003EidVolume\u0028IF\u0029V)((float) num2, (int) num3, (IntPtr) num4, (IntPtr) num5);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    internal static void idPan([In] int obj0, [In] float obj1)
    {
      JNI.Frame frame = new JNI.Frame();
      if (Soloud.__\u003Cjniptr\u003EidPan\u0028IF\u0029V == IntPtr.Zero)
        Soloud.__\u003Cjniptr\u003EidPan\u0028IF\u0029V = JNI.Frame.GetFuncPtr(Soloud.__\u003CGetCallerID\u003E(), "arc/audio/Soloud", nameof (idPan), "(IF)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Soloud.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Soloud>.Value);
        int num4 = obj0;
        double num5 = (double) obj1;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, float)>) Soloud.__\u003Cjniptr\u003EidPan\u0028IF\u0029V)((float) num2, (int) num3, (IntPtr) num4, (IntPtr) num5);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    internal static void filterFade([In] int obj0, [In] int obj1, [In] int obj2, [In] float obj3, [In] float obj4)
    {
      JNI.Frame frame = new JNI.Frame();
      if (Soloud.__\u003Cjniptr\u003EfilterFade\u0028IIIFF\u0029V == IntPtr.Zero)
        Soloud.__\u003Cjniptr\u003EfilterFade\u0028IIIFF\u0029V = JNI.Frame.GetFuncPtr(Soloud.__\u003CGetCallerID\u003E(), "arc/audio/Soloud", nameof (filterFade), "(IIIFF)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Soloud.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Soloud>.Value);
        int num4 = obj0;
        int num5 = obj1;
        int num6 = obj2;
        double num7 = (double) obj3;
        double num8 = (double) obj4;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, int, int, float, float)>) Soloud.__\u003Cjniptr\u003EfilterFade\u0028IIIFF\u0029V)((float) num2, (float) num3, num4, num5, num6, (IntPtr) num7, (IntPtr) num8);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    internal static void filterSet([In] int obj0, [In] int obj1, [In] int obj2, [In] float obj3)
    {
      JNI.Frame frame = new JNI.Frame();
      if (Soloud.__\u003Cjniptr\u003EfilterSet\u0028IIIF\u0029V == IntPtr.Zero)
        Soloud.__\u003Cjniptr\u003EfilterSet\u0028IIIF\u0029V = JNI.Frame.GetFuncPtr(Soloud.__\u003CGetCallerID\u003E(), "arc/audio/Soloud", nameof (filterSet), "(IIIF)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Soloud.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Soloud>.Value);
        int num4 = obj0;
        int num5 = obj1;
        int num6 = obj2;
        double num7 = (double) obj3;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, int, int, float)>) Soloud.__\u003Cjniptr\u003EfilterSet\u0028IIIF\u0029V)((float) num2, (int) num3, num4, num5, (IntPtr) num6, (IntPtr) num7);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    internal static void setGlobalFilter([In] int obj0, [In] long obj1)
    {
      JNI.Frame frame = new JNI.Frame();
      if (Soloud.__\u003Cjniptr\u003EsetGlobalFilter\u0028IJ\u0029V == IntPtr.Zero)
        Soloud.__\u003Cjniptr\u003EsetGlobalFilter\u0028IJ\u0029V = JNI.Frame.GetFuncPtr(Soloud.__\u003CGetCallerID\u003E(), "arc/audio/Soloud", nameof (setGlobalFilter), "(IJ)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Soloud.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Soloud>.Value);
        int num4 = obj0;
        long num5 = obj1;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, long)>) Soloud.__\u003Cjniptr\u003EsetGlobalFilter\u0028IJ\u0029V)((long) num2, (int) num3, (IntPtr) num4, (IntPtr) num5);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    internal static void stopAll()
    {
      JNI.Frame frame = new JNI.Frame();
      if (Soloud.__\u003Cjniptr\u003EstopAll\u0028\u0029V == IntPtr.Zero)
        Soloud.__\u003Cjniptr\u003EstopAll\u0028\u0029V = JNI.Frame.GetFuncPtr(Soloud.__\u003CGetCallerID\u003E(), "arc/audio/Soloud", nameof (stopAll), "()V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Soloud.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Soloud>.Value);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr)>) Soloud.__\u003Cjniptr\u003EstopAll\u0028\u0029V)(num2, num3);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    internal static void deinit()
    {
      JNI.Frame frame = new JNI.Frame();
      if (Soloud.__\u003Cjniptr\u003Edeinit\u0028\u0029V == IntPtr.Zero)
        Soloud.__\u003Cjniptr\u003Edeinit\u0028\u0029V = JNI.Frame.GetFuncPtr(Soloud.__\u003CGetCallerID\u003E(), "arc/audio/Soloud", nameof (deinit), "()V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Soloud.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Soloud>.Value);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr)>) Soloud.__\u003Cjniptr\u003Edeinit\u0028\u0029V)(num2, num3);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    internal static void sourceFilter([In] long obj0, [In] int obj1, [In] long obj2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (Soloud.__\u003Cjniptr\u003EsourceFilter\u0028JIJ\u0029V == IntPtr.Zero)
        Soloud.__\u003Cjniptr\u003EsourceFilter\u0028JIJ\u0029V = JNI.Frame.GetFuncPtr(Soloud.__\u003CGetCallerID\u003E(), "arc/audio/Soloud", nameof (sourceFilter), "(JIJ)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Soloud.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Soloud>.Value);
        long num4 = obj0;
        int num5 = obj1;
        long num6 = obj2;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, long, int, long)>) Soloud.__\u003Cjniptr\u003EsourceFilter\u0028JIJ\u0029V)((long) num2, (int) num3, num4, (IntPtr) num5, (IntPtr) num6);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    internal static long busNew()
    {
      JNI.Frame frame = new JNI.Frame();
      if (Soloud.__\u003Cjniptr\u003EbusNew\u0028\u0029J == IntPtr.Zero)
        Soloud.__\u003Cjniptr\u003EbusNew\u0028\u0029J = JNI.Frame.GetFuncPtr(Soloud.__\u003CGetCallerID\u003E(), "arc/audio/Soloud", nameof (busNew), "()J");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Soloud.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Soloud>.Value);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<long (IntPtr, IntPtr)>) Soloud.__\u003Cjniptr\u003EbusNew\u0028\u0029J)(num2, num3);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    internal static int sourcePlay([In] long obj0)
    {
      JNI.Frame frame = new JNI.Frame();
      if (Soloud.__\u003Cjniptr\u003EsourcePlay\u0028J\u0029I == IntPtr.Zero)
        Soloud.__\u003Cjniptr\u003EsourcePlay\u0028J\u0029I = JNI.Frame.GetFuncPtr(Soloud.__\u003CGetCallerID\u003E(), "arc/audio/Soloud", nameof (sourcePlay), "(J)I");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Soloud.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Soloud>.Value);
        long num4 = obj0;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<int (IntPtr, IntPtr, long)>) Soloud.__\u003Cjniptr\u003EsourcePlay\u0028J\u0029I)((long) num2, num3, (IntPtr) num4);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    internal static long filterBassBoost()
    {
      JNI.Frame frame = new JNI.Frame();
      if (Soloud.__\u003Cjniptr\u003EfilterBassBoost\u0028\u0029J == IntPtr.Zero)
        Soloud.__\u003Cjniptr\u003EfilterBassBoost\u0028\u0029J = JNI.Frame.GetFuncPtr(Soloud.__\u003CGetCallerID\u003E(), "arc/audio/Soloud", nameof (filterBassBoost), "()J");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Soloud.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Soloud>.Value);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<long (IntPtr, IntPtr)>) Soloud.__\u003Cjniptr\u003EfilterBassBoost\u0028\u0029J)(num2, num3);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    internal static void bassBoostSet([In] long obj0, [In] float obj1)
    {
      JNI.Frame frame = new JNI.Frame();
      if (Soloud.__\u003Cjniptr\u003EbassBoostSet\u0028JF\u0029V == IntPtr.Zero)
        Soloud.__\u003Cjniptr\u003EbassBoostSet\u0028JF\u0029V = JNI.Frame.GetFuncPtr(Soloud.__\u003CGetCallerID\u003E(), "arc/audio/Soloud", nameof (bassBoostSet), "(JF)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Soloud.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Soloud>.Value);
        long num4 = obj0;
        double num5 = (double) obj1;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, long, float)>) Soloud.__\u003Cjniptr\u003EbassBoostSet\u0028JF\u0029V)((float) num2, (long) num3, (IntPtr) num4, (IntPtr) num5);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    internal static long filterEcho()
    {
      JNI.Frame frame = new JNI.Frame();
      if (Soloud.__\u003Cjniptr\u003EfilterEcho\u0028\u0029J == IntPtr.Zero)
        Soloud.__\u003Cjniptr\u003EfilterEcho\u0028\u0029J = JNI.Frame.GetFuncPtr(Soloud.__\u003CGetCallerID\u003E(), "arc/audio/Soloud", nameof (filterEcho), "()J");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Soloud.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Soloud>.Value);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<long (IntPtr, IntPtr)>) Soloud.__\u003Cjniptr\u003EfilterEcho\u0028\u0029J)(num2, num3);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    internal static void echoSet([In] long obj0, [In] float obj1, [In] float obj2, [In] float obj3)
    {
      JNI.Frame frame = new JNI.Frame();
      if (Soloud.__\u003Cjniptr\u003EechoSet\u0028JFFF\u0029V == IntPtr.Zero)
        Soloud.__\u003Cjniptr\u003EechoSet\u0028JFFF\u0029V = JNI.Frame.GetFuncPtr(Soloud.__\u003CGetCallerID\u003E(), "arc/audio/Soloud", nameof (echoSet), "(JFFF)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Soloud.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Soloud>.Value);
        long num4 = obj0;
        double num5 = (double) obj1;
        double num6 = (double) obj2;
        double num7 = (double) obj3;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, long, float, float, float)>) Soloud.__\u003Cjniptr\u003EechoSet\u0028JFFF\u0029V)((float) num2, (float) num3, (float) num4, (long) num5, (IntPtr) num6, (IntPtr) num7);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    internal static long filterFlanger()
    {
      JNI.Frame frame = new JNI.Frame();
      if (Soloud.__\u003Cjniptr\u003EfilterFlanger\u0028\u0029J == IntPtr.Zero)
        Soloud.__\u003Cjniptr\u003EfilterFlanger\u0028\u0029J = JNI.Frame.GetFuncPtr(Soloud.__\u003CGetCallerID\u003E(), "arc/audio/Soloud", nameof (filterFlanger), "()J");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Soloud.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Soloud>.Value);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<long (IntPtr, IntPtr)>) Soloud.__\u003Cjniptr\u003EfilterFlanger\u0028\u0029J)(num2, num3);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    internal static void flangerSet([In] long obj0, [In] float obj1, [In] float obj2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (Soloud.__\u003Cjniptr\u003EflangerSet\u0028JFF\u0029V == IntPtr.Zero)
        Soloud.__\u003Cjniptr\u003EflangerSet\u0028JFF\u0029V = JNI.Frame.GetFuncPtr(Soloud.__\u003CGetCallerID\u003E(), "arc/audio/Soloud", nameof (flangerSet), "(JFF)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Soloud.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Soloud>.Value);
        long num4 = obj0;
        double num5 = (double) obj1;
        double num6 = (double) obj2;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, long, float, float)>) Soloud.__\u003Cjniptr\u003EflangerSet\u0028JFF\u0029V)((float) num2, (float) num3, num4, (IntPtr) num5, (IntPtr) num6);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    internal static long filterFreeverb()
    {
      JNI.Frame frame = new JNI.Frame();
      if (Soloud.__\u003Cjniptr\u003EfilterFreeverb\u0028\u0029J == IntPtr.Zero)
        Soloud.__\u003Cjniptr\u003EfilterFreeverb\u0028\u0029J = JNI.Frame.GetFuncPtr(Soloud.__\u003CGetCallerID\u003E(), "arc/audio/Soloud", nameof (filterFreeverb), "()J");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Soloud.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Soloud>.Value);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<long (IntPtr, IntPtr)>) Soloud.__\u003Cjniptr\u003EfilterFreeverb\u0028\u0029J)(num2, num3);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    internal static void freeverbSet([In] long obj0, [In] float obj1, [In] float obj2, [In] float obj3, [In] float obj4)
    {
      JNI.Frame frame = new JNI.Frame();
      if (Soloud.__\u003Cjniptr\u003EfreeverbSet\u0028JFFFF\u0029V == IntPtr.Zero)
        Soloud.__\u003Cjniptr\u003EfreeverbSet\u0028JFFFF\u0029V = JNI.Frame.GetFuncPtr(Soloud.__\u003CGetCallerID\u003E(), "arc/audio/Soloud", nameof (freeverbSet), "(JFFFF)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Soloud.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Soloud>.Value);
        long num4 = obj0;
        double num5 = (double) obj1;
        double num6 = (double) obj2;
        double num7 = (double) obj3;
        double num8 = (double) obj4;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, long, float, float, float, float)>) Soloud.__\u003Cjniptr\u003EfreeverbSet\u0028JFFFF\u0029V)((float) num2, (float) num3, (float) num4, (float) num5, (long) num6, (IntPtr) num7, (IntPtr) num8);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    internal static long filterLofi()
    {
      JNI.Frame frame = new JNI.Frame();
      if (Soloud.__\u003Cjniptr\u003EfilterLofi\u0028\u0029J == IntPtr.Zero)
        Soloud.__\u003Cjniptr\u003EfilterLofi\u0028\u0029J = JNI.Frame.GetFuncPtr(Soloud.__\u003CGetCallerID\u003E(), "arc/audio/Soloud", nameof (filterLofi), "()J");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Soloud.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Soloud>.Value);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<long (IntPtr, IntPtr)>) Soloud.__\u003Cjniptr\u003EfilterLofi\u0028\u0029J)(num2, num3);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    internal static void lofiSet([In] long obj0, [In] float obj1, [In] float obj2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (Soloud.__\u003Cjniptr\u003ElofiSet\u0028JFF\u0029V == IntPtr.Zero)
        Soloud.__\u003Cjniptr\u003ElofiSet\u0028JFF\u0029V = JNI.Frame.GetFuncPtr(Soloud.__\u003CGetCallerID\u003E(), "arc/audio/Soloud", nameof (lofiSet), "(JFF)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Soloud.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Soloud>.Value);
        long num4 = obj0;
        double num5 = (double) obj1;
        double num6 = (double) obj2;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, long, float, float)>) Soloud.__\u003Cjniptr\u003ElofiSet\u0028JFF\u0029V)((float) num2, (float) num3, num4, (IntPtr) num5, (IntPtr) num6);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    internal static long filterRobotize()
    {
      JNI.Frame frame = new JNI.Frame();
      if (Soloud.__\u003Cjniptr\u003EfilterRobotize\u0028\u0029J == IntPtr.Zero)
        Soloud.__\u003Cjniptr\u003EfilterRobotize\u0028\u0029J = JNI.Frame.GetFuncPtr(Soloud.__\u003CGetCallerID\u003E(), "arc/audio/Soloud", nameof (filterRobotize), "()J");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Soloud.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Soloud>.Value);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<long (IntPtr, IntPtr)>) Soloud.__\u003Cjniptr\u003EfilterRobotize\u0028\u0029J)(num2, num3);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    internal static void robotizeSet([In] long obj0, [In] float obj1, [In] int obj2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (Soloud.__\u003Cjniptr\u003ErobotizeSet\u0028JFI\u0029V == IntPtr.Zero)
        Soloud.__\u003Cjniptr\u003ErobotizeSet\u0028JFI\u0029V = JNI.Frame.GetFuncPtr(Soloud.__\u003CGetCallerID\u003E(), "arc/audio/Soloud", nameof (robotizeSet), "(JFI)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Soloud.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Soloud>.Value);
        long num4 = obj0;
        double num5 = (double) obj1;
        int num6 = obj2;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, long, float, int)>) Soloud.__\u003Cjniptr\u003ErobotizeSet\u0028JFI\u0029V)((int) num2, (float) num3, num4, (IntPtr) num5, (IntPtr) num6);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    internal static long filterWaveShaper()
    {
      JNI.Frame frame = new JNI.Frame();
      if (Soloud.__\u003Cjniptr\u003EfilterWaveShaper\u0028\u0029J == IntPtr.Zero)
        Soloud.__\u003Cjniptr\u003EfilterWaveShaper\u0028\u0029J = JNI.Frame.GetFuncPtr(Soloud.__\u003CGetCallerID\u003E(), "arc/audio/Soloud", nameof (filterWaveShaper), "()J");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Soloud.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Soloud>.Value);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<long (IntPtr, IntPtr)>) Soloud.__\u003Cjniptr\u003EfilterWaveShaper\u0028\u0029J)(num2, num3);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    internal static void waveShaperSet([In] long obj0, [In] float obj1)
    {
      JNI.Frame frame = new JNI.Frame();
      if (Soloud.__\u003Cjniptr\u003EwaveShaperSet\u0028JF\u0029V == IntPtr.Zero)
        Soloud.__\u003Cjniptr\u003EwaveShaperSet\u0028JF\u0029V = JNI.Frame.GetFuncPtr(Soloud.__\u003CGetCallerID\u003E(), "arc/audio/Soloud", nameof (waveShaperSet), "(JF)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Soloud.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Soloud>.Value);
        long num4 = obj0;
        double num5 = (double) obj1;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, long, float)>) Soloud.__\u003Cjniptr\u003EwaveShaperSet\u0028JF\u0029V)((float) num2, (long) num3, (IntPtr) num4, (IntPtr) num5);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    internal static long streamLoad([In] string obj0)
    {
      JNI.Frame frame = new JNI.Frame();
      if (Soloud.__\u003Cjniptr\u003EstreamLoad\u0028Ljava\u002Flang\u002FString\u003B\u0029J == IntPtr.Zero)
        Soloud.__\u003Cjniptr\u003EstreamLoad\u0028Ljava\u002Flang\u002FString\u003B\u0029J = JNI.Frame.GetFuncPtr(Soloud.__\u003CGetCallerID\u003E(), "arc/audio/Soloud", nameof (streamLoad), "(Ljava/lang/String;)J");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Soloud.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Soloud>.Value);
        IntPtr num4 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj0);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<long (IntPtr, IntPtr, IntPtr)>) Soloud.__\u003Cjniptr\u003EstreamLoad\u0028Ljava\u002Flang\u002FString\u003B\u0029J)(num2, num3, num4);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    internal static bool idGetPause([In] int obj0)
    {
      JNI.Frame frame = new JNI.Frame();
      if (Soloud.__\u003Cjniptr\u003EidGetPause\u0028I\u0029Z == IntPtr.Zero)
        Soloud.__\u003Cjniptr\u003EidGetPause\u0028I\u0029Z = JNI.Frame.GetFuncPtr(Soloud.__\u003CGetCallerID\u003E(), "arc/audio/Soloud", nameof (idGetPause), "(I)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Soloud.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Soloud>.Value);
        int num4 = obj0;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, int)>) Soloud.__\u003Cjniptr\u003EidGetPause\u0028I\u0029Z)((int) num2, num3, (IntPtr) num4);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    internal static int sourcePlayBus(
      [In] long obj0,
      [In] long obj1,
      [In] float obj2,
      [In] float obj3,
      [In] float obj4,
      [In] bool obj5)
    {
      JNI.Frame frame = new JNI.Frame();
      if (Soloud.__\u003Cjniptr\u003EsourcePlayBus\u0028JJFFFZ\u0029I == IntPtr.Zero)
        Soloud.__\u003Cjniptr\u003EsourcePlayBus\u0028JJFFFZ\u0029I = JNI.Frame.GetFuncPtr(Soloud.__\u003CGetCallerID\u003E(), "arc/audio/Soloud", nameof (sourcePlayBus), "(JJFFFZ)I");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Soloud.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Soloud>.Value);
        long num4 = obj0;
        long num5 = obj1;
        double num6 = (double) obj2;
        double num7 = (double) obj3;
        double num8 = (double) obj4;
        int num9 = obj5 ? 1 : 0;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<int (IntPtr, IntPtr, long, long, float, float, float, bool)>) Soloud.__\u003Cjniptr\u003EsourcePlayBus\u0028JJFFFZ\u0029I)((bool) num2, (float) num3, (float) num4, (float) num5, (long) num6, (long) num7, (IntPtr) num8, (IntPtr) num9);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    internal static float idPosition([In] int obj0)
    {
      JNI.Frame frame = new JNI.Frame();
      if (Soloud.__\u003Cjniptr\u003EidPosition\u0028I\u0029F == IntPtr.Zero)
        Soloud.__\u003Cjniptr\u003EidPosition\u0028I\u0029F = JNI.Frame.GetFuncPtr(Soloud.__\u003CGetCallerID\u003E(), "arc/audio/Soloud", nameof (idPosition), "(I)F");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Soloud.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Soloud>.Value);
        int num4 = obj0;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<float (IntPtr, IntPtr, int)>) Soloud.__\u003Cjniptr\u003EidPosition\u0028I\u0029F)((int) num2, num3, (IntPtr) num4);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    internal static void idSeek([In] int obj0, [In] float obj1)
    {
      JNI.Frame frame = new JNI.Frame();
      if (Soloud.__\u003Cjniptr\u003EidSeek\u0028IF\u0029V == IntPtr.Zero)
        Soloud.__\u003Cjniptr\u003EidSeek\u0028IF\u0029V = JNI.Frame.GetFuncPtr(Soloud.__\u003CGetCallerID\u003E(), "arc/audio/Soloud", nameof (idSeek), "(IF)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Soloud.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Soloud>.Value);
        int num4 = obj0;
        double num5 = (double) obj1;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, float)>) Soloud.__\u003Cjniptr\u003EidSeek\u0028IF\u0029V)((float) num2, (int) num3, (IntPtr) num4, (IntPtr) num5);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [LineNumberTable(4)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Soloud()
    {
    }

    [Modifiers]
    internal static int backendId()
    {
      JNI.Frame frame = new JNI.Frame();
      if (Soloud.__\u003Cjniptr\u003EbackendId\u0028\u0029I == IntPtr.Zero)
        Soloud.__\u003Cjniptr\u003EbackendId\u0028\u0029I = JNI.Frame.GetFuncPtr(Soloud.__\u003CGetCallerID\u003E(), "arc/audio/Soloud", nameof (backendId), "()I");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Soloud.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Soloud>.Value);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<int (IntPtr, IntPtr)>) Soloud.__\u003Cjniptr\u003EbackendId\u0028\u0029I)(num2, num3);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    internal static long speechNew()
    {
      JNI.Frame frame = new JNI.Frame();
      if (Soloud.__\u003Cjniptr\u003EspeechNew\u0028\u0029J == IntPtr.Zero)
        Soloud.__\u003Cjniptr\u003EspeechNew\u0028\u0029J = JNI.Frame.GetFuncPtr(Soloud.__\u003CGetCallerID\u003E(), "arc/audio/Soloud", nameof (speechNew), "()J");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Soloud.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Soloud>.Value);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<long (IntPtr, IntPtr)>) Soloud.__\u003Cjniptr\u003EspeechNew\u0028\u0029J)(num2, num3);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    internal static void speechText([In] long obj0, [In] string obj1)
    {
      JNI.Frame frame = new JNI.Frame();
      if (Soloud.__\u003Cjniptr\u003EspeechText\u0028JLjava\u002Flang\u002FString\u003B\u0029V == IntPtr.Zero)
        Soloud.__\u003Cjniptr\u003EspeechText\u0028JLjava\u002Flang\u002FString\u003B\u0029V = JNI.Frame.GetFuncPtr(Soloud.__\u003CGetCallerID\u003E(), "arc/audio/Soloud", nameof (speechText), "(JLjava/lang/String;)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Soloud.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Soloud>.Value);
        long num4 = obj0;
        IntPtr num5 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj1);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, long, IntPtr)>) Soloud.__\u003Cjniptr\u003EspeechText\u0028JLjava\u002Flang\u002FString\u003B\u0029V)(num2, (long) num3, (IntPtr) num4, num5);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    internal static void speechParams([In] long obj0, [In] int obj1, [In] float obj2, [In] float obj3, [In] int obj4)
    {
      JNI.Frame frame = new JNI.Frame();
      if (Soloud.__\u003Cjniptr\u003EspeechParams\u0028JIFFI\u0029V == IntPtr.Zero)
        Soloud.__\u003Cjniptr\u003EspeechParams\u0028JIFFI\u0029V = JNI.Frame.GetFuncPtr(Soloud.__\u003CGetCallerID\u003E(), "arc/audio/Soloud", nameof (speechParams), "(JIFFI)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Soloud.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Soloud>.Value);
        long num4 = obj0;
        int num5 = obj1;
        double num6 = (double) obj2;
        double num7 = (double) obj3;
        int num8 = obj4;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, long, int, float, float, int)>) Soloud.__\u003Cjniptr\u003EspeechParams\u0028JIFFI\u0029V)((int) num2, (float) num3, (float) num4, num5, (long) num6, (IntPtr) num7, (IntPtr) num8);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    internal static long wavLoad([In] byte[] obj0, [In] int obj1)
    {
      JNI.Frame frame = new JNI.Frame();
      if (Soloud.__\u003Cjniptr\u003EwavLoad\u0028\u005BBI\u0029J == IntPtr.Zero)
        Soloud.__\u003Cjniptr\u003EwavLoad\u0028\u005BBI\u0029J = JNI.Frame.GetFuncPtr(Soloud.__\u003CGetCallerID\u003E(), "arc/audio/Soloud", nameof (wavLoad), "([BI)J");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Soloud.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Soloud>.Value);
        IntPtr num4 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj0);
        int num5 = obj1;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<long (IntPtr, IntPtr, IntPtr, int)>) Soloud.__\u003Cjniptr\u003EwavLoad\u0028\u005BBI\u0029J)((int) num2, num3, num4, (IntPtr) num5);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    internal static float idGetVolume([In] int obj0)
    {
      JNI.Frame frame = new JNI.Frame();
      if (Soloud.__\u003Cjniptr\u003EidGetVolume\u0028I\u0029F == IntPtr.Zero)
        Soloud.__\u003Cjniptr\u003EidGetVolume\u0028I\u0029F = JNI.Frame.GetFuncPtr(Soloud.__\u003CGetCallerID\u003E(), "arc/audio/Soloud", nameof (idGetVolume), "(I)F");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Soloud.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Soloud>.Value);
        int num4 = obj0;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<float (IntPtr, IntPtr, int)>) Soloud.__\u003Cjniptr\u003EidGetVolume\u0028I\u0029F)((int) num2, num3, (IntPtr) num4);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    internal static bool idGetLooping([In] int obj0)
    {
      JNI.Frame frame = new JNI.Frame();
      if (Soloud.__\u003Cjniptr\u003EidGetLooping\u0028I\u0029Z == IntPtr.Zero)
        Soloud.__\u003Cjniptr\u003EidGetLooping\u0028I\u0029Z = JNI.Frame.GetFuncPtr(Soloud.__\u003CGetCallerID\u003E(), "arc/audio/Soloud", nameof (idGetLooping), "(I)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Soloud.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Soloud>.Value);
        int num4 = obj0;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, int)>) Soloud.__\u003Cjniptr\u003EidGetLooping\u0028I\u0029Z)((int) num2, num3, (IntPtr) num4);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    internal static double streamLength([In] long obj0)
    {
      JNI.Frame frame = new JNI.Frame();
      if (Soloud.__\u003Cjniptr\u003EstreamLength\u0028J\u0029D == IntPtr.Zero)
        Soloud.__\u003Cjniptr\u003EstreamLength\u0028J\u0029D = JNI.Frame.GetFuncPtr(Soloud.__\u003CGetCallerID\u003E(), "arc/audio/Soloud", nameof (streamLength), "(J)D");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Soloud.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Soloud>.Value);
        long num4 = obj0;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<double (IntPtr, IntPtr, long)>) Soloud.__\u003Cjniptr\u003EstreamLength\u0028J\u0029D)((long) num2, num3, (IntPtr) num4);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    internal static void sourceDestroy([In] long obj0)
    {
      JNI.Frame frame = new JNI.Frame();
      if (Soloud.__\u003Cjniptr\u003EsourceDestroy\u0028J\u0029V == IntPtr.Zero)
        Soloud.__\u003Cjniptr\u003EsourceDestroy\u0028J\u0029V = JNI.Frame.GetFuncPtr(Soloud.__\u003CGetCallerID\u003E(), "arc/audio/Soloud", nameof (sourceDestroy), "(J)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Soloud.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Soloud>.Value);
        long num4 = obj0;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, long)>) Soloud.__\u003Cjniptr\u003EsourceDestroy\u0028J\u0029V)((long) num2, num3, (IntPtr) num4);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    internal static void sourceInaudible([In] long obj0, [In] bool obj1, [In] bool obj2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (Soloud.__\u003Cjniptr\u003EsourceInaudible\u0028JZZ\u0029V == IntPtr.Zero)
        Soloud.__\u003Cjniptr\u003EsourceInaudible\u0028JZZ\u0029V = JNI.Frame.GetFuncPtr(Soloud.__\u003CGetCallerID\u003E(), "arc/audio/Soloud", nameof (sourceInaudible), "(JZZ)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Soloud.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Soloud>.Value);
        long num4 = obj0;
        int num5 = obj1 ? 1 : 0;
        int num6 = obj2 ? 1 : 0;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, long, bool, bool)>) Soloud.__\u003Cjniptr\u003EsourceInaudible\u0028JZZ\u0029V)((bool) num2, (bool) num3, num4, (IntPtr) num5, (IntPtr) num6);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    internal static int sourceCount([In] long obj0)
    {
      JNI.Frame frame = new JNI.Frame();
      if (Soloud.__\u003Cjniptr\u003EsourceCount\u0028J\u0029I == IntPtr.Zero)
        Soloud.__\u003Cjniptr\u003EsourceCount\u0028J\u0029I = JNI.Frame.GetFuncPtr(Soloud.__\u003CGetCallerID\u003E(), "arc/audio/Soloud", nameof (sourceCount), "(J)I");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Soloud.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Soloud>.Value);
        long num4 = obj0;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<int (IntPtr, IntPtr, long)>) Soloud.__\u003Cjniptr\u003EsourceCount\u0028J\u0029I)((long) num2, num3, (IntPtr) num4);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    internal static void sourceLoop([In] long obj0, [In] bool obj1)
    {
      JNI.Frame frame = new JNI.Frame();
      if (Soloud.__\u003Cjniptr\u003EsourceLoop\u0028JZ\u0029V == IntPtr.Zero)
        Soloud.__\u003Cjniptr\u003EsourceLoop\u0028JZ\u0029V = JNI.Frame.GetFuncPtr(Soloud.__\u003CGetCallerID\u003E(), "arc/audio/Soloud", nameof (sourceLoop), "(JZ)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Soloud.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Soloud>.Value);
        long num4 = obj0;
        int num5 = obj1 ? 1 : 0;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, long, bool)>) Soloud.__\u003Cjniptr\u003EsourceLoop\u0028JZ\u0029V)((bool) num2, (long) num3, (IntPtr) num4, (IntPtr) num5);
      }
      catch (object ex)
      {
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
      if (Soloud.__\u003CcallerID\u003E == null)
        Soloud.__\u003CcallerID\u003E = (CallerID) new Soloud.__\u003CCallerID\u003E();
      return Soloud.__\u003CcallerID\u003E;
    }

    private sealed class __\u003CCallerID\u003E : CallerID
    {
      internal __\u003CCallerID\u003E()
      {
      }
    }
  }
}
