// Decompiled with JetBrains decompiler
// Type: mindustry.maps.filters.OreMedianFilter
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
using mindustry.content;
using mindustry.world;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.maps.filters
{
  public class OreMedianFilter : GenerateFilter
  {
    public float radius;
    public float percentile;
    private IntSeq blocks;

    [LineNumberTable(new byte[] {159, 153, 104, 107, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public OreMedianFilter()
    {
      OreMedianFilter oreMedianFilter = this;
      this.radius = 2f;
      this.percentile = 0.5f;
      this.blocks = new IntSeq();
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

    [LineNumberTable(19)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override FilterOption[] options()
    {
      FilterOption.SliderOption[] sliderOptionArray = new FilterOption.SliderOption[2];
      FilterOption.SliderOption.__\u003Cclinit\u003E();
      sliderOptionArray[0] = new FilterOption.SliderOption("radius", (Floatp) new OreMedianFilter.__\u003C\u003EAnon0(this), (Floatc) new OreMedianFilter.__\u003C\u003EAnon1(this), 1f, 12f);
      FilterOption.SliderOption.__\u003Cclinit\u003E();
      sliderOptionArray[1] = new FilterOption.SliderOption("percentile", (Floatp) new OreMedianFilter.__\u003C\u003EAnon2(this), (Floatc) new OreMedianFilter.__\u003C\u003EAnon3(this), 0.0f, 1f);
      return (FilterOption[]) Structs.arr((object[]) sliderOptionArray);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool isBuffered() => true;

    [LineNumberTable(new byte[] {159, 174, 152, 112, 112, 122, 127, 160, 89, 127, 73, 208, 140, 107, 106, 108, 147, 127, 11, 115, 247, 59, 43, 233, 74, 139, 127, 13, 142, 119})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void apply()
    {
      if (object.ReferenceEquals((object) this.@in.overlay, (object) Blocks.spawn))
        return;
      int num1 = this.@in.x / 2 * 2;
      int num2 = this.@in.y / 2 * 2;
      if (!object.ReferenceEquals((object) this.@in.overlay, (object) Blocks.air) && (!object.ReferenceEquals((object) this.@in.tile((float) (num1 + 1), (float) num2).overlay(), (object) this.@in.overlay) || !object.ReferenceEquals((object) this.@in.tile((float) num1, (float) num2).overlay(), (object) this.@in.overlay) || (!object.ReferenceEquals((object) this.@in.tile((float) (num1 + 1), (float) (num2 + 1)).overlay(), (object) this.@in.overlay) || !object.ReferenceEquals((object) this.@in.tile((float) num1, (float) (num2 + 1)).overlay(), (object) this.@in.overlay)) || (this.@in.tile((float) (num1 + 1), (float) num2).block().isStatic() || this.@in.tile((float) num1, (float) num2).block().isStatic() || (this.@in.tile((float) (num1 + 1), (float) (num2 + 1)).block().isStatic() || this.@in.tile((float) num1, (float) (num2 + 1)).block().isStatic()))))
        this.@in.overlay = Blocks.air;
      int num3 = ByteCodeHelper.f2i(this.radius);
      this.blocks.clear();
      for (int index1 = -num3; index1 <= num3; ++index1)
      {
        for (int index2 = -num3; index2 <= num3; ++index2)
        {
          if ((double) Mathf.dst2((float) index1, (float) index2) <= (double) (num3 * num3))
          {
            Tile tile = this.@in.tile((float) (this.@in.x + index1), (float) (this.@in.y + index2));
            if (!object.ReferenceEquals((object) tile.overlay(), (object) Blocks.spawn))
              this.blocks.add((int) tile.overlay().__\u003C\u003Eid);
          }
        }
      }
      this.blocks.sort();
      int id = this.blocks.get(Math.min(ByteCodeHelper.f2i((float) this.blocks.size * this.percentile), this.blocks.size - 1));
      this.@in.overlay = Vars.content.block(id);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Floatp
    {
      private readonly OreMedianFilter arg\u00241;

      internal __\u003C\u003EAnon0([In] OreMedianFilter obj0) => this.arg\u00241 = obj0;

      public float get() => this.arg\u00241.lambda\u0024options\u00240();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Floatc
    {
      private readonly OreMedianFilter arg\u00241;

      internal __\u003C\u003EAnon1([In] OreMedianFilter obj0) => this.arg\u00241 = obj0;

      public void get([In] float obj0) => this.arg\u00241.lambda\u0024options\u00241(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon2 : Floatp
    {
      private readonly OreMedianFilter arg\u00241;

      internal __\u003C\u003EAnon2([In] OreMedianFilter obj0) => this.arg\u00241 = obj0;

      public float get() => this.arg\u00241.lambda\u0024options\u00242();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon3 : Floatc
    {
      private readonly OreMedianFilter arg\u00241;

      internal __\u003C\u003EAnon3([In] OreMedianFilter obj0) => this.arg\u00241 = obj0;

      public void get([In] float obj0) => this.arg\u00241.lambda\u0024options\u00243(obj0);
    }
  }
}
