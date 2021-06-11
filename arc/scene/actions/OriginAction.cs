// Decompiled with JetBrains decompiler
// Type: arc.scene.actions.OriginAction
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using System.Runtime.CompilerServices;

namespace arc.scene.actions
{
  public class OriginAction : Action
  {
    [LineNumberTable(6)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public OriginAction()
    {
    }

    [LineNumberTable(new byte[] {159, 152, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool act(float delta)
    {
      this.actor.setOrigin(1);
      return true;
    }
  }
}
