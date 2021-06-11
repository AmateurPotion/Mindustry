// Decompiled with JetBrains decompiler
// Type: mindustry.mod.ClassMap
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using mindustry.ai.types;
using mindustry.entities.abilities;
using mindustry.entities.bullet;
using mindustry.entities.effect;
using mindustry.game;
using mindustry.type.weather;
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
using mindustry.world.blocks.payloads;
using mindustry.world.blocks.power;
using mindustry.world.blocks.production;
using mindustry.world.blocks.sandbox;
using mindustry.world.blocks.storage;
using mindustry.world.blocks.units;
using mindustry.world.draw;
using System.Runtime.CompilerServices;

namespace mindustry.mod
{
  public class ClassMap : Object
  {
    [Signature("Larc/struct/ObjectMap<Ljava/lang/String;Ljava/lang/Class<*>;>;")]
    internal static ObjectMap __\u003C\u003Eclasses;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(5)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ClassMap()
    {
    }

    [LineNumberTable(new byte[] {159, 141, 141, 170, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static ClassMap()
    {
      if (ByteCodeHelper.isAlreadyInited("mindustry.mod.ClassMap"))
        return;
      ClassMap.__\u003C\u003Eclasses = new ObjectMap();
      ClassMap.__\u003C\u003Eclasses.put((object) "BuilderAI", (object) ClassLiteral<BuilderAI>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "FlyingAI", (object) ClassLiteral<FlyingAI>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "FormationAI", (object) ClassLiteral<FormationAI>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "GroundAI", (object) ClassLiteral<GroundAI>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "LogicAI", (object) ClassLiteral<LogicAI>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "MinerAI", (object) ClassLiteral<MinerAI>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "RepairAI", (object) ClassLiteral<RepairAI>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "SuicideAI", (object) ClassLiteral<SuicideAI>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "Ability", (object) ClassLiteral<Ability>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "ForceFieldAbility", (object) ClassLiteral<ForceFieldAbility>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "MoveLightningAbility", (object) ClassLiteral<MoveLightningAbility>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "RepairFieldAbility", (object) ClassLiteral<RepairFieldAbility>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "ShieldRegenFieldAbility", (object) ClassLiteral<ShieldRegenFieldAbility>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "StatusFieldAbility", (object) ClassLiteral<StatusFieldAbility>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "UnitSpawnAbility", (object) ClassLiteral<UnitSpawnAbility>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "ArtilleryBulletType", (object) ClassLiteral<ArtilleryBulletType>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "BasicBulletType", (object) ClassLiteral<BasicBulletType>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "BombBulletType", (object) ClassLiteral<BombBulletType>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "BulletType", (object) ClassLiteral<BulletType>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "ContinuousLaserBulletType", (object) ClassLiteral<ContinuousLaserBulletType>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "FlakBulletType", (object) ClassLiteral<FlakBulletType>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "LaserBoltBulletType", (object) ClassLiteral<LaserBoltBulletType>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "LaserBulletType", (object) ClassLiteral<LaserBulletType>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "LightningBulletType", (object) ClassLiteral<LightningBulletType>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "LiquidBulletType", (object) ClassLiteral<LiquidBulletType>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "MassDriverBolt", (object) ClassLiteral<MassDriverBolt>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "MissileBulletType", (object) ClassLiteral<MissileBulletType>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "PointBulletType", (object) ClassLiteral<PointBulletType>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "RailBulletType", (object) ClassLiteral<RailBulletType>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "SapBulletType", (object) ClassLiteral<SapBulletType>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "ShrapnelBulletType", (object) ClassLiteral<ShrapnelBulletType>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "MultiEffect", (object) ClassLiteral<MultiEffect>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "ParticleEffect", (object) ClassLiteral<ParticleEffect>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "WaveEffect", (object) ClassLiteral<WaveEffect>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "Objectives", (object) ClassLiteral<Objectives>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "Objective", (object) ClassLiteral<Objectives.Objective>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "Produce", (object) ClassLiteral<Objectives.Produce>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "Research", (object) ClassLiteral<Objectives.Research>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "SectorComplete", (object) ClassLiteral<Objectives.SectorComplete>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "ParticleWeather", (object) ClassLiteral<ParticleWeather>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "RainWeather", (object) ClassLiteral<RainWeather>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "Attributes", (object) ClassLiteral<mindustry.world.blocks.Attributes>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "Autotiler", (object) ClassLiteral<Autotiler>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "AutotilerHolder", (object) ClassLiteral<Autotiler.AutotilerHolder>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "SliceMode", (object) ClassLiteral<Autotiler.SliceMode>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "ConstructBlock", (object) ClassLiteral<ConstructBlock>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "ConstructBuild", (object) ClassLiteral<ConstructBlock.ConstructBuild>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "ControlBlock", (object) ClassLiteral<ControlBlock>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "ItemSelection", (object) ClassLiteral<ItemSelection>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "Accelerator", (object) ClassLiteral<Accelerator>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "AcceleratorBuild", (object) ClassLiteral<Accelerator.AcceleratorBuild>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "LaunchPad", (object) ClassLiteral<LaunchPad>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "LaunchPadBuild", (object) ClassLiteral<LaunchPad.LaunchPadBuild>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "Door", (object) ClassLiteral<Door>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "DoorBuild", (object) ClassLiteral<Door.DoorBuild>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "ForceProjector", (object) ClassLiteral<ForceProjector>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "ForceBuild", (object) ClassLiteral<ForceProjector.ForceBuild>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "MendProjector", (object) ClassLiteral<MendProjector>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "MendBuild", (object) ClassLiteral<MendProjector.MendBuild>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "OverdriveProjector", (object) ClassLiteral<OverdriveProjector>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "OverdriveBuild", (object) ClassLiteral<OverdriveProjector.OverdriveBuild>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "ShockMine", (object) ClassLiteral<ShockMine>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "ShockMineBuild", (object) ClassLiteral<ShockMine.ShockMineBuild>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "Thruster", (object) ClassLiteral<Thruster>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "ThrusterBuild", (object) ClassLiteral<Thruster.ThrusterBuild>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "Wall", (object) ClassLiteral<Wall>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "WallBuild", (object) ClassLiteral<Wall.WallBuild>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "BaseTurret", (object) ClassLiteral<BaseTurret>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "BaseTurretBuild", (object) ClassLiteral<BaseTurret.BaseTurretBuild>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "ItemTurret", (object) ClassLiteral<ItemTurret>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "ItemTurretBuild", (object) ClassLiteral<ItemTurret.ItemTurretBuild>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "LaserTurret", (object) ClassLiteral<LaserTurret>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "LaserTurretBuild", (object) ClassLiteral<LaserTurret.LaserTurretBuild>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "LiquidTurret", (object) ClassLiteral<LiquidTurret>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "LiquidTurretBuild", (object) ClassLiteral<LiquidTurret.LiquidTurretBuild>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "PointDefenseTurret", (object) ClassLiteral<PointDefenseTurret>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "PointDefenseBuild", (object) ClassLiteral<PointDefenseTurret.PointDefenseBuild>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "PowerTurret", (object) ClassLiteral<PowerTurret>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "PowerTurretBuild", (object) ClassLiteral<PowerTurret.PowerTurretBuild>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "ReloadTurret", (object) ClassLiteral<ReloadTurret>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "ReloadTurretBuild", (object) ClassLiteral<ReloadTurret.ReloadTurretBuild>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "TractorBeamTurret", (object) ClassLiteral<TractorBeamTurret>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "TractorBeamBuild", (object) ClassLiteral<TractorBeamTurret.TractorBeamBuild>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "Turret", (object) ClassLiteral<Turret>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "AmmoEntry", (object) ClassLiteral<Turret.AmmoEntry>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "TurretBuild", (object) ClassLiteral<Turret.TurretBuild>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "ArmoredConveyor", (object) ClassLiteral<ArmoredConveyor>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "ArmoredConveyorBuild", (object) ClassLiteral<ArmoredConveyor.ArmoredConveyorBuild>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "BufferedItemBridge", (object) ClassLiteral<BufferedItemBridge>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "BufferedItemBridgeBuild", (object) ClassLiteral<BufferedItemBridge.BufferedItemBridgeBuild>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "ChainedBuilding", (object) ClassLiteral<ChainedBuilding>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "Conveyor", (object) ClassLiteral<Conveyor>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "ConveyorBuild", (object) ClassLiteral<Conveyor.ConveyorBuild>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "ExtendingItemBridge", (object) ClassLiteral<ExtendingItemBridge>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "ExtendingItemBridgeBuild", (object) ClassLiteral<ExtendingItemBridge.ExtendingItemBridgeBuild>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "ItemBridge", (object) ClassLiteral<ItemBridge>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "ItemBridgeBuild", (object) ClassLiteral<ItemBridge.ItemBridgeBuild>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "Junction", (object) ClassLiteral<Junction>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "JunctionBuild", (object) ClassLiteral<Junction.JunctionBuild>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "MassDriver", (object) ClassLiteral<MassDriver>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "DriverBulletData", (object) ClassLiteral<MassDriver.DriverBulletData>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "DriverState", (object) ClassLiteral<MassDriver.DriverState>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "MassDriverBuild", (object) ClassLiteral<MassDriver.MassDriverBuild>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "OverflowGate", (object) ClassLiteral<OverflowGate>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "OverflowGateBuild", (object) ClassLiteral<OverflowGate.OverflowGateBuild>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "PayloadConveyor", (object) ClassLiteral<PayloadConveyor>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "PayloadConveyorBuild", (object) ClassLiteral<PayloadConveyor.PayloadConveyorBuild>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "PayloadRouter", (object) ClassLiteral<PayloadRouter>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "PayloadRouterBuild", (object) ClassLiteral<PayloadRouter.PayloadRouterBuild>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "Router", (object) ClassLiteral<Router>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "RouterBuild", (object) ClassLiteral<Router.RouterBuild>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "Sorter", (object) ClassLiteral<Sorter>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "SorterBuild", (object) ClassLiteral<Sorter.SorterBuild>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "StackConveyor", (object) ClassLiteral<StackConveyor>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "StackConveyorBuild", (object) ClassLiteral<StackConveyor.StackConveyorBuild>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "AirBlock", (object) ClassLiteral<AirBlock>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "Boulder", (object) ClassLiteral<Boulder>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "Cliff", (object) ClassLiteral<Cliff>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "DoubleOverlayFloor", (object) ClassLiteral<DoubleOverlayFloor>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "Floor", (object) ClassLiteral<Floor>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "OreBlock", (object) ClassLiteral<OreBlock>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "OverlayFloor", (object) ClassLiteral<OverlayFloor>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "ShallowLiquid", (object) ClassLiteral<ShallowLiquid>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "SpawnBlock", (object) ClassLiteral<SpawnBlock>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "StaticTree", (object) ClassLiteral<StaticTree>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "StaticWall", (object) ClassLiteral<StaticWall>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "TreeBlock", (object) ClassLiteral<TreeBlock>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "BlockForge", (object) ClassLiteral<BlockForge>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "BlockForgeBuild", (object) ClassLiteral<BlockForge.BlockForgeBuild>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "BlockLoader", (object) ClassLiteral<BlockLoader>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "BlockLoaderBuild", (object) ClassLiteral<BlockLoader.BlockLoaderBuild>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "BlockUnloader", (object) ClassLiteral<BlockUnloader>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "BlockUnloaderBuild", (object) ClassLiteral<BlockUnloader.BlockUnloaderBuild>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "LegacyBlock", (object) ClassLiteral<LegacyBlock>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "LegacyMechPad", (object) ClassLiteral<LegacyMechPad>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "LegacyMechPadBuild", (object) ClassLiteral<LegacyMechPad.LegacyMechPadBuild>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "LegacyUnitFactory", (object) ClassLiteral<LegacyUnitFactory>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "LegacyUnitFactoryBuild", (object) ClassLiteral<LegacyUnitFactory.LegacyUnitFactoryBuild>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "ArmoredConduit", (object) ClassLiteral<ArmoredConduit>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "ArmoredConduitBuild", (object) ClassLiteral<ArmoredConduit.ArmoredConduitBuild>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "Conduit", (object) ClassLiteral<Conduit>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "ConduitBuild", (object) ClassLiteral<Conduit.ConduitBuild>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "LiquidBlock", (object) ClassLiteral<LiquidBlock>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "LiquidBuild", (object) ClassLiteral<LiquidBlock.LiquidBuild>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "LiquidBridge", (object) ClassLiteral<LiquidBridge>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "LiquidBridgeBuild", (object) ClassLiteral<LiquidBridge.LiquidBridgeBuild>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "LiquidExtendingBridge", (object) ClassLiteral<LiquidExtendingBridge>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "LiquidExtendingBridgeBuild", (object) ClassLiteral<LiquidExtendingBridge.LiquidExtendingBridgeBuild>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "LiquidJunction", (object) ClassLiteral<LiquidJunction>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "LiquidJunctionBuild", (object) ClassLiteral<LiquidJunction.LiquidJunctionBuild>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "LiquidRouter", (object) ClassLiteral<LiquidRouter>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "LiquidRouterBuild", (object) ClassLiteral<LiquidRouter.LiquidRouterBuild>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "LogicBlock", (object) ClassLiteral<LogicBlock>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "LogicBuild", (object) ClassLiteral<LogicBlock.LogicBuild>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "LogicLink", (object) ClassLiteral<LogicBlock.LogicLink>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "LogicDisplay", (object) ClassLiteral<LogicDisplay>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "GraphicsType", (object) ClassLiteral<LogicDisplay.GraphicsType>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "LogicDisplayBuild", (object) ClassLiteral<LogicDisplay.LogicDisplayBuild>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "MemoryBlock", (object) ClassLiteral<MemoryBlock>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "MemoryBuild", (object) ClassLiteral<MemoryBlock.MemoryBuild>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "MessageBlock", (object) ClassLiteral<MessageBlock>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "MessageBuild", (object) ClassLiteral<MessageBlock.MessageBuild>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "SwitchBlock", (object) ClassLiteral<SwitchBlock>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "SwitchBuild", (object) ClassLiteral<SwitchBlock.SwitchBuild>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "BuildPayload", (object) ClassLiteral<BuildPayload>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "Payload", (object) ClassLiteral<Payload>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "UnitPayload", (object) ClassLiteral<UnitPayload>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "Battery", (object) ClassLiteral<Battery>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "BatteryBuild", (object) ClassLiteral<Battery.BatteryBuild>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "BurnerGenerator", (object) ClassLiteral<BurnerGenerator>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "BurnerGeneratorBuild", (object) ClassLiteral<BurnerGenerator.BurnerGeneratorBuild>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "ConditionalConsumePower", (object) ClassLiteral<ConditionalConsumePower>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "DecayGenerator", (object) ClassLiteral<DecayGenerator>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "ImpactReactor", (object) ClassLiteral<ImpactReactor>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "ImpactReactorBuild", (object) ClassLiteral<ImpactReactor.ImpactReactorBuild>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "ItemLiquidGenerator", (object) ClassLiteral<ItemLiquidGenerator>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "ItemLiquidGeneratorBuild", (object) ClassLiteral<ItemLiquidGenerator.ItemLiquidGeneratorBuild>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "LightBlock", (object) ClassLiteral<LightBlock>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "LightBuild", (object) ClassLiteral<LightBlock.LightBuild>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "NuclearReactor", (object) ClassLiteral<NuclearReactor>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "NuclearReactorBuild", (object) ClassLiteral<NuclearReactor.NuclearReactorBuild>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "PowerBlock", (object) ClassLiteral<PowerBlock>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "PowerDiode", (object) ClassLiteral<PowerDiode>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "PowerDiodeBuild", (object) ClassLiteral<PowerDiode.PowerDiodeBuild>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "PowerDistributor", (object) ClassLiteral<PowerDistributor>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "PowerGenerator", (object) ClassLiteral<PowerGenerator>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "GeneratorBuild", (object) ClassLiteral<PowerGenerator.GeneratorBuild>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "PowerGraph", (object) ClassLiteral<PowerGraph>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "PowerNode", (object) ClassLiteral<PowerNode>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "PowerNodeBuild", (object) ClassLiteral<PowerNode.PowerNodeBuild>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "SingleTypeGenerator", (object) ClassLiteral<SingleTypeGenerator>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "SolarGenerator", (object) ClassLiteral<SolarGenerator>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "SolarGeneratorBuild", (object) ClassLiteral<SolarGenerator.SolarGeneratorBuild>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "ThermalGenerator", (object) ClassLiteral<ThermalGenerator>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "ThermalGeneratorBuild", (object) ClassLiteral<ThermalGenerator.ThermalGeneratorBuild>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "AttributeSmelter", (object) ClassLiteral<AttributeSmelter>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "AttributeSmelterBuild", (object) ClassLiteral<AttributeSmelter.AttributeSmelterBuild>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "Cultivator", (object) ClassLiteral<Cultivator>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "CultivatorBuild", (object) ClassLiteral<Cultivator.CultivatorBuild>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "Drill", (object) ClassLiteral<Drill>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "DrillBuild", (object) ClassLiteral<Drill.DrillBuild>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "Fracker", (object) ClassLiteral<Fracker>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "FrackerBuild", (object) ClassLiteral<Fracker.FrackerBuild>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "GenericCrafter", (object) ClassLiteral<GenericCrafter>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "GenericCrafterBuild", (object) ClassLiteral<GenericCrafter.GenericCrafterBuild>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "GenericSmelter", (object) ClassLiteral<GenericSmelter>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "SmelterBuild", (object) ClassLiteral<GenericSmelter.SmelterBuild>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "Incinerator", (object) ClassLiteral<Incinerator>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "IncineratorBuild", (object) ClassLiteral<Incinerator.IncineratorBuild>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "LiquidConverter", (object) ClassLiteral<LiquidConverter>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "LiquidConverterBuild", (object) ClassLiteral<LiquidConverter.LiquidConverterBuild>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "PayloadAcceptor", (object) ClassLiteral<PayloadAcceptor>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "PayloadAcceptorBuild", (object) ClassLiteral<PayloadAcceptor.PayloadAcceptorBuild>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "Pump", (object) ClassLiteral<Pump>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "PumpBuild", (object) ClassLiteral<Pump.PumpBuild>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "Separator", (object) ClassLiteral<Separator>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "SeparatorBuild", (object) ClassLiteral<Separator.SeparatorBuild>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "SolidPump", (object) ClassLiteral<SolidPump>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "SolidPumpBuild", (object) ClassLiteral<SolidPump.SolidPumpBuild>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "ItemSource", (object) ClassLiteral<ItemSource>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "ItemSourceBuild", (object) ClassLiteral<ItemSource.ItemSourceBuild>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "ItemVoid", (object) ClassLiteral<ItemVoid>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "ItemVoidBuild", (object) ClassLiteral<ItemVoid.ItemVoidBuild>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "LiquidSource", (object) ClassLiteral<LiquidSource>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "LiquidSourceBuild", (object) ClassLiteral<LiquidSource.LiquidSourceBuild>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "LiquidVoid", (object) ClassLiteral<LiquidVoid>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "LiquidVoidBuild", (object) ClassLiteral<LiquidVoid.LiquidVoidBuild>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "PowerSource", (object) ClassLiteral<PowerSource>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "PowerSourceBuild", (object) ClassLiteral<PowerSource.PowerSourceBuild>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "PowerVoid", (object) ClassLiteral<PowerVoid>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "CoreBlock", (object) ClassLiteral<CoreBlock>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "CoreBuild", (object) ClassLiteral<CoreBlock.CoreBuild>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "StorageBlock", (object) ClassLiteral<StorageBlock>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "StorageBuild", (object) ClassLiteral<StorageBlock.StorageBuild>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "Unloader", (object) ClassLiteral<Unloader>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "UnloaderBuild", (object) ClassLiteral<Unloader.UnloaderBuild>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "CommandCenter", (object) ClassLiteral<CommandCenter>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "CommandBuild", (object) ClassLiteral<CommandCenter.CommandBuild>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "Reconstructor", (object) ClassLiteral<Reconstructor>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "ReconstructorBuild", (object) ClassLiteral<Reconstructor.ReconstructorBuild>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "RepairPoint", (object) ClassLiteral<RepairPoint>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "RepairPointBuild", (object) ClassLiteral<RepairPoint.RepairPointBuild>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "ResupplyPoint", (object) ClassLiteral<ResupplyPoint>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "ResupplyPointBuild", (object) ClassLiteral<ResupplyPoint.ResupplyPointBuild>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "UnitBlock", (object) ClassLiteral<UnitBlock>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "UnitBuild", (object) ClassLiteral<UnitBlock.UnitBuild>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "UnitFactory", (object) ClassLiteral<UnitFactory>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "UnitFactoryBuild", (object) ClassLiteral<UnitFactory.UnitFactoryBuild>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "UnitPlan", (object) ClassLiteral<UnitFactory.UnitPlan>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "DrawAnimation", (object) ClassLiteral<DrawAnimation>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "DrawBlock", (object) ClassLiteral<DrawBlock>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "DrawGlow", (object) ClassLiteral<DrawGlow>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "DrawMixer", (object) ClassLiteral<DrawMixer>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "DrawRotator", (object) ClassLiteral<DrawRotator>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "DrawWeave", (object) ClassLiteral<DrawWeave>.Value);
      ClassMap.__\u003C\u003Eclasses.put((object) "Block", (object) ClassLiteral<Block>.Value);
    }

    [Modifiers]
    public static ObjectMap classes
    {
      [HideFromJava] get => ClassMap.__\u003C\u003Eclasses;
    }
  }
}
