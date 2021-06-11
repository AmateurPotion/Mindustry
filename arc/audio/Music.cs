// Decompiled with JetBrains decompiler
// Type: arc.audio.Music
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.files;
using arc.util;
using IKVM.Attributes;
using IKVM.Runtime;
using java.io;
using java.lang;
using System;
using System.Runtime.CompilerServices;

namespace arc.audio
{
  public class Music : AudioSource
  {
    [arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})]
    internal Fi file;
    internal int voice;
    internal bool looping;
    internal float volume;
    internal float pitch;
    internal float pan;

    [LineNumberTable(new byte[] {44, 148, 107, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void stop()
    {
      if (this.handle == 0L || this.voice <= 0)
        return;
      Soloud.sourceStop(this.handle);
      this.voice = 0;
    }

    [LineNumberTable(new byte[] {51, 149})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isPlaying() => this.handle != 0L && this.voice > 0 && (Soloud.idValid(this.voice) && !Soloud.idGetPause(this.voice));

    [LineNumberTable(new byte[] {72, 104, 148, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setVolume(float volume)
    {
      this.volume = volume;
      if (this.handle == 0L || this.voice <= 0)
        return;
      Soloud.idVolume(this.voice, volume);
    }

    [LineNumberTable(new byte[] {159, 115, 162, 103, 148, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setLooping(bool isLooping)
    {
      int num = isLooping ? 1 : 0;
      this.looping = num != 0;
      if (this.handle == 0L || this.voice <= 0)
        return;
      Soloud.idLooping(this.voice, num != 0);
    }

    [LineNumberTable(new byte[] {26, 151, 122, 137, 159, 25, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void play()
    {
      if (this.handle == 0L || !Core.audio.initialized)
        return;
      if (Soloud.idValid(this.voice) && Soloud.idGetPause(this.voice))
      {
        this.pause(false);
      }
      else
      {
        this.voice = Soloud.sourcePlayBus(this.handle, Core.audio.musicBus.handle, this.volume, this.pitch, this.pan, this.looping);
        Soloud.idProtected(this.voice, true);
      }
    }

    [LineNumberTable(new byte[] {159, 185, 232, 54, 135, 255, 2, 74})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Music()
    {
      Music music = this;
      this.voice = -1;
      this.volume = 1f;
      this.pitch = 1f;
      this.pan = 0.0f;
    }

    [Throws(new string[] {"java.lang.Exception"})]
    [LineNumberTable(new byte[] {159, 190, 135, 130, 159, 55, 159, 2, 200, 127, 17, 97, 130, 127, 13, 97, 129, 255, 14, 48, 233, 84, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void load(Fi file)
    {
      this.file = file;
      ArcRuntimeException runtimeException = (ArcRuntimeException) null;
      Fi[] fiArray = Music.caches(new StringBuilder().append(file.nameWithoutExtension()).append("__").append(file.length()).append(".").append(file.extension()).toString());
      int length = fiArray.Length;
      for (int index = 0; index < length; ++index)
      {
        Fi dest = fiArray[index];
        if (dest.exists() && !dest.isDirectory())
        {
          if (dest.length() == file.length())
            goto label_5;
        }
        file.copyTo(dest);
label_5:
        Exception exception1;
        try
        {
          this.handle = Soloud.streamLoad(dest.file().getCanonicalPath());
          return;
        }
        catch (Exception ex)
        {
          M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
          if (m0 == null)
            throw;
          else
            exception1 = (Exception) m0;
        }
        Exception exception2 = exception1;
        try
        {
          this.handle = Soloud.streamLoad(dest.file().getAbsolutePath());
          return;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
        runtimeException = new ArcRuntimeException(new StringBuilder().append("Error loading music: ").append(dest.file().getCanonicalPath()).toString(), (Exception) exception2);
      }
      if (runtimeException != null)
        throw Throwable.__\u003Cunmap\u003E((Exception) runtimeException);
    }

    [Throws(new string[] {"java.lang.Exception"})]
    [LineNumberTable(new byte[] {159, 180, 232, 59, 135, 223, 2, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Music(Fi file)
    {
      Music music = this;
      this.voice = -1;
      this.volume = 1f;
      this.pitch = 1f;
      this.pan = 0.0f;
      this.load(file);
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {106, 139, 109, 127, 7, 31, 18})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal static Fi[] caches(string name)
    {
      string property = java.lang.System.getProperty("java.io.tmpdir");
      return new Fi[3]
      {
        Core.settings.getDataDirectory().child("cache").child(name),
        Core.files.cache(name),
        property != null ? Core.files.absolute(property).child(name) : Core.files.absolute(File.createTempFile(name, "mind").getAbsolutePath())
      };
    }

    [LineNumberTable(new byte[] {159, 120, 66, 148, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void pause(bool pause)
    {
      int num = pause ? 1 : 0;
      if (this.handle == 0L || this.voice <= 0)
        return;
      Soloud.idPause(this.voice, num != 0);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isLooping() => this.looping;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getVolume() => this.volume;

    [LineNumberTable(new byte[] {79, 104, 136, 148, 109, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void set(float pan, float volume)
    {
      this.volume = volume;
      this.pan = pan;
      if (this.handle == 0L || this.voice <= 0)
        return;
      Soloud.idVolume(this.voice, volume);
      Soloud.idPan(this.voice, pan);
    }

    [LineNumberTable(new byte[] {89, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getPosition() => this.handle == 0L ? 0.0f : Soloud.idPosition(this.voice);

    [LineNumberTable(new byte[] {95, 148, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setPosition(float position)
    {
      if (this.handle == 0L || this.voice <= 0)
        return;
      Soloud.idSeek(this.voice, position);
    }

    [LineNumberTable(152)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toString() => new StringBuilder().append("SoloudMusic: ").append((object) this.file).toString();
  }
}
