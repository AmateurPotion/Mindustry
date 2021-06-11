// Decompiled with JetBrains decompiler
// Type: arc.graphics.TextureArray
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.files;
using arc.graphics.gl;
using arc.util;
using IKVM.Attributes;
using java.lang;
using java.nio;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.graphics
{
  public class TextureArray : GLTexture
  {
    private TextureArrayData data;

    [LineNumberTable(new byte[] {159, 184, 104, 103, 48, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static Fi[] getInternalHandles(params string[] _param0)
    {
      Fi[] fiArray = new Fi[_param0.Length];
      for (int index = 0; index < _param0.Length; ++index)
        fiArray[index] = Core.files.@internal(_param0[index]);
      return fiArray;
    }

    [LineNumberTable(new byte[] {159, 162, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public TextureArray(params Fi[] files)
      : this(false, files)
    {
    }

    [LineNumberTable(new byte[] {159, 136, 66, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public TextureArray(bool useMipMaps, params Fi[] files)
      : this(useMipMaps, Pixmap.Format.__\u003C\u003Ergba8888, files)
    {
    }

    [LineNumberTable(new byte[] {159, 135, 66, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public TextureArray(bool useMipMaps, Pixmap.Format format, params Fi[] files)
    {
      int num = useMipMaps ? 1 : 0;
      // ISSUE: explicit constructor call
      this.\u002Ector((TextureArrayData) new FileTextureArrayData(format, num != 0, files));
    }

    [LineNumberTable(new byte[] {159, 174, 146, 103, 176, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public TextureArray(TextureArrayData data)
      : base(35866, Gl.genTexture())
    {
      TextureArray textureArray = this;
      if (Core.gl30 == null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new ArcRuntimeException("TextureArray requires a device running with GLES 3.0 compatibilty");
      }
      this.load(data);
    }

    [LineNumberTable(new byte[] {0, 103, 108, 140, 102, 159, 23, 142, 134, 114, 114, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void load([In] TextureArrayData obj0)
    {
      this.data = obj0;
      this.width = obj0.getWidth();
      this.height = obj0.getHeight();
      this.bind();
      Core.gl30.glTexImage3D(35866, 0, obj0.getInternalFormat(), obj0.getWidth(), obj0.getHeight(), obj0.getDepth(), 0, obj0.getInternalFormat(), obj0.getGLType(), (Buffer) null);
      if (!obj0.isPrepared())
        obj0.prepare();
      obj0.consumeTextureArrayData();
      this.setFilter(this.minFilter, this.magFilter);
      this.setWrap(this.uWrap, this.vWrap);
      Gl.bindTexture(this.__\u003C\u003EglTarget, 0);
    }

    [LineNumberTable(new byte[] {159, 158, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public TextureArray(params string[] internalPaths)
      : this(TextureArray.getInternalHandles(internalPaths))
    {
    }

    [LineNumberTable(68)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override int getDepth() => this.data.getDepth();
  }
}
