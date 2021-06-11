// Decompiled with JetBrains decompiler
// Type: arc.scene.actions.TimeScaleAction
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using System.Runtime.CompilerServices;

namespace arc.scene.actions
{
  public class TimeScaleAction : DelegateAction
  {
    private float scale;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setScale(float scale) => this.scale = scale;

    [LineNumberTable(7)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public TimeScaleAction()
    {
    }

    [LineNumberTable(12)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override bool @delegate(float delta) => this.action == null || this.action.act(delta * this.scale);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getScale() => this.scale;
  }
}
