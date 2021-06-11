// Decompiled with JetBrains decompiler
// Type: mindustry.logic.LCanvas
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.@struct;
using arc.func;
using arc.graphics;
using arc.graphics.g2d;
using arc.input;
using arc.math;
using arc.math.geom;
using arc.scene;
using arc.scene.@event;
using arc.scene.style;
using arc.scene.ui;
using arc.scene.ui.layout;
using arc.util;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.util;
using mindustry.gen;
using mindustry.graphics;
using mindustry.ui;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.logic
{
  public class LCanvas : Table
  {
    public const int maxJumpsDrawn = 100;
    internal static LCanvas canvas;
    public LCanvas.DragLayout statements;
    public ScrollPane pane;
    public Group jumps;
    internal LCanvas.StatementElem dragging;
    internal LCanvas.StatementElem hovered;
    internal float targetWidth;
    internal int jumpCount;
    [Signature("Larc/struct/Seq<Larc/scene/ui/Tooltip;>;")]
    internal Seq tooltips;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {49, 121, 124, 146, 134, 108, 139, 242, 70, 148, 172, 246, 69, 99, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void rebuild()
    {
      this.targetWidth = !LCanvas.useRows() ? 900f : 400f;
      float num = this.pane == null ? 0.0f : this.pane.getScrollPercentY();
      string asm = this.statements == null ? (string) null : this.save();
      this.clear();
      this.statements = new LCanvas.DragLayout(this);
      this.jumps = (Group) new WidgetGroup();
      this.pane = (ScrollPane) this.pane((Cons) new LCanvas.__\u003C\u003EAnon1(this)).grow().get();
      this.pane.setFlickScroll(false);
      Core.app.post((Runnable) new LCanvas.__\u003C\u003EAnon2(this, num));
      if (asm == null)
        return;
      this.load(asm);
    }

    [Signature("(Larc/scene/ui/layout/Cell<*>;Ljava/lang/String;)V")]
    [LineNumberTable(new byte[] {12, 127, 25, 127, 0, 183, 103, 255, 11, 79, 206})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void tooltip(Cell cell, string key)
    {
      string lowerCase = String.instancehelper_toLowerCase(key);
      object obj1 = (object) "";
      object obj2 = (object) " ";
      CharSequence charSequence1;
      charSequence1.__\u003Cref\u003E = (__Null) obj2;
      CharSequence charSequence2 = charSequence1;
      object obj3 = obj1;
      charSequence1.__\u003Cref\u003E = (__Null) obj3;
      CharSequence charSequence3 = charSequence1;
      string key1 = String.instancehelper_replace(lowerCase, charSequence2, charSequence3);
      if (!Core.settings.getBool("logichints", true) || !Core.bundle.has(key1))
        return;
      Tooltip.__\u003Cclinit\u003E();
      Tooltip tooltip = new Tooltip((Cons) new LCanvas.__\u003C\u003EAnon0(key1));
      if (Vars.mobile)
        cell.get().addListener((EventListener) new LCanvas.\u0032(20f, 0.4f, 0.43f, 0.15f, tooltip, cell));
      else
        cell.get().addListener((EventListener) tooltip);
    }

    [LineNumberTable(58)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool useRows() => (double) Core.graphics.getWidth() < (double) (Scl.scl(900f) * 1.2f);

    [LineNumberTable(new byte[] {90, 127, 1, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string save()
    {
      Seq statements = this.statements.getChildren().@as().map((Func) new LCanvas.__\u003C\u003EAnon3());
      statements.each((Cons) new LCanvas.__\u003C\u003EAnon4());
      return LAssembler.write(statements);
    }

    [LineNumberTable(new byte[] {97, 139, 103, 107, 107, 123, 103, 130, 123, 102, 130, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void load(string asm)
    {
      this.jumps.clear();
      Seq seq = LAssembler.read(asm);
      seq.truncate(1000);
      this.statements.clearChildren();
      Iterator iterator1 = seq.iterator();
      while (iterator1.hasNext())
        this.add((LStatement) iterator1.next());
      Iterator iterator2 = seq.iterator();
      while (iterator2.hasNext())
        ((LStatement) iterator2.next()).setupUI();
      this.statements.layout();
    }

    [LineNumberTable(new byte[] {86, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void add(LStatement statement) => this.statements.addChild((Element) new LCanvas.StatementElem(this, statement));

    [LineNumberTable(new byte[] {114, 127, 3, 99, 107, 169, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual LCanvas.StatementElem checkHovered()
    {
      Element actor = Core.scene.hit((float) Core.input.mouseX(), (float) Core.input.mouseY(), true);
      if (actor != null)
      {
        while (actor != null && !(actor is LCanvas.StatementElem))
          actor = (Element) actor.parent;
      }
      return actor == null || this.isDescendantOf(actor) ? (LCanvas.StatementElem) null : (LCanvas.StatementElem) actor;
    }

    [Modifiers]
    [LineNumberTable(64)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024tooltip\u00240([In] string obj0, [In] Table obj1)
    {
      Table table = obj1.background(Styles.black8).margin(4f);
      object obj = (object) new StringBuilder().append("[lightgray]").append(Core.bundle.get(obj0)).toString();
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj;
      CharSequence text = charSequence;
      table.add(text).style((Style) Styles.outlineLabel);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {59, 103, 127, 8, 140, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024rebuild\u00241([In] Table obj0)
    {
      obj0.center();
      obj0.add((Element) this.statements).pad(2f).center().width(this.targetWidth);
      obj0.addChild((Element) this.jumps);
      this.jumps.cullable = false;
    }

    [Modifiers]
    [LineNumberTable(new byte[] {70, 109, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024rebuild\u00242([In] float obj0)
    {
      this.pane.setScrollPercentY(obj0);
      this.pane.updateVisualScroll();
    }

    [Modifiers]
    [LineNumberTable(140)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static LStatement lambda\u0024save\u00243([In] LCanvas.StatementElem obj0) => obj0.st;

    [LineNumberTable(new byte[] {159, 177, 232, 61, 103, 171, 134, 241, 79, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public LCanvas()
    {
      LCanvas lcanvas = this;
      this.jumpCount = 0;
      this.tooltips = new Seq();
      LCanvas.canvas = this;
      Core.scene.addListener((EventListener) new LCanvas.\u0031(this));
      this.rebuild();
    }

    [Signature("(Larc/scene/ui/layout/Cell<*>;Ljava/lang/Enum<*>;)V")]
    [LineNumberTable(new byte[] {40, 127, 27, 109, 137, 159, 6})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void tooltip(Cell cell, Enum key)
    {
      string key1 = new StringBuilder().append(String.instancehelper_toLowerCase(Object.instancehelper_getClass((object) key).getSimpleName())).append(".").append(String.instancehelper_toLowerCase(key.name())).toString();
      if (Core.bundle.has(key1))
        LCanvas.tooltip(cell, key1);
      else
        LCanvas.tooltip(cell, new StringBuilder().append("lenum.").append(key.name()).toString());
    }

    [LineNumberTable(new byte[] {81, 103, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void draw()
    {
      this.jumpCount = 0;
      base.draw();
    }

    [LineNumberTable(new byte[] {126, 136, 140, 111, 108, 126, 110, 123, 191, 9})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void act(float delta)
    {
      base.act(delta);
      this.hovered = this.checkHovered();
      if (!Core.input.isTouched())
        return;
      float num1 = (float) Core.input.mouseY();
      if ((double) Math.min(num1 - this.y, (float) Core.graphics.getHeight() - num1) >= (double) Scl.scl(100f))
        return;
      int num2 = Mathf.sign((float) Core.graphics.getHeight() / 2f - num1);
      this.pane.setScrollY(this.pane.getScrollY() + (float) num2 * Scl.scl(15f));
    }

    [HideFromJava]
    static LCanvas() => Table.__\u003Cclinit\u003E();

    [EnclosingMethod(null, "<init>", "()V")]
    [SpecialName]
    internal new class \u0031 : InputListener
    {
      [Modifiers]
      internal LCanvas this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [Modifiers]
      [LineNumberTable(new byte[] {159, 188, 122, 113})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024touchDown\u00240()
      {
        this.this\u00240.tooltips.each((Cons) new LCanvas.\u0031.__\u003C\u003EAnon1());
        this.this\u00240.tooltips.clear();
      }

      [LineNumberTable(38)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0031([In] LCanvas obj0)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector();
      }

      [LineNumberTable(new byte[] {159, 184, 127, 6, 107, 98, 213})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override bool touchDown(
        [In] InputEvent obj0,
        [In] float obj1,
        [In] float obj2,
        [In] int obj3,
        [In] KeyCode obj4)
      {
        Iterator iterator = this.this\u00240.tooltips.iterator();
        while (iterator.hasNext())
          ((Tooltip) iterator.next()).__\u003C\u003Econtainer.toFront();
        Core.app.post((Runnable) new LCanvas.\u0031.__\u003C\u003EAnon0(this));
        return base.touchDown(obj0, obj1, obj2, obj3, obj4);
      }

      [HideFromJava]
      static \u0031() => InputListener.__\u003Cclinit\u003E();

      [SpecialName]
      private sealed class __\u003C\u003EAnon0 : Runnable
      {
        private readonly LCanvas.\u0031 arg\u00241;

        internal __\u003C\u003EAnon0([In] LCanvas.\u0031 obj0) => this.arg\u00241 = obj0;

        public void run() => this.arg\u00241.lambda\u0024touchDown\u00240();
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon1 : Cons
      {
        internal __\u003C\u003EAnon1()
        {
        }

        public void get([In] object obj0) => ((Tooltip) obj0).hide();
      }
    }

    [InnerClass]
    [EnclosingMethod(null, "tooltip", "(Larc.scene.ui.layout.Cell;Ljava.lang.String;)V")]
    [SpecialName]
    internal new class \u0032 : ElementGestureListener
    {
      [Modifiers]
      internal Tooltip val\u0024tip;
      [Modifiers]
      internal Cell val\u0024cell;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(68)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0032([In] float obj0, [In] float obj1, [In] float obj2, [In] float obj3, [In] Tooltip obj4, [In] Cell obj5)
      {
        this.val\u0024tip = obj4;
        this.val\u0024cell = obj5;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj0, obj1, obj2, obj3);
      }

      [LineNumberTable(new byte[] {21, 112, 149, 127, 11, 127, 0, 134, 98})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override bool longPress([In] Element obj0, [In] float obj1, [In] float obj2)
      {
        this.val\u0024tip.show(obj0, obj1, obj2);
        LCanvas.canvas.tooltips.add((object) this.val\u0024tip);
        Iterator iterator = this.val\u0024cell.get().getListeners().iterator();
        while (iterator.hasNext())
        {
          EventListener eventListener = (EventListener) iterator.next();
          ClickListener clickListener;
          if (eventListener is ClickListener && object.ReferenceEquals((object) (clickListener = (ClickListener) eventListener), (object) (ClickListener) eventListener))
            clickListener.cancel();
        }
        return true;
      }

      [HideFromJava]
      static \u0032() => ElementGestureListener.__\u003Cclinit\u003E();
    }

    public class DragLayout : WidgetGroup
    {
      internal float space;
      internal float prefWidth;
      internal float prefHeight;
      [Signature("Larc/struct/Seq<Larc/scene/Element;>;")]
      internal Seq seq;
      internal int insertPosition;
      internal bool invalidated;
      [Modifiers]
      internal LCanvas this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {160, 76, 111, 113, 107, 199, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public DragLayout(LCanvas _param1)
      {
        this.this\u00240 = _param1;
        // ISSUE: explicit constructor call
        base.\u002Ector();
        LCanvas.DragLayout dragLayout = this;
        this.space = Scl.scl(10f);
        this.seq = new Seq();
        this.insertPosition = 0;
        this.setTransform(true);
      }

      [LineNumberTable(new byte[] {160, 88, 103, 102, 140, 152, 114, 191, 3, 115, 179, 150, 117, 151, 116, 237, 54, 233, 78, 144, 159, 12, 135, 117, 148, 127, 26, 106, 226, 59, 235, 73, 187, 119, 63, 2, 232, 69, 134, 117, 145})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void layout()
      {
        this.invalidated = true;
        float num1 = 0.0f;
        this.seq.clear();
        float num2 = this.getChildren().sumf((Floatf) new LCanvas.DragLayout.__\u003C\u003EAnon0(this));
        LCanvas.DragLayout dragLayout1 = this;
        float num3 = num2;
        double num4 = (double) num3;
        this.prefHeight = num3;
        this.height = (float) num4;
        LCanvas.DragLayout dragLayout2 = this;
        float num5 = Scl.scl(this.this\u00240.targetWidth);
        double num6 = (double) num5;
        this.prefWidth = num5;
        this.width = (float) num6;
        for (int index = 0; index < this.getChildren().size; ++index)
        {
          Element element = (Element) this.getChildren().get(index);
          if (!object.ReferenceEquals((object) this.this\u00240.dragging, (object) element))
          {
            element.setSize(this.width, element.getPrefHeight());
            element.setPosition(0.0f, this.height - num1, 10);
            num1 += element.getPrefHeight() + this.space;
            this.seq.add((object) element);
          }
        }
        if (this.this\u00240.dragging != null)
        {
          float num7 = this.this\u00240.dragging.getY(2) + this.this\u00240.dragging.translation.y;
          this.insertPosition = 0;
          for (int index = 0; index < this.seq.size; ++index)
          {
            Element element = (Element) this.seq.get(index);
            if ((double) num7 < (double) element.y && (index == this.seq.size - 1 || (double) num7 > (double) ((Element) this.seq.get(index + 1)).y))
            {
              this.insertPosition = index + 1;
              break;
            }
          }
          float num8 = this.this\u00240.dragging.getHeight() + this.space;
          for (int insertPosition = this.insertPosition; insertPosition < this.seq.size; ++insertPosition)
            ((Element) this.seq.get(insertPosition)).y -= num8;
        }
        this.invalidateHierarchy();
        if (this.parent == null || !(this.parent is Table))
          return;
        this.setCullingArea(this.parent.getCullingArea());
      }

      [Modifiers]
      [LineNumberTable(206)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private float lambda\u0024layout\u00240([In] Element obj0) => obj0.getHeight() + this.space;

      [Modifiers]
      [LineNumberTable(280)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static void lambda\u0024draw\u00241([In] Element obj0) => obj0.cullable = false;

      [Modifiers]
      [LineNumberTable(286)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static void lambda\u0024draw\u00242([In] Element obj0) => obj0.cullable = true;

      [MethodImpl(MethodImplOptions.NoInlining)]
      public override float getPrefWidth() => this.prefWidth;

      [MethodImpl(MethodImplOptions.NoInlining)]
      public override float getPrefHeight() => this.prefHeight;

      [LineNumberTable(new byte[] {160, 154, 171, 127, 7, 114, 103, 159, 39, 191, 7, 104, 181, 134, 104, 117, 135})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void draw()
      {
        Draw.alpha(this.parentAlpha);
        if (this.this\u00240.dragging != null && this.insertPosition <= this.seq.size)
        {
          float height = this.this\u00240.dragging.getHeight();
          float x = this.x;
          float num = this.insertPosition != 0 ? ((Element) this.seq.get(this.insertPosition - 1)).y + this.y - this.space : this.height + this.y;
          Tex.pane.draw(x, num - height, this.width, this.this\u00240.dragging.getHeight());
        }
        if (this.invalidated)
          this.__\u003C\u003Echildren.each((Cons) new LCanvas.DragLayout.__\u003C\u003EAnon1());
        base.draw();
        if (!this.invalidated)
          return;
        this.__\u003C\u003Echildren.each((Cons) new LCanvas.DragLayout.__\u003C\u003EAnon2());
        this.invalidated = false;
      }

      [LineNumberTable(new byte[] {160, 178, 144, 127, 1, 112, 98, 166, 123, 55, 198, 145, 117, 55, 198, 172, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal virtual void finishLayout()
      {
        if (this.this\u00240.dragging != null)
        {
          Iterator iterator = this.getChildren().iterator();
          while (iterator.hasNext())
            ((Element) iterator.next()).setTranslation(0.0f, 0.0f);
          this.clearChildren();
          for (int index = 0; index <= this.insertPosition - 1 && index < this.seq.size; ++index)
            this.addChild((Element) this.seq.get(index));
          this.addChild((Element) this.this\u00240.dragging);
          for (int insertPosition = this.insertPosition; insertPosition < this.seq.size; ++insertPosition)
            this.addChild((Element) this.seq.get(insertPosition));
          this.this\u00240.dragging = (LCanvas.StatementElem) null;
        }
        this.layout();
      }

      [HideFromJava]
      static DragLayout() => WidgetGroup.__\u003Cclinit\u003E();

      [SpecialName]
      private new sealed class __\u003C\u003EAnon0 : Floatf
      {
        private readonly LCanvas.DragLayout arg\u00241;

        internal __\u003C\u003EAnon0([In] LCanvas.DragLayout obj0) => this.arg\u00241 = obj0;

        public float get([In] object obj0) => this.arg\u00241.lambda\u0024layout\u00240((Element) obj0);
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon1 : Cons
      {
        internal __\u003C\u003EAnon1()
        {
        }

        public void get([In] object obj0) => LCanvas.DragLayout.lambda\u0024draw\u00241((Element) obj0);
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon2 : Cons
      {
        internal __\u003C\u003EAnon2()
        {
        }

        public void get([In] object obj0) => LCanvas.DragLayout.lambda\u0024draw\u00242((Element) obj0);
      }
    }

    public class JumpButton : ImageButton
    {
      internal Color hoverColor;
      internal Color defaultColor;
      [Signature("Larc/func/Prov<Lmindustry/logic/LCanvas$StatementElem;>;")]
      internal Prov to;
      internal bool selecting;
      internal float mx;
      internal float my;
      internal ClickListener listener;
      public LCanvas.JumpCurve curve;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [Modifiers]
      [LineNumberTable(new byte[] {161, 100, 127, 5, 167, 127, 2, 113})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024new\u00240([In] Cons obj0)
      {
        if (this.to.get() != null && ((Element) this.to.get()).parent == null)
          obj0.get((object) null);
        this.setColor(!this.listener.isOver() ? this.defaultColor : this.hoverColor);
        this.getStyle().imageUpColor = this.__\u003C\u003Ecolor;
      }

      [Signature("(Larc/func/Prov<Lmindustry/logic/LCanvas$StatementElem;>;Larc/func/Cons<Lmindustry/logic/LCanvas$StatementElem;>;)V")]
      [LineNumberTable(new byte[] {161, 64, 242, 54, 107, 235, 75, 103, 151, 238, 94, 243, 73, 108})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public JumpButton(Prov getter, Cons setter)
        : base((Drawable) Tex.logicNode, Styles.colori)
      {
        LCanvas.JumpButton jumpButton1 = this;
        this.hoverColor = Pal.place;
        this.defaultColor = Color.__\u003C\u003Ewhite;
        this.to = getter;
        LCanvas.JumpButton jumpButton2 = this;
        ClickListener clickListener1 = new ClickListener();
        ClickListener clickListener2 = clickListener1;
        this.listener = clickListener1;
        this.addListener((EventListener) clickListener2);
        this.addListener((EventListener) new LCanvas.JumpButton.\u0031(this, setter));
        this.update((Runnable) new LCanvas.JumpButton.__\u003C\u003EAnon0(this, setter));
        this.curve = new LCanvas.JumpCurve(this);
      }

      [LineNumberTable(new byte[] {161, 113, 135, 99, 142, 149})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      protected internal override void setScene(Scene stage)
      {
        base.setScene(stage);
        if (stage == null)
          this.curve.remove();
        else
          LCanvas.canvas.jumps.addChild((Element) this.curve);
      }

      [HideFromJava]
      static JumpButton() => ImageButton.__\u003Cclinit\u003E();

      [EnclosingMethod(null, "<init>", "(Larc.func.Prov;Larc.func.Cons;)V")]
      [SpecialName]
      internal new class \u0031 : InputListener
      {
        [Modifiers]
        internal Cons val\u0024setter;
        [Modifiers]
        internal LCanvas.JumpButton this\u00240;

        [SpecialName]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public new static void __\u003Cclinit\u003E()
        {
        }

        [LineNumberTable(439)]
        [MethodImpl(MethodImplOptions.NoInlining)]
        internal \u0031([In] LCanvas.JumpButton obj0, [In] Cons obj1)
        {
          this.this\u00240 = obj0;
          this.val\u0024setter = obj1;
          // ISSUE: explicit constructor call
          base.\u002Ector();
        }

        [LineNumberTable(new byte[] {161, 72, 108, 108, 109, 109})]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public override bool touchDown(
          [In] InputEvent obj0,
          [In] float obj1,
          [In] float obj2,
          [In] int obj3,
          [In] KeyCode obj4)
        {
          this.this\u00240.selecting = true;
          this.val\u0024setter.get((object) null);
          this.this\u00240.mx = obj1;
          this.this\u00240.my = obj2;
          return true;
        }

        [LineNumberTable(new byte[] {161, 81, 109, 109})]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public override void touchDragged([In] InputEvent obj0, [In] float obj1, [In] float obj2, [In] int obj3)
        {
          this.this\u00240.mx = obj1;
          this.this\u00240.my = obj2;
        }

        [LineNumberTable(new byte[] {161, 87, 122, 139, 113, 142, 140, 108})]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public override void touchUp(
          [In] InputEvent obj0,
          [In] float obj1,
          [In] float obj2,
          [In] int obj3,
          [In] KeyCode obj4)
        {
          this.this\u00240.localToStageCoordinates(Tmp.__\u003C\u003Ev1.set(obj1, obj2));
          LCanvas.StatementElem hovered = LCanvas.canvas.hovered;
          if (hovered != null && !this.this\u00240.isDescendantOf((Element) hovered))
            this.val\u0024setter.get((object) hovered);
          else
            this.val\u0024setter.get((object) null);
          this.this\u00240.selecting = false;
        }

        [HideFromJava]
        static \u0031() => InputListener.__\u003Cclinit\u003E();
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon0 : Runnable
      {
        private readonly LCanvas.JumpButton arg\u00241;
        private readonly Cons arg\u00242;

        internal __\u003C\u003EAnon0([In] LCanvas.JumpButton obj0, [In] Cons obj1)
        {
          this.arg\u00241 = obj0;
          this.arg\u00242 = obj1;
        }

        public void run() => this.arg\u00241.lambda\u0024new\u00240(this.arg\u00242);
      }
    }

    public class JumpCurve : Element
    {
      public LCanvas.JumpButton button;

      [LineNumberTable(new byte[] {161, 126, 104, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public JumpCurve(LCanvas.JumpButton button)
      {
        LCanvas.JumpCurve jumpCurve = this;
        this.button = button;
      }

      [LineNumberTable(new byte[] {161, 180, 117, 139, 230, 81, 255, 4, 69, 247, 59, 229, 70})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void drawCurve(float x, float y, float x2, float y2)
      {
        Lines.stroke(4f, this.button.__\u003C\u003Ecolor);
        Draw.alpha(this.parentAlpha);
        float num = 100f;
        Lines.curve(x, y, x + num, y, x2 + num, y2, x2, y2, Math.max(18, ByteCodeHelper.f2i(Mathf.dst(x, y, x2, y2) / 6f)));
      }

      [LineNumberTable(new byte[] {161, 132, 136, 114, 134})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void act(float delta)
      {
        base.act(delta);
        if (!this.button.listener.isOver())
          return;
        this.toFront();
      }

      [LineNumberTable(new byte[] {161, 141, 146, 127, 14, 161, 127, 34, 98, 140, 140, 158, 99, 159, 5, 100, 109, 127, 4, 162, 159, 5, 112, 144, 102, 159, 41, 110, 112, 127, 18, 133})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void draw()
      {
        ++LCanvas.canvas.jumpCount;
        if (LCanvas.canvas.jumpCount > 100 && !this.button.selecting && !this.button.listener.isOver())
          return;
        Element element = this.button.to.get() != null || !this.button.selecting ? (Element) this.button.to.get() : (Element) LCanvas.canvas.hovered;
        int num1 = 0;
        Vec2 v1 = Tmp.__\u003C\u003Ev1;
        Vec2 v2 = Tmp.__\u003C\u003Ev2;
        ScrollPane pane = LCanvas.canvas.pane;
        this.button.localToAscendantCoordinates((Element) pane, v2.set(0.0f, 0.0f));
        if (element != null)
        {
          element.localToAscendantCoordinates((Element) pane, v1.set(element.getWidth(), element.getHeight() / 2f));
          num1 = 1;
        }
        else if (this.button.selecting)
        {
          v1.set(v2).add(this.button.mx, this.button.my);
          num1 = 1;
        }
        float num2 = LCanvas.canvas.pane.getVisualScrollY() - LCanvas.canvas.pane.getMaxY();
        v1.y += num2;
        v2.y += num2;
        if (num1 == 0)
          return;
        this.drawCurve(v2.x + this.button.getWidth() / 2f, v2.y + this.button.getHeight() / 2f, v1.x, v1.y);
        float width = this.button.getWidth();
        Draw.color(this.button.__\u003C\u003Ecolor);
        Tex.logicNode.draw(v1.x + width * 0.75f, v1.y - width / 2f, -width, width);
        Draw.reset();
      }
    }

    public class StatementElem : Table
    {
      public LStatement st;
      [Modifiers]
      internal LCanvas this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {160, 206, 111, 103, 135, 108, 108, 108, 139, 247, 119, 144, 135, 247, 69, 154, 108})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public StatementElem(LCanvas _param1, LStatement st)
      {
        this.this\u00240 = _param1;
        // ISSUE: explicit constructor call
        base.\u002Ector();
        LCanvas.StatementElem statementElem = this;
        this.st = st;
        st.elem = this;
        this.background((Drawable) Tex.whitePane);
        this.setColor(st.color());
        this.margin(0.0f);
        this.touchable = Touchable.__\u003C\u003Eenabled;
        this.table((Drawable) Tex.whiteui, (Cons) new LCanvas.StatementElem.__\u003C\u003EAnon0(this, st)).growX().height(38f);
        this.row();
        this.table((Cons) new LCanvas.StatementElem.__\u003C\u003EAnon1(this, st)).pad(4f).padTop(2f).left().grow();
        this.marginBottom(7f);
      }

      [LineNumberTable(new byte[] {161, 29, 108, 99, 141, 114, 112, 103, 134})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void copy()
      {
        LStatement st = this.st.copy();
        if (st == null)
          return;
        LCanvas.StatementElem statementElem = new LCanvas.StatementElem(this.this\u00240, st);
        this.this\u00240.statements.addChildAfter((Element) this, (Element) statementElem);
        this.this\u00240.statements.layout();
        st.elem = statementElem;
        st.setupUI();
      }

      [Modifiers]
      [LineNumberTable(new byte[] {160, 216, 114, 140, 108, 139, 127, 29, 140, 127, 0, 159, 10, 223, 1, 134, 237, 100})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024new\u00242([In] LStatement obj0, [In] Table obj1)
      {
        obj1.__\u003C\u003Ecolor.set(this.__\u003C\u003Ecolor);
        obj1.addListener((EventListener) new HandCursorListener());
        obj1.margin(6f);
        obj1.touchable = Touchable.__\u003C\u003Eenabled;
        Table table = obj1;
        object obj = (object) obj0.name();
        CharSequence charSequence;
        charSequence.__\u003Cref\u003E = (__Null) obj;
        CharSequence text = charSequence;
        table.add(text).style((Style) Styles.outlineLabel).color(this.__\u003C\u003Ecolor).padRight(8f);
        obj1.add().growX();
        obj1.button((Drawable) Icon.copy, Styles.logici, (Runnable) new LCanvas.StatementElem.__\u003C\u003EAnon2()).size(24f).padRight(6f).get().tapped((Runnable) new LCanvas.StatementElem.__\u003C\u003EAnon3(this));
        obj1.button((Drawable) Icon.cancel, Styles.logici, (Runnable) new LCanvas.StatementElem.__\u003C\u003EAnon4(this)).size(24f);
        obj1.addListener((EventListener) new LCanvas.StatementElem.\u0031(this));
      }

      [Modifiers]
      [LineNumberTable(new byte[] {161, 19, 103, 108, 108, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024new\u00243([In] LStatement obj0, [In] Table obj1)
      {
        obj1.left();
        obj1.marginLeft(4f);
        obj1.setColor(this.__\u003C\u003Ecolor);
        obj0.build(obj1);
      }

      [Modifiers]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static void lambda\u0024new\u00240()
      {
      }

      [Modifiers]
      [LineNumberTable(new byte[] {160, 229, 103, 108, 112})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024new\u00241()
      {
        this.remove();
        this.this\u00240.dragging = (LCanvas.StatementElem) null;
        this.this\u00240.statements.layout();
      }

      [LineNumberTable(new byte[] {161, 42, 102, 159, 52, 127, 2, 125, 133, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void draw()
      {
        float num = 5f;
        Fill.dropShadow(this.x + this.width / 2f, this.y + this.height / 2f, this.width + num, this.height + num, 10f, 0.9f * this.parentAlpha);
        Draw.color(0.0f, 0.0f, 0.0f, 0.3f * this.parentAlpha);
        Fill.crect(this.x, this.y, this.width, this.height);
        Draw.reset();
        base.draw();
      }

      [HideFromJava]
      static StatementElem() => Table.__\u003Cclinit\u003E();

      [InnerClass]
      [EnclosingMethod(null, "<init>", "(Lmindustry.logic.LCanvas;Lmindustry.logic.LStatement;)V")]
      [SpecialName]
      internal new class \u0031 : InputListener
      {
        internal float lastx;
        internal float lasty;
        [Modifiers]
        internal LCanvas.StatementElem this\u00241;

        [SpecialName]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public new static void __\u003Cclinit\u003E()
        {
        }

        [LineNumberTable(348)]
        [MethodImpl(MethodImplOptions.NoInlining)]
        internal \u0031([In] LCanvas.StatementElem obj0)
        {
          this.this\u00241 = obj0;
          // ISSUE: explicit constructor call
          base.\u002Ector();
        }

        [LineNumberTable(new byte[] {160, 240, 110, 107, 162, 122, 108, 108, 118, 107, 117})]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public override bool touchDown(
          [In] InputEvent obj0,
          [In] float obj1,
          [In] float obj2,
          [In] int obj3,
          [In] KeyCode obj4)
        {
          if (object.ReferenceEquals((object) obj4, (object) KeyCode.__\u003C\u003EmouseMiddle))
          {
            this.this\u00241.copy();
            return false;
          }
          Vec2 parentCoordinates = this.this\u00241.localToParentCoordinates(Tmp.__\u003C\u003Ev1.set(obj1, obj2));
          this.lastx = parentCoordinates.x;
          this.lasty = parentCoordinates.y;
          this.this\u00241.this\u00240.dragging = this.this\u00241;
          this.this\u00241.toFront();
          this.this\u00241.this\u00240.statements.layout();
          return true;
        }

        [LineNumberTable(new byte[] {161, 0, 154, 127, 14, 108, 140, 117})]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public override void touchDragged([In] InputEvent obj0, [In] float obj1, [In] float obj2, [In] int obj3)
        {
          Vec2 parentCoordinates = this.this\u00241.localToParentCoordinates(Tmp.__\u003C\u003Ev1.set(obj1, obj2));
          this.this\u00241.translation.add(parentCoordinates.x - this.lastx, parentCoordinates.y - this.lasty);
          this.lastx = parentCoordinates.x;
          this.lasty = parentCoordinates.y;
          this.this\u00241.this\u00240.statements.layout();
        }

        [LineNumberTable(new byte[] {161, 11, 117})]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public override void touchUp(
          [In] InputEvent obj0,
          [In] float obj1,
          [In] float obj2,
          [In] int obj3,
          [In] KeyCode obj4)
        {
          this.this\u00241.this\u00240.statements.finishLayout();
        }

        [HideFromJava]
        static \u0031() => InputListener.__\u003Cclinit\u003E();
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon0 : Cons
      {
        private readonly LCanvas.StatementElem arg\u00241;
        private readonly LStatement arg\u00242;

        internal __\u003C\u003EAnon0([In] LCanvas.StatementElem obj0, [In] LStatement obj1)
        {
          this.arg\u00241 = obj0;
          this.arg\u00242 = obj1;
        }

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024new\u00242(this.arg\u00242, (Table) obj0);
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon1 : Cons
      {
        private readonly LCanvas.StatementElem arg\u00241;
        private readonly LStatement arg\u00242;

        internal __\u003C\u003EAnon1([In] LCanvas.StatementElem obj0, [In] LStatement obj1)
        {
          this.arg\u00241 = obj0;
          this.arg\u00242 = obj1;
        }

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024new\u00243(this.arg\u00242, (Table) obj0);
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon2 : Runnable
      {
        internal __\u003C\u003EAnon2()
        {
        }

        public void run() => LCanvas.StatementElem.lambda\u0024new\u00240();
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon3 : Runnable
      {
        private readonly LCanvas.StatementElem arg\u00241;

        internal __\u003C\u003EAnon3([In] LCanvas.StatementElem obj0) => this.arg\u00241 = obj0;

        public void run() => this.arg\u00241.copy();
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon4 : Runnable
      {
        private readonly LCanvas.StatementElem arg\u00241;

        internal __\u003C\u003EAnon4([In] LCanvas.StatementElem obj0) => this.arg\u00241 = obj0;

        public void run() => this.arg\u00241.lambda\u0024new\u00241();
      }
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon0 : Cons
    {
      private readonly string arg\u00241;

      internal __\u003C\u003EAnon0([In] string obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => LCanvas.lambda\u0024tooltip\u00240(this.arg\u00241, (Table) obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon1 : Cons
    {
      private readonly LCanvas arg\u00241;

      internal __\u003C\u003EAnon1([In] LCanvas obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024rebuild\u00241((Table) obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon2 : Runnable
    {
      private readonly LCanvas arg\u00241;
      private readonly float arg\u00242;

      internal __\u003C\u003EAnon2([In] LCanvas obj0, [In] float obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => this.arg\u00241.lambda\u0024rebuild\u00242(this.arg\u00242);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon3 : Func
    {
      internal __\u003C\u003EAnon3()
      {
      }

      public object get([In] object obj0) => (object) LCanvas.lambda\u0024save\u00243((LCanvas.StatementElem) obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon4 : Cons
    {
      internal __\u003C\u003EAnon4()
      {
      }

      public void get([In] object obj0) => ((LStatement) obj0).saveUI();
    }
  }
}
