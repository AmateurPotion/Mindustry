// Decompiled with JetBrains decompiler
// Type: arc.assets.loaders.AssetLoader
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.files;
using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;

namespace arc.assets.loaders
{
  [Signature("<T:Ljava/lang/Object;P:Larc/assets/AssetLoaderParameters<TT;>;>Ljava/lang/Object;")]
  public abstract class AssetLoader : Object
  {
    private FileHandleResolver resolver;

    [LineNumberTable(new byte[] {159, 163, 104, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public AssetLoader(FileHandleResolver resolver)
    {
      AssetLoader assetLoader = this;
      this.resolver = resolver;
    }

    [LineNumberTable(30)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Fi resolve(string fileName) => this.resolver.resolve(fileName);

    [Signature("(Ljava/lang/String;Larc/files/Fi;TP;)Larc/struct/Seq<Larc/assets/AssetDescriptor;>;")]
    public abstract Seq getDependencies(string str, Fi f, AssetLoaderParameters alp);
  }
}
