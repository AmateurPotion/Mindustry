// Decompiled with JetBrains decompiler
// Type: mindustry.gen.Sounds
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.audio;
using arc.func;
using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.gen
{
  public class Sounds : Object
  {
    public static Sound noammo;
    public static Sound cutter;
    public static Sound plasmadrop;
    public static Sound tractorbeam;
    public static Sound respawn;
    public static Sound splash;
    public static Sound buttonClick;
    public static Sound laserbig;
    public static Sound missile;
    public static Sound shootSnap;
    public static Sound lasershoot;
    public static Sound bang;
    public static Sound pulse;
    public static Sound bigshot;
    public static Sound respawning;
    public static Sound plasmaboom;
    public static Sound build;
    public static Sound flame;
    public static Sound combustion;
    public static Sound release;
    public static Sound windowHide;
    public static Sound breaks;
    public static Sound thruster;
    public static Sound shield;
    public static Sound fire;
    public static Sound beam;
    public static Sound minebeam;
    public static Sound machine;
    public static Sound flame2;
    public static Sound lasercharge2;
    public static Sound door;
    public static Sound sap;
    public static Sound wave;
    public static Sound windhowl;
    public static Sound swish;
    public static Sound laserblast;
    public static Sound corexplode;
    public static Sound message;
    public static Sound unlock;
    public static Sound back;
    public static Sound press;
    public static Sound techloop;
    public static Sound pew;
    public static Sound click;
    public static Sound railgun;
    public static Sound shootBig;
    public static Sound spray;
    public static Sound place;
    public static Sound steam;
    public static Sound shoot;
    public static Sound laser;
    public static Sound lasercharge;
    public static Sound grinding;
    public static Sound smelter;
    public static Sound explosion;
    public static Sound explosionbig;
    public static Sound drill;
    public static Sound hum;
    public static Sound artillery;
    public static Sound shotgun;
    public static Sound spark;
    public static Sound wind;
    public static Sound mud;
    public static Sound rain;
    public static Sound wind2;
    public static Sound conveyor;
    public static Sound boom;
    public static Sound none;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {93, 127, 4, 127, 4, 127, 4, 127, 4, 127, 4, 127, 4, 127, 4, 127, 4, 127, 4, 127, 4, 127, 4, 127, 4, 127, 4, 127, 4, 127, 4, 127, 4, 127, 4, 127, 4, 127, 4, 127, 4, 127, 4, 127, 4, 127, 4, 127, 4, 127, 4, 127, 4, 127, 4, 127, 4, 127, 4, 127, 4, 127, 4, 127, 4, 127, 4, 127, 4, 127, 4, 127, 4, 127, 4, 127, 4, 127, 4, 127, 4, 127, 4, 127, 4, 127, 4, 127, 4, 127, 4, 127, 4, 127, 4, 127, 4, 127, 4, 127, 4, 127, 4, 127, 4, 127, 4, 127, 4, 127, 4, 127, 4, 127, 4, 127, 4, 127, 4, 127, 4, 127, 4, 127, 4, 127, 4, 127, 4, 127, 4, 127, 4, 127, 4})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void load()
    {
      Core.assets.load("sounds/noammo.ogg", (Class) ClassLiteral<Sound>.Value).loaded = (Cons) new Sounds.__\u003C\u003EAnon0();
      Core.assets.load("sounds/cutter.ogg", (Class) ClassLiteral<Sound>.Value).loaded = (Cons) new Sounds.__\u003C\u003EAnon1();
      Core.assets.load("sounds/plasmadrop.ogg", (Class) ClassLiteral<Sound>.Value).loaded = (Cons) new Sounds.__\u003C\u003EAnon2();
      Core.assets.load("sounds/tractorbeam.ogg", (Class) ClassLiteral<Sound>.Value).loaded = (Cons) new Sounds.__\u003C\u003EAnon3();
      Core.assets.load("sounds/respawn.ogg", (Class) ClassLiteral<Sound>.Value).loaded = (Cons) new Sounds.__\u003C\u003EAnon4();
      Core.assets.load("sounds/splash.ogg", (Class) ClassLiteral<Sound>.Value).loaded = (Cons) new Sounds.__\u003C\u003EAnon5();
      Core.assets.load("sounds/buttonClick.ogg", (Class) ClassLiteral<Sound>.Value).loaded = (Cons) new Sounds.__\u003C\u003EAnon6();
      Core.assets.load("sounds/laserbig.ogg", (Class) ClassLiteral<Sound>.Value).loaded = (Cons) new Sounds.__\u003C\u003EAnon7();
      Core.assets.load("sounds/missile.ogg", (Class) ClassLiteral<Sound>.Value).loaded = (Cons) new Sounds.__\u003C\u003EAnon8();
      Core.assets.load("sounds/shootSnap.ogg", (Class) ClassLiteral<Sound>.Value).loaded = (Cons) new Sounds.__\u003C\u003EAnon9();
      Core.assets.load("sounds/lasershoot.ogg", (Class) ClassLiteral<Sound>.Value).loaded = (Cons) new Sounds.__\u003C\u003EAnon10();
      Core.assets.load("sounds/bang.ogg", (Class) ClassLiteral<Sound>.Value).loaded = (Cons) new Sounds.__\u003C\u003EAnon11();
      Core.assets.load("sounds/pulse.ogg", (Class) ClassLiteral<Sound>.Value).loaded = (Cons) new Sounds.__\u003C\u003EAnon12();
      Core.assets.load("sounds/bigshot.ogg", (Class) ClassLiteral<Sound>.Value).loaded = (Cons) new Sounds.__\u003C\u003EAnon13();
      Core.assets.load("sounds/respawning.ogg", (Class) ClassLiteral<Sound>.Value).loaded = (Cons) new Sounds.__\u003C\u003EAnon14();
      Core.assets.load("sounds/plasmaboom.ogg", (Class) ClassLiteral<Sound>.Value).loaded = (Cons) new Sounds.__\u003C\u003EAnon15();
      Core.assets.load("sounds/build.ogg", (Class) ClassLiteral<Sound>.Value).loaded = (Cons) new Sounds.__\u003C\u003EAnon16();
      Core.assets.load("sounds/flame.ogg", (Class) ClassLiteral<Sound>.Value).loaded = (Cons) new Sounds.__\u003C\u003EAnon17();
      Core.assets.load("sounds/combustion.ogg", (Class) ClassLiteral<Sound>.Value).loaded = (Cons) new Sounds.__\u003C\u003EAnon18();
      Core.assets.load("sounds/release.ogg", (Class) ClassLiteral<Sound>.Value).loaded = (Cons) new Sounds.__\u003C\u003EAnon19();
      Core.assets.load("sounds/windowHide.ogg", (Class) ClassLiteral<Sound>.Value).loaded = (Cons) new Sounds.__\u003C\u003EAnon20();
      Core.assets.load("sounds/break.ogg", (Class) ClassLiteral<Sound>.Value).loaded = (Cons) new Sounds.__\u003C\u003EAnon21();
      Core.assets.load("sounds/thruster.ogg", (Class) ClassLiteral<Sound>.Value).loaded = (Cons) new Sounds.__\u003C\u003EAnon22();
      Core.assets.load("sounds/shield.ogg", (Class) ClassLiteral<Sound>.Value).loaded = (Cons) new Sounds.__\u003C\u003EAnon23();
      Core.assets.load("sounds/fire.ogg", (Class) ClassLiteral<Sound>.Value).loaded = (Cons) new Sounds.__\u003C\u003EAnon24();
      Core.assets.load("sounds/beam.ogg", (Class) ClassLiteral<Sound>.Value).loaded = (Cons) new Sounds.__\u003C\u003EAnon25();
      Core.assets.load("sounds/minebeam.ogg", (Class) ClassLiteral<Sound>.Value).loaded = (Cons) new Sounds.__\u003C\u003EAnon26();
      Core.assets.load("sounds/machine.ogg", (Class) ClassLiteral<Sound>.Value).loaded = (Cons) new Sounds.__\u003C\u003EAnon27();
      Core.assets.load("sounds/flame2.ogg", (Class) ClassLiteral<Sound>.Value).loaded = (Cons) new Sounds.__\u003C\u003EAnon28();
      Core.assets.load("sounds/lasercharge2.ogg", (Class) ClassLiteral<Sound>.Value).loaded = (Cons) new Sounds.__\u003C\u003EAnon29();
      Core.assets.load("sounds/door.ogg", (Class) ClassLiteral<Sound>.Value).loaded = (Cons) new Sounds.__\u003C\u003EAnon30();
      Core.assets.load("sounds/sap.ogg", (Class) ClassLiteral<Sound>.Value).loaded = (Cons) new Sounds.__\u003C\u003EAnon31();
      Core.assets.load("sounds/wave.ogg", (Class) ClassLiteral<Sound>.Value).loaded = (Cons) new Sounds.__\u003C\u003EAnon32();
      Core.assets.load("sounds/windhowl.ogg", (Class) ClassLiteral<Sound>.Value).loaded = (Cons) new Sounds.__\u003C\u003EAnon33();
      Core.assets.load("sounds/swish.ogg", (Class) ClassLiteral<Sound>.Value).loaded = (Cons) new Sounds.__\u003C\u003EAnon34();
      Core.assets.load("sounds/laserblast.ogg", (Class) ClassLiteral<Sound>.Value).loaded = (Cons) new Sounds.__\u003C\u003EAnon35();
      Core.assets.load("sounds/corexplode.ogg", (Class) ClassLiteral<Sound>.Value).loaded = (Cons) new Sounds.__\u003C\u003EAnon36();
      Core.assets.load("sounds/ui/message.ogg", (Class) ClassLiteral<Sound>.Value).loaded = (Cons) new Sounds.__\u003C\u003EAnon37();
      Core.assets.load("sounds/ui/unlock.ogg", (Class) ClassLiteral<Sound>.Value).loaded = (Cons) new Sounds.__\u003C\u003EAnon38();
      Core.assets.load("sounds/ui/back.ogg", (Class) ClassLiteral<Sound>.Value).loaded = (Cons) new Sounds.__\u003C\u003EAnon39();
      Core.assets.load("sounds/ui/press.ogg", (Class) ClassLiteral<Sound>.Value).loaded = (Cons) new Sounds.__\u003C\u003EAnon40();
      Core.assets.load("sounds/techloop.ogg", (Class) ClassLiteral<Sound>.Value).loaded = (Cons) new Sounds.__\u003C\u003EAnon41();
      Core.assets.load("sounds/pew.ogg", (Class) ClassLiteral<Sound>.Value).loaded = (Cons) new Sounds.__\u003C\u003EAnon42();
      Core.assets.load("sounds/click.ogg", (Class) ClassLiteral<Sound>.Value).loaded = (Cons) new Sounds.__\u003C\u003EAnon43();
      Core.assets.load("sounds/railgun.ogg", (Class) ClassLiteral<Sound>.Value).loaded = (Cons) new Sounds.__\u003C\u003EAnon44();
      Core.assets.load("sounds/shootBig.ogg", (Class) ClassLiteral<Sound>.Value).loaded = (Cons) new Sounds.__\u003C\u003EAnon45();
      Core.assets.load("sounds/spray.ogg", (Class) ClassLiteral<Sound>.Value).loaded = (Cons) new Sounds.__\u003C\u003EAnon46();
      Core.assets.load("sounds/place.ogg", (Class) ClassLiteral<Sound>.Value).loaded = (Cons) new Sounds.__\u003C\u003EAnon47();
      Core.assets.load("sounds/steam.ogg", (Class) ClassLiteral<Sound>.Value).loaded = (Cons) new Sounds.__\u003C\u003EAnon48();
      Core.assets.load("sounds/shoot.ogg", (Class) ClassLiteral<Sound>.Value).loaded = (Cons) new Sounds.__\u003C\u003EAnon49();
      Core.assets.load("sounds/laser.ogg", (Class) ClassLiteral<Sound>.Value).loaded = (Cons) new Sounds.__\u003C\u003EAnon50();
      Core.assets.load("sounds/lasercharge.ogg", (Class) ClassLiteral<Sound>.Value).loaded = (Cons) new Sounds.__\u003C\u003EAnon51();
      Core.assets.load("sounds/grinding.ogg", (Class) ClassLiteral<Sound>.Value).loaded = (Cons) new Sounds.__\u003C\u003EAnon52();
      Core.assets.load("sounds/smelter.ogg", (Class) ClassLiteral<Sound>.Value).loaded = (Cons) new Sounds.__\u003C\u003EAnon53();
      Core.assets.load("sounds/explosion.ogg", (Class) ClassLiteral<Sound>.Value).loaded = (Cons) new Sounds.__\u003C\u003EAnon54();
      Core.assets.load("sounds/explosionbig.ogg", (Class) ClassLiteral<Sound>.Value).loaded = (Cons) new Sounds.__\u003C\u003EAnon55();
      Core.assets.load("sounds/drill.ogg", (Class) ClassLiteral<Sound>.Value).loaded = (Cons) new Sounds.__\u003C\u003EAnon56();
      Core.assets.load("sounds/hum.ogg", (Class) ClassLiteral<Sound>.Value).loaded = (Cons) new Sounds.__\u003C\u003EAnon57();
      Core.assets.load("sounds/artillery.ogg", (Class) ClassLiteral<Sound>.Value).loaded = (Cons) new Sounds.__\u003C\u003EAnon58();
      Core.assets.load("sounds/shotgun.ogg", (Class) ClassLiteral<Sound>.Value).loaded = (Cons) new Sounds.__\u003C\u003EAnon59();
      Core.assets.load("sounds/spark.ogg", (Class) ClassLiteral<Sound>.Value).loaded = (Cons) new Sounds.__\u003C\u003EAnon60();
      Core.assets.load("sounds/wind.ogg", (Class) ClassLiteral<Sound>.Value).loaded = (Cons) new Sounds.__\u003C\u003EAnon61();
      Core.assets.load("sounds/mud.ogg", (Class) ClassLiteral<Sound>.Value).loaded = (Cons) new Sounds.__\u003C\u003EAnon62();
      Core.assets.load("sounds/rain.ogg", (Class) ClassLiteral<Sound>.Value).loaded = (Cons) new Sounds.__\u003C\u003EAnon63();
      Core.assets.load("sounds/wind2.ogg", (Class) ClassLiteral<Sound>.Value).loaded = (Cons) new Sounds.__\u003C\u003EAnon64();
      Core.assets.load("sounds/conveyor.ogg", (Class) ClassLiteral<Sound>.Value).loaded = (Cons) new Sounds.__\u003C\u003EAnon65();
      Core.assets.load("sounds/boom.ogg", (Class) ClassLiteral<Sound>.Value).loaded = (Cons) new Sounds.__\u003C\u003EAnon66();
    }

    [Modifiers]
    [LineNumberTable(143)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u00240([In] object obj0) => Sounds.noammo = (Sound) obj0;

    [Modifiers]
    [LineNumberTable(144)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u00241([In] object obj0) => Sounds.cutter = (Sound) obj0;

    [Modifiers]
    [LineNumberTable(145)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u00242([In] object obj0) => Sounds.plasmadrop = (Sound) obj0;

    [Modifiers]
    [LineNumberTable(146)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u00243([In] object obj0) => Sounds.tractorbeam = (Sound) obj0;

    [Modifiers]
    [LineNumberTable(147)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u00244([In] object obj0) => Sounds.respawn = (Sound) obj0;

    [Modifiers]
    [LineNumberTable(148)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u00245([In] object obj0) => Sounds.splash = (Sound) obj0;

    [Modifiers]
    [LineNumberTable(149)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u00246([In] object obj0) => Sounds.buttonClick = (Sound) obj0;

    [Modifiers]
    [LineNumberTable(150)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u00247([In] object obj0) => Sounds.laserbig = (Sound) obj0;

    [Modifiers]
    [LineNumberTable(151)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u00248([In] object obj0) => Sounds.missile = (Sound) obj0;

    [Modifiers]
    [LineNumberTable(152)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u00249([In] object obj0) => Sounds.shootSnap = (Sound) obj0;

    [Modifiers]
    [LineNumberTable(153)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002410([In] object obj0) => Sounds.lasershoot = (Sound) obj0;

    [Modifiers]
    [LineNumberTable(154)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002411([In] object obj0) => Sounds.bang = (Sound) obj0;

    [Modifiers]
    [LineNumberTable(155)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002412([In] object obj0) => Sounds.pulse = (Sound) obj0;

    [Modifiers]
    [LineNumberTable(156)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002413([In] object obj0) => Sounds.bigshot = (Sound) obj0;

    [Modifiers]
    [LineNumberTable(157)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002414([In] object obj0) => Sounds.respawning = (Sound) obj0;

    [Modifiers]
    [LineNumberTable(158)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002415([In] object obj0) => Sounds.plasmaboom = (Sound) obj0;

    [Modifiers]
    [LineNumberTable(159)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002416([In] object obj0) => Sounds.build = (Sound) obj0;

    [Modifiers]
    [LineNumberTable(160)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002417([In] object obj0) => Sounds.flame = (Sound) obj0;

    [Modifiers]
    [LineNumberTable(161)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002418([In] object obj0) => Sounds.combustion = (Sound) obj0;

    [Modifiers]
    [LineNumberTable(162)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002419([In] object obj0) => Sounds.release = (Sound) obj0;

    [Modifiers]
    [LineNumberTable(163)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002420([In] object obj0) => Sounds.windowHide = (Sound) obj0;

    [Modifiers]
    [LineNumberTable(164)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002421([In] object obj0) => Sounds.breaks = (Sound) obj0;

    [Modifiers]
    [LineNumberTable(165)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002422([In] object obj0) => Sounds.thruster = (Sound) obj0;

    [Modifiers]
    [LineNumberTable(166)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002423([In] object obj0) => Sounds.shield = (Sound) obj0;

    [Modifiers]
    [LineNumberTable(167)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002424([In] object obj0) => Sounds.fire = (Sound) obj0;

    [Modifiers]
    [LineNumberTable(168)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002425([In] object obj0) => Sounds.beam = (Sound) obj0;

    [Modifiers]
    [LineNumberTable(169)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002426([In] object obj0) => Sounds.minebeam = (Sound) obj0;

    [Modifiers]
    [LineNumberTable(170)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002427([In] object obj0) => Sounds.machine = (Sound) obj0;

    [Modifiers]
    [LineNumberTable(171)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002428([In] object obj0) => Sounds.flame2 = (Sound) obj0;

    [Modifiers]
    [LineNumberTable(172)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002429([In] object obj0) => Sounds.lasercharge2 = (Sound) obj0;

    [Modifiers]
    [LineNumberTable(173)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002430([In] object obj0) => Sounds.door = (Sound) obj0;

    [Modifiers]
    [LineNumberTable(174)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002431([In] object obj0) => Sounds.sap = (Sound) obj0;

    [Modifiers]
    [LineNumberTable(175)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002432([In] object obj0) => Sounds.wave = (Sound) obj0;

    [Modifiers]
    [LineNumberTable(176)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002433([In] object obj0) => Sounds.windhowl = (Sound) obj0;

    [Modifiers]
    [LineNumberTable(177)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002434([In] object obj0) => Sounds.swish = (Sound) obj0;

    [Modifiers]
    [LineNumberTable(178)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002435([In] object obj0) => Sounds.laserblast = (Sound) obj0;

    [Modifiers]
    [LineNumberTable(179)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002436([In] object obj0) => Sounds.corexplode = (Sound) obj0;

    [Modifiers]
    [LineNumberTable(180)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002437([In] object obj0) => Sounds.message = (Sound) obj0;

    [Modifiers]
    [LineNumberTable(181)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002438([In] object obj0) => Sounds.unlock = (Sound) obj0;

    [Modifiers]
    [LineNumberTable(182)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002439([In] object obj0) => Sounds.back = (Sound) obj0;

    [Modifiers]
    [LineNumberTable(183)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002440([In] object obj0) => Sounds.press = (Sound) obj0;

    [Modifiers]
    [LineNumberTable(184)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002441([In] object obj0) => Sounds.techloop = (Sound) obj0;

    [Modifiers]
    [LineNumberTable(185)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002442([In] object obj0) => Sounds.pew = (Sound) obj0;

    [Modifiers]
    [LineNumberTable(186)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002443([In] object obj0) => Sounds.click = (Sound) obj0;

    [Modifiers]
    [LineNumberTable(187)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002444([In] object obj0) => Sounds.railgun = (Sound) obj0;

    [Modifiers]
    [LineNumberTable(188)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002445([In] object obj0) => Sounds.shootBig = (Sound) obj0;

    [Modifiers]
    [LineNumberTable(189)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002446([In] object obj0) => Sounds.spray = (Sound) obj0;

    [Modifiers]
    [LineNumberTable(190)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002447([In] object obj0) => Sounds.place = (Sound) obj0;

    [Modifiers]
    [LineNumberTable(191)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002448([In] object obj0) => Sounds.steam = (Sound) obj0;

    [Modifiers]
    [LineNumberTable(192)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002449([In] object obj0) => Sounds.shoot = (Sound) obj0;

    [Modifiers]
    [LineNumberTable(193)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002450([In] object obj0) => Sounds.laser = (Sound) obj0;

    [Modifiers]
    [LineNumberTable(194)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002451([In] object obj0) => Sounds.lasercharge = (Sound) obj0;

    [Modifiers]
    [LineNumberTable(195)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002452([In] object obj0) => Sounds.grinding = (Sound) obj0;

    [Modifiers]
    [LineNumberTable(196)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002453([In] object obj0) => Sounds.smelter = (Sound) obj0;

    [Modifiers]
    [LineNumberTable(197)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002454([In] object obj0) => Sounds.explosion = (Sound) obj0;

    [Modifiers]
    [LineNumberTable(198)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002455([In] object obj0) => Sounds.explosionbig = (Sound) obj0;

    [Modifiers]
    [LineNumberTable(199)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002456([In] object obj0) => Sounds.drill = (Sound) obj0;

    [Modifiers]
    [LineNumberTable(200)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002457([In] object obj0) => Sounds.hum = (Sound) obj0;

    [Modifiers]
    [LineNumberTable(201)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002458([In] object obj0) => Sounds.artillery = (Sound) obj0;

    [Modifiers]
    [LineNumberTable(202)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002459([In] object obj0) => Sounds.shotgun = (Sound) obj0;

    [Modifiers]
    [LineNumberTable(203)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002460([In] object obj0) => Sounds.spark = (Sound) obj0;

    [Modifiers]
    [LineNumberTable(204)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002461([In] object obj0) => Sounds.wind = (Sound) obj0;

    [Modifiers]
    [LineNumberTable(205)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002462([In] object obj0) => Sounds.mud = (Sound) obj0;

    [Modifiers]
    [LineNumberTable(206)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002463([In] object obj0) => Sounds.rain = (Sound) obj0;

    [Modifiers]
    [LineNumberTable(207)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002464([In] object obj0) => Sounds.wind2 = (Sound) obj0;

    [Modifiers]
    [LineNumberTable(208)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002465([In] object obj0) => Sounds.conveyor = (Sound) obj0;

    [Modifiers]
    [LineNumberTable(209)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002466([In] object obj0) => Sounds.boom = (Sound) obj0;

    [LineNumberTable(5)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Sounds()
    {
    }

    [LineNumberTable(new byte[] {159, 141, 141, 138, 138, 138, 138, 138, 138, 138, 138, 138, 138, 138, 138, 138, 138, 138, 138, 138, 138, 138, 138, 138, 138, 138, 138, 138, 138, 138, 138, 138, 138, 138, 138, 138, 138, 138, 138, 138, 138, 138, 138, 138, 138, 138, 138, 138, 138, 138, 138, 138, 138, 138, 138, 138, 138, 138, 138, 138, 138, 138, 138, 138, 138, 138, 138, 138, 138, 138})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static Sounds()
    {
      if (ByteCodeHelper.isAlreadyInited("mindustry.gen.Sounds"))
        return;
      Sounds.noammo = new Sound();
      Sounds.cutter = new Sound();
      Sounds.plasmadrop = new Sound();
      Sounds.tractorbeam = new Sound();
      Sounds.respawn = new Sound();
      Sounds.splash = new Sound();
      Sounds.buttonClick = new Sound();
      Sounds.laserbig = new Sound();
      Sounds.missile = new Sound();
      Sounds.shootSnap = new Sound();
      Sounds.lasershoot = new Sound();
      Sounds.bang = new Sound();
      Sounds.pulse = new Sound();
      Sounds.bigshot = new Sound();
      Sounds.respawning = new Sound();
      Sounds.plasmaboom = new Sound();
      Sounds.build = new Sound();
      Sounds.flame = new Sound();
      Sounds.combustion = new Sound();
      Sounds.release = new Sound();
      Sounds.windowHide = new Sound();
      Sounds.breaks = new Sound();
      Sounds.thruster = new Sound();
      Sounds.shield = new Sound();
      Sounds.fire = new Sound();
      Sounds.beam = new Sound();
      Sounds.minebeam = new Sound();
      Sounds.machine = new Sound();
      Sounds.flame2 = new Sound();
      Sounds.lasercharge2 = new Sound();
      Sounds.door = new Sound();
      Sounds.sap = new Sound();
      Sounds.wave = new Sound();
      Sounds.windhowl = new Sound();
      Sounds.swish = new Sound();
      Sounds.laserblast = new Sound();
      Sounds.corexplode = new Sound();
      Sounds.message = new Sound();
      Sounds.unlock = new Sound();
      Sounds.back = new Sound();
      Sounds.press = new Sound();
      Sounds.techloop = new Sound();
      Sounds.pew = new Sound();
      Sounds.click = new Sound();
      Sounds.railgun = new Sound();
      Sounds.shootBig = new Sound();
      Sounds.spray = new Sound();
      Sounds.place = new Sound();
      Sounds.steam = new Sound();
      Sounds.shoot = new Sound();
      Sounds.laser = new Sound();
      Sounds.lasercharge = new Sound();
      Sounds.grinding = new Sound();
      Sounds.smelter = new Sound();
      Sounds.explosion = new Sound();
      Sounds.explosionbig = new Sound();
      Sounds.drill = new Sound();
      Sounds.hum = new Sound();
      Sounds.artillery = new Sound();
      Sounds.shotgun = new Sound();
      Sounds.spark = new Sound();
      Sounds.wind = new Sound();
      Sounds.mud = new Sound();
      Sounds.rain = new Sound();
      Sounds.wind2 = new Sound();
      Sounds.conveyor = new Sound();
      Sounds.boom = new Sound();
      Sounds.none = new Sound();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Cons
    {
      internal __\u003C\u003EAnon0()
      {
      }

      public void get([In] object obj0) => Sounds.lambda\u0024load\u00240(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Cons
    {
      internal __\u003C\u003EAnon1()
      {
      }

      public void get([In] object obj0) => Sounds.lambda\u0024load\u00241(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon2 : Cons
    {
      internal __\u003C\u003EAnon2()
      {
      }

      public void get([In] object obj0) => Sounds.lambda\u0024load\u00242(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon3 : Cons
    {
      internal __\u003C\u003EAnon3()
      {
      }

      public void get([In] object obj0) => Sounds.lambda\u0024load\u00243(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon4 : Cons
    {
      internal __\u003C\u003EAnon4()
      {
      }

      public void get([In] object obj0) => Sounds.lambda\u0024load\u00244(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon5 : Cons
    {
      internal __\u003C\u003EAnon5()
      {
      }

      public void get([In] object obj0) => Sounds.lambda\u0024load\u00245(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon6 : Cons
    {
      internal __\u003C\u003EAnon6()
      {
      }

      public void get([In] object obj0) => Sounds.lambda\u0024load\u00246(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon7 : Cons
    {
      internal __\u003C\u003EAnon7()
      {
      }

      public void get([In] object obj0) => Sounds.lambda\u0024load\u00247(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon8 : Cons
    {
      internal __\u003C\u003EAnon8()
      {
      }

      public void get([In] object obj0) => Sounds.lambda\u0024load\u00248(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon9 : Cons
    {
      internal __\u003C\u003EAnon9()
      {
      }

      public void get([In] object obj0) => Sounds.lambda\u0024load\u00249(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon10 : Cons
    {
      internal __\u003C\u003EAnon10()
      {
      }

      public void get([In] object obj0) => Sounds.lambda\u0024load\u002410(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon11 : Cons
    {
      internal __\u003C\u003EAnon11()
      {
      }

      public void get([In] object obj0) => Sounds.lambda\u0024load\u002411(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon12 : Cons
    {
      internal __\u003C\u003EAnon12()
      {
      }

      public void get([In] object obj0) => Sounds.lambda\u0024load\u002412(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon13 : Cons
    {
      internal __\u003C\u003EAnon13()
      {
      }

      public void get([In] object obj0) => Sounds.lambda\u0024load\u002413(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon14 : Cons
    {
      internal __\u003C\u003EAnon14()
      {
      }

      public void get([In] object obj0) => Sounds.lambda\u0024load\u002414(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon15 : Cons
    {
      internal __\u003C\u003EAnon15()
      {
      }

      public void get([In] object obj0) => Sounds.lambda\u0024load\u002415(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon16 : Cons
    {
      internal __\u003C\u003EAnon16()
      {
      }

      public void get([In] object obj0) => Sounds.lambda\u0024load\u002416(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon17 : Cons
    {
      internal __\u003C\u003EAnon17()
      {
      }

      public void get([In] object obj0) => Sounds.lambda\u0024load\u002417(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon18 : Cons
    {
      internal __\u003C\u003EAnon18()
      {
      }

      public void get([In] object obj0) => Sounds.lambda\u0024load\u002418(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon19 : Cons
    {
      internal __\u003C\u003EAnon19()
      {
      }

      public void get([In] object obj0) => Sounds.lambda\u0024load\u002419(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon20 : Cons
    {
      internal __\u003C\u003EAnon20()
      {
      }

      public void get([In] object obj0) => Sounds.lambda\u0024load\u002420(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon21 : Cons
    {
      internal __\u003C\u003EAnon21()
      {
      }

      public void get([In] object obj0) => Sounds.lambda\u0024load\u002421(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon22 : Cons
    {
      internal __\u003C\u003EAnon22()
      {
      }

      public void get([In] object obj0) => Sounds.lambda\u0024load\u002422(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon23 : Cons
    {
      internal __\u003C\u003EAnon23()
      {
      }

      public void get([In] object obj0) => Sounds.lambda\u0024load\u002423(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon24 : Cons
    {
      internal __\u003C\u003EAnon24()
      {
      }

      public void get([In] object obj0) => Sounds.lambda\u0024load\u002424(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon25 : Cons
    {
      internal __\u003C\u003EAnon25()
      {
      }

      public void get([In] object obj0) => Sounds.lambda\u0024load\u002425(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon26 : Cons
    {
      internal __\u003C\u003EAnon26()
      {
      }

      public void get([In] object obj0) => Sounds.lambda\u0024load\u002426(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon27 : Cons
    {
      internal __\u003C\u003EAnon27()
      {
      }

      public void get([In] object obj0) => Sounds.lambda\u0024load\u002427(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon28 : Cons
    {
      internal __\u003C\u003EAnon28()
      {
      }

      public void get([In] object obj0) => Sounds.lambda\u0024load\u002428(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon29 : Cons
    {
      internal __\u003C\u003EAnon29()
      {
      }

      public void get([In] object obj0) => Sounds.lambda\u0024load\u002429(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon30 : Cons
    {
      internal __\u003C\u003EAnon30()
      {
      }

      public void get([In] object obj0) => Sounds.lambda\u0024load\u002430(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon31 : Cons
    {
      internal __\u003C\u003EAnon31()
      {
      }

      public void get([In] object obj0) => Sounds.lambda\u0024load\u002431(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon32 : Cons
    {
      internal __\u003C\u003EAnon32()
      {
      }

      public void get([In] object obj0) => Sounds.lambda\u0024load\u002432(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon33 : Cons
    {
      internal __\u003C\u003EAnon33()
      {
      }

      public void get([In] object obj0) => Sounds.lambda\u0024load\u002433(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon34 : Cons
    {
      internal __\u003C\u003EAnon34()
      {
      }

      public void get([In] object obj0) => Sounds.lambda\u0024load\u002434(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon35 : Cons
    {
      internal __\u003C\u003EAnon35()
      {
      }

      public void get([In] object obj0) => Sounds.lambda\u0024load\u002435(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon36 : Cons
    {
      internal __\u003C\u003EAnon36()
      {
      }

      public void get([In] object obj0) => Sounds.lambda\u0024load\u002436(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon37 : Cons
    {
      internal __\u003C\u003EAnon37()
      {
      }

      public void get([In] object obj0) => Sounds.lambda\u0024load\u002437(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon38 : Cons
    {
      internal __\u003C\u003EAnon38()
      {
      }

      public void get([In] object obj0) => Sounds.lambda\u0024load\u002438(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon39 : Cons
    {
      internal __\u003C\u003EAnon39()
      {
      }

      public void get([In] object obj0) => Sounds.lambda\u0024load\u002439(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon40 : Cons
    {
      internal __\u003C\u003EAnon40()
      {
      }

      public void get([In] object obj0) => Sounds.lambda\u0024load\u002440(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon41 : Cons
    {
      internal __\u003C\u003EAnon41()
      {
      }

      public void get([In] object obj0) => Sounds.lambda\u0024load\u002441(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon42 : Cons
    {
      internal __\u003C\u003EAnon42()
      {
      }

      public void get([In] object obj0) => Sounds.lambda\u0024load\u002442(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon43 : Cons
    {
      internal __\u003C\u003EAnon43()
      {
      }

      public void get([In] object obj0) => Sounds.lambda\u0024load\u002443(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon44 : Cons
    {
      internal __\u003C\u003EAnon44()
      {
      }

      public void get([In] object obj0) => Sounds.lambda\u0024load\u002444(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon45 : Cons
    {
      internal __\u003C\u003EAnon45()
      {
      }

      public void get([In] object obj0) => Sounds.lambda\u0024load\u002445(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon46 : Cons
    {
      internal __\u003C\u003EAnon46()
      {
      }

      public void get([In] object obj0) => Sounds.lambda\u0024load\u002446(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon47 : Cons
    {
      internal __\u003C\u003EAnon47()
      {
      }

      public void get([In] object obj0) => Sounds.lambda\u0024load\u002447(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon48 : Cons
    {
      internal __\u003C\u003EAnon48()
      {
      }

      public void get([In] object obj0) => Sounds.lambda\u0024load\u002448(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon49 : Cons
    {
      internal __\u003C\u003EAnon49()
      {
      }

      public void get([In] object obj0) => Sounds.lambda\u0024load\u002449(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon50 : Cons
    {
      internal __\u003C\u003EAnon50()
      {
      }

      public void get([In] object obj0) => Sounds.lambda\u0024load\u002450(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon51 : Cons
    {
      internal __\u003C\u003EAnon51()
      {
      }

      public void get([In] object obj0) => Sounds.lambda\u0024load\u002451(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon52 : Cons
    {
      internal __\u003C\u003EAnon52()
      {
      }

      public void get([In] object obj0) => Sounds.lambda\u0024load\u002452(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon53 : Cons
    {
      internal __\u003C\u003EAnon53()
      {
      }

      public void get([In] object obj0) => Sounds.lambda\u0024load\u002453(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon54 : Cons
    {
      internal __\u003C\u003EAnon54()
      {
      }

      public void get([In] object obj0) => Sounds.lambda\u0024load\u002454(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon55 : Cons
    {
      internal __\u003C\u003EAnon55()
      {
      }

      public void get([In] object obj0) => Sounds.lambda\u0024load\u002455(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon56 : Cons
    {
      internal __\u003C\u003EAnon56()
      {
      }

      public void get([In] object obj0) => Sounds.lambda\u0024load\u002456(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon57 : Cons
    {
      internal __\u003C\u003EAnon57()
      {
      }

      public void get([In] object obj0) => Sounds.lambda\u0024load\u002457(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon58 : Cons
    {
      internal __\u003C\u003EAnon58()
      {
      }

      public void get([In] object obj0) => Sounds.lambda\u0024load\u002458(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon59 : Cons
    {
      internal __\u003C\u003EAnon59()
      {
      }

      public void get([In] object obj0) => Sounds.lambda\u0024load\u002459(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon60 : Cons
    {
      internal __\u003C\u003EAnon60()
      {
      }

      public void get([In] object obj0) => Sounds.lambda\u0024load\u002460(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon61 : Cons
    {
      internal __\u003C\u003EAnon61()
      {
      }

      public void get([In] object obj0) => Sounds.lambda\u0024load\u002461(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon62 : Cons
    {
      internal __\u003C\u003EAnon62()
      {
      }

      public void get([In] object obj0) => Sounds.lambda\u0024load\u002462(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon63 : Cons
    {
      internal __\u003C\u003EAnon63()
      {
      }

      public void get([In] object obj0) => Sounds.lambda\u0024load\u002463(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon64 : Cons
    {
      internal __\u003C\u003EAnon64()
      {
      }

      public void get([In] object obj0) => Sounds.lambda\u0024load\u002464(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon65 : Cons
    {
      internal __\u003C\u003EAnon65()
      {
      }

      public void get([In] object obj0) => Sounds.lambda\u0024load\u002465(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon66 : Cons
    {
      internal __\u003C\u003EAnon66()
      {
      }

      public void get([In] object obj0) => Sounds.lambda\u0024load\u002466(obj0);
    }
  }
}
