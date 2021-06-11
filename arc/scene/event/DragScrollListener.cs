// Decompiled with JetBrains decompiler
// Type: arc.scene.event.DragScrollListener
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.math;
using arc.scene.@event;
using arc.scene.ui;
using arc.util;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.scene.@event
{
  public class DragScrollListener : DragListener
  {
    internal Interp interpolation;
    internal float minSpeed;
    internal float maxSpeed;
    internal float tickSecs;
    internal long startTime;
    internal long rampTime;
    private ScrollPane scroll;
    private Timer.Task scrollUp;
    private Timer.Task scrollDown;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(44)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual float getScrollPixels() => this.interpolation.apply(this.minSpeed, this.maxSpeed, Math.min(1f, (float) (java.lang.System.currentTimeMillis() - this.startTime) / (float) this.rampTime));

    [LineNumberTable(new byte[] {159, 161, 232, 58, 107, 127, 2, 236, 69, 135, 237, 70, 237, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public DragScrollListener(ScrollPane scroll)
    {
      DragScrollListener dragScrollListener = this;
      this.interpolation = (Interp) Interp.exp5In;
      this.minSpeed = 15f;
      this.maxSpeed = 75f;
      this.tickSecs = 0.05f;
      this.rampTime = 1750L;
      this.scroll = scroll;
      this.scrollUp = (Timer.Task) new DragScrollListener.\u0031(this, scroll);
      this.scrollDown = (Timer.Task) new DragScrollListener.\u0032(this, scroll);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setup(
      float minSpeedPixels,
      float maxSpeedPixels,
      float tickSecs,
      float rampSecs)
    {
      this.minSpeed = minSpeedPixels;
      this.maxSpeed = maxSpeedPixels;
      this.tickSecs = tickSecs;
      this.rampTime = ByteCodeHelper.f2l(rampSecs * 1000f);
    }

    [LineNumberTable(new byte[] {159, 191, 127, 0, 112, 107, 109, 107, 152, 97, 105, 107, 109, 107, 152, 161, 107, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void drag(InputEvent @event, float x, float y, int pointer)
    {
      if ((double) x >= 0.0 && (double) x < (double) this.scroll.getWidth())
      {
        if ((double) y >= (double) this.scroll.getHeight())
        {
          this.scrollDown.cancel();
          if (this.scrollUp.isScheduled())
            return;
          this.startTime = java.lang.System.currentTimeMillis();
          Timer.schedule(this.scrollUp, this.tickSecs, this.tickSecs);
          return;
        }
        if ((double) y < 0.0)
        {
          this.scrollUp.cancel();
          if (this.scrollDown.isScheduled())
            return;
          this.startTime = java.lang.System.currentTimeMillis();
          Timer.schedule(this.scrollDown, this.tickSecs, this.tickSecs);
          return;
        }
      }
      this.scrollUp.cancel();
      this.scrollDown.cancel();
    }

    [LineNumberTable(new byte[] {22, 107, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void dragStop(InputEvent @event, float x, float y, int pointer)
    {
      this.scrollUp.cancel();
      this.scrollDown.cancel();
    }

    [HideFromJava]
    static DragScrollListener() => DragListener.__\u003Cclinit\u003E();

    [EnclosingMethod(null, "<init>", "(Larc.scene.ui.ScrollPane;)V")]
    [SpecialName]
    internal new class \u0031 : Timer.Task
    {
      [Modifiers]
      internal ScrollPane val\u0024scroll;
      [Modifiers]
      internal DragScrollListener this\u00240;

      [LineNumberTable(22)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0031([In] DragScrollListener obj0, [In] ScrollPane obj1)
      {
        this.this\u00240 = obj0;
        this.val\u0024scroll = obj1;
        // ISSUE: explicit constructor call
        base.\u002Ector();
      }

      [LineNumberTable(new byte[] {159, 167, 127, 6})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void run() => this.val\u0024scroll.setScrollY(this.val\u0024scroll.getScrollY() - this.this\u00240.getScrollPixels());
    }

    [EnclosingMethod(null, "<init>", "(Larc.scene.ui.ScrollPane;)V")]
    [SpecialName]
    internal class \u0032 : Timer.Task
    {
      [Modifiers]
      internal ScrollPane val\u0024scroll;
      [Modifiers]
      internal DragScrollListener this\u00240;

      [LineNumberTable(28)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0032([In] DragScrollListener obj0, [In] ScrollPane obj1)
      {
        this.this\u00240 = obj0;
        this.val\u0024scroll = obj1;
        // ISSUE: explicit constructor call
        base.\u002Ector();
      }

      [LineNumberTable(new byte[] {159, 173, 127, 6})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void run() => this.val\u0024scroll.setScrollY(this.val\u0024scroll.getScrollY() + this.this\u00240.getScrollPixels());
    }
  }
}
