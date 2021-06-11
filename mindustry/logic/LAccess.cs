// Decompiled with JetBrains decompiler
// Type: mindustry.logic.LAccess
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.func;
using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.logic
{
  [Signature("Ljava/lang/Enum<Lmindustry/logic/LAccess;>;")]
  [Modifiers]
  [Serializable]
  public sealed class LAccess : Enum
  {
    [Modifiers]
    internal static LAccess __\u003C\u003EtotalItems;
    [Modifiers]
    internal static LAccess __\u003C\u003EfirstItem;
    [Modifiers]
    internal static LAccess __\u003C\u003EtotalLiquids;
    [Modifiers]
    internal static LAccess __\u003C\u003EtotalPower;
    [Modifiers]
    internal static LAccess __\u003C\u003EitemCapacity;
    [Modifiers]
    internal static LAccess __\u003C\u003EliquidCapacity;
    [Modifiers]
    internal static LAccess __\u003C\u003EpowerCapacity;
    [Modifiers]
    internal static LAccess __\u003C\u003EpowerNetStored;
    [Modifiers]
    internal static LAccess __\u003C\u003EpowerNetCapacity;
    [Modifiers]
    internal static LAccess __\u003C\u003EpowerNetIn;
    [Modifiers]
    internal static LAccess __\u003C\u003EpowerNetOut;
    [Modifiers]
    internal static LAccess __\u003C\u003Eammo;
    [Modifiers]
    internal static LAccess __\u003C\u003EammoCapacity;
    [Modifiers]
    internal static LAccess __\u003C\u003Ehealth;
    [Modifiers]
    internal static LAccess __\u003C\u003EmaxHealth;
    [Modifiers]
    internal static LAccess __\u003C\u003Eheat;
    [Modifiers]
    internal static LAccess __\u003C\u003Eefficiency;
    [Modifiers]
    internal static LAccess __\u003C\u003Etimescale;
    [Modifiers]
    internal static LAccess __\u003C\u003Erotation;
    [Modifiers]
    internal static LAccess __\u003C\u003Ex;
    [Modifiers]
    internal static LAccess __\u003C\u003Ey;
    [Modifiers]
    internal static LAccess __\u003C\u003EshootX;
    [Modifiers]
    internal static LAccess __\u003C\u003EshootY;
    [Modifiers]
    internal static LAccess __\u003C\u003Esize;
    [Modifiers]
    internal static LAccess __\u003C\u003Edead;
    [Modifiers]
    internal static LAccess __\u003C\u003Erange;
    [Modifiers]
    internal static LAccess __\u003C\u003Eshooting;
    [Modifiers]
    internal static LAccess __\u003C\u003Eboosting;
    [Modifiers]
    internal static LAccess __\u003C\u003EmineX;
    [Modifiers]
    internal static LAccess __\u003C\u003EmineY;
    [Modifiers]
    internal static LAccess __\u003C\u003Emining;
    [Modifiers]
    internal static LAccess __\u003C\u003Eteam;
    [Modifiers]
    internal static LAccess __\u003C\u003Etype;
    [Modifiers]
    internal static LAccess __\u003C\u003Eflag;
    [Modifiers]
    internal static LAccess __\u003C\u003Econtrolled;
    [Modifiers]
    internal static LAccess __\u003C\u003Econtroller;
    [Modifiers]
    internal static LAccess __\u003C\u003Ecommanded;
    [Modifiers]
    internal static LAccess __\u003C\u003Ename;
    [Modifiers]
    internal static LAccess __\u003C\u003Econfig;
    [Modifiers]
    internal static LAccess __\u003C\u003EpayloadCount;
    [Modifiers]
    internal static LAccess __\u003C\u003EpayloadType;
    [Modifiers]
    internal static LAccess __\u003C\u003Eenabled;
    [Modifiers]
    internal static LAccess __\u003C\u003Eshoot;
    [Modifiers]
    internal static LAccess __\u003C\u003Eshootp;
    [Modifiers]
    internal static LAccess __\u003C\u003Econfigure;
    [Modifiers]
    internal static LAccess __\u003C\u003Ecolor;
    internal string[] __\u003C\u003Eparams;
    internal bool __\u003C\u003EisObj;
    internal static LAccess[] __\u003C\u003Eall;
    internal static LAccess[] __\u003C\u003Esenseable;
    internal static LAccess[] __\u003C\u003Econtrols;
    [Modifiers]
    private static LAccess[] \u0024VALUES;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(6)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static LAccess[] values() => (LAccess[]) LAccess.\u0024VALUES.Clone();

    [LineNumberTable(6)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static LAccess valueOf(string name) => (LAccess) Enum.valueOf((Class) ClassLiteral<LAccess>.Value, name);

    [Signature("([Ljava/lang/String;)V")]
    [LineNumberTable(new byte[] {14, 106, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private LAccess(string _param1, int _param2, params string[] _param3)
      : base(_param1, _param2)
    {
      LAccess laccess = this;
      this.__\u003C\u003Eparams = _param3;
      this.__\u003C\u003EisObj = false;
      GC.KeepAlive((object) this);
    }

    [Signature("(Z[Ljava/lang/String;)V")]
    [LineNumberTable(new byte[] {159, 125, 98, 106, 104, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private LAccess(string _param1, int _param2, bool _param3, params string[] _param4)
    {
      int num = _param3 ? 1 : 0;
      // ISSUE: explicit constructor call
      base.\u002Ector(_param1, _param2);
      LAccess laccess = this;
      this.__\u003C\u003Eparams = _param4;
      this.__\u003C\u003EisObj = num != 0;
      GC.KeepAlive((object) this);
    }

    [Modifiers]
    [LineNumberTable(61)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024static\u00240([In] LAccess obj0) => obj0.__\u003C\u003Eparams.Length <= 1;

    [Modifiers]
    [LineNumberTable(62)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024static\u00241([In] LAccess obj0) => obj0.__\u003C\u003Eparams.Length > 0;

    [LineNumberTable(new byte[] {159, 141, 173, 118, 118, 118, 118, 118, 118, 118, 118, 118, 119, 119, 119, 119, 119, 119, 119, 119, 119, 119, 119, 119, 119, 119, 119, 119, 119, 119, 119, 119, 119, 119, 119, 119, 119, 119, 119, 119, 119, 119, 119, 183, 127, 0, 127, 16, 127, 9, 127, 1, 255, 16, 16, 255, 161, 66, 118, 106, 127, 9})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static LAccess()
    {
      if (ByteCodeHelper.isAlreadyInited("mindustry.logic.LAccess"))
        return;
      LAccess.__\u003C\u003EtotalItems = new LAccess(nameof (totalItems), 0, new string[0]);
      LAccess.__\u003C\u003EfirstItem = new LAccess(nameof (firstItem), 1, new string[0]);
      LAccess.__\u003C\u003EtotalLiquids = new LAccess(nameof (totalLiquids), 2, new string[0]);
      LAccess.__\u003C\u003EtotalPower = new LAccess(nameof (totalPower), 3, new string[0]);
      LAccess.__\u003C\u003EitemCapacity = new LAccess(nameof (itemCapacity), 4, new string[0]);
      LAccess.__\u003C\u003EliquidCapacity = new LAccess(nameof (liquidCapacity), 5, new string[0]);
      LAccess.__\u003C\u003EpowerCapacity = new LAccess(nameof (powerCapacity), 6, new string[0]);
      LAccess.__\u003C\u003EpowerNetStored = new LAccess(nameof (powerNetStored), 7, new string[0]);
      LAccess.__\u003C\u003EpowerNetCapacity = new LAccess(nameof (powerNetCapacity), 8, new string[0]);
      LAccess.__\u003C\u003EpowerNetIn = new LAccess(nameof (powerNetIn), 9, new string[0]);
      LAccess.__\u003C\u003EpowerNetOut = new LAccess(nameof (powerNetOut), 10, new string[0]);
      LAccess.__\u003C\u003Eammo = new LAccess(nameof (ammo), 11, new string[0]);
      LAccess.__\u003C\u003EammoCapacity = new LAccess(nameof (ammoCapacity), 12, new string[0]);
      LAccess.__\u003C\u003Ehealth = new LAccess(nameof (health), 13, new string[0]);
      LAccess.__\u003C\u003EmaxHealth = new LAccess(nameof (maxHealth), 14, new string[0]);
      LAccess.__\u003C\u003Eheat = new LAccess(nameof (heat), 15, new string[0]);
      LAccess.__\u003C\u003Eefficiency = new LAccess(nameof (efficiency), 16, new string[0]);
      LAccess.__\u003C\u003Etimescale = new LAccess(nameof (timescale), 17, new string[0]);
      LAccess.__\u003C\u003Erotation = new LAccess(nameof (rotation), 18, new string[0]);
      LAccess.__\u003C\u003Ex = new LAccess(nameof (x), 19, new string[0]);
      LAccess.__\u003C\u003Ey = new LAccess(nameof (y), 20, new string[0]);
      LAccess.__\u003C\u003EshootX = new LAccess(nameof (shootX), 21, new string[0]);
      LAccess.__\u003C\u003EshootY = new LAccess(nameof (shootY), 22, new string[0]);
      LAccess.__\u003C\u003Esize = new LAccess(nameof (size), 23, new string[0]);
      LAccess.__\u003C\u003Edead = new LAccess(nameof (dead), 24, new string[0]);
      LAccess.__\u003C\u003Erange = new LAccess(nameof (range), 25, new string[0]);
      LAccess.__\u003C\u003Eshooting = new LAccess(nameof (shooting), 26, new string[0]);
      LAccess.__\u003C\u003Eboosting = new LAccess(nameof (boosting), 27, new string[0]);
      LAccess.__\u003C\u003EmineX = new LAccess(nameof (mineX), 28, new string[0]);
      LAccess.__\u003C\u003EmineY = new LAccess(nameof (mineY), 29, new string[0]);
      LAccess.__\u003C\u003Emining = new LAccess(nameof (mining), 30, new string[0]);
      LAccess.__\u003C\u003Eteam = new LAccess(nameof (team), 31, new string[0]);
      LAccess.__\u003C\u003Etype = new LAccess(nameof (type), 32, new string[0]);
      LAccess.__\u003C\u003Eflag = new LAccess(nameof (flag), 33, new string[0]);
      LAccess.__\u003C\u003Econtrolled = new LAccess(nameof (controlled), 34, new string[0]);
      LAccess.__\u003C\u003Econtroller = new LAccess(nameof (controller), 35, new string[0]);
      LAccess.__\u003C\u003Ecommanded = new LAccess(nameof (commanded), 36, new string[0]);
      LAccess.__\u003C\u003Ename = new LAccess(nameof (name), 37, new string[0]);
      LAccess.__\u003C\u003Econfig = new LAccess(nameof (config), 38, new string[0]);
      LAccess.__\u003C\u003EpayloadCount = new LAccess(nameof (payloadCount), 39, new string[0]);
      LAccess.__\u003C\u003EpayloadType = new LAccess(nameof (payloadType), 40, new string[0]);
      LAccess.__\u003C\u003Eenabled = new LAccess(nameof (enabled), 41, new string[1]
      {
        "to"
      });
      LAccess.__\u003C\u003Eshoot = new LAccess(nameof (shoot), 42, new string[3]
      {
        nameof (x),
        nameof (y),
        nameof (shoot)
      });
      LAccess.__\u003C\u003Eshootp = new LAccess(nameof (shootp), 43, true, new string[2]
      {
        "unit",
        nameof (shoot)
      });
      LAccess.__\u003C\u003Econfigure = new LAccess(nameof (configure), 44, true, new string[1]
      {
        "to"
      });
      LAccess.__\u003C\u003Ecolor = new LAccess(nameof (color), 45, new string[3]
      {
        "r",
        "g",
        "b"
      });
      LAccess.\u0024VALUES = new LAccess[46]
      {
        LAccess.__\u003C\u003EtotalItems,
        LAccess.__\u003C\u003EfirstItem,
        LAccess.__\u003C\u003EtotalLiquids,
        LAccess.__\u003C\u003EtotalPower,
        LAccess.__\u003C\u003EitemCapacity,
        LAccess.__\u003C\u003EliquidCapacity,
        LAccess.__\u003C\u003EpowerCapacity,
        LAccess.__\u003C\u003EpowerNetStored,
        LAccess.__\u003C\u003EpowerNetCapacity,
        LAccess.__\u003C\u003EpowerNetIn,
        LAccess.__\u003C\u003EpowerNetOut,
        LAccess.__\u003C\u003Eammo,
        LAccess.__\u003C\u003EammoCapacity,
        LAccess.__\u003C\u003Ehealth,
        LAccess.__\u003C\u003EmaxHealth,
        LAccess.__\u003C\u003Eheat,
        LAccess.__\u003C\u003Eefficiency,
        LAccess.__\u003C\u003Etimescale,
        LAccess.__\u003C\u003Erotation,
        LAccess.__\u003C\u003Ex,
        LAccess.__\u003C\u003Ey,
        LAccess.__\u003C\u003EshootX,
        LAccess.__\u003C\u003EshootY,
        LAccess.__\u003C\u003Esize,
        LAccess.__\u003C\u003Edead,
        LAccess.__\u003C\u003Erange,
        LAccess.__\u003C\u003Eshooting,
        LAccess.__\u003C\u003Eboosting,
        LAccess.__\u003C\u003EmineX,
        LAccess.__\u003C\u003EmineY,
        LAccess.__\u003C\u003Emining,
        LAccess.__\u003C\u003Eteam,
        LAccess.__\u003C\u003Etype,
        LAccess.__\u003C\u003Eflag,
        LAccess.__\u003C\u003Econtrolled,
        LAccess.__\u003C\u003Econtroller,
        LAccess.__\u003C\u003Ecommanded,
        LAccess.__\u003C\u003Ename,
        LAccess.__\u003C\u003Econfig,
        LAccess.__\u003C\u003EpayloadCount,
        LAccess.__\u003C\u003EpayloadType,
        LAccess.__\u003C\u003Eenabled,
        LAccess.__\u003C\u003Eshoot,
        LAccess.__\u003C\u003Eshootp,
        LAccess.__\u003C\u003Econfigure,
        LAccess.__\u003C\u003Ecolor
      };
      LAccess.__\u003C\u003Eall = LAccess.values();
      LAccess.__\u003C\u003Esenseable = (LAccess[]) Seq.select((object[]) LAccess.__\u003C\u003Eall, (Boolf) new LAccess.__\u003C\u003EAnon0()).toArray((Class) ClassLiteral<LAccess>.Value);
      LAccess.__\u003C\u003Econtrols = (LAccess[]) Seq.select((object[]) LAccess.__\u003C\u003Eall, (Boolf) new LAccess.__\u003C\u003EAnon1()).toArray((Class) ClassLiteral<LAccess>.Value);
    }

    [Modifiers]
    public static LAccess totalItems
    {
      [HideFromJava] get => LAccess.__\u003C\u003EtotalItems;
    }

    [Modifiers]
    public static LAccess firstItem
    {
      [HideFromJava] get => LAccess.__\u003C\u003EfirstItem;
    }

    [Modifiers]
    public static LAccess totalLiquids
    {
      [HideFromJava] get => LAccess.__\u003C\u003EtotalLiquids;
    }

    [Modifiers]
    public static LAccess totalPower
    {
      [HideFromJava] get => LAccess.__\u003C\u003EtotalPower;
    }

    [Modifiers]
    public static LAccess itemCapacity
    {
      [HideFromJava] get => LAccess.__\u003C\u003EitemCapacity;
    }

    [Modifiers]
    public static LAccess liquidCapacity
    {
      [HideFromJava] get => LAccess.__\u003C\u003EliquidCapacity;
    }

    [Modifiers]
    public static LAccess powerCapacity
    {
      [HideFromJava] get => LAccess.__\u003C\u003EpowerCapacity;
    }

    [Modifiers]
    public static LAccess powerNetStored
    {
      [HideFromJava] get => LAccess.__\u003C\u003EpowerNetStored;
    }

    [Modifiers]
    public static LAccess powerNetCapacity
    {
      [HideFromJava] get => LAccess.__\u003C\u003EpowerNetCapacity;
    }

    [Modifiers]
    public static LAccess powerNetIn
    {
      [HideFromJava] get => LAccess.__\u003C\u003EpowerNetIn;
    }

    [Modifiers]
    public static LAccess powerNetOut
    {
      [HideFromJava] get => LAccess.__\u003C\u003EpowerNetOut;
    }

    [Modifiers]
    public static LAccess ammo
    {
      [HideFromJava] get => LAccess.__\u003C\u003Eammo;
    }

    [Modifiers]
    public static LAccess ammoCapacity
    {
      [HideFromJava] get => LAccess.__\u003C\u003EammoCapacity;
    }

    [Modifiers]
    public static LAccess health
    {
      [HideFromJava] get => LAccess.__\u003C\u003Ehealth;
    }

    [Modifiers]
    public static LAccess maxHealth
    {
      [HideFromJava] get => LAccess.__\u003C\u003EmaxHealth;
    }

    [Modifiers]
    public static LAccess heat
    {
      [HideFromJava] get => LAccess.__\u003C\u003Eheat;
    }

    [Modifiers]
    public static LAccess efficiency
    {
      [HideFromJava] get => LAccess.__\u003C\u003Eefficiency;
    }

    [Modifiers]
    public static LAccess timescale
    {
      [HideFromJava] get => LAccess.__\u003C\u003Etimescale;
    }

    [Modifiers]
    public static LAccess rotation
    {
      [HideFromJava] get => LAccess.__\u003C\u003Erotation;
    }

    [Modifiers]
    public static LAccess x
    {
      [HideFromJava] get => LAccess.__\u003C\u003Ex;
    }

    [Modifiers]
    public static LAccess y
    {
      [HideFromJava] get => LAccess.__\u003C\u003Ey;
    }

    [Modifiers]
    public static LAccess shootX
    {
      [HideFromJava] get => LAccess.__\u003C\u003EshootX;
    }

    [Modifiers]
    public static LAccess shootY
    {
      [HideFromJava] get => LAccess.__\u003C\u003EshootY;
    }

    [Modifiers]
    public static LAccess size
    {
      [HideFromJava] get => LAccess.__\u003C\u003Esize;
    }

    [Modifiers]
    public static LAccess dead
    {
      [HideFromJava] get => LAccess.__\u003C\u003Edead;
    }

    [Modifiers]
    public static LAccess range
    {
      [HideFromJava] get => LAccess.__\u003C\u003Erange;
    }

    [Modifiers]
    public static LAccess shooting
    {
      [HideFromJava] get => LAccess.__\u003C\u003Eshooting;
    }

    [Modifiers]
    public static LAccess boosting
    {
      [HideFromJava] get => LAccess.__\u003C\u003Eboosting;
    }

    [Modifiers]
    public static LAccess mineX
    {
      [HideFromJava] get => LAccess.__\u003C\u003EmineX;
    }

    [Modifiers]
    public static LAccess mineY
    {
      [HideFromJava] get => LAccess.__\u003C\u003EmineY;
    }

    [Modifiers]
    public static LAccess mining
    {
      [HideFromJava] get => LAccess.__\u003C\u003Emining;
    }

    [Modifiers]
    public static LAccess team
    {
      [HideFromJava] get => LAccess.__\u003C\u003Eteam;
    }

    [Modifiers]
    public static LAccess type
    {
      [HideFromJava] get => LAccess.__\u003C\u003Etype;
    }

    [Modifiers]
    public static LAccess flag
    {
      [HideFromJava] get => LAccess.__\u003C\u003Eflag;
    }

    [Modifiers]
    public static LAccess controlled
    {
      [HideFromJava] get => LAccess.__\u003C\u003Econtrolled;
    }

    [Modifiers]
    public static LAccess controller
    {
      [HideFromJava] get => LAccess.__\u003C\u003Econtroller;
    }

    [Modifiers]
    public static LAccess commanded
    {
      [HideFromJava] get => LAccess.__\u003C\u003Ecommanded;
    }

    [Modifiers]
    public static LAccess name
    {
      [HideFromJava] get => LAccess.__\u003C\u003Ename;
    }

    [Modifiers]
    public static LAccess config
    {
      [HideFromJava] get => LAccess.__\u003C\u003Econfig;
    }

    [Modifiers]
    public static LAccess payloadCount
    {
      [HideFromJava] get => LAccess.__\u003C\u003EpayloadCount;
    }

    [Modifiers]
    public static LAccess payloadType
    {
      [HideFromJava] get => LAccess.__\u003C\u003EpayloadType;
    }

    [Modifiers]
    public static LAccess enabled
    {
      [HideFromJava] get => LAccess.__\u003C\u003Eenabled;
    }

    [Modifiers]
    public static LAccess shoot
    {
      [HideFromJava] get => LAccess.__\u003C\u003Eshoot;
    }

    [Modifiers]
    public static LAccess shootp
    {
      [HideFromJava] get => LAccess.__\u003C\u003Eshootp;
    }

    [Modifiers]
    public static LAccess configure
    {
      [HideFromJava] get => LAccess.__\u003C\u003Econfigure;
    }

    [Modifiers]
    public static LAccess color
    {
      [HideFromJava] get => LAccess.__\u003C\u003Ecolor;
    }

    [Modifiers]
    public string[] @params
    {
      [HideFromJava] get => this.__\u003C\u003Eparams;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Eparams = value;
    }

    [Modifiers]
    public bool isObj
    {
      [HideFromJava] get => this.__\u003C\u003EisObj;
      [HideFromJava] [param: In] private set => this.__\u003C\u003EisObj = value;
    }

    [Modifiers]
    public static LAccess[] all
    {
      [HideFromJava] get => LAccess.__\u003C\u003Eall;
    }

    [Modifiers]
    public static LAccess[] senseable
    {
      [HideFromJava] get => LAccess.__\u003C\u003Esenseable;
    }

    [Modifiers]
    public static LAccess[] controls
    {
      [HideFromJava] get => LAccess.__\u003C\u003Econtrols;
    }

    [HideFromJava]
    [Serializable]
    public enum __Enum
    {
      totalItems,
      firstItem,
      totalLiquids,
      totalPower,
      itemCapacity,
      liquidCapacity,
      powerCapacity,
      powerNetStored,
      powerNetCapacity,
      powerNetIn,
      powerNetOut,
      ammo,
      ammoCapacity,
      health,
      maxHealth,
      heat,
      efficiency,
      timescale,
      rotation,
      x,
      y,
      shootX,
      shootY,
      size,
      dead,
      range,
      shooting,
      boosting,
      mineX,
      mineY,
      mining,
      team,
      type,
      flag,
      controlled,
      controller,
      commanded,
      name,
      config,
      payloadCount,
      payloadType,
      enabled,
      shoot,
      shootp,
      configure,
      color,
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Boolf
    {
      internal __\u003C\u003EAnon0()
      {
      }

      public bool get([In] object obj0) => (LAccess.lambda\u0024static\u00240((LAccess) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Boolf
    {
      internal __\u003C\u003EAnon1()
      {
      }

      public bool get([In] object obj0) => (LAccess.lambda\u0024static\u00241((LAccess) obj0) ? 1 : 0) != 0;
    }
  }
}
