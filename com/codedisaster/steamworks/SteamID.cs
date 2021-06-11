// Decompiled with JetBrains decompiler
// Type: com.codedisaster.steamworks.SteamID
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
  public class SteamID : SteamNativeHandle
  {
    [Modifiers]
    private static long InvalidSteamID;
    static IntPtr __\u003Cjniptr\u003EisValid\u0028J\u0029Z;
    [SpecialName]
    private static CallerID __\u003CcallerID\u003E;
    static IntPtr __\u003Cjniptr\u003EgetInvalidSteamID\u0028\u0029J;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(32)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getAccountID()
    {
      long handle = this.handle;
      long num = 4294967296;
      return num != -1L ? (int) (handle % num) : 0;
    }

    [LineNumberTable(new byte[] {159, 150, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public SteamID()
      : base(SteamID.InvalidSteamID)
    {
    }

    [LineNumberTable(40)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static SteamID createFromNativeHandle(long id) => new SteamID(id);

    [LineNumberTable(new byte[] {159, 166, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal SteamID([In] long obj0)
      : base(obj0)
    {
    }

    [Modifiers]
    private static bool isValid([In] long obj0)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamID.__\u003Cjniptr\u003EisValid\u0028J\u0029Z == IntPtr.Zero)
        SteamID.__\u003Cjniptr\u003EisValid\u0028J\u0029Z = JNI.Frame.GetFuncPtr(SteamID.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamID", nameof (isValid), "(J)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamID.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamID>.Value);
        long num4 = obj0;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, long)>) SteamID.__\u003Cjniptr\u003EisValid\u0028J\u0029Z)((long) num2, num3, (IntPtr) num4);
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
    private static long getInvalidSteamID()
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamID.__\u003Cjniptr\u003EgetInvalidSteamID\u0028\u0029J == IntPtr.Zero)
        SteamID.__\u003Cjniptr\u003EgetInvalidSteamID\u0028\u0029J = JNI.Frame.GetFuncPtr(SteamID.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamID", nameof (getInvalidSteamID), "()J");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamID.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamID>.Value);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<long (IntPtr, IntPtr)>) SteamID.__\u003Cjniptr\u003EgetInvalidSteamID\u0028\u0029J)(num2, num3);
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

    [LineNumberTable(new byte[] {159, 154, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public SteamID(SteamID steamID)
      : base(steamID.handle)
    {
    }

    [LineNumberTable(28)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isValid() => SteamID.isValid(this.handle);

    [LineNumberTable(5)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static SteamID()
    {
      if (ByteCodeHelper.isAlreadyInited("com.codedisaster.steamworks.SteamID"))
        return;
      SteamID.InvalidSteamID = SteamID.getInvalidSteamID();
    }

    static CallerID __\u003CGetCallerID\u003E()
    {
      if (SteamID.__\u003CcallerID\u003E == null)
        SteamID.__\u003CcallerID\u003E = (CallerID) new SteamID.__\u003CCallerID\u003E();
      return SteamID.__\u003CcallerID\u003E;
    }

    private sealed class __\u003CCallerID\u003E : CallerID
    {
      internal __\u003CCallerID\u003E()
      {
      }
    }
  }
}
