// Decompiled with JetBrains decompiler
// Type: mindustry.maps.filters.RandomItemFilter
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.math;
using IKVM.Attributes;
using java.lang;
using java.util;
using mindustry.type;
using mindustry.world;
using mindustry.world.blocks.storage;
using System.Runtime.CompilerServices;

namespace mindustry.maps.filters
{
  public class RandomItemFilter : GenerateFilter
  {
    [Signature("Larc/struct/Seq<Lmindustry/type/ItemStack;>;")]
    public Seq drops;
    public float chance;

    [LineNumberTable(new byte[] {159, 151, 104, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public RandomItemFilter()
    {
      RandomItemFilter randomItemFilter = this;
      this.drops = new Seq();
      this.chance = 0.3f;
    }

    [LineNumberTable(15)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override FilterOption[] options() => new FilterOption[0];

    [LineNumberTable(new byte[] {159, 162, 126, 127, 1, 127, 1, 110, 159, 18, 130, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void apply(Tiles tiles, GenerateFilter.GenerateInput @in)
    {
      Iterator iterator1 = tiles.iterator();
label_1:
      while (iterator1.hasNext())
      {
        Tile tile = (Tile) iterator1.next();
        if (tile.block() is StorageBlock && !(tile.block() is CoreBlock))
        {
          Iterator iterator2 = this.drops.iterator();
          while (true)
          {
            ItemStack itemStack;
            do
            {
              if (iterator2.hasNext())
                itemStack = (ItemStack) iterator2.next();
              else
                goto label_1;
            }
            while (!Mathf.chance((double) this.chance));
            tile.build.items.add(itemStack.item, Math.min(Mathf.random(itemStack.amount), tile.block().itemCapacity));
          }
        }
      }
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool isPost() => true;
  }
}
