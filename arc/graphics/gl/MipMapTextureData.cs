// Decompiled with JetBrains decompiler
// Type: arc.graphics.gl.MipMapTextureData
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.util;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System.Runtime.CompilerServices;

namespace arc.graphics.gl
{
  public class MipMapTextureData : Object, TextureData
  {
    internal TextureData[] mips;

    [LineNumberTable(new byte[] {159, 159, 104, 109, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public MipMapTextureData(params TextureData[] mipMapData)
    {
      MipMapTextureData mipMapTextureData = this;
      this.mips = new TextureData[mipMapData.Length];
      ByteCodeHelper.arraycopy((object) mipMapData, 0, (object) this.mips, 0, mipMapData.Length);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isCustom() => true;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isPrepared() => true;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void prepare()
    {
    }

    [LineNumberTable(38)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Pixmap consumePixmap()
    {
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new ArcRuntimeException("It's compressed, use the compressed method");
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool disposePixmap() => false;

    [LineNumberTable(new byte[] {159, 190, 108, 47, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void consumeCustomData(int target)
    {
      for (int miplevel = 0; miplevel < this.mips.Length; ++miplevel)
        GLTexture.uploadImageData(target, this.mips[miplevel], miplevel);
    }

    [LineNumberTable(55)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getWidth() => this.mips[0].getWidth();

    [LineNumberTable(60)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getHeight() => this.mips[0].getHeight();

    [LineNumberTable(65)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Pixmap.Format getFormat() => this.mips[0].getFormat();

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool useMipMaps() => false;

    [HideFromJava]
    public virtual Pixmap getPixmap() => TextureData.\u003Cdefault\u003EgetPixmap((TextureData) this);
  }
}
