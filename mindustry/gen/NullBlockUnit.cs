// Decompiled with JetBrains decompiler
// Type: mindustry.gen.NullBlockUnit
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.func;
using arc.graphics;
using arc.graphics.g2d;
using arc.math.geom;
using arc.scene.ui.layout;
using arc.util.io;
using IKVM.Attributes;
using java.nio;
using mindustry.ai.formations;
using mindustry.async;
using mindustry.ctype;
using mindustry.entities;
using mindustry.entities.comp;
using mindustry.entities.units;
using mindustry.game;
using mindustry.logic;
using mindustry.type;
using mindustry.ui;
using mindustry.world;
using mindustry.world.blocks.environment;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.gen
{
  [Implements(new string[] {"mindustry.gen.BlockUnitc"})]
  internal sealed class NullBlockUnit : 
    Unit,
    BlockUnitc,
    Rotc,
    Entityc,
    Teamc,
    Posc,
    Position,
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
    [LineNumberTable(37)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal NullBlockUnit()
    {
    }

    [Signature("<T:Ljava/lang/Object;>()TT;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed object @as() => (object) null;

    [Signature("<T::Lmindustry/gen/Entityc;>()TT;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed Entityc self() => (Entityc) null;

    [Signature("<T:Ljava/lang/Object;>(Larc/func/Cons<TT;>;)TT;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed object with([In] Cons obj0) => (object) null;

    [Signature("()Larc/struct/Seq<Lmindustry/entities/abilities/Ability;>;")]
    [LineNumberTable(59)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed Seq abilities() => new Seq(0);

    [Signature("(Larc/struct/Seq<Lmindustry/entities/abilities/Ability;>;)V")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void abilities([In] Seq obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed bool acceptsItem([In] Item obj0) => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed bool activelyBuilding() => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void add()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void addBuild([In] BuildPlan obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void addBuild([In] BuildPlan obj0, [In] bool obj1)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void addItem([In] Item obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void addItem([In] Item obj0, [In] int obj1)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void afterRead()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void afterSync()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void aim([In] Position obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void aim([In] float obj0, [In] float obj1)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void aimLook([In] Position obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void aimLook([In] float obj0, [In] float obj1)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed float aimX() => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void aimX([In] float obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed float aimY() => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void aimY([In] float obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed float ammo() => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void ammo([In] float obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed float ammof() => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed float angleTo([In] Position obj0) => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed float angleTo([In] float obj0, [In] float obj1) => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void apply([In] StatusEffect obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void apply([In] StatusEffect obj0, [In] float obj1)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void approach([In] Vec2 obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed float armor() => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void armor([In] float obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed Block blockOn() => (Block) null;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed float bounds() => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed BuildPlan buildPlan() => (BuildPlan) null;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed float buildSpeedMultiplier() => 1f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed bool canBuild() => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed bool canDrown() => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed bool canMine() => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed bool canMine([In] Item obj0) => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed bool canPass([In] int obj0, [In] int obj1) => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed bool canPassOn() => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed bool canShoot() => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed int cap() => 0;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed bool cheating() => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed bool checkTarget([In] bool obj0, [In] bool obj1) => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void clampHealth()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed int classId() => 0;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void clearBuilding()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void clearCommand()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void clearItem()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void clearStatuses()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed float clipSize() => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed Building closestCore() => (Building) null;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed Building closestEnemyCore() => (Building) null;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed bool collides([In] Hitboxc obj0) => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void collision([In] Hitboxc obj0, [In] float obj1, [In] float obj2)
    {
    }

    [Signature("(Lmindustry/ai/formations/Formation;Larc/struct/Seq<Lmindustry/gen/Unit;>;)V")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void command([In] Formation obj0, [In] Seq obj1)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void commandNearby([In] FormationPattern obj0)
    {
    }

    [Signature("(Lmindustry/ai/formations/FormationPattern;Larc/func/Boolf<Lmindustry/gen/Unit;>;)V")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void commandNearby([In] FormationPattern obj0, [In] Boolf obj1)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void controlWeapons([In] bool obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void controlWeapons([In] bool obj0, [In] bool obj1)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed UnitController controller() => (UnitController) null;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void controller([In] UnitController obj0)
    {
    }

    [Signature("()Larc/struct/Seq<Lmindustry/gen/Unit;>;")]
    [LineNumberTable(394)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed Seq controlling() => new Seq(10);

    [Signature("(Larc/struct/Seq<Lmindustry/gen/Unit;>;)V")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void controlling([In] Seq obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed Building core() => (Building) null;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed int count() => 0;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void damage([In] float obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void damage([In] float obj0, [In] bool obj1)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void damageContinuous([In] float obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void damageContinuousPierce([In] float obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed float damageMultiplier() => 1f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void damagePierce([In] float obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void damagePierce([In] float obj0, [In] bool obj1)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed bool damaged() => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed bool dead() => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void dead([In] bool obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed float deltaAngle() => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed float deltaLen() => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed float deltaX() => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void deltaX([In] float obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed float deltaY() => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void deltaY([In] float obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void destroy()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed bool disarmed() => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void display([In] Table obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed float drag() => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void drag([In] float obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed float dragMultiplier() => 1f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void draw()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void drawBuildPlans()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void drawPlan([In] BuildPlan obj0, [In] float obj1)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void drawPlanTop([In] BuildPlan obj0, [In] float obj1)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed float drownTime() => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void drownTime([In] float obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed float dst([In] Position obj0) => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed float dst([In] float obj0, [In] float obj1) => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed float dst2([In] Position obj0) => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed float dst2([In] float obj0, [In] float obj1) => 0.0f;

    [Signature("(Larc/func/Cons<Lmindustry/gen/Unit;>;)V")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void eachGroup([In] Cons obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed float elevation() => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void elevation([In] float obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed double flag() => 0.0;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void flag([In] double obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed Floor floorOn() => (Floor) null;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed float floorSpeedMultiplier() => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed Formation formation() => (Formation) null;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void formation([In] Formation obj0)
    {
    }

    [Signature("(Larc/func/Cons<Larc/math/geom/QuadTree;>;)V")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void getCollisions([In] Cons obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed string getControllerName() => (string) null;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed Player getPlayer() => (Player) null;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed float getX() => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed float getY() => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed bool hasEffect([In] StatusEffect obj0) => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed bool hasItem() => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed bool hasWeapons() => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void heal()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void heal([In] float obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void healFract([In] float obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed float health() => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void health([In] float obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed float healthMultiplier() => 1f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed float healthf() => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed float hitSize() => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void hitSize([In] float obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed float hitTime() => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void hitTime([In] float obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void hitbox([In] Rect obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void hitboxTile([In] Rect obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed bool hovering() => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void hovering([In] bool obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed TextureRegion icon() => (TextureRegion) null;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed int id() => -1;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void id([In] int obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void impulse([In] Vec2 obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void impulse([In] float obj0, [In] float obj1)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void impulseNet([In] Vec2 obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed bool inRange([In] Position obj0) => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void interpolate()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed bool isAI() => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed bool isAdded() => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed bool isBoss() => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed bool isBuilding() => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed bool isCommanding() => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed bool isCounted() => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed bool isFlying() => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed bool isGrounded() => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed bool isImmune([In] StatusEffect obj0) => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed bool isLocal() => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed bool isNull() => true;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed bool isPlayer() => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed bool isRemote() => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed bool isRotate() => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed bool isShooting() => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void isShooting([In] bool obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed bool isValid() => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed Item item() => (Item) null;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed int itemCapacity() => 0;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed float itemTime() => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void itemTime([In] float obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void kill()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void killed()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void landed()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed long lastUpdated() => 0;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void lastUpdated([In] long obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed float lastX() => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void lastX([In] float obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed float lastY() => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void lastY([In] float obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void lookAt([In] Position obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void lookAt([In] float obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void lookAt([In] float obj0, [In] float obj1)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed float mass() => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed int maxAccepted([In] Item obj0) => 0;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed float maxHealth() => 1f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void maxHealth([In] float obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed float minFormationSpeed() => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void minFormationSpeed([In] float obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed Tile mineTile() => (Tile) null;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void mineTile([In] Tile obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed float mineTimer() => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void mineTimer([In] float obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed bool mining() => false;

    [LineNumberTable(1062)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed WeaponMount[] mounts() => new WeaponMount[0];

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void mounts([In] WeaponMount[] obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void move([In] float obj0, [In] float obj1)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void moveAt([In] Vec2 obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void moveAt([In] Vec2 obj0, [In] float obj1)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed bool moving() => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed bool offloadImmediately() => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed bool onSolid() => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed int pathType() => 0;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed PhysicsProcess.PhysicRef physref() => (PhysicsProcess.PhysicRef) null;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void physref([In] PhysicsProcess.PhysicRef obj0)
    {
    }

    [Signature("()Larc/struct/Queue<Lmindustry/entities/units/BuildPlan;>;")]
    [LineNumberTable(1123)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed Queue plans() => new Queue(1);

    [Signature("(Larc/struct/Queue<Lmindustry/entities/units/BuildPlan;>;)V")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void plans([In] Queue obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed float prefRotation() => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed float range() => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void read([In] Reads obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void readSync([In] Reads obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void readSyncManual([In] FloatBuffer obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed float realSpeed() => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed float reloadMultiplier() => 1f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void remove()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void removeBuild([In] int obj0, [In] int obj1, [In] bool obj2)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void resetController()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed float rotation() => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void rotation([In] float obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed double sense([In] Content obj0) => 0.0;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed double sense([In] LAccess obj0) => 0.0;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed object senseObject([In] LAccess obj0) => (object) null;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed bool serialize() => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void set([In] Position obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void set([In] float obj0, [In] float obj1)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void set([In] UnitType obj0, [In] UnitController obj1)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void setType([In] UnitType obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void setWeaponRotation([In] float obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void setupWeapons([In] UnitType obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed float shield() => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void shield([In] float obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed float shieldAlpha() => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void shieldAlpha([In] float obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed bool shouldSkip([In] BuildPlan obj0, [In] Building obj1) => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void snapInterpolation()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void snapSync()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed EntityCollisions.SolidPred solidity() => (EntityCollisions.SolidPred) null;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed bool spawnedByCore() => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void spawnedByCore([In] bool obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed float speed() => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed float speedMultiplier() => 1f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed float splashTimer() => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void splashTimer([In] float obj0)
    {
    }

    [LineNumberTable(1331)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed ItemStack stack() => new ItemStack();

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void stack([In] ItemStack obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed Color statusColor() => (Color) null;

    [LineNumberTable(1348)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed Team team() => Team.__\u003C\u003Ederelict;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void team([In] Team obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public Building tile() => (Building) null;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public void tile([In] Building obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed Tile tileOn() => (Tile) null;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed int tileX() => 0;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed int tileY() => 0;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void trns([In] Position obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void trns([In] float obj0, [In] float obj1)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed UnitType type() => (UnitType) null;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void type([In] UnitType obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void unapply([In] StatusEffect obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void update()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed bool updateBuilding() => true;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void updateBuilding([In] bool obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void updateLastPosition()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed long updateSpacing() => 0;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void updateSpacing([In] long obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed bool validMine([In] Tile obj0) => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed bool validMine([In] Tile obj0, [In] bool obj1) => false;

    [LineNumberTable(1458)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed Vec2 vel() => new Vec2();

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed bool within([In] Position obj0, [In] float obj1) => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed bool within([In] float obj0, [In] float obj1, [In] float obj2) => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void wobble()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void write([In] Writes obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void writeSync([In] Writes obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void writeSyncManual([In] FloatBuffer obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed float x() => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void x([In] float obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed float y() => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void y([In] float obj0)
    {
    }
  }
}
