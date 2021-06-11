// Decompiled with JetBrains decompiler
// Type: mindustry.maps.filters.SpawnPathFilter
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.func;
using arc.math;
using arc.util;
using IKVM.Attributes;
using IKVM.Runtime;
using java.util;
using mindustry.ai;
using mindustry.content;
using mindustry.world;
using mindustry.world.blocks.storage;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.maps.filters
{
  public class SpawnPathFilter : GenerateFilter
  {
    internal int radius;

    [LineNumberTable(new byte[] {159, 158, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public SpawnPathFilter()
    {
      SpawnPathFilter spawnPathFilter = this;
      this.radius = 3;
    }

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private float lambda\u0024options\u00240() => (float) this.radius;

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024options\u00241([In] float obj0) => this.radius = ByteCodeHelper.f2i(obj0);

    [Modifiers]
    [LineNumberTable(42)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static float lambda\u0024apply\u00242([In] Tile obj0) => obj0.solid() ? 100f : 1f;

    [Modifiers]
    [LineNumberTable(42)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024apply\u00243([In] Tile obj0) => !obj0.floor().isDeep();

    [LineNumberTable(new byte[] {159, 163, 127, 24, 38})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override FilterOption[] options()
    {
      FilterOption.SliderOption[] sliderOptionArray = new FilterOption.SliderOption[1];
      FilterOption.SliderOption.__\u003Cclinit\u003E();
      sliderOptionArray[0] = new FilterOption.SliderOption("radius", (Floatp) new SpawnPathFilter.__\u003C\u003EAnon0(this), (Floatc) new SpawnPathFilter.__\u003C\u003EAnon1(this), 1f, 20f).display();
      return (FilterOption[]) Structs.arr((object[]) sliderOptionArray);
    }

    [LineNumberTable(new byte[] {159, 170, 98, 134, 123, 114, 135, 127, 10, 130, 133, 113, 126, 127, 25, 127, 4, 118, 118, 120, 127, 20, 108, 105, 236, 59, 43, 235, 75, 101, 133})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void apply(Tiles tiles, GenerateFilter.GenerateInput @in)
    {
      Tile tile1 = (Tile) null;
      Seq seq = new Seq();
      Iterator iterator1 = tiles.iterator();
      while (iterator1.hasNext())
      {
        Tile tile2 = (Tile) iterator1.next();
        if (object.ReferenceEquals((object) tile2.overlay(), (object) Blocks.spawn))
          seq.add((object) tile2);
        if (tile2.block() is CoreBlock && !object.ReferenceEquals((object) tile2.team(), (object) Vars.state.rules.waveTeam))
          tile1 = tile2;
      }
      if (tile1 == null || !seq.any())
        return;
      Iterator iterator2 = seq.iterator();
      while (iterator2.hasNext())
      {
        Tile tile2 = (Tile) iterator2.next();
        Iterator iterator3 = Astar.pathfind((int) tile1.x, (int) tile1.y, (int) tile2.x, (int) tile2.y, (Astar.TileHueristic) new SpawnPathFilter.__\u003C\u003EAnon2(), Astar.__\u003C\u003Emanhattan, (Boolf) new SpawnPathFilter.__\u003C\u003EAnon3()).iterator();
label_11:
        if (iterator3.hasNext())
        {
          Tile tile3 = (Tile) iterator3.next();
          int num = -this.radius;
          while (true)
          {
            if (num <= this.radius)
            {
              for (int index = -this.radius; index <= this.radius; ++index)
              {
                int x = (int) tile3.x + num;
                int y = (int) tile3.y + index;
                if (Structs.inBounds(x, y, Vars.world.width(), Vars.world.height()) && Mathf.within((float) num, (float) index, (float) this.radius))
                {
                  Tile tile4 = tiles.getn(x, y);
                  if (!tile4.synthetic())
                    tile4.setBlock(Blocks.air);
                }
              }
              ++num;
            }
            else
              goto label_11;
          }
        }
      }
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool isPost() => true;

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Floatp
    {
      private readonly SpawnPathFilter arg\u00241;

      internal __\u003C\u003EAnon0([In] SpawnPathFilter obj0) => this.arg\u00241 = obj0;

      public float get() => this.arg\u00241.lambda\u0024options\u00240();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Floatc
    {
      private readonly SpawnPathFilter arg\u00241;

      internal __\u003C\u003EAnon1([In] SpawnPathFilter obj0) => this.arg\u00241 = obj0;

      public void get([In] float obj0) => this.arg\u00241.lambda\u0024options\u00241(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon2 : Astar.TileHueristic
    {
      internal __\u003C\u003EAnon2()
      {
      }

      public float cost([In] Tile obj0) => SpawnPathFilter.lambda\u0024apply\u00242(obj0);

      [SpecialName]
      public float cost([In] Tile obj0, [In] Tile obj1) => Astar.TileHueristic.\u003Cdefault\u003Ecost((Astar.TileHueristic) this, obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon3 : Boolf
    {
      internal __\u003C\u003EAnon3()
      {
      }

      public bool get([In] object obj0) => (SpawnPathFilter.lambda\u0024apply\u00243((Tile) obj0) ? 1 : 0) != 0;
    }
  }
}
