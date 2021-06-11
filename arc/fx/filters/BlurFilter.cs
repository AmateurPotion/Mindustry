// Decompiled with JetBrains decompiler
// Type: arc.fx.filters.BlurFilter
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.fx.util;
using arc.graphics;
using arc.graphics.gl;
using IKVM.Attributes;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.fx.filters
{
  public class BlurFilter : FxFilter
  {
    internal GaussianBlurFilter __\u003C\u003Eblur;
    [Modifiers]
    private PingPongBuffer pingPongBuffer;
    [Modifiers]
    private CopyFilter copy;
    public Blending blending;
    private bool firstRender;

    [LineNumberTable(new byte[] {159, 164, 232, 55, 171, 231, 71, 144, 139, 107, 108, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public BlurFilter(int blurPasses, GaussianBlurFilter.BlurType blurType)
    {
      BlurFilter blurFilter = this;
      this.blending = Blending.__\u003C\u003Edisabled;
      this.firstRender = true;
      this.pingPongBuffer = new PingPongBuffer(Pixmap.Format.__\u003C\u003Ergba8888);
      this.copy = new CopyFilter();
      this.__\u003C\u003Eblur = new GaussianBlurFilter();
      this.__\u003C\u003Eblur.setPasses(blurPasses);
      this.__\u003C\u003Eblur.setType(blurType);
    }

    [LineNumberTable(new byte[] {159, 161, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public BlurFilter()
      : this(8, GaussianBlurFilter.BlurType.__\u003C\u003Egaussian5x5)
    {
    }

    [LineNumberTable(new byte[] {159, 176, 107, 107, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void dispose()
    {
      this.pingPongBuffer.dispose();
      this.__\u003C\u003Eblur.dispose();
      this.copy.dispose();
    }

    [LineNumberTable(new byte[] {159, 183, 109, 109, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void resize(int width, int height)
    {
      this.pingPongBuffer.resize(width, height);
      this.__\u003C\u003Eblur.resize(width, height);
      this.copy.resize(width, height);
    }

    [LineNumberTable(new byte[] {159, 190, 107, 107, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void rebind()
    {
      this.pingPongBuffer.rebind();
      this.__\u003C\u003Eblur.setParams();
      this.copy.rebind();
    }

    [LineNumberTable(new byte[] {5, 142, 119, 161, 138, 107, 127, 2, 171, 104, 103, 127, 2, 139, 113, 139, 114, 106, 187, 119, 101, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void render(FrameBuffer src, FrameBuffer dst)
    {
      if (this.__\u003C\u003Eblur.getPasses() < 1)
      {
        this.copy.setInput(src).setOutput(dst).render();
      }
      else
      {
        Gl.disable(3042);
        this.pingPongBuffer.begin();
        this.copy.setInput(src).setOutput(this.pingPongBuffer.getDstBuffer()).render();
        this.pingPongBuffer.swap();
        if (this.firstRender)
        {
          this.firstRender = false;
          this.copy.setInput(src).setOutput(this.pingPongBuffer.getDstBuffer()).render();
          this.pingPongBuffer.swap();
        }
        this.__\u003C\u003Eblur.render(this.pingPongBuffer);
        this.pingPongBuffer.end();
        if (!object.ReferenceEquals((object) this.blending, (object) Blending.__\u003C\u003Edisabled))
        {
          Gl.enable(3042);
          Gl.blendFunc(this.blending.__\u003C\u003Esrc, this.blending.__\u003C\u003Edst);
        }
        this.copy.setInput(this.pingPongBuffer.getDstTexture()).setOutput(dst).render();
      }
    }

    [Modifiers]
    public GaussianBlurFilter blur
    {
      [HideFromJava] get => this.__\u003C\u003Eblur;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Eblur = value;
    }
  }
}
