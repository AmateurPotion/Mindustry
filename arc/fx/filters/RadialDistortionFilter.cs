// Decompiled with JetBrains decompiler
// Type: arc.fx.filters.RadialDistortionFilter
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using System.Runtime.CompilerServices;

namespace arc.fx.filters
{
  public sealed class RadialDistortionFilter : FxFilter
  {
    public float zoom;
    public float distortion;

    [LineNumberTable(new byte[] {159, 153, 107, 111, 5, 236, 60, 107, 235, 70, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public RadialDistortionFilter()
      : base(FxFilter.compileShader(Core.files.classpath("shaders/screenspace.vert"), Core.files.classpath("shaders/radial-distortion.frag")))
    {
      RadialDistortionFilter distortionFilter = this;
      this.zoom = 1f;
      this.distortion = 0.3f;
      this.rebind();
    }

    [LineNumberTable(new byte[] {159, 161, 113, 118, 118})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setParams()
    {
      this.__\u003C\u003Eshader.setUniformi("u_texture0", 0);
      this.__\u003C\u003Eshader.setUniformf("distortion", this.distortion);
      this.__\u003C\u003Eshader.setUniformf("zoom", this.zoom);
    }
  }
}
