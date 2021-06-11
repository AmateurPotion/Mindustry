// Decompiled with JetBrains decompiler
// Type: arc.scene.ui.Slider
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.func;
using arc.input;
using arc.math;
using arc.scene.@event;
using arc.scene.style;
using arc.util.pooling;
using ikvm.@internal;
using IKVM.Attributes;
using java.lang;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.scene.ui
{
  public class Slider : ProgressBar
  {
    internal int draggingPointer;
    internal bool mouseOver;
    private Interp visualInterpolationInverse;
    private float[] snapValues;
    private float threshold;

    [LineNumberTable(new byte[] {159, 133, 131, 127, 2})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Slider(float min, float max, float stepSize, bool vertical)
    {
      int num = vertical ? 1 : 0;
      // ISSUE: explicit constructor call
      this.\u002Ector(min, max, stepSize, num != 0, (Slider.SliderStyle) Core.scene.getStyle((Class) ClassLiteral<Slider.SliderStyle>.Value));
    }

    [LineNumberTable(new byte[] {103, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void moved(Floatc listener) => this.changed((Runnable) new Slider.__\u003C\u003EAnon0(this, listener));

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setSnapToValues(float[] values, float threshold)
    {
      this.snapValues = values;
      this.threshold = threshold;
    }

    [LineNumberTable(new byte[] {68, 103, 103, 191, 0, 135, 105, 137, 107, 123, 115, 124, 127, 9, 119, 120, 101, 123, 115, 124, 127, 9, 119, 184, 100, 127, 3, 107, 106, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual bool calculatePositionAndValue([In] float obj0, [In] float obj1)
    {
      Slider.SliderStyle style = this.getStyle();
      Drawable knobDrawable = this.getKnobDrawable();
      Drawable drawable = !this.disabled || style.disabledBackground == null ? style.background : style.disabledBackground;
      float position = this.position;
      float minValue = this.getMinValue();
      float maxValue = this.getMaxValue();
      float num1;
      if (this.vertical)
      {
        float num2 = this.getHeight() - drawable.getTopHeight() - drawable.getBottomHeight();
        float num3 = knobDrawable != null ? knobDrawable.getMinHeight() : 0.0f;
        this.position = obj1 - drawable.getBottomHeight() - num3 * 0.5f;
        num1 = minValue + (maxValue - minValue) * this.visualInterpolationInverse.apply(this.position / (num2 - num3));
        this.position = Math.max(0.0f, this.position);
        this.position = Math.min(num2 - num3, this.position);
      }
      else
      {
        float num2 = this.getWidth() - drawable.getLeftWidth() - drawable.getRightWidth();
        float num3 = knobDrawable != null ? knobDrawable.getMinWidth() : 0.0f;
        this.position = obj0 - drawable.getLeftWidth() - num3 * 0.5f;
        num1 = minValue + (maxValue - minValue) * this.visualInterpolationInverse.apply(this.position / (num2 - num3));
        this.position = Math.max(0.0f, this.position);
        this.position = Math.min(num2 - num3, this.position);
      }
      float num4 = num1;
      if (!Core.input.keyDown(KeyCode.__\u003C\u003EshiftLeft) && !Core.input.keyDown(KeyCode.__\u003C\u003EshiftRight))
        num1 = this.snap(num1);
      int num5 = this.setValue(num1) ? 1 : 0;
      if ((double) num1 == (double) num4)
        this.position = position;
      return num5 != 0;
    }

    [LineNumberTable(new byte[] {159, 129, 67, 241, 43, 135, 235, 85, 108, 237, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Slider(float min, float max, float stepSize, bool vertical, Slider.SliderStyle style)
    {
      int num = vertical ? 1 : 0;
      // ISSUE: explicit constructor call
      base.\u002Ector(min, max, stepSize, num != 0, (ProgressBar.ProgressBarStyle) style);
      Slider slider = this;
      this.draggingPointer = -1;
      this.visualInterpolationInverse = Interp.linear;
      this.addListener((EventListener) new HandCursorListener());
      this.addListener((EventListener) new Slider.\u0031(this));
    }

    [LineNumberTable(100)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Slider.SliderStyle getStyle() => (Slider.SliderStyle) __nonvirtual (((ProgressBar) this).getStyle());

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isDragging() => this.draggingPointer != -1;

    [LineNumberTable(new byte[] {61, 103, 120, 120, 30})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override Drawable getKnobDrawable()
    {
      Slider.SliderStyle style = this.getStyle();
      if (this.disabled && style.disabledKnob != null)
        return style.disabledKnob;
      if (this.isDragging() && style.knobDown != null)
        return style.knobDown;
      return this.mouseOver && style.knobOver != null ? style.knobOver : style.knob;
    }

    [LineNumberTable(new byte[] {108, 107, 108, 63, 4, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual float snap(float value)
    {
      if (this.snapValues == null)
        return value;
      for (int index = 0; index < this.snapValues.Length; ++index)
      {
        if ((double) Math.abs(value - this.snapValues[index]) <= (double) this.threshold)
          return this.snapValues[index];
      }
      return value;
    }

    [Modifiers]
    [LineNumberTable(153)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024moved\u00240([In] Floatc obj0) => obj0.get(this.getValue());

    [LineNumberTable(new byte[] {54, 115, 120, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setStyle(Slider.SliderStyle style)
    {
      if (style == null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new NullPointerException("style cannot be null");
      }
      if (!(style is Slider.SliderStyle))
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException("style must be a SliderStyle.");
      }
      this.setStyle((ProgressBar.ProgressBarStyle) style);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setVisualInterpolationInverse(Interp interpolation) => this.visualInterpolationInverse = interpolation;

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(30)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual ProgressBar.ProgressBarStyle \u003Cbridge\u003EgetStyle() => (ProgressBar.ProgressBarStyle) this.getStyle();

    [EnclosingMethod(null, "<init>", "(FFFZLarc.scene.ui.Slider$SliderStyle;)V")]
    [SpecialName]
    internal new class \u0031 : InputListener
    {
      [Modifiers]
      internal Slider this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(55)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0031([In] Slider obj0)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector();
      }

      [LineNumberTable(new byte[] {8, 111, 112, 109, 112})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override bool touchDown(
        [In] InputEvent obj0,
        [In] float obj1,
        [In] float obj2,
        [In] int obj3,
        [In] KeyCode obj4)
      {
        if (this.this\u00240.disabled || this.this\u00240.draggingPointer != -1)
          return false;
        this.this\u00240.draggingPointer = obj3;
        this.this\u00240.calculatePositionAndValue(obj1, obj2);
        return true;
      }

      [LineNumberTable(new byte[] {17, 112, 108, 145, 122, 109, 134})]
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
        this.this\u00240.draggingPointer = -1;
        if (this.this\u00240.calculatePositionAndValue(obj1, obj2))
          return;
        ChangeListener.ChangeEvent changeEvent = (ChangeListener.ChangeEvent) Pools.obtain((Class) ClassLiteral<ChangeListener.ChangeEvent>.Value, (Prov) new Slider.\u0031.__\u003C\u003EAnon0());
        this.this\u00240.fire((SceneEvent) changeEvent);
        Pools.free((object) changeEvent);
      }

      [LineNumberTable(new byte[] {29, 112})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void touchDragged([In] InputEvent obj0, [In] float obj1, [In] float obj2, [In] int obj3) => this.this\u00240.calculatePositionAndValue(obj1, obj2);

      [LineNumberTable(new byte[] {34, 113})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void enter([In] InputEvent obj0, [In] float obj1, [In] float obj2, [In] int obj3, [In] Element obj4)
      {
        if (obj3 != -1)
          return;
        this.this\u00240.mouseOver = true;
      }

      [LineNumberTable(new byte[] {39, 113})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void exit([In] InputEvent obj0, [In] float obj1, [In] float obj2, [In] int obj3, [In] Element obj4)
      {
        if (obj3 != -1)
          return;
        this.this\u00240.mouseOver = false;
      }

      [HideFromJava]
      static \u0031() => InputListener.__\u003Cclinit\u003E();

      [SpecialName]
      private sealed class __\u003C\u003EAnon0 : Prov
      {
        internal __\u003C\u003EAnon0()
        {
        }

        public object get() => (object) new ChangeListener.ChangeEvent();
      }
    }

    public class SliderStyle : ProgressBar.ProgressBarStyle
    {
      public Drawable knobOver;
      public Drawable knobDown;

      [LineNumberTable(192)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public SliderStyle()
      {
      }
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon0 : Runnable
    {
      private readonly Slider arg\u00241;
      private readonly Floatc arg\u00242;

      internal __\u003C\u003EAnon0([In] Slider obj0, [In] Floatc obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => this.arg\u00241.lambda\u0024moved\u00240(this.arg\u00242);
    }
  }
}
