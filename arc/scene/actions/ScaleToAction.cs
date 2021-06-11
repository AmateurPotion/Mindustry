// Decompiled with JetBrains decompiler
// Type: arc.scene.actions.ScaleToAction
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using System.Runtime.CompilerServices;

namespace arc.scene.actions
{
  public class ScaleToAction : TemporalAction
  {
    private float startX;
    private float startY;
    private float endX;
    private float endY;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setScale(float x, float y)
    {
      this.endX = x;
      this.endY = y;
    }

    [LineNumberTable(7)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ScaleToAction()
    {
    }

    [LineNumberTable(new byte[] {159, 155, 113, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void begin()
    {
      this.startX = this.target.scaleX;
      this.startY = this.target.scaleY;
    }

    [LineNumberTable(new byte[] {159, 161, 127, 32})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void update(float percent) => this.target.setScale(this.startX + (this.endX - this.startX) * percent, this.startY + (this.endY - this.startY) * percent);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setScale(float scale)
    {
      this.endX = scale;
      this.endY = scale;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getX() => this.endX;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setX(float x) => this.endX = x;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getY() => this.endY;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setY(float y) => this.endY = y;
  }
}
