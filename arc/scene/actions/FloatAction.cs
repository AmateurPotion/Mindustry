// Decompiled with JetBrains decompiler
// Type: arc.scene.actions.FloatAction
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using System.Runtime.CompilerServices;

namespace arc.scene.actions
{
  public class FloatAction : TemporalAction
  {
    private float start;
    private float end;
    private float value;

    [LineNumberTable(new byte[] {159, 154, 104, 107, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public FloatAction()
    {
      FloatAction floatAction = this;
      this.start = 0.0f;
      this.end = 1f;
    }

    [LineNumberTable(new byte[] {159, 160, 104, 104, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public FloatAction(float start, float end)
    {
      FloatAction floatAction = this;
      this.start = start;
      this.end = end;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void begin() => this.value = this.start;

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void update(float percent) => this.value = this.start + (this.end - this.start) * percent;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getValue() => this.value;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setValue(float value) => this.value = value;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getStart() => this.start;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setStart(float start) => this.start = start;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getEnd() => this.end;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setEnd(float end) => this.end = end;
  }
}
