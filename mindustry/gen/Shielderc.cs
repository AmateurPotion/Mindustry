// Decompiled with JetBrains decompiler
// Type: mindustry.gen.Shielderc
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.math.geom;
using IKVM.Attributes;

namespace mindustry.gen
{
  [Implements(new string[] {"mindustry.gen.Damagec", "mindustry.gen.Posc", "mindustry.gen.Teamc", "mindustry.gen.Entityc"})]
  public interface Shielderc : Damagec, Entityc, Posc, Position, Teamc
  {
    void absorb();
  }
}
