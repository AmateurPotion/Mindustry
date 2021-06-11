// Decompiled with JetBrains decompiler
// Type: arc.audio.Filters
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;

namespace arc.audio
{
  public class Filters : Object
  {
    public const int paramWet = 0;

    [LineNumberTable(5)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Filters()
    {
    }

    public class BassBoostFilter : AudioFilter
    {
      [LineNumberTable(new byte[] {16, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public BassBoostFilter()
        : base(Soloud.filterBassBoost())
      {
      }

      [LineNumberTable(new byte[] {20, 109})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void set(float amount) => Soloud.bassBoostSet(this.handle, amount);
    }

    public class BiquadFilter : AudioFilter
    {
      [LineNumberTable(new byte[] {159, 153, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public BiquadFilter()
        : base(Soloud.filterBiquad())
      {
      }

      [LineNumberTable(new byte[] {159, 157, 112})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void set(int type, float frequency, float resonance) => Soloud.biquadSet(this.handle, type, frequency, resonance);
    }

    public class EchoFilter : AudioFilter
    {
      [LineNumberTable(new byte[] {159, 164, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public EchoFilter()
        : base(Soloud.filterEcho())
      {
      }

      [LineNumberTable(new byte[] {159, 168, 113})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void set(float delay, float decay, float filter) => Soloud.echoSet(this.handle, delay, decay, filter);
    }

    public class FlangerFilter : AudioFilter
    {
      [LineNumberTable(new byte[] {159, 186, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public FlangerFilter()
        : base(Soloud.filterFlanger())
      {
      }

      [LineNumberTable(new byte[] {159, 190, 111})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void set(float delay, float frequency) => Soloud.flangerSet(this.handle, delay, frequency);
    }

    public class FreeverbFilter : AudioFilter
    {
      [LineNumberTable(new byte[] {38, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public FreeverbFilter()
        : base(Soloud.filterFreeverb())
      {
      }

      [LineNumberTable(new byte[] {42, 116})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void set(float mode, float roomSize, float damp, float width) => Soloud.freeverbSet(this.handle, mode, roomSize, damp, width);
    }

    public class LofiFilter : AudioFilter
    {
      [LineNumberTable(new byte[] {159, 175, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public LofiFilter()
        : base(Soloud.filterLofi())
      {
      }

      [LineNumberTable(new byte[] {159, 179, 111})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void set(float sampleRate, float depth) => Soloud.lofiSet(this.handle, sampleRate, depth);
    }

    public class RobotizeFilter : AudioFilter
    {
      [LineNumberTable(new byte[] {27, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public RobotizeFilter()
        : base(Soloud.filterRobotize())
      {
      }

      [LineNumberTable(new byte[] {31, 110})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void set(float freq, int waveform) => Soloud.robotizeSet(this.handle, freq, waveform);
    }

    public class WaveShaperFilter : AudioFilter
    {
      [LineNumberTable(new byte[] {5, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public WaveShaperFilter()
        : base(Soloud.filterWaveShaper())
      {
      }

      [LineNumberTable(new byte[] {9, 109})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void set(float amount) => Soloud.waveShaperSet(this.handle, amount);
    }
  }
}
