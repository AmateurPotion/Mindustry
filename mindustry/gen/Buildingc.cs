// Decompiled with JetBrains decompiler
// Type: mindustry.gen.Buildingc
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.@struct;
using arc.graphics.g2d;
using arc.math.geom;
using arc.scene.ui.layout;
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

namespace mindustry.gen
{
  [Implements(new string[] {"arc.math.geom.QuadTree$QuadTreeObject", "mindustry.ui.Displayable", "mindustry.logic.Senseable", "mindustry.logic.Controllable", "mindustry.entities.comp.Sized", "mindustry.gen.Healthc", "mindustry.gen.Posc", "mindustry.gen.Teamc", "mindustry.gen.Timerc", "mindustry.gen.Entityc"})]
  public interface Buildingc : 
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
    Building init(Tile t1, Team t2, bool b, int i);

    Building create(Block b, Team t);

    new int tileX();

    new int tileY();

    void writeBase(Writes w);

    void readBase(Reads r);

    void writeAll(Writes w);

    void readAll(Reads r, byte b);

    new void write(Writes w);

    void read(Reads r, byte b);

    void addPlan(bool b);

    void configure(object obj);

    void configureAny(object obj);

    void deselect();

    bool configTapped();

    void applyBoost(float f1, float f2);

    Building nearby(int i1, int i2);

    Building nearby(int i);

    byte relativeTo(Tile t);

    byte relativeTo(Building b);

    byte relativeToEdge(Tile t);

    byte relativeTo(int i1, int i2);

    Building front();

    Building back();

    Building left();

    Building right();

    int pos();

    float rotdeg();

    Floor floor();

    bool interactable(Team t);

    float timeScale();

    bool consValid();

    void consume();

    float delta();

    float edelta();

    float efficiency();

    BlockStatus status();

    void sleep();

    void noSleep();

    byte version();

    bool canUnload();

    void itemTaken(Item i);

    void dropped();

    void handleString(object obj);

    void created();

    bool shouldConsume();

    bool productionValid();

    float getPowerProduction();

    int acceptStack(Item i1, int i2, Teamc t);

    int getMaximumAccepted(Item i);

    int removeStack(Item i1, int i2);

    void handleStack(Item i1, int i2, Teamc t);

    void getStackOffset(Item i, Vec2 v);

    void onProximityUpdate();

    bool acceptPayload(Building b, Payload p);

    void handlePayload(Building b, Payload p);

    bool movePayload(Payload p);

    bool dumpPayload(Payload p);

    void handleItem(Building b, Item i);

    bool acceptItem(Building b, Item i);

    bool acceptLiquid(Building b, Liquid l);

    void handleLiquid(Building b, Liquid l, float f);

    void dumpLiquid(Liquid l);

    void dumpLiquid(Liquid l, float f);

    bool canDumpLiquid(Building b, Liquid l);

    void transferLiquid(Building b, float f, Liquid l);

    float moveLiquidForward(bool b, Liquid l);

    float moveLiquid(Building b, Liquid l);

    Building getLiquidDestination(Building b, Liquid l);

    Payload getPayload();

    Payload takePayload();

    void offload(Item i);

    bool put(Item i);

    void produced(Item i);

    void produced(Item i1, int i2);

    bool dump();

    bool dump(Item i);

    void incrementDump(int i);

    bool canDump(Building b, Item i);

    bool moveForward(Item i);

    void onProximityRemoved();

    void onProximityAdded();

    void updatePowerGraph();

    void powerGraphRemoved();

    bool conductsTo(Building b);

    [Signature("(Larc/struct/Seq<Lmindustry/gen/Building;>;)Larc/struct/Seq<Lmindustry/gen/Building;>;")]
    Seq getPowerConnections(Seq s);

    float getProgressIncrease(float f);

    float getDisplayEfficiency();

    bool shouldActiveSound();

    bool shouldAmbientSound();

    void drawStatus();

    void drawCracks();

    void drawSelect();

    void drawDisabled();

    void draw();

    void drawTeamTop();

    void drawLight();

    void drawLiquidLight(Liquid l, float f);

    void drawTeam();

    void playerPlaced(object obj);

    void placed();

    [Signature("(Larc/struct/Seq<Lmindustry/gen/Building;>;)V")]
    void overwrote(Seq s);

    void onRemoved();

    void unitOn(Unit u);

    void unitRemoved(Unit u);

    void configured(Unit u, object obj);

    void tapped();

    void onDestroyed();

    string getDisplayName();

    TextureRegion getDisplayIcon();

    new void display(Table t);

    void displayConsumption(Table t);

    void displayBars(Table t);

    void buildConfiguration(Table t);

    void updateTableAlign(Table t);

    Graphics.Cursor getCursor();

    bool onConfigureTileTapped(Building b);

    bool shouldShowConfigure(Player p);

    bool shouldHideConfigure(Player p);

    void drawConfigure();

    bool checkSolid();

    float handleDamage(float f);

    bool collide(Bullet b);

    bool collision(Bullet b);

    bool canPickup();

    void pickedUp();

    void removeFromProximity();

    void updateProximity();

    void updateTile();

    float ambientVolume();

    object config();

    new bool isValid();

    new float hitSize();

    new void kill();

    new void damage(float f);

    new double sense(LAccess la);

    new object senseObject(LAccess la);

    new double sense(Content c);

    new void control(LAccess la, double d1, double d2, double d3, double d4);

    new void control(LAccess la, object obj, double d1, double d2, double d3);

    new void remove();

    new void killed();

    new void update();

    new void hitbox(Rect r);

    Tile tile();

    void tile(Tile t);

    Block block();

    void block(Block b);

    [Signature("()Larc/struct/Seq<Lmindustry/gen/Building;>;")]
    Seq proximity();

    [Signature("(Larc/struct/Seq<Lmindustry/gen/Building;>;)V")]
    void proximity(Seq s);

    bool updateFlow();

    void updateFlow(bool b);

    byte cdump();

    void cdump(byte b);

    int rotation();

    void rotation(int i);

    bool enabled();

    void enabled(bool b);

    float enabledControlTime();

    void enabledControlTime(float f);

    string lastAccessed();

    void lastAccessed(string str);

    PowerModule power();

    void power(PowerModule pm);

    ItemModule items();

    void items(ItemModule im);

    LiquidModule liquids();

    void liquids(LiquidModule lm);

    ConsumeModule cons();

    void cons(ConsumeModule cm);
  }
}
