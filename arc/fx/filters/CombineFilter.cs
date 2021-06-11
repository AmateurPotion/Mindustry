// Decompiled with JetBrains decompiler
// Type: arc.fx.filters.CombineFilter
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.graphics;
using arc.graphics.gl;
using IKVM.Attributes;
using System.Runtime.CompilerServices;

namespace arc.fx.filters
{
  public sealed class CombineFilter : FxFilter
  {
    public float src1int;
    public float src1sat;
    public float src2int;
    public float src2sat;
    public Texture inputTexture2;

    [LineNumberTable(new byte[] {159, 154, 242, 60, 127, 13, 199, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public CombineFilter()
      : base("screenspace", "combine")
    {
      CombineFilter combineFilter = this;
      this.src1int = 1f;
      this.src1sat = 1f;
      this.src2int = 1f;
      this.src2sat = 1f;
      this.inputTexture2 = (Texture) null;
      this.rebind();
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual CombineFilter setInput(Texture texture1, Texture texture2)
    {
      this.inputTexture = texture1;
      this.inputTexture2 = texture2;
      return this;
    }

    [LineNumberTable(new byte[] {159, 159, 113, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual CombineFilter setInput(FrameBuffer buffer1, FrameBuffer buffer2)
    {
      this.inputTexture = (Texture) buffer1.getTexture();
      this.inputTexture2 = (Texture) buffer2.getTexture();
      return this;
    }

    [LineNumberTable(new byte[] {159, 172, 113, 113, 118, 118, 118, 118})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setParams()
    {
      this.__\u003C\u003Eshader.setUniformi("u_texture0", 0);
      this.__\u003C\u003Eshader.setUniformi("u_texture1", 1);
      this.__\u003C\u003Eshader.setUniformf("u_src1Intensity", this.src1int);
      this.__\u003C\u003Eshader.setUniformf("u_src2Intensity", this.src2int);
      this.__\u003C\u003Eshader.setUniformf("u_src1Saturation", this.src1sat);
      this.__\u003C\u003Eshader.setUniformf("u_src2Saturation", this.src2sat);
    }

    [LineNumberTable(new byte[] {159, 182, 108, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void onBeforeRender()
    {
      this.inputTexture.bind(0);
      this.inputTexture2.bind(1);
    }
  }
}
