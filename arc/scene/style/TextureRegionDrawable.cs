// Decompiled with JetBrains decompiler
// Type: arc.scene.style.TextureRegionDrawable
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.graphics;
using arc.graphics.g2d;
using arc.scene.ui.layout;
using arc.util;
using IKVM.Attributes;
using System.Runtime.CompilerServices;

namespace arc.scene.style
{
  [Implements(new string[] {"arc.scene.style.TransformDrawable"})]
  public class TextureRegionDrawable : BaseDrawable, TransformDrawable, Drawable
  {
    protected internal TextureRegion region;
    protected internal Color tint;
    protected internal float scale;

    [LineNumberTable(new byte[] {13, 103, 123, 123})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setRegion(TextureRegion region)
    {
      this.region = region;
      this.setMinWidth(Scl.scl(this.scale * (float) region.width));
      this.setMinHeight(Scl.scl(this.scale * (float) region.height));
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual TextureRegion getRegion() => this.region;

    [LineNumberTable(new byte[] {159, 164, 232, 57, 122, 235, 71, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public TextureRegionDrawable(TextureRegion region)
    {
      TextureRegionDrawable textureRegionDrawable = this;
      this.tint = new Color(1f, 1f, 1f);
      this.scale = 1f;
      this.setRegion(region);
    }

    [LineNumberTable(new byte[] {159, 185, 127, 6, 127, 12})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void draw(float x, float y, float width, float height)
    {
      Draw.color(Tmp.__\u003C\u003Ec1.set(this.tint).mul(Draw.getColor()).toFloatBits());
      Draw.rect(this.region, x + width / 2f, y + height / 2f, width, height);
    }

    [LineNumberTable(new byte[] {25, 108, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Drawable tint(Color tint)
    {
      TextureRegionDrawable textureRegionDrawable = new TextureRegionDrawable(this.region);
      textureRegionDrawable.tint.set(tint);
      return (Drawable) textureRegionDrawable;
    }

    [LineNumberTable(new byte[] {159, 161, 232, 60, 122, 203})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public TextureRegionDrawable()
    {
      TextureRegionDrawable textureRegionDrawable = this;
      this.tint = new Color(1f, 1f, 1f);
      this.scale = 1f;
    }

    [LineNumberTable(new byte[] {159, 168, 232, 53, 122, 235, 75, 104, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public TextureRegionDrawable(TextureRegion region, float scale)
    {
      TextureRegionDrawable textureRegionDrawable = this;
      this.tint = new Color(1f, 1f, 1f);
      this.scale = 1f;
      this.scale = scale;
      this.setRegion(region);
    }

    [LineNumberTable(new byte[] {159, 174, 233, 47, 122, 235, 81, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public TextureRegionDrawable(TextureRegionDrawable drawable)
      : base((Drawable) drawable)
    {
      TextureRegionDrawable textureRegionDrawable = this;
      this.tint = new Color(1f, 1f, 1f);
      this.scale = 1f;
      this.setRegion(drawable.region);
    }

    [LineNumberTable(38)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override float imageSize() => (float) this.region.width;

    [LineNumberTable(new byte[] {159, 191, 127, 6, 127, 32})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void draw(
      float x,
      float y,
      float originX,
      float originY,
      float width,
      float height,
      float scaleX,
      float scaleY,
      float rotation)
    {
      Draw.color(Tmp.__\u003C\u003Ec1.set(this.tint).mul(Draw.getColor()).toFloatBits());
      Draw.rect(this.region, x + width / 2f, y + height / 2f, width * scaleX, height * scaleY, originX, originY, rotation);
    }

    [LineNumberTable(new byte[] {4, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual TextureRegionDrawable set(TextureRegion region)
    {
      this.setRegion(region);
      return this;
    }

    [LineNumberTable(70)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Drawable tint(float r, float g, float b, float a) => this.tint(Tmp.__\u003C\u003Ec1.set(r, g, b, a));
  }
}
