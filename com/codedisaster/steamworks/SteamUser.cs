// Decompiled with JetBrains decompiler
// Type: com.codedisaster.steamworks.SteamUser
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
  public class SteamUser : SteamInterface
  {
    static IntPtr __\u003Cjniptr\u003EcreateCallback\u0028Lcom\u002Fcodedisaster\u002Fsteamworks\u002FSteamUserCallbackAdapter\u003B\u0029J;
    [SpecialName]
    private static CallerID __\u003CcallerID\u003E;
    static IntPtr __\u003Cjniptr\u003EgetSteamID\u0028J\u0029J;
    static IntPtr __\u003Cjniptr\u003EinitiateGameConnection\u0028JLjava\u002Fnio\u002FByteBuffer\u003BIIJISZ\u0029I;
    static IntPtr __\u003Cjniptr\u003EterminateGameConnection\u0028JIS\u0029V;
    static IntPtr __\u003Cjniptr\u003EstartVoiceRecording\u0028J\u0029V;
    static IntPtr __\u003Cjniptr\u003EstopVoiceRecording\u0028J\u0029V;
    static IntPtr __\u003Cjniptr\u003EgetAvailableVoice\u0028J\u005BI\u0029I;
    static IntPtr __\u003Cjniptr\u003EgetVoice\u0028JLjava\u002Fnio\u002FByteBuffer\u003BII\u005BI\u0029I;
    static IntPtr __\u003Cjniptr\u003EdecompressVoice\u0028JLjava\u002Fnio\u002FByteBuffer\u003BIILjava\u002Fnio\u002FByteBuffer\u003BII\u005BII\u0029I;
    static IntPtr __\u003Cjniptr\u003EgetVoiceOptimalSampleRate\u0028J\u0029I;
    static IntPtr __\u003Cjniptr\u003EgetAuthSessionTicket\u0028JLjava\u002Fnio\u002FByteBuffer\u003BII\u005BI\u0029I;
    static IntPtr __\u003Cjniptr\u003EbeginAuthSession\u0028JLjava\u002Fnio\u002FByteBuffer\u003BIIJ\u0029I;
    static IntPtr __\u003Cjniptr\u003EendAuthSession\u0028JJ\u0029V;
    static IntPtr __\u003Cjniptr\u003EcancelAuthTicket\u0028JI\u0029V;
    static IntPtr __\u003Cjniptr\u003EuserHasLicenseForApp\u0028JJI\u0029I;
    static IntPtr __\u003Cjniptr\u003ErequestEncryptedAppTicket\u0028JJLjava\u002Fnio\u002FByteBuffer\u003BII\u0029J;
    static IntPtr __\u003Cjniptr\u003EgetEncryptedAppTicket\u0028JLjava\u002Fnio\u002FByteBuffer\u003BII\u005BI\u0029Z;
    static IntPtr __\u003Cjniptr\u003EisBehindNAT\u0028J\u0029Z;
    static IntPtr __\u003Cjniptr\u003EadvertiseGame\u0028JJIS\u0029V;

    [LineNumberTable(32)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual SteamID getSteamID()
    {
      SteamID.__\u003Cclinit\u003E();
      return new SteamID(SteamUser.getSteamID(this.pointer));
    }

    [LineNumberTable(new byte[] {159, 169, 108, 37, 133})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public SteamUser(SteamUserCallback callback)
      : base(SteamAPI.getSteamUserPointer(), SteamUser.createCallback(new SteamUserCallbackAdapter(callback)))
    {
    }

    [Modifiers]
    private static long createCallback([In] SteamUserCallbackAdapter obj0)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamUser.__\u003Cjniptr\u003EcreateCallback\u0028Lcom\u002Fcodedisaster\u002Fsteamworks\u002FSteamUserCallbackAdapter\u003B\u0029J == IntPtr.Zero)
        SteamUser.__\u003Cjniptr\u003EcreateCallback\u0028Lcom\u002Fcodedisaster\u002Fsteamworks\u002FSteamUserCallbackAdapter\u003B\u0029J = JNI.Frame.GetFuncPtr(SteamUser.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamUser", nameof (createCallback), "(Lcom/codedisaster/steamworks/SteamUserCallbackAdapter;)J");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamUser.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamUser>.Value);
        IntPtr num4 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj0);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<long (IntPtr, IntPtr, IntPtr)>) SteamUser.__\u003Cjniptr\u003EcreateCallback\u0028Lcom\u002Fcodedisaster\u002Fsteamworks\u002FSteamUserCallbackAdapter\u003B\u0029J)(num2, num3, num4);
      }
      catch (object ex)
      {
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
    private static long getSteamID([In] long obj0)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamUser.__\u003Cjniptr\u003EgetSteamID\u0028J\u0029J == IntPtr.Zero)
        SteamUser.__\u003Cjniptr\u003EgetSteamID\u0028J\u0029J = JNI.Frame.GetFuncPtr(SteamUser.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamUser", nameof (getSteamID), "(J)J");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamUser.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamUser>.Value);
        long num4 = obj0;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<long (IntPtr, IntPtr, long)>) SteamUser.__\u003Cjniptr\u003EgetSteamID\u0028J\u0029J)((long) num2, num3, (IntPtr) num4);
      }
      catch (object ex)
      {
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
    private static int initiateGameConnection(
      [In] long obj0,
      [In] ByteBuffer obj1,
      [In] int obj2,
      [In] int obj3,
      [In] long obj4,
      [In] int obj5,
      [In] short obj6,
      [In] bool obj7)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamUser.__\u003Cjniptr\u003EinitiateGameConnection\u0028JLjava\u002Fnio\u002FByteBuffer\u003BIIJISZ\u0029I == IntPtr.Zero)
        SteamUser.__\u003Cjniptr\u003EinitiateGameConnection\u0028JLjava\u002Fnio\u002FByteBuffer\u003BIIJISZ\u0029I = JNI.Frame.GetFuncPtr(SteamUser.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamUser", nameof (initiateGameConnection), "(JLjava/nio/ByteBuffer;IIJISZ)I");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamUser.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamUser>.Value);
        long num4 = obj0;
        IntPtr num5 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj1);
        int num6 = obj2;
        int num7 = obj3;
        long num8 = obj4;
        int num9 = obj5;
        int num10 = (int) obj6;
        int num11 = obj7 ? 1 : 0;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<int (IntPtr, IntPtr, long, IntPtr, int, int, long, int, short, bool)>) SteamUser.__\u003Cjniptr\u003EinitiateGameConnection\u0028JLjava\u002Fnio\u002FByteBuffer\u003BIIJISZ\u0029I)((bool) num2, (short) num3, (int) num4, (long) num5, num6, num7, (IntPtr) num8, (long) num9, (IntPtr) num10, (IntPtr) num11);
      }
      catch (object ex)
      {
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
    private static void terminateGameConnection([In] long obj0, [In] int obj1, [In] short obj2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamUser.__\u003Cjniptr\u003EterminateGameConnection\u0028JIS\u0029V == IntPtr.Zero)
        SteamUser.__\u003Cjniptr\u003EterminateGameConnection\u0028JIS\u0029V = JNI.Frame.GetFuncPtr(SteamUser.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamUser", nameof (terminateGameConnection), "(JIS)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamUser.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamUser>.Value);
        long num4 = obj0;
        int num5 = obj1;
        int num6 = (int) obj2;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, long, int, short)>) SteamUser.__\u003Cjniptr\u003EterminateGameConnection\u0028JIS\u0029V)((short) num2, (int) num3, num4, (IntPtr) num5, (IntPtr) num6);
      }
      catch (object ex)
      {
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
    private static void startVoiceRecording([In] long obj0)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamUser.__\u003Cjniptr\u003EstartVoiceRecording\u0028J\u0029V == IntPtr.Zero)
        SteamUser.__\u003Cjniptr\u003EstartVoiceRecording\u0028J\u0029V = JNI.Frame.GetFuncPtr(SteamUser.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamUser", nameof (startVoiceRecording), "(J)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamUser.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamUser>.Value);
        long num4 = obj0;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, long)>) SteamUser.__\u003Cjniptr\u003EstartVoiceRecording\u0028J\u0029V)((long) num2, num3, (IntPtr) num4);
      }
      catch (object ex)
      {
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
    private static void stopVoiceRecording([In] long obj0)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamUser.__\u003Cjniptr\u003EstopVoiceRecording\u0028J\u0029V == IntPtr.Zero)
        SteamUser.__\u003Cjniptr\u003EstopVoiceRecording\u0028J\u0029V = JNI.Frame.GetFuncPtr(SteamUser.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamUser", nameof (stopVoiceRecording), "(J)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamUser.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamUser>.Value);
        long num4 = obj0;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, long)>) SteamUser.__\u003Cjniptr\u003EstopVoiceRecording\u0028J\u0029V)((long) num2, num3, (IntPtr) num4);
      }
      catch (object ex)
      {
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
    private static int getAvailableVoice([In] long obj0, [In] int[] obj1)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamUser.__\u003Cjniptr\u003EgetAvailableVoice\u0028J\u005BI\u0029I == IntPtr.Zero)
        SteamUser.__\u003Cjniptr\u003EgetAvailableVoice\u0028J\u005BI\u0029I = JNI.Frame.GetFuncPtr(SteamUser.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamUser", nameof (getAvailableVoice), "(J[I)I");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamUser.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamUser>.Value);
        long num4 = obj0;
        IntPtr num5 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj1);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<int (IntPtr, IntPtr, long, IntPtr)>) SteamUser.__\u003Cjniptr\u003EgetAvailableVoice\u0028J\u005BI\u0029I)(num2, (long) num3, (IntPtr) num4, num5);
      }
      catch (object ex)
      {
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
    private static int getVoice([In] long obj0, [In] ByteBuffer obj1, [In] int obj2, [In] int obj3, [In] int[] obj4)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamUser.__\u003Cjniptr\u003EgetVoice\u0028JLjava\u002Fnio\u002FByteBuffer\u003BII\u005BI\u0029I == IntPtr.Zero)
        SteamUser.__\u003Cjniptr\u003EgetVoice\u0028JLjava\u002Fnio\u002FByteBuffer\u003BII\u005BI\u0029I = JNI.Frame.GetFuncPtr(SteamUser.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamUser", nameof (getVoice), "(JLjava/nio/ByteBuffer;II[I)I");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamUser.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamUser>.Value);
        long num4 = obj0;
        IntPtr num5 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj1);
        int num6 = obj2;
        int num7 = obj3;
        IntPtr num8 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj4);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<int (IntPtr, IntPtr, long, IntPtr, int, int, IntPtr)>) SteamUser.__\u003Cjniptr\u003EgetVoice\u0028JLjava\u002Fnio\u002FByteBuffer\u003BII\u005BI\u0029I)(num2, (int) num3, (int) num4, num5, (long) num6, (IntPtr) num7, num8);
      }
      catch (object ex)
      {
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
    private static int decompressVoice(
      [In] long obj0,
      [In] ByteBuffer obj1,
      [In] int obj2,
      [In] int obj3,
      [In] ByteBuffer obj4,
      [In] int obj5,
      [In] int obj6,
      [In] int[] obj7,
      [In] int obj8)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamUser.__\u003Cjniptr\u003EdecompressVoice\u0028JLjava\u002Fnio\u002FByteBuffer\u003BIILjava\u002Fnio\u002FByteBuffer\u003BII\u005BII\u0029I == IntPtr.Zero)
        SteamUser.__\u003Cjniptr\u003EdecompressVoice\u0028JLjava\u002Fnio\u002FByteBuffer\u003BIILjava\u002Fnio\u002FByteBuffer\u003BII\u005BII\u0029I = JNI.Frame.GetFuncPtr(SteamUser.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamUser", nameof (decompressVoice), "(JLjava/nio/ByteBuffer;IILjava/nio/ByteBuffer;II[II)I");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamUser.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamUser>.Value);
        long num4 = obj0;
        IntPtr num5 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj1);
        int num6 = obj2;
        int num7 = obj3;
        IntPtr num8 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj4);
        int num9 = obj5;
        int num10 = obj6;
        IntPtr num11 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj7);
        int num12 = obj8;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<int (IntPtr, IntPtr, long, IntPtr, int, int, IntPtr, int, int, IntPtr, int)>) SteamUser.__\u003Cjniptr\u003EdecompressVoice\u0028JLjava\u002Fnio\u002FByteBuffer\u003BIILjava\u002Fnio\u002FByteBuffer\u003BII\u005BII\u0029I)((int) num2, num3, (int) num4, (int) num5, (IntPtr) num6, num7, (int) num8, (IntPtr) num9, (long) num10, num11, (IntPtr) num12);
      }
      catch (object ex)
      {
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
    private static int getVoiceOptimalSampleRate([In] long obj0)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamUser.__\u003Cjniptr\u003EgetVoiceOptimalSampleRate\u0028J\u0029I == IntPtr.Zero)
        SteamUser.__\u003Cjniptr\u003EgetVoiceOptimalSampleRate\u0028J\u0029I = JNI.Frame.GetFuncPtr(SteamUser.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamUser", nameof (getVoiceOptimalSampleRate), "(J)I");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamUser.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamUser>.Value);
        long num4 = obj0;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<int (IntPtr, IntPtr, long)>) SteamUser.__\u003Cjniptr\u003EgetVoiceOptimalSampleRate\u0028J\u0029I)((long) num2, num3, (IntPtr) num4);
      }
      catch (object ex)
      {
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
    private static int getAuthSessionTicket(
      [In] long obj0,
      [In] ByteBuffer obj1,
      [In] int obj2,
      [In] int obj3,
      [In] int[] obj4)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamUser.__\u003Cjniptr\u003EgetAuthSessionTicket\u0028JLjava\u002Fnio\u002FByteBuffer\u003BII\u005BI\u0029I == IntPtr.Zero)
        SteamUser.__\u003Cjniptr\u003EgetAuthSessionTicket\u0028JLjava\u002Fnio\u002FByteBuffer\u003BII\u005BI\u0029I = JNI.Frame.GetFuncPtr(SteamUser.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamUser", nameof (getAuthSessionTicket), "(JLjava/nio/ByteBuffer;II[I)I");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamUser.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamUser>.Value);
        long num4 = obj0;
        IntPtr num5 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj1);
        int num6 = obj2;
        int num7 = obj3;
        IntPtr num8 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj4);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<int (IntPtr, IntPtr, long, IntPtr, int, int, IntPtr)>) SteamUser.__\u003Cjniptr\u003EgetAuthSessionTicket\u0028JLjava\u002Fnio\u002FByteBuffer\u003BII\u005BI\u0029I)(num2, (int) num3, (int) num4, num5, (long) num6, (IntPtr) num7, num8);
      }
      catch (object ex)
      {
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
    private static int beginAuthSession(
      [In] long obj0,
      [In] ByteBuffer obj1,
      [In] int obj2,
      [In] int obj3,
      [In] long obj4)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamUser.__\u003Cjniptr\u003EbeginAuthSession\u0028JLjava\u002Fnio\u002FByteBuffer\u003BIIJ\u0029I == IntPtr.Zero)
        SteamUser.__\u003Cjniptr\u003EbeginAuthSession\u0028JLjava\u002Fnio\u002FByteBuffer\u003BIIJ\u0029I = JNI.Frame.GetFuncPtr(SteamUser.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamUser", nameof (beginAuthSession), "(JLjava/nio/ByteBuffer;IIJ)I");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamUser.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamUser>.Value);
        long num4 = obj0;
        IntPtr num5 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj1);
        int num6 = obj2;
        int num7 = obj3;
        long num8 = obj4;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<int (IntPtr, IntPtr, long, IntPtr, int, int, long)>) SteamUser.__\u003Cjniptr\u003EbeginAuthSession\u0028JLjava\u002Fnio\u002FByteBuffer\u003BIIJ\u0029I)((long) num2, (int) num3, (int) num4, num5, (long) num6, (IntPtr) num7, (IntPtr) num8);
      }
      catch (object ex)
      {
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
    private static void endAuthSession([In] long obj0, [In] long obj1)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamUser.__\u003Cjniptr\u003EendAuthSession\u0028JJ\u0029V == IntPtr.Zero)
        SteamUser.__\u003Cjniptr\u003EendAuthSession\u0028JJ\u0029V = JNI.Frame.GetFuncPtr(SteamUser.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamUser", nameof (endAuthSession), "(JJ)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamUser.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamUser>.Value);
        long num4 = obj0;
        long num5 = obj1;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, long, long)>) SteamUser.__\u003Cjniptr\u003EendAuthSession\u0028JJ\u0029V)((long) num2, (long) num3, (IntPtr) num4, (IntPtr) num5);
      }
      catch (object ex)
      {
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
    private static void cancelAuthTicket([In] long obj0, [In] int obj1)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamUser.__\u003Cjniptr\u003EcancelAuthTicket\u0028JI\u0029V == IntPtr.Zero)
        SteamUser.__\u003Cjniptr\u003EcancelAuthTicket\u0028JI\u0029V = JNI.Frame.GetFuncPtr(SteamUser.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamUser", nameof (cancelAuthTicket), "(JI)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamUser.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamUser>.Value);
        long num4 = obj0;
        int num5 = obj1;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, long, int)>) SteamUser.__\u003Cjniptr\u003EcancelAuthTicket\u0028JI\u0029V)((int) num2, (long) num3, (IntPtr) num4, (IntPtr) num5);
      }
      catch (object ex)
      {
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
    private static int userHasLicenseForApp([In] long obj0, [In] long obj1, [In] int obj2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamUser.__\u003Cjniptr\u003EuserHasLicenseForApp\u0028JJI\u0029I == IntPtr.Zero)
        SteamUser.__\u003Cjniptr\u003EuserHasLicenseForApp\u0028JJI\u0029I = JNI.Frame.GetFuncPtr(SteamUser.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamUser", nameof (userHasLicenseForApp), "(JJI)I");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamUser.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamUser>.Value);
        long num4 = obj0;
        long num5 = obj1;
        int num6 = obj2;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<int (IntPtr, IntPtr, long, long, int)>) SteamUser.__\u003Cjniptr\u003EuserHasLicenseForApp\u0028JJI\u0029I)((int) num2, (long) num3, num4, (IntPtr) num5, (IntPtr) num6);
      }
      catch (object ex)
      {
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
    private static long requestEncryptedAppTicket(
      [In] long obj0,
      [In] long obj1,
      [In] ByteBuffer obj2,
      [In] int obj3,
      [In] int obj4)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamUser.__\u003Cjniptr\u003ErequestEncryptedAppTicket\u0028JJLjava\u002Fnio\u002FByteBuffer\u003BII\u0029J == IntPtr.Zero)
        SteamUser.__\u003Cjniptr\u003ErequestEncryptedAppTicket\u0028JJLjava\u002Fnio\u002FByteBuffer\u003BII\u0029J = JNI.Frame.GetFuncPtr(SteamUser.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamUser", nameof (requestEncryptedAppTicket), "(JJLjava/nio/ByteBuffer;II)J");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamUser.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamUser>.Value);
        long num4 = obj0;
        long num5 = obj1;
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj2);
        int num7 = obj3;
        int num8 = obj4;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<long (IntPtr, IntPtr, long, long, IntPtr, int, int)>) SteamUser.__\u003Cjniptr\u003ErequestEncryptedAppTicket\u0028JJLjava\u002Fnio\u002FByteBuffer\u003BII\u0029J)((int) num2, (int) num3, (IntPtr) num4, num5, (long) num6, (IntPtr) num7, (IntPtr) num8);
      }
      catch (object ex)
      {
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
    private static bool getEncryptedAppTicket(
      [In] long obj0,
      [In] ByteBuffer obj1,
      [In] int obj2,
      [In] int obj3,
      [In] int[] obj4)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamUser.__\u003Cjniptr\u003EgetEncryptedAppTicket\u0028JLjava\u002Fnio\u002FByteBuffer\u003BII\u005BI\u0029Z == IntPtr.Zero)
        SteamUser.__\u003Cjniptr\u003EgetEncryptedAppTicket\u0028JLjava\u002Fnio\u002FByteBuffer\u003BII\u005BI\u0029Z = JNI.Frame.GetFuncPtr(SteamUser.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamUser", nameof (getEncryptedAppTicket), "(JLjava/nio/ByteBuffer;II[I)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamUser.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamUser>.Value);
        long num4 = obj0;
        IntPtr num5 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj1);
        int num6 = obj2;
        int num7 = obj3;
        IntPtr num8 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj4);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, long, IntPtr, int, int, IntPtr)>) SteamUser.__\u003Cjniptr\u003EgetEncryptedAppTicket\u0028JLjava\u002Fnio\u002FByteBuffer\u003BII\u005BI\u0029Z)(num2, (int) num3, (int) num4, num5, (long) num6, (IntPtr) num7, num8);
      }
      catch (object ex)
      {
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
    private static bool isBehindNAT([In] long obj0)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamUser.__\u003Cjniptr\u003EisBehindNAT\u0028J\u0029Z == IntPtr.Zero)
        SteamUser.__\u003Cjniptr\u003EisBehindNAT\u0028J\u0029Z = JNI.Frame.GetFuncPtr(SteamUser.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamUser", nameof (isBehindNAT), "(J)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamUser.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamUser>.Value);
        long num4 = obj0;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, long)>) SteamUser.__\u003Cjniptr\u003EisBehindNAT\u0028J\u0029Z)((long) num2, num3, (IntPtr) num4);
      }
      catch (object ex)
      {
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
    private static void advertiseGame([In] long obj0, [In] long obj1, [In] int obj2, [In] short obj3)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamUser.__\u003Cjniptr\u003EadvertiseGame\u0028JJIS\u0029V == IntPtr.Zero)
        SteamUser.__\u003Cjniptr\u003EadvertiseGame\u0028JJIS\u0029V = JNI.Frame.GetFuncPtr(SteamUser.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamUser", nameof (advertiseGame), "(JJIS)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamUser.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamUser>.Value);
        long num4 = obj0;
        long num5 = obj1;
        int num6 = obj2;
        int num7 = (int) obj3;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, long, long, int, short)>) SteamUser.__\u003Cjniptr\u003EadvertiseGame\u0028JJIS\u0029V)((short) num2, (int) num3, num4, num5, (IntPtr) num6, (IntPtr) num7);
      }
      catch (object ex)
      {
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
    [LineNumberTable(new byte[] {159, 133, 134, 104, 176, 191, 3, 100, 168})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int initiateGameConnection(
      ByteBuffer authBlob,
      SteamID steamIDGameServer,
      int serverIP,
      short serverPort,
      bool secure)
    {
      int num1 = (int) serverPort;
      int num2 = secure ? 1 : 0;
      if (!authBlob.isDirect())
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new SteamException("Direct buffer required!");
      }
      int num3 = SteamUser.initiateGameConnection(this.pointer, authBlob, ((Buffer) authBlob).position(), ((Buffer) authBlob).remaining(), steamIDGameServer.handle, serverIP, (short) num1, num2 != 0);
      if (num3 > 0)
        ((Buffer) authBlob).limit(num3);
      return num3;
    }

    [LineNumberTable(new byte[] {159, 129, 98, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void terminateGameConnection(int serverIP, short serverPort)
    {
      int num = (int) serverPort;
      SteamUser.terminateGameConnection(this.pointer, serverIP, (short) num);
    }

    [LineNumberTable(new byte[] {7, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void startVoiceRecording() => SteamUser.startVoiceRecording(this.pointer);

    [LineNumberTable(new byte[] {11, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void stopVoiceRecording() => SteamUser.stopVoiceRecording(this.pointer);

    [LineNumberTable(new byte[] {15, 141})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual SteamUser.VoiceResult getAvailableVoice(int[] bytesAvailable) => SteamUser.VoiceResult.byOrdinal(SteamUser.getAvailableVoice(this.pointer, bytesAvailable));

    [Throws(new string[] {"com.codedisaster.steamworks.SteamException"})]
    [LineNumberTable(new byte[] {22, 104, 176, 154})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual SteamUser.VoiceResult getVoice(ByteBuffer voiceData, int[] bytesWritten)
    {
      if (!voiceData.isDirect())
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new SteamException("Direct buffer required!");
      }
      return SteamUser.VoiceResult.byOrdinal(SteamUser.getVoice(this.pointer, voiceData, ((Buffer) voiceData).position(), ((Buffer) voiceData).remaining(), bytesWritten));
    }

    [Throws(new string[] {"com.codedisaster.steamworks.SteamException"})]
    [LineNumberTable(new byte[] {33, 104, 176, 104, 176, 104, 109, 14, 230, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual SteamUser.VoiceResult decompressVoice(
      ByteBuffer voiceData,
      ByteBuffer audioData,
      int[] bytesWritten,
      int desiredSampleRate)
    {
      if (!voiceData.isDirect())
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new SteamException("Direct buffer required!");
      }
      if (!audioData.isDirect())
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new SteamException("Direct buffer required!");
      }
      return SteamUser.VoiceResult.byOrdinal(SteamUser.decompressVoice(this.pointer, voiceData, ((Buffer) voiceData).position(), ((Buffer) voiceData).remaining(), audioData, ((Buffer) audioData).position(), ((Buffer) audioData).remaining(), bytesWritten, desiredSampleRate));
    }

    [LineNumberTable(100)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getVoiceOptimalSampleRate() => SteamUser.getVoiceOptimalSampleRate(this.pointer);

    [Throws(new string[] {"com.codedisaster.steamworks.SteamException"})]
    [LineNumberTable(new byte[] {55, 104, 176, 104, 44, 166, 102, 170})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual SteamAuthTicket getAuthSessionTicket(
      ByteBuffer authTicket,
      int[] sizeInBytes)
    {
      if (!authTicket.isDirect())
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new SteamException("Direct buffer required!");
      }
      int authSessionTicket = SteamUser.getAuthSessionTicket(this.pointer, authTicket, ((Buffer) authTicket).position(), ((Buffer) authTicket).remaining(), sizeInBytes);
      if (authSessionTicket != 0)
        ((Buffer) authTicket).limit(sizeInBytes[0]);
      return new SteamAuthTicket((long) authSessionTicket);
    }

    [Throws(new string[] {"com.codedisaster.steamworks.SteamException"})]
    [LineNumberTable(new byte[] {71, 104, 176, 104, 49, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual SteamAuth.BeginAuthSessionResult beginAuthSession(
      ByteBuffer authTicket,
      SteamID steamID)
    {
      if (!authTicket.isDirect())
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new SteamException("Direct buffer required!");
      }
      return SteamAuth.BeginAuthSessionResult.byOrdinal(SteamUser.beginAuthSession(this.pointer, authTicket, ((Buffer) authTicket).position(), ((Buffer) authTicket).remaining(), steamID.handle));
    }

    [LineNumberTable(new byte[] {82, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void endAuthSession(SteamID steamID) => SteamUser.endAuthSession(this.pointer, steamID.handle);

    [LineNumberTable(new byte[] {86, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void cancelAuthTicket(SteamAuthTicket authTicket) => SteamUser.cancelAuthTicket(this.pointer, (int) authTicket.handle);

    [LineNumberTable(140)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual SteamAuth.UserHasLicenseForAppResult userHasLicenseForApp(
      SteamID steamID,
      int appID)
    {
      return SteamAuth.UserHasLicenseForAppResult.byOrdinal(SteamUser.userHasLicenseForApp(this.pointer, steamID.handle, appID));
    }

    [Throws(new string[] {"com.codedisaster.steamworks.SteamException"})]
    [LineNumberTable(new byte[] {95, 104, 176, 110, 43})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual SteamAPICall requestEncryptedAppTicket(ByteBuffer dataToInclude)
    {
      if (!dataToInclude.isDirect())
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new SteamException("Direct buffer required!");
      }
      return new SteamAPICall(SteamUser.requestEncryptedAppTicket(this.pointer, this.callback, dataToInclude, ((Buffer) dataToInclude).position(), ((Buffer) dataToInclude).remaining()));
    }

    [Throws(new string[] {"com.codedisaster.steamworks.SteamException"})]
    [LineNumberTable(new byte[] {105, 104, 176})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool getEncryptedAppTicket(ByteBuffer ticket, int[] sizeInBytes)
    {
      if (!ticket.isDirect())
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new SteamException("Direct buffer required!");
      }
      return SteamUser.getEncryptedAppTicket(this.pointer, ticket, ((Buffer) ticket).position(), ((Buffer) ticket).remaining(), sizeInBytes);
    }

    [LineNumberTable(163)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isBehindNAT() => SteamUser.isBehindNAT(this.pointer);

    [LineNumberTable(new byte[] {159, 101, 162, 115})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void advertiseGame(SteamID steamIDGameServer, int serverIP, short serverPort)
    {
      int num = (int) serverPort;
      SteamUser.advertiseGame(this.pointer, steamIDGameServer.handle, serverIP, (short) num);
    }

    [Modifiers]
    [LineNumberTable(5)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void dispose() => base.dispose();

    new static CallerID __\u003CGetCallerID\u003E()
    {
      if (SteamUser.__\u003CcallerID\u003E == null)
        SteamUser.__\u003CcallerID\u003E = (CallerID) new SteamUser.__\u003CCallerID\u003E();
      return SteamUser.__\u003CcallerID\u003E;
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
    [Signature("Ljava/lang/Enum<Lcom/codedisaster/steamworks/SteamUser$VoiceResult;>;")]
    [Modifiers]
    [Serializable]
    public sealed class VoiceResult : Enum
    {
      [Modifiers]
      internal static SteamUser.VoiceResult __\u003C\u003EOK;
      [Modifiers]
      internal static SteamUser.VoiceResult __\u003C\u003ENotInitialized;
      [Modifiers]
      internal static SteamUser.VoiceResult __\u003C\u003ENotRecording;
      [Modifiers]
      internal static SteamUser.VoiceResult __\u003C\u003ENoData;
      [Modifiers]
      internal static SteamUser.VoiceResult __\u003C\u003EBufferTooSmall;
      [Modifiers]
      internal static SteamUser.VoiceResult __\u003C\u003EDataCorrupted;
      [Modifiers]
      internal static SteamUser.VoiceResult __\u003C\u003ERestricted;
      [Modifiers]
      internal static SteamUser.VoiceResult __\u003C\u003EUnsupportedCodec;
      [Modifiers]
      internal static SteamUser.VoiceResult __\u003C\u003EReceiverOutOfDate;
      [Modifiers]
      internal static SteamUser.VoiceResult __\u003C\u003EReceiverDidNotAnswer;
      [Modifiers]
      private static SteamUser.VoiceResult[] values;
      [Modifiers]
      private static SteamUser.VoiceResult[] \u0024VALUES;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [Signature("()V")]
      [LineNumberTable(7)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private VoiceResult([In] string obj0, [In] int obj1)
        : base(obj0, obj1)
      {
        GC.KeepAlive((object) this);
      }

      [LineNumberTable(7)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static SteamUser.VoiceResult[] values() => (SteamUser.VoiceResult[]) SteamUser.VoiceResult.\u0024VALUES.Clone();

      [LineNumberTable(7)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static SteamUser.VoiceResult valueOf(string name) => (SteamUser.VoiceResult) Enum.valueOf((Class) ClassLiteral<SteamUser.VoiceResult>.Value, name);

      [LineNumberTable(22)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal static SteamUser.VoiceResult byOrdinal([In] int obj0) => SteamUser.VoiceResult.values[obj0];

      [LineNumberTable(new byte[] {159, 140, 77, 112, 112, 112, 112, 112, 112, 112, 112, 112, 241, 54, 255, 62, 76})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static VoiceResult()
      {
        if (ByteCodeHelper.isAlreadyInited("com.codedisaster.steamworks.SteamUser$VoiceResult"))
          return;
        SteamUser.VoiceResult.__\u003C\u003EOK = new SteamUser.VoiceResult(nameof (OK), 0);
        SteamUser.VoiceResult.__\u003C\u003ENotInitialized = new SteamUser.VoiceResult(nameof (NotInitialized), 1);
        SteamUser.VoiceResult.__\u003C\u003ENotRecording = new SteamUser.VoiceResult(nameof (NotRecording), 2);
        SteamUser.VoiceResult.__\u003C\u003ENoData = new SteamUser.VoiceResult(nameof (NoData), 3);
        SteamUser.VoiceResult.__\u003C\u003EBufferTooSmall = new SteamUser.VoiceResult(nameof (BufferTooSmall), 4);
        SteamUser.VoiceResult.__\u003C\u003EDataCorrupted = new SteamUser.VoiceResult(nameof (DataCorrupted), 5);
        SteamUser.VoiceResult.__\u003C\u003ERestricted = new SteamUser.VoiceResult(nameof (Restricted), 6);
        SteamUser.VoiceResult.__\u003C\u003EUnsupportedCodec = new SteamUser.VoiceResult(nameof (UnsupportedCodec), 7);
        SteamUser.VoiceResult.__\u003C\u003EReceiverOutOfDate = new SteamUser.VoiceResult(nameof (ReceiverOutOfDate), 8);
        SteamUser.VoiceResult.__\u003C\u003EReceiverDidNotAnswer = new SteamUser.VoiceResult(nameof (ReceiverDidNotAnswer), 9);
        SteamUser.VoiceResult.\u0024VALUES = new SteamUser.VoiceResult[10]
        {
          SteamUser.VoiceResult.__\u003C\u003EOK,
          SteamUser.VoiceResult.__\u003C\u003ENotInitialized,
          SteamUser.VoiceResult.__\u003C\u003ENotRecording,
          SteamUser.VoiceResult.__\u003C\u003ENoData,
          SteamUser.VoiceResult.__\u003C\u003EBufferTooSmall,
          SteamUser.VoiceResult.__\u003C\u003EDataCorrupted,
          SteamUser.VoiceResult.__\u003C\u003ERestricted,
          SteamUser.VoiceResult.__\u003C\u003EUnsupportedCodec,
          SteamUser.VoiceResult.__\u003C\u003EReceiverOutOfDate,
          SteamUser.VoiceResult.__\u003C\u003EReceiverDidNotAnswer
        };
        SteamUser.VoiceResult.values = SteamUser.VoiceResult.values();
      }

      [Modifiers]
      public static SteamUser.VoiceResult OK
      {
        [HideFromJava] get => SteamUser.VoiceResult.__\u003C\u003EOK;
      }

      [Modifiers]
      public static SteamUser.VoiceResult NotInitialized
      {
        [HideFromJava] get => SteamUser.VoiceResult.__\u003C\u003ENotInitialized;
      }

      [Modifiers]
      public static SteamUser.VoiceResult NotRecording
      {
        [HideFromJava] get => SteamUser.VoiceResult.__\u003C\u003ENotRecording;
      }

      [Modifiers]
      public static SteamUser.VoiceResult NoData
      {
        [HideFromJava] get => SteamUser.VoiceResult.__\u003C\u003ENoData;
      }

      [Modifiers]
      public static SteamUser.VoiceResult BufferTooSmall
      {
        [HideFromJava] get => SteamUser.VoiceResult.__\u003C\u003EBufferTooSmall;
      }

      [Modifiers]
      public static SteamUser.VoiceResult DataCorrupted
      {
        [HideFromJava] get => SteamUser.VoiceResult.__\u003C\u003EDataCorrupted;
      }

      [Modifiers]
      public static SteamUser.VoiceResult Restricted
      {
        [HideFromJava] get => SteamUser.VoiceResult.__\u003C\u003ERestricted;
      }

      [Modifiers]
      public static SteamUser.VoiceResult UnsupportedCodec
      {
        [HideFromJava] get => SteamUser.VoiceResult.__\u003C\u003EUnsupportedCodec;
      }

      [Modifiers]
      public static SteamUser.VoiceResult ReceiverOutOfDate
      {
        [HideFromJava] get => SteamUser.VoiceResult.__\u003C\u003EReceiverOutOfDate;
      }

      [Modifiers]
      public static SteamUser.VoiceResult ReceiverDidNotAnswer
      {
        [HideFromJava] get => SteamUser.VoiceResult.__\u003C\u003EReceiverDidNotAnswer;
      }

      [HideFromJava]
      [Serializable]
      public enum __Enum
      {
        OK,
        NotInitialized,
        NotRecording,
        NoData,
        BufferTooSmall,
        DataCorrupted,
        Restricted,
        UnsupportedCodec,
        ReceiverOutOfDate,
        ReceiverDidNotAnswer,
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
