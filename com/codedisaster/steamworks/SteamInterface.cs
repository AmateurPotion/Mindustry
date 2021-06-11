// Decompiled with JetBrains decompiler
// Type: com.codedisaster.steamworks.SteamInterface
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
  internal abstract class SteamInterface : Object
  {
    [Modifiers]
    protected internal long pointer;
    protected internal long callback;
    static IntPtr __\u003Cjniptr\u003EdeleteCallback\u0028J\u0029V;
    [SpecialName]
    private static CallerID __\u003CcallerID\u003E;

    [LineNumberTable(new byte[] {159, 156, 104, 105, 176, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal SteamInterface([In] long obj0, [In] long obj1)
    {
      SteamInterface steamInterface = this;
      if (obj0 == 0L)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new RuntimeException("Steam interface created with null pointer. Always check result of SteamAPI.init(), or with SteamAPI.isSteamRunning()!");
      }
      this.pointer = obj0;
      this.callback = obj1;
    }

    [Modifiers]
    protected internal static void deleteCallback([In] long obj0)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamInterface.__\u003Cjniptr\u003EdeleteCallback\u0028J\u0029V == IntPtr.Zero)
        SteamInterface.__\u003Cjniptr\u003EdeleteCallback\u0028J\u0029V = JNI.Frame.GetFuncPtr(SteamInterface.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamInterface", nameof (deleteCallback), "(J)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamInterface.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamInterface>.Value);
        long num4 = obj0;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, long)>) SteamInterface.__\u003Cjniptr\u003EdeleteCallback\u0028J\u0029V)((long) num2, num3, (IntPtr) num4);
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

    [LineNumberTable(new byte[] {159, 153, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal SteamInterface([In] long obj0)
      : this(obj0, 0L)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void setCallback([In] long obj0) => this.callback = obj0;

    [LineNumberTable(new byte[] {159, 170, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void dispose() => SteamInterface.deleteCallback(this.callback);

    [Throws(new string[] {"com.codedisaster.steamworks.SteamException"})]
    [LineNumberTable(new byte[] {159, 174, 104, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void checkBuffer([In] Buffer obj0)
    {
      if (!obj0.isDirect())
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new SteamException("Direct buffer required.");
      }
    }

    [Throws(new string[] {"com.codedisaster.steamworks.SteamException"})]
    [LineNumberTable(new byte[] {159, 180, 101, 159, 33})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void checkArray([In] byte[] obj0, [In] int obj1)
    {
      if (obj0.Length < obj1)
      {
        string message = new StringBuilder().append("Array too small, ").append(obj0.Length).append(" found but ").append(obj1).append(" expected.").toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new SteamException(message);
      }
    }

    static CallerID __\u003CGetCallerID\u003E()
    {
      if (SteamInterface.__\u003CcallerID\u003E == null)
        SteamInterface.__\u003CcallerID\u003E = (CallerID) new SteamInterface.__\u003CCallerID\u003E();
      return SteamInterface.__\u003CcallerID\u003E;
    }

    private sealed class __\u003CCallerID\u003E : CallerID
    {
      internal __\u003CCallerID\u003E()
      {
      }
    }
  }
}
