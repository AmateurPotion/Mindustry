// Decompiled with JetBrains decompiler
// Type: arc.graphics.profiling.GLProfiler
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.math;
using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;

namespace arc.graphics.profiling
{
  public class GLProfiler : Object
  {
    private Graphics graphics;
    private GLInterceptor glInterceptor;
    private GLErrorListener listener;
    private bool enabled;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual GLErrorListener getListener() => this.listener;

    [LineNumberTable(new byte[] {159, 168, 232, 58, 231, 71, 103, 103, 99, 148, 146, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public GLProfiler(Graphics graphics)
    {
      GLProfiler glProfiler = this;
      this.enabled = false;
      this.graphics = graphics;
      this.glInterceptor = graphics.getGL30() == null ? (GLInterceptor) new GL20Interceptor(this, graphics.getGL20()) : (GLInterceptor) new GL30Interceptor(this, graphics.getGL30());
      this.listener = GLErrorListener.LOGGING_LISTENER;
    }

    [LineNumberTable(new byte[] {159, 181, 137, 108, 99, 152, 177, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void enable()
    {
      if (this.enabled)
        return;
      if (this.graphics.getGL30() != null)
        this.graphics.setGL30((GL30) this.glInterceptor);
      else
        this.graphics.setGL20((GL20) this.glInterceptor);
      this.enabled = true;
    }

    [LineNumberTable(new byte[] {3, 137, 108, 127, 6, 159, 1, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void disable()
    {
      if (!this.enabled)
        return;
      if (this.graphics.getGL30() != null)
        this.graphics.setGL30(((GL30Interceptor) this.graphics.getGL30()).__\u003C\u003Egl30);
      else
        this.graphics.setGL20(((GL20Interceptor) this.graphics.getGL20()).__\u003C\u003Egl20);
      this.enabled = false;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setListener(GLErrorListener errorListener) => this.listener = errorListener;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isEnabled() => this.enabled;

    [LineNumberTable(81)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getCalls() => this.glInterceptor.calls;

    [LineNumberTable(88)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getTextureBindings() => this.glInterceptor.textureBindings;

    [LineNumberTable(92)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getStateChanges() => this.glInterceptor.stateChanges;

    [LineNumberTable(99)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getDrawCalls() => this.glInterceptor.drawCalls;

    [LineNumberTable(106)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getShaderSwitches() => this.glInterceptor.shaderSwitches;

    [LineNumberTable(113)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual FloatCounter getVertexCount() => this.glInterceptor.__\u003C\u003EvertexCount;

    [LineNumberTable(new byte[] {71, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void reset() => this.glInterceptor.reset();
  }
}
