// Decompiled with JetBrains decompiler
// Type: arc.scene.event.SceneEvent
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.scene.@event;
using arc.util.pooling;
using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;

namespace arc.scene.@event
{
  public class SceneEvent : Object, Pool.Poolable
  {
    public Element targetActor;
    public Element listenerActor;
    public bool capture;
    public bool bubbles;
    public bool handled;
    public bool stopped;
    public bool cancelled;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void handle() => this.handled = true;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void stop() => this.stopped = true;

    [LineNumberTable(new byte[] {159, 164, 232, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public SceneEvent()
    {
      SceneEvent sceneEvent = this;
      this.bubbles = true;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void cancel()
    {
      this.cancelled = true;
      this.stopped = true;
      this.handled = true;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void reset()
    {
      this.targetActor = (Element) null;
      this.listenerActor = (Element) null;
      this.capture = false;
      this.bubbles = true;
      this.handled = false;
      this.stopped = false;
      this.cancelled = false;
    }
  }
}
