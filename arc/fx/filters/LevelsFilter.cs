// Decompiled with JetBrains decompiler
// Type: arc.fx.filters.LevelsFilter
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using System.Runtime.CompilerServices;

namespace arc.fx.filters
{
  public class LevelsFilter : FxFilter
  {
    public float brightness;
    public float contrast;
    public float saturation;
    public float hue;
    public float gamma;

    [LineNumberTable(new byte[] {159, 160, 255, 12, 57, 107, 107, 107, 107, 203, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public LevelsFilter()
      : base(FxFilter.compileShader(Core.files.classpath("shaders/screenspace.vert"), Core.files.classpath("shaders/levels.frag")))
    {
      LevelsFilter levelsFilter = this;
      this.brightness = 0.0f;
      this.contrast = 1f;
      this.saturation = 1f;
      this.hue = 1f;
      this.gamma = 1f;
      this.rebind();
    }

    [LineNumberTable(new byte[] {159, 166, 113, 118, 118, 118, 118, 118})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setParams()
    {
      this.__\u003C\u003Eshader.setUniformi("u_texture0", 0);
      this.__\u003C\u003Eshader.setUniformf("u_brightness", this.brightness);
      this.__\u003C\u003Eshader.setUniformf("u_contrast", this.contrast);
      this.__\u003C\u003Eshader.setUniformf("u_saturation", this.saturation);
      this.__\u003C\u003Eshader.setUniformf("u_hue", this.hue);
      this.__\u003C\u003Eshader.setUniformf("u_gamma", this.gamma);
    }
  }
}
