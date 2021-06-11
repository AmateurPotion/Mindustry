// Decompiled with JetBrains decompiler
// Type: arc.freetype.FreetypeFontLoader
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.assets;
using arc.assets.loaders;
using arc.files;
using arc.graphics.g2d;
using ikvm.@internal;
using IKVM.Attributes;
using java.lang;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace arc.freetype
{
  [Signature("Larc/assets/loaders/AsynchronousAssetLoader<Larc/graphics/g2d/Font;Larc/freetype/FreetypeFontLoader$FreeTypeFontLoaderParameter;>;")]
  public class FreetypeFontLoader : AsynchronousAssetLoader
  {
    [LineNumberTable(new byte[] {159, 173, 100, 112, 127, 18})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Font loadSync(
      AssetManager manager,
      string fileName,
      Fi file,
      FreetypeFontLoader.FreeTypeFontLoaderParameter parameter)
    {
      if (parameter == null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new RuntimeException("FreetypeFontParameter must be set in AssetManager#load to point at a TTF file!");
      }
      return ((FreeTypeFontGenerator) manager.get(new StringBuilder().append(parameter.fontFileName).append(".gen").toString(), (Class) ClassLiteral<FreeTypeFontGenerator>.Value)).generateFont(parameter.fontParameters);
    }

    [LineNumberTable(new byte[] {159, 167, 100, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void loadAsync(
      AssetManager manager,
      string fileName,
      Fi file,
      FreetypeFontLoader.FreeTypeFontLoaderParameter parameter)
    {
      if (parameter == null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new RuntimeException("FreetypeFontParameter must be set in AssetManager#load to point at a TTF file!");
      }
    }

    [Signature("(Ljava/lang/String;Larc/files/Fi;Larc/freetype/FreetypeFontLoader$FreeTypeFontLoaderParameter;)Larc/struct/Seq<Larc/assets/AssetDescriptor;>;")]
    [LineNumberTable(new byte[] {159, 181, 102, 127, 16})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Seq getDependencies(
      string fileName,
      Fi file,
      FreetypeFontLoader.FreeTypeFontLoaderParameter parameter)
    {
      Seq seq = new Seq();
      seq.add((object) new AssetDescriptor(new StringBuilder().append(parameter.fontFileName).append(".gen").toString(), (Class) ClassLiteral<FreeTypeFontGenerator>.Value));
      return seq;
    }

    [LineNumberTable(new byte[] {159, 162, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public FreetypeFontLoader(FileHandleResolver resolver)
      : base(resolver)
    {
    }

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(18)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override object loadSync(AssetManager am, string str, Fi f, AssetLoaderParameters alp) => (object) this.loadSync(am, str, f, (FreetypeFontLoader.FreeTypeFontLoaderParameter) alp);

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(18)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void loadAsync(AssetManager am, string str, Fi f, AssetLoaderParameters alp) => this.loadAsync(am, str, f, (FreetypeFontLoader.FreeTypeFontLoaderParameter) alp);

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(18)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override Seq getDependencies(string str, Fi f, AssetLoaderParameters alp) => this.getDependencies(str, f, (FreetypeFontLoader.FreeTypeFontLoaderParameter) alp);

    [Signature("Larc/assets/AssetLoaderParameters<Larc/graphics/g2d/Font;>;")]
    public class FreeTypeFontLoaderParameter : AssetLoaderParameters
    {
      public string fontFileName;
      public FreeTypeFontGenerator.FreeTypeFontParameter fontParameters;

      [LineNumberTable(new byte[] {3, 232, 59, 235, 70, 103, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public FreeTypeFontLoaderParameter(
        string fontFileName,
        FreeTypeFontGenerator.FreeTypeFontParameter fontParameters)
      {
        FreetypeFontLoader.FreeTypeFontLoaderParameter fontLoaderParameter = this;
        this.fontParameters = new FreeTypeFontGenerator.FreeTypeFontParameter();
        this.fontFileName = fontFileName;
        this.fontParameters = fontParameters;
      }

      [LineNumberTable(new byte[] {0, 8, 171})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public FreeTypeFontLoaderParameter()
      {
        FreetypeFontLoader.FreeTypeFontLoaderParameter fontLoaderParameter = this;
        this.fontParameters = new FreeTypeFontGenerator.FreeTypeFontParameter();
      }
    }
  }
}
