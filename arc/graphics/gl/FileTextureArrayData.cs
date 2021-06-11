// Decompiled with JetBrains decompiler
// Type: arc.graphics.gl.FileTextureArrayData
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.files;
using arc.util;
using IKVM.Attributes;
using java.lang;
using java.nio;
using System.Runtime.CompilerServices;

namespace arc.graphics.gl
{
  public class FileTextureArrayData : Object, TextureArrayData
  {
    internal bool useMipMaps;
    private TextureData[] textureDatas;
    private bool prepared;
    private Pixmap.Format format;
    private int depth;

    [LineNumberTable(new byte[] {159, 138, 130, 104, 103, 103, 104, 109, 103, 50, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public FileTextureArrayData(Pixmap.Format format, bool useMipMaps, Fi[] files)
    {
      int num = useMipMaps ? 1 : 0;
      // ISSUE: explicit constructor call
      base.\u002Ector();
      FileTextureArrayData textureArrayData = this;
      this.format = format;
      this.useMipMaps = num != 0;
      this.depth = files.Length;
      this.textureDatas = new TextureData[files.Length];
      for (int index = 0; index < files.Length; ++index)
        this.textureDatas[index] = TextureData.load(files[index], format, num != 0);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isPrepared() => this.prepared;

    [LineNumberTable(new byte[] {159, 177, 98, 98, 123, 103, 100, 104, 104, 130, 116, 240, 56, 235, 75, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void prepare()
    {
      int num1 = -1;
      int num2 = -1;
      TextureData[] textureDatas = this.textureDatas;
      int length = textureDatas.Length;
      for (int index = 0; index < length; ++index)
      {
        TextureData textureData = textureDatas[index];
        textureData.prepare();
        if (num1 == -1)
        {
          num1 = textureData.getWidth();
          num2 = textureData.getHeight();
        }
        else if (num1 != textureData.getWidth() || num2 != textureData.getHeight())
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new ArcRuntimeException("Error whilst preparing TextureArray: TextureArray Textures must have equal dimensions.");
        }
      }
      this.prepared = true;
    }

    [LineNumberTable(new byte[] {3, 111, 111, 151, 105, 103, 103, 115, 121, 108, 120, 104, 134, 99, 130, 127, 19, 233, 46, 233, 85})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void consumeTextureArrayData()
    {
      for (int i5 = 0; i5 < this.textureDatas.Length; ++i5)
      {
        if (this.textureDatas[i5].isCustom())
        {
          this.textureDatas[i5].consumeCustomData(35866);
        }
        else
        {
          TextureData textureData = this.textureDatas[i5];
          Pixmap pixmap1 = textureData.consumePixmap();
          int num = textureData.disposePixmap() ? 1 : 0;
          if (!object.ReferenceEquals((object) textureData.getFormat(), (object) pixmap1.getFormat()))
          {
            Pixmap pixmap2 = new Pixmap(pixmap1.getWidth(), pixmap1.getHeight(), textureData.getFormat());
            pixmap2.setBlending(Pixmap.Blending.__\u003C\u003Enone);
            pixmap2.drawPixmap(pixmap1, 0, 0, 0, 0, pixmap1.getWidth(), pixmap1.getHeight());
            if (textureData.disposePixmap())
              pixmap1.dispose();
            pixmap1 = pixmap2;
            num = 1;
          }
          Core.gl30.glTexSubImage3D(35866, 0, 0, 0, i5, pixmap1.getWidth(), pixmap1.getHeight(), 1, pixmap1.getGLInternalFormat(), pixmap1.getGLType(), (Buffer) pixmap1.getPixels());
          if (num != 0)
            pixmap1.dispose();
        }
      }
    }

    [LineNumberTable(78)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getWidth() => this.textureDatas[0].getWidth();

    [LineNumberTable(83)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getHeight() => this.textureDatas[0].getHeight();

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getDepth() => this.depth;

    [LineNumberTable(93)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getInternalFormat() => this.format.toGlFormat();

    [LineNumberTable(98)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getGLType() => this.format.toGlType();
  }
}
