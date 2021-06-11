// Decompiled with JetBrains decompiler
// Type: arc.fx.filters.VignettingFilter
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.graphics;
using IKVM.Attributes;
using System.Runtime.CompilerServices;

namespace arc.fx.filters
{
  public sealed class VignettingFilter : FxFilter
  {
    private Texture lutTexture;
    public float vignetteX;
    public float vignetteY;
    public float centerX;
    public float centerY;
    public float intensity;
    public float saturation;
    public float saturationMul;
    public bool saturationEnabled;
    public bool lutEnabled;
    public float lutIntensity;
    public int lutIndex1;
    public int lutIndex2;
    public float lutStep;
    public float lutStepOffset;
    public float lutIndexOffset;

    [LineNumberTable(new byte[] {159, 135, 98, 107, 111, 101, 99, 103, 229, 59, 236, 43, 135, 107, 107, 107, 107, 107, 107, 203, 103, 107, 103, 167, 235, 73, 103, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public VignettingFilter(bool controlSaturation)
    {
      int num = controlSaturation ? 1 : 0;
      // ISSUE: explicit constructor call
      base.\u002Ector(FxFilter.compileShader(Core.files.classpath("shaders/screenspace.vert"), Core.files.classpath("shaders/vignetting.frag"), num == 0 ? "#define ENABLE_GRADIENT_MAPPING" : "#define CONTROL_SATURATION\n#define ENABLE_GRADIENT_MAPPING"));
      VignettingFilter vignettingFilter = this;
      this.lutTexture = (Texture) null;
      this.vignetteX = 0.8f;
      this.vignetteY = 0.25f;
      this.centerX = 0.5f;
      this.centerY = 0.5f;
      this.intensity = 1f;
      this.saturation = 0.0f;
      this.saturationMul = 0.0f;
      this.lutEnabled = false;
      this.lutIntensity = 1f;
      this.lutIndex1 = -1;
      this.lutIndex2 = -1;
      this.lutIndexOffset = 0.0f;
      this.saturationEnabled = num != 0;
      this.rebind();
    }

    [LineNumberTable(new byte[] {159, 185, 103, 146, 104, 116, 147})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setLut(Texture texture)
    {
      this.lutTexture = texture;
      this.lutEnabled = this.lutTexture != null;
      if (!this.lutEnabled)
        return;
      this.lutStep = 1f / (float) texture.height;
      this.lutStepOffset = this.lutStep / 2f;
    }

    [LineNumberTable(new byte[] {4, 145, 118, 118, 150, 113, 118, 118, 150, 104, 118, 182, 118, 118, 118, 118, 118})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setParams()
    {
      this.__\u003C\u003Eshader.setUniformi("u_texture0", 0);
      this.__\u003C\u003Eshader.setUniformi("u_lutIndex1", this.lutIndex1);
      this.__\u003C\u003Eshader.setUniformi("u_lutIndex2", this.lutIndex2);
      this.__\u003C\u003Eshader.setUniformf("u_lutIndexOffset", this.lutIndexOffset);
      this.__\u003C\u003Eshader.setUniformi("u_texture1", 1);
      this.__\u003C\u003Eshader.setUniformf("u_lutIntensity", this.lutIntensity);
      this.__\u003C\u003Eshader.setUniformf("u_lutStep", this.lutStep);
      this.__\u003C\u003Eshader.setUniformf("u_lutStepOffset", this.lutStepOffset);
      if (this.saturationEnabled)
      {
        this.__\u003C\u003Eshader.setUniformf("u_saturation", this.saturation);
        this.__\u003C\u003Eshader.setUniformf("u_saturationMul", this.saturationMul);
      }
      this.__\u003C\u003Eshader.setUniformf("u_vignetteIntensity", this.intensity);
      this.__\u003C\u003Eshader.setUniformf("u_vignetteX", this.vignetteX);
      this.__\u003C\u003Eshader.setUniformf("u_vignetteY", this.vignetteY);
      this.__\u003C\u003Eshader.setUniformf("u_centerX", this.centerX);
      this.__\u003C\u003Eshader.setUniformf("u_centerY", this.centerY);
    }

    [LineNumberTable(new byte[] {29, 108, 104, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void onBeforeRender()
    {
      this.inputTexture.bind(0);
      if (!this.lutEnabled)
        return;
      this.lutTexture.bind(1);
    }
  }
}
