// Decompiled with JetBrains decompiler
// Type: arc.assets.loaders.SynchronousAssetLoader
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.files;
using IKVM.Attributes;
using System.Runtime.CompilerServices;

namespace arc.assets.loaders
{
  [Signature("<T:Ljava/lang/Object;P:Larc/assets/AssetLoaderParameters<TT;>;>Larc/assets/loaders/AssetLoader<TT;TP;>;")]
  public abstract class SynchronousAssetLoader : AssetLoader
  {
    [Signature("(Larc/assets/AssetManager;Ljava/lang/String;Larc/files/Fi;TP;)TT;")]
    public abstract object load(AssetManager am, string str, Fi f, AssetLoaderParameters alp);

    [LineNumberTable(new byte[] {159, 151, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public SynchronousAssetLoader(FileHandleResolver resolver)
      : base(resolver)
    {
    }
  }
}
