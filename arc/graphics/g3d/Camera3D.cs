// Decompiled with JetBrains decompiler
// Type: arc.graphics.g3d.Camera3D
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.math.geom;
using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.graphics.g3d
{
  public class Camera3D : Object
  {
    public float fov;
    public float near;
    public float far;
    public bool perspective;
    public float width;
    public float height;
    internal Vec3 __\u003C\u003Eposition;
    internal Vec3 __\u003C\u003Edirection;
    internal Vec3 __\u003C\u003Eup;
    internal Mat3D __\u003C\u003Ecombined;
    internal Mat3D __\u003C\u003Eprojection;
    internal Mat3D __\u003C\u003Eview;
    internal Mat3D __\u003C\u003EinvProjectionView;
    [Modifiers]
    private Vec3 tmpVec;
    [Modifiers]
    private Ray ray;

    [LineNumberTable(new byte[] {159, 148, 136, 139, 139, 139, 199, 139, 154, 186, 139, 139, 139, 139, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Camera3D()
    {
      Camera3D camera3D = this;
      this.fov = 67f;
      this.near = 1f;
      this.far = 100f;
      this.perspective = true;
      this.__\u003C\u003Eposition = new Vec3();
      this.__\u003C\u003Edirection = new Vec3(0.0f, 0.0f, -1f);
      this.__\u003C\u003Eup = new Vec3(0.0f, 1f, 0.0f);
      this.__\u003C\u003Ecombined = new Mat3D();
      this.__\u003C\u003Eprojection = new Mat3D();
      this.__\u003C\u003Eview = new Mat3D();
      this.__\u003C\u003EinvProjectionView = new Mat3D();
      this.tmpVec = new Vec3();
      this.ray = new Ray(new Vec3(), new Vec3());
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void resize(float width, float height)
    {
      this.width = width;
      this.height = height;
    }

    [LineNumberTable(new byte[] {4, 127, 3, 112, 115, 149, 126, 149, 146, 114, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void lookAt(float x, float y, float z)
    {
      this.tmpVec.set(x, y, z).sub(this.__\u003C\u003Eposition).nor();
      if (this.tmpVec.isZero())
        return;
      float num = this.tmpVec.dot(this.__\u003C\u003Eup);
      if ((double) Math.abs(num - 1f) < 9.99999971718069E-10)
        this.__\u003C\u003Eup.set(this.__\u003C\u003Edirection).scl(-1f);
      else if ((double) Math.abs(num + 1f) < 9.99999971718069E-10)
        this.__\u003C\u003Eup.set(this.__\u003C\u003Edirection);
      this.__\u003C\u003Edirection.set(this.tmpVec);
      this.normalizeUp();
    }

    [LineNumberTable(new byte[] {159, 179, 104, 159, 27, 191, 47, 127, 21, 125, 119})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void update()
    {
      if (this.perspective)
        this.__\u003C\u003Eprojection.setToProjection(Math.abs(this.near), Math.abs(this.far), this.fov, this.width / this.height);
      else
        this.__\u003C\u003Eprojection.setToOrtho((float) (-(double) this.width / 2.0), this.width / 2f, (float) (-(double) this.height / 2.0), this.height / 2f, this.near, this.far);
      this.__\u003C\u003Eview.setToLookAt(this.__\u003C\u003Eposition, this.tmpVec.set(this.__\u003C\u003Eposition).add(this.__\u003C\u003Edirection), this.__\u003C\u003Eup);
      this.__\u003C\u003Ecombined.set(this.__\u003C\u003Eprojection).mul(this.__\u003C\u003Eview);
      this.__\u003C\u003EinvProjectionView.set(this.__\u003C\u003Ecombined).inv();
    }

    [LineNumberTable(new byte[] {24, 120})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void lookAt(Vec3 target) => this.lookAt(target.x, target.y, target.z);

    [LineNumberTable(159)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Ray getMouseRay() => this.getPickRay((float) Core.input.mouseX(), (float) Core.input.mouseY());

    [LineNumberTable(new byte[] {83, 127, 9})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec3 project(Vec3 worldCoords)
    {
      this.project(worldCoords, 0.0f, 0.0f, (float) Core.graphics.getWidth(), (float) Core.graphics.getHeight());
      return worldCoords;
    }

    [LineNumberTable(new byte[] {32, 125, 127, 3})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void normalizeUp()
    {
      this.tmpVec.set(this.__\u003C\u003Edirection).crs(this.__\u003C\u003Eup);
      this.__\u003C\u003Eup.set(this.tmpVec).crs(this.__\u003C\u003Edirection).nor();
    }

    [LineNumberTable(new byte[] {51, 110, 102, 102, 122, 122, 122, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec3 unproject(
      Vec3 screenCoords,
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
      screenCoords.z = 2f * screenCoords.z - 1f;
      Mat3D.prj(screenCoords, this.__\u003C\u003EinvProjectionView);
      return screenCoords;
    }

    [LineNumberTable(new byte[] {101, 109, 127, 4, 127, 4, 122})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec3 project(
      Vec3 worldCoords,
      float viewportX,
      float viewportY,
      float viewportWidth,
      float viewportHeight)
    {
      Mat3D.prj(worldCoords, this.__\u003C\u003Ecombined);
      worldCoords.x = viewportWidth * (worldCoords.x + 1f) / 2f + viewportX;
      worldCoords.y = viewportHeight * (worldCoords.y + 1f) / 2f + viewportY;
      worldCoords.z = (worldCoords.z + 1f) / 2f;
      return worldCoords;
    }

    [LineNumberTable(186)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Ray getPickRay(float screenX, float screenY) => this.getPickRay(screenX, screenY, 0.0f, 0.0f, (float) Core.graphics.getWidth(), (float) Core.graphics.getHeight());

    [LineNumberTable(new byte[] {123, 127, 12, 127, 12, 127, 2})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Ray getPickRay(
      float screenX,
      float screenY,
      float viewportX,
      float viewportY,
      float viewportWidth,
      float viewportHeight)
    {
      this.unproject(this.ray.__\u003C\u003Eorigin.set(screenX, screenY, 0.0f), viewportX, viewportY, viewportWidth, viewportHeight);
      this.unproject(this.ray.__\u003C\u003Edirection.set(screenX, screenY, 1f), viewportX, viewportY, viewportWidth, viewportHeight);
      this.ray.__\u003C\u003Edirection.sub(this.ray.__\u003C\u003Eorigin).nor();
      return this.ray;
    }

    [LineNumberTable(new byte[] {71, 127, 9})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec3 unproject(Vec3 screenCoords)
    {
      this.unproject(screenCoords, 0.0f, 0.0f, (float) Core.graphics.getWidth(), (float) Core.graphics.getHeight());
      return screenCoords;
    }

    [Modifiers]
    public Vec3 position
    {
      [HideFromJava] get => this.__\u003C\u003Eposition;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Eposition = value;
    }

    [Modifiers]
    public Vec3 direction
    {
      [HideFromJava] get => this.__\u003C\u003Edirection;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Edirection = value;
    }

    [Modifiers]
    public Vec3 up
    {
      [HideFromJava] get => this.__\u003C\u003Eup;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Eup = value;
    }

    [Modifiers]
    public Mat3D combined
    {
      [HideFromJava] get => this.__\u003C\u003Ecombined;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Ecombined = value;
    }

    [Modifiers]
    public Mat3D projection
    {
      [HideFromJava] get => this.__\u003C\u003Eprojection;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Eprojection = value;
    }

    [Modifiers]
    public Mat3D view
    {
      [HideFromJava] get => this.__\u003C\u003Eview;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Eview = value;
    }

    [Modifiers]
    public Mat3D invProjectionView
    {
      [HideFromJava] get => this.__\u003C\u003EinvProjectionView;
      [HideFromJava] [param: In] private set => this.__\u003C\u003EinvProjectionView = value;
    }
  }
}
