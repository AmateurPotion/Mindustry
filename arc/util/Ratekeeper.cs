// Decompiled with JetBrains decompiler
// Type: arc.util.Ratekeeper
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;

namespace arc.util
{
  public class Ratekeeper : Object
  {
    public int occurences;
    public long lastTime;

    [LineNumberTable(new byte[] {159, 156, 110, 103, 171, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool allow(long spacing, int cap)
    {
      if (Time.timeSinceMillis(this.lastTime) > spacing)
      {
        this.occurences = 0;
        this.lastTime = Time.millis();
      }
      ++this.occurences;
      return this.occurences <= cap;
    }

    [LineNumberTable(4)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Ratekeeper()
    {
    }
  }
}
