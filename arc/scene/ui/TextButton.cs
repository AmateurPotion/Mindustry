// Decompiled with JetBrains decompiler
// Type: arc.scene.ui.TextButton
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.graphics;
using arc.graphics.g2d;
using arc.scene.style;
using arc.scene.ui.layout;
using ikvm.@internal;
using IKVM.Attributes;
using java.lang;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.scene.ui
{
  public class TextButton : Button
  {
    internal Label __\u003C\u003Elabel;
    private TextButton.TextButtonStyle style;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 163, 123})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public TextButton(string text)
      : this(text, (TextButton.TextButtonStyle) Core.scene.getStyle((Class) ClassLiteral<TextButton.TextButtonStyle>.Value))
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Label getLabel() => this.__\u003C\u003Elabel;

    [LineNumberTable(new byte[] {159, 167, 104, 103, 103, 127, 21, 108, 127, 9, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public TextButton(string text, TextButton.TextButtonStyle style)
    {
      TextButton textButton = this;
      this.setStyle((Button.ButtonStyle) style);
      this.style = style;
      Label.__\u003Cclinit\u003E();
      string str = text;
      Label.LabelStyle style1 = new Label.LabelStyle(style.font, style.fontColor);
      object obj = (object) str;
      CharSequence text1;
      text1.__\u003Cref\u003E = (__Null) obj;
      this.__\u003C\u003Elabel = new Label(text1, style1);
      this.__\u003C\u003Elabel.setAlignment(1);
      this.add((Element) this.__\u003C\u003Elabel).expand().fill().wrap().minWidth(this.getMinWidth());
      this.setSize(this.getPrefWidth(), this.getPrefHeight());
    }

    [Signature("()Larc/scene/ui/layout/Cell<Larc/scene/ui/Label;>;")]
    [LineNumberTable(76)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cell getLabelCell() => this.getCell((Element) this.__\u003C\u003Elabel);

    [LineNumberTable(new byte[] {34, 124})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setText(string text)
    {
      Label label = this.__\u003C\u003Elabel;
      object obj = (object) text;
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj;
      CharSequence newText = charSequence;
      label.setText(newText);
    }

    [LineNumberTable(80)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual CharSequence getText()
    {
      object text = (object) this.__\u003C\u003Elabel.getText();
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) text;
      return charSequence;
    }

    [LineNumberTable(new byte[] {159, 183, 115, 120, 103, 108, 104, 103, 108, 108, 108, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setStyle(Button.ButtonStyle style)
    {
      if (style == null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new NullPointerException("style cannot be null");
      }
      if (!(style is TextButton.TextButtonStyle))
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException("style must be a TextButtonStyle.");
      }
      base.setStyle(style);
      this.style = (TextButton.TextButtonStyle) style;
      if (this.__\u003C\u003Elabel == null)
        return;
      TextButton.TextButtonStyle textButtonStyle = (TextButton.TextButtonStyle) style;
      Label.LabelStyle style1 = this.__\u003C\u003Elabel.getStyle();
      style1.font = textButtonStyle.font;
      style1.fontColor = textButtonStyle.fontColor;
      this.__\u003C\u003Elabel.setStyle(style1);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual TextButton.TextButtonStyle getStyle() => this.style;

    [LineNumberTable(new byte[] {7, 117, 113, 117, 113, 117, 127, 17, 117, 142, 108, 116, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void draw()
    {
      Color color = !this.isDisabled() || this.style.disabledFontColor == null ? (!this.isPressed() || this.style.downFontColor == null ? (!this.isChecked || this.style.checkedFontColor == null ? (!this.isOver() || this.style.overFontColor == null ? this.style.fontColor : this.style.overFontColor) : (!this.isOver() || this.style.checkedOverFontColor == null ? this.style.checkedFontColor : this.style.checkedOverFontColor)) : this.style.downFontColor) : this.style.disabledFontColor;
      if (color != null)
        this.__\u003C\u003Elabel.getStyle().fontColor = color;
      base.draw();
    }

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(16)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Button.ButtonStyle \u003Cbridge\u003EgetStyle() => (Button.ButtonStyle) this.getStyle();

    [HideFromJava]
    static TextButton() => Button.__\u003Cclinit\u003E();

    [Modifiers]
    protected internal Label label
    {
      [HideFromJava] get => this.__\u003C\u003Elabel;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Elabel = value;
    }

    public class TextButtonStyle : Button.ButtonStyle
    {
      public Font font;
      public Color fontColor;
      public Color downFontColor;
      public Color overFontColor;
      public Color checkedFontColor;
      public Color checkedOverFontColor;
      public Color disabledFontColor;

      [LineNumberTable(new byte[] {55, 105, 108, 126, 126, 126, 126, 126, 126})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public TextButtonStyle(TextButton.TextButtonStyle style)
        : base((Button.ButtonStyle) style)
      {
        TextButton.TextButtonStyle textButtonStyle = this;
        this.font = style.font;
        if (style.fontColor != null)
        {
          Color.__\u003Cclinit\u003E();
          this.fontColor = new Color(style.fontColor);
        }
        if (style.downFontColor != null)
        {
          Color.__\u003Cclinit\u003E();
          this.downFontColor = new Color(style.downFontColor);
        }
        if (style.overFontColor != null)
        {
          Color.__\u003Cclinit\u003E();
          this.overFontColor = new Color(style.overFontColor);
        }
        if (style.checkedFontColor != null)
        {
          Color.__\u003Cclinit\u003E();
          this.checkedFontColor = new Color(style.checkedFontColor);
        }
        if (style.checkedOverFontColor != null)
        {
          Color.__\u003Cclinit\u003E();
          this.checkedFontColor = new Color(style.checkedOverFontColor);
        }
        if (style.disabledFontColor == null)
          return;
        Color.__\u003Cclinit\u003E();
        this.disabledFontColor = new Color(style.disabledFontColor);
      }

      [LineNumberTable(new byte[] {46, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public TextButtonStyle()
      {
      }

      [LineNumberTable(new byte[] {50, 107, 104})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public TextButtonStyle(Drawable up, Drawable down, Drawable @checked, Font font)
        : base(up, down, @checked)
      {
        TextButton.TextButtonStyle textButtonStyle = this;
        this.font = font;
      }
    }
  }
}
