// Decompiled with JetBrains decompiler
// Type: arc.assets.loaders.TextureLoader
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.files;
using arc.graphics;
using IKVM.Attributes;
using java.lang;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace arc.assets.loaders
{
  [Signature("Larc/assets/loaders/AsynchronousAssetLoader<Larc/graphics/Texture;Larc/assets/loaders/TextureLoader$TextureParameter;>;")]
  public class TextureLoader : AsynchronousAssetLoader
  {
    internal TextureLoader.TextureLoaderInfo info;

    [LineNumberTable(new byte[] {159, 191, 106, 108, 99, 147, 145, 100, 116, 148})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Texture loadSync(
      AssetManager manager,
      string fileName,
      Fi file,
      TextureLoader.TextureParameter parameter)
    {
      if (this.info == null)
        return (Texture) null;
      Texture texture = this.info.texture;
      if (texture != null)
        texture.load(this.info.data);
      else
        texture = new Texture(this.info.data);
      if (parameter != null)
      {
        texture.setFilter(parameter.minFilter, parameter.magFilter);
        texture.setWrap(parameter.wrapU, parameter.wrapV);
      }
      return texture;
    }

    [LineNumberTable(new byte[] {159, 169, 108, 109, 98, 98, 140, 100, 104, 104, 178, 115, 98, 114, 146, 127, 3})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void loadAsync(
      AssetManager manager,
      string fileName,
      Fi file,
      TextureLoader.TextureParameter parameter)
    {
      this.info.filename = fileName;
      if (parameter == null || parameter.textureData == null)
      {
        Pixmap.Format format = (Pixmap.Format) null;
        int num = 0;
        this.info.texture = (Texture) null;
        if (parameter != null)
        {
          format = parameter.format;
          num = parameter.genMipMaps ? 1 : 0;
          this.info.texture = parameter.texture;
        }
        this.info.data = TextureData.load(file, format, num != 0);
      }
      else
      {
        this.info.data = parameter.textureData;
        this.info.texture = parameter.texture;
      }
      if (this.info.data.isPrepared())
        return;
      this.info.data.prepare();
    }

    [Signature("(Ljava/lang/String;Larc/files/Fi;Larc/assets/loaders/TextureLoader$TextureParameter;)Larc/struct/Seq<Larc/assets/AssetDescriptor;>;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Seq getDependencies(
      string fileName,
      Fi file,
      TextureLoader.TextureParameter parameter)
    {
      return (Seq) null;
    }

    [LineNumberTable(new byte[] {159, 164, 233, 61, 203})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public TextureLoader(FileHandleResolver resolver)
      : base(resolver)
    {
      TextureLoader textureLoader = this;
      this.info = new TextureLoader.TextureLoaderInfo();
    }

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(18)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override object loadSync(AssetManager am, string str, Fi f, AssetLoaderParameters alp) => (object) this.loadSync(am, str, f, (TextureLoader.TextureParameter) alp);

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(18)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void loadAsync(AssetManager am, string str, Fi f, AssetLoaderParameters alp) => this.loadAsync(am, str, f, (TextureLoader.TextureParameter) alp);

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(18)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override Seq getDependencies(string str, Fi f, AssetLoaderParameters alp) => this.getDependencies(str, f, (TextureLoader.TextureParameter) alp);

    public class TextureLoaderInfo : Object
    {
      internal string filename;
      internal TextureData data;
      internal Texture texture;

      [LineNumberTable(68)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public TextureLoaderInfo()
      {
      }
    }

    [Signature("Larc/assets/AssetLoaderParameters<Larc/graphics/Texture;>;")]
    public class TextureParameter : AssetLoaderParameters
    {
      public Pixmap.Format format;
      public bool genMipMaps;
      public Texture texture;
      public TextureData textureData;
      public Texture.TextureFilter minFilter;
      public Texture.TextureFilter magFilter;
      public Texture.TextureWrap wrapU;
      public Texture.TextureWrap wrapV;

      [LineNumberTable(new byte[] {38, 232, 52, 135, 135, 135, 103, 107, 107, 107, 171})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public TextureParameter()
      {
        TextureLoader.TextureParameter textureParameter = this;
        this.format = (Pixmap.Format) null;
        this.genMipMaps = false;
        this.texture = (Texture) null;
        this.textureData = (TextureData) null;
        this.minFilter = Texture.TextureFilter.__\u003C\u003Enearest;
        this.magFilter = Texture.TextureFilter.__\u003C\u003Enearest;
        this.wrapU = Texture.TextureWrap.__\u003C\u003EclampToEdge;
        this.wrapV = Texture.TextureWrap.__\u003C\u003EclampToEdge;
      }
    }
  }
}
