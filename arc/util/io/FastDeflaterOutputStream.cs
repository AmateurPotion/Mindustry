// Decompiled with JetBrains decompiler
// Type: arc.util.io.FastDeflaterOutputStream
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.io;
using java.util.zip;
using System.Runtime.CompilerServices;

namespace arc.util.io
{
  public class FastDeflaterOutputStream : DeflaterOutputStream
  {
    [Modifiers]
    private byte[] tmp;

    [LineNumberTable(new byte[] {159, 153, 233, 61, 208})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public FastDeflaterOutputStream(OutputStream outputStream)
      : base(outputStream)
    {
      FastDeflaterOutputStream deflaterOutputStream = this;
      this.tmp = new byte[1]{ (byte) 0 };
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {159, 158, 112, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void write(int var1)
    {
      this.tmp[0] = (byte) (var1 & (int) byte.MaxValue);
      this.write(this.tmp, 0, 1);
    }
  }
}
