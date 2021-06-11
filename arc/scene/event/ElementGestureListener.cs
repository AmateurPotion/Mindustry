// Decompiled with JetBrains decompiler
// Type: arc.scene.event.ElementGestureListener
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
using System.Runtime.InteropServices;

namespace arc.scene.@event
{
  public class ElementGestureListener : Object, EventListener
  {
    [Modifiers]
    internal static Vec2 tmpCoords;
    [Modifiers]
    internal static Vec2 tmpCoords2;
    [Modifiers]
    private GestureDetector detector;
    internal InputEvent @event;
    internal Element actor;
    internal Element touchDownTarget;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 170, 104, 250, 120})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ElementGestureListener(
      float halfTapSquareSize,
      float tapCountInterval,
      float longPressDuration,
      float maxFlingDelay)
    {
      ElementGestureListener elementGestureListener = this;
      this.detector = new GestureDetector(halfTapSquareSize, tapCountInterval, longPressDuration, maxFlingDelay, (GestureDetector.GestureListener) new ElementGestureListener.\u0031(this));
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void touchDown(
      InputEvent @event,
      float x,
      float y,
      int pointer,
      KeyCode button)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void touchUp(InputEvent @event, float x, float y, int pointer, KeyCode button)
    {
    }

    [LineNumberTable(new byte[] {159, 166, 122})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ElementGestureListener()
      : this(20f, 0.4f, 1.1f, 0.15f)
    {
    }

    [LineNumberTable(new byte[] {39, 106, 135, 159, 10, 108, 108, 127, 5, 127, 3, 127, 8, 130, 106, 103, 108, 127, 5, 127, 3, 127, 8, 130, 103, 108, 126, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool handle(SceneEvent e)
    {
      if (!(e is InputEvent))
        return false;
      InputEvent @event = (InputEvent) e;
      switch (ElementGestureListener.\u0032.\u0024SwitchMap\u0024arc\u0024scene\u0024event\u0024InputEvent\u0024InputEventType[@event.type.ordinal()])
      {
        case 1:
          this.actor = @event.listenerActor;
          this.touchDownTarget = @event.targetActor;
          this.detector.touchDown(@event.stageX, @event.stageY, @event.pointer, @event.keyCode);
          this.actor.stageToLocalCoordinates(ElementGestureListener.tmpCoords.set(@event.stageX, @event.stageY));
          this.touchDown(@event, ElementGestureListener.tmpCoords.x, ElementGestureListener.tmpCoords.y, @event.pointer, @event.keyCode);
          return true;
        case 2:
          if (@event.isTouchFocusCancel())
            return false;
          this.@event = @event;
          this.actor = @event.listenerActor;
          this.detector.touchUp(@event.stageX, @event.stageY, @event.pointer, @event.keyCode);
          this.actor.stageToLocalCoordinates(ElementGestureListener.tmpCoords.set(@event.stageX, @event.stageY));
          this.touchUp(@event, ElementGestureListener.tmpCoords.x, ElementGestureListener.tmpCoords.y, @event.pointer, @event.keyCode);
          return true;
        case 3:
          this.@event = @event;
          this.actor = @event.listenerActor;
          this.detector.touchDragged(@event.stageX, @event.stageY, @event.pointer);
          return true;
        default:
          return false;
      }
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void tap(InputEvent @event, float x, float y, int count, KeyCode button)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool longPress(Element actor, float x, float y) => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void fling(InputEvent @event, float velocityX, float velocityY, KeyCode button)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void pan(InputEvent @event, float x, float y, float deltaX, float deltaY)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void zoom(InputEvent @event, float initialDistance, float distance)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void pinch(
      InputEvent @event,
      Vec2 initialPointer1,
      Vec2 initialPointer2,
      Vec2 pointer1,
      Vec2 pointer2)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual GestureDetector getGestureDetector() => this.detector;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Element getTouchDownTarget() => this.touchDownTarget;

    [LineNumberTable(16)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static ElementGestureListener()
    {
      if (ByteCodeHelper.isAlreadyInited("arc.scene.event.ElementGestureListener"))
        return;
      ElementGestureListener.tmpCoords = new Vec2();
      ElementGestureListener.tmpCoords2 = new Vec2();
    }

    [EnclosingMethod(null, "<init>", "(FFFF)V")]
    [SpecialName]
    internal class \u0031 : Object, GestureDetector.GestureListener
    {
      [Modifiers]
      private Vec2 initialPointer1;
      [Modifiers]
      private Vec2 initialPointer2;
      [Modifiers]
      private Vec2 pointer1;
      [Modifiers]
      private Vec2 pointer2;
      [Modifiers]
      internal ElementGestureListener this\u00240;

      [LineNumberTable(new byte[] {159, 171, 111, 118})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0031([In] ElementGestureListener obj0)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector();
        ElementGestureListener.\u0031 obj = this;
        this.initialPointer1 = new Vec2();
        this.initialPointer2 = new Vec2();
        this.pointer1 = new Vec2();
        this.pointer2 = new Vec2();
      }

      [LineNumberTable(new byte[] {31, 114, 127, 12})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void stageToLocalAmount([In] Vec2 obj0)
      {
        this.this\u00240.actor.stageToLocalCoordinates(obj0);
        obj0.sub(this.this\u00240.actor.stageToLocalCoordinates(ElementGestureListener.tmpCoords2.set(0.0f, 0.0f)));
      }

      [LineNumberTable(new byte[] {159, 177, 127, 0, 127, 14})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual bool tap([In] float obj0, [In] float obj1, [In] int obj2, [In] KeyCode obj3)
      {
        this.this\u00240.actor.stageToLocalCoordinates(ElementGestureListener.tmpCoords.set(obj0, obj1));
        this.this\u00240.tap(this.this\u00240.@event, ElementGestureListener.tmpCoords.x, ElementGestureListener.tmpCoords.y, obj2, obj3);
        return true;
      }

      [LineNumberTable(new byte[] {159, 184, 127, 0})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual bool longPress([In] float obj0, [In] float obj1)
      {
        this.this\u00240.actor.stageToLocalCoordinates(ElementGestureListener.tmpCoords.set(obj0, obj1));
        return this.this\u00240.longPress(this.this\u00240.actor, ElementGestureListener.tmpCoords.x, ElementGestureListener.tmpCoords.y);
      }

      [LineNumberTable(new byte[] {159, 190, 116, 127, 12})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual bool fling([In] float obj0, [In] float obj1, [In] KeyCode obj2)
      {
        this.stageToLocalAmount(ElementGestureListener.tmpCoords.set(obj0, obj1));
        this.this\u00240.fling(this.this\u00240.@event, ElementGestureListener.tmpCoords.x, ElementGestureListener.tmpCoords.y, obj2);
        return true;
      }

      [LineNumberTable(new byte[] {5, 117, 108, 108, 127, 0, 127, 16})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual bool pan([In] float obj0, [In] float obj1, [In] float obj2, [In] float obj3)
      {
        this.stageToLocalAmount(ElementGestureListener.tmpCoords.set(obj2, obj3));
        obj2 = ElementGestureListener.tmpCoords.x;
        obj3 = ElementGestureListener.tmpCoords.y;
        this.this\u00240.actor.stageToLocalCoordinates(ElementGestureListener.tmpCoords.set(obj0, obj1));
        this.this\u00240.pan(this.this\u00240.@event, ElementGestureListener.tmpCoords.x, ElementGestureListener.tmpCoords.y, obj2, obj3);
        return true;
      }

      [LineNumberTable(new byte[] {15, 122})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual bool zoom([In] float obj0, [In] float obj1)
      {
        this.this\u00240.zoom(this.this\u00240.@event, obj0, obj1);
        return true;
      }

      [LineNumberTable(new byte[] {22, 125, 125, 125, 126, 127, 15})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual bool pinch([In] Vec2 obj0, [In] Vec2 obj1, [In] Vec2 obj2, [In] Vec2 obj3)
      {
        this.this\u00240.actor.stageToLocalCoordinates(this.initialPointer1.set(obj0));
        this.this\u00240.actor.stageToLocalCoordinates(this.initialPointer2.set(obj1));
        this.this\u00240.actor.stageToLocalCoordinates(this.pointer1.set(obj2));
        this.this\u00240.actor.stageToLocalCoordinates(this.pointer2.set(obj3));
        this.this\u00240.pinch(this.this\u00240.@event, this.initialPointer1, this.initialPointer2, this.pointer1, this.pointer2);
        return true;
      }

      [HideFromJava]
      public virtual bool touchDown([In] float obj0, [In] float obj1, [In] int obj2, [In] KeyCode obj3) => GestureDetector.GestureListener.\u003Cdefault\u003EtouchDown((GestureDetector.GestureListener) this, obj0, obj1, obj2, obj3);

      [HideFromJava]
      public virtual bool panStop([In] float obj0, [In] float obj1, [In] int obj2, [In] KeyCode obj3) => GestureDetector.GestureListener.\u003Cdefault\u003EpanStop((GestureDetector.GestureListener) this, obj0, obj1, obj2, obj3);

      [HideFromJava]
      public virtual void pinchStop() => GestureDetector.GestureListener.\u003Cdefault\u003EpinchStop((GestureDetector.GestureListener) this);
    }

    [InnerClass]
    [EnclosingMethod(null, null, null)]
    [Modifiers]
    [SpecialName]
    internal class \u0032 : Object
    {
      [Modifiers]
      internal static int[] \u0024SwitchMap\u0024arc\u0024scene\u0024event\u0024InputEvent\u0024InputEventType;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(92)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static \u0032()
      {
        if (ByteCodeHelper.isAlreadyInited("arc.scene.event.ElementGestureListener$2"))
          return;
        ElementGestureListener.\u0032.\u0024SwitchMap\u0024arc\u0024scene\u0024event\u0024InputEvent\u0024InputEventType = new int[InputEvent.InputEventType.values().Length];
        try
        {
          ElementGestureListener.\u0032.\u0024SwitchMap\u0024arc\u0024scene\u0024event\u0024InputEvent\u0024InputEventType[InputEvent.InputEventType.__\u003C\u003EtouchDown.ordinal()] = 1;
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
          ElementGestureListener.\u0032.\u0024SwitchMap\u0024arc\u0024scene\u0024event\u0024InputEvent\u0024InputEventType[InputEvent.InputEventType.__\u003C\u003EtouchUp.ordinal()] = 2;
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
          ElementGestureListener.\u0032.\u0024SwitchMap\u0024arc\u0024scene\u0024event\u0024InputEvent\u0024InputEventType[InputEvent.InputEventType.__\u003C\u003EtouchDragged.ordinal()] = 3;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
      }

      \u0032() => throw null;
    }
  }
}
