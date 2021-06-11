// Decompiled with JetBrains decompiler
// Type: arc.graphics.profiling.GL30Interceptor
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.nio;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.graphics.profiling
{
  [Implements(new string[] {"arc.graphics.GL30"})]
  public class GL30Interceptor : GLInterceptor, GL30, GL20
  {
    internal GL30 __\u003C\u003Egl30;

    [LineNumberTable(new byte[] {159, 167, 108, 99, 113, 142})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void check()
    {
      for (int error = this.__\u003C\u003Egl30.glGetError(); error != 0; error = this.__\u003C\u003Egl30.glGetError())
        this.glProfiler.getListener().onError(error);
    }

    [LineNumberTable(new byte[] {159, 162, 105, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal GL30Interceptor(GLProfiler glProfiler, GL30 gl30)
      : base(glProfiler)
    {
      GL30Interceptor gl30Interceptor = this;
      this.__\u003C\u003Egl30 = gl30;
    }

    [LineNumberTable(new byte[] {159, 176, 110, 108, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glActiveTexture(int texture)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glActiveTexture(texture);
      this.check();
    }

    [LineNumberTable(new byte[] {159, 183, 110, 110, 109, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glBindTexture(int target, int texture)
    {
      ++this.textureBindings;
      ++this.calls;
      this.__\u003C\u003Egl30.glBindTexture(target, texture);
      this.check();
    }

    [LineNumberTable(new byte[] {159, 191, 110, 109, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glBlendFunc(int sfactor, int dfactor)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glBlendFunc(sfactor, dfactor);
      this.check();
    }

    [LineNumberTable(new byte[] {6, 110, 108, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glClear(int mask)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glClear(mask);
      this.check();
    }

    [LineNumberTable(new byte[] {13, 110, 116, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glClearColor(float red, float green, float blue, float alpha)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glClearColor(red, green, blue, alpha);
      this.check();
    }

    [LineNumberTable(new byte[] {20, 110, 109, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glClearDepthf(float depth)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glClearDepthf(depth);
      this.check();
    }

    [LineNumberTable(new byte[] {27, 110, 108, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glClearStencil(int s)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glClearStencil(s);
      this.check();
    }

    [LineNumberTable(new byte[] {159, 121, 73, 110, 111, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glColorMask(bool red, bool green, bool blue, bool alpha)
    {
      int num1 = red ? 1 : 0;
      int num2 = green ? 1 : 0;
      int num3 = blue ? 1 : 0;
      int num4 = alpha ? 1 : 0;
      ++this.calls;
      this.__\u003C\u003Egl30.glColorMask(num1 != 0, num2 != 0, num3 != 0, num4 != 0);
      this.check();
    }

    [LineNumberTable(new byte[] {42, 110, 120, 102})]
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
      this.__\u003C\u003Egl30.glCompressedTexImage2D(target, level, internalformat, width, height, border, imageSize, data);
      this.check();
    }

    [LineNumberTable(new byte[] {50, 110, 122, 102})]
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
      this.__\u003C\u003Egl30.glCompressedTexSubImage2D(target, level, xoffset, yoffset, width, height, format, imageSize, data);
      this.check();
    }

    [LineNumberTable(new byte[] {57, 110, 120, 102})]
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
      this.__\u003C\u003Egl30.glCopyTexImage2D(target, level, internalformat, x, y, width, height, border);
      this.check();
    }

    [LineNumberTable(new byte[] {64, 110, 120, 102})]
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
      this.__\u003C\u003Egl30.glCopyTexSubImage2D(target, level, xoffset, yoffset, x, y, width, height);
      this.check();
    }

    [LineNumberTable(new byte[] {71, 110, 108, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glCullFace(int mode)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glCullFace(mode);
      this.check();
    }

    [LineNumberTable(new byte[] {78, 110, 108, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glDeleteTexture(int texture)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glDeleteTexture(texture);
      this.check();
    }

    [LineNumberTable(new byte[] {85, 110, 108, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glDepthFunc(int func)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glDepthFunc(func);
      this.check();
    }

    [LineNumberTable(new byte[] {159, 107, 130, 110, 108, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glDepthMask(bool flag)
    {
      int num = flag ? 1 : 0;
      ++this.calls;
      this.__\u003C\u003Egl30.glDepthMask(num != 0);
      this.check();
    }

    [LineNumberTable(new byte[] {99, 110, 111, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glDepthRangef(float zNear, float zFar)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glDepthRangef(zNear, zFar);
      this.check();
    }

    [LineNumberTable(new byte[] {106, 110, 108, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glDisable(int cap)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glDisable(cap);
      this.check();
    }

    [LineNumberTable(new byte[] {113, 109, 110, 110, 110, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glDrawArrays(int mode, int first, int count)
    {
      this.__\u003C\u003EvertexCount.put((float) count);
      ++this.drawCalls;
      ++this.calls;
      this.__\u003C\u003Egl30.glDrawArrays(mode, first, count);
      this.check();
    }

    [LineNumberTable(new byte[] {122, 109, 110, 110, 112, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glDrawElements(int mode, int count, int type, Buffer indices)
    {
      this.__\u003C\u003EvertexCount.put((float) count);
      ++this.drawCalls;
      ++this.calls;
      this.__\u003C\u003Egl30.glDrawElements(mode, count, type, indices);
      this.check();
    }

    [LineNumberTable(new byte[] {160, 67, 110, 108, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glEnable(int cap)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glEnable(cap);
      this.check();
    }

    [LineNumberTable(new byte[] {160, 74, 110, 107, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glFinish()
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glFinish();
      this.check();
    }

    [LineNumberTable(new byte[] {160, 81, 110, 107, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glFlush()
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glFlush();
      this.check();
    }

    [LineNumberTable(new byte[] {160, 88, 110, 108, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glFrontFace(int mode)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glFrontFace(mode);
      this.check();
    }

    [LineNumberTable(new byte[] {160, 95, 110, 108, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override int glGenTexture()
    {
      ++this.calls;
      int num = this.__\u003C\u003Egl30.glGenTexture();
      this.check();
      return num;
    }

    [LineNumberTable(new byte[] {160, 103, 142})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override int glGetError()
    {
      ++this.calls;
      return this.__\u003C\u003Egl30.glGetError();
    }

    [LineNumberTable(new byte[] {160, 110, 110, 109, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glGetIntegerv(int pname, IntBuffer @params)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glGetIntegerv(pname, @params);
      this.check();
    }

    [LineNumberTable(new byte[] {160, 117, 110, 109, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string glGetString(int name)
    {
      ++this.calls;
      string str = this.__\u003C\u003Egl30.glGetString(name);
      this.check();
      return str;
    }

    [LineNumberTable(new byte[] {160, 125, 110, 109, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glHint(int target, int mode)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glHint(target, mode);
      this.check();
    }

    [LineNumberTable(new byte[] {160, 132, 110, 109, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glLineWidth(float width)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glLineWidth(width);
      this.check();
    }

    [LineNumberTable(new byte[] {160, 139, 110, 109, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glPixelStorei(int pname, int param)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glPixelStorei(pname, param);
      this.check();
    }

    [LineNumberTable(new byte[] {160, 146, 110, 111, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glPolygonOffset(float factor, float units)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glPolygonOffset(factor, units);
      this.check();
    }

    [LineNumberTable(new byte[] {160, 153, 110, 118, 102})]
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
      this.__\u003C\u003Egl30.glReadPixels(x, y, width, height, format, type, pixels);
      this.check();
    }

    [LineNumberTable(new byte[] {160, 160, 110, 112, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glScissor(int x, int y, int width, int height)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glScissor(x, y, width, height);
      this.check();
    }

    [LineNumberTable(new byte[] {160, 167, 110, 110, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glStencilFunc(int func, int @ref, int mask)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glStencilFunc(func, @ref, mask);
      this.check();
    }

    [LineNumberTable(new byte[] {160, 174, 110, 108, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glStencilMask(int mask)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glStencilMask(mask);
      this.check();
    }

    [LineNumberTable(new byte[] {160, 181, 110, 110, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glStencilOp(int fail, int zfail, int zpass)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glStencilOp(fail, zfail, zpass);
      this.check();
    }

    [LineNumberTable(new byte[] {160, 189, 110, 122, 102})]
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
      this.__\u003C\u003Egl30.glTexImage2D(target, level, internalformat, width, height, border, format, type, pixels);
      this.check();
    }

    [LineNumberTable(new byte[] {160, 196, 110, 111, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glTexParameterf(int target, int pname, float param)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glTexParameterf(target, pname, param);
      this.check();
    }

    [LineNumberTable(new byte[] {160, 204, 110, 122, 102})]
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
      this.__\u003C\u003Egl30.glTexSubImage2D(target, level, xoffset, yoffset, width, height, format, type, pixels);
      this.check();
    }

    [LineNumberTable(new byte[] {160, 211, 110, 112, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glViewport(int x, int y, int width, int height)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glViewport(x, y, width, height);
      this.check();
    }

    [LineNumberTable(new byte[] {160, 218, 110, 109, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glAttachShader(int program, int shader)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glAttachShader(program, shader);
      this.check();
    }

    [LineNumberTable(new byte[] {160, 225, 110, 110, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glBindAttribLocation(int program, int index, string name)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glBindAttribLocation(program, index, name);
      this.check();
    }

    [LineNumberTable(new byte[] {160, 232, 110, 109, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glBindBuffer(int target, int buffer)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glBindBuffer(target, buffer);
      this.check();
    }

    [LineNumberTable(new byte[] {160, 239, 110, 109, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glBindFramebuffer(int target, int framebuffer)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glBindFramebuffer(target, framebuffer);
      this.check();
    }

    [LineNumberTable(new byte[] {160, 246, 110, 109, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glBindRenderbuffer(int target, int renderbuffer)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glBindRenderbuffer(target, renderbuffer);
      this.check();
    }

    [LineNumberTable(new byte[] {160, 253, 110, 116, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glBlendColor(float red, float green, float blue, float alpha)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glBlendColor(red, green, blue, alpha);
      this.check();
    }

    [LineNumberTable(new byte[] {161, 4, 110, 108, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glBlendEquation(int mode)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glBlendEquation(mode);
      this.check();
    }

    [LineNumberTable(new byte[] {161, 11, 110, 109, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glBlendEquationSeparate(int modeRGB, int modeAlpha)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glBlendEquationSeparate(modeRGB, modeAlpha);
      this.check();
    }

    [LineNumberTable(new byte[] {161, 18, 110, 112, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glBlendFuncSeparate(int srcRGB, int dstRGB, int srcAlpha, int dstAlpha)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glBlendFuncSeparate(srcRGB, dstRGB, srcAlpha, dstAlpha);
      this.check();
    }

    [LineNumberTable(new byte[] {161, 25, 110, 112, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glBufferData(int target, int size, Buffer data, int usage)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glBufferData(target, size, data, usage);
      this.check();
    }

    [LineNumberTable(new byte[] {161, 32, 110, 112, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glBufferSubData(int target, int offset, int size, Buffer data)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glBufferSubData(target, offset, size, data);
      this.check();
    }

    [LineNumberTable(new byte[] {161, 39, 110, 109, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override int glCheckFramebufferStatus(int target)
    {
      ++this.calls;
      int num = this.__\u003C\u003Egl30.glCheckFramebufferStatus(target);
      this.check();
      return num;
    }

    [LineNumberTable(new byte[] {161, 47, 110, 108, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glCompileShader(int shader)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glCompileShader(shader);
      this.check();
    }

    [LineNumberTable(new byte[] {161, 54, 110, 108, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override int glCreateProgram()
    {
      ++this.calls;
      int program = this.__\u003C\u003Egl30.glCreateProgram();
      this.check();
      return program;
    }

    [LineNumberTable(new byte[] {161, 62, 110, 109, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override int glCreateShader(int type)
    {
      ++this.calls;
      int shader = this.__\u003C\u003Egl30.glCreateShader(type);
      this.check();
      return shader;
    }

    [LineNumberTable(new byte[] {161, 70, 110, 108, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glDeleteBuffer(int buffer)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glDeleteBuffer(buffer);
      this.check();
    }

    [LineNumberTable(new byte[] {161, 77, 110, 108, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glDeleteFramebuffer(int framebuffer)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glDeleteFramebuffer(framebuffer);
      this.check();
    }

    [LineNumberTable(new byte[] {161, 84, 110, 108, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glDeleteProgram(int program)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glDeleteProgram(program);
      this.check();
    }

    [LineNumberTable(new byte[] {161, 91, 110, 108, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glDeleteRenderbuffer(int renderbuffer)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glDeleteRenderbuffer(renderbuffer);
      this.check();
    }

    [LineNumberTable(new byte[] {161, 98, 110, 108, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glDeleteShader(int shader)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glDeleteShader(shader);
      this.check();
    }

    [LineNumberTable(new byte[] {161, 105, 110, 109, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glDetachShader(int program, int shader)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glDetachShader(program, shader);
      this.check();
    }

    [LineNumberTable(new byte[] {161, 112, 110, 108, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glDisableVertexAttribArray(int index)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glDisableVertexAttribArray(index);
      this.check();
    }

    [LineNumberTable(new byte[] {161, 119, 109, 110, 110, 112, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glDrawElements(int mode, int count, int type, int indices)
    {
      this.__\u003C\u003EvertexCount.put((float) count);
      ++this.drawCalls;
      ++this.calls;
      this.__\u003C\u003Egl30.glDrawElements(mode, count, type, indices);
      this.check();
    }

    [LineNumberTable(new byte[] {161, 128, 110, 108, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glEnableVertexAttribArray(int index)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glEnableVertexAttribArray(index);
      this.check();
    }

    [LineNumberTable(new byte[] {161, 135, 110, 112, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glFramebufferRenderbuffer(
      int target,
      int attachment,
      int renderbuffertarget,
      int renderbuffer)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glFramebufferRenderbuffer(target, attachment, renderbuffertarget, renderbuffer);
      this.check();
    }

    [LineNumberTable(new byte[] {161, 142, 110, 114, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glFramebufferTexture2D(
      int target,
      int attachment,
      int textarget,
      int texture,
      int level)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glFramebufferTexture2D(target, attachment, textarget, texture, level);
      this.check();
    }

    [LineNumberTable(new byte[] {161, 149, 110, 108, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override int glGenBuffer()
    {
      ++this.calls;
      int num = this.__\u003C\u003Egl30.glGenBuffer();
      this.check();
      return num;
    }

    [LineNumberTable(new byte[] {161, 157, 110, 108, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glGenerateMipmap(int target)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glGenerateMipmap(target);
      this.check();
    }

    [LineNumberTable(new byte[] {161, 164, 110, 108, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override int glGenFramebuffer()
    {
      ++this.calls;
      int num = this.__\u003C\u003Egl30.glGenFramebuffer();
      this.check();
      return num;
    }

    [LineNumberTable(new byte[] {161, 172, 110, 108, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override int glGenRenderbuffer()
    {
      ++this.calls;
      int num = this.__\u003C\u003Egl30.glGenRenderbuffer();
      this.check();
      return num;
    }

    [LineNumberTable(new byte[] {161, 180, 110, 113, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string glGetActiveAttrib(
      int program,
      int index,
      IntBuffer size,
      IntBuffer type)
    {
      ++this.calls;
      string activeAttrib = this.__\u003C\u003Egl30.glGetActiveAttrib(program, index, size, type);
      this.check();
      return activeAttrib;
    }

    [LineNumberTable(new byte[] {161, 188, 110, 113, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string glGetActiveUniform(
      int program,
      int index,
      IntBuffer size,
      IntBuffer type)
    {
      ++this.calls;
      string activeUniform = this.__\u003C\u003Egl30.glGetActiveUniform(program, index, size, type);
      this.check();
      return activeUniform;
    }

    [LineNumberTable(new byte[] {161, 196, 110, 110, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override int glGetAttribLocation(int program, string name)
    {
      ++this.calls;
      int attribLocation = this.__\u003C\u003Egl30.glGetAttribLocation(program, name);
      this.check();
      return attribLocation;
    }

    [LineNumberTable(new byte[] {161, 204, 110, 109, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glGetBooleanv(int pname, Buffer @params)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glGetBooleanv(pname, @params);
      this.check();
    }

    [LineNumberTable(new byte[] {161, 211, 110, 110, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glGetBufferParameteriv(int target, int pname, IntBuffer @params)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glGetBufferParameteriv(target, pname, @params);
      this.check();
    }

    [LineNumberTable(new byte[] {161, 218, 110, 109, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glGetFloatv(int pname, FloatBuffer @params)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glGetFloatv(pname, @params);
      this.check();
    }

    [LineNumberTable(new byte[] {161, 225, 110, 112, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glGetFramebufferAttachmentParameteriv(
      int target,
      int attachment,
      int pname,
      IntBuffer @params)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glGetFramebufferAttachmentParameteriv(target, attachment, pname, @params);
      this.check();
    }

    [LineNumberTable(new byte[] {161, 232, 110, 110, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glGetProgramiv(int program, int pname, IntBuffer @params)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glGetProgramiv(program, pname, @params);
      this.check();
    }

    [LineNumberTable(new byte[] {161, 239, 110, 109, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string glGetProgramInfoLog(int program)
    {
      ++this.calls;
      string programInfoLog = this.__\u003C\u003Egl30.glGetProgramInfoLog(program);
      this.check();
      return programInfoLog;
    }

    [LineNumberTable(new byte[] {161, 247, 110, 110, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glGetRenderbufferParameteriv(int target, int pname, IntBuffer @params)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glGetRenderbufferParameteriv(target, pname, @params);
      this.check();
    }

    [LineNumberTable(new byte[] {161, 254, 110, 110, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glGetShaderiv(int shader, int pname, IntBuffer @params)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glGetShaderiv(shader, pname, @params);
      this.check();
    }

    [LineNumberTable(new byte[] {162, 5, 110, 109, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string glGetShaderInfoLog(int shader)
    {
      ++this.calls;
      string shaderInfoLog = this.__\u003C\u003Egl30.glGetShaderInfoLog(shader);
      this.check();
      return shaderInfoLog;
    }

    [LineNumberTable(new byte[] {162, 13, 110, 112, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glGetShaderPrecisionFormat(
      int shadertype,
      int precisiontype,
      IntBuffer range,
      IntBuffer precision)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glGetShaderPrecisionFormat(shadertype, precisiontype, range, precision);
      this.check();
    }

    [LineNumberTable(new byte[] {162, 20, 110, 110, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glGetTexParameterfv(int target, int pname, FloatBuffer @params)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glGetTexParameterfv(target, pname, @params);
      this.check();
    }

    [LineNumberTable(new byte[] {162, 27, 110, 110, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glGetTexParameteriv(int target, int pname, IntBuffer @params)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glGetTexParameteriv(target, pname, @params);
      this.check();
    }

    [LineNumberTable(new byte[] {162, 34, 110, 110, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glGetUniformfv(int program, int location, FloatBuffer @params)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glGetUniformfv(program, location, @params);
      this.check();
    }

    [LineNumberTable(new byte[] {162, 41, 110, 110, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glGetUniformiv(int program, int location, IntBuffer @params)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glGetUniformiv(program, location, @params);
      this.check();
    }

    [LineNumberTable(new byte[] {162, 48, 110, 110, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override int glGetUniformLocation(int program, string name)
    {
      ++this.calls;
      int uniformLocation = this.__\u003C\u003Egl30.glGetUniformLocation(program, name);
      this.check();
      return uniformLocation;
    }

    [LineNumberTable(new byte[] {162, 56, 110, 110, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glGetVertexAttribfv(int index, int pname, FloatBuffer @params)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glGetVertexAttribfv(index, pname, @params);
      this.check();
    }

    [LineNumberTable(new byte[] {162, 63, 110, 110, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glGetVertexAttribiv(int index, int pname, IntBuffer @params)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glGetVertexAttribiv(index, pname, @params);
      this.check();
    }

    [LineNumberTable(new byte[] {162, 70, 110, 109, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool glIsBuffer(int buffer)
    {
      ++this.calls;
      int num = this.__\u003C\u003Egl30.glIsBuffer(buffer) ? 1 : 0;
      this.check();
      return num != 0;
    }

    [LineNumberTable(new byte[] {162, 78, 110, 109, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool glIsEnabled(int cap)
    {
      ++this.calls;
      int num = this.__\u003C\u003Egl30.glIsEnabled(cap) ? 1 : 0;
      this.check();
      return num != 0;
    }

    [LineNumberTable(new byte[] {162, 86, 110, 109, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool glIsFramebuffer(int framebuffer)
    {
      ++this.calls;
      int num = this.__\u003C\u003Egl30.glIsFramebuffer(framebuffer) ? 1 : 0;
      this.check();
      return num != 0;
    }

    [LineNumberTable(new byte[] {162, 94, 110, 109, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool glIsProgram(int program)
    {
      ++this.calls;
      int num = this.__\u003C\u003Egl30.glIsProgram(program) ? 1 : 0;
      this.check();
      return num != 0;
    }

    [LineNumberTable(new byte[] {162, 102, 110, 109, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool glIsRenderbuffer(int renderbuffer)
    {
      ++this.calls;
      int num = this.__\u003C\u003Egl30.glIsRenderbuffer(renderbuffer) ? 1 : 0;
      this.check();
      return num != 0;
    }

    [LineNumberTable(new byte[] {162, 110, 110, 109, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool glIsShader(int shader)
    {
      ++this.calls;
      int num = this.__\u003C\u003Egl30.glIsShader(shader) ? 1 : 0;
      this.check();
      return num != 0;
    }

    [LineNumberTable(new byte[] {162, 118, 110, 109, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool glIsTexture(int texture)
    {
      ++this.calls;
      int num = this.__\u003C\u003Egl30.glIsTexture(texture) ? 1 : 0;
      this.check();
      return num != 0;
    }

    [LineNumberTable(new byte[] {162, 126, 110, 108, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glLinkProgram(int program)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glLinkProgram(program);
      this.check();
    }

    [LineNumberTable(new byte[] {162, 133, 110, 107, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glReleaseShaderCompiler()
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glReleaseShaderCompiler();
      this.check();
    }

    [LineNumberTable(new byte[] {162, 140, 110, 112, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glRenderbufferStorage(
      int target,
      int internalformat,
      int width,
      int height)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glRenderbufferStorage(target, internalformat, width, height);
      this.check();
    }

    [LineNumberTable(new byte[] {158, 205, 98, 110, 110, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glSampleCoverage(float value, bool invert)
    {
      int num = invert ? 1 : 0;
      ++this.calls;
      this.__\u003C\u003Egl30.glSampleCoverage(value, num != 0);
      this.check();
    }

    [LineNumberTable(new byte[] {162, 154, 110, 109, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glShaderSource(int shader, string @string)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glShaderSource(shader, @string);
      this.check();
    }

    [LineNumberTable(new byte[] {162, 161, 110, 112, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glStencilFuncSeparate(int face, int func, int @ref, int mask)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glStencilFuncSeparate(face, func, @ref, mask);
      this.check();
    }

    [LineNumberTable(new byte[] {162, 168, 110, 109, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glStencilMaskSeparate(int face, int mask)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glStencilMaskSeparate(face, mask);
      this.check();
    }

    [LineNumberTable(new byte[] {162, 175, 110, 112, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glStencilOpSeparate(int face, int fail, int zfail, int zpass)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glStencilOpSeparate(face, fail, zfail, zpass);
      this.check();
    }

    [LineNumberTable(new byte[] {162, 182, 110, 110, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glTexParameterfv(int target, int pname, FloatBuffer @params)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glTexParameterfv(target, pname, @params);
      this.check();
    }

    [LineNumberTable(new byte[] {162, 189, 110, 110, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glTexParameteri(int target, int pname, int param)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glTexParameteri(target, pname, param);
      this.check();
    }

    [LineNumberTable(new byte[] {162, 196, 110, 110, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glTexParameteriv(int target, int pname, IntBuffer @params)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glTexParameteriv(target, pname, @params);
      this.check();
    }

    [LineNumberTable(new byte[] {162, 203, 110, 110, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glUniform1f(int location, float x)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glUniform1f(location, x);
      this.check();
    }

    [LineNumberTable(new byte[] {162, 210, 110, 110, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glUniform1fv(int location, int count, FloatBuffer v)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glUniform1fv(location, count, v);
      this.check();
    }

    [LineNumberTable(new byte[] {162, 217, 110, 112, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glUniform1fv(int location, int count, float[] v, int offset)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glUniform1fv(location, count, v, offset);
      this.check();
    }

    [LineNumberTable(new byte[] {162, 224, 110, 109, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glUniform1i(int location, int x)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glUniform1i(location, x);
      this.check();
    }

    [LineNumberTable(new byte[] {162, 231, 110, 110, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glUniform1iv(int location, int count, IntBuffer v)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glUniform1iv(location, count, v);
      this.check();
    }

    [LineNumberTable(new byte[] {162, 238, 110, 112, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glUniform1iv(int location, int count, int[] v, int offset)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glUniform1iv(location, count, v, offset);
      this.check();
    }

    [LineNumberTable(new byte[] {162, 245, 110, 112, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glUniform2f(int location, float x, float y)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glUniform2f(location, x, y);
      this.check();
    }

    [LineNumberTable(new byte[] {162, 252, 110, 110, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glUniform2fv(int location, int count, FloatBuffer v)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glUniform2fv(location, count, v);
      this.check();
    }

    [LineNumberTable(new byte[] {163, 3, 110, 112, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glUniform2fv(int location, int count, float[] v, int offset)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glUniform2fv(location, count, v, offset);
      this.check();
    }

    [LineNumberTable(new byte[] {163, 10, 110, 110, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glUniform2i(int location, int x, int y)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glUniform2i(location, x, y);
      this.check();
    }

    [LineNumberTable(new byte[] {163, 17, 110, 110, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glUniform2iv(int location, int count, IntBuffer v)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glUniform2iv(location, count, v);
      this.check();
    }

    [LineNumberTable(new byte[] {163, 24, 110, 112, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glUniform2iv(int location, int count, int[] v, int offset)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glUniform2iv(location, count, v, offset);
      this.check();
    }

    [LineNumberTable(new byte[] {163, 31, 110, 115, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glUniform3f(int location, float x, float y, float z)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glUniform3f(location, x, y, z);
      this.check();
    }

    [LineNumberTable(new byte[] {163, 38, 110, 110, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glUniform3fv(int location, int count, FloatBuffer v)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glUniform3fv(location, count, v);
      this.check();
    }

    [LineNumberTable(new byte[] {163, 45, 110, 112, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glUniform3fv(int location, int count, float[] v, int offset)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glUniform3fv(location, count, v, offset);
      this.check();
    }

    [LineNumberTable(new byte[] {163, 52, 110, 112, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glUniform3i(int location, int x, int y, int z)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glUniform3i(location, x, y, z);
      this.check();
    }

    [LineNumberTable(new byte[] {163, 59, 110, 110, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glUniform3iv(int location, int count, IntBuffer v)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glUniform3iv(location, count, v);
      this.check();
    }

    [LineNumberTable(new byte[] {163, 66, 110, 112, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glUniform3iv(int location, int count, int[] v, int offset)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glUniform3iv(location, count, v, offset);
      this.check();
    }

    [LineNumberTable(new byte[] {163, 73, 110, 118, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glUniform4f(int location, float x, float y, float z, float w)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glUniform4f(location, x, y, z, w);
      this.check();
    }

    [LineNumberTable(new byte[] {163, 80, 110, 110, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glUniform4fv(int location, int count, FloatBuffer v)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glUniform4fv(location, count, v);
      this.check();
    }

    [LineNumberTable(new byte[] {163, 87, 110, 112, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glUniform4fv(int location, int count, float[] v, int offset)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glUniform4fv(location, count, v, offset);
      this.check();
    }

    [LineNumberTable(new byte[] {163, 94, 110, 114, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glUniform4i(int location, int x, int y, int z, int w)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glUniform4i(location, x, y, z, w);
      this.check();
    }

    [LineNumberTable(new byte[] {163, 101, 110, 110, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glUniform4iv(int location, int count, IntBuffer v)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glUniform4iv(location, count, v);
      this.check();
    }

    [LineNumberTable(new byte[] {163, 108, 110, 112, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glUniform4iv(int location, int count, int[] v, int offset)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glUniform4iv(location, count, v, offset);
      this.check();
    }

    [LineNumberTable(new byte[] {158, 149, 98, 110, 112, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glUniformMatrix2fv(
      int location,
      int count,
      bool transpose,
      FloatBuffer value)
    {
      int num = transpose ? 1 : 0;
      ++this.calls;
      this.__\u003C\u003Egl30.glUniformMatrix2fv(location, count, num != 0, value);
      this.check();
    }

    [LineNumberTable(new byte[] {158, 147, 66, 110, 114, 102})]
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
      this.__\u003C\u003Egl30.glUniformMatrix2fv(location, count, num != 0, value, offset);
      this.check();
    }

    [LineNumberTable(new byte[] {158, 146, 162, 110, 112, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glUniformMatrix3fv(
      int location,
      int count,
      bool transpose,
      FloatBuffer value)
    {
      int num = transpose ? 1 : 0;
      ++this.calls;
      this.__\u003C\u003Egl30.glUniformMatrix3fv(location, count, num != 0, value);
      this.check();
    }

    [LineNumberTable(new byte[] {158, 144, 130, 110, 114, 102})]
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
      this.__\u003C\u003Egl30.glUniformMatrix3fv(location, count, num != 0, value, offset);
      this.check();
    }

    [LineNumberTable(new byte[] {158, 142, 98, 110, 112, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glUniformMatrix4fv(
      int location,
      int count,
      bool transpose,
      FloatBuffer value)
    {
      int num = transpose ? 1 : 0;
      ++this.calls;
      this.__\u003C\u003Egl30.glUniformMatrix4fv(location, count, num != 0, value);
      this.check();
    }

    [LineNumberTable(new byte[] {158, 140, 66, 110, 114, 102})]
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
      this.__\u003C\u003Egl30.glUniformMatrix4fv(location, count, num != 0, value, offset);
      this.check();
    }

    [LineNumberTable(new byte[] {163, 157, 110, 110, 108, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glUseProgram(int program)
    {
      ++this.shaderSwitches;
      ++this.calls;
      this.__\u003C\u003Egl30.glUseProgram(program);
      this.check();
    }

    [LineNumberTable(new byte[] {163, 165, 110, 108, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glValidateProgram(int program)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glValidateProgram(program);
      this.check();
    }

    [LineNumberTable(new byte[] {163, 172, 110, 110, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glVertexAttrib1f(int indx, float x)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glVertexAttrib1f(indx, x);
      this.check();
    }

    [LineNumberTable(new byte[] {163, 179, 110, 109, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glVertexAttrib1fv(int indx, FloatBuffer values)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glVertexAttrib1fv(indx, values);
      this.check();
    }

    [LineNumberTable(new byte[] {163, 186, 110, 112, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glVertexAttrib2f(int indx, float x, float y)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glVertexAttrib2f(indx, x, y);
      this.check();
    }

    [LineNumberTable(new byte[] {163, 193, 110, 109, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glVertexAttrib2fv(int indx, FloatBuffer values)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glVertexAttrib2fv(indx, values);
      this.check();
    }

    [LineNumberTable(new byte[] {163, 200, 110, 115, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glVertexAttrib3f(int indx, float x, float y, float z)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glVertexAttrib3f(indx, x, y, z);
      this.check();
    }

    [LineNumberTable(new byte[] {163, 207, 110, 109, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glVertexAttrib3fv(int indx, FloatBuffer values)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glVertexAttrib3fv(indx, values);
      this.check();
    }

    [LineNumberTable(new byte[] {163, 214, 110, 118, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glVertexAttrib4f(int indx, float x, float y, float z, float w)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glVertexAttrib4f(indx, x, y, z, w);
      this.check();
    }

    [LineNumberTable(new byte[] {163, 221, 110, 109, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void glVertexAttrib4fv(int indx, FloatBuffer values)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glVertexAttrib4fv(indx, values);
      this.check();
    }

    [LineNumberTable(new byte[] {158, 121, 131, 110, 115, 102})]
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
      this.__\u003C\u003Egl30.glVertexAttribPointer(indx, size, type, num != 0, stride, ptr);
      this.check();
    }

    [LineNumberTable(new byte[] {158, 119, 99, 110, 115, 102})]
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
      this.__\u003C\u003Egl30.glVertexAttribPointer(indx, size, type, num != 0, stride, ptr);
      this.check();
    }

    [LineNumberTable(new byte[] {163, 244, 110, 108, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glReadBuffer(int mode)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glReadBuffer(mode);
      this.check();
    }

    [LineNumberTable(new byte[] {163, 251, 110, 110, 110, 116, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glDrawRangeElements(
      int mode,
      int start,
      int end,
      int count,
      int type,
      Buffer indices)
    {
      this.__\u003C\u003EvertexCount.put((float) count);
      ++this.drawCalls;
      ++this.calls;
      this.__\u003C\u003Egl30.glDrawRangeElements(mode, start, end, count, type, indices);
      this.check();
    }

    [LineNumberTable(new byte[] {164, 4, 110, 110, 110, 116, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glDrawRangeElements(
      int mode,
      int start,
      int end,
      int count,
      int type,
      int offset)
    {
      this.__\u003C\u003EvertexCount.put((float) count);
      ++this.drawCalls;
      ++this.calls;
      this.__\u003C\u003Egl30.glDrawRangeElements(mode, start, end, count, type, offset);
      this.check();
    }

    [LineNumberTable(new byte[] {164, 14, 110, 124, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glTexImage3D(
      int target,
      int level,
      int internalformat,
      int width,
      int height,
      int depth,
      int border,
      int format,
      int type,
      Buffer pixels)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glTexImage3D(target, level, internalformat, width, height, depth, border, format, type, pixels);
      this.check();
    }

    [LineNumberTable(new byte[] {164, 22, 110, 124, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glTexImage3D(
      int target,
      int level,
      int internalformat,
      int width,
      int height,
      int depth,
      int border,
      int format,
      int type,
      int offset)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glTexImage3D(target, level, internalformat, width, height, depth, border, format, type, offset);
      this.check();
    }

    [LineNumberTable(new byte[] {164, 30, 110, 126, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glTexSubImage3D(
      int target,
      int level,
      int xoffset,
      int yoffset,
      int zoffset,
      int width,
      int height,
      int depth,
      int format,
      int type,
      Buffer pixels)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glTexSubImage3D(target, level, xoffset, yoffset, zoffset, width, height, depth, format, type, pixels);
      this.check();
    }

    [LineNumberTable(new byte[] {164, 38, 110, 126, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glTexSubImage3D(
      int target,
      int level,
      int xoffset,
      int yoffset,
      int zoffset,
      int width,
      int height,
      int depth,
      int format,
      int type,
      int offset)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glTexSubImage3D(target, level, xoffset, yoffset, zoffset, width, height, depth, format, type, offset);
      this.check();
    }

    [LineNumberTable(new byte[] {164, 46, 110, 122, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glCopyTexSubImage3D(
      int target,
      int level,
      int xoffset,
      int yoffset,
      int zoffset,
      int x,
      int y,
      int width,
      int height)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glCopyTexSubImage3D(target, level, xoffset, yoffset, zoffset, x, y, width, height);
      this.check();
    }

    [LineNumberTable(new byte[] {164, 53, 110, 109, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glGenQueries(int n, IntBuffer ids)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glGenQueries(n, ids);
      this.check();
    }

    [LineNumberTable(new byte[] {164, 60, 110, 109, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glDeleteQueries(int n, IntBuffer ids)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glDeleteQueries(n, ids);
      this.check();
    }

    [LineNumberTable(new byte[] {164, 67, 110, 109, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool glIsQuery(int id)
    {
      ++this.calls;
      int num = this.__\u003C\u003Egl30.glIsQuery(id) ? 1 : 0;
      this.check();
      return num != 0;
    }

    [LineNumberTable(new byte[] {164, 75, 110, 109, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glBeginQuery(int target, int id)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glBeginQuery(target, id);
      this.check();
    }

    [LineNumberTable(new byte[] {164, 82, 110, 108, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glEndQuery(int target)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glEndQuery(target);
      this.check();
    }

    [LineNumberTable(new byte[] {164, 89, 110, 110, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glGetQueryiv(int target, int pname, IntBuffer @params)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glGetQueryiv(target, pname, @params);
      this.check();
    }

    [LineNumberTable(new byte[] {164, 96, 110, 110, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glGetQueryObjectuiv(int id, int pname, IntBuffer @params)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glGetQueryObjectuiv(id, pname, @params);
      this.check();
    }

    [LineNumberTable(new byte[] {164, 103, 110, 109, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool glUnmapBuffer(int target)
    {
      ++this.calls;
      int num = this.__\u003C\u003Egl30.glUnmapBuffer(target) ? 1 : 0;
      this.check();
      return num != 0;
    }

    [LineNumberTable(new byte[] {164, 111, 110, 110, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Buffer glGetBufferPointerv(int target, int pname)
    {
      ++this.calls;
      Buffer bufferPointerv = this.__\u003C\u003Egl30.glGetBufferPointerv(target, pname);
      this.check();
      return bufferPointerv;
    }

    [LineNumberTable(new byte[] {164, 119, 110, 110, 109, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glDrawBuffers(int n, IntBuffer bufs)
    {
      ++this.drawCalls;
      ++this.calls;
      this.__\u003C\u003Egl30.glDrawBuffers(n, bufs);
      this.check();
    }

    [LineNumberTable(new byte[] {158, 82, 98, 110, 112, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glUniformMatrix2x3fv(
      int location,
      int count,
      bool transpose,
      FloatBuffer value)
    {
      int num = transpose ? 1 : 0;
      ++this.calls;
      this.__\u003C\u003Egl30.glUniformMatrix2x3fv(location, count, num != 0, value);
      this.check();
    }

    [LineNumberTable(new byte[] {158, 80, 66, 110, 112, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glUniformMatrix3x2fv(
      int location,
      int count,
      bool transpose,
      FloatBuffer value)
    {
      int num = transpose ? 1 : 0;
      ++this.calls;
      this.__\u003C\u003Egl30.glUniformMatrix3x2fv(location, count, num != 0, value);
      this.check();
    }

    [LineNumberTable(new byte[] {158, 79, 162, 110, 112, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glUniformMatrix2x4fv(
      int location,
      int count,
      bool transpose,
      FloatBuffer value)
    {
      int num = transpose ? 1 : 0;
      ++this.calls;
      this.__\u003C\u003Egl30.glUniformMatrix2x4fv(location, count, num != 0, value);
      this.check();
    }

    [LineNumberTable(new byte[] {158, 77, 130, 110, 112, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glUniformMatrix4x2fv(
      int location,
      int count,
      bool transpose,
      FloatBuffer value)
    {
      int num = transpose ? 1 : 0;
      ++this.calls;
      this.__\u003C\u003Egl30.glUniformMatrix4x2fv(location, count, num != 0, value);
      this.check();
    }

    [LineNumberTable(new byte[] {158, 75, 98, 110, 112, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glUniformMatrix3x4fv(
      int location,
      int count,
      bool transpose,
      FloatBuffer value)
    {
      int num = transpose ? 1 : 0;
      ++this.calls;
      this.__\u003C\u003Egl30.glUniformMatrix3x4fv(location, count, num != 0, value);
      this.check();
    }

    [LineNumberTable(new byte[] {158, 73, 66, 110, 112, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glUniformMatrix4x3fv(
      int location,
      int count,
      bool transpose,
      FloatBuffer value)
    {
      int num = transpose ? 1 : 0;
      ++this.calls;
      this.__\u003C\u003Egl30.glUniformMatrix4x3fv(location, count, num != 0, value);
      this.check();
    }

    [LineNumberTable(new byte[] {164, 170, 110, 124, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glBlitFramebuffer(
      int srcX0,
      int srcY0,
      int srcX1,
      int srcY1,
      int dstX0,
      int dstY0,
      int dstX1,
      int dstY1,
      int mask,
      int filter)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glBlitFramebuffer(srcX0, srcY0, srcX1, srcY1, dstX0, dstY0, dstX1, dstY1, mask, filter);
      this.check();
    }

    [LineNumberTable(new byte[] {164, 177, 110, 114, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glRenderbufferStorageMultisample(
      int target,
      int samples,
      int internalformat,
      int width,
      int height)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glRenderbufferStorageMultisample(target, samples, internalformat, width, height);
      this.check();
    }

    [LineNumberTable(new byte[] {164, 184, 110, 114, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glFramebufferTextureLayer(
      int target,
      int attachment,
      int texture,
      int level,
      int layer)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glFramebufferTextureLayer(target, attachment, texture, level, layer);
      this.check();
    }

    [LineNumberTable(new byte[] {164, 191, 110, 110, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glFlushMappedBufferRange(int target, int offset, int length)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glFlushMappedBufferRange(target, offset, length);
      this.check();
    }

    [LineNumberTable(new byte[] {164, 198, 110, 108, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glBindVertexArray(int array)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glBindVertexArray(array);
      this.check();
    }

    [LineNumberTable(new byte[] {164, 205, 110, 109, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glDeleteVertexArrays(int n, IntBuffer arrays)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glDeleteVertexArrays(n, arrays);
      this.check();
    }

    [LineNumberTable(new byte[] {164, 212, 110, 109, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glGenVertexArrays(int n, IntBuffer arrays)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glGenVertexArrays(n, arrays);
      this.check();
    }

    [LineNumberTable(new byte[] {164, 219, 110, 109, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool glIsVertexArray(int array)
    {
      ++this.calls;
      int num = this.__\u003C\u003Egl30.glIsVertexArray(array) ? 1 : 0;
      this.check();
      return num != 0;
    }

    [LineNumberTable(new byte[] {164, 227, 110, 108, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glBeginTransformFeedback(int primitiveMode)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glBeginTransformFeedback(primitiveMode);
      this.check();
    }

    [LineNumberTable(new byte[] {164, 234, 110, 107, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glEndTransformFeedback()
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glEndTransformFeedback();
      this.check();
    }

    [LineNumberTable(new byte[] {164, 241, 110, 114, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glBindBufferRange(
      int target,
      int index,
      int buffer,
      int offset,
      int size)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glBindBufferRange(target, index, buffer, offset, size);
      this.check();
    }

    [LineNumberTable(new byte[] {164, 248, 110, 110, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glBindBufferBase(int target, int index, int buffer)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glBindBufferBase(target, index, buffer);
      this.check();
    }

    [LineNumberTable(new byte[] {164, 255, 110, 110, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glTransformFeedbackVaryings(int program, string[] varyings, int bufferMode)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glTransformFeedbackVaryings(program, varyings, bufferMode);
      this.check();
    }

    [LineNumberTable(new byte[] {165, 6, 110, 114, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glVertexAttribIPointer(
      int index,
      int size,
      int type,
      int stride,
      int offset)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glVertexAttribIPointer(index, size, type, stride, offset);
      this.check();
    }

    [LineNumberTable(new byte[] {165, 13, 110, 110, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glGetVertexAttribIiv(int index, int pname, IntBuffer @params)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glGetVertexAttribIiv(index, pname, @params);
      this.check();
    }

    [LineNumberTable(new byte[] {165, 20, 110, 110, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glGetVertexAttribIuiv(int index, int pname, IntBuffer @params)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glGetVertexAttribIuiv(index, pname, @params);
      this.check();
    }

    [LineNumberTable(new byte[] {165, 27, 110, 114, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glVertexAttribI4i(int index, int x, int y, int z, int w)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glVertexAttribI4i(index, x, y, z, w);
      this.check();
    }

    [LineNumberTable(new byte[] {165, 34, 110, 114, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glVertexAttribI4ui(int index, int x, int y, int z, int w)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glVertexAttribI4ui(index, x, y, z, w);
      this.check();
    }

    [LineNumberTable(new byte[] {165, 41, 110, 110, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glGetUniformuiv(int program, int location, IntBuffer @params)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glGetUniformuiv(program, location, @params);
      this.check();
    }

    [LineNumberTable(new byte[] {165, 48, 110, 110, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int glGetFragDataLocation(int program, string name)
    {
      ++this.calls;
      int fragDataLocation = this.__\u003C\u003Egl30.glGetFragDataLocation(program, name);
      this.check();
      return fragDataLocation;
    }

    [LineNumberTable(new byte[] {165, 56, 110, 110, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glUniform1uiv(int location, int count, IntBuffer value)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glUniform1uiv(location, count, value);
      this.check();
    }

    [LineNumberTable(new byte[] {165, 63, 110, 110, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glUniform3uiv(int location, int count, IntBuffer value)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glUniform3uiv(location, count, value);
      this.check();
    }

    [LineNumberTable(new byte[] {165, 70, 110, 110, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glUniform4uiv(int location, int count, IntBuffer value)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glUniform4uiv(location, count, value);
      this.check();
    }

    [LineNumberTable(new byte[] {165, 77, 110, 110, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glClearBufferiv(int buffer, int drawbuffer, IntBuffer value)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glClearBufferiv(buffer, drawbuffer, value);
      this.check();
    }

    [LineNumberTable(new byte[] {165, 84, 110, 110, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glClearBufferuiv(int buffer, int drawbuffer, IntBuffer value)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glClearBufferuiv(buffer, drawbuffer, value);
      this.check();
    }

    [LineNumberTable(new byte[] {165, 91, 110, 110, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glClearBufferfv(int buffer, int drawbuffer, FloatBuffer value)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glClearBufferfv(buffer, drawbuffer, value);
      this.check();
    }

    [LineNumberTable(new byte[] {165, 98, 110, 113, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glClearBufferfi(int buffer, int drawbuffer, float depth, int stencil)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glClearBufferfi(buffer, drawbuffer, depth, stencil);
      this.check();
    }

    [LineNumberTable(new byte[] {165, 105, 110, 110, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string glGetStringi(int name, int index)
    {
      ++this.calls;
      string stringi = this.__\u003C\u003Egl30.glGetStringi(name, index);
      this.check();
      return stringi;
    }

    [LineNumberTable(new byte[] {165, 113, 110, 114, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glCopyBufferSubData(
      int readTarget,
      int writeTarget,
      int readOffset,
      int writeOffset,
      int size)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glCopyBufferSubData(readTarget, writeTarget, readOffset, writeOffset, size);
      this.check();
    }

    [LineNumberTable(new byte[] {165, 120, 110, 110, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glGetUniformIndices(
      int program,
      string[] uniformNames,
      IntBuffer uniformIndices)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glGetUniformIndices(program, uniformNames, uniformIndices);
      this.check();
    }

    [LineNumberTable(new byte[] {165, 127, 110, 114, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glGetActiveUniformsiv(
      int program,
      int uniformCount,
      IntBuffer uniformIndices,
      int pname,
      IntBuffer @params)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glGetActiveUniformsiv(program, uniformCount, uniformIndices, pname, @params);
      this.check();
    }

    [LineNumberTable(new byte[] {165, 134, 110, 110, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int glGetUniformBlockIndex(int program, string uniformBlockName)
    {
      ++this.calls;
      int uniformBlockIndex = this.__\u003C\u003Egl30.glGetUniformBlockIndex(program, uniformBlockName);
      this.check();
      return uniformBlockIndex;
    }

    [LineNumberTable(new byte[] {165, 142, 110, 112, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glGetActiveUniformBlockiv(
      int program,
      int uniformBlockIndex,
      int pname,
      IntBuffer @params)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glGetActiveUniformBlockiv(program, uniformBlockIndex, pname, @params);
      this.check();
    }

    [LineNumberTable(new byte[] {165, 149, 110, 112, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glGetActiveUniformBlockName(
      int program,
      int uniformBlockIndex,
      Buffer length,
      Buffer uniformBlockName)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glGetActiveUniformBlockName(program, uniformBlockIndex, length, uniformBlockName);
      this.check();
    }

    [LineNumberTable(new byte[] {165, 156, 110, 110, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glUniformBlockBinding(
      int program,
      int uniformBlockIndex,
      int uniformBlockBinding)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glUniformBlockBinding(program, uniformBlockIndex, uniformBlockBinding);
      this.check();
    }

    [LineNumberTable(new byte[] {165, 163, 109, 110, 110, 112, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glDrawArraysInstanced(int mode, int first, int count, int instanceCount)
    {
      this.__\u003C\u003EvertexCount.put((float) count);
      ++this.drawCalls;
      ++this.calls;
      this.__\u003C\u003Egl30.glDrawArraysInstanced(mode, first, count, instanceCount);
      this.check();
    }

    [LineNumberTable(new byte[] {165, 172, 109, 110, 110, 114, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glDrawElementsInstanced(
      int mode,
      int count,
      int type,
      int indicesOffset,
      int instanceCount)
    {
      this.__\u003C\u003EvertexCount.put((float) count);
      ++this.drawCalls;
      ++this.calls;
      this.__\u003C\u003Egl30.glDrawElementsInstanced(mode, count, type, indicesOffset, instanceCount);
      this.check();
    }

    [LineNumberTable(new byte[] {165, 181, 110, 109, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glGetInteger64v(int pname, LongBuffer @params)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glGetInteger64v(pname, @params);
      this.check();
    }

    [LineNumberTable(new byte[] {165, 188, 110, 110, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glGetBufferParameteri64v(int target, int pname, LongBuffer @params)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glGetBufferParameteri64v(target, pname, @params);
      this.check();
    }

    [LineNumberTable(new byte[] {165, 195, 110, 109, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glGenSamplers(int count, IntBuffer samplers)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glGenSamplers(count, samplers);
      this.check();
    }

    [LineNumberTable(new byte[] {165, 202, 110, 109, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glDeleteSamplers(int count, IntBuffer samplers)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glDeleteSamplers(count, samplers);
      this.check();
    }

    [LineNumberTable(new byte[] {165, 209, 110, 109, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool glIsSampler(int sampler)
    {
      ++this.calls;
      int num = this.__\u003C\u003Egl30.glIsSampler(sampler) ? 1 : 0;
      this.check();
      return num != 0;
    }

    [LineNumberTable(new byte[] {165, 217, 110, 109, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glBindSampler(int unit, int sampler)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glBindSampler(unit, sampler);
      this.check();
    }

    [LineNumberTable(new byte[] {165, 224, 110, 110, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glSamplerParameteri(int sampler, int pname, int param)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glSamplerParameteri(sampler, pname, param);
      this.check();
    }

    [LineNumberTable(new byte[] {165, 231, 110, 110, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glSamplerParameteriv(int sampler, int pname, IntBuffer param)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glSamplerParameteriv(sampler, pname, param);
      this.check();
    }

    [LineNumberTable(new byte[] {165, 238, 110, 111, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glSamplerParameterf(int sampler, int pname, float param)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glSamplerParameterf(sampler, pname, param);
      this.check();
    }

    [LineNumberTable(new byte[] {165, 245, 110, 110, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glSamplerParameterfv(int sampler, int pname, FloatBuffer param)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glSamplerParameterfv(sampler, pname, param);
      this.check();
    }

    [LineNumberTable(new byte[] {165, 252, 110, 110, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glGetSamplerParameteriv(int sampler, int pname, IntBuffer @params)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glGetSamplerParameteriv(sampler, pname, @params);
      this.check();
    }

    [LineNumberTable(new byte[] {166, 3, 110, 110, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glGetSamplerParameterfv(int sampler, int pname, FloatBuffer @params)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glGetSamplerParameterfv(sampler, pname, @params);
      this.check();
    }

    [LineNumberTable(new byte[] {166, 10, 110, 109, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glVertexAttribDivisor(int index, int divisor)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glVertexAttribDivisor(index, divisor);
      this.check();
    }

    [LineNumberTable(new byte[] {166, 17, 110, 109, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glBindTransformFeedback(int target, int id)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glBindTransformFeedback(target, id);
      this.check();
    }

    [LineNumberTable(new byte[] {166, 24, 110, 109, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glDeleteTransformFeedbacks(int n, IntBuffer ids)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glDeleteTransformFeedbacks(n, ids);
      this.check();
    }

    [LineNumberTable(new byte[] {166, 31, 110, 109, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glGenTransformFeedbacks(int n, IntBuffer ids)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glGenTransformFeedbacks(n, ids);
      this.check();
    }

    [LineNumberTable(new byte[] {166, 38, 110, 109, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool glIsTransformFeedback(int id)
    {
      ++this.calls;
      int num = this.__\u003C\u003Egl30.glIsTransformFeedback(id) ? 1 : 0;
      this.check();
      return num != 0;
    }

    [LineNumberTable(new byte[] {166, 46, 110, 107, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glPauseTransformFeedback()
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glPauseTransformFeedback();
      this.check();
    }

    [LineNumberTable(new byte[] {166, 53, 110, 107, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glResumeTransformFeedback()
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glResumeTransformFeedback();
      this.check();
    }

    [LineNumberTable(new byte[] {166, 60, 110, 110, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glProgramParameteri(int program, int pname, int value)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glProgramParameteri(program, pname, value);
      this.check();
    }

    [LineNumberTable(new byte[] {166, 67, 110, 110, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glInvalidateFramebuffer(
      int target,
      int numAttachments,
      IntBuffer attachments)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glInvalidateFramebuffer(target, numAttachments, attachments);
      this.check();
    }

    [LineNumberTable(new byte[] {166, 75, 110, 118, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glInvalidateSubFramebuffer(
      int target,
      int numAttachments,
      IntBuffer attachments,
      int x,
      int y,
      int width,
      int height)
    {
      ++this.calls;
      this.__\u003C\u003Egl30.glInvalidateSubFramebuffer(target, numAttachments, attachments, x, y, width, height);
      this.check();
    }

    [Modifiers]
    protected internal GL30 gl30
    {
      [HideFromJava] get => this.__\u003C\u003Egl30;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Egl30 = value;
    }
  }
}
