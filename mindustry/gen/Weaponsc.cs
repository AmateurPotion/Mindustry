// Decompiled with JetBrains decompiler
// Type: mindustry.gen.Weaponsc
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.math.geom;
using IKVM.Attributes;
using mindustry.entities.comp;
using mindustry.entities.units;
using mindustry.type;

namespace mindustry.gen
{
  [Implements(new string[] {"mindustry.gen.Rotc", "mindustry.gen.Teamc", "mindustry.gen.Flyingc", "mindustry.gen.Healthc", "mindustry.gen.Posc", "mindustry.gen.Statusc", "mindustry.gen.Hitboxc", "mindustry.gen.Entityc", "mindustry.gen.Velc"})]
  public interface Weaponsc : 
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
    Statusc
  {
    void controlWeapons(bool b1, bool b2);

    float aimX();

    float aimY();

    void aim(float f1, float f2);

    void aim(Position p);

    void controlWeapons(bool b);

    float ammof();

    void setWeaponRotation(float f);

    void setupWeapons(UnitType ut);

    bool canShoot();

    new void remove();

    new void update();

    WeaponMount[] mounts();

    void mounts(WeaponMount[] wmarr);

    bool isRotate();

    void aimX(float f);

    void aimY(float f);

    bool isShooting();

    void isShooting(bool b);

    float ammo();

    void ammo(float f);
  }
}
