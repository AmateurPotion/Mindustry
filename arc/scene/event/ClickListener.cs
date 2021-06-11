// Decompiled with JetBrains decompiler
// Type: arc.scene.event.ClickListener
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.input;
using arc.scene.@event;
using arc.util;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System.Runtime.CompilerServices;

namespace arc.scene.@event
{
  public class ClickListener : InputListener
  {
    public static float visualPressedDuration;
    public static Runnable clicked;
    protected internal float tapSquareSize;
    protected internal float touchDownX;
    protected internal float touchDownY;
    protected internal int pressedPointer;
    protected internal KeyCode pressedButton;
    protected internal KeyCode button;
    protected internal bool pressed;
    protected internal bool over;
    protected internal bool overAny;
    protected internal bool cancelled;
    protected internal long visualPressedTime;
    protected internal long tapCountInterval;
    protected internal int tapCount;
    protected internal long lastTapTime;
    protected internal bool stop;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void clicked(InputEvent @event, float x, float y)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setButton(KeyCode button) => this.button = button;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getTapCount() => this.tapCount;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isPressed() => this.pressed;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void cancel()
    {
      if (this.pressedPointer == -1)
        return;
      this.cancelled = true;
      this.pressed = false;
    }

    [LineNumberTable(new byte[] {91, 106, 108, 111, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isVisualPressed()
    {
      if (this.pressed)
        return true;
      if (this.visualPressedTime <= 0L)
        return false;
      if (this.visualPressedTime > Time.millis())
        return true;
      this.visualPressedTime = 0L;
      return false;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isOver() => this.over || this.pressed;

    [LineNumberTable(new byte[] {61, 117, 127, 1})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isOver(Element element, float x, float y)
    {
      element.localToStageCoordinates(Tmp.__\u003C\u003Ev1.set(x, y));
      Element element1 = Core.scene.hit(Tmp.__\u003C\u003Ev1.x, Tmp.__\u003C\u003Ev1.y, true);
      return element1 != null && element1.isDescendantOf(element);
    }

    [LineNumberTable(new byte[] {159, 175, 232, 52, 127, 2, 135, 171, 172, 167})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ClickListener()
    {
      ClickListener clickListener = this;
      this.tapSquareSize = 14f;
      this.touchDownX = -1f;
      this.touchDownY = -1f;
      this.pressedPointer = -1;
      this.button = KeyCode.__\u003C\u003EmouseLeft;
      this.tapCountInterval = 400000000L;
      this.stop = false;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void invalidateTapSquare()
    {
      this.touchDownX = -1f;
      this.touchDownY = -1f;
    }

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u00240()
    {
    }

    [LineNumberTable(new byte[] {159, 177, 232, 50, 127, 2, 135, 171, 172, 231, 70, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ClickListener(KeyCode button)
    {
      ClickListener clickListener = this;
      this.tapSquareSize = 14f;
      this.touchDownX = -1f;
      this.touchDownY = -1f;
      this.pressedPointer = -1;
      this.button = KeyCode.__\u003C\u003EmouseLeft;
      this.tapCountInterval = 400000000L;
      this.stop = false;
      this.button = button;
    }

    [LineNumberTable(new byte[] {159, 183, 106, 125, 103, 104, 104, 104, 104, 125})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool touchDown(
      InputEvent @event,
      float x,
      float y,
      int pointer,
      KeyCode button)
    {
      if (this.pressed || pointer == 0 && this.button != null && !object.ReferenceEquals((object) button, (object) this.button))
        return false;
      this.pressed = true;
      this.pressedPointer = pointer;
      this.pressedButton = button;
      this.touchDownX = x;
      this.touchDownY = y;
      this.visualPressedTime = Time.millis() + ByteCodeHelper.f2l(ClickListener.visualPressedDuration * 1000f);
      return true;
    }

    [LineNumberTable(new byte[] {4, 115, 118, 127, 14, 136, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void touchDragged(InputEvent @event, float x, float y, int pointer)
    {
      if (pointer != this.pressedPointer || this.cancelled)
        return;
      this.pressed = this.isOver(@event.listenerActor, x, y);
      if (this.pressed && pointer == 0 && (this.button != null && !Core.input.keyDown(this.button)))
        this.pressed = false;
      if (this.pressed)
        return;
      this.invalidateTapSquare();
    }

    [LineNumberTable(new byte[] {15, 109, 107, 145, 127, 1, 99, 102, 119, 110, 135, 106, 171, 103, 103, 103, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void touchUp(
      InputEvent @event,
      float x,
      float y,
      int pointer,
      KeyCode button)
    {
      if (pointer != this.pressedPointer)
        return;
      if (!this.cancelled)
      {
        int num1 = this.isOver(@event.listenerActor, x, y) ? 1 : 0;
        if (num1 != 0 && pointer == 0 && (this.button != null && !object.ReferenceEquals((object) button, (object) this.button)))
          num1 = 0;
        if (num1 != 0)
        {
          long num2 = Time.nanos();
          if (num2 - this.lastTapTime > this.tapCountInterval)
            this.tapCount = 0;
          ++this.tapCount;
          this.lastTapTime = num2;
          ClickListener.clicked.run();
          this.clicked(@event, x, y);
        }
      }
      this.pressed = false;
      this.pressedPointer = -1;
      this.pressedButton = (KeyCode) null;
      this.cancelled = false;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void enter(
      InputEvent @event,
      float x,
      float y,
      int pointer,
      Element fromActor)
    {
      if (pointer == -1 && !this.cancelled)
        this.over = true;
      if (this.cancelled)
        return;
      this.overAny = true;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void exit(InputEvent @event, float x, float y, int pointer, Element toActor)
    {
      if (pointer == -1 && !this.cancelled)
        this.over = false;
      if (this.cancelled)
        return;
      this.overAny = false;
    }

    [LineNumberTable(117)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool inTapSquare(float x, float y) => ((double) this.touchDownX != -1.0 || (double) this.touchDownY != -1.0) && ((double) Math.abs(x - this.touchDownX) < (double) this.tapSquareSize && (double) Math.abs(y - this.touchDownY) < (double) this.tapSquareSize);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool inTapSquare() => (double) this.touchDownX != -1.0;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getTapSquareSize() => this.tapSquareSize;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setTapSquareSize(float halfTapSquareSize) => this.tapSquareSize = halfTapSquareSize;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setTapCountInterval(float tapCountInterval) => this.tapCountInterval = ByteCodeHelper.f2l(tapCountInterval * 1E+09f);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setTapCount(int tapCount) => this.tapCount = tapCount;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getTouchDownX() => this.touchDownX;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getTouchDownY() => this.touchDownY;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual KeyCode getPressedButton() => this.pressedButton;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getPressedPointer() => this.pressedPointer;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual KeyCode getButton() => this.button;

    [LineNumberTable(new byte[] {159, 138, 146, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static ClickListener()
    {
      InputListener.__\u003Cclinit\u003E();
      if (ByteCodeHelper.isAlreadyInited("arc.scene.event.ClickListener"))
        return;
      ClickListener.visualPressedDuration = 0.1f;
      ClickListener.clicked = (Runnable) new ClickListener.__\u003C\u003EAnon0();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Runnable
    {
      internal __\u003C\u003EAnon0()
      {
      }

      public void run() => ClickListener.lambda\u0024static\u00240();
    }
  }
}
