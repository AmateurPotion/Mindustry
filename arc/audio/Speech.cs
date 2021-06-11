// Decompiled with JetBrains decompiler
// Type: arc.audio.Speech
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using System.Runtime.CompilerServices;

namespace arc.audio
{
  public class Speech : Sound
  {
    [LineNumberTable(new byte[] {159, 149, 104, 115, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Speech()
    {
      Speech speech = this;
      if (Core.audio == null || !Core.audio.initialized())
        return;
      this.handle = Soloud.speechNew();
    }

    [LineNumberTable(new byte[] {159, 156, 106, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setText(string text)
    {
      if (this.handle == 0L)
        return;
      Soloud.speechText(this.handle, text);
    }

    [LineNumberTable(new byte[] {159, 162, 106, 146})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setParams(int freq, float speed, float declination, int waveform)
    {
      if (this.handle == 0L)
        return;
      Soloud.speechParams(this.handle, freq, speed, declination, waveform);
    }
  }
}
