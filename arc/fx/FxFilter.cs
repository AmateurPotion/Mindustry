// Decompiled with JetBrains decompiler
// Type: arc.fx.FxFilter
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.files;
using arc.graphics;
using arc.graphics.g2d;
using arc.graphics.gl;
using arc.util;
using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.fx
{
  public abstract class FxFilter : Object, Disposable
  {
    protected internal const int u_texture0 = 0;
    protected internal const int u_texture1 = 1;
    protected internal const int u_texture2 = 2;
    protected internal const int u_texture3 = 3;
    internal Shader __\u003C\u003Eshader;
    protected internal Texture inputTexture;
    protected internal FrameBuffer outputBuffer;
    protected internal bool disabled;
    protected internal bool autobind;
    public float time;

    [LineNumberTable(new byte[] {159, 177, 232, 50, 103, 103, 142, 235, 75, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public FxFilter(Shader shader)
    {
      FxFilter fxFilter = this;
      this.inputTexture = (Texture) null;
      this.outputBuffer = (FrameBuffer) null;
      this.disabled = false;
      this.autobind = false;
      this.time = 0.0f;
      this.__\u003C\u003Eshader = shader;
    }

    [LineNumberTable(40)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Shader compileShader(Fi vertexFile, Fi fragmentFile) => FxFilter.compileShader(vertexFile, fragmentFile, "");

    [LineNumberTable(44)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Shader compileShader(Fi vertexFile, Fi fragmentFile, string defines)
    {
      Shader.__\u003Cclinit\u003E();
      return new Shader(new StringBuilder().append(defines).append("\n").append(vertexFile.readString()).toString(), new StringBuilder().append(defines).append("\n").append(fragmentFile.readString()).toString());
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual FxFilter setInput(Texture input)
    {
      this.inputTexture = input;
      return this;
    }

    [LineNumberTable(new byte[] {36, 104, 145})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void setParams()
    {
      if (this.__\u003C\u003Eshader == null)
        return;
      this.__\u003C\u003Eshader.setUniformi("u_texture0", 0);
    }

    [LineNumberTable(new byte[] {67, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void onBeforeRender() => this.inputTexture.bind(0);

    [LineNumberTable(53)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual FxFilter setInput(FrameBuffer input) => this.setInput((Texture) input.getTexture());

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual FxFilter setOutput(FrameBuffer output)
    {
      this.outputBuffer = output;
      return this;
    }

    [LineNumberTable(new byte[] {46, 122, 99, 203, 134, 107, 104, 134, 139, 99, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void render()
    {
      int num = this.outputBuffer == null || this.outputBuffer.isBound() ? 0 : 1;
      if (num != 0)
        this.outputBuffer.begin();
      this.onBeforeRender();
      this.__\u003C\u003Eshader.bind();
      if (this.autobind)
        this.setParams();
      Draw.blit(this.__\u003C\u003Eshader);
      if (num == 0)
        return;
      this.outputBuffer.end();
    }

    [LineNumberTable(new byte[] {159, 170, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public FxFilter()
      : this((Shader) null)
    {
    }

    [LineNumberTable(new byte[] {159, 174, 127, 72})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public FxFilter(string vert, string frag)
      : this(FxFilter.compileShader(Core.files.classpath(new StringBuilder().append("shaders/").append(vert).append(".vert").toString()), Core.files.classpath(new StringBuilder().append("shaders/").append(frag).append(".frag").toString())))
    {
    }

    [LineNumberTable(new byte[] {13, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void dispose() => this.__\u003C\u003Eshader.dispose();

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void resize(int width, int height)
    {
    }

    [LineNumberTable(new byte[] {25, 137, 107, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void rebind()
    {
      if (this.__\u003C\u003Eshader == null)
        return;
      this.__\u003C\u003Eshader.bind();
      this.setParams();
    }

    [LineNumberTable(new byte[] {72, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void render(FrameBuffer src, FrameBuffer dst) => this.setInput(src).setOutput(dst).render();

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isDisabled() => this.disabled;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setDisabled(bool enabled) => this.disabled = enabled;

    [LineNumberTable(new byte[] {86, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void update() => this.time = Time.time;

    [HideFromJava]
    public virtual bool isDisposed() => Disposable.\u003Cdefault\u003EisDisposed((Disposable) this);

    [Modifiers]
    protected internal Shader shader
    {
      [HideFromJava] get => this.__\u003C\u003Eshader;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Eshader = value;
    }
  }
}
