// Decompiled with JetBrains decompiler
// Type: arc.audio.Sound
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.files;
using arc.math;
using arc.math.geom;
using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;

namespace arc.audio
{
  public class Sound : AudioSource
  {
    public AudioBus bus;
    internal long framePlayed;
    internal Fi file;

    [LineNumberTable(133)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int play() => this.play(1f * (float) Core.settings.getInt("sfxvol") / 100f);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setBus(AudioBus bus) => this.bus = bus;

    [LineNumberTable(new byte[] {35, 146, 127, 10})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float calcFalloff(float x, float y)
    {
      if (Core.app.isHeadless())
        return 1f;
      float num = Mathf.dst(x, y, Core.camera.__\u003C\u003Eposition.x, Core.camera.__\u003C\u003Eposition.y);
      return Mathf.clamp(1f / (num * num / Core.audio.falloff));
    }

    [LineNumberTable(new byte[] {25, 146})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float calcPan(float x, float y) => Core.app.isHeadless() ? 0.0f : Mathf.clamp((x - Core.camera.__\u003C\u003Eposition.x) / (Core.camera.width / 2f), -0.9f, 0.9f);

    [LineNumberTable(182)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int loop(float volume, float pitch, float pan) => this.play(volume, pitch, pan, true);

    [LineNumberTable(new byte[] {20, 107, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void stop()
    {
      if (this.handle == 0L)
        return;
      Soloud.sourceStop(this.handle);
    }

    [LineNumberTable(81)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float calcVolume(float x, float y) => this.calcFalloff(x, y) * (float) Core.settings.getInt("sfxvol") / 100f;

    [LineNumberTable(new byte[] {54, 113, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int at(float x, float y, float pitch, float volume)
    {
      float volume1 = this.calcVolume(x, y) * volume;
      return (double) volume1 < 0.00999999977648258 ? -1 : this.play(volume1, pitch, this.calcPan(x, y));
    }

    [LineNumberTable(119)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int at(Position pos) => this.at(pos.getX(), pos.getY());

    [LineNumberTable(96)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int at(float x, float y, float pitch) => this.at(x, y, pitch, 1f);

    [LineNumberTable(new byte[] {159, 178, 232, 58, 250, 72})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Sound()
    {
      Sound sound = this;
      this.bus = Core.audio != null ? Core.audio.soundBus : (AudioBus) null;
    }

    [LineNumberTable(124)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int at(Position pos, float pitch) => this.at(pos.getX(), pos.getY(), pitch);

    [LineNumberTable(114)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int at(float x, float y) => this.at(x, y, 1f);

    [LineNumberTable(new byte[] {159, 188, 103, 103, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void load(Fi file)
    {
      byte[] numArray = file.readBytes();
      this.file = file;
      this.handle = Soloud.wavLoad(numArray, numArray.Length);
    }

    [LineNumberTable(new byte[] {159, 183, 232, 53, 250, 76, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Sound(Fi file)
    {
      Sound sound = this;
      this.bus = Core.audio != null ? Core.audio.soundBus : (AudioBus) null;
      this.load(file);
    }

    [LineNumberTable(154)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int play(float volume, float pitch, float pan) => this.play(volume, pitch, pan, false);

    [LineNumberTable(143)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int play(float volume) => this.play(volume, 1f, 0.0f);

    [LineNumberTable(new byte[] {159, 128, 163, 127, 19, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int play(float volume, float pitch, float pan, bool loop)
    {
      int num = loop ? 1 : 0;
      if (this.handle == 0L || this.framePlayed == Core.graphics.getFrameId() || (this.bus == null || !Core.audio.initialized))
        return -1;
      this.framePlayed = Core.graphics.getFrameId();
      return Soloud.sourcePlayBus(this.handle, this.bus.handle, volume, pitch, pan, num != 0);
    }

    [LineNumberTable(171)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int loop(float volume) => this.loop(volume, 1f, 0.0f);

    [LineNumberTable(162)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int loop() => this.loop(1f);

    [LineNumberTable(187)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toString() => new StringBuilder().append("SoloudSound: ").append((object) this.file).toString();
  }
}
