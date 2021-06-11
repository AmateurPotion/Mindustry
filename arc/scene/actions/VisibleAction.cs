// Decompiled with JetBrains decompiler
// Type: arc.scene.actions.VisibleAction
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using System.Runtime.CompilerServices;

namespace arc.scene.actions
{
  public class VisibleAction : Action
  {
    private bool visible;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setVisible(bool visible) => this.visible = visible;

    [LineNumberTable(9)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public VisibleAction()
    {
    }

    [LineNumberTable(new byte[] {159, 156, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool act(float delta)
    {
      this.target.visible = this.visible;
      return true;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isVisible() => this.visible;
  }
}
