// Decompiled with JetBrains decompiler
// Type: arc.fx.filters.BiasFilter
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using System.Runtime.CompilerServices;

namespace arc.fx.filters
{
  public sealed class BiasFilter : FxFilter
  {
    public float bias;

    [LineNumberTable(new byte[] {159, 156, 107, 111, 5, 172, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public BiasFilter()
      : base(FxFilter.compileShader(Core.files.classpath("shaders/screenspace.vert"), Core.files.classpath(nameof (bias))))
    {
      BiasFilter biasFilter = this;
      this.rebind();
    }

    [LineNumberTable(new byte[] {159, 164, 113, 118})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setParams()
    {
      this.__\u003C\u003Eshader.setUniformi("u_texture0", 0);
      this.__\u003C\u003Eshader.setUniformf("u_bias", this.bias);
    }
  }
}
