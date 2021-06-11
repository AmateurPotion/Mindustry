// Decompiled with JetBrains decompiler
// Type: arc.assets.loaders.AsynchronousAssetLoader
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.files;
using IKVM.Attributes;
using System.Runtime.CompilerServices;

namespace arc.assets.loaders
{
  [Signature("<T:Ljava/lang/Object;P:Larc/assets/AssetLoaderParameters<TT;>;>Larc/assets/loaders/AssetLoader<TT;TP;>;")]
  public abstract class AsynchronousAssetLoader : AssetLoader
  {
    [LineNumberTable(new byte[] {159, 157, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public AsynchronousAssetLoader(FileHandleResolver resolver)
      : base(resolver)
    {
    }

    [Signature("(Larc/assets/AssetManager;Ljava/lang/String;Larc/files/Fi;TP;)V")]
    public abstract void loadAsync(AssetManager am, string str, Fi f, AssetLoaderParameters alp);

    [Signature("(Larc/assets/AssetManager;Ljava/lang/String;Larc/files/Fi;TP;)TT;")]
    public abstract object loadSync(AssetManager am, string str, Fi f, AssetLoaderParameters alp);
  }
}
