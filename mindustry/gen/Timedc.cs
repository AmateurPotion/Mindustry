// Decompiled with JetBrains decompiler
// Type: mindustry.gen.Timedc
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.math;
using IKVM.Attributes;

namespace mindustry.gen
{
  [Implements(new string[] {"arc.math.Scaled", "mindustry.gen.Entityc"})]
  public interface Timedc : Scaled, Entityc
  {
    new void update();

    new float fin();

    float time();

    void time(float f);

    float lifetime();

    void lifetime(float f);
  }
}
