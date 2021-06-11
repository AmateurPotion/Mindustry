// Decompiled with JetBrains decompiler
// Type: arc.backend.sdl.SdlGL30
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.backend.sdl.jni;
using arc.graphics;
using IKVM.Attributes;
using java.nio;
using System.Runtime.CompilerServices;

namespace arc.backend.sdl
{
  [Implements(new string[] {"arc.graphics.GL30"})]
  public class SdlGL30 : SdlGL20, GL30, GL20
  {
    [LineNumberTable(8)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public SdlGL30()
    {
    }

    [LineNumberTable(9)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glReadBuffer(int mode) => SDLGL.glReadBuffer(mode);

    [LineNumberTable(10)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glDrawRangeElements(
      int mode,
      int start,
      int end,
      int count,
      int type,
      int offset)
    {
      SDLGL.glDrawRangeElements(mode, start, end, count, type, offset);
    }

    [LineNumberTable(11)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glDrawRangeElements(
      int mode,
      int start,
      int end,
      int count,
      int type,
      Buffer indices)
    {
      SDLGL.glDrawRangeElements(mode, start, end, count, type, indices);
    }

    [LineNumberTable(12)]
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
      SDLGL.glTexImage3D(target, level, internalformat, width, height, depth, border, format, type, offset);
    }

    [LineNumberTable(13)]
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
      SDLGL.glTexImage3D(target, level, internalformat, width, height, depth, border, format, type, pixels);
    }

    [LineNumberTable(14)]
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
      SDLGL.glTexSubImage3D(target, level, xoffset, yoffset, zoffset, width, height, depth, format, type, offset);
    }

    [LineNumberTable(15)]
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
      SDLGL.glTexSubImage3D(target, level, xoffset, yoffset, zoffset, width, height, depth, format, type, pixels);
    }

    [LineNumberTable(16)]
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
      SDLGL.glCopyTexSubImage3D(target, level, xoffset, yoffset, zoffset, x, y, width, height);
    }

    [LineNumberTable(17)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glGenQueries(int n, IntBuffer ids) => SDLGL.glGenQueries(n, ids);

    [LineNumberTable(18)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glDeleteQueries(int n, IntBuffer ids) => SDLGL.glDeleteQueries(n, ids);

    [LineNumberTable(19)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool glIsQuery(int id) => SDLGL.glIsQuery(id);

    [LineNumberTable(20)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glBeginQuery(int target, int id) => SDLGL.glBeginQuery(target, id);

    [LineNumberTable(21)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glEndQuery(int target) => SDLGL.glEndQuery(target);

    [LineNumberTable(22)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glGetQueryiv(int target, int pname, IntBuffer @params) => SDLGL.glGetQueryiv(target, pname, @params);

    [LineNumberTable(23)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glGetQueryObjectuiv(int id, int pname, IntBuffer @params) => SDLGL.glGetQueryObjectuiv(id, pname, @params);

    [LineNumberTable(24)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool glUnmapBuffer(int target) => SDLGL.glUnmapBuffer(target);

    [LineNumberTable(25)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Buffer glGetBufferPointerv(int target, int pname) => SDLGL.glGetBufferPointerv(target, pname);

    [LineNumberTable(26)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glDrawBuffers(int n, IntBuffer bufs) => SDLGL.glDrawBuffers(n, bufs);

    [LineNumberTable(27)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glUniformMatrix2x3fv(
      int location,
      int count,
      bool transpose,
      FloatBuffer value)
    {
      int num = transpose ? 1 : 0;
      SDLGL.glUniformMatrix2x3fv(location, count, num != 0, value);
    }

    [LineNumberTable(28)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glUniformMatrix3x2fv(
      int location,
      int count,
      bool transpose,
      FloatBuffer value)
    {
      int num = transpose ? 1 : 0;
      SDLGL.glUniformMatrix3x2fv(location, count, num != 0, value);
    }

    [LineNumberTable(29)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glUniformMatrix2x4fv(
      int location,
      int count,
      bool transpose,
      FloatBuffer value)
    {
      int num = transpose ? 1 : 0;
      SDLGL.glUniformMatrix2x4fv(location, count, num != 0, value);
    }

    [LineNumberTable(30)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glUniformMatrix4x2fv(
      int location,
      int count,
      bool transpose,
      FloatBuffer value)
    {
      int num = transpose ? 1 : 0;
      SDLGL.glUniformMatrix4x2fv(location, count, num != 0, value);
    }

    [LineNumberTable(31)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glUniformMatrix3x4fv(
      int location,
      int count,
      bool transpose,
      FloatBuffer value)
    {
      int num = transpose ? 1 : 0;
      SDLGL.glUniformMatrix3x4fv(location, count, num != 0, value);
    }

    [LineNumberTable(32)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glUniformMatrix4x3fv(
      int location,
      int count,
      bool transpose,
      FloatBuffer value)
    {
      int num = transpose ? 1 : 0;
      SDLGL.glUniformMatrix4x3fv(location, count, num != 0, value);
    }

    [LineNumberTable(33)]
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
      SDLGL.glBlitFramebuffer(srcX0, srcY0, srcX1, srcY1, dstX0, dstY0, dstX1, dstY1, mask, filter);
    }

    [LineNumberTable(34)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glRenderbufferStorageMultisample(
      int target,
      int samples,
      int internalformat,
      int width,
      int height)
    {
      SDLGL.glRenderbufferStorageMultisample(target, samples, internalformat, width, height);
    }

    [LineNumberTable(35)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glFramebufferTextureLayer(
      int target,
      int attachment,
      int texture,
      int level,
      int layer)
    {
      SDLGL.glFramebufferTextureLayer(target, attachment, texture, level, layer);
    }

    [LineNumberTable(36)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glFlushMappedBufferRange(int target, int offset, int length) => SDLGL.glFlushMappedBufferRange(target, offset, length);

    [LineNumberTable(37)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glBindVertexArray(int array) => SDLGL.glBindVertexArray(array);

    [LineNumberTable(38)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glDeleteVertexArrays(int n, IntBuffer arrays) => SDLGL.glDeleteVertexArrays(n, arrays);

    [LineNumberTable(39)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glGenVertexArrays(int n, IntBuffer arrays) => SDLGL.glGenVertexArrays(n, arrays);

    [LineNumberTable(40)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool glIsVertexArray(int array) => SDLGL.glIsVertexArray(array);

    [LineNumberTable(41)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glBeginTransformFeedback(int primitiveMode) => SDLGL.glBeginTransformFeedback(primitiveMode);

    [LineNumberTable(42)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glEndTransformFeedback() => SDLGL.glEndTransformFeedback();

    [LineNumberTable(43)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glBindBufferRange(
      int target,
      int index,
      int buffer,
      int offset,
      int size)
    {
      SDLGL.glBindBufferRange(target, index, buffer, offset, size);
    }

    [LineNumberTable(44)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glBindBufferBase(int target, int index, int buffer) => SDLGL.glBindBufferBase(target, index, buffer);

    [LineNumberTable(45)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glTransformFeedbackVaryings(int program, string[] varyings, int bufferMode) => SDLGL.glTransformFeedbackVaryings(program, varyings, bufferMode);

    [LineNumberTable(46)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glVertexAttribIPointer(
      int index,
      int size,
      int type,
      int stride,
      int offset)
    {
      SDLGL.glVertexAttribIPointer(index, size, type, stride, offset);
    }

    [LineNumberTable(47)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glGetVertexAttribIiv(int index, int pname, IntBuffer @params) => SDLGL.glGetVertexAttribIiv(index, pname, @params);

    [LineNumberTable(48)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glGetVertexAttribIuiv(int index, int pname, IntBuffer @params) => SDLGL.glGetVertexAttribIuiv(index, pname, @params);

    [LineNumberTable(49)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glVertexAttribI4i(int index, int x, int y, int z, int w) => SDLGL.glVertexAttribI4i(index, x, y, z, w);

    [LineNumberTable(50)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glVertexAttribI4ui(int index, int x, int y, int z, int w) => SDLGL.glVertexAttribI4ui(index, x, y, z, w);

    [LineNumberTable(51)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glGetUniformuiv(int program, int location, IntBuffer @params) => SDLGL.glGetUniformuiv(program, location, @params);

    [LineNumberTable(52)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int glGetFragDataLocation(int program, string name) => SDLGL.glGetFragDataLocation(program, name);

    [LineNumberTable(53)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glUniform1uiv(int location, int count, IntBuffer value) => SDLGL.glUniform1uiv(location, count, value);

    [LineNumberTable(54)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glUniform3uiv(int location, int count, IntBuffer value) => SDLGL.glUniform3uiv(location, count, value);

    [LineNumberTable(55)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glUniform4uiv(int location, int count, IntBuffer value) => SDLGL.glUniform4uiv(location, count, value);

    [LineNumberTable(56)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glClearBufferiv(int buffer, int drawbuffer, IntBuffer value) => SDLGL.glClearBufferiv(buffer, drawbuffer, value);

    [LineNumberTable(57)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glClearBufferuiv(int buffer, int drawbuffer, IntBuffer value) => SDLGL.glClearBufferuiv(buffer, drawbuffer, value);

    [LineNumberTable(58)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glClearBufferfv(int buffer, int drawbuffer, FloatBuffer value) => SDLGL.glClearBufferfv(buffer, drawbuffer, value);

    [LineNumberTable(59)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glClearBufferfi(int buffer, int drawbuffer, float depth, int stencil) => SDLGL.glClearBufferfi(buffer, drawbuffer, depth, stencil);

    [LineNumberTable(60)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string glGetStringi(int name, int index) => SDLGL.glGetStringi(name, index);

    [LineNumberTable(61)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glCopyBufferSubData(
      int readTarget,
      int writeTarget,
      int readOffset,
      int writeOffset,
      int size)
    {
      SDLGL.glCopyBufferSubData(readTarget, writeTarget, readOffset, writeOffset, size);
    }

    [LineNumberTable(62)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glGetUniformIndices(
      int program,
      string[] uniformNames,
      IntBuffer uniformIndices)
    {
      SDLGL.glGetUniformIndices(program, uniformNames, uniformIndices);
    }

    [LineNumberTable(63)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glGetActiveUniformsiv(
      int program,
      int uniformCount,
      IntBuffer uniformIndices,
      int pname,
      IntBuffer @params)
    {
      SDLGL.glGetActiveUniformsiv(program, uniformCount, uniformIndices, pname, @params);
    }

    [LineNumberTable(64)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int glGetUniformBlockIndex(int program, string uniformBlockName) => SDLGL.glGetUniformBlockIndex(program, uniformBlockName);

    [LineNumberTable(65)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glGetActiveUniformBlockiv(
      int program,
      int uniformBlockIndex,
      int pname,
      IntBuffer @params)
    {
      SDLGL.glGetActiveUniformBlockiv(program, uniformBlockIndex, pname, @params);
    }

    [LineNumberTable(66)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glGetActiveUniformBlockName(
      int program,
      int uniformBlockIndex,
      Buffer length,
      Buffer uniformBlockName)
    {
      SDLGL.glGetActiveUniformBlockName(program, uniformBlockIndex, length, uniformBlockName);
    }

    [LineNumberTable(67)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glUniformBlockBinding(
      int program,
      int uniformBlockIndex,
      int uniformBlockBinding)
    {
      SDLGL.glUniformBlockBinding(program, uniformBlockIndex, uniformBlockBinding);
    }

    [LineNumberTable(68)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glDrawArraysInstanced(int mode, int first, int count, int instanceCount) => SDLGL.glDrawArraysInstanced(mode, first, count, instanceCount);

    [LineNumberTable(69)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glDrawElementsInstanced(
      int mode,
      int count,
      int type,
      int indicesOffset,
      int instanceCount)
    {
      SDLGL.glDrawElementsInstanced(mode, count, type, indicesOffset, instanceCount);
    }

    [LineNumberTable(70)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glGetInteger64v(int pname, LongBuffer @params) => SDLGL.glGetInteger64v(pname, @params);

    [LineNumberTable(71)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glGetBufferParameteri64v(int target, int pname, LongBuffer @params) => SDLGL.glGetBufferParameteri64v(target, pname, @params);

    [LineNumberTable(72)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glGenSamplers(int count, IntBuffer samplers) => SDLGL.glGenSamplers(count, samplers);

    [LineNumberTable(73)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glDeleteSamplers(int count, IntBuffer samplers) => SDLGL.glDeleteSamplers(count, samplers);

    [LineNumberTable(74)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool glIsSampler(int sampler) => SDLGL.glIsSampler(sampler);

    [LineNumberTable(75)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glBindSampler(int unit, int sampler) => SDLGL.glBindSampler(unit, sampler);

    [LineNumberTable(76)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glSamplerParameteri(int sampler, int pname, int param) => SDLGL.glSamplerParameteri(sampler, pname, param);

    [LineNumberTable(77)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glSamplerParameteriv(int sampler, int pname, IntBuffer param) => SDLGL.glSamplerParameteriv(sampler, pname, param);

    [LineNumberTable(78)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glSamplerParameterf(int sampler, int pname, float param) => SDLGL.glSamplerParameterf(sampler, pname, param);

    [LineNumberTable(79)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glSamplerParameterfv(int sampler, int pname, FloatBuffer param) => SDLGL.glSamplerParameterfv(sampler, pname, param);

    [LineNumberTable(80)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glGetSamplerParameteriv(int sampler, int pname, IntBuffer @params) => SDLGL.glGetSamplerParameteriv(sampler, pname, @params);

    [LineNumberTable(81)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glGetSamplerParameterfv(int sampler, int pname, FloatBuffer @params) => SDLGL.glGetSamplerParameterfv(sampler, pname, @params);

    [LineNumberTable(82)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glVertexAttribDivisor(int index, int divisor) => SDLGL.glVertexAttribDivisor(index, divisor);

    [LineNumberTable(83)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glBindTransformFeedback(int target, int id) => SDLGL.glBindTransformFeedback(target, id);

    [LineNumberTable(84)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glDeleteTransformFeedbacks(int n, IntBuffer ids) => SDLGL.glDeleteTransformFeedbacks(n, ids);

    [LineNumberTable(85)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glGenTransformFeedbacks(int n, IntBuffer ids) => SDLGL.glGenTransformFeedbacks(n, ids);

    [LineNumberTable(86)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool glIsTransformFeedback(int id) => SDLGL.glIsTransformFeedback(id);

    [LineNumberTable(87)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glPauseTransformFeedback() => SDLGL.glPauseTransformFeedback();

    [LineNumberTable(88)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glResumeTransformFeedback() => SDLGL.glResumeTransformFeedback();

    [LineNumberTable(89)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glProgramParameteri(int program, int pname, int value) => SDLGL.glProgramParameteri(program, pname, value);

    [LineNumberTable(90)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void glInvalidateFramebuffer(
      int target,
      int numAttachments,
      IntBuffer attachments)
    {
      SDLGL.glInvalidateFramebuffer(target, numAttachments, attachments);
    }

    [LineNumberTable(91)]
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
      SDLGL.glInvalidateSubFramebuffer(target, numAttachments, attachments, x, y, width, height);
    }
  }
}
