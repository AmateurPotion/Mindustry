// Decompiled with JetBrains decompiler
// Type: arc.scene.ui.ScrollPane
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.graphics.g2d;
using arc.input;
using arc.math;
using arc.math.geom;
using arc.scene.@event;
using arc.scene.style;
using arc.scene.ui.layout;
using arc.scene.utils;
using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.scene.ui
{
  public class ScrollPane : WidgetGroup
  {
    [Modifiers]
    internal Rect hScrollBounds;
    [Modifiers]
    internal Rect vScrollBounds;
    [Modifiers]
    internal Rect hKnobBounds;
    [Modifiers]
    internal Rect vKnobBounds;
    [Modifiers]
    internal Vec2 lastPoint;
    [Modifiers]
    private Rect widgetAreaBounds;
    [Modifiers]
    private Rect widgetCullingArea;
    [Modifiers]
    private Rect scissorBounds;
    protected internal bool disableX;
    protected internal bool disableY;
    internal bool scrollX;
    internal bool scrollY;
    internal bool vScrollOnRight;
    internal bool hScrollOnBottom;
    internal float amountX;
    internal float amountY;
    internal float visualAmountX;
    internal float visualAmountY;
    internal float maxX;
    internal float maxY;
    internal bool touchScrollH;
    internal bool touchScrollV;
    internal float areaWidth;
    internal float areaHeight;
    internal float fadeAlpha;
    internal float fadeAlphaSeconds;
    internal float fadeDelay;
    internal float fadeDelaySeconds;
    internal bool cancelTouchFocus;
    internal bool flickScroll;
    internal float velocityX;
    internal float velocityY;
    internal float flingTimer;
    internal float flingTime;
    internal int draggingPointer;
    private ScrollPane.ScrollPaneStyle style;
    private Element widget;
    private ElementGestureListener flickScrollListener;
    private bool fadeScrollBars;
    private bool smoothScrolling;
    private bool overscrollX;
    private bool overscrollY;
    private float overscrollDistance;
    private float overscrollSpeedMin;
    private float overscrollSpeedMax;
    private bool forceScrollX;
    private bool forceScrollY;
    private bool clamp;
    private bool scrollbarsOnTop;
    private bool variableSizeKnobs;
    private bool clip;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {20, 232, 22, 107, 107, 107, 107, 107, 107, 107, 171, 103, 231, 70, 127, 2, 103, 167, 107, 199, 110, 110, 159, 2, 135, 103, 231, 73, 115, 103, 103, 112, 135, 237, 160, 85, 236, 97, 141, 237, 74, 237, 87})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ScrollPane(Element widget, ScrollPane.ScrollPaneStyle style)
    {
      ScrollPane scrollPane = this;
      this.hScrollBounds = new Rect();
      this.vScrollBounds = new Rect();
      this.hKnobBounds = new Rect();
      this.vKnobBounds = new Rect();
      this.lastPoint = new Vec2();
      this.widgetAreaBounds = new Rect();
      this.widgetCullingArea = new Rect();
      this.scissorBounds = new Rect();
      this.vScrollOnRight = true;
      this.hScrollOnBottom = true;
      this.fadeAlpha = 1f;
      this.fadeAlphaSeconds = 1f;
      this.fadeDelaySeconds = 1f;
      this.cancelTouchFocus = true;
      this.flickScroll = true;
      this.flingTime = 1f;
      this.draggingPointer = -1;
      this.fadeScrollBars = false;
      this.smoothScrolling = true;
      this.overscrollX = true;
      this.overscrollY = true;
      this.overscrollDistance = 50f;
      this.overscrollSpeedMin = 30f;
      this.overscrollSpeedMax = 200f;
      this.clamp = true;
      this.variableSizeKnobs = true;
      this.clip = true;
      if (style == null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException("style cannot be null.");
      }
      this.style = style;
      this.setWidget(widget);
      this.setSize(150f, 150f);
      this.setTransform(true);
      this.addCaptureListener((EventListener) new ScrollPane.\u0031(this));
      this.flickScrollListener = (ElementGestureListener) new ScrollPane.\u0032(this);
      this.addListener((EventListener) this.flickScrollListener);
      this.addListener((EventListener) new ScrollPane.\u0033(this));
      this.addCaptureListener((EventListener) new ScrollPane.\u0034(this));
    }

    [LineNumberTable(new byte[] {16, 123})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ScrollPane(Element widget)
      : this(widget, (ScrollPane.ScrollPaneStyle) Core.scene.getStyle((Class) ClassLiteral<ScrollPane.ScrollPaneStyle>.Value))
    {
    }

    [LineNumberTable(new byte[] {158, 141, 162, 106, 103, 111, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setFadeScrollBars(bool fadeScrollBars)
    {
      int num = fadeScrollBars ? 1 : 0;
      if ((this.fadeScrollBars ? 1 : 0) == num)
        return;
      this.fadeScrollBars = num != 0;
      if (num == 0)
        this.fadeAlpha = this.fadeAlphaSeconds;
      this.invalidate();
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setOverscroll(bool overscrollX, bool overscrollY)
    {
      int num1 = overscrollX ? 1 : 0;
      int num2 = overscrollY ? 1 : 0;
      this.overscrollX = num1 != 0;
      this.overscrollY = num2 != 0;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setScrollingDisabled(bool x, bool y)
    {
      int num1 = x ? 1 : 0;
      int num2 = y ? 1 : 0;
      this.disableX = num1 != 0;
      this.disableY = num2 != 0;
    }

    [LineNumberTable(new byte[] {162, 183, 123})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getScrollPercentY() => Float.isNaN(this.amountY / this.maxY) ? 1f : Mathf.clamp(this.amountY / this.maxY, 0.0f, 1f);

    [LineNumberTable(new byte[] {158, 194, 130, 106, 103, 99, 143, 109, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setFlickScroll(bool flickScroll)
    {
      int num = flickScroll ? 1 : 0;
      if ((this.flickScroll ? 1 : 0) == num)
        return;
      this.flickScroll = num != 0;
      if (num != 0)
        this.addListener((EventListener) this.flickScrollListener);
      else
        this.removeListener((EventListener) this.flickScrollListener);
      this.invalidate();
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getScrollY() => this.amountY;

    [LineNumberTable(new byte[] {163, 32, 121})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setScrollY(float pixels) => this.scrollY(Mathf.clamp(pixels, 0.0f, this.maxY));

    [LineNumberTable(new byte[] {162, 188, 127, 1})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setScrollPercentY(float percentY) => this.scrollY(this.maxY * Mathf.clamp(percentY, 0.0f, 1f));

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void updateVisualScroll()
    {
      this.visualAmountX = this.amountX;
      this.visualAmountY = this.amountY;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getVisualScrollY() => !this.scrollY ? 0.0f : this.visualAmountY;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getMaxY() => this.maxY;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setScrollYForce(float pixels)
    {
      this.visualAmountY = pixels;
      this.amountY = pixels;
      this.scrollY = true;
    }

    [LineNumberTable(new byte[] {158, 219, 66, 127, 11, 123, 123})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override Element hit(float x, float y, bool touchable)
    {
      int num = touchable ? 1 : 0;
      if ((double) x < 0.0 || (double) x >= (double) this.getWidth() || ((double) y < 0.0 || (double) y >= (double) this.getHeight()))
        return (Element) null;
      if (this.scrollX && this.hScrollBounds.contains(x, y))
        return (Element) this;
      return this.scrollY && this.vScrollBounds.contains(x, y) ? (Element) this : base.hit(x, y, num != 0);
    }

    [LineNumberTable(new byte[] {160, 158, 115, 103, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setStyle(ScrollPane.ScrollPaneStyle style)
    {
      if (style == null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException("style cannot be null.");
      }
      this.style = style;
      this.invalidateHierarchy();
    }

    [LineNumberTable(new byte[] {160, 165, 136, 113, 130, 127, 9, 112, 127, 9, 162, 112, 134, 111, 123, 123, 166, 122, 127, 2, 122, 159, 2, 112, 109, 107, 171, 162, 255, 160, 76, 69, 113, 110, 159, 37, 127, 35, 130, 113, 110, 159, 37, 127, 35, 164, 122, 186, 102, 118, 109, 102, 159, 26, 120, 100, 110, 102, 159, 34, 122, 162, 118, 109, 102, 159, 26, 120, 100, 110, 102, 159, 34, 122, 226, 69, 99, 103, 149})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void act(float delta)
    {
      base.act(delta);
      int num1 = this.flickScrollListener.getGestureDetector().isPanning() ? 1 : 0;
      int num2 = 0;
      if ((double) this.fadeAlpha > 0.0 && this.fadeScrollBars && (num1 == 0 && !this.touchScrollH) && !this.touchScrollV)
      {
        this.fadeDelay -= delta;
        if ((double) this.fadeDelay <= 0.0)
          this.fadeAlpha = Math.max(0.0f, this.fadeAlpha - delta);
        num2 = 1;
      }
      if ((double) this.flingTimer > 0.0)
      {
        this.resetFade();
        float num3 = this.flingTimer / this.flingTime;
        this.amountX -= this.velocityX * num3 * delta;
        this.amountY -= this.velocityY * num3 * delta;
        this.clamp();
        if ((double) this.amountX == -(double) this.overscrollDistance)
          this.velocityX = 0.0f;
        if ((double) this.amountX >= (double) (this.maxX + this.overscrollDistance))
          this.velocityX = 0.0f;
        if ((double) this.amountY == -(double) this.overscrollDistance)
          this.velocityY = 0.0f;
        if ((double) this.amountY >= (double) (this.maxY + this.overscrollDistance))
          this.velocityY = 0.0f;
        this.flingTimer -= delta;
        if ((double) this.flingTimer <= 0.0)
        {
          this.velocityX = 0.0f;
          this.velocityY = 0.0f;
        }
        num2 = 1;
      }
      if (this.smoothScrolling && (double) this.flingTimer <= 0.0 && num1 == 0 && (!this.touchScrollH || this.scrollX && (double) (this.maxX / (this.hScrollBounds.width - this.hKnobBounds.width)) > (double) (this.areaWidth * 0.1f)) && (!this.touchScrollV || this.scrollY && (double) (this.maxY / (this.vScrollBounds.height - this.vKnobBounds.height)) > (double) (this.areaHeight * 0.1f)))
      {
        if ((double) this.visualAmountX != (double) this.amountX)
        {
          if ((double) this.visualAmountX < (double) this.amountX)
            this.visualScrollX(Math.min(this.amountX, this.visualAmountX + Math.max(200f * delta, (this.amountX - this.visualAmountX) * 7f * delta)));
          else
            this.visualScrollX(Math.max(this.amountX, this.visualAmountX - Math.max(200f * delta, (this.visualAmountX - this.amountX) * 7f * delta)));
          num2 = 1;
        }
        if ((double) this.visualAmountY != (double) this.amountY)
        {
          if ((double) this.visualAmountY < (double) this.amountY)
            this.visualScrollY(Math.min(this.amountY, this.visualAmountY + Math.max(200f * delta, (this.amountY - this.visualAmountY) * 7f * delta)));
          else
            this.visualScrollY(Math.max(this.amountY, this.visualAmountY - Math.max(200f * delta, (this.visualAmountY - this.amountY) * 7f * delta)));
          num2 = 1;
        }
      }
      else
      {
        if ((double) this.visualAmountX != (double) this.amountX)
          this.visualScrollX(this.amountX);
        if ((double) this.visualAmountY != (double) this.amountY)
          this.visualScrollY(this.amountY);
      }
      if (num1 == 0)
      {
        if (this.overscrollX && this.scrollX)
        {
          if ((double) this.amountX < 0.0)
          {
            this.resetFade();
            this.amountX += (this.overscrollSpeedMin + (this.overscrollSpeedMax - this.overscrollSpeedMin) * -this.amountX / this.overscrollDistance) * delta;
            if ((double) this.amountX > 0.0)
              this.scrollX(0.0f);
            num2 = 1;
          }
          else if ((double) this.amountX > (double) this.maxX)
          {
            this.resetFade();
            this.amountX -= (this.overscrollSpeedMin + (this.overscrollSpeedMax - this.overscrollSpeedMin) * -(this.maxX - this.amountX) / this.overscrollDistance) * delta;
            if ((double) this.amountX < (double) this.maxX)
              this.scrollX(this.maxX);
            num2 = 1;
          }
        }
        if (this.overscrollY && this.scrollY)
        {
          if ((double) this.amountY < 0.0)
          {
            this.resetFade();
            this.amountY += (this.overscrollSpeedMin + (this.overscrollSpeedMax - this.overscrollSpeedMin) * -this.amountY / this.overscrollDistance) * delta;
            if ((double) this.amountY > 0.0)
              this.scrollY(0.0f);
            num2 = 1;
          }
          else if ((double) this.amountY > (double) this.maxY)
          {
            this.resetFade();
            this.amountY -= (this.overscrollSpeedMin + (this.overscrollSpeedMax - this.overscrollSpeedMin) * -(this.maxY - this.amountY) / this.overscrollDistance) * delta;
            if ((double) this.amountY < (double) this.maxY)
              this.scrollY(this.maxY);
            num2 = 1;
          }
        }
      }
      if (num2 == 0)
        return;
      Scene scene = this.getScene();
      if (scene == null || !scene.getActionsRequestRendering())
        return;
      Core.graphics.requestRendering();
    }

    [LineNumberTable(new byte[] {161, 12, 108, 108, 140, 123, 99, 104, 105, 105, 169, 105, 137, 103, 108, 127, 9, 103, 108, 191, 9, 111, 144, 201, 110, 206, 127, 5, 159, 5, 104, 135, 104, 112, 159, 2, 104, 112, 122, 103, 240, 70, 155, 132, 118, 112, 181, 136, 125, 191, 0, 159, 6, 255, 6, 69, 127, 1, 159, 1, 112, 112, 132, 112, 112, 176, 221, 107, 102, 137, 146, 120, 120, 104, 159, 24, 146, 146, 127, 32, 118, 98, 127, 1, 191, 1, 107, 102, 169, 104, 146, 164, 104, 142, 131, 120, 114, 104, 159, 24, 146, 104, 156, 140, 127, 39, 98, 127, 1, 223, 1, 111, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void layout()
    {
      Drawable background = this.style.background;
      Drawable hScrollKnob = this.style.hScrollKnob;
      Drawable vScrollKnob = this.style.vScrollKnob;
      float x = 0.0f;
      float num1 = 0.0f;
      float num2 = 0.0f;
      float y1 = 0.0f;
      if (background != null)
      {
        x = background.getLeftWidth();
        num1 = background.getRightWidth();
        num2 = background.getTopHeight();
        y1 = background.getBottomHeight();
      }
      float width1 = this.getWidth();
      float height1 = this.getHeight();
      float num3 = 0.0f;
      if (hScrollKnob != null)
        num3 = hScrollKnob.getMinHeight();
      if (this.style.hScroll != null)
        num3 = Math.max(num3, this.style.hScroll.getMinHeight());
      float num4 = 0.0f;
      if (vScrollKnob != null)
        num4 = vScrollKnob.getMinWidth();
      if (this.style.vScroll != null)
        num4 = Math.max(num4, this.style.vScroll.getMinWidth());
      this.areaWidth = width1 - x - num1;
      this.areaHeight = height1 - num2 - y1;
      if (this.widget == null)
        return;
      float prefWidth = this.widget.getPrefWidth();
      float prefHeight = this.widget.getPrefHeight();
      this.scrollX = this.forceScrollX || (double) prefWidth > (double) this.areaWidth && !this.disableX;
      this.scrollY = this.forceScrollY || (double) prefHeight > (double) this.areaHeight && !this.disableY;
      int num5 = this.fadeScrollBars ? 1 : 0;
      if (num5 == 0)
      {
        if (this.scrollY)
        {
          this.areaWidth -= num4;
          if (!this.scrollX && (double) prefWidth > (double) this.areaWidth && !this.disableX)
            this.scrollX = true;
        }
        if (this.scrollX)
        {
          this.areaHeight -= num3;
          if (!this.scrollY && (double) prefHeight > (double) this.areaHeight && !this.disableY)
          {
            this.scrollY = true;
            this.areaWidth -= num4;
          }
        }
      }
      this.widgetAreaBounds.set(x, y1, this.areaWidth, this.areaHeight);
      if (num5 != 0)
      {
        if (this.scrollX && this.scrollY)
        {
          this.areaHeight -= num3;
          this.areaWidth -= num4;
        }
      }
      else if (this.scrollbarsOnTop)
      {
        if (this.scrollX)
          this.widgetAreaBounds.height += num3;
        if (this.scrollY)
          this.widgetAreaBounds.width += num4;
      }
      else
      {
        if (this.scrollX && this.hScrollOnBottom)
          this.widgetAreaBounds.y += num3;
        if (this.scrollY && !this.vScrollOnRight)
          this.widgetAreaBounds.x += num4;
      }
      float width2 = !this.disableX ? Math.max(this.areaWidth, prefWidth) : this.areaWidth;
      float height2 = !this.disableY ? Math.max(this.areaHeight, prefHeight) : this.areaHeight;
      this.maxX = width2 - this.areaWidth;
      this.maxY = height2 - this.areaHeight;
      if (num5 != 0 && this.scrollX && this.scrollY)
      {
        this.maxY -= num3;
        this.maxX -= num4;
      }
      this.scrollX(Mathf.clamp(this.amountX, 0.0f, this.maxX));
      if (this.scrollX)
      {
        if (hScrollKnob != null)
        {
          float minHeight = hScrollKnob.getMinHeight();
          this.hScrollBounds.set(!this.vScrollOnRight ? x + num4 : x, !this.hScrollOnBottom ? height1 - num2 - minHeight : y1, this.areaWidth, minHeight);
          this.hKnobBounds.width = !this.variableSizeKnobs ? hScrollKnob.getMinWidth() : Math.max(hScrollKnob.getMinWidth(), (float) ByteCodeHelper.f2i(this.hScrollBounds.width * this.areaWidth / width2));
          this.hKnobBounds.height = hScrollKnob.getMinHeight();
          this.hKnobBounds.x = this.hScrollBounds.x + (float) ByteCodeHelper.f2i((this.hScrollBounds.width - this.hKnobBounds.width) * this.getScrollPercentX());
          this.hKnobBounds.y = this.hScrollBounds.y;
        }
        else
        {
          this.hScrollBounds.set(0.0f, 0.0f, 0.0f, 0.0f);
          this.hKnobBounds.set(0.0f, 0.0f, 0.0f, 0.0f);
        }
      }
      if (this.scrollY)
      {
        if (vScrollKnob != null)
        {
          float minWidth = vScrollKnob.getMinWidth();
          float y2 = !this.hScrollOnBottom ? y1 : height1 - num2 - this.areaHeight;
          this.vScrollBounds.set(!this.vScrollOnRight ? x : width1 - num1 - minWidth, y2, minWidth, this.areaHeight);
          this.vKnobBounds.width = vScrollKnob.getMinWidth();
          this.vKnobBounds.height = !this.variableSizeKnobs ? vScrollKnob.getMinHeight() : Math.max(vScrollKnob.getMinHeight(), (float) ByteCodeHelper.f2i(this.vScrollBounds.height * this.areaHeight / height2));
          this.vKnobBounds.x = !this.vScrollOnRight ? x : width1 - num1 - vScrollKnob.getMinWidth();
          this.vKnobBounds.y = this.vScrollBounds.y + (float) ByteCodeHelper.f2i((this.vScrollBounds.height - this.vKnobBounds.height) * (1f - this.getScrollPercentY()));
        }
        else
        {
          this.vScrollBounds.set(0.0f, 0.0f, 0.0f, 0.0f);
          this.vKnobBounds.set(0.0f, 0.0f, 0.0f, 0.0f);
        }
      }
      this.widget.setSize(width2, height2);
      this.widget.validate();
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void resetFade()
    {
      this.fadeAlpha = this.fadeAlphaSeconds;
      this.fadeDelay = this.fadeDelaySeconds;
    }

    [LineNumberTable(new byte[] {163, 23, 121})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setScrollX(float pixels) => this.scrollX(Mathf.clamp(pixels, 0.0f, this.maxX));

    [LineNumberTable(new byte[] {160, 135, 103, 103, 103, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void cancel()
    {
      this.draggingPointer = -1;
      this.touchScrollH = false;
      this.touchScrollV = false;
      this.flickScrollListener.getGestureDetector().cancel();
    }

    [LineNumberTable(new byte[] {162, 179, 127, 1})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setScrollPercentX(float percentX) => this.scrollX(this.maxX * Mathf.clamp(percentX, 0.0f, 1f));

    [LineNumberTable(new byte[] {162, 66, 121, 117, 103, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setWidget(Element widget)
    {
      if (object.ReferenceEquals((object) widget, (object) this))
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException("widget cannot be the ScrollPane.");
      }
      if (this.widget != null)
        base.removeChild(this.widget);
      this.widget = widget;
      if (widget == null)
        return;
      this.addChild(widget);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void scrollX(float pixelsX) => this.amountX = pixelsX;

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void scrollY(float pixelsY) => this.amountY = pixelsY;

    [LineNumberTable(new byte[] {160, 142, 105, 127, 13, 55, 133, 127, 13, 55, 133})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void clamp()
    {
      if (!this.clamp)
        return;
      this.scrollX(!this.overscrollX ? Mathf.clamp(this.amountX, 0.0f, this.maxX) : Mathf.clamp(this.amountX, -this.overscrollDistance, this.maxX + this.overscrollDistance));
      this.scrollY(!this.overscrollY ? Mathf.clamp(this.amountY, 0.0f, this.maxY) : Mathf.clamp(this.amountY, -this.overscrollDistance, this.maxY + this.overscrollDistance));
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void visualScrollX(float pixelsX) => this.visualAmountX = pixelsX;

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void visualScrollY(float pixelsY) => this.visualAmountY = pixelsY;

    [LineNumberTable(new byte[] {162, 174, 123})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getScrollPercentX() => Float.isNaN(this.amountX / this.maxX) ? 1f : Mathf.clamp(this.amountX / this.maxX, 0.0f, 1f);

    [LineNumberTable(792)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getVisualScrollPercentX() => Mathf.clamp(this.visualAmountX / this.maxX, 0.0f, 1f);

    [LineNumberTable(796)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getVisualScrollPercentY() => Mathf.clamp(this.visualAmountY / this.maxY, 0.0f, 1f);

    [LineNumberTable(new byte[] {158, 187, 70, 103, 99, 159, 0, 127, 1, 136, 152, 103, 99, 159, 9, 127, 19, 152, 120})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void scrollTo(
      float x,
      float y,
      float width,
      float height,
      bool centerHorizontal,
      bool centerVertical)
    {
      int num1 = centerHorizontal ? 1 : 0;
      int num2 = centerVertical ? 1 : 0;
      float num3 = this.amountX;
      if (num1 != 0)
      {
        num3 = x - this.areaWidth / 2f + width / 2f;
      }
      else
      {
        if ((double) (x + width) > (double) (num3 + this.areaWidth))
          num3 = x + width - this.areaWidth;
        if ((double) x < (double) num3)
          num3 = x;
      }
      this.scrollX(Mathf.clamp(num3, 0.0f, this.maxX));
      float num4 = this.amountY;
      if (num2 != 0)
      {
        num4 = this.maxY - y + this.areaHeight / 2f - height / 2f;
      }
      else
      {
        if ((double) num4 > (double) (this.maxY - y - height + this.areaHeight))
          num4 = this.maxY - y - height + this.areaHeight;
        if ((double) num4 < (double) (this.maxY - y))
          num4 = this.maxY - y;
      }
      this.scrollY(Mathf.clamp(num4, 0.0f, this.maxY));
    }

    [LineNumberTable(new byte[] {160, 129, 103, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void cancelTouchFocus() => this.getScene()?.cancelTouchFocusExcept((EventListener) this.flickScrollListener, (Element) this);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual ScrollPane.ScrollPaneStyle getStyle() => this.style;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setClip(bool clip) => this.clip = clip;

    [LineNumberTable(new byte[] {161, 168, 137, 166, 140, 104, 127, 32, 104, 191, 39, 108, 104, 146, 152, 108, 152, 118, 112, 102, 127, 0, 127, 7, 133, 112, 102, 127, 0, 127, 7, 197, 141, 112, 127, 5, 127, 5, 118, 118, 214, 223, 22, 150, 136, 109, 102, 168, 198, 127, 53, 112, 109, 223, 42, 107, 109, 127, 29, 109, 159, 29, 107, 109, 127, 29, 109, 191, 29, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void draw()
    {
      if (this.widget == null)
        return;
      this.validate();
      this.applyTransform(this.computeTransform());
      if (this.scrollX)
        this.hKnobBounds.x = this.hScrollBounds.x + (float) ByteCodeHelper.f2i((this.hScrollBounds.width - this.hKnobBounds.width) * this.getVisualScrollPercentX());
      if (this.scrollY)
        this.vKnobBounds.y = this.vScrollBounds.y + (float) ByteCodeHelper.f2i((this.vScrollBounds.height - this.vKnobBounds.height) * (1f - this.getVisualScrollPercentY()));
      float y1 = this.widgetAreaBounds.y;
      float y2 = this.scrollY ? y1 - (float) ByteCodeHelper.f2i(this.maxY - this.visualAmountY) : y1 - (float) ByteCodeHelper.f2i(this.maxY);
      float x = this.widgetAreaBounds.x;
      if (this.scrollX)
        x -= (float) ByteCodeHelper.f2i(this.visualAmountX);
      if (!this.fadeScrollBars && this.scrollbarsOnTop)
      {
        if (this.scrollX && this.hScrollOnBottom)
        {
          float num = 0.0f;
          if (this.style.hScrollKnob != null)
            num = this.style.hScrollKnob.getMinHeight();
          if (this.style.hScroll != null)
            num = Math.max(num, this.style.hScroll.getMinHeight());
          y2 += num;
        }
        if (this.scrollY && !this.vScrollOnRight)
        {
          float num = 0.0f;
          if (this.style.hScrollKnob != null)
            num = this.style.hScrollKnob.getMinWidth();
          if (this.style.hScroll != null)
            num = Math.max(num, this.style.hScroll.getMinWidth());
          x += num;
        }
      }
      this.widget.setPosition(x, y2);
      if (this.widget is Cullable)
      {
        this.widgetCullingArea.x = -this.widget.x + this.widgetAreaBounds.x;
        this.widgetCullingArea.y = -this.widget.y + this.widgetAreaBounds.y;
        this.widgetCullingArea.width = this.widgetAreaBounds.width;
        this.widgetCullingArea.height = this.widgetAreaBounds.height;
        ((Cullable) this.widget).setCullingArea(this.widgetCullingArea);
      }
      if (this.style.background != null)
        this.style.background.draw(0.0f, 0.0f, this.getWidth(), this.getHeight());
      Core.scene.calculateScissors(this.widgetAreaBounds, this.scissorBounds);
      if (this.clip)
      {
        if (ScissorStack.push(this.scissorBounds))
        {
          this.drawChildren();
          ScissorStack.pop();
        }
      }
      else
        this.drawChildren();
      Draw.color(this.__\u003C\u003Ecolor.r, this.__\u003C\u003Ecolor.g, this.__\u003C\u003Ecolor.b, this.__\u003C\u003Ecolor.a * this.parentAlpha * Interp.fade.apply(this.fadeAlpha / this.fadeAlphaSeconds));
      if (this.scrollX && this.scrollY && this.style.corner != null)
        this.style.corner.draw(this.hScrollBounds.x + this.hScrollBounds.width, this.hScrollBounds.y, this.vScrollBounds.width, this.vScrollBounds.y);
      if (this.scrollX)
      {
        if (this.style.hScroll != null)
          this.style.hScroll.draw(this.hScrollBounds.x, this.hScrollBounds.y, this.hScrollBounds.width, this.hScrollBounds.height);
        if (this.style.hScrollKnob != null)
          this.style.hScrollKnob.draw(this.hKnobBounds.x, this.hKnobBounds.y, this.hKnobBounds.width, this.hKnobBounds.height);
      }
      if (this.scrollY)
      {
        if (this.style.vScroll != null)
          this.style.vScroll.draw(this.vScrollBounds.x, this.vScrollBounds.y, this.vScrollBounds.width, this.vScrollBounds.height);
        if (this.style.vScrollKnob != null)
          this.style.vScrollKnob.draw(this.vKnobBounds.x, this.vKnobBounds.y, this.vKnobBounds.width, this.vKnobBounds.height);
      }
      this.resetTransform();
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void fling(float flingTime, float velocityX, float velocityY)
    {
      this.flingTimer = flingTime;
      this.velocityX = velocityX;
      this.velocityY = velocityY;
    }

    [LineNumberTable(new byte[] {162, 14, 102, 104, 102, 141, 127, 22, 104, 102, 127, 0, 127, 7, 133})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override float getPrefWidth()
    {
      float num1 = 0.0f;
      if (this.widget != null)
      {
        this.validate();
        num1 = this.widget.getPrefWidth();
      }
      if (this.style.background != null)
        num1 += this.style.background.getLeftWidth() + this.style.background.getRightWidth();
      if (this.scrollY)
      {
        float num2 = 0.0f;
        if (this.style.vScrollKnob != null)
          num2 = this.style.vScrollKnob.getMinWidth();
        if (this.style.vScroll != null)
          num2 = Math.max(num2, this.style.vScroll.getMinWidth());
        num1 += num2;
      }
      return num1;
    }

    [LineNumberTable(new byte[] {162, 31, 102, 104, 102, 141, 127, 22, 104, 102, 127, 0, 127, 7, 133})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override float getPrefHeight()
    {
      float num1 = 0.0f;
      if (this.widget != null)
      {
        this.validate();
        num1 = this.widget.getPrefHeight();
      }
      if (this.style.background != null)
        num1 += this.style.background.getTopHeight() + this.style.background.getBottomHeight();
      if (this.scrollX)
      {
        float num2 = 0.0f;
        if (this.style.hScrollKnob != null)
          num2 = this.style.hScrollKnob.getMinHeight();
        if (this.style.hScroll != null)
          num2 = Math.max(num2, this.style.hScroll.getMinHeight());
        num1 += num2;
      }
      return num1;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override float getMinWidth() => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override float getMinHeight() => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Element getWidget() => this.widget;

    [LineNumberTable(new byte[] {162, 74, 115, 112, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool removeChild(Element actor)
    {
      if (actor == null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException("actor cannot be null.");
      }
      if (!object.ReferenceEquals((object) actor, (object) this.widget))
        return false;
      this.setWidget((Element) null);
      return true;
    }

    [LineNumberTable(new byte[] {158, 221, 66, 115, 112, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool removeChild(Element actor, bool unfocus)
    {
      int num = unfocus ? 1 : 0;
      if (actor == null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException("actor cannot be null.");
      }
      if (!object.ReferenceEquals((object) actor, (object) this.widget))
        return false;
      this.widget = (Element) null;
      return base.removeChild(actor, num != 0);
    }

    [LineNumberTable(744)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual float getMouseWheelX() => Math.min(this.areaWidth, Math.max(this.areaWidth * 0.9f, this.maxX * 0.1f) / 4f);

    [LineNumberTable(749)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual float getMouseWheelY() => Math.min(this.areaHeight, Math.max(this.areaHeight * 0.9f, this.maxY * 0.1f) / 4f);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setScrollXForce(float pixels)
    {
      this.visualAmountX = pixels;
      this.amountX = pixels;
      this.scrollX = true;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getScrollX() => this.amountX;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getVisualScrollX() => !this.scrollX ? 0.0f : this.visualAmountX;

    [LineNumberTable(new byte[] {162, 202, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setFlickScrollTapSquareSize(float halfTapSquareSize) => this.flickScrollListener.getGestureDetector().setTapSquareSize(halfTapSquareSize);

    [LineNumberTable(new byte[] {162, 210, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void scrollTo(float x, float y, float width, float height) => this.scrollTo(x, y, width, height, false, false);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getMaxX() => this.maxX;

    [LineNumberTable(new byte[] {162, 248, 110, 102, 127, 0, 127, 7})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getScrollBarHeight()
    {
      if (!this.scrollX)
        return 0.0f;
      float num = 0.0f;
      if (this.style.hScrollKnob != null)
        num = this.style.hScrollKnob.getMinHeight();
      if (this.style.hScroll != null)
        num = Math.max(num, this.style.hScroll.getMinHeight());
      return num;
    }

    [LineNumberTable(new byte[] {163, 0, 110, 102, 127, 0, 127, 7})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getScrollBarWidth()
    {
      if (!this.scrollY)
        return 0.0f;
      float num = 0.0f;
      if (this.style.vScrollKnob != null)
        num = this.style.vScrollKnob.getMinWidth();
      if (this.style.vScroll != null)
        num = Math.max(num, this.style.vScroll.getMinWidth());
      return num;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getScrollWidth() => this.areaWidth;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getScrollHeight() => this.areaHeight;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isScrollX() => this.scrollX;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isScrollY() => this.scrollY;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isScrollingDisabledX() => this.disableX;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isScrollingDisabledY() => this.disableY;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isLeftEdge() => !this.scrollX || (double) this.amountX <= 0.0;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isRightEdge() => !this.scrollX || (double) this.amountX >= (double) this.maxX;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isTopEdge() => !this.scrollY || (double) this.amountY <= 0.0;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isBottomEdge() => !this.scrollY || (double) this.amountY >= (double) this.maxY;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isDragging() => this.draggingPointer != -1;

    [LineNumberTable(952)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isPanning() => this.flickScrollListener.getGestureDetector().isPanning();

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isFlinging() => (double) this.flingTimer > 0.0;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getVelocityX() => this.velocityX;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setVelocityX(float velocityX) => this.velocityX = velocityX;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getVelocityY() => this.velocityY;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setVelocityY(float velocityY) => this.velocityY = velocityY;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setupOverscroll(float distance, float speedMin, float speedMax)
    {
      this.overscrollDistance = distance;
      this.overscrollSpeedMin = speedMin;
      this.overscrollSpeedMax = speedMax;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setForceScroll(bool x, bool y)
    {
      int num1 = x ? 1 : 0;
      int num2 = y ? 1 : 0;
      this.forceScrollX = num1 != 0;
      this.forceScrollY = num2 != 0;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isForceScrollX() => this.forceScrollX;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isForceScrollY() => this.forceScrollY;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setFlingTime(float flingTime) => this.flingTime = flingTime;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setClamp(bool clamp) => this.clamp = clamp;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setScrollBarPositions(bool bottom, bool right)
    {
      int num1 = bottom ? 1 : 0;
      int num2 = right ? 1 : 0;
      this.hScrollOnBottom = num1 != 0;
      this.vScrollOnRight = num2 != 0;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setupFadeScrollBars(float fadeAlphaSeconds, float fadeDelaySeconds)
    {
      this.fadeAlphaSeconds = fadeAlphaSeconds;
      this.fadeDelaySeconds = fadeDelaySeconds;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setSmoothScrolling(bool smoothScrolling) => this.smoothScrolling = smoothScrolling;

    [LineNumberTable(new byte[] {158, 135, 66, 103, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setScrollbarsOnTop(bool scrollbarsOnTop)
    {
      this.scrollbarsOnTop = scrollbarsOnTop;
      this.invalidate();
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool getVariableSizeKnobs() => this.variableSizeKnobs;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setVariableSizeKnobs(bool variableSizeKnobs) => this.variableSizeKnobs = variableSizeKnobs;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setCancelTouchFocus(bool cancelTouchFocus) => this.cancelTouchFocus = cancelTouchFocus;

    [HideFromJava]
    static ScrollPane() => WidgetGroup.__\u003Cclinit\u003E();

    [EnclosingMethod(null, "<init>", "(Larc.scene.Element;Larc.scene.ui.ScrollPane$ScrollPaneStyle;)V")]
    [SpecialName]
    internal new class \u0031 : InputListener
    {
      private float handlePosition;
      [Modifiers]
      internal ScrollPane this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(77)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0031([In] ScrollPane obj0)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector();
      }

      [LineNumberTable(new byte[] {32, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void enter([In] InputEvent obj0, [In] float obj1, [In] float obj2, [In] int obj3, [In] Element obj4) => this.this\u00240.requestScroll();

      [LineNumberTable(new byte[] {37, 112, 116, 139, 152, 148, 127, 10, 102, 107, 118, 117, 118, 108, 109, 130, 127, 31, 130, 127, 10, 102, 107, 118, 117, 118, 108, 109, 130, 127, 31, 130})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override bool touchDown(
        [In] InputEvent obj0,
        [In] float obj1,
        [In] float obj2,
        [In] int obj3,
        [In] KeyCode obj4)
      {
        if (this.this\u00240.draggingPointer != -1 || obj3 == 0 && !object.ReferenceEquals((object) obj4, (object) KeyCode.__\u003C\u003EmouseLeft))
          return false;
        this.this\u00240.requestScroll();
        if (!this.this\u00240.flickScroll)
          this.this\u00240.resetFade();
        if ((double) this.this\u00240.fadeAlpha == 0.0)
          return false;
        if (this.this\u00240.scrollX && this.this\u00240.hScrollBounds.contains(obj1, obj2))
        {
          obj0.stop();
          this.this\u00240.resetFade();
          if (this.this\u00240.hKnobBounds.contains(obj1, obj2))
          {
            this.this\u00240.lastPoint.set(obj1, obj2);
            this.handlePosition = this.this\u00240.hKnobBounds.x;
            this.this\u00240.touchScrollH = true;
            this.this\u00240.draggingPointer = obj3;
            return true;
          }
          this.this\u00240.setScrollX(this.this\u00240.amountX + this.this\u00240.areaWidth * ((double) obj1 >= (double) this.this\u00240.hKnobBounds.x ? 1f : -1f));
          return true;
        }
        if (!this.this\u00240.scrollY || !this.this\u00240.vScrollBounds.contains(obj1, obj2))
          return false;
        obj0.stop();
        this.this\u00240.resetFade();
        if (this.this\u00240.vKnobBounds.contains(obj1, obj2))
        {
          this.this\u00240.lastPoint.set(obj1, obj2);
          this.handlePosition = this.this\u00240.vKnobBounds.y;
          this.this\u00240.touchScrollV = true;
          this.this\u00240.draggingPointer = obj3;
          return true;
        }
        this.this\u00240.setScrollY(this.this\u00240.amountY + this.this\u00240.areaHeight * ((double) obj2 >= (double) this.this\u00240.vKnobBounds.y ? -1f : 1f));
        return true;
      }

      [LineNumberTable(new byte[] {76, 112, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void touchUp(
        [In] InputEvent obj0,
        [In] float obj1,
        [In] float obj2,
        [In] int obj3,
        [In] KeyCode obj4)
      {
        if (obj3 != this.this\u00240.draggingPointer)
          return;
        this.this\u00240.cancel();
      }

      [LineNumberTable(new byte[] {82, 112, 112, 117, 106, 103, 120, 127, 29, 127, 4, 127, 10, 117, 117, 117, 106, 103, 120, 127, 29, 127, 4, 127, 17, 149})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void touchDragged([In] InputEvent obj0, [In] float obj1, [In] float obj2, [In] int obj3)
      {
        if (obj3 != this.this\u00240.draggingPointer)
          return;
        if (this.this\u00240.touchScrollH)
        {
          float num1 = this.handlePosition + (obj1 - this.this\u00240.lastPoint.x);
          this.handlePosition = num1;
          float num2 = Math.min(this.this\u00240.hScrollBounds.x + this.this\u00240.hScrollBounds.width - this.this\u00240.hKnobBounds.width, Math.max(this.this\u00240.hScrollBounds.x, num1));
          float num3 = this.this\u00240.hScrollBounds.width - this.this\u00240.hKnobBounds.width;
          if ((double) num3 != 0.0)
            this.this\u00240.setScrollPercentX((num2 - this.this\u00240.hScrollBounds.x) / num3);
          this.this\u00240.lastPoint.set(obj1, obj2);
        }
        else
        {
          if (!this.this\u00240.touchScrollV)
            return;
          float num1 = this.handlePosition + (obj2 - this.this\u00240.lastPoint.y);
          this.handlePosition = num1;
          float num2 = Math.min(this.this\u00240.vScrollBounds.y + this.this\u00240.vScrollBounds.height - this.this\u00240.vKnobBounds.height, Math.max(this.this\u00240.vScrollBounds.y, num1));
          float num3 = this.this\u00240.vScrollBounds.height - this.this\u00240.vKnobBounds.height;
          if ((double) num3 != 0.0)
            this.this\u00240.setScrollPercentY(1f - (num2 - this.this\u00240.vScrollBounds.y) / num3);
          this.this\u00240.lastPoint.set(obj1, obj2);
        }
      }

      [LineNumberTable(new byte[] {106, 120, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override bool mouseMoved([In] InputEvent obj0, [In] float obj1, [In] float obj2)
      {
        if (!this.this\u00240.flickScroll)
          this.this\u00240.resetFade();
        this.this\u00240.requestScroll();
        return false;
      }

      [HideFromJava]
      static \u0031() => InputListener.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "<init>", "(Larc.scene.Element;Larc.scene.ui.ScrollPane$ScrollPaneStyle;)V")]
    [SpecialName]
    internal new class \u0032 : ElementGestureListener
    {
      [Modifiers]
      internal ScrollPane this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(162)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0032([In] ScrollPane obj0)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector();
      }

      [LineNumberTable(new byte[] {115, 107, 118, 118, 107, 127, 39})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void pan([In] InputEvent obj0, [In] float obj1, [In] float obj2, [In] float obj3, [In] float obj4)
      {
        this.this\u00240.resetFade();
        this.this\u00240.amountX -= obj3;
        this.this\u00240.amountY += obj4;
        this.this\u00240.clamp();
        if (!this.this\u00240.cancelTouchFocus || (!this.this\u00240.scrollX || (double) obj3 == 0.0) && (!this.this\u00240.scrollY || (double) obj4 == 0.0))
          return;
        this.this\u00240.cancelTouchFocus();
      }

      [LineNumberTable(new byte[] {124, 124, 118, 109, 152, 124, 118, 110, 152})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void fling([In] InputEvent obj0, [In] float obj1, [In] float obj2, [In] KeyCode obj3)
      {
        if ((double) Math.abs(obj1) > 150.0 && this.this\u00240.scrollX)
        {
          this.this\u00240.flingTimer = this.this\u00240.flingTime;
          this.this\u00240.velocityX = obj1;
          if (this.this\u00240.cancelTouchFocus)
            this.this\u00240.cancelTouchFocus();
        }
        if ((double) Math.abs(obj2) <= 150.0 || !this.this\u00240.scrollY)
          return;
        this.this\u00240.flingTimer = this.this\u00240.flingTime;
        this.this\u00240.velocityY = -obj2;
        if (!this.this\u00240.cancelTouchFocus)
          return;
        this.this\u00240.cancelTouchFocus();
      }

      [LineNumberTable(new byte[] {160, 74, 105, 127, 8, 130})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override bool handle([In] SceneEvent obj0)
      {
        if (!base.handle(obj0))
          return false;
        if (object.ReferenceEquals((object) ((InputEvent) obj0).type, (object) InputEvent.InputEventType.__\u003C\u003EtouchDown))
          this.this\u00240.flingTimer = 0.0f;
        return true;
      }

      [HideFromJava]
      static \u0032() => ElementGestureListener.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "<init>", "(Larc.scene.Element;Larc.scene.ui.ScrollPane$ScrollPaneStyle;)V")]
    [SpecialName]
    internal new class \u0033 : InputListener
    {
      [Modifiers]
      internal ScrollPane this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(197)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0033([In] ScrollPane obj0)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector();
      }

      [LineNumberTable(new byte[] {160, 86, 107, 127, 23, 127, 23})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override bool scrolled(
        [In] InputEvent obj0,
        [In] float obj1,
        [In] float obj2,
        [In] float obj3,
        [In] float obj4)
      {
        this.this\u00240.resetFade();
        if (this.this\u00240.scrollY)
          this.this\u00240.setScrollY(this.this\u00240.amountY + this.this\u00240.getMouseWheelY() * obj4);
        if (this.this\u00240.scrollX)
          this.this\u00240.setScrollX(this.this\u00240.amountX + this.this\u00240.getMouseWheelX() * obj3);
        return this.this\u00240.scrollX || this.this\u00240.scrollY;
      }

      [HideFromJava]
      static \u0033() => InputListener.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "<init>", "(Larc.scene.Element;Larc.scene.ui.ScrollPane$ScrollPaneStyle;)V")]
    [SpecialName]
    internal new class \u0034 : InputListener
    {
      internal bool on;
      [Modifiers]
      internal ScrollPane this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {160, 93, 111})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0034([In] ScrollPane obj0)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector();
        ScrollPane.\u0034 obj = this;
        this.on = false;
      }

      [LineNumberTable(new byte[] {160, 98, 113, 113, 112, 108, 162})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override bool touchDown(
        [In] InputEvent obj0,
        [In] float obj1,
        [In] float obj2,
        [In] int obj3,
        [In] KeyCode obj4)
      {
        Element element = this.this\u00240.hit(obj1, obj2, true);
        this.on = this.this\u00240.flickScroll;
        if (!(element is Slider) || !this.on)
          return base.touchDown(obj0, obj1, obj2, obj3, obj4);
        this.this\u00240.setFlickScroll(false);
        return true;
      }

      [LineNumberTable(new byte[] {160, 110, 104, 140, 111})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void touchUp(
        [In] InputEvent obj0,
        [In] float obj1,
        [In] float obj2,
        [In] int obj3,
        [In] KeyCode obj4)
      {
        if (this.on)
          this.this\u00240.setFlickScroll(true);
        base.touchUp(obj0, obj1, obj2, obj3, obj4);
      }

      [HideFromJava]
      static \u0034() => InputListener.__\u003Cclinit\u003E();
    }

    public class ScrollPaneStyle : Style
    {
      public Drawable background;
      public Drawable corner;
      public Drawable hScroll;
      public Drawable hScrollKnob;
      public Drawable vScroll;
      public Drawable vScrollKnob;

      [LineNumberTable(new byte[] {163, 207, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public ScrollPaneStyle()
      {
      }

      [LineNumberTable(new byte[] {163, 210, 104, 108, 108, 108, 108, 108})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public ScrollPaneStyle(ScrollPane.ScrollPaneStyle style)
      {
        ScrollPane.ScrollPaneStyle scrollPaneStyle = this;
        this.background = style.background;
        this.hScroll = style.hScroll;
        this.hScrollKnob = style.hScrollKnob;
        this.vScroll = style.vScroll;
        this.vScrollKnob = style.vScrollKnob;
      }
    }
  }
}
