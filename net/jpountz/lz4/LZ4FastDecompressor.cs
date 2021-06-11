// Decompiled with JetBrains decompiler
// Type: net.jpountz.lz4.LZ4FastDecompressor
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using java.nio;
using System.Runtime.CompilerServices;

namespace net.jpountz.lz4
{
  public abstract class LZ4FastDecompressor : Object, LZ4Decompressor
  {
    [LineNumberTable(113)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public byte[] decompress(byte[] src, int destLen) => this.decompress(src, 0, destLen);

    public abstract int decompress(byte[] barr1, int i1, byte[] barr2, int i2, int i3);

    [LineNumberTable(65)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public int decompress(byte[] src, byte[] dest, int destLen) => this.decompress(src, 0, dest, 0, destLen);

    [LineNumberTable(new byte[] {49, 103, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public byte[] decompress(byte[] src, int srcOff, int destLen)
    {
      byte[] barr2 = new byte[destLen];
      this.decompress(src, srcOff, barr2, 0, destLen);
      return barr2;
    }

    public abstract int decompress(ByteBuffer bb1, int i1, ByteBuffer bb2, int i2, int i3);

    [LineNumberTable(26)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public LZ4FastDecompressor()
    {
    }

    [LineNumberTable(77)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public int decompress(byte[] src, byte[] dest) => this.decompress(src, dest, dest.Length);

    [LineNumberTable(new byte[] {75, 123, 109, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public void decompress(ByteBuffer src, ByteBuffer dest)
    {
      int num = this.decompress(src, ((Buffer) src).position(), dest, ((Buffer) dest).position(), ((Buffer) dest).remaining());
      ((Buffer) dest).position(((Buffer) dest).limit());
      ((Buffer) src).position(((Buffer) src).position() + num);
    }

    [LineNumberTable(132)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toString() => Object.instancehelper_getClass((object) this).getSimpleName();
  }
}
