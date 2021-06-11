// Decompiled with JetBrains decompiler
// Type: mindustry.game.Saves
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.@struct;
using arc.assets;
using arc.assets.loaders;
using arc.files;
using arc.func;
using arc.graphics;
using arc.util;
using arc.util.async;
using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.io;
using java.lang;
using java.text;
using java.util;
using mindustry.core;
using mindustry.io;
using mindustry.maps;
using mindustry.type;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.game
{
  public class Saves : Object
  {
    [Signature("Larc/struct/Seq<Lmindustry/game/Saves$SaveSlot;>;")]
    internal Seq saves;
    [arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})]
    internal Saves.SaveSlot current;
    [arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})]
    private Saves.SaveSlot lastSectorSave;
    internal AsyncExecutor previewExecutor;
    private bool saving;
    private float time;
    internal long totalPlaytime;
    private long lastTimestamp;

    [LineNumberTable(new byte[] {159, 177, 232, 54, 171, 236, 72, 153, 245, 71})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Saves()
    {
      Saves saves = this;
      this.saves = new Seq();
      this.previewExecutor = new AsyncExecutor(1);
      Core.assets.setLoader((Class) ClassLiteral<Texture>.Value, ".spreview", (AssetLoader) new SavePreviewLoader());
      Events.on((Class) ClassLiteral<EventType.StateChangeEvent>.Value, (Cons) new Saves.__\u003C\u003EAnon0(this));
    }

    [LineNumberTable(new byte[] {159, 190, 140, 123, 127, 13, 105, 109, 237, 60, 233, 72, 191, 1, 127, 8, 105, 110, 159, 25, 142, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void load()
    {
      this.saves.clear();
      Fi[] fiArray = Vars.saveDirectory.list();
      int length = fiArray.Length;
      for (int index = 0; index < length; ++index)
      {
        Fi file = fiArray[index];
        string str = file.name();
        object obj = (object) "backup";
        CharSequence charSequence1;
        charSequence1.__\u003Cref\u003E = (__Null) obj;
        CharSequence charSequence2 = charSequence1;
        if (!String.instancehelper_contains(str, charSequence2) && SaveIO.isSaveValid(file))
        {
          Saves.SaveSlot saveSlot = new Saves.SaveSlot(this, file);
          this.saves.add((object) saveSlot);
          saveSlot.meta = SaveIO.getMeta(file);
        }
      }
      this.lastSectorSave = (Saves.SaveSlot) this.saves.find((Boolf) new Saves.__\u003C\u003EAnon1());
      Iterator iterator = this.saves.iterator();
      while (iterator.hasNext())
      {
        Saves.SaveSlot saveSlot = (Saves.SaveSlot) iterator.next();
        if (saveSlot.getSector() != null)
        {
          if (saveSlot.getSector().save != null)
            Log.warn("Sector @ has two corresponding saves: @ and @", (object) saveSlot.getSector(), (object) saveSlot.getSector().save.__\u003C\u003Efile, (object) saveSlot.__\u003C\u003Efile);
          saveSlot.getSector().save = saveSlot;
        }
      }
    }

    [arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Saves.SaveSlot getCurrent() => this.current;

    [LineNumberTable(new byte[] {30, 121, 115, 106, 152, 171, 127, 26, 115, 123, 167, 189, 2, 97, 166, 150, 173, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void update()
    {
      if (this.current != null && Vars.state.isGame() && (!Vars.state.isPaused() || !Core.scene.hasDialog()))
      {
        if (this.lastTimestamp != 0L)
          this.totalPlaytime += Time.timeSinceMillis(this.lastTimestamp);
        this.lastTimestamp = Time.millis();
      }
      if (Vars.state.isGame() && !Vars.state.gameOver && (this.current != null && this.current.isAutosave()))
      {
        this.time += Time.delta;
        if ((double) this.time <= (double) (Core.settings.getInt("saveinterval") * 60))
          return;
        this.saving = true;
        Exception th;
        try
        {
          this.current.save();
          goto label_11;
        }
        catch (Exception ex)
        {
          th = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        }
        Log.err(th);
label_11:
        Time.runTask(3f, (Runnable) new Saves.__\u003C\u003EAnon2(this));
        this.time = 0.0f;
      }
      else
        this.time = 0.0f;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void resetSave() => this.current = (Saves.SaveSlot) null;

    [LineNumberTable(new byte[] {75, 104, 115, 123, 145, 108, 107, 108, 122})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void saveSector(Sector sector)
    {
      if (sector.save == null)
      {
        sector.save = new Saves.SaveSlot(this, this.getSectorFile(sector));
        sector.save.setName(sector.save.__\u003C\u003Efile.nameWithoutExtension());
        this.saves.add((object) sector.save);
      }
      sector.save.setAutosave(true);
      sector.save.save();
      this.lastSectorSave = sector.save;
      Core.settings.put("last-sector-save", (object) sector.save.getName());
    }

    [LineNumberTable(new byte[] {87, 109, 103, 108, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Saves.SaveSlot addSave(string name)
    {
      Saves.SaveSlot saveSlot = new Saves.SaveSlot(this, this.getNextSlotFile());
      saveSlot.setName(name);
      this.saves.add((object) saveSlot);
      saveSlot.save();
      return saveSlot;
    }

    [LineNumberTable(121)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Fi getSectorFile(Sector sector) => Vars.saveDirectory.child(new StringBuilder().append("sector-").append(sector.__\u003C\u003Eplanet.__\u003C\u003Ename).append("-").append(sector.__\u003C\u003Eid).append(".").append("msav").toString());

    [LineNumberTable(new byte[] {105, 130, 127, 24, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Fi getNextSlotFile()
    {
      int num = 0;
      Fi fi;
      while ((fi = Vars.saveDirectory.child(new StringBuilder().append(num).append(".").append("msav").toString())).exists())
        ++num;
      return fi;
    }

    [Modifiers]
    [LineNumberTable(new byte[] {159, 181, 114, 104, 104, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u00240([In] EventType.StateChangeEvent obj0)
    {
      if (!object.ReferenceEquals((object) obj0.__\u003C\u003Eto, (object) GameState.State.__\u003C\u003Emenu))
        return;
      this.totalPlaytime = 0L;
      this.lastTimestamp = 0L;
      this.current = (Saves.SaveSlot) null;
    }

    [Modifiers]
    [LineNumberTable(58)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024load\u00241([In] Saves.SaveSlot obj0) => obj0.isSector() && String.instancehelper_equals(obj0.getName(), (object) Core.settings.getString("last-sector-save", "<none>"));

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024update\u00242() => this.saving = false;

    [arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Saves.SaveSlot getLastSector() => this.lastSectorSave;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual long getTotalPlaytime() => this.totalPlaytime;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isSaving() => this.saving;

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {95, 109, 103, 108, 108, 113, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Saves.SaveSlot importSave(Fi file)
    {
      Saves.SaveSlot saveSlot = new Saves.SaveSlot(this, this.getNextSlotFile());
      saveSlot.importFile(file);
      saveSlot.setName(file.nameWithoutExtension());
      this.saves.add((object) saveSlot);
      saveSlot.meta = SaveIO.getMeta(saveSlot.__\u003C\u003Efile);
      this.current = saveSlot;
      return saveSlot;
    }

    [Signature("()Larc/struct/Seq<Lmindustry/game/Saves$SaveSlot;>;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Seq getSaveSlots() => this.saves;

    [LineNumberTable(new byte[] {118, 127, 6, 104, 134, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void deleteAll()
    {
      Iterator iterator = this.saves.copy().iterator();
      while (iterator.hasNext())
      {
        Saves.SaveSlot saveSlot = (Saves.SaveSlot) iterator.next();
        if (!saveSlot.isSector())
          saveSlot.delete();
      }
    }

    public class SaveSlot : Object
    {
      internal Fi __\u003C\u003Efile;
      internal bool requestedPreview;
      public SaveMeta meta;
      [Modifiers]
      internal Saves this\u00240;

      [LineNumberTable(313)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual bool isAutosave() => Core.settings.getBool(new StringBuilder().append("save-").append(this.index()).append("-autosave").toString(), true);

      [LineNumberTable(new byte[] {160, 83, 108, 108, 140, 107, 113, 108, 172, 108, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void save()
      {
        long totalPlaytime1 = this.this\u00240.totalPlaytime;
        long totalPlaytime2 = this.this\u00240.totalPlaytime;
        this.this\u00240.totalPlaytime = totalPlaytime1;
        SaveIO.save(this.__\u003C\u003Efile);
        this.meta = SaveIO.getMeta(this.__\u003C\u003Efile);
        if (Vars.state.isGame())
          this.this\u00240.current = this;
        this.this\u00240.totalPlaytime = totalPlaytime2;
        this.savePreview();
      }

      [Throws(new string[] {"mindustry.io.SaveIO$SaveException"})]
      [LineNumberTable(new byte[] {160, 72, 107, 113, 108, 118, 184, 2, 97, 140})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void load()
      {
        Exception exception;
        try
        {
          SaveIO.load(this.__\u003C\u003Efile);
          this.meta = SaveIO.getMeta(this.__\u003C\u003Efile);
          this.this\u00240.current = this;
          this.this\u00240.totalPlaytime = this.meta.timePlayed;
          this.savePreview();
          return;
        }
        catch (Exception ex)
        {
          exception = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        }
        Exception throwable = exception;
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new SaveIO.SaveException(throwable);
      }

      [LineNumberTable(new byte[] {159, 63, 98, 127, 26})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void setAutosave(bool save)
      {
        int num = save ? 1 : 0;
        Core.settings.put(new StringBuilder().append("save-").append(this.index()).append("-autosave").toString(), (object) Boolean.valueOf(num != 0));
      }

      [LineNumberTable(new byte[] {160, 223, 114, 145, 108, 115, 115, 172, 119, 149})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void delete()
      {
        if (SaveIO.backupFileFor(this.__\u003C\u003Efile).exists())
          SaveIO.backupFileFor(this.__\u003C\u003Efile).delete();
        this.__\u003C\u003Efile.delete();
        this.this\u00240.saves.remove((object) this, true);
        if (object.ReferenceEquals((object) this, (object) this.this\u00240.current))
          this.this\u00240.current = (Saves.SaveSlot) null;
        if (!Core.assets.isLoaded(this.loadPreviewFile().path()))
          return;
        Core.assets.unload(this.loadPreviewFile().path());
      }

      [LineNumberTable(new byte[] {160, 98, 119, 149, 252, 72})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void savePreview()
      {
        if (Core.assets.isLoaded(this.loadPreviewFile().path()))
          Core.assets.unload(this.loadPreviewFile().path());
        this.this\u00240.previewExecutor.submit((Runnable) new Saves.SaveSlot.__\u003C\u003EAnon0(this));
      }

      [LineNumberTable(246)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private Fi loadPreviewFile() => this.previewFile().sibling(new StringBuilder().append(this.previewFile().name()).append(".spreview").toString());

      [LineNumberTable(242)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private Fi previewFile() => Vars.mapPreviewDirectory.child(new StringBuilder().append("save_slot_").append(this.index()).append(".png").toString());

      [LineNumberTable(238)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private string index() => this.__\u003C\u003Efile.nameWithoutExtension();

      [LineNumberTable(297)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual bool isSector() => this.getSector() != null;

      [LineNumberTable(289)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual string[] getMods() => this.meta.mods;

      [LineNumberTable(293)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual Sector getSector() => this.meta == null || this.meta.rules == null ? (Sector) null : this.meta.rules.sector;

      [Modifiers]
      [LineNumberTable(new byte[] {160, 103, 122, 185, 2, 97, 134})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024savePreview\u00240()
      {
        Exception th;
        try
        {
          this.previewFile().writePNG(Vars.renderer.__\u003C\u003Eminimap.getPixmap());
          this.requestedPreview = false;
          return;
        }
        catch (Exception ex)
        {
          th = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        }
        Log.err(th);
      }

      [LineNumberTable(new byte[] {160, 66, 111, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public SaveSlot(Saves _param1, Fi file)
      {
        this.this\u00240 = _param1;
        // ISSUE: explicit constructor call
        base.\u002Ector();
        Saves.SaveSlot saveSlot = this;
        this.__\u003C\u003Efile = file;
      }

      [LineNumberTable(new byte[] {160, 112, 109, 98, 119, 123, 104, 123, 135})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual Texture previewTexture()
      {
        if (!this.previewFile().exists())
          return (Texture) null;
        if (Core.assets.isLoaded(this.loadPreviewFile().path()))
          return (Texture) Core.assets.get(this.loadPreviewFile().path());
        if (!this.requestedPreview)
        {
          Core.assets.load(new AssetDescriptor(this.loadPreviewFile(), (Class) ClassLiteral<Texture>.Value));
          this.requestedPreview = true;
        }
        return (Texture) null;
      }

      [LineNumberTable(250)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual bool isHidden() => this.isSector();

      [LineNumberTable(254)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual string getPlayTime() => Strings.formatMillis(!object.ReferenceEquals((object) this.this\u00240.current, (object) this) ? this.meta.timePlayed : this.this\u00240.totalPlaytime);

      [LineNumberTable(258)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual long getTimestamp() => this.meta.timestamp;

      [LineNumberTable(262)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual string getDate()
      {
        DateFormat dateTimeInstance = DateFormat.getDateTimeInstance();
        Date.__\u003Cclinit\u003E();
        Date date = new Date(this.meta.timestamp);
        return dateTimeInstance.format(date);
      }

      [LineNumberTable(266)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual Map getMap() => this.meta.map;

      [LineNumberTable(new byte[] {160, 156, 108, 145, 104, 159, 22, 134})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void cautiousLoad(Runnable run)
      {
        Seq seq = Seq.with((object[]) this.getMods());
        seq.removeAll(Vars.mods.getModStrings());
        if (!seq.isEmpty())
          Vars.ui.showConfirm("@warning", Core.bundle.format("mod.missing", (object) seq.toString("\n")), run);
        else
          run.run();
      }

      [LineNumberTable(281)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual string getName() => Core.settings.getString(new StringBuilder().append("save-").append(this.index()).append("-name").toString(), "untitled");

      [LineNumberTable(new byte[] {160, 171, 127, 21})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void setName(string name) => Core.settings.put(new StringBuilder().append("save-").append(this.index()).append("-name").toString(), (object) name);

      [LineNumberTable(301)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual Gamemode mode() => this.meta.rules.mode();

      [LineNumberTable(305)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual int getBuild() => this.meta.build;

      [LineNumberTable(309)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual int getWave() => this.meta.wave;

      [Throws(new string[] {"java.io.IOException"})]
      [LineNumberTable(new byte[] {160, 208, 191, 4, 2, 97, 140})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void importFile(Fi from)
      {
        Exception exception1;
        try
        {
          from.copyTo(this.__\u003C\u003Efile);
          return;
        }
        catch (Exception ex)
        {
          M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
          if (m0 == null)
            throw;
          else
            exception1 = (Exception) m0;
        }
        Exception exception2 = exception1;
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IOException((Exception) exception2);
      }

      [Throws(new string[] {"java.io.IOException"})]
      [LineNumberTable(new byte[] {160, 216, 191, 4, 2, 97, 140})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void exportFile(Fi to)
      {
        Exception exception1;
        try
        {
          this.__\u003C\u003Efile.copyTo(to);
          return;
        }
        catch (Exception ex)
        {
          M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
          if (m0 == null)
            throw;
          else
            exception1 = (Exception) m0;
        }
        Exception exception2 = exception1;
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IOException((Exception) exception2);
      }

      [Modifiers]
      public Fi file
      {
        [HideFromJava] get => this.__\u003C\u003Efile;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Efile = value;
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon0 : Runnable
      {
        private readonly Saves.SaveSlot arg\u00241;

        internal __\u003C\u003EAnon0([In] Saves.SaveSlot obj0) => this.arg\u00241 = obj0;

        public void run() => this.arg\u00241.lambda\u0024savePreview\u00240();
      }
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Cons
    {
      private readonly Saves arg\u00241;

      internal __\u003C\u003EAnon0([In] Saves obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024new\u00240((EventType.StateChangeEvent) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Boolf
    {
      internal __\u003C\u003EAnon1()
      {
      }

      public bool get([In] object obj0) => (Saves.lambda\u0024load\u00241((Saves.SaveSlot) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon2 : Runnable
    {
      private readonly Saves arg\u00241;

      internal __\u003C\u003EAnon2([In] Saves obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024update\u00242();
    }
  }
}
