// Decompiled with JetBrains decompiler
// Type: arc.struct.GridBits
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;

namespace arc.@struct
{
  public class GridBits : Object
  {
    [Modifiers]
    private Bits bits;
    [Modifiers]
    private int width;
    [Modifiers]
    private int height;

    [LineNumberTable(new byte[] {159, 149, 104, 103, 103, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public GridBits(int width, int height)
    {
      GridBits gridBits = this;
      this.width = width;
      this.height = height;
      this.bits = new Bits(width * height);
    }

    [LineNumberTable(new byte[] {159, 165, 117})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void set(int x, int y) => this.bits.set(x + y * this.width);

    [LineNumberTable(new byte[] {159, 160, 124})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool get(int x, int y) => x < this.width && y < this.height && (x >= 0 && y >= 0) && this.bits.get(x + y * this.width);

    [LineNumberTable(new byte[] {159, 136, 162, 99, 151, 149})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void set(int x, int y, bool b)
    {
      if (b)
        this.bits.set(x + y * this.width);
      else
        this.bits.clear(x + y * this.width);
    }

    [LineNumberTable(new byte[] {159, 156, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void set(GridBits other) => this.bits.set(other.bits);

    [LineNumberTable(new byte[] {159, 177, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void clear() => this.bits.clear();

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int width() => this.width;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int height() => this.height;
  }
}
