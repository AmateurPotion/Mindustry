// Decompiled with JetBrains decompiler
// Type: mindustry.game.Rules
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.graphics;
using arc.util;
using arc.util.serialization;
using ikvm.@internal;
using IKVM.Attributes;
using java.lang;
using java.util;
using mindustry.content;
using mindustry.io;
using mindustry.type;
using System.Runtime.CompilerServices;

namespace mindustry.game
{
  public class Rules : Object
  {
    public bool infiniteResources;
    public Rules.TeamRules teams;
    public bool waveTimer;
    public bool waves;
    public bool pvp;
    public bool waitEnemies;
    public bool attackMode;
    public bool editor;
    public bool canGameOver;
    public bool reactorExplosions;
    public bool schematicsAllowed;
    public bool damageExplosions;
    public bool fire;
    public bool unitAmmo;
    public bool unitCapVariable;
    public float unitBuildSpeedMultiplier;
    public float unitDamageMultiplier;
    public bool logicUnitBuild;
    public float blockHealthMultiplier;
    public float blockDamageMultiplier;
    public float buildCostMultiplier;
    public float buildSpeedMultiplier;
    public float deconstructRefundMultiplier;
    public float enemyCoreBuildRadius;
    public float dropZoneRadius;
    public float waveSpacing;
    public int winWave;
    public int unitCap;
    [Nullable(new object[] {64, "Larc/util/Nullable;"})]
    public Sector sector;
    [Signature("Larc/struct/Seq<Lmindustry/game/SpawnGroup;>;")]
    public Seq spawns;
    [Signature("Larc/struct/Seq<Lmindustry/type/ItemStack;>;")]
    public Seq loadout;
    [Signature("Larc/struct/Seq<Lmindustry/type/Weather$WeatherEntry;>;")]
    public Seq weather;
    [Signature("Larc/struct/ObjectSet<Lmindustry/world/Block;>;")]
    public ObjectSet bannedBlocks;
    [Signature("Larc/struct/ObjectSet<Lmindustry/world/Block;>;")]
    public ObjectSet revealedBlocks;
    [Signature("Larc/struct/ObjectSet<Ljava/lang/String;>;")]
    public ObjectSet researched;
    public bool lighting;
    public bool enemyLights;
    public Color ambientLight;
    public Team defaultTeam;
    public Team waveTeam;
    [Nullable(new object[] {64, "Larc/util/Nullable;"})]
    public string modeName;
    public bool coreIncinerates;
    public StringMap tags;

    [LineNumberTable(new byte[] {80, 104, 102, 104, 102, 104, 102, 104, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Gamemode mode()
    {
      if (this.pvp)
        return Gamemode.__\u003C\u003Epvp;
      if (this.editor)
        return Gamemode.__\u003C\u003Eeditor;
      if (this.attackMode)
        return Gamemode.__\u003C\u003Eattack;
      return this.infiniteResources ? Gamemode.__\u003C\u003Esandbox : Gamemode.__\u003C\u003Esurvival;
    }

    [LineNumberTable(new byte[] {159, 160, 200, 139, 231, 70, 135, 135, 135, 135, 135, 135, 135, 135, 135, 135, 139, 139, 135, 139, 139, 139, 139, 139, 139, 139, 139, 135, 199, 139, 159, 4, 140, 139, 139, 139, 167, 135, 159, 0, 139, 203, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Rules()
    {
      Rules rules = this;
      this.teams = new Rules.TeamRules();
      this.waveTimer = true;
      this.waitEnemies = false;
      this.attackMode = false;
      this.editor = false;
      this.canGameOver = true;
      this.reactorExplosions = true;
      this.schematicsAllowed = true;
      this.damageExplosions = true;
      this.fire = true;
      this.unitAmmo = false;
      this.unitCapVariable = true;
      this.unitBuildSpeedMultiplier = 1f;
      this.unitDamageMultiplier = 1f;
      this.logicUnitBuild = true;
      this.blockHealthMultiplier = 1f;
      this.blockDamageMultiplier = 1f;
      this.buildCostMultiplier = 1f;
      this.buildSpeedMultiplier = 1f;
      this.deconstructRefundMultiplier = 0.5f;
      this.enemyCoreBuildRadius = 400f;
      this.dropZoneRadius = 300f;
      this.waveSpacing = 7200f;
      this.winWave = 0;
      this.unitCap = 0;
      this.spawns = new Seq();
      this.loadout = ItemStack.list((object) Items.copper, (object) Integer.valueOf(100));
      this.weather = new Seq(1);
      this.bannedBlocks = new ObjectSet();
      this.revealedBlocks = new ObjectSet();
      this.researched = new ObjectSet();
      this.lighting = false;
      this.enemyLights = true;
      this.ambientLight = new Color(0.01f, 0.01f, 0.04f, 0.99f);
      this.defaultTeam = Team.__\u003C\u003Esharded;
      this.waveTeam = Team.__\u003C\u003Ecrux;
      this.coreIncinerates = false;
      this.tags = new StringMap();
    }

    [LineNumberTable(125)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Rules copy() => (Rules) JsonIO.copy((object) this);

    public class TeamRule : Object
    {
      public bool ai;
      public float aiTier;
      public bool aiCoreSpawn;
      public bool cheat;
      public bool infiniteResources;
      public bool infiniteAmmo;

      [LineNumberTable(new byte[] {58, 200, 139})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public TeamRule()
      {
        Rules.TeamRule teamRule = this;
        this.aiTier = 1f;
        this.aiCoreSpawn = true;
      }
    }

    public class TeamRules : Object, Json.JsonSerializable
    {
      [Modifiers]
      internal Rules.TeamRule[] values;

      [LineNumberTable(new byte[] {98, 110, 119})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual Rules.TeamRule get(Team team)
      {
        Rules.TeamRule teamRule = this.values[team.__\u003C\u003Eid];
        if (teamRule == null)
          this.values[team.__\u003C\u003Eid] = teamRule = new Rules.TeamRule();
        return teamRule;
      }

      [LineNumberTable(new byte[] {94, 104})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public TeamRules()
      {
        Rules.TeamRules teamRules = this;
        this.values = new Rules.TeamRule[Team.__\u003C\u003Eall.Length];
      }

      [LineNumberTable(new byte[] {105, 115, 111, 31, 24, 230, 69})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void write(Json json)
      {
        Team[] all = Team.__\u003C\u003Eall;
        int length = all.Length;
        for (int index = 0; index < length; ++index)
        {
          Team team = all[index];
          if (this.values[team.__\u003C\u003Eid] != null)
            json.writeValue(new StringBuilder().append(team.__\u003C\u003Eid).append("").toString(), (object) this.values[team.__\u003C\u003Eid], (Class) ClassLiteral<Rules.TeamRule>.Value);
        }
      }

      [LineNumberTable(new byte[] {114, 123, 127, 4, 98})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void read(Json json, JsonValue jsonData)
      {
        JsonValue.JsonIterator jsonIterator = jsonData.iterator();
        while (((Iterator) jsonIterator).hasNext())
        {
          JsonValue jsonData1 = (JsonValue) ((Iterator) jsonIterator).next();
          this.values[Integer.parseInt(jsonData1.name)] = (Rules.TeamRule) json.readValue((Class) ClassLiteral<Rules.TeamRule>.Value, jsonData1);
        }
      }
    }
  }
}
