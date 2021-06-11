// Decompiled with JetBrains decompiler
// Type: arc.scene.actions.SizeByAction
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using System.Runtime.CompilerServices;

namespace arc.scene.actions
{
  public class SizeByAction : RelativeTemporalAction
  {
    private float amountWidth;
    private float amountHeight;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setAmount(float width, float height)
    {
      this.amountWidth = width;
      this.amountHeight = height;
    }

    [LineNumberTable(7)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public SizeByAction()
    {
    }

    [LineNumberTable(new byte[] {159, 154, 127, 0})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void updateRelative(float percentDelta) => this.target.sizeBy(this.amountWidth * percentDelta, this.amountHeight * percentDelta);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getAmountWidth() => this.amountWidth;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setAmountWidth(float width) => this.amountWidth = width;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getAmountHeight() => this.amountHeight;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setAmountHeight(float height) => this.amountHeight = height;
  }
}
