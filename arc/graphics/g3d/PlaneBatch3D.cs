// Decompiled with JetBrains decompiler
// Type: arc.graphics.g3d.PlaneBatch3D
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.graphics.g2d;
using arc.math;
using arc.math.geom;
using IKVM.Attributes;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.graphics.g3d
{
  public class PlaneBatch3D : Batch
  {
    internal Vec3 __\u003C\u003Eup;
    internal Vec3 __\u003C\u003Eright;
    internal Vec3 __\u003C\u003Eorigin;
    internal Vec3 __\u003C\u003Evec;
    internal VertexBatch3D __\u003C\u003Ebatch;
    internal float[] __\u003C\u003Evertex;
    protected internal float scaling;

    [LineNumberTable(new byte[] {159, 158, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public PlaneBatch3D()
      : this(5000)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setScaling(float scaling) => this.scaling = scaling;

    [LineNumberTable(new byte[] {159, 178, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void proj(Mat3D mat) => this.__\u003C\u003Ebatch.proj(mat);

    [LineNumberTable(new byte[] {159, 172, 109, 114, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setPlane(Vec3 origin, Vec3 up, Vec3 right)
    {
      this.__\u003C\u003Eorigin.set(origin);
      this.__\u003C\u003Eup.set(up).nor();
      this.__\u003C\u003Eright.set(right).nor();
    }

    [LineNumberTable(new byte[] {159, 161, 232, 55, 159, 13, 108, 235, 71, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public PlaneBatch3D(int vertices)
    {
      PlaneBatch3D planeBatch3D = this;
      this.__\u003C\u003Eup = new Vec3();
      this.__\u003C\u003Eright = new Vec3();
      this.__\u003C\u003Eorigin = new Vec3();
      this.__\u003C\u003Evec = new Vec3();
      this.__\u003C\u003Evertex = new float[6];
      this.scaling = 1f;
      this.__\u003C\u003Ebatch = new VertexBatch3D(vertices, false, true, 1);
    }

    [LineNumberTable(new byte[] {95, 119, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void checkFlush()
    {
      if (this.idx < this.__\u003C\u003Ebatch.getMaxVertices() / 6 / 6)
        return;
      this.flush();
    }

    [LineNumberTable(new byte[] {101, 127, 29, 115, 115, 115, 106, 107, 107, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void vertex([In] float obj0, [In] float obj1, [In] float obj2, [In] float obj3, [In] float obj4)
    {
      this.__\u003C\u003Evec.set(this.__\u003C\u003Eorigin).add(this.__\u003C\u003Eright, obj0 * this.scaling).add(this.__\u003C\u003Eup, obj1 * this.scaling);
      this.__\u003C\u003Evertex[0] = this.__\u003C\u003Evec.x;
      this.__\u003C\u003Evertex[1] = this.__\u003C\u003Evec.y;
      this.__\u003C\u003Evertex[2] = this.__\u003C\u003Evec.z;
      this.__\u003C\u003Evertex[3] = obj2;
      this.__\u003C\u003Evertex[4] = obj3;
      this.__\u003C\u003Evertex[5] = obj4;
      this.__\u003C\u003Ebatch.vertex(this.__\u003C\u003Evertex);
    }

    [LineNumberTable(new byte[] {159, 183, 112, 193, 134, 107, 108, 135, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void flush()
    {
      if (this.lastTexture == null || this.idx == 0)
        return;
      Gl.depthMask(false);
      this.lastTexture.bind();
      this.__\u003C\u003Ebatch.flush(4);
      this.idx = 0;
      Gl.depthMask(true);
    }

    [LineNumberTable(new byte[] {8, 103, 110, 167, 134, 104, 104, 101, 102, 106, 234, 76, 107, 139, 111, 143, 111, 143, 112, 144, 108, 140, 103, 103, 103, 103, 103, 103, 103, 135, 104, 104, 104, 104, 136, 112, 112, 144, 112, 112, 144, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void draw(
      TextureRegion region,
      float x,
      float y,
      float originX,
      float originY,
      float width,
      float height,
      float rotation)
    {
      Texture texture = region.texture;
      if (!object.ReferenceEquals((object) texture, (object) this.lastTexture))
        this.switchTexture(texture);
      this.checkFlush();
      float num1 = x + originX;
      float num2 = y + originY;
      float num3 = -originX;
      float num4 = -originY;
      float num5 = width - originX;
      float num6 = height - originY;
      float num7 = Mathf.cosDeg(rotation);
      float num8 = Mathf.sinDeg(rotation);
      float num9 = num7 * num3 - num8 * num4;
      float num10 = num8 * num3 + num7 * num4;
      float num11 = num7 * num3 - num8 * num6;
      float num12 = num8 * num3 + num7 * num6;
      float num13 = num7 * num5 - num8 * num6;
      float num14 = num8 * num5 + num7 * num6;
      float num15 = num9 + (num13 - num11);
      float num16 = num14 - (num12 - num10);
      float num17 = num9 + num1;
      float num18 = num10 + num2;
      float num19 = num11 + num1;
      float num20 = num12 + num2;
      float num21 = num13 + num1;
      float num22 = num14 + num2;
      float num23 = num15 + num1;
      float num24 = num16 + num2;
      float u = region.u;
      float v2 = region.v2;
      float u2 = region.u2;
      float v = region.v;
      float colorPacked = this.colorPacked;
      this.vertex(num19, num20, colorPacked, u, v);
      this.vertex(num17, num18, colorPacked, u, v2);
      this.vertex(num21, num22, colorPacked, u2, v);
      this.vertex(num23, num24, colorPacked, u2, v2);
      this.vertex(num21, num22, colorPacked, u2, v);
      this.vertex(num17, num18, colorPacked, u, v2);
      ++this.idx;
    }

    [LineNumberTable(new byte[] {75, 110, 167, 106, 134, 125, 127, 5, 159, 2, 127, 5, 125, 159, 5, 238, 53, 234, 77})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void draw(Texture texture, float[] v, int offset, int count)
    {
      if (!object.ReferenceEquals((object) texture, (object) this.lastTexture))
        this.switchTexture(texture);
      for (int index = offset; index < count; index += 24)
      {
        this.checkFlush();
        this.vertex(v[index], v[index + 1], v[index + 2], v[index + 3], v[index + 4]);
        this.vertex(v[index + 12], v[index + 13], v[index + 14], v[index + 15], v[index + 16]);
        this.vertex(v[index + 6], v[index + 7], v[index + 8], v[index + 9], v[index + 10]);
        this.vertex(v[index + 12], v[index + 13], v[index + 14], v[index + 15], v[index + 16]);
        this.vertex(v[index], v[index + 1], v[index + 2], v[index + 3], v[index + 4]);
        this.vertex(v[index + 18], v[index + 19], v[index + 20], v[index + 21], v[index + 22]);
        ++this.idx;
      }
    }

    [Modifiers]
    protected internal Vec3 up
    {
      [HideFromJava] get => this.__\u003C\u003Eup;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Eup = value;
    }

    [Modifiers]
    protected internal Vec3 right
    {
      [HideFromJava] get => this.__\u003C\u003Eright;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Eright = value;
    }

    [Modifiers]
    protected internal Vec3 origin
    {
      [HideFromJava] get => this.__\u003C\u003Eorigin;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Eorigin = value;
    }

    [Modifiers]
    protected internal Vec3 vec
    {
      [HideFromJava] get => this.__\u003C\u003Evec;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Evec = value;
    }

    [Modifiers]
    protected internal VertexBatch3D batch
    {
      [HideFromJava] get => this.__\u003C\u003Ebatch;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Ebatch = value;
    }

    [Modifiers]
    protected internal float[] vertex
    {
      [HideFromJava] get => this.__\u003C\u003Evertex;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Evertex = value;
    }
  }
}
