// Decompiled with JetBrains decompiler
// Type: mindustry.graphics.Pal
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.graphics;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System.Runtime.CompilerServices;

namespace mindustry.graphics
{
  public class Pal : Object
  {
    public static Color thoriumPink;
    public static Color items;
    public static Color command;
    public static Color sap;
    public static Color sapBullet;
    public static Color sapBulletBack;
    public static Color spore;
    public static Color shield;
    public static Color shieldIn;
    public static Color bulletYellow;
    public static Color bulletYellowBack;
    public static Color darkMetal;
    public static Color darkerMetal;
    public static Color missileYellow;
    public static Color missileYellowBack;
    public static Color meltdownHit;
    public static Color plastaniumBack;
    public static Color plastaniumFront;
    public static Color lightFlame;
    public static Color darkFlame;
    public static Color lightPyraFlame;
    public static Color darkPyraFlame;
    public static Color turretHeat;
    public static Color lightOrange;
    public static Color lightishOrange;
    public static Color lighterOrange;
    public static Color lightishGray;
    public static Color darkishGray;
    public static Color darkerGray;
    public static Color darkestGray;
    public static Color shadow;
    public static Color ammo;
    public static Color rubble;
    public static Color boostTo;
    public static Color boostFrom;
    public static Color lancerLaser;
    public static Color stoneGray;
    public static Color engine;
    public static Color health;
    public static Color heal;
    public static Color bar;
    public static Color accent;
    public static Color stat;
    public static Color gray;
    public static Color metalGrayDark;
    public static Color accentBack;
    public static Color place;
    public static Color remove;
    public static Color noplace;
    public static Color removeBack;
    public static Color placeRotate;
    public static Color breakInvalid;
    public static Color range;
    public static Color power;
    public static Color powerBar;
    public static Color powerLight;
    public static Color placing;
    public static Color unitFront;
    public static Color unitBack;
    public static Color lightTrail;
    public static Color surge;
    public static Color plastanium;
    public static Color redSpark;
    public static Color orangeSpark;
    public static Color redDust;
    public static Color redderDust;
    public static Color plasticSmoke;
    public static Color adminChat;
    public static Color logicBlocks;
    public static Color logicControl;
    public static Color logicOperations;
    public static Color logicIo;
    public static Color logicUnits;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(5)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Pal()
    {
    }

    [LineNumberTable(new byte[] {159, 140, 77, 143, 111, 143, 111, 111, 143, 143, 121, 153, 111, 143, 111, 143, 111, 143, 143, 111, 143, 111, 143, 111, 143, 143, 111, 111, 143, 111, 126, 126, 126, 126, 111, 143, 111, 143, 143, 111, 143, 111, 111, 106, 111, 111, 111, 111, 111, 111, 111, 111, 111, 106, 111, 111, 111, 111, 111, 138, 111, 143, 143, 143, 143, 111, 143, 111, 143, 143, 143, 111, 111, 111, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static Pal()
    {
      if (ByteCodeHelper.isAlreadyInited("mindustry.graphics.Pal"))
        return;
      Pal.thoriumPink = Color.valueOf("f9a3c7");
      Pal.items = Color.valueOf("2ea756");
      Pal.command = Color.valueOf("eab678");
      Pal.sap = Color.valueOf("665c9f");
      Pal.sapBullet = Color.valueOf("bf92f9");
      Pal.sapBulletBack = Color.valueOf("6d56bf");
      Pal.spore = Color.valueOf("7457ce");
      Pal.shield = Color.valueOf("ffd37f").a(0.7f);
      Pal.shieldIn = Color.__\u003C\u003Eblack.cpy().a(0.0f);
      Pal.bulletYellow = Color.valueOf("fff8e8");
      Pal.bulletYellowBack = Color.valueOf("f9c27a");
      Pal.darkMetal = Color.valueOf("6e7080");
      Pal.darkerMetal = Color.valueOf("565666");
      Pal.missileYellow = Color.valueOf("ffd2ae");
      Pal.missileYellowBack = Color.valueOf("e58956");
      Pal.meltdownHit = Color.valueOf("ffb98b");
      Pal.plastaniumBack = Color.valueOf("d8d97f");
      Pal.plastaniumFront = Color.valueOf("fffac6");
      Pal.lightFlame = Color.valueOf("ffdd55");
      Pal.darkFlame = Color.valueOf("db401c");
      Pal.lightPyraFlame = Color.valueOf("ffb855");
      Pal.darkPyraFlame = Color.valueOf("db661c");
      Pal.turretHeat = Color.valueOf("ab3400");
      Pal.lightOrange = Color.valueOf("f68021");
      Pal.lightishOrange = Color.valueOf("f8ad42");
      Pal.lighterOrange = Color.valueOf("f6e096");
      Pal.lightishGray = Color.valueOf("a2a2a2");
      Pal.darkishGray = new Color(0.3f, 0.3f, 0.3f, 1f);
      Pal.darkerGray = new Color(0.2f, 0.2f, 0.2f, 1f);
      Pal.darkestGray = new Color(0.1f, 0.1f, 0.1f, 1f);
      Pal.shadow = new Color(0.0f, 0.0f, 0.0f, 0.22f);
      Pal.ammo = Color.valueOf("ff8947");
      Pal.rubble = Color.valueOf("1c1817");
      Pal.boostTo = Color.valueOf("ffad4d");
      Pal.boostFrom = Color.valueOf("ff7f57");
      Pal.lancerLaser = Color.valueOf("a9d8ff");
      Pal.stoneGray = Color.valueOf("8f8f8f");
      Pal.engine = Color.valueOf("ffbb64");
      Pal.health = Color.valueOf("ff341c");
      Pal.heal = Color.valueOf("98ffa9");
      Pal.bar = Color.__\u003C\u003Eslate;
      Pal.accent = Color.valueOf("ffd37f");
      Pal.stat = Color.valueOf("ffd37f");
      Pal.gray = Color.valueOf("454545");
      Pal.metalGrayDark = Color.valueOf("6e7080");
      Pal.accentBack = Color.valueOf("d4816b");
      Pal.place = Color.valueOf("6335f8");
      Pal.remove = Color.valueOf("e55454");
      Pal.noplace = Color.valueOf("ffa697");
      Pal.removeBack = Color.valueOf("a73e3e");
      Pal.placeRotate = Pal.accent;
      Pal.breakInvalid = Color.valueOf("d44b3d");
      Pal.range = Color.valueOf("f4ba6e");
      Pal.power = Color.valueOf("fbad67");
      Pal.powerBar = Color.valueOf("ec7b4c");
      Pal.powerLight = Color.valueOf("fbd367");
      Pal.placing = Pal.accent;
      Pal.unitFront = Color.valueOf("ffa665");
      Pal.unitBack = Color.valueOf("d06b53");
      Pal.lightTrail = Color.valueOf("ffe2a9");
      Pal.surge = Color.valueOf("f3e979");
      Pal.plastanium = Color.valueOf("a1b46e");
      Pal.redSpark = Color.valueOf("fbb97f");
      Pal.orangeSpark = Color.valueOf("d2b29c");
      Pal.redDust = Color.valueOf("ffa480");
      Pal.redderDust = Color.valueOf("ff7b69");
      Pal.plasticSmoke = Color.valueOf("f1e479");
      Pal.adminChat = Color.valueOf("ff4000");
      Pal.logicBlocks = Color.valueOf("d4816b");
      Pal.logicControl = Color.valueOf("6bb2b2");
      Pal.logicOperations = Color.valueOf("877bad");
      Pal.logicIo = Color.valueOf("a08a8a");
      Pal.logicUnits = Color.valueOf("c7b59d");
    }
  }
}
