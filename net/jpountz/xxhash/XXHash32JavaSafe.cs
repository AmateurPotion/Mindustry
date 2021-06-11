// Decompiled with JetBrains decompiler
// Type: net.jpountz.xxhash.XXHash32JavaSafe
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
  internal sealed class XXHash32JavaSafe : XXHash32
  {
    [Modifiers]
    public static XXHash32 INSTANCE;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 165, 136, 164, 104, 101, 111, 105, 102, 138, 112, 105, 104, 133, 112, 105, 104, 133, 114, 107, 106, 133, 114, 107, 106, 101, 135, 127, 6, 98, 170, 134, 102, 114, 113, 167, 100, 121, 113, 167, 106, 106, 106, 106, 138})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override int hash([In] byte[] obj0, [In] int obj1, [In] int obj2, [In] int obj3)
    {
      SafeUtils.checkRange(obj0, obj1, obj2);
      int num1 = obj1 + obj2;
      int num2;
      if (obj2 >= 16)
      {
        int num3 = num1 - 16;
        int num4 = obj3 - 1640531535 - 2048144777;
        int num5 = obj3 - 2048144777;
        int num6 = obj3 + 0;
        int num7 = obj3 - -1640531535;
        do
        {
          num4 = Integer.rotateLeft(num4 + SafeUtils.readIntLE(obj0, obj1) * -2048144777, 13) * -1640531535;
          obj1 += 4;
          num5 = Integer.rotateLeft(num5 + SafeUtils.readIntLE(obj0, obj1) * -2048144777, 13) * -1640531535;
          obj1 += 4;
          num6 = Integer.rotateLeft(num6 + SafeUtils.readIntLE(obj0, obj1) * -2048144777, 13) * -1640531535;
          obj1 += 4;
          num7 = Integer.rotateLeft(num7 + SafeUtils.readIntLE(obj0, obj1) * -2048144777, 13) * -1640531535;
          obj1 += 4;
        }
        while (obj1 <= num3);
        num2 = Integer.rotateLeft(num4, 1) + Integer.rotateLeft(num5, 7) + Integer.rotateLeft(num6, 12) + Integer.rotateLeft(num7, 18);
      }
      else
        num2 = obj3 + 374761393;
      int num8 = num2 + obj2;
      for (; obj1 <= num1 - 4; obj1 += 4)
        num8 = Integer.rotateLeft(num8 + SafeUtils.readIntLE(obj0, obj1) * -1028477379, 17) * 668265263;
      for (; obj1 < num1; ++obj1)
        num8 = Integer.rotateLeft(num8 + ((int) (sbyte) SafeUtils.readByte(obj0, obj1) & (int) byte.MaxValue) * 374761393, 11) * -1640531535;
      int num9 = (num8 ^ (int) ((uint) num8 >> 15)) * -2048144777;
      int num10 = (num9 ^ (int) ((uint) num9 >> 13)) * -1028477379;
      return num10 ^ (int) ((uint) num10 >> 16);
    }

    [LineNumberTable(16)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal XXHash32JavaSafe()
    {
    }

    [LineNumberTable(new byte[] {37, 104, 152, 104, 136, 164, 104, 101, 111, 105, 102, 138, 112, 105, 104, 133, 112, 105, 104, 133, 114, 107, 106, 133, 114, 107, 106, 101, 135, 127, 6, 98, 170, 134, 102, 114, 113, 167, 100, 121, 113, 167, 106, 106, 106, 106, 138})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override int hash([In] ByteBuffer obj0, [In] int obj1, [In] int obj2, [In] int obj3)
    {
      if (obj0.hasArray())
        return this.hash(obj0.array(), obj1 + obj0.arrayOffset(), obj2, obj3);
      ByteBufferUtils.checkRange(obj0, obj1, obj2);
      obj0 = ByteBufferUtils.inLittleEndianOrder(obj0);
      int num1 = obj1 + obj2;
      int num2;
      if (obj2 >= 16)
      {
        int num3 = num1 - 16;
        int num4 = obj3 - 1640531535 - 2048144777;
        int num5 = obj3 - 2048144777;
        int num6 = obj3 + 0;
        int num7 = obj3 - -1640531535;
        do
        {
          num4 = Integer.rotateLeft(num4 + ByteBufferUtils.readIntLE(obj0, obj1) * -2048144777, 13) * -1640531535;
          obj1 += 4;
          num5 = Integer.rotateLeft(num5 + ByteBufferUtils.readIntLE(obj0, obj1) * -2048144777, 13) * -1640531535;
          obj1 += 4;
          num6 = Integer.rotateLeft(num6 + ByteBufferUtils.readIntLE(obj0, obj1) * -2048144777, 13) * -1640531535;
          obj1 += 4;
          num7 = Integer.rotateLeft(num7 + ByteBufferUtils.readIntLE(obj0, obj1) * -2048144777, 13) * -1640531535;
          obj1 += 4;
        }
        while (obj1 <= num3);
        num2 = Integer.rotateLeft(num4, 1) + Integer.rotateLeft(num5, 7) + Integer.rotateLeft(num6, 12) + Integer.rotateLeft(num7, 18);
      }
      else
        num2 = obj3 + 374761393;
      int num8 = num2 + obj2;
      for (; obj1 <= num1 - 4; obj1 += 4)
        num8 = Integer.rotateLeft(num8 + ByteBufferUtils.readIntLE(obj0, obj1) * -1028477379, 17) * 668265263;
      for (; obj1 < num1; ++obj1)
        num8 = Integer.rotateLeft(num8 + ((int) (sbyte) ByteBufferUtils.readByte(obj0, obj1) & (int) byte.MaxValue) * 374761393, 11) * -1640531535;
      int num9 = (num8 ^ (int) ((uint) num8 >> 15)) * -2048144777;
      int num10 = (num9 ^ (int) ((uint) num9 >> 13)) * -1028477379;
      return num10 ^ (int) ((uint) num10 >> 16);
    }

    [LineNumberTable(18)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static XXHash32JavaSafe()
    {
      if (ByteCodeHelper.isAlreadyInited("net.jpountz.xxhash.XXHash32JavaSafe"))
        return;
      XXHash32JavaSafe.INSTANCE = (XXHash32) new XXHash32JavaSafe();
    }
  }
}
