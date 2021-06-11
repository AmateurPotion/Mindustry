// Decompiled with JetBrains decompiler
// Type: net.jpountz.lz4.LZ4JavaUnsafeFastDecompressor
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.nio;
using net.jpountz.util;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace net.jpountz.lz4
{
  internal sealed class LZ4JavaUnsafeFastDecompressor : LZ4FastDecompressor
  {
    [Modifiers]
    public static LZ4FastDecompressor INSTANCE;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 165, 103, 138, 100, 106, 159, 6, 194, 134, 98, 163, 111, 164, 101, 102, 98, 114, 140, 173, 134, 103, 101, 191, 6, 107, 101, 99, 197, 107, 101, 163, 105, 100, 134, 102, 191, 6, 102, 102, 98, 114, 140, 141, 134, 134, 103, 101, 159, 6, 141, 139, 99, 165})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override int decompress([In] byte[] obj0, [In] int obj1, [In] byte[] obj2, [In] int obj3, [In] int obj4)
    {
      UnsafeUtils.checkRange(obj0, obj1);
      UnsafeUtils.checkRange(obj2, obj3, obj4);
      if (obj4 == 0)
      {
        if (UnsafeUtils.readByte(obj0, obj1) != (byte) 0)
        {
          string msg = new StringBuilder().append("Malformed input at ").append(obj1).toString();
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new LZ4Exception(msg);
        }
        return 1;
      }
      int num1 = obj3 + obj4;
      int srcOff1 = obj1;
      int num2 = obj3;
      int num3;
      int num4;
      int num5;
      while (true)
      {
        int num6 = (int) (sbyte) UnsafeUtils.readByte(obj0, srcOff1) & (int) byte.MaxValue;
        num3 = srcOff1 + 1;
        num4 = (int) ((uint) num6 >> 4);
        if (num4 == 15)
        {
          int num7;
          while (true)
          {
            byte[] src = obj0;
            int srcOff2 = num3;
            ++num3;
            if ((num7 = (int) (sbyte) UnsafeUtils.readByte(src, srcOff2)) == -1)
              num4 += (int) byte.MaxValue;
            else
              break;
          }
          num4 += num7 & (int) byte.MaxValue;
        }
        num5 = num2 + num4;
        if (num5 <= num1 - 8)
        {
          LZ4UnsafeUtils.wildArraycopy(obj0, num3, obj2, num2, num4);
          int srcOff2 = num3 + num4;
          int num7 = num5;
          int num8 = UnsafeUtils.readShortLE(obj0, srcOff2);
          srcOff1 = srcOff2 + 2;
          int num9 = num7 - num8;
          if (num9 >= obj3)
          {
            int num10 = num6 & 15;
            if (num10 == 15)
            {
              int num11;
              while (true)
              {
                byte[] src = obj0;
                int srcOff3 = srcOff1;
                ++srcOff1;
                if ((num11 = (int) (sbyte) UnsafeUtils.readByte(src, srcOff3)) == -1)
                  num10 += (int) byte.MaxValue;
                else
                  break;
              }
              num10 += num11 & (int) byte.MaxValue;
            }
            int num12 = num10 + 4;
            int num13 = num7 + num12;
            if (num13 > num1 - 8)
            {
              if (num13 <= num1)
                LZ4UnsafeUtils.safeIncrementalCopy(obj2, num9, num7, num12);
              else
                goto label_23;
            }
            else
              LZ4UnsafeUtils.wildIncrementalCopy(obj2, num9, num7, num13);
            num2 = num13;
          }
          else
            goto label_15;
        }
        else
          break;
      }
      if (num5 != num1)
      {
        string msg = new StringBuilder().append("Malformed input at ").append(num3).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new LZ4Exception(msg);
      }
      LZ4UnsafeUtils.safeArraycopy(obj0, num3, obj2, num2, num4);
      return num3 + num4 - obj1;
label_15:
      string msg1 = new StringBuilder().append("Malformed input at ").append(srcOff1).toString();
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new LZ4Exception(msg1);
label_23:
      string msg2 = new StringBuilder().append("Malformed input at ").append(srcOff1).toString();
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new LZ4Exception(msg2);
    }

    [LineNumberTable(15)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal LZ4JavaUnsafeFastDecompressor()
    {
    }

    [LineNumberTable(new byte[] {61, 112, 159, 7, 104, 168, 103, 138, 100, 106, 159, 6, 194, 134, 98, 163, 111, 164, 101, 102, 98, 114, 140, 173, 134, 103, 101, 191, 6, 107, 101, 99, 197, 107, 101, 163, 105, 100, 134, 102, 191, 6, 102, 102, 98, 114, 140, 141, 134, 134, 103, 101, 159, 6, 141, 139, 99, 165})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override int decompress(
      [In] ByteBuffer obj0,
      [In] int obj1,
      [In] ByteBuffer obj2,
      [In] int obj3,
      [In] int obj4)
    {
      if (obj0.hasArray() && obj2.hasArray())
        return this.decompress(obj0.array(), obj1 + obj0.arrayOffset(), obj2.array(), obj3 + obj2.arrayOffset(), obj4);
      obj0 = ByteBufferUtils.inNativeByteOrder(obj0);
      obj2 = ByteBufferUtils.inNativeByteOrder(obj2);
      ByteBufferUtils.checkRange(obj0, obj1);
      ByteBufferUtils.checkRange(obj2, obj3, obj4);
      if (obj4 == 0)
      {
        if (ByteBufferUtils.readByte(obj0, obj1) != (byte) 0)
        {
          string msg = new StringBuilder().append("Malformed input at ").append(obj1).toString();
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new LZ4Exception(msg);
        }
        return 1;
      }
      int num1 = obj3 + obj4;
      int i1 = obj1;
      int num2 = obj3;
      int num3;
      int num4;
      int num5;
      while (true)
      {
        int num6 = (int) (sbyte) ByteBufferUtils.readByte(obj0, i1) & (int) byte.MaxValue;
        num3 = i1 + 1;
        num4 = (int) ((uint) num6 >> 4);
        if (num4 == 15)
        {
          int num7;
          while (true)
          {
            ByteBuffer buf = obj0;
            int i2 = num3;
            ++num3;
            if ((num7 = (int) (sbyte) ByteBufferUtils.readByte(buf, i2)) == -1)
              num4 += (int) byte.MaxValue;
            else
              break;
          }
          num4 += num7 & (int) byte.MaxValue;
        }
        num5 = num2 + num4;
        if (num5 <= num1 - 8)
        {
          LZ4ByteBufferUtils.wildArraycopy(obj0, num3, obj2, num2, num4);
          int i2 = num3 + num4;
          int num7 = num5;
          int num8 = ByteBufferUtils.readShortLE(obj0, i2);
          i1 = i2 + 2;
          int num9 = num7 - num8;
          if (num9 >= obj3)
          {
            int num10 = num6 & 15;
            if (num10 == 15)
            {
              int num11;
              while (true)
              {
                ByteBuffer buf = obj0;
                int i3 = i1;
                ++i1;
                if ((num11 = (int) (sbyte) ByteBufferUtils.readByte(buf, i3)) == -1)
                  num10 += (int) byte.MaxValue;
                else
                  break;
              }
              num10 += num11 & (int) byte.MaxValue;
            }
            int num12 = num10 + 4;
            int num13 = num7 + num12;
            if (num13 > num1 - 8)
            {
              if (num13 <= num1)
                LZ4ByteBufferUtils.safeIncrementalCopy(obj2, num9, num7, num12);
              else
                goto label_25;
            }
            else
              LZ4ByteBufferUtils.wildIncrementalCopy(obj2, num9, num7, num13);
            num2 = num13;
          }
          else
            goto label_17;
        }
        else
          break;
      }
      if (num5 != num1)
      {
        string msg = new StringBuilder().append("Malformed input at ").append(num3).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new LZ4Exception(msg);
      }
      LZ4ByteBufferUtils.safeArraycopy(obj0, num3, obj2, num2, num4);
      return num3 + num4 - obj1;
label_17:
      string msg1 = new StringBuilder().append("Malformed input at ").append(i1).toString();
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new LZ4Exception(msg1);
label_25:
      string msg2 = new StringBuilder().append("Malformed input at ").append(i1).toString();
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new LZ4Exception(msg2);
    }

    [LineNumberTable(17)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static LZ4JavaUnsafeFastDecompressor()
    {
      if (ByteCodeHelper.isAlreadyInited("net.jpountz.lz4.LZ4JavaUnsafeFastDecompressor"))
        return;
      LZ4JavaUnsafeFastDecompressor.INSTANCE = (LZ4FastDecompressor) new LZ4JavaUnsafeFastDecompressor();
    }
  }
}
