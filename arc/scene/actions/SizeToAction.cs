// Decompiled with JetBrains decompiler
// Type: arc.scene.actions.SizeToAction
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using System.Runtime.CompilerServices;

namespace arc.scene.actions
{
  public class SizeToAction : TemporalAction
  {
    private float startWidth;
    private float startHeight;
    private float endWidth;
    private float endHeight;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setSize(float width, float height)
    {
      this.endWidth = width;
      this.endHeight = height;
    }

    [LineNumberTable(7)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public SizeToAction()
    {
    }

    [LineNumberTable(new byte[] {159, 155, 114, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void begin()
    {
      this.startWidth = this.target.getWidth();
      this.startHeight = this.target.getHeight();
    }

    [LineNumberTable(new byte[] {159, 161, 127, 32})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void update(float percent) => this.target.setSize(this.startWidth + (this.endWidth - this.startWidth) * percent, this.startHeight + (this.endHeight - this.startHeight) * percent);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getWidth() => this.endWidth;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setWidth(float width) => this.endWidth = width;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getHeight() => this.endHeight;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setHeight(float height) => this.endHeight = height;
  }
}
