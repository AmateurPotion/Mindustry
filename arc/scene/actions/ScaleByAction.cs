// Decompiled with JetBrains decompiler
// Type: arc.scene.actions.ScaleByAction
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using System.Runtime.CompilerServices;

namespace arc.scene.actions
{
  public class ScaleByAction : RelativeTemporalAction
  {
    private float amountX;
    private float amountY;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setAmount(float x, float y)
    {
      this.amountX = x;
      this.amountY = y;
    }

    [LineNumberTable(new byte[] {159, 152, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ScaleByAction()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setAmount(float scale)
    {
      this.amountX = scale;
      this.amountY = scale;
    }

    [LineNumberTable(new byte[] {159, 155, 104, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ScaleByAction(float amount)
    {
      ScaleByAction scaleByAction = this;
      this.setAmount(amount);
    }

    [LineNumberTable(new byte[] {159, 161, 127, 0})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void updateRelative(float percentDelta) => this.target.scaleBy(this.amountX * percentDelta, this.amountY * percentDelta);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getAmountX() => this.amountX;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setAmountX(float x) => this.amountX = x;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getAmountY() => this.amountY;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setAmountY(float y) => this.amountY = y;
  }
}
