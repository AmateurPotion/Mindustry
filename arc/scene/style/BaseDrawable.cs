// Decompiled with JetBrains decompiler
// Type: arc.scene.style.BaseDrawable
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;

namespace arc.scene.style
{
  public class BaseDrawable : Object, Drawable
  {
    private string name;
    private float leftWidth;
    private float rightWidth;
    private float topHeight;
    private float bottomHeight;
    private float minWidth;
    private float minHeight;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void draw(float x, float y, float width, float height)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setMinWidth(float minWidth) => this.minWidth = minWidth;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setMinHeight(float minHeight) => this.minHeight = minHeight;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string getName() => this.name;

    [LineNumberTable(new byte[] {159, 153, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public BaseDrawable()
    {
    }

    [LineNumberTable(new byte[] {159, 157, 104, 121, 109, 109, 109, 109, 109, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public BaseDrawable(Drawable drawable)
    {
      BaseDrawable baseDrawable = this;
      if (drawable is BaseDrawable)
        this.name = ((BaseDrawable) drawable).getName();
      this.leftWidth = drawable.getLeftWidth();
      this.rightWidth = drawable.getRightWidth();
      this.topHeight = drawable.getTopHeight();
      this.bottomHeight = drawable.getBottomHeight();
      this.minWidth = drawable.getMinWidth();
      this.minHeight = drawable.getMinHeight();
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void draw(
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
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getLeftWidth() => this.leftWidth;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setLeftWidth(float leftWidth) => this.leftWidth = leftWidth;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getRightWidth() => this.rightWidth;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setRightWidth(float rightWidth) => this.rightWidth = rightWidth;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getTopHeight() => this.topHeight;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setTopHeight(float topHeight) => this.topHeight = topHeight;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getBottomHeight() => this.bottomHeight;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setBottomHeight(float bottomHeight) => this.bottomHeight = bottomHeight;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getMinWidth() => this.minWidth;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getMinHeight() => this.minHeight;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setName(string name) => this.name = name;

    [LineNumberTable(new byte[] {53, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toString() => this.name == null ? Object.instancehelper_getClass((object) this).toString() : this.name;

    [HideFromJava]
    public virtual float imageSize() => Drawable.\u003Cdefault\u003EimageSize((Drawable) this);
  }
}
