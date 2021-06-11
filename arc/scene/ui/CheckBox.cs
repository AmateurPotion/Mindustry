// Decompiled with JetBrains decompiler
// Type: arc.scene.ui.CheckBox
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.scene.style;
using arc.scene.ui.layout;
using arc.util;
using ikvm.@internal;
using IKVM.Attributes;
using java.lang;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace arc.scene.ui
{
  public class CheckBox : TextButton
  {
    private Image image;
    private Cell imageCell;
    private CheckBox.CheckBoxStyle style;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cell getImageCell() => this.imageCell;

    [LineNumberTable(new byte[] {159, 166, 106, 102, 103, 127, 8, 127, 2, 103, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public CheckBox(string text, CheckBox.CheckBoxStyle style)
      : base(text, (TextButton.TextButtonStyle) style)
    {
      CheckBox checkBox1 = this;
      this.clearChildren();
      Label label = this.getLabel();
      CheckBox checkBox2 = this;
      Image image1 = new Image(style.checkboxOff, Scaling.__\u003C\u003Estretch);
      Image image2 = image1;
      this.image = image1;
      this.imageCell = this.add((Element) image2);
      ((Label) this.add((Element) label).padLeft(4f).get()).setWrap(false);
      label.setAlignment(8);
      this.setSize(this.getPrefWidth(), this.getPrefHeight());
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual CheckBox.CheckBoxStyle getStyle() => this.style;

    [LineNumberTable(new byte[] {159, 162, 123})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public CheckBox(string text)
      : this(text, (CheckBox.CheckBoxStyle) Core.scene.getStyle((Class) ClassLiteral<CheckBox.CheckBoxStyle>.Value))
    {
    }

    [LineNumberTable(new byte[] {159, 186, 120, 103, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setStyle(Button.ButtonStyle style)
    {
      if (!(style is CheckBox.CheckBoxStyle))
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException("style must be a CheckBoxStyle.");
      }
      base.setStyle(style);
      this.style = (CheckBox.CheckBoxStyle) style;
    }

    [LineNumberTable(new byte[] {1, 98, 104, 117, 142, 140, 102, 125, 110, 117, 110, 125, 142, 140, 108, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void draw()
    {
      Drawable drawable = (Drawable) null;
      if (this.isDisabled())
        drawable = !this.isChecked || this.style.checkboxOnDisabled == null ? this.style.checkboxOffDisabled : this.style.checkboxOnDisabled;
      if (drawable == null)
        drawable = !this.isChecked || !this.isOver() || this.style.checkboxOnOver == null ? (!this.isChecked || this.style.checkboxOn == null ? (!this.isOver() || this.style.checkboxOver == null || this.isDisabled() ? this.style.checkboxOff : this.style.checkboxOver) : this.style.checkboxOn) : this.style.checkboxOnOver;
      this.image.setDrawable(drawable);
      base.draw();
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Image getImage() => this.image;

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(14)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual TextButton.TextButtonStyle \u003Cbridge\u003EgetStyle() => (TextButton.TextButtonStyle) this.getStyle();

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(14)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override Button.ButtonStyle \u003Cbridge\u003EgetStyle() => (Button.ButtonStyle) this.getStyle();

    [HideFromJava]
    static CheckBox() => TextButton.__\u003Cclinit\u003E();

    public class CheckBoxStyle : TextButton.TextButtonStyle
    {
      public Drawable checkboxOn;
      public Drawable checkboxOff;
      public Drawable checkboxOver;
      public Drawable checkboxOnDisabled;
      public Drawable checkboxOffDisabled;
      public Drawable checkboxOnOver;

      [LineNumberTable(84)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public CheckBoxStyle()
      {
      }
    }
  }
}
