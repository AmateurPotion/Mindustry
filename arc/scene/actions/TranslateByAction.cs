// Decompiled with JetBrains decompiler
// Type: arc.scene.actions.TranslateByAction
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using System.Runtime.CompilerServices;

namespace arc.scene.actions
{
  public class TranslateByAction : RelativeTemporalAction
  {
    private float amountX;
    private float amountY;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setAmount(float x, float y)
    {
      this.amountX = x;
      this.amountY = y;
    }

    [LineNumberTable(7)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public TranslateByAction()
    {
    }

    [LineNumberTable(new byte[] {159, 154, 127, 6})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void updateRelative(float percentDelta) => this.target.translation.add(this.amountX * percentDelta, this.amountY * percentDelta);

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
