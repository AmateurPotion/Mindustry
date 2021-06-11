// Decompiled with JetBrains decompiler
// Type: mindustry.gen.NullBuilder
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.func;
using arc.graphics;
using arc.math.geom;
using arc.util.io;
using IKVM.Attributes;
using java.lang;
using mindustry.entities;
using mindustry.entities.comp;
using mindustry.entities.units;
using mindustry.game;
using mindustry.type;
using mindustry.world;
using mindustry.world.blocks.environment;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.gen
{
  [Implements(new string[] {"mindustry.gen.Builderc"})]
  internal sealed class NullBuilder : 
    Object,
    Builderc,
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
    [LineNumberTable(21)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal NullBuilder()
    {
    }

    [Signature("<T:Ljava/lang/Object;>()TT;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public object @as() => (object) null;

    [Signature("<T::Lmindustry/gen/Entityc;>()TT;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Entityc self() => (Entityc) null;

    [Signature("<T:Ljava/lang/Object;>(Larc/func/Cons<TT;>;)TT;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public object with([In] Cons obj0) => (object) null;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public bool activelyBuilding() => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public void add()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public void addBuild([In] BuildPlan obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public void addBuild([In] BuildPlan obj0, [In] bool obj1)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public void afterRead()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public float angleTo([In] Position obj0) => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public float angleTo([In] float obj0, [In] float obj1) => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public void apply([In] StatusEffect obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public void apply([In] StatusEffect obj0, [In] float obj1)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public Block blockOn() => (Block) null;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public BuildPlan buildPlan() => (BuildPlan) null;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public float buildSpeedMultiplier() => 1f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public bool canBuild() => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public bool canDrown() => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public bool canPass([In] int obj0, [In] int obj1) => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public bool canPassOn() => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public bool cheating() => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public bool checkTarget([In] bool obj0, [In] bool obj1) => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public void clampHealth()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public int classId() => 0;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public void clearBuilding()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public void clearStatuses()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public Building closestCore() => (Building) null;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public Building closestEnemyCore() => (Building) null;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public bool collides([In] Hitboxc obj0) => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public void collision([In] Hitboxc obj0, [In] float obj1, [In] float obj2)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public Building core() => (Building) null;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public void damage([In] float obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public void damage([In] float obj0, [In] bool obj1)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public void damageContinuous([In] float obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public void damageContinuousPierce([In] float obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public float damageMultiplier() => 1f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public void damagePierce([In] float obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public void damagePierce([In] float obj0, [In] bool obj1)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public bool damaged() => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public bool dead() => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public void dead([In] bool obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public float deltaAngle() => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public float deltaLen() => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public float deltaX() => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public void deltaX([In] float obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public float deltaY() => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public void deltaY([In] float obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public bool disarmed() => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public float drag() => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public void drag([In] float obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public float dragMultiplier() => 1f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public void draw()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public void drawBuildPlans()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public void drawPlan([In] BuildPlan obj0, [In] float obj1)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public void drawPlanTop([In] BuildPlan obj0, [In] float obj1)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public float drownTime() => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public void drownTime([In] float obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public float dst([In] Position obj0) => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public float dst([In] float obj0, [In] float obj1) => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public float dst2([In] Position obj0) => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public float dst2([In] float obj0, [In] float obj1) => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public float elevation() => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public void elevation([In] float obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public Floor floorOn() => (Floor) null;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public float floorSpeedMultiplier() => 0.0f;

    [Signature("(Larc/func/Cons<Larc/math/geom/QuadTree;>;)V")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public void getCollisions([In] Cons obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public float getX() => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public float getY() => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public bool hasEffect([In] StatusEffect obj0) => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public void heal()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public void heal([In] float obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public void healFract([In] float obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public float health() => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public void health([In] float obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public float healthMultiplier() => 1f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public float healthf() => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public float hitSize() => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public void hitSize([In] float obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public float hitTime() => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public void hitTime([In] float obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public void hitbox([In] Rect obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public void hitboxTile([In] Rect obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public bool hovering() => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public void hovering([In] bool obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public int id() => -1;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public void id([In] int obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public bool isAdded() => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public bool isBoss() => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public bool isBuilding() => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public bool isFlying() => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public bool isGrounded() => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public bool isImmune([In] StatusEffect obj0) => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public bool isLocal() => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public bool isNull() => true;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public bool isRemote() => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public bool isValid() => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public void kill()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public void killed()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public void landed()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public float lastX() => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public void lastX([In] float obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public float lastY() => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public void lastY([In] float obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public float maxHealth() => 1f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public void maxHealth([In] float obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public void move([In] float obj0, [In] float obj1)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public void moveAt([In] Vec2 obj0, [In] float obj1)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public bool moving() => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public bool onSolid() => false;

    [Signature("()Larc/struct/Queue<Lmindustry/entities/units/BuildPlan;>;")]
    [LineNumberTable(628)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Queue plans() => new Queue(1);

    [Signature("(Larc/struct/Queue<Lmindustry/entities/units/BuildPlan;>;)V")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public void plans([In] Queue obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public void read([In] Reads obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public float reloadMultiplier() => 1f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public void remove()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public void removeBuild([In] int obj0, [In] int obj1, [In] bool obj2)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public float rotation() => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public void rotation([In] float obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public bool serialize() => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public void set([In] Position obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public void set([In] float obj0, [In] float obj1)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public bool shouldSkip([In] BuildPlan obj0, [In] Building obj1) => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public EntityCollisions.SolidPred solidity() => (EntityCollisions.SolidPred) null;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public float speedMultiplier() => 1f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public float splashTimer() => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public void splashTimer([In] float obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public Color statusColor() => (Color) null;

    [LineNumberTable(722)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Team team() => Team.__\u003C\u003Ederelict;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public void team([In] Team obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public Tile tileOn() => (Tile) null;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public int tileX() => 0;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public int tileY() => 0;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public void trns([In] Position obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public void trns([In] float obj0, [In] float obj1)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public void unapply([In] StatusEffect obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public void update()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public bool updateBuilding() => true;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public void updateBuilding([In] bool obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public void updateLastPosition()
    {
    }

    [LineNumberTable(787)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Vec2 vel() => new Vec2();

    [MethodImpl(MethodImplOptions.NoInlining)]
    public bool within([In] Position obj0, [In] float obj1) => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public bool within([In] float obj0, [In] float obj1, [In] float obj2) => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public void wobble()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public void write([In] Writes obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public float x() => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public void x([In] float obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public float y() => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public void y([In] float obj0)
    {
    }
  }
}
