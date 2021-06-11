// Decompiled with JetBrains decompiler
// Type: arc.fx.filters.ChromaticAberrationFilter
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;

namespace arc.fx.filters
{
  public class ChromaticAberrationFilter : FxFilter
  {
    public float maxDistortion;

    [LineNumberTable(new byte[] {159, 152, 107, 111, 31, 0, 236, 61, 235, 71, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ChromaticAberrationFilter(int passes)
      : base(FxFilter.compileShader(Core.files.classpath("shaders/screenspace.vert"), Core.files.classpath("shaders/chromatic-aberration.frag"), new StringBuilder().append("#define PASSES ").append(passes).toString()))
    {
      ChromaticAberrationFilter aberrationFilter = this;
      this.maxDistortion = 1.2f;
      this.rebind();
    }

    [LineNumberTable(new byte[] {159, 161, 113, 118})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setParams()
    {
      this.__\u003C\u003Eshader.setUniformi("u_texture0", 0);
      this.__\u003C\u003Eshader.setUniformf("u_maxDistortion", this.maxDistortion);
    }
  }
}
