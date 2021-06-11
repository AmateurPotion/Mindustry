// Decompiled with JetBrains decompiler
// Type: mindustry.ai.BlockIndexer
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.@struct;
using arc.func;
using arc.math;
using arc.math.geom;
using arc.util;
using ikvm.@internal;
using IKVM.Attributes;
using ikvm.lang;
using IKVM.Runtime;
using java.lang;
using java.util;
using java.util.function;
using mindustry.content;
using mindustry.core;
using mindustry.game;
using mindustry.gen;
using mindustry.type;
using mindustry.world;
using mindustry.world.blocks;
using mindustry.world.meta;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.ai
{
  public class BlockIndexer : Object
  {
    private const int quadrantSize = 16;
    [Modifiers]
    [Signature("Larc/struct/ObjectSet<Lmindustry/type/Item;>;")]
    private ObjectSet scanOres;
    [Modifiers]
    private IntSet intSet;
    [Modifiers]
    [Signature("Larc/struct/ObjectSet<Lmindustry/type/Item;>;")]
    private ObjectSet itemSet;
    [Signature("Larc/struct/ObjectMap<Lmindustry/type/Item;Lmindustry/ai/BlockIndexer$TileArray;>;")]
    private ObjectMap ores;
    private GridBits[] structQuadrants;
    [Signature("[Larc/struct/ObjectSet<Lmindustry/gen/Building;>;")]
    private ObjectSet[] damagedTiles;
    [Signature("Larc/struct/ObjectSet<Lmindustry/type/Item;>;")]
    private ObjectSet allOres;
    [Signature("Larc/struct/Seq<Lmindustry/game/Team;>;")]
    private Seq activeTeams;
    private BlockIndexer.TileArray[][] flagMap;
    private int[] unitCaps;
    [Signature("Larc/struct/IntMap<Lmindustry/ai/BlockIndexer$TileIndex;>;")]
    private IntMap typeMap;
    private BlockIndexer.TileArray emptySet;
    [Signature("Larc/struct/Seq<Lmindustry/world/Tile;>;")]
    private Seq returnArray;
    [Signature("Larc/struct/Seq<Lmindustry/gen/Building;>;")]
    private Seq breturnArray;

    [LineNumberTable(new byte[] {7, 232, 38, 107, 107, 139, 203, 145, 139, 144, 159, 20, 145, 139, 139, 139, 171, 213, 245, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public BlockIndexer()
    {
      BlockIndexer blockIndexer = this;
      this.scanOres = new ObjectSet();
      this.intSet = new IntSet();
      this.itemSet = new ObjectSet();
      this.ores = new ObjectMap();
      this.damagedTiles = new ObjectSet[Team.__\u003C\u003Eall.Length];
      this.allOres = new ObjectSet();
      this.activeTeams = new Seq((Class) ClassLiteral<Team>.Value);
      int length1 = Team.__\u003C\u003Eall.Length;
      int length2 = BlockFlag.__\u003C\u003Eall.Length;
      int[] numArray = new int[2];
      int num1 = length2;
      numArray[1] = num1;
      int num2 = length1;
      numArray[0] = num2;
      // ISSUE: type reference
      this.flagMap = (BlockIndexer.TileArray[][]) ByteCodeHelper.multianewarray(__typeref (BlockIndexer.TileArray[][]), numArray);
      this.unitCaps = new int[Team.__\u003C\u003Eall.Length];
      this.typeMap = new IntMap();
      this.emptySet = new BlockIndexer.TileArray();
      this.returnArray = new Seq();
      this.breturnArray = new Seq();
      Events.on((Class) ClassLiteral<EventType.TileChangeEvent>.Value, (Cons) new BlockIndexer.__\u003C\u003EAnon0(this));
      Events.on((Class) ClassLiteral<EventType.WorldLoadEvent>.Value, (Cons) new BlockIndexer.__\u003C\u003EAnon1(this));
    }

    [LineNumberTable(119)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private BlockIndexer.TileArray[] getFlagged([In] Team obj0) => this.flagMap[obj0.__\u003C\u003Eid];

    [LineNumberTable(new byte[] {160, 226, 115, 110, 123, 127, 4, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void updateCap([In] Team obj0)
    {
      BlockIndexer.TileArray tileArray = this.getFlagged(obj0)[BlockFlag.__\u003C\u003EunitModifier.ordinal()];
      this.unitCaps[obj0.__\u003C\u003Eid] = 0;
      Iterator iterator = tileArray.iterator();
      while (iterator.hasNext())
      {
        Tile tile = (Tile) iterator.next();
        int[] unitCaps = this.unitCaps;
        int id = obj0.__\u003C\u003Eid;
        int[] numArray = unitCaps;
        numArray[id] = numArray[id] + tile.block().unitCapModifier;
      }
    }

    [LineNumberTable(new byte[] {160, 234, 127, 23, 141, 159, 6, 137, 135, 105, 130, 119, 172, 191, 9, 115, 177, 137, 107, 107, 139, 191, 31, 127, 19, 127, 19, 112, 159, 23, 243, 60, 43, 235, 74, 127, 5, 180, 111, 139, 137, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void process([In] Tile obj0)
    {
      if (obj0.block().flags.size() > 0 && !object.ReferenceEquals((object) obj0.team(), (object) Team.__\u003C\u003Ederelict) && obj0.isCenter())
      {
        BlockIndexer.TileArray[] flagged = this.getFlagged(obj0.team());
        Iterator iterator = obj0.block().flags.iterator();
        while (iterator.hasNext())
        {
          BlockFlag blockFlag = (BlockFlag) iterator.next();
          BlockIndexer.TileArray tileArray = flagged[blockFlag.ordinal()];
          tileArray.add(obj0);
          flagged[blockFlag.ordinal()] = tileArray;
        }
        if (obj0.block().flags.contains((Enum) BlockFlag.__\u003C\u003EunitModifier))
          this.updateCap(obj0.team());
        this.typeMap.put(obj0.pos(), (object) new BlockIndexer.TileIndex(obj0.block().flags, obj0.team()));
      }
      if (!this.activeTeams.contains((object) obj0.team()))
        this.activeTeams.add((object) obj0.team());
      if (this.ores == null)
        return;
      int num1 = (int) obj0.x / 16;
      int num2 = (int) obj0.y / 16;
      this.itemSet.clear();
      Tile tile1 = Vars.world.rawTile(Mathf.clamp(num1 * 16 + 8, 0, Vars.world.width() - 1), Mathf.clamp(num2 * 16 + 8, 0, Vars.world.height() - 1));
      for (int x = Math.max(0, (int) tile1.x - 8); x < (int) tile1.x + 8 && x < Vars.world.width(); ++x)
      {
        for (int y = Math.max(0, (int) tile1.y - 8); y < (int) tile1.y + 8 && y < Vars.world.height(); ++y)
        {
          Tile tile2 = Vars.world.tile(x, y);
          if (tile2 != null && tile2.drop() != null && (this.scanOres.contains((object) tile2.drop()) && object.ReferenceEquals((object) tile2.block(), (object) Blocks.air)))
            this.itemSet.add((object) tile2.drop());
        }
      }
      ObjectSet.ObjectSetIterator objectSetIterator = this.scanOres.iterator();
      while (((Iterator) objectSetIterator).hasNext())
      {
        Item obj = (Item) ((Iterator) objectSetIterator).next();
        BlockIndexer.TileArray tileArray = (BlockIndexer.TileArray) this.ores.get((object) obj);
        if (!this.itemSet.contains((object) obj))
          tileArray.remove(tile1);
        else
          tileArray.add(tile1);
      }
    }

    [LineNumberTable(new byte[] {161, 33, 169, 106, 138, 127, 4, 169, 127, 4, 105, 162, 170, 127, 5, 126, 144, 115, 105, 226, 59, 40, 235, 74, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void updateQuadrant([In] Tile obj0)
    {
      if (this.structQuadrants == null)
        return;
      int x1 = (int) obj0.x / 16;
      int y1 = (int) obj0.y / 16;
      Iterator iterator = this.activeTeams.iterator();
label_3:
      while (iterator.hasNext())
      {
        Team team = (Team) iterator.next();
        GridBits gridBits = this.structQuadrant(team);
        if (object.ReferenceEquals((object) obj0.team(), (object) team) && obj0.build != null && obj0.block().targetable)
        {
          gridBits.set(x1, y1);
        }
        else
        {
          gridBits.set(x1, y1, false);
          int x2 = x1 * 16;
          while (true)
          {
            if (x2 < Vars.world.width() && x2 < (x1 + 1) * 16)
            {
              for (int y2 = y1 * 16; y2 < Vars.world.height() && y2 < (y1 + 1) * 16; ++y2)
              {
                Building building = Vars.world.build(x2, y2);
                if (building != null && object.ReferenceEquals((object) building.team, (object) team))
                {
                  gridBits.set(x1, y1);
                  goto label_3;
                }
              }
              ++x2;
            }
            else
              goto label_3;
          }
        }
      }
    }

    [LineNumberTable(new byte[] {73, 111, 159, 33})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private GridBits structQuadrant([In] Team obj0)
    {
      if (this.structQuadrants[obj0.__\u003C\u003Eid] == null)
        this.structQuadrants[obj0.__\u003C\u003Eid] = new GridBits(Mathf.ceil((float) Vars.world.width() / 16f), Mathf.ceil((float) Vars.world.height() / 16f));
      return this.structQuadrants[obj0.__\u003C\u003Eid];
    }

    [LineNumberTable(172)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual BlockIndexer.TileArray getAllied(Team team, BlockFlag type) => this.flagMap[team.__\u003C\u003Eid][type.ordinal()];

    [Signature("(Lmindustry/game/Team;FFFLarc/func/Boolf<Lmindustry/gen/Building;>;Larc/func/Cons<Lmindustry/gen/Building;>;)Z")]
    [LineNumberTable(new byte[] {160, 71, 139, 104, 136, 119, 130, 112, 112, 154, 144, 134, 127, 18, 105, 226, 55, 43, 235, 79})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool eachBlock(
      Team team,
      float wx,
      float wy,
      float range,
      Boolf pred,
      Cons cons)
    {
      this.intSet.clear();
      int tile1 = World.toTile(wx);
      int tile2 = World.toTile(wy);
      int num1 = ByteCodeHelper.f2i(range / 8f + 1f);
      int num2 = 0;
      for (int x = -num1 + tile1; x <= num1 + tile1; ++x)
      {
        for (int y = -num1 + tile2; y <= num1 + tile2; ++y)
        {
          if (Mathf.within((float) (x * 8), (float) (y * 8), wx, wy, range))
          {
            Building building = Vars.world.build(x, y);
            if (building != null && (team == null || object.ReferenceEquals((object) building.team, (object) team)) && (pred.get((object) building) && this.intSet.add(building.pos())))
            {
              cons.get((object) building);
              num2 = 1;
            }
          }
        }
      }
      return num2 != 0;
    }

    [Signature("(Lmindustry/game/Team;FFFLarc/func/Boolf<Lmindustry/gen/Building;>;Z)Lmindustry/gen/Building;")]
    [LineNumberTable(new byte[] {159, 75, 131, 98, 134, 127, 46, 159, 49, 145, 127, 5, 127, 7, 144, 159, 49, 127, 0, 159, 1, 159, 7, 120, 99, 227, 52, 43, 235, 60, 43, 233, 89})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Building findTile(
      Team team,
      float x,
      float y,
      float range,
      Boolf pred,
      bool usePriority)
    {
      int num1 = usePriority ? 1 : 0;
      Building building1 = (Building) null;
      float num2 = 0.0f;
      for (int index1 = Math.max(ByteCodeHelper.f2i((x - range) / 8f / 16f), 0); index1 <= ByteCodeHelper.f2i((x + range) / 8f / 16f) && index1 < this.quadWidth(); ++index1)
      {
        for (int index2 = Math.max(ByteCodeHelper.f2i((y - range) / 8f / 16f), 0); index2 <= ByteCodeHelper.f2i((y + range) / 8f / 16f) && index2 < this.quadHeight(); ++index2)
        {
          if (this.getQuad(team, index1, index2))
          {
            for (int x1 = index1 * 16; x1 < (index1 + 1) * 16 && x1 < Vars.world.width(); ++x1)
            {
              for (int y1 = index2 * 16; y1 < (index2 + 1) * 16 && y1 < Vars.world.height(); ++y1)
              {
                Building building2 = Vars.world.build(x1, y1);
                if (building2 != null && object.ReferenceEquals((object) building2.team, (object) team) && (pred.get((object) building2) && building2.block.targetable) && !object.ReferenceEquals((object) building2.team, (object) Team.__\u003C\u003Ederelict))
                {
                  float num3 = building2.dst(x, y) - building2.hitSize() / 2f;
                  if ((double) num3 < (double) range && (building1 == null || (double) num3 < (double) num2 && (num1 == 0 || building1.block.priority.ordinal() <= building2.block.priority.ordinal()) || num1 != 0 && building1.block.priority.ordinal() < building2.block.priority.ordinal()))
                  {
                    num2 = num3;
                    building1 = building2;
                  }
                }
              }
            }
          }
        }
      }
      return building1;
    }

    [LineNumberTable(439)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private int quadWidth() => Mathf.ceil((float) Vars.world.width() / 16f);

    [LineNumberTable(443)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private int quadHeight() => Mathf.ceil((float) Vars.world.height() / 16f);

    [LineNumberTable(435)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool getQuad([In] Team obj0, [In] int obj1, [In] int obj2) => this.structQuadrant(obj0).get(obj1, obj2);

    [LineNumberTable(308)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual BlockIndexer.TileArray getOrePositions(Item item) => (BlockIndexer.TileArray) this.ores.get((object) item, (object) this.emptySet);

    [LineNumberTable(new byte[] {160, 199, 150, 133, 127, 14, 127, 8, 109, 127, 1, 226, 61, 38, 233, 73})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Tile findClosestOre(float xp, float yp, Item item)
    {
      Tile closest = (Tile) Geometry.findClosest(xp, yp, (Iterable) this.getOrePositions(item));
      if (closest == null)
        return (Tile) null;
      for (int x = Math.max(0, (int) closest.x - 8); x < (int) closest.x + 8 && x < Vars.world.width(); ++x)
      {
        for (int y = Math.max(0, (int) closest.y - 8); y < (int) closest.y + 8 && y < Vars.world.height(); ++y)
        {
          Tile tile = Vars.world.tile(x, y);
          if (object.ReferenceEquals((object) tile.block(), (object) Blocks.air) && object.ReferenceEquals((object) tile.drop(), (object) item))
            return tile;
        }
      }
      return (Tile) null;
    }

    [LineNumberTable(new byte[] {160, 129, 116, 183, 121})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void notifyTileDamaged(Building entity)
    {
      if (this.damagedTiles[entity.team.__\u003C\u003Eid] == null)
        this.damagedTiles[entity.team.__\u003C\u003Eid] = new ObjectSet();
      this.damagedTiles[entity.team.__\u003C\u003Eid].add((object) entity);
    }

    [LineNumberTable(new byte[] {161, 77, 171, 127, 1, 114, 130, 127, 8, 107, 171, 127, 17, 159, 9, 121, 236, 61, 234, 69, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void scanOres()
    {
      this.ores = new ObjectMap();
      ObjectSet.ObjectSetIterator objectSetIterator = this.scanOres.iterator();
      while (((Iterator) objectSetIterator).hasNext())
        this.ores.put((object) (Item) ((Iterator) objectSetIterator).next(), (object) new BlockIndexer.TileArray());
      Iterator iterator = Vars.world.tiles.iterator();
      while (iterator.hasNext())
      {
        Tile tile = (Tile) iterator.next();
        int num1 = (int) tile.x / 16;
        int num2 = (int) tile.y / 16;
        if (tile.drop() != null && this.scanOres.contains((object) tile.drop()) && object.ReferenceEquals((object) tile.block(), (object) Blocks.air))
          ((BlockIndexer.TileArray) this.ores.get((object) tile.drop())).add(Vars.world.tile(Mathf.clamp(num1 * 16 + 8, 0, Vars.world.width() - 1), Mathf.clamp(num2 * 16 + 8, 0, Vars.world.height() - 1)));
      }
    }

    [LineNumberTable(new byte[] {54, 118, 119, 127, 1, 121, 130, 114, 172, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void updateIndices(Tile tile)
    {
      if (this.typeMap.get(tile.pos()) != null)
      {
        BlockIndexer.TileIndex tileIndex = (BlockIndexer.TileIndex) this.typeMap.get(tile.pos());
        Iterator iterator = tileIndex.flags.iterator();
        while (iterator.hasNext())
        {
          BlockFlag blockFlag = (BlockFlag) iterator.next();
          this.getFlagged(tileIndex.team)[blockFlag.ordinal()].remove(tile);
        }
        if (tileIndex.flags.contains((Enum) BlockFlag.__\u003C\u003EunitModifier))
          this.updateCap(tileIndex.team);
      }
      this.process(tile);
      this.updateQuadrant(tile);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {9, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u00240([In] EventType.TileChangeEvent obj0) => this.updateIndices(obj0.__\u003C\u003Etile);

    [Modifiers]
    [LineNumberTable(new byte[] {13, 107, 112, 113, 127, 20, 113, 144, 108, 107, 47, 38, 230, 70, 107, 107, 167, 145, 127, 9, 136, 119, 173, 124, 130, 107, 107, 56, 38, 230, 70, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u00241([In] EventType.WorldLoadEvent obj0)
    {
      this.scanOres.clear();
      this.scanOres.addAll(Item.getAllOres());
      this.damagedTiles = new ObjectSet[Team.__\u003C\u003Eall.Length];
      int length1 = Team.__\u003C\u003Eall.Length;
      int length2 = BlockFlag.__\u003C\u003Eall.Length;
      int[] numArray = new int[2];
      int num1 = length2;
      numArray[1] = num1;
      int num2 = length1;
      numArray[0] = num2;
      // ISSUE: type reference
      this.flagMap = (BlockIndexer.TileArray[][]) ByteCodeHelper.multianewarray(__typeref (BlockIndexer.TileArray[][]), numArray);
      this.unitCaps = new int[Team.__\u003C\u003Eall.Length];
      this.activeTeams = new Seq((Class) ClassLiteral<Team>.Value);
      for (int index1 = 0; index1 < this.flagMap.Length; ++index1)
      {
        for (int index2 = 0; index2 < BlockFlag.__\u003C\u003Eall.Length; ++index2)
          this.flagMap[index1][index2] = new BlockIndexer.TileArray();
      }
      this.typeMap.clear();
      this.allOres.clear();
      this.ores = (ObjectMap) null;
      this.structQuadrants = new GridBits[Team.__\u003C\u003Eall.Length];
      Iterator iterator = Vars.world.tiles.iterator();
      while (iterator.hasNext())
      {
        Tile tile = (Tile) iterator.next();
        this.process(tile);
        if (tile.build != null && tile.build.damaged())
          this.notifyTileDamaged(tile.build);
        if (tile.drop() != null)
          this.allOres.add((object) tile.drop());
      }
      for (int index1 = 0; index1 < this.quadWidth(); ++index1)
      {
        for (int index2 = 0; index2 < this.quadHeight(); ++index2)
          this.updateQuadrant(Vars.world.tile(index1 * 16, index2 * 16));
      }
      this.scanOres();
    }

    [LineNumberTable(new byte[] {81, 169, 127, 5, 110, 106, 106, 142, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void updateTeamIndex(Team team)
    {
      if (this.structQuadrants == null)
        return;
      Iterator iterator = Vars.world.tiles.iterator();
      while (iterator.hasNext())
      {
        Tile tile = (Tile) iterator.next();
        if (object.ReferenceEquals((object) tile.team(), (object) team))
        {
          int x = (int) tile.x / 16;
          int y = (int) tile.y / 16;
          this.structQuadrant(team).set(x, y);
        }
      }
    }

    [LineNumberTable(145)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool hasOre(Item item) => this.allOres.contains((object) item);

    [Signature("(Lmindustry/game/Team;)Larc/struct/ObjectSet<Lmindustry/gen/Building;>;")]
    [LineNumberTable(new byte[] {100, 140, 111, 178, 110, 123, 127, 12, 140, 130, 127, 1, 104, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual ObjectSet getDamaged(Team team)
    {
      this.breturnArray.clear();
      if (this.damagedTiles[team.__\u003C\u003Eid] == null)
        this.damagedTiles[team.__\u003C\u003Eid] = new ObjectSet();
      ObjectSet damagedTile = this.damagedTiles[team.__\u003C\u003Eid];
      ObjectSet.ObjectSetIterator objectSetIterator = damagedTile.iterator();
      while (((Iterator) objectSetIterator).hasNext())
      {
        Building building = (Building) ((Iterator) objectSetIterator).next();
        if (!building.isValid() || !object.ReferenceEquals((object) building.team, (object) team) || (!building.damaged() || building.block is ConstructBlock))
          this.breturnArray.add((object) building);
      }
      Iterator iterator = this.breturnArray.iterator();
      while (iterator.hasNext())
      {
        Building building = (Building) iterator.next();
        damagedTile.remove((object) building);
      }
      return damagedTile;
    }

    [LineNumberTable(177)]
    [Nullable(new object[] {64, "Larc/util/Nullable;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Tile findClosestFlag(float x, float y, Team team, BlockFlag flag) => (Tile) Geometry.findClosest(x, y, (Iterable) this.getAllied(team, flag));

    [Signature("(Lmindustry/gen/Teamc;FLarc/func/Boolf<Lmindustry/gen/Building;>;Larc/func/Cons<Lmindustry/gen/Building;>;)Z")]
    [LineNumberTable(181)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool eachBlock(Teamc team, float range, Boolf pred, Cons cons) => this.eachBlock(team.team(), ((Posc) team).getX(), ((Posc) team).getY(), range, pred, cons);

    [Signature("(Lmindustry/game/Team;Lmindustry/world/meta/BlockFlag;)Larc/struct/Seq<Lmindustry/world/Tile;>;")]
    [LineNumberTable(new byte[] {160, 99, 108, 144, 107, 119, 108, 113, 100, 127, 1, 109, 226, 58, 238, 74, 112, 117, 108, 113, 100, 127, 1, 109, 226, 57, 235, 76})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Seq getEnemy(Team team, BlockFlag type)
    {
      this.returnArray.clear();
      Seq present = Vars.state.teams.present;
      if (present.isEmpty())
      {
        Team[] all = Team.__\u003C\u003Eall;
        int length = all.Length;
        for (int index = 0; index < length; ++index)
        {
          Team team1 = all[index];
          if (!object.ReferenceEquals((object) team1, (object) team))
          {
            BlockIndexer.TileArray tileArray = this.getFlagged(team1)[type.ordinal()];
            if (tileArray != null)
            {
              Iterator iterator = tileArray.iterator();
              while (iterator.hasNext())
                this.returnArray.add((object) (Tile) iterator.next());
            }
          }
        }
      }
      else
      {
        for (int index = 0; index < present.size; ++index)
        {
          Team team1 = ((Teams.TeamData[]) present.items)[index].__\u003C\u003Eteam;
          if (!object.ReferenceEquals((object) team1, (object) team))
          {
            BlockIndexer.TileArray tileArray = this.getFlagged(team1)[type.ordinal()];
            if (tileArray != null)
            {
              Iterator iterator = tileArray.iterator();
              while (iterator.hasNext())
                this.returnArray.add((object) (Tile) iterator.next());
            }
          }
        }
      }
      return this.returnArray;
    }

    [Signature("(Lmindustry/game/Team;FFFLarc/func/Boolf<Lmindustry/gen/Building;>;)Lmindustry/gen/Building;")]
    [LineNumberTable(new byte[] {160, 137, 112, 147, 152, 118, 99, 226, 57, 233, 75})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Building findEnemyTile(
      Team team,
      float x,
      float y,
      float range,
      Boolf pred)
    {
      for (int index = 0; index < this.activeTeams.size; ++index)
      {
        Team team1 = ((Team[]) this.activeTeams.items)[index];
        if (!object.ReferenceEquals((object) team1, (object) team) && !object.ReferenceEquals((object) team, (object) Team.__\u003C\u003Ederelict))
        {
          Building tile = Vars.indexer.findTile(team1, x, y, range, pred, true);
          if (tile != null)
            return tile;
        }
      }
      return (Building) null;
    }

    [Signature("(Lmindustry/game/Team;FFFLarc/func/Boolf<Lmindustry/gen/Building;>;)Lmindustry/gen/Building;")]
    [LineNumberTable(266)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Building findTile(
      Team team,
      float x,
      float y,
      float range,
      Boolf pred)
    {
      return this.findTile(team, x, y, range, pred, false);
    }

    [LineNumberTable(331)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Tile findClosestOre(Unit unit, Item item) => this.findClosestOre(unit.x, unit.y, item);

    [LineNumberTable(336)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getExtraUnits(Team team) => this.unitCaps[team.__\u003C\u003Eid];

    [Signature("Ljava/lang/Object;Ljava/lang/Iterable<Lmindustry/world/Tile;>;")]
    [Implements(new string[] {"java.lang.Iterable"})]
    public class TileArray : Object, Iterable, IEnumerable
    {
      [Signature("Larc/struct/Seq<Lmindustry/world/Tile;>;")]
      internal Seq tiles;
      internal IntSet contained;

      [LineNumberTable(new byte[] {161, 108, 104, 110})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public TileArray()
      {
        BlockIndexer.TileArray tileArray = this;
        this.tiles = new Seq(false, 16);
        this.contained = new IntSet();
      }

      [LineNumberTable(new byte[] {161, 113, 115, 140})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void add(Tile tile)
      {
        if (!this.contained.add(tile.pos()))
          return;
        this.tiles.add((object) tile);
      }

      [LineNumberTable(new byte[] {161, 119, 115, 141})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void remove(Tile tile)
      {
        if (!this.contained.remove(tile.pos()))
          return;
        this.tiles.remove((object) tile);
      }

      [LineNumberTable(495)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual int size() => this.tiles.size;

      [LineNumberTable(499)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual Tile first() => (Tile) this.tiles.first();

      [Signature("()Ljava/util/Iterator<Lmindustry/world/Tile;>;")]
      [LineNumberTable(504)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual Iterator iterator() => this.tiles.iterator();

      [HideFromJava]
      public virtual void forEach([In] Consumer obj0) => Iterable.\u003Cdefault\u003EforEach((Iterable) this, obj0);

      [HideFromJava]
      public virtual Spliterator spliterator() => Iterable.\u003Cdefault\u003Espliterator((Iterable) this);

      [HideFromJava]
      [SpecialName]
      IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) new IterableEnumerator((Iterable) this);
    }

    [InnerClass]
    internal class TileIndex : Object
    {
      [Modifiers]
      [Signature("Larc/struct/EnumSet<Lmindustry/world/meta/BlockFlag;>;")]
      public EnumSet flags;
      [Modifiers]
      public Team team;

      [Signature("(Larc/struct/EnumSet<Lmindustry/world/meta/BlockFlag;>;Lmindustry/game/Team;)V")]
      [LineNumberTable(new byte[] {161, 102, 104, 103, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public TileIndex([In] EnumSet obj0, [In] Team obj1)
      {
        BlockIndexer.TileIndex tileIndex = this;
        this.flags = obj0;
        this.team = obj1;
      }
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Cons
    {
      private readonly BlockIndexer arg\u00241;

      internal __\u003C\u003EAnon0([In] BlockIndexer obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024new\u00240((EventType.TileChangeEvent) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Cons
    {
      private readonly BlockIndexer arg\u00241;

      internal __\u003C\u003EAnon1([In] BlockIndexer obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024new\u00241((EventType.WorldLoadEvent) obj0);
    }
  }
}
