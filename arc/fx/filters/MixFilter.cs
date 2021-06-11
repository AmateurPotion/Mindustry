// Decompiled with JetBrains decompiler
// Type: arc.fx.filters.MixFilter
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.graphics;
using arc.graphics.gl;
using IKVM.Attributes;
using java.lang;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace arc.fx.filters
{
  public sealed class MixFilter : FxFilter
  {
    private Texture inputTexture2;
    public float mix;

    [LineNumberTable(34)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual MixFilter setInput(FrameBuffer input)
    {
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new UnsupportedOperationException("Use #setInput(FboWrapper, FboWrapper)} instead.");
    }

    [LineNumberTable(39)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual MixFilter setInput(Texture input)
    {
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new UnsupportedOperationException("Use #setInput(Texture, Texture)} instead.");
    }

    [LineNumberTable(new byte[] {159, 155, 107, 111, 5, 236, 60, 103, 235, 71, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public MixFilter()
      : base(FxFilter.compileShader(Core.files.classpath("shaders/screenspace.vert"), Core.files.classpath("shaders/mix.frag")))
    {
      MixFilter mixFilter = this;
      this.inputTexture2 = (Texture) null;
      this.mix = 0.5f;
      this.rebind();
    }

    [LineNumberTable(new byte[] {159, 163, 113, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual MixFilter setInput(FrameBuffer buffer1, FrameBuffer buffer2)
    {
      this.inputTexture = (Texture) buffer1.getTexture();
      this.inputTexture2 = (Texture) buffer2.getTexture();
      return this;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual MixFilter setInput(Texture texture1, Texture texture2)
    {
      this.inputTexture = texture1;
      this.inputTexture2 = texture2;
      return this;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void resize(int width, int height)
    {
    }

    [LineNumberTable(new byte[] {159, 191, 113, 113, 118})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setParams()
    {
      this.__\u003C\u003Eshader.setUniformi("u_texture0", 0);
      this.__\u003C\u003Eshader.setUniformi("u_texture1", 1);
      this.__\u003C\u003Eshader.setUniformf("u_mix", this.mix);
    }

    [LineNumberTable(new byte[] {6, 108, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void onBeforeRender()
    {
      this.inputTexture.bind(0);
      this.inputTexture2.bind(1);
    }

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(8)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual FxFilter \u003Cbridge\u003EsetInput(FrameBuffer fb) => (FxFilter) this.setInput(fb);

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(8)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual FxFilter \u003Cbridge\u003EsetInput(Texture t) => (FxFilter) this.setInput(t);
  }
}
