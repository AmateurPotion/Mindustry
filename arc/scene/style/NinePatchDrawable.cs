// Decompiled with JetBrains decompiler
// Type: arc.scene.style.NinePatchDrawable
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.graphics;
using arc.graphics.g2d;
using IKVM.Attributes;
using System.Runtime.CompilerServices;

namespace arc.scene.style
{
  [Implements(new string[] {"arc.scene.style.TransformDrawable"})]
  public class NinePatchDrawable : BaseDrawable, TransformDrawable, Drawable
  {
    protected internal NinePatch patch;

    [LineNumberTable(new byte[] {159, 166, 104, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public NinePatchDrawable(NinePatch patch)
    {
      NinePatchDrawable ninePatchDrawable = this;
      this.setPatch(patch);
    }

    [LineNumberTable(new byte[] {159, 177, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void draw(float x, float y, float width, float height) => this.patch.draw(x, y, width, height);

    [LineNumberTable(new byte[] {159, 190, 103, 109, 109, 109, 109, 109, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setPatch(NinePatch patch)
    {
      this.patch = patch;
      this.setMinWidth(patch.getTotalWidth());
      this.setMinHeight(patch.getTotalHeight());
      this.setTopHeight(patch.getPadTop());
      this.setRightWidth(patch.getPadRight());
      this.setBottomHeight(patch.getPadBottom());
      this.setLeftWidth(patch.getPadLeft());
    }

    [LineNumberTable(new byte[] {159, 171, 105, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public NinePatchDrawable(NinePatchDrawable drawable)
      : base((Drawable) drawable)
    {
      NinePatchDrawable ninePatchDrawable = this;
      this.setPatch(drawable.patch);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual NinePatch getPatch() => this.patch;

    [LineNumberTable(new byte[] {159, 163, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public NinePatchDrawable()
    {
    }

    [LineNumberTable(new byte[] {159, 182, 127, 4})]
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
      this.patch.draw(x, y, originX, originY, width, height, scaleX, scaleY, rotation);
    }

    [LineNumberTable(new byte[] {9, 103, 119})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual NinePatchDrawable tint(Color tint)
    {
      NinePatchDrawable ninePatchDrawable1 = new NinePatchDrawable(this);
      NinePatchDrawable ninePatchDrawable2 = ninePatchDrawable1;
      NinePatch.__\u003Cclinit\u003E();
      NinePatch patch = new NinePatch(ninePatchDrawable1.getPatch(), tint);
      ninePatchDrawable2.setPatch(patch);
      return ninePatchDrawable1;
    }

    [HideFromJava]
    public override float imageSize() => Drawable.\u003Cdefault\u003EimageSize((Drawable) this);
  }
}
