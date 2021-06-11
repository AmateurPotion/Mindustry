// Decompiled with JetBrains decompiler
// Type: mindustry.core.Control
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.@struct;
using arc.assets;
using arc.audio;
using arc.files;
using arc.func;
using arc.graphics.g2d;
using arc.input;
using arc.math;
using arc.math.geom;
using arc.scene.style;
using arc.scene.ui;
using arc.util;
using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.io;
using java.lang;
using java.text;
using java.util;
using mindustry.audio;
using mindustry.content;
using mindustry.ctype;
using mindustry.entities;
using mindustry.game;
using mindustry.gen;
using mindustry.input;
using mindustry.io;
using mindustry.maps;
using mindustry.net;
using mindustry.type;
using mindustry.ui;
using mindustry.ui.dialogs;
using mindustry.world;
using mindustry.world.blocks.storage;
using mindustry.world.modules;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.core
{
  [Implements(new string[] {"arc.ApplicationListener", "arc.assets.Loadable"})]
  public class Control : Object, ApplicationListener, Loadable
  {
    public Saves saves;
    public SoundControl sound;
    public InputHandler input;
    private Interval timer;
    private bool hiscore;
    private bool wasPaused;

    [LineNumberTable(new byte[] {8, 232, 60, 108, 103, 167, 107, 171, 244, 72, 244, 70, 244, 71, 244, 76, 213, 245, 71, 245, 73, 244, 72, 244, 69, 244, 76, 245, 80, 213, 244, 74, 244, 70, 244, 71, 245, 74, 244, 94})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Control()
    {
      Control control = this;
      this.timer = new Interval(2);
      this.hiscore = false;
      this.wasPaused = false;
      this.saves = new Saves();
      this.sound = new SoundControl();
      Events.on((Class) ClassLiteral<EventType.ClientLoadEvent>.Value, (Cons) new Control.__\u003C\u003EAnon0());
      Events.on((Class) ClassLiteral<EventType.StateChangeEvent>.Value, (Cons) new Control.__\u003C\u003EAnon1());
      Events.on((Class) ClassLiteral<EventType.PlayEvent>.Value, (Cons) new Control.__\u003C\u003EAnon2());
      Events.on((Class) ClassLiteral<EventType.WorldLoadEvent>.Value, (Cons) new Control.__\u003C\u003EAnon3());
      Events.on((Class) ClassLiteral<EventType.SaveLoadEvent>.Value, (Cons) new Control.__\u003C\u003EAnon4(this));
      Events.on((Class) ClassLiteral<EventType.ResetEvent>.Value, (Cons) new Control.__\u003C\u003EAnon5(this));
      Events.on((Class) ClassLiteral<EventType.WaveEvent>.Value, (Cons) new Control.__\u003C\u003EAnon6(this));
      Events.on((Class) ClassLiteral<EventType.GameOverEvent>.Value, (Cons) new Control.__\u003C\u003EAnon7());
      Events.on((Class) ClassLiteral<EventType.WorldLoadEvent>.Value, (Cons) new Control.__\u003C\u003EAnon8());
      Events.on((Class) ClassLiteral<EventType.WorldLoadEvent>.Value, (Cons) new Control.__\u003C\u003EAnon9());
      Events.on((Class) ClassLiteral<EventType.UnlockEvent>.Value, (Cons) new Control.__\u003C\u003EAnon10(this));
      Events.on((Class) ClassLiteral<EventType.SectorCaptureEvent>.Value, (Cons) new Control.__\u003C\u003EAnon11(this));
      Events.on((Class) ClassLiteral<EventType.BlockBuildEndEvent>.Value, (Cons) new Control.__\u003C\u003EAnon12());
      Events.on((Class) ClassLiteral<EventType.BlockDestroyEvent>.Value, (Cons) new Control.__\u003C\u003EAnon13());
      Events.on((Class) ClassLiteral<EventType.UnitDestroyEvent>.Value, (Cons) new Control.__\u003C\u003EAnon14());
      Events.on((Class) ClassLiteral<EventType.GameOverEvent>.Value, (Cons) new Control.__\u003C\u003EAnon15(this));
      Events.run((object) EventType.Trigger.__\u003C\u003EnewGame, (Runnable) new Control.__\u003C\u003EAnon16());
    }

    [LineNumberTable(new byte[] {160, 142, 106, 121, 159, 0, 103, 141, 171, 108, 170, 117})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void createPlayer()
    {
      Vars.player = Player.create();
      Vars.player.name = Core.settings.getString("name");
      Vars.player.color.set(Core.settings.getInt("color-0"));
      this.input = !Vars.mobile ? (InputHandler) new DesktopInput() : (InputHandler) new MobileInput();
      if (Vars.state.isGame())
        Vars.player.add();
      Events.on((Class) ClassLiteral<EventType.ClientLoadEvent>.Value, (Cons) new Control.__\u003C\u003EAnon18(this));
    }

    [LineNumberTable(new byte[] {160, 190, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void playSector([arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})] Sector origin, Sector sector) => this.playSector(origin, sector, new WorldReloader());

    [LineNumberTable(new byte[] {160, 194, 248, 160, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void playSector([arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})] Sector _param1, Sector _param2, WorldReloader _param3) => Vars.ui.loadAnd((Runnable) new Control.__\u003C\u003EAnon20(this, _param2, _param3, _param1));

    [LineNumberTable(new byte[] {160, 132, 141, 127, 0, 127, 14, 139, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void checkAutoUnlocks()
    {
      if (Vars.net.client())
        return;
      Iterator iterator = TechTree.all.iterator();
      while (iterator.hasNext())
      {
        TechTree.TechNode techNode = (TechTree.TechNode) iterator.next();
        if (!techNode.content.unlocked() && techNode.requirements.Length == 0 && !techNode.objectives.contains((Boolf) new Control.__\u003C\u003EAnon17()))
          techNode.content.unlock();
      }
    }

    [Modifiers]
    [LineNumberTable(new byte[] {14, 125, 213})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024new\u00241([In] EventType.ClientLoadEvent obj0)
    {
      if (!Vars.mods.skipModLoading() || !Vars.mods.list().any())
        return;
      Time.runTask(4f, (Runnable) new Control.__\u003C\u003EAnon36());
    }

    [Modifiers]
    [LineNumberTable(new byte[] {22, 127, 41, 159, 2})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024new\u00242([In] EventType.StateChangeEvent obj0)
    {
      if ((!object.ReferenceEquals((object) obj0.__\u003C\u003Efrom, (object) GameState.State.__\u003C\u003Eplaying) || !object.ReferenceEquals((object) obj0.__\u003C\u003Eto, (object) GameState.State.__\u003C\u003Emenu)) && (!object.ReferenceEquals((object) obj0.__\u003C\u003Efrom, (object) GameState.State.__\u003C\u003Emenu) || object.ReferenceEquals((object) obj0.__\u003C\u003Eto, (object) GameState.State.__\u003C\u003Emenu)))
        return;
      Platform platform = Vars.platform;
      Objects.requireNonNull((object) platform);
      Time.runTask(5f, (Runnable) new Control.__\u003C\u003EAnon35(platform));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {28, 121, 138, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024new\u00243([In] EventType.PlayEvent obj0)
    {
      Vars.player.team(Vars.netServer.assignTeam(Vars.player));
      Vars.player.add();
      Vars.state.set(GameState.State.__\u003C\u003Eplaying);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {35, 127, 3, 107, 99, 107, 145, 98, 149})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024new\u00244([In] EventType.WorldLoadEvent obj0)
    {
      if (Mathf.zero(Vars.player.x) && Mathf.zero(Vars.player.y))
      {
        CoreBlock.CoreBuild coreBuild = Vars.player.bestCore();
        if (coreBuild == null)
          return;
        Vars.player.set((Position) coreBuild);
        Core.camera.__\u003C\u003Eposition.set((Position) coreBuild);
      }
      else
        Core.camera.__\u003C\u003Eposition.set((Position) Vars.player);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {47, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u00245([In] EventType.SaveLoadEvent obj0) => this.input.checkUnit();

    [Modifiers]
    [LineNumberTable(new byte[] {51, 138, 103, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u00246([In] EventType.ResetEvent obj0)
    {
      Vars.player.reset();
      this.hiscore = false;
      this.saves.resetSave();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {58, 123, 103, 185, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u00247([In] EventType.WaveEvent obj0)
    {
      if (Vars.state.map.getHightScore() < Vars.state.wave)
      {
        this.hiscore = true;
        Vars.state.map.setHighScore(Vars.state.wave);
      }
      Sounds.wave.play();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {67, 121, 159, 14, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024new\u00248([In] EventType.GameOverEvent obj0)
    {
      Vars.state.stats.wavesLasted = Vars.state.wave;
      Effect.shake(5f, 6f, Core.camera.__\u003C\u003Eposition.x, Core.camera.__\u003C\u003Eposition.y);
      Call.gameOver(obj0.__\u003C\u003Ewinner);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {75, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024new\u00249([In] EventType.WorldLoadEvent obj0) => Vars.player.add();

    [Modifiers]
    [LineNumberTable(129)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024new\u002411([In] EventType.WorldLoadEvent obj0) => Core.app.post((Runnable) new Control.__\u003C\u003EAnon34());

    [Modifiers]
    [LineNumberTable(new byte[] {92, 109, 181, 134, 112, 127, 3, 127, 29, 159, 20, 133})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u002414([In] EventType.UnlockEvent obj0)
    {
      if (obj0.__\u003C\u003Econtent.showUnlock())
        Vars.ui.hudfrag.showUnlock(obj0.__\u003C\u003Econtent);
      this.checkAutoUnlocks();
      if (!(obj0.__\u003C\u003Econtent is SectorPreset))
        return;
      Iterator iterator = TechTree.all.iterator();
      while (iterator.hasNext())
      {
        TechTree.TechNode techNode = (TechTree.TechNode) iterator.next();
        if (!techNode.content.unlocked() && techNode.objectives.contains((Boolf) new Control.__\u003C\u003EAnon32(obj0)) && !techNode.objectives.contains((Boolf) new Control.__\u003C\u003EAnon33()))
          Vars.ui.hudfrag.showToast((Drawable) new TextureRegionDrawable(techNode.content.icon(Cicon.__\u003C\u003Elarge)), Core.bundle.get("available"));
      }
    }

    [Modifiers]
    [LineNumberTable(new byte[] {108, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u002415([In] EventType.SectorCaptureEvent obj0) => this.checkAutoUnlocks();

    [Modifiers]
    [LineNumberTable(new byte[] {112, 119, 104, 153, 183})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024new\u002416([In] EventType.BlockBuildEndEvent obj0)
    {
      if (!object.ReferenceEquals((object) obj0.__\u003C\u003Eteam, (object) Vars.player.team()))
        return;
      if (obj0.__\u003C\u003Ebreaking)
        ++Vars.state.stats.buildingsDeconstructed;
      else
        ++Vars.state.stats.buildingsBuilt;
    }

    [Modifiers]
    [LineNumberTable(new byte[] {122, 124, 151})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024new\u002417([In] EventType.BlockDestroyEvent obj0)
    {
      if (!object.ReferenceEquals((object) obj0.__\u003C\u003Etile.team(), (object) Vars.player.team()))
        return;
      ++Vars.state.stats.buildingsDestroyed;
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 64, 124, 151})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024new\u002418([In] EventType.UnitDestroyEvent obj0)
    {
      if (object.ReferenceEquals((object) obj0.__\u003C\u003Eunit.team(), (object) Vars.player.team()))
        return;
      ++Vars.state.stats.enemyUnitsDestroyed;
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 71, 191, 0, 109, 176})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u002419([In] EventType.GameOverEvent obj0)
    {
      if (!Vars.state.isCampaign() || Vars.net.client() || (Vars.headless || this.saves.getCurrent() == null))
        return;
      this.saves.getCurrent().save();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 81, 139, 164, 114, 106, 106, 191, 2, 116, 116, 117, 113, 139, 250, 74})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024new\u002424()
    {
      CoreBlock.CoreBuild coreBuild = Vars.player.closestCore();
      if (coreBuild == null)
        return;
      if (Core.settings.getInt("musicvol") > 0)
      {
        Musics.land.stop();
        Musics.land.play();
        Musics.land.setVolume((float) Core.settings.getInt("musicvol") / 100f);
      }
      Core.app.post((Runnable) new Control.__\u003C\u003EAnon28());
      Vars.renderer.zoomIn(Fx.__\u003C\u003EcoreLand.lifetime);
      Core.app.post((Runnable) new Control.__\u003C\u003EAnon29((Building) coreBuild));
      Core.camera.__\u003C\u003Eposition.set((Position) coreBuild);
      Vars.player.set((Position) coreBuild);
      Time.run(Fx.__\u003C\u003EcoreLand.lifetime, (Runnable) new Control.__\u003C\u003EAnon30((Building) coreBuild));
    }

    [Modifiers]
    [LineNumberTable(249)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024checkAutoUnlocks\u002425([In] Objectives.Objective obj0) => !obj0.complete();

    [Modifiers]
    [LineNumberTable(270)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024createPlayer\u002426([In] EventType.ClientLoadEvent obj0) => this.input.add();

    [Modifiers]
    [LineNumberTable(new byte[] {160, 172, 106, 108, 107, 112, 112, 106, 125, 159, 51, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024playMap\u002427([In] Map obj0, [In] Rules obj1)
    {
      Vars.logic.reset();
      Vars.world.loadMap(obj0, obj1);
      Vars.state.rules = obj1;
      Vars.state.rules.sector = (Sector) null;
      Vars.state.rules.editor = false;
      Vars.logic.play();
      if (Core.settings.getBool("savecreate") && !Vars.world.isInvalidMap())
      {
        Saves saves = Vars.control.saves;
        StringBuilder stringBuilder = new StringBuilder().append(obj0.name()).append(" ");
        SimpleDateFormat.__\u003Cclinit\u003E();
        string str = ((DateFormat) new SimpleDateFormat("MMM dd h:mm", Locale.getDefault())).format(new Date());
        string name = stringBuilder.append(str).toString();
        saves.addSave(name);
      }
      Events.fire((object) EventType.Trigger.__\u003C\u003EnewGame);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 195, 121, 116, 175, 111, 103, 108, 176, 102, 102, 103, 176, 190, 141, 103, 134, 105, 197, 118, 186, 170, 139, 159, 1, 140, 176, 191, 85, 148, 127, 23, 120, 100, 127, 13, 113, 178, 101, 222, 106, 106, 138, 177, 124, 149, 107, 170, 111, 251, 72, 226, 58, 98, 103, 103, 117, 102, 136, 145, 102, 107, 144, 108, 108, 106, 112, 107, 106, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024playSector\u002429([In] Sector obj0, [In] WorldReloader obj1, [In] Sector obj2)
    {
      if (this.saves.getCurrent() != null && Vars.state.isGame())
      {
        Vars.control.saves.getCurrent().save();
        Vars.control.saves.resetSave();
      }
      Vars.ui.planet.hide();
      Saves.SaveSlot save = obj0.save;
      obj0.__\u003C\u003Eplanet.setLastSector(obj0);
      if (save != null)
      {
        if (!Vars.clearSectors)
        {
          SaveIO.SaveException saveException;
          try
          {
            obj1.begin();
            save.load();
            save.setAutosave(true);
            Vars.state.rules.sector = obj0;
            if (Vars.state.rules.defaultTeam.cores().isEmpty())
            {
              if (obj0.info.spawnPosition == 0)
              {
                obj0.save = (Saves.SaveSlot) null;
                save.delete();
                this.playSector(obj2, obj0, obj1);
                return;
              }
              Tile tile1 = Vars.world.tile(obj0.info.spawnPosition);
              tile1.setBlock(Blocks.coreShard, Vars.state.rules.defaultTeam);
              SectorDamage.apply(1f);
              Vars.state.wave = 1;
              Vars.state.wavetime = Vars.state.rules.waveSpacing * 2f;
              obj0.info.wasCaptured = false;
              Vars.state.rules.waves = true;
              Vars.state.rules.winWave = !Vars.state.rules.attackMode ? (obj0.preset == null || obj0.preset.captureWave <= 0 ? (Vars.state.rules.winWave <= Vars.state.wave ? 30 : Vars.state.rules.winWave) : obj0.preset.captureWave) : -1;
              if (Vars.state.rules.attackMode)
              {
                Iterator iterator = Vars.state.rules.waveTeam.data().blocks.iterator();
                while (iterator.hasNext())
                {
                  Teams.BlockPlan blockPlan = (Teams.BlockPlan) iterator.next();
                  Tile tile2 = Vars.world.tile((int) blockPlan.__\u003C\u003Ex, (int) blockPlan.__\u003C\u003Ey);
                  if (tile2 != null)
                  {
                    tile2.setBlock(Vars.content.block((int) blockPlan.__\u003C\u003Eblock), Vars.state.rules.waveTeam, (int) blockPlan.__\u003C\u003Erotation);
                    if (blockPlan.__\u003C\u003Econfig != null && tile2.build != null)
                      tile2.build.configureAny(blockPlan.__\u003C\u003Econfig);
                  }
                }
                Vars.state.rules.waveTeam.data().blocks.clear();
              }
              Groups.unit.clear();
              Groups.fire.clear();
              Groups.puddle.clear();
              Schematics.placeLaunchLoadout((int) tile1.x, (int) tile1.y);
              Vars.player.set((float) ((int) tile1.x * 8), (float) ((int) tile1.y * 8));
              Core.camera.__\u003C\u003Eposition.set((Position) Vars.player);
              Events.fire((object) new EventType.SectorLaunchEvent(obj0));
              Events.fire((object) EventType.Trigger.__\u003C\u003EnewGame);
            }
            Vars.state.set(GameState.State.__\u003C\u003Eplaying);
            obj1.end();
            goto label_18;
          }
          catch (SaveIO.SaveException ex)
          {
            saveException = (SaveIO.SaveException) ByteCodeHelper.MapException<SaveIO.SaveException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
          }
          Log.err((Exception) saveException);
          obj0.save = (Saves.SaveSlot) null;
          Time.runTask(10f, (Runnable) new Control.__\u003C\u003EAnon27());
          save.delete();
          this.playSector(obj2, obj0);
label_18:
          Vars.ui.planet.hide();
          return;
        }
      }
      obj1.begin();
      Vars.world.loadSector(obj0);
      Vars.state.rules.sector = obj0;
      obj0.info.origin = obj2;
      obj0.info.destination = obj2;
      Vars.logic.play();
      Vars.control.saves.saveSector(obj0);
      Events.fire((object) new EventType.SectorLaunchEvent(obj0));
      Events.fire((object) EventType.Trigger.__\u003C\u003EnewGame);
      obj1.end();
    }

    [Modifiers]
    [LineNumberTable(458)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024init\u002434() => Core.app.post((Runnable) new Control.__\u003C\u003EAnon23());

    [Modifiers]
    [LineNumberTable(535)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024update\u002435([In] Item obj0, [In] int obj1) => obj0.unlock();

    [Modifiers]
    [LineNumberTable(new byte[] {161, 89, 107, 135, 111, 236, 71, 252, 69, 144, 123, 146, 252, 69, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024init\u002433()
    {
      BaseDialog baseDialog = new BaseDialog("@confirm");
      baseDialog.setFillParent(true);
      float[] numArray = new float[1]{ 660f };
      Runnable listener = (Runnable) new Control.__\u003C\u003EAnon24(baseDialog);
      baseDialog.__\u003C\u003Econt.label((Prov) new Control.__\u003C\u003EAnon25(numArray, listener)).pad(10f).expand().center();
      baseDialog.__\u003C\u003Ebuttons.defaults().size(200f, 60f);
      baseDialog.__\u003C\u003Ebuttons.button("@uiscale.cancel", listener);
      baseDialog.__\u003C\u003Ebuttons.button("@ok", (Runnable) new Control.__\u003C\u003EAnon26(baseDialog));
      baseDialog.show();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 94, 118, 117, 102, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024init\u002430([In] BaseDialog obj0)
    {
      Core.settings.put("uiscale", (object) Integer.valueOf(100));
      Core.settings.put("uiscalechanged", (object) Boolean.valueOf(false));
      obj0.hide();
      Core.app.exit();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 101, 106, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static CharSequence lambda\u0024init\u002431([In] float[] obj0, [In] Runnable obj1)
    {
      if ((double) obj0[0] <= 0.0)
        obj1.run();
      I18NBundle bundle = Core.bundle;
      object[] objArray = new object[1];
      float[] numArray1 = obj0;
      int index1 = 0;
      float[] numArray2 = numArray1;
      float[] numArray3 = numArray2;
      int num1 = index1;
      float num2 = numArray2[index1] - Time.delta;
      int index2 = num1;
      float[] numArray4 = numArray3;
      double num3 = (double) num2;
      numArray4[index2] = num2;
      objArray[0] = (object) Integer.valueOf(ByteCodeHelper.f2i((float) (num3 / 60.0)));
      object obj = (object) bundle.format("uiscale.reset", objArray);
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj;
      return charSequence;
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 111, 117, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024init\u002432([In] BaseDialog obj0)
    {
      Core.settings.put("uiscalechanged", (object) Boolean.valueOf(false));
      obj0.hide();
    }

    [Modifiers]
    [LineNumberTable(393)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024playSector\u002428() => Vars.ui.showErrorMessage("@save.corrupted");

    [Modifiers]
    [LineNumberTable(206)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024new\u002420() => Vars.ui.hudfrag.showLand();

    [Modifiers]
    [LineNumberTable(208)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024new\u002421([In] Building obj0) => Fx.__\u003C\u003EcoreLand.at(obj0.getX(), obj0.getY(), 0.0f, (object) obj0.block);

    [Modifiers]
    [LineNumberTable(new byte[] {160, 99, 107, 144, 111, 127, 24, 127, 86, 31, 6, 197})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024new\u002423([In] Building obj0)
    {
      Fx.__\u003C\u003Elaunch.at((Position) obj0);
      Effect.shake(5f, 5f, (Position) obj0);
      if (!Vars.state.isCampaign())
        return;
      Vars.ui.announce(new StringBuilder().append("[accent]").append(Vars.state.rules.sector.name()).append("\n").append(!Vars.state.rules.sector.info.resources.any() ? "" : new StringBuilder().append("[lightgray]").append(Core.bundle.get("sectors.resources")).append("[white] ").append(Vars.state.rules.sector.info.resources.toString(" ", (Func) new Control.__\u003C\u003EAnon31())).toString()).toString(), 5f);
    }

    [Modifiers]
    [LineNumberTable(219)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static string lambda\u0024new\u002422([In] UnlockableContent obj0) => obj0.emoji();

    [Modifiers]
    [LineNumberTable(150)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024new\u002412(
      [In] EventType.UnlockEvent obj0,
      [In] Objectives.Objective obj1)
    {
      Objectives.Objective objective = obj1;
      Objectives.SectorComplete sectorComplete;
      return objective is Objectives.SectorComplete && object.ReferenceEquals((object) (sectorComplete = (Objectives.SectorComplete) objective), (object) (Objectives.SectorComplete) objective) && object.ReferenceEquals((object) sectorComplete.preset, (object) obj0.__\u003C\u003Econtent);
    }

    [Modifiers]
    [LineNumberTable(150)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024new\u002413([In] Objectives.Objective obj0) => !obj0.complete();

    [Modifiers]
    [LineNumberTable(new byte[] {80, 157, 111, 221, 226, 61, 97, 112, 175})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024new\u002410()
    {
      if (!Vars.state.rules.pvp)
        return;
      if (Vars.net.active())
        return;
      IOException ioException1;
      try
      {
        Vars.net.host(6567);
        Vars.player.admin(true);
        return;
      }
      catch (IOException ex)
      {
        ioException1 = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
      }
      IOException ioException2 = ioException1;
      Vars.ui.showException("@server.error", (Exception) ioException2);
      Vars.state.set(GameState.State.__\u003C\u003Emenu);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {16, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024new\u00240() => Vars.ui.showInfo("@mods.initfailed");

    [LineNumberTable(new byte[] {160, 114, 159, 2, 144, 159, 13, 159, 7, 230, 60, 229, 71, 134, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void loadAsync()
    {
      Draw.scl = 1f / (float) Core.atlas.find("scale_marker").width;
      Core.input.setCatch(KeyCode.__\u003C\u003Eback, true);
      Core.settings.defaults((object) "ip", (object) "localhost", (object) "color-0", (object) Integer.valueOf(Vars.__\u003C\u003EplayerColors[8].rgba()), (object) "name", (object) "", (object) "lastBuild", (object) Integer.valueOf(0));
      this.createPlayer();
      this.saves.load();
    }

    [LineNumberTable(new byte[] {160, 160, 108, 118, 107, 103, 103, 99, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setInput(InputHandler newInput)
    {
      Block block = this.input.block;
      int num = Core.input.getInputProcessors().contains((object) this.input) ? 1 : 0;
      this.input.remove();
      this.input = newInput;
      newInput.block = block;
      if (num == 0)
        return;
      newInput.add();
    }

    [LineNumberTable(new byte[] {160, 171, 246, 76})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void playMap(Map map, Rules rules) => Vars.ui.loadAnd((Runnable) new Control.__\u003C\u003EAnon19(map, rules));

    [LineNumberTable(new byte[] {160, 186, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void playSector(Sector sector) => this.playSector(sector, sector);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isHighScore() => this.hiscore;

    [LineNumberTable(new byte[] {161, 51, 159, 38, 121, 188, 2, 97, 198, 127, 15, 102, 130, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void dispose()
    {
      if (this.saves != null && this.saves.getCurrent() != null && (this.saves.getCurrent().isAutosave() && !Vars.net.client()))
      {
        if (!Vars.state.isMenu())
        {
          Exception th;
          try
          {
            SaveIO.save(Vars.control.saves.getCurrent().__\u003C\u003Efile);
            Log.info((object) "Saved on exit.");
            goto label_5;
          }
          catch (Exception ex)
          {
            th = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
          }
          Log.err(th);
        }
      }
label_5:
      Iterator iterator = Core.assets.getAll((Class) ClassLiteral<Music>.Value, new Seq()).iterator();
      while (iterator.hasNext())
        ((Music) iterator.next()).stop();
      Vars.net.dispose();
    }

    [LineNumberTable(new byte[] {161, 69, 114, 117, 159, 1})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void pause()
    {
      if (!Core.settings.getBool("backgroundpause", true))
        return;
      this.wasPaused = Vars.state.@is(GameState.State.__\u003C\u003Epaused);
      if (!Vars.state.@is(GameState.State.__\u003C\u003Eplaying))
        return;
      Vars.state.set(GameState.State.__\u003C\u003Epaused);
    }

    [LineNumberTable(new byte[] {161, 77, 127, 12, 143})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void resume()
    {
      if (!Vars.state.@is(GameState.State.__\u003C\u003Epaused) || this.wasPaused || !Core.settings.getBool("backgroundpause", true))
        return;
      Vars.state.set(GameState.State.__\u003C\u003Eplaying);
    }

    [LineNumberTable(new byte[] {161, 84, 170, 114, 244, 94})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void init()
    {
      Vars.platform.updateRPC();
      if (!Core.settings.getBool("uiscalechanged", false))
        return;
      Core.app.post((Runnable) new Control.__\u003C\u003EAnon21());
    }

    [LineNumberTable(new byte[] {161, 123, 136, 203, 159, 1, 34, 161, 139, 139, 113, 112, 99, 159, 2, 149, 187, 127, 3, 116, 155, 127, 24, 159, 24, 111, 171, 115, 202, 117, 123, 181, 127, 64, 191, 8, 127, 26, 113, 113, 125, 112, 207, 127, 22, 170, 130, 108, 165, 127, 47, 170})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void update()
    {
      if (Core.assets == null)
        return;
      this.saves.update();
      try
      {
        Core.assets.update();
        goto label_7;
      }
      catch (Exception ex)
      {
        if (ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 2) == null)
          throw;
      }
label_7:
      this.input.updateState();
      this.sound.update();
      if (Core.input.keyTap((KeyBinds.KeyBind) Binding.__\u003C\u003Efullscreen))
      {
        int num = Core.settings.getBool("fullscreen") ? 1 : 0;
        if (num != 0)
          Core.graphics.setWindowedMode(Core.graphics.getWidth(), Core.graphics.getHeight());
        else
          Core.graphics.setFullscreenMode(Core.graphics.getDisplayMode());
        Core.settings.put("fullscreen", (object) Boolean.valueOf(num == 0));
      }
      if (Float.isNaN(Vars.player.x) || Float.isNaN(Vars.player.y))
      {
        Vars.player.set(0.0f, 0.0f);
        if (!Vars.player.dead())
          Vars.player.unit().kill();
      }
      if (Float.isNaN(Core.camera.__\u003C\u003Eposition.x))
        Core.camera.__\u003C\u003Eposition.x = (float) Vars.world.unitWidth() / 2f;
      if (Float.isNaN(Core.camera.__\u003C\u003Eposition.y))
        Core.camera.__\u003C\u003Eposition.y = (float) Vars.world.unitHeight() / 2f;
      if (Vars.state.isGame())
      {
        this.input.update();
        if (this.timer.get(0, 300f))
          Vars.platform.updateRPC();
        CoreBlock.CoreBuild coreBuild = Vars.state.rules.defaultTeam.core();
        if (!Vars.net.client() && coreBuild != null && Vars.state.isCampaign())
          coreBuild.items.each((ItemModule.ItemConsumer) new Control.__\u003C\u003EAnon22());
        if (Core.input.keyTap((KeyBinds.KeyBind) Binding.__\u003C\u003Epause) && !Core.scene.hasDialog() && (!Core.scene.hasKeyboard() && !Vars.ui.restart.isShown()) && (Vars.state.@is(GameState.State.__\u003C\u003Epaused) || Vars.state.@is(GameState.State.__\u003C\u003Eplaying)))
          Vars.state.set(!Vars.state.@is(GameState.State.__\u003C\u003Eplaying) ? GameState.State.__\u003C\u003Eplaying : GameState.State.__\u003C\u003Epaused);
        if (Core.input.keyTap((KeyBinds.KeyBind) Binding.__\u003C\u003Emenu) && !Vars.ui.restart.isShown() && !Vars.ui.minimapfrag.shown())
        {
          if (Vars.ui.chatfrag.shown())
            Vars.ui.chatfrag.hide();
          else if (!Vars.ui.paused.isShown() && !Core.scene.hasDialog())
          {
            Vars.ui.paused.show();
            Vars.state.set(GameState.State.__\u003C\u003Epaused);
          }
        }
        if (Vars.mobile || !Core.input.keyTap((KeyBinds.KeyBind) Binding.__\u003C\u003Escreenshot) || (Core.scene.getKeyboardFocus() is TextField || Core.scene.hasKeyboard()))
          return;
        Vars.renderer.takeMapScreenshot();
      }
      else
      {
        if (!Vars.state.isPaused())
          Time.update();
        if (Core.scene.hasDialog() || Core.scene.__\u003C\u003Eroot.getChildren().isEmpty() || (Core.scene.__\u003C\u003Eroot.getChildren().peek() is Dialog || !Core.input.keyTap(KeyCode.__\u003C\u003Eback)))
          return;
        Vars.platform.hide();
      }
    }

    [HideFromJava]
    public virtual void resize([In] int obj0, [In] int obj1) => ApplicationListener.\u003Cdefault\u003Eresize((ApplicationListener) this, obj0, obj1);

    [HideFromJava]
    public virtual void exit() => ApplicationListener.\u003Cdefault\u003Eexit((ApplicationListener) this);

    [HideFromJava]
    public virtual void fileDropped([In] Fi obj0) => ApplicationListener.\u003Cdefault\u003EfileDropped((ApplicationListener) this, obj0);

    [HideFromJava]
    public virtual void loadSync() => Loadable.\u003Cdefault\u003EloadSync((Loadable) this);

    [HideFromJava]
    public virtual string getName() => Loadable.\u003Cdefault\u003EgetName((Loadable) this);

    [HideFromJava]
    public virtual Seq getDependencies() => Loadable.\u003Cdefault\u003EgetDependencies((Loadable) this);

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Cons
    {
      internal __\u003C\u003EAnon0()
      {
      }

      public void get([In] object obj0) => Control.lambda\u0024new\u00241((EventType.ClientLoadEvent) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Cons
    {
      internal __\u003C\u003EAnon1()
      {
      }

      public void get([In] object obj0) => Control.lambda\u0024new\u00242((EventType.StateChangeEvent) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon2 : Cons
    {
      internal __\u003C\u003EAnon2()
      {
      }

      public void get([In] object obj0) => Control.lambda\u0024new\u00243((EventType.PlayEvent) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon3 : Cons
    {
      internal __\u003C\u003EAnon3()
      {
      }

      public void get([In] object obj0) => Control.lambda\u0024new\u00244((EventType.WorldLoadEvent) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon4 : Cons
    {
      private readonly Control arg\u00241;

      internal __\u003C\u003EAnon4([In] Control obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024new\u00245((EventType.SaveLoadEvent) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon5 : Cons
    {
      private readonly Control arg\u00241;

      internal __\u003C\u003EAnon5([In] Control obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024new\u00246((EventType.ResetEvent) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon6 : Cons
    {
      private readonly Control arg\u00241;

      internal __\u003C\u003EAnon6([In] Control obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024new\u00247((EventType.WaveEvent) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon7 : Cons
    {
      internal __\u003C\u003EAnon7()
      {
      }

      public void get([In] object obj0) => Control.lambda\u0024new\u00248((EventType.GameOverEvent) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon8 : Cons
    {
      internal __\u003C\u003EAnon8()
      {
      }

      public void get([In] object obj0) => Control.lambda\u0024new\u00249((EventType.WorldLoadEvent) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon9 : Cons
    {
      internal __\u003C\u003EAnon9()
      {
      }

      public void get([In] object obj0) => Control.lambda\u0024new\u002411((EventType.WorldLoadEvent) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon10 : Cons
    {
      private readonly Control arg\u00241;

      internal __\u003C\u003EAnon10([In] Control obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024new\u002414((EventType.UnlockEvent) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon11 : Cons
    {
      private readonly Control arg\u00241;

      internal __\u003C\u003EAnon11([In] Control obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024new\u002415((EventType.SectorCaptureEvent) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon12 : Cons
    {
      internal __\u003C\u003EAnon12()
      {
      }

      public void get([In] object obj0) => Control.lambda\u0024new\u002416((EventType.BlockBuildEndEvent) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon13 : Cons
    {
      internal __\u003C\u003EAnon13()
      {
      }

      public void get([In] object obj0) => Control.lambda\u0024new\u002417((EventType.BlockDestroyEvent) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon14 : Cons
    {
      internal __\u003C\u003EAnon14()
      {
      }

      public void get([In] object obj0) => Control.lambda\u0024new\u002418((EventType.UnitDestroyEvent) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon15 : Cons
    {
      private readonly Control arg\u00241;

      internal __\u003C\u003EAnon15([In] Control obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024new\u002419((EventType.GameOverEvent) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon16 : Runnable
    {
      internal __\u003C\u003EAnon16()
      {
      }

      public void run() => Control.lambda\u0024new\u002424();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon17 : Boolf
    {
      internal __\u003C\u003EAnon17()
      {
      }

      public bool get([In] object obj0) => (Control.lambda\u0024checkAutoUnlocks\u002425((Objectives.Objective) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon18 : Cons
    {
      private readonly Control arg\u00241;

      internal __\u003C\u003EAnon18([In] Control obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024createPlayer\u002426((EventType.ClientLoadEvent) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon19 : Runnable
    {
      private readonly Map arg\u00241;
      private readonly Rules arg\u00242;

      internal __\u003C\u003EAnon19([In] Map obj0, [In] Rules obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => Control.lambda\u0024playMap\u002427(this.arg\u00241, this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon20 : Runnable
    {
      private readonly Control arg\u00241;
      private readonly Sector arg\u00242;
      private readonly WorldReloader arg\u00243;
      private readonly Sector arg\u00244;

      internal __\u003C\u003EAnon20([In] Control obj0, [In] Sector obj1, [In] WorldReloader obj2, [In] Sector obj3)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
        this.arg\u00244 = obj3;
      }

      public void run() => this.arg\u00241.lambda\u0024playSector\u002429(this.arg\u00242, this.arg\u00243, this.arg\u00244);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon21 : Runnable
    {
      internal __\u003C\u003EAnon21()
      {
      }

      public void run() => Control.lambda\u0024init\u002434();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon22 : ItemModule.ItemConsumer
    {
      internal __\u003C\u003EAnon22()
      {
      }

      public void accept([In] Item obj0, [In] int obj1) => Control.lambda\u0024update\u002435(obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon23 : Runnable
    {
      internal __\u003C\u003EAnon23()
      {
      }

      public void run() => Control.lambda\u0024init\u002433();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon24 : Runnable
    {
      private readonly BaseDialog arg\u00241;

      internal __\u003C\u003EAnon24([In] BaseDialog obj0) => this.arg\u00241 = obj0;

      public void run() => Control.lambda\u0024init\u002430(this.arg\u00241);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon25 : Prov
    {
      private readonly float[] arg\u00241;
      private readonly Runnable arg\u00242;

      internal __\u003C\u003EAnon25([In] float[] obj0, [In] Runnable obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public object get() => (object) Control.lambda\u0024init\u002431(this.arg\u00241, this.arg\u00242).__\u003Cref\u003E;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon26 : Runnable
    {
      private readonly BaseDialog arg\u00241;

      internal __\u003C\u003EAnon26([In] BaseDialog obj0) => this.arg\u00241 = obj0;

      public void run() => Control.lambda\u0024init\u002432(this.arg\u00241);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon27 : Runnable
    {
      internal __\u003C\u003EAnon27()
      {
      }

      public void run() => Control.lambda\u0024playSector\u002428();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon28 : Runnable
    {
      internal __\u003C\u003EAnon28()
      {
      }

      public void run() => Control.lambda\u0024new\u002420();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon29 : Runnable
    {
      private readonly Building arg\u00241;

      internal __\u003C\u003EAnon29([In] Building obj0) => this.arg\u00241 = obj0;

      public void run() => Control.lambda\u0024new\u002421(this.arg\u00241);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon30 : Runnable
    {
      private readonly Building arg\u00241;

      internal __\u003C\u003EAnon30([In] Building obj0) => this.arg\u00241 = obj0;

      public void run() => Control.lambda\u0024new\u002423(this.arg\u00241);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon31 : Func
    {
      internal __\u003C\u003EAnon31()
      {
      }

      public object get([In] object obj0) => (object) Control.lambda\u0024new\u002422((UnlockableContent) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon32 : Boolf
    {
      private readonly EventType.UnlockEvent arg\u00241;

      internal __\u003C\u003EAnon32([In] EventType.UnlockEvent obj0) => this.arg\u00241 = obj0;

      public bool get([In] object obj0) => (Control.lambda\u0024new\u002412(this.arg\u00241, (Objectives.Objective) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon33 : Boolf
    {
      internal __\u003C\u003EAnon33()
      {
      }

      public bool get([In] object obj0) => (Control.lambda\u0024new\u002413((Objectives.Objective) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon34 : Runnable
    {
      internal __\u003C\u003EAnon34()
      {
      }

      public void run() => Control.lambda\u0024new\u002410();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon35 : Runnable
    {
      private readonly Platform arg\u00241;

      internal __\u003C\u003EAnon35([In] Platform obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.updateRPC();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon36 : Runnable
    {
      internal __\u003C\u003EAnon36()
      {
      }

      public void run() => Control.lambda\u0024new\u00240();
    }
  }
}
