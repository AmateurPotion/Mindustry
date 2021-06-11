// Decompiled with JetBrains decompiler
// Type: net.jpountz.lz4.LZ4JNIFastDecompressor
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
  internal sealed class LZ4JNIFastDecompressor : LZ4FastDecompressor
  {
    [Modifiers]
    public static LZ4JNIFastDecompressor INSTANCE;
    private static LZ4FastDecompressor SAFE_INSTANCE;
    [Modifiers]
    internal static bool \u0024assertionsDisabled;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(28)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal LZ4JNIFastDecompressor()
    {
    }

    [LineNumberTable(new byte[] {159, 177, 103, 106, 111, 100, 159, 18})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed int decompress([In] byte[] obj0, [In] int obj1, [In] byte[] obj2, [In] int obj3, [In] int obj4)
    {
      SafeUtils.checkRange(obj0, obj1);
      SafeUtils.checkRange(obj2, obj3, obj4);
      int num = LZ4JNI.LZ4_decompress_fast(obj0, (ByteBuffer) null, obj1, obj2, (ByteBuffer) null, obj3, obj4);
      if (num < 0)
      {
        string msg = new StringBuilder().append("Error decoding offset ").append(obj1 - num).append(" of input buffer").toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new LZ4Exception(msg);
      }
      return num;
    }

    [LineNumberTable(new byte[] {159, 188, 102, 103, 138, 127, 7, 100, 100, 104, 103, 140, 122, 130, 104, 103, 141, 122, 162, 112, 101, 159, 19, 131, 103, 100, 146})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override int decompress(
      [In] ByteBuffer obj0,
      [In] int obj1,
      [In] ByteBuffer obj2,
      [In] int obj3,
      [In] int obj4)
    {
      ByteBufferUtils.checkNotReadOnly(obj2);
      ByteBufferUtils.checkRange(obj0, obj1);
      ByteBufferUtils.checkRange(obj2, obj3, obj4);
      if (!obj0.hasArray() && !obj0.isDirect() || !obj2.hasArray() && !obj2.isDirect())
        return (LZ4JNIFastDecompressor.SAFE_INSTANCE ?? (LZ4JNIFastDecompressor.SAFE_INSTANCE = LZ4Factory.safeInstance().fastDecompressor())).decompress(obj0, obj1, obj2, obj3, obj4);
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
        if (!LZ4JNIFastDecompressor.\u0024assertionsDisabled && !obj0.isDirect())
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new AssertionError();
        }
        byteBuffer1 = obj0;
      }
      if (obj2.hasArray())
      {
        numArray2 = obj2.array();
        obj3 += obj2.arrayOffset();
      }
      else
      {
        if (!LZ4JNIFastDecompressor.\u0024assertionsDisabled && !obj2.isDirect())
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new AssertionError();
        }
        byteBuffer2 = obj2;
      }
      int num = LZ4JNI.LZ4_decompress_fast(numArray1, byteBuffer1, obj1, numArray2, byteBuffer2, obj3, obj4);
      if (num < 0)
      {
        string msg = new StringBuilder().append("Error decoding offset ").append(obj1 - num).append(" of input buffer").toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new LZ4Exception(msg);
      }
      return num;
    }

    [LineNumberTable(new byte[] {159, 135, 77, 149})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static LZ4JNIFastDecompressor()
    {
      if (ByteCodeHelper.isAlreadyInited("net.jpountz.lz4.LZ4JNIFastDecompressor"))
        return;
      LZ4JNIFastDecompressor.\u0024assertionsDisabled = !((Class) ClassLiteral<LZ4JNIFastDecompressor>.Value).desiredAssertionStatus();
      LZ4JNIFastDecompressor.INSTANCE = new LZ4JNIFastDecompressor();
    }
  }
}
