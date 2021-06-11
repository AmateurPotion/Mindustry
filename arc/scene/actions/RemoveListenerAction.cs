// Decompiled with JetBrains decompiler
// Type: arc.scene.actions.RemoveListenerAction
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.scene.@event;
using IKVM.Attributes;
using System.Runtime.CompilerServices;

namespace arc.scene.actions
{
  public class RemoveListenerAction : Action
  {
    private EventListener listener;
    private bool capture;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setListener(EventListener listener) => this.listener = listener;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setCapture(bool capture) => this.capture = capture;

    [LineNumberTable(10)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public RemoveListenerAction()
    {
    }

    [LineNumberTable(new byte[] {159, 158, 104, 148, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool act(float delta)
    {
      if (this.capture)
        this.target.removeCaptureListener(this.listener);
      else
        this.target.removeListener(this.listener);
      return true;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual EventListener getListener() => this.listener;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool getCapture() => this.capture;

    [LineNumberTable(new byte[] {159, 183, 102, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void reset()
    {
      base.reset();
      this.listener = (EventListener) null;
    }
  }
}
