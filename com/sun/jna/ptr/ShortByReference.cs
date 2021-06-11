// Decompiled with JetBrains decompiler
// Type: com.sun.jna.ptr.ShortByReference
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using System.Runtime.CompilerServices;

namespace com.sun.jna.ptr
{
  public class ShortByReference : ByReference
  {
    [LineNumberTable(new byte[] {159, 134, 98, 105, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ShortByReference(short value)
    {
      int num = (int) value;
      // ISSUE: explicit constructor call
      base.\u002Ector(2);
      ShortByReference shortByReference = this;
      this.setValue((short) num);
    }

    [LineNumberTable(new byte[] {159, 133, 130, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setValue(short value)
    {
      int num = (int) value;
      this.getPointer().setShort(0L, (short) num);
    }

    [LineNumberTable(new byte[] {159, 171, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ShortByReference()
      : this((short) 0)
    {
    }

    [LineNumberTable(42)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual short getValue() => this.getPointer().getShort(0L);
  }
}
