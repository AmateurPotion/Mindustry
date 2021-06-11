// Decompiled with JetBrains decompiler
// Type: mindustry.gen.ElevationMovec
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.math.geom;
using IKVM.Attributes;
using mindustry.entities;
using mindustry.entities.comp;

namespace mindustry.gen
{
  [Implements(new string[] {"mindustry.gen.Flyingc", "mindustry.gen.Healthc", "mindustry.gen.Posc", "mindustry.gen.Hitboxc", "mindustry.gen.Entityc", "mindustry.gen.Velc"})]
  public interface ElevationMovec : 
    Flyingc,
    Healthc,
    Posc,
    Position,
    Entityc,
    Hitboxc,
    Sized,
    QuadTree.QuadTreeObject,
    Velc
  {
    new EntityCollisions.SolidPred solidity();
  }
}
