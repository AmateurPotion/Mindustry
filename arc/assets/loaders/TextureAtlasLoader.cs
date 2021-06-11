// Decompiled with JetBrains decompiler
// Type: arc.assets.loaders.TextureAtlasLoader
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.files;
using arc.graphics;
using arc.graphics.g2d;
using ikvm.@internal;
using IKVM.Attributes;
using java.lang;
using java.util;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace arc.assets.loaders
{
  [Signature("Larc/assets/loaders/SynchronousAssetLoader<Larc/graphics/g2d/TextureAtlas;Larc/assets/loaders/TextureAtlasLoader$TextureAtlasParameter;>;")]
  public class TextureAtlasLoader : SynchronousAssetLoader
  {
    internal TextureAtlas.TextureAtlasData data;

    [LineNumberTable(new byte[] {159, 166, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public TextureAtlasLoader(FileHandleResolver resolver)
      : base(resolver)
    {
    }

    [LineNumberTable(new byte[] {159, 171, 127, 6, 127, 17, 130, 113, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual TextureAtlas load(
      AssetManager assetManager,
      string fileName,
      Fi file,
      TextureAtlasLoader.TextureAtlasParameter parameter)
    {
      Iterator iterator = this.data.getPages().iterator();
      while (iterator.hasNext())
      {
        TextureAtlas.TextureAtlasData.AtlasPage atlasPage = (TextureAtlas.TextureAtlasData.AtlasPage) iterator.next();
        atlasPage.texture = (Texture) assetManager.get(String.instancehelper_replaceAll(atlasPage.__\u003C\u003EtextureFile.path(), "\\\\", "/"), (Class) ClassLiteral<Texture>.Value);
      }
      TextureAtlas.__\u003Cclinit\u003E();
      TextureAtlas textureAtlas = new TextureAtlas(this.data);
      this.data = (TextureAtlas.TextureAtlasData) null;
      return textureAtlas;
    }

    [Signature("(Ljava/lang/String;Larc/files/Fi;Larc/assets/loaders/TextureAtlasLoader$TextureAtlasParameter;)Larc/struct/Seq<Larc/assets/AssetDescriptor;>;")]
    [LineNumberTable(new byte[] {159, 182, 135, 99, 149, 174, 102, 127, 9, 103, 109, 109, 109, 109, 120, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Seq getDependencies(
      string fileName,
      Fi atlasFile,
      TextureAtlasLoader.TextureAtlasParameter parameter)
    {
      Fi imagesDir = atlasFile.parent();
      this.data = parameter == null ? new TextureAtlas.TextureAtlasData(atlasFile, imagesDir, false) : new TextureAtlas.TextureAtlasData(atlasFile, imagesDir, parameter.flip);
      Seq seq = new Seq();
      Iterator iterator = this.data.getPages().iterator();
      while (iterator.hasNext())
      {
        TextureAtlas.TextureAtlasData.AtlasPage atlasPage = (TextureAtlas.TextureAtlasData.AtlasPage) iterator.next();
        seq.add((object) new AssetDescriptor(atlasPage.__\u003C\u003EtextureFile, (Class) ClassLiteral<Texture>.Value, (AssetLoaderParameters) new TextureLoader.TextureParameter()
        {
          format = atlasPage.__\u003C\u003Eformat,
          genMipMaps = atlasPage.__\u003C\u003EuseMipMaps,
          minFilter = atlasPage.__\u003C\u003EminFilter,
          magFilter = atlasPage.__\u003C\u003EmagFilter
        }));
      }
      return seq;
    }

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(20)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override object load(AssetManager am, string str, Fi f, AssetLoaderParameters alp) => (object) this.load(am, str, f, (TextureAtlasLoader.TextureAtlasParameter) alp);

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(20)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override Seq getDependencies(string str, Fi f, AssetLoaderParameters alp) => this.getDependencies(str, f, (TextureAtlasLoader.TextureAtlasParameter) alp);

    [Signature("Larc/assets/AssetLoaderParameters<Larc/graphics/g2d/TextureAtlas;>;")]
    public class TextureAtlasParameter : AssetLoaderParameters
    {
      public bool flip;

      [LineNumberTable(new byte[] {14, 8, 167})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public TextureAtlasParameter()
      {
        TextureAtlasLoader.TextureAtlasParameter textureAtlasParameter = this;
        this.flip = false;
      }

      [LineNumberTable(new byte[] {159, 126, 162, 232, 59, 231, 70, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public TextureAtlasParameter(bool flip)
      {
        int num = flip ? 1 : 0;
        // ISSUE: explicit constructor call
        base.\u002Ector();
        TextureAtlasLoader.TextureAtlasParameter textureAtlasParameter = this;
        this.flip = false;
        this.flip = num != 0;
      }

      [LineNumberTable(new byte[] {22, 233, 54, 231, 75})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public TextureAtlasParameter(
        AssetLoaderParameters.LoadedCallback loadedCallback)
        : base(loadedCallback)
      {
        TextureAtlasLoader.TextureAtlasParameter textureAtlasParameter = this;
        this.flip = false;
      }
    }
  }
}
