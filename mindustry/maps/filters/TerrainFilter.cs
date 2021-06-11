// Decompiled with JetBrains decompiler
// Type: mindustry.maps.filters.TerrainFilter
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.func;
using arc.math;
using arc.util;
using IKVM.Attributes;
using mindustry.content;
using mindustry.world;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.maps.filters
{
  public class TerrainFilter : GenerateFilter
  {
    internal float scl;
    internal float threshold;
    internal float octaves;
    internal float falloff;
    internal float magnitude;
    internal float circleScl;
    internal Block floor;
    internal Block block;

    [LineNumberTable(new byte[] {159, 152, 104, 127, 35})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public TerrainFilter()
    {
      TerrainFilter terrainFilter = this;
      this.scl = 40f;
      this.threshold = 0.9f;
      this.octaves = 3f;
      this.falloff = 0.5f;
      this.magnitude = 1f;
      this.circleScl = 2.1f;
      this.floor = Blocks.air;
      this.block = Blocks.stoneWall;
    }

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private float lambda\u0024options\u00240() => this.scl;

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024options\u00241([In] float obj0) => this.scl = obj0;

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private float lambda\u0024options\u00242() => this.magnitude;

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024options\u00243([In] float obj0) => this.magnitude = obj0;

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private float lambda\u0024options\u00244() => this.threshold;

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024options\u00245([In] float obj0) => this.threshold = obj0;

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private float lambda\u0024options\u00246() => this.circleScl;

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024options\u00247([In] float obj0) => this.circleScl = obj0;

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private float lambda\u0024options\u00248() => this.octaves;

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024options\u00249([In] float obj0) => this.octaves = obj0;

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private float lambda\u0024options\u002410() => this.falloff;

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024options\u002411([In] float obj0) => this.falloff = obj0;

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Block lambda\u0024options\u002412() => this.floor;

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024options\u002413([In] Block obj0) => this.floor = obj0;

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Block lambda\u0024options\u002414() => this.block;

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024options\u002415([In] Block obj0) => this.block = obj0;

    [LineNumberTable(16)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override FilterOption[] options()
    {
      FilterOption[] filterOptionArray = new FilterOption[8];
      FilterOption.SliderOption.__\u003Cclinit\u003E();
      filterOptionArray[0] = (FilterOption) new FilterOption.SliderOption("scale", (Floatp) new TerrainFilter.__\u003C\u003EAnon0(this), (Floatc) new TerrainFilter.__\u003C\u003EAnon1(this), 1f, 500f);
      FilterOption.SliderOption.__\u003Cclinit\u003E();
      filterOptionArray[1] = (FilterOption) new FilterOption.SliderOption("mag", (Floatp) new TerrainFilter.__\u003C\u003EAnon2(this), (Floatc) new TerrainFilter.__\u003C\u003EAnon3(this), 0.0f, 2f);
      FilterOption.SliderOption.__\u003Cclinit\u003E();
      filterOptionArray[2] = (FilterOption) new FilterOption.SliderOption("threshold", (Floatp) new TerrainFilter.__\u003C\u003EAnon4(this), (Floatc) new TerrainFilter.__\u003C\u003EAnon5(this), 0.0f, 1f);
      FilterOption.SliderOption.__\u003Cclinit\u003E();
      filterOptionArray[3] = (FilterOption) new FilterOption.SliderOption("circle-scale", (Floatp) new TerrainFilter.__\u003C\u003EAnon6(this), (Floatc) new TerrainFilter.__\u003C\u003EAnon7(this), 0.0f, 3f);
      FilterOption.SliderOption.__\u003Cclinit\u003E();
      filterOptionArray[4] = (FilterOption) new FilterOption.SliderOption("octaves", (Floatp) new TerrainFilter.__\u003C\u003EAnon8(this), (Floatc) new TerrainFilter.__\u003C\u003EAnon9(this), 1f, 10f);
      FilterOption.SliderOption.__\u003Cclinit\u003E();
      filterOptionArray[5] = (FilterOption) new FilterOption.SliderOption("falloff", (Floatp) new TerrainFilter.__\u003C\u003EAnon10(this), (Floatc) new TerrainFilter.__\u003C\u003EAnon11(this), 0.0f, 1f);
      FilterOption.BlockOption.__\u003Cclinit\u003E();
      filterOptionArray[6] = (FilterOption) new FilterOption.BlockOption("floor", (Prov) new TerrainFilter.__\u003C\u003EAnon12(this), (Cons) new TerrainFilter.__\u003C\u003EAnon13(this), FilterOption.__\u003C\u003EfloorsOptional);
      FilterOption.BlockOption.__\u003Cclinit\u003E();
      filterOptionArray[7] = (FilterOption) new FilterOption.BlockOption("wall", (Prov) new TerrainFilter.__\u003C\u003EAnon14(this), (Cons) new TerrainFilter.__\u003C\u003EAnon15(this), FilterOption.__\u003C\u003EwallsOnly);
      return (FilterOption[]) Structs.arr((object[]) filterOptionArray);
    }

    [LineNumberTable(new byte[] {159, 172, 159, 103, 114, 177, 105, 145})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void apply()
    {
      float num = this.noise((float) this.@in.x, (float) this.@in.y, this.scl, this.magnitude, this.octaves, this.falloff) + Mathf.dst((float) this.@in.x / (float) this.@in.width, (float) this.@in.y / (float) this.@in.height, 0.5f, 0.5f) * this.circleScl;
      if (!object.ReferenceEquals((object) this.floor, (object) Blocks.air))
        this.@in.floor = this.floor;
      if ((double) num < (double) this.threshold)
        return;
      this.@in.block = this.block;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Floatp
    {
      private readonly TerrainFilter arg\u00241;

      internal __\u003C\u003EAnon0([In] TerrainFilter obj0) => this.arg\u00241 = obj0;

      public float get() => this.arg\u00241.lambda\u0024options\u00240();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Floatc
    {
      private readonly TerrainFilter arg\u00241;

      internal __\u003C\u003EAnon1([In] TerrainFilter obj0) => this.arg\u00241 = obj0;

      public void get([In] float obj0) => this.arg\u00241.lambda\u0024options\u00241(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon2 : Floatp
    {
      private readonly TerrainFilter arg\u00241;

      internal __\u003C\u003EAnon2([In] TerrainFilter obj0) => this.arg\u00241 = obj0;

      public float get() => this.arg\u00241.lambda\u0024options\u00242();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon3 : Floatc
    {
      private readonly TerrainFilter arg\u00241;

      internal __\u003C\u003EAnon3([In] TerrainFilter obj0) => this.arg\u00241 = obj0;

      public void get([In] float obj0) => this.arg\u00241.lambda\u0024options\u00243(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon4 : Floatp
    {
      private readonly TerrainFilter arg\u00241;

      internal __\u003C\u003EAnon4([In] TerrainFilter obj0) => this.arg\u00241 = obj0;

      public float get() => this.arg\u00241.lambda\u0024options\u00244();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon5 : Floatc
    {
      private readonly TerrainFilter arg\u00241;

      internal __\u003C\u003EAnon5([In] TerrainFilter obj0) => this.arg\u00241 = obj0;

      public void get([In] float obj0) => this.arg\u00241.lambda\u0024options\u00245(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon6 : Floatp
    {
      private readonly TerrainFilter arg\u00241;

      internal __\u003C\u003EAnon6([In] TerrainFilter obj0) => this.arg\u00241 = obj0;

      public float get() => this.arg\u00241.lambda\u0024options\u00246();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon7 : Floatc
    {
      private readonly TerrainFilter arg\u00241;

      internal __\u003C\u003EAnon7([In] TerrainFilter obj0) => this.arg\u00241 = obj0;

      public void get([In] float obj0) => this.arg\u00241.lambda\u0024options\u00247(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon8 : Floatp
    {
      private readonly TerrainFilter arg\u00241;

      internal __\u003C\u003EAnon8([In] TerrainFilter obj0) => this.arg\u00241 = obj0;

      public float get() => this.arg\u00241.lambda\u0024options\u00248();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon9 : Floatc
    {
      private readonly TerrainFilter arg\u00241;

      internal __\u003C\u003EAnon9([In] TerrainFilter obj0) => this.arg\u00241 = obj0;

      public void get([In] float obj0) => this.arg\u00241.lambda\u0024options\u00249(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon10 : Floatp
    {
      private readonly TerrainFilter arg\u00241;

      internal __\u003C\u003EAnon10([In] TerrainFilter obj0) => this.arg\u00241 = obj0;

      public float get() => this.arg\u00241.lambda\u0024options\u002410();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon11 : Floatc
    {
      private readonly TerrainFilter arg\u00241;

      internal __\u003C\u003EAnon11([In] TerrainFilter obj0) => this.arg\u00241 = obj0;

      public void get([In] float obj0) => this.arg\u00241.lambda\u0024options\u002411(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon12 : Prov
    {
      private readonly TerrainFilter arg\u00241;

      internal __\u003C\u003EAnon12([In] TerrainFilter obj0) => this.arg\u00241 = obj0;

      public object get() => (object) this.arg\u00241.lambda\u0024options\u002412();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon13 : Cons
    {
      private readonly TerrainFilter arg\u00241;

      internal __\u003C\u003EAnon13([In] TerrainFilter obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024options\u002413((Block) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon14 : Prov
    {
      private readonly TerrainFilter arg\u00241;

      internal __\u003C\u003EAnon14([In] TerrainFilter obj0) => this.arg\u00241 = obj0;

      public object get() => (object) this.arg\u00241.lambda\u0024options\u002414();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon15 : Cons
    {
      private readonly TerrainFilter arg\u00241;

      internal __\u003C\u003EAnon15([In] TerrainFilter obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024options\u002415((Block) obj0);
    }
  }
}
