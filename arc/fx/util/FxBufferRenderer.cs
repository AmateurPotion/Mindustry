// Decompiled with JetBrains decompiler
// Type: arc.fx.util.FxBufferRenderer
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.graphics;
using arc.graphics.gl;
using arc.util;
using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;

namespace arc.fx.util
{
  public class FxBufferRenderer : Object, Disposable
  {
    [Modifiers]
    private Shader shader;

    [LineNumberTable(new byte[] {159, 157, 136, 245, 80, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public FxBufferRenderer()
    {
      FxBufferRenderer fxBufferRenderer = this;
      this.shader = new Shader("attribute vec4 a_position;\nattribute vec2 a_texCoord0;\nvarying vec2 v_texCoords;\nvoid main(){\n    v_texCoords = a_texCoord0;\n    gl_Position = a_position;\n}", "varying vec2 v_texCoords;\nuniform sampler2D u_texture0;\nvoid main(){\n    gl_FragColor = texture2D(u_texture0, v_texCoords);\n}");
      this.rebind();
    }

    [LineNumberTable(new byte[] {159, 184, 107, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void rebind()
    {
      this.shader.bind();
      this.shader.setUniformi("u_texture0", 0);
    }

    [LineNumberTable(new byte[] {159, 189, 125})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void renderToScreen(FrameBuffer input) => this.renderToScreen(input, 0, 0, Core.graphics.getBackBufferWidth(), Core.graphics.getBackBufferHeight());

    [LineNumberTable(new byte[] {1, 139, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void renderToScreen(FrameBuffer input, int x, int y, int width, int height)
    {
      Gl.viewport(x, y, width, height);
      input.blit(this.shader);
    }

    [LineNumberTable(new byte[] {7, 102, 108, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void renderToFbo(FrameBuffer input, FrameBuffer output)
    {
      output.begin();
      input.blit(this.shader);
      output.end();
    }

    [LineNumberTable(new byte[] {159, 180, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void dispose() => this.shader.dispose();

    [HideFromJava]
    public virtual bool isDisposed() => Disposable.\u003Cdefault\u003EisDisposed((Disposable) this);
  }
}
