// Decompiled with JetBrains decompiler
// Type: arc.scene.ui.ProgressBar
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.func;
using arc.graphics;
using arc.graphics.g2d;
using arc.math;
using arc.scene.@event;
using arc.scene.style;
using arc.scene.utils;
using arc.util.pooling;
using ikvm.@internal;
using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;

namespace arc.scene.ui
{
  [Implements(new string[] {"arc.scene.utils.Disableable"})]
  public class ProgressBar : Element, Disableable
  {
    [Modifiers]
    internal bool vertical;
    internal float position;
    internal bool disabled;
    private ProgressBar.ProgressBarStyle style;
    private float min;
    private float max;
    private float stepSize;
    private float value;
    private float animateFromValue;
    private float animateDuration;
    private float animateTime;
    private Interp animateInterpolation;
    private Interp visualInterpolation;
    private bool round;

    [LineNumberTable(new byte[] {160, 132, 127, 2, 103, 103, 104, 104, 122, 104, 99, 105, 109, 103, 140, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool setValue(float value)
    {
      value = this.clamp((float) Math.round(value / this.stepSize) * this.stepSize);
      float num1 = this.value;
      if ((double) value == (double) num1)
        return false;
      float visualValue = this.getVisualValue();
      this.value = value;
      ChangeListener.ChangeEvent changeEvent = (ChangeListener.ChangeEvent) Pools.obtain((Class) ClassLiteral<ChangeListener.ChangeEvent>.Value, (Prov) new ProgressBar.__\u003C\u003EAnon0());
      int num2 = this.fire((SceneEvent) changeEvent) ? 1 : 0;
      if (num2 != 0)
        this.value = num1;
      else if ((double) this.animateDuration > 0.0)
      {
        this.animateFromValue = visualValue;
        this.animateTime = this.animateDuration;
      }
      Pools.free((object) changeEvent);
      return num2 == 0;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getValue() => this.value;

    [LineNumberTable(new byte[] {21, 115, 103, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setStyle(ProgressBar.ProgressBarStyle style)
    {
      if (style == null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException("style cannot be null.");
      }
      this.style = style;
      this.invalidateHierarchy();
    }

    [LineNumberTable(new byte[] {160, 169, 104, 103, 127, 15, 159, 0})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override float getPrefWidth()
    {
      if (!this.vertical)
        return 140f;
      Drawable knobDrawable = this.getKnobDrawable();
      Drawable drawable = !this.disabled || this.style.disabledBackground == null ? this.style.background : this.style.disabledBackground;
      return Math.max(knobDrawable != null ? knobDrawable.getMinWidth() : 0.0f, drawable.getMinWidth());
    }

    [LineNumberTable(new byte[] {160, 179, 104, 134, 103, 127, 15})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override float getPrefHeight()
    {
      if (this.vertical)
        return 140f;
      Drawable knobDrawable = this.getKnobDrawable();
      Drawable drawable = !this.disabled || this.style.disabledBackground == null ? this.style.background : this.style.disabledBackground;
      return Math.max(knobDrawable != null ? knobDrawable.getMinHeight() : 0.0f, drawable != null ? drawable.getMinHeight() : 0.0f);
    }

    [LineNumberTable(231)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual Drawable getKnobDrawable() => this.disabled && this.style.disabledKnob != null ? this.style.disabledKnob : this.style.knob;

    [LineNumberTable(227)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getVisualPercent() => this.visualInterpolation.apply((this.getVisualValue() - this.min) / (this.max - this.min));

    [LineNumberTable(new byte[] {160, 103, 109, 127, 15})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getVisualValue() => (double) this.animateTime > 0.0 ? this.animateInterpolation.apply(this.animateFromValue, this.value, 1f - this.animateTime / this.animateDuration) : this.value;

    [LineNumberTable(268)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual float clamp(float value) => Mathf.clamp(value, this.min, this.max);

    [LineNumberTable(new byte[] {159, 130, 131, 232, 48, 107, 107, 231, 79, 127, 30, 127, 16, 104, 104, 104, 104, 103, 104, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ProgressBar(
      float min,
      float max,
      float stepSize,
      bool vertical,
      ProgressBar.ProgressBarStyle style)
    {
      int num = vertical ? 1 : 0;
      // ISSUE: explicit constructor call
      base.\u002Ector();
      ProgressBar progressBar = this;
      this.animateInterpolation = Interp.linear;
      this.visualInterpolation = Interp.linear;
      this.round = true;
      if ((double) min > (double) max)
      {
        string str = new StringBuilder().append("max must be > min. min,max: ").append(min).append(", ").append(max).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException(str);
      }
      if ((double) stepSize <= 0.0)
      {
        string str = new StringBuilder().append("stepSize must be > 0: ").append(stepSize).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException(str);
      }
      this.setStyle(style);
      this.min = min;
      this.max = max;
      this.stepSize = stepSize;
      this.vertical = num != 0;
      this.value = min;
      this.setSize(this.getPrefWidth(), this.getPrefHeight());
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual ProgressBar.ProgressBarStyle getStyle() => this.style;

    [LineNumberTable(new byte[] {28, 104, 109, 112, 103, 149})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void act(float delta)
    {
      base.act(delta);
      if ((double) this.animateTime <= 0.0)
        return;
      this.animateTime -= delta;
      Scene scene = this.getScene();
      if (scene == null || !scene.getActionsRequestRendering())
        return;
      Core.graphics.requestRendering();
    }

    [LineNumberTable(new byte[] {38, 103, 103, 103, 122, 123, 155, 104, 104, 104, 105, 105, 115, 115, 137, 159, 10, 107, 132, 103, 102, 104, 159, 22, 127, 8, 105, 177, 103, 113, 99, 124, 112, 154, 107, 112, 159, 2, 183, 103, 103, 103, 104, 127, 36, 38, 167, 191, 23, 103, 104, 127, 22, 63, 1, 167, 127, 10, 52, 165, 102, 104, 159, 32, 159, 6, 101, 132, 103, 102, 104, 159, 22, 127, 8, 105, 177, 103, 113, 99, 124, 112, 154, 107, 112, 156, 183, 103, 103, 103, 104, 127, 22, 52, 167, 127, 12, 38, 165, 103, 104, 127, 34, 52, 167, 127, 24, 38, 165, 102, 104, 159, 32, 191, 6})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void draw()
    {
      ProgressBar.ProgressBarStyle style = this.style;
      int num1 = this.disabled ? 1 : 0;
      Drawable knobDrawable = this.getKnobDrawable();
      Drawable drawable1 = num1 == 0 || style.disabledBackground == null ? style.background : style.disabledBackground;
      Drawable drawable2 = num1 == 0 || style.disabledKnobBefore == null ? style.knobBefore : style.disabledKnobBefore;
      Drawable drawable3 = num1 == 0 || style.disabledKnobAfter == null ? style.knobAfter : style.disabledKnobAfter;
      Color color = this.__\u003C\u003Ecolor;
      float x = this.x;
      float y = this.y;
      float width = this.getWidth();
      float height = this.getHeight();
      float f4 = knobDrawable != null ? knobDrawable.getMinHeight() : 0.0f;
      float f3 = knobDrawable != null ? knobDrawable.getMinWidth() : 0.0f;
      float visualPercent = this.getVisualPercent();
      Draw.color(color.r, color.g, color.b, color.a * this.parentAlpha);
      if (this.vertical)
      {
        float num2 = height;
        float num3 = 0.0f;
        if (drawable1 != null)
        {
          if (this.round)
            drawable1.draw((float) Math.round(x + (width - drawable1.getMinWidth()) * 0.5f), y, (float) Math.round(drawable1.getMinWidth()), height);
          else
            drawable1.draw(x + width - drawable1.getMinWidth() * 0.5f, y, drawable1.getMinWidth(), height);
          num3 = drawable1.getTopHeight();
          num2 -= num3 + drawable1.getBottomHeight();
        }
        float num4 = 0.0f;
        if ((double) this.min != (double) this.max)
        {
          if (knobDrawable == null)
          {
            num4 = drawable2 != null ? drawable2.getMinHeight() * 0.5f : 0.0f;
            this.position = (num2 - num4) * visualPercent;
            this.position = Math.min(num2 - num4, this.position);
          }
          else
          {
            num4 = f4 * 0.5f;
            this.position = (num2 - f4) * visualPercent;
            this.position = Math.min(num2 - f4, this.position) + drawable1.getBottomHeight();
          }
          this.position = Math.max(0.0f, this.position);
        }
        if (drawable2 != null)
        {
          float num5 = 0.0f;
          if (drawable1 != null)
            num5 = num3;
          if (this.round)
            drawable2.draw((float) Math.round(x + (width - drawable2.getMinWidth()) * 0.5f), (float) Math.round(y + num5), (float) Math.round(drawable2.getMinWidth()), (float) Math.round(this.position + num4));
          else
            drawable2.draw(x + (width - drawable2.getMinWidth()) * 0.5f, y + num5, drawable2.getMinWidth(), this.position + num4);
        }
        if (drawable3 != null)
        {
          if (this.round)
            drawable3.draw((float) Math.round(x + (width - drawable3.getMinWidth()) * 0.5f), (float) Math.round(y + this.position + num4), (float) Math.round(drawable3.getMinWidth()), (float) Math.round(height - this.position - num4));
          else
            drawable3.draw(x + (width - drawable3.getMinWidth()) * 0.5f, y + this.position + num4, drawable3.getMinWidth(), height - this.position - num4);
        }
        if (knobDrawable == null)
          return;
        if (this.round)
          knobDrawable.draw((float) Math.round(x + (width - f3) * 0.5f), (float) Math.round(y + this.position), (float) Math.round(f3), (float) Math.round(f4));
        else
          knobDrawable.draw(x + (width - f3) * 0.5f, y + this.position, f3, f4);
      }
      else
      {
        float num2 = width;
        float num3 = 0.0f;
        if (drawable1 != null)
        {
          if (this.round)
            drawable1.draw(x, (float) Math.round(y + (height - drawable1.getMinHeight()) * 0.5f), width, (float) Math.round(drawable1.getMinHeight()));
          else
            drawable1.draw(x, y + (height - drawable1.getMinHeight()) * 0.5f, width, drawable1.getMinHeight());
          num3 = drawable1.getLeftWidth();
          num2 -= num3 + drawable1.getRightWidth();
        }
        float num4 = 0.0f;
        if ((double) this.min != (double) this.max)
        {
          if (knobDrawable == null)
          {
            num4 = drawable2 != null ? drawable2.getMinWidth() * 0.5f : 0.0f;
            this.position = (num2 - num4) * visualPercent;
            this.position = Math.min(num2 - num4, this.position);
          }
          else
          {
            num4 = f3 * 0.5f;
            this.position = (num2 - f3) * visualPercent;
            this.position = Math.min(num2 - f3, this.position) + num3;
          }
          this.position = Math.max(0.0f, this.position);
        }
        if (drawable2 != null)
        {
          float num5 = 0.0f;
          if (drawable1 != null)
            num5 = num3;
          if (this.round)
            drawable2.draw((float) Math.round(x + num5), (float) Math.round(y + (height - drawable2.getMinHeight()) * 0.5f), (float) Math.round(this.position + num4), (float) Math.round(drawable2.getMinHeight()));
          else
            drawable2.draw(x + num5, y + (height - drawable2.getMinHeight()) * 0.5f, this.position + num4, drawable2.getMinHeight());
        }
        if (drawable3 != null)
        {
          if (this.round)
            drawable3.draw((float) Math.round(x + this.position + num4), (float) Math.round(y + (height - drawable3.getMinHeight()) * 0.5f), (float) Math.round(width - this.position - num4), (float) Math.round(drawable3.getMinHeight()));
          else
            drawable3.draw(x + this.position + num4, y + (height - drawable3.getMinHeight()) * 0.5f, width - this.position - num4, drawable3.getMinHeight());
        }
        if (knobDrawable == null)
          return;
        if (this.round)
          knobDrawable.draw((float) Math.round(x + this.position), (float) Math.round(y + (height - f4) * 0.5f), (float) Math.round(f3), (float) Math.round(f4));
        else
          knobDrawable.draw(x + this.position, y + (height - f4) * 0.5f, f3, f4);
      }
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getPercent() => (this.value - this.min) / (this.max - this.min);

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual float getKnobPosition() => this.position;

    [LineNumberTable(new byte[] {160, 159, 118, 104, 104, 106, 107, 115})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setRange(float min, float max)
    {
      if ((double) min > (double) max)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException("min must be <= max");
      }
      this.min = min;
      this.max = max;
      if ((double) this.value < (double) min)
      {
        this.setValue(min);
      }
      else
      {
        if ((double) this.value <= (double) max)
          return;
        this.setValue(max);
      }
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getMinValue() => this.min;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getMaxValue() => this.max;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getStepSize() => this.stepSize;

    [LineNumberTable(new byte[] {160, 201, 127, 16, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setStepSize(float stepSize)
    {
      if ((double) stepSize <= 0.0)
      {
        string str = new StringBuilder().append("steps must be > 0: ").append(stepSize).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException(str);
      }
      this.stepSize = stepSize;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setAnimateDuration(float duration) => this.animateDuration = duration;

    [LineNumberTable(new byte[] {160, 212, 115, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setAnimateInterpolation(Interp animateInterpolation)
    {
      if (animateInterpolation == null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException("animateInterpolation cannot be null.");
      }
      this.animateInterpolation = animateInterpolation;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setVisualInterpolation(Interp interpolation) => this.visualInterpolation = interpolation;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setRound(bool round) => this.round = round;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isDisabled() => this.disabled;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setDisabled(bool disabled) => this.disabled = disabled;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isVertical() => this.vertical;

    public class ProgressBarStyle : Style
    {
      public Drawable background;
      public Drawable disabledBackground;
      public Drawable knob;
      public Drawable disabledKnob;
      public Drawable knobBefore;
      public Drawable knobAfter;
      public Drawable disabledKnobBefore;
      public Drawable disabledKnobAfter;

      [LineNumberTable(new byte[] {161, 0, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public ProgressBarStyle()
      {
      }

      [LineNumberTable(new byte[] {161, 3, 104, 103, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public ProgressBarStyle(Drawable background, Drawable knob)
      {
        ProgressBar.ProgressBarStyle progressBarStyle = this;
        this.background = background;
        this.knob = knob;
      }

      [LineNumberTable(new byte[] {161, 8, 104, 108, 108, 108, 108, 108, 108, 108, 108})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public ProgressBarStyle(ProgressBar.ProgressBarStyle style)
      {
        ProgressBar.ProgressBarStyle progressBarStyle = this;
        this.background = style.background;
        this.disabledBackground = style.disabledBackground;
        this.knob = style.knob;
        this.disabledKnob = style.disabledKnob;
        this.knobBefore = style.knobBefore;
        this.knobAfter = style.knobAfter;
        this.disabledKnobBefore = style.disabledKnobBefore;
        this.disabledKnobAfter = style.disabledKnobAfter;
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
