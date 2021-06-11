// Decompiled with JetBrains decompiler
// Type: net.jpountz.xxhash.XXHashJNI
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.nio;
using net.jpountz.util;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace net.jpountz.xxhash
{
  [Signature("Ljava/lang/Enum<Lnet/jpountz/xxhash/XXHashJNI;>;")]
  [Modifiers]
  [Serializable]
  internal sealed class XXHashJNI : Enum
  {
    [Modifiers]
    private static XXHashJNI[] \u0024VALUES;
    static IntPtr __\u003Cjniptr\u003Einit\u0028\u0029V;
    [SpecialName]
    private static CallerID __\u003CcallerID\u003E;
    static IntPtr __\u003Cjniptr\u003EXXH32\u0028\u005BBIII\u0029I;
    static IntPtr __\u003Cjniptr\u003EXXH32BB\u0028Ljava\u002Fnio\u002FByteBuffer\u003BIII\u0029I;
    static IntPtr __\u003Cjniptr\u003EXXH32_init\u0028I\u0029J;
    static IntPtr __\u003Cjniptr\u003EXXH32_update\u0028J\u005BBII\u0029V;
    static IntPtr __\u003Cjniptr\u003EXXH32_digest\u0028J\u0029I;
    static IntPtr __\u003Cjniptr\u003EXXH32_free\u0028J\u0029V;
    static IntPtr __\u003Cjniptr\u003EXXH64\u0028\u005BBIIJ\u0029J;
    static IntPtr __\u003Cjniptr\u003EXXH64BB\u0028Ljava\u002Fnio\u002FByteBuffer\u003BIIJ\u0029J;
    static IntPtr __\u003Cjniptr\u003EXXH64_init\u0028J\u0029J;
    static IntPtr __\u003Cjniptr\u003EXXH64_update\u0028J\u005BBII\u0029V;
    static IntPtr __\u003Cjniptr\u003EXXH64_digest\u0028J\u0029J;
    static IntPtr __\u003Cjniptr\u003EXXH64_free\u0028J\u0029V;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [Modifiers]
    internal static long XXH32_init([In] int obj0)
    {
      JNI.Frame frame = new JNI.Frame();
      if (XXHashJNI.__\u003Cjniptr\u003EXXH32_init\u0028I\u0029J == IntPtr.Zero)
        XXHashJNI.__\u003Cjniptr\u003EXXH32_init\u0028I\u0029J = JNI.Frame.GetFuncPtr(XXHashJNI.__\u003CGetCallerID\u003E(), "net/jpountz/xxhash/XXHashJNI", nameof (XXH32_init), "(I)J");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(XXHashJNI.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<XXHashJNI>.Value);
        int num4 = obj0;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<long (IntPtr, IntPtr, int)>) XXHashJNI.__\u003Cjniptr\u003EXXH32_init\u0028I\u0029J)((int) num2, num3, (IntPtr) num4);
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
    internal static void XXH32_free([In] long obj0)
    {
      JNI.Frame frame = new JNI.Frame();
      if (XXHashJNI.__\u003Cjniptr\u003EXXH32_free\u0028J\u0029V == IntPtr.Zero)
        XXHashJNI.__\u003Cjniptr\u003EXXH32_free\u0028J\u0029V = JNI.Frame.GetFuncPtr(XXHashJNI.__\u003CGetCallerID\u003E(), "net/jpountz/xxhash/XXHashJNI", nameof (XXH32_free), "(J)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(XXHashJNI.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<XXHashJNI>.Value);
        long num4 = obj0;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, long)>) XXHashJNI.__\u003Cjniptr\u003EXXH32_free\u0028J\u0029V)((long) num2, num3, (IntPtr) num4);
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
    internal static int XXH32_digest([In] long obj0)
    {
      JNI.Frame frame = new JNI.Frame();
      if (XXHashJNI.__\u003Cjniptr\u003EXXH32_digest\u0028J\u0029I == IntPtr.Zero)
        XXHashJNI.__\u003Cjniptr\u003EXXH32_digest\u0028J\u0029I = JNI.Frame.GetFuncPtr(XXHashJNI.__\u003CGetCallerID\u003E(), "net/jpountz/xxhash/XXHashJNI", nameof (XXH32_digest), "(J)I");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(XXHashJNI.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<XXHashJNI>.Value);
        long num4 = obj0;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<int (IntPtr, IntPtr, long)>) XXHashJNI.__\u003Cjniptr\u003EXXH32_digest\u0028J\u0029I)((long) num2, num3, (IntPtr) num4);
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
    internal static void XXH32_update([In] long obj0, [In] byte[] obj1, [In] int obj2, [In] int obj3)
    {
      JNI.Frame frame = new JNI.Frame();
      if (XXHashJNI.__\u003Cjniptr\u003EXXH32_update\u0028J\u005BBII\u0029V == IntPtr.Zero)
        XXHashJNI.__\u003Cjniptr\u003EXXH32_update\u0028J\u005BBII\u0029V = JNI.Frame.GetFuncPtr(XXHashJNI.__\u003CGetCallerID\u003E(), "net/jpountz/xxhash/XXHashJNI", nameof (XXH32_update), "(J[BII)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(XXHashJNI.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<XXHashJNI>.Value);
        long num4 = obj0;
        IntPtr num5 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj1);
        int num6 = obj2;
        int num7 = obj3;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, long, IntPtr, int, int)>) XXHashJNI.__\u003Cjniptr\u003EXXH32_update\u0028J\u005BBII\u0029V)((int) num2, (int) num3, (IntPtr) num4, (long) num5, (IntPtr) num6, (IntPtr) num7);
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
    internal static long XXH64_init([In] long obj0)
    {
      JNI.Frame frame = new JNI.Frame();
      if (XXHashJNI.__\u003Cjniptr\u003EXXH64_init\u0028J\u0029J == IntPtr.Zero)
        XXHashJNI.__\u003Cjniptr\u003EXXH64_init\u0028J\u0029J = JNI.Frame.GetFuncPtr(XXHashJNI.__\u003CGetCallerID\u003E(), "net/jpountz/xxhash/XXHashJNI", nameof (XXH64_init), "(J)J");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(XXHashJNI.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<XXHashJNI>.Value);
        long num4 = obj0;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<long (IntPtr, IntPtr, long)>) XXHashJNI.__\u003Cjniptr\u003EXXH64_init\u0028J\u0029J)((long) num2, num3, (IntPtr) num4);
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
    internal static void XXH64_free([In] long obj0)
    {
      JNI.Frame frame = new JNI.Frame();
      if (XXHashJNI.__\u003Cjniptr\u003EXXH64_free\u0028J\u0029V == IntPtr.Zero)
        XXHashJNI.__\u003Cjniptr\u003EXXH64_free\u0028J\u0029V = JNI.Frame.GetFuncPtr(XXHashJNI.__\u003CGetCallerID\u003E(), "net/jpountz/xxhash/XXHashJNI", nameof (XXH64_free), "(J)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(XXHashJNI.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<XXHashJNI>.Value);
        long num4 = obj0;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, long)>) XXHashJNI.__\u003Cjniptr\u003EXXH64_free\u0028J\u0029V)((long) num2, num3, (IntPtr) num4);
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
    internal static long XXH64_digest([In] long obj0)
    {
      JNI.Frame frame = new JNI.Frame();
      if (XXHashJNI.__\u003Cjniptr\u003EXXH64_digest\u0028J\u0029J == IntPtr.Zero)
        XXHashJNI.__\u003Cjniptr\u003EXXH64_digest\u0028J\u0029J = JNI.Frame.GetFuncPtr(XXHashJNI.__\u003CGetCallerID\u003E(), "net/jpountz/xxhash/XXHashJNI", nameof (XXH64_digest), "(J)J");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(XXHashJNI.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<XXHashJNI>.Value);
        long num4 = obj0;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<long (IntPtr, IntPtr, long)>) XXHashJNI.__\u003Cjniptr\u003EXXH64_digest\u0028J\u0029J)((long) num2, num3, (IntPtr) num4);
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
    internal static void XXH64_update([In] long obj0, [In] byte[] obj1, [In] int obj2, [In] int obj3)
    {
      JNI.Frame frame = new JNI.Frame();
      if (XXHashJNI.__\u003Cjniptr\u003EXXH64_update\u0028J\u005BBII\u0029V == IntPtr.Zero)
        XXHashJNI.__\u003Cjniptr\u003EXXH64_update\u0028J\u005BBII\u0029V = JNI.Frame.GetFuncPtr(XXHashJNI.__\u003CGetCallerID\u003E(), "net/jpountz/xxhash/XXHashJNI", nameof (XXH64_update), "(J[BII)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(XXHashJNI.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<XXHashJNI>.Value);
        long num4 = obj0;
        IntPtr num5 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj1);
        int num6 = obj2;
        int num7 = obj3;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, long, IntPtr, int, int)>) XXHashJNI.__\u003Cjniptr\u003EXXH64_update\u0028J\u005BBII\u0029V)((int) num2, (int) num3, (IntPtr) num4, (long) num5, (IntPtr) num6, (IntPtr) num7);
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
    internal static int XXH32([In] byte[] obj0, [In] int obj1, [In] int obj2, [In] int obj3)
    {
      JNI.Frame frame = new JNI.Frame();
      if (XXHashJNI.__\u003Cjniptr\u003EXXH32\u0028\u005BBIII\u0029I == IntPtr.Zero)
        XXHashJNI.__\u003Cjniptr\u003EXXH32\u0028\u005BBIII\u0029I = JNI.Frame.GetFuncPtr(XXHashJNI.__\u003CGetCallerID\u003E(), "net/jpountz/xxhash/XXHashJNI", nameof (XXH32), "([BIII)I");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(XXHashJNI.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<XXHashJNI>.Value);
        IntPtr num4 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj0);
        int num5 = obj1;
        int num6 = obj2;
        int num7 = obj3;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<int (IntPtr, IntPtr, IntPtr, int, int, int)>) XXHashJNI.__\u003Cjniptr\u003EXXH32\u0028\u005BBIII\u0029I)((int) num2, (int) num3, (int) num4, (IntPtr) num5, (IntPtr) num6, (IntPtr) num7);
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
    internal static int XXH32BB([In] ByteBuffer obj0, [In] int obj1, [In] int obj2, [In] int obj3)
    {
      JNI.Frame frame = new JNI.Frame();
      if (XXHashJNI.__\u003Cjniptr\u003EXXH32BB\u0028Ljava\u002Fnio\u002FByteBuffer\u003BIII\u0029I == IntPtr.Zero)
        XXHashJNI.__\u003Cjniptr\u003EXXH32BB\u0028Ljava\u002Fnio\u002FByteBuffer\u003BIII\u0029I = JNI.Frame.GetFuncPtr(XXHashJNI.__\u003CGetCallerID\u003E(), "net/jpountz/xxhash/XXHashJNI", nameof (XXH32BB), "(Ljava/nio/ByteBuffer;III)I");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(XXHashJNI.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<XXHashJNI>.Value);
        IntPtr num4 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj0);
        int num5 = obj1;
        int num6 = obj2;
        int num7 = obj3;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<int (IntPtr, IntPtr, IntPtr, int, int, int)>) XXHashJNI.__\u003Cjniptr\u003EXXH32BB\u0028Ljava\u002Fnio\u002FByteBuffer\u003BIII\u0029I)((int) num2, (int) num3, (int) num4, (IntPtr) num5, (IntPtr) num6, (IntPtr) num7);
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
    internal static long XXH64([In] byte[] obj0, [In] int obj1, [In] int obj2, [In] long obj3)
    {
      JNI.Frame frame = new JNI.Frame();
      if (XXHashJNI.__\u003Cjniptr\u003EXXH64\u0028\u005BBIIJ\u0029J == IntPtr.Zero)
        XXHashJNI.__\u003Cjniptr\u003EXXH64\u0028\u005BBIIJ\u0029J = JNI.Frame.GetFuncPtr(XXHashJNI.__\u003CGetCallerID\u003E(), "net/jpountz/xxhash/XXHashJNI", nameof (XXH64), "([BIIJ)J");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(XXHashJNI.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<XXHashJNI>.Value);
        IntPtr num4 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj0);
        int num5 = obj1;
        int num6 = obj2;
        long num7 = obj3;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<long (IntPtr, IntPtr, IntPtr, int, int, long)>) XXHashJNI.__\u003Cjniptr\u003EXXH64\u0028\u005BBIIJ\u0029J)((long) num2, (int) num3, (int) num4, (IntPtr) num5, (IntPtr) num6, (IntPtr) num7);
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
    internal static long XXH64BB([In] ByteBuffer obj0, [In] int obj1, [In] int obj2, [In] long obj3)
    {
      JNI.Frame frame = new JNI.Frame();
      if (XXHashJNI.__\u003Cjniptr\u003EXXH64BB\u0028Ljava\u002Fnio\u002FByteBuffer\u003BIIJ\u0029J == IntPtr.Zero)
        XXHashJNI.__\u003Cjniptr\u003EXXH64BB\u0028Ljava\u002Fnio\u002FByteBuffer\u003BIIJ\u0029J = JNI.Frame.GetFuncPtr(XXHashJNI.__\u003CGetCallerID\u003E(), "net/jpountz/xxhash/XXHashJNI", nameof (XXH64BB), "(Ljava/nio/ByteBuffer;IIJ)J");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(XXHashJNI.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<XXHashJNI>.Value);
        IntPtr num4 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj0);
        int num5 = obj1;
        int num6 = obj2;
        long num7 = obj3;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<long (IntPtr, IntPtr, IntPtr, int, int, long)>) XXHashJNI.__\u003Cjniptr\u003EXXH64BB\u0028Ljava\u002Fnio\u002FByteBuffer\u003BIIJ\u0029J)((long) num2, (int) num3, (int) num4, (IntPtr) num5, (IntPtr) num6, (IntPtr) num7);
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
    private static void init()
    {
      JNI.Frame frame = new JNI.Frame();
      if (XXHashJNI.__\u003Cjniptr\u003Einit\u0028\u0029V == IntPtr.Zero)
        XXHashJNI.__\u003Cjniptr\u003Einit\u0028\u0029V = JNI.Frame.GetFuncPtr(XXHashJNI.__\u003CGetCallerID\u003E(), "net/jpountz/xxhash/XXHashJNI", nameof (init), "()V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(XXHashJNI.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<XXHashJNI>.Value);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr)>) XXHashJNI.__\u003Cjniptr\u003Einit\u0028\u0029V)(num2, num3);
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

    [LineNumberTable(21)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static XXHashJNI[] values() => (XXHashJNI[]) XXHashJNI.\u0024VALUES.Clone();

    [LineNumberTable(21)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static XXHashJNI valueOf([In] string obj0) => (XXHashJNI) Enum.valueOf((Class) ClassLiteral<XXHashJNI>.Value, obj0);

    [Signature("()V")]
    [LineNumberTable(21)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private XXHashJNI([In] string obj0, [In] int obj1)
      : base(obj0, obj1)
    {
      GC.KeepAlive((object) this);
    }

    [LineNumberTable(new byte[] {159, 137, 109, 203, 101, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static XXHashJNI()
    {
      if (ByteCodeHelper.isAlreadyInited("net.jpountz.xxhash.XXHashJNI"))
        return;
      XXHashJNI.\u0024VALUES = new XXHashJNI[0];
      Native.load();
      XXHashJNI.init();
    }

    static CallerID __\u003CGetCallerID\u003E()
    {
      if (XXHashJNI.__\u003CcallerID\u003E == null)
        XXHashJNI.__\u003CcallerID\u003E = (CallerID) new XXHashJNI.__\u003CCallerID\u003E();
      return XXHashJNI.__\u003CcallerID\u003E;
    }

    private sealed class __\u003CCallerID\u003E : CallerID
    {
      internal __\u003CCallerID\u003E()
      {
      }
    }
  }
}
