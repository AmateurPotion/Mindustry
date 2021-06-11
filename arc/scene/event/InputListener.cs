// Decompiled with JetBrains decompiler
// Type: arc.scene.event.InputListener
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.input;
using arc.math.geom;
using arc.scene.@event;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System;
using System.Runtime.CompilerServices;

namespace arc.scene.@event
{
  public class InputListener : Object, EventListener
  {
    [Modifiers]
    private static Vec2 tmpCoords;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool keyDown(InputEvent @event, KeyCode keycode) => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool keyUp(InputEvent @event, KeyCode keycode) => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool keyTyped(InputEvent @event, char character) => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool touchDown(
      InputEvent @event,
      float x,
      float y,
      int pointer,
      KeyCode button)
    {
      return false;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void touchUp(InputEvent @event, float x, float y, int pointer, KeyCode button)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void touchDragged(InputEvent @event, float x, float y, int pointer)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool mouseMoved(InputEvent @event, float x, float y) => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool scrolled(
      InputEvent @event,
      float x,
      float y,
      float amountX,
      float amountY)
    {
      return false;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void enter(
      InputEvent @event,
      float x,
      float y,
      int pointer,
      Element fromActor)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void exit(InputEvent @event, float x, float y, int pointer, Element toActor)
    {
    }

    [LineNumberTable(11)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public InputListener()
    {
    }

    [LineNumberTable(new byte[] {159, 158, 106, 135, 127, 7, 110, 110, 174, 146, 159, 26, 159, 9, 127, 8, 130, 127, 2, 130, 156, 159, 9, 127, 8, 130, 127, 8, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool handle(SceneEvent e)
    {
      if (!(e is InputEvent))
        return false;
      InputEvent @event = (InputEvent) e;
      switch (InputListener.\u0031.\u0024SwitchMap\u0024arc\u0024scene\u0024event\u0024InputEvent\u0024InputEventType[@event.type.ordinal()])
      {
        case 1:
          return this.keyDown(@event, @event.keyCode);
        case 2:
          return this.keyUp(@event, @event.keyCode);
        case 3:
          return this.keyTyped(@event, @event.character);
        default:
          @event.toCoordinates(@event.listenerActor, InputListener.tmpCoords);
          switch (InputListener.\u0031.\u0024SwitchMap\u0024arc\u0024scene\u0024event\u0024InputEvent\u0024InputEventType[@event.type.ordinal()])
          {
            case 4:
              return this.touchDown(@event, InputListener.tmpCoords.x, InputListener.tmpCoords.y, @event.pointer, @event.keyCode);
            case 5:
              this.touchUp(@event, InputListener.tmpCoords.x, InputListener.tmpCoords.y, @event.pointer, @event.keyCode);
              return true;
            case 6:
              this.touchDragged(@event, InputListener.tmpCoords.x, InputListener.tmpCoords.y, @event.pointer);
              return true;
            case 7:
              return this.mouseMoved(@event, InputListener.tmpCoords.x, InputListener.tmpCoords.y);
            case 8:
              return this.scrolled(@event, InputListener.tmpCoords.x, InputListener.tmpCoords.y, @event.scrollAmountX, @event.scrollAmountY);
            case 9:
              this.enter(@event, InputListener.tmpCoords.x, InputListener.tmpCoords.y, @event.pointer, @event.relatedActor);
              return false;
            case 10:
              this.exit(@event, InputListener.tmpCoords.x, InputListener.tmpCoords.y, @event.pointer, @event.relatedActor);
              return false;
            default:
              return false;
          }
      }
    }

    [LineNumberTable(12)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static InputListener()
    {
      if (ByteCodeHelper.isAlreadyInited("arc.scene.event.InputListener"))
        return;
      InputListener.tmpCoords = new Vec2();
    }

    [InnerClass]
    [EnclosingMethod(null, null, null)]
    [Modifiers]
    [SpecialName]
    internal class \u0031 : Object
    {
      [Modifiers]
      internal static int[] \u0024SwitchMap\u0024arc\u0024scene\u0024event\u0024InputEvent\u0024InputEventType;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(19)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static \u0031()
      {
        if (ByteCodeHelper.isAlreadyInited("arc.scene.event.InputListener$1"))
          return;
        InputListener.\u0031.\u0024SwitchMap\u0024arc\u0024scene\u0024event\u0024InputEvent\u0024InputEventType = new int[InputEvent.InputEventType.values().Length];
        try
        {
          InputListener.\u0031.\u0024SwitchMap\u0024arc\u0024scene\u0024event\u0024InputEvent\u0024InputEventType[InputEvent.InputEventType.__\u003C\u003EkeyDown.ordinal()] = 1;
          goto label_6;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_6:
        try
        {
          InputListener.\u0031.\u0024SwitchMap\u0024arc\u0024scene\u0024event\u0024InputEvent\u0024InputEventType[InputEvent.InputEventType.__\u003C\u003EkeyUp.ordinal()] = 2;
          goto label_10;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_10:
        try
        {
          InputListener.\u0031.\u0024SwitchMap\u0024arc\u0024scene\u0024event\u0024InputEvent\u0024InputEventType[InputEvent.InputEventType.__\u003C\u003EkeyTyped.ordinal()] = 3;
          goto label_14;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_14:
        try
        {
          InputListener.\u0031.\u0024SwitchMap\u0024arc\u0024scene\u0024event\u0024InputEvent\u0024InputEventType[InputEvent.InputEventType.__\u003C\u003EtouchDown.ordinal()] = 4;
          goto label_18;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_18:
        try
        {
          InputListener.\u0031.\u0024SwitchMap\u0024arc\u0024scene\u0024event\u0024InputEvent\u0024InputEventType[InputEvent.InputEventType.__\u003C\u003EtouchUp.ordinal()] = 5;
          goto label_22;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_22:
        try
        {
          InputListener.\u0031.\u0024SwitchMap\u0024arc\u0024scene\u0024event\u0024InputEvent\u0024InputEventType[InputEvent.InputEventType.__\u003C\u003EtouchDragged.ordinal()] = 6;
          goto label_26;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_26:
        try
        {
          InputListener.\u0031.\u0024SwitchMap\u0024arc\u0024scene\u0024event\u0024InputEvent\u0024InputEventType[InputEvent.InputEventType.__\u003C\u003EmouseMoved.ordinal()] = 7;
          goto label_30;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_30:
        try
        {
          InputListener.\u0031.\u0024SwitchMap\u0024arc\u0024scene\u0024event\u0024InputEvent\u0024InputEventType[InputEvent.InputEventType.__\u003C\u003Escrolled.ordinal()] = 8;
          goto label_34;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_34:
        try
        {
          InputListener.\u0031.\u0024SwitchMap\u0024arc\u0024scene\u0024event\u0024InputEvent\u0024InputEventType[InputEvent.InputEventType.__\u003C\u003Eenter.ordinal()] = 9;
          goto label_38;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_38:
        try
        {
          InputListener.\u0031.\u0024SwitchMap\u0024arc\u0024scene\u0024event\u0024InputEvent\u0024InputEventType[InputEvent.InputEventType.__\u003C\u003Eexit.ordinal()] = 10;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
      }

      \u0031() => throw null;
    }
  }
}
