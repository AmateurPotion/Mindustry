// Decompiled with JetBrains decompiler
// Type: com.sun.jna.ptr.FloatByReference
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using System.Runtime.CompilerServices;

namespace com.sun.jna.ptr
{
  public class FloatByReference : ByReference
  {
    [LineNumberTable(new byte[] {159, 174, 105, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public FloatByReference(float value)
      : base(4)
    {
      FloatByReference floatByReference = this;
      this.setValue(value);
    }

    [LineNumberTable(new byte[] {159, 179, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setValue(float value) => this.getPointer().setFloat(0L, value);

    [LineNumberTable(new byte[] {159, 170, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public FloatByReference()
      : this(0.0f)
    {
    }

    [LineNumberTable(41)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getValue() => this.getPointer().getFloat(0L);
  }
}
