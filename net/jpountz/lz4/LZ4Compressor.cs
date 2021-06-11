// Decompiled with JetBrains decompiler
// Type: net.jpountz.lz4.LZ4Compressor
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
  public abstract class LZ4Compressor : Object
  {
    [LineNumberTable(146)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public byte[] compress(byte[] src) => this.compress(src, 0, src.Length);

    [LineNumberTable(35)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public int maxCompressedLength(int length) => LZ4Utils.maxCompressedLength(length);

    [LineNumberTable(95)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public int compress(byte[] src, int srcOff, int srcLen, byte[] dest, int destOff) => this.compress(src, srcOff, srcLen, dest, destOff, dest.Length - destOff);

    public abstract int compress(byte[] barr1, int i1, int i2, byte[] barr2, int i3, int i4);

    [LineNumberTable(new byte[] {82, 104, 103, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public byte[] compress(byte[] src, int srcOff, int srcLen)
    {
      byte[] dest = new byte[this.maxCompressedLength(srcLen)];
      int num = this.compress(src, srcOff, srcLen, dest, 0);
      return Arrays.copyOf(dest, num);
    }

    public abstract int compress(ByteBuffer bb1, int i1, int i2, ByteBuffer bb2, int i3, int i4);

    [LineNumberTable(25)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public LZ4Compressor()
    {
    }

    [LineNumberTable(108)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public int compress(byte[] src, byte[] dest) => this.compress(src, 0, src.Length, dest, 0);

    [LineNumberTable(new byte[] {108, 127, 2, 109, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public void compress(ByteBuffer src, ByteBuffer dest)
    {
      int num = this.compress(src, ((Buffer) src).position(), ((Buffer) src).remaining(), dest, ((Buffer) dest).position(), ((Buffer) dest).remaining());
      ((Buffer) src).position(((Buffer) src).limit());
      ((Buffer) dest).position(((Buffer) dest).position() + num);
    }

    [LineNumberTable(165)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toString() => Object.instancehelper_getClass((object) this).getSimpleName();
  }
}
