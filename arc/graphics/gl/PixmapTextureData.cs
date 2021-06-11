// Decompiled with JetBrains decompiler
// Type: arc.graphics.gl.PixmapTextureData
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.util;
using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;

namespace arc.graphics.gl
{
  public class PixmapTextureData : Object, TextureData
  {
    [Modifiers]
    internal Pixmap pixmap;
    [Modifiers]
    internal Pixmap.Format format;
    [Modifiers]
    internal bool useMipMaps;
    [Modifiers]
    internal bool disposePixmap;

    [LineNumberTable(new byte[] {159, 139, 133, 104, 103, 114, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public PixmapTextureData(
      Pixmap pixmap,
      Pixmap.Format format,
      bool useMipMaps,
      bool disposePixmap)
    {
      int num1 = useMipMaps ? 1 : 0;
      int num2 = disposePixmap ? 1 : 0;
      // ISSUE: explicit constructor call
      base.\u002Ector();
      PixmapTextureData pixmapTextureData = this;
      this.pixmap = pixmap;
      this.format = format != null ? format : pixmap.getFormat();
      this.useMipMaps = num1 != 0;
      this.disposePixmap = num2 != 0;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool disposePixmap() => this.disposePixmap;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Pixmap consumePixmap() => this.pixmap;

    [LineNumberTable(33)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getWidth() => this.pixmap.getWidth();

    [LineNumberTable(38)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getHeight() => this.pixmap.getHeight();

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Pixmap.Format getFormat() => this.format;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool useMipMaps() => this.useMipMaps;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isCustom() => false;

    [LineNumberTable(58)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void consumeCustomData(int target)
    {
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new ArcRuntimeException("This TextureData implementation does not upload data itself");
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isPrepared() => true;

    [LineNumberTable(68)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void prepare()
    {
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new ArcRuntimeException("prepare() must not be called on a PixmapTextureData instance as it is already prepared.");
    }

    [HideFromJava]
    public virtual Pixmap getPixmap() => TextureData.\u003Cdefault\u003EgetPixmap((TextureData) this);
  }
}
