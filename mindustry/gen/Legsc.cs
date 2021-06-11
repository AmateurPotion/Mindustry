// Decompiled with JetBrains decompiler
// Type: mindustry.gen.Legsc
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.math.geom;
using IKVM.Attributes;
using mindustry.entities;
using mindustry.entities.comp;
using mindustry.logic;
using mindustry.ui;

namespace mindustry.gen
{
  [Implements(new string[] {"mindustry.gen.Rotc", "mindustry.gen.Teamc", "mindustry.gen.Flyingc", "mindustry.gen.Drawc", "mindustry.gen.Shieldc", "mindustry.gen.Minerc", "mindustry.gen.Healthc", "mindustry.gen.Posc", "mindustry.gen.Weaponsc", "mindustry.gen.Statusc", "mindustry.gen.Hitboxc", "mindustry.gen.Unitc", "mindustry.gen.Commanderc", "mindustry.gen.Physicsc", "mindustry.gen.Syncc", "mindustry.gen.Entityc", "mindustry.gen.Builderc", "mindustry.gen.Velc", "mindustry.gen.Itemsc", "mindustry.gen.Boundedc"})]
  public interface Legsc : 
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
    Boundedc
  {
    Leg[] legs();

    float baseRotation();

    float legAngle(float f, int i);

    new EntityCollisions.SolidPred solidity();

    new int pathType();

    new void add();

    void resetLegs();

    new void update();

    void legs(Leg[] larr);

    float totalLength();

    void totalLength(float f);

    float moveSpace();

    void moveSpace(float f);

    void baseRotation(float f);
  }
}
