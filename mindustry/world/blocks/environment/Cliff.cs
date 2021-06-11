// Decompiled with JetBrains decompiler
// Type: mindustry.world.blocks.environment.Cliff
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.graphics.g2d;
using arc.util;
using IKVM.Attributes;
using mindustry.graphics;
using System.Runtime.CompilerServices;

namespace mindustry.world.blocks.environment
{
  public class Cliff : Block
  {
    public float size;
    public TextureRegion[] cliffs;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 156, 233, 60, 235, 69, 114, 103, 107, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Cliff(string name)
      : base(name)
    {
      Cliff cliff1 = this;
      this.size = 11f;
      Cliff cliff2 = this;
      int num1 = 0;
      int num2 = num1;
      this.alwaysReplace = num1 != 0;
      this.breakable = num2 != 0;
      this.solid = true;
      this.cacheLayer = CacheLayer.__\u003C\u003Ewalls;
      this.fillsTile = false;
      this.hasShadow = false;
    }

    [LineNumberTable(new byte[] {159, 166, 127, 5, 127, 8, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void drawBase(Tile tile)
    {
      Draw.color(Tmp.__\u003C\u003Ec1.set(tile.floor().mapColor).mul(1.6f));
      Draw.rect(this.cliffs[(int) (sbyte) tile.data & (int) byte.MaxValue], tile.worldx(), tile.worldy());
      Draw.color();
    }

    [LineNumberTable(31)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override int minimapColor(Tile tile) => Tmp.__\u003C\u003Ec1.set(tile.floor().mapColor).mul(1.2f).rgba();

    [HideFromJava]
    static Cliff() => Block.__\u003Cclinit\u003E();
  }
}
