// Decompiled with JetBrains decompiler
// Type: arc.graphics.Camera
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.math;
using arc.math.geom;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.graphics
{
  public class Camera : Object
  {
    [Modifiers]
    private static Vec2 tmpVector;
    internal Vec2 __\u003C\u003Eposition;
    internal Mat __\u003C\u003Emat;
    internal Mat __\u003C\u003Einv;
    public float width;
    public float height;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(120)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Rect bounds(Rect @out) => @out.setSize(this.width, this.height).setCenter(this.__\u003C\u003Eposition);

    [LineNumberTable(new byte[] {159, 152, 200, 139, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Camera()
    {
      Camera camera = this;
      this.__\u003C\u003Eposition = new Vec2();
      this.__\u003C\u003Emat = new Mat();
      this.__\u003C\u003Einv = new Mat();
    }

    [LineNumberTable(new byte[] {159, 169, 127, 45, 119})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void update()
    {
      this.__\u003C\u003Emat.setOrtho(this.__\u003C\u003Eposition.x - this.width / 2f, this.__\u003C\u003Eposition.y - this.height / 2f, this.width, this.height);
      this.__\u003C\u003Einv.set(this.__\u003C\u003Emat).inv();
    }

    [LineNumberTable(new byte[] {44, 127, 22})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec2 project(float screenX, float screenY)
    {
      this.project(Camera.tmpVector.set(screenX, screenY), 0.0f, 0.0f, (float) Core.graphics.getWidth(), (float) Core.graphics.getHeight());
      return Camera.tmpVector;
    }

    [LineNumberTable(new byte[] {159, 174, 104, 104, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void resize(float viewportWidth, float viewportHeight)
    {
      this.width = viewportWidth;
      this.height = viewportHeight;
      this.update();
    }

    [LineNumberTable(new byte[] {21, 127, 9})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec2 unproject(Vec2 screenCoords)
    {
      this.unproject(screenCoords, 0.0f, 0.0f, (float) Core.graphics.getWidth(), (float) Core.graphics.getHeight());
      return screenCoords;
    }

    [LineNumberTable(new byte[] {38, 127, 9})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec2 project(Vec2 worldCoords)
    {
      this.project(worldCoords, 0.0f, 0.0f, (float) Core.graphics.getWidth(), (float) Core.graphics.getHeight());
      return worldCoords;
    }

    [LineNumberTable(new byte[] {2, 110, 102, 102, 122, 122, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec2 unproject(
      Vec2 screenCoords,
      float viewportX,
      float viewportY,
      float viewportWidth,
      float viewportHeight)
    {
      float x = screenCoords.x;
      float y = screenCoords.y;
      float num1 = x - viewportX;
      float num2 = y - viewportY;
      screenCoords.x = 2f * num1 / viewportWidth - 1f;
      screenCoords.y = 2f * num2 / viewportHeight - 1f;
      screenCoords.mul(this.__\u003C\u003Einv);
      return screenCoords;
    }

    [LineNumberTable(new byte[] {62, 109, 127, 4, 127, 4})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec2 project(
      Vec2 worldCoords,
      float viewportX,
      float viewportY,
      float viewportWidth,
      float viewportHeight)
    {
      worldCoords.mul(this.__\u003C\u003Emat);
      worldCoords.x = viewportWidth * (worldCoords.x + 1f) / 2f + viewportX;
      worldCoords.y = viewportHeight * (worldCoords.y + 1f) / 2f + viewportY;
      return worldCoords;
    }

    [LineNumberTable(new byte[] {27, 127, 22})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec2 unproject(float screenX, float screenY)
    {
      this.unproject(Camera.tmpVector.set(screenX, screenY), 0.0f, 0.0f, (float) Core.graphics.getWidth(), (float) Core.graphics.getHeight());
      return Camera.tmpVector;
    }

    [LineNumberTable(12)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static Camera()
    {
      if (ByteCodeHelper.isAlreadyInited("arc.graphics.Camera"))
        return;
      Camera.tmpVector = new Vec2();
    }

    [Modifiers]
    public Vec2 position
    {
      [HideFromJava] get => this.__\u003C\u003Eposition;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Eposition = value;
    }

    [Modifiers]
    public Mat mat
    {
      [HideFromJava] get => this.__\u003C\u003Emat;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Emat = value;
    }

    [Modifiers]
    public Mat inv
    {
      [HideFromJava] get => this.__\u003C\u003Einv;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Einv = value;
    }
  }
}
