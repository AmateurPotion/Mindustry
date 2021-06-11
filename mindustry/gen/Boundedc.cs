// Decompiled with JetBrains decompiler
// Type: mindustry.gen.Boundedc
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.math.geom;
using IKVM.Attributes;
using mindustry.entities.comp;

namespace mindustry.gen
{
  [Implements(new string[] {"mindustry.gen.Healthc", "mindustry.gen.Posc", "mindustry.gen.Hitboxc", "mindustry.gen.Entityc", "mindustry.gen.Flyingc", "mindustry.gen.Velc"})]
  public interface Boundedc : 
    Healthc,
    Posc,
    Position,
    Entityc,
    Hitboxc,
    Sized,
    QuadTree.QuadTreeObject,
    Flyingc,
    Velc
  {
    new void update();
  }
}
