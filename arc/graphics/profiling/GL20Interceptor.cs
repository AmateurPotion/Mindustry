// Decompiled with JetBrains decompiler
// Type: arc.graphics.profiling.GL20Interceptor
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.nio;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.graphics.profiling
{
  [Implements(new string[] {"arc.graphics.GL20"})]
  public class GL20Interceptor : GLInterceptor, GL20
  {
    internal GL20 __\u003C\u003Egl20;

    [LineNumberTable(new byte[] {159, 162, 108, 99, 113, 142})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void check()
    {
      for (int error = this.__\u003C\u003Egl20.glGetError(); error != 0; error = this.__\u003C\u003Egl20.glGetError())
        this.glProfiler.getListener().onError(error);
    }

    [LineNumberTable(new byte[] {159, 157, 105, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal GL20Interceptor(GLProfiler glProfiler, GL20 gl20)
      : base(glProfiler)
    {
      GL20Interceptor gl20Interceptor = this;
      this.__\u003C\u003Egl20 = gl20;
    }

    [LineNumberTable(new byte[] {159, 171, 110, 108, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glActiveTexture(int texture)
    {
      ++this.calls;
      this.__\u003C\u003Egl20.glActiveTexture(texture);
      this.check();
    }

    [LineNumberTable(new byte[] {159, 178, 110, 110, 109, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glBindTexture(int target, int texture)
    {
      ++this.textureBindings;
      ++this.calls;
      this.__\u003C\u003Egl20.glBindTexture(target, texture);
      this.check();
    }

    [LineNumberTable(new byte[] {159, 186, 110, 109, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glBlendFunc(int sfactor, int dfactor)
    {
      ++this.calls;
      this.__\u003C\u003Egl20.glBlendFunc(sfactor, dfactor);
      this.check();
    }

    [LineNumberTable(new byte[] {1, 110, 108, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glClear(int mask)
    {
      ++this.calls;
      this.__\u003C\u003Egl20.glClear(mask);
      this.check();
    }

    [LineNumberTable(new byte[] {8, 110, 116, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glClearColor(float red, float green, float blue, float alpha)
    {
      ++this.calls;
      this.__\u003C\u003Egl20.glClearColor(red, green, blue, alpha);
      this.check();
    }

    [LineNumberTable(new byte[] {15, 110, 109, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glClearDepthf(float depth)
    {
      ++this.calls;
      this.__\u003C\u003Egl20.glClearDepthf(depth);
      this.check();
    }

    [LineNumberTable(new byte[] {22, 110, 108, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glClearStencil(int s)
    {
      ++this.calls;
      this.__\u003C\u003Egl20.glClearStencil(s);
      this.check();
    }

    [LineNumberTable(new byte[] {159, 123, 169, 110, 111, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glColorMask(bool red, bool green, bool blue, bool alpha)
    {
      int num1 = red ? 1 : 0;
      int num2 = green ? 1 : 0;
      int num3 = blue ? 1 : 0;
      int num4 = alpha ? 1 : 0;
      ++this.calls;
      this.__\u003C\u003Egl20.glColorMask(num1 != 0, num2 != 0, num3 != 0, num4 != 0);
      this.check();
    }

    [LineNumberTable(new byte[] {37, 110, 120, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glCompressedTexImage2D(
      int target,
      int level,
      int internalformat,
      int width,
      int height,
      int border,
      int imageSize,
      Buffer data)
    {
      ++this.calls;
      this.__\u003C\u003Egl20.glCompressedTexImage2D(target, level, internalformat, width, height, border, imageSize, data);
      this.check();
    }

    [LineNumberTable(new byte[] {45, 110, 122, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glCompressedTexSubImage2D(
      int target,
      int level,
      int xoffset,
      int yoffset,
      int width,
      int height,
      int format,
      int imageSize,
      Buffer data)
    {
      ++this.calls;
      this.__\u003C\u003Egl20.glCompressedTexSubImage2D(target, level, xoffset, yoffset, width, height, format, imageSize, data);
      this.check();
    }

    [LineNumberTable(new byte[] {52, 110, 120, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glCopyTexImage2D(
      int target,
      int level,
      int internalformat,
      int x,
      int y,
      int width,
      int height,
      int border)
    {
      ++this.calls;
      this.__\u003C\u003Egl20.glCopyTexImage2D(target, level, internalformat, x, y, width, height, border);
      this.check();
    }

    [LineNumberTable(new byte[] {59, 110, 120, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glCopyTexSubImage2D(
      int target,
      int level,
      int xoffset,
      int yoffset,
      int x,
      int y,
      int width,
      int height)
    {
      ++this.calls;
      this.__\u003C\u003Egl20.glCopyTexSubImage2D(target, level, xoffset, yoffset, x, y, width, height);
      this.check();
    }

    [LineNumberTable(new byte[] {66, 110, 108, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glCullFace(int mode)
    {
      ++this.calls;
      this.__\u003C\u003Egl20.glCullFace(mode);
      this.check();
    }

    [LineNumberTable(new byte[] {73, 110, 108, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glDeleteTexture(int texture)
    {
      ++this.calls;
      this.__\u003C\u003Egl20.glDeleteTexture(texture);
      this.check();
    }

    [LineNumberTable(new byte[] {80, 110, 108, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glDepthFunc(int func)
    {
      ++this.calls;
      this.__\u003C\u003Egl20.glDepthFunc(func);
      this.check();
    }

    [LineNumberTable(new byte[] {159, 108, 98, 110, 108, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glDepthMask(bool flag)
    {
      int num = flag ? 1 : 0;
      ++this.calls;
      this.__\u003C\u003Egl20.glDepthMask(num != 0);
      this.check();
    }

    [LineNumberTable(new byte[] {94, 110, 111, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glDepthRangef(float zNear, float zFar)
    {
      ++this.calls;
      this.__\u003C\u003Egl20.glDepthRangef(zNear, zFar);
      this.check();
    }

    [LineNumberTable(new byte[] {101, 110, 108, 110, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glDisable(int cap)
    {
      ++this.calls;
      this.__\u003C\u003Egl20.glDisable(cap);
      ++this.stateChanges;
      this.check();
    }

    [LineNumberTable(new byte[] {109, 109, 110, 110, 110, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glDrawArrays(int mode, int first, int count)
    {
      this.__\u003C\u003EvertexCount.put((float) count);
      ++this.drawCalls;
      ++this.calls;
      this.__\u003C\u003Egl20.glDrawArrays(mode, first, count);
      this.check();
    }

    [LineNumberTable(new byte[] {118, 109, 110, 110, 112, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glDrawElements(int mode, int count, int type, Buffer indices)
    {
      this.__\u003C\u003EvertexCount.put((float) count);
      ++this.drawCalls;
      ++this.calls;
      this.__\u003C\u003Egl20.glDrawElements(mode, count, type, indices);
      this.check();
    }

    [LineNumberTable(new byte[] {127, 110, 110, 108, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glEnable(int cap)
    {
      ++this.calls;
      ++this.stateChanges;
      this.__\u003C\u003Egl20.glEnable(cap);
      this.check();
    }

    [LineNumberTable(new byte[] {160, 71, 110, 107, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glFinish()
    {
      ++this.calls;
      this.__\u003C\u003Egl20.glFinish();
      this.check();
    }

    [LineNumberTable(new byte[] {160, 78, 110, 107, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glFlush()
    {
      ++this.calls;
      this.__\u003C\u003Egl20.glFlush();
      this.check();
    }

    [LineNumberTable(new byte[] {160, 85, 110, 108, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glFrontFace(int mode)
    {
      ++this.calls;
      this.__\u003C\u003Egl20.glFrontFace(mode);
      this.check();
    }

    [LineNumberTable(new byte[] {160, 92, 110, 108, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override int glGenTexture()
    {
      ++this.calls;
      int num = this.__\u003C\u003Egl20.glGenTexture();
      this.check();
      return num;
    }

    [LineNumberTable(new byte[] {160, 100, 142})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override int glGetError()
    {
      ++this.calls;
      return this.__\u003C\u003Egl20.glGetError();
    }

    [LineNumberTable(new byte[] {160, 107, 110, 109, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glGetIntegerv(int pname, IntBuffer @params)
    {
      ++this.calls;
      this.__\u003C\u003Egl20.glGetIntegerv(pname, @params);
      this.check();
    }

    [LineNumberTable(new byte[] {160, 114, 110, 109, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string glGetString(int name)
    {
      ++this.calls;
      string str = this.__\u003C\u003Egl20.glGetString(name);
      this.check();
      return str;
    }

    [LineNumberTable(new byte[] {160, 122, 110, 109, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glHint(int target, int mode)
    {
      ++this.calls;
      this.__\u003C\u003Egl20.glHint(target, mode);
      this.check();
    }

    [LineNumberTable(new byte[] {160, 129, 110, 109, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glLineWidth(float width)
    {
      ++this.calls;
      this.__\u003C\u003Egl20.glLineWidth(width);
      this.check();
    }

    [LineNumberTable(new byte[] {160, 136, 110, 109, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glPixelStorei(int pname, int param)
    {
      ++this.calls;
      this.__\u003C\u003Egl20.glPixelStorei(pname, param);
      this.check();
    }

    [LineNumberTable(new byte[] {160, 143, 110, 111, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glPolygonOffset(float factor, float units)
    {
      ++this.calls;
      this.__\u003C\u003Egl20.glPolygonOffset(factor, units);
      this.check();
    }

    [LineNumberTable(new byte[] {160, 150, 110, 118, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glReadPixels(
      int x,
      int y,
      int width,
      int height,
      int format,
      int type,
      Buffer pixels)
    {
      ++this.calls;
      this.__\u003C\u003Egl20.glReadPixels(x, y, width, height, format, type, pixels);
      this.check();
    }

    [LineNumberTable(new byte[] {160, 157, 110, 112, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glScissor(int x, int y, int width, int height)
    {
      ++this.calls;
      this.__\u003C\u003Egl20.glScissor(x, y, width, height);
      this.check();
    }

    [LineNumberTable(new byte[] {160, 164, 110, 110, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glStencilFunc(int func, int @ref, int mask)
    {
      ++this.calls;
      this.__\u003C\u003Egl20.glStencilFunc(func, @ref, mask);
      this.check();
    }

    [LineNumberTable(new byte[] {160, 171, 110, 108, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glStencilMask(int mask)
    {
      ++this.calls;
      this.__\u003C\u003Egl20.glStencilMask(mask);
      this.check();
    }

    [LineNumberTable(new byte[] {160, 178, 110, 110, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glStencilOp(int fail, int zfail, int zpass)
    {
      ++this.calls;
      this.__\u003C\u003Egl20.glStencilOp(fail, zfail, zpass);
      this.check();
    }

    [LineNumberTable(new byte[] {160, 186, 110, 122, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glTexImage2D(
      int target,
      int level,
      int internalformat,
      int width,
      int height,
      int border,
      int format,
      int type,
      Buffer pixels)
    {
      ++this.calls;
      this.__\u003C\u003Egl20.glTexImage2D(target, level, internalformat, width, height, border, format, type, pixels);
      this.check();
    }

    [LineNumberTable(new byte[] {160, 193, 110, 111, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glTexParameterf(int target, int pname, float param)
    {
      ++this.calls;
      this.__\u003C\u003Egl20.glTexParameterf(target, pname, param);
      this.check();
    }

    [LineNumberTable(new byte[] {160, 201, 110, 122, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glTexSubImage2D(
      int target,
      int level,
      int xoffset,
      int yoffset,
      int width,
      int height,
      int format,
      int type,
      Buffer pixels)
    {
      ++this.calls;
      this.__\u003C\u003Egl20.glTexSubImage2D(target, level, xoffset, yoffset, width, height, format, type, pixels);
      this.check();
    }

    [LineNumberTable(new byte[] {160, 208, 110, 112, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glViewport(int x, int y, int width, int height)
    {
      ++this.calls;
      this.__\u003C\u003Egl20.glViewport(x, y, width, height);
      this.check();
    }

    [LineNumberTable(new byte[] {160, 215, 110, 109, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glAttachShader(int program, int shader)
    {
      ++this.calls;
      this.__\u003C\u003Egl20.glAttachShader(program, shader);
      this.check();
    }

    [LineNumberTable(new byte[] {160, 222, 110, 110, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glBindAttribLocation(int program, int index, string name)
    {
      ++this.calls;
      this.__\u003C\u003Egl20.glBindAttribLocation(program, index, name);
      this.check();
    }

    [LineNumberTable(new byte[] {160, 229, 110, 109, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glBindBuffer(int target, int buffer)
    {
      ++this.calls;
      this.__\u003C\u003Egl20.glBindBuffer(target, buffer);
      this.check();
    }

    [LineNumberTable(new byte[] {160, 236, 110, 109, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glBindFramebuffer(int target, int framebuffer)
    {
      ++this.calls;
      this.__\u003C\u003Egl20.glBindFramebuffer(target, framebuffer);
      this.check();
    }

    [LineNumberTable(new byte[] {160, 243, 110, 109, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glBindRenderbuffer(int target, int renderbuffer)
    {
      ++this.calls;
      this.__\u003C\u003Egl20.glBindRenderbuffer(target, renderbuffer);
      this.check();
    }

    [LineNumberTable(new byte[] {160, 250, 110, 116, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glBlendColor(float red, float green, float blue, float alpha)
    {
      ++this.calls;
      this.__\u003C\u003Egl20.glBlendColor(red, green, blue, alpha);
      this.check();
    }

    [LineNumberTable(new byte[] {161, 1, 110, 108, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glBlendEquation(int mode)
    {
      ++this.calls;
      this.__\u003C\u003Egl20.glBlendEquation(mode);
      this.check();
    }

    [LineNumberTable(new byte[] {161, 8, 110, 109, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glBlendEquationSeparate(int modeRGB, int modeAlpha)
    {
      ++this.calls;
      this.__\u003C\u003Egl20.glBlendEquationSeparate(modeRGB, modeAlpha);
      this.check();
    }

    [LineNumberTable(new byte[] {161, 15, 110, 112, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glBlendFuncSeparate(int srcRGB, int dstRGB, int srcAlpha, int dstAlpha)
    {
      ++this.calls;
      this.__\u003C\u003Egl20.glBlendFuncSeparate(srcRGB, dstRGB, srcAlpha, dstAlpha);
      this.check();
    }

    [LineNumberTable(new byte[] {161, 22, 110, 112, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glBufferData(int target, int size, Buffer data, int usage)
    {
      ++this.calls;
      this.__\u003C\u003Egl20.glBufferData(target, size, data, usage);
      this.check();
    }

    [LineNumberTable(new byte[] {161, 29, 110, 112, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glBufferSubData(int target, int offset, int size, Buffer data)
    {
      ++this.calls;
      this.__\u003C\u003Egl20.glBufferSubData(target, offset, size, data);
      this.check();
    }

    [LineNumberTable(new byte[] {161, 36, 110, 109, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override int glCheckFramebufferStatus(int target)
    {
      ++this.calls;
      int num = this.__\u003C\u003Egl20.glCheckFramebufferStatus(target);
      this.check();
      return num;
    }

    [LineNumberTable(new byte[] {161, 44, 110, 108, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glCompileShader(int shader)
    {
      ++this.calls;
      this.__\u003C\u003Egl20.glCompileShader(shader);
      this.check();
    }

    [LineNumberTable(new byte[] {161, 51, 110, 108, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override int glCreateProgram()
    {
      ++this.calls;
      int program = this.__\u003C\u003Egl20.glCreateProgram();
      this.check();
      return program;
    }

    [LineNumberTable(new byte[] {161, 59, 110, 109, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override int glCreateShader(int type)
    {
      ++this.calls;
      int shader = this.__\u003C\u003Egl20.glCreateShader(type);
      this.check();
      return shader;
    }

    [LineNumberTable(new byte[] {161, 67, 110, 108, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glDeleteBuffer(int buffer)
    {
      ++this.calls;
      this.__\u003C\u003Egl20.glDeleteBuffer(buffer);
      this.check();
    }

    [LineNumberTable(new byte[] {161, 74, 110, 108, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glDeleteFramebuffer(int framebuffer)
    {
      ++this.calls;
      this.__\u003C\u003Egl20.glDeleteFramebuffer(framebuffer);
      this.check();
    }

    [LineNumberTable(new byte[] {161, 81, 110, 108, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glDeleteProgram(int program)
    {
      ++this.calls;
      this.__\u003C\u003Egl20.glDeleteProgram(program);
      this.check();
    }

    [LineNumberTable(new byte[] {161, 88, 110, 108, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glDeleteRenderbuffer(int renderbuffer)
    {
      ++this.calls;
      this.__\u003C\u003Egl20.glDeleteRenderbuffer(renderbuffer);
      this.check();
    }

    [LineNumberTable(new byte[] {161, 95, 110, 108, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glDeleteShader(int shader)
    {
      ++this.calls;
      this.__\u003C\u003Egl20.glDeleteShader(shader);
      this.check();
    }

    [LineNumberTable(new byte[] {161, 102, 110, 109, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glDetachShader(int program, int shader)
    {
      ++this.calls;
      this.__\u003C\u003Egl20.glDetachShader(program, shader);
      this.check();
    }

    [LineNumberTable(new byte[] {161, 109, 110, 108, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glDisableVertexAttribArray(int index)
    {
      ++this.calls;
      this.__\u003C\u003Egl20.glDisableVertexAttribArray(index);
      this.check();
    }

    [LineNumberTable(new byte[] {161, 116, 109, 110, 110, 112, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glDrawElements(int mode, int count, int type, int indices)
    {
      this.__\u003C\u003EvertexCount.put((float) count);
      ++this.drawCalls;
      ++this.calls;
      this.__\u003C\u003Egl20.glDrawElements(mode, count, type, indices);
      this.check();
    }

    [LineNumberTable(new byte[] {161, 125, 110, 108, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glEnableVertexAttribArray(int index)
    {
      ++this.calls;
      this.__\u003C\u003Egl20.glEnableVertexAttribArray(index);
      this.check();
    }

    [LineNumberTable(new byte[] {161, 132, 110, 112, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glFramebufferRenderbuffer(
      int target,
      int attachment,
      int renderbuffertarget,
      int renderbuffer)
    {
      ++this.calls;
      this.__\u003C\u003Egl20.glFramebufferRenderbuffer(target, attachment, renderbuffertarget, renderbuffer);
      this.check();
    }

    [LineNumberTable(new byte[] {161, 139, 110, 114, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glFramebufferTexture2D(
      int target,
      int attachment,
      int textarget,
      int texture,
      int level)
    {
      ++this.calls;
      this.__\u003C\u003Egl20.glFramebufferTexture2D(target, attachment, textarget, texture, level);
      this.check();
    }

    [LineNumberTable(new byte[] {161, 146, 110, 108, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override int glGenBuffer()
    {
      ++this.calls;
      int num = this.__\u003C\u003Egl20.glGenBuffer();
      this.check();
      return num;
    }

    [LineNumberTable(new byte[] {161, 154, 110, 108, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glGenerateMipmap(int target)
    {
      ++this.calls;
      this.__\u003C\u003Egl20.glGenerateMipmap(target);
      this.check();
    }

    [LineNumberTable(new byte[] {161, 161, 110, 108, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override int glGenFramebuffer()
    {
      ++this.calls;
      int num = this.__\u003C\u003Egl20.glGenFramebuffer();
      this.check();
      return num;
    }

    [LineNumberTable(new byte[] {161, 169, 110, 108, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override int glGenRenderbuffer()
    {
      ++this.calls;
      int num = this.__\u003C\u003Egl20.glGenRenderbuffer();
      this.check();
      return num;
    }

    [LineNumberTable(new byte[] {161, 177, 110, 113, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string glGetActiveAttrib(
      int program,
      int index,
      IntBuffer size,
      IntBuffer type)
    {
      ++this.calls;
      string activeAttrib = this.__\u003C\u003Egl20.glGetActiveAttrib(program, index, size, type);
      this.check();
      return activeAttrib;
    }

    [LineNumberTable(new byte[] {161, 185, 110, 113, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string glGetActiveUniform(
      int program,
      int index,
      IntBuffer size,
      IntBuffer type)
    {
      ++this.calls;
      string activeUniform = this.__\u003C\u003Egl20.glGetActiveUniform(program, index, size, type);
      this.check();
      return activeUniform;
    }

    [LineNumberTable(new byte[] {161, 193, 110, 110, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override int glGetAttribLocation(int program, string name)
    {
      ++this.calls;
      int attribLocation = this.__\u003C\u003Egl20.glGetAttribLocation(program, name);
      this.check();
      return attribLocation;
    }

    [LineNumberTable(new byte[] {161, 201, 110, 109, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glGetBooleanv(int pname, Buffer @params)
    {
      ++this.calls;
      this.__\u003C\u003Egl20.glGetBooleanv(pname, @params);
      this.check();
    }

    [LineNumberTable(new byte[] {161, 208, 110, 110, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glGetBufferParameteriv(int target, int pname, IntBuffer @params)
    {
      ++this.calls;
      this.__\u003C\u003Egl20.glGetBufferParameteriv(target, pname, @params);
      this.check();
    }

    [LineNumberTable(new byte[] {161, 215, 110, 109, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glGetFloatv(int pname, FloatBuffer @params)
    {
      ++this.calls;
      this.__\u003C\u003Egl20.glGetFloatv(pname, @params);
      this.check();
    }

    [LineNumberTable(new byte[] {161, 222, 110, 112, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glGetFramebufferAttachmentParameteriv(
      int target,
      int attachment,
      int pname,
      IntBuffer @params)
    {
      ++this.calls;
      this.__\u003C\u003Egl20.glGetFramebufferAttachmentParameteriv(target, attachment, pname, @params);
      this.check();
    }

    [LineNumberTable(new byte[] {161, 229, 110, 110, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glGetProgramiv(int program, int pname, IntBuffer @params)
    {
      ++this.calls;
      this.__\u003C\u003Egl20.glGetProgramiv(program, pname, @params);
      this.check();
    }

    [LineNumberTable(new byte[] {161, 236, 110, 109, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string glGetProgramInfoLog(int program)
    {
      ++this.calls;
      string programInfoLog = this.__\u003C\u003Egl20.glGetProgramInfoLog(program);
      this.check();
      return programInfoLog;
    }

    [LineNumberTable(new byte[] {161, 244, 110, 110, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glGetRenderbufferParameteriv(int target, int pname, IntBuffer @params)
    {
      ++this.calls;
      this.__\u003C\u003Egl20.glGetRenderbufferParameteriv(target, pname, @params);
      this.check();
    }

    [LineNumberTable(new byte[] {161, 251, 110, 110, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glGetShaderiv(int shader, int pname, IntBuffer @params)
    {
      ++this.calls;
      this.__\u003C\u003Egl20.glGetShaderiv(shader, pname, @params);
      this.check();
    }

    [LineNumberTable(new byte[] {162, 2, 110, 109, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string glGetShaderInfoLog(int shader)
    {
      ++this.calls;
      string shaderInfoLog = this.__\u003C\u003Egl20.glGetShaderInfoLog(shader);
      this.check();
      return shaderInfoLog;
    }

    [LineNumberTable(new byte[] {162, 10, 110, 112, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glGetShaderPrecisionFormat(
      int shadertype,
      int precisiontype,
      IntBuffer range,
      IntBuffer precision)
    {
      ++this.calls;
      this.__\u003C\u003Egl20.glGetShaderPrecisionFormat(shadertype, precisiontype, range, precision);
      this.check();
    }

    [LineNumberTable(new byte[] {162, 17, 110, 110, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glGetTexParameterfv(int target, int pname, FloatBuffer @params)
    {
      ++this.calls;
      this.__\u003C\u003Egl20.glGetTexParameterfv(target, pname, @params);
      this.check();
    }

    [LineNumberTable(new byte[] {162, 24, 110, 110, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glGetTexParameteriv(int target, int pname, IntBuffer @params)
    {
      ++this.calls;
      this.__\u003C\u003Egl20.glGetTexParameteriv(target, pname, @params);
      this.check();
    }

    [LineNumberTable(new byte[] {162, 31, 110, 110, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glGetUniformfv(int program, int location, FloatBuffer @params)
    {
      ++this.calls;
      this.__\u003C\u003Egl20.glGetUniformfv(program, location, @params);
      this.check();
    }

    [LineNumberTable(new byte[] {162, 38, 110, 110, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glGetUniformiv(int program, int location, IntBuffer @params)
    {
      ++this.calls;
      this.__\u003C\u003Egl20.glGetUniformiv(program, location, @params);
      this.check();
    }

    [LineNumberTable(new byte[] {162, 45, 110, 110, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override int glGetUniformLocation(int program, string name)
    {
      ++this.calls;
      int uniformLocation = this.__\u003C\u003Egl20.glGetUniformLocation(program, name);
      this.check();
      return uniformLocation;
    }

    [LineNumberTable(new byte[] {162, 53, 110, 110, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glGetVertexAttribfv(int index, int pname, FloatBuffer @params)
    {
      ++this.calls;
      this.__\u003C\u003Egl20.glGetVertexAttribfv(index, pname, @params);
      this.check();
    }

    [LineNumberTable(new byte[] {162, 60, 110, 110, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glGetVertexAttribiv(int index, int pname, IntBuffer @params)
    {
      ++this.calls;
      this.__\u003C\u003Egl20.glGetVertexAttribiv(index, pname, @params);
      this.check();
    }

    [LineNumberTable(new byte[] {162, 67, 110, 109, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool glIsBuffer(int buffer)
    {
      ++this.calls;
      int num = this.__\u003C\u003Egl20.glIsBuffer(buffer) ? 1 : 0;
      this.check();
      return num != 0;
    }

    [LineNumberTable(new byte[] {162, 75, 110, 109, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool glIsEnabled(int cap)
    {
      ++this.calls;
      int num = this.__\u003C\u003Egl20.glIsEnabled(cap) ? 1 : 0;
      this.check();
      return num != 0;
    }

    [LineNumberTable(new byte[] {162, 83, 110, 109, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool glIsFramebuffer(int framebuffer)
    {
      ++this.calls;
      int num = this.__\u003C\u003Egl20.glIsFramebuffer(framebuffer) ? 1 : 0;
      this.check();
      return num != 0;
    }

    [LineNumberTable(new byte[] {162, 91, 110, 109, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool glIsProgram(int program)
    {
      ++this.calls;
      int num = this.__\u003C\u003Egl20.glIsProgram(program) ? 1 : 0;
      this.check();
      return num != 0;
    }

    [LineNumberTable(new byte[] {162, 99, 110, 109, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool glIsRenderbuffer(int renderbuffer)
    {
      ++this.calls;
      int num = this.__\u003C\u003Egl20.glIsRenderbuffer(renderbuffer) ? 1 : 0;
      this.check();
      return num != 0;
    }

    [LineNumberTable(new byte[] {162, 107, 110, 109, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool glIsShader(int shader)
    {
      ++this.calls;
      int num = this.__\u003C\u003Egl20.glIsShader(shader) ? 1 : 0;
      this.check();
      return num != 0;
    }

    [LineNumberTable(new byte[] {162, 115, 110, 109, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool glIsTexture(int texture)
    {
      ++this.calls;
      int num = this.__\u003C\u003Egl20.glIsTexture(texture) ? 1 : 0;
      this.check();
      return num != 0;
    }

    [LineNumberTable(new byte[] {162, 123, 110, 108, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glLinkProgram(int program)
    {
      ++this.calls;
      this.__\u003C\u003Egl20.glLinkProgram(program);
      this.check();
    }

    [LineNumberTable(new byte[] {162, 130, 110, 107, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glReleaseShaderCompiler()
    {
      ++this.calls;
      this.__\u003C\u003Egl20.glReleaseShaderCompiler();
      this.check();
    }

    [LineNumberTable(new byte[] {162, 137, 110, 112, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glRenderbufferStorage(
      int target,
      int internalformat,
      int width,
      int height)
    {
      ++this.calls;
      this.__\u003C\u003Egl20.glRenderbufferStorage(target, internalformat, width, height);
      this.check();
    }

    [LineNumberTable(new byte[] {158, 206, 130, 110, 110, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glSampleCoverage(float value, bool invert)
    {
      int num = invert ? 1 : 0;
      ++this.calls;
      this.__\u003C\u003Egl20.glSampleCoverage(value, num != 0);
      this.check();
    }

    [LineNumberTable(new byte[] {162, 151, 110, 109, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glShaderSource(int shader, string @string)
    {
      ++this.calls;
      this.__\u003C\u003Egl20.glShaderSource(shader, @string);
      this.check();
    }

    [LineNumberTable(new byte[] {162, 158, 110, 112, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glStencilFuncSeparate(int face, int func, int @ref, int mask)
    {
      ++this.calls;
      this.__\u003C\u003Egl20.glStencilFuncSeparate(face, func, @ref, mask);
      this.check();
    }

    [LineNumberTable(new byte[] {162, 165, 110, 109, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glStencilMaskSeparate(int face, int mask)
    {
      ++this.calls;
      this.__\u003C\u003Egl20.glStencilMaskSeparate(face, mask);
      this.check();
    }

    [LineNumberTable(new byte[] {162, 172, 110, 112, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glStencilOpSeparate(int face, int fail, int zfail, int zpass)
    {
      ++this.calls;
      this.__\u003C\u003Egl20.glStencilOpSeparate(face, fail, zfail, zpass);
      this.check();
    }

    [LineNumberTable(new byte[] {162, 179, 110, 110, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glTexParameterfv(int target, int pname, FloatBuffer @params)
    {
      ++this.calls;
      this.__\u003C\u003Egl20.glTexParameterfv(target, pname, @params);
      this.check();
    }

    [LineNumberTable(new byte[] {162, 186, 110, 110, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glTexParameteri(int target, int pname, int param)
    {
      ++this.calls;
      this.__\u003C\u003Egl20.glTexParameteri(target, pname, param);
      this.check();
    }

    [LineNumberTable(new byte[] {162, 193, 110, 110, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glTexParameteriv(int target, int pname, IntBuffer @params)
    {
      ++this.calls;
      this.__\u003C\u003Egl20.glTexParameteriv(target, pname, @params);
      this.check();
    }

    [LineNumberTable(new byte[] {162, 200, 110, 110, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glUniform1f(int location, float x)
    {
      ++this.calls;
      this.__\u003C\u003Egl20.glUniform1f(location, x);
      this.check();
    }

    [LineNumberTable(new byte[] {162, 207, 110, 110, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glUniform1fv(int location, int count, FloatBuffer v)
    {
      ++this.calls;
      this.__\u003C\u003Egl20.glUniform1fv(location, count, v);
      this.check();
    }

    [LineNumberTable(new byte[] {162, 214, 110, 112, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glUniform1fv(int location, int count, float[] v, int offset)
    {
      ++this.calls;
      this.__\u003C\u003Egl20.glUniform1fv(location, count, v, offset);
      this.check();
    }

    [LineNumberTable(new byte[] {162, 221, 110, 109, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glUniform1i(int location, int x)
    {
      ++this.calls;
      this.__\u003C\u003Egl20.glUniform1i(location, x);
      this.check();
    }

    [LineNumberTable(new byte[] {162, 228, 110, 110, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glUniform1iv(int location, int count, IntBuffer v)
    {
      ++this.calls;
      this.__\u003C\u003Egl20.glUniform1iv(location, count, v);
      this.check();
    }

    [LineNumberTable(new byte[] {162, 235, 110, 112, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glUniform1iv(int location, int count, int[] v, int offset)
    {
      ++this.calls;
      this.__\u003C\u003Egl20.glUniform1iv(location, count, v, offset);
      this.check();
    }

    [LineNumberTable(new byte[] {162, 242, 110, 112, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glUniform2f(int location, float x, float y)
    {
      ++this.calls;
      this.__\u003C\u003Egl20.glUniform2f(location, x, y);
      this.check();
    }

    [LineNumberTable(new byte[] {162, 249, 110, 110, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glUniform2fv(int location, int count, FloatBuffer v)
    {
      ++this.calls;
      this.__\u003C\u003Egl20.glUniform2fv(location, count, v);
      this.check();
    }

    [LineNumberTable(new byte[] {163, 0, 110, 112, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glUniform2fv(int location, int count, float[] v, int offset)
    {
      ++this.calls;
      this.__\u003C\u003Egl20.glUniform2fv(location, count, v, offset);
      this.check();
    }

    [LineNumberTable(new byte[] {163, 7, 110, 110, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glUniform2i(int location, int x, int y)
    {
      ++this.calls;
      this.__\u003C\u003Egl20.glUniform2i(location, x, y);
      this.check();
    }

    [LineNumberTable(new byte[] {163, 14, 110, 110, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glUniform2iv(int location, int count, IntBuffer v)
    {
      ++this.calls;
      this.__\u003C\u003Egl20.glUniform2iv(location, count, v);
      this.check();
    }

    [LineNumberTable(new byte[] {163, 21, 110, 112, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glUniform2iv(int location, int count, int[] v, int offset)
    {
      ++this.calls;
      this.__\u003C\u003Egl20.glUniform2iv(location, count, v, offset);
      this.check();
    }

    [LineNumberTable(new byte[] {163, 28, 110, 115, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glUniform3f(int location, float x, float y, float z)
    {
      ++this.calls;
      this.__\u003C\u003Egl20.glUniform3f(location, x, y, z);
      this.check();
    }

    [LineNumberTable(new byte[] {163, 35, 110, 110, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glUniform3fv(int location, int count, FloatBuffer v)
    {
      ++this.calls;
      this.__\u003C\u003Egl20.glUniform3fv(location, count, v);
      this.check();
    }

    [LineNumberTable(new byte[] {163, 42, 110, 112, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glUniform3fv(int location, int count, float[] v, int offset)
    {
      ++this.calls;
      this.__\u003C\u003Egl20.glUniform3fv(location, count, v, offset);
      this.check();
    }

    [LineNumberTable(new byte[] {163, 49, 110, 112, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glUniform3i(int location, int x, int y, int z)
    {
      ++this.calls;
      this.__\u003C\u003Egl20.glUniform3i(location, x, y, z);
      this.check();
    }

    [LineNumberTable(new byte[] {163, 56, 110, 110, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glUniform3iv(int location, int count, IntBuffer v)
    {
      ++this.calls;
      this.__\u003C\u003Egl20.glUniform3iv(location, count, v);
      this.check();
    }

    [LineNumberTable(new byte[] {163, 63, 110, 112, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glUniform3iv(int location, int count, int[] v, int offset)
    {
      ++this.calls;
      this.__\u003C\u003Egl20.glUniform3iv(location, count, v, offset);
      this.check();
    }

    [LineNumberTable(new byte[] {163, 70, 110, 118, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glUniform4f(int location, float x, float y, float z, float w)
    {
      ++this.calls;
      this.__\u003C\u003Egl20.glUniform4f(location, x, y, z, w);
      this.check();
    }

    [LineNumberTable(new byte[] {163, 77, 110, 110, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glUniform4fv(int location, int count, FloatBuffer v)
    {
      ++this.calls;
      this.__\u003C\u003Egl20.glUniform4fv(location, count, v);
      this.check();
    }

    [LineNumberTable(new byte[] {163, 84, 110, 112, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glUniform4fv(int location, int count, float[] v, int offset)
    {
      ++this.calls;
      this.__\u003C\u003Egl20.glUniform4fv(location, count, v, offset);
      this.check();
    }

    [LineNumberTable(new byte[] {163, 91, 110, 114, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glUniform4i(int location, int x, int y, int z, int w)
    {
      ++this.calls;
      this.__\u003C\u003Egl20.glUniform4i(location, x, y, z, w);
      this.check();
    }

    [LineNumberTable(new byte[] {163, 98, 110, 110, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glUniform4iv(int location, int count, IntBuffer v)
    {
      ++this.calls;
      this.__\u003C\u003Egl20.glUniform4iv(location, count, v);
      this.check();
    }

    [LineNumberTable(new byte[] {163, 105, 110, 112, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glUniform4iv(int location, int count, int[] v, int offset)
    {
      ++this.calls;
      this.__\u003C\u003Egl20.glUniform4iv(location, count, v, offset);
      this.check();
    }

    [LineNumberTable(new byte[] {158, 150, 130, 110, 112, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glUniformMatrix2fv(
      int location,
      int count,
      bool transpose,
      FloatBuffer value)
    {
      int num = transpose ? 1 : 0;
      ++this.calls;
      this.__\u003C\u003Egl20.glUniformMatrix2fv(location, count, num != 0, value);
      this.check();
    }

    [LineNumberTable(new byte[] {158, 148, 98, 110, 114, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glUniformMatrix2fv(
      int location,
      int count,
      bool transpose,
      float[] value,
      int offset)
    {
      int num = transpose ? 1 : 0;
      ++this.calls;
      this.__\u003C\u003Egl20.glUniformMatrix2fv(location, count, num != 0, value, offset);
      this.check();
    }

    [LineNumberTable(new byte[] {158, 146, 66, 110, 112, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glUniformMatrix3fv(
      int location,
      int count,
      bool transpose,
      FloatBuffer value)
    {
      int num = transpose ? 1 : 0;
      ++this.calls;
      this.__\u003C\u003Egl20.glUniformMatrix3fv(location, count, num != 0, value);
      this.check();
    }

    [LineNumberTable(new byte[] {158, 145, 162, 110, 114, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glUniformMatrix3fv(
      int location,
      int count,
      bool transpose,
      float[] value,
      int offset)
    {
      int num = transpose ? 1 : 0;
      ++this.calls;
      this.__\u003C\u003Egl20.glUniformMatrix3fv(location, count, num != 0, value, offset);
      this.check();
    }

    [LineNumberTable(new byte[] {158, 143, 130, 110, 112, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glUniformMatrix4fv(
      int location,
      int count,
      bool transpose,
      FloatBuffer value)
    {
      int num = transpose ? 1 : 0;
      ++this.calls;
      this.__\u003C\u003Egl20.glUniformMatrix4fv(location, count, num != 0, value);
      this.check();
    }

    [LineNumberTable(new byte[] {158, 141, 98, 110, 114, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glUniformMatrix4fv(
      int location,
      int count,
      bool transpose,
      float[] value,
      int offset)
    {
      int num = transpose ? 1 : 0;
      ++this.calls;
      this.__\u003C\u003Egl20.glUniformMatrix4fv(location, count, num != 0, value, offset);
      this.check();
    }

    [LineNumberTable(new byte[] {163, 154, 110, 110, 108, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glUseProgram(int program)
    {
      ++this.shaderSwitches;
      ++this.calls;
      this.__\u003C\u003Egl20.glUseProgram(program);
      this.check();
    }

    [LineNumberTable(new byte[] {163, 162, 110, 108, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glValidateProgram(int program)
    {
      ++this.calls;
      this.__\u003C\u003Egl20.glValidateProgram(program);
      this.check();
    }

    [LineNumberTable(new byte[] {163, 169, 110, 110, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glVertexAttrib1f(int indx, float x)
    {
      ++this.calls;
      this.__\u003C\u003Egl20.glVertexAttrib1f(indx, x);
      this.check();
    }

    [LineNumberTable(new byte[] {163, 176, 110, 109, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glVertexAttrib1fv(int indx, FloatBuffer values)
    {
      ++this.calls;
      this.__\u003C\u003Egl20.glVertexAttrib1fv(indx, values);
      this.check();
    }

    [LineNumberTable(new byte[] {163, 183, 110, 112, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glVertexAttrib2f(int indx, float x, float y)
    {
      ++this.calls;
      this.__\u003C\u003Egl20.glVertexAttrib2f(indx, x, y);
      this.check();
    }

    [LineNumberTable(new byte[] {163, 190, 110, 109, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glVertexAttrib2fv(int indx, FloatBuffer values)
    {
      ++this.calls;
      this.__\u003C\u003Egl20.glVertexAttrib2fv(indx, values);
      this.check();
    }

    [LineNumberTable(new byte[] {163, 197, 110, 115, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glVertexAttrib3f(int indx, float x, float y, float z)
    {
      ++this.calls;
      this.__\u003C\u003Egl20.glVertexAttrib3f(indx, x, y, z);
      this.check();
    }

    [LineNumberTable(new byte[] {163, 204, 110, 109, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glVertexAttrib3fv(int indx, FloatBuffer values)
    {
      ++this.calls;
      this.__\u003C\u003Egl20.glVertexAttrib3fv(indx, values);
      this.check();
    }

    [LineNumberTable(new byte[] {163, 211, 110, 118, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glVertexAttrib4f(int indx, float x, float y, float z, float w)
    {
      ++this.calls;
      this.__\u003C\u003Egl20.glVertexAttrib4f(indx, x, y, z, w);
      this.check();
    }

    [LineNumberTable(new byte[] {163, 218, 110, 109, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glVertexAttrib4fv(int indx, FloatBuffer values)
    {
      ++this.calls;
      this.__\u003C\u003Egl20.glVertexAttrib4fv(indx, values);
      this.check();
    }

    [LineNumberTable(new byte[] {158, 122, 163, 110, 115, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glVertexAttribPointer(
      int indx,
      int size,
      int type,
      bool normalized,
      int stride,
      Buffer ptr)
    {
      int num = normalized ? 1 : 0;
      ++this.calls;
      this.__\u003C\u003Egl20.glVertexAttribPointer(indx, size, type, num != 0, stride, ptr);
      this.check();
    }

    [LineNumberTable(new byte[] {158, 120, 131, 110, 115, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glVertexAttribPointer(
      int indx,
      int size,
      int type,
      bool normalized,
      int stride,
      int ptr)
    {
      int num = normalized ? 1 : 0;
      ++this.calls;
      this.__\u003C\u003Egl20.glVertexAttribPointer(indx, size, type, num != 0, stride, ptr);
      this.check();
    }

    [Modifiers]
    protected internal GL20 gl20
    {
      [HideFromJava] get => this.__\u003C\u003Egl20;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Egl20 = value;
    }
  }
}
