// Decompiled with JetBrains decompiler
// Type: arc.scene.ui.Image
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.graphics;
using arc.graphics.g2d;
using arc.math.geom;
using arc.scene.style;
using arc.util;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System.Runtime.CompilerServices;

namespace arc.scene.ui
{
  public class Image : Element
  {
    protected internal float imageX;
    protected internal float imageY;
    protected internal float imageWidth;
    protected internal float imageHeight;
    private Scaling scaling;
    private int align;
    private Drawable drawable;

    [LineNumberTable(new byte[] {159, 188, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Image(TextureRegion region)
      : this((Drawable) new TextureRegionDrawable(region), Scaling.__\u003C\u003Estretch, 1)
    {
    }

    [LineNumberTable(new byte[] {159, 166, 127, 24})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Image()
      : this(!Core.atlas.has("whiteui") ? (TextureRegion) Core.atlas.find("white") : (TextureRegion) Core.atlas.find("whiteui"))
    {
    }

    [LineNumberTable(new byte[] {9, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Image(Drawable drawable)
      : this(drawable, Scaling.__\u003C\u003Estretch, 1)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Drawable getDrawable() => this.drawable;

    [LineNumberTable(new byte[] {30, 137, 109, 109, 104, 136, 113, 109, 141, 106, 109, 107, 151, 159, 4, 106, 119, 106, 141, 127, 4})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void layout()
    {
      if (this.drawable == null)
        return;
      float minWidth = this.drawable.getMinWidth();
      float minHeight = this.drawable.getMinHeight();
      float width = this.getWidth();
      float height = this.getHeight();
      Vec2 vec2 = this.scaling.apply(minWidth, minHeight, width, height);
      this.imageWidth = vec2.x;
      this.imageHeight = vec2.y;
      this.imageX = (this.align & 8) == 0 ? ((this.align & 16) == 0 ? (float) ByteCodeHelper.f2i(width / 2f - this.imageWidth / 2f) : (float) ByteCodeHelper.f2i(width - this.imageWidth)) : 0.0f;
      if ((this.align & 2) != 0)
        this.imageY = (float) ByteCodeHelper.f2i(height - this.imageHeight);
      else if ((this.align & 4) != 0)
        this.imageY = 0.0f;
      else
        this.imageY = (float) ByteCodeHelper.f2i(height / 2f - this.imageHeight / 2f);
    }

    [LineNumberTable(new byte[] {21, 104, 103, 103, 103, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Image(Drawable drawable, Scaling scaling, int align)
    {
      Image image = this;
      this.setDrawable(drawable);
      this.scaling = scaling;
      this.align = align;
      this.setSize(this.getPrefWidth(), this.getPrefHeight());
    }

    [LineNumberTable(new byte[] {93, 111, 99, 127, 1, 136, 102, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setDrawable(Drawable drawable)
    {
      if (object.ReferenceEquals((object) this.drawable, (object) drawable))
        return;
      if (drawable != null)
      {
        if ((double) this.getPrefWidth() != (double) drawable.getMinWidth() || (double) this.getPrefHeight() != (double) drawable.getMinHeight())
          this.invalidateHierarchy();
      }
      else
        this.invalidateHierarchy();
      this.drawable = drawable;
    }

    [LineNumberTable(new byte[] {127, 117})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override float getPrefWidth() => this.drawable != null ? this.drawable.getMinWidth() : 0.0f;

    [LineNumberTable(new byte[] {160, 69, 117})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override float getPrefHeight() => this.drawable != null ? this.drawable.getMinHeight() : 0.0f;

    [LineNumberTable(new byte[] {159, 171, 105, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Image(Drawable name, Color color)
      : this(name)
    {
      Image image = this;
      this.setColor(color);
    }

    [LineNumberTable(new byte[] {159, 180, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Image(NinePatch patch)
      : this((Drawable) new NinePatchDrawable(patch), Scaling.__\u003C\u003Estretch, 1)
    {
    }

    [LineNumberTable(new byte[] {1, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Image(Texture texture)
      : this((Drawable) new TextureRegionDrawable(new TextureRegion(texture)))
    {
    }

    [LineNumberTable(new byte[] {17, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Image(Drawable drawable, Scaling scaling)
      : this(drawable, scaling, 1)
    {
    }

    [LineNumberTable(new byte[] {58, 134, 103, 103, 103, 103, 107, 152, 112, 105, 121, 159, 42, 161, 127, 24})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void draw()
    {
      this.validate();
      float x = this.x;
      float y = this.y;
      float scaleX = this.scaleX;
      float scaleY = this.scaleY;
      Draw.color(this.__\u003C\u003Ecolor);
      Draw.alpha(this.parentAlpha * this.__\u003C\u003Ecolor.a);
      if (this.drawable is TransformDrawable)
      {
        float rotation = this.getRotation();
        if ((double) scaleX != 1.0 || (double) scaleY != 1.0 || (double) rotation != 0.0)
        {
          this.drawable.draw(x + this.imageX, y + this.imageY, this.originX - this.imageX, this.originY - this.imageY, this.imageWidth, this.imageHeight, scaleX, scaleY, rotation);
          return;
        }
      }
      if (this.drawable == null)
        return;
      this.drawable.draw(x + this.imageX, y + this.imageY, this.imageWidth * scaleX, this.imageHeight * scaleY);
    }

    [LineNumberTable(129)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual TextureRegion getRegion() => ((TextureRegionDrawable) this.drawable).getRegion();

    [LineNumberTable(new byte[] {88, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setDrawable(TextureRegion region) => this.setDrawable((Drawable) new TextureRegionDrawable(region));

    [LineNumberTable(new byte[] {103, 115, 103, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Image setScaling(Scaling scaling)
    {
      if (scaling == null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException("scaling cannot be null.");
      }
      this.scaling = scaling;
      this.invalidate();
      return this;
    }

    [LineNumberTable(new byte[] {111, 103, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setAlign(int align)
    {
      this.align = align;
      this.invalidate();
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override float getMinWidth() => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override float getMinHeight() => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getImageX() => this.imageX;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getImageY() => this.imageY;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getImageWidth() => this.imageWidth;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getImageHeight() => this.imageHeight;
  }
}
