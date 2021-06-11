// Decompiled with JetBrains decompiler
// Type: mindustry.world.meta.Stat
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
  [Signature("Ljava/lang/Enum<Lmindustry/world/meta/Stat;>;")]
  [Modifiers]
  [Serializable]
  public sealed class Stat : Enum
  {
    [Modifiers]
    internal static Stat __\u003C\u003Ehealth;
    [Modifiers]
    internal static Stat __\u003C\u003Earmor;
    [Modifiers]
    internal static Stat __\u003C\u003Esize;
    [Modifiers]
    internal static Stat __\u003C\u003EdisplaySize;
    [Modifiers]
    internal static Stat __\u003C\u003EbuildTime;
    [Modifiers]
    internal static Stat __\u003C\u003EbuildCost;
    [Modifiers]
    internal static Stat __\u003C\u003EmemoryCapacity;
    [Modifiers]
    internal static Stat __\u003C\u003Eexplosiveness;
    [Modifiers]
    internal static Stat __\u003C\u003Eflammability;
    [Modifiers]
    internal static Stat __\u003C\u003Eradioactivity;
    [Modifiers]
    internal static Stat __\u003C\u003Echarge;
    [Modifiers]
    internal static Stat __\u003C\u003EheatCapacity;
    [Modifiers]
    internal static Stat __\u003C\u003Eviscosity;
    [Modifiers]
    internal static Stat __\u003C\u003Etemperature;
    [Modifiers]
    internal static Stat __\u003C\u003Eflying;
    [Modifiers]
    internal static Stat __\u003C\u003Espeed;
    [Modifiers]
    internal static Stat __\u003C\u003EbuildSpeed;
    [Modifiers]
    internal static Stat __\u003C\u003EmineSpeed;
    [Modifiers]
    internal static Stat __\u003C\u003EmineTier;
    [Modifiers]
    internal static Stat __\u003C\u003EpayloadCapacity;
    [Modifiers]
    internal static Stat __\u003C\u003EcommandLimit;
    [Modifiers]
    internal static Stat __\u003C\u003EbaseDeflectChance;
    [Modifiers]
    internal static Stat __\u003C\u003ElightningChance;
    [Modifiers]
    internal static Stat __\u003C\u003ElightningDamage;
    [Modifiers]
    internal static Stat __\u003C\u003Eabilities;
    [Modifiers]
    internal static Stat __\u003C\u003EcanBoost;
    [Modifiers]
    internal static Stat __\u003C\u003EmaxUnits;
    [Modifiers]
    internal static Stat __\u003C\u003EdamageMultiplier;
    [Modifiers]
    internal static Stat __\u003C\u003EhealthMultiplier;
    [Modifiers]
    internal static Stat __\u003C\u003EspeedMultiplier;
    [Modifiers]
    internal static Stat __\u003C\u003EreloadMultiplier;
    [Modifiers]
    internal static Stat __\u003C\u003EbuildSpeedMultiplier;
    [Modifiers]
    internal static Stat __\u003C\u003Ereactive;
    [Modifiers]
    internal static Stat __\u003C\u003EitemCapacity;
    [Modifiers]
    internal static Stat __\u003C\u003EitemsMoved;
    [Modifiers]
    internal static Stat __\u003C\u003ElaunchTime;
    [Modifiers]
    internal static Stat __\u003C\u003EmaxConsecutive;
    [Modifiers]
    internal static Stat __\u003C\u003EliquidCapacity;
    [Modifiers]
    internal static Stat __\u003C\u003EpowerCapacity;
    [Modifiers]
    internal static Stat __\u003C\u003EpowerUse;
    [Modifiers]
    internal static Stat __\u003C\u003EpowerDamage;
    [Modifiers]
    internal static Stat __\u003C\u003EpowerRange;
    [Modifiers]
    internal static Stat __\u003C\u003EpowerConnections;
    [Modifiers]
    internal static Stat __\u003C\u003EbasePowerGeneration;
    [Modifiers]
    internal static Stat __\u003C\u003Etiles;
    [Modifiers]
    internal static Stat __\u003C\u003Einput;
    [Modifiers]
    internal static Stat __\u003C\u003Eoutput;
    [Modifiers]
    internal static Stat __\u003C\u003EproductionTime;
    [Modifiers]
    internal static Stat __\u003C\u003EdrillTier;
    [Modifiers]
    internal static Stat __\u003C\u003EdrillSpeed;
    [Modifiers]
    internal static Stat __\u003C\u003ElinkRange;
    [Modifiers]
    internal static Stat __\u003C\u003Einstructions;
    [Modifiers]
    internal static Stat __\u003C\u003Eweapons;
    [Modifiers]
    internal static Stat __\u003C\u003Ebullet;
    [Modifiers]
    internal static Stat __\u003C\u003EspeedIncrease;
    [Modifiers]
    internal static Stat __\u003C\u003ErepairTime;
    [Modifiers]
    internal static Stat __\u003C\u003Erange;
    [Modifiers]
    internal static Stat __\u003C\u003EshootRange;
    [Modifiers]
    internal static Stat __\u003C\u003Einaccuracy;
    [Modifiers]
    internal static Stat __\u003C\u003Eshots;
    [Modifiers]
    internal static Stat __\u003C\u003Ereload;
    [Modifiers]
    internal static Stat __\u003C\u003EpowerShot;
    [Modifiers]
    internal static Stat __\u003C\u003EtargetsAir;
    [Modifiers]
    internal static Stat __\u003C\u003EtargetsGround;
    [Modifiers]
    internal static Stat __\u003C\u003Edamage;
    [Modifiers]
    internal static Stat __\u003C\u003Eammo;
    [Modifiers]
    internal static Stat __\u003C\u003EammoUse;
    [Modifiers]
    internal static Stat __\u003C\u003EshieldHealth;
    [Modifiers]
    internal static Stat __\u003C\u003EcooldownTime;
    [Modifiers]
    internal static Stat __\u003C\u003Ebooster;
    [Modifiers]
    internal static Stat __\u003C\u003EboostEffect;
    [Modifiers]
    internal static Stat __\u003C\u003Eaffinities;
    [Modifiers]
    internal static Stat __\u003C\u003Eopposites;
    internal StatCat __\u003C\u003Ecategory;
    [Modifiers]
    private static Stat[] \u0024VALUES;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(102)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string localized() => Core.bundle.get(new StringBuilder().append("stat.").append(String.instancehelper_toLowerCase(this.name(), (Locale) Locale.ROOT)).toString());

    [Signature("()V")]
    [LineNumberTable(new byte[] {47, 106, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Stat([In] string obj0, [In] int obj1)
      : base(obj0, obj1)
    {
      Stat stat = this;
      this.__\u003C\u003Ecategory = StatCat.__\u003C\u003Egeneral;
      GC.KeepAlive((object) this);
    }

    [Signature("(Lmindustry/world/meta/StatCat;)V")]
    [LineNumberTable(new byte[] {43, 106, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Stat([In] string obj0, [In] int obj1, [In] StatCat obj2)
      : base(obj0, obj1)
    {
      Stat stat = this;
      this.__\u003C\u003Ecategory = obj2;
      GC.KeepAlive((object) this);
    }

    [LineNumberTable(8)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Stat[] values() => (Stat[]) Stat.\u0024VALUES.Clone();

    [LineNumberTable(8)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Stat valueOf(string name) => (Stat) Enum.valueOf((Class) ClassLiteral<Stat>.Value, name);

    [LineNumberTable(new byte[] {159, 140, 109, 112, 112, 112, 112, 112, 112, 112, 112, 112, 113, 113, 113, 113, 113, 113, 113, 113, 113, 113, 113, 113, 113, 113, 113, 113, 113, 145, 113, 113, 113, 113, 113, 145, 118, 118, 118, 150, 150, 118, 118, 118, 118, 118, 150, 118, 118, 118, 118, 118, 118, 118, 150, 118, 150, 118, 118, 118, 118, 118, 118, 118, 118, 118, 118, 118, 118, 118, 118, 150, 118, 118, 118, 246, 159, 175})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static Stat()
    {
      if (ByteCodeHelper.isAlreadyInited("mindustry.world.meta.Stat"))
        return;
      Stat.__\u003C\u003Ehealth = new Stat(nameof (health), 0);
      Stat.__\u003C\u003Earmor = new Stat(nameof (armor), 1);
      Stat.__\u003C\u003Esize = new Stat(nameof (size), 2);
      Stat.__\u003C\u003EdisplaySize = new Stat(nameof (displaySize), 3);
      Stat.__\u003C\u003EbuildTime = new Stat(nameof (buildTime), 4);
      Stat.__\u003C\u003EbuildCost = new Stat(nameof (buildCost), 5);
      Stat.__\u003C\u003EmemoryCapacity = new Stat(nameof (memoryCapacity), 6);
      Stat.__\u003C\u003Eexplosiveness = new Stat(nameof (explosiveness), 7);
      Stat.__\u003C\u003Eflammability = new Stat(nameof (flammability), 8);
      Stat.__\u003C\u003Eradioactivity = new Stat(nameof (radioactivity), 9);
      Stat.__\u003C\u003Echarge = new Stat(nameof (charge), 10);
      Stat.__\u003C\u003EheatCapacity = new Stat(nameof (heatCapacity), 11);
      Stat.__\u003C\u003Eviscosity = new Stat(nameof (viscosity), 12);
      Stat.__\u003C\u003Etemperature = new Stat(nameof (temperature), 13);
      Stat.__\u003C\u003Eflying = new Stat(nameof (flying), 14);
      Stat.__\u003C\u003Espeed = new Stat(nameof (speed), 15);
      Stat.__\u003C\u003EbuildSpeed = new Stat(nameof (buildSpeed), 16);
      Stat.__\u003C\u003EmineSpeed = new Stat(nameof (mineSpeed), 17);
      Stat.__\u003C\u003EmineTier = new Stat(nameof (mineTier), 18);
      Stat.__\u003C\u003EpayloadCapacity = new Stat(nameof (payloadCapacity), 19);
      Stat.__\u003C\u003EcommandLimit = new Stat(nameof (commandLimit), 20);
      Stat.__\u003C\u003EbaseDeflectChance = new Stat(nameof (baseDeflectChance), 21);
      Stat.__\u003C\u003ElightningChance = new Stat(nameof (lightningChance), 22);
      Stat.__\u003C\u003ElightningDamage = new Stat(nameof (lightningDamage), 23);
      Stat.__\u003C\u003Eabilities = new Stat(nameof (abilities), 24);
      Stat.__\u003C\u003EcanBoost = new Stat(nameof (canBoost), 25);
      Stat.__\u003C\u003EmaxUnits = new Stat(nameof (maxUnits), 26);
      Stat.__\u003C\u003EdamageMultiplier = new Stat(nameof (damageMultiplier), 27);
      Stat.__\u003C\u003EhealthMultiplier = new Stat(nameof (healthMultiplier), 28);
      Stat.__\u003C\u003EspeedMultiplier = new Stat(nameof (speedMultiplier), 29);
      Stat.__\u003C\u003EreloadMultiplier = new Stat(nameof (reloadMultiplier), 30);
      Stat.__\u003C\u003EbuildSpeedMultiplier = new Stat(nameof (buildSpeedMultiplier), 31);
      Stat.__\u003C\u003Ereactive = new Stat(nameof (reactive), 32);
      Stat.__\u003C\u003EitemCapacity = new Stat(nameof (itemCapacity), 33, StatCat.__\u003C\u003Eitems);
      Stat.__\u003C\u003EitemsMoved = new Stat(nameof (itemsMoved), 34, StatCat.__\u003C\u003Eitems);
      Stat.__\u003C\u003ElaunchTime = new Stat(nameof (launchTime), 35, StatCat.__\u003C\u003Eitems);
      Stat.__\u003C\u003EmaxConsecutive = new Stat(nameof (maxConsecutive), 36, StatCat.__\u003C\u003Eitems);
      Stat.__\u003C\u003EliquidCapacity = new Stat(nameof (liquidCapacity), 37, StatCat.__\u003C\u003Eliquids);
      Stat.__\u003C\u003EpowerCapacity = new Stat(nameof (powerCapacity), 38, StatCat.__\u003C\u003Epower);
      Stat.__\u003C\u003EpowerUse = new Stat(nameof (powerUse), 39, StatCat.__\u003C\u003Epower);
      Stat.__\u003C\u003EpowerDamage = new Stat(nameof (powerDamage), 40, StatCat.__\u003C\u003Epower);
      Stat.__\u003C\u003EpowerRange = new Stat(nameof (powerRange), 41, StatCat.__\u003C\u003Epower);
      Stat.__\u003C\u003EpowerConnections = new Stat(nameof (powerConnections), 42, StatCat.__\u003C\u003Epower);
      Stat.__\u003C\u003EbasePowerGeneration = new Stat(nameof (basePowerGeneration), 43, StatCat.__\u003C\u003Epower);
      Stat.__\u003C\u003Etiles = new Stat(nameof (tiles), 44, StatCat.__\u003C\u003Ecrafting);
      Stat.__\u003C\u003Einput = new Stat(nameof (input), 45, StatCat.__\u003C\u003Ecrafting);
      Stat.__\u003C\u003Eoutput = new Stat(nameof (output), 46, StatCat.__\u003C\u003Ecrafting);
      Stat.__\u003C\u003EproductionTime = new Stat(nameof (productionTime), 47, StatCat.__\u003C\u003Ecrafting);
      Stat.__\u003C\u003EdrillTier = new Stat(nameof (drillTier), 48, StatCat.__\u003C\u003Ecrafting);
      Stat.__\u003C\u003EdrillSpeed = new Stat(nameof (drillSpeed), 49, StatCat.__\u003C\u003Ecrafting);
      Stat.__\u003C\u003ElinkRange = new Stat(nameof (linkRange), 50, StatCat.__\u003C\u003Ecrafting);
      Stat.__\u003C\u003Einstructions = new Stat(nameof (instructions), 51, StatCat.__\u003C\u003Ecrafting);
      Stat.__\u003C\u003Eweapons = new Stat(nameof (weapons), 52, StatCat.__\u003C\u003Efunction);
      Stat.__\u003C\u003Ebullet = new Stat(nameof (bullet), 53, StatCat.__\u003C\u003Efunction);
      Stat.__\u003C\u003EspeedIncrease = new Stat(nameof (speedIncrease), 54, StatCat.__\u003C\u003Efunction);
      Stat.__\u003C\u003ErepairTime = new Stat(nameof (repairTime), 55, StatCat.__\u003C\u003Efunction);
      Stat.__\u003C\u003Erange = new Stat(nameof (range), 56, StatCat.__\u003C\u003Efunction);
      Stat.__\u003C\u003EshootRange = new Stat(nameof (shootRange), 57, StatCat.__\u003C\u003Efunction);
      Stat.__\u003C\u003Einaccuracy = new Stat(nameof (inaccuracy), 58, StatCat.__\u003C\u003Efunction);
      Stat.__\u003C\u003Eshots = new Stat(nameof (shots), 59, StatCat.__\u003C\u003Efunction);
      Stat.__\u003C\u003Ereload = new Stat(nameof (reload), 60, StatCat.__\u003C\u003Efunction);
      Stat.__\u003C\u003EpowerShot = new Stat(nameof (powerShot), 61, StatCat.__\u003C\u003Efunction);
      Stat.__\u003C\u003EtargetsAir = new Stat(nameof (targetsAir), 62, StatCat.__\u003C\u003Efunction);
      Stat.__\u003C\u003EtargetsGround = new Stat(nameof (targetsGround), 63, StatCat.__\u003C\u003Efunction);
      Stat.__\u003C\u003Edamage = new Stat(nameof (damage), 64, StatCat.__\u003C\u003Efunction);
      Stat.__\u003C\u003Eammo = new Stat(nameof (ammo), 65, StatCat.__\u003C\u003Efunction);
      Stat.__\u003C\u003EammoUse = new Stat(nameof (ammoUse), 66, StatCat.__\u003C\u003Efunction);
      Stat.__\u003C\u003EshieldHealth = new Stat(nameof (shieldHealth), 67, StatCat.__\u003C\u003Efunction);
      Stat.__\u003C\u003EcooldownTime = new Stat(nameof (cooldownTime), 68, StatCat.__\u003C\u003Efunction);
      Stat.__\u003C\u003Ebooster = new Stat(nameof (booster), 69, StatCat.__\u003C\u003Eoptional);
      Stat.__\u003C\u003EboostEffect = new Stat(nameof (boostEffect), 70, StatCat.__\u003C\u003Eoptional);
      Stat.__\u003C\u003Eaffinities = new Stat(nameof (affinities), 71, StatCat.__\u003C\u003Eoptional);
      Stat.__\u003C\u003Eopposites = new Stat(nameof (opposites), 72, StatCat.__\u003C\u003Eoptional);
      Stat.\u0024VALUES = new Stat[73]
      {
        Stat.__\u003C\u003Ehealth,
        Stat.__\u003C\u003Earmor,
        Stat.__\u003C\u003Esize,
        Stat.__\u003C\u003EdisplaySize,
        Stat.__\u003C\u003EbuildTime,
        Stat.__\u003C\u003EbuildCost,
        Stat.__\u003C\u003EmemoryCapacity,
        Stat.__\u003C\u003Eexplosiveness,
        Stat.__\u003C\u003Eflammability,
        Stat.__\u003C\u003Eradioactivity,
        Stat.__\u003C\u003Echarge,
        Stat.__\u003C\u003EheatCapacity,
        Stat.__\u003C\u003Eviscosity,
        Stat.__\u003C\u003Etemperature,
        Stat.__\u003C\u003Eflying,
        Stat.__\u003C\u003Espeed,
        Stat.__\u003C\u003EbuildSpeed,
        Stat.__\u003C\u003EmineSpeed,
        Stat.__\u003C\u003EmineTier,
        Stat.__\u003C\u003EpayloadCapacity,
        Stat.__\u003C\u003EcommandLimit,
        Stat.__\u003C\u003EbaseDeflectChance,
        Stat.__\u003C\u003ElightningChance,
        Stat.__\u003C\u003ElightningDamage,
        Stat.__\u003C\u003Eabilities,
        Stat.__\u003C\u003EcanBoost,
        Stat.__\u003C\u003EmaxUnits,
        Stat.__\u003C\u003EdamageMultiplier,
        Stat.__\u003C\u003EhealthMultiplier,
        Stat.__\u003C\u003EspeedMultiplier,
        Stat.__\u003C\u003EreloadMultiplier,
        Stat.__\u003C\u003EbuildSpeedMultiplier,
        Stat.__\u003C\u003Ereactive,
        Stat.__\u003C\u003EitemCapacity,
        Stat.__\u003C\u003EitemsMoved,
        Stat.__\u003C\u003ElaunchTime,
        Stat.__\u003C\u003EmaxConsecutive,
        Stat.__\u003C\u003EliquidCapacity,
        Stat.__\u003C\u003EpowerCapacity,
        Stat.__\u003C\u003EpowerUse,
        Stat.__\u003C\u003EpowerDamage,
        Stat.__\u003C\u003EpowerRange,
        Stat.__\u003C\u003EpowerConnections,
        Stat.__\u003C\u003EbasePowerGeneration,
        Stat.__\u003C\u003Etiles,
        Stat.__\u003C\u003Einput,
        Stat.__\u003C\u003Eoutput,
        Stat.__\u003C\u003EproductionTime,
        Stat.__\u003C\u003EdrillTier,
        Stat.__\u003C\u003EdrillSpeed,
        Stat.__\u003C\u003ElinkRange,
        Stat.__\u003C\u003Einstructions,
        Stat.__\u003C\u003Eweapons,
        Stat.__\u003C\u003Ebullet,
        Stat.__\u003C\u003EspeedIncrease,
        Stat.__\u003C\u003ErepairTime,
        Stat.__\u003C\u003Erange,
        Stat.__\u003C\u003EshootRange,
        Stat.__\u003C\u003Einaccuracy,
        Stat.__\u003C\u003Eshots,
        Stat.__\u003C\u003Ereload,
        Stat.__\u003C\u003EpowerShot,
        Stat.__\u003C\u003EtargetsAir,
        Stat.__\u003C\u003EtargetsGround,
        Stat.__\u003C\u003Edamage,
        Stat.__\u003C\u003Eammo,
        Stat.__\u003C\u003EammoUse,
        Stat.__\u003C\u003EshieldHealth,
        Stat.__\u003C\u003EcooldownTime,
        Stat.__\u003C\u003Ebooster,
        Stat.__\u003C\u003EboostEffect,
        Stat.__\u003C\u003Eaffinities,
        Stat.__\u003C\u003Eopposites
      };
    }

    [Modifiers]
    public static Stat health
    {
      [HideFromJava] get => Stat.__\u003C\u003Ehealth;
    }

    [Modifiers]
    public static Stat armor
    {
      [HideFromJava] get => Stat.__\u003C\u003Earmor;
    }

    [Modifiers]
    public static Stat size
    {
      [HideFromJava] get => Stat.__\u003C\u003Esize;
    }

    [Modifiers]
    public static Stat displaySize
    {
      [HideFromJava] get => Stat.__\u003C\u003EdisplaySize;
    }

    [Modifiers]
    public static Stat buildTime
    {
      [HideFromJava] get => Stat.__\u003C\u003EbuildTime;
    }

    [Modifiers]
    public static Stat buildCost
    {
      [HideFromJava] get => Stat.__\u003C\u003EbuildCost;
    }

    [Modifiers]
    public static Stat memoryCapacity
    {
      [HideFromJava] get => Stat.__\u003C\u003EmemoryCapacity;
    }

    [Modifiers]
    public static Stat explosiveness
    {
      [HideFromJava] get => Stat.__\u003C\u003Eexplosiveness;
    }

    [Modifiers]
    public static Stat flammability
    {
      [HideFromJava] get => Stat.__\u003C\u003Eflammability;
    }

    [Modifiers]
    public static Stat radioactivity
    {
      [HideFromJava] get => Stat.__\u003C\u003Eradioactivity;
    }

    [Modifiers]
    public static Stat charge
    {
      [HideFromJava] get => Stat.__\u003C\u003Echarge;
    }

    [Modifiers]
    public static Stat heatCapacity
    {
      [HideFromJava] get => Stat.__\u003C\u003EheatCapacity;
    }

    [Modifiers]
    public static Stat viscosity
    {
      [HideFromJava] get => Stat.__\u003C\u003Eviscosity;
    }

    [Modifiers]
    public static Stat temperature
    {
      [HideFromJava] get => Stat.__\u003C\u003Etemperature;
    }

    [Modifiers]
    public static Stat flying
    {
      [HideFromJava] get => Stat.__\u003C\u003Eflying;
    }

    [Modifiers]
    public static Stat speed
    {
      [HideFromJava] get => Stat.__\u003C\u003Espeed;
    }

    [Modifiers]
    public static Stat buildSpeed
    {
      [HideFromJava] get => Stat.__\u003C\u003EbuildSpeed;
    }

    [Modifiers]
    public static Stat mineSpeed
    {
      [HideFromJava] get => Stat.__\u003C\u003EmineSpeed;
    }

    [Modifiers]
    public static Stat mineTier
    {
      [HideFromJava] get => Stat.__\u003C\u003EmineTier;
    }

    [Modifiers]
    public static Stat payloadCapacity
    {
      [HideFromJava] get => Stat.__\u003C\u003EpayloadCapacity;
    }

    [Modifiers]
    public static Stat commandLimit
    {
      [HideFromJava] get => Stat.__\u003C\u003EcommandLimit;
    }

    [Modifiers]
    public static Stat baseDeflectChance
    {
      [HideFromJava] get => Stat.__\u003C\u003EbaseDeflectChance;
    }

    [Modifiers]
    public static Stat lightningChance
    {
      [HideFromJava] get => Stat.__\u003C\u003ElightningChance;
    }

    [Modifiers]
    public static Stat lightningDamage
    {
      [HideFromJava] get => Stat.__\u003C\u003ElightningDamage;
    }

    [Modifiers]
    public static Stat abilities
    {
      [HideFromJava] get => Stat.__\u003C\u003Eabilities;
    }

    [Modifiers]
    public static Stat canBoost
    {
      [HideFromJava] get => Stat.__\u003C\u003EcanBoost;
    }

    [Modifiers]
    public static Stat maxUnits
    {
      [HideFromJava] get => Stat.__\u003C\u003EmaxUnits;
    }

    [Modifiers]
    public static Stat damageMultiplier
    {
      [HideFromJava] get => Stat.__\u003C\u003EdamageMultiplier;
    }

    [Modifiers]
    public static Stat healthMultiplier
    {
      [HideFromJava] get => Stat.__\u003C\u003EhealthMultiplier;
    }

    [Modifiers]
    public static Stat speedMultiplier
    {
      [HideFromJava] get => Stat.__\u003C\u003EspeedMultiplier;
    }

    [Modifiers]
    public static Stat reloadMultiplier
    {
      [HideFromJava] get => Stat.__\u003C\u003EreloadMultiplier;
    }

    [Modifiers]
    public static Stat buildSpeedMultiplier
    {
      [HideFromJava] get => Stat.__\u003C\u003EbuildSpeedMultiplier;
    }

    [Modifiers]
    public static Stat reactive
    {
      [HideFromJava] get => Stat.__\u003C\u003Ereactive;
    }

    [Modifiers]
    public static Stat itemCapacity
    {
      [HideFromJava] get => Stat.__\u003C\u003EitemCapacity;
    }

    [Modifiers]
    public static Stat itemsMoved
    {
      [HideFromJava] get => Stat.__\u003C\u003EitemsMoved;
    }

    [Modifiers]
    public static Stat launchTime
    {
      [HideFromJava] get => Stat.__\u003C\u003ElaunchTime;
    }

    [Modifiers]
    public static Stat maxConsecutive
    {
      [HideFromJava] get => Stat.__\u003C\u003EmaxConsecutive;
    }

    [Modifiers]
    public static Stat liquidCapacity
    {
      [HideFromJava] get => Stat.__\u003C\u003EliquidCapacity;
    }

    [Modifiers]
    public static Stat powerCapacity
    {
      [HideFromJava] get => Stat.__\u003C\u003EpowerCapacity;
    }

    [Modifiers]
    public static Stat powerUse
    {
      [HideFromJava] get => Stat.__\u003C\u003EpowerUse;
    }

    [Modifiers]
    public static Stat powerDamage
    {
      [HideFromJava] get => Stat.__\u003C\u003EpowerDamage;
    }

    [Modifiers]
    public static Stat powerRange
    {
      [HideFromJava] get => Stat.__\u003C\u003EpowerRange;
    }

    [Modifiers]
    public static Stat powerConnections
    {
      [HideFromJava] get => Stat.__\u003C\u003EpowerConnections;
    }

    [Modifiers]
    public static Stat basePowerGeneration
    {
      [HideFromJava] get => Stat.__\u003C\u003EbasePowerGeneration;
    }

    [Modifiers]
    public static Stat tiles
    {
      [HideFromJava] get => Stat.__\u003C\u003Etiles;
    }

    [Modifiers]
    public static Stat input
    {
      [HideFromJava] get => Stat.__\u003C\u003Einput;
    }

    [Modifiers]
    public static Stat output
    {
      [HideFromJava] get => Stat.__\u003C\u003Eoutput;
    }

    [Modifiers]
    public static Stat productionTime
    {
      [HideFromJava] get => Stat.__\u003C\u003EproductionTime;
    }

    [Modifiers]
    public static Stat drillTier
    {
      [HideFromJava] get => Stat.__\u003C\u003EdrillTier;
    }

    [Modifiers]
    public static Stat drillSpeed
    {
      [HideFromJava] get => Stat.__\u003C\u003EdrillSpeed;
    }

    [Modifiers]
    public static Stat linkRange
    {
      [HideFromJava] get => Stat.__\u003C\u003ElinkRange;
    }

    [Modifiers]
    public static Stat instructions
    {
      [HideFromJava] get => Stat.__\u003C\u003Einstructions;
    }

    [Modifiers]
    public static Stat weapons
    {
      [HideFromJava] get => Stat.__\u003C\u003Eweapons;
    }

    [Modifiers]
    public static Stat bullet
    {
      [HideFromJava] get => Stat.__\u003C\u003Ebullet;
    }

    [Modifiers]
    public static Stat speedIncrease
    {
      [HideFromJava] get => Stat.__\u003C\u003EspeedIncrease;
    }

    [Modifiers]
    public static Stat repairTime
    {
      [HideFromJava] get => Stat.__\u003C\u003ErepairTime;
    }

    [Modifiers]
    public static Stat range
    {
      [HideFromJava] get => Stat.__\u003C\u003Erange;
    }

    [Modifiers]
    public static Stat shootRange
    {
      [HideFromJava] get => Stat.__\u003C\u003EshootRange;
    }

    [Modifiers]
    public static Stat inaccuracy
    {
      [HideFromJava] get => Stat.__\u003C\u003Einaccuracy;
    }

    [Modifiers]
    public static Stat shots
    {
      [HideFromJava] get => Stat.__\u003C\u003Eshots;
    }

    [Modifiers]
    public static Stat reload
    {
      [HideFromJava] get => Stat.__\u003C\u003Ereload;
    }

    [Modifiers]
    public static Stat powerShot
    {
      [HideFromJava] get => Stat.__\u003C\u003EpowerShot;
    }

    [Modifiers]
    public static Stat targetsAir
    {
      [HideFromJava] get => Stat.__\u003C\u003EtargetsAir;
    }

    [Modifiers]
    public static Stat targetsGround
    {
      [HideFromJava] get => Stat.__\u003C\u003EtargetsGround;
    }

    [Modifiers]
    public static Stat damage
    {
      [HideFromJava] get => Stat.__\u003C\u003Edamage;
    }

    [Modifiers]
    public static Stat ammo
    {
      [HideFromJava] get => Stat.__\u003C\u003Eammo;
    }

    [Modifiers]
    public static Stat ammoUse
    {
      [HideFromJava] get => Stat.__\u003C\u003EammoUse;
    }

    [Modifiers]
    public static Stat shieldHealth
    {
      [HideFromJava] get => Stat.__\u003C\u003EshieldHealth;
    }

    [Modifiers]
    public static Stat cooldownTime
    {
      [HideFromJava] get => Stat.__\u003C\u003EcooldownTime;
    }

    [Modifiers]
    public static Stat booster
    {
      [HideFromJava] get => Stat.__\u003C\u003Ebooster;
    }

    [Modifiers]
    public static Stat boostEffect
    {
      [HideFromJava] get => Stat.__\u003C\u003EboostEffect;
    }

    [Modifiers]
    public static Stat affinities
    {
      [HideFromJava] get => Stat.__\u003C\u003Eaffinities;
    }

    [Modifiers]
    public static Stat opposites
    {
      [HideFromJava] get => Stat.__\u003C\u003Eopposites;
    }

    [Modifiers]
    public StatCat category
    {
      [HideFromJava] get => this.__\u003C\u003Ecategory;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Ecategory = value;
    }

    [HideFromJava]
    [Serializable]
    public enum __Enum
    {
      health,
      armor,
      size,
      displaySize,
      buildTime,
      buildCost,
      memoryCapacity,
      explosiveness,
      flammability,
      radioactivity,
      charge,
      heatCapacity,
      viscosity,
      temperature,
      flying,
      speed,
      buildSpeed,
      mineSpeed,
      mineTier,
      payloadCapacity,
      commandLimit,
      baseDeflectChance,
      lightningChance,
      lightningDamage,
      abilities,
      canBoost,
      maxUnits,
      damageMultiplier,
      healthMultiplier,
      speedMultiplier,
      reloadMultiplier,
      buildSpeedMultiplier,
      reactive,
      itemCapacity,
      itemsMoved,
      launchTime,
      maxConsecutive,
      liquidCapacity,
      powerCapacity,
      powerUse,
      powerDamage,
      powerRange,
      powerConnections,
      basePowerGeneration,
      tiles,
      input,
      output,
      productionTime,
      drillTier,
      drillSpeed,
      linkRange,
      instructions,
      weapons,
      bullet,
      speedIncrease,
      repairTime,
      range,
      shootRange,
      inaccuracy,
      shots,
      reload,
      powerShot,
      targetsAir,
      targetsGround,
      damage,
      ammo,
      ammoUse,
      shieldHealth,
      cooldownTime,
      booster,
      boostEffect,
      affinities,
      opposites,
    }
  }
}
