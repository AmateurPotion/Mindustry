// Decompiled with JetBrains decompiler
// Type: arc.assets.loaders.SoundLoader
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.audio;
using arc.files;
using arc.util;
using IKVM.Attributes;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace arc.assets.loaders
{
  [Signature("Larc/assets/loaders/AsynchronousAssetLoader<Larc/audio/Sound;Larc/assets/loaders/SoundLoader$SoundParameter;>;")]
  public class SoundLoader : AsynchronousAssetLoader
  {
    private Sound sound;

    [LineNumberTable(new byte[] {159, 160, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public SoundLoader(FileHandleResolver resolver)
      : base(resolver)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Sound loadSync(
      AssetManager manager,
      string fileName,
      Fi file,
      SoundLoader.SoundParameter parameter)
    {
      Sound sound = this.sound;
      this.sound = (Sound) null;
      return sound;
    }

    [LineNumberTable(new byte[] {159, 175, 109, 154, 145})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void loadAsync(
      AssetManager manager,
      string fileName,
      Fi file,
      SoundLoader.SoundParameter parameter)
    {
      if (parameter != null && parameter.sound != null)
      {
        SoundLoader soundLoader = this;
        Sound sound1 = parameter.sound;
        Sound sound2 = sound1;
        this.sound = sound1;
        Fi file1 = file;
        sound2.load(file1);
      }
      else
        this.sound = Core.audio.newSound(file);
    }

    [Signature("(Ljava/lang/String;Larc/files/Fi;Larc/assets/loaders/SoundLoader$SoundParameter;)Larc/struct/Seq<Larc/assets/AssetDescriptor;>;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Seq getDependencies(
      string fileName,
      Fi file,
      SoundLoader.SoundParameter parameter)
    {
      return (Seq) null;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual Sound getLoadedSound() => this.sound;

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(14)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override object loadSync(AssetManager am, string str, Fi f, AssetLoaderParameters alp) => (object) this.loadSync(am, str, f, (SoundLoader.SoundParameter) alp);

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(14)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void loadAsync(AssetManager am, string str, Fi f, AssetLoaderParameters alp) => this.loadAsync(am, str, f, (SoundLoader.SoundParameter) alp);

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(14)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override Seq getDependencies(string str, Fi f, AssetLoaderParameters alp) => this.getDependencies(str, f, (SoundLoader.SoundParameter) alp);

    [Signature("Larc/assets/AssetLoaderParameters<Larc/audio/Sound;>;")]
    public class SoundParameter : AssetLoaderParameters
    {
      [Nullable(new object[] {64, "Larc/util/Nullable;"})]
      public Sound sound;

      [LineNumberTable(new byte[] {8, 104, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public SoundParameter([Nullable(new object[] {64, "Larc/util/Nullable;"})] Sound sound)
      {
        SoundLoader.SoundParameter soundParameter = this;
        this.sound = sound;
      }

      [LineNumberTable(new byte[] {5, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public SoundParameter()
      {
      }

      [LineNumberTable(new byte[] {13, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public SoundParameter(
        AssetLoaderParameters.LoadedCallback loadedCallback)
        : base(loadedCallback)
      {
      }
    }
  }
}
