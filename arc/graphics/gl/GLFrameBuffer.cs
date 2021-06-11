// Decompiled with JetBrains decompiler
// Type: arc.graphics.gl.GLFrameBuffer
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.graphics.g2d;
using arc.util;
using IKVM.Attributes;
using java.lang;
using java.nio;
using java.util;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace arc.graphics.gl
{
  [Signature("<T:Larc/graphics/GLTexture;>Ljava/lang/Object;Larc/util/Disposable;")]
  public abstract class GLFrameBuffer : Object, Disposable
  {
    protected internal const int GL_DEPTH24_STENCIL8_OES = 35056;
    protected internal static GLFrameBuffer currentBoundFramebuffer;
    protected internal static int defaultFramebufferHandle;
    protected internal static int bufferNesting;
    protected internal static bool defaultFramebufferHandleInitialized;
    [Signature("Larc/struct/Seq<TT;>;")]
    protected internal Seq textureAttachments;
    protected internal GLFrameBuffer lastBoundFramebuffer;
    protected internal int framebufferHandle;
    protected internal int depthbufferHandle;
    protected internal int stencilbufferHandle;
    protected internal int depthStencilPackedBufferHandle;
    protected internal bool hasDepthStencilPackedBuffer;
    protected internal bool isMRT;
    [Signature("Larc/graphics/gl/GLFrameBuffer$GLFrameBufferBuilder<+Larc/graphics/gl/GLFrameBuffer<TT;>;>;")]
    protected internal GLFrameBuffer.GLFrameBufferBuilder bufferBuilder;

    [LineNumberTable(new byte[] {160, 197, 133, 102, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void begin()
    {
      Draw.flush();
      this.beginBind();
      this.setFrameBufferViewport();
    }

    [LineNumberTable(new byte[] {160, 220, 133, 136, 107, 173, 101, 187, 172, 139, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void end()
    {
      Draw.flush();
      if (this.lastBoundFramebuffer != null)
      {
        this.lastBoundFramebuffer.bind();
        this.lastBoundFramebuffer.setFrameBufferViewport();
      }
      else
      {
        GLFrameBuffer.unbind();
        Gl.viewport(0, 0, Core.graphics.getBackBufferWidth(), Core.graphics.getBackBufferHeight());
      }
      --GLFrameBuffer.bufferNesting;
      GLFrameBuffer.currentBoundFramebuffer = this.lastBoundFramebuffer;
      this.lastBoundFramebuffer = (GLFrameBuffer) null;
    }

    [LineNumberTable(new byte[] {160, 165, 127, 1, 103, 130, 104, 141, 120, 184, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void dispose()
    {
      Iterator iterator = this.textureAttachments.iterator();
      while (iterator.hasNext())
        this.disposeColorTexture((GLTexture) iterator.next());
      if (this.hasDepthStencilPackedBuffer)
      {
        Gl.deleteRenderbuffer(this.depthStencilPackedBufferHandle);
      }
      else
      {
        if (this.bufferBuilder.hasDepthRenderBuffer)
          Gl.deleteRenderbuffer(this.depthbufferHandle);
        if (this.bufferBuilder.hasStencilRenderBuffer)
          Gl.deleteRenderbuffer(this.stencilbufferHandle);
      }
      Gl.deleteFramebuffer(this.framebufferHandle);
    }

    [LineNumberTable(new byte[] {160, 190, 102, 125, 121})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void begin(Color clearColor)
    {
      this.begin();
      Gl.clearColor(clearColor.r, clearColor.g, clearColor.b, clearColor.a);
      Gl.clear(this.depthbufferHandle == 0 ? 16384 : 16640);
    }

    [LineNumberTable(406)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getWidth() => this.bufferBuilder.width;

    [LineNumberTable(401)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getHeight() => this.bufferBuilder.height;

    [Signature("()TT;")]
    [LineNumberTable(78)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual GLTexture getTexture() => (GLTexture) this.textureAttachments.first();

    [LineNumberTable(new byte[] {47, 166, 103, 102, 108, 119, 107, 108, 98, 230, 69, 153, 107, 144, 108, 140, 109, 107, 112, 188, 109, 107, 112, 188, 109, 107, 112, 220, 121, 99, 107, 127, 13, 106, 109, 105, 116, 38, 133, 104, 105, 113, 38, 135, 105, 113, 38, 165, 135, 125, 109, 179, 104, 105, 105, 48, 168, 105, 110, 98, 182, 109, 186, 109, 186, 109, 218, 107, 127, 5, 109, 130, 140, 127, 23, 113, 106, 109, 107, 135, 109, 107, 135, 109, 107, 167, 107, 103, 112, 113, 139, 154, 154, 204, 139, 108, 127, 5, 104, 130, 104, 141, 120, 184, 139, 105, 112, 105, 112, 105, 112, 105, 112, 159, 7})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void build()
    {
      this.checkValidBuilder();
      if (!GLFrameBuffer.defaultFramebufferHandleInitialized)
      {
        GLFrameBuffer.defaultFramebufferHandleInitialized = true;
        if (Core.app.isIOS())
        {
          IntBuffer @params = ByteBuffer.allocateDirect(64).order(ByteOrder.nativeOrder()).asIntBuffer();
          Gl.getIntegerv(36006, @params);
          GLFrameBuffer.defaultFramebufferHandle = @params.get(0);
        }
        else
          GLFrameBuffer.defaultFramebufferHandle = 0;
      }
      int framebuffer = GLFrameBuffer.currentBoundFramebuffer != null ? GLFrameBuffer.currentBoundFramebuffer.framebufferHandle : GLFrameBuffer.defaultFramebufferHandle;
      this.framebufferHandle = Gl.genFramebuffer();
      Gl.bindFramebuffer(36160, this.framebufferHandle);
      int width = this.bufferBuilder.width;
      int height = this.bufferBuilder.height;
      if (this.bufferBuilder.hasDepthRenderBuffer)
      {
        this.depthbufferHandle = Gl.genRenderbuffer();
        Gl.bindRenderbuffer(36161, this.depthbufferHandle);
        Gl.renderbufferStorage(36161, this.bufferBuilder.depthRenderBufferSpec.internalFormat, width, height);
      }
      if (this.bufferBuilder.hasStencilRenderBuffer)
      {
        this.stencilbufferHandle = Gl.genRenderbuffer();
        Gl.bindRenderbuffer(36161, this.stencilbufferHandle);
        Gl.renderbufferStorage(36161, this.bufferBuilder.stencilRenderBufferSpec.internalFormat, width, height);
      }
      if (this.bufferBuilder.hasPackedStencilDepthRenderBuffer)
      {
        this.depthStencilPackedBufferHandle = Gl.genRenderbuffer();
        Gl.bindRenderbuffer(36161, this.depthStencilPackedBufferHandle);
        Gl.renderbufferStorage(36161, this.bufferBuilder.packedStencilDepthRenderBufferSpec.internalFormat, width, height);
      }
      this.isMRT = this.bufferBuilder.textureAttachmentSpecs.size > 1;
      int num1 = 0;
      if (this.isMRT)
      {
        Iterator iterator = this.bufferBuilder.textureAttachmentSpecs.iterator();
        while (iterator.hasNext())
        {
          GLFrameBuffer.FrameBufferTextureAttachmentSpec glfbfbtas = (GLFrameBuffer.FrameBufferTextureAttachmentSpec) iterator.next();
          GLTexture texture = this.createTexture(glfbfbtas);
          this.textureAttachments.add((object) texture);
          if (glfbfbtas.isColorTexture())
          {
            Gl.framebufferTexture2D(36160, 36064 + num1, 3553, texture.getTextureObjectHandle(), 0);
            ++num1;
          }
          else if (glfbfbtas.isDepth)
            Gl.framebufferTexture2D(36160, 36096, 3553, texture.getTextureObjectHandle(), 0);
          else if (glfbfbtas.isStencil)
            Gl.framebufferTexture2D(36160, 36128, 3553, texture.getTextureObjectHandle(), 0);
        }
      }
      else
      {
        GLTexture texture = this.createTexture((GLFrameBuffer.FrameBufferTextureAttachmentSpec) this.bufferBuilder.textureAttachmentSpecs.first());
        this.textureAttachments.add((object) texture);
        Gl.bindTexture(texture.__\u003C\u003EglTarget, texture.getTextureObjectHandle());
      }
      if (this.isMRT)
      {
        IntBuffer ib = Buffers.newIntBuffer(num1);
        for (int index = 0; index < num1; ++index)
          ib.put(36064 + index);
        ((Buffer) ib).position(0);
        Core.gl30.glDrawBuffers(num1, ib);
      }
      else
        this.attachFrameBufferColorTexture((GLTexture) this.textureAttachments.first());
      if (this.bufferBuilder.hasDepthRenderBuffer)
        Gl.framebufferRenderbuffer(36160, 36096, 36161, this.depthbufferHandle);
      if (this.bufferBuilder.hasStencilRenderBuffer)
        Gl.framebufferRenderbuffer(36160, 36128, 36161, this.stencilbufferHandle);
      if (this.bufferBuilder.hasPackedStencilDepthRenderBuffer)
        Gl.framebufferRenderbuffer(36160, 33306, 36161, this.depthStencilPackedBufferHandle);
      Gl.bindRenderbuffer(36161, 0);
      Iterator iterator1 = this.textureAttachments.iterator();
      while (iterator1.hasNext())
        Gl.bindTexture(((GLTexture) iterator1.next()).__\u003C\u003EglTarget, 0);
      int num2 = Gl.checkFramebufferStatus(36160);
      if (num2 == 36061 && this.bufferBuilder.hasDepthRenderBuffer && this.bufferBuilder.hasStencilRenderBuffer && (Core.graphics.supportsExtension("GL_OES_packed_depth_stencil") || Core.graphics.supportsExtension("GL_EXT_packed_depth_stencil")))
      {
        if (this.bufferBuilder.hasDepthRenderBuffer)
        {
          Gl.deleteRenderbuffer(this.depthbufferHandle);
          this.depthbufferHandle = 0;
        }
        if (this.bufferBuilder.hasStencilRenderBuffer)
        {
          Gl.deleteRenderbuffer(this.stencilbufferHandle);
          this.stencilbufferHandle = 0;
        }
        if (this.bufferBuilder.hasPackedStencilDepthRenderBuffer)
        {
          Gl.deleteRenderbuffer(this.depthStencilPackedBufferHandle);
          this.depthStencilPackedBufferHandle = 0;
        }
        this.depthStencilPackedBufferHandle = Gl.genRenderbuffer();
        this.hasDepthStencilPackedBuffer = true;
        Gl.bindRenderbuffer(36161, this.depthStencilPackedBufferHandle);
        Gl.renderbufferStorage(36161, 35056, width, height);
        Gl.bindRenderbuffer(36161, 0);
        Gl.framebufferRenderbuffer(36160, 36096, 36161, this.depthStencilPackedBufferHandle);
        Gl.framebufferRenderbuffer(36160, 36128, 36161, this.depthStencilPackedBufferHandle);
        num2 = Gl.checkFramebufferStatus(36160);
      }
      Gl.bindFramebuffer(36160, framebuffer);
      if (num2 == 36053)
        return;
      Iterator iterator2 = this.textureAttachments.iterator();
      while (iterator2.hasNext())
        this.disposeColorTexture((GLTexture) iterator2.next());
      if (this.hasDepthStencilPackedBuffer)
      {
        Gl.deleteBuffer(this.depthStencilPackedBufferHandle);
      }
      else
      {
        if (this.bufferBuilder.hasDepthRenderBuffer)
          Gl.deleteRenderbuffer(this.depthbufferHandle);
        if (this.bufferBuilder.hasStencilRenderBuffer)
          Gl.deleteRenderbuffer(this.stencilbufferHandle);
      }
      Gl.deleteFramebuffer(this.framebufferHandle);
      switch (num2)
      {
        case 36054:
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalStateException("Frame buffer couldn't be constructed: incomplete attachment");
        case 36055:
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalStateException("Frame buffer couldn't be constructed: missing attachment");
        case 36057:
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalStateException("Frame buffer couldn't be constructed: incomplete dimensions");
        case 36061:
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalStateException("Frame buffer couldn't be constructed: unsupported combination of formats");
        default:
          string str = new StringBuilder().append("Frame buffer couldn't be constructed: unknown error ").append(num2).toString();
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalStateException(str);
      }
    }

    [LineNumberTable(new byte[] {160, 139, 139, 102, 109, 144, 115, 144, 127, 9, 104, 112, 104, 112, 104, 113, 176, 133})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void checkValidBuilder()
    {
      if (Core.graphics.isGL30Available())
        return;
      if (this.bufferBuilder.hasPackedStencilDepthRenderBuffer)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new ArcRuntimeException("Packed Stencil/Render render buffers are not available on GLES 2.0");
      }
      if (this.bufferBuilder.textureAttachmentSpecs.size > 1)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new ArcRuntimeException("Multiple render targets not available on GLES 2.0");
      }
      Iterator iterator = this.bufferBuilder.textureAttachmentSpecs.iterator();
      while (iterator.hasNext())
      {
        GLFrameBuffer.FrameBufferTextureAttachmentSpec textureAttachmentSpec = (GLFrameBuffer.FrameBufferTextureAttachmentSpec) iterator.next();
        if (textureAttachmentSpec.isDepth)
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new ArcRuntimeException("Depth texture FrameBuffer Attachment not available on GLES 2.0");
        }
        if (textureAttachmentSpec.isStencil)
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new ArcRuntimeException("Stencil texture FrameBuffer Attachment not available on GLES 2.0");
        }
        if (textureAttachmentSpec.isFloat && !Core.graphics.supportsExtension("OES_texture_float"))
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new ArcRuntimeException("Float texture FrameBuffer Attachment not available on GLES 2.0");
        }
      }
    }

    [Signature("(Larc/graphics/gl/GLFrameBuffer$FrameBufferTextureAttachmentSpec;)TT;")]
    protected internal abstract GLTexture createTexture(
      GLFrameBuffer.FrameBufferTextureAttachmentSpec glfbfbtas);

    [Signature("(TT;)V")]
    protected internal abstract void attachFrameBufferColorTexture(GLTexture glt);

    [Signature("(TT;)V")]
    protected internal abstract void disposeColorTexture(GLTexture glt);

    [LineNumberTable(new byte[] {160, 205, 157, 107, 102, 108, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void beginBind()
    {
      if (object.ReferenceEquals((object) GLFrameBuffer.currentBoundFramebuffer, (object) this))
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException("Do not begin() twice.");
      }
      this.lastBoundFramebuffer = GLFrameBuffer.currentBoundFramebuffer;
      GLFrameBuffer.currentBoundFramebuffer = this;
      ++GLFrameBuffer.bufferNesting;
      this.bind();
    }

    [LineNumberTable(new byte[] {160, 215, 125})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void setFrameBufferViewport() => Gl.viewport(0, 0, this.bufferBuilder.width, this.bufferBuilder.height);

    [LineNumberTable(new byte[] {160, 181, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void bind() => Gl.bindFramebuffer(36160, this.framebufferHandle);

    [LineNumberTable(new byte[] {23, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void unbind() => Gl.bindFramebuffer(36160, GLFrameBuffer.defaultFramebufferHandle);

    [LineNumberTable(new byte[] {8, 232, 45, 139, 231, 82})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal GLFrameBuffer()
    {
      GLFrameBuffer glFrameBuffer = this;
      this.textureAttachments = new Seq();
      this.lastBoundFramebuffer = (GLFrameBuffer) null;
    }

    [Signature("(Larc/graphics/gl/GLFrameBuffer$GLFrameBufferBuilder<+Larc/graphics/gl/GLFrameBuffer<TT;>;>;)V")]
    [LineNumberTable(new byte[] {12, 232, 41, 139, 231, 86, 103, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal GLFrameBuffer(GLFrameBuffer.GLFrameBufferBuilder bufferBuilder)
    {
      GLFrameBuffer glFrameBuffer = this;
      this.textureAttachments = new Seq();
      this.lastBoundFramebuffer = (GLFrameBuffer) null;
      this.bufferBuilder = bufferBuilder;
      this.build();
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int getBufferNesting() => GLFrameBuffer.bufferNesting;

    [Signature("()Larc/struct/Seq<TT;>;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Seq getTextureAttachments() => this.textureAttachments;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isBound() => object.ReferenceEquals((object) GLFrameBuffer.currentBoundFramebuffer, (object) this);

    [LineNumberTable(new byte[] {160, 243, 136, 173, 165, 172, 139, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void endBind()
    {
      if (this.lastBoundFramebuffer != null)
        this.lastBoundFramebuffer.bind();
      else
        GLFrameBuffer.unbind();
      --GLFrameBuffer.bufferNesting;
      GLFrameBuffer.currentBoundFramebuffer = this.lastBoundFramebuffer;
      this.lastBoundFramebuffer = (GLFrameBuffer) null;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getFramebufferHandle() => this.framebufferHandle;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getDepthBufferHandle() => this.depthbufferHandle;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getStencilBufferHandle() => this.stencilbufferHandle;

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual int getDepthStencilPackedBuffer() => this.depthStencilPackedBufferHandle;

    [HideFromJava]
    public virtual bool isDisposed() => Disposable.\u003Cdefault\u003EisDisposed((Disposable) this);

    [Signature("Larc/graphics/gl/GLFrameBuffer$GLFrameBufferBuilder<Larc/graphics/gl/FloatFrameBuffer;>;")]
    public class FloatFrameBufferBuilder : GLFrameBuffer.GLFrameBufferBuilder
    {
      [LineNumberTable(new byte[] {161, 163, 104})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public FloatFrameBufferBuilder(int width, int height)
        : base(width, height)
      {
      }

      [Modifiers]
      [LineNumberTable(531)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override GLFrameBuffer.GLFrameBufferBuilder addFloatAttachment(
        int i1,
        int i2,
        int i3,
        bool b)
      {
        int num = b ? 1 : 0;
        return base.addFloatAttachment(i1, i2, i3, num != 0);
      }

      [Modifiers]
      [LineNumberTable(531)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override GLFrameBuffer.GLFrameBufferBuilder addBasicDepthRenderBuffer() => base.addBasicDepthRenderBuffer();

      [LineNumberTable(538)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual FloatFrameBuffer build() => new FloatFrameBuffer((GLFrameBuffer.GLFrameBufferBuilder) this);

      [Modifiers]
      [EditorBrowsable(EditorBrowsableState.Never)]
      [LineNumberTable(531)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual GLFrameBuffer \u003Cbridge\u003Ebuild() => (GLFrameBuffer) this.build();

      [Modifiers]
      [LineNumberTable(531)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override GLFrameBuffer.GLFrameBufferBuilder addBasicStencilDepthPackedRenderBuffer() => base.addBasicStencilDepthPackedRenderBuffer();

      [Modifiers]
      [LineNumberTable(531)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override GLFrameBuffer.GLFrameBufferBuilder addBasicStencilRenderBuffer() => base.addBasicStencilRenderBuffer();

      [Modifiers]
      [LineNumberTable(531)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override GLFrameBuffer.GLFrameBufferBuilder addStencilDepthPackedRenderBuffer(
        int i)
      {
        return base.addStencilDepthPackedRenderBuffer(i);
      }

      [Modifiers]
      [LineNumberTable(531)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override GLFrameBuffer.GLFrameBufferBuilder addStencilRenderBuffer(int i) => base.addStencilRenderBuffer(i);

      [Modifiers]
      [LineNumberTable(531)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override GLFrameBuffer.GLFrameBufferBuilder addDepthRenderBuffer(int i) => base.addDepthRenderBuffer(i);

      [Modifiers]
      [LineNumberTable(531)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override GLFrameBuffer.GLFrameBufferBuilder addStencilTextureAttachment(
        int i1,
        int i2)
      {
        return base.addStencilTextureAttachment(i1, i2);
      }

      [Modifiers]
      [LineNumberTable(531)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override GLFrameBuffer.GLFrameBufferBuilder addDepthTextureAttachment(
        int i1,
        int i2)
      {
        return base.addDepthTextureAttachment(i1, i2);
      }

      [Modifiers]
      [LineNumberTable(531)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override GLFrameBuffer.GLFrameBufferBuilder addBasicColorTextureAttachment(
        Pixmap.Format pf)
      {
        return base.addBasicColorTextureAttachment(pf);
      }

      [Modifiers]
      [LineNumberTable(531)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override GLFrameBuffer.GLFrameBufferBuilder addColorTextureAttachment(
        int i1,
        int i2,
        int i3)
      {
        return base.addColorTextureAttachment(i1, i2, i3);
      }
    }

    [Signature("Larc/graphics/gl/GLFrameBuffer$GLFrameBufferBuilder<Larc/graphics/gl/FrameBuffer;>;")]
    public class FrameBufferBuilder : GLFrameBuffer.GLFrameBufferBuilder
    {
      [LineNumberTable(new byte[] {161, 152, 104})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public FrameBufferBuilder(int width, int height)
        : base(width, height)
      {
      }

      [Modifiers]
      [LineNumberTable(520)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override GLFrameBuffer.GLFrameBufferBuilder addBasicColorTextureAttachment(
        Pixmap.Format pf)
      {
        return base.addBasicColorTextureAttachment(pf);
      }

      [Modifiers]
      [LineNumberTable(520)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override GLFrameBuffer.GLFrameBufferBuilder addBasicDepthRenderBuffer() => base.addBasicDepthRenderBuffer();

      [Modifiers]
      [LineNumberTable(520)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override GLFrameBuffer.GLFrameBufferBuilder addBasicStencilRenderBuffer() => base.addBasicStencilRenderBuffer();

      [LineNumberTable(527)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual FrameBuffer build() => new FrameBuffer((GLFrameBuffer.GLFrameBufferBuilder) this);

      [Modifiers]
      [EditorBrowsable(EditorBrowsableState.Never)]
      [LineNumberTable(520)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual GLFrameBuffer \u003Cbridge\u003Ebuild() => (GLFrameBuffer) this.build();

      [Modifiers]
      [LineNumberTable(520)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override GLFrameBuffer.GLFrameBufferBuilder addBasicStencilDepthPackedRenderBuffer() => base.addBasicStencilDepthPackedRenderBuffer();

      [Modifiers]
      [LineNumberTable(520)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override GLFrameBuffer.GLFrameBufferBuilder addStencilDepthPackedRenderBuffer(
        int i)
      {
        return base.addStencilDepthPackedRenderBuffer(i);
      }

      [Modifiers]
      [LineNumberTable(520)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override GLFrameBuffer.GLFrameBufferBuilder addStencilRenderBuffer(int i) => base.addStencilRenderBuffer(i);

      [Modifiers]
      [LineNumberTable(520)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override GLFrameBuffer.GLFrameBufferBuilder addDepthRenderBuffer(int i) => base.addDepthRenderBuffer(i);

      [Modifiers]
      [LineNumberTable(520)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override GLFrameBuffer.GLFrameBufferBuilder addStencilTextureAttachment(
        int i1,
        int i2)
      {
        return base.addStencilTextureAttachment(i1, i2);
      }

      [Modifiers]
      [LineNumberTable(520)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override GLFrameBuffer.GLFrameBufferBuilder addDepthTextureAttachment(
        int i1,
        int i2)
      {
        return base.addDepthTextureAttachment(i1, i2);
      }

      [Modifiers]
      [LineNumberTable(520)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override GLFrameBuffer.GLFrameBufferBuilder addFloatAttachment(
        int i1,
        int i2,
        int i3,
        bool b)
      {
        int num = b ? 1 : 0;
        return base.addFloatAttachment(i1, i2, i3, num != 0);
      }

      [Modifiers]
      [LineNumberTable(520)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override GLFrameBuffer.GLFrameBufferBuilder addColorTextureAttachment(
        int i1,
        int i2,
        int i3)
      {
        return base.addColorTextureAttachment(i1, i2, i3);
      }
    }

    [Signature("Larc/graphics/gl/GLFrameBuffer$GLFrameBufferBuilder<Larc/graphics/gl/FrameBufferCubemap;>;")]
    public class FrameBufferCubemapBuilder : GLFrameBuffer.GLFrameBufferBuilder
    {
      [LineNumberTable(new byte[] {161, 174, 104})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public FrameBufferCubemapBuilder(int width, int height)
        : base(width, height)
      {
      }

      [Modifiers]
      [LineNumberTable(542)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override GLFrameBuffer.GLFrameBufferBuilder addBasicColorTextureAttachment(
        Pixmap.Format pf)
      {
        return base.addBasicColorTextureAttachment(pf);
      }

      [Modifiers]
      [LineNumberTable(542)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override GLFrameBuffer.GLFrameBufferBuilder addBasicDepthRenderBuffer() => base.addBasicDepthRenderBuffer();

      [Modifiers]
      [LineNumberTable(542)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override GLFrameBuffer.GLFrameBufferBuilder addBasicStencilRenderBuffer() => base.addBasicStencilRenderBuffer();

      [LineNumberTable(549)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual FrameBufferCubemap build() => new FrameBufferCubemap((GLFrameBuffer.GLFrameBufferBuilder) this);

      [Modifiers]
      [EditorBrowsable(EditorBrowsableState.Never)]
      [LineNumberTable(542)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual GLFrameBuffer \u003Cbridge\u003Ebuild() => (GLFrameBuffer) this.build();

      [Modifiers]
      [LineNumberTable(542)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override GLFrameBuffer.GLFrameBufferBuilder addBasicStencilDepthPackedRenderBuffer() => base.addBasicStencilDepthPackedRenderBuffer();

      [Modifiers]
      [LineNumberTable(542)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override GLFrameBuffer.GLFrameBufferBuilder addStencilDepthPackedRenderBuffer(
        int i)
      {
        return base.addStencilDepthPackedRenderBuffer(i);
      }

      [Modifiers]
      [LineNumberTable(542)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override GLFrameBuffer.GLFrameBufferBuilder addStencilRenderBuffer(int i) => base.addStencilRenderBuffer(i);

      [Modifiers]
      [LineNumberTable(542)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override GLFrameBuffer.GLFrameBufferBuilder addDepthRenderBuffer(int i) => base.addDepthRenderBuffer(i);

      [Modifiers]
      [LineNumberTable(542)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override GLFrameBuffer.GLFrameBufferBuilder addStencilTextureAttachment(
        int i1,
        int i2)
      {
        return base.addStencilTextureAttachment(i1, i2);
      }

      [Modifiers]
      [LineNumberTable(542)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override GLFrameBuffer.GLFrameBufferBuilder addDepthTextureAttachment(
        int i1,
        int i2)
      {
        return base.addDepthTextureAttachment(i1, i2);
      }

      [Modifiers]
      [LineNumberTable(542)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override GLFrameBuffer.GLFrameBufferBuilder addFloatAttachment(
        int i1,
        int i2,
        int i3,
        bool b)
      {
        int num = b ? 1 : 0;
        return base.addFloatAttachment(i1, i2, i3, num != 0);
      }

      [Modifiers]
      [LineNumberTable(542)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override GLFrameBuffer.GLFrameBufferBuilder addColorTextureAttachment(
        int i1,
        int i2,
        int i3)
      {
        return base.addColorTextureAttachment(i1, i2, i3);
      }
    }

    [InnerClass]
    public class FrameBufferRenderBufferAttachmentSpec : Object
    {
      internal int internalFormat;

      [LineNumberTable(new byte[] {161, 59, 104, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public FrameBufferRenderBufferAttachmentSpec(int internalFormat)
      {
        GLFrameBuffer.FrameBufferRenderBufferAttachmentSpec bufferAttachmentSpec = this;
        this.internalFormat = internalFormat;
      }
    }

    [InnerClass]
    public class FrameBufferTextureAttachmentSpec : Object
    {
      internal int internalFormat;
      internal int format;
      internal int type;
      internal bool isFloat;
      internal bool isGpuOnly;
      internal bool isDepth;
      internal bool isStencil;

      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual bool isColorTexture() => !this.isDepth && !this.isStencil;

      [LineNumberTable(new byte[] {161, 45, 104, 103, 103, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public FrameBufferTextureAttachmentSpec(int internalformat, int format, int type)
      {
        GLFrameBuffer.FrameBufferTextureAttachmentSpec textureAttachmentSpec = this;
        this.internalFormat = internalformat;
        this.format = format;
        this.type = type;
      }
    }

    [InnerClass]
    [Signature("<U:Larc/graphics/gl/GLFrameBuffer<+Larc/graphics/GLTexture;>;>Ljava/lang/Object;")]
    public abstract class GLFrameBufferBuilder : Object
    {
      protected internal int width;
      protected internal int height;
      [Signature("Larc/struct/Seq<Larc/graphics/gl/GLFrameBuffer$FrameBufferTextureAttachmentSpec;>;")]
      protected internal Seq textureAttachmentSpecs;
      protected internal GLFrameBuffer.FrameBufferRenderBufferAttachmentSpec stencilRenderBufferSpec;
      protected internal GLFrameBuffer.FrameBufferRenderBufferAttachmentSpec depthRenderBufferSpec;
      protected internal GLFrameBuffer.FrameBufferRenderBufferAttachmentSpec packedStencilDepthRenderBufferSpec;
      protected internal bool hasStencilRenderBuffer;
      protected internal bool hasDepthRenderBuffer;
      protected internal bool hasPackedStencilDepthRenderBuffer;

      [Signature("(Larc/graphics/Pixmap$Format;)Larc/graphics/gl/GLFrameBuffer$GLFrameBufferBuilder<TU;>;")]
      [LineNumberTable(new byte[] {161, 88, 103, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual GLFrameBuffer.GLFrameBufferBuilder addBasicColorTextureAttachment(
        Pixmap.Format format)
      {
        int glFormat = format.toGlFormat();
        int glType = format.toGlType();
        return this.addColorTextureAttachment(glFormat, glFormat, glType);
      }

      [Signature("()Larc/graphics/gl/GLFrameBuffer$GLFrameBufferBuilder<TU;>;")]
      [LineNumberTable(506)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual GLFrameBuffer.GLFrameBufferBuilder addBasicDepthRenderBuffer() => this.addDepthRenderBuffer(33189);

      [Signature("()Larc/graphics/gl/GLFrameBuffer$GLFrameBufferBuilder<TU;>;")]
      [LineNumberTable(510)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual GLFrameBuffer.GLFrameBufferBuilder addBasicStencilRenderBuffer() => this.addStencilRenderBuffer(36168);

      [Signature("(IIIZ)Larc/graphics/gl/GLFrameBuffer$GLFrameBufferBuilder<TU;>;")]
      [LineNumberTable(new byte[] {159, 26, 67, 105, 103, 103, 108})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual GLFrameBuffer.GLFrameBufferBuilder addFloatAttachment(
        int internalFormat,
        int format,
        int type,
        bool gpuOnly)
      {
        int num = gpuOnly ? 1 : 0;
        this.textureAttachmentSpecs.add((object) new GLFrameBuffer.FrameBufferTextureAttachmentSpec(internalFormat, format, type)
        {
          isFloat = true,
          isGpuOnly = (num != 0)
        });
        return this;
      }

      [Signature("(III)Larc/graphics/gl/GLFrameBuffer$GLFrameBufferBuilder<TU;>;")]
      [LineNumberTable(new byte[] {161, 83, 115})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual GLFrameBuffer.GLFrameBufferBuilder addColorTextureAttachment(
        int internalFormat,
        int format,
        int type)
      {
        this.textureAttachmentSpecs.add((object) new GLFrameBuffer.FrameBufferTextureAttachmentSpec(internalFormat, format, type));
        return this;
      }

      [Signature("(I)Larc/graphics/gl/GLFrameBuffer$GLFrameBufferBuilder<TU;>;")]
      [LineNumberTable(new byte[] {161, 118, 108, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual GLFrameBuffer.GLFrameBufferBuilder addDepthRenderBuffer(
        int internalFormat)
      {
        this.depthRenderBufferSpec = new GLFrameBuffer.FrameBufferRenderBufferAttachmentSpec(internalFormat);
        this.hasDepthRenderBuffer = true;
        return this;
      }

      [Signature("(I)Larc/graphics/gl/GLFrameBuffer$GLFrameBufferBuilder<TU;>;")]
      [LineNumberTable(new byte[] {161, 124, 108, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual GLFrameBuffer.GLFrameBufferBuilder addStencilRenderBuffer(
        int internalFormat)
      {
        this.stencilRenderBufferSpec = new GLFrameBuffer.FrameBufferRenderBufferAttachmentSpec(internalFormat);
        this.hasStencilRenderBuffer = true;
        return this;
      }

      [Signature("(I)Larc/graphics/gl/GLFrameBuffer$GLFrameBufferBuilder<TU;>;")]
      [LineNumberTable(new byte[] {161, 130, 108, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual GLFrameBuffer.GLFrameBufferBuilder addStencilDepthPackedRenderBuffer(
        int internalFormat)
      {
        this.packedStencilDepthRenderBufferSpec = new GLFrameBuffer.FrameBufferRenderBufferAttachmentSpec(internalFormat);
        this.hasPackedStencilDepthRenderBuffer = true;
        return this;
      }

      [LineNumberTable(new byte[] {161, 77, 232, 54, 235, 75, 103, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public GLFrameBufferBuilder(int width, int height)
      {
        GLFrameBuffer.GLFrameBufferBuilder frameBufferBuilder = this;
        this.textureAttachmentSpecs = new Seq();
        this.width = width;
        this.height = height;
      }

      [Signature("(II)Larc/graphics/gl/GLFrameBuffer$GLFrameBufferBuilder<TU;>;")]
      [LineNumberTable(new byte[] {161, 102, 141, 103, 108})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual GLFrameBuffer.GLFrameBufferBuilder addDepthTextureAttachment(
        int internalFormat,
        int type)
      {
        this.textureAttachmentSpecs.add((object) new GLFrameBuffer.FrameBufferTextureAttachmentSpec(internalFormat, 6402, type)
        {
          isDepth = true
        });
        return this;
      }

      [Signature("(II)Larc/graphics/gl/GLFrameBuffer$GLFrameBufferBuilder<TU;>;")]
      [LineNumberTable(new byte[] {161, 110, 141, 103, 108})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual GLFrameBuffer.GLFrameBufferBuilder addStencilTextureAttachment(
        int internalFormat,
        int type)
      {
        this.textureAttachmentSpecs.add((object) new GLFrameBuffer.FrameBufferTextureAttachmentSpec(internalFormat, 36128, type)
        {
          isStencil = true
        });
        return this;
      }

      [Signature("()Larc/graphics/gl/GLFrameBuffer$GLFrameBufferBuilder<TU;>;")]
      [LineNumberTable(514)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual GLFrameBuffer.GLFrameBufferBuilder addBasicStencilDepthPackedRenderBuffer() => this.addStencilDepthPackedRenderBuffer(35056);

      [Signature("()TU;")]
      public abstract GLFrameBuffer build();
    }
  }
}
