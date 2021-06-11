// Decompiled with JetBrains decompiler
// Type: com.sun.jna.ptr.ByteByReference
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using System.Runtime.CompilerServices;

namespace com.sun.jna.ptr
{
  public class ByteByReference : ByReference
  {
    [LineNumberTable(new byte[] {159, 134, 99, 105, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ByteByReference(byte value)
    {
      int num = (int) (sbyte) value;
      // ISSUE: explicit constructor call
      base.\u002Ector(1);
      ByteByReference byteByReference = this;
      this.setValue((byte) num);
    }

    [LineNumberTable(new byte[] {159, 133, 131, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setValue(byte value)
    {
      int num = (int) (sbyte) value;
      this.getPointer().setByte(0L, (byte) num);
    }

    [LineNumberTable(new byte[] {159, 171, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ByteByReference()
      : this((byte) 0)
    {
    }

    [LineNumberTable(42)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual byte getValue() => this.getPointer().getByte(0L);
  }
}
