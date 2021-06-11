// Decompiled with JetBrains decompiler
// Type: arc.scene.ui.Dialog
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.func;
using arc.graphics;
using arc.graphics.g2d;
using arc.input;
using arc.math;
using arc.math.geom;
using arc.scene.@event;
using arc.scene.actions;
using arc.scene.style;
using arc.scene.ui.layout;
using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.scene.ui
{
  public class Dialog : Table
  {
    [Signature("Larc/func/Prov<Larc/scene/Action;>;")]
    private static Prov defaultShowAction;
    [Signature("Larc/func/Prov<Larc/scene/Action;>;")]
    private static Prov defaultHideAction;
    protected internal InputListener ignoreTouchDown;
    [Modifiers]
    private static Vec2 tmpPosition;
    [Modifiers]
    private static Vec2 tmpSize;
    private const int MOVE = 32;
    protected internal int edge;
    protected internal bool dragging;
    internal bool isMovable;
    internal bool isModal;
    internal bool isResizable;
    internal bool center;
    internal int resizeBorder;
    internal bool keepWithinStage;
    private Dialog.DialogStyle style;
    internal Element previousKeyboardFocus;
    internal Element previousScrollFocus;
    internal FocusListener focusListener;
    internal Table __\u003C\u003Econt;
    internal Table __\u003C\u003Ebuttons;
    internal Label __\u003C\u003Etitle;
    internal Table __\u003C\u003EtitleTable;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(452)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Dialog show() => this.show(Core.scene);

    [LineNumberTable(408)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isShown() => this.getScene() != null;

    [LineNumberTable(new byte[] {10, 232, 35, 236, 77, 124, 103, 231, 79, 115, 107, 135, 127, 21, 140, 107, 127, 7, 150, 103, 107, 139, 237, 71, 237, 160, 114, 135, 113, 127, 5, 103, 159, 0, 118, 150, 236, 87, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Dialog(string title, Dialog.DialogStyle style)
    {
      Dialog dialog1 = this;
      this.ignoreTouchDown = (InputListener) new Dialog.\u0031(this);
      this.isMovable = false;
      this.isModal = true;
      this.isResizable = false;
      this.center = true;
      this.resizeBorder = 8;
      this.keepWithinStage = true;
      if (title == null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException("title cannot be null.");
      }
      this.touchable = Touchable.__\u003C\u003Eenabled;
      this.setClip(true);
      Label.__\u003Cclinit\u003E();
      string str = title;
      Label.LabelStyle style1 = new Label.LabelStyle(style.titleFont, style.titleFontColor);
      object obj = (object) str;
      CharSequence text;
      text.__\u003Cref\u003E = (__Null) obj;
      this.__\u003C\u003Etitle = new Label(text, style1);
      this.__\u003C\u003Etitle.setEllipsis(true);
      this.__\u003C\u003EtitleTable = new Table();
      this.__\u003C\u003EtitleTable.add((Element) this.__\u003C\u003Etitle).expandX().fillX().minWidth(0.0f);
      this.add((Element) this.__\u003C\u003EtitleTable).growX().row();
      this.setStyle(style);
      this.setWidth(150f);
      this.setHeight(150f);
      this.addCaptureListener((EventListener) new Dialog.\u0032(this));
      this.addListener((EventListener) new Dialog.\u0033(this));
      this.setOrigin(1);
      this.defaults().pad(3f);
      Dialog dialog2 = this;
      Table table1 = new Table();
      Table table2 = table1;
      this.__\u003C\u003Econt = table1;
      this.add((Element) table2).expand().fill();
      this.row();
      Dialog dialog3 = this;
      Table table3 = new Table();
      Table table4 = table3;
      this.__\u003C\u003Ebuttons = table3;
      this.add((Element) table4).fillX();
      this.__\u003C\u003Econt.defaults().pad(3f);
      this.__\u003C\u003Ebuttons.defaults().pad(3f);
      this.focusListener = (FocusListener) new Dialog.\u0034(this);
      this.shown((Runnable) new Dialog.__\u003C\u003EAnon0(this));
    }

    [LineNumberTable(new byte[] {160, 128, 115, 103, 140, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setStyle(Dialog.DialogStyle style)
    {
      if (style == null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException("style cannot be null.");
      }
      this.style = style;
      this.setBackground(style.background);
      this.invalidateHierarchy();
    }

    [LineNumberTable(new byte[] {161, 4, 238, 71})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void shown(Runnable run) => this.addListener((EventListener) new Dialog.\u0035(this, run));

    [LineNumberTable(new byte[] {160, 136, 105, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void keepWithinStage()
    {
      if (!this.keepWithinStage)
        return;
      this.keepInStage();
    }

    [LineNumberTable(new byte[] {160, 181, 127, 89})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void centerWindow() => this.setPosition((float) Math.round((Core.scene.getWidth() - Core.scene.marginLeft - Core.scene.marginRight - this.getWidth()) / 2f), (float) Math.round((Core.scene.getHeight() - Core.scene.marginTop - Core.scene.marginBottom - this.getHeight()) / 2f));

    [LineNumberTable(new byte[] {160, 167, 103, 127, 6, 121})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void drawStageBackground(
      float x,
      float y,
      float width,
      float height)
    {
      Color color = this.__\u003C\u003Ecolor;
      Draw.color(color.r, color.g, color.b, color.a * this.parentAlpha);
      this.style.stageBackground.draw(x, y, width, height);
    }

    [LineNumberTable(new byte[] {161, 119, 105, 103, 103, 135, 117})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void hide()
    {
      if (!this.isShown())
        return;
      this.setOrigin(1);
      this.setClip(false);
      this.setTransform(true);
      this.hide((Action) Dialog.defaultHideAction.get());
    }

    [LineNumberTable(new byte[] {161, 87, 119, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Dialog show(Scene stage)
    {
      this.show(stage, (Action) Dialog.defaultShowAction.get());
      this.centerWindow();
      return this;
    }

    [LineNumberTable(new byte[] {161, 43, 103, 103, 135, 141, 102, 141, 103, 103, 147, 103, 103, 147, 102, 103, 104, 136, 106, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Dialog show(Scene stage, Action action)
    {
      this.setOrigin(1);
      this.setClip(false);
      this.setTransform(true);
      this.fire((SceneEvent) new VisibilityEvent(false));
      this.clearActions();
      this.removeCaptureListener((EventListener) this.ignoreTouchDown);
      this.previousKeyboardFocus = (Element) null;
      Element keyboardFocus = stage.getKeyboardFocus();
      if (keyboardFocus != null && !keyboardFocus.isDescendantOf((Element) this))
        this.previousKeyboardFocus = keyboardFocus;
      this.previousScrollFocus = (Element) null;
      Element scrollFocus = stage.getScrollFocus();
      if (scrollFocus != null && !scrollFocus.isDescendantOf((Element) this))
        this.previousScrollFocus = scrollFocus;
      this.pack();
      stage.add((Element) this);
      stage.setKeyboardFocus((Element) this);
      stage.setScrollFocus((Element) this);
      if (action != null)
        this.addAction(action);
      this.pack();
      return this;
    }

    [LineNumberTable(new byte[] {161, 94, 141, 103, 102, 109, 124, 103, 153, 124, 103, 153, 99, 109, 159, 0, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void hide(Action action)
    {
      this.fire((SceneEvent) new VisibilityEvent(true));
      Scene scene = this.getScene();
      if (scene != null)
      {
        this.removeListener((EventListener) this.focusListener);
        if (this.previousKeyboardFocus != null && this.previousKeyboardFocus.getScene() == null)
          this.previousKeyboardFocus = (Element) null;
        Element keyboardFocus = scene.getKeyboardFocus();
        if (keyboardFocus == null || keyboardFocus.isDescendantOf((Element) this))
          scene.setKeyboardFocus(this.previousKeyboardFocus);
        if (this.previousScrollFocus != null && this.previousScrollFocus.getScene() == null)
          this.previousScrollFocus = (Element) null;
        Element scrollFocus = scene.getScrollFocus();
        if (scrollFocus == null || scrollFocus.isDescendantOf((Element) this))
          scene.setScrollFocus(this.previousScrollFocus);
      }
      if (action != null)
      {
        this.addCaptureListener((EventListener) this.ignoreTouchDown);
        this.addAction((Action) Actions.sequence(action, (Action) Actions.removeListener((EventListener) this.ignoreTouchDown, true), (Action) Actions.remove()));
      }
      else
        this.remove();
    }

    [LineNumberTable(new byte[] {160, 229, 139, 246, 72})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void updateScrollFocus()
    {
      bool[] flagArray = new bool[1]{ false };
      Core.app.post((Runnable) new Dialog.__\u003C\u003EAnon1(this, flagArray));
    }

    [Modifiers]
    [LineNumberTable(345)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024updateScrollFocus\u00243([In] bool[] obj0) => this.forEach((Cons) new Dialog.__\u003C\u003EAnon4(obj0));

    [Modifiers]
    [LineNumberTable(new byte[] {161, 31, 122, 149})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024closeOnBack\u00244([In] KeyCode obj0)
    {
      if (!object.ReferenceEquals((object) obj0, (object) KeyCode.__\u003C\u003Eescape) && !object.ReferenceEquals((object) obj0, (object) KeyCode.__\u003C\u003Eback))
        return;
      Core.app.post((Runnable) new Dialog.__\u003C\u003EAnon3(this));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 232, 134, 104, 108, 132})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024updateScrollFocus\u00242([In] bool[] obj0, [In] Element obj1)
    {
      if (obj0[0] || !(obj1 is ScrollPane))
        return;
      Core.scene.setScrollFocus(obj1);
      obj0[0] = true;
    }

    [Modifiers]
    [LineNumberTable(29)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static Action lambda\u0024static\u00240() => (Action) Actions.sequence((Action) Actions.alpha(0.0f), (Action) Actions.fadeIn(0.4f, Interp.fade));

    [Modifiers]
    [LineNumberTable(30)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static Action lambda\u0024static\u00241() => (Action) Actions.fadeOut(0.4f, Interp.fade);

    [LineNumberTable(new byte[] {7, 123})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Dialog(string title)
      : this(title, (Dialog.DialogStyle) Core.scene.getStyle((Class) ClassLiteral<Dialog.DialogStyle>.Value))
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Dialog.DialogStyle getStyle() => this.style;

    [LineNumberTable(new byte[] {160, 142, 136, 104, 102, 125, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void act(float delta)
    {
      base.act(delta);
      if (this.getScene() == null)
        return;
      this.keepWithinStage();
      if (!this.center || this.isMovable || this.getActions().size != 0)
        return;
      this.centerWindow();
    }

    [LineNumberTable(new byte[] {160, 154, 103, 144, 112, 123, 127, 0, 191, 47, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void draw()
    {
      Scene scene = this.getScene();
      if (scene.getKeyboardFocus() == null)
        scene.setKeyboardFocus((Element) this);
      if (this.style.stageBackground != null)
      {
        this.stageToLocalCoordinates(Dialog.tmpPosition.set(0.0f, 0.0f));
        this.stageToLocalCoordinates(Dialog.tmpSize.set(scene.getWidth(), scene.getHeight()));
        this.drawStageBackground(this.x + Dialog.tmpPosition.x, this.y + Dialog.tmpPosition.y, this.x + Dialog.tmpSize.x, this.y + Dialog.tmpSize.y);
      }
      base.draw();
    }

    [LineNumberTable(new byte[] {159, 70, 66, 108, 127, 3})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override Element hit(float x, float y, bool touchable)
    {
      int num = touchable ? 1 : 0;
      Element element = base.hit(x, y, num != 0);
      return element == null && this.isModal && (num == 0 || object.ReferenceEquals((object) this.touchable, (object) Touchable.__\u003C\u003Eenabled)) ? (Element) this : element;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isMovable() => this.isMovable;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setMovable(bool isMovable) => this.isMovable = isMovable;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isModal() => this.isModal;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setModal(bool isModal) => this.isModal = isModal;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setKeepWithinStage(bool keepWithinStage) => this.keepWithinStage = keepWithinStage;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isCentered() => this.center;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setCentered(bool center) => this.center = center;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isResizable() => this.isResizable;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setResizable(bool isResizable) => this.isResizable = isResizable;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setResizeBorder(int resizeBorder) => this.resizeBorder = resizeBorder;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isDragging() => this.dragging;

    [Signature("(Larc/func/Prov<Larc/scene/Action;>;)V")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void setHideAction(Prov prov) => Dialog.defaultHideAction = prov;

    [Signature("(Larc/func/Prov<Larc/scene/Action;>;)V")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void setShowAction(Prov prov) => Dialog.defaultShowAction = prov;

    [LineNumberTable(new byte[] {160, 251, 99, 143, 109, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void setScene(Scene stage)
    {
      if (stage == null)
        this.addListener((EventListener) this.focusListener);
      else
        this.removeListener((EventListener) this.focusListener);
      base.setScene(stage);
    }

    [LineNumberTable(new byte[] {161, 15, 238, 71})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void hidden(Runnable run) => this.addListener((EventListener) new Dialog.\u0036(this, run));

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addCloseButton()
    {
    }

    [LineNumberTable(new byte[] {161, 30, 241, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void closeOnBack() => this.keyDown((Cons) new Dialog.__\u003C\u003EAnon2(this));

    [LineNumberTable(new byte[] {161, 73, 104, 136, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void toggle()
    {
      if (this.isShown())
        this.hide();
      else
        this.show();
    }

    [LineNumberTable(new byte[] {159, 135, 114, 111, 239, 73, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static Dialog()
    {
      Table.__\u003Cclinit\u003E();
      if (ByteCodeHelper.isAlreadyInited("arc.scene.ui.Dialog"))
        return;
      Dialog.defaultShowAction = (Prov) new Dialog.__\u003C\u003EAnon5();
      Dialog.defaultHideAction = (Prov) new Dialog.__\u003C\u003EAnon6();
      Dialog.tmpPosition = new Vec2();
      Dialog.tmpSize = new Vec2();
    }

    [Modifiers]
    public Table cont
    {
      [HideFromJava] get => this.__\u003C\u003Econt;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Econt = value;
    }

    [Modifiers]
    public Table buttons
    {
      [HideFromJava] get => this.__\u003C\u003Ebuttons;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Ebuttons = value;
    }

    [Modifiers]
    public Label title
    {
      [HideFromJava] get => this.__\u003C\u003Etitle;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Etitle = value;
    }

    [Modifiers]
    public Table titleTable
    {
      [HideFromJava] get => this.__\u003C\u003EtitleTable;
      [HideFromJava] [param: In] private set => this.__\u003C\u003EtitleTable = value;
    }

    [EnclosingMethod(null, null, null)]
    [SpecialName]
    internal new class \u0031 : InputListener
    {
      [Modifiers]
      internal Dialog this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(31)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0031([In] Dialog obj0)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector();
      }

      [LineNumberTable(new byte[] {159, 176, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override bool touchDown(
        [In] InputEvent obj0,
        [In] float obj1,
        [In] float obj2,
        [In] int obj3,
        [In] KeyCode obj4)
      {
        obj0.cancel();
        return false;
      }

      [HideFromJava]
      static \u0031() => InputListener.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "<init>", "(Ljava.lang.String;Larc.scene.ui.Dialog$DialogStyle;)V")]
    [SpecialName]
    internal new class \u0032 : InputListener
    {
      [Modifiers]
      internal Dialog this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(76)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0032([In] Dialog obj0)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector();
      }

      [LineNumberTable(new byte[] {29, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override bool touchDown(
        [In] InputEvent obj0,
        [In] float obj1,
        [In] float obj2,
        [In] int obj3,
        [In] KeyCode obj4)
      {
        this.this\u00240.toFront();
        return false;
      }

      [HideFromJava]
      static \u0032() => InputListener.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "<init>", "(Ljava.lang.String;Larc.scene.ui.Dialog$DialogStyle;)V")]
    [SpecialName]
    internal new class \u0033 : InputListener
    {
      internal float startX;
      internal float startY;
      internal float lastX;
      internal float lastY;
      [Modifiers]
      internal Dialog this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(83)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0033([In] Dialog obj0)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector();
      }

      [LineNumberTable(new byte[] {37, 116, 122, 123, 103, 108, 127, 41, 127, 7, 125, 127, 7, 118, 127, 7, 125, 159, 7, 127, 30, 109})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void updateEdge([In] float obj0, [In] float obj1)
      {
        float num1 = (float) this.this\u00240.resizeBorder / 2f;
        float width = this.this\u00240.getWidth();
        float height = this.this\u00240.getHeight();
        float marginTop = this.this\u00240.getMarginTop();
        float marginRight = this.this\u00240.getMarginRight();
        float num2 = width - marginRight;
        this.this\u00240.edge = 0;
        if (this.this\u00240.isResizable && (double) obj0 >= (double) (this.this\u00240.getMarginLeft() - num1) && ((double) obj0 <= (double) (num2 + num1) && (double) obj1 >= (double) (this.this\u00240.getMarginBottom() - num1)))
        {
          if ((double) obj0 < (double) (this.this\u00240.getMarginLeft() + num1))
            this.this\u00240.edge |= 8;
          if ((double) obj0 > (double) (num2 - num1))
            this.this\u00240.edge |= 16;
          if ((double) obj1 < (double) (this.this\u00240.getMarginBottom() + num1))
            this.this\u00240.edge |= 4;
          if (this.this\u00240.edge != 0)
            num1 += 25f;
          if ((double) obj0 < (double) (this.this\u00240.getMarginLeft() + num1))
            this.this\u00240.edge |= 8;
          if ((double) obj0 > (double) (num2 - num1))
            this.this\u00240.edge |= 16;
          if ((double) obj1 < (double) (this.this\u00240.getMarginBottom() + num1))
            this.this\u00240.edge |= 4;
        }
        if (!this.this\u00240.isMovable || this.this\u00240.edge != 0 || ((double) obj1 > (double) height || (double) obj1 < (double) (height - marginTop)) || ((double) obj0 < (double) this.this\u00240.getMarginLeft() || (double) obj0 > (double) num2))
          return;
        this.this\u00240.edge = 32;
      }

      [LineNumberTable(new byte[] {57, 110, 106, 124, 104, 104, 118, 150})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override bool touchDown(
        [In] InputEvent obj0,
        [In] float obj1,
        [In] float obj2,
        [In] int obj3,
        [In] KeyCode obj4)
      {
        if (object.ReferenceEquals((object) obj4, (object) KeyCode.__\u003C\u003EmouseLeft))
        {
          this.updateEdge(obj1, obj2);
          this.this\u00240.dragging = this.this\u00240.edge != 0;
          this.startX = obj1;
          this.startY = obj2;
          this.lastX = obj1 - this.this\u00240.getWidth();
          this.lastY = obj2 - this.this\u00240.getHeight();
        }
        return this.this\u00240.edge != 0 || this.this\u00240.isModal;
      }

      [LineNumberTable(new byte[] {70, 108})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void touchUp(
        [In] InputEvent obj0,
        [In] float obj1,
        [In] float obj2,
        [In] int obj3,
        [In] KeyCode obj4)
      {
        this.this\u00240.dragging = false;
      }

      [LineNumberTable(new byte[] {75, 110, 122, 152, 110, 110, 109, 159, 13, 112, 120, 102, 134, 111, 108, 113, 116, 102, 134, 111, 108, 113, 116, 102, 134, 115, 111, 112, 118, 112, 134, 114, 111, 112, 118, 112, 134, 127, 8})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void touchDragged([In] InputEvent obj0, [In] float obj1, [In] float obj2, [In] int obj3)
      {
        if (!this.this\u00240.dragging)
          return;
        float width = this.this\u00240.getWidth();
        float height = this.this\u00240.getHeight();
        float x = this.this\u00240.x;
        float y = this.this\u00240.y;
        float minWidth = this.this\u00240.getMinWidth();
        float minHeight = this.this\u00240.getMinHeight();
        Scene scene = this.this\u00240.getScene();
        int num1 = !this.this\u00240.keepWithinStage || !object.ReferenceEquals((object) this.this\u00240.parent, (object) scene.__\u003C\u003Eroot) ? 0 : 1;
        if ((this.this\u00240.edge & 32) != 0)
        {
          float num2 = obj1 - this.startX;
          float num3 = obj2 - this.startY;
          x += num2;
          y += num3;
        }
        if ((this.this\u00240.edge & 8) != 0)
        {
          float num2 = obj1 - this.startX;
          if ((double) (width - num2) < (double) minWidth)
            num2 = -(minWidth - width);
          if (num1 != 0 && (double) (x + num2) < 0.0)
            num2 = -x;
          width -= num2;
          x += num2;
        }
        if ((this.this\u00240.edge & 4) != 0)
        {
          float num2 = obj2 - this.startY;
          if ((double) (height - num2) < (double) minHeight)
            num2 = -(minHeight - height);
          if (num1 != 0 && (double) (y + num2) < 0.0)
            num2 = -y;
          height -= num2;
          y += num2;
        }
        if ((this.this\u00240.edge & 16) != 0)
        {
          float num2 = obj1 - this.lastX - width;
          if ((double) (width + num2) < (double) minWidth)
            num2 = minWidth - width;
          if (num1 != 0 && (double) (x + width + num2) > (double) scene.getWidth())
            num2 = scene.getWidth() - x - width;
          width += num2;
        }
        if ((this.this\u00240.edge & 2) != 0)
        {
          float num2 = obj2 - this.lastY - height;
          if ((double) (height + num2) < (double) minHeight)
            num2 = minHeight - height;
          if (num1 != 0 && (double) (y + height + num2) > (double) scene.getHeight())
            num2 = scene.getHeight() - y - height;
          height += num2;
        }
        this.this\u00240.setBounds((float) Math.round(x), (float) Math.round(y), (float) Math.round(width), (float) Math.round(height));
      }

      [LineNumberTable(new byte[] {122, 106})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override bool mouseMoved([In] InputEvent obj0, [In] float obj1, [In] float obj2)
      {
        this.updateEdge(obj1, obj2);
        return this.this\u00240.isModal;
      }

      [LineNumberTable(178)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override bool scrolled(
        [In] InputEvent obj0,
        [In] float obj1,
        [In] float obj2,
        [In] float obj3,
        [In] float obj4)
      {
        return this.this\u00240.isModal;
      }

      [LineNumberTable(183)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override bool keyDown([In] InputEvent obj0, [In] KeyCode obj1) => this.this\u00240.isModal;

      [LineNumberTable(188)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override bool keyUp([In] InputEvent obj0, [In] KeyCode obj1) => this.this\u00240.isModal;

      [LineNumberTable(193)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override bool keyTyped([In] InputEvent obj0, [In] char obj1) => this.this\u00240.isModal;

      [HideFromJava]
      static \u0033() => InputListener.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "<init>", "(Ljava.lang.String;Larc.scene.ui.Dialog$DialogStyle;)V")]
    [SpecialName]
    internal new class \u0034 : FocusListener
    {
      [Modifiers]
      internal Dialog this\u00240;

      [LineNumberTable(207)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0034([In] Dialog obj0)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector();
      }

      [LineNumberTable(new byte[] {160, 105, 108, 127, 19, 119, 103, 125, 122, 134})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void focusChanged([In] FocusListener.FocusEvent obj0)
      {
        Scene scene = this.this\u00240.getScene();
        if (!this.this\u00240.isModal || scene == null || (scene.__\u003C\u003Eroot.getChildren().size <= 0 || !object.ReferenceEquals(scene.__\u003C\u003Eroot.getChildren().peek(), (object) this.this\u00240)))
          return;
        Element relatedActor = obj0.relatedActor;
        if (relatedActor == null || relatedActor.isDescendantOf((Element) this.this\u00240) || (Object.instancehelper_equals((object) relatedActor, (object) this.this\u00240.previousKeyboardFocus) || Object.instancehelper_equals((object) relatedActor, (object) this.this\u00240.previousScrollFocus)))
          return;
        obj0.cancel();
      }

      [LineNumberTable(new byte[] {159, 90, 130, 106})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void keyboardFocusChanged(
        [In] FocusListener.FocusEvent obj0,
        [In] Element obj1,
        [In] bool obj2)
      {
        if (obj2)
          return;
        this.focusChanged(obj0);
      }

      [LineNumberTable(new byte[] {159, 89, 162, 106})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void scrollFocusChanged(
        [In] FocusListener.FocusEvent obj0,
        [In] Element obj1,
        [In] bool obj2)
      {
        if (obj2)
          return;
        this.focusChanged(obj0);
      }
    }

    [EnclosingMethod(null, "shown", "(Ljava.lang.Runnable;)V")]
    [SpecialName]
    internal new class \u0035 : VisibilityListener
    {
      [Modifiers]
      internal Runnable val\u0024run;
      [Modifiers]
      internal Dialog this\u00240;

      [LineNumberTable(374)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0035([In] Dialog obj0, [In] Runnable obj1)
      {
        this.this\u00240 = obj0;
        this.val\u0024run = obj1;
        // ISSUE: explicit constructor call
        base.\u002Ector();
      }

      [LineNumberTable(new byte[] {161, 7, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override bool shown()
      {
        this.val\u0024run.run();
        return false;
      }
    }

    [EnclosingMethod(null, "hidden", "(Ljava.lang.Runnable;)V")]
    [SpecialName]
    internal new class \u0036 : VisibilityListener
    {
      [Modifiers]
      internal Runnable val\u0024run;
      [Modifiers]
      internal Dialog this\u00240;

      [LineNumberTable(385)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0036([In] Dialog obj0, [In] Runnable obj1)
      {
        this.this\u00240 = obj0;
        this.val\u0024run = obj1;
        // ISSUE: explicit constructor call
        base.\u002Ector();
      }

      [LineNumberTable(new byte[] {161, 18, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override bool hidden()
      {
        this.val\u0024run.run();
        return false;
      }
    }

    public class DialogStyle : Style
    {
      public Drawable background;
      public Font titleFont;
      public Color titleFontColor;
      public Drawable stageBackground;

      [LineNumberTable(new byte[] {161, 128, 232, 69})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public DialogStyle()
      {
        Dialog.DialogStyle dialogStyle = this;
        this.titleFontColor = new Color(1f, 1f, 1f, 1f);
      }
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon0 : Runnable
    {
      private readonly Dialog arg\u00241;

      internal __\u003C\u003EAnon0([In] Dialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.updateScrollFocus();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon1 : Runnable
    {
      private readonly Dialog arg\u00241;
      private readonly bool[] arg\u00242;

      internal __\u003C\u003EAnon1([In] Dialog obj0, [In] bool[] obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => this.arg\u00241.lambda\u0024updateScrollFocus\u00243(this.arg\u00242);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon2 : Cons
    {
      private readonly Dialog arg\u00241;

      internal __\u003C\u003EAnon2([In] Dialog obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024closeOnBack\u00244((KeyCode) obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon3 : Runnable
    {
      private readonly Dialog arg\u00241;

      internal __\u003C\u003EAnon3([In] Dialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.hide();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon4 : Cons
    {
      private readonly bool[] arg\u00241;

      internal __\u003C\u003EAnon4([In] bool[] obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => Dialog.lambda\u0024updateScrollFocus\u00242(this.arg\u00241, (Element) obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon5 : Prov
    {
      internal __\u003C\u003EAnon5()
      {
      }

      public object get() => (object) Dialog.lambda\u0024static\u00240();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon6 : Prov
    {
      internal __\u003C\u003EAnon6()
      {
      }

      public object get() => (object) Dialog.lambda\u0024static\u00241();
    }
  }
}
