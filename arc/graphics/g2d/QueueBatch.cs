// Decompiled with JetBrains decompiler
// Type: arc.graphics.g2d.QueueBatch
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using System.Runtime.CompilerServices;

namespace arc.graphics.g2d
{
  public class QueueBatch : SortedSpriteBatch
  {
    [LineNumberTable(new byte[] {159, 150, 136, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public QueueBatch()
    {
      QueueBatch queueBatch = this;
      this.sort = true;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setBlending(Blending blending) => this.blending = blending;

    [LineNumberTable(new byte[] {159, 163, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void flush() => base.flush();

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void setSort(bool sort)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void sortRequests()
    {
    }
  }
}
