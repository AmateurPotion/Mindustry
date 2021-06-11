// Decompiled with JetBrains decompiler
// Type: mindustry.world.blocks.environment.AirBlock
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.graphics.g2d;
using IKVM.Attributes;
using System.Runtime.CompilerServices;

namespace mindustry.world.blocks.environment
{
  public class AirBlock : Floor
  {
    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 153, 105, 103, 103, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public AirBlock(string name)
      : base(name)
    {
      AirBlock airBlock = this;
      this.alwaysReplace = true;
      this.hasShadow = false;
      this.useColor = false;
      this.wall = (Block) this;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void drawBase(Tile tile)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void load()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void init() => this.decoration = (Block) this;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool isHidden() => true;

    [LineNumberTable(new byte[] {159, 180, 104, 158})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override TextureRegion[] variantRegions()
    {
      if (this.variantRegions == null)
        this.variantRegions = new TextureRegion[1]
        {
          (TextureRegion) Core.atlas.find("clear")
        };
      return this.variantRegions;
    }

    [HideFromJava]
    static AirBlock() => Floor.__\u003Cclinit\u003E();
  }
}
