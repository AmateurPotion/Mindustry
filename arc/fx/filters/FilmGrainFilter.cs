// Decompiled with JetBrains decompiler
// Type: arc.fx.filters.FilmGrainFilter
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.util;
using IKVM.Attributes;
using System.Runtime.CompilerServices;

namespace arc.fx.filters
{
  public class FilmGrainFilter : FxFilter
  {
    public float seed;

    [LineNumberTable(new byte[] {159, 153, 107, 111, 5, 236, 61, 235, 70, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public FilmGrainFilter()
      : base(FxFilter.compileShader(Core.files.classpath("shaders/screenspace.vert"), Core.files.classpath("shaders/film-grain.frag")))
    {
      FilmGrainFilter filmGrainFilter = this;
      this.seed = 0.0f;
      this.rebind();
    }

    [LineNumberTable(new byte[] {159, 160, 104, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setSeed(float seed)
    {
      this.seed = seed;
      this.rebind();
    }

    [LineNumberTable(new byte[] {159, 166, 113, 118})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setParams()
    {
      this.__\u003C\u003Eshader.setUniformi("u_texture0", 0);
      this.__\u003C\u003Eshader.setUniformf("u_seed", this.seed);
    }

    [LineNumberTable(new byte[] {159, 172, 127, 2, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void update()
    {
      this.time = (this.time + Time.delta / 60f) % 1f;
      this.seed = this.time;
    }
  }
}
