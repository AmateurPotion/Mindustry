// Decompiled with JetBrains decompiler
// Type: mindustry.world.CachedTile
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.func;
using IKVM.Attributes;
using mindustry.game;
using mindustry.gen;
using mindustry.world.modules;
using System.Runtime.CompilerServices;

namespace mindustry.world
{
  public class CachedTile : Tile
  {
    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 157, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public CachedTile()
      : base(0, 0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void preChanged()
    {
    }

    [Signature("(Lmindustry/game/Team;Larc/func/Prov<Lmindustry/gen/Building;>;I)V")]
    [LineNumberTable(new byte[] {159, 167, 135, 135, 107, 108, 113, 103, 103, 115, 115, 115, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void changeBuild(Team team, Prov entityprov, int rotation)
    {
      this.build = (Building) null;
      Block block = this.block();
      if (!block.hasBuilding())
        return;
      Building building = (Building) entityprov.get();
      building.cons(new ConsumeModule(this.build));
      building.tile((Tile) this);
      building.block(block);
      if (block.hasItems)
        building.items = new ItemModule();
      if (block.hasLiquids)
        building.liquids(new LiquidModule());
      if (block.hasPower)
        building.power(new PowerModule());
      this.build = building;
    }

    [HideFromJava]
    static CachedTile() => Tile.__\u003Cclinit\u003E();
  }
}
