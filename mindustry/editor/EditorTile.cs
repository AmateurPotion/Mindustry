// Decompiled with JetBrains decompiler
// Type: mindustry.editor.EditorTile
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.func;
using IKVM.Attributes;
using mindustry.content;
using mindustry.game;
using mindustry.gen;
using mindustry.world;
using mindustry.world.blocks.environment;
using mindustry.world.modules;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.editor
{
  public class EditorTile : Tile
  {
    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(147)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool skip() => Vars.state.isGame() || Vars.ui.editor.__\u003C\u003Eeditor.isLoading();

    [LineNumberTable(new byte[] {159, 105, 162, 127, 14})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void op([In] DrawOperation.OpType obj0, [In] short obj1)
    {
      int num = (int) obj1;
      Vars.ui.editor.__\u003C\u003Eeditor.addTileOp(TileOp.get(this.x, this.y, (byte) obj0.ordinal(), (short) num));
    }

    [LineNumberTable(new byte[] {93, 127, 6})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void update() => Vars.ui.editor.__\u003C\u003Eeditor.renderer.updatePoint((int) this.x, (int) this.y);

    [Modifiers]
    [LineNumberTable(80)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024setTeam\u00240([In] Tile obj0) => Vars.ui.editor.__\u003C\u003Eeditor.renderer.updatePoint((int) obj0.x, (int) obj0.y);

    [LineNumberTable(new byte[] {159, 159, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public EditorTile(int x, int y, int floor, int overlay, int wall)
      : base(x, y, floor, overlay, wall)
    {
    }

    [LineNumberTable(new byte[] {159, 164, 104, 103, 161, 136, 117, 140, 161, 119, 121, 127, 5, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setFloor(Floor type)
    {
      if (this.skip())
        base.setFloor(type);
      else if (type is OverlayFloor)
      {
        if (!this.floor.hasSurface() && type.needsSurface)
          return;
        this.setOverlayID(type.__\u003C\u003Eid);
      }
      else
      {
        if (object.ReferenceEquals((object) this.floor, (object) type) && this.overlayID() == (short) 0)
          return;
        if (this.overlayID() != (short) 0)
          this.op(DrawOperation.OpType.__\u003C\u003Eoverlay, this.overlayID());
        if (!object.ReferenceEquals((object) this.floor, (object) type))
          this.op(DrawOperation.OpType.__\u003C\u003Efloor, this.floor.__\u003C\u003Eid);
        base.setFloor(type);
      }
    }

    [LineNumberTable(new byte[] {159, 185, 104, 105, 161, 127, 5, 102, 161, 104, 113, 120, 125, 118, 102, 98, 127, 1, 127, 6, 214, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setBlock(Block type, Team team, int rotation)
    {
      if (this.skip())
        base.setBlock(type, team, rotation);
      else if (object.ReferenceEquals((object) this.block, (object) type) && (this.build == null || this.build.rotation == rotation))
      {
        this.update();
      }
      else
      {
        if (!this.isCenter())
        {
          EditorTile tile = (EditorTile) this.build.tile;
          tile.op(DrawOperation.OpType.__\u003C\u003Erotation, (short) (sbyte) this.build.rotation);
          tile.op(DrawOperation.OpType.__\u003C\u003Eteam, (short) (sbyte) this.build.team.__\u003C\u003Eid);
          tile.op(DrawOperation.OpType.__\u003C\u003Eblock, this.block.__\u003C\u003Eid);
          this.update();
        }
        else
        {
          if (this.build != null)
            this.op(DrawOperation.OpType.__\u003C\u003Erotation, (short) (sbyte) this.build.rotation);
          if (this.build != null)
            this.op(DrawOperation.OpType.__\u003C\u003Eteam, (short) (sbyte) this.build.team.__\u003C\u003Eid);
          this.op(DrawOperation.OpType.__\u003C\u003Eblock, this.block.__\u003C\u003Eid);
        }
        base.setBlock(type, team, rotation);
      }
    }

    [LineNumberTable(new byte[] {21, 104, 103, 161, 111, 115, 135, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setTeam(Team team)
    {
      if (this.skip())
      {
        base.setTeam(team);
      }
      else
      {
        if (this.getTeamID() == team.__\u003C\u003Eid)
          return;
        this.op(DrawOperation.OpType.__\u003C\u003Eteam, (short) (sbyte) this.getTeamID());
        base.setTeam(team);
        this.getLinkedTiles((Cons) new EditorTile.__\u003C\u003EAnon0());
      }
    }

    [LineNumberTable(new byte[] {35, 104, 103, 161, 123, 111, 118, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setOverlay(Block overlay)
    {
      if (this.skip())
      {
        base.setOverlay(overlay);
      }
      else
      {
        if (!this.floor.hasSurface() && overlay.asFloor().needsSurface || object.ReferenceEquals((object) this.overlay(), (object) overlay))
          return;
        this.op(DrawOperation.OpType.__\u003C\u003Eoverlay, this.overlay.__\u003C\u003Eid);
        base.setOverlay(overlay);
      }
    }

    [LineNumberTable(new byte[] {48, 104, 136, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void fireChanged()
    {
      if (this.skip())
        base.fireChanged();
      else
        this.update();
    }

    [LineNumberTable(new byte[] {57, 104, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void recache()
    {
      if (!this.skip())
        return;
      base.recache();
    }

    [LineNumberTable(new byte[] {64, 108, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void changed()
    {
      if (!Vars.state.isGame())
        return;
      base.changed();
    }

    [Signature("(Lmindustry/game/Team;Larc/func/Prov<Lmindustry/gen/Building;>;I)V")]
    [LineNumberTable(new byte[] {71, 104, 105, 161, 135, 115, 152, 135, 107, 122, 118, 120, 120, 152})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void changeBuild(Team team, Prov entityprov, int rotation)
    {
      if (this.skip())
      {
        base.changeBuild(team, entityprov, rotation);
      }
      else
      {
        this.build = (Building) null;
        if (this.block == null)
          this.block = Blocks.air;
        if (this.floor == null)
          this.floor = (Floor) Blocks.air;
        Block block = this.block();
        if (!block.hasBuilding())
          return;
        this.build = ((Building) entityprov.get()).init((Tile) this, team, false, rotation);
        this.build.cons = new ConsumeModule(this.build);
        if (block.hasItems)
          this.build.items = new ItemModule();
        if (block.hasLiquids)
          this.build.liquids(new LiquidModule());
        if (!block.hasPower)
          return;
        this.build.power(new PowerModule());
      }
    }

    [HideFromJava]
    static EditorTile() => Tile.__\u003Cclinit\u003E();

    [SpecialName]
    private new sealed class __\u003C\u003EAnon0 : Cons
    {
      internal __\u003C\u003EAnon0()
      {
      }

      public void get([In] object obj0) => EditorTile.lambda\u0024setTeam\u00240((Tile) obj0);
    }
  }
}
