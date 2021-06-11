// Decompiled with JetBrains decompiler
// Type: arc.fx.filters.ThresholdFilter
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using System.Runtime.CompilerServices;

namespace arc.fx.filters
{
  public class ThresholdFilter : FxFilter
  {
    public float gamma;

    [LineNumberTable(new byte[] {159, 151, 242, 61, 203, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ThresholdFilter()
      : base("screenspace", "threshold")
    {
      ThresholdFilter thresholdFilter = this;
      this.gamma = 0.0f;
      this.rebind();
    }

    [LineNumberTable(new byte[] {159, 157, 145, 118, 127, 5})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setParams()
    {
      this.__\u003C\u003Eshader.setUniformi("u_texture0", 0);
      this.__\u003C\u003Eshader.setUniformf("treshold", this.gamma);
      this.__\u003C\u003Eshader.setUniformf("tresholdInvTx", 1f / (1f - this.gamma));
    }
  }
}
