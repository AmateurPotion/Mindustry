// Decompiled with JetBrains decompiler
// Type: mindustry.maps.planet.SerpuloPlanetGenerator
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.func;
using arc.graphics;
using arc.math;
using arc.math.geom;
using arc.util;
using arc.util.noise;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.util;
using mindustry.ai;
using mindustry.content;
using mindustry.ctype;
using mindustry.game;
using mindustry.graphics.g3d;
using mindustry.maps.generators;
using mindustry.type;
using mindustry.world;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.maps.planet
{
  public class SerpuloPlanetGenerator : PlanetGenerator
  {
    internal RidgedPerlin rid;
    internal BaseGenerator basegen;
    internal float scl;
    internal float waterOffset;
    internal Block[][] arr;
    [Signature("Larc/struct/ObjectMap<Lmindustry/world/Block;Lmindustry/world/Block;>;")]
    internal ObjectMap dec;
    [Signature("Larc/struct/ObjectMap<Lmindustry/world/Block;Lmindustry/world/Block;>;")]
    internal ObjectMap tars;
    internal float water;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 162, 104, 109, 107, 107, 139, 255, 165, 176, 81, 255, 50, 71, 255, 18, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public SerpuloPlanetGenerator()
    {
      SerpuloPlanetGenerator serpuloPlanetGenerator = this;
      this.rid = new RidgedPerlin(1, 2);
      this.basegen = new BaseGenerator();
      this.scl = 5f;
      this.waterOffset = 0.07f;
      this.arr = new Block[13][]
      {
        new Block[13]
        {
          Blocks.water,
          Blocks.darksandWater,
          Blocks.darksand,
          Blocks.darksand,
          Blocks.darksand,
          Blocks.darksand,
          Blocks.sand,
          Blocks.sand,
          Blocks.sand,
          Blocks.sand,
          Blocks.darksandTaintedWater,
          Blocks.stone,
          Blocks.stone
        },
        new Block[13]
        {
          Blocks.water,
          Blocks.darksandWater,
          Blocks.darksand,
          Blocks.darksand,
          Blocks.sand,
          Blocks.sand,
          Blocks.sand,
          Blocks.sand,
          Blocks.sand,
          Blocks.darksandTaintedWater,
          Blocks.stone,
          Blocks.stone,
          Blocks.stone
        },
        new Block[13]
        {
          Blocks.water,
          Blocks.darksandWater,
          Blocks.darksand,
          Blocks.sand,
          Blocks.salt,
          Blocks.sand,
          Blocks.sand,
          Blocks.sand,
          Blocks.sand,
          Blocks.darksandTaintedWater,
          Blocks.stone,
          Blocks.stone,
          Blocks.stone
        },
        new Block[13]
        {
          Blocks.water,
          Blocks.sandWater,
          Blocks.sand,
          Blocks.salt,
          Blocks.salt,
          Blocks.salt,
          Blocks.sand,
          Blocks.stone,
          Blocks.stone,
          Blocks.stone,
          Blocks.snow,
          Blocks.iceSnow,
          Blocks.ice
        },
        new Block[13]
        {
          Blocks.deepwater,
          Blocks.water,
          Blocks.sandWater,
          Blocks.sand,
          Blocks.salt,
          Blocks.sand,
          Blocks.sand,
          Blocks.basalt,
          Blocks.snow,
          Blocks.snow,
          Blocks.snow,
          Blocks.snow,
          Blocks.ice
        },
        new Block[13]
        {
          Blocks.deepwater,
          Blocks.water,
          Blocks.sandWater,
          Blocks.sand,
          Blocks.sand,
          Blocks.sand,
          Blocks.moss,
          Blocks.iceSnow,
          Blocks.snow,
          Blocks.snow,
          Blocks.ice,
          Blocks.snow,
          Blocks.ice
        },
        new Block[13]
        {
          Blocks.deepwater,
          Blocks.sandWater,
          Blocks.sand,
          Blocks.sand,
          Blocks.moss,
          Blocks.moss,
          Blocks.snow,
          Blocks.basalt,
          Blocks.basalt,
          Blocks.basalt,
          Blocks.ice,
          Blocks.snow,
          Blocks.ice
        },
        new Block[13]
        {
          Blocks.taintedWater,
          Blocks.darksandTaintedWater,
          Blocks.darksand,
          Blocks.darksand,
          Blocks.basalt,
          Blocks.moss,
          Blocks.basalt,
          Blocks.hotrock,
          Blocks.basalt,
          Blocks.ice,
          Blocks.snow,
          Blocks.ice,
          Blocks.ice
        },
        new Block[13]
        {
          Blocks.darksandWater,
          Blocks.darksand,
          Blocks.darksand,
          Blocks.darksand,
          Blocks.moss,
          Blocks.sporeMoss,
          Blocks.snow,
          Blocks.basalt,
          Blocks.basalt,
          Blocks.ice,
          Blocks.snow,
          Blocks.ice,
          Blocks.ice
        },
        new Block[13]
        {
          Blocks.darksandWater,
          Blocks.darksand,
          Blocks.darksand,
          Blocks.sporeMoss,
          Blocks.ice,
          Blocks.ice,
          Blocks.snow,
          Blocks.snow,
          Blocks.snow,
          Blocks.snow,
          Blocks.ice,
          Blocks.ice,
          Blocks.ice
        },
        new Block[13]
        {
          Blocks.taintedWater,
          Blocks.darksandTaintedWater,
          Blocks.darksand,
          Blocks.sporeMoss,
          Blocks.sporeMoss,
          Blocks.ice,
          Blocks.ice,
          Blocks.snow,
          Blocks.snow,
          Blocks.ice,
          Blocks.ice,
          Blocks.ice,
          Blocks.ice
        },
        new Block[13]
        {
          Blocks.darksandTaintedWater,
          Blocks.darksandTaintedWater,
          Blocks.darksand,
          Blocks.sporeMoss,
          Blocks.moss,
          Blocks.sporeMoss,
          Blocks.iceSnow,
          Blocks.snow,
          Blocks.ice,
          Blocks.ice,
          Blocks.ice,
          Blocks.ice,
          Blocks.ice
        },
        new Block[13]
        {
          Blocks.darksandWater,
          Blocks.darksand,
          Blocks.snow,
          Blocks.ice,
          Blocks.iceSnow,
          Blocks.snow,
          Blocks.snow,
          Blocks.snow,
          Blocks.ice,
          Blocks.ice,
          Blocks.ice,
          Blocks.ice,
          Blocks.ice
        }
      };
      this.dec = ObjectMap.of((object) Blocks.sporeMoss, (object) Blocks.sporeCluster, (object) Blocks.moss, (object) Blocks.sporeCluster, (object) Blocks.taintedWater, (object) Blocks.water, (object) Blocks.darksandTaintedWater, (object) Blocks.darksandWater);
      this.tars = ObjectMap.of((object) Blocks.sporeMoss, (object) Blocks.shale, (object) Blocks.moss, (object) Blocks.shale);
      this.water = 2f / (float) this.arr[0].Length;
    }

    [Modifiers]
    [LineNumberTable(20)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static Rand access\u0024000([In] SerpuloPlanetGenerator obj0) => obj0.rand;

    [Modifiers]
    [LineNumberTable(20)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static Rand access\u0024100([In] SerpuloPlanetGenerator obj0) => obj0.rand;

    [Modifiers]
    [LineNumberTable(20)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static float access\u0024200(
      [In] SerpuloPlanetGenerator obj0,
      [In] float obj1,
      [In] float obj2,
      [In] double obj3,
      [In] double obj4,
      [In] double obj5)
    {
      return obj0.noise(obj1, obj2, obj3, obj4, obj5);
    }

    [LineNumberTable(new byte[] {8, 120})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual float rawHeight([In] Vec3 obj0)
    {
      obj0 = Tmp.__\u003C\u003Ev33.set(obj0).scl(this.scl);
      return (Mathf.pow((float) this.noise.octaveNoise3D(7.0, 0.5, 0.333333343267441, (double) obj0.x, (double) obj0.y, (double) obj0.z), 2.3f) + this.waterOffset) / (1f + this.waterOffset);
    }

    [LineNumberTable(new byte[] {74, 105, 108, 120, 103, 125, 127, 38, 110, 105, 136, 159, 81, 127, 47, 105, 149})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual Block getBlock([In] Vec3 obj0)
    {
      float num1 = this.rawHeight(obj0);
      Tmp.__\u003C\u003Ev31.set(obj0);
      obj0 = Tmp.__\u003C\u003Ev33.set(obj0).scl(this.scl);
      float scl = this.scl;
      float num2 = Mathf.lerp(Mathf.clamp(Math.abs(obj0.y * 2f) / scl), (float) this.noise.octaveNoise3D(7.0, 0.56, 0.333333343267441, (double) obj0.x, (double) (obj0.y + 999f), (double) obj0.z), 0.5f);
      float num3 = Mathf.clamp(num1 * 1.2f);
      float num4 = (float) this.noise.octaveNoise3D(4.0, 0.550000011920929, 0.5, (double) obj0.x, (double) (obj0.y + 999f), (double) obj0.z) * 0.3f + Tmp.__\u003C\u003Ev31.dst(0.0f, 0.0f, 1f) * 0.2f;
      Block block = this.arr[Mathf.clamp(ByteCodeHelper.f2i(num2 * (float) this.arr.Length), 0, this.arr[0].Length - 1)][Mathf.clamp(ByteCodeHelper.f2i(num3 * (float) this.arr[0].Length), 0, this.arr[0].Length - 1)];
      return (double) num4 > 0.5 ? (Block) this.tars.get((object) block, (object) block) : block;
    }

    [LineNumberTable(new byte[] {96, 127, 0})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override float noise(
      float x,
      float y,
      double octaves,
      double falloff,
      double scl,
      double mag)
    {
      Vec3 vec3 = this.sector.__\u003C\u003Erect.project(x, y).scl(5f);
      return (float) this.noise.octaveNoise3D(octaves, falloff, 1.0 / scl, (double) vec3.x, (double) vec3.y, (double) vec3.z) * (float) mag;
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 163, 147, 106, 112, 109, 106, 127, 88, 121, 103, 226, 58, 233, 74, 127, 9, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024generate\u00240([In] Seq obj0, [In] FloatSeq obj1, [In] int obj2, [In] int obj3)
    {
      if (!this.floor.asFloor().hasSurface())
        return;
      int num1 = obj2 - 4;
      int num2 = obj3 + 23;
      for (int index = obj0.size - 1; index >= 0; index += -1)
      {
        Block block = (Block) obj0.get(index);
        float num3 = obj1.get(index);
        if ((double) Math.abs(0.5f - this.noise((float) num1, (float) (num2 + index * 999), 2.0, 0.7, (double) (40 + index * 2))) > 0.219999998807907 + (double) index * 0.01 && (double) Math.abs(0.5f - this.noise((float) num1, (float) (num2 - index * 999), 1.0, 1.0, (double) (30 + index * 4))) > (double) (0.37f + num3))
        {
          this.ore = block;
          break;
        }
      }
      if (!object.ReferenceEquals((object) this.ore, (object) Blocks.oreScrap) || !this.rand.chance(0.33))
        return;
      this.floor = Blocks.metalFloorDamaged;
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 189, 114, 127, 35, 235, 69, 117, 127, 74, 127, 10, 107, 235, 69, 117, 127, 35, 144, 107, 98, 119, 127, 0, 127, 11, 226, 61, 233, 70, 99, 139, 101, 127, 32, 127, 20, 127, 4, 105, 159, 23, 159, 6, 203, 153, 98, 99, 122, 127, 0, 119, 132, 227, 59, 232, 72, 127, 73, 255, 9, 70, 102, 127, 9, 119, 229, 61, 230, 71, 127, 27, 191, 13})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024generate\u00243([In] Seq obj0, [In] int obj1, [In] int obj2)
    {
      if (object.ReferenceEquals((object) this.floor, (object) Blocks.sporeMoss) && (double) Math.abs(0.5f - this.noise((float) (obj1 - 90), (float) obj2, 4.0, 0.8, 65.0)) > 0.02)
        this.floor = Blocks.moss;
      if (object.ReferenceEquals((object) this.floor, (object) Blocks.darksand) && (double) Math.abs(0.5f - this.noise((float) (obj1 - 40), (float) obj2, 2.0, 0.7, 80.0)) > 0.25 && ((double) Math.abs(0.5f - this.noise((float) obj1, (float) (obj2 + this.sector.__\u003C\u003Eid * 10), 1.0, 1.0, 60.0)) > 0.409999996423721 && !obj0.contains((Boolf) new SerpuloPlanetGenerator.__\u003C\u003EAnon5(obj1, obj2))))
      {
        this.floor = Blocks.tar;
        this.ore = Blocks.air;
      }
      if (object.ReferenceEquals((object) this.floor, (object) Blocks.hotrock))
      {
        if ((double) Math.abs(0.5f - this.noise((float) (obj1 - 90), (float) obj2, 4.0, 0.8, 80.0)) > 0.035)
        {
          this.floor = Blocks.basalt;
        }
        else
        {
          this.ore = Blocks.air;
          int num = 1;
          Point2[] d4 = Geometry.__\u003C\u003Ed4;
          int length = d4.Length;
          for (int index = 0; index < length; ++index)
          {
            Point2 point2 = d4[index];
            Tile tile = this.tiles.get(obj1 + point2.x, obj2 + point2.y);
            if (tile == null || !object.ReferenceEquals((object) tile.floor(), (object) Blocks.hotrock) && !object.ReferenceEquals((object) tile.floor(), (object) Blocks.magmarock))
              num = 0;
          }
          if (num != 0)
            this.floor = Blocks.magmarock;
        }
      }
      else if (!object.ReferenceEquals((object) this.floor, (object) Blocks.basalt) && !object.ReferenceEquals((object) this.floor, (object) Blocks.ice) && this.floor.asFloor().hasSurface())
      {
        float num = this.noise((float) (obj1 + 782), (float) obj2, 5.0, 0.75, 260.0, 1.0);
        if ((double) num > 0.670000016689301 && !obj0.contains((Boolf) new SerpuloPlanetGenerator.__\u003C\u003EAnon6(obj1, obj2)))
        {
          if ((double) num > 0.720000028610229)
            this.floor = (double) num <= 0.779999971389771 ? (!object.ReferenceEquals((object) this.floor, (object) Blocks.sand) ? Blocks.darksandTaintedWater : Blocks.sandWater) : Blocks.taintedWater;
          else
            this.floor = !object.ReferenceEquals((object) this.floor, (object) Blocks.sand) ? Blocks.darksand : this.floor;
          this.ore = Blocks.air;
        }
      }
      if (this.rand.chance(3.0 / 400.0))
      {
        int num1 = 0;
        int num2 = 1;
        Point2[] d4 = Geometry.__\u003C\u003Ed4;
        int length = d4.Length;
        for (int index = 0; index < length; ++index)
        {
          Point2 point2 = d4[index];
          Tile tile = this.tiles.get(obj1 + point2.x, obj2 + point2.y);
          if (tile != null && object.ReferenceEquals((object) tile.block(), (object) Blocks.air))
            num1 = 1;
          else
            num2 = 0;
        }
        if (num1 != 0 && (object.ReferenceEquals((object) this.block, (object) Blocks.snowWall) || object.ReferenceEquals((object) this.block, (object) Blocks.iceWall) || num2 != 0 && object.ReferenceEquals((object) this.block, (object) Blocks.air) && (object.ReferenceEquals((object) this.floor, (object) Blocks.snow) && this.rand.chance(0.03))))
          this.block = !this.rand.chance(0.5) ? Blocks.whiteTreeDead : Blocks.whiteTree;
      }
      for (int index = 0; index < 4; ++index)
      {
        Tile tile = Vars.world.tile(obj1 + Geometry.__\u003C\u003Ed4[index].x, obj2 + Geometry.__\u003C\u003Ed4[index].y);
        if (tile != null && !object.ReferenceEquals((object) tile.block(), (object) Blocks.air))
          return;
      }
      if (!this.rand.chance(0.01) || !this.floor.asFloor().hasSurface() || !object.ReferenceEquals((object) this.block, (object) Blocks.air))
        return;
      this.block = (Block) this.dec.get((object) this.floor, (object) this.floor.asFloor().decoration);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 55, 110, 112, 107, 105, 122, 127, 4, 127, 24, 236, 61, 43, 233, 73})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024generate\u00244([In] int obj0, [In] int obj1)
    {
      Tile tile1 = this.tiles.getn(obj0, obj1);
      if (!tile1.floor().hasSurface())
        return;
      tile1.setOverlay(Blocks.oreScrap);
      for (int index1 = 1; index1 <= 2; ++index1)
      {
        Point2[] d8 = Geometry.__\u003C\u003Ed8;
        int length = d8.Length;
        for (int index2 = 0; index2 < length; ++index2)
        {
          Point2 point2 = d8[index2];
          Tile tile2 = this.tiles.get(obj0 + point2.x * index1, obj1 + point2.y * index1);
          if (tile2 != null && tile2.floor().hasSurface() && this.rand.chance(index1 != 1 ? 0.2 : 0.4))
            tile2.setOverlay(Blocks.oreScrap);
        }
      }
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 72, 113, 150, 112, 118, 127, 2, 104, 118, 191, 23})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024generate\u00245([In] int obj0, [In] int obj1, [In] int obj2, [In] int obj3, [In] int obj4)
    {
      float num = Mathf.lerp(0.05f, 0.5f, Mathf.dst((float) obj3, (float) obj4, (float) obj0, (float) obj1) / (float) obj2);
      Tile tile = this.tiles.getn(obj3, obj4);
      if (tile.build == null || !tile.isCenter())
        return;
      if (object.ReferenceEquals((object) tile.team(), (object) Team.__\u003C\u003Ederelict) && this.rand.chance((double) num))
      {
        tile.remove();
      }
      else
      {
        if (!this.rand.chance(0.5))
          return;
        tile.build.health -= this.rand.random(tile.build.health * 0.9f);
      }
    }

    [Modifiers]
    [LineNumberTable(465)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Tile lambda\u0024generate\u00246([In] SerpuloPlanetGenerator.\u0031Room obj0) => this.tiles.getn(obj0.x, obj0.y);

    [Modifiers]
    [LineNumberTable(312)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024generate\u00241(
      [In] int obj0,
      [In] int obj1,
      [In] SerpuloPlanetGenerator.\u0031Room obj2)
    {
      return Mathf.within((float) obj0, (float) obj1, (float) obj2.x, (float) obj2.y, 15f);
    }

    [Modifiers]
    [LineNumberTable(337)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024generate\u00242(
      [In] int obj0,
      [In] int obj1,
      [In] SerpuloPlanetGenerator.\u0031Room obj2)
    {
      return Mathf.within((float) obj0, (float) obj1, (float) obj2.x, (float) obj2.y, 14f);
    }

    [LineNumberTable(new byte[] {16, 117, 103, 161, 135, 98, 114, 159, 19, 127, 10, 162, 112, 127, 1, 175, 255, 32, 69, 225, 55, 235, 78, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void generateSector(Sector sector)
    {
      if (sector.__\u003C\u003Eid == 154 || sector.__\u003C\u003Eid == 0)
      {
        sector.generateEnemyBase = true;
      }
      else
      {
        PlanetGrid.Ptile tile1 = sector.__\u003C\u003Etile;
        int num1 = 0;
        float num2 = Math.abs(tile1.v.y);
        float num3 = Noise.snoise3(tile1.v.x, tile1.v.y, tile1.v.z, 1f / 1000f, 0.58f);
        if ((double) num3 + (double) num2 / 7.1 > 0.12 && (double) num2 > 0.23)
          num1 = 1;
        if ((double) num3 < 0.16)
        {
          PlanetGrid.Ptile[] tiles = tile1.tiles;
          int length = tiles.Length;
          for (int index = 0; index < length; ++index)
          {
            PlanetGrid.Ptile tile2 = tiles[index];
            Sector sector1 = sector.__\u003C\u003Eplanet.getSector(tile2);
            if (sector1.__\u003C\u003Eid == sector.__\u003C\u003Eplanet.startSector || sector1.generateEnemyBase && (double) num2 < 0.85 || sector.preset != null && (double) num3 < 0.11)
              return;
          }
        }
        sector.generateEnemyBase = num1 != 0;
      }
    }

    [LineNumberTable(new byte[] {51, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override float getHeight(Vec3 position) => Math.max(this.rawHeight(position), this.water);

    [LineNumberTable(new byte[] {57, 136, 120})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override Color getColor(Vec3 position)
    {
      Block block = this.getBlock(position);
      return object.ReferenceEquals((object) block, (object) Blocks.salt) ? Blocks.sand.mapColor : Tmp.__\u003C\u003Ec1.set(block.mapColor).a(1f - block.albedo);
    }

    [LineNumberTable(new byte[] {65, 109, 150, 127, 19, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void genTile(Vec3 position, TileGen tile)
    {
      tile.floor = this.getBlock(position);
      tile.block = tile.floor.asFloor().wall;
      if ((double) this.rid.getValue((double) position.x, (double) position.y, (double) position.z, 22f) <= 0.32)
        return;
      tile.block = Blocks.air;
    }

    [LineNumberTable(new byte[] {124, 103, 144, 102, 118, 110, 134, 107, 127, 13, 124, 124, 112, 127, 8, 255, 2, 58, 235, 74, 99, 103, 127, 12, 114, 127, 3, 99, 99, 111, 103, 125, 157, 163, 107, 107, 119, 114, 230, 61, 40, 235, 73, 116, 159, 2, 108, 115, 127, 41, 127, 21, 104, 233, 59, 235, 72, 226, 36, 236, 96, 127, 0, 123, 130, 121, 105, 63, 8, 200, 127, 0, 105, 130, 103, 144, 159, 0, 125, 125, 103, 103, 135, 127, 90, 172, 127, 97, 172, 127, 97, 172, 118, 172, 103, 110, 63, 21, 200, 245, 83, 134, 135, 134, 242, 160, 78, 109, 107, 155, 112, 104, 164, 116, 113, 113, 127, 1, 242, 61, 40, 235, 73, 145, 99, 135, 126, 112, 178, 127, 3, 165, 148, 113, 99, 110, 127, 5, 127, 5, 127, 7, 118, 216, 255, 5, 78, 134, 127, 4, 255, 19, 25, 235, 120, 147, 127, 1, 127, 4, 130, 112, 159, 52, 159, 13, 191, 40, 135, 127, 24, 127, 11, 148, 127, 11})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void generate()
    {
      this.cells(4);
      this.distort(10f, 12f);
      float num1 = 1.3f;
      float num2 = (float) this.width / 2f / Mathf.__\u003C\u003Esqrt3;
      int num3 = this.rand.random(2, 5);
      Seq seq1 = new Seq();
      for (int index = 0; index < num3; ++index)
      {
        Tmp.__\u003C\u003Ev1.trns(this.rand.random(360f), this.rand.random(num2 / num1));
        float num4 = (float) this.width / 2f + Tmp.__\u003C\u003Ev1.x;
        float num5 = (float) this.height / 2f + Tmp.__\u003C\u003Ev1.y;
        float num6 = Math.min(this.rand.random(9f, (num2 - Tmp.__\u003C\u003Ev1.len()) / 2f), 30f);
        seq1.add((object) new SerpuloPlanetGenerator.\u0031Room(this, ByteCodeHelper.f2i(num4), ByteCodeHelper.f2i(num5), ByteCodeHelper.f2i(num6)));
      }
      SerpuloPlanetGenerator.\u0031Room obj1 = (SerpuloPlanetGenerator.\u0031Room) null;
      Seq seq2 = new Seq();
      int num7 = this.rand.random(1, Math.max(ByteCodeHelper.f2i(this.sector.threat * 4f), 1));
      int num8 = this.rand.nextInt(360);
      float len = (float) this.width / 2.55f - (float) this.rand.random(13, 23);
      int num9 = 5;
      int num10 = 5;
      for (int index1 = 0; index1 < 360; index1 += num9)
      {
        int num4 = num8 + index1;
        int num5 = ByteCodeHelper.f2i((float) (this.width / 2) + Angles.trnsx((float) num4, len));
        int num6 = ByteCodeHelper.f2i((float) (this.height / 2) + Angles.trnsy((float) num4, len));
        int num11 = 0;
        for (int index2 = -num10; index2 <= num10; ++index2)
        {
          for (int index3 = -num10; index3 <= num10; ++index3)
          {
            Tile tile = this.tiles.get(num5 + index2, num6 + index3);
            if (tile == null || tile.floor().liquidDrop != null)
              ++num11;
          }
        }
        if (num11 <= 4 || index1 + num9 >= 360)
        {
          seq1.add((object) (obj1 = new SerpuloPlanetGenerator.\u0031Room(this, num5, num6, this.rand.random(8, 15))));
          for (int index2 = 0; index2 < num7; ++index2)
          {
            float num12 = this.rand.range(60f);
            Tmp.__\u003C\u003Ev1.set((float) (num5 - this.width / 2), (float) (num6 - this.height / 2)).rotate(180f + num12).add((float) (this.width / 2), (float) (this.height / 2));
            SerpuloPlanetGenerator.\u0031Room obj2 = new SerpuloPlanetGenerator.\u0031Room(this, ByteCodeHelper.f2i(Tmp.__\u003C\u003Ev1.x), ByteCodeHelper.f2i(Tmp.__\u003C\u003Ev1.y), this.rand.random(8, 15));
            seq1.add((object) obj2);
            seq2.add((object) obj2);
          }
          break;
        }
      }
      Iterator iterator1 = seq1.iterator();
      while (iterator1.hasNext())
      {
        SerpuloPlanetGenerator.\u0031Room obj2 = (SerpuloPlanetGenerator.\u0031Room) iterator1.next();
        this.erase(obj2.x, obj2.y, obj2.radius);
      }
      int num13 = this.rand.random(Math.max(num3 - 1, 1), num3 + 3);
      for (int index = 0; index < num13; ++index)
        ((SerpuloPlanetGenerator.\u0031Room) seq1.random(this.rand)).connect((SerpuloPlanetGenerator.\u0031Room) seq1.random(this.rand));
      Iterator iterator2 = seq1.iterator();
      while (iterator2.hasNext())
      {
        SerpuloPlanetGenerator.\u0031Room obj2 = (SerpuloPlanetGenerator.\u0031Room) iterator2.next();
        obj1.connect(obj2);
      }
      this.cells(1);
      this.distort(10f, 6f);
      this.inverseFloodFill(this.tiles.getn(obj1.x, obj1.y));
      Seq seq3 = Seq.with((object[]) new Block[2]
      {
        Blocks.oreCopper,
        Blocks.oreLead
      });
      float num14 = Math.abs(this.sector.__\u003C\u003Etile.v.y);
      float num15 = 0.5f;
      float num16 = 1f;
      float num17 = 1.3f;
      if (this.noise.octaveNoise3D(2.0, 0.5, (double) num16, (double) this.sector.__\u003C\u003Etile.v.x, (double) this.sector.__\u003C\u003Etile.v.y, (double) this.sector.__\u003C\u003Etile.v.z) * (double) num15 + (double) num14 > (double) (0.25f * num17))
        seq3.add((object) Blocks.oreCoal);
      if (this.noise.octaveNoise3D(2.0, 0.5, (double) num16, (double) (this.sector.__\u003C\u003Etile.v.x + 1f), (double) this.sector.__\u003C\u003Etile.v.y, (double) this.sector.__\u003C\u003Etile.v.z) * (double) num15 + (double) num14 > (double) (0.5f * num17))
        seq3.add((object) Blocks.oreTitanium);
      if (this.noise.octaveNoise3D(2.0, 0.5, (double) num16, (double) (this.sector.__\u003C\u003Etile.v.x + 2f), (double) this.sector.__\u003C\u003Etile.v.y, (double) this.sector.__\u003C\u003Etile.v.z) * (double) num15 + (double) num14 > (double) (0.7f * num17))
        seq3.add((object) Blocks.oreThorium);
      if (this.rand.chance(0.25))
        seq3.add((object) Blocks.oreScrap);
      FloatSeq floatSeq = new FloatSeq();
      for (int index = 0; index < seq3.size; ++index)
        floatSeq.add(this.rand.random(-0.1f, 0.01f) - (float) index * 0.01f + num14 * 0.04f);
      this.pass((Intc2) new SerpuloPlanetGenerator.__\u003C\u003EAnon0(this, seq3, floatSeq));
      this.trimDark();
      this.median(2);
      this.tech();
      this.pass((Intc2) new SerpuloPlanetGenerator.__\u003C\u003EAnon1(this, seq1));
      float threat = this.sector.threat;
      this.ints.clear();
      this.ints.ensureCapacity(this.width * this.height / 4);
      int num18 = this.rand.random(-2, 4);
      if (num18 > 0)
      {
        int num4 = 25;
        for (int x = num4; x < this.width - num4; ++x)
        {
          for (int y = num4; y < this.height - num4; ++y)
          {
            Tile tile = this.tiles.getn(x, y);
            if (!tile.solid() && (tile.drop() != null || tile.floor().liquidDrop != null))
              this.ints.add(tile.pos());
          }
        }
        this.ints.shuffle(this.rand);
        int num5 = 0;
        float max = 0.4f;
        for (int index1 = 0; index1 < this.ints.size && num5 < num18; ++index1)
        {
          int pos = this.ints.items[index1];
          int x = (int) Point2.x(pos);
          int y = (int) Point2.y(pos);
          if (!Mathf.within((float) x, (float) y, (float) obj1.x, (float) obj1.y, 18f))
          {
            float index2 = threat + this.rand.random(max);
            Tile tile = this.tiles.getn(x, y);
            BaseRegistry.BasePart part = (BaseRegistry.BasePart) null;
            if (tile.overlay().itemDrop != null)
              part = (BaseRegistry.BasePart) Vars.bases.forResource((Content) tile.drop()).getFrac(index2);
            else if (tile.floor().liquidDrop != null && this.rand.chance(0.05))
              part = (BaseRegistry.BasePart) Vars.bases.forResource((Content) tile.floor().liquidDrop).getFrac(index2);
            else if (this.rand.chance(0.05))
              part = (BaseRegistry.BasePart) Vars.bases.parts.getFrac(index2);
            if (part != null && BaseGenerator.tryPlace(part, x, y, Team.__\u003C\u003Ederelict, (Intc2) new SerpuloPlanetGenerator.__\u003C\u003EAnon2(this)))
            {
              ++num5;
              int radius = Math.max(part.__\u003C\u003Eschematic.width, part.__\u003C\u003Eschematic.height) / 2 + 3;
              Geometry.circle(x, y, this.tiles.__\u003C\u003Ewidth, this.tiles.__\u003C\u003Eheight, radius, (Intc2) new SerpuloPlanetGenerator.__\u003C\u003EAnon3(this, x, y, radius));
            }
          }
        }
      }
      Schematics.placeLaunchLoadout(obj1.x, obj1.y);
      Iterator iterator3 = seq2.iterator();
      while (iterator3.hasNext())
      {
        SerpuloPlanetGenerator.\u0031Room obj2 = (SerpuloPlanetGenerator.\u0031Room) iterator3.next();
        this.tiles.getn(obj2.x, obj2.y).setOverlay(Blocks.spawn);
      }
      if (this.sector.hasEnemyBase())
      {
        this.basegen.generate(this.tiles, seq2.map((Func) new SerpuloPlanetGenerator.__\u003C\u003EAnon4(this)), this.tiles.get(obj1.x, obj1.y), Vars.state.rules.waveTeam, this.sector, threat);
        Rules rules = Vars.state.rules;
        SectorInfo info = this.sector.info;
        int num4 = 1;
        SectorInfo sectorInfo = info;
        int num5 = num4;
        sectorInfo.attack = num4 != 0;
        rules.attackMode = num5 != 0;
      }
      else
      {
        Rules rules = Vars.state.rules;
        SectorInfo info = this.sector.info;
        int num4 = 10 + 5 * ByteCodeHelper.f2i(Math.max(threat * 10f, 1f));
        SectorInfo sectorInfo = info;
        int num5 = num4;
        sectorInfo.winWave = num4;
        rules.winWave = num5;
      }
      float num19 = 0.4f;
      Vars.state.rules.waveSpacing = Mathf.lerp(7800f, 3600f, Math.max(threat - num19, 0.0f) / 0.8f);
      Rules rules1 = Vars.state.rules;
      SectorInfo info1 = this.sector.info;
      int num20 = 1;
      SectorInfo sectorInfo1 = info1;
      int num21 = num20;
      sectorInfo1.waves = num20 != 0;
      rules1.waves = num21 != 0;
      Vars.state.rules.enemyCoreBuildRadius = 600f;
      Vars.state.rules.spawns = Waves.generate(threat, new Rand(), Vars.state.rules.attackMode);
    }

    [LineNumberTable(new byte[] {161, 113, 109, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void postGenerate(Tiles tiles)
    {
      if (!this.sector.hasEnemyBase())
        return;
      this.basegen.postGenerate();
    }

    [HideFromJava]
    static SerpuloPlanetGenerator() => PlanetGenerator.__\u003Cclinit\u003E();

    [EnclosingMethod(null, "generate", "()V")]
    [SpecialName]
    internal class \u0031Room : Object
    {
      internal int x;
      internal int y;
      internal int radius;
      [Signature("Larc/struct/ObjectSet<Lmindustry/maps/planet/SerpuloPlanetGenerator$1Room;>;")]
      internal ObjectSet connected;
      [Modifiers]
      internal SerpuloPlanetGenerator this\u00240;

      [Modifiers]
      [LineNumberTable(170)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private float lambda\u0024connect\u00240([In] float obj0, [In] Tile obj1) => (!obj1.solid() ? 0.0f : 5f) + SerpuloPlanetGenerator.access\u0024200(this.this\u00240, (float) obj1.x, (float) obj1.y, 1.0, 1.0, (double) (1f / obj0)) * 60f;

      [LineNumberTable(new byte[] {107, 15, 171, 103, 103, 104, 109})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0031Room([In] SerpuloPlanetGenerator obj0, [In] int obj1, [In] int obj2, [In] int obj3)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector();
        SerpuloPlanetGenerator.\u0031Room obj = this;
        this.connected = new ObjectSet();
        this.x = obj1;
        this.y = obj2;
        this.radius = obj3;
        this.connected.add((object) this);
      }

      [LineNumberTable(new byte[] {115, 143, 109, 124, 116, 127, 33})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal virtual void connect([In] SerpuloPlanetGenerator.\u0031Room obj0)
      {
        if (this.connected.contains((object) obj0))
          return;
        this.connected.add((object) obj0);
        float num = SerpuloPlanetGenerator.access\u0024000(this.this\u00240).random(20f, 60f);
        int rad = SerpuloPlanetGenerator.access\u0024100(this.this\u00240).random(4, 12);
        this.this\u00240.brush(this.this\u00240.pathfind(this.x, this.y, obj0.x, obj0.y, (Astar.TileHueristic) new SerpuloPlanetGenerator.\u0031Room.__\u003C\u003EAnon0(this, num), Astar.__\u003C\u003Emanhattan), rad);
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon0 : Astar.TileHueristic
      {
        private readonly SerpuloPlanetGenerator.\u0031Room arg\u00241;
        private readonly float arg\u00242;

        internal __\u003C\u003EAnon0([In] SerpuloPlanetGenerator.\u0031Room obj0, [In] float obj1)
        {
          this.arg\u00241 = obj0;
          this.arg\u00242 = obj1;
        }

        public float cost([In] Tile obj0) => this.arg\u00241.lambda\u0024connect\u00240(this.arg\u00242, obj0);

        [SpecialName]
        public float cost([In] Tile obj0, [In] Tile obj1) => Astar.TileHueristic.\u003Cdefault\u003Ecost((Astar.TileHueristic) this, obj0, obj1);
      }
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon0 : Intc2
    {
      private readonly SerpuloPlanetGenerator arg\u00241;
      private readonly Seq arg\u00242;
      private readonly FloatSeq arg\u00243;

      internal __\u003C\u003EAnon0([In] SerpuloPlanetGenerator obj0, [In] Seq obj1, [In] FloatSeq obj2)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
      }

      public void get([In] int obj0, [In] int obj1) => this.arg\u00241.lambda\u0024generate\u00240(this.arg\u00242, this.arg\u00243, obj0, obj1);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon1 : Intc2
    {
      private readonly SerpuloPlanetGenerator arg\u00241;
      private readonly Seq arg\u00242;

      internal __\u003C\u003EAnon1([In] SerpuloPlanetGenerator obj0, [In] Seq obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] int obj0, [In] int obj1) => this.arg\u00241.lambda\u0024generate\u00243(this.arg\u00242, obj0, obj1);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon2 : Intc2
    {
      private readonly SerpuloPlanetGenerator arg\u00241;

      internal __\u003C\u003EAnon2([In] SerpuloPlanetGenerator obj0) => this.arg\u00241 = obj0;

      public void get([In] int obj0, [In] int obj1) => this.arg\u00241.lambda\u0024generate\u00244(obj0, obj1);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon3 : Intc2
    {
      private readonly SerpuloPlanetGenerator arg\u00241;
      private readonly int arg\u00242;
      private readonly int arg\u00243;
      private readonly int arg\u00244;

      internal __\u003C\u003EAnon3([In] SerpuloPlanetGenerator obj0, [In] int obj1, [In] int obj2, [In] int obj3)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
        this.arg\u00244 = obj3;
      }

      public void get([In] int obj0, [In] int obj1) => this.arg\u00241.lambda\u0024generate\u00245(this.arg\u00242, this.arg\u00243, this.arg\u00244, obj0, obj1);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon4 : Func
    {
      private readonly SerpuloPlanetGenerator arg\u00241;

      internal __\u003C\u003EAnon4([In] SerpuloPlanetGenerator obj0) => this.arg\u00241 = obj0;

      public object get([In] object obj0) => (object) this.arg\u00241.lambda\u0024generate\u00246((SerpuloPlanetGenerator.\u0031Room) obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon5 : Boolf
    {
      private readonly int arg\u00241;
      private readonly int arg\u00242;

      internal __\u003C\u003EAnon5([In] int obj0, [In] int obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public bool get([In] object obj0) => (SerpuloPlanetGenerator.lambda\u0024generate\u00241(this.arg\u00241, this.arg\u00242, (SerpuloPlanetGenerator.\u0031Room) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon6 : Boolf
    {
      private readonly int arg\u00241;
      private readonly int arg\u00242;

      internal __\u003C\u003EAnon6([In] int obj0, [In] int obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public bool get([In] object obj0) => (SerpuloPlanetGenerator.lambda\u0024generate\u00242(this.arg\u00241, this.arg\u00242, (SerpuloPlanetGenerator.\u0031Room) obj0) ? 1 : 0) != 0;
    }
  }
}
