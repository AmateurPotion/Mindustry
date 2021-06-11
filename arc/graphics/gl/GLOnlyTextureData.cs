// Decompiled with JetBrains decompiler
// Type: arc.graphics.gl.GLOnlyTextureData
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
  public class GLOnlyTextureData : Object, TextureData
  {
    internal int width;
    internal int height;
    internal bool isPrepared;
    internal int mipLevel;
    internal int internalFormat;
    internal int format;
    internal int type;

    [LineNumberTable(new byte[] {159, 178, 232, 42, 103, 103, 167, 231, 82, 103, 103, 103, 104, 104, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public GLOnlyTextureData(
      int width,
      int height,
      int mipMapLevel,
      int internalFormat,
      int format,
      int type)
    {
      GLOnlyTextureData glOnlyTextureData = this;
      this.width = 0;
      this.height = 0;
      this.isPrepared = false;
      this.mipLevel = 0;
      this.width = width;
      this.height = height;
      this.mipLevel = mipMapLevel;
      this.internalFormat = internalFormat;
      this.format = format;
      this.type = type;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isCustom() => true;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isPrepared() => this.isPrepared;

    [LineNumberTable(new byte[] {7, 120, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void prepare()
    {
      if (this.isPrepared)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new ArcRuntimeException("Already prepared");
      }
      this.isPrepared = true;
    }

    [LineNumberTable(new byte[] {13, 127, 13})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void consumeCustomData(int target) => Gl.texImage2D(target, this.mipLevel, this.internalFormat, this.width, this.height, 0, this.format, this.type, (Buffer) null);

    [LineNumberTable(68)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Pixmap consumePixmap()
    {
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new ArcRuntimeException("This TextureData implementation does not return a Pixmap");
    }

    [LineNumberTable(73)]
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

    [LineNumberTable(88)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Pixmap.Format getFormat() => Pixmap.Format.__\u003C\u003Ergba8888;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool useMipMaps() => false;

    [HideFromJava]
    public virtual Pixmap getPixmap() => TextureData.\u003Cdefault\u003EgetPixmap((TextureData) this);
  }
}
