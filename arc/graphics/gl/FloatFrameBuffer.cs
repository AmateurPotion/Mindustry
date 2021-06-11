// Decompiled with JetBrains decompiler
// Type: arc.graphics.gl.FloatFrameBuffer
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace arc.graphics.gl
{
  public class FloatFrameBuffer : FrameBuffer
  {
    [LineNumberTable(new byte[] {159, 191, 255, 21, 69, 103, 108, 178, 112, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override Texture createTexture(
      GLFrameBuffer.FrameBufferTextureAttachmentSpec attachmentSpec)
    {
      Texture texture = new Texture((TextureData) new FloatTextureData(this.bufferBuilder.width, this.bufferBuilder.height, attachmentSpec.internalFormat, attachmentSpec.format, attachmentSpec.type, attachmentSpec.isGpuOnly));
      if (Core.app.isDesktop())
        texture.setFilter(Texture.TextureFilter.__\u003C\u003Elinear, Texture.TextureFilter.__\u003C\u003Elinear);
      else
        texture.setFilter(Texture.TextureFilter.__\u003C\u003Enearest, Texture.TextureFilter.__\u003C\u003Enearest);
      texture.setWrap(Texture.TextureWrap.__\u003C\u003EclampToEdge, Texture.TextureWrap.__\u003C\u003EclampToEdge);
      return texture;
    }

    [LineNumberTable(new byte[] {159, 153, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal FloatFrameBuffer()
    {
    }

    [Signature("(Larc/graphics/gl/GLFrameBuffer$GLFrameBufferBuilder<+Larc/graphics/gl/GLFrameBuffer<Larc/graphics/Texture;>;>;)V")]
    [LineNumberTable(new byte[] {159, 160, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal FloatFrameBuffer(GLFrameBuffer.GLFrameBufferBuilder bufferBuilder)
      : base(bufferBuilder)
    {
    }

    [LineNumberTable(new byte[] {159, 135, 66, 104, 104, 119, 106, 135, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public FloatFrameBuffer(int width, int height, bool hasDepth)
    {
      int num = hasDepth ? 1 : 0;
      // ISSUE: explicit constructor call
      base.\u002Ector();
      FloatFrameBuffer floatFrameBuffer = this;
      GLFrameBuffer.FloatFrameBufferBuilder frameBufferBuilder = new GLFrameBuffer.FloatFrameBufferBuilder(width, height);
      frameBufferBuilder.addFloatAttachment(34836, 6408, 5126, false);
      if (num != 0)
        frameBufferBuilder.addBasicDepthRenderBuffer();
      this.bufferBuilder = (GLFrameBuffer.GLFrameBufferBuilder) frameBufferBuilder;
      this.build();
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void create(
      Pixmap.Format format,
      int width,
      int height,
      bool hasDepth,
      bool hasStencil)
    {
    }

    [LineNumberTable(44)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void resize(int width, int height)
    {
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new IllegalArgumentException("resize() is currently unsupported here.");
    }

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(9)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override GLTexture \u003Cbridge\u003EcreateTexture(
      GLFrameBuffer.FrameBufferTextureAttachmentSpec glfbfbtas)
    {
      return (GLTexture) this.createTexture(glfbfbtas);
    }
  }
}
