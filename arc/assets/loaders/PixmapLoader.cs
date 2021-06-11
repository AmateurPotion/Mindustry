// Decompiled with JetBrains decompiler
// Type: arc.assets.loaders.PixmapLoader
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.files;
using arc.graphics;
using IKVM.Attributes;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace arc.assets.loaders
{
  [Signature("Larc/assets/loaders/AsynchronousAssetLoader<Larc/graphics/Pixmap;Larc/assets/loaders/PixmapLoader$PixmapParameter;>;")]
  public class PixmapLoader : AsynchronousAssetLoader
  {
    internal Pixmap pixmap;

    [LineNumberTable(new byte[] {159, 160, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public PixmapLoader(FileHandleResolver resolver)
      : base(resolver)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Pixmap loadSync(
      AssetManager manager,
      string fileName,
      Fi file,
      PixmapLoader.PixmapParameter parameter)
    {
      Pixmap pixmap = this.pixmap;
      this.pixmap = (Pixmap) null;
      return pixmap;
    }

    [LineNumberTable(new byte[] {159, 165, 103, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void loadAsync(
      AssetManager manager,
      string fileName,
      Fi file,
      PixmapLoader.PixmapParameter parameter)
    {
      this.pixmap = (Pixmap) null;
      this.pixmap = new Pixmap(file);
    }

    [Signature("(Ljava/lang/String;Larc/files/Fi;Larc/assets/loaders/PixmapLoader$PixmapParameter;)Larc/struct/Seq<Larc/assets/AssetDescriptor;>;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Seq getDependencies(
      string fileName,
      Fi file,
      PixmapLoader.PixmapParameter parameter)
    {
      return (Seq) null;
    }

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(14)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override object loadSync(AssetManager am, string str, Fi f, AssetLoaderParameters alp) => (object) this.loadSync(am, str, f, (PixmapLoader.PixmapParameter) alp);

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(14)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void loadAsync(AssetManager am, string str, Fi f, AssetLoaderParameters alp) => this.loadAsync(am, str, f, (PixmapLoader.PixmapParameter) alp);

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(14)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override Seq getDependencies(string str, Fi f, AssetLoaderParameters alp) => this.getDependencies(str, f, (PixmapLoader.PixmapParameter) alp);

    [Signature("Larc/assets/AssetLoaderParameters<Larc/graphics/Pixmap;>;")]
    public class PixmapParameter : AssetLoaderParameters
    {
      [LineNumberTable(39)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public PixmapParameter()
      {
      }
    }
  }
}
