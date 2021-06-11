// Decompiled with JetBrains decompiler
// Type: mindustry.maps.filters.EnemySpawnFilter
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.func;
using arc.util;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.util;
using mindustry.content;
using mindustry.world;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.maps.filters
{
  public class EnemySpawnFilter : GenerateFilter
  {
    internal int amount;

    [LineNumberTable(new byte[] {159, 152, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public EnemySpawnFilter()
    {
      EnemySpawnFilter enemySpawnFilter = this;
      this.amount = 1;
    }

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private float lambda\u0024options\u00240() => (float) this.amount;

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024options\u00241([In] float obj0) => this.amount = ByteCodeHelper.f2i(obj0);

    [LineNumberTable(new byte[] {159, 157, 127, 24, 38})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override FilterOption[] options()
    {
      FilterOption.SliderOption[] sliderOptionArray = new FilterOption.SliderOption[1];
      FilterOption.SliderOption.__\u003Cclinit\u003E();
      sliderOptionArray[0] = new FilterOption.SliderOption("amount", (Floatp) new EnemySpawnFilter.__\u003C\u003EAnon0(this), (Floatc) new EnemySpawnFilter.__\u003C\u003EAnon1(this), 1f, 10f).display();
      return (FilterOption[]) Structs.arr((object[]) sliderOptionArray);
    }

    [LineNumberTable(new byte[] {159, 164, 102, 123, 114, 140, 130, 134, 114, 109, 112, 7, 200})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void apply(Tiles tiles, GenerateFilter.GenerateInput @in)
    {
      IntSeq intSeq = new IntSeq();
      Iterator iterator = tiles.iterator();
      while (iterator.hasNext())
      {
        Tile tile = (Tile) iterator.next();
        if (object.ReferenceEquals((object) tile.overlay(), (object) Blocks.spawn))
          intSeq.add(tile.pos());
      }
      intSeq.shuffle();
      for (int index = Math.min(intSeq.size, this.amount); index < intSeq.size; ++index)
        tiles.getp(intSeq.get(index)).clearOverlay();
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool isPost() => true;

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Floatp
    {
      private readonly EnemySpawnFilter arg\u00241;

      internal __\u003C\u003EAnon0([In] EnemySpawnFilter obj0) => this.arg\u00241 = obj0;

      public float get() => this.arg\u00241.lambda\u0024options\u00240();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Floatc
    {
      private readonly EnemySpawnFilter arg\u00241;

      internal __\u003C\u003EAnon1([In] EnemySpawnFilter obj0) => this.arg\u00241 = obj0;

      public void get([In] float obj0) => this.arg\u00241.lambda\u0024options\u00241(obj0);
    }
  }
}
