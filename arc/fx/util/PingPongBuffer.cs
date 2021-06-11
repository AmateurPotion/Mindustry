// Decompiled with JetBrains decompiler
// Type: arc.fx.util.PingPongBuffer
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.graphics;
using arc.graphics.gl;
using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;

namespace arc.fx.util
{
  public sealed class PingPongBuffer : Object
  {
    [Modifiers]
    private FrameBuffer buffer1;
    [Modifiers]
    private FrameBuffer buffer2;
    private FrameBuffer bufDst;
    private FrameBuffer bufSrc;
    private bool writeState;
    private bool capturing;
    private Texture.TextureWrap wrapU;
    private Texture.TextureWrap wrapV;
    private Texture.TextureFilter filterMin;
    private Texture.TextureFilter filterMag;

    [LineNumberTable(new byte[] {159, 126, 102, 232, 41, 107, 107, 107, 235, 85, 112, 112, 166, 103, 108, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public PingPongBuffer(
      Pixmap.Format fbFormat,
      int width,
      int height,
      bool depth,
      bool stencil)
    {
      int num1 = depth ? 1 : 0;
      int num2 = stencil ? 1 : 0;
      // ISSUE: explicit constructor call
      base.\u002Ector();
      PingPongBuffer pingPongBuffer = this;
      this.wrapU = Texture.TextureWrap.__\u003C\u003EclampToEdge;
      this.wrapV = Texture.TextureWrap.__\u003C\u003EclampToEdge;
      this.filterMin = Texture.TextureFilter.__\u003C\u003Elinear;
      this.filterMag = Texture.TextureFilter.__\u003C\u003Elinear;
      this.buffer1 = new FrameBuffer(fbFormat, width, height, num1 != 0, num2 != 0);
      this.buffer2 = new FrameBuffer(fbFormat, width, height, num1 != 0, num2 != 0);
      this.rebind();
      this.writeState = false;
      this.bufDst = this.buffer1;
      this.bufSrc = this.buffer2;
    }

    [LineNumberTable(new byte[] {27, 107, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void dispose()
    {
      this.buffer1.dispose();
      this.buffer2.dispose();
    }

    [LineNumberTable(new byte[] {32, 109, 109, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void resize(int width, int height)
    {
      this.buffer1.resize(width, height);
      this.buffer2.resize(width, height);
      this.rebind();
    }

    [LineNumberTable(new byte[] {125, 103, 103, 103, 104, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setTextureParams(
      Texture.TextureWrap u,
      Texture.TextureWrap v,
      Texture.TextureFilter min,
      Texture.TextureFilter mag)
    {
      this.wrapU = u;
      this.wrapV = v;
      this.filterMin = min;
      this.filterMag = mag;
      this.rebind();
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual FrameBuffer getDstBuffer() => this.bufDst;

    [LineNumberTable(new byte[] {160, 70, 126})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void clear(Color clearColor) => this.clear(clearColor.r, clearColor.g, clearColor.b, clearColor.a);

    [LineNumberTable(new byte[] {60, 104, 176, 103, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void begin()
    {
      if (this.capturing)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalStateException("Ping pong buffer is already in capturing state.");
      }
      this.capturing = true;
      this.bufDst.begin();
    }

    [LineNumberTable(new byte[] {97, 104, 144, 107, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void end()
    {
      if (!this.capturing)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalStateException("Ping pong is not in capturing state. You should call begin() before calling end().");
      }
      this.bufDst.end();
      this.capturing = false;
    }

    [LineNumberTable(new byte[] {73, 104, 203, 104, 108, 142, 108, 172, 104, 171, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void swap()
    {
      if (this.capturing)
        this.bufDst.end();
      if (this.writeState)
      {
        this.bufSrc = this.buffer1;
        this.bufDst = this.buffer2;
      }
      else
      {
        this.bufSrc = this.buffer2;
        this.bufDst = this.buffer1;
      }
      if (this.capturing)
        this.bufDst.begin();
      this.writeState = !this.writeState;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual FrameBuffer getSrcBuffer() => this.bufSrc;

    [LineNumberTable(new byte[] {4, 123})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public PingPongBuffer(Pixmap.Format fbFormat)
      : this(fbFormat, Core.graphics.getWidth(), Core.graphics.getHeight())
    {
    }

    [LineNumberTable(new byte[] {42, 104, 113, 114, 146, 104, 113, 114, 146})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void rebind()
    {
      if (this.buffer1 != null)
      {
        Texture texture = (Texture) this.buffer1.getTexture();
        texture.setWrap(this.wrapU, this.wrapV);
        texture.setFilter(this.filterMin, this.filterMag);
      }
      if (this.buffer2 == null)
        return;
      Texture texture1 = (Texture) this.buffer2.getTexture();
      texture1.setWrap(this.wrapU, this.wrapV);
      texture1.setFilter(this.filterMin, this.filterMag);
    }

    [LineNumberTable(166)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Texture getDstTexture() => (Texture) this.bufDst.getTexture();

    [LineNumberTable(156)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Texture getSrcTexture() => (Texture) this.bufSrc.getTexture();

    [LineNumberTable(new byte[] {8, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public PingPongBuffer(Pixmap.Format fbFormat, int width, int height)
      : this(fbFormat, width, height, false, false)
    {
    }

    [LineNumberTable(new byte[] {160, 75, 135, 99, 166, 110, 106, 102, 138, 99, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void clear(float r, float g, float b, float a)
    {
      int num = this.capturing ? 1 : 0;
      if (num == 0)
        this.begin();
      Gl.clearColor(r, g, b, a);
      Gl.clear(16384);
      this.swap();
      Gl.clear(16384);
      if (num != 0)
        return;
      this.end();
    }
  }
}
