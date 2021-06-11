// Decompiled with JetBrains decompiler
// Type: mindustry.maps.filters.CoreSpawnFilter
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.util;
using IKVM.Attributes;
using java.lang;
using java.util;
using mindustry.world;
using mindustry.world.blocks.storage;
using System.Runtime.CompilerServices;

namespace mindustry.maps.filters
{
  public class CoreSpawnFilter : GenerateFilter
  {
    internal int amount;

    [LineNumberTable(new byte[] {159, 153, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public CoreSpawnFilter()
    {
      CoreSpawnFilter coreSpawnFilter = this;
      this.amount = 1;
    }

    [LineNumberTable(16)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override FilterOption[] options() => (FilterOption[]) Structs.arr((object[]) new FilterOption[0]);

    [LineNumberTable(new byte[] {159, 166, 102, 123, 127, 18, 140, 130, 134, 114, 109, 51, 168})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void apply(Tiles tiles, GenerateFilter.GenerateInput @in)
    {
      IntSeq intSeq = new IntSeq();
      Iterator iterator = tiles.iterator();
      while (iterator.hasNext())
      {
        Tile tile = (Tile) iterator.next();
        if (object.ReferenceEquals((object) tile.team(), (object) Vars.state.rules.defaultTeam) && tile.block() is CoreBlock && tile.isCenter())
          intSeq.add(tile.pos());
      }
      intSeq.shuffle();
      for (int index = Math.min(intSeq.size, this.amount); index < intSeq.size; ++index)
        tiles.getp(intSeq.get(index)).remove();
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool isPost() => true;
  }
}
