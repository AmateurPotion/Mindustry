// Decompiled with JetBrains decompiler
// Type: arc.graphics.gl.FrameBuffer
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.graphics.g2d;
using IKVM.Attributes;
using java.lang;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace arc.graphics.gl
{
  [Signature("Larc/graphics/gl/GLFrameBuffer<Larc/graphics/Texture;>;")]
  public class FrameBuffer : GLFrameBuffer
  {
    private Pixmap.Format format;

    [LineNumberTable(new byte[] {159, 180, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public FrameBuffer()
      : this(2, 2)
    {
    }

    [LineNumberTable(new byte[] {44, 105, 169, 147, 127, 3, 122, 134, 105, 110, 107, 107, 104, 108, 103, 103, 103, 103, 117, 102, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void resize(int width, int height)
    {
      width = Math.max(width, 2);
      height = Math.max(height, 2);
      if (width == this.getWidth() && height == this.getHeight())
        return;
      Texture.TextureFilter minFilter = this.getTexture().getMinFilter();
      Texture.TextureFilter magFilter = this.getTexture().getMagFilter();
      int num1 = this.depthbufferHandle == 0 ? 0 : 1;
      int num2 = this.stencilbufferHandle == 0 ? 0 : 1;
      this.dispose();
      GLFrameBuffer.FrameBufferBuilder frameBufferBuilder = new GLFrameBuffer.FrameBufferBuilder(width, height);
      frameBufferBuilder.addBasicColorTextureAttachment(this.format);
      if (num1 != 0)
        frameBufferBuilder.addBasicDepthRenderBuffer();
      if (num2 != 0)
        frameBufferBuilder.addBasicStencilRenderBuffer();
      this.bufferBuilder = (GLFrameBuffer.GLFrameBufferBuilder) frameBufferBuilder;
      this.textureAttachments.clear();
      this.framebufferHandle = 0;
      this.depthbufferHandle = 0;
      this.stencilbufferHandle = 0;
      this.depthStencilPackedBufferHandle = 0;
      FrameBuffer frameBuffer = this;
      int num3 = 0;
      int num4 = num3;
      this.isMRT = num3 != 0;
      this.hasDepthStencilPackedBuffer = num4 != 0;
      this.build();
      this.getTexture().setFilter(minFilter, magFilter);
    }

    [LineNumberTable(new byte[] {159, 185, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public FrameBuffer(int width, int height)
      : this(Pixmap.Format.__\u003C\u003Ergba8888, width, height, false, false)
    {
    }

    [LineNumberTable(new byte[] {38, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void blit(Shader shader) => Draw.blit(this, shader);

    [LineNumberTable(new byte[] {159, 129, 99, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public FrameBuffer(Pixmap.Format format, int width, int height, bool hasDepth)
    {
      int num = hasDepth ? 1 : 0;
      // ISSUE: explicit constructor call
      this.\u002Ector(format, width, height, num != 0, false);
    }

    [LineNumberTable(new byte[] {159, 128, 130, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public FrameBuffer(int width, int height, bool hasDepth)
    {
      int num = hasDepth ? 1 : 0;
      // ISSUE: explicit constructor call
      this.\u002Ector(Pixmap.Format.__\u003C\u003Ergba8888, width, height, num != 0, false);
    }

    [LineNumberTable(new byte[] {159, 125, 134, 104, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public FrameBuffer(
      Pixmap.Format format,
      int width,
      int height,
      bool hasDepth,
      bool hasStencil)
    {
      int num1 = hasDepth ? 1 : 0;
      int num2 = hasStencil ? 1 : 0;
      // ISSUE: explicit constructor call
      base.\u002Ector();
      FrameBuffer frameBuffer = this;
      this.create(format, width, height, num1 != 0, num2 != 0);
    }

    [LineNumberTable(new byte[] {159, 124, 166, 105, 105, 103, 104, 104, 106, 106, 103, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void create(
      Pixmap.Format format,
      int width,
      int height,
      bool hasDepth,
      bool hasStencil)
    {
      int num1 = hasDepth ? 1 : 0;
      int num2 = hasStencil ? 1 : 0;
      width = Math.max(width, 2);
      height = Math.max(height, 2);
      this.format = format;
      GLFrameBuffer.FrameBufferBuilder frameBufferBuilder = new GLFrameBuffer.FrameBufferBuilder(width, height);
      frameBufferBuilder.addBasicColorTextureAttachment(format);
      if (num1 != 0)
        frameBufferBuilder.addBasicDepthRenderBuffer();
      if (num2 != 0)
        frameBufferBuilder.addBasicStencilRenderBuffer();
      this.bufferBuilder = (GLFrameBuffer.GLFrameBufferBuilder) frameBufferBuilder;
      this.build();
    }

    [LineNumberTable(new byte[] {90, 123})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void attachFrameBufferColorTexture(Texture texture) => Gl.framebufferTexture2D(36160, 36064, 3553, texture.getTextureObjectHandle(), 0);

    [LineNumberTable(new byte[] {85, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void disposeColorTexture(Texture colorTexture) => colorTexture.dispose();

    [LineNumberTable(new byte[] {76, 127, 16, 103, 112, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual Texture createTexture(
      GLFrameBuffer.FrameBufferTextureAttachmentSpec attachmentSpec)
    {
      Texture texture = new Texture((TextureData) new GLOnlyTextureData(this.bufferBuilder.width, this.bufferBuilder.height, 0, attachmentSpec.internalFormat, attachmentSpec.format, attachmentSpec.type));
      texture.setFilter(Texture.TextureFilter.__\u003C\u003Elinear, Texture.TextureFilter.__\u003C\u003Elinear);
      texture.setWrap(Texture.TextureWrap.__\u003C\u003EclampToEdge, Texture.TextureWrap.__\u003C\u003EclampToEdge);
      return texture;
    }

    [Signature("(Larc/graphics/gl/GLFrameBuffer$GLFrameBufferBuilder<+Larc/graphics/gl/GLFrameBuffer<Larc/graphics/Texture;>;>;)V")]
    [LineNumberTable(new byte[] {159, 175, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal FrameBuffer(GLFrameBuffer.GLFrameBufferBuilder bufferBuilder)
      : base(bufferBuilder)
    {
    }

    [LineNumberTable(new byte[] {159, 190, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public FrameBuffer(Pixmap.Format format, int width, int height)
      : this(format, width, height, false, false)
    {
    }

    [LineNumberTable(new byte[] {71, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void unbind() => GLFrameBuffer.unbind();

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(26)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void attachFrameBufferColorTexture(GLTexture glt) => this.attachFrameBufferColorTexture((Texture) glt);

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(26)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void disposeColorTexture(GLTexture glt) => this.disposeColorTexture((Texture) glt);

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(26)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    GLTexture GLFrameBuffer.\u003Cbridge\u003EcreateTexture(
      GLFrameBuffer.FrameBufferTextureAttachmentSpec glfbfbtas)
    {
      return (GLTexture) this.createTexture(glfbfbtas);
    }
  }
}
