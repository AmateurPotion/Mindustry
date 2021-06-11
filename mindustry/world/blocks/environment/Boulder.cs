// Decompiled with JetBrains decompiler
// Type: mindustry.world.blocks.environment.Boulder
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.graphics.g2d;
using arc.math;
using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;

namespace mindustry.world.blocks.environment
{
  public class Boulder : Block
  {
    public int variants;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 154, 105, 103, 135, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Boulder(string name)
      : base(name)
    {
      Boulder boulder = this;
      this.breakable = true;
      this.alwaysReplace = true;
      this.deconstructThreshold = 0.35f;
    }

    [LineNumberTable(new byte[] {159, 163, 105, 159, 25, 153})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void drawBase(Tile tile)
    {
      if (this.variants > 0)
        Draw.rect(this.variantRegions[Mathf.randomSeed((long) tile.pos(), 0, Math.max(0, this.variantRegions.Length - 1))], tile.worldx(), tile.worldy());
      else
        Draw.rect(this.region, tile.worldx(), tile.worldy());
    }

    [LineNumberTable(30)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override TextureRegion[] icons()
    {
      if (this.variants == 0)
        return base.icons();
      return new TextureRegion[1]
      {
        (TextureRegion) Core.atlas.find(new StringBuilder().append(this.__\u003C\u003Ename).append("1").toString())
      };
    }

    [LineNumberTable(new byte[] {159, 177, 134, 105, 145, 107, 63, 16, 198})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void load()
    {
      base.load();
      if (this.variants <= 0)
        return;
      this.variantRegions = new TextureRegion[this.variants];
      for (int index = 0; index < this.variants; ++index)
        this.variantRegions[index] = (TextureRegion) Core.atlas.find(new StringBuilder().append(this.__\u003C\u003Ename).append(index + 1).toString());
    }

    [HideFromJava]
    static Boulder() => Block.__\u003Cclinit\u003E();
  }
}
