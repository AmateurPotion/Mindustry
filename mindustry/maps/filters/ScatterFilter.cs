// Decompiled with JetBrains decompiler
// Type: mindustry.maps.filters.ScatterFilter
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
  public class ScatterFilter : GenerateFilter
  {
    protected internal float chance;
    protected internal Block flooronto;
    protected internal Block floor;
    protected internal Block block;

    [LineNumberTable(new byte[] {159, 151, 104, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ScatterFilter()
    {
      ScatterFilter scatterFilter = this;
      this.chance = 0.013f;
      this.flooronto = Blocks.air;
      this.floor = Blocks.air;
      this.block = Blocks.air;
    }

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private float lambda\u0024options\u00240() => this.chance;

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024options\u00241([In] float obj0) => this.chance = obj0;

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Block lambda\u0024options\u00242() => this.flooronto;

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024options\u00243([In] Block obj0) => this.flooronto = obj0;

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Block lambda\u0024options\u00244() => this.floor;

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024options\u00245([In] Block obj0) => this.floor = obj0;

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Block lambda\u0024options\u00246() => this.block;

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024options\u00247([In] Block obj0) => this.block = obj0;

    [LineNumberTable(15)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override FilterOption[] options()
    {
      FilterOption[] filterOptionArray = new FilterOption[4];
      FilterOption.SliderOption.__\u003Cclinit\u003E();
      filterOptionArray[0] = (FilterOption) new FilterOption.SliderOption("chance", (Floatp) new ScatterFilter.__\u003C\u003EAnon0(this), (Floatc) new ScatterFilter.__\u003C\u003EAnon1(this), 0.0f, 1f);
      FilterOption.BlockOption.__\u003Cclinit\u003E();
      filterOptionArray[1] = (FilterOption) new FilterOption.BlockOption("flooronto", (Prov) new ScatterFilter.__\u003C\u003EAnon2(this), (Cons) new ScatterFilter.__\u003C\u003EAnon3(this), FilterOption.__\u003C\u003EfloorsOptional);
      FilterOption.BlockOption.__\u003Cclinit\u003E();
      filterOptionArray[2] = (FilterOption) new FilterOption.BlockOption("floor", (Prov) new ScatterFilter.__\u003C\u003EAnon4(this), (Cons) new ScatterFilter.__\u003C\u003EAnon5(this), FilterOption.__\u003C\u003EfloorsOptional);
      FilterOption.BlockOption.__\u003Cclinit\u003E();
      filterOptionArray[3] = (FilterOption) new FilterOption.BlockOption("block", (Prov) new ScatterFilter.__\u003C\u003EAnon6(this), (Cons) new ScatterFilter.__\u003C\u003EAnon7(this), FilterOption.__\u003C\u003EwallsOresOptional);
      return (FilterOption[]) Structs.arr((object[]) filterOptionArray);
    }

    [LineNumberTable(new byte[] {159, 168, 127, 70, 109, 147, 209, 127, 44, 145})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void apply()
    {
      if (!object.ReferenceEquals((object) this.block, (object) Blocks.air) && (object.ReferenceEquals((object) this.@in.floor, (object) this.flooronto) || object.ReferenceEquals((object) this.flooronto, (object) Blocks.air)) && (object.ReferenceEquals((object) this.@in.block, (object) Blocks.air) && (double) this.chance() <= (double) this.chance))
      {
        if (!this.block.isOverlay())
          this.@in.block = this.block;
        else
          this.@in.overlay = this.block;
      }
      if (object.ReferenceEquals((object) this.floor, (object) Blocks.air) || !object.ReferenceEquals((object) this.@in.floor, (object) this.flooronto) && !object.ReferenceEquals((object) this.flooronto, (object) Blocks.air) || (double) this.chance() > (double) this.chance)
        return;
      this.@in.floor = this.floor;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Floatp
    {
      private readonly ScatterFilter arg\u00241;

      internal __\u003C\u003EAnon0([In] ScatterFilter obj0) => this.arg\u00241 = obj0;

      public float get() => this.arg\u00241.lambda\u0024options\u00240();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Floatc
    {
      private readonly ScatterFilter arg\u00241;

      internal __\u003C\u003EAnon1([In] ScatterFilter obj0) => this.arg\u00241 = obj0;

      public void get([In] float obj0) => this.arg\u00241.lambda\u0024options\u00241(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon2 : Prov
    {
      private readonly ScatterFilter arg\u00241;

      internal __\u003C\u003EAnon2([In] ScatterFilter obj0) => this.arg\u00241 = obj0;

      public object get() => (object) this.arg\u00241.lambda\u0024options\u00242();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon3 : Cons
    {
      private readonly ScatterFilter arg\u00241;

      internal __\u003C\u003EAnon3([In] ScatterFilter obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024options\u00243((Block) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon4 : Prov
    {
      private readonly ScatterFilter arg\u00241;

      internal __\u003C\u003EAnon4([In] ScatterFilter obj0) => this.arg\u00241 = obj0;

      public object get() => (object) this.arg\u00241.lambda\u0024options\u00244();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon5 : Cons
    {
      private readonly ScatterFilter arg\u00241;

      internal __\u003C\u003EAnon5([In] ScatterFilter obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024options\u00245((Block) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon6 : Prov
    {
      private readonly ScatterFilter arg\u00241;

      internal __\u003C\u003EAnon6([In] ScatterFilter obj0) => this.arg\u00241 = obj0;

      public object get() => (object) this.arg\u00241.lambda\u0024options\u00246();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon7 : Cons
    {
      private readonly ScatterFilter arg\u00241;

      internal __\u003C\u003EAnon7([In] ScatterFilter obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024options\u00247((Block) obj0);
    }
  }
}
