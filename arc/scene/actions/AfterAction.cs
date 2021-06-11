// Decompiled with JetBrains decompiler
// Type: arc.scene.actions.AfterAction
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using IKVM.Attributes;
using System.Runtime.CompilerServices;

namespace arc.scene.actions
{
  public class AfterAction : DelegateAction
  {
    [Signature("Larc/struct/Seq<Larc/scene/Action;>;")]
    private Seq waitForActions;

    [LineNumberTable(new byte[] {159, 153, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public AfterAction()
    {
      AfterAction afterAction = this;
      this.waitForActions = new Seq(false, 4);
    }

    [LineNumberTable(new byte[] {159, 158, 117, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setTarget(Element target)
    {
      if (target != null)
        this.waitForActions.addAll(target.getActions());
      base.setTarget(target);
    }

    [LineNumberTable(new byte[] {159, 164, 102, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void restart()
    {
      base.restart();
      this.waitForActions.clear();
    }

    [LineNumberTable(new byte[] {159, 170, 108, 117, 114, 114, 105, 241, 61, 230, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override bool @delegate(float delta)
    {
      Seq actions = this.target.getActions();
      if (actions.size == 1)
        this.waitForActions.clear();
      for (int index = this.waitForActions.size - 1; index >= 0; index += -1)
      {
        Action action = (Action) this.waitForActions.get(index);
        if (actions.indexOf((object) action, true) == -1)
          this.waitForActions.remove(index);
      }
      return this.waitForActions.size <= 0 && this.action.act(delta);
    }
  }
}
