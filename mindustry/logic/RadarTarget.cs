// Decompiled with JetBrains decompiler
// Type: mindustry.logic.RadarTarget
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using mindustry.game;
using mindustry.gen;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.logic
{
  [Signature("Ljava/lang/Enum<Lmindustry/logic/RadarTarget;>;")]
  [Modifiers]
  [Serializable]
  public sealed class RadarTarget : Enum
  {
    [Modifiers]
    internal static RadarTarget __\u003C\u003Eany;
    [Modifiers]
    internal static RadarTarget __\u003C\u003Eenemy;
    [Modifiers]
    internal static RadarTarget __\u003C\u003Eally;
    [Modifiers]
    internal static RadarTarget __\u003C\u003Eplayer;
    [Modifiers]
    internal static RadarTarget __\u003C\u003Eattacker;
    [Modifiers]
    internal static RadarTarget __\u003C\u003Eflying;
    [Modifiers]
    internal static RadarTarget __\u003C\u003Eboss;
    [Modifiers]
    internal static RadarTarget __\u003C\u003Eground;
    internal RadarTarget.RadarTargetFunc __\u003C\u003Efunc;
    internal static RadarTarget[] __\u003C\u003Eall;
    [Modifiers]
    private static RadarTarget[] \u0024VALUES;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(6)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static RadarTarget valueOf(string name) => (RadarTarget) Enum.valueOf((Class) ClassLiteral<RadarTarget>.Value, name);

    [Signature("(Lmindustry/logic/RadarTarget$RadarTargetFunc;)V")]
    [LineNumberTable(new byte[] {159, 162, 106, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private RadarTarget([In] string obj0, [In] int obj1, [In] RadarTarget.RadarTargetFunc obj2)
      : base(obj0, obj1)
    {
      RadarTarget radarTarget = this;
      this.__\u003C\u003Efunc = obj2;
      GC.KeepAlive((object) this);
    }

    [LineNumberTable(6)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static RadarTarget[] values() => (RadarTarget[]) RadarTarget.\u0024VALUES.Clone();

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024static\u00240([In] Team obj0, [In] Unit obj1) => true;

    [Modifiers]
    [LineNumberTable(8)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024static\u00241([In] Team obj0, [In] Unit obj1) => !object.ReferenceEquals((object) obj0, (object) obj1.team);

    [Modifiers]
    [LineNumberTable(9)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024static\u00242([In] Team obj0, [In] Unit obj1) => object.ReferenceEquals((object) obj0, (object) obj1.team);

    [Modifiers]
    [LineNumberTable(10)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024static\u00243([In] Team obj0, [In] Unit obj1) => obj1.isPlayer();

    [Modifiers]
    [LineNumberTable(11)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024static\u00244([In] Team obj0, [In] Unit obj1) => obj1.canShoot();

    [Modifiers]
    [LineNumberTable(12)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024static\u00245([In] Team obj0, [In] Unit obj1) => obj1.isFlying();

    [Modifiers]
    [LineNumberTable(13)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024static\u00246([In] Team obj0, [In] Unit obj1) => obj1.isBoss();

    [Modifiers]
    [LineNumberTable(14)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024static\u00247([In] Team obj0, [In] Unit obj1) => obj1.isGrounded();

    [LineNumberTable(new byte[] {159, 141, 173, 122, 122, 122, 122, 122, 122, 122, 250, 56, 255, 44, 76})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static RadarTarget()
    {
      if (ByteCodeHelper.isAlreadyInited("mindustry.logic.RadarTarget"))
        return;
      RadarTarget.__\u003C\u003Eany = new RadarTarget(nameof (any), 0, (RadarTarget.RadarTargetFunc) new RadarTarget.__\u003C\u003EAnon0());
      RadarTarget.__\u003C\u003Eenemy = new RadarTarget(nameof (enemy), 1, (RadarTarget.RadarTargetFunc) new RadarTarget.__\u003C\u003EAnon1());
      RadarTarget.__\u003C\u003Eally = new RadarTarget(nameof (ally), 2, (RadarTarget.RadarTargetFunc) new RadarTarget.__\u003C\u003EAnon2());
      RadarTarget.__\u003C\u003Eplayer = new RadarTarget(nameof (player), 3, (RadarTarget.RadarTargetFunc) new RadarTarget.__\u003C\u003EAnon3());
      RadarTarget.__\u003C\u003Eattacker = new RadarTarget(nameof (attacker), 4, (RadarTarget.RadarTargetFunc) new RadarTarget.__\u003C\u003EAnon4());
      RadarTarget.__\u003C\u003Eflying = new RadarTarget(nameof (flying), 5, (RadarTarget.RadarTargetFunc) new RadarTarget.__\u003C\u003EAnon5());
      RadarTarget.__\u003C\u003Eboss = new RadarTarget(nameof (boss), 6, (RadarTarget.RadarTargetFunc) new RadarTarget.__\u003C\u003EAnon6());
      RadarTarget.__\u003C\u003Eground = new RadarTarget(nameof (ground), 7, (RadarTarget.RadarTargetFunc) new RadarTarget.__\u003C\u003EAnon7());
      RadarTarget.\u0024VALUES = new RadarTarget[8]
      {
        RadarTarget.__\u003C\u003Eany,
        RadarTarget.__\u003C\u003Eenemy,
        RadarTarget.__\u003C\u003Eally,
        RadarTarget.__\u003C\u003Eplayer,
        RadarTarget.__\u003C\u003Eattacker,
        RadarTarget.__\u003C\u003Eflying,
        RadarTarget.__\u003C\u003Eboss,
        RadarTarget.__\u003C\u003Eground
      };
      RadarTarget.__\u003C\u003Eall = RadarTarget.values();
    }

    [Modifiers]
    public static RadarTarget any
    {
      [HideFromJava] get => RadarTarget.__\u003C\u003Eany;
    }

    [Modifiers]
    public static RadarTarget enemy
    {
      [HideFromJava] get => RadarTarget.__\u003C\u003Eenemy;
    }

    [Modifiers]
    public static RadarTarget ally
    {
      [HideFromJava] get => RadarTarget.__\u003C\u003Eally;
    }

    [Modifiers]
    public static RadarTarget player
    {
      [HideFromJava] get => RadarTarget.__\u003C\u003Eplayer;
    }

    [Modifiers]
    public static RadarTarget attacker
    {
      [HideFromJava] get => RadarTarget.__\u003C\u003Eattacker;
    }

    [Modifiers]
    public static RadarTarget flying
    {
      [HideFromJava] get => RadarTarget.__\u003C\u003Eflying;
    }

    [Modifiers]
    public static RadarTarget boss
    {
      [HideFromJava] get => RadarTarget.__\u003C\u003Eboss;
    }

    [Modifiers]
    public static RadarTarget ground
    {
      [HideFromJava] get => RadarTarget.__\u003C\u003Eground;
    }

    [Modifiers]
    public RadarTarget.RadarTargetFunc func
    {
      [HideFromJava] get => this.__\u003C\u003Efunc;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Efunc = value;
    }

    [Modifiers]
    public static RadarTarget[] all
    {
      [HideFromJava] get => RadarTarget.__\u003C\u003Eall;
    }

    [HideFromJava]
    [Serializable]
    public enum __Enum
    {
      any,
      enemy,
      ally,
      player,
      attacker,
      flying,
      boss,
      ground,
    }

    public interface RadarTargetFunc
    {
      bool get(Team t, Unit u);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : RadarTarget.RadarTargetFunc
    {
      internal __\u003C\u003EAnon0()
      {
      }

      public bool get([In] Team obj0, [In] Unit obj1) => (RadarTarget.lambda\u0024static\u00240(obj0, obj1) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : RadarTarget.RadarTargetFunc
    {
      internal __\u003C\u003EAnon1()
      {
      }

      public bool get([In] Team obj0, [In] Unit obj1) => (RadarTarget.lambda\u0024static\u00241(obj0, obj1) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon2 : RadarTarget.RadarTargetFunc
    {
      internal __\u003C\u003EAnon2()
      {
      }

      public bool get([In] Team obj0, [In] Unit obj1) => (RadarTarget.lambda\u0024static\u00242(obj0, obj1) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon3 : RadarTarget.RadarTargetFunc
    {
      internal __\u003C\u003EAnon3()
      {
      }

      public bool get([In] Team obj0, [In] Unit obj1) => (RadarTarget.lambda\u0024static\u00243(obj0, obj1) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon4 : RadarTarget.RadarTargetFunc
    {
      internal __\u003C\u003EAnon4()
      {
      }

      public bool get([In] Team obj0, [In] Unit obj1) => (RadarTarget.lambda\u0024static\u00244(obj0, obj1) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon5 : RadarTarget.RadarTargetFunc
    {
      internal __\u003C\u003EAnon5()
      {
      }

      public bool get([In] Team obj0, [In] Unit obj1) => (RadarTarget.lambda\u0024static\u00245(obj0, obj1) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon6 : RadarTarget.RadarTargetFunc
    {
      internal __\u003C\u003EAnon6()
      {
      }

      public bool get([In] Team obj0, [In] Unit obj1) => (RadarTarget.lambda\u0024static\u00246(obj0, obj1) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon7 : RadarTarget.RadarTargetFunc
    {
      internal __\u003C\u003EAnon7()
      {
      }

      public bool get([In] Team obj0, [In] Unit obj1) => (RadarTarget.lambda\u0024static\u00247(obj0, obj1) ? 1 : 0) != 0;
    }
  }
}
