// Decompiled with JetBrains decompiler
// Type: arc.util.Buffers
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.nio;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.util
{
  public sealed class Buffers : Object
  {
    [Modifiers]
    [Signature("Larc/struct/Seq<Ljava/nio/ByteBuffer;>;")]
    internal static Seq unsafeBuffers;
    internal static int allocatedUnsafe;
    static IntPtr __\u003Cjniptr\u003EfreeMemory\u0028Ljava\u002Fnio\u002FByteBuffer\u003B\u0029V;
    [SpecialName]
    private static CallerID __\u003CcallerID\u003E;
    static IntPtr __\u003Cjniptr\u003EnewDisposableByteBuffer\u0028I\u0029Ljava\u002Fnio\u002FByteBuffer\u003B;
    static IntPtr __\u003Cjniptr\u003EgetBufferAddress\u0028Ljava\u002Fnio\u002FBuffer\u003B\u0029J;
    static IntPtr __\u003Cjniptr\u003Eclear\u0028Ljava\u002Fnio\u002FByteBuffer\u003BI\u0029V;
    static IntPtr __\u003Cjniptr\u003EcopyJni\u0028\u005BFLjava\u002Fnio\u002FBuffer\u003BII\u0029V;
    static IntPtr __\u003Cjniptr\u003EcopyJni\u0028\u005BBILjava\u002Fnio\u002FBuffer\u003BII\u0029V;
    static IntPtr __\u003Cjniptr\u003EcopyJni\u0028\u005BSILjava\u002Fnio\u002FBuffer\u003BII\u0029V;
    static IntPtr __\u003Cjniptr\u003EcopyJni\u0028\u005BIILjava\u002Fnio\u002FBuffer\u003BII\u0029V;
    static IntPtr __\u003Cjniptr\u003EcopyJni\u0028\u005BFILjava\u002Fnio\u002FBuffer\u003BII\u0029V;
    static IntPtr __\u003Cjniptr\u003EcopyJni\u0028Ljava\u002Fnio\u002FBuffer\u003BILjava\u002Fnio\u002FBuffer\u003BII\u0029V;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 188, 117, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void copy(byte[] src, int srcOffset, Buffer dst, int numElements)
    {
      dst.limit(dst.position() + Buffers.bytesToElements(dst, numElements));
      Buffers.copyJni(src, srcOffset, dst, Buffers.positionInBytes(dst), numElements);
    }

    [LineNumberTable(new byte[] {122, 105, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static IntBuffer newIntBuffer(int numInts)
    {
      ByteBuffer byteBuffer = ByteBuffer.allocateDirect(numInts * 4);
      byteBuffer.order(ByteOrder.nativeOrder());
      return byteBuffer.asIntBuffer();
    }

    [LineNumberTable(new byte[] {104, 105, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static FloatBuffer newFloatBuffer(int numFloats)
    {
      ByteBuffer byteBuffer = ByteBuffer.allocateDirect(numFloats * 4);
      byteBuffer.order(ByteOrder.nativeOrder());
      return byteBuffer.asFloatBuffer();
    }

    [LineNumberTable(new byte[] {160, 84, 103, 108, 108, 108, 107, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static ByteBuffer newUnsafeByteBuffer(int numBytes)
    {
      ByteBuffer byteBuffer = Buffers.newDisposableByteBuffer(numBytes);
      byteBuffer.order(ByteOrder.nativeOrder());
      Buffers.allocatedUnsafe += numBytes;
      lock (Buffers.unsafeBuffers)
        Buffers.unsafeBuffers.add((object) byteBuffer);
      return byteBuffer;
    }

    [LineNumberTable(new byte[] {11, 119, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void copy(short[] src, int srcOffset, Buffer dst, int numElements)
    {
      dst.limit(dst.position() + Buffers.bytesToElements(dst, numElements << 1));
      Buffers.copyJni(src, srcOffset, dst, Buffers.positionInBytes(dst), numElements << 1);
    }

    [LineNumberTable(new byte[] {160, 64, 103, 108, 110, 112, 111, 108, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void disposeUnsafeByteBuffer(ByteBuffer buffer)
    {
      int num = ((Buffer) buffer).capacity();
      lock (Buffers.unsafeBuffers)
      {
        if (!Buffers.unsafeBuffers.remove((object) buffer, true))
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalArgumentException("buffer not allocated with newUnsafeByteBuffer or already disposed");
        }
      }
      Buffers.allocatedUnsafe -= num;
      Buffers.freeMemory(buffer);
    }

    [LineNumberTable(new byte[] {116, 103, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static ByteBuffer newByteBuffer(int numBytes)
    {
      ByteBuffer byteBuffer = ByteBuffer.allocateDirect(numBytes);
      byteBuffer.order(ByteOrder.nativeOrder());
      return byteBuffer;
    }

    [LineNumberTable(new byte[] {159, 169, 104, 108, 144, 105, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void copy(float[] src, Buffer dst, int numFloats, int offset)
    {
      switch (dst)
      {
        case ByteBuffer _:
          dst.limit(numFloats << 2);
          break;
        case FloatBuffer _:
          dst.limit(numFloats);
          break;
      }
      Buffers.copyJni(src, dst, numFloats, offset);
      dst.position(0);
    }

    [LineNumberTable(new byte[] {25, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void copy(float[] src, int srcOffset, int numElements, Buffer dst) => Buffers.copyJni(src, srcOffset, dst, Buffers.positionInBytes(dst), numElements << 2);

    [Modifiers]
    private static void copyJni([In] float[] obj0, [In] Buffer obj1, [In] int obj2, [In] int obj3)
    {
      JNI.Frame frame = new JNI.Frame();
      if (Buffers.__\u003Cjniptr\u003EcopyJni\u0028\u005BFLjava\u002Fnio\u002FBuffer\u003BII\u0029V == IntPtr.Zero)
        Buffers.__\u003Cjniptr\u003EcopyJni\u0028\u005BFLjava\u002Fnio\u002FBuffer\u003BII\u0029V = JNI.Frame.GetFuncPtr(Buffers.__\u003CGetCallerID\u003E(), "arc/util/Buffers", nameof (copyJni), "([FLjava/nio/Buffer;II)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Buffers.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Buffers>.Value);
        IntPtr num4 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj0);
        IntPtr num5 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj1);
        int num6 = obj2;
        int num7 = obj3;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, IntPtr, IntPtr, int, int)>) Buffers.__\u003Cjniptr\u003EcopyJni\u0028\u005BFLjava\u002Fnio\u002FBuffer\u003BII\u0029V)((int) num2, (int) num3, num4, num5, (IntPtr) num6, (IntPtr) num7);
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

    [LineNumberTable(129)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static int bytesToElements([In] Buffer obj0, [In] int obj1) => (int) ((uint) obj1 >> Buffers.elementShift(obj0));

    [LineNumberTable(125)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static int positionInBytes([In] Buffer obj0) => obj0.position() << Buffers.elementShift(obj0);

    [Modifiers]
    private static void copyJni([In] byte[] obj0, [In] int obj1, [In] Buffer obj2, [In] int obj3, [In] int obj4)
    {
      JNI.Frame frame = new JNI.Frame();
      if (Buffers.__\u003Cjniptr\u003EcopyJni\u0028\u005BBILjava\u002Fnio\u002FBuffer\u003BII\u0029V == IntPtr.Zero)
        Buffers.__\u003Cjniptr\u003EcopyJni\u0028\u005BBILjava\u002Fnio\u002FBuffer\u003BII\u0029V = JNI.Frame.GetFuncPtr(Buffers.__\u003CGetCallerID\u003E(), "arc/util/Buffers", nameof (copyJni), "([BILjava/nio/Buffer;II)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Buffers.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Buffers>.Value);
        IntPtr num4 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj0);
        int num5 = obj1;
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj2);
        int num7 = obj3;
        int num8 = obj4;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, IntPtr, int, IntPtr, int, int)>) Buffers.__\u003Cjniptr\u003EcopyJni\u0028\u005BBILjava\u002Fnio\u002FBuffer\u003BII\u0029V)((int) num2, (int) num3, num4, num5, num6, (IntPtr) num7, (IntPtr) num8);
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
    private static void copyJni([In] short[] obj0, [In] int obj1, [In] Buffer obj2, [In] int obj3, [In] int obj4)
    {
      JNI.Frame frame = new JNI.Frame();
      if (Buffers.__\u003Cjniptr\u003EcopyJni\u0028\u005BSILjava\u002Fnio\u002FBuffer\u003BII\u0029V == IntPtr.Zero)
        Buffers.__\u003Cjniptr\u003EcopyJni\u0028\u005BSILjava\u002Fnio\u002FBuffer\u003BII\u0029V = JNI.Frame.GetFuncPtr(Buffers.__\u003CGetCallerID\u003E(), "arc/util/Buffers", nameof (copyJni), "([SILjava/nio/Buffer;II)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Buffers.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Buffers>.Value);
        IntPtr num4 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj0);
        int num5 = obj1;
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj2);
        int num7 = obj3;
        int num8 = obj4;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, IntPtr, int, IntPtr, int, int)>) Buffers.__\u003Cjniptr\u003EcopyJni\u0028\u005BSILjava\u002Fnio\u002FBuffer\u003BII\u0029V)((int) num2, (int) num3, num4, num5, num6, (IntPtr) num7, (IntPtr) num8);
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
    private static void copyJni([In] float[] obj0, [In] int obj1, [In] Buffer obj2, [In] int obj3, [In] int obj4)
    {
      JNI.Frame frame = new JNI.Frame();
      if (Buffers.__\u003Cjniptr\u003EcopyJni\u0028\u005BFILjava\u002Fnio\u002FBuffer\u003BII\u0029V == IntPtr.Zero)
        Buffers.__\u003Cjniptr\u003EcopyJni\u0028\u005BFILjava\u002Fnio\u002FBuffer\u003BII\u0029V = JNI.Frame.GetFuncPtr(Buffers.__\u003CGetCallerID\u003E(), "arc/util/Buffers", nameof (copyJni), "([FILjava/nio/Buffer;II)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Buffers.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Buffers>.Value);
        IntPtr num4 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj0);
        int num5 = obj1;
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj2);
        int num7 = obj3;
        int num8 = obj4;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, IntPtr, int, IntPtr, int, int)>) Buffers.__\u003Cjniptr\u003EcopyJni\u0028\u005BFILjava\u002Fnio\u002FBuffer\u003BII\u0029V)((int) num2, (int) num3, num4, num5, num6, (IntPtr) num7, (IntPtr) num8);
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
    private static void copyJni([In] int[] obj0, [In] int obj1, [In] Buffer obj2, [In] int obj3, [In] int obj4)
    {
      JNI.Frame frame = new JNI.Frame();
      if (Buffers.__\u003Cjniptr\u003EcopyJni\u0028\u005BIILjava\u002Fnio\u002FBuffer\u003BII\u0029V == IntPtr.Zero)
        Buffers.__\u003Cjniptr\u003EcopyJni\u0028\u005BIILjava\u002Fnio\u002FBuffer\u003BII\u0029V = JNI.Frame.GetFuncPtr(Buffers.__\u003CGetCallerID\u003E(), "arc/util/Buffers", nameof (copyJni), "([IILjava/nio/Buffer;II)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Buffers.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Buffers>.Value);
        IntPtr num4 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj0);
        int num5 = obj1;
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj2);
        int num7 = obj3;
        int num8 = obj4;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, IntPtr, int, IntPtr, int, int)>) Buffers.__\u003Cjniptr\u003EcopyJni\u0028\u005BIILjava\u002Fnio\u002FBuffer\u003BII\u0029V)((int) num2, (int) num3, num4, num5, num6, (IntPtr) num7, (IntPtr) num8);
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

    [LineNumberTable(133)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static int elementsToBytes([In] Buffer obj0, [In] int obj1) => obj1 << Buffers.elementShift(obj0);

    [Modifiers]
    private static void copyJni([In] Buffer obj0, [In] int obj1, [In] Buffer obj2, [In] int obj3, [In] int obj4)
    {
      JNI.Frame frame = new JNI.Frame();
      if (Buffers.__\u003Cjniptr\u003EcopyJni\u0028Ljava\u002Fnio\u002FBuffer\u003BILjava\u002Fnio\u002FBuffer\u003BII\u0029V == IntPtr.Zero)
        Buffers.__\u003Cjniptr\u003EcopyJni\u0028Ljava\u002Fnio\u002FBuffer\u003BILjava\u002Fnio\u002FBuffer\u003BII\u0029V = JNI.Frame.GetFuncPtr(Buffers.__\u003CGetCallerID\u003E(), "arc/util/Buffers", nameof (copyJni), "(Ljava/nio/Buffer;ILjava/nio/Buffer;II)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Buffers.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Buffers>.Value);
        IntPtr num4 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj0);
        int num5 = obj1;
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj2);
        int num7 = obj3;
        int num8 = obj4;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, IntPtr, int, IntPtr, int, int)>) Buffers.__\u003Cjniptr\u003EcopyJni\u0028Ljava\u002Fnio\u002FBuffer\u003BILjava\u002Fnio\u002FBuffer\u003BII\u0029V)((int) num2, (int) num3, num4, num5, num6, (IntPtr) num7, (IntPtr) num8);
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

    [LineNumberTable(new byte[] {87, 104, 98, 112, 98, 104, 98, 104, 98, 104, 98, 104, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static int elementShift([In] Buffer obj0)
    {
      switch (obj0)
      {
        case ByteBuffer _:
          return 0;
        case ShortBuffer _:
        case CharBuffer _:
          return 1;
        case IntBuffer _:
          return 2;
        case LongBuffer _:
          return 3;
        case FloatBuffer _:
          return 2;
        case DoubleBuffer _:
          return 3;
        default:
          string message = new StringBuilder().append("Can't copy to a ").append(Object.instancehelper_getClass((object) obj0).getName()).append(" instance").toString();
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new ArcRuntimeException(message);
      }
    }

    [Modifiers]
    private static void freeMemory([In] ByteBuffer obj0)
    {
      JNI.Frame frame = new JNI.Frame();
      if (Buffers.__\u003Cjniptr\u003EfreeMemory\u0028Ljava\u002Fnio\u002FByteBuffer\u003B\u0029V == IntPtr.Zero)
        Buffers.__\u003Cjniptr\u003EfreeMemory\u0028Ljava\u002Fnio\u002FByteBuffer\u003B\u0029V = JNI.Frame.GetFuncPtr(Buffers.__\u003CGetCallerID\u003E(), "arc/util/Buffers", nameof (freeMemory), "(Ljava/nio/ByteBuffer;)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Buffers.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Buffers>.Value);
        IntPtr num4 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj0);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, IntPtr)>) Buffers.__\u003Cjniptr\u003EfreeMemory\u0028Ljava\u002Fnio\u002FByteBuffer\u003B\u0029V)(num2, num3, num4);
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
    private static ByteBuffer newDisposableByteBuffer([In] int obj0)
    {
      JNI.Frame frame = new JNI.Frame();
      if (Buffers.__\u003Cjniptr\u003EnewDisposableByteBuffer\u0028I\u0029Ljava\u002Fnio\u002FByteBuffer\u003B == IntPtr.Zero)
        Buffers.__\u003Cjniptr\u003EnewDisposableByteBuffer\u0028I\u0029Ljava\u002Fnio\u002FByteBuffer\u003B = JNI.Frame.GetFuncPtr(Buffers.__\u003CGetCallerID\u003E(), "arc/util/Buffers", nameof (newDisposableByteBuffer), "(I)Ljava/nio/ByteBuffer;");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Buffers.__\u003CGetCallerID\u003E());
      try
      {
        ref JNI.Frame local = ref frame;
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Buffers>.Value);
        int num4 = obj0;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        IntPtr num5 = __calli((__FnPtr<IntPtr (IntPtr, IntPtr, int)>) Buffers.__\u003Cjniptr\u003EnewDisposableByteBuffer\u0028I\u0029Ljava\u002Fnio\u002FByteBuffer\u003B)((int) num2, num3, (IntPtr) num4);
        return (ByteBuffer) ((JNI.Frame) ref local).UnwrapLocalRef(num5);
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
    private static long getBufferAddress([In] Buffer obj0)
    {
      JNI.Frame frame = new JNI.Frame();
      if (Buffers.__\u003Cjniptr\u003EgetBufferAddress\u0028Ljava\u002Fnio\u002FBuffer\u003B\u0029J == IntPtr.Zero)
        Buffers.__\u003Cjniptr\u003EgetBufferAddress\u0028Ljava\u002Fnio\u002FBuffer\u003B\u0029J = JNI.Frame.GetFuncPtr(Buffers.__\u003CGetCallerID\u003E(), "arc/util/Buffers", nameof (getBufferAddress), "(Ljava/nio/Buffer;)J");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Buffers.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Buffers>.Value);
        IntPtr num4 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj0);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<long (IntPtr, IntPtr, IntPtr)>) Buffers.__\u003Cjniptr\u003EgetBufferAddress\u0028Ljava\u002Fnio\u002FBuffer\u003B\u0029J)(num2, num3, num4);
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

    [LineNumberTable(11)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Buffers()
    {
    }

    [LineNumberTable(new byte[] {39, 119, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void copy(int[] src, int srcOffset, Buffer dst, int numElements)
    {
      dst.limit(dst.position() + Buffers.bytesToElements(dst, numElements << 2));
      Buffers.copyJni(src, srcOffset, dst, Buffers.positionInBytes(dst), numElements << 2);
    }

    [LineNumberTable(new byte[] {54, 119, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void copy(float[] src, int srcOffset, Buffer dst, int numElements)
    {
      dst.limit(dst.position() + Buffers.bytesToElements(dst, numElements << 2));
      Buffers.copyJni(src, srcOffset, dst, Buffers.positionInBytes(dst), numElements << 2);
    }

    [LineNumberTable(new byte[] {69, 104, 117, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void copy(Buffer src, Buffer dst, int numElements)
    {
      int bytes = Buffers.elementsToBytes(src, numElements);
      dst.limit(dst.position() + Buffers.bytesToElements(dst, bytes));
      Buffers.copyJni(src, Buffers.positionInBytes(src), dst, Buffers.positionInBytes(dst), bytes);
    }

    [LineNumberTable(new byte[] {110, 105, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static ShortBuffer newShortBuffer(int numShorts)
    {
      ByteBuffer byteBuffer = ByteBuffer.allocateDirect(numShorts * 2);
      byteBuffer.order(ByteOrder.nativeOrder());
      return byteBuffer.asShortBuffer();
    }

    [LineNumberTable(new byte[] {160, 74, 108, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool isUnsafeByteBuffer(ByteBuffer buffer)
    {
      int num;
      lock (Buffers.unsafeBuffers)
        num = Buffers.unsafeBuffers.contains((object) buffer, true) ? 1 : 0;
      return num != 0;
    }

    [LineNumberTable(213)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static long getUnsafeBufferAddress(Buffer buffer) => Buffers.getBufferAddress(buffer) + (long) buffer.position();

    [LineNumberTable(new byte[] {160, 109, 113, 108, 107, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static ByteBuffer newUnsafeByteBuffer(ByteBuffer buffer)
    {
      Buffers.allocatedUnsafe += ((Buffer) buffer).capacity();
      lock (Buffers.unsafeBuffers)
        Buffers.unsafeBuffers.add((object) buffer);
      return buffer;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int getAllocatedBytesUnsafe() => Buffers.allocatedUnsafe;

    [Modifiers]
    private static void clear([In] ByteBuffer obj0, [In] int obj1)
    {
      JNI.Frame frame = new JNI.Frame();
      if (Buffers.__\u003Cjniptr\u003Eclear\u0028Ljava\u002Fnio\u002FByteBuffer\u003BI\u0029V == IntPtr.Zero)
        Buffers.__\u003Cjniptr\u003Eclear\u0028Ljava\u002Fnio\u002FByteBuffer\u003BI\u0029V = JNI.Frame.GetFuncPtr(Buffers.__\u003CGetCallerID\u003E(), "arc/util/Buffers", nameof (clear), "(Ljava/nio/ByteBuffer;I)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Buffers.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Buffers>.Value);
        IntPtr num4 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj0);
        int num5 = obj1;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, IntPtr, int)>) Buffers.__\u003Cjniptr\u003Eclear\u0028Ljava\u002Fnio\u002FByteBuffer\u003BI\u0029V)((int) num2, num3, num4, (IntPtr) num5);
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

    [LineNumberTable(new byte[] {159, 139, 77, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static Buffers()
    {
      if (ByteCodeHelper.isAlreadyInited("arc.util.Buffers"))
        return;
      Buffers.unsafeBuffers = new Seq();
      Buffers.allocatedUnsafe = 0;
    }

    static CallerID __\u003CGetCallerID\u003E()
    {
      if (Buffers.__\u003CcallerID\u003E == null)
        Buffers.__\u003CcallerID\u003E = (CallerID) new Buffers.__\u003CCallerID\u003E();
      return Buffers.__\u003CcallerID\u003E;
    }

    private sealed class __\u003CCallerID\u003E : CallerID
    {
      internal __\u003CCallerID\u003E()
      {
      }
    }
  }
}
