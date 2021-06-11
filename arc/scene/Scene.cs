// Decompiled with JetBrains decompiler
// Type: arc.scene.Scene
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.func;
using arc.graphics;
using arc.graphics.g2d;
using arc.input;
using arc.math;
using arc.math.geom;
using arc.scene.@event;
using arc.scene.style;
using arc.scene.ui;
using arc.scene.ui.layout;
using arc.util;
using arc.util.pooling;
using arc.util.viewport;
using ikvm.@internal;
using IKVM.Attributes;
using java.lang;
using java.lang.reflect;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.scene
{
  public class Scene : Object, InputProcessor
  {
    internal Group __\u003C\u003Eroot;
    public float marginLeft;
    public float marginRight;
    public float marginTop;
    public float marginBottom;
    [Modifiers]
    [Signature("Larc/struct/ObjectMap<Ljava/lang/Class;Ljava/lang/Object;>;")]
    private ObjectMap styleDefaults;
    [Modifiers]
    private Vec2 tempCoords;
    [Modifiers]
    private Element[] pointerOverActors;
    [Modifiers]
    private bool[] pointerTouched;
    [Modifiers]
    private int[] pointerScreenX;
    [Modifiers]
    private int[] pointerScreenY;
    [Modifiers]
    [Signature("Larc/struct/SnapshotSeq<Larc/scene/Scene$TouchFocus;>;")]
    private SnapshotSeq touchFocuses;
    private Viewport viewport;
    private int mouseScreenX;
    private int mouseScreenY;
    private Element mouseOverElement;
    private Element keyboardFocus;
    private Element scrollFocus;
    private bool actionsRequestRendering;
    [SpecialName]
    private static CallerID __\u003CcallerID\u003E;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool getActionsRequestRendering() => this.actionsRequestRendering;

    [LineNumberTable(new byte[] {158, 212, 162, 123})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Element hit(float stageX, float stageY, bool touchable)
    {
      int num = touchable ? 1 : 0;
      this.__\u003C\u003Eroot.parentToLocalCoordinates(this.tempCoords.set(stageX, stageY));
      return this.__\u003C\u003Eroot.hit(this.tempCoords.x, this.tempCoords.y, num != 0);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Element getKeyboardFocus() => this.keyboardFocus;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Element getScrollFocus() => this.scrollFocus;

    [LineNumberTable(new byte[] {162, 20, 112, 122, 107, 103, 99, 103, 103, 136, 109, 99, 103, 99, 103, 103, 104, 109, 171, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool setKeyboardFocus(Element actor)
    {
      if (object.ReferenceEquals((object) this.keyboardFocus, (object) actor))
        return true;
      FocusListener.FocusEvent focusEvent = (FocusListener.FocusEvent) Pools.obtain((Class) ClassLiteral<FocusListener.FocusEvent>.Value, (Prov) new Scene.__\u003C\u003EAnon7());
      focusEvent.type = FocusListener.FocusEvent.Type.__\u003C\u003Ekeyboard;
      Element keyboardFocus = this.keyboardFocus;
      if (keyboardFocus != null)
      {
        focusEvent.focused = false;
        focusEvent.relatedActor = actor;
        keyboardFocus.fire((SceneEvent) focusEvent);
      }
      int num = focusEvent.cancelled ? 0 : 1;
      if (num != 0)
      {
        this.keyboardFocus = actor;
        if (actor != null)
        {
          focusEvent.focused = true;
          focusEvent.relatedActor = keyboardFocus;
          actor.fire((SceneEvent) focusEvent);
          num = focusEvent.cancelled ? 0 : 1;
          if (num == 0)
            this.setKeyboardFocus(keyboardFocus);
        }
      }
      Pools.free((object) focusEvent);
      return num != 0;
    }

    [LineNumberTable(new byte[] {162, 58, 112, 122, 107, 103, 99, 103, 103, 136, 109, 99, 103, 99, 103, 103, 104, 109, 171, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool setScrollFocus(Element actor)
    {
      if (object.ReferenceEquals((object) this.scrollFocus, (object) actor))
        return true;
      FocusListener.FocusEvent focusEvent = (FocusListener.FocusEvent) Pools.obtain((Class) ClassLiteral<FocusListener.FocusEvent>.Value, (Prov) new Scene.__\u003C\u003EAnon7());
      focusEvent.type = FocusListener.FocusEvent.Type.__\u003C\u003Escroll;
      Element scrollFocus = this.scrollFocus;
      if (scrollFocus != null)
      {
        focusEvent.focused = false;
        focusEvent.relatedActor = actor;
        scrollFocus.fire((SceneEvent) focusEvent);
      }
      int num = focusEvent.cancelled ? 0 : 1;
      if (num != 0)
      {
        this.scrollFocus = actor;
        if (actor != null)
        {
          focusEvent.focused = true;
          focusEvent.relatedActor = scrollFocus;
          actor.fire((SceneEvent) focusEvent);
          num = focusEvent.cancelled ? 0 : 1;
          if (num == 0)
            this.setScrollFocus(scrollFocus);
        }
      }
      Pools.free((object) focusEvent);
      return num != 0;
    }

    [LineNumberTable(new byte[] {161, 99, 122, 103, 103, 103, 104, 104, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addTouchFocus(
      EventListener listener,
      Element listenerActor,
      Element target,
      int pointer,
      KeyCode button)
    {
      Scene.TouchFocus touchFocus = (Scene.TouchFocus) Pools.obtain((Class) ClassLiteral<Scene.TouchFocus>.Value, (Prov) new Scene.__\u003C\u003EAnon6());
      touchFocus.listenerActor = listenerActor;
      touchFocus.target = target;
      touchFocus.listener = listener;
      touchFocus.pointer = pointer;
      touchFocus.button = button;
      this.touchFocuses.add((object) touchFocus);
    }

    [LineNumberTable(new byte[] {162, 155, 102, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void calculateScissors(Rect localRect, Rect scissorRect) => this.viewport.calculateScissors(Draw.trans(), localRect, scissorRect);

    [LineNumberTable(new byte[] {162, 130, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec2 screenToStageCoordinates(Vec2 screenCoords)
    {
      this.viewport.unproject(screenCoords);
      return screenCoords;
    }

    [LineNumberTable(736)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Camera getCamera() => this.viewport.getCamera();

    [LineNumberTable(726)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getWidth() => this.viewport.getWorldWidth();

    [LineNumberTable(731)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getHeight() => this.viewport.getWorldHeight();

    [LineNumberTable(new byte[] {162, 9, 103, 126, 126})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void unfocus(Element actor)
    {
      this.cancelTouchFocus(actor);
      if (this.scrollFocus != null && this.scrollFocus.isDescendantOf(actor))
        this.setScrollFocus((Element) null);
      if (this.keyboardFocus == null || !this.keyboardFocus.isDescendantOf(actor))
        return;
      this.setKeyboardFocus((Element) null);
    }

    [Signature("<T:Ljava/lang/Object;>(Ljava/lang/Class<TT;>;)TT;")]
    [LineNumberTable(76)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object getStyle(Class type) => this.styleDefaults.getThrow((object) type, (Prov) new Scene.__\u003C\u003EAnon0(type));

    [LineNumberTable(new byte[] {161, 199, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void add(Element actor) => this.__\u003C\u003Eroot.addChild(actor);

    [LineNumberTable(new byte[] {62, 109, 108, 109, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Dialog getDialog()
    {
      if (this.getKeyboardFocus() is Dialog)
        return (Dialog) this.getKeyboardFocus();
      return this.getScrollFocus() is Dialog ? (Dialog) this.getScrollFocus() : (Dialog) null;
    }

    [LineNumberTable(100)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool hasDialog() => this.getScrollFocus() is Dialog || this.getKeyboardFocus() != null && this.getKeyboardFocus().isDescendantOf((Boolf) new Scene.__\u003C\u003EAnon4());

    [LineNumberTable(104)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool hasKeyboard() => this.getKeyboardFocus() != null;

    [LineNumberTable(new byte[] {159, 185, 232, 51, 107, 107, 109, 109, 109, 109, 242, 69, 167, 236, 72, 236, 75, 112, 140, 127, 1})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Scene()
    {
      Scene scene = this;
      this.styleDefaults = new ObjectMap();
      this.tempCoords = new Vec2();
      this.pointerOverActors = new Element[20];
      this.pointerTouched = new bool[20];
      this.pointerScreenX = new int[20];
      this.pointerScreenY = new int[20];
      this.touchFocuses = new SnapshotSeq(true, 4, (Class) ClassLiteral<Scene.TouchFocus>.Value);
      this.actionsRequestRendering = true;
      this.viewport = (Viewport) new Scene.\u0031(this);
      this.__\u003C\u003Eroot = (Group) new Scene.\u0032(this);
      this.__\u003C\u003Eroot.touchable = Touchable.__\u003C\u003EchildrenOnly;
      this.__\u003C\u003Eroot.setScene(this);
      this.viewport.update(Core.graphics.getWidth(), Core.graphics.getHeight(), true);
    }

    [LineNumberTable(new byte[] {84, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void act() => this.act(Core.graphics.getDeltaTime());

    [LineNumberTable(new byte[] {71, 108, 134, 142, 134, 107, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void draw()
    {
      Camera camera = this.viewport.getCamera();
      camera.update();
      if (!this.__\u003C\u003Eroot.visible)
        return;
      Draw.proj(camera);
      this.__\u003C\u003Eroot.draw();
      Draw.flush();
    }

    [LineNumberTable(new byte[] {162, 184, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void resize(int width, int height) => this.viewport.update(width, height, true);

    [Signature("<T:Ljava/lang/Object;>(Ljava/lang/Class<TT;>;TT;)V")]
    [LineNumberTable(new byte[] {30, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addStyle(Class type, object style) => this.styleDefaults.put((object) type, style);

    [LineNumberTable(92)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool hasMouse() => this.hit((float) Core.input.mouseX(), (float) Core.input.mouseY(), true) != null;

    [LineNumberTable(192)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Element find(string name) => this.__\u003C\u003Eroot.find(name);

    [LineNumberTable(88)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool hasField() => this.getKeyboardFocus() is TextField;

    [LineNumberTable(108)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool hasScroll() => this.getScrollFocus() != null;

    [LineNumberTable(96)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool hasMouse(float mousex, float mousey) => this.hit(mousex, mousey, true) != null;

    [LineNumberTable(593)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool addListener(EventListener listener) => this.__\u003C\u003Eroot.addListener(listener);

    [LineNumberTable(new byte[] {160, 91, 102, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Table table()
    {
      Table table = new Table();
      table.setFillParent(true);
      this.add((Element) table);
      return table;
    }

    [LineNumberTable(new byte[] {93, 113, 113, 127, 3, 191, 3, 113, 137, 109, 102, 105, 159, 5, 122, 107, 113, 113, 103, 103, 104, 102, 194, 255, 1, 44, 233, 87, 120, 159, 0, 127, 10, 127, 10, 104, 104, 105, 105, 103, 130, 203, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void act(float delta)
    {
      this.__\u003C\u003Eroot.y = this.marginBottom;
      this.__\u003C\u003Eroot.x = this.marginLeft;
      this.__\u003C\u003Eroot.height = this.getHeight() - this.marginBottom - this.marginTop;
      this.__\u003C\u003Eroot.width = this.getWidth() - this.marginLeft - this.marginRight;
      int index = 0;
      for (int length = this.pointerOverActors.Length; index < length; ++index)
      {
        Element pointerOverActor = this.pointerOverActors[index];
        if (!this.pointerTouched[index])
        {
          if (pointerOverActor != null)
          {
            this.pointerOverActors[index] = (Element) null;
            this.screenToStageCoordinates(this.tempCoords.set((float) this.pointerScreenX[index], (float) this.pointerScreenY[index]));
            InputEvent inputEvent = (InputEvent) Pools.obtain((Class) ClassLiteral<InputEvent>.Value, (Prov) new Scene.__\u003C\u003EAnon5());
            inputEvent.type = InputEvent.InputEventType.__\u003C\u003Eexit;
            inputEvent.stageX = this.tempCoords.x;
            inputEvent.stageY = this.tempCoords.y;
            inputEvent.relatedActor = pointerOverActor;
            inputEvent.pointer = index;
            pointerOverActor.fire((SceneEvent) inputEvent);
            Pools.free((object) inputEvent);
          }
        }
        else
          this.pointerOverActors[index] = this.fireEnterAndExit(pointerOverActor, this.pointerScreenX[index], this.pointerScreenY[index], index);
      }
      if (Core.app.isDesktop() || Core.app.isWeb())
        this.mouseOverElement = this.fireEnterAndExit(this.mouseOverElement, this.mouseScreenX, this.mouseScreenY, -1);
      if (this.scrollFocus != null && (!this.scrollFocus.visible || this.scrollFocus.getScene() == null))
        this.scrollFocus = (Element) null;
      if (this.keyboardFocus != null && (!this.keyboardFocus.visible || this.keyboardFocus.getScene() == null))
        this.keyboardFocus = (Element) null;
      if (this.scrollFocus != null)
      {
        for (Element element = this.scrollFocus; element.parent != null; element = (Element) element.parent)
        {
          if (!element.visible)
          {
            this.scrollFocus = (Element) null;
            break;
          }
        }
      }
      this.__\u003C\u003Eroot.act(delta);
    }

    [LineNumberTable(new byte[] {160, 117, 118, 126, 171, 102, 122, 113, 113, 104, 107, 103, 104, 166, 102, 122, 113, 113, 104, 107, 103, 104, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Element fireEnterAndExit([In] Element obj0, [In] int obj1, [In] int obj2, [In] int obj3)
    {
      this.screenToStageCoordinates(this.tempCoords.set((float) obj1, (float) obj2));
      Element element = this.hit(this.tempCoords.x, this.tempCoords.y, true);
      if (object.ReferenceEquals((object) element, (object) obj0))
        return obj0;
      if (obj0 != null)
      {
        InputEvent inputEvent = (InputEvent) Pools.obtain((Class) ClassLiteral<InputEvent>.Value, (Prov) new Scene.__\u003C\u003EAnon5());
        inputEvent.stageX = this.tempCoords.x;
        inputEvent.stageY = this.tempCoords.y;
        inputEvent.pointer = obj3;
        inputEvent.type = InputEvent.InputEventType.__\u003C\u003Eexit;
        inputEvent.relatedActor = element;
        obj0.fire((SceneEvent) inputEvent);
        Pools.free((object) inputEvent);
      }
      if (element != null)
      {
        InputEvent inputEvent = (InputEvent) Pools.obtain((Class) ClassLiteral<InputEvent>.Value, (Prov) new Scene.__\u003C\u003EAnon5());
        inputEvent.stageX = this.tempCoords.x;
        inputEvent.stageY = this.tempCoords.y;
        inputEvent.pointer = obj3;
        inputEvent.type = InputEvent.InputEventType.__\u003C\u003Eenter;
        inputEvent.relatedActor = obj0;
        element.fire((SceneEvent) inputEvent);
        Pools.free((object) inputEvent);
      }
      return element;
    }

    [LineNumberTable(new byte[] {162, 174, 108, 110, 108, 110, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual bool isInsideViewport(int screenX, int screenY)
    {
      int screenX1 = this.viewport.getScreenX();
      int num1 = screenX1 + this.viewport.getScreenWidth();
      int screenY1 = this.viewport.getScreenY();
      int num2 = screenY1 + this.viewport.getScreenHeight();
      screenY = Core.graphics.getHeight() - screenY;
      return screenX >= screenX1 && screenX < num1 && (screenY >= screenY1 && screenY < num2);
    }

    [LineNumberTable(new byte[] {161, 169, 122, 107, 107, 203, 103, 108, 114, 101, 127, 1, 109, 109, 109, 109, 109, 238, 56, 233, 75, 134, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void cancelTouchFocusExcept(EventListener exceptListener, Element exceptActor)
    {
      InputEvent inputEvent = (InputEvent) Pools.obtain((Class) ClassLiteral<InputEvent>.Value, (Prov) new Scene.__\u003C\u003EAnon5());
      inputEvent.type = InputEvent.InputEventType.__\u003C\u003EtouchUp;
      inputEvent.stageX = (float) int.MinValue;
      inputEvent.stageY = (float) int.MinValue;
      SnapshotSeq touchFocuses = this.touchFocuses;
      Scene.TouchFocus[] touchFocusArray = (Scene.TouchFocus[]) touchFocuses.begin();
      int index = 0;
      for (int size = touchFocuses.size; index < size; ++index)
      {
        Scene.TouchFocus touchFocus = touchFocusArray[index];
        if ((!object.ReferenceEquals((object) touchFocus.listener, (object) exceptListener) || !object.ReferenceEquals((object) touchFocus.listenerActor, (object) exceptActor)) && touchFocuses.remove((object) touchFocus, true))
        {
          inputEvent.targetActor = touchFocus.target;
          inputEvent.listenerActor = touchFocus.listenerActor;
          inputEvent.pointer = touchFocus.pointer;
          inputEvent.keyCode = touchFocus.button;
          touchFocus.listener.handle((SceneEvent) inputEvent);
        }
      }
      touchFocuses.end();
      Pools.free((object) inputEvent);
    }

    [LineNumberTable(new byte[] {162, 2, 104, 104, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void unfocusAll()
    {
      this.setScrollFocus((Element) null);
      this.setKeyboardFocus((Element) null);
      this.cancelTouchFocus();
    }

    [LineNumberTable(new byte[] {161, 161, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void cancelTouchFocus() => this.cancelTouchFocusExcept((EventListener) null, (Element) null);

    [LineNumberTable(new byte[] {161, 129, 122, 107, 107, 203, 103, 108, 114, 101, 113, 109, 109, 109, 109, 109, 238, 56, 233, 75, 134, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void cancelTouchFocus(Element actor)
    {
      InputEvent inputEvent = (InputEvent) Pools.obtain((Class) ClassLiteral<InputEvent>.Value, (Prov) new Scene.__\u003C\u003EAnon5());
      inputEvent.type = InputEvent.InputEventType.__\u003C\u003EtouchUp;
      inputEvent.stageX = (float) int.MinValue;
      inputEvent.stageY = (float) int.MinValue;
      SnapshotSeq touchFocuses = this.touchFocuses;
      Scene.TouchFocus[] touchFocusArray = (Scene.TouchFocus[]) touchFocuses.begin();
      int index = 0;
      for (int size = touchFocuses.size; index < size; ++index)
      {
        Scene.TouchFocus touchFocus = touchFocusArray[index];
        if (object.ReferenceEquals((object) touchFocus.listenerActor, (object) actor) && touchFocuses.remove((object) touchFocus, true))
        {
          inputEvent.targetActor = touchFocus.target;
          inputEvent.listenerActor = touchFocus.listenerActor;
          inputEvent.pointer = touchFocus.pointer;
          inputEvent.keyCode = touchFocus.button;
          touchFocus.listener.handle((SceneEvent) inputEvent);
        }
      }
      touchFocuses.end();
      Pools.free((object) inputEvent);
    }

    [Modifiers]
    [LineNumberTable(76)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static RuntimeException lambda\u0024getStyle\u00240([In] Class obj0) => (RuntimeException) new IllegalArgumentException(new StringBuilder().append("No default style for type: ").append(obj0.getSimpleName()).toString());

    [Modifiers]
    [LineNumberTable(84)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024registerStyles\u00241([In] Field obj0) => String.instancehelper_startsWith(obj0.getName(), "default");

    [Modifiers]
    [LineNumberTable(84)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024registerStyles\u00242([In] Field obj0) => this.addStyle(obj0.getType(), Reflect.get(obj0));

    [Modifiers]
    [LineNumberTable(100)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024hasDialog\u00243([In] Element obj0) => obj0 is Dialog;

    [Modifiers]
    [LineNumberTable(469)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static Scene.TouchFocus lambda\u0024addTouchFocus\u00244() => new Scene.TouchFocus((Scene.\u0031) null);

    [LineNumberTable(new byte[] {20, 104, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Scene(Viewport viewport)
      : this()
    {
      Scene scene = this;
      this.viewport = viewport;
    }

    [Signature("(Ljava/lang/Class<*>;)V")]
    [LineNumberTable(new byte[] {34, 127, 11})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void registerStyles(Class type) => Seq.with((object[]) type.getFields(Scene.__\u003CGetCallerID\u003E())).each((Boolf) new Scene.__\u003C\u003EAnon2(), (Cons) new Scene.__\u003C\u003EAnon3(this));

    [LineNumberTable(196)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Element findVisible(string name) => this.__\u003C\u003Eroot.findVisible(name);

    [Signature("(Larc/func/Boolf<Larc/scene/Element;>;)Larc/scene/Element;")]
    [LineNumberTable(200)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Element find(Boolf pred) => this.__\u003C\u003Eroot.find(pred);

    [Signature("(Larc/func/Cons<Larc/scene/ui/layout/Table;>;)Larc/scene/ui/layout/Table;")]
    [LineNumberTable(new byte[] {160, 99, 102, 103, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Table table(Cons cons)
    {
      Table table = new Table();
      table.setFillParent(true);
      this.add((Element) table);
      cons.get((object) table);
      return table;
    }

    [Signature("(Larc/scene/style/Drawable;Larc/func/Cons<Larc/scene/ui/layout/Table;>;)Larc/scene/ui/layout/Table;")]
    [LineNumberTable(new byte[] {160, 108, 103, 103, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Table table(Drawable style, Cons cons)
    {
      Table table = new Table(style);
      table.setFillParent(true);
      this.add((Element) table);
      cons.get((object) table);
      return table;
    }

    [LineNumberTable(new byte[] {160, 152, 140, 105, 105, 137, 150, 122, 107, 113, 113, 103, 136, 126, 99, 159, 7, 168, 103, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool touchDown(int screenX, int screenY, int pointer, KeyCode button)
    {
      if (!this.isInsideViewport(screenX, screenY))
        return false;
      this.pointerTouched[pointer] = true;
      this.pointerScreenX[pointer] = screenX;
      this.pointerScreenY[pointer] = screenY;
      this.screenToStageCoordinates(this.tempCoords.set((float) screenX, (float) screenY));
      InputEvent inputEvent = (InputEvent) Pools.obtain((Class) ClassLiteral<InputEvent>.Value, (Prov) new Scene.__\u003C\u003EAnon5());
      inputEvent.type = InputEvent.InputEventType.__\u003C\u003EtouchDown;
      inputEvent.stageX = this.tempCoords.x;
      inputEvent.stageY = this.tempCoords.y;
      inputEvent.pointer = pointer;
      inputEvent.keyCode = button;
      Element element = this.hit(this.tempCoords.x, this.tempCoords.y, true);
      if (element == null)
      {
        if (object.ReferenceEquals((object) this.__\u003C\u003Eroot.touchable, (object) Touchable.__\u003C\u003Eenabled))
          this.__\u003C\u003Eroot.fire((SceneEvent) inputEvent);
      }
      else
        element.fire((SceneEvent) inputEvent);
      int num = inputEvent.handled ? 1 : 0;
      Pools.free((object) inputEvent);
      return num != 0;
    }

    [LineNumberTable(new byte[] {160, 185, 105, 105, 103, 135, 143, 150, 122, 107, 113, 113, 135, 103, 108, 114, 101, 108, 109, 109, 109, 245, 58, 233, 72, 134, 103, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool touchDragged(int screenX, int screenY, int pointer)
    {
      this.pointerScreenX[pointer] = screenX;
      this.pointerScreenY[pointer] = screenY;
      this.mouseScreenX = screenX;
      this.mouseScreenY = screenY;
      if (this.touchFocuses.size == 0)
        return false;
      this.screenToStageCoordinates(this.tempCoords.set((float) screenX, (float) screenY));
      InputEvent inputEvent = (InputEvent) Pools.obtain((Class) ClassLiteral<InputEvent>.Value, (Prov) new Scene.__\u003C\u003EAnon5());
      inputEvent.type = InputEvent.InputEventType.__\u003C\u003EtouchDragged;
      inputEvent.stageX = this.tempCoords.x;
      inputEvent.stageY = this.tempCoords.y;
      inputEvent.pointer = pointer;
      SnapshotSeq touchFocuses = this.touchFocuses;
      Scene.TouchFocus[] touchFocusArray = (Scene.TouchFocus[]) touchFocuses.begin();
      int index = 0;
      for (int size = touchFocuses.size; index < size; ++index)
      {
        Scene.TouchFocus touchFocus = touchFocusArray[index];
        if (touchFocus.pointer == pointer && touchFocuses.contains((object) touchFocus, true))
        {
          inputEvent.targetActor = touchFocus.target;
          inputEvent.listenerActor = touchFocus.listenerActor;
          if (touchFocus.listener.handle((SceneEvent) inputEvent))
            inputEvent.handle();
        }
      }
      touchFocuses.end();
      int num = inputEvent.handled ? 1 : 0;
      Pools.free((object) inputEvent);
      return num != 0;
    }

    [LineNumberTable(new byte[] {160, 223, 105, 105, 137, 143, 150, 122, 107, 113, 113, 103, 136, 103, 108, 114, 101, 127, 0, 109, 109, 109, 117, 231, 57, 233, 73, 134, 103, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool touchUp(int screenX, int screenY, int pointer, KeyCode button)
    {
      this.pointerTouched[pointer] = false;
      this.pointerScreenX[pointer] = screenX;
      this.pointerScreenY[pointer] = screenY;
      if (this.touchFocuses.size == 0)
        return false;
      this.screenToStageCoordinates(this.tempCoords.set((float) screenX, (float) screenY));
      InputEvent inputEvent = (InputEvent) Pools.obtain((Class) ClassLiteral<InputEvent>.Value, (Prov) new Scene.__\u003C\u003EAnon5());
      inputEvent.type = InputEvent.InputEventType.__\u003C\u003EtouchUp;
      inputEvent.stageX = this.tempCoords.x;
      inputEvent.stageY = this.tempCoords.y;
      inputEvent.pointer = pointer;
      inputEvent.keyCode = button;
      SnapshotSeq touchFocuses = this.touchFocuses;
      Scene.TouchFocus[] touchFocusArray = (Scene.TouchFocus[]) touchFocuses.begin();
      int index = 0;
      for (int size = touchFocuses.size; index < size; ++index)
      {
        Scene.TouchFocus touchFocus = touchFocusArray[index];
        if (touchFocus.pointer == pointer && object.ReferenceEquals((object) touchFocus.button, (object) button) && touchFocuses.remove((object) touchFocus, true))
        {
          inputEvent.targetActor = touchFocus.target;
          inputEvent.listenerActor = touchFocus.listenerActor;
          if (touchFocus.listener.handle((SceneEvent) inputEvent))
            inputEvent.handle();
          Pools.free((object) touchFocus);
        }
      }
      touchFocuses.end();
      int num = inputEvent.handled ? 1 : 0;
      Pools.free((object) inputEvent);
      return num != 0;
    }

    [LineNumberTable(new byte[] {161, 6, 140, 103, 135, 150, 122, 107, 113, 145, 126, 138, 104, 103, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool mouseMoved(int screenX, int screenY)
    {
      if (!this.isInsideViewport(screenX, screenY))
        return false;
      this.mouseScreenX = screenX;
      this.mouseScreenY = screenY;
      this.screenToStageCoordinates(this.tempCoords.set((float) screenX, (float) screenY));
      InputEvent inputEvent = (InputEvent) Pools.obtain((Class) ClassLiteral<InputEvent>.Value, (Prov) new Scene.__\u003C\u003EAnon5());
      inputEvent.type = InputEvent.InputEventType.__\u003C\u003EmouseMoved;
      inputEvent.stageX = this.tempCoords.x;
      inputEvent.stageY = this.tempCoords.y;
      (this.hit(this.tempCoords.x, this.tempCoords.y, true) ?? (Element) this.__\u003C\u003Eroot).fire((SceneEvent) inputEvent);
      int num = inputEvent.handled ? 1 : 0;
      Pools.free((object) inputEvent);
      return num != 0;
    }

    [LineNumberTable(new byte[] {161, 33, 151, 159, 1, 122, 107, 104, 104, 113, 113, 104, 103, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool scrolled(float amountX, float amountY)
    {
      Element element = this.scrollFocus != null ? this.scrollFocus : (Element) this.__\u003C\u003Eroot;
      this.screenToStageCoordinates(this.tempCoords.set((float) this.mouseScreenX, (float) this.mouseScreenY));
      InputEvent inputEvent = (InputEvent) Pools.obtain((Class) ClassLiteral<InputEvent>.Value, (Prov) new Scene.__\u003C\u003EAnon5());
      inputEvent.type = InputEvent.InputEventType.__\u003C\u003Escrolled;
      inputEvent.scrollAmountX = amountX;
      inputEvent.scrollAmountY = amountY;
      inputEvent.stageX = this.tempCoords.x;
      inputEvent.stageY = this.tempCoords.y;
      element.fire((SceneEvent) inputEvent);
      int num = inputEvent.handled ? 1 : 0;
      Pools.free((object) inputEvent);
      return num != 0;
    }

    [LineNumberTable(new byte[] {161, 55, 119, 122, 107, 103, 104, 103, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool keyDown(KeyCode keyCode)
    {
      Element element = this.keyboardFocus != null ? this.keyboardFocus : (Element) this.__\u003C\u003Eroot;
      InputEvent inputEvent = (InputEvent) Pools.obtain((Class) ClassLiteral<InputEvent>.Value, (Prov) new Scene.__\u003C\u003EAnon5());
      inputEvent.type = InputEvent.InputEventType.__\u003C\u003EkeyDown;
      inputEvent.keyCode = keyCode;
      element.fire((SceneEvent) inputEvent);
      int num = inputEvent.handled ? 1 : 0;
      Pools.free((object) inputEvent);
      return num != 0;
    }

    [LineNumberTable(new byte[] {161, 71, 119, 122, 107, 103, 104, 103, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool keyUp(KeyCode keyCode)
    {
      Element element = this.keyboardFocus != null ? this.keyboardFocus : (Element) this.__\u003C\u003Eroot;
      InputEvent inputEvent = (InputEvent) Pools.obtain((Class) ClassLiteral<InputEvent>.Value, (Prov) new Scene.__\u003C\u003EAnon5());
      inputEvent.type = InputEvent.InputEventType.__\u003C\u003EkeyUp;
      inputEvent.keyCode = keyCode;
      element.fire((SceneEvent) inputEvent);
      int num = inputEvent.handled ? 1 : 0;
      Pools.free((object) inputEvent);
      return num != 0;
    }

    [LineNumberTable(new byte[] {159, 28, 98, 119, 122, 107, 103, 104, 103, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool keyTyped(char character)
    {
      int num1 = (int) character;
      Element element = this.keyboardFocus != null ? this.keyboardFocus : (Element) this.__\u003C\u003Eroot;
      InputEvent inputEvent = (InputEvent) Pools.obtain((Class) ClassLiteral<InputEvent>.Value, (Prov) new Scene.__\u003C\u003EAnon5());
      inputEvent.type = InputEvent.InputEventType.__\u003C\u003EkeyTyped;
      inputEvent.character = (char) num1;
      element.fire((SceneEvent) inputEvent);
      int num2 = inputEvent.handled ? 1 : 0;
      Pools.free((object) inputEvent);
      return num2 != 0;
    }

    [LineNumberTable(new byte[] {161, 113, 103, 112, 109, 159, 36, 104, 230, 59, 233, 72})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void removeTouchFocus(
      EventListener listener,
      Element listenerActor,
      Element target,
      int pointer,
      KeyCode button)
    {
      SnapshotSeq touchFocuses = this.touchFocuses;
      for (int index = touchFocuses.size - 1; index >= 0; index += -1)
      {
        Scene.TouchFocus touchFocus = (Scene.TouchFocus) touchFocuses.get(index);
        if (object.ReferenceEquals((object) touchFocus.listener, (object) listener) && object.ReferenceEquals((object) touchFocus.listenerActor, (object) listenerActor) && (object.ReferenceEquals((object) touchFocus.target, (object) target) && touchFocus.pointer == pointer) && object.ReferenceEquals((object) touchFocus.button, (object) button))
        {
          touchFocuses.remove(index);
          Pools.free((object) touchFocus);
        }
      }
    }

    [LineNumberTable(new byte[] {161, 207, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addAction(Action action) => this.__\u003C\u003Eroot.addAction(action);

    [Signature("()Larc/struct/Seq<Larc/scene/Element;>;")]
    [LineNumberTable(585)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Seq getElements() => (Seq) this.__\u003C\u003Eroot.__\u003C\u003Echildren;

    [LineNumberTable(601)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool removeListener(EventListener listener) => this.__\u003C\u003Eroot.removeListener(listener);

    [LineNumberTable(609)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool addCaptureListener(EventListener listener) => this.__\u003C\u003Eroot.addCaptureListener(listener);

    [LineNumberTable(617)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool removeCaptureListener(EventListener listener) => this.__\u003C\u003Eroot.removeCaptureListener(listener);

    [LineNumberTable(new byte[] {161, 252, 102, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void clear()
    {
      this.unfocusAll();
      this.__\u003C\u003Eroot.clear();
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Viewport getViewport() => this.viewport;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setViewport(Viewport viewport) => this.viewport = viewport;

    [LineNumberTable(new byte[] {162, 139, 109, 122})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec2 stageToScreenCoordinates(Vec2 stageCoords)
    {
      this.viewport.project(stageCoords);
      stageCoords.y = (float) this.viewport.getScreenHeight() - stageCoords.y;
      return stageCoords;
    }

    [LineNumberTable(776)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec2 toScreenCoordinates(Vec2 coords, Mat transformMatrix) => this.viewport.toScreenCoordinates(coords, transformMatrix);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setActionsRequestRendering(bool actionsRequestRendering) => this.actionsRequestRendering = actionsRequestRendering;

    [HideFromJava]
    public virtual void connected([In] InputDevice obj0) => InputProcessor.\u003Cdefault\u003Econnected((InputProcessor) this, obj0);

    [HideFromJava]
    public virtual void disconnected([In] InputDevice obj0) => InputProcessor.\u003Cdefault\u003Edisconnected((InputProcessor) this, obj0);

    static CallerID __\u003CGetCallerID\u003E()
    {
      if (Scene.__\u003CcallerID\u003E == null)
        Scene.__\u003CcallerID\u003E = (CallerID) new Scene.__\u003CCallerID\u003E();
      return Scene.__\u003CcallerID\u003E;
    }

    [Modifiers]
    public Group root
    {
      [HideFromJava] get => this.__\u003C\u003Eroot;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Eroot = value;
    }

    [EnclosingMethod(null, "<init>", "()V")]
    [SpecialName]
    internal class \u0031 : ScreenViewport
    {
      [Modifiers]
      internal Scene this\u00240;

      [LineNumberTable(44)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0031([In] Scene obj0)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector();
      }

      [LineNumberTable(new byte[] {159, 189, 97, 63, 5, 133})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void calculateScissors([In] Mat obj0, [In] Rect obj1, [In] Rect obj2) => ScissorStack.calculateScissors(this.getCamera(), (float) this.getScreenX(), (float) this.getScreenY(), (float) this.getScreenWidth(), (float) this.getScreenHeight(), obj0, obj1, obj2);
    }

    [EnclosingMethod(null, "<init>", "()V")]
    [SpecialName]
    internal class \u0032 : Group
    {
      [Modifiers]
      internal Scene this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(52)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0032([In] Scene obj0)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector();
      }

      [LineNumberTable(55)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override float getHeight() => this.this\u00240.getHeight() - this.this\u00240.marginTop - this.this\u00240.marginBottom;

      [LineNumberTable(60)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override float getWidth() => this.this\u00240.getWidth() - this.this\u00240.marginLeft - this.this\u00240.marginRight;

      [HideFromJava]
      static \u0032() => Group.__\u003Cclinit\u003E();
    }

    [InnerClass]
    internal sealed class TouchFocus : Object, Pool.Poolable
    {
      internal EventListener listener;
      internal Element listenerActor;
      internal Element target;
      internal int pointer;
      internal KeyCode button;

      [Modifiers]
      [LineNumberTable(817)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal TouchFocus([In] Scene.\u0031 obj0)
        : this()
      {
      }

      [LineNumberTable(817)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private TouchFocus()
      {
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void reset()
      {
        this.listenerActor = (Element) null;
        this.listener = (EventListener) null;
        this.target = (Element) null;
      }
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Prov
    {
      private readonly Class arg\u00241;

      internal __\u003C\u003EAnon0([In] Class obj0) => this.arg\u00241 = obj0;

      public object get() => (object) Scene.lambda\u0024getStyle\u00240(this.arg\u00241);
    }

    private sealed class __\u003CCallerID\u003E : CallerID
    {
      internal __\u003CCallerID\u003E()
      {
      }
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon2 : Boolf
    {
      internal __\u003C\u003EAnon2()
      {
      }

      public bool get([In] object obj0) => (Scene.lambda\u0024registerStyles\u00241((Field) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon3 : Cons
    {
      private readonly Scene arg\u00241;

      internal __\u003C\u003EAnon3([In] Scene obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024registerStyles\u00242((Field) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon4 : Boolf
    {
      internal __\u003C\u003EAnon4()
      {
      }

      public bool get([In] object obj0) => (Scene.lambda\u0024hasDialog\u00243((Element) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon5 : Prov
    {
      internal __\u003C\u003EAnon5()
      {
      }

      public object get() => (object) new InputEvent();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon6 : Prov
    {
      internal __\u003C\u003EAnon6()
      {
      }

      public object get() => (object) Scene.lambda\u0024addTouchFocus\u00244();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon7 : Prov
    {
      internal __\u003C\u003EAnon7()
      {
      }

      public object get() => (object) new FocusListener.FocusEvent();
    }
  }
}
