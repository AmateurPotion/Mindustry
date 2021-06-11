// Decompiled with JetBrains decompiler
// Type: arc.scene.actions.RotateToAction
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.math;
using IKVM.Attributes;
using System.Runtime.CompilerServices;

namespace arc.scene.actions
{
  public class RotateToAction : TemporalAction
  {
    private float start;
    private float end;
    private bool useShortestDirection;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setRotation(float rotation) => this.end = rotation;

    [LineNumberTable(new byte[] {159, 162, 8, 167})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public RotateToAction()
    {
      RotateToAction rotateToAction = this;
      this.useShortestDirection = false;
    }

    [LineNumberTable(new byte[] {159, 136, 66, 232, 58, 231, 71, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public RotateToAction(bool useShortestDirection)
    {
      int num = useShortestDirection ? 1 : 0;
      // ISSUE: explicit constructor call
      base.\u002Ector();
      RotateToAction rotateToAction = this;
      this.useShortestDirection = false;
      this.useShortestDirection = num != 0;
    }

    [LineNumberTable(new byte[] {159, 172, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void begin() => this.start = this.target.getRotation();

    [LineNumberTable(new byte[] {159, 177, 104, 159, 2, 127, 6})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void update(float percent)
    {
      if (this.useShortestDirection)
        this.target.setRotation(Mathf.slerp(this.start, this.end, percent));
      else
        this.target.setRotation(this.start + (this.end - this.start) * percent);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getRotation() => this.end;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isUseShortestDirection() => this.useShortestDirection;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setUseShortestDirection(bool useShortestDirection) => this.useShortestDirection = useShortestDirection;
  }
}
