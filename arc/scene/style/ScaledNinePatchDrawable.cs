// Decompiled with JetBrains decompiler
// Type: arc.scene.style.ScaledNinePatchDrawable
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.graphics.g2d;
using arc.scene.ui.layout;
using IKVM.Attributes;
using System.Runtime.CompilerServices;

namespace arc.scene.style
{
  public class ScaledNinePatchDrawable : NinePatchDrawable
  {
    private float scale;

    [LineNumberTable(new byte[] {159, 155, 232, 58, 241, 71, 142, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ScaledNinePatchDrawable(NinePatch patch, float multiplier)
    {
      ScaledNinePatchDrawable ninePatchDrawable = this;
      this.scale = Scl.scl(1f);
      this.scale = Scl.scl(multiplier);
      this.setPatch(patch);
    }

    [LineNumberTable(new byte[] {159, 172, 135, 117, 117})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setPatch(NinePatch patch)
    {
      base.setPatch(patch);
      this.setMinWidth(patch.getTotalWidth() * this.scale);
      this.setMinHeight(patch.getTotalHeight() * this.scale);
    }

    [LineNumberTable(new byte[] {159, 152, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ScaledNinePatchDrawable(NinePatch patch)
      : this(patch, 1f)
    {
    }

    [LineNumberTable(new byte[] {159, 162, 233, 51, 241, 78})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ScaledNinePatchDrawable(NinePatchDrawable drawable)
      : base(drawable)
    {
      ScaledNinePatchDrawable ninePatchDrawable = this;
      this.scale = Scl.scl(1f);
    }

    [LineNumberTable(new byte[] {159, 167, 127, 32})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void draw(float x, float y, float width, float height) => this.getPatch().draw(x, y, 0.0f, 0.0f, width / this.scale, height / this.scale, this.scale, this.scale, 0.0f);

    [LineNumberTable(38)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override float getLeftWidth() => this.patch.getPadLeft() * this.scale;

    [LineNumberTable(43)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override float getRightWidth() => this.patch.getPadRight() * this.scale;

    [LineNumberTable(48)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override float getTopHeight() => this.patch.getPadTop() * this.scale;

    [LineNumberTable(53)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override float getBottomHeight() => this.patch.getPadBottom() * this.scale;
  }
}
