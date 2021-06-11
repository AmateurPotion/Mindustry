// Decompiled with JetBrains decompiler
// Type: mindustry.maps.filters.DistortFilter
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.func;
using arc.util;
using IKVM.Attributes;
using mindustry.world;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.maps.filters
{
  public class DistortFilter : GenerateFilter
  {
    internal float scl;
    internal float mag;

    [LineNumberTable(new byte[] {159, 149, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public DistortFilter()
    {
      DistortFilter distortFilter = this;
      this.scl = 40f;
      this.mag = 5f;
    }

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private float lambda\u0024options\u00240() => this.scl;

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024options\u00241([In] float obj0) => this.scl = obj0;

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private float lambda\u0024options\u00242() => this.mag;

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024options\u00243([In] float obj0) => this.mag = obj0;

    [LineNumberTable(12)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override FilterOption[] options()
    {
      FilterOption.SliderOption[] sliderOptionArray = new FilterOption.SliderOption[2];
      FilterOption.SliderOption.__\u003Cclinit\u003E();
      sliderOptionArray[0] = new FilterOption.SliderOption("scale", (Floatp) new DistortFilter.__\u003C\u003EAnon0(this), (Floatc) new DistortFilter.__\u003C\u003EAnon1(this), 1f, 200f);
      FilterOption.SliderOption.__\u003Cclinit\u003E();
      sliderOptionArray[1] = new FilterOption.SliderOption("mag", (Floatp) new DistortFilter.__\u003C\u003EAnon2(this), (Floatc) new DistortFilter.__\u003C\u003EAnon3(this), 0.5f, 100f);
      return (FilterOption[]) Structs.arr((object[]) sliderOptionArray);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool isBuffered() => true;

    [LineNumberTable(new byte[] {159, 167, 159, 160, 69, 113, 127, 17, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void apply()
    {
      Tile tile = this.@in.tile((float) this.@in.x + this.noise((float) this.@in.x, (float) this.@in.y, this.scl, this.mag) - this.mag / 2f, (float) this.@in.y + this.noise((float) this.@in.x, (float) this.@in.y + this.o, this.scl, this.mag) - this.mag / 2f);
      this.@in.floor = (Block) tile.floor();
      if (!tile.block().synthetic() && !this.@in.block.synthetic())
        this.@in.block = tile.block();
      this.@in.overlay = (Block) tile.overlay();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Floatp
    {
      private readonly DistortFilter arg\u00241;

      internal __\u003C\u003EAnon0([In] DistortFilter obj0) => this.arg\u00241 = obj0;

      public float get() => this.arg\u00241.lambda\u0024options\u00240();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Floatc
    {
      private readonly DistortFilter arg\u00241;

      internal __\u003C\u003EAnon1([In] DistortFilter obj0) => this.arg\u00241 = obj0;

      public void get([In] float obj0) => this.arg\u00241.lambda\u0024options\u00241(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon2 : Floatp
    {
      private readonly DistortFilter arg\u00241;

      internal __\u003C\u003EAnon2([In] DistortFilter obj0) => this.arg\u00241 = obj0;

      public float get() => this.arg\u00241.lambda\u0024options\u00242();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon3 : Floatc
    {
      private readonly DistortFilter arg\u00241;

      internal __\u003C\u003EAnon3([In] DistortFilter obj0) => this.arg\u00241 = obj0;

      public void get([In] float obj0) => this.arg\u00241.lambda\u0024options\u00243(obj0);
    }
  }
}
