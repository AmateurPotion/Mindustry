// Decompiled with JetBrains decompiler
// Type: mindustry.game.SectorInfo
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.func;
using arc.math;
using arc.util;
using IKVM.Attributes;
using java.lang;
using java.util;
using mindustry.content;
using mindustry.gen;
using mindustry.maps;
using mindustry.type;
using mindustry.world;
using mindustry.world.blocks.storage;
using mindustry.world.modules;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.game
{
  public class SectorInfo : Object
  {
    private const int valueWindow = 60;
    private const float refreshPeriod = 60f;
    [Signature("Larc/struct/ObjectMap<Lmindustry/type/Item;Lmindustry/game/SectorInfo$ExportStat;>;")]
    public ObjectMap production;
    [Signature("Larc/struct/ObjectMap<Lmindustry/type/Item;Lmindustry/game/SectorInfo$ExportStat;>;")]
    public ObjectMap rawProduction;
    [Signature("Larc/struct/ObjectMap<Lmindustry/type/Item;Lmindustry/game/SectorInfo$ExportStat;>;")]
    public ObjectMap export;
    public ItemSeq items;
    public Block bestCoreType;
    public int storageCapacity;
    public bool hasCore;
    public bool wasCaptured;
    [arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})]
    public Sector origin;
    [arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})]
    public Sector destination;
    [Signature("Larc/struct/Seq<Lmindustry/ctype/UnlockableContent;>;")]
    public Seq resources;
    public bool waves;
    public bool attack;
    public bool hasSpawns;
    public int wave;
    public int winWave;
    public int wavesSurvived;
    public float waveSpacing;
    public float damage;
    public int wavesPassed;
    public int spawnPosition;
    public float secondsPassed;
    public float minutesCaptured;
    [arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})]
    public string name;
    [arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})]
    public string icon;
    public int waveVersion;
    public bool shown;
    public float sumHealth;
    public float sumRps;
    public float sumDps;
    public float waveHealthBase;
    public float waveHealthSlope;
    public float waveDpsBase;
    public float waveDpsSlope;
    public float bossHealth;
    public float bossDps;
    public float curEnemyHealth;
    public float curEnemyDps;
    public int bossWave;
    [NonSerialized]
    private Interval time;
    [arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})]
    [NonSerialized]
    private int[] coreDeltas;
    [arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})]
    [NonSerialized]
    private int[] productionDeltas;

    [LineNumberTable(new byte[] {160, 91, 173, 181, 245, 77, 127, 3, 191, 3, 127, 8, 115, 179, 159, 41, 110, 159, 70, 133, 108, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void update()
    {
      if (Vars.net.client() || !this.time.get(60f))
        return;
      this.export.each((Cons2) new SectorInfo.__\u003C\u003EAnon5());
      if (this.coreDeltas == null)
        this.coreDeltas = new int[Vars.content.items().size];
      if (this.productionDeltas == null)
        this.productionDeltas = new int[Vars.content.items().size];
      Iterator iterator = Vars.content.items().iterator();
      while (iterator.hasNext())
      {
        Item obj = (Item) iterator.next();
        this.updateDelta(obj, this.production, this.coreDeltas);
        this.updateDelta(obj, this.rawProduction, this.productionDeltas);
        ((SectorInfo.ExportStat) this.production.get((object) obj)).mean = Math.min(((SectorInfo.ExportStat) this.production.get((object) obj)).mean, ((SectorInfo.ExportStat) this.rawProduction.get((object) obj)).mean);
        if (this.export.containsKey((object) obj))
          ((SectorInfo.ExportStat) this.export.get((object) obj)).mean = Math.min(((SectorInfo.ExportStat) this.export.get((object) obj)).mean, Math.max(((SectorInfo.ExportStat) this.rawProduction.get((object) obj)).mean, -((SectorInfo.ExportStat) this.production.get((object) obj)).mean));
      }
      Arrays.fill(this.coreDeltas, 0);
      Arrays.fill(this.productionDeltas, 0);
    }

    [LineNumberTable(new byte[] {79, 118, 103, 199, 113, 168, 112, 117, 117, 117, 181, 127, 0, 191, 9, 117, 99, 107, 145, 150})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void write()
    {
      if (Vars.state.rules.waveTeam.core() != null)
      {
        this.attack = true;
        this.winWave = 0;
      }
      if (this.winWave <= 0 && !this.attack)
        this.winWave = 30;
      Vars.state.wave = this.wave;
      Vars.state.rules.waves = this.waves;
      Vars.state.rules.waveSpacing = this.waveSpacing;
      Vars.state.rules.winWave = this.winWave;
      Vars.state.rules.attackMode = this.attack;
      if (this.waveVersion != 5 && Vars.state.rules.sector.preset == null)
        Vars.state.rules.spawns = Waves.generate(Vars.state.rules.sector.threat);
      CoreBlock.CoreBuild coreBuild = Vars.state.rules.defaultTeam.core();
      if (coreBuild == null)
        return;
      coreBuild.items.clear();
      coreBuild.items.add(this.items);
      coreBuild.items.each((ItemModule.ItemConsumer) new SectorInfo.__\u003C\u003EAnon2(coreBuild));
    }

    [LineNumberTable(new byte[] {47, 127, 3, 118})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void handleProduction(Item item, int amount)
    {
      if (this.productionDeltas == null)
        this.productionDeltas = new int[Vars.content.items().size];
      int[] productionDeltas = this.productionDeltas;
      int id = (int) item.__\u003C\u003Eid;
      int[] numArray = productionDeltas;
      numArray[id] = numArray[id] + amount;
    }

    [LineNumberTable(new byte[] {64, 127, 11})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void handleItemExport(Item item, int amount) => ((SectorInfo.ExportStat) this.export.get((object) item, (Prov) new SectorInfo.__\u003C\u003EAnon1())).counter += (float) amount;

    [Signature("(Lmindustry/type/Item;Larc/struct/ObjectMap<Lmindustry/type/Item;Lmindustry/game/SectorInfo$ExportStat;>;[I)V")]
    [LineNumberTable(new byte[] {160, 132, 119, 104, 113, 199, 116, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void updateDelta([In] Item obj0, [In] ObjectMap obj1, [In] int[] obj2)
    {
      SectorInfo.ExportStat exportStat = (SectorInfo.ExportStat) obj1.get((object) obj0, (Prov) new SectorInfo.__\u003C\u003EAnon1());
      if (!exportStat.loaded)
      {
        exportStat.means.fill(exportStat.mean);
        exportStat.loaded = true;
      }
      exportStat.means.add((float) obj2[(int) obj0.__\u003C\u003Eid]);
      exportStat.mean = exportStat.means.rawMean();
    }

    [Modifiers]
    [LineNumberTable(155)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024write\u00240([In] CoreBlock.CoreBuild obj0, [In] Item obj1, [In] int obj2) => obj0.items.set(obj1, Mathf.clamp(obj2, 0, obj0.storageCapacity));

    [Modifiers]
    [LineNumberTable(182)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static float lambda\u0024prepare\u00241([In] CoreBlock.CoreBuild obj0) => (float) obj0.block.size;

    [Modifiers]
    [LineNumberTable(new byte[] {160, 77, 127, 19})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024prepare\u00242([In] Item obj0, [In] SectorInfo.ExportStat obj1) => obj1.mean = Math.min(obj1.mean, ((SectorInfo.ExportStat) this.rawProduction.get((object) obj0, (Prov) new SectorInfo.__\u003C\u003EAnon1())).mean);

    [Modifiers]
    [LineNumberTable(new byte[] {160, 99, 104, 113, 199, 124, 107, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024update\u00243([In] Item obj0, [In] SectorInfo.ExportStat obj1)
    {
      if (!obj1.loaded)
      {
        obj1.means.fill(obj1.mean);
        obj1.loaded = true;
      }
      obj1.means.add(Math.max(obj1.counter, 0.0f));
      obj1.counter = 0.0f;
      obj1.mean = obj1.means.rawMean();
    }

    [Modifiers]
    [LineNumberTable(259)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024exportRates\u00244(
      [In] ObjectFloatMap obj0,
      [In] Item obj1,
      [In] SectorInfo.ExportStat obj2)
    {
      obj0.put((object) obj1, obj2.mean);
    }

    [LineNumberTable(new byte[] {159, 160, 232, 71, 139, 139, 139, 139, 139, 135, 135, 231, 70, 139, 135, 135, 135, 142, 135, 235, 80, 135, 231, 69, 167})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public SectorInfo()
    {
      SectorInfo sectorInfo = this;
      this.production = new ObjectMap();
      this.rawProduction = new ObjectMap();
      this.export = new ObjectMap();
      this.items = new ItemSeq();
      this.bestCoreType = Blocks.coreShard;
      this.storageCapacity = 0;
      this.hasCore = true;
      this.wasCaptured = false;
      this.resources = new Seq();
      this.waves = true;
      this.attack = false;
      this.hasSpawns = true;
      this.wave = 1;
      this.winWave = -1;
      this.wavesSurvived = -1;
      this.waveSpacing = 7200f;
      this.waveVersion = -1;
      this.shown = false;
      this.bossWave = -1;
      this.time = new Interval();
    }

    [LineNumberTable(new byte[] {41, 127, 3, 118})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void handleCoreItem(Item item, int amount)
    {
      if (this.coreDeltas == null)
        this.coreDeltas = new int[Vars.content.items().size];
      int[] coreDeltas = this.coreDeltas;
      int id = (int) item.__\u003C\u003Eid;
      int[] numArray = coreDeltas;
      numArray[id] = numArray[id] + amount;
    }

    [LineNumberTable(104)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Sector getRealDestination() => !Vars.net.client() || this.destination != null ? this.destination : (Sector) Vars.state.rules.sector.__\u003C\u003Eplanet.sectors.find((Boolf) new SectorInfo.__\u003C\u003EAnon0());

    [LineNumberTable(new byte[] {59, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void handleItemExport(ItemStack stack) => this.handleItemExport(stack.item, stack.amount);

    [LineNumberTable(new byte[] {69, 127, 11})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void handleItemImport(Item item, int amount) => ((SectorInfo.ExportStat) this.export.get((object) item, (Prov) new SectorInfo.__\u003C\u003EAnon1())).counter -= (float) amount;

    [LineNumberTable(123)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getExport(Item item) => ((SectorInfo.ExportStat) this.export.get((object) item, (Prov) new SectorInfo.__\u003C\u003EAnon1())).mean;

    [LineNumberTable(new byte[] {112, 139, 149, 99, 103, 107, 61, 198, 172, 103, 117, 112, 117, 117, 117, 109, 127, 35, 114, 107, 103, 107, 179, 214, 113, 180, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void prepare()
    {
      this.items.clear();
      CoreBlock.CoreBuild coreBuild = Vars.state.rules.defaultTeam.core();
      if (coreBuild != null)
      {
        ItemModule items = coreBuild.items;
        for (int id = 0; id < items.length(); ++id)
          this.items.set(Vars.content.item(id), items.get(id));
        this.spawnPosition = coreBuild.pos();
      }
      this.waveVersion = 5;
      this.waveSpacing = Vars.state.rules.waveSpacing;
      this.wave = Vars.state.wave;
      this.winWave = Vars.state.rules.winWave;
      this.waves = Vars.state.rules.waves;
      this.attack = Vars.state.rules.attackMode;
      this.hasCore = coreBuild != null;
      this.bestCoreType = this.hasCore ? ((Building) Vars.state.rules.defaultTeam.cores().max((Floatf) new SectorInfo.__\u003C\u003EAnon3())).block : Blocks.air;
      this.storageCapacity = coreBuild == null ? 0 : coreBuild.storageCapacity;
      this.secondsPassed = 0.0f;
      this.wavesPassed = 0;
      this.damage = 0.0f;
      this.hasSpawns = Vars.spawner.countSpawns() > 0;
      this.production.each((Cons2) new SectorInfo.__\u003C\u003EAnon4(this));
      if (Vars.state.rules.sector != null)
        Vars.state.rules.sector.saveInfo();
      SectorDamage.writeParameters(this);
    }

    [Signature("()Larc/struct/ObjectFloatMap<Lmindustry/type/Item;>;")]
    [LineNumberTable(new byte[] {160, 144, 102, 118})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual ObjectFloatMap exportRates()
    {
      ObjectFloatMap objectFloatMap = new ObjectFloatMap();
      this.export.each((Cons2) new SectorInfo.__\u003C\u003EAnon6(objectFloatMap));
      return objectFloatMap;
    }

    public class ExportStat : Object
    {
      [NonSerialized]
      public float counter;
      [NonSerialized]
      public WindowedMean means;
      [NonSerialized]
      public bool loaded;
      public float mean;

      [LineNumberTable(new byte[] {160, 149, 136})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public ExportStat()
      {
        SectorInfo.ExportStat exportStat = this;
        this.means = new WindowedMean(60);
      }

      [LineNumberTable(272)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual string toString() => new StringBuilder().append(this.mean).append("").toString();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Boolf
    {
      internal __\u003C\u003EAnon0()
      {
      }

      public bool get([In] object obj0) => (((Sector) obj0).hasBase() ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Prov
    {
      internal __\u003C\u003EAnon1()
      {
      }

      public object get() => (object) new SectorInfo.ExportStat();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon2 : ItemModule.ItemConsumer
    {
      private readonly CoreBlock.CoreBuild arg\u00241;

      internal __\u003C\u003EAnon2([In] CoreBlock.CoreBuild obj0) => this.arg\u00241 = obj0;

      public void accept([In] Item obj0, [In] int obj1) => SectorInfo.lambda\u0024write\u00240(this.arg\u00241, obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon3 : Floatf
    {
      internal __\u003C\u003EAnon3()
      {
      }

      public float get([In] object obj0) => SectorInfo.lambda\u0024prepare\u00241((CoreBlock.CoreBuild) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon4 : Cons2
    {
      private readonly SectorInfo arg\u00241;

      internal __\u003C\u003EAnon4([In] SectorInfo obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0, [In] object obj1) => this.arg\u00241.lambda\u0024prepare\u00242((Item) obj0, (SectorInfo.ExportStat) obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon5 : Cons2
    {
      internal __\u003C\u003EAnon5()
      {
      }

      public void get([In] object obj0, [In] object obj1) => SectorInfo.lambda\u0024update\u00243((Item) obj0, (SectorInfo.ExportStat) obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon6 : Cons2
    {
      private readonly ObjectFloatMap arg\u00241;

      internal __\u003C\u003EAnon6([In] ObjectFloatMap obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0, [In] object obj1) => SectorInfo.lambda\u0024exportRates\u00244(this.arg\u00241, (Item) obj0, (SectorInfo.ExportStat) obj1);
    }
  }
}
