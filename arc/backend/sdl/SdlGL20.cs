// Decompiled with JetBrains decompiler
// Type: arc.backend.sdl.SdlGL20
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.backend.sdl.jni;
using arc.graphics;
using IKVM.Attributes;
using java.lang;
using java.nio;
using System.Runtime.CompilerServices;

namespace arc.backend.sdl
{
  public class SdlGL20 : Object, GL20
  {
    [LineNumberTable(8)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public SdlGL20()
    {
    }

    [LineNumberTable(9)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glActiveTexture(int texture) => SDLGL.glActiveTexture(texture);

    [LineNumberTable(10)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glBindTexture(int target, int texture) => SDLGL.glBindTexture(target, texture);

    [LineNumberTable(11)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glBlendFunc(int sfactor, int dfactor) => SDLGL.glBlendFunc(sfactor, dfactor);

    [LineNumberTable(12)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glClear(int mask) => SDLGL.glClear(mask);

    [LineNumberTable(13)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glClearColor(float red, float green, float blue, float alpha) => SDLGL.glClearColor(red, green, blue, alpha);

    [LineNumberTable(14)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glClearDepthf(float depth) => SDLGL.glClearDepthf(depth);

    [LineNumberTable(15)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glClearStencil(int s) => SDLGL.glClearStencil(s);

    [LineNumberTable(16)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glColorMask(bool red, bool green, bool blue, bool alpha) => SDLGL.glColorMask(red, green, blue, alpha);

    [LineNumberTable(17)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glCompressedTexImage2D(
      int target,
      int level,
      int internalformat,
      int width,
      int height,
      int border,
      int imageSize,
      Buffer data)
    {
      SDLGL.glCompressedTexImage2D(target, level, internalformat, width, height, border, imageSize, data);
    }

    [LineNumberTable(18)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glCompressedTexSubImage2D(
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
      SDLGL.glCompressedTexSubImage2D(target, level, xoffset, yoffset, width, height, format, imageSize, data);
    }

    [LineNumberTable(19)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glCopyTexImage2D(
      int target,
      int level,
      int internalformat,
      int x,
      int y,
      int width,
      int height,
      int border)
    {
      SDLGL.glCopyTexImage2D(target, level, internalformat, x, y, width, height, border);
    }

    [LineNumberTable(20)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glCopyTexSubImage2D(
      int target,
      int level,
      int xoffset,
      int yoffset,
      int x,
      int y,
      int width,
      int height)
    {
      SDLGL.glCopyTexSubImage2D(target, level, xoffset, yoffset, x, y, width, height);
    }

    [LineNumberTable(21)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glCullFace(int mode) => SDLGL.glCullFace(mode);

    [LineNumberTable(22)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glDeleteTexture(int texture) => SDLGL.glDeleteTexture(texture);

    [LineNumberTable(23)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glDepthFunc(int func) => SDLGL.glDepthFunc(func);

    [LineNumberTable(24)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glDepthMask(bool flag) => SDLGL.glDepthMask(flag);

    [LineNumberTable(25)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glDepthRangef(float zNear, float zFar) => SDLGL.glDepthRangef(zNear, zFar);

    [LineNumberTable(26)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glDisable(int cap) => SDLGL.glDisable(cap);

    [LineNumberTable(27)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glDrawArrays(int mode, int first, int count) => SDLGL.glDrawArrays(mode, first, count);

    [LineNumberTable(28)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glDrawElements(int mode, int count, int type, Buffer indices) => SDLGL.glDrawElements(mode, count, type, indices);

    [LineNumberTable(29)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glEnable(int cap) => SDLGL.glEnable(cap);

    [LineNumberTable(30)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glFinish() => SDLGL.glFinish();

    [LineNumberTable(31)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glFlush() => SDLGL.glFlush();

    [LineNumberTable(32)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glFrontFace(int mode) => SDLGL.glFrontFace(mode);

    [LineNumberTable(33)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int glGenTexture() => SDLGL.glGenTexture();

    [LineNumberTable(34)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int glGetError() => SDLGL.glGetError();

    [LineNumberTable(35)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glGetIntegerv(int pname, IntBuffer @params) => SDLGL.glGetIntegerv(pname, @params);

    [LineNumberTable(36)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string glGetString(int name) => SDLGL.glGetString(name);

    [LineNumberTable(37)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glHint(int target, int mode) => SDLGL.glHint(target, mode);

    [LineNumberTable(38)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glLineWidth(float width) => SDLGL.glLineWidth(width);

    [LineNumberTable(39)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glPixelStorei(int pname, int param) => SDLGL.glPixelStorei(pname, param);

    [LineNumberTable(40)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glPolygonOffset(float factor, float units) => SDLGL.glPolygonOffset(factor, units);

    [LineNumberTable(41)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glReadPixels(
      int x,
      int y,
      int width,
      int height,
      int format,
      int type,
      Buffer pixels)
    {
      SDLGL.glReadPixels(x, y, width, height, format, type, pixels);
    }

    [LineNumberTable(42)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glScissor(int x, int y, int width, int height) => SDLGL.glScissor(x, y, width, height);

    [LineNumberTable(43)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glStencilFunc(int func, int @ref, int mask) => SDLGL.glStencilFunc(func, @ref, mask);

    [LineNumberTable(44)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glStencilMask(int mask) => SDLGL.glStencilMask(mask);

    [LineNumberTable(45)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glStencilOp(int fail, int zfail, int zpass) => SDLGL.glStencilOp(fail, zfail, zpass);

    [LineNumberTable(46)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glTexImage2D(
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
      SDLGL.glTexImage2D(target, level, internalformat, width, height, border, format, type, pixels);
    }

    [LineNumberTable(47)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glTexParameterf(int target, int pname, float param) => SDLGL.glTexParameterf(target, pname, param);

    [LineNumberTable(48)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glTexSubImage2D(
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
      SDLGL.glTexSubImage2D(target, level, xoffset, yoffset, width, height, format, type, pixels);
    }

    [LineNumberTable(49)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glViewport(int x, int y, int width, int height) => SDLGL.glViewport(x, y, width, height);

    [LineNumberTable(50)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glAttachShader(int program, int shader) => SDLGL.glAttachShader(program, shader);

    [LineNumberTable(51)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glBindAttribLocation(int program, int index, string name) => SDLGL.glBindAttribLocation(program, index, name);

    [LineNumberTable(52)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glBindBuffer(int target, int buffer) => SDLGL.glBindBuffer(target, buffer);

    [LineNumberTable(53)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glBindFramebuffer(int target, int framebuffer) => SDLGL.glBindFramebuffer(target, framebuffer);

    [LineNumberTable(54)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glBindRenderbuffer(int target, int renderbuffer) => SDLGL.glBindRenderbuffer(target, renderbuffer);

    [LineNumberTable(55)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glBlendColor(float red, float green, float blue, float alpha) => SDLGL.glBlendColor(red, green, blue, alpha);

    [LineNumberTable(56)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glBlendEquation(int mode) => SDLGL.glBlendEquation(mode);

    [LineNumberTable(57)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glBlendEquationSeparate(int modeRGB, int modeAlpha) => SDLGL.glBlendEquationSeparate(modeRGB, modeAlpha);

    [LineNumberTable(58)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glBlendFuncSeparate(int srcRGB, int dstRGB, int srcAlpha, int dstAlpha) => SDLGL.glBlendFuncSeparate(srcRGB, dstRGB, srcAlpha, dstAlpha);

    [LineNumberTable(59)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glBufferData(int target, int size, Buffer data, int usage) => SDLGL.glBufferData(target, size, data, usage);

    [LineNumberTable(60)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glBufferSubData(int target, int offset, int size, Buffer data) => SDLGL.glBufferSubData(target, offset, size, data);

    [LineNumberTable(61)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int glCheckFramebufferStatus(int target) => SDLGL.glCheckFramebufferStatus(target);

    [LineNumberTable(62)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glCompileShader(int shader) => SDLGL.glCompileShader(shader);

    [LineNumberTable(63)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int glCreateProgram() => SDLGL.glCreateProgram();

    [LineNumberTable(64)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int glCreateShader(int type) => SDLGL.glCreateShader(type);

    [LineNumberTable(65)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glDeleteBuffer(int buffer) => SDLGL.glDeleteBuffer(buffer);

    [LineNumberTable(66)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glDeleteFramebuffer(int framebuffer) => SDLGL.glDeleteFramebuffer(framebuffer);

    [LineNumberTable(67)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glDeleteProgram(int program) => SDLGL.glDeleteProgram(program);

    [LineNumberTable(68)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glDeleteRenderbuffer(int renderbuffer) => SDLGL.glDeleteRenderbuffer(renderbuffer);

    [LineNumberTable(69)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glDeleteShader(int shader) => SDLGL.glDeleteShader(shader);

    [LineNumberTable(70)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glDetachShader(int program, int shader) => SDLGL.glDetachShader(program, shader);

    [LineNumberTable(71)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glDisableVertexAttribArray(int index) => SDLGL.glDisableVertexAttribArray(index);

    [LineNumberTable(72)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glDrawElements(int mode, int count, int type, int indices) => SDLGL.glDrawElements(mode, count, type, indices);

    [LineNumberTable(73)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glEnableVertexAttribArray(int index) => SDLGL.glEnableVertexAttribArray(index);

    [LineNumberTable(74)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glFramebufferRenderbuffer(
      int target,
      int attachment,
      int renderbuffertarget,
      int renderbuffer)
    {
      SDLGL.glFramebufferRenderbuffer(target, attachment, renderbuffertarget, renderbuffer);
    }

    [LineNumberTable(75)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glFramebufferTexture2D(
      int target,
      int attachment,
      int textarget,
      int texture,
      int level)
    {
      SDLGL.glFramebufferTexture2D(target, attachment, textarget, texture, level);
    }

    [LineNumberTable(76)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int glGenBuffer() => SDLGL.glGenBuffer();

    [LineNumberTable(77)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glGenerateMipmap(int target) => SDLGL.glGenerateMipmap(target);

    [LineNumberTable(78)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int glGenFramebuffer() => SDLGL.glGenFramebuffer();

    [LineNumberTable(79)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int glGenRenderbuffer() => SDLGL.glGenRenderbuffer();

    [LineNumberTable(80)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string glGetActiveAttrib(
      int program,
      int index,
      IntBuffer size,
      IntBuffer type)
    {
      return SDLGL.glGetActiveAttrib(program, index, (object) size, (object) type);
    }

    [LineNumberTable(81)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string glGetActiveUniform(
      int program,
      int index,
      IntBuffer size,
      IntBuffer type)
    {
      return SDLGL.glGetActiveUniform(program, index, (object) size, (object) type);
    }

    [LineNumberTable(82)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int glGetAttribLocation(int program, string name) => SDLGL.glGetAttribLocation(program, name);

    [LineNumberTable(83)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glGetBooleanv(int pname, Buffer @params) => SDLGL.glGetBooleanv(pname, @params);

    [LineNumberTable(84)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glGetBufferParameteriv(int target, int pname, IntBuffer @params) => SDLGL.glGetBufferParameteriv(target, pname, @params);

    [LineNumberTable(85)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glGetFloatv(int pname, FloatBuffer @params) => SDLGL.glGetFloatv(pname, @params);

    [LineNumberTable(86)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glGetFramebufferAttachmentParameteriv(
      int target,
      int attachment,
      int pname,
      IntBuffer @params)
    {
      SDLGL.glGetFramebufferAttachmentParameteriv(target, attachment, pname, @params);
    }

    [LineNumberTable(87)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glGetProgramiv(int program, int pname, IntBuffer @params) => SDLGL.glGetProgramiv(program, pname, @params);

    [LineNumberTable(88)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string glGetProgramInfoLog(int program) => SDLGL.glGetProgramInfoLog(program);

    [LineNumberTable(89)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glGetRenderbufferParameteriv(int target, int pname, IntBuffer @params) => SDLGL.glGetRenderbufferParameteriv(target, pname, @params);

    [LineNumberTable(90)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glGetShaderiv(int shader, int pname, IntBuffer @params) => SDLGL.glGetShaderiv(shader, pname, @params);

    [LineNumberTable(91)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string glGetShaderInfoLog(int shader) => SDLGL.glGetShaderInfoLog(shader);

    [LineNumberTable(92)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glGetShaderPrecisionFormat(
      int shadertype,
      int precisiontype,
      IntBuffer range,
      IntBuffer precision)
    {
      SDLGL.glGetShaderPrecisionFormat(shadertype, precisiontype, range, precision);
    }

    [LineNumberTable(93)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glGetTexParameterfv(int target, int pname, FloatBuffer @params) => SDLGL.glGetTexParameterfv(target, pname, @params);

    [LineNumberTable(94)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glGetTexParameteriv(int target, int pname, IntBuffer @params) => SDLGL.glGetTexParameteriv(target, pname, @params);

    [LineNumberTable(95)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glGetUniformfv(int program, int location, FloatBuffer @params) => SDLGL.glGetUniformfv(program, location, @params);

    [LineNumberTable(96)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glGetUniformiv(int program, int location, IntBuffer @params) => SDLGL.glGetUniformiv(program, location, @params);

    [LineNumberTable(97)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int glGetUniformLocation(int program, string name) => SDLGL.glGetUniformLocation(program, name);

    [LineNumberTable(98)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glGetVertexAttribfv(int index, int pname, FloatBuffer @params) => SDLGL.glGetVertexAttribfv(index, pname, @params);

    [LineNumberTable(99)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glGetVertexAttribiv(int index, int pname, IntBuffer @params) => SDLGL.glGetVertexAttribiv(index, pname, @params);

    [LineNumberTable(100)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool glIsBuffer(int buffer) => SDLGL.glIsBuffer(buffer);

    [LineNumberTable(101)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool glIsEnabled(int cap) => SDLGL.glIsEnabled(cap);

    [LineNumberTable(102)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool glIsFramebuffer(int framebuffer) => SDLGL.glIsFramebuffer(framebuffer);

    [LineNumberTable(103)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool glIsProgram(int program) => SDLGL.glIsProgram(program);

    [LineNumberTable(104)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool glIsRenderbuffer(int renderbuffer) => SDLGL.glIsRenderbuffer(renderbuffer);

    [LineNumberTable(105)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool glIsShader(int shader) => SDLGL.glIsShader(shader);

    [LineNumberTable(106)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool glIsTexture(int texture) => SDLGL.glIsTexture(texture);

    [LineNumberTable(107)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glLinkProgram(int program) => SDLGL.glLinkProgram(program);

    [LineNumberTable(108)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glReleaseShaderCompiler() => SDLGL.glReleaseShaderCompiler();

    [LineNumberTable(109)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glRenderbufferStorage(
      int target,
      int internalformat,
      int width,
      int height)
    {
      SDLGL.glRenderbufferStorage(target, internalformat, width, height);
    }

    [LineNumberTable(110)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glSampleCoverage(float value, bool invert)
    {
      int num = invert ? 1 : 0;
      SDLGL.glSampleCoverage(value, num != 0);
    }

    [LineNumberTable(111)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glShaderSource(int shader, string @string) => SDLGL.glShaderSource(shader, @string);

    [LineNumberTable(112)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glStencilFuncSeparate(int face, int func, int @ref, int mask) => SDLGL.glStencilFuncSeparate(face, func, @ref, mask);

    [LineNumberTable(113)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glStencilMaskSeparate(int face, int mask) => SDLGL.glStencilMaskSeparate(face, mask);

    [LineNumberTable(114)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glStencilOpSeparate(int face, int fail, int zfail, int zpass) => SDLGL.glStencilOpSeparate(face, fail, zfail, zpass);

    [LineNumberTable(115)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glTexParameterfv(int target, int pname, FloatBuffer @params) => SDLGL.glTexParameterfv(target, pname, @params);

    [LineNumberTable(116)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glTexParameteri(int target, int pname, int param) => SDLGL.glTexParameteri(target, pname, param);

    [LineNumberTable(117)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glTexParameteriv(int target, int pname, IntBuffer @params) => SDLGL.glTexParameteriv(target, pname, @params);

    [LineNumberTable(118)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glUniform1f(int location, float x) => SDLGL.glUniform1f(location, x);

    [LineNumberTable(119)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glUniform1fv(int location, int count, FloatBuffer v) => SDLGL.glUniform1fv(location, count, v);

    [LineNumberTable(120)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glUniform1fv(int location, int count, float[] v, int offset) => SDLGL.glUniform1fv(location, count, v, offset);

    [LineNumberTable(121)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glUniform1i(int location, int x) => SDLGL.glUniform1i(location, x);

    [LineNumberTable(122)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glUniform1iv(int location, int count, IntBuffer v) => SDLGL.glUniform1iv(location, count, v);

    [LineNumberTable(123)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glUniform1iv(int location, int count, int[] v, int offset) => SDLGL.glUniform1iv(location, count, v, offset);

    [LineNumberTable(124)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glUniform2f(int location, float x, float y) => SDLGL.glUniform2f(location, x, y);

    [LineNumberTable(125)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glUniform2fv(int location, int count, FloatBuffer v) => SDLGL.glUniform2fv(location, count, v);

    [LineNumberTable(126)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glUniform2fv(int location, int count, float[] v, int offset) => SDLGL.glUniform2fv(location, count, v, offset);

    [LineNumberTable(127)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glUniform2i(int location, int x, int y) => SDLGL.glUniform2i(location, x, y);

    [LineNumberTable(128)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glUniform2iv(int location, int count, IntBuffer v) => SDLGL.glUniform2iv(location, count, v);

    [LineNumberTable(129)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glUniform2iv(int location, int count, int[] v, int offset) => SDLGL.glUniform2iv(location, count, v, offset);

    [LineNumberTable(130)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glUniform3f(int location, float x, float y, float z) => SDLGL.glUniform3f(location, x, y, z);

    [LineNumberTable(131)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glUniform3fv(int location, int count, FloatBuffer v) => SDLGL.glUniform3fv(location, count, v);

    [LineNumberTable(132)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glUniform3fv(int location, int count, float[] v, int offset) => SDLGL.glUniform3fv(location, count, v, offset);

    [LineNumberTable(133)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glUniform3i(int location, int x, int y, int z) => SDLGL.glUniform3i(location, x, y, z);

    [LineNumberTable(134)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glUniform3iv(int location, int count, IntBuffer v) => SDLGL.glUniform3iv(location, count, v);

    [LineNumberTable(135)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glUniform3iv(int location, int count, int[] v, int offset) => SDLGL.glUniform3iv(location, count, v, offset);

    [LineNumberTable(136)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glUniform4f(int location, float x, float y, float z, float w) => SDLGL.glUniform4f(location, x, y, z, w);

    [LineNumberTable(137)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glUniform4fv(int location, int count, FloatBuffer v) => SDLGL.glUniform4fv(location, count, v);

    [LineNumberTable(138)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glUniform4fv(int location, int count, float[] v, int offset) => SDLGL.glUniform4fv(location, count, v, offset);

    [LineNumberTable(139)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glUniform4i(int location, int x, int y, int z, int w) => SDLGL.glUniform4i(location, x, y, z, w);

    [LineNumberTable(140)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glUniform4iv(int location, int count, IntBuffer v) => SDLGL.glUniform4iv(location, count, v);

    [LineNumberTable(141)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glUniform4iv(int location, int count, int[] v, int offset) => SDLGL.glUniform4iv(location, count, v, offset);

    [LineNumberTable(142)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glUniformMatrix2fv(
      int location,
      int count,
      bool transpose,
      FloatBuffer value)
    {
      int num = transpose ? 1 : 0;
      SDLGL.glUniformMatrix2fv(location, count, num != 0, value);
    }

    [LineNumberTable(143)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glUniformMatrix2fv(
      int location,
      int count,
      bool transpose,
      float[] value,
      int offset)
    {
      int num = transpose ? 1 : 0;
      SDLGL.glUniformMatrix2fv(location, count, num != 0, value, offset);
    }

    [LineNumberTable(144)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glUniformMatrix3fv(
      int location,
      int count,
      bool transpose,
      FloatBuffer value)
    {
      int num = transpose ? 1 : 0;
      SDLGL.glUniformMatrix3fv(location, count, num != 0, value);
    }

    [LineNumberTable(145)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glUniformMatrix3fv(
      int location,
      int count,
      bool transpose,
      float[] value,
      int offset)
    {
      int num = transpose ? 1 : 0;
      SDLGL.glUniformMatrix3fv(location, count, num != 0, value, offset);
    }

    [LineNumberTable(146)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glUniformMatrix4fv(
      int location,
      int count,
      bool transpose,
      FloatBuffer value)
    {
      int num = transpose ? 1 : 0;
      SDLGL.glUniformMatrix4fv(location, count, num != 0, value);
    }

    [LineNumberTable(147)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glUniformMatrix4fv(
      int location,
      int count,
      bool transpose,
      float[] value,
      int offset)
    {
      int num = transpose ? 1 : 0;
      SDLGL.glUniformMatrix4fv(location, count, num != 0, value, offset);
    }

    [LineNumberTable(148)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glUseProgram(int program) => SDLGL.glUseProgram(program);

    [LineNumberTable(149)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glValidateProgram(int program) => SDLGL.glValidateProgram(program);

    [LineNumberTable(150)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glVertexAttrib1f(int indx, float x) => SDLGL.glVertexAttrib1f(indx, x);

    [LineNumberTable(151)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glVertexAttrib1fv(int indx, FloatBuffer values) => SDLGL.glVertexAttrib1fv(indx, values);

    [LineNumberTable(152)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glVertexAttrib2f(int indx, float x, float y) => SDLGL.glVertexAttrib2f(indx, x, y);

    [LineNumberTable(153)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glVertexAttrib2fv(int indx, FloatBuffer values) => SDLGL.glVertexAttrib2fv(indx, values);

    [LineNumberTable(154)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glVertexAttrib3f(int indx, float x, float y, float z) => SDLGL.glVertexAttrib3f(indx, x, y, z);

    [LineNumberTable(155)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glVertexAttrib3fv(int indx, FloatBuffer values) => SDLGL.glVertexAttrib3fv(indx, values);

    [LineNumberTable(156)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glVertexAttrib4f(int indx, float x, float y, float z, float w) => SDLGL.glVertexAttrib4f(indx, x, y, z, w);

    [LineNumberTable(157)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glVertexAttrib4fv(int indx, FloatBuffer values) => SDLGL.glVertexAttrib4fv(indx, values);

    [LineNumberTable(158)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glVertexAttribPointer(
      int indx,
      int size,
      int type,
      bool normalized,
      int stride,
      Buffer ptr)
    {
      int num = normalized ? 1 : 0;
      SDLGL.glVertexAttribPointer(indx, size, type, num != 0, stride, (object) ptr);
    }

    [LineNumberTable(159)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glVertexAttribPointer(
      int indx,
      int size,
      int type,
      bool normalized,
      int stride,
      int ptr)
    {
      int num = normalized ? 1 : 0;
      SDLGL.glVertexAttribPointer(indx, size, type, num != 0, stride, ptr);
    }
  }
}
