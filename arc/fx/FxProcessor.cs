// Decompiled with JetBrains decompiler
// Type: arc.fx.FxProcessor
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.func;
using arc.fx.util;
using arc.graphics;
using arc.graphics.g2d;
using arc.graphics.gl;
using arc.util;
using IKVM.Attributes;
using java.lang;
using java.util;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.fx
{
  public sealed class FxProcessor : Object, Disposable
  {
    [Modifiers]
    [Signature("Larc/struct/ObjectIntMap<Larc/fx/FxFilter;>;")]
    private ObjectIntMap priorities;
    [Modifiers]
    [Signature("Larc/struct/Seq<Larc/fx/FxFilter;>;")]
    private Seq effectsAll;
    [Modifiers]
    [Signature("Larc/struct/Seq<Larc/fx/FxFilter;>;")]
    private Seq effectsEnabled;
    [Modifiers]
    private FxBufferRenderer bufferRenderer;
    [Modifiers]
    private Pixmap.Format fboFormat;
    [Modifiers]
    private PingPongBuffer pingPongBuffer;
    private bool disabled;
    private bool capturing;
    private bool hasCaptured;
    private bool applyingEffects;
    private bool blendingEnabled;
    private int width;
    private int height;

    [LineNumberTable(new byte[] {159, 129, 166, 232, 31, 139, 139, 171, 235, 69, 103, 103, 103, 135, 231, 81, 103, 112, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public FxProcessor(
      Pixmap.Format fboFormat,
      int bufferWidth,
      int bufferHeight,
      bool depth,
      bool stencil)
    {
      int num1 = depth ? 1 : 0;
      int num2 = stencil ? 1 : 0;
      // ISSUE: explicit constructor call
      base.\u002Ector();
      FxProcessor fxProcessor = this;
      this.priorities = new ObjectIntMap();
      this.effectsAll = new Seq();
      this.effectsEnabled = new Seq();
      this.bufferRenderer = new FxBufferRenderer();
      this.disabled = false;
      this.capturing = false;
      this.hasCaptured = false;
      this.applyingEffects = false;
      this.blendingEnabled = false;
      this.fboFormat = fboFormat;
      this.pingPongBuffer = new PingPongBuffer(fboFormat, bufferWidth, bufferHeight, num1 != 0, num2 != 0);
      this.width = bufferWidth;
      this.height = bufferHeight;
    }

    [LineNumberTable(new byte[] {123, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addEffect(FxFilter effect) => this.addEffect(effect, 0);

    [LineNumberTable(new byte[] {14, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void dispose() => this.pingPongBuffer.dispose();

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getWidth() => this.width;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getHeight() => this.height;

    [LineNumberTable(new byte[] {18, 114, 103, 135, 141, 127, 1, 104, 102, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void resize(int width, int height)
    {
      if (this.width == width && this.height == height)
        return;
      this.width = width;
      this.height = height;
      this.pingPongBuffer.resize(width, height);
      Iterator iterator = this.effectsAll.iterator();
      while (iterator.hasNext())
      {
        FxFilter fxFilter = (FxFilter) iterator.next();
        fxFilter.resize(width, height);
        fxFilter.rebind();
      }
    }

    [LineNumberTable(new byte[] {160, 116, 104, 176, 106, 138, 133, 103, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool begin()
    {
      if (this.applyingEffects)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalStateException("You cannot capture when you're applying the effects.");
      }
      if (this.disabled || this.capturing)
        return false;
      Draw.flush();
      this.capturing = true;
      this.pingPongBuffer.begin();
      return true;
    }

    [LineNumberTable(new byte[] {160, 135, 138, 133, 103, 103, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool end()
    {
      if (!this.capturing)
        return false;
      Draw.flush();
      this.hasCaptured = true;
      this.capturing = false;
      this.pingPongBuffer.end();
      return true;
    }

    [LineNumberTable(new byte[] {160, 149, 104, 176, 105, 137, 149, 156, 103, 103, 135, 104, 172, 170, 106, 170, 107, 107, 102, 109, 124, 102, 235, 60, 230, 71, 171, 138, 104, 170, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void applyEffects()
    {
      if (this.capturing)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalStateException("You should call VfxManager.endCapture() before applying the effects.");
      }
      if (this.disabled || !this.hasCaptured)
        return;
      this.effectsAll.each((Cons) new FxProcessor.__\u003C\u003EAnon3());
      Seq seq = this.effectsEnabled.selectFrom(this.effectsAll, (Boolf) new FxProcessor.__\u003C\u003EAnon4());
      this.applyingEffects = true;
      int size = seq.size;
      if (size > 0)
      {
        if (this.blendingEnabled)
          Gl.enable(3042);
        else
          Gl.disable(3042);
        Gl.disable(2884);
        Gl.disable(2929);
        this.pingPongBuffer.swap();
        this.pingPongBuffer.begin();
        for (int index = 0; index < size; ++index)
        {
          ((FxFilter) seq.get(index)).render(this.pingPongBuffer.getSrcBuffer(), this.pingPongBuffer.getDstBuffer());
          if (index < size - 1)
            this.pingPongBuffer.swap();
        }
        this.pingPongBuffer.end();
        Gl.activeTexture(33984);
        if (this.blendingEnabled)
          Gl.disable(3042);
      }
      this.applyingEffects = false;
    }

    [LineNumberTable(new byte[] {160, 197, 104, 144, 105, 169, 104, 140, 138, 118, 104, 138})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void render()
    {
      if (this.capturing)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalStateException("You should call VfxManager.endCapture() before rendering the result.");
      }
      if (this.disabled || !this.hasCaptured)
        return;
      if (this.blendingEnabled)
        Gl.enable(3042);
      else
        Gl.disable(3042);
      this.bufferRenderer.renderToScreen(this.pingPongBuffer.getDstBuffer());
      if (!this.blendingEnabled)
        return;
      Gl.disable(3042);
    }

    [LineNumberTable(new byte[] {2, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public FxProcessor(Pixmap.Format fboFormat, int bufferWidth, int bufferHeight)
      : this(fboFormat, bufferWidth, bufferHeight, false, false)
    {
    }

    [LineNumberTable(new byte[] {77, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setBufferTextureParams(
      Texture.TextureWrap u,
      Texture.TextureWrap v,
      Texture.TextureFilter min,
      Texture.TextureFilter mag)
    {
      this.pingPongBuffer.setTextureParams(u, v, min, mag);
    }

    [LineNumberTable(new byte[] {127, 108, 109, 120, 114, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addEffect(FxFilter effect, int priority)
    {
      this.effectsAll.add((object) effect);
      this.priorities.put((object) effect, priority);
      this.effectsAll.sort((Floatf) new FxProcessor.__\u003C\u003EAnon1(this, effect));
      effect.resize(this.width, this.height);
      effect.rebind();
    }

    [LineNumberTable(new byte[] {160, 103, 120, 152, 108, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void clear(Color color)
    {
      if (this.capturing)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalStateException("Cannot clean up buffers when capturing.");
      }
      if (this.applyingEffects)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalStateException("Cannot clean up buffers when applying effects.");
      }
      this.pingPongBuffer.clear(color);
      this.hasCaptured = false;
    }

    [Modifiers]
    [LineNumberTable(161)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024hasEnabledEffects\u00240([In] FxFilter obj0) => !obj0.isDisabled();

    [Modifiers]
    [LineNumberTable(179)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private float lambda\u0024addEffect\u00241([In] FxFilter obj0, [In] FxFilter obj1) => (float) this.priorities.get((object) obj0, 0);

    [Modifiers]
    [LineNumberTable(203)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private float lambda\u0024setEffectPriority\u00242([In] FxFilter obj0, [In] FxFilter obj1) => (float) this.priorities.get((object) obj0, 0);

    [Modifiers]
    [LineNumberTable(272)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024applyEffects\u00243([In] FxFilter obj0) => !obj0.isDisabled();

    [LineNumberTable(new byte[] {159, 186, 127, 0})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public FxProcessor()
      : this(Pixmap.Format.__\u003C\u003Ergba8888, Core.graphics.getBackBufferWidth(), Core.graphics.getBackBufferHeight())
    {
    }

    [LineNumberTable(new byte[] {159, 190, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public FxProcessor(int w, int h)
      : this(Pixmap.Format.__\u003C\u003Ergba8888, w, h)
    {
    }

    [LineNumberTable(new byte[] {32, 139, 127, 1, 102, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void rebind()
    {
      this.bufferRenderer.rebind();
      Iterator iterator = this.effectsAll.iterator();
      while (iterator.hasNext())
        ((FxFilter) iterator.next()).rebind();
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isDisabled() => this.disabled;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setDisabled(bool disabled) => this.disabled = disabled;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isBlendingEnabled() => this.blendingEnabled;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setBlendingEnabled(bool blendingEnabled) => this.blendingEnabled = blendingEnabled;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Pixmap.Format getFramebufferFormat() => this.fboFormat;

    [LineNumberTable(new byte[] {81, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setTextureFilter(Texture.TextureFilter filter) => this.setBufferTextureParams(Texture.TextureWrap.__\u003C\u003EclampToEdge, Texture.TextureWrap.__\u003C\u003EclampToEdge, filter, filter);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isCapturing() => this.capturing;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isApplyingEffects() => this.applyingEffects;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool hasResult() => this.hasCaptured;

    [LineNumberTable(150)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual FrameBuffer getResultBuffer() => this.pingPongBuffer.getDstBuffer();

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual PingPongBuffer getPingPongBuffer() => this.pingPongBuffer;

    [LineNumberTable(161)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool hasEnabledEffects() => this.effectsAll.contains((Boolf) new FxProcessor.__\u003C\u003EAnon0());

    [LineNumberTable(new byte[] {160, 74, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void removeEffect(FxFilter effect) => this.effectsAll.remove((object) effect);

    [LineNumberTable(new byte[] {160, 81, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void removeAllEffects() => this.effectsAll.clear();

    [LineNumberTable(new byte[] {160, 88, 109, 120})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setEffectPriority(FxFilter effect, int priority)
    {
      this.priorities.put((object) effect, priority);
      this.effectsAll.sort((Floatf) new FxProcessor.__\u003C\u003EAnon2(this, effect));
    }

    [LineNumberTable(new byte[] {160, 96, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void clear() => this.clear(Color.__\u003C\u003Eclear);

    [LineNumberTable(new byte[] {160, 216, 104, 144, 105, 169, 104, 138, 123, 104, 138})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void render(int x, int y, int width, int height)
    {
      if (this.capturing)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalStateException("You should call VfxManager.endCapture() before rendering the result.");
      }
      if (this.disabled || !this.hasCaptured)
        return;
      if (this.blendingEnabled)
        Gl.enable(3042);
      this.bufferRenderer.renderToScreen(this.pingPongBuffer.getDstBuffer(), x, y, width, height);
      if (!this.blendingEnabled)
        return;
      Gl.disable(3042);
    }

    [LineNumberTable(new byte[] {160, 233, 104, 144, 105, 169, 104, 138, 119, 104, 138})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void render(FrameBuffer output)
    {
      if (this.capturing)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalStateException("You should call VfxManager.endCapture() before rendering the result.");
      }
      if (this.disabled || !this.hasCaptured)
        return;
      if (this.blendingEnabled)
        Gl.enable(3042);
      this.bufferRenderer.renderToFbo(this.pingPongBuffer.getDstBuffer(), output);
      if (!this.blendingEnabled)
        return;
      Gl.disable(3042);
    }

    [HideFromJava]
    public virtual bool isDisposed() => Disposable.\u003Cdefault\u003EisDisposed((Disposable) this);

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Boolf
    {
      internal __\u003C\u003EAnon0()
      {
      }

      public bool get([In] object obj0) => (FxProcessor.lambda\u0024hasEnabledEffects\u00240((FxFilter) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Floatf
    {
      private readonly FxProcessor arg\u00241;
      private readonly FxFilter arg\u00242;

      internal __\u003C\u003EAnon1([In] FxProcessor obj0, [In] FxFilter obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public float get([In] object obj0) => this.arg\u00241.lambda\u0024addEffect\u00241(this.arg\u00242, (FxFilter) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon2 : Floatf
    {
      private readonly FxProcessor arg\u00241;
      private readonly FxFilter arg\u00242;

      internal __\u003C\u003EAnon2([In] FxProcessor obj0, [In] FxFilter obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public float get([In] object obj0) => this.arg\u00241.lambda\u0024setEffectPriority\u00242(this.arg\u00242, (FxFilter) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon3 : Cons
    {
      internal __\u003C\u003EAnon3()
      {
      }

      public void get([In] object obj0) => ((FxFilter) obj0).update();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon4 : Boolf
    {
      internal __\u003C\u003EAnon4()
      {
      }

      public bool get([In] object obj0) => (FxProcessor.lambda\u0024applyEffects\u00243((FxFilter) obj0) ? 1 : 0) != 0;
    }
  }
}
