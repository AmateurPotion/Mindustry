// Decompiled with JetBrains decompiler
// Type: mindustry.maps.generators.BasicGenerator
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.func;
using arc.math;
using arc.math.geom;
using arc.util;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.util;
using mindustry.ai;
using mindustry.content;
using mindustry.world;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.maps.generators
{
  public abstract class BasicGenerator : Object, WorldGenerator
  {
    internal static ShortSeq __\u003C\u003Eints1;
    internal static ShortSeq __\u003C\u003Eints2;
    protected internal Rand rand;
    protected internal int width;
    protected internal int height;
    protected internal Tiles tiles;
    protected internal Block floor;
    protected internal Block block;
    protected internal Block ore;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal static void __\u003Cclinit\u003E()
    {
    }

    [HideFromJava]
    public virtual void postGenerate([In] Tiles obj0) => WorldGenerator.\u003Cdefault\u003EpostGenerate((WorldGenerator) this, obj0);

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void generate()
    {
    }

    [LineNumberTable(new byte[] {159, 189, 125, 136, 251, 78, 211})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void median(int radius, double percentile)
    {
      short[] numArray1 = new short[this.tiles.__\u003C\u003Ewidth * this.tiles.__\u003C\u003Eheight];
      short[] numArray2 = new short[numArray1.Length];
      this.tiles.each((Intc2) new BasicGenerator.__\u003C\u003EAnon0(this, radius, numArray2, percentile, numArray1));
      this.pass((Intc2) new BasicGenerator.__\u003C\u003EAnon1(this, numArray1, numArray2));
    }

    [LineNumberTable(new byte[] {160, 118, 127, 4, 108, 108, 108, 114, 113, 108, 108, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void pass(Intc2 r)
    {
      Iterator iterator = this.tiles.iterator();
      while (iterator.hasNext())
      {
        Tile tile = (Tile) iterator.next();
        this.floor = (Block) tile.floor();
        this.block = tile.block();
        this.ore = (Block) tile.overlay();
        r.get((int) tile.x, (int) tile.y);
        tile.setFloor(this.floor.asFloor());
        tile.setBlock(this.block);
        tile.setOverlay(this.ore);
      }
    }

    [LineNumberTable(new byte[] {160, 75, 124, 156, 151, 102, 252, 84, 231, 43, 230, 88, 119})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void cells(int iterations, int birthLimit, int deathLimit, int cradius)
    {
      GridBits other = new GridBits(this.tiles.__\u003C\u003Ewidth, this.tiles.__\u003C\u003Eheight);
      GridBits gridBits = new GridBits(this.tiles.__\u003C\u003Ewidth, this.tiles.__\u003C\u003Eheight);
      this.tiles.each((Intc2) new BasicGenerator.__\u003C\u003EAnon9(this, gridBits));
      for (int index = 0; index < iterations; ++index)
      {
        this.tiles.each((Intc2) new BasicGenerator.__\u003C\u003EAnon10(this, cradius, gridBits, other, deathLimit, birthLimit));
        gridBits.set(other);
      }
      this.tiles.each((Intc2) new BasicGenerator.__\u003C\u003EAnon11(this, gridBits));
    }

    protected internal abstract float noise(
      float f1,
      float f2,
      double d1,
      double d2,
      double d3,
      double d4);

    [LineNumberTable(new byte[] {160, 134, 106, 103, 104, 127, 3, 111, 236, 60, 41, 233, 73})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void erase(int cx, int cy, int rad)
    {
      for (int index1 = -rad; index1 <= rad; ++index1)
      {
        for (int index2 = -rad; index2 <= rad; ++index2)
        {
          int x = cx + index1;
          int y = cy + index2;
          if (Structs.inBounds(x, y, this.width, this.height) && Mathf.within((float) index1, (float) index2, (float) rad))
            this.tiles.getn(x, y).setBlock(Blocks.air);
        }
      }
    }

    [LineNumberTable(222)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual float noise(float x, float y, double scl, double mag) => this.noise(x, y, 1.0, 1.0, scl, mag);

    [LineNumberTable(228)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual float noise(
      float x,
      float y,
      double octaves,
      double falloff,
      double scl)
    {
      return this.noise(x, y, octaves, falloff, scl, 1.0);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {1, 106, 106, 223, 2, 106, 138, 127, 31, 127, 32})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024median\u00241(
      [In] int obj0,
      [In] short[] obj1,
      [In] double obj2,
      [In] short[] obj3,
      [In] int obj4,
      [In] int obj5)
    {
      BasicGenerator.__\u003C\u003Eints1.clear();
      BasicGenerator.__\u003C\u003Eints2.clear();
      Geometry.circle(obj4, obj5, this.width, this.height, obj0, (Intc2) new BasicGenerator.__\u003C\u003EAnon14(this));
      BasicGenerator.__\u003C\u003Eints1.sort();
      BasicGenerator.__\u003C\u003Eints2.sort();
      obj1[obj4 + obj5 * this.width] = BasicGenerator.__\u003C\u003Eints1.get(Mathf.clamp(ByteCodeHelper.d2i((double) BasicGenerator.__\u003C\u003Eints1.size * obj2), 0, BasicGenerator.__\u003C\u003Eints1.size - 1));
      obj3[obj4 + obj5 * this.width] = BasicGenerator.__\u003C\u003Eints2.get(Mathf.clamp(ByteCodeHelper.d2i((double) BasicGenerator.__\u003C\u003Eints2.size * obj2), 0, BasicGenerator.__\u003C\u003Eints2.size - 1));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {15, 125, 125})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024median\u00242([In] short[] obj0, [In] short[] obj1, [In] int obj2, [In] int obj3)
    {
      this.block = Vars.content.block((int) obj0[obj2 + obj3 * this.width]);
      this.floor = Vars.content.block((int) obj1[obj2 + obj3 * this.width]);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {22, 147, 105, 112, 109, 127, 68, 117, 103, 226, 59, 233, 72})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024ores\u00243([In] Seq obj0, [In] int obj1, [In] int obj2)
    {
      if (!this.floor.asFloor().hasSurface())
        return;
      int num1 = obj1 - 4;
      int num2 = obj2 + 23;
      for (int index = obj0.size - 1; index >= 0; index += -1)
      {
        Block block = (Block) obj0.get(index);
        if ((double) Math.abs(0.5f - this.noise((float) num1, (float) (num2 + index * 999), 2.0, 0.7, (double) (40 + index * 2))) > 0.259999990463257 && (double) Math.abs(0.5f - this.noise((float) num1, (float) (num2 - index * 999), 1.0, 1.0, (double) (30 + index * 4))) > 0.370000004768372)
        {
          this.ore = block;
          break;
        }
      }
    }

    [Modifiers]
    [LineNumberTable(new byte[] {38, 127, 41, 142, 127, 22, 106, 100, 183, 108, 136})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024terrain\u00244(
      [In] float obj0,
      [In] float obj1,
      [In] float obj2,
      [In] Block obj3,
      [In] int obj4,
      [In] int obj5)
    {
      double num1 = (double) (this.noise((float) obj4, (float) obj5, 5.0, 0.5, (double) obj0) * obj1 + Mathf.dst((float) obj4 / (float) this.width, (float) obj5 / (float) this.height, 0.5f, 0.5f) * obj2);
      double num2 = (double) Math.min(obj4, Math.min(obj5, Math.min(Math.abs(obj4 - (this.width - 1)), Math.abs(obj5 - (this.height - 1)))));
      double num3 = 5.0;
      if (num2 < num3)
        num1 += (num3 - num2) / num3 / 1.5;
      if (num1 <= 0.9)
        return;
      this.block = obj3;
    }

    [Modifiers]
    [LineNumberTable(new byte[] {55, 121, 112, 104, 109, 168})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024noise\u00245(
      [In] int obj0,
      [In] float obj1,
      [In] float obj2,
      [In] float obj3,
      [In] Block obj4,
      [In] Block obj5,
      [In] int obj6,
      [In] int obj7)
    {
      if ((double) this.noise((float) obj0, obj1, (double) obj2, (double) obj6, (double) obj7) <= (double) obj3)
        return;
      Tile tile = this.tiles.getn(obj6, obj7);
      this.floor = obj4;
      if (!tile.block().solid)
        return;
      this.block = obj5;
    }

    [Modifiers]
    [LineNumberTable(new byte[] {67, 127, 35, 136})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024overlay\u00246(
      [In] int obj0,
      [In] float obj1,
      [In] float obj2,
      [In] float obj3,
      [In] float obj4,
      [In] Block obj5,
      [In] Block obj6,
      [In] int obj7,
      [In] int obj8)
    {
      if ((double) this.noise((float) obj7, (float) obj8, (double) obj0, (double) obj1, (double) obj2) <= (double) obj3 || !Mathf.chance((double) obj4) || !object.ReferenceEquals((object) this.tiles.getn(obj7, obj8).floor(), (object) obj5))
        return;
      this.ore = obj6;
    }

    [Modifiers]
    [LineNumberTable(new byte[] {77, 147, 123, 121, 127, 66, 127, 9, 120, 127, 5, 203, 125, 171})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024tech\u00247([In] int obj0, [In] Block[] obj1, [In] int obj2, [In] int obj3)
    {
      if (!this.floor.asFloor().hasSurface())
        return;
      int num1 = obj2;
      int num2 = obj0;
      int num3 = num2 != -1 ? num1 % num2 : 0;
      int num4 = obj3;
      int num5 = obj0;
      int num6 = num5 != -1 ? num4 % num5 : 0;
      int num7 = obj2;
      int num8 = obj0;
      int num9 = num8 != -1 ? num7 / num8 : -num7;
      int num10 = obj3;
      int num11 = obj0;
      int num12 = num11 != -1 ? num10 / num11 : -num10;
      if ((double) this.noise((float) num9, (float) num12, 0.200000002980232, 1.0) <= 0.629999995231628 || (double) this.noise((float) num9, (float) (num12 + 999), 200.0, 1.0) <= 0.600000023841858 || num3 != 0 && num6 != 0 && (num3 != obj0 - 1 && num6 != obj0 - 1))
        return;
      if (Mathf.chance((double) this.noise((float) (obj2 + 2299171), (float) obj3, 40.0, 1.0)))
      {
        this.floor = obj1[this.rand.random(0, obj1.Length - 1)];
        if ((double) Mathf.dst((float) num3, (float) num6, (float) (obj0 / 2), (float) (obj0 / 2)) > (double) ((float) obj0 / 2f + 2f))
          this.floor = Blocks.darkPanel4;
      }
      if (!this.block.solid || !Mathf.chance(0.7))
        return;
      this.block = Blocks.darkMetal;
    }

    [Modifiers]
    [LineNumberTable(new byte[] {101, 114, 127, 69, 127, 31, 110, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024distort\u00248(
      [In] float obj0,
      [In] float obj1,
      [In] short[] obj2,
      [In] short[] obj3,
      [In] int obj4,
      [In] int obj5)
    {
      int index = obj5 * this.tiles.__\u003C\u003Ewidth + obj4;
      float num1 = (float) obj4 + this.noise((float) obj4 - 155f, (float) obj5 - 200f, (double) obj0, (double) obj1) - obj1 / 2f;
      float num2 = (float) obj5 + this.noise((float) obj4 + 155f, (float) obj5 + 155f, (double) obj0, (double) obj1) - obj1 / 2f;
      Tile tile = this.tiles.getn(Mathf.clamp(ByteCodeHelper.f2i(num1), 0, this.tiles.__\u003C\u003Ewidth - 1), Mathf.clamp(ByteCodeHelper.f2i(num2), 0, this.tiles.__\u003C\u003Eheight - 1));
      obj2[index] = tile.block().__\u003C\u003Eid;
      obj3[index] = tile.floor().__\u003C\u003Eid;
    }

    [Modifiers]
    [LineNumberTable(new byte[] {117, 107, 110, 105, 110, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024scatter\u00249(
      [In] float obj0,
      [In] Block obj1,
      [In] Block obj2,
      [In] int obj3,
      [In] int obj4)
    {
      if (!Mathf.chance((double) obj0))
        return;
      if (object.ReferenceEquals((object) this.floor, (object) obj1))
      {
        this.floor = obj2;
      }
      else
      {
        if (!object.ReferenceEquals((object) this.block, (object) obj1))
          return;
        this.block = obj2;
      }
    }

    [Modifiers]
    [LineNumberTable(192)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024cells\u002410([In] GridBits obj0, [In] int obj1, [In] int obj2) => obj0.set(obj1, obj2, !this.tiles.get(obj1, obj2).block().isAir());

    [Modifiers]
    [LineNumberTable(new byte[] {160, 82, 130, 106, 106, 117, 127, 22, 228, 61, 41, 233, 73, 108, 148, 143})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024cells\u002411(
      [In] int obj0,
      [In] GridBits obj1,
      [In] GridBits obj2,
      [In] int obj3,
      [In] int obj4,
      [In] int obj5,
      [In] int obj6)
    {
      int num = 0;
      for (int index1 = -obj0; index1 <= obj0; ++index1)
      {
        for (int index2 = -obj0; index2 <= obj0; ++index2)
        {
          if ((index1 != 0 || index2 != 0) && Mathf.within((float) index1, (float) index2, (float) obj0) && (!Structs.inBounds(obj5 + index1, obj6 + index2, this.tiles.__\u003C\u003Ewidth, this.tiles.__\u003C\u003Eheight) || obj1.get(obj5 + index1, obj6 + index2)))
            ++num;
        }
      }
      if (obj1.get(obj5, obj6))
        obj2.set(obj5, obj6, num >= obj3);
      else
        obj2.set(obj5, obj6, num > obj4);
    }

    [Modifiers]
    [LineNumberTable(218)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024cells\u002412([In] GridBits obj0, [In] int obj1, [In] int obj2) => this.tiles.get(obj1, obj2).setBlock(obj0.get(obj1, obj2) ? this.tiles.get(obj1, obj2).floor().wall : Blocks.air);

    [Modifiers]
    [LineNumberTable(244)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024brush\u002413([In] int obj0, [In] Tile obj1) => this.erase((int) obj1.x, (int) obj1.y, obj0);

    [Modifiers]
    [LineNumberTable(260)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024pathfind\u002414([In] Tile obj0) => (double) Vars.world.getDarkness((int) obj0.x, (int) obj0.y) <= 1.0;

    [Modifiers]
    [LineNumberTable(new byte[] {4, 124, 124})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024median\u00240([In] int obj0, [In] int obj1)
    {
      BasicGenerator.__\u003C\u003Eints1.add(this.tiles.getn(obj0, obj1).floorID());
      BasicGenerator.__\u003C\u003Eints2.add(this.tiles.getn(obj0, obj1).blockID());
    }

    [LineNumberTable(new byte[] {159, 158, 168})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public BasicGenerator()
    {
      BasicGenerator basicGenerator = this;
      this.rand = new Rand();
    }

    [LineNumberTable(new byte[] {159, 173, 103, 108, 140, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void generate(Tiles tiles)
    {
      this.tiles = tiles;
      this.width = tiles.__\u003C\u003Ewidth;
      this.height = tiles.__\u003C\u003Eheight;
      this.generate();
    }

    [LineNumberTable(new byte[] {159, 185, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void median(int radius) => this.median(radius, 0.5);

    [Signature("(Larc/struct/Seq<Lmindustry/world/Block;>;)V")]
    [LineNumberTable(new byte[] {21, 242, 77})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void ores(Seq ores) => this.pass((Intc2) new BasicGenerator.__\u003C\u003EAnon2(this, ores));

    [LineNumberTable(new byte[] {37, 249, 78})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void terrain(Block dst, float scl, float mag, float cmag) => this.pass((Intc2) new BasicGenerator.__\u003C\u003EAnon3(this, scl, mag, cmag, dst));

    [LineNumberTable(new byte[] {54, 253, 73})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void noise(
      Block floor,
      Block block,
      int octaves,
      float falloff,
      float scl,
      float threshold)
    {
      this.pass((Intc2) new BasicGenerator.__\u003C\u003EAnon4(this, octaves, falloff, scl, threshold, floor, block));
    }

    [LineNumberTable(new byte[] {66, 255, 1, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void overlay(
      Block floor,
      Block block,
      float chance,
      int octaves,
      float falloff,
      float scl,
      float threshold)
    {
      this.pass((Intc2) new BasicGenerator.__\u003C\u003EAnon5(this, octaves, falloff, scl, threshold, chance, floor, block));
    }

    [LineNumberTable(new byte[] {74, 111, 99, 243, 82})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void tech() => this.pass((Intc2) new BasicGenerator.__\u003C\u003EAnon6(this, 20, new Block[1]
    {
      Blocks.darkPanel3
    }));

    [LineNumberTable(new byte[] {97, 125, 136, 252, 72, 103, 109, 120, 243, 61, 230, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void distort(float scl, float mag)
    {
      short[] numArray1 = new short[this.tiles.__\u003C\u003Ewidth * this.tiles.__\u003C\u003Eheight];
      short[] numArray2 = new short[numArray1.Length];
      this.tiles.each((Intc2) new BasicGenerator.__\u003C\u003EAnon7(this, scl, mag, numArray1, numArray2));
      for (int idx = 0; idx < numArray1.Length; ++idx)
      {
        Tile tile = this.tiles.geti(idx);
        tile.setFloor(Vars.content.block((int) numArray2[idx]).asFloor());
        tile.setBlock(Vars.content.block((int) numArray1[idx]));
      }
    }

    [LineNumberTable(new byte[] {116, 245, 72})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void scatter(Block target, Block dst, float chance) => this.pass((Intc2) new BasicGenerator.__\u003C\u003EAnon8(this, chance, target, dst));

    [LineNumberTable(new byte[] {127, 107, 107, 40, 38, 230, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void each(Intc2 r)
    {
      for (int i1 = 0; i1 < this.width; ++i1)
      {
        for (int i2 = 0; i2 < this.height; ++i2)
          r.get(i1, i2);
      }
    }

    [LineNumberTable(new byte[] {160, 71, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void cells(int iterations) => this.cells(iterations, 16, 16, 3);

    [Signature("(Larc/struct/Seq<Lmindustry/world/Tile;>;I)V")]
    [LineNumberTable(new byte[] {160, 130, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void brush(Seq path, int rad) => path.each((Cons) new BasicGenerator.__\u003C\u003EAnon12(this, rad));

    [Signature("(IIIILmindustry/ai/Astar$TileHueristic;Lmindustry/ai/Astar$DistanceHeuristic;)Larc/struct/Seq<Lmindustry/world/Tile;>;")]
    [LineNumberTable(260)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Seq pathfind(
      int startX,
      int startY,
      int endX,
      int endY,
      Astar.TileHueristic th,
      Astar.DistanceHeuristic dh)
    {
      return Astar.pathfind(startX, startY, endX, endY, th, dh, (Boolf) new BasicGenerator.__\u003C\u003EAnon13());
    }

    [LineNumberTable(new byte[] {160, 150, 127, 4, 127, 0, 105, 63, 26, 198, 99, 145, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void trimDark()
    {
      Iterator iterator = this.tiles.iterator();
      while (iterator.hasNext())
      {
        Tile tile = (Tile) iterator.next();
        int num = (double) Vars.world.getDarkness((int) tile.x, (int) tile.y) > 0.0 ? 1 : 0;
        for (int index = 0; index < 4 && num == 0; ++index)
          num = (double) Vars.world.getDarkness((int) tile.x + Geometry.__\u003C\u003Ed4[index].x, (int) tile.y + Geometry.__\u003C\u003Ed4[index].y) > 0.0 ? 1 : 0;
        if (num != 0)
          tile.setBlock(tile.floor().wall);
      }
    }

    [LineNumberTable(new byte[] {160, 163, 156, 102, 108, 107, 103, 111, 105, 127, 0, 119, 113, 113, 127, 10, 116, 237, 58, 235, 74, 133, 127, 5, 127, 10, 147, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void inverseFloodFill(Tile start)
    {
      GridBits gridBits = new GridBits(this.tiles.__\u003C\u003Ewidth, this.tiles.__\u003C\u003Eheight);
      IntSeq intSeq = new IntSeq();
      intSeq.add(start.pos());
label_1:
      while (!intSeq.isEmpty())
      {
        int pos = intSeq.pop();
        int x1 = (int) Point2.x(pos);
        int y1 = (int) Point2.y(pos);
        gridBits.set(x1, y1);
        Point2[] d4 = Geometry.__\u003C\u003Ed4;
        int length = d4.Length;
        int index = 0;
        while (true)
        {
          if (index < length)
          {
            Point2 point2 = d4[index];
            int x2 = x1 + point2.x;
            int y2 = y1 + point2.y;
            if (this.tiles.@in(x2, y2))
            {
              Tile tile = this.tiles.getn(x2, y2);
              if (object.ReferenceEquals((object) tile.block(), (object) Blocks.air) && !gridBits.get((int) tile.x, (int) tile.y))
              {
                gridBits.set((int) tile.x, (int) tile.y);
                intSeq.add(tile.pos());
              }
            }
            ++index;
          }
          else
            goto label_1;
        }
      }
      Iterator iterator = this.tiles.iterator();
      while (iterator.hasNext())
      {
        Tile tile = (Tile) iterator.next();
        if (!gridBits.get((int) tile.x, (int) tile.y) && object.ReferenceEquals((object) tile.block(), (object) Blocks.air))
          tile.setBlock(tile.floor().wall);
      }
    }

    [LineNumberTable(17)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static BasicGenerator()
    {
      if (ByteCodeHelper.isAlreadyInited("mindustry.maps.generators.BasicGenerator"))
        return;
      BasicGenerator.__\u003C\u003Eints1 = new ShortSeq();
      BasicGenerator.__\u003C\u003Eints2 = new ShortSeq();
    }

    [Modifiers]
    protected internal static ShortSeq ints1
    {
      [HideFromJava] get => BasicGenerator.__\u003C\u003Eints1;
    }

    [Modifiers]
    protected internal static ShortSeq ints2
    {
      [HideFromJava] get => BasicGenerator.__\u003C\u003Eints2;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Intc2
    {
      private readonly BasicGenerator arg\u00241;
      private readonly int arg\u00242;
      private readonly short[] arg\u00243;
      private readonly double arg\u00244;
      private readonly short[] arg\u00245;

      internal __\u003C\u003EAnon0(
        [In] BasicGenerator obj0,
        [In] int obj1,
        [In] short[] obj2,
        [In] double obj3,
        [In] short[] obj4)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
        this.arg\u00244 = obj3;
        this.arg\u00245 = obj4;
      }

      public void get([In] int obj0, [In] int obj1) => this.arg\u00241.lambda\u0024median\u00241(this.arg\u00242, this.arg\u00243, this.arg\u00244, this.arg\u00245, obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Intc2
    {
      private readonly BasicGenerator arg\u00241;
      private readonly short[] arg\u00242;
      private readonly short[] arg\u00243;

      internal __\u003C\u003EAnon1([In] BasicGenerator obj0, [In] short[] obj1, [In] short[] obj2)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
      }

      public void get([In] int obj0, [In] int obj1) => this.arg\u00241.lambda\u0024median\u00242(this.arg\u00242, this.arg\u00243, obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon2 : Intc2
    {
      private readonly BasicGenerator arg\u00241;
      private readonly Seq arg\u00242;

      internal __\u003C\u003EAnon2([In] BasicGenerator obj0, [In] Seq obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] int obj0, [In] int obj1) => this.arg\u00241.lambda\u0024ores\u00243(this.arg\u00242, obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon3 : Intc2
    {
      private readonly BasicGenerator arg\u00241;
      private readonly float arg\u00242;
      private readonly float arg\u00243;
      private readonly float arg\u00244;
      private readonly Block arg\u00245;

      internal __\u003C\u003EAnon3(
        [In] BasicGenerator obj0,
        [In] float obj1,
        [In] float obj2,
        [In] float obj3,
        [In] Block obj4)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
        this.arg\u00244 = obj3;
        this.arg\u00245 = obj4;
      }

      public void get([In] int obj0, [In] int obj1) => this.arg\u00241.lambda\u0024terrain\u00244(this.arg\u00242, this.arg\u00243, this.arg\u00244, this.arg\u00245, obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon4 : Intc2
    {
      private readonly BasicGenerator arg\u00241;
      private readonly int arg\u00242;
      private readonly float arg\u00243;
      private readonly float arg\u00244;
      private readonly float arg\u00245;
      private readonly Block arg\u00246;
      private readonly Block arg\u00247;

      internal __\u003C\u003EAnon4(
        [In] BasicGenerator obj0,
        [In] int obj1,
        [In] float obj2,
        [In] float obj3,
        [In] float obj4,
        [In] Block obj5,
        [In] Block obj6)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
        this.arg\u00244 = obj3;
        this.arg\u00245 = obj4;
        this.arg\u00246 = obj5;
        this.arg\u00247 = obj6;
      }

      public void get([In] int obj0, [In] int obj1) => this.arg\u00241.lambda\u0024noise\u00245(this.arg\u00242, this.arg\u00243, this.arg\u00244, this.arg\u00245, this.arg\u00246, this.arg\u00247, obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon5 : Intc2
    {
      private readonly BasicGenerator arg\u00241;
      private readonly int arg\u00242;
      private readonly float arg\u00243;
      private readonly float arg\u00244;
      private readonly float arg\u00245;
      private readonly float arg\u00246;
      private readonly Block arg\u00247;
      private readonly Block arg\u00248;

      internal __\u003C\u003EAnon5(
        [In] BasicGenerator obj0,
        [In] int obj1,
        [In] float obj2,
        [In] float obj3,
        [In] float obj4,
        [In] float obj5,
        [In] Block obj6,
        [In] Block obj7)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
        this.arg\u00244 = obj3;
        this.arg\u00245 = obj4;
        this.arg\u00246 = obj5;
        this.arg\u00247 = obj6;
        this.arg\u00248 = obj7;
      }

      public void get([In] int obj0, [In] int obj1) => this.arg\u00241.lambda\u0024overlay\u00246(this.arg\u00242, this.arg\u00243, this.arg\u00244, this.arg\u00245, this.arg\u00246, this.arg\u00247, this.arg\u00248, obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon6 : Intc2
    {
      private readonly BasicGenerator arg\u00241;
      private readonly int arg\u00242;
      private readonly Block[] arg\u00243;

      internal __\u003C\u003EAnon6([In] BasicGenerator obj0, [In] int obj1, [In] Block[] obj2)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
      }

      public void get([In] int obj0, [In] int obj1) => this.arg\u00241.lambda\u0024tech\u00247(this.arg\u00242, this.arg\u00243, obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon7 : Intc2
    {
      private readonly BasicGenerator arg\u00241;
      private readonly float arg\u00242;
      private readonly float arg\u00243;
      private readonly short[] arg\u00244;
      private readonly short[] arg\u00245;

      internal __\u003C\u003EAnon7(
        [In] BasicGenerator obj0,
        [In] float obj1,
        [In] float obj2,
        [In] short[] obj3,
        [In] short[] obj4)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
        this.arg\u00244 = obj3;
        this.arg\u00245 = obj4;
      }

      public void get([In] int obj0, [In] int obj1) => this.arg\u00241.lambda\u0024distort\u00248(this.arg\u00242, this.arg\u00243, this.arg\u00244, this.arg\u00245, obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon8 : Intc2
    {
      private readonly BasicGenerator arg\u00241;
      private readonly float arg\u00242;
      private readonly Block arg\u00243;
      private readonly Block arg\u00244;

      internal __\u003C\u003EAnon8([In] BasicGenerator obj0, [In] float obj1, [In] Block obj2, [In] Block obj3)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
        this.arg\u00244 = obj3;
      }

      public void get([In] int obj0, [In] int obj1) => this.arg\u00241.lambda\u0024scatter\u00249(this.arg\u00242, this.arg\u00243, this.arg\u00244, obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon9 : Intc2
    {
      private readonly BasicGenerator arg\u00241;
      private readonly GridBits arg\u00242;

      internal __\u003C\u003EAnon9([In] BasicGenerator obj0, [In] GridBits obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] int obj0, [In] int obj1) => this.arg\u00241.lambda\u0024cells\u002410(this.arg\u00242, obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon10 : Intc2
    {
      private readonly BasicGenerator arg\u00241;
      private readonly int arg\u00242;
      private readonly GridBits arg\u00243;
      private readonly GridBits arg\u00244;
      private readonly int arg\u00245;
      private readonly int arg\u00246;

      internal __\u003C\u003EAnon10(
        [In] BasicGenerator obj0,
        [In] int obj1,
        [In] GridBits obj2,
        [In] GridBits obj3,
        [In] int obj4,
        [In] int obj5)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
        this.arg\u00244 = obj3;
        this.arg\u00245 = obj4;
        this.arg\u00246 = obj5;
      }

      public void get([In] int obj0, [In] int obj1) => this.arg\u00241.lambda\u0024cells\u002411(this.arg\u00242, this.arg\u00243, this.arg\u00244, this.arg\u00245, this.arg\u00246, obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon11 : Intc2
    {
      private readonly BasicGenerator arg\u00241;
      private readonly GridBits arg\u00242;

      internal __\u003C\u003EAnon11([In] BasicGenerator obj0, [In] GridBits obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] int obj0, [In] int obj1) => this.arg\u00241.lambda\u0024cells\u002412(this.arg\u00242, obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon12 : Cons
    {
      private readonly BasicGenerator arg\u00241;
      private readonly int arg\u00242;

      internal __\u003C\u003EAnon12([In] BasicGenerator obj0, [In] int obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024brush\u002413(this.arg\u00242, (Tile) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon13 : Boolf
    {
      internal __\u003C\u003EAnon13()
      {
      }

      public bool get([In] object obj0) => (BasicGenerator.lambda\u0024pathfind\u002414((Tile) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon14 : Intc2
    {
      private readonly BasicGenerator arg\u00241;

      internal __\u003C\u003EAnon14([In] BasicGenerator obj0) => this.arg\u00241 = obj0;

      public void get([In] int obj0, [In] int obj1) => this.arg\u00241.lambda\u0024median\u00240(obj0, obj1);
    }
  }
}
