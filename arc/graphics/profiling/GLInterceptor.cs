// Decompiled with JetBrains decompiler
// Type: arc.graphics.profiling.GLInterceptor
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.math;
using IKVM.Attributes;
using java.lang;
using java.nio;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.graphics.profiling
{
  public abstract class GLInterceptor : Object, GL20
  {
    internal FloatCounter __\u003C\u003EvertexCount;
    public int calls;
    public int textureBindings;
    public int drawCalls;
    public int shaderSwitches;
    public int stateChanges;
    protected internal GLProfiler glProfiler;

    [LineNumberTable(new byte[] {159, 157, 232, 56, 236, 73, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal GLInterceptor(GLProfiler profiler)
    {
      GLInterceptor glInterceptor = this;
      this.__\u003C\u003EvertexCount = new FloatCounter(0);
      this.glProfiler = profiler;
    }

    [LineNumberTable(new byte[] {159, 162, 127, 11, 102, 102, 102, 102, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static string resolveErrorNumber(int error)
    {
      switch (error)
      {
        case 1280:
          return "GL_INVALID_ENUM";
        case 1281:
          return "GL_INVALID_VALUE";
        case 1282:
          return "GL_INVALID_OPERATION";
        case 1285:
          return "GL_OUT_OF_MEMORY";
        case 1286:
          return "GL_INVALID_FRAMEBUFFER_OPERATION";
        default:
          return new StringBuilder().append("number ").append(error).toString();
      }
    }

    [LineNumberTable(new byte[] {159, 173, 103, 103, 103, 103, 103, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void reset()
    {
      this.calls = 0;
      this.textureBindings = 0;
      this.drawCalls = 0;
      this.shaderSwitches = 0;
      this.stateChanges = 0;
      this.__\u003C\u003EvertexCount.reset();
    }

    [HideFromJava]
    public abstract void glActiveTexture([In] int obj0);

    [HideFromJava]
    public abstract void glBindTexture([In] int obj0, [In] int obj1);

    [HideFromJava]
    public abstract void glBlendFunc([In] int obj0, [In] int obj1);

    [HideFromJava]
    public abstract void glClear([In] int obj0);

    [HideFromJava]
    public abstract void glClearColor([In] float obj0, [In] float obj1, [In] float obj2, [In] float obj3);

    [HideFromJava]
    public abstract void glClearDepthf([In] float obj0);

    [HideFromJava]
    public abstract void glClearStencil([In] int obj0);

    [HideFromJava]
    public abstract void glColorMask([In] bool obj0, [In] bool obj1, [In] bool obj2, [In] bool obj3);

    [HideFromJava]
    public abstract void glCompressedTexImage2D(
      [In] int obj0,
      [In] int obj1,
      [In] int obj2,
      [In] int obj3,
      [In] int obj4,
      [In] int obj5,
      [In] int obj6,
      [In] Buffer obj7);

    [HideFromJava]
    public abstract void glCompressedTexSubImage2D(
      [In] int obj0,
      [In] int obj1,
      [In] int obj2,
      [In] int obj3,
      [In] int obj4,
      [In] int obj5,
      [In] int obj6,
      [In] int obj7,
      [In] Buffer obj8);

    [HideFromJava]
    public abstract void glCopyTexImage2D(
      [In] int obj0,
      [In] int obj1,
      [In] int obj2,
      [In] int obj3,
      [In] int obj4,
      [In] int obj5,
      [In] int obj6,
      [In] int obj7);

    [HideFromJava]
    public abstract void glCopyTexSubImage2D(
      [In] int obj0,
      [In] int obj1,
      [In] int obj2,
      [In] int obj3,
      [In] int obj4,
      [In] int obj5,
      [In] int obj6,
      [In] int obj7);

    [HideFromJava]
    public abstract void glCullFace([In] int obj0);

    [HideFromJava]
    public abstract void glDeleteTexture([In] int obj0);

    [HideFromJava]
    public abstract void glDepthFunc([In] int obj0);

    [HideFromJava]
    public abstract void glDepthMask([In] bool obj0);

    [HideFromJava]
    public abstract void glDepthRangef([In] float obj0, [In] float obj1);

    [HideFromJava]
    public abstract void glDisable([In] int obj0);

    [HideFromJava]
    public abstract void glDrawArrays([In] int obj0, [In] int obj1, [In] int obj2);

    [HideFromJava]
    public abstract void glDrawElements([In] int obj0, [In] int obj1, [In] int obj2, [In] Buffer obj3);

    [HideFromJava]
    public abstract void glEnable([In] int obj0);

    [HideFromJava]
    public abstract void glFinish();

    [HideFromJava]
    public abstract void glFlush();

    [HideFromJava]
    public abstract void glFrontFace([In] int obj0);

    [HideFromJava]
    public abstract int glGenTexture();

    [HideFromJava]
    public abstract int glGetError();

    [HideFromJava]
    public abstract void glGetIntegerv([In] int obj0, [In] IntBuffer obj1);

    [HideFromJava]
    public abstract string glGetString([In] int obj0);

    [HideFromJava]
    public abstract void glHint([In] int obj0, [In] int obj1);

    [HideFromJava]
    public abstract void glLineWidth([In] float obj0);

    [HideFromJava]
    public abstract void glPixelStorei([In] int obj0, [In] int obj1);

    [HideFromJava]
    public abstract void glPolygonOffset([In] float obj0, [In] float obj1);

    [HideFromJava]
    public abstract void glReadPixels(
      [In] int obj0,
      [In] int obj1,
      [In] int obj2,
      [In] int obj3,
      [In] int obj4,
      [In] int obj5,
      [In] Buffer obj6);

    [HideFromJava]
    public abstract void glScissor([In] int obj0, [In] int obj1, [In] int obj2, [In] int obj3);

    [HideFromJava]
    public abstract void glStencilFunc([In] int obj0, [In] int obj1, [In] int obj2);

    [HideFromJava]
    public abstract void glStencilMask([In] int obj0);

    [HideFromJava]
    public abstract void glStencilOp([In] int obj0, [In] int obj1, [In] int obj2);

    [HideFromJava]
    public abstract void glTexImage2D(
      [In] int obj0,
      [In] int obj1,
      [In] int obj2,
      [In] int obj3,
      [In] int obj4,
      [In] int obj5,
      [In] int obj6,
      [In] int obj7,
      [In] Buffer obj8);

    [HideFromJava]
    public abstract void glTexParameterf([In] int obj0, [In] int obj1, [In] float obj2);

    [HideFromJava]
    public abstract void glTexSubImage2D(
      [In] int obj0,
      [In] int obj1,
      [In] int obj2,
      [In] int obj3,
      [In] int obj4,
      [In] int obj5,
      [In] int obj6,
      [In] int obj7,
      [In] Buffer obj8);

    [HideFromJava]
    public abstract void glViewport([In] int obj0, [In] int obj1, [In] int obj2, [In] int obj3);

    [HideFromJava]
    public abstract void glAttachShader([In] int obj0, [In] int obj1);

    [HideFromJava]
    public abstract void glBindAttribLocation([In] int obj0, [In] int obj1, [In] string obj2);

    [HideFromJava]
    public abstract void glBindBuffer([In] int obj0, [In] int obj1);

    [HideFromJava]
    public abstract void glBindFramebuffer([In] int obj0, [In] int obj1);

    [HideFromJava]
    public abstract void glBindRenderbuffer([In] int obj0, [In] int obj1);

    [HideFromJava]
    public abstract void glBlendColor([In] float obj0, [In] float obj1, [In] float obj2, [In] float obj3);

    [HideFromJava]
    public abstract void glBlendEquation([In] int obj0);

    [HideFromJava]
    public abstract void glBlendEquationSeparate([In] int obj0, [In] int obj1);

    [HideFromJava]
    public abstract void glBlendFuncSeparate([In] int obj0, [In] int obj1, [In] int obj2, [In] int obj3);

    [HideFromJava]
    public abstract void glBufferData([In] int obj0, [In] int obj1, [In] Buffer obj2, [In] int obj3);

    [HideFromJava]
    public abstract void glBufferSubData([In] int obj0, [In] int obj1, [In] int obj2, [In] Buffer obj3);

    [HideFromJava]
    public abstract int glCheckFramebufferStatus([In] int obj0);

    [HideFromJava]
    public abstract void glCompileShader([In] int obj0);

    [HideFromJava]
    public abstract int glCreateProgram();

    [HideFromJava]
    public abstract int glCreateShader([In] int obj0);

    [HideFromJava]
    public abstract void glDeleteBuffer([In] int obj0);

    [HideFromJava]
    public abstract void glDeleteFramebuffer([In] int obj0);

    [HideFromJava]
    public abstract void glDeleteProgram([In] int obj0);

    [HideFromJava]
    public abstract void glDeleteRenderbuffer([In] int obj0);

    [HideFromJava]
    public abstract void glDeleteShader([In] int obj0);

    [HideFromJava]
    public abstract void glDetachShader([In] int obj0, [In] int obj1);

    [HideFromJava]
    public abstract void glDisableVertexAttribArray([In] int obj0);

    [HideFromJava]
    public abstract void glDrawElements([In] int obj0, [In] int obj1, [In] int obj2, [In] int obj3);

    [HideFromJava]
    public abstract void glEnableVertexAttribArray([In] int obj0);

    [HideFromJava]
    public abstract void glFramebufferRenderbuffer([In] int obj0, [In] int obj1, [In] int obj2, [In] int obj3);

    [HideFromJava]
    public abstract void glFramebufferTexture2D([In] int obj0, [In] int obj1, [In] int obj2, [In] int obj3, [In] int obj4);

    [HideFromJava]
    public abstract int glGenBuffer();

    [HideFromJava]
    public abstract void glGenerateMipmap([In] int obj0);

    [HideFromJava]
    public abstract int glGenFramebuffer();

    [HideFromJava]
    public abstract int glGenRenderbuffer();

    [HideFromJava]
    public abstract string glGetActiveAttrib([In] int obj0, [In] int obj1, [In] IntBuffer obj2, [In] IntBuffer obj3);

    [HideFromJava]
    public abstract string glGetActiveUniform([In] int obj0, [In] int obj1, [In] IntBuffer obj2, [In] IntBuffer obj3);

    [HideFromJava]
    public abstract int glGetAttribLocation([In] int obj0, [In] string obj1);

    [HideFromJava]
    public abstract void glGetBooleanv([In] int obj0, [In] Buffer obj1);

    [HideFromJava]
    public abstract void glGetBufferParameteriv([In] int obj0, [In] int obj1, [In] IntBuffer obj2);

    [HideFromJava]
    public abstract void glGetFloatv([In] int obj0, [In] FloatBuffer obj1);

    [HideFromJava]
    public abstract void glGetFramebufferAttachmentParameteriv(
      [In] int obj0,
      [In] int obj1,
      [In] int obj2,
      [In] IntBuffer obj3);

    [HideFromJava]
    public abstract void glGetProgramiv([In] int obj0, [In] int obj1, [In] IntBuffer obj2);

    [HideFromJava]
    public abstract string glGetProgramInfoLog([In] int obj0);

    [HideFromJava]
    public abstract void glGetRenderbufferParameteriv([In] int obj0, [In] int obj1, [In] IntBuffer obj2);

    [HideFromJava]
    public abstract void glGetShaderiv([In] int obj0, [In] int obj1, [In] IntBuffer obj2);

    [HideFromJava]
    public abstract string glGetShaderInfoLog([In] int obj0);

    [HideFromJava]
    public abstract void glGetShaderPrecisionFormat(
      [In] int obj0,
      [In] int obj1,
      [In] IntBuffer obj2,
      [In] IntBuffer obj3);

    [HideFromJava]
    public abstract void glGetTexParameterfv([In] int obj0, [In] int obj1, [In] FloatBuffer obj2);

    [HideFromJava]
    public abstract void glGetTexParameteriv([In] int obj0, [In] int obj1, [In] IntBuffer obj2);

    [HideFromJava]
    public abstract void glGetUniformfv([In] int obj0, [In] int obj1, [In] FloatBuffer obj2);

    [HideFromJava]
    public abstract void glGetUniformiv([In] int obj0, [In] int obj1, [In] IntBuffer obj2);

    [HideFromJava]
    public abstract int glGetUniformLocation([In] int obj0, [In] string obj1);

    [HideFromJava]
    public abstract void glGetVertexAttribfv([In] int obj0, [In] int obj1, [In] FloatBuffer obj2);

    [HideFromJava]
    public abstract void glGetVertexAttribiv([In] int obj0, [In] int obj1, [In] IntBuffer obj2);

    [HideFromJava]
    public abstract bool glIsBuffer([In] int obj0);

    [HideFromJava]
    public abstract bool glIsEnabled([In] int obj0);

    [HideFromJava]
    public abstract bool glIsFramebuffer([In] int obj0);

    [HideFromJava]
    public abstract bool glIsProgram([In] int obj0);

    [HideFromJava]
    public abstract bool glIsRenderbuffer([In] int obj0);

    [HideFromJava]
    public abstract bool glIsShader([In] int obj0);

    [HideFromJava]
    public abstract bool glIsTexture([In] int obj0);

    [HideFromJava]
    public abstract void glLinkProgram([In] int obj0);

    [HideFromJava]
    public abstract void glReleaseShaderCompiler();

    [HideFromJava]
    public abstract void glRenderbufferStorage([In] int obj0, [In] int obj1, [In] int obj2, [In] int obj3);

    [HideFromJava]
    public abstract void glSampleCoverage([In] float obj0, [In] bool obj1);

    [HideFromJava]
    public abstract void glShaderSource([In] int obj0, [In] string obj1);

    [HideFromJava]
    public abstract void glStencilFuncSeparate([In] int obj0, [In] int obj1, [In] int obj2, [In] int obj3);

    [HideFromJava]
    public abstract void glStencilMaskSeparate([In] int obj0, [In] int obj1);

    [HideFromJava]
    public abstract void glStencilOpSeparate([In] int obj0, [In] int obj1, [In] int obj2, [In] int obj3);

    [HideFromJava]
    public abstract void glTexParameterfv([In] int obj0, [In] int obj1, [In] FloatBuffer obj2);

    [HideFromJava]
    public abstract void glTexParameteri([In] int obj0, [In] int obj1, [In] int obj2);

    [HideFromJava]
    public abstract void glTexParameteriv([In] int obj0, [In] int obj1, [In] IntBuffer obj2);

    [HideFromJava]
    public abstract void glUniform1f([In] int obj0, [In] float obj1);

    [HideFromJava]
    public abstract void glUniform1fv([In] int obj0, [In] int obj1, [In] FloatBuffer obj2);

    [HideFromJava]
    public abstract void glUniform1fv([In] int obj0, [In] int obj1, [In] float[] obj2, [In] int obj3);

    [HideFromJava]
    public abstract void glUniform1i([In] int obj0, [In] int obj1);

    [HideFromJava]
    public abstract void glUniform1iv([In] int obj0, [In] int obj1, [In] IntBuffer obj2);

    [HideFromJava]
    public abstract void glUniform1iv([In] int obj0, [In] int obj1, [In] int[] obj2, [In] int obj3);

    [HideFromJava]
    public abstract void glUniform2f([In] int obj0, [In] float obj1, [In] float obj2);

    [HideFromJava]
    public abstract void glUniform2fv([In] int obj0, [In] int obj1, [In] FloatBuffer obj2);

    [HideFromJava]
    public abstract void glUniform2fv([In] int obj0, [In] int obj1, [In] float[] obj2, [In] int obj3);

    [HideFromJava]
    public abstract void glUniform2i([In] int obj0, [In] int obj1, [In] int obj2);

    [HideFromJava]
    public abstract void glUniform2iv([In] int obj0, [In] int obj1, [In] IntBuffer obj2);

    [HideFromJava]
    public abstract void glUniform2iv([In] int obj0, [In] int obj1, [In] int[] obj2, [In] int obj3);

    [HideFromJava]
    public abstract void glUniform3f([In] int obj0, [In] float obj1, [In] float obj2, [In] float obj3);

    [HideFromJava]
    public abstract void glUniform3fv([In] int obj0, [In] int obj1, [In] FloatBuffer obj2);

    [HideFromJava]
    public abstract void glUniform3fv([In] int obj0, [In] int obj1, [In] float[] obj2, [In] int obj3);

    [HideFromJava]
    public abstract void glUniform3i([In] int obj0, [In] int obj1, [In] int obj2, [In] int obj3);

    [HideFromJava]
    public abstract void glUniform3iv([In] int obj0, [In] int obj1, [In] IntBuffer obj2);

    [HideFromJava]
    public abstract void glUniform3iv([In] int obj0, [In] int obj1, [In] int[] obj2, [In] int obj3);

    [HideFromJava]
    public abstract void glUniform4f([In] int obj0, [In] float obj1, [In] float obj2, [In] float obj3, [In] float obj4);

    [HideFromJava]
    public abstract void glUniform4fv([In] int obj0, [In] int obj1, [In] FloatBuffer obj2);

    [HideFromJava]
    public abstract void glUniform4fv([In] int obj0, [In] int obj1, [In] float[] obj2, [In] int obj3);

    [HideFromJava]
    public abstract void glUniform4i([In] int obj0, [In] int obj1, [In] int obj2, [In] int obj3, [In] int obj4);

    [HideFromJava]
    public abstract void glUniform4iv([In] int obj0, [In] int obj1, [In] IntBuffer obj2);

    [HideFromJava]
    public abstract void glUniform4iv([In] int obj0, [In] int obj1, [In] int[] obj2, [In] int obj3);

    [HideFromJava]
    public abstract void glUniformMatrix2fv([In] int obj0, [In] int obj1, [In] bool obj2, [In] FloatBuffer obj3);

    [HideFromJava]
    public abstract void glUniformMatrix2fv(
      [In] int obj0,
      [In] int obj1,
      [In] bool obj2,
      [In] float[] obj3,
      [In] int obj4);

    [HideFromJava]
    public abstract void glUniformMatrix3fv([In] int obj0, [In] int obj1, [In] bool obj2, [In] FloatBuffer obj3);

    [HideFromJava]
    public abstract void glUniformMatrix3fv(
      [In] int obj0,
      [In] int obj1,
      [In] bool obj2,
      [In] float[] obj3,
      [In] int obj4);

    [HideFromJava]
    public abstract void glUniformMatrix4fv([In] int obj0, [In] int obj1, [In] bool obj2, [In] FloatBuffer obj3);

    [HideFromJava]
    public abstract void glUniformMatrix4fv(
      [In] int obj0,
      [In] int obj1,
      [In] bool obj2,
      [In] float[] obj3,
      [In] int obj4);

    [HideFromJava]
    public abstract void glUseProgram([In] int obj0);

    [HideFromJava]
    public abstract void glValidateProgram([In] int obj0);

    [HideFromJava]
    public abstract void glVertexAttrib1f([In] int obj0, [In] float obj1);

    [HideFromJava]
    public abstract void glVertexAttrib1fv([In] int obj0, [In] FloatBuffer obj1);

    [HideFromJava]
    public abstract void glVertexAttrib2f([In] int obj0, [In] float obj1, [In] float obj2);

    [HideFromJava]
    public abstract void glVertexAttrib2fv([In] int obj0, [In] FloatBuffer obj1);

    [HideFromJava]
    public abstract void glVertexAttrib3f([In] int obj0, [In] float obj1, [In] float obj2, [In] float obj3);

    [HideFromJava]
    public abstract void glVertexAttrib3fv([In] int obj0, [In] FloatBuffer obj1);

    [HideFromJava]
    public abstract void glVertexAttrib4f(
      [In] int obj0,
      [In] float obj1,
      [In] float obj2,
      [In] float obj3,
      [In] float obj4);

    [HideFromJava]
    public abstract void glVertexAttrib4fv([In] int obj0, [In] FloatBuffer obj1);

    [HideFromJava]
    public abstract void glVertexAttribPointer(
      [In] int obj0,
      [In] int obj1,
      [In] int obj2,
      [In] bool obj3,
      [In] int obj4,
      [In] Buffer obj5);

    [HideFromJava]
    public abstract void glVertexAttribPointer(
      [In] int obj0,
      [In] int obj1,
      [In] int obj2,
      [In] bool obj3,
      [In] int obj4,
      [In] int obj5);

    [Modifiers]
    public FloatCounter vertexCount
    {
      [HideFromJava] get => this.__\u003C\u003EvertexCount;
      [HideFromJava] [param: In] private set => this.__\u003C\u003EvertexCount = value;
    }
  }
}
