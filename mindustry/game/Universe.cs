// Decompiled with JetBrains decompiler
// Type: mindustry.game.Universe
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.@struct;
using arc.func;
using arc.math;
using arc.util;
using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.util;
using mindustry.content;
using mindustry.maps;
using mindustry.type;
using mindustry.world.blocks.storage;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.game
{
  public class Universe : Object
  {
    private int seconds;
    private int netSeconds;
    private float secondCounter;
    private int turn;
    private float turnCounter;
    [Nullable(new object[] {64, "Larc/util/Nullable;"})]
    private Schematic lastLoadout;
    private ItemSeq lastLaunchResources;

    [LineNumberTable(new byte[] {159, 169, 8, 171, 166, 244, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Universe()
    {
      Universe universe = this;
      this.lastLaunchResources = new ItemSeq();
      this.load();
      Events.on((Class) ClassLiteral<EventType.SectorCaptureEvent>.Value, (Cons) new Universe.__\u003C\u003EAnon0());
    }

    [LineNumberTable(287)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float secondsf() => (float) this.seconds() + this.secondCounter;

    [LineNumberTable(new byte[] {159, 183, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void updateGlobal() => this.updatePlanet(Planets.sun);

    [LineNumberTable(new byte[] {13, 111, 122, 179, 109, 107, 166, 109, 120, 179, 117, 230, 69, 143, 113, 191, 3, 124, 159, 1})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void update()
    {
      if (!Vars.net.client())
      {
        this.secondCounter += Time.delta / 60f;
        this.turnCounter += Time.delta;
        if ((double) this.turnCounter >= 7200.0)
        {
          this.turnCounter = 0.0f;
          this.runTurn();
        }
        if ((double) this.secondCounter >= 1.0)
        {
          this.seconds += ByteCodeHelper.f2i(this.secondCounter);
          this.secondCounter %= 1f;
          int seconds = this.seconds;
          int num = 10;
          if ((num != -1 ? seconds % num : 0) == 1)
            this.save();
        }
      }
      if (!Vars.state.hasSector())
        return;
      float a = Mathf.clamp(Mathf.map(Vars.state.getSector().getLight(), 0.0f, 0.8f, 0.3f, 1f));
      Vars.state.rules.ambientLight.a = 1f - a;
      Vars.state.rules.lighting = !Mathf.equal(a, 1f);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void updateNetSeconds(int value) => this.netSeconds = value;

    [LineNumberTable(283)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int seconds() => Vars.net.client() ? this.netSeconds : this.seconds;

    [LineNumberTable(new byte[] {71, 115})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Schematic getLastLoadout()
    {
      if (this.lastLoadout == null)
        this.lastLoadout = Loadouts.basicShard;
      return this.lastLoadout;
    }

    [LineNumberTable(new byte[] {55, 127, 10})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual ItemSeq getLaunchResources()
    {
      this.lastLaunchResources = (ItemSeq) Core.settings.getJson("launch-resources-seq", (Class) ClassLiteral<ItemSeq>.Value, (Prov) new Universe.__\u003C\u003EAnon1());
      return this.lastLaunchResources;
    }

    [LineNumberTable(new byte[] {160, 182, 117, 117})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void load()
    {
      this.seconds = Core.settings.getInt("utimei");
      this.turn = Core.settings.getInt("turn");
    }

    [LineNumberTable(new byte[] {159, 191, 108, 109, 104, 151, 127, 1, 103, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void updatePlanet([In] Planet obj0)
    {
      obj0.position.setZero();
      obj0.addParentOffset(obj0.position);
      if (obj0.parent != null)
        obj0.position.add(obj0.parent.position);
      Iterator iterator = obj0.children.iterator();
      while (iterator.hasNext())
        this.updatePlanet((Planet) iterator.next());
    }

    [LineNumberTable(new byte[] {93, 142, 163, 127, 8, 127, 5, 184, 105, 147, 217, 172, 105, 185, 127, 9, 142, 100, 174, 186, 191, 1, 141, 172, 113, 113, 109, 118, 159, 34, 109, 173, 172, 170, 110, 110, 105, 135, 127, 1, 201, 253, 72, 159, 1, 145, 199, 127, 20, 184, 127, 14, 191, 44, 105, 113, 112, 146, 110, 109, 109, 167, 204, 101, 133, 138, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void runTurn()
    {
      ++this.turn;
      int num1 = 120;
      Iterator iterator1 = Vars.content.planets().iterator();
label_1:
      while (iterator1.hasNext())
      {
        Iterator iterator2 = ((Planet) iterator1.next()).sectors.iterator();
        while (true)
        {
          Sector sector;
          int num2;
          do
          {
            do
            {
              do
              {
                if (iterator2.hasNext())
                  sector = (Sector) iterator2.next();
                else
                  goto label_1;
              }
              while (!sector.hasSave() || !sector.hasBase());
              if (sector.isAttacked())
                sector.info.minutesCaptured = 0.0f;
              else
                sector.info.minutesCaptured += 2f;
              if (!sector.isBeingPlayed())
              {
                if (sector.isAttacked())
                  sector.info.secondsPassed += 120f;
                int num3 = ByteCodeHelper.f2i(sector.info.secondsPassed * 60f / sector.info.waveSpacing);
                int num4 = sector.info.waves ? 1 : 0;
                if (num4 != 0)
                  sector.info.wavesPassed = num3;
                float num5 = num4 == 0 ? 0.0f : SectorDamage.getDamage(sector.info);
                sector.info.damage = Math.max(sector.info.damage, num5);
                if (num4 != 0 && (double) num5 >= 0.999000012874603)
                {
                  Events.fire((object) new EventType.SectorLoseEvent(sector));
                  sector.info.items.clear();
                  sector.info.damage = 1f;
                  sector.info.hasCore = false;
                  sector.info.production.clear();
                }
                else if (num4 != 0 && num3 > 0 && (sector.info.winWave > 1 && sector.info.wave + num3 >= sector.info.winWave) && !sector.hasEnemyBase())
                {
                  sector.info.waves = false;
                  sector.info.wasCaptured = true;
                  Events.fire((object) new EventType.SectorCaptureEvent(sector));
                }
                float productionScale = sector.getProductionScale();
                if (sector.info.destination != null)
                {
                  Sector destination = sector.info.destination;
                  if (destination.hasBase())
                  {
                    ItemSeq items = new ItemSeq();
                    sector.info.export.each((Cons2) new Universe.__\u003C\u003EAnon3(items, num1, productionScale));
                    destination.addItems(items);
                  }
                }
                sector.info.export.each((Cons2) new Universe.__\u003C\u003EAnon4(sector));
                sector.info.production.each((Cons2) new Universe.__\u003C\u003EAnon5(sector, num1, productionScale));
                sector.info.items.checkNegative();
                sector.saveInfo();
              }
            }
            while (sector.isAttacked() || (double) sector.info.minutesCaptured <= 20.0 || !sector.info.hasSpawns);
            num2 = sector.near().count((Boolf) new Universe.__\u003C\u003EAnon6());
          }
          while (num2 <= 0 || !Mathf.chance((double) (0.01f * (0.8f + (float) (num2 - 1) * 0.3f))));
          int num6 = Math.max(sector.info.winWave, !sector.isBeingPlayed() ? sector.info.wave + sector.info.wavesPassed : Vars.state.wave) + Mathf.random(2, 4) * 5;
          if (sector.isBeingPlayed())
          {
            Vars.state.rules.winWave = num6;
            Vars.state.rules.waves = true;
            Vars.state.rules.attackMode = false;
          }
          else
          {
            sector.info.winWave = num6;
            sector.info.waves = true;
            sector.info.attack = false;
            sector.saveInfo();
          }
          Events.fire((object) new EventType.SectorInvasionEvent(sector));
        }
      }
      Events.fire((object) new EventType.TurnEvent());
      this.save();
    }

    [LineNumberTable(new byte[] {160, 177, 122, 122})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void save()
    {
      Core.settings.put("utimei", (object) Integer.valueOf(this.seconds));
      Core.settings.put("turn", (object) Integer.valueOf(this.turn));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {159, 174, 120, 148})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024new\u00240([In] EventType.SectorCaptureEvent obj0)
    {
      if (Vars.net.client() || !Vars.state.isCampaign())
        return;
      Vars.state.getSector().__\u003C\u003Eplanet.updateBaseCoverage();
    }

    [Modifiers]
    [LineNumberTable(136)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024getLoadout\u00241([In] string obj0, [In] Schematic obj1) => obj1.file != null && String.instancehelper_equals(obj1.file.nameWithoutExtension(), (object) obj0);

    [Modifiers]
    [LineNumberTable(206)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024runTurn\u00242(
      [In] ItemSeq obj0,
      [In] int obj1,
      [In] float obj2,
      [In] Item obj3,
      [In] SectorInfo.ExportStat obj4)
    {
      obj0.add(obj3, ByteCodeHelper.f2i(obj4.mean * (float) obj1 * obj2));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 98, 159, 33, 159, 1})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024runTurn\u00243(
      [In] Sector obj0,
      [In] Item obj1,
      [In] SectorInfo.ExportStat obj2)
    {
      if (obj0.info.items.get(obj1) > 0 || (double) ((SectorInfo.ExportStat) obj0.info.production.get((object) obj1, (Prov) new Universe.__\u003C\u003EAnon7())).mean >= 0.0)
        return;
      ((SectorInfo.ExportStat) obj0.info.export.get((object) obj1)).mean = 0.0f;
    }

    [Modifiers]
    [LineNumberTable(219)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024runTurn\u00244(
      [In] Sector obj0,
      [In] int obj1,
      [In] float obj2,
      [In] Item obj3,
      [In] SectorInfo.ExportStat obj4)
    {
      obj0.info.items.add(obj3, Math.min(ByteCodeHelper.f2i(obj4.mean * (float) obj1 * obj2), obj0.info.storageCapacity - obj0.info.items.get(obj3)));
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int turn() => this.turn;

    [LineNumberTable(new byte[] {46, 103, 107, 111, 111, 111, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void clearLoadoutInfo()
    {
      this.lastLoadout = (Schematic) null;
      this.lastLaunchResources = new ItemSeq();
      Core.settings.remove("launch-resources-seq");
      Core.settings.remove("lastloadout-core-shard");
      Core.settings.remove("lastloadout-core-nucleus");
      Core.settings.remove("lastloadout-core-foundation");
    }

    [LineNumberTable(new byte[] {60, 103, 117})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void updateLaunchResources(ItemSeq stacks)
    {
      this.lastLaunchResources = stacks;
      Core.settings.putJson("launch-resources-seq", (object) this.lastLaunchResources);
    }

    [LineNumberTable(new byte[] {66, 127, 36, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void updateLoadout(CoreBlock block, Schematic schem)
    {
      Core.settings.put(new StringBuilder().append("lastloadout-").append(block.__\u003C\u003Ename).toString(), schem.file != null ? (object) schem.file.nameWithoutExtension() : (object) "");
      this.lastLoadout = schem;
    }

    [LineNumberTable(new byte[] {79, 173, 191, 16, 108, 151})]
    [Nullable(new object[] {64, "Larc/util/Nullable;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Schematic getLoadout(CoreBlock core)
    {
      if (Vars.schematics == null)
        return Loadouts.basicShard;
      string str = Core.settings.getString(new StringBuilder().append("lastloadout-").append(core.__\u003C\u003Ename).toString(), "");
      Seq loadouts = Vars.schematics.getLoadouts(core);
      Schematic schematic = (Schematic) loadouts.find((Boolf) new Universe.__\u003C\u003EAnon2(str));
      if (schematic != null)
        return schematic;
      return loadouts.any() ? (Schematic) loadouts.first() : (Schematic) null;
    }

    [LineNumberTable(new byte[] {160, 146, 134, 127, 5, 127, 2, 105, 141, 98, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual ItemSeq getGlobalResources()
    {
      ItemSeq itemSeq = new ItemSeq();
      Iterator iterator1 = Vars.content.planets().iterator();
label_1:
      while (iterator1.hasNext())
      {
        Iterator iterator2 = ((Planet) iterator1.next()).sectors.iterator();
        while (true)
        {
          Sector sector;
          do
          {
            if (iterator2.hasNext())
              sector = (Sector) iterator2.next();
            else
              goto label_1;
          }
          while (!sector.hasSave());
          itemSeq.add(sector.items());
        }
      }
      return itemSeq;
    }

    [LineNumberTable(278)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float secondsMod(float mod, float scale) => (float) this.seconds() / scale % mod;

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Cons
    {
      internal __\u003C\u003EAnon0()
      {
      }

      public void get([In] object obj0) => Universe.lambda\u0024new\u00240((EventType.SectorCaptureEvent) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Prov
    {
      internal __\u003C\u003EAnon1()
      {
      }

      public object get() => (object) new ItemSeq();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon2 : Boolf
    {
      private readonly string arg\u00241;

      internal __\u003C\u003EAnon2([In] string obj0) => this.arg\u00241 = obj0;

      public bool get([In] object obj0) => (Universe.lambda\u0024getLoadout\u00241(this.arg\u00241, (Schematic) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon3 : Cons2
    {
      private readonly ItemSeq arg\u00241;
      private readonly int arg\u00242;
      private readonly float arg\u00243;

      internal __\u003C\u003EAnon3([In] ItemSeq obj0, [In] int obj1, [In] float obj2)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
      }

      public void get([In] object obj0, [In] object obj1) => Universe.lambda\u0024runTurn\u00242(this.arg\u00241, this.arg\u00242, this.arg\u00243, (Item) obj0, (SectorInfo.ExportStat) obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon4 : Cons2
    {
      private readonly Sector arg\u00241;

      internal __\u003C\u003EAnon4([In] Sector obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0, [In] object obj1) => Universe.lambda\u0024runTurn\u00243(this.arg\u00241, (Item) obj0, (SectorInfo.ExportStat) obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon5 : Cons2
    {
      private readonly Sector arg\u00241;
      private readonly int arg\u00242;
      private readonly float arg\u00243;

      internal __\u003C\u003EAnon5([In] Sector obj0, [In] int obj1, [In] float obj2)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
      }

      public void get([In] object obj0, [In] object obj1) => Universe.lambda\u0024runTurn\u00244(this.arg\u00241, this.arg\u00242, this.arg\u00243, (Item) obj0, (SectorInfo.ExportStat) obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon6 : Boolf
    {
      internal __\u003C\u003EAnon6()
      {
      }

      public bool get([In] object obj0) => (((Sector) obj0).hasEnemyBase() ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon7 : Prov
    {
      internal __\u003C\u003EAnon7()
      {
      }

      public object get() => (object) new SectorInfo.ExportStat();
    }
  }
}
