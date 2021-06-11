// Decompiled with JetBrains decompiler
// Type: arc.freetype.FreeTypeFontGeneratorLoader
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.assets;
using arc.assets.loaders;
using arc.files;
using IKVM.Attributes;
using java.lang;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace arc.freetype
{
  [Signature("Larc/assets/loaders/SynchronousAssetLoader<Larc/freetype/FreeTypeFontGenerator;Larc/freetype/FreeTypeFontGeneratorLoader$FreeTypeFontGeneratorParameters;>;")]
  public class FreeTypeFontGeneratorLoader : SynchronousAssetLoader
  {
    [LineNumberTable(new byte[] {159, 165, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public FreeTypeFontGeneratorLoader(FileHandleResolver resolver)
      : base(resolver)
    {
    }

    [LineNumberTable(new byte[] {159, 171, 98, 114, 148, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual FreeTypeFontGenerator load(
      AssetManager assetManager,
      string fileName,
      Fi file,
      FreeTypeFontGeneratorLoader.FreeTypeFontGeneratorParameters parameter)
    {
      return !String.instancehelper_equals(file.extension(), (object) "gen") ? new FreeTypeFontGenerator(file) : new FreeTypeFontGenerator(file.sibling(file.nameWithoutExtension()));
    }

    [Signature("(Ljava/lang/String;Larc/files/Fi;Larc/freetype/FreeTypeFontGeneratorLoader$FreeTypeFontGeneratorParameters;)Larc/struct/Seq<Larc/assets/AssetDescriptor;>;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Seq getDependencies(
      string fileName,
      Fi file,
      FreeTypeFontGeneratorLoader.FreeTypeFontGeneratorParameters parameter)
    {
      return (Seq) null;
    }

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(20)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override object load(AssetManager am, string str, Fi f, AssetLoaderParameters alp) => (object) this.load(am, str, f, (FreeTypeFontGeneratorLoader.FreeTypeFontGeneratorParameters) alp);

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(20)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override Seq getDependencies(string str, Fi f, AssetLoaderParameters alp) => this.getDependencies(str, f, (FreeTypeFontGeneratorLoader.FreeTypeFontGeneratorParameters) alp);

    [Signature("Larc/assets/AssetLoaderParameters<Larc/freetype/FreeTypeFontGenerator;>;")]
    public class FreeTypeFontGeneratorParameters : AssetLoaderParameters
    {
      [LineNumberTable(43)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public FreeTypeFontGeneratorParameters()
      {
      }
    }
  }
}
