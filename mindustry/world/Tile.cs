// Decompiled with JetBrains decompiler
// Type: mindustry.world.Tile
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.func;
using arc.math;
using arc.math.geom;
using arc.scene;
using arc.scene.ui;
using arc.scene.ui.layout;
using arc.util;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.util;
using mindustry.content;
using mindustry.game;
using mindustry.gen;
using mindustry.type;
using mindustry.ui;
using mindustry.world.blocks.environment;
using mindustry.world.modules;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.world
{
  [Implements(new string[] {"arc.math.geom.Position", "arc.math.geom.QuadTree$QuadTreeObject", "mindustry.ui.Displayable"})]
  public class Tile : Object, Position, QuadTree.QuadTreeObject, Displayable
  {
    [Modifiers]
    [Signature("Larc/struct/ObjectSet<Lmindustry/gen/Building;>;")]
    internal static ObjectSet tileSet;
    public byte data;
    [Nullable(new object[] {64, "Larc/util/Nullable;"})]
    public Building build;
    public short x;
    public short y;
    protected internal Block block;
    protected internal Floor floor;
    protected internal Floor overlay;
    protected internal bool changing;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(166)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Team team() => this.build == null ? Team.__\u003C\u003Ederelict : this.build.team;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Block block() => this.block;

    [LineNumberTable(58)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int pos() => Point2.pack((int) this.x, (int) this.y);

    [LineNumberTable(new byte[] {161, 97, 124, 125, 125, 125})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Tile nearby(int rotation)
    {
      switch (rotation)
      {
        case 0:
          return Vars.world.tile((int) this.x + 1, (int) this.y);
        case 1:
          return Vars.world.tile((int) this.x, (int) this.y + 1);
        case 2:
          return Vars.world.tile((int) this.x - 1, (int) this.y);
        case 3:
          return Vars.world.tile((int) this.x, (int) this.y - 1);
        default:
          return (Tile) null;
      }
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual byte relativeTo(int cx, int cy)
    {
      if ((int) this.x == cx && (int) this.y == cy - 1)
        return 1;
      if ((int) this.x == cx && (int) this.y == cy + 1)
        return 3;
      if ((int) this.x == cx - 1 && (int) this.y == cy)
        return 0;
      return (int) this.x == cx + 1 && (int) this.y == cy ? (byte) 2 : byte.MaxValue;
    }

    [LineNumberTable(487)]
    [Nullable(new object[] {64, "Larc/util/Nullable;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Item drop() => object.ReferenceEquals((object) this.overlay, (object) Blocks.air) || this.overlay.itemDrop == null ? this.floor.itemDrop : this.overlay.itemDrop;

    [Signature("(Lmindustry/world/Block;Larc/struct/Seq<Lmindustry/world/Tile;>;)Larc/struct/Seq<Lmindustry/world/Tile;>;")]
    [LineNumberTable(new byte[] {161, 51, 103, 121})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Seq getLinkedTilesAs(Block block, Seq tmpArray)
    {
      tmpArray.clear();
      Block block1 = block;
      Seq seq = tmpArray;
      Objects.requireNonNull((object) seq);
      Cons tmpArray1 = (Cons) new Tile.__\u003C\u003EAnon4(seq);
      this.getLinkedTilesAs(block1, tmpArray1);
      return tmpArray;
    }

    [HideFromJava]
    public virtual float angleTo([In] Position obj0) => Position.\u003Cdefault\u003EangleTo((Position) this, obj0);

    [HideFromJava]
    public virtual bool within([In] Position obj0, [In] float obj1) => Position.\u003Cdefault\u003Ewithin((Position) this, obj0, obj1);

    [LineNumberTable(176)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isCenter() => this.build == null || object.ReferenceEquals((object) this.build.tile(), (object) this);

    [LineNumberTable(374)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool solid() => this.block.solid || this.floor.solid || this.build != null && this.build.checkSolid();

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Floor floor() => this.floor;

    [LineNumberTable(188)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getTeamID() => this.team().__\u003C\u003Eid;

    [LineNumberTable(491)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int staticDarkness() => this.block.solid && this.block.fillsTile && !this.block.synthetic() ? (int) (sbyte) this.data : 0;

    [Signature("(Larc/func/Cons<Lmindustry/world/Tile;>;)V")]
    [LineNumberTable(new byte[] {161, 21, 112, 108, 103, 103, 102, 104, 127, 2, 12, 40, 230, 70, 98, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void getLinkedTiles(Cons cons)
    {
      if (this.block.isMultiblock())
      {
        int size = this.block.size;
        int num1 = -(size - 1) / 2;
        int num2 = -(size - 1) / 2;
        for (int index1 = 0; index1 < size; ++index1)
        {
          for (int index2 = 0; index2 < size; ++index2)
          {
            Tile tile = Vars.world.tile((int) this.x + index1 + num1, (int) this.y + index2 + num2);
            if (tile != null)
              cons.get((object) tile);
          }
        }
      }
      else
        cons.get((object) this);
    }

    [LineNumberTable(383)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool dangerous() => !this.block.solid && (this.floor.isDeep() || (double) this.floor.damageTaken > 0.0);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float worldx() => (float) ((int) this.x * 8);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float worldy() => (float) ((int) this.y * 8);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Floor overlay() => this.overlay;

    [LineNumberTable(137)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float drawx() => this.block().offset + this.worldx();

    [LineNumberTable(141)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float drawy() => this.block().offset + this.worldy();

    [LineNumberTable(459)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Tile nearby(Point2 relative) => Vars.world.tile((int) this.x + relative.x, (int) this.y + relative.y);

    [LineNumberTable(new byte[] {161, 105, 124, 125, 125, 125})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Building nearbyBuild(int rotation)
    {
      switch (rotation)
      {
        case 0:
          return Vars.world.build((int) this.x + 1, (int) this.y);
        case 1:
          return Vars.world.build((int) this.x, (int) this.y + 1);
        case 2:
          return Vars.world.build((int) this.x - 1, (int) this.y);
        case 3:
          return Vars.world.build((int) this.x, (int) this.y - 1);
        default:
          return (Building) null;
      }
    }

    [LineNumberTable(62)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual byte relativeTo(Tile tile) => this.relativeTo((int) tile.x, (int) tile.y);

    [LineNumberTable(new byte[] {35, 121, 124, 109, 144, 109, 176, 127, 15, 118, 150, 118, 214})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual byte absoluteRelativeTo(int cx, int cy)
    {
      int size = this.block.size;
      int num = 2;
      if ((num != -1 ? size % num : 0) == 1)
      {
        if (Math.abs((int) this.x - cx) > Math.abs((int) this.y - cy))
        {
          if ((int) this.x <= cx - 1)
            return 0;
          if ((int) this.x >= cx + 1)
            return 2;
        }
        else
        {
          if ((int) this.y <= cy - 1)
            return 1;
          if ((int) this.y >= cy + 1)
            return 3;
        }
      }
      else if ((double) Math.abs((float) ((int) this.x - cx) + 0.5f) > (double) Math.abs((float) ((int) this.y - cy) + 0.5f))
      {
        if ((double) ((float) this.x + 0.5f) <= (double) (cx - 1))
          return 0;
        if ((double) ((float) this.x + 0.5f) >= (double) (cx + 1))
          return 2;
      }
      else
      {
        if ((double) ((float) this.y + 0.5f) <= (double) (cy - 1))
          return 1;
        if ((double) ((float) this.y + 0.5f) >= (double) (cy + 1))
          return 3;
      }
      return byte.MaxValue;
    }

    [LineNumberTable(446)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Rect getHitbox(Rect rect) => rect.setCentered(this.drawx(), this.drawy(), (float) (this.block.size * 8), (float) (this.block.size * 8));

    [LineNumberTable(new byte[] {160, 138, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setBlock(Block type, Team team) => this.setBlock(type, team, 0);

    [LineNumberTable(new byte[] {160, 191, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void remove() => this.setBlock(Blocks.air);

    [LineNumberTable(new byte[] {160, 78, 123})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setBlock(Block type, Team team, int rotation)
    {
      Block type1 = type;
      Team team1 = team;
      int rotation1 = rotation;
      Block block = type;
      Objects.requireNonNull((object) block);
      Prov entityprov = (Prov) new Tile.__\u003C\u003EAnon0(block);
      this.setBlock(type1, team1, rotation1, entityprov);
    }

    [LineNumberTable(new byte[] {3, 127, 12})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Tile(int x, int y, int floor, int overlay, int wall)
      : this(x, y, Vars.content.block(floor), Vars.content.block(overlay), Vars.content.block(wall))
    {
    }

    [LineNumberTable(365)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool passable() => (!this.floor.solid || !object.ReferenceEquals((object) this.block, (object) Blocks.air) && !this.block.solidifes) && (!this.block.solid || this.block.destructible || this.block.update);

    [LineNumberTable(145)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isDarkened() => this.block.solid && !this.block.synthetic() && this.block.fillsTile;

    [LineNumberTable(342)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual short floorID() => this.floor.__\u003C\u003Eid;

    [LineNumberTable(338)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual short blockID() => this.block.__\u003C\u003Eid;

    [LineNumberTable(334)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual short overlayID() => this.overlay.__\u003C\u003Eid;

    [LineNumberTable(new byte[] {160, 147, 103, 144, 102, 104, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setFloor(Floor type)
    {
      this.floor = type;
      this.overlay = (Floor) Blocks.air;
      this.recache();
      if (this.build == null)
        return;
      this.build.onProximityUpdate();
    }

    [LineNumberTable(new byte[] {120, 104, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setTeam(Team team)
    {
      if (this.build == null)
        return;
      this.build.team(team);
    }

    [LineNumberTable(new byte[] {159, 56, 130, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setOverlayID(short ore)
    {
      int id = (int) ore;
      this.setOverlay(Vars.content.block(id));
    }

    [Signature("(Lmindustry/game/Team;Larc/func/Prov<Lmindustry/gen/Building;>;I)V")]
    [LineNumberTable(new byte[] {161, 167, 107, 113, 107, 167, 138, 117, 127, 9, 100, 237, 61, 230, 72, 127, 4, 103, 162, 109, 159, 23})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void changeBuild(Team team, Prov entityprov, int rotation)
    {
      if (this.build != null)
      {
        int size = this.build.block.size;
        this.build.remove();
        this.build = (Building) null;
        Tile.tileSet.clear();
        Point2[] edges = Edges.getEdges(size);
        int length = edges.Length;
        for (int index = 0; index < length; ++index)
        {
          Point2 point2 = edges[index];
          Building building = Vars.world.build((int) this.x + point2.x, (int) this.y + point2.y);
          if (building != null)
            Tile.tileSet.add((object) building);
        }
        ObjectSet.ObjectSetIterator objectSetIterator = Tile.tileSet.iterator();
        while (((Iterator) objectSetIterator).hasNext())
          ((Building) ((Iterator) objectSetIterator).next()).updateProximity();
      }
      if (!this.block.hasBuilding())
        return;
      this.build = ((Building) entityprov.get()).init(this, team, this.block.update && !Vars.state.isEditor(), rotation);
    }

    [LineNumberTable(new byte[] {161, 194, 111, 104, 176, 115, 127, 7, 114, 231, 61, 230, 73, 166, 109, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void changed()
    {
      if (!Vars.world.isGenerating())
      {
        if (this.build != null)
        {
          this.build.updateProximity();
        }
        else
        {
          Point2[] d4 = Geometry.__\u003C\u003Ed4;
          int length = d4.Length;
          for (int index = 0; index < length; ++index)
          {
            Point2 point2 = d4[index];
            Building building = Vars.world.build((int) this.x + point2.x, (int) this.y + point2.y);
            if (building != null && !building.tile.changing)
              building.onProximityUpdate();
          }
        }
      }
      this.fireChanged();
      if (!this.block.isStatic())
        return;
      this.recache();
    }

    [LineNumberTable(new byte[] {159, 182, 232, 56, 231, 73, 104, 104, 108, 109, 168, 127, 0, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Tile(int x, int y, Block floor, Block overlay, Block wall)
    {
      Tile tile = this;
      this.changing = false;
      this.x = (short) x;
      this.y = (short) y;
      this.floor = (Floor) floor;
      this.overlay = (Floor) overlay;
      this.block = wall;
      Team derelict = Team.__\u003C\u003Ederelict;
      Block block = wall;
      Objects.requireNonNull((object) block);
      Prov entityprov = (Prov) new Tile.__\u003C\u003EAnon0(block);
      this.changeBuild(derelict, entityprov, 0);
      this.changed();
    }

    [Signature("(Lmindustry/world/Block;Lmindustry/game/Team;ILarc/func/Prov<Lmindustry/gen/Building;>;)V")]
    [LineNumberTable(new byte[] {160, 82, 135, 117, 166, 103, 102, 145, 104, 204, 112, 113, 113, 103, 167, 107, 112, 112, 109, 109, 116, 144, 100, 132, 206, 104, 232, 50, 43, 43, 235, 89, 103, 167, 102, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setBlock(Block type, Team team, int rotation, Prov entityprov)
    {
      this.changing = true;
      if (type.isStatic() || this.block.isStatic())
        this.recache();
      this.block = type;
      this.preChanged();
      this.changeBuild(team, entityprov, (int) (sbyte) Mathf.mod(rotation, 4));
      if (this.build != null)
        this.build.team(team);
      if (this.block.isMultiblock())
      {
        int num1 = -(this.block.size - 1) / 2;
        int num2 = -(this.block.size - 1) / 2;
        Building build = this.build;
        Block block = this.block;
        for (int index1 = 0; index1 < 2; ++index1)
        {
          for (int index2 = 0; index2 < block.size; ++index2)
          {
            for (int index3 = 0; index3 < block.size; ++index3)
            {
              int x = index2 + num1 + (int) this.x;
              int y = index3 + num2 + (int) this.y;
              if (x != (int) this.x || y != (int) this.y)
              {
                Tile tile = Vars.world.tile(x, y);
                if (tile != null)
                {
                  if (index1 == 0)
                  {
                    tile.setBlock(Blocks.air);
                  }
                  else
                  {
                    tile.build = build;
                    tile.block = block;
                  }
                }
              }
            }
          }
        }
        this.build = build;
        this.block = block;
      }
      this.changed();
      this.changing = false;
    }

    [LineNumberTable(new byte[] {160, 177, 121, 117, 112, 102, 127, 18, 99, 245, 61, 230, 71})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void recache()
    {
      if (Vars.headless || Vars.world.isGenerating())
        return;
      Vars.renderer.__\u003C\u003Eblocks.__\u003C\u003Efloor.recacheTile(this);
      Vars.renderer.__\u003C\u003Eminimap.update(this);
      for (int index = 0; index < 8; ++index)
      {
        Tile tile = Vars.world.tile((int) this.x + Geometry.__\u003C\u003Ed8[index].x, (int) this.y + Geometry.__\u003C\u003Ed8[index].y);
        if (tile != null)
          Vars.renderer.__\u003C\u003Eblocks.__\u003C\u003Efloor.recacheTile(tile);
      }
    }

    [LineNumberTable(new byte[] {161, 130, 139, 107, 171, 117, 120, 113, 103, 104, 107, 104, 121, 132, 106, 104, 172, 231, 55, 40, 235, 84, 109, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void preChanged()
    {
      if (this.build != null)
      {
        this.build.onRemoved();
        this.build.removeFromProximity();
        if (this.build.block.isMultiblock())
        {
          int num1 = this.build.tileX();
          int num2 = this.build.tileY();
          int size = this.build.block.size;
          int num3 = -(size - 1) / 2;
          int num4 = -(size - 1) / 2;
          for (int index1 = 0; index1 < size; ++index1)
          {
            for (int index2 = 0; index2 < size; ++index2)
            {
              Tile tile = Vars.world.tile(num1 + index1 + num3, num2 + index2 + num4);
              if (tile != null && !object.ReferenceEquals((object) tile, (object) this))
              {
                tile.build = (Building) null;
                tile.block = Blocks.air;
                tile.fireChanged();
              }
            }
          }
        }
      }
      if (!this.block.isStatic())
        return;
      this.recache();
    }

    [LineNumberTable(new byte[] {160, 142, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setBlock(Block type) => this.setBlock(type, Team.__\u003C\u003Ederelict, 0);

    [LineNumberTable(new byte[] {160, 236, 140, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setOverlay(Block block)
    {
      this.overlay = (Floor) block;
      this.recache();
    }

    [LineNumberTable(new byte[] {160, 169, 127, 8})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void circle(int radius, Intc2 cons) => Geometry.circle((int) this.x, (int) this.y, Vars.world.width(), Vars.world.height(), radius, cons);

    [LineNumberTable(new byte[] {160, 211, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setFloorNet(Block floor, Block overlay) => Call.setFloor(this, floor, overlay);

    [Signature("(Lmindustry/world/Block;Larc/func/Cons<Lmindustry/world/Tile;>;)V")]
    [LineNumberTable(new byte[] {161, 61, 107, 108, 108, 107, 107, 127, 1, 12, 38, 230, 70, 98, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void getLinkedTilesAs(Block block, Cons tmpArray)
    {
      if (block.isMultiblock())
      {
        int num1 = -(block.size - 1) / 2;
        int num2 = -(block.size - 1) / 2;
        for (int index1 = 0; index1 < block.size; ++index1)
        {
          for (int index2 = 0; index2 < block.size; ++index2)
          {
            Tile tile = Vars.world.tile((int) this.x + index1 + num1, (int) this.y + index2 + num2);
            if (tile != null)
              tmpArray.get((object) tile);
          }
        }
      }
      else
        tmpArray.get((object) this);
    }

    [LineNumberTable(new byte[] {161, 217, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void fireChanged() => Vars.world.notifyChanged(this);

    [Modifiers]
    [LineNumberTable(117)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static float lambda\u0024getFlammability\u00240([In] Item obj0, [In] int obj1) => obj0.flammability * (float) obj1;

    [Modifiers]
    [LineNumberTable(120)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static float lambda\u0024getFlammability\u00241([In] Liquid obj0, [In] float obj1) => obj0.flammability * obj1 / 3f;

    [Modifiers]
    [LineNumberTable(287)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024circle\u00242([In] Cons obj0, [In] int obj1, [In] int obj2) => obj0.get((object) Vars.world.rawTile(obj1, obj2));

    [Modifiers]
    [LineNumberTable(new byte[] {161, 225, 103, 125, 127, 8})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024display\u00243([In] Block obj0, [In] Table obj1)
    {
      obj1.left();
      obj1.add((Element) new Image(obj0.getDisplayIcon(this))).size(32f);
      obj1.labelWrap(obj0.getDisplayName(this)).left().width(190f).padLeft(5f);
    }

    [LineNumberTable(new byte[] {159, 176, 8, 167, 104, 104, 127, 7})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Tile(int x, int y)
    {
      Tile tile1 = this;
      this.changing = false;
      this.x = (short) x;
      this.y = (short) y;
      Tile tile2 = this;
      Tile tile3 = this;
      Floor air = (Floor) Blocks.air;
      Floor floor1 = air;
      this.overlay = air;
      Floor floor2 = floor1;
      Floor floor3 = floor2;
      this.floor = floor2;
      this.block = (Block) floor3;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static byte relativeTo(int x, int y, int cx, int cy)
    {
      if (x == cx && y == cy - 1)
        return 1;
      if (x == cx && y == cy + 1)
        return 3;
      if (x == cx - 1 && y == cy)
        return 0;
      return x == cx + 1 && y == cy ? (byte) 2 : byte.MaxValue;
    }

    [LineNumberTable(new byte[] {61, 109, 122, 145, 102, 104, 156, 109, 191, 0, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getFlammability()
    {
      if (!this.block.hasItems)
        return this.floor.liquidDrop != null && !this.block.solid ? this.floor.liquidDrop.flammability : 0.0f;
      if (this.build == null)
        return 0.0f;
      float num = this.build.items.sum((ItemModule.ItemCalculator) new Tile.__\u003C\u003EAnon1());
      if (this.block.hasLiquids)
        num += this.build.liquids.sum((LiquidModule.LiquidCalculator) new Tile.__\u003C\u003EAnon2());
      return num;
    }

    [Signature("<T:Lmindustry/world/Block;>()TT;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Block cblock() => this.block;

    [LineNumberTable(180)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int centerX() => this.build == null ? (int) this.x : (int) this.build.tile.x;

    [LineNumberTable(184)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int centerY() => this.build == null ? (int) this.y : (int) this.build.tile.y;

    [LineNumberTable(new byte[] {160, 158, 103, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setFloorUnder(Floor floor)
    {
      Floor overlay = this.overlay;
      this.setFloor(floor);
      this.setOverlay((Block) overlay);
    }

    [LineNumberTable(new byte[] {160, 165, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setAir() => this.setBlock(Blocks.air);

    [Signature("(ILarc/func/Cons<Lmindustry/world/Tile;>;)V")]
    [LineNumberTable(new byte[] {160, 173, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void circle(int radius, Cons cons) => this.circle(radius, (Intc2) new Tile.__\u003C\u003EAnon3(cons));

    [LineNumberTable(new byte[] {160, 196, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void removeNet() => Call.removeTile(this);

    [LineNumberTable(new byte[] {160, 201, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setNet(Block block) => Call.setTile(this, block, Team.__\u003C\u003Ederelict, 0);

    [LineNumberTable(new byte[] {160, 206, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setNet(Block block, Team team, int rotation) => Call.setTile(this, block, team, rotation);

    [LineNumberTable(new byte[] {160, 216, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setFloorNet(Block floor) => this.setFloorNet(floor, Blocks.air);

    [LineNumberTable(new byte[] {160, 243, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setOverlayQuiet(Block block) => this.overlay = (Floor) block;

    [LineNumberTable(new byte[] {160, 247, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void clearOverlay() => this.setOverlayID((short) 0);

    [LineNumberTable(370)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool synthetic() => this.block.update || this.block.destructible;

    [LineNumberTable(378)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool breakable() => this.block.destructible || this.block.breakable || this.block.update;

    [Signature("(Larc/struct/Seq<Lmindustry/world/Tile;>;)Larc/struct/Seq<Lmindustry/world/Tile;>;")]
    [LineNumberTable(new byte[] {161, 41, 103, 120})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Seq getLinkedTiles(Seq tmpArray)
    {
      tmpArray.clear();
      Seq seq = tmpArray;
      Objects.requireNonNull((object) seq);
      this.getLinkedTiles((Cons) new Tile.__\u003C\u003EAnon4(seq));
      return tmpArray;
    }

    [LineNumberTable(450)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Rect getBounds(Rect rect) => rect.set((float) ((int) this.x * 8) - 4f, (float) ((int) this.y * 8) - 4f, 8f, 8f);

    [LineNumberTable(new byte[] {161, 85, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void hitbox(Rect rect) => this.getHitbox(rect);

    [LineNumberTable(463)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Tile nearby(int dx, int dy) => Vars.world.tile((int) this.x + dx, (int) this.y + dy);

    [LineNumberTable(483)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool interactable(Team team) => Vars.state.teams.canInteract(team, this.team());

    [LineNumberTable(496)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool adjacentTo(Tile tile) => this.relativeTo(tile) != byte.MaxValue;

    [LineNumberTable(new byte[] {161, 222, 156, 210, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void display(Table table)
    {
      Floor floor = this.overlay.itemDrop == null ? this.floor : this.overlay;
      table.table((Cons) new Tile.__\u003C\u003EAnon5(this, (Block) floor)).growX().left();
    }

    [LineNumberTable(603)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getX() => this.drawx();

    [LineNumberTable(608)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getY() => this.drawy();

    [LineNumberTable(613)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toString() => new StringBuilder().append(this.floor.__\u003C\u003Ename).append(":").append(this.block.__\u003C\u003Ename).append(":").append((object) this.overlay).append("[").append((int) this.x).append(",").append((int) this.y).append("] entity=").append(this.build != null ? Object.instancehelper_getClass((object) this.build).getSimpleName() : "null").append(":").append((object) this.team()).toString();

    [LineNumberTable(new byte[] {161, 250, 108, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void setFloor(Tile tile, Block floor, Block overlay)
    {
      tile.setFloor(floor.asFloor());
      tile.setOverlay(overlay);
    }

    [LineNumberTable(new byte[] {162, 0, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void removeTile(Tile tile) => tile.remove();

    [LineNumberTable(new byte[] {162, 5, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void setTile(Tile tile, Block block, Team team, int rotation) => tile.setBlock(block, team, rotation);

    [LineNumberTable(new byte[] {162, 10, 99, 103, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void setTeam(Building build, Team team)
    {
      if (build == null)
        return;
      build.team = team;
      Vars.indexer.updateIndices(build.tile);
    }

    [LineNumberTable(new byte[] {162, 18, 132, 136, 104, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void tileDamage(Building build, float health)
    {
      if (build == null)
        return;
      build.health = health;
      if (!build.damaged())
        return;
      Vars.indexer.notifyTileDamaged(build);
    }

    [LineNumberTable(new byte[] {162, 29, 100, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void tileDestroyed(Building build) => build?.killed();

    [LineNumberTable(22)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static Tile()
    {
      if (ByteCodeHelper.isAlreadyInited("mindustry.world.Tile"))
        return;
      Tile.tileSet = new ObjectSet();
    }

    [HideFromJava]
    public virtual float angleTo([In] float obj0, [In] float obj1) => Position.\u003Cdefault\u003EangleTo((Position) this, obj0, obj1);

    [HideFromJava]
    public virtual float dst2([In] Position obj0) => Position.\u003Cdefault\u003Edst2((Position) this, obj0);

    [HideFromJava]
    public virtual float dst([In] Position obj0) => Position.\u003Cdefault\u003Edst((Position) this, obj0);

    [HideFromJava]
    public virtual float dst([In] float obj0, [In] float obj1) => Position.\u003Cdefault\u003Edst((Position) this, obj0, obj1);

    [HideFromJava]
    public virtual float dst2([In] float obj0, [In] float obj1) => Position.\u003Cdefault\u003Edst2((Position) this, obj0, obj1);

    [HideFromJava]
    public virtual bool within([In] float obj0, [In] float obj1, [In] float obj2) => Position.\u003Cdefault\u003Ewithin((Position) this, obj0, obj1, obj2);

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Prov
    {
      private readonly Block arg\u00241;

      internal __\u003C\u003EAnon0([In] Block obj0) => this.arg\u00241 = obj0;

      public object get() => (object) this.arg\u00241.newBuilding();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : ItemModule.ItemCalculator
    {
      internal __\u003C\u003EAnon1()
      {
      }

      public float get([In] Item obj0, [In] int obj1) => Tile.lambda\u0024getFlammability\u00240(obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon2 : LiquidModule.LiquidCalculator
    {
      internal __\u003C\u003EAnon2()
      {
      }

      public float get([In] Liquid obj0, [In] float obj1) => Tile.lambda\u0024getFlammability\u00241(obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon3 : Intc2
    {
      private readonly Cons arg\u00241;

      internal __\u003C\u003EAnon3([In] Cons obj0) => this.arg\u00241 = obj0;

      public void get([In] int obj0, [In] int obj1) => Tile.lambda\u0024circle\u00242(this.arg\u00241, obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon4 : Cons
    {
      private readonly Seq arg\u00241;

      internal __\u003C\u003EAnon4([In] Seq obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.add((object) (Tile) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon5 : Cons
    {
      private readonly Tile arg\u00241;
      private readonly Block arg\u00242;

      internal __\u003C\u003EAnon5([In] Tile obj0, [In] Block obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024display\u00243(this.arg\u00242, (Table) obj0);
    }
  }
}
