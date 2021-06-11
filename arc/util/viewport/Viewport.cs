// Decompiled with JetBrains decompiler
// Type: arc.util.viewport.Viewport
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.graphics;
using arc.graphics.g2d;
using arc.graphics.gl;
using arc.math;
using arc.math.geom;
using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;

namespace arc.util.viewport
{
  public abstract class Viewport : Object
  {
    [Modifiers]
    private Vec2 tmp;
    private Camera camera;
    private float worldWidth;
    private float worldHeight;
    private int screenX;
    private int screenY;
    private int screenWidth;
    private int screenHeight;

    [LineNumberTable(new byte[] {159, 134, 98, 125, 113, 113, 127, 15, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void apply(bool centerCamera)
    {
      int num = centerCamera ? 1 : 0;
      HdpiUtils.glViewport(this.screenX, this.screenY, this.screenWidth, this.screenHeight);
      this.camera.width = this.worldWidth;
      this.camera.height = this.worldHeight;
      if (num != 0)
        this.camera.__\u003C\u003Eposition.set(this.worldWidth / 2f, this.worldHeight / 2f);
      this.camera.update();
    }

    [LineNumberTable(new byte[] {159, 129, 66, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void update(int screenWidth, int screenHeight, bool centerCamera) => this.apply(centerCamera);

    [LineNumberTable(new byte[] {159, 159, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Viewport()
    {
      Viewport viewport = this;
      this.tmp = new Vec2();
    }

    [LineNumberTable(new byte[] {159, 167, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void apply() => this.apply(false);

    [LineNumberTable(new byte[] {159, 184, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public void update(int screenWidth, int screenHeight) => this.update(screenWidth, screenHeight, false);

    [LineNumberTable(new byte[] {11, 120, 127, 15, 125})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec2 unproject(Vec2 screenCoords)
    {
      this.tmp.set(screenCoords.x, screenCoords.y);
      this.camera.unproject(this.tmp, (float) this.screenX, (float) this.screenY, (float) this.screenWidth, (float) this.screenHeight);
      screenCoords.set(this.tmp.x, this.tmp.y);
      return screenCoords;
    }

    [LineNumberTable(new byte[] {23, 120, 127, 15, 125})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec2 project(Vec2 worldCoords)
    {
      this.tmp.set(worldCoords.x, worldCoords.y);
      this.camera.project(this.tmp, (float) this.screenX, (float) this.screenY, (float) this.screenWidth, (float) this.screenHeight);
      worldCoords.set(this.tmp.x, this.tmp.y);
      return worldCoords;
    }

    [LineNumberTable(new byte[] {31, 127, 11})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void calculateScissors(Mat batchTransform, Rect area, Rect scissor) => ScissorStack.calculateScissors(this.camera, (float) this.screenX, (float) this.screenY, (float) this.screenWidth, (float) this.screenHeight, batchTransform, area, scissor);

    [LineNumberTable(new byte[] {39, 120, 109, 114, 127, 4, 113, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec2 toScreenCoordinates(Vec2 worldCoords, Mat transformMatrix)
    {
      this.tmp.set(worldCoords.x, worldCoords.y);
      this.tmp.mul(transformMatrix);
      this.camera.project(this.tmp);
      this.tmp.y = (float) Core.graphics.getHeight() - this.tmp.y;
      worldCoords.x = this.tmp.x;
      worldCoords.y = this.tmp.y;
      return worldCoords;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Camera getCamera() => this.camera;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setCamera(Camera camera) => this.camera = camera;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getWorldWidth() => this.worldWidth;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setWorldWidth(float worldWidth) => this.worldWidth = worldWidth;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getWorldHeight() => this.worldHeight;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setWorldHeight(float worldHeight) => this.worldHeight = worldHeight;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setWorldSize(float worldWidth, float worldHeight)
    {
      this.worldWidth = worldWidth;
      this.worldHeight = worldHeight;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getScreenX() => this.screenX;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setScreenX(int screenX) => this.screenX = screenX;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getScreenY() => this.screenY;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setScreenY(int screenY) => this.screenY = screenY;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getScreenWidth() => this.screenWidth;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setScreenWidth(int screenWidth) => this.screenWidth = screenWidth;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getScreenHeight() => this.screenHeight;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setScreenHeight(int screenHeight) => this.screenHeight = screenHeight;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setScreenPosition(int screenX, int screenY)
    {
      this.screenX = screenX;
      this.screenY = screenY;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setScreenSize(int screenWidth, int screenHeight)
    {
      this.screenWidth = screenWidth;
      this.screenHeight = screenHeight;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setScreenBounds(
      int screenX,
      int screenY,
      int screenWidth,
      int screenHeight)
    {
      this.screenX = screenX;
      this.screenY = screenY;
      this.screenWidth = screenWidth;
      this.screenHeight = screenHeight;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getLeftGutterWidth() => this.screenX;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getRightGutterX() => this.screenX + this.screenWidth;

    [LineNumberTable(197)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getRightGutterWidth() => Core.graphics.getWidth() - (this.screenX + this.screenWidth);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getBottomGutterHeight() => this.screenY;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getTopGutterY() => this.screenY + this.screenHeight;

    [LineNumberTable(212)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getTopGutterHeight() => Core.graphics.getHeight() - (this.screenY + this.screenHeight);
  }
}
