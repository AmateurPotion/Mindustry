// Decompiled with JetBrains decompiler
// Type: arc.util.io.ReusableByteInStream
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.io;
using java.lang;
using System.Runtime.CompilerServices;

namespace arc.util.io
{
  public class ReusableByteInStream : ByteArrayInputStream
  {
    [LineNumberTable(new byte[] {159, 152, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ReusableByteInStream()
      : base(new byte[0])
    {
    }

    [LineNumberTable(new byte[] {159, 160, 103, 104, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setBytes(byte[] bytes)
    {
      this.pos = (__Null) 0;
      this.count = (__Null) bytes.Length;
      this.mark = (__Null) 0;
      this.buf = (__Null) bytes;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int position() => (int) this.pos;

    [LineNumberTable(new byte[] {159, 167, 103, 103, 112, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setBytes(byte[] bytes, int offset, int length)
    {
      this.buf = (__Null) bytes;
      this.pos = (__Null) offset;
      this.count = (__Null) Math.min(offset + length, bytes.Length);
      this.mark = (__Null) offset;
    }
  }
}
