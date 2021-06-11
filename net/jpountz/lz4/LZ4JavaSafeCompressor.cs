// Decompiled with JetBrains decompiler
// Type: net.jpountz.lz4.LZ4JavaSafeCompressor
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
  internal sealed class LZ4JavaSafeCompressor : LZ4Compressor
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
        short[] buf = new short[8192];
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
              int off = LZ4Utils.hash64k(SafeUtils.readInt(obj0, i2));
              num11 = obj1 + SafeUtils.readShort(buf, off);
              SafeUtils.writeShort(buf, off, i2 - obj1);
            }
            else
              goto label_21;
          }
          while (!LZ4SafeUtils.readIntEquals(obj0, num11, i2));
          int num14 = LZ4SafeUtils.commonBytesBackward(obj0, num11, i2, obj1, num6);
          i1 = i2 - num14;
          int num15 = num11 - num14;
          int num16 = i1 - num6;
          int num17 = num5;
          int num18 = num5 + 1;
          int num19 = num17;
          if (num18 + num16 + 8 + (int) ((uint) num16 >> 8) <= obj5)
          {
            if (num16 >= 15)
            {
              SafeUtils.writeByte(obj3, num19, 240);
              num18 = LZ4SafeUtils.writeLen(num16 - 15, obj3, num18);
            }
            else
              SafeUtils.writeByte(obj3, num19, num16 << 4);
            LZ4SafeUtils.wildArraycopy(obj0, num6, obj3, num18, num16);
            int off1 = num18 + num16;
            while (true)
            {
              SafeUtils.writeShortLE(obj3, off1, (int) (short) (i1 - num15));
              num5 = off1 + 2;
              int num12 = i1 + 4;
              int num13 = num15 + 4;
              int num20 = LZ4SafeUtils.commonBytes(obj0, num13, num12, num2);
              if (num5 + 6 + (int) ((uint) num20 >> 8) <= obj5)
              {
                i1 = num12 + num20;
                if (num20 >= 15)
                {
                  SafeUtils.writeByte(obj3, num19, (int) (sbyte) SafeUtils.readByte(obj3, num19) | 15);
                  num5 = LZ4SafeUtils.writeLen(num20 - 15, obj3, num5);
                }
                else
                  SafeUtils.writeByte(obj3, num19, (int) (sbyte) SafeUtils.readByte(obj3, num19) | num20);
                if (i1 <= num3)
                {
                  SafeUtils.writeShort(buf, LZ4Utils.hash64k(SafeUtils.readInt(obj0, i1 - 2)), i1 - 2 - obj1);
                  int off2 = LZ4Utils.hash64k(SafeUtils.readInt(obj0, i1));
                  num15 = obj1 + SafeUtils.readShort(buf, off2);
                  SafeUtils.writeShort(buf, off2, i1 - obj1);
                  if (LZ4SafeUtils.readIntEquals(obj0, i1, num15))
                  {
                    int num21 = num5;
                    off1 = num5 + 1;
                    num19 = num21;
                    SafeUtils.writeByte(obj3, num19, 0);
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
            int num22 = i1;
            num7 = i1 + 1;
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
        num6 = i1;
      }
label_21:
      return LZ4SafeUtils.lastLiterals(obj0, num6, num1 - num6, obj3, num5, obj5) - obj4;
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
      SafeUtils.checkRange(obj0, obj1, obj2);
      SafeUtils.checkRange(obj3, obj4, obj5);
      int num1 = obj4 + obj5;
      if (obj2 < 65547)
        return LZ4JavaSafeCompressor.compress64k(obj0, obj1, obj2, obj3, obj4, num1);
      int num2 = obj1 + obj2;
      int num3 = num2 - 5;
      int num4 = num2 - 12;
      int num5 = obj1;
      int num6 = obj4;
      int num7 = num5;
      int num8 = num5 + 1;
      int num9 = num7;
      int[] buf = new int[4096];
      Arrays.fill(buf, num9);
      int num10;
      while (true)
      {
        int num11 = num8;
        int num12 = 1;
        int num13 = 1 << LZ4Constants.SKIP_STRENGTH;
        int num14;
        int num15;
        int v;
        do
        {
          num14 = num11;
          num11 += num12;
          int num16 = num13;
          ++num13;
          int num17 = LZ4Constants.SKIP_STRENGTH & 31;
          num12 = (int) ((uint) num16 >> num17);
          if (num11 <= num4)
          {
            int off = LZ4Utils.hash(SafeUtils.readInt(obj0, num14));
            num15 = SafeUtils.readInt(buf, off);
            v = num14 - num15;
            SafeUtils.writeInt(buf, off, num14);
          }
          else
            goto label_22;
        }
        while (v >= 65536 || !LZ4SafeUtils.readIntEquals(obj0, num15, num14));
        int num18 = LZ4SafeUtils.commonBytesBackward(obj0, num15, num14, obj1, num9);
        num10 = num14 - num18;
        int num19 = num15 - num18;
        int num20 = num10 - num9;
        int num21 = num6;
        int num22 = num6 + 1;
        int num23 = num21;
        if (num22 + num20 + 8 + (int) ((uint) num20 >> 8) <= num1)
        {
          if (num20 >= 15)
          {
            SafeUtils.writeByte(obj3, num23, 240);
            num22 = LZ4SafeUtils.writeLen(num20 - 15, obj3, num22);
          }
          else
            SafeUtils.writeByte(obj3, num23, num20 << 4);
          LZ4SafeUtils.wildArraycopy(obj0, num9, obj3, num22, num20);
          int off1 = num22 + num20;
          while (true)
          {
            SafeUtils.writeShortLE(obj3, off1, v);
            num6 = off1 + 2;
            int num16 = num10 + 4;
            int num17 = LZ4SafeUtils.commonBytes(obj0, num19 + 4, num16, num3);
            if (num6 + 6 + (int) ((uint) num17 >> 8) <= num1)
            {
              num10 = num16 + num17;
              if (num17 >= 15)
              {
                SafeUtils.writeByte(obj3, num23, (int) (sbyte) SafeUtils.readByte(obj3, num23) | 15);
                num6 = LZ4SafeUtils.writeLen(num17 - 15, obj3, num6);
              }
              else
                SafeUtils.writeByte(obj3, num23, (int) (sbyte) SafeUtils.readByte(obj3, num23) | num17);
              if (num10 <= num4)
              {
                SafeUtils.writeInt(buf, LZ4Utils.hash(SafeUtils.readInt(obj0, num10 - 2)), num10 - 2);
                int off2 = LZ4Utils.hash(SafeUtils.readInt(obj0, num10));
                num19 = SafeUtils.readInt(buf, off2);
                SafeUtils.writeInt(buf, off2, num10);
                v = num10 - num19;
                if (v < 65536 && LZ4SafeUtils.readIntEquals(obj0, num19, num10))
                {
                  int num24 = num6;
                  off1 = num6 + 1;
                  num23 = num24;
                  SafeUtils.writeByte(obj3, num23, 0);
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
          int num25 = num10;
          num8 = num10 + 1;
          num9 = num25;
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
      num9 = num10;
label_22:
      return LZ4SafeUtils.lastLiterals(obj0, num9, num2 - num9, obj3, num6, num1) - obj4;
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
        short[] buf = new short[8192];
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
              int off = LZ4Utils.hash64k(ByteBufferUtils.readInt(obj0, i2));
              num11 = obj1 + SafeUtils.readShort(buf, off);
              SafeUtils.writeShort(buf, off, i2 - obj1);
            }
            else
              goto label_21;
          }
          while (!LZ4ByteBufferUtils.readIntEquals(obj0, num11, i2));
          int num14 = LZ4ByteBufferUtils.commonBytesBackward(obj0, num11, i2, obj1, num6);
          i1 = i2 - num14;
          int num15 = num11 - num14;
          int num16 = i1 - num6;
          int num17 = num5;
          int num18 = num5 + 1;
          int num19 = num17;
          if (num18 + num16 + 8 + (int) ((uint) num16 >> 8) <= obj5)
          {
            if (num16 >= 15)
            {
              ByteBufferUtils.writeByte(obj3, num19, 240);
              num18 = LZ4ByteBufferUtils.writeLen(num16 - 15, obj3, num18);
            }
            else
              ByteBufferUtils.writeByte(obj3, num19, num16 << 4);
            LZ4ByteBufferUtils.wildArraycopy(obj0, num6, obj3, num18, num16);
            int off1 = num18 + num16;
            while (true)
            {
              ByteBufferUtils.writeShortLE(obj3, off1, (int) (short) (i1 - num15));
              num5 = off1 + 2;
              int num12 = i1 + 4;
              int num13 = num15 + 4;
              int num20 = LZ4ByteBufferUtils.commonBytes(obj0, num13, num12, num2);
              if (num5 + 6 + (int) ((uint) num20 >> 8) <= obj5)
              {
                i1 = num12 + num20;
                if (num20 >= 15)
                {
                  ByteBufferUtils.writeByte(obj3, num19, (int) (sbyte) ByteBufferUtils.readByte(obj3, num19) | 15);
                  num5 = LZ4ByteBufferUtils.writeLen(num20 - 15, obj3, num5);
                }
                else
                  ByteBufferUtils.writeByte(obj3, num19, (int) (sbyte) ByteBufferUtils.readByte(obj3, num19) | num20);
                if (i1 <= num3)
                {
                  SafeUtils.writeShort(buf, LZ4Utils.hash64k(ByteBufferUtils.readInt(obj0, i1 - 2)), i1 - 2 - obj1);
                  int off2 = LZ4Utils.hash64k(ByteBufferUtils.readInt(obj0, i1));
                  num15 = obj1 + SafeUtils.readShort(buf, off2);
                  SafeUtils.writeShort(buf, off2, i1 - obj1);
                  if (LZ4ByteBufferUtils.readIntEquals(obj0, i1, num15))
                  {
                    int num21 = num5;
                    off1 = num5 + 1;
                    num19 = num21;
                    ByteBufferUtils.writeByte(obj3, num19, 0);
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
            int num22 = i1;
            num7 = i1 + 1;
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
        num6 = i1;
      }
label_21:
      return LZ4ByteBufferUtils.lastLiterals(obj0, num6, num1 - num6, obj3, num5, obj5) - obj4;
    }

    [LineNumberTable(17)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal LZ4JavaSafeCompressor()
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
        return LZ4JavaSafeCompressor.compress64k(obj0, obj1, obj2, obj3, obj4, num1);
      int num2 = obj1 + obj2;
      int num3 = num2 - 5;
      int num4 = num2 - 12;
      int num5 = obj1;
      int num6 = obj4;
      int num7 = num5;
      int num8 = num5 + 1;
      int num9 = num7;
      int[] buf = new int[4096];
      Arrays.fill(buf, num9);
      int num10;
      while (true)
      {
        int num11 = num8;
        int num12 = 1;
        int num13 = 1 << LZ4Constants.SKIP_STRENGTH;
        int num14;
        int num15;
        int i;
        do
        {
          num14 = num11;
          num11 += num12;
          int num16 = num13;
          ++num13;
          int num17 = LZ4Constants.SKIP_STRENGTH & 31;
          num12 = (int) ((uint) num16 >> num17);
          if (num11 <= num4)
          {
            int off = LZ4Utils.hash(ByteBufferUtils.readInt(obj0, num14));
            num15 = SafeUtils.readInt(buf, off);
            i = num14 - num15;
            SafeUtils.writeInt(buf, off, num14);
          }
          else
            goto label_24;
        }
        while (i >= 65536 || !LZ4ByteBufferUtils.readIntEquals(obj0, num15, num14));
        int num18 = LZ4ByteBufferUtils.commonBytesBackward(obj0, num15, num14, obj1, num9);
        num10 = num14 - num18;
        int num19 = num15 - num18;
        int num20 = num10 - num9;
        int num21 = num6;
        int num22 = num6 + 1;
        int num23 = num21;
        if (num22 + num20 + 8 + (int) ((uint) num20 >> 8) <= num1)
        {
          if (num20 >= 15)
          {
            ByteBufferUtils.writeByte(obj3, num23, 240);
            num22 = LZ4ByteBufferUtils.writeLen(num20 - 15, obj3, num22);
          }
          else
            ByteBufferUtils.writeByte(obj3, num23, num20 << 4);
          LZ4ByteBufferUtils.wildArraycopy(obj0, num9, obj3, num22, num20);
          int off1 = num22 + num20;
          while (true)
          {
            ByteBufferUtils.writeShortLE(obj3, off1, i);
            num6 = off1 + 2;
            int num16 = num10 + 4;
            int num17 = LZ4ByteBufferUtils.commonBytes(obj0, num19 + 4, num16, num3);
            if (num6 + 6 + (int) ((uint) num17 >> 8) <= num1)
            {
              num10 = num16 + num17;
              if (num17 >= 15)
              {
                ByteBufferUtils.writeByte(obj3, num23, (int) (sbyte) ByteBufferUtils.readByte(obj3, num23) | 15);
                num6 = LZ4ByteBufferUtils.writeLen(num17 - 15, obj3, num6);
              }
              else
                ByteBufferUtils.writeByte(obj3, num23, (int) (sbyte) ByteBufferUtils.readByte(obj3, num23) | num17);
              if (num10 <= num4)
              {
                SafeUtils.writeInt(buf, LZ4Utils.hash(ByteBufferUtils.readInt(obj0, num10 - 2)), num10 - 2);
                int off2 = LZ4Utils.hash(ByteBufferUtils.readInt(obj0, num10));
                num19 = SafeUtils.readInt(buf, off2);
                SafeUtils.writeInt(buf, off2, num10);
                i = num10 - num19;
                if (i < 65536 && LZ4ByteBufferUtils.readIntEquals(obj0, num19, num10))
                {
                  int num24 = num6;
                  off1 = num6 + 1;
                  num23 = num24;
                  ByteBufferUtils.writeByte(obj3, num23, 0);
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
          int num25 = num10;
          num8 = num10 + 1;
          num9 = num25;
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
      num9 = num10;
label_24:
      return LZ4ByteBufferUtils.lastLiterals(obj0, num9, num2 - num9, obj3, num6, num1) - obj4;
    }

    [LineNumberTable(19)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static LZ4JavaSafeCompressor()
    {
      if (ByteCodeHelper.isAlreadyInited("net.jpountz.lz4.LZ4JavaSafeCompressor"))
        return;
      LZ4JavaSafeCompressor.INSTANCE = (LZ4Compressor) new LZ4JavaSafeCompressor();
    }
  }
}
