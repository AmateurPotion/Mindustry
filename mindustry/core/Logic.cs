// Decompiled with JetBrains decompiler
// Type: mindustry.core.Logic
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.files;
using arc.func;
using arc.math;
using arc.util;
using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.util;
using mindustry.content;
using mindustry.ctype;
using mindustry.game;
using mindustry.gen;
using mindustry.maps;
using mindustry.type;
using mindustry.world;
using mindustry.world.blocks.storage;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.core
{
  public class Logic : Object, ApplicationListener
  {
    [LineNumberTable(new byte[] {159, 174, 134, 244, 73, 244, 79, 244, 102, 244, 90, 244, 70, 244, 89, 244, 75})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Logic()
    {
      Events.on((Class) ClassLiteral<EventType.BlockDestroyEvent>.Value, (Cons) new Logic.__\u003C\u003EAnon0());
      Events.on((Class) ClassLiteral<EventType.BlockBuildEndEvent>.Value, (Cons) new Logic.__\u003C\u003EAnon1());
      Events.on((Class) ClassLiteral<EventType.SaveLoadEvent>.Value, (Cons) new Logic.__\u003C\u003EAnon2());
      Events.on((Class) ClassLiteral<EventType.WorldLoadEvent>.Value, (Cons) new Logic.__\u003C\u003EAnon3());
      Events.on((Class) ClassLiteral<EventType.UnlockEvent>.Value, (Cons) new Logic.__\u003C\u003EAnon4());
      Events.on((Class) ClassLiteral<EventType.SectorCaptureEvent>.Value, (Cons) new Logic.__\u003C\u003EAnon5());
      Events.on((Class) ClassLiteral<EventType.TurnEvent>.Value, (Cons) new Logic.__\u003C\u003EAnon6());
    }

    [LineNumberTable(new byte[] {160, 74, 139, 138, 144, 101, 101, 170, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void reset()
    {
      GameState.State state = Vars.state.getState();
      Vars.state = new GameState();
      Events.fire((object) new EventType.StateChangeEvent(state, GameState.State.__\u003C\u003Emenu));
      Groups.clear();
      Time.clear();
      Events.fire((object) new EventType.ResetEvent());
      Core.settings.manualSave();
    }

    [LineNumberTable(new byte[] {118, 143, 127, 1, 170, 111, 127, 13, 104, 103, 107, 127, 11, 121, 130, 133})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void play()
    {
      Vars.state.set(GameState.State.__\u003C\u003Eplaying);
      Vars.state.wavetime = Vars.state.rules.waveSpacing * 2f;
      Events.fire((object) new EventType.PlayEvent());
      if (Vars.state.isCampaign())
        return;
      Iterator iterator1 = Vars.state.teams.getActive().iterator();
label_2:
      while (iterator1.hasNext())
      {
        Teams.TeamData teamData = (Teams.TeamData) iterator1.next();
        if (teamData.hasCore())
        {
          CoreBlock.CoreBuild coreBuild = teamData.core();
          coreBuild.items.clear();
          Iterator iterator2 = Vars.state.rules.loadout.iterator();
          while (true)
          {
            if (iterator2.hasNext())
            {
              ItemStack itemStack = (ItemStack) iterator2.next();
              coreBuild.items.add(itemStack.item, itemStack.amount);
            }
            else
              goto label_2;
          }
        }
      }
    }

    [LineNumberTable(new byte[] {160, 93, 106, 114, 153, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void runWave()
    {
      Vars.spawner.spawnEnemies();
      ++Vars.state.wave;
      Vars.state.wavetime = Vars.state.rules.waveSpacing;
      Events.fire((object) new EventType.WaveEvent());
    }

    [LineNumberTable(new byte[] {160, 140, 159, 0, 159, 13, 179, 127, 9, 127, 3, 123, 107, 159, 7, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void updateWeather()
    {
      Vars.state.rules.weather.removeAll((Boolf) new Logic.__\u003C\u003EAnon8());
      Iterator iterator = Vars.state.rules.weather.iterator();
      while (iterator.hasNext())
      {
        Weather.WeatherEntry weatherEntry = (Weather.WeatherEntry) iterator.next();
        weatherEntry.cooldown -= Time.delta;
        if (((double) weatherEntry.cooldown < 0.0 || weatherEntry.always) && !weatherEntry.weather.isActive())
        {
          float duration = !weatherEntry.always ? Mathf.random(weatherEntry.minDuration, weatherEntry.maxDuration) : float.PositiveInfinity;
          weatherEntry.cooldown = duration + Mathf.random(weatherEntry.minFrequency, weatherEntry.maxFrequency);
          Tmp.__\u003C\u003Ev1.setToRandomDirection();
          Call.createWeather(weatherEntry.weather, weatherEntry.intensity, duration, Tmp.__\u003C\u003Ev1.x, Tmp.__\u003C\u003Ev1.y);
        }
      }
    }

    [LineNumberTable(422)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isWaitingWave() => (Vars.state.rules.waitEnemies || Vars.state.wave >= Vars.state.rules.winWave && Vars.state.rules.winWave > 0) && Vars.state.enemies > 0;

    [LineNumberTable(new byte[] {160, 102, 143, 127, 3, 107, 217, 159, 35, 208, 127, 90, 143, 170, 127, 20, 107, 126, 148, 159, 0, 159, 27, 127, 5, 122, 203})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void checkGameState()
    {
      if (Vars.state.isCampaign())
      {
        if (Vars.state.teams.playerCores().size == 0 && !Vars.state.gameOver)
        {
          Vars.state.gameOver = true;
          Events.fire((object) new EventType.GameOverEvent(Vars.state.rules.waveTeam));
        }
        if (Vars.state.rules.waves && Vars.spawner.countSpawns() + Vars.state.teams.cores(Vars.state.rules.waveTeam).size <= 0)
          Vars.state.rules.waves = false;
        if ((!Vars.state.rules.waves || Vars.state.enemies != 0 || (Vars.state.rules.winWave <= 0 || Vars.state.wave < Vars.state.rules.winWave) || Vars.spawner.isSpawning()) && (!Vars.state.rules.attackMode || !Vars.state.rules.waveTeam.cores().isEmpty()))
          return;
        Call.sectorCapture();
      }
      else if (!Vars.state.rules.attackMode && Vars.state.teams.playerCores().size == 0 && !Vars.state.gameOver)
      {
        Vars.state.gameOver = true;
        Events.fire((object) new EventType.GameOverEvent(Vars.state.rules.waveTeam));
      }
      else
      {
        if (!Vars.state.rules.attackMode || Vars.state.teams.getActive().count((Boolf) new Logic.__\u003C\u003EAnon7()) > 1 && (Vars.state.rules.pvp || Vars.state.rules.defaultTeam.core() != null) || Vars.state.gameOver)
          return;
        Teams.TeamData teamData = (Teams.TeamData) Vars.state.teams.getActive().find((Boolf) new Logic.__\u003C\u003EAnon7());
        Events.fire((object) new EventType.GameOverEvent(teamData != null ? teamData.__\u003C\u003Eteam : Team.__\u003C\u003Ederelict));
        Vars.state.gameOver = true;
      }
    }

    [Modifiers]
    [LineNumberTable(new byte[] {159, 178, 135, 159, 3, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024new\u00240([In] EventType.BlockDestroyEvent obj0)
    {
      Tile tile = obj0.__\u003C\u003Etile;
      if (tile.build == null || !tile.block().rebuildable || Vars.net.client())
        return;
      tile.build.addPlan(true);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {159, 186, 107, 118, 108, 107, 108, 113, 127, 42, 134, 133})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024new\u00241([In] EventType.BlockBuildEndEvent obj0)
    {
      if (obj0.__\u003C\u003Ebreaking)
        return;
      Iterator iterator = Vars.state.teams.get(obj0.__\u003C\u003Eteam).blocks.iterator();
      while (iterator.hasNext())
      {
        Teams.BlockPlan blockPlan = (Teams.BlockPlan) iterator.next();
        Block block = Vars.content.block((int) blockPlan.__\u003C\u003Eblock);
        if (obj0.__\u003C\u003Etile.block().bounds((int) obj0.__\u003C\u003Etile.x, (int) obj0.__\u003C\u003Etile.y, Tmp.__\u003C\u003Er1).overlaps(block.bounds((int) blockPlan.__\u003C\u003Ex, (int) blockPlan.__\u003C\u003Ey, Tmp.__\u003C\u003Er2)))
          iterator.remove();
      }
    }

    [Modifiers]
    [LineNumberTable(new byte[] {9, 111, 144, 117, 166, 167, 100, 244, 72, 132, 114, 153, 197, 107, 103, 103, 139, 148})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024new\u00243([In] EventType.SaveLoadEvent obj0)
    {
      if (!Vars.state.isCampaign())
        return;
      Vars.state.rules.coreIncinerates = true;
      SectorInfo info = Vars.state.rules.sector.info;
      info.write();
      int wavesPassed = info.wavesPassed;
      if (wavesPassed > 0)
        Groups.unit.each((Cons) new Logic.__\u003C\u003EAnon16());
      if (wavesPassed > 0)
      {
        Vars.state.wave += wavesPassed;
        Vars.state.wavetime = Vars.state.rules.waveSpacing;
        SectorDamage.applyCalculatedDamage();
      }
      info.damage = 0.0f;
      info.wavesPassed = 0;
      info.hasCore = true;
      info.secondsPassed = 0.0f;
      Vars.state.rules.sector.saveInfo();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {48, 154, 143, 127, 8, 154, 112, 127, 16, 186, 127, 15, 127, 5, 119, 98, 194, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024new\u00244([In] EventType.WorldLoadEvent obj0)
    {
      Vars.state.rules.waveTeam.rules().infiniteAmmo = true;
      if (Vars.state.isCampaign())
      {
        if (Vars.state.getSector().preset == null || Vars.state.getSector().preset.useAI)
          Vars.state.rules.waveTeam.rules().ai = true;
        Vars.state.rules.coreIncinerates = true;
        Vars.state.rules.waveTeam.rules().aiTier = Vars.state.getSector().threat * 0.8f;
        Vars.state.rules.waveTeam.rules().infiniteResources = true;
        Iterator iterator1 = Vars.state.rules.waveTeam.cores().iterator();
label_4:
        while (iterator1.hasNext())
        {
          CoreBlock.CoreBuild coreBuild = (CoreBlock.CoreBuild) iterator1.next();
          Iterator iterator2 = Vars.content.items().iterator();
          while (true)
          {
            if (iterator2.hasNext())
            {
              Item obj = (Item) iterator2.next();
              coreBuild.items.set(obj, coreBuild.block.itemCapacity);
            }
            else
              goto label_4;
          }
        }
      }
      Core.settings.manualSave();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {73, 108, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024new\u00245([In] EventType.UnlockEvent obj0)
    {
      if (!Vars.net.server())
        return;
      Call.researched((Content) obj0.__\u003C\u003Econtent);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {79, 127, 26, 159, 8, 127, 18, 103, 107, 255, 1, 70, 165, 244, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024new\u00248([In] EventType.SectorCaptureEvent obj0)
    {
      if (Vars.net.client() || !object.ReferenceEquals((object) obj0.__\u003C\u003Esector, (object) Vars.state.getSector()) || !obj0.__\u003C\u003Esector.isBeingPlayed())
        return;
      Iterator iterator = Vars.world.tiles.iterator();
      while (iterator.hasNext())
      {
        Tile tile = (Tile) iterator.next();
        if (tile.isCenter() && tile.build != null && object.ReferenceEquals((object) tile.build.team, (object) Vars.state.rules.waveTeam))
        {
          Building build = tile.build;
          Call.setTeam(build, Team.__\u003C\u003Ederelict);
          Time.run(Mathf.random(0.0f, 360f), (Runnable) new Logic.__\u003C\u003EAnon13(build));
        }
      }
      Groups.unit.each((Cons) new Logic.__\u003C\u003EAnon14());
    }

    [Modifiers]
    [LineNumberTable(new byte[] {104, 120, 117, 223, 5, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024new\u002410([In] EventType.TurnEvent obj0)
    {
      if (!Vars.net.server() || !Vars.state.isCampaign())
        return;
      int[] amounts = new int[Vars.content.items().size];
      Vars.state.getSector().info.production.each((Cons2) new Logic.__\u003C\u003EAnon12(amounts));
      Call.sectorProduced(amounts);
    }

    [Modifiers]
    [LineNumberTable(254)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024updateWeather\u002411([In] Weather.WeatherEntry obj0) => obj0.weather == null;

    [Modifiers]
    [LineNumberTable(333)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static int lambda\u0024sectorProduced\u002412([In] Item obj0, [In] Sector obj1) => obj1.hasBase() ? obj1.info.storageCapacity - obj1.info.items.get(obj0) : 0;

    [Modifiers]
    [LineNumberTable(371)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024update\u002413([In] Unit obj0) => object.ReferenceEquals((object) obj0.team(), (object) Vars.state.rules.waveTeam) && obj0.isCounted();

    [Modifiers]
    [LineNumberTable(409)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024update\u002414([In] WeatherState obj0) => Vars.state.envAttrs.add(obj0.weather.attrs, obj0.opacity);

    [Modifiers]
    [LineNumberTable(new byte[] {107, 127, 8})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024new\u00249([In] int[] obj0, [In] Item obj1, [In] SectorInfo.ExportStat obj2) => obj0[(int) obj1.__\u003C\u003Eid] = Math.max(0, ByteCodeHelper.f2i(obj2.mean * 7200f / 60f));

    [Modifiers]
    [LineNumberTable(new byte[] {86, 112, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024new\u00246([In] Building obj0)
    {
      if (!Mathf.chance(0.25))
        return;
      obj0.kill();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {95, 124, 159, 8})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024new\u00247([In] Unit obj0)
    {
      if (!object.ReferenceEquals((object) obj0.team, (object) Vars.state.rules.waveTeam))
        return;
      double num = (double) Mathf.random(0.0f, 300f);
      Unit unit = obj0;
      Objects.requireNonNull((object) unit);
      Runnable r = (Runnable) new Logic.__\u003C\u003EAnon15(unit);
      Time.run((float) num, r);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {21, 124, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024new\u00242([In] Unit obj0)
    {
      if (!object.ReferenceEquals((object) obj0.team, (object) Vars.state.rules.waveTeam))
        return;
      obj0.remove();
    }

    [LineNumberTable(new byte[] {160, 89, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void skipWave() => this.runWave();

    [LineNumberTable(new byte[] {160, 159, 144, 145, 112, 161, 186, 185, 176, 115, 158})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void sectorCapture()
    {
      Vars.state.rules.waves = false;
      if (Vars.state.rules.sector == null)
      {
        Vars.state.rules.attackMode = false;
      }
      else
      {
        Vars.state.rules.sector.info.wasCaptured = true;
        Events.fire((object) new EventType.SectorCaptureEvent(Vars.state.rules.sector));
        Vars.state.rules.attackMode = false;
        if (Vars.headless || Vars.net.client())
          return;
        Vars.control.saves.saveSector(Vars.state.rules.sector);
      }
    }

    [LineNumberTable(new byte[] {160, 183, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void updateGameOver(Team winner) => Vars.state.gameOver = true;

    [LineNumberTable(new byte[] {160, 188, 121, 112, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void gameOver(Team winner)
    {
      Vars.state.stats.wavesLasted = Vars.state.wave;
      Vars.ui.restart.show(winner);
      Vars.netClient.setQuiet();
    }

    [LineNumberTable(new byte[] {160, 196, 159, 1, 167, 99, 107, 169, 123})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void researched(Content content)
    {
      Content content1 = content;
      UnlockableContent unlockableContent;
      if (!(content1 is UnlockableContent) || !object.ReferenceEquals((object) (unlockableContent = (UnlockableContent) content1), (object) (UnlockableContent) content1))
        return;
      for (TechTree.TechNode techNode = unlockableContent.node(); techNode != null; techNode = techNode.parent)
        techNode.content.unlock();
      Vars.state.rules.researched.add((object) unlockableContent.__\u003C\u003Ename);
    }

    [LineNumberTable(new byte[] {160, 212, 109, 117, 130, 127, 8, 106, 104, 120, 134, 118, 127, 8, 105, 127, 18, 116, 130, 133, 133, 99, 127, 2, 103, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void sectorProduced(int[] amounts)
    {
      if (!Vars.state.isCampaign())
        return;
      Planet planet = Vars.state.rules.sector.__\u003C\u003Eplanet;
      int num1 = 0;
      Iterator iterator1 = Vars.content.items().iterator();
label_3:
      while (iterator1.hasNext())
      {
        Item obj = (Item) iterator1.next();
        int amount1 = amounts[(int) obj.__\u003C\u003Eid];
        if (amount1 > 0)
        {
          int num2 = planet.sectors.sum((Intf) new Logic.__\u003C\u003EAnon9(obj));
          if (num2 != 0)
          {
            double num3 = Math.min((double) amount1 / (double) num2, 1.0);
            Iterator iterator2 = planet.sectors.iterator();
            while (true)
            {
              Sector sector;
              do
              {
                if (iterator2.hasNext())
                  sector = (Sector) iterator2.next();
                else
                  goto label_3;
              }
              while (!sector.hasBase());
              int amount2 = ByteCodeHelper.d2i(Math.ceil((double) (sector.info.storageCapacity - sector.info.items.get(obj)) * num3));
              sector.info.items.add(obj, amount2);
              num1 = 1;
            }
          }
        }
      }
      if (num1 == 0)
        return;
      Iterator iterator3 = planet.sectors.iterator();
      while (iterator3.hasNext())
        ((Sector) iterator3.next()).saveInfo();
    }

    [LineNumberTable(new byte[] {160, 243, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void dispose() => Core.settings.manualSave();

    [LineNumberTable(new byte[] {160, 248, 106, 138, 120, 170, 111, 108, 190, 111, 143, 108, 185, 108, 138, 165, 120, 134, 127, 10, 104, 139, 162, 127, 15, 104, 223, 7, 127, 15, 198, 111, 148, 165, 127, 22, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void update()
    {
      Events.fire((object) EventType.Trigger.__\u003C\u003Eupdate);
      Vars.universe.updateGlobal();
      if (Core.settings.modified() && !Vars.state.isPlaying())
        Core.settings.forceSave();
      if (!Vars.state.isGame())
        return;
      if (!Vars.net.client())
        Vars.state.enemies = Groups.unit.count((Boolf) new Logic.__\u003C\u003EAnon10());
      if (!Vars.state.isPaused())
      {
        Vars.state.teams.updateTeamStats();
        if (Vars.state.isCampaign())
          Vars.state.rules.sector.info.update();
        if (Vars.state.isCampaign())
          Vars.universe.update();
        Time.update();
        if (!Vars.net.client() && !Vars.state.isEditor())
        {
          this.updateWeather();
          Iterator iterator = Vars.state.teams.getActive().iterator();
          while (iterator.hasNext())
          {
            Teams.TeamData teamData = (Teams.TeamData) iterator.next();
            if (teamData.hasAI())
              teamData.__\u003C\u003Eai.update();
          }
        }
        if (Vars.state.rules.waves && Vars.state.rules.waveTimer && (!Vars.state.gameOver && !this.isWaitingWave()))
          Vars.state.wavetime = Math.max(Vars.state.wavetime - Time.delta, 0.0f);
        if (!Vars.net.client() && (double) Vars.state.wavetime <= 0.0 && Vars.state.rules.waves)
          this.runWave();
        Vars.state.envAttrs.clear();
        Groups.weather.each((Cons) new Logic.__\u003C\u003EAnon11());
        Groups.update();
      }
      if (Vars.net.client() || Vars.world.isInvalidMap() || (Vars.state.isEditor() || !Vars.state.rules.canGameOver))
        return;
      this.checkGameState();
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
    public virtual void exit() => ApplicationListener.\u003Cdefault\u003Eexit((ApplicationListener) this);

    [HideFromJava]
    public virtual void fileDropped([In] Fi obj0) => ApplicationListener.\u003Cdefault\u003EfileDropped((ApplicationListener) this, obj0);

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Cons
    {
      internal __\u003C\u003EAnon0()
      {
      }

      public void get([In] object obj0) => Logic.lambda\u0024new\u00240((EventType.BlockDestroyEvent) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Cons
    {
      internal __\u003C\u003EAnon1()
      {
      }

      public void get([In] object obj0) => Logic.lambda\u0024new\u00241((EventType.BlockBuildEndEvent) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon2 : Cons
    {
      internal __\u003C\u003EAnon2()
      {
      }

      public void get([In] object obj0) => Logic.lambda\u0024new\u00243((EventType.SaveLoadEvent) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon3 : Cons
    {
      internal __\u003C\u003EAnon3()
      {
      }

      public void get([In] object obj0) => Logic.lambda\u0024new\u00244((EventType.WorldLoadEvent) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon4 : Cons
    {
      internal __\u003C\u003EAnon4()
      {
      }

      public void get([In] object obj0) => Logic.lambda\u0024new\u00245((EventType.UnlockEvent) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon5 : Cons
    {
      internal __\u003C\u003EAnon5()
      {
      }

      public void get([In] object obj0) => Logic.lambda\u0024new\u00248((EventType.SectorCaptureEvent) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon6 : Cons
    {
      internal __\u003C\u003EAnon6()
      {
      }

      public void get([In] object obj0) => Logic.lambda\u0024new\u002410((EventType.TurnEvent) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon7 : Boolf
    {
      internal __\u003C\u003EAnon7()
      {
      }

      public bool get([In] object obj0) => (((Teams.TeamData) obj0).hasCore() ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon8 : Boolf
    {
      internal __\u003C\u003EAnon8()
      {
      }

      public bool get([In] object obj0) => (Logic.lambda\u0024updateWeather\u002411((Weather.WeatherEntry) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon9 : Intf
    {
      private readonly Item arg\u00241;

      internal __\u003C\u003EAnon9([In] Item obj0) => this.arg\u00241 = obj0;

      public int get([In] object obj0) => Logic.lambda\u0024sectorProduced\u002412(this.arg\u00241, (Sector) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon10 : Boolf
    {
      internal __\u003C\u003EAnon10()
      {
      }

      public bool get([In] object obj0) => (Logic.lambda\u0024update\u002413((Unit) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon11 : Cons
    {
      internal __\u003C\u003EAnon11()
      {
      }

      public void get([In] object obj0) => Logic.lambda\u0024update\u002414((WeatherState) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon12 : Cons2
    {
      private readonly int[] arg\u00241;

      internal __\u003C\u003EAnon12([In] int[] obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0, [In] object obj1) => Logic.lambda\u0024new\u00249(this.arg\u00241, (Item) obj0, (SectorInfo.ExportStat) obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon13 : Runnable
    {
      private readonly Building arg\u00241;

      internal __\u003C\u003EAnon13([In] Building obj0) => this.arg\u00241 = obj0;

      public void run() => Logic.lambda\u0024new\u00246(this.arg\u00241);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon14 : Cons
    {
      internal __\u003C\u003EAnon14()
      {
      }

      public void get([In] object obj0) => Logic.lambda\u0024new\u00247((Unit) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon15 : Runnable
    {
      private readonly Unit arg\u00241;

      internal __\u003C\u003EAnon15([In] Unit obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.kill();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon16 : Cons
    {
      internal __\u003C\u003EAnon16()
      {
      }

      public void get([In] object obj0) => Logic.lambda\u0024new\u00242((Unit) obj0);
    }
  }
}
