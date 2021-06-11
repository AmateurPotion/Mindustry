// Decompiled with JetBrains decompiler
// Type: mindustry.world.blocks.power.PowerNode
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.@struct;
using arc.func;
using arc.graphics;
using arc.graphics.g2d;
using arc.math;
using arc.math.geom;
using arc.util;
using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.util;
using java.util.function;
using mindustry.core;
using mindustry.entities.units;
using mindustry.game;
using mindustry.gen;
using mindustry.graphics;
using mindustry.input;
using mindustry.world.meta;
using mindustry.world.modules;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.world.blocks.power
{
  public class PowerNode : PowerBlock
  {
    protected internal static bool returnValue;
    protected internal static BuildPlan otherReq;
    [Signature("Larc/struct/ObjectSet<Lmindustry/world/blocks/power/PowerGraph;>;")]
    internal static ObjectSet __\u003C\u003Egraphs;
    protected internal static int returnInt;
    public TextureRegion laser;
    public TextureRegion laserEnd;
    public float laserRange;
    public int maxNodes;
    public Color laserColor1;
    public Color laserColor2;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [Signature("(Lmindustry/world/Tile;Lmindustry/world/Block;Lmindustry/game/Team;Larc/func/Cons<Lmindustry/gen/Building;>;)V")]
    [LineNumberTable(new byte[] {160, 135, 238, 74, 107, 170, 125, 106, 127, 24, 127, 3, 252, 60, 233, 72, 117, 187, 254, 71, 246, 70, 214})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void getNodeLinks(Tile tile, Block block, Team team, Cons others)
    {
      Boolf pred = (Boolf) new PowerNode.__\u003C\u003EAnon11(tile, block, team);
      Block.__\u003C\u003EtempTileEnts.clear();
      PowerNode.__\u003C\u003Egraphs.clear();
      Point2[] edges = Edges.getEdges(block.size);
      int length = edges.Length;
      for (int index = 0; index < length; ++index)
      {
        Point2 relative = edges[index];
        Tile tile1 = tile.nearby(relative);
        if (tile1 != null && object.ReferenceEquals((object) tile1.team(), (object) team) && (tile1.build != null && tile1.build.power != null) && (!block.consumesPower || !tile1.block().consumesPower || (block.outputsPower || tile1.block().outputsPower)))
          PowerNode.__\u003C\u003Egraphs.add((object) tile1.build.power.graph);
      }
      if (tile.build != null && tile.build.power != null)
        PowerNode.__\u003C\u003Egraphs.add((object) tile.build.power.graph);
      Geometry.circle((int) tile.x, (int) tile.y, 13, (Intc2) new PowerNode.__\u003C\u003EAnon12(pred));
      Block.__\u003C\u003EtempTileEnts.sort((Comparator) new PowerNode.__\u003C\u003EAnon13(tile));
      Block.__\u003C\u003EtempTileEnts.each(pred, (Cons) new PowerNode.__\u003C\u003EAnon14(others));
    }

    [LineNumberTable(new byte[] {117, 113, 112, 159, 10, 127, 28})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void drawLaser(
      Team team,
      float x1,
      float y1,
      float x2,
      float y2,
      int size1,
      int size2)
    {
      float degrees = Angles.angle(x1, y1, x2, y2);
      float num1 = Mathf.cosDeg(degrees);
      float num2 = Mathf.sinDeg(degrees);
      float num3 = (float) (size1 * 8) / 2f - 1.5f;
      float num4 = (float) (size2 * 8) / 2f - 1.5f;
      Drawf.laser(team, this.laser, this.laserEnd, x1 + num1 * num3, y1 + num2 * num3, x2 - num1 * num4, y2 - num2 * num4, 0.25f);
    }

    [Signature("(Lmindustry/world/Tile;Lmindustry/game/Team;Larc/func/Cons<Lmindustry/gen/Building;>;)V")]
    [LineNumberTable(new byte[] {160, 83, 238, 75, 107, 170, 125, 106, 127, 11, 252, 61, 233, 71, 117, 187, 255, 15, 71, 246, 70, 134, 247, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void getPotentialLinks(Tile tile, Team team, Cons others)
    {
      Boolf pred = (Boolf) new PowerNode.__\u003C\u003EAnon7(this, tile, team);
      Block.__\u003C\u003EtempTileEnts.clear();
      PowerNode.__\u003C\u003Egraphs.clear();
      Point2[] edges = Edges.getEdges(this.size);
      int length = edges.Length;
      for (int index = 0; index < length; ++index)
      {
        Point2 relative = edges[index];
        Tile tile1 = tile.nearby(relative);
        if (tile1 != null && object.ReferenceEquals((object) tile1.team(), (object) team) && (tile1.build != null && tile1.build.power != null))
          PowerNode.__\u003C\u003Egraphs.add((object) tile1.build.power.graph);
      }
      if (tile.build != null && tile.build.power != null)
        PowerNode.__\u003C\u003Egraphs.add((object) tile.build.power.graph);
      Geometry.circle((int) tile.x, (int) tile.y, ByteCodeHelper.f2i(this.laserRange + 2f), (Intc2) new PowerNode.__\u003C\u003EAnon8(pred));
      Block.__\u003C\u003EtempTileEnts.sort((Comparator) new PowerNode.__\u003C\u003EAnon9(tile));
      PowerNode.returnInt = 0;
      Block.__\u003C\u003EtempTileEnts.each(pred, (Cons) new PowerNode.__\u003C\u003EAnon10(this, others));
    }

    [LineNumberTable(180)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual bool overlaps(float srcx, float srcy, Tile other, float range) => Intersector.overlaps(Tmp.__\u003C\u003Ecr1.set(srcx, srcy, range), other.getHitbox(Tmp.__\u003C\u003Er1));

    [LineNumberTable(new byte[] {112, 127, 20, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void setupColor(float satisfaction)
    {
      Draw.color(this.laserColor1, this.laserColor2, (1f - satisfaction) * 0.86f + Mathf.absin(3f, 0.1f));
      Draw.alpha(Renderer.laserOpacity);
    }

    [LineNumberTable(new byte[] {159, 62, 130, 159, 15, 127, 60, 127, 9, 159, 23, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool linkValid(Building tile, Building link, bool checkMaxNodes)
    {
      int num = checkMaxNodes ? 1 : 0;
      if (object.ReferenceEquals((object) tile, (object) link) || link == null || (!link.block.hasPower || !object.ReferenceEquals((object) tile.team, (object) link.team)))
        return false;
      if (!this.overlaps(tile, link, this.laserRange * 8f))
      {
        Block block = link.block;
        PowerNode powerNode;
        if (!(block is PowerNode) || !object.ReferenceEquals((object) (powerNode = (PowerNode) block), (object) (PowerNode) block) || !this.overlaps(link, tile, powerNode.laserRange * 8f))
          return false;
      }
      if (num != 0)
      {
        Block block = link.block;
        PowerNode powerNode;
        if (block is PowerNode && object.ReferenceEquals((object) (powerNode = (PowerNode) block), (object) (PowerNode) block) && (link.power.links.size >= powerNode.maxNodes && !link.power.links.contains(tile.pos())))
          return false;
      }
      return true;
    }

    [LineNumberTable(184)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual bool overlaps(Building src, Building other, float range) => this.overlaps(src.x, src.y, other.tile(), range);

    [LineNumberTable(342)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool insulated(int x, int y, int x2, int y2) => Vars.world.raycast(x, y, x2, y2, (Geometry.Raycaster) new PowerNode.__\u003C\u003EAnon16());

    [LineNumberTable(175)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual bool overlaps(
      float srcx,
      float srcy,
      Tile other,
      Block otherBlock,
      float range)
    {
      return Intersector.overlaps(Tmp.__\u003C\u003Ecr1.set(srcx, srcy, range), Tmp.__\u003C\u003Er1.setCentered(other.worldx() + otherBlock.offset, other.worldy() + otherBlock.offset, (float) (otherBlock.size * 8), (float) (otherBlock.size * 8)));
    }

    [LineNumberTable(334)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool insulated(Tile tile, Tile other) => PowerNode.insulated((int) tile.x, (int) tile.y, (int) other.x, (int) other.y);

    [LineNumberTable(new byte[] {160, 78, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool overlaps([Nullable(new object[] {64, "Larc/util/Nullable;"})] Tile src, [Nullable(new object[] {64, "Larc/util/Nullable;"})] Tile other) => src == null || other == null || Intersector.overlaps(Tmp.__\u003C\u003Ecr1.set(src.worldx() + this.offset, src.worldy() + this.offset, this.laserRange * 8f), Tmp.__\u003C\u003Er1.setSize((float) (this.size * 8)).setCenter(other.worldx() + this.offset, other.worldy() + this.offset));

    [LineNumberTable(318)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool linkValid(Building tile, Building link) => this.linkValid(tile, link, true);

    [Modifiers]
    [LineNumberTable(new byte[] {0, 103, 113, 159, 3, 134, 114, 154, 167, 136, 151, 135, 136, 159, 15, 115, 177, 147, 120, 214, 150})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u00240([In] Building obj0, [In] Integer obj1)
    {
      PowerModule power = obj0.power;
      Building building = Vars.world.build(obj1.intValue());
      int num1 = power.links.contains(obj1.intValue()) ? 1 : 0;
      int num2 = building == null || building.power == null ? 0 : 1;
      if (num1 != 0)
      {
        power.links.removeValue(obj1.intValue());
        if (num2 != 0)
          building.power.links.removeValue(obj0.pos());
        PowerGraph powerGraph = new PowerGraph();
        powerGraph.reflow(obj0);
        if (num2 == 0 || object.ReferenceEquals((object) building.power.graph, (object) powerGraph))
          return;
        new PowerGraph().reflow(building);
      }
      else
      {
        if (!this.linkValid(obj0, building) || num2 == 0 || power.links.size >= this.maxNodes)
          return;
        if (!power.links.contains(building.pos()))
          power.links.add(building.pos());
        if (object.ReferenceEquals((object) building.team, (object) obj0.team) && !building.power.links.contains(obj0.pos()))
          building.power.links.add(obj0.pos());
        power.graph.addGraph(building.power.graph);
      }
    }

    [Modifiers]
    [LineNumberTable(new byte[] {38, 144, 177, 107, 104, 31, 2, 230, 70, 115, 127, 4, 31, 3, 200})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u00241([In] Building obj0, [In] Point2[] obj1)
    {
      obj0.power.links.clear();
      IntSeq intSeq = new IntSeq(obj0.power.links);
      for (int index = 0; index < intSeq.size; ++index)
      {
        int num = intSeq.get(index);
        ((Cons2) this.configurations.get((object) ClassLiteral<Integer>.Value)).get((object) obj0, (object) Integer.valueOf(num));
      }
      Point2[] point2Array = obj1;
      int length = point2Array.Length;
      for (int index = 0; index < length; ++index)
      {
        Point2 point2 = point2Array[index];
        int num = Point2.pack(point2.x + obj0.tileX(), point2.y + obj0.tileY());
        ((Cons2) this.configurations.get((object) ClassLiteral<Integer>.Value)).get((object) obj0, (object) Integer.valueOf(num));
      }
    }

    [Modifiers]
    [LineNumberTable(109)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static mindustry.ui.Bar lambda\u0024setBars\u00245([In] Building obj0)
    {
      mindustry.ui.Bar.__\u003Cclinit\u003E();
      return new mindustry.ui.Bar((Prov) new PowerNode.__\u003C\u003EAnon25(obj0), (Prov) new PowerNode.__\u003C\u003EAnon26(), (Floatp) new PowerNode.__\u003C\u003EAnon27(obj0));
    }

    [Modifiers]
    [LineNumberTable(115)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static mindustry.ui.Bar lambda\u0024setBars\u00249([In] Building obj0)
    {
      mindustry.ui.Bar.__\u003Cclinit\u003E();
      return new mindustry.ui.Bar((Prov) new PowerNode.__\u003C\u003EAnon22(obj0), (Prov) new PowerNode.__\u003C\u003EAnon23(), (Floatp) new PowerNode.__\u003C\u003EAnon24(obj0));
    }

    [Modifiers]
    [LineNumberTable(121)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private mindustry.ui.Bar lambda\u0024setBars\u002413([In] Building obj0)
    {
      mindustry.ui.Bar.__\u003Cclinit\u003E();
      return new mindustry.ui.Bar((Prov) new PowerNode.__\u003C\u003EAnon19(this, obj0), (Prov) new PowerNode.__\u003C\u003EAnon20(), (Floatp) new PowerNode.__\u003C\u003EAnon21(this, obj0));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {97, 119, 159, 37, 127, 22})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024drawPlace\u002414([In] Tile obj0, [In] int obj1, [In] int obj2, [In] Building obj3)
    {
      Draw.color(this.laserColor1, Renderer.laserOpacity * 0.5f);
      this.drawLaser(obj0.team(), (float) (obj1 * 8) + this.offset, (float) (obj2 * 8) + this.offset, obj3.x, obj3.y, this.size, obj3.block.size);
      Drawf.square(obj3.x, obj3.y, (float) (obj3.block.size * 8) / 2f + 2f, Pal.place);
    }

    [Modifiers]
    [LineNumberTable(158)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool lambda\u0024changePlacementPath\u002415([In] Point2 obj0, [In] Point2 obj1) => this.overlaps(Vars.world.tile(obj0.x, obj0.y), Vars.world.tile(obj1.x, obj1.y));

    [Modifiers]
    [LineNumberTable(new byte[] {160, 88, 231, 59, 159, 74, 127, 30, 113, 106, 127, 40, 60})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool lambda\u0024getPotentialLinks\u002417([In] Tile obj0, [In] Team obj1, [In] Building obj2)
    {
      if (obj2 != null && !object.ReferenceEquals((object) obj2.tile(), (object) obj0) && obj2.power != null && (obj2.block.outputsPower || obj2.block.consumesPower || obj2.block is PowerNode) && (this.overlaps((float) ((int) obj0.x * 8) + this.offset, (float) ((int) obj0.y * 8) + this.offset, obj2.tile(), this.laserRange * 8f) && object.ReferenceEquals((object) obj2.team, (object) obj1) && (!PowerNode.__\u003C\u003Egraphs.contains((object) obj2.power.graph) && !PowerNode.insulated(obj0, obj2.tile))))
      {
        Building building = obj2;
        PowerNode.PowerNodeBuild powerNodeBuild;
        if ((!(building is PowerNode.PowerNodeBuild) || !object.ReferenceEquals((object) (powerNodeBuild = (PowerNode.PowerNodeBuild) building), (object) (PowerNode.PowerNodeBuild) building) || powerNodeBuild.power.links.size < ((PowerNode) powerNodeBuild.block).maxNodes) && !Structs.contains((object[]) Edges.getEdges(this.size), (Boolf) new PowerNode.__\u003C\u003EAnon18(obj0, obj2)))
          return true;
      }
      return false;
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 110, 109, 118, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024getPotentialLinks\u002418([In] Boolf obj0, [In] int obj1, [In] int obj2)
    {
      Building building = Vars.world.build(obj1, obj2);
      if (!obj0.get((object) building) || Block.__\u003C\u003EtempTileEnts.contains((object) building))
        return;
      Block.__\u003C\u003EtempTileEnts.add((object) building);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 117, 127, 4, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static int lambda\u0024getPotentialLinks\u002419(
      [In] Tile obj0,
      [In] Building obj1,
      [In] Building obj2)
    {
      int num = -Boolean.compare(obj1.block is PowerNode, obj2.block is PowerNode);
      return num != 0 ? num : Float.compare(obj1.dst2((Position) obj0), obj2.dst2((Position) obj0));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 125, 117, 118, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024getPotentialLinks\u002420([In] Cons obj0, [In] Building obj1)
    {
      if (PowerNode.returnInt++ >= this.maxNodes)
        return;
      PowerNode.__\u003C\u003Egraphs.add((object) obj1.power.graph);
      obj0.get((object) obj1);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 139, 231, 60, 159, 82, 127, 6, 110, 109, 60})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024getNodeLinks\u002422(
      [In] Tile obj0,
      [In] Block obj1,
      [In] Team obj2,
      [In] Building obj3)
    {
      if (obj3 != null && !object.ReferenceEquals((object) obj3.tile(), (object) obj0))
      {
        Block block = obj3.block;
        PowerNode powerNode;
        if (block is PowerNode && object.ReferenceEquals((object) (powerNode = (PowerNode) block), (object) (PowerNode) block) && (obj3.power.links.size < powerNode.maxNodes && powerNode.overlaps(obj3.x, obj3.y, obj0, obj1, powerNode.laserRange * 8f)) && (object.ReferenceEquals((object) obj3.team, (object) obj2) && !PowerNode.__\u003C\u003Egraphs.contains((object) obj3.power.graph) && (!PowerNode.insulated(obj0, obj3.tile) && !Structs.contains((object[]) Edges.getEdges(obj1.size), (Boolf) new PowerNode.__\u003C\u003EAnon17(obj0, obj3)))))
          return true;
      }
      return false;
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 162, 109, 118, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024getNodeLinks\u002423([In] Boolf obj0, [In] int obj1, [In] int obj2)
    {
      Building building = Vars.world.build(obj1, obj2);
      if (!obj0.get((object) building) || Block.__\u003C\u003EtempTileEnts.contains((object) building))
        return;
      Block.__\u003C\u003EtempTileEnts.add((object) building);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 169, 127, 4, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static int lambda\u0024getNodeLinks\u002424([In] Tile obj0, [In] Building obj1, [In] Building obj2)
    {
      int num = -Boolean.compare(obj1.block is PowerNode, obj2.block is PowerNode);
      return num != 0 ? num : Float.compare(obj1.dst2((Position) obj0), obj2.dst2((Position) obj0));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 175, 118, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024getNodeLinks\u002425([In] Cons obj0, [In] Building obj1)
    {
      PowerNode.__\u003C\u003Egraphs.add((object) obj1.power.graph);
      obj0.get((object) obj1);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 188, 191, 98, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024drawRequestConfigTop\u002426(
      [In] int obj0,
      [In] int obj1,
      [In] BuildPlan obj2,
      [In] BuildPlan obj3)
    {
      if (obj3.block == null || obj0 < obj3.x - (obj3.block.size - 1) / 2 || (obj1 < obj3.y - (obj3.block.size - 1) / 2 || obj0 > obj3.x + obj3.block.size / 2) || (obj1 > obj3.y + obj3.block.size / 2 || object.ReferenceEquals((object) obj3, (object) obj2) || !obj3.block.hasPower))
        return;
      PowerNode.otherReq = obj3;
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 229, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024insulated\u002427([In] int obj0, [In] int obj1)
    {
      Building building = Vars.world.build(obj0, obj1);
      return building != null && building.block.insulated;
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 141, 127, 6})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024getNodeLinks\u002421([In] Tile obj0, [In] Building obj1, [In] Point2 obj2)
    {
      Tile tile = Vars.world.tile((int) obj0.x + obj2.x, (int) obj0.y + obj2.y);
      return tile != null && object.ReferenceEquals((object) tile.build, (object) obj1);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 90, 127, 6})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024getPotentialLinks\u002416(
      [In] Tile obj0,
      [In] Building obj1,
      [In] Point2 obj2)
    {
      Tile tile = Vars.world.tile((int) obj0.x + obj2.x, (int) obj0.y + obj2.y);
      return tile != null && object.ReferenceEquals((object) tile.build, (object) obj1);
    }

    [Modifiers]
    [LineNumberTable(122)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private string lambda\u0024setBars\u002410([In] Building obj0) => Core.bundle.format("bar.powerlines", (object) Integer.valueOf(obj0.power.links.size), (object) Integer.valueOf(this.maxNodes));

    [Modifiers]
    [LineNumberTable(123)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static Color lambda\u0024setBars\u002411() => Pal.items;

    [Modifiers]
    [LineNumberTable(124)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private float lambda\u0024setBars\u002412([In] Building obj0) => (float) obj0.power.links.size / (float) this.maxNodes;

    [Modifiers]
    [LineNumberTable(new byte[] {66, 125, 63, 16})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static string lambda\u0024setBars\u00246([In] Building obj0) => Core.bundle.format("bar.powerstored", (object) UI.formatAmount(ByteCodeHelper.f2i(obj0.power.graph.getLastPowerStored())), (object) UI.formatAmount(ByteCodeHelper.f2i(obj0.power.graph.getLastCapacity())));

    [Modifiers]
    [LineNumberTable(118)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static Color lambda\u0024setBars\u00247() => Pal.powerBar;

    [Modifiers]
    [LineNumberTable(119)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static float lambda\u0024setBars\u00248([In] Building obj0) => Mathf.clamp(obj0.power.graph.getLastPowerStored() / obj0.power.graph.getLastCapacity());

    [Modifiers]
    [LineNumberTable(new byte[] {60, 119, 63, 55})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static string lambda\u0024setBars\u00242([In] Building obj0) => Core.bundle.format("bar.powerbalance", (object) new StringBuilder().append((double) obj0.power.graph.getPowerBalance() < 0.0 ? "" : "+").append(UI.formatAmount(ByteCodeHelper.f2i(obj0.power.graph.getPowerBalance() * 60f))).toString());

    [Modifiers]
    [LineNumberTable(112)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static Color lambda\u0024setBars\u00243() => Pal.powerBar;

    [Modifiers]
    [LineNumberTable(113)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static float lambda\u0024setBars\u00244([In] Building obj0) => Mathf.clamp(obj0.power.graph.getLastPowerProduced() / obj0.power.graph.getLastPowerNeeded());

    [LineNumberTable(new byte[] {159, 182, 233, 58, 107, 103, 107, 203, 103, 103, 103, 103, 103, 104, 135, 246, 102, 246, 81})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public PowerNode(string name)
      : base(name)
    {
      PowerNode powerNode = this;
      this.laserRange = 6f;
      this.maxNodes = 3;
      this.laserColor1 = Color.__\u003C\u003Ewhite;
      this.laserColor2 = Pal.powerLight;
      this.configurable = true;
      this.consumesPower = false;
      this.outputsPower = false;
      this.canOverdrive = false;
      this.swapDiagonalPlacement = true;
      this.schematicPriority = -10;
      this.drawDisabled = false;
      this.config((Class) ClassLiteral<Integer>.Value, (Cons2) new PowerNode.__\u003C\u003EAnon0(this));
      this.config((Class) ClassLiteral<Point2[]>.Value, (Cons2) new PowerNode.__\u003C\u003EAnon1(this));
    }

    [LineNumberTable(new byte[] {58, 102, 250, 70, 250, 70, 251, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setBars()
    {
      base.setBars();
      this.__\u003C\u003Ebars.add("power", (Func) new PowerNode.__\u003C\u003EAnon2());
      this.__\u003C\u003Ebars.add("batteries", (Func) new PowerNode.__\u003C\u003EAnon3());
      this.__\u003C\u003Ebars.add("connections", (Func) new PowerNode.__\u003C\u003EAnon4(this));
    }

    [LineNumberTable(new byte[] {80, 134, 123, 124})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setStats()
    {
      base.setStats();
      this.stats.add(Stat.__\u003C\u003EpowerRange, this.laserRange, StatUnit.__\u003C\u003Eblocks);
      this.stats.add(Stat.__\u003C\u003EpowerConnections, (float) this.maxNodes, StatUnit.__\u003C\u003Enone);
    }

    [LineNumberTable(new byte[] {88, 141, 132, 106, 106, 159, 11, 255, 0, 71, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void drawPlace(int x, int y, int rotation, bool valid)
    {
      Tile tile = Vars.world.tile(x, y);
      if (tile == null)
        return;
      Lines.stroke(1f);
      Draw.color(Pal.placing);
      Drawf.circles((float) (x * 8) + this.offset, (float) (y * 8) + this.offset, this.laserRange * 8f);
      this.getPotentialLinks(tile, Vars.player.team(), (Cons) new PowerNode.__\u003C\u003EAnon5(this, tile, x, y));
      Draw.reset();
    }

    [Signature("(Larc/struct/Seq<Larc/math/geom/Point2;>;I)V")]
    [LineNumberTable(new byte[] {108, 115})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void changePlacementPath(Seq points, int rotation) => Placement.calculateNodes(points, (Block) this, rotation, (Boolf2) new PowerNode.__\u003C\u003EAnon6(this));

    [LineNumberTable(188)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual bool overlaps(Tile src, Tile other, float range) => this.overlaps(src.drawx(), src.drawy(), other, range);

    [Signature("(Lmindustry/entities/units/BuildPlan;Larc/util/Eachable<Lmindustry/entities/units/BuildPlan;>;)V")]
    [LineNumberTable(new byte[] {160, 182, 127, 11, 107, 118, 127, 1, 102, 245, 72, 149, 255, 56, 51, 235, 79, 133})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void drawRequestConfigTop(BuildPlan req, Eachable list)
    {
      object config = req.config;
      Point2[] point2Array1;
      if (!(config is Point2[]) || !object.ReferenceEquals((object) (point2Array1 = (Point2[]) config), (object) (Point2[]) config))
        return;
      this.setupColor(1f);
      Point2[] point2Array2 = point2Array1;
      int length = point2Array2.Length;
      for (int index = 0; index < length; ++index)
      {
        Point2 point2 = point2Array2[index];
        int num1 = req.x + point2.x;
        int num2 = req.y + point2.y;
        PowerNode.otherReq = (BuildPlan) null;
        list.each((Cons) new PowerNode.__\u003C\u003EAnon15(num1, num2, req));
        if (PowerNode.otherReq != null && PowerNode.otherReq.block != null)
          this.drawLaser(Vars.player != null ? Vars.player.team() : Team.__\u003C\u003Esharded, req.drawx(), req.drawy(), PowerNode.otherReq.drawx(), PowerNode.otherReq.drawy(), this.size, PowerNode.otherReq.block.size);
      }
      Draw.color();
    }

    [LineNumberTable(338)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool insulated(Building tile, Building other) => PowerNode.insulated(tile.tileX(), tile.tileY(), other.tileX(), other.tileY());

    [LineNumberTable(new byte[] {159, 136, 146, 166, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static PowerNode()
    {
      PowerBlock.__\u003Cclinit\u003E();
      if (ByteCodeHelper.isAlreadyInited("mindustry.world.blocks.power.PowerNode"))
        return;
      PowerNode.returnValue = false;
      PowerNode.__\u003C\u003Egraphs = new ObjectSet();
      PowerNode.returnInt = 0;
    }

    [Modifiers]
    protected internal static ObjectSet graphs
    {
      [HideFromJava] get => PowerNode.__\u003C\u003Egraphs;
    }

    public class PowerNodeBuild : Building
    {
      [Modifiers]
      internal PowerNode this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(459)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      protected internal virtual bool linked(Building other) => this.power.links.contains(other.pos());

      [LineNumberTable(new byte[] {161, 94, 118, 103, 63, 21, 166})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual Point2[] config()
      {
        Point2[] point2Array = new Point2[this.power.links.size];
        for (int index = 0; index < point2Array.Length; ++index)
          point2Array[index] = Point2.unpack(this.power.links.get(index)).sub((int) this.tile.x, (int) this.tile.y);
        return point2Array;
      }

      [Modifiers]
      [LineNumberTable(new byte[] {160, 241, 120, 145})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024placed\u00240([In] Building obj0)
      {
        if (this.power.links.contains(obj0.pos()))
          return;
        this.configureAny((object) Integer.valueOf(obj0.pos()));
      }

      [Modifiers]
      [LineNumberTable(new byte[] {161, 16, 127, 10, 145})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024onConfigureTileTapped\u00241([In] int[] obj0, [In] Building obj1)
      {
        if (PowerNode.insulated((Building) this, obj1))
          return;
        int[] numArray1 = obj0;
        int index1 = 0;
        int[] numArray2 = numArray1;
        int[] numArray3 = numArray2;
        int num1 = index1;
        int num2 = numArray2[index1];
        int index2 = num1;
        int[] numArray4 = numArray3;
        int num3 = num2;
        numArray4[index2] = num2 + 1;
        int maxNodes = this.this\u00240.maxNodes;
        if (num3 >= maxNodes)
          return;
        this.configure((object) Integer.valueOf(obj1.pos()));
      }

      [LineNumberTable(348)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public PowerNodeBuild(PowerNode _param1)
      {
        this.this\u00240 = _param1;
        // ISSUE: explicit constructor call
        base.\u002Ector();
      }

      [LineNumberTable(new byte[] {160, 238, 141, 255, 3, 70, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void placed()
      {
        if (Vars.net.client())
          return;
        this.this\u00240.getPotentialLinks(this.tile, this.team, (Cons) new PowerNode.PowerNodeBuild.__\u003C\u003EAnon0(this));
        base.placed();
      }

      [LineNumberTable(new byte[] {160, 251, 144, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void dropped()
      {
        this.power.links.clear();
        new PowerGraph().add((Building) this);
      }

      [LineNumberTable(new byte[] {161, 2, 112})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void updateTile() => this.power.graph.update();

      [LineNumberTable(new byte[] {161, 7, 111, 113, 162, 108, 114, 107, 255, 4, 69, 98, 115, 190, 102, 162})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override bool onConfigureTileTapped(Building other)
      {
        if (this.this\u00240.linkValid((Building) this, other))
        {
          this.configure((object) Integer.valueOf(other.pos()));
          return false;
        }
        if (!object.ReferenceEquals((object) this, (object) other))
          return true;
        if (other.power.links.size == 0)
        {
          this.this\u00240.getPotentialLinks(this.tile, this.team, (Cons) new PowerNode.PowerNodeBuild.__\u003C\u003EAnon1(this, new int[1]
          {
            0
          }));
        }
        else
        {
          while (this.power.links.size > 0)
            this.configure((object) Integer.valueOf(this.power.links.get(0)));
        }
        this.deselect();
        return false;
      }

      [LineNumberTable(new byte[] {161, 34, 134, 138, 106, 127, 4, 101})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void drawSelect()
      {
        base.drawSelect();
        Lines.stroke(1f);
        Draw.color(Pal.accent);
        Drawf.circles(this.x, this.y, this.this\u00240.laserRange * 8f);
        Draw.reset();
      }

      [LineNumberTable(new byte[] {161, 46, 127, 42, 159, 4, 127, 46, 127, 46, 141, 121, 136, 99, 255, 19, 57, 41, 233, 78, 101})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void drawConfigure()
      {
        Drawf.circles(this.x, this.y, (float) (this.tile.block().size * 8) / 2f + 1f + Mathf.absin(Time.time, 4f, 1f));
        Drawf.circles(this.x, this.y, this.this\u00240.laserRange * 8f);
        for (int x = ByteCodeHelper.f2i((float) this.tile.x - this.this\u00240.laserRange - 2f); (double) x <= (double) ((float) this.tile.x + this.this\u00240.laserRange + 2f); ++x)
        {
          for (int y = ByteCodeHelper.f2i((float) this.tile.y - this.this\u00240.laserRange - 2f); (double) y <= (double) ((float) this.tile.y + this.this\u00240.laserRange + 2f); ++y)
          {
            Building building = Vars.world.build(x, y);
            if (!object.ReferenceEquals((object) building, (object) this) && this.this\u00240.linkValid((Building) this, building, false) && this.linked(building))
              Drawf.square(building.x, building.y, (float) (building.block.size * 8) / 2f + 1f, Pal.place);
          }
        }
        Draw.reset();
      }

      [LineNumberTable(new byte[] {161, 68, 134, 141, 106, 156, 120, 156, 145, 157, 255, 32, 57, 233, 74, 101})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void draw()
      {
        base.draw();
        if (Mathf.zero(Renderer.laserOpacity))
          return;
        Draw.z(70f);
        this.this\u00240.setupColor(this.power.graph.getSatisfaction());
        for (int index = 0; index < this.power.links.size; ++index)
        {
          Building link = Vars.world.build(this.power.links.get(index));
          if (this.this\u00240.linkValid((Building) this, link) && (!(link.block is PowerNode) || link.id < this.id))
            this.this\u00240.drawLaser(this.team, this.x, this.y, link.x, link.y, this.this\u00240.size, link.block.size);
        }
        Draw.reset();
      }

      [Modifiers]
      [EditorBrowsable(EditorBrowsableState.Never)]
      [LineNumberTable(348)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual object \u003Cbridge\u003Econfig() => (object) this.config();

      [HideFromJava]
      static PowerNodeBuild() => Building.__\u003Cclinit\u003E();

      [SpecialName]
      private new sealed class __\u003C\u003EAnon0 : Cons
      {
        private readonly PowerNode.PowerNodeBuild arg\u00241;

        internal __\u003C\u003EAnon0([In] PowerNode.PowerNodeBuild obj0) => this.arg\u00241 = obj0;

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024placed\u00240((Building) obj0);
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon1 : Cons
      {
        private readonly PowerNode.PowerNodeBuild arg\u00241;
        private readonly int[] arg\u00242;

        internal __\u003C\u003EAnon1([In] PowerNode.PowerNodeBuild obj0, [In] int[] obj1)
        {
          this.arg\u00241 = obj0;
          this.arg\u00242 = obj1;
        }

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024onConfigureTileTapped\u00241(this.arg\u00242, (Building) obj0);
      }
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon0 : Cons2
    {
      private readonly PowerNode arg\u00241;

      internal __\u003C\u003EAnon0([In] PowerNode obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0, [In] object obj1) => this.arg\u00241.lambda\u0024new\u00240((Building) obj0, (Integer) obj1);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon1 : Cons2
    {
      private readonly PowerNode arg\u00241;

      internal __\u003C\u003EAnon1([In] PowerNode obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0, [In] object obj1) => this.arg\u00241.lambda\u0024new\u00241((Building) obj0, (Point2[]) obj1);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon2 : Func
    {
      internal __\u003C\u003EAnon2()
      {
      }

      public object get([In] object obj0) => (object) PowerNode.lambda\u0024setBars\u00245((Building) obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon3 : Func
    {
      internal __\u003C\u003EAnon3()
      {
      }

      public object get([In] object obj0) => (object) PowerNode.lambda\u0024setBars\u00249((Building) obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon4 : Func
    {
      private readonly PowerNode arg\u00241;

      internal __\u003C\u003EAnon4([In] PowerNode obj0) => this.arg\u00241 = obj0;

      public object get([In] object obj0) => (object) this.arg\u00241.lambda\u0024setBars\u002413((Building) obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon5 : Cons
    {
      private readonly PowerNode arg\u00241;
      private readonly Tile arg\u00242;
      private readonly int arg\u00243;
      private readonly int arg\u00244;

      internal __\u003C\u003EAnon5([In] PowerNode obj0, [In] Tile obj1, [In] int obj2, [In] int obj3)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
        this.arg\u00244 = obj3;
      }

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024drawPlace\u002414(this.arg\u00242, this.arg\u00243, this.arg\u00244, (Building) obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon6 : Boolf2
    {
      private readonly PowerNode arg\u00241;

      internal __\u003C\u003EAnon6([In] PowerNode obj0) => this.arg\u00241 = obj0;

      public bool get([In] object obj0, [In] object obj1) => (this.arg\u00241.lambda\u0024changePlacementPath\u002415((Point2) obj0, (Point2) obj1) ? 1 : 0) != 0;
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon7 : Boolf
    {
      private readonly PowerNode arg\u00241;
      private readonly Tile arg\u00242;
      private readonly Team arg\u00243;

      internal __\u003C\u003EAnon7([In] PowerNode obj0, [In] Tile obj1, [In] Team obj2)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
      }

      public bool get([In] object obj0) => (this.arg\u00241.lambda\u0024getPotentialLinks\u002417(this.arg\u00242, this.arg\u00243, (Building) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon8 : Intc2
    {
      private readonly Boolf arg\u00241;

      internal __\u003C\u003EAnon8([In] Boolf obj0) => this.arg\u00241 = obj0;

      public void get([In] int obj0, [In] int obj1) => PowerNode.lambda\u0024getPotentialLinks\u002418(this.arg\u00241, obj0, obj1);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon9 : Comparator
    {
      private readonly Tile arg\u00241;

      internal __\u003C\u003EAnon9([In] Tile obj0) => this.arg\u00241 = obj0;

      public int compare([In] object obj0, [In] object obj1) => PowerNode.lambda\u0024getPotentialLinks\u002419(this.arg\u00241, (Building) obj0, (Building) obj1);

      [SpecialName]
      public Comparator thenComparing([In] Comparator obj0) => Comparator.\u003Cdefault\u003EthenComparing((Comparator) this, obj0);

      [SpecialName]
      public bool equals([In] object obj0) => Object.instancehelper_equals((object) this, obj0);

      [SpecialName]
      public Comparator reversed() => Comparator.\u003Cdefault\u003Ereversed((Comparator) this);

      [SpecialName]
      public Comparator thenComparing([In] Function obj0, [In] Comparator obj1) => Comparator.\u003Cdefault\u003EthenComparing((Comparator) this, obj0, obj1);

      [SpecialName]
      public Comparator thenComparing([In] Function obj0) => Comparator.\u003Cdefault\u003EthenComparing((Comparator) this, obj0);

      [SpecialName]
      public Comparator thenComparingInt([In] ToIntFunction obj0) => Comparator.\u003Cdefault\u003EthenComparingInt((Comparator) this, obj0);

      [SpecialName]
      public Comparator thenComparingLong([In] ToLongFunction obj0) => Comparator.\u003Cdefault\u003EthenComparingLong((Comparator) this, obj0);

      [SpecialName]
      public Comparator thenComparingDouble([In] ToDoubleFunction obj0) => Comparator.\u003Cdefault\u003EthenComparingDouble((Comparator) this, obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon10 : Cons
    {
      private readonly PowerNode arg\u00241;
      private readonly Cons arg\u00242;

      internal __\u003C\u003EAnon10([In] PowerNode obj0, [In] Cons obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024getPotentialLinks\u002420(this.arg\u00242, (Building) obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon11 : Boolf
    {
      private readonly Tile arg\u00241;
      private readonly Block arg\u00242;
      private readonly Team arg\u00243;

      internal __\u003C\u003EAnon11([In] Tile obj0, [In] Block obj1, [In] Team obj2)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
      }

      public bool get([In] object obj0) => (PowerNode.lambda\u0024getNodeLinks\u002422(this.arg\u00241, this.arg\u00242, this.arg\u00243, (Building) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon12 : Intc2
    {
      private readonly Boolf arg\u00241;

      internal __\u003C\u003EAnon12([In] Boolf obj0) => this.arg\u00241 = obj0;

      public void get([In] int obj0, [In] int obj1) => PowerNode.lambda\u0024getNodeLinks\u002423(this.arg\u00241, obj0, obj1);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon13 : Comparator
    {
      private readonly Tile arg\u00241;

      internal __\u003C\u003EAnon13([In] Tile obj0) => this.arg\u00241 = obj0;

      public int compare([In] object obj0, [In] object obj1) => PowerNode.lambda\u0024getNodeLinks\u002424(this.arg\u00241, (Building) obj0, (Building) obj1);

      [SpecialName]
      public Comparator thenComparing([In] Comparator obj0) => Comparator.\u003Cdefault\u003EthenComparing((Comparator) this, obj0);

      [SpecialName]
      public bool equals([In] object obj0) => Object.instancehelper_equals((object) this, obj0);

      [SpecialName]
      public Comparator reversed() => Comparator.\u003Cdefault\u003Ereversed((Comparator) this);

      [SpecialName]
      public Comparator thenComparing([In] Function obj0, [In] Comparator obj1) => Comparator.\u003Cdefault\u003EthenComparing((Comparator) this, obj0, obj1);

      [SpecialName]
      public Comparator thenComparing([In] Function obj0) => Comparator.\u003Cdefault\u003EthenComparing((Comparator) this, obj0);

      [SpecialName]
      public Comparator thenComparingInt([In] ToIntFunction obj0) => Comparator.\u003Cdefault\u003EthenComparingInt((Comparator) this, obj0);

      [SpecialName]
      public Comparator thenComparingLong([In] ToLongFunction obj0) => Comparator.\u003Cdefault\u003EthenComparingLong((Comparator) this, obj0);

      [SpecialName]
      public Comparator thenComparingDouble([In] ToDoubleFunction obj0) => Comparator.\u003Cdefault\u003EthenComparingDouble((Comparator) this, obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon14 : Cons
    {
      private readonly Cons arg\u00241;

      internal __\u003C\u003EAnon14([In] Cons obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => PowerNode.lambda\u0024getNodeLinks\u002425(this.arg\u00241, (Building) obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon15 : Cons
    {
      private readonly int arg\u00241;
      private readonly int arg\u00242;
      private readonly BuildPlan arg\u00243;

      internal __\u003C\u003EAnon15([In] int obj0, [In] int obj1, [In] BuildPlan obj2)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
      }

      public void get([In] object obj0) => PowerNode.lambda\u0024drawRequestConfigTop\u002426(this.arg\u00241, this.arg\u00242, this.arg\u00243, (BuildPlan) obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon16 : Geometry.Raycaster
    {
      internal __\u003C\u003EAnon16()
      {
      }

      public bool accept([In] int obj0, [In] int obj1) => (PowerNode.lambda\u0024insulated\u002427(obj0, obj1) ? 1 : 0) != 0;
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon17 : Boolf
    {
      private readonly Tile arg\u00241;
      private readonly Building arg\u00242;

      internal __\u003C\u003EAnon17([In] Tile obj0, [In] Building obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public bool get([In] object obj0) => (PowerNode.lambda\u0024getNodeLinks\u002421(this.arg\u00241, this.arg\u00242, (Point2) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon18 : Boolf
    {
      private readonly Tile arg\u00241;
      private readonly Building arg\u00242;

      internal __\u003C\u003EAnon18([In] Tile obj0, [In] Building obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public bool get([In] object obj0) => (PowerNode.lambda\u0024getPotentialLinks\u002416(this.arg\u00241, this.arg\u00242, (Point2) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon19 : Prov
    {
      private readonly PowerNode arg\u00241;
      private readonly Building arg\u00242;

      internal __\u003C\u003EAnon19([In] PowerNode obj0, [In] Building obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public object get() => (object) this.arg\u00241.lambda\u0024setBars\u002410(this.arg\u00242);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon20 : Prov
    {
      internal __\u003C\u003EAnon20()
      {
      }

      public object get() => (object) PowerNode.lambda\u0024setBars\u002411();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon21 : Floatp
    {
      private readonly PowerNode arg\u00241;
      private readonly Building arg\u00242;

      internal __\u003C\u003EAnon21([In] PowerNode obj0, [In] Building obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public float get() => this.arg\u00241.lambda\u0024setBars\u002412(this.arg\u00242);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon22 : Prov
    {
      private readonly Building arg\u00241;

      internal __\u003C\u003EAnon22([In] Building obj0) => this.arg\u00241 = obj0;

      public object get() => (object) PowerNode.lambda\u0024setBars\u00246(this.arg\u00241);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon23 : Prov
    {
      internal __\u003C\u003EAnon23()
      {
      }

      public object get() => (object) PowerNode.lambda\u0024setBars\u00247();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon24 : Floatp
    {
      private readonly Building arg\u00241;

      internal __\u003C\u003EAnon24([In] Building obj0) => this.arg\u00241 = obj0;

      public float get() => PowerNode.lambda\u0024setBars\u00248(this.arg\u00241);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon25 : Prov
    {
      private readonly Building arg\u00241;

      internal __\u003C\u003EAnon25([In] Building obj0) => this.arg\u00241 = obj0;

      public object get() => (object) PowerNode.lambda\u0024setBars\u00242(this.arg\u00241);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon26 : Prov
    {
      internal __\u003C\u003EAnon26()
      {
      }

      public object get() => (object) PowerNode.lambda\u0024setBars\u00243();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon27 : Floatp
    {
      private readonly Building arg\u00241;

      internal __\u003C\u003EAnon27([In] Building obj0) => this.arg\u00241 = obj0;

      public float get() => PowerNode.lambda\u0024setBars\u00244(this.arg\u00241);
    }
  }
}
