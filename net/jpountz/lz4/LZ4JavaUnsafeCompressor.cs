// Decompiled with JetBrains decompiler
// Type: net.jpountz.lz4.LZ4JavaUnsafeCompressor
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.nio;
using java.util;
using net.jpountz.util;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace net.jpountz.lz4
{
  internal sealed class LZ4JavaUnsafeCompressor : LZ4Compressor
  {
    [Modifiers]
    public static LZ4Compressor INSTANCE;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 164, 100, 100, 133, 134, 131, 136, 140, 228, 70, 163, 99, 140, 99, 103, 147, 101, 165, 110, 109, 108, 174, 110, 101, 167, 166, 138, 112, 176, 102, 109, 145, 204, 109, 199, 109, 166, 100, 102, 108, 109, 144, 165, 102, 116, 145, 212, 100, 99, 197, 186, 110, 109, 140, 107, 162, 106, 105, 165, 103, 165, 115})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static int compress64k(
      [In] byte[] obj0,
      [In] int obj1,
      [In] int obj2,
      [In] byte[] obj3,
      [In] int obj4,
      [In] int obj5)
    {
      int num1 = obj1 + obj2;
      int num2 = num1 - 5;
      int num3 = num1 - 12;
      int num4 = obj1;
      int num5 = obj4;
      int num6 = num4;
      if (obj2 >= 13)
      {
        short[] numArray = new short[8192];
        int num7 = num4 + 1;
        int srcOff1;
        while (true)
        {
          int num8 = num7;
          int num9 = 1;
          int num10 = 1 << LZ4Constants.SKIP_STRENGTH;
          int srcOff2;
          int num11;
          do
          {
            srcOff2 = num8;
            num8 += num9;
            int num12 = num10;
            ++num10;
            int num13 = LZ4Constants.SKIP_STRENGTH & 31;
            num9 = (int) ((uint) num12 >> num13);
            if (num8 <= num3)
            {
              int num14 = LZ4Utils.hash64k(UnsafeUtils.readInt(obj0, srcOff2));
              num11 = obj1 + UnsafeUtils.readShort(numArray, num14);
              UnsafeUtils.writeShort(numArray, num14, srcOff2 - obj1);
            }
            else
              goto label_21;
          }
          while (!LZ4UnsafeUtils.readIntEquals(obj0, num11, srcOff2));
          int num15 = LZ4UnsafeUtils.commonBytesBackward(obj0, num11, srcOff2, obj1, num6);
          srcOff1 = srcOff2 - num15;
          int num16 = num11 - num15;
          int num17 = srcOff1 - num6;
          int num18 = num5;
          int num19 = num5 + 1;
          int srcOff3 = num18;
          if (num19 + num17 + 8 + (int) ((uint) num17 >> 8) <= obj5)
          {
            if (num17 >= 15)
            {
              UnsafeUtils.writeByte(obj3, srcOff3, 240);
              num19 = LZ4UnsafeUtils.writeLen(num17 - 15, obj3, num19);
            }
            else
              UnsafeUtils.writeByte(obj3, srcOff3, num17 << 4);
            LZ4UnsafeUtils.wildArraycopy(obj0, num6, obj3, num19, num17);
            int off = num19 + num17;
            while (true)
            {
              UnsafeUtils.writeShortLE(obj3, off, (int) (short) (srcOff1 - num16));
              num5 = off + 2;
              int num12 = srcOff1 + 4;
              int num13 = num16 + 4;
              int num14 = LZ4UnsafeUtils.commonBytes(obj0, num13, num12, num2);
              if (num5 + 6 + (int) ((uint) num14 >> 8) <= obj5)
              {
                srcOff1 = num12 + num14;
                if (num14 >= 15)
                {
                  UnsafeUtils.writeByte(obj3, srcOff3, (int) (sbyte) UnsafeUtils.readByte(obj3, srcOff3) | 15);
                  num5 = LZ4UnsafeUtils.writeLen(num14 - 15, obj3, num5);
                }
                else
                  UnsafeUtils.writeByte(obj3, srcOff3, (int) (sbyte) UnsafeUtils.readByte(obj3, srcOff3) | num14);
                if (srcOff1 <= num3)
                {
                  UnsafeUtils.writeShort(numArray, LZ4Utils.hash64k(UnsafeUtils.readInt(obj0, srcOff1 - 2)), srcOff1 - 2 - obj1);
                  int num20 = LZ4Utils.hash64k(UnsafeUtils.readInt(obj0, srcOff1));
                  num16 = obj1 + UnsafeUtils.readShort(numArray, num20);
                  UnsafeUtils.writeShort(numArray, num20, srcOff1 - obj1);
                  if (LZ4UnsafeUtils.readIntEquals(obj0, srcOff1, num16))
                  {
                    int num21 = num5;
                    off = num5 + 1;
                    srcOff3 = num21;
                    UnsafeUtils.writeByte(obj3, srcOff3, 0);
                  }
                  else
                    break;
                }
                else
                  goto label_17;
              }
              else
                goto label_12;
            }
            int num22 = srcOff1;
            num7 = srcOff1 + 1;
            num6 = num22;
          }
          else
            break;
        }
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new LZ4Exception("maxDestLen is too small");
label_12:
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new LZ4Exception("maxDestLen is too small");
label_17:
        num6 = srcOff1;
      }
label_21:
      return LZ4UnsafeUtils.lastLiterals(obj0, num6, num1 - num6, obj3, num5, obj5) - obj4;
    }

    [LineNumberTable(new byte[] {91, 104, 107, 134, 104, 174, 100, 100, 133, 103, 138, 108, 233, 70, 164, 99, 172, 100, 103, 147, 101, 165, 111, 107, 103, 107, 187, 111, 103, 167, 167, 138, 111, 176, 102, 110, 146, 205, 110, 199, 107, 166, 102, 111, 108, 144, 167, 102, 118, 146, 214, 101, 100, 197, 186, 111, 107, 107, 135, 117, 162, 106, 106, 165, 106, 133, 115})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override int compress(
      [In] byte[] obj0,
      [In] int obj1,
      [In] int obj2,
      [In] byte[] obj3,
      [In] int obj4,
      [In] int obj5)
    {
      UnsafeUtils.checkRange(obj0, obj1, obj2);
      UnsafeUtils.checkRange(obj3, obj4, obj5);
      int num1 = obj4 + obj5;
      if (obj2 < 65547)
        return LZ4JavaUnsafeCompressor.compress64k(obj0, obj1, obj2, obj3, obj4, num1);
      int num2 = obj1 + obj2;
      int num3 = num2 - 5;
      int num4 = num2 - 12;
      int num5 = obj1;
      int num6 = obj4;
      int num7 = num5;
      int num8 = num5 + 1;
      int num9 = num7;
      int[] numArray = new int[4096];
      Arrays.fill(numArray, num9);
      int srcOff1;
      while (true)
      {
        int num10 = num8;
        int num11 = 1;
        int num12 = 1 << LZ4Constants.SKIP_STRENGTH;
        int srcOff2;
        int num13;
        int v;
        do
        {
          srcOff2 = num10;
          num10 += num11;
          int num14 = num12;
          ++num12;
          int num15 = LZ4Constants.SKIP_STRENGTH & 31;
          num11 = (int) ((uint) num14 >> num15);
          if (num10 <= num4)
          {
            int num16 = LZ4Utils.hash(UnsafeUtils.readInt(obj0, srcOff2));
            num13 = UnsafeUtils.readInt(numArray, num16);
            v = srcOff2 - num13;
            UnsafeUtils.writeInt(numArray, num16, srcOff2);
          }
          else
            goto label_22;
        }
        while (v >= 65536 || !LZ4UnsafeUtils.readIntEquals(obj0, num13, srcOff2));
        int num17 = LZ4UnsafeUtils.commonBytesBackward(obj0, num13, srcOff2, obj1, num9);
        srcOff1 = srcOff2 - num17;
        int num18 = num13 - num17;
        int num19 = srcOff1 - num9;
        int num20 = num6;
        int num21 = num6 + 1;
        int srcOff3 = num20;
        if (num21 + num19 + 8 + (int) ((uint) num19 >> 8) <= num1)
        {
          if (num19 >= 15)
          {
            UnsafeUtils.writeByte(obj3, srcOff3, 240);
            num21 = LZ4UnsafeUtils.writeLen(num19 - 15, obj3, num21);
          }
          else
            UnsafeUtils.writeByte(obj3, srcOff3, num19 << 4);
          LZ4UnsafeUtils.wildArraycopy(obj0, num9, obj3, num21, num19);
          int off = num21 + num19;
          while (true)
          {
            UnsafeUtils.writeShortLE(obj3, off, v);
            num6 = off + 2;
            int num14 = srcOff1 + 4;
            int num15 = LZ4UnsafeUtils.commonBytes(obj0, num18 + 4, num14, num3);
            if (num6 + 6 + (int) ((uint) num15 >> 8) <= num1)
            {
              srcOff1 = num14 + num15;
              if (num15 >= 15)
              {
                UnsafeUtils.writeByte(obj3, srcOff3, (int) (sbyte) UnsafeUtils.readByte(obj3, srcOff3) | 15);
                num6 = LZ4UnsafeUtils.writeLen(num15 - 15, obj3, num6);
              }
              else
                UnsafeUtils.writeByte(obj3, srcOff3, (int) (sbyte) UnsafeUtils.readByte(obj3, srcOff3) | num15);
              if (srcOff1 <= num4)
              {
                UnsafeUtils.writeInt(numArray, LZ4Utils.hash(UnsafeUtils.readInt(obj0, srcOff1 - 2)), srcOff1 - 2);
                int num16 = LZ4Utils.hash(UnsafeUtils.readInt(obj0, srcOff1));
                num18 = UnsafeUtils.readInt(numArray, num16);
                UnsafeUtils.writeInt(numArray, num16, srcOff1);
                v = srcOff1 - num18;
                if (v < 65536 && LZ4UnsafeUtils.readIntEquals(obj0, num18, srcOff1))
                {
                  int num22 = num6;
                  off = num6 + 1;
                  srcOff3 = num22;
                  UnsafeUtils.writeByte(obj3, srcOff3, 0);
                }
                else
                  break;
              }
              else
                goto label_18;
            }
            else
              goto label_13;
          }
          int num23 = srcOff1;
          num8 = srcOff1 + 1;
          num9 = num23;
        }
        else
          break;
      }
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new LZ4Exception("maxDestLen is too small");
label_13:
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new LZ4Exception("maxDestLen is too small");
label_18:
      num9 = srcOff1;
label_22:
      return LZ4UnsafeUtils.lastLiterals(obj0, num9, num2 - num9, obj3, num6, num1) - obj4;
    }

    [LineNumberTable(new byte[] {160, 150, 100, 100, 133, 134, 131, 136, 140, 228, 70, 163, 99, 140, 99, 103, 147, 101, 165, 110, 109, 108, 174, 110, 101, 167, 166, 138, 112, 176, 102, 109, 145, 204, 109, 199, 109, 166, 100, 102, 108, 109, 144, 165, 102, 116, 145, 212, 100, 99, 197, 186, 110, 109, 140, 107, 162, 106, 105, 165, 103, 165, 115})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static int compress64k(
      [In] ByteBuffer obj0,
      [In] int obj1,
      [In] int obj2,
      [In] ByteBuffer obj3,
      [In] int obj4,
      [In] int obj5)
    {
      int num1 = obj1 + obj2;
      int num2 = num1 - 5;
      int num3 = num1 - 12;
      int num4 = obj1;
      int num5 = obj4;
      int num6 = num4;
      if (obj2 >= 13)
      {
        short[] numArray = new short[8192];
        int num7 = num4 + 1;
        int i1;
        while (true)
        {
          int num8 = num7;
          int num9 = 1;
          int num10 = 1 << LZ4Constants.SKIP_STRENGTH;
          int i2;
          int num11;
          do
          {
            i2 = num8;
            num8 += num9;
            int num12 = num10;
            ++num10;
            int num13 = LZ4Constants.SKIP_STRENGTH & 31;
            num9 = (int) ((uint) num12 >> num13);
            if (num8 <= num3)
            {
              int num14 = LZ4Utils.hash64k(ByteBufferUtils.readInt(obj0, i2));
              num11 = obj1 + UnsafeUtils.readShort(numArray, num14);
              UnsafeUtils.writeShort(numArray, num14, i2 - obj1);
            }
            else
              goto label_21;
          }
          while (!LZ4ByteBufferUtils.readIntEquals(obj0, num11, i2));
          int num15 = LZ4ByteBufferUtils.commonBytesBackward(obj0, num11, i2, obj1, num6);
          i1 = i2 - num15;
          int num16 = num11 - num15;
          int num17 = i1 - num6;
          int num18 = num5;
          int num19 = num5 + 1;
          int num20 = num18;
          if (num19 + num17 + 8 + (int) ((uint) num17 >> 8) <= obj5)
          {
            if (num17 >= 15)
            {
              ByteBufferUtils.writeByte(obj3, num20, 240);
              num19 = LZ4ByteBufferUtils.writeLen(num17 - 15, obj3, num19);
            }
            else
              ByteBufferUtils.writeByte(obj3, num20, num17 << 4);
            LZ4ByteBufferUtils.wildArraycopy(obj0, num6, obj3, num19, num17);
            int off = num19 + num17;
            while (true)
            {
              ByteBufferUtils.writeShortLE(obj3, off, (int) (short) (i1 - num16));
              num5 = off + 2;
              int num12 = i1 + 4;
              int num13 = num16 + 4;
              int num14 = LZ4ByteBufferUtils.commonBytes(obj0, num13, num12, num2);
              if (num5 + 6 + (int) ((uint) num14 >> 8) <= obj5)
              {
                i1 = num12 + num14;
                if (num14 >= 15)
                {
                  ByteBufferUtils.writeByte(obj3, num20, (int) (sbyte) ByteBufferUtils.readByte(obj3, num20) | 15);
                  num5 = LZ4ByteBufferUtils.writeLen(num14 - 15, obj3, num5);
                }
                else
                  ByteBufferUtils.writeByte(obj3, num20, (int) (sbyte) ByteBufferUtils.readByte(obj3, num20) | num14);
                if (i1 <= num3)
                {
                  UnsafeUtils.writeShort(numArray, LZ4Utils.hash64k(ByteBufferUtils.readInt(obj0, i1 - 2)), i1 - 2 - obj1);
                  int num21 = LZ4Utils.hash64k(ByteBufferUtils.readInt(obj0, i1));
                  num16 = obj1 + UnsafeUtils.readShort(numArray, num21);
                  UnsafeUtils.writeShort(numArray, num21, i1 - obj1);
                  if (LZ4ByteBufferUtils.readIntEquals(obj0, i1, num16))
                  {
                    int num22 = num5;
                    off = num5 + 1;
                    num20 = num22;
                    ByteBufferUtils.writeByte(obj3, num20, 0);
                  }
                  else
                    break;
                }
                else
                  goto label_17;
              }
              else
                goto label_12;
            }
            int num23 = i1;
            num7 = i1 + 1;
            num6 = num23;
          }
          else
            break;
        }
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new LZ4Exception("maxDestLen is too small");
label_12:
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new LZ4Exception("maxDestLen is too small");
label_17:
        num6 = i1;
      }
label_21:
      return LZ4ByteBufferUtils.lastLiterals(obj0, num6, num1 - num6, obj3, num5, obj5) - obj4;
    }

    [LineNumberTable(17)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal LZ4JavaUnsafeCompressor()
    {
    }

    [LineNumberTable(new byte[] {161, 13, 113, 159, 10, 104, 137, 104, 107, 134, 104, 174, 100, 100, 133, 103, 138, 108, 233, 70, 164, 99, 172, 100, 103, 147, 101, 165, 111, 107, 103, 107, 187, 111, 103, 167, 167, 138, 111, 176, 102, 110, 146, 205, 110, 199, 107, 166, 102, 111, 108, 144, 167, 102, 118, 146, 214, 101, 100, 197, 186, 111, 107, 107, 135, 117, 162, 106, 106, 165, 106, 133, 115})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override int compress(
      [In] ByteBuffer obj0,
      [In] int obj1,
      [In] int obj2,
      [In] ByteBuffer obj3,
      [In] int obj4,
      [In] int obj5)
    {
      if (obj0.hasArray() && obj3.hasArray())
        return this.compress(obj0.array(), obj1 + obj0.arrayOffset(), obj2, obj3.array(), obj4 + obj3.arrayOffset(), obj5);
      obj0 = ByteBufferUtils.inNativeByteOrder(obj0);
      obj3 = ByteBufferUtils.inNativeByteOrder(obj3);
      ByteBufferUtils.checkRange(obj0, obj1, obj2);
      ByteBufferUtils.checkRange(obj3, obj4, obj5);
      int num1 = obj4 + obj5;
      if (obj2 < 65547)
        return LZ4JavaUnsafeCompressor.compress64k(obj0, obj1, obj2, obj3, obj4, num1);
      int num2 = obj1 + obj2;
      int num3 = num2 - 5;
      int num4 = num2 - 12;
      int num5 = obj1;
      int num6 = obj4;
      int num7 = num5;
      int num8 = num5 + 1;
      int num9 = num7;
      int[] numArray = new int[4096];
      Arrays.fill(numArray, num9);
      int i1;
      while (true)
      {
        int num10 = num8;
        int num11 = 1;
        int num12 = 1 << LZ4Constants.SKIP_STRENGTH;
        int i2;
        int num13;
        int i3;
        do
        {
          i2 = num10;
          num10 += num11;
          int num14 = num12;
          ++num12;
          int num15 = LZ4Constants.SKIP_STRENGTH & 31;
          num11 = (int) ((uint) num14 >> num15);
          if (num10 <= num4)
          {
            int num16 = LZ4Utils.hash(ByteBufferUtils.readInt(obj0, i2));
            num13 = UnsafeUtils.readInt(numArray, num16);
            i3 = i2 - num13;
            UnsafeUtils.writeInt(numArray, num16, i2);
          }
          else
            goto label_24;
        }
        while (i3 >= 65536 || !LZ4ByteBufferUtils.readIntEquals(obj0, num13, i2));
        int num17 = LZ4ByteBufferUtils.commonBytesBackward(obj0, num13, i2, obj1, num9);
        i1 = i2 - num17;
        int num18 = num13 - num17;
        int num19 = i1 - num9;
        int num20 = num6;
        int num21 = num6 + 1;
        int num22 = num20;
        if (num21 + num19 + 8 + (int) ((uint) num19 >> 8) <= num1)
        {
          if (num19 >= 15)
          {
            ByteBufferUtils.writeByte(obj3, num22, 240);
            num21 = LZ4ByteBufferUtils.writeLen(num19 - 15, obj3, num21);
          }
          else
            ByteBufferUtils.writeByte(obj3, num22, num19 << 4);
          LZ4ByteBufferUtils.wildArraycopy(obj0, num9, obj3, num21, num19);
          int off = num21 + num19;
          while (true)
          {
            ByteBufferUtils.writeShortLE(obj3, off, i3);
            num6 = off + 2;
            int num14 = i1 + 4;
            int num15 = LZ4ByteBufferUtils.commonBytes(obj0, num18 + 4, num14, num3);
            if (num6 + 6 + (int) ((uint) num15 >> 8) <= num1)
            {
              i1 = num14 + num15;
              if (num15 >= 15)
              {
                ByteBufferUtils.writeByte(obj3, num22, (int) (sbyte) ByteBufferUtils.readByte(obj3, num22) | 15);
                num6 = LZ4ByteBufferUtils.writeLen(num15 - 15, obj3, num6);
              }
              else
                ByteBufferUtils.writeByte(obj3, num22, (int) (sbyte) ByteBufferUtils.readByte(obj3, num22) | num15);
              if (i1 <= num4)
              {
                UnsafeUtils.writeInt(numArray, LZ4Utils.hash(ByteBufferUtils.readInt(obj0, i1 - 2)), i1 - 2);
                int num16 = LZ4Utils.hash(ByteBufferUtils.readInt(obj0, i1));
                num18 = UnsafeUtils.readInt(numArray, num16);
                UnsafeUtils.writeInt(numArray, num16, i1);
                i3 = i1 - num18;
                if (i3 < 65536 && LZ4ByteBufferUtils.readIntEquals(obj0, num18, i1))
                {
                  int num23 = num6;
                  off = num6 + 1;
                  num22 = num23;
                  ByteBufferUtils.writeByte(obj3, num22, 0);
                }
                else
                  break;
              }
              else
                goto label_20;
            }
            else
              goto label_15;
          }
          int num24 = i1;
          num8 = i1 + 1;
          num9 = num24;
        }
        else
          break;
      }
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new LZ4Exception("maxDestLen is too small");
label_15:
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new LZ4Exception("maxDestLen is too small");
label_20:
      num9 = i1;
label_24:
      return LZ4ByteBufferUtils.lastLiterals(obj0, num9, num2 - num9, obj3, num6, num1) - obj4;
    }

    [LineNumberTable(19)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static LZ4JavaUnsafeCompressor()
    {
      if (ByteCodeHelper.isAlreadyInited("net.jpountz.lz4.LZ4JavaUnsafeCompressor"))
        return;
      LZ4JavaUnsafeCompressor.INSTANCE = (LZ4Compressor) new LZ4JavaUnsafeCompressor();
    }
  }
}
