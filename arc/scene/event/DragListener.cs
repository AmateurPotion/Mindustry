// Decompiled with JetBrains decompiler
// Type: arc.scene.event.DragListener
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.scene.@event;
using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;

namespace arc.scene.@event
{
  public class DragListener : InputListener
  {
    private float tapSquareSize;
    private float touchDownX;
    private float touchDownY;
    private float stageTouchDownX;
    private float stageTouchDownY;
    private int pressedPointer;
    private int button;
    private bool dragging;
    private float deltaX;
    private float deltaY;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void dragStart(InputEvent @event, float x, float y, int pointer)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void drag(InputEvent @event, float x, float y, int pointer)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void dragStop(InputEvent @event, float x, float y, int pointer)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void cancel()
    {
      this.dragging = false;
      this.pressedPointer = -1;
    }

    [LineNumberTable(new byte[] {159, 151, 104, 127, 24})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public DragListener()
    {
      DragListener dragListener = this;
      this.tapSquareSize = 14f;
      this.touchDownX = -1f;
      this.touchDownY = -1f;
      this.stageTouchDownX = -1f;
      this.stageTouchDownY = -1f;
      this.pressedPointer = -1;
    }

    [LineNumberTable(new byte[] {159, 159, 107, 121, 104, 104, 104, 108, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool touchDown(InputEvent @event, float x, float y, int pointer, int button)
    {
      if (this.pressedPointer != -1 || pointer == 0 && this.button != -1 && button != this.button)
        return false;
      this.pressedPointer = pointer;
      this.touchDownX = x;
      this.touchDownY = y;
      this.stageTouchDownX = @event.stageX;
      this.stageTouchDownY = @event.stageY;
      return true;
    }

    [LineNumberTable(new byte[] {159, 171, 107, 127, 25, 103, 109, 104, 136, 104, 112, 112, 109, 104, 136})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void touchDragged(InputEvent @event, float x, float y, int pointer)
    {
      if (pointer != this.pressedPointer)
        return;
      if (!this.dragging && ((double) Math.abs(this.touchDownX - x) > (double) this.tapSquareSize || (double) Math.abs(this.touchDownY - y) > (double) this.tapSquareSize))
      {
        this.dragging = true;
        this.dragStart(@event, x, y, pointer);
        this.deltaX = x;
        this.deltaY = y;
      }
      if (!this.dragging)
        return;
      this.deltaX -= x;
      this.deltaY -= y;
      this.drag(@event, x, y, pointer);
      this.deltaX = x;
      this.deltaY = y;
    }

    [LineNumberTable(new byte[] {159, 188, 106, 117, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void touchUp(InputEvent @event, float x, float y, int pointer, int button)
    {
      if (pointer != this.pressedPointer)
        return;
      if (this.dragging)
        this.dragStop(@event, x, y, pointer);
      this.cancel();
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isDragging() => this.dragging;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getTapSquareSize() => this.tapSquareSize;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setTapSquareSize(float halfTapSquareSize) => this.tapSquareSize = halfTapSquareSize;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getTouchDownX() => this.touchDownX;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getTouchDownY() => this.touchDownY;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getStageTouchDownX() => this.stageTouchDownX;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getStageTouchDownY() => this.stageTouchDownY;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getDeltaX() => this.deltaX;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getDeltaY() => this.deltaY;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getButton() => this.button;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setButton(int button) => this.button = button;

    [HideFromJava]
    static DragListener() => InputListener.__\u003Cclinit\u003E();
  }
}
