// Decompiled with JetBrains decompiler
// Type: mindustry.desktop.steam.SStat
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.desktop.steam
{
  [Signature("Ljava/lang/Enum<Lmindustry/desktop/steam/SStat;>;")]
  [Modifiers]
  [Serializable]
  public sealed class SStat : Enum
  {
    [Modifiers]
    internal static SStat __\u003C\u003EunitsDestroyed;
    [Modifiers]
    internal static SStat __\u003C\u003EattacksWon;
    [Modifiers]
    internal static SStat __\u003C\u003EpvpsWon;
    [Modifiers]
    internal static SStat __\u003C\u003EtimesLaunched;
    [Modifiers]
    internal static SStat __\u003C\u003EblocksDestroyed;
    [Modifiers]
    internal static SStat __\u003C\u003EitemsLaunched;
    [Modifiers]
    internal static SStat __\u003C\u003EreactorsOverheated;
    [Modifiers]
    internal static SStat __\u003C\u003EmaxUnitActive;
    [Modifiers]
    internal static SStat __\u003C\u003EunitTypesBuilt;
    [Modifiers]
    internal static SStat __\u003C\u003EunitsBuilt;
    [Modifiers]
    internal static SStat __\u003C\u003EbossesDefeated;
    [Modifiers]
    internal static SStat __\u003C\u003EmaxPlayersServer;
    [Modifiers]
    internal static SStat __\u003C\u003EmapsMade;
    [Modifiers]
    internal static SStat __\u003C\u003EmapsPublished;
    [Modifiers]
    internal static SStat __\u003C\u003EmaxWavesSurvived;
    [Modifiers]
    internal static SStat __\u003C\u003EblocksBuilt;
    [Modifiers]
    internal static SStat __\u003C\u003EmaxProduction;
    [Modifiers]
    internal static SStat __\u003C\u003EsectorsControlled;
    [Modifiers]
    internal static SStat __\u003C\u003EschematicsCreated;
    [Modifiers]
    private static SStat[] \u0024VALUES;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 172, 105, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void max(int amount)
    {
      if (amount <= this.get())
        return;
      this.set(amount);
    }

    [LineNumberTable(new byte[] {159, 191, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void add() => this.add(1);

    [LineNumberTable(new byte[] {159, 178, 119, 138, 115, 38, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void set(int amount)
    {
      SVars.stats.__\u003C\u003Estats.setStatI(this.name(), amount);
      SVars.stats.onUpdate();
      SAchievement[] all = SAchievement.__\u003C\u003Eall;
      int length = all.Length;
      for (int index = 0; index < length; ++index)
        all[index].checkCompletion();
    }

    [LineNumberTable(new byte[] {159, 187, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void add(int amount) => this.set(this.get() + amount);

    [LineNumberTable(26)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int get() => SVars.stats.__\u003C\u003Estats.getStatI(this.name(), 0);

    [Signature("()V")]
    [LineNumberTable(3)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private SStat([In] string obj0, [In] int obj1)
      : base(obj0, obj1)
    {
      GC.KeepAlive((object) this);
    }

    [LineNumberTable(3)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static SStat[] values() => (SStat[]) SStat.\u0024VALUES.Clone();

    [LineNumberTable(3)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static SStat valueOf(string name) => (SStat) Enum.valueOf((Class) ClassLiteral<SStat>.Value, name);

    [LineNumberTable(new byte[] {159, 141, 77, 112, 112, 112, 112, 112, 112, 112, 112, 112, 113, 113, 113, 113, 113, 113, 113, 113, 113, 241, 45})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static SStat()
    {
      if (ByteCodeHelper.isAlreadyInited("mindustry.desktop.steam.SStat"))
        return;
      SStat.__\u003C\u003EunitsDestroyed = new SStat(nameof (unitsDestroyed), 0);
      SStat.__\u003C\u003EattacksWon = new SStat(nameof (attacksWon), 1);
      SStat.__\u003C\u003EpvpsWon = new SStat(nameof (pvpsWon), 2);
      SStat.__\u003C\u003EtimesLaunched = new SStat(nameof (timesLaunched), 3);
      SStat.__\u003C\u003EblocksDestroyed = new SStat(nameof (blocksDestroyed), 4);
      SStat.__\u003C\u003EitemsLaunched = new SStat(nameof (itemsLaunched), 5);
      SStat.__\u003C\u003EreactorsOverheated = new SStat(nameof (reactorsOverheated), 6);
      SStat.__\u003C\u003EmaxUnitActive = new SStat(nameof (maxUnitActive), 7);
      SStat.__\u003C\u003EunitTypesBuilt = new SStat(nameof (unitTypesBuilt), 8);
      SStat.__\u003C\u003EunitsBuilt = new SStat(nameof (unitsBuilt), 9);
      SStat.__\u003C\u003EbossesDefeated = new SStat(nameof (bossesDefeated), 10);
      SStat.__\u003C\u003EmaxPlayersServer = new SStat(nameof (maxPlayersServer), 11);
      SStat.__\u003C\u003EmapsMade = new SStat(nameof (mapsMade), 12);
      SStat.__\u003C\u003EmapsPublished = new SStat(nameof (mapsPublished), 13);
      SStat.__\u003C\u003EmaxWavesSurvived = new SStat(nameof (maxWavesSurvived), 14);
      SStat.__\u003C\u003EblocksBuilt = new SStat(nameof (blocksBuilt), 15);
      SStat.__\u003C\u003EmaxProduction = new SStat(nameof (maxProduction), 16);
      SStat.__\u003C\u003EsectorsControlled = new SStat(nameof (sectorsControlled), 17);
      SStat.__\u003C\u003EschematicsCreated = new SStat(nameof (schematicsCreated), 18);
      SStat.\u0024VALUES = new SStat[19]
      {
        SStat.__\u003C\u003EunitsDestroyed,
        SStat.__\u003C\u003EattacksWon,
        SStat.__\u003C\u003EpvpsWon,
        SStat.__\u003C\u003EtimesLaunched,
        SStat.__\u003C\u003EblocksDestroyed,
        SStat.__\u003C\u003EitemsLaunched,
        SStat.__\u003C\u003EreactorsOverheated,
        SStat.__\u003C\u003EmaxUnitActive,
        SStat.__\u003C\u003EunitTypesBuilt,
        SStat.__\u003C\u003EunitsBuilt,
        SStat.__\u003C\u003EbossesDefeated,
        SStat.__\u003C\u003EmaxPlayersServer,
        SStat.__\u003C\u003EmapsMade,
        SStat.__\u003C\u003EmapsPublished,
        SStat.__\u003C\u003EmaxWavesSurvived,
        SStat.__\u003C\u003EblocksBuilt,
        SStat.__\u003C\u003EmaxProduction,
        SStat.__\u003C\u003EsectorsControlled,
        SStat.__\u003C\u003EschematicsCreated
      };
    }

    [Modifiers]
    public static SStat unitsDestroyed
    {
      [HideFromJava] get => SStat.__\u003C\u003EunitsDestroyed;
    }

    [Modifiers]
    public static SStat attacksWon
    {
      [HideFromJava] get => SStat.__\u003C\u003EattacksWon;
    }

    [Modifiers]
    public static SStat pvpsWon
    {
      [HideFromJava] get => SStat.__\u003C\u003EpvpsWon;
    }

    [Modifiers]
    public static SStat timesLaunched
    {
      [HideFromJava] get => SStat.__\u003C\u003EtimesLaunched;
    }

    [Modifiers]
    public static SStat blocksDestroyed
    {
      [HideFromJava] get => SStat.__\u003C\u003EblocksDestroyed;
    }

    [Modifiers]
    public static SStat itemsLaunched
    {
      [HideFromJava] get => SStat.__\u003C\u003EitemsLaunched;
    }

    [Modifiers]
    public static SStat reactorsOverheated
    {
      [HideFromJava] get => SStat.__\u003C\u003EreactorsOverheated;
    }

    [Modifiers]
    public static SStat maxUnitActive
    {
      [HideFromJava] get => SStat.__\u003C\u003EmaxUnitActive;
    }

    [Modifiers]
    public static SStat unitTypesBuilt
    {
      [HideFromJava] get => SStat.__\u003C\u003EunitTypesBuilt;
    }

    [Modifiers]
    public static SStat unitsBuilt
    {
      [HideFromJava] get => SStat.__\u003C\u003EunitsBuilt;
    }

    [Modifiers]
    public static SStat bossesDefeated
    {
      [HideFromJava] get => SStat.__\u003C\u003EbossesDefeated;
    }

    [Modifiers]
    public static SStat maxPlayersServer
    {
      [HideFromJava] get => SStat.__\u003C\u003EmaxPlayersServer;
    }

    [Modifiers]
    public static SStat mapsMade
    {
      [HideFromJava] get => SStat.__\u003C\u003EmapsMade;
    }

    [Modifiers]
    public static SStat mapsPublished
    {
      [HideFromJava] get => SStat.__\u003C\u003EmapsPublished;
    }

    [Modifiers]
    public static SStat maxWavesSurvived
    {
      [HideFromJava] get => SStat.__\u003C\u003EmaxWavesSurvived;
    }

    [Modifiers]
    public static SStat blocksBuilt
    {
      [HideFromJava] get => SStat.__\u003C\u003EblocksBuilt;
    }

    [Modifiers]
    public static SStat maxProduction
    {
      [HideFromJava] get => SStat.__\u003C\u003EmaxProduction;
    }

    [Modifiers]
    public static SStat sectorsControlled
    {
      [HideFromJava] get => SStat.__\u003C\u003EsectorsControlled;
    }

    [Modifiers]
    public static SStat schematicsCreated
    {
      [HideFromJava] get => SStat.__\u003C\u003EschematicsCreated;
    }

    [HideFromJava]
    [Serializable]
    public enum __Enum
    {
      unitsDestroyed,
      attacksWon,
      pvpsWon,
      timesLaunched,
      blocksDestroyed,
      itemsLaunched,
      reactorsOverheated,
      maxUnitActive,
      unitTypesBuilt,
      unitsBuilt,
      bossesDefeated,
      maxPlayersServer,
      mapsMade,
      mapsPublished,
      maxWavesSurvived,
      blocksBuilt,
      maxProduction,
      sectorsControlled,
      schematicsCreated,
    }
  }
}
