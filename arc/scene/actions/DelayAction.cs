// Decompiled with JetBrains decompiler
// Type: arc.scene.actions.DelayAction
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using System.Runtime.CompilerServices;

namespace arc.scene.actions
{
  public class DelayAction : DelegateAction
  {
    private float duration;
    private float time;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setDuration(float duration) => this.duration = duration;

    [LineNumberTable(new byte[] {159, 152, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public DelayAction()
    {
    }

    [LineNumberTable(new byte[] {159, 155, 104, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public DelayAction(float duration)
    {
      DelayAction delayAction = this;
      this.duration = duration;
    }

    [LineNumberTable(new byte[] {159, 161, 110, 112, 112, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override bool @delegate(float delta)
    {
      if ((double) this.time < (double) this.duration)
      {
        this.time += delta;
        if ((double) this.time < (double) this.duration)
          return false;
        delta = this.time - this.duration;
      }
      return this.action == null || this.action.act(delta);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void finish() => this.time = this.duration;

    [LineNumberTable(new byte[] {159, 176, 102, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void restart()
    {
      base.restart();
      this.time = 0.0f;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getTime() => this.time;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setTime(float time) => this.time = time;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getDuration() => this.duration;
  }
}
