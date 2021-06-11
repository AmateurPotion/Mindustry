// Decompiled with JetBrains decompiler
// Type: mindustry.maps.SectorDamage
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
using mindustry.entities;
using mindustry.entities.abilities;
using mindustry.game;
using mindustry.gen;
using mindustry.logic;
using mindustry.type;
using mindustry.world;
using mindustry.world.blocks.defense;
using mindustry.world.blocks.defense.turrets;
using mindustry.world.blocks.storage;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.maps
{
  public class SectorDamage : Object
  {
    public const int maxRetWave = 40;
    public const int maxWavesSimulated = 50;
    private const bool rubble = true;

    [LineNumberTable(new byte[] {161, 8, 139, 102, 191, 16, 127, 3, 127, 31, 104, 155, 133, 118, 114, 159, 3, 127, 5, 135, 163, 255, 7, 79, 104, 167, 127, 4, 144, 110, 110, 120, 127, 38, 176, 127, 30, 127, 13, 223, 10, 146, 142, 111, 226, 47, 43, 235, 61, 235, 93, 127, 1, 117, 104, 140, 98, 197, 105, 127, 24, 108, 162, 127, 0, 131, 140, 107, 111, 109, 152, 107, 191, 5, 126, 108, 164, 127, 13, 147, 150, 191, 18, 150, 127, 13, 191, 10, 109, 137, 179, 114, 162, 117, 104, 234, 29, 235, 103, 165})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void apply(float fraction)
    {
      Tiles tiles = Vars.world.tiles;
      Queue queue = new Queue();
      int width = tiles.__\u003C\u003Ewidth;
      int height = tiles.__\u003C\u003Eheight;
      int[] numArray1 = new int[2];
      int num1 = height;
      numArray1[1] = num1;
      int num2 = width;
      numArray1[0] = num2;
      // ISSUE: type reference
      float[][] numArray2 = (float[][]) ByteCodeHelper.multianewarray(__typeref (float[][]), numArray1);
      Iterator iterator1 = tiles.iterator();
      while (iterator1.hasNext())
      {
        Tile tile = (Tile) iterator1.next();
        if (tile.block() is CoreBlock && object.ReferenceEquals((object) tile.team(), (object) Vars.state.rules.waveTeam) || object.ReferenceEquals((object) tile.overlay(), (object) Blocks.spawn))
        {
          queue.add((object) tile);
          numArray2[(int) tile.x][(int) tile.y] = fraction * 24f;
        }
      }
      CoreBlock.CoreBuild coreBuild = Vars.state.rules.defaultTeam.core();
      if (coreBuild != null && !queue.isEmpty())
      {
        Iterator iterator2 = queue.iterator();
label_6:
        while (iterator2.hasNext())
        {
          Seq seq1 = Astar.pathfind((Tile) iterator2.next(), coreBuild.tile, (Astar.TileHueristic) new SectorDamage.__\u003C\u003EAnon3(), (Boolf) new SectorDamage.__\u003C\u003EAnon7());
          Seq seq2 = new Seq();
          int num3 = 3;
          float num4 = ((double) fraction < 1.0 ? seq1.sumf((Floatf) new SectorDamage.__\u003C\u003EAnon8(num3)) : 1f) * fraction;
          float num5 = 0.0f;
          for (int index1 = 0; index1 < seq1.size && ((double) num5 < (double) num4 || (double) fraction >= 1.0); ++index1)
          {
            Tile tile1 = (Tile) seq1.get(index1);
            for (int index2 = -num3; index2 <= num3; ++index2)
            {
              for (int index3 = -num3; index3 <= num3; ++index3)
              {
                int x = index2 + (int) tile1.x;
                int y = index3 + (int) tile1.y;
                if (x >= 0 && y >= 0 && (x < Vars.world.width() && y < Vars.world.height()) && Mathf.within((float) index2, (float) index3, (float) num3))
                {
                  Tile tile2 = Vars.world.rawTile(x, y);
                  if (tile2.build != null && object.ReferenceEquals((object) tile2.team(), (object) Vars.state.rules.defaultTeam) && !(tile2.block() is CoreBlock))
                  {
                    if (!tile2.floor().solid && !tile2.floor().isLiquid && Mathf.chance(0.4))
                      Effect.rubble(tile2.build.x, tile2.build.y, tile2.block().size);
                    num5 += tile2.build.health;
                    seq2.add((object) tile2.build);
                    if ((double) num5 >= (double) num4 && (double) fraction < 0.999000012874603)
                      goto label_21;
                  }
                }
              }
            }
          }
label_21:
          Iterator iterator3 = seq2.iterator();
          while (true)
          {
            Building building;
            do
            {
              if (iterator3.hasNext())
                building = (Building) iterator3.next();
              else
                goto label_6;
            }
            while (!object.ReferenceEquals((object) building.tile.build, (object) building));
            building.addPlan(false);
            building.tile.remove();
          }
        }
      }
      if ((double) fraction >= 1.0)
      {
        Iterator iterator2 = Vars.state.rules.defaultTeam.cores().copy().iterator();
        while (iterator2.hasNext())
          ((Building) iterator2.next()).tile.remove();
      }
      float num6 = fraction / ((float) Math.max(tiles.__\u003C\u003Ewidth, tiles.__\u003C\u003Eheight) * Mathf.__\u003C\u003Esqrt2);
      int num7 = 0;
      if ((double) fraction <= 0.150000005960464)
        return;
label_30:
      while (!queue.isEmpty())
      {
        num7 = Math.max(num7, queue.size);
        Tile tile1 = (Tile) queue.removeFirst();
        float num3 = numArray2[(int) tile1.x][(int) tile1.y] - num6;
        int index = 0;
        while (true)
        {
          if (index < 4)
          {
            int x = (int) tile1.x + Geometry.__\u003C\u003Ed4x[index];
            int y = (int) tile1.y + Geometry.__\u003C\u003Ed4y[index];
            if (tiles.@in(x, y) && (double) numArray2[x][y] < (double) num3)
            {
              Tile tile2 = tiles.getn(x, y);
              float num4 = num3;
              if (tile2.build != null && !object.ReferenceEquals((object) tile2.team(), (object) Vars.state.rules.waveTeam))
              {
                num4 -= tile2.build.health();
                tile2.build.health -= num3;
                if (tile2.block() is CoreBlock)
                  tile2.build.health = Math.max(tile2.build.health, 1f);
                if ((double) tile2.build.health < 0.0)
                {
                  if (!tile2.floor().solid && !tile2.floor().isLiquid && Mathf.chance(0.4))
                    Effect.rubble(tile2.build.x, tile2.build.y, tile2.block().size);
                  tile2.build.addPlan(false);
                  tile2.remove();
                }
                else
                  Vars.indexer.notifyTileDamaged(tile2.build);
              }
              else if (tile2.solid() && !tile2.synthetic())
                goto label_46;
              if ((double) num4 > 0.0 && (double) numArray2[x][y] < (double) num4)
              {
                queue.addLast((object) tile2);
                numArray2[x][y] = num4;
              }
            }
label_46:
            ++index;
          }
          else
            goto label_30;
        }
      }
    }

    [LineNumberTable(new byte[] {71, 187, 141, 171, 102, 102, 103, 127, 7, 127, 30, 104, 141, 133, 178, 167, 127, 0, 107, 103, 143, 113, 130, 162, 156, 127, 9, 255, 13, 73, 194, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void applyCalculatedDamage()
    {
      float damage = SectorDamage.getDamage(Vars.state.rules.sector.info);
      float fraction = Mathf.pow(damage, 1.2f);
      Tile firstSpawn = Vars.spawner.getFirstSpawn();
      if (firstSpawn != null)
      {
        Seq seq = new Seq();
        float num1 = 0.0f;
        Iterator iterator1 = Groups.unit.iterator();
        while (iterator1.hasNext())
        {
          Unit unit = (Unit) iterator1.next();
          if (object.ReferenceEquals((object) unit.team, (object) Vars.state.rules.defaultTeam) && unit.within((Position) firstSpawn, Vars.state.rules.dropZoneRadius * 2.5f))
          {
            seq.add((object) unit);
            num1 += unit.health;
          }
        }
        seq.sort((Floatf) new SectorDamage.__\u003C\u003EAnon0(firstSpawn));
        float num2 = damage * num1;
        Iterator iterator2 = seq.iterator();
        while (iterator2.hasNext())
        {
          Unit unit = (Unit) iterator2.next();
          if ((double) unit.health < (double) num2)
          {
            unit.remove();
            num2 -= unit.health;
          }
          else
          {
            unit.health -= num2;
            break;
          }
        }
      }
      if (Vars.state.rules.sector.info.wavesPassed > 0)
      {
        Iterator iterator = Vars.spawner.getSpawns().iterator();
        while (iterator.hasNext())
          ((Tile) iterator.next()).circle(ByteCodeHelper.f2i(Vars.state.rules.dropZoneRadius / 8f), (Cons) new SectorDamage.__\u003C\u003EAnon1());
      }
      SectorDamage.apply(fraction);
    }

    [LineNumberTable(new byte[] {127, 117, 102, 149, 126, 191, 0, 140, 140, 101, 124, 103, 131, 113, 104, 99, 99, 124, 103, 114, 127, 0, 152, 112, 123, 106, 228, 58, 235, 74, 137, 111, 99, 162, 102, 165, 100, 223, 3, 102, 123, 155, 113, 112, 149, 112, 245, 59, 235, 75, 117, 231, 69, 99, 135, 191, 4, 110, 110, 120, 127, 19, 144, 159, 29, 127, 15, 255, 8, 56, 43, 235, 78, 133, 181, 127, 7, 106, 108, 127, 70, 127, 63, 191, 18, 127, 11, 191, 13, 127, 11, 113, 200, 133, 174, 159, 7, 171, 157, 127, 1, 122, 114, 127, 26, 191, 3, 119, 127, 1, 159, 9, 165, 103, 99, 142, 127, 1, 142, 127, 17, 127, 3, 121, 139, 115, 100, 133, 106, 127, 17, 127, 1, 101, 113, 241, 47, 235, 84, 103, 135, 127, 1, 109, 136, 104, 127, 8, 127, 54, 226, 57, 235, 77, 105, 109, 141, 105, 109, 141, 111, 104, 136, 135, 108, 140, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void writeParameters(SectorInfo info)
    {
      CoreBlock.CoreBuild coreBuild = Vars.state.rules.defaultTeam.core();
      Seq seq1 = new Seq();
      Vars.spawner.eachGroundSpawn((Intc2) new SectorDamage.__\u003C\u003EAnon2(seq1));
      if (seq1.isEmpty() && Vars.state.rules.waveTeam.core() != null)
        seq1.add((object) Vars.state.rules.waveTeam.core().tile);
      if (coreBuild == null || seq1.isEmpty())
        return;
      Tile from = (Tile) seq1.first();
      Time.mark();
      Pathfinder.Flowfield field = Vars.pathfinder.getField(Vars.state.rules.waveTeam, 0, 0);
      Seq seq2 = new Seq();
      int num1 = 0;
      if (field != null && field.weights != null)
      {
        int[][] weights = field.weights;
        int num2 = 0;
        Tile tile1 = from;
        for (; num2 < Vars.world.width() * Vars.world.height(); ++num2)
        {
          int maxValue = int.MaxValue;
          int x1 = (int) tile1.x;
          int y1 = (int) tile1.y;
          Point2[] d4 = Geometry.__\u003C\u003Ed4;
          int length = d4.Length;
          for (int index = 0; index < length; ++index)
          {
            Point2 point2 = d4[index];
            int x2 = x1 + point2.x;
            int y2 = y1 + point2.y;
            Tile tile2 = Vars.world.tile(x2, y2);
            if (tile2 != null && weights[x2][y2] < maxValue && weights[x2][y2] != -1)
            {
              maxValue = weights[x2][y2];
              tile1 = tile2;
            }
          }
          seq2.add((object) tile1);
          if (object.ReferenceEquals((object) tile1.build, (object) coreBuild))
          {
            num1 = 1;
            break;
          }
        }
      }
      if (num1 == 0)
        seq2 = Astar.pathfind(from, coreBuild.tile, (Astar.TileHueristic) new SectorDamage.__\u003C\u003EAnon3(), (Boolf) new SectorDamage.__\u003C\u003EAnon4());
      int num3 = 5;
      int num4 = 3;
      int size1 = seq2.size;
      int num5 = num3;
      Seq seq3 = new Seq((num5 != -1 ? size1 / num5 : -size1) + 1);
      int size2 = seq2.size;
      int num6 = num4;
      Seq seq4 = new Seq((num6 != -1 ? size2 / num6 : -size2) + 1);
      for (int index = 0; index < seq2.size; ++index)
      {
        int num2 = index;
        int num7 = num3;
        if ((num7 != -1 ? num2 % num7 : 0) == 0)
          seq3.add((object) (Tile) seq2.get(index));
        int num8 = index;
        int num9 = num4;
        if ((num9 != -1 ? num8 % num9 : 0) == 0)
          seq4.add((object) (Tile) seq2.get(index));
      }
      float num10 = 0.0f;
      float num11 = 0.0f;
      float num12 = 0.0f;
      float num13 = 0.0f;
      int num14 = 5;
      IntSet intSet = new IntSet();
      Iterator iterator1 = seq4.iterator();
label_24:
      while (iterator1.hasNext())
      {
        Tile tile1 = (Tile) iterator1.next();
        int num2 = -num14;
        while (true)
        {
          if (num2 <= num14)
          {
            for (int index = -num14; index <= num14; ++index)
            {
              int x = num2 + (int) tile1.x;
              int y = index + (int) tile1.y;
              if (x >= 0 && y >= 0 && (x < Vars.world.width() && y < Vars.world.height()))
              {
                Tile tile2 = Vars.world.rawTile(x, y);
                if (tile2.build != null && object.ReferenceEquals((object) tile2.team(), (object) Vars.state.rules.defaultTeam) && intSet.add(tile2.pos()))
                {
                  num10 += tile2.build.health / (float) (tile2.block().size * tile2.block().size);
                  num13 += 1f / (float) (tile2.block().size * tile2.block().size);
                }
              }
            }
            ++num2;
          }
          else
            goto label_24;
        }
      }
      float num15 = (double) num13 > 1.0 ? num10 / num13 : num10;
      Iterator iterator2 = Groups.build.iterator();
      while (iterator2.hasNext())
      {
        Building building1 = (Building) iterator2.next();
        float num2 = building1.efficiency();
        if ((double) num2 > 0.0799999982118607 && object.ReferenceEquals((object) building1.team, (object) Vars.state.rules.defaultTeam))
        {
          Building building2 = building1;
          Ranged ranged;
          if (building2 is Ranged && object.ReferenceEquals((object) (ranged = (Ranged) building2), (object) (Ranged) building2) && seq3.contains((Boolf) new SectorDamage.__\u003C\u003EAnon5(building1, ranged)))
          {
            Block block1 = building1.block;
            Turret turret;
            if (block1 is Turret && object.ReferenceEquals((object) (turret = (Turret) block1), (object) (Turret) block1))
            {
              Building building3 = building1;
              Turret.TurretBuild turretBuild;
              if (building3 is Turret.TurretBuild && object.ReferenceEquals((object) (turretBuild = (Turret.TurretBuild) building3), (object) (Turret.TurretBuild) building3) && turretBuild.hasAmmo())
                num12 += (float) turret.shots / turret.reloadTime * 60f * turretBuild.peekAmmo().estimateDPS() * num2;
            }
            Block block2 = building1.block;
            MendProjector mendProjector;
            if (block2 is MendProjector && object.ReferenceEquals((object) (mendProjector = (MendProjector) block2), (object) (MendProjector) block2))
              num11 += mendProjector.healPercent / mendProjector.reload * num15 * 60f / 100f * num2;
            Block block3 = building1.block;
            ForceProjector forceProjector;
            if (block3 is ForceProjector && object.ReferenceEquals((object) (forceProjector = (ForceProjector) block3), (object) (ForceProjector) block3))
            {
              num10 += forceProjector.shieldHealth * num2;
              num11 += num2;
            }
          }
        }
      }
      float num16 = 0.0f;
      float num17 = 0.0f;
      Iterator iterator3 = Groups.unit.iterator();
      while (iterator3.hasNext())
      {
        Unit unit = (Unit) iterator3.next();
        if (!unit.isPlayer())
        {
          float num2 = 1f + Mathf.clamp(unit.armor / 20f);
          if (object.ReferenceEquals((object) unit.team, (object) Vars.state.rules.defaultTeam))
          {
            num10 += unit.health * num2 + unit.shield;
            num12 += unit.type.dpsEstimate;
            object obj = unit.abilities.find((Boolf) new SectorDamage.__\u003C\u003EAnon6());
            RepairFieldAbility repairFieldAbility;
            if (obj is RepairFieldAbility && object.ReferenceEquals((object) (repairFieldAbility = (RepairFieldAbility) obj), (object) (RepairFieldAbility) obj))
              num11 += repairFieldAbility.amount / repairFieldAbility.reload * 60f;
          }
          else
          {
            float num7 = !unit.isBoss() ? 1f : 3f;
            num17 += unit.type.dpsEstimate * unit.damageMultiplier() * num7;
            num16 += unit.health * num2 * unit.healthMultiplier() * num7 + unit.shield;
          }
        }
      }
      LinearRegression linearRegression = new LinearRegression();
      SpawnGroup spawnGroup1 = (SpawnGroup) null;
      Seq v1 = new Seq();
      Seq v2 = new Seq();
      for (int wave = Vars.state.wave; wave < Vars.state.wave + 10; ++wave)
      {
        float y1 = 0.0f;
        float y2 = 0.0f;
        Iterator iterator4 = Vars.state.rules.spawns.iterator();
        while (iterator4.hasNext())
        {
          SpawnGroup spawnGroup2 = (SpawnGroup) iterator4.next();
          float num2 = 1f + Mathf.clamp(spawnGroup2.type.armor / 20f);
          StatusEffect statusEffect = spawnGroup2.effect != null ? spawnGroup2.effect : StatusEffects.none;
          int spawned = spawnGroup2.getSpawned(wave);
          if (object.ReferenceEquals((object) spawnGroup2.effect, (object) StatusEffects.boss))
            spawnGroup1 = spawnGroup2;
          else if (spawned > 0)
          {
            y2 += (float) spawned * (spawnGroup2.getShield(wave) + spawnGroup2.type.health * statusEffect.healthMultiplier * num2);
            y1 += (float) spawned * spawnGroup2.type.dpsEstimate * statusEffect.damageMultiplier;
          }
        }
        v1.add((object) new Vec2((float) wave, y1));
        v2.add((object) new Vec2((float) wave, y2));
      }
      if (spawnGroup1 != null)
      {
        float num2 = 1.2f;
        for (int wave = Vars.state.wave; wave < Vars.state.wave + 60; ++wave)
        {
          int spawned = spawnGroup1.getSpawned(wave - 1);
          if (spawned > 0)
          {
            info.bossWave = wave;
            info.bossDps = (float) spawned * spawnGroup1.type.dpsEstimate * StatusEffects.boss.damageMultiplier * num2;
            info.bossHealth = (float) spawned * (spawnGroup1.getShield(wave) + spawnGroup1.type.health * StatusEffects.boss.healthMultiplier * (1f + Mathf.clamp(spawnGroup1.type.armor / 20f))) * num2;
            break;
          }
        }
      }
      linearRegression.calculate(v2);
      info.waveHealthBase = linearRegression.intercept;
      info.waveHealthSlope = linearRegression.slope;
      linearRegression.calculate(v1);
      info.waveDpsBase = linearRegression.intercept;
      info.waveDpsSlope = linearRegression.slope;
      info.sumHealth = num10 * 0.9f;
      info.sumDps = num12;
      info.sumRps = num11;
      float num18 = 1.6f;
      info.curEnemyDps = num17 * num18;
      info.curEnemyHealth = num16 * num18;
      info.wavesSurvived = SectorDamage.getWavesSurvived(info);
    }

    [LineNumberTable(31)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static float getDamage(SectorInfo info) => SectorDamage.getDamage(info, info.wavesPassed);

    [LineNumberTable(36)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static float getDamage(SectorInfo info, int wavesPassed) => SectorDamage.getDamage(info, wavesPassed, false);

    [LineNumberTable(new byte[] {159, 131, 162, 103, 103, 199, 103, 99, 165, 104, 167, 141, 107, 108, 140, 117, 149, 106, 108, 172, 102, 108, 204, 186, 120, 171, 171, 102, 134, 234, 69, 172, 166, 252, 20, 235, 113, 99, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static float getDamage(SectorInfo info, int wavesPassed, bool retWave)
    {
      int num1 = retWave ? 1 : 0;
      float num2 = info.sumHealth;
      int wave = info.wave;
      float waveSpacing = info.waveSpacing;
      if (wavesPassed > 0)
      {
        int num3 = wave;
        int num4 = wave + wavesPassed;
        if (wavesPassed > 50 && num1 == 0)
          num3 = num4 - 50;
        for (int index = num3; index <= num4; ++index)
        {
          float num5 = num2 / info.sumHealth;
          float num6 = info.sumDps * num5;
          float num7 = info.sumRps * num5;
          float num8 = info.waveDpsBase + info.waveDpsSlope * (float) index;
          float num9 = info.waveHealthBase + info.waveHealthSlope * (float) index;
          if (info.bossWave == index)
          {
            num8 += info.bossDps;
            num9 += info.bossHealth;
          }
          if (index == num3)
          {
            num8 += info.curEnemyDps;
            num9 += info.curEnemyHealth;
          }
          if ((double) num9 >= 0.0 && (double) num8 >= 0.0)
          {
            float num10 = (double) num6 > 9.99999974737875E-05 ? num9 / num6 : float.PositiveInfinity;
            float num11 = num2 / (num8 - num7);
            if ((double) num11 >= 0.0)
            {
              if ((double) num10 > (double) num11)
              {
                num2 = 0.0f;
                if (num1 != 0)
                  return (float) (index - num3);
                break;
              }
              float num12 = num10 * (num8 - num7);
              num2 = Math.min(num2 - num12 + num7 / 60f * waveSpacing, info.sumHealth);
            }
          }
        }
      }
      return num1 != 0 ? 40f : 1f - Mathf.clamp(num2 / info.sumHealth);
    }

    [LineNumberTable(41)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int getWavesSurvived(SectorInfo info) => ByteCodeHelper.f2i(SectorDamage.getDamage(info, 40, true));

    [Modifiers]
    [LineNumberTable(139)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static float lambda\u0024applyCalculatedDamage\u00240([In] Tile obj0, [In] Unit obj1) => obj1.dst2((Position) obj0);

    [Modifiers]
    [LineNumberTable(new byte[] {110, 124, 125, 191, 7, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024applyCalculatedDamage\u00241([In] Tile obj0)
    {
      if (!object.ReferenceEquals((object) obj0.team(), (object) Vars.state.rules.defaultTeam))
        return;
      if (obj0.floor().hasSurface() && Mathf.chance(0.4))
        Effect.rubble(obj0.build.x, obj0.build.y, obj0.block().size);
      obj0.remove();
    }

    [Modifiers]
    [LineNumberTable(179)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024writeParameters\u00242([In] Seq obj0, [In] int obj1, [In] int obj2) => obj0.add((object) Vars.world.tile(obj1, obj2));

    [LineNumberTable(new byte[] {161, 150, 101, 127, 4, 127, 40, 251, 61})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static float cost([In] Tile obj0) => (float) (1.0 + (!obj0.block().isStatic() || !obj0.solid() ? 0.0 : 200.0) + (obj0.build == null ? 0.0 : (double) (obj0.build.health / (float) (obj0.build.block.size * obj0.build.block.size) / 20f)) + (!obj0.floor().isLiquid ? 0.0 : 10.0));

    [Modifiers]
    [LineNumberTable(223)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024writeParameters\u00243([In] Tile obj0) => !obj0.block().isStatic() || !obj0.solid();

    [Modifiers]
    [LineNumberTable(276)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024writeParameters\u00244([In] Building obj0, [In] Ranged obj1, [In] Tile obj2) => obj2.within((Position) obj0, obj1.range() + 32f);

    [Modifiers]
    [LineNumberTable(306)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024writeParameters\u00245([In] Ability obj0) => obj0 is RepairFieldAbility;

    [Modifiers]
    [LineNumberTable(395)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024apply\u00246([In] Tile obj0) => !obj0.block().isStatic() || !obj0.solid();

    [Modifiers]
    [LineNumberTable(new byte[] {161, 32, 102, 106, 106, 115, 127, 33, 111, 110, 255, 49, 59, 41, 233, 75})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static float lambda\u0024apply\u00247([In] int obj0, [In] Tile obj1)
    {
      float num = 0.0f;
      for (int index1 = -obj0; index1 <= obj0; ++index1)
      {
        for (int index2 = -obj0; index2 <= obj0; ++index2)
        {
          int x = index1 + (int) obj1.x;
          int y = index2 + (int) obj1.y;
          if (x >= 0 && y >= 0 && (x < Vars.world.width() && y < Vars.world.height()) && Mathf.within((float) index1, (float) index2, (float) obj0))
          {
            Tile tile = Vars.world.rawTile(x, y);
            if (!(tile.block() is CoreBlock))
              num += !object.ReferenceEquals((object) tile.team(), (object) Vars.state.rules.defaultTeam) ? 0.0f : tile.build.health / (float) (tile.block().size * tile.block().size);
          }
        }
      }
      return num;
    }

    [LineNumberTable(23)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public SectorDamage()
    {
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Floatf
    {
      private readonly Tile arg\u00241;

      internal __\u003C\u003EAnon0([In] Tile obj0) => this.arg\u00241 = obj0;

      public float get([In] object obj0) => SectorDamage.lambda\u0024applyCalculatedDamage\u00240(this.arg\u00241, (Unit) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Cons
    {
      internal __\u003C\u003EAnon1()
      {
      }

      public void get([In] object obj0) => SectorDamage.lambda\u0024applyCalculatedDamage\u00241((Tile) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon2 : Intc2
    {
      private readonly Seq arg\u00241;

      internal __\u003C\u003EAnon2([In] Seq obj0) => this.arg\u00241 = obj0;

      public void get([In] int obj0, [In] int obj1) => SectorDamage.lambda\u0024writeParameters\u00242(this.arg\u00241, obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon3 : Astar.TileHueristic
    {
      internal __\u003C\u003EAnon3()
      {
      }

      public float cost([In] Tile obj0) => SectorDamage.cost(obj0);

      [SpecialName]
      public float cost([In] Tile obj0, [In] Tile obj1) => Astar.TileHueristic.\u003Cdefault\u003Ecost((Astar.TileHueristic) this, obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon4 : Boolf
    {
      internal __\u003C\u003EAnon4()
      {
      }

      public bool get([In] object obj0) => (SectorDamage.lambda\u0024writeParameters\u00243((Tile) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon5 : Boolf
    {
      private readonly Building arg\u00241;
      private readonly Ranged arg\u00242;

      internal __\u003C\u003EAnon5([In] Building obj0, [In] Ranged obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public bool get([In] object obj0) => (SectorDamage.lambda\u0024writeParameters\u00244(this.arg\u00241, this.arg\u00242, (Tile) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon6 : Boolf
    {
      internal __\u003C\u003EAnon6()
      {
      }

      public bool get([In] object obj0) => (SectorDamage.lambda\u0024writeParameters\u00245((Ability) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon7 : Boolf
    {
      internal __\u003C\u003EAnon7()
      {
      }

      public bool get([In] object obj0) => (SectorDamage.lambda\u0024apply\u00246((Tile) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon8 : Floatf
    {
      private readonly int arg\u00241;

      internal __\u003C\u003EAnon8([In] int obj0) => this.arg\u00241 = obj0;

      public float get([In] object obj0) => SectorDamage.lambda\u0024apply\u00247(this.arg\u00241, (Tile) obj0);
    }
  }
}
