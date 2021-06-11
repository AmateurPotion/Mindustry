// Decompiled with JetBrains decompiler
// Type: net.jpountz.lz4.LZ4SafeDecompressor
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using java.nio;
using java.util;
using System.Runtime.CompilerServices;

namespace net.jpountz.lz4
{
  public abstract class LZ4SafeDecompressor : Object, LZ4UnknownSizeDecompressor
  {
    [LineNumberTable(74)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public int decompress(byte[] src, int srcOff, int srcLen, byte[] dest, int destOff) => this.decompress(src, srcOff, srcLen, dest, destOff, dest.Length - destOff);

    public abstract int decompress(byte[] barr1, int i1, int i2, byte[] barr2, int i3, int i4);

    [LineNumberTable(new byte[] {65, 104, 110, 101, 136})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public byte[] decompress(byte[] src, int srcOff, int srcLen, int maxDestLen)
    {
      byte[] barr2 = new byte[maxDestLen];
      int num = this.decompress(src, srcOff, srcLen, barr2, 0, maxDestLen);
      if (num != barr2.Length)
        barr2 = Arrays.copyOf(barr2, num);
      return barr2;
    }

    public abstract int decompress(
      ByteBuffer bb1,
      int i1,
      int i2,
      ByteBuffer bb2,
      int i3,
      int i4);

    [LineNumberTable(27)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public LZ4SafeDecompressor()
    {
    }

    [LineNumberTable(87)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public int decompress(byte[] src, byte[] dest) => this.decompress(src, 0, src.Length, dest, 0);

    [LineNumberTable(133)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public byte[] decompress(byte[] src, int maxDestLen) => this.decompress(src, 0, src.Length, maxDestLen);

    [LineNumberTable(new byte[] {95, 127, 2, 109, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public void decompress(ByteBuffer src, ByteBuffer dest)
    {
      int num = this.decompress(src, ((Buffer) src).position(), ((Buffer) src).remaining(), dest, ((Buffer) dest).position(), ((Buffer) dest).remaining());
      ((Buffer) src).position(((Buffer) src).limit());
      ((Buffer) dest).position(((Buffer) dest).position() + num);
    }

    [LineNumberTable(152)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toString() => Object.instancehelper_getClass((object) this).getSimpleName();
  }
}
