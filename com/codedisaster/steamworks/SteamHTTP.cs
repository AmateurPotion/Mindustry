// Decompiled with JetBrains decompiler
// Type: com.codedisaster.steamworks.SteamHTTP
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
  public class SteamHTTP : SteamInterface
  {
    static IntPtr __\u003Cjniptr\u003EcreateCallback\u0028Lcom\u002Fcodedisaster\u002Fsteamworks\u002FSteamHTTPCallbackAdapter\u003B\u0029J;
    [SpecialName]
    private static CallerID __\u003CcallerID\u003E;
    static IntPtr __\u003Cjniptr\u003EcreateHTTPRequest\u0028JILjava\u002Flang\u002FString\u003B\u0029J;
    static IntPtr __\u003Cjniptr\u003EsetHTTPRequestContextValue\u0028JJJ\u0029Z;
    static IntPtr __\u003Cjniptr\u003EsetHTTPRequestNetworkActivityTimeout\u0028JJI\u0029Z;
    static IntPtr __\u003Cjniptr\u003EsetHTTPRequestHeaderValue\u0028JJLjava\u002Flang\u002FString\u003BLjava\u002Flang\u002FString\u003B\u0029Z;
    static IntPtr __\u003Cjniptr\u003EsetHTTPRequestGetOrPostParameter\u0028JJLjava\u002Flang\u002FString\u003BLjava\u002Flang\u002FString\u003B\u0029Z;
    static IntPtr __\u003Cjniptr\u003EsendHTTPRequest\u0028JJJ\u0029J;
    static IntPtr __\u003Cjniptr\u003EsendHTTPRequestAndStreamResponse\u0028JJ\u0029J;
    static IntPtr __\u003Cjniptr\u003EgetHTTPResponseHeaderSize\u0028JJLjava\u002Flang\u002FString\u003B\u0029I;
    static IntPtr __\u003Cjniptr\u003EgetHTTPResponseHeaderValue\u0028JJLjava\u002Flang\u002FString\u003BLjava\u002Fnio\u002FByteBuffer\u003BII\u0029Z;
    static IntPtr __\u003Cjniptr\u003EgetHTTPResponseBodySize\u0028JJ\u0029I;
    static IntPtr __\u003Cjniptr\u003EgetHTTPResponseBodyData\u0028JJLjava\u002Fnio\u002FByteBuffer\u003BII\u0029Z;
    static IntPtr __\u003Cjniptr\u003EgetHTTPStreamingResponseBodyData\u0028JJILjava\u002Fnio\u002FByteBuffer\u003BII\u0029Z;
    static IntPtr __\u003Cjniptr\u003EreleaseHTTPRequest\u0028JJ\u0029Z;

    [Modifiers]
    private static long createCallback([In] SteamHTTPCallbackAdapter obj0)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamHTTP.__\u003Cjniptr\u003EcreateCallback\u0028Lcom\u002Fcodedisaster\u002Fsteamworks\u002FSteamHTTPCallbackAdapter\u003B\u0029J == IntPtr.Zero)
        SteamHTTP.__\u003Cjniptr\u003EcreateCallback\u0028Lcom\u002Fcodedisaster\u002Fsteamworks\u002FSteamHTTPCallbackAdapter\u003B\u0029J = JNI.Frame.GetFuncPtr(SteamHTTP.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamHTTP", nameof (createCallback), "(Lcom/codedisaster/steamworks/SteamHTTPCallbackAdapter;)J");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamHTTP.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamHTTP>.Value);
        IntPtr num4 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj0);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<long (IntPtr, IntPtr, IntPtr)>) SteamHTTP.__\u003Cjniptr\u003EcreateCallback\u0028Lcom\u002Fcodedisaster\u002Fsteamworks\u002FSteamHTTPCallbackAdapter\u003B\u0029J)(num2, num3, num4);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [LineNumberTable(new byte[] {60, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal SteamHTTP([In] long obj0, [In] long obj1)
      : base(obj0, obj1)
    {
    }

    [Modifiers]
    private static long createHTTPRequest([In] long obj0, [In] int obj1, [In] string obj2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamHTTP.__\u003Cjniptr\u003EcreateHTTPRequest\u0028JILjava\u002Flang\u002FString\u003B\u0029J == IntPtr.Zero)
        SteamHTTP.__\u003Cjniptr\u003EcreateHTTPRequest\u0028JILjava\u002Flang\u002FString\u003B\u0029J = JNI.Frame.GetFuncPtr(SteamHTTP.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamHTTP", nameof (createHTTPRequest), "(JILjava/lang/String;)J");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamHTTP.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamHTTP>.Value);
        long num4 = obj0;
        int num5 = obj1;
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj2);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<long (IntPtr, IntPtr, long, int, IntPtr)>) SteamHTTP.__\u003Cjniptr\u003EcreateHTTPRequest\u0028JILjava\u002Flang\u002FString\u003B\u0029J)(num2, (int) num3, num4, (IntPtr) num5, num6);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    private static bool setHTTPRequestContextValue([In] long obj0, [In] long obj1, [In] long obj2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamHTTP.__\u003Cjniptr\u003EsetHTTPRequestContextValue\u0028JJJ\u0029Z == IntPtr.Zero)
        SteamHTTP.__\u003Cjniptr\u003EsetHTTPRequestContextValue\u0028JJJ\u0029Z = JNI.Frame.GetFuncPtr(SteamHTTP.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamHTTP", nameof (setHTTPRequestContextValue), "(JJJ)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamHTTP.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamHTTP>.Value);
        long num4 = obj0;
        long num5 = obj1;
        long num6 = obj2;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, long, long, long)>) SteamHTTP.__\u003Cjniptr\u003EsetHTTPRequestContextValue\u0028JJJ\u0029Z)((long) num2, (long) num3, num4, (IntPtr) num5, (IntPtr) num6);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    private static bool setHTTPRequestNetworkActivityTimeout([In] long obj0, [In] long obj1, [In] int obj2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamHTTP.__\u003Cjniptr\u003EsetHTTPRequestNetworkActivityTimeout\u0028JJI\u0029Z == IntPtr.Zero)
        SteamHTTP.__\u003Cjniptr\u003EsetHTTPRequestNetworkActivityTimeout\u0028JJI\u0029Z = JNI.Frame.GetFuncPtr(SteamHTTP.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamHTTP", nameof (setHTTPRequestNetworkActivityTimeout), "(JJI)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamHTTP.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamHTTP>.Value);
        long num4 = obj0;
        long num5 = obj1;
        int num6 = obj2;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, long, long, int)>) SteamHTTP.__\u003Cjniptr\u003EsetHTTPRequestNetworkActivityTimeout\u0028JJI\u0029Z)((int) num2, (long) num3, num4, (IntPtr) num5, (IntPtr) num6);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    private static bool setHTTPRequestHeaderValue([In] long obj0, [In] long obj1, [In] string obj2, [In] string obj3)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamHTTP.__\u003Cjniptr\u003EsetHTTPRequestHeaderValue\u0028JJLjava\u002Flang\u002FString\u003BLjava\u002Flang\u002FString\u003B\u0029Z == IntPtr.Zero)
        SteamHTTP.__\u003Cjniptr\u003EsetHTTPRequestHeaderValue\u0028JJLjava\u002Flang\u002FString\u003BLjava\u002Flang\u002FString\u003B\u0029Z = JNI.Frame.GetFuncPtr(SteamHTTP.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamHTTP", nameof (setHTTPRequestHeaderValue), "(JJLjava/lang/String;Ljava/lang/String;)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamHTTP.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamHTTP>.Value);
        long num4 = obj0;
        long num5 = obj1;
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj2);
        IntPtr num7 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj3);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, long, long, IntPtr, IntPtr)>) SteamHTTP.__\u003Cjniptr\u003EsetHTTPRequestHeaderValue\u0028JJLjava\u002Flang\u002FString\u003BLjava\u002Flang\u002FString\u003B\u0029Z)(num2, num3, num4, num5, num6, num7);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    private static bool setHTTPRequestGetOrPostParameter(
      [In] long obj0,
      [In] long obj1,
      [In] string obj2,
      [In] string obj3)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamHTTP.__\u003Cjniptr\u003EsetHTTPRequestGetOrPostParameter\u0028JJLjava\u002Flang\u002FString\u003BLjava\u002Flang\u002FString\u003B\u0029Z == IntPtr.Zero)
        SteamHTTP.__\u003Cjniptr\u003EsetHTTPRequestGetOrPostParameter\u0028JJLjava\u002Flang\u002FString\u003BLjava\u002Flang\u002FString\u003B\u0029Z = JNI.Frame.GetFuncPtr(SteamHTTP.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamHTTP", nameof (setHTTPRequestGetOrPostParameter), "(JJLjava/lang/String;Ljava/lang/String;)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamHTTP.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamHTTP>.Value);
        long num4 = obj0;
        long num5 = obj1;
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj2);
        IntPtr num7 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj3);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, long, long, IntPtr, IntPtr)>) SteamHTTP.__\u003Cjniptr\u003EsetHTTPRequestGetOrPostParameter\u0028JJLjava\u002Flang\u002FString\u003BLjava\u002Flang\u002FString\u003B\u0029Z)(num2, num3, num4, num5, num6, num7);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    private static long sendHTTPRequest([In] long obj0, [In] long obj1, [In] long obj2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamHTTP.__\u003Cjniptr\u003EsendHTTPRequest\u0028JJJ\u0029J == IntPtr.Zero)
        SteamHTTP.__\u003Cjniptr\u003EsendHTTPRequest\u0028JJJ\u0029J = JNI.Frame.GetFuncPtr(SteamHTTP.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamHTTP", nameof (sendHTTPRequest), "(JJJ)J");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamHTTP.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamHTTP>.Value);
        long num4 = obj0;
        long num5 = obj1;
        long num6 = obj2;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<long (IntPtr, IntPtr, long, long, long)>) SteamHTTP.__\u003Cjniptr\u003EsendHTTPRequest\u0028JJJ\u0029J)((long) num2, (long) num3, num4, (IntPtr) num5, (IntPtr) num6);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    private static long sendHTTPRequestAndStreamResponse([In] long obj0, [In] long obj1)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamHTTP.__\u003Cjniptr\u003EsendHTTPRequestAndStreamResponse\u0028JJ\u0029J == IntPtr.Zero)
        SteamHTTP.__\u003Cjniptr\u003EsendHTTPRequestAndStreamResponse\u0028JJ\u0029J = JNI.Frame.GetFuncPtr(SteamHTTP.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamHTTP", nameof (sendHTTPRequestAndStreamResponse), "(JJ)J");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamHTTP.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamHTTP>.Value);
        long num4 = obj0;
        long num5 = obj1;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<long (IntPtr, IntPtr, long, long)>) SteamHTTP.__\u003Cjniptr\u003EsendHTTPRequestAndStreamResponse\u0028JJ\u0029J)((long) num2, (long) num3, (IntPtr) num4, (IntPtr) num5);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    private static int getHTTPResponseHeaderSize([In] long obj0, [In] long obj1, [In] string obj2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamHTTP.__\u003Cjniptr\u003EgetHTTPResponseHeaderSize\u0028JJLjava\u002Flang\u002FString\u003B\u0029I == IntPtr.Zero)
        SteamHTTP.__\u003Cjniptr\u003EgetHTTPResponseHeaderSize\u0028JJLjava\u002Flang\u002FString\u003B\u0029I = JNI.Frame.GetFuncPtr(SteamHTTP.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamHTTP", nameof (getHTTPResponseHeaderSize), "(JJLjava/lang/String;)I");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamHTTP.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamHTTP>.Value);
        long num4 = obj0;
        long num5 = obj1;
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj2);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<int (IntPtr, IntPtr, long, long, IntPtr)>) SteamHTTP.__\u003Cjniptr\u003EgetHTTPResponseHeaderSize\u0028JJLjava\u002Flang\u002FString\u003B\u0029I)(num2, (long) num3, num4, (IntPtr) num5, num6);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    private static bool getHTTPResponseHeaderValue(
      [In] long obj0,
      [In] long obj1,
      [In] string obj2,
      [In] ByteBuffer obj3,
      [In] int obj4,
      [In] int obj5)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamHTTP.__\u003Cjniptr\u003EgetHTTPResponseHeaderValue\u0028JJLjava\u002Flang\u002FString\u003BLjava\u002Fnio\u002FByteBuffer\u003BII\u0029Z == IntPtr.Zero)
        SteamHTTP.__\u003Cjniptr\u003EgetHTTPResponseHeaderValue\u0028JJLjava\u002Flang\u002FString\u003BLjava\u002Fnio\u002FByteBuffer\u003BII\u0029Z = JNI.Frame.GetFuncPtr(SteamHTTP.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamHTTP", nameof (getHTTPResponseHeaderValue), "(JJLjava/lang/String;Ljava/nio/ByteBuffer;II)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamHTTP.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamHTTP>.Value);
        long num4 = obj0;
        long num5 = obj1;
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj2);
        IntPtr num7 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj3);
        int num8 = obj4;
        int num9 = obj5;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, long, long, IntPtr, IntPtr, int, int)>) SteamHTTP.__\u003Cjniptr\u003EgetHTTPResponseHeaderValue\u0028JJLjava\u002Flang\u002FString\u003BLjava\u002Fnio\u002FByteBuffer\u003BII\u0029Z)((int) num2, (int) num3, (IntPtr) num4, (IntPtr) num5, (long) num6, (long) num7, (IntPtr) num8, (IntPtr) num9);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    private static int getHTTPResponseBodySize([In] long obj0, [In] long obj1)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamHTTP.__\u003Cjniptr\u003EgetHTTPResponseBodySize\u0028JJ\u0029I == IntPtr.Zero)
        SteamHTTP.__\u003Cjniptr\u003EgetHTTPResponseBodySize\u0028JJ\u0029I = JNI.Frame.GetFuncPtr(SteamHTTP.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamHTTP", nameof (getHTTPResponseBodySize), "(JJ)I");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamHTTP.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamHTTP>.Value);
        long num4 = obj0;
        long num5 = obj1;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<int (IntPtr, IntPtr, long, long)>) SteamHTTP.__\u003Cjniptr\u003EgetHTTPResponseBodySize\u0028JJ\u0029I)((long) num2, (long) num3, (IntPtr) num4, (IntPtr) num5);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    private static bool getHTTPResponseBodyData(
      [In] long obj0,
      [In] long obj1,
      [In] ByteBuffer obj2,
      [In] int obj3,
      [In] int obj4)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamHTTP.__\u003Cjniptr\u003EgetHTTPResponseBodyData\u0028JJLjava\u002Fnio\u002FByteBuffer\u003BII\u0029Z == IntPtr.Zero)
        SteamHTTP.__\u003Cjniptr\u003EgetHTTPResponseBodyData\u0028JJLjava\u002Fnio\u002FByteBuffer\u003BII\u0029Z = JNI.Frame.GetFuncPtr(SteamHTTP.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamHTTP", nameof (getHTTPResponseBodyData), "(JJLjava/nio/ByteBuffer;II)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamHTTP.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamHTTP>.Value);
        long num4 = obj0;
        long num5 = obj1;
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj2);
        int num7 = obj3;
        int num8 = obj4;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, long, long, IntPtr, int, int)>) SteamHTTP.__\u003Cjniptr\u003EgetHTTPResponseBodyData\u0028JJLjava\u002Fnio\u002FByteBuffer\u003BII\u0029Z)((int) num2, (int) num3, (IntPtr) num4, num5, (long) num6, (IntPtr) num7, (IntPtr) num8);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    private static bool getHTTPStreamingResponseBodyData(
      [In] long obj0,
      [In] long obj1,
      [In] int obj2,
      [In] ByteBuffer obj3,
      [In] int obj4,
      [In] int obj5)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamHTTP.__\u003Cjniptr\u003EgetHTTPStreamingResponseBodyData\u0028JJILjava\u002Fnio\u002FByteBuffer\u003BII\u0029Z == IntPtr.Zero)
        SteamHTTP.__\u003Cjniptr\u003EgetHTTPStreamingResponseBodyData\u0028JJILjava\u002Fnio\u002FByteBuffer\u003BII\u0029Z = JNI.Frame.GetFuncPtr(SteamHTTP.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamHTTP", nameof (getHTTPStreamingResponseBodyData), "(JJILjava/nio/ByteBuffer;II)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamHTTP.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamHTTP>.Value);
        long num4 = obj0;
        long num5 = obj1;
        int num6 = obj2;
        IntPtr num7 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj3);
        int num8 = obj4;
        int num9 = obj5;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, long, long, int, IntPtr, int, int)>) SteamHTTP.__\u003Cjniptr\u003EgetHTTPStreamingResponseBodyData\u0028JJILjava\u002Fnio\u002FByteBuffer\u003BII\u0029Z)((int) num2, (int) num3, (IntPtr) num4, (int) num5, (long) num6, (long) num7, (IntPtr) num8, (IntPtr) num9);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    private static bool releaseHTTPRequest([In] long obj0, [In] long obj1)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamHTTP.__\u003Cjniptr\u003EreleaseHTTPRequest\u0028JJ\u0029Z == IntPtr.Zero)
        SteamHTTP.__\u003Cjniptr\u003EreleaseHTTPRequest\u0028JJ\u0029Z = JNI.Frame.GetFuncPtr(SteamHTTP.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamHTTP", nameof (releaseHTTPRequest), "(JJ)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamHTTP.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamHTTP>.Value);
        long num4 = obj0;
        long num5 = obj1;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, long, long)>) SteamHTTP.__\u003Cjniptr\u003EreleaseHTTPRequest\u0028JJ\u0029Z)((long) num2, (long) num3, (IntPtr) num4, (IntPtr) num5);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [LineNumberTable(new byte[] {55, 108, 37, 133})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public SteamHTTP(SteamHTTPCallback callback)
      : this(SteamAPI.getSteamHTTPPointer(), SteamHTTP.createCallback(new SteamHTTPCallbackAdapter(callback)))
    {
    }

    [LineNumberTable(114)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual SteamHTTPRequestHandle createHTTPRequest(
      SteamHTTP.HTTPMethod requestMethod,
      string absoluteURL)
    {
      return new SteamHTTPRequestHandle(SteamHTTP.createHTTPRequest(this.pointer, requestMethod.ordinal(), absoluteURL));
    }

    [LineNumberTable(118)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool setHTTPRequestContextValue(
      SteamHTTPRequestHandle request,
      long contextValue)
    {
      return SteamHTTP.setHTTPRequestContextValue(this.pointer, request.handle, contextValue);
    }

    [LineNumberTable(122)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool setHTTPRequestNetworkActivityTimeout(
      SteamHTTPRequestHandle request,
      int timeoutSeconds)
    {
      return SteamHTTP.setHTTPRequestNetworkActivityTimeout(this.pointer, request.handle, timeoutSeconds);
    }

    [LineNumberTable(128)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool setHTTPRequestHeaderValue(
      SteamHTTPRequestHandle request,
      string headerName,
      string headerValue)
    {
      return SteamHTTP.setHTTPRequestHeaderValue(this.pointer, request.handle, headerName, headerValue);
    }

    [LineNumberTable(134)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool setHTTPRequestGetOrPostParameter(
      SteamHTTPRequestHandle request,
      string paramName,
      string paramValue)
    {
      return SteamHTTP.setHTTPRequestGetOrPostParameter(this.pointer, request.handle, paramName, paramValue);
    }

    [LineNumberTable(138)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual SteamAPICall sendHTTPRequest(SteamHTTPRequestHandle request) => new SteamAPICall(SteamHTTP.sendHTTPRequest(this.pointer, this.callback, request.handle));

    [LineNumberTable(142)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual SteamAPICall sendHTTPRequestAndStreamResponse(
      SteamHTTPRequestHandle request)
    {
      return new SteamAPICall(SteamHTTP.sendHTTPRequestAndStreamResponse(this.pointer, request.handle));
    }

    [LineNumberTable(146)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getHTTPResponseHeaderSize(SteamHTTPRequestHandle request, string headerName) => SteamHTTP.getHTTPResponseHeaderSize(this.pointer, request.handle, headerName);

    [Throws(new string[] {"com.codedisaster.steamworks.SteamException"})]
    [LineNumberTable(new byte[] {102, 104, 176, 111, 43})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool getHTTPResponseHeaderValue(
      SteamHTTPRequestHandle request,
      string headerName,
      ByteBuffer value)
    {
      if (!value.isDirect())
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new SteamException("Direct buffer required!");
      }
      return SteamHTTP.getHTTPResponseHeaderValue(this.pointer, request.handle, headerName, value, ((Buffer) value).position(), ((Buffer) value).remaining());
    }

    [LineNumberTable(161)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getHTTPResponseBodySize(SteamHTTPRequestHandle request) => SteamHTTP.getHTTPResponseBodySize(this.pointer, request.handle);

    [Throws(new string[] {"com.codedisaster.steamworks.SteamException"})]
    [LineNumberTable(new byte[] {116, 104, 176})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool getHTTPResponseBodyData(SteamHTTPRequestHandle request, ByteBuffer data)
    {
      if (!data.isDirect())
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new SteamException("Direct buffer required!");
      }
      return SteamHTTP.getHTTPResponseBodyData(this.pointer, request.handle, data, ((Buffer) data).position(), ((Buffer) data).remaining());
    }

    [Throws(new string[] {"com.codedisaster.steamworks.SteamException"})]
    [LineNumberTable(new byte[] {126, 104, 176, 111, 43})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool getHTTPStreamingResponseBodyData(
      SteamHTTPRequestHandle request,
      int bodyDataOffset,
      ByteBuffer data)
    {
      if (!data.isDirect())
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new SteamException("Direct buffer required!");
      }
      return SteamHTTP.getHTTPStreamingResponseBodyData(this.pointer, request.handle, bodyDataOffset, data, ((Buffer) data).position(), ((Buffer) data).remaining());
    }

    [LineNumberTable(185)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool releaseHTTPRequest(SteamHTTPRequestHandle request) => SteamHTTP.releaseHTTPRequest(this.pointer, request.handle);

    [Modifiers]
    [LineNumberTable(5)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void dispose() => base.dispose();

    new static CallerID __\u003CGetCallerID\u003E()
    {
      if (SteamHTTP.__\u003CcallerID\u003E == null)
        SteamHTTP.__\u003CcallerID\u003E = (CallerID) new SteamHTTP.__\u003CCallerID\u003E();
      return SteamHTTP.__\u003CcallerID\u003E;
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
    [Signature("Ljava/lang/Enum<Lcom/codedisaster/steamworks/SteamHTTP$HTTPMethod;>;")]
    [Modifiers]
    [Serializable]
    public sealed class HTTPMethod : Enum
    {
      [Modifiers]
      internal static SteamHTTP.HTTPMethod __\u003C\u003EInvalid;
      [Modifiers]
      internal static SteamHTTP.HTTPMethod __\u003C\u003EGET;
      [Modifiers]
      internal static SteamHTTP.HTTPMethod __\u003C\u003EHEAD;
      [Modifiers]
      internal static SteamHTTP.HTTPMethod __\u003C\u003EPOST;
      [Modifiers]
      internal static SteamHTTP.HTTPMethod __\u003C\u003EPUT;
      [Modifiers]
      internal static SteamHTTP.HTTPMethod __\u003C\u003EDELETE;
      [Modifiers]
      internal static SteamHTTP.HTTPMethod __\u003C\u003EOPTIONS;
      [Modifiers]
      private static SteamHTTP.HTTPMethod[] \u0024VALUES;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [Signature("()V")]
      [LineNumberTable(7)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private HTTPMethod([In] string obj0, [In] int obj1)
        : base(obj0, obj1)
      {
        GC.KeepAlive((object) this);
      }

      [LineNumberTable(7)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static SteamHTTP.HTTPMethod[] values() => (SteamHTTP.HTTPMethod[]) SteamHTTP.HTTPMethod.\u0024VALUES.Clone();

      [LineNumberTable(7)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static SteamHTTP.HTTPMethod valueOf(string name) => (SteamHTTP.HTTPMethod) Enum.valueOf((Class) ClassLiteral<SteamHTTP.HTTPMethod>.Value, name);

      [LineNumberTable(new byte[] {159, 140, 77, 112, 112, 112, 112, 112, 112, 240, 57})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static HTTPMethod()
      {
        if (ByteCodeHelper.isAlreadyInited("com.codedisaster.steamworks.SteamHTTP$HTTPMethod"))
          return;
        SteamHTTP.HTTPMethod.__\u003C\u003EInvalid = new SteamHTTP.HTTPMethod(nameof (Invalid), 0);
        SteamHTTP.HTTPMethod.__\u003C\u003EGET = new SteamHTTP.HTTPMethod(nameof (GET), 1);
        SteamHTTP.HTTPMethod.__\u003C\u003EHEAD = new SteamHTTP.HTTPMethod(nameof (HEAD), 2);
        SteamHTTP.HTTPMethod.__\u003C\u003EPOST = new SteamHTTP.HTTPMethod(nameof (POST), 3);
        SteamHTTP.HTTPMethod.__\u003C\u003EPUT = new SteamHTTP.HTTPMethod(nameof (PUT), 4);
        SteamHTTP.HTTPMethod.__\u003C\u003EDELETE = new SteamHTTP.HTTPMethod(nameof (DELETE), 5);
        SteamHTTP.HTTPMethod.__\u003C\u003EOPTIONS = new SteamHTTP.HTTPMethod(nameof (OPTIONS), 6);
        SteamHTTP.HTTPMethod.\u0024VALUES = new SteamHTTP.HTTPMethod[7]
        {
          SteamHTTP.HTTPMethod.__\u003C\u003EInvalid,
          SteamHTTP.HTTPMethod.__\u003C\u003EGET,
          SteamHTTP.HTTPMethod.__\u003C\u003EHEAD,
          SteamHTTP.HTTPMethod.__\u003C\u003EPOST,
          SteamHTTP.HTTPMethod.__\u003C\u003EPUT,
          SteamHTTP.HTTPMethod.__\u003C\u003EDELETE,
          SteamHTTP.HTTPMethod.__\u003C\u003EOPTIONS
        };
      }

      [Modifiers]
      public static SteamHTTP.HTTPMethod Invalid
      {
        [HideFromJava] get => SteamHTTP.HTTPMethod.__\u003C\u003EInvalid;
      }

      [Modifiers]
      public static SteamHTTP.HTTPMethod GET
      {
        [HideFromJava] get => SteamHTTP.HTTPMethod.__\u003C\u003EGET;
      }

      [Modifiers]
      public static SteamHTTP.HTTPMethod HEAD
      {
        [HideFromJava] get => SteamHTTP.HTTPMethod.__\u003C\u003EHEAD;
      }

      [Modifiers]
      public static SteamHTTP.HTTPMethod POST
      {
        [HideFromJava] get => SteamHTTP.HTTPMethod.__\u003C\u003EPOST;
      }

      [Modifiers]
      public static SteamHTTP.HTTPMethod PUT
      {
        [HideFromJava] get => SteamHTTP.HTTPMethod.__\u003C\u003EPUT;
      }

      [Modifiers]
      public static SteamHTTP.HTTPMethod DELETE
      {
        [HideFromJava] get => SteamHTTP.HTTPMethod.__\u003C\u003EDELETE;
      }

      [Modifiers]
      public static SteamHTTP.HTTPMethod OPTIONS
      {
        [HideFromJava] get => SteamHTTP.HTTPMethod.__\u003C\u003EOPTIONS;
      }

      [HideFromJava]
      [Serializable]
      public enum __Enum
      {
        Invalid,
        GET,
        HEAD,
        POST,
        PUT,
        DELETE,
        OPTIONS,
      }
    }

    [InnerClass]
    [Signature("Ljava/lang/Enum<Lcom/codedisaster/steamworks/SteamHTTP$HTTPStatusCode;>;")]
    [Modifiers]
    [Serializable]
    public sealed class HTTPStatusCode : Enum
    {
      [Modifiers]
      internal static SteamHTTP.HTTPStatusCode __\u003C\u003EInvalid;
      [Modifiers]
      internal static SteamHTTP.HTTPStatusCode __\u003C\u003EContinue;
      [Modifiers]
      internal static SteamHTTP.HTTPStatusCode __\u003C\u003ESwitchingProtocols;
      [Modifiers]
      internal static SteamHTTP.HTTPStatusCode __\u003C\u003EOK;
      [Modifiers]
      internal static SteamHTTP.HTTPStatusCode __\u003C\u003ECreated;
      [Modifiers]
      internal static SteamHTTP.HTTPStatusCode __\u003C\u003EAccepted;
      [Modifiers]
      internal static SteamHTTP.HTTPStatusCode __\u003C\u003ENonAuthoritative;
      [Modifiers]
      internal static SteamHTTP.HTTPStatusCode __\u003C\u003ENoContent;
      [Modifiers]
      internal static SteamHTTP.HTTPStatusCode __\u003C\u003EResetContent;
      [Modifiers]
      internal static SteamHTTP.HTTPStatusCode __\u003C\u003EPartialContent;
      [Modifiers]
      internal static SteamHTTP.HTTPStatusCode __\u003C\u003EMultipleChoices;
      [Modifiers]
      internal static SteamHTTP.HTTPStatusCode __\u003C\u003EMovedPermanently;
      [Modifiers]
      internal static SteamHTTP.HTTPStatusCode __\u003C\u003EFound;
      [Modifiers]
      internal static SteamHTTP.HTTPStatusCode __\u003C\u003ESeeOther;
      [Modifiers]
      internal static SteamHTTP.HTTPStatusCode __\u003C\u003ENotModified;
      [Modifiers]
      internal static SteamHTTP.HTTPStatusCode __\u003C\u003EUseProxy;
      [Modifiers]
      internal static SteamHTTP.HTTPStatusCode __\u003C\u003ETemporaryRedirect;
      [Modifiers]
      internal static SteamHTTP.HTTPStatusCode __\u003C\u003EBadRequest;
      [Modifiers]
      internal static SteamHTTP.HTTPStatusCode __\u003C\u003EUnauthorized;
      [Modifiers]
      internal static SteamHTTP.HTTPStatusCode __\u003C\u003EPaymentRequired;
      [Modifiers]
      internal static SteamHTTP.HTTPStatusCode __\u003C\u003EForbidden;
      [Modifiers]
      internal static SteamHTTP.HTTPStatusCode __\u003C\u003ENotFound;
      [Modifiers]
      internal static SteamHTTP.HTTPStatusCode __\u003C\u003EMethodNotAllowed;
      [Modifiers]
      internal static SteamHTTP.HTTPStatusCode __\u003C\u003ENotAcceptable;
      [Modifiers]
      internal static SteamHTTP.HTTPStatusCode __\u003C\u003EProxyAuthRequired;
      [Modifiers]
      internal static SteamHTTP.HTTPStatusCode __\u003C\u003ERequestTimeout;
      [Modifiers]
      internal static SteamHTTP.HTTPStatusCode __\u003C\u003EConflict;
      [Modifiers]
      internal static SteamHTTP.HTTPStatusCode __\u003C\u003EGone;
      [Modifiers]
      internal static SteamHTTP.HTTPStatusCode __\u003C\u003ELengthRequired;
      [Modifiers]
      internal static SteamHTTP.HTTPStatusCode __\u003C\u003EPreconditionFailed;
      [Modifiers]
      internal static SteamHTTP.HTTPStatusCode __\u003C\u003ERequestEntityTooLarge;
      [Modifiers]
      internal static SteamHTTP.HTTPStatusCode __\u003C\u003ERequestURITooLong;
      [Modifiers]
      internal static SteamHTTP.HTTPStatusCode __\u003C\u003EUnsupportedMediaType;
      [Modifiers]
      internal static SteamHTTP.HTTPStatusCode __\u003C\u003ERequestedRangeNotSatisfiable;
      [Modifiers]
      internal static SteamHTTP.HTTPStatusCode __\u003C\u003EExpectationFailed;
      [Modifiers]
      internal static SteamHTTP.HTTPStatusCode __\u003C\u003EUnknown4xx;
      [Modifiers]
      internal static SteamHTTP.HTTPStatusCode __\u003C\u003ETooManyRequests;
      [Modifiers]
      internal static SteamHTTP.HTTPStatusCode __\u003C\u003EInternalServerError;
      [Modifiers]
      internal static SteamHTTP.HTTPStatusCode __\u003C\u003ENotImplemented;
      [Modifiers]
      internal static SteamHTTP.HTTPStatusCode __\u003C\u003EBadGateway;
      [Modifiers]
      internal static SteamHTTP.HTTPStatusCode __\u003C\u003EServiceUnavailable;
      [Modifiers]
      internal static SteamHTTP.HTTPStatusCode __\u003C\u003EGatewayTimeout;
      [Modifiers]
      internal static SteamHTTP.HTTPStatusCode __\u003C\u003EHTTPVersionNotSupported;
      [Modifiers]
      internal static SteamHTTP.HTTPStatusCode __\u003C\u003EUnknown5xx;
      [Modifiers]
      private int code;
      [Modifiers]
      private static SteamHTTP.HTTPStatusCode[] values;
      [Modifiers]
      private static SteamHTTP.HTTPStatusCode[] \u0024VALUES;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [Signature("(I)V")]
      [LineNumberTable(new byte[] {21, 106, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private HTTPStatusCode([In] string obj0, [In] int obj1, [In] int obj2)
        : base(obj0, obj1)
      {
        SteamHTTP.HTTPStatusCode httpStatusCode = this;
        this.code = obj2;
        GC.KeepAlive((object) this);
      }

      [LineNumberTable(17)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static SteamHTTP.HTTPStatusCode[] values() => (SteamHTTP.HTTPStatusCode[]) SteamHTTP.HTTPStatusCode.\u0024VALUES.Clone();

      [LineNumberTable(17)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static SteamHTTP.HTTPStatusCode valueOf(string name) => (SteamHTTP.HTTPStatusCode) Enum.valueOf((Class) ClassLiteral<SteamHTTP.HTTPStatusCode>.Value, name);

      [LineNumberTable(new byte[] {31, 98, 233, 70, 100, 102, 104, 105, 102, 105, 134, 130, 130})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal static SteamHTTP.HTTPStatusCode byValue([In] int obj0)
      {
        int num1 = 0;
        int num2 = SteamHTTP.HTTPStatusCode.values.Length - 1;
        while (num1 <= num2)
        {
          int index = (num1 + num2) / 2;
          SteamHTTP.HTTPStatusCode httpStatusCode = SteamHTTP.HTTPStatusCode.values[index];
          if (obj0 < httpStatusCode.code)
          {
            num2 = index - 1;
          }
          else
          {
            if (obj0 <= httpStatusCode.code)
              return httpStatusCode;
            num1 = index + 1;
          }
        }
        return SteamHTTP.HTTPStatusCode.__\u003C\u003EInvalid;
      }

      [LineNumberTable(new byte[] {159, 138, 141, 145, 114, 146, 117, 117, 117, 117, 117, 117, 150, 118, 118, 118, 118, 118, 118, 150, 118, 118, 118, 118, 118, 118, 118, 118, 118, 118, 118, 118, 118, 118, 118, 118, 118, 118, 118, 150, 118, 118, 118, 118, 118, 118, 246, 15, 255, 161, 48, 116})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static HTTPStatusCode()
      {
        if (ByteCodeHelper.isAlreadyInited("com.codedisaster.steamworks.SteamHTTP$HTTPStatusCode"))
          return;
        SteamHTTP.HTTPStatusCode.__\u003C\u003EInvalid = new SteamHTTP.HTTPStatusCode(nameof (Invalid), 0, 0);
        SteamHTTP.HTTPStatusCode.__\u003C\u003EContinue = new SteamHTTP.HTTPStatusCode(nameof (Continue), 1, 100);
        SteamHTTP.HTTPStatusCode.__\u003C\u003ESwitchingProtocols = new SteamHTTP.HTTPStatusCode(nameof (SwitchingProtocols), 2, 101);
        SteamHTTP.HTTPStatusCode.__\u003C\u003EOK = new SteamHTTP.HTTPStatusCode(nameof (OK), 3, 200);
        SteamHTTP.HTTPStatusCode.__\u003C\u003ECreated = new SteamHTTP.HTTPStatusCode(nameof (Created), 4, 201);
        SteamHTTP.HTTPStatusCode.__\u003C\u003EAccepted = new SteamHTTP.HTTPStatusCode(nameof (Accepted), 5, 202);
        SteamHTTP.HTTPStatusCode.__\u003C\u003ENonAuthoritative = new SteamHTTP.HTTPStatusCode(nameof (NonAuthoritative), 6, 203);
        SteamHTTP.HTTPStatusCode.__\u003C\u003ENoContent = new SteamHTTP.HTTPStatusCode(nameof (NoContent), 7, 204);
        SteamHTTP.HTTPStatusCode.__\u003C\u003EResetContent = new SteamHTTP.HTTPStatusCode(nameof (ResetContent), 8, 205);
        SteamHTTP.HTTPStatusCode.__\u003C\u003EPartialContent = new SteamHTTP.HTTPStatusCode(nameof (PartialContent), 9, 206);
        SteamHTTP.HTTPStatusCode.__\u003C\u003EMultipleChoices = new SteamHTTP.HTTPStatusCode(nameof (MultipleChoices), 10, 300);
        SteamHTTP.HTTPStatusCode.__\u003C\u003EMovedPermanently = new SteamHTTP.HTTPStatusCode(nameof (MovedPermanently), 11, 301);
        SteamHTTP.HTTPStatusCode.__\u003C\u003EFound = new SteamHTTP.HTTPStatusCode(nameof (Found), 12, 302);
        SteamHTTP.HTTPStatusCode.__\u003C\u003ESeeOther = new SteamHTTP.HTTPStatusCode(nameof (SeeOther), 13, 303);
        SteamHTTP.HTTPStatusCode.__\u003C\u003ENotModified = new SteamHTTP.HTTPStatusCode(nameof (NotModified), 14, 304);
        SteamHTTP.HTTPStatusCode.__\u003C\u003EUseProxy = new SteamHTTP.HTTPStatusCode(nameof (UseProxy), 15, 305);
        SteamHTTP.HTTPStatusCode.__\u003C\u003ETemporaryRedirect = new SteamHTTP.HTTPStatusCode(nameof (TemporaryRedirect), 16, 307);
        SteamHTTP.HTTPStatusCode.__\u003C\u003EBadRequest = new SteamHTTP.HTTPStatusCode(nameof (BadRequest), 17, 400);
        SteamHTTP.HTTPStatusCode.__\u003C\u003EUnauthorized = new SteamHTTP.HTTPStatusCode(nameof (Unauthorized), 18, 401);
        SteamHTTP.HTTPStatusCode.__\u003C\u003EPaymentRequired = new SteamHTTP.HTTPStatusCode(nameof (PaymentRequired), 19, 402);
        SteamHTTP.HTTPStatusCode.__\u003C\u003EForbidden = new SteamHTTP.HTTPStatusCode(nameof (Forbidden), 20, 403);
        SteamHTTP.HTTPStatusCode.__\u003C\u003ENotFound = new SteamHTTP.HTTPStatusCode(nameof (NotFound), 21, 404);
        SteamHTTP.HTTPStatusCode.__\u003C\u003EMethodNotAllowed = new SteamHTTP.HTTPStatusCode(nameof (MethodNotAllowed), 22, 405);
        SteamHTTP.HTTPStatusCode.__\u003C\u003ENotAcceptable = new SteamHTTP.HTTPStatusCode(nameof (NotAcceptable), 23, 406);
        SteamHTTP.HTTPStatusCode.__\u003C\u003EProxyAuthRequired = new SteamHTTP.HTTPStatusCode(nameof (ProxyAuthRequired), 24, 407);
        SteamHTTP.HTTPStatusCode.__\u003C\u003ERequestTimeout = new SteamHTTP.HTTPStatusCode(nameof (RequestTimeout), 25, 408);
        SteamHTTP.HTTPStatusCode.__\u003C\u003EConflict = new SteamHTTP.HTTPStatusCode(nameof (Conflict), 26, 409);
        SteamHTTP.HTTPStatusCode.__\u003C\u003EGone = new SteamHTTP.HTTPStatusCode(nameof (Gone), 27, 410);
        SteamHTTP.HTTPStatusCode.__\u003C\u003ELengthRequired = new SteamHTTP.HTTPStatusCode(nameof (LengthRequired), 28, 411);
        SteamHTTP.HTTPStatusCode.__\u003C\u003EPreconditionFailed = new SteamHTTP.HTTPStatusCode(nameof (PreconditionFailed), 29, 412);
        SteamHTTP.HTTPStatusCode.__\u003C\u003ERequestEntityTooLarge = new SteamHTTP.HTTPStatusCode(nameof (RequestEntityTooLarge), 30, 413);
        SteamHTTP.HTTPStatusCode.__\u003C\u003ERequestURITooLong = new SteamHTTP.HTTPStatusCode(nameof (RequestURITooLong), 31, 414);
        SteamHTTP.HTTPStatusCode.__\u003C\u003EUnsupportedMediaType = new SteamHTTP.HTTPStatusCode(nameof (UnsupportedMediaType), 32, 415);
        SteamHTTP.HTTPStatusCode.__\u003C\u003ERequestedRangeNotSatisfiable = new SteamHTTP.HTTPStatusCode(nameof (RequestedRangeNotSatisfiable), 33, 416);
        SteamHTTP.HTTPStatusCode.__\u003C\u003EExpectationFailed = new SteamHTTP.HTTPStatusCode(nameof (ExpectationFailed), 34, 417);
        SteamHTTP.HTTPStatusCode.__\u003C\u003EUnknown4xx = new SteamHTTP.HTTPStatusCode(nameof (Unknown4xx), 35, 418);
        SteamHTTP.HTTPStatusCode.__\u003C\u003ETooManyRequests = new SteamHTTP.HTTPStatusCode(nameof (TooManyRequests), 36, 429);
        SteamHTTP.HTTPStatusCode.__\u003C\u003EInternalServerError = new SteamHTTP.HTTPStatusCode(nameof (InternalServerError), 37, 500);
        SteamHTTP.HTTPStatusCode.__\u003C\u003ENotImplemented = new SteamHTTP.HTTPStatusCode(nameof (NotImplemented), 38, 501);
        SteamHTTP.HTTPStatusCode.__\u003C\u003EBadGateway = new SteamHTTP.HTTPStatusCode(nameof (BadGateway), 39, 502);
        SteamHTTP.HTTPStatusCode.__\u003C\u003EServiceUnavailable = new SteamHTTP.HTTPStatusCode(nameof (ServiceUnavailable), 40, 503);
        SteamHTTP.HTTPStatusCode.__\u003C\u003EGatewayTimeout = new SteamHTTP.HTTPStatusCode(nameof (GatewayTimeout), 41, 504);
        SteamHTTP.HTTPStatusCode.__\u003C\u003EHTTPVersionNotSupported = new SteamHTTP.HTTPStatusCode(nameof (HTTPVersionNotSupported), 42, 505);
        SteamHTTP.HTTPStatusCode.__\u003C\u003EUnknown5xx = new SteamHTTP.HTTPStatusCode(nameof (Unknown5xx), 43, 599);
        SteamHTTP.HTTPStatusCode.\u0024VALUES = new SteamHTTP.HTTPStatusCode[44]
        {
          SteamHTTP.HTTPStatusCode.__\u003C\u003EInvalid,
          SteamHTTP.HTTPStatusCode.__\u003C\u003EContinue,
          SteamHTTP.HTTPStatusCode.__\u003C\u003ESwitchingProtocols,
          SteamHTTP.HTTPStatusCode.__\u003C\u003EOK,
          SteamHTTP.HTTPStatusCode.__\u003C\u003ECreated,
          SteamHTTP.HTTPStatusCode.__\u003C\u003EAccepted,
          SteamHTTP.HTTPStatusCode.__\u003C\u003ENonAuthoritative,
          SteamHTTP.HTTPStatusCode.__\u003C\u003ENoContent,
          SteamHTTP.HTTPStatusCode.__\u003C\u003EResetContent,
          SteamHTTP.HTTPStatusCode.__\u003C\u003EPartialContent,
          SteamHTTP.HTTPStatusCode.__\u003C\u003EMultipleChoices,
          SteamHTTP.HTTPStatusCode.__\u003C\u003EMovedPermanently,
          SteamHTTP.HTTPStatusCode.__\u003C\u003EFound,
          SteamHTTP.HTTPStatusCode.__\u003C\u003ESeeOther,
          SteamHTTP.HTTPStatusCode.__\u003C\u003ENotModified,
          SteamHTTP.HTTPStatusCode.__\u003C\u003EUseProxy,
          SteamHTTP.HTTPStatusCode.__\u003C\u003ETemporaryRedirect,
          SteamHTTP.HTTPStatusCode.__\u003C\u003EBadRequest,
          SteamHTTP.HTTPStatusCode.__\u003C\u003EUnauthorized,
          SteamHTTP.HTTPStatusCode.__\u003C\u003EPaymentRequired,
          SteamHTTP.HTTPStatusCode.__\u003C\u003EForbidden,
          SteamHTTP.HTTPStatusCode.__\u003C\u003ENotFound,
          SteamHTTP.HTTPStatusCode.__\u003C\u003EMethodNotAllowed,
          SteamHTTP.HTTPStatusCode.__\u003C\u003ENotAcceptable,
          SteamHTTP.HTTPStatusCode.__\u003C\u003EProxyAuthRequired,
          SteamHTTP.HTTPStatusCode.__\u003C\u003ERequestTimeout,
          SteamHTTP.HTTPStatusCode.__\u003C\u003EConflict,
          SteamHTTP.HTTPStatusCode.__\u003C\u003EGone,
          SteamHTTP.HTTPStatusCode.__\u003C\u003ELengthRequired,
          SteamHTTP.HTTPStatusCode.__\u003C\u003EPreconditionFailed,
          SteamHTTP.HTTPStatusCode.__\u003C\u003ERequestEntityTooLarge,
          SteamHTTP.HTTPStatusCode.__\u003C\u003ERequestURITooLong,
          SteamHTTP.HTTPStatusCode.__\u003C\u003EUnsupportedMediaType,
          SteamHTTP.HTTPStatusCode.__\u003C\u003ERequestedRangeNotSatisfiable,
          SteamHTTP.HTTPStatusCode.__\u003C\u003EExpectationFailed,
          SteamHTTP.HTTPStatusCode.__\u003C\u003EUnknown4xx,
          SteamHTTP.HTTPStatusCode.__\u003C\u003ETooManyRequests,
          SteamHTTP.HTTPStatusCode.__\u003C\u003EInternalServerError,
          SteamHTTP.HTTPStatusCode.__\u003C\u003ENotImplemented,
          SteamHTTP.HTTPStatusCode.__\u003C\u003EBadGateway,
          SteamHTTP.HTTPStatusCode.__\u003C\u003EServiceUnavailable,
          SteamHTTP.HTTPStatusCode.__\u003C\u003EGatewayTimeout,
          SteamHTTP.HTTPStatusCode.__\u003C\u003EHTTPVersionNotSupported,
          SteamHTTP.HTTPStatusCode.__\u003C\u003EUnknown5xx
        };
        SteamHTTP.HTTPStatusCode.values = SteamHTTP.HTTPStatusCode.values();
      }

      [Modifiers]
      public static SteamHTTP.HTTPStatusCode Invalid
      {
        [HideFromJava] get => SteamHTTP.HTTPStatusCode.__\u003C\u003EInvalid;
      }

      [Modifiers]
      public static SteamHTTP.HTTPStatusCode Continue
      {
        [HideFromJava] get => SteamHTTP.HTTPStatusCode.__\u003C\u003EContinue;
      }

      [Modifiers]
      public static SteamHTTP.HTTPStatusCode SwitchingProtocols
      {
        [HideFromJava] get => SteamHTTP.HTTPStatusCode.__\u003C\u003ESwitchingProtocols;
      }

      [Modifiers]
      public static SteamHTTP.HTTPStatusCode OK
      {
        [HideFromJava] get => SteamHTTP.HTTPStatusCode.__\u003C\u003EOK;
      }

      [Modifiers]
      public static SteamHTTP.HTTPStatusCode Created
      {
        [HideFromJava] get => SteamHTTP.HTTPStatusCode.__\u003C\u003ECreated;
      }

      [Modifiers]
      public static SteamHTTP.HTTPStatusCode Accepted
      {
        [HideFromJava] get => SteamHTTP.HTTPStatusCode.__\u003C\u003EAccepted;
      }

      [Modifiers]
      public static SteamHTTP.HTTPStatusCode NonAuthoritative
      {
        [HideFromJava] get => SteamHTTP.HTTPStatusCode.__\u003C\u003ENonAuthoritative;
      }

      [Modifiers]
      public static SteamHTTP.HTTPStatusCode NoContent
      {
        [HideFromJava] get => SteamHTTP.HTTPStatusCode.__\u003C\u003ENoContent;
      }

      [Modifiers]
      public static SteamHTTP.HTTPStatusCode ResetContent
      {
        [HideFromJava] get => SteamHTTP.HTTPStatusCode.__\u003C\u003EResetContent;
      }

      [Modifiers]
      public static SteamHTTP.HTTPStatusCode PartialContent
      {
        [HideFromJava] get => SteamHTTP.HTTPStatusCode.__\u003C\u003EPartialContent;
      }

      [Modifiers]
      public static SteamHTTP.HTTPStatusCode MultipleChoices
      {
        [HideFromJava] get => SteamHTTP.HTTPStatusCode.__\u003C\u003EMultipleChoices;
      }

      [Modifiers]
      public static SteamHTTP.HTTPStatusCode MovedPermanently
      {
        [HideFromJava] get => SteamHTTP.HTTPStatusCode.__\u003C\u003EMovedPermanently;
      }

      [Modifiers]
      public static SteamHTTP.HTTPStatusCode Found
      {
        [HideFromJava] get => SteamHTTP.HTTPStatusCode.__\u003C\u003EFound;
      }

      [Modifiers]
      public static SteamHTTP.HTTPStatusCode SeeOther
      {
        [HideFromJava] get => SteamHTTP.HTTPStatusCode.__\u003C\u003ESeeOther;
      }

      [Modifiers]
      public static SteamHTTP.HTTPStatusCode NotModified
      {
        [HideFromJava] get => SteamHTTP.HTTPStatusCode.__\u003C\u003ENotModified;
      }

      [Modifiers]
      public static SteamHTTP.HTTPStatusCode UseProxy
      {
        [HideFromJava] get => SteamHTTP.HTTPStatusCode.__\u003C\u003EUseProxy;
      }

      [Modifiers]
      public static SteamHTTP.HTTPStatusCode TemporaryRedirect
      {
        [HideFromJava] get => SteamHTTP.HTTPStatusCode.__\u003C\u003ETemporaryRedirect;
      }

      [Modifiers]
      public static SteamHTTP.HTTPStatusCode BadRequest
      {
        [HideFromJava] get => SteamHTTP.HTTPStatusCode.__\u003C\u003EBadRequest;
      }

      [Modifiers]
      public static SteamHTTP.HTTPStatusCode Unauthorized
      {
        [HideFromJava] get => SteamHTTP.HTTPStatusCode.__\u003C\u003EUnauthorized;
      }

      [Modifiers]
      public static SteamHTTP.HTTPStatusCode PaymentRequired
      {
        [HideFromJava] get => SteamHTTP.HTTPStatusCode.__\u003C\u003EPaymentRequired;
      }

      [Modifiers]
      public static SteamHTTP.HTTPStatusCode Forbidden
      {
        [HideFromJava] get => SteamHTTP.HTTPStatusCode.__\u003C\u003EForbidden;
      }

      [Modifiers]
      public static SteamHTTP.HTTPStatusCode NotFound
      {
        [HideFromJava] get => SteamHTTP.HTTPStatusCode.__\u003C\u003ENotFound;
      }

      [Modifiers]
      public static SteamHTTP.HTTPStatusCode MethodNotAllowed
      {
        [HideFromJava] get => SteamHTTP.HTTPStatusCode.__\u003C\u003EMethodNotAllowed;
      }

      [Modifiers]
      public static SteamHTTP.HTTPStatusCode NotAcceptable
      {
        [HideFromJava] get => SteamHTTP.HTTPStatusCode.__\u003C\u003ENotAcceptable;
      }

      [Modifiers]
      public static SteamHTTP.HTTPStatusCode ProxyAuthRequired
      {
        [HideFromJava] get => SteamHTTP.HTTPStatusCode.__\u003C\u003EProxyAuthRequired;
      }

      [Modifiers]
      public static SteamHTTP.HTTPStatusCode RequestTimeout
      {
        [HideFromJava] get => SteamHTTP.HTTPStatusCode.__\u003C\u003ERequestTimeout;
      }

      [Modifiers]
      public static SteamHTTP.HTTPStatusCode Conflict
      {
        [HideFromJava] get => SteamHTTP.HTTPStatusCode.__\u003C\u003EConflict;
      }

      [Modifiers]
      public static SteamHTTP.HTTPStatusCode Gone
      {
        [HideFromJava] get => SteamHTTP.HTTPStatusCode.__\u003C\u003EGone;
      }

      [Modifiers]
      public static SteamHTTP.HTTPStatusCode LengthRequired
      {
        [HideFromJava] get => SteamHTTP.HTTPStatusCode.__\u003C\u003ELengthRequired;
      }

      [Modifiers]
      public static SteamHTTP.HTTPStatusCode PreconditionFailed
      {
        [HideFromJava] get => SteamHTTP.HTTPStatusCode.__\u003C\u003EPreconditionFailed;
      }

      [Modifiers]
      public static SteamHTTP.HTTPStatusCode RequestEntityTooLarge
      {
        [HideFromJava] get => SteamHTTP.HTTPStatusCode.__\u003C\u003ERequestEntityTooLarge;
      }

      [Modifiers]
      public static SteamHTTP.HTTPStatusCode RequestURITooLong
      {
        [HideFromJava] get => SteamHTTP.HTTPStatusCode.__\u003C\u003ERequestURITooLong;
      }

      [Modifiers]
      public static SteamHTTP.HTTPStatusCode UnsupportedMediaType
      {
        [HideFromJava] get => SteamHTTP.HTTPStatusCode.__\u003C\u003EUnsupportedMediaType;
      }

      [Modifiers]
      public static SteamHTTP.HTTPStatusCode RequestedRangeNotSatisfiable
      {
        [HideFromJava] get => SteamHTTP.HTTPStatusCode.__\u003C\u003ERequestedRangeNotSatisfiable;
      }

      [Modifiers]
      public static SteamHTTP.HTTPStatusCode ExpectationFailed
      {
        [HideFromJava] get => SteamHTTP.HTTPStatusCode.__\u003C\u003EExpectationFailed;
      }

      [Modifiers]
      public static SteamHTTP.HTTPStatusCode Unknown4xx
      {
        [HideFromJava] get => SteamHTTP.HTTPStatusCode.__\u003C\u003EUnknown4xx;
      }

      [Modifiers]
      public static SteamHTTP.HTTPStatusCode TooManyRequests
      {
        [HideFromJava] get => SteamHTTP.HTTPStatusCode.__\u003C\u003ETooManyRequests;
      }

      [Modifiers]
      public static SteamHTTP.HTTPStatusCode InternalServerError
      {
        [HideFromJava] get => SteamHTTP.HTTPStatusCode.__\u003C\u003EInternalServerError;
      }

      [Modifiers]
      public static SteamHTTP.HTTPStatusCode NotImplemented
      {
        [HideFromJava] get => SteamHTTP.HTTPStatusCode.__\u003C\u003ENotImplemented;
      }

      [Modifiers]
      public static SteamHTTP.HTTPStatusCode BadGateway
      {
        [HideFromJava] get => SteamHTTP.HTTPStatusCode.__\u003C\u003EBadGateway;
      }

      [Modifiers]
      public static SteamHTTP.HTTPStatusCode ServiceUnavailable
      {
        [HideFromJava] get => SteamHTTP.HTTPStatusCode.__\u003C\u003EServiceUnavailable;
      }

      [Modifiers]
      public static SteamHTTP.HTTPStatusCode GatewayTimeout
      {
        [HideFromJava] get => SteamHTTP.HTTPStatusCode.__\u003C\u003EGatewayTimeout;
      }

      [Modifiers]
      public static SteamHTTP.HTTPStatusCode HTTPVersionNotSupported
      {
        [HideFromJava] get => SteamHTTP.HTTPStatusCode.__\u003C\u003EHTTPVersionNotSupported;
      }

      [Modifiers]
      public static SteamHTTP.HTTPStatusCode Unknown5xx
      {
        [HideFromJava] get => SteamHTTP.HTTPStatusCode.__\u003C\u003EUnknown5xx;
      }

      [HideFromJava]
      [Serializable]
      public enum __Enum
      {
        Invalid,
        Continue,
        SwitchingProtocols,
        OK,
        Created,
        Accepted,
        NonAuthoritative,
        NoContent,
        ResetContent,
        PartialContent,
        MultipleChoices,
        MovedPermanently,
        Found,
        SeeOther,
        NotModified,
        UseProxy,
        TemporaryRedirect,
        BadRequest,
        Unauthorized,
        PaymentRequired,
        Forbidden,
        NotFound,
        MethodNotAllowed,
        NotAcceptable,
        ProxyAuthRequired,
        RequestTimeout,
        Conflict,
        Gone,
        LengthRequired,
        PreconditionFailed,
        RequestEntityTooLarge,
        RequestURITooLong,
        UnsupportedMediaType,
        RequestedRangeNotSatisfiable,
        ExpectationFailed,
        Unknown4xx,
        TooManyRequests,
        InternalServerError,
        NotImplemented,
        BadGateway,
        ServiceUnavailable,
        GatewayTimeout,
        HTTPVersionNotSupported,
        Unknown5xx,
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
