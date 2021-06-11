// Decompiled with JetBrains decompiler
// Type: mindustry.maps.filters.MedianFilter
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.func;
using arc.math;
using arc.util;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using mindustry.world;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.maps.filters
{
  public class MedianFilter : GenerateFilter
  {
    internal float radius;
    internal float percentile;
    internal IntSeq blocks;
    internal IntSeq floors;

    [LineNumberTable(new byte[] {159, 153, 104, 107, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public MedianFilter()
    {
      MedianFilter medianFilter = this;
      this.radius = 2f;
      this.percentile = 0.5f;
      this.blocks = new IntSeq();
      this.floors = new IntSeq();
    }

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private float lambda\u0024options\u00240() => this.radius;

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024options\u00241([In] float obj0) => this.radius = obj0;

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private float lambda\u0024options\u00242() => this.percentile;

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024options\u00243([In] float obj0) => this.percentile = obj0;

    [LineNumberTable(18)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override FilterOption[] options()
    {
      FilterOption.SliderOption[] sliderOptionArray = new FilterOption.SliderOption[2];
      FilterOption.SliderOption.__\u003Cclinit\u003E();
      sliderOptionArray[0] = new FilterOption.SliderOption("radius", (Floatp) new MedianFilter.__\u003C\u003EAnon0(this), (Floatc) new MedianFilter.__\u003C\u003EAnon1(this), 1f, 12f);
      FilterOption.SliderOption.__\u003Cclinit\u003E();
      sliderOptionArray[1] = new FilterOption.SliderOption("percentile", (Floatp) new MedianFilter.__\u003C\u003EAnon2(this), (Floatc) new MedianFilter.__\u003C\u003EAnon3(this), 0.0f, 1f);
      return (FilterOption[]) Structs.arr((object[]) sliderOptionArray);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool isBuffered() => true;

    [LineNumberTable(new byte[] {159, 173, 108, 107, 107, 106, 106, 146, 127, 9, 118, 246, 59, 41, 233, 74, 107, 139, 127, 13, 155, 118, 127, 29})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void apply()
    {
      int num = ByteCodeHelper.f2i(this.radius);
      this.blocks.clear();
      this.floors.clear();
      for (int index1 = -num; index1 <= num; ++index1)
      {
        for (int index2 = -num; index2 <= num; ++index2)
        {
          if ((double) Mathf.dst2((float) index1, (float) index2) <= (double) (num * num))
          {
            Tile tile = this.@in.tile((float) (this.@in.x + index1), (float) (this.@in.y + index2));
            this.blocks.add((int) tile.block().__\u003C\u003Eid);
            this.floors.add((int) tile.floor().__\u003C\u003Eid);
          }
        }
      }
      this.floors.sort();
      this.blocks.sort();
      int index = Math.min(ByteCodeHelper.f2i((float) this.floors.size * this.percentile), this.floors.size - 1);
      int id1 = this.floors.get(index);
      int id2 = this.blocks.get(index);
      this.@in.floor = Vars.content.block(id1);
      if (Vars.content.block(id2).synthetic() || this.@in.block.synthetic())
        return;
      this.@in.block = Vars.content.block(id2);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Floatp
    {
      private readonly MedianFilter arg\u00241;

      internal __\u003C\u003EAnon0([In] MedianFilter obj0) => this.arg\u00241 = obj0;

      public float get() => this.arg\u00241.lambda\u0024options\u00240();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Floatc
    {
      private readonly MedianFilter arg\u00241;

      internal __\u003C\u003EAnon1([In] MedianFilter obj0) => this.arg\u00241 = obj0;

      public void get([In] float obj0) => this.arg\u00241.lambda\u0024options\u00241(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon2 : Floatp
    {
      private readonly MedianFilter arg\u00241;

      internal __\u003C\u003EAnon2([In] MedianFilter obj0) => this.arg\u00241 = obj0;

      public float get() => this.arg\u00241.lambda\u0024options\u00242();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon3 : Floatc
    {
      private readonly MedianFilter arg\u00241;

      internal __\u003C\u003EAnon3([In] MedianFilter obj0) => this.arg\u00241 = obj0;

      public void get([In] float obj0) => this.arg\u00241.lambda\u0024options\u00243(obj0);
    }
  }
}
