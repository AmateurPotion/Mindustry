// Decompiled with JetBrains decompiler
// Type: arc.scene.ui.ImageButton
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.graphics;
using arc.graphics.g2d;
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
  public class ImageButton : Button
  {
    [Modifiers]
    private Image image;
    private ImageButton.ImageButtonStyle style;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {91, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void resizeImage(float size) => this.getImageCell().size(size);

    [LineNumberTable(new byte[] {159, 171, 105, 103, 135, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ImageButton(Drawable icon, ImageButton.ImageButtonStyle stylen)
      : this(stylen)
    {
      ImageButton imageButton = this;
      this.setStyle((Button.ButtonStyle) new ImageButton.ImageButtonStyle(stylen)
      {
        imageUp = icon
      });
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual ImageButton.ImageButtonStyle getStyle() => this.style;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Image getImage() => this.image;

    [LineNumberTable(137)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cell getImageCell() => this.getCell((Element) this.image) == null ? (Cell) this.getCells().first() : this.getCell((Element) this.image);

    [LineNumberTable(new byte[] {3, 105, 107, 113, 109, 103, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ImageButton(ImageButton.ImageButtonStyle style)
      : base((Button.ButtonStyle) style)
    {
      ImageButton imageButton = this;
      this.image = new Image();
      this.image.setScaling(Scaling.__\u003C\u003Efit);
      this.add((Element) this.image);
      this.setStyle((Button.ButtonStyle) style);
      this.setSize(this.getPrefWidth(), this.getPrefHeight());
    }

    [LineNumberTable(new byte[] {34, 104, 112, 103, 108, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setStyle(Button.ButtonStyle style)
    {
      if (!(style is ImageButton.ImageButtonStyle))
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException("style must be an ImageButtonStyle.");
      }
      base.setStyle(style);
      this.style = (ImageButton.ImageButtonStyle) style;
      if (this.image == null)
        return;
      this.updateImage();
    }

    [LineNumberTable(new byte[] {49, 98, 117, 113, 117, 113, 117, 127, 17, 117, 110, 109, 140, 140, 117, 113, 117, 110, 117, 110, 109, 140, 108, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void updateImage()
    {
      Drawable drawable = (Drawable) null;
      if (this.isDisabled() && this.style.imageDisabled != null)
        drawable = this.style.imageDisabled;
      else if (this.isPressed() && this.style.imageDown != null)
        drawable = this.style.imageDown;
      else if (this.isChecked && this.style.imageChecked != null)
        drawable = this.style.imageCheckedOver == null || !this.isOver() ? this.style.imageChecked : this.style.imageCheckedOver;
      else if (this.isOver() && this.style.imageOver != null)
        drawable = this.style.imageOver;
      else if (this.style.imageUp != null)
        drawable = this.style.imageUp;
      Color color = this.image.__\u003C\u003Ecolor;
      if (this.isDisabled && this.style.imageDisabledColor != null)
        color = this.style.imageDisabledColor;
      else if (this.isPressed() && this.style.imageDownColor != null)
        color = this.style.imageDownColor;
      else if (this.isChecked() && this.style.imageCheckedColor != null)
        color = this.style.imageCheckedColor;
      else if (this.style.imageUpColor != null)
        color = this.style.imageUpColor;
      this.image.setDrawable(drawable);
      this.image.setColor(color);
    }

    [LineNumberTable(new byte[] {159, 167, 122})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ImageButton()
      : this((ImageButton.ImageButtonStyle) Core.scene.getStyle((Class) ClassLiteral<ImageButton.ImageButtonStyle>.Value))
    {
    }

    [LineNumberTable(new byte[] {159, 179, 124, 122, 140, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ImageButton(TextureRegion region)
      : this((ImageButton.ImageButtonStyle) Core.scene.getStyle((Class) ClassLiteral<ImageButton.ImageButtonStyle>.Value))
    {
      ImageButton imageButton = this;
      this.setStyle((Button.ButtonStyle) new ImageButton.ImageButtonStyle((ImageButton.ImageButtonStyle) Core.scene.getStyle((Class) ClassLiteral<ImageButton.ImageButtonStyle>.Value))
      {
        imageUp = (Drawable) new TextureRegionDrawable(region)
      });
    }

    [LineNumberTable(new byte[] {159, 187, 105, 103, 140, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ImageButton(TextureRegion region, ImageButton.ImageButtonStyle stylen)
      : this(stylen)
    {
      ImageButton imageButton = this;
      this.setStyle((Button.ButtonStyle) new ImageButton.ImageButtonStyle(stylen)
      {
        imageUp = (Drawable) new TextureRegionDrawable(region)
      });
    }

    [LineNumberTable(new byte[] {12, 147, 122, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ImageButton(Drawable imageUp)
      : this(new ImageButton.ImageButtonStyle((Drawable) null, (Drawable) null, (Drawable) null, imageUp, (Drawable) null, (Drawable) null))
    {
      ImageButton imageButton = this;
      this.setStyle((Button.ButtonStyle) new ImageButton.ImageButtonStyle((ImageButton.ImageButtonStyle) Core.scene.getStyle((Class) ClassLiteral<ImageButton.ImageButtonStyle>.Value))
      {
        imageUp = imageUp
      });
    }

    [LineNumberTable(new byte[] {20, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ImageButton(Drawable imageUp, Drawable imageDown)
      : this(new ImageButton.ImageButtonStyle((Drawable) null, (Drawable) null, (Drawable) null, imageUp, imageDown, (Drawable) null))
    {
    }

    [LineNumberTable(new byte[] {24, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ImageButton(Drawable imageUp, Drawable imageDown, Drawable imageChecked)
      : this(new ImageButton.ImageButtonStyle((Drawable) null, (Drawable) null, (Drawable) null, imageUp, imageDown, imageChecked))
    {
    }

    [LineNumberTable(new byte[] {42, 109, 103, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void replaceImage(Element element)
    {
      this.getImageCell().setElement(element);
      this.addChild(element);
      this.image.remove();
    }

    [LineNumberTable(new byte[] {78, 102, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void draw()
    {
      this.updateImage();
      base.draw();
    }

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(20)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Button.ButtonStyle \u003Cbridge\u003EgetStyle() => (Button.ButtonStyle) this.getStyle();

    [HideFromJava]
    static ImageButton() => Button.__\u003Cclinit\u003E();

    public class ImageButtonStyle : Button.ButtonStyle
    {
      public Drawable imageUp;
      public Drawable imageDown;
      public Drawable imageOver;
      public Drawable imageChecked;
      public Drawable imageCheckedOver;
      public Drawable imageDisabled;
      public Color imageUpColor;
      public Color imageCheckedColor;
      public Color imageDownColor;
      public Color imageDisabledColor;

      [LineNumberTable(new byte[] {115, 105, 108, 108, 108, 108, 108, 108, 108, 108, 108, 108})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public ImageButtonStyle(ImageButton.ImageButtonStyle style)
        : base((Button.ButtonStyle) style)
      {
        ImageButton.ImageButtonStyle imageButtonStyle = this;
        this.imageUp = style.imageUp;
        this.imageDown = style.imageDown;
        this.imageOver = style.imageOver;
        this.imageChecked = style.imageChecked;
        this.imageCheckedOver = style.imageCheckedOver;
        this.imageDisabled = style.imageDisabled;
        this.imageUpColor = style.imageUpColor;
        this.imageDownColor = style.imageDownColor;
        this.imageCheckedColor = style.imageCheckedColor;
        this.imageDisabledColor = style.imageDisabledColor;
      }

      [LineNumberTable(new byte[] {108, 107, 104, 104, 104})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public ImageButtonStyle(
        Drawable up,
        Drawable down,
        Drawable @checked,
        Drawable imageUp,
        Drawable imageDown,
        Drawable imageChecked)
        : base(up, down, @checked)
      {
        ImageButton.ImageButtonStyle imageButtonStyle = this;
        this.imageUp = imageUp;
        this.imageDown = imageDown;
        this.imageChecked = imageChecked;
      }

      [LineNumberTable(new byte[] {103, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public ImageButtonStyle()
      {
      }
    }
  }
}
