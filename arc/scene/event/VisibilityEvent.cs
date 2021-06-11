// Decompiled with JetBrains decompiler
// Type: arc.scene.event.VisibilityEvent
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.scene.@event;
using IKVM.Attributes;
using System.Runtime.CompilerServices;

namespace arc.scene.@event
{
  public class VisibilityEvent : SceneEvent
  {
    private bool hide;

    [LineNumberTable(new byte[] {159, 140, 98, 104, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public VisibilityEvent(bool hide)
    {
      int num = hide ? 1 : 0;
      // ISSUE: explicit constructor call
      base.\u002Ector();
      VisibilityEvent visibilityEvent = this;
      this.hide = num != 0;
    }

    [LineNumberTable(new byte[] {159, 148, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public VisibilityEvent()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isHide() => this.hide;
  }
}
