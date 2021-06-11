// Decompiled with JetBrains decompiler
// Type: net.jpountz.xxhash.StreamingXXHash32JavaUnsafe
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
  internal sealed class StreamingXXHash32JavaUnsafe : AbstractStreamingXXHash32Java
  {
    [LineNumberTable(new byte[] {159, 169, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal StreamingXXHash32JavaUnsafe([In] int obj0)
      : base(obj0)
    {
    }

    [LineNumberTable(new byte[] {159, 175, 107, 159, 25, 173, 139, 98, 107, 117, 111, 166, 105, 124, 111, 166, 103, 104, 103, 104, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override int getValue()
    {
      int num1 = (int) ((this.totalLen < 16L ? (long) (this.seed + 374761393) : (long) (Integer.rotateLeft(this.v1, 1) + Integer.rotateLeft(this.v2, 7) + Integer.rotateLeft(this.v3, 12) + Integer.rotateLeft(this.v4, 18))) + this.totalLen);
      int srcOff;
      for (srcOff = 0; srcOff <= this.memSize - 4; srcOff += 4)
        num1 = Integer.rotateLeft(num1 + UnsafeUtils.readIntLE(this.memory, srcOff) * -1028477379, 17) * 668265263;
      for (; srcOff < this.memSize; ++srcOff)
        num1 = Integer.rotateLeft(num1 + ((int) (sbyte) UnsafeUtils.readByte(this.memory, srcOff) & (int) byte.MaxValue) * 374761393, 11) * -1640531535;
      int num2 = (num1 ^ (int) ((uint) num1 >> 15)) * -2048144777;
      int num3 = (num2 ^ (int) ((uint) num2 >> 13)) * -1028477379;
      return num3 ^ (int) ((uint) num3 >> 16);
    }

    [LineNumberTable(new byte[] {15, 136, 143, 108, 116, 110, 161, 132, 108, 156, 127, 0, 115, 146, 127, 0, 115, 146, 127, 0, 115, 146, 127, 1, 115, 146, 109, 199, 101, 103, 103, 104, 136, 103, 112, 105, 104, 133, 112, 105, 104, 133, 114, 107, 106, 133, 114, 107, 106, 170, 103, 103, 104, 168, 100, 113, 137})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void update([In] byte[] obj0, [In] int obj1, [In] int obj2)
    {
      SafeUtils.checkRange(obj0, obj1, obj2);
      this.totalLen += (long) obj2;
      if (this.memSize + obj2 < 16)
      {
        ByteCodeHelper.arraycopy_primitive_1((Array) obj0, obj1, (Array) this.memory, this.memSize, obj2);
        this.memSize += obj2;
      }
      else
      {
        int num1 = obj1 + obj2;
        if (this.memSize > 0)
        {
          ByteCodeHelper.arraycopy_primitive_1((Array) obj0, obj1, (Array) this.memory, this.memSize, 16 - this.memSize);
          this.v1 += UnsafeUtils.readIntLE(this.memory, 0) * -2048144777;
          this.v1 = Integer.rotateLeft(this.v1, 13);
          this.v1 *= -1640531535;
          this.v2 += UnsafeUtils.readIntLE(this.memory, 4) * -2048144777;
          this.v2 = Integer.rotateLeft(this.v2, 13);
          this.v2 *= -1640531535;
          this.v3 += UnsafeUtils.readIntLE(this.memory, 8) * -2048144777;
          this.v3 = Integer.rotateLeft(this.v3, 13);
          this.v3 *= -1640531535;
          this.v4 += UnsafeUtils.readIntLE(this.memory, 12) * -2048144777;
          this.v4 = Integer.rotateLeft(this.v4, 13);
          this.v4 *= -1640531535;
          obj1 += 16 - this.memSize;
          this.memSize = 0;
        }
        int num2 = num1 - 16;
        int num3 = this.v1;
        int num4 = this.v2;
        int num5 = this.v3;
        int num6 = this.v4;
        for (; obj1 <= num2; obj1 += 4)
        {
          num3 = Integer.rotateLeft(num3 + UnsafeUtils.readIntLE(obj0, obj1) * -2048144777, 13) * -1640531535;
          obj1 += 4;
          num4 = Integer.rotateLeft(num4 + UnsafeUtils.readIntLE(obj0, obj1) * -2048144777, 13) * -1640531535;
          obj1 += 4;
          num5 = Integer.rotateLeft(num5 + UnsafeUtils.readIntLE(obj0, obj1) * -2048144777, 13) * -1640531535;
          obj1 += 4;
          num6 = Integer.rotateLeft(num6 + UnsafeUtils.readIntLE(obj0, obj1) * -2048144777, 13) * -1640531535;
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

    internal new class Factory : Object, StreamingXXHash32.Factory
    {
      [Modifiers]
      public static StreamingXXHash32.Factory INSTANCE;

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
      public virtual StreamingXXHash32 newStreamingHash([In] int obj0) => (StreamingXXHash32) new StreamingXXHash32JavaUnsafe(obj0);

      [LineNumberTable(17)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static Factory()
      {
        if (ByteCodeHelper.isAlreadyInited("net.jpountz.xxhash.StreamingXXHash32JavaUnsafe$Factory"))
          return;
        StreamingXXHash32JavaUnsafe.Factory.INSTANCE = (StreamingXXHash32.Factory) new StreamingXXHash32JavaUnsafe.Factory();
      }
    }
  }
}
