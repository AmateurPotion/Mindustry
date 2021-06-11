// Decompiled with JetBrains decompiler
// Type: arc.util.viewport.ExtendViewport
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.graphics;
using arc.math.geom;
using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;

namespace arc.util.viewport
{
  public class ExtendViewport : Viewport
  {
    private float minWorldWidth;
    private float minWorldHeight;
    private float maxWorldWidth;
    private float maxWorldHeight;

    [LineNumberTable(new byte[] {159, 182, 104, 104, 104, 104, 105, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ExtendViewport(
      float minWorldWidth,
      float minWorldHeight,
      float maxWorldWidth,
      float maxWorldHeight,
      Camera camera)
    {
      ExtendViewport extendViewport = this;
      this.minWorldWidth = minWorldWidth;
      this.minWorldHeight = minWorldHeight;
      this.maxWorldWidth = maxWorldWidth;
      this.maxWorldHeight = maxWorldHeight;
      this.setCamera(camera);
    }

    [LineNumberTable(new byte[] {159, 161, 121})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ExtendViewport(float minWorldWidth, float minWorldHeight)
      : this(minWorldWidth, minWorldHeight, 0.0f, 0.0f, new Camera())
    {
    }

    [LineNumberTable(new byte[] {159, 166, 117})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ExtendViewport(float minWorldWidth, float minWorldHeight, Camera camera)
      : this(minWorldWidth, minWorldHeight, 0.0f, 0.0f, camera)
    {
    }

    [LineNumberTable(new byte[] {159, 174, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ExtendViewport(
      float minWorldWidth,
      float minWorldHeight,
      float maxWorldWidth,
      float maxWorldHeight)
      : this(minWorldWidth, minWorldHeight, maxWorldWidth, maxWorldHeight, new Camera())
    {
    }

    [LineNumberTable(new byte[] {159, 130, 162, 103, 103, 177, 109, 109, 104, 104, 104, 107, 127, 6, 102, 112, 109, 104, 104, 107, 127, 6, 102, 176, 168, 150, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void update(int screenWidth, int screenHeight, bool centerCamera)
    {
      int num1 = centerCamera ? 1 : 0;
      float minWorldWidth = this.minWorldWidth;
      float minWorldHeight = this.minWorldHeight;
      Vec2 vec2 = Scaling.__\u003C\u003Efit.apply(minWorldWidth, minWorldHeight, (float) screenWidth, (float) screenHeight);
      int screenWidth1 = Math.round(vec2.x);
      int screenHeight1 = Math.round(vec2.y);
      if (screenWidth1 < screenWidth)
      {
        float num2 = (float) screenHeight1 / minWorldHeight;
        float num3 = minWorldHeight / (float) screenHeight1;
        float num4 = (float) (screenWidth - screenWidth1) * num3;
        if ((double) this.maxWorldWidth > 0.0)
          num4 = Math.min(num4, this.maxWorldWidth - this.minWorldWidth);
        minWorldWidth += num4;
        screenWidth1 += Math.round(num4 * num2);
      }
      else if (screenHeight1 < screenHeight)
      {
        float num2 = (float) screenWidth1 / minWorldWidth;
        float num3 = minWorldWidth / (float) screenWidth1;
        float num4 = (float) (screenHeight - screenHeight1) * num3;
        if ((double) this.maxWorldHeight > 0.0)
          num4 = Math.min(num4, this.maxWorldHeight - this.minWorldHeight);
        minWorldHeight += num4;
        screenHeight1 += Math.round(num4 * num2);
      }
      this.setWorldSize(minWorldWidth, minWorldHeight);
      this.setScreenBounds((screenWidth - screenWidth1) / 2, (screenHeight - screenHeight1) / 2, screenWidth1, screenHeight1);
      this.apply(num1 != 0);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getMinWorldWidth() => this.minWorldWidth;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setMinWorldWidth(float minWorldWidth) => this.minWorldWidth = minWorldWidth;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getMinWorldHeight() => this.minWorldHeight;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setMinWorldHeight(float minWorldHeight) => this.minWorldHeight = minWorldHeight;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getMaxWorldWidth() => this.maxWorldWidth;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setMaxWorldWidth(float maxWorldWidth) => this.maxWorldWidth = maxWorldWidth;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getMaxWorldHeight() => this.maxWorldHeight;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setMaxWorldHeight(float maxWorldHeight) => this.maxWorldHeight = maxWorldHeight;
  }
}
