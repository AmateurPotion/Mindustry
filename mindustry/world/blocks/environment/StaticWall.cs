// Decompiled with JetBrains decompiler
// Type: mindustry.world.blocks.environment.StaticWall
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.graphics.g2d;
using arc.math;
using arc.math.geom;
using IKVM.Attributes;
using java.lang;
using mindustry.graphics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.world.blocks.environment
{
  public class StaticWall : Boulder
  {
    public TextureRegion large;
    public TextureRegion[][] split;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 160, 105, 114, 103, 103, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public StaticWall(string name)
      : base(name)
    {
      StaticWall staticWall1 = this;
      StaticWall staticWall2 = this;
      int num1 = 0;
      int num2 = num1;
      this.alwaysReplace = num1 != 0;
      this.breakable = num2 != 0;
      this.solid = true;
      this.variants = 2;
      this.cacheLayer = CacheLayer.__\u003C\u003Ewalls;
    }

    [LineNumberTable(new byte[] {159, 188, 127, 14, 123, 121, 125, 246, 60})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual bool eq([In] int obj0, [In] int obj1) => obj0 < Vars.world.width() - 1 && obj1 < Vars.world.height() - 1 && (object.ReferenceEquals((object) Vars.world.tile(obj0 + 1, obj1).block(), (object) this) && object.ReferenceEquals((object) Vars.world.tile(obj0, obj1 + 1).block(), (object) this)) && (object.ReferenceEquals((object) Vars.world.tile(obj0, obj1).block(), (object) this) && object.ReferenceEquals((object) Vars.world.tile(obj0 + 1, obj1 + 1).block(), (object) this));

    [LineNumberTable(new byte[] {159, 169, 107, 139, 127, 26, 127, 34, 105, 159, 25, 153})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void drawBase(Tile tile)
    {
      int x1 = (int) tile.x / 2 * 2;
      int y1 = (int) tile.y / 2 * 2;
      if (Core.atlas.isFound(this.large) && this.eq(x1, y1) && (double) Mathf.randomSeed((long) Point2.pack(x1, y1)) < 0.5)
      {
        TextureRegion[][] split = this.split;
        int x2 = (int) tile.x;
        int num1 = 2;
        int index1 = num1 != -1 ? x2 % num1 : 0;
        TextureRegion[] textureRegionArray = split[index1];
        int y2 = (int) tile.y;
        int num2 = 2;
        int index2 = 1 - (num2 != -1 ? y2 % num2 : 0);
        Draw.rect(textureRegionArray[index2], tile.worldx(), tile.worldy());
      }
      else if (this.variants > 0)
        Draw.rect(this.variantRegions[Mathf.randomSeed((long) tile.pos(), 0, Math.max(0, this.variantRegions.Length - 1))], tile.worldx(), tile.worldy());
      else
        Draw.rect(this.region, tile.worldx(), tile.worldy());
    }

    [LineNumberTable(new byte[] {159, 183, 102, 117})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void load()
    {
      base.load();
      this.split = this.large.split(32, 32);
    }

    [HideFromJava]
    static StaticWall() => Boulder.__\u003Cclinit\u003E();
  }
}
