// Decompiled with JetBrains decompiler
// Type: mindustry.desktop.steam.SStats
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.@struct;
using arc.files;
using arc.func;
using arc.util;
using com.codedisaster.steamworks;
using ikvm.@internal;
using IKVM.Attributes;
using java.lang;
using java.util;
using mindustry.content;
using mindustry.entities.units;
using mindustry.game;
using mindustry.gen;
using mindustry.type;
using mindustry.world;
using mindustry.world.blocks.distribution;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.desktop.steam
{
  public class SStats : Object, SteamUserStatsCallback
  {
    internal SteamUserStats __\u003C\u003Estats;
    private bool updated;
    private int statSavePeriod;
    [Signature("Larc/struct/ObjectSet<Ljava/lang/String;>;")]
    private ObjectSet blocksBuilt;
    [Signature("Larc/struct/ObjectSet<Ljava/lang/String;>;")]
    private ObjectSet unitsBuilt;
    [Signature("Larc/struct/ObjectSet<Lmindustry/type/UnitType;>;")]
    private ObjectSet t5s;
    private IntSet @checked;

    [LineNumberTable(new byte[] {159, 172, 232, 55, 140, 103, 135, 118, 107, 171, 140, 245, 92})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public SStats()
    {
      SStats sstats = this;
      this.__\u003C\u003Estats = new SteamUserStats((SteamUserStatsCallback) this);
      this.updated = false;
      this.statSavePeriod = 4;
      this.blocksBuilt = new ObjectSet();
      this.unitsBuilt = new ObjectSet();
      this.t5s = new ObjectSet();
      this.@checked = new IntSet();
      this.__\u003C\u003Estats.requestCurrentStats();
      Events.on((Class) ClassLiteral<EventType.ClientLoadEvent>.Value, (Cons) new SStats.__\u003C\u003EAnon0(this));
    }

    [LineNumberTable(342)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool campaign() => Vars.state.isCampaign();

    [LineNumberTable(new byte[] {160, 220, 242, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void trigger([In] EventType.Trigger obj0, [In] SAchievement obj1) => Events.run((object) obj0, (Runnable) new SStats.__\u003C\u003EAnon32(this, obj1));

    [LineNumberTable(new byte[] {36, 245, 76, 244, 79, 245, 70, 245, 70, 245, 107, 245, 76, 244, 70, 212, 245, 70, 148, 148, 244, 72, 159, 1, 159, 1, 245, 70, 144, 144, 144, 144, 144, 159, 1, 245, 70, 144, 144, 245, 70, 245, 70, 245, 70, 212, 212, 245, 74, 244, 70, 235, 73, 117, 117, 149, 244, 70, 244, 89})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void registerEvents()
    {
      Events.on((Class) ClassLiteral<EventType.UnitDestroyEvent>.Value, (Cons) new SStats.__\u003C\u003EAnon4(this));
      Events.on((Class) ClassLiteral<EventType.TurnEvent>.Value, (Cons) new SStats.__\u003C\u003EAnon5());
      Events.run((object) EventType.Trigger.__\u003C\u003EnewGame, (Runnable) new SStats.__\u003C\u003EAnon6(this));
      Events.on((Class) ClassLiteral<EventType.CommandIssueEvent>.Value, (Cons) new SStats.__\u003C\u003EAnon7(this));
      Events.on((Class) ClassLiteral<EventType.BlockBuildEndEvent>.Value, (Cons) new SStats.__\u003C\u003EAnon8(this));
      Events.on((Class) ClassLiteral<EventType.UnitCreateEvent>.Value, (Cons) new SStats.__\u003C\u003EAnon9(this));
      Events.on((Class) ClassLiteral<EventType.UnitControlEvent>.Value, (Cons) new SStats.__\u003C\u003EAnon10());
      Events.on((Class) ClassLiteral<EventType.SchematicCreateEvent>.Value, (Cons) new SStats.__\u003C\u003EAnon11());
      Events.on((Class) ClassLiteral<EventType.BlockDestroyEvent>.Value, (Cons) new SStats.__\u003C\u003EAnon12(this));
      Events.on((Class) ClassLiteral<EventType.MapMakeEvent>.Value, (Cons) new SStats.__\u003C\u003EAnon13());
      Events.on((Class) ClassLiteral<EventType.MapPublishEvent>.Value, (Cons) new SStats.__\u003C\u003EAnon14());
      Events.on((Class) ClassLiteral<EventType.UnlockEvent>.Value, (Cons) new SStats.__\u003C\u003EAnon15());
      EventType.Trigger openWiki1 = EventType.Trigger.__\u003C\u003EopenWiki;
      SAchievement openWiki2 = SAchievement.__\u003C\u003EopenWiki;
      Objects.requireNonNull((object) openWiki2);
      Runnable listener1 = (Runnable) new SStats.__\u003C\u003EAnon16(openWiki2);
      Events.run((object) openWiki1, listener1);
      EventType.Trigger exclusionDeath = EventType.Trigger.__\u003C\u003EexclusionDeath;
      SAchievement dieExclusion = SAchievement.__\u003C\u003EdieExclusion;
      Objects.requireNonNull((object) dieExclusion);
      Runnable listener2 = (Runnable) new SStats.__\u003C\u003EAnon16(dieExclusion);
      Events.run((object) exclusionDeath, listener2);
      Events.on((Class) ClassLiteral<EventType.UnitDrownEvent>.Value, (Cons) new SStats.__\u003C\u003EAnon17(this));
      this.trigger(EventType.Trigger.__\u003C\u003EacceleratorUse, SAchievement.__\u003C\u003EuseAccelerator);
      this.trigger(EventType.Trigger.__\u003C\u003EimpactPower, SAchievement.__\u003C\u003EpowerupImpactReactor);
      this.trigger(EventType.Trigger.__\u003C\u003EflameAmmo, SAchievement.__\u003C\u003EuseFlameAmmo);
      this.trigger(EventType.Trigger.__\u003C\u003EturretCool, SAchievement.__\u003C\u003EcoolTurret);
      this.trigger(EventType.Trigger.__\u003C\u003EsuicideBomb, SAchievement.__\u003C\u003EsuicideBomb);
      EventType.Trigger enablePixelation1 = EventType.Trigger.__\u003C\u003EenablePixelation;
      SAchievement enablePixelation2 = SAchievement.__\u003C\u003EenablePixelation;
      Objects.requireNonNull((object) enablePixelation2);
      Runnable listener3 = (Runnable) new SStats.__\u003C\u003EAnon16(enablePixelation2);
      Events.run((object) enablePixelation1, listener3);
      Events.run((object) EventType.Trigger.__\u003C\u003EthoriumReactorOverheat, (Runnable) new SStats.__\u003C\u003EAnon18(this));
      this.trigger(EventType.Trigger.__\u003C\u003Eshock, SAchievement.__\u003C\u003EshockWetEnemy);
      this.trigger(EventType.Trigger.__\u003C\u003EphaseDeflectHit, SAchievement.__\u003C\u003EkillEnemyPhaseWall);
      Events.on((Class) ClassLiteral<EventType.LaunchItemEvent>.Value, (Cons) new SStats.__\u003C\u003EAnon19(this));
      Events.on((Class) ClassLiteral<EventType.PickupEvent>.Value, (Cons) new SStats.__\u003C\u003EAnon20(this));
      Events.on((Class) ClassLiteral<EventType.UnitCreateEvent>.Value, (Cons) new SStats.__\u003C\u003EAnon21(this));
      Events.on((Class) ClassLiteral<EventType.SectorLaunchEvent>.Value, (Cons) new SStats.__\u003C\u003EAnon22());
      Events.on((Class) ClassLiteral<EventType.LaunchItemEvent>.Value, (Cons) new SStats.__\u003C\u003EAnon23());
      Events.on((Class) ClassLiteral<EventType.WaveEvent>.Value, (Cons) new SStats.__\u003C\u003EAnon24(this));
      Events.on((Class) ClassLiteral<EventType.PlayerJoin>.Value, (Cons) new SStats.__\u003C\u003EAnon25());
      Runnable runnable = (Runnable) new SStats.__\u003C\u003EAnon26();
      Events.on((Class) ClassLiteral<EventType.ResearchEvent>.Value, (Cons) new SStats.__\u003C\u003EAnon27(runnable));
      Events.on((Class) ClassLiteral<EventType.UnlockEvent>.Value, (Cons) new SStats.__\u003C\u003EAnon28(runnable));
      Events.on((Class) ClassLiteral<EventType.ClientLoadEvent>.Value, (Cons) new SStats.__\u003C\u003EAnon29(runnable));
      Events.on((Class) ClassLiteral<EventType.WinEvent>.Value, (Cons) new SStats.__\u003C\u003EAnon30());
      Events.on((Class) ClassLiteral<EventType.SectorCaptureEvent>.Value, (Cons) new SStats.__\u003C\u003EAnon31());
    }

    [LineNumberTable(new byte[] {160, 215, 122, 122})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void save()
    {
      Core.settings.putJson("units-built", (Class) ClassLiteral<String>.Value, (object) this.unitsBuilt);
      Core.settings.putJson("blocks-built", (Class) ClassLiteral<String>.Value, (object) this.blocksBuilt);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {159, 176, 127, 15, 127, 15, 159, 34, 240, 75, 255, 6, 70, 118, 118, 123, 138})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u00242([In] EventType.ClientLoadEvent obj0)
    {
      this.unitsBuilt = (ObjectSet) Core.settings.getJson("units-built", (Class) ClassLiteral<ObjectSet>.Value, (Class) ClassLiteral<String>.Value, (Prov) new SStats.__\u003C\u003EAnon40());
      this.blocksBuilt = (ObjectSet) Core.settings.getJson("blocks-built", (Class) ClassLiteral<ObjectSet>.Value, (Class) ClassLiteral<String>.Value, (Prov) new SStats.__\u003C\u003EAnon40());
      this.t5s = ObjectSet.with((object[]) new UnitType[6]
      {
        UnitTypes.omura,
        UnitTypes.reign,
        UnitTypes.toxopid,
        UnitTypes.eclipse,
        UnitTypes.oct,
        UnitTypes.corvus
      });
      Core.app.addListener((ApplicationListener) new SStats.\u0031(this));
      Timer.schedule((Runnable) new SStats.__\u003C\u003EAnon41(this), (float) (this.statSavePeriod * 60), (float) (this.statSavePeriod * 60));
      if (Items.thorium.unlocked())
        SAchievement.__\u003C\u003EobtainThorium.complete();
      if (Items.titanium.unlocked())
        SAchievement.__\u003C\u003EobtainTitanium.complete();
      if (Vars.content.sectors().contains((Boolf) new SStats.__\u003C\u003EAnon42()))
        return;
      SAchievement.__\u003C\u003EunlockAllZones.complete();
    }

    [Modifiers]
    [LineNumberTable(69)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024checkUpdate\u00243([In] Unit obj0) => object.ReferenceEquals((object) obj0.team, (object) Vars.player.team());

    [Modifiers]
    [LineNumberTable(71)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024checkUpdate\u00244([In] Unit obj0) => object.ReferenceEquals((object) obj0.type, (object) UnitTypes.poly) && object.ReferenceEquals((object) obj0.team, (object) Vars.player.team());

    [Modifiers]
    [LineNumberTable(76)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024checkUpdate\u00245([In] Building obj0, [In] Item obj1) => obj0.items.get(obj1) < obj0.block.itemCapacity;

    [Modifiers]
    [LineNumberTable(new byte[] {37, 104, 124, 138, 109, 202})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024registerEvents\u00246([In] EventType.UnitDestroyEvent obj0)
    {
      if (!this.campaign() || object.ReferenceEquals((object) obj0.__\u003C\u003Eunit.team, (object) Vars.player.team()))
        return;
      SStat.__\u003C\u003EunitsDestroyed.add();
      if (!obj0.__\u003C\u003Eunit.isBoss())
        return;
      SStat.__\u003C\u003EbossesDefeated.add();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {49, 102, 127, 8, 127, 5, 105, 127, 16, 127, 1, 130, 101, 133, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024registerEvents\u00247([In] EventType.TurnEvent obj0)
    {
      float num = 0.0f;
      Iterator iterator1 = Vars.content.planets().iterator();
label_1:
      while (iterator1.hasNext())
      {
        Iterator iterator2 = ((Planet) iterator1.next()).sectors.iterator();
label_3:
        Sector sector;
        do
        {
          if (iterator2.hasNext())
            sector = (Sector) iterator2.next();
          else
            goto label_1;
        }
        while (!sector.hasBase());
        ObjectMap.Values values = sector.info.production.values().iterator();
        while (true)
        {
          SectorInfo.ExportStat exportStat;
          do
          {
            if (((Iterator) values).hasNext())
              exportStat = (SectorInfo.ExportStat) ((Iterator) values).next();
            else
              goto label_3;
          }
          while ((double) exportStat.mean <= 0.0);
          num += exportStat.mean * 60f;
        }
      }
      SStat.__\u003C\u003EmaxProduction.max(Math.round(num));
    }

    [Modifiers]
    [LineNumberTable(113)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024registerEvents\u00249() => Core.app.post((Runnable) new SStats.__\u003C\u003EAnon39(this));

    [Modifiers]
    [LineNumberTable(new byte[] {70, 122, 138})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024registerEvents\u002410([In] EventType.CommandIssueEvent obj0)
    {
      if (!this.campaign() || !object.ReferenceEquals((object) obj0.__\u003C\u003Ecommand, (object) UnitCommand.__\u003C\u003Eattack))
        return;
      SAchievement.__\u003C\u003EissueAttackCommand.complete();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {76, 127, 18, 138, 127, 25, 170, 119, 170, 125, 127, 23, 170, 166, 117, 139, 103, 102, 114, 109, 114, 112, 226, 59, 230, 75, 124, 234, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024registerEvents\u002412([In] EventType.BlockBuildEndEvent obj0)
    {
      if (!this.campaign() || obj0.__\u003C\u003Eunit == null || (!obj0.__\u003C\u003Eunit.isLocal() || obj0.__\u003C\u003Ebreaking))
        return;
      SStat.__\u003C\u003EblocksBuilt.add();
      if (object.ReferenceEquals((object) obj0.__\u003C\u003Etile.block(), (object) Blocks.router) && obj0.__\u003C\u003Etile.build.proximity().contains((Boolf) new SStats.__\u003C\u003EAnon38()))
        SAchievement.__\u003C\u003EchainRouters.complete();
      if (object.ReferenceEquals((object) obj0.__\u003C\u003Etile.block(), (object) Blocks.groundFactory))
        SAchievement.__\u003C\u003EbuildGroundFactory.complete();
      if (this.blocksBuilt.add((object) obj0.__\u003C\u003Etile.block().__\u003C\u003Ename))
      {
        if (this.blocksBuilt.contains((object) "meltdown") && this.blocksBuilt.contains((object) "spectre") && this.blocksBuilt.contains((object) "foreshadow"))
          SAchievement.__\u003C\u003EbuildMeltdownSpectre.complete();
        this.save();
      }
      if (!(obj0.__\u003C\u003Etile.block() is Conveyor))
        return;
      this.@checked.clear();
      Tile tile1 = obj0.__\u003C\u003Etile;
      for (int index = 0; index < 4; ++index)
      {
        this.@checked.add(tile1.pos());
        if (tile1.build == null)
          return;
        Tile tile2 = tile1.nearby(tile1.build.rotation);
        if (tile2 == null || !(tile2.block() is Conveyor))
          return;
        tile1 = tile2;
      }
      if (!object.ReferenceEquals((object) tile1, (object) obj0.__\u003C\u003Etile) || this.@checked.size != 4)
        return;
      SAchievement.__\u003C\u003EcircleConveyor.complete();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {119, 104, 125, 191, 5, 120, 170})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024registerEvents\u002414([In] EventType.UnitCreateEvent obj0)
    {
      if (!this.campaign())
        return;
      if (this.unitsBuilt.add((object) obj0.__\u003C\u003Eunit.type.__\u003C\u003Ename))
        SStat.__\u003C\u003EunitTypesBuilt.set(Vars.content.units().count((Boolf) new SStats.__\u003C\u003EAnon37(this)));
      if (!this.t5s.contains((object) obj0.__\u003C\u003Eunit.type))
        return;
      SAchievement.__\u003C\u003EbuildT5.complete();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 67, 127, 28, 138})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024registerEvents\u002415([In] EventType.UnitControlEvent obj0)
    {
      Unit unit = obj0.__\u003C\u003Eunit;
      BlockUnitc blockUnitc;
      if (!(unit is BlockUnitc) || !object.ReferenceEquals((object) (blockUnitc = (BlockUnitc) unit), (object) (BlockUnitc) unit) || !object.ReferenceEquals((object) blockUnitc.tile().block, (object) Blocks.router))
        return;
      SAchievement.__\u003C\u003EbecomeRouter.complete();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 73, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024registerEvents\u002416([In] EventType.SchematicCreateEvent obj0) => SStat.__\u003C\u003EschematicsCreated.add();

    [Modifiers]
    [LineNumberTable(new byte[] {160, 77, 127, 5, 138})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024registerEvents\u002417([In] EventType.BlockDestroyEvent obj0)
    {
      if (!this.campaign() || object.ReferenceEquals((object) obj0.__\u003C\u003Etile.team(), (object) Vars.player.team()))
        return;
      SStat.__\u003C\u003EblocksDestroyed.add();
    }

    [Modifiers]
    [LineNumberTable(196)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024registerEvents\u002418([In] EventType.MapMakeEvent obj0) => SStat.__\u003C\u003EmapsMade.add();

    [Modifiers]
    [LineNumberTable(198)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024registerEvents\u002419([In] EventType.MapPublishEvent obj0) => SStat.__\u003C\u003EmapsPublished.add();

    [Modifiers]
    [LineNumberTable(new byte[] {160, 87, 124, 124, 127, 9, 138})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024registerEvents\u002421([In] EventType.UnlockEvent obj0)
    {
      if (object.ReferenceEquals((object) obj0.__\u003C\u003Econtent, (object) Items.thorium))
        SAchievement.__\u003C\u003EobtainThorium.complete();
      if (object.ReferenceEquals((object) obj0.__\u003C\u003Econtent, (object) Items.titanium))
        SAchievement.__\u003C\u003EobtainTitanium.complete();
      if (!(obj0.__\u003C\u003Econtent is SectorPreset) || Vars.content.sectors().contains((Boolf) new SStats.__\u003C\u003EAnon36()))
        return;
      SAchievement.__\u003C\u003EunlockAllZones.complete();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 99, 117, 138})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024registerEvents\u002422([In] EventType.UnitDrownEvent obj0)
    {
      if (!this.campaign() || !obj0.__\u003C\u003Eunit.isPlayer())
        return;
      SAchievement.__\u003C\u003Edrown.complete();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 117, 104, 138})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024registerEvents\u002423()
    {
      if (!this.campaign())
        return;
      SStat.__\u003C\u003EreactorsOverheated.add();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 127, 104, 138})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024registerEvents\u002424([In] EventType.LaunchItemEvent obj0)
    {
      if (!this.campaign())
        return;
      SAchievement.__\u003C\u003ElaunchItemPad.complete();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 133, 127, 22, 138})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024registerEvents\u002425([In] EventType.PickupEvent obj0)
    {
      if (!obj0.__\u003C\u003Ecarrier.isPlayer() || !this.campaign() || (obj0.__\u003C\u003Eunit == null || !this.t5s.contains((object) obj0.__\u003C\u003Eunit.type)))
        return;
      SAchievement.__\u003C\u003EpickupT5.complete();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 139, 127, 5, 138})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024registerEvents\u002426([In] EventType.UnitCreateEvent obj0)
    {
      if (!this.campaign() || !object.ReferenceEquals((object) obj0.__\u003C\u003Eunit.team(), (object) Vars.player.team()))
        return;
      SStat.__\u003C\u003EunitsBuilt.add();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 145, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024registerEvents\u002427([In] EventType.SectorLaunchEvent obj0) => SStat.__\u003C\u003EtimesLaunched.add();

    [Modifiers]
    [LineNumberTable(new byte[] {160, 149, 117})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024registerEvents\u002428([In] EventType.LaunchItemEvent obj0) => SStat.__\u003C\u003EitemsLaunched.add(obj0.__\u003C\u003Estack.amount);

    [Modifiers]
    [LineNumberTable(new byte[] {160, 153, 104, 148, 127, 0, 170})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024registerEvents\u002429([In] EventType.WaveEvent obj0)
    {
      if (!this.campaign())
        return;
      SStat.__\u003C\u003EmaxWavesSurvived.max(Vars.state.wave);
      if (Vars.state.stats.buildingsBuilt != 0 || Vars.state.wave < 10)
        return;
      SAchievement.__\u003C\u003Esurvive10WavesNoBlocks.complete();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 163, 108, 148})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024registerEvents\u002430([In] EventType.PlayerJoin obj0)
    {
      if (!Vars.net.server())
        return;
      SStat.__\u003C\u003EmaxPlayersServer.max(Groups.player.size());
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 169, 150, 118, 138})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024registerEvents\u002432()
    {
      if (Blocks.router.unlocked())
        SAchievement.__\u003C\u003EresearchRouter.complete();
      if (TechTree.all.contains((Boolf) new SStats.__\u003C\u003EAnon35()))
        return;
      SAchievement.__\u003C\u003EresearchAll.complete();
    }

    [Modifiers]
    [LineNumberTable(291)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024registerEvents\u002433(
      [In] Runnable obj0,
      [In] EventType.ResearchEvent obj1)
    {
      obj0.run();
    }

    [Modifiers]
    [LineNumberTable(292)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024registerEvents\u002434(
      [In] Runnable obj0,
      [In] EventType.UnlockEvent obj1)
    {
      obj0.run();
    }

    [Modifiers]
    [LineNumberTable(293)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024registerEvents\u002435(
      [In] Runnable obj0,
      [In] EventType.ClientLoadEvent obj1)
    {
      obj0.run();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 182, 113, 138})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024registerEvents\u002436([In] EventType.WinEvent obj0)
    {
      if (!Vars.state.rules.pvp)
        return;
      SStat.__\u003C\u003EpvpsWon.add();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 188, 121, 126, 170, 113, 202, 113, 170, 121, 170, 127, 2, 170, 127, 10})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024registerEvents\u002438([In] EventType.SectorCaptureEvent obj0)
    {
      if (obj0.__\u003C\u003Esector.isBeingPlayed() || Vars.net.client())
      {
        if (Vars.state.wave <= 5 && Vars.state.rules.attackMode)
          SAchievement.__\u003C\u003EdefeatAttack5Waves.complete();
        if (Vars.state.stats.buildingsDestroyed == 0)
          SAchievement.__\u003C\u003EcaptureNoBlocksBroken.complete();
      }
      if (Vars.state.rules.attackMode)
        SStat.__\u003C\u003EattacksWon.add();
      if (!obj0.__\u003C\u003Esector.isBeingPlayed() && !Vars.net.client())
        SAchievement.__\u003C\u003EcaptureBackground.complete();
      if (!obj0.__\u003C\u003Esector.__\u003C\u003Eplanet.sectors.contains((Boolf) new SStats.__\u003C\u003EAnon33()))
        SAchievement.__\u003C\u003EcaptureAllSectors.complete();
      SStat.__\u003C\u003EsectorsControlled.set(obj0.__\u003C\u003Esector.__\u003C\u003Eplanet.sectors.count((Boolf) new SStats.__\u003C\u003EAnon34()));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 221, 104, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024trigger\u002439([In] SAchievement obj0)
    {
      if (!this.campaign())
        return;
      obj0.complete();
    }

    [Modifiers]
    [LineNumberTable(320)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024registerEvents\u002437([In] Sector obj0) => !obj0.hasBase();

    [Modifiers]
    [LineNumberTable(285)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024registerEvents\u002431([In] TechTree.TechNode obj0) => obj0.content.locked();

    [Modifiers]
    [LineNumberTable(203)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024registerEvents\u002420([In] SectorPreset obj0) => obj0.locked();

    [Modifiers]
    [LineNumberTable(171)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool lambda\u0024registerEvents\u002413([In] UnitType obj0) => this.unitsBuilt.contains((object) obj0.__\u003C\u003Ename) && !obj0.isHidden();

    [Modifiers]
    [LineNumberTable(129)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024registerEvents\u002411([In] Building obj0) => object.ReferenceEquals((object) obj0.block, (object) Blocks.router);

    [Modifiers]
    [LineNumberTable(new byte[] {64, 127, 16, 138})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024registerEvents\u00248()
    {
      if (!this.campaign() || Vars.player.core() == null || Vars.player.core().items.total() < 10000)
        return;
      SAchievement.__\u003C\u003Edrop10kitems.complete();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {0, 104, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u00240()
    {
      if (!this.updated)
        return;
      this.__\u003C\u003Estats.storeStats();
    }

    [Modifiers]
    [LineNumberTable(57)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024new\u00241([In] SectorPreset obj0) => obj0.locked();

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void onUpdate() => this.updated = true;

    [LineNumberTable(new byte[] {18, 107, 158, 120, 170, 127, 10, 124, 106, 130, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void checkUpdate()
    {
      if (!this.campaign())
        return;
      SStat.__\u003C\u003EmaxUnitActive.max(Groups.unit.count((Boolf) new SStats.__\u003C\u003EAnon1()));
      if (Groups.unit.count((Boolf) new SStats.__\u003C\u003EAnon2()) >= 10)
        SAchievement.__\u003C\u003Eactive10Polys.complete();
      Iterator iterator = Vars.player.team().cores().iterator();
      while (iterator.hasNext())
      {
        Building building = (Building) iterator.next();
        if (!Vars.content.items().contains((Boolf) new SStats.__\u003C\u003EAnon3(building)))
        {
          SAchievement.__\u003C\u003EfillCoreAllCampaign.complete();
          break;
        }
      }
    }

    [LineNumberTable(new byte[] {160, 233, 134, 109, 150, 138})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void onUserStatsReceived(long gameID, SteamID steamID, SteamResult result)
    {
      this.registerEvents();
      if (!object.ReferenceEquals((object) result, (object) SteamResult.__\u003C\u003EOK))
        Log.err("Failed to receive steam stats: @", (object) result);
      else
        Log.info((object) "Received steam stats.");
    }

    [LineNumberTable(new byte[] {160, 244, 148, 109, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void onUserStatsStored(long gameID, SteamResult result)
    {
      Log.info("Stored stats: @", (object) result);
      if (!object.ReferenceEquals((object) result, (object) SteamResult.__\u003C\u003EOK))
        return;
      this.updated = true;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void onUserStatsUnloaded(SteamID steamID)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void onUserAchievementStored(long l, bool b, string s, int i, int i1)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void onLeaderboardFindResult(
      SteamLeaderboardHandle steamLeaderboardHandle,
      bool b)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void onLeaderboardScoresDownloaded(
      SteamLeaderboardHandle steamLeaderboardHandle,
      SteamLeaderboardEntriesHandle steamLeaderboardEntriesHandle,
      int i)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void onLeaderboardScoreUploaded(
      bool b,
      SteamLeaderboardHandle steamLeaderboardHandle,
      int i,
      bool b1,
      int i1,
      int i2)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void onGlobalStatsReceived(long l, SteamResult steamResult)
    {
    }

    [Modifiers]
    public SteamUserStats stats
    {
      [HideFromJava] get => this.__\u003C\u003Estats;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Estats = value;
    }

    [EnclosingMethod(null, "<init>", "()V")]
    [SpecialName]
    internal class \u0031 : Object, ApplicationListener
    {
      internal Interval i;
      [Modifiers]
      internal SStats this\u00240;

      [LineNumberTable(new byte[] {159, 180, 111})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0031([In] SStats obj0)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector();
        SStats.\u0031 obj = this;
        this.i = new Interval();
      }

      [LineNumberTable(new byte[] {159, 185, 114, 139})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void update()
      {
        if (!this.i.get(60f))
          return;
        this.this\u00240.checkUpdate();
      }

      [HideFromJava]
      public virtual void init() => ApplicationListener.\u003Cdefault\u003Einit((ApplicationListener) this);

      [HideFromJava]
      public virtual void resize([In] int obj0, [In] int obj1) => ApplicationListener.\u003Cdefault\u003Eresize((ApplicationListener) this, obj0, obj1);

      [HideFromJava]
      public virtual void pause() => ApplicationListener.\u003Cdefault\u003Epause((ApplicationListener) this);

      [HideFromJava]
      public virtual void resume() => ApplicationListener.\u003Cdefault\u003Eresume((ApplicationListener) this);

      [HideFromJava]
      public virtual void dispose() => ApplicationListener.\u003Cdefault\u003Edispose((ApplicationListener) this);

      [HideFromJava]
      public virtual void exit() => ApplicationListener.\u003Cdefault\u003Eexit((ApplicationListener) this);

      [HideFromJava]
      public virtual void fileDropped([In] Fi obj0) => ApplicationListener.\u003Cdefault\u003EfileDropped((ApplicationListener) this, obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Cons
    {
      private readonly SStats arg\u00241;

      internal __\u003C\u003EAnon0([In] SStats obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024new\u00242((EventType.ClientLoadEvent) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Boolf
    {
      internal __\u003C\u003EAnon1()
      {
      }

      public bool get([In] object obj0) => (SStats.lambda\u0024checkUpdate\u00243((Unit) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon2 : Boolf
    {
      internal __\u003C\u003EAnon2()
      {
      }

      public bool get([In] object obj0) => (SStats.lambda\u0024checkUpdate\u00244((Unit) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon3 : Boolf
    {
      private readonly Building arg\u00241;

      internal __\u003C\u003EAnon3([In] Building obj0) => this.arg\u00241 = obj0;

      public bool get([In] object obj0) => (SStats.lambda\u0024checkUpdate\u00245(this.arg\u00241, (Item) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon4 : Cons
    {
      private readonly SStats arg\u00241;

      internal __\u003C\u003EAnon4([In] SStats obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024registerEvents\u00246((EventType.UnitDestroyEvent) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon5 : Cons
    {
      internal __\u003C\u003EAnon5()
      {
      }

      public void get([In] object obj0) => SStats.lambda\u0024registerEvents\u00247((EventType.TurnEvent) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon6 : Runnable
    {
      private readonly SStats arg\u00241;

      internal __\u003C\u003EAnon6([In] SStats obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024registerEvents\u00249();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon7 : Cons
    {
      private readonly SStats arg\u00241;

      internal __\u003C\u003EAnon7([In] SStats obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024registerEvents\u002410((EventType.CommandIssueEvent) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon8 : Cons
    {
      private readonly SStats arg\u00241;

      internal __\u003C\u003EAnon8([In] SStats obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024registerEvents\u002412((EventType.BlockBuildEndEvent) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon9 : Cons
    {
      private readonly SStats arg\u00241;

      internal __\u003C\u003EAnon9([In] SStats obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024registerEvents\u002414((EventType.UnitCreateEvent) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon10 : Cons
    {
      internal __\u003C\u003EAnon10()
      {
      }

      public void get([In] object obj0) => SStats.lambda\u0024registerEvents\u002415((EventType.UnitControlEvent) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon11 : Cons
    {
      internal __\u003C\u003EAnon11()
      {
      }

      public void get([In] object obj0) => SStats.lambda\u0024registerEvents\u002416((EventType.SchematicCreateEvent) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon12 : Cons
    {
      private readonly SStats arg\u00241;

      internal __\u003C\u003EAnon12([In] SStats obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024registerEvents\u002417((EventType.BlockDestroyEvent) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon13 : Cons
    {
      internal __\u003C\u003EAnon13()
      {
      }

      public void get([In] object obj0) => SStats.lambda\u0024registerEvents\u002418((EventType.MapMakeEvent) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon14 : Cons
    {
      internal __\u003C\u003EAnon14()
      {
      }

      public void get([In] object obj0) => SStats.lambda\u0024registerEvents\u002419((EventType.MapPublishEvent) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon15 : Cons
    {
      internal __\u003C\u003EAnon15()
      {
      }

      public void get([In] object obj0) => SStats.lambda\u0024registerEvents\u002421((EventType.UnlockEvent) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon16 : Runnable
    {
      private readonly SAchievement arg\u00241;

      internal __\u003C\u003EAnon16([In] SAchievement obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.complete();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon17 : Cons
    {
      private readonly SStats arg\u00241;

      internal __\u003C\u003EAnon17([In] SStats obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024registerEvents\u002422((EventType.UnitDrownEvent) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon18 : Runnable
    {
      private readonly SStats arg\u00241;

      internal __\u003C\u003EAnon18([In] SStats obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024registerEvents\u002423();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon19 : Cons
    {
      private readonly SStats arg\u00241;

      internal __\u003C\u003EAnon19([In] SStats obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024registerEvents\u002424((EventType.LaunchItemEvent) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon20 : Cons
    {
      private readonly SStats arg\u00241;

      internal __\u003C\u003EAnon20([In] SStats obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024registerEvents\u002425((EventType.PickupEvent) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon21 : Cons
    {
      private readonly SStats arg\u00241;

      internal __\u003C\u003EAnon21([In] SStats obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024registerEvents\u002426((EventType.UnitCreateEvent) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon22 : Cons
    {
      internal __\u003C\u003EAnon22()
      {
      }

      public void get([In] object obj0) => SStats.lambda\u0024registerEvents\u002427((EventType.SectorLaunchEvent) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon23 : Cons
    {
      internal __\u003C\u003EAnon23()
      {
      }

      public void get([In] object obj0) => SStats.lambda\u0024registerEvents\u002428((EventType.LaunchItemEvent) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon24 : Cons
    {
      private readonly SStats arg\u00241;

      internal __\u003C\u003EAnon24([In] SStats obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024registerEvents\u002429((EventType.WaveEvent) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon25 : Cons
    {
      internal __\u003C\u003EAnon25()
      {
      }

      public void get([In] object obj0) => SStats.lambda\u0024registerEvents\u002430((EventType.PlayerJoin) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon26 : Runnable
    {
      internal __\u003C\u003EAnon26()
      {
      }

      public void run() => SStats.lambda\u0024registerEvents\u002432();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon27 : Cons
    {
      private readonly Runnable arg\u00241;

      internal __\u003C\u003EAnon27([In] Runnable obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => SStats.lambda\u0024registerEvents\u002433(this.arg\u00241, (EventType.ResearchEvent) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon28 : Cons
    {
      private readonly Runnable arg\u00241;

      internal __\u003C\u003EAnon28([In] Runnable obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => SStats.lambda\u0024registerEvents\u002434(this.arg\u00241, (EventType.UnlockEvent) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon29 : Cons
    {
      private readonly Runnable arg\u00241;

      internal __\u003C\u003EAnon29([In] Runnable obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => SStats.lambda\u0024registerEvents\u002435(this.arg\u00241, (EventType.ClientLoadEvent) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon30 : Cons
    {
      internal __\u003C\u003EAnon30()
      {
      }

      public void get([In] object obj0) => SStats.lambda\u0024registerEvents\u002436((EventType.WinEvent) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon31 : Cons
    {
      internal __\u003C\u003EAnon31()
      {
      }

      public void get([In] object obj0) => SStats.lambda\u0024registerEvents\u002438((EventType.SectorCaptureEvent) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon32 : Runnable
    {
      private readonly SStats arg\u00241;
      private readonly SAchievement arg\u00242;

      internal __\u003C\u003EAnon32([In] SStats obj0, [In] SAchievement obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => this.arg\u00241.lambda\u0024trigger\u002439(this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon33 : Boolf
    {
      internal __\u003C\u003EAnon33()
      {
      }

      public bool get([In] object obj0) => (SStats.lambda\u0024registerEvents\u002437((Sector) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon34 : Boolf
    {
      internal __\u003C\u003EAnon34()
      {
      }

      public bool get([In] object obj0) => (((Sector) obj0).hasBase() ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon35 : Boolf
    {
      internal __\u003C\u003EAnon35()
      {
      }

      public bool get([In] object obj0) => (SStats.lambda\u0024registerEvents\u002431((TechTree.TechNode) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon36 : Boolf
    {
      internal __\u003C\u003EAnon36()
      {
      }

      public bool get([In] object obj0) => (SStats.lambda\u0024registerEvents\u002420((SectorPreset) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon37 : Boolf
    {
      private readonly SStats arg\u00241;

      internal __\u003C\u003EAnon37([In] SStats obj0) => this.arg\u00241 = obj0;

      public bool get([In] object obj0) => (this.arg\u00241.lambda\u0024registerEvents\u002413((UnitType) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon38 : Boolf
    {
      internal __\u003C\u003EAnon38()
      {
      }

      public bool get([In] object obj0) => (SStats.lambda\u0024registerEvents\u002411((Building) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon39 : Runnable
    {
      private readonly SStats arg\u00241;

      internal __\u003C\u003EAnon39([In] SStats obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024registerEvents\u00248();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon40 : Prov
    {
      internal __\u003C\u003EAnon40()
      {
      }

      public object get() => (object) new ObjectSet();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon41 : Runnable
    {
      private readonly SStats arg\u00241;

      internal __\u003C\u003EAnon41([In] SStats obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024new\u00240();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon42 : Boolf
    {
      internal __\u003C\u003EAnon42()
      {
      }

      public bool get([In] object obj0) => (SStats.lambda\u0024new\u00241((SectorPreset) obj0) ? 1 : 0) != 0;
    }
  }
}
