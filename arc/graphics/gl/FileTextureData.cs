// Decompiled with JetBrains decompiler
// Type: arc.graphics.gl.FileTextureData
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.files;
using arc.util;
using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;

namespace arc.graphics.gl
{
  public class FileTextureData : Object, TextureData
  {
    [Modifiers]
    internal Fi file;
    internal int width;
    internal int height;
    internal Pixmap.Format format;
    internal Pixmap pixmap;
    internal bool useMipMaps;
    internal bool isPrepared;

    [LineNumberTable(new byte[] {159, 138, 99, 232, 57, 103, 199, 167, 103, 103, 103, 103, 104, 113, 113, 148})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public FileTextureData(Fi file, Pixmap preloadedPixmap, Pixmap.Format format, bool useMipMaps)
    {
      int num = useMipMaps ? 1 : 0;
      // ISSUE: explicit constructor call
      base.\u002Ector();
      FileTextureData fileTextureData = this;
      this.width = 0;
      this.height = 0;
      this.isPrepared = false;
      this.file = file;
      this.pixmap = preloadedPixmap;
      this.format = format;
      this.useMipMaps = num != 0;
      if (this.pixmap == null)
        return;
      this.width = this.pixmap.getWidth();
      this.height = this.pixmap.getHeight();
      if (format != null)
        return;
      this.format = this.pixmap.getFormat();
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isPrepared() => this.isPrepared;

    [LineNumberTable(new byte[] {159, 178, 120, 104, 113, 113, 113, 153, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void prepare()
    {
      if (this.isPrepared)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new ArcRuntimeException("Already prepared");
      }
      if (this.pixmap == null)
      {
        this.pixmap = new Pixmap(this.file);
        this.width = this.pixmap.getWidth();
        this.height = this.pixmap.getHeight();
        if (this.format == null)
          this.format = this.pixmap.getFormat();
      }
      this.isPrepared = true;
    }

    [LineNumberTable(new byte[] {159, 190, 120, 103, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Pixmap consumePixmap()
    {
      if (!this.isPrepared)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new ArcRuntimeException("Call prepare() before calling getPixmap()");
      }
      this.isPrepared = false;
      Pixmap pixmap = this.pixmap;
      this.pixmap = (Pixmap) null;
      return pixmap;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool disposePixmap() => true;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getWidth() => this.width;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getHeight() => this.height;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Pixmap.Format getFormat() => this.format;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool useMipMaps() => this.useMipMaps;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Fi getFileHandle() => this.file;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isCustom() => false;

    [LineNumberTable(91)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void consumeCustomData(int target)
    {
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new ArcRuntimeException("This TextureData implementation does not upload data itself");
    }

    [LineNumberTable(95)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toString() => this.file.toString();

    [HideFromJava]
    public virtual Pixmap getPixmap() => TextureData.\u003Cdefault\u003EgetPixmap((TextureData) this);
  }
}
