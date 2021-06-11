// Decompiled with JetBrains decompiler
// Type: arc.scene.actions.TemporalAction
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.math;
using arc.util.pooling;
using IKVM.Attributes;
using System.Runtime.CompilerServices;

namespace arc.scene.actions
{
  public abstract class TemporalAction : Action
  {
    private float duration;
    private float time;
    private Interp interpolation;
    private bool reverse;
    private bool began;
    private bool complete;

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void begin()
    {
    }

    protected internal abstract void update(float f);

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void end()
    {
    }

    [LineNumberTable(new byte[] {159, 158, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public TemporalAction()
    {
    }

    [LineNumberTable(new byte[] {159, 161, 104, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public TemporalAction(float duration)
    {
      TemporalAction temporalAction = this;
      this.duration = duration;
    }

    [LineNumberTable(new byte[] {159, 165, 104, 104, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public TemporalAction(float duration, Interp interpolation)
    {
      TemporalAction temporalAction = this;
      this.duration = duration;
      this.interpolation = interpolation;
    }

    [LineNumberTable(new byte[] {159, 172, 106, 103, 135, 104, 102, 135, 112, 151, 104, 136, 111, 150, 121, 110, 139, 103, 35, 2})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool act(float delta)
    {
      if (this.complete)
        return true;
      Pool pool = this.getPool();
      this.setPool((Pool) null);
      try
      {
        if (!this.began)
        {
          this.begin();
          this.began = true;
        }
        this.time += delta;
        this.complete = (double) this.time >= (double) this.duration;
        float f;
        if (this.complete)
        {
          f = 1f;
        }
        else
        {
          f = this.time / this.duration;
          if (this.interpolation != null)
            f = this.interpolation.apply(f);
        }
        this.update(!this.reverse ? f : 1f - f);
        if (this.complete)
          this.end();
        return this.complete;
      }
      finally
      {
        this.setPool(pool);
      }
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void finish() => this.time = this.duration;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void restart()
    {
      this.time = 0.0f;
      this.began = false;
      this.complete = false;
    }

    [LineNumberTable(new byte[] {37, 102, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void reset()
    {
      base.reset();
      this.reverse = false;
      this.interpolation = (Interp) null;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getTime() => this.time;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setTime(float time) => this.time = time;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getDuration() => this.duration;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setDuration(float duration) => this.duration = duration;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Interp getInterpolation() => this.interpolation;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setInterpolation(Interp interpolation) => this.interpolation = interpolation;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isReverse() => this.reverse;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setReverse(bool reverse) => this.reverse = reverse;
  }
}
