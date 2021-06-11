// Decompiled with JetBrains decompiler
// Type: arc.assets.AssetLoaderParameters
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;

namespace arc.assets
{
  [Signature("<T:Ljava/lang/Object;>Ljava/lang/Object;")]
  public class AssetLoaderParameters : Object
  {
    public AssetLoaderParameters.LoadedCallback loadedCallback;

    [LineNumberTable(new byte[] {159, 148, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public AssetLoaderParameters()
    {
    }

    [LineNumberTable(new byte[] {159, 152, 104, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public AssetLoaderParameters(
      AssetLoaderParameters.LoadedCallback loadedCallback)
    {
      AssetLoaderParameters loaderParameters = this;
      this.loadedCallback = loadedCallback;
    }

    public interface LoadedCallback
    {
      void finishedLoading(AssetManager am, string str, Class c);
    }
  }
}
