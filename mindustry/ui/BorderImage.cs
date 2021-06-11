// Decompiled with JetBrains decompiler
// Type: mindustry.ui.BorderImage
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.graphics;
using arc.graphics.g2d;
using arc.scene.ui;
using arc.scene.ui.layout;
using IKVM.Attributes;
using mindustry.graphics;
using System.Runtime.CompilerServices;

namespace mindustry.ui
{
  public class BorderImage : Image
  {
    public float thickness;
    public float pad;
    public Color borderColor;

    [LineNumberTable(new byte[] {159, 155, 232, 61, 118, 203})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public BorderImage()
    {
      BorderImage borderImage = this;
      this.thickness = 4f;
      this.pad = 0.0f;
      this.borderColor = Pal.gray;
    }

    [LineNumberTable(new byte[] {159, 160, 233, 56, 118, 235, 72})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public BorderImage(Texture texture)
      : base(texture)
    {
      BorderImage borderImage = this;
      this.thickness = 4f;
      this.pad = 0.0f;
      this.borderColor = Pal.gray;
    }

    [LineNumberTable(new byte[] {159, 164, 233, 52, 118, 235, 76, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public BorderImage(Texture texture, float thick)
      : base(texture)
    {
      BorderImage borderImage = this;
      this.thickness = 4f;
      this.pad = 0.0f;
      this.borderColor = Pal.gray;
      this.thickness = thick;
    }

    [LineNumberTable(new byte[] {159, 169, 233, 47, 118, 235, 81, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public BorderImage(TextureRegion region, float thick)
      : base(region)
    {
      BorderImage borderImage = this;
      this.thickness = 4f;
      this.pad = 0.0f;
      this.borderColor = Pal.gray;
      this.thickness = thick;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual BorderImage border(Color color)
    {
      this.borderColor = color;
      return this;
    }

    [LineNumberTable(new byte[] {159, 180, 134, 107, 107, 113, 127, 76, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void draw()
    {
      base.draw();
      Draw.color(this.borderColor);
      Draw.alpha(this.parentAlpha);
      Lines.stroke(Scl.scl(this.thickness));
      Lines.rect(this.x + this.imageX - this.pad, this.y + this.imageY - this.pad, this.imageWidth * this.scaleX + this.pad * 2f, this.imageHeight * this.scaleY + this.pad * 2f);
      Draw.reset();
    }
  }
}
