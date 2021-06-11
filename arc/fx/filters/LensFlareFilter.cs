// Decompiled with JetBrains decompiler
// Type: arc.fx.filters.LensFlareFilter
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.graphics;
using arc.math.geom;
using IKVM.Attributes;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.fx.filters
{
  public sealed class LensFlareFilter : FxFilter
  {
    [Modifiers]
    private Vec2 viewport;
    internal Vec2 __\u003C\u003ElightPosition;
    internal Color __\u003C\u003Ecolor;
    public float intensity;

    [LineNumberTable(new byte[] {159, 162, 107, 111, 5, 236, 57, 139, 117, 127, 0, 235, 70, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public LensFlareFilter()
      : base(FxFilter.compileShader(Core.files.classpath("shaders/screenspace.vert"), Core.files.classpath("shaders/lensflare.frag")))
    {
      LensFlareFilter lensFlareFilter = this;
      this.viewport = new Vec2();
      this.__\u003C\u003ElightPosition = new Vec2(0.5f, 0.5f);
      this.__\u003C\u003Ecolor = new Color(1f, 0.8f, 0.2f, 1f);
      this.intensity = 5f;
      this.rebind();
    }

    [LineNumberTable(new byte[] {159, 170, 112, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void resize(int width, int height)
    {
      this.viewport.set((float) width, (float) height);
      this.rebind();
    }

    [LineNumberTable(new byte[] {159, 176, 113, 118, 118, 127, 18, 118})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setParams()
    {
      this.__\u003C\u003Eshader.setUniformi("u_texture0", 0);
      this.__\u003C\u003Eshader.setUniformf("u_lightPosition", this.__\u003C\u003ElightPosition);
      this.__\u003C\u003Eshader.setUniformf("u_intensity", this.intensity);
      this.__\u003C\u003Eshader.setUniformf("u_color", this.__\u003C\u003Ecolor.r, this.__\u003C\u003Ecolor.g, this.__\u003C\u003Ecolor.b);
      this.__\u003C\u003Eshader.setUniformf("u_viewport", this.viewport);
    }

    [Modifiers]
    public Vec2 lightPosition
    {
      [HideFromJava] get => this.__\u003C\u003ElightPosition;
      [HideFromJava] [param: In] private set => this.__\u003C\u003ElightPosition = value;
    }

    [Modifiers]
    public Color color
    {
      [HideFromJava] get => this.__\u003C\u003Ecolor;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Ecolor = value;
    }
  }
}
