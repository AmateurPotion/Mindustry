// Decompiled with JetBrains decompiler
// Type: net.jpountz.xxhash.StreamingXXHash64JavaUnsafe
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using net.jpountz.util;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace net.jpountz.xxhash
{
  internal sealed class StreamingXXHash64JavaUnsafe : AbstractStreamingXXHash64Java
  {
    [LineNumberTable(new byte[] {159, 169, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal StreamingXXHash64JavaUnsafe([In] long obj0)
      : base(obj0)
    {
    }

    [LineNumberTable(new byte[] {159, 175, 110, 103, 103, 103, 135, 159, 4, 127, 8, 152, 127, 8, 152, 127, 8, 152, 127, 8, 120, 98, 178, 139, 99, 111, 111, 127, 15, 127, 0, 102, 133, 108, 127, 5, 127, 0, 166, 106, 121, 117, 168, 106, 110, 106, 110, 138})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override long getValue()
    {
      long num1;
      if (this.totalLen >= 32L)
      {
        long v1 = this.v1;
        long v2 = this.v2;
        long v3 = this.v3;
        long v4 = this.v4;
        num1 = ((((Long.rotateLeft(v1, 1) + Long.rotateLeft(v2, 7) + Long.rotateLeft(v3, 12) + Long.rotateLeft(v4, 18) ^ Long.rotateLeft(v1 * -4417276706812531889L, 31) * -7046029288634856825L) * -7046029288634856825L + -8796714831421723037L ^ Long.rotateLeft(v2 * -4417276706812531889L, 31) * -7046029288634856825L) * -7046029288634856825L + -8796714831421723037L ^ Long.rotateLeft(v3 * -4417276706812531889L, 31) * -7046029288634856825L) * -7046029288634856825L + -8796714831421723037L ^ Long.rotateLeft(v4 * -4417276706812531889L, 31) * -7046029288634856825L) * -7046029288634856825L + -8796714831421723037L;
      }
      else
        num1 = this.seed + 2870177450012600261L;
      long num2 = num1 + this.totalLen;
      int srcOff;
      for (srcOff = 0; srcOff <= this.memSize - 8; srcOff += 8)
      {
        long num3 = Long.rotateLeft(UnsafeUtils.readLongLE(this.memory, srcOff) * -4417276706812531889L, 31) * -7046029288634856825L;
        num2 = Long.rotateLeft(num2 ^ num3, 27) * -7046029288634856825L + -8796714831421723037L;
      }
      if (srcOff <= this.memSize - 4)
      {
        num2 = Long.rotateLeft(num2 ^ ((long) UnsafeUtils.readIntLE(this.memory, srcOff) & (long) uint.MaxValue) * -7046029288634856825L, 23) * -4417276706812531889L + 1609587929392839161L;
        srcOff += 4;
      }
      for (; srcOff < this.memSize; ++srcOff)
        num2 = Long.rotateLeft(num2 ^ (long) this.memory[srcOff] * 2870177450012600261L, 11) * -7046029288634856825L;
      long num4 = (num2 ^ (long) ((ulong) num2 >> 33)) * -4417276706812531889L;
      long num5 = (num4 ^ (long) ((ulong) num4 >> 29)) * 1609587929392839161L;
      return num5 ^ (long) ((ulong) num5 >> 32);
    }

    [LineNumberTable(new byte[] {39, 136, 143, 108, 116, 110, 161, 132, 108, 156, 127, 4, 115, 150, 127, 4, 115, 150, 127, 5, 115, 150, 127, 5, 115, 150, 109, 199, 101, 103, 103, 104, 136, 103, 116, 105, 108, 133, 116, 105, 108, 133, 118, 107, 110, 133, 118, 107, 110, 170, 103, 103, 104, 168, 100, 113, 137})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void update([In] byte[] obj0, [In] int obj1, [In] int obj2)
    {
      SafeUtils.checkRange(obj0, obj1, obj2);
      this.totalLen += (long) obj2;
      if (this.memSize + obj2 < 32)
      {
        ByteCodeHelper.arraycopy_primitive_1((Array) obj0, obj1, (Array) this.memory, this.memSize, obj2);
        this.memSize += obj2;
      }
      else
      {
        int num1 = obj1 + obj2;
        if (this.memSize > 0)
        {
          ByteCodeHelper.arraycopy_primitive_1((Array) obj0, obj1, (Array) this.memory, this.memSize, 32 - this.memSize);
          this.v1 += UnsafeUtils.readLongLE(this.memory, 0) * -4417276706812531889L;
          this.v1 = Long.rotateLeft(this.v1, 31);
          this.v1 *= -7046029288634856825L;
          this.v2 += UnsafeUtils.readLongLE(this.memory, 8) * -4417276706812531889L;
          this.v2 = Long.rotateLeft(this.v2, 31);
          this.v2 *= -7046029288634856825L;
          this.v3 += UnsafeUtils.readLongLE(this.memory, 16) * -4417276706812531889L;
          this.v3 = Long.rotateLeft(this.v3, 31);
          this.v3 *= -7046029288634856825L;
          this.v4 += UnsafeUtils.readLongLE(this.memory, 24) * -4417276706812531889L;
          this.v4 = Long.rotateLeft(this.v4, 31);
          this.v4 *= -7046029288634856825L;
          obj1 += 32 - this.memSize;
          this.memSize = 0;
        }
        int num2 = num1 - 32;
        long num3 = this.v1;
        long num4 = this.v2;
        long num5 = this.v3;
        long num6 = this.v4;
        for (; obj1 <= num2; obj1 += 8)
        {
          num3 = Long.rotateLeft(num3 + UnsafeUtils.readLongLE(obj0, obj1) * -4417276706812531889L, 31) * -7046029288634856825L;
          obj1 += 8;
          num4 = Long.rotateLeft(num4 + UnsafeUtils.readLongLE(obj0, obj1) * -4417276706812531889L, 31) * -7046029288634856825L;
          obj1 += 8;
          num5 = Long.rotateLeft(num5 + UnsafeUtils.readLongLE(obj0, obj1) * -4417276706812531889L, 31) * -7046029288634856825L;
          obj1 += 8;
          num6 = Long.rotateLeft(num6 + UnsafeUtils.readLongLE(obj0, obj1) * -4417276706812531889L, 31) * -7046029288634856825L;
        }
        this.v1 = num3;
        this.v2 = num4;
        this.v3 = num5;
        this.v4 = num6;
        if (obj1 >= num1)
          return;
        ByteCodeHelper.arraycopy_primitive_1((Array) obj0, obj1, (Array) this.memory, 0, num1 - obj1);
        this.memSize = num1 - obj1;
      }
    }

    internal new class Factory : Object, StreamingXXHash64.Factory
    {
      [Modifiers]
      public static StreamingXXHash64.Factory INSTANCE;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(15)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal Factory()
      {
      }

      [LineNumberTable(21)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual StreamingXXHash64 newStreamingHash([In] long obj0) => (StreamingXXHash64) new StreamingXXHash64JavaUnsafe(obj0);

      [LineNumberTable(17)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static Factory()
      {
        if (ByteCodeHelper.isAlreadyInited("net.jpountz.xxhash.StreamingXXHash64JavaUnsafe$Factory"))
          return;
        StreamingXXHash64JavaUnsafe.Factory.INSTANCE = (StreamingXXHash64.Factory) new StreamingXXHash64JavaUnsafe.Factory();
      }
    }
  }
}
