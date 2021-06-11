// Decompiled with JetBrains decompiler
// Type: mindustry.maps.filters.OreFilter
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
  public class OreFilter : GenerateFilter
  {
    public float scl;
    public float threshold;
    public float octaves;
    public float falloff;
    public Block ore;
    public Block target;

    [LineNumberTable(new byte[] {159, 151, 104, 127, 13})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public OreFilter()
    {
      OreFilter oreFilter = this;
      this.scl = 23f;
      this.threshold = 0.81f;
      this.octaves = 2f;
      this.falloff = 0.3f;
      this.ore = Blocks.oreCopper;
      this.target = Blocks.air;
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
    private float lambda\u0024options\u00244() => this.octaves;

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024options\u00245([In] float obj0) => this.octaves = obj0;

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private float lambda\u0024options\u00246() => this.falloff;

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024options\u00247([In] float obj0) => this.falloff = obj0;

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Block lambda\u0024options\u00248() => this.ore;

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024options\u00249([In] Block obj0) => this.ore = obj0;

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Block lambda\u0024options\u002410() => this.target;

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024options\u002411([In] Block obj0) => this.target = obj0;

    [LineNumberTable(15)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override FilterOption[] options()
    {
      FilterOption[] filterOptionArray = new FilterOption[6];
      FilterOption.SliderOption.__\u003Cclinit\u003E();
      filterOptionArray[0] = (FilterOption) new FilterOption.SliderOption("scale", (Floatp) new OreFilter.__\u003C\u003EAnon0(this), (Floatc) new OreFilter.__\u003C\u003EAnon1(this), 1f, 500f);
      FilterOption.SliderOption.__\u003Cclinit\u003E();
      filterOptionArray[1] = (FilterOption) new FilterOption.SliderOption("threshold", (Floatp) new OreFilter.__\u003C\u003EAnon2(this), (Floatc) new OreFilter.__\u003C\u003EAnon3(this), 0.0f, 1f);
      FilterOption.SliderOption.__\u003Cclinit\u003E();
      filterOptionArray[2] = (FilterOption) new FilterOption.SliderOption("octaves", (Floatp) new OreFilter.__\u003C\u003EAnon4(this), (Floatc) new OreFilter.__\u003C\u003EAnon5(this), 1f, 10f);
      FilterOption.SliderOption.__\u003Cclinit\u003E();
      filterOptionArray[3] = (FilterOption) new FilterOption.SliderOption("falloff", (Floatp) new OreFilter.__\u003C\u003EAnon6(this), (Floatc) new OreFilter.__\u003C\u003EAnon7(this), 0.0f, 1f);
      FilterOption.BlockOption.__\u003Cclinit\u003E();
      filterOptionArray[4] = (FilterOption) new FilterOption.BlockOption("ore", (Prov) new OreFilter.__\u003C\u003EAnon8(this), (Cons) new OreFilter.__\u003C\u003EAnon9(this), FilterOption.__\u003C\u003EoresOnly);
      FilterOption.BlockOption.__\u003Cclinit\u003E();
      filterOptionArray[5] = (FilterOption) new FilterOption.BlockOption("target", (Prov) new OreFilter.__\u003C\u003EAnon10(this), (Cons) new OreFilter.__\u003C\u003EAnon11(this), FilterOption.__\u003C\u003EoresFloorsOptional);
      return (FilterOption[]) Structs.arr((object[]) filterOptionArray);
    }

    [LineNumberTable(new byte[] {159, 169, 159, 24, 127, 93, 145})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void apply()
    {
      if ((double) this.noise((float) this.@in.x, (float) this.@in.y, this.scl, 1f, this.octaves, this.falloff) <= (double) this.threshold || object.ReferenceEquals((object) this.@in.overlay, (object) Blocks.spawn) || !object.ReferenceEquals((object) this.target, (object) Blocks.air) && !object.ReferenceEquals((object) this.@in.floor, (object) this.target) && !object.ReferenceEquals((object) this.@in.overlay, (object) this.target) || !this.@in.floor.asFloor().hasSurface())
        return;
      this.@in.overlay = this.ore;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Floatp
    {
      private readonly OreFilter arg\u00241;

      internal __\u003C\u003EAnon0([In] OreFilter obj0) => this.arg\u00241 = obj0;

      public float get() => this.arg\u00241.lambda\u0024options\u00240();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Floatc
    {
      private readonly OreFilter arg\u00241;

      internal __\u003C\u003EAnon1([In] OreFilter obj0) => this.arg\u00241 = obj0;

      public void get([In] float obj0) => this.arg\u00241.lambda\u0024options\u00241(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon2 : Floatp
    {
      private readonly OreFilter arg\u00241;

      internal __\u003C\u003EAnon2([In] OreFilter obj0) => this.arg\u00241 = obj0;

      public float get() => this.arg\u00241.lambda\u0024options\u00242();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon3 : Floatc
    {
      private readonly OreFilter arg\u00241;

      internal __\u003C\u003EAnon3([In] OreFilter obj0) => this.arg\u00241 = obj0;

      public void get([In] float obj0) => this.arg\u00241.lambda\u0024options\u00243(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon4 : Floatp
    {
      private readonly OreFilter arg\u00241;

      internal __\u003C\u003EAnon4([In] OreFilter obj0) => this.arg\u00241 = obj0;

      public float get() => this.arg\u00241.lambda\u0024options\u00244();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon5 : Floatc
    {
      private readonly OreFilter arg\u00241;

      internal __\u003C\u003EAnon5([In] OreFilter obj0) => this.arg\u00241 = obj0;

      public void get([In] float obj0) => this.arg\u00241.lambda\u0024options\u00245(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon6 : Floatp
    {
      private readonly OreFilter arg\u00241;

      internal __\u003C\u003EAnon6([In] OreFilter obj0) => this.arg\u00241 = obj0;

      public float get() => this.arg\u00241.lambda\u0024options\u00246();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon7 : Floatc
    {
      private readonly OreFilter arg\u00241;

      internal __\u003C\u003EAnon7([In] OreFilter obj0) => this.arg\u00241 = obj0;

      public void get([In] float obj0) => this.arg\u00241.lambda\u0024options\u00247(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon8 : Prov
    {
      private readonly OreFilter arg\u00241;

      internal __\u003C\u003EAnon8([In] OreFilter obj0) => this.arg\u00241 = obj0;

      public object get() => (object) this.arg\u00241.lambda\u0024options\u00248();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon9 : Cons
    {
      private readonly OreFilter arg\u00241;

      internal __\u003C\u003EAnon9([In] OreFilter obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024options\u00249((Block) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon10 : Prov
    {
      private readonly OreFilter arg\u00241;

      internal __\u003C\u003EAnon10([In] OreFilter obj0) => this.arg\u00241 = obj0;

      public object get() => (object) this.arg\u00241.lambda\u0024options\u002410();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon11 : Cons
    {
      private readonly OreFilter arg\u00241;

      internal __\u003C\u003EAnon11([In] OreFilter obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024options\u002411((Block) obj0);
    }
  }
}
