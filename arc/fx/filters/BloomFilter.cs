// Decompiled with JetBrains decompiler
// Type: arc.fx.filters.BloomFilter
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
  public class BloomFilter : FxFilter
  {
    internal PingPongBuffer __\u003C\u003Ebuffer;
    internal GaussianBlurFilter __\u003C\u003Eblur;
    internal ThresholdFilter __\u003C\u003Ethreshold;
    internal CombineFilter __\u003C\u003Ecombine;
    public Blending blending;
    public int scaling;

    [LineNumberTable(new byte[] {159, 162, 232, 61, 107, 167, 144, 107, 107, 139, 108, 112, 112, 112, 112, 112, 112, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public BloomFilter()
    {
      BloomFilter bloomFilter = this;
      this.blending = Blending.__\u003C\u003Enormal;
      this.scaling = 4;
      this.__\u003C\u003Ebuffer = new PingPongBuffer(Pixmap.Format.__\u003C\u003Ergba8888);
      this.__\u003C\u003Eblur = new GaussianBlurFilter();
      this.__\u003C\u003Ethreshold = new ThresholdFilter();
      this.__\u003C\u003Ecombine = new CombineFilter();
      this.__\u003C\u003Eblur.setPasses(2);
      this.__\u003C\u003Eblur.setAmount(10f);
      this.__\u003C\u003Ethreshold.gamma = 0.0f;
      this.__\u003C\u003Ecombine.src1int = 1f;
      this.__\u003C\u003Ecombine.src1sat = 1f;
      this.__\u003C\u003Ecombine.src2int = 2f;
      this.__\u003C\u003Ecombine.src2sat = 2f;
      this.rebind();
    }

    [LineNumberTable(new byte[] {159, 181, 107, 107, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void rebind()
    {
      this.__\u003C\u003Ethreshold.rebind();
      this.__\u003C\u003Ecombine.rebind();
      this.__\u003C\u003Ebuffer.rebind();
    }

    [LineNumberTable(new byte[] {159, 188, 114, 146, 109, 109, 109, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void resize(int width, int height)
    {
      int num1 = width;
      int scaling1 = this.scaling;
      width = scaling1 != -1 ? num1 / scaling1 : -num1;
      int num2 = height;
      int scaling2 = this.scaling;
      height = scaling2 != -1 ? num2 / scaling2 : -num2;
      this.__\u003C\u003Ebuffer.resize(width, height);
      this.__\u003C\u003Eblur.resize(width, height);
      this.__\u003C\u003Ethreshold.resize(width, height);
      this.__\u003C\u003Ecombine.resize(width, height);
    }

    [LineNumberTable(new byte[] {7, 107, 107, 107, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void dispose()
    {
      this.__\u003C\u003Ecombine.dispose();
      this.__\u003C\u003Ethreshold.dispose();
      this.__\u003C\u003Eblur.dispose();
      this.__\u003C\u003Ebuffer.dispose();
    }

    [LineNumberTable(new byte[] {15, 140, 138, 203, 127, 2, 171, 145, 139, 114, 106, 219, 120, 101, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void render(FrameBuffer src, FrameBuffer dst)
    {
      Texture texture = (Texture) src.getTexture();
      Gl.disable(3042);
      this.__\u003C\u003Ebuffer.begin();
      this.__\u003C\u003Ethreshold.setInput(texture).setOutput(this.__\u003C\u003Ebuffer.getDstBuffer()).render();
      this.__\u003C\u003Ebuffer.swap();
      this.__\u003C\u003Eblur.render(this.__\u003C\u003Ebuffer);
      this.__\u003C\u003Ebuffer.end();
      if (!object.ReferenceEquals((object) this.blending, (object) Blending.__\u003C\u003Edisabled))
      {
        Gl.enable(3042);
        Gl.blendFunc(this.blending.__\u003C\u003Esrc, this.blending.__\u003C\u003Edst);
      }
      this.__\u003C\u003Ecombine.setInput(texture, this.__\u003C\u003Ebuffer.getDstTexture()).setOutput(dst).render();
    }

    [Modifiers]
    public PingPongBuffer buffer
    {
      [HideFromJava] get => this.__\u003C\u003Ebuffer;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Ebuffer = value;
    }

    [Modifiers]
    public GaussianBlurFilter blur
    {
      [HideFromJava] get => this.__\u003C\u003Eblur;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Eblur = value;
    }

    [Modifiers]
    public ThresholdFilter threshold
    {
      [HideFromJava] get => this.__\u003C\u003Ethreshold;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Ethreshold = value;
    }

    [Modifiers]
    public CombineFilter combine
    {
      [HideFromJava] get => this.__\u003C\u003Ecombine;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Ecombine = value;
    }
  }
}
