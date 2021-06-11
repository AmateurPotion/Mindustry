// Decompiled with JetBrains decompiler
// Type: mindustry.ai.WaveSpawner
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.@struct;
using arc.func;
using arc.math;
using arc.math.geom;
using arc.util;
using ikvm.@internal;
using IKVM.Attributes;
using java.lang;
using java.util;
using mindustry.content;
using mindustry.core;
using mindustry.entities;
using mindustry.game;
using mindustry.gen;
using mindustry.type;
using mindustry.world;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.ai
{
  public class WaveSpawner : Object
  {
    private const float margin = 40f;
    private const float coreMargin = 16f;
    private const float maxSteps = 30f;
    [Signature("Larc/struct/Seq<Lmindustry/world/Tile;>;")]
    private Seq spawns;
    private bool spawning;
    private bool any;
    private Tile firstSpawn;

    [LineNumberTable(new byte[] {159, 171, 232, 59, 107, 103, 103, 167, 117})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public WaveSpawner()
    {
      WaveSpawner waveSpawner = this;
      this.spawns = new Seq();
      this.spawning = false;
      this.any = false;
      this.firstSpawn = (Tile) null;
      Events.on((Class) ClassLiteral<EventType.WorldLoadEvent>.Value, (Cons) new WaveSpawner.__\u003C\u003EAnon0(this));
    }

    [LineNumberTable(new byte[] {54, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void eachGroundSpawn(Intc2 cons) => this.eachGroundSpawn((WaveSpawner.SpawnConsumer) new WaveSpawner.__\u003C\u003EAnon7(cons));

    [Signature("()Larc/struct/Seq<Lmindustry/world/Tile;>;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Seq getSpawns() => this.spawns;

    [LineNumberTable(new byte[] {58, 108, 127, 1, 117, 162, 127, 49, 122, 127, 19, 159, 29, 99, 163, 115, 127, 21, 103, 255, 10, 71, 104, 99, 162, 157, 133, 100, 159, 14, 133})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void eachGroundSpawn([In] WaveSpawner.SpawnConsumer obj0)
    {
      if (Vars.state.hasSpawns())
      {
        Iterator iterator = this.spawns.iterator();
        while (iterator.hasNext())
        {
          Tile tile = (Tile) iterator.next();
          obj0.accept(tile.worldx(), tile.worldy(), true);
        }
      }
      if (!Vars.state.rules.attackMode || !Vars.state.teams.isActive(Vars.state.rules.waveTeam) || Vars.state.teams.playerCores().isEmpty())
        return;
      Building building1 = (Building) Vars.state.teams.playerCores().first();
      Iterator iterator1 = Vars.state.rules.waveTeam.cores().iterator();
      while (iterator1.hasNext())
      {
        Building building2 = (Building) iterator1.next();
        Tmp.__\u003C\u003Ev1.set((Position) building1).sub((Position) building2).limit(16f + (float) (building2.block.size * 8) / 2f * Mathf.__\u003C\u003Esqrt2);
        int num1 = 0;
        int num2 = 0;
        while (true)
        {
          int num3 = num2;
          ++num2;
          if ((double) num3 < 30.0)
          {
            int tile1 = World.toTile(building2.x + Tmp.__\u003C\u003Ev1.x);
            int tile2 = World.toTile(building2.y + Tmp.__\u003C\u003Ev1.y);
            this.any = false;
            Geometry.circle(tile1, tile2, Vars.world.width(), Vars.world.height(), 3, (Intc2) new WaveSpawner.__\u003C\u003EAnon8(this));
            if (this.any)
              Tmp.__\u003C\u003Ev1.setLength(Tmp.__\u003C\u003Ev1.len() + 8.8f);
            else
              break;
          }
          else
            goto label_12;
        }
        num1 = 1;
label_12:
        if (num1 != 0)
          obj0.accept(building2.x + Tmp.__\u003C\u003Ev1.x, building2.y + Tmp.__\u003C\u003Ev1.y, false);
      }
    }

    [LineNumberTable(new byte[] {100, 127, 4, 127, 26, 127, 10, 127, 32, 127, 32, 106, 133, 127, 21, 127, 31, 116, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void eachFlyerSpawn([In] Floatc2 obj0)
    {
      Iterator iterator1 = this.spawns.iterator();
      while (iterator1.hasNext())
      {
        Tile tile = (Tile) iterator1.next();
        float angle = Angles.angle((float) Vars.world.width() / 2f, (float) Vars.world.height() / 2f, (float) tile.x, (float) tile.y);
        float len = (float) Math.max(Vars.world.width(), Vars.world.height()) * Mathf.__\u003C\u003Esqrt2 * 8f;
        float f1 = Mathf.clamp((float) (Vars.world.width() * 8) / 2f + Angles.trnsx(angle, len), -40f, (float) (Vars.world.width() * 8) + 40f);
        float f2 = Mathf.clamp((float) (Vars.world.height() * 8) / 2f + Angles.trnsy(angle, len), -40f, (float) (Vars.world.height() * 8) + 40f);
        obj0.get(f1, f2);
      }
      if (!Vars.state.rules.attackMode || !Vars.state.teams.isActive(Vars.state.rules.waveTeam))
        return;
      Iterator iterator2 = Vars.state.teams.get(Vars.state.rules.waveTeam).__\u003C\u003Ecores.iterator();
      while (iterator2.hasNext())
      {
        Building building = (Building) iterator2.next();
        obj0.get(building.x, building.y);
      }
    }

    [LineNumberTable(new byte[] {160, 67, 127, 32, 112, 134, 125})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void spawnEffect([In] Unit obj0)
    {
      obj0.rotation = obj0.angleTo((float) Vars.world.width() / 2f * 8f, (float) Vars.world.height() / 2f * 8f);
      obj0.apply(StatusEffects.unmoving, 30f);
      obj0.add();
      Call.spawnEffect(obj0.x, obj0.y, obj0.rotation, obj0.type);
    }

    [LineNumberTable(new byte[] {49, 125, 127, 14})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void doShockwave(float x, float y)
    {
      Fx.__\u003C\u003EspawnShockwave.at(x, y, Vars.state.rules.dropZoneRadius);
      Damage.damage(Vars.state.rules.waveTeam, x, y, Vars.state.rules.dropZoneRadius, 1E+08f, true);
    }

    [LineNumberTable(new byte[] {120, 103, 140, 127, 5, 114, 140, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void reset()
    {
      this.spawning = false;
      this.spawns.clear();
      Iterator iterator = Vars.world.tiles.iterator();
      while (iterator.hasNext())
      {
        Tile tile = (Tile) iterator.next();
        if (object.ReferenceEquals((object) tile.overlay(), (object) Blocks.spawn))
          this.spawns.add((object) tile);
      }
    }

    [Modifiers]
    [LineNumberTable(30)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u00240([In] EventType.WorldLoadEvent obj0) => this.reset();

    [Modifiers]
    [LineNumberTable(new byte[] {159, 179, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024getFirstSpawn\u00241([In] int obj0, [In] int obj1) => this.firstSpawn = Vars.world.tile(obj0, obj1);

    [Modifiers]
    [LineNumberTable(52)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024playerNear\u00242([In] Tile obj0) => (double) Mathf.dst((float) ((int) obj0.x * 8), (float) ((int) obj0.y * 8), Vars.player.x, Vars.player.y) < (double) Vars.state.rules.dropZoneRadius && !object.ReferenceEquals((object) Vars.player.team(), (object) Vars.state.rules.waveTeam);

    [Modifiers]
    [LineNumberTable(new byte[] {159, 128, 162, 99, 138})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024spawnEnemies\u00243([In] float obj0, [In] float obj1, [In] bool obj2)
    {
      if (!obj2)
        return;
      this.doShockwave(obj0, obj1);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {23, 102, 127, 3, 127, 1, 231, 61, 230, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024spawnEnemies\u00244(
      [In] int obj0,
      [In] SpawnGroup obj1,
      [In] float obj2,
      [In] float obj3,
      [In] float obj4)
    {
      for (int index = 0; index < obj0; ++index)
      {
        Unit unit = obj1.createUnit(Vars.state.rules.waveTeam, Vars.state.wave - 1);
        unit.set(obj3 + Mathf.range(obj2), obj4 + Mathf.range(obj2));
        this.spawnEffect(unit);
      }
    }

    [Modifiers]
    [LineNumberTable(new byte[] {34, 102, 141, 127, 3, 127, 5, 231, 59, 230, 71})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024spawnEnemies\u00245(
      [In] int obj0,
      [In] float obj1,
      [In] SpawnGroup obj2,
      [In] float obj3,
      [In] float obj4,
      [In] bool obj5)
    {
      for (int index = 0; index < obj0; ++index)
      {
        Tmp.__\u003C\u003Ev1.rnd(obj1);
        Unit unit = obj2.createUnit(Vars.state.rules.waveTeam, Vars.state.wave - 1);
        unit.set(obj3 + Tmp.__\u003C\u003Ev1.x, obj4 + Tmp.__\u003C\u003Ev1.y);
        this.spawnEffect(unit);
      }
    }

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024spawnEnemies\u00246() => this.spawning = false;

    [Modifiers]
    [LineNumberTable(104)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024eachGroundSpawn\u00247(
      [In] Intc2 obj0,
      [In] float obj1,
      [In] float obj2,
      [In] bool obj3)
    {
      obj0.get(World.toTile(obj1), World.toTile(obj2));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {77, 110, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024eachGroundSpawn\u00248([In] int obj0, [In] int obj1)
    {
      if (!Vars.world.solid(obj0, obj1))
        return;
      this.any = true;
    }

    [Modifiers]
    [LineNumberTable(196)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024spawnEffect\u00249([In] float obj0, [In] float obj1) => Fx.__\u003C\u003Espawn.at(obj0, obj1);

    [LineNumberTable(new byte[] {159, 177, 103, 177})]
    [Nullable(new object[] {64, "Larc/util/Nullable;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Tile getFirstSpawn()
    {
      this.firstSpawn = (Tile) null;
      this.eachGroundSpawn((Intc2) new WaveSpawner.__\u003C\u003EAnon1(this));
      return this.firstSpawn;
    }

    [LineNumberTable(43)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int countSpawns() => this.spawns.size;

    [LineNumberTable(52)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool playerNear() => Vars.state.hasSpawns() && !Vars.player.dead() && this.spawns.contains((Boolf) new WaveSpawner.__\u003C\u003EAnon2());

    [LineNumberTable(new byte[] {6, 135, 241, 70, 127, 13, 138, 147, 109, 134, 244, 71, 98, 134, 244, 75, 133, 117})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void spawnEnemies()
    {
      this.spawning = true;
      this.eachGroundSpawn((WaveSpawner.SpawnConsumer) new WaveSpawner.__\u003C\u003EAnon3(this));
      Iterator iterator = Vars.state.rules.spawns.iterator();
      while (iterator.hasNext())
      {
        SpawnGroup spawnGroup = (SpawnGroup) iterator.next();
        if (spawnGroup.type != null)
        {
          int spawned = spawnGroup.getSpawned(Vars.state.wave - 1);
          if (spawnGroup.type.flying)
          {
            float num = 26.66667f;
            this.eachFlyerSpawn((Floatc2) new WaveSpawner.__\u003C\u003EAnon4(this, spawned, spawnGroup, num));
          }
          else
          {
            float num = 16f;
            this.eachGroundSpawn((WaveSpawner.SpawnConsumer) new WaveSpawner.__\u003C\u003EAnon5(this, spawned, num, spawnGroup));
          }
        }
      }
      Time.run(121f, (Runnable) new WaveSpawner.__\u003C\u003EAnon6(this));
    }

    [LineNumberTable(166)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isSpawning() => this.spawning && !Vars.net.client();

    [LineNumberTable(new byte[] {160, 80, 145, 120})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void spawnEffect(float x, float y, float rotation, UnitType u)
    {
      Fx.__\u003C\u003EunitSpawn.at(x, y, rotation, (object) u);
      Time.run(30f, (Runnable) new WaveSpawner.__\u003C\u003EAnon9(x, y));
    }

    [InnerClass]
    internal interface SpawnConsumer
    {
      void accept([In] float obj0, [In] float obj1, [In] bool obj2);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Cons
    {
      private readonly WaveSpawner arg\u00241;

      internal __\u003C\u003EAnon0([In] WaveSpawner obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024new\u00240((EventType.WorldLoadEvent) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Intc2
    {
      private readonly WaveSpawner arg\u00241;

      internal __\u003C\u003EAnon1([In] WaveSpawner obj0) => this.arg\u00241 = obj0;

      public void get([In] int obj0, [In] int obj1) => this.arg\u00241.lambda\u0024getFirstSpawn\u00241(obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon2 : Boolf
    {
      internal __\u003C\u003EAnon2()
      {
      }

      public bool get([In] object obj0) => (WaveSpawner.lambda\u0024playerNear\u00242((Tile) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon3 : WaveSpawner.SpawnConsumer
    {
      private readonly WaveSpawner arg\u00241;

      internal __\u003C\u003EAnon3([In] WaveSpawner obj0) => this.arg\u00241 = obj0;

      public void accept([In] float obj0, [In] float obj1, [In] bool obj2) => this.arg\u00241.lambda\u0024spawnEnemies\u00243(obj0, obj1, obj2);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon4 : Floatc2
    {
      private readonly WaveSpawner arg\u00241;
      private readonly int arg\u00242;
      private readonly SpawnGroup arg\u00243;
      private readonly float arg\u00244;

      internal __\u003C\u003EAnon4([In] WaveSpawner obj0, [In] int obj1, [In] SpawnGroup obj2, [In] float obj3)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
        this.arg\u00244 = obj3;
      }

      public void get([In] float obj0, [In] float obj1) => this.arg\u00241.lambda\u0024spawnEnemies\u00244(this.arg\u00242, this.arg\u00243, this.arg\u00244, obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon5 : WaveSpawner.SpawnConsumer
    {
      private readonly WaveSpawner arg\u00241;
      private readonly int arg\u00242;
      private readonly float arg\u00243;
      private readonly SpawnGroup arg\u00244;

      internal __\u003C\u003EAnon5([In] WaveSpawner obj0, [In] int obj1, [In] float obj2, [In] SpawnGroup obj3)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
        this.arg\u00244 = obj3;
      }

      public void accept([In] float obj0, [In] float obj1, [In] bool obj2) => this.arg\u00241.lambda\u0024spawnEnemies\u00245(this.arg\u00242, this.arg\u00243, this.arg\u00244, obj0, obj1, obj2);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon6 : Runnable
    {
      private readonly WaveSpawner arg\u00241;

      internal __\u003C\u003EAnon6([In] WaveSpawner obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024spawnEnemies\u00246();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon7 : WaveSpawner.SpawnConsumer
    {
      private readonly Intc2 arg\u00241;

      internal __\u003C\u003EAnon7([In] Intc2 obj0) => this.arg\u00241 = obj0;

      public void accept([In] float obj0, [In] float obj1, [In] bool obj2) => WaveSpawner.lambda\u0024eachGroundSpawn\u00247(this.arg\u00241, obj0, obj1, obj2);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon8 : Intc2
    {
      private readonly WaveSpawner arg\u00241;

      internal __\u003C\u003EAnon8([In] WaveSpawner obj0) => this.arg\u00241 = obj0;

      public void get([In] int obj0, [In] int obj1) => this.arg\u00241.lambda\u0024eachGroundSpawn\u00248(obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon9 : Runnable
    {
      private readonly float arg\u00241;
      private readonly float arg\u00242;

      internal __\u003C\u003EAnon9([In] float obj0, [In] float obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => WaveSpawner.lambda\u0024spawnEffect\u00249(this.arg\u00241, this.arg\u00242);
    }
  }
}
