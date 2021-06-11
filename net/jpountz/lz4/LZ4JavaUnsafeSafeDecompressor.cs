// Decompiled with JetBrains decompiler
// Type: net.jpountz.lz4.LZ4JavaUnsafeSafeDecompressor
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
  internal sealed class LZ4JavaUnsafeSafeDecompressor : LZ4SafeDecompressor
  {
    [Modifiers]
    public static LZ4SafeDecompressor INSTANCE;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 165, 104, 139, 100, 110, 144, 162, 164, 134, 98, 163, 112, 164, 102, 102, 99, 118, 140, 173, 134, 115, 101, 107, 103, 191, 6, 108, 101, 99, 197, 108, 101, 163, 105, 100, 134, 102, 191, 6, 103, 102, 99, 118, 140, 141, 134, 134, 103, 101, 159, 6, 142, 140, 99, 165})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override int decompress(
      [In] byte[] obj0,
      [In] int obj1,
      [In] int obj2,
      [In] byte[] obj3,
      [In] int obj4,
      [In] int obj5)
    {
      UnsafeUtils.checkRange(obj0, obj1, obj2);
      UnsafeUtils.checkRange(obj3, obj4, obj5);
      if (obj5 == 0)
      {
        if (obj2 != 1 || UnsafeUtils.readByte(obj0, obj1) != (byte) 0)
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new LZ4Exception("Output buffer too small");
        }
        return 0;
      }
      int num1 = obj1 + obj2;
      int num2 = obj4 + obj5;
      int srcOff1 = obj1;
      int num3 = obj4;
      int num4;
      int num5;
      int num6;
      while (true)
      {
        int num7 = (int) (sbyte) UnsafeUtils.readByte(obj0, srcOff1) & (int) byte.MaxValue;
        num4 = srcOff1 + 1;
        num5 = (int) ((uint) num7 >> 4);
        if (num5 == 15)
        {
          int num8 = -1;
          while (num4 < num1)
          {
            byte[] src = obj0;
            int srcOff2 = num4;
            ++num4;
            if ((num8 = (int) (sbyte) UnsafeUtils.readByte(src, srcOff2)) == -1)
              num5 += (int) byte.MaxValue;
            else
              break;
          }
          num5 += num8 & (int) byte.MaxValue;
        }
        num6 = num3 + num5;
        if (num6 <= num2 - 8 && num4 + num5 <= num1 - 8)
        {
          LZ4UnsafeUtils.wildArraycopy(obj0, num4, obj3, num3, num5);
          int srcOff2 = num4 + num5;
          int num8 = num6;
          int num9 = UnsafeUtils.readShortLE(obj0, srcOff2);
          srcOff1 = srcOff2 + 2;
          int num10 = num8 - num9;
          if (num10 >= obj4)
          {
            int num11 = num7 & 15;
            if (num11 == 15)
            {
              int num12 = -1;
              while (srcOff1 < num1)
              {
                byte[] src = obj0;
                int srcOff3 = srcOff1;
                ++srcOff1;
                if ((num12 = (int) (sbyte) UnsafeUtils.readByte(src, srcOff3)) == -1)
                  num11 += (int) byte.MaxValue;
                else
                  break;
              }
              num11 += num12 & (int) byte.MaxValue;
            }
            int num13 = num11 + 4;
            int num14 = num8 + num13;
            if (num14 > num2 - 8)
            {
              if (num14 <= num2)
                LZ4UnsafeUtils.safeIncrementalCopy(obj3, num10, num8, num13);
              else
                goto label_27;
            }
            else
              LZ4UnsafeUtils.wildIncrementalCopy(obj3, num10, num8, num14);
            num3 = num14;
          }
          else
            goto label_18;
        }
        else
          break;
      }
      if (num6 > num2)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new LZ4Exception();
      }
      if (num4 + num5 != num1)
      {
        string msg = new StringBuilder().append("Malformed input at ").append(num4).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new LZ4Exception(msg);
      }
      LZ4UnsafeUtils.safeArraycopy(obj0, num4, obj3, num3, num5);
      int num15 = num4 + num5;
      return num6 - obj4;
label_18:
      string msg1 = new StringBuilder().append("Malformed input at ").append(srcOff1).toString();
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new LZ4Exception(msg1);
label_27:
      string msg2 = new StringBuilder().append("Malformed input at ").append(srcOff1).toString();
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new LZ4Exception(msg2);
    }

    [LineNumberTable(15)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal LZ4JavaUnsafeSafeDecompressor()
    {
    }

    [LineNumberTable(new byte[] {65, 113, 159, 10, 104, 169, 104, 139, 100, 110, 144, 162, 164, 134, 98, 163, 112, 164, 102, 102, 99, 118, 140, 173, 134, 115, 101, 107, 103, 191, 6, 108, 101, 99, 197, 108, 101, 163, 105, 100, 134, 102, 191, 6, 103, 102, 99, 118, 140, 141, 134, 134, 103, 101, 159, 6, 142, 140, 99, 165})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override int decompress(
      [In] ByteBuffer obj0,
      [In] int obj1,
      [In] int obj2,
      [In] ByteBuffer obj3,
      [In] int obj4,
      [In] int obj5)
    {
      if (obj0.hasArray() && obj3.hasArray())
        return this.decompress(obj0.array(), obj1 + obj0.arrayOffset(), obj2, obj3.array(), obj4 + obj3.arrayOffset(), obj5);
      obj0 = ByteBufferUtils.inNativeByteOrder(obj0);
      obj3 = ByteBufferUtils.inNativeByteOrder(obj3);
      ByteBufferUtils.checkRange(obj0, obj1, obj2);
      ByteBufferUtils.checkRange(obj3, obj4, obj5);
      if (obj5 == 0)
      {
        if (obj2 != 1 || ByteBufferUtils.readByte(obj0, obj1) != (byte) 0)
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new LZ4Exception("Output buffer too small");
        }
        return 0;
      }
      int num1 = obj1 + obj2;
      int num2 = obj4 + obj5;
      int i1 = obj1;
      int num3 = obj4;
      int num4;
      int num5;
      int num6;
      while (true)
      {
        int num7 = (int) (sbyte) ByteBufferUtils.readByte(obj0, i1) & (int) byte.MaxValue;
        num4 = i1 + 1;
        num5 = (int) ((uint) num7 >> 4);
        if (num5 == 15)
        {
          int num8 = -1;
          while (num4 < num1)
          {
            ByteBuffer buf = obj0;
            int i2 = num4;
            ++num4;
            if ((num8 = (int) (sbyte) ByteBufferUtils.readByte(buf, i2)) == -1)
              num5 += (int) byte.MaxValue;
            else
              break;
          }
          num5 += num8 & (int) byte.MaxValue;
        }
        num6 = num3 + num5;
        if (num6 <= num2 - 8 && num4 + num5 <= num1 - 8)
        {
          LZ4ByteBufferUtils.wildArraycopy(obj0, num4, obj3, num3, num5);
          int i2 = num4 + num5;
          int num8 = num6;
          int num9 = ByteBufferUtils.readShortLE(obj0, i2);
          i1 = i2 + 2;
          int num10 = num8 - num9;
          if (num10 >= obj4)
          {
            int num11 = num7 & 15;
            if (num11 == 15)
            {
              int num12 = -1;
              while (i1 < num1)
              {
                ByteBuffer buf = obj0;
                int i3 = i1;
                ++i1;
                if ((num12 = (int) (sbyte) ByteBufferUtils.readByte(buf, i3)) == -1)
                  num11 += (int) byte.MaxValue;
                else
                  break;
              }
              num11 += num12 & (int) byte.MaxValue;
            }
            int num13 = num11 + 4;
            int num14 = num8 + num13;
            if (num14 > num2 - 8)
            {
              if (num14 <= num2)
                LZ4ByteBufferUtils.safeIncrementalCopy(obj3, num10, num8, num13);
              else
                goto label_29;
            }
            else
              LZ4ByteBufferUtils.wildIncrementalCopy(obj3, num10, num8, num14);
            num3 = num14;
          }
          else
            goto label_20;
        }
        else
          break;
      }
      if (num6 > num2)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new LZ4Exception();
      }
      if (num4 + num5 != num1)
      {
        string msg = new StringBuilder().append("Malformed input at ").append(num4).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new LZ4Exception(msg);
      }
      LZ4ByteBufferUtils.safeArraycopy(obj0, num4, obj3, num3, num5);
      int num15 = num4 + num5;
      return num6 - obj4;
label_20:
      string msg1 = new StringBuilder().append("Malformed input at ").append(i1).toString();
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new LZ4Exception(msg1);
label_29:
      string msg2 = new StringBuilder().append("Malformed input at ").append(i1).toString();
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new LZ4Exception(msg2);
    }

    [LineNumberTable(17)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static LZ4JavaUnsafeSafeDecompressor()
    {
      if (ByteCodeHelper.isAlreadyInited("net.jpountz.lz4.LZ4JavaUnsafeSafeDecompressor"))
        return;
      LZ4JavaUnsafeSafeDecompressor.INSTANCE = (LZ4SafeDecompressor) new LZ4JavaUnsafeSafeDecompressor();
    }
  }
}
