// Decompiled with JetBrains decompiler
// Type: arc.fx.filters.RippleFilter
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using System.Runtime.CompilerServices;

namespace arc.fx.filters
{
  public class RippleFilter : FxFilter
  {
    public float amount;
    public float speed;

    [LineNumberTable(new byte[] {159, 152, 107, 111, 5, 172, 104, 104, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public RippleFilter(float amount, float speed)
      : base(FxFilter.compileShader(Core.files.classpath("shaders/screenspace.vert"), Core.files.classpath("shaders/ripple.frag")))
    {
      RippleFilter rippleFilter = this;
      this.amount = amount;
      this.speed = speed;
      this.rebind();
    }

    [LineNumberTable(new byte[] {159, 162, 113, 118, 118, 118})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setParams()
    {
      this.__\u003C\u003Eshader.setUniformi("u_texture0", 0);
      this.__\u003C\u003Eshader.setUniformf("u_amount", this.amount);
      this.__\u003C\u003Eshader.setUniformf("u_speed", this.speed);
      this.__\u003C\u003Eshader.setUniformf("u_time", this.time);
    }
  }
}
