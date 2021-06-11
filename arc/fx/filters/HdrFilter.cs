// Decompiled with JetBrains decompiler
// Type: arc.fx.filters.HdrFilter
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using System.Runtime.CompilerServices;

namespace arc.fx.filters
{
  public sealed class HdrFilter : FxFilter
  {
    public float exposure;
    public float gamma;

    [LineNumberTable(new byte[] {159, 161, 107, 111, 5, 172, 104, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public HdrFilter(float exposure, float gamma)
      : base(FxFilter.compileShader(Core.files.classpath("shaders/screenspace.vert"), Core.files.classpath("shaders/hdr.frag")))
    {
      HdrFilter hdrFilter = this;
      this.exposure = exposure;
      this.gamma = gamma;
    }

    [LineNumberTable(new byte[] {159, 157, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public HdrFilter()
      : this(3f, 2.2f)
    {
    }

    [LineNumberTable(new byte[] {159, 171, 113, 118, 118})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setParams()
    {
      this.__\u003C\u003Eshader.setUniformi("u_texture0", 0);
      this.__\u003C\u003Eshader.setUniformf("u_exposure", this.exposure);
      this.__\u003C\u003Eshader.setUniformf("u_gamma", this.gamma);
    }
  }
}
