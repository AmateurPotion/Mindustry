// Decompiled with JetBrains decompiler
// Type: arc.fx.filters.RadialBlurFilter
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.fx.filters
{
  public sealed class RadialBlurFilter : FxFilter
  {
    internal int __\u003C\u003Epasses;
    public float strength;
    public float originX;
    public float originY;
    public float zoom;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setOrigin(float originX, float originY)
    {
      this.originX = originX;
      this.originY = originY;
    }

    [LineNumberTable(new byte[] {159, 157, 107, 111, 31, 0, 236, 58, 107, 107, 107, 235, 71, 103, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public RadialBlurFilter(int passes)
      : base(FxFilter.compileShader(Core.files.classpath("shaders/radial-blur.vert"), Core.files.classpath("shaders/radial-blur.frag"), new StringBuilder().append("#define PASSES ").append(passes).toString()))
    {
      RadialBlurFilter radialBlurFilter = this;
      this.strength = 0.2f;
      this.originX = 0.5f;
      this.originY = 0.5f;
      this.zoom = 1f;
      this.__\u003C\u003Epasses = passes;
      this.rebind();
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getOriginX() => this.originX;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getOriginY() => this.originY;

    [LineNumberTable(new byte[] {159, 180, 101, 104, 102, 136, 134, 101, 104, 101, 136, 134, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setOrigin(int align) => this.setOrigin((align & 8) == 0 ? ((align & 16) == 0 ? 0.5f : 1f) : 0.0f, (align & 4) == 0 ? ((align & 2) == 0 ? 0.5f : 1f) : 0.0f);

    [LineNumberTable(new byte[] {17, 113, 127, 0, 118, 118, 118})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setParams()
    {
      this.__\u003C\u003Eshader.setUniformi("u_texture0", 0);
      this.__\u003C\u003Eshader.setUniformf("u_blurDiv", this.strength / (float) this.__\u003C\u003Epasses);
      this.__\u003C\u003Eshader.setUniformf("u_offsetX", this.originX);
      this.__\u003C\u003Eshader.setUniformf("u_offsetY", this.originY);
      this.__\u003C\u003Eshader.setUniformf("u_zoom", this.zoom);
    }

    [Modifiers]
    public int passes
    {
      [HideFromJava] get => this.__\u003C\u003Epasses;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Epasses = value;
    }
  }
}
