// Decompiled with JetBrains decompiler
// Type: arc.fx.filters.NfaaFilter
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.math.geom;
using IKVM.Attributes;
using System.Runtime.CompilerServices;

namespace arc.fx.filters
{
  public sealed class NfaaFilter : FxFilter
  {
    [Modifiers]
    private Vec2 viewportInverse;

    [LineNumberTable(new byte[] {159, 138, 162, 107, 111, 20, 236, 57, 235, 74})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public NfaaFilter(bool supportAlpha)
    {
      int num = supportAlpha ? 1 : 0;
      // ISSUE: explicit constructor call
      base.\u002Ector(FxFilter.compileShader(Core.files.classpath("shaders/screenspace.vert"), Core.files.classpath("shaders/nfaa.frag"), num == 0 ? "" : "#define SUPPORT_ALPHA"));
      NfaaFilter nfaaFilter = this;
      this.viewportInverse = new Vec2();
    }

    [LineNumberTable(new byte[] {159, 157, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public NfaaFilter()
      : this(false)
    {
    }

    [LineNumberTable(new byte[] {159, 168, 126, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void resize(int width, int height)
    {
      this.viewportInverse.set(1f / (float) width, 1f / (float) height);
      this.rebind();
    }

    [LineNumberTable(new byte[] {159, 174, 113, 118})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setParams()
    {
      this.__\u003C\u003Eshader.setUniformi("u_texture0", 0);
      this.__\u003C\u003Eshader.setUniformf("u_viewportInverse", this.viewportInverse);
    }
  }
}
