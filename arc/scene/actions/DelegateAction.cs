// Decompiled with JetBrains decompiler
// Type: arc.scene.actions.DelegateAction
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.util.pooling;
using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;

namespace arc.scene.actions
{
  public abstract class DelegateAction : Action
  {
    protected internal Action action;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setAction(Action action) => this.action = action;

    protected internal abstract bool @delegate(float f);

    [LineNumberTable(11)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public DelegateAction()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Action getAction() => this.action;

    [LineNumberTable(new byte[] {159, 169, 103, 135, 141, 103, 35, 2})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed bool act(float delta)
    {
      Pool pool = this.getPool();
      this.setPool((Pool) null);
      try
      {
        return this.@delegate(delta);
      }
      finally
      {
        this.setPool(pool);
      }
    }

    [LineNumberTable(new byte[] {159, 180, 115})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void restart()
    {
      if (this.action == null)
        return;
      this.action.restart();
    }

    [LineNumberTable(new byte[] {159, 185, 102, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void reset()
    {
      base.reset();
      this.action = (Action) null;
    }

    [LineNumberTable(new byte[] {159, 191, 116, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setActor(Element actor)
    {
      if (this.action != null)
        this.action.setActor(actor);
      base.setActor(actor);
    }

    [LineNumberTable(new byte[] {5, 116, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setTarget(Element target)
    {
      if (this.action != null)
        this.action.setTarget(target);
      base.setTarget(target);
    }

    [LineNumberTable(60)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string toString() => new StringBuilder().append(base.toString()).append(this.action != null ? new StringBuilder().append("(").append((object) this.action).append(")").toString() : "").toString();
  }
}
