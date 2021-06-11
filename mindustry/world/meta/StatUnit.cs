// Decompiled with JetBrains decompiler
// Type: mindustry.world.meta.StatUnit
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.util;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.world.meta
{
  [Signature("Ljava/lang/Enum<Lmindustry/world/meta/StatUnit;>;")]
  [Modifiers]
  [Serializable]
  public sealed class StatUnit : Enum
  {
    [Modifiers]
    internal static StatUnit __\u003C\u003Eblocks;
    [Modifiers]
    internal static StatUnit __\u003C\u003EblocksSquared;
    [Modifiers]
    internal static StatUnit __\u003C\u003EpowerSecond;
    [Modifiers]
    internal static StatUnit __\u003C\u003EliquidSecond;
    [Modifiers]
    internal static StatUnit __\u003C\u003EitemsSecond;
    [Modifiers]
    internal static StatUnit __\u003C\u003EliquidUnits;
    [Modifiers]
    internal static StatUnit __\u003C\u003EpowerUnits;
    [Modifiers]
    internal static StatUnit __\u003C\u003Edegrees;
    [Modifiers]
    internal static StatUnit __\u003C\u003Eseconds;
    [Modifiers]
    internal static StatUnit __\u003C\u003Eminutes;
    [Modifiers]
    internal static StatUnit __\u003C\u003EperSecond;
    [Modifiers]
    internal static StatUnit __\u003C\u003EperMinute;
    [Modifiers]
    internal static StatUnit __\u003C\u003EperShot;
    [Modifiers]
    internal static StatUnit __\u003C\u003EtimesSpeed;
    [Modifiers]
    internal static StatUnit __\u003C\u003Epercent;
    [Modifiers]
    internal static StatUnit __\u003C\u003EshieldHealth;
    [Modifiers]
    internal static StatUnit __\u003C\u003Enone;
    [Modifiers]
    internal static StatUnit __\u003C\u003Eitems;
    internal bool __\u003C\u003Espace;
    [Modifiers]
    private static StatUnit[] \u0024VALUES;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 183, 115})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string localized() => object.ReferenceEquals((object) this, (object) StatUnit.__\u003C\u003Enone) ? "" : Core.bundle.get(new StringBuilder().append("unit.").append(String.instancehelper_toLowerCase(this.name(), (Locale) Locale.ROOT)).toString());

    [Signature("(Z)V")]
    [LineNumberTable(new byte[] {159, 134, 66, 106, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private StatUnit([In] string obj0, [In] int obj1, [In] bool obj2)
    {
      int num = obj2 ? 1 : 0;
      // ISSUE: explicit constructor call
      base.\u002Ector(obj0, obj1);
      StatUnit statUnit = this;
      this.__\u003C\u003Espace = num != 0;
      GC.KeepAlive((object) this);
    }

    [Signature("()V")]
    [LineNumberTable(new byte[] {159, 179, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private StatUnit([In] string obj0, [In] int obj1)
      : this(obj0, obj1, true)
    {
      GC.KeepAlive((object) this);
    }

    [LineNumberTable(10)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static StatUnit[] values() => (StatUnit[]) StatUnit.\u0024VALUES.Clone();

    [LineNumberTable(10)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static StatUnit valueOf(string name) => (StatUnit) Enum.valueOf((Class) ClassLiteral<StatUnit>.Value, name);

    [LineNumberTable(new byte[] {159, 140, 173, 112, 112, 112, 112, 112, 112, 112, 112, 112, 113, 113, 113, 114, 114, 114, 113, 113, 241, 46})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static StatUnit()
    {
      if (ByteCodeHelper.isAlreadyInited("mindustry.world.meta.StatUnit"))
        return;
      StatUnit.__\u003C\u003Eblocks = new StatUnit(nameof (blocks), 0);
      StatUnit.__\u003C\u003EblocksSquared = new StatUnit(nameof (blocksSquared), 1);
      StatUnit.__\u003C\u003EpowerSecond = new StatUnit(nameof (powerSecond), 2);
      StatUnit.__\u003C\u003EliquidSecond = new StatUnit(nameof (liquidSecond), 3);
      StatUnit.__\u003C\u003EitemsSecond = new StatUnit(nameof (itemsSecond), 4);
      StatUnit.__\u003C\u003EliquidUnits = new StatUnit(nameof (liquidUnits), 5);
      StatUnit.__\u003C\u003EpowerUnits = new StatUnit(nameof (powerUnits), 6);
      StatUnit.__\u003C\u003Edegrees = new StatUnit(nameof (degrees), 7);
      StatUnit.__\u003C\u003Eseconds = new StatUnit(nameof (seconds), 8);
      StatUnit.__\u003C\u003Eminutes = new StatUnit(nameof (minutes), 9);
      StatUnit.__\u003C\u003EperSecond = new StatUnit(nameof (perSecond), 10);
      StatUnit.__\u003C\u003EperMinute = new StatUnit(nameof (perMinute), 11);
      StatUnit.__\u003C\u003EperShot = new StatUnit(nameof (perShot), 12, false);
      StatUnit.__\u003C\u003EtimesSpeed = new StatUnit(nameof (timesSpeed), 13, false);
      StatUnit.__\u003C\u003Epercent = new StatUnit(nameof (percent), 14, false);
      StatUnit.__\u003C\u003EshieldHealth = new StatUnit(nameof (shieldHealth), 15);
      StatUnit.__\u003C\u003Enone = new StatUnit(nameof (none), 16);
      StatUnit.__\u003C\u003Eitems = new StatUnit(nameof (items), 17);
      StatUnit.\u0024VALUES = new StatUnit[18]
      {
        StatUnit.__\u003C\u003Eblocks,
        StatUnit.__\u003C\u003EblocksSquared,
        StatUnit.__\u003C\u003EpowerSecond,
        StatUnit.__\u003C\u003EliquidSecond,
        StatUnit.__\u003C\u003EitemsSecond,
        StatUnit.__\u003C\u003EliquidUnits,
        StatUnit.__\u003C\u003EpowerUnits,
        StatUnit.__\u003C\u003Edegrees,
        StatUnit.__\u003C\u003Eseconds,
        StatUnit.__\u003C\u003Eminutes,
        StatUnit.__\u003C\u003EperSecond,
        StatUnit.__\u003C\u003EperMinute,
        StatUnit.__\u003C\u003EperShot,
        StatUnit.__\u003C\u003EtimesSpeed,
        StatUnit.__\u003C\u003Epercent,
        StatUnit.__\u003C\u003EshieldHealth,
        StatUnit.__\u003C\u003Enone,
        StatUnit.__\u003C\u003Eitems
      };
    }

    [Modifiers]
    public static StatUnit blocks
    {
      [HideFromJava] get => StatUnit.__\u003C\u003Eblocks;
    }

    [Modifiers]
    public static StatUnit blocksSquared
    {
      [HideFromJava] get => StatUnit.__\u003C\u003EblocksSquared;
    }

    [Modifiers]
    public static StatUnit powerSecond
    {
      [HideFromJava] get => StatUnit.__\u003C\u003EpowerSecond;
    }

    [Modifiers]
    public static StatUnit liquidSecond
    {
      [HideFromJava] get => StatUnit.__\u003C\u003EliquidSecond;
    }

    [Modifiers]
    public static StatUnit itemsSecond
    {
      [HideFromJava] get => StatUnit.__\u003C\u003EitemsSecond;
    }

    [Modifiers]
    public static StatUnit liquidUnits
    {
      [HideFromJava] get => StatUnit.__\u003C\u003EliquidUnits;
    }

    [Modifiers]
    public static StatUnit powerUnits
    {
      [HideFromJava] get => StatUnit.__\u003C\u003EpowerUnits;
    }

    [Modifiers]
    public static StatUnit degrees
    {
      [HideFromJava] get => StatUnit.__\u003C\u003Edegrees;
    }

    [Modifiers]
    public static StatUnit seconds
    {
      [HideFromJava] get => StatUnit.__\u003C\u003Eseconds;
    }

    [Modifiers]
    public static StatUnit minutes
    {
      [HideFromJava] get => StatUnit.__\u003C\u003Eminutes;
    }

    [Modifiers]
    public static StatUnit perSecond
    {
      [HideFromJava] get => StatUnit.__\u003C\u003EperSecond;
    }

    [Modifiers]
    public static StatUnit perMinute
    {
      [HideFromJava] get => StatUnit.__\u003C\u003EperMinute;
    }

    [Modifiers]
    public static StatUnit perShot
    {
      [HideFromJava] get => StatUnit.__\u003C\u003EperShot;
    }

    [Modifiers]
    public static StatUnit timesSpeed
    {
      [HideFromJava] get => StatUnit.__\u003C\u003EtimesSpeed;
    }

    [Modifiers]
    public static StatUnit percent
    {
      [HideFromJava] get => StatUnit.__\u003C\u003Epercent;
    }

    [Modifiers]
    public static StatUnit shieldHealth
    {
      [HideFromJava] get => StatUnit.__\u003C\u003EshieldHealth;
    }

    [Modifiers]
    public static StatUnit none
    {
      [HideFromJava] get => StatUnit.__\u003C\u003Enone;
    }

    [Modifiers]
    public static StatUnit items
    {
      [HideFromJava] get => StatUnit.__\u003C\u003Eitems;
    }

    [Modifiers]
    public bool space
    {
      [HideFromJava] get => this.__\u003C\u003Espace;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Espace = value;
    }

    [HideFromJava]
    [Serializable]
    public enum __Enum
    {
      blocks,
      blocksSquared,
      powerSecond,
      liquidSecond,
      itemsSecond,
      liquidUnits,
      powerUnits,
      degrees,
      seconds,
      minutes,
      perSecond,
      perMinute,
      perShot,
      timesSpeed,
      percent,
      shieldHealth,
      none,
      items,
    }
  }
}
