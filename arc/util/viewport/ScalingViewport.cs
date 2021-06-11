// Decompiled with JetBrains decompiler
// Type: arc.util.viewport.ScalingViewport
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
  public class ScalingViewport : Viewport
  {
    private Scaling scaling;

    [LineNumberTable(new byte[] {159, 173, 104, 103, 106, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ScalingViewport(Scaling scaling, float worldWidth, float worldHeight, Camera camera)
    {
      ScalingViewport scalingViewport = this;
      this.scaling = scaling;
      this.setWorldSize(worldWidth, worldHeight);
      this.setCamera(camera);
    }

    [LineNumberTable(new byte[] {159, 170, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ScalingViewport(Scaling scaling, float worldWidth, float worldHeight)
      : this(scaling, worldWidth, worldHeight, new Camera())
    {
    }

    [LineNumberTable(new byte[] {159, 133, 162, 126, 108, 172, 146, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void update(int screenWidth, int screenHeight, bool centerCamera)
    {
      int num = centerCamera ? 1 : 0;
      Vec2 vec2 = this.scaling.apply(this.getWorldWidth(), this.getWorldHeight(), (float) screenWidth, (float) screenHeight);
      int screenWidth1 = Math.round(vec2.x);
      int screenHeight1 = Math.round(vec2.y);
      this.setScreenBounds((screenWidth - screenWidth1) / 2, (screenHeight - screenHeight1) / 2, screenWidth1, screenHeight1);
      this.apply(num != 0);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Scaling getScaling() => this.scaling;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setScaling(Scaling scaling) => this.scaling = scaling;
  }
}
