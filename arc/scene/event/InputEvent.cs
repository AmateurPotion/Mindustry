// Decompiled with JetBrains decompiler
// Type: arc.scene.event.InputEvent
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.input;
using arc.math.geom;
using arc.scene.@event;
using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.scene.@event
{
  public class InputEvent : SceneEvent
  {
    public InputEvent.InputEventType type;
    public float stageX;
    public float stageY;
    public int pointer;
    public float scrollAmountX;
    public float scrollAmountY;
    public KeyCode keyCode;
    public char character;
    public Element relatedActor;

    [LineNumberTable(12)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public InputEvent()
    {
    }

    [LineNumberTable(new byte[] {159, 174, 115, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec2 toCoordinates(Element actor, Vec2 actorCoords)
    {
      actorCoords.set(this.stageX, this.stageY);
      actor.stageToLocalCoordinates(actorCoords);
      return actorCoords;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isTouchFocusCancel() => (double) this.stageX == (double) int.MinValue || (double) this.stageY == (double) int.MinValue;

    [LineNumberTable(new byte[] {159, 165, 102, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void reset()
    {
      base.reset();
      this.relatedActor = (Element) null;
    }

    [LineNumberTable(44)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toString() => this.type.toString();

    [InnerClass]
    [Signature("Ljava/lang/Enum<Larc/scene/event/InputEvent$InputEventType;>;")]
    [Modifiers]
    [Serializable]
    public sealed class InputEventType : Enum
    {
      [Modifiers]
      internal static InputEvent.InputEventType __\u003C\u003EtouchDown;
      [Modifiers]
      internal static InputEvent.InputEventType __\u003C\u003EtouchUp;
      [Modifiers]
      internal static InputEvent.InputEventType __\u003C\u003EtouchDragged;
      [Modifiers]
      internal static InputEvent.InputEventType __\u003C\u003EmouseMoved;
      [Modifiers]
      internal static InputEvent.InputEventType __\u003C\u003Eenter;
      [Modifiers]
      internal static InputEvent.InputEventType __\u003C\u003Eexit;
      [Modifiers]
      internal static InputEvent.InputEventType __\u003C\u003Escrolled;
      [Modifiers]
      internal static InputEvent.InputEventType __\u003C\u003EkeyDown;
      [Modifiers]
      internal static InputEvent.InputEventType __\u003C\u003EkeyUp;
      [Modifiers]
      internal static InputEvent.InputEventType __\u003C\u003EkeyTyped;
      [Modifiers]
      private static InputEvent.InputEventType[] \u0024VALUES;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(48)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static InputEvent.InputEventType[] values() => (InputEvent.InputEventType[]) InputEvent.InputEventType.\u0024VALUES.Clone();

      [Signature("()V")]
      [LineNumberTable(48)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private InputEventType([In] string obj0, [In] int obj1)
        : base(obj0, obj1)
      {
        GC.KeepAlive((object) this);
      }

      [LineNumberTable(48)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static InputEvent.InputEventType valueOf(string name) => (InputEvent.InputEventType) Enum.valueOf((Class) ClassLiteral<InputEvent.InputEventType>.Value, name);

      [LineNumberTable(new byte[] {159, 130, 141, 144, 144, 144, 144, 144, 144, 144, 144, 144, 241, 44})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static InputEventType()
      {
        if (ByteCodeHelper.isAlreadyInited("arc.scene.event.InputEvent$InputEventType"))
          return;
        InputEvent.InputEventType.__\u003C\u003EtouchDown = new InputEvent.InputEventType(nameof (touchDown), 0);
        InputEvent.InputEventType.__\u003C\u003EtouchUp = new InputEvent.InputEventType(nameof (touchUp), 1);
        InputEvent.InputEventType.__\u003C\u003EtouchDragged = new InputEvent.InputEventType(nameof (touchDragged), 2);
        InputEvent.InputEventType.__\u003C\u003EmouseMoved = new InputEvent.InputEventType(nameof (mouseMoved), 3);
        InputEvent.InputEventType.__\u003C\u003Eenter = new InputEvent.InputEventType(nameof (enter), 4);
        InputEvent.InputEventType.__\u003C\u003Eexit = new InputEvent.InputEventType(nameof (exit), 5);
        InputEvent.InputEventType.__\u003C\u003Escrolled = new InputEvent.InputEventType(nameof (scrolled), 6);
        InputEvent.InputEventType.__\u003C\u003EkeyDown = new InputEvent.InputEventType(nameof (keyDown), 7);
        InputEvent.InputEventType.__\u003C\u003EkeyUp = new InputEvent.InputEventType(nameof (keyUp), 8);
        InputEvent.InputEventType.__\u003C\u003EkeyTyped = new InputEvent.InputEventType(nameof (keyTyped), 9);
        InputEvent.InputEventType.\u0024VALUES = new InputEvent.InputEventType[10]
        {
          InputEvent.InputEventType.__\u003C\u003EtouchDown,
          InputEvent.InputEventType.__\u003C\u003EtouchUp,
          InputEvent.InputEventType.__\u003C\u003EtouchDragged,
          InputEvent.InputEventType.__\u003C\u003EmouseMoved,
          InputEvent.InputEventType.__\u003C\u003Eenter,
          InputEvent.InputEventType.__\u003C\u003Eexit,
          InputEvent.InputEventType.__\u003C\u003Escrolled,
          InputEvent.InputEventType.__\u003C\u003EkeyDown,
          InputEvent.InputEventType.__\u003C\u003EkeyUp,
          InputEvent.InputEventType.__\u003C\u003EkeyTyped
        };
      }

      [Modifiers]
      public static InputEvent.InputEventType touchDown
      {
        [HideFromJava] get => InputEvent.InputEventType.__\u003C\u003EtouchDown;
      }

      [Modifiers]
      public static InputEvent.InputEventType touchUp
      {
        [HideFromJava] get => InputEvent.InputEventType.__\u003C\u003EtouchUp;
      }

      [Modifiers]
      public static InputEvent.InputEventType touchDragged
      {
        [HideFromJava] get => InputEvent.InputEventType.__\u003C\u003EtouchDragged;
      }

      [Modifiers]
      public static InputEvent.InputEventType mouseMoved
      {
        [HideFromJava] get => InputEvent.InputEventType.__\u003C\u003EmouseMoved;
      }

      [Modifiers]
      public static InputEvent.InputEventType enter
      {
        [HideFromJava] get => InputEvent.InputEventType.__\u003C\u003Eenter;
      }

      [Modifiers]
      public static InputEvent.InputEventType exit
      {
        [HideFromJava] get => InputEvent.InputEventType.__\u003C\u003Eexit;
      }

      [Modifiers]
      public static InputEvent.InputEventType scrolled
      {
        [HideFromJava] get => InputEvent.InputEventType.__\u003C\u003Escrolled;
      }

      [Modifiers]
      public static InputEvent.InputEventType keyDown
      {
        [HideFromJava] get => InputEvent.InputEventType.__\u003C\u003EkeyDown;
      }

      [Modifiers]
      public static InputEvent.InputEventType keyUp
      {
        [HideFromJava] get => InputEvent.InputEventType.__\u003C\u003EkeyUp;
      }

      [Modifiers]
      public static InputEvent.InputEventType keyTyped
      {
        [HideFromJava] get => InputEvent.InputEventType.__\u003C\u003EkeyTyped;
      }

      [HideFromJava]
      [Serializable]
      public enum __Enum
      {
        touchDown,
        touchUp,
        touchDragged,
        mouseMoved,
        enter,
        exit,
        scrolled,
        keyDown,
        keyUp,
        keyTyped,
      }
    }
  }
}
