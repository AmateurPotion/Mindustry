// Decompiled with JetBrains decompiler
// Type: arc.backend.sdl.SdlInput
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.input;
using arc.util;
using IKVM.Attributes;
using java.lang;
using java.util;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.backend.sdl
{
  public class SdlInput : Input
  {
    [Modifiers]
    private InputEventQueue queue;
    private int mouseX;
    private int mouseY;
    private int deltaX;
    private int deltaY;
    private int mousePressed;
    private byte[] strcpy;

    [LineNumberTable(new byte[] {159, 152, 104, 203})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public SdlInput()
    {
      SdlInput sdlInput = this;
      this.queue = new InputEventQueue();
      this.strcpy = new byte[32];
    }

    [LineNumberTable(new byte[] {159, 161, 100, 103, 103, 132, 135, 101, 99, 143, 237, 69, 102, 122, 123, 123, 159, 9, 108, 103, 100, 149, 107, 107, 107, 107, 110, 103, 99, 110, 110, 149, 116, 110, 179, 108, 100, 143, 110, 110, 103, 135, 105, 155, 152, 105, 100, 100, 114, 108, 98, 103, 104, 100, 98, 226, 60, 230, 71, 102, 46, 166, 116, 110, 53, 200})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void handleInput([In] int[] obj0)
    {
      switch (obj0[0])
      {
        case 2:
          int num1 = obj0[1];
          int num2 = Core.graphics.getHeight() - obj0[2];
          this.deltaX = num1 - this.mouseX;
          this.deltaY = num2 - this.mouseY;
          this.mouseX = num1;
          this.mouseY = num2;
          if (this.mousePressed > 0)
          {
            this.queue.touchDragged(this.mouseX, this.mouseY, 0);
            break;
          }
          this.queue.mouseMoved(this.mouseX, this.mouseY);
          break;
        case 3:
          int num3 = obj0[1] == 1 ? 1 : 0;
          int num4 = obj0[4];
          int screenX = obj0[2];
          int screenY = Core.graphics.getHeight() - obj0[3];
          KeyCode keyCode1;
          switch (num4)
          {
            case 1:
              keyCode1 = KeyCode.__\u003C\u003EmouseLeft;
              break;
            case 2:
              keyCode1 = KeyCode.__\u003C\u003EmouseMiddle;
              break;
            case 3:
              keyCode1 = KeyCode.__\u003C\u003EmouseRight;
              break;
            case 4:
              keyCode1 = KeyCode.__\u003C\u003EmouseBack;
              break;
            case 5:
              keyCode1 = KeyCode.__\u003C\u003EmouseForward;
              break;
            default:
              keyCode1 = (KeyCode) null;
              break;
          }
          KeyCode keyCode2 = keyCode1;
          if (keyCode2 == null)
            break;
          if (num3 != 0)
          {
            ++this.mousePressed;
            this.queue.keyDown(keyCode2);
            this.queue.touchDown(screenX, screenY, 0, keyCode2);
            break;
          }
          this.mousePressed = Math.max(0, this.mousePressed - 1);
          this.queue.keyUp(keyCode2);
          this.queue.touchUp(screenX, screenY, 0, keyCode2);
          break;
        case 4:
          this.queue.scrolled((float) -obj0[1], (float) -obj0[2]);
          break;
        case 5:
          int num5 = obj0[1] == 1 ? 1 : 0;
          KeyCode code = SdlScanmap.getCode(obj0[4]);
          if (obj0[3] == 0)
          {
            if (num5 != 0)
              this.queue.keyDown(code);
            else
              this.queue.keyUp(code);
          }
          if (num5 == 0)
            break;
          if (object.ReferenceEquals((object) code, (object) KeyCode.__\u003C\u003Ebackspace))
            this.queue.keyTyped('\b');
          if (object.ReferenceEquals((object) code, (object) KeyCode.__\u003C\u003Etab))
            this.queue.keyTyped('\t');
          if (object.ReferenceEquals((object) code, (object) KeyCode.__\u003C\u003Eenter))
            this.queue.keyTyped('\r');
          if (!object.ReferenceEquals((object) code, (object) KeyCode.__\u003C\u003EforwardDel) && !object.ReferenceEquals((object) code, (object) KeyCode.__\u003C\u003Edel))
            break;
          this.queue.keyTyped('\u007F');
          break;
        case 6:
          int num6 = 0;
          for (int index = 0; index < 32; ++index)
          {
            if ((ushort) obj0[index + 1] == (ushort) 0)
            {
              num6 = index;
              break;
            }
          }
          for (int index = 0; index < num6; ++index)
            this.strcpy[index] = (byte) obj0[index + 1];
          string str = String.newhelper(this.strcpy, 0, num6, Strings.__\u003C\u003Eutf8);
          for (int index = 0; index < String.instancehelper_length(str); ++index)
            this.queue.keyTyped(String.instancehelper_charAt(str, index));
          break;
      }
    }

    [LineNumberTable(new byte[] {51, 113, 139, 127, 1, 102, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void update()
    {
      this.queue.setProcessor((InputProcessor) this.inputMultiplexer);
      this.queue.drain();
      Iterator iterator = this.devices.iterator();
      while (iterator.hasNext())
        ((InputDevice) iterator.next()).preUpdate();
    }

    [LineNumberTable(new byte[] {61, 127, 1, 102, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void postUpdate()
    {
      Iterator iterator = this.devices.iterator();
      while (iterator.hasNext())
        ((InputDevice) iterator.next()).postUpdate();
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override int mouseX() => this.mouseX;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override int mouseX(int pointer) => pointer == 0 ? this.mouseX : 0;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override int deltaX() => this.deltaX;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override int deltaX(int pointer) => pointer == 0 ? this.deltaX : 0;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override int mouseY() => this.mouseY;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override int mouseY(int pointer) => pointer == 0 ? this.mouseY : 0;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override int deltaY() => this.deltaY;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override int deltaY(int pointer) => pointer == 0 ? this.deltaY : 0;

    [LineNumberTable(158)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool isTouched() => this.keyDown(KeyCode.__\u003C\u003EmouseLeft) || this.keyDown(KeyCode.__\u003C\u003EmouseRight);

    [LineNumberTable(163)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool justTouched() => this.keyTap(KeyCode.__\u003C\u003EmouseLeft) || this.keyTap(KeyCode.__\u003C\u003EmouseRight);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool isTouched(int pointer) => false;

    [LineNumberTable(173)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override long getCurrentEventTime() => this.queue.getCurrentEventTime();
  }
}
