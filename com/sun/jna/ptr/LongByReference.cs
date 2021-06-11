// Decompiled with JetBrains decompiler
// Type: com.sun.jna.ptr.LongByReference
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using System.Runtime.CompilerServices;

namespace com.sun.jna.ptr
{
  public class LongByReference : ByReference
  {
    [LineNumberTable(new byte[] {159, 174, 105, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public LongByReference(long value)
      : base(8)
    {
      LongByReference longByReference = this;
      this.setValue(value);
    }

    [LineNumberTable(new byte[] {159, 179, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setValue(long value) => this.getPointer().setLong(0L, value);

    [LineNumberTable(new byte[] {159, 170, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public LongByReference()
      : this(0L)
    {
    }

    [LineNumberTable(41)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual long getValue() => this.getPointer().getLong(0L);
  }
}
