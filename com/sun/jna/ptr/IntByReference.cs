// Decompiled with JetBrains decompiler
// Type: com.sun.jna.ptr.IntByReference
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using System.Runtime.CompilerServices;

namespace com.sun.jna.ptr
{
  public class IntByReference : ByReference
  {
    [LineNumberTable(new byte[] {159, 175, 105, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public IntByReference(int value)
      : base(4)
    {
      IntByReference intByReference = this;
      this.setValue(value);
    }

    [LineNumberTable(new byte[] {159, 180, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setValue(int value) => this.getPointer().setInt(0L, value);

    [LineNumberTable(new byte[] {159, 171, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public IntByReference()
      : this(0)
    {
    }

    [LineNumberTable(42)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getValue() => this.getPointer().getInt(0L);
  }
}
