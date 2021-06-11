// Decompiled with JetBrains decompiler
// Type: arc.audio.AudioFilter
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;

namespace arc.audio
{
  public abstract class AudioFilter : Object
  {
    protected internal long handle;

    [LineNumberTable(new byte[] {159, 148, 104, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal AudioFilter(long handle)
    {
      AudioFilter audioFilter = this;
      this.handle = handle;
    }
  }
}
