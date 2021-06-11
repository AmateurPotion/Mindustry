// Decompiled with JetBrains decompiler
// Type: arc.fx.filters.FxaaFilter
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.math.geom;
using IKVM.Attributes;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.fx.filters
{
  public sealed class FxaaFilter : FxFilter
  {
    internal Vec2 __\u003C\u003EviewportInverse;
    public float fxaaReduceMin;
    public float fxaaReduceMul;
    public float fxaaSpanMax;

    [LineNumberTable(new byte[] {159, 137, 131, 107, 111, 101, 239, 61, 236, 54, 235, 78, 104, 104, 104, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public FxaaFilter(
      float fxaaReduceMin,
      float fxaaReduceMul,
      float fxaaSpanMax,
      bool supportAlpha)
    {
      int num = supportAlpha ? 1 : 0;
      // ISSUE: explicit constructor call
      base.\u002Ector(FxFilter.compileShader(Core.files.classpath("shaders/screenspace.vert"), Core.files.classpath("shaders/fxaa.frag"), num == 0 ? "" : "#define SUPPORT_ALPHA"));
      FxaaFilter fxaaFilter = this;
      this.__\u003C\u003EviewportInverse = new Vec2();
      this.fxaaReduceMin = fxaaReduceMin;
      this.fxaaReduceMul = fxaaReduceMul;
      this.fxaaSpanMax = fxaaSpanMax;
      this.rebind();
    }

    [LineNumberTable(new byte[] {159, 160, 118})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public FxaaFilter()
      : this(1f / 128f, 0.125f, 8f, true)
    {
    }

    [LineNumberTable(new byte[] {159, 176, 126, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void resize(int width, int height)
    {
      this.__\u003C\u003EviewportInverse.set(1f / (float) width, 1f / (float) height);
      this.rebind();
    }

    [LineNumberTable(new byte[] {159, 182, 113, 118, 118, 118, 118})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setParams()
    {
      this.__\u003C\u003Eshader.setUniformi("u_texture0", 0);
      this.__\u003C\u003Eshader.setUniformf("u_viewportInverse", this.__\u003C\u003EviewportInverse);
      this.__\u003C\u003Eshader.setUniformf("u_fxaaReduceMin", this.fxaaReduceMin);
      this.__\u003C\u003Eshader.setUniformf("u_fxaaReduceMul", this.fxaaReduceMul);
      this.__\u003C\u003Eshader.setUniformf("u_fxaaSpanMax", this.fxaaSpanMax);
    }

    [Modifiers]
    public Vec2 viewportInverse
    {
      [HideFromJava] get => this.__\u003C\u003EviewportInverse;
      [HideFromJava] [param: In] private set => this.__\u003C\u003EviewportInverse = value;
    }
  }
}
