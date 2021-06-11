// Decompiled with JetBrains decompiler
// Type: mindustry.gen.NullBuilding
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.@struct;
using arc.func;
using arc.graphics.g2d;
using arc.math.geom;
using arc.scene.ui.layout;
using arc.util;
using arc.util.io;
using IKVM.Attributes;
using mindustry.ctype;
using mindustry.entities.comp;
using mindustry.game;
using mindustry.logic;
using mindustry.type;
using mindustry.ui;
using mindustry.world;
using mindustry.world.blocks.environment;
using mindustry.world.blocks.payloads;
using mindustry.world.meta;
using mindustry.world.modules;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.gen
{
  [Implements(new string[] {"mindustry.gen.Buildingc"})]
  internal sealed class NullBuilding : 
    Building,
    Buildingc,
    QuadTree.QuadTreeObject,
    Displayable,
    Senseable,
    Controllable,
    Sized,
    Healthc,
    Posc,
    Position,
    Entityc,
    Teamc,
    Timerc
  {
    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(30)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal NullBuilding()
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

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed bool acceptItem([In] Building obj0, [In] Item obj1) => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed bool acceptLiquid([In] Building obj0, [In] Liquid obj1) => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed bool acceptPayload([In] Building obj0, [In] Payload obj1) => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed int acceptStack([In] Item obj0, [In] int obj1, [In] Teamc obj2) => 0;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void add()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void addPlan([In] bool obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void afterRead()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed float ambientVolume() => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed float angleTo([In] Position obj0) => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed float angleTo([In] float obj0, [In] float obj1) => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void applyBoost([In] float obj0, [In] float obj1)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed Building back() => (Building) null;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed Block block() => (Block) null;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void block([In] Block obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed Block blockOn() => (Block) null;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void buildConfiguration([In] Table obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed bool canDump([In] Building obj0, [In] Item obj1) => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed bool canDumpLiquid([In] Building obj0, [In] Liquid obj1) => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed bool canPickup() => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed bool canUnload() => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed byte cdump() => 0;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void cdump([In] byte obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed bool cheating() => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed bool checkSolid() => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void clampHealth()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed int classId() => 0;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed Building closestCore() => (Building) null;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed Building closestEnemyCore() => (Building) null;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed bool collide([In] Bullet obj0) => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed bool collision([In] Bullet obj0) => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed bool conductsTo([In] Building obj0) => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed object config() => (object) null;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed bool configTapped() => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void configure([In] object obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void configureAny([In] object obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void configured([In] Unit obj0, [In] object obj1)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed ConsumeModule cons() => (ConsumeModule) null;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void cons([In] ConsumeModule obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed bool consValid() => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void consume()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void control(
      [In] LAccess obj0,
      [In] double obj1,
      [In] double obj2,
      [In] double obj3,
      [In] double obj4)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void control(
      [In] LAccess obj0,
      [In] object obj1,
      [In] double obj2,
      [In] double obj3,
      [In] double obj4)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed Building core() => (Building) null;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed Building create([In] Block obj0, [In] Team obj1) => (Building) null;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void created()
    {
    }

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
    public override sealed float delta() => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void deselect()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void display([In] Table obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void displayBars([In] Table obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void displayConsumption([In] Table obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void draw()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void drawConfigure()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void drawCracks()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void drawDisabled()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void drawLight()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void drawLiquidLight([In] Liquid obj0, [In] float obj1)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void drawSelect()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void drawStatus()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void drawTeam()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void drawTeamTop()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void dropped()
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

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed bool dump() => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed bool dump([In] Item obj0) => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void dumpLiquid([In] Liquid obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void dumpLiquid([In] Liquid obj0, [In] float obj1)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed bool dumpPayload([In] Payload obj0) => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed float edelta() => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed float efficiency() => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed bool enabled() => true;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void enabled([In] bool obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed float enabledControlTime() => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void enabledControlTime([In] float obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed Floor floor() => (Floor) null;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed Floor floorOn() => (Floor) null;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed Building front() => (Building) null;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed Graphics.Cursor getCursor() => (Graphics.Cursor) null;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed float getDisplayEfficiency() => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed TextureRegion getDisplayIcon() => (TextureRegion) null;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed string getDisplayName() => (string) null;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed Building getLiquidDestination([In] Building obj0, [In] Liquid obj1) => (Building) null;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed int getMaximumAccepted([In] Item obj0) => 0;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed Payload getPayload() => (Payload) null;

    [Signature("(Larc/struct/Seq<Lmindustry/gen/Building;>;)Larc/struct/Seq<Lmindustry/gen/Building;>;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed Seq getPowerConnections([In] Seq obj0) => (Seq) null;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed float getPowerProduction() => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed float getProgressIncrease([In] float obj0) => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void getStackOffset([In] Item obj0, [In] Vec2 obj1)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed float getX() => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed float getY() => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed float handleDamage([In] float obj0) => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void handleItem([In] Building obj0, [In] Item obj1)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void handleLiquid([In] Building obj0, [In] Liquid obj1, [In] float obj2)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void handlePayload([In] Building obj0, [In] Payload obj1)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void handleStack([In] Item obj0, [In] int obj1, [In] Teamc obj2)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void handleString([In] object obj0)
    {
    }

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
    public override sealed float healthf() => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed float hitSize() => 0.0f;

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
    public override sealed int id() => -1;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void id([In] int obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void incrementDump([In] int obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed Building init([In] Tile obj0, [In] Team obj1, [In] bool obj2, [In] int obj3) => (Building) null;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed bool interactable([In] Team obj0) => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed bool isAdded() => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed bool isLocal() => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed bool isNull() => true;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed bool isRemote() => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed bool isValid() => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void itemTaken([In] Item obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed ItemModule items() => (ItemModule) null;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void items([In] ItemModule obj0)
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
    public override sealed string lastAccessed() => (string) null;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void lastAccessed([In] string obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed Building left() => (Building) null;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed LiquidModule liquids() => (LiquidModule) null;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void liquids([In] LiquidModule obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed float maxHealth() => 1f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void maxHealth([In] float obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed bool moveForward([In] Item obj0) => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed float moveLiquid([In] Building obj0, [In] Liquid obj1) => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed float moveLiquidForward([In] bool obj0, [In] Liquid obj1) => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed bool movePayload([In] Payload obj0) => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed Building nearby([In] int obj0) => (Building) null;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed Building nearby([In] int obj0, [In] int obj1) => (Building) null;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void noSleep()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void offload([In] Item obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed bool onConfigureTileTapped([In] Building obj0) => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void onDestroyed()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void onProximityAdded()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void onProximityRemoved()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void onProximityUpdate()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void onRemoved()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed bool onSolid() => false;

    [Signature("(Larc/struct/Seq<Lmindustry/gen/Building;>;)V")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void overwrote([In] Seq obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void pickedUp()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void placed()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void playerPlaced([In] object obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed int pos() => 0;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed PowerModule power() => (PowerModule) null;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void power([In] PowerModule obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void powerGraphRemoved()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void produced([In] Item obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void produced([In] Item obj0, [In] int obj1)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed bool productionValid() => false;

    [Signature("()Larc/struct/Seq<Lmindustry/gen/Building;>;")]
    [LineNumberTable(964)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed Seq proximity() => new Seq(8);

    [Signature("(Larc/struct/Seq<Lmindustry/gen/Building;>;)V")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void proximity([In] Seq obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed bool put([In] Item obj0) => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void read([In] Reads obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void read([In] Reads obj0, [In] byte obj1)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void readAll([In] Reads obj0, [In] byte obj1)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void readBase([In] Reads obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed byte relativeTo([In] Building obj0) => 0;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed byte relativeTo([In] int obj0, [In] int obj1) => 0;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed byte relativeTo([In] Tile obj0) => 0;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed byte relativeToEdge([In] Tile obj0) => 0;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void remove()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void removeFromProximity()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed int removeStack([In] Item obj0, [In] int obj1) => 0;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed Building right() => (Building) null;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed int rotation() => 0;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void rotation([In] int obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed float rotdeg() => 0.0f;

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
    public override sealed bool shouldActiveSound() => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed bool shouldAmbientSound() => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed bool shouldConsume() => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed bool shouldHideConfigure([In] Player obj0) => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed bool shouldShowConfigure([In] Player obj0) => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void sleep()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed BlockStatus status() => (BlockStatus) null;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed Payload takePayload() => (Payload) null;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void tapped()
    {
    }

    [LineNumberTable(1150)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed Team team() => Team.__\u003C\u003Ederelict;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void team([In] Team obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed Tile tile() => (Tile) null;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void tile([In] Tile obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed Tile tileOn() => (Tile) null;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed int tileX() => 0;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed int tileY() => 0;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed float timeScale() => 1f;

    [LineNumberTable(1196)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed Interval timer() => new Interval(6);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void timer([In] Interval obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed bool timer([In] int obj0, [In] float obj1) => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void transferLiquid([In] Building obj0, [In] float obj1, [In] Liquid obj2)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void trns([In] Position obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void trns([In] float obj0, [In] float obj1)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void unitOn([In] Unit obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void unitRemoved([In] Unit obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void update()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed bool updateFlow() => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void updateFlow([In] bool obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void updatePowerGraph()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void updateProximity()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void updateTableAlign([In] Table obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void updateTile()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed byte version() => 0;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed bool within([In] Position obj0, [In] float obj1) => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed bool within([In] float obj0, [In] float obj1, [In] float obj2) => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void write([In] Writes obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void writeAll([In] Writes obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void writeBase([In] Writes obj0)
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

    [HideFromJava]
    static NullBuilding() => Building.__\u003Cclinit\u003E();
  }
}
