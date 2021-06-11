// Decompiled with JetBrains decompiler
// Type: arc.scene.actions.RemoveAction
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using System.Runtime.CompilerServices;

namespace arc.scene.actions
{
  public class RemoveAction : Action
  {
    private Action action;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setAction(Action action) => this.action = action;

    [LineNumberTable(9)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public RemoveAction()
    {
    }

    [LineNumberTable(new byte[] {159, 156, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool act(float delta)
    {
      this.target.removeAction(this.action);
      return true;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Action getAction() => this.action;

    [LineNumberTable(new byte[] {159, 170, 102, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void reset()
    {
      base.reset();
      this.action = (Action) null;
    }
  }
}
