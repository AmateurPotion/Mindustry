// Decompiled with JetBrains decompiler
// Type: net.jpountz.xxhash.XXHash64JavaSafe
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

namespace net.jpountz.xxhash
{
  internal sealed class XXHash64JavaSafe : XXHash64
  {
    [Modifiers]
    public static XXHash64 INSTANCE;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 165, 136, 164, 104, 101, 119, 109, 103, 142, 116, 105, 108, 133, 116, 105, 108, 133, 118, 107, 110, 133, 118, 107, 110, 101, 135, 159, 6, 127, 8, 152, 127, 8, 152, 127, 15, 152, 127, 15, 120, 98, 174, 135, 102, 105, 127, 15, 127, 0, 101, 133, 102, 126, 127, 0, 165, 100, 126, 117, 167, 106, 110, 106, 110, 138})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override long hash([In] byte[] obj0, [In] int obj1, [In] int obj2, [In] long obj3)
    {
      SafeUtils.checkRange(obj0, obj1, obj2);
      int num1 = obj1 + obj2;
      long num2;
      if (obj2 >= 32)
      {
        int num3 = num1 - 32;
        long num4 = obj3 + -7046029288634856825L + -4417276706812531889L;
        long num5 = obj3 + -4417276706812531889L;
        long num6 = obj3 + 0L;
        long num7 = obj3 - -7046029288634856825L;
        do
        {
          num4 = Long.rotateLeft(num4 + SafeUtils.readLongLE(obj0, obj1) * -4417276706812531889L, 31) * -7046029288634856825L;
          obj1 += 8;
          num5 = Long.rotateLeft(num5 + SafeUtils.readLongLE(obj0, obj1) * -4417276706812531889L, 31) * -7046029288634856825L;
          obj1 += 8;
          num6 = Long.rotateLeft(num6 + SafeUtils.readLongLE(obj0, obj1) * -4417276706812531889L, 31) * -7046029288634856825L;
          obj1 += 8;
          num7 = Long.rotateLeft(num7 + SafeUtils.readLongLE(obj0, obj1) * -4417276706812531889L, 31) * -7046029288634856825L;
          obj1 += 8;
        }
        while (obj1 <= num3);
        num2 = ((((Long.rotateLeft(num4, 1) + Long.rotateLeft(num5, 7) + Long.rotateLeft(num6, 12) + Long.rotateLeft(num7, 18) ^ Long.rotateLeft(num4 * -4417276706812531889L, 31) * -7046029288634856825L) * -7046029288634856825L + -8796714831421723037L ^ Long.rotateLeft(num5 * -4417276706812531889L, 31) * -7046029288634856825L) * -7046029288634856825L + -8796714831421723037L ^ Long.rotateLeft(num6 * -4417276706812531889L, 31) * -7046029288634856825L) * -7046029288634856825L + -8796714831421723037L ^ Long.rotateLeft(num7 * -4417276706812531889L, 31) * -7046029288634856825L) * -7046029288634856825L + -8796714831421723037L;
      }
      else
        num2 = obj3 + 2870177450012600261L;
      long num8 = num2 + (long) obj2;
      for (; obj1 <= num1 - 8; obj1 += 8)
      {
        long num3 = Long.rotateLeft(SafeUtils.readLongLE(obj0, obj1) * -4417276706812531889L, 31) * -7046029288634856825L;
        num8 = Long.rotateLeft(num8 ^ num3, 27) * -7046029288634856825L + -8796714831421723037L;
      }
      if (obj1 <= num1 - 4)
      {
        num8 = Long.rotateLeft(num8 ^ ((long) SafeUtils.readIntLE(obj0, obj1) & (long) uint.MaxValue) * -7046029288634856825L, 23) * -4417276706812531889L + 1609587929392839161L;
        obj1 += 4;
      }
      for (; obj1 < num1; ++obj1)
        num8 = Long.rotateLeft(num8 ^ (long) ((int) (sbyte) SafeUtils.readByte(obj0, obj1) & (int) byte.MaxValue) * 2870177450012600261L, 11) * -7046029288634856825L;
      long num9 = (num8 ^ (long) ((ulong) num8 >> 33)) * -4417276706812531889L;
      long num10 = (num9 ^ (long) ((ulong) num9 >> 29)) * 1609587929392839161L;
      return num10 ^ (long) ((ulong) num10 >> 32);
    }

    [LineNumberTable(16)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal XXHash64JavaSafe()
    {
    }

    [LineNumberTable(new byte[] {56, 104, 152, 104, 136, 164, 104, 101, 119, 109, 103, 142, 116, 105, 108, 133, 116, 105, 108, 133, 118, 107, 110, 133, 118, 107, 110, 101, 135, 159, 6, 127, 8, 152, 127, 8, 152, 127, 15, 152, 127, 15, 120, 98, 174, 135, 102, 105, 127, 15, 127, 0, 101, 133, 102, 126, 127, 0, 165, 100, 126, 117, 167, 106, 110, 106, 110, 138})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override long hash([In] ByteBuffer obj0, [In] int obj1, [In] int obj2, [In] long obj3)
    {
      if (obj0.hasArray())
        return this.hash(obj0.array(), obj1 + obj0.arrayOffset(), obj2, obj3);
      ByteBufferUtils.checkRange(obj0, obj1, obj2);
      obj0 = ByteBufferUtils.inLittleEndianOrder(obj0);
      int num1 = obj1 + obj2;
      long num2;
      if (obj2 >= 32)
      {
        int num3 = num1 - 32;
        long num4 = obj3 + -7046029288634856825L + -4417276706812531889L;
        long num5 = obj3 + -4417276706812531889L;
        long num6 = obj3 + 0L;
        long num7 = obj3 - -7046029288634856825L;
        do
        {
          num4 = Long.rotateLeft(num4 + ByteBufferUtils.readLongLE(obj0, obj1) * -4417276706812531889L, 31) * -7046029288634856825L;
          obj1 += 8;
          num5 = Long.rotateLeft(num5 + ByteBufferUtils.readLongLE(obj0, obj1) * -4417276706812531889L, 31) * -7046029288634856825L;
          obj1 += 8;
          num6 = Long.rotateLeft(num6 + ByteBufferUtils.readLongLE(obj0, obj1) * -4417276706812531889L, 31) * -7046029288634856825L;
          obj1 += 8;
          num7 = Long.rotateLeft(num7 + ByteBufferUtils.readLongLE(obj0, obj1) * -4417276706812531889L, 31) * -7046029288634856825L;
          obj1 += 8;
        }
        while (obj1 <= num3);
        num2 = ((((Long.rotateLeft(num4, 1) + Long.rotateLeft(num5, 7) + Long.rotateLeft(num6, 12) + Long.rotateLeft(num7, 18) ^ Long.rotateLeft(num4 * -4417276706812531889L, 31) * -7046029288634856825L) * -7046029288634856825L + -8796714831421723037L ^ Long.rotateLeft(num5 * -4417276706812531889L, 31) * -7046029288634856825L) * -7046029288634856825L + -8796714831421723037L ^ Long.rotateLeft(num6 * -4417276706812531889L, 31) * -7046029288634856825L) * -7046029288634856825L + -8796714831421723037L ^ Long.rotateLeft(num7 * -4417276706812531889L, 31) * -7046029288634856825L) * -7046029288634856825L + -8796714831421723037L;
      }
      else
        num2 = obj3 + 2870177450012600261L;
      long num8 = num2 + (long) obj2;
      for (; obj1 <= num1 - 8; obj1 += 8)
      {
        long num3 = Long.rotateLeft(ByteBufferUtils.readLongLE(obj0, obj1) * -4417276706812531889L, 31) * -7046029288634856825L;
        num8 = Long.rotateLeft(num8 ^ num3, 27) * -7046029288634856825L + -8796714831421723037L;
      }
      if (obj1 <= num1 - 4)
      {
        num8 = Long.rotateLeft(num8 ^ ((long) ByteBufferUtils.readIntLE(obj0, obj1) & (long) uint.MaxValue) * -7046029288634856825L, 23) * -4417276706812531889L + 1609587929392839161L;
        obj1 += 4;
      }
      for (; obj1 < num1; ++obj1)
        num8 = Long.rotateLeft(num8 ^ (long) ((int) (sbyte) ByteBufferUtils.readByte(obj0, obj1) & (int) byte.MaxValue) * 2870177450012600261L, 11) * -7046029288634856825L;
      long num9 = (num8 ^ (long) ((ulong) num8 >> 33)) * -4417276706812531889L;
      long num10 = (num9 ^ (long) ((ulong) num9 >> 29)) * 1609587929392839161L;
      return num10 ^ (long) ((ulong) num10 >> 32);
    }

    [LineNumberTable(18)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static XXHash64JavaSafe()
    {
      if (ByteCodeHelper.isAlreadyInited("net.jpountz.xxhash.XXHash64JavaSafe"))
        return;
      XXHash64JavaSafe.INSTANCE = (XXHash64) new XXHash64JavaSafe();
    }
  }
}
