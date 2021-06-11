// Decompiled with JetBrains decompiler
// Type: arc.graphics.g2d.Batch
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.graphics.gl;
using arc.math;
using arc.util;
using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.graphics.g2d
{
  public abstract class Batch : Object, Disposable
  {
    protected internal Mesh mesh;
    protected internal float z;
    protected internal bool sortAscending;
    protected internal int idx;
    protected internal Texture lastTexture;
    protected internal bool apply;
    internal Mat __\u003C\u003EtransformMatrix;
    internal Mat __\u003C\u003EprojectionMatrix;
    internal Mat __\u003C\u003EcombinedMatrix;
    protected internal Blending blending;
    protected internal Shader shader;
    protected internal Shader customShader;
    protected internal bool ownsShader;
    internal Color __\u003C\u003Ecolor;
    protected internal float colorPacked;
    internal Color __\u003C\u003EmixColor;
    protected internal float mixColorPacked;

    [LineNumberTable(new byte[] {78, 102, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void setProjection(Mat projection)
    {
      this.flush();
      this.__\u003C\u003EprojectionMatrix.set(projection);
    }

    [LineNumberTable(new byte[] {63, 104, 139, 123})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void dispose()
    {
      if (this.mesh != null)
        this.mesh.dispose();
      if (!this.ownsShader || this.shader == null)
        return;
      this.shader.dispose();
    }

    protected internal abstract void flush();

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual Shader getShader() => this.customShader == null ? this.shader : this.customShader;

    [LineNumberTable(new byte[] {159, 104, 98, 102, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void setShader(Shader shader, bool apply)
    {
      int num = apply ? 1 : 0;
      this.flush();
      this.customShader = shader;
      this.apply = num != 0;
    }

    [LineNumberTable(new byte[] {159, 151, 200, 103, 103, 199, 107, 107, 139, 139, 167, 127, 0, 139, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Batch()
    {
      Batch batch = this;
      this.sortAscending = true;
      this.idx = 0;
      this.lastTexture = (Texture) null;
      this.__\u003C\u003EtransformMatrix = new Mat();
      this.__\u003C\u003EprojectionMatrix = new Mat();
      this.__\u003C\u003EcombinedMatrix = new Mat();
      this.blending = Blending.__\u003C\u003Enormal;
      this.customShader = (Shader) null;
      this.__\u003C\u003Ecolor = new Color(1f, 1f, 1f, 1f);
      this.colorPacked = Color.__\u003C\u003EwhiteFloatBits;
      this.__\u003C\u003EmixColor = Color.__\u003C\u003Eclear;
      this.mixColorPacked = Color.__\u003C\u003EclearFloatBits;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void z(float z) => this.z = !this.sortAscending ? -z : z;

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void setSort(bool sort)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void setSortAscending(bool ascend) => this.sortAscending = ascend;

    [LineNumberTable(new byte[] {159, 191, 109, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void setColor(Color tint)
    {
      this.__\u003C\u003Ecolor.set(tint);
      this.colorPacked = tint.toFloatBits();
    }

    [LineNumberTable(new byte[] {4, 117, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void setColor(float r, float g, float b, float a)
    {
      this.__\u003C\u003Ecolor.set(r, g, b, a);
      this.colorPacked = this.__\u003C\u003Ecolor.toFloatBits();
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual Color getColor() => this.__\u003C\u003Ecolor;

    [LineNumberTable(new byte[] {13, 110, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void setPackedColor(float packedColor)
    {
      this.__\u003C\u003Ecolor.abgr8888(packedColor);
      this.colorPacked = packedColor;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual float getPackedColor() => this.colorPacked;

    [LineNumberTable(new byte[] {22, 109, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void setMixColor(Color tint)
    {
      this.__\u003C\u003EmixColor.set(tint);
      this.mixColorPacked = tint.toFloatBits();
    }

    [LineNumberTable(new byte[] {27, 117, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void setMixColor(float r, float g, float b, float a)
    {
      this.__\u003C\u003EmixColor.set(r, g, b, a);
      this.mixColorPacked = this.__\u003C\u003EmixColor.toFloatBits();
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual Color getMixColor() => this.__\u003C\u003EmixColor;

    [LineNumberTable(new byte[] {36, 110, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void setPackedMixColor(float packedColor)
    {
      this.__\u003C\u003EmixColor.abgr8888(packedColor);
      this.mixColorPacked = packedColor;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual float getPackedMixColor() => this.mixColorPacked;

    protected internal abstract void draw(Texture t, float[] farr, int i1, int i2);

    protected internal abstract void draw(
      TextureRegion tr,
      float f1,
      float f2,
      float f3,
      float f4,
      float f5,
      float f6,
      float f7);

    [LineNumberTable(new byte[] {49, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void draw(Runnable request) => request.run();

    [LineNumberTable(new byte[] {55, 110, 134, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void setBlending(Blending blending)
    {
      if (!object.ReferenceEquals((object) this.blending, (object) blending))
        this.flush();
      this.blending = blending;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual Mat getProjection() => this.__\u003C\u003EprojectionMatrix;

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual Mat getTransform() => this.__\u003C\u003EtransformMatrix;

    [LineNumberTable(new byte[] {83, 102, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void setTransform(Mat transform)
    {
      this.flush();
      this.__\u003C\u003EtransformMatrix.set(transform);
    }

    [LineNumberTable(new byte[] {88, 125, 118, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void setupMatrices()
    {
      this.__\u003C\u003EcombinedMatrix.set(this.__\u003C\u003EprojectionMatrix).mul(this.__\u003C\u003EtransformMatrix);
      this.getShader().setUniformMatrix4("u_projTrans", this.__\u003C\u003EcombinedMatrix);
      this.getShader().setUniformi("u_texture", 0);
    }

    [LineNumberTable(new byte[] {94, 102, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void switchTexture(Texture texture)
    {
      this.flush();
      this.lastTexture = texture;
    }

    [LineNumberTable(new byte[] {99, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void setShader(Shader shader) => this.setShader(shader, true);

    [HideFromJava]
    public virtual bool isDisposed() => Disposable.\u003Cdefault\u003EisDisposed((Disposable) this);

    [Modifiers]
    protected internal Mat transformMatrix
    {
      [HideFromJava] get => this.__\u003C\u003EtransformMatrix;
      [HideFromJava] [param: In] private set => this.__\u003C\u003EtransformMatrix = value;
    }

    [Modifiers]
    protected internal Mat projectionMatrix
    {
      [HideFromJava] get => this.__\u003C\u003EprojectionMatrix;
      [HideFromJava] [param: In] private set => this.__\u003C\u003EprojectionMatrix = value;
    }

    [Modifiers]
    protected internal Mat combinedMatrix
    {
      [HideFromJava] get => this.__\u003C\u003EcombinedMatrix;
      [HideFromJava] [param: In] private set => this.__\u003C\u003EcombinedMatrix = value;
    }

    [Modifiers]
    protected internal Color color
    {
      [HideFromJava] get => this.__\u003C\u003Ecolor;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Ecolor = value;
    }

    [Modifiers]
    protected internal Color mixColor
    {
      [HideFromJava] get => this.__\u003C\u003EmixColor;
      [HideFromJava] [param: In] private set => this.__\u003C\u003EmixColor = value;
    }
  }
}
