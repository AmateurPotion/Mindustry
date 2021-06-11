// Decompiled with JetBrains decompiler
// Type: mindustry.gen.Mechc
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.math.geom;
using IKVM.Attributes;
using mindustry.entities.comp;
using mindustry.logic;
using mindustry.ui;

namespace mindustry.gen
{
  [Implements(new string[] {"mindustry.gen.Rotc", "mindustry.gen.Teamc", "mindustry.gen.Flyingc", "mindustry.gen.Drawc", "mindustry.gen.Shieldc", "mindustry.gen.Minerc", "mindustry.gen.Healthc", "mindustry.gen.Posc", "mindustry.gen.Weaponsc", "mindustry.gen.Statusc", "mindustry.gen.Hitboxc", "mindustry.gen.Unitc", "mindustry.gen.Commanderc", "mindustry.gen.Physicsc", "mindustry.gen.Syncc", "mindustry.gen.Entityc", "mindustry.gen.Builderc", "mindustry.gen.ElevationMovec", "mindustry.gen.Velc", "mindustry.gen.Itemsc", "mindustry.gen.Boundedc"})]
  public interface Mechc : 
    Rotc,
    Entityc,
    Teamc,
    Posc,
    Position,
    Flyingc,
    Healthc,
    Hitboxc,
    Sized,
    QuadTree.QuadTreeObject,
    Velc,
    Drawc,
    Shieldc,
    Minerc,
    Itemsc,
    Weaponsc,
    Statusc,
    Unitc,
    Displayable,
    Senseable,
    Ranged,
    Commanderc,
    Physicsc,
    Syncc,
    Builderc,
    Boundedc,
    ElevationMovec
  {
    float baseRotation();

    float walkExtend(bool b);

    new void update();

    new void moveAt(Vec2 v, float f);

    new void approach(Vec2 v);

    void baseRotation(float f);

    float walkTime();

    void walkTime(float f);

    float walkExtension();

    void walkExtension(float f);
  }
}
