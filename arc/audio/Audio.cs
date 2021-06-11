// Decompiled with JetBrains decompiler
// Type: arc.audio.Audio
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.files;
using arc.util;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.audio
{
  public class Audio : Object, Disposable
  {
    public float falloff;
    internal bool initialized;
    public AudioBus soundBus;
    public AudioBus musicBus;

    [LineNumberTable(new byte[] {33, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isPlaying(int soundId) => this.initialized && Soloud.idValid(soundId);

    [LineNumberTable(new byte[] {159, 120, 66, 105, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void protect(int voice, bool protect)
    {
      int num = protect ? 1 : 0;
      if (!this.initialized)
        return;
      Soloud.idProtected(voice, num != 0);
    }

    [LineNumberTable(new byte[] {78, 105, 104, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void set(int soundId, float pan, float volume)
    {
      if (!this.initialized)
        return;
      Soloud.idVolume(soundId, volume);
      Soloud.idPan(soundId, pan);
    }

    [LineNumberTable(new byte[] {53, 105, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void stop(int soundId)
    {
      if (!this.initialized)
        return;
      Soloud.idStop(soundId);
    }

    [LineNumberTable(new byte[] {100, 105, 101, 101, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void dispose()
    {
      if (!this.initialized)
        return;
      Soloud.stopAll();
      Soloud.deinit();
      this.initialized = false;
    }

    [LineNumberTable(new byte[] {159, 164, 232, 54, 235, 69, 139, 203, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Audio()
    {
      Audio audio = this;
      this.falloff = 16000f;
      this.soundBus = new AudioBus();
      this.musicBus = new AudioBus();
      this.initialize();
    }

    [LineNumberTable(new byte[] {25, 124, 97, 127, 1})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Music newMusic(Fi file)
    {
      Music music;
      Exception exception;
      try
      {
        music = new Music(file);
      }
      catch (Exception ex)
      {
        exception = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        goto label_3;
      }
      return music;
label_3:
      Exception th = exception;
      Log.err(new StringBuilder().append("Error loading music: ").append((object) file).toString(), th);
      return new Music();
    }

    [LineNumberTable(new byte[] {15, 124, 97, 127, 1})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Sound newSound(Fi file)
    {
      Sound sound;
      Exception exception;
      try
      {
        sound = new Sound(file);
      }
      catch (Exception ex)
      {
        exception = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        goto label_3;
      }
      return sound;
label_3:
      Exception th = exception;
      Log.err(new StringBuilder().append("Error loading sound: ").append((object) file).toString(), th);
      return new Sound();
    }

    [LineNumberTable(new byte[] {159, 175, 101, 109, 63, 27, 165, 103, 112, 144, 255, 3, 82, 2, 97, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void initialize()
    {
      Exception th;
      try
      {
        Soloud.init();
        Log.info("[Audio] Initialized SoLoud @ using @ at @hz / @ samples / @ channels", (object) Integer.valueOf(Soloud.version()), (object) Soloud.backendString(), (object) Integer.valueOf(Soloud.backendSamplerate()), (object) Integer.valueOf(Soloud.backendBufferSize()), (object) Integer.valueOf(Soloud.backendChannels()));
        this.initialized = true;
        this.soundBus = new AudioBus().init();
        this.musicBus = new AudioBus().init();
        Core.app.addListener((ApplicationListener) new Audio.\u0031(this));
        return;
      }
      catch (Exception ex)
      {
        th = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
      }
      Log.err("Failed to initialize audio, disabling sound", th);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool initialized() => this.initialized;

    [LineNumberTable(new byte[] {159, 119, 99, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int play(AudioSource source, float volume, float pitch, float pan, bool loop)
    {
      int num = loop ? 1 : 0;
      return !this.initialized || source.handle == 0L ? -1 : Soloud.sourcePlay(source.handle, volume, pitch, pan, num != 0);
    }

    [LineNumberTable(new byte[] {48, 115, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void stop(AudioSource source)
    {
      if (!this.initialized || source.handle == 0L)
        return;
      Soloud.sourceStop(source.handle);
    }

    [LineNumberTable(new byte[] {159, 115, 66, 105, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setPaused(int soundId, bool paused)
    {
      int num = paused ? 1 : 0;
      if (!this.initialized)
        return;
      Soloud.idPause(soundId, num != 0);
    }

    [LineNumberTable(new byte[] {159, 114, 98, 105, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setLooping(int soundId, bool looping)
    {
      int num = looping ? 1 : 0;
      if (!this.initialized)
        return;
      Soloud.idLooping(soundId, num != 0);
    }

    [LineNumberTable(new byte[] {68, 105, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setPitch(int soundId, float pitch)
    {
      if (!this.initialized)
        return;
      Soloud.idPitch(soundId, pitch);
    }

    [LineNumberTable(new byte[] {73, 105, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setVolume(int soundId, float volume)
    {
      if (!this.initialized)
        return;
      Soloud.idVolume(soundId, volume);
    }

    [LineNumberTable(new byte[] {84, 105, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void fadeFilterParam(
      int voice,
      int filter,
      int attribute,
      float value,
      float timeSec)
    {
      if (!this.initialized)
        return;
      Soloud.filterFade(voice, filter, attribute, value, timeSec);
    }

    [LineNumberTable(new byte[] {89, 105, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setFilterParam(int voice, int filter, int attribute, float value)
    {
      if (!this.initialized)
        return;
      Soloud.filterSet(voice, filter, attribute, value);
    }

    [LineNumberTable(new byte[] {94, 105, 115})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setFilter(int index, [arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})] AudioFilter filter)
    {
      if (!this.initialized)
        return;
      Soloud.setGlobalFilter(index, filter != null ? filter.handle : 0L);
    }

    [HideFromJava]
    public virtual bool isDisposed() => Disposable.\u003Cdefault\u003EisDisposed((Disposable) this);

    [EnclosingMethod(null, "initialize", "()V")]
    [SpecialName]
    internal class \u0031 : Object, ApplicationListener
    {
      [Modifiers]
      internal Audio this\u00240;

      [LineNumberTable(41)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0031([In] Audio obj0)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector();
      }

      [LineNumberTable(new byte[] {159, 187, 108, 134})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void pause()
      {
        if (!Core.app.isMobile())
          return;
        Soloud.pauseAll(true);
      }

      [LineNumberTable(new byte[] {2, 108, 134})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void resume()
      {
        if (!Core.app.isMobile())
          return;
        Soloud.pauseAll(false);
      }

      [HideFromJava]
      public virtual void init() => ApplicationListener.\u003Cdefault\u003Einit((ApplicationListener) this);

      [HideFromJava]
      public virtual void resize([In] int obj0, [In] int obj1) => ApplicationListener.\u003Cdefault\u003Eresize((ApplicationListener) this, obj0, obj1);

      [HideFromJava]
      public virtual void update() => ApplicationListener.\u003Cdefault\u003Eupdate((ApplicationListener) this);

      [HideFromJava]
      public virtual void dispose() => ApplicationListener.\u003Cdefault\u003Edispose((ApplicationListener) this);

      [HideFromJava]
      public virtual void exit() => ApplicationListener.\u003Cdefault\u003Eexit((ApplicationListener) this);

      [HideFromJava]
      public virtual void fileDropped([In] Fi obj0) => ApplicationListener.\u003Cdefault\u003EfileDropped((ApplicationListener) this, obj0);
    }
  }
}
