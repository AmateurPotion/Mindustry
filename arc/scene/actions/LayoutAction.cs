﻿// Decompiled with JetBrains decompiler
// Type: arc.scene.actions.LayoutAction
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using System.Runtime.CompilerServices;

namespace arc.scene.actions
{
  public class LayoutAction : Action
  {
    private bool enabled;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setLayoutEnabled(bool enabled) => this.enabled = enabled;

    [LineNumberTable(10)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public LayoutAction()
    {
    }

    [LineNumberTable(new byte[] {159, 157, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool act(float delta)
    {
      this.target.setLayoutEnabled(this.enabled);
      return true;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isEnabled() => this.enabled;
  }
}
