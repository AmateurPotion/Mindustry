// Decompiled with JetBrains decompiler
// Type: arc.scene.event.ChangeListener
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.scene.@event;
using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;

namespace arc.scene.@event
{
  public abstract class ChangeListener : Object, EventListener
  {
    public abstract void changed(ChangeListener.ChangeEvent clce, Element e);

    [LineNumberTable(9)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ChangeListener()
    {
    }

    [LineNumberTable(new byte[] {159, 154, 106, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool handle(SceneEvent @event)
    {
      if (!(@event is ChangeListener.ChangeEvent))
        return false;
      this.changed((ChangeListener.ChangeEvent) @event, @event.targetActor);
      return false;
    }

    public class ChangeEvent : SceneEvent
    {
      [LineNumberTable(24)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public ChangeEvent()
      {
      }
    }
  }
}
