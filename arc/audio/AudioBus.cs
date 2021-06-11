// Decompiled with JetBrains decompiler
// Type: arc.audio.AudioBus
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.util;
using IKVM.Attributes;
using System.Runtime.CompilerServices;

namespace arc.audio
{
  public class AudioBus : AudioSource
  {
    public int id;

    [LineNumberTable(new byte[] {159, 153, 104, 115, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public AudioBus()
    {
      AudioBus audioBus = this;
      if (Core.audio == null || !Core.audio.initialized)
        return;
      this.init();
    }

    [LineNumberTable(new byte[] {159, 161, 107, 121})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setFilter(int index, [Nullable(new object[] {64, "Larc/util/Nullable;"})] AudioFilter filter)
    {
      if (this.handle == 0L)
        return;
      Soloud.sourceFilter(this.handle, index, filter != null ? filter.handle : 0L);
    }

    [LineNumberTable(new byte[] {4, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setFilterParam(int filter, int attribute, float value) => Core.audio.setFilterParam(this.id, filter, attribute, value);

    [LineNumberTable(new byte[] {0, 119})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void fadeFilterParam(int filter, int attribute, float value, float timeSec) => Core.audio.fadeFilterParam(this.id, filter, attribute, value, timeSec);

    [LineNumberTable(new byte[] {159, 177, 120, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void play()
    {
      if (this.handle == 0L || Soloud.idValid(this.id))
        return;
      this.id = Soloud.sourcePlay(this.handle);
    }

    [LineNumberTable(new byte[] {159, 182, 107, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void replay()
    {
      if (this.handle == 0L)
        return;
      this.id = Soloud.sourcePlay(this.handle);
    }

    [LineNumberTable(new byte[] {159, 166, 108, 107, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual AudioBus init()
    {
      if (this.handle != 0L)
        return this;
      this.handle = Soloud.busNew();
      this.id = Soloud.sourcePlay(this.handle);
      return this;
    }

    [LineNumberTable(31)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool playing() => this.handle != 0L && Core.audio.isPlaying(this.id);

    [LineNumberTable(new byte[] {159, 187, 112, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void stop()
    {
      Core.audio.stop(this.id);
      this.id = 0;
    }

    [LineNumberTable(new byte[] {8, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setVolume(float volume) => Core.audio.setVolume(this.id, volume);
  }
}
