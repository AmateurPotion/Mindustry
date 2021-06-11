// Decompiled with JetBrains decompiler
// Type: mindustry.maps.filters.BlendFilter
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.func;
using arc.math;
using arc.util;
using IKVM.Attributes;
using IKVM.Runtime;
using mindustry.content;
using mindustry.world;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.maps.filters
{
  public class BlendFilter : GenerateFilter
  {
    internal float radius;
    internal Block block;
    internal Block floor;
    internal Block ignore;

    [LineNumberTable(new byte[] {159, 152, 104, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public BlendFilter()
    {
      BlendFilter blendFilter = this;
      this.radius = 2f;
      this.block = Blocks.stone;
      this.floor = Blocks.ice;
      this.ignore = Blocks.air;
    }

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private float lambda\u0024options\u00240() => this.radius;

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024options\u00241([In] float obj0) => this.radius = obj0;

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Block lambda\u0024options\u00242() => this.block;

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024options\u00243([In] Block obj0) => this.block = obj0;

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Block lambda\u0024options\u00244() => this.floor;

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024options\u00245([In] Block obj0) => this.floor = obj0;

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Block lambda\u0024options\u00246() => this.ignore;

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024options\u00247([In] Block obj0) => this.ignore = obj0;

    [LineNumberTable(16)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override FilterOption[] options()
    {
      FilterOption[] filterOptionArray = new FilterOption[4];
      FilterOption.SliderOption.__\u003Cclinit\u003E();
      filterOptionArray[0] = (FilterOption) new FilterOption.SliderOption("radius", (Floatp) new BlendFilter.__\u003C\u003EAnon0(this), (Floatc) new BlendFilter.__\u003C\u003EAnon1(this), 1f, 10f);
      FilterOption.BlockOption.__\u003Cclinit\u003E();
      filterOptionArray[1] = (FilterOption) new FilterOption.BlockOption("block", (Prov) new BlendFilter.__\u003C\u003EAnon2(this), (Cons) new BlendFilter.__\u003C\u003EAnon3(this), FilterOption.__\u003C\u003EanyOptional);
      FilterOption.BlockOption.__\u003Cclinit\u003E();
      filterOptionArray[2] = (FilterOption) new FilterOption.BlockOption("floor", (Prov) new BlendFilter.__\u003C\u003EAnon4(this), (Cons) new BlendFilter.__\u003C\u003EAnon5(this), FilterOption.__\u003C\u003EfloorsOnly);
      FilterOption.BlockOption.__\u003Cclinit\u003E();
      filterOptionArray[3] = (FilterOption) new FilterOption.BlockOption("ignore", (Prov) new BlendFilter.__\u003C\u003EAnon6(this), (Cons) new BlendFilter.__\u003C\u003EAnon7(this), FilterOption.__\u003C\u003EfloorsOptional);
      return (FilterOption[]) Structs.arr((object[]) filterOptionArray);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool isBuffered() => true;

    [LineNumberTable(new byte[] {159, 173, 159, 36, 108, 162, 106, 106, 114, 159, 10, 127, 29, 98, 226, 58, 41, 233, 76, 99, 145})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void apply()
    {
      if (object.ReferenceEquals((object) this.@in.floor, (object) this.block) || object.ReferenceEquals((object) this.block, (object) Blocks.air) || object.ReferenceEquals((object) this.@in.floor, (object) this.ignore))
        return;
      int num1 = ByteCodeHelper.f2i(this.radius);
      int num2 = 0;
      for (int index1 = -num1; index1 <= num1; ++index1)
      {
        for (int index2 = -num1; index2 <= num1; ++index2)
        {
          if (!Mathf.within((float) index1, (float) index2, (float) num1))
          {
            Tile tile = this.@in.tile((float) (this.@in.x + index1), (float) (this.@in.y + index2));
            if (object.ReferenceEquals((object) tile.floor(), (object) this.block) || object.ReferenceEquals((object) tile.block(), (object) this.block) || object.ReferenceEquals((object) tile.overlay(), (object) this.block))
            {
              num2 = 1;
              goto label_12;
            }
          }
        }
      }
label_12:
      if (num2 == 0)
        return;
      this.@in.floor = this.floor;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Floatp
    {
      private readonly BlendFilter arg\u00241;

      internal __\u003C\u003EAnon0([In] BlendFilter obj0) => this.arg\u00241 = obj0;

      public float get() => this.arg\u00241.lambda\u0024options\u00240();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Floatc
    {
      private readonly BlendFilter arg\u00241;

      internal __\u003C\u003EAnon1([In] BlendFilter obj0) => this.arg\u00241 = obj0;

      public void get([In] float obj0) => this.arg\u00241.lambda\u0024options\u00241(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon2 : Prov
    {
      private readonly BlendFilter arg\u00241;

      internal __\u003C\u003EAnon2([In] BlendFilter obj0) => this.arg\u00241 = obj0;

      public object get() => (object) this.arg\u00241.lambda\u0024options\u00242();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon3 : Cons
    {
      private readonly BlendFilter arg\u00241;

      internal __\u003C\u003EAnon3([In] BlendFilter obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024options\u00243((Block) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon4 : Prov
    {
      private readonly BlendFilter arg\u00241;

      internal __\u003C\u003EAnon4([In] BlendFilter obj0) => this.arg\u00241 = obj0;

      public object get() => (object) this.arg\u00241.lambda\u0024options\u00244();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon5 : Cons
    {
      private readonly BlendFilter arg\u00241;

      internal __\u003C\u003EAnon5([In] BlendFilter obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024options\u00245((Block) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon6 : Prov
    {
      private readonly BlendFilter arg\u00241;

      internal __\u003C\u003EAnon6([In] BlendFilter obj0) => this.arg\u00241 = obj0;

      public object get() => (object) this.arg\u00241.lambda\u0024options\u00246();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon7 : Cons
    {
      private readonly BlendFilter arg\u00241;

      internal __\u003C\u003EAnon7([In] BlendFilter obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024options\u00247((Block) obj0);
    }
  }
}
