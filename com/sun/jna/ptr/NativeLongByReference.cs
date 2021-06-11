// Decompiled with JetBrains decompiler
// Type: com.sun.jna.ptr.NativeLongByReference
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using System.Runtime.CompilerServices;

namespace com.sun.jna.ptr
{
  public class NativeLongByReference : ByReference
  {
    [LineNumberTable(new byte[] {159, 176, 109, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public NativeLongByReference(NativeLong value)
      : base(NativeLong.__\u003C\u003ESIZE)
    {
      NativeLongByReference nativeLongByReference = this;
      this.setValue(value);
    }

    [LineNumberTable(new byte[] {159, 181, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setValue(NativeLong value) => this.getPointer().setNativeLong(0L, value);

    [LineNumberTable(new byte[] {159, 172, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public NativeLongByReference()
      : this(new NativeLong(0L))
    {
    }

    [LineNumberTable(43)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual NativeLong getValue() => this.getPointer().getNativeLong(0L);
  }
}
