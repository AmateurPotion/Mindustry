// Decompiled with JetBrains decompiler
// Type: mindustry.logic.LUnitControl
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

namespace mindustry.logic
{
  [Signature("Ljava/lang/Enum<Lmindustry/logic/LUnitControl;>;")]
  [Modifiers]
  [Serializable]
  public sealed class LUnitControl : Enum
  {
    [Modifiers]
    internal static LUnitControl __\u003C\u003Eidle;
    [Modifiers]
    internal static LUnitControl __\u003C\u003Estop;
    [Modifiers]
    internal static LUnitControl __\u003C\u003Emove;
    [Modifiers]
    internal static LUnitControl __\u003C\u003Eapproach;
    [Modifiers]
    internal static LUnitControl __\u003C\u003Eboost;
    [Modifiers]
    internal static LUnitControl __\u003C\u003Epathfind;
    [Modifiers]
    internal static LUnitControl __\u003C\u003Etarget;
    [Modifiers]
    internal static LUnitControl __\u003C\u003Etargetp;
    [Modifiers]
    internal static LUnitControl __\u003C\u003EitemDrop;
    [Modifiers]
    internal static LUnitControl __\u003C\u003EitemTake;
    [Modifiers]
    internal static LUnitControl __\u003C\u003EpayDrop;
    [Modifiers]
    internal static LUnitControl __\u003C\u003EpayTake;
    [Modifiers]
    internal static LUnitControl __\u003C\u003Emine;
    [Modifiers]
    internal static LUnitControl __\u003C\u003Eflag;
    [Modifiers]
    internal static LUnitControl __\u003C\u003Ebuild;
    [Modifiers]
    internal static LUnitControl __\u003C\u003EgetBlock;
    [Modifiers]
    internal static LUnitControl __\u003C\u003Ewithin;
    internal string[] __\u003C\u003Eparams;
    internal static LUnitControl[] __\u003C\u003Eall;
    [Modifiers]
    private static LUnitControl[] \u0024VALUES;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(3)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static LUnitControl[] values() => (LUnitControl[]) LUnitControl.\u0024VALUES.Clone();

    [LineNumberTable(3)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static LUnitControl valueOf(string name) => (LUnitControl) Enum.valueOf((Class) ClassLiteral<LUnitControl>.Value, name);

    [Signature("([Ljava/lang/String;)V")]
    [LineNumberTable(new byte[] {159, 167, 106, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private LUnitControl(string _param1, int _param2, params string[] _param3)
      : base(_param1, _param2)
    {
      LUnitControl lunitControl = this;
      this.__\u003C\u003Eparams = _param3;
      GC.KeepAlive((object) this);
    }

    [LineNumberTable(new byte[] {159, 141, 77, 118, 118, 127, 7, 127, 15, 126, 118, 127, 15, 127, 7, 127, 7, 127, 16, 119, 127, 0, 127, 8, 127, 0, 127, 32, 127, 24, 255, 24, 47, 255, 125, 84})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static LUnitControl()
    {
      if (ByteCodeHelper.isAlreadyInited("mindustry.logic.LUnitControl"))
        return;
      LUnitControl.__\u003C\u003Eidle = new LUnitControl(nameof (idle), 0, new string[0]);
      LUnitControl.__\u003C\u003Estop = new LUnitControl(nameof (stop), 1, new string[0]);
      LUnitControl.__\u003C\u003Emove = new LUnitControl(nameof (move), 2, new string[2]
      {
        "x",
        "y"
      });
      LUnitControl.__\u003C\u003Eapproach = new LUnitControl(nameof (approach), 3, new string[3]
      {
        "x",
        "y",
        "radius"
      });
      LUnitControl.__\u003C\u003Eboost = new LUnitControl(nameof (boost), 4, new string[1]
      {
        "enable"
      });
      LUnitControl.__\u003C\u003Epathfind = new LUnitControl(nameof (pathfind), 5, new string[0]);
      LUnitControl.__\u003C\u003Etarget = new LUnitControl(nameof (target), 6, new string[3]
      {
        "x",
        "y",
        "shoot"
      });
      LUnitControl.__\u003C\u003Etargetp = new LUnitControl(nameof (targetp), 7, new string[2]
      {
        "unit",
        "shoot"
      });
      LUnitControl.__\u003C\u003EitemDrop = new LUnitControl(nameof (itemDrop), 8, new string[2]
      {
        "to",
        "amount"
      });
      LUnitControl.__\u003C\u003EitemTake = new LUnitControl(nameof (itemTake), 9, new string[3]
      {
        "from",
        "item",
        "amount"
      });
      LUnitControl.__\u003C\u003EpayDrop = new LUnitControl(nameof (payDrop), 10, new string[0]);
      LUnitControl.__\u003C\u003EpayTake = new LUnitControl(nameof (payTake), 11, new string[1]
      {
        "takeUnits"
      });
      LUnitControl.__\u003C\u003Emine = new LUnitControl(nameof (mine), 12, new string[2]
      {
        "x",
        "y"
      });
      LUnitControl.__\u003C\u003Eflag = new LUnitControl(nameof (flag), 13, new string[1]
      {
        "value"
      });
      LUnitControl.__\u003C\u003Ebuild = new LUnitControl(nameof (build), 14, new string[5]
      {
        "x",
        "y",
        "block",
        "rotation",
        "config"
      });
      LUnitControl.__\u003C\u003EgetBlock = new LUnitControl(nameof (getBlock), 15, new string[4]
      {
        "x",
        "y",
        "type",
        "building"
      });
      LUnitControl.__\u003C\u003Ewithin = new LUnitControl(nameof (within), 16, new string[4]
      {
        "x",
        "y",
        "radius",
        "result"
      });
      LUnitControl.\u0024VALUES = new LUnitControl[17]
      {
        LUnitControl.__\u003C\u003Eidle,
        LUnitControl.__\u003C\u003Estop,
        LUnitControl.__\u003C\u003Emove,
        LUnitControl.__\u003C\u003Eapproach,
        LUnitControl.__\u003C\u003Eboost,
        LUnitControl.__\u003C\u003Epathfind,
        LUnitControl.__\u003C\u003Etarget,
        LUnitControl.__\u003C\u003Etargetp,
        LUnitControl.__\u003C\u003EitemDrop,
        LUnitControl.__\u003C\u003EitemTake,
        LUnitControl.__\u003C\u003EpayDrop,
        LUnitControl.__\u003C\u003EpayTake,
        LUnitControl.__\u003C\u003Emine,
        LUnitControl.__\u003C\u003Eflag,
        LUnitControl.__\u003C\u003Ebuild,
        LUnitControl.__\u003C\u003EgetBlock,
        LUnitControl.__\u003C\u003Ewithin
      };
      LUnitControl.__\u003C\u003Eall = LUnitControl.values();
    }

    [Modifiers]
    public static LUnitControl idle
    {
      [HideFromJava] get => LUnitControl.__\u003C\u003Eidle;
    }

    [Modifiers]
    public static LUnitControl stop
    {
      [HideFromJava] get => LUnitControl.__\u003C\u003Estop;
    }

    [Modifiers]
    public static LUnitControl move
    {
      [HideFromJava] get => LUnitControl.__\u003C\u003Emove;
    }

    [Modifiers]
    public static LUnitControl approach
    {
      [HideFromJava] get => LUnitControl.__\u003C\u003Eapproach;
    }

    [Modifiers]
    public static LUnitControl boost
    {
      [HideFromJava] get => LUnitControl.__\u003C\u003Eboost;
    }

    [Modifiers]
    public static LUnitControl pathfind
    {
      [HideFromJava] get => LUnitControl.__\u003C\u003Epathfind;
    }

    [Modifiers]
    public static LUnitControl target
    {
      [HideFromJava] get => LUnitControl.__\u003C\u003Etarget;
    }

    [Modifiers]
    public static LUnitControl targetp
    {
      [HideFromJava] get => LUnitControl.__\u003C\u003Etargetp;
    }

    [Modifiers]
    public static LUnitControl itemDrop
    {
      [HideFromJava] get => LUnitControl.__\u003C\u003EitemDrop;
    }

    [Modifiers]
    public static LUnitControl itemTake
    {
      [HideFromJava] get => LUnitControl.__\u003C\u003EitemTake;
    }

    [Modifiers]
    public static LUnitControl payDrop
    {
      [HideFromJava] get => LUnitControl.__\u003C\u003EpayDrop;
    }

    [Modifiers]
    public static LUnitControl payTake
    {
      [HideFromJava] get => LUnitControl.__\u003C\u003EpayTake;
    }

    [Modifiers]
    public static LUnitControl mine
    {
      [HideFromJava] get => LUnitControl.__\u003C\u003Emine;
    }

    [Modifiers]
    public static LUnitControl flag
    {
      [HideFromJava] get => LUnitControl.__\u003C\u003Eflag;
    }

    [Modifiers]
    public static LUnitControl build
    {
      [HideFromJava] get => LUnitControl.__\u003C\u003Ebuild;
    }

    [Modifiers]
    public static LUnitControl getBlock
    {
      [HideFromJava] get => LUnitControl.__\u003C\u003EgetBlock;
    }

    [Modifiers]
    public static LUnitControl within
    {
      [HideFromJava] get => LUnitControl.__\u003C\u003Ewithin;
    }

    [Modifiers]
    public string[] @params
    {
      [HideFromJava] get => this.__\u003C\u003Eparams;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Eparams = value;
    }

    [Modifiers]
    public static LUnitControl[] all
    {
      [HideFromJava] get => LUnitControl.__\u003C\u003Eall;
    }

    [HideFromJava]
    [Serializable]
    public enum __Enum
    {
      idle,
      stop,
      move,
      approach,
      boost,
      pathfind,
      target,
      targetp,
      itemDrop,
      itemTake,
      payDrop,
      payTake,
      mine,
      flag,
      build,
      getBlock,
      within,
    }
  }
}
