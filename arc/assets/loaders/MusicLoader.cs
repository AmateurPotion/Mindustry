// Decompiled with JetBrains decompiler
// Type: arc.assets.loaders.MusicLoader
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.audio;
using arc.files;
using arc.util;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace arc.assets.loaders
{
  [Signature("Larc/assets/loaders/AsynchronousAssetLoader<Larc/audio/Music;Larc/assets/loaders/MusicLoader$MusicParameter;>;")]
  public class MusicLoader : AsynchronousAssetLoader
  {
    private Music music;

    [LineNumberTable(new byte[] {159, 160, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public MusicLoader(FileHandleResolver resolver)
      : base(resolver)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Music loadSync(
      AssetManager manager,
      string fileName,
      Fi file,
      MusicLoader.MusicParameter parameter)
    {
      Music music = this.music;
      this.music = (Music) null;
      return music;
    }

    [LineNumberTable(new byte[] {159, 175, 141, 191, 16, 2, 97, 102, 130, 145})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void loadAsync(
      AssetManager manager,
      string fileName,
      Fi file,
      MusicLoader.MusicParameter parameter)
    {
      if (parameter != null)
      {
        if (parameter.music != null)
        {
          Exception exception;
          try
          {
            MusicLoader musicLoader = this;
            Music music1 = parameter.music;
            Music music2 = music1;
            this.music = music1;
            Fi file1 = file;
            music2.load(file1);
            return;
          }
          catch (Exception ex)
          {
            M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
            if (m0 == null)
              throw;
            else
              exception = (Exception) m0;
          }
          Log.err((Exception) exception);
          return;
        }
      }
      this.music = Core.audio.newMusic(file);
    }

    [Signature("(Ljava/lang/String;Larc/files/Fi;Larc/assets/loaders/MusicLoader$MusicParameter;)Larc/struct/Seq<Larc/assets/AssetDescriptor;>;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Seq getDependencies(
      string fileName,
      Fi file,
      MusicLoader.MusicParameter parameter)
    {
      return (Seq) null;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual Music getLoadedMusic() => this.music;

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(14)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override object loadSync(AssetManager am, string str, Fi f, AssetLoaderParameters alp) => (object) this.loadSync(am, str, f, (MusicLoader.MusicParameter) alp);

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(14)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void loadAsync(AssetManager am, string str, Fi f, AssetLoaderParameters alp) => this.loadAsync(am, str, f, (MusicLoader.MusicParameter) alp);

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(14)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override Seq getDependencies(string str, Fi f, AssetLoaderParameters alp) => this.getDependencies(str, f, (MusicLoader.MusicParameter) alp);

    [Signature("Larc/assets/AssetLoaderParameters<Larc/audio/Music;>;")]
    public class MusicParameter : AssetLoaderParameters
    {
      [arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})]
      public Music music;

      [LineNumberTable(new byte[] {12, 104, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public MusicParameter([arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})] Music music)
      {
        MusicLoader.MusicParameter musicParameter = this;
        this.music = music;
      }

      [LineNumberTable(new byte[] {9, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public MusicParameter()
      {
      }

      [LineNumberTable(new byte[] {17, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public MusicParameter(
        AssetLoaderParameters.LoadedCallback loadedCallback)
        : base(loadedCallback)
      {
      }
    }
  }
}
