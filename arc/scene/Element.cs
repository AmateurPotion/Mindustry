// Decompiled with JetBrains decompiler
// Type: arc.scene.Element
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.func;
using arc.graphics;
using arc.graphics.g2d;
using arc.input;
using arc.math.geom;
using arc.scene.@event;
using arc.scene.actions;
using arc.scene.utils;
using arc.util.pooling;
using ikvm.@internal;
using IKVM.Attributes;
using java.lang;
using java.util;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.scene
{
  public class Element : Object
  {
    internal Color __\u003C\u003Ecolor;
    public float originX;
    public float originY;
    public float scaleX;
    public float scaleY;
    public float rotation;
    public string name;
    public bool fillParent;
    public Vec2 translation;
    public bool visible;
    public object userObject;
    public Touchable touchable;
    public Group parent;
    public Boolp visibility;
    [Signature("Larc/func/Prov<Larc/scene/event/Touchable;>;")]
    public Prov touchablility;
    public bool cullable;
    [Modifiers]
    [Signature("Larc/struct/DelayedRemovalSeq<Larc/scene/event/EventListener;>;")]
    private DelayedRemovalSeq listeners;
    [Modifiers]
    [Signature("Larc/struct/DelayedRemovalSeq<Larc/scene/event/EventListener;>;")]
    private DelayedRemovalSeq captureListeners;
    [Modifiers]
    [Signature("Larc/struct/Seq<Larc/scene/Action;>;")]
    private Seq actions;
    public float x;
    public float y;
    protected internal float width;
    protected internal float height;
    protected internal float parentAlpha;
    private Scene stage;
    private bool needsLayout;
    private bool layoutEnabled;
    private Runnable update;

    [LineNumberTable(new byte[] {162, 168, 137, 103, 107, 180, 105, 103, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void validate()
    {
      if (!this.layoutEnabled)
        return;
      Group parent = this.parent;
      if (this.fillParent && parent != null)
        this.setSize(parent.getWidth(), parent.getHeight());
      if (!this.needsLayout)
        return;
      this.needsLayout = false;
      this.layout();
    }

    [LineNumberTable(new byte[] {160, 236, 115, 130, 101, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isDescendantOf(Element actor)
    {
      if (actor == null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException("actor cannot be null.");
      }
      for (Element element = this; element != null; element = (Element) element.parent)
      {
        if (object.ReferenceEquals((object) element, (object) actor))
          return true;
      }
      return false;
    }

    [LineNumberTable(new byte[] {159, 105, 162, 152, 114, 143, 103, 135, 102, 112, 110, 106, 102, 104, 104, 115, 255, 4, 57, 233, 77, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool notify(SceneEvent @event, bool capture)
    {
      int num = capture ? 1 : 0;
      if (@event.targetActor == null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException("The event target cannot be null.");
      }
      DelayedRemovalSeq delayedRemovalSeq = num == 0 ? this.listeners : this.captureListeners;
      if (delayedRemovalSeq.size == 0)
        return @event.cancelled;
      @event.listenerActor = this;
      @event.capture = num != 0;
      delayedRemovalSeq.begin();
      int index = 0;
      for (int size = delayedRemovalSeq.size; index < size; ++index)
      {
        EventListener listener = (EventListener) delayedRemovalSeq.get(index);
        if (listener.handle(@event))
        {
          @event.handle();
          if (@event is InputEvent)
          {
            InputEvent inputEvent = (InputEvent) @event;
            if (object.ReferenceEquals((object) inputEvent.type, (object) InputEvent.InputEventType.__\u003C\u003EtouchDown))
              this.getScene().addTouchFocus(listener, this, inputEvent.targetActor, inputEvent.pointer, inputEvent.keyCode);
          }
        }
      }
      delayedRemovalSeq.end();
      return @event.cancelled;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Scene getScene() => this.stage;

    [LineNumberTable(new byte[] {160, 133, 115, 111, 108, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool addListener(EventListener listener)
    {
      if (listener == null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException("listener cannot be null.");
      }
      if (this.listeners.contains((object) listener, true))
        return false;
      this.listeners.add((object) listener);
      return true;
    }

    [LineNumberTable(new byte[] {160, 170, 103, 140, 127, 0})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addAction(Action action)
    {
      action.setActor(this);
      this.actions.add((object) action);
      if (this.stage == null || !this.stage.getActionsRequestRendering())
        return;
      Core.graphics.requestRendering();
    }

    [LineNumberTable(new byte[] {160, 195, 114, 55, 134, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void clearActions()
    {
      for (int index = this.actions.size - 1; index >= 0; index += -1)
        ((Action) this.actions.get(index)).setActor((Element) null);
      this.actions.clear();
    }

    [LineNumberTable(new byte[] {160, 202, 108, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void clearListeners()
    {
      this.listeners.clear();
      this.captureListeners.clear();
    }

    [LineNumberTable(new byte[] {161, 100, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void sizeChanged() => this.invalidate();

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void invalidate() => this.needsLayout = true;

    [LineNumberTable(new byte[] {161, 113, 116, 104, 104, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setSize(float width, float height)
    {
      if ((double) this.width == (double) width && (double) this.height == (double) height)
        return;
      this.width = width;
      this.height = height;
      this.sizeChanged();
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void rotationChanged()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setOrigin(int alignment)
    {
      this.originX = (alignment & 8) == 0 ? ((alignment & 16) == 0 ? this.width / 2f : this.width) : 0.0f;
      if ((alignment & 4) != 0)
        this.originY = 0.0f;
      else if ((alignment & 2) != 0)
        this.originY = this.height;
      else
        this.originY = this.height / 2f;
    }

    [LineNumberTable(new byte[] {162, 3, 116, 103, 100, 103, 106, 112, 112, 107, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setZIndex(int index)
    {
      if (index < 0)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException("ZIndex cannot be < 0.");
      }
      Group parent = this.parent;
      if (parent == null)
        return;
      SnapshotSeq children = parent.__\u003C\u003Echildren;
      if (children.size == 1)
        return;
      index = Math.min(index, children.size - 1);
      if (object.ReferenceEquals(children.get(index), (object) this) || !children.remove((object) this, true))
        return;
      children.insert(index, (object) this);
    }

    [LineNumberTable(new byte[] {162, 27, 117, 102, 104, 104, 104, 105, 103, 122, 104, 106, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool clipBegin(float x, float y, float width, float height)
    {
      if ((double) width <= 0.0 || (double) height <= 0.0)
        return false;
      Rect tmp = Rect.__\u003C\u003Etmp;
      tmp.x = x;
      tmp.y = y;
      tmp.width = width;
      tmp.height = height;
      Scene stage = this.stage;
      Rect rect = (Rect) Pools.obtain((Class) ClassLiteral<Rect>.Value, (Prov) new Element.__\u003C\u003EAnon1());
      stage.calculateScissors(tmp, rect);
      if (ScissorStack.push(rect))
        return true;
      Pools.free((object) rect);
      return false;
    }

    [LineNumberTable(new byte[] {162, 55, 117, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec2 stageToLocalCoordinates(Vec2 stageCoords)
    {
      if (this.parent != null)
        this.parent.stageToLocalCoordinates(stageCoords);
      this.parentToLocalCoordinates(stageCoords);
      return stageCoords;
    }

    [LineNumberTable(new byte[] {162, 110, 103, 103, 103, 116, 117, 107, 112, 111, 149, 104, 104, 122, 123, 133, 114, 114, 104, 104, 111, 112, 123, 156})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec2 parentToLocalCoordinates(Vec2 parentCoords)
    {
      float rotation = this.rotation;
      float scaleX = this.scaleX;
      float scaleY = this.scaleY;
      float num1 = this.x + this.translation.x;
      float num2 = this.y + this.translation.y;
      if ((double) rotation == 0.0)
      {
        if ((double) scaleX == 1.0 && (double) scaleY == 1.0)
        {
          parentCoords.x -= num1;
          parentCoords.y -= num2;
        }
        else
        {
          float originX = this.originX;
          float originY = this.originY;
          parentCoords.x = (parentCoords.x - num1 - originX) / scaleX + originX;
          parentCoords.y = (parentCoords.y - num2 - originY) / scaleY + originY;
        }
      }
      else
      {
        float num3 = (float) Math.cos((double) (rotation * ((float) Math.PI / 180f)));
        float num4 = (float) Math.sin((double) (rotation * ((float) Math.PI / 180f)));
        float originX = this.originX;
        float originY = this.originY;
        float num5 = parentCoords.x - num1 - originX;
        float num6 = parentCoords.y - num2 - originY;
        parentCoords.x = (num5 * num3 + num6 * num4) / scaleX + originX;
        parentCoords.y = (num5 * -num4 + num6 * num3) / scaleY + originY;
      }
      return parentCoords;
    }

    [LineNumberTable(new byte[] {162, 99, 98, 99, 104, 103, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec2 localToAscendantCoordinates(Element ascendant, Vec2 localCoords)
    {
      Element element = this;
      while (element != null)
      {
        element.localToParentCoordinates(localCoords);
        element = (Element) element.parent;
        if (object.ReferenceEquals((object) (Group) element, (object) ascendant))
          break;
      }
      return localCoords;
    }

    [LineNumberTable(new byte[] {162, 69, 104, 103, 103, 116, 117, 107, 112, 111, 149, 104, 104, 122, 123, 133, 114, 114, 104, 104, 111, 111, 123, 157})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec2 localToParentCoordinates(Vec2 localCoords)
    {
      float num1 = -this.rotation;
      float scaleX = this.scaleX;
      float scaleY = this.scaleY;
      float num2 = this.x + this.translation.x;
      float num3 = this.y + this.translation.y;
      if ((double) num1 == 0.0)
      {
        if ((double) scaleX == 1.0 && (double) scaleY == 1.0)
        {
          localCoords.x += num2;
          localCoords.y += num3;
        }
        else
        {
          float originX = this.originX;
          float originY = this.originY;
          localCoords.x = (localCoords.x - originX) * scaleX + originX + num2;
          localCoords.y = (localCoords.y - originY) * scaleY + originY + num3;
        }
      }
      else
      {
        float num4 = (float) Math.cos((double) (num1 * ((float) Math.PI / 180f)));
        float num5 = (float) Math.sin((double) (num1 * ((float) Math.PI / 180f)));
        float originX = this.originX;
        float originY = this.originY;
        float num6 = (localCoords.x - originX) * scaleX;
        float num7 = (localCoords.y - originY) * scaleY;
        localCoords.x = num6 * num4 + num7 * num5 + originX + num2;
        localCoords.y = num6 * -num5 + num7 * num4 + originY + num3;
      }
      return localCoords;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getPrefWidth() => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getPrefHeight() => 0.0f;

    [LineNumberTable(new byte[] {162, 190, 105, 102, 103, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void invalidateHierarchy()
    {
      if (!this.layoutEnabled)
        return;
      this.invalidate();
      this.parent?.invalidateHierarchy();
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getWidth() => this.width;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getHeight() => this.height;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void layout()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getX(int alignment)
    {
      float x = this.x;
      if ((alignment & 16) != 0)
        x += this.width;
      else if ((alignment & 8) == 0)
        x += this.width / 2f;
      return x;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getY(int alignment)
    {
      float y = this.y;
      if ((alignment & 2) != 0)
        y += this.height;
      else if ((alignment & 4) == 0)
        y += this.height / 2f;
      return y;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setPosition(float x, float y, int alignment)
    {
      if ((alignment & 16) != 0)
        x -= this.width;
      else if ((alignment & 8) == 0)
        x -= this.width / 2f;
      if ((alignment & 2) != 0)
        y -= this.height;
      else if ((alignment & 4) == 0)
        y -= this.height / 2f;
      if ((double) this.x == (double) x && (double) this.y == (double) y)
        return;
      this.x = x;
      this.y = y;
    }

    [Signature("(Larc/func/Cons<Larc/input/KeyCode;>;)V")]
    [LineNumberTable(new byte[] {162, 237, 238, 71})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void keyDown(Cons cons) => this.addListener((EventListener) new Element.\u0033(this, cons));

    [Signature("()Larc/struct/Seq<Larc/scene/event/EventListener;>;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Seq getListeners() => (Seq) this.listeners;

    [LineNumberTable(888)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual ClickListener clicked(KeyCode button, Runnable r) => this.clicked((Cons) new Element.__\u003C\u003EAnon3(button), r);

    [Signature("(Larc/func/Cons<Larc/scene/event/ClickListener;>;Ljava/lang/Runnable;)Larc/scene/event/ClickListener;")]
    [LineNumberTable(893)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual ClickListener clicked(Cons tweaker, Runnable r) => this.clicked(tweaker, (Cons) new Element.__\u003C\u003EAnon4(r));

    [Signature("(Larc/func/Cons<Larc/scene/event/ClickListener;>;Larc/func/Cons<Larc/scene/event/ClickListener;>;)Larc/scene/event/ClickListener;")]
    [LineNumberTable(new byte[] {163, 16, 98, 241, 70, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual ClickListener clicked(Cons tweaker, Cons runner)
    {
      Element element = this;
      Element.\u0034 obj;
      this.addListener((EventListener) (obj = new Element.\u0034(this, runner, element)));
      tweaker.get((object) obj);
      return (ClickListener) obj;
    }

    [LineNumberTable(new byte[] {59, 167, 122, 103, 99, 103, 233, 69, 103, 237, 87, 103, 102, 231, 40, 106, 106, 248, 84, 103, 102, 7, 103, 230, 43, 227, 61, 232, 87, 103, 102, 230, 46, 105, 245, 79, 103, 102, 5, 103, 230, 48, 162, 105, 245, 75, 103, 102, 5, 103, 230, 52, 98, 245, 74, 103, 102, 5, 103, 230, 53, 162, 238, 71, 103, 102, 232, 56, 112, 248, 69, 103, 102, 7, 103, 230, 58, 3, 232, 71, 103, 102, 230, 60, 139, 103, 102, 3, 2})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool fire(SceneEvent @event)
    {
      @event.targetActor = this;
      Seq seq = (Seq) Pools.obtain((Class) ClassLiteral<Seq>.Value, (Prov) new Element.__\u003C\u003EAnon0());
      for (Group parent = this.parent; parent != null; parent = parent.parent)
        seq.add((object) parent);
      object[] items;
      int index;
      // ISSUE: fault handler
      try
      {
        items = seq.items;
        index = seq.size - 1;
      }
      __fault
      {
        seq.clear();
        Pools.free((object) seq);
      }
      int num;
      while (true)
      {
        // ISSUE: fault handler
        try
        {
          if (index >= 0)
          {
            ((Element) items[index]).notify(@event, true);
            if (@event.stopped)
            {
              num = @event.cancelled ? 1 : 0;
              break;
            }
          }
          else
            goto label_12;
        }
        __fault
        {
          seq.clear();
          Pools.free((object) seq);
        }
        // ISSUE: fault handler
        try
        {
          index += -1;
        }
        __fault
        {
          seq.clear();
          Pools.free((object) seq);
        }
      }
      seq.clear();
      Pools.free((object) seq);
      return num != 0;
label_12:
      // ISSUE: fault handler
      try
      {
        this.notify(@event, true);
        if (@event.stopped)
          index = @event.cancelled ? 1 : 0;
        else
          goto label_16;
      }
      __fault
      {
        seq.clear();
        Pools.free((object) seq);
      }
      seq.clear();
      Pools.free((object) seq);
      return index != 0;
label_16:
      // ISSUE: fault handler
      try
      {
        this.notify(@event, false);
        if (!@event.bubbles)
          index = @event.cancelled ? 1 : 0;
        else
          goto label_20;
      }
      __fault
      {
        seq.clear();
        Pools.free((object) seq);
      }
      seq.clear();
      Pools.free((object) seq);
      return index != 0;
label_20:
      // ISSUE: fault handler
      try
      {
        if (@event.stopped)
          index = @event.cancelled ? 1 : 0;
        else
          goto label_24;
      }
      __fault
      {
        seq.clear();
        Pools.free((object) seq);
      }
      seq.clear();
      Pools.free((object) seq);
      return index != 0;
label_24:
      int size;
      // ISSUE: fault handler
      try
      {
        index = 0;
        size = seq.size;
      }
      __fault
      {
        seq.clear();
        Pools.free((object) seq);
      }
      while (true)
      {
        // ISSUE: fault handler
        try
        {
          if (index < size)
          {
            ((Element) items[index]).notify(@event, false);
            if (@event.stopped)
            {
              num = @event.cancelled ? 1 : 0;
              break;
            }
          }
          else
            goto label_33;
        }
        __fault
        {
          seq.clear();
          Pools.free((object) seq);
        }
        // ISSUE: fault handler
        try
        {
          ++index;
        }
        __fault
        {
          seq.clear();
          Pools.free((object) seq);
        }
      }
      seq.clear();
      Pools.free((object) seq);
      return num != 0;
label_33:
      try
      {
        return @event.cancelled;
      }
      finally
      {
        seq.clear();
        Pools.free((object) seq);
      }
    }

    [Modifiers]
    [LineNumberTable(new byte[] {162, 230, 105, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024keyDown\u00240([In] KeyCode obj0, [In] Runnable obj1, [In] KeyCode obj2)
    {
      if (!object.ReferenceEquals((object) obj2, (object) obj0))
        return;
      obj1.run();
    }

    [Modifiers]
    [LineNumberTable(888)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024clicked\u00241([In] KeyCode obj0, [In] ClickListener obj1) => obj1.setButton(obj0);

    [Modifiers]
    [LineNumberTable(893)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024clicked\u00242([In] Runnable obj0, [In] ClickListener obj1) => obj0.run();

    [LineNumberTable(new byte[] {159, 162, 104, 127, 0, 182, 117, 135, 203, 135, 120, 236, 71, 171, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Element()
    {
      Element element = this;
      this.__\u003C\u003Ecolor = new Color(1f, 1f, 1f, 1f);
      this.scaleX = 1f;
      this.scaleY = 1f;
      this.translation = new Vec2(0.0f, 0.0f);
      this.visible = true;
      this.touchable = Touchable.__\u003C\u003Eenabled;
      this.cullable = true;
      this.listeners = new DelayedRemovalSeq(0);
      this.captureListeners = new DelayedRemovalSeq(0);
      this.actions = new Seq(0);
      this.parentAlpha = 1f;
      this.needsLayout = true;
      this.layoutEnabled = true;
    }

    [LineNumberTable(new byte[] {1, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void draw() => this.validate();

    [LineNumberTable(new byte[] {11, 103, 108, 127, 0, 110, 109, 118, 109, 118, 101, 105, 103, 228, 56, 233, 78, 126, 115})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void act(float delta)
    {
      Seq actions = this.actions;
      if (actions.size > 0)
      {
        if (this.stage != null && this.stage.getActionsRequestRendering())
          Core.graphics.requestRendering();
        for (int index1 = 0; index1 < actions.size; ++index1)
        {
          Action action = (Action) actions.get(index1);
          if (action.act(delta) && index1 < actions.size)
          {
            int index2 = !object.ReferenceEquals((object) (Action) actions.get(index1), (object) action) ? actions.indexOf((object) action, true) : index1;
            if (index2 != -1)
            {
              actions.remove(index2);
              action.setActor((Element) null);
              index1 += -1;
            }
          }
        }
      }
      if (this.touchablility != null)
        this.touchable = (Touchable) this.touchablility.get();
      if (this.update == null)
        return;
      this.update.run();
    }

    [LineNumberTable(new byte[] {33, 121})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void updateVisibility()
    {
      if (this.visibility == null)
        return;
      this.visible = this.visibility.get();
    }

    [LineNumberTable(new byte[] {37, 127, 3})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool hasMouse()
    {
      Element element = Core.scene.hit((float) Core.input.mouseX(), (float) Core.input.mouseY(), true);
      return object.ReferenceEquals((object) element, (object) this) || element != null && element.isDescendantOf(this);
    }

    [LineNumberTable(92)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool hasKeyboard() => object.ReferenceEquals((object) Core.scene.getKeyboardFocus(), (object) this);

    [LineNumberTable(96)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool hasScroll() => object.ReferenceEquals((object) Core.scene.getScrollFocus(), (object) this);

    [LineNumberTable(new byte[] {50, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void requestKeyboard() => Core.scene.setKeyboardFocus(this);

    [LineNumberTable(new byte[] {54, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void requestScroll() => Core.scene.setScrollFocus(this);

    [LineNumberTable(new byte[] {159, 95, 162, 119, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Element hit(float x, float y, bool touchable)
    {
      if (touchable && !object.ReferenceEquals((object) this.touchable, (object) Touchable.__\u003C\u003Eenabled))
        return (Element) null;
      Element element = this;
      return (double) x >= (double) element.translation.x && (double) x < (double) (this.width + element.translation.x) && ((double) y >= (double) element.translation.y && (double) y < (double) (this.height + element.translation.y)) ? this : (Element) null;
    }

    [LineNumberTable(201)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool remove() => this.parent != null && this.parent.removeChild(this, true);

    [LineNumberTable(new byte[] {160, 94, 238, 85})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void dragged(Floatc2 cons) => this.addListener((EventListener) new Element.\u0031(this, cons));

    [LineNumberTable(new byte[] {160, 118, 238, 71})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void scrolled(Floatc cons) => this.addListener((EventListener) new Element.\u0032(this, cons));

    [LineNumberTable(new byte[] {160, 142, 115})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool removeListener(EventListener listener)
    {
      if (listener == null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException("listener cannot be null.");
      }
      return this.listeners.remove((object) listener, true);
    }

    [LineNumberTable(new byte[] {160, 155, 115, 123})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool addCaptureListener(EventListener listener)
    {
      if (listener == null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException("listener cannot be null.");
      }
      if (!this.captureListeners.contains((object) listener, true))
        this.captureListeners.add((object) listener);
      return true;
    }

    [LineNumberTable(new byte[] {160, 161, 115})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool removeCaptureListener(EventListener listener)
    {
      if (listener == null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException("listener cannot be null.");
      }
      return this.captureListeners.remove((object) listener, true);
    }

    [Signature("()Larc/struct/Seq<Larc/scene/event/EventListener;>;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Seq getCaptureListeners() => (Seq) this.captureListeners;

    [LineNumberTable(new byte[] {160, 177, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void actions(params Action[] actions) => this.addAction((Action) Actions.sequence(actions));

    [LineNumberTable(new byte[] {160, 181, 118})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void removeAction(Action action)
    {
      if (!this.actions.remove((object) action, true))
        return;
      action.setActor((Element) null);
    }

    [Signature("()Larc/struct/Seq<Larc/scene/Action;>;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Seq getActions() => this.actions;

    [LineNumberTable(304)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool hasActions() => this.actions.size > 0;

    [LineNumberTable(new byte[] {160, 208, 102, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void clear()
    {
      this.clearActions();
      this.clearListeners();
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void setScene(Scene stage) => this.stage = stage;

    [Signature("(Larc/func/Boolf<Larc/scene/Element;>;)Z")]
    [LineNumberTable(new byte[] {160, 226, 98, 99, 107, 137})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isDescendantOf(Boolf actor)
    {
      for (Element element = this; element != null; element = (Element) element.parent)
      {
        if (actor.get((object) element))
          return true;
      }
      return false;
    }

    [LineNumberTable(new byte[] {160, 247, 147, 101, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isAscendantOf(Element actor)
    {
      if (actor == null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException("actor cannot be null.");
      }
      for (; actor != null; actor = (Element) actor.parent)
      {
        if (object.ReferenceEquals((object) actor, (object) this))
          return true;
      }
      return false;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool hasParent() => this.parent != null;

    [LineNumberTable(376)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isTouchable() => object.ReferenceEquals((object) this.touchable, (object) Touchable.__\u003C\u003Eenabled);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setPosition(float x, float y)
    {
      if ((double) this.x == (double) x && (double) this.y == (double) y)
        return;
      this.x = x;
      this.y = y;
    }

    [LineNumberTable(new byte[] {161, 60, 114, 112, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void moveBy(float x, float y)
    {
      if ((double) x == 0.0 && (double) y == 0.0)
        return;
      this.x += x;
      this.y += y;
    }

    [LineNumberTable(new byte[] {161, 71, 106, 104, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setWidth(float width)
    {
      if ((double) this.width == (double) width)
        return;
      this.width = width;
      this.sizeChanged();
    }

    [LineNumberTable(new byte[] {161, 82, 106, 104, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setHeight(float height)
    {
      if ((double) this.height == (double) height)
        return;
      this.height = height;
      this.sizeChanged();
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getTop() => this.y + this.height;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getRight() => this.x + this.width;

    [LineNumberTable(new byte[] {161, 108, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setSize(float size) => this.setSize(size, size);

    [LineNumberTable(new byte[] {161, 122, 105, 112, 112, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void sizeBy(float size)
    {
      if ((double) size == 0.0)
        return;
      this.width += size;
      this.height += size;
      this.sizeChanged();
    }

    [LineNumberTable(new byte[] {161, 131, 114, 112, 112, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void sizeBy(float width, float height)
    {
      if ((double) width == 0.0 && (double) height == 0.0)
        return;
      this.width += width;
      this.height += height;
      this.sizeChanged();
    }

    [LineNumberTable(new byte[] {161, 140, 116, 104, 136, 117, 104, 105, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setBounds(float x, float y, float width, float height)
    {
      if ((double) this.x != (double) x || (double) this.y != (double) y)
      {
        this.x = x;
        this.y = y;
      }
      if ((double) this.width == (double) width && (double) this.height == (double) height)
        return;
      this.width = width;
      this.height = height;
      this.sizeChanged();
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setOrigin(float originX, float originY)
    {
      this.originX = originX;
      this.originY = originY;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setScale(float scaleXY)
    {
      this.scaleX = scaleXY;
      this.scaleY = scaleXY;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setScale(float scaleX, float scaleY)
    {
      this.scaleX = scaleX;
      this.scaleY = scaleY;
    }

    [LineNumberTable(new byte[] {161, 188, 112, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void scaleBy(float scale)
    {
      this.scaleX += scale;
      this.scaleY += scale;
    }

    [LineNumberTable(new byte[] {161, 194, 112, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void scaleBy(float scaleX, float scaleY)
    {
      this.scaleX += scaleX;
      this.scaleY += scaleY;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getRotation() => this.rotation;

    [LineNumberTable(new byte[] {161, 203, 106, 104, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setRotation(float degrees)
    {
      if ((double) this.rotation == (double) degrees)
        return;
      this.rotation = degrees;
      this.rotationChanged();
    }

    [LineNumberTable(new byte[] {161, 210, 103, 106, 104, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setRotationOrigin(float degrees, int align)
    {
      this.setOrigin(align);
      if ((double) this.rotation == (double) degrees)
        return;
      this.rotation = degrees;
      this.rotationChanged();
    }

    [LineNumberTable(new byte[] {161, 219, 105, 112, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void rotateBy(float amountInDegrees)
    {
      if ((double) amountInDegrees == 0.0)
        return;
      this.rotation += amountInDegrees;
      this.rotationChanged();
    }

    [LineNumberTable(new byte[] {161, 226, 117})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setColor(float r, float g, float b, float a) => this.__\u003C\u003Ecolor.set(r, g, b, a);

    [LineNumberTable(new byte[] {161, 230, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setColor(Color color) => this.__\u003C\u003Ecolor.set(color);

    [LineNumberTable(new byte[] {161, 235, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void toFront() => this.setZIndex(int.MaxValue);

    [LineNumberTable(new byte[] {161, 240, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void toBack() => this.setZIndex(0);

    [LineNumberTable(new byte[] {161, 248, 103, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getZIndex()
    {
      Group parent = this.parent;
      return parent == null ? -1 : parent.__\u003C\u003Echildren.indexOf((object) this, true);
    }

    [LineNumberTable(642)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool clipBegin() => this.clipBegin(this.x, this.y, this.width, this.height);

    [LineNumberTable(new byte[] {162, 43, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void clipEnd() => Pools.free((object) ScissorStack.pop());

    [LineNumberTable(new byte[] {162, 48, 103, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec2 screenToLocalCoordinates(Vec2 screenCoords)
    {
      Scene stage = this.stage;
      return stage == null ? screenCoords : this.stageToLocalCoordinates(stage.screenToStageCoordinates(screenCoords));
    }

    [LineNumberTable(690)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec2 localToStageCoordinates(Vec2 localCoords) => this.localToAscendantCoordinates((Element) null, localCoords);

    [LineNumberTable(765)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getMinWidth() => this.getPrefWidth();

    [LineNumberTable(769)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getMinHeight() => this.getPrefHeight();

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getMaxWidth() => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getMaxHeight() => 0.0f;

    [LineNumberTable(new byte[] {158, 201, 98, 103, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setLayoutEnabled(bool enabled)
    {
      int num = enabled ? 1 : 0;
      this.layoutEnabled = num != 0;
      if (num == 0)
        return;
      this.invalidateHierarchy();
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool needsLayout() => this.needsLayout;

    [LineNumberTable(new byte[] {162, 198, 116, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void pack()
    {
      this.setSize(this.getPrefWidth(), this.getPrefHeight());
      this.validate();
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setFillParent(bool fillParent) => this.fillParent = fillParent;

    [LineNumberTable(new byte[] {162, 209, 105, 108, 109, 109, 127, 1, 127, 7, 127, 1, 127, 5, 127, 0, 127, 5, 127, 1, 127, 5})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void keepInStage()
    {
      if (this.stage == null)
        return;
      Camera camera = this.stage.getCamera();
      float width = this.stage.getWidth();
      float height = this.stage.getHeight();
      if ((double) (this.getX(16) - camera.__\u003C\u003Eposition.x) > (double) (width / 2f))
        this.setPosition(camera.__\u003C\u003Eposition.x + width / 2f, this.getY(16), 16);
      if ((double) (this.getX(8) - camera.__\u003C\u003Eposition.x) < -(double) width / 2.0)
        this.setPosition(camera.__\u003C\u003Eposition.x - width / 2f, this.getY(8), 8);
      if ((double) (this.getY(2) - camera.__\u003C\u003Eposition.y) > (double) (height / 2f))
        this.setPosition(this.getX(2), camera.__\u003C\u003Eposition.y + height / 2f, 2);
      if ((double) (this.getY(4) - camera.__\u003C\u003Eposition.y) >= -(double) height / 2.0)
        return;
      this.setPosition(this.getX(4), camera.__\u003C\u003Eposition.y - height / 2f, 4);
    }

    [LineNumberTable(new byte[] {162, 224, 109, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setTranslation(float x, float y)
    {
      this.translation.x = x;
      this.translation.y = y;
    }

    [LineNumberTable(new byte[] {162, 229, 210})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void keyDown(KeyCode key, Runnable l) => this.keyDown((Cons) new Element.__\u003C\u003EAnon2(key, l));

    [LineNumberTable(new byte[] {162, 248, 127, 1, 104, 154, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void fireClick()
    {
      Iterator iterator = this.getListeners().iterator();
      while (iterator.hasNext())
      {
        EventListener eventListener = (EventListener) iterator.next();
        if (eventListener is ClickListener)
          ((ClickListener) eventListener).clicked(new InputEvent(), -1f, -1f);
      }
    }

    [LineNumberTable(883)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual ClickListener clicked(Runnable r) => this.clicked(KeyCode.__\u003C\u003EmouseLeft, r);

    [LineNumberTable(new byte[] {163, 29, 238, 72})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void tapped(Runnable r) => this.addListener((EventListener) new Element.\u0035(this, r));

    [LineNumberTable(new byte[] {163, 41, 238, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void hovered(Runnable r) => this.addListener((EventListener) new Element.\u0036(this, r));

    [LineNumberTable(new byte[] {163, 51, 238, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void exited(Runnable r) => this.addListener((EventListener) new Element.\u0037(this, r));

    [LineNumberTable(new byte[] {163, 61, 238, 72})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void released(Runnable r) => this.addListener((EventListener) new Element.\u0038(this, r));

    [LineNumberTable(new byte[] {163, 73, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void change() => this.fire((SceneEvent) new ChangeListener.ChangeEvent());

    [LineNumberTable(new byte[] {163, 78, 98, 239, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void changed(Runnable r) => this.addListener((EventListener) new Element.\u0039(this, this, r));

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Element update(Runnable r)
    {
      this.update = r;
      return this;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Element visible(Boolp vis)
    {
      this.visibility = vis;
      return this;
    }

    [Signature("(Larc/func/Prov<Larc/scene/event/Touchable;>;)V")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void touchable(Prov touch) => this.touchablility = touch;

    [LineNumberTable(new byte[] {163, 103, 103, 99, 115, 105, 142})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toString()
    {
      string str = this.name;
      if (str == null)
      {
        str = String.instancehelper_split(base.toString(), "@")[0];
        int num = String.instancehelper_lastIndexOf(str, 46);
        if (num != -1)
          str = String.instancehelper_substring(str, num + 1);
      }
      return str;
    }

    [Modifiers]
    public Color color
    {
      [HideFromJava] get => this.__\u003C\u003Ecolor;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Ecolor = value;
    }

    [EnclosingMethod(null, "dragged", "(Larc.func.Floatc2;)V")]
    [SpecialName]
    internal class \u0031 : InputListener
    {
      internal float lastX;
      internal float lastY;
      [Modifiers]
      internal Floatc2 val\u0024cons;
      [Modifiers]
      internal Element this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(208)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0031([In] Element obj0, [In] Floatc2 obj1)
      {
        this.this\u00240 = obj0;
        this.val\u0024cons = obj1;
        // ISSUE: explicit constructor call
        base.\u002Ector();
      }

      [LineNumberTable(new byte[] {160, 99, 145, 127, 0, 104, 104})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void touchDragged([In] InputEvent obj0, [In] float obj1, [In] float obj2, [In] int obj3)
      {
        if (Core.app.isMobile() && obj3 != 0)
          return;
        this.val\u0024cons.get(obj1 - this.lastX, obj2 - this.lastY);
        this.lastX = obj1;
        this.lastY = obj2;
      }

      [LineNumberTable(new byte[] {160, 108, 146, 104, 104})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override bool touchDown(
        [In] InputEvent obj0,
        [In] float obj1,
        [In] float obj2,
        [In] int obj3,
        [In] KeyCode obj4)
      {
        if (Core.app.isMobile() && obj3 != 0)
          return false;
        this.lastX = obj1;
        this.lastY = obj2;
        return true;
      }

      [HideFromJava]
      static \u0031() => InputListener.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "scrolled", "(Larc.func.Floatc;)V")]
    [SpecialName]
    internal class \u0032 : InputListener
    {
      [Modifiers]
      internal Floatc val\u0024cons;
      [Modifiers]
      internal Element this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(232)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0032([In] Element obj0, [In] Floatc obj1)
      {
        this.this\u00240 = obj0;
        this.val\u0024cons = obj1;
        // ISSUE: explicit constructor call
        base.\u002Ector();
      }

      [LineNumberTable(new byte[] {160, 121, 110})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override bool scrolled(
        [In] InputEvent obj0,
        [In] float obj1,
        [In] float obj2,
        [In] float obj3,
        [In] float obj4)
      {
        this.val\u0024cons.get(obj4);
        return true;
      }

      [HideFromJava]
      static \u0032() => InputListener.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "keyDown", "(Larc.func.Cons;)V")]
    [SpecialName]
    internal class \u0033 : InputListener
    {
      [Modifiers]
      internal Cons val\u0024cons;
      [Modifiers]
      internal Element this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(863)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0033([In] Element obj0, [In] Cons obj1)
      {
        this.this\u00240 = obj0;
        this.val\u0024cons = obj1;
        // ISSUE: explicit constructor call
        base.\u002Ector();
      }

      [LineNumberTable(new byte[] {162, 240, 108})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override bool keyDown([In] InputEvent obj0, [In] KeyCode obj1)
      {
        this.val\u0024cons.get((object) obj1);
        return true;
      }

      [HideFromJava]
      static \u0033() => InputListener.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "clicked", "(Larc.func.Cons;Larc.func.Cons;)Larc.scene.event.ClickListener;")]
    [SpecialName]
    internal class \u0034 : ClickListener
    {
      [Modifiers]
      internal Cons val\u0024runner;
      [Modifiers]
      internal Element val\u0024elem;
      [Modifiers]
      internal Element this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(899)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0034([In] Element obj0, [In] Cons obj1, [In] Element obj2)
      {
        this.this\u00240 = obj0;
        this.val\u0024runner = obj1;
        this.val\u0024elem = obj2;
        // ISSUE: explicit constructor call
        base.\u002Ector();
      }

      [LineNumberTable(new byte[] {163, 20, 127, 20})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void clicked([In] InputEvent obj0, [In] float obj1, [In] float obj2)
      {
        if (this.val\u0024runner == null || this.val\u0024elem is Disableable && ((Disableable) this.val\u0024elem).isDisabled())
          return;
        this.val\u0024runner.get((object) this);
      }

      [HideFromJava]
      static \u0034() => ClickListener.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "tapped", "(Ljava.lang.Runnable;)V")]
    [SpecialName]
    internal class \u0035 : InputListener
    {
      [Modifiers]
      internal Runnable val\u0024r;
      [Modifiers]
      internal Element this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(911)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0035([In] Element obj0, [In] Runnable obj1)
      {
        this.this\u00240 = obj0;
        this.val\u0024r = obj1;
        // ISSUE: explicit constructor call
        base.\u002Ector();
      }

      [LineNumberTable(new byte[] {163, 32, 107, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override bool touchDown(
        [In] InputEvent obj0,
        [In] float obj1,
        [In] float obj2,
        [In] int obj3,
        [In] KeyCode obj4)
      {
        this.val\u0024r.run();
        obj0.stop();
        return true;
      }

      [HideFromJava]
      static \u0035() => InputListener.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "hovered", "(Ljava.lang.Runnable;)V")]
    [SpecialName]
    internal class \u0036 : InputListener
    {
      [Modifiers]
      internal Runnable val\u0024r;
      [Modifiers]
      internal Element this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(923)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0036([In] Element obj0, [In] Runnable obj1)
      {
        this.this\u00240 = obj0;
        this.val\u0024r = obj1;
        // ISSUE: explicit constructor call
        base.\u002Ector();
      }

      [LineNumberTable(new byte[] {163, 44, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void enter([In] InputEvent obj0, [In] float obj1, [In] float obj2, [In] int obj3, [In] Element obj4) => this.val\u0024r.run();

      [HideFromJava]
      static \u0036() => InputListener.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "exited", "(Ljava.lang.Runnable;)V")]
    [SpecialName]
    internal class \u0037 : InputListener
    {
      [Modifiers]
      internal Runnable val\u0024r;
      [Modifiers]
      internal Element this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(933)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0037([In] Element obj0, [In] Runnable obj1)
      {
        this.this\u00240 = obj0;
        this.val\u0024r = obj1;
        // ISSUE: explicit constructor call
        base.\u002Ector();
      }

      [LineNumberTable(new byte[] {163, 54, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void exit([In] InputEvent obj0, [In] float obj1, [In] float obj2, [In] int obj3, [In] Element obj4) => this.val\u0024r.run();

      [HideFromJava]
      static \u0037() => InputListener.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "released", "(Ljava.lang.Runnable;)V")]
    [SpecialName]
    internal class \u0038 : InputListener
    {
      [Modifiers]
      internal Runnable val\u0024r;
      [Modifiers]
      internal Element this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(943)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0038([In] Element obj0, [In] Runnable obj1)
      {
        this.this\u00240 = obj0;
        this.val\u0024r = obj1;
        // ISSUE: explicit constructor call
        base.\u002Ector();
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      public override bool touchDown(
        [In] InputEvent obj0,
        [In] float obj1,
        [In] float obj2,
        [In] int obj3,
        [In] KeyCode obj4)
      {
        return true;
      }

      [LineNumberTable(new byte[] {163, 66, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void touchUp(
        [In] InputEvent obj0,
        [In] float obj1,
        [In] float obj2,
        [In] int obj3,
        [In] KeyCode obj4)
      {
        this.val\u0024r.run();
      }

      [HideFromJava]
      static \u0038() => InputListener.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "changed", "(Ljava.lang.Runnable;)V")]
    [SpecialName]
    internal class \u0039 : ChangeListener
    {
      [Modifiers]
      internal Element val\u0024elem;
      [Modifiers]
      internal Runnable val\u0024r;
      [Modifiers]
      internal Element this\u00240;

      [LineNumberTable(961)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0039([In] Element obj0, [In] Element obj1, [In] Runnable obj2)
      {
        this.this\u00240 = obj0;
        this.val\u0024elem = obj1;
        this.val\u0024r = obj2;
        // ISSUE: explicit constructor call
        base.\u002Ector();
      }

      [LineNumberTable(new byte[] {163, 82, 127, 11})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void changed([In] ChangeListener.ChangeEvent obj0, [In] Element obj1)
      {
        if (this.val\u0024elem is Disableable && ((Disableable) this.val\u0024elem).isDisabled())
          return;
        this.val\u0024r.run();
      }
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Prov
    {
      internal __\u003C\u003EAnon0()
      {
      }

      public object get() => (object) new Seq();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Prov
    {
      internal __\u003C\u003EAnon1()
      {
      }

      public object get() => (object) new Rect();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon2 : Cons
    {
      private readonly KeyCode arg\u00241;
      private readonly Runnable arg\u00242;

      internal __\u003C\u003EAnon2([In] KeyCode obj0, [In] Runnable obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] object obj0) => Element.lambda\u0024keyDown\u00240(this.arg\u00241, this.arg\u00242, (KeyCode) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon3 : Cons
    {
      private readonly KeyCode arg\u00241;

      internal __\u003C\u003EAnon3([In] KeyCode obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => Element.lambda\u0024clicked\u00241(this.arg\u00241, (ClickListener) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon4 : Cons
    {
      private readonly Runnable arg\u00241;

      internal __\u003C\u003EAnon4([In] Runnable obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => Element.lambda\u0024clicked\u00242(this.arg\u00241, (ClickListener) obj0);
    }
  }
}
