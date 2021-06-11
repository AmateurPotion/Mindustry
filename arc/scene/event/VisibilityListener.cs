// Decompiled with JetBrains decompiler
// Type: arc.scene.event.VisibilityListener
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.scene.@event;
using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;

namespace arc.scene.@event
{
  public class VisibilityListener : Object, EventListener
  {
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool hidden() => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool shown() => false;

    [LineNumberTable(3)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public VisibilityListener()
    {
    }

    [LineNumberTable(new byte[] {159, 149, 104, 109, 135, 167})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool handle(SceneEvent @event)
    {
      if (!(@event is VisibilityEvent))
        return false;
      return ((VisibilityEvent) @event).isHide() ? this.hidden() : this.shown();
    }
  }
}
