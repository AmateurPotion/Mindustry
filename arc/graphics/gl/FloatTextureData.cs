// Decompiled with JetBrains decompiler
// Type: arc.graphics.gl.FloatTextureData
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.util;
using IKVM.Attributes;
using java.lang;
using java.nio;
using System.Runtime.CompilerServices;

namespace arc.graphics.gl
{
  public class FloatTextureData : Object, TextureData
  {
    internal int width;
    internal int height;
    internal int internalFormat;
    internal int format;
    internal int type;
    internal bool isGpuOnly;
    internal bool isPrepared;
    internal FloatBuffer buffer;

    [LineNumberTable(new byte[] {159, 136, 131, 232, 61, 199, 103, 103, 103, 104, 104, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public FloatTextureData(
      int w,
      int h,
      int internalFormat,
      int format,
      int type,
      bool isGpuOnly)
    {
      int num = isGpuOnly ? 1 : 0;
      // ISSUE: explicit constructor call
      base.\u002Ector();
      FloatTextureData floatTextureData = this;
      this.isPrepared = false;
      this.width = w;
      this.height = h;
      this.internalFormat = internalFormat;
      this.format = format;
      this.type = type;
      this.isGpuOnly = num != 0;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isCustom() => true;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isPrepared() => this.isPrepared;

    [LineNumberTable(new byte[] {159, 189, 120, 107, 98, 126, 124, 124, 124, 156, 154, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void prepare()
    {
      if (this.isPrepared)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new ArcRuntimeException("Already prepared");
      }
      if (!this.isGpuOnly)
      {
        int num = 4;
        if (Core.graphics.getGLVersion().__\u003C\u003Etype.equals((object) GLVersion.GlType.__\u003C\u003EOpenGL))
        {
          if (this.internalFormat == 34842 || this.internalFormat == 34836)
            num = 4;
          if (this.internalFormat == 34843 || this.internalFormat == 34837)
            num = 3;
          if (this.internalFormat == 33327 || this.internalFormat == 33328)
            num = 2;
          if (this.internalFormat == 33325 || this.internalFormat == 33326)
            num = 1;
        }
        this.buffer = Buffers.newFloatBuffer(this.width * this.height * num);
      }
      this.isPrepared = true;
    }

    [LineNumberTable(new byte[] {13, 159, 5, 113, 208, 191, 12, 108, 113, 208, 159, 12})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void consumeCustomData(int target)
    {
      if (Core.app.isAndroid() || Core.app.isIOS() || Core.app.isWeb())
      {
        if (!Core.graphics.supportsExtension("OES_texture_float"))
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new ArcRuntimeException("Extension OES_texture_float not supported!");
        }
        Gl.texImage2D(target, 0, 6408, this.width, this.height, 0, 6408, 5126, (Buffer) this.buffer);
      }
      else
      {
        if (!Core.graphics.isGL30Available() && !Core.graphics.supportsExtension("GL_ARB_texture_float"))
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new ArcRuntimeException("Extension GL_ARB_texture_float not supported!");
        }
        Gl.texImage2D(target, 0, this.internalFormat, this.width, this.height, 0, this.format, 5126, (Buffer) this.buffer);
      }
    }

    [LineNumberTable(85)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Pixmap consumePixmap()
    {
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new ArcRuntimeException("This TextureData implementation does not return a Pixmap");
    }

    [LineNumberTable(90)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool disposePixmap()
    {
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new ArcRuntimeException("This TextureData implementation does not return a Pixmap");
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getWidth() => this.width;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getHeight() => this.height;

    [LineNumberTable(105)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Pixmap.Format getFormat() => Pixmap.Format.__\u003C\u003Ergba8888;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool useMipMaps() => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual FloatBuffer getBuffer() => this.buffer;

    [HideFromJava]
    public virtual Pixmap getPixmap() => TextureData.\u003Cdefault\u003EgetPixmap((TextureData) this);
  }
}
