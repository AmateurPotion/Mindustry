// Decompiled with JetBrains decompiler
// Type: arc.backend.sdl.jni.SDLGL
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.util;
using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.nio;
using System;
using System.Runtime.CompilerServices;

namespace arc.backend.sdl.jni
{
  public class SDLGL : Object
  {
    static IntPtr __\u003Cjniptr\u003Einit\u0028\u0029Ljava\u002Flang\u002FString\u003B;
    [SpecialName]
    private static CallerID __\u003CcallerID\u003E;
    static IntPtr __\u003Cjniptr\u003EglActiveTexture\u0028I\u0029V;
    static IntPtr __\u003Cjniptr\u003EglBindTexture\u0028II\u0029V;
    static IntPtr __\u003Cjniptr\u003EglBlendFunc\u0028II\u0029V;
    static IntPtr __\u003Cjniptr\u003EglClear\u0028I\u0029V;
    static IntPtr __\u003Cjniptr\u003EglClearColor\u0028FFFF\u0029V;
    static IntPtr __\u003Cjniptr\u003EglClearDepthf\u0028F\u0029V;
    static IntPtr __\u003Cjniptr\u003EglClearStencil\u0028I\u0029V;
    static IntPtr __\u003Cjniptr\u003EglColorMask\u0028ZZZZ\u0029V;
    static IntPtr __\u003Cjniptr\u003EglCompressedTexImage2D\u0028IIIIIIILjava\u002Fnio\u002FBuffer\u003B\u0029V;
    static IntPtr __\u003Cjniptr\u003EglCompressedTexSubImage2D\u0028IIIIIIIILjava\u002Fnio\u002FBuffer\u003B\u0029V;
    static IntPtr __\u003Cjniptr\u003EglCopyTexImage2D\u0028IIIIIIII\u0029V;
    static IntPtr __\u003Cjniptr\u003EglCopyTexSubImage2D\u0028IIIIIIII\u0029V;
    static IntPtr __\u003Cjniptr\u003EglCullFace\u0028I\u0029V;
    static IntPtr __\u003Cjniptr\u003EglDeleteTexture\u0028I\u0029V;
    static IntPtr __\u003Cjniptr\u003EglDepthFunc\u0028I\u0029V;
    static IntPtr __\u003Cjniptr\u003EglDepthMask\u0028Z\u0029V;
    static IntPtr __\u003Cjniptr\u003EglDepthRangef\u0028FF\u0029V;
    static IntPtr __\u003Cjniptr\u003EglDisable\u0028I\u0029V;
    static IntPtr __\u003Cjniptr\u003EglDrawArrays\u0028III\u0029V;
    static IntPtr __\u003Cjniptr\u003EglDrawElements\u0028IIILjava\u002Fnio\u002FBuffer\u003B\u0029V;
    static IntPtr __\u003Cjniptr\u003EglEnable\u0028I\u0029V;
    static IntPtr __\u003Cjniptr\u003EglFinish\u0028\u0029V;
    static IntPtr __\u003Cjniptr\u003EglFlush\u0028\u0029V;
    static IntPtr __\u003Cjniptr\u003EglFrontFace\u0028I\u0029V;
    static IntPtr __\u003Cjniptr\u003EglGenTexture\u0028\u0029I;
    static IntPtr __\u003Cjniptr\u003EglGetError\u0028\u0029I;
    static IntPtr __\u003Cjniptr\u003EglGetIntegerv\u0028ILjava\u002Fnio\u002FIntBuffer\u003B\u0029V;
    static IntPtr __\u003Cjniptr\u003EglGetString\u0028I\u0029Ljava\u002Flang\u002FString\u003B;
    static IntPtr __\u003Cjniptr\u003EglHint\u0028II\u0029V;
    static IntPtr __\u003Cjniptr\u003EglLineWidth\u0028F\u0029V;
    static IntPtr __\u003Cjniptr\u003EglPixelStorei\u0028II\u0029V;
    static IntPtr __\u003Cjniptr\u003EglPolygonOffset\u0028FF\u0029V;
    static IntPtr __\u003Cjniptr\u003EglReadPixels\u0028IIIIIILjava\u002Fnio\u002FBuffer\u003B\u0029V;
    static IntPtr __\u003Cjniptr\u003EglScissor\u0028IIII\u0029V;
    static IntPtr __\u003Cjniptr\u003EglStencilFunc\u0028III\u0029V;
    static IntPtr __\u003Cjniptr\u003EglStencilMask\u0028I\u0029V;
    static IntPtr __\u003Cjniptr\u003EglStencilOp\u0028III\u0029V;
    static IntPtr __\u003Cjniptr\u003EglTexImage2D\u0028IIIIIIIILjava\u002Fnio\u002FBuffer\u003B\u0029V;
    static IntPtr __\u003Cjniptr\u003EglTexParameterf\u0028IIF\u0029V;
    static IntPtr __\u003Cjniptr\u003EglTexSubImage2D\u0028IIIIIIIILjava\u002Fnio\u002FBuffer\u003B\u0029V;
    static IntPtr __\u003Cjniptr\u003EglViewport\u0028IIII\u0029V;
    static IntPtr __\u003Cjniptr\u003EglAttachShader\u0028II\u0029V;
    static IntPtr __\u003Cjniptr\u003EglBindAttribLocation\u0028IILjava\u002Flang\u002FString\u003B\u0029V;
    static IntPtr __\u003Cjniptr\u003EglBindBuffer\u0028II\u0029V;
    static IntPtr __\u003Cjniptr\u003EglBindFramebuffer\u0028II\u0029V;
    static IntPtr __\u003Cjniptr\u003EglBindRenderbuffer\u0028II\u0029V;
    static IntPtr __\u003Cjniptr\u003EglBlendColor\u0028FFFF\u0029V;
    static IntPtr __\u003Cjniptr\u003EglBlendEquation\u0028I\u0029V;
    static IntPtr __\u003Cjniptr\u003EglBlendEquationSeparate\u0028II\u0029V;
    static IntPtr __\u003Cjniptr\u003EglBlendFuncSeparate\u0028IIII\u0029V;
    static IntPtr __\u003Cjniptr\u003EglBufferData\u0028IILjava\u002Fnio\u002FBuffer\u003BI\u0029V;
    static IntPtr __\u003Cjniptr\u003EglBufferSubData\u0028IIILjava\u002Fnio\u002FBuffer\u003B\u0029V;
    static IntPtr __\u003Cjniptr\u003EglCheckFramebufferStatus\u0028I\u0029I;
    static IntPtr __\u003Cjniptr\u003EglCompileShader\u0028I\u0029V;
    static IntPtr __\u003Cjniptr\u003EglCreateProgram\u0028\u0029I;
    static IntPtr __\u003Cjniptr\u003EglCreateShader\u0028I\u0029I;
    static IntPtr __\u003Cjniptr\u003EglDeleteBuffer\u0028I\u0029V;
    static IntPtr __\u003Cjniptr\u003EglDeleteFramebuffer\u0028I\u0029V;
    static IntPtr __\u003Cjniptr\u003EglDeleteProgram\u0028I\u0029V;
    static IntPtr __\u003Cjniptr\u003EglDeleteRenderbuffer\u0028I\u0029V;
    static IntPtr __\u003Cjniptr\u003EglDeleteShader\u0028I\u0029V;
    static IntPtr __\u003Cjniptr\u003EglDetachShader\u0028II\u0029V;
    static IntPtr __\u003Cjniptr\u003EglDisableVertexAttribArray\u0028I\u0029V;
    static IntPtr __\u003Cjniptr\u003EglDrawElements\u0028IIII\u0029V;
    static IntPtr __\u003Cjniptr\u003EglEnableVertexAttribArray\u0028I\u0029V;
    static IntPtr __\u003Cjniptr\u003EglFramebufferRenderbuffer\u0028IIII\u0029V;
    static IntPtr __\u003Cjniptr\u003EglFramebufferTexture2D\u0028IIIII\u0029V;
    static IntPtr __\u003Cjniptr\u003EglGenBuffer\u0028\u0029I;
    static IntPtr __\u003Cjniptr\u003EglGenerateMipmap\u0028I\u0029V;
    static IntPtr __\u003Cjniptr\u003EglGenFramebuffer\u0028\u0029I;
    static IntPtr __\u003Cjniptr\u003EglGenRenderbuffer\u0028\u0029I;
    static IntPtr __\u003Cjniptr\u003EglGetActiveAttrib\u0028IILjava\u002Flang\u002FObject\u003BLjava\u002Flang\u002FObject\u003B\u0029Ljava\u002Flang\u002FString\u003B;
    static IntPtr __\u003Cjniptr\u003EglGetActiveUniform\u0028IILjava\u002Flang\u002FObject\u003BLjava\u002Flang\u002FObject\u003B\u0029Ljava\u002Flang\u002FString\u003B;
    static IntPtr __\u003Cjniptr\u003EglGetAttribLocation\u0028ILjava\u002Flang\u002FString\u003B\u0029I;
    static IntPtr __\u003Cjniptr\u003EglGetBooleanv\u0028ILjava\u002Fnio\u002FBuffer\u003B\u0029V;
    static IntPtr __\u003Cjniptr\u003EglGetBufferParameteriv\u0028IILjava\u002Fnio\u002FIntBuffer\u003B\u0029V;
    static IntPtr __\u003Cjniptr\u003EglGetFloatv\u0028ILjava\u002Fnio\u002FFloatBuffer\u003B\u0029V;
    static IntPtr __\u003Cjniptr\u003EglGetFramebufferAttachmentParameteriv\u0028IIILjava\u002Fnio\u002FIntBuffer\u003B\u0029V;
    static IntPtr __\u003Cjniptr\u003EglGetProgramiv\u0028IILjava\u002Fnio\u002FIntBuffer\u003B\u0029V;
    static IntPtr __\u003Cjniptr\u003EglGetProgramInfoLog\u0028I\u0029Ljava\u002Flang\u002FString\u003B;
    static IntPtr __\u003Cjniptr\u003EglGetRenderbufferParameteriv\u0028IILjava\u002Fnio\u002FIntBuffer\u003B\u0029V;
    static IntPtr __\u003Cjniptr\u003EglGetShaderiv\u0028IILjava\u002Fnio\u002FIntBuffer\u003B\u0029V;
    static IntPtr __\u003Cjniptr\u003EglGetShaderInfoLog\u0028I\u0029Ljava\u002Flang\u002FString\u003B;
    static IntPtr __\u003Cjniptr\u003EglGetShaderPrecisionFormat\u0028IILjava\u002Fnio\u002FIntBuffer\u003BLjava\u002Fnio\u002FIntBuffer\u003B\u0029V;
    static IntPtr __\u003Cjniptr\u003EglGetTexParameterfv\u0028IILjava\u002Fnio\u002FFloatBuffer\u003B\u0029V;
    static IntPtr __\u003Cjniptr\u003EglGetTexParameteriv\u0028IILjava\u002Fnio\u002FIntBuffer\u003B\u0029V;
    static IntPtr __\u003Cjniptr\u003EglGetUniformfv\u0028IILjava\u002Fnio\u002FFloatBuffer\u003B\u0029V;
    static IntPtr __\u003Cjniptr\u003EglGetUniformiv\u0028IILjava\u002Fnio\u002FIntBuffer\u003B\u0029V;
    static IntPtr __\u003Cjniptr\u003EglGetUniformLocation\u0028ILjava\u002Flang\u002FString\u003B\u0029I;
    static IntPtr __\u003Cjniptr\u003EglGetVertexAttribfv\u0028IILjava\u002Fnio\u002FFloatBuffer\u003B\u0029V;
    static IntPtr __\u003Cjniptr\u003EglGetVertexAttribiv\u0028IILjava\u002Fnio\u002FIntBuffer\u003B\u0029V;
    static IntPtr __\u003Cjniptr\u003EglIsBuffer\u0028I\u0029Z;
    static IntPtr __\u003Cjniptr\u003EglIsEnabled\u0028I\u0029Z;
    static IntPtr __\u003Cjniptr\u003EglIsFramebuffer\u0028I\u0029Z;
    static IntPtr __\u003Cjniptr\u003EglIsProgram\u0028I\u0029Z;
    static IntPtr __\u003Cjniptr\u003EglIsRenderbuffer\u0028I\u0029Z;
    static IntPtr __\u003Cjniptr\u003EglIsShader\u0028I\u0029Z;
    static IntPtr __\u003Cjniptr\u003EglIsTexture\u0028I\u0029Z;
    static IntPtr __\u003Cjniptr\u003EglLinkProgram\u0028I\u0029V;
    static IntPtr __\u003Cjniptr\u003EglReleaseShaderCompiler\u0028\u0029V;
    static IntPtr __\u003Cjniptr\u003EglRenderbufferStorage\u0028IIII\u0029V;
    static IntPtr __\u003Cjniptr\u003EglSampleCoverage\u0028FZ\u0029V;
    static IntPtr __\u003Cjniptr\u003EglShaderSource\u0028ILjava\u002Flang\u002FString\u003B\u0029V;
    static IntPtr __\u003Cjniptr\u003EglStencilFuncSeparate\u0028IIII\u0029V;
    static IntPtr __\u003Cjniptr\u003EglStencilMaskSeparate\u0028II\u0029V;
    static IntPtr __\u003Cjniptr\u003EglStencilOpSeparate\u0028IIII\u0029V;
    static IntPtr __\u003Cjniptr\u003EglTexParameterfv\u0028IILjava\u002Fnio\u002FFloatBuffer\u003B\u0029V;
    static IntPtr __\u003Cjniptr\u003EglTexParameteri\u0028III\u0029V;
    static IntPtr __\u003Cjniptr\u003EglTexParameteriv\u0028IILjava\u002Fnio\u002FIntBuffer\u003B\u0029V;
    static IntPtr __\u003Cjniptr\u003EglUniform1f\u0028IF\u0029V;
    static IntPtr __\u003Cjniptr\u003EglUniform1fv\u0028IILjava\u002Fnio\u002FFloatBuffer\u003B\u0029V;
    static IntPtr __\u003Cjniptr\u003EglUniform1fv\u0028II\u005BFI\u0029V;
    static IntPtr __\u003Cjniptr\u003EglUniform1i\u0028II\u0029V;
    static IntPtr __\u003Cjniptr\u003EglUniform1iv\u0028IILjava\u002Fnio\u002FIntBuffer\u003B\u0029V;
    static IntPtr __\u003Cjniptr\u003EglUniform1iv\u0028II\u005BII\u0029V;
    static IntPtr __\u003Cjniptr\u003EglUniform2f\u0028IFF\u0029V;
    static IntPtr __\u003Cjniptr\u003EglUniform2fv\u0028IILjava\u002Fnio\u002FFloatBuffer\u003B\u0029V;
    static IntPtr __\u003Cjniptr\u003EglUniform2fv\u0028II\u005BFI\u0029V;
    static IntPtr __\u003Cjniptr\u003EglUniform2i\u0028III\u0029V;
    static IntPtr __\u003Cjniptr\u003EglUniform2iv\u0028IILjava\u002Fnio\u002FIntBuffer\u003B\u0029V;
    static IntPtr __\u003Cjniptr\u003EglUniform2iv\u0028II\u005BII\u0029V;
    static IntPtr __\u003Cjniptr\u003EglUniform3f\u0028IFFF\u0029V;
    static IntPtr __\u003Cjniptr\u003EglUniform3fv\u0028IILjava\u002Fnio\u002FFloatBuffer\u003B\u0029V;
    static IntPtr __\u003Cjniptr\u003EglUniform3fv\u0028II\u005BFI\u0029V;
    static IntPtr __\u003Cjniptr\u003EglUniform3i\u0028IIII\u0029V;
    static IntPtr __\u003Cjniptr\u003EglUniform3iv\u0028IILjava\u002Fnio\u002FIntBuffer\u003B\u0029V;
    static IntPtr __\u003Cjniptr\u003EglUniform3iv\u0028II\u005BII\u0029V;
    static IntPtr __\u003Cjniptr\u003EglUniform4f\u0028IFFFF\u0029V;
    static IntPtr __\u003Cjniptr\u003EglUniform4fv\u0028IILjava\u002Fnio\u002FFloatBuffer\u003B\u0029V;
    static IntPtr __\u003Cjniptr\u003EglUniform4fv\u0028II\u005BFI\u0029V;
    static IntPtr __\u003Cjniptr\u003EglUniform4i\u0028IIIII\u0029V;
    static IntPtr __\u003Cjniptr\u003EglUniform4iv\u0028IILjava\u002Fnio\u002FIntBuffer\u003B\u0029V;
    static IntPtr __\u003Cjniptr\u003EglUniform4iv\u0028II\u005BII\u0029V;
    static IntPtr __\u003Cjniptr\u003EglUniformMatrix2fv\u0028IIZLjava\u002Fnio\u002FFloatBuffer\u003B\u0029V;
    static IntPtr __\u003Cjniptr\u003EglUniformMatrix2fv\u0028IIZ\u005BFI\u0029V;
    static IntPtr __\u003Cjniptr\u003EglUniformMatrix3fv\u0028IIZLjava\u002Fnio\u002FFloatBuffer\u003B\u0029V;
    static IntPtr __\u003Cjniptr\u003EglUniformMatrix3fv\u0028IIZ\u005BFI\u0029V;
    static IntPtr __\u003Cjniptr\u003EglUniformMatrix4fv\u0028IIZLjava\u002Fnio\u002FFloatBuffer\u003B\u0029V;
    static IntPtr __\u003Cjniptr\u003EglUniformMatrix4fv\u0028IIZ\u005BFI\u0029V;
    static IntPtr __\u003Cjniptr\u003EglUseProgram\u0028I\u0029V;
    static IntPtr __\u003Cjniptr\u003EglValidateProgram\u0028I\u0029V;
    static IntPtr __\u003Cjniptr\u003EglVertexAttrib1f\u0028IF\u0029V;
    static IntPtr __\u003Cjniptr\u003EglVertexAttrib1fv\u0028ILjava\u002Fnio\u002FFloatBuffer\u003B\u0029V;
    static IntPtr __\u003Cjniptr\u003EglVertexAttrib2f\u0028IFF\u0029V;
    static IntPtr __\u003Cjniptr\u003EglVertexAttrib2fv\u0028ILjava\u002Fnio\u002FFloatBuffer\u003B\u0029V;
    static IntPtr __\u003Cjniptr\u003EglVertexAttrib3f\u0028IFFF\u0029V;
    static IntPtr __\u003Cjniptr\u003EglVertexAttrib3fv\u0028ILjava\u002Fnio\u002FFloatBuffer\u003B\u0029V;
    static IntPtr __\u003Cjniptr\u003EglVertexAttrib4f\u0028IFFFF\u0029V;
    static IntPtr __\u003Cjniptr\u003EglVertexAttrib4fv\u0028ILjava\u002Fnio\u002FFloatBuffer\u003B\u0029V;
    static IntPtr __\u003Cjniptr\u003EglVertexAttribPointer\u0028IIIZILjava\u002Flang\u002FObject\u003B\u0029V;
    static IntPtr __\u003Cjniptr\u003EglVertexAttribPointer\u0028IIIZII\u0029V;
    static IntPtr __\u003Cjniptr\u003EglReadBuffer\u0028I\u0029V;
    static IntPtr __\u003Cjniptr\u003EglDrawRangeElements\u0028IIIIII\u0029V;
    static IntPtr __\u003Cjniptr\u003EglDrawRangeElements\u0028IIIIILjava\u002Fnio\u002FBuffer\u003B\u0029V;
    static IntPtr __\u003Cjniptr\u003EglTexImage3D\u0028IIIIIIIIII\u0029V;
    static IntPtr __\u003Cjniptr\u003EglTexImage3D\u0028IIIIIIIIILjava\u002Fnio\u002FBuffer\u003B\u0029V;
    static IntPtr __\u003Cjniptr\u003EglTexSubImage3D\u0028IIIIIIIIIII\u0029V;
    static IntPtr __\u003Cjniptr\u003EglTexSubImage3D\u0028IIIIIIIIIILjava\u002Fnio\u002FBuffer\u003B\u0029V;
    static IntPtr __\u003Cjniptr\u003EglCopyTexSubImage3D\u0028IIIIIIIII\u0029V;
    static IntPtr __\u003Cjniptr\u003EglGenQueries\u0028ILjava\u002Fnio\u002FIntBuffer\u003B\u0029V;
    static IntPtr __\u003Cjniptr\u003EglDeleteQueries\u0028ILjava\u002Fnio\u002FIntBuffer\u003B\u0029V;
    static IntPtr __\u003Cjniptr\u003EglIsQuery\u0028I\u0029Z;
    static IntPtr __\u003Cjniptr\u003EglBeginQuery\u0028II\u0029V;
    static IntPtr __\u003Cjniptr\u003EglEndQuery\u0028I\u0029V;
    static IntPtr __\u003Cjniptr\u003EglGetQueryiv\u0028IILjava\u002Fnio\u002FIntBuffer\u003B\u0029V;
    static IntPtr __\u003Cjniptr\u003EglGetQueryObjectuiv\u0028IILjava\u002Fnio\u002FIntBuffer\u003B\u0029V;
    static IntPtr __\u003Cjniptr\u003EglUnmapBuffer\u0028I\u0029Z;
    static IntPtr __\u003Cjniptr\u003EglGetBufferPointerv\u0028II\u0029Ljava\u002Fnio\u002FBuffer\u003B;
    static IntPtr __\u003Cjniptr\u003EglDrawBuffers\u0028ILjava\u002Fnio\u002FIntBuffer\u003B\u0029V;
    static IntPtr __\u003Cjniptr\u003EglUniformMatrix2x3fv\u0028IIZLjava\u002Fnio\u002FFloatBuffer\u003B\u0029V;
    static IntPtr __\u003Cjniptr\u003EglUniformMatrix3x2fv\u0028IIZLjava\u002Fnio\u002FFloatBuffer\u003B\u0029V;
    static IntPtr __\u003Cjniptr\u003EglUniformMatrix2x4fv\u0028IIZLjava\u002Fnio\u002FFloatBuffer\u003B\u0029V;
    static IntPtr __\u003Cjniptr\u003EglUniformMatrix4x2fv\u0028IIZLjava\u002Fnio\u002FFloatBuffer\u003B\u0029V;
    static IntPtr __\u003Cjniptr\u003EglUniformMatrix3x4fv\u0028IIZLjava\u002Fnio\u002FFloatBuffer\u003B\u0029V;
    static IntPtr __\u003Cjniptr\u003EglUniformMatrix4x3fv\u0028IIZLjava\u002Fnio\u002FFloatBuffer\u003B\u0029V;
    static IntPtr __\u003Cjniptr\u003EglBlitFramebuffer\u0028IIIIIIIIII\u0029V;
    static IntPtr __\u003Cjniptr\u003EglRenderbufferStorageMultisample\u0028IIIII\u0029V;
    static IntPtr __\u003Cjniptr\u003EglFramebufferTextureLayer\u0028IIIII\u0029V;
    static IntPtr __\u003Cjniptr\u003EglFlushMappedBufferRange\u0028III\u0029V;
    static IntPtr __\u003Cjniptr\u003EglBindVertexArray\u0028I\u0029V;
    static IntPtr __\u003Cjniptr\u003EglDeleteVertexArrays\u0028ILjava\u002Fnio\u002FIntBuffer\u003B\u0029V;
    static IntPtr __\u003Cjniptr\u003EglGenVertexArrays\u0028ILjava\u002Fnio\u002FIntBuffer\u003B\u0029V;
    static IntPtr __\u003Cjniptr\u003EglIsVertexArray\u0028I\u0029Z;
    static IntPtr __\u003Cjniptr\u003EglBeginTransformFeedback\u0028I\u0029V;
    static IntPtr __\u003Cjniptr\u003EglEndTransformFeedback\u0028\u0029V;
    static IntPtr __\u003Cjniptr\u003EglBindBufferRange\u0028IIIII\u0029V;
    static IntPtr __\u003Cjniptr\u003EglBindBufferBase\u0028III\u0029V;
    static IntPtr __\u003Cjniptr\u003EglTransformFeedbackVaryings\u0028I\u005BLjava\u002Flang\u002FString\u003BI\u0029V;
    static IntPtr __\u003Cjniptr\u003EglVertexAttribIPointer\u0028IIIII\u0029V;
    static IntPtr __\u003Cjniptr\u003EglGetVertexAttribIiv\u0028IILjava\u002Fnio\u002FIntBuffer\u003B\u0029V;
    static IntPtr __\u003Cjniptr\u003EglGetVertexAttribIuiv\u0028IILjava\u002Fnio\u002FIntBuffer\u003B\u0029V;
    static IntPtr __\u003Cjniptr\u003EglVertexAttribI4i\u0028IIIII\u0029V;
    static IntPtr __\u003Cjniptr\u003EglVertexAttribI4ui\u0028IIIII\u0029V;
    static IntPtr __\u003Cjniptr\u003EglGetUniformuiv\u0028IILjava\u002Fnio\u002FIntBuffer\u003B\u0029V;
    static IntPtr __\u003Cjniptr\u003EglGetFragDataLocation\u0028ILjava\u002Flang\u002FString\u003B\u0029I;
    static IntPtr __\u003Cjniptr\u003EglUniform1uiv\u0028IILjava\u002Fnio\u002FIntBuffer\u003B\u0029V;
    static IntPtr __\u003Cjniptr\u003EglUniform3uiv\u0028IILjava\u002Fnio\u002FIntBuffer\u003B\u0029V;
    static IntPtr __\u003Cjniptr\u003EglUniform4uiv\u0028IILjava\u002Fnio\u002FIntBuffer\u003B\u0029V;
    static IntPtr __\u003Cjniptr\u003EglClearBufferiv\u0028IILjava\u002Fnio\u002FIntBuffer\u003B\u0029V;
    static IntPtr __\u003Cjniptr\u003EglClearBufferuiv\u0028IILjava\u002Fnio\u002FIntBuffer\u003B\u0029V;
    static IntPtr __\u003Cjniptr\u003EglClearBufferfv\u0028IILjava\u002Fnio\u002FFloatBuffer\u003B\u0029V;
    static IntPtr __\u003Cjniptr\u003EglClearBufferfi\u0028IIFI\u0029V;
    static IntPtr __\u003Cjniptr\u003EglGetStringi\u0028II\u0029Ljava\u002Flang\u002FString\u003B;
    static IntPtr __\u003Cjniptr\u003EglCopyBufferSubData\u0028IIIII\u0029V;
    static IntPtr __\u003Cjniptr\u003EglGetUniformIndices\u0028I\u005BLjava\u002Flang\u002FString\u003BLjava\u002Fnio\u002FIntBuffer\u003B\u0029V;
    static IntPtr __\u003Cjniptr\u003EglGetActiveUniformsiv\u0028IILjava\u002Fnio\u002FIntBuffer\u003BILjava\u002Fnio\u002FIntBuffer\u003B\u0029V;
    static IntPtr __\u003Cjniptr\u003EglGetUniformBlockIndex\u0028ILjava\u002Flang\u002FString\u003B\u0029I;
    static IntPtr __\u003Cjniptr\u003EglGetActiveUniformBlockiv\u0028IIILjava\u002Fnio\u002FIntBuffer\u003B\u0029V;
    static IntPtr __\u003Cjniptr\u003EglGetActiveUniformBlockName\u0028IILjava\u002Fnio\u002FBuffer\u003BLjava\u002Fnio\u002FBuffer\u003B\u0029V;
    static IntPtr __\u003Cjniptr\u003EglUniformBlockBinding\u0028III\u0029V;
    static IntPtr __\u003Cjniptr\u003EglDrawArraysInstanced\u0028IIII\u0029V;
    static IntPtr __\u003Cjniptr\u003EglDrawElementsInstanced\u0028IIIII\u0029V;
    static IntPtr __\u003Cjniptr\u003EglGetInteger64v\u0028ILjava\u002Fnio\u002FLongBuffer\u003B\u0029V;
    static IntPtr __\u003Cjniptr\u003EglGetBufferParameteri64v\u0028IILjava\u002Fnio\u002FLongBuffer\u003B\u0029V;
    static IntPtr __\u003Cjniptr\u003EglGenSamplers\u0028ILjava\u002Fnio\u002FIntBuffer\u003B\u0029V;
    static IntPtr __\u003Cjniptr\u003EglDeleteSamplers\u0028ILjava\u002Fnio\u002FIntBuffer\u003B\u0029V;
    static IntPtr __\u003Cjniptr\u003EglIsSampler\u0028I\u0029Z;
    static IntPtr __\u003Cjniptr\u003EglBindSampler\u0028II\u0029V;
    static IntPtr __\u003Cjniptr\u003EglSamplerParameteri\u0028III\u0029V;
    static IntPtr __\u003Cjniptr\u003EglSamplerParameteriv\u0028IILjava\u002Fnio\u002FIntBuffer\u003B\u0029V;
    static IntPtr __\u003Cjniptr\u003EglSamplerParameterf\u0028IIF\u0029V;
    static IntPtr __\u003Cjniptr\u003EglSamplerParameterfv\u0028IILjava\u002Fnio\u002FFloatBuffer\u003B\u0029V;
    static IntPtr __\u003Cjniptr\u003EglGetSamplerParameteriv\u0028IILjava\u002Fnio\u002FIntBuffer\u003B\u0029V;
    static IntPtr __\u003Cjniptr\u003EglGetSamplerParameterfv\u0028IILjava\u002Fnio\u002FFloatBuffer\u003B\u0029V;
    static IntPtr __\u003Cjniptr\u003EglVertexAttribDivisor\u0028II\u0029V;
    static IntPtr __\u003Cjniptr\u003EglBindTransformFeedback\u0028II\u0029V;
    static IntPtr __\u003Cjniptr\u003EglDeleteTransformFeedbacks\u0028ILjava\u002Fnio\u002FIntBuffer\u003B\u0029V;
    static IntPtr __\u003Cjniptr\u003EglGenTransformFeedbacks\u0028ILjava\u002Fnio\u002FIntBuffer\u003B\u0029V;
    static IntPtr __\u003Cjniptr\u003EglIsTransformFeedback\u0028I\u0029Z;
    static IntPtr __\u003Cjniptr\u003EglPauseTransformFeedback\u0028\u0029V;
    static IntPtr __\u003Cjniptr\u003EglResumeTransformFeedback\u0028\u0029V;
    static IntPtr __\u003Cjniptr\u003EglProgramParameteri\u0028III\u0029V;
    static IntPtr __\u003Cjniptr\u003EglInvalidateFramebuffer\u0028IILjava\u002Fnio\u002FIntBuffer\u003B\u0029V;
    static IntPtr __\u003Cjniptr\u003EglInvalidateSubFramebuffer\u0028IILjava\u002Fnio\u002FIntBuffer\u003BIIII\u0029V;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [Modifiers]
    public static void glActiveTexture(int i)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglActiveTexture\u0028I\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglActiveTexture\u0028I\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glActiveTexture), "(I)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int)>) SDLGL.__\u003Cjniptr\u003EglActiveTexture\u0028I\u0029V)((int) num2, num3, (IntPtr) num4);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glBindTexture(int i1, int i2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglBindTexture\u0028II\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglBindTexture\u0028II\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glBindTexture), "(II)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i1;
        int num5 = i2;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, int)>) SDLGL.__\u003Cjniptr\u003EglBindTexture\u0028II\u0029V)((int) num2, (int) num3, (IntPtr) num4, (IntPtr) num5);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glBlendFunc(int i1, int i2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglBlendFunc\u0028II\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglBlendFunc\u0028II\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glBlendFunc), "(II)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i1;
        int num5 = i2;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, int)>) SDLGL.__\u003Cjniptr\u003EglBlendFunc\u0028II\u0029V)((int) num2, (int) num3, (IntPtr) num4, (IntPtr) num5);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glClear(int i)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglClear\u0028I\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglClear\u0028I\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glClear), "(I)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int)>) SDLGL.__\u003Cjniptr\u003EglClear\u0028I\u0029V)((int) num2, num3, (IntPtr) num4);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glClearColor(float f1, float f2, float f3, float f4)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglClearColor\u0028FFFF\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglClearColor\u0028FFFF\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glClearColor), "(FFFF)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        double num4 = (double) f1;
        double num5 = (double) f2;
        double num6 = (double) f3;
        double num7 = (double) f4;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, float, float, float, float)>) SDLGL.__\u003Cjniptr\u003EglClearColor\u0028FFFF\u0029V)((float) num2, (float) num3, (float) num4, (float) num5, (IntPtr) num6, (IntPtr) num7);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glClearDepthf(float f)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglClearDepthf\u0028F\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglClearDepthf\u0028F\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glClearDepthf), "(F)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        double num4 = (double) f;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, float)>) SDLGL.__\u003Cjniptr\u003EglClearDepthf\u0028F\u0029V)((float) num2, num3, (IntPtr) num4);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glClearStencil(int i)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglClearStencil\u0028I\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglClearStencil\u0028I\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glClearStencil), "(I)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int)>) SDLGL.__\u003Cjniptr\u003EglClearStencil\u0028I\u0029V)((int) num2, num3, (IntPtr) num4);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glColorMask(bool b1, bool b2, bool b3, bool b4)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglColorMask\u0028ZZZZ\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglColorMask\u0028ZZZZ\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glColorMask), "(ZZZZ)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = b1 ? 1 : 0;
        int num5 = b2 ? 1 : 0;
        int num6 = b3 ? 1 : 0;
        int num7 = b4 ? 1 : 0;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, bool, bool, bool, bool)>) SDLGL.__\u003Cjniptr\u003EglColorMask\u0028ZZZZ\u0029V)((bool) num2, (bool) num3, num4 != 0, num5 != 0, (IntPtr) num6, (IntPtr) num7);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glCompressedTexImage2D(
      int i1,
      int i2,
      int i3,
      int i4,
      int i5,
      int i6,
      int i7,
      Buffer b)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglCompressedTexImage2D\u0028IIIIIIILjava\u002Fnio\u002FBuffer\u003B\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglCompressedTexImage2D\u0028IIIIIIILjava\u002Fnio\u002FBuffer\u003B\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glCompressedTexImage2D), "(IIIIIIILjava/nio/Buffer;)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i1;
        int num5 = i2;
        int num6 = i3;
        int num7 = i4;
        int num8 = i5;
        int num9 = i6;
        int num10 = i7;
        IntPtr num11 = ((JNI.Frame) ref frame).MakeLocalRef((object) b);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, int, int, int, int, int, int, IntPtr)>) SDLGL.__\u003Cjniptr\u003EglCompressedTexImage2D\u0028IIIIIIILjava\u002Fnio\u002FBuffer\u003B\u0029V)(num2, (int) num3, num4, num5, num6, num7, num8, num9, (IntPtr) num10, num11);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glCompressedTexSubImage2D(
      int i1,
      int i2,
      int i3,
      int i4,
      int i5,
      int i6,
      int i7,
      int i8,
      Buffer b)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglCompressedTexSubImage2D\u0028IIIIIIIILjava\u002Fnio\u002FBuffer\u003B\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglCompressedTexSubImage2D\u0028IIIIIIIILjava\u002Fnio\u002FBuffer\u003B\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glCompressedTexSubImage2D), "(IIIIIIIILjava/nio/Buffer;)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i1;
        int num5 = i2;
        int num6 = i3;
        int num7 = i4;
        int num8 = i5;
        int num9 = i6;
        int num10 = i7;
        int num11 = i8;
        IntPtr num12 = ((JNI.Frame) ref frame).MakeLocalRef((object) b);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, int, int, int, int, int, int, int, IntPtr)>) SDLGL.__\u003Cjniptr\u003EglCompressedTexSubImage2D\u0028IIIIIIIILjava\u002Fnio\u002FBuffer\u003B\u0029V)(num2, (int) num3, num4, num5, num6, num7, num8, num9, num10, (IntPtr) num11, num12);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glCopyTexImage2D(
      int i1,
      int i2,
      int i3,
      int i4,
      int i5,
      int i6,
      int i7,
      int i8)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglCopyTexImage2D\u0028IIIIIIII\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglCopyTexImage2D\u0028IIIIIIII\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glCopyTexImage2D), "(IIIIIIII)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i1;
        int num5 = i2;
        int num6 = i3;
        int num7 = i4;
        int num8 = i5;
        int num9 = i6;
        int num10 = i7;
        int num11 = i8;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, int, int, int, int, int, int, int)>) SDLGL.__\u003Cjniptr\u003EglCopyTexImage2D\u0028IIIIIIII\u0029V)((int) num2, (int) num3, num4, num5, num6, num7, num8, num9, (IntPtr) num10, (IntPtr) num11);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glCopyTexSubImage2D(
      int i1,
      int i2,
      int i3,
      int i4,
      int i5,
      int i6,
      int i7,
      int i8)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglCopyTexSubImage2D\u0028IIIIIIII\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglCopyTexSubImage2D\u0028IIIIIIII\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glCopyTexSubImage2D), "(IIIIIIII)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i1;
        int num5 = i2;
        int num6 = i3;
        int num7 = i4;
        int num8 = i5;
        int num9 = i6;
        int num10 = i7;
        int num11 = i8;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, int, int, int, int, int, int, int)>) SDLGL.__\u003Cjniptr\u003EglCopyTexSubImage2D\u0028IIIIIIII\u0029V)((int) num2, (int) num3, num4, num5, num6, num7, num8, num9, (IntPtr) num10, (IntPtr) num11);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glCullFace(int i)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglCullFace\u0028I\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglCullFace\u0028I\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glCullFace), "(I)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int)>) SDLGL.__\u003Cjniptr\u003EglCullFace\u0028I\u0029V)((int) num2, num3, (IntPtr) num4);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glDeleteTexture(int i)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglDeleteTexture\u0028I\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglDeleteTexture\u0028I\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glDeleteTexture), "(I)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int)>) SDLGL.__\u003Cjniptr\u003EglDeleteTexture\u0028I\u0029V)((int) num2, num3, (IntPtr) num4);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glDepthFunc(int i)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglDepthFunc\u0028I\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglDepthFunc\u0028I\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glDepthFunc), "(I)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int)>) SDLGL.__\u003Cjniptr\u003EglDepthFunc\u0028I\u0029V)((int) num2, num3, (IntPtr) num4);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glDepthMask(bool b)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglDepthMask\u0028Z\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglDepthMask\u0028Z\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glDepthMask), "(Z)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = b ? 1 : 0;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, bool)>) SDLGL.__\u003Cjniptr\u003EglDepthMask\u0028Z\u0029V)((bool) num2, num3, (IntPtr) num4);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glDepthRangef(float f1, float f2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglDepthRangef\u0028FF\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglDepthRangef\u0028FF\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glDepthRangef), "(FF)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        double num4 = (double) f1;
        double num5 = (double) f2;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, float, float)>) SDLGL.__\u003Cjniptr\u003EglDepthRangef\u0028FF\u0029V)((float) num2, (float) num3, (IntPtr) num4, (IntPtr) num5);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glDisable(int i)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglDisable\u0028I\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglDisable\u0028I\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glDisable), "(I)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int)>) SDLGL.__\u003Cjniptr\u003EglDisable\u0028I\u0029V)((int) num2, num3, (IntPtr) num4);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glDrawArrays(int i1, int i2, int i3)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglDrawArrays\u0028III\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglDrawArrays\u0028III\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glDrawArrays), "(III)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i1;
        int num5 = i2;
        int num6 = i3;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, int, int)>) SDLGL.__\u003Cjniptr\u003EglDrawArrays\u0028III\u0029V)((int) num2, (int) num3, num4, (IntPtr) num5, (IntPtr) num6);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glDrawElements(int i1, int i2, int i3, Buffer b)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglDrawElements\u0028IIILjava\u002Fnio\u002FBuffer\u003B\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglDrawElements\u0028IIILjava\u002Fnio\u002FBuffer\u003B\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glDrawElements), "(IIILjava/nio/Buffer;)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i1;
        int num5 = i2;
        int num6 = i3;
        IntPtr num7 = ((JNI.Frame) ref frame).MakeLocalRef((object) b);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, int, int, IntPtr)>) SDLGL.__\u003Cjniptr\u003EglDrawElements\u0028IIILjava\u002Fnio\u002FBuffer\u003B\u0029V)(num2, (int) num3, num4, num5, (IntPtr) num6, num7);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glEnable(int i)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglEnable\u0028I\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglEnable\u0028I\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glEnable), "(I)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int)>) SDLGL.__\u003Cjniptr\u003EglEnable\u0028I\u0029V)((int) num2, num3, (IntPtr) num4);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glFinish()
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglFinish\u0028\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglFinish\u0028\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glFinish), "()V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr)>) SDLGL.__\u003Cjniptr\u003EglFinish\u0028\u0029V)(num2, num3);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glFlush()
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglFlush\u0028\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglFlush\u0028\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glFlush), "()V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr)>) SDLGL.__\u003Cjniptr\u003EglFlush\u0028\u0029V)(num2, num3);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glFrontFace(int i)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglFrontFace\u0028I\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglFrontFace\u0028I\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glFrontFace), "(I)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int)>) SDLGL.__\u003Cjniptr\u003EglFrontFace\u0028I\u0029V)((int) num2, num3, (IntPtr) num4);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static int glGenTexture()
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglGenTexture\u0028\u0029I == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglGenTexture\u0028\u0029I = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glGenTexture), "()I");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<int (IntPtr, IntPtr)>) SDLGL.__\u003Cjniptr\u003EglGenTexture\u0028\u0029I)(num2, num3);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static int glGetError()
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglGetError\u0028\u0029I == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglGetError\u0028\u0029I = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glGetError), "()I");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<int (IntPtr, IntPtr)>) SDLGL.__\u003Cjniptr\u003EglGetError\u0028\u0029I)(num2, num3);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glGetIntegerv(int i, IntBuffer ib)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglGetIntegerv\u0028ILjava\u002Fnio\u002FIntBuffer\u003B\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglGetIntegerv\u0028ILjava\u002Fnio\u002FIntBuffer\u003B\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glGetIntegerv), "(ILjava/nio/IntBuffer;)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i;
        IntPtr num5 = ((JNI.Frame) ref frame).MakeLocalRef((object) ib);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, IntPtr)>) SDLGL.__\u003Cjniptr\u003EglGetIntegerv\u0028ILjava\u002Fnio\u002FIntBuffer\u003B\u0029V)(num2, (int) num3, (IntPtr) num4, num5);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static string glGetString(int i)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglGetString\u0028I\u0029Ljava\u002Flang\u002FString\u003B == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglGetString\u0028I\u0029Ljava\u002Flang\u002FString\u003B = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glGetString), "(I)Ljava/lang/String;");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        ref JNI.Frame local = ref frame;
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        IntPtr num5 = __calli((__FnPtr<IntPtr (IntPtr, IntPtr, int)>) SDLGL.__\u003Cjniptr\u003EglGetString\u0028I\u0029Ljava\u002Flang\u002FString\u003B)((int) num2, num3, (IntPtr) num4);
        return (string) ((JNI.Frame) ref local).UnwrapLocalRef(num5);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glHint(int i1, int i2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglHint\u0028II\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglHint\u0028II\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glHint), "(II)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i1;
        int num5 = i2;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, int)>) SDLGL.__\u003Cjniptr\u003EglHint\u0028II\u0029V)((int) num2, (int) num3, (IntPtr) num4, (IntPtr) num5);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glLineWidth(float f)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglLineWidth\u0028F\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglLineWidth\u0028F\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glLineWidth), "(F)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        double num4 = (double) f;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, float)>) SDLGL.__\u003Cjniptr\u003EglLineWidth\u0028F\u0029V)((float) num2, num3, (IntPtr) num4);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glPixelStorei(int i1, int i2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglPixelStorei\u0028II\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglPixelStorei\u0028II\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glPixelStorei), "(II)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i1;
        int num5 = i2;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, int)>) SDLGL.__\u003Cjniptr\u003EglPixelStorei\u0028II\u0029V)((int) num2, (int) num3, (IntPtr) num4, (IntPtr) num5);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glPolygonOffset(float f1, float f2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglPolygonOffset\u0028FF\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglPolygonOffset\u0028FF\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glPolygonOffset), "(FF)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        double num4 = (double) f1;
        double num5 = (double) f2;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, float, float)>) SDLGL.__\u003Cjniptr\u003EglPolygonOffset\u0028FF\u0029V)((float) num2, (float) num3, (IntPtr) num4, (IntPtr) num5);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glReadPixels(int i1, int i2, int i3, int i4, int i5, int i6, Buffer b)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglReadPixels\u0028IIIIIILjava\u002Fnio\u002FBuffer\u003B\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglReadPixels\u0028IIIIIILjava\u002Fnio\u002FBuffer\u003B\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glReadPixels), "(IIIIIILjava/nio/Buffer;)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i1;
        int num5 = i2;
        int num6 = i3;
        int num7 = i4;
        int num8 = i5;
        int num9 = i6;
        IntPtr num10 = ((JNI.Frame) ref frame).MakeLocalRef((object) b);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, int, int, int, int, int, IntPtr)>) SDLGL.__\u003Cjniptr\u003EglReadPixels\u0028IIIIIILjava\u002Fnio\u002FBuffer\u003B\u0029V)(num2, (int) num3, num4, num5, num6, num7, num8, (IntPtr) num9, num10);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glScissor(int i1, int i2, int i3, int i4)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglScissor\u0028IIII\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglScissor\u0028IIII\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glScissor), "(IIII)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i1;
        int num5 = i2;
        int num6 = i3;
        int num7 = i4;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, int, int, int)>) SDLGL.__\u003Cjniptr\u003EglScissor\u0028IIII\u0029V)((int) num2, (int) num3, num4, num5, (IntPtr) num6, (IntPtr) num7);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glStencilFunc(int i1, int i2, int i3)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglStencilFunc\u0028III\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglStencilFunc\u0028III\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glStencilFunc), "(III)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i1;
        int num5 = i2;
        int num6 = i3;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, int, int)>) SDLGL.__\u003Cjniptr\u003EglStencilFunc\u0028III\u0029V)((int) num2, (int) num3, num4, (IntPtr) num5, (IntPtr) num6);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glStencilMask(int i)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglStencilMask\u0028I\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglStencilMask\u0028I\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glStencilMask), "(I)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int)>) SDLGL.__\u003Cjniptr\u003EglStencilMask\u0028I\u0029V)((int) num2, num3, (IntPtr) num4);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glStencilOp(int i1, int i2, int i3)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglStencilOp\u0028III\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglStencilOp\u0028III\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glStencilOp), "(III)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i1;
        int num5 = i2;
        int num6 = i3;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, int, int)>) SDLGL.__\u003Cjniptr\u003EglStencilOp\u0028III\u0029V)((int) num2, (int) num3, num4, (IntPtr) num5, (IntPtr) num6);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glTexImage2D(
      int i1,
      int i2,
      int i3,
      int i4,
      int i5,
      int i6,
      int i7,
      int i8,
      Buffer b)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglTexImage2D\u0028IIIIIIIILjava\u002Fnio\u002FBuffer\u003B\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglTexImage2D\u0028IIIIIIIILjava\u002Fnio\u002FBuffer\u003B\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glTexImage2D), "(IIIIIIIILjava/nio/Buffer;)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i1;
        int num5 = i2;
        int num6 = i3;
        int num7 = i4;
        int num8 = i5;
        int num9 = i6;
        int num10 = i7;
        int num11 = i8;
        IntPtr num12 = ((JNI.Frame) ref frame).MakeLocalRef((object) b);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, int, int, int, int, int, int, int, IntPtr)>) SDLGL.__\u003Cjniptr\u003EglTexImage2D\u0028IIIIIIIILjava\u002Fnio\u002FBuffer\u003B\u0029V)(num2, (int) num3, num4, num5, num6, num7, num8, num9, num10, (IntPtr) num11, num12);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glTexParameterf(int i1, int i2, float f)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglTexParameterf\u0028IIF\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglTexParameterf\u0028IIF\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glTexParameterf), "(IIF)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i1;
        int num5 = i2;
        double num6 = (double) f;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, int, float)>) SDLGL.__\u003Cjniptr\u003EglTexParameterf\u0028IIF\u0029V)((float) num2, (int) num3, num4, (IntPtr) num5, (IntPtr) num6);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glTexSubImage2D(
      int i1,
      int i2,
      int i3,
      int i4,
      int i5,
      int i6,
      int i7,
      int i8,
      Buffer b)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglTexSubImage2D\u0028IIIIIIIILjava\u002Fnio\u002FBuffer\u003B\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglTexSubImage2D\u0028IIIIIIIILjava\u002Fnio\u002FBuffer\u003B\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glTexSubImage2D), "(IIIIIIIILjava/nio/Buffer;)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i1;
        int num5 = i2;
        int num6 = i3;
        int num7 = i4;
        int num8 = i5;
        int num9 = i6;
        int num10 = i7;
        int num11 = i8;
        IntPtr num12 = ((JNI.Frame) ref frame).MakeLocalRef((object) b);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, int, int, int, int, int, int, int, IntPtr)>) SDLGL.__\u003Cjniptr\u003EglTexSubImage2D\u0028IIIIIIIILjava\u002Fnio\u002FBuffer\u003B\u0029V)(num2, (int) num3, num4, num5, num6, num7, num8, num9, num10, (IntPtr) num11, num12);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glViewport(int i1, int i2, int i3, int i4)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglViewport\u0028IIII\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglViewport\u0028IIII\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glViewport), "(IIII)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i1;
        int num5 = i2;
        int num6 = i3;
        int num7 = i4;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, int, int, int)>) SDLGL.__\u003Cjniptr\u003EglViewport\u0028IIII\u0029V)((int) num2, (int) num3, num4, num5, (IntPtr) num6, (IntPtr) num7);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glAttachShader(int i1, int i2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglAttachShader\u0028II\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglAttachShader\u0028II\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glAttachShader), "(II)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i1;
        int num5 = i2;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, int)>) SDLGL.__\u003Cjniptr\u003EglAttachShader\u0028II\u0029V)((int) num2, (int) num3, (IntPtr) num4, (IntPtr) num5);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glBindAttribLocation(int i1, int i2, string str)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglBindAttribLocation\u0028IILjava\u002Flang\u002FString\u003B\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglBindAttribLocation\u0028IILjava\u002Flang\u002FString\u003B\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glBindAttribLocation), "(IILjava/lang/String;)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i1;
        int num5 = i2;
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) str);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, int, IntPtr)>) SDLGL.__\u003Cjniptr\u003EglBindAttribLocation\u0028IILjava\u002Flang\u002FString\u003B\u0029V)(num2, (int) num3, num4, (IntPtr) num5, num6);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glBindBuffer(int i1, int i2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglBindBuffer\u0028II\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglBindBuffer\u0028II\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glBindBuffer), "(II)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i1;
        int num5 = i2;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, int)>) SDLGL.__\u003Cjniptr\u003EglBindBuffer\u0028II\u0029V)((int) num2, (int) num3, (IntPtr) num4, (IntPtr) num5);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glBindFramebuffer(int i1, int i2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglBindFramebuffer\u0028II\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglBindFramebuffer\u0028II\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glBindFramebuffer), "(II)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i1;
        int num5 = i2;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, int)>) SDLGL.__\u003Cjniptr\u003EglBindFramebuffer\u0028II\u0029V)((int) num2, (int) num3, (IntPtr) num4, (IntPtr) num5);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glBindRenderbuffer(int i1, int i2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglBindRenderbuffer\u0028II\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglBindRenderbuffer\u0028II\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glBindRenderbuffer), "(II)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i1;
        int num5 = i2;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, int)>) SDLGL.__\u003Cjniptr\u003EglBindRenderbuffer\u0028II\u0029V)((int) num2, (int) num3, (IntPtr) num4, (IntPtr) num5);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glBlendColor(float f1, float f2, float f3, float f4)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglBlendColor\u0028FFFF\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglBlendColor\u0028FFFF\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glBlendColor), "(FFFF)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        double num4 = (double) f1;
        double num5 = (double) f2;
        double num6 = (double) f3;
        double num7 = (double) f4;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, float, float, float, float)>) SDLGL.__\u003Cjniptr\u003EglBlendColor\u0028FFFF\u0029V)((float) num2, (float) num3, (float) num4, (float) num5, (IntPtr) num6, (IntPtr) num7);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glBlendEquation(int i)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglBlendEquation\u0028I\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglBlendEquation\u0028I\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glBlendEquation), "(I)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int)>) SDLGL.__\u003Cjniptr\u003EglBlendEquation\u0028I\u0029V)((int) num2, num3, (IntPtr) num4);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glBlendEquationSeparate(int i1, int i2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglBlendEquationSeparate\u0028II\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglBlendEquationSeparate\u0028II\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glBlendEquationSeparate), "(II)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i1;
        int num5 = i2;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, int)>) SDLGL.__\u003Cjniptr\u003EglBlendEquationSeparate\u0028II\u0029V)((int) num2, (int) num3, (IntPtr) num4, (IntPtr) num5);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glBlendFuncSeparate(int i1, int i2, int i3, int i4)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglBlendFuncSeparate\u0028IIII\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglBlendFuncSeparate\u0028IIII\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glBlendFuncSeparate), "(IIII)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i1;
        int num5 = i2;
        int num6 = i3;
        int num7 = i4;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, int, int, int)>) SDLGL.__\u003Cjniptr\u003EglBlendFuncSeparate\u0028IIII\u0029V)((int) num2, (int) num3, num4, num5, (IntPtr) num6, (IntPtr) num7);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glBufferData(int i1, int i2, Buffer b, int i3)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglBufferData\u0028IILjava\u002Fnio\u002FBuffer\u003BI\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglBufferData\u0028IILjava\u002Fnio\u002FBuffer\u003BI\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glBufferData), "(IILjava/nio/Buffer;I)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i1;
        int num5 = i2;
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) b);
        int num7 = i3;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, int, IntPtr, int)>) SDLGL.__\u003Cjniptr\u003EglBufferData\u0028IILjava\u002Fnio\u002FBuffer\u003BI\u0029V)((int) num2, num3, num4, num5, num6, (IntPtr) num7);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glBufferSubData(int i1, int i2, int i3, Buffer b)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglBufferSubData\u0028IIILjava\u002Fnio\u002FBuffer\u003B\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglBufferSubData\u0028IIILjava\u002Fnio\u002FBuffer\u003B\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glBufferSubData), "(IIILjava/nio/Buffer;)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i1;
        int num5 = i2;
        int num6 = i3;
        IntPtr num7 = ((JNI.Frame) ref frame).MakeLocalRef((object) b);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, int, int, IntPtr)>) SDLGL.__\u003Cjniptr\u003EglBufferSubData\u0028IIILjava\u002Fnio\u002FBuffer\u003B\u0029V)(num2, (int) num3, num4, num5, (IntPtr) num6, num7);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static int glCheckFramebufferStatus(int i)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglCheckFramebufferStatus\u0028I\u0029I == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglCheckFramebufferStatus\u0028I\u0029I = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glCheckFramebufferStatus), "(I)I");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<int (IntPtr, IntPtr, int)>) SDLGL.__\u003Cjniptr\u003EglCheckFramebufferStatus\u0028I\u0029I)((int) num2, num3, (IntPtr) num4);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glCompileShader(int i)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglCompileShader\u0028I\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglCompileShader\u0028I\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glCompileShader), "(I)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int)>) SDLGL.__\u003Cjniptr\u003EglCompileShader\u0028I\u0029V)((int) num2, num3, (IntPtr) num4);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static int glCreateProgram()
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglCreateProgram\u0028\u0029I == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglCreateProgram\u0028\u0029I = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glCreateProgram), "()I");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<int (IntPtr, IntPtr)>) SDLGL.__\u003Cjniptr\u003EglCreateProgram\u0028\u0029I)(num2, num3);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static int glCreateShader(int i)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglCreateShader\u0028I\u0029I == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglCreateShader\u0028I\u0029I = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glCreateShader), "(I)I");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<int (IntPtr, IntPtr, int)>) SDLGL.__\u003Cjniptr\u003EglCreateShader\u0028I\u0029I)((int) num2, num3, (IntPtr) num4);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glDeleteBuffer(int i)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglDeleteBuffer\u0028I\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglDeleteBuffer\u0028I\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glDeleteBuffer), "(I)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int)>) SDLGL.__\u003Cjniptr\u003EglDeleteBuffer\u0028I\u0029V)((int) num2, num3, (IntPtr) num4);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glDeleteFramebuffer(int i)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglDeleteFramebuffer\u0028I\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglDeleteFramebuffer\u0028I\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glDeleteFramebuffer), "(I)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int)>) SDLGL.__\u003Cjniptr\u003EglDeleteFramebuffer\u0028I\u0029V)((int) num2, num3, (IntPtr) num4);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glDeleteProgram(int i)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglDeleteProgram\u0028I\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglDeleteProgram\u0028I\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glDeleteProgram), "(I)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int)>) SDLGL.__\u003Cjniptr\u003EglDeleteProgram\u0028I\u0029V)((int) num2, num3, (IntPtr) num4);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glDeleteRenderbuffer(int i)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglDeleteRenderbuffer\u0028I\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglDeleteRenderbuffer\u0028I\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glDeleteRenderbuffer), "(I)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int)>) SDLGL.__\u003Cjniptr\u003EglDeleteRenderbuffer\u0028I\u0029V)((int) num2, num3, (IntPtr) num4);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glDeleteShader(int i)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglDeleteShader\u0028I\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglDeleteShader\u0028I\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glDeleteShader), "(I)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int)>) SDLGL.__\u003Cjniptr\u003EglDeleteShader\u0028I\u0029V)((int) num2, num3, (IntPtr) num4);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glDetachShader(int i1, int i2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglDetachShader\u0028II\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglDetachShader\u0028II\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glDetachShader), "(II)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i1;
        int num5 = i2;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, int)>) SDLGL.__\u003Cjniptr\u003EglDetachShader\u0028II\u0029V)((int) num2, (int) num3, (IntPtr) num4, (IntPtr) num5);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glDisableVertexAttribArray(int i)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglDisableVertexAttribArray\u0028I\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglDisableVertexAttribArray\u0028I\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glDisableVertexAttribArray), "(I)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int)>) SDLGL.__\u003Cjniptr\u003EglDisableVertexAttribArray\u0028I\u0029V)((int) num2, num3, (IntPtr) num4);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glDrawElements(int i1, int i2, int i3, int i4)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglDrawElements\u0028IIII\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglDrawElements\u0028IIII\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glDrawElements), "(IIII)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i1;
        int num5 = i2;
        int num6 = i3;
        int num7 = i4;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, int, int, int)>) SDLGL.__\u003Cjniptr\u003EglDrawElements\u0028IIII\u0029V)((int) num2, (int) num3, num4, num5, (IntPtr) num6, (IntPtr) num7);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glEnableVertexAttribArray(int i)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglEnableVertexAttribArray\u0028I\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglEnableVertexAttribArray\u0028I\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glEnableVertexAttribArray), "(I)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int)>) SDLGL.__\u003Cjniptr\u003EglEnableVertexAttribArray\u0028I\u0029V)((int) num2, num3, (IntPtr) num4);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glFramebufferRenderbuffer(int i1, int i2, int i3, int i4)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglFramebufferRenderbuffer\u0028IIII\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglFramebufferRenderbuffer\u0028IIII\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glFramebufferRenderbuffer), "(IIII)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i1;
        int num5 = i2;
        int num6 = i3;
        int num7 = i4;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, int, int, int)>) SDLGL.__\u003Cjniptr\u003EglFramebufferRenderbuffer\u0028IIII\u0029V)((int) num2, (int) num3, num4, num5, (IntPtr) num6, (IntPtr) num7);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glFramebufferTexture2D(int i1, int i2, int i3, int i4, int i5)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglFramebufferTexture2D\u0028IIIII\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglFramebufferTexture2D\u0028IIIII\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glFramebufferTexture2D), "(IIIII)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i1;
        int num5 = i2;
        int num6 = i3;
        int num7 = i4;
        int num8 = i5;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, int, int, int, int)>) SDLGL.__\u003Cjniptr\u003EglFramebufferTexture2D\u0028IIIII\u0029V)((int) num2, (int) num3, num4, num5, num6, (IntPtr) num7, (IntPtr) num8);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static int glGenBuffer()
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglGenBuffer\u0028\u0029I == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglGenBuffer\u0028\u0029I = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glGenBuffer), "()I");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<int (IntPtr, IntPtr)>) SDLGL.__\u003Cjniptr\u003EglGenBuffer\u0028\u0029I)(num2, num3);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glGenerateMipmap(int i)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglGenerateMipmap\u0028I\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglGenerateMipmap\u0028I\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glGenerateMipmap), "(I)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int)>) SDLGL.__\u003Cjniptr\u003EglGenerateMipmap\u0028I\u0029V)((int) num2, num3, (IntPtr) num4);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static int glGenFramebuffer()
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglGenFramebuffer\u0028\u0029I == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglGenFramebuffer\u0028\u0029I = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glGenFramebuffer), "()I");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<int (IntPtr, IntPtr)>) SDLGL.__\u003Cjniptr\u003EglGenFramebuffer\u0028\u0029I)(num2, num3);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static int glGenRenderbuffer()
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglGenRenderbuffer\u0028\u0029I == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglGenRenderbuffer\u0028\u0029I = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glGenRenderbuffer), "()I");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<int (IntPtr, IntPtr)>) SDLGL.__\u003Cjniptr\u003EglGenRenderbuffer\u0028\u0029I)(num2, num3);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static string glGetActiveAttrib(int i1, int i2, object obj1, object obj2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglGetActiveAttrib\u0028IILjava\u002Flang\u002FObject\u003BLjava\u002Flang\u002FObject\u003B\u0029Ljava\u002Flang\u002FString\u003B == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglGetActiveAttrib\u0028IILjava\u002Flang\u002FObject\u003BLjava\u002Flang\u002FObject\u003B\u0029Ljava\u002Flang\u002FString\u003B = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glGetActiveAttrib), "(IILjava/lang/Object;Ljava/lang/Object;)Ljava/lang/String;");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        ref JNI.Frame local = ref frame;
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i1;
        int num5 = i2;
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef(obj1);
        IntPtr num7 = ((JNI.Frame) ref frame).MakeLocalRef(obj2);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        IntPtr num8 = __calli((__FnPtr<IntPtr (IntPtr, IntPtr, int, int, IntPtr, IntPtr)>) SDLGL.__\u003Cjniptr\u003EglGetActiveAttrib\u0028IILjava\u002Flang\u002FObject\u003BLjava\u002Flang\u002FObject\u003B\u0029Ljava\u002Flang\u002FString\u003B)(num2, num3, num4, num5, num6, num7);
        return (string) ((JNI.Frame) ref local).UnwrapLocalRef(num8);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static string glGetActiveUniform(int i1, int i2, object obj1, object obj2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglGetActiveUniform\u0028IILjava\u002Flang\u002FObject\u003BLjava\u002Flang\u002FObject\u003B\u0029Ljava\u002Flang\u002FString\u003B == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglGetActiveUniform\u0028IILjava\u002Flang\u002FObject\u003BLjava\u002Flang\u002FObject\u003B\u0029Ljava\u002Flang\u002FString\u003B = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glGetActiveUniform), "(IILjava/lang/Object;Ljava/lang/Object;)Ljava/lang/String;");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        ref JNI.Frame local = ref frame;
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i1;
        int num5 = i2;
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef(obj1);
        IntPtr num7 = ((JNI.Frame) ref frame).MakeLocalRef(obj2);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        IntPtr num8 = __calli((__FnPtr<IntPtr (IntPtr, IntPtr, int, int, IntPtr, IntPtr)>) SDLGL.__\u003Cjniptr\u003EglGetActiveUniform\u0028IILjava\u002Flang\u002FObject\u003BLjava\u002Flang\u002FObject\u003B\u0029Ljava\u002Flang\u002FString\u003B)(num2, num3, num4, num5, num6, num7);
        return (string) ((JNI.Frame) ref local).UnwrapLocalRef(num8);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static int glGetAttribLocation(int i, string str)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglGetAttribLocation\u0028ILjava\u002Flang\u002FString\u003B\u0029I == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglGetAttribLocation\u0028ILjava\u002Flang\u002FString\u003B\u0029I = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glGetAttribLocation), "(ILjava/lang/String;)I");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i;
        IntPtr num5 = ((JNI.Frame) ref frame).MakeLocalRef((object) str);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<int (IntPtr, IntPtr, int, IntPtr)>) SDLGL.__\u003Cjniptr\u003EglGetAttribLocation\u0028ILjava\u002Flang\u002FString\u003B\u0029I)(num2, (int) num3, (IntPtr) num4, num5);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glGetBooleanv(int i, Buffer b)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglGetBooleanv\u0028ILjava\u002Fnio\u002FBuffer\u003B\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglGetBooleanv\u0028ILjava\u002Fnio\u002FBuffer\u003B\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glGetBooleanv), "(ILjava/nio/Buffer;)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i;
        IntPtr num5 = ((JNI.Frame) ref frame).MakeLocalRef((object) b);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, IntPtr)>) SDLGL.__\u003Cjniptr\u003EglGetBooleanv\u0028ILjava\u002Fnio\u002FBuffer\u003B\u0029V)(num2, (int) num3, (IntPtr) num4, num5);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glGetBufferParameteriv(int i1, int i2, IntBuffer ib)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglGetBufferParameteriv\u0028IILjava\u002Fnio\u002FIntBuffer\u003B\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglGetBufferParameteriv\u0028IILjava\u002Fnio\u002FIntBuffer\u003B\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glGetBufferParameteriv), "(IILjava/nio/IntBuffer;)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i1;
        int num5 = i2;
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) ib);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, int, IntPtr)>) SDLGL.__\u003Cjniptr\u003EglGetBufferParameteriv\u0028IILjava\u002Fnio\u002FIntBuffer\u003B\u0029V)(num2, (int) num3, num4, (IntPtr) num5, num6);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glGetFloatv(int i, FloatBuffer fb)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglGetFloatv\u0028ILjava\u002Fnio\u002FFloatBuffer\u003B\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglGetFloatv\u0028ILjava\u002Fnio\u002FFloatBuffer\u003B\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glGetFloatv), "(ILjava/nio/FloatBuffer;)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i;
        IntPtr num5 = ((JNI.Frame) ref frame).MakeLocalRef((object) fb);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, IntPtr)>) SDLGL.__\u003Cjniptr\u003EglGetFloatv\u0028ILjava\u002Fnio\u002FFloatBuffer\u003B\u0029V)(num2, (int) num3, (IntPtr) num4, num5);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glGetFramebufferAttachmentParameteriv(int i1, int i2, int i3, IntBuffer ib)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglGetFramebufferAttachmentParameteriv\u0028IIILjava\u002Fnio\u002FIntBuffer\u003B\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglGetFramebufferAttachmentParameteriv\u0028IIILjava\u002Fnio\u002FIntBuffer\u003B\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glGetFramebufferAttachmentParameteriv), "(IIILjava/nio/IntBuffer;)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i1;
        int num5 = i2;
        int num6 = i3;
        IntPtr num7 = ((JNI.Frame) ref frame).MakeLocalRef((object) ib);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, int, int, IntPtr)>) SDLGL.__\u003Cjniptr\u003EglGetFramebufferAttachmentParameteriv\u0028IIILjava\u002Fnio\u002FIntBuffer\u003B\u0029V)(num2, (int) num3, num4, num5, (IntPtr) num6, num7);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glGetProgramiv(int i1, int i2, IntBuffer ib)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglGetProgramiv\u0028IILjava\u002Fnio\u002FIntBuffer\u003B\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglGetProgramiv\u0028IILjava\u002Fnio\u002FIntBuffer\u003B\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glGetProgramiv), "(IILjava/nio/IntBuffer;)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i1;
        int num5 = i2;
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) ib);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, int, IntPtr)>) SDLGL.__\u003Cjniptr\u003EglGetProgramiv\u0028IILjava\u002Fnio\u002FIntBuffer\u003B\u0029V)(num2, (int) num3, num4, (IntPtr) num5, num6);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static string glGetProgramInfoLog(int i)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglGetProgramInfoLog\u0028I\u0029Ljava\u002Flang\u002FString\u003B == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglGetProgramInfoLog\u0028I\u0029Ljava\u002Flang\u002FString\u003B = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glGetProgramInfoLog), "(I)Ljava/lang/String;");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        ref JNI.Frame local = ref frame;
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        IntPtr num5 = __calli((__FnPtr<IntPtr (IntPtr, IntPtr, int)>) SDLGL.__\u003Cjniptr\u003EglGetProgramInfoLog\u0028I\u0029Ljava\u002Flang\u002FString\u003B)((int) num2, num3, (IntPtr) num4);
        return (string) ((JNI.Frame) ref local).UnwrapLocalRef(num5);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glGetRenderbufferParameteriv(int i1, int i2, IntBuffer ib)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglGetRenderbufferParameteriv\u0028IILjava\u002Fnio\u002FIntBuffer\u003B\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglGetRenderbufferParameteriv\u0028IILjava\u002Fnio\u002FIntBuffer\u003B\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glGetRenderbufferParameteriv), "(IILjava/nio/IntBuffer;)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i1;
        int num5 = i2;
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) ib);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, int, IntPtr)>) SDLGL.__\u003Cjniptr\u003EglGetRenderbufferParameteriv\u0028IILjava\u002Fnio\u002FIntBuffer\u003B\u0029V)(num2, (int) num3, num4, (IntPtr) num5, num6);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glGetShaderiv(int i1, int i2, IntBuffer ib)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglGetShaderiv\u0028IILjava\u002Fnio\u002FIntBuffer\u003B\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglGetShaderiv\u0028IILjava\u002Fnio\u002FIntBuffer\u003B\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glGetShaderiv), "(IILjava/nio/IntBuffer;)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i1;
        int num5 = i2;
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) ib);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, int, IntPtr)>) SDLGL.__\u003Cjniptr\u003EglGetShaderiv\u0028IILjava\u002Fnio\u002FIntBuffer\u003B\u0029V)(num2, (int) num3, num4, (IntPtr) num5, num6);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static string glGetShaderInfoLog(int i)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglGetShaderInfoLog\u0028I\u0029Ljava\u002Flang\u002FString\u003B == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglGetShaderInfoLog\u0028I\u0029Ljava\u002Flang\u002FString\u003B = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glGetShaderInfoLog), "(I)Ljava/lang/String;");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        ref JNI.Frame local = ref frame;
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        IntPtr num5 = __calli((__FnPtr<IntPtr (IntPtr, IntPtr, int)>) SDLGL.__\u003Cjniptr\u003EglGetShaderInfoLog\u0028I\u0029Ljava\u002Flang\u002FString\u003B)((int) num2, num3, (IntPtr) num4);
        return (string) ((JNI.Frame) ref local).UnwrapLocalRef(num5);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glGetShaderPrecisionFormat(int i1, int i2, IntBuffer ib1, IntBuffer ib2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglGetShaderPrecisionFormat\u0028IILjava\u002Fnio\u002FIntBuffer\u003BLjava\u002Fnio\u002FIntBuffer\u003B\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglGetShaderPrecisionFormat\u0028IILjava\u002Fnio\u002FIntBuffer\u003BLjava\u002Fnio\u002FIntBuffer\u003B\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glGetShaderPrecisionFormat), "(IILjava/nio/IntBuffer;Ljava/nio/IntBuffer;)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i1;
        int num5 = i2;
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) ib1);
        IntPtr num7 = ((JNI.Frame) ref frame).MakeLocalRef((object) ib2);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, int, IntPtr, IntPtr)>) SDLGL.__\u003Cjniptr\u003EglGetShaderPrecisionFormat\u0028IILjava\u002Fnio\u002FIntBuffer\u003BLjava\u002Fnio\u002FIntBuffer\u003B\u0029V)(num2, num3, num4, num5, num6, num7);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glGetTexParameterfv(int i1, int i2, FloatBuffer fb)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglGetTexParameterfv\u0028IILjava\u002Fnio\u002FFloatBuffer\u003B\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglGetTexParameterfv\u0028IILjava\u002Fnio\u002FFloatBuffer\u003B\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glGetTexParameterfv), "(IILjava/nio/FloatBuffer;)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i1;
        int num5 = i2;
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) fb);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, int, IntPtr)>) SDLGL.__\u003Cjniptr\u003EglGetTexParameterfv\u0028IILjava\u002Fnio\u002FFloatBuffer\u003B\u0029V)(num2, (int) num3, num4, (IntPtr) num5, num6);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glGetTexParameteriv(int i1, int i2, IntBuffer ib)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglGetTexParameteriv\u0028IILjava\u002Fnio\u002FIntBuffer\u003B\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglGetTexParameteriv\u0028IILjava\u002Fnio\u002FIntBuffer\u003B\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glGetTexParameteriv), "(IILjava/nio/IntBuffer;)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i1;
        int num5 = i2;
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) ib);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, int, IntPtr)>) SDLGL.__\u003Cjniptr\u003EglGetTexParameteriv\u0028IILjava\u002Fnio\u002FIntBuffer\u003B\u0029V)(num2, (int) num3, num4, (IntPtr) num5, num6);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glGetUniformfv(int i1, int i2, FloatBuffer fb)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglGetUniformfv\u0028IILjava\u002Fnio\u002FFloatBuffer\u003B\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglGetUniformfv\u0028IILjava\u002Fnio\u002FFloatBuffer\u003B\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glGetUniformfv), "(IILjava/nio/FloatBuffer;)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i1;
        int num5 = i2;
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) fb);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, int, IntPtr)>) SDLGL.__\u003Cjniptr\u003EglGetUniformfv\u0028IILjava\u002Fnio\u002FFloatBuffer\u003B\u0029V)(num2, (int) num3, num4, (IntPtr) num5, num6);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glGetUniformiv(int i1, int i2, IntBuffer ib)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglGetUniformiv\u0028IILjava\u002Fnio\u002FIntBuffer\u003B\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglGetUniformiv\u0028IILjava\u002Fnio\u002FIntBuffer\u003B\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glGetUniformiv), "(IILjava/nio/IntBuffer;)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i1;
        int num5 = i2;
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) ib);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, int, IntPtr)>) SDLGL.__\u003Cjniptr\u003EglGetUniformiv\u0028IILjava\u002Fnio\u002FIntBuffer\u003B\u0029V)(num2, (int) num3, num4, (IntPtr) num5, num6);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static int glGetUniformLocation(int i, string str)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglGetUniformLocation\u0028ILjava\u002Flang\u002FString\u003B\u0029I == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglGetUniformLocation\u0028ILjava\u002Flang\u002FString\u003B\u0029I = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glGetUniformLocation), "(ILjava/lang/String;)I");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i;
        IntPtr num5 = ((JNI.Frame) ref frame).MakeLocalRef((object) str);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<int (IntPtr, IntPtr, int, IntPtr)>) SDLGL.__\u003Cjniptr\u003EglGetUniformLocation\u0028ILjava\u002Flang\u002FString\u003B\u0029I)(num2, (int) num3, (IntPtr) num4, num5);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glGetVertexAttribfv(int i1, int i2, FloatBuffer fb)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglGetVertexAttribfv\u0028IILjava\u002Fnio\u002FFloatBuffer\u003B\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglGetVertexAttribfv\u0028IILjava\u002Fnio\u002FFloatBuffer\u003B\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glGetVertexAttribfv), "(IILjava/nio/FloatBuffer;)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i1;
        int num5 = i2;
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) fb);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, int, IntPtr)>) SDLGL.__\u003Cjniptr\u003EglGetVertexAttribfv\u0028IILjava\u002Fnio\u002FFloatBuffer\u003B\u0029V)(num2, (int) num3, num4, (IntPtr) num5, num6);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glGetVertexAttribiv(int i1, int i2, IntBuffer ib)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglGetVertexAttribiv\u0028IILjava\u002Fnio\u002FIntBuffer\u003B\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglGetVertexAttribiv\u0028IILjava\u002Fnio\u002FIntBuffer\u003B\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glGetVertexAttribiv), "(IILjava/nio/IntBuffer;)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i1;
        int num5 = i2;
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) ib);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, int, IntPtr)>) SDLGL.__\u003Cjniptr\u003EglGetVertexAttribiv\u0028IILjava\u002Fnio\u002FIntBuffer\u003B\u0029V)(num2, (int) num3, num4, (IntPtr) num5, num6);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static bool glIsBuffer(int i)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglIsBuffer\u0028I\u0029Z == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglIsBuffer\u0028I\u0029Z = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glIsBuffer), "(I)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, int)>) SDLGL.__\u003Cjniptr\u003EglIsBuffer\u0028I\u0029Z)((int) num2, num3, (IntPtr) num4);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static bool glIsEnabled(int i)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglIsEnabled\u0028I\u0029Z == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglIsEnabled\u0028I\u0029Z = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glIsEnabled), "(I)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, int)>) SDLGL.__\u003Cjniptr\u003EglIsEnabled\u0028I\u0029Z)((int) num2, num3, (IntPtr) num4);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static bool glIsFramebuffer(int i)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglIsFramebuffer\u0028I\u0029Z == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglIsFramebuffer\u0028I\u0029Z = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glIsFramebuffer), "(I)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, int)>) SDLGL.__\u003Cjniptr\u003EglIsFramebuffer\u0028I\u0029Z)((int) num2, num3, (IntPtr) num4);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static bool glIsProgram(int i)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglIsProgram\u0028I\u0029Z == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglIsProgram\u0028I\u0029Z = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glIsProgram), "(I)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, int)>) SDLGL.__\u003Cjniptr\u003EglIsProgram\u0028I\u0029Z)((int) num2, num3, (IntPtr) num4);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static bool glIsRenderbuffer(int i)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglIsRenderbuffer\u0028I\u0029Z == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglIsRenderbuffer\u0028I\u0029Z = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glIsRenderbuffer), "(I)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, int)>) SDLGL.__\u003Cjniptr\u003EglIsRenderbuffer\u0028I\u0029Z)((int) num2, num3, (IntPtr) num4);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static bool glIsShader(int i)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglIsShader\u0028I\u0029Z == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglIsShader\u0028I\u0029Z = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glIsShader), "(I)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, int)>) SDLGL.__\u003Cjniptr\u003EglIsShader\u0028I\u0029Z)((int) num2, num3, (IntPtr) num4);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static bool glIsTexture(int i)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglIsTexture\u0028I\u0029Z == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglIsTexture\u0028I\u0029Z = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glIsTexture), "(I)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, int)>) SDLGL.__\u003Cjniptr\u003EglIsTexture\u0028I\u0029Z)((int) num2, num3, (IntPtr) num4);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glLinkProgram(int i)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglLinkProgram\u0028I\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglLinkProgram\u0028I\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glLinkProgram), "(I)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int)>) SDLGL.__\u003Cjniptr\u003EglLinkProgram\u0028I\u0029V)((int) num2, num3, (IntPtr) num4);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glReleaseShaderCompiler()
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglReleaseShaderCompiler\u0028\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglReleaseShaderCompiler\u0028\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glReleaseShaderCompiler), "()V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr)>) SDLGL.__\u003Cjniptr\u003EglReleaseShaderCompiler\u0028\u0029V)(num2, num3);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glRenderbufferStorage(int i1, int i2, int i3, int i4)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglRenderbufferStorage\u0028IIII\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglRenderbufferStorage\u0028IIII\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glRenderbufferStorage), "(IIII)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i1;
        int num5 = i2;
        int num6 = i3;
        int num7 = i4;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, int, int, int)>) SDLGL.__\u003Cjniptr\u003EglRenderbufferStorage\u0028IIII\u0029V)((int) num2, (int) num3, num4, num5, (IntPtr) num6, (IntPtr) num7);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glSampleCoverage(float f, bool b)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglSampleCoverage\u0028FZ\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglSampleCoverage\u0028FZ\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glSampleCoverage), "(FZ)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        double num4 = (double) f;
        int num5 = b ? 1 : 0;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, float, bool)>) SDLGL.__\u003Cjniptr\u003EglSampleCoverage\u0028FZ\u0029V)((bool) num2, (float) num3, (IntPtr) num4, (IntPtr) num5);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glShaderSource(int i, string str)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglShaderSource\u0028ILjava\u002Flang\u002FString\u003B\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglShaderSource\u0028ILjava\u002Flang\u002FString\u003B\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glShaderSource), "(ILjava/lang/String;)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i;
        IntPtr num5 = ((JNI.Frame) ref frame).MakeLocalRef((object) str);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, IntPtr)>) SDLGL.__\u003Cjniptr\u003EglShaderSource\u0028ILjava\u002Flang\u002FString\u003B\u0029V)(num2, (int) num3, (IntPtr) num4, num5);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glStencilFuncSeparate(int i1, int i2, int i3, int i4)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglStencilFuncSeparate\u0028IIII\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglStencilFuncSeparate\u0028IIII\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glStencilFuncSeparate), "(IIII)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i1;
        int num5 = i2;
        int num6 = i3;
        int num7 = i4;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, int, int, int)>) SDLGL.__\u003Cjniptr\u003EglStencilFuncSeparate\u0028IIII\u0029V)((int) num2, (int) num3, num4, num5, (IntPtr) num6, (IntPtr) num7);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glStencilMaskSeparate(int i1, int i2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglStencilMaskSeparate\u0028II\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglStencilMaskSeparate\u0028II\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glStencilMaskSeparate), "(II)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i1;
        int num5 = i2;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, int)>) SDLGL.__\u003Cjniptr\u003EglStencilMaskSeparate\u0028II\u0029V)((int) num2, (int) num3, (IntPtr) num4, (IntPtr) num5);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glStencilOpSeparate(int i1, int i2, int i3, int i4)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglStencilOpSeparate\u0028IIII\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglStencilOpSeparate\u0028IIII\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glStencilOpSeparate), "(IIII)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i1;
        int num5 = i2;
        int num6 = i3;
        int num7 = i4;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, int, int, int)>) SDLGL.__\u003Cjniptr\u003EglStencilOpSeparate\u0028IIII\u0029V)((int) num2, (int) num3, num4, num5, (IntPtr) num6, (IntPtr) num7);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glTexParameterfv(int i1, int i2, FloatBuffer fb)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglTexParameterfv\u0028IILjava\u002Fnio\u002FFloatBuffer\u003B\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglTexParameterfv\u0028IILjava\u002Fnio\u002FFloatBuffer\u003B\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glTexParameterfv), "(IILjava/nio/FloatBuffer;)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i1;
        int num5 = i2;
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) fb);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, int, IntPtr)>) SDLGL.__\u003Cjniptr\u003EglTexParameterfv\u0028IILjava\u002Fnio\u002FFloatBuffer\u003B\u0029V)(num2, (int) num3, num4, (IntPtr) num5, num6);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glTexParameteri(int i1, int i2, int i3)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglTexParameteri\u0028III\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglTexParameteri\u0028III\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glTexParameteri), "(III)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i1;
        int num5 = i2;
        int num6 = i3;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, int, int)>) SDLGL.__\u003Cjniptr\u003EglTexParameteri\u0028III\u0029V)((int) num2, (int) num3, num4, (IntPtr) num5, (IntPtr) num6);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glTexParameteriv(int i1, int i2, IntBuffer ib)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglTexParameteriv\u0028IILjava\u002Fnio\u002FIntBuffer\u003B\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglTexParameteriv\u0028IILjava\u002Fnio\u002FIntBuffer\u003B\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glTexParameteriv), "(IILjava/nio/IntBuffer;)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i1;
        int num5 = i2;
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) ib);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, int, IntPtr)>) SDLGL.__\u003Cjniptr\u003EglTexParameteriv\u0028IILjava\u002Fnio\u002FIntBuffer\u003B\u0029V)(num2, (int) num3, num4, (IntPtr) num5, num6);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glUniform1f(int i, float f)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglUniform1f\u0028IF\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglUniform1f\u0028IF\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glUniform1f), "(IF)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i;
        double num5 = (double) f;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, float)>) SDLGL.__\u003Cjniptr\u003EglUniform1f\u0028IF\u0029V)((float) num2, (int) num3, (IntPtr) num4, (IntPtr) num5);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glUniform1fv(int i1, int i2, FloatBuffer fb)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglUniform1fv\u0028IILjava\u002Fnio\u002FFloatBuffer\u003B\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglUniform1fv\u0028IILjava\u002Fnio\u002FFloatBuffer\u003B\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glUniform1fv), "(IILjava/nio/FloatBuffer;)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i1;
        int num5 = i2;
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) fb);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, int, IntPtr)>) SDLGL.__\u003Cjniptr\u003EglUniform1fv\u0028IILjava\u002Fnio\u002FFloatBuffer\u003B\u0029V)(num2, (int) num3, num4, (IntPtr) num5, num6);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glUniform1fv(int i1, int i2, float[] farr, int i3)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglUniform1fv\u0028II\u005BFI\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglUniform1fv\u0028II\u005BFI\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glUniform1fv), "(II[FI)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i1;
        int num5 = i2;
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) farr);
        int num7 = i3;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, int, IntPtr, int)>) SDLGL.__\u003Cjniptr\u003EglUniform1fv\u0028II\u005BFI\u0029V)((int) num2, num3, num4, num5, num6, (IntPtr) num7);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glUniform1i(int i1, int i2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglUniform1i\u0028II\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglUniform1i\u0028II\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glUniform1i), "(II)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i1;
        int num5 = i2;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, int)>) SDLGL.__\u003Cjniptr\u003EglUniform1i\u0028II\u0029V)((int) num2, (int) num3, (IntPtr) num4, (IntPtr) num5);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glUniform1iv(int i1, int i2, IntBuffer ib)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglUniform1iv\u0028IILjava\u002Fnio\u002FIntBuffer\u003B\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglUniform1iv\u0028IILjava\u002Fnio\u002FIntBuffer\u003B\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glUniform1iv), "(IILjava/nio/IntBuffer;)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i1;
        int num5 = i2;
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) ib);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, int, IntPtr)>) SDLGL.__\u003Cjniptr\u003EglUniform1iv\u0028IILjava\u002Fnio\u002FIntBuffer\u003B\u0029V)(num2, (int) num3, num4, (IntPtr) num5, num6);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glUniform1iv(int i1, int i2, int[] iarr, int i3)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglUniform1iv\u0028II\u005BII\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglUniform1iv\u0028II\u005BII\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glUniform1iv), "(II[II)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i1;
        int num5 = i2;
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) iarr);
        int num7 = i3;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, int, IntPtr, int)>) SDLGL.__\u003Cjniptr\u003EglUniform1iv\u0028II\u005BII\u0029V)((int) num2, num3, num4, num5, num6, (IntPtr) num7);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glUniform2f(int i, float f1, float f2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglUniform2f\u0028IFF\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglUniform2f\u0028IFF\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glUniform2f), "(IFF)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i;
        double num5 = (double) f1;
        double num6 = (double) f2;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, float, float)>) SDLGL.__\u003Cjniptr\u003EglUniform2f\u0028IFF\u0029V)((float) num2, (float) num3, num4, (IntPtr) num5, (IntPtr) num6);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glUniform2fv(int i1, int i2, FloatBuffer fb)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglUniform2fv\u0028IILjava\u002Fnio\u002FFloatBuffer\u003B\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglUniform2fv\u0028IILjava\u002Fnio\u002FFloatBuffer\u003B\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glUniform2fv), "(IILjava/nio/FloatBuffer;)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i1;
        int num5 = i2;
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) fb);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, int, IntPtr)>) SDLGL.__\u003Cjniptr\u003EglUniform2fv\u0028IILjava\u002Fnio\u002FFloatBuffer\u003B\u0029V)(num2, (int) num3, num4, (IntPtr) num5, num6);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glUniform2fv(int i1, int i2, float[] farr, int i3)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglUniform2fv\u0028II\u005BFI\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglUniform2fv\u0028II\u005BFI\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glUniform2fv), "(II[FI)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i1;
        int num5 = i2;
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) farr);
        int num7 = i3;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, int, IntPtr, int)>) SDLGL.__\u003Cjniptr\u003EglUniform2fv\u0028II\u005BFI\u0029V)((int) num2, num3, num4, num5, num6, (IntPtr) num7);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glUniform2i(int i1, int i2, int i3)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglUniform2i\u0028III\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglUniform2i\u0028III\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glUniform2i), "(III)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i1;
        int num5 = i2;
        int num6 = i3;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, int, int)>) SDLGL.__\u003Cjniptr\u003EglUniform2i\u0028III\u0029V)((int) num2, (int) num3, num4, (IntPtr) num5, (IntPtr) num6);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glUniform2iv(int i1, int i2, IntBuffer ib)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglUniform2iv\u0028IILjava\u002Fnio\u002FIntBuffer\u003B\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglUniform2iv\u0028IILjava\u002Fnio\u002FIntBuffer\u003B\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glUniform2iv), "(IILjava/nio/IntBuffer;)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i1;
        int num5 = i2;
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) ib);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, int, IntPtr)>) SDLGL.__\u003Cjniptr\u003EglUniform2iv\u0028IILjava\u002Fnio\u002FIntBuffer\u003B\u0029V)(num2, (int) num3, num4, (IntPtr) num5, num6);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glUniform2iv(int i1, int i2, int[] iarr, int i3)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglUniform2iv\u0028II\u005BII\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglUniform2iv\u0028II\u005BII\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glUniform2iv), "(II[II)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i1;
        int num5 = i2;
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) iarr);
        int num7 = i3;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, int, IntPtr, int)>) SDLGL.__\u003Cjniptr\u003EglUniform2iv\u0028II\u005BII\u0029V)((int) num2, num3, num4, num5, num6, (IntPtr) num7);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glUniform3f(int i, float f1, float f2, float f3)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglUniform3f\u0028IFFF\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglUniform3f\u0028IFFF\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glUniform3f), "(IFFF)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i;
        double num5 = (double) f1;
        double num6 = (double) f2;
        double num7 = (double) f3;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, float, float, float)>) SDLGL.__\u003Cjniptr\u003EglUniform3f\u0028IFFF\u0029V)((float) num2, (float) num3, (float) num4, (int) num5, (IntPtr) num6, (IntPtr) num7);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glUniform3fv(int i1, int i2, FloatBuffer fb)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglUniform3fv\u0028IILjava\u002Fnio\u002FFloatBuffer\u003B\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglUniform3fv\u0028IILjava\u002Fnio\u002FFloatBuffer\u003B\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glUniform3fv), "(IILjava/nio/FloatBuffer;)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i1;
        int num5 = i2;
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) fb);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, int, IntPtr)>) SDLGL.__\u003Cjniptr\u003EglUniform3fv\u0028IILjava\u002Fnio\u002FFloatBuffer\u003B\u0029V)(num2, (int) num3, num4, (IntPtr) num5, num6);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glUniform3fv(int i1, int i2, float[] farr, int i3)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglUniform3fv\u0028II\u005BFI\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglUniform3fv\u0028II\u005BFI\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glUniform3fv), "(II[FI)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i1;
        int num5 = i2;
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) farr);
        int num7 = i3;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, int, IntPtr, int)>) SDLGL.__\u003Cjniptr\u003EglUniform3fv\u0028II\u005BFI\u0029V)((int) num2, num3, num4, num5, num6, (IntPtr) num7);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glUniform3i(int i1, int i2, int i3, int i4)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglUniform3i\u0028IIII\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglUniform3i\u0028IIII\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glUniform3i), "(IIII)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i1;
        int num5 = i2;
        int num6 = i3;
        int num7 = i4;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, int, int, int)>) SDLGL.__\u003Cjniptr\u003EglUniform3i\u0028IIII\u0029V)((int) num2, (int) num3, num4, num5, (IntPtr) num6, (IntPtr) num7);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glUniform3iv(int i1, int i2, IntBuffer ib)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglUniform3iv\u0028IILjava\u002Fnio\u002FIntBuffer\u003B\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglUniform3iv\u0028IILjava\u002Fnio\u002FIntBuffer\u003B\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glUniform3iv), "(IILjava/nio/IntBuffer;)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i1;
        int num5 = i2;
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) ib);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, int, IntPtr)>) SDLGL.__\u003Cjniptr\u003EglUniform3iv\u0028IILjava\u002Fnio\u002FIntBuffer\u003B\u0029V)(num2, (int) num3, num4, (IntPtr) num5, num6);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glUniform3iv(int i1, int i2, int[] iarr, int i3)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglUniform3iv\u0028II\u005BII\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglUniform3iv\u0028II\u005BII\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glUniform3iv), "(II[II)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i1;
        int num5 = i2;
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) iarr);
        int num7 = i3;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, int, IntPtr, int)>) SDLGL.__\u003Cjniptr\u003EglUniform3iv\u0028II\u005BII\u0029V)((int) num2, num3, num4, num5, num6, (IntPtr) num7);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glUniform4f(int i, float f1, float f2, float f3, float f4)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglUniform4f\u0028IFFFF\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglUniform4f\u0028IFFFF\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glUniform4f), "(IFFFF)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i;
        double num5 = (double) f1;
        double num6 = (double) f2;
        double num7 = (double) f3;
        double num8 = (double) f4;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, float, float, float, float)>) SDLGL.__\u003Cjniptr\u003EglUniform4f\u0028IFFFF\u0029V)((float) num2, (float) num3, (float) num4, (float) num5, (int) num6, (IntPtr) num7, (IntPtr) num8);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glUniform4fv(int i1, int i2, FloatBuffer fb)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglUniform4fv\u0028IILjava\u002Fnio\u002FFloatBuffer\u003B\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglUniform4fv\u0028IILjava\u002Fnio\u002FFloatBuffer\u003B\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glUniform4fv), "(IILjava/nio/FloatBuffer;)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i1;
        int num5 = i2;
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) fb);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, int, IntPtr)>) SDLGL.__\u003Cjniptr\u003EglUniform4fv\u0028IILjava\u002Fnio\u002FFloatBuffer\u003B\u0029V)(num2, (int) num3, num4, (IntPtr) num5, num6);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glUniform4fv(int i1, int i2, float[] farr, int i3)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglUniform4fv\u0028II\u005BFI\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglUniform4fv\u0028II\u005BFI\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glUniform4fv), "(II[FI)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i1;
        int num5 = i2;
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) farr);
        int num7 = i3;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, int, IntPtr, int)>) SDLGL.__\u003Cjniptr\u003EglUniform4fv\u0028II\u005BFI\u0029V)((int) num2, num3, num4, num5, num6, (IntPtr) num7);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glUniform4i(int i1, int i2, int i3, int i4, int i5)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglUniform4i\u0028IIIII\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglUniform4i\u0028IIIII\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glUniform4i), "(IIIII)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i1;
        int num5 = i2;
        int num6 = i3;
        int num7 = i4;
        int num8 = i5;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, int, int, int, int)>) SDLGL.__\u003Cjniptr\u003EglUniform4i\u0028IIIII\u0029V)((int) num2, (int) num3, num4, num5, num6, (IntPtr) num7, (IntPtr) num8);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glUniform4iv(int i1, int i2, IntBuffer ib)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglUniform4iv\u0028IILjava\u002Fnio\u002FIntBuffer\u003B\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglUniform4iv\u0028IILjava\u002Fnio\u002FIntBuffer\u003B\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glUniform4iv), "(IILjava/nio/IntBuffer;)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i1;
        int num5 = i2;
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) ib);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, int, IntPtr)>) SDLGL.__\u003Cjniptr\u003EglUniform4iv\u0028IILjava\u002Fnio\u002FIntBuffer\u003B\u0029V)(num2, (int) num3, num4, (IntPtr) num5, num6);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glUniform4iv(int i1, int i2, int[] iarr, int i3)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglUniform4iv\u0028II\u005BII\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglUniform4iv\u0028II\u005BII\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glUniform4iv), "(II[II)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i1;
        int num5 = i2;
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) iarr);
        int num7 = i3;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, int, IntPtr, int)>) SDLGL.__\u003Cjniptr\u003EglUniform4iv\u0028II\u005BII\u0029V)((int) num2, num3, num4, num5, num6, (IntPtr) num7);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glUniformMatrix2fv(int i1, int i2, bool b, FloatBuffer fb)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglUniformMatrix2fv\u0028IIZLjava\u002Fnio\u002FFloatBuffer\u003B\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglUniformMatrix2fv\u0028IIZLjava\u002Fnio\u002FFloatBuffer\u003B\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glUniformMatrix2fv), "(IIZLjava/nio/FloatBuffer;)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i1;
        int num5 = i2;
        int num6 = b ? 1 : 0;
        IntPtr num7 = ((JNI.Frame) ref frame).MakeLocalRef((object) fb);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, int, bool, IntPtr)>) SDLGL.__\u003Cjniptr\u003EglUniformMatrix2fv\u0028IIZLjava\u002Fnio\u002FFloatBuffer\u003B\u0029V)(num2, (bool) num3, num4, num5, (IntPtr) num6, num7);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glUniformMatrix2fv(int i1, int i2, bool b, float[] farr, int i3)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglUniformMatrix2fv\u0028IIZ\u005BFI\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglUniformMatrix2fv\u0028IIZ\u005BFI\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glUniformMatrix2fv), "(IIZ[FI)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i1;
        int num5 = i2;
        int num6 = b ? 1 : 0;
        IntPtr num7 = ((JNI.Frame) ref frame).MakeLocalRef((object) farr);
        int num8 = i3;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, int, bool, IntPtr, int)>) SDLGL.__\u003Cjniptr\u003EglUniformMatrix2fv\u0028IIZ\u005BFI\u0029V)((int) num2, num3, num4 != 0, num5, num6, num7, (IntPtr) num8);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glUniformMatrix3fv(int i1, int i2, bool b, FloatBuffer fb)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglUniformMatrix3fv\u0028IIZLjava\u002Fnio\u002FFloatBuffer\u003B\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglUniformMatrix3fv\u0028IIZLjava\u002Fnio\u002FFloatBuffer\u003B\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glUniformMatrix3fv), "(IIZLjava/nio/FloatBuffer;)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i1;
        int num5 = i2;
        int num6 = b ? 1 : 0;
        IntPtr num7 = ((JNI.Frame) ref frame).MakeLocalRef((object) fb);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, int, bool, IntPtr)>) SDLGL.__\u003Cjniptr\u003EglUniformMatrix3fv\u0028IIZLjava\u002Fnio\u002FFloatBuffer\u003B\u0029V)(num2, (bool) num3, num4, num5, (IntPtr) num6, num7);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glUniformMatrix3fv(int i1, int i2, bool b, float[] farr, int i3)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglUniformMatrix3fv\u0028IIZ\u005BFI\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglUniformMatrix3fv\u0028IIZ\u005BFI\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glUniformMatrix3fv), "(IIZ[FI)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i1;
        int num5 = i2;
        int num6 = b ? 1 : 0;
        IntPtr num7 = ((JNI.Frame) ref frame).MakeLocalRef((object) farr);
        int num8 = i3;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, int, bool, IntPtr, int)>) SDLGL.__\u003Cjniptr\u003EglUniformMatrix3fv\u0028IIZ\u005BFI\u0029V)((int) num2, num3, num4 != 0, num5, num6, num7, (IntPtr) num8);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glUniformMatrix4fv(int i1, int i2, bool b, FloatBuffer fb)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglUniformMatrix4fv\u0028IIZLjava\u002Fnio\u002FFloatBuffer\u003B\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglUniformMatrix4fv\u0028IIZLjava\u002Fnio\u002FFloatBuffer\u003B\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glUniformMatrix4fv), "(IIZLjava/nio/FloatBuffer;)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i1;
        int num5 = i2;
        int num6 = b ? 1 : 0;
        IntPtr num7 = ((JNI.Frame) ref frame).MakeLocalRef((object) fb);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, int, bool, IntPtr)>) SDLGL.__\u003Cjniptr\u003EglUniformMatrix4fv\u0028IIZLjava\u002Fnio\u002FFloatBuffer\u003B\u0029V)(num2, (bool) num3, num4, num5, (IntPtr) num6, num7);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glUniformMatrix4fv(int i1, int i2, bool b, float[] farr, int i3)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglUniformMatrix4fv\u0028IIZ\u005BFI\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglUniformMatrix4fv\u0028IIZ\u005BFI\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glUniformMatrix4fv), "(IIZ[FI)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i1;
        int num5 = i2;
        int num6 = b ? 1 : 0;
        IntPtr num7 = ((JNI.Frame) ref frame).MakeLocalRef((object) farr);
        int num8 = i3;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, int, bool, IntPtr, int)>) SDLGL.__\u003Cjniptr\u003EglUniformMatrix4fv\u0028IIZ\u005BFI\u0029V)((int) num2, num3, num4 != 0, num5, num6, num7, (IntPtr) num8);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glUseProgram(int i)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglUseProgram\u0028I\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglUseProgram\u0028I\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glUseProgram), "(I)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int)>) SDLGL.__\u003Cjniptr\u003EglUseProgram\u0028I\u0029V)((int) num2, num3, (IntPtr) num4);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glValidateProgram(int i)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglValidateProgram\u0028I\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglValidateProgram\u0028I\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glValidateProgram), "(I)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int)>) SDLGL.__\u003Cjniptr\u003EglValidateProgram\u0028I\u0029V)((int) num2, num3, (IntPtr) num4);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glVertexAttrib1f(int i, float f)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglVertexAttrib1f\u0028IF\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglVertexAttrib1f\u0028IF\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glVertexAttrib1f), "(IF)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i;
        double num5 = (double) f;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, float)>) SDLGL.__\u003Cjniptr\u003EglVertexAttrib1f\u0028IF\u0029V)((float) num2, (int) num3, (IntPtr) num4, (IntPtr) num5);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glVertexAttrib1fv(int i, FloatBuffer fb)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglVertexAttrib1fv\u0028ILjava\u002Fnio\u002FFloatBuffer\u003B\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglVertexAttrib1fv\u0028ILjava\u002Fnio\u002FFloatBuffer\u003B\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glVertexAttrib1fv), "(ILjava/nio/FloatBuffer;)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i;
        IntPtr num5 = ((JNI.Frame) ref frame).MakeLocalRef((object) fb);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, IntPtr)>) SDLGL.__\u003Cjniptr\u003EglVertexAttrib1fv\u0028ILjava\u002Fnio\u002FFloatBuffer\u003B\u0029V)(num2, (int) num3, (IntPtr) num4, num5);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glVertexAttrib2f(int i, float f1, float f2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglVertexAttrib2f\u0028IFF\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglVertexAttrib2f\u0028IFF\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glVertexAttrib2f), "(IFF)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i;
        double num5 = (double) f1;
        double num6 = (double) f2;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, float, float)>) SDLGL.__\u003Cjniptr\u003EglVertexAttrib2f\u0028IFF\u0029V)((float) num2, (float) num3, num4, (IntPtr) num5, (IntPtr) num6);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glVertexAttrib2fv(int i, FloatBuffer fb)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglVertexAttrib2fv\u0028ILjava\u002Fnio\u002FFloatBuffer\u003B\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglVertexAttrib2fv\u0028ILjava\u002Fnio\u002FFloatBuffer\u003B\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glVertexAttrib2fv), "(ILjava/nio/FloatBuffer;)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i;
        IntPtr num5 = ((JNI.Frame) ref frame).MakeLocalRef((object) fb);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, IntPtr)>) SDLGL.__\u003Cjniptr\u003EglVertexAttrib2fv\u0028ILjava\u002Fnio\u002FFloatBuffer\u003B\u0029V)(num2, (int) num3, (IntPtr) num4, num5);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glVertexAttrib3f(int i, float f1, float f2, float f3)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglVertexAttrib3f\u0028IFFF\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglVertexAttrib3f\u0028IFFF\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glVertexAttrib3f), "(IFFF)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i;
        double num5 = (double) f1;
        double num6 = (double) f2;
        double num7 = (double) f3;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, float, float, float)>) SDLGL.__\u003Cjniptr\u003EglVertexAttrib3f\u0028IFFF\u0029V)((float) num2, (float) num3, (float) num4, (int) num5, (IntPtr) num6, (IntPtr) num7);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glVertexAttrib3fv(int i, FloatBuffer fb)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglVertexAttrib3fv\u0028ILjava\u002Fnio\u002FFloatBuffer\u003B\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglVertexAttrib3fv\u0028ILjava\u002Fnio\u002FFloatBuffer\u003B\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glVertexAttrib3fv), "(ILjava/nio/FloatBuffer;)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i;
        IntPtr num5 = ((JNI.Frame) ref frame).MakeLocalRef((object) fb);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, IntPtr)>) SDLGL.__\u003Cjniptr\u003EglVertexAttrib3fv\u0028ILjava\u002Fnio\u002FFloatBuffer\u003B\u0029V)(num2, (int) num3, (IntPtr) num4, num5);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glVertexAttrib4f(int i, float f1, float f2, float f3, float f4)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglVertexAttrib4f\u0028IFFFF\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglVertexAttrib4f\u0028IFFFF\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glVertexAttrib4f), "(IFFFF)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i;
        double num5 = (double) f1;
        double num6 = (double) f2;
        double num7 = (double) f3;
        double num8 = (double) f4;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, float, float, float, float)>) SDLGL.__\u003Cjniptr\u003EglVertexAttrib4f\u0028IFFFF\u0029V)((float) num2, (float) num3, (float) num4, (float) num5, (int) num6, (IntPtr) num7, (IntPtr) num8);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glVertexAttrib4fv(int i, FloatBuffer fb)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglVertexAttrib4fv\u0028ILjava\u002Fnio\u002FFloatBuffer\u003B\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglVertexAttrib4fv\u0028ILjava\u002Fnio\u002FFloatBuffer\u003B\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glVertexAttrib4fv), "(ILjava/nio/FloatBuffer;)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i;
        IntPtr num5 = ((JNI.Frame) ref frame).MakeLocalRef((object) fb);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, IntPtr)>) SDLGL.__\u003Cjniptr\u003EglVertexAttrib4fv\u0028ILjava\u002Fnio\u002FFloatBuffer\u003B\u0029V)(num2, (int) num3, (IntPtr) num4, num5);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glVertexAttribPointer(int i1, int i2, int i3, bool b, int i4, object obj)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglVertexAttribPointer\u0028IIIZILjava\u002Flang\u002FObject\u003B\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglVertexAttribPointer\u0028IIIZILjava\u002Flang\u002FObject\u003B\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glVertexAttribPointer), "(IIIZILjava/lang/Object;)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i1;
        int num5 = i2;
        int num6 = i3;
        int num7 = b ? 1 : 0;
        int num8 = i4;
        IntPtr num9 = ((JNI.Frame) ref frame).MakeLocalRef(obj);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, int, int, bool, int, IntPtr)>) SDLGL.__\u003Cjniptr\u003EglVertexAttribPointer\u0028IIIZILjava\u002Flang\u002FObject\u003B\u0029V)(num2, (int) num3, num4 != 0, num5, num6, num7, (IntPtr) num8, num9);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glVertexAttribPointer(int i1, int i2, int i3, bool b, int i4, int i5)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglVertexAttribPointer\u0028IIIZII\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglVertexAttribPointer\u0028IIIZII\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glVertexAttribPointer), "(IIIZII)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i1;
        int num5 = i2;
        int num6 = i3;
        int num7 = b ? 1 : 0;
        int num8 = i4;
        int num9 = i5;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, int, int, bool, int, int)>) SDLGL.__\u003Cjniptr\u003EglVertexAttribPointer\u0028IIIZII\u0029V)((int) num2, (int) num3, num4 != 0, num5, num6, num7, (IntPtr) num8, (IntPtr) num9);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glReadBuffer(int i)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglReadBuffer\u0028I\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglReadBuffer\u0028I\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glReadBuffer), "(I)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int)>) SDLGL.__\u003Cjniptr\u003EglReadBuffer\u0028I\u0029V)((int) num2, num3, (IntPtr) num4);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glDrawRangeElements(int i1, int i2, int i3, int i4, int i5, int i6)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglDrawRangeElements\u0028IIIIII\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglDrawRangeElements\u0028IIIIII\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glDrawRangeElements), "(IIIIII)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i1;
        int num5 = i2;
        int num6 = i3;
        int num7 = i4;
        int num8 = i5;
        int num9 = i6;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, int, int, int, int, int)>) SDLGL.__\u003Cjniptr\u003EglDrawRangeElements\u0028IIIIII\u0029V)((int) num2, (int) num3, num4, num5, num6, num7, (IntPtr) num8, (IntPtr) num9);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glDrawRangeElements(int i1, int i2, int i3, int i4, int i5, Buffer b)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglDrawRangeElements\u0028IIIIILjava\u002Fnio\u002FBuffer\u003B\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglDrawRangeElements\u0028IIIIILjava\u002Fnio\u002FBuffer\u003B\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glDrawRangeElements), "(IIIIILjava/nio/Buffer;)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i1;
        int num5 = i2;
        int num6 = i3;
        int num7 = i4;
        int num8 = i5;
        IntPtr num9 = ((JNI.Frame) ref frame).MakeLocalRef((object) b);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, int, int, int, int, IntPtr)>) SDLGL.__\u003Cjniptr\u003EglDrawRangeElements\u0028IIIIILjava\u002Fnio\u002FBuffer\u003B\u0029V)(num2, (int) num3, num4, num5, num6, num7, (IntPtr) num8, num9);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glTexImage3D(
      int i1,
      int i2,
      int i3,
      int i4,
      int i5,
      int i6,
      int i7,
      int i8,
      int i9,
      int i10)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglTexImage3D\u0028IIIIIIIIII\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglTexImage3D\u0028IIIIIIIIII\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glTexImage3D), "(IIIIIIIIII)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i1;
        int num5 = i2;
        int num6 = i3;
        int num7 = i4;
        int num8 = i5;
        int num9 = i6;
        int num10 = i7;
        int num11 = i8;
        int num12 = i9;
        int num13 = i10;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, int, int, int, int, int, int, int, int, int)>) SDLGL.__\u003Cjniptr\u003EglTexImage3D\u0028IIIIIIIIII\u0029V)((int) num2, (int) num3, num4, num5, num6, num7, num8, num9, num10, num11, (IntPtr) num12, (IntPtr) num13);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glTexImage3D(
      int i1,
      int i2,
      int i3,
      int i4,
      int i5,
      int i6,
      int i7,
      int i8,
      int i9,
      Buffer b)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglTexImage3D\u0028IIIIIIIIILjava\u002Fnio\u002FBuffer\u003B\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglTexImage3D\u0028IIIIIIIIILjava\u002Fnio\u002FBuffer\u003B\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glTexImage3D), "(IIIIIIIIILjava/nio/Buffer;)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i1;
        int num5 = i2;
        int num6 = i3;
        int num7 = i4;
        int num8 = i5;
        int num9 = i6;
        int num10 = i7;
        int num11 = i8;
        int num12 = i9;
        IntPtr num13 = ((JNI.Frame) ref frame).MakeLocalRef((object) b);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, int, int, int, int, int, int, int, int, IntPtr)>) SDLGL.__\u003Cjniptr\u003EglTexImage3D\u0028IIIIIIIIILjava\u002Fnio\u002FBuffer\u003B\u0029V)(num2, (int) num3, num4, num5, num6, num7, num8, num9, num10, num11, (IntPtr) num12, num13);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glTexSubImage3D(
      int i1,
      int i2,
      int i3,
      int i4,
      int i5,
      int i6,
      int i7,
      int i8,
      int i9,
      int i10,
      int i11)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglTexSubImage3D\u0028IIIIIIIIIII\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglTexSubImage3D\u0028IIIIIIIIIII\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glTexSubImage3D), "(IIIIIIIIIII)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i1;
        int num5 = i2;
        int num6 = i3;
        int num7 = i4;
        int num8 = i5;
        int num9 = i6;
        int num10 = i7;
        int num11 = i8;
        int num12 = i9;
        int num13 = i10;
        int num14 = i11;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, int, int, int, int, int, int, int, int, int, int)>) SDLGL.__\u003Cjniptr\u003EglTexSubImage3D\u0028IIIIIIIIIII\u0029V)((int) num2, (int) num3, num4, num5, num6, num7, num8, num9, num10, num11, num12, (IntPtr) num13, (IntPtr) num14);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glTexSubImage3D(
      int i1,
      int i2,
      int i3,
      int i4,
      int i5,
      int i6,
      int i7,
      int i8,
      int i9,
      int i10,
      Buffer b)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglTexSubImage3D\u0028IIIIIIIIIILjava\u002Fnio\u002FBuffer\u003B\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglTexSubImage3D\u0028IIIIIIIIIILjava\u002Fnio\u002FBuffer\u003B\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glTexSubImage3D), "(IIIIIIIIIILjava/nio/Buffer;)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i1;
        int num5 = i2;
        int num6 = i3;
        int num7 = i4;
        int num8 = i5;
        int num9 = i6;
        int num10 = i7;
        int num11 = i8;
        int num12 = i9;
        int num13 = i10;
        IntPtr num14 = ((JNI.Frame) ref frame).MakeLocalRef((object) b);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, int, int, int, int, int, int, int, int, int, IntPtr)>) SDLGL.__\u003Cjniptr\u003EglTexSubImage3D\u0028IIIIIIIIIILjava\u002Fnio\u002FBuffer\u003B\u0029V)(num2, (int) num3, num4, num5, num6, num7, num8, num9, num10, num11, num12, (IntPtr) num13, num14);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glCopyTexSubImage3D(
      int i1,
      int i2,
      int i3,
      int i4,
      int i5,
      int i6,
      int i7,
      int i8,
      int i9)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglCopyTexSubImage3D\u0028IIIIIIIII\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglCopyTexSubImage3D\u0028IIIIIIIII\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glCopyTexSubImage3D), "(IIIIIIIII)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i1;
        int num5 = i2;
        int num6 = i3;
        int num7 = i4;
        int num8 = i5;
        int num9 = i6;
        int num10 = i7;
        int num11 = i8;
        int num12 = i9;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, int, int, int, int, int, int, int, int)>) SDLGL.__\u003Cjniptr\u003EglCopyTexSubImage3D\u0028IIIIIIIII\u0029V)((int) num2, (int) num3, num4, num5, num6, num7, num8, num9, num10, (IntPtr) num11, (IntPtr) num12);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glGenQueries(int i, IntBuffer ib)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglGenQueries\u0028ILjava\u002Fnio\u002FIntBuffer\u003B\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglGenQueries\u0028ILjava\u002Fnio\u002FIntBuffer\u003B\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glGenQueries), "(ILjava/nio/IntBuffer;)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i;
        IntPtr num5 = ((JNI.Frame) ref frame).MakeLocalRef((object) ib);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, IntPtr)>) SDLGL.__\u003Cjniptr\u003EglGenQueries\u0028ILjava\u002Fnio\u002FIntBuffer\u003B\u0029V)(num2, (int) num3, (IntPtr) num4, num5);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glDeleteQueries(int i, IntBuffer ib)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglDeleteQueries\u0028ILjava\u002Fnio\u002FIntBuffer\u003B\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglDeleteQueries\u0028ILjava\u002Fnio\u002FIntBuffer\u003B\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glDeleteQueries), "(ILjava/nio/IntBuffer;)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i;
        IntPtr num5 = ((JNI.Frame) ref frame).MakeLocalRef((object) ib);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, IntPtr)>) SDLGL.__\u003Cjniptr\u003EglDeleteQueries\u0028ILjava\u002Fnio\u002FIntBuffer\u003B\u0029V)(num2, (int) num3, (IntPtr) num4, num5);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static bool glIsQuery(int i)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglIsQuery\u0028I\u0029Z == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglIsQuery\u0028I\u0029Z = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glIsQuery), "(I)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, int)>) SDLGL.__\u003Cjniptr\u003EglIsQuery\u0028I\u0029Z)((int) num2, num3, (IntPtr) num4);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glBeginQuery(int i1, int i2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglBeginQuery\u0028II\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglBeginQuery\u0028II\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glBeginQuery), "(II)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i1;
        int num5 = i2;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, int)>) SDLGL.__\u003Cjniptr\u003EglBeginQuery\u0028II\u0029V)((int) num2, (int) num3, (IntPtr) num4, (IntPtr) num5);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glEndQuery(int i)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglEndQuery\u0028I\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglEndQuery\u0028I\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glEndQuery), "(I)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int)>) SDLGL.__\u003Cjniptr\u003EglEndQuery\u0028I\u0029V)((int) num2, num3, (IntPtr) num4);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glGetQueryiv(int i1, int i2, IntBuffer ib)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglGetQueryiv\u0028IILjava\u002Fnio\u002FIntBuffer\u003B\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglGetQueryiv\u0028IILjava\u002Fnio\u002FIntBuffer\u003B\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glGetQueryiv), "(IILjava/nio/IntBuffer;)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i1;
        int num5 = i2;
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) ib);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, int, IntPtr)>) SDLGL.__\u003Cjniptr\u003EglGetQueryiv\u0028IILjava\u002Fnio\u002FIntBuffer\u003B\u0029V)(num2, (int) num3, num4, (IntPtr) num5, num6);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glGetQueryObjectuiv(int i1, int i2, IntBuffer ib)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglGetQueryObjectuiv\u0028IILjava\u002Fnio\u002FIntBuffer\u003B\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglGetQueryObjectuiv\u0028IILjava\u002Fnio\u002FIntBuffer\u003B\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glGetQueryObjectuiv), "(IILjava/nio/IntBuffer;)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i1;
        int num5 = i2;
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) ib);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, int, IntPtr)>) SDLGL.__\u003Cjniptr\u003EglGetQueryObjectuiv\u0028IILjava\u002Fnio\u002FIntBuffer\u003B\u0029V)(num2, (int) num3, num4, (IntPtr) num5, num6);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static bool glUnmapBuffer(int i)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglUnmapBuffer\u0028I\u0029Z == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglUnmapBuffer\u0028I\u0029Z = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glUnmapBuffer), "(I)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, int)>) SDLGL.__\u003Cjniptr\u003EglUnmapBuffer\u0028I\u0029Z)((int) num2, num3, (IntPtr) num4);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static Buffer glGetBufferPointerv(int i1, int i2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglGetBufferPointerv\u0028II\u0029Ljava\u002Fnio\u002FBuffer\u003B == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglGetBufferPointerv\u0028II\u0029Ljava\u002Fnio\u002FBuffer\u003B = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glGetBufferPointerv), "(II)Ljava/nio/Buffer;");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        ref JNI.Frame local = ref frame;
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i1;
        int num5 = i2;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        IntPtr num6 = __calli((__FnPtr<IntPtr (IntPtr, IntPtr, int, int)>) SDLGL.__\u003Cjniptr\u003EglGetBufferPointerv\u0028II\u0029Ljava\u002Fnio\u002FBuffer\u003B)((int) num2, (int) num3, (IntPtr) num4, (IntPtr) num5);
        return (Buffer) ((JNI.Frame) ref local).UnwrapLocalRef(num6);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glDrawBuffers(int i, IntBuffer ib)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglDrawBuffers\u0028ILjava\u002Fnio\u002FIntBuffer\u003B\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglDrawBuffers\u0028ILjava\u002Fnio\u002FIntBuffer\u003B\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glDrawBuffers), "(ILjava/nio/IntBuffer;)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i;
        IntPtr num5 = ((JNI.Frame) ref frame).MakeLocalRef((object) ib);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, IntPtr)>) SDLGL.__\u003Cjniptr\u003EglDrawBuffers\u0028ILjava\u002Fnio\u002FIntBuffer\u003B\u0029V)(num2, (int) num3, (IntPtr) num4, num5);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glUniformMatrix2x3fv(int i1, int i2, bool b, FloatBuffer fb)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglUniformMatrix2x3fv\u0028IIZLjava\u002Fnio\u002FFloatBuffer\u003B\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglUniformMatrix2x3fv\u0028IIZLjava\u002Fnio\u002FFloatBuffer\u003B\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glUniformMatrix2x3fv), "(IIZLjava/nio/FloatBuffer;)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i1;
        int num5 = i2;
        int num6 = b ? 1 : 0;
        IntPtr num7 = ((JNI.Frame) ref frame).MakeLocalRef((object) fb);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, int, bool, IntPtr)>) SDLGL.__\u003Cjniptr\u003EglUniformMatrix2x3fv\u0028IIZLjava\u002Fnio\u002FFloatBuffer\u003B\u0029V)(num2, (bool) num3, num4, num5, (IntPtr) num6, num7);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glUniformMatrix3x2fv(int i1, int i2, bool b, FloatBuffer fb)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglUniformMatrix3x2fv\u0028IIZLjava\u002Fnio\u002FFloatBuffer\u003B\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglUniformMatrix3x2fv\u0028IIZLjava\u002Fnio\u002FFloatBuffer\u003B\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glUniformMatrix3x2fv), "(IIZLjava/nio/FloatBuffer;)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i1;
        int num5 = i2;
        int num6 = b ? 1 : 0;
        IntPtr num7 = ((JNI.Frame) ref frame).MakeLocalRef((object) fb);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, int, bool, IntPtr)>) SDLGL.__\u003Cjniptr\u003EglUniformMatrix3x2fv\u0028IIZLjava\u002Fnio\u002FFloatBuffer\u003B\u0029V)(num2, (bool) num3, num4, num5, (IntPtr) num6, num7);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glUniformMatrix2x4fv(int i1, int i2, bool b, FloatBuffer fb)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglUniformMatrix2x4fv\u0028IIZLjava\u002Fnio\u002FFloatBuffer\u003B\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglUniformMatrix2x4fv\u0028IIZLjava\u002Fnio\u002FFloatBuffer\u003B\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glUniformMatrix2x4fv), "(IIZLjava/nio/FloatBuffer;)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i1;
        int num5 = i2;
        int num6 = b ? 1 : 0;
        IntPtr num7 = ((JNI.Frame) ref frame).MakeLocalRef((object) fb);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, int, bool, IntPtr)>) SDLGL.__\u003Cjniptr\u003EglUniformMatrix2x4fv\u0028IIZLjava\u002Fnio\u002FFloatBuffer\u003B\u0029V)(num2, (bool) num3, num4, num5, (IntPtr) num6, num7);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glUniformMatrix4x2fv(int i1, int i2, bool b, FloatBuffer fb)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglUniformMatrix4x2fv\u0028IIZLjava\u002Fnio\u002FFloatBuffer\u003B\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglUniformMatrix4x2fv\u0028IIZLjava\u002Fnio\u002FFloatBuffer\u003B\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glUniformMatrix4x2fv), "(IIZLjava/nio/FloatBuffer;)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i1;
        int num5 = i2;
        int num6 = b ? 1 : 0;
        IntPtr num7 = ((JNI.Frame) ref frame).MakeLocalRef((object) fb);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, int, bool, IntPtr)>) SDLGL.__\u003Cjniptr\u003EglUniformMatrix4x2fv\u0028IIZLjava\u002Fnio\u002FFloatBuffer\u003B\u0029V)(num2, (bool) num3, num4, num5, (IntPtr) num6, num7);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glUniformMatrix3x4fv(int i1, int i2, bool b, FloatBuffer fb)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglUniformMatrix3x4fv\u0028IIZLjava\u002Fnio\u002FFloatBuffer\u003B\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglUniformMatrix3x4fv\u0028IIZLjava\u002Fnio\u002FFloatBuffer\u003B\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glUniformMatrix3x4fv), "(IIZLjava/nio/FloatBuffer;)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i1;
        int num5 = i2;
        int num6 = b ? 1 : 0;
        IntPtr num7 = ((JNI.Frame) ref frame).MakeLocalRef((object) fb);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, int, bool, IntPtr)>) SDLGL.__\u003Cjniptr\u003EglUniformMatrix3x4fv\u0028IIZLjava\u002Fnio\u002FFloatBuffer\u003B\u0029V)(num2, (bool) num3, num4, num5, (IntPtr) num6, num7);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glUniformMatrix4x3fv(int i1, int i2, bool b, FloatBuffer fb)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglUniformMatrix4x3fv\u0028IIZLjava\u002Fnio\u002FFloatBuffer\u003B\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglUniformMatrix4x3fv\u0028IIZLjava\u002Fnio\u002FFloatBuffer\u003B\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glUniformMatrix4x3fv), "(IIZLjava/nio/FloatBuffer;)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i1;
        int num5 = i2;
        int num6 = b ? 1 : 0;
        IntPtr num7 = ((JNI.Frame) ref frame).MakeLocalRef((object) fb);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, int, bool, IntPtr)>) SDLGL.__\u003Cjniptr\u003EglUniformMatrix4x3fv\u0028IIZLjava\u002Fnio\u002FFloatBuffer\u003B\u0029V)(num2, (bool) num3, num4, num5, (IntPtr) num6, num7);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glBlitFramebuffer(
      int i1,
      int i2,
      int i3,
      int i4,
      int i5,
      int i6,
      int i7,
      int i8,
      int i9,
      int i10)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglBlitFramebuffer\u0028IIIIIIIIII\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglBlitFramebuffer\u0028IIIIIIIIII\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glBlitFramebuffer), "(IIIIIIIIII)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i1;
        int num5 = i2;
        int num6 = i3;
        int num7 = i4;
        int num8 = i5;
        int num9 = i6;
        int num10 = i7;
        int num11 = i8;
        int num12 = i9;
        int num13 = i10;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, int, int, int, int, int, int, int, int, int)>) SDLGL.__\u003Cjniptr\u003EglBlitFramebuffer\u0028IIIIIIIIII\u0029V)((int) num2, (int) num3, num4, num5, num6, num7, num8, num9, num10, num11, (IntPtr) num12, (IntPtr) num13);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glRenderbufferStorageMultisample(int i1, int i2, int i3, int i4, int i5)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglRenderbufferStorageMultisample\u0028IIIII\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglRenderbufferStorageMultisample\u0028IIIII\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glRenderbufferStorageMultisample), "(IIIII)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i1;
        int num5 = i2;
        int num6 = i3;
        int num7 = i4;
        int num8 = i5;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, int, int, int, int)>) SDLGL.__\u003Cjniptr\u003EglRenderbufferStorageMultisample\u0028IIIII\u0029V)((int) num2, (int) num3, num4, num5, num6, (IntPtr) num7, (IntPtr) num8);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glFramebufferTextureLayer(int i1, int i2, int i3, int i4, int i5)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglFramebufferTextureLayer\u0028IIIII\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglFramebufferTextureLayer\u0028IIIII\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glFramebufferTextureLayer), "(IIIII)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i1;
        int num5 = i2;
        int num6 = i3;
        int num7 = i4;
        int num8 = i5;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, int, int, int, int)>) SDLGL.__\u003Cjniptr\u003EglFramebufferTextureLayer\u0028IIIII\u0029V)((int) num2, (int) num3, num4, num5, num6, (IntPtr) num7, (IntPtr) num8);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glFlushMappedBufferRange(int i1, int i2, int i3)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglFlushMappedBufferRange\u0028III\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglFlushMappedBufferRange\u0028III\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glFlushMappedBufferRange), "(III)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i1;
        int num5 = i2;
        int num6 = i3;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, int, int)>) SDLGL.__\u003Cjniptr\u003EglFlushMappedBufferRange\u0028III\u0029V)((int) num2, (int) num3, num4, (IntPtr) num5, (IntPtr) num6);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glBindVertexArray(int i)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglBindVertexArray\u0028I\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglBindVertexArray\u0028I\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glBindVertexArray), "(I)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int)>) SDLGL.__\u003Cjniptr\u003EglBindVertexArray\u0028I\u0029V)((int) num2, num3, (IntPtr) num4);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glDeleteVertexArrays(int i, IntBuffer ib)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglDeleteVertexArrays\u0028ILjava\u002Fnio\u002FIntBuffer\u003B\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglDeleteVertexArrays\u0028ILjava\u002Fnio\u002FIntBuffer\u003B\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glDeleteVertexArrays), "(ILjava/nio/IntBuffer;)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i;
        IntPtr num5 = ((JNI.Frame) ref frame).MakeLocalRef((object) ib);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, IntPtr)>) SDLGL.__\u003Cjniptr\u003EglDeleteVertexArrays\u0028ILjava\u002Fnio\u002FIntBuffer\u003B\u0029V)(num2, (int) num3, (IntPtr) num4, num5);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glGenVertexArrays(int i, IntBuffer ib)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglGenVertexArrays\u0028ILjava\u002Fnio\u002FIntBuffer\u003B\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglGenVertexArrays\u0028ILjava\u002Fnio\u002FIntBuffer\u003B\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glGenVertexArrays), "(ILjava/nio/IntBuffer;)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i;
        IntPtr num5 = ((JNI.Frame) ref frame).MakeLocalRef((object) ib);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, IntPtr)>) SDLGL.__\u003Cjniptr\u003EglGenVertexArrays\u0028ILjava\u002Fnio\u002FIntBuffer\u003B\u0029V)(num2, (int) num3, (IntPtr) num4, num5);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static bool glIsVertexArray(int i)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglIsVertexArray\u0028I\u0029Z == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglIsVertexArray\u0028I\u0029Z = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glIsVertexArray), "(I)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, int)>) SDLGL.__\u003Cjniptr\u003EglIsVertexArray\u0028I\u0029Z)((int) num2, num3, (IntPtr) num4);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glBeginTransformFeedback(int i)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglBeginTransformFeedback\u0028I\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglBeginTransformFeedback\u0028I\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glBeginTransformFeedback), "(I)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int)>) SDLGL.__\u003Cjniptr\u003EglBeginTransformFeedback\u0028I\u0029V)((int) num2, num3, (IntPtr) num4);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glEndTransformFeedback()
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglEndTransformFeedback\u0028\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglEndTransformFeedback\u0028\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glEndTransformFeedback), "()V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr)>) SDLGL.__\u003Cjniptr\u003EglEndTransformFeedback\u0028\u0029V)(num2, num3);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glBindBufferRange(int i1, int i2, int i3, int i4, int i5)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglBindBufferRange\u0028IIIII\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglBindBufferRange\u0028IIIII\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glBindBufferRange), "(IIIII)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i1;
        int num5 = i2;
        int num6 = i3;
        int num7 = i4;
        int num8 = i5;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, int, int, int, int)>) SDLGL.__\u003Cjniptr\u003EglBindBufferRange\u0028IIIII\u0029V)((int) num2, (int) num3, num4, num5, num6, (IntPtr) num7, (IntPtr) num8);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glBindBufferBase(int i1, int i2, int i3)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglBindBufferBase\u0028III\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglBindBufferBase\u0028III\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glBindBufferBase), "(III)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i1;
        int num5 = i2;
        int num6 = i3;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, int, int)>) SDLGL.__\u003Cjniptr\u003EglBindBufferBase\u0028III\u0029V)((int) num2, (int) num3, num4, (IntPtr) num5, (IntPtr) num6);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glTransformFeedbackVaryings(int i1, string[] strarr, int i2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglTransformFeedbackVaryings\u0028I\u005BLjava\u002Flang\u002FString\u003BI\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglTransformFeedbackVaryings\u0028I\u005BLjava\u002Flang\u002FString\u003BI\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glTransformFeedbackVaryings), "(I[Ljava/lang/String;I)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i1;
        IntPtr num5 = ((JNI.Frame) ref frame).MakeLocalRef((object) strarr);
        int num6 = i2;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, IntPtr, int)>) SDLGL.__\u003Cjniptr\u003EglTransformFeedbackVaryings\u0028I\u005BLjava\u002Flang\u002FString\u003BI\u0029V)((int) num2, num3, num4, num5, (IntPtr) num6);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glVertexAttribIPointer(int i1, int i2, int i3, int i4, int i5)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglVertexAttribIPointer\u0028IIIII\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglVertexAttribIPointer\u0028IIIII\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glVertexAttribIPointer), "(IIIII)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i1;
        int num5 = i2;
        int num6 = i3;
        int num7 = i4;
        int num8 = i5;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, int, int, int, int)>) SDLGL.__\u003Cjniptr\u003EglVertexAttribIPointer\u0028IIIII\u0029V)((int) num2, (int) num3, num4, num5, num6, (IntPtr) num7, (IntPtr) num8);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glGetVertexAttribIiv(int i1, int i2, IntBuffer ib)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglGetVertexAttribIiv\u0028IILjava\u002Fnio\u002FIntBuffer\u003B\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglGetVertexAttribIiv\u0028IILjava\u002Fnio\u002FIntBuffer\u003B\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glGetVertexAttribIiv), "(IILjava/nio/IntBuffer;)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i1;
        int num5 = i2;
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) ib);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, int, IntPtr)>) SDLGL.__\u003Cjniptr\u003EglGetVertexAttribIiv\u0028IILjava\u002Fnio\u002FIntBuffer\u003B\u0029V)(num2, (int) num3, num4, (IntPtr) num5, num6);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glGetVertexAttribIuiv(int i1, int i2, IntBuffer ib)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglGetVertexAttribIuiv\u0028IILjava\u002Fnio\u002FIntBuffer\u003B\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglGetVertexAttribIuiv\u0028IILjava\u002Fnio\u002FIntBuffer\u003B\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glGetVertexAttribIuiv), "(IILjava/nio/IntBuffer;)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i1;
        int num5 = i2;
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) ib);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, int, IntPtr)>) SDLGL.__\u003Cjniptr\u003EglGetVertexAttribIuiv\u0028IILjava\u002Fnio\u002FIntBuffer\u003B\u0029V)(num2, (int) num3, num4, (IntPtr) num5, num6);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glVertexAttribI4i(int i1, int i2, int i3, int i4, int i5)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglVertexAttribI4i\u0028IIIII\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglVertexAttribI4i\u0028IIIII\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glVertexAttribI4i), "(IIIII)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i1;
        int num5 = i2;
        int num6 = i3;
        int num7 = i4;
        int num8 = i5;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, int, int, int, int)>) SDLGL.__\u003Cjniptr\u003EglVertexAttribI4i\u0028IIIII\u0029V)((int) num2, (int) num3, num4, num5, num6, (IntPtr) num7, (IntPtr) num8);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glVertexAttribI4ui(int i1, int i2, int i3, int i4, int i5)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglVertexAttribI4ui\u0028IIIII\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglVertexAttribI4ui\u0028IIIII\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glVertexAttribI4ui), "(IIIII)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i1;
        int num5 = i2;
        int num6 = i3;
        int num7 = i4;
        int num8 = i5;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, int, int, int, int)>) SDLGL.__\u003Cjniptr\u003EglVertexAttribI4ui\u0028IIIII\u0029V)((int) num2, (int) num3, num4, num5, num6, (IntPtr) num7, (IntPtr) num8);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glGetUniformuiv(int i1, int i2, IntBuffer ib)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglGetUniformuiv\u0028IILjava\u002Fnio\u002FIntBuffer\u003B\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglGetUniformuiv\u0028IILjava\u002Fnio\u002FIntBuffer\u003B\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glGetUniformuiv), "(IILjava/nio/IntBuffer;)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i1;
        int num5 = i2;
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) ib);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, int, IntPtr)>) SDLGL.__\u003Cjniptr\u003EglGetUniformuiv\u0028IILjava\u002Fnio\u002FIntBuffer\u003B\u0029V)(num2, (int) num3, num4, (IntPtr) num5, num6);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static int glGetFragDataLocation(int i, string str)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglGetFragDataLocation\u0028ILjava\u002Flang\u002FString\u003B\u0029I == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglGetFragDataLocation\u0028ILjava\u002Flang\u002FString\u003B\u0029I = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glGetFragDataLocation), "(ILjava/lang/String;)I");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i;
        IntPtr num5 = ((JNI.Frame) ref frame).MakeLocalRef((object) str);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<int (IntPtr, IntPtr, int, IntPtr)>) SDLGL.__\u003Cjniptr\u003EglGetFragDataLocation\u0028ILjava\u002Flang\u002FString\u003B\u0029I)(num2, (int) num3, (IntPtr) num4, num5);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glUniform1uiv(int i1, int i2, IntBuffer ib)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglUniform1uiv\u0028IILjava\u002Fnio\u002FIntBuffer\u003B\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglUniform1uiv\u0028IILjava\u002Fnio\u002FIntBuffer\u003B\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glUniform1uiv), "(IILjava/nio/IntBuffer;)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i1;
        int num5 = i2;
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) ib);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, int, IntPtr)>) SDLGL.__\u003Cjniptr\u003EglUniform1uiv\u0028IILjava\u002Fnio\u002FIntBuffer\u003B\u0029V)(num2, (int) num3, num4, (IntPtr) num5, num6);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glUniform3uiv(int i1, int i2, IntBuffer ib)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglUniform3uiv\u0028IILjava\u002Fnio\u002FIntBuffer\u003B\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglUniform3uiv\u0028IILjava\u002Fnio\u002FIntBuffer\u003B\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glUniform3uiv), "(IILjava/nio/IntBuffer;)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i1;
        int num5 = i2;
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) ib);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, int, IntPtr)>) SDLGL.__\u003Cjniptr\u003EglUniform3uiv\u0028IILjava\u002Fnio\u002FIntBuffer\u003B\u0029V)(num2, (int) num3, num4, (IntPtr) num5, num6);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glUniform4uiv(int i1, int i2, IntBuffer ib)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglUniform4uiv\u0028IILjava\u002Fnio\u002FIntBuffer\u003B\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglUniform4uiv\u0028IILjava\u002Fnio\u002FIntBuffer\u003B\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glUniform4uiv), "(IILjava/nio/IntBuffer;)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i1;
        int num5 = i2;
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) ib);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, int, IntPtr)>) SDLGL.__\u003Cjniptr\u003EglUniform4uiv\u0028IILjava\u002Fnio\u002FIntBuffer\u003B\u0029V)(num2, (int) num3, num4, (IntPtr) num5, num6);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glClearBufferiv(int i1, int i2, IntBuffer ib)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglClearBufferiv\u0028IILjava\u002Fnio\u002FIntBuffer\u003B\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglClearBufferiv\u0028IILjava\u002Fnio\u002FIntBuffer\u003B\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glClearBufferiv), "(IILjava/nio/IntBuffer;)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i1;
        int num5 = i2;
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) ib);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, int, IntPtr)>) SDLGL.__\u003Cjniptr\u003EglClearBufferiv\u0028IILjava\u002Fnio\u002FIntBuffer\u003B\u0029V)(num2, (int) num3, num4, (IntPtr) num5, num6);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glClearBufferuiv(int i1, int i2, IntBuffer ib)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglClearBufferuiv\u0028IILjava\u002Fnio\u002FIntBuffer\u003B\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglClearBufferuiv\u0028IILjava\u002Fnio\u002FIntBuffer\u003B\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glClearBufferuiv), "(IILjava/nio/IntBuffer;)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i1;
        int num5 = i2;
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) ib);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, int, IntPtr)>) SDLGL.__\u003Cjniptr\u003EglClearBufferuiv\u0028IILjava\u002Fnio\u002FIntBuffer\u003B\u0029V)(num2, (int) num3, num4, (IntPtr) num5, num6);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glClearBufferfv(int i1, int i2, FloatBuffer fb)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglClearBufferfv\u0028IILjava\u002Fnio\u002FFloatBuffer\u003B\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglClearBufferfv\u0028IILjava\u002Fnio\u002FFloatBuffer\u003B\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glClearBufferfv), "(IILjava/nio/FloatBuffer;)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i1;
        int num5 = i2;
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) fb);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, int, IntPtr)>) SDLGL.__\u003Cjniptr\u003EglClearBufferfv\u0028IILjava\u002Fnio\u002FFloatBuffer\u003B\u0029V)(num2, (int) num3, num4, (IntPtr) num5, num6);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glClearBufferfi(int i1, int i2, float f, int i3)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglClearBufferfi\u0028IIFI\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglClearBufferfi\u0028IIFI\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glClearBufferfi), "(IIFI)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i1;
        int num5 = i2;
        double num6 = (double) f;
        int num7 = i3;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, int, float, int)>) SDLGL.__\u003Cjniptr\u003EglClearBufferfi\u0028IIFI\u0029V)((int) num2, (float) num3, num4, num5, (IntPtr) num6, (IntPtr) num7);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static string glGetStringi(int i1, int i2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglGetStringi\u0028II\u0029Ljava\u002Flang\u002FString\u003B == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglGetStringi\u0028II\u0029Ljava\u002Flang\u002FString\u003B = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glGetStringi), "(II)Ljava/lang/String;");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        ref JNI.Frame local = ref frame;
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i1;
        int num5 = i2;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        IntPtr num6 = __calli((__FnPtr<IntPtr (IntPtr, IntPtr, int, int)>) SDLGL.__\u003Cjniptr\u003EglGetStringi\u0028II\u0029Ljava\u002Flang\u002FString\u003B)((int) num2, (int) num3, (IntPtr) num4, (IntPtr) num5);
        return (string) ((JNI.Frame) ref local).UnwrapLocalRef(num6);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glCopyBufferSubData(int i1, int i2, int i3, int i4, int i5)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglCopyBufferSubData\u0028IIIII\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglCopyBufferSubData\u0028IIIII\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glCopyBufferSubData), "(IIIII)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i1;
        int num5 = i2;
        int num6 = i3;
        int num7 = i4;
        int num8 = i5;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, int, int, int, int)>) SDLGL.__\u003Cjniptr\u003EglCopyBufferSubData\u0028IIIII\u0029V)((int) num2, (int) num3, num4, num5, num6, (IntPtr) num7, (IntPtr) num8);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glGetUniformIndices(int i, string[] strarr, IntBuffer ib)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglGetUniformIndices\u0028I\u005BLjava\u002Flang\u002FString\u003BLjava\u002Fnio\u002FIntBuffer\u003B\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglGetUniformIndices\u0028I\u005BLjava\u002Flang\u002FString\u003BLjava\u002Fnio\u002FIntBuffer\u003B\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glGetUniformIndices), "(I[Ljava/lang/String;Ljava/nio/IntBuffer;)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i;
        IntPtr num5 = ((JNI.Frame) ref frame).MakeLocalRef((object) strarr);
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) ib);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, IntPtr, IntPtr)>) SDLGL.__\u003Cjniptr\u003EglGetUniformIndices\u0028I\u005BLjava\u002Flang\u002FString\u003BLjava\u002Fnio\u002FIntBuffer\u003B\u0029V)(num2, num3, num4, num5, num6);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glGetActiveUniformsiv(
      int i1,
      int i2,
      IntBuffer ib1,
      int i3,
      IntBuffer ib2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglGetActiveUniformsiv\u0028IILjava\u002Fnio\u002FIntBuffer\u003BILjava\u002Fnio\u002FIntBuffer\u003B\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglGetActiveUniformsiv\u0028IILjava\u002Fnio\u002FIntBuffer\u003BILjava\u002Fnio\u002FIntBuffer\u003B\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glGetActiveUniformsiv), "(IILjava/nio/IntBuffer;ILjava/nio/IntBuffer;)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i1;
        int num5 = i2;
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) ib1);
        int num7 = i3;
        IntPtr num8 = ((JNI.Frame) ref frame).MakeLocalRef((object) ib2);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, int, IntPtr, int, IntPtr)>) SDLGL.__\u003Cjniptr\u003EglGetActiveUniformsiv\u0028IILjava\u002Fnio\u002FIntBuffer\u003BILjava\u002Fnio\u002FIntBuffer\u003B\u0029V)(num2, (int) num3, (IntPtr) num4, num5, (int) num6, (IntPtr) num7, num8);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static int glGetUniformBlockIndex(int i, string str)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglGetUniformBlockIndex\u0028ILjava\u002Flang\u002FString\u003B\u0029I == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglGetUniformBlockIndex\u0028ILjava\u002Flang\u002FString\u003B\u0029I = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glGetUniformBlockIndex), "(ILjava/lang/String;)I");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i;
        IntPtr num5 = ((JNI.Frame) ref frame).MakeLocalRef((object) str);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<int (IntPtr, IntPtr, int, IntPtr)>) SDLGL.__\u003Cjniptr\u003EglGetUniformBlockIndex\u0028ILjava\u002Flang\u002FString\u003B\u0029I)(num2, (int) num3, (IntPtr) num4, num5);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glGetActiveUniformBlockiv(int i1, int i2, int i3, IntBuffer ib)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglGetActiveUniformBlockiv\u0028IIILjava\u002Fnio\u002FIntBuffer\u003B\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglGetActiveUniformBlockiv\u0028IIILjava\u002Fnio\u002FIntBuffer\u003B\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glGetActiveUniformBlockiv), "(IIILjava/nio/IntBuffer;)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i1;
        int num5 = i2;
        int num6 = i3;
        IntPtr num7 = ((JNI.Frame) ref frame).MakeLocalRef((object) ib);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, int, int, IntPtr)>) SDLGL.__\u003Cjniptr\u003EglGetActiveUniformBlockiv\u0028IIILjava\u002Fnio\u002FIntBuffer\u003B\u0029V)(num2, (int) num3, num4, num5, (IntPtr) num6, num7);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glGetActiveUniformBlockName(int i1, int i2, Buffer b1, Buffer b2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglGetActiveUniformBlockName\u0028IILjava\u002Fnio\u002FBuffer\u003BLjava\u002Fnio\u002FBuffer\u003B\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglGetActiveUniformBlockName\u0028IILjava\u002Fnio\u002FBuffer\u003BLjava\u002Fnio\u002FBuffer\u003B\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glGetActiveUniformBlockName), "(IILjava/nio/Buffer;Ljava/nio/Buffer;)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i1;
        int num5 = i2;
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) b1);
        IntPtr num7 = ((JNI.Frame) ref frame).MakeLocalRef((object) b2);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, int, IntPtr, IntPtr)>) SDLGL.__\u003Cjniptr\u003EglGetActiveUniformBlockName\u0028IILjava\u002Fnio\u002FBuffer\u003BLjava\u002Fnio\u002FBuffer\u003B\u0029V)(num2, num3, num4, num5, num6, num7);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glUniformBlockBinding(int i1, int i2, int i3)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglUniformBlockBinding\u0028III\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglUniformBlockBinding\u0028III\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glUniformBlockBinding), "(III)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i1;
        int num5 = i2;
        int num6 = i3;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, int, int)>) SDLGL.__\u003Cjniptr\u003EglUniformBlockBinding\u0028III\u0029V)((int) num2, (int) num3, num4, (IntPtr) num5, (IntPtr) num6);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glDrawArraysInstanced(int i1, int i2, int i3, int i4)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglDrawArraysInstanced\u0028IIII\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglDrawArraysInstanced\u0028IIII\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glDrawArraysInstanced), "(IIII)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i1;
        int num5 = i2;
        int num6 = i3;
        int num7 = i4;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, int, int, int)>) SDLGL.__\u003Cjniptr\u003EglDrawArraysInstanced\u0028IIII\u0029V)((int) num2, (int) num3, num4, num5, (IntPtr) num6, (IntPtr) num7);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glDrawElementsInstanced(int i1, int i2, int i3, int i4, int i5)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglDrawElementsInstanced\u0028IIIII\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglDrawElementsInstanced\u0028IIIII\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glDrawElementsInstanced), "(IIIII)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i1;
        int num5 = i2;
        int num6 = i3;
        int num7 = i4;
        int num8 = i5;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, int, int, int, int)>) SDLGL.__\u003Cjniptr\u003EglDrawElementsInstanced\u0028IIIII\u0029V)((int) num2, (int) num3, num4, num5, num6, (IntPtr) num7, (IntPtr) num8);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glGetInteger64v(int i, LongBuffer lb)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglGetInteger64v\u0028ILjava\u002Fnio\u002FLongBuffer\u003B\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglGetInteger64v\u0028ILjava\u002Fnio\u002FLongBuffer\u003B\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glGetInteger64v), "(ILjava/nio/LongBuffer;)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i;
        IntPtr num5 = ((JNI.Frame) ref frame).MakeLocalRef((object) lb);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, IntPtr)>) SDLGL.__\u003Cjniptr\u003EglGetInteger64v\u0028ILjava\u002Fnio\u002FLongBuffer\u003B\u0029V)(num2, (int) num3, (IntPtr) num4, num5);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glGetBufferParameteri64v(int i1, int i2, LongBuffer lb)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglGetBufferParameteri64v\u0028IILjava\u002Fnio\u002FLongBuffer\u003B\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglGetBufferParameteri64v\u0028IILjava\u002Fnio\u002FLongBuffer\u003B\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glGetBufferParameteri64v), "(IILjava/nio/LongBuffer;)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i1;
        int num5 = i2;
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) lb);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, int, IntPtr)>) SDLGL.__\u003Cjniptr\u003EglGetBufferParameteri64v\u0028IILjava\u002Fnio\u002FLongBuffer\u003B\u0029V)(num2, (int) num3, num4, (IntPtr) num5, num6);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glGenSamplers(int i, IntBuffer ib)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglGenSamplers\u0028ILjava\u002Fnio\u002FIntBuffer\u003B\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglGenSamplers\u0028ILjava\u002Fnio\u002FIntBuffer\u003B\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glGenSamplers), "(ILjava/nio/IntBuffer;)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i;
        IntPtr num5 = ((JNI.Frame) ref frame).MakeLocalRef((object) ib);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, IntPtr)>) SDLGL.__\u003Cjniptr\u003EglGenSamplers\u0028ILjava\u002Fnio\u002FIntBuffer\u003B\u0029V)(num2, (int) num3, (IntPtr) num4, num5);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glDeleteSamplers(int i, IntBuffer ib)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglDeleteSamplers\u0028ILjava\u002Fnio\u002FIntBuffer\u003B\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglDeleteSamplers\u0028ILjava\u002Fnio\u002FIntBuffer\u003B\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glDeleteSamplers), "(ILjava/nio/IntBuffer;)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i;
        IntPtr num5 = ((JNI.Frame) ref frame).MakeLocalRef((object) ib);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, IntPtr)>) SDLGL.__\u003Cjniptr\u003EglDeleteSamplers\u0028ILjava\u002Fnio\u002FIntBuffer\u003B\u0029V)(num2, (int) num3, (IntPtr) num4, num5);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static bool glIsSampler(int i)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglIsSampler\u0028I\u0029Z == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglIsSampler\u0028I\u0029Z = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glIsSampler), "(I)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, int)>) SDLGL.__\u003Cjniptr\u003EglIsSampler\u0028I\u0029Z)((int) num2, num3, (IntPtr) num4);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glBindSampler(int i1, int i2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglBindSampler\u0028II\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglBindSampler\u0028II\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glBindSampler), "(II)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i1;
        int num5 = i2;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, int)>) SDLGL.__\u003Cjniptr\u003EglBindSampler\u0028II\u0029V)((int) num2, (int) num3, (IntPtr) num4, (IntPtr) num5);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glSamplerParameteri(int i1, int i2, int i3)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglSamplerParameteri\u0028III\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglSamplerParameteri\u0028III\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glSamplerParameteri), "(III)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i1;
        int num5 = i2;
        int num6 = i3;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, int, int)>) SDLGL.__\u003Cjniptr\u003EglSamplerParameteri\u0028III\u0029V)((int) num2, (int) num3, num4, (IntPtr) num5, (IntPtr) num6);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glSamplerParameteriv(int i1, int i2, IntBuffer ib)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglSamplerParameteriv\u0028IILjava\u002Fnio\u002FIntBuffer\u003B\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglSamplerParameteriv\u0028IILjava\u002Fnio\u002FIntBuffer\u003B\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glSamplerParameteriv), "(IILjava/nio/IntBuffer;)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i1;
        int num5 = i2;
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) ib);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, int, IntPtr)>) SDLGL.__\u003Cjniptr\u003EglSamplerParameteriv\u0028IILjava\u002Fnio\u002FIntBuffer\u003B\u0029V)(num2, (int) num3, num4, (IntPtr) num5, num6);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glSamplerParameterf(int i1, int i2, float f)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglSamplerParameterf\u0028IIF\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglSamplerParameterf\u0028IIF\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glSamplerParameterf), "(IIF)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i1;
        int num5 = i2;
        double num6 = (double) f;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, int, float)>) SDLGL.__\u003Cjniptr\u003EglSamplerParameterf\u0028IIF\u0029V)((float) num2, (int) num3, num4, (IntPtr) num5, (IntPtr) num6);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glSamplerParameterfv(int i1, int i2, FloatBuffer fb)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglSamplerParameterfv\u0028IILjava\u002Fnio\u002FFloatBuffer\u003B\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglSamplerParameterfv\u0028IILjava\u002Fnio\u002FFloatBuffer\u003B\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glSamplerParameterfv), "(IILjava/nio/FloatBuffer;)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i1;
        int num5 = i2;
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) fb);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, int, IntPtr)>) SDLGL.__\u003Cjniptr\u003EglSamplerParameterfv\u0028IILjava\u002Fnio\u002FFloatBuffer\u003B\u0029V)(num2, (int) num3, num4, (IntPtr) num5, num6);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glGetSamplerParameteriv(int i1, int i2, IntBuffer ib)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglGetSamplerParameteriv\u0028IILjava\u002Fnio\u002FIntBuffer\u003B\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglGetSamplerParameteriv\u0028IILjava\u002Fnio\u002FIntBuffer\u003B\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glGetSamplerParameteriv), "(IILjava/nio/IntBuffer;)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i1;
        int num5 = i2;
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) ib);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, int, IntPtr)>) SDLGL.__\u003Cjniptr\u003EglGetSamplerParameteriv\u0028IILjava\u002Fnio\u002FIntBuffer\u003B\u0029V)(num2, (int) num3, num4, (IntPtr) num5, num6);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glGetSamplerParameterfv(int i1, int i2, FloatBuffer fb)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglGetSamplerParameterfv\u0028IILjava\u002Fnio\u002FFloatBuffer\u003B\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglGetSamplerParameterfv\u0028IILjava\u002Fnio\u002FFloatBuffer\u003B\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glGetSamplerParameterfv), "(IILjava/nio/FloatBuffer;)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i1;
        int num5 = i2;
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) fb);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, int, IntPtr)>) SDLGL.__\u003Cjniptr\u003EglGetSamplerParameterfv\u0028IILjava\u002Fnio\u002FFloatBuffer\u003B\u0029V)(num2, (int) num3, num4, (IntPtr) num5, num6);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glVertexAttribDivisor(int i1, int i2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglVertexAttribDivisor\u0028II\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglVertexAttribDivisor\u0028II\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glVertexAttribDivisor), "(II)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i1;
        int num5 = i2;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, int)>) SDLGL.__\u003Cjniptr\u003EglVertexAttribDivisor\u0028II\u0029V)((int) num2, (int) num3, (IntPtr) num4, (IntPtr) num5);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glBindTransformFeedback(int i1, int i2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglBindTransformFeedback\u0028II\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglBindTransformFeedback\u0028II\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glBindTransformFeedback), "(II)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i1;
        int num5 = i2;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, int)>) SDLGL.__\u003Cjniptr\u003EglBindTransformFeedback\u0028II\u0029V)((int) num2, (int) num3, (IntPtr) num4, (IntPtr) num5);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glDeleteTransformFeedbacks(int i, IntBuffer ib)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglDeleteTransformFeedbacks\u0028ILjava\u002Fnio\u002FIntBuffer\u003B\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglDeleteTransformFeedbacks\u0028ILjava\u002Fnio\u002FIntBuffer\u003B\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glDeleteTransformFeedbacks), "(ILjava/nio/IntBuffer;)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i;
        IntPtr num5 = ((JNI.Frame) ref frame).MakeLocalRef((object) ib);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, IntPtr)>) SDLGL.__\u003Cjniptr\u003EglDeleteTransformFeedbacks\u0028ILjava\u002Fnio\u002FIntBuffer\u003B\u0029V)(num2, (int) num3, (IntPtr) num4, num5);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glGenTransformFeedbacks(int i, IntBuffer ib)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglGenTransformFeedbacks\u0028ILjava\u002Fnio\u002FIntBuffer\u003B\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglGenTransformFeedbacks\u0028ILjava\u002Fnio\u002FIntBuffer\u003B\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glGenTransformFeedbacks), "(ILjava/nio/IntBuffer;)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i;
        IntPtr num5 = ((JNI.Frame) ref frame).MakeLocalRef((object) ib);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, IntPtr)>) SDLGL.__\u003Cjniptr\u003EglGenTransformFeedbacks\u0028ILjava\u002Fnio\u002FIntBuffer\u003B\u0029V)(num2, (int) num3, (IntPtr) num4, num5);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static bool glIsTransformFeedback(int i)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglIsTransformFeedback\u0028I\u0029Z == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglIsTransformFeedback\u0028I\u0029Z = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glIsTransformFeedback), "(I)Z");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, int)>) SDLGL.__\u003Cjniptr\u003EglIsTransformFeedback\u0028I\u0029Z)((int) num2, num3, (IntPtr) num4);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glPauseTransformFeedback()
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglPauseTransformFeedback\u0028\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglPauseTransformFeedback\u0028\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glPauseTransformFeedback), "()V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr)>) SDLGL.__\u003Cjniptr\u003EglPauseTransformFeedback\u0028\u0029V)(num2, num3);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glResumeTransformFeedback()
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglResumeTransformFeedback\u0028\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglResumeTransformFeedback\u0028\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glResumeTransformFeedback), "()V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr)>) SDLGL.__\u003Cjniptr\u003EglResumeTransformFeedback\u0028\u0029V)(num2, num3);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glProgramParameteri(int i1, int i2, int i3)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglProgramParameteri\u0028III\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglProgramParameteri\u0028III\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glProgramParameteri), "(III)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i1;
        int num5 = i2;
        int num6 = i3;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, int, int)>) SDLGL.__\u003Cjniptr\u003EglProgramParameteri\u0028III\u0029V)((int) num2, (int) num3, num4, (IntPtr) num5, (IntPtr) num6);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glInvalidateFramebuffer(int i1, int i2, IntBuffer ib)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglInvalidateFramebuffer\u0028IILjava\u002Fnio\u002FIntBuffer\u003B\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglInvalidateFramebuffer\u0028IILjava\u002Fnio\u002FIntBuffer\u003B\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glInvalidateFramebuffer), "(IILjava/nio/IntBuffer;)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i1;
        int num5 = i2;
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) ib);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, int, IntPtr)>) SDLGL.__\u003Cjniptr\u003EglInvalidateFramebuffer\u0028IILjava\u002Fnio\u002FIntBuffer\u003B\u0029V)(num2, (int) num3, num4, (IntPtr) num5, num6);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void glInvalidateSubFramebuffer(
      int i1,
      int i2,
      IntBuffer ib,
      int i3,
      int i4,
      int i5,
      int i6)
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003EglInvalidateSubFramebuffer\u0028IILjava\u002Fnio\u002FIntBuffer\u003BIIII\u0029V == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003EglInvalidateSubFramebuffer\u0028IILjava\u002Fnio\u002FIntBuffer\u003BIIII\u0029V = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (glInvalidateSubFramebuffer), "(IILjava/nio/IntBuffer;IIII)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        int num4 = i1;
        int num5 = i2;
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) ib);
        int num7 = i3;
        int num8 = i4;
        int num9 = i5;
        int num10 = i6;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int, int, IntPtr, int, int, int, int)>) SDLGL.__\u003Cjniptr\u003EglInvalidateSubFramebuffer\u0028IILjava\u002Fnio\u002FIntBuffer\u003BIIII\u0029V)((int) num2, (int) num3, num4, num5, num6, num7, num8, (IntPtr) num9, (IntPtr) num10);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    [arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})]
    private static string init()
    {
      JNI.Frame frame = new JNI.Frame();
      if (SDLGL.__\u003Cjniptr\u003Einit\u0028\u0029Ljava\u002Flang\u002FString\u003B == IntPtr.Zero)
        SDLGL.__\u003Cjniptr\u003Einit\u0028\u0029Ljava\u002Flang\u002FString\u003B = JNI.Frame.GetFuncPtr(SDLGL.__\u003CGetCallerID\u003E(), "arc/backend/sdl/jni/SDLGL", nameof (init), "()Ljava/lang/String;");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(SDLGL.__\u003CGetCallerID\u003E());
      try
      {
        ref JNI.Frame local = ref frame;
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<SDLGL>.Value);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        IntPtr num4 = __calli((__FnPtr<IntPtr (IntPtr, IntPtr)>) SDLGL.__\u003Cjniptr\u003Einit\u0028\u0029Ljava\u002Flang\u002FString\u003B)(num2, num3);
        return (string) ((JNI.Frame) ref local).UnwrapLocalRef(num4);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [LineNumberTable(7)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public SDLGL()
    {
    }

    [LineNumberTable(new byte[] {159, 116, 173, 102, 99, 159, 6})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static SDLGL()
    {
      if (ByteCodeHelper.isAlreadyInited("arc.backend.sdl.jni.SDLGL"))
        return;
      string str = SDLGL.init();
      if (str != null)
      {
        string message = new StringBuilder().append("GLEW failed to initialize: ").append(str).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new ArcRuntimeException(message);
      }
    }

    static CallerID __\u003CGetCallerID\u003E()
    {
      if (SDLGL.__\u003CcallerID\u003E == null)
        SDLGL.__\u003CcallerID\u003E = (CallerID) new SDLGL.__\u003CCallerID\u003E();
      return SDLGL.__\u003CcallerID\u003E;
    }

    private sealed class __\u003CCallerID\u003E : CallerID
    {
      internal __\u003CCallerID\u003E()
      {
      }
    }
  }
}
