// Decompiled with JetBrains decompiler
// Type: mindustry.world.blocks.distribution.ArmoredConveyor
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using mindustry.gen;
using mindustry.type;
using System.Runtime.CompilerServices;

namespace mindustry.world.blocks.distribution
{
  public class ArmoredConveyor : Conveyor
  {
    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 152, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ArmoredConveyor(string name)
      : base(name)
    {
    }

    [LineNumberTable(new byte[] {159, 157, 127, 3, 52})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool blends(
      Tile tile,
      int rotation,
      int otherx,
      int othery,
      int otherrot,
      Block otherblock)
    {
      return otherblock.outputsItems() && this.blendsArmored(tile, rotation, otherx, othery, otherrot, otherblock) || this.lookingAt(tile, rotation, otherx, othery, otherblock) && otherblock.hasItems;
    }

    [HideFromJava]
    static ArmoredConveyor() => Conveyor.__\u003Cclinit\u003E();

    public class ArmoredConveyorBuild : Conveyor.ConveyorBuild
    {
      [Modifiers]
      internal ArmoredConveyor this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(19)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public ArmoredConveyorBuild(ArmoredConveyor _param1)
      {
        this.this\u00240 = _param1;
        // ISSUE: explicit constructor call
        base.\u002Ector((Conveyor) _param1);
      }

      [LineNumberTable(22)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override bool acceptItem(Building source, Item item) => base.acceptItem(source, item) && (source.block is Conveyor || (int) (sbyte) Edges.getFacingEdge(source.tile(), this.tile).relativeTo(this.tile) == this.rotation);

      [HideFromJava]
      static ArmoredConveyorBuild() => Conveyor.ConveyorBuild.__\u003Cclinit\u003E();
    }
  }
}
