// Decompiled with JetBrains decompiler
// Type: arc.assets.loaders.FontLoader
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.files;
using arc.graphics;
using arc.graphics.g2d;
using arc.util;
using ikvm.@internal;
using IKVM.Attributes;
using java.lang;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace arc.assets.loaders
{
  [Signature("Larc/assets/loaders/AsynchronousAssetLoader<Larc/graphics/g2d/Font;Larc/assets/loaders/FontLoader$FontParameter;>;")]
  public class FontLoader : AsynchronousAssetLoader
  {
    internal Font.FontData data;

    [LineNumberTable(new byte[] {159, 170, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public FontLoader(FileHandleResolver resolver)
      : base(resolver)
    {
    }

    [LineNumberTable(new byte[] {19, 115, 120, 121, 136, 99, 127, 28, 136, 109, 104, 104, 63, 10, 168})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Font loadSync(
      AssetManager manager,
      string fileName,
      Fi file,
      FontLoader.FontParameter parameter)
    {
      if (parameter != null && parameter.atlasName != null)
      {
        TextureAtlas textureAtlas = (TextureAtlas) manager.get(parameter.atlasName, (Class) ClassLiteral<TextureAtlas>.Value);
        string name = file.sibling(this.data.imagePaths[0]).nameWithoutExtension();
        TextureAtlas.AtlasRegion atlasRegion = textureAtlas.find(name);
        if (atlasRegion == null)
        {
          string message = new StringBuilder().append("Could not find font region ").append(name).append(" in atlas ").append(parameter.atlasName).toString();
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new ArcRuntimeException(message);
        }
        return new Font(file, (TextureRegion) atlasRegion);
      }
      int length = this.data.getImagePaths().Length;
      Seq pageRegions = new Seq(length);
      for (int index = 0; index < length; ++index)
        pageRegions.add((object) new TextureRegion((Texture) manager.get(this.data.getImagePath(index), (Class) ClassLiteral<Texture>.Value)));
      return new Font(this.data, pageRegions, true);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void loadAsync(
      AssetManager manager,
      string fileName,
      Fi file,
      FontLoader.FontParameter parameter)
    {
    }

    [Signature("(Ljava/lang/String;Larc/files/Fi;Larc/assets/loaders/FontLoader$FontParameter;)Larc/struct/Seq<Larc/assets/AssetDescriptor;>;")]
    [LineNumberTable(new byte[] {159, 175, 102, 107, 108, 162, 123, 107, 155, 116, 109, 136, 135, 99, 109, 109, 173, 111, 232, 51, 233, 81})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Seq getDependencies(
      string fileName,
      Fi file,
      FontLoader.FontParameter parameter)
    {
      Seq seq = new Seq();
      if (parameter != null && parameter.fontData != null)
      {
        this.data = parameter.fontData;
        return seq;
      }
      this.data = new Font.FontData(file, parameter != null && parameter.flip);
      if (parameter != null && parameter.atlasName != null)
      {
        seq.add((object) new AssetDescriptor(parameter.atlasName, (Class) ClassLiteral<TextureAtlas>.Value));
      }
      else
      {
        for (int index = 0; index < this.data.getImagePaths().Length; ++index)
        {
          Fi file1 = this.resolve(this.data.getImagePath(index));
          TextureLoader.TextureParameter textureParameter = new TextureLoader.TextureParameter();
          if (parameter != null)
          {
            textureParameter.genMipMaps = parameter.genMipMaps;
            textureParameter.minFilter = parameter.minFilter;
            textureParameter.magFilter = parameter.magFilter;
          }
          AssetDescriptor assetDescriptor = new AssetDescriptor(file1, (Class) ClassLiteral<Texture>.Value, (AssetLoaderParameters) textureParameter);
          seq.add((object) assetDescriptor);
        }
      }
      return seq;
    }

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(24)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override object loadSync(AssetManager am, string str, Fi f, AssetLoaderParameters alp) => (object) this.loadSync(am, str, f, (FontLoader.FontParameter) alp);

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(24)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void loadAsync(AssetManager am, string str, Fi f, AssetLoaderParameters alp) => this.loadAsync(am, str, f, (FontLoader.FontParameter) alp);

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(24)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override Seq getDependencies(string str, Fi f, AssetLoaderParameters alp) => this.getDependencies(str, f, (FontLoader.FontParameter) alp);

    [Signature("Larc/assets/AssetLoaderParameters<Larc/graphics/g2d/Font;>;")]
    public class FontParameter : AssetLoaderParameters
    {
      public bool flip;
      public bool genMipMaps;
      public Texture.TextureFilter minFilter;
      public Texture.TextureFilter magFilter;
      public Font.FontData fontData;
      public string atlasName;

      [LineNumberTable(new byte[] {42, 136, 167, 167, 171, 171, 231, 70})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public FontParameter()
      {
        FontLoader.FontParameter fontParameter = this;
        this.flip = false;
        this.genMipMaps = false;
        this.minFilter = Texture.TextureFilter.__\u003C\u003Enearest;
        this.magFilter = Texture.TextureFilter.__\u003C\u003Enearest;
        this.fontData = (Font.FontData) null;
        this.atlasName = (string) null;
      }
    }
  }
}
