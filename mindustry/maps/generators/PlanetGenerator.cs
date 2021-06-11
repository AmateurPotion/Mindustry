// Decompiled with JetBrains decompiler
// Type: mindustry.maps.generators.PlanetGenerator
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.func;
using arc.graphics;
using arc.math.geom;
using arc.util.noise;
using IKVM.Attributes;
using mindustry.graphics.g3d;
using mindustry.type;
using mindustry.world;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.maps.generators
{
  [Implements(new string[] {"mindustry.graphics.g3d.HexMesher"})]
  public abstract class PlanetGenerator : BasicGenerator, HexMesher
  {
    protected internal IntSeq ints;
    protected internal Sector sector;
    protected internal Simplex noise;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 160, 135, 98, 159, 19, 109, 162, 112, 154, 127, 0, 161, 116, 98, 226, 56, 232, 77, 99, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void generateSector(Sector sector)
    {
      PlanetGrid.Ptile tile1 = sector.__\u003C\u003Etile;
      int num1 = 0;
      float num2 = Noise.snoise3(tile1.v.x, tile1.v.y, tile1.v.z, 1f / 1000f, 0.5f);
      if ((double) num2 > 0.027)
        num1 = 1;
      if ((double) num2 < 0.15)
      {
        PlanetGrid.Ptile[] tiles = tile1.tiles;
        int length = tiles.Length;
        for (int index = 0; index < length; ++index)
        {
          PlanetGrid.Ptile tile2 = tiles[index];
          if (sector.__\u003C\u003Eplanet.getSector(tile2).__\u003C\u003Eid == sector.__\u003C\u003Eplanet.startSector)
            return;
          if (sector.__\u003C\u003Eplanet.getSector(tile2).generateEnemyBase)
          {
            num1 = 0;
            break;
          }
        }
      }
      if (num1 == 0)
        return;
      sector.generateEnemyBase = true;
    }

    [LineNumberTable(new byte[] {7, 103, 103, 146, 102, 243, 72, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void generate(Tiles tiles, Sector sec)
    {
      this.tiles = tiles;
      this.sector = sec;
      this.rand.setSeed((long) sec.__\u003C\u003Eid);
      TileGen tileGen = new TileGen();
      tiles.each((Intc2) new PlanetGenerator.__\u003C\u003EAnon0(this, tileGen, tiles));
      this.generate(tiles);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void genTile(Vec3 position, TileGen tile)
    {
    }

    [Modifiers]
    [LineNumberTable(new byte[] {13, 102, 159, 9, 104, 127, 9})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024generate\u00240([In] TileGen obj0, [In] Tiles obj1, [In] int obj2, [In] int obj3)
    {
      obj0.reset();
      this.genTile(this.sector.__\u003C\u003Erect.project((float) obj2 / (float) obj1.__\u003C\u003Ewidth, (float) obj3 / (float) obj1.__\u003C\u003Eheight), obj0);
      Tiles tiles = obj1;
      int x = obj2;
      int y = obj3;
      Tile.__\u003Cclinit\u003E();
      Tile tile = new Tile(obj2, obj3, obj0.floor, obj0.overlay, obj0.block);
      tiles.set(x, y, tile);
    }

    [LineNumberTable(new byte[] {159, 153, 104, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public PlanetGenerator()
    {
      PlanetGenerator planetGenerator = this;
      this.ints = new IntSeq();
      this.noise = new Simplex();
    }

    [LineNumberTable(new byte[] {2, 117})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override float noise(
      float x,
      float y,
      double octaves,
      double falloff,
      double scl,
      double mag)
    {
      Vec3 vec3 = this.sector.__\u003C\u003Erect.project(x, y);
      return (float) this.noise.octaveNoise3D(octaves, falloff, 1.0 / scl, (double) vec3.x, (double) vec3.y, (double) vec3.z) * (float) mag;
    }

    [HideFromJava]
    public abstract float getHeight([In] Vec3 obj0);

    [HideFromJava]
    public abstract Color getColor([In] Vec3 obj0);

    [HideFromJava]
    static PlanetGenerator() => BasicGenerator.__\u003Cclinit\u003E();

    [SpecialName]
    private new sealed class __\u003C\u003EAnon0 : Intc2
    {
      private readonly PlanetGenerator arg\u00241;
      private readonly TileGen arg\u00242;
      private readonly Tiles arg\u00243;

      internal __\u003C\u003EAnon0([In] PlanetGenerator obj0, [In] TileGen obj1, [In] Tiles obj2)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
      }

      public void get([In] int obj0, [In] int obj1) => this.arg\u00241.lambda\u0024generate\u00240(this.arg\u00242, this.arg\u00243, obj0, obj1);
    }
  }
}
