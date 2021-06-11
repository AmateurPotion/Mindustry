// Decompiled with JetBrains decompiler
// Type: mindustry.gen.Unitc
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.func;
using arc.graphics.g2d;
using arc.math.geom;
using arc.scene.ui.layout;
using IKVM.Attributes;
using mindustry.ctype;
using mindustry.entities.comp;
using mindustry.entities.units;
using mindustry.logic;
using mindustry.type;
using mindustry.ui;

namespace mindustry.gen
{
  [Implements(new string[] {"mindustry.ui.Displayable", "mindustry.logic.Senseable", "mindustry.logic.Ranged", "mindustry.gen.Rotc", "mindustry.gen.Healthc", "mindustry.gen.Drawc", "mindustry.gen.Shieldc", "mindustry.gen.Minerc", "mindustry.gen.Posc", "mindustry.gen.Weaponsc", "mindustry.gen.Hitboxc", "mindustry.gen.Statusc", "mindustry.gen.Teamc", "mindustry.gen.Commanderc", "mindustry.gen.Physicsc", "mindustry.gen.Syncc", "mindustry.gen.Entityc", "mindustry.gen.Builderc", "mindustry.gen.Flyingc", "mindustry.gen.Velc", "mindustry.gen.Itemsc", "mindustry.gen.Boundedc"})]
  public interface Unitc : 
    Displayable,
    Senseable,
    Ranged,
    Posc,
    Position,
    Entityc,
    Teamc,
    Rotc,
    Healthc,
    Drawc,
    Shieldc,
    Minerc,
    Itemsc,
    Weaponsc,
    Flyingc,
    Hitboxc,
    Sized,
    QuadTree.QuadTreeObject,
    Velc,
    Statusc,
    Commanderc,
    Physicsc,
    Syncc,
    Builderc,
    Boundedc
  {
    bool isPlayer();

    float prefRotation();

    void lookAt(float f);

    bool hasWeapons();

    int pathType();

    float speed();

    void moveAt(Vec2 v);

    float realSpeed();

    void lookAt(Position p);

    void resetController();

    void lookAt(float f1, float f2);

    void approach(Vec2 v);

    void aimLook(Position p);

    void spawnedByCore(bool b);

    float bounds();

    void setType(UnitType ut);

    UnitController controller();

    UnitType type();

    bool isCounted();

    new void kill();

    void destroy();

    void aimLook(float f1, float f2);

    bool inRange(Position p);

    [Signature("(Larc/func/Cons<Lmindustry/gen/Unit;>;)V")]
    void eachGroup(Cons c);

    new float range();

    new float clipSize();

    new double sense(LAccess la);

    new object senseObject(LAccess la);

    new double sense(Content c);

    new bool canDrown();

    new bool canShoot();

    new int itemCapacity();

    new void controller(UnitController uc);

    void set(UnitType ut, UnitController uc);

    bool isAI();

    int count();

    int cap();

    new void afterSync();

    new void afterRead();

    new void add();

    new void remove();

    new void landed();

    new void update();

    TextureRegion icon();

    string getControllerName();

    new void display(Table t);

    new bool isImmune(StatusEffect se);

    new void draw();

    Player getPlayer();

    new void killed();

    void type(UnitType ut);

    bool spawnedByCore();

    double flag();

    void flag(double d);

    [Signature("()Larc/struct/Seq<Lmindustry/entities/abilities/Ability;>;")]
    Seq abilities();

    [Signature("(Larc/struct/Seq<Lmindustry/entities/abilities/Ability;>;)V")]
    void abilities(Seq s);
  }
}
