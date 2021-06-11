// Decompiled with JetBrains decompiler
// Type: mindustry.logic.Ranged
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.math.geom;
using IKVM.Attributes;
using mindustry.gen;

namespace mindustry.logic
{
  [Implements(new string[] {"mindustry.gen.Posc", "mindustry.gen.Teamc"})]
  public interface Ranged : Posc, Position, Entityc, Teamc
  {
    float range();
  }
}
