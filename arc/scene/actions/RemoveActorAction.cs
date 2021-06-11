// Decompiled with JetBrains decompiler
// Type: arc.scene.actions.RemoveActorAction
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using System.Runtime.CompilerServices;

namespace arc.scene.actions
{
  public class RemoveActorAction : Action
  {
    private bool removed;

    [LineNumberTable(9)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public RemoveActorAction()
    {
    }

    [LineNumberTable(new byte[] {159, 156, 104, 103, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool act(float delta)
    {
      if (!this.removed)
      {
        this.removed = true;
        this.target.remove();
      }
      return true;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void restart() => this.removed = false;
  }
}
