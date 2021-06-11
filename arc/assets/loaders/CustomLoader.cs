// Decompiled with JetBrains decompiler
// Type: arc.assets.loaders.CustomLoader
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.assets.loaders.resolvers;
using arc.files;
using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;

namespace arc.assets.loaders
{
  public abstract class CustomLoader : AsynchronousAssetLoader
  {
    public Runnable loaded;

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024new\u00240()
    {
    }

    [LineNumberTable(new byte[] {159, 154, 237, 61, 208})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public CustomLoader()
      : base((FileHandleResolver) new InternalFileHandleResolver())
    {
      CustomLoader customLoader = this;
      this.loaded = (Runnable) new CustomLoader.__\u003C\u003EAnon0();
    }

    [LineNumberTable(new byte[] {159, 159, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override object loadSync(
      AssetManager manager,
      string fileName,
      Fi file,
      AssetLoaderParameters parameter)
    {
      this.loaded.run();
      return (object) this;
    }

    [Signature("(Ljava/lang/String;Larc/files/Fi;Larc/assets/AssetLoaderParameters;)Larc/struct/Seq<Larc/assets/AssetDescriptor;>;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override Seq getDependencies(
      string fileName,
      Fi file,
      AssetLoaderParameters parameter)
    {
      return (Seq) null;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Runnable
    {
      internal __\u003C\u003EAnon0()
      {
      }

      public void run() => CustomLoader.lambda\u0024new\u00240();
    }
  }
}
