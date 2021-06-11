// Decompiled with JetBrains decompiler
// Type: arc.input.KeyboardDevice
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using IKVM.Attributes;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.input
{
  [Implements(new string[] {"arc.input.InputProcessor"})]
  public class KeyboardDevice : InputDevice, InputProcessor
  {
    [Modifiers]
    private IntSet pressed;
    [Modifiers]
    private IntSet lastFramePressed;
    [Modifiers]
    private IntFloatMap axes;

    [LineNumberTable(new byte[] {159, 148, 104, 107, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public KeyboardDevice()
    {
      KeyboardDevice keyboardDevice = this;
      this.pressed = new IntSet();
      this.lastFramePressed = new IntSet();
      this.axes = new IntFloatMap();
    }

    [LineNumberTable(new byte[] {159, 162, 156})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool isPressed(KeyCode key) => object.ReferenceEquals((object) key, (object) KeyCode.__\u003C\u003EanyKey) ? this.pressed.size > 0 : this.pressed.contains(key.ordinal());

    [LineNumberTable(27)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool isTapped(KeyCode key) => this.isPressed(key) && !this.lastFramePressed.contains(key.ordinal());

    [LineNumberTable(32)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool isReleased(KeyCode key) => !this.isPressed(key) && this.lastFramePressed.contains(key.ordinal());

    [LineNumberTable(37)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override float getAxis(KeyCode keyCode) => this.axes.get(keyCode.ordinal(), 0.0f);

    [LineNumberTable(new byte[] {159, 184, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool keyDown(KeyCode key)
    {
      this.pressed.add(key.ordinal());
      return false;
    }

    [LineNumberTable(new byte[] {159, 190, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool keyUp(KeyCode key)
    {
      this.pressed.remove(key.ordinal());
      return false;
    }

    [LineNumberTable(new byte[] {159, 155, 107, 113, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void postUpdate()
    {
      this.lastFramePressed.clear();
      this.lastFramePressed.addAll(this.pressed);
      this.axes.clear();
    }

    [LineNumberTable(new byte[] {4, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool touchDown(int screenX, int screenY, int pointer, KeyCode button)
    {
      this.keyDown(button);
      return false;
    }

    [LineNumberTable(new byte[] {10, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool touchUp(int screenX, int screenY, int pointer, KeyCode button)
    {
      if (pointer == 0)
        this.keyUp(button);
      return false;
    }

    [LineNumberTable(new byte[] {16, 120})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool scrolled(float amountX, float amountY)
    {
      this.axes.put(KeyCode.__\u003C\u003Escroll.ordinal(), -amountY);
      return false;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string name() => "Keyboard";

    [LineNumberTable(77)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override InputDevice.DeviceType type() => InputDevice.DeviceType.__\u003C\u003Ekeyboard;

    [HideFromJava]
    public virtual void connected([In] InputDevice obj0) => InputProcessor.\u003Cdefault\u003Econnected((InputProcessor) this, obj0);

    [HideFromJava]
    public virtual void disconnected([In] InputDevice obj0) => InputProcessor.\u003Cdefault\u003Edisconnected((InputProcessor) this, obj0);

    [HideFromJava]
    public virtual bool keyTyped([In] char obj0) => InputProcessor.\u003Cdefault\u003EkeyTyped((InputProcessor) this, obj0);

    [HideFromJava]
    public virtual bool touchDragged([In] int obj0, [In] int obj1, [In] int obj2) => InputProcessor.\u003Cdefault\u003EtouchDragged((InputProcessor) this, obj0, obj1, obj2);

    [HideFromJava]
    public virtual bool mouseMoved([In] int obj0, [In] int obj1) => InputProcessor.\u003Cdefault\u003EmouseMoved((InputProcessor) this, obj0, obj1);
  }
}
