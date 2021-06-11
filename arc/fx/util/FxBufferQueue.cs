// Decompiled with JetBrains decompiler
// Type: arc.fx.util.FxBufferQueue
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.graphics;
using arc.graphics.gl;
using arc.util;
using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;

namespace arc.fx.util
{
  public class FxBufferQueue : Object, Disposable
  {
    [Modifiers]
    [Signature("Larc/struct/Seq<Larc/graphics/gl/FrameBuffer;>;")]
    private Seq buffers;
    private int currentIdx;
    private Texture.TextureWrap wrapU;
    private Texture.TextureWrap wrapV;
    private Texture.TextureFilter filterMin;
    private Texture.TextureFilter filterMag;

    [LineNumberTable(new byte[] {159, 161, 232, 57, 135, 107, 107, 107, 171, 100, 144, 109, 102, 51, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public FxBufferQueue(Pixmap.Format pixelFormat, int fboAmount)
    {
      FxBufferQueue fxBufferQueue = this;
      this.currentIdx = 0;
      this.wrapU = Texture.TextureWrap.__\u003C\u003EclampToEdge;
      this.wrapV = Texture.TextureWrap.__\u003C\u003EclampToEdge;
      this.filterMin = Texture.TextureFilter.__\u003C\u003Enearest;
      this.filterMag = Texture.TextureFilter.__\u003C\u003Enearest;
      if (fboAmount < 1)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException("FBO amount should be a positive number.");
      }
      this.buffers = new Seq(true, fboAmount);
      for (int index = 0; index < fboAmount; ++index)
        this.buffers.add((object) new FrameBuffer(pixelFormat, 4, 4));
    }

    [LineNumberTable(new byte[] {159, 179, 112, 56, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void resize(int width, int height)
    {
      for (int index = 0; index < this.buffers.size; ++index)
        ((FrameBuffer) this.buffers.get(index)).resize(width, height);
    }

    [LineNumberTable(new byte[] {159, 173, 112, 54, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void dispose()
    {
      for (int index = 0; index < this.buffers.size; ++index)
        ((GLFrameBuffer) this.buffers.get(index)).dispose();
    }

    [LineNumberTable(new byte[] {159, 188, 112, 146, 133, 108, 114, 242, 57, 233, 73})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void rebind()
    {
      for (int index = 0; index < this.buffers.size; ++index)
      {
        FrameBuffer frameBuffer = (FrameBuffer) this.buffers.get(index);
        if (frameBuffer != null)
        {
          Texture texture = (Texture) frameBuffer.getTexture();
          texture.setWrap(this.wrapU, this.wrapV);
          texture.setFilter(this.filterMin, this.filterMag);
        }
      }
    }

    [LineNumberTable(new byte[] {12, 127, 4})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual FrameBuffer changeToNext()
    {
      int num = this.currentIdx + 1;
      int size = this.buffers.size;
      this.currentIdx = size != -1 ? num % size : 0;
      return this.getCurrent();
    }

    [LineNumberTable(58)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual FrameBuffer getCurrent() => (FrameBuffer) this.buffers.get(this.currentIdx);

    [LineNumberTable(new byte[] {17, 103, 103, 103, 104, 102})]
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

    [HideFromJava]
    public virtual bool isDisposed() => Disposable.\u003Cdefault\u003EisDisposed((Disposable) this);
  }
}
