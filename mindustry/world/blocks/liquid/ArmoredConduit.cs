// Decompiled with JetBrains decompiler
// Type: mindustry.world.blocks.liquid.ArmoredConduit
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.graphics.g2d;
using IKVM.Attributes;
using mindustry.gen;
using mindustry.type;
using System.Runtime.CompilerServices;

namespace mindustry.world.blocks.liquid
{
  public class ArmoredConduit : Conduit
  {
    public TextureRegion capRegion;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 155, 105, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ArmoredConduit(string name)
      : base(name)
    {
      ArmoredConduit armoredConduit = this;
      this.leaks = false;
    }

    [LineNumberTable(new byte[] {159, 161, 127, 3, 52})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool blends(
      Tile tile,
      int rotation,
      int otherx,
      int othery,
      int otherrot,
      Block otherblock)
    {
      return otherblock.outputsLiquid && this.blendsArmored(tile, rotation, otherx, othery, otherrot, otherblock) || this.lookingAt(tile, rotation, otherx, othery, otherblock) && otherblock.hasLiquids;
    }

    [HideFromJava]
    static ArmoredConduit() => Conduit.__\u003Cclinit\u003E();

    public class ArmoredConduitBuild : Conduit.ConduitBuild
    {
      [Modifiers]
      internal ArmoredConduit this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(23)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public ArmoredConduitBuild(ArmoredConduit _param1)
      {
        this.this\u00240 = _param1;
        // ISSUE: explicit constructor call
        base.\u002Ector((Conduit) _param1);
      }

      [LineNumberTable(new byte[] {159, 168, 166, 103, 159, 5, 127, 4})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void draw()
      {
        base.draw();
        Building building = this.front();
        if (building != null && object.ReferenceEquals((object) building.team, (object) this.team) && building.block.hasLiquids)
          return;
        Draw.rect(this.this\u00240.capRegion, this.x, this.y, this.rotdeg());
      }

      [LineNumberTable(new byte[] {159, 179, 127, 20, 50})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override bool acceptLiquid(Building source, Liquid liquid) => base.acceptLiquid(source, liquid) && (source.block is Conduit || (int) (sbyte) source.tile.absoluteRelativeTo((int) this.tile.x, (int) this.tile.y) == this.rotation);

      [HideFromJava]
      static ArmoredConduitBuild() => Conduit.ConduitBuild.__\u003Cclinit\u003E();
    }
  }
}
