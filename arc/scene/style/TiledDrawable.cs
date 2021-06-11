// Decompiled with JetBrains decompiler
// Type: arc.scene.style.TiledDrawable
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.graphics;
using arc.graphics.g2d;
using arc.util;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace arc.scene.style
{
  public class TiledDrawable : TextureRegionDrawable
  {
    [Modifiers]
    private Color color;
    private float tileWidth;
    private float tileHeight;

    [LineNumberTable(new byte[] {159, 167, 233, 52, 255, 0, 77})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public TiledDrawable(TextureRegionDrawable drawable)
      : base(drawable)
    {
      TiledDrawable tiledDrawable = this;
      this.color = new Color(1f, 1f, 1f, 1f);
    }

    [LineNumberTable(new byte[] {58, 103, 109, 109, 109, 109, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual TiledDrawable tint(Color tint)
    {
      TiledDrawable tiledDrawable = new TiledDrawable((TextureRegionDrawable) this);
      tiledDrawable.color.set(tint);
      tiledDrawable.setLeftWidth(this.getLeftWidth());
      tiledDrawable.setRightWidth(this.getRightWidth());
      tiledDrawable.setTopHeight(this.getTopHeight());
      tiledDrawable.setBottomHeight(this.getBottomHeight());
      return tiledDrawable;
    }

    [LineNumberTable(new byte[] {159, 159, 232, 60, 255, 0, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public TiledDrawable()
    {
      TiledDrawable tiledDrawable = this;
      this.color = new Color(1f, 1f, 1f, 1f);
    }

    [LineNumberTable(new byte[] {159, 163, 233, 56, 255, 0, 73})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public TiledDrawable(TextureRegion region)
      : base(region)
    {
      TiledDrawable tiledDrawable = this;
      this.color = new Color(1f, 1f, 1f, 1f);
    }

    [LineNumberTable(new byte[] {159, 172, 103, 109, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setRegion(TextureRegion region)
    {
      base.setRegion(region);
      this.tileWidth = (float) region.width;
      this.tileHeight = (float) region.height;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setTileSize(float w, float h)
    {
      this.tileWidth = w;
      this.tileHeight = h;
    }

    [LineNumberTable(new byte[] {159, 184, 103, 110, 120, 120, 104, 107, 104, 100, 105, 108, 7, 200, 231, 58, 232, 72, 104, 104, 104, 140, 114, 104, 100, 105, 108, 146, 127, 9, 231, 59, 232, 72, 105, 114, 108, 146, 191, 9, 140, 104, 114, 100, 136, 108, 146, 127, 9, 231, 58, 232, 73})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void draw(float x, float y, float width, float height)
    {
      TextureRegion region = this.getRegion();
      float tileWidth = this.tileWidth;
      float tileHeight = this.tileHeight;
      int num1 = ByteCodeHelper.f2i(width / tileWidth);
      int num2 = ByteCodeHelper.f2i(height / tileHeight);
      float w = width - tileWidth * (float) num1;
      float h = height - tileHeight * (float) num2;
      float num3 = x;
      float num4 = y;
      Draw.color(this.color);
      for (int index1 = 0; index1 < num1; ++index1)
      {
        y = num4;
        for (int index2 = 0; index2 < num2; ++index2)
        {
          Draw.rect(region, x, y, tileWidth, tileHeight);
          y += tileHeight;
        }
        x += tileWidth;
      }
      Texture texture = region.texture;
      float u = region.u;
      float v2_1 = region.v2;
      if ((double) w > 0.0)
      {
        float u2 = u + w / (float) texture.width;
        float v = region.v;
        y = num4;
        for (int index = 0; index < num2; ++index)
        {
          Tmp.__\u003C\u003Etr1.set(texture);
          Tmp.__\u003C\u003Etr1.set(u, v2_1, u2, v);
          Draw.rect(Tmp.__\u003C\u003Etr1, x + w / 2f, y + h / 2f, w, h);
          y += tileHeight;
        }
        if ((double) h > 0.0)
        {
          float v2_2 = v2_1 - h / (float) texture.height;
          Tmp.__\u003C\u003Etr1.set(texture);
          Tmp.__\u003C\u003Etr1.set(u, v2_1, u2, v2_2);
          Draw.rect(Tmp.__\u003C\u003Etr1, x + w / 2f, y + h / 2f, w, h);
        }
      }
      if ((double) h <= 0.0)
        return;
      float u2_1 = region.u2;
      float v2_3 = v2_1 - h / (float) texture.height;
      x = num3;
      for (int index = 0; index < num1; ++index)
      {
        Tmp.__\u003C\u003Etr1.set(texture);
        Tmp.__\u003C\u003Etr1.set(u, v2_1, u2_1, v2_3);
        Draw.rect(Tmp.__\u003C\u003Etr1, x + w / 2f, y + h / 2f, w, h);
        x += tileWidth;
      }
    }

    [LineNumberTable(99)]
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
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new UnsupportedOperationException();
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Color getColor() => this.color;

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(12)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Drawable \u003Cbridge\u003Etint(Color c) => (Drawable) this.tint(c);
  }
}
