// Decompiled with JetBrains decompiler
// Type: arc.assets.loaders.CubemapLoader
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
  [Signature("Larc/assets/loaders/AsynchronousAssetLoader<Larc/graphics/Cubemap;Larc/assets/loaders/CubemapLoader$CubemapParameter;>;")]
  public class CubemapLoader : AsynchronousAssetLoader
  {
    internal CubemapLoader.CubemapLoaderInfo info;

    [LineNumberTable(new byte[] {159, 169, 233, 61, 203})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public CubemapLoader(FileHandleResolver resolver)
      : base(resolver)
    {
      CubemapLoader cubemapLoader = this;
      this.info = new CubemapLoader.CubemapLoaderInfo();
    }

    [LineNumberTable(new byte[] {2, 106, 108, 99, 147, 145, 100, 116, 148})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cubemap loadSync(
      AssetManager manager,
      string fileName,
      Fi file,
      CubemapLoader.CubemapParameter parameter)
    {
      if (this.info == null)
        return (Cubemap) null;
      Cubemap cubemap = this.info.cubemap;
      if (cubemap != null)
        cubemap.load(this.info.data);
      else
        cubemap = new Cubemap(this.info.data);
      if (parameter != null)
      {
        cubemap.setFilter(parameter.minFilter, parameter.magFilter);
        cubemap.setWrap(parameter.wrapU, parameter.wrapV);
      }
      return cubemap;
    }

    [LineNumberTable(new byte[] {159, 174, 108, 109, 98, 98, 98, 140, 100, 104, 146, 98, 114, 146, 127, 3})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void loadAsync(
      AssetManager manager,
      string fileName,
      Fi file,
      CubemapLoader.CubemapParameter parameter)
    {
      this.info.filename = fileName;
      if (parameter == null || parameter.cubemapData == null)
      {
        this.info.cubemap = (Cubemap) null;
        if (parameter != null)
        {
          Pixmap.Format format = parameter.format;
          this.info.cubemap = parameter.cubemap;
        }
      }
      else
      {
        this.info.data = parameter.cubemapData;
        this.info.cubemap = parameter.cubemap;
      }
      if (this.info.data.isPrepared())
        return;
      this.info.data.prepare();
    }

    [Signature("(Ljava/lang/String;Larc/files/Fi;Larc/assets/loaders/CubemapLoader$CubemapParameter;)Larc/struct/Seq<Larc/assets/AssetDescriptor;>;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Seq getDependencies(
      string fileName,
      Fi file,
      CubemapLoader.CubemapParameter parameter)
    {
      return (Seq) null;
    }

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(23)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override object loadSync(AssetManager am, string str, Fi f, AssetLoaderParameters alp) => (object) this.loadSync(am, str, f, (CubemapLoader.CubemapParameter) alp);

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(23)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void loadAsync(AssetManager am, string str, Fi f, AssetLoaderParameters alp) => this.loadAsync(am, str, f, (CubemapLoader.CubemapParameter) alp);

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(23)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override Seq getDependencies(string str, Fi f, AssetLoaderParameters alp) => this.getDependencies(str, f, (CubemapLoader.CubemapParameter) alp);

    public class CubemapLoaderInfo : Object
    {
      internal string filename;
      internal CubemapData data;
      internal Cubemap cubemap;

      [LineNumberTable(71)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public CubemapLoaderInfo()
      {
      }
    }

    [Signature("Larc/assets/AssetLoaderParameters<Larc/graphics/Cubemap;>;")]
    public class CubemapParameter : AssetLoaderParameters
    {
      public Pixmap.Format format;
      public Cubemap cubemap;
      public CubemapData cubemapData;
      public Texture.TextureFilter minFilter;
      public Texture.TextureFilter magFilter;
      public Texture.TextureWrap wrapU;
      public Texture.TextureWrap wrapV;

      [LineNumberTable(new byte[] {27, 136, 135, 135, 103, 107, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public CubemapParameter()
      {
        CubemapLoader.CubemapParameter cubemapParameter = this;
        this.format = (Pixmap.Format) null;
        this.cubemap = (Cubemap) null;
        this.cubemapData = (CubemapData) null;
        this.minFilter = Texture.TextureFilter.__\u003C\u003Enearest;
        this.magFilter = Texture.TextureFilter.__\u003C\u003Enearest;
        this.wrapU = Texture.TextureWrap.__\u003C\u003EclampToEdge;
        this.wrapV = Texture.TextureWrap.__\u003C\u003EclampToEdge;
      }
    }
  }
}
