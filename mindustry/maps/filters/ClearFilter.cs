// Decompiled with JetBrains decompiler
// Type: mindustry.maps.filters.ClearFilter
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
  public class ClearFilter : GenerateFilter
  {
    protected internal Block block;

    [LineNumberTable(new byte[] {159, 151, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ClearFilter()
    {
      ClearFilter clearFilter = this;
      this.block = Blocks.air;
    }

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Block lambda\u0024options\u00240() => this.block;

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024options\u00241([In] Block obj0) => this.block = obj0;

    [Modifiers]
    [LineNumberTable(14)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024options\u00242([In] Block obj0) => FilterOption.__\u003C\u003EoresOnly.get((object) obj0) || FilterOption.__\u003C\u003EwallsOnly.get((object) obj0);

    [LineNumberTable(14)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override FilterOption[] options()
    {
      FilterOption.BlockOption[] blockOptionArray = new FilterOption.BlockOption[1];
      FilterOption.BlockOption.__\u003Cclinit\u003E();
      blockOptionArray[0] = new FilterOption.BlockOption("block", (Prov) new ClearFilter.__\u003C\u003EAnon0(this), (Cons) new ClearFilter.__\u003C\u003EAnon1(this), (Boolf) new ClearFilter.__\u003C\u003EAnon2());
      return (FilterOption[]) Structs.arr((object[]) blockOptionArray);
    }

    [LineNumberTable(new byte[] {159, 162, 120, 176, 120, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void apply()
    {
      if (object.ReferenceEquals((object) this.@in.block, (object) this.block))
        this.@in.block = Blocks.air;
      if (!object.ReferenceEquals((object) this.@in.overlay, (object) this.block))
        return;
      this.@in.overlay = Blocks.air;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Prov
    {
      private readonly ClearFilter arg\u00241;

      internal __\u003C\u003EAnon0([In] ClearFilter obj0) => this.arg\u00241 = obj0;

      public object get() => (object) this.arg\u00241.lambda\u0024options\u00240();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Cons
    {
      private readonly ClearFilter arg\u00241;

      internal __\u003C\u003EAnon1([In] ClearFilter obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024options\u00241((Block) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon2 : Boolf
    {
      internal __\u003C\u003EAnon2()
      {
      }

      public bool get([In] object obj0) => (ClearFilter.lambda\u0024options\u00242((Block) obj0) ? 1 : 0) != 0;
    }
  }
}
