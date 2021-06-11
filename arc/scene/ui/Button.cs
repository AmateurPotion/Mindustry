// Decompiled with JetBrains decompiler
// Type: arc.scene.ui.Button
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.func;
using arc.math.geom;
using arc.scene.@event;
using arc.scene.style;
using arc.scene.ui.layout;
using arc.scene.utils;
using arc.util.pooling;
using ikvm.@internal;
using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.scene.ui
{
  [Implements(new string[] {"arc.scene.utils.Disableable"})]
  public class Button : Table, Disableable
  {
    internal bool isChecked;
    internal bool isDisabled;
    internal ButtonGroup buttonGroup;
    internal Boolp disabledProvider;
    private Button.ButtonStyle style;
    private ClickListener clickListener;
    private bool programmaticChangeEvents;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 111, 66, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setChecked(bool isChecked) => this.setChecked(isChecked, this.programmaticChangeEvents);

    [LineNumberTable(new byte[] {159, 187, 104, 102, 186, 112, 159, 12, 117, 113, 117, 127, 17, 117, 142, 140, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Button()
    {
      Button button = this;
      this.initialize();
      this.style = (Button.ButtonStyle) Core.scene.getStyle((Class) ClassLiteral<Button.ButtonStyle>.Value);
      this.setBackground(!this.isPressed() || this.isDisabled() ? (!this.isDisabled() || this.style.disabled == null ? (!this.isChecked || this.style.@checked == null ? (!this.isOver() || this.style.over == null ? this.style.up : this.style.over) : (!this.isOver() || this.style.checkedOver == null ? this.style.@checked : this.style.checkedOver)) : this.style.disabled) : (this.style.down != null ? this.style.down : this.style.up));
    }

    [LineNumberTable(new byte[] {159, 180, 104, 102, 103, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Button(Button.ButtonStyle style)
    {
      Button button = this;
      this.initialize();
      this.setStyle(style);
      this.setSize(this.getPrefWidth(), this.getPrefHeight());
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isDisabled() => this.isDisabled;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setDisabled(Boolp prov) => this.disabledProvider = prov;

    [LineNumberTable(new byte[] {160, 71, 115, 167, 112, 156, 112, 105, 112, 127, 2, 112, 137, 135, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setStyle(Button.ButtonStyle style)
    {
      if (style == null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException("style cannot be null.");
      }
      this.style = style;
      this.setBackground(!this.isPressed() || this.isDisabled() ? (!this.isDisabled() || style.disabled == null ? (!this.isChecked || style.@checked == null ? (!this.isOver() || style.over == null ? style.up : style.over) : (!this.isOver() || style.checkedOver == null ? style.@checked : style.checkedOver)) : style.disabled) : (style.down != null ? style.down : style.up));
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isChecked() => this.isChecked;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual ClickListener getClickListener() => this.clickListener;

    [LineNumberTable(new byte[] {37, 107, 248, 71, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void initialize()
    {
      this.touchable = Touchable.__\u003C\u003Eenabled;
      Button button = this;
      Button.\u0031 obj1 = new Button.\u0031(this);
      Button.\u0031 obj2 = obj1;
      this.clickListener = (ClickListener) obj1;
      this.addListener((EventListener) obj2);
      this.addListener((EventListener) new HandCursorListener());
    }

    [LineNumberTable(new byte[] {160, 144, 104, 127, 7, 127, 7, 127, 7})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override float getPrefWidth()
    {
      float num = base.getPrefWidth();
      if (this.style.up != null)
        num = Math.max(num, this.style.up.getMinWidth());
      if (this.style.down != null)
        num = Math.max(num, this.style.down.getMinWidth());
      if (this.style.@checked != null)
        num = Math.max(num, this.style.@checked.getMinWidth());
      return num;
    }

    [LineNumberTable(new byte[] {160, 153, 104, 127, 7, 127, 7, 127, 7})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override float getPrefHeight()
    {
      float num = base.getPrefHeight();
      if (this.style.up != null)
        num = Math.max(num, this.style.up.getMinHeight());
      if (this.style.down != null)
        num = Math.max(num, this.style.down.getMinHeight());
      if (this.style.@checked != null)
        num = Math.max(num, this.style.@checked.getMinHeight());
      return num;
    }

    [LineNumberTable(128)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isPressed() => this.clickListener.isVisualPressed();

    [LineNumberTable(132)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isOver() => this.clickListener.isOver();

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setDisabled(bool isDisabled) => this.isDisabled = isDisabled;

    [LineNumberTable(new byte[] {159, 117, 68, 106, 120, 135, 99, 122, 118, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void setChecked([In] bool obj0, [In] bool obj1)
    {
      int num1 = obj0 ? 1 : 0;
      int num2 = obj1 ? 1 : 0;
      if ((this.isChecked ? 1 : 0) == num1 || this.buttonGroup != null && !this.buttonGroup.canCheck(this, num1 != 0))
        return;
      this.isChecked = num1 != 0;
      if (num2 == 0)
        return;
      ChangeListener.ChangeEvent changeEvent = (ChangeListener.ChangeEvent) Pools.obtain((Class) ClassLiteral<ChangeListener.ChangeEvent>.Value, (Prov) new Button.__\u003C\u003EAnon0());
      if (this.fire((SceneEvent) changeEvent))
        this.isChecked = num1 == 0;
      Pools.free((object) changeEvent);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {109, 127, 4, 127, 8, 132})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024childrenPressed\u00240([In] Vec2 obj0, [In] bool[] obj1, [In] Element obj2)
    {
      obj2.stageToLocalCoordinates(obj0.set((float) Core.input.mouseX(), (float) Core.input.mouseY()));
      if (!(obj2 is Button) || !((Button) obj2).getClickListener().isOver(obj2, obj0.x, obj0.y))
        return;
      obj1[0] = true;
    }

    [LineNumberTable(new byte[] {16, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Button(Drawable up)
      : this(new Button.ButtonStyle(up, (Drawable) null, (Drawable) null))
    {
    }

    [LineNumberTable(new byte[] {20, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Button(Drawable up, Drawable down)
      : this(new Button.ButtonStyle(up, down, (Drawable) null))
    {
    }

    [LineNumberTable(new byte[] {24, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Button(Drawable up, Drawable down, Drawable @checked)
      : this(new Button.ButtonStyle(up, down, @checked))
    {
    }

    [LineNumberTable(new byte[] {29, 136, 104, 145})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void act(float delta)
    {
      base.act(delta);
      if (this.disabledProvider == null)
        return;
      this.setDisabled(this.disabledProvider.get());
    }

    [LineNumberTable(new byte[] {66, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void toggle() => this.setChecked(!this.isChecked);

    [LineNumberTable(new byte[] {105, 107, 134, 242, 71})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool childrenPressed()
    {
      bool[] flagArray = new bool[1]{ false };
      this.forEach((Cons) new Button.__\u003C\u003EAnon1(new Vec2(), flagArray));
      return flagArray[0];
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setProgrammaticChangeEvents(bool programmaticChangeEvents) => this.programmaticChangeEvents = programmaticChangeEvents;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Button.ButtonStyle getStyle() => this.style;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual ButtonGroup getButtonGroup() => this.buttonGroup;

    [LineNumberTable(new byte[] {160, 97, 134, 103, 103, 103, 135, 99, 112, 114, 112, 114, 112, 127, 13, 112, 111, 109, 141, 168, 102, 109, 111, 102, 109, 143, 109, 173, 104, 110, 55, 136, 102, 110, 57, 168, 104, 123, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void draw()
    {
      this.validate();
      int num1 = this.isDisabled() ? 1 : 0;
      int num2 = this.isPressed() ? 1 : 0;
      int num3 = this.isChecked() ? 1 : 0;
      int num4 = this.isOver() ? 1 : 0;
      Drawable background = (Drawable) null;
      if (num1 != 0 && this.style.disabled != null)
        background = this.style.disabled;
      else if (num2 != 0 && this.style.down != null)
        background = this.style.down;
      else if (num3 != 0 && this.style.@checked != null)
        background = this.style.checkedOver == null || num4 == 0 ? this.style.@checked : this.style.checkedOver;
      else if (num4 != 0 && this.style.over != null)
        background = this.style.over;
      else if (this.style.up != null)
        background = this.style.up;
      this.setBackground(background);
      float x;
      float y;
      if (num2 != 0 && num1 == 0)
      {
        x = this.style.pressedOffsetX;
        y = this.style.pressedOffsetY;
      }
      else if (num3 != 0 && num1 == 0)
      {
        x = this.style.checkedOffsetX;
        y = this.style.checkedOffsetY;
      }
      else
      {
        x = this.style.unpressedOffsetX;
        y = this.style.unpressedOffsetY;
      }
      SnapshotSeq children = this.getChildren();
      for (int index = 0; index < children.size; ++index)
        ((Element) children.get(index)).moveBy(x, y);
      base.draw();
      for (int index = 0; index < children.size; ++index)
        ((Element) children.get(index)).moveBy(-x, -y);
      Scene scene = this.getScene();
      if (scene == null || !scene.getActionsRequestRendering() || num2 == (this.clickListener.isPressed() ? 1 : 0))
        return;
      Core.graphics.requestRendering();
    }

    [LineNumberTable(276)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override float getMinWidth() => this.getPrefWidth();

    [LineNumberTable(281)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override float getMinHeight() => this.getPrefHeight();

    [HideFromJava]
    static Button() => Table.__\u003Cclinit\u003E();

    [EnclosingMethod(null, "initialize", "()V")]
    [SpecialName]
    internal new class \u0031 : ClickListener
    {
      [Modifiers]
      internal Button this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(88)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0031([In] Button obj0)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector();
      }

      [LineNumberTable(new byte[] {41, 110, 125})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void clicked([In] InputEvent obj0, [In] float obj1, [In] float obj2)
      {
        if (this.this\u00240.isDisabled())
          return;
        this.this\u00240.setChecked(!this.this\u00240.isChecked, true);
      }

      [HideFromJava]
      static \u0031() => ClickListener.__\u003Cclinit\u003E();
    }

    public class ButtonStyle : Style
    {
      public Drawable up;
      public Drawable down;
      public Drawable over;
      public Drawable @checked;
      public Drawable checkedOver;
      public Drawable disabled;
      public float pressedOffsetX;
      public float pressedOffsetY;
      public float unpressedOffsetX;
      public float unpressedOffsetY;
      public float checkedOffsetX;
      public float checkedOffsetY;

      [LineNumberTable(new byte[] {160, 184, 104, 103, 103, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public ButtonStyle(Drawable up, Drawable down, Drawable @checked)
      {
        Button.ButtonStyle buttonStyle = this;
        this.up = up;
        this.down = down;
        this.@checked = @checked;
      }

      [LineNumberTable(new byte[] {160, 181, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public ButtonStyle()
      {
      }

      [LineNumberTable(new byte[] {160, 190, 104, 108, 108, 108, 108, 108, 108, 108, 108, 108, 108, 108, 108})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public ButtonStyle(Button.ButtonStyle style)
      {
        Button.ButtonStyle buttonStyle = this;
        this.up = style.up;
        this.down = style.down;
        this.over = style.over;
        this.@checked = style.@checked;
        this.checkedOver = style.checkedOver;
        this.disabled = style.disabled;
        this.pressedOffsetX = style.pressedOffsetX;
        this.pressedOffsetY = style.pressedOffsetY;
        this.unpressedOffsetX = style.unpressedOffsetX;
        this.unpressedOffsetY = style.unpressedOffsetY;
        this.checkedOffsetX = style.checkedOffsetX;
        this.checkedOffsetY = style.checkedOffsetY;
      }
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon0 : Prov
    {
      internal __\u003C\u003EAnon0()
      {
      }

      public object get() => (object) new ChangeListener.ChangeEvent();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon1 : Cons
    {
      private readonly Vec2 arg\u00241;
      private readonly bool[] arg\u00242;

      internal __\u003C\u003EAnon1([In] Vec2 obj0, [In] bool[] obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] object obj0) => Button.lambda\u0024childrenPressed\u00240(this.arg\u00241, this.arg\u00242, (Element) obj0);
    }
  }
}
