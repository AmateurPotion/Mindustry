// Decompiled with JetBrains decompiler
// Type: mindustry.content.TechTree
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.@struct;
using arc.func;
using arc.util;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using mindustry.ctype;
using mindustry.game;
using mindustry.type;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.content
{
  public class TechTree : Object, ContentList
  {
    [Signature("Larc/struct/ObjectMap<Lmindustry/ctype/UnlockableContent;Lmindustry/content/TechTree$TechNode;>;")]
    internal static ObjectMap map;
    internal static TechTree.TechNode context;
    [Signature("Larc/struct/Seq<Lmindustry/content/TechTree$TechNode;>;")]
    public static Seq all;
    public static TechTree.TechNode root;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(681)]
    [Nullable(new object[] {64, "Larc/util/Nullable;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static TechTree.TechNode get(UnlockableContent content) => (TechTree.TechNode) TechTree.map.get((object) content);

    [LineNumberTable(new byte[] {162, 7, 102, 106, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void setup()
    {
      TechTree.context = (TechTree.TechNode) null;
      TechTree.map = new ObjectMap();
      TechTree.all = new Seq();
    }

    [LineNumberTable(642)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static TechTree.TechNode node([In] UnlockableContent obj0, [In] Runnable obj1) => TechTree.node(obj0, obj0.researchRequirements(), obj1);

    [LineNumberTable(646)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static TechTree.TechNode node(
      [In] UnlockableContent obj0,
      [In] ItemStack[] obj1,
      [In] Runnable obj2)
    {
      return TechTree.node(obj0, obj1, (Seq) null, obj2);
    }

    [Signature("(Lmindustry/ctype/UnlockableContent;[Lmindustry/type/ItemStack;Larc/struct/Seq<Lmindustry/game/Objectives$Objective;>;Ljava/lang/Runnable;)Lmindustry/content/TechTree$TechNode;")]
    [LineNumberTable(new byte[] {162, 24, 109, 99, 173, 102, 102, 102, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static TechTree.TechNode node(
      [In] UnlockableContent obj0,
      [In] ItemStack[] obj1,
      [In] Seq obj2,
      [In] Runnable obj3)
    {
      TechTree.TechNode techNode = new TechTree.TechNode(TechTree.context, obj0, obj1);
      if (obj2 != null)
        techNode.objectives.addAll(obj2);
      TechTree.TechNode context = TechTree.context;
      TechTree.context = techNode;
      obj3.run();
      TechTree.context = context;
      return techNode;
    }

    [Signature("(Lmindustry/ctype/UnlockableContent;Larc/struct/Seq<Lmindustry/game/Objectives$Objective;>;Ljava/lang/Runnable;)Lmindustry/content/TechTree$TechNode;")]
    [LineNumberTable(672)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static TechTree.TechNode nodeProduce(
      [In] UnlockableContent obj0,
      [In] Seq obj1,
      [In] Runnable obj2)
    {
      return TechTree.node(obj0, obj0.researchRequirements(), obj1.and((object) new Objectives.Produce(obj0)), obj2);
    }

    [LineNumberTable(676)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static TechTree.TechNode nodeProduce([In] UnlockableContent obj0, [In] Runnable obj1) => TechTree.nodeProduce(obj0, new Seq(), obj1);

    [Signature("(Lmindustry/ctype/UnlockableContent;Larc/struct/Seq<Lmindustry/game/Objectives$Objective;>;Ljava/lang/Runnable;)Lmindustry/content/TechTree$TechNode;")]
    [LineNumberTable(664)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static TechTree.TechNode node([In] UnlockableContent obj0, [In] Seq obj1, [In] Runnable obj2) => TechTree.node(obj0, obj0.researchRequirements(), obj1, obj2);

    [LineNumberTable(668)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static TechTree.TechNode node([In] UnlockableContent obj0) => TechTree.node(obj0, (Runnable) new TechTree.__\u003C\u003EAnon1());

    [Modifiers]
    [LineNumberTable(new byte[] {159, 170, 245, 113, 245, 70, 245, 160, 183, 245, 160, 76, 245, 160, 92, 245, 160, 136, 245, 123})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u0024186()
    {
      TechTree.node((UnlockableContent) Blocks.conveyor, (Runnable) new TechTree.__\u003C\u003EAnon3());
      TechTree.node((UnlockableContent) Blocks.coreFoundation, (Runnable) new TechTree.__\u003C\u003EAnon4());
      TechTree.node((UnlockableContent) Blocks.mechanicalDrill, (Runnable) new TechTree.__\u003C\u003EAnon5());
      TechTree.node((UnlockableContent) Blocks.duo, (Runnable) new TechTree.__\u003C\u003EAnon6());
      TechTree.node((UnlockableContent) Blocks.groundFactory, (Runnable) new TechTree.__\u003C\u003EAnon7());
      TechTree.node((UnlockableContent) SectorPresets.groundZero, (Runnable) new TechTree.__\u003C\u003EAnon8());
      TechTree.nodeProduce((UnlockableContent) Items.copper, (Runnable) new TechTree.__\u003C\u003EAnon9());
    }

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024node\u0024187()
    {
    }

    [Modifiers]
    [LineNumberTable(685)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static RuntimeException lambda\u0024getNotNull\u0024188(
      [In] UnlockableContent obj0)
    {
      return new RuntimeException(new StringBuilder().append((object) obj0).append(" does not have a tech node").toString());
    }

    [Modifiers]
    [LineNumberTable(new byte[] {159, 172, 245, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002416() => TechTree.node((UnlockableContent) Blocks.junction, (Runnable) new TechTree.__\u003C\u003EAnon173());

    [Modifiers]
    [LineNumberTable(new byte[] {28, 181})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002418() => TechTree.node((UnlockableContent) Blocks.coreNucleus, (Runnable) new TechTree.__\u003C\u003EAnon172());

    [Modifiers]
    [LineNumberTable(new byte[] {35, 245, 92, 245, 160, 96, 255, 14, 119})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002483()
    {
      TechTree.node((UnlockableContent) Blocks.mechanicalPump, (Runnable) new TechTree.__\u003C\u003EAnon108());
      TechTree.node((UnlockableContent) Blocks.graphitePress, (Runnable) new TechTree.__\u003C\u003EAnon109());
      TechTree.node((UnlockableContent) Blocks.combustionGenerator, Seq.with((object[]) new Objectives.Objective[1]
      {
        (Objectives.Objective) new Objectives.Research((UnlockableContent) Items.coal)
      }), (Runnable) new TechTree.__\u003C\u003EAnon110());
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 153, 245, 90, 245, 84, 245, 91})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u0024111()
    {
      TechTree.node((UnlockableContent) Blocks.copperWall, (Runnable) new TechTree.__\u003C\u003EAnon81());
      TechTree.node((UnlockableContent) Blocks.scatter, (Runnable) new TechTree.__\u003C\u003EAnon82());
      TechTree.node((UnlockableContent) Blocks.scorch, (Runnable) new TechTree.__\u003C\u003EAnon83());
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 229, 213, 245, 100, 245, 104, 255, 14, 73})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u0024149()
    {
      TechTree.node((UnlockableContent) Blocks.commandCenter, (Runnable) new TechTree.__\u003C\u003EAnon44());
      TechTree.node((UnlockableContent) UnitTypes.dagger, (Runnable) new TechTree.__\u003C\u003EAnon45());
      TechTree.node((UnlockableContent) Blocks.airFactory, (Runnable) new TechTree.__\u003C\u003EAnon46());
      TechTree.node((UnlockableContent) Blocks.additiveReconstructor, Seq.with((object[]) new Objectives.Objective[1]
      {
        (Objectives.Objective) new Objectives.SectorComplete(SectorPresets.biomassFacility)
      }), (Runnable) new TechTree.__\u003C\u003EAnon47());
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 65, 255, 40, 160, 133})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u0024165() => TechTree.node((UnlockableContent) SectorPresets.frozenForest, Seq.with((object[]) new Objectives.Objective[3]
    {
      (Objectives.Objective) new Objectives.SectorComplete(SectorPresets.groundZero),
      (Objectives.Objective) new Objectives.Research((UnlockableContent) Blocks.junction),
      (Objectives.Objective) new Objectives.Research((UnlockableContent) Blocks.router)
    }), (Runnable) new TechTree.__\u003C\u003EAnon29());

    [Modifiers]
    [LineNumberTable(new byte[] {161, 201, 213, 245, 86, 245, 95})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u0024185()
    {
      TechTree.nodeProduce((UnlockableContent) Liquids.water, (Runnable) new TechTree.__\u003C\u003EAnon10());
      TechTree.nodeProduce((UnlockableContent) Items.lead, (Runnable) new TechTree.__\u003C\u003EAnon11());
      TechTree.nodeProduce((UnlockableContent) Items.sand, (Runnable) new TechTree.__\u003C\u003EAnon12());
    }

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u0024166()
    {
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 206, 245, 80, 181})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u0024173()
    {
      TechTree.nodeProduce((UnlockableContent) Items.titanium, (Runnable) new TechTree.__\u003C\u003EAnon23());
      TechTree.nodeProduce((UnlockableContent) Items.metaglass, (Runnable) new TechTree.__\u003C\u003EAnon24());
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 228, 245, 70, 245, 87})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u0024184()
    {
      TechTree.nodeProduce((UnlockableContent) Items.scrap, (Runnable) new TechTree.__\u003C\u003EAnon13());
      TechTree.nodeProduce((UnlockableContent) Items.coal, (Runnable) new TechTree.__\u003C\u003EAnon14());
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 229, 181})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u0024175() => TechTree.nodeProduce((UnlockableContent) Liquids.slag, (Runnable) new TechTree.__\u003C\u003EAnon22());

    [Modifiers]
    [LineNumberTable(new byte[] {161, 235, 245, 70, 245, 70, 213, 245, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u0024183()
    {
      TechTree.nodeProduce((UnlockableContent) Items.graphite, (Runnable) new TechTree.__\u003C\u003EAnon15());
      TechTree.nodeProduce((UnlockableContent) Items.pyratite, (Runnable) new TechTree.__\u003C\u003EAnon16());
      TechTree.nodeProduce((UnlockableContent) Items.sporePod, (Runnable) new TechTree.__\u003C\u003EAnon17());
      TechTree.nodeProduce((UnlockableContent) Liquids.oil, (Runnable) new TechTree.__\u003C\u003EAnon18());
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 236, 181})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u0024177() => TechTree.nodeProduce((UnlockableContent) Items.silicon, (Runnable) new TechTree.__\u003C\u003EAnon21());

    [Modifiers]
    [LineNumberTable(new byte[] {161, 242, 181})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u0024179() => TechTree.nodeProduce((UnlockableContent) Items.blastCompound, (Runnable) new TechTree.__\u003C\u003EAnon20());

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u0024180()
    {
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 252, 181})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u0024182() => TechTree.nodeProduce((UnlockableContent) Items.plastanium, (Runnable) new TechTree.__\u003C\u003EAnon19());

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u0024181()
    {
    }

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u0024178()
    {
    }

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u0024176()
    {
    }

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u0024174()
    {
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 207, 213, 245, 73})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u0024171()
    {
      TechTree.nodeProduce((UnlockableContent) Liquids.cryofluid, (Runnable) new TechTree.__\u003C\u003EAnon25());
      TechTree.nodeProduce((UnlockableContent) Items.thorium, (Runnable) new TechTree.__\u003C\u003EAnon26());
    }

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u0024172()
    {
    }

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u0024167()
    {
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 212, 213, 181})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u0024170()
    {
      TechTree.nodeProduce((UnlockableContent) Items.surgeAlloy, (Runnable) new TechTree.__\u003C\u003EAnon27());
      TechTree.nodeProduce((UnlockableContent) Items.phaseFabric, (Runnable) new TechTree.__\u003C\u003EAnon28());
    }

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u0024168()
    {
    }

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u0024169()
    {
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 70, 255, 40, 160, 97, 255, 66, 94})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u0024164()
    {
      TechTree.node((UnlockableContent) SectorPresets.craters, Seq.with((object[]) new Objectives.Objective[3]
      {
        (Objectives.Objective) new Objectives.SectorComplete(SectorPresets.frozenForest),
        (Objectives.Objective) new Objectives.Research((UnlockableContent) Blocks.mender),
        (Objectives.Objective) new Objectives.Research((UnlockableContent) Blocks.combustionGenerator)
      }), (Runnable) new TechTree.__\u003C\u003EAnon30());
      TechTree.node((UnlockableContent) SectorPresets.biomassFacility, Seq.with((object[]) new Objectives.Objective[5]
      {
        (Objectives.Objective) new Objectives.SectorComplete(SectorPresets.frozenForest),
        (Objectives.Objective) new Objectives.Research((UnlockableContent) Blocks.powerNode),
        (Objectives.Objective) new Objectives.Research((UnlockableContent) Blocks.steamGenerator),
        (Objectives.Objective) new Objectives.Research((UnlockableContent) Blocks.scatter),
        (Objectives.Objective) new Objectives.Research((UnlockableContent) Blocks.graphitePress)
      }), (Runnable) new TechTree.__\u003C\u003EAnon31());
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 75, 255, 66, 160, 79, 255, 92, 75})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u0024159()
    {
      TechTree.node((UnlockableContent) SectorPresets.ruinousShores, Seq.with((object[]) new Objectives.Objective[5]
      {
        (Objectives.Objective) new Objectives.SectorComplete(SectorPresets.craters),
        (Objectives.Objective) new Objectives.Research((UnlockableContent) Blocks.graphitePress),
        (Objectives.Objective) new Objectives.Research((UnlockableContent) Blocks.combustionGenerator),
        (Objectives.Objective) new Objectives.Research((UnlockableContent) Blocks.kiln),
        (Objectives.Objective) new Objectives.Research((UnlockableContent) Blocks.mechanicalPump)
      }), (Runnable) new TechTree.__\u003C\u003EAnon35());
      TechTree.node((UnlockableContent) SectorPresets.overgrowth, Seq.with((object[]) new Objectives.Objective[7]
      {
        (Objectives.Objective) new Objectives.SectorComplete(SectorPresets.craters),
        (Objectives.Objective) new Objectives.SectorComplete(SectorPresets.fungalPass),
        (Objectives.Objective) new Objectives.Research((UnlockableContent) Blocks.cultivator),
        (Objectives.Objective) new Objectives.Research((UnlockableContent) Blocks.sporePress),
        (Objectives.Objective) new Objectives.Research((UnlockableContent) Blocks.additiveReconstructor),
        (Objectives.Objective) new Objectives.Research((UnlockableContent) UnitTypes.mace),
        (Objectives.Objective) new Objectives.Research((UnlockableContent) UnitTypes.flare)
      }), (Runnable) new TechTree.__\u003C\u003EAnon36());
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 174, 255, 40, 86})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u0024163() => TechTree.node((UnlockableContent) SectorPresets.stainedMountains, Seq.with((object[]) new Objectives.Objective[3]
    {
      (Objectives.Objective) new Objectives.SectorComplete(SectorPresets.biomassFacility),
      (Objectives.Objective) new Objectives.Research((UnlockableContent) Blocks.pneumaticDrill),
      (Objectives.Objective) new Objectives.Research((UnlockableContent) Blocks.siliconSmelter)
    }), (Runnable) new TechTree.__\u003C\u003EAnon32());

    [Modifiers]
    [LineNumberTable(new byte[] {161, 179, 255, 53, 80})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u0024162() => TechTree.node((UnlockableContent) SectorPresets.fungalPass, Seq.with((object[]) new Objectives.Objective[4]
    {
      (Objectives.Objective) new Objectives.SectorComplete(SectorPresets.stainedMountains),
      (Objectives.Objective) new Objectives.Research((UnlockableContent) Blocks.groundFactory),
      (Objectives.Objective) new Objectives.Research((UnlockableContent) Blocks.door),
      (Objectives.Objective) new Objectives.Research((UnlockableContent) Blocks.siliconSmelter)
    }), (Runnable) new TechTree.__\u003C\u003EAnon33());

    [Modifiers]
    [LineNumberTable(new byte[] {161, 185, 255, 66, 73})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u0024161() => TechTree.node((UnlockableContent) SectorPresets.nuclearComplex, Seq.with((object[]) new Objectives.Objective[5]
    {
      (Objectives.Objective) new Objectives.SectorComplete(SectorPresets.fungalPass),
      (Objectives.Objective) new Objectives.Research((UnlockableContent) Blocks.thermalGenerator),
      (Objectives.Objective) new Objectives.Research((UnlockableContent) Blocks.laserDrill),
      (Objectives.Objective) new Objectives.Research((UnlockableContent) Items.plastanium),
      (Objectives.Objective) new Objectives.Research((UnlockableContent) Blocks.swarmer)
    }), (Runnable) new TechTree.__\u003C\u003EAnon34());

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u0024160()
    {
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 82, 255, 66, 160, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u0024157() => TechTree.node((UnlockableContent) SectorPresets.windsweptIslands, Seq.with((object[]) new Objectives.Objective[5]
    {
      (Objectives.Objective) new Objectives.SectorComplete(SectorPresets.ruinousShores),
      (Objectives.Objective) new Objectives.Research((UnlockableContent) Blocks.pneumaticDrill),
      (Objectives.Objective) new Objectives.Research((UnlockableContent) Blocks.hail),
      (Objectives.Objective) new Objectives.Research((UnlockableContent) Blocks.siliconSmelter),
      (Objectives.Objective) new Objectives.Research((UnlockableContent) Blocks.steamGenerator)
    }), (Runnable) new TechTree.__\u003C\u003EAnon37());

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u0024158()
    {
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 89, 255, 53, 105, 255, 79, 75, 255, 79, 74})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u0024156()
    {
      TechTree.node((UnlockableContent) SectorPresets.tarFields, Seq.with((object[]) new Objectives.Objective[4]
      {
        (Objectives.Objective) new Objectives.SectorComplete(SectorPresets.windsweptIslands),
        (Objectives.Objective) new Objectives.Research((UnlockableContent) Blocks.coalCentrifuge),
        (Objectives.Objective) new Objectives.Research((UnlockableContent) Blocks.conduit),
        (Objectives.Objective) new Objectives.Research((UnlockableContent) Blocks.wave)
      }), (Runnable) new TechTree.__\u003C\u003EAnon38());
      TechTree.node((UnlockableContent) SectorPresets.extractionOutpost, Seq.with((object[]) new Objectives.Objective[6]
      {
        (Objectives.Objective) new Objectives.SectorComplete(SectorPresets.stainedMountains),
        (Objectives.Objective) new Objectives.SectorComplete(SectorPresets.windsweptIslands),
        (Objectives.Objective) new Objectives.Research((UnlockableContent) Blocks.groundFactory),
        (Objectives.Objective) new Objectives.Research((UnlockableContent) UnitTypes.nova),
        (Objectives.Objective) new Objectives.Research((UnlockableContent) Blocks.airFactory),
        (Objectives.Objective) new Objectives.Research((UnlockableContent) UnitTypes.mono)
      }), (Runnable) new TechTree.__\u003C\u003EAnon39());
      TechTree.node((UnlockableContent) SectorPresets.saltFlats, Seq.with((object[]) new Objectives.Objective[6]
      {
        (Objectives.Objective) new Objectives.SectorComplete(SectorPresets.windsweptIslands),
        (Objectives.Objective) new Objectives.Research((UnlockableContent) Blocks.commandCenter),
        (Objectives.Objective) new Objectives.Research((UnlockableContent) Blocks.groundFactory),
        (Objectives.Objective) new Objectives.Research((UnlockableContent) Blocks.additiveReconstructor),
        (Objectives.Objective) new Objectives.Research((UnlockableContent) Blocks.airFactory),
        (Objectives.Objective) new Objectives.Research((UnlockableContent) Blocks.door)
      }), (Runnable) new TechTree.__\u003C\u003EAnon40());
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 95, 255, 66, 97})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u0024153() => TechTree.node((UnlockableContent) SectorPresets.impact0078, Seq.with((object[]) new Objectives.Objective[5]
    {
      (Objectives.Objective) new Objectives.SectorComplete(SectorPresets.tarFields),
      (Objectives.Objective) new Objectives.Research((UnlockableContent) Items.thorium),
      (Objectives.Objective) new Objectives.Research((UnlockableContent) Blocks.lancer),
      (Objectives.Objective) new Objectives.Research((UnlockableContent) Blocks.salvo),
      (Objectives.Objective) new Objectives.Research((UnlockableContent) Blocks.coreFoundation)
    }), (Runnable) new TechTree.__\u003C\u003EAnon41());

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u0024154()
    {
    }

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u0024155()
    {
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 102, 255, 53, 89})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u0024152() => TechTree.node((UnlockableContent) SectorPresets.desolateRift, Seq.with((object[]) new Objectives.Objective[4]
    {
      (Objectives.Objective) new Objectives.SectorComplete(SectorPresets.impact0078),
      (Objectives.Objective) new Objectives.Research((UnlockableContent) Blocks.thermalGenerator),
      (Objectives.Objective) new Objectives.Research((UnlockableContent) Blocks.thoriumReactor),
      (Objectives.Objective) new Objectives.Research((UnlockableContent) Blocks.coreNucleus)
    }), (Runnable) new TechTree.__\u003C\u003EAnon42());

    [Modifiers]
    [LineNumberTable(new byte[] {161, 108, 255, 160, 125, 82})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u0024151() => TechTree.node((UnlockableContent) SectorPresets.planetaryTerminal, Seq.with((object[]) new Objectives.Objective[14]
    {
      (Objectives.Objective) new Objectives.SectorComplete(SectorPresets.desolateRift),
      (Objectives.Objective) new Objectives.SectorComplete(SectorPresets.nuclearComplex),
      (Objectives.Objective) new Objectives.SectorComplete(SectorPresets.overgrowth),
      (Objectives.Objective) new Objectives.SectorComplete(SectorPresets.extractionOutpost),
      (Objectives.Objective) new Objectives.SectorComplete(SectorPresets.saltFlats),
      (Objectives.Objective) new Objectives.Research((UnlockableContent) UnitTypes.risso),
      (Objectives.Objective) new Objectives.Research((UnlockableContent) UnitTypes.minke),
      (Objectives.Objective) new Objectives.Research((UnlockableContent) UnitTypes.bryde),
      (Objectives.Objective) new Objectives.Research((UnlockableContent) Blocks.spectre),
      (Objectives.Objective) new Objectives.Research((UnlockableContent) Blocks.launchPad),
      (Objectives.Objective) new Objectives.Research((UnlockableContent) Blocks.massDriver),
      (Objectives.Objective) new Objectives.Research((UnlockableContent) Blocks.impactReactor),
      (Objectives.Objective) new Objectives.Research((UnlockableContent) Blocks.additiveReconstructor),
      (Objectives.Objective) new Objectives.Research((UnlockableContent) Blocks.exponentialReconstructor)
    }), (Runnable) new TechTree.__\u003C\u003EAnon43());

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u0024150()
    {
    }

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u0024112()
    {
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 234, 245, 74, 245, 76, 245, 75})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u0024127()
    {
      TechTree.node((UnlockableContent) UnitTypes.mace, (Runnable) new TechTree.__\u003C\u003EAnon67());
      TechTree.node((UnlockableContent) UnitTypes.nova, (Runnable) new TechTree.__\u003C\u003EAnon68());
      TechTree.node((UnlockableContent) UnitTypes.crawler, (Runnable) new TechTree.__\u003C\u003EAnon69());
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 14, 245, 88, 255, 14, 77})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u0024144()
    {
      TechTree.node((UnlockableContent) UnitTypes.flare, (Runnable) new TechTree.__\u003C\u003EAnon51());
      TechTree.node((UnlockableContent) Blocks.navalFactory, Seq.with((object[]) new Objectives.Objective[1]
      {
        (Objectives.Objective) new Objectives.SectorComplete(SectorPresets.ruinousShores)
      }), (Runnable) new TechTree.__\u003C\u003EAnon52());
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 54, 245, 71})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u0024148() => TechTree.node((UnlockableContent) Blocks.multiplicativeReconstructor, (Runnable) new TechTree.__\u003C\u003EAnon48());

    [Modifiers]
    [LineNumberTable(new byte[] {161, 55, 255, 14, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u0024147() => TechTree.node((UnlockableContent) Blocks.exponentialReconstructor, Seq.with((object[]) new Objectives.Objective[1]
    {
      (Objectives.Objective) new Objectives.SectorComplete(SectorPresets.overgrowth)
    }), (Runnable) new TechTree.__\u003C\u003EAnon49());

    [Modifiers]
    [LineNumberTable(new byte[] {161, 56, 181})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u0024146() => TechTree.node((UnlockableContent) Blocks.tetrativeReconstructor, (Runnable) new TechTree.__\u003C\u003EAnon50());

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u0024145()
    {
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 15, 245, 74, 245, 75})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u0024137()
    {
      TechTree.node((UnlockableContent) UnitTypes.horizon, (Runnable) new TechTree.__\u003C\u003EAnon58());
      TechTree.node((UnlockableContent) UnitTypes.mono, (Runnable) new TechTree.__\u003C\u003EAnon59());
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 39, 245, 75})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u0024143() => TechTree.node((UnlockableContent) UnitTypes.risso, (Runnable) new TechTree.__\u003C\u003EAnon53());

    [Modifiers]
    [LineNumberTable(new byte[] {161, 40, 245, 73})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u0024142() => TechTree.node((UnlockableContent) UnitTypes.minke, (Runnable) new TechTree.__\u003C\u003EAnon54());

    [Modifiers]
    [LineNumberTable(new byte[] {161, 41, 245, 71})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u0024141() => TechTree.node((UnlockableContent) UnitTypes.bryde, (Runnable) new TechTree.__\u003C\u003EAnon55());

    [Modifiers]
    [LineNumberTable(new byte[] {161, 42, 245, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u0024140() => TechTree.node((UnlockableContent) UnitTypes.sei, (Runnable) new TechTree.__\u003C\u003EAnon56());

    [Modifiers]
    [LineNumberTable(new byte[] {161, 43, 181})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u0024139() => TechTree.node((UnlockableContent) UnitTypes.omura, (Runnable) new TechTree.__\u003C\u003EAnon57());

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u0024138()
    {
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 16, 245, 71})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u0024131() => TechTree.node((UnlockableContent) UnitTypes.zenith, (Runnable) new TechTree.__\u003C\u003EAnon64());

    [Modifiers]
    [LineNumberTable(new byte[] {161, 26, 245, 73})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u0024136() => TechTree.node((UnlockableContent) UnitTypes.poly, (Runnable) new TechTree.__\u003C\u003EAnon60());

    [Modifiers]
    [LineNumberTable(new byte[] {161, 27, 245, 71})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u0024135() => TechTree.node((UnlockableContent) UnitTypes.mega, (Runnable) new TechTree.__\u003C\u003EAnon61());

    [Modifiers]
    [LineNumberTable(new byte[] {161, 28, 245, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u0024134() => TechTree.node((UnlockableContent) UnitTypes.quad, (Runnable) new TechTree.__\u003C\u003EAnon62());

    [Modifiers]
    [LineNumberTable(new byte[] {161, 29, 181})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u0024133() => TechTree.node((UnlockableContent) UnitTypes.oct, (Runnable) new TechTree.__\u003C\u003EAnon63());

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u0024132()
    {
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 17, 245, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u0024130() => TechTree.node((UnlockableContent) UnitTypes.antumbra, (Runnable) new TechTree.__\u003C\u003EAnon65());

    [Modifiers]
    [LineNumberTable(new byte[] {161, 18, 181})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u0024129() => TechTree.node((UnlockableContent) UnitTypes.eclipse, (Runnable) new TechTree.__\u003C\u003EAnon66());

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u0024128()
    {
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 235, 245, 71})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u0024116() => TechTree.node((UnlockableContent) UnitTypes.fortress, (Runnable) new TechTree.__\u003C\u003EAnon78());

    [Modifiers]
    [LineNumberTable(new byte[] {160, 245, 245, 73})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u0024121() => TechTree.node((UnlockableContent) UnitTypes.pulsar, (Runnable) new TechTree.__\u003C\u003EAnon74());

    [Modifiers]
    [LineNumberTable(new byte[] {161, 1, 245, 73})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u0024126() => TechTree.node((UnlockableContent) UnitTypes.atrax, (Runnable) new TechTree.__\u003C\u003EAnon70());

    [Modifiers]
    [LineNumberTable(new byte[] {161, 2, 245, 71})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u0024125() => TechTree.node((UnlockableContent) UnitTypes.spiroct, (Runnable) new TechTree.__\u003C\u003EAnon71());

    [Modifiers]
    [LineNumberTable(new byte[] {161, 3, 245, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u0024124() => TechTree.node((UnlockableContent) UnitTypes.arkyid, (Runnable) new TechTree.__\u003C\u003EAnon72());

    [Modifiers]
    [LineNumberTable(new byte[] {161, 4, 181})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u0024123() => TechTree.node((UnlockableContent) UnitTypes.toxopid, (Runnable) new TechTree.__\u003C\u003EAnon73());

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u0024122()
    {
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 246, 245, 71})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u0024120() => TechTree.node((UnlockableContent) UnitTypes.quasar, (Runnable) new TechTree.__\u003C\u003EAnon75());

    [Modifiers]
    [LineNumberTable(new byte[] {160, 247, 245, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u0024119() => TechTree.node((UnlockableContent) UnitTypes.vela, (Runnable) new TechTree.__\u003C\u003EAnon76());

    [Modifiers]
    [LineNumberTable(new byte[] {160, 248, 181})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u0024118() => TechTree.node((UnlockableContent) UnitTypes.corvus, (Runnable) new TechTree.__\u003C\u003EAnon77());

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u0024117()
    {
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 236, 245, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u0024115() => TechTree.node((UnlockableContent) UnitTypes.scepter, (Runnable) new TechTree.__\u003C\u003EAnon79());

    [Modifiers]
    [LineNumberTable(new byte[] {160, 237, 181})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u0024114() => TechTree.node((UnlockableContent) UnitTypes.reign, (Runnable) new TechTree.__\u003C\u003EAnon80());

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u0024113()
    {
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 154, 245, 87})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002492() => TechTree.node((UnlockableContent) Blocks.copperWallLarge, (Runnable) new TechTree.__\u003C\u003EAnon100());

    [Modifiers]
    [LineNumberTable(new byte[] {160, 180, 255, 14, 81})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u0024100() => TechTree.node((UnlockableContent) Blocks.hail, Seq.with((object[]) new Objectives.Objective[1]
    {
      (Objectives.Objective) new Objectives.SectorComplete(SectorPresets.craters)
    }), (Runnable) new TechTree.__\u003C\u003EAnon93());

    [Modifiers]
    [LineNumberTable(new byte[] {160, 200, 245, 89})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u0024110() => TechTree.node((UnlockableContent) Blocks.arc, (Runnable) new TechTree.__\u003C\u003EAnon84());

    [Modifiers]
    [LineNumberTable(new byte[] {160, 201, 245, 76, 245, 75})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u0024109()
    {
      TechTree.node((UnlockableContent) Blocks.wave, (Runnable) new TechTree.__\u003C\u003EAnon85());
      TechTree.node((UnlockableContent) Blocks.lancer, (Runnable) new TechTree.__\u003C\u003EAnon86());
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 202, 245, 70, 181})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u0024104()
    {
      TechTree.node((UnlockableContent) Blocks.parallax, (Runnable) new TechTree.__\u003C\u003EAnon90());
      TechTree.node((UnlockableContent) Blocks.tsunami, (Runnable) new TechTree.__\u003C\u003EAnon91());
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 214, 245, 70, 181})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u0024108()
    {
      TechTree.node((UnlockableContent) Blocks.meltdown, (Runnable) new TechTree.__\u003C\u003EAnon87());
      TechTree.node((UnlockableContent) Blocks.shockMine, (Runnable) new TechTree.__\u003C\u003EAnon88());
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 215, 181})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u0024106() => TechTree.node((UnlockableContent) Blocks.foreshadow, (Runnable) new TechTree.__\u003C\u003EAnon89());

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u0024107()
    {
    }

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u0024105()
    {
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 203, 181})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u0024102() => TechTree.node((UnlockableContent) Blocks.segment, (Runnable) new TechTree.__\u003C\u003EAnon92());

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u0024103()
    {
    }

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u0024101()
    {
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 181, 245, 79})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002499() => TechTree.node((UnlockableContent) Blocks.salvo, (Runnable) new TechTree.__\u003C\u003EAnon94());

    [Modifiers]
    [LineNumberTable(new byte[] {160, 182, 245, 72, 245, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002498()
    {
      TechTree.node((UnlockableContent) Blocks.swarmer, (Runnable) new TechTree.__\u003C\u003EAnon95());
      TechTree.node((UnlockableContent) Blocks.ripple, (Runnable) new TechTree.__\u003C\u003EAnon96());
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 183, 245, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002495() => TechTree.node((UnlockableContent) Blocks.cyclone, (Runnable) new TechTree.__\u003C\u003EAnon98());

    [Modifiers]
    [LineNumberTable(new byte[] {160, 191, 181})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002497() => TechTree.node((UnlockableContent) Blocks.fuse, (Runnable) new TechTree.__\u003C\u003EAnon97());

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002496()
    {
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 184, 191, 14})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002494() => TechTree.node((UnlockableContent) Blocks.spectre, Seq.with((object[]) new Objectives.Objective[1]
    {
      (Objectives.Objective) new Objectives.SectorComplete(SectorPresets.nuclearComplex)
    }), (Runnable) new TechTree.__\u003C\u003EAnon99());

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002493()
    {
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 155, 245, 85})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002491() => TechTree.node((UnlockableContent) Blocks.titaniumWall, (Runnable) new TechTree.__\u003C\u003EAnon101());

    [Modifiers]
    [LineNumberTable(new byte[] {160, 156, 139, 181, 245, 69, 245, 73})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002490()
    {
      TechTree.node((UnlockableContent) Blocks.titaniumWallLarge);
      TechTree.node((UnlockableContent) Blocks.door, (Runnable) new TechTree.__\u003C\u003EAnon102());
      TechTree.node((UnlockableContent) Blocks.plastaniumWall, (Runnable) new TechTree.__\u003C\u003EAnon103());
      TechTree.node((UnlockableContent) Blocks.thoriumWall, (Runnable) new TechTree.__\u003C\u003EAnon104());
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 159, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002484() => TechTree.node((UnlockableContent) Blocks.doorLarge);

    [Modifiers]
    [LineNumberTable(new byte[] {160, 162, 181})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002486() => TechTree.node((UnlockableContent) Blocks.plastaniumWallLarge, (Runnable) new TechTree.__\u003C\u003EAnon107());

    [Modifiers]
    [LineNumberTable(new byte[] {160, 167, 107, 245, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002489()
    {
      TechTree.node((UnlockableContent) Blocks.thoriumWallLarge);
      TechTree.node((UnlockableContent) Blocks.surgeWall, (Runnable) new TechTree.__\u003C\u003EAnon105());
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 169, 107, 181})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002488()
    {
      TechTree.node((UnlockableContent) Blocks.surgeWallLarge);
      TechTree.node((UnlockableContent) Blocks.phaseWall, (Runnable) new TechTree.__\u003C\u003EAnon106());
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 171, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002487() => TechTree.node((UnlockableContent) Blocks.phaseWallLarge);

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002485()
    {
    }

    [Modifiers]
    [LineNumberTable(new byte[] {36, 245, 89})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002427() => TechTree.node((UnlockableContent) Blocks.conduit, (Runnable) new TechTree.__\u003C\u003EAnon164());

    [Modifiers]
    [LineNumberTable(new byte[] {64, 255, 14, 82, 245, 70, 245, 160, 68})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002461()
    {
      TechTree.node((UnlockableContent) Blocks.pneumaticDrill, Seq.with((object[]) new Objectives.Objective[1]
      {
        (Objectives.Objective) new Objectives.SectorComplete(SectorPresets.frozenForest)
      }), (Runnable) new TechTree.__\u003C\u003EAnon131());
      TechTree.node((UnlockableContent) Blocks.pyratiteMixer, (Runnable) new TechTree.__\u003C\u003EAnon132());
      TechTree.node((UnlockableContent) Blocks.siliconSmelter, (Runnable) new TechTree.__\u003C\u003EAnon133());
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 96, 245, 117})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002482() => TechTree.node((UnlockableContent) Blocks.powerNode, (Runnable) new TechTree.__\u003C\u003EAnon111());

    [Modifiers]
    [LineNumberTable(new byte[] {160, 97, 245, 72, 245, 70, 245, 80, 255, 14, 80, 245, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002481()
    {
      TechTree.node((UnlockableContent) Blocks.powerNodeLarge, (Runnable) new TechTree.__\u003C\u003EAnon112());
      TechTree.node((UnlockableContent) Blocks.battery, (Runnable) new TechTree.__\u003C\u003EAnon113());
      TechTree.node((UnlockableContent) Blocks.mender, (Runnable) new TechTree.__\u003C\u003EAnon114());
      TechTree.node((UnlockableContent) Blocks.steamGenerator, Seq.with((object[]) new Objectives.Objective[1]
      {
        (Objectives.Objective) new Objectives.SectorComplete(SectorPresets.craters)
      }), (Runnable) new TechTree.__\u003C\u003EAnon115());
      TechTree.node((UnlockableContent) Blocks.solarPanel, (Runnable) new TechTree.__\u003C\u003EAnon116());
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 98, 245, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002464() => TechTree.node((UnlockableContent) Blocks.diode, (Runnable) new TechTree.__\u003C\u003EAnon129());

    [Modifiers]
    [LineNumberTable(new byte[] {160, 106, 181})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002466() => TechTree.node((UnlockableContent) Blocks.batteryLarge, (Runnable) new TechTree.__\u003C\u003EAnon128());

    [Modifiers]
    [LineNumberTable(new byte[] {160, 112, 245, 77})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002472() => TechTree.node((UnlockableContent) Blocks.mendProjector, (Runnable) new TechTree.__\u003C\u003EAnon123());

    [Modifiers]
    [LineNumberTable(new byte[] {160, 128, 245, 77})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002478() => TechTree.node((UnlockableContent) Blocks.thermalGenerator, (Runnable) new TechTree.__\u003C\u003EAnon118());

    [Modifiers]
    [LineNumberTable(new byte[] {160, 144, 181})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002480() => TechTree.node((UnlockableContent) Blocks.largeSolarPanel, (Runnable) new TechTree.__\u003C\u003EAnon117());

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002479()
    {
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 129, 245, 75})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002477() => TechTree.node((UnlockableContent) Blocks.differentialGenerator, (Runnable) new TechTree.__\u003C\u003EAnon119());

    [Modifiers]
    [LineNumberTable(new byte[] {160, 130, 255, 14, 73})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002476() => TechTree.node((UnlockableContent) Blocks.thoriumReactor, Seq.with((object[]) new Objectives.Objective[1]
    {
      (Objectives.Objective) new Objectives.Research((UnlockableContent) Liquids.cryofluid)
    }), (Runnable) new TechTree.__\u003C\u003EAnon120());

    [Modifiers]
    [LineNumberTable(new byte[] {160, 131, 213, 181})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002475()
    {
      TechTree.node((UnlockableContent) Blocks.impactReactor, (Runnable) new TechTree.__\u003C\u003EAnon121());
      TechTree.node((UnlockableContent) Blocks.rtgGenerator, (Runnable) new TechTree.__\u003C\u003EAnon122());
    }

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002473()
    {
    }

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002474()
    {
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 113, 255, 14, 72, 181})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002471()
    {
      TechTree.node((UnlockableContent) Blocks.forceProjector, Seq.with((object[]) new Objectives.Objective[1]
      {
        (Objectives.Objective) new Objectives.SectorComplete(SectorPresets.impact0078)
      }), (Runnable) new TechTree.__\u003C\u003EAnon124());
      TechTree.node((UnlockableContent) Blocks.repairPoint, (Runnable) new TechTree.__\u003C\u003EAnon125());
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 114, 255, 14, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002469() => TechTree.node((UnlockableContent) Blocks.overdriveProjector, Seq.with((object[]) new Objectives.Objective[1]
    {
      (Objectives.Objective) new Objectives.SectorComplete(SectorPresets.impact0078)
    }), (Runnable) new TechTree.__\u003C\u003EAnon126());

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002470()
    {
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 115, 191, 14})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002468() => TechTree.node((UnlockableContent) Blocks.overdriveDome, Seq.with((object[]) new Objectives.Objective[1]
    {
      (Objectives.Objective) new Objectives.SectorComplete(SectorPresets.impact0078)
    }), (Runnable) new TechTree.__\u003C\u003EAnon127());

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002467()
    {
    }

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002465()
    {
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 99, 181})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002463() => TechTree.node((UnlockableContent) Blocks.surgeTower, (Runnable) new TechTree.__\u003C\u003EAnon130());

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002462()
    {
    }

    [Modifiers]
    [LineNumberTable(new byte[] {65, 223, 14, 245, 75})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002433()
    {
      TechTree.node((UnlockableContent) Blocks.cultivator, Seq.with((object[]) new Objectives.Objective[1]
      {
        (Objectives.Objective) new Objectives.SectorComplete(SectorPresets.biomassFacility)
      }), (Runnable) new TechTree.__\u003C\u003EAnon159());
      TechTree.node((UnlockableContent) Blocks.laserDrill, (Runnable) new TechTree.__\u003C\u003EAnon160());
    }

    [Modifiers]
    [LineNumberTable(new byte[] {83, 181})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002435() => TechTree.node((UnlockableContent) Blocks.blastMixer, (Runnable) new TechTree.__\u003C\u003EAnon158());

    [Modifiers]
    [LineNumberTable(new byte[] {90, 245, 80, 255, 14, 86, 245, 88, 181})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002460()
    {
      TechTree.node((UnlockableContent) Blocks.sporePress, (Runnable) new TechTree.__\u003C\u003EAnon134());
      TechTree.node((UnlockableContent) Blocks.kiln, Seq.with((object[]) new Objectives.Objective[1]
      {
        (Objectives.Objective) new Objectives.SectorComplete(SectorPresets.craters)
      }), (Runnable) new TechTree.__\u003C\u003EAnon135());
      TechTree.node((UnlockableContent) Blocks.microProcessor, (Runnable) new TechTree.__\u003C\u003EAnon136());
      TechTree.node((UnlockableContent) Blocks.illuminator, (Runnable) new TechTree.__\u003C\u003EAnon137());
    }

    [Modifiers]
    [LineNumberTable(new byte[] {91, 245, 72, 255, 14, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002441()
    {
      TechTree.node((UnlockableContent) Blocks.coalCentrifuge, (Runnable) new TechTree.__\u003C\u003EAnon153());
      TechTree.node((UnlockableContent) Blocks.plastaniumCompressor, Seq.with((object[]) new Objectives.Objective[1]
      {
        (Objectives.Objective) new Objectives.SectorComplete(SectorPresets.windsweptIslands)
      }), (Runnable) new TechTree.__\u003C\u003EAnon154());
    }

    [Modifiers]
    [LineNumberTable(new byte[] {107, 245, 83})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002449() => TechTree.node((UnlockableContent) Blocks.pulverizer, (Runnable) new TechTree.__\u003C\u003EAnon146());

    [Modifiers]
    [LineNumberTable(new byte[] {160, 65, 245, 85})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002458() => TechTree.node((UnlockableContent) Blocks.switchBlock, (Runnable) new TechTree.__\u003C\u003EAnon138());

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002459()
    {
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 66, 245, 78, 245, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002457()
    {
      TechTree.node((UnlockableContent) Blocks.message, (Runnable) new TechTree.__\u003C\u003EAnon139());
      TechTree.node((UnlockableContent) Blocks.logicProcessor, (Runnable) new TechTree.__\u003C\u003EAnon140());
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 67, 245, 70, 245, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002454()
    {
      TechTree.node((UnlockableContent) Blocks.logicDisplay, (Runnable) new TechTree.__\u003C\u003EAnon142());
      TechTree.node((UnlockableContent) Blocks.memoryCell, (Runnable) new TechTree.__\u003C\u003EAnon143());
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 81, 181})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002456() => TechTree.node((UnlockableContent) Blocks.hyperProcessor, (Runnable) new TechTree.__\u003C\u003EAnon141());

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002455()
    {
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 68, 181})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002451() => TechTree.node((UnlockableContent) Blocks.largeLogicDisplay, (Runnable) new TechTree.__\u003C\u003EAnon145());

    [Modifiers]
    [LineNumberTable(new byte[] {160, 74, 181})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002453() => TechTree.node((UnlockableContent) Blocks.memoryBank, (Runnable) new TechTree.__\u003C\u003EAnon144());

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002452()
    {
    }

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002450()
    {
    }

    [Modifiers]
    [LineNumberTable(new byte[] {108, 245, 81})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002448() => TechTree.node((UnlockableContent) Blocks.incinerator, (Runnable) new TechTree.__\u003C\u003EAnon147());

    [Modifiers]
    [LineNumberTable(new byte[] {109, 245, 79})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002447() => TechTree.node((UnlockableContent) Blocks.melter, (Runnable) new TechTree.__\u003C\u003EAnon148());

    [Modifiers]
    [LineNumberTable(new byte[] {110, 213, 245, 70, 181})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002446()
    {
      TechTree.node((UnlockableContent) Blocks.surgeSmelter, (Runnable) new TechTree.__\u003C\u003EAnon149());
      TechTree.node((UnlockableContent) Blocks.separator, (Runnable) new TechTree.__\u003C\u003EAnon150());
      TechTree.node((UnlockableContent) Blocks.cryofluidMixer, (Runnable) new TechTree.__\u003C\u003EAnon151());
    }

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002442()
    {
    }

    [Modifiers]
    [LineNumberTable(new byte[] {115, 181})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002444() => TechTree.node((UnlockableContent) Blocks.disassembler, (Runnable) new TechTree.__\u003C\u003EAnon152());

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002445()
    {
    }

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002443()
    {
    }

    [Modifiers]
    [LineNumberTable(new byte[] {92, 245, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002438() => TechTree.node((UnlockableContent) Blocks.multiPress, (Runnable) new TechTree.__\u003C\u003EAnon156());

    [Modifiers]
    [LineNumberTable(new byte[] {100, 191, 14})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002440() => TechTree.node((UnlockableContent) Blocks.phaseWeaver, Seq.with((object[]) new Objectives.Objective[1]
    {
      (Objectives.Objective) new Objectives.SectorComplete(SectorPresets.tarFields)
    }), (Runnable) new TechTree.__\u003C\u003EAnon155());

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002439()
    {
    }

    [Modifiers]
    [LineNumberTable(new byte[] {93, 181})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002437() => TechTree.node((UnlockableContent) Blocks.siliconCrucible, (Runnable) new TechTree.__\u003C\u003EAnon157());

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002436()
    {
    }

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002434()
    {
    }

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002428()
    {
    }

    [Modifiers]
    [LineNumberTable(new byte[] {70, 223, 14, 255, 14, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002432()
    {
      TechTree.node((UnlockableContent) Blocks.blastDrill, Seq.with((object[]) new Objectives.Objective[1]
      {
        (Objectives.Objective) new Objectives.SectorComplete(SectorPresets.nuclearComplex)
      }), (Runnable) new TechTree.__\u003C\u003EAnon161());
      TechTree.node((UnlockableContent) Blocks.waterExtractor, Seq.with((object[]) new Objectives.Objective[1]
      {
        (Objectives.Objective) new Objectives.SectorComplete(SectorPresets.saltFlats)
      }), (Runnable) new TechTree.__\u003C\u003EAnon162());
    }

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002429()
    {
    }

    [Modifiers]
    [LineNumberTable(new byte[] {75, 181})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002431() => TechTree.node((UnlockableContent) Blocks.oilExtractor, (Runnable) new TechTree.__\u003C\u003EAnon163());

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002430()
    {
    }

    [Modifiers]
    [LineNumberTable(new byte[] {37, 245, 87})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002426() => TechTree.node((UnlockableContent) Blocks.liquidJunction, (Runnable) new TechTree.__\u003C\u003EAnon165());

    [Modifiers]
    [LineNumberTable(new byte[] {38, 245, 85})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002425() => TechTree.node((UnlockableContent) Blocks.liquidRouter, (Runnable) new TechTree.__\u003C\u003EAnon166());

    [Modifiers]
    [LineNumberTable(new byte[] {39, 139, 139, 255, 14, 79})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002424()
    {
      TechTree.node((UnlockableContent) Blocks.liquidTank);
      TechTree.node((UnlockableContent) Blocks.bridgeConduit);
      TechTree.node((UnlockableContent) Blocks.pulseConduit, Seq.with((object[]) new Objectives.Objective[1]
      {
        (Objectives.Objective) new Objectives.SectorComplete(SectorPresets.windsweptIslands)
      }), (Runnable) new TechTree.__\u003C\u003EAnon167());
    }

    [Modifiers]
    [LineNumberTable(new byte[] {44, 213, 213, 245, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002423()
    {
      TechTree.node((UnlockableContent) Blocks.phaseConduit, (Runnable) new TechTree.__\u003C\u003EAnon168());
      TechTree.node((UnlockableContent) Blocks.platedConduit, (Runnable) new TechTree.__\u003C\u003EAnon169());
      TechTree.node((UnlockableContent) Blocks.rotaryPump, (Runnable) new TechTree.__\u003C\u003EAnon170());
    }

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002419()
    {
    }

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002420()
    {
    }

    [Modifiers]
    [LineNumberTable(new byte[] {53, 181})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002422() => TechTree.node((UnlockableContent) Blocks.thermalPump, (Runnable) new TechTree.__\u003C\u003EAnon171());

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002421()
    {
    }

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002417()
    {
    }

    [Modifiers]
    [LineNumberTable(new byte[] {159, 173, 245, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002415() => TechTree.node((UnlockableContent) Blocks.router, (Runnable) new TechTree.__\u003C\u003EAnon174());

    [Modifiers]
    [LineNumberTable(new byte[] {159, 174, 255, 14, 70, 107, 245, 70, 255, 14, 71, 245, 85})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002414()
    {
      TechTree.node((UnlockableContent) Blocks.launchPad, Seq.with((object[]) new Objectives.Objective[1]
      {
        (Objectives.Objective) new Objectives.SectorComplete(SectorPresets.extractionOutpost)
      }), (Runnable) new TechTree.__\u003C\u003EAnon175());
      TechTree.node((UnlockableContent) Blocks.distributor);
      TechTree.node((UnlockableContent) Blocks.sorter, (Runnable) new TechTree.__\u003C\u003EAnon176());
      TechTree.node((UnlockableContent) Blocks.container, Seq.with((object[]) new Objectives.Objective[1]
      {
        (Objectives.Objective) new Objectives.SectorComplete(SectorPresets.biomassFacility)
      }), (Runnable) new TechTree.__\u003C\u003EAnon177());
      TechTree.node((UnlockableContent) Blocks.itemBridge, (Runnable) new TechTree.__\u003C\u003EAnon178());
    }

    [Modifiers]
    [LineNumberTable(new byte[] {159, 175, 191, 14})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u00241() => TechTree.node((UnlockableContent) Blocks.interplanetaryAccelerator, Seq.with((object[]) new Objectives.Objective[1]
    {
      (Objectives.Objective) new Objectives.SectorComplete(SectorPresets.planetaryTerminal)
    }), (Runnable) new TechTree.__\u003C\u003EAnon188());

    [Modifiers]
    [LineNumberTable(new byte[] {159, 182, 107, 181})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u00243()
    {
      TechTree.node((UnlockableContent) Blocks.invertedSorter);
      TechTree.node((UnlockableContent) Blocks.overflowGate, (Runnable) new TechTree.__\u003C\u003EAnon187());
    }

    [Modifiers]
    [LineNumberTable(new byte[] {159, 188, 107, 191, 14})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u00245()
    {
      TechTree.node((UnlockableContent) Blocks.unloader);
      TechTree.node((UnlockableContent) Blocks.vault, Seq.with((object[]) new Objectives.Objective[1]
      {
        (Objectives.Objective) new Objectives.SectorComplete(SectorPresets.stainedMountains)
      }), (Runnable) new TechTree.__\u003C\u003EAnon186());
    }

    [Modifiers]
    [LineNumberTable(new byte[] {3, 255, 14, 83})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002413() => TechTree.node((UnlockableContent) Blocks.titaniumConveyor, Seq.with((object[]) new Objectives.Objective[1]
    {
      (Objectives.Objective) new Objectives.SectorComplete(SectorPresets.craters)
    }), (Runnable) new TechTree.__\u003C\u003EAnon179());

    [Modifiers]
    [LineNumberTable(new byte[] {4, 245, 70, 245, 70, 245, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002412()
    {
      TechTree.node((UnlockableContent) Blocks.phaseConveyor, (Runnable) new TechTree.__\u003C\u003EAnon180());
      TechTree.node((UnlockableContent) Blocks.payloadConveyor, (Runnable) new TechTree.__\u003C\u003EAnon181());
      TechTree.node((UnlockableContent) Blocks.armoredConveyor, (Runnable) new TechTree.__\u003C\u003EAnon182());
    }

    [Modifiers]
    [LineNumberTable(new byte[] {5, 181})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u00247() => TechTree.node((UnlockableContent) Blocks.massDriver, (Runnable) new TechTree.__\u003C\u003EAnon185());

    [Modifiers]
    [LineNumberTable(new byte[] {11, 181})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u00249() => TechTree.node((UnlockableContent) Blocks.payloadRouter, (Runnable) new TechTree.__\u003C\u003EAnon184());

    [Modifiers]
    [LineNumberTable(new byte[] {17, 181})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002411() => TechTree.node((UnlockableContent) Blocks.plastaniumConveyor, (Runnable) new TechTree.__\u003C\u003EAnon183());

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002410()
    {
    }

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u00248()
    {
    }

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u00246()
    {
    }

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u00244()
    {
    }

    [Modifiers]
    [LineNumberTable(new byte[] {159, 184, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u00242() => TechTree.node((UnlockableContent) Blocks.underflowGate);

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u00240()
    {
    }

    [LineNumberTable(15)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public TechTree()
    {
    }

    [LineNumberTable(new byte[] {159, 166, 133, 249, 162, 92})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void load()
    {
      TechTree.setup();
      TechTree.root = TechTree.node((UnlockableContent) Blocks.coreShard, (Runnable) new TechTree.__\u003C\u003EAnon0());
    }

    [LineNumberTable(685)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static TechTree.TechNode getNotNull(UnlockableContent content) => (TechTree.TechNode) TechTree.map.getThrow((object) content, (Prov) new TechTree.__\u003C\u003EAnon2(content));

    [LineNumberTable(new byte[] {159, 138, 77, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static TechTree()
    {
      if (ByteCodeHelper.isAlreadyInited("mindustry.content.TechTree"))
        return;
      TechTree.map = new ObjectMap();
      TechTree.context = (TechTree.TechNode) null;
    }

    public class TechNode : Object
    {
      public int depth;
      [Nullable(new object[] {64, "Larc/util/Nullable;"})]
      public TechTree.TechNode parent;
      public UnlockableContent content;
      public ItemStack[] requirements;
      internal ItemStack[] __\u003C\u003EfinishedRequirements;
      [Signature("Larc/struct/Seq<Lmindustry/game/Objectives$Objective;>;")]
      public Seq objectives;
      [Signature("Larc/struct/Seq<Lmindustry/content/TechTree$TechNode;>;")]
      internal Seq __\u003C\u003Echildren;

      [LineNumberTable(new byte[] {162, 125, 116, 63, 52, 166})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void save()
      {
        ItemStack[] finishedRequirements = this.__\u003C\u003EfinishedRequirements;
        int length = finishedRequirements.Length;
        for (int index = 0; index < length; ++index)
        {
          ItemStack itemStack = finishedRequirements[index];
          Core.settings.put(new StringBuilder().append("req-").append(this.content.__\u003C\u003Ename).append("-").append(itemStack.item.__\u003C\u003Ename).toString(), (object) Integer.valueOf(itemStack.amount));
        }
      }

      [Modifiers]
      [LineNumberTable(new byte[] {162, 96, 105, 145})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024new\u00240([In] ObjectSet obj0, [In] UnlockableContent obj1)
      {
        if (!obj0.add((object) obj1))
          return;
        this.objectives.add((object) new Objectives.Research(obj1));
      }

      [LineNumberTable(new byte[] {162, 78, 232, 60, 139, 171, 143, 103, 103, 103, 116, 173, 106, 63, 74, 201, 166, 242, 70, 109, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public TechNode(
        [Nullable(new object[] {64, "Larc/util/Nullable;"})] TechTree.TechNode parent,
        UnlockableContent content,
        ItemStack[] requirements)
      {
        TechTree.TechNode techNode = this;
        this.objectives = new Seq();
        this.__\u003C\u003Echildren = new Seq();
        parent?.__\u003C\u003Echildren.add((object) this);
        this.parent = parent;
        this.content = content;
        this.requirements = requirements;
        this.depth = parent != null ? parent.depth + 1 : 0;
        this.__\u003C\u003EfinishedRequirements = new ItemStack[requirements.Length];
        for (int index1 = 0; index1 < requirements.Length; ++index1)
        {
          ItemStack[] finishedRequirements = this.__\u003C\u003EfinishedRequirements;
          int index2 = index1;
          ItemStack.__\u003Cclinit\u003E();
          ItemStack itemStack = new ItemStack(requirements[index1].item, Core.settings != null ? Core.settings.getInt(new StringBuilder().append("req-").append(content.__\u003C\u003Ename).append("-").append(requirements[index1].item.__\u003C\u003Ename).toString()) : 0);
          finishedRequirements[index2] = itemStack;
        }
        ObjectSet objectSet = new ObjectSet();
        content.getDependencies((Cons) new TechTree.TechNode.__\u003C\u003EAnon0(this, objectSet));
        TechTree.map.put((object) content, (object) this);
        TechTree.all.add((object) this);
      }

      [LineNumberTable(new byte[] {162, 107, 116, 39, 166, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void reset()
      {
        ItemStack[] finishedRequirements = this.__\u003C\u003EfinishedRequirements;
        int length = finishedRequirements.Length;
        for (int index = 0; index < length; ++index)
          finishedRequirements[index].amount = 0;
        this.save();
      }

      [LineNumberTable(new byte[] {162, 115, 108, 104, 146})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void remove()
      {
        TechTree.all.remove((object) this);
        if (this.parent == null)
          return;
        this.parent.__\u003C\u003Echildren.remove((object) this);
      }

      [Modifiers]
      public ItemStack[] finishedRequirements
      {
        [HideFromJava] get => this.__\u003C\u003EfinishedRequirements;
        [HideFromJava] [param: In] private set => this.__\u003C\u003EfinishedRequirements = value;
      }

      [Modifiers]
      public Seq children
      {
        [HideFromJava] get => this.__\u003C\u003Echildren;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Echildren = value;
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon0 : Cons
      {
        private readonly TechTree.TechNode arg\u00241;
        private readonly ObjectSet arg\u00242;

        internal __\u003C\u003EAnon0([In] TechTree.TechNode obj0, [In] ObjectSet obj1)
        {
          this.arg\u00241 = obj0;
          this.arg\u00242 = obj1;
        }

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024new\u00240(this.arg\u00242, (UnlockableContent) obj0);
      }
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Runnable
    {
      internal __\u003C\u003EAnon0()
      {
      }

      public void run() => TechTree.lambda\u0024load\u0024186();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Runnable
    {
      internal __\u003C\u003EAnon1()
      {
      }

      public void run() => TechTree.lambda\u0024node\u0024187();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon2 : Prov
    {
      private readonly UnlockableContent arg\u00241;

      internal __\u003C\u003EAnon2([In] UnlockableContent obj0) => this.arg\u00241 = obj0;

      public object get() => (object) TechTree.lambda\u0024getNotNull\u0024188(this.arg\u00241);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon3 : Runnable
    {
      internal __\u003C\u003EAnon3()
      {
      }

      public void run() => TechTree.lambda\u0024load\u002416();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon4 : Runnable
    {
      internal __\u003C\u003EAnon4()
      {
      }

      public void run() => TechTree.lambda\u0024load\u002418();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon5 : Runnable
    {
      internal __\u003C\u003EAnon5()
      {
      }

      public void run() => TechTree.lambda\u0024load\u002483();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon6 : Runnable
    {
      internal __\u003C\u003EAnon6()
      {
      }

      public void run() => TechTree.lambda\u0024load\u0024111();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon7 : Runnable
    {
      internal __\u003C\u003EAnon7()
      {
      }

      public void run() => TechTree.lambda\u0024load\u0024149();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon8 : Runnable
    {
      internal __\u003C\u003EAnon8()
      {
      }

      public void run() => TechTree.lambda\u0024load\u0024165();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon9 : Runnable
    {
      internal __\u003C\u003EAnon9()
      {
      }

      public void run() => TechTree.lambda\u0024load\u0024185();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon10 : Runnable
    {
      internal __\u003C\u003EAnon10()
      {
      }

      public void run() => TechTree.lambda\u0024load\u0024166();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon11 : Runnable
    {
      internal __\u003C\u003EAnon11()
      {
      }

      public void run() => TechTree.lambda\u0024load\u0024173();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon12 : Runnable
    {
      internal __\u003C\u003EAnon12()
      {
      }

      public void run() => TechTree.lambda\u0024load\u0024184();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon13 : Runnable
    {
      internal __\u003C\u003EAnon13()
      {
      }

      public void run() => TechTree.lambda\u0024load\u0024175();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon14 : Runnable
    {
      internal __\u003C\u003EAnon14()
      {
      }

      public void run() => TechTree.lambda\u0024load\u0024183();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon15 : Runnable
    {
      internal __\u003C\u003EAnon15()
      {
      }

      public void run() => TechTree.lambda\u0024load\u0024177();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon16 : Runnable
    {
      internal __\u003C\u003EAnon16()
      {
      }

      public void run() => TechTree.lambda\u0024load\u0024179();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon17 : Runnable
    {
      internal __\u003C\u003EAnon17()
      {
      }

      public void run() => TechTree.lambda\u0024load\u0024180();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon18 : Runnable
    {
      internal __\u003C\u003EAnon18()
      {
      }

      public void run() => TechTree.lambda\u0024load\u0024182();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon19 : Runnable
    {
      internal __\u003C\u003EAnon19()
      {
      }

      public void run() => TechTree.lambda\u0024load\u0024181();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon20 : Runnable
    {
      internal __\u003C\u003EAnon20()
      {
      }

      public void run() => TechTree.lambda\u0024load\u0024178();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon21 : Runnable
    {
      internal __\u003C\u003EAnon21()
      {
      }

      public void run() => TechTree.lambda\u0024load\u0024176();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon22 : Runnable
    {
      internal __\u003C\u003EAnon22()
      {
      }

      public void run() => TechTree.lambda\u0024load\u0024174();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon23 : Runnable
    {
      internal __\u003C\u003EAnon23()
      {
      }

      public void run() => TechTree.lambda\u0024load\u0024171();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon24 : Runnable
    {
      internal __\u003C\u003EAnon24()
      {
      }

      public void run() => TechTree.lambda\u0024load\u0024172();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon25 : Runnable
    {
      internal __\u003C\u003EAnon25()
      {
      }

      public void run() => TechTree.lambda\u0024load\u0024167();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon26 : Runnable
    {
      internal __\u003C\u003EAnon26()
      {
      }

      public void run() => TechTree.lambda\u0024load\u0024170();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon27 : Runnable
    {
      internal __\u003C\u003EAnon27()
      {
      }

      public void run() => TechTree.lambda\u0024load\u0024168();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon28 : Runnable
    {
      internal __\u003C\u003EAnon28()
      {
      }

      public void run() => TechTree.lambda\u0024load\u0024169();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon29 : Runnable
    {
      internal __\u003C\u003EAnon29()
      {
      }

      public void run() => TechTree.lambda\u0024load\u0024164();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon30 : Runnable
    {
      internal __\u003C\u003EAnon30()
      {
      }

      public void run() => TechTree.lambda\u0024load\u0024159();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon31 : Runnable
    {
      internal __\u003C\u003EAnon31()
      {
      }

      public void run() => TechTree.lambda\u0024load\u0024163();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon32 : Runnable
    {
      internal __\u003C\u003EAnon32()
      {
      }

      public void run() => TechTree.lambda\u0024load\u0024162();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon33 : Runnable
    {
      internal __\u003C\u003EAnon33()
      {
      }

      public void run() => TechTree.lambda\u0024load\u0024161();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon34 : Runnable
    {
      internal __\u003C\u003EAnon34()
      {
      }

      public void run() => TechTree.lambda\u0024load\u0024160();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon35 : Runnable
    {
      internal __\u003C\u003EAnon35()
      {
      }

      public void run() => TechTree.lambda\u0024load\u0024157();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon36 : Runnable
    {
      internal __\u003C\u003EAnon36()
      {
      }

      public void run() => TechTree.lambda\u0024load\u0024158();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon37 : Runnable
    {
      internal __\u003C\u003EAnon37()
      {
      }

      public void run() => TechTree.lambda\u0024load\u0024156();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon38 : Runnable
    {
      internal __\u003C\u003EAnon38()
      {
      }

      public void run() => TechTree.lambda\u0024load\u0024153();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon39 : Runnable
    {
      internal __\u003C\u003EAnon39()
      {
      }

      public void run() => TechTree.lambda\u0024load\u0024154();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon40 : Runnable
    {
      internal __\u003C\u003EAnon40()
      {
      }

      public void run() => TechTree.lambda\u0024load\u0024155();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon41 : Runnable
    {
      internal __\u003C\u003EAnon41()
      {
      }

      public void run() => TechTree.lambda\u0024load\u0024152();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon42 : Runnable
    {
      internal __\u003C\u003EAnon42()
      {
      }

      public void run() => TechTree.lambda\u0024load\u0024151();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon43 : Runnable
    {
      internal __\u003C\u003EAnon43()
      {
      }

      public void run() => TechTree.lambda\u0024load\u0024150();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon44 : Runnable
    {
      internal __\u003C\u003EAnon44()
      {
      }

      public void run() => TechTree.lambda\u0024load\u0024112();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon45 : Runnable
    {
      internal __\u003C\u003EAnon45()
      {
      }

      public void run() => TechTree.lambda\u0024load\u0024127();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon46 : Runnable
    {
      internal __\u003C\u003EAnon46()
      {
      }

      public void run() => TechTree.lambda\u0024load\u0024144();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon47 : Runnable
    {
      internal __\u003C\u003EAnon47()
      {
      }

      public void run() => TechTree.lambda\u0024load\u0024148();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon48 : Runnable
    {
      internal __\u003C\u003EAnon48()
      {
      }

      public void run() => TechTree.lambda\u0024load\u0024147();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon49 : Runnable
    {
      internal __\u003C\u003EAnon49()
      {
      }

      public void run() => TechTree.lambda\u0024load\u0024146();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon50 : Runnable
    {
      internal __\u003C\u003EAnon50()
      {
      }

      public void run() => TechTree.lambda\u0024load\u0024145();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon51 : Runnable
    {
      internal __\u003C\u003EAnon51()
      {
      }

      public void run() => TechTree.lambda\u0024load\u0024137();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon52 : Runnable
    {
      internal __\u003C\u003EAnon52()
      {
      }

      public void run() => TechTree.lambda\u0024load\u0024143();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon53 : Runnable
    {
      internal __\u003C\u003EAnon53()
      {
      }

      public void run() => TechTree.lambda\u0024load\u0024142();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon54 : Runnable
    {
      internal __\u003C\u003EAnon54()
      {
      }

      public void run() => TechTree.lambda\u0024load\u0024141();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon55 : Runnable
    {
      internal __\u003C\u003EAnon55()
      {
      }

      public void run() => TechTree.lambda\u0024load\u0024140();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon56 : Runnable
    {
      internal __\u003C\u003EAnon56()
      {
      }

      public void run() => TechTree.lambda\u0024load\u0024139();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon57 : Runnable
    {
      internal __\u003C\u003EAnon57()
      {
      }

      public void run() => TechTree.lambda\u0024load\u0024138();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon58 : Runnable
    {
      internal __\u003C\u003EAnon58()
      {
      }

      public void run() => TechTree.lambda\u0024load\u0024131();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon59 : Runnable
    {
      internal __\u003C\u003EAnon59()
      {
      }

      public void run() => TechTree.lambda\u0024load\u0024136();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon60 : Runnable
    {
      internal __\u003C\u003EAnon60()
      {
      }

      public void run() => TechTree.lambda\u0024load\u0024135();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon61 : Runnable
    {
      internal __\u003C\u003EAnon61()
      {
      }

      public void run() => TechTree.lambda\u0024load\u0024134();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon62 : Runnable
    {
      internal __\u003C\u003EAnon62()
      {
      }

      public void run() => TechTree.lambda\u0024load\u0024133();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon63 : Runnable
    {
      internal __\u003C\u003EAnon63()
      {
      }

      public void run() => TechTree.lambda\u0024load\u0024132();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon64 : Runnable
    {
      internal __\u003C\u003EAnon64()
      {
      }

      public void run() => TechTree.lambda\u0024load\u0024130();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon65 : Runnable
    {
      internal __\u003C\u003EAnon65()
      {
      }

      public void run() => TechTree.lambda\u0024load\u0024129();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon66 : Runnable
    {
      internal __\u003C\u003EAnon66()
      {
      }

      public void run() => TechTree.lambda\u0024load\u0024128();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon67 : Runnable
    {
      internal __\u003C\u003EAnon67()
      {
      }

      public void run() => TechTree.lambda\u0024load\u0024116();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon68 : Runnable
    {
      internal __\u003C\u003EAnon68()
      {
      }

      public void run() => TechTree.lambda\u0024load\u0024121();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon69 : Runnable
    {
      internal __\u003C\u003EAnon69()
      {
      }

      public void run() => TechTree.lambda\u0024load\u0024126();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon70 : Runnable
    {
      internal __\u003C\u003EAnon70()
      {
      }

      public void run() => TechTree.lambda\u0024load\u0024125();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon71 : Runnable
    {
      internal __\u003C\u003EAnon71()
      {
      }

      public void run() => TechTree.lambda\u0024load\u0024124();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon72 : Runnable
    {
      internal __\u003C\u003EAnon72()
      {
      }

      public void run() => TechTree.lambda\u0024load\u0024123();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon73 : Runnable
    {
      internal __\u003C\u003EAnon73()
      {
      }

      public void run() => TechTree.lambda\u0024load\u0024122();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon74 : Runnable
    {
      internal __\u003C\u003EAnon74()
      {
      }

      public void run() => TechTree.lambda\u0024load\u0024120();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon75 : Runnable
    {
      internal __\u003C\u003EAnon75()
      {
      }

      public void run() => TechTree.lambda\u0024load\u0024119();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon76 : Runnable
    {
      internal __\u003C\u003EAnon76()
      {
      }

      public void run() => TechTree.lambda\u0024load\u0024118();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon77 : Runnable
    {
      internal __\u003C\u003EAnon77()
      {
      }

      public void run() => TechTree.lambda\u0024load\u0024117();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon78 : Runnable
    {
      internal __\u003C\u003EAnon78()
      {
      }

      public void run() => TechTree.lambda\u0024load\u0024115();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon79 : Runnable
    {
      internal __\u003C\u003EAnon79()
      {
      }

      public void run() => TechTree.lambda\u0024load\u0024114();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon80 : Runnable
    {
      internal __\u003C\u003EAnon80()
      {
      }

      public void run() => TechTree.lambda\u0024load\u0024113();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon81 : Runnable
    {
      internal __\u003C\u003EAnon81()
      {
      }

      public void run() => TechTree.lambda\u0024load\u002492();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon82 : Runnable
    {
      internal __\u003C\u003EAnon82()
      {
      }

      public void run() => TechTree.lambda\u0024load\u0024100();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon83 : Runnable
    {
      internal __\u003C\u003EAnon83()
      {
      }

      public void run() => TechTree.lambda\u0024load\u0024110();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon84 : Runnable
    {
      internal __\u003C\u003EAnon84()
      {
      }

      public void run() => TechTree.lambda\u0024load\u0024109();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon85 : Runnable
    {
      internal __\u003C\u003EAnon85()
      {
      }

      public void run() => TechTree.lambda\u0024load\u0024104();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon86 : Runnable
    {
      internal __\u003C\u003EAnon86()
      {
      }

      public void run() => TechTree.lambda\u0024load\u0024108();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon87 : Runnable
    {
      internal __\u003C\u003EAnon87()
      {
      }

      public void run() => TechTree.lambda\u0024load\u0024106();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon88 : Runnable
    {
      internal __\u003C\u003EAnon88()
      {
      }

      public void run() => TechTree.lambda\u0024load\u0024107();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon89 : Runnable
    {
      internal __\u003C\u003EAnon89()
      {
      }

      public void run() => TechTree.lambda\u0024load\u0024105();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon90 : Runnable
    {
      internal __\u003C\u003EAnon90()
      {
      }

      public void run() => TechTree.lambda\u0024load\u0024102();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon91 : Runnable
    {
      internal __\u003C\u003EAnon91()
      {
      }

      public void run() => TechTree.lambda\u0024load\u0024103();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon92 : Runnable
    {
      internal __\u003C\u003EAnon92()
      {
      }

      public void run() => TechTree.lambda\u0024load\u0024101();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon93 : Runnable
    {
      internal __\u003C\u003EAnon93()
      {
      }

      public void run() => TechTree.lambda\u0024load\u002499();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon94 : Runnable
    {
      internal __\u003C\u003EAnon94()
      {
      }

      public void run() => TechTree.lambda\u0024load\u002498();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon95 : Runnable
    {
      internal __\u003C\u003EAnon95()
      {
      }

      public void run() => TechTree.lambda\u0024load\u002495();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon96 : Runnable
    {
      internal __\u003C\u003EAnon96()
      {
      }

      public void run() => TechTree.lambda\u0024load\u002497();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon97 : Runnable
    {
      internal __\u003C\u003EAnon97()
      {
      }

      public void run() => TechTree.lambda\u0024load\u002496();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon98 : Runnable
    {
      internal __\u003C\u003EAnon98()
      {
      }

      public void run() => TechTree.lambda\u0024load\u002494();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon99 : Runnable
    {
      internal __\u003C\u003EAnon99()
      {
      }

      public void run() => TechTree.lambda\u0024load\u002493();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon100 : Runnable
    {
      internal __\u003C\u003EAnon100()
      {
      }

      public void run() => TechTree.lambda\u0024load\u002491();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon101 : Runnable
    {
      internal __\u003C\u003EAnon101()
      {
      }

      public void run() => TechTree.lambda\u0024load\u002490();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon102 : Runnable
    {
      internal __\u003C\u003EAnon102()
      {
      }

      public void run() => TechTree.lambda\u0024load\u002484();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon103 : Runnable
    {
      internal __\u003C\u003EAnon103()
      {
      }

      public void run() => TechTree.lambda\u0024load\u002486();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon104 : Runnable
    {
      internal __\u003C\u003EAnon104()
      {
      }

      public void run() => TechTree.lambda\u0024load\u002489();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon105 : Runnable
    {
      internal __\u003C\u003EAnon105()
      {
      }

      public void run() => TechTree.lambda\u0024load\u002488();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon106 : Runnable
    {
      internal __\u003C\u003EAnon106()
      {
      }

      public void run() => TechTree.lambda\u0024load\u002487();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon107 : Runnable
    {
      internal __\u003C\u003EAnon107()
      {
      }

      public void run() => TechTree.lambda\u0024load\u002485();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon108 : Runnable
    {
      internal __\u003C\u003EAnon108()
      {
      }

      public void run() => TechTree.lambda\u0024load\u002427();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon109 : Runnable
    {
      internal __\u003C\u003EAnon109()
      {
      }

      public void run() => TechTree.lambda\u0024load\u002461();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon110 : Runnable
    {
      internal __\u003C\u003EAnon110()
      {
      }

      public void run() => TechTree.lambda\u0024load\u002482();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon111 : Runnable
    {
      internal __\u003C\u003EAnon111()
      {
      }

      public void run() => TechTree.lambda\u0024load\u002481();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon112 : Runnable
    {
      internal __\u003C\u003EAnon112()
      {
      }

      public void run() => TechTree.lambda\u0024load\u002464();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon113 : Runnable
    {
      internal __\u003C\u003EAnon113()
      {
      }

      public void run() => TechTree.lambda\u0024load\u002466();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon114 : Runnable
    {
      internal __\u003C\u003EAnon114()
      {
      }

      public void run() => TechTree.lambda\u0024load\u002472();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon115 : Runnable
    {
      internal __\u003C\u003EAnon115()
      {
      }

      public void run() => TechTree.lambda\u0024load\u002478();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon116 : Runnable
    {
      internal __\u003C\u003EAnon116()
      {
      }

      public void run() => TechTree.lambda\u0024load\u002480();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon117 : Runnable
    {
      internal __\u003C\u003EAnon117()
      {
      }

      public void run() => TechTree.lambda\u0024load\u002479();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon118 : Runnable
    {
      internal __\u003C\u003EAnon118()
      {
      }

      public void run() => TechTree.lambda\u0024load\u002477();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon119 : Runnable
    {
      internal __\u003C\u003EAnon119()
      {
      }

      public void run() => TechTree.lambda\u0024load\u002476();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon120 : Runnable
    {
      internal __\u003C\u003EAnon120()
      {
      }

      public void run() => TechTree.lambda\u0024load\u002475();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon121 : Runnable
    {
      internal __\u003C\u003EAnon121()
      {
      }

      public void run() => TechTree.lambda\u0024load\u002473();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon122 : Runnable
    {
      internal __\u003C\u003EAnon122()
      {
      }

      public void run() => TechTree.lambda\u0024load\u002474();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon123 : Runnable
    {
      internal __\u003C\u003EAnon123()
      {
      }

      public void run() => TechTree.lambda\u0024load\u002471();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon124 : Runnable
    {
      internal __\u003C\u003EAnon124()
      {
      }

      public void run() => TechTree.lambda\u0024load\u002469();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon125 : Runnable
    {
      internal __\u003C\u003EAnon125()
      {
      }

      public void run() => TechTree.lambda\u0024load\u002470();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon126 : Runnable
    {
      internal __\u003C\u003EAnon126()
      {
      }

      public void run() => TechTree.lambda\u0024load\u002468();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon127 : Runnable
    {
      internal __\u003C\u003EAnon127()
      {
      }

      public void run() => TechTree.lambda\u0024load\u002467();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon128 : Runnable
    {
      internal __\u003C\u003EAnon128()
      {
      }

      public void run() => TechTree.lambda\u0024load\u002465();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon129 : Runnable
    {
      internal __\u003C\u003EAnon129()
      {
      }

      public void run() => TechTree.lambda\u0024load\u002463();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon130 : Runnable
    {
      internal __\u003C\u003EAnon130()
      {
      }

      public void run() => TechTree.lambda\u0024load\u002462();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon131 : Runnable
    {
      internal __\u003C\u003EAnon131()
      {
      }

      public void run() => TechTree.lambda\u0024load\u002433();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon132 : Runnable
    {
      internal __\u003C\u003EAnon132()
      {
      }

      public void run() => TechTree.lambda\u0024load\u002435();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon133 : Runnable
    {
      internal __\u003C\u003EAnon133()
      {
      }

      public void run() => TechTree.lambda\u0024load\u002460();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon134 : Runnable
    {
      internal __\u003C\u003EAnon134()
      {
      }

      public void run() => TechTree.lambda\u0024load\u002441();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon135 : Runnable
    {
      internal __\u003C\u003EAnon135()
      {
      }

      public void run() => TechTree.lambda\u0024load\u002449();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon136 : Runnable
    {
      internal __\u003C\u003EAnon136()
      {
      }

      public void run() => TechTree.lambda\u0024load\u002458();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon137 : Runnable
    {
      internal __\u003C\u003EAnon137()
      {
      }

      public void run() => TechTree.lambda\u0024load\u002459();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon138 : Runnable
    {
      internal __\u003C\u003EAnon138()
      {
      }

      public void run() => TechTree.lambda\u0024load\u002457();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon139 : Runnable
    {
      internal __\u003C\u003EAnon139()
      {
      }

      public void run() => TechTree.lambda\u0024load\u002454();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon140 : Runnable
    {
      internal __\u003C\u003EAnon140()
      {
      }

      public void run() => TechTree.lambda\u0024load\u002456();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon141 : Runnable
    {
      internal __\u003C\u003EAnon141()
      {
      }

      public void run() => TechTree.lambda\u0024load\u002455();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon142 : Runnable
    {
      internal __\u003C\u003EAnon142()
      {
      }

      public void run() => TechTree.lambda\u0024load\u002451();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon143 : Runnable
    {
      internal __\u003C\u003EAnon143()
      {
      }

      public void run() => TechTree.lambda\u0024load\u002453();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon144 : Runnable
    {
      internal __\u003C\u003EAnon144()
      {
      }

      public void run() => TechTree.lambda\u0024load\u002452();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon145 : Runnable
    {
      internal __\u003C\u003EAnon145()
      {
      }

      public void run() => TechTree.lambda\u0024load\u002450();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon146 : Runnable
    {
      internal __\u003C\u003EAnon146()
      {
      }

      public void run() => TechTree.lambda\u0024load\u002448();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon147 : Runnable
    {
      internal __\u003C\u003EAnon147()
      {
      }

      public void run() => TechTree.lambda\u0024load\u002447();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon148 : Runnable
    {
      internal __\u003C\u003EAnon148()
      {
      }

      public void run() => TechTree.lambda\u0024load\u002446();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon149 : Runnable
    {
      internal __\u003C\u003EAnon149()
      {
      }

      public void run() => TechTree.lambda\u0024load\u002442();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon150 : Runnable
    {
      internal __\u003C\u003EAnon150()
      {
      }

      public void run() => TechTree.lambda\u0024load\u002444();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon151 : Runnable
    {
      internal __\u003C\u003EAnon151()
      {
      }

      public void run() => TechTree.lambda\u0024load\u002445();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon152 : Runnable
    {
      internal __\u003C\u003EAnon152()
      {
      }

      public void run() => TechTree.lambda\u0024load\u002443();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon153 : Runnable
    {
      internal __\u003C\u003EAnon153()
      {
      }

      public void run() => TechTree.lambda\u0024load\u002438();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon154 : Runnable
    {
      internal __\u003C\u003EAnon154()
      {
      }

      public void run() => TechTree.lambda\u0024load\u002440();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon155 : Runnable
    {
      internal __\u003C\u003EAnon155()
      {
      }

      public void run() => TechTree.lambda\u0024load\u002439();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon156 : Runnable
    {
      internal __\u003C\u003EAnon156()
      {
      }

      public void run() => TechTree.lambda\u0024load\u002437();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon157 : Runnable
    {
      internal __\u003C\u003EAnon157()
      {
      }

      public void run() => TechTree.lambda\u0024load\u002436();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon158 : Runnable
    {
      internal __\u003C\u003EAnon158()
      {
      }

      public void run() => TechTree.lambda\u0024load\u002434();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon159 : Runnable
    {
      internal __\u003C\u003EAnon159()
      {
      }

      public void run() => TechTree.lambda\u0024load\u002428();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon160 : Runnable
    {
      internal __\u003C\u003EAnon160()
      {
      }

      public void run() => TechTree.lambda\u0024load\u002432();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon161 : Runnable
    {
      internal __\u003C\u003EAnon161()
      {
      }

      public void run() => TechTree.lambda\u0024load\u002429();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon162 : Runnable
    {
      internal __\u003C\u003EAnon162()
      {
      }

      public void run() => TechTree.lambda\u0024load\u002431();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon163 : Runnable
    {
      internal __\u003C\u003EAnon163()
      {
      }

      public void run() => TechTree.lambda\u0024load\u002430();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon164 : Runnable
    {
      internal __\u003C\u003EAnon164()
      {
      }

      public void run() => TechTree.lambda\u0024load\u002426();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon165 : Runnable
    {
      internal __\u003C\u003EAnon165()
      {
      }

      public void run() => TechTree.lambda\u0024load\u002425();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon166 : Runnable
    {
      internal __\u003C\u003EAnon166()
      {
      }

      public void run() => TechTree.lambda\u0024load\u002424();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon167 : Runnable
    {
      internal __\u003C\u003EAnon167()
      {
      }

      public void run() => TechTree.lambda\u0024load\u002423();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon168 : Runnable
    {
      internal __\u003C\u003EAnon168()
      {
      }

      public void run() => TechTree.lambda\u0024load\u002419();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon169 : Runnable
    {
      internal __\u003C\u003EAnon169()
      {
      }

      public void run() => TechTree.lambda\u0024load\u002420();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon170 : Runnable
    {
      internal __\u003C\u003EAnon170()
      {
      }

      public void run() => TechTree.lambda\u0024load\u002422();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon171 : Runnable
    {
      internal __\u003C\u003EAnon171()
      {
      }

      public void run() => TechTree.lambda\u0024load\u002421();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon172 : Runnable
    {
      internal __\u003C\u003EAnon172()
      {
      }

      public void run() => TechTree.lambda\u0024load\u002417();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon173 : Runnable
    {
      internal __\u003C\u003EAnon173()
      {
      }

      public void run() => TechTree.lambda\u0024load\u002415();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon174 : Runnable
    {
      internal __\u003C\u003EAnon174()
      {
      }

      public void run() => TechTree.lambda\u0024load\u002414();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon175 : Runnable
    {
      internal __\u003C\u003EAnon175()
      {
      }

      public void run() => TechTree.lambda\u0024load\u00241();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon176 : Runnable
    {
      internal __\u003C\u003EAnon176()
      {
      }

      public void run() => TechTree.lambda\u0024load\u00243();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon177 : Runnable
    {
      internal __\u003C\u003EAnon177()
      {
      }

      public void run() => TechTree.lambda\u0024load\u00245();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon178 : Runnable
    {
      internal __\u003C\u003EAnon178()
      {
      }

      public void run() => TechTree.lambda\u0024load\u002413();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon179 : Runnable
    {
      internal __\u003C\u003EAnon179()
      {
      }

      public void run() => TechTree.lambda\u0024load\u002412();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon180 : Runnable
    {
      internal __\u003C\u003EAnon180()
      {
      }

      public void run() => TechTree.lambda\u0024load\u00247();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon181 : Runnable
    {
      internal __\u003C\u003EAnon181()
      {
      }

      public void run() => TechTree.lambda\u0024load\u00249();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon182 : Runnable
    {
      internal __\u003C\u003EAnon182()
      {
      }

      public void run() => TechTree.lambda\u0024load\u002411();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon183 : Runnable
    {
      internal __\u003C\u003EAnon183()
      {
      }

      public void run() => TechTree.lambda\u0024load\u002410();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon184 : Runnable
    {
      internal __\u003C\u003EAnon184()
      {
      }

      public void run() => TechTree.lambda\u0024load\u00248();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon185 : Runnable
    {
      internal __\u003C\u003EAnon185()
      {
      }

      public void run() => TechTree.lambda\u0024load\u00246();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon186 : Runnable
    {
      internal __\u003C\u003EAnon186()
      {
      }

      public void run() => TechTree.lambda\u0024load\u00244();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon187 : Runnable
    {
      internal __\u003C\u003EAnon187()
      {
      }

      public void run() => TechTree.lambda\u0024load\u00242();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon188 : Runnable
    {
      internal __\u003C\u003EAnon188()
      {
      }

      public void run() => TechTree.lambda\u0024load\u00240();
    }
  }
}
