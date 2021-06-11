// Decompiled with JetBrains decompiler
// Type: arc.scene.ui.Touchpad
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.func;
using arc.graphics;
using arc.graphics.g2d;
using arc.input;
using arc.math.geom;
using arc.scene.@event;
using arc.scene.style;
using arc.util.pooling;
using ikvm.@internal;
using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.scene.ui
{
  public class Touchpad : Element
  {
    [Modifiers]
    private Circle knobBounds;
    [Modifiers]
    private Circle touchBounds;
    [Modifiers]
    private Circle deadzoneBounds;
    [Modifiers]
    private Vec2 knobPosition;
    [Modifiers]
    private Vec2 knobPercent;
    internal bool touched;
    internal bool resetOnTouchUp;
    private Touchpad.TouchpadStyle style;
    private float deadzoneRadius;

    [LineNumberTable(new byte[] {159, 124, 98, 108, 108, 108, 109, 109, 109, 112, 118, 102, 116, 127, 19, 110, 126, 113, 146, 223, 35, 125, 123, 106, 111, 142, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void calculatePositionAndValue([In] float obj0, [In] float obj1, [In] bool obj2)
    {
      int num1 = obj2 ? 1 : 0;
      float x1 = this.knobPosition.x;
      float y1 = this.knobPosition.y;
      float x2 = this.knobPercent.x;
      float y2 = this.knobPercent.y;
      float x3 = this.knobBounds.x;
      float y3 = this.knobBounds.y;
      this.knobPosition.set(x3, y3);
      this.knobPercent.set(0.0f, 0.0f);
      if (num1 == 0 && !this.deadzoneBounds.contains(obj0, obj1))
      {
        this.knobPercent.set((obj0 - x3) / this.knobBounds.radius, (obj1 - y3) / this.knobBounds.radius);
        float num2 = this.knobPercent.len();
        if ((double) num2 > 1.0)
          this.knobPercent.scl(1f / num2);
        if (this.knobBounds.contains(obj0, obj1))
          this.knobPosition.set(obj0, obj1);
        else
          this.knobPosition.set(this.knobPercent).nor().scl(this.knobBounds.radius).add(this.knobBounds.x, this.knobBounds.y);
      }
      if ((double) x2 == (double) this.knobPercent.x && (double) y2 == (double) this.knobPercent.y)
        return;
      ChangeListener.ChangeEvent changeEvent = (ChangeListener.ChangeEvent) Pools.obtain((Class) ClassLiteral<ChangeListener.ChangeEvent>.Value, (Prov) new Touchpad.__\u003C\u003EAnon0());
      if (this.fire((SceneEvent) changeEvent))
      {
        this.knobPercent.set(x2, y2);
        this.knobPosition.set(x1, y1);
      }
      Pools.free((object) changeEvent);
    }

    [LineNumberTable(new byte[] {159, 183, 232, 49, 122, 122, 122, 107, 139, 231, 74, 121, 136, 159, 9, 103, 148, 237, 84})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Touchpad(float deadzoneRadius, Touchpad.TouchpadStyle style)
    {
      Touchpad touchpad = this;
      this.knobBounds = new Circle(0.0f, 0.0f, 0.0f);
      this.touchBounds = new Circle(0.0f, 0.0f, 0.0f);
      this.deadzoneBounds = new Circle(0.0f, 0.0f, 0.0f);
      this.knobPosition = new Vec2();
      this.knobPercent = new Vec2();
      this.resetOnTouchUp = true;
      if ((double) deadzoneRadius < 0.0)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException("deadzoneRadius must be > 0");
      }
      this.deadzoneRadius = deadzoneRadius;
      this.knobPosition.set(this.getWidth() / 2f, this.getHeight() / 2f);
      this.setStyle(style);
      this.setSize(this.getPrefWidth(), this.getPrefHeight());
      this.addListener((EventListener) new Touchpad.\u0031(this));
    }

    [LineNumberTable(new byte[] {62, 115, 103, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setStyle(Touchpad.TouchpadStyle style)
    {
      if (style == null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException("style cannot be null");
      }
      this.style = style;
      this.invalidateHierarchy();
    }

    [LineNumberTable(162)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override float getPrefWidth() => this.style.background != null ? this.style.background.getMinWidth() : 0.0f;

    [LineNumberTable(167)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override float getPrefHeight() => this.style.background != null ? this.style.background.getMinHeight() : 0.0f;

    [LineNumberTable(new byte[] {159, 180, 124})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Touchpad(float deadzoneRadius)
      : this(deadzoneRadius, (Touchpad.TouchpadStyle) Core.scene.getStyle((Class) ClassLiteral<Touchpad.TouchpadStyle>.Value))
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Touchpad.TouchpadStyle getStyle() => this.style;

    [LineNumberTable(119)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override Element hit(float x, float y, bool touchable) => this.touchBounds.contains(x, y) ? (Element) this : (Element) null;

    [LineNumberTable(new byte[] {75, 111, 111, 105, 111, 127, 33, 111, 148, 110, 118})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void layout()
    {
      float x = this.getWidth() / 2f;
      float y = this.getHeight() / 2f;
      float radius = Math.min(x, y);
      this.touchBounds.set(x, y, radius);
      if (this.style.knob != null)
        radius -= Math.max(this.style.knob.getMinWidth(), this.style.knob.getMinHeight()) / 2f;
      this.knobBounds.set(x, y, radius);
      this.deadzoneBounds.set(x, y, this.deadzoneRadius);
      this.knobPosition.set(x, y);
      this.knobPercent.set(0.0f, 0.0f);
    }

    [LineNumberTable(new byte[] {89, 134, 103, 159, 6, 103, 103, 104, 137, 109, 144, 109, 100, 127, 1, 127, 1, 153})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void draw()
    {
      this.validate();
      Color color = this.__\u003C\u003Ecolor;
      Draw.color(color.r, color.g, color.b, color.a * this.parentAlpha);
      float x = this.x;
      float y = this.y;
      float width = this.getWidth();
      float height = this.getHeight();
      this.style.background?.draw(x, y, width, height);
      Drawable knob = this.style.knob;
      if (knob == null)
        return;
      float f1 = x + (this.knobPosition.x - knob.getMinWidth() / 2f);
      float f2 = y + (this.knobPosition.y - knob.getMinHeight() / 2f);
      knob.draw(f1, f2, knob.getMinWidth(), knob.getMinHeight());
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isTouched() => this.touched;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool getResetOnTouchUp() => this.resetOnTouchUp;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setResetOnTouchUp(bool reset) => this.resetOnTouchUp = reset;

    [LineNumberTable(new byte[] {160, 71, 121, 104, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setDeadzone(float deadzoneRadius)
    {
      if ((double) deadzoneRadius < 0.0)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException("deadzoneRadius must be > 0");
      }
      this.deadzoneRadius = deadzoneRadius;
      this.invalidate();
    }

    [LineNumberTable(192)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getKnobX() => this.knobPosition.x;

    [LineNumberTable(197)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getKnobY() => this.knobPosition.y;

    [LineNumberTable(205)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getKnobPercentX() => this.knobPercent.x;

    [LineNumberTable(213)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getKnobPercentY() => this.knobPercent.y;

    [EnclosingMethod(null, "<init>", "(FLarc.scene.ui.Touchpad$TouchpadStyle;)V")]
    [SpecialName]
    internal new class \u0031 : InputListener
    {
      [Modifiers]
      internal Touchpad this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(50)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0031([In] Touchpad obj0)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector();
      }

      [LineNumberTable(new byte[] {3, 111, 108, 112})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override bool touchDown(
        [In] InputEvent obj0,
        [In] float obj1,
        [In] float obj2,
        [In] int obj3,
        [In] KeyCode obj4)
      {
        if (this.this\u00240.touched)
          return false;
        this.this\u00240.touched = true;
        this.this\u00240.calculatePositionAndValue(obj1, obj2, false);
        return true;
      }

      [LineNumberTable(new byte[] {11, 112})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void touchDragged([In] InputEvent obj0, [In] float obj1, [In] float obj2, [In] int obj3) => this.this\u00240.calculatePositionAndValue(obj1, obj2, false);

      [LineNumberTable(new byte[] {16, 108, 122})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void touchUp(
        [In] InputEvent obj0,
        [In] float obj1,
        [In] float obj2,
        [In] int obj3,
        [In] KeyCode obj4)
      {
        this.this\u00240.touched = false;
        this.this\u00240.calculatePositionAndValue(obj1, obj2, this.this\u00240.resetOnTouchUp);
      }

      [HideFromJava]
      static \u0031() => InputListener.__\u003Cclinit\u003E();
    }

    public class TouchpadStyle : Object
    {
      public Drawable background;
      public Drawable knob;

      [LineNumberTable(new byte[] {160, 113, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public TouchpadStyle()
      {
      }

      [LineNumberTable(new byte[] {160, 116, 104, 103, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public TouchpadStyle(Drawable background, Drawable knob)
      {
        Touchpad.TouchpadStyle touchpadStyle = this;
        this.background = background;
        this.knob = knob;
      }

      [LineNumberTable(new byte[] {160, 121, 104, 108, 108})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public TouchpadStyle(Touchpad.TouchpadStyle style)
      {
        Touchpad.TouchpadStyle touchpadStyle = this;
        this.background = style.background;
        this.knob = style.knob;
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
  }
}
