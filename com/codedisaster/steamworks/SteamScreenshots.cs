// Decompiled with JetBrains decompiler
// Type: com.codedisaster.steamworks.SteamScreenshots
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.nio;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace com.codedisaster.steamworks
{
  public class SteamScreenshots : SteamInterface
  {
    static IntPtr __\u003Cjniptr\u003EcreateCallback\u0028Lcom\u002Fcodedisaster\u002Fsteamworks\u002FSteamScreenshotsCallbackAdapter\u003B\u0029J;
    [SpecialName]
    private static CallerID __\u003CcallerID\u003E;
    static IntPtr __\u003Cjniptr\u003EwriteScreenshot\u0028JLjava\u002Fnio\u002FByteBuffer\u003BIII\u0029I;
    static IntPtr __\u003Cjniptr\u003EaddScreenshotToLibrary\u0028JLjava\u002Flang\u002FString\u003BLjava\u002Flang\u002FString\u003BII\u0029I;
    static IntPtr __\u003Cjniptr\u003EtriggerScreenshot\u0028J\u0029V;
    static IntPtr __\u003Cjniptr\u003EhookScreenshots\u0028JZ\u0029V;
    static IntPtr __\u003Cjniptr\u003EsetLocation\u0028JILjava\u002Flang\u002FString\u003B\u0029Z;
    static IntPtr __\u003Cjniptr\u003EtagUser\u0028JIJ\u0029Z;
    static IntPtr __\u003Cjniptr\u003EtagPublishedFile\u0028JIJ\u0029Z;
    static IntPtr __\u003Cjniptr\u003EisScreenshotsHooked\u0028J\u0029Z;

    [Modifiers]
    private static long createCallback([In] SteamScreenshotsCallbackAdapter obj0)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamScreenshots.__\u003Cjniptr\u003EcreateCallback\u0028Lcom\u002Fcodedisaster\u002Fsteamworks\u002FSteamScreenshotsCallbackAdapter\u003B\u0029J == IntPtr.Zero)
        SteamScreenshots.__\u003Cjniptr\u003EcreateCallback\u0028Lcom\u002Fcodedisaster\u002Fsteamworks\u002FSteamScreenshotsCallbackAdapter\u003B\u0029J = JNI.Frame.GetFuncPtr(SteamScreenshots.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamScreenshots", nameof (createCallback), "(Lcom/codedisaster/steamworks/SteamScreenshotsCallbackAdapter;)J");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamScreenshots.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamScreenshots>.Value);
        IntPtr num4 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj0);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<long (IntPtr, IntPtr, IntPtr)>) SteamScreenshots.__\u003Cjniptr\u003EcreateCallback\u0028Lcom\u002Fcodedisaster\u002Fsteamworks\u002FSteamScreenshotsCallbackAdapter\u003B\u0029J)(num2, num3, num4);
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
    private static int writeScreenshot([In] long obj0, [In] ByteBuffer obj1, [In] int obj2, [In] int obj3, [In] int obj4)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamScreenshots.__\u003Cjniptr\u003EwriteScreenshot\u0028JLjava\u002Fnio\u002FByteBuffer\u003BIII\u0029I == IntPtr.Zero)
        SteamScreenshots.__\u003Cjniptr\u003EwriteScreenshot\u0028JLjava\u002Fnio\u002FByteBuffer\u003BIII\u0029I = JNI.Frame.GetFuncPtr(SteamScreenshots.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamScreenshots", nameof (writeScreenshot), "(JLjava/nio/ByteBuffer;III)I");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamScreenshots.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamScreenshots>.Value);
        long num4 = obj0;
        IntPtr num5 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj1);
        int num6 = obj2;
        int num7 = obj3;
        int num8 = obj4;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<int (IntPtr, IntPtr, long, IntPtr, int, int, int)>) SteamScreenshots.__\u003Cjniptr\u003EwriteScreenshot\u0028JLjava\u002Fnio\u002FByteBuffer\u003BIII\u0029I)((int) num2, (int) num3, (int) num4, num5, (long) num6, (IntPtr) num7, (IntPtr) num8);
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
    private static int addScreenshotToLibrary(
      [In] long obj0,
      [In] string obj1,
      [In] string obj2,
      [In] int obj3,
      [In] int obj4)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamScreenshots.__\u003Cjniptr\u003EaddScreenshotToLibrary\u0028JLjava\u002Flang\u002FString\u003BLjava\u002Flang\u002FString\u003BII\u0029I == IntPtr.Zero)
        SteamScreenshots.__\u003Cjniptr\u003EaddScreenshotToLibrary\u0028JLjava\u002Flang\u002FString\u003BLjava\u002Flang\u002FString\u003BII\u0029I = JNI.Frame.GetFuncPtr(SteamScreenshots.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamScreenshots", nameof (addScreenshotToLibrary), "(JLjava/lang/String;Ljava/lang/String;II)I");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamScreenshots.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamScreenshots>.Value);
        long num4 = obj0;
        IntPtr num5 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj1);
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj2);
        int num7 = obj3;
        int num8 = obj4;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<int (IntPtr, IntPtr, long, IntPtr, IntPtr, int, int)>) SteamScreenshots.__\u003Cjniptr\u003EaddScreenshotToLibrary\u0028JLjava\u002Flang\u002FString\u003BLjava\u002Flang\u002FString\u003BII\u0029I)((int) num2, (int) num3, (IntPtr) num4, num5, (long) num6, (IntPtr) num7, (IntPtr) num8);
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
    private static void triggerScreenshot([In] long obj0)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamScreenshots.__\u003Cjniptr\u003EtriggerScreenshot\u0028J\u0029V == IntPtr.Zero)
        SteamScreenshots.__\u003Cjniptr\u003EtriggerScreenshot\u0028J\u0029V = JNI.Frame.GetFuncPtr(SteamScreenshots.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamScreenshots", nameof (triggerScreenshot), "(J)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamScreenshots.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamScreenshots>.Value);
        long num4 = obj0;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, long)>) SteamScreenshots.__\u003Cjniptr\u003EtriggerScreenshot\u0028J\u0029V)((long) num2, num3, (IntPtr) num4);
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
    private static void hookScreenshots([In] long obj0, [In] bool obj1)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamScreenshots.__\u003Cjniptr\u003EhookScreenshots\u0028JZ\u0029V == IntPtr.Zero)
        SteamScreenshots.__\u003Cjniptr\u003EhookScreenshots\u0028JZ\u0029V = JNI.Frame.GetFuncPtr(SteamScreenshots.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamScreenshots", nameof (hookScreenshots), "(JZ)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamScreenshots.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamScreenshots>.Value);
        long num4 = obj0;
        int num5 = obj1 ? 1 : 0;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, long, bool)>) SteamScreenshots.__\u003Cjniptr\u003EhookScreenshots\u0028JZ\u0029V)((bool) num2, (long) num3, (IntPtr) num4, (IntPtr) num5);
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
    private static bool setLocation([In] long obj0, [In] int obj1, [In] string obj2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamScreenshots.__\u003Cjniptr\u003EsetLocation\u0028JILjava\u002Flang\u002FString\u003B\u0029Z == IntPtr.Zero)
        SteamScreenshots.__\u003Cjniptr\u003EsetLocation\u0028JILjava\u002Flang\u002FString\u003B\u0029Z = JNI.Frame.GetFuncPtr(SteamScreenshots.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamScreenshots", nameof (setLocation), "(JILjava/lang/String;)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamScreenshots.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamScreenshots>.Value);
        long num4 = obj0;
        int num5 = obj1;
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj2);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, long, int, IntPtr)>) SteamScreenshots.__\u003Cjniptr\u003EsetLocation\u0028JILjava\u002Flang\u002FString\u003B\u0029Z)(num2, (int) num3, num4, (IntPtr) num5, num6);
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
    private static bool tagUser([In] long obj0, [In] int obj1, [In] long obj2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamScreenshots.__\u003Cjniptr\u003EtagUser\u0028JIJ\u0029Z == IntPtr.Zero)
        SteamScreenshots.__\u003Cjniptr\u003EtagUser\u0028JIJ\u0029Z = JNI.Frame.GetFuncPtr(SteamScreenshots.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamScreenshots", nameof (tagUser), "(JIJ)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamScreenshots.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamScreenshots>.Value);
        long num4 = obj0;
        int num5 = obj1;
        long num6 = obj2;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, long, int, long)>) SteamScreenshots.__\u003Cjniptr\u003EtagUser\u0028JIJ\u0029Z)((long) num2, (int) num3, num4, (IntPtr) num5, (IntPtr) num6);
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
    private static bool tagPublishedFile([In] long obj0, [In] int obj1, [In] long obj2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamScreenshots.__\u003Cjniptr\u003EtagPublishedFile\u0028JIJ\u0029Z == IntPtr.Zero)
        SteamScreenshots.__\u003Cjniptr\u003EtagPublishedFile\u0028JIJ\u0029Z = JNI.Frame.GetFuncPtr(SteamScreenshots.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamScreenshots", nameof (tagPublishedFile), "(JIJ)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamScreenshots.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamScreenshots>.Value);
        long num4 = obj0;
        int num5 = obj1;
        long num6 = obj2;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, long, int, long)>) SteamScreenshots.__\u003Cjniptr\u003EtagPublishedFile\u0028JIJ\u0029Z)((long) num2, (int) num3, num4, (IntPtr) num5, (IntPtr) num6);
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
    private static bool isScreenshotsHooked([In] long obj0)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SteamScreenshots.__\u003Cjniptr\u003EisScreenshotsHooked\u0028J\u0029Z == IntPtr.Zero)
        SteamScreenshots.__\u003Cjniptr\u003EisScreenshotsHooked\u0028J\u0029Z = JNI.Frame.GetFuncPtr(SteamScreenshots.__\u003CGetCallerID\u003E(), "com/codedisaster/steamworks/SteamScreenshots", nameof (isScreenshotsHooked), "(J)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SteamScreenshots.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SteamScreenshots>.Value);
        long num4 = obj0;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, long)>) SteamScreenshots.__\u003Cjniptr\u003EisScreenshotsHooked\u0028J\u0029Z)((long) num2, num3, (IntPtr) num4);
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

    [LineNumberTable(new byte[] {159, 150, 118})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public SteamScreenshots(SteamScreenshotsCallback callback)
      : base(SteamAPI.getSteamScreenshotsPointer(), SteamScreenshots.createCallback(new SteamScreenshotsCallbackAdapter(callback)))
    {
    }

    [LineNumberTable(12)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual SteamScreenshotHandle writeScreenshot(
      ByteBuffer rgb,
      int width,
      int height)
    {
      SteamScreenshotHandle.__\u003Cclinit\u003E();
      return new SteamScreenshotHandle(SteamScreenshots.writeScreenshot(this.pointer, rgb, ((Buffer) rgb).remaining(), width, height));
    }

    [LineNumberTable(16)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual SteamScreenshotHandle addScreenshotToLibrary(
      string file,
      string thumbnail,
      int width,
      int height)
    {
      SteamScreenshotHandle.__\u003Cclinit\u003E();
      return new SteamScreenshotHandle(SteamScreenshots.addScreenshotToLibrary(this.pointer, file, thumbnail, width, height));
    }

    [LineNumberTable(new byte[] {159, 162, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void triggerScreenshot() => SteamScreenshots.triggerScreenshot(this.pointer);

    [LineNumberTable(new byte[] {159, 136, 66, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void hookScreenshots(bool hook) => SteamScreenshots.hookScreenshots(this.pointer, hook);

    [LineNumberTable(28)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool setLocation(SteamScreenshotHandle screenshot, string location) => SteamScreenshots.setLocation(this.pointer, screenshot.handle, location);

    [LineNumberTable(32)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool tagUser(SteamScreenshotHandle screenshot, SteamID steamID) => SteamScreenshots.tagUser(this.pointer, screenshot.handle, steamID.handle);

    [LineNumberTable(36)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool tagPublishedFile(
      SteamScreenshotHandle screenshot,
      SteamPublishedFileID publishedFileID)
    {
      return SteamScreenshots.tagPublishedFile(this.pointer, screenshot.handle, publishedFileID.handle);
    }

    [LineNumberTable(40)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isScreenshotsHooked() => SteamScreenshots.isScreenshotsHooked(this.pointer);

    [Modifiers]
    [LineNumberTable(5)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void dispose() => base.dispose();

    new static CallerID __\u003CGetCallerID\u003E()
    {
      if (SteamScreenshots.__\u003CcallerID\u003E == null)
        SteamScreenshots.__\u003CcallerID\u003E = (CallerID) new SteamScreenshots.__\u003CCallerID\u003E();
      return SteamScreenshots.__\u003CcallerID\u003E;
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
