// Decompiled with JetBrains decompiler
// Type: arc.graphics.gl.FrameBufferCubemap
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.util;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace arc.graphics.gl
{
  [Signature("Larc/graphics/gl/GLFrameBuffer<Larc/graphics/Cubemap;>;")]
  public class FrameBufferCubemap : GLFrameBuffer
  {
    [Modifiers]
    private static Cubemap.CubemapSide[] cubemapSides;
    private int currentSide;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 124, 166, 104, 104, 104, 106, 106, 135, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public FrameBufferCubemap(
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
      FrameBufferCubemap frameBufferCubemap = this;
      GLFrameBuffer.FrameBufferCubemapBuilder bufferCubemapBuilder = new GLFrameBuffer.FrameBufferCubemapBuilder(width, height);
      bufferCubemapBuilder.addBasicColorTextureAttachment(format);
      if (num1 != 0)
        bufferCubemapBuilder.addBasicDepthRenderBuffer();
      if (num2 != 0)
        bufferCubemapBuilder.addBasicStencilRenderBuffer();
      this.bufferBuilder = (GLFrameBuffer.GLFrameBufferBuilder) bufferCubemapBuilder;
      this.build();
    }

    [LineNumberTable(145)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cubemap.CubemapSide getSide() => this.currentSide < 0 ? (Cubemap.CubemapSide) null : FrameBufferCubemap.cubemapSides[this.currentSide];

    [LineNumberTable(new byte[] {90, 127, 7})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void bindSide(Cubemap.CubemapSide side) => Gl.framebufferTexture2D(36160, 36064, side.__\u003C\u003EglEnum, this.getTexture().getTextureObjectHandle(), 0);

    [LineNumberTable(new byte[] {52, 103, 102, 115, 56, 168})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void attachFrameBufferColorTexture(Cubemap texture)
    {
      int textureObjectHandle = texture.getTextureObjectHandle();
      Cubemap.CubemapSide[] cubemapSideArray = Cubemap.CubemapSide.values();
      int length = cubemapSideArray.Length;
      for (int index = 0; index < length; ++index)
        Gl.framebufferTexture2D(36160, 36064, cubemapSideArray[index].__\u003C\u003EglEnum, textureObjectHandle, 0);
    }

    [LineNumberTable(new byte[] {47, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void disposeColorTexture(Cubemap colorTexture) => colorTexture.dispose();

    [LineNumberTable(new byte[] {38, 127, 16, 108, 112, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual Cubemap createTexture(
      GLFrameBuffer.FrameBufferTextureAttachmentSpec attachmentSpec)
    {
      GLOnlyTextureData glOnlyTextureData = new GLOnlyTextureData(this.bufferBuilder.width, this.bufferBuilder.height, 0, attachmentSpec.internalFormat, attachmentSpec.format, attachmentSpec.type);
      Cubemap cubemap = new Cubemap((TextureData) glOnlyTextureData, (TextureData) glOnlyTextureData, (TextureData) glOnlyTextureData, (TextureData) glOnlyTextureData, (TextureData) glOnlyTextureData, (TextureData) glOnlyTextureData);
      cubemap.setFilter(Texture.TextureFilter.__\u003C\u003Elinear, Texture.TextureFilter.__\u003C\u003Elinear);
      cubemap.setWrap(Texture.TextureWrap.__\u003C\u003EclampToEdge, Texture.TextureWrap.__\u003C\u003EclampToEdge);
      return cubemap;
    }

    [LineNumberTable(new byte[] {159, 190, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal FrameBufferCubemap()
    {
    }

    [Signature("(Larc/graphics/gl/GLFrameBuffer$GLFrameBufferBuilder<+Larc/graphics/gl/GLFrameBuffer<Larc/graphics/Cubemap;>;>;)V")]
    [LineNumberTable(new byte[] {5, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal FrameBufferCubemap(GLFrameBuffer.GLFrameBufferBuilder bufferBuilder)
      : base(bufferBuilder)
    {
    }

    [LineNumberTable(new byte[] {159, 127, 131, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public FrameBufferCubemap(Pixmap.Format format, int width, int height, bool hasDepth)
    {
      int num = hasDepth ? 1 : 0;
      // ISSUE: explicit constructor call
      this.\u002Ector(format, width, height, num != 0, false);
    }

    [LineNumberTable(new byte[] {65, 103, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void bind()
    {
      this.currentSide = -1;
      base.bind();
    }

    [LineNumberTable(new byte[] {74, 105, 112, 105, 162, 110, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool nextSide()
    {
      if (this.currentSide > 5)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new ArcRuntimeException("No remaining sides.");
      }
      if (this.currentSide == 5)
        return false;
      ++this.currentSide;
      this.bindSide(this.getSide());
      return true;
    }

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(42)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void attachFrameBufferColorTexture(GLTexture glt) => this.attachFrameBufferColorTexture((Cubemap) glt);

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(42)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void disposeColorTexture(GLTexture glt) => this.disposeColorTexture((Cubemap) glt);

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(42)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    GLTexture GLFrameBuffer.\u003Cbridge\u003EcreateTexture(
      GLFrameBuffer.FrameBufferTextureAttachmentSpec glfbfbtas)
    {
      return (GLTexture) this.createTexture(glfbfbtas);
    }

    [LineNumberTable(44)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static FrameBufferCubemap()
    {
      if (ByteCodeHelper.isAlreadyInited("arc.graphics.gl.FrameBufferCubemap"))
        return;
      FrameBufferCubemap.cubemapSides = Cubemap.CubemapSide.values();
    }
  }
}
