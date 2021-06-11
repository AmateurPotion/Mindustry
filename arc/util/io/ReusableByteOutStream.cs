// Decompiled with JetBrains decompiler
// Type: arc.util.io.ReusableByteOutStream
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.io;
using System.Runtime.CompilerServices;

namespace arc.util.io
{
  public class ReusableByteOutStream : ByteArrayOutputStream
  {
    [LineNumberTable(new byte[] {159, 150, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ReusableByteOutStream(int capacity)
      : base(capacity)
    {
    }

    [LineNumberTable(new byte[] {159, 153, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ReusableByteOutStream()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual byte[] getBytes() => (byte[]) this.buf;
  }
}
