// Decompiled with JetBrains decompiler
// Type: mindustry.maps.filters.RiverNoiseFilter
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.func;
using arc.util;
using IKVM.Attributes;
using mindustry.content;
using mindustry.world;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.maps.filters
{
  public class RiverNoiseFilter : GenerateFilter
  {
    internal float scl;
    internal float threshold;
    internal float threshold2;
    internal Block floor;
    internal Block floor2;
    internal Block block;

    [LineNumberTable(new byte[] {159, 151, 104, 127, 2})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public RiverNoiseFilter()
    {
      RiverNoiseFilter riverNoiseFilter = this;
      this.scl = 40f;
      this.threshold = 0.0f;
      this.threshold2 = 0.1f;
      this.floor = Blocks.water;
      this.floor2 = Blocks.deepwater;
      this.block = Blocks.sandWall;
    }

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private float lambda\u0024options\u00240() => this.scl;

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024options\u00241([In] float obj0) => this.scl = obj0;

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private float lambda\u0024options\u00242() => this.threshold;

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024options\u00243([In] float obj0) => this.threshold = obj0;

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private float lambda\u0024options\u00244() => this.threshold2;

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024options\u00245([In] float obj0) => this.threshold2 = obj0;

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Block lambda\u0024options\u00246() => this.block;

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024options\u00247([In] Block obj0) => this.block = obj0;

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Block lambda\u0024options\u00248() => this.floor;

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024options\u00249([In] Block obj0) => this.floor = obj0;

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Block lambda\u0024options\u002410() => this.floor2;

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024options\u002411([In] Block obj0) => this.floor2 = obj0;

    [LineNumberTable(15)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override FilterOption[] options()
    {
      FilterOption[] filterOptionArray = new FilterOption[6];
      FilterOption.SliderOption.__\u003Cclinit\u003E();
      filterOptionArray[0] = (FilterOption) new FilterOption.SliderOption("scale", (Floatp) new RiverNoiseFilter.__\u003C\u003EAnon0(this), (Floatc) new RiverNoiseFilter.__\u003C\u003EAnon1(this), 1f, 500f);
      FilterOption.SliderOption.__\u003Cclinit\u003E();
      filterOptionArray[1] = (FilterOption) new FilterOption.SliderOption("threshold", (Floatp) new RiverNoiseFilter.__\u003C\u003EAnon2(this), (Floatc) new RiverNoiseFilter.__\u003C\u003EAnon3(this), -1f, 0.3f);
      FilterOption.SliderOption.__\u003Cclinit\u003E();
      filterOptionArray[2] = (FilterOption) new FilterOption.SliderOption("threshold2", (Floatp) new RiverNoiseFilter.__\u003C\u003EAnon4(this), (Floatc) new RiverNoiseFilter.__\u003C\u003EAnon5(this), -1f, 0.3f);
      FilterOption.BlockOption.__\u003Cclinit\u003E();
      filterOptionArray[3] = (FilterOption) new FilterOption.BlockOption("block", (Prov) new RiverNoiseFilter.__\u003C\u003EAnon6(this), (Cons) new RiverNoiseFilter.__\u003C\u003EAnon7(this), FilterOption.__\u003C\u003EwallsOnly);
      FilterOption.BlockOption.__\u003Cclinit\u003E();
      filterOptionArray[4] = (FilterOption) new FilterOption.BlockOption("floor", (Prov) new RiverNoiseFilter.__\u003C\u003EAnon8(this), (Cons) new RiverNoiseFilter.__\u003C\u003EAnon9(this), FilterOption.__\u003C\u003EfloorsOnly);
      FilterOption.BlockOption.__\u003Cclinit\u003E();
      filterOptionArray[5] = (FilterOption) new FilterOption.BlockOption("floor2", (Prov) new RiverNoiseFilter.__\u003C\u003EAnon10(this), (Cons) new RiverNoiseFilter.__\u003C\u003EAnon11(this), FilterOption.__\u003C\u003EfloorsOnly);
      return (FilterOption[]) Structs.arr((object[]) filterOptionArray);
    }

    [LineNumberTable(new byte[] {159, 169, 159, 12, 105, 145, 114, 177, 105, 177})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void apply()
    {
      float num = this.rnoise((float) this.@in.x, (float) this.@in.y, this.scl, 1f);
      if ((double) num < (double) this.threshold)
        return;
      this.@in.floor = this.floor;
      if (this.@in.block.solid)
        this.@in.block = this.block;
      if ((double) num < (double) this.threshold2)
        return;
      this.@in.floor = this.floor2;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Floatp
    {
      private readonly RiverNoiseFilter arg\u00241;

      internal __\u003C\u003EAnon0([In] RiverNoiseFilter obj0) => this.arg\u00241 = obj0;

      public float get() => this.arg\u00241.lambda\u0024options\u00240();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Floatc
    {
      private readonly RiverNoiseFilter arg\u00241;

      internal __\u003C\u003EAnon1([In] RiverNoiseFilter obj0) => this.arg\u00241 = obj0;

      public void get([In] float obj0) => this.arg\u00241.lambda\u0024options\u00241(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon2 : Floatp
    {
      private readonly RiverNoiseFilter arg\u00241;

      internal __\u003C\u003EAnon2([In] RiverNoiseFilter obj0) => this.arg\u00241 = obj0;

      public float get() => this.arg\u00241.lambda\u0024options\u00242();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon3 : Floatc
    {
      private readonly RiverNoiseFilter arg\u00241;

      internal __\u003C\u003EAnon3([In] RiverNoiseFilter obj0) => this.arg\u00241 = obj0;

      public void get([In] float obj0) => this.arg\u00241.lambda\u0024options\u00243(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon4 : Floatp
    {
      private readonly RiverNoiseFilter arg\u00241;

      internal __\u003C\u003EAnon4([In] RiverNoiseFilter obj0) => this.arg\u00241 = obj0;

      public float get() => this.arg\u00241.lambda\u0024options\u00244();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon5 : Floatc
    {
      private readonly RiverNoiseFilter arg\u00241;

      internal __\u003C\u003EAnon5([In] RiverNoiseFilter obj0) => this.arg\u00241 = obj0;

      public void get([In] float obj0) => this.arg\u00241.lambda\u0024options\u00245(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon6 : Prov
    {
      private readonly RiverNoiseFilter arg\u00241;

      internal __\u003C\u003EAnon6([In] RiverNoiseFilter obj0) => this.arg\u00241 = obj0;

      public object get() => (object) this.arg\u00241.lambda\u0024options\u00246();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon7 : Cons
    {
      private readonly RiverNoiseFilter arg\u00241;

      internal __\u003C\u003EAnon7([In] RiverNoiseFilter obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024options\u00247((Block) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon8 : Prov
    {
      private readonly RiverNoiseFilter arg\u00241;

      internal __\u003C\u003EAnon8([In] RiverNoiseFilter obj0) => this.arg\u00241 = obj0;

      public object get() => (object) this.arg\u00241.lambda\u0024options\u00248();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon9 : Cons
    {
      private readonly RiverNoiseFilter arg\u00241;

      internal __\u003C\u003EAnon9([In] RiverNoiseFilter obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024options\u00249((Block) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon10 : Prov
    {
      private readonly RiverNoiseFilter arg\u00241;

      internal __\u003C\u003EAnon10([In] RiverNoiseFilter obj0) => this.arg\u00241 = obj0;

      public object get() => (object) this.arg\u00241.lambda\u0024options\u002410();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon11 : Cons
    {
      private readonly RiverNoiseFilter arg\u00241;

      internal __\u003C\u003EAnon11([In] RiverNoiseFilter obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024options\u002411((Block) obj0);
    }
  }
}
