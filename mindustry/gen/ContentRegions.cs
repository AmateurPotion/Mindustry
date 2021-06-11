// Decompiled with JetBrains decompiler
// Type: mindustry.gen.ContentRegions
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.graphics.g2d;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using mindustry.ctype;
using mindustry.world;
using mindustry.world.blocks.campaign;
using mindustry.world.blocks.defense;
using mindustry.world.blocks.defense.turrets;
using mindustry.world.blocks.distribution;
using mindustry.world.blocks.environment;
using mindustry.world.blocks.liquid;
using mindustry.world.blocks.logic;
using mindustry.world.blocks.power;
using mindustry.world.blocks.production;
using mindustry.world.blocks.units;
using System.Runtime.CompilerServices;

namespace mindustry.gen
{
  public class ContentRegions : Object
  {
    [LineNumberTable(new byte[] {0, 104, 122, 154, 104, 159, 31, 107, 127, 77, 127, 77, 159, 77, 107, 127, 31, 127, 31, 159, 31, 104, 159, 31, 107, 113, 102, 63, 49, 166, 127, 31, 159, 31, 107, 127, 15, 105, 105, 63, 67, 41, 233, 70, 104, 159, 31, 104, 127, 31, 159, 31, 104, 159, 31, 104, 159, 31, 104, 159, 31, 104, 127, 31, 159, 31, 104, 117, 106, 63, 28, 198, 104, 127, 31, 159, 31, 107, 113, 102, 63, 49, 166, 113, 105, 63, 85, 201, 107, 127, 31, 127, 31, 159, 31, 104, 159, 31, 104, 159, 31, 107, 127, 31, 127, 31, 127, 31, 159, 77, 104, 159, 31, 104, 159, 31, 104, 159, 31, 104, 127, 31, 122, 154, 104, 159, 31, 104, 159, 31, 104, 159, 31, 107, 127, 36, 127, 31, 159, 31, 107, 113, 102, 63, 49, 166, 159, 31, 104, 154, 104, 159, 31, 104, 127, 31, 159, 31, 104, 127, 31, 159, 31, 104, 159, 31, 107, 127, 77, 159, 31, 104, 159, 36, 104, 127, 31, 159, 31, 107, 127, 31, 159, 36, 104, 159, 31, 107, 127, 31, 127, 31, 159, 31, 107, 127, 31, 113, 102, 63, 49, 198})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void loadRegions(MappableContent content)
    {
      if (content is PowerNode)
      {
        ((PowerNode) content).laser = (TextureRegion) Core.atlas.find("laser");
        ((PowerNode) content).laserEnd = (TextureRegion) Core.atlas.find("laser-end");
      }
      if (content is MendProjector)
        ((MendProjector) content).topRegion = (TextureRegion) Core.atlas.find(new StringBuilder().append("").append(content.__\u003C\u003Ename).append("-top").toString());
      if (content is PayloadAcceptor)
      {
        ((PayloadAcceptor) content).topRegion = Core.atlas.find(new StringBuilder().append("").append(content.__\u003C\u003Ename).append("-top").toString(), new StringBuilder().append("factory-top-").append(((Block) content).size).append("").toString());
        ((PayloadAcceptor) content).outRegion = Core.atlas.find(new StringBuilder().append("").append(content.__\u003C\u003Ename).append("-out").toString(), new StringBuilder().append("factory-out-").append(((Block) content).size).append("").toString());
        ((PayloadAcceptor) content).inRegion = Core.atlas.find(new StringBuilder().append("").append(content.__\u003C\u003Ename).append("-in").toString(), new StringBuilder().append("factory-in-").append(((Block) content).size).append("").toString());
      }
      if (content is Fracker)
      {
        ((Fracker) content).liquidRegion = (TextureRegion) Core.atlas.find(new StringBuilder().append("").append(content.__\u003C\u003Ename).append("-liquid").toString());
        ((Fracker) content).rotatorRegion = (TextureRegion) Core.atlas.find(new StringBuilder().append("").append(content.__\u003C\u003Ename).append("-rotator").toString());
        ((Fracker) content).topRegion = (TextureRegion) Core.atlas.find(new StringBuilder().append("").append(content.__\u003C\u003Ename).append("-top").toString());
      }
      if (content is SolidPump)
        ((SolidPump) content).rotatorRegion = (TextureRegion) Core.atlas.find(new StringBuilder().append("").append(content.__\u003C\u003Ename).append("-rotator").toString());
      if (content is StackConveyor)
      {
        ((StackConveyor) content).regions = new TextureRegion[3];
        for (int index = 0; index < 3; ++index)
          ((StackConveyor) content).regions[index] = (TextureRegion) Core.atlas.find(new StringBuilder().append("").append(content.__\u003C\u003Ename).append("-").append(index).append("").toString());
        ((StackConveyor) content).edgeRegion = (TextureRegion) Core.atlas.find(new StringBuilder().append("").append(content.__\u003C\u003Ename).append("-edge").toString());
        ((StackConveyor) content).stackRegion = (TextureRegion) Core.atlas.find(new StringBuilder().append("").append(content.__\u003C\u003Ename).append("-stack").toString());
      }
      if (content is Conveyor)
      {
        Conveyor conveyor = (Conveyor) content;
        int[] numArray = new int[2];
        int num1 = 4;
        numArray[1] = num1;
        int num2 = 7;
        numArray[0] = num2;
        // ISSUE: type reference
        TextureRegion[][] textureRegionArray = (TextureRegion[][]) ByteCodeHelper.multianewarray(__typeref (TextureRegion[][]), numArray);
        conveyor.regions = textureRegionArray;
        for (int index1 = 0; index1 < 7; ++index1)
        {
          for (int index2 = 0; index2 < 4; ++index2)
            ((Conveyor) content).regions[index1][index2] = (TextureRegion) Core.atlas.find(new StringBuilder().append("").append(content.__\u003C\u003Ename).append("-").append(index1).append("-").append(index2).append("").toString());
        }
      }
      if (content is ArmoredConduit)
        ((ArmoredConduit) content).capRegion = (TextureRegion) Core.atlas.find(new StringBuilder().append("").append(content.__\u003C\u003Ename).append("-cap").toString());
      if (content is ItemLiquidGenerator)
      {
        ((ItemLiquidGenerator) content).topRegion = (TextureRegion) Core.atlas.find(new StringBuilder().append("").append(content.__\u003C\u003Ename).append("-top").toString());
        ((ItemLiquidGenerator) content).liquidRegion = (TextureRegion) Core.atlas.find(new StringBuilder().append("").append(content.__\u003C\u003Ename).append("-liquid").toString());
      }
      if (content is ForceProjector)
        ((ForceProjector) content).topRegion = (TextureRegion) Core.atlas.find(new StringBuilder().append("").append(content.__\u003C\u003Ename).append("-top").toString());
      if (content is SwitchBlock)
        ((SwitchBlock) content).onRegion = (TextureRegion) Core.atlas.find(new StringBuilder().append("").append(content.__\u003C\u003Ename).append("-on").toString());
      if (content is Thruster)
        ((Thruster) content).topRegion = (TextureRegion) Core.atlas.find(new StringBuilder().append("").append(content.__\u003C\u003Ename).append("-top").toString());
      if (content is LiquidTurret)
      {
        ((LiquidTurret) content).liquidRegion = (TextureRegion) Core.atlas.find(new StringBuilder().append("").append(content.__\u003C\u003Ename).append("-liquid").toString());
        ((LiquidTurret) content).topRegion = (TextureRegion) Core.atlas.find(new StringBuilder().append("").append(content.__\u003C\u003Ename).append("-top").toString());
      }
      if (content is Cliff)
      {
        ((Cliff) content).cliffs = new TextureRegion[256];
        for (int index = 0; index < 256; ++index)
          ((Cliff) content).cliffs[index] = (TextureRegion) Core.atlas.find(new StringBuilder().append("cliffmask").append(index).append("").toString());
      }
      if (content is Separator)
      {
        ((Separator) content).liquidRegion = (TextureRegion) Core.atlas.find(new StringBuilder().append("").append(content.__\u003C\u003Ename).append("-liquid").toString());
        ((Separator) content).spinnerRegion = (TextureRegion) Core.atlas.find(new StringBuilder().append("").append(content.__\u003C\u003Ename).append("-spinner").toString());
      }
      if (content is Conduit)
      {
        ((Conduit) content).topRegions = new TextureRegion[5];
        for (int index = 0; index < 5; ++index)
          ((Conduit) content).topRegions[index] = (TextureRegion) Core.atlas.find(new StringBuilder().append("").append(content.__\u003C\u003Ename).append("-top-").append(index).append("").toString());
        ((Conduit) content).botRegions = new TextureRegion[5];
        for (int index = 0; index < 5; ++index)
          ((Conduit) content).botRegions[index] = Core.atlas.find(new StringBuilder().append("").append(content.__\u003C\u003Ename).append("-bottom-").append(index).append("").toString(), new StringBuilder().append("conduit-bottom-").append(index).append("").toString());
      }
      if (content is LiquidBlock)
      {
        ((LiquidBlock) content).liquidRegion = (TextureRegion) Core.atlas.find(new StringBuilder().append("").append(content.__\u003C\u003Ename).append("-liquid").toString());
        ((LiquidBlock) content).topRegion = (TextureRegion) Core.atlas.find(new StringBuilder().append("").append(content.__\u003C\u003Ename).append("-top").toString());
        ((LiquidBlock) content).bottomRegion = (TextureRegion) Core.atlas.find(new StringBuilder().append("").append(content.__\u003C\u003Ename).append("-bottom").toString());
      }
      if (content is GenericSmelter)
        ((GenericSmelter) content).topRegion = (TextureRegion) Core.atlas.find(new StringBuilder().append("").append(content.__\u003C\u003Ename).append("-top").toString());
      if (content is Battery)
        ((Battery) content).topRegion = (TextureRegion) Core.atlas.find(new StringBuilder().append("").append(content.__\u003C\u003Ename).append("-top").toString());
      if (content is Drill)
      {
        ((Drill) content).rimRegion = (TextureRegion) Core.atlas.find(new StringBuilder().append("").append(content.__\u003C\u003Ename).append("-rim").toString());
        ((Drill) content).rotatorRegion = (TextureRegion) Core.atlas.find(new StringBuilder().append("").append(content.__\u003C\u003Ename).append("-rotator").toString());
        ((Drill) content).topRegion = (TextureRegion) Core.atlas.find(new StringBuilder().append("").append(content.__\u003C\u003Ename).append("-top").toString());
        ((Drill) content).itemRegion = Core.atlas.find(new StringBuilder().append("").append(content.__\u003C\u003Ename).append("-item").toString(), new StringBuilder().append("drill-item-").append(((Block) content).size).append("").toString());
      }
      if (content is TreeBlock)
        ((TreeBlock) content).shadow = (TextureRegion) Core.atlas.find(new StringBuilder().append("").append(content.__\u003C\u003Ename).append("-shadow").toString());
      if (content is Block)
        ((Block) content).teamRegion = (TextureRegion) Core.atlas.find(new StringBuilder().append("").append(content.__\u003C\u003Ename).append("-team").toString());
      if (content is PowerDiode)
        ((PowerDiode) content).arrow = (TextureRegion) Core.atlas.find(new StringBuilder().append("").append(content.__\u003C\u003Ename).append("-arrow").toString());
      if (content is RepairPoint)
      {
        ((RepairPoint) content).baseRegion = (TextureRegion) Core.atlas.find(new StringBuilder().append("").append(content.__\u003C\u003Ename).append("-base").toString());
        ((RepairPoint) content).laser = (TextureRegion) Core.atlas.find("laser");
        ((RepairPoint) content).laserEnd = (TextureRegion) Core.atlas.find("laser-end");
      }
      if (content is Door)
        ((Door) content).openRegion = (TextureRegion) Core.atlas.find(new StringBuilder().append("").append(content.__\u003C\u003Ename).append("-open").toString());
      if (content is OverdriveProjector)
        ((OverdriveProjector) content).topRegion = (TextureRegion) Core.atlas.find(new StringBuilder().append("").append(content.__\u003C\u003Ename).append("-top").toString());
      if (content is StaticWall)
        ((StaticWall) content).large = (TextureRegion) Core.atlas.find(new StringBuilder().append("").append(content.__\u003C\u003Ename).append("-large").toString());
      if (content is TractorBeamTurret)
      {
        ((TractorBeamTurret) content).baseRegion = (TextureRegion) Core.atlas.find(new StringBuilder().append("block-").append(((Block) content).size).append("").toString());
        ((TractorBeamTurret) content).laser = (TextureRegion) Core.atlas.find(new StringBuilder().append("").append(content.__\u003C\u003Ename).append("-laser").toString());
        ((TractorBeamTurret) content).laserEnd = (TextureRegion) Core.atlas.find(new StringBuilder().append("").append(content.__\u003C\u003Ename).append("-laser-end").toString());
      }
      if (content is BurnerGenerator)
      {
        ((BurnerGenerator) content).turbineRegions = new TextureRegion[2];
        for (int index = 0; index < 2; ++index)
          ((BurnerGenerator) content).turbineRegions[index] = (TextureRegion) Core.atlas.find(new StringBuilder().append("").append(content.__\u003C\u003Ename).append("-turbine").append(index).append("").toString());
        ((BurnerGenerator) content).capRegion = (TextureRegion) Core.atlas.find(new StringBuilder().append("").append(content.__\u003C\u003Ename).append("-cap").toString());
      }
      if (content is Accelerator)
        ((Accelerator) content).arrowRegion = (TextureRegion) Core.atlas.find("launch-arrow");
      if (content is MassDriver)
        ((MassDriver) content).baseRegion = (TextureRegion) Core.atlas.find(new StringBuilder().append("").append(content.__\u003C\u003Ename).append("-base").toString());
      if (content is PayloadConveyor)
      {
        ((PayloadConveyor) content).topRegion = (TextureRegion) Core.atlas.find(new StringBuilder().append("").append(content.__\u003C\u003Ename).append("-top").toString());
        ((PayloadConveyor) content).edgeRegion = (TextureRegion) Core.atlas.find(new StringBuilder().append("").append(content.__\u003C\u003Ename).append("-edge").toString());
      }
      if (content is Cultivator)
      {
        ((Cultivator) content).middleRegion = (TextureRegion) Core.atlas.find(new StringBuilder().append("").append(content.__\u003C\u003Ename).append("-middle").toString());
        ((Cultivator) content).topRegion = (TextureRegion) Core.atlas.find(new StringBuilder().append("").append(content.__\u003C\u003Ename).append("-top").toString());
      }
      if (content is LightBlock)
        ((LightBlock) content).topRegion = (TextureRegion) Core.atlas.find(new StringBuilder().append("").append(content.__\u003C\u003Ename).append("-top").toString());
      if (content is Turret)
      {
        ((Turret) content).baseRegion = Core.atlas.find(new StringBuilder().append("").append(content.__\u003C\u003Ename).append("-base").toString(), new StringBuilder().append("block-").append(((Block) content).size).append("").toString());
        ((Turret) content).heatRegion = (TextureRegion) Core.atlas.find(new StringBuilder().append("").append(content.__\u003C\u003Ename).append("-heat").toString());
      }
      if (content is PointDefenseTurret)
        ((PointDefenseTurret) content).baseRegion = (TextureRegion) Core.atlas.find(new StringBuilder().append("block-").append(((Block) content).size).append("").toString());
      if (content is NuclearReactor)
      {
        ((NuclearReactor) content).topRegion = (TextureRegion) Core.atlas.find(new StringBuilder().append("").append(content.__\u003C\u003Ename).append("-top").toString());
        ((NuclearReactor) content).lightsRegion = (TextureRegion) Core.atlas.find(new StringBuilder().append("").append(content.__\u003C\u003Ename).append("-lights").toString());
      }
      if (content is LaunchPad)
      {
        ((LaunchPad) content).lightRegion = (TextureRegion) Core.atlas.find(new StringBuilder().append("").append(content.__\u003C\u003Ename).append("-light").toString());
        ((LaunchPad) content).podRegion = Core.atlas.find(new StringBuilder().append("").append(content.__\u003C\u003Ename).append("-pod").toString(), "launchpod");
      }
      if (content is PayloadRouter)
        ((PayloadRouter) content).overRegion = (TextureRegion) Core.atlas.find(new StringBuilder().append("").append(content.__\u003C\u003Ename).append("-over").toString());
      if (content is ItemBridge)
      {
        ((ItemBridge) content).endRegion = (TextureRegion) Core.atlas.find(new StringBuilder().append("").append(content.__\u003C\u003Ename).append("-end").toString());
        ((ItemBridge) content).bridgeRegion = (TextureRegion) Core.atlas.find(new StringBuilder().append("").append(content.__\u003C\u003Ename).append("-bridge").toString());
        ((ItemBridge) content).arrowRegion = (TextureRegion) Core.atlas.find(new StringBuilder().append("").append(content.__\u003C\u003Ename).append("-arrow").toString());
      }
      if (!(content is ImpactReactor))
        return;
      ((ImpactReactor) content).bottomRegion = (TextureRegion) Core.atlas.find(new StringBuilder().append("").append(content.__\u003C\u003Ename).append("-bottom").toString());
      ((ImpactReactor) content).plasmaRegions = new TextureRegion[4];
      for (int index = 0; index < 4; ++index)
        ((ImpactReactor) content).plasmaRegions[index] = (TextureRegion) Core.atlas.find(new StringBuilder().append("").append(content.__\u003C\u003Ename).append("-plasma-").append(index).append("").toString());
    }

    [LineNumberTable(48)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ContentRegions()
    {
    }
  }
}
