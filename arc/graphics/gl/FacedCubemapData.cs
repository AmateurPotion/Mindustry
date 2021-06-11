// Decompiled with JetBrains decompiler
// Type: arc.graphics.gl.FacedCubemapData
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.files;
using arc.util;
using IKVM.Attributes;
using java.lang;
using java.nio;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.graphics.gl
{
  public class FacedCubemapData : Object, CubemapData
  {
    internal TextureData[] __\u003C\u003Edata;

    [LineNumberTable(new byte[] {15, 232, 14, 236, 115, 105, 105, 105, 106, 106, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public FacedCubemapData(
      TextureData positiveX,
      TextureData negativeX,
      TextureData positiveY,
      TextureData negativeY,
      TextureData positiveZ,
      TextureData negativeZ)
    {
      FacedCubemapData facedCubemapData = this;
      this.__\u003C\u003Edata = new TextureData[6];
      this.__\u003C\u003Edata[0] = positiveX;
      this.__\u003C\u003Edata[1] = negativeX;
      this.__\u003C\u003Edata[2] = positiveY;
      this.__\u003C\u003Edata[3] = negativeY;
      this.__\u003C\u003Edata[4] = positiveZ;
      this.__\u003C\u003Edata[5] = negativeZ;
    }

    [LineNumberTable(new byte[] {159, 185, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public FacedCubemapData(
      Pixmap positiveX,
      Pixmap negativeX,
      Pixmap positiveY,
      Pixmap negativeY,
      Pixmap positiveZ,
      Pixmap negativeZ)
      : this(positiveX, negativeX, positiveY, negativeY, positiveZ, negativeZ, false)
    {
    }

    [LineNumberTable(new byte[] {159, 130, 67, 118, 120, 113, 120, 234, 60, 229, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public FacedCubemapData(
      Pixmap positiveX,
      Pixmap negativeX,
      Pixmap positiveY,
      Pixmap negativeY,
      Pixmap positiveZ,
      Pixmap negativeZ,
      bool useMipMaps)
    {
      int num = useMipMaps ? 1 : 0;
      // ISSUE: explicit constructor call
      this.\u002Ector(positiveX != null ? (TextureData) new PixmapTextureData(positiveX, (Pixmap.Format) null, num != 0, false) : (TextureData) null, negativeX != null ? (TextureData) new PixmapTextureData(negativeX, (Pixmap.Format) null, num != 0, false) : (TextureData) null, positiveY != null ? (TextureData) new PixmapTextureData(positiveY, (Pixmap.Format) null, num != 0, false) : (TextureData) null, negativeY != null ? (TextureData) new PixmapTextureData(negativeY, (Pixmap.Format) null, num != 0, false) : (TextureData) null, positiveZ != null ? (TextureData) new PixmapTextureData(positiveZ, (Pixmap.Format) null, num != 0, false) : (TextureData) null, negativeZ != null ? (TextureData) new PixmapTextureData(negativeZ, (Pixmap.Format) null, num != 0, false) : (TextureData) null);
    }

    [LineNumberTable(new byte[] {48, 108, 44, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isComplete()
    {
      for (int index = 0; index < this.__\u003C\u003Edata.Length; ++index)
      {
        if (this.__\u003C\u003Edata[index] == null)
          return false;
      }
      return true;
    }

    [LineNumberTable(new byte[] {159, 164, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public FacedCubemapData()
      : this((Pixmap) null, (Pixmap) null, (Pixmap) null, (Pixmap) null, (Pixmap) null, (Pixmap) null)
    {
    }

    [LineNumberTable(new byte[] {159, 169, 99, 118, 21, 197})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public FacedCubemapData(
      Fi positiveX,
      Fi negativeX,
      Fi positiveY,
      Fi negativeY,
      Fi positiveZ,
      Fi negativeZ)
      : this(TextureData.load(positiveX, false), TextureData.load(negativeX, false), TextureData.load(positiveY, false), TextureData.load(negativeY, false), TextureData.load(positiveZ, false), TextureData.load(negativeZ, false))
    {
    }

    [LineNumberTable(new byte[] {159, 134, 163, 99, 118, 21, 197})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public FacedCubemapData(
      Fi positiveX,
      Fi negativeX,
      Fi positiveY,
      Fi negativeY,
      Fi positiveZ,
      Fi negativeZ,
      bool useMipMaps)
    {
      int num = useMipMaps ? 1 : 0;
      // ISSUE: explicit constructor call
      this.\u002Ector(TextureData.load(positiveX, num != 0), TextureData.load(negativeX, num != 0), TextureData.load(positiveY, num != 0), TextureData.load(negativeY, num != 0), TextureData.load(positiveZ, num != 0), TextureData.load(negativeZ, num != 0));
    }

    [LineNumberTable(new byte[] {7, 223, 77})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public FacedCubemapData(int width, int height, int depth, Pixmap.Format format)
      : this((TextureData) new PixmapTextureData(new Pixmap(depth, height, format), (Pixmap.Format) null, false, true), (TextureData) new PixmapTextureData(new Pixmap(depth, height, format), (Pixmap.Format) null, false, true), (TextureData) new PixmapTextureData(new Pixmap(width, depth, format), (Pixmap.Format) null, false, true), (TextureData) new PixmapTextureData(new Pixmap(width, depth, format), (Pixmap.Format) null, false, true), (TextureData) new PixmapTextureData(new Pixmap(width, height, format), (Pixmap.Format) null, false, true), (TextureData) new PixmapTextureData(new Pixmap(width, height, format), (Pixmap.Format) null, false, true))
    {
    }

    [LineNumberTable(new byte[] {32, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void load(Cubemap.CubemapSide side, Fi file) => this.__\u003C\u003Edata[side.__\u003C\u003Eindex] = TextureData.load(file, false);

    [LineNumberTable(new byte[] {43, 124})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void load(Cubemap.CubemapSide side, Pixmap pixmap) => this.__\u003C\u003Edata[side.__\u003C\u003Eindex] = pixmap != null ? (TextureData) new PixmapTextureData(pixmap, (Pixmap.Format) null, false, false) : (TextureData) null;

    [LineNumberTable(105)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual TextureData getTextureData(Cubemap.CubemapSide side) => this.__\u003C\u003Edata[side.__\u003C\u003Eindex];

    [LineNumberTable(new byte[] {60, 98, 127, 15, 98, 127, 15, 98, 127, 15, 98, 127, 15, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getWidth()
    {
      int num = 0;
      int width1;
      if (this.__\u003C\u003Edata[Cubemap.CubemapSide.__\u003C\u003EpositiveZ.__\u003C\u003Eindex] != null && (width1 = this.__\u003C\u003Edata[Cubemap.CubemapSide.__\u003C\u003EpositiveZ.__\u003C\u003Eindex].getWidth()) > num)
        num = width1;
      int width2;
      if (this.__\u003C\u003Edata[Cubemap.CubemapSide.__\u003C\u003EnegativeZ.__\u003C\u003Eindex] != null && (width2 = this.__\u003C\u003Edata[Cubemap.CubemapSide.__\u003C\u003EnegativeZ.__\u003C\u003Eindex].getWidth()) > num)
        num = width2;
      int width3;
      if (this.__\u003C\u003Edata[Cubemap.CubemapSide.__\u003C\u003EpositiveY.__\u003C\u003Eindex] != null && (width3 = this.__\u003C\u003Edata[Cubemap.CubemapSide.__\u003C\u003EpositiveY.__\u003C\u003Eindex].getWidth()) > num)
        num = width3;
      int width4;
      if (this.__\u003C\u003Edata[Cubemap.CubemapSide.__\u003C\u003EnegativeY.__\u003C\u003Eindex] != null && (width4 = this.__\u003C\u003Edata[Cubemap.CubemapSide.__\u003C\u003EnegativeY.__\u003C\u003Eindex].getWidth()) > num)
        num = width4;
      return num;
    }

    [LineNumberTable(new byte[] {74, 98, 127, 15, 98, 127, 15, 98, 127, 15, 98, 127, 15, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getHeight()
    {
      int num = 0;
      int height1;
      if (this.__\u003C\u003Edata[Cubemap.CubemapSide.__\u003C\u003EpositiveZ.__\u003C\u003Eindex] != null && (height1 = this.__\u003C\u003Edata[Cubemap.CubemapSide.__\u003C\u003EpositiveZ.__\u003C\u003Eindex].getHeight()) > num)
        num = height1;
      int height2;
      if (this.__\u003C\u003Edata[Cubemap.CubemapSide.__\u003C\u003EnegativeZ.__\u003C\u003Eindex] != null && (height2 = this.__\u003C\u003Edata[Cubemap.CubemapSide.__\u003C\u003EnegativeZ.__\u003C\u003Eindex].getHeight()) > num)
        num = height2;
      int height3;
      if (this.__\u003C\u003Edata[Cubemap.CubemapSide.__\u003C\u003EpositiveX.__\u003C\u003Eindex] != null && (height3 = this.__\u003C\u003Edata[Cubemap.CubemapSide.__\u003C\u003EpositiveX.__\u003C\u003Eindex].getHeight()) > num)
        num = height3;
      int height4;
      if (this.__\u003C\u003Edata[Cubemap.CubemapSide.__\u003C\u003EnegativeX.__\u003C\u003Eindex] != null && (height4 = this.__\u003C\u003Edata[Cubemap.CubemapSide.__\u003C\u003EnegativeX.__\u003C\u003Eindex].getHeight()) > num)
        num = height4;
      return num;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isPrepared() => false;

    [LineNumberTable(new byte[] {93, 120, 127, 9})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void prepare()
    {
      if (!this.isComplete())
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new ArcRuntimeException("You need to complete your cubemap data before using it");
      }
      TextureData[] data = this.__\u003C\u003Edata;
      int length = data.Length;
      for (int index = 0; index < length; ++index)
      {
        TextureData textureData = data[index];
        if (!textureData.isPrepared())
          textureData.prepare();
      }
    }

    [LineNumberTable(new byte[] {99, 111, 111, 153, 110, 110, 125, 127, 0, 107, 119, 117, 98, 130, 107, 117, 56, 133, 233, 47, 233, 84})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void consumeCubemapData()
    {
      for (int index = 0; index < this.__\u003C\u003Edata.Length; ++index)
      {
        if (this.__\u003C\u003Edata[index].isCustom())
        {
          this.__\u003C\u003Edata[index].consumeCustomData(34069 + index);
        }
        else
        {
          Pixmap pixmap1 = this.__\u003C\u003Edata[index].consumePixmap();
          int num = this.__\u003C\u003Edata[index].disposePixmap() ? 1 : 0;
          if (!object.ReferenceEquals((object) this.__\u003C\u003Edata[index].getFormat(), (object) pixmap1.getFormat()))
          {
            Pixmap pixmap2 = new Pixmap(pixmap1.getWidth(), pixmap1.getHeight(), this.__\u003C\u003Edata[index].getFormat());
            pixmap2.setBlending(Pixmap.Blending.__\u003C\u003Enone);
            pixmap2.drawPixmap(pixmap1, 0, 0, 0, 0, pixmap1.getWidth(), pixmap1.getHeight());
            if (this.__\u003C\u003Edata[index].disposePixmap())
              pixmap1.dispose();
            pixmap1 = pixmap2;
            num = 1;
          }
          Gl.pixelStorei(3317, 1);
          Gl.texImage2D(34069 + index, 0, pixmap1.getGLInternalFormat(), pixmap1.getWidth(), pixmap1.getHeight(), 0, pixmap1.getGLFormat(), pixmap1.getGLType(), (Buffer) pixmap1.getPixels());
          if (num != 0)
            pixmap1.dispose();
        }
      }
    }

    [Modifiers]
    protected internal TextureData[] data
    {
      [HideFromJava] get => this.__\u003C\u003Edata;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Edata = value;
    }
  }
}
