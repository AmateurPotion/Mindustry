// Decompiled with JetBrains decompiler
// Type: arc.graphics.GLTexture
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.graphics.gl;
using arc.util;
using IKVM.Attributes;
using java.lang;
using java.nio;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.graphics
{
  public abstract class GLTexture : Object, Disposable
  {
    internal int __\u003C\u003EglTarget;
    public int width;
    public int height;
    protected internal int glHandle;
    protected internal Texture.TextureFilter minFilter;
    protected internal Texture.TextureFilter magFilter;
    protected internal Texture.TextureWrap uWrap;
    protected internal Texture.TextureWrap vWrap;

    [LineNumberTable(new byte[] {97, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setWrap(Texture.TextureWrap wrap) => this.setWrap(wrap, wrap);

    [LineNumberTable(new byte[] {160, 76, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setFilter(Texture.TextureFilter filter) => this.setFilter(filter, filter);

    [LineNumberTable(new byte[] {160, 102, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void dispose() => this.delete();

    [LineNumberTable(new byte[] {160, 85, 103, 103, 102, 118, 118})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setFilter(Texture.TextureFilter minFilter, Texture.TextureFilter magFilter)
    {
      this.minFilter = minFilter;
      this.magFilter = magFilter;
      this.bind();
      Gl.texParameteri(this.__\u003C\u003EglTarget, 10241, minFilter.__\u003C\u003EglEnum);
      Gl.texParameteri(this.__\u003C\u003EglTarget, 10240, magFilter.__\u003C\u003EglEnum);
    }

    [LineNumberTable(new byte[] {33, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void bind() => Gl.bindTexture(this.__\u003C\u003EglTarget, this.glHandle);

    [LineNumberTable(new byte[] {41, 108, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void bind(int unit)
    {
      Gl.activeTexture(33984 + unit);
      Gl.bindTexture(this.__\u003C\u003EglTarget, this.glHandle);
    }

    [LineNumberTable(new byte[] {106, 103, 103, 102, 118, 118})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setWrap(Texture.TextureWrap u, Texture.TextureWrap v)
    {
      this.uWrap = u;
      this.vWrap = v;
      this.bind();
      Gl.texParameteri(this.__\u003C\u003EglTarget, 10242, u.getGLEnum());
      Gl.texParameteri(this.__\u003C\u003EglTarget, 10243, v.getGLEnum());
    }

    [HideFromJava]
    public virtual bool isDisposed() => Disposable.\u003Cdefault\u003EisDisposed((Disposable) this);

    [LineNumberTable(new byte[] {159, 172, 232, 54, 107, 107, 107, 235, 72, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public GLTexture(int glTarget, int glHandle)
    {
      GLTexture glTexture = this;
      this.minFilter = Texture.TextureFilter.__\u003C\u003Enearest;
      this.magFilter = Texture.TextureFilter.__\u003C\u003Enearest;
      this.uWrap = Texture.TextureWrap.__\u003C\u003EclampToEdge;
      this.vWrap = Texture.TextureWrap.__\u003C\u003EclampToEdge;
      this.__\u003C\u003EglTarget = glTarget;
      this.glHandle = glHandle;
    }

    [LineNumberTable(new byte[] {159, 182, 131, 161, 142, 104, 103, 161, 103, 103, 115, 120, 107, 119, 104, 134, 98, 162, 107, 104, 149, 118, 49, 165, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void uploadImageData(int target, TextureData data, int miplevel)
    {
      if (data == null)
        return;
      if (!data.isPrepared())
        data.prepare();
      if (data.isCustom())
      {
        data.consumeCustomData(target);
      }
      else
      {
        Pixmap pixmap1 = data.consumePixmap();
        int num = data.disposePixmap() ? 1 : 0;
        if (!object.ReferenceEquals((object) data.getFormat(), (object) pixmap1.getFormat()))
        {
          Pixmap pixmap2 = new Pixmap(pixmap1.getWidth(), pixmap1.getHeight(), data.getFormat());
          pixmap2.setBlending(Pixmap.Blending.__\u003C\u003Enone);
          pixmap2.drawPixmap(pixmap1, 0, 0, 0, 0, pixmap1.getWidth(), pixmap1.getHeight());
          if (data.disposePixmap())
            pixmap1.dispose();
          pixmap1 = pixmap2;
          num = 1;
        }
        Gl.pixelStorei(3317, 1);
        if (data.useMipMaps())
          MipMapGenerator.generateMipMap(target, pixmap1, pixmap1.getWidth(), pixmap1.getHeight());
        else
          Gl.texImage2D(target, miplevel, pixmap1.getGLInternalFormat(), pixmap1.getWidth(), pixmap1.getHeight(), 0, pixmap1.getGLFormat(), pixmap1.getGLType(), (Buffer) pixmap1.getPixels());
        if (num == 0)
          return;
        pixmap1.dispose();
      }
    }

    [LineNumberTable(new byte[] {159, 108, 66, 116, 118, 135, 116, 118, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void unsafeSetWrap(Texture.TextureWrap u, Texture.TextureWrap v, bool force)
    {
      int num = force ? 1 : 0;
      if (u != null && (num != 0 || !object.ReferenceEquals((object) this.uWrap, (object) u)))
      {
        Gl.texParameteri(this.__\u003C\u003EglTarget, 10242, u.getGLEnum());
        this.uWrap = u;
      }
      if (v == null || num == 0 && object.ReferenceEquals((object) this.vWrap, (object) v))
        return;
      Gl.texParameteri(this.__\u003C\u003EglTarget, 10243, v.getGLEnum());
      this.vWrap = v;
    }

    [LineNumberTable(new byte[] {159, 98, 162, 116, 118, 135, 116, 118, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void unsafeSetFilter(
      Texture.TextureFilter minFilter,
      Texture.TextureFilter magFilter,
      bool force)
    {
      int num = force ? 1 : 0;
      if (minFilter != null && (num != 0 || !object.ReferenceEquals((object) this.minFilter, (object) minFilter)))
      {
        Gl.texParameteri(this.__\u003C\u003EglTarget, 10241, minFilter.__\u003C\u003EglEnum);
        this.minFilter = minFilter;
      }
      if (magFilter == null || num == 0 && object.ReferenceEquals((object) this.magFilter, (object) magFilter))
        return;
      Gl.texParameteri(this.__\u003C\u003EglTarget, 10240, magFilter.__\u003C\u003EglEnum);
      this.magFilter = magFilter;
    }

    [LineNumberTable(new byte[] {160, 94, 104, 107, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void delete()
    {
      if (this.glHandle == 0)
        return;
      Gl.deleteTexture(this.glHandle);
      this.glHandle = 0;
    }

    [LineNumberTable(new byte[] {159, 169, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public GLTexture(int glTarget)
      : this(glTarget, Gl.genTexture())
    {
    }

    [LineNumberTable(new byte[] {159, 178, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal static void uploadImageData(int target, TextureData data) => GLTexture.uploadImageData(target, data, 0);

    public abstract int getDepth();

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Texture.TextureFilter getMinFilter() => this.minFilter;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Texture.TextureFilter getMagFilter() => this.magFilter;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Texture.TextureWrap getUWrap() => this.uWrap;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Texture.TextureWrap getVWrap() => this.vWrap;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getTextureObjectHandle() => this.glHandle;

    [LineNumberTable(new byte[] {76, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void unsafeSetWrap(Texture.TextureWrap u, Texture.TextureWrap v) => this.unsafeSetWrap(u, v, false);

    [LineNumberTable(new byte[] {119, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void unsafeSetFilter(
      Texture.TextureFilter minFilter,
      Texture.TextureFilter magFilter)
    {
      this.unsafeSetFilter(minFilter, magFilter, false);
    }

    [Modifiers]
    public int glTarget
    {
      [HideFromJava] get => this.__\u003C\u003EglTarget;
      [HideFromJava] [param: In] private set => this.__\u003C\u003EglTarget = value;
    }
  }
}
