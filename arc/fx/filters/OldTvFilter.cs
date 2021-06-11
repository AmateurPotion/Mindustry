// Decompiled with JetBrains decompiler
// Type: arc.fx.filters.OldTvFilter
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.math.geom;
using IKVM.Attributes;
using System.Runtime.CompilerServices;

namespace arc.fx.filters
{
  public class OldTvFilter : FxFilter
  {
    [Modifiers]
    private Vec2 resolution;

    [LineNumberTable(new byte[] {159, 153, 107, 111, 5, 236, 61, 235, 70, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public OldTvFilter()
      : base(FxFilter.compileShader(Core.files.classpath("shaders/screenspace.vert"), Core.files.classpath("shaders/old-tv.frag")))
    {
      OldTvFilter oldTvFilter = this;
      this.resolution = new Vec2();
      this.rebind();
    }

    [LineNumberTable(new byte[] {159, 161, 112, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void resize(int width, int height)
    {
      this.resolution.set((float) width, (float) height);
      this.rebind();
    }

    [LineNumberTable(new byte[] {159, 167, 113, 118, 118})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setParams()
    {
      this.__\u003C\u003Eshader.setUniformi("u_texture0", 0);
      this.__\u003C\u003Eshader.setUniformf("u_resolution", this.resolution);
      this.__\u003C\u003Eshader.setUniformf("u_time", this.time);
    }
  }
}
