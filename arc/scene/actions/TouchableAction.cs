// Decompiled with JetBrains decompiler
// Type: arc.scene.actions.TouchableAction
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.scene.@event;
using IKVM.Attributes;
using System.Runtime.CompilerServices;

namespace arc.scene.actions
{
  public class TouchableAction : Action
  {
    private Touchable touchable;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void touchable(Touchable touchable) => this.touchable = touchable;

    [LineNumberTable(10)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public TouchableAction()
    {
    }

    [LineNumberTable(new byte[] {159, 157, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool act(float delta)
    {
      this.target.touchable = this.touchable;
      return true;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Touchable getTouchable() => this.touchable;
  }
}
