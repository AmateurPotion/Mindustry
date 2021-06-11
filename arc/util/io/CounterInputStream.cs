// Decompiled with JetBrains decompiler
// Type: arc.util.io.CounterInputStream
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.io;
using System.Runtime.CompilerServices;

namespace arc.util.io
{
  public class CounterInputStream : FilterInputStream
  {
    public int count;

    [LineNumberTable(new byte[] {159, 151, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public CounterInputStream(InputStream inputStream)
      : base(inputStream)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void resetCount() => this.count = 0;

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {159, 160, 104, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual long skip(long l)
    {
      long num = base.skip(l);
      CounterInputStream counterInputStream = this;
      counterInputStream.count = (int) ((long) counterInputStream.count + num);
      return num;
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {159, 167, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int read()
    {
      ++this.count;
      return ((InputStream) this.@in).read();
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {159, 173, 113, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int read(byte[] bytes, int offset, int length)
    {
      int num = ((InputStream) this.@in).read(bytes, offset, length);
      this.count += num;
      return num;
    }
  }
}
