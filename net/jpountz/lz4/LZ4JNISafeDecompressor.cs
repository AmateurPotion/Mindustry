// Decompiled with JetBrains decompiler
// Type: net.jpountz.lz4.LZ4JNISafeDecompressor
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.nio;
using net.jpountz.util;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace net.jpountz.lz4
{
  internal sealed class LZ4JNISafeDecompressor : LZ4SafeDecompressor
  {
    [Modifiers]
    public static LZ4JNISafeDecompressor INSTANCE;
    private static LZ4SafeDecompressor SAFE_INSTANCE;
    [Modifiers]
    internal static bool \u0024assertionsDisabled;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(27)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal LZ4JNISafeDecompressor()
    {
    }

    [LineNumberTable(new byte[] {159, 176, 104, 107, 113, 100, 159, 18})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed int decompress(
      [In] byte[] obj0,
      [In] int obj1,
      [In] int obj2,
      [In] byte[] obj3,
      [In] int obj4,
      [In] int obj5)
    {
      SafeUtils.checkRange(obj0, obj1, obj2);
      SafeUtils.checkRange(obj3, obj4, obj5);
      int num = LZ4JNI.LZ4_decompress_safe(obj0, (ByteBuffer) null, obj1, obj2, obj3, (ByteBuffer) null, obj4, obj5);
      if (num < 0)
      {
        string msg = new StringBuilder().append("Error decoding offset ").append(obj1 - num).append(" of input buffer").toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new LZ4Exception(msg);
      }
      return num;
    }

    [LineNumberTable(new byte[] {159, 187, 103, 104, 139, 127, 9, 100, 100, 104, 103, 140, 122, 130, 105, 104, 142, 123, 163, 113, 101, 159, 19, 131, 103, 100, 146})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override int decompress(
      [In] ByteBuffer obj0,
      [In] int obj1,
      [In] int obj2,
      [In] ByteBuffer obj3,
      [In] int obj4,
      [In] int obj5)
    {
      ByteBufferUtils.checkNotReadOnly(obj3);
      ByteBufferUtils.checkRange(obj0, obj1, obj2);
      ByteBufferUtils.checkRange(obj3, obj4, obj5);
      if (!obj0.hasArray() && !obj0.isDirect() || !obj3.hasArray() && !obj3.isDirect())
        return (LZ4JNISafeDecompressor.SAFE_INSTANCE ?? (LZ4JNISafeDecompressor.SAFE_INSTANCE = LZ4Factory.safeInstance().safeDecompressor())).decompress(obj0, obj1, obj2, obj3, obj4, obj5);
      byte[] numArray1 = (byte[]) null;
      byte[] numArray2 = (byte[]) null;
      ByteBuffer byteBuffer1 = (ByteBuffer) null;
      ByteBuffer byteBuffer2 = (ByteBuffer) null;
      if (obj0.hasArray())
      {
        numArray1 = obj0.array();
        obj1 += obj0.arrayOffset();
      }
      else
      {
        if (!LZ4JNISafeDecompressor.\u0024assertionsDisabled && !obj0.isDirect())
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new AssertionError();
        }
        byteBuffer1 = obj0;
      }
      if (obj3.hasArray())
      {
        numArray2 = obj3.array();
        obj4 += obj3.arrayOffset();
      }
      else
      {
        if (!LZ4JNISafeDecompressor.\u0024assertionsDisabled && !obj3.isDirect())
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new AssertionError();
        }
        byteBuffer2 = obj3;
      }
      int num = LZ4JNI.LZ4_decompress_safe(numArray1, byteBuffer1, obj1, obj2, numArray2, byteBuffer2, obj4, obj5);
      if (num < 0)
      {
        string msg = new StringBuilder().append("Error decoding offset ").append(obj1 - num).append(" of input buffer").toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new LZ4Exception(msg);
      }
      return num;
    }

    [LineNumberTable(new byte[] {159, 136, 173, 149})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static LZ4JNISafeDecompressor()
    {
      if (ByteCodeHelper.isAlreadyInited("net.jpountz.lz4.LZ4JNISafeDecompressor"))
        return;
      LZ4JNISafeDecompressor.\u0024assertionsDisabled = !((Class) ClassLiteral<LZ4JNISafeDecompressor>.Value).desiredAssertionStatus();
      LZ4JNISafeDecompressor.INSTANCE = new LZ4JNISafeDecompressor();
    }
  }
}
