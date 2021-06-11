// Decompiled with JetBrains decompiler
// Type: arc.scene.actions.MoveToAction
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using System.Runtime.CompilerServices;

namespace arc.scene.actions
{
  public class MoveToAction : TemporalAction
  {
    private float startX;
    private float startY;
    private float endX;
    private float endY;
    private int alignment;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setPosition(float x, float y)
    {
      this.endX = x;
      this.endY = y;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setPosition(float x, float y, int alignment)
    {
      this.endX = x;
      this.endY = y;
      this.alignment = alignment;
    }

    [LineNumberTable(new byte[] {159, 151, 168})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public MoveToAction()
    {
      MoveToAction moveToAction = this;
      this.alignment = 12;
    }

    [LineNumberTable(new byte[] {159, 158, 120, 120})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void begin()
    {
      this.startX = this.target.getX(this.alignment);
      this.startY = this.target.getY(this.alignment);
    }

    [LineNumberTable(new byte[] {159, 164, 127, 38})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void update(float percent) => this.target.setPosition(this.startX + (this.endX - this.startX) * percent, this.startY + (this.endY - this.startY) * percent, this.alignment);

    [LineNumberTable(new byte[] {159, 169, 102, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void reset()
    {
      base.reset();
      this.alignment = 12;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getX() => this.endX;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setX(float x) => this.endX = x;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getY() => this.endY;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setY(float y) => this.endY = y;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getAlignment() => this.alignment;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setAlignment(int alignment) => this.alignment = alignment;
  }
}
