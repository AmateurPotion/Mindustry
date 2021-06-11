// Decompiled with JetBrains decompiler
// Type: mindustry.content.Blocks
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.func;
using arc.graphics;
using IKVM.Attributes;
using java.lang;
using mindustry.ctype;
using mindustry.entities;
using mindustry.entities.bullet;
using mindustry.gen;
using mindustry.graphics;
using mindustry.type;
using mindustry.world;
using mindustry.world.blocks;
using mindustry.world.blocks.campaign;
using mindustry.world.blocks.defense;
using mindustry.world.blocks.defense.turrets;
using mindustry.world.blocks.distribution;
using mindustry.world.blocks.environment;
using mindustry.world.blocks.experimental;
using mindustry.world.blocks.legacy;
using mindustry.world.blocks.liquid;
using mindustry.world.blocks.logic;
using mindustry.world.blocks.power;
using mindustry.world.blocks.production;
using mindustry.world.blocks.sandbox;
using mindustry.world.blocks.storage;
using mindustry.world.blocks.units;
using mindustry.world.consumers;
using mindustry.world.draw;
using mindustry.world.meta;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.content
{
  public class Blocks : Object, ContentList
  {
    public static Block air;
    public static Block spawn;
    public static Block cliff;
    public static Block deepwater;
    public static Block water;
    public static Block taintedWater;
    public static Block tar;
    public static Block slag;
    public static Block stone;
    public static Block craters;
    public static Block charr;
    public static Block sand;
    public static Block darksand;
    public static Block dirt;
    public static Block mud;
    public static Block ice;
    public static Block snow;
    public static Block darksandTaintedWater;
    public static Block space;
    public static Block dacite;
    public static Block stoneWall;
    public static Block dirtWall;
    public static Block sporeWall;
    public static Block iceWall;
    public static Block daciteWall;
    public static Block sporePine;
    public static Block snowPine;
    public static Block pine;
    public static Block shrubs;
    public static Block whiteTree;
    public static Block whiteTreeDead;
    public static Block sporeCluster;
    public static Block iceSnow;
    public static Block sandWater;
    public static Block darksandWater;
    public static Block duneWall;
    public static Block sandWall;
    public static Block moss;
    public static Block sporeMoss;
    public static Block shale;
    public static Block shaleWall;
    public static Block shaleBoulder;
    public static Block sandBoulder;
    public static Block daciteBoulder;
    public static Block boulder;
    public static Block snowBoulder;
    public static Block basaltBoulder;
    public static Block grass;
    public static Block salt;
    public static Block metalFloor;
    public static Block metalFloorDamaged;
    public static Block metalFloor2;
    public static Block metalFloor3;
    public static Block metalFloor5;
    public static Block basalt;
    public static Block magmarock;
    public static Block hotrock;
    public static Block snowWall;
    public static Block saltWall;
    public static Block darkPanel1;
    public static Block darkPanel2;
    public static Block darkPanel3;
    public static Block darkPanel4;
    public static Block darkPanel5;
    public static Block darkPanel6;
    public static Block darkMetal;
    public static Block pebbles;
    public static Block tendrils;
    public static Block oreCopper;
    public static Block oreLead;
    public static Block oreScrap;
    public static Block oreCoal;
    public static Block oreTitanium;
    public static Block oreThorium;
    public static Block siliconSmelter;
    public static Block siliconCrucible;
    public static Block kiln;
    public static Block graphitePress;
    public static Block plastaniumCompressor;
    public static Block multiPress;
    public static Block phaseWeaver;
    public static Block surgeSmelter;
    public static Block pyratiteMixer;
    public static Block blastMixer;
    public static Block cryofluidMixer;
    public static Block melter;
    public static Block separator;
    public static Block disassembler;
    public static Block sporePress;
    public static Block pulverizer;
    public static Block incinerator;
    public static Block coalCentrifuge;
    public static Block powerSource;
    public static Block powerVoid;
    public static Block itemSource;
    public static Block itemVoid;
    public static Block liquidSource;
    public static Block liquidVoid;
    public static Block illuminator;
    public static Block copperWall;
    public static Block copperWallLarge;
    public static Block titaniumWall;
    public static Block titaniumWallLarge;
    public static Block plastaniumWall;
    public static Block plastaniumWallLarge;
    public static Block thoriumWall;
    public static Block thoriumWallLarge;
    public static Block door;
    public static Block doorLarge;
    public static Block phaseWall;
    public static Block phaseWallLarge;
    public static Block surgeWall;
    public static Block surgeWallLarge;
    public static Block mender;
    public static Block mendProjector;
    public static Block overdriveProjector;
    public static Block overdriveDome;
    public static Block forceProjector;
    public static Block shockMine;
    public static Block scrapWall;
    public static Block scrapWallLarge;
    public static Block scrapWallHuge;
    public static Block scrapWallGigantic;
    public static Block thruster;
    public static Block conveyor;
    public static Block titaniumConveyor;
    public static Block plastaniumConveyor;
    public static Block armoredConveyor;
    public static Block distributor;
    public static Block junction;
    public static Block itemBridge;
    public static Block phaseConveyor;
    public static Block sorter;
    public static Block invertedSorter;
    public static Block router;
    public static Block overflowGate;
    public static Block underflowGate;
    public static Block massDriver;
    public static Block payloadConveyor;
    public static Block payloadRouter;
    public static Block mechanicalPump;
    public static Block rotaryPump;
    public static Block thermalPump;
    public static Block conduit;
    public static Block pulseConduit;
    public static Block platedConduit;
    public static Block liquidRouter;
    public static Block liquidTank;
    public static Block liquidJunction;
    public static Block bridgeConduit;
    public static Block phaseConduit;
    public static Block combustionGenerator;
    public static Block thermalGenerator;
    public static Block steamGenerator;
    public static Block differentialGenerator;
    public static Block rtgGenerator;
    public static Block solarPanel;
    public static Block largeSolarPanel;
    public static Block thoriumReactor;
    public static Block impactReactor;
    public static Block battery;
    public static Block batteryLarge;
    public static Block powerNode;
    public static Block powerNodeLarge;
    public static Block surgeTower;
    public static Block diode;
    public static Block mechanicalDrill;
    public static Block pneumaticDrill;
    public static Block laserDrill;
    public static Block blastDrill;
    public static Block waterExtractor;
    public static Block oilExtractor;
    public static Block cultivator;
    public static Block coreShard;
    public static Block coreFoundation;
    public static Block coreNucleus;
    public static Block vault;
    public static Block container;
    public static Block unloader;
    public static Block duo;
    public static Block scatter;
    public static Block scorch;
    public static Block hail;
    public static Block arc;
    public static Block wave;
    public static Block lancer;
    public static Block swarmer;
    public static Block salvo;
    public static Block fuse;
    public static Block ripple;
    public static Block cyclone;
    public static Block foreshadow;
    public static Block spectre;
    public static Block meltdown;
    public static Block segment;
    public static Block parallax;
    public static Block tsunami;
    public static Block commandCenter;
    public static Block groundFactory;
    public static Block airFactory;
    public static Block navalFactory;
    public static Block additiveReconstructor;
    public static Block multiplicativeReconstructor;
    public static Block exponentialReconstructor;
    public static Block tetrativeReconstructor;
    public static Block repairPoint;
    public static Block resupplyPoint;
    public static Block message;
    public static Block switchBlock;
    public static Block microProcessor;
    public static Block logicProcessor;
    public static Block hyperProcessor;
    public static Block largeLogicDisplay;
    public static Block logicDisplay;
    public static Block memoryCell;
    public static Block memoryBank;
    public static Block launchPad;
    public static Block launchPadLarge;
    public static Block interplanetaryAccelerator;
    public static Block blockForge;
    public static Block blockLoader;
    public static Block blockUnloader;

    [LineNumberTable(33)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Blocks()
    {
    }

    [LineNumberTable(new byte[] {48, 143, 143, 240, 71, 103, 39, 198, 240, 77, 240, 75, 240, 77, 240, 71, 240, 70, 240, 70, 240, 75, 240, 80, 240, 71, 143, 240, 69, 208, 208, 240, 74, 240, 75, 240, 70, 240, 70, 143, 240, 78, 121, 121, 153, 143, 208, 240, 70, 208, 240, 70, 240, 70, 240, 69, 208, 208, 208, 208, 240, 69, 208, 240, 69, 240, 69, 143, 143, 208, 208, 208, 208, 143, 143, 208, 208, 240, 69, 208, 208, 208, 208, 240, 70, 240, 70, 208, 208, 208, 208, 208, 112, 112, 112, 112, 112, 144, 143, 143, 239, 69, 245, 70, 245, 70, 148, 245, 70, 245, 70, 245, 73, 240, 76, 240, 80, 240, 78, 240, 80, 240, 77, 240, 82, 240, 81, 240, 77, 240, 82, 240, 77, 240, 75, 240, 75, 240, 80, 240, 82, 240, 80, 240, 79, 240, 76, 240, 73, 130, 241, 69, 241, 70, 241, 69, 241, 70, 241, 72, 241, 73, 241, 69, 241, 70, 241, 71, 241, 72, 241, 70, 241, 71, 241, 69, 241, 72, 241, 70, 241, 71, 241, 71, 241, 70, 241, 69, 240, 77, 240, 76, 240, 71, 240, 75, 240, 78, 240, 77, 240, 72, 240, 71, 240, 71, 240, 71, 240, 72, 240, 71, 240, 72, 240, 69, 240, 70, 240, 69, 240, 69, 240, 69, 240, 70, 240, 73, 240, 69, 240, 72, 240, 69, 240, 73, 240, 73, 240, 69, 240, 71, 240, 71, 240, 69, 240, 71, 208, 240, 70, 240, 75, 240, 70, 240, 71, 240, 71, 208, 240, 69, 240, 70, 240, 73, 240, 74, 240, 76, 240, 78, 240, 71, 240, 69, 240, 70, 240, 77, 240, 81, 240, 73, 240, 73, 240, 77, 240, 84, 240, 76, 240, 77, 240, 85, 240, 76, 240, 76, 240, 76, 240, 70, 240, 70, 240, 73, 240, 86, 240, 87, 240, 81, 240, 81, 240, 84, 240, 97, 240, 85, 240, 79, 240, 82, 240, 89, 240, 77, 240, 87, 240, 100, 240, 94, 240, 85, 240, 107, 240, 90, 240, 98, 240, 70, 240, 75, 240, 74, 240, 74, 240, 83, 240, 83, 240, 85, 240, 85, 240, 71, 240, 78, 240, 70, 240, 69, 240, 69, 240, 69, 240, 69, 240, 69, 240, 75, 107, 107, 172, 236, 71, 240, 74, 240, 73, 240, 77, 208, 208, 240, 72, 240, 74, 240, 77, 240, 70, 240, 71, 240, 72, 240, 75, 240, 71, 240, 71, 240, 72})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void load()
    {
      Blocks.air = (Block) new AirBlock("air");
      Blocks.spawn = (Block) new SpawnBlock("spawn");
      Blocks.cliff = (Block) new Blocks.\u0031(this, "cliff");
      for (int size = 1; size <= 16; ++size)
      {
        ConstructBlock constructBlock = new ConstructBlock(size);
      }
      Blocks.deepwater = (Block) new Blocks.\u0032(this, "deepwater");
      Blocks.water = (Block) new Blocks.\u0033(this, "water");
      Blocks.taintedWater = (Block) new Blocks.\u0034(this, "tainted-water");
      Blocks.darksandTaintedWater = (Block) new Blocks.\u0035(this, "darksand-tainted-water");
      Blocks.sandWater = (Block) new Blocks.\u0036(this, "sand-water");
      Blocks.darksandWater = (Block) new Blocks.\u0037(this, "darksand-water");
      Blocks.tar = (Block) new Blocks.\u0038(this, "tar");
      Blocks.slag = (Block) new Blocks.\u0039(this, "slag");
      Blocks.space = (Block) new Blocks.\u00310(this, "space");
      Blocks.stone = (Block) new Floor("stone");
      Blocks.craters = (Block) new Blocks.\u00311(this, "craters");
      Blocks.charr = (Block) new Blocks.\u00312(this, "char");
      Blocks.basalt = (Block) new Blocks.\u00313(this, "basalt");
      Blocks.hotrock = (Block) new Blocks.\u00314(this, "hotrock");
      Blocks.magmarock = (Block) new Blocks.\u00315(this, "magmarock");
      Blocks.sand = (Block) new Blocks.\u00316(this, "sand");
      Blocks.darksand = (Block) new Blocks.\u00317(this, "darksand");
      Blocks.dirt = (Block) new Floor("dirt");
      Blocks.mud = (Block) new Blocks.\u00318(this, "mud");
      ((ShallowLiquid) Blocks.darksandTaintedWater).set(Blocks.taintedWater, Blocks.darksand);
      ((ShallowLiquid) Blocks.sandWater).set(Blocks.water, Blocks.sand);
      ((ShallowLiquid) Blocks.darksandWater).set(Blocks.water, Blocks.darksand);
      Blocks.dacite = (Block) new Floor("dacite");
      Blocks.grass = (Block) new Blocks.\u00319(this, "grass");
      Blocks.salt = (Block) new Blocks.\u00320(this, "salt");
      Blocks.snow = (Block) new Blocks.\u00321(this, "snow");
      Blocks.ice = (Block) new Blocks.\u00322(this, "ice");
      Blocks.iceSnow = (Block) new Blocks.\u00323(this, "ice-snow");
      Blocks.shale = (Block) new Blocks.\u00324(this, "shale");
      Blocks.stoneWall = (Block) new Blocks.\u00325(this, "stone-wall");
      Blocks.sporeWall = (Block) new Blocks.\u00326(this, "spore-wall");
      Blocks.dirtWall = (Block) new Blocks.\u00327(this, "dirt-wall");
      Blocks.daciteWall = (Block) new Blocks.\u00328(this, "dacite-wall");
      Blocks.iceWall = (Block) new Blocks.\u00329(this, "ice-wall");
      Blocks.snowWall = (Block) new Blocks.\u00330(this, "snow-wall");
      Blocks.duneWall = (Block) new Blocks.\u00331(this, "dune-wall");
      Blocks.sandWall = (Block) new Blocks.\u00332(this, "sand-wall");
      Blocks.saltWall = (Block) new StaticWall("salt-wall");
      Blocks.shrubs = (Block) new StaticWall("shrubs");
      Blocks.shaleWall = (Block) new Blocks.\u00333(this, "shale-wall");
      Blocks.sporePine = (Block) new Blocks.\u00334(this, "spore-pine");
      Blocks.snowPine = (Block) new Blocks.\u00335(this, "snow-pine");
      Blocks.pine = (Block) new Blocks.\u00336(this, "pine");
      Blocks.whiteTreeDead = (Block) new TreeBlock("white-tree-dead");
      Blocks.whiteTree = (Block) new TreeBlock("white-tree");
      Blocks.sporeCluster = (Block) new Blocks.\u00337(this, "spore-cluster");
      Blocks.boulder = (Block) new Blocks.\u00338(this, "boulder");
      Blocks.snowBoulder = (Block) new Blocks.\u00339(this, "snow-boulder");
      Blocks.shaleBoulder = (Block) new Blocks.\u00340(this, "shale-boulder");
      Blocks.sandBoulder = (Block) new Blocks.\u00341(this, "sand-boulder");
      Blocks.daciteBoulder = (Block) new Blocks.\u00342(this, "dacite-boulder");
      Blocks.basaltBoulder = (Block) new Blocks.\u00343(this, "basalt-boulder");
      Blocks.moss = (Block) new Blocks.\u00344(this, "moss");
      Blocks.sporeMoss = (Block) new Blocks.\u00345(this, "spore-moss");
      Blocks.metalFloor = (Block) new Blocks.\u00346(this, "metal-floor");
      Blocks.metalFloorDamaged = (Block) new Blocks.\u00347(this, "metal-floor-damaged");
      Blocks.metalFloor2 = (Block) new Blocks.\u00348(this, "metal-floor-2");
      Blocks.metalFloor3 = (Block) new Blocks.\u00349(this, "metal-floor-3");
      Blocks.metalFloor5 = (Block) new Blocks.\u00350(this, "metal-floor-5");
      Blocks.darkPanel1 = (Block) new Blocks.\u00351(this, "dark-panel-1");
      Blocks.darkPanel2 = (Block) new Blocks.\u00352(this, "dark-panel-2");
      Blocks.darkPanel3 = (Block) new Blocks.\u00353(this, "dark-panel-3");
      Blocks.darkPanel4 = (Block) new Blocks.\u00354(this, "dark-panel-4");
      Blocks.darkPanel5 = (Block) new Blocks.\u00355(this, "dark-panel-5");
      Blocks.darkPanel6 = (Block) new Blocks.\u00356(this, "dark-panel-6");
      Blocks.darkMetal = (Block) new StaticWall("dark-metal");
      Blocks.pebbles = (Block) new DoubleOverlayFloor("pebbles");
      Blocks.tendrils = (Block) new OverlayFloor("tendrils");
      Blocks.\u00357.__\u003Cclinit\u003E();
      Blocks.oreCopper = (Block) new Blocks.\u00357(this, Items.copper);
      Blocks.\u00358.__\u003Cclinit\u003E();
      Blocks.oreLead = (Block) new Blocks.\u00358(this, Items.lead);
      OreBlock.__\u003Cclinit\u003E();
      Blocks.oreScrap = (Block) new OreBlock(Items.scrap);
      Blocks.\u00359.__\u003Cclinit\u003E();
      Blocks.oreCoal = (Block) new Blocks.\u00359(this, Items.coal);
      Blocks.\u00360.__\u003Cclinit\u003E();
      Blocks.oreTitanium = (Block) new Blocks.\u00360(this, Items.titanium);
      Blocks.\u00361.__\u003Cclinit\u003E();
      Blocks.oreThorium = (Block) new Blocks.\u00361(this, Items.thorium);
      Blocks.graphitePress = (Block) new Blocks.\u00362(this, "graphite-press");
      Blocks.multiPress = (Block) new Blocks.\u00363(this, "multi-press");
      Blocks.siliconSmelter = (Block) new Blocks.\u00364(this, "silicon-smelter");
      Blocks.siliconCrucible = (Block) new Blocks.\u00365(this, "silicon-crucible");
      Blocks.kiln = (Block) new Blocks.\u00366(this, "kiln");
      Blocks.plastaniumCompressor = (Block) new Blocks.\u00367(this, "plastanium-compressor");
      Blocks.phaseWeaver = (Block) new Blocks.\u00368(this, "phase-weaver");
      Blocks.surgeSmelter = (Block) new Blocks.\u00369(this, "alloy-smelter");
      Blocks.cryofluidMixer = (Block) new Blocks.\u00370(this, "cryofluid-mixer");
      Blocks.pyratiteMixer = (Block) new Blocks.\u00371(this, "pyratite-mixer");
      Blocks.blastMixer = (Block) new Blocks.\u00372(this, "blast-mixer");
      Blocks.melter = (Block) new Blocks.\u00373(this, "melter");
      Blocks.separator = (Block) new Blocks.\u00374(this, "separator");
      Blocks.disassembler = (Block) new Blocks.\u00375(this, "disassembler");
      Blocks.sporePress = (Block) new Blocks.\u00376(this, "spore-press");
      Blocks.pulverizer = (Block) new Blocks.\u00377(this, "pulverizer");
      Blocks.coalCentrifuge = (Block) new Blocks.\u00378(this, "coal-centrifuge");
      Blocks.incinerator = (Block) new Blocks.\u00379(this, "incinerator");
      int num = 4;
      Blocks.copperWall = (Block) new Blocks.\u00380(this, "copper-wall", num);
      Blocks.copperWallLarge = (Block) new Blocks.\u00381(this, "copper-wall-large", num);
      Blocks.titaniumWall = (Block) new Blocks.\u00382(this, "titanium-wall", num);
      Blocks.titaniumWallLarge = (Block) new Blocks.\u00383(this, "titanium-wall-large", num);
      Blocks.plastaniumWall = (Block) new Blocks.\u00384(this, "plastanium-wall", num);
      Blocks.plastaniumWallLarge = (Block) new Blocks.\u00385(this, "plastanium-wall-large", num);
      Blocks.thoriumWall = (Block) new Blocks.\u00386(this, "thorium-wall", num);
      Blocks.thoriumWallLarge = (Block) new Blocks.\u00387(this, "thorium-wall-large", num);
      Blocks.phaseWall = (Block) new Blocks.\u00388(this, "phase-wall", num);
      Blocks.phaseWallLarge = (Block) new Blocks.\u00389(this, "phase-wall-large", num);
      Blocks.surgeWall = (Block) new Blocks.\u00390(this, "surge-wall", num);
      Blocks.surgeWallLarge = (Block) new Blocks.\u00391(this, "surge-wall-large", num);
      Blocks.door = (Block) new Blocks.\u00392(this, "door", num);
      Blocks.doorLarge = (Block) new Blocks.\u00393(this, "door-large", num);
      Blocks.scrapWall = (Block) new Blocks.\u00394(this, "scrap-wall", num);
      Blocks.scrapWallLarge = (Block) new Blocks.\u00395(this, "scrap-wall-large", num);
      Blocks.scrapWallHuge = (Block) new Blocks.\u00396(this, "scrap-wall-huge", num);
      Blocks.scrapWallGigantic = (Block) new Blocks.\u00397(this, "scrap-wall-gigantic", num);
      Blocks.thruster = (Block) new Blocks.\u00398(this, "thruster", num);
      Blocks.mender = (Block) new Blocks.\u00399(this, "mender");
      Blocks.mendProjector = (Block) new Blocks.\u003100(this, "mend-projector");
      Blocks.overdriveProjector = (Block) new Blocks.\u003101(this, "overdrive-projector");
      Blocks.overdriveDome = (Block) new Blocks.\u003102(this, "overdrive-dome");
      Blocks.forceProjector = (Block) new Blocks.\u003103(this, "force-projector");
      Blocks.shockMine = (Block) new Blocks.\u003104(this, "shock-mine");
      Blocks.conveyor = (Block) new Blocks.\u003105(this, "conveyor");
      Blocks.titaniumConveyor = (Block) new Blocks.\u003106(this, "titanium-conveyor");
      Blocks.plastaniumConveyor = (Block) new Blocks.\u003107(this, "plastanium-conveyor");
      Blocks.armoredConveyor = (Block) new Blocks.\u003108(this, "armored-conveyor");
      Blocks.junction = (Block) new Blocks.\u003109(this, "junction");
      Blocks.itemBridge = (Block) new Blocks.\u003110(this, "bridge-conveyor");
      Blocks.phaseConveyor = (Block) new Blocks.\u003111(this, "phase-conveyor");
      Blocks.sorter = (Block) new Blocks.\u003112(this, "sorter");
      Blocks.invertedSorter = (Block) new Blocks.\u003113(this, "inverted-sorter");
      Blocks.router = (Block) new Blocks.\u003114(this, "router");
      Blocks.distributor = (Block) new Blocks.\u003115(this, "distributor");
      Blocks.overflowGate = (Block) new Blocks.\u003116(this, "overflow-gate");
      Blocks.underflowGate = (Block) new Blocks.\u003117(this, "underflow-gate");
      Blocks.massDriver = (Block) new Blocks.\u003118(this, "mass-driver");
      Blocks.payloadConveyor = (Block) new Blocks.\u003119(this, "payload-conveyor");
      Blocks.payloadRouter = (Block) new Blocks.\u003120(this, "payload-router");
      Blocks.mechanicalPump = (Block) new Blocks.\u003121(this, "mechanical-pump");
      Blocks.rotaryPump = (Block) new Blocks.\u003122(this, "rotary-pump");
      Blocks.thermalPump = (Block) new Blocks.\u003123(this, "thermal-pump");
      Blocks.conduit = (Block) new Blocks.\u003124(this, "conduit");
      Blocks.pulseConduit = (Block) new Blocks.\u003125(this, "pulse-conduit");
      Blocks.platedConduit = (Block) new Blocks.\u003126(this, "plated-conduit");
      Blocks.liquidRouter = (Block) new Blocks.\u003127(this, "liquid-router");
      Blocks.liquidTank = (Block) new Blocks.\u003128(this, "liquid-tank");
      Blocks.liquidJunction = (Block) new Blocks.\u003129(this, "liquid-junction");
      Blocks.bridgeConduit = (Block) new Blocks.\u003130(this, "bridge-conduit");
      Blocks.phaseConduit = (Block) new Blocks.\u003131(this, "phase-conduit");
      Blocks.powerNode = (Block) new Blocks.\u003132(this, "power-node");
      Blocks.powerNodeLarge = (Block) new Blocks.\u003133(this, "power-node-large");
      Blocks.surgeTower = (Block) new Blocks.\u003134(this, "surge-tower");
      Blocks.diode = (Block) new Blocks.\u003135(this, "diode");
      Blocks.battery = (Block) new Blocks.\u003136(this, "battery");
      Blocks.batteryLarge = (Block) new Blocks.\u003137(this, "battery-large");
      Blocks.combustionGenerator = (Block) new Blocks.\u003138(this, "combustion-generator");
      Blocks.thermalGenerator = (Block) new Blocks.\u003139(this, "thermal-generator");
      Blocks.steamGenerator = (Block) new Blocks.\u003140(this, "steam-generator");
      Blocks.differentialGenerator = (Block) new Blocks.\u003141(this, "differential-generator");
      Blocks.rtgGenerator = (Block) new Blocks.\u003142(this, "rtg-generator");
      Blocks.solarPanel = (Block) new Blocks.\u003143(this, "solar-panel");
      Blocks.largeSolarPanel = (Block) new Blocks.\u003144(this, "solar-panel-large");
      Blocks.thoriumReactor = (Block) new Blocks.\u003145(this, "thorium-reactor");
      Blocks.impactReactor = (Block) new Blocks.\u003146(this, "impact-reactor");
      Blocks.mechanicalDrill = (Block) new Blocks.\u003147(this, "mechanical-drill");
      Blocks.pneumaticDrill = (Block) new Blocks.\u003148(this, "pneumatic-drill");
      Blocks.laserDrill = (Block) new Blocks.\u003149(this, "laser-drill");
      Blocks.blastDrill = (Block) new Blocks.\u003150(this, "blast-drill");
      Blocks.waterExtractor = (Block) new Blocks.\u003151(this, "water-extractor");
      Blocks.cultivator = (Block) new Blocks.\u003152(this, "cultivator");
      Blocks.oilExtractor = (Block) new Blocks.\u003153(this, "oil-extractor");
      Blocks.coreShard = (Block) new Blocks.\u003154(this, "core-shard");
      Blocks.coreFoundation = (Block) new Blocks.\u003155(this, "core-foundation");
      Blocks.coreNucleus = (Block) new Blocks.\u003156(this, "core-nucleus");
      Blocks.vault = (Block) new Blocks.\u003157(this, "vault");
      Blocks.container = (Block) new Blocks.\u003158(this, "container");
      Blocks.unloader = (Block) new Blocks.\u003159(this, "unloader");
      Blocks.duo = (Block) new Blocks.\u003160(this, "duo");
      Blocks.scatter = (Block) new Blocks.\u003161(this, "scatter");
      Blocks.scorch = (Block) new Blocks.\u003162(this, "scorch");
      Blocks.hail = (Block) new Blocks.\u003163(this, "hail");
      Blocks.wave = (Block) new Blocks.\u003164(this, "wave");
      Blocks.lancer = (Block) new Blocks.\u003165(this, "lancer");
      Blocks.arc = (Block) new Blocks.\u003166(this, "arc");
      Blocks.parallax = (Block) new Blocks.\u003167(this, "parallax");
      Blocks.swarmer = (Block) new Blocks.\u003168(this, "swarmer");
      Blocks.salvo = (Block) new Blocks.\u003169(this, "salvo");
      Blocks.segment = (Block) new Blocks.\u003170(this, "segment");
      Blocks.tsunami = (Block) new Blocks.\u003171(this, "tsunami");
      Blocks.fuse = (Block) new Blocks.\u003172(this, "fuse");
      Blocks.ripple = (Block) new Blocks.\u003173(this, "ripple");
      Blocks.cyclone = (Block) new Blocks.\u003174(this, "cyclone");
      Blocks.foreshadow = (Block) new Blocks.\u003175(this, "foreshadow");
      Blocks.spectre = (Block) new Blocks.\u003176(this, "spectre");
      Blocks.meltdown = (Block) new Blocks.\u003177(this, "meltdown");
      Blocks.commandCenter = (Block) new Blocks.\u003178(this, "command-center");
      Blocks.groundFactory = (Block) new Blocks.\u003179(this, "ground-factory");
      Blocks.airFactory = (Block) new Blocks.\u003180(this, "air-factory");
      Blocks.navalFactory = (Block) new Blocks.\u003181(this, "naval-factory");
      Blocks.additiveReconstructor = (Block) new Blocks.\u003182(this, "additive-reconstructor");
      Blocks.multiplicativeReconstructor = (Block) new Blocks.\u003183(this, "multiplicative-reconstructor");
      Blocks.exponentialReconstructor = (Block) new Blocks.\u003184(this, "exponential-reconstructor");
      Blocks.tetrativeReconstructor = (Block) new Blocks.\u003185(this, "tetrative-reconstructor");
      Blocks.repairPoint = (Block) new Blocks.\u003186(this, "repair-point");
      Blocks.resupplyPoint = (Block) new Blocks.\u003187(this, "resupply-point");
      Blocks.powerSource = (Block) new Blocks.\u003188(this, "power-source");
      Blocks.powerVoid = (Block) new Blocks.\u003189(this, "power-void");
      Blocks.itemSource = (Block) new Blocks.\u003190(this, "item-source");
      Blocks.itemVoid = (Block) new Blocks.\u003191(this, "item-void");
      Blocks.liquidSource = (Block) new Blocks.\u003192(this, "liquid-source");
      Blocks.liquidVoid = (Block) new Blocks.\u003193(this, "liquid-void");
      Blocks.illuminator = (Block) new Blocks.\u003194(this, "illuminator");
      LegacyMechPad legacyMechPad = new LegacyMechPad("legacy-mech-pad");
      LegacyUnitFactory legacyUnitFactory = new LegacyUnitFactory("legacy-unit-factory");
      Blocks.\u003195 obj1 = new Blocks.\u003195(this, "legacy-unit-factory-air");
      Blocks.\u003196 obj2 = new Blocks.\u003196(this, "legacy-unit-factory-ground");
      Blocks.launchPad = (Block) new Blocks.\u003197(this, "launch-pad");
      Blocks.launchPadLarge = (Block) new Blocks.\u003198(this, "launch-pad-large");
      Blocks.interplanetaryAccelerator = (Block) new Blocks.\u003199(this, "interplanetary-accelerator");
      Blocks.message = (Block) new Blocks.\u003200(this, "message");
      Blocks.switchBlock = (Block) new Blocks.\u003201(this, "switch");
      Blocks.microProcessor = (Block) new Blocks.\u003202(this, "micro-processor");
      Blocks.logicProcessor = (Block) new Blocks.\u003203(this, "logic-processor");
      Blocks.hyperProcessor = (Block) new Blocks.\u003204(this, "hyper-processor");
      Blocks.memoryCell = (Block) new Blocks.\u003205(this, "memory-cell");
      Blocks.memoryBank = (Block) new Blocks.\u003206(this, "memory-bank");
      Blocks.logicDisplay = (Block) new Blocks.\u003207(this, "logic-display");
      Blocks.largeLogicDisplay = (Block) new Blocks.\u003208(this, "large-logic-display");
      Blocks.blockForge = (Block) new Blocks.\u003209(this, "block-forge");
      Blocks.blockLoader = (Block) new Blocks.\u003210(this, "block-loader");
      Blocks.blockUnloader = (Block) new Blocks.\u003211(this, "block-unloader");
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u0031 : Cliff
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {52, 112, 103, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0031([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u0031 obj = this;
        this.inEditor = false;
        this.saveData = true;
      }

      [HideFromJava]
      static \u0031() => Cliff.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00310 : Floor
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {160, 82, 112, 107, 103, 103, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00310([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u00310 obj = this;
        this.cacheLayer = CacheLayer.__\u003C\u003Espace;
        this.placeableOn = false;
        this.solid = true;
        this.variants = 0;
      }

      [HideFromJava]
      static \u00310() => Floor.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u003100 : MendProjector
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {162, 244, 112, 127, 45, 113, 103, 107, 107, 107, 107, 118, 118})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u003100([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u003100 obj = this;
        this.requirements(Category.__\u003C\u003Eeffect, ItemStack.with((object) Items.lead, (object) Integer.valueOf(100), (object) Items.titanium, (object) Integer.valueOf(25), (object) Items.silicon, (object) Integer.valueOf(40)));
        this.__\u003C\u003Econsumes.power(1.5f);
        this.size = 2;
        this.reload = 250f;
        this.range = 85f;
        this.healPercent = 11f;
        this.phaseBoost = 15f;
        this.health = 80 * this.size * this.size;
        this.__\u003C\u003Econsumes.item(Items.phaseFabric).boost();
      }

      [HideFromJava]
      static \u003100() => MendProjector.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u003101 : OverdriveProjector
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {163, 0, 112, 127, 63, 113, 103, 118})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u003101([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u003101 obj = this;
        this.requirements(Category.__\u003C\u003Eeffect, ItemStack.with((object) Items.lead, (object) Integer.valueOf(100), (object) Items.titanium, (object) Integer.valueOf(75), (object) Items.silicon, (object) Integer.valueOf(75), (object) Items.plastanium, (object) Integer.valueOf(30)));
        this.__\u003C\u003Econsumes.power(3.5f);
        this.size = 2;
        this.__\u003C\u003Econsumes.item(Items.phaseFabric).boost();
      }

      [HideFromJava]
      static \u003101() => OverdriveProjector.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u003102 : OverdriveProjector
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {163, 7, 112, 127, 92, 113, 103, 107, 107, 107, 103, 127, 26})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u003102([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u003102 obj = this;
        this.requirements(Category.__\u003C\u003Eeffect, ItemStack.with((object) Items.lead, (object) Integer.valueOf(200), (object) Items.titanium, (object) Integer.valueOf(130), (object) Items.silicon, (object) Integer.valueOf(130), (object) Items.plastanium, (object) Integer.valueOf(80), (object) Items.surgeAlloy, (object) Integer.valueOf(120)));
        this.__\u003C\u003Econsumes.power(10f);
        this.size = 3;
        this.range = 200f;
        this.speedBoost = 2.5f;
        this.useTime = 300f;
        this.hasBoost = false;
        this.__\u003C\u003Econsumes.items(ItemStack.with((object) Items.phaseFabric, (object) Integer.valueOf(1), (object) Items.silicon, (object) Integer.valueOf(1)));
      }

      [HideFromJava]
      static \u003102() => OverdriveProjector.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u003103 : ForceProjector
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {163, 18, 112, 127, 45, 103, 107, 107, 107, 107, 107, 139, 118, 113})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u003103([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u003103 obj = this;
        this.requirements(Category.__\u003C\u003Eeffect, ItemStack.with((object) Items.lead, (object) Integer.valueOf(100), (object) Items.titanium, (object) Integer.valueOf(75), (object) Items.silicon, (object) Integer.valueOf(125)));
        this.size = 3;
        this.phaseRadiusBoost = 80f;
        this.radius = 101.7f;
        this.shieldHealth = 750f;
        this.cooldownNormal = 1.5f;
        this.cooldownLiquid = 1.2f;
        this.cooldownBrokenBase = 0.35f;
        this.__\u003C\u003Econsumes.item(Items.phaseFabric).boost();
        this.__\u003C\u003Econsumes.power(4f);
      }

      [HideFromJava]
      static \u003103() => ForceProjector.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u003104 : ShockMine
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {163, 32, 112, 127, 27, 103, 104, 107, 107, 104, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u003104([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u003104 obj = this;
        this.requirements(Category.__\u003C\u003Eeffect, ItemStack.with((object) Items.lead, (object) Integer.valueOf(25), (object) Items.silicon, (object) Integer.valueOf(12)));
        this.hasShadow = false;
        this.health = 50;
        this.damage = 25f;
        this.tileDamage = 7f;
        this.length = 10;
        this.tendrils = 4;
      }

      [HideFromJava]
      static \u003104() => ShockMine.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u003105 : Conveyor
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {163, 45, 112, 127, 9, 104, 107, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u003105([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u003105 obj = this;
        this.requirements(Category.__\u003C\u003Edistribution, ItemStack.with((object) Items.copper, (object) Integer.valueOf(1)), true);
        this.health = 45;
        this.speed = 0.03f;
        this.displayedSpeed = 4.2f;
        this.buildCostMultiplier = 2f;
      }

      [HideFromJava]
      static \u003105() => Conveyor.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u003106 : Conveyor
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {163, 53, 112, 127, 42, 104, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u003106([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u003106 obj = this;
        this.requirements(Category.__\u003C\u003Edistribution, ItemStack.with((object) Items.copper, (object) Integer.valueOf(1), (object) Items.lead, (object) Integer.valueOf(1), (object) Items.titanium, (object) Integer.valueOf(1)));
        this.health = 65;
        this.speed = 0.08f;
        this.displayedSpeed = 11f;
      }

      [HideFromJava]
      static \u003106() => Conveyor.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u003107 : StackConveyor
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {163, 60, 112, 127, 42, 104, 107, 104})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u003107([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u003107 obj = this;
        this.requirements(Category.__\u003C\u003Edistribution, ItemStack.with((object) Items.plastanium, (object) Integer.valueOf(1), (object) Items.silicon, (object) Integer.valueOf(1), (object) Items.graphite, (object) Integer.valueOf(1)));
        this.health = 75;
        this.speed = 0.06666667f;
        this.itemCapacity = 10;
      }

      [HideFromJava]
      static \u003107() => StackConveyor.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u003108 : ArmoredConveyor
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {163, 67, 112, 127, 42, 107, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u003108([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u003108 obj = this;
        this.requirements(Category.__\u003C\u003Edistribution, ItemStack.with((object) Items.plastanium, (object) Integer.valueOf(1), (object) Items.thorium, (object) Integer.valueOf(1), (object) Items.metaglass, (object) Integer.valueOf(1)));
        this.health = 180;
        this.speed = 0.08f;
        this.displayedSpeed = 11f;
      }

      [HideFromJava]
      static \u003108() => ArmoredConveyor.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u003109 : Junction
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {163, 74, 112, 127, 9, 107, 103, 104, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u003109([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u003109 obj = this;
        this.requirements(Category.__\u003C\u003Edistribution, ItemStack.with((object) Items.copper, (object) Integer.valueOf(2)), true);
        this.speed = 26f;
        this.capacity = 6;
        this.health = 30;
        this.buildCostMultiplier = 6f;
      }

      [HideFromJava]
      static \u003109() => Junction.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00311 : Floor
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {160, 91, 112, 103, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00311([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u00311 obj = this;
        this.variants = 3;
        this.blendGroup = Blocks.stone;
      }

      [HideFromJava]
      static \u00311() => Floor.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u003110 : BufferedItemBridge
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {163, 82, 112, 127, 25, 103, 107, 104})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u003110([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u003110 obj = this;
        this.requirements(Category.__\u003C\u003Edistribution, ItemStack.with((object) Items.lead, (object) Integer.valueOf(6), (object) Items.copper, (object) Integer.valueOf(6)));
        this.range = 4;
        this.speed = 74f;
        this.bufferCapacity = 14;
      }

      [HideFromJava]
      static \u003110() => BufferedItemBridge.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u003111 : ItemBridge
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {163, 89, 112, 127, 61, 104, 103, 103, 113})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u003111([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u003111 obj = this;
        this.requirements(Category.__\u003C\u003Edistribution, ItemStack.with((object) Items.phaseFabric, (object) Integer.valueOf(5), (object) Items.silicon, (object) Integer.valueOf(7), (object) Items.lead, (object) Integer.valueOf(10), (object) Items.graphite, (object) Integer.valueOf(10)));
        this.range = 12;
        this.canOverdrive = false;
        this.hasPower = true;
        this.__\u003C\u003Econsumes.power(0.3f);
      }

      [HideFromJava]
      static \u003111() => ItemBridge.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u003112 : Sorter
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {163, 97, 112, 127, 25, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u003112([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u003112 obj = this;
        this.requirements(Category.__\u003C\u003Edistribution, ItemStack.with((object) Items.lead, (object) Integer.valueOf(2), (object) Items.copper, (object) Integer.valueOf(2)));
        this.buildCostMultiplier = 3f;
      }

      [HideFromJava]
      static \u003112() => Sorter.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u003113 : Sorter
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {163, 102, 112, 127, 25, 107, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u003113([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u003113 obj = this;
        this.requirements(Category.__\u003C\u003Edistribution, ItemStack.with((object) Items.lead, (object) Integer.valueOf(2), (object) Items.copper, (object) Integer.valueOf(2)));
        this.buildCostMultiplier = 3f;
        this.invert = true;
      }

      [HideFromJava]
      static \u003113() => Sorter.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u003114 : Router
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {163, 108, 112, 127, 8, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u003114([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u003114 obj = this;
        this.requirements(Category.__\u003C\u003Edistribution, ItemStack.with((object) Items.copper, (object) Integer.valueOf(3)));
        this.buildCostMultiplier = 4f;
      }

      [HideFromJava]
      static \u003114() => Router.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u003115 : Router
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {163, 113, 112, 127, 25, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u003115([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u003115 obj = this;
        this.requirements(Category.__\u003C\u003Edistribution, ItemStack.with((object) Items.lead, (object) Integer.valueOf(4), (object) Items.copper, (object) Integer.valueOf(4)));
        this.size = 2;
      }

      [HideFromJava]
      static \u003115() => Router.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u003116 : OverflowGate
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {163, 118, 112, 127, 25, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u003116([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u003116 obj = this;
        this.requirements(Category.__\u003C\u003Edistribution, ItemStack.with((object) Items.lead, (object) Integer.valueOf(2), (object) Items.copper, (object) Integer.valueOf(4)));
        this.buildCostMultiplier = 3f;
      }

      [HideFromJava]
      static \u003116() => OverflowGate.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u003117 : OverflowGate
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {163, 123, 112, 127, 25, 107, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u003117([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u003117 obj = this;
        this.requirements(Category.__\u003C\u003Edistribution, ItemStack.with((object) Items.lead, (object) Integer.valueOf(2), (object) Items.copper, (object) Integer.valueOf(4)));
        this.buildCostMultiplier = 3f;
        this.invert = true;
      }

      [HideFromJava]
      static \u003117() => OverflowGate.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u003118 : MassDriver
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {163, 129, 112, 127, 63, 103, 104, 107, 107, 113})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u003118([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u003118 obj = this;
        this.requirements(Category.__\u003C\u003Edistribution, ItemStack.with((object) Items.titanium, (object) Integer.valueOf(125), (object) Items.silicon, (object) Integer.valueOf(75), (object) Items.lead, (object) Integer.valueOf(125), (object) Items.thorium, (object) Integer.valueOf(50)));
        this.size = 3;
        this.itemCapacity = 120;
        this.reloadTime = 200f;
        this.range = 440f;
        this.__\u003C\u003Econsumes.power(1.75f);
      }

      [HideFromJava]
      static \u003118() => MassDriver.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u003119 : PayloadConveyor
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {163, 138, 112, 127, 27, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u003119([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u003119 obj = this;
        this.requirements(Category.__\u003C\u003Edistribution, ItemStack.with((object) Items.graphite, (object) Integer.valueOf(10), (object) Items.copper, (object) Integer.valueOf(20)));
        this.canOverdrive = false;
      }

      [HideFromJava]
      static \u003119() => PayloadConveyor.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00312 : Floor
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {160, 96, 112, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00312([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u00312 obj = this;
        this.blendGroup = Blocks.stone;
      }

      [HideFromJava]
      static \u00312() => Floor.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u003120 : PayloadRouter
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {163, 143, 112, 127, 27, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u003120([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u003120 obj = this;
        this.requirements(Category.__\u003C\u003Edistribution, ItemStack.with((object) Items.graphite, (object) Integer.valueOf(15), (object) Items.copper, (object) Integer.valueOf(20)));
        this.canOverdrive = false;
      }

      [HideFromJava]
      static \u003120() => PayloadRouter.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u003121 : Pump
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {163, 151, 112, 127, 27, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u003121([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u003121 obj = this;
        this.requirements(Category.__\u003C\u003Eliquid, ItemStack.with((object) Items.copper, (object) Integer.valueOf(15), (object) Items.metaglass, (object) Integer.valueOf(10)));
        this.pumpAmount = 0.11f;
      }

      [HideFromJava]
      static \u003121() => Pump.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u003122 : Pump
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {163, 156, 112, 127, 63, 107, 113, 107, 103, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u003122([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u003122 obj = this;
        this.requirements(Category.__\u003C\u003Eliquid, ItemStack.with((object) Items.copper, (object) Integer.valueOf(70), (object) Items.metaglass, (object) Integer.valueOf(50), (object) Items.silicon, (object) Integer.valueOf(20), (object) Items.titanium, (object) Integer.valueOf(35)));
        this.pumpAmount = 0.2f;
        this.__\u003C\u003Econsumes.power(0.3f);
        this.liquidCapacity = 30f;
        this.hasPower = true;
        this.size = 2;
      }

      [HideFromJava]
      static \u003122() => Pump.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u003123 : Pump
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {163, 165, 112, 127, 83, 107, 113, 107, 103, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u003123([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u003123 obj = this;
        this.requirements(Category.__\u003C\u003Eliquid, ItemStack.with((object) Items.copper, (object) Integer.valueOf(80), (object) Items.metaglass, (object) Integer.valueOf(90), (object) Items.silicon, (object) Integer.valueOf(30), (object) Items.titanium, (object) Integer.valueOf(40), (object) Items.thorium, (object) Integer.valueOf(35)));
        this.pumpAmount = 0.22f;
        this.__\u003C\u003Econsumes.power(1.3f);
        this.liquidCapacity = 40f;
        this.hasPower = true;
        this.size = 3;
      }

      [HideFromJava]
      static \u003123() => Pump.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u003124 : Conduit
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {163, 174, 112, 127, 8, 104})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u003124([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u003124 obj = this;
        this.requirements(Category.__\u003C\u003Eliquid, ItemStack.with((object) Items.metaglass, (object) Integer.valueOf(1)));
        this.health = 45;
      }

      [HideFromJava]
      static \u003124() => Conduit.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u003125 : Conduit
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {163, 179, 112, 127, 25, 107, 107, 104})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u003125([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u003125 obj = this;
        this.requirements(Category.__\u003C\u003Eliquid, ItemStack.with((object) Items.titanium, (object) Integer.valueOf(2), (object) Items.metaglass, (object) Integer.valueOf(1)));
        this.liquidCapacity = 16f;
        this.liquidPressure = 1.025f;
        this.health = 90;
      }

      [HideFromJava]
      static \u003125() => Conduit.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u003126 : ArmoredConduit
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {163, 186, 112, 127, 42, 107, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u003126([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u003126 obj = this;
        this.requirements(Category.__\u003C\u003Eliquid, ItemStack.with((object) Items.thorium, (object) Integer.valueOf(2), (object) Items.metaglass, (object) Integer.valueOf(1), (object) Items.plastanium, (object) Integer.valueOf(1)));
        this.liquidCapacity = 16f;
        this.liquidPressure = 1.025f;
        this.health = 220;
      }

      [HideFromJava]
      static \u003126() => ArmoredConduit.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u003127 : LiquidRouter
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {163, 193, 112, 127, 25, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u003127([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u003127 obj = this;
        this.requirements(Category.__\u003C\u003Eliquid, ItemStack.with((object) Items.graphite, (object) Integer.valueOf(4), (object) Items.metaglass, (object) Integer.valueOf(2)));
        this.liquidCapacity = 20f;
      }

      [HideFromJava]
      static \u003127() => LiquidRouter.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u003128 : LiquidRouter
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {163, 198, 112, 127, 27, 103, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u003128([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u003128 obj = this;
        this.requirements(Category.__\u003C\u003Eliquid, ItemStack.with((object) Items.titanium, (object) Integer.valueOf(25), (object) Items.metaglass, (object) Integer.valueOf(25)));
        this.size = 3;
        this.liquidCapacity = 1500f;
        this.health = 500;
      }

      [HideFromJava]
      static \u003128() => LiquidRouter.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u003129 : LiquidJunction
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {163, 205, 112, 127, 25})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u003129([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u003129 obj = this;
        this.requirements(Category.__\u003C\u003Eliquid, ItemStack.with((object) Items.graphite, (object) Integer.valueOf(2), (object) Items.metaglass, (object) Integer.valueOf(2)));
      }

      [HideFromJava]
      static \u003129() => LiquidJunction.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00313 : Floor
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {160, 100, 112, 117})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00313([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u00313 obj = this;
        this.attributes.set(Attribute.__\u003C\u003Ewater, -0.25f);
      }

      [HideFromJava]
      static \u00313() => Floor.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u003130 : LiquidExtendingBridge
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {163, 209, 112, 127, 25, 103, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u003130([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u003130 obj = this;
        this.requirements(Category.__\u003C\u003Eliquid, ItemStack.with((object) Items.graphite, (object) Integer.valueOf(4), (object) Items.metaglass, (object) Integer.valueOf(8)));
        this.range = 4;
        this.hasPower = false;
      }

      [HideFromJava]
      static \u003130() => LiquidExtendingBridge.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u003131 : LiquidBridge
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {163, 215, 112, 127, 61, 104, 103, 103, 113})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u003131([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u003131 obj = this;
        this.requirements(Category.__\u003C\u003Eliquid, ItemStack.with((object) Items.phaseFabric, (object) Integer.valueOf(5), (object) Items.silicon, (object) Integer.valueOf(7), (object) Items.metaglass, (object) Integer.valueOf(20), (object) Items.titanium, (object) Integer.valueOf(10)));
        this.range = 12;
        this.hasPower = true;
        this.canOverdrive = false;
        this.__\u003C\u003Econsumes.power(0.3f);
      }

      [HideFromJava]
      static \u003131() => LiquidBridge.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u003132 : PowerNode
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {163, 226, 112, 127, 25, 104, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u003132([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u003132 obj = this;
        this.requirements(Category.__\u003C\u003Epower, ItemStack.with((object) Items.copper, (object) Integer.valueOf(1), (object) Items.lead, (object) Integer.valueOf(3)));
        this.maxNodes = 10;
        this.laserRange = 6f;
      }

      [HideFromJava]
      static \u003132() => PowerNode.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u003133 : PowerNode
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {163, 232, 112, 127, 43, 103, 104, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u003133([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u003133 obj = this;
        this.requirements(Category.__\u003C\u003Epower, ItemStack.with((object) Items.titanium, (object) Integer.valueOf(5), (object) Items.lead, (object) Integer.valueOf(10), (object) Items.silicon, (object) Integer.valueOf(3)));
        this.size = 2;
        this.maxNodes = 15;
        this.laserRange = 9.5f;
      }

      [HideFromJava]
      static \u003133() => PowerNode.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u003134 : PowerNode
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {163, 239, 112, 127, 62, 103, 103, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u003134([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u003134 obj = this;
        this.requirements(Category.__\u003C\u003Epower, ItemStack.with((object) Items.titanium, (object) Integer.valueOf(7), (object) Items.lead, (object) Integer.valueOf(10), (object) Items.silicon, (object) Integer.valueOf(15), (object) Items.surgeAlloy, (object) Integer.valueOf(15)));
        this.size = 2;
        this.maxNodes = 2;
        this.laserRange = 40f;
      }

      [HideFromJava]
      static \u003134() => PowerNode.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u003135 : PowerDiode
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {163, 246, 112, 127, 44})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u003135([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u003135 obj = this;
        this.requirements(Category.__\u003C\u003Epower, ItemStack.with((object) Items.silicon, (object) Integer.valueOf(10), (object) Items.plastanium, (object) Integer.valueOf(5), (object) Items.metaglass, (object) Integer.valueOf(10)));
      }

      [HideFromJava]
      static \u003135() => PowerDiode.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u003136 : Battery
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {163, 250, 112, 127, 26, 113})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u003136([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u003136 obj = this;
        this.requirements(Category.__\u003C\u003Epower, ItemStack.with((object) Items.copper, (object) Integer.valueOf(5), (object) Items.lead, (object) Integer.valueOf(20)));
        this.__\u003C\u003Econsumes.powerBuffered(4000f);
      }

      [HideFromJava]
      static \u003136() => Battery.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u003137 : Battery
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {163, 255, 112, 127, 45, 103, 113})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u003137([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u003137 obj = this;
        this.requirements(Category.__\u003C\u003Epower, ItemStack.with((object) Items.titanium, (object) Integer.valueOf(20), (object) Items.lead, (object) Integer.valueOf(40), (object) Items.silicon, (object) Integer.valueOf(20)));
        this.size = 3;
        this.__\u003C\u003Econsumes.powerBuffered(50000f);
      }

      [HideFromJava]
      static \u003137() => Battery.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u003138 : BurnerGenerator
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {164, 5, 112, 127, 27, 107, 139, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u003138([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u003138 obj = this;
        this.requirements(Category.__\u003C\u003Epower, ItemStack.with((object) Items.copper, (object) Integer.valueOf(25), (object) Items.lead, (object) Integer.valueOf(15)));
        this.powerProduction = 1f;
        this.itemDuration = 120f;
        this.ambientSound = Sounds.smelter;
        this.ambientSoundVolume = 0.03f;
      }

      [HideFromJava]
      static \u003138() => BurnerGenerator.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u003139 : ThermalGenerator
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {164, 14, 112, 127, 83, 107, 107, 103, 103, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u003139([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u003139 obj = this;
        this.requirements(Category.__\u003C\u003Epower, ItemStack.with((object) Items.copper, (object) Integer.valueOf(40), (object) Items.graphite, (object) Integer.valueOf(35), (object) Items.lead, (object) Integer.valueOf(50), (object) Items.silicon, (object) Integer.valueOf(35), (object) Items.metaglass, (object) Integer.valueOf(40)));
        this.powerProduction = 1.8f;
        this.generateEffect = Fx.__\u003C\u003Eredgeneratespark;
        this.size = 2;
        this.floating = true;
        this.ambientSound = Sounds.hum;
        this.ambientSoundVolume = 0.06f;
      }

      [HideFromJava]
      static \u003139() => ThermalGenerator.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00314 : Floor
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {160, 104, 112, 117, 117, 139, 103, 107, 122})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00314([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u00314 obj = this;
        this.attributes.set(Attribute.__\u003C\u003Eheat, 0.5f);
        this.attributes.set(Attribute.__\u003C\u003Ewater, -0.5f);
        this.blendGroup = Blocks.basalt;
        this.emitLight = true;
        this.lightRadius = 30f;
        this.lightColor = Color.__\u003C\u003Eorange.cpy().a(0.15f);
      }

      [HideFromJava]
      static \u00314() => Floor.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u003140 : BurnerGenerator
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {164, 24, 112, 127, 63, 107, 107, 118, 103, 135, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u003140([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u003140 obj = this;
        this.requirements(Category.__\u003C\u003Epower, ItemStack.with((object) Items.copper, (object) Integer.valueOf(35), (object) Items.graphite, (object) Integer.valueOf(25), (object) Items.lead, (object) Integer.valueOf(40), (object) Items.silicon, (object) Integer.valueOf(30)));
        this.powerProduction = 5.5f;
        this.itemDuration = 90f;
        this.__\u003C\u003Econsumes.liquid(Liquids.water, 0.1f);
        this.hasLiquids = true;
        this.size = 2;
        this.ambientSound = Sounds.smelter;
        this.ambientSoundVolume = 0.06f;
      }

      [HideFromJava]
      static \u003140() => BurnerGenerator.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u003141 : SingleTypeGenerator
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {164, 36, 112, 127, 83, 107, 107, 103, 103, 103, 107, 139, 120, 118})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u003141([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u003141 obj = this;
        this.requirements(Category.__\u003C\u003Epower, ItemStack.with((object) Items.copper, (object) Integer.valueOf(70), (object) Items.titanium, (object) Integer.valueOf(50), (object) Items.lead, (object) Integer.valueOf(100), (object) Items.silicon, (object) Integer.valueOf(65), (object) Items.metaglass, (object) Integer.valueOf(50)));
        this.powerProduction = 18f;
        this.itemDuration = 220f;
        this.hasLiquids = true;
        this.hasItems = true;
        this.size = 3;
        this.ambientSound = Sounds.steam;
        this.ambientSoundVolume = 0.03f;
        this.__\u003C\u003Econsumes.item(Items.pyratite).optional(true, false);
        this.__\u003C\u003Econsumes.liquid(Liquids.cryofluid, 0.1f);
      }

      [HideFromJava]
      static \u003141() => SingleTypeGenerator.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u003142 : DecayGenerator
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {164, 50, 112, 127, 83, 103, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u003142([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u003142 obj = this;
        this.requirements(Category.__\u003C\u003Epower, ItemStack.with((object) Items.lead, (object) Integer.valueOf(100), (object) Items.silicon, (object) Integer.valueOf(75), (object) Items.phaseFabric, (object) Integer.valueOf(25), (object) Items.plastanium, (object) Integer.valueOf(75), (object) Items.thorium, (object) Integer.valueOf(50)));
        this.size = 2;
        this.powerProduction = 4.5f;
        this.itemDuration = 840f;
      }

      [HideFromJava]
      static \u003142() => DecayGenerator.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u003143 : SolarGenerator
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {164, 57, 112, 127, 27, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u003143([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u003143 obj = this;
        this.requirements(Category.__\u003C\u003Epower, ItemStack.with((object) Items.lead, (object) Integer.valueOf(10), (object) Items.silicon, (object) Integer.valueOf(15)));
        this.powerProduction = 0.1f;
      }

      [HideFromJava]
      static \u003143() => SolarGenerator.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u003144 : SolarGenerator
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {164, 62, 112, 127, 45, 103, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u003144([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u003144 obj = this;
        this.requirements(Category.__\u003C\u003Epower, ItemStack.with((object) Items.lead, (object) Integer.valueOf(80), (object) Items.silicon, (object) Integer.valueOf(110), (object) Items.phaseFabric, (object) Integer.valueOf(15)));
        this.size = 3;
        this.powerProduction = 1.3f;
      }

      [HideFromJava]
      static \u003144() => SolarGenerator.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u003145 : NuclearReactor
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {164, 68, 112, 127, 95, 107, 107, 103, 107, 107, 107, 113, 107, 127, 6})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u003145([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u003145 obj = this;
        this.requirements(Category.__\u003C\u003Epower, ItemStack.with((object) Items.lead, (object) Integer.valueOf(300), (object) Items.silicon, (object) Integer.valueOf(200), (object) Items.graphite, (object) Integer.valueOf(150), (object) Items.thorium, (object) Integer.valueOf(150), (object) Items.metaglass, (object) Integer.valueOf(50)));
        this.ambientSound = Sounds.hum;
        this.ambientSoundVolume = 0.24f;
        this.size = 3;
        this.health = 700;
        this.itemDuration = 360f;
        this.powerProduction = 15f;
        this.__\u003C\u003Econsumes.item(Items.thorium);
        this.heating = 0.02f;
        this.__\u003C\u003Econsumes.liquid(Liquids.cryofluid, this.heating / this.coolantPower).update(false);
      }

      [HideFromJava]
      static \u003145() => NuclearReactor.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u003146 : ImpactReactor
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {164, 81, 112, 127, 118, 103, 107, 107, 107, 107, 139, 113, 113, 118})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u003146([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u003146 obj = this;
        this.requirements(Category.__\u003C\u003Epower, ItemStack.with((object) Items.lead, (object) Integer.valueOf(500), (object) Items.silicon, (object) Integer.valueOf(300), (object) Items.graphite, (object) Integer.valueOf(400), (object) Items.thorium, (object) Integer.valueOf(100), (object) Items.surgeAlloy, (object) Integer.valueOf(250), (object) Items.metaglass, (object) Integer.valueOf(250)));
        this.size = 4;
        this.health = 900;
        this.powerProduction = 130f;
        this.itemDuration = 140f;
        this.ambientSound = Sounds.pulse;
        this.ambientSoundVolume = 0.07f;
        this.__\u003C\u003Econsumes.power(25f);
        this.__\u003C\u003Econsumes.item(Items.blastCompound);
        this.__\u003C\u003Econsumes.liquid(Liquids.cryofluid, 0.25f);
      }

      [HideFromJava]
      static \u003146() => ImpactReactor.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u003147 : Drill
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {164, 98, 112, 127, 10, 103, 107, 135, 123})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u003147([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u003147 obj = this;
        this.requirements(Category.__\u003C\u003Eproduction, ItemStack.with((object) Items.copper, (object) Integer.valueOf(12)), true);
        this.tier = 2;
        this.drillTime = 600f;
        this.size = 2;
        this.__\u003C\u003Econsumes.liquid(Liquids.water, 0.05f).boost();
      }

      [HideFromJava]
      static \u003147() => Drill.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u003148 : Drill
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {164, 107, 112, 127, 27, 103, 107, 135, 123})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u003148([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u003148 obj = this;
        this.requirements(Category.__\u003C\u003Eproduction, ItemStack.with((object) Items.copper, (object) Integer.valueOf(18), (object) Items.graphite, (object) Integer.valueOf(10)));
        this.tier = 3;
        this.drillTime = 400f;
        this.size = 2;
        this.__\u003C\u003Econsumes.liquid(Liquids.water, 0.06f).boost();
      }

      [HideFromJava]
      static \u003148() => Drill.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u003149 : Drill
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {164, 116, 112, 127, 63, 107, 103, 103, 103, 107, 139, 113, 123})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u003149([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u003149 obj = this;
        this.requirements(Category.__\u003C\u003Eproduction, ItemStack.with((object) Items.copper, (object) Integer.valueOf(35), (object) Items.graphite, (object) Integer.valueOf(30), (object) Items.silicon, (object) Integer.valueOf(30), (object) Items.titanium, (object) Integer.valueOf(20)));
        this.drillTime = 280f;
        this.size = 3;
        this.hasPower = true;
        this.tier = 4;
        this.updateEffect = Fx.__\u003C\u003EpulverizeMedium;
        this.drillEffect = Fx.__\u003C\u003EmineBig;
        this.__\u003C\u003Econsumes.power(1.1f);
        this.__\u003C\u003Econsumes.liquid(Liquids.water, 0.08f).boost();
      }

      [HideFromJava]
      static \u003149() => Drill.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00315 : Floor
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {160, 114, 112, 117, 117, 107, 139, 103, 107, 122})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00315([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u00315 obj = this;
        this.attributes.set(Attribute.__\u003C\u003Eheat, 0.75f);
        this.attributes.set(Attribute.__\u003C\u003Ewater, -0.75f);
        this.updateEffect = Fx.__\u003C\u003Emagmasmoke;
        this.blendGroup = Blocks.basalt;
        this.emitLight = true;
        this.lightRadius = 50f;
        this.lightColor = Color.__\u003C\u003Eorange.cpy().a(0.3f);
      }

      [HideFromJava]
      static \u00315() => Floor.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u003150 : Drill
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {164, 129, 112, 127, 63, 107, 103, 103, 103, 103, 107, 107, 107, 107, 171, 139, 113, 123})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u003150([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u003150 obj = this;
        this.requirements(Category.__\u003C\u003Eproduction, ItemStack.with((object) Items.copper, (object) Integer.valueOf(65), (object) Items.silicon, (object) Integer.valueOf(60), (object) Items.titanium, (object) Integer.valueOf(50), (object) Items.thorium, (object) Integer.valueOf(75)));
        this.drillTime = 280f;
        this.size = 4;
        this.drawRim = true;
        this.hasPower = true;
        this.tier = 5;
        this.updateEffect = Fx.__\u003C\u003EpulverizeRed;
        this.updateEffectChance = 0.03f;
        this.drillEffect = Fx.__\u003C\u003EmineHuge;
        this.rotateSpeed = 6f;
        this.warmupSpeed = 0.01f;
        this.liquidBoostIntensity = 1.8f;
        this.__\u003C\u003Econsumes.power(3f);
        this.__\u003C\u003Econsumes.liquid(Liquids.water, 0.1f).boost();
      }

      [HideFromJava]
      static \u003150() => Drill.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u003151 : SolidPump
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {164, 149, 112, 127, 45, 107, 107, 103, 107, 107, 139, 113})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u003151([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u003151 obj = this;
        this.requirements(Category.__\u003C\u003Eproduction, ItemStack.with((object) Items.metaglass, (object) Integer.valueOf(30), (object) Items.graphite, (object) Integer.valueOf(30), (object) Items.lead, (object) Integer.valueOf(30)));
        this.result = Liquids.water;
        this.pumpAmount = 0.11f;
        this.size = 2;
        this.liquidCapacity = 30f;
        this.rotateSpeed = 1.4f;
        this.attribute = Attribute.__\u003C\u003Ewater;
        this.__\u003C\u003Econsumes.power(1.5f);
      }

      [HideFromJava]
      static \u003151() => SolidPump.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u003152 : Cultivator
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {164, 161, 112, 127, 45, 118, 107, 103, 103, 103, 135, 113, 118})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u003152([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u003152 obj = this;
        this.requirements(Category.__\u003C\u003Eproduction, ItemStack.with((object) Items.copper, (object) Integer.valueOf(25), (object) Items.lead, (object) Integer.valueOf(25), (object) Items.silicon, (object) Integer.valueOf(10)));
        ItemStack.__\u003Cclinit\u003E();
        this.outputItem = new ItemStack(Items.sporePod, 1);
        this.craftTime = 140f;
        this.size = 2;
        this.hasLiquids = true;
        this.hasPower = true;
        this.hasItems = true;
        this.__\u003C\u003Econsumes.power(0.9f);
        this.__\u003C\u003Econsumes.liquid(Liquids.water, 0.2f);
      }

      [HideFromJava]
      static \u003152() => Cultivator.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u003153 : Fracker
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {164, 174, 112, 127, 89, 107, 107, 107, 107, 107, 103, 107, 107, 107, 139, 113, 113, 118})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u003153([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u003153 obj = this;
        this.requirements(Category.__\u003C\u003Eproduction, ItemStack.with((object) Items.copper, (object) Integer.valueOf(150), (object) Items.graphite, (object) Integer.valueOf(175), (object) Items.lead, (object) Integer.valueOf(115), (object) Items.thorium, (object) Integer.valueOf(115), (object) Items.silicon, (object) Integer.valueOf(75)));
        this.result = Liquids.oil;
        this.updateEffect = Fx.__\u003C\u003Epulverize;
        this.liquidCapacity = 50f;
        this.updateEffectChance = 0.05f;
        this.pumpAmount = 0.25f;
        this.size = 3;
        this.liquidCapacity = 30f;
        this.attribute = Attribute.__\u003C\u003Eoil;
        this.baseEfficiency = 0.0f;
        this.itemUseTime = 60f;
        this.__\u003C\u003Econsumes.item(Items.sand);
        this.__\u003C\u003Econsumes.power(3f);
        this.__\u003C\u003Econsumes.liquid(Liquids.water, 0.15f);
      }

      [HideFromJava]
      static \u003153() => Fracker.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u003154 : CoreBlock
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {164, 195, 112, 127, 38, 135, 107, 107, 107, 135, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u003154([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u003154 obj = this;
        this.requirements(Category.__\u003C\u003Eeffect, BuildVisibility.__\u003C\u003EeditorOnly, ItemStack.with((object) Items.copper, (object) Integer.valueOf(1000), (object) Items.lead, (object) Integer.valueOf(800)));
        this.alwaysUnlocked = true;
        this.unitType = UnitTypes.alpha;
        this.health = 1100;
        this.itemCapacity = 4000;
        this.size = 3;
        this.unitCapModifier = 8;
      }

      [HideFromJava]
      static \u003154() => CoreBlock.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u003155 : CoreBlock
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {164, 207, 112, 159, 54, 107, 107, 107, 135, 104, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u003155([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u003155 obj = this;
        this.requirements(Category.__\u003C\u003Eeffect, ItemStack.with((object) Items.copper, (object) Integer.valueOf(3000), (object) Items.lead, (object) Integer.valueOf(3000), (object) Items.silicon, (object) Integer.valueOf(2000)));
        this.unitType = UnitTypes.beta;
        this.health = 3500;
        this.itemCapacity = 9000;
        this.size = 4;
        this.unitCapModifier = 16;
        this.researchCostMultiplier = 0.04f;
      }

      [HideFromJava]
      static \u003155() => CoreBlock.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u003156 : CoreBlock
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {164, 219, 112, 159, 75, 107, 107, 107, 135, 104, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u003156([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u003156 obj = this;
        this.requirements(Category.__\u003C\u003Eeffect, ItemStack.with((object) Items.copper, (object) Integer.valueOf(8000), (object) Items.lead, (object) Integer.valueOf(8000), (object) Items.silicon, (object) Integer.valueOf(5000), (object) Items.thorium, (object) Integer.valueOf(4000)));
        this.unitType = UnitTypes.gamma;
        this.health = 6000;
        this.itemCapacity = 13000;
        this.size = 5;
        this.unitCapModifier = 24;
        this.researchCostMultiplier = 0.06f;
      }

      [HideFromJava]
      static \u003156() => CoreBlock.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u003157 : StorageBlock
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {164, 231, 112, 127, 30, 103, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u003157([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u003157 obj = this;
        this.requirements(Category.__\u003C\u003Eeffect, ItemStack.with((object) Items.titanium, (object) Integer.valueOf(250), (object) Items.thorium, (object) Integer.valueOf(125)));
        this.size = 3;
        this.itemCapacity = 1000;
      }

      [HideFromJava]
      static \u003157() => StorageBlock.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u003158 : StorageBlock
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {164, 237, 112, 127, 9, 103, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u003158([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u003158 obj = this;
        this.requirements(Category.__\u003C\u003Eeffect, ItemStack.with((object) Items.titanium, (object) Integer.valueOf(100)));
        this.size = 2;
        this.itemCapacity = 300;
      }

      [HideFromJava]
      static \u003158() => StorageBlock.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u003159 : Unloader
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {164, 243, 112, 127, 27, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u003159([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u003159 obj = this;
        this.requirements(Category.__\u003C\u003Eeffect, ItemStack.with((object) Items.titanium, (object) Integer.valueOf(25), (object) Items.silicon, (object) Integer.valueOf(30)));
        this.speed = 6f;
        this.group = BlockGroup.__\u003C\u003Etransportation;
      }

      [HideFromJava]
      static \u003159() => Unloader.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00316 : Floor
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {160, 125, 112, 107, 103, 117})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00316([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u00316 obj = this;
        this.itemDrop = Items.sand;
        this.playerUnmineable = true;
        this.attributes.set(Attribute.__\u003C\u003Eoil, 0.7f);
      }

      [HideFromJava]
      static \u00316() => Floor.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u003160 : ItemTurret
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {164, 252, 112, 127, 10, 255, 45, 71, 107, 103, 103, 107, 107, 107, 107, 107, 107, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u003160([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u003160 obj = this;
        this.requirements(Category.__\u003C\u003Eturret, ItemStack.with((object) Items.copper, (object) Integer.valueOf(35)), true);
        this.ammo((object) Items.copper, (object) Bullets.standardCopper, (object) Items.graphite, (object) Bullets.standardDense, (object) Items.pyratite, (object) Bullets.standardIncendiary, (object) Items.silicon, (object) Bullets.standardHoming);
        this.spread = 4f;
        this.shots = 2;
        this.alternate = true;
        this.reloadTime = 20f;
        this.restitution = 0.03f;
        this.range = 100f;
        this.shootCone = 15f;
        this.ammoUseEffect = Fx.__\u003C\u003Ecasing1;
        this.health = 250;
        this.inaccuracy = 2f;
        this.rotateSpeed = 10f;
      }

      [HideFromJava]
      static \u003160() => ItemTurret.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u003161 : ItemTurret
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {165, 18, 112, 127, 27, 255, 29, 69, 107, 107, 103, 107, 103, 135, 107, 107, 107, 139, 121, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u003161([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u003161 obj = this;
        this.requirements(Category.__\u003C\u003Eturret, ItemStack.with((object) Items.copper, (object) Integer.valueOf(85), (object) Items.lead, (object) Integer.valueOf(45)));
        this.ammo((object) Items.scrap, (object) Bullets.flakScrap, (object) Items.lead, (object) Bullets.flakLead, (object) Items.metaglass, (object) Bullets.flakGlass);
        this.reloadTime = 18f;
        this.range = 160f;
        this.size = 2;
        this.burstSpacing = 5f;
        this.shots = 2;
        this.targetGround = false;
        this.recoilAmount = 2f;
        this.rotateSpeed = 15f;
        this.inaccuracy = 17f;
        this.shootCone = 35f;
        this.health = 200 * this.size * this.size;
        this.shootSound = Sounds.shootSnap;
      }

      [HideFromJava]
      static \u003161() => ItemTurret.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u003162 : ItemTurret
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {165, 41, 112, 127, 27, 223, 13, 107, 107, 107, 107, 107, 103, 107, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u003162([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u003162 obj = this;
        this.requirements(Category.__\u003C\u003Eturret, ItemStack.with((object) Items.copper, (object) Integer.valueOf(25), (object) Items.graphite, (object) Integer.valueOf(22)));
        this.ammo((object) Items.coal, (object) Bullets.basicFlame, (object) Items.pyratite, (object) Bullets.pyraFlame);
        this.recoilAmount = 0.0f;
        this.reloadTime = 6f;
        this.coolantMultiplier = 1.5f;
        this.range = 60f;
        this.shootCone = 50f;
        this.targetAir = false;
        this.ammoUseEffect = Fx.__\u003C\u003Enone;
        this.health = 400;
        this.shootSound = Sounds.flame;
      }

      [HideFromJava]
      static \u003162() => ItemTurret.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u003163 : ItemTurret
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {165, 58, 112, 127, 27, 255, 29, 69, 103, 107, 107, 107, 107, 107, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u003163([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u003163 obj = this;
        this.requirements(Category.__\u003C\u003Eturret, ItemStack.with((object) Items.copper, (object) Integer.valueOf(40), (object) Items.graphite, (object) Integer.valueOf(17)));
        this.ammo((object) Items.graphite, (object) Bullets.artilleryDense, (object) Items.silicon, (object) Bullets.artilleryHoming, (object) Items.pyratite, (object) Bullets.artilleryIncendiary);
        this.targetAir = false;
        this.reloadTime = 60f;
        this.recoilAmount = 2f;
        this.range = 230f;
        this.inaccuracy = 1f;
        this.shootCone = 10f;
        this.health = 260;
        this.shootSound = Sounds.bang;
      }

      [HideFromJava]
      static \u003163() => ItemTurret.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u003164 : LiquidTurret
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {165, 75, 112, 127, 27, 255, 45, 70, 103, 107, 107, 107, 107, 107, 107, 107, 121, 127, 2})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u003164([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u003164 obj = this;
        this.requirements(Category.__\u003C\u003Eturret, ItemStack.with((object) Items.metaglass, (object) Integer.valueOf(45), (object) Items.lead, (object) Integer.valueOf(75)));
        this.ammo((object) Liquids.water, (object) Bullets.waterShot, (object) Liquids.slag, (object) Bullets.slagShot, (object) Liquids.cryofluid, (object) Bullets.cryoShot, (object) Liquids.oil, (object) Bullets.oilShot);
        this.size = 2;
        this.recoilAmount = 0.0f;
        this.reloadTime = 2f;
        this.inaccuracy = 5f;
        this.shootCone = 50f;
        this.liquidCapacity = 10f;
        this.shootEffect = Fx.__\u003C\u003EshootLiquid;
        this.range = 110f;
        this.health = 250 * this.size * this.size;
        this.flags = EnumSet.of((Enum[]) new BlockFlag[2]
        {
          BlockFlag.__\u003C\u003Eturret,
          BlockFlag.__\u003C\u003Eextinguisher
        });
      }

      [HideFromJava]
      static \u003164() => LiquidTurret.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u003165 : PowerTurret
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {165, 95, 112, 127, 45, 107, 107, 107, 103, 107, 107, 107, 107, 107, 107, 107, 107, 107, 107, 103, 121, 103, 139, 241, 74})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u003165([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u003165 obj = this;
        this.requirements(Category.__\u003C\u003Eturret, ItemStack.with((object) Items.copper, (object) Integer.valueOf(60), (object) Items.lead, (object) Integer.valueOf(70), (object) Items.silicon, (object) Integer.valueOf(50)));
        this.range = 165f;
        this.chargeTime = 40f;
        this.chargeMaxDelay = 30f;
        this.chargeEffects = 7;
        this.recoilAmount = 2f;
        this.reloadTime = 80f;
        this.cooldown = 0.03f;
        this.powerUse = 6f;
        this.shootShake = 2f;
        this.shootEffect = Fx.__\u003C\u003ElancerLaserShoot;
        this.smokeEffect = Fx.__\u003C\u003Enone;
        this.chargeEffect = Fx.__\u003C\u003ElancerLaserCharge;
        this.chargeBeginEffect = Fx.__\u003C\u003ElancerLaserChargeBegin;
        this.heatColor = Color.__\u003C\u003Ered;
        this.size = 2;
        this.health = 280 * this.size * this.size;
        this.targetAir = false;
        this.shootSound = Sounds.laser;
        this.shootType = (BulletType) new Blocks.\u003165.\u0031(this, 140f);
      }

      [HideFromJava]
      static \u003165() => PowerTurret.__\u003Cclinit\u003E();

      [InnerClass]
      [EnclosingMethod(null, null, null)]
      [SpecialName]
      internal new class \u0031 : LaserBulletType
      {
        [Modifiers]
        internal Blocks.\u003165 this\u00241;

        [LineNumberTable(new byte[] {165, 116, 113, 127, 20, 107, 107, 107, 107, 107, 103, 107})]
        [MethodImpl(MethodImplOptions.NoInlining)]
        internal \u0031([In] Blocks.\u003165 obj0, [In] float obj1)
        {
          this.this\u00241 = obj0;
          // ISSUE: explicit constructor call
          base.\u002Ector(obj1);
          Blocks.\u003165.\u0031 obj = this;
          this.colors = new Color[3]
          {
            Pal.lancerLaser.cpy().a(0.4f),
            Pal.lancerLaser,
            Color.__\u003C\u003Ewhite
          };
          this.hitEffect = Fx.__\u003C\u003EhitLancer;
          this.despawnEffect = Fx.__\u003C\u003Enone;
          this.hitSize = 4f;
          this.lifetime = 16f;
          this.drawSize = 400f;
          this.collidesAir = false;
          this.length = 173f;
        }
      }
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u003166 : PowerTurret
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {165, 128, 112, 127, 27, 236, 69, 107, 107, 107, 107, 103, 107, 107, 107, 107, 103, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u003166([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u003166 obj = this;
        this.requirements(Category.__\u003C\u003Eturret, ItemStack.with((object) Items.copper, (object) Integer.valueOf(50), (object) Items.lead, (object) Integer.valueOf(50)));
        this.shootType = (BulletType) new Blocks.\u003166.\u0031(this);
        this.reloadTime = 35f;
        this.shootCone = 40f;
        this.rotateSpeed = 8f;
        this.powerUse = 3.3f;
        this.targetAir = false;
        this.range = 90f;
        this.shootEffect = Fx.__\u003C\u003ElightningShoot;
        this.heatColor = Color.__\u003C\u003Ered;
        this.recoilAmount = 1f;
        this.size = 1;
        this.health = 260;
        this.shootSound = Sounds.spark;
      }

      [HideFromJava]
      static \u003166() => PowerTurret.__\u003Cclinit\u003E();

      [InnerClass]
      [EnclosingMethod(null, null, null)]
      [SpecialName]
      internal new class \u0031 : LightningBulletType
      {
        [Modifiers]
        internal Blocks.\u003166 this\u00241;

        [LineNumberTable(new byte[] {165, 130, 111, 107, 104, 103})]
        [MethodImpl(MethodImplOptions.NoInlining)]
        internal \u0031([In] Blocks.\u003166 obj0)
        {
          this.this\u00241 = obj0;
          // ISSUE: explicit constructor call
          base.\u002Ector();
          Blocks.\u003166.\u0031 obj = this;
          this.damage = 20f;
          this.lightningLength = 25;
          this.collidesAir = false;
        }
      }
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u003167 : TractorBeamTurret
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {165, 149, 112, 159, 45, 103, 103, 107, 107, 107, 107, 121, 139, 123})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u003167([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u003167 obj = this;
        this.requirements(Category.__\u003C\u003Eturret, ItemStack.with((object) Items.silicon, (object) Integer.valueOf(120), (object) Items.titanium, (object) Integer.valueOf(90), (object) Items.graphite, (object) Integer.valueOf(30)));
        this.hasPower = true;
        this.size = 2;
        this.force = 8f;
        this.scaledForce = 7f;
        this.range = 230f;
        this.damage = 0.3f;
        this.health = 160 * this.size * this.size;
        this.rotateSpeed = 10f;
        this.__\u003C\u003Econsumes.powerCond(3f, (Boolf) new Blocks.\u003167.__\u003C\u003EAnon0());
      }

      [Modifiers]
      [LineNumberTable(1555)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static bool lambda\u0024new\u00240([In] TractorBeamTurret.TractorBeamBuild obj0) => obj0.target != null;

      [HideFromJava]
      static \u003167() => TractorBeamTurret.__\u003Cclinit\u003E();

      [SpecialName]
      private new sealed class __\u003C\u003EAnon0 : Boolf
      {
        internal __\u003C\u003EAnon0()
        {
        }

        public bool get([In] object obj0) => (Blocks.\u003167.lambda\u0024new\u00240((TractorBeamTurret.TractorBeamBuild) obj0) ? 1 : 0) != 0;
      }
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u003168 : ItemTurret
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {165, 164, 112, 127, 63, 255, 29, 69, 107, 103, 107, 107, 107, 107, 103, 121, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u003168([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u003168 obj = this;
        this.requirements(Category.__\u003C\u003Eturret, ItemStack.with((object) Items.graphite, (object) Integer.valueOf(35), (object) Items.titanium, (object) Integer.valueOf(35), (object) Items.plastanium, (object) Integer.valueOf(45), (object) Items.silicon, (object) Integer.valueOf(30)));
        this.ammo((object) Items.blastCompound, (object) Bullets.missileExplosive, (object) Items.pyratite, (object) Bullets.missileIncendiary, (object) Items.surgeAlloy, (object) Bullets.missileSurge);
        this.reloadTime = 30f;
        this.shots = 4;
        this.burstSpacing = 5f;
        this.inaccuracy = 10f;
        this.range = 200f;
        this.xRand = 6f;
        this.size = 2;
        this.health = 300 * this.size * this.size;
        this.shootSound = Sounds.missile;
      }

      [HideFromJava]
      static \u003168() => ItemTurret.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u003169 : ItemTurret
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {165, 182, 112, 127, 45, 255, 63, 72, 103, 107, 107, 107, 107, 107, 107, 107, 107, 103, 107, 121, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u003169([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u003169 obj = this;
        this.requirements(Category.__\u003C\u003Eturret, ItemStack.with((object) Items.copper, (object) Integer.valueOf(100), (object) Items.graphite, (object) Integer.valueOf(90), (object) Items.titanium, (object) Integer.valueOf(60)));
        this.ammo((object) Items.copper, (object) Bullets.standardCopper, (object) Items.graphite, (object) Bullets.standardDense, (object) Items.pyratite, (object) Bullets.standardIncendiary, (object) Items.silicon, (object) Bullets.standardHoming, (object) Items.thorium, (object) Bullets.standardThorium);
        this.size = 2;
        this.range = 150f;
        this.reloadTime = 38f;
        this.restitution = 0.03f;
        this.ammoEjectBack = 3f;
        this.cooldown = 0.03f;
        this.recoilAmount = 3f;
        this.shootShake = 1f;
        this.burstSpacing = 3f;
        this.shots = 4;
        this.ammoUseEffect = Fx.__\u003C\u003Ecasing2;
        this.health = 240 * this.size * this.size;
        this.shootSound = Sounds.shootBig;
      }

      [HideFromJava]
      static \u003169() => ItemTurret.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00317 : Floor
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {160, 131, 112, 107, 103, 117})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00317([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u00317 obj = this;
        this.itemDrop = Items.sand;
        this.playerUnmineable = true;
        this.attributes.set(Attribute.__\u003C\u003Eoil, 1.5f);
      }

      [HideFromJava]
      static \u00317() => Floor.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u003170 : PointDefenseTurret
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {165, 207, 112, 159, 48, 121, 107, 103, 123, 103, 107, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u003170([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u003170 obj = this;
        this.requirements(Category.__\u003C\u003Eturret, ItemStack.with((object) Items.silicon, (object) Integer.valueOf(130), (object) Items.thorium, (object) Integer.valueOf(80), (object) Items.phaseFabric, (object) Integer.valueOf(40)));
        this.health = 250 * this.size * this.size;
        this.range = 180f;
        this.hasPower = true;
        this.__\u003C\u003Econsumes.powerCond(8f, (Boolf) new Blocks.\u003170.__\u003C\u003EAnon0());
        this.size = 2;
        this.shootLength = 5f;
        this.bulletDamage = 30f;
        this.reloadTime = 9f;
      }

      [Modifiers]
      [LineNumberTable(1607)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static bool lambda\u0024new\u00240([In] PointDefenseTurret.PointDefenseBuild obj0) => obj0.target != null;

      [HideFromJava]
      static \u003170() => PointDefenseTurret.__\u003Cclinit\u003E();

      [SpecialName]
      private new sealed class __\u003C\u003EAnon0 : Boolf
      {
        internal __\u003C\u003EAnon0()
        {
        }

        public bool get([In] object obj0) => (Blocks.\u003170.lambda\u0024new\u00240((PointDefenseTurret.PointDefenseBuild) obj0) ? 1 : 0) != 0;
      }
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u003171 : LiquidTurret
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {165, 220, 112, 127, 69, 255, 45, 70, 103, 107, 103, 107, 107, 107, 107, 107, 107, 107, 107, 121, 127, 2})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u003171([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u003171 obj = this;
        this.requirements(Category.__\u003C\u003Eturret, ItemStack.with((object) Items.metaglass, (object) Integer.valueOf(100), (object) Items.lead, (object) Integer.valueOf(400), (object) Items.titanium, (object) Integer.valueOf(250), (object) Items.thorium, (object) Integer.valueOf(100)));
        this.ammo((object) Liquids.water, (object) Bullets.heavyWaterShot, (object) Liquids.slag, (object) Bullets.heavySlagShot, (object) Liquids.cryofluid, (object) Bullets.heavyCryoShot, (object) Liquids.oil, (object) Bullets.heavyOilShot);
        this.size = 3;
        this.reloadTime = 2f;
        this.shots = 2;
        this.velocityInaccuracy = 0.1f;
        this.inaccuracy = 4f;
        this.recoilAmount = 1f;
        this.restitution = 0.04f;
        this.shootCone = 45f;
        this.liquidCapacity = 40f;
        this.shootEffect = Fx.__\u003C\u003EshootLiquid;
        this.range = 190f;
        this.health = 250 * this.size * this.size;
        this.flags = EnumSet.of((Enum[]) new BlockFlag[2]
        {
          BlockFlag.__\u003C\u003Eturret,
          BlockFlag.__\u003C\u003Eextinguisher
        });
      }

      [HideFromJava]
      static \u003171() => LiquidTurret.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u003172 : ItemTurret
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {165, 243, 112, 159, 51, 107, 107, 107, 107, 103, 107, 107, 107, 135, 121, 139, 142, 255, 17, 80})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u003172([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u003172 obj = this;
        this.requirements(Category.__\u003C\u003Eturret, ItemStack.with((object) Items.copper, (object) Integer.valueOf(225), (object) Items.graphite, (object) Integer.valueOf(225), (object) Items.thorium, (object) Integer.valueOf(100)));
        this.reloadTime = 35f;
        this.shootShake = 4f;
        this.range = 90f;
        this.recoilAmount = 5f;
        this.shots = 3;
        this.spread = 20f;
        this.restitution = 0.1f;
        this.shootCone = 30f;
        this.size = 3;
        this.health = 220 * this.size * this.size;
        this.shootSound = Sounds.shotgun;
        float num = this.range + 10f;
        this.ammo((object) Items.titanium, (object) new Blocks.\u003172.\u0031(this, num), (object) Items.thorium, (object) new Blocks.\u003172.\u0032(this, num));
      }

      [HideFromJava]
      static \u003172() => ItemTurret.__\u003Cclinit\u003E();

      [InnerClass]
      [EnclosingMethod(null, null, null)]
      [SpecialName]
      internal new class \u0031 : ShrapnelBulletType
      {
        [Modifiers]
        internal float val\u0024brange;
        [Modifiers]
        internal Blocks.\u003172 this\u00241;

        [LineNumberTable(new byte[] {166, 6, 119, 108, 107, 107, 107, 107})]
        [MethodImpl(MethodImplOptions.NoInlining)]
        internal \u0031([In] Blocks.\u003172 obj0, [In] float obj1)
        {
          this.this\u00241 = obj0;
          this.val\u0024brange = obj1;
          // ISSUE: explicit constructor call
          base.\u002Ector();
          Blocks.\u003172.\u0031 obj = this;
          this.length = this.val\u0024brange;
          this.damage = 66f;
          this.ammoMultiplier = 4f;
          this.width = 17f;
          this.reloadMultiplier = 1.3f;
        }
      }

      [InnerClass]
      [EnclosingMethod(null, null, null)]
      [SpecialName]
      internal class \u0032 : ShrapnelBulletType
      {
        [Modifiers]
        internal float val\u0024brange;
        [Modifiers]
        internal Blocks.\u003172 this\u00241;

        [LineNumberTable(new byte[] {166, 13, 119, 108, 107, 107, 107, 118})]
        [MethodImpl(MethodImplOptions.NoInlining)]
        internal \u0032([In] Blocks.\u003172 obj0, [In] float obj1)
        {
          this.this\u00241 = obj0;
          this.val\u0024brange = obj1;
          // ISSUE: explicit constructor call
          base.\u002Ector();
          Blocks.\u003172.\u0032 obj2 = this;
          this.length = this.val\u0024brange;
          this.damage = 105f;
          this.ammoMultiplier = 5f;
          this.toColor = Pal.thoriumPink;
          Blocks.\u003172.\u0032 obj3 = this;
          Effect thoriumShoot = Fx.__\u003C\u003EthoriumShoot;
          Effect effect = thoriumShoot;
          this.smokeEffect = thoriumShoot;
          this.shootEffect = effect;
        }
      }
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u003173 : ItemTurret
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {166, 23, 112, 127, 51, 255, 63, 72, 103, 103, 103, 107, 107, 107, 107, 103, 107, 107, 107, 107, 107, 107, 139, 121, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u003173([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u003173 obj = this;
        this.requirements(Category.__\u003C\u003Eturret, ItemStack.with((object) Items.copper, (object) Integer.valueOf(150), (object) Items.graphite, (object) Integer.valueOf(135), (object) Items.titanium, (object) Integer.valueOf(60)));
        this.ammo((object) Items.graphite, (object) Bullets.artilleryDense, (object) Items.silicon, (object) Bullets.artilleryHoming, (object) Items.pyratite, (object) Bullets.artilleryIncendiary, (object) Items.blastCompound, (object) Bullets.artilleryExplosive, (object) Items.plastanium, (object) Bullets.artilleryPlastic);
        this.targetAir = false;
        this.size = 3;
        this.shots = 4;
        this.inaccuracy = 12f;
        this.reloadTime = 60f;
        this.ammoEjectBack = 5f;
        this.ammoUseEffect = Fx.__\u003C\u003Ecasing3Double;
        this.ammoPerShot = 2;
        this.cooldown = 0.03f;
        this.velocityInaccuracy = 0.2f;
        this.restitution = 0.02f;
        this.recoilAmount = 6f;
        this.shootShake = 2f;
        this.range = 290f;
        this.minRange = 50f;
        this.health = 130 * this.size * this.size;
        this.shootSound = Sounds.artillery;
      }

      [HideFromJava]
      static \u003173() => ItemTurret.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u003174 : ItemTurret
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {166, 53, 112, 127, 48, 255, 45, 70, 107, 107, 107, 103, 107, 107, 107, 107, 139, 121})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u003174([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u003174 obj = this;
        this.requirements(Category.__\u003C\u003Eturret, ItemStack.with((object) Items.copper, (object) Integer.valueOf(200), (object) Items.titanium, (object) Integer.valueOf(125), (object) Items.plastanium, (object) Integer.valueOf(80)));
        this.ammo((object) Items.metaglass, (object) Bullets.fragGlass, (object) Items.blastCompound, (object) Bullets.fragExplosive, (object) Items.plastanium, (object) Bullets.fragPlastic, (object) Items.surgeAlloy, (object) Bullets.fragSurge);
        this.xRand = 4f;
        this.reloadTime = 8f;
        this.range = 200f;
        this.size = 3;
        this.recoilAmount = 3f;
        this.rotateSpeed = 10f;
        this.inaccuracy = 10f;
        this.shootCone = 30f;
        this.shootSound = Sounds.shootSnap;
        this.health = 145 * this.size * this.size;
      }

      [HideFromJava]
      static \u003174() => ItemTurret.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u003175 : ItemTurret
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {166, 74, 112, 145, 127, 98, 254, 80, 104, 103, 107, 107, 107, 107, 107, 107, 107, 103, 103, 107, 107, 144, 139, 121, 139, 123})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u003175([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u003175 obj2 = this;
        Blocks.\u003175 obj3 = this;
        float num1 = 500f;
        double num2 = (double) num1;
        this.range = num1;
        float num3 = (float) num2;
        this.requirements(Category.__\u003C\u003Eturret, ItemStack.with((object) Items.copper, (object) Integer.valueOf(1000), (object) Items.metaglass, (object) Integer.valueOf(600), (object) Items.surgeAlloy, (object) Integer.valueOf(300), (object) Items.plastanium, (object) Integer.valueOf(200), (object) Items.silicon, (object) Integer.valueOf(600)));
        this.ammo((object) Items.surgeAlloy, (object) new Blocks.\u003175.\u0031(this, num3));
        this.maxAmmo = 40;
        this.ammoPerShot = 4;
        this.rotateSpeed = 2f;
        this.reloadTime = 200f;
        this.ammoUseEffect = Fx.__\u003C\u003Ecasing3Double;
        this.recoilAmount = 5f;
        this.restitution = 0.009f;
        this.cooldown = 0.009f;
        this.shootShake = 4f;
        this.shots = 1;
        this.size = 4;
        this.shootCone = 2f;
        this.shootSound = Sounds.railgun;
        this.unitSort = (Units.Sortf) new Blocks.\u003175.__\u003C\u003EAnon0();
        this.coolantMultiplier = 0.4f;
        this.health = 150 * this.size * this.size;
        this.coolantUsage = 1f;
        this.__\u003C\u003Econsumes.powerCond(10f, (Boolf) new Blocks.\u003175.__\u003C\u003EAnon1());
      }

      [Modifiers]
      [LineNumberTable(1757)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static float lambda\u0024new\u00240([In] Unit obj0, [In] float obj1, [In] float obj2) => -obj0.maxHealth;

      [HideFromJava]
      static \u003175() => ItemTurret.__\u003Cclinit\u003E();

      [InnerClass]
      [EnclosingMethod(null, null, null)]
      [SpecialName]
      internal new class \u0031 : PointBulletType
      {
        [Modifiers]
        internal float val\u0024brange;
        [Modifiers]
        internal Blocks.\u003175 this\u00241;

        [LineNumberTable(new byte[] {166, 79, 119, 107, 107, 107, 107, 107, 107, 107, 107, 108, 107, 107})]
        [MethodImpl(MethodImplOptions.NoInlining)]
        internal \u0031([In] Blocks.\u003175 obj0, [In] float obj1)
        {
          this.this\u00241 = obj0;
          this.val\u0024brange = obj1;
          // ISSUE: explicit constructor call
          base.\u002Ector();
          Blocks.\u003175.\u0031 obj = this;
          this.shootEffect = Fx.__\u003C\u003EinstShoot;
          this.hitEffect = Fx.__\u003C\u003EinstHit;
          this.smokeEffect = Fx.__\u003C\u003EsmokeCloud;
          this.trailEffect = Fx.__\u003C\u003EinstTrail;
          this.despawnEffect = Fx.__\u003C\u003EinstBomb;
          this.trailSpacing = 20f;
          this.damage = 1350f;
          this.buildingDamageMultiplier = 0.3f;
          this.speed = this.val\u0024brange;
          this.hitShake = 6f;
          this.ammoMultiplier = 1f;
        }
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon0 : Units.Sortf
      {
        internal __\u003C\u003EAnon0()
        {
        }

        public float cost([In] Unit obj0, [In] float obj1, [In] float obj2) => Blocks.\u003175.lambda\u0024new\u00240(obj0, obj1, obj2);
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon1 : Boolf
      {
        internal __\u003C\u003EAnon1()
        {
        }

        public bool get([In] object obj0) => (((Turret.TurretBuild) obj0).isActive() ? 1 : 0) != 0;
      }
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u003176 : ItemTurret
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {166, 117, 112, 127, 98, 255, 29, 69, 107, 107, 107, 107, 107, 107, 107, 107, 103, 107, 103, 103, 107, 139, 121, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u003176([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u003176 obj = this;
        this.requirements(Category.__\u003C\u003Eturret, ItemStack.with((object) Items.copper, (object) Integer.valueOf(900), (object) Items.graphite, (object) Integer.valueOf(300), (object) Items.surgeAlloy, (object) Integer.valueOf(250), (object) Items.plastanium, (object) Integer.valueOf(175), (object) Items.thorium, (object) Integer.valueOf(250)));
        this.ammo((object) Items.graphite, (object) Bullets.standardDenseBig, (object) Items.pyratite, (object) Bullets.standardIncendiaryBig, (object) Items.thorium, (object) Bullets.standardThoriumBig);
        this.reloadTime = 6f;
        this.coolantMultiplier = 0.5f;
        this.restitution = 0.1f;
        this.ammoUseEffect = Fx.__\u003C\u003Ecasing3;
        this.range = 200f;
        this.inaccuracy = 3f;
        this.recoilAmount = 3f;
        this.spread = 8f;
        this.alternate = true;
        this.shootShake = 2f;
        this.shots = 2;
        this.size = 4;
        this.shootCone = 24f;
        this.shootSound = Sounds.shootBig;
        this.health = 160 * this.size * this.size;
        this.coolantUsage = 1f;
      }

      [HideFromJava]
      static \u003176() => ItemTurret.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u003177 : LaserTurret
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {166, 143, 112, 127, 98, 107, 107, 107, 103, 107, 107, 107, 107, 107, 107, 107, 107, 139, 241, 75, 121, 127, 12})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u003177([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u003177 obj = this;
        this.requirements(Category.__\u003C\u003Eturret, ItemStack.with((object) Items.copper, (object) Integer.valueOf(1200), (object) Items.lead, (object) Integer.valueOf(350), (object) Items.graphite, (object) Integer.valueOf(300), (object) Items.surgeAlloy, (object) Integer.valueOf(325), (object) Items.silicon, (object) Integer.valueOf(325)));
        this.shootEffect = Fx.__\u003C\u003EshootBigSmoke2;
        this.shootCone = 40f;
        this.recoilAmount = 4f;
        this.size = 4;
        this.shootShake = 2f;
        this.range = 190f;
        this.reloadTime = 90f;
        this.firingMoveFract = 0.5f;
        this.shootDuration = 220f;
        this.powerUse = 17f;
        this.shootSound = Sounds.laserbig;
        this.loopSound = Sounds.beam;
        this.loopSoundVolume = 2f;
        this.shootType = (BulletType) new Blocks.\u003177.\u0031(this, 70f);
        this.health = 200 * this.size * this.size;
        this.__\u003C\u003Econsumes.add((Consume) new ConsumeLiquidFilter((Boolf) new Blocks.\u003177.__\u003C\u003EAnon0(), 0.5f)).update(false);
      }

      [Modifiers]
      [LineNumberTable(1821)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static bool lambda\u0024new\u00240([In] Liquid obj0) => (double) obj0.temperature <= 0.5 && (double) obj0.flammability < 0.100000001490116;

      [HideFromJava]
      static \u003177() => LaserTurret.__\u003Cclinit\u003E();

      [InnerClass]
      [EnclosingMethod(null, null, null)]
      [SpecialName]
      internal new class \u0031 : ContinuousLaserBulletType
      {
        [Modifiers]
        internal Blocks.\u003177 this\u00241;

        [LineNumberTable(new byte[] {166, 159, 113, 107, 107, 107, 139, 107, 107, 103})]
        [MethodImpl(MethodImplOptions.NoInlining)]
        internal \u0031([In] Blocks.\u003177 obj0, [In] float obj1)
        {
          this.this\u00241 = obj0;
          // ISSUE: explicit constructor call
          base.\u002Ector(obj1);
          Blocks.\u003177.\u0031 obj = this;
          this.length = 200f;
          this.hitEffect = Fx.__\u003C\u003EhitMeltdown;
          this.hitColor = Pal.meltdownHit;
          this.drawSize = 420f;
          this.incendChance = 0.4f;
          this.incendSpread = 5f;
          this.incendAmount = 1;
        }
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon0 : Boolf
      {
        internal __\u003C\u003EAnon0()
        {
        }

        public bool get([In] object obj0) => (Blocks.\u003177.lambda\u0024new\u00240((Liquid) obj0) ? 1 : 0) != 0;
      }
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u003178 : CommandCenter
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {166, 177, 112, 127, 72, 103, 118})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u003178([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u003178 obj = this;
        this.requirements(Category.__\u003C\u003Eunits, ItemStack.with((object) Items.copper, (object) Integer.valueOf(200), (object) Items.lead, (object) Integer.valueOf(250), (object) Items.silicon, (object) Integer.valueOf(250), (object) Items.graphite, (object) Integer.valueOf(100)));
        this.size = 2;
        this.health = this.size * this.size * 55;
      }

      [HideFromJava]
      static \u003178() => CommandCenter.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u003179 : UnitFactory
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {166, 183, 112, 127, 45, 127, 6, 127, 34, 127, 34, 255, 22, 61, 234, 69, 103, 113})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u003179([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u003179 obj = this;
        this.requirements(Category.__\u003C\u003Eunits, ItemStack.with((object) Items.copper, (object) Integer.valueOf(50), (object) Items.lead, (object) Integer.valueOf(120), (object) Items.silicon, (object) Integer.valueOf(80)));
        this.plans = Seq.with((object[]) new UnitFactory.UnitPlan[3]
        {
          new UnitFactory.UnitPlan(UnitTypes.dagger, 900f, ItemStack.with((object) Items.silicon, (object) Integer.valueOf(10), (object) Items.lead, (object) Integer.valueOf(10))),
          new UnitFactory.UnitPlan(UnitTypes.crawler, 720f, ItemStack.with((object) Items.silicon, (object) Integer.valueOf(10), (object) Items.coal, (object) Integer.valueOf(20))),
          new UnitFactory.UnitPlan(UnitTypes.nova, 2400f, ItemStack.with((object) Items.silicon, (object) Integer.valueOf(30), (object) Items.lead, (object) Integer.valueOf(20), (object) Items.titanium, (object) Integer.valueOf(20)))
        });
        this.size = 3;
        this.__\u003C\u003Econsumes.power(1.2f);
      }

      [HideFromJava]
      static \u003179() => UnitFactory.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00318 : Floor
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {160, 139, 112, 107, 103, 107, 107, 117, 107, 107, 107, 107, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00318([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u00318 obj = this;
        this.speedMultiplier = 0.6f;
        this.variants = 3;
        this.status = StatusEffects.muddy;
        this.statusDuration = 30f;
        this.attributes.set(Attribute.__\u003C\u003Ewater, 1f);
        this.cacheLayer = CacheLayer.__\u003C\u003Emud;
        this.albedo = 0.35f;
        this.walkSound = Sounds.mud;
        this.walkSoundVolume = 0.08f;
        this.walkSoundPitchMin = 0.4f;
        this.walkSoundPitchMax = 0.5f;
      }

      [HideFromJava]
      static \u00318() => Floor.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u003180 : UnitFactory
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {166, 194, 112, 127, 27, 127, 6, 127, 16, 31, 4, 202, 103, 113})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u003180([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u003180 obj = this;
        this.requirements(Category.__\u003C\u003Eunits, ItemStack.with((object) Items.copper, (object) Integer.valueOf(60), (object) Items.lead, (object) Integer.valueOf(70)));
        this.plans = Seq.with((object[]) new UnitFactory.UnitPlan[2]
        {
          new UnitFactory.UnitPlan(UnitTypes.flare, 900f, ItemStack.with((object) Items.silicon, (object) Integer.valueOf(15))),
          new UnitFactory.UnitPlan(UnitTypes.mono, 2100f, ItemStack.with((object) Items.silicon, (object) Integer.valueOf(30), (object) Items.lead, (object) Integer.valueOf(15)))
        });
        this.size = 3;
        this.__\u003C\u003Econsumes.power(1.2f);
      }

      [HideFromJava]
      static \u003180() => UnitFactory.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u003181 : UnitFactory
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {166, 204, 112, 127, 51, 127, 6, 63, 4, 170, 103, 113, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u003181([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u003181 obj = this;
        this.requirements(Category.__\u003C\u003Eunits, ItemStack.with((object) Items.copper, (object) Integer.valueOf(150), (object) Items.lead, (object) Integer.valueOf(130), (object) Items.metaglass, (object) Integer.valueOf(120)));
        this.plans = Seq.with((object[]) new UnitFactory.UnitPlan[1]
        {
          new UnitFactory.UnitPlan(UnitTypes.risso, 2700f, ItemStack.with((object) Items.silicon, (object) Integer.valueOf(20), (object) Items.metaglass, (object) Integer.valueOf(35)))
        });
        this.size = 3;
        this.__\u003C\u003Econsumes.power(1.2f);
        this.floating = true;
      }

      [HideFromJava]
      static \u003181() => UnitFactory.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u003182 : Reconstructor
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {166, 214, 112, 159, 48, 103, 113, 159, 28, 139, 255, 160, 73, 72})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u003182([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u003182 obj = this;
        this.requirements(Category.__\u003C\u003Eunits, ItemStack.with((object) Items.copper, (object) Integer.valueOf(200), (object) Items.lead, (object) Integer.valueOf(120), (object) Items.silicon, (object) Integer.valueOf(90)));
        this.size = 3;
        this.__\u003C\u003Econsumes.power(3f);
        this.__\u003C\u003Econsumes.items(ItemStack.with((object) Items.silicon, (object) Integer.valueOf(40), (object) Items.graphite, (object) Integer.valueOf(40)));
        this.constructTime = 600f;
        this.upgrades.addAll((object[]) new UnitType[6][]
        {
          new UnitType[2]{ UnitTypes.nova, UnitTypes.pulsar },
          new UnitType[2]{ UnitTypes.dagger, UnitTypes.mace },
          new UnitType[2]{ UnitTypes.crawler, UnitTypes.atrax },
          new UnitType[2]{ UnitTypes.flare, UnitTypes.horizon },
          new UnitType[2]{ UnitTypes.mono, UnitTypes.poly },
          new UnitType[2]{ UnitTypes.risso, UnitTypes.minke }
        });
      }

      [HideFromJava]
      static \u003182() => Reconstructor.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u003183 : Reconstructor
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {166, 233, 112, 159, 75, 103, 113, 159, 49, 139, 255, 160, 73, 72})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u003183([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u003183 obj = this;
        this.requirements(Category.__\u003C\u003Eunits, ItemStack.with((object) Items.lead, (object) Integer.valueOf(650), (object) Items.silicon, (object) Integer.valueOf(450), (object) Items.titanium, (object) Integer.valueOf(350), (object) Items.thorium, (object) Integer.valueOf(650)));
        this.size = 5;
        this.__\u003C\u003Econsumes.power(6f);
        this.__\u003C\u003Econsumes.items(ItemStack.with((object) Items.silicon, (object) Integer.valueOf(130), (object) Items.titanium, (object) Integer.valueOf(80), (object) Items.metaglass, (object) Integer.valueOf(40)));
        this.constructTime = 1800f;
        this.upgrades.addAll((object[]) new UnitType[6][]
        {
          new UnitType[2]{ UnitTypes.horizon, UnitTypes.zenith },
          new UnitType[2]{ UnitTypes.mace, UnitTypes.fortress },
          new UnitType[2]{ UnitTypes.poly, UnitTypes.mega },
          new UnitType[2]{ UnitTypes.minke, UnitTypes.bryde },
          new UnitType[2]{ UnitTypes.pulsar, UnitTypes.quasar },
          new UnitType[2]{ UnitTypes.atrax, UnitTypes.spiroct }
        });
      }

      [HideFromJava]
      static \u003183() => Reconstructor.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u003184 : Reconstructor
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {166, 252, 112, 159, 121, 103, 113, 127, 55, 150, 107, 139, 255, 160, 73, 72})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u003184([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u003184 obj = this;
        this.requirements(Category.__\u003C\u003Eunits, ItemStack.with((object) Items.lead, (object) Integer.valueOf(2000), (object) Items.silicon, (object) Integer.valueOf(1000), (object) Items.titanium, (object) Integer.valueOf(2000), (object) Items.thorium, (object) Integer.valueOf(750), (object) Items.plastanium, (object) Integer.valueOf(450), (object) Items.phaseFabric, (object) Integer.valueOf(600)));
        this.size = 7;
        this.__\u003C\u003Econsumes.power(13f);
        this.__\u003C\u003Econsumes.items(ItemStack.with((object) Items.silicon, (object) Integer.valueOf(850), (object) Items.titanium, (object) Integer.valueOf(750), (object) Items.plastanium, (object) Integer.valueOf(650)));
        this.__\u003C\u003Econsumes.liquid(Liquids.cryofluid, 1f);
        this.constructTime = 5400f;
        this.liquidCapacity = 60f;
        this.upgrades.addAll((object[]) new UnitType[6][]
        {
          new UnitType[2]{ UnitTypes.zenith, UnitTypes.antumbra },
          new UnitType[2]{ UnitTypes.spiroct, UnitTypes.arkyid },
          new UnitType[2]{ UnitTypes.fortress, UnitTypes.scepter },
          new UnitType[2]{ UnitTypes.bryde, UnitTypes.sei },
          new UnitType[2]{ UnitTypes.mega, UnitTypes.quad },
          new UnitType[2]{ UnitTypes.quasar, UnitTypes.vela }
        });
      }

      [HideFromJava]
      static \u003184() => Reconstructor.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u003185 : Reconstructor
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {167, 17, 112, 159, 121, 104, 113, 127, 76, 150, 107, 139, 255, 160, 73, 72})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u003185([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u003185 obj = this;
        this.requirements(Category.__\u003C\u003Eunits, ItemStack.with((object) Items.lead, (object) Integer.valueOf(4000), (object) Items.silicon, (object) Integer.valueOf(3000), (object) Items.thorium, (object) Integer.valueOf(1000), (object) Items.plastanium, (object) Integer.valueOf(600), (object) Items.phaseFabric, (object) Integer.valueOf(600), (object) Items.surgeAlloy, (object) Integer.valueOf(800)));
        this.size = 9;
        this.__\u003C\u003Econsumes.power(25f);
        this.__\u003C\u003Econsumes.items(ItemStack.with((object) Items.silicon, (object) Integer.valueOf(1000), (object) Items.plastanium, (object) Integer.valueOf(600), (object) Items.surgeAlloy, (object) Integer.valueOf(500), (object) Items.phaseFabric, (object) Integer.valueOf(350)));
        this.__\u003C\u003Econsumes.liquid(Liquids.cryofluid, 3f);
        this.constructTime = 14400f;
        this.liquidCapacity = 180f;
        this.upgrades.addAll((object[]) new UnitType[6][]
        {
          new UnitType[2]{ UnitTypes.antumbra, UnitTypes.eclipse },
          new UnitType[2]{ UnitTypes.arkyid, UnitTypes.toxopid },
          new UnitType[2]{ UnitTypes.scepter, UnitTypes.reign },
          new UnitType[2]{ UnitTypes.sei, UnitTypes.omura },
          new UnitType[2]{ UnitTypes.quad, UnitTypes.oct },
          new UnitType[2]{ UnitTypes.vela, UnitTypes.corvus }
        });
      }

      [HideFromJava]
      static \u003185() => Reconstructor.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u003186 : RepairPoint
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {167, 38, 112, 127, 45, 107, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u003186([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u003186 obj = this;
        this.requirements(Category.__\u003C\u003Eunits, ItemStack.with((object) Items.lead, (object) Integer.valueOf(15), (object) Items.copper, (object) Integer.valueOf(15), (object) Items.silicon, (object) Integer.valueOf(15)));
        this.repairSpeed = 0.5f;
        this.repairRadius = 65f;
        this.powerUse = 1f;
      }

      [HideFromJava]
      static \u003186() => RepairPoint.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u003187 : ResupplyPoint
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {167, 45, 112, 159, 50, 103, 107, 104, 135, 114})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u003187([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u003187 obj = this;
        this.requirements(Category.__\u003C\u003Eunits, BuildVisibility.__\u003C\u003EammoOnly, ItemStack.with((object) Items.lead, (object) Integer.valueOf(20), (object) Items.copper, (object) Integer.valueOf(15), (object) Items.silicon, (object) Integer.valueOf(15)));
        this.size = 2;
        this.range = 80f;
        this.itemCapacity = 20;
        this.ammoAmount = 5;
        this.__\u003C\u003Econsumes.item(Items.copper, 1);
      }

      [HideFromJava]
      static \u003187() => ResupplyPoint.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u003188 : PowerSource
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {167, 59, 112, 123, 107, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u003188([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u003188 obj = this;
        this.requirements(Category.__\u003C\u003Epower, BuildVisibility.__\u003C\u003EsandboxOnly, ItemStack.with());
        this.powerProduction = 16666.67f;
        this.alwaysUnlocked = true;
      }

      [HideFromJava]
      static \u003188() => PowerSource.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u003189 : PowerVoid
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {167, 65, 112, 123, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u003189([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u003189 obj = this;
        this.requirements(Category.__\u003C\u003Epower, BuildVisibility.__\u003C\u003EsandboxOnly, ItemStack.with());
        this.alwaysUnlocked = true;
      }

      [HideFromJava]
      static \u003189() => PowerVoid.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00319 : Floor
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {160, 159, 112, 117})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00319([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u00319 obj = this;
        this.attributes.set(Attribute.__\u003C\u003Ewater, 0.1f);
      }

      [HideFromJava]
      static \u00319() => Floor.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u003190 : ItemSource
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {167, 70, 112, 123, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u003190([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u003190 obj = this;
        this.requirements(Category.__\u003C\u003Edistribution, BuildVisibility.__\u003C\u003EsandboxOnly, ItemStack.with());
        this.alwaysUnlocked = true;
      }

      [HideFromJava]
      static \u003190() => ItemSource.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u003191 : ItemVoid
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {167, 75, 112, 123, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u003191([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u003191 obj = this;
        this.requirements(Category.__\u003C\u003Edistribution, BuildVisibility.__\u003C\u003EsandboxOnly, ItemStack.with());
        this.alwaysUnlocked = true;
      }

      [HideFromJava]
      static \u003191() => ItemVoid.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u003192 : LiquidSource
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {167, 80, 112, 123, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u003192([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u003192 obj = this;
        this.requirements(Category.__\u003C\u003Eliquid, BuildVisibility.__\u003C\u003EsandboxOnly, ItemStack.with());
        this.alwaysUnlocked = true;
      }

      [HideFromJava]
      static \u003192() => LiquidSource.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u003193 : LiquidVoid
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {167, 85, 112, 123, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u003193([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u003193 obj = this;
        this.requirements(Category.__\u003C\u003Eliquid, BuildVisibility.__\u003C\u003EsandboxOnly, ItemStack.with());
        this.alwaysUnlocked = true;
      }

      [HideFromJava]
      static \u003193() => LiquidVoid.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u003194 : LightBlock
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {167, 90, 112, 127, 31, 107, 107, 113})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u003194([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u003194 obj = this;
        this.requirements(Category.__\u003C\u003Eeffect, BuildVisibility.__\u003C\u003ElightingOnly, ItemStack.with((object) Items.graphite, (object) Integer.valueOf(12), (object) Items.silicon, (object) Integer.valueOf(8)));
        this.brightness = 0.75f;
        this.radius = 120f;
        this.__\u003C\u003Econsumes.power(0.05f);
      }

      [HideFromJava]
      static \u003194() => LightBlock.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u003195 : LegacyUnitFactory
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {167, 103, 112, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u003195([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u003195 obj = this;
        this.replacement = Blocks.airFactory;
      }

      [HideFromJava]
      static \u003195() => LegacyUnitFactory.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u003196 : LegacyUnitFactory
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {167, 106, 112, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u003196([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u003196 obj = this;
        this.replacement = Blocks.groundFactory;
      }

      [HideFromJava]
      static \u003196() => LegacyUnitFactory.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u003197 : LaunchPad
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {167, 113, 112, 127, 80, 103, 104, 107, 103, 113})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u003197([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u003197 obj = this;
        this.requirements(Category.__\u003C\u003Eeffect, BuildVisibility.__\u003C\u003EcampaignOnly, ItemStack.with((object) Items.copper, (object) Integer.valueOf(350), (object) Items.silicon, (object) Integer.valueOf(140), (object) Items.lead, (object) Integer.valueOf(200), (object) Items.titanium, (object) Integer.valueOf(150)));
        this.size = 3;
        this.itemCapacity = 100;
        this.launchTime = 1200f;
        this.hasPower = true;
        this.__\u003C\u003Econsumes.power(4f);
      }

      [HideFromJava]
      static \u003197() => LaunchPad.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u003198 : LaunchPad
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {167, 123, 112, 127, 77, 103, 107, 107, 103, 113})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u003198([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u003198 obj = this;
        this.requirements(Category.__\u003C\u003Eeffect, BuildVisibility.__\u003C\u003EdebugOnly, ItemStack.with((object) Items.titanium, (object) Integer.valueOf(200), (object) Items.silicon, (object) Integer.valueOf(150), (object) Items.lead, (object) Integer.valueOf(250), (object) Items.plastanium, (object) Integer.valueOf(75)));
        this.size = 4;
        this.itemCapacity = 300;
        this.launchTime = 2100f;
        this.hasPower = true;
        this.__\u003C\u003Econsumes.power(6f);
      }

      [HideFromJava]
      static \u003198() => LaunchPad.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u003199 : Accelerator
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {167, 132, 112, 127, 126, 107, 103, 103, 113, 107, 118})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u003199([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u003199 obj = this;
        this.requirements(Category.__\u003C\u003Eeffect, BuildVisibility.__\u003C\u003EcampaignOnly, ItemStack.with((object) Items.copper, (object) Integer.valueOf(16000), (object) Items.silicon, (object) Integer.valueOf(11000), (object) Items.thorium, (object) Integer.valueOf(13000), (object) Items.titanium, (object) Integer.valueOf(12000), (object) Items.surgeAlloy, (object) Integer.valueOf(6000), (object) Items.phaseFabric, (object) Integer.valueOf(5000)));
        this.researchCostMultiplier = 0.1f;
        this.size = 7;
        this.hasPower = true;
        this.__\u003C\u003Econsumes.power(10f);
        this.buildCostMultiplier = 0.5f;
        this.health = this.size * this.size * 80;
      }

      [HideFromJava]
      static \u003199() => Accelerator.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u0032 : Floor
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {63, 112, 107, 103, 107, 107, 103, 107, 107, 107, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0032([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u0032 obj = this;
        this.speedMultiplier = 0.2f;
        this.variants = 0;
        this.liquidDrop = Liquids.water;
        this.liquidMultiplier = 1.5f;
        this.isLiquid = true;
        this.status = StatusEffects.wet;
        this.statusDuration = 120f;
        this.drownTime = 140f;
        this.cacheLayer = CacheLayer.__\u003C\u003Ewater;
        this.albedo = 0.5f;
      }

      [HideFromJava]
      static \u0032() => Floor.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00320 : Floor
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {160, 163, 112, 103, 117, 117})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00320([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u00320 obj = this;
        this.variants = 0;
        this.attributes.set(Attribute.__\u003C\u003Ewater, -0.3f);
        this.attributes.set(Attribute.__\u003C\u003Eoil, 0.3f);
      }

      [HideFromJava]
      static \u00320() => Floor.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u003200 : MessageBlock
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {167, 145, 112, 127, 8})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u003200([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u003200 obj = this;
        this.requirements(Category.__\u003C\u003Elogic, ItemStack.with((object) Items.graphite, (object) Integer.valueOf(5)));
      }

      [HideFromJava]
      static \u003200() => MessageBlock.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u003201 : SwitchBlock
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {167, 149, 112, 127, 8})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u003201([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u003201 obj = this;
        this.requirements(Category.__\u003C\u003Elogic, ItemStack.with((object) Items.graphite, (object) Integer.valueOf(5)));
      }

      [HideFromJava]
      static \u003201() => SwitchBlock.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u003202 : LogicBlock
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {167, 153, 112, 159, 45, 135, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u003202([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u003202 obj = this;
        this.requirements(Category.__\u003C\u003Elogic, ItemStack.with((object) Items.copper, (object) Integer.valueOf(80), (object) Items.lead, (object) Integer.valueOf(50), (object) Items.silicon, (object) Integer.valueOf(30)));
        this.instructionsPerTick = 2;
        this.size = 1;
      }

      [HideFromJava]
      static \u003202() => LogicBlock.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u003203 : LogicBlock
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {167, 161, 112, 159, 66, 135, 139, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u003203([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u003203 obj = this;
        this.requirements(Category.__\u003C\u003Elogic, ItemStack.with((object) Items.lead, (object) Integer.valueOf(320), (object) Items.silicon, (object) Integer.valueOf(60), (object) Items.graphite, (object) Integer.valueOf(60), (object) Items.thorium, (object) Integer.valueOf(50)));
        this.instructionsPerTick = 8;
        this.range = 176f;
        this.size = 2;
      }

      [HideFromJava]
      static \u003203() => LogicBlock.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u003204 : LogicBlock
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {167, 171, 112, 159, 69, 118, 135, 136, 139, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u003204([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u003204 obj = this;
        this.requirements(Category.__\u003C\u003Elogic, ItemStack.with((object) Items.lead, (object) Integer.valueOf(450), (object) Items.silicon, (object) Integer.valueOf(130), (object) Items.thorium, (object) Integer.valueOf(75), (object) Items.surgeAlloy, (object) Integer.valueOf(50)));
        this.__\u003C\u003Econsumes.liquid(Liquids.cryofluid, 0.08f);
        this.hasLiquids = true;
        this.instructionsPerTick = 25;
        this.range = 336f;
        this.size = 3;
      }

      [HideFromJava]
      static \u003204() => LogicBlock.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u003205 : MemoryBlock
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {167, 184, 112, 159, 27, 104})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u003205([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u003205 obj = this;
        this.requirements(Category.__\u003C\u003Elogic, ItemStack.with((object) Items.graphite, (object) Integer.valueOf(30), (object) Items.silicon, (object) Integer.valueOf(30)));
        this.memoryCapacity = 64;
      }

      [HideFromJava]
      static \u003205() => MemoryBlock.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u003206 : MemoryBlock
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {167, 190, 112, 159, 45, 107, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u003206([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u003206 obj = this;
        this.requirements(Category.__\u003C\u003Elogic, ItemStack.with((object) Items.graphite, (object) Integer.valueOf(80), (object) Items.silicon, (object) Integer.valueOf(80), (object) Items.phaseFabric, (object) Integer.valueOf(30)));
        this.memoryCapacity = 512;
        this.size = 2;
      }

      [HideFromJava]
      static \u003206() => MemoryBlock.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u003207 : LogicDisplay
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {167, 197, 112, 159, 45, 136, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u003207([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u003207 obj = this;
        this.requirements(Category.__\u003C\u003Elogic, ItemStack.with((object) Items.lead, (object) Integer.valueOf(100), (object) Items.silicon, (object) Integer.valueOf(50), (object) Items.metaglass, (object) Integer.valueOf(50)));
        this.displaySize = 80;
        this.size = 3;
      }

      [HideFromJava]
      static \u003207() => LogicDisplay.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u003208 : LogicDisplay
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {167, 205, 112, 159, 69, 139, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u003208([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u003208 obj = this;
        this.requirements(Category.__\u003C\u003Elogic, ItemStack.with((object) Items.lead, (object) Integer.valueOf(200), (object) Items.silicon, (object) Integer.valueOf(150), (object) Items.metaglass, (object) Integer.valueOf(100), (object) Items.phaseFabric, (object) Integer.valueOf(75)));
        this.displaySize = 176;
        this.size = 6;
      }

      [HideFromJava]
      static \u003208() => LogicDisplay.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u003209 : BlockForge
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {167, 216, 112, 127, 14, 103, 113, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u003209([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u003209 obj = this;
        this.requirements(Category.__\u003C\u003Ecrafting, BuildVisibility.__\u003C\u003EdebugOnly, ItemStack.with((object) Items.thorium, (object) Integer.valueOf(100)));
        this.hasPower = true;
        this.__\u003C\u003Econsumes.power(2f);
        this.size = 3;
      }

      [HideFromJava]
      static \u003209() => BlockForge.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00321 : Floor
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {160, 169, 112, 117})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00321([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u00321 obj = this;
        this.attributes.set(Attribute.__\u003C\u003Ewater, 0.2f);
      }

      [HideFromJava]
      static \u00321() => Floor.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u003210 : BlockLoader
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {167, 223, 112, 127, 14, 103, 113, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u003210([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u003210 obj = this;
        this.requirements(Category.__\u003C\u003Edistribution, BuildVisibility.__\u003C\u003EdebugOnly, ItemStack.with((object) Items.thorium, (object) Integer.valueOf(100)));
        this.hasPower = true;
        this.__\u003C\u003Econsumes.power(2f);
        this.size = 3;
      }

      [HideFromJava]
      static \u003210() => BlockLoader.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u003211 : BlockUnloader
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {167, 230, 112, 127, 14, 103, 113, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u003211([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u003211 obj = this;
        this.requirements(Category.__\u003C\u003Edistribution, BuildVisibility.__\u003C\u003EdebugOnly, ItemStack.with((object) Items.thorium, (object) Integer.valueOf(100)));
        this.hasPower = true;
        this.__\u003C\u003Econsumes.power(2f);
        this.size = 3;
      }

      [HideFromJava]
      static \u003211() => BlockUnloader.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00322 : Floor
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {160, 173, 112, 107, 107, 117})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00322([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u00322 obj = this;
        this.dragMultiplier = 0.35f;
        this.speedMultiplier = 0.9f;
        this.attributes.set(Attribute.__\u003C\u003Ewater, 0.4f);
      }

      [HideFromJava]
      static \u00322() => Floor.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00323 : Floor
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {160, 179, 112, 107, 103, 117})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00323([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u00323 obj = this;
        this.dragMultiplier = 0.6f;
        this.variants = 3;
        this.attributes.set(Attribute.__\u003C\u003Ewater, 0.3f);
      }

      [HideFromJava]
      static \u00323() => Floor.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00324 : Floor
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {160, 185, 112, 103, 117})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00324([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u00324 obj = this;
        this.variants = 3;
        this.attributes.set(Attribute.__\u003C\u003Eoil, 1f);
      }

      [HideFromJava]
      static \u00324() => Floor.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00325 : StaticWall
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {160, 190, 112, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00325([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u00325 obj = this;
        this.variants = 2;
      }

      [HideFromJava]
      static \u00325() => StaticWall.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00326 : StaticWall
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {160, 194, 112, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00326([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u00326 obj = this;
        this.variants = 2;
      }

      [HideFromJava]
      static \u00326() => StaticWall.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00327 : StaticWall
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {160, 198, 112, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00327([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u00327 obj = this;
        this.variants = 2;
      }

      [HideFromJava]
      static \u00327() => StaticWall.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00328 : StaticWall
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {160, 202, 112, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00328([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u00328 obj = this;
        this.variants = 2;
      }

      [HideFromJava]
      static \u00328() => StaticWall.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00329 : StaticWall
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {160, 206, 112, 103, 112})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00329([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u00329 obj = this;
        this.variants = 2;
        Blocks.iceSnow.asFloor().wall = (Block) this;
      }

      [HideFromJava]
      static \u00329() => StaticWall.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u0033 : Floor
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {76, 112, 107, 103, 107, 107, 107, 103, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0033([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u0033 obj = this;
        this.speedMultiplier = 0.5f;
        this.variants = 0;
        this.status = StatusEffects.wet;
        this.statusDuration = 90f;
        this.liquidDrop = Liquids.water;
        this.isLiquid = true;
        this.cacheLayer = CacheLayer.__\u003C\u003Ewater;
        this.albedo = 0.5f;
      }

      [HideFromJava]
      static \u0033() => Floor.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00330 : StaticWall
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {160, 211, 112, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00330([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u00330 obj = this;
        this.variants = 2;
      }

      [HideFromJava]
      static \u00330() => StaticWall.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00331 : StaticWall
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {160, 215, 112, 103, 127, 25})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00331([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u00331 obj2 = this;
        this.variants = 2;
        Floor floor1 = Blocks.basalt.asFloor();
        Floor floor2 = Blocks.darksandWater.asFloor();
        Floor floor3 = Blocks.darksandTaintedWater.asFloor();
        Blocks.\u00331 obj3 = this;
        floor3.wall = (Block) this;
        Blocks.\u00331 obj4 = this;
        Floor floor4 = floor2;
        Blocks.\u00331 obj5 = obj4;
        floor4.wall = (Block) obj4;
        floor1.wall = (Block) obj5;
      }

      [HideFromJava]
      static \u00331() => StaticWall.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00332 : StaticWall
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {160, 220, 112, 103, 127, 25})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00332([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u00332 obj2 = this;
        this.variants = 2;
        Floor floor1 = Blocks.sandWater.asFloor();
        Floor floor2 = Blocks.water.asFloor();
        Floor floor3 = Blocks.deepwater.asFloor();
        Blocks.\u00332 obj3 = this;
        floor3.wall = (Block) this;
        Blocks.\u00332 obj4 = this;
        Floor floor4 = floor2;
        Blocks.\u00332 obj5 = obj4;
        floor4.wall = (Block) obj4;
        floor1.wall = (Block) obj5;
      }

      [HideFromJava]
      static \u00332() => StaticWall.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00333 : StaticWall
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {160, 229, 112, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00333([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u00333 obj = this;
        this.variants = 2;
      }

      [HideFromJava]
      static \u00333() => StaticWall.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00334 : StaticTree
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {160, 233, 112, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00334([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u00334 obj = this;
        this.variants = 0;
      }

      [HideFromJava]
      static \u00334() => StaticTree.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00335 : StaticTree
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {160, 237, 112, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00335([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u00335 obj = this;
        this.variants = 0;
      }

      [HideFromJava]
      static \u00335() => StaticTree.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00336 : StaticTree
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {160, 241, 112, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00336([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u00336 obj = this;
        this.variants = 0;
      }

      [HideFromJava]
      static \u00336() => StaticTree.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00337 : Boulder
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {160, 249, 112, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00337([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u00337 obj = this;
        this.variants = 3;
      }

      [HideFromJava]
      static \u00337() => Boulder.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00338 : Boulder
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {160, 253, 112, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00338([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u00338 obj = this;
        this.variants = 2;
      }

      [HideFromJava]
      static \u00338() => Boulder.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00339 : Boulder
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {161, 1, 112, 103, 127, 45})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00339([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u00339 obj2 = this;
        this.variants = 2;
        Floor floor1 = Blocks.snow.asFloor();
        Floor floor2 = Blocks.ice.asFloor();
        Floor floor3 = Blocks.iceSnow.asFloor();
        Floor floor4 = Blocks.salt.asFloor();
        Blocks.\u00339 obj3 = this;
        floor4.decoration = (Block) this;
        Blocks.\u00339 obj4 = this;
        Floor floor5 = floor3;
        Blocks.\u00339 obj5 = obj4;
        floor5.decoration = (Block) obj4;
        Blocks.\u00339 obj6 = obj5;
        Floor floor6 = floor2;
        Blocks.\u00339 obj7 = obj6;
        floor6.decoration = (Block) obj6;
        floor1.decoration = (Block) obj7;
      }

      [HideFromJava]
      static \u00339() => Boulder.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u0034 : Floor
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {87, 112, 107, 103, 107, 107, 107, 107, 103, 107, 107, 117})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0034([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u0034 obj = this;
        this.speedMultiplier = 0.17f;
        this.variants = 0;
        this.status = StatusEffects.wet;
        this.statusDuration = 140f;
        this.drownTime = 120f;
        this.liquidDrop = Liquids.water;
        this.isLiquid = true;
        this.cacheLayer = CacheLayer.__\u003C\u003Ewater;
        this.albedo = 0.5f;
        this.attributes.set(Attribute.__\u003C\u003Espores, 0.15f);
      }

      [HideFromJava]
      static \u0034() => Floor.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00340 : Boulder
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {161, 6, 112, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00340([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u00340 obj = this;
        this.variants = 2;
      }

      [HideFromJava]
      static \u00340() => Boulder.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00341 : Boulder
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {161, 10, 112, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00341([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u00341 obj = this;
        this.variants = 2;
      }

      [HideFromJava]
      static \u00341() => Boulder.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00342 : Boulder
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {161, 14, 112, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00342([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u00342 obj = this;
        this.variants = 2;
      }

      [HideFromJava]
      static \u00342() => Boulder.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00343 : Boulder
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {161, 18, 112, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00343([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u00343 obj = this;
        this.variants = 2;
      }

      [HideFromJava]
      static \u00343() => Boulder.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00344 : Floor
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {161, 22, 112, 103, 117, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00344([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u00344 obj = this;
        this.variants = 3;
        this.attributes.set(Attribute.__\u003C\u003Espores, 0.15f);
        this.wall = Blocks.sporePine;
      }

      [HideFromJava]
      static \u00344() => Floor.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00345 : Floor
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {161, 28, 112, 103, 117, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00345([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u00345 obj = this;
        this.variants = 3;
        this.attributes.set(Attribute.__\u003C\u003Espores, 0.3f);
        this.wall = Blocks.sporeWall;
      }

      [HideFromJava]
      static \u00345() => Floor.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00346 : Floor
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {161, 34, 112, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00346([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u00346 obj = this;
        this.variants = 0;
      }

      [HideFromJava]
      static \u00346() => Floor.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00347 : Floor
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {161, 38, 112, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00347([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u00347 obj = this;
        this.variants = 3;
      }

      [HideFromJava]
      static \u00347() => Floor.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00348 : Floor
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {161, 42, 112, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00348([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u00348 obj = this;
        this.variants = 0;
      }

      [HideFromJava]
      static \u00348() => Floor.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00349 : Floor
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {161, 46, 112, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00349([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u00349 obj = this;
        this.variants = 0;
      }

      [HideFromJava]
      static \u00349() => Floor.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u0035 : ShallowLiquid
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {100, 112, 107, 107, 107, 117})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0035([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u0035 obj = this;
        this.speedMultiplier = 0.75f;
        this.statusDuration = 60f;
        this.albedo = 0.5f;
        this.attributes.set(Attribute.__\u003C\u003Espores, 0.1f);
      }

      [HideFromJava]
      static \u0035() => ShallowLiquid.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00350 : Floor
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {161, 50, 112, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00350([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u00350 obj = this;
        this.variants = 0;
      }

      [HideFromJava]
      static \u00350() => Floor.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00351 : Floor
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(424)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00351([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u00351 obj = this;
        this.variants = 0;
      }

      [HideFromJava]
      static \u00351() => Floor.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00352 : Floor
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(425)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00352([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u00352 obj = this;
        this.variants = 0;
      }

      [HideFromJava]
      static \u00352() => Floor.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00353 : Floor
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(426)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00353([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u00353 obj = this;
        this.variants = 0;
      }

      [HideFromJava]
      static \u00353() => Floor.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00354 : Floor
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(427)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00354([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u00354 obj = this;
        this.variants = 0;
      }

      [HideFromJava]
      static \u00354() => Floor.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00355 : Floor
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(428)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00355([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u00355 obj = this;
        this.variants = 0;
      }

      [HideFromJava]
      static \u00355() => Floor.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00356 : Floor
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(429)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00356([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u00356 obj = this;
        this.variants = 0;
      }

      [HideFromJava]
      static \u00356() => Floor.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00357 : OreBlock
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {161, 70, 112, 103, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00357([In] Blocks obj0, [In] Item obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u00357 obj = this;
        this.oreDefault = true;
        this.oreThreshold = 0.81f;
        this.oreScale = 23.47619f;
      }

      [HideFromJava]
      static \u00357() => OreBlock.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00358 : OreBlock
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {161, 76, 112, 103, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00358([In] Blocks obj0, [In] Item obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u00358 obj = this;
        this.oreDefault = true;
        this.oreThreshold = 0.828f;
        this.oreScale = 23.95238f;
      }

      [HideFromJava]
      static \u00358() => OreBlock.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00359 : OreBlock
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {161, 84, 112, 103, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00359([In] Blocks obj0, [In] Item obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u00359 obj = this;
        this.oreDefault = true;
        this.oreThreshold = 0.846f;
        this.oreScale = 24.42857f;
      }

      [HideFromJava]
      static \u00359() => OreBlock.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u0036 : ShallowLiquid
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {107, 112, 107, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0036([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u0036 obj = this;
        this.speedMultiplier = 0.8f;
        this.statusDuration = 50f;
        this.albedo = 0.5f;
      }

      [HideFromJava]
      static \u0036() => ShallowLiquid.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00360 : OreBlock
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {161, 90, 112, 103, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00360([In] Blocks obj0, [In] Item obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u00360 obj = this;
        this.oreDefault = true;
        this.oreThreshold = 0.864f;
        this.oreScale = 24.90476f;
      }

      [HideFromJava]
      static \u00360() => OreBlock.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00361 : OreBlock
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {161, 96, 112, 103, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00361([In] Blocks obj0, [In] Item obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u00361 obj = this;
        this.oreDefault = true;
        this.oreThreshold = 0.882f;
        this.oreScale = 25.38095f;
      }

      [HideFromJava]
      static \u00361() => OreBlock.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00362 : GenericCrafter
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {161, 105, 112, 159, 27, 107, 118, 107, 103, 135, 114})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00362([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u00362 obj = this;
        this.requirements(Category.__\u003C\u003Ecrafting, ItemStack.with((object) Items.copper, (object) Integer.valueOf(75), (object) Items.lead, (object) Integer.valueOf(30)));
        this.craftEffect = Fx.__\u003C\u003EpulverizeMedium;
        ItemStack.__\u003Cclinit\u003E();
        this.outputItem = new ItemStack(Items.graphite, 1);
        this.craftTime = 90f;
        this.size = 2;
        this.hasItems = true;
        this.__\u003C\u003Econsumes.item(Items.coal, 2);
      }

      [HideFromJava]
      static \u00362() => GenericCrafter.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00363 : GenericCrafter
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {161, 117, 112, 159, 63, 107, 118, 107, 103, 103, 103, 135, 113, 114, 118})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00363([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u00363 obj = this;
        this.requirements(Category.__\u003C\u003Ecrafting, ItemStack.with((object) Items.titanium, (object) Integer.valueOf(100), (object) Items.silicon, (object) Integer.valueOf(25), (object) Items.lead, (object) Integer.valueOf(100), (object) Items.graphite, (object) Integer.valueOf(50)));
        this.craftEffect = Fx.__\u003C\u003EpulverizeMedium;
        ItemStack.__\u003Cclinit\u003E();
        this.outputItem = new ItemStack(Items.graphite, 2);
        this.craftTime = 30f;
        this.size = 3;
        this.hasItems = true;
        this.hasLiquids = true;
        this.hasPower = true;
        this.__\u003C\u003Econsumes.power(1.8f);
        this.__\u003C\u003Econsumes.item(Items.coal, 3);
        this.__\u003C\u003Econsumes.liquid(Liquids.water, 0.1f);
      }

      [HideFromJava]
      static \u00363() => GenericCrafter.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00364 : GenericSmelter
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {161, 133, 112, 127, 27, 107, 118, 107, 103, 103, 103, 144, 127, 26, 113})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00364([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u00364 obj = this;
        this.requirements(Category.__\u003C\u003Ecrafting, ItemStack.with((object) Items.copper, (object) Integer.valueOf(30), (object) Items.lead, (object) Integer.valueOf(25)));
        this.craftEffect = Fx.__\u003C\u003Esmeltsmoke;
        ItemStack.__\u003Cclinit\u003E();
        this.outputItem = new ItemStack(Items.silicon, 1);
        this.craftTime = 40f;
        this.size = 2;
        this.hasPower = true;
        this.hasLiquids = false;
        this.flameColor = Color.valueOf("ffef99");
        this.__\u003C\u003Econsumes.items(ItemStack.with((object) Items.coal, (object) Integer.valueOf(1), (object) Items.sand, (object) Integer.valueOf(2)));
        this.__\u003C\u003Econsumes.power(0.5f);
      }

      [HideFromJava]
      static \u00364() => GenericSmelter.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00365 : AttributeSmelter
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {161, 147, 112, 127, 63, 107, 118, 107, 103, 103, 103, 112, 104, 139, 127, 43, 113})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00365([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u00365 obj = this;
        this.requirements(Category.__\u003C\u003Ecrafting, ItemStack.with((object) Items.titanium, (object) Integer.valueOf(120), (object) Items.metaglass, (object) Integer.valueOf(80), (object) Items.plastanium, (object) Integer.valueOf(35), (object) Items.silicon, (object) Integer.valueOf(60)));
        this.craftEffect = Fx.__\u003C\u003Esmeltsmoke;
        ItemStack.__\u003Cclinit\u003E();
        this.outputItem = new ItemStack(Items.silicon, 8);
        this.craftTime = 90f;
        this.size = 3;
        this.hasPower = true;
        this.hasLiquids = false;
        this.flameColor = Color.valueOf("ffef99");
        this.itemCapacity = 30;
        this.boostScale = 0.15f;
        this.__\u003C\u003Econsumes.items(ItemStack.with((object) Items.coal, (object) Integer.valueOf(4), (object) Items.sand, (object) Integer.valueOf(6), (object) Items.pyratite, (object) Integer.valueOf(1)));
        this.__\u003C\u003Econsumes.power(4f);
      }

      [HideFromJava]
      static \u00365() => AttributeSmelter.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00366 : GenericSmelter
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {161, 163, 112, 127, 45, 107, 118, 107, 103, 114, 144, 127, 26, 113})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00366([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u00366 obj2 = this;
        this.requirements(Category.__\u003C\u003Ecrafting, ItemStack.with((object) Items.copper, (object) Integer.valueOf(60), (object) Items.graphite, (object) Integer.valueOf(30), (object) Items.lead, (object) Integer.valueOf(30)));
        this.craftEffect = Fx.__\u003C\u003Esmeltsmoke;
        ItemStack.__\u003Cclinit\u003E();
        this.outputItem = new ItemStack(Items.metaglass, 1);
        this.craftTime = 30f;
        this.size = 2;
        Blocks.\u00366 obj3 = this;
        int num1 = 1;
        int num2 = num1;
        this.hasItems = num1 != 0;
        this.hasPower = num2 != 0;
        this.flameColor = Color.valueOf("ffc099");
        this.__\u003C\u003Econsumes.items(ItemStack.with((object) Items.lead, (object) Integer.valueOf(1), (object) Items.sand, (object) Integer.valueOf(1)));
        this.__\u003C\u003Econsumes.power(0.6f);
      }

      [HideFromJava]
      static \u00366() => GenericSmelter.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00367 : GenericCrafter
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {161, 176, 112, 127, 63, 103, 107, 107, 118, 103, 107, 114, 107, 107, 139, 118, 113, 114})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00367([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u00367 obj2 = this;
        this.requirements(Category.__\u003C\u003Ecrafting, ItemStack.with((object) Items.silicon, (object) Integer.valueOf(80), (object) Items.lead, (object) Integer.valueOf(115), (object) Items.graphite, (object) Integer.valueOf(60), (object) Items.titanium, (object) Integer.valueOf(80)));
        this.hasItems = true;
        this.liquidCapacity = 60f;
        this.craftTime = 60f;
        ItemStack.__\u003Cclinit\u003E();
        this.outputItem = new ItemStack(Items.plastanium, 1);
        this.size = 2;
        this.health = 320;
        Blocks.\u00367 obj3 = this;
        int num1 = 1;
        int num2 = num1;
        this.hasLiquids = num1 != 0;
        this.hasPower = num2 != 0;
        this.craftEffect = Fx.__\u003C\u003Eformsmoke;
        this.updateEffect = Fx.__\u003C\u003Eplasticburn;
        this.drawer = (DrawBlock) new DrawGlow();
        this.__\u003C\u003Econsumes.liquid(Liquids.oil, 0.25f);
        this.__\u003C\u003Econsumes.power(3f);
        this.__\u003C\u003Econsumes.item(Items.titanium, 2);
      }

      [HideFromJava]
      static \u00367() => GenericCrafter.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00368 : GenericCrafter
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {161, 194, 112, 127, 48, 107, 118, 107, 103, 103, 139, 107, 139, 127, 27, 113, 104})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00368([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u00368 obj = this;
        this.requirements(Category.__\u003C\u003Ecrafting, ItemStack.with((object) Items.silicon, (object) Integer.valueOf(130), (object) Items.lead, (object) Integer.valueOf(120), (object) Items.thorium, (object) Integer.valueOf(75)));
        this.craftEffect = Fx.__\u003C\u003Esmeltsmoke;
        ItemStack.__\u003Cclinit\u003E();
        this.outputItem = new ItemStack(Items.phaseFabric, 1);
        this.craftTime = 120f;
        this.size = 2;
        this.hasPower = true;
        this.drawer = (DrawBlock) new DrawWeave();
        this.ambientSound = Sounds.techloop;
        this.ambientSoundVolume = 0.02f;
        this.__\u003C\u003Econsumes.items(ItemStack.with((object) Items.thorium, (object) Integer.valueOf(4), (object) Items.sand, (object) Integer.valueOf(10)));
        this.__\u003C\u003Econsumes.power(5f);
        this.itemCapacity = 20;
      }

      [HideFromJava]
      static \u00368() => GenericCrafter.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00369 : GenericSmelter
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {161, 211, 112, 127, 45, 107, 118, 107, 103, 103, 136, 113, 127, 60})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00369([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u00369 obj = this;
        this.requirements(Category.__\u003C\u003Ecrafting, ItemStack.with((object) Items.silicon, (object) Integer.valueOf(80), (object) Items.lead, (object) Integer.valueOf(80), (object) Items.thorium, (object) Integer.valueOf(70)));
        this.craftEffect = Fx.__\u003C\u003Esmeltsmoke;
        ItemStack.__\u003Cclinit\u003E();
        this.outputItem = new ItemStack(Items.surgeAlloy, 1);
        this.craftTime = 75f;
        this.size = 3;
        this.hasPower = true;
        this.itemCapacity = 20;
        this.__\u003C\u003Econsumes.power(4f);
        this.__\u003C\u003Econsumes.items(ItemStack.with((object) Items.copper, (object) Integer.valueOf(3), (object) Items.lead, (object) Integer.valueOf(4), (object) Items.titanium, (object) Integer.valueOf(2), (object) Items.silicon, (object) Integer.valueOf(3)));
      }

      [HideFromJava]
      static \u00369() => GenericSmelter.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u0037 : ShallowLiquid
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {113, 112, 107, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0037([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u0037 obj = this;
        this.speedMultiplier = 0.8f;
        this.statusDuration = 50f;
        this.albedo = 0.5f;
      }

      [HideFromJava]
      static \u0037() => ShallowLiquid.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00370 : LiquidConverter
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {161, 224, 112, 127, 45, 117, 107, 103, 103, 103, 103, 103, 103, 103, 139, 113, 113, 118})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00370([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u00370 obj = this;
        this.requirements(Category.__\u003C\u003Ecrafting, ItemStack.with((object) Items.lead, (object) Integer.valueOf(65), (object) Items.silicon, (object) Integer.valueOf(40), (object) Items.titanium, (object) Integer.valueOf(60)));
        this.outputLiquid = new LiquidStack(Liquids.cryofluid, 0.2f);
        this.craftTime = 120f;
        this.size = 2;
        this.hasPower = true;
        this.hasItems = true;
        this.hasLiquids = true;
        this.rotate = false;
        this.solid = true;
        this.outputsLiquid = true;
        this.drawer = (DrawBlock) new DrawMixer();
        this.__\u003C\u003Econsumes.power(1f);
        this.__\u003C\u003Econsumes.item(Items.titanium);
        this.__\u003C\u003Econsumes.liquid(Liquids.water, 0.2f);
      }

      [HideFromJava]
      static \u00370() => LiquidConverter.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00371 : GenericSmelter
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {161, 242, 112, 127, 27, 107, 103, 103, 150, 135, 113, 127, 43})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00371([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u00371 obj = this;
        this.requirements(Category.__\u003C\u003Ecrafting, ItemStack.with((object) Items.copper, (object) Integer.valueOf(50), (object) Items.lead, (object) Integer.valueOf(25)));
        this.flameColor = Color.__\u003C\u003Eclear;
        this.hasItems = true;
        this.hasPower = true;
        ItemStack.__\u003Cclinit\u003E();
        this.outputItem = new ItemStack(Items.pyratite, 1);
        this.size = 2;
        this.__\u003C\u003Econsumes.power(0.2f);
        this.__\u003C\u003Econsumes.items(ItemStack.with((object) Items.coal, (object) Integer.valueOf(1), (object) Items.lead, (object) Integer.valueOf(2), (object) Items.sand, (object) Integer.valueOf(2)));
      }

      [HideFromJava]
      static \u00371() => GenericSmelter.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00372 : GenericCrafter
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {161, 255, 112, 127, 27, 103, 103, 118, 135, 127, 26, 113})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00372([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u00372 obj = this;
        this.requirements(Category.__\u003C\u003Ecrafting, ItemStack.with((object) Items.lead, (object) Integer.valueOf(30), (object) Items.titanium, (object) Integer.valueOf(20)));
        this.hasItems = true;
        this.hasPower = true;
        ItemStack.__\u003Cclinit\u003E();
        this.outputItem = new ItemStack(Items.blastCompound, 1);
        this.size = 2;
        this.__\u003C\u003Econsumes.items(ItemStack.with((object) Items.pyratite, (object) Integer.valueOf(1), (object) Items.sporePod, (object) Integer.valueOf(1)));
        this.__\u003C\u003Econsumes.power(0.4f);
      }

      [HideFromJava]
      static \u00372() => GenericCrafter.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00373 : GenericCrafter
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {162, 10, 112, 127, 45, 107, 117, 107, 146, 113, 114})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00373([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u00373 obj2 = this;
        this.requirements(Category.__\u003C\u003Ecrafting, ItemStack.with((object) Items.copper, (object) Integer.valueOf(30), (object) Items.lead, (object) Integer.valueOf(35), (object) Items.graphite, (object) Integer.valueOf(45)));
        this.health = 200;
        this.outputLiquid = new LiquidStack(Liquids.slag, 2f);
        this.craftTime = 10f;
        Blocks.\u00373 obj3 = this;
        int num1 = 1;
        int num2 = num1;
        this.hasPower = num1 != 0;
        this.hasLiquids = num2 != 0;
        this.__\u003C\u003Econsumes.power(1f);
        this.__\u003C\u003Econsumes.item(Items.scrap, 1);
      }

      [HideFromJava]
      static \u00373() => GenericCrafter.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00374 : Separator
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {162, 21, 112, 127, 27, 114, 113, 113, 113, 230, 60, 234, 70, 103, 107, 135, 113, 118})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00374([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u00374 obj = this;
        this.requirements(Category.__\u003C\u003Ecrafting, ItemStack.with((object) Items.copper, (object) Integer.valueOf(30), (object) Items.titanium, (object) Integer.valueOf(25)));
        this.results = ItemStack.with((object) Items.copper, (object) Integer.valueOf(5), (object) Items.lead, (object) Integer.valueOf(3), (object) Items.graphite, (object) Integer.valueOf(2), (object) Items.titanium, (object) Integer.valueOf(2));
        this.hasPower = true;
        this.craftTime = 35f;
        this.size = 2;
        this.__\u003C\u003Econsumes.power(1f);
        this.__\u003C\u003Econsumes.liquid(Liquids.slag, 0.07f);
      }

      [HideFromJava]
      static \u00374() => Separator.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00375 : Separator
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {162, 37, 112, 127, 69, 114, 113, 113, 113, 230, 60, 234, 70, 103, 107, 103, 136, 113, 113, 118})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00375([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u00375 obj = this;
        this.requirements(Category.__\u003C\u003Ecrafting, ItemStack.with((object) Items.graphite, (object) Integer.valueOf(140), (object) Items.titanium, (object) Integer.valueOf(100), (object) Items.silicon, (object) Integer.valueOf(150), (object) Items.surgeAlloy, (object) Integer.valueOf(70)));
        this.results = ItemStack.with((object) Items.sand, (object) Integer.valueOf(4), (object) Items.graphite, (object) Integer.valueOf(2), (object) Items.titanium, (object) Integer.valueOf(2), (object) Items.thorium, (object) Integer.valueOf(1));
        this.hasPower = true;
        this.craftTime = 15f;
        this.size = 3;
        this.itemCapacity = 20;
        this.__\u003C\u003Econsumes.power(4f);
        this.__\u003C\u003Econsumes.item(Items.scrap);
        this.__\u003C\u003Econsumes.liquid(Liquids.slag, 0.12f);
      }

      [HideFromJava]
      static \u00375() => Separator.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00376 : GenericCrafter
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {162, 55, 112, 127, 27, 107, 107, 117, 103, 107, 103, 103, 107, 139, 114, 113})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00376([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u00376 obj = this;
        this.requirements(Category.__\u003C\u003Ecrafting, ItemStack.with((object) Items.lead, (object) Integer.valueOf(35), (object) Items.silicon, (object) Integer.valueOf(30)));
        this.liquidCapacity = 60f;
        this.craftTime = 20f;
        this.outputLiquid = new LiquidStack(Liquids.oil, 6f);
        this.size = 2;
        this.health = 320;
        this.hasLiquids = true;
        this.hasPower = true;
        this.craftEffect = Fx.__\u003C\u003Enone;
        this.drawer = (DrawBlock) new DrawAnimation();
        this.__\u003C\u003Econsumes.item(Items.sporePod, 1);
        this.__\u003C\u003Econsumes.power(0.7f);
      }

      [HideFromJava]
      static \u00376() => GenericCrafter.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00377 : GenericCrafter
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {162, 71, 112, 127, 27, 118, 107, 107, 107, 114, 107, 107, 139, 114, 113})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00377([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u00377 obj2 = this;
        this.requirements(Category.__\u003C\u003Ecrafting, ItemStack.with((object) Items.copper, (object) Integer.valueOf(30), (object) Items.lead, (object) Integer.valueOf(25)));
        ItemStack.__\u003Cclinit\u003E();
        this.outputItem = new ItemStack(Items.sand, 1);
        this.craftEffect = Fx.__\u003C\u003Epulverize;
        this.craftTime = 40f;
        this.updateEffect = Fx.__\u003C\u003EpulverizeSmall;
        Blocks.\u00377 obj3 = this;
        int num1 = 1;
        int num2 = num1;
        this.hasPower = num1 != 0;
        this.hasItems = num2 != 0;
        this.drawer = (DrawBlock) new DrawRotator();
        this.ambientSound = Sounds.grinding;
        this.ambientSoundVolume = 0.025f;
        this.__\u003C\u003Econsumes.item(Items.scrap, 1);
        this.__\u003C\u003Econsumes.power(0.5f);
      }

      [HideFromJava]
      static \u00377() => GenericCrafter.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00378 : GenericCrafter
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {162, 86, 112, 127, 45, 107, 118, 107, 103, 157, 118, 113})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00378([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u00378 obj2 = this;
        this.requirements(Category.__\u003C\u003Ecrafting, ItemStack.with((object) Items.titanium, (object) Integer.valueOf(20), (object) Items.graphite, (object) Integer.valueOf(40), (object) Items.lead, (object) Integer.valueOf(30)));
        this.craftEffect = Fx.__\u003C\u003Esmeltsmoke;
        ItemStack.__\u003Cclinit\u003E();
        this.outputItem = new ItemStack(Items.coal, 1);
        this.craftTime = 30f;
        this.size = 2;
        Blocks.\u00378 obj3 = this;
        Blocks.\u00378 obj4 = this;
        int num1 = 1;
        int num2 = num1;
        this.hasLiquids = num1 != 0;
        int num3 = num2;
        int num4 = num3;
        this.hasItems = num3 != 0;
        this.hasPower = num4 != 0;
        this.__\u003C\u003Econsumes.liquid(Liquids.oil, 0.1f);
        this.__\u003C\u003Econsumes.power(0.7f);
      }

      [HideFromJava]
      static \u00378() => GenericCrafter.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00379 : Incinerator
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {162, 98, 112, 127, 26, 104, 113})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00379([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u00379 obj = this;
        this.requirements(Category.__\u003C\u003Ecrafting, ItemStack.with((object) Items.graphite, (object) Integer.valueOf(5), (object) Items.lead, (object) Integer.valueOf(15)));
        this.health = 90;
        this.__\u003C\u003Econsumes.power(0.5f);
      }

      [HideFromJava]
      static \u00379() => Incinerator.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u0038 : Floor
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {119, 112, 107, 107, 107, 107, 103, 107, 103, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0038([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u0038 obj = this;
        this.drownTime = 150f;
        this.status = StatusEffects.tarred;
        this.statusDuration = 240f;
        this.speedMultiplier = 0.19f;
        this.variants = 0;
        this.liquidDrop = Liquids.oil;
        this.isLiquid = true;
        this.cacheLayer = CacheLayer.__\u003C\u003Etar;
      }

      [HideFromJava]
      static \u0038() => Floor.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00380 : Wall
    {
      [Modifiers]
      internal int val\u0024wallHealthMultiplier;
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {162, 109, 119, 127, 8, 111})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00380([In] Blocks obj0, [In] string obj1, [In] int obj2)
      {
        this.this\u00240 = obj0;
        this.val\u0024wallHealthMultiplier = obj2;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u00380 obj = this;
        this.requirements(Category.__\u003C\u003Edefense, ItemStack.with((object) Items.copper, (object) Integer.valueOf(6)));
        this.health = 80 * this.val\u0024wallHealthMultiplier;
      }

      [HideFromJava]
      static \u00380() => Wall.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00381 : Wall
    {
      [Modifiers]
      internal int val\u0024wallHealthMultiplier;
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {162, 114, 119, 127, 0, 114, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00381([In] Blocks obj0, [In] string obj1, [In] int obj2)
      {
        this.this\u00240 = obj0;
        this.val\u0024wallHealthMultiplier = obj2;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u00381 obj = this;
        this.requirements(Category.__\u003C\u003Edefense, ItemStack.mult(Blocks.copperWall.requirements, 4f));
        this.health = 320 * this.val\u0024wallHealthMultiplier;
        this.size = 2;
      }

      [HideFromJava]
      static \u00381() => Wall.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00382 : Wall
    {
      [Modifiers]
      internal int val\u0024wallHealthMultiplier;
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {162, 120, 119, 127, 8, 111})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00382([In] Blocks obj0, [In] string obj1, [In] int obj2)
      {
        this.this\u00240 = obj0;
        this.val\u0024wallHealthMultiplier = obj2;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u00382 obj = this;
        this.requirements(Category.__\u003C\u003Edefense, ItemStack.with((object) Items.titanium, (object) Integer.valueOf(6)));
        this.health = 110 * this.val\u0024wallHealthMultiplier;
      }

      [HideFromJava]
      static \u00382() => Wall.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00383 : Wall
    {
      [Modifiers]
      internal int val\u0024wallHealthMultiplier;
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {162, 125, 119, 127, 0, 113, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00383([In] Blocks obj0, [In] string obj1, [In] int obj2)
      {
        this.this\u00240 = obj0;
        this.val\u0024wallHealthMultiplier = obj2;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u00383 obj = this;
        this.requirements(Category.__\u003C\u003Edefense, ItemStack.mult(Blocks.titaniumWall.requirements, 4f));
        this.health = 110 * this.val\u0024wallHealthMultiplier * 4;
        this.size = 2;
      }

      [HideFromJava]
      static \u00383() => Wall.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00384 : Wall
    {
      [Modifiers]
      internal int val\u0024wallHealthMultiplier;
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {162, 131, 119, 127, 25, 114, 103, 103, 104})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00384([In] Blocks obj0, [In] string obj1, [In] int obj2)
      {
        this.this\u00240 = obj0;
        this.val\u0024wallHealthMultiplier = obj2;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u00384 obj = this;
        this.requirements(Category.__\u003C\u003Edefense, ItemStack.with((object) Items.plastanium, (object) Integer.valueOf(5), (object) Items.metaglass, (object) Integer.valueOf(2)));
        this.health = 130 * this.val\u0024wallHealthMultiplier;
        this.insulated = true;
        this.absorbLasers = true;
        this.schematicPriority = 10;
      }

      [HideFromJava]
      static \u00384() => Wall.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00385 : Wall
    {
      [Modifiers]
      internal int val\u0024wallHealthMultiplier;
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {162, 139, 119, 127, 0, 116, 103, 103, 103, 104})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00385([In] Blocks obj0, [In] string obj1, [In] int obj2)
      {
        this.this\u00240 = obj0;
        this.val\u0024wallHealthMultiplier = obj2;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u00385 obj = this;
        this.requirements(Category.__\u003C\u003Edefense, ItemStack.mult(Blocks.plastaniumWall.requirements, 4f));
        this.health = 130 * this.val\u0024wallHealthMultiplier * 4;
        this.size = 2;
        this.insulated = true;
        this.absorbLasers = true;
        this.schematicPriority = 10;
      }

      [HideFromJava]
      static \u00385() => Wall.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00386 : Wall
    {
      [Modifiers]
      internal int val\u0024wallHealthMultiplier;
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {162, 148, 119, 127, 8, 114})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00386([In] Blocks obj0, [In] string obj1, [In] int obj2)
      {
        this.this\u00240 = obj0;
        this.val\u0024wallHealthMultiplier = obj2;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u00386 obj = this;
        this.requirements(Category.__\u003C\u003Edefense, ItemStack.with((object) Items.thorium, (object) Integer.valueOf(6)));
        this.health = 200 * this.val\u0024wallHealthMultiplier;
      }

      [HideFromJava]
      static \u00386() => Wall.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00387 : Wall
    {
      [Modifiers]
      internal int val\u0024wallHealthMultiplier;
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {162, 153, 119, 127, 0, 116, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00387([In] Blocks obj0, [In] string obj1, [In] int obj2)
      {
        this.this\u00240 = obj0;
        this.val\u0024wallHealthMultiplier = obj2;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u00387 obj = this;
        this.requirements(Category.__\u003C\u003Edefense, ItemStack.mult(Blocks.thoriumWall.requirements, 4f));
        this.health = 200 * this.val\u0024wallHealthMultiplier * 4;
        this.size = 2;
      }

      [HideFromJava]
      static \u00387() => Wall.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00388 : Wall
    {
      [Modifiers]
      internal int val\u0024wallHealthMultiplier;
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {162, 159, 119, 127, 8, 114, 107, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00388([In] Blocks obj0, [In] string obj1, [In] int obj2)
      {
        this.this\u00240 = obj0;
        this.val\u0024wallHealthMultiplier = obj2;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u00388 obj = this;
        this.requirements(Category.__\u003C\u003Edefense, ItemStack.with((object) Items.phaseFabric, (object) Integer.valueOf(6)));
        this.health = 150 * this.val\u0024wallHealthMultiplier;
        this.chanceDeflect = 10f;
        this.flashHit = true;
      }

      [HideFromJava]
      static \u00388() => Wall.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00389 : Wall
    {
      [Modifiers]
      internal int val\u0024wallHealthMultiplier;
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {162, 166, 119, 127, 0, 114, 103, 107, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00389([In] Blocks obj0, [In] string obj1, [In] int obj2)
      {
        this.this\u00240 = obj0;
        this.val\u0024wallHealthMultiplier = obj2;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u00389 obj = this;
        this.requirements(Category.__\u003C\u003Edefense, ItemStack.mult(Blocks.phaseWall.requirements, 4f));
        this.health = 600 * this.val\u0024wallHealthMultiplier;
        this.size = 2;
        this.chanceDeflect = 10f;
        this.flashHit = true;
      }

      [HideFromJava]
      static \u00389() => Wall.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u0039 : Floor
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {160, 66, 112, 107, 107, 107, 107, 103, 107, 103, 107, 149, 103, 107, 122})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0039([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u0039 obj = this;
        this.drownTime = 150f;
        this.status = StatusEffects.melting;
        this.statusDuration = 240f;
        this.speedMultiplier = 0.19f;
        this.variants = 0;
        this.liquidDrop = Liquids.slag;
        this.isLiquid = true;
        this.cacheLayer = CacheLayer.__\u003C\u003Eslag;
        this.attributes.set(Attribute.__\u003C\u003Eheat, 0.85f);
        this.emitLight = true;
        this.lightRadius = 40f;
        this.lightColor = Color.__\u003C\u003Eorange.cpy().a(0.38f);
      }

      [HideFromJava]
      static \u0039() => Floor.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00390 : Wall
    {
      [Modifiers]
      internal int val\u0024wallHealthMultiplier;
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {162, 174, 119, 127, 8, 114, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00390([In] Blocks obj0, [In] string obj1, [In] int obj2)
      {
        this.this\u00240 = obj0;
        this.val\u0024wallHealthMultiplier = obj2;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u00390 obj = this;
        this.requirements(Category.__\u003C\u003Edefense, ItemStack.with((object) Items.surgeAlloy, (object) Integer.valueOf(6)));
        this.health = 230 * this.val\u0024wallHealthMultiplier;
        this.lightningChance = 0.05f;
      }

      [HideFromJava]
      static \u00390() => Wall.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00391 : Wall
    {
      [Modifiers]
      internal int val\u0024wallHealthMultiplier;
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {162, 180, 119, 127, 0, 114, 103, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00391([In] Blocks obj0, [In] string obj1, [In] int obj2)
      {
        this.this\u00240 = obj0;
        this.val\u0024wallHealthMultiplier = obj2;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u00391 obj = this;
        this.requirements(Category.__\u003C\u003Edefense, ItemStack.mult(Blocks.surgeWall.requirements, 4f));
        this.health = 920 * this.val\u0024wallHealthMultiplier;
        this.size = 2;
        this.lightningChance = 0.05f;
      }

      [HideFromJava]
      static \u00391() => Wall.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00392 : Door
    {
      [Modifiers]
      internal int val\u0024wallHealthMultiplier;
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {162, 187, 119, 127, 25, 111})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00392([In] Blocks obj0, [In] string obj1, [In] int obj2)
      {
        this.this\u00240 = obj0;
        this.val\u0024wallHealthMultiplier = obj2;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u00392 obj = this;
        this.requirements(Category.__\u003C\u003Edefense, ItemStack.with((object) Items.titanium, (object) Integer.valueOf(6), (object) Items.silicon, (object) Integer.valueOf(4)));
        this.health = 100 * this.val\u0024wallHealthMultiplier;
      }

      [HideFromJava]
      static \u00392() => Door.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00393 : Door
    {
      [Modifiers]
      internal int val\u0024wallHealthMultiplier;
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {162, 192, 119, 127, 0, 107, 107, 114, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00393([In] Blocks obj0, [In] string obj1, [In] int obj2)
      {
        this.this\u00240 = obj0;
        this.val\u0024wallHealthMultiplier = obj2;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u00393 obj = this;
        this.requirements(Category.__\u003C\u003Edefense, ItemStack.mult(Blocks.door.requirements, 4f));
        this.openfx = Fx.__\u003C\u003Edooropenlarge;
        this.closefx = Fx.__\u003C\u003Edoorcloselarge;
        this.health = 400 * this.val\u0024wallHealthMultiplier;
        this.size = 2;
      }

      [HideFromJava]
      static \u00393() => Door.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00394 : Wall
    {
      [Modifiers]
      internal int val\u0024wallHealthMultiplier;
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {162, 200, 119, 127, 13, 111, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00394([In] Blocks obj0, [In] string obj1, [In] int obj2)
      {
        this.this\u00240 = obj0;
        this.val\u0024wallHealthMultiplier = obj2;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u00394 obj = this;
        this.requirements(Category.__\u003C\u003Edefense, BuildVisibility.__\u003C\u003EsandboxOnly, ItemStack.with((object) Items.scrap, (object) Integer.valueOf(6)));
        this.health = 60 * this.val\u0024wallHealthMultiplier;
        this.variants = 5;
      }

      [HideFromJava]
      static \u00394() => Wall.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00395 : Wall
    {
      [Modifiers]
      internal int val\u0024wallHealthMultiplier;
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {162, 206, 119, 127, 5, 114, 103, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00395([In] Blocks obj0, [In] string obj1, [In] int obj2)
      {
        this.this\u00240 = obj0;
        this.val\u0024wallHealthMultiplier = obj2;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u00395 obj = this;
        this.requirements(Category.__\u003C\u003Edefense, BuildVisibility.__\u003C\u003EsandboxOnly, ItemStack.mult(Blocks.scrapWall.requirements, 4f));
        this.health = 240 * this.val\u0024wallHealthMultiplier;
        this.size = 2;
        this.variants = 4;
      }

      [HideFromJava]
      static \u00395() => Wall.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00396 : Wall
    {
      [Modifiers]
      internal int val\u0024wallHealthMultiplier;
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {162, 213, 119, 127, 5, 114, 103, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00396([In] Blocks obj0, [In] string obj1, [In] int obj2)
      {
        this.this\u00240 = obj0;
        this.val\u0024wallHealthMultiplier = obj2;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u00396 obj = this;
        this.requirements(Category.__\u003C\u003Edefense, BuildVisibility.__\u003C\u003EsandboxOnly, ItemStack.mult(Blocks.scrapWall.requirements, 9f));
        this.health = 540 * this.val\u0024wallHealthMultiplier;
        this.size = 3;
        this.variants = 3;
      }

      [HideFromJava]
      static \u00396() => Wall.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00397 : Wall
    {
      [Modifiers]
      internal int val\u0024wallHealthMultiplier;
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {162, 220, 119, 127, 5, 114, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00397([In] Blocks obj0, [In] string obj1, [In] int obj2)
      {
        this.this\u00240 = obj0;
        this.val\u0024wallHealthMultiplier = obj2;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u00397 obj = this;
        this.requirements(Category.__\u003C\u003Edefense, BuildVisibility.__\u003C\u003EsandboxOnly, ItemStack.mult(Blocks.scrapWall.requirements, 16f));
        this.health = 960 * this.val\u0024wallHealthMultiplier;
        this.size = 4;
      }

      [HideFromJava]
      static \u00397() => Wall.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00398 : Thruster
    {
      [Modifiers]
      internal int val\u0024wallHealthMultiplier;
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {162, 226, 119, 114, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00398([In] Blocks obj0, [In] string obj1, [In] int obj2)
      {
        this.this\u00240 = obj0;
        this.val\u0024wallHealthMultiplier = obj2;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u00398 obj = this;
        this.health = 880 * this.val\u0024wallHealthMultiplier;
        this.size = 4;
      }

      [HideFromJava]
      static \u00398() => Thruster.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00399 : MendProjector
    {
      [Modifiers]
      internal Blocks this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {162, 231, 112, 127, 27, 113, 103, 107, 107, 107, 107, 107, 104, 118})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00399([In] Blocks obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Blocks.\u00399 obj = this;
        this.requirements(Category.__\u003C\u003Eeffect, ItemStack.with((object) Items.lead, (object) Integer.valueOf(30), (object) Items.copper, (object) Integer.valueOf(25)));
        this.__\u003C\u003Econsumes.power(0.3f);
        this.size = 1;
        this.reload = 200f;
        this.range = 40f;
        this.healPercent = 4f;
        this.phaseBoost = 4f;
        this.phaseRangeBoost = 20f;
        this.health = 80;
        this.__\u003C\u003Econsumes.item(Items.silicon).boost();
      }

      [HideFromJava]
      static \u00399() => MendProjector.__\u003Cclinit\u003E();
    }
  }
}
