// Decompiled with JetBrains decompiler
// Type: com.sun.jna.ptr.PointerByReference
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using System.Runtime.CompilerServices;

namespace com.sun.jna.ptr
{
  public class PointerByReference : ByReference
  {
    [LineNumberTable(new byte[] {159, 181, 109, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public PointerByReference(Pointer value)
      : base(Pointer.__\u003C\u003ESIZE)
    {
      PointerByReference pointerByReference = this;
      this.setValue(value);
    }

    [LineNumberTable(new byte[] {159, 186, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setValue(Pointer value) => this.getPointer().setPointer(0L, value);

    [LineNumberTable(new byte[] {159, 177, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public PointerByReference()
      : this((Pointer) null)
    {
    }

    [LineNumberTable(48)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Pointer getValue() => this.getPointer().getPointer(0L);
  }
}
