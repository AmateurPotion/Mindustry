// Decompiled with JetBrains decompiler
// Type: mindustry.audio.SoundLoop
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.audio;
using arc.math;
using arc.util;
using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;

namespace mindustry.audio
{
  public class SoundLoop : Object
  {
    private const float fadeSpeed = 0.05f;
    [Modifiers]
    private Sound sound;
    private int id;
    private float volume;
    private float baseVolume;

    [LineNumberTable(new byte[] {159, 158, 232, 61, 199, 103, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public SoundLoop(Sound sound, float baseVolume)
    {
      SoundLoop soundLoop = this;
      this.id = -1;
      this.sound = sound;
      this.baseVolume = baseVolume;
    }

    [LineNumberTable(new byte[] {159, 137, 130, 142, 105, 102, 223, 44, 99, 159, 3, 127, 1, 109, 112, 103, 193, 159, 33})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void update(float x, float y, bool play)
    {
      int num = play ? 1 : 0;
      if ((double) this.baseVolume <= 0.0)
        return;
      if (this.id < 0)
      {
        if (num == 0)
          return;
        this.id = this.sound.loop(this.sound.calcVolume(x, y) * this.volume * this.baseVolume, 1f, this.sound.calcPan(x, y));
      }
      else
      {
        if (num != 0)
        {
          this.volume = Mathf.clamp(this.volume + 0.05f * Time.delta);
        }
        else
        {
          this.volume = Mathf.clamp(this.volume - 0.05f * Time.delta);
          if ((double) this.volume <= 1.0 / 1000.0)
          {
            Core.audio.stop(this.id);
            this.id = -1;
            return;
          }
        }
        Core.audio.set(this.id, this.sound.calcPan(x, y), this.sound.calcVolume(x, y) * this.volume * this.baseVolume);
      }
    }

    [LineNumberTable(new byte[] {159, 188, 105, 112, 103, 150})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void stop()
    {
      if (this.id == -1)
        return;
      Core.audio.stop(this.id);
      this.id = -1;
      SoundLoop soundLoop = this;
      float num1 = -1f;
      double num2 = (double) num1;
      this.baseVolume = num1;
      this.volume = (float) num2;
    }
  }
}
