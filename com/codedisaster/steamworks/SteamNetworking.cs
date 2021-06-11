// Decompiled with JetBrains decompiler
// Type: com.codedisaster.steamworks.SteamNetworking
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
  public class SteamNetworking : SteamInterface
  {
    [Modifiers]
    private int[] tmpIntResult;
    [Modifiers]
    private long[] tmpLongResult;
    static IntPtr __\u003Cjniptr\u003EcreateCallback\u0028Lcom\u002Fcodedisaster\u002Fsteamworks\u002FSteamNetworkingCallbackAdapter\u003B\u0029J;
    [SpecialName]
    private static CallerID __\u003CcallerID\u003E;
    static IntPtr __\u003Cjniptr\u003EsendP2PPacket\u0028JJLjava\u002Fnio\u002FByteBuffer\u003BIIII\u0029Z;
    static IntPtr __\u003Cjniptr\u003EisP2PPacketAvailable\u0028J\u005BII\u0029Z;
    static IntPtr __\u003Cjniptr\u003EreadP2PPacket\u0028JLjava\u002Fnio\u002FByteBuffer\u003BII\u005BI\u005BJI\u0029Z;
    static IntPtr __\u003Cjniptr\u003EacceptP2PSessionWithUser\u0028JJ\u0029Z;
    static IntPtr __\u003Cjniptr\u003EcloseP2PSessionWithUser\u0028JJ\u0029Z;
    static IntPtr __\u003Cjniptr\u003EcloseP2PChannelWithUser\u0028JJI\u0029Z;
    static IntPtr __\u003Cjniptr\u003EgetP2PSessionState\u0028JJLcom\u002Fcodedisaster\u002Fsteamworks\u002FSteamNetworking\u0024P2PSessionState\u003B\u0029Z;
    static IntPtr __\u003Cjniptr\u003EallowP2PPacketRelay\u0028JZ\u0029Z;

    [LineNumberTable(new byte[] {45, 116, 137})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int isP2PPacketAvailable(int channel) => SteamNetworking.isP2PPacketAvailable(this.pointer, this.tmpIntResult, channel) ? this.tmpIntResult[0] : 0;

    [Throws(new string[] {"com.codedisaster.steamworks.SteamException"})]
    [LineNumberTable(new byte[] {59, 104, 176, 127, 8, 110, 169})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int readP2PPacket(SteamID steamIDRemote, ByteBuffer dest, int channel)
    {
      if (!dest.isDirect())
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new SteamException("Direct buffer required!");
      }
      if (!SteamNetworking.readP2PPacket(this.pointer, dest, ((Buffer) dest).position(), ((Buffer) dest).remaining(), this.tmpIntResult, this.tmpLongResult, channel))
        return 0;
      steamIDRemote.handle = this.tmpLongResult[0];
      return this.tmpIntResult[0];
    }

    [LineNumberTable(new byte[] {25, 108, 37, 133})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public SteamNetworking(SteamNetworkingCallback callback)
      : this(SteamAPI.getSteamNetworkingPointer(), SteamNetworking.createCallback(new SteamNetworkingCallbackAdapter(callback)))
    {
    }

    [Throws(new string[] {"com.codedisaster.steamworks.SteamException"})]
    [LineNumberTable(new byte[] {36, 104, 176, 110, 51})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool sendP2PPacket(
      SteamID steamIDRemote,
      ByteBuffer data,
      SteamNetworking.P2PSend sendType,
      int channel)
    {
      if (!data.isDirect())
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new SteamException("Direct buffer required!");
      }
      return SteamNetworking.sendP2PPacket(this.pointer, steamIDRemote.handle, data, ((Buffer) data).position(), ((Buffer) data).remaining(), sendType.ordinal(), channel);
    }

    [LineNumberTable(126)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool closeP2PSessionWithUser(SteamID steamIDRemote) => SteamNetworking.closeP2PSessionWithUser(this.pointer, steamIDRemote.handle);

    [LineNumberTable(122)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool acceptP2PSessionWithUser(SteamID steamIDRemote) => SteamNetworking.acceptP2PSessionWithUser(this.pointer, steamIDRemote.handle);

    [LineNumberTable(134)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool getP2PSessionState(
      SteamID steamIDRemote,
      SteamNetworking.P2PSessionState connectionState)
    {
      return SteamNetworking.getP2PSessionState(this.pointer, steamIDRemote.handle, connectionState);
    }

    [Modifiers]
    private static long createCallback([In] SteamNetworkingCallbackAdapter obj0)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamNetworking.__\u003Cjniptr\u003EcreateCallback\u0028Lcom\u002Fcodedisaster\u002Fsteamworks\u002FSteamNetworkingCallbackAdapter\u003B\u0029J == IntPtr.Zero)
        SteamNetworking.__\u003Cjniptr\u003EcreateCallback\u0028Lcom\u002Fcodedisaster\u002Fsteamworks\u002FSteamNetworkingCallbackAdapter\u003B\u0029J = JNI.Frame.GetFuncPtr(SteamNetworking.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamNetworking", nameof (createCallback), "(Lcom/codedisaster/steamworks/SteamNetworkingCallbackAdapter;)J");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamNetworking.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamNetworking>.Value);
        IntPtr num4 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj0);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<long (IntPtr, IntPtr, IntPtr)>) SteamNetworking.__\u003Cjniptr\u003EcreateCallback\u0028Lcom\u002Fcodedisaster\u002Fsteamworks\u002FSteamNetworkingCallbackAdapter\u003B\u0029J)(num2, num3, num4);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [LineNumberTable(new byte[] {30, 234, 55, 108, 236, 73})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal SteamNetworking([In] long obj0, [In] long obj1)
      : base(obj0, obj1)
    {
      SteamNetworking steamNetworking = this;
      this.tmpIntResult = new int[1];
      this.tmpLongResult = new long[1];
    }

    [Modifiers]
    private static bool sendP2PPacket(
      [In] long obj0,
      [In] long obj1,
      [In] ByteBuffer obj2,
      [In] int obj3,
      [In] int obj4,
      [In] int obj5,
      [In] int obj6)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamNetworking.__\u003Cjniptr\u003EsendP2PPacket\u0028JJLjava\u002Fnio\u002FByteBuffer\u003BIIII\u0029Z == IntPtr.Zero)
        SteamNetworking.__\u003Cjniptr\u003EsendP2PPacket\u0028JJLjava\u002Fnio\u002FByteBuffer\u003BIIII\u0029Z = JNI.Frame.GetFuncPtr(SteamNetworking.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamNetworking", nameof (sendP2PPacket), "(JJLjava/nio/ByteBuffer;IIII)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamNetworking.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamNetworking>.Value);
        long num4 = obj0;
        long num5 = obj1;
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj2);
        int num7 = obj3;
        int num8 = obj4;
        int num9 = obj5;
        int num10 = obj6;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, long, long, IntPtr, int, int, int, int)>) SteamNetworking.__\u003Cjniptr\u003EsendP2PPacket\u0028JJLjava\u002Fnio\u002FByteBuffer\u003BIIII\u0029Z)((int) num2, (int) num3, (int) num4, (int) num5, num6, (long) num7, (long) num8, (IntPtr) num9, (IntPtr) num10);
      }
      catch (object ex)
      {
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
    private static bool isP2PPacketAvailable([In] long obj0, [In] int[] obj1, [In] int obj2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamNetworking.__\u003Cjniptr\u003EisP2PPacketAvailable\u0028J\u005BII\u0029Z == IntPtr.Zero)
        SteamNetworking.__\u003Cjniptr\u003EisP2PPacketAvailable\u0028J\u005BII\u0029Z = JNI.Frame.GetFuncPtr(SteamNetworking.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamNetworking", nameof (isP2PPacketAvailable), "(J[II)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamNetworking.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamNetworking>.Value);
        long num4 = obj0;
        IntPtr num5 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj1);
        int num6 = obj2;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, long, IntPtr, int)>) SteamNetworking.__\u003Cjniptr\u003EisP2PPacketAvailable\u0028J\u005BII\u0029Z)((int) num2, num3, num4, num5, (IntPtr) num6);
      }
      catch (object ex)
      {
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
    private static bool readP2PPacket(
      [In] long obj0,
      [In] ByteBuffer obj1,
      [In] int obj2,
      [In] int obj3,
      [In] int[] obj4,
      [In] long[] obj5,
      [In] int obj6)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamNetworking.__\u003Cjniptr\u003EreadP2PPacket\u0028JLjava\u002Fnio\u002FByteBuffer\u003BII\u005BI\u005BJI\u0029Z == IntPtr.Zero)
        SteamNetworking.__\u003Cjniptr\u003EreadP2PPacket\u0028JLjava\u002Fnio\u002FByteBuffer\u003BII\u005BI\u005BJI\u0029Z = JNI.Frame.GetFuncPtr(SteamNetworking.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamNetworking", nameof (readP2PPacket), "(JLjava/nio/ByteBuffer;II[I[JI)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamNetworking.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamNetworking>.Value);
        long num4 = obj0;
        IntPtr num5 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj1);
        int num6 = obj2;
        int num7 = obj3;
        IntPtr num8 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj4);
        IntPtr num9 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj5);
        int num10 = obj6;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, long, IntPtr, int, int, IntPtr, IntPtr, int)>) SteamNetworking.__\u003Cjniptr\u003EreadP2PPacket\u0028JLjava\u002Fnio\u002FByteBuffer\u003BII\u005BI\u005BJI\u0029Z)((int) num2, num3, (IntPtr) num4, (int) num5, num6, (IntPtr) num7, (long) num8, num9, (IntPtr) num10);
      }
      catch (object ex)
      {
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
    private static bool acceptP2PSessionWithUser([In] long obj0, [In] long obj1)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamNetworking.__\u003Cjniptr\u003EacceptP2PSessionWithUser\u0028JJ\u0029Z == IntPtr.Zero)
        SteamNetworking.__\u003Cjniptr\u003EacceptP2PSessionWithUser\u0028JJ\u0029Z = JNI.Frame.GetFuncPtr(SteamNetworking.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamNetworking", nameof (acceptP2PSessionWithUser), "(JJ)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamNetworking.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamNetworking>.Value);
        long num4 = obj0;
        long num5 = obj1;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, long, long)>) SteamNetworking.__\u003Cjniptr\u003EacceptP2PSessionWithUser\u0028JJ\u0029Z)((long) num2, (long) num3, (IntPtr) num4, (IntPtr) num5);
      }
      catch (object ex)
      {
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
    private static bool closeP2PSessionWithUser([In] long obj0, [In] long obj1)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamNetworking.__\u003Cjniptr\u003EcloseP2PSessionWithUser\u0028JJ\u0029Z == IntPtr.Zero)
        SteamNetworking.__\u003Cjniptr\u003EcloseP2PSessionWithUser\u0028JJ\u0029Z = JNI.Frame.GetFuncPtr(SteamNetworking.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamNetworking", nameof (closeP2PSessionWithUser), "(JJ)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamNetworking.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamNetworking>.Value);
        long num4 = obj0;
        long num5 = obj1;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, long, long)>) SteamNetworking.__\u003Cjniptr\u003EcloseP2PSessionWithUser\u0028JJ\u0029Z)((long) num2, (long) num3, (IntPtr) num4, (IntPtr) num5);
      }
      catch (object ex)
      {
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
    private static bool closeP2PChannelWithUser([In] long obj0, [In] long obj1, [In] int obj2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamNetworking.__\u003Cjniptr\u003EcloseP2PChannelWithUser\u0028JJI\u0029Z == IntPtr.Zero)
        SteamNetworking.__\u003Cjniptr\u003EcloseP2PChannelWithUser\u0028JJI\u0029Z = JNI.Frame.GetFuncPtr(SteamNetworking.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamNetworking", nameof (closeP2PChannelWithUser), "(JJI)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamNetworking.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamNetworking>.Value);
        long num4 = obj0;
        long num5 = obj1;
        int num6 = obj2;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, long, long, int)>) SteamNetworking.__\u003Cjniptr\u003EcloseP2PChannelWithUser\u0028JJI\u0029Z)((int) num2, (long) num3, num4, (IntPtr) num5, (IntPtr) num6);
      }
      catch (object ex)
      {
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
    private static bool getP2PSessionState(
      [In] long obj0,
      [In] long obj1,
      [In] SteamNetworking.P2PSessionState obj2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamNetworking.__\u003Cjniptr\u003EgetP2PSessionState\u0028JJLcom\u002Fcodedisaster\u002Fsteamworks\u002FSteamNetworking\u0024P2PSessionState\u003B\u0029Z == IntPtr.Zero)
        SteamNetworking.__\u003Cjniptr\u003EgetP2PSessionState\u0028JJLcom\u002Fcodedisaster\u002Fsteamworks\u002FSteamNetworking\u0024P2PSessionState\u003B\u0029Z = JNI.Frame.GetFuncPtr(SteamNetworking.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamNetworking", nameof (getP2PSessionState), "(JJLcom/codedisaster/steamworks/SteamNetworking$P2PSessionState;)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamNetworking.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamNetworking>.Value);
        long num4 = obj0;
        long num5 = obj1;
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj2);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, long, long, IntPtr)>) SteamNetworking.__\u003Cjniptr\u003EgetP2PSessionState\u0028JJLcom\u002Fcodedisaster\u002Fsteamworks\u002FSteamNetworking\u0024P2PSessionState\u003B\u0029Z)(num2, (long) num3, num4, (IntPtr) num5, num6);
      }
      catch (object ex)
      {
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
    private static bool allowP2PPacketRelay([In] long obj0, [In] bool obj1)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamNetworking.__\u003Cjniptr\u003EallowP2PPacketRelay\u0028JZ\u0029Z == IntPtr.Zero)
        SteamNetworking.__\u003Cjniptr\u003EallowP2PPacketRelay\u0028JZ\u0029Z = JNI.Frame.GetFuncPtr(SteamNetworking.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamNetworking", nameof (allowP2PPacketRelay), "(JZ)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamNetworking.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamNetworking>.Value);
        long num4 = obj0;
        int num5 = obj1 ? 1 : 0;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, long, bool)>) SteamNetworking.__\u003Cjniptr\u003EallowP2PPacketRelay\u0028JZ\u0029Z)((bool) num2, (long) num3, (IntPtr) num4, (IntPtr) num5);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [LineNumberTable(130)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool closeP2PChannelWithUser(SteamID steamIDRemote, int channel) => SteamNetworking.closeP2PChannelWithUser(this.pointer, steamIDRemote.handle, channel);

    [LineNumberTable(138)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool allowP2PPacketRelay(bool allow) => SteamNetworking.allowP2PPacketRelay(this.pointer, allow);

    [Modifiers]
    [LineNumberTable(5)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void dispose() => base.dispose();

    new static CallerID __\u003CGetCallerID\u003E()
    {
      if (SteamNetworking.__\u003CcallerID\u003E == null)
        SteamNetworking.__\u003CcallerID\u003E = (CallerID) new SteamNetworking.__\u003CCallerID\u003E();
      return SteamNetworking.__\u003CcallerID\u003E;
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
    [Signature("Ljava/lang/Enum<Lcom/codedisaster/steamworks/SteamNetworking$P2PSend;>;")]
    [Modifiers]
    [Serializable]
    public sealed class P2PSend : Enum
    {
      [Modifiers]
      internal static SteamNetworking.P2PSend __\u003C\u003EUnreliable;
      [Modifiers]
      internal static SteamNetworking.P2PSend __\u003C\u003EUnreliableNoDelay;
      [Modifiers]
      internal static SteamNetworking.P2PSend __\u003C\u003EReliable;
      [Modifiers]
      internal static SteamNetworking.P2PSend __\u003C\u003EReliableWithBuffering;
      [Modifiers]
      private static SteamNetworking.P2PSend[] \u0024VALUES;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [Signature("()V")]
      [LineNumberTable(7)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private P2PSend([In] string obj0, [In] int obj1)
        : base(obj0, obj1)
      {
        GC.KeepAlive((object) this);
      }

      [LineNumberTable(7)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static SteamNetworking.P2PSend[] values() => (SteamNetworking.P2PSend[]) SteamNetworking.P2PSend.\u0024VALUES.Clone();

      [LineNumberTable(7)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static SteamNetworking.P2PSend valueOf(string name) => (SteamNetworking.P2PSend) Enum.valueOf((Class) ClassLiteral<SteamNetworking.P2PSend>.Value, name);

      [LineNumberTable(new byte[] {159, 140, 77, 112, 112, 112, 240, 60})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static P2PSend()
      {
        if (ByteCodeHelper.isAlreadyInited("com.codedisaster.steamworks.SteamNetworking$P2PSend"))
          return;
        SteamNetworking.P2PSend.__\u003C\u003EUnreliable = new SteamNetworking.P2PSend(nameof (Unreliable), 0);
        SteamNetworking.P2PSend.__\u003C\u003EUnreliableNoDelay = new SteamNetworking.P2PSend(nameof (UnreliableNoDelay), 1);
        SteamNetworking.P2PSend.__\u003C\u003EReliable = new SteamNetworking.P2PSend(nameof (Reliable), 2);
        SteamNetworking.P2PSend.__\u003C\u003EReliableWithBuffering = new SteamNetworking.P2PSend(nameof (ReliableWithBuffering), 3);
        SteamNetworking.P2PSend.\u0024VALUES = new SteamNetworking.P2PSend[4]
        {
          SteamNetworking.P2PSend.__\u003C\u003EUnreliable,
          SteamNetworking.P2PSend.__\u003C\u003EUnreliableNoDelay,
          SteamNetworking.P2PSend.__\u003C\u003EReliable,
          SteamNetworking.P2PSend.__\u003C\u003EReliableWithBuffering
        };
      }

      [Modifiers]
      public static SteamNetworking.P2PSend Unreliable
      {
        [HideFromJava] get => SteamNetworking.P2PSend.__\u003C\u003EUnreliable;
      }

      [Modifiers]
      public static SteamNetworking.P2PSend UnreliableNoDelay
      {
        [HideFromJava] get => SteamNetworking.P2PSend.__\u003C\u003EUnreliableNoDelay;
      }

      [Modifiers]
      public static SteamNetworking.P2PSend Reliable
      {
        [HideFromJava] get => SteamNetworking.P2PSend.__\u003C\u003EReliable;
      }

      [Modifiers]
      public static SteamNetworking.P2PSend ReliableWithBuffering
      {
        [HideFromJava] get => SteamNetworking.P2PSend.__\u003C\u003EReliableWithBuffering;
      }

      [HideFromJava]
      [Serializable]
      public enum __Enum
      {
        Unreliable,
        UnreliableNoDelay,
        Reliable,
        ReliableWithBuffering,
      }
    }

    [InnerClass]
    [Signature("Ljava/lang/Enum<Lcom/codedisaster/steamworks/SteamNetworking$P2PSessionError;>;")]
    [Modifiers]
    [Serializable]
    public sealed class P2PSessionError : Enum
    {
      [Modifiers]
      internal static SteamNetworking.P2PSessionError __\u003C\u003ENone;
      [Modifiers]
      internal static SteamNetworking.P2PSessionError __\u003C\u003ENotRunningApp;
      [Modifiers]
      internal static SteamNetworking.P2PSessionError __\u003C\u003ENoRightsToApp;
      [Modifiers]
      internal static SteamNetworking.P2PSessionError __\u003C\u003EDestinationNotLoggedIn;
      [Modifiers]
      internal static SteamNetworking.P2PSessionError __\u003C\u003ETimeout;
      [Modifiers]
      private static SteamNetworking.P2PSessionError[] values;
      [Modifiers]
      private static SteamNetworking.P2PSessionError[] \u0024VALUES;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [Signature("()V")]
      [LineNumberTable(14)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private P2PSessionError([In] string obj0, [In] int obj1)
        : base(obj0, obj1)
      {
        GC.KeepAlive((object) this);
      }

      [LineNumberTable(14)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static SteamNetworking.P2PSessionError[] values() => (SteamNetworking.P2PSessionError[]) SteamNetworking.P2PSessionError.\u0024VALUES.Clone();

      [LineNumberTable(14)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static SteamNetworking.P2PSessionError valueOf(string name) => (SteamNetworking.P2PSessionError) Enum.valueOf((Class) ClassLiteral<SteamNetworking.P2PSessionError>.Value, name);

      [LineNumberTable(24)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static SteamNetworking.P2PSessionError byOrdinal(int sessionError) => SteamNetworking.P2PSessionError.values[sessionError];

      [LineNumberTable(new byte[] {159, 139, 173, 112, 112, 112, 112, 240, 59, 255, 20, 71})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static P2PSessionError()
      {
        if (ByteCodeHelper.isAlreadyInited("com.codedisaster.steamworks.SteamNetworking$P2PSessionError"))
          return;
        SteamNetworking.P2PSessionError.__\u003C\u003ENone = new SteamNetworking.P2PSessionError(nameof (None), 0);
        SteamNetworking.P2PSessionError.__\u003C\u003ENotRunningApp = new SteamNetworking.P2PSessionError(nameof (NotRunningApp), 1);
        SteamNetworking.P2PSessionError.__\u003C\u003ENoRightsToApp = new SteamNetworking.P2PSessionError(nameof (NoRightsToApp), 2);
        SteamNetworking.P2PSessionError.__\u003C\u003EDestinationNotLoggedIn = new SteamNetworking.P2PSessionError(nameof (DestinationNotLoggedIn), 3);
        SteamNetworking.P2PSessionError.__\u003C\u003ETimeout = new SteamNetworking.P2PSessionError(nameof (Timeout), 4);
        SteamNetworking.P2PSessionError.\u0024VALUES = new SteamNetworking.P2PSessionError[5]
        {
          SteamNetworking.P2PSessionError.__\u003C\u003ENone,
          SteamNetworking.P2PSessionError.__\u003C\u003ENotRunningApp,
          SteamNetworking.P2PSessionError.__\u003C\u003ENoRightsToApp,
          SteamNetworking.P2PSessionError.__\u003C\u003EDestinationNotLoggedIn,
          SteamNetworking.P2PSessionError.__\u003C\u003ETimeout
        };
        SteamNetworking.P2PSessionError.values = SteamNetworking.P2PSessionError.values();
      }

      [Modifiers]
      public static SteamNetworking.P2PSessionError None
      {
        [HideFromJava] get => SteamNetworking.P2PSessionError.__\u003C\u003ENone;
      }

      [Modifiers]
      public static SteamNetworking.P2PSessionError NotRunningApp
      {
        [HideFromJava] get => SteamNetworking.P2PSessionError.__\u003C\u003ENotRunningApp;
      }

      [Modifiers]
      public static SteamNetworking.P2PSessionError NoRightsToApp
      {
        [HideFromJava] get => SteamNetworking.P2PSessionError.__\u003C\u003ENoRightsToApp;
      }

      [Modifiers]
      public static SteamNetworking.P2PSessionError DestinationNotLoggedIn
      {
        [HideFromJava] get => SteamNetworking.P2PSessionError.__\u003C\u003EDestinationNotLoggedIn;
      }

      [Modifiers]
      public static SteamNetworking.P2PSessionError Timeout
      {
        [HideFromJava] get => SteamNetworking.P2PSessionError.__\u003C\u003ETimeout;
      }

      [HideFromJava]
      [Serializable]
      public enum __Enum
      {
        None,
        NotRunningApp,
        NoRightsToApp,
        DestinationNotLoggedIn,
        Timeout,
      }
    }

    public class P2PSessionState : Object
    {
      internal byte connectionActive;
      internal byte connecting;
      internal byte sessionError;
      internal byte usingRelay;
      internal int bytesQueuedForSend;
      internal int packetsQueuedForSend;
      internal int remoteIP;
      internal short remotePort;

      [LineNumberTable(28)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public P2PSessionState()
      {
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual bool isConnectionActive() => this.connectionActive != (byte) 0;

      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual bool isConnecting() => this.connecting != (byte) 0;

      [LineNumberTable(47)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual SteamNetworking.P2PSessionError getLastSessionError() => SteamNetworking.P2PSessionError.byOrdinal((int) (sbyte) this.sessionError);

      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual bool isUsingRelay() => this.usingRelay != (byte) 0;

      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual int getBytesQueuedForSend() => this.bytesQueuedForSend;

      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual int getPacketsQueuedForSend() => this.packetsQueuedForSend;

      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual int getRemoteIP() => this.remoteIP;

      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual short getRemotePort() => this.remotePort;
    }

    private new sealed class __\u003CCallerID\u003E : CallerID
    {
      internal __\u003CCallerID\u003E()
      {
      }
    }
  }
}
