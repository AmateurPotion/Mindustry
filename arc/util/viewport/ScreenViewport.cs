// Decompiled with JetBrains decompiler
// Type: arc.util.viewport.ScreenViewport
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.graphics;
using IKVM.Attributes;
using System.Runtime.CompilerServices;

namespace arc.util.viewport
{
  public class ScreenViewport : Viewport
  {
    private float unitsPerPixel;

    [LineNumberTable(new byte[] {159, 161, 232, 57, 235, 72, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ScreenViewport(Camera camera)
    {
      ScreenViewport screenViewport = this;
      this.unitsPerPixel = 1f;
      this.setCamera(camera);
    }

    [LineNumberTable(new byte[] {159, 158, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ScreenViewport()
      : this(new Camera())
    {
    }

    [LineNumberTable(new byte[] {159, 136, 98, 106, 122, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void update(int screenWidth, int screenHeight, bool centerCamera)
    {
      int num = centerCamera ? 1 : 0;
      this.setScreenBounds(0, 0, screenWidth, screenHeight);
      this.setWorldSize((float) screenWidth * this.unitsPerPixel, (float) screenHeight * this.unitsPerPixel);
      this.apply(num != 0);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getUnitsPerPixel() => this.unitsPerPixel;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setUnitsPerPixel(float unitsPerPixel) => this.unitsPerPixel = unitsPerPixel;
  }
}
