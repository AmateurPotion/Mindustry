// Decompiled with JetBrains decompiler
// Type: arc.scene.actions.RotateByAction
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using System.Runtime.CompilerServices;

namespace arc.scene.actions
{
  public class RotateByAction : RelativeTemporalAction
  {
    private float amount;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setAmount(float rotationAmount) => this.amount = rotationAmount;

    [LineNumberTable(7)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public RotateByAction()
    {
    }

    [LineNumberTable(new byte[] {159, 154, 117})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void updateRelative(float percentDelta) => this.target.rotateBy(this.amount * percentDelta);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getAmount() => this.amount;
  }
}
