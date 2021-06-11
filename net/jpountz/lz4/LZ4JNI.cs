// Decompiled with JetBrains decompiler
// Type: net.jpountz.lz4.LZ4JNI
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

namespace net.jpountz.lz4
{
  [Signature("Ljava/lang/Enum<Lnet/jpountz/lz4/LZ4JNI;>;")]
  [Modifiers]
  [Serializable]
  internal sealed class LZ4JNI : Enum
  {
    [Modifiers]
    private static LZ4JNI[] \u0024VALUES;
    static IntPtr __\u003Cjniptr\u003Einit\u0028\u0029V;
    [SpecialName]
    private static CallerID __\u003CcallerID\u003E;
    static IntPtr __\u003Cjniptr\u003ELZ4_compress_limitedOutput\u0028\u005BBLjava\u002Fnio\u002FByteBuffer\u003BII\u005BBLjava\u002Fnio\u002FByteBuffer\u003BII\u0029I;
    static IntPtr __\u003Cjniptr\u003ELZ4_compressHC\u0028\u005BBLjava\u002Fnio\u002FByteBuffer\u003BII\u005BBLjava\u002Fnio\u002FByteBuffer\u003BIII\u0029I;
    static IntPtr __\u003Cjniptr\u003ELZ4_decompress_fast\u0028\u005BBLjava\u002Fnio\u002FByteBuffer\u003BI\u005BBLjava\u002Fnio\u002FByteBuffer\u003BII\u0029I;
    static IntPtr __\u003Cjniptr\u003ELZ4_decompress_safe\u0028\u005BBLjava\u002Fnio\u002FByteBuffer\u003BII\u005BBLjava\u002Fnio\u002FByteBuffer\u003BII\u0029I;
    static IntPtr __\u003Cjniptr\u003ELZ4_compressBound\u0028I\u0029I;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [Modifiers]
    internal static int LZ4_compressHC(
      [In] byte[] obj0,
      [In] ByteBuffer obj1,
      [In] int obj2,
      [In] int obj3,
      [In] byte[] obj4,
      [In] ByteBuffer obj5,
      [In] int obj6,
      [In] int obj7,
      [In] int obj8)
    {
      JNI.Frame frame = new JNI.Frame();
      if (LZ4JNI.__\u003Cjniptr\u003ELZ4_compressHC\u0028\u005BBLjava\u002Fnio\u002FByteBuffer\u003BII\u005BBLjava\u002Fnio\u002FByteBuffer\u003BIII\u0029I == IntPtr.Zero)
        LZ4JNI.__\u003Cjniptr\u003ELZ4_compressHC\u0028\u005BBLjava\u002Fnio\u002FByteBuffer\u003BII\u005BBLjava\u002Fnio\u002FByteBuffer\u003BIII\u0029I = JNI.Frame.GetFuncPtr(LZ4JNI.__\u003CGetCallerID\u003E(), "net/jpountz/lz4/LZ4JNI", nameof (LZ4_compressHC), "([BLjava/nio/ByteBuffer;II[BLjava/nio/ByteBuffer;III)I");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(LZ4JNI.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<LZ4JNI>.Value);
        IntPtr num4 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj0);
        IntPtr num5 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj1);
        int num6 = obj2;
        int num7 = obj3;
        IntPtr num8 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj4);
        IntPtr num9 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj5);
        int num10 = obj6;
        int num11 = obj7;
        int num12 = obj8;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<int (IntPtr, IntPtr, IntPtr, IntPtr, int, int, IntPtr, IntPtr, int, int, int)>) LZ4JNI.__\u003Cjniptr\u003ELZ4_compressHC\u0028\u005BBLjava\u002Fnio\u002FByteBuffer\u003BII\u005BBLjava\u002Fnio\u002FByteBuffer\u003BIII\u0029I)((int) num2, (int) num3, (int) num4, num5, (IntPtr) num6, num7, (int) num8, num9, (IntPtr) num10, (IntPtr) num11, (IntPtr) num12);
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
      if (LZ4JNI.__\u003Cjniptr\u003Einit\u0028\u0029V == IntPtr.Zero)
        LZ4JNI.__\u003Cjniptr\u003Einit\u0028\u0029V = JNI.Frame.GetFuncPtr(LZ4JNI.__\u003CGetCallerID\u003E(), "net/jpountz/lz4/LZ4JNI", nameof (init), "()V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(LZ4JNI.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<LZ4JNI>.Value);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr)>) LZ4JNI.__\u003Cjniptr\u003Einit\u0028\u0029V)(num2, num3);
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

    [LineNumberTable(25)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static LZ4JNI[] values() => (LZ4JNI[]) LZ4JNI.\u0024VALUES.Clone();

    [LineNumberTable(25)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static LZ4JNI valueOf([In] string obj0) => (LZ4JNI) Enum.valueOf((Class) ClassLiteral<LZ4JNI>.Value, obj0);

    [Signature("()V")]
    [LineNumberTable(25)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private LZ4JNI([In] string obj0, [In] int obj1)
      : base(obj0, obj1)
    {
      GC.KeepAlive((object) this);
    }

    [Modifiers]
    internal static int LZ4_compress_limitedOutput(
      [In] byte[] obj0,
      [In] ByteBuffer obj1,
      [In] int obj2,
      [In] int obj3,
      [In] byte[] obj4,
      [In] ByteBuffer obj5,
      [In] int obj6,
      [In] int obj7)
    {
      JNI.Frame frame = new JNI.Frame();
      if (LZ4JNI.__\u003Cjniptr\u003ELZ4_compress_limitedOutput\u0028\u005BBLjava\u002Fnio\u002FByteBuffer\u003BII\u005BBLjava\u002Fnio\u002FByteBuffer\u003BII\u0029I == IntPtr.Zero)
        LZ4JNI.__\u003Cjniptr\u003ELZ4_compress_limitedOutput\u0028\u005BBLjava\u002Fnio\u002FByteBuffer\u003BII\u005BBLjava\u002Fnio\u002FByteBuffer\u003BII\u0029I = JNI.Frame.GetFuncPtr(LZ4JNI.__\u003CGetCallerID\u003E(), "net/jpountz/lz4/LZ4JNI", nameof (LZ4_compress_limitedOutput), "([BLjava/nio/ByteBuffer;II[BLjava/nio/ByteBuffer;II)I");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(LZ4JNI.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<LZ4JNI>.Value);
        IntPtr num4 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj0);
        IntPtr num5 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj1);
        int num6 = obj2;
        int num7 = obj3;
        IntPtr num8 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj4);
        IntPtr num9 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj5);
        int num10 = obj6;
        int num11 = obj7;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<int (IntPtr, IntPtr, IntPtr, IntPtr, int, int, IntPtr, IntPtr, int, int)>) LZ4JNI.__\u003Cjniptr\u003ELZ4_compress_limitedOutput\u0028\u005BBLjava\u002Fnio\u002FByteBuffer\u003BII\u005BBLjava\u002Fnio\u002FByteBuffer\u003BII\u0029I)((int) num2, (int) num3, num4, num5, num6, num7, num8, num9, (IntPtr) num10, (IntPtr) num11);
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
    internal static int LZ4_decompress_fast(
      [In] byte[] obj0,
      [In] ByteBuffer obj1,
      [In] int obj2,
      [In] byte[] obj3,
      [In] ByteBuffer obj4,
      [In] int obj5,
      [In] int obj6)
    {
      JNI.Frame frame = new JNI.Frame();
      if (LZ4JNI.__\u003Cjniptr\u003ELZ4_decompress_fast\u0028\u005BBLjava\u002Fnio\u002FByteBuffer\u003BI\u005BBLjava\u002Fnio\u002FByteBuffer\u003BII\u0029I == IntPtr.Zero)
        LZ4JNI.__\u003Cjniptr\u003ELZ4_decompress_fast\u0028\u005BBLjava\u002Fnio\u002FByteBuffer\u003BI\u005BBLjava\u002Fnio\u002FByteBuffer\u003BII\u0029I = JNI.Frame.GetFuncPtr(LZ4JNI.__\u003CGetCallerID\u003E(), "net/jpountz/lz4/LZ4JNI", nameof (LZ4_decompress_fast), "([BLjava/nio/ByteBuffer;I[BLjava/nio/ByteBuffer;II)I");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(LZ4JNI.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<LZ4JNI>.Value);
        IntPtr num4 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj0);
        IntPtr num5 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj1);
        int num6 = obj2;
        IntPtr num7 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj3);
        IntPtr num8 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj4);
        int num9 = obj5;
        int num10 = obj6;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<int (IntPtr, IntPtr, IntPtr, IntPtr, int, IntPtr, IntPtr, int, int)>) LZ4JNI.__\u003Cjniptr\u003ELZ4_decompress_fast\u0028\u005BBLjava\u002Fnio\u002FByteBuffer\u003BI\u005BBLjava\u002Fnio\u002FByteBuffer\u003BII\u0029I)((int) num2, (int) num3, num4, num5, num6, num7, num8, (IntPtr) num9, (IntPtr) num10);
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
    internal static int LZ4_decompress_safe(
      [In] byte[] obj0,
      [In] ByteBuffer obj1,
      [In] int obj2,
      [In] int obj3,
      [In] byte[] obj4,
      [In] ByteBuffer obj5,
      [In] int obj6,
      [In] int obj7)
    {
      JNI.Frame frame = new JNI.Frame();
      if (LZ4JNI.__\u003Cjniptr\u003ELZ4_decompress_safe\u0028\u005BBLjava\u002Fnio\u002FByteBuffer\u003BII\u005BBLjava\u002Fnio\u002FByteBuffer\u003BII\u0029I == IntPtr.Zero)
        LZ4JNI.__\u003Cjniptr\u003ELZ4_decompress_safe\u0028\u005BBLjava\u002Fnio\u002FByteBuffer\u003BII\u005BBLjava\u002Fnio\u002FByteBuffer\u003BII\u0029I = JNI.Frame.GetFuncPtr(LZ4JNI.__\u003CGetCallerID\u003E(), "net/jpountz/lz4/LZ4JNI", nameof (LZ4_decompress_safe), "([BLjava/nio/ByteBuffer;II[BLjava/nio/ByteBuffer;II)I");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(LZ4JNI.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<LZ4JNI>.Value);
        IntPtr num4 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj0);
        IntPtr num5 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj1);
        int num6 = obj2;
        int num7 = obj3;
        IntPtr num8 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj4);
        IntPtr num9 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj5);
        int num10 = obj6;
        int num11 = obj7;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<int (IntPtr, IntPtr, IntPtr, IntPtr, int, int, IntPtr, IntPtr, int, int)>) LZ4JNI.__\u003Cjniptr\u003ELZ4_decompress_safe\u0028\u005BBLjava\u002Fnio\u002FByteBuffer\u003BII\u005BBLjava\u002Fnio\u002FByteBuffer\u003BII\u0029I)((int) num2, (int) num3, num4, num5, num6, num7, num8, num9, (IntPtr) num10, (IntPtr) num11);
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
    internal static int LZ4_compressBound([In] int obj0)
    {
      JNI.Frame frame = new JNI.Frame();
      if (LZ4JNI.__\u003Cjniptr\u003ELZ4_compressBound\u0028I\u0029I == IntPtr.Zero)
        LZ4JNI.__\u003Cjniptr\u003ELZ4_compressBound\u0028I\u0029I = JNI.Frame.GetFuncPtr(LZ4JNI.__\u003CGetCallerID\u003E(), "net/jpountz/lz4/LZ4JNI", nameof (LZ4_compressBound), "(I)I");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(LZ4JNI.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<LZ4JNI>.Value);
        int num4 = obj0;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<int (IntPtr, IntPtr, int)>) LZ4JNI.__\u003Cjniptr\u003ELZ4_compressBound\u0028I\u0029I)((int) num2, num3, (IntPtr) num4);
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

    [LineNumberTable(new byte[] {159, 136, 109, 203, 101, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static LZ4JNI()
    {
      if (ByteCodeHelper.isAlreadyInited("net.jpountz.lz4.LZ4JNI"))
        return;
      LZ4JNI.\u0024VALUES = new LZ4JNI[0];
      Native.load();
      LZ4JNI.init();
    }

    static CallerID __\u003CGetCallerID\u003E()
    {
      if (LZ4JNI.__\u003CcallerID\u003E == null)
        LZ4JNI.__\u003CcallerID\u003E = (CallerID) new LZ4JNI.__\u003CCallerID\u003E();
      return LZ4JNI.__\u003CcallerID\u003E;
    }

    private sealed class __\u003CCallerID\u003E : CallerID
    {
      internal __\u003CCallerID\u003E()
      {
      }
    }
  }
}
