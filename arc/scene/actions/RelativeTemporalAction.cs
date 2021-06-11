// Decompiled with JetBrains decompiler
// Type: arc.scene.actions.RelativeTemporalAction
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using System.Runtime.CompilerServices;

namespace arc.scene.actions
{
  public abstract class RelativeTemporalAction : TemporalAction
  {
    private float lastPercent;

    protected internal abstract void updateRelative(float f);

    [LineNumberTable(7)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public RelativeTemporalAction()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void begin() => this.lastPercent = 0.0f;

    [LineNumberTable(new byte[] {159, 159, 112, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void update(float percent)
    {
      this.updateRelative(percent - this.lastPercent);
      this.lastPercent = percent;
    }
  }
}
